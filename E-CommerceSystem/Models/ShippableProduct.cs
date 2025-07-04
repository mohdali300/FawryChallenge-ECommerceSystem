using E_CommerceSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.Models
{
    public class ShippableProduct : Product, IShippable
    {
        public double Weight { get; set; }

        public ShippableProduct(string name, double price, int quantity, double weight) : base(name, price, quantity)
        {
            Weight = weight;
        }
    }
}