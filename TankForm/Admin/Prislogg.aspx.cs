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
    public partial class Prislogg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IQueryable<PrisLogg> GetPrislogg()
        {
            var _db = new TankForm.Models.ProduktContext();
            IQueryable<PrisLogg> query = _db.Prislogger;
            return query;
        }
    }
}