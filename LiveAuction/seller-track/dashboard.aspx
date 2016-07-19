<%@ Page Language="C#" MasterPageFile="~/seller-track/Seller.Master" AutoEventWireup="true"
    CodeBehind="dashboard.aspx.cs" Inherits="LiveAuction.seller_track.dashboard" %>

<%@ Register Src="~/UserControl/SellerLeftPanel.ascx" TagName="SellerLeftPanel" TagPrefix="UCSellerLeftPanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $('#liDashboard').addClass('sdmnu-active');
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- this is the breadcumbs area -->
    <section class="breadcumbs-area-sec">
         <div class="container">
             <div class="row">
                 <div class="col-md-12">
                     <div class="breadcumb">
                     <a href="#" class="incative">Home &raquo; </a><span class="current-page">Dashboard</span></div>
                 </div>
             </div>
         </div>
     </section>
    <!-- end of breadcumbs area -->
    <section class="creat-account-sec">
        <div class="container">
            <div class="row">
              <UCSellerLeftPanel:SellerLeftPanel runat="server" ID="SellerLftPnl" />           
              <div class="col-md-9">
                <div class="cr-accnt">
                  <div class="tt">
                      <div class="account-creat-title">
                          <h2>Dashboard</h2>
                      </div>
                  </div>
                  <div class="tt">
                  	<div class="dash-higher-vl">
                  		<div class="alert alert-success"><span class="dash-tt"><strong>Sell in volume</strong></span> <strong>interested in selling in more volume?</strong>  Learn more about our partner program <a href="#">here</a></div>
                  	</div>
                  </div>
                  <div class="tt">
                  	<div class="row">
                     <div class="col-md-7">
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
                             <li><a href="#"><span>1 pending auctions schedule request</span><i class="fa fa-angle-right" aria-hidden="true"></i></a></li>
                             <li><a href="#"><span>1 item to be scheduled</span><i class="fa fa-angle-right" aria-hidden="true"></i></a></li>
                           </ul>
                         </div>
                       </div> <!-- end of the dash-item-sec -->
                     </div> 
                     <div class="col-md-5">
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
                     <div class="col-md-7">
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
                     <div class="col-md-5">
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
                                    <td>£0.00</td>
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
</asp:Content>
