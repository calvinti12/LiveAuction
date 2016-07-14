using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using System.Data;
using EntityLayer;

namespace LiveAuction.seller_track
{
    public partial class list_deal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopulateCategoryLevel1();
                //PopulateAuction();
            }
        }
        private void PopulateCategoryLevel1()
        {
            DealBL objDealBL = new DealBL();
            DataTable dtCategoryLevel1 = objDealBL.GetProductCategoryLevel1();
            categotyLevel1.DataSource = dtCategoryLevel1;
            categotyLevel1.DataTextField = "CategoryName";
            categotyLevel1.DataValueField = "CategoryId";
            categotyLevel1.DataBind();
            PopulateCategoryLevel2(Convert.ToInt32(categotyLevel1.SelectedValue));
        }
        private void PopulateCategoryLevel2(int parentCategoryIdLevel1)
        {
            DealBL objDealBL = new DealBL();
            DataTable dtCategoryLevel2 = objDealBL.GetProductCategoryLevel2(parentCategoryIdLevel1);
            categotyLevel2.DataSource = dtCategoryLevel2;
            categotyLevel2.DataTextField = "CategoryName";
            categotyLevel2.DataValueField = "CategoryId";
            categotyLevel2.DataBind();
            if (dtCategoryLevel2.Rows.Count > 0)
            {
                categotyLevel2.Visible = true;
                PopulateCategoryLevel3(Convert.ToInt32(categotyLevel2.SelectedValue));
            }
            else
            {
                categotyLevel2.Visible = false;
                categotyLevel3.Visible = false;
            }
        }
        private void PopulateCategoryLevel3(int parentCategoryIdLevel2)
        {
            DealBL objDealBL = new DealBL();
            DataTable dtCategoryLevel3 = objDealBL.GetProductCategoryLevel3(parentCategoryIdLevel2);
            categotyLevel3.DataSource = dtCategoryLevel3;
            categotyLevel3.DataTextField = "CategoryName";
            categotyLevel3.DataValueField = "CategoryId";
            categotyLevel3.DataBind();
            if (dtCategoryLevel3.Rows.Count > 0)
            {
                categotyLevel3.Visible = true;
            }
            else
                categotyLevel3.Visible = false;
        }
        protected void categotyLevel1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateCategoryLevel2(Convert.ToInt32(categotyLevel1.SelectedValue));
        }
        protected void categotyLevel2_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateCategoryLevel3(Convert.ToInt32(categotyLevel2.SelectedValue));
        }
        //private void PopulateAuction()
        //{
        //    DealBL objDealBL = new DealBL();
        //    DataTable dtAuction = objDealBL.GetAuction(Convert.ToString(Session["UserType"]), Convert.ToInt32(Session["UserId"]));
        //    auction.DataSource = dtAuction;
        //    auction.DataTextField = "AuctionName";
        //    auction.DataValueField = "AuctionId";
        //    auction.DataBind();
        //}
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                DealBL objDealBL = new DealBL();
                DealEL objDealEL = new DealEL();
                string Responsetxt = string.Empty;
                string dealimages = Request["hdnimagefiles"];
                objDealEL.ProductUsed = ItemUsed.SelectedItem.ToString();
                if (!categotyLevel2.Visible)
                {
                    objDealEL.CategoryId = Convert.ToInt32(categotyLevel1.SelectedValue);
                }
                else
                {
                    if (categotyLevel3.Visible)
                    {
                        objDealEL.CategoryId = Convert.ToInt32(categotyLevel3.SelectedValue);
                    }
                    else
                        objDealEL.CategoryId = Convert.ToInt32(categotyLevel2.SelectedValue);
                }
                //objDealEL.AuctionId = Convert.ToInt32(auction.SelectedValue);
                objDealEL.IsBranded = rdbYes.Checked;
                objDealEL.Title = txtTitle.Text;
                objDealEL.SKU = txtSKU.Text;
                objDealEL.Description = txtDesc.Text;
                objDealEL.Question = txtQuestion.Text;
                //objDealEL.Quantity = Convert.ToInt32(txtQuantity.Text);
                //objDealEL.CostBasis = txtCost.Text;
                objDealEL.OriginalPrice = txtOriginalPrice.Text;
                objDealEL.DealPrice = TxtDealPrice.Text;
                objDealEL.DealDate = Convert.ToDateTime(auctiondate.Text);
                objDealEL.DealTime = auctiontime.Text;
                //objDealEL.StartingBid = txtStartBid.Text;
                objDealEL.ShipCountry = ddlCountry.Text;
                objDealEL.ShipWithin = ddlShipWithin.Text;
                objDealEL.DeliveryTime = ddlTimeTake.Text;
                objDealEL.IsFreeShipping = chkFreeShipping.Checked;
                objDealEL.ShippingPrice = ddlPrice.Text;
                objDealEL.IsShippedEverywhere = chkShip.Checked;
                objDealEL.images = dealimages;
                if (objDealBL.Save(objDealEL, out Responsetxt))
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