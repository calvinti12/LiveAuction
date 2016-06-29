using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LiveAuction
{
    public partial class Selling : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserType"] != null && Convert.ToString(Session["UserType"]) != "")
            {
                if (Convert.ToString(Session["UserType"]) == "Seller")
                {
                    Response.Redirect("seller-track/dashboard.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ScriptRegistration", "trR('Please login as a Seller');", true);

                }
            }

        }
    }
}