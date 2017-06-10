using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ConnectService.MobileAppService.Startup))]

namespace ConnectService.MobileAppService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}