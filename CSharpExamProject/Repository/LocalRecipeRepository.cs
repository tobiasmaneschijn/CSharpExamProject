using System.Collections.ObjectModel;
using System.Text.Json;
using MyRecipesLib.Model;
using RandomDataGenerator;
using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Randomizers;

namespace MyRecipesLib.Repository;

/**
 * <summary>
 *     A repository for recipes. Saved locally on the device using a folder with a JSON file for each recipe for easy
 *     sharing.
 * </summary>
 */
public class LocalRecipeRepository : IRecipeRepository
{
    private readonly string _folderPath =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyRecipes");

    private readonly ObservableCollection<Recipe> _recipes = new();


    public LocalRecipeRepository(string folderPath)
    {
        _folderPath = folderPath;
        Initialize();
    }

    public LocalRecipeRepository()
    {
        Initialize();
    }

    /*
     * Returns all the recipes in the repository
     */
    public ObservableCollection<Recipe> Recipes()
    {
        return _recipes;
    }

    /**
     * Returns a recipe from the repository
     */
    public Recipe Get(string id)
    {
        return _recipes.FirstOrDefault(r => r.Id == id) ?? new Recipe();
    }

    /**
     * Adds a recipe to the repository and saves it in a file
     */
    public Recipe Add(Recipe item)
    {
        _recipes.Add(item);
        Save(item);
        return item;
    }

    /**
     * Removes a recipe from the repository and deletes the file
     */
    public void Remove(string id)
    {
        try
        {
            var recipe = _recipes.FirstOrDefault(r => r.Id == id);
            _recipes.Remove(recipe ?? throw new InvalidOperationException());
            File.Delete(Path.Combine(_folderPath, $"{recipe.Title.Replace(" ", "_")}.json"));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    /**
     * Updates a recipe in the repository and saves it in a file
     */
    public bool Update(Recipe item)
    {
        try
        {
            var recipe = _recipes.FirstOrDefault(r => r.Id == item.Id);
            _recipes.Remove(recipe ?? throw new InvalidOperationException());
            _recipes.Add(item);
            Save(item);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    private void Initialize()
    {
        Console.WriteLine(_folderPath);
        if (!Directory.Exists(_folderPath))
        {
            Directory.CreateDirectory(_folderPath);

         
            for (var i = 0; i < 50; i++)
            {
                var r = RecipeGenerator.GenerateRandomRecipe();
                Save(r);
            }
        }

        var files = Directory.GetFiles(_folderPath);

        foreach (var file in files)
        {
            // filter out non-recipe files
            if (!file.EndsWith(".json")) continue;

            var recipe = JsonSerializer.Deserialize<Recipe>(File.ReadAllText(file));
            _recipes.Add(recipe ?? throw new InvalidOperationException());
        }
    }

    /**
     * Saves a recipe in a file
     */
    private void Save(Recipe recipe)
    {
        try
        {
            var json = JsonSerializer.Serialize(recipe);
            File.WriteAllText(Path.Combine(_folderPath, $"{recipe.Title.Replace(" ", "_")}.json"), json);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /**
     * Saves all the recipes in individual files
     */
    private void SaveAll()
    {
        foreach (var recipe in _recipes) Save(recipe);
    }

    /*
     * Reload all the recipes from the files
     */
    public void Reload()
    {
        _recipes.Clear();
        var files = Directory.GetFiles(_folderPath);

        foreach (var file in files)
        {
            // filter out non-recipe files
            if (!file.EndsWith(".json")) continue;

            var recipe = JsonSerializer.Deserialize<Recipe>(File.ReadAllText(file));
            _recipes.Add(recipe ?? throw new InvalidOperationException());
        }
    }
}