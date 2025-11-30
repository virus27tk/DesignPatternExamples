using System;

namespace DesignPatterns
{
    public interface IPizza
    {
        string GetToppings();
    }

    public class MargheritaPizza : IPizza
    {
        public string GetToppings()
        {
            return "Base Pizza: Margherita";
        }
    }

    public abstract class PizzaDecorator : IPizza
    {
        protected readonly IPizza _pizza;

        public PizzaDecorator(IPizza pizza)
        {
            _pizza = pizza;
        }

        public abstract string GetToppings();
    }

    public class CheeseToppingDecorator : PizzaDecorator
    {
        public CheeseToppingDecorator(IPizza pizza) : base(pizza)
        {
        }

        public override string GetToppings()
        {
            return _pizza.GetToppings() + " With Cheese Toppings";
        }
    }

    public class VeggieDecorator : PizzaDecorator
    {
        public VeggieDecorator(IPizza pizza) : base(pizza)
        {
        }

        public override string GetToppings()
        {
            return _pizza.GetToppings() + " With Veggie Toppings";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var pizza = new MargheritaPizza();
            var decorator = new CheeseToppingDecorator(pizza);
            Console.WriteLine(decorator.GetToppings());

            var decorator2 = new VeggieDecorator(pizza);
            Console.WriteLine(decorator2.GetToppings());

            var decorator3 = new CheeseToppingDecorator(new VeggieDecorator(pizza));
            Console.WriteLine(decorator3.GetToppings());
            Console.ReadLine();
        }
    }
}