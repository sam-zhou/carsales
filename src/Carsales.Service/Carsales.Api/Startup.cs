using Carsales.Api;
using Carsales.Api.IoC;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace Carsales.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            IoCContainer.Setup();
            
            ConfigureAuth(app);
        }
    }
}
