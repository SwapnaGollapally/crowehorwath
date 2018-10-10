using HellowWorldAPI.DataAccessLayer;
using HellowWorldAPI.Interfaces;
using HellowWorldAPI.Logger;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;

namespace HellowWorldAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            UnityContainer container = new UnityContainer();
            //container.RegisterType<IRetrieveResults, TextDataDAL>();
            //container.RegisterType<ILogger, ApplicationFileLogger>();
        }
    }
}
