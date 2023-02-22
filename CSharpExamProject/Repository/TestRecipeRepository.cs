using MyRecipesLib.Model;

namespace MyRecipesLib.Repository;

 public class TestRecipeRepository : IRecipeRepository
{
    // Private list of recipes including a few test recipes
    private readonly List<Recipe> _recipes = new()
    {
        new Recipe
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
        }
    };


    public IEnumerable<Recipe> GetAll()
    {
        return _recipes;
    }

    public Recipe Get(int id)
    {
        return _recipes.FirstOrDefault(r => r.Id == id);
    }

    public Recipe Add(Recipe item)
    {
        _recipes.Add(item);
        return item;
    }

    public void Remove(int id)
    {
        _recipes.Remove(_recipes.FirstOrDefault(r => r.Id == id));
    }

    public bool Update(Recipe item)
    {
        Recipe recipe = _recipes.FirstOrDefault(r => r.Id == item.Id);

        recipe.Title = item.Title;
        recipe.Description = item.Description;
        recipe.Ingredients = item.Ingredients;
        recipe.Steps = item.Steps;
        recipe.PreparationTime = item.PreparationTime;
        recipe.CookingTime = item.CookingTime;
        return true;
    }
}