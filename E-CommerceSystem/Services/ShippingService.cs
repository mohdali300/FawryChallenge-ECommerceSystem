using E_CommerceSystem.Interfaces;
using E_CommerceSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.Services
{
    public class ShippingService : IShippingService
    {
        public string GetName(Product product)
        {
            return product.Name;
        }

        public double GetWeight(double weight, int quantity)
        {
            return weight * quantity;
        }

        public void ShipProduct(List<CartItem> items)
        {
            try
            {
                double totalWeight = 0;
                Console.WriteLine("** Shipment notice **");
                foreach (var item in items)
                {
                    if (item.Product is IShippable shippable)
                    {
                        var quantity = item.Quantity;
                        var weight = shippable.Weight;
                        totalWeight += weight * quantity;
                        Console.WriteLine($"{quantity}X {GetName(item.Product),-12}      {GetWeight(weight * 1000, quantity)}g");
                    }
                }

                Console.WriteLine($"Total package weight {totalWeight}kg");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while shipping the product: {ex.Message}");
            }
        }

        public double CalculateShipping(List<CartItem> items)
        {
            double totalKGs = 0;

            foreach (var item in items)
            {
                if (item.Product is IShippable shippable)
                {
                    totalKGs += shippable.Weight * item.Quantity;
                }
            }

            double shippingFeePerKg = 15.0;

            return totalKGs * shippingFeePerKg;
        }
    }
}
