namespace MyRecipesApp.Logic;

public static class ViewModelLocator
{
    private static IServiceProvider _serviceProvider;

    public static void Init(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public static MainViewModel MainViewModelInstance => _serviceProvider.GetService<MainViewModel>();
}