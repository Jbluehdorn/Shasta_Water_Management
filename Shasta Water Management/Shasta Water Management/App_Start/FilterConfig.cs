using System.Web;
using System.Web.Mvc;
using Shasta_Water_Management.Filters;

namespace Shasta_Water_Management
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new LogInFilter());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
