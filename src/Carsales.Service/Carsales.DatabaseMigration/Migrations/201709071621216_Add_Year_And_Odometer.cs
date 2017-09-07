namespace Carsales.DatabaseMigration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Year_And_Odometer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "Year", c => c.Int(nullable: false));
            AddColumn("dbo.Vehicles", "Odometer", c => c.Int(nullable: false));
            AddColumn("dbo.Badges", "Year", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Badges", "Year");
            DropColumn("dbo.Vehicles", "Odometer");
            DropColumn("dbo.Vehicles", "Year");
        }
    }
}
