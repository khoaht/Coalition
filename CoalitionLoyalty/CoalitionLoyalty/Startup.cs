using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CoalitionLoyalty.Startup))]
namespace CoalitionLoyalty
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
