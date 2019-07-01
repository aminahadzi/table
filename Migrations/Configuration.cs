namespace Coffee_Table.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Coffee_Table.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Coffee_Table.Models.ApplicationDbContext>
    {
        public DbSet<Group> Groups { get; set; }
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Coffee_Table.Models.ApplicationDbContext";
        }

        protected override void Seed(Coffee_Table.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
