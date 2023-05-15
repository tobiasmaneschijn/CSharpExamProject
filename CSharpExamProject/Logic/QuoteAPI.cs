using System.Net.Http.Json;
using MyRecipesLib.Model.Quotes;

namespace MyRecipesLib.Logic;

public class QuoteAPI
{
    
    
    private const string endpoint = "https://api.api-ninjas.com/v1/quotes?category=food";

    //

    public static async Task<QuoteData> GetQuote()
    {
        HttpClient client = new HttpClient();
        Console.WriteLine( 
            "Getting quote from API"
        );
        // set the API key in the header X-Api-Key 
        
        client.DefaultRequestHeaders.Add("X-Api-Key", "igU7ZmdXyRlcNRx1VsKtng==is8efabPfwtQL5dc");

        QuoteData quote = new QuoteData();
        try
        {
            var res = await client.GetFromJsonAsync<QuoteData[]>(endpoint);
            
            if (res != null)
            {
                Console.WriteLine("Got quote from API");
                Console.WriteLine(res.ToString());
                quote = res[0];
            }
            

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return quote;
    }
}