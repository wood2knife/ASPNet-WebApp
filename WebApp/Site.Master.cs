using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.Core;

namespace WebApp
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserSession.Current.Role == null && HttpContext.Current.Request.Url.AbsoluteUri.Contains("Login.aspx"))
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}