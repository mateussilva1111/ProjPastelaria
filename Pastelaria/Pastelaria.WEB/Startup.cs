using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pastelaria.WEB.Startup))]
namespace Pastelaria.WEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
