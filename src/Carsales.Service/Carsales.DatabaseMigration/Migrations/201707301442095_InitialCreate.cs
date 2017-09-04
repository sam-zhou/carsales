using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.Migrations;

namespace Carsales.DatabaseMigration.Migrations
{
    public partial class InitialCreate : DbMigration
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
                        Site_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sites", t => t.Site_Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.Site_Id);
            
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
                "dbo.Sites",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Description = c.String(maxLength: 500),
                        IsDefault = c.Boolean(nullable: false),
                        Url = c.String(nullable: false, maxLength: 20),
                        Type = c.Int(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "SqlDefaultValue",
                                    new AnnotationValues(oldValue: null, newValue: "GETUTCDATE()")
                                },
                            }),
                        CreatedBy = c.Long(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "SqlDefaultValue",
                                    new AnnotationValues(oldValue: null, newValue: "GETUTCDATE()")
                                },
                            }),
                        ModifiedBy = c.Long(nullable: false),
                        DeletedDateTime = c.DateTime(nullable: false),
                        DeletedBy = c.Long(nullable: false),
                        User_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedBy, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.ModifiedBy, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Url, unique: true, name: "IX_Site_Url")
                .Index(t => t.CreatedBy)
                .Index(t => t.ModifiedBy)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Description = c.String(maxLength: 500),
                        Url = c.String(nullable: false, maxLength: 20),
                        SiteId = c.Long(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "SqlDefaultValue",
                                    new AnnotationValues(oldValue: null, newValue: "GETUTCDATE()")
                                },
                            }),
                        CreatedBy = c.Long(nullable: false),
                        ModifiedDateTime = c.DateTime(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "SqlDefaultValue",
                                    new AnnotationValues(oldValue: null, newValue: "GETUTCDATE()")
                                },
                            }),
                        ModifiedBy = c.Long(nullable: false),
                        DeletedDateTime = c.DateTime(nullable: false),
                        DeletedBy = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedBy, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.ModifiedBy, cascadeDelete: false)
                .ForeignKey("dbo.Sites", t => t.SiteId, cascadeDelete: true)
                .Index(t => t.Url, unique: true, name: "IX_Project_Url")
                .Index(t => t.SiteId)
                .Index(t => t.CreatedBy)
                .Index(t => t.ModifiedBy);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sites", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Site_Id", "dbo.Sites");
            DropForeignKey("dbo.Projects", "SiteId", "dbo.Sites");
            DropForeignKey("dbo.Projects", "ModifiedBy", "dbo.Users");
            DropForeignKey("dbo.Projects", "CreatedBy", "dbo.Users");
            DropForeignKey("dbo.Sites", "ModifiedBy", "dbo.Users");
            DropForeignKey("dbo.Sites", "CreatedBy", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserLogins", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropIndex("dbo.Projects", new[] { "ModifiedBy" });
            DropIndex("dbo.Projects", new[] { "CreatedBy" });
            DropIndex("dbo.Projects", new[] { "SiteId" });
            DropIndex("dbo.Projects", "IX_Project_Url");
            DropIndex("dbo.Sites", new[] { "User_Id" });
            DropIndex("dbo.Sites", new[] { "ModifiedBy" });
            DropIndex("dbo.Sites", new[] { "CreatedBy" });
            DropIndex("dbo.Sites", "IX_Site_Url");
            DropIndex("dbo.UserLogins", new[] { "UserId" });
            DropIndex("dbo.UserClaims", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "Site_Id" });
            DropIndex("dbo.Users", "UserNameIndex");
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.Roles", "RoleNameIndex");
            DropTable("dbo.Projects",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "CreatedDateTime",
                        new Dictionary<string, object>
                        {
                            { "SqlDefaultValue", "GETUTCDATE()" },
                        }
                    },
                    {
                        "ModifiedDateTime",
                        new Dictionary<string, object>
                        {
                            { "SqlDefaultValue", "GETUTCDATE()" },
                        }
                    },
                });
            DropTable("dbo.Sites",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "CreatedDateTime",
                        new Dictionary<string, object>
                        {
                            { "SqlDefaultValue", "GETUTCDATE()" },
                        }
                    },
                    {
                        "ModifiedDateTime",
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
