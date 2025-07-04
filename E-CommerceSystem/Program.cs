using E_CommerceSystem.Models;

namespace E_CommerceSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer("Mohamed Ali", 1500.0);

            var cheese = new ExpirableShippableProduct("Cheese", 5, 10, DateTime.Now.AddDays(7), 0.3);
            var biscuit = new ExpirableProduct("Biscuit", 2.5, 20, DateTime.Now.AddDays(30));
            var pepsi = new ExpirableShippableProduct("Pepsi", 2.5, 20, DateTime.Now.AddDays(-1), 1.0);
            var tv = new ShippableProduct("TV", 1250, 5, 10.0);
            var scratchCard = new Product("Mobile scratch card", 760, 3);

            customer.Cart.AddItem(cheese, 2);
            customer.Cart.AddItem(biscuit, 1);
            customer.Cart.AddItem(tv, 1);
            customer.Cart.AddItem(scratchCard, 4);
            customer.Cart.AddItem(pepsi, 1);
            Console.WriteLine();
            Console.WriteLine();

            customer.Checkout();
        }
    }
}
