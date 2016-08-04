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
        public static string currentLotNo = "";
        //public static string userName = Convert.ToString(HttpContext.Current.Session["UserName"]).Trim();
        //public static string adminName = Convert.ToString(HttpContext.Current.Session["AdminUserName"]).Trim();
        public static string userName;
        public static string adminName;
        protected void Page_Load(object sender, EventArgs e)
        {
            userName = Convert.ToString(HttpContext.Current.Session["UserName"]).Trim();
            adminName = Convert.ToString(HttpContext.Current.Session["AdminUserName"]).Trim();
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
            currentLotNo = Convert.ToString(dt1.Rows[0]["LotId"]);
            currentLit += @"<div class='col-md-6 col-sm-6 col-xs-12'>
							<div class='category-sell-item-full-sec'>
								<div class='category-sell-pic'>
									<img src='/fileupload/upload/" + dt1.Rows[0]["LotImageName"] + "' alt='this is for selling item images' class='img-responsive' />";
            currentLit += @"</div>
								<div class='category-sell-pic-caption text-center'>
									<h1>current lot <span class='currentLotClass'>" + dt1.Rows[0]["LotId"] + "</span></h1>";
            currentLit += @"</div>
							</div>
							<div class='category-sell-item-des-sec'>
								<h3 class='text-primary'>Auction : " + dt1.Rows[0]["AuctionName"] + "</h3>";
            currentLit += @"<p>" + dt1.Rows[0]["LotDesc"] + "</p>";
            currentLit += @"<p>Low estimate price&nbsp-&nbsp" + dt1.Rows[0]["LowEstimatePrice"] + "£</p>";
            currentLit += @"<p>High estimate price&nbsp-&nbsp" + dt1.Rows[0]["HighEstimatePrice"] + "£</p>";
            currentLit += @"</div>
						</div>";
            var lowEstimatePrice = Convert.ToInt32(dt1.Rows[0]["LowEstimatePrice"]);

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
            for (int i = 1; i < dt.Rows.Count - 1; i++)
            {
                lit = @"<div class='cat-sell-single-item clearfix'>
							<div class='cat-sell-title'>
								<p><span class='text-primary'><span>Lot&nbsp</span>" + dt.Rows[i]["LotId"] + "</span></p>";
                lit += @"</div>
							<div class='cat-sell-tag'>
								<h3>" + dt.Rows[i]["Title"] + "</h3>";
                lit += @"</div>
							<div class='cat-sell-pic-sec'>
								<div class='cat-sell-snt'>
									<img src='/fileupload/upload/" + dt.Rows[i]["LotImageName"] + "' alt='this is for cat sell snt' class='img-responsive'>";
                lit += @"</div>
								<div class='cat-sell-snt'>
									<a href='bid-detail.aspx?id=" + dt.Rows[i]["LotId"] + "&cat=auction' class='text-info'>View More</a>";
                lit += @"</div>
							</div>
						</div>";
                html.Append(lit);
            }
            PlaceHolderQueueLot.Controls.Add(new Literal { Text = html.ToString() });
            StringBuilder bidBtnHtml = new StringBuilder();
            var bidBtn = "";

            if (userName != null && userName != "")
            {
                bidBtn += @"<a href='#' class='bidBtn'><h1 class='bg-primary'>Bid</h1></a>";
            }
            else if (adminName != null && adminName != "")
            {
                bidBtn += @"<a href='#' class='bidBtn'><h1 class='bg-primary'>Bid</h1></a>";
            }
            else
            {
                bidBtn += @"<a href='#' class='bidBtn' data-toggle='modal' data-target='#loginmodal'><h1 class='bg-primary'>Sign in to Bid</h1></a>";
            }
            bidBtnHtml.Append(bidBtn);
            PlaceHolderBidButton.Controls.Add(new Literal { Text = bidBtnHtml.ToString() });
        }
        #region Log file add
        public static void AddtoLogFile(string Message, string WebPage, string fileName)
        {
            string LogPath = HttpContext.Current.Server.MapPath(@"~\Admin\log_files\").ToString();
            //string LogPath = ConfigurationManager.AppSettings["LogPath"].ToString();
            //string filename = "Log_" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";
            string filename = "Log_" + fileName + ".txt";
            string filepath = LogPath + filename;
            if (File.Exists(filepath))
            {
                using (StreamWriter writer = new StreamWriter(filepath, true))
                {
                    //writer.WriteLine("-------------------START-------------" + DateTime.Now);
                    //writer.WriteLine("Source :" + ErrorPage);
                    //writer.WriteLine(Message);
                    //writer.WriteLine("-------------------END-------------" + DateTime.Now);
                    writer.WriteLine("-----------------------------------------------------------");
                    writer.WriteLine(Message + " at " + DateTime.Now);
                }
                //WriteToDatabase(filename.ToString(),filepath);
            }
            else
            {
                StreamWriter writer = File.CreateText(filepath);
                //writer.WriteLine("-------------------START-------------" + DateTime.Now);
                //writer.WriteLine("Source :" + ErrorPage);
                //writer.WriteLine(Message);
                //writer.WriteLine("-------------------END-------------" + DateTime.Now);
                writer.WriteLine("-----------------------------------------------------------");
                writer.WriteLine(Message + " at " + DateTime.Now);
                writer.Close();
                WriteToDatabase(filename.ToString(), filepath);
            }

        }
        public static void WriteToDatabase(string filename, string filepath)
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
        #region Calling Web Method
        [System.Web.Services.WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public static string WriteToLog()
        {
            userName = Convert.ToString(HttpContext.Current.Session["UserName"]).Trim();
            adminName = Convert.ToString(HttpContext.Current.Session["AdminUserName"]).Trim();
            if (userName != null && userName != "")
            {
                AddtoLogFile(userName + " added the bid", "sampleWebsite", "lotNo_" + currentLotNo);
            }
            if (adminName != null && adminName != "")
            {
                AddtoLogFile("admin added the bid", "sampleWebsite", "lotNo_" + currentLotNo);
            }
            return "Your bid has been made ";
        }
        #endregion
    }
}