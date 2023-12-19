namespace Po.Core
{
    public class PizzaController
    {
        public List<Pizza> Pizzas { get; set; }
        public List<Ingredient> Ingredients { get; set; }

        public PizzaController()
        {
            Pizzas = new();
            Ingredients = new();
        }

        public List<Ingredient> GetAvailableIngredients()
        {
            return Ingredients
                .Where(x => x.IsAvailable)
                .ToList();
        }

        private bool IsIngredientExist(string ingredientName)
        {
            return Ingredients
                .Where(x => x.Name == ingredientName)
                .Any();
        }

        private bool IsPizzaExist(string pizzaType)
        {
            return Pizzas
                .Where(x => x.Type == pizzaType)
                .Any();
        }

        public void AddIngredient(string name, decimal price)
        {
            var ingredient = new Ingredient(name, price);

            if (ingredient.IsValid() == false)
                throw new InvalidOperationException("Ingredient is not valid.");

            if (IsIngredientExist(name))
                throw new InvalidOperationException("Ingredient already exist.");

            Ingredients.Add(ingredient);
        }

        public void CreatePizza(string pizzaType)
        {
            if (IsPizzaExist(pizzaType))
                throw new InvalidOperationException("Pizza already exist.");

            var newPizza = new Pizza(pizzaType, new());

            Pizzas.Add(newPizza);
        }

        public void AddIngredientToPizza(string ingredientName, string pizzaType)
        {
            if (IsIngredientExist(ingredientName) == false)
                throw new InvalidOperationException("Ingredient is not exist.");

            if (IsPizzaExist(pizzaType) == false)
                throw new InvalidOperationException("Pizza is not exist.");

            var pizza = Pizzas.First(x => x.Type == pizzaType);

            if (pizza.Ingredients.Contains(ingredientName))
                throw new InvalidOperationException($"{pizzaType} already contains {ingredientName}.");

            pizza.Ingredients.Add(ingredientName);
        }

        public void RemoveIngredientOfPizza(string ingredientName, string pizzaType)
        {
            if (IsPizzaExist(pizzaType) == false)
                throw new InvalidOperationException("Pizza is not exist.");

            var pizza = Pizzas.First(x => x.Type == pizzaType);

            if (pizza.Ingredients.Contains(ingredientName) == false)
                throw new InvalidOperationException($"{pizzaType} is not contains {ingredientName}.");

            pizza.Ingredients.Remove(ingredientName);
        }
    }
}
