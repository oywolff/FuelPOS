namespace TankForm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PrisLoggs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Stasjonsnr = c.Int(nullable: false),
                        Produktnr = c.Int(nullable: false),
                        Dato = c.DateTime(nullable: false),
                        NyPris = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Produkts",
                c => new
                    {
                        ProduktID = c.Int(nullable: false, identity: true),
                        Produktnr = c.Int(nullable: false),
                        Beskrivelse = c.String(nullable: false, maxLength: 20),
                        ImagePath = c.String(),
                        Pris = c.Double(),
                        StasjonID = c.Int(),
                    })
                .PrimaryKey(t => t.ProduktID)
                .ForeignKey("dbo.Stasjons", t => t.StasjonID)
                .Index(t => t.StasjonID);
            
            CreateTable(
                "dbo.Stasjons",
                c => new
                    {
                        StasjonID = c.Int(nullable: false, identity: true),
                        Stasjonsnummer = c.Int(nullable: false),
                        Navn = c.String(),
                    })
                .PrimaryKey(t => t.StasjonID);
            
            CreateTable(
                "dbo.Tanks",
                c => new
                    {
                        TankId = c.String(nullable: false, maxLength: 128),
                        StatusId = c.String(),
                        Tanknummer = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        NyPris = c.Double(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        ProduktId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TankId)
                .ForeignKey("dbo.Produkts", t => t.ProduktId, cascadeDelete: true)
                .Index(t => t.ProduktId);
            
            CreateTable(
                "dbo.TankVolums",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Tanknummer = c.Int(nullable: false),
                        Drivstoff = c.String(),
                        Kapasitet = c.Int(nullable: false),
                        AktVolum = c.Single(nullable: false),
                        Ullage = c.Single(nullable: false),
                        VannNiva = c.Single(nullable: false),
                        Oppdatert = c.DateTime(nullable: false),
                        AktPris = c.Single(nullable: false),
                        NyPris = c.Single(nullable: false),
                        PrisOppdatert = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tanks", "ProduktId", "dbo.Produkts");
            DropForeignKey("dbo.Produkts", "StasjonID", "dbo.Stasjons");
            DropIndex("dbo.Tanks", new[] { "ProduktId" });
            DropIndex("dbo.Produkts", new[] { "StasjonID" });
            DropTable("dbo.TankVolums");
            DropTable("dbo.Tanks");
            DropTable("dbo.Stasjons");
            DropTable("dbo.Produkts");
            DropTable("dbo.PrisLoggs");
        }
    }
}
