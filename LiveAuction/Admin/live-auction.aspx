<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="live-auction.aspx.cs" Inherits="LiveAuction.Admin.live_auction_admin"
    MasterPageFile="~/Admin/Admin.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="js/custom.js" type="text/javascript"></script>
    <%--<script src="js/LiveAuction.js" type="text/javascript"></script>--%>
    <script src="../js/LiveAuction.js" type="text/javascript"></script>
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
                        <div class="col-md-6 col-sm-6 col-xs-12" id='currentLot'>
						</div>
						<div class="col-md-6 col-sm-6 col-xs-12 ">
							<div class="category-curent-itm-dis">
								<div class="">
								  <div class="">
								     
                                    <div class="ttll-pnl-foot clearfix">
								  		<div class="asking clearfix">
											<h2 >Asking Bid</h2>
                                            <div class="alert alert-danger alert-bid" role="alert" id="blink"></div>
                                            
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
                                        <div class="alert alert-warning text-center" role="alert" id="liveBidLogs"> </div>
								    </div>
                                    <div class="frbtn clearfix">
	                                    <button type="button" class="btn btn-danger pull-left" id="fairBtn">FAIR WARNING</button>
	                                    <button type="button" class="btn btn-danger pull-right" id="soldBtn">SOLD</button>
                                    </div>
								  </div>
								  
								</div>
							</div>
						</div>
                        <div class="col-md-12" id="currentLotDesc">
                            <div class=""></div>
                        </div>
					</div>
                    </div>
				</div> 
				<div class="col-md-3 col-sm-12 col-xs-12">
                    <div class="bid-details sadow">
                        <div class="upcoming-lttitle"><h3>Lots</h3></div>
                        <div class="catergory-sell-item-sw clearfix" id="lotQueue">
                        </div>
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
