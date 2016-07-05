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
            StringBuilder modalWindowHtml = new StringBuilder();
            string connectionString = System.Configuration.ConfigurationSettings.AppSettings["ConnStr"]; //ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "select * from Auction";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            string modalHtml = "";
            string autionData = "";
            string lit = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lit = lit + @"<div class='col-md-3 col-sm-6 col-xs-12'>
                            <div class='action-item-sec text-center'><input type='hidden' class='auctionId' value=" + i +
                                "><img src='./Admin/FileUpload/" + dt.Rows[i]["ImageName"] + "' width='200px' alt='" + dt.Rows[i]["AuctionName"] + " image" + "'/><p>" + dt.Rows[i]["Address"] +
                                        "</p><a href='#' class='btn btn-danger btn-block bidding-sing-btn todaysAction' data-toggle='modal' data-target='#bidpopup"+ dt.Rows[i]["AuctionId"] +"' >View Details</a><div class='action-timing-sec'><p>";
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

                autionData += "<script type='text/javascript'>var data = { 'auctionName':'" + dt.Rows[i]["AuctionName"] + "'," +
                              "'auctionDate': '" + dt.Rows[i]["AuctionDate"] + "'," +
                              "'auctionTime':'" + dt.Rows[i]["AuctionTime"] + "'," +
                              "'auctionAddress':'" + dt.Rows[i]["Address"] + "'," +
                              "'id':'" + i + "'," +
                              "'auctionImageName':'" + dt.Rows[i]["ImageName"] + "'};todayDeal.push(data);</script>";

                string subquery = "select LotId,LotDesc,LotImageName from [AuctionBidPlatform].[dbo].[View_list_item]   where AuctionId=" + dt.Rows[i]["AuctionId"] + " and IsScheduled=1";
                SqlDataAdapter adapter1 = new SqlDataAdapter(subquery, con);
                DataTable dt1 = new DataTable();
                adapter1.Fill(dt1);
                con.Close();
                
                
                modalHtml += "<section class='bid-popup-sector'><!-- Modal --><div class='modal fade' id='bidpopup" + dt.Rows[i]["AuctionId"] + "' tabindex='-1' role='dialog' aria-labelledby='myModalLabel'>" +
                                      "<div class='modal-dialog bid-model-dialog' role='document'>" +
                                        "<div class='modal-content bid-model-content'>" +
                                          "<div class='modal-header bid-model-header'>" +
                                            "<button type='button' class='close' data-dismiss='modal' aria-label='Close'><span aria-hidden='true'>&times;</span></button>" +
                                            "<h4 class='modal-title' id='myModalLabel'>"+ dt.Rows[i]["AuctionName"] + "</h4>" +
                                          "</div>" +
                                          "<div class='modal-body bid-model-body'>" +
                                              "<div class='row'>" +
                                                "<div class='col-md-6'>" +
                                                  "<div class='cr-accnt pop-cr-accnt'>" +
                                                    "<div class='bid-popup-pic-sec'>" +
                                                      "<div class='bid-popup-title'>" +
                                                        "<!--<h3>Lot 693</h3>-->" +
                                                      "</div>" +
                                                      "<div class='bid-popup-pic'>" +
                                                        "<!--<img src='images/bidpp1.png' alt='this is for bid popup' >-->" +
                                                        "<img src='./Admin/FileUpload/" + dt.Rows[i]["ImageName"] + "' width='200px' alt='" + dt.Rows[i]["AuctionName"] + " image" + "'/>" +
                                                      "</div>" +
                                                      "<div class='bid-p-dis'>" +
                                                        "<p class='bid-alate'>A late 19th century zulu axe asymmetrical blade 13.5 darkwood haft with flared end (cracked).GC plate 6</p>" +
                                                      "</div>" +
                                                      "<!--<div class='bid-p-dis text-center'>" +
                                                        "<h4>Estimates 250 275 GBP</h4>" +
                                                      "</div>" +
                                                      "<div class='bid-p-dis text-center'>" +
                                                        "<h4>Room Bid 240 GBP</h4>" +
                                                      "</div>-->" +
                                                      "<div class='bid-p-dis'>" +
                                                        "<button type='button' class='btn btn-danger btn-block'>Time left </button>" +
                                                      "</div>" +
                                                    "</div>" +
                                                  "</div>" +
                                                  "<div class='cr-accnt pop-cr-accnt'>" +
                                                    "<div class='log-audio'>" +
                                                      "<div class='log-lft'>" +
                                                        "<button type='button' class='btn btn-default btn-sm'>logout</button>" +
                                                      "</div>" +
                                                      "<div class='log-lft pull-right'>" +
                                                        "<p class='pull-left audio-pop'>Audio available &nbsp; &nbsp; </p><button type='button' class='btn btn-default btn-sm  class='pull-left''><i class='fa fa-volume-up'></i></button>" +
                                                      "</div>" +
                                                    "</div>" +
                                                  "</div>" +
                                                "</div>" +
                                                "<div class='col-md-6'>" +
                                                  "<div class='cr-accnt pop-cr-accnt'>" +
                                                    "<div class='log-audio'>" +
                                                      "<div class='log-lft'>" +
                                                        "<p>Approved</p>" +
                                                      "</div>" +
                                                      "<div class='log-lft pull-right'>" +
                                                        "<p class='pull-left'>Selling carency: &nbsp; &nbsp; </p><p class='pull-right'><strong>GBP</strong></p>" +
                                                      "</div>" +
                                                    "</div>" +
                                                  "</div>" +
                                                  "<div class='cr-accnt pop-cr-accnt'>" +
                                                    "<div class='pop-tble'>" +
                                                      "<div class='table-responsive'>" +
                                                        "<table class='table table-bordered table-striped table-hover'>" +
                                                          "<thead>" +
                                                            "<!--<tr>" +
                                                              "<td>Firstname</td>" +
                                                              "<td>Lastname</td>" +
                                                              "<td>Email</td>" +

                                                            "</tr>-->" +
                                                          "</thead>" +
                                                          "<thead >" +
                                                            "<tr>" +
                                                              "<th>Lot</th>" +
                                                              "<th>Description</th>" +
                                                              "<th>Image</th>" +
                                                            "</tr>" +
                                                          "</thead>" +
                                                          "<tbody>" ;
                                                            for (int j = 0; j < dt1.Rows.Count; j++)
                                                            {
                                                                modalHtml += "<tr><td>" + dt1.Rows[j]["LotId"] + "</td>" +
                                                                "<td>" + dt1.Rows[j]["LotDesc"] + "</td>" +
                                                                "<td class='pop-ico'><img  width='50px' src='../fileupload/upload/" + dt1.Rows[j]["LotImageName"] + "'/></td>" +
                                                              "</tr>";
                                                            }
                                                            modalHtml += "<!--<tr>" +
                                                              "<td>693</td>" +
                                                              "<td>Lorem ipsum dolor sit amet, consectetur adipiscing elit, se</td>" +
                                                              "<td class='pop-ico'><i class='fa fa-camera'></i></td>" +
                                                            "</tr>" +
                                                            "<tr>" +
                                                              "<td>694</td>" +
                                                              "<td>Lorem ipsum dolor sit amet, consectetur adipiscing elit, se</td>" +
                                                              "<td class='pop-ico'><i class='fa fa-camera'></i></td>" +
                                                            "</tr>" +
                                                            "<tr>" +
                                                              "<td>695</td>" +
                                                              "<td>Lorem ipsum dolor sit amet, consectetur adipiscing elit, se</td>" +
                                                              "<td class='pop-ico'><i class='fa fa-camera'></i></td>" +
                                                            "</tr>" +
                                                            "<tr>" +
                                                              "<td>696</td>" +
                                                              "<td>Lorem ipsum dolor sit amet, consectetur adipiscing elit, se</td>" +
                                                              "<td class='pop-ico'><i class='fa fa-camera'></i></td>" +
                                                              "<td class='pop-ico'><i class='fa fa-camera'></i></td>" +
                                                            "</tr>-->" +
                                                          "</tbody>" +
                                                       " </table>" +
                                                      "</div>" +
                                                    "</div> <!-- end of popup table -->" +
                                                    "<!--<div class='row'>" +
                                                    "<div class='ttble-btm'>" +
                                                    "</div>" +
                                                    "</div>" +
                                                  "</div>" +
                                                  "<div class='cr-accnt pop-cr-accnt'>" +
                                                    "<p class='clck-txt'>clicking the bid button is a legally binding obligation to buy and pay for the lot should your bid successful.For security, we track all bids placed </p>" +
                                                  "</div>" +
                                                "</div>" +
                                              "</div>" +
                                              "<div class='row'>" +
                                                "<div class='col-md-12'>" +
                                                    "<div class='cr-accnt'>" +
                                                      "<!--<div class='log-audio'>" +
                                                        "<div class='log-lft'>" +
                                                          "<div class='pop-footer-lft pull-left'>" +
                                                            "<H3><STRONG>WALLIS & WALLIS</STRONG></H3>" +
                                                          "</div>" +
                                                          "<div class='pop-footer-rht'>" +
                                                            "<ul class='list-unstyled'>" +
                                                              "<li><strong>Bidder information</strong></li>" +
                                                              "<li>Bidder id: <span class='popup-bidder-id'>SR661855</span></li>" +
                                                              "<li>Currency <span class='popup-carency'>GBP</span></li>" +
                                                            "</ul>" +
                                                          "</div>" +
                                                        "</div>" +
                                                        "<div class='log-lft pull-right'>" +
                                                          "<ul class='list-unstyled rt-direct'>" +
                                                            "<li><strong>Need Help?</strong></li>" +
                                                            "<li><span>support: </span> +44(0)203 &nbsp;725&nbsp;555 </li>" +
                                                            "<li><span>Auctioneer: </span><a href='#'>http://wallisandwallis.co.uk</a></li>" +
                                                          "</ul>" +
                                                        "</div>" +
                                                      "</div>-->" +
                                                  "</div>" +
                                               "</div>" +
                                              "</div>" +
                                          "</div>" +
                                        "</div>" +
                                      "</div>" +
                                    "</div>" +
                                  "</section>-->" +
                                "<!-- end of bid popup -->" +
                                "<!---------------- END OF MODAL WINDOW --------------------->";
                
            }
            html.Append(lit );
            modalWindowHtml.Append(modalHtml);
            //html.Append(autionData);
            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
            PlaceHolder2.Controls.Add(new Literal { Text = modalWindowHtml.ToString() });
        }
    }
}