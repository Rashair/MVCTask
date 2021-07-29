using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MVCTask.Helpers;

namespace MVCTask
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            GlobalFilters.Filters.Add(new LanguageChangeFilter());
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }


        public class LanguageChangeFilter : IActionFilter
        {
            public void OnActionExecuted(ActionExecutedContext filterContext)
            {
            }

            public void OnActionExecuting(ActionExecutingContext filterContext)
            {
                var cookie = HttpContext.Current.Request.Cookies[Language.Key];
                if (cookie?.Value != null)
                {
                    Language.ChangeThreadCulture(cookie.Value);
                }
                else
                {
                    Language.ChangeThreadCulture(Language.plPL);
                }
            }
        }
    }
}
