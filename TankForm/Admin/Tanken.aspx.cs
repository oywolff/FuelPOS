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
    public partial class Tanken : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            decimal nypris;
            string s;
            int tn;
            // Nødvendig ved flere tanker men hindrer nypris i å fungere...            
             //   TankenListe.DataBind();
   
            using (var _db = new TankForm.Models.ProduktContext())
            {

                for (int i = 0; i < TankenListe.Rows.Count; i++)
                {
                    TextBox prisTextBox = new TextBox(); 
                    prisTextBox = (TextBox)TankenListe.Rows[i].FindControl("NyPris");
                    nypris = Convert.ToDecimal(prisTextBox.Text.ToString());
                    tn = Convert.ToInt32(TankenListe.Rows[i].Cells[0].Text);
                    s = TankenListe.Rows[i].Cells[7].Text;
                 
                   if ((float)nypris > 0)
                    {
                        prisTextBox.BackColor = System.Drawing.Color.Yellow;
                        prisTextBox.ForeColor = System.Drawing.Color.Black;
                   }
                    if (s=="True")
                    {
                        prisTextBox.BackColor = System.Drawing.Color.Green;
                        prisTextBox.ForeColor = System.Drawing.Color.Black;
                    }

                    if ((float)nypris < 0)
                    {
                        TankenListe.Rows[i].Cells[6].ForeColor = System.Drawing.Color.Red;
                    }
                    if ((float)nypris == 0.0)
                        TankenListe.Rows[i].Cells[6].ForeColor = System.Drawing.Color.Black;
                }
            }

        }

        public IQueryable<TankVolum> GetTankVolum()
        {
           var _db = new TankForm.Models.ProduktContext();
            IQueryable<TankVolum> query = _db.TankVolumer.Include(e => e.Stasjons);
            // for valgt stasjon 
           if (Master.ValgtStasjon != "") query = query.Where(p => p.Stasjons.Navn == Master.ValgtStasjon);
            return query;
        }


        public IQueryable<TankVolum> GetTankVolumORIG()
        {
            var _db = new TankForm.Models.ProduktContext();
            IQueryable<TankVolum> query = _db.TankVolumer;
            return query;
        }

        public IQueryable<TankVolum> GetTankVolumLINK([QueryString("id")] int? stasjonId)
        {
            var _db = new TankForm.Models.ProduktContext();
            IQueryable<TankVolum> query = _db.TankVolumer.Include(e => e.Stasjons)
                .Where(e => e.StasjonID == stasjonId);

            if (stasjonId.HasValue && stasjonId > 0)
            {
                query = query.Where(p => p.StasjonID == stasjonId);
            }
            return query;
        }



        public void UpdateItemTEST()
        {
            float nypris;
            int tn;
            TextBox prisTextBox = new TextBox();
            prisTextBox = (TextBox)TankenListe.Rows[0].FindControl("NyPris");

            testlabel.Text = prisTextBox.Text;

            nypris = (float)Convert.ToDecimal(prisTextBox.Text.ToString());
            tn = Convert.ToInt32(TankenListe.Rows[0].Cells[0].Text);

            using (var _adb = new ProduktContext())
            {
                var testitem = (from t in _adb.TankVolumer where t.Tanknummer ==1  select t).FirstOrDefault();
                //testitem = testitem.Where(t => t.StasjonID.Equals(1));
               // testitem = testitem.Where(t => t.Tanknummer.Equals(1));
                testitem.NyPris = 0;
                _adb.SaveChanges();
            }
            TankenListe.DataBind();

        }

        public void UpdateItem()
        {
            decimal nypris;
            int tn;
            int TableID;
   
            using (var _db = new ProduktContext())
            {
                for (int i = 0; i < TankenListe.Rows.Count; i++)
                {
                    TextBox prisTextBox = new TextBox();
                    prisTextBox = (TextBox)TankenListe.Rows[i].FindControl("NyPris");
                    nypris = Convert.ToDecimal(prisTextBox.Text.ToString());
                    tn = Convert.ToInt32(TankenListe.Rows[i].Cells[0].Text); 
                    TableID = Convert.ToInt32(TankenListe.Rows[i].Cells[8].Text);

                    prisTextBox.BackColor = System.Drawing.Color.White;
                    prisTextBox.ForeColor = System.Drawing.Color.Black;
                    if ((float)nypris > 0)
                    {
                        prisTextBox.BackColor = System.Drawing.Color.Yellow;
                        prisTextBox.ForeColor = System.Drawing.Color.Black;
                       
                    }
                   if ((float)nypris < 0)
                   {
                       prisTextBox.ForeColor = System.Drawing.Color.Red;  
                       UpdateBtn.Text = nypris.ToString();
                   }
                   if ((float)nypris== 0.0)
                   {
                       TankenListe.Rows[i].Cells[6].ForeColor = System.Drawing.Color.Black;
                   }
 
                    try
                    {
                        var myItem = (from c in _db.TankVolumer where c.ID== TableID  select c).FirstOrDefault();
                                 
                            if (myItem != null)
                            {
                                myItem.PrisOppdatert = false;
                               // myItem.NyPris =(float)nypris;
                                myItem.NyPris = (float)Convert.ToDecimal(prisTextBox.Text.ToString());
                                myItem.PrisOppdatert = false;
                                _db.SaveChanges();
                            }
                        
                    }
                    catch (Exception exp)
                    {
                        throw new Exception("ERROR: Unable to Update product - " + exp.Message.ToString(), exp);
                    }


               //     TankenListe.Rows[i].FindControl("Remove").Visible =false;
                }
            }
        }

        protected void CreateFile_Click(object sender, EventArgs e)
        {
            Master.Oppdatering = "123"; // funcParam.Text;
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            UpdateItem();
            //UpdateBtn.Enabled = false;
            //UpdateBtn.Visible = false;
            //UpdateBtn.BackColor = System.Drawing.Color.Green;
            //UpdateBtn.Text = "Sendt til systemet....";


        }
    }
}