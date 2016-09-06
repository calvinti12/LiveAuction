using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace LiveAuction
{
    public partial class my_account1 : System.Web.UI.Page
    {
        public static string userName;
        public static string userId;
        protected void Page_Load(object sender, EventArgs e)
        {
         userName = Convert.ToString(HttpContext.Current.Session["UserName"]).Trim();
         userId = Convert.ToString(HttpContext.Current.Session["UserId"]).Trim();
         if (userName != null && userName != "")
         {  }
         else
         {
             Response.Redirect("index.aspx"); 
         }
        }
        #region LoadAccountDetails
        [System.Web.Services.WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public static List<BidderDetail> LoadAccountDetails()
        {
            string query = "select * from dbo.View_Bidder where BidderId=" + userId;
            DataTable dt=RunDatabaseScript(query);
            BidderDetail bidderDetail = new BidderDetail();
            List<BidderDetail> bidder = new List<BidderDetail>();
                bidder.Add(new BidderDetail
                {
                    BidderId =Convert.ToInt32(userId),
                    FirstName = Convert.ToString(dt.Rows[0]["FirstName"]),
                    LastName = Convert.ToString(dt.Rows[0]["LastName"]),
                    Email = Convert.ToString(dt.Rows[0]["Email"]),
                    Phone = Convert.ToString(dt.Rows[0]["Telephone"]),
                    Country =Convert.ToString(dt.Rows[0]["City"]),
                    Telephone =Convert.ToString(dt.Rows[0]["Telephone"]),
                    CardNo = Convert.ToString(dt.Rows[0]["CardNo"]),
                    CardStartMonth = Convert.ToString(dt.Rows[0]["CardStartMonth"]),
                    CardStartYear = Convert.ToString(dt.Rows[0]["CardStartYear"]),
                    CardExpiryMonth = Convert.ToString(dt.Rows[0]["CardExpiryMonth"]),
                    CardExpiryYear = Convert.ToString(dt.Rows[0]["CardExpiryYear"]),
                    SecurityCode = Convert.ToString(dt.Rows[0]["SecurityCode"]),
                    CardHolderName=Convert.ToString(dt.Rows[0]["CardHolderName"]),
                    Address = Convert.ToString(dt.Rows[0]["Address"]),
                    Password = Convert.ToString(dt.Rows[0]["Password"])
                });
                return bidder;
        }
        #endregion
        #region UpdatePersonalInfo
        [System.Web.Services.WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public static void UpdatePersonalInfo(string FirstName, string LastName, string Email, string Telephone, string Country)
        { 
            string query="Update dbo.View_Bidder set FirstName='"+FirstName+"',LastName='"+LastName+"',Email='"+Email+"',Telephone='"+Telephone+"',City='"+Country+"' where BidderId="+userId ;
            RunDatabaseScript(query);
        }
        #endregion
        #region UpdateCardInfo
        [System.Web.Services.WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public static void UpdateCardInfo(string CardNo, string CardHolderName, string CardStartMonth, string CardStartYear, string CardExpiryMonth, string CardExpiryYear, string SecurityCode)
        {
            string query = "Update dbo.View_Bidder set CardHolderName='" + CardHolderName + "',CardNo='" + CardNo + "',CardStartMonth='" + CardStartMonth + "',CardStartYear='" + CardStartYear + "',CardExpiryMonth='" + CardExpiryMonth + "',CardExpiryYear='" + CardExpiryYear + "',SecurityCode='" + SecurityCode + "' where BidderId=" + userId;
            RunDatabaseScript(query);
        }
        #endregion
        #region UpdateAddressInfo
        [System.Web.Services.WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public static void UpdateAddressInfo(string Address)
        {
            string query = "Update dbo.View_Bidder set Address='" + Address + "' where BidderId=" + userId;
            RunDatabaseScript(query);
        }
        #endregion
        #region UpdatePassword
        [System.Web.Services.WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public static void UpdatePassword(string Password)
        {
            string query = "Update dbo.View_Bidder set Password='" + Password + "' where BidderId=" + userId;
            RunDatabaseScript(query);
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
    public class BidderDetail {
        public int BidderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string Telephone { get; set; }
        public string CardNo { get; set; }
        public string CardStartMonth { get; set; }
        public string CardStartYear { get; set; }
        public string CardExpiryMonth { get; set; }
        public string CardExpiryYear { get; set; }
        public string SecurityCode { get; set; }
        public string CardHolderName { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
    }
}