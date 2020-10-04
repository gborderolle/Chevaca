using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Chevaca.Startup))]
namespace Chevaca
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
