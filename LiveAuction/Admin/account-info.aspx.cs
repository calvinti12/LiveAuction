using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicLayer;
using EntityLayer;

namespace LiveAuction.seller_track
{
    public partial class account_info : System.Web.UI.Page
    {
        BidderBL objBidderBL = new BidderBL();
        BidderEL objBidderEL = new BidderEL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] != null)
                {
                    PopulateSellerAccountDetails(Convert.ToInt32(Session["UserId"]));
                }
            }

        }



        public void PopulateSellerAccountDetails(int SellerId)
        {
            DataTable dtAcct = objBidderBL.SellerAccountDetails(SellerId);
            if (dtAcct != null && dtAcct.Rows.Count > 0)
            {
                txtName.Text = Convert.ToString(dtAcct.Rows[0]["PreferredName"]);
                txtEmail.Text = Convert.ToString(dtAcct.Rows[0]["Email"]);
                txtPhone.Text = Convert.ToString(dtAcct.Rows[0]["Telephone"]);
                PopulateCountryList();
                ddlCountry.SelectedValue = Convert.ToString(dtAcct.Rows[0]["Country"]);
                PopulateTimeZoneListByCountry(Convert.ToInt32(ddlCountry.SelectedValue));
                ddlTimeZone.SelectedValue = Convert.ToString(dtAcct.Rows[0]["TimeZone"]);
            }

        }

        public void PopulateCountryList()
        {
            DataTable dtCountry = objBidderBL.GetCountries();
            if (dtCountry != null && dtCountry.Rows.Count > 0)
            {
                ddlCountry.DataTextField = "CountryName";
                ddlCountry.DataValueField = "Id";
                ddlCountry.DataSource = dtCountry;
                ddlCountry.DataBind();
                
            }
            ddlCountry.Items.Insert(0, new ListItem("--Select Country--", "0"));

        }

        public void PopulateTimeZoneListByCountry(int CountryId)
        {
            DataTable dtTimeZone = objBidderBL.GetTimeZonesFromCountry(CountryId);
            if (dtTimeZone != null && dtTimeZone.Rows.Count > 0)
            {
                ddlTimeZone.DataTextField = "Name";
                ddlTimeZone.DataValueField = "Id";
                ddlTimeZone.DataSource = dtTimeZone;
                ddlTimeZone.DataBind();
                
            }
            ddlTimeZone.Items.Insert(0, new ListItem("--Select TimeZone--", "0"));

        }
        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            int CountryId = Convert.ToInt32(ddlCountry.SelectedValue);
            PopulateTimeZoneListByCountry(CountryId);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Session["UserId"] != null)
            {
                string Responsetxt = string.Empty;
                objBidderEL.BidderId = Convert.ToInt32(Session["UserId"]);
                objBidderEL.PreferredName = txtName.Text.Trim();
                objBidderEL.Telephone = txtPhone.Text.Trim();
                objBidderEL.Country = ddlCountry.SelectedValue;
                objBidderEL.TimeZone = ddlTimeZone.SelectedValue;

                if (objBidderBL.UpdateSellerAccount(objBidderEL, out Responsetxt))
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ScriptRegistration", "alert('" + Responsetxt + "');", true);
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ScriptRegistration", "alert('" + Responsetxt + "');", true);
                }
            }
        }
    }
}