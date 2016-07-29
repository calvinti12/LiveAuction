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
using System.Data.OleDb;
using System.Collections;


namespace LiveAuction.seller_track
{
    public partial class item_csv : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopulateAuction();
            }
        }
        #region Populate Auction
        private void PopulateAuction()
        {
            ProductLotBL objProductLotBL = new ProductLotBL();
            DataTable dtAuction = objProductLotBL.GetAuction(Convert.ToString(Session["UserType"]), Convert.ToInt32(Session["UserId"]));
            auction.DataSource = dtAuction;
            auction.DataTextField = "AuctionName";
            auction.DataValueField = "AuctionId";
            auction.DataBind();
        }
        #endregion
        protected void Upload(object sender, EventArgs e)
        {
            #region UpLoadCSV
            //Upload and save the file
            if (CSVFileUpload.HasFile)
            {
                string filename = DateTime.Now.ToString("yyyy_MM_ddTHHmmss") + "_" + Path.GetFileName(CSVFileUpload.FileName);
                string csvPath = Server.MapPath("~/fileupload/CSV/") + filename;
                CSVFileUpload.SaveAs(csvPath);

                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[5] {
            new DataColumn("Number", typeof(string)),
            new DataColumn("LotDesc", typeof(string)),
            new DataColumn("LowEstimatePrice", typeof(string)),
            new DataColumn("HighEstimatePrice", typeof(string)),
            new DataColumn("SaleSection", typeof(string))
            });
                string csvData = File.ReadAllText(csvPath);
                foreach (string row in csvData.Split('\n'))
                {
                    try
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
                    catch (Exception)
                    {
                        Response.Write("<script type='text/javascript'>alert('There might be a problem in uploading the file.Please try again !');</script>");
                    }
                }
                /*--------- proc call ---------- */
                ProductLotBL objProductLotBL = new ProductLotBL();
                ProductLotEL objProductLotEL = new ProductLotEL();
                string Responsetxt = string.Empty;
                string productimages = Request["hdnimagefiles"];
                ArrayList images = new ArrayList();
                foreach (string image in productimages.Split(','))
                {
                    images.Add(image);
                }
                Response.Write(images.Count);
                /*--------- proc call end -------*/
                string connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"];
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    try
                    {
                        for (int i = 1; i < dt.Rows.Count; i++)
                        {
                            var category = Convert.ToString(dt.Rows[i]["SaleSection"]).Trim();
                            string CategoryQuery = "select * from ProductCategory where CategoryName like '" + category + "'";
                            SqlDataAdapter adapter = new SqlDataAdapter(CategoryQuery, con);
                            DataTable dtCategory = new DataTable();
                            adapter.Fill(dtCategory);
                            objProductLotEL.ProductUsed = "";
                            objProductLotEL.CategoryId = Convert.ToInt32(dtCategory.Rows[0]["CategoryId"]);
                            objProductLotEL.AuctionId = Convert.ToInt32(auction.SelectedValue);
                            objProductLotEL.IsBranded = true;
                            objProductLotEL.Title = "";
                            objProductLotEL.SKU = "";
                            objProductLotEL.Description = Convert.ToString(dt.Rows[i]["LotDesc"]);
                            objProductLotEL.Question = "";
                            objProductLotEL.Quantity = 1;
                            objProductLotEL.CostBasis = "";
                            objProductLotEL.RetailPrice = "";
                            objProductLotEL.BuyPrice = "";
                            objProductLotEL.StartingBid = "";
                            objProductLotEL.ShipCountry = "";
                            objProductLotEL.ShipWithin = "";
                            objProductLotEL.DeliveryTime = "";
                            objProductLotEL.IsFreeShipping = true;
                            objProductLotEL.ShippingPrice = "";
                            objProductLotEL.IsShippedEverywhere = true;
                            objProductLotEL.IsScheduled = true;
                            objProductLotEL.images = Convert.ToString(images[i-1]);
                            objProductLotEL.LowEstimatePrice = Convert.ToString(dt.Rows[i]["LowEstimatePrice"]);
                            objProductLotEL.HighEstimatePrice = Convert.ToString(dt.Rows[i]["HighEstimatePrice"]);
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
                    catch (Exception)
                    {
                        Response.Write("<script type='text/javascript'>alert('There might be a problem in uploading the file.Please try again !');</script>");
                    }
                }
            }
#endregion
        }
    }
}