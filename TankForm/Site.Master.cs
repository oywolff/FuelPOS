using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using TankForm.Models;
using TankForm.Logic;

namespace TankForm
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        public string ValgtStasjon
        {
            get
            {
                //return Label1.Text;
                if (DropDownList1.SelectedItem != null)
                    return DropDownList1.SelectedItem.Value;
                else return "JOARS";
            }
            set
            {
                Label1.Text = value;
            }
        }

        public string Oppdatering
        {
            get
            {
                return Label2.Text;
            }
            set
            {
                Label2.Text = value;
                //Label2.Visible = true;
            }
        }

        public void NyStasjonValgt(Object sender, EventArgs e)
        {
            Label1.Text = DropDownList1.SelectedItem.Value;
            ValgtStasjon = DropDownList1.SelectedItem.Value;
            Label2.Text = "Oppdatert";
            Oppdatering = "Oppdatert";
        }

        public void LagStasjonliste()
        {
            var _db = new TankForm.Models.ProduktContext();
            IQueryable<Stasjon> query = _db.Stasjoner;
            foreach (var item in query)
            {
                DropDownList1.Items.Add(new ListItem(item.Stasjonsnummer.ToString(), item.Navn));
            }
            //DropDownList1.Items.Add(new ListItem("Carbon", "C"));
        }


        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.IsInRole("canEdit"))
            {
                produktlink.Visible = true;
                prislogglink.Visible = true;
                rapporterlink.Visible = true;
                DropDownList1.Visible = true;
                Label1.Visible = true;
            }

            if (DropDownList1.SelectedItem == null)
            {
                LagStasjonliste();
                DropDownList1.SelectedItem.Value = "JOARS";
                Label1.Text = "JOARS";
                Label2.Text = "Oppdatert";
                Oppdatering = "Oppdatert";
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            using (TankStatusActions usersShoppingCart = new TankStatusActions())
            {
                string cartStr = string.Format("Cart ({0})", usersShoppingCart.GetCount());
                cartCount.InnerText = cartStr;
            }
        }



        public IQueryable<Stasjon> GetStasjoner()
        {
            var _db = new TankForm.Models.ProduktContext();
            IQueryable<Stasjon> query = _db.Stasjoner;
            return query;
        }
        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut();
        }
    }

}