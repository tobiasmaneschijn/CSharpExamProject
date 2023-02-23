using System.Collections.ObjectModel;
using System.Windows.Input;
using MyRecipesLib.Logic;
using MyRecipesLib.Model;
using MyRecipesLib.Repository;

namespace MyRecipesApp.Logic;

public class MainViewModel
{
    // make it a singleton
    
    private  IRecipeRepository RecipeRepository { get; } = new LocalRecipeRepository();
    public RecipeAssistant AppRecipeAssistant { get; }

    public ObservableCollection<Recipe> Recipes
    {
        get => RecipeRepository.Recipes();
    }

    public MainViewModel()
    {
        AppRecipeAssistant = new RecipeAssistant(RecipeRepository);
    }
    
    
    public ICommand OpenRecipeCommand { get; }

    private async Task ExecuteOpenRecipeCommand(Recipe recipe)
    {
        await Shell.Current.GoToAsync($"RecipeDetailsPage?recipeId={recipe.Id}");
    }
    
}