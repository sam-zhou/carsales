using System;
using System.Data.Entity;
using Carsales.Core.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Carsales.Core
{
    public class CarsalesUserStore :
    UserStore<User, Role, long, UserLogin, UserRole, UserClaim>,
    IUserStore<User, long>,
    IDisposable
    {
        public CarsalesUserStore(DbContext context) : base(context)
        {
           
        }
    }
}
