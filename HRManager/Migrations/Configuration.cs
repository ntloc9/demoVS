namespace HRManager.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HRManager.Models.HRManagerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HRManager.Models.HRManagerContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Employees.AddOrUpdate(
              p => p.EmployeeId,
              new Models.Employee { EmployeeName = "Andrew Peters", Address = "12 cmt8 q3", Email = "Andrew@gmail.com" },
              new Models.Employee { EmployeeName = "Brice Lambson", Address = "13 cmt8 q3", Email = "Brice@gmail.com" },
              new Models.Employee { EmployeeName = "Rowan Miller", Address = "14 cmt8 q3", Email = "Rowan@gmail.com" }
            );
            //
        }
    }
}
