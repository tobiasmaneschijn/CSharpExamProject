using MyRecipesLib.Model;
using MyRecipesLib.Repository;

namespace MyRecipesLib.Logic;

/*
 * <summary>
 *    The RecipeAssistant class is responsible for assisting the user in creating recipes, and for helping the user to find recipes.
 *    It also helps the user to find recipes based on the ingredients they have available and the time they have available.
 *    It also help the user choose food based on a specific diet.
 * </summary>
 */
public class RecipeAssistant
{
 
    /*
     * <summary>
     *    The RecipeAssistant constructor.
     * </summary>
     * <param name="recipeRepository">The repository to use for recipes.</param>
     * <param name="ingredientRepository">The repository to use for ingredients.</param>
     */
    public RecipeAssistant(IRecipeRepository recipeRepository)
    {
        RecipeRepository = recipeRepository;
    }
 
    /*
     * <summary>
     *    The repository to use for recipes.
     * </summary>
     */
    public IRecipeRepository RecipeRepository { get; set; }
 

 
    /*
     * <summary>
     *    Returns a list of recipes that can be made with the ingredients the user has available.
     * </summary>
     * <param name="ingredients">The ingredients the user has available.</param>
     * <returns>A list of recipes that can be made with the ingredients the user has available.</returns>
     */
    public List<Recipe> FindRecipesByIngredients(List<Ingredient> ingredients)
    {
        List<Recipe> recipes = new();
        foreach (Recipe recipe in RecipeRepository.Recipes())
        {
            bool canMake = true;
            foreach (Ingredient ingredient in recipe.Ingredients)
            {
                if (!ingredients.Contains(ingredient))
                {
                    canMake = false;
                    break;
                }
            }
            if (canMake)
            {
                recipes.Add(recipe);
            }
        }
        return recipes;
    }
 
    /*
     * <summary>
     *    Returns a list of recipes that can be made with the ingredients the user has available and the time the user has available.
     * </summary>
     * <param name="ingredients">The ingredients the user has available.</param>
     * <param name="time">The time the user has available.</param>
     * <returns>A list of recipes that can be made with the ingredients the user has available and the time the user has available.</returns>
     */
    public List<Recipe> FindRecipesByIngredientsAndTime(List<Ingredient> ingredients, int time)
    {
        List<Recipe> recipes = new();
        foreach (var recipe in RecipeRepository.Recipes())
        {
            bool can = true;
            foreach (Ingredient ingredient in recipe.Ingredients)
            {
                if (!ingredients.Contains(ingredient))
                {
                    can = false;
                    break;
                }
            }

            if (can && recipe.PreparationTime + recipe.CookingTime <= time)
            {
                recipes.Add(recipe);
            }
        }
        return recipes;
    }
}