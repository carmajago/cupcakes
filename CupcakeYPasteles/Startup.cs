using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CupcakeYPasteles.Startup))]
namespace CupcakeYPasteles
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
