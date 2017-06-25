using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agathas.Storefront.IOC
{
    public class IOCContainer
    {
        public static Container Container { get; set; }

        public static void ConfigureDependencies()
        {
            Container = new Container(new ControllerRegistry());
        }
    }
}
