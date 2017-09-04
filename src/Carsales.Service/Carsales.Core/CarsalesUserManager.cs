using System;
using System.Data.Entity;
using System.Web.Configuration;
using Carsales.Core.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Carsales.Core
{
    // Configure the application user manager which is used in this application.
    public class CarsalesUserManager : UserManager<User, long>
    {
        public CarsalesUserManager(IUserStore<User, long> store)
            : base(store)
        {
        }


        public static CarsalesUserManager Create(IdentityFactoryOptions<CarsalesUserManager> options,
            IOwinContext context)
        {
            var manager = new CarsalesUserManager(new CarsalesUserStore(context.Get<DbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<User, long>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = int.Parse(WebConfigurationManager.AppSettings["PasswordRequiredLength"]),
                RequireNonLetterOrDigit = WebConfigurationManager.AppSettings["PasswordRequireNonLetterOrDigit"].ToLower() == "true",
                RequireDigit = WebConfigurationManager.AppSettings["PasswordRequireDigit"].ToLower() == "true",
                RequireLowercase = WebConfigurationManager.AppSettings["PasswordRequireLowercase"].ToLower() == "true",
                RequireUppercase = WebConfigurationManager.AppSettings["PasswordRequireUppercase"].ToLower() == "true",
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<User, long>
            {
                MessageFormat = "Your security code is {0}"
            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<User, long>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<User, long>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }
}
