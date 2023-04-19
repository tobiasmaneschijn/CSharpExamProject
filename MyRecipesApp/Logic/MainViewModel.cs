using System.Collections.ObjectModel;
using System.Windows.Input;
using MyRecipesLib.Logic;
using MyRecipesLib.Model;
using MyRecipesLib.Repository;

namespace MyRecipesApp.Logic;

public class MainViewModel
{
    private  IRecipeRepository RecipeRepository { get; } = new LocalRecipeRepository();
    public RecipeAssistant AppRecipeAssistant { get; }
    public Recipe CurrentRecipe { get; set; }

   

    public ObservableCollection<Recipe> Recipes => RecipeRepository.Recipes();

    public MainViewModel()
    {
        AppRecipeAssistant = new RecipeAssistant(RecipeRepository);
    }
    
   

    public void SetCurrentRecipe(string recipeId)
    {
        var recipe = RecipeRepository.Recipes() .FirstOrDefault(r => r.Id == recipeId);
        CurrentRecipe = recipe;
    }
}