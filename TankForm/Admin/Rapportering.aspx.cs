using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Net;
using Microsoft.Reporting.WebForms;
using System.Web.Security;
using System.Security.Principal;


namespace TankForm
{
    public partial class Rapportering : System.Web.UI.Page
    {

        public class CustomReportCredentials : Microsoft.Reporting.WebForms.IReportServerCredentials
        {

            // local variable for network credential.
            private string _UserName;
            private string _PassWord;
            private string _DomainName;
            public CustomReportCredentials(string UserName, string PassWord, string DomainName)
            {
                _UserName = UserName;
                _PassWord = PassWord;
                _DomainName = DomainName;
            }

            public WindowsIdentity ImpersonationUser
            {
                get
                {
                    return null;  // not use ImpersonationUser
                }
            }

            public ICredentials NetworkCredentials
            {
                get
                {

                    // use NetworkCredentials
                    return new NetworkCredential(_UserName, _PassWord, _DomainName);
                }
            }
            public bool GetFormsCredentials(out Cookie authCookie, out string user, out string password, out string authority)
            {

                // not use FormsCredentials unless you have implements a custom autentication.
                authCookie = null;
                user = password = authority = null;
                return false;
            }
                        


        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IReportServerCredentials irsc = new CustomReportCredentials("oywo", "Draugen2016", "");
                ReportViewer1.ServerReport.ReportServerCredentials = irsc;
            }
        }
    }
}