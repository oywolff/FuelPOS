using System.ComponentModel.DataAnnotations;

namespace TankForm.Models
{
    public class Tank
    {
        [Key]
        public string TankId { get; set; }
        public string StatusId { get; set; }
        public int Tanknummer { get; set; }
        public int Quantity { get; set; }
        public double NyPris { get; set; }
        public System.DateTime DateCreated { get; set; }
        public int ProduktId { get; set; }
        public virtual Produkt Produkt { get; set; }
  } 
}