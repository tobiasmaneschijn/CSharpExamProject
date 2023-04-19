using System.Collections.ObjectModel;
using MyRecipesLib.Model;

namespace MyRecipesLib.Repository
{
	public class TestRecipeRepository : IRecipeRepository
	{
		// Private list of recipes including a few test recipes
		private readonly ObservableCollection<Recipe> _recipes = new()
		{
			new Recipe
			{
				Id = "water",
				Title = "Hot Water",
				PreparationTime = 1,
				CookingTime = 5,
				Description = "This is an amazing recipe on how to make hot water",
				Ingredients = new List<Ingredient>
				{
					new Ingredient
					{
						Id = "water",
						Name = "Water",
						Quantity = 250,
						Unit = "ml"
					},
					new Ingredient
					{
						Id = "kettle",
						Name = "Kettle",
						Quantity = 1,
						Unit = "piece"
					},
					new Ingredient
					{
						Id = "cup",
						Name = "Cup",
						Quantity = 1,
						Unit = "piece"
					}
				},
				Steps = new List<RecipeStep>
				{
					new RecipeStep
					{
						Id = 1,
						Content = "Put water in a kettle and boil it"
					},
					new RecipeStep
					{
						Id = 2,
						Content = "Pour the water into a cup"
					},
					new RecipeStep
					{
						Id = 3,
						Content = "Enjoy your hot water"
					}
				}
			}
		};

		public ObservableCollection<Recipe> Recipes()
		{
			return _recipes;
		}

		public Recipe Get(string id)
		{
			return _recipes.FirstOrDefault(r => r.Id == id);
		}

		public Recipe Add(Recipe item)
		{
			_recipes.Add(item);
			return item;
		}

		public void Remove(string id)
		{
			_recipes.Remove(_recipes.FirstOrDefault(r => r.Id == id));
		}

		public bool Update(Recipe item)
		{
			Recipe recipe = _recipes.FirstOrDefault(r => r.Id == item.Id);

			if (recipe != null)
			{
				recipe.Title = item.Title;
				recipe.Description = item.Description;
				recipe.Ingredients = item.Ingredients;
				recipe.Steps = item.Steps;
				recipe.PreparationTime = item.PreparationTime;
				recipe.CookingTime = item.CookingTime;
				return true;
			}
			return false;
		}
	}
}
