using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicLayer;
using System.IO;

namespace LiveAuction
{
    public partial class catalogue : System.Web.UI.Page
    {
        public static string strRelProduct = string.Empty;

        public static string strHeading = string.Empty;
        AuctionBL objAuctionBL = new AuctionBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["aid"] != null)
                {
                    populateData();
                }
            }
        }

        protected void populateData()
        {
            strRelProduct = "";
            strHeading = "";
            
            int AuctionId = Convert.ToInt32(Request.QueryString["aid"]);
            DataSet ds = objAuctionBL.GetLotListByAuctionID(AuctionId);
            DataTable dt = ds.Tables[0];
            DataTable dt1 = ds.Tables[1];
            if (dt != null && dt1 != null)
            {
                strHeading = Convert.ToString(dt1.Rows[0]["AuctionName"]) + " - " + Convert.ToString(dt.Rows.Count);
            }
            else
            {
                strHeading = "Lot Lists";
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                Cache["ProductLotExcel"] = dt;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows.Count > 0)
                    {
                        strRelProduct = strRelProduct + "<li>";
                    }
                    else if (i == dt.Rows.Count - 1)
                    {
                        strRelProduct = strRelProduct + "<li class=\"noBg\">";
                    }
                    else
                    {
                        strRelProduct = strRelProduct + "<li>";
                    }
                    //strRelProduct = strRelProduct + "<div class=\"imgarea\"><img src=\"" + "../writereaddata/Painting/Thumbnail/" + Convert.ToString(dt.Rows[i]["ImageURL"]) + "\" alt=\"\"></div>";
                    strRelProduct = strRelProduct + "<table><tr><td  class=\"imgarea\" valign=\"middle\" align=\"center\">" + "<a href=\"ItemDetail.aspx?LotId=" + Convert.ToString(dt.Rows[i]["LotId"]) + "\"><img src=\"" + "fileupload/upload/" + Convert.ToString(dt.Rows[i]["DefaultImage"]) + "\" alt=\"\"> </a></td>";
                    //strRelProduct = strRelProduct + "<p class=\"relcontent\"><b style=\"color:black!important;\">" + Convert.ToString(dt.Rows[i]["Name"]) + "</b></p>";
                    strRelProduct = strRelProduct + "<td style=\"padding-left:10px;vertical-align: top;\"><p class=\"relcontent\">" + "<a href=\"ItemDetail.aspx?LotId=" + dt.Rows[i]["LotId"].ToString() + "\">" + "<b style=\"color:black!important;\"> Lot Id : " + Convert.ToString(dt.Rows[i]["LotId"]) + "</b></a></p>";
                    //------Product Code---------------
                    strRelProduct = strRelProduct + "<p class=\"relcontent\">" + "<b style=\"color:black!important;\">" + "Ends On : " + Convert.ToString(dt.Rows[i]["AuctionDate"]) + " " + Convert.ToString(dt.Rows[i]["AuctionTime"]) + "</b></p>";


                    strRelProduct = strRelProduct + "<p class=\"relcontent\">" + Convert.ToString(dt.Rows[i]["LotDesc"]) + "</p>";

                    //strRelProduct = strRelProduct + " <span class=\"dollartxt\">INR " + Convert.ToString(dt.Rows[i]["Price"]) + " </span><a href=\"ProductDetail.aspx?Cat=y&PaintingId=" + dt.Rows[i]["Id"].ToString() + "\" class=\"viewmorebtn\">View</a>";
                    strRelProduct = strRelProduct + " </td><td><span class=\"dollartxt\"><span class=\"WebRupee\">Current Bid: £</span> " + Convert.ToString(dt.Rows[i]["StartingBid"]) + "</span></td></tr></table>";
                    strRelProduct = strRelProduct + "</li>";

                }

            }
           
            else
            {
                lblMsg.Text = "No Records Found.";
            }


        }


        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable myTable = new DataTable();

                //myTable.Columns.Add("OrderId", typeof(int));
                myTable.Columns.Add("LotId", typeof(string));
                myTable.Columns.Add("LotDesc", typeof(string));
                myTable.Columns.Add("AuctionDate", typeof(string));
                myTable.Columns.Add("AuctionTime", typeof(string));
                myTable.Columns.Add("StartingBid", typeof(string));
                myTable.Columns.Add("DefaultImage", typeof(string));



                DataTable dt = (Cache["ProductLotExcel"]) as DataTable;
               
                
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        int i = 0;

                        for (i = 0; i < dt.Rows.Count; i++)
                        {
                            DataRow dr = myTable.NewRow();
                            //dr["OrderId"] = Convert.ToInt32(dt.Rows[i]["OrderId"]);
                            dr["LotId"] = Convert.ToString(dt.Rows[i]["LotId"]);
                            dr["LotDesc"] = Convert.ToString(dt.Rows[i]["LotDesc"]);
                            dr["AuctionDate"] = Convert.ToString(dt.Rows[i]["AuctionDate"]);
                            dr["AuctionTime"] = Convert.ToString(dt.Rows[i]["AuctionTime"]);
                            dr["StartingBid"] = Convert.ToString(dt.Rows[i]["StartingBid"]);
                            dr["DefaultImage"] = Convert.ToString(dt.Rows[i]["DefaultImage"]);


                            myTable.Rows.Add(dr);
                        }

                        string format = "ddMMyyyyHHmmss";
                        string CurrMonth = String.Format("{0:MMMM}", DateTime.Now);

                        string ExcelName = DateTime.Now.ToString(format);
                        string FileName = ExcelName.ToString() + ".xls";
                        //string FileName = "VTR.xls";
                        string FileFullPath = Server.MapPath("Excel/" + FileName);

                        DataSet dse = new DataSet("Export");
                        dse.Tables.Add(myTable);

                        ExcelLibrary.DataSetHelper.CreateWorkbook(FileFullPath, dse);

                        Response.ContentType = "application/ms-excel";
                        FileInfo OutFile = new FileInfo(FileFullPath);
                        long filesize = OutFile.Length;
                        Response.AddHeader("Content-Length", filesize.ToString());
                        Response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName.Replace(" ", "_") + "");
                        Response.WriteFile(FileFullPath);
                        Response.Flush();
                        Response.Close();


                    }
                    else
                    {
                        // ltMessage.Text = "No Data Available Currently";
                    }
                }
                else
                {
                    //  ltMessage.Text = "No Data Available Currently";
                }
            }
            catch (Exception ex)
            {// ltMessage.Text = ex.Message.ToString(); }

            }
        }

       
    }
}