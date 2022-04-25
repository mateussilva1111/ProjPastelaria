using SimpleInjector.Integration.WebApi;
using System.Web.Http.Dependencies;

namespace Pastelaria.API
{
    public class WebApiApplication : WebApiConfig
    {
        private static readonly IDependencyResolver _dependencyResolver = new SimpleInjectorWebApiDependencyResolver(SimpleInjectorContainer.Build());

        public WebApiApplication()
            : base(_dependencyResolver)
        {

        }

    }
}

