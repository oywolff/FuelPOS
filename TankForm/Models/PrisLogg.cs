using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
namespace TankForm.Models
{
    public class PrisLogg
    {
        public int ID { get; set; }
        public int Stasjonsnr { get; set; }
        public int Produktnr { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Dato { get; set; }
        public float NyPris { get; set; }
    }
}