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
                            Email = "test@lynex.com.au",
                            EmailConfirmed = true,
                            PhoneNumber = "0430501022",
                            PhoneNumberConfirmed = true,
                            AccessFailedCount = 0,
                            LockoutEnabled = false,
                            UserName = "test@lynex.com.au",
                            SecurityStamp = "7668b7bc-7a5d-4b3b-8388-f2e5c59f3d43",
                            PasswordHash = "ABJ1bxk+trJ6PTk4iCBSq/WLDVmhI455FFxZbcXHtH1Xw2NyTKHsJmrWQ1Mbl7S4SQ=="
                        };
                        userManager.Create(user);
                        userManager.AddToRole(user.Id, "Administrator");

                        var user2 = new User
                        {
                            Email = "samzhou.it@gmail.com",
                            EmailConfirmed = true,
                            PhoneNumber = "0430501022",
                            PhoneNumberConfirmed = true,
                            AccessFailedCount = 0,
                            LockoutEnabled = false,
                            UserName = "samzhou.it@gmail.com",
                            SecurityStamp = "6c5d586d-8390-4d96-9db7-f06bb2c6a6df",
                            PasswordHash = "ANNNzqwEGjePRrU/8VbqSXnJynL/wP51zG+1Ilf424Pu9nYvLWmfa0owBFtj99fywQ=="
                        };
                        userManager.Create(user2);
                        userManager.AddToRole(user2.Id, "Administrator");
                    }
                }

                //var site = new Site
                //{
                //    IsDefault = true,
                //    CreatedBy = 1,
                //    Name = "Willetton",
                //    //{"D":"Z7At6fVvJdIX8QUS5s6qKo1K6YRrikZDCBtmZtFNvsLVDvmB5LNNtQ/TjrcxbmJCxcZCNudlnPSdK298QZFxc3asGpLtPkT9z2zjFOaQA9wpNtvQK7BTP/56QJQP6ioxGfEvilEXVXw+2ERkniu5zgOj5MdLy/T31JTUL6iCIJKsK6x2+pu0QbqCJPnQiZk+GvRB4/Y9VEvtUZl9xJQxuTkR/fYLXRL1sKbOxtWvf1Mimm62T1EH1GmR7cZvKkqdtLKrb/8/gehlcaWZ8ms0rfUWeEJUB1mPvqsCVjH5rvS1rX08j5gPyZtolpRqSoYjvFhk+3y6FQ6EOBX93RHVoQ==","DP":"TniHOfpjiWIuvEY46jdEgXfpycz5qwOBvkT59H551kAZvNjthCi3qaIhwpL+Eitfwe0ReqJKD/UYyojfq/6IDV+2UrKcitgd1f4E6dX5NIzQQ1cLN9Xga6hBPfosq12zZPHLUoHxQRtcNb305+EFHiHmEoYxfQl69RJBM3X3iZE=","DQ":"KR8L8vC8XiAFSg25dFmVrMxPmWT66+YmJKwanN2XV1bw3uajy5EFE0BjP74Ggt1IvnZm/PftBPQHNRRpF5VaQ5npaV6OVW1qDA2gdAOCU4tOh5Hnge1eN3r7bIwZ7S23ZhHBwvIYv3AHrjU9Ek25hqKMZ1B+A9Ghw22kNLB5BB0=","Exponent":"AQAB","InverseQ":"FjYzuUqQ4/EFTsWB2upii23mu5r0bEZ579TKNdbzVeSQkGcbI7tTRI4TrOWo07WkiAiJHe4XJtPxc/yj+vjzGhqqxjaaLWMK18qTwPY6OSOavwRZLEqdl/2kVslwZni8JTON18LY9itRM7uaY5lmmDUI7PNpyibbhJo9q0uBJYI=","Modulus":"mMxzNRkfAUGaa1CX8VGlsM07alr3mBMYbRWbOEz5/CtsrA8h70GMomHw97iTn6kn0/tTaOUUrEOu7bRZUiKLLlswV8Q5uyfukoNuSKR5bQUFGaZ1/WO11nAcdCcH0vmN8gZ9eRZiXfOx5sWA+SJ8YXN0H9DwlglhrRQZg8WA05bZ5jbAcfzeF3+rfkL+3b7CnZic2Yupk9zrR1uxQnD3qNKR2dlXCtSibb4JVzJ4CNSySqWvP0Q6fB0IBHnqLgJbE7lDRhLveW6IP6wcAZDxGFJ7fWys4Q2CGd0iCjviBHWDtkCWOaB57xTbR5Su7/mNhYWie14cuuWji9DiToNgZw==","P":"yx4toDmRKT1nu7MrJeNAbK1VzxxqpoovMiCezDnbv9XGwt2Yk1wejxasPNXVZ3Ca9DBItxZcx+fnKegZh2XzE8O8R+DZuXPEfOOwM+DZNZ5lk5VA/f+9XSjJZJaZeucatap75y4iTpvniuVx6zYIduUteS7Nyor8S3sLFsBch/E=","Q":"wJR9dPtEgb63x0Wdw9VNpRSt0eks6JE3CsLZkI80qnbpdZ5cmxIyDl5ww4t5haYiiJnD/FJIwFItdiH+GOyIaghcQnEMedSZG3iQVF6CvrjNhpymLPHqpg3iECmubyUlf3Q78UoVUl8u+3GEQQekwiHvbGyKq7vB5PziJqX9hdc="}
                //    //Secret = "{\"D\":\"Z7At6fVvJdIX8QUS5s6qKo1K6YRrikZDCBtmZtFNvsLVDvmB5LNNtQ/TjrcxbmJCxcZCNudlnPSdK298QZFxc3asGpLtPkT9z2zjFOaQA9wpNtvQK7BTP/56QJQP6ioxGfEvilEXVXw+2ERkniu5zgOj5MdLy/T31JTUL6iCIJKsK6x2+pu0QbqCJPnQiZk+GvRB4/Y9VEvtUZl9xJQxuTkR/fYLXRL1sKbOxtWvf1Mimm62T1EH1GmR7cZvKkqdtLKrb/8/gehlcaWZ8ms0rfUWeEJUB1mPvqsCVjH5rvS1rX08j5gPyZtolpRqSoYjvFhk+3y6FQ6EOBX93RHVoQ==\",\"DP\":\"TniHOfpjiWIuvEY46jdEgXfpycz5qwOBvkT59H551kAZvNjthCi3qaIhwpL+Eitfwe0ReqJKD/UYyojfq/6IDV+2UrKcitgd1f4E6dX5NIzQQ1cLN9Xga6hBPfosq12zZPHLUoHxQRtcNb305+EFHiHmEoYxfQl69RJBM3X3iZE=\",\"DQ\":\"KR8L8vC8XiAFSg25dFmVrMxPmWT66+YmJKwanN2XV1bw3uajy5EFE0BjP74Ggt1IvnZm/PftBPQHNRRpF5VaQ5npaV6OVW1qDA2gdAOCU4tOh5Hnge1eN3r7bIwZ7S23ZhHBwvIYv3AHrjU9Ek25hqKMZ1B+A9Ghw22kNLB5BB0=\",\"Exponent\":\"AQAB\",\"InverseQ\":\"FjYzuUqQ4/EFTsWB2upii23mu5r0bEZ579TKNdbzVeSQkGcbI7tTRI4TrOWo07WkiAiJHe4XJtPxc/yj+vjzGhqqxjaaLWMK18qTwPY6OSOavwRZLEqdl/2kVslwZni8JTON18LY9itRM7uaY5lmmDUI7PNpyibbhJo9q0uBJYI=\",\"Modulus\":\"mMxzNRkfAUGaa1CX8VGlsM07alr3mBMYbRWbOEz5/CtsrA8h70GMomHw97iTn6kn0/tTaOUUrEOu7bRZUiKLLlswV8Q5uyfukoNuSKR5bQUFGaZ1/WO11nAcdCcH0vmN8gZ9eRZiXfOx5sWA+SJ8YXN0H9DwlglhrRQZg8WA05bZ5jbAcfzeF3+rfkL+3b7CnZic2Yupk9zrR1uxQnD3qNKR2dlXCtSibb4JVzJ4CNSySqWvP0Q6fB0IBHnqLgJbE7lDRhLveW6IP6wcAZDxGFJ7fWys4Q2CGd0iCjviBHWDtkCWOaB57xTbR5Su7/mNhYWie14cuuWji9DiToNgZw==\",\"P\":\"yx4toDmRKT1nu7MrJeNAbK1VzxxqpoovMiCezDnbv9XGwt2Yk1wejxasPNXVZ3Ca9DBItxZcx+fnKegZh2XzE8O8R+DZuXPEfOOwM+DZNZ5lk5VA/f+9XSjJZJaZeucatap75y4iTpvniuVx6zYIduUteS7Nyor8S3sLFsBch/E=\",\"Q\":\"wJR9dPtEgb63x0Wdw9VNpRSt0eks6JE3CsLZkI80qnbpdZ5cmxIyDl5ww4t5haYiiJnD/FJIwFItdiH+GOyIaghcQnEMedSZG3iQVF6CvrjNhpymLPHqpg3iECmubyUlf3Q78UoVUl8u+3GEQQekwiHvbGyKq7vB5PziJqX9hdc=\"}"
                //};

                //dbContext.Set<Site>().Add(site);


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
