using System.Text.Json;
using System.Text.Json.Serialization;
using MyRecipesLib.Model;

namespace MyRecipesLib.Repository;

/**
 * <summary>
 * A repository for recipes. Saved locally on the device using a folder with a JSON file for each recipe for easy sharing.
 * </summary>
 */
public class LocalRecipeRepository : IRecipeRepository
{
    private readonly string _folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyRecipes");
    
    private readonly List<Recipe> _recipes = new();
    public LocalRecipeRepository()
    {
        Console.WriteLine(_folderPath);
        if (!Directory.Exists(_folderPath))
        {
            Directory.CreateDirectory(_folderPath);
            
            // Create a test recipe and save it in a file
            var recipe = new Recipe
            {
                Id = 1,
                Title = "Hot Water",
                PreparationTime = 1,
                CookingTime = 5,
                Description = "This is an amazing recipe on how to make hot water",
                Ingredients = new List<Ingredient>
                {
                    new()
                    {
                        Id = 1,
                        Name = "Water",
                        Quantity = 250,
                        Unit = "ml"
                    },
                    new()
                    {
                        Id = 2,
                        Name = "Kettle",
                        Quantity = 1,
                        Unit = "piece"
                    },
                    new()
                    {
                        Id = 3,
                        Name = "Cup",
                        Quantity = 1,
                        Unit = "piece"
                    }
                },
                Steps = new List<RecipeStep>
                {
                    new()
                    {
                        Id = 1,
                        Content = "Put water in a kettle and boil it"
                    },
                    new()
                    {
                        Id = 2,
                        Content = "Pour the water into a cup"
                    },
                    new()
                    {
                        Id = 3,
                        Content = "Enjoy your hot water"
                    }
                }
            };
            
            var json = JsonSerializer.Serialize(recipe);
            File.WriteAllText(Path.Combine(_folderPath, "hot_water.json"), json);
        }
        var files = Directory.GetFiles(_folderPath);
        
        foreach (var file in files)
        {
            // filter out non-recipe files
            if (!file.EndsWith(".json"))
            {
                continue;
            }
            
            var recipe =  JsonSerializer.Deserialize<Recipe>(File.ReadAllText(file));
            _recipes.Add(recipe);
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
        foreach (var recipe in _recipes)
        {
            Save(recipe);
        }
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
            if (!file.EndsWith(".json"))
            {
                continue;
            }
            
            var recipe =  JsonSerializer.Deserialize<Recipe>(File.ReadAllText(file));
            _recipes.Add(recipe);
        }
    }
    
    /*
     * Returns all the recipes in the repository
     */
    public IEnumerable<Recipe> GetAll()
    {
        return _recipes;   
    }

    /**
     * Returns a recipe from the repository
     */
    public Recipe Get(int id)
    {
        return _recipes.FirstOrDefault(r => r.Id == id);
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
    public void Remove(int id)
    {
        try
        {
            var recipe = _recipes.FirstOrDefault(r => r.Id == id);
            _recipes.Remove(recipe);
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
            _recipes.Remove(recipe);
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
}