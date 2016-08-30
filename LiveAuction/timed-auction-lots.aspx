<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="timed-auction-lots.aspx.cs"
    Inherits="LiveAuction.timed_auction_lots" MasterPageFile="~/Bidder.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="js/custom.js" type="text/javascript"></script>
    <script src="js/TimedAuction.js" type="text/javascript"></script>
    <!-- this is the breadcumbs area -->
    <section class="breadcumbs-area-sec">
         <div class="container">
             <div class="row">
                 <div class="col-md-12">
                     <div class="breadcumb">
                     <a href="index.aspx" class="incative">Home &raquo; </a>Timed Auctions &raquo;</div>
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
                                    <div class="fair-burn" id="Div1">
                                        <a href="#" id='A1' class="btn btn-primary btn-lg btn-bid buyNowPriceId " data-toggle="tooltip" title="
                                        Suspendisse hendrerit iaculis quam, ut tempor magna aliquet at. In mollis a ex ac bibendum. Curabitur venenatis egestas ante faucibus tempor.
                                        " data-placement="bottom"></a>
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
                    </div>
				</div>
            
			</div>
		</div>

	</section>
    <!-- this is the start of category display  sell page -->
</asp:Content>
