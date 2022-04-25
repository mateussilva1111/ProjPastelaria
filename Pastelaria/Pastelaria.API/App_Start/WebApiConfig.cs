using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dependencies;

namespace Pastelaria.API
{
    public abstract class WebApiConfig : HttpApplication
    {

        private readonly IDependencyResolver _dependencyResolver;


        protected WebApiConfig(IDependencyResolver dependencyResolver)
        {
            _dependencyResolver = dependencyResolver;
        }

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(config =>
            {

                // Web API configuration and services

                // Web API routes
                config.MapHttpAttributeRoutes();

                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{action}"
                );

                config.Formatters.Clear();
                config.Formatters.Add(new JsonMediaTypeFormatter
                {
                    SerializerSettings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                        ContractResolver = new DefaultContractResolver
                        {
                            IgnoreSerializableAttribute = true
                        }
                    }
                });

                config.DependencyResolver = _dependencyResolver;

            });
        }

    }
}
