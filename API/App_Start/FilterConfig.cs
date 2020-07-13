using System.Web.Http.Filters;
using API.Attribute;
using API.Filters;

namespace API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(HttpFilterCollection filters)
        {
            filters.Add(new CustomDataBinderAttribute());
            filters.Add(new BasicExceptionFilterAtribute());
            filters.Add(new BasicAuthenticationAttribute());
        }

        public static void RegisterHttpFilters(HttpFilterCollection filters)
        {
            filters.Add(new AuditLogActionFilter());
        }
    }
}