﻿// See https://aka.ms/new-console-template for more information

using MyRecipesLib.Logic;
using MyRecipesLib.Model;
using MyRecipesLib.Repository;


// Method that prints a recipe in a more readable way using different colors for each section
static void PrintRecipe(Recipe recipe)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(recipe.Title);
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(recipe.Description);
    Console.WriteLine($"Preparation time: {recipe.PreparationTime} minutes");
    Console.WriteLine($"Cooking time: {recipe.CookingTime} minutes");

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("Ingredients:");

    foreach (var ingredient in recipe.Ingredients)
        Console.WriteLine($"- {ingredient.Quantity} {ingredient.Unit} {ingredient.Name}");

    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Steps:");
    foreach (var step in recipe.Steps) Console.WriteLine($"- {step.Content}");

    Console.WriteLine();
}


IRecipeRepository recipeRepository = new LocalRecipeRepository();

foreach (var recipe in recipeRepository.Recipes())
{
    // PrintRecipe(recipe);
}

// Can the user make hot water with the ingredients they have? They don't have a kettle

RecipeAssistant recipeAssistant = new(recipeRepository);

var recipes = recipeAssistant.FindRecipesByIngredients(new List<Ingredient>
{
    new()
    {
        Id = "water",
        Name = "Water",
        Quantity = 250,
        Unit = "ml"
    },
    new()
    {
        Id = "cup",
        Name = "Cup",
        Quantity = 1,
        Unit = "piece"
    },
    new()
    {
        Id = "kettle",
        Name = "Kettle",
        Quantity = 1,
        Unit = "piece"
    }
});

foreach (var recipe in recipes) PrintRecipe(recipe);