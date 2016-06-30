<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Bidder.Master" CodeBehind="index.aspx.cs"
    Inherits="LiveAuction.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section class="slider-section">
        <div class="container">
            <div class="row">
                <div class="col-md-8 col-sm-8 col-xs-12">
                    <div class="watch-sl-sec">
                        <img src="images/slider1.jpg" alt="" class="img-responsive">
                        <div class="watch-caption main-slider-caption">
                            <h2><strong>CAR, GOLD,</br>Jewellery & more</strong></h2>
                            <p>BID NOW!</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-4 col-sm-4 col-xs-12">
                    <div class="slider-sd-portion">
                        <img src="images/duck-pot2.jpg" alt="duck-pot.jpg" class="img-responsive">
                        <div class="sldr-sd-caption">
                            <h3>Today's top deal</h1>
                            <p>buy now !</p>
                        </div>
                    </div>
                    <div class="slider-sd-portion">
                        <img src="images/ball-fl.jpg" alt="ball-fl.jpg" class="img-responsive">
                        <div class="sldr-sd-caption">
                            <h3>sports equipment</h1>
                            <p>buy now !</p>
                        </div>
                    </div> 
                </div>
            </div>
        </div>
    </section> <!-- end of slider seciton -->

    <section class="today-item-section">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="item-sector">
                        <div class="item-sec-title pull-left">
                            <h1>TODAY'S ACTION</h1>
                        </div>
                        <div class="item-sec-view pull-right">
                            <a href="#" class="btn btn-default btn-item-vew">VIEW ALL</a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
            <asp:PlaceHolder ID = "PlaceHolder1" runat="server"/>
                <%--<div class="col-md-3 col-sm-6 col-xs-12">
                    <div class="action-item-sec text-center">
                        <img src="images/action-item-logo.png" alt="action-item-logo.png">
                        <p>2011 Chevy, Building Materials,<br> Tools, Etc</p>
                        <a href="#" class="btn btn-danger btn-block">View Details</a>
                        <div class="action-timing-sec">
                            <p>live</p>
                        </div>
                    </div>
                </div> <!-- end of the turning col -->
                

                <div class="col-md-3 col-sm-6 col-xs-12">
                    <div class="action-item-sec text-center">
                        <img src="images/action-item-logo.png" alt="action-item-logo.png">
                        <p>2011 Chevy, Building Materials,<br> Tools, Etc</p>
                        <a href="#" class="btn btn-danger btn-block">View Details</a>
                        <div class="action-timing-sec">
                            <p>20: 36: 59</p>
                        </div>
                    </div>
                </div> <!-- end of the turning col -->
                <div class="col-md-3 col-sm-6 col-xs-12">
                    <div class="action-item-sec text-center">
                        <img src="images/action-item-logo.png" alt="action-item-logo.png">
                        <p>2011 Chevy, Building Materials,<br> Tools, Etc</p>
                        <a href="#" class="btn btn-danger btn-block">View Details</a>
                        <div class="action-timing-sec">
                            <p>20: 36: 59 </p>
                        </div>
                    </div>
                </div> <!-- end of the turning col -->
                <div class="col-md-3 col-sm-6 col-xs-12">
                    <div class="action-item-sec text-center">
                        <img src="images/action-item-logo.png" alt="action-item-logo.png">
                        <p>2011 Chevy, Building Materials,<br> Tools, Etc</p>
                        <a href="#" class="btn btn-danger btn-block">View Details</a>
                        <div class="action-timing-sec">
                            <p>live</p>
                        </div>
                    </div>
                </div> <!-- end of the turning col -->
                <div class="col-md-3 col-sm-6 col-xs-12">
                    <div class="action-item-sec text-center">
                        <img src="images/action-item-logo.png" alt="action-item-logo.png">
                        <p>2011 Chevy, Building Materials,<br> Tools, Etc</p>
                        <a href="#" class="btn btn-danger btn-block">View Details</a>
                        <div class="action-timing-sec">
                            <p>live</p>
                        </div>
                    </div>
                </div> <!-- end of the turning col -->
                <div class="col-md-3 col-sm-6 col-xs-12">
                    <div class="action-item-sec text-center">
                        <img src="images/action-item-logo.png" alt="action-item-logo.png">
                        <p>2011 Chevy, Building Materials,<br> Tools, Etc</p>
                        <a href="#" class="btn btn-danger btn-block">View Details</a>
                        <div class="action-timing-sec">
                            <p>20: 36: 59</p>
                        </div>
                    </div>
                </div> <!-- end of the turning col -->
                <div class="col-md-3 col-sm-6 col-xs-12">
                    <div class="action-item-sec text-center">
                        <img src="images/action-item-logo.png" alt="action-item-logo.png">
                        <p>2011 Chevy, Building Materials,<br> Tools, Etc</p>
                        <a href="#" class="btn btn-danger btn-block">View Details</a>
                        <div class="action-timing-sec">
                            <p>20: 36: 59</p>
                        </div>
                    </div>
                </div> <!-- end of the turning col -->
                <div class="col-md-3 col-sm-6 col-xs-12">
                    <div class="action-item-sec text-center">
                        <img src="images/action-item-logo.png" alt="action-item-logo.png">
                        <p>2011 Chevy, Building Materials,<br> Tools, Etc</p>
                        <a href="#" class="btn btn-danger btn-block">View Details</a>
                        <div class="action-timing-sec">
                            <p>live</p>
                        </div>
                    </div>
                </div> <!-- end of the turning col -->--%>
            </div>
        </div>
    </section> <!-- end of action item section -->

    <section class="item-carousel-sec">
        <div class="container">
            <div class="row">
                <div class="col-md-10 col-md-offset-1">
                    <div class="item-carousel-title text-center">
                        <h2>Coming Soon</h2>
                    </div>
                    <div class="item-carousel-item-sec">
                        <div class="carousel slide" data-ride="carousel" data-type="multi" data-interval="3000" id="myCarousel">
                  <div class="carousel-inner">
                    <div class="item active"> 
                        <div class="col-md-3 col-sm-6 col-xs-12">
                            <a href="#"><img src="images/item-slider1.jpg" class="img-responsive"></a>
                        </div>
                    </div>
                    <div class="item">
                        <div class="col-md-3 col-sm-6 col-xs-12">
                            <a href="#"><img src="images/item-slider2.jpg" class="img-responsive"></a>
                        </div>
                    </div>
                    <div class="item">
                        <div class="col-md-3 col-sm-6 col-xs-12">
                            <a href="#"><img src="images/item-slider3.jpg" class="img-responsive"></a>
                        </div>
                    </div>
                    <div class="item">
                        <div class="col-md-3 col-sm-6 col-xs-12">
                            <a href="#"><img src="images/item-slider1.jpg" class="img-responsive"></a>
                        </div>
                    </div>
                    <div class="item">
                        <div class="col-md-3 col-sm-6 col-xs-12">
                            <a href="#"><img src="images/item-slider2.jpg" class="img-responsive"></a>
                        </div>
                    </div>
                    <div class="item">
                        <div class="col-md-3 col-sm-6 col-xs-12">
                            <a href="#"><img src="images/item-slider3.jpg" class="img-responsive"></a>
                        </div>
                    </div>
                    <div class="item">
                        <div class="col-md-3 col-sm-6 col-xs-12">
                            <a href="#"><img src="images/item-slider1.jpg" class="img-responsive"></a>
                        </div>
                    </div>
                    <div class="item">
                        <div class="col-md-3 col-sm-6 col-xs-12">
                            <a href="#"><img src="images/item-slider2.jpg" class="img-responsive"></a>
                        </div>
                    </div>
                  </div> <!-- end of carousel-inner -->
                  <a class="left carousel-control" href="#myCarousel" data-slide="prev"><img src="images/item-car-lt-ctrl.png" alt=""></a>
                  <a class="right carousel-control crsl-ctrl-rt" href="#myCarousel" data-slide="next"><img src="images/item-car-rt-ctrl.png" alt=""></a>
                </div>
                    </div>
                </div> 
            </div>
        </div>
    </section> <!-- end of item carousel  section -->

    <section class="today-item-section">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="item-sector">
                        <div class="item-sec-title pull-left">
                            <h1>TODAY'S DEAL</h1>
                        </div>
                        <div class="item-sec-view pull-right">
                            <a href="#" class="btn btn-default btn-item-vew">VIEW ALL</a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 col-sm-6 col-xs-12">
                    <div class="action-item-del-sec">
                        <div class="deal-pic"> <!-- image must be 260*210px -->
                            <img src="images/frize2.jpg" alt="frize.jpg" class="img-responsive">
                        </div>
                        <div class="deal-pic-caption">
                            <div class="deal-pic-caption-title">
                                <p>Haier 565 L Frost Free Side by Side  Refrigerator.</p>
                            </div>
                            <div class="time-button">
                                <div class="pull-left"><a href="#" class="btn btn-danger">BUY NOW !</a></div>
                                <div class="pull-right"><p>20h : 11m : 20s Left</p></div>
                            </div>
                        </div>
                    </div>
                </div> <!-- end of the turning col -->
                <div class="col-md-4 col-sm-6 col-xs-12">
                    <div class="action-item-del-sec">
                        <div class="deal-pic">
                            <img src="images/deal-shoe.png" alt="deal-shoe.png" class="img-responsive">
                        </div>
                        <div class="deal-pic-caption">
                            <div class="deal-pic-caption-title">
                                <p>Haier 565 L Frost Free Side by Side  Refrigerator.</p>
                            </div>
                            <div class="time-button">
                                <div class="pull-left"><a href="#" class="btn btn-danger">BUY NOW !</a></div>
                                <div class="pull-right"><p>20h : 11m : 20s Left</p></div>
                            </div>
                        </div>
                    </div>
                </div> <!-- end of the turning col -->
                <div class="col-md-4 col-sm-6 col-xs-12">
                    <div class="action-item-del-sec">
                        <div class="deal-pic">
                            <img src="images/deal-laptop.png" alt="deal-laptop.png" class="img-responsive">
                        </div>
                        <div class="deal-pic-caption">
                            <div class="deal-pic-caption-title">
                                <p>Haier 565 L Frost Free Side by Side  Refrigerator.</p>
                            </div>
                            <div class="time-button">
                                <div class="pull-left"><a href="#" class="btn btn-danger">BUY NOW !</a></div>
                                <div class="pull-right"><p>20h : 11m : 20s Left</p></div>
                            </div>
                        </div>
                    </div>
                </div> <!-- end of the turning col -->
                <div class="col-md-4 col-sm-6 col-xs-12">
                    <div class="action-item-del-sec">
                        <div class="deal-pic">
                            <img src="images/deal-mouse.png" alt="deal-mouse.png" class="img-responsive">
                        </div>
                        <div class="deal-pic-caption">
                            <div class="deal-pic-caption-title">
                                <p>Haier 565 L Frost Free Side by Side  Refrigerator.</p>
                            </div>
                            <div class="time-button">
                                <div class="pull-left"><a href="#" class="btn btn-danger">BUY NOW !</a></div>
                                <div class="pull-right"><p>20h : 11m : 20s Left</p></div>
                            </div>
                        </div>
                    </div>
                </div> <!-- end of the turning col -->
                <div class="col-md-4 col-sm-6 col-xs-12">
                    <div class="action-item-del-sec">
                        <div class="deal-pic">
                            <img src="images/deal-nekless.png" alt="deal-nekless.png" class="img-responsive">
                        </div>
                        <div class="deal-pic-caption">
                            <div class="deal-pic-caption-title">
                                <p>Haier 565 L Frost Free Side by Side  Refrigerator.</p>
                            </div>
                            <div class="time-button">
                                <div class="pull-left"><a href="#" class="btn btn-danger">BUY NOW !</a></div>
                                <div class="pull-right"><p>20h : 11m : 20s Left</p></div>
                            </div>
                        </div>
                    </div>
                </div> <!-- end of the turning col -->
                <div class="col-md-4 col-sm-6 col-xs-12">
                    <div class="action-item-del-sec">
                        <div class="deal-pic">
                            <img src="images/deal-bag.png" alt="deal-bag.png" class="img-responsive">
                        </div>
                        <div class="deal-pic-caption">
                            <div class="deal-pic-caption-title">
                                <p>Haier 565 L Frost Free Side by Side  Refrigerator.</p>
                            </div>
                            <div class="time-button">
                                <div class="pull-left"><a href="#" class="btn btn-danger">BUY NOW !</a></div>
                                <div class="pull-right"><p>20h : 11m : 20s Left</p></div>
                            </div>
                        </div>
                    </div>
                </div> <!-- end of the turning col -->
            </div>
        </div>
    </section> <!-- end of action item section -->

    <!---------------  MODAL WINDOW ---------------------------->
    
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

    <!---------------- END OF MODAL WINDOW --------------------->

</asp:Content>
