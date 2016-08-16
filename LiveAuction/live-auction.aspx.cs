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
        //-------------- server urls ------------------ AddToLogFile, SoldItem
        //----------------- end -----------------------
        //--------------local urls --------------------
        //----------------- end -----------------------
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
            //FetchAskingBidValue();
            StringBuilder bidBtnHtml = new StringBuilder();

            // PlaceHolderBidButton.Controls.Add(new Literal { Text = bidBtnHtml.ToString() });
        }
        #endregion
        #region FetchCurrentLot
        [System.Web.Services.WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public void FetchCurrentLot()
        {
            //live_auction_admin la = new live_auction_admin();
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
            string query = "UPDATE [AuctionBidPlatform].[dbo].[ProductLot] SET LiveAuctionPassed=1 WHERE LotId=" + currentLotNo;
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
        }
        #endregion
        #region Add Log File
        public static void AddtoLogFile(string Message, string WebPage, string fileName, int askingBid, string id)
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
                    //writer.WriteLine(DateTime.Now.ToString("dd-MM-yyyy") + " - " + Message + " at " + " £ " + askingBidPrice);
                    if (askingBidPrice < 100)
                    {
                        askingBidPrice += 5;
                        writer.WriteLine("---------------------------------------------------------------------");
                        writer.WriteLine(Message + askingBidPrice);
                        UpdateAskingBid(id);
                    }
                    if (askingBidPrice >= 100 && askingBidPrice < 300)
                    {
                        askingBidPrice += 10;
                        writer.WriteLine("---------------------------------------------------------------------");
                        writer.WriteLine(Message + askingBidPrice);
                        UpdateAskingBid(id);
                    }
                    if (askingBidPrice >= 300 && askingBidPrice < 1000)
                    {
                        askingBidPrice += 20;
                        writer.WriteLine("---------------------------------------------------------------------");
                        writer.WriteLine(Message + askingBidPrice);
                        UpdateAskingBid(id);
                    }
                    if (askingBidPrice >= 1000 && askingBidPrice <= 3000)
                    {
                        askingBidPrice += 25;
                        writer.WriteLine("---------------------------------------------------------------------");
                        writer.WriteLine(Message + askingBidPrice);
                        UpdateAskingBid(id);
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
                    writer.WriteLine(Message + askingBidPrice);
                    UpdateAskingBid(id);
                }
                if (askingBidPrice >= 100 && askingBidPrice < 300)
                {
                    askingBidPrice += 10;
                    writer.WriteLine("---------------------------------------------------------------------");
                    writer.WriteLine(Message + askingBidPrice);
                    UpdateAskingBid(id);
                }
                if (askingBidPrice >= 300 && askingBidPrice < 1000)
                {
                    askingBidPrice += 20;
                    writer.WriteLine("---------------------------------------------------------------------");
                    writer.WriteLine(Message + askingBidPrice);
                    UpdateAskingBid(id);
                }
                if (askingBidPrice >= 1000 && askingBidPrice < 3000)
                {
                    askingBidPrice += 25;
                    writer.WriteLine("---------------------------------------------------------------------");
                    writer.WriteLine(Message + askingBidPrice);
                    UpdateAskingBid(id);
                }
                writer.Close();
                //WriteToDatabase(filename.ToString(), filepath);
            }
        }
        #endregion
        #region Update asking Log Bid
        public static void UpdateAskingBid(string id)
        {
            string connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"]; //ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "UPDATE [AuctionBidPlatform].[dbo].[LiveAuctionAskingBids] set BidValue=" + askingBidPrice + ",AskingBidOwner='" + userName + "' where LotId=" + id;
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
        }
        #endregion
        #region Insert Asking Bid
        public static void InsertAskingBid()
        {
            string connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"]; //ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "INSERT INTO [AuctionBidPlatform].[dbo].[LiveAuctionAskingBids]([LotId],[BidValue],[AskingBidOwner])VALUES(" + currentLotNo + "," + askingBidPrice + ",'" + userName + "')";
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
        #region WriteToLog
        [System.Web.Services.WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public static string WriteToLog(string id)
        {
            userName = Convert.ToString(HttpContext.Current.Session["UserName"]).Trim();
            if (userName != null && userName != "")
            {
                //AddtoLogFile(userName + " added the bid", "sampleWebsite", "lotNo_" + id, askingBidPrice, id);
                AddtoLogFile(userName + " placed the bid at £", "sampleWebsite", "lotNo_" + id, askingBidPrice, id);
                return userName + " placed the bid at £" + askingBidPrice;
            }
            else
                return "Please sign in for bid";
        }
        #endregion
        #region FetchAskingBidValue
        [System.Web.Services.WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public static List<LiveAuctionAskingBids> FetchAskingBidValue(string id)
        {
            if (id != "" && id != null)
            {
                LiveAuctionAskingBids lab = new LiveAuctionAskingBids();
                List<LiveAuctionAskingBids> askingBids = new List<LiveAuctionAskingBids>();

                string connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"]; //ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string query = "SELECT [BidValue],[AskingBidOwner] FROM [AuctionBidPlatform].[dbo].[LiveAuctionAskingBids] WHERE [LotId]=" + id;
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                con.Close();
                int bidVal;
                string askingBidOwner = "";
                if (dt.Rows.Count > 0)
                { 
                    bidVal = Convert.ToInt32(dt.Rows[0]["BidValue"]);
                    askingBidOwner = Convert.ToString(dt.Rows[0]["AskingBidOwner"]);
                }
                else
                { bidVal = 10; }
                askingBids.Add(new LiveAuctionAskingBids
                {
                    BidValue = bidVal,
                    AskingBidOwner = askingBidOwner
                });
                askingBidPrice = Convert.ToInt32(bidVal);
                return askingBids;
            }
            else return null;
        }
        #endregion
        #region Sold Item
        [System.Web.Services.WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public static List<ProductLot> SoldItem(string id)
        {
            string query = "UPDATE dbo.ProductLot set IsSold = 1 WHERE LotId=" + id;
            RunDatabaseScript(query);
            string fetchQuery = "select * from [AuctionBidPlatform].[dbo].[View_list_item]  where IsSold=0";
            DataTable dt = RunDatabaseScript(fetchQuery);
            ProductLot productLot = new ProductLot();
            List<ProductLot> lots = new List<ProductLot>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lots.Add(new ProductLot
                {
                    LotId = Convert.ToInt32(dt.Rows[i]["LotId"]),
                    LotImageUrl = "http://127.0.0.1:2520/fileupload/upload/" + dt.Rows[i]["LotImageName"],
                    //LotImageUrl = "http://auctionbidplatform.com/fileupload/upload/" + dt.Rows[i]["LotImageName"],
                    LotDesc = Convert.ToString(dt.Rows[i]["LotDesc"]),
                    Title = Convert.ToString(dt.Rows[i]["Title"]),
                    AuctionName = Convert.ToString(dt.Rows[i]["AuctionName"]),
                    Address = Convert.ToString(dt.Rows[i]["Address"]),
                    LowEstimatePrice = Convert.ToString(dt.Rows[i]["LowEstimatePrice"]),
                    HighEstimatePrice = Convert.ToString(dt.Rows[i]["HighEstimatePrice"])
                });
            }
            return lots;
        }
        #endregion
        #region Fair Warning
        [System.Web.Services.WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public static void FairWarning()
        {
            string query = "UPDATE dbo.ProductLot set FairWarning = 1 WHERE LotId=" + currentLotNo;
            RunDatabaseScript(query);
        }
        #endregion
        #region FetchLotJSON
        [System.Web.Services.WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public static List<ProductLot> FetchAllLots()
        {
            string fetchQuery = "select * from [AuctionBidPlatform].[dbo].[View_list_item]  where IsSold=0";
            DataTable dt = RunDatabaseScript(fetchQuery);
            ProductLot productLot = new ProductLot();
            List<ProductLot> lots = new List<ProductLot>();
            currentLotNo = Convert.ToString(dt.Rows[0]["LotId"]);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lots.Add(new ProductLot
                {
                    LotId = Convert.ToInt32(dt.Rows[i]["LotId"]),
                    LotImageUrl = "http://127.0.0.1:2520/fileupload/upload/" + dt.Rows[i]["LotImageName"],
                    //LotImageUrl = "http://auctionbidplatform.com/fileupload/upload/" + dt.Rows[i]["LotImageName"],
                    LotDesc = Convert.ToString(dt.Rows[i]["LotDesc"]),
                    Title = Convert.ToString(dt.Rows[i]["Title"]),
                    AuctionName = Convert.ToString(dt.Rows[i]["AuctionName"]),
                    Address = Convert.ToString(dt.Rows[i]["Address"]),
                    LowEstimatePrice = Convert.ToString(dt.Rows[i]["LowEstimatePrice"]),
                    HighEstimatePrice = Convert.ToString(dt.Rows[i]["HighEstimatePrice"])
                });
            }
            return lots;
        }
        #endregion
        #region Fetch fair warning
        [System.Web.Services.WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public static bool FetchFairWarning(int id)
        {
            string query = "select FairWarning from dbo.ProductLot where LotId=" + id;
            string connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"];
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            Boolean key = Convert.ToBoolean(dt.Rows[0]["FairWarning"]);
            con.Close();

            return key;
        }
        #endregion
        #region IsSoldOrNot
        [System.Web.Services.WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public static bool IsSoldOrNot(int id)
        {
            string query = "SELECT IsSold FROM dbo.ProductLot where LotId=" + id;
            string connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"];
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            Boolean key = Convert.ToBoolean(dt.Rows[0]["IsSold"]);
            con.Close();
            return key;
        }
        #endregion
        #region General Database Operation
        public static DataTable RunDatabaseScript(string query)
        {
            string connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"];
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;
        }
        #endregion
    }
    public class ProductLot
    {
        public int LotId { get; set; }
        public string LotImageUrl { get; set; }
        public string LotDesc { get; set; }
        public string Title { get; set; }
        public string AuctionName { get; set; }
        public string Address { get; set; }
        public string LowEstimatePrice { get; set; }
        public string HighEstimatePrice { get; set; }
    }
    public class LiveAuctionAskingBids
    {
        public int BidValue { get; set; }
        public string AskingBidOwner { get; set; }
    }
}