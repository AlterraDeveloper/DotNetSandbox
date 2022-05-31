using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using OnlineBankDemo.DataAccessLayer.GeneralBook;
using OnlineBankDemo.Service.Common;
using Unity;
using Unity.Lifetime;

namespace OnlineBankDemo.Service.GeneralBook
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            CommonUnityConfig.UnityConfig(container);
            container.RegisterType<GeneralBookUnitOfWork, GeneralBookUnitOfWork>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
