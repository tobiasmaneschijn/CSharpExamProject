using MyRecipesLib.Model;

namespace MyRecipesLib.Repository;

public interface IRecipeRepository
{
    IEnumerable<Recipe> GetAll();
    Recipe Get(int id);
    Recipe Add(Recipe item);
    void Remove(int id);
    bool Update(Recipe item);
}