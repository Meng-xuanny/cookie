using cookie.Recipes;
/// <summary>
/// cookie app
/// </summary>
public class CookieApp
{
    private IUserInteraction _userInteractions;
    private IRecipeRepo _recipeRepository;


    public CookieApp(IUserInteraction userInteractions, IRecipeRepo recipeRepository)
    {
        _recipeRepository = recipeRepository;
        _userInteractions = userInteractions;

    }

    public void Run(string filePath)
    {
        var allRecipes = _recipeRepository.ReadRecipes(filePath);
        _recipeRepository.PrintExistingRecipes(allRecipes);

        _userInteractions.PromptToCreateRecipe();

        var ingredients = _userInteractions.ReadUserIngredients();

        if (ingredients.Count() > 0)
        {
            var recipe = new Recipe(ingredients);//making selected ingredients a new recipe
            allRecipes.Add(recipe);
            _recipeRepository.WriteRecipe(filePath, allRecipes);
            _userInteractions.ShowMessage("Recipe added.");
            _userInteractions.ShowMessage(recipe.ToReadableStr());
        }
        else
        {
            _userInteractions.ShowMessage("No ingredients have been selected. Recipe will not be saved.");
        }

        _userInteractions.Exit();
    }
}
