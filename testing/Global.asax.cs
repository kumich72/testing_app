using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace testing
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static NLog.Logger loggerNlog = NLog.LogManager.GetCurrentClassLogger();

        protected void Application_Start()
        {
            var loggerNlog = NLog.LogManager.GetCurrentClassLogger();
            loggerNlog.Info("Let's Application Start!");

            Logger.InitLogger();

            Logger.Log.Info("Start!");

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        override public void Init()
        {
            loggerNlog.Info("Cast Init");
        }

        override public void Dispose()
        {
            loggerNlog.Info("Cast Application Dispose");
        }

        protected void Application_Error()
        {
            loggerNlog.Info("Application Error");
        }


        protected void Application_End()
        {
            loggerNlog.Info("Application End");
        }

    }
}
