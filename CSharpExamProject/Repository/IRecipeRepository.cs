using System.Collections.ObjectModel;
using MyRecipesLib.Model;

namespace MyRecipesLib.Repository;

public interface IRecipeRepository
{
    ObservableCollection<Recipe> Recipes();
    Recipe Get(int id);
    Recipe Add(Recipe item);
    void Remove(int id);
    bool Update(Recipe item);
}