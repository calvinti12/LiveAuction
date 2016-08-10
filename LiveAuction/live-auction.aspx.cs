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
        public static int askingBidPrice = 0;
        public static string currentLotId = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            FetchLots();
        }
        #region Fetch lots
        
        public void FetchLots()
        {
            userName = Convert.ToString(HttpContext.Current.Session["UserName"]).Trim();
            adminName = Convert.ToString(HttpContext.Current.Session["AdminUserName"]).Trim();
            StringBuilder html = new StringBuilder();
            StringBuilder currentHtml = new StringBuilder();
            StringBuilder askingBidHtml = new StringBuilder();
            string connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"]; //ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "select * from [AuctionBidPlatform].[dbo].[View_list_item]  where IsSold=0";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            //string delquery = "delete  from dbo.LiveAuctionLogs";
            //SqlDataAdapter deladapter = new SqlDataAdapter(delquery, con);
            //DataTable deldt = new DataTable();
            //deladapter.Fill(deldt);

            string currentLotQuery = "select top 1 * from [AuctionBidPlatform].[dbo].[View_list_item] where IsSold=0";
            SqlDataAdapter adapter1 = new SqlDataAdapter(currentLotQuery, con);
            DataTable dt1 = new DataTable();
            adapter1.Fill(dt1);
            con.Close();
            string lit = "";
            string currentLit = "";
            string askingBid = "";
            if (dt1.Rows.Count > 0)
            {
                currentLotNo = Convert.ToString(dt1.Rows[0]["LotId"]);

                currentLotId = currentLotNo;
                FetchAskingBidValue();
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
                askingBid += @"<h1 class='text-danger'>£ <span id='askingBidPrice'>" + askingBidPrice + "</span></h1>";
                askingBidHtml.Append(askingBid);
                PlaceHolderAskingBid.Controls.Add(new Literal { Text = askingBidHtml.ToString() });
                currentHtml.Append(currentLit);
                PlaceHolderCurrentLot.Controls.Add(new Literal { Text = currentHtml.ToString() });
            }
            else {
                Response.Write("<script type='text/javascript'>alert('No more items left for Live Auction');</script>");
                //Response.Redirect("index.aspx");
            }
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
            //else if (adminName != null && adminName != "")
            //{
            //    bidBtn += @"<a href='#' class='bidBtn'><h1 class='bg-primary'>Bid</h1></a>";
            //}
            else
            {
                bidBtn += @"<a href='#' class='bidBtn' data-toggle='modal' data-target='#loginmodal'><h1 class='bg-primary'>Sign in to Bid</h1></a>";
            }
            bidBtnHtml.Append(bidBtn);
            PlaceHolderBidButton.Controls.Add(new Literal { Text = bidBtnHtml.ToString() });
            
        }
        #endregion
        #region Fetch Lot For AJAX call
        [System.Web.Services.WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public static void FetchCurrentLot()
        {
            live_auction la = new live_auction( );
            //la.FetchLots();
            //Page_Load(null, EventArgs.Empty);
        }
        #endregion
        #region Update Current Lot
        [System.Web.Services.WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public static void UpdateCurrentLot()
        {
            string connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"]; //ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "UPDATE [AuctionBidPlatform].[dbo].[ProductLot] SET LiveAuctionPassed=1 WHERE LotId="+currentLotNo;
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
        }
        #endregion
        #region Add Log File
        public static void AddtoLogFile(string Message, string WebPage, string fileName, int askingBid)
        {
            //string LogPath = HttpContext.Current.Server.MapPath(@"~\TCAG\Admin\log_files\").ToString();
            string LogPath = HttpContext.Current.Server.MapPath(@"~\Admin\log_files\").ToString();
            string filename = "Log_" + fileName + ".txt";
            string filepath = LogPath + filename;
            if (File.Exists(filepath))
            {
                using (StreamWriter writer = new StreamWriter(filepath, true))
                {
                    //writer.WriteLine("---------------------------------------------------------------------");
                    //writer.WriteLine(DateTime.Now.ToString("dd-MM-yyyy HH:MM:ss") + " - " + Message + " at " + askingBidPrice + "£");
                    if (askingBidPrice < 100)
                    {
                        askingBidPrice += 5;
                        writer.WriteLine("---------------------------------------------------------------------");
                        writer.WriteLine(DateTime.Now.ToString("dd-MM-yyyy") + " - " + Message + " at " + " £ " + askingBidPrice);
                        UpdateAskingBid();
                    }
                    if (askingBidPrice >= 100 && askingBidPrice < 300)
                    {
                        askingBidPrice += 10;
                        writer.WriteLine("---------------------------------------------------------------------");
                        writer.WriteLine(DateTime.Now.ToString("dd-MM-yyyy") + " - " + Message + " at " + " £ " + askingBidPrice);
                        UpdateAskingBid();
                    }
                    if (askingBidPrice >= 300 && askingBidPrice < 1000)
                    {
                        askingBidPrice += 20;
                        writer.WriteLine("---------------------------------------------------------------------");
                        writer.WriteLine(DateTime.Now.ToString("dd-MM-yyyy") + " - " + Message + " at " + " £ " + askingBidPrice);
                        UpdateAskingBid();
                    }
                    if (askingBidPrice >= 1000 && askingBidPrice <= 3000)
                    {
                        askingBidPrice += 25;
                        writer.WriteLine("---------------------------------------------------------------------");
                        writer.WriteLine(DateTime.Now.ToString("dd-MM-yyyy") + " - " + Message + " at " + " £ " + askingBidPrice);
                        UpdateAskingBid();
                    }
                }
            }
            else
            {
                StreamWriter writer = File.CreateText(filepath);
                InsertAskingBid();
                // writer.WriteLine(DateTime.Now.ToString("dd-MM-yyyy HH:MM:ss") + " - " + Message + " at " + askingBidPrice + "£");
                if (askingBidPrice < 100)
                {
                    askingBidPrice += 5;
                    writer.WriteLine("---------------------------------------------------------------------");
                    writer.WriteLine(DateTime.Now.ToString("dd-MM-yyyy") + " - " + Message + " at " + " £ " + askingBidPrice);
                    UpdateAskingBid();
                }
                if (askingBidPrice >= 100 && askingBidPrice < 300)
                {
                    askingBidPrice += 10;
                    writer.WriteLine("---------------------------------------------------------------------");
                    writer.WriteLine(DateTime.Now.ToString("dd-MM-yyyy") + " - " + Message + " at " + " £ " + askingBidPrice);
                    UpdateAskingBid();
                }
                if (askingBidPrice >= 300 && askingBidPrice < 1000)
                {
                    askingBidPrice += 20;
                    writer.WriteLine("---------------------------------------------------------------------");
                    writer.WriteLine(DateTime.Now.ToString("dd-MM-yyyy") + " - " + Message + " at " + " £ " + askingBidPrice);
                    UpdateAskingBid();
                }
                if (askingBidPrice >= 1000 && askingBidPrice < 3000)
                {
                    askingBidPrice += 25;
                    writer.WriteLine("---------------------------------------------------------------------");
                    writer.WriteLine(DateTime.Now.ToString("dd-MM-yyyy") + " - " + Message + " at " + " £ " + askingBidPrice);
                    UpdateAskingBid();
                }
                writer.Close();
                //WriteToDatabase(filename.ToString(), filepath);
            }
        }
        #endregion
        #region Update asking Log Bid
        public static void UpdateAskingBid()
        {
            string connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"]; //ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "UPDATE [AuctionBidPlatform].[dbo].[LiveAuctionAskingBids] set BidValue=" + askingBidPrice + " where LotId=" + currentLotId;
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
        }
        #endregion
        #region Insert Asking Bid
        public static void InsertAskingBid() {

            string connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"]; //ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "INSERT INTO [AuctionBidPlatform].[dbo].[LiveAuctionAskingBids]([LotId],[BidValue])VALUES(" + currentLotNo + "," + askingBidPrice + ")";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
        }
        #endregion
        #region Insert Log file details to database
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
        public static void WriteToLog()
        {
            userName = Convert.ToString(HttpContext.Current.Session["UserName"]).Trim();
            adminName = Convert.ToString(HttpContext.Current.Session["AdminUserName"]).Trim();
            if (userName != null && userName != "")
            {
                AddtoLogFile(userName + " added the bid", "sampleWebsite", "lotNo_" + currentLotNo, askingBidPrice);
            }
            if (adminName != null && adminName != "")
            {
                AddtoLogFile("admin added the bid", "sampleWebsite", "lotNo_" + currentLotNo, askingBidPrice);
            }
        }
        #endregion
        #region Getting Asking Bid price value 
        [System.Web.Services.WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public static int  FetchAskingBidValue()
        {
            if (currentLotId != "")
            {
                string connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"]; //ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string query = "SELECT [BidValue] FROM [AuctionBidPlatform].[dbo].[LiveAuctionAskingBids] WHERE [LotId]=" + currentLotId;
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                con.Close();
                int bidVal;
                if (dt.Rows.Count > 0)
                { bidVal = Convert.ToInt32(dt.Rows[0]["BidValue"]); }
                else
                { bidVal = 10; }
                askingBidPrice = Convert.ToInt32(bidVal);
                return bidVal;
            }
            else
                return 0;
            
        }
        #endregion
    }
}