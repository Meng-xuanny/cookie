using cookie.Recipes;

public class Recipe
    {
        public  IEnumerable<Ingredient> Ingredients { get; }

        public Recipe(IEnumerable<Ingredient> ingredients)
        {
            Ingredients = ingredients;
        }

        public  string ToReadableStr()
        {
            var steps = new List<string>();
            foreach(var ing in Ingredients)
            {
                steps.Add($"{ing.Name}. {ing.Instruction}");

            }
            return string.Join(Environment.NewLine, steps);
        }

    }

    


