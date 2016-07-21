<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Admin.Master"
    CodeBehind="Dashboard.aspx.cs" Inherits="LiveAuction.Admin.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="">
        <div class="page-title">
            <div class="title_left">
                <h3>
                    Dashboard
                </h3>
            </div>
        </div>
        <div class="clearfix">
        </div>
        <section class="creat-account-sec">
        <div class="container">
            <div class="row">
              <%--<div class="col-md-3">
                <div class="cr-accnt">
                  <div class="account-selling-lstItem-sec">
                    <div class="account-selling-title">
                      <strong><h4>selling</h4></strong>
                    </div>
                    <div class="account-selling-lstItem">
                      <ul class="list-unstyled">
                        <li class="sdmnu-active"><a href="dashboard.html">Dashboard</a></li>
                        <li><a href="advertise.html">Advertise</a></li>
                        <li><a href="sell-item.html">Items</a></li>
                        <li><a href="item-auction.html">Auctions</a></li>
                        <li><a href="item-csv.html">CSV Auctions</a></li>
                      </ul>
                    </div>
                  </div><!-- end of item accont selling -->

                  <div class="account-selling-lstItem-sec">
                    <div class="account-selling-title">
                      <strong><h4>sales</h4></strong>
                    </div>
                    <div class="account-selling-lstItem">
                      <ul class="list-unstyled">
                        <li><a href="money.html">Your money</a></li>
                        <li><a href="feedback.html">Feedback</a></li>
                        <li><a href="stats.html">Stats</a></li>
                      </ul>
                    </div>
                  </div>

                  <div class="account-selling-lstItem-sec">
                    <div class="account-selling-title">
                      <strong><h4>Account</h4></strong>
                    </div>
                    <div class="account-selling-lstItem">
                      <ul class="list-unstyled">
                        <li><a href="account-info.html">Account info</a></li>
                        <li><a href="#">Reminders</a></li>
                        <li><a href="inbox.html">Inbox</a></li>
                        <li><a href="#">Sign Out</a></li>
                      </ul>
                    </div>
                  </div>

                  <div class="account-selling-lstItem-sec">
                    <div class="account-selling-title">
                      <strong><h4>Purchases</h4></strong>
                    </div>
                    <div class="account-selling-lstItem">
                      <ul class="list-unstyled">
                        <li><a href="#">My Orders</a></li>
                      </ul>
                    </div>
                  </div>

                  <div class="account-selling-lstItem-sec">
                    <div class="account-selling-title">
                      <strong><h4>Help & Support</h4></strong>
                    </div>
                    <div class="account-selling-lstItem">
                      <ul class="list-unstyled">
                        <li><a href="#">Contact Us</a></li>
                        <li><a href="#">Cases</a></li>
                        <li><a href="#">FAQs</a></li>
                        <li><a href="#">Forums</a></li>
                      </ul>
                    </div>
                  </div>
                </div> <!-- end of cr-accnt for left sideber -->
              </div>--%>
              <div class="col-md-12">
                <div class="cr-accnt
<%--                <div class="tt">
                    <div class="row">
                        <form>
                            <div class="col-md-3 col-sm-6 col-xs-12">
                                <div class="form-group dash-dp">
                                    <div class="dropdown">
                                      <button class="btn btn-primary dropdown-toggle form-control" type="button" data-toggle="dropdown">selling
                                      <span class="caret pull-right"></span></button>
                                      <ul class="dropdown-menu">
                                        <li class="#"><a href="dashboard.html">Dashboard</a></li>
                                        <li><a href="advertise.html">Advertise</a></li>
                                        <li><a href="sell-item.html">Items</a></li>
                                        <li><a href="item-auction.html">Auctions</a></li>
                                        <li><a href="item-csv.html">CSV Auctions</a></li>
                                      </ul>
                                    </div>
                                </div>
                               </div>
                            <div class="col-md-3 col-sm-6 col-xs-12">
                                <div class="form-group dash-dp">
                                    <div class="dropdown">
                                      <button class="btn btn-primary dropdown-toggle form-control" type="button" data-toggle="dropdown">sales
                                      <span class="caret pull-right"></span></button>
                                      <ul class="dropdown-menu">
                                        <li><a href="#">Your money</a></li>
                                        <li><a href="#">Feedback</a></li>
                                        <li><a href="#">Stats</a></li>
                                      </ul>
                                    </div>
                                </div>
                               </div>
                            <div class="col-md-3 col-sm-6 col-xs-12">
                                <div class="form-group dash-dp">
                                    <div class="dropdown">
                                      <button class="btn btn-primary dropdown-toggle form-control" type="button" data-toggle="dropdown">Account
                                      <span class="caret pull-right"></span></button>
                                      <ul class="dropdown-menu">
                                        <li><a href="#">Account info</a></li>
                                        <li><a href="#">Reminders</a></li>
                                        <li><a href="#">Inbox</a></li>
                                        <li><a href="#">Sign Out</a></li>
                                      </ul>
                                    </div>
                                </div>
                               </div>
                            <!-- <div class="col-md-3 col-sm-6 col-xs-12">
                                <div class="form-group dash-dp">
                                    <div class="dropdown">
                                      <button class="btn btn-primary dropdown-toggle form-control" type="button" data-toggle="dropdown">PURCHASES
                                      <span class="caret pull-right"></span></button>
                                      <ul class="dropdown-menu">
                                        <li class="#"><a href="#">order</a></li>
                                        
                                      </ul>
                                    </div>
                                </div>
                               </div> -->
                        </form>
                    </div>
                </div>--%>
                  <div class="tt">
                  	<div class="dash-higher-vl">
                  		<div class="alert alert-success"><span class="dash-tt"><strong>Sell in volume</strong></span> <strong>interested in selling in more volume?</strong>  Learn more about our partner program <a href="#">here</a></div>
                  	</div>
                  </div>
                  <div class="tt">
                  	<div class="row">
                     <div class="col-md-7 col-xs-12">
                       <div class="dash-item-sec">
                         <div class="dash-item">
                           <ul class="list-inline dash-tp-item-line">
                             <li>To Do</li>
                           </ul>
                           <ul class="list-unstyled dash-tp-item-arrw">
                             <li><a href="#"><span>List More Item to sell</span><i class="fa fa-angle-right" aria-hidden="true"></i></a></li>
                           </ul>
                         </div>
                       </div> <!-- end of the dash-item-sec -->
                       <div class="dash-item-sec">
                         <div class="dash-item">
                           <ul class="list-inline dash-tp-item-line">
                             <li>To Do</li>
                             <li><a href="#">View</a></li>
                           </ul>
                           <ul class="list-unstyled dash-tp-item-arrw">
                             <li><a href="#"><span>0 Item schedule into Auctions</span><i class="fa fa-angle-right" aria-hidden="true"></i></a></li>
                             <li><a href="#"><span>1 panding Auctions schedule Request</span><i class="fa fa-angle-right" aria-hidden="true"></i></a></li>
                             <li><a href="#"><span>1 item to be scheduled</span><i class="fa fa-angle-right" aria-hidden="true"></i></a></li>
                           </ul>
                         </div>
                       </div> <!-- end of the dash-item-sec -->
                     </div> 
                     <div class="col-md-5 col-xs-12">
                       <div class="update-box-notification text-center">
                        <div class="update-box-notification-content">
                          <h4>UPDATE BOX</h4>
                          <P>Will have admin notification, and other staff</P>
                        </div>
                       </div> <!-- end of update-box-notification -->
                     </div> 
                    </div>
                  </div>
                  <div class="tt">
                    <div class="row">
                     <div class="col-md-7 col-xs-12">
                       <div class="dash-item-sec">
                         <div class="dash-item">
                            <ul class="list-inline dash-tp-item-line">
                               <li>My Reputation</li>
                               <li><a href="#">View</a></li>
                            </ul>
                            <div class="reputation-table">
                              <table class="table table-bordered">
                                <tr>
                                  <td><h4>Last 30 Days</h4> <br> <p>since 02/07/16</p></td>
                                  <td><h4>Last 90 Days</h4> <br> <p>since 12/07/16</p></td>
                                </tr>
                                <tr>
                                  <td><h4>Ship on Item <i class="fa fa-info-circle" aria-hidden="true"></i></h4> <br> <p>-</p></td>
                                  <td></td>
                                </tr>
                                <tr>
                                  <td><h4>Avg time to ship <i class="fa fa-info-circle" aria-hidden="true"></i></h4> <br> <p>-</p></td>
                                  <td></td>
                                </tr>
                              </table>
                            </div> <!-- end of reputation-table -->
                          </div>
                        </div> <!-- end of the dash-item-sec -->
                     </div> 
                     <div class="col-md-5 col-xs-12">
                       <div class="dash-item-sec">
                          <div class="dash-item-sec">
                         <div class="dash-item">
                            <ul class="list-inline dash-tp-item-line">
                               <li>My Sales</li>
                               <li><a href="#">View</a></li>
                            </ul>
                            <div class="reputation-table raputaiton-table-week">
                              <table class="table table-bordered">
                                <thead>
                                  <tr>
                                    <td colspan="2">
                                      <h4><strong>This Week</strong></h4><p>since Mondey</p>
                                    </td>
                                  </tr>
                                </thead>
                                <tbody>
                                  <tr>
                                    <td><strong>Sales</strong></td>
                                    <td>$0.00</td>
                                  </tr>
                                  <tr>
                                    <td><strong>items</strong></td>
                                    <td>0</td>
                                  </tr>
                                  <tr>
                                    <td><strong>sold: </strong></td>
                                    <td></td>
                                  </tr>
                                  <tr>
                                    <td colspan="2"><a href="#">View Last Week</a></td>
                                  </tr>
                                </tbody>
                              </table>
                            </div>
                          </div>
                        </div>
                       </div> <!-- end of the dash-item-sec -->
                     </div> 
                    </div>
                  </div>
              </div>
              </div>
            </div>
        </div>
    </section>
        <div class="clearfix">
        </div>
    </div>
</asp:Content>
