using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryTask
{
    public interface IShippingItem
    {
        public decimal Weight { get; set; }
        public string Address { get; set; }
        public DateTime ShippingDate { get; set; }
        public decimal CalculateShippingCost();
    }
}
