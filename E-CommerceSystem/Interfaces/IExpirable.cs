using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.Interfaces
{
    public interface IExpirable
    {
        DateTime ExpiryDate { get; set; }
        bool IsExpired();
    }
}
