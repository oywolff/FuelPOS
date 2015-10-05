using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace TankForm.Models
{
    public class Stasjon
    {
        [ScaffoldColumn(false)]
        public int StasjonID { get; set; }

        public int Stasjonsnummer { get; set; }
    
        [Display(Name = "Stasjonens navn")]
        public string Navn { get; set; }

        public virtual ICollection<Produkt> Produkts { get; set; }
        public virtual ICollection<TankVolum> TankVolums { get; set; }

    }
}