namespace SNRTVU.EMS.Infrastructure.Repositories.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SNRTVU.EMS.Infrastructure.Repositories.EntityFramework.EMSDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            base.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SNRTVU.EMS.Infrastructure.Repositories.EntityFramework.EMSDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
