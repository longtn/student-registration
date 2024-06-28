using Serilog;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace StudentRegistration.App
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            UnityConfig.RegisterComponents();

            var log = new LoggerConfiguration()
                .WriteTo.File(System.Web.Hosting.HostingEnvironment.MapPath("~/bin/Logs/log.txt"))
                .CreateLogger();
            Log.Logger = log;
            Log.Logger.Information("Application_Start");
        }
    }
}
