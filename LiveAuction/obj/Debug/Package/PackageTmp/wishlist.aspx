<%@ Page Language="C#" MasterPageFile="~/Bidder.Master" AutoEventWireup="true" CodeBehind="wishlist.aspx.cs" Inherits="LiveAuction.wishlist" %>

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
    
    <section class="creat-account-sec">
        <div class="container">
            <div class="row">
            	<div class="col-md-3">
            		<div class="cr-accnt">
            			<div class="input-group">
					      <input type="text" class="form-control" placeholder="Search Wish List">
					      <span class="input-group-btn">
					        <button class="btn btn-primary" type="button">Go!</button>
					      </span>
					    </div><!-- /input-group -->
            		</div>
            		<div class="cr-accnt">
            			<div class="wishlist-result">
            				<p>No Wish List Filter</p>
            			</div>
            		</div>
            	</div>
            	<div class="col-md-9">
            		<div class="cr-accnt">
            			<div class="wishlist-make text-center">
            				<p>The are no items currently in your wish list</p>
            				<p>You can add item by clicking on the <span><button type="button" class="btn btn-primary">Wish + </button></span> link next to lots in a catalouge.</p>
            			</div>
            		</div>
            	</div>
            </div>
        </div>
    </section>
</asp:Content>
