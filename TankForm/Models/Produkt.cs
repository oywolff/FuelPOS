using System.ComponentModel.DataAnnotations;


namespace TankForm.Models
{
    public class Produkt
    {
        [ScaffoldColumn(false)]
        public int ProduktID { get; set; }
        public int Produktnr { get; set; }
        [Required, StringLength(20), Display(Name = "Beskrivelse")]
        public string Beskrivelse { get; set; }
        public string ImagePath { get; set; }
        [Display(Name = "Pris")]
        public double? Pris { get; set; }
        public int? StasjonID { get; set; }
        public virtual Stasjon Stasjons { get; set; }
    }
}