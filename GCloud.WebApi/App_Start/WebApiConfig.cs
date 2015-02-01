using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.OData.Builder;
using GCloud.Models;
using GCloud.WebApi.Common;

namespace GCloud.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            //CORS
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
            //config.EnableCors();
            // Web API configuration and services

            config.DependencyResolver = new NinjectResolver(NinjectWebCommon.CreateKernel());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
              name: "BreezeApi",
              routeTemplate: "breeze/{controller}/{action}");

            // New code:
            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Customer>("Customers");
            builder.EntitySet<PhoneNumber>("PhoneNumbers");
            builder.EntitySet<Address>("Addresses");
            builder.EntitySet<Group>("Groups");
            builder.EntitySet<Country>("Countries");
            config.Routes.MapODataRoute("ODataRoute", "odata", builder.GetEdmModel()); /// obsolete
            //config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
        }
    }
}
