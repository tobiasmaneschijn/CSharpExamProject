using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyRecipesLib.Model;
using MyRecipesLib.Repository;

namespace MyRecipesTest
{
	[TestClass]
	public class LocalRecipeRepositoryTests
	{
		private IRecipeRepository _repository;
		private readonly string _testFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyRecipesTest");

		[TestInitialize]
		public void Initialize()
		{
			// Initialize the repository with the test folder path
			_repository = new LocalRecipeRepository(_testFolderPath);
		}

		[TestCleanup]
		public void Cleanup()
		{
			// Delete the test folder after each test run
			if (Directory.Exists(_testFolderPath))
			{
				Directory.Delete(_testFolderPath, true);
			}
		}

		[TestMethod]
		public void TestRecipes()
		{
			var recipes = _repository.Recipes();
			Assert.IsNotNull(recipes);
			Assert.IsTrue(recipes.Count > 0);
		}

		[TestMethod]
		public void TestGetRecipeById()
		{
			var recipe = _repository.Get("hot_water");
			Assert.IsNotNull(recipe);
			Assert.AreEqual("Hot Water", recipe.Title);
		}

		[TestMethod]
		public void TestAddRecipe()
		{
			var newRecipe = new Recipe
			{
				Id = "test_recipe",
				Title = "Test Recipe",
				// Add other properties as needed
			};

			_repository.Add(newRecipe);
			var addedRecipe = _repository.Get("test_recipe");
			Assert.IsNotNull(addedRecipe);
			Assert.AreEqual("Test Recipe", addedRecipe.Title);
		}

		[TestMethod]
		public void TestUpdateRecipe()
		{
			var recipeToUpdate = _repository.Get("hot_water");
			Assert.IsNotNull(recipeToUpdate);

			recipeToUpdate.Title = "Updated Hot Water";
			_repository.Update(recipeToUpdate);

			var updatedRecipe = _repository.Get("hot_water");
			Assert.IsNotNull(updatedRecipe);
			Assert.AreEqual("Updated Hot Water", updatedRecipe.Title);
		}

		[TestMethod]
		public void TestRemoveRecipe()
		{
			var newRecipe = new Recipe
			{
				Id = "test_recipe",
				Title = "Test Recipe",
				// Add other properties as needed
			};

			_repository.Add(newRecipe);
			var addedRecipe = _repository.Get("test_recipe");
			Assert.IsNotNull(addedRecipe);

			_repository.Remove("test_recipe");
			var removedRecipe = _repository.Get("test_recipe");
			Assert.IsNull(removedRecipe);
		}
	}
}
