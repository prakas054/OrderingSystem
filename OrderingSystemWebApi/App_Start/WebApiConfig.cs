using Autofac;
using Autofac.Integration.WebApi;
using OrderingSystemWebApi.Controllers;
using OrderingSystemWebApi.Models;
using OrderingSystemWebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;

namespace OrderingSystemWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            var configs = GlobalConfiguration.Configuration;

            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<OrderRepository>().As<IOrderRepository<Order>>();
            builder.RegisterType<OrderController>();
            builder.RegisterType<Order>();

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(configs);

            // OPTIONAL: Register the Autofac model binder provider.
            builder.RegisterWebApiModelBinderProvider();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
