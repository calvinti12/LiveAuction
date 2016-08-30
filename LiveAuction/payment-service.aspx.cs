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
    public partial class payment_service : System.Web.UI.Page
    {
        public static string userName;
        protected void Page_Load(object sender, EventArgs e)
        {
            userName = Convert.ToString(HttpContext.Current.Session["UserName"]).Trim();
            if (userName != null && userName != "")
            { }
            else
            {
                Response.Redirect("index.aspx");
            }
        }
        #region RunDatabaseScript
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
        #region GetCardDetail
        [System.Web.Services.WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public static List<CardHolderDetails> GetCardDetail()
        {
            string query = "select * from dbo.View_Bidder where PreferredName like '" + userName + "'";
            DataTable dt = RunDatabaseScript(query);
            List<CardHolderDetails> lots = new List<CardHolderDetails>();
            if (dt.Rows.Count > 0)
            {
                lots.Add(new CardHolderDetails
                {
                    BidderId = Convert.ToInt32(dt.Rows[0]["BidderId"]),
                    CardHolderName = Convert.ToString(dt.Rows[0]["CardHolderName"]),
                    CardNo = Convert.ToString(dt.Rows[0]["CardNo"]),
                    ExpireMonth = Convert.ToInt32(dt.Rows[0]["CardExpiryMonth"]),
                    ExpireYear = Convert.ToInt32(dt.Rows[0]["CardExpiryYear"]),
                    SecurityCode = Convert.ToString(dt.Rows[0]["SecurityCode"])
                });
            }
            return lots;
        }
        #endregion
        #region FetchApiKeys
        [System.Web.Services.WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod()]
        public static List<ApiKey> FetchApiKeys()
        {
            string query = "select * from WorldPayApiKeys";
            DataTable dt = RunDatabaseScript(query);
            List<ApiKey> keys = new List<ApiKey>();
            if (dt.Rows.Count > 0)
            {
                keys.Add(new ApiKey
                {
                    ClientKey = Convert.ToString(dt.Rows[0]["ClientKey"]),
                    ServiceKey = Convert.ToString(dt.Rows[0]["ServiceKey"])
                });
            }
            return keys;
        }
        #endregion
    }
    public class CardHolderDetails
    {
        public int BidderId { set; get; }
        public string CardHolderName { get; set; }
        public string CardNo { get; set; }
        public int ExpireMonth { get; set; }
        public int ExpireYear { get; set; }
        public string SecurityCode { get; set; }
    }
    public class ApiKey
    {
        public string ClientKey { get; set; }
        public string ServiceKey { get; set; }
    }
}