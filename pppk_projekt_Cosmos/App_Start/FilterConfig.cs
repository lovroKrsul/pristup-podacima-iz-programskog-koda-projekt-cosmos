using System.Web;
using System.Web.Mvc;

namespace pppk_projekt_Cosmos
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
