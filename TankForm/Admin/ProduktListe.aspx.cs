using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TankForm.Models;
using TankForm.Logic;
using System.Collections.Specialized;
using System.Collections;
using System.Web.ModelBinding;
using System.Data.Entity;

namespace TankForm
{
    public partial class ProduktListe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            produktListe.DataBind();
        }

        public IQueryable<Produkt> GetProdukterStasjon()
        {
            var _db = new TankForm.Models.ProduktContext();
            IQueryable<Produkt> query = _db.Produkter.Include(e => e.Stasjons);
            // for valgt stasjon 
            if (Master.ValgtStasjon != "") query = query.Where(p => p.Stasjons.Navn == Master.ValgtStasjon);
            return query;
        }


        public IQueryable<Produkt> GetProdukter([QueryString("id")] int? stasjonId)
        {
            var _db = new TankForm.Models.ProduktContext();
            IQueryable<Produkt> query = _db.Produkter;
            if (stasjonId.HasValue && stasjonId > 0)
            {
                query = query.Where(p => p.StasjonID == stasjonId);
            }
            return query;
        }
    }
}