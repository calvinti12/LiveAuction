using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LiveAuction.seller_track
{
    public partial class Seller : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["UserType"] != null && Convert.ToString(Session["UserType"]) != "")
            //{
            //    if (Convert.ToString(Session["UserType"]) == "Seller")
            //    {
            //        if (Session["UserName"] != null && Convert.ToString(Session["UserName"]) != "")
            //        {
            //            lblUserName.Text = Session["UserName"].ToString();

            //            liWecomeUser.Visible = true;
            //            liLogout.Visible = true;
            //        }
            //    }
            //    else
            //    {
            //        Response.Redirect("../index.aspx");
            //    }
            //}
            //else
            //{
                
            //    liWecomeUser.Visible = false;
            //    liLogout.Visible = false;
            //    Response.Redirect("../logout.aspx");
            //}
            if (string.IsNullOrEmpty(Convert.ToString(Session["AdminUserName"])))
                Response.Redirect("~/Admin/Login.aspx");
            //lblName.Text = Convert.ToString(Session["AdminName"]);
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