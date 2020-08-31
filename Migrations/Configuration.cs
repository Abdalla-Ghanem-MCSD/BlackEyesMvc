namespace BlackEyesMvc.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BlackEyesMvc.Models.DbContainer>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;

        }

        protected override void Seed(BlackEyesMvc.Models.DbContainer context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
