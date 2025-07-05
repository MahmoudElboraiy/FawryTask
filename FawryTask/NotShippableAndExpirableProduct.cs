using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryTask
{
    public class NotShippableAndExpirableProduct : Product, IExpiredItem
    {
        public DateTime ExpirationDate { get; set; }
    }
}
