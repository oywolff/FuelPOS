namespace TankForm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
         }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tanks", "ProduktId", "dbo.Produkts");
            DropForeignKey("dbo.TankVolums", "StasjonID", "dbo.Stasjons");
            DropForeignKey("dbo.Produkts", "StasjonID", "dbo.Stasjons");
            DropIndex("dbo.Tanks", new[] { "ProduktId" });
            DropIndex("dbo.TankVolums", new[] { "StasjonID" });
            DropIndex("dbo.Produkts", new[] { "StasjonID" });
            DropTable("dbo.Tanks");
            DropTable("dbo.TankVolums");
            DropTable("dbo.Stasjons");
            DropTable("dbo.Produkts");
            DropTable("dbo.PrisLoggs");
        }
    }
}
