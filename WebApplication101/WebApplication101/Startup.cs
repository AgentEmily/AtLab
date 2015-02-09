using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebApplication101.Startup))]
namespace WebApplication101
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
