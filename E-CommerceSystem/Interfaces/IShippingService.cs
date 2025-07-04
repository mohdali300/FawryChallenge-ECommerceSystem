using E_CommerceSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.Interfaces
{
    public interface IShippingService
    {
        string GetName(Product product);
        double GetWeight(double weight, int quantity);
        void ShipProduct(List<CartItem> items);
        double CalculateShipping(List<CartItem> items);
    }
}
