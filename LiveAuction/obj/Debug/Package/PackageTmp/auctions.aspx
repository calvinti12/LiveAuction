<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Bidder.Master" CodeBehind="auctions.aspx.cs"
    Inherits="LiveAuction.auctions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="breadcumbs-area-sec">
         <div class="container">
             <div class="row">
                 <div class="col-md-12">
                     <div class="breadcumb">
                     <a href="index.aspx" class="incative">Home &raquo; </a><span class="current-page">Timed Auction</span></div>
                 </div>
             </div>
         </div>
     </section>
    <!-- end of breadcumbs area -->
    <section class="creat-account-sec">
        <div class="container">
            <div class="row">

            <div class="fav-container">
											<div class="row">
												<div class="col-xs-12 col-sm-8 col-md-9 ">
													
													<div>
														<h4 class="auction-title"><a href="#"><%=AuctionType%></a></h4>
													</div>
													<div class="clearfix">
														<h5 class="auction-auctioneer">
															<strong><em class="pull-left">by <%=AuctionName%></em></strong> <i class="fa  text-primary"></i>
														</h5>
													</div>
													<div>
														<h6><em></em></h6>
														<h6>
															
																Ends on 
																<%=AuctionDate%> &nbsp;<%=AuctionTime%> 
														</h6>
														<h6><%=AuctionAddress%></h6>
														
													</div>
												</div>
												<div class="col-xs-12 col-sm-4 col-md-3 auction-btn-group ">
													<div class="hidden-xs visible-sm visible-md visible-lg">
														
																<div class="text-center">
																	<i class="fa fa-clock-o fa-lg blue-text"></i> <span class="blue-text"><strong>Timed</strong></span>
																</div>	
															
													</div>
													<div>
														
																<div class="text-center">
																	<a href="#">Register to Bid</a>
																</div>
																
														<div class="text-center">
															<a href="catalogue.aspx?aid=<%=AuctionId%>" class="btn btn-primary btn-cta">View Catalogue</a>
														</div>
													</div>
												</div>
											</div>
											 
										</div>
                                       

               </div>
        </div>
    </section>
</asp:Content>
