using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LiveAuction.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(Convert.ToString(Session["AdminUserName"])))
                Response.Redirect("~/Admin/Login.aspx");
            lblName.Text = Convert.ToString(Session["AdminName"]);
        }
        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("AdminName");
            Session.Remove("AdminUserName");
            Session.Remove("AdminUserId");
            Response.Redirect("~/Admin/Login.aspx");
        }
    }
}