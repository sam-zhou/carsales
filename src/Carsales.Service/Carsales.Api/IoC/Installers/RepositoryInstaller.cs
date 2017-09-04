using Carsales.Core.Repositories.Abstracts;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Carsales.Api.IoC.Installers
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyInThisApplication()
                            .BasedOn<IRepository>().WithServiceAllInterfaces()
                            .LifestyleTransient()
                );
        }
    }
}