using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryTask
{
    public class Customer
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public decimal Balance { get; set; }
        public List<ProductToBuy> ProductsToBuy { get; set; } = new List<ProductToBuy>();
    }
}
