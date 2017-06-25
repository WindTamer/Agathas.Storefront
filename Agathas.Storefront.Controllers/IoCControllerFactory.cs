using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using StructureMap;
using Agathas.Storefront.Controllers.Controllers;
using Agathas.Storefront.IOC;

namespace Agathas.Storefront.Controllers
{
    public class IoCControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return IOCContainer.Container.GetInstance(controllerType) as IController;
        }
    }
}
