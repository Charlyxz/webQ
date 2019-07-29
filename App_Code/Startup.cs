using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(webQ.Startup))]
namespace webQ
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
