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
    public partial class list_item : System.Web.UI.Page
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
            ProductLotBL objProductLotBL = new ProductLotBL();
            DataTable dtCategoryLevel1 = objProductLotBL.GetProductCategoryLevel1();
            categotyLevel1.DataSource = dtCategoryLevel1;
            categotyLevel1.DataTextField = "CategoryName";
            categotyLevel1.DataValueField = "CategoryId";
            categotyLevel1.DataBind();
            PopulateCategoryLevel2(Convert.ToInt32(categotyLevel1.SelectedValue));
        }
        private void PopulateCategoryLevel2(int parentCategoryIdLevel1)
        {
            ProductLotBL objProductLotBL = new ProductLotBL();
            DataTable dtCategoryLevel2 = objProductLotBL.GetProductCategoryLevel2(parentCategoryIdLevel1);
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
            ProductLotBL objProductLotBL = new ProductLotBL();
            DataTable dtCategoryLevel3 = objProductLotBL.GetProductCategoryLevel3(parentCategoryIdLevel2);
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
            ProductLotBL objProductLotBL = new ProductLotBL();
            DataTable dtAuction = objProductLotBL.GetAuction(Convert.ToString(Session["UserType"]), Convert.ToInt32(Session["UserId"]));
            auction.DataSource = dtAuction;
            auction.DataTextField = "AuctionName";
            auction.DataValueField = "AuctionId";
            auction.DataBind();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                ProductLotBL objProductLotBL = new ProductLotBL();
                ProductLotEL objProductLotEL = new ProductLotEL();
                string Responsetxt = string.Empty;
                string productimages = Request["hdnimagefiles"];
                objProductLotEL.ProductUsed = ItemUsed.SelectedItem.ToString();
                if (!categotyLevel2.Visible)
                {
                    objProductLotEL.CategoryId = Convert.ToInt32(categotyLevel1.SelectedValue);
                }
                else
                {
                    if (categotyLevel3.Visible)
                    {
                        objProductLotEL.CategoryId = Convert.ToInt32(categotyLevel3.SelectedValue);
                    }
                    else
                        objProductLotEL.CategoryId = Convert.ToInt32(categotyLevel2.SelectedValue);
                }
                objProductLotEL.AuctionId = Convert.ToInt32(auction.SelectedValue);
                objProductLotEL.IsBranded = rdbYes.Checked;
                objProductLotEL.Title = txtTitle.Text;
                objProductLotEL.SKU = txtSKU.Text;
                objProductLotEL.Description = txtDesc.Text;
                objProductLotEL.Question = txtQuestion.Text;
                objProductLotEL.Quantity = Convert.ToInt32(txtQuantity.Text);
                objProductLotEL.CostBasis = txtCost.Text;
                objProductLotEL.RetailPrice = txtRetail.Text;
                objProductLotEL.BuyPrice = txtBuy.Text;
                objProductLotEL.StartingBid = txtStartBid.Text;
                objProductLotEL.ShipCountry = ddlCountry.Text;
                objProductLotEL.ShipWithin = ddlShipWithin.Text;
                objProductLotEL.DeliveryTime = ddlTimeTake.Text;
                objProductLotEL.IsFreeShipping = chkFreeShipping.Checked;
                objProductLotEL.ShippingPrice = ddlPrice.Text;
                objProductLotEL.IsShippedEverywhere = chkShip.Checked;
                objProductLotEL.LowEstimatePrice = lowEstimatePrice.Text;
                objProductLotEL.HighEstimatePrice = highEstimatePrice.Text;
                objProductLotEL.LiveAuctionPassed = "0";
                objProductLotEL.images = productimages;
                if (objProductLotBL.Save(objProductLotEL, out Responsetxt))
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