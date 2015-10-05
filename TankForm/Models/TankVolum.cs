using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace TankForm.Models
{
    public class TankVolum
    {
        public int ID { get; set; }
        public int Tanknummer { get; set; }
        public String Drivstoff { get; set; }
        public int Kapasitet { get; set; }
        public float AktVolum { get; set; }
        public float Ullage { get; set; }
        public float VannNiva { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Oppdatert { get; set; }
        public float AktPris { get; set; }
        public float NyPris { get; set; }
        public Boolean PrisOppdatert { get; set; }
        public int? StasjonID { get; set; }
        public virtual Stasjon Stasjons { get; set; }
    }
}