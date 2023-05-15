using MyRecipesLib.Logic;
using MyRecipesLib.Model;
using MyRecipesLib.Repository;

namespace MyRecipesWApp.Data;

internal class RecipesService
{
    private readonly RecipeAssistant _recipeAssistant;
    private readonly IRecipeRepository _recipeRepository;

    public RecipesService()
    {
        _recipeRepository = new LocalRecipeRepository();
        _recipeAssistant = new RecipeAssistant(_recipeRepository);
    }


    public Task<Recipe[]> GetRecipesAsync()
    {
        return Task.FromResult(_recipeRepository.Recipes().ToArray());
    }

    public Task<Recipe> GetRecipeAsync(string id)
    {
        return Task.FromResult(_recipeRepository.Recipes().FirstOrDefault(r => r.Id == id));
    }

    public Task<Recipe> AddRecipeAsync(Recipe recipe)
    {
        _recipeRepository.Add(recipe);
        return Task.FromResult(recipe);
    }

    public Task<Recipe> UpdateRecipeAsync(Recipe recipe)
    {
        _recipeRepository.Update(recipe);
        return Task.FromResult(recipe);
    }

    public Task<Recipe> DeleteRecipeAsync(string id)
    {
        var recipe = _recipeRepository.Recipes().FirstOrDefault(r => r.Id == id);
        _recipeRepository.Remove(id);
        return Task.FromResult(recipe);
    }
}