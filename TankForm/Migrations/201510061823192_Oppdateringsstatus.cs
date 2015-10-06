namespace TankForm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Oppdateringsstatus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Oppdateringsstatus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Stasjonsnr = c.Int(nullable: false),
                        Beskrivelse = c.String(),
                        Dato = c.DateTime(nullable: false),
                        NyInt = c.Int(nullable: false),
                        NyFloat = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Oppdateringsstatus");
        }
    }
}
