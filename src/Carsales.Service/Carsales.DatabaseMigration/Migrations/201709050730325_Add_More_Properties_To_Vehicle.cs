namespace Carsales.DatabaseMigration.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Add_More_Properties_To_Vehicle : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FileName = c.String(nullable: false),
                        Path = c.String(nullable: false),
                        ThumbnailPath = c.String(nullable: false),
                        Order = c.Int(nullable: false),
                        VehicleId = c.Long(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "SqlDefaultValue",
                                    new AnnotationValues(oldValue: null, newValue: "GETUTCDATE()")
                                },
                            }),
                        CreatedBy = c.Long(),
                        ModifiedDateTime = c.DateTime(),
                        ModifiedBy = c.Long(),
                        DeletedDateTime = c.DateTime(),
                        DeletedBy = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedBy)
                .ForeignKey("dbo.Users", t => t.DeletedBy)
                .ForeignKey("dbo.Users", t => t.ModifiedBy)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.VehicleId)
                .Index(t => t.CreatedBy)
                .Index(t => t.ModifiedBy)
                .Index(t => t.DeletedBy);
            
            AddColumn("dbo.Vehicles", "Price", c => c.Int());
            AddColumn("dbo.Vehicles", "State", c => c.Int(nullable: false));
            AddColumn("dbo.Vehicles", "Postcode", c => c.String(maxLength: 4));
            AddColumn("dbo.Vehicles", "Surburb", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Images", "ModifiedBy", "dbo.Users");
            DropForeignKey("dbo.Images", "DeletedBy", "dbo.Users");
            DropForeignKey("dbo.Images", "CreatedBy", "dbo.Users");
            DropIndex("dbo.Images", new[] { "DeletedBy" });
            DropIndex("dbo.Images", new[] { "ModifiedBy" });
            DropIndex("dbo.Images", new[] { "CreatedBy" });
            DropIndex("dbo.Images", new[] { "VehicleId" });
            DropColumn("dbo.Vehicles", "Surburb");
            DropColumn("dbo.Vehicles", "Postcode");
            DropColumn("dbo.Vehicles", "State");
            DropColumn("dbo.Vehicles", "Price");
            DropTable("dbo.Images",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "CreatedDateTime",
                        new Dictionary<string, object>
                        {
                            { "SqlDefaultValue", "GETUTCDATE()" },
                        }
                    },
                });
        }
    }
}
