using cookie.Recipes;


public class IngredientRegister
{
    public IEnumerable<Ingredient> All { get; } =new List<Ingredient>
    {
            new Wheatflour(),
            new Coconutflour(),
            new Butter(),
            new Cinnamon(),
            new Cardamom()
    };

    public Ingredient GetById(int id)
    {
        foreach(var ingredient in All)
        {
            if(id==ingredient.Id)
            {
                return ingredient;
            }

        }
        return null;
    }
}
