namespace ServiceStation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AfterAddingViewModels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cars", "VIN", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cars", "VIN", c => c.String(nullable: false, maxLength: 17));
        }
    }
}
