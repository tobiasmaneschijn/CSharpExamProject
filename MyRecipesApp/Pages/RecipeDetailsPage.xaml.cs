using MyRecipesApp.Logic;

namespace MyRecipesApp.Pages;

public partial class RecipeDetailsPage : ContentPage, IQueryAttributable
{
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var viewModel = ViewModelLocator.MainViewModelInstance;
        if (!query.ContainsKey("recipeId")) return;
        var recipeId = (string)query["recipeId"];
        viewModel.SetCurrentRecipe(recipeId);
        BindingContext = viewModel.CurrentRecipe;

    }

    public RecipeDetailsPage()
    {
        InitializeComponent();
    }
}