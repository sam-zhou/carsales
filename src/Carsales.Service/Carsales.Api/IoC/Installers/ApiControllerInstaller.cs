using System.Web.Http.Controllers;
using Carsales.Api.Api;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Carsales.Api.IoC.Installers
{
    public class ApiControllerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                            .BasedOn<BaseApiController>()
                            .LifestyleTransient());
        }
    }
}