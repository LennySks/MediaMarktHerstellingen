using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HerstellingWeb
{
    public partial class Master : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Default.aspx");
        }
    }
}