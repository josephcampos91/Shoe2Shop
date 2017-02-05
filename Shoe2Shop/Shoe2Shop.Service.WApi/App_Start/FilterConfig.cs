using System.Web;
using System.Web.Mvc;

namespace Shoe2Shop.Service.WApi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
