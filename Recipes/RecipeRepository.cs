using cookie.Recipes;
/// /
/// / 
/// /
/// /implementation
public class RecipeRepository : IRecipeRepo
{
    private IStringsRepository _stringsRepository;
    private const string separator = ",";
    private IngredientRegister _ingredientRegister;

    public RecipeRepository(IStringsRepository stringsRepository, IngredientRegister ingredientRegister)
    {
        _stringsRepository = stringsRepository;
        _ingredientRegister = ingredientRegister;
    }

    public List<Recipe> ReadRecipes(string filePath)
    {
        var recipes = new List<Recipe>();
        List<string> recipesIdStrings= _stringsRepository.Read(filePath);//get the ids(in string format)

        
        foreach (var recipeIdString in recipesIdStrings)
        {
             var recipe = RecipeFromString(recipeIdString);//converting one string to a recipe obj
             recipes.Add(recipe);
        }

        return recipes;
        

        //return new List<Recipe>{
        //      new Recipe(new List<Ingredient>{
        //        new Wheatflour(),
        //        new Butter(),
        //        new Cinnamon()
        //    }),
        //    new Recipe(new List<Ingredient>{
        //        new Coconutflour(),
        //        new Butter(),
        //        new Cardamom()
        //    })
        //  };
    }

    private Recipe RecipeFromString(string recipeIdString)
    {
        var ingredientList = new List<Ingredient>();
        string[] idsString = recipeIdString.Split(separator);

        foreach(var idStr in idsString)
        {
            var id = int.Parse(idStr);
            var ingredient=_ingredientRegister.GetById(id);
            ingredientList.Add(ingredient);
        }
        return new Recipe(ingredientList);
    }

    public void PrintExistingRecipes(IEnumerable<Recipe> allRecipes)
    {
        if(allRecipes.Count()> 0)
        {
            Console.WriteLine("Existing recipes are: " + Environment.NewLine);
            var counter = 1;
            foreach(var recipe in allRecipes)
            {
                Console.WriteLine($"**** {counter} ****");
                Console.WriteLine(recipe.ToReadableStr());
                Console.WriteLine();
                ++counter;
            }

        }
    }

    public void WriteRecipe(string filePath, List<Recipe> allRecipes)
    {
        var recipeAsStrings = new List<string>();
        foreach(var recipe in allRecipes)
        {
            var idList = new List<int>();
            foreach(var ingredient in recipe.Ingredients)
            {
                idList.Add(ingredient.Id);
            }
            recipeAsStrings.Add(string.Join(separator, idList));
        }
        _stringsRepository.Write(filePath, recipeAsStrings);

    }

}
