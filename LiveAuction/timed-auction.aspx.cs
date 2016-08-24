using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace LiveAuction
{
    public partial class timed_auction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder html = new StringBuilder();
            StringBuilder htmlLive = new StringBuilder();
            StringBuilder todaysDealStringBuilder = new StringBuilder();
            StringBuilder modalWindowHtml = new StringBuilder();
            string connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"]; //ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "select * from TimedAuction";
            string todaysDealQuery = "select DealId,DealDesc,Title,OriginalPrice,DealPrice,DealDate,DealTime,ImageName from View_list_deals where IsDealPassed=1";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            SqlDataAdapter adapterDeal = new SqlDataAdapter(todaysDealQuery, con);
            DataTable dtTodaysDeal = new DataTable();
            adapterDeal.Fill(dtTodaysDeal);
            con.Close();
            string modalHtml = "";
            string autionData = "";
            string dealData = "";
            string litLiveAuction = "<script type='text/javascript'>$(function () {" +
                                "var austDay = new Date();" +
                                "austDay = new Date('2016-07-07T12:00:00');" +
                                "$('#counterDiv').countdown({ until: austDay, compact: true," +
                                    "format: 'DHMS', description: ''" +
                                "});" +
                            "});" +
                            "function liftOff() { " +
                                " alert('We have lift off!');" +
                                "}" +
                        "</script>";
            string litUpcomingAuction = "<script type='text/javascript'>$(function () {" +
                               "var austDay = new Date();" +
                               "austDay = new Date('2016-07-07T12:00:00');" +
                               "$('#counterDiv').countdown({ until: austDay, compact: true," +
                                   "format: 'DHMS', description: ''" +
                               "});" +
                           "});" +
                           "function liftOff() { " +
                               " alert('We have lift off!');" +
                               "}" +
                       "</script>";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var today = DateTime.Now;
                var auctionDate = Convert.ToDateTime(dt.Rows[i]["AuctionDate"]).Date.ToString("yyyy-MM-dd");
                var auctionTime = Convert.ToDateTime(dt.Rows[i]["AuctionTime"]).TimeOfDay;
                var dateDiff = Convert.ToDateTime(dt.Rows[i]["AuctionDate"]) - today;
                if (today < Convert.ToDateTime(dt.Rows[i]["AuctionDate"]))
                {
                    litUpcomingAuction = litUpcomingAuction + @"<div class='col-md-3 col-sm-6 col-xs-12'>
                            <div class='action-item-sec text-center'><input type='hidden' class='auctionId' value=" + i +
                                        "><img src='Admin/FileUpload/timedauction/" + dt.Rows[i]["ImageName"] + "' width='200px' alt='" + dt.Rows[i]["AuctionName"] + " image" + "'/><p>" +
                                                dt.Rows[i]["AuctionName"] + "</p><a href='timed-auction-lots.aspx' class='btn btn-danger btn-block bidding-sing-btn todaysAction'>Bid</a><div class='action-timing-sec'><p id='counterDiv" + i + "'>";
                    // Response.Write(auctionDate +" ");
                    litUpcomingAuction = litUpcomingAuction + @"<script type='text/javascript'>
                            $(function () {

                                var austDay = new Date();
                                austDay = new Date('" + auctionDate + "T" + auctionTime + "');$('#counterDiv" + i + "').countdown({ until: austDay, onExpiry:liftOff , compact: true,format: 'DHMS', description: ''});$('#modalCounterDiv" + i + "').countdown({ until: austDay, compact: true,format: 'DHMS', description: ''});}); </script>";
                    //lit = lit + Convert.ToDateTime(dt.Rows[i]["AuctionDate"]).Date.ToString("d");
                    litUpcomingAuction = litUpcomingAuction + @"</p></div></div></div>";

                    autionData += "<script type='text/javascript'>var data = { 'auctionName':'" + dt.Rows[i]["AuctionName"] + "'," +
                                  "'auctionDate': '" + dt.Rows[i]["AuctionDate"] + "'," +
                                  "'auctionTime':'" + dt.Rows[i]["AuctionTime"] + "'," +
                                  "'id':'" + i + "'," +
                                  "'auctionImageName':'" + dt.Rows[i]["ImageName"] + "'};todayDeal.push(data);</script>";
                }
            }
            if (dt.Rows.Count == 0)
            {
                litUpcomingAuction += "<h1>No Timed auction available</h1>";
            }
            html.Append(litLiveAuction);
            htmlLive.Append(litUpcomingAuction);
            modalWindowHtml.Append(modalHtml);
            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
            //PlaceHolder2.Controls.Add(new Literal { Text = modalWindowHtml.ToString() });
            UpcomingAuctionPlaceHolder.Controls.Add(new Literal { Text = htmlLive.ToString() });
            todaysDealStringBuilder.Append(dealData);
            //TodaysDealPlaceholder.Controls.Add(new Literal { Text = todaysDealStringBuilder.ToString() });
        }
    }
}