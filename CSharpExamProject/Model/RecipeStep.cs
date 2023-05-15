namespace MyRecipesLib.Model;

public class RecipeStep
{
    public RecipeStep()
    {
    }

    public RecipeStep(int id, string content, string videoUrl, string imageBase64)
    {
        Id = id;
        Content = content;
        VideoUrl = videoUrl;
        ImageBase64 = imageBase64;
    }

    public int Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public string VideoUrl { get; set; } = string.Empty;
    public string ImageBase64 { get; set; } = string.Empty;
}