<%@ Page Language="C#" MasterPageFile="~/seller-track/Seller.Master" AutoEventWireup="true"
    CodeBehind="feedback.aspx.cs" Inherits="LiveAuction.seller_track.feedback" %>

<%@ Register Src="~/UserControl/SellerLeftPanel.ascx" TagName="SellerLeftPanel" TagPrefix="UCSellerLeftPanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $('#liFeedback').addClass('sdmnu-active');
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
                     <a href="#" class="incative">Home &raquo; </a><span class="current-page">Feedback</span></div>
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
                          <h2>Feedback</h2>
                      </div>
                  </div>
                  <div class="tt">
                    <div class="row">
                      <div class="feedback-top">
                      <form>
                        <div class="form-group col-sm-6">
                          <div class="dropdown">
                            <button class="btn btn-default dropdown-toggle" type="button" id="feedbackdropdown" data-toggle="dropdown" aria-haspopup="true" aria-expanded="true">
                              showing: All
                              <span class="caret"></span>
                            </button>
                            <ul class="dropdown-menu" aria-labelledby="feedbackdropdown">
                              <li><a href="#">Action</a></li>
                              <li><a href="#">Another action</a></li>
                            </ul>
                          </div>
                        </div>
                        <div class="form-group col-sm-6">
                          <div class="input-group">
                            <input type="text" class="form-control" placeholder="item # SKU or title">
                            <span class="input-group-btn">
                              <button class="btn btn-primary" type="button">Search</button>
                            </span>
                          </div><!-- /input-group -->
                        </div>
                      </form>
                    </div>
                    </div>
                    
                  </div>
                  <div class="tt">
                    <div class="advertise-sec text-center">
                      <p>feedback</p>
                    </div>
                  </div>
              </div>
              </div>
            </div>
        </div>
    </section>
</asp:Content>
