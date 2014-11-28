using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CL.Infrastructure
{
    public class DatabaseContext : IdentityDbContext<User>
    {
        public DatabaseContext()
            : base(Constants.Constants.AppConnection)
        {
        }


        public IDbSet<Transaction> Transactions { get; set; }

        public IDbSet<Client> Clients { get; set; }

        public IDbSet<Company> Companies { get; set; }

        public IDbSet<Card> Cards { get; set; }

        
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Remove unused conventions
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUser>()
                .ToTable("Users");
            modelBuilder.Entity<User>()
                .ToTable("Users");

            modelBuilder.Entity<IdentityRole>()
            .ToTable("Roles");
            modelBuilder.Entity<Role>()
                .ToTable("Roles");

            modelBuilder.Entity<IdentityUserRole>()
                .ToTable("UserRoles");

        }


    }
}
