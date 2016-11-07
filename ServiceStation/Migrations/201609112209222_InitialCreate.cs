namespace ServiceStation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        CarsID = c.Int(nullable: false, identity: true),
                        Make = c.String(nullable: false, maxLength: 50),
                        Model = c.String(nullable: false, maxLength: 50),
                        Year = c.Int(nullable: false),
                        VIN = c.String(nullable: false, maxLength: 17),
                        ClientsID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CarsID)
                .ForeignKey("dbo.Clients", t => t.ClientsID, cascadeDelete: true)
                .Index(t => t.ClientsID);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientsID = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        BirthDate = c.DateTime(nullable: false),
                        Address = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ClientsID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrdersID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.String(nullable: false),
                        CarsID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrdersID)
                .ForeignKey("dbo.Cars", t => t.CarsID, cascadeDelete: true)
                .Index(t => t.CarsID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "CarsID", "dbo.Cars");
            DropForeignKey("dbo.Cars", "ClientsID", "dbo.Clients");
            DropIndex("dbo.Orders", new[] { "CarsID" });
            DropIndex("dbo.Cars", new[] { "ClientsID" });
            DropTable("dbo.Orders");
            DropTable("dbo.Clients");
            DropTable("dbo.Cars");
        }
    }
}
