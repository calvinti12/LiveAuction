<%@ Page Language="C#" MasterPageFile="~/seller-track/Seller.Master" AutoEventWireup="true" CodeBehind="seller2.aspx.cs" Inherits="LiveAuction.seller_track.seller2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!-- this is the breadcumbs area -->
     <section class="breadcumbs-area-sec">
         <div class="container">
             <div class="row">
                 <div class="col-md-12">
                     <div class="breadcumb">
                     <a href="#" class="incative">Register &raquo; </a><a href="#" class="incative">list-item &raquo; </a><span class="current-page">Schedule item</span></div>
                 </div>
             </div>
         </div>
     </section>

     <!-- end of breadcumbs area -->
    
    <section class="creat-account-sec">
        <div class="container">
            <div class="row">
            	<div class="col-sm-12">
            		<div class="cr-accnt">
            				<div class="tt">
		                      <div class="account-creat-title">
		                          <h2>1. Item</h2>
		                      </div>
		                </div>
                    <div class="row">
                      <div class="col-md-8">
                        <div class="selling-1st-sec">
                          <div class="selling-1st-dropdown">
                            <div class="dropdown">
                              <button class="btn btn-primary dropdown-toggle" type="button" id="feedbackdropdown" data-toggle="dropdown" aria-haspopup="true" aria-expanded="true">
                                Choose a Category
                                <span class="caret"></span>
                              </button>
                              <ul class="dropdown-menu" aria-labelledby="feedbackdropdown">
                                <li><a href="#">Action</a></li>
                                <li><a href="#">Another action</a></li>
                              </ul>
                            </div>
                          </div>
                          <div class="selling-1st-txt">
                            <p>picking the right category is important and help buyers to find out your products easily. Can't find the right category ? Just Choose "others"/ "others"</p>
                          </div>
                        </div>
                      </div>
                    </div>
            		</div>
            	</div>
            </div>
        </div>
    </section>
</asp:Content>
