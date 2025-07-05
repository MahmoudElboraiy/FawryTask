using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryTask
{
    public interface IExpiredItem
    {
        public DateTime ExpirationDate { get; set; }
    }
}
