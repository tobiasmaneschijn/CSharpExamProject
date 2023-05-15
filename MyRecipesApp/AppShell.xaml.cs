using MyRecipesApp.Logic;
using MyRecipesApp.Pages;

namespace MyRecipesApp;

public partial class AppShell : Shell
{
    public AppShell(MainViewModel viewModel)
    {
        InitializeComponent();

        Routing.RegisterRoute("recipes/details", typeof(RecipeDetailsPage));
    }
}