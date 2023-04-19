using System.Collections.ObjectModel;
using MyRecipesLib.Model;

namespace MyRecipesLib.Repository;

public interface IRecipeRepository
{
    ObservableCollection<Recipe> Recipes();
    Recipe Get(string id);
    Recipe Add(Recipe item);
    void Remove(string id);
    bool Update(Recipe item);
}