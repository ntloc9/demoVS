namespace HRManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "EmployeeName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Employees", "Address", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Employees", "Email", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Email", c => c.String(maxLength: 30));
            AlterColumn("dbo.Employees", "Address", c => c.String(maxLength: 30));
            AlterColumn("dbo.Employees", "EmployeeName", c => c.String(maxLength: 30));
        }
    }
}
