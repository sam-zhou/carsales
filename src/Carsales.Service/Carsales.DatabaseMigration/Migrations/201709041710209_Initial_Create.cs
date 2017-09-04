namespace Carsales.DatabaseMigration.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserId = c.Long(nullable: false),
                        RoleId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IsActive = c.Boolean(nullable: false),
                        UserLoginAttempt = c.Int(nullable: false),
                        LastLoginTime = c.DateTime(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.UserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Long(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        VehicleType = c.Int(nullable: false),
                        BadgeId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 500),
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
                .ForeignKey("dbo.Badges", t => t.BadgeId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.CreatedBy)
                .ForeignKey("dbo.Users", t => t.DeletedBy)
                .ForeignKey("dbo.Users", t => t.ModifiedBy)
                .Index(t => t.BadgeId)
                .Index(t => t.CreatedBy)
                .Index(t => t.ModifiedBy)
                .Index(t => t.DeletedBy);
            
            CreateTable(
                "dbo.Badges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        ModelId = c.Int(nullable: false),
                        Engine = c.Int(nullable: false),
                        Doors = c.Int(nullable: false),
                        Wheels = c.Int(nullable: false),
                        BadgeType = c.Int(nullable: false),
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
                .ForeignKey("dbo.Models", t => t.ModelId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.ModifiedBy)
                .Index(t => t.ModelId)
                .Index(t => t.CreatedBy)
                .Index(t => t.ModifiedBy)
                .Index(t => t.DeletedBy);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        MakeId = c.Int(nullable: false),
                        VehicleType = c.Int(nullable: false),
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
                .ForeignKey("dbo.Makes", t => t.MakeId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.ModifiedBy)
                .Index(t => t.MakeId)
                .Index(t => t.CreatedBy)
                .Index(t => t.ModifiedBy)
                .Index(t => t.DeletedBy);
            
            CreateTable(
                "dbo.Makes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
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
                .Index(t => t.CreatedBy)
                .Index(t => t.ModifiedBy)
                .Index(t => t.DeletedBy);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "ModifiedBy", "dbo.Users");
            DropForeignKey("dbo.Vehicles", "DeletedBy", "dbo.Users");
            DropForeignKey("dbo.Vehicles", "CreatedBy", "dbo.Users");
            DropForeignKey("dbo.Vehicles", "BadgeId", "dbo.Badges");
            DropForeignKey("dbo.Badges", "ModifiedBy", "dbo.Users");
            DropForeignKey("dbo.Badges", "ModelId", "dbo.Models");
            DropForeignKey("dbo.Models", "ModifiedBy", "dbo.Users");
            DropForeignKey("dbo.Models", "MakeId", "dbo.Makes");
            DropForeignKey("dbo.Makes", "ModifiedBy", "dbo.Users");
            DropForeignKey("dbo.Makes", "DeletedBy", "dbo.Users");
            DropForeignKey("dbo.Makes", "CreatedBy", "dbo.Users");
            DropForeignKey("dbo.Models", "DeletedBy", "dbo.Users");
            DropForeignKey("dbo.Models", "CreatedBy", "dbo.Users");
            DropForeignKey("dbo.Badges", "DeletedBy", "dbo.Users");
            DropForeignKey("dbo.Badges", "CreatedBy", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserLogins", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropIndex("dbo.Makes", new[] { "DeletedBy" });
            DropIndex("dbo.Makes", new[] { "ModifiedBy" });
            DropIndex("dbo.Makes", new[] { "CreatedBy" });
            DropIndex("dbo.Models", new[] { "DeletedBy" });
            DropIndex("dbo.Models", new[] { "ModifiedBy" });
            DropIndex("dbo.Models", new[] { "CreatedBy" });
            DropIndex("dbo.Models", new[] { "MakeId" });
            DropIndex("dbo.Badges", new[] { "DeletedBy" });
            DropIndex("dbo.Badges", new[] { "ModifiedBy" });
            DropIndex("dbo.Badges", new[] { "CreatedBy" });
            DropIndex("dbo.Badges", new[] { "ModelId" });
            DropIndex("dbo.Vehicles", new[] { "DeletedBy" });
            DropIndex("dbo.Vehicles", new[] { "ModifiedBy" });
            DropIndex("dbo.Vehicles", new[] { "CreatedBy" });
            DropIndex("dbo.Vehicles", new[] { "BadgeId" });
            DropIndex("dbo.UserLogins", new[] { "UserId" });
            DropIndex("dbo.UserClaims", new[] { "UserId" });
            DropIndex("dbo.Users", "UserNameIndex");
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.Roles", "RoleNameIndex");
            DropTable("dbo.Makes",
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
            DropTable("dbo.Models",
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
            DropTable("dbo.Badges",
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
            DropTable("dbo.Vehicles",
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
            DropTable("dbo.UserLogins");
            DropTable("dbo.UserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Roles");
        }
    }
}
