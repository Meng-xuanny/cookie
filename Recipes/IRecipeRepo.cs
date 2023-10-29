using cookie.Recipes;
/// <summary>
/// recipe
/// </summary>
///
/// 
/// interface--recipe
public interface IRecipeRepo
{
    void PrintExistingRecipes(IEnumerable<Recipe> allRecipes);
    List<Recipe> ReadRecipes(string filePath);
    void WriteRecipe(string filePath, List<Recipe> allRecipes);
}
