namespace CL.Infrastructure.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CL.Infrastructure.Constants;
    using Domain.Entity;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<CL.Infrastructure.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CL.Infrastructure.DatabaseContext context)
        {
            // This method will be called after migrating to the latest version.
            var userManager = new UserManager<User>(new UserStore<User>(context));
            var roleManager = new RoleManager<Role>(new RoleStore<Role>(context));

            #region Migrate User and Roles
            if (!roleManager.RoleExists(UserRoles.Administrator)) context.Roles.AddOrUpdate(new Role()
            {
                Name = UserRoles.Administrator,
                Description = UserRoles.Administrator,
            });


            var company = new Company()
            {
                Id = Guid.NewGuid(),
                Name = "TDevs LTD",
                GiveBackPercentage = 10// 10 percent
            };
            var existed = context.Companies.Any(t => t.Name.Equals(company.Name));
            if (existed == false)
            {
                context.Companies.Add(company);
                context.SaveChanges();


                if (!roleManager.RoleExists(UserRoles.User)) context.Roles.AddOrUpdate(new Role() { Name = UserRoles.User, Description = UserRoles.User });

                var admin = new User()
                {
                    CompanyId = company.Id,
                    UserName = "admin",
                    Email = "hotankhoa.qn@gmail.com",
                    FirstName = "Khoa",
                    LastName = "Ho Tan",
                    Address = "Da Nang, Viet Nam"
                };


                if (userManager.Find("admin", "abcde12345-") == null)
                {
                    var resultAdmin = userManager.Create(admin, "abcde12345-");
                    if (resultAdmin.Succeeded)
                        userManager.AddToRole(admin.Id, UserRoles.Administrator);
                }


            }

            var client = new Client()
          {
              Id = Guid.NewGuid(),
              FirstName = "Khoa",
              LastName = "Ho",
              SurName = "Mr",
              Email = "hotankhoa.qn@gmail.com"

          };
            client.Cards = new List<Card>();
            client.Cards.Add(new Card() { Id = Guid.NewGuid(), CardNumber = "6565447" });
            client.Cards.Add(new Card() { Id = Guid.NewGuid(), CardNumber = "7797979" });
            client.Cards.Add(new Card() { Id = Guid.NewGuid(), CardNumber = "8646511" });
            var existedClient = context.Clients.Any(t => t.LastName.Equals(client.LastName));
            if (existed == false)
            {
                context.Clients.Add(client);
                context.SaveChanges();
            }


            #endregion
        }
    }
}
