using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Leadersofpositvechange.Startup))]
namespace Leadersofpositvechange
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
