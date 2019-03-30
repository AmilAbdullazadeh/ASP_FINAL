namespace ASPFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aaA : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Announcements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        City = c.String(nullable: false, maxLength: 150),
                        Vip = c.Boolean(nullable: false),
                        CardDetailsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CarDetails", t => t.CardDetailsId)
                .Index(t => t.CardDetailsId);
            
            CreateTable(
                "dbo.CarDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 255),
                        Price = c.Int(nullable: false),
                        ModelId = c.Int(nullable: false),
                        ProductionYear = c.DateTime(nullable: false),
                        EngineCapacity = c.Double(nullable: false),
                        CarMarch = c.Int(nullable: false),
                        Color = c.String(nullable: false, maxLength: 100),
                        ShortContent = c.String(nullable: false, maxLength: 255),
                        FuelTypeId = c.Int(nullable: false),
                        GearboxId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FuelTypes", t => t.FuelTypeId)
                .ForeignKey("dbo.Gearboxes", t => t.GearboxId)
                .ForeignKey("dbo.Models", t => t.ModelId, cascadeDelete: true)
                .Index(t => t.ModelId)
                .Index(t => t.FuelTypeId)
                .Index(t => t.GearboxId);
            
            CreateTable(
                "dbo.FuelTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Gearboxes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        MarkaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Markas", t => t.MarkaId)
                .Index(t => t.MarkaId);
            
            CreateTable(
                "dbo.Markas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 255),
                        Title = c.String(nullable: false, maxLength: 100),
                        Content = c.String(nullable: false, maxLength: 255),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 70),
                        Lastname = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        PhoneNumber = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true, name: "UN_Email");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Announcements", "CardDetailsId", "dbo.CarDetails");
            DropForeignKey("dbo.CarDetails", "ModelId", "dbo.Models");
            DropForeignKey("dbo.Models", "MarkaId", "dbo.Markas");
            DropForeignKey("dbo.CarDetails", "GearboxId", "dbo.Gearboxes");
            DropForeignKey("dbo.CarDetails", "FuelTypeId", "dbo.FuelTypes");
            DropIndex("dbo.Users", "UN_Email");
            DropIndex("dbo.Models", new[] { "MarkaId" });
            DropIndex("dbo.CarDetails", new[] { "GearboxId" });
            DropIndex("dbo.CarDetails", new[] { "FuelTypeId" });
            DropIndex("dbo.CarDetails", new[] { "ModelId" });
            DropIndex("dbo.Announcements", new[] { "CardDetailsId" });
            DropTable("dbo.Users");
            DropTable("dbo.News");
            DropTable("dbo.Markas");
            DropTable("dbo.Models");
            DropTable("dbo.Gearboxes");
            DropTable("dbo.FuelTypes");
            DropTable("dbo.CarDetails");
            DropTable("dbo.Announcements");
        }
    }
}
