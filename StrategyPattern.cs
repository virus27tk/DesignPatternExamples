namespace InvoiceApp.DesignPatterns
{
    public enum PaymentMethod
    {
        CreditCard,
        PayPal,
        Crypto,
        Cash
    }

    public interface IPaymentStrategy
    {
        void Pay(decimal amount);
    }

    public class CreditCardPayment : IPaymentStrategy
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Processing credit card payment of {amount:C}");
        }
    }

    public class PayPalPayment : IPaymentStrategy
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Processing PayPal payment of {amount:C}");
        }
    }

    public class CryptoPayment : IPaymentStrategy
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Processing cryptocurrency payment of {amount:C}");
        }
    }

    public class CashPayment : IPaymentStrategy
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Processing cash payment of {amount:C}");
        }
    }

    public interface ICheckoutService
    {
        void Checkout(decimal amount, IPaymentStrategy paymentStrategy);
    }

    public class CheckoutService : ICheckoutService
    {
        public void Checkout(decimal amount, IPaymentStrategy paymentStrategy)
        {
            paymentStrategy.Pay(amount);
        }
    }

    public interface IPaymentStrategyRegistry
    {
        IPaymentStrategy? GetPaymentStrategy(PaymentMethod method);
    }

    public class PaymentStrategyRegistry : IPaymentStrategyRegistry
    {
        private readonly Dictionary<PaymentMethod, IPaymentStrategy> _strategies;

        public PaymentStrategyRegistry()
        {
            _strategies = new Dictionary<PaymentMethod, IPaymentStrategy>
            {
                { PaymentMethod.CreditCard, new CreditCardPayment() },
                { PaymentMethod.PayPal, new PayPalPayment() },
                { PaymentMethod.Crypto, new CryptoPayment() },
                { PaymentMethod.Cash, new CashPayment() }
            };
        }

        public IPaymentStrategy? GetPaymentStrategy(PaymentMethod method)
        {
            return _strategies.TryGetValue(method, out IPaymentStrategy? value) ? value : null;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // Example usage
            Console.WriteLine("Available payment methods: creditcard, paypal, crypto, cash");
            Console.Write("Select payment method: ");
            string? paymentMethod = Console.ReadLine()?.ToLower();

            var registry = new PaymentStrategyRegistry();

            if (paymentMethod != null)
            {
                Enum.TryParse(paymentMethod, true, out PaymentMethod method);
                var strategy = registry.GetPaymentStrategy(method);
                if (strategy != null)
                {
                    var checkoutService = new CheckoutService();
                    checkoutService.Checkout(99.99m, strategy);
                }
                else
                {
                    Console.WriteLine("Invalid payment method selected.");
                }
            }
        }
    }
}
