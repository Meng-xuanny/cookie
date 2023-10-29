
//interface--user
public interface IUserInteraction
{
    void Exit();
    void PromptToCreateRecipe();
    IEnumerable<Ingredient> ReadUserIngredients();
    void ShowMessage(string message);
}
