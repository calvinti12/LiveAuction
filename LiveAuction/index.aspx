<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Bidder.Master" CodeBehind="index.aspx.cs"
    Inherits="LiveAuction.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="js/custom.js" type="text/javascript"></script>
    <script src="Scripts/angular.js" type="text/javascript"></script>
    <script src="Scripts/angular-route.js" type="text/javascript"></script>
    <section class="slider-section">
        <div class="container">
            <div class="row">
                <div class="col-md-8 col-sm-8 col-xs-12">
                    <div class="watch-sl-sec">
                        <img src="images/slider1.jpg" alt="" class="img-responsive">
                        <div class="watch-caption main-slider-caption">
                            <h2><strong>Come along to our free Friday morning valuations between 10am -1pm</strong></h2>
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
                            <h3>We are now welcoming consignments for our October sale, including Oriental Porcelain!</h1>
                            <p>buy now !</p>
                        </div>
                    </div> 
                </div>
            </div>
        </div>
    </section>
    <!-- end of slider seciton -->
    <section class="today-item-section">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="item-sector">
                        <div class="item-sec-title pull-left">
                        <%--<script type="text/javascript">
                            $(function () {
                                var austDay = new Date();
                                austDay = new Date("2016-07-07T12:00:00");
                                console.log(austDay);
                                $('#counterDiv').countdown({ until: austDay, compact: true,
                                    format: 'DHMS', description: ''
                                });
                            });
                        </script>
                        <div id="counterDiv">ghhh</div>--%>
                            <h1>UPCOMING AUCTIONS</h1>
                        </div>
                        <div class="item-sec-view pull-right">
                            <a href="CatDisplay.aspx?cat=AllAuctions" class="btn btn-default btn-item-vew">VIEW ALL</a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
            <asp:PlaceHolder ID = "PlaceHolder1" runat="server"/>
            </div>
        </div>
    </section>
    <!-- end of action item section -->
    <section class="item-carousel-sec">
        <div class="container">
            <div class="row">
                <div class="col-md-10 col-md-offset-1">
                    <div class="item-carousel-title text-center">
                        <h2>Coming Soon</h2>
                    </div>
                    <div class="item-carousel-item-sec">
                        <div class="carousel slide" data-ride="carousel" data-type="multi" data-interval="3000" id="myCarousel">
                  <div class="carousel-inner sp-cr-inn">
                    <div class="item active"> 
                        <div class="col-md-3 col-sm-6 col-xs-12">
                            <a href="#"><img src="images/20.jpg" class="img-responsive"></a>
                        </div>
                    </div>
                    <div class="item">
                        <div class="col-md-3 col-sm-6 col-xs-12">
                            <a href="#"><img src="images/228.jpg" class="img-responsive"></a>
                        </div>
                    </div>
                    <div class="item">
                        <div class="col-md-3 col-sm-6 col-xs-12">
                            <a href="#"><img src="images/235.jpg" class="img-responsive"></a>
                        </div>
                    </div>
                    <div class="item">
                        <div class="col-md-3 col-sm-6 col-xs-12">
                            <a href="#"><img src="images/25.jpg" class="img-responsive"></a>
                        </div>
                    </div>
                    <div class="item">
                        <div class="col-md-3 col-sm-6 col-xs-12">
                            <a href="#"><img src="images/880.jpg" class="img-responsive"></a>
                        </div>
                    </div>
                    <div class="item">
                        <div class="col-md-3 col-sm-6 col-xs-12">
                            <a href="#"><img src="images/959.jpg" class="img-responsive"></a>
                        </div>
                    </div>
                    <div class="item">
                        <div class="col-md-3 col-sm-6 col-xs-12">
                            <a href="#"><img src="images/713.jpg" class="img-responsive"></a>
                        </div>
                    </div>
                    <div class="item">
                        <div class="col-md-3 col-sm-6 col-xs-12">
                            <a href="#"><img src="images/700.jpg" class="img-responsive"></a>
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
    </section>
    <!-- end of item carousel  section -->
    <section class="today-item-section">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="item-sector">
                        <div class="item-sec-title pull-left">
                            <h1>TODAY'S DEALS</h1>
                        </div>
                        <div class="item-sec-view pull-right">
                            <a href="CatDisplay.aspx?dcat=AllDeals" class="btn btn-default btn-item-vew">VIEW ALL</a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <%--<div class="col-md-4 col-sm-6 col-xs-12">
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
                </div> <!-- end of the turning col -->--%>
                <asp:PlaceHolder ID="TodaysDealPlaceholder" runat="server"></asp:PlaceHolder>
            </div>
        </div>
    </section>
    <!-- end of action item section -->
    <asp:PlaceHolder ID="PlaceHolder2" runat="server" />
    <script type="text/javascript">
        //console.log(todayDeal);
        var deal = todayDeal
        $(".todaysAction").click(function () {
            var id = $(".auctionId").val();
            // console.log(id + " clicked");
            //var AuctionName = todayDeal[0].auctionName;
            console.log(deal[1]);
            // $("#myModalLabel").html(AuctionName);
            var path = "./Admin/FileUpload/" + deal[1].auctionImageName;
            console.log(path);
            $(".bid-popup-pic").attr("src", path);
            console.log(pic);
        });
    </script>
</asp:Content>
