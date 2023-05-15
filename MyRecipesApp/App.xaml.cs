using MyRecipesApp.Logic;
using MyRecipesLib.Repository;

namespace MyRecipesApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        var services = new ServiceCollection();
        services.AddScoped<IRecipeRepository, LocalRecipeRepository>();
        services.AddScoped<MainViewModel>();
        var serviceProvider = services.BuildServiceProvider();
        ViewModelLocator.Init(serviceProvider);
        MainPage = new AppShell(serviceProvider.GetService<MainViewModel>());
    }
}