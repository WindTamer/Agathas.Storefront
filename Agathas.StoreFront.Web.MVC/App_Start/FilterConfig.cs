using System.Web;
using System.Web.Mvc;

namespace Agathas.StoreFront.Web.MVC.Alex
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}