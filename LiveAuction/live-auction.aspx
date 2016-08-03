<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="live-auction.aspx.cs" Inherits="LiveAuction.live_auction"
    MasterPageFile="~/Bidder.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="js/custom.js" type="text/javascript"></script>
    <script src="Scripts/angular.js" type="text/javascript"></script>
    <script src="Scripts/angular-route.js" type="text/javascript"></script>
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
                        <asp:PlaceHolder ID = "PlaceHolderCurrentLot" runat="server"/>
						<div class="col-md-6 col-sm-6 col-xs-12">
							<div class="category-curent-itm-dis">
								<div class="panel panel-default">
								  <div class="panel-heading">
								    <h3 class="text-primary panel-ttle-cat">Live video</h3>
								    <%--<p class="text-info">Arcle load basic</p>--%>
                                    <div class="">
                                     <video width="320" height="240" controls  poster="video_contents/video.gif">
                                        <source src="video_contents/movie.mp4" type="video/mp4">
                                        <source src="video_contents/movie.ogg" type="video/ogg">
                                        Your browser does not support the video tag.
                                     </video> 
                                     </div>
								    <%--<p class="text-info">Damage vichels</p>--%>
								  </div>
								  <div class="panel-body">
								    <div class="cat-it-dis">
								    	<p class="text-success">successfully conected to server</p>
								    	<div class="wel-message">
								    		<p>welcome</p>
								    		<p><span>This is now</span>&nbsp;&nbsp;<span>thu march 3 3:32(Est)</span></p>
								    		<p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum</p>
								    	</div>
								    </div>
								  </div>
								  <div class="panel-footer">
								  	<div class="ttll-pnl-foot clearfix">
								  		<div class="pull-left">
											<h2>Asking Bid</h2>
											<h1 class="text-danger">AU$ <span>0</span></h1>
										</div>
										<div class="pull-right">
											<a href="#"><h1 class="bg-primary">Bid</h1></a>
										</div>
								  	</div>
								  </div>
								</div>
							</div>
						</div>
					</div>
				</div>
				<div class="col-md-4 col-sm-12 col-xs-12">
					<div class="catergory-sell-item-sw clearfix">
                        <asp:PlaceHolder ID = "PlaceHolderQueueLot" runat="server"/>
						<%--<div class="cat-sell-single-item clearfix">
							<div class="cat-sell-title">
								<p><span class="text-primary">Lot 102</span>&nbsp;&nbsp; <span><a href="#" class="text-muted">Add to wish list</a></span></p>
							</div>
							<div class="cat-sell-tag">
								<h3>cp 08/98, sujuki, crown vira, wagon, 5 sites, 4 doors</h3>
							</div>
							<div class="cat-sell-pic-sec">
								<div class="cat-sell-snt">
									<img src="images/tt.jpg" alt="this is for cat sell snt" class="img-responsive">
								</div>
								<div class="cat-sell-snt">
									<a href="#" class="text-info">View More</a>
								</div>
							</div>
						</div>
						<div class="cat-sell-single-item clearfix">
							<div class="cat-sell-title">
								<p><span class="text-primary">Lot 102</span>&nbsp;&nbsp; <span><a href="#" class="text-muted">Add to wish list</a></span></p>
							</div>
							<div class="cat-sell-tag">
								<h3>cp 08/98, sujuki, crown vira, wagon, 5 sites, 4 doors</h3>
							</div>
							<div class="cat-sell-pic-sec">
								<div class="cat-sell-snt">
									<img src="images/tt.jpg" alt="this is for cat sell snt" class="img-responsive">
								</div>
								<div class="cat-sell-snt">
									<a href="#" class="text-info">View More</a>
								</div>
							</div>
						</div>
						<div class="cat-sell-single-item clearfix">
							<div class="cat-sell-title">
								<p><span class="text-primary">Lot 102</span>&nbsp;&nbsp; <span><a href="#" class="text-muted">Add to wish list</a></span></p>
							</div>
							<div class="cat-sell-tag">
								<h3>cp 08/98, sujuki, crown vira, wagon, 5 sites, 4 doors</h3>
							</div>
							<div class="cat-sell-pic-sec">
								<div class="cat-sell-snt">
									<img src="images/tt.jpg" alt="this is for cat sell snt" class="img-responsive">
								</div>
								<div class="cat-sell-snt">
									<a href="#" class="text-info">View More</a>
								</div>
							</div>
						</div>
						<div class="cat-sell-single-item clearfix">
							<div class="cat-sell-title">
								<p><span class="text-primary">Lot 102</span>&nbsp;&nbsp; <span><a href="#" class="text-muted">Add to wish list</a></span></p>
							</div>
							<div class="cat-sell-tag">
								<h3>cp 08/98, sujuki, crown vira, wagon, 5 sites, 4 doors</h3>
							</div>
							<div class="cat-sell-pic-sec">
								<div class="cat-sell-snt">
									<img src="images/tt.jpg" alt="this is for cat sell snt" class="img-responsive">
								</div>
								<div class="cat-sell-snt">
									<a href="#" class="text-info">View More</a>
								</div>
							</div>
						</div>
						<div class="cat-sell-single-item clearfix">
							<div class="cat-sell-title">
								<p><span class="text-primary">Lot 102</span>&nbsp;&nbsp; <span><a href="#" class="text-muted">Add to wish list</a></span></p>
							</div>
							<div class="cat-sell-tag">
								<h3>cp 08/98, sujuki, crown vira, wagon, 5 sites, 4 doors</h3>
							</div>
							<div class="cat-sell-pic-sec">
								<div class="cat-sell-snt">
									<img src="images/tt.jpg" alt="this is for cat sell snt" class="img-responsive">
								</div>
								<div class="cat-sell-snt">
									<a href="#" class="text-info">View More</a>
								</div>
							</div>
						</div>--%>
					</div>
				</div>
			</div>
		</div>
	</section>
    <!-- this is the start of category display  sell page -->
</asp:Content>
