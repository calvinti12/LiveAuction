using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LiveAuction
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LogoutUser();

        }
        protected void LogoutUser()
        {
            Session.RemoveAll();
            Session.Abandon();
            Session.Clear();
            Response.Redirect("index.aspx");
        }
    }
}