using System;
using InvoiceApp.DesignPatterns;

namespace InvoiceApp.DesignPatterns
{
    public enum BurgerType
    {
        Cheese,
        Veggie,
        Chicken
    }

    public enum DrinkType
    {
        Soda,
        FruitJuice,
        Coke
    }
    public interface IBurger
    {
        void Cook();
    }
    public class CheeseBurger : IBurger
    {
        public void Cook()
        {
            Console.WriteLine("Cooking a Cheese Burger");
        }
    }
    public class VeggieBurger : IBurger
    {
        public void Cook()
        {
            Console.WriteLine("Cooking a Veggie Burger");
        }
    }
    public class ChickenBurger : IBurger
    {
        public void Cook()
        {
            Console.WriteLine("Cooking a Chicken Burger");
        }
    }
    public class HealthyCheeseBurger : IBurger
    {
        public void Cook()
        {
            Console.WriteLine("Cooking a Healthy Cheese Burger");
        }
    }
    public class HealthyVeggieBurger : IBurger
    {
        public void Cook()
        {
            Console.WriteLine("Cooking a Healthy Veggie Burger");
        }
    }
    public class HealthyChickenBurger : IBurger
    {
        public void Cook()
        {
            Console.WriteLine("Cooking a Healthy Chicken Burger");
        }
    }
    
    public interface IDrink
    {
        void Pour();
    }
    public class Soda : IDrink
    {
        public void Pour()
        {
            Console.WriteLine("Pouring a Soda");
        }
    }
    public class FruitJuice : IDrink
    {
        public void Pour()
        {
            Console.WriteLine("Pouring a Fruit Juice");
        }
    }
    public class Coke : IDrink
    {
        public void Pour()
        {
            Console.WriteLine("Pouring a Coke");
        }
    }
    
    public interface IBurgerFactory
    {
        IBurger CreateBurger(BurgerType type);
    }
    
    public interface IDrinkFactory
    {
        IDrink CreateDrink(DrinkType type);
    }

    public interface IFoodFactory
    {
        IBurger CreateBurger(BurgerType type);
        IDrink CreateDrink(DrinkType type);
    }

    public class HealthyFoodFactory : IFoodFactory
    {
        public IBurger CreateBurger(BurgerType type)
        {
            switch (type)
            {
                case BurgerType.Cheese:
                    return new HealthyCheeseBurger();
                case BurgerType.Veggie:
                    return new HealthyVeggieBurger();
                case BurgerType.Chicken:
                    return new HealthyChickenBurger();
                default:
                    throw new ArgumentException("Invalid burger type");
            }
        }

        public IDrink CreateDrink(DrinkType type)
        {
            switch (type)
            {
                case DrinkType.Soda:
                    return new Soda();
                case DrinkType.FruitJuice:
                    return new FruitJuice();
                default:
                    throw new ArgumentException("Invalid drink type");
            }
        }
    }

    public class UnHealthyFoodFactory : IFoodFactory
    {
        public IBurger CreateBurger(BurgerType type)
        {
            switch (type)
            {
                case BurgerType.Cheese:
                    return new CheeseBurger();
                case BurgerType.Veggie:
                    return new VeggieBurger();
                case BurgerType.Chicken:
                    return new ChickenBurger();
                default:
                    throw new ArgumentException("Invalid burger type");
            }
        }

        public IDrink CreateDrink(DrinkType type)
        {
            switch (type)
            {
                case DrinkType.Coke:
                    return new Coke();
                default:
                    throw new ArgumentException("Invalid drink type");
            }
        }
    }

    public class FactoryDemo
    {
        public static void DemoMain(string[] args)
        {  
            var factory = new HealthyFoodFactory();
            IBurger burger1 = factory.CreateBurger(BurgerType.Veggie);
            burger1.Cook();
            IDrink drink1 = factory.CreateDrink(DrinkType.Soda);
            drink1.Pour();

            var factory2 = new UnHealthyFoodFactory();
            IBurger burger2 = factory2.CreateBurger(BurgerType.Veggie);
            burger2.Cook();
            IDrink drink2 = factory2.CreateDrink(DrinkType.Coke);
            drink2.Pour();
			
			//Testing Needed
        }
    }
}