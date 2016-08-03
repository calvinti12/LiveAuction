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
    public partial class live_auction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder html = new StringBuilder();
            StringBuilder currentHtml = new StringBuilder();
            string connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"]; //ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "select Distinct * from [AuctionBidPlatform].[dbo].[View_list_item]";
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
            currentLit += @"</div>
						</div>";
            currentHtml.Append(currentLit);
            PlaceHolderCurrentLot.Controls.Add(new Literal { Text = currentHtml.ToString() });
            for (int i = 0; i < dt.Rows.Count; i++)
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
            html.Append(lit);
            PlaceHolderQueueLot.Controls.Add(new Literal { Text = html.ToString() });
        }
    }
}