namespace MyRecipesLib.Model;

public class RecipeGenerator
{
    private static readonly Random random = new();

    private static readonly string[] IngredientNames = 
        new[] { "Chicken", "Salt", "Pepper", "Onion", "Garlic", "Olive oil", "Tomatoes", "Pasta", "Basil", "Parmesan",
            "Beef", "Pork", "Lamb", "Fish", "Shrimp", "Crab", "Clams", "Lobster", "Tofu", "Eggs", "Milk", "Cream",
            "Butter", "Cheese", "Yogurt", "Sour cream", "Mayonnaise", "Vinegar", "Mustard", "Soy sauce", "Worcestershire sauce",
            "Hot sauce", "Chili powder", "Paprika", "Cumin", "Curry powder", "Ginger", "Cinnamon", "Nutmeg", "Cloves", 
            "Thyme", "Rosemary", "Oregano", "Parsley", "Cilantro", "Dill", "Mint", "Lemon", "Lime", "Orange",
            "Apple", "Banana", "Strawberries", "Blueberries", "Raspberries", "Grapes", "Pineapple", "Coconut", "Chocolate", "Vanilla"
        };
    
    private static readonly string[] Units =
        new[] { "cup", "tsp", "tbsp", "lb", "oz", "g", "ml", "pcs" };

    private static readonly string[] StepContents = 
        new[] { "Chop", "Mix", "Fry", "Boil", "Bake", "Grill", "Sauté", "Roast", "Marinate" };

    private static readonly string[] RecipeTypes = 
        new[] { "Stew", "Casserole", "Soup", "Roast", "Bake", "Pie", "Tart", "Pudding", "Cake", "Muffin", "Bread", 
            "Salad", "Curry", "Paella", "Risotto", "Lasagna", "Pizza", "Burger", "Sandwich", "Pasta", 
            "Ravioli", "Gnocchi", "Sushi", "Roll", "Noodles", "Tacos", "Burrito", "Guacamole", "Salsa", 
            "Dip", "Smoothie", "Juice", "Cocktail", "Steak", "Frittata", "Omelette", "Quiche", "Pancakes", 
            "Waffles", "Crepes", "Brownies", "Cookies", "Ice cream", "Sorbet", "Trifle", "Mousse", "Custard", 
            "Brulee", "Parfait", "Fondue", "Goulash", "Chowder", "Bisque", "Gumbo", "Tagine", "Ratatouille", 
            "Strudel", "Fritters", "Doughnuts", "Pretzel", "Chutney", "Jam", "Jelly", "Preserves", "Pickles" };

    
    public static Recipe GenerateRandomRecipe()
    {
        string name = IngredientNames[random.Next(IngredientNames.Length)];
        string type = RecipeTypes[random.Next(RecipeTypes.Length)];
        var id = Guid.NewGuid().ToString();
        var title = name + " " + type;
        var description = "This is a randomly generated recipe using " + title;
        var preparationTime = random.Next(5, 60);
        var cookingTime = random.Next(10, 180);
        var ingredients = GenerateRandomIngredients();
        var steps = GenerateRandomSteps();
        var imageUrl = $"https://loremflickr.com/300/200/"+name+"+"+type ;
        return new Recipe(id, title, description, preparationTime, cookingTime, steps, ingredients, imageUrl);
    }

    private static List<Ingredient> GenerateRandomIngredients()
    {
        var ingredients = new List<Ingredient>();
        var numberOfIngredients = random.Next(3, 10);

        for (int i = 0; i < numberOfIngredients; i++)
        {
            var id = Guid.NewGuid().ToString();
            var name = IngredientNames[random.Next(IngredientNames.Length)];
            var quantity = random.Next(1, 5);
            var unit = Units[random.Next(Units.Length)];
            var notes = "Some notes about " + name;

            ingredients.Add(new Ingredient(id, name, quantity, unit, notes));
        }

        return ingredients;
    }

    private static List<RecipeStep> GenerateRandomSteps()
    {
        var steps = new List<RecipeStep>();
        var numberOfSteps = random.Next(3, 7);

        for (int i = 0; i < numberOfSteps; i++)
        {
            var content = StepContents[random.Next(StepContents.Length)] + " the ingredients";
            var videoUrl = "https://www.youtube.com/watch?v=5zgEgfYqAUQ";
            var imageBase64 = "";

            steps.Add(new RecipeStep(i+1, content, videoUrl, imageBase64));
        }

        return steps;
    }
}