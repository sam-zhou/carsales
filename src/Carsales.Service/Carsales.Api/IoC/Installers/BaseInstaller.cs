using System.Data.Entity;
using System.Web;
using Carsales.Core;
using Carsales.Core.Models;
using Carsales.Core.Providers;
using Carsales.Core.Uow;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace Carsales.Api.IoC.Installers
{
    public class BaseInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<DbContext>()
                .ImplementedBy<CarsalesDbContext>()
                .LifestylePerWebRequest());
            container.Register(Component.For<IUnitOfWork>()
                .ImplementedBy<UnitOfWork>()
                .LifestylePerWebRequest());
            container.Register(Component.For<IUserStore<User, long>>().ImplementedBy<CarsalesUserStore>().LifestylePerWebRequest());
            container.Register(Component.For<CarsalesUserManager>().LifestylePerWebRequest());
            container.Register(Component.For<IAuthenticationManager>().UsingFactoryMethod((kernel, creationContext) => HttpContext.Current.GetOwinContext().Authentication).LifestylePerWebRequest());
            container.Register(Component.For<IClientInfoProvider>().ImplementedBy<ClientInfoProvider>().LifestylePerWebRequest());
        }
    }
}