using System.Web.Mvc;
using System.Web.Routing;
using Agathas.Storefront.Controllers;
using Agathas.Storefront.Infrastructure.Configuration;
using Agathas.Storefront.Infrastructure.Email;
using Agathas.Storefront.Infrastructure.Logging;
using StructureMap;
using Agathas.Storefront.IOC;

namespace Agathas.Storefront.UI.Web.MVC
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            IOCContainer.ConfigureDependencies();

            RegisterRoutes(RouteTable.Routes);

            Services.AutoMapperBootStrapper.ConfigureAutoMapper();

            ApplicationSettingsFactory.InitializeApplicationSettingsFactory
                                  (IOCContainer.Container.GetInstance<IApplicationSettings>());

            LoggingFactory.InitializeLogFactory(IOCContainer.Container.GetInstance<ILogger>());

            EmailServiceFactory.InitializeEmailServiceFactory
                                  (IOCContainer.Container.GetInstance<IEmailService>());

            ControllerBuilder.Current.SetControllerFactory(new IoCControllerFactory());

            LoggingFactory.GetLogger().Log("Application Started");            

        }
    }
}