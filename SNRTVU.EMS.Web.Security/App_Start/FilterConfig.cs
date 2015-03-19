using System.Web;
using System.Web.Mvc;

using SNRTVU.EMS.Infrastructure.Mvc.Filter;

namespace SNRTVU.EMS.Web.Security
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleCustomErrorFilterAttribute(), 1);
            filters.Add(new HandleErrorAttribute(), 2);
        }
    }
}
