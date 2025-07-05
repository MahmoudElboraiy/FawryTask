using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryTask
{
    public class Cart
    {
        public List<Product> Products { get; set; } = new List<Product>();

        public decimal Subtotal
        {
            get
            {
                return Products.Sum(p => p.Price * p.Quantity);
            }
        }
        public decimal ShippingFees
        {
            get
            {
                return Products.OfType<ShippableAndExpirableProduct>().Sum(p => p.CalculateShippingCost())
                    + Products.OfType<ShippableAndNotExpirableProduct>().Sum(p => p.CalculateShippingCost());
            }
        }
    }
}
