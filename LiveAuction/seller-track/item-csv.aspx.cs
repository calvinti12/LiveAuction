using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BusinessLogicLayer;
using EntityLayer;


namespace LiveAuction.seller_track
{
    public partial class item_csv : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Upload(object sender, EventArgs e)
        {
            //Upload and save the file
            string filename = DateTime.Now.ToString("yyyy_MM_ddTHHmmss") + "_" + Path.GetFileName(FileUpload1.FileName);
            string csvPath = Server.MapPath("~/fileupload/CSV/") + filename;
            Response.Write(Server.MapPath(FileUpload1.FileName));
            FileUpload1.SaveAs(csvPath);

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[27] { 
            new DataColumn("LotDesc", typeof(string)),
            new DataColumn("CategoryId", typeof(string)),
            new DataColumn("RangeStart", typeof(string)),
            new DataColumn("RangeEnd", typeof(string)),
            new DataColumn("Currency", typeof(string)),
            new DataColumn("CreatedOn", typeof(string)),
            new DataColumn("CreatedBy", typeof(string)),
            new DataColumn("UpdatedOn", typeof(string)),
            new DataColumn("UpdatedBy", typeof(string)),
            new DataColumn("IsProductUsed", typeof(string)),           
            new DataColumn("AuctionId",typeof(string)),
            new DataColumn("IsBranded", typeof(string)),
            new DataColumn("Title", typeof(string)),
            new DataColumn("SKU", typeof(string)),
            new DataColumn("CheckoutQuestion", typeof(string)),
            new DataColumn("Quantity", typeof(string)),
            new DataColumn("CostBasis", typeof(string)),
            new DataColumn("RetailPrice", typeof(string)),
            new DataColumn("BuynowPrice", typeof(string)),
            new DataColumn("StartingBid", typeof(string)),
            new DataColumn("ShipFrom", typeof(string)),
            new DataColumn("ShipWithin", typeof(string)),
            new DataColumn("DeliveryTakes", typeof(string)),
            new DataColumn("IsFreeShipping", typeof(string)),
            new DataColumn("ShippingPrice", typeof(string)),
            new DataColumn("IsShippingEveryWhere", typeof(string)),            
            new DataColumn("IsScheduled", typeof(string))
            });


            string csvData = File.ReadAllText(csvPath);
            foreach (string row in csvData.Split('\n'))
            {
                if (!string.IsNullOrEmpty(row))
                {
                    dt.Rows.Add();
                    int i = 0;
                    foreach (string cell in row.Split(','))
                    {
                        dt.Rows[dt.Rows.Count - 1][i] = cell;
                        i++;
                    }
                }
            }

            string connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"]; //ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                //Response.Write(dt.Rows.Count);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //Response.Write(dt.Rows[i]["LotDesc"] + "<br/>");
                    string query =
"INSERT INTO ProductLot(LotDesc,CategoryId,RangeStart,RangeEnd,Currency,CreatedOn,CreatedBy,UpdatedOn,UpdatedBy,IsProductUsed,AuctionId,IsBranded,Title,SKU,CheckoutQuestion,Quantity,CostBasis,RetailPrice,BuynowPrice,StartingBid,ShipFrom,ShipWithin,DeliveryTakes,IsFreeShipping,ShippingPrice,IsShippingEveryWhere,IsScheduled)VALUES('" + dt.Rows[i]["LotDesc"] + "'," + dt.Rows[i]["CategoryId"] + "," + dt.Rows[i]["RangeStart"] + "," + dt.Rows[i]["RangeEnd"] + ",'" + dt.Rows[i]["Currency"] + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',1," + dt.Rows[i]["UpdatedOn"] + "," + dt.Rows[i]["UpdatedBy"] + ",'" + dt.Rows[i]["IsProductUsed"] + "'," + dt.Rows[i]["AuctionId"] + "," + dt.Rows[i]["IsBranded"] + ",'" + dt.Rows[i]["Title"] + "','" + dt.Rows[i]["SKU"] + "','" + dt.Rows[i]["CheckoutQuestion"] + "'," + dt.Rows[i]["Quantity"] + ",'" + dt.Rows[i]["CostBasis"] + "','" + dt.Rows[i]["RetailPrice"] + "','" + dt.Rows[i]["BuynowPrice"] + "','" + dt.Rows[i]["StartingBid"] + "','" + dt.Rows[i]["ShipFrom"] + "','" + dt.Rows[i]["ShipWithin"] + "','" + dt.Rows[i]["DeliveryTakes"] + "'," + dt.Rows[i]["IsFreeShipping"] + ",'" + dt.Rows[i]["ShippingPrice"] + "'," + dt.Rows[i]["IsShippingEveryWhere"] + "," + dt.Rows[i]["IsScheduled"] + ")";
                    //"INSERT INTO ProductLot (LotDesc,CategoryId,CreatedOn,CreatedBy,IsProductUsed,AuctionId,IsBranded,Title,SKU,CheckoutQuestion,Quantity,CostBasis,RetailPrice,BuynowPrice,StartingBid,ShipFrom,ShipWithin,DeliveryTakes,IsFreeShipping,ShippingPrice,IsShippingEveryWhere,IsScheduled) VALUES('" + dt.Rows[i]["LotDesc"] + "'," + dt.Rows[i]["CategoryId"] + ",'" + DateTime.Now.Date.ToString("yyyy-MM-dd HH:mm:ss") + "',1,'" + dt.Rows[i]["IsProductUsed"] + "'," + dt.Rows[i]["AuctionId"] + "," + dt.Rows[i]["IsBranded"] + ",'" + dt.Rows[i]["Title"] + "'," + dt.Rows[i]["SKU"] + ",'" + dt.Rows[i]["CheckoutQuestion"] + "'," + dt.Rows[i]["Quantity"] + "," + dt.Rows[i]["CostBasis"] + "," + dt.Rows[i]["RetailPrice"] + "," + dt.Rows[i]["BuyNowPrice"] + "," + dt.Rows[i]["StartingBid"] + "," + dt.Rows[i]["StartingBid"] + ",'" + dt.Rows[i]["ShipFrom"] + "'," + dt.Rows[i]["ShipCountry"] + ",'" + dt.Rows[i]["ShipWithin"] + "','" + dt.Rows[i]["DeliveryTime"] + "','" + dt.Rows[i]["IsFreeShipping"] + "','" + dt.Rows[i]["ShippingPrice"] + "'," + dt.Rows[i]["IsShippedEverywhere"] + dt.Rows[i]["IsScheduled"] + ")";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataTable dt1 = new DataTable();
                    adapter.Fill(dt1);
                    con.Close();
                    //if (i > 0)
                    //{
                    //txtAuctionName.Text = "";
                    //auctiontime.Text = "";
                    //auctiondate.Text = "";
                    //number.Text = "";
                    //fileUploadLabel.Text = "";
                    //address.Text = "";
                    //schedulingfee.Text = "";
                    //lblMessage.Text = "<span style=\"color: #54a75c\">Auction saved successfully</span>";
                    //}
                }

            }
            //ProductLotBL objProductLotBL = new ProductLotBL();
            //ProductLotEL objProductLotEL = new ProductLotEL();
            //string Responsetxt = string.Empty;
            //string productimages = Request["hdnimagefiles"];
            //objProductLotEL.ProductUsed = ItemUsed.SelectedItem.ToString();
            //if (!categotyLevel2.Visible)
            //{
            //    objProductLotEL.CategoryId = Convert.ToInt32(categotyLevel1.SelectedValue);
            //}
            //else
            //{
            //    if (categotyLevel3.Visible)
            //    {
            //        objProductLotEL.CategoryId = Convert.ToInt32(categotyLevel3.SelectedValue);
            //    }
            //    else
            //        objProductLotEL.CategoryId = Convert.ToInt32(categotyLevel2.SelectedValue);
            //}
            //objProductLotEL.AuctionId = Convert.ToInt32(auction.SelectedValue);
            //objProductLotEL.IsBranded = rdbYes.Checked;
            //objProductLotEL.Title = txtTitle.Text;
            //objProductLotEL.SKU = txtSKU.Text;
            //objProductLotEL.Description = txtDesc.Text;
            //objProductLotEL.Question = txtQuestion.Text;
            //objProductLotEL.Quantity = Convert.ToInt32(txtQuantity.Text);
            //objProductLotEL.CostBasis = txtCost.Text;
            //objProductLotEL.RetailPrice = txtRetail.Text;
            //objProductLotEL.BuyPrice = txtBuy.Text;
            //objProductLotEL.StartingBid = txtStartBid.Text;
            //objProductLotEL.ShipCountry = ddlCountry.Text;
            //objProductLotEL.ShipWithin = ddlShipWithin.Text;
            //objProductLotEL.DeliveryTime = ddlTimeTake.Text;
            //objProductLotEL.IsFreeShipping = chkFreeShipping.Checked;
            //objProductLotEL.ShippingPrice = ddlPrice.Text;
            //objProductLotEL.IsShippedEverywhere = chkShip.Checked;
            //objProductLotEL.images = productimages;
            //if (objProductLotBL.Save(objProductLotEL, out Responsetxt))
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ScriptRegistration", "alert('" + Responsetxt + "');", true);
            //}
            //else
            //{

            //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ScriptRegistration", "alert('" + Responsetxt + "');", true);
            //}

            //string consString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            //using (SqlConnection con = new SqlConnection(consString))
            //{
            //    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
            //    {
            //        //Set the database table name
            //        sqlBulkCopy.DestinationTableName = "dbo.Customers";
            //        con.Open();
            //        sqlBulkCopy.WriteToServer(dt);
            //        con.Close();
            //    }
            //}

            //INSERT INTO ProductLot (LotDesc,CategoryId,CreatedOn,CreatedBy,IsProductUsed,AuctionId,IsBranded,Title,SKU,CheckoutQuestion
            //,Quantity,CostBasis,RetailPrice,BuynowPrice,StartingBid,ShipFrom,ShipWithin,DeliveryTakes,IsFreeShipping,ShippingPrice,IsShippingEveryWhere) 
            //        VALUES(@Description,@CategoryId, getdate(),1,@ProductUsed,@AuctionId,@IsBranded,@Title,@SKU,@Question,
            //        @Quantity,@CostBasis,@RetailPrice,@BuyPrice,@StartingBid,@ShipCountry,@ShipWithin,@DeliveryTime,@IsFreeShipping,@ShippingPrice,@IsShippedEverywhere) 
        }

    }
}