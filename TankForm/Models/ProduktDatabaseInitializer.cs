using System.Collections.Generic;
using System.Data.Entity;

namespace TankForm.Models
{
    public class ProduktDatabaseInitializer : DropCreateDatabaseIfModelChanges<ProduktContext>
    {
        protected override void Seed(ProduktContext context)
        {
            GetStasjoner().ForEach(c => context.Stasjoner.Add(c));
            GetProdukter().ForEach(p => context.Produkter.Add(p));
        }

        private static List<Stasjon> GetStasjoner()
        {
            var stasjoner = new List<Stasjon> {
                new Stasjon
                {
                    StasjonID = 1,
                    Stasjonsnummer = 2052,
                    Navn = "JOARS"
                },
            };
            return stasjoner;
        }

        private static List<Produkt> GetProdukter()
        {
            var produkter = new List<Produkt> {
                new Produkt
                {
                    ProduktID = 1,
                    Produktnr = 3,
                    Beskrivelse = "95 Blyfri", 
                    ImagePath="Blyfri95.png",
                    Pris = 14.05,
                    StasjonID = 1
               },
                new Produkt 
                {
                    ProduktID = 2,
                    Produktnr = 4,
                    Beskrivelse = "Diesel", 
                    ImagePath="Diesel.png",
                    Pris = 11.95,
                    StasjonID = 1
               },
                new Produkt
                {
                    ProduktID = 3,
                    Produktnr = 7,
                    Beskrivelse = "Diesel Avgfr", 
                    ImagePath="Diesel Avgfri.png",
                    Pris = 9.05,
                    StasjonID = 1
                },
            };

            return produkter;
        }
    }
}