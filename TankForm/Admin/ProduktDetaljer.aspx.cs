using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TankForm.Models;
using System.Web.ModelBinding;

namespace TankForm
{
    public partial class ProduktDetaljer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IQueryable<Produkt> GetProdukter([QueryString("produktID")] int? produktId)
        {
            var _db = new TankForm.Models.ProduktContext();
            IQueryable<Produkt> query = _db.Produkter;
            if (produktId.HasValue && produktId > 0)
            {
                query = query.Where(p => p.ProduktID == produktId);
            }
            else
            {
                query = null;
            }
            return query;
        }
    }
}