using HelpDeskAPI.DI;
using HelpDeskDAL;
using HelpDeskDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApiContrib.IoC.Ninject;

namespace HelpDeskAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.DependencyResolver = new DI.NinjectResolver();
           
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
           
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
