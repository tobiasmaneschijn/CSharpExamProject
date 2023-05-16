using System;
using System.IO;
using MyRecipesLib.Model;
using MyRecipesLib.Repository;
using NUnit.Framework;

[TestFixture]
public class LocalRecipeRepositoryTests
{
    private string _testDirectory;
    private LocalRecipeRepository _repository;

    [SetUp]
    public void SetUp()
    {
        _testDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        Directory.CreateDirectory(_testDirectory);
        _repository = new LocalRecipeRepository(_testDirectory);
    }

    [TearDown]
    public void TearDown()
    {
        Directory.Delete(_testDirectory, true);
    }

    [Test]
    public void Initialize_Creates_Directory_If_Not_Exists()
    {
        string newDirectory = Path.Combine(_testDirectory, "NewDirectory");
        _repository = new LocalRecipeRepository(newDirectory);
        Assert.IsTrue(Directory.Exists(newDirectory));
    }

    [Test]
    public void Add_Recipe_Saves_File()
    {
        var recipe = new Recipe() { Id = "1", Title = "Test_Recipe" };
        _repository.Add(recipe);

        var filePath = Path.Combine(_testDirectory, $"{recipe.Title.Replace(" ", "_")}.json");
        Assert.IsTrue(File.Exists(filePath));
    }

    [Test]
    public void Remove_Recipe_Deletes_File()
    {
        var recipe = new Recipe() { Id = "2", Title = "Test_Recipe_To_Remove" };
        _repository.Add(recipe);

        var filePath = Path.Combine(_testDirectory, $"{recipe.Title.Replace(" ", "_")}.json");
        _repository.Remove(recipe.Id);

        Assert.IsFalse(File.Exists(filePath));
    }

    [Test]
    public void Update_Recipe_Updates_File()
    {
        var recipe = new Recipe() { Id = "3", Title = "Test_Recipe_To_Update" };
        _repository.Add(recipe);

        recipe.Title = "Updated_Title";
        _repository.Update(recipe);

        var filePath = Path.Combine(_testDirectory, $"{recipe.Title.Replace(" ", "_")}.json");
        Assert.IsTrue(File.Exists(filePath));
    }
    // More tests...
}