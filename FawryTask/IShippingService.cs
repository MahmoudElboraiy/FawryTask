using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryTask
{
    public interface IShippingService
    {
        string GetName(int id);
        decimal getWeight(int id);
    }
}
