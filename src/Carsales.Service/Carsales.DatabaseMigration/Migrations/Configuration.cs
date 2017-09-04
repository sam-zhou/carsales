using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.SqlServer;
using Carsales.Core;
using Carsales.Core.Enum;
using Carsales.Core.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Carsales.DatabaseMigration.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<CarsalesDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            SetSqlGenerator("System.Data.SqlClient", new CustomSqlServerMigrationSqlGenerator());
        }

        protected override void Seed(CarsalesDbContext context)
        {


            using (var dbContext = new CarsalesDbContext())
            {
                var enumToLookup = new EnumToLookup();
                enumToLookup.NameFieldLength = 25;
                enumToLookup.TableNamePrefix = string.Empty;
                enumToLookup.Apply(dbContext);

                using (var roleStore = new RoleStore<Role, long, UserRole>(dbContext))
                {
                    using (var roleManager = new RoleManager<Role, long>(roleStore))
                    {
                        roleManager.Create(new Role
                        {
                            Id = 1,
                            Name = "Administrator"
                        });

                        roleManager.Create(new Role
                        {
                            Id = 2,
                            Name = "User"
                        });

                        roleManager.Create(new Role
                        {
                            Id = 3,
                            Name = "CustomManager"
                        });
                    }
                }

                using (var userStore = new CarsalesUserStore(dbContext))
                {
                    using (var userManager = new CarsalesUserManager(userStore))
                    {
                        var user = new User
                        {
                            Email = "samzhou.it@gmail.com",
                            EmailConfirmed = true,
                            PhoneNumber = "0430501022",
                            PhoneNumberConfirmed = true,
                            AccessFailedCount = 0,
                            LockoutEnabled = false,
                            UserName = "samzhou.it@gmail.com",
                            SecurityStamp = "7668b7bc-7a5d-4b3b-8388-f2e5c59f3d43",
                            PasswordHash = "ABJ1bxk+trJ6PTk4iCBSq/WLDVmhI455FFxZbcXHtH1Xw2NyTKHsJmrWQ1Mbl7S4SQ=="
                        };
                        userManager.Create(user);
                        userManager.AddToRole(user.Id, "Administrator");
                    }
                }

                dbContext.SaveChanges();
            }

        }

        internal class CustomSqlServerMigrationSqlGenerator : SqlServerMigrationSqlGenerator
        {
            protected override void Generate(AddColumnOperation addColumnOperation)
            {
                SetAnnotatedColumn(addColumnOperation.Column);

                base.Generate(addColumnOperation);
            }

            protected override void Generate(CreateTableOperation createTableOperation)
            {
                SetAnnotatedColumn(createTableOperation.Columns);

                base.Generate(createTableOperation);
            }


            private void SetAnnotatedColumn(IEnumerable<ColumnModel> columns)
            {
                foreach (var columnModel in columns)
                {
                    SetAnnotatedColumn(columnModel);
                }
            }


            private void SetAnnotatedColumn(ColumnModel column)
            {
                AnnotationValues values;
                if (column.Annotations.TryGetValue("SqlDefaultValue", out values))
                {
                    column.DefaultValueSql = (string)values.NewValue;
                }
            }
        }
    }
}
