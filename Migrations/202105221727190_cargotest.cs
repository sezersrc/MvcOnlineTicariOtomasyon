namespace MvcOnlineTicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cargotest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CargoDetails",
                c => new
                    {
                        CargoDetailID = c.Int(nullable: false, identity: true),
                        CargDetail = c.String(maxLength: 300, unicode: false),
                        TrackingNumber = c.String(maxLength: 10, unicode: false),
                        Employee = c.String(maxLength: 10, unicode: false),
                        Recipient = c.String(maxLength: 25),
                        CargoDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CargoDetailID);
            
            CreateTable(
                "dbo.CargoTrackings",
                c => new
                    {
                        CargoTrackingID = c.Int(nullable: false, identity: true),
                        TrackingNumber = c.String(maxLength: 10, unicode: false),
                        CTDetail = c.String(maxLength: 100, unicode: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CargoTrackingID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CargoTrackings");
            DropTable("dbo.CargoDetails");
        }
    }
}
