using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using System.Data;

namespace LiveAuction
{
    public partial class Bidder : System.Web.UI.MasterPage
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserType"] != null && Convert.ToString(Session["UserType"]) != "")
            {
                if (Session["UserName"] != null && Convert.ToString(Session["UserName"]) != "")
                {
                    lblUserName.Text = Session["UserName"].ToString();
                    liSignUp.Visible = false;
                    liLogIn.Visible = false;
                    liWecomeUser.Visible = true;
                    liLogout.Visible = true;
                }
            }
            else
            {
                liSignUp.Visible = true;
                liLogIn.Visible = true;
                liWecomeUser.Visible = false;
                liLogout.Visible = false;
            }

        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
            Session.Clear();
            Response.Redirect("index.aspx");
        }
        protected void lnkSeller_Click(object sender, EventArgs e)
        {
            if (Session["UserType"] != null && Convert.ToString(Session["UserType"]) != "")
            {
                if (Convert.ToString(Session["UserType"]) == "Seller")
                {
                    Response.Redirect("seller-track/dashboard.aspx");
                }
                else 
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ScriptRegistration", "trLoginR('Please login as a Seller');", true);
                
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ScriptRegistration", "trLoginR('Please login as a Seller');", true);

            }
        }
         
        

       
    }
}