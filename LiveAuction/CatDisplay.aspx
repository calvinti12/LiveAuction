<%@ Page Language="C#" MasterPageFile="~/Bidder.Master" AutoEventWireup="true" CodeBehind="CatDisplay.aspx.cs"
    Inherits="LiveAuction.CatDisplay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- this is the breadcumbs area -->
    <section class="breadcumbs-area-sec">
         <div class="container">
             <div class="row">
                 <div class="col-md-12">
                     <div class="breadcumb">
                     <a href="index.aspx" class="incative">Home &raquo; </a><a href="CatDisplay.aspx?cat=AllAuctions" class="incative">Live Auctions &raquo; </a><%--<span class="current-page">Registration</span>--%></div>
                 </div>
             </div>
         </div>
     </section>
    <!-- end of breadcumbs area -->
    <!-- this is the start of category display page -->
    <section class="cat_display">
        <div class="container">
          <div class="row">
            <div class="col-md-3">
              <div class="cr-accnt">
                  <div class="account-selling-lstItem-sec">
                    <div class="account-selling-title">
                    <%--<asp:PlaceHolder ID="SubCategoryHeading" runat="server" />--%>
                     <strong><h4>Categoris</h4></strong>
                    </div>
                    <div class="account-selling-lstItem">
                      <ul class="list-unstyled">
                        <asp:PlaceHolder ID="PlaceHolderSubCategory" runat="server" />
                      </ul>
                    </div>
                  </div><!-- end of item accont selling -->
                </div> <!-- end of cr-accnt for left sideber -->
            </div> <!-- end of left coloum -->
            <div class="col-md-9">
              <div class="cat-item-tl-sec">
                <div class="cat-item-title">
                  <%--<asp:PlaceHolder ID="CategoryHeading" runat="server" />--%>
                  <h2>All Auctions</h2>
                </div>

                <div class="row">
                <asp:PlaceHolder ID="PlaceHolderCatagoriesMainContainer" runat="server" />
                </div>
              </div>
            </div>
          </div>
        </div>
      </section>
    <!-- this is the start of category display page -->
</asp:Content>
