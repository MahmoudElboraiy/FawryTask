using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryTask
{
    public class ShippingService : IShippingService
    {
        public List<ProductToShipped> productToShipped = new List<ProductToShipped>();
        public ShippingService()
        {
           
        }
        public ShippingService(List<ProductToShipped> productToShipped)
        {
            this.productToShipped = productToShipped;
        }
        public string GetName(int id )
        {
            var product = productToShipped.FirstOrDefault( x => x.Id == id);
            return product.Name;
        }

        public decimal getWeight(int id)
        {
            var product = productToShipped.FirstOrDefault(x => x.Id == id);
            return product.Weight;
        }
    }
}
