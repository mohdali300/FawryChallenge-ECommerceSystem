using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.Models
{
    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public CartItem()
        {
        }

        public double GetItemSubtotalPrice()
        {
            return Product.Price * Quantity;
        }
    }
}
