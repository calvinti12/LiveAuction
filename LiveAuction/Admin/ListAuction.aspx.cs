using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace LiveAuction.Admin
{
    public partial class ListAuction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillGrid();
            }

        }
        private void FillGrid()
        {
            string connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"]; //ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "select * from Auction";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            string moralHtml = "";
            string lit = @"<table id='example' class='table table-striped responsive-utilities jambo_table'>
                        <thead>
                            <tr class='headings'>
                                <th>
                                    <input type='checkbox' class='tableflat'>
                                </th>
                                <th>Auction Id </th>
                                <th>Auction Name </th>
                                <th>Auction Date </th>                             
                                <th class='no-link last'>
                                    <span class='nobr'>Action</span>
                                </th>
                            </tr>
                        </thead>
                        <tbody>";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i % 2 == 0)
                {
                    lit = lit + @"<tr class='even pointer'>
                                <td class='a-center'>
                                    <input type='checkbox' class='tableflat'>
                                </td>
                                <td class=''>" + dt.Rows[i]["AuctionId"] + "</td>" +
                                "<td class=''>" + dt.Rows[i]["AuctionName"] + "</td>" +
                                "<td class=''>" + Convert.ToDateTime(dt.Rows[i]["AuctionDate"]).Date.ToString("d") + "</td>" +
                                "<td class='last'>" +
                                    "<a href='#' data-toggle='modal' data-target='#bidpopup" + dt.Rows[i]["AuctionId"] + "'>View</a>" +
                                "</td>" +
                            "</tr>";
                }
                else
                {
                    lit = lit + @"<tr class='odd pointer'>
                                <td class='a-center'>
                                    <input type='checkbox' class='tableflat'>
                                </td>
                                <td class=''>" + dt.Rows[i]["AuctionId"] + "</td>" +
                                "<td class=''>" + dt.Rows[i]["AuctionName"] + "</td>" +
                                "<td class=''>" + Convert.ToDateTime(dt.Rows[i]["AuctionDate"]).Date.ToString("d") + "</td>" +
                                "<td class='last'>" +
                                    "<a href='#' data-toggle='modal' data-target='#bidpopup" + dt.Rows[i]["AuctionId"] + "'>View</a>" +
                                "</td>" +
                            "</tr>";
                }
                moralHtml += @"</table><section class='bid-popup-sector'>
        <div class='modal fade' id='bidpopup" + dt.Rows[i]["AuctionId"] + "' tabindex='-1' role='dialog' aria-labelledby='myModalLabel'>";
                moralHtml += @"<div class='modal-dialog bid-model-dialog' role='document'>
            <div class='modal-content bid-model-content'>
              <div class='modal-header bid-model-header'>
                <button type='button' class='close' data-dismiss='modal' aria-label='Close'><span aria-hidden='true'>&times;</span></button>
                <h4 class='modal-title' id='myModalLabel'>" + dt.Rows[i]["AuctionName"] + "</h4>";
                moralHtml += @"</div>
              <div class='modal-body bid-model-body'>
                  <div class='row'>
                    <div class='col-md-6'>
                      <div class='cr-accnt pop-cr-accnt'>
                        <div class='bid-popup-pic-sec'>
                          <div class='bid-popup-title'>
                            <h3>Lot 693</h3>
                          </div>
                          <div class='bid-popup-pic'>
                            <img src='FileUpload/" + dt.Rows[i]["ImageName"] + "' alt='this is for bid popup' width='200px'>";
                moralHtml += @"</div>
                          <div class='bid-p-dis'>
                            <p class='bid-alate'>" + dt.Rows[i]["Description"] + "</p>";
                moralHtml += @"</div>
                          <div class='bid-p-dis text-center'>
                            <h4>Estimates 250 275 GBP</h4>
                          </div>
                          <div class='bid-p-dis text-center'>
                            <h4>Room Bid 240 GBP</h4>
                          </div>
                          <!--<div class='bid-p-dis'>
                            <button type='button' class='btn btn-danger btn-block'>Bid 150 GBP</button>
                          </div>-->
                        </div>
                      </div>
                    </div>
                    <div class='col-md-6'>
                      <!--<div class='cr-accnt pop-cr-accnt'>
                        <div class='log-audio'>
                          <div class='log-lft'>
                            <p>Approved</p>
                          </div>
                          <div class='log-lft pull-right'>
                            <p class='pull-left'>Selling carency: &nbsp; &nbsp; </p><p class='pull-right'><strong>GBP</strong></p>
                          </div>
                        </div>
                      </div>-->
                      <div class='cr-accnt pop-cr-accnt'>
                        <div class='pop-tble'>
                          <div class='table-responsive'>
                            <table class='table table-bordered table-striped table-hover'>
                              <thead>
                                <tr>
                                  <td>Firstname</td>
                                  <td>Lastname</td>
                                  <td>Email</td>
                                  
                                </tr>
                              </thead>
                              <thead >
                                <tr>
                                  <th>Lot</th>
                                  <th>Description</th>
                                  <th>Image</th>
                                </tr>
                              </thead>
                              <tbody>
                                <tr>
                                  <td>692</td>
                                  <td>Lorem ipsum dolor sit amet, consectetur adipiscing elit, se</td>
                                  <td class='pop-ico'><i class='fa fa-camera'></i></td>
                                </tr>
                                <tr>
                                  <td>693</td>
                                  <td>Lorem ipsum dolor sit amet, consectetur adipiscing elit, se</td>
                                  <td class='pop-ico'><i class='fa fa-camera'></i></td>
                                </tr>
                                <tr>
                                  <td>694</td>
                                  <td>Lorem ipsum dolor sit amet, consectetur adipiscing elit, se</td>
                                  <td class='pop-ico'><i class='fa fa-camera'></i></td>
                                </tr>
                                <tr>
                                  <td>695</td>
                                  <td>Lorem ipsum dolor sit amet, consectetur adipiscing elit, se</td>
                                  <td class='pop-ico'><i class='fa fa-camera'></i></td>
                                </tr>
                                <tr>
                                  <td>696</td>
                                  <td>Lorem ipsum dolor sit amet, consectetur adipiscing elit, se</td>
                                  <td class='pop-ico'><i class='fa fa-camera'></i></td>
                                </tr>
                              </tbody>
                            </table>
                          </div>
                        </div> <!-- end of popup table -->
                        <div class='row'>
                        <div class='ttble-btm'>
                        </div>
                        </div>
                      </div>
                      <div class='cr-accnt pop-cr-accnt'>
                        <p class='clck-txt'>clicking the bid button is a legally binding obligation to buy and pay for the lot should your bid successful.For security, we track all bids placed </p>
                      </div>
                    </div>
                  </div>
                  <div class='row'>
                    <div class='col-md-12'>
                        <div class='cr-accnt'>
                          <div class='log-audio'>
                            <div class='log-lft'>
                              <div class='pop-footer-lft pull-left'>
                                <H3><STRONG>WALLIS & WALLIS</STRONG></H3>
                              </div>
                              <div class='pop-footer-rht'>
                                <ul class='list-unstyled'>
                                  <li><strong>Bidder information</strong></li>
                                  <li>Bidder id: <span class='popup-bidder-id'>SR661855</span></li>
                                  <li>Currency <span class='popup-carency'>GBP</span></li>
                                </ul>
                              </div>
                            </div>
                            <div class='log-lft pull-right'>
                              <ul class='list-unstyled rt-direct'>
                                <li><strong>Need Help?</strong></li>
                                <li><span>support: </span> +44(0)203 &nbsp;725&nbsp;555 </li>
                                <li><span>Auctioneer: </span><a href='#'>http://wallisandwallis.co.uk</a></li>
                              </ul>
                            </div>
                          </div>
                      </div>
                    </div>
                  </div>
              </div>
            </div>
          </div>
        </div>
      </section>";
            }
            lit += @"</table>";
            literalText.Text = lit + moralHtml;

        }
    }
}