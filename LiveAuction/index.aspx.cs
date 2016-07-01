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
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder html = new StringBuilder();
            string connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"]; //ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "select * from Auction where IsSchedule='1'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            string autionData = "";
            string lit = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lit = lit + @"<div class='col-md-3 col-sm-6 col-xs-12'>
                            <div class='action-item-sec text-center'><input type='hidden' class='auctionId' value="+i+
                                "><img src='./Admin/FileUpload/" + dt.Rows[i]["ImageName"] + "' width='200px' alt='" + dt.Rows[i]["AuctionName"] + " image" + "'/><p>" + dt.Rows[i]["Address"] +
                                        "</p><a href='#' class='btn btn-danger btn-block bidding-sing-btn' data-toggle='modal' data-target='#bidpopup'>View Details</a><div class='action-timing-sec'><p>";
                lit = lit + Convert.ToDateTime(dt.Rows[i]["AuctionDate"]).Date.ToString("d");
                lit = lit + @"</p></div></div></div>";

                //var data = "{  'auctionName':" + dt.Rows[i]["AuctionName"] +
                //              "'auctionDate':" + dt.Rows[i]["AuctionDate"] +
                //              "'auctionTime':" + dt.Rows[i]["AuctionTime"] +
                //              "'auctionAddress':" + dt.Rows[i]["Address"] +
                //              "'auctionImageName':" + dt.Rows[i]["ImageName"] +
                //            "}";
                //autionData += "<script type='text/javascript'>var data = { 'auctionName':'" + dt.Rows[i]["AuctionName"] +"'"+
                //              "'auctionDate': '" + dt.Rows[i]["AuctionDate"] + "'" +
                //              "'auctionTime':'" + dt.Rows[i]["AuctionTime"] + "'" +
                //              "'auctionAddress':'" + dt.Rows[i]["Address"] + "'" +
                //              "'auctionImageName':'" + dt.Rows[i]["ImageName"] + "'};todayDeal.push(data);console.log('in script');</script>";

                autionData += "<script type='text/javascript'>var data = { 'auctionName':'" + dt.Rows[i]["AuctionName"] +"',"+
                              "'auctionDate': '" + dt.Rows[i]["AuctionDate"] + "'," +
                              "'auctionTime':'" + dt.Rows[i]["AuctionTime"] + "'," +
                              "'auctionAddress':'" + dt.Rows[i]["Address"] + "'," +
                              "'id':'" + i + "'," +
                              "'auctionImageName':'" + dt.Rows[i]["ImageName"] + "'};todayDeal.push(data);</script>";

            }
            html.Append(lit);
            html.Append(autionData);
            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
        }
    }
}