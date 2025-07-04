using E_CommerceSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.Models
{
    public class ExpirableShippableProduct:Product, IExpirable, IShippable
    {
        public DateTime ExpiryDate { get; set; }
        public double Weight { get; set; }

        public ExpirableShippableProduct(string name, double price, int quantity, DateTime expiryDate, double weight) 
            : base(name, price, quantity)
        {
            ExpiryDate = expiryDate;
            Weight = weight;
        }

        public bool IsExpired()
        {
            return DateTime.Now > ExpiryDate;
        }
    }
}
