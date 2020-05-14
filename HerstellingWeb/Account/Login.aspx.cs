using System;
using System.Web.Security;
using System.Web.UI;
using MediaMarktHerstelling;

namespace HerstellingWeb
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                lblFoutboodschap.Text = "";
                lblFoutboodschap.Visible = false;
            }
        }

        protected void btnAanmelden_Click(object sender, EventArgs e)
        {
            var c = (Controller) Session["Controller"];

            if (gebruikersnaam.Value.Trim() == "" || paswoord.Value == "")
            {
                lblFoutboodschap.Visible = true;
                lblFoutboodschap.Text = "Foutieve aanmeldpoging!";
            }
            else if (c.Aanmelden(gebruikersnaam.Value, paswoord.Value))
            {
                Session["User"] = c.CurrentUser;
                FormsAuthentication.RedirectFromLoginPage(gebruikersnaam.Value, false);
            }
        }

        protected void btnTerug_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

    }
}