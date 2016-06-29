<%@ Page Language="C#" MasterPageFile="~/Bidder.Master" AutoEventWireup="true" CodeBehind="bid-detail.aspx.cs"
    Inherits="LiveAuction.bid_detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- this is the breadcumbs area -->
    <section class="breadcumbs-area-sec">
         <div class="container">
             <div class="row">
                 <div class="col-md-12">
                     <div class="breadcumb">
                     <a href="#" class="incative">Home &raquo; </a><a href="#" class="incative">Live Auctions &raquo; </a><span class="current-page">Breitling Super Ocean Men's Watch</span></div>
                 </div>
             </div>
         </div>
     </section>
    <!-- end of breadcumbs area -->
    <!-- start of bid popup -->
    <section class="bid-popup-sector">
        <!-- Modal -->
        <div class="modal fade" id="bidpopup" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
          <div class="modal-dialog bid-model-dialog" role="document">
            <div class="modal-content bid-model-content">
              <div class="modal-header bid-model-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title" id="myModalLabel">Wallis & Wallis</h4>
              </div>
              <div class="modal-body bid-model-body">
                  <div class="row">
                    <div class="col-md-6">
                      <div class="cr-accnt pop-cr-accnt">
                        <div class="bid-popup-pic-sec">
                          <div class="bid-popup-title">
                            <h3>Lot 693</h3>
                          </div>
                          <div class="bid-popup-pic">
                            <img src="images/bidpp1.png" alt="this is for bid popup" >
                          </div>
                          <div class="bid-p-dis">
                            <p class="bid-alate">A late 19th century zulu axe asymmetrical blade 13.5 darkwood haft with flared end (cracked).GC plate 6</p>
                          </div>
                          <div class="bid-p-dis text-center">
                            <h4>Estimates 250 275 GBP</h4>
                          </div>
                          <div class="bid-p-dis text-center">
                            <h4>Room Bid 240 GBP</h4>
                          </div>
                          <div class="bid-p-dis">
                            <button type="button" class="btn btn-danger btn-block">Bid 150 GBP</button>
                          </div>
                        </div>
                      </div>
                      <div class="cr-accnt pop-cr-accnt">
                        <div class="log-audio">
                          <div class="log-lft">
                            <button type="button" class="btn btn-default btn-sm">logout</button>
                          </div>
                          <div class="log-lft pull-right">
                            <p class="pull-left audio-pop">Audio available &nbsp; &nbsp; </p><button type="button" class="btn btn-default btn-sm  class="pull-left""><i class="fa fa-volume-up"></i></button>
                          </div>
                        </div>
                      </div>
                    </div>
                    <div class="col-md-6">
                      <div class="cr-accnt pop-cr-accnt">
                        <div class="log-audio">
                          <div class="log-lft">
                            <p>Approved</p>
                          </div>
                          <div class="log-lft pull-right">
                            <p class="pull-left">Selling carency: &nbsp; &nbsp; </p><p class="pull-right"><strong>GBP</strong></p>
                          </div>
                        </div>
                      </div>
                      <div class="cr-accnt pop-cr-accnt">
                        <div class="pop-tble">
                          <div class="table-responsive">
                            <table class="table table-bordered table-striped table-hover">
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
                                  <td class="pop-ico"><i class="fa fa-camera"></i></td>
                                </tr>
                                <tr>
                                  <td>693</td>
                                  <td>Lorem ipsum dolor sit amet, consectetur adipiscing elit, se</td>
                                  <td class="pop-ico"><i class="fa fa-camera"></i></td>
                                </tr>
                                <tr>
                                  <td>694</td>
                                  <td>Lorem ipsum dolor sit amet, consectetur adipiscing elit, se</td>
                                  <td class="pop-ico"><i class="fa fa-camera"></i></td>
                                </tr>
                                <tr>
                                  <td>695</td>
                                  <td>Lorem ipsum dolor sit amet, consectetur adipiscing elit, se</td>
                                  <td class="pop-ico"><i class="fa fa-camera"></i></td>
                                </tr>
                                <tr>
                                  <td>696</td>
                                  <td>Lorem ipsum dolor sit amet, consectetur adipiscing elit, se</td>
                                  <td class="pop-ico"><i class="fa fa-camera"></i></td>
                                </tr>
                              </tbody>
                            </table>
                          </div>
                        </div> <!-- end of popup table -->
                        <div class="row">
                        <div class="ttble-btm">
                          
                    
                          
                        </div>
                        </div>
                      </div>
                      <div class="cr-accnt pop-cr-accnt">
                        <p class="clck-txt">clicking the bid button is a legally binding obligation to buy and pay for the lot should your bid successful.For security, we track all bids placed </p>
                      </div>
                    </div>
                  </div>
                  <div class="row">
                    <div class="col-md-12">
                        <div class="cr-accnt">
                          <div class="log-audio">
                            <div class="log-lft">
                              <div class="pop-footer-lft pull-left">
                                <H3><STRONG>WALLIS & WALLIS</STRONG></H3>
                              </div>
                              <div class="pop-footer-rht">
                                <ul class="list-unstyled">
                                  <li><strong>Bidder information</strong></li>
                                  <li>Bidder id: <span class="popup-bidder-id">SR661855</span></li>
                                  <li>Currency <span class="popup-carency">GBP</span></li>
                                </ul>
                              </div>
                            </div>
                            <div class="log-lft pull-right">
                              <ul class="list-unstyled rt-direct">
                                <li><strong>Need Help?</strong></li>
                                <li><span>support: </span> +44(0)203 &nbsp;725&nbsp;555 </li>
                                <li><span>Auctioneer: </span><a href="#">http://wallisandwallis.co.uk</a></li>
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
      </section>
    <!-- end of bid popup -->
    <section class="bid-details-sec">
      <div class="container">
        <div class="row">
          <div class="col-md-9">
            <div class="bid-details sadow">
              <div class="bid-detail-item">
              <div class="col-md-12">
                <div class="bid-title-sec">
                  <div class="pull-left bid-title-sec-lft">
                    <div class="name-content text-center"><!-- if it is content -->
                      <h1>LOT</h1><h2>99</h2>
                    </div>
                    <div class="name-pic" style="display: none;"><!-- if it is profile pic -->
                      <img src="" alt="this is for example image">
                    </div>
                  </div> <!-- end of pull left -->
                  <div class="bid-title-sec">
                    <div class="bid-title">
                      <h2>Breitling Super Ocean Men's Watch</h2>
                    </div>
                    <div class="bidder-name">
                      <p>Northwich Auction</p>
                    </div>
                  </div>
                </div>
              </div>  <!-- end of dib title col md 12 -->
              <div class="col-md-12">
                <div class="bid-pic">
                  <img src="images/slider1.jpg" alt="this is the bid image" class="img-responsive">
                </div>
              </div>
              <div class="col-md-12">
                <div class="bid-pic-tag">High End Watches, Exotic Antiques, Cars, Gold, Vintage & Collectible Coins, and Jewelry.
                </div>
                <div class="bid-socail-feedback">
                  <img src="images/bid-social-fid.png" alt="this is for bid social feed" class="img-responsive">
                </div>
              </div>
            </div>  <!-- end of bid detail item -->
            <div class="bid-buy-sec">
              <div class="col-md-12">
                <div class="bid-buy">
                  <div class="bid-buy-pic">
                    <img src="images/bid-bought.png" alt="this is for bid bought" class="img-responsive">
                  </div>
                  <div class="bid-buy-name">
                    <a href="#">Northwich Auction</a>
                  </div>
                </div>
              </div>
            </div> <!-- end of bid buy sec -->
            <div class="bid-content-sec">
              <div class="col-md-12">
                <div class="bid-content">
                  <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
                  <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
                </div>
                <p></p>
              </div>
            </div> <!-- end of bid content -->
            </div>
          </div>
          <div class="col-md-3">
            <div class="bidding-sideber-sec sadow">
              <div class="bidding-sideber-item">
                <div class="bidding-time">Live Auction: <span>30 Mar 2016 09:00 BST</span> </div>
              </div>
              <div class="bidding-sideber-item">
                <h4><strong>Estimate: <span>20 GBP - 40 GBP</span></strong></h4>
                <div class="bidder-estimate-bottom">
                  <p>Buyer's Premium: <span>20.00% </span></p>
                  <p>Internet surcharge: <span>3.00%</span></p>
                </div>
              </div>
              <div class="bidding-sideber-item ">
                <a href="#" class="btn btn-danger btn-block bidding-sing-btn" data-toggle="modal" data-target="#bidpopup">SIGN IN TO BID</a>
              </div>
            </div>
            <div class="bidding-sideber-sec sadow">
              <div class="bidding-sideber-item">
                <div class="bidding-pg-slder-sec">
                  <div class="bidding-pg-slder-title">
                    <h4><strong>Catalogue</strong></h4>
                  </div>
                  <div class="bidding-pg-slder">
                    
                  </div>
                  <div class="view-all-item">
                    <a href="#">View all 142 Lots</a>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
</asp:Content>
