using E_CommerceSystem.Interfaces;
using E_CommerceSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.Services
{
    public class CheckoutService
    {
        public static double Checkout(Cart cart, IShippingService shippingService, double balance)
        {
            shippingService.ShipProduct(cart.Items);
            Console.WriteLine("** Checkout receipt **");
            
            foreach (var item in cart.Items)
            {
                if (item.Quantity > item.Product.Quantity)
                {
                    Console.WriteLine($"{item.Product.Name} doesn’t have enough stock.");
                    continue;
                }

                if (item.Product is IExpirable expirable && expirable.IsExpired())
                {
                    Console.Error.WriteLine($"{item.Product.Name} is expired and cannot be purchased.");
                    continue;
                }

                Console.WriteLine($"{item.Quantity}X {item.Product.Name,-12}      {item.Product.Price * item.Quantity}");
            }

            double subtotal = cart.Items.Sum(i => i.Product.Price * i.Quantity);
            double shippingFees = shippingService.CalculateShipping(cart.Items);
            double total = subtotal + shippingFees;

            if (balance < total)
            {
                Console.Error.WriteLine("You do not have enough balance.");
                return balance;
            }

            foreach (var item in cart.Items)
            {
                item.Product.Quantity -= item.Quantity;
            }

            Console.WriteLine("------------------------------------");
            Console.WriteLine($"Subtotal     {subtotal}");
            Console.WriteLine($"Shipping     {shippingFees}");
            Console.WriteLine($"Amount       {total}");
            Console.WriteLine();

            return balance-total;
        }
    }
}
