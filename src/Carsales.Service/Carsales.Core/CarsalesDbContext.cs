using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Carsales.Core.Models;
using Carsales.Core.Models.Attributes;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Carsales.Core
{
    public class CarsalesDbContext : IdentityDbContext<User, Role, long, UserLogin, UserRole, UserClaim>
    {
        public DbSet<Vehicle> Vehicles;

        public CarsalesDbContext()
            : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException("modelBuilder");
            }

            modelBuilder.Conventions.Add(new AttributeToColumnAnnotationConvention<SqlDefaultValueAttribute, string>("SqlDefaultValue", (p, attributes) => attributes.Single().DefaultValue));

            // Needed to ensure subclasses share the same table
            var user = modelBuilder.Entity<User>()
                .ToTable("Users");
            user.HasMany(u => u.Roles).WithRequired().HasForeignKey(ur => ur.UserId);
            user.HasMany(u => u.Claims).WithRequired().HasForeignKey(uc => uc.UserId);
            user.HasMany(u => u.Logins).WithRequired().HasForeignKey(ul => ul.UserId);
            
            user.Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(256)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UserNameIndex") { IsUnique = true }));

            // CONSIDER: u.Email is Required if set on options?
            user.Property(u => u.Email).HasMaxLength(256);

            modelBuilder.Entity<UserRole>()
                .HasKey(r => new { r.UserId, r.RoleId })
                .ToTable("UserRoles");


            modelBuilder.Entity<UserLogin>()
                .HasKey(l => new { l.LoginProvider, l.ProviderKey, l.UserId })
                .ToTable("UserLogins");

            modelBuilder.Entity<UserClaim>()
                .ToTable("UserClaims");

            var role = modelBuilder.Entity<Role>()
                .ToTable("Roles");
            role.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(256)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("RoleNameIndex") { IsUnique = true }));
            role.HasMany(r => r.Users).WithRequired().HasForeignKey(ur => ur.RoleId);
        }

        //public static CarsalesDbContext Create()
        //{
        //    return new CarsalesDbContext();
        //}
    }
}
