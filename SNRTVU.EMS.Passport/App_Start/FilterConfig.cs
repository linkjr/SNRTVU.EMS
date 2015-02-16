using System.Web;
using System.Web.Mvc;

namespace SNRTVU.EMS.Passport
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
