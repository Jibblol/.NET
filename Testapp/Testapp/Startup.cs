using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Testapp.Startup))]
namespace Testapp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
