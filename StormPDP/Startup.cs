using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StormPDP.Startup))]
namespace StormPDP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
