using System.Text;
using System.Text.Json;

namespace MyRecipesLib.Model.Quotes;
/*
 *   {
    "quote": "To be interested in food but not in food production is clearly absurd.",
    "author": "Wendell Berry",
    "category": "food"
  }
 */
public class QuoteData
{
    public string Quote { get; set; } = "No quote";
    public string Author { get; set; } = "No author";
    public string Category { get; set; } = "No category";
    
    public override string ToString()
    {
        return $"{Quote} - {Author}";
    }
    
    public string ToJson()
    {
        return JsonSerializer.Serialize(this);
    }
    
    public static QuoteData FromJson(string json)
    {
        return JsonSerializer.Deserialize<QuoteData>(json) ?? new QuoteData();
    }
}