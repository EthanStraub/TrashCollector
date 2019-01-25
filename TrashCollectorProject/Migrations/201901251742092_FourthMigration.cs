namespace TrashCollectorProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FourthMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Status");
        }
    }
}
