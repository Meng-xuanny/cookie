using cookie.Recipes;

public class ConsoleUserInteractions : IUserInteraction
{
    private readonly IngredientRegister _ingredientRegister;

    public ConsoleUserInteractions(IngredientRegister ingredientRegister)
    {
        _ingredientRegister = ingredientRegister;
    }

    public void PromptToCreateRecipe()
    {
        Console.WriteLine("Create a new cookie recipe. Available ingredients are: ");
        foreach(var ing in _ingredientRegister.All)
        {
            Console.WriteLine($"{ing.Id}. {ing.Name}");
        }
    }


    public IEnumerable<Ingredient> ReadUserIngredients()
    {
        var ingredients = new List<Ingredient>();
        bool correctId = false;
        while (!correctId)
        {
            Console.WriteLine("Add an ingredient by its ID or type anything else if finished.");

            var userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int id))
            {
                var userSelectedIngredient = _ingredientRegister.GetById(id);

                if(userSelectedIngredient is not null)
                {
                    ingredients.Add(userSelectedIngredient);
                }
                else
                {
                    Console.WriteLine("you selected nothing.");
                }
            }

            else
            {
                correctId = true;
            }
        }
        return ingredients;

    }

    public void Exit()
    {
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

}
