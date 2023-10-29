namespace cookie.Recipes
{
    public class Butter : Ingredient
    {
        public override int Id { get; } = 3;

        public override string Name { get; } = "Butter";
        public override string Instruction => $"Melt on low heat. {base.Instruction}";

    }
}

