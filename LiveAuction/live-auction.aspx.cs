using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;

namespace LiveAuction
{
    public partial class live_auction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var userName = Convert.ToString(Session["UserName"]).Trim();
            var adminName=Convert.ToString(Session["AdminUserName"]).Trim();
            if (userName != null && userName != "")
            {
                AddtoLogFile(userName + " added the bid", "sampleWebsite");
            }
            if (adminName != null && adminName != "")
            {
                AddtoLogFile(adminName + " added the bid", "sampleWebsite");
            }
            //Response.Write("User : " + Convert.ToString(Session["AdminUserName"]) + "<br/>user id : " + Session["UserId"] + "<br/>User name : " + Session["UserName"]);
            StringBuilder html = new StringBuilder();
            StringBuilder currentHtml = new StringBuilder();
            StringBuilder askingBidHtml = new StringBuilder();
            string connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"]; //ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "select * from [AuctionBidPlatform].[dbo].[View_list_item]";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            string currentLotQuery = "select top 1 * from [AuctionBidPlatform].[dbo].[View_list_item]";
            SqlDataAdapter adapter1 = new SqlDataAdapter(currentLotQuery, con);
            DataTable dt1 = new DataTable();
            adapter1.Fill(dt1);
            con.Close();
            string lit = "";
            string currentLit = "";
            string askingBid = "";
            currentLit += @"<div class='col-md-6 col-sm-6 col-xs-12'>
							<div class='category-sell-item-full-sec'>
								<div class='category-sell-pic'>
									<img src='/fileupload/upload/" + dt1.Rows[0]["LotImageName"] + "' alt='this is for selling item images' class='img-responsive' />";
            currentLit += @"</div>
								<div class='category-sell-pic-caption text-center'>
									<h1>current lot " + dt1.Rows[0]["LotId"] + "</h1>";
            currentLit += @"</div>
							</div>
							<div class='category-sell-item-des-sec'>
								<h3 class='text-primary'>Auction : " + dt1.Rows[0]["AuctionName"] + "</h3>";
            currentLit += @"<p>" + dt1.Rows[0]["LotDesc"] + "</p>";
            currentLit += @"<p>Low estimate price&nbsp-&nbsp" + dt1.Rows[0]["LowEstimatePrice"] + "£</p>";
            currentLit += @"<p>High estimate price&nbsp-&nbsp" + dt1.Rows[0]["HighEstimatePrice"] + "£</p>";
            currentLit += @"</div>
						</div>";
            var lowEstimatePrice=Convert.ToInt32(dt1.Rows[0]["LowEstimatePrice"]);
            var askingBidPrice = 0;
            if (lowEstimatePrice >= 0 && lowEstimatePrice <= 200) { askingBidPrice = 5; }
            if (lowEstimatePrice >= 101 && lowEstimatePrice <= 500) { askingBidPrice = 10; }
            if (lowEstimatePrice >= 501 && lowEstimatePrice <= 1000) { askingBidPrice = 50; }
            if (lowEstimatePrice >= 501 && lowEstimatePrice <= 1000) { askingBidPrice = 50; }
            if (lowEstimatePrice >= 1001 && lowEstimatePrice <= 3000) { askingBidPrice = 150; }
            if (lowEstimatePrice >= 3001 && lowEstimatePrice <= 10000) { askingBidPrice = 500; }
            askingBid += @"<h1 class='text-danger'>£ <span>" + askingBidPrice + "</span></h1>";
            askingBidHtml.Append(askingBid);
            PlaceHolderAskingBid.Controls.Add(new Literal { Text = askingBidHtml.ToString() });
            currentHtml.Append(currentLit);
            PlaceHolderCurrentLot.Controls.Add(new Literal { Text = currentHtml.ToString() });
            for (int i = 1; i < dt.Rows.Count-1; i++)
            {
                lit = @"<div class='cat-sell-single-item clearfix'>
							<div class='cat-sell-title'>
								<p><span class='text-primary'><span>Lot&nbsp</span>" + dt.Rows[i]["LotId"] + "</span></p>";
                lit += @"</div>
							<div class='cat-sell-tag'>
								<h3>"+dt.Rows[i]["Title"]+"</h3>";
                lit += @"</div>
							<div class='cat-sell-pic-sec'>
								<div class='cat-sell-snt'>
									<img src='/fileupload/upload/"+dt.Rows[i]["LotImageName"]+"' alt='this is for cat sell snt' class='img-responsive'>";
                lit += @"</div>
								<div class='cat-sell-snt'>
									<a href='bid-detail.aspx?id=" + dt.Rows[i]["LotId"] + "&cat=auction' class='text-info'>View More</a>";
                lit += @"</div>
							</div>
						</div>";
                html.Append(lit);
            }
            PlaceHolderQueueLot.Controls.Add(new Literal { Text = html.ToString() });
        }
        #region Log file add
        public void AddtoLogFile(string Message, string WebPage)
        {
            string LogPath = Server.MapPath(@"~\Admin\log_files\").ToString();
            //string LogPath = ConfigurationManager.AppSettings["LogPath"].ToString();
            string filename = "Log_" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";
            string filepath = LogPath + filename;
            if (File.Exists(filepath))
            {
                using (StreamWriter writer = new StreamWriter(filepath, true))
                {
                    writer.WriteLine("-------------------START-------------" + DateTime.Now);
                    writer.WriteLine("Source :" + ErrorPage);
                    writer.WriteLine(Message);
                    writer.WriteLine("-------------------END-------------" + DateTime.Now);
                }
                //WriteToDatabase(filename.ToString(),filepath);
            }
            else
            {
                StreamWriter writer = File.CreateText(filepath);
                writer.WriteLine("-------------------START-------------" + DateTime.Now);
                writer.WriteLine("Source :" + ErrorPage);
                writer.WriteLine(Message);
                writer.WriteLine("-------------------END-------------" + DateTime.Now);
                writer.Close();
                WriteToDatabase(filename.ToString(), filepath);
            }
            
        }

        private void WriteToDatabase(string filename,string filepath)
        {
            string connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"]; //ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "INSERT INTO [AuctionBidPlatform].[dbo].[LiveAuctionLogs]([FileName],[CreatedOn],[FilePath])VALUES('" + filename + "'," + DateTime.Now.ToString("yyyy-MM-dd") + ",'" + filepath + "')";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
        }
        #endregion
    }
}