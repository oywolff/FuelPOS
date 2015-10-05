using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TankForm.Startup))]
namespace TankForm
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
