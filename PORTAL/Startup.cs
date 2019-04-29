using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PORTAL.Startup))]
namespace PORTAL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
