using System;
using System.Web;
using System.Web.UI;
using MediaMarktHerstelling;

namespace HerstellingWeb
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            ScriptManager.ScriptResourceMapping.AddDefinition(
                "jquery",
                new ScriptResourceDefinition
                {
                    Path = "~/Scripts/jquery-3.0.0.slim.js"
                }
            );
            ScriptManager.ScriptResourceMapping.AddDefinition(
                "popper",
                new ScriptResourceDefinition
                {
                    Path = "~/Scripts/popper.min.js"
                }
            );
            ScriptManager.ScriptResourceMapping.AddDefinition(
                "bootstrap",
                new ScriptResourceDefinition
                {
                    Path = "~/Scripts/bootstrap.min.js"
                }
            );
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            var c = new Controller();
            Session["controller"] = c;
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {
        }

        protected void Session_End(object sender, EventArgs e)
        {
        }

        protected void Application_End(object sender, EventArgs e)
        {
        }
    }
}