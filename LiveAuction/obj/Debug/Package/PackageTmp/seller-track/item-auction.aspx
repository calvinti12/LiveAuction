<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/seller-track/Seller.Master"
    CodeBehind="item-auction.aspx.cs" Inherits="LiveAuction.seller_track.item_auction" %>

<%@ Register Src="~/UserControl/SellerLeftPanel.ascx" TagName="SellerLeftPanel" TagPrefix="UCSellerLeftPanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $('#liAuctions').addClass('sdmnu-active');
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- this is the breadcumbs area -->
    <section class="breadcumbs-area-sec">
         <div class="container">
             <div class="row">
                 <div class="col-md-12">
                     <div class="breadcumb">
                     <a href="#" class="incative">Home &raquo; </a><span class="current-page">Item Auction</span></div>
                 </div>
             </div>
         </div>
     </section>
    <!-- end of breadcumbs area -->
    <section class="creat-account-sec">
        <div class="container">
            <div class="row">
              <UCSellerLeftPanel:SellerLeftPanel runat="server" ID="SellerLftPnl" />
              <div class="col-md-9">
                <div class="cr-accnt">
                  <div class="tt">
                      <div class="account-creat-title">
                          <h2>Scheduling Statistics</h2>
                      </div>
                  </div>
                  <div class="tt">
                  	<div class="row">
                  		<div class="col-md-6">
	                    	<div class="schduled-big-title">
	                    		<h1>REQUESTED: 1</h1>
	                    	</div>
	                    </div>
	                    <div class="col-md-6">
	                    	<div class="schduled-big-title">
	                    		<h1>SCHEDULED: 4</h1>
	                    	</div>
	                    </div>
                  	</div>
                  </div>
                  <div class="tt">
                  	<div class="sell-higher-vl">
                  		<h3>WANT TO SELL IN HIGHER VOLUME?</h3>
                  		<P>Apply for a <strong>partner Auction</strong>, an exclusive auction event, to sell <strong>50 or more items</strong> in a day.</P>
                  		<button type="button" class="btn btn-primary">Apply Now</button>
                  	</div>
                  </div>
                  <div class="tt">
                  	<div class="aution-table table-responsive">
                  		<table class="table table-condensed">
                  			<thead>
                  				<tr>
                  					<td>Date</td>
                  					<td>Auction Name</td>
                  					<td>Scheduling Fee <i class="fa fa-info-circle" aria-hidden="true"></i></td>
                  					<td>Commission <i class="fa fa-info-circle" aria-hidden="true"></i></td>
                  					<td></td>
                  				</tr>
                  			</thead>
                  			<tbody>
                  				<tr class="active">
                  					<td colspan="5">Live Auction</td>
                  				</tr>
                  				<tr>
                  					<td>6pm sun mar 06</td>
                  					<td>Free Shipping bazar</td>
                  					<td>$0.50</td>
                  					<td>10%</td>
                  					<td><i class="fa fa-calendar-o" aria-hidden="true"></i> Requested to schedule</td>
                  				</tr>
                  				<tr>
                  					<td>6pm sun mar 06</td>
                  					<td>Free Shipping bazar</td>
                  					<td>$0.50</td>
                  					<td>10%</td>
                  					<td><i class="fa fa-calendar-o" aria-hidden="true"></i> Requested to schedule</td>
                  				</tr>
                  				<tr>
                  					<td>6pm sun mar 06</td>
                  					<td>Free Shipping bazar</td>
                  					<td>$0.50</td>
                  					<td>10%</td>
                  					<td><i class="fa fa-calendar-o" aria-hidden="true"></i> Requested to schedule</td>
                  				</tr>
                  				<tr>
                  					<td>6pm sun mar 06</td>
                  					<td>Free Shipping bazar</td>
                  					<td>$0.50</td>
                  					<td>10%</td>
                  					<td><i class="fa fa-calendar-o" aria-hidden="true"></i> Requested to schedule</td>
                  				</tr>
                  				<tr>
                  					<td>6pm sun mar 06</td>
                  					<td>Free Shipping bazar</td>
                  					<td>$0.50</td>
                  					<td>10%</td>
                  					<td><i class="fa fa-calendar-o" aria-hidden="true"></i> Requested to schedule</td>
                  				</tr>
                  				<tr>
                  					<td>6pm sun mar 06</td>
                  					<td>Free Shipping bazar</td>
                  					<td>$0.50</td>
                  					<td>10%</td>
                  					<td>closed</td>
                  				</tr>
                  				<tr>
                  					<td>6pm sun mar 06</td>
                  					<td>Free Shipping bazar</td>
                  					<td>$0.50</td>
                  					<td>10%</td>
                  					<td><i class="fa fa-calendar-o" aria-hidden="true"></i> Requested to schedule</td>
                  				</tr>
                  				<tr class="active">
                  					<td colspan="5">Upcoming Auction</td>
                  				</tr>
                  				<tr>
                  					<td>6pm sun mar 06</td>
                  					<td>Free Shipping bazar</td>
                  					<td>$0.50</td>
                  					<td>10%</td>
                  					<td><i class="fa fa-calendar-o" aria-hidden="true"></i> Requested to schedule</td>
                  				</tr>
                  				<tr>
                  					<td>6pm sun mar 06</td>
                  					<td>Free Shipping bazar</td>
                  					<td>$0.50</td>
                  					<td>10%</td>
                  					<td><i class="fa fa-calendar-o" aria-hidden="true"></i> Requested to schedule</td>
                  				</tr>
                  				<tr>
                  					<td>6pm sun mar 06</td>
                  					<td>Free Shipping bazar</td>
                  					<td>$0.50</td>
                  					<td>10%</td>
                  					<td><i class="fa fa-calendar-o" aria-hidden="true"></i> Requested to schedule</td>
                  				</tr>
                  				<tr class="active">
                  					<td colspan="5">Schudled Auction</td>
                  				</tr>
                  				<tr>
                  					<td>6pm sun mar 06</td>
                  					<td>Free Shipping bazar</td>
                  					<td>$0.50</td>
                  					<td>10%</td>
                  					<td>closed</td>
                  				</tr>
                  				<tr>
                  					<td>6pm sun mar 06</td>
                  					<td>Free Shipping bazar</td>
                  					<td>$0.50</td>
                  					<td>10%</td>
                  					<td><i class="fa fa-calendar-o" aria-hidden="true"></i> Requested to schedule</td>
                  				</tr>
                  				<tr>
                  					<td>6pm sun mar 06</td>
                  					<td>Free Shipping bazar</td>
                  					<td>$0.50</td>
                  					<td>10%</td>
                  					<td><i class="fa fa-calendar-o" aria-hidden="true"></i> Requested to schedule</td>
                  				</tr>
                  				<tr>
                  					<td>6pm sun mar 06</td>
                  					<td>Free Shipping bazar</td>
                  					<td>$0.50</td>
                  					<td>10%</td>
                  					<td><i class="fa fa-calendar-o" aria-hidden="true"></i> Requested to schedule</td>
                  				</tr>
                  				<tr>
                  					<td>6pm sun mar 06</td>
                  					<td>Free Shipping bazar</td>
                  					<td>$0.50</td>
                  					<td>10%</td>
                  					<td><i class="fa fa-calendar-o" aria-hidden="true"></i> Requested to schedule</td>
                  				</tr>
                  				<tr>
                  					<td>6pm sun mar 06</td>
                  					<td>Free Shipping bazar</td>
                  					<td>$0.50</td>
                  					<td>10%</td>
                  					<td><i class="fa fa-calendar-o" aria-hidden="true"></i> Requested to schedule</td>
                  				</tr>
                  				<tr>
                  					<td>6pm sun mar 06</td>
                  					<td>Free Shipping bazar</td>
                  					<td>$0.50</td>
                  					<td>10%</td>
                  					<td><i class="fa fa-calendar-o" aria-hidden="true"></i> Requested to schedule</td>
                  				</tr>
                  			</tbody>
                  		</table>
                  	</div>
                  </div>
              </div>
              </div>
            </div>
        </div>
    </section>
</asp:Content>
