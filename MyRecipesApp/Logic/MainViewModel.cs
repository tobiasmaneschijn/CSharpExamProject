using System.Collections.ObjectModel;
using MyRecipesLib.Logic;
using MyRecipesLib.Model;
using MyRecipesLib.Repository;

namespace MyRecipesApp.Logic;

public class MainViewModel
{
    public MainViewModel()
    {
        AppRecipeAssistant = new RecipeAssistant(RecipeRepository);
    }

    private IRecipeRepository RecipeRepository { get; } = new LocalRecipeRepository();
    public RecipeAssistant AppRecipeAssistant { get; }
    public Recipe CurrentRecipe { get; set; }


    public ObservableCollection<Recipe> Recipes => RecipeRepository.Recipes();


    public void SetCurrentRecipe(string recipeId)
    {
        var recipe = RecipeRepository.Recipes().FirstOrDefault(r => r.Id == recipeId);
        CurrentRecipe = recipe;
    }
}