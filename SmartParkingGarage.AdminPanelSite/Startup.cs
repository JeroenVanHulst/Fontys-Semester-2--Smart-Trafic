using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SmartParkingGarage.AdminPanelSite.Startup))]
namespace SmartParkingGarage.AdminPanelSite
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
