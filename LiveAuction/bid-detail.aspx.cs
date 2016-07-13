using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace LiveAuction
{
    public partial class bid_detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateCategoryLevel1();
            int id = Convert.ToInt32(Request.QueryString["id"]);
            if (id != null)
            {
                SelectProduct(id);
            }
        }
        public void SelectProduct(Int32 id)
        {
            StringBuilder html = new StringBuilder();
            StringBuilder siteMap = new StringBuilder();
            string connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"]; //ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "select LotId,Title,LotImageName,LotDesc,AuctionName from dbo.View_list_item where LotId=" + id;
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            string siteMapString = @"<a href='#' class='incative'>Home &raquo; </a><a href='#' class='incative'>Live Auctions &raquo; </a><span class='current-page'>" + dt.Rows[0]["LotDesc"] + "</span></div>";
            string template = @"<section class='bid-details-sec'>
      <div class='container'>
        <div class='row'>
          <div class='col-md-9'>
            <div class='bid-details sadow'>
              <div class='bid-detail-item'>
              <div class='col-md-12'>
                <div class='bid-title-sec'>
                  <div class='pull-left bid-title-sec-lft'>
                    <div class='name-content text-center'><!-- if it is content -->
                      <h1>LOT</h1><h2>" + dt.Rows[0]["LotId"] + "</h2>";
            template += @"</div>
                   <div class='name-pic' style='display: none;'><!-- if it is profile pic -->
                      <img src='' alt='this is for example image'>
                    </div>
                  </div> <!-- end of pull left -->
                  <div class='bid-title-sec'>
                    <div class='bid-title'>
                      <h2>" + dt.Rows[0]["Title"] + "</h2>";
            template += @"</div>
                    <div class='bidder-name'>
                      <p>" + dt.Rows[0]["AuctionName"] + " Auction</p>";
            template += @"</div>
                  </div>
                </div>
              </div>  <!-- end of dib title col md 12 -->
              <div class='col-md-12'>
                <div class='bid-pic'>
                  <img src='fileupload/upload/" + dt.Rows[0]["LotImageName"] + "' alt='this is the bid image' class='img-responsive'/>";
            template += @"</div>
              </div>
              <div class='col-md-12'>
                <div class='bid-pic-tag'>" + dt.Rows[0]["LotDesc"] + "</div>";
            template += @"<div class='bid-socail-feedback'>
                  <img src='images/bid-social-fid.png' alt='this is for bid social feed' class='img-responsive'>
                </div>
              </div>
            </div>  <!-- end of bid detail item -->
            <div class='bid-buy-sec'>
              <div class='col-md-12'>
                <div class='bid-buy'>
                  <div class='bid-buy-pic'>
                    <img src='images/bid-bought.png' alt='this is for bid bought' class='img-responsive'>
                  </div>
                  <div class='bid-buy-name'>
                    <a href='#'>" + dt.Rows[0]["AuctionName"] + " Auction</a>";
            template += @"</div>
                </div>
              </div>
            </div> <!-- end of bid buy sec -->
            <div class='bid-content-sec'>
              <div class='col-md-12'>
                <div class='bid-content'>
                  <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
                  <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
                </div>
                <p></p>
              </div>
            </div> <!-- end of bid content -->
            </div>
          </div>
          <div class='col-md-3'>
            <div class='bidding-sideber-sec sadow'>
              <div class='bidding-sideber-item'>
                <div class='bidding-time'>Live Auction: <span>30 Mar 2016 09:00 BST</span> </div>
              </div>
              <div class='bidding-sideber-item'>
                <h4><strong>Estimate: <span>20 GBP - 40 GBP</span></strong></h4>
                <div class='bidder-estimate-bottom'>
                  <p>Buyer's Premium: <span>20.00% </span></p>
                  <p>Internet surcharge: <span>3.00%</span></p>
                </div>
              </div>
              <div class='bidding-sideber-item '>
                <a href='#' class='btn btn-danger btn-block bidding-sing-btn' data-toggle='modal' data-target='#bidpopup'>SIGN IN TO BID</a>
              </div>
            </div>
            <div class='bidding-sideber-sec sadow'>
              <div class='bidding-sideber-item'>
                <div class='bidding-pg-slder-sec'>
                  <div class='bidding-pg-slder-title'>
                    <h4><strong>Catalogue</strong></h4>
                  </div>
                  <div class='bidding-pg-slder'>
                    
                  </div>
                  <div class='view-all-item'>
                    <a href='#'>View all 142 Lots</a>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>";
            //Response.Redirect("sell-item.aspx");
            html.Append(template);
            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
            siteMap.Append(siteMapString);
            PlaceHolder2.Controls.Add(new Literal { Text = siteMap.ToString() });
        }
        private void PopulateCategoryLevel1()
        {

        }
    }
}