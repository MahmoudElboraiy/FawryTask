using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryTask
{
    public class Order
    {
        public decimal Subtotal { get; set; }
        public decimal ShippingFees { get; set; }
        public decimal Total { get; set; }
        public override string ToString()
        {
            Console.WriteLine($"CONSOLE OUTPUT\r\n");
            return base.ToString();
        }
    }
}
