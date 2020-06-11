using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_17bangMVC.Startup))]
namespace _17bangMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
