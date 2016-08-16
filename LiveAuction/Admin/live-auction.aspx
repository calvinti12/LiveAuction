<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="live-auction.aspx.cs" Inherits="LiveAuction.Admin.live_auction_admin"
    MasterPageFile="~/Admin/Admin.Master" %>

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
				<div class="col-md-8 col-sm-12 col-xs-12">
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
						<div class="col-md-6 col-sm-6 col-xs-12">
							<div class="category-curent-itm-dis">
								<div class="panel panel-default">
								  <div class="panel-heading">
                                    <div class="cat-it-dis">
								    	<%--<p class="text-success">successfully conected to server</p>--%>
								    	<div class="wel-message text-center" style="font-size:12px;">
                                            <p class="text-center text-success" id="liveBidLogs">admin placed the bid at 15</p>
                                        </div>
								    </div>
								    <div class="ttll-pnl-foot clearfix">
								  		<div class="pull-left">
											<h2>Asking Bid</h2>
                                            <%--<asp:PlaceHolder ID="PlaceHolderAskingBid" runat="server"></asp:PlaceHolder--%>
                                           <h1 class="text-danger"><span id='askingBidPrice'></span></h1>
										</div>
                                        <div class="pull-left" style="margin-left:10%;color:#a94442">
											<%--<h4 id="counterDiv">30sec</h4>--%>
                                            
										</div>
										<div class="pull-right">
                                            <button type="button" class="btn btn-danger" id="fairBtn">FAIR WARNING</button>
                                            <button type="button" class="btn btn-danger" id="soldBtn">SOLD</button>
                                            <a href='#' class='bidBtn'><h1 class='bg-primary' style="text-align: center;">Bid</h1></a>
										</div>
								  	</div>
								  </div>
								  <div class="panel-body">
                                    <div class="catergory-sell-item-sw clearfix" id="lotQueue">
                                        <%--<asp:PlaceHolder ID = "PlaceHolderQueueLot" runat="server"/>--%>
					                </div>
								  </div>
								</div>
							</div>
						</div>
					</div>
				</div>
				<div class="col-md-4 col-sm-12 col-xs-12">
                    <h3 class="text-primary panel-ttle-cat">Live video</h3>
                    <div class="">
                        <video width="320" height="240" controls  poster="video_contents/video.gif">
                        <%--<source src="video_contents/movie.mp4" type="video/mp4">
                        <source src="video_contents/movie.ogg" type="video/ogg">--%>
                        Your browser does not support the video tag.
                        </video> 
                        </div>
				</div>
			</div>
		</div>

	</section>
    <!-- this is the start of category display  sell page -->
</asp:Content>
