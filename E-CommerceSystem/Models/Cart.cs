using E_CommerceSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; set; }

        public Cart()
        {
            Items = new List<CartItem>();
        }

        public bool AddItem(Product product, int quantity)
        {
            if (product == null || quantity <= 0)
            {
                Console.WriteLine("Invalid item, cannot add to cart.");
                return false;
            }

            if(quantity > product.Quantity)
            {
                Console.WriteLine($"Cannot add {quantity} of {product.Name} to the cart, there is only {product.Quantity} available.");
                return false;
            }

            if(product is IExpirable expirable)
            {
                if(expirable.IsExpired())
                    { return false; }
            }

            var existingItem = Items.FirstOrDefault(i => i.Product.Name == product.Name);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                Items.Add(new CartItem
                {
                    Product = product,
                    Quantity = quantity
                });
            }

            Console.WriteLine($"Added {quantity} of {product.Name} to the cart.");
            return true;
        }
    }
}
