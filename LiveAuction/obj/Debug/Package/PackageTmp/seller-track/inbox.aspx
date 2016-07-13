<%@ Page Language="C#" MasterPageFile="~/seller-track/Seller.Master" AutoEventWireup="true"
    CodeBehind="inbox.aspx.cs" Inherits="LiveAuction.seller_track.inbox" %>

<%@ Register Src="~/UserControl/SellerLeftPanel.ascx" TagName="SellerLeftPanel" TagPrefix="UCSellerLeftPanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $('#liInbox').addClass('sdmnu-active');
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
                     <a href="#" class="incative">Home &raquo; </a><span class="current-page">inbox</span></div>
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
                          <h2>Inbox</h2>
                      </div>
                  </div>
                  <div class="tt">
                    <div class="inbox-tabs">

                        <!-- Nav tabs -->
                        <ul class="nav nav-pills" role="tablist">
                          <li role="presentation" class="active"><a href="#all" aria-controls="home" role="tab" data-toggle="tab">All</a></li>
                          <li role="presentation"><a href="#unread" aria-controls="profile" role="tab" data-toggle="tab">Unread</a></li>
                          <li role="presentation"><a href="#archived" aria-controls="messages" role="tab" data-toggle="tab">Archived</a></li>
                        </ul>

                        <!-- Tab panes -->
                        <div class="tab-content">
                          <div role="tabpanel" class="tab-pane active" id="all">
                            <div class="tab-cnt-sec">
                              <p>You don't have any conversation to dispaly.</p>
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
                        </div>
                    </div>
                  </div>
              </div>
              </div>
            </div>
        </div>
    </section>
</asp:Content>
