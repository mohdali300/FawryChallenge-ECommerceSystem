using E_CommerceSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.Models
{
    public class ExpirableProduct : Product, IExpirable
    {
        public DateTime ExpiryDate { get; set; }

        public ExpirableProduct(string name, double price, int quantity, DateTime expiryDate):base(name, price, quantity)
        {
            ExpiryDate = expiryDate;
        }

        public bool IsExpired()
        {
            return DateTime.Now > ExpiryDate;
        }
    }
}