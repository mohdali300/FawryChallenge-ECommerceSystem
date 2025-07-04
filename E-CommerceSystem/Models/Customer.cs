using E_CommerceSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public Cart Cart { get; set; }
        private ShippingService shippingService;

        public Customer(string name, double balance)
        {
            Name = name;
            Balance = balance;
            Cart = new Cart();
            shippingService = new ShippingService();
        }

        public void Checkout()
        {
            try
            {
                if (Cart.Items == null || !Cart.Items.Any())
                {
                    Console.Error.WriteLine("Cart is empty.");
                    return;
                }

                var balance = CheckoutService.Checkout(Cart, shippingService, Balance);
                if (balance != Balance)
                {
                    Balance = balance;
                    Console.WriteLine($"Your remaining balance is: {balance.ToString("0.00")}");
                    Console.WriteLine($"Thank you for your purchase, {Name}!");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred during checkout: {ex.Message}");
            }
        }

    }
}
