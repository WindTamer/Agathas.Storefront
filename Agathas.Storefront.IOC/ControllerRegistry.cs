using Agathas.Storefront.Infrastructure.Configuration;
using Agathas.Storefront.Infrastructure.CookieStorage;
using Agathas.Storefront.Infrastructure.Email;
using Agathas.Storefront.Infrastructure.Logging;
using Agathas.Storefront.Infrastructure.UnitOfWork;
using Agathas.Storefront.Model.Basket;
using Agathas.Storefront.Model.Categories;
using Agathas.Storefront.Model.Products;
using Agathas.Storefront.Model.Shipping;
using Agathas.Storefront.Services.Implementations;
using Agathas.Storefront.Services.Interfaces;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agathas.Storefront.IOC
{
    public class ControllerRegistry : Registry
    {
        public ControllerRegistry()
        {
            // Repositories 
            For<IBasketRepository>().Use<Repository.NHibernate.Repositories.BasketRepository>();
            For<IDeliveryOptionRepository>().Use<Repository.NHibernate.Repositories.DeliveryOptionRepository>();

            For<ICategoryRepository>().Use<Repository.NHibernate.Repositories.CategoryRepository>();
            For<IProductTitleRepository>().Use<Repository.NHibernate.Repositories.ProductTitleRepository>();
            For<IProductRepository>().Use<Repository.NHibernate.Repositories.ProductRepository>();
            For<IUnitOfWork>().Use<Repository.NHibernate.NHUnitOfWork>();

            // Product Catalogue                                         
            For<IProductCatalogService>().Use<ProductCatalogService>();

            For<IBasketService>().Use<BasketService>();
            For<ICookieStorageService>().Use<CookieStorageService>();


            // Application Settings                 
            For<IApplicationSettings>().Use<WebConfigApplicationSettings>();

            // Logger
            For<ILogger>().Use<Log4NetAdapter>();

            // Email Service                 
            For<IEmailService>().Use<TextLoggingEmailService>();
        }
    }
}
