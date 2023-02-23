using MyRecipesApp.Logic;
using MyRecipesApp.Pages;

namespace MyRecipesApp;

public partial class AppShell : Shell
{
    public AppShell(MainViewModel viewModel)
    {
        InitializeComponent();
        
        Routing.RegisterRoute(nameof(RecipesPage), typeof(RecipesPage));
        Routing.RegisterRoute(nameof(IngredientsPage), typeof(IngredientsPage));
        
    }
    
    
}