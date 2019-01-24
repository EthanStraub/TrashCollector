namespace TrashCollectorProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        pickupDay = c.String(),
                        oneTimePickupDay = c.String(),
                        startDate = c.String(),
                        endDate = c.String(),
                        dueBalance = c.Int(nullable: false),
                        addressLine1 = c.String(),
                        addressLine2 = c.String(),
                        cityAndState = c.String(),
                        zipCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customers");
        }
    }
}
