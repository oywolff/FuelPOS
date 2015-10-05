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
    public partial class NyPrisendring : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            decimal nypris;
            string s;
            int tn;

            using (var _db = new TankForm.Models.ProduktContext())
            {

                for (int i = 0; i < TankenListe.Rows.Count; i++)
                {
                    TextBox prisTextBox = new TextBox();
                    prisTextBox = (TextBox)TankenListe.Rows[i].FindControl("NyPris");
                    nypris = Convert.ToDecimal(prisTextBox.Text.ToString());
                    tn = Convert.ToInt32(TankenListe.Rows[i].Cells[0].Text);
                    s = TankenListe.Rows[i].Cells[6].Text;

                    if ((float)nypris > 0)
                    {
                        prisTextBox.BackColor = System.Drawing.Color.Yellow;
                        prisTextBox.ForeColor = System.Drawing.Color.Black;
                    }
                    if (s == "True")
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

        public void UpdateItem()
        {
            decimal nypris;
            int tn;
            using (var _db = new TankForm.Models.ProduktContext())
            {
                for (int i = 0; i < TankenListe.Rows.Count; i++)
                {
                    TextBox prisTextBox = new TextBox();
                    prisTextBox = (TextBox)TankenListe.Rows[i].FindControl("NyPris");
                    nypris = Convert.ToDecimal(prisTextBox.Text.ToString());
                    tn = Convert.ToInt32(TankenListe.Rows[i].Cells[0].Text);

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
                    }
                    if ((float)nypris == 0.0)
                    {
                        TankenListe.Rows[i].Cells[6].ForeColor = System.Drawing.Color.Black;
                    }

                    try
                    {
                        var myItem = (from c in _db.TankVolumer where c.Tanknummer == tn select c).FirstOrDefault();
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