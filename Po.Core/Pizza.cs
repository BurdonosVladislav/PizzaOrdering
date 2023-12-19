namespace Po.Core
{
    public class Pizza
    {
        public string Type { get; set; }
        public List<string> Ingredients { get; set; }
        public int CountOrders { get; private set; }

        public Pizza(string type, List<string> ingredients)
        {
            Type = type;
            Ingredients = ingredients;
            CountOrders = 0;
        }

        public void AddOrder()
        {
            CountOrders++;
        }

        public void RemoveOrder()
        {
            CountOrders--;
        }
    }
}
