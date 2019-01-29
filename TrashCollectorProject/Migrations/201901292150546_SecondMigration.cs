namespace TrashCollectorProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "pickupStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "pickupStatus");
        }
    }
}
