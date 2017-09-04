using Carsales.Core.Services.Interface;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using log4net;

namespace Carsales.Api.IoC.Installers
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //container.Register(Component.For<IDatabaseService>().ImplementedBy<DatabaseService>().LifestylePerWebRequest());
            //container.Register(Component.For<IAddressService>().ImplementedBy<AddressService>().LifestylePerWebRequest());
            //container.Register(Component.For<IUserService>().ImplementedBy<UserService>().LifestylePerWebRequest());
            //container.Register(Component.For<IAuthenticationService>().ImplementedBy<AuthenticationService>().LifestylePerWebRequest());
            container.Register(Component.For<ILog>().Instance(LogManager.GetLogger(typeof(WebApiApplication))));


            container.Register(Classes.FromAssemblyInThisApplication()
                            .BasedOn<IService>().WithServiceAllInterfaces()
                            .LifestyleTransient()
                );


            

        }
    }
}