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
                     <asp:PlaceHolder ID = "PlaceHolder2" runat="server"/>
                     
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
    <asp:PlaceHolder ID = "PlaceHolder1" runat="server"/>
</asp:Content>
