using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication1.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApplication1.Models.ApplicationDbContext context)
        {

            var roleAdmin = context.Roles.SingleOrDefault(p => p.Name == "Owner");
            if (roleAdmin == null)
            {
                roleAdmin = new IdentityRole("Owner");
                context.Roles.Add(roleAdmin);
            }

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
