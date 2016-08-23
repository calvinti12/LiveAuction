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
    public partial class timed_auction_lot : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopulateCategoryLevel1();
                PopulateAuction();
            }
        }
        private void PopulateCategoryLevel1()
        {
            TimedProductLotBL objTimedProductLotBL = new TimedProductLotBL();
            DataTable dtCategoryLevel1 = objTimedProductLotBL.GetProductCategoryLevel1();
            categotyLevel1.DataSource = dtCategoryLevel1;
            categotyLevel1.DataTextField = "CategoryName";
            categotyLevel1.DataValueField = "CategoryId";
            categotyLevel1.DataBind();
            PopulateCategoryLevel2(Convert.ToInt32(categotyLevel1.SelectedValue));
        }
        private void PopulateCategoryLevel2(int parentCategoryIdLevel1)
        {
            TimedProductLotBL objTimedProductLotBL = new TimedProductLotBL();
            DataTable dtCategoryLevel2 = objTimedProductLotBL.GetProductCategoryLevel2(parentCategoryIdLevel1);
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
            TimedProductLotBL objTimedProductLotBL = new TimedProductLotBL();
            DataTable dtCategoryLevel3 = objTimedProductLotBL.GetProductCategoryLevel3(parentCategoryIdLevel2);
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
        private void PopulateAuction()
        {
            TimedProductLotBL objTimedProductLotBL = new TimedProductLotBL();
            DataTable dtAuction = objTimedProductLotBL.GetAuction(Convert.ToString(Session["UserType"]), Convert.ToInt32(Session["UserId"]));
            auction.DataSource = dtAuction;
            auction.DataTextField = "AuctionName";
            auction.DataValueField = "TimedAuctionId";
            auction.DataBind();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                TimedProductLotBL objTimedProductLotBL = new TimedProductLotBL();
                TimedProductLotEL objTimedProductLotEL = new TimedProductLotEL();
                string Responsetxt = string.Empty;
                string productimages = Request["hdnimagefiles"];
                objTimedProductLotEL.ProductUsed = ItemUsed.SelectedItem.ToString();
                if (!categotyLevel2.Visible)
                {
                    objTimedProductLotEL.CategoryId = Convert.ToInt32(categotyLevel1.SelectedValue);
                }
                else
                {
                    if (categotyLevel3.Visible)
                    {
                        objTimedProductLotEL.CategoryId = Convert.ToInt32(categotyLevel3.SelectedValue);
                    }
                    else
                        objTimedProductLotEL.CategoryId = Convert.ToInt32(categotyLevel2.SelectedValue);
                }
                objTimedProductLotEL.AuctionId = Convert.ToInt32(auction.SelectedValue);
                objTimedProductLotEL.IsBranded = rdbYes.Checked;
                objTimedProductLotEL.Title = txtTitle.Text;
                objTimedProductLotEL.SKU = txtSKU.Text;
                objTimedProductLotEL.Description = txtDesc.Text;
                objTimedProductLotEL.Question = txtQuestion.Text;
                objTimedProductLotEL.Quantity = Convert.ToInt32(txtQuantity.Text);
                objTimedProductLotEL.CostBasis = txtCost.Text;
                objTimedProductLotEL.RetailPrice = txtRetail.Text;
                objTimedProductLotEL.BuyPrice = txtBuy.Text;
                objTimedProductLotEL.StartingBid = txtStartBid.Text;
                objTimedProductLotEL.ShipCountry = ddlCountry.Text;
                objTimedProductLotEL.ShipWithin = ddlShipWithin.Text;
                objTimedProductLotEL.DeliveryTime = ddlTimeTake.Text;
                objTimedProductLotEL.IsFreeShipping = chkFreeShipping.Checked;
                objTimedProductLotEL.ShippingPrice = ddlPrice.Text;
                objTimedProductLotEL.IsShippedEverywhere = chkShip.Checked;
                objTimedProductLotEL.LowEstimatePrice = lowEstimatePrice.Text;
                objTimedProductLotEL.HighEstimatePrice = highEstimatePrice.Text;
                objTimedProductLotEL.MaximumReserveValue = maximumReserveValue.Text;
                objTimedProductLotEL.BidderId = 0;
                objTimedProductLotEL.IsSold = false;
                objTimedProductLotEL.images = productimages;
                if (objTimedProductLotBL.Save(objTimedProductLotEL, out Responsetxt))
                {
                    rdbYes.Checked=false;
                    txtTitle.Text="";
                    txtSKU.Text="";
                    txtDesc.Text="";
                    txtQuestion.Text="";
                    txtQuantity.Text="";
                    txtCost.Text="";
                    txtRetail.Text="";
                    txtBuy.Text="";
                    txtStartBid.Text="";
                    ddlCountry.Text="";
                    ddlShipWithin.Text="";
                    ddlTimeTake.Text="";
                    chkFreeShipping.Checked=false;
                    ddlPrice.Text="";
                    chkShip.Checked=false;
                    lowEstimatePrice.Text="";
                    highEstimatePrice.Text="";
                    maximumReserveValue.Text="";
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