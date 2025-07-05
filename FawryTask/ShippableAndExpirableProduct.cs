using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryTask
{
    public class ShippableAndExpirableProduct :Product, IShippingItem, IExpiredItem
    {
        public decimal Weight { get; set; }

        public string Address { get; set; }
        public decimal ShippingFeesPerKilo { get; set; }

        public DateTime ShippingDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public decimal CalculateShippingCost()
        {
            return Weight * Quantity * ShippingFeesPerKilo;
        }
    }
}
