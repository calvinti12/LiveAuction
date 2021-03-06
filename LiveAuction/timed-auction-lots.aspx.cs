﻿using System;
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
using System.Net.Mail;
namespace LiveAuction
{
    public partial class timed_auction_lots : System.Web.UI.Page
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
            //FetchLots();
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
            string query = "select * from [AuctionBidPlatform].[dbo].[View_timed_auction_lots]";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            //string delquery = "delete  from dbo.LiveAuctionLogs";
            //SqlDataAdapter deladapter = new SqlDataAdapter(delquery, con);
            //DataTable deldt = new DataTable();
            //deladapter.Fill(deldt);

            string currentLotQuery = "select top 1 * from [AuctionBidPlatform].[dbo].[View_timed_auction_lots]";
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
            string query = "UPDATE [AuctionBidPlatform].[dbo].[TimedProductLot] SET LiveAuctionPassed=1 WHERE LotId=" + currentLotNo;
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
        }
        #endregion
        #region Add Log File
        public static void AddtoLogFile(string Message, string WebPage, string fileName, int askingBid, string id)
        {
            string LogPath = HttpContext.Current.Server.MapPath(@"~\TCAG\Admin\timed_log_files\").ToString();
            //string LogPath = HttpContext.Current.Server.MapPath(@"~\Admin\timed_log_files\").ToString();
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
            string query = "UPDATE [AuctionBidPlatform].[dbo].[TimedAuctionAskingBids] set BidValue=" + askingBidPrice + ",AskingBidOwner='" + userName + "' where LotId=" + id;
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
            string query = "INSERT INTO [AuctionBidPlatform].[dbo].[TimedAuctionAskingBids]([LotId],[BidValue],[AskingBidOwner])VALUES(" + currentLotNo + "," + askingBidPrice + ",'" + userName + "')";
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
                AddtoLogFile("Internet bid £", "sampleWebsite", "lotNo_" + id, askingBidPrice, id);
                return "Internet bid £" + askingBidPrice;
            }
            else
                return "0";
        }
        #endregion
        #region FetchAskingBidValue
        [System.Web.Services.WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public static List<TimedAuctionAskingBids> FetchAskingBidValue(string id)
        {
            if (id != "" && id != null)
            {
                TimedAuctionAskingBids lab = new TimedAuctionAskingBids();
                List<TimedAuctionAskingBids> askingBids = new List<TimedAuctionAskingBids>();

                string connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"]; //ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string query = "SELECT [BidValue],[AskingBidOwner] FROM [AuctionBidPlatform].[dbo].[TimedAuctionAskingBids] WHERE [LotId]=" + id;
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                con.Close();
                int bidVal;
                string askingBidOwner = "";
                if (dt.Rows.Count > 0)
                {
                    askingBidOwner = Convert.ToString(dt.Rows[0]["AskingBidOwner"]);
                    if (askingBidOwner.Equals("admin@admin.com"))
                    {
                        bidVal = Convert.ToInt32(dt.Rows[0]["BidValue"]);
                        askingBidOwner = "Room bid";
                    }
                    else
                    {
                        bidVal = Convert.ToInt32(dt.Rows[0]["BidValue"]);
                        askingBidOwner = "Internet bid";
                    }
                }
                else
                { bidVal = 10; }
                askingBids.Add(new TimedAuctionAskingBids
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
        public static List<TimedProductLot> SoldItem(string id)
        {
            userName = Convert.ToString(HttpContext.Current.Session["UserName"]).Trim();
            if (userName != null && userName != "")
            {
                //string query = "UPDATE dbo.TimedProductLot set IsSold = 1 WHERE LotId=" + id;
                //RunDatabaseScript(query);
                string fetchQuery = "select * from [AuctionBidPlatform].[dbo].[View_list_item]  where IsSold=0";
                DataTable dt = RunDatabaseScript(fetchQuery);
                TimedProductLot TimedProductLot = new TimedProductLot();
                List<TimedProductLot> lots = new List<TimedProductLot>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lots.Add(new TimedProductLot
                    {
                        LotId = Convert.ToInt32(dt.Rows[i]["LotId"]),
                        //LotImageUrl = "http://127.0.0.1:2520/fileupload/upload/" + dt.Rows[i]["LotImageName"],
                        LotImageUrl = "http://auctionbidplatform.com/fileupload/upload/" + dt.Rows[i]["LotImageName"],
                        LotDesc = Convert.ToString(dt.Rows[i]["LotDesc"]),
                        Title = Convert.ToString(dt.Rows[i]["Title"]),
                        AuctionName = Convert.ToString(dt.Rows[i]["AuctionName"]),
                        LowEstimatePrice = Convert.ToString(dt.Rows[i]["LowEstimatePrice"]),
                        HighEstimatePrice = Convert.ToString(dt.Rows[i]["HighEstimatePrice"])
                    });
                }
                return lots;
            }
            List<TimedProductLot> blanklot = new List<TimedProductLot>();
            blanklot.Add(new TimedProductLot
            {
                Title = "novalue",

            });
            return blanklot;
        }
        #endregion
        #region FetchAllLots
        [System.Web.Services.WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public static List<TimedProductLot> FetchAllLots()
        {
            string fetchQuery = "select * from [AuctionBidPlatform].[dbo].[View_timed_auction_lots]  where IsSold=0";
            DataTable dt = RunDatabaseScript(fetchQuery);
            TimedProductLot TimedProductLot = new TimedProductLot();
            List<TimedProductLot> lots = new List<TimedProductLot>();
            currentLotNo = Convert.ToString(dt.Rows[0]["LotId"]);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var auctionDate = Convert.ToDateTime(dt.Rows[i]["AuctionDate"]).Date.ToString("dd/MM/yyyy");
                var auctionTime = Convert.ToDateTime(dt.Rows[i]["AuctionTime"]).TimeOfDay;
                lots.Add(new TimedProductLot
                {
                    LotId = Convert.ToInt32(dt.Rows[i]["LotId"]),
                    //LotImageUrl = "http://127.0.0.1:2520/fileupload/upload/" + dt.Rows[i]["ImageName"],
                    LotImageUrl = "http://auctionbidplatform.com/fileupload/upload/" + dt.Rows[i]["ImageName"],
                    LotDesc = Convert.ToString(dt.Rows[i]["LotDesc"]),
                    Title = Convert.ToString(dt.Rows[i]["Title"]),
                    AuctionName = Convert.ToString(dt.Rows[i]["AuctionName"]),
                    AuctionDate = Convert.ToString(auctionDate),
                    AuctionTime = Convert.ToString(auctionTime),
                    LowEstimatePrice = Convert.ToString(dt.Rows[i]["LowEstimatePrice"]),
                    HighEstimatePrice = Convert.ToString(dt.Rows[i]["HighEstimatePrice"]),
                    MaximumReserveValue = Convert.ToString(dt.Rows[i]["MaxReserveValue"]),
                    BuynowPrice = Convert.ToString(dt.Rows[i]["BuynowPrice"]),
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
            string query = "select FairWarning from dbo.TimedProductLot where LotId=" + id;
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
            string query = "SELECT IsSold FROM dbo.TimedProductLot where LotId=" + id;
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
        #region send mail
        protected string SendEmail(string toAddress, string subject, string body)
        {
            string result = "Message Sent Successfully..!!";
            string senderID = "SenderEmailID";// use sender’s email id here..
            const string senderPassword = "Password"; // sender password here…
            try
            {
                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com", // smtp server address here…
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new System.Net.NetworkCredential(senderID, senderPassword),
                    Timeout = 30000,
                };
                MailMessage message = new MailMessage(senderID, toAddress, subject, body);
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                result = "Error sending email.!!!";
            }
            return result;
        }
        #endregion
        #region getuserName
        [System.Web.Services.WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public static string GetUserName()
        {
            userName = Convert.ToString(HttpContext.Current.Session["UserName"]).Trim();
            if (userName != null && userName != "")
            {
                return userName;
            }
            else
                return "";
        }
        #endregion
        public void RedirecToPaymentPage()
        {
            HttpContext.Current.Response.Redirect("payment-service.aspx");
        }
    }

    public class TimedProductLot
    {
        public int LotId { get; set; }
        public string LotImageUrl { get; set; }
        public string LotDesc { get; set; }
        public string Title { get; set; }
        public string AuctionName { get; set; }
        public string AuctionDate { get; set; }
        public string AuctionTime { get; set; }
        public string LowEstimatePrice { get; set; }
        public string HighEstimatePrice { get; set; }
        public string MaximumReserveValue { get; set; }
        public string BuynowPrice { get; set; }
    }
    public class TimedAuctionAskingBids
    {
        public int BidValue { get; set; }
        public string AskingBidOwner { get; set; }
    }
}