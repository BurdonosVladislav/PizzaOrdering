namespace Po.Core
{
    public class Ingredient
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }

        public Ingredient(string name, decimal price, bool isAvailable = true)
        {
            Name = name;
            Price = price;
            IsAvailable = isAvailable;
        }

        public bool IsValid()
        {
            return !(string.IsNullOrWhiteSpace(Name) || Price < 0);
        }

        public override string ToString()
        {
            return $"Name: {Name}. Price: {Price}.";
        }
    }
}