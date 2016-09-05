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
            //BidderCardDetailEL objBidderCardEL = new BidderCardDetailEL();
            string Responsetxt = string.Empty;
            objBidderEL.Email = txtEmail.Text;
            objBidderEL.Password = txtPassword.Text;
            objBidderEL.FirstName = firstName.Text;
            objBidderEL.LastName = lastName.Text;
            objBidderEL.Address = address1.Text;
            objBidderEL.City = town.Text;
            objBidderEL.PinCode = postcode.Text;
            objBidderEL.Telephone = telephone.Text;
            objBidderEL.CardExpiryMonth = Convert.ToInt32(ExpMonth.Text);
            objBidderEL.CardExpiryYear = Convert.ToInt32(ExpYear.Text);
            objBidderEL.CardStartMonth = Convert.ToInt32(startingMonth.Text);
            objBidderEL.CardStartYear = Convert.ToInt32(startingYear.Text);
            objBidderEL.CardHolderName = cardHolderName.Text;
            objBidderEL.CardNo = cardNo.Text;
            objBidderEL.SecurityCode = cvv.Text;
            objBidderEL.CardBillingAddress1 = address1.Text; ;

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