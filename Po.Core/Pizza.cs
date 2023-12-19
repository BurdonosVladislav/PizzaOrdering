namespace Po.Core
{
    public class Pizza
    {
        public string Type { get; set; }
        public List<string> Ingredients { get; set; }

        public Pizza(string type, List<string> ingredients)
        {
            Type = type;
            Ingredients = ingredients;
        }
    }
}
