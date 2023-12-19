using Po.Core;

namespace Po.UnitTests
{
    public class PizzaControllerTests
    {
        [Fact]
        public void AddIngredient_ShouldAddIngredient()
        {
            // arrange
            var pizzaController = new PizzaController();
            var ingredientName = "Ingredient";
            decimal ingredientPrice = 10;

            // act
            pizzaController.AddIngredient(ingredientName, ingredientPrice);

            // assert
            Assert.Contains(pizzaController.Ingredients,
                x => x.Name == ingredientName && x.Price == ingredientPrice);
        }

        [Fact]
        public void AddIngredient_TryAddTwoSameIngredient_ShouldThrowException()
        {
            // arrange
            var pizzaController = new PizzaController();
            var ingredientName = "Ingredient";
            decimal ingredientPrice = 10;

            // act
            pizzaController.AddIngredient(ingredientName, ingredientPrice);
           
            // assert
            Assert.Throws<InvalidOperationException>(() 
                => pizzaController.AddIngredient(ingredientName, ingredientPrice));
        }

        [Theory]
        [InlineData("", 5)]
        [InlineData("", -5)]
        public void AddIngredient_TryAddNotValidIngredient_ShouldThrowException(
            string ingredientName, decimal ingredientPrice)
        {
            // arrange
            var pizzaController = new PizzaController();

            // act

            // assert
            Assert.Throws<InvalidOperationException>(()
                => pizzaController.AddIngredient(ingredientName, ingredientPrice));
        }

        [Fact]
        public void AddPizza_ShouldAddPizza()
        {
            // arrange
            var pizzaController = new PizzaController();
            var pizzaType = "Type";

            // act
            pizzaController.CreatePizza(pizzaType);

            // assert
            Assert.Contains(pizzaController.Pizzas, x => x.Type == pizzaType);
        }

        [Fact]
        public void AddPizza_TryAddTwoSamePizza_ShouldAddIngredient()
        {
            // arrange
            var pizzaController = new PizzaController();
            var pizzaType = "Type";

            // act
            pizzaController.CreatePizza(pizzaType);

            // assert
            Assert.Throws<InvalidOperationException>(() => pizzaController.CreatePizza(pizzaType));
        }

        [Fact]
        public void AddIngredientToPizza_ShouldAddIngredientToPizza()
        {
            // arrange
            var pizzaController = new PizzaController();
            var ingredientName = "Ingredient";
            decimal ingredientPrice = 10;
            var pizzaType = "Type";

            // act
            pizzaController.CreatePizza(pizzaType);
            pizzaController.AddIngredient(ingredientName, ingredientPrice);
            pizzaController.AddIngredientToPizza(ingredientName, pizzaType);

            // assert
            Assert.Contains(pizzaController.Pizzas,
                x => x.Type == pizzaType && x.Ingredients.Contains(ingredientName));
        }

        [Fact]
        public void AddIngredientToPizza_TryAddNotExistIngredientToPizza_ShouldThrowException()
        {
            // arrange
            var pizzaController = new PizzaController();
            var ingredientName = "Ingredient";
            var pizzaType = "Type";

            // act
            pizzaController.CreatePizza(pizzaType);
            

            // assert
            Assert.Throws<InvalidOperationException>(() 
                => pizzaController.AddIngredientToPizza(ingredientName, pizzaType));
        }

        [Fact]
        public void AddIngredientToPizza_TryAddIngredientToNotExistPizza_ShouldThrowException()
        {
            // arrange
            var pizzaController = new PizzaController();
            var ingredientName = "Ingredient";
            decimal ingredientPrice = 10;
            var pizzaType = "Type";

            // act
            pizzaController.AddIngredient(ingredientName, ingredientPrice);


            // assert
            Assert.Throws<InvalidOperationException>(()
                => pizzaController.AddIngredientToPizza(ingredientName, pizzaType));
        }

        [Fact]
        public void RemoveIngredientOfPizza_ShouldRemoveIngredientOfPizza()
        {
            // arrange
            var pizzaController = new PizzaController();
            var ingredientName = "Ingredient";
            decimal ingredientPrice = 10;
            var pizzaType = "Type";

            // act
            pizzaController.CreatePizza(pizzaType);
            pizzaController.AddIngredient(ingredientName, ingredientPrice);
            pizzaController.AddIngredientToPizza(ingredientName, pizzaType);
            pizzaController.RemoveIngredientOfPizza(ingredientName, pizzaType);

            var pizza = pizzaController.Pizzas.First(x => x.Type == pizzaType);

            // assert
            Assert.DoesNotContain(pizza.Ingredients, x => x == ingredientName);
        }

        [Fact] 
        public void RemoveIngredientOfPizza_TryRemoveNotExistIngredientOfPizza_ShouldRemoveIngredientOfPizza()
        {
            // arrange
            var pizzaController = new PizzaController();
            var ingredientName = "Ingredient";
            var pizzaType = "Type";

            // act
            pizzaController.CreatePizza(pizzaType);

            // assert
            Assert.Throws<InvalidOperationException>(()
                => pizzaController.RemoveIngredientOfPizza(ingredientName, pizzaType));
        }

        
    }
}