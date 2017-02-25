using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(DevEnvExeAppService.Startup))]

namespace DevEnvExeAppService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}