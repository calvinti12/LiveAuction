<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="live-auction.aspx.cs" Inherits="LiveAuction.live_auction"
    MasterPageFile="~/Bidder.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="js/custom.js" type="text/javascript"></script>
    <script src="js/LiveAuction.js" type="text/javascript"></script>
    <!-- this is the breadcumbs area -->
    <section class="breadcumbs-area-sec">
         <div class="container">
             <div class="row">
                 <div class="col-md-12">
                     <div class="breadcumb">
                     <a href="index.aspx" class="incative">Home &raquo; </a>Live Auctions &raquo;</div>
                 </div>
             </div>
         </div>
     </section>
    <!-- end of breadcumbs area -->
    <!-- this is the start of category display sell page -->
    <section class="category-sell">
		<div class="container">
			<div class="row"> 
				<div class="col-md-9 col-sm-12 col-xs-12">
                    <div class="bid-details sadow">
                        <div class="row">
                        <%--<asp:PlaceHolder ID = "PlaceHolderCurrentLot" runat="server"/>--%>
                        <div class="col-md-6 col-sm-6 col-xs-12" id='currentLot'>
                        <%--<div class="category-sell-item-full-sec">
								<div class="category-sell-pic">
									<img src="images/tt.jpg" alt="this is for selling item images" class="img-responsive" />
								</div>
								<div class="category-sell-pic-caption text-center">
									<h1>current lot 101</h1>
								</div>
							</div>
							<div class="category-sell-item-des-sec">
								<h3 class="text-primary">CP 09 05 sujuki witch hatchback 5 seats 4 doors</h3>
								<p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type <a href="#" class="text-info">specimen book. It has survived not</a>  only five</p>
							</div>--%>
						</div>
						<div class="col-md-6 col-sm-6 col-xs-12 ">
							<div class="category-curent-itm-dis">
								<div class="">
								  <div class="">
								     
                                    <div class="ttll-pnl-foot clearfix">
								  		<div class="asking clearfix">
											<h2 >Asking Bid</h2>
                                            <div class="alert alert-danger" role="alert" id="blink"></div>
                                            <div class="lot-doll clearfix">
                                                <div class="pull-left">
                                                    <h1 class="text-danger pull-left"><span id='askingBidPrice'class="price01"></span></h1>
                                                    <span id='signInAlert' class="text-danger"></span>
                                                </div>
                                                <div class="pull-right">
                                                    <div class="fair-burn" id="ButtonPlace">
                                                        <a href='#' id='bidBtn' class="btn btn-primary btn-lg btn-bid">Bid</a>
                                                    </div>
                                                </div>
                                            </div>
										</div>
								  	</div>
                                    <div class="cat-it-dis">
								    	<%--<p class="text-success">successfully conected to server</p>--%>
								    	<div class="wel-message text-center" style="font-size:12px;">
                                            <p class="text-center text-success" id="liveBidLogs"></p>
                                        </div>
								    </div>
								  </div>
								  
								</div>
							</div>
						</div>
                        <div class="col-md-12" id="currentLotDesc">
                            <%--<div class="category-sell-item-des-sec">
                                <h3 class="text-primary">Auction : <span id="currentLotAuctionName">Chorley Auction House</span></h3>
                                <p id="currentLotDesc">Test description</p>
                                <p>Low estimate price&nbsp;-&nbsp;<span id="currentLotLowEstimatePrice">£500</span></p>
                                <p>High estimate price&nbsp;-&nbsp;<span id="currentLotHighEstimatePrice">£700</span></p>
                            </div>--%>
                            <div class=""></div>
                        </div>
					</div>
                    </div>
				</div> 
				<div class="col-md-3 col-sm-12 col-xs-12">
                    <div class="bid-details sadow">
                        <div class="upcoming-lttitle"><h3>Lots</h3></div>
                        <div class="catergory-sell-item-sw clearfix" id="lotQueue">
                           <%-- <div class="cat-sell-single-item clearfix">
                                <div class="pull-left">
                                    <div class="cat-sell-pic">
                                        <img src="images/700.jpg" />
                                    </div>
                                    <div class="lot-st">
                                        <p>Lot 1</p>
                                    </div>
                                </div>
                                <div class="pull-left">
                                    <div class="cat-sell-dis">
                                        <p>Tow bottle of scots single</p>
                                    </div>
                                </div>
                            </div>--%>
                        </div>
                            <%--<div class="catergory-sell-item-sw clearfix" id="lotQueue">--%>
                            <%--<asp:PlaceHolder ID = "PlaceHolderQueueLot" runat="server"/>--%>
					    </div>

                         <div class="bid-details sadow"> 
							<h4>Live video</h4>
                            <div class="">
                                <video width="100%" height="150" controls  poster="video_contents/video.gif">
                                <%--<source src="video_contents/movie.mp4" type="video/mp4">
                                <source src="video_contents/movie.ogg" type="video/ogg">--%>
                                Your browser does not support the video tag.
                                </video> 
                            </div>
						</div>
                    </div>
				</div>
            
			</div>
		</div>

	</section>
    <!-- this is the start of category display  sell page -->
</asp:Content>
