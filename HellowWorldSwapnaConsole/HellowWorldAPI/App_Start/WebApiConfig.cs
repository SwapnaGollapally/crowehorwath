using HellowWorldAPI.DataAccessLayer;
using HellowWorldAPI.Interfaces;
using HellowWorldAPI.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace HellowWorldAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            var container = new UnityContainer();
            container.RegisterType<IRetrieveResults, TextDataDAL>();
            container.RegisterType<ILogger, ApplicationFileLogger>();
            config.DependencyResolver = new UnityResolver(container);
        }
    }
}
