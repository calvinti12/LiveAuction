using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityLayer;
using BusinessLogicLayer;

namespace LiveAuction
{
    public partial class signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnCreateAcc_Click(object sender, EventArgs e)
        {
            BidderEL objBidderEL = new BidderEL();
            BidderBL objBidderBL = new BidderBL();
            string Responsetxt = string.Empty;
            objBidderEL.Email = txtEmail.Text;
            objBidderEL.Password = txtPassword.Text;
            //objBidderEL.UserType = rdbtnlistUserType.SelectedValue;
            objBidderEL.UserType = "1";
            if (chkAgree.Checked)
            {
                if (objBidderBL.BidderSignUp(objBidderEL, out Responsetxt))
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ScriptRegistration", "trG('" + Responsetxt + "');", true);
                }
                else
                {
                    //lblMsg.ForeColor = System.Drawing.Color.Red;
                    //lblMsg.Text = Responsetxt;
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ScriptRegistration", "trR('" + Responsetxt + "');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ScriptRegistration", "trR('Please check read and agree checkbox');", true);
            }

        }
    }
}