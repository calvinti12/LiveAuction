<%@ Page Language="C#" MasterPageFile="~/Bidder.Master" AutoEventWireup="true" CodeBehind="CatDisplay.aspx.cs"
    Inherits="LiveAuction.CatDisplay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- this is the breadcumbs area -->
    <section class="breadcumbs-area-sec">
         <div class="container">
             <div class="row">
                 <div class="col-md-12">
                     <div class="breadcumb">
                     <a href="#" class="incative">Home &raquo; </a><a href="#" class="incative">Live Auctions &raquo; </a><span class="current-page">Registration</span></div>
                 </div>
             </div>
         </div>
     </section>
    <!-- end of breadcumbs area -->
    <!-- this is the start of category display page -->
    <section class="cat_display">
        <div class="container">
          <div class="row">
            <div class="col-md-3">
              <div class="cr-accnt">
                  <div class="account-selling-lstItem-sec">
                    <div class="account-selling-title">
                    <asp:PlaceHolder ID="SubCategoryHeading" runat="server" />
                    </div>
                    <div class="account-selling-lstItem">
                      <ul class="list-unstyled">
                        <%--<li><a href="dashboard.html">Dashboard</a></li>
                        <li><a href="advertise.html">Advertise</a></li>
                        <li><a href="sell-item.html">Items</a></li>
                        <li><a href="item-auction.html">Auctions</a></li>
                        <li><a href="item-csv.html">CSV Auctions</a></li>--%>
                        <asp:PlaceHolder ID="PlaceHolderSubCategory" runat="server" />
                      </ul>
                    </div>
                  </div><!-- end of item accont selling -->

                  
                </div> <!-- end of cr-accnt for left sideber -->
            </div> <!-- end of left coloum -->
            <div class="col-md-9">
              <div class="cat-item-tl-sec">
                <div class="cat-item-title">
                  <asp:PlaceHolder ID="CategoryHeading" runat="server" />
                </div>

                <div class="row">
                <asp:PlaceHolder ID="PlaceHolderCatagoriesMainContainer" runat="server" />
                  <%--<div class="col-md-4">
                    <div class="action-item-del-sec cat-item-sec">
                        <div class="deal-pict">
                            <img src="images/deal-bag.png" alt="deal-bag.png" class="img-responsive">
                        </div>
                        <div class="deal-pic-caption">
                            <div class="deal-pic-caption-title">
                                <p>Haier 565 L Frost Free Side by Side  Refrigerator.</p>
                            </div>
                            <div class="time-butt clearfix">
                                <div class="pull-left">
                                  <span><i class="fa fa-heart-o" aria-hidden="true"></i></span>&nbsp;&nbsp;<span>10</span>
                                </div>
                                <div class="pull-right">
                                  <span><i class="fa fa-shopping-cart" aria-hidden="true"></i></span>&nbsp;&nbsp;<span>$450</span>
                                </div>
                            </div>
                        </div>
                    </div>
                  </div>  <!-- end of cat-item-sec -->
                  <div class="col-md-4">
                    <div class="action-item-del-sec cat-item-sec">
                        <div class="deal-pict">
                            <img src="images/deal-bag.png" alt="deal-bag.png" class="img-responsive">
                        </div>
                        <div class="deal-pic-caption">
                            <div class="deal-pic-caption-title">
                                <p>Haier 565 L Frost Free Side by Side  Refrigerator.</p>
                            </div>
                            <div class="time-butt clearfix">
                                <div class="pull-left">
                                  <span><i class="fa fa-heart-o" aria-hidden="true"></i></span>&nbsp;&nbsp;<span>10</span>
                                </div>
                                <div class="pull-right">
                                  <span><i class="fa fa-shopping-cart" aria-hidden="true"></i></span>&nbsp;&nbsp;<span>$450</span>
                                </div>
                            </div>
                        </div>
                    </div>
                  </div>  <!-- end of cat-item-sec -->
                  <div class="col-md-4">
                    <div class="action-item-del-sec cat-item-sec">
                        <div class="deal-pict">
                            <img src="images/deal-bag.png" alt="deal-bag.png" class="img-responsive">
                        </div>
                        <div class="deal-pic-caption">
                            <div class="deal-pic-caption-title">
                                <p>Haier 565 L Frost Free Side by Side  Refrigerator.</p>
                            </div>
                            <div class="time-butt clearfix">
                                <div class="pull-left">
                                  <span><i class="fa fa-heart-o" aria-hidden="true"></i></span>&nbsp;&nbsp;<span>10</span>
                                </div>
                                <div class="pull-right">
                                  <span><i class="fa fa-shopping-cart" aria-hidden="true"></i></span>&nbsp;&nbsp;<span>$450</span>
                                </div>
                            </div>
                        </div>
                    </div>
                  </div>  <!-- end of cat-item-sec -->
                  <div class="col-md-4">
                    <div class="action-item-del-sec cat-item-sec">
                        <div class="deal-pict">
                            <img src="images/deal-bag.png" alt="deal-bag.png" class="img-responsive">
                        </div>
                        <div class="deal-pic-caption">
                            <div class="deal-pic-caption-title">
                                <p>Haier 565 L Frost Free Side by Side  Refrigerator.</p>
                            </div>
                            <div class="time-butt clearfix">
                                <div class="pull-left">
                                  <span><i class="fa fa-heart-o" aria-hidden="true"></i></span>&nbsp;&nbsp;<span>10</span>
                                </div>
                                <div class="pull-right">
                                  <span><i class="fa fa-shopping-cart" aria-hidden="true"></i></span>&nbsp;&nbsp;<span>$450</span>
                                </div>
                            </div>
                        </div>
                    </div>
                  </div>  <!-- end of cat-item-sec -->
                  <div class="col-md-4">
                    <div class="action-item-del-sec cat-item-sec">
                        <div class="deal-pict">
                            <img src="images/deal-bag.png" alt="deal-bag.png" class="img-responsive">
                        </div>
                        <div class="deal-pic-caption">
                            <div class="deal-pic-caption-title">
                                <p>Haier 565 L Frost Free Side by Side  Refrigerator.</p>
                            </div>
                            <div class="time-butt clearfix">
                                <div class="pull-left">
                                  <span><i class="fa fa-heart-o" aria-hidden="true"></i></span>&nbsp;&nbsp;<span>10</span>
                                </div>
                                <div class="pull-right">
                                  <span><i class="fa fa-shopping-cart" aria-hidden="true"></i></span>&nbsp;&nbsp;<span>$450</span>
                                </div>
                            </div>
                        </div>
                    </div>
                  </div>  <!-- end of cat-item-sec -->
                  <div class="col-md-4">
                    <div class="action-item-del-sec cat-item-sec">
                        <div class="deal-pict">
                            <img src="images/deal-bag.png" alt="deal-bag.png" class="img-responsive">
                        </div>
                        <div class="deal-pic-caption">
                            <div class="deal-pic-caption-title">
                                <p>Haier 565 L Frost Free Side by Side  Refrigerator.</p>
                            </div>
                            <div class="time-butt clearfix">
                                <div class="pull-left">
                                  <span><i class="fa fa-heart-o" aria-hidden="true"></i></span>&nbsp;&nbsp;<span>10</span>
                                </div>
                                <div class="pull-right">
                                  <span><i class="fa fa-shopping-cart" aria-hidden="true"></i></span>&nbsp;&nbsp;<span>$450</span>
                                </div>
                            </div>
                        </div>
                    </div>
                  </div>  <!-- end of cat-item-sec -->
                  <div class="col-md-4">
                    <div class="action-item-del-sec cat-item-sec">
                        <div class="deal-pict">
                            <img src="images/deal-bag.png" alt="deal-bag.png" class="img-responsive">
                        </div>
                        <div class="deal-pic-caption">
                            <div class="deal-pic-caption-title">
                                <p>Haier 565 L Frost Free Side by Side  Refrigerator.</p>
                            </div>
                            <div class="time-butt clearfix">
                                <div class="pull-left">
                                  <span><i class="fa fa-heart-o" aria-hidden="true"></i></span>&nbsp;&nbsp;<span>10</span>
                                </div>
                                <div class="pull-right">
                                  <span><i class="fa fa-shopping-cart" aria-hidden="true"></i></span>&nbsp;&nbsp;<span>$450</span>
                                </div>
                            </div>
                        </div>
                    </div>
                  </div>  <!-- end of cat-item-sec -->--%>
                </div>
              </div>
            </div>
          </div>
        </div>
      </section>
    <!-- this is the start of category display page -->
</asp:Content>
