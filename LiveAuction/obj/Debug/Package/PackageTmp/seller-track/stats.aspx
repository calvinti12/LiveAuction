<%@ Page Language="C#" MasterPageFile="~/seller-track/Seller.Master" AutoEventWireup="true" CodeBehind="stats.aspx.cs" Inherits="LiveAuction.seller_track.stats" %>

<%@ Register Src="~/UserControl/SellerLeftPanel.ascx" TagName="SellerLeftPanel" TagPrefix="UCSellerLeftPanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $('#liStats').addClass('sdmnu-active');
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
                     <a href="#" class="incative">Home &raquo; </a><span class="current-page">Stats</span></div>
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
                          <h2>Reputation Stats</h2>
                      </div>
                  </div>
                  <div class="tt">
                    <div class="inbox-tabs">

                        <!-- Nav tabs -->
                        <ul class="nav nav-tabs" role="tablist">
                          <li role="presentation" class="active"><a href="#all" aria-controls="home" role="tab" data-toggle="tab">Reputation Stats</a></li>
                          <li role="presentation"><a href="#unread" aria-controls="profile" role="tab" data-toggle="tab">Shipping Stats</a></li>
                          <li role="presentation"><a href="#archived" aria-controls="messages" role="tab" data-toggle="tab">Sales Stats</a></li>
                          <li role="presentation"><a href="#archived" aria-controls="messages" role="tab" data-toggle="tab">SKU Stats</a></li>
                        </ul>

                        <!-- Tab panes -->
                        <div class="tab-content">
                          <div role="tabpanel" class="tab-pane active" id="all">
                            <div class="tab-cnt-sec">
                              <p>No Stats to display.</p>
                            </div>
                          </div>
                          <div role="tabpanel" class="tab-pane" id="unread">
                            <div class="tab-cnt-sec">
                              
                            </div>
                          </div>
                          <div role="tabpanel" class="tab-pane" id="archived">
                            <div class="tab-cnt-sec">
                              
                            </div>
                          </div>
                          <div role="tabpanel" class="tab-pane" id="archived">
                            <div class="tab-cnt-sec">
                              
                            </div>
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
