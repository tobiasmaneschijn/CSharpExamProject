using MyRecipesLib.Model;

namespace MyRecipesApp.Controls;

public partial class RecipeCell : ContentView
{
    public RecipeCell()
    {
        InitializeComponent();
        var tapGestureRecognizer = (TapGestureRecognizer)FindByName("TapGestureRecognizer");
    }

    // tapped event handler
    private async void OnTapped(object sender, EventArgs e)
    {
        var recipe = (Recipe)BindingContext;
        await Shell.Current.GoToAsync($"details?recipeId={recipe.Id}");
        var route = Shell.Current.CurrentItem.Route;
    }
}