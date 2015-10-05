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
    public partial class TankStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var _db = new TankForm.Models.ProduktContext())
            {

                var myItem = (from c in _db.TankVolumer where c.Drivstoff.Equals("95 BlyFri") select c).Where(p => p.Stasjons.Navn == Master.ValgtStasjon).FirstOrDefault();
                if (myItem != null) Chart3.ChartAreas[0].AxisY.Maximum = myItem.Kapasitet;

                myItem = (from c in _db.TankVolumer where c.Drivstoff.Equals("Diesel") select c).Where(p => p.Stasjons.Navn == Master.ValgtStasjon).FirstOrDefault();
                if (myItem != null) Chart4.ChartAreas[0].AxisY.Maximum = myItem.Kapasitet;

                myItem = (from c in _db.TankVolumer where c.Drivstoff.Equals("Diesel Avgfr") select c).Where(p => p.Stasjons.Navn == Master.ValgtStasjon).FirstOrDefault();
                if (myItem != null) Chart7.ChartAreas[0].AxisY.Maximum = myItem.Kapasitet;
            }

            Tankst3.DataBind();
            Tankst4.DataBind();
            Tankst7.DataBind();
        }



        public IQueryable<TankVolum> GetTankVolum3()
        {
            var _db = new TankForm.Models.ProduktContext();
            IQueryable<TankVolum> query = _db.TankVolumer.Include(e => e.Stasjons);
            // for valgt stasjon 
            if (Master.ValgtStasjon != "") query = query.Where(p => p.Stasjons.Navn == Master.ValgtStasjon);
            query = query.Where(p => p.Drivstoff == "95 BlyFri");
            return query;
        }
        public IQueryable<TankVolum> GetTankVolum4()
        {
            var _db = new TankForm.Models.ProduktContext();
            IQueryable<TankVolum> query = _db.TankVolumer.Include(e => e.Stasjons);
            // for valgt stasjon 
            if (Master.ValgtStasjon != "") query = query.Where(p => p.Stasjons.Navn == Master.ValgtStasjon);
            query = query.Where(p => p.Drivstoff == "Diesel");
            return query;
        }
        public IQueryable<TankVolum> GetTankVolum7()
        {
            var _db = new TankForm.Models.ProduktContext();
            IQueryable<TankVolum> query = _db.TankVolumer.Include(e => e.Stasjons);
            // for valgt stasjon 
            if (Master.ValgtStasjon != "") query = query.Where(p => p.Stasjons.Navn == Master.ValgtStasjon);
            query = query.Where(p => p.Drivstoff == "Diesel Avgfr");
            return query;
        }   
    }
}