namespace MyRecipesLib.Model;

public class Recipe
{
    public Recipe()
    {
    }

    public Recipe(string id, string title, string description, int preparationTime, int cookingTime,
        List<RecipeStep> steps, List<Ingredient> ingredients, string imageUrl)
    {
        Id = id;
        Title = title;
        Description = description;
        PreparationTime = preparationTime;
        CookingTime = cookingTime;
        Steps = steps;
        Ingredients = ingredients;
        ImageUrl = imageUrl;
    }

    /**
     * <summary>
     *     The name of the recipe
     * </summary>
     */

    public string Title { get; set; } = "Empty Recipe";


    /**
     * <summary>
     *     The description of the recipe. Can be quite long.
     * </summary>
     * @TODO Use markdown for the description.
     */
    public string Description { get; set; } = "No description";

    /**
     * <summary>
     *     How long to prepare ingredients in minutes
     * </summary>
     */
    public int PreparationTime { get; set; }

    /**
     * <summary>
     *     How long to cook the recipe
     * </summary>
     */
    public int CookingTime { get; set; }

    /**
     * <summary>
     *     Identifier of the recipe
     * </summary>
     */
    public string Id { get; set; } = "test_empty";

    /**
     * <summary>
     *     The steps of the recipe
     * </summary>
     */
    public List<RecipeStep> Steps { get; set; } = new();

    /**
     * <summary>
     *     The ingredients of the recipe
     * </summary>
     */
    public List<Ingredient> Ingredients { get; set; } = new();

    /**
     * <summary>
     *     Url to the image of the recipe
     * </summary>
     */
    public string ImageUrl { get; set; } = string.Empty;

    /**
     * <summary>
     *     Returns a string representation of the recipe
     * </summary>
     */
    public override string ToString()
    {
        return Title;
    }
}