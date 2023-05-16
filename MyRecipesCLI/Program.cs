using System;
using MyRecipesLib.Model;
using MyRecipesLib.Repository;

class Program
{
    static void Main(string[] args)
    {
        var repo = new LocalRecipeRepository();
        
        if (args.Length == 0)
        {
            Console.WriteLine("Please enter a command.");
            return;
        }

        var command = args[0];

        switch (command)
        {
            case "add":
                if (args.Length < 3)
                {
                    Console.WriteLine("Please provide the title and description for the recipe.");
                    return;
                }
                var newRecipe = new Recipe { Title = args[1], Description = args[2] };
                repo.Add(newRecipe);
                Console.WriteLine($"Added recipe: {newRecipe.Title}");
                break;
                
            case "edit":
                if (args.Length < 3)
                {
                    Console.WriteLine("Please provide the ID and new title of the recipe to edit.");
                    return;
                }
                var recipeToEdit = repo.Get(args[1]);
                if (recipeToEdit == null)
                {
                    Console.WriteLine($"Could not find a recipe with ID {args[1]}");
                    return;
                }
                recipeToEdit.Title = args[2];
                repo.Update(recipeToEdit);
                Console.WriteLine($"Updated recipe: {recipeToEdit.Title}");
                break;

            case "delete":
                if (args.Length < 2)
                {
                    Console.WriteLine("Please provide the ID of the recipe to delete.");
                    return;
                }
                repo.Remove(args[1]);
                Console.WriteLine($"Deleted recipe: {args[1]}");
                break;

            case "list":
                var recipes = repo.Recipes();
                foreach (var recipe in recipes)
                {
                    Console.WriteLine($"{recipe.Id}: {recipe.Title}");
                }
                break;

            default:
                Console.WriteLine($"Unrecognized command: {command}");
                break;
        }
    }
}
