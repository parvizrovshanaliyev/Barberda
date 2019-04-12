namespace Barbeda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BarberImage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 350),
                        BarberId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Barber", t => t.BarberId, cascadeDelete: false)
                .Index(t => t.BarberId);
            
            CreateTable(
                "dbo.Barber",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Surname = c.String(nullable: false, maxLength: 50),
                        Image = c.String(maxLength: 350),
                        Description = c.String(nullable: false, maxLength: 300),
                        Email = c.String(nullable: false),
                        Tel = c.Int(nullable: false),
                        BeganWork = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ServicetoBarber",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BarberId = c.Int(nullable: false),
                        ServiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Barber", t => t.BarberId, cascadeDelete: false)
                .ForeignKey("dbo.Service", t => t.ServiceId, cascadeDelete: false)
                .Index(t => t.BarberId)
                .Index(t => t.ServiceId);
            
            CreateTable(
                "dbo.Service",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Image = c.String(maxLength: 350),
                        Description = c.String(nullable: false, maxLength: 300),
                        DataFilter = c.String(nullable: false, maxLength: 50),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ServicePortfolio",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 350),
                        ServiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Service", t => t.ServiceId, cascadeDelete: false)
                .Index(t => t.ServiceId);
            
            CreateTable(
                "dbo.Slider",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TitleOne = c.String(nullable: false, maxLength: 100),
                        TitleTwo = c.String(nullable: false, maxLength: 100),
                        UpdateAt = c.DateTime(),
                        Image = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServicetoBarber", "ServiceId", "dbo.Service");
            DropForeignKey("dbo.ServicePortfolio", "ServiceId", "dbo.Service");
            DropForeignKey("dbo.ServicetoBarber", "BarberId", "dbo.Barber");
            DropForeignKey("dbo.BarberImage", "BarberId", "dbo.Barber");
            DropIndex("dbo.ServicePortfolio", new[] { "ServiceId" });
            DropIndex("dbo.ServicetoBarber", new[] { "ServiceId" });
            DropIndex("dbo.ServicetoBarber", new[] { "BarberId" });
            DropIndex("dbo.BarberImage", new[] { "BarberId" });
            DropTable("dbo.Slider");
            DropTable("dbo.ServicePortfolio");
            DropTable("dbo.Service");
            DropTable("dbo.ServicetoBarber");
            DropTable("dbo.Barber");
            DropTable("dbo.BarberImage");
        }
    }
}
