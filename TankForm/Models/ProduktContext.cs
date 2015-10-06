using System.Data.Entity;
namespace TankForm.Models
{
    public class ProduktContext : DbContext
    {
        public ProduktContext() : base("TankForm")
        {
        }
        public DbSet<Stasjon> Stasjoner { get; set; }
        public DbSet<Produkt> Produkter { get; set; }
        public DbSet<Tank> TankStatus { get; set; }
        public DbSet<TankVolum> TankVolumer { get; set; }
        public DbSet<PrisLogg> Prislogger { get; set; }
        public DbSet<Oppdateringsstatus> Oppdateringsstatus { get; set; }
    }
}