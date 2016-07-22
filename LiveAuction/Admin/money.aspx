<%@ Page Language="C#" MasterPageFile="~/seller-track/Seller.Master" AutoEventWireup="true"
    CodeBehind="money.aspx.cs" Inherits="LiveAuction.seller_track.money" %>

<%@ Register Src="~/UserControl/SellerLeftPanel.ascx" TagName="SellerLeftPanel" TagPrefix="UCSellerLeftPanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $('#liMoney').addClass('sdmnu-active');
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
                     <a href="#" class="incative">Home &raquo; </a><span class="current-page">money</span></div>
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
                    <div class="account-creat-title money-acc-title">
                      <h2>Your Money</h2>
                      <a href="#"><h4><i class="fa fa-university" aria-hidden="true"></i> Update Payment Details</h4></a>
                    </div>
                  </div>
                  <div class="tt">
                    <div class="money-sec clearfix">
                      <div class="col-md-6">
                        <div class="money-table">
                          <table class="table">
                            <thead>
                              <tr>
                                <td colspan="2"><strong>Next Payout</strong></td>
                              </tr>
                            </thead>
                            <tbody>
                              <tr>
                                <td>Sales & Cradit</td>
                                <td>£0.00</td>
                              </tr>
                              <tr>
                                <td>Fees</td>
                                <td>£0.00</td>
                              </tr>
                              <tr>
                                <td>Net</td>
                                <td>£0.00</td>
                              </tr>
                              <tr>
                                <td colspan="2" class="money-notice">Please note there is a £5.00 minimum. You will receive a payout as soon as your net payout amonut exceeds £5.00</td>
                              </tr>
                            </tbody>
                          </table>
                        </div>
                      </div>
                      <div class="col-md-6">
                        <div class="money-table">
                          <table class="table">
                            <thead>
                              <tr>
                                <td colspan="2"><strong>Awaiting Delivery</strong></td>
                              </tr>
                            </thead>
                            <tbody>
                              <tr>
                                <td>Sale</td>
                                <td>£0.00</td>
                              </tr>
                              <tr>
                                <td>Fees</td>
                                <td>£0.00</td>
                              </tr>
                              <tr>
                                <td>Net</td>
                                <td>£0.00</td>
                              </tr>
                            </tbody>
                          </table>
                        </div>
                      </div>
                    </div>
                  </div>
                  <div class="tt">
                    <div class="inbox-tabs money-tabs">
                        <!-- Nav tabs -->
                        <ul class="nav nav-tabs" role="tablist">
                          <li role="presentation" class="active"><a href="#Sales" aria-controls="home" role="tab" data-toggle="tab">Sales & Fees - Next Payout</a></li>
                          <li role="presentation"><a href="#Awaiting" aria-controls="profile" role="tab" data-toggle="tab">Sales - Awaiting Devlivery</a></li>
                          <li role="presentation"><a href="#Due" aria-controls="messages" role="tab" data-toggle="tab">Fees - Due after 7 days</a></li>
                          <li role="presentation"><a href="#Completed" aria-controls="messages" role="tab" data-toggle="tab">Completed Payouts</a></li>
                        </ul>

                        <!-- Tab panes -->
                        <div class="tab-content">
                          <div role="tabpanel" class="tab-pane active" id="Sales">
                            <div class="tab-cnt-sec">
                              <p>You don't have any conversation to dispaly.</p>
                              <p>No sales to dispaly</p>
                            </div>
                          </div>
                          <div role="tabpanel" class="tab-pane" id="Awaiting">
                            <div class="tab-cnt-sec">
                              
                            </div>
                          </div>
                          <div role="tabpanel" class="tab-pane" id="Due">
                            <div class="tab-cnt-sec">
                              
                            </div>
                          </div>
                          <div role="tabpanel" class="tab-pane" id="Completed">
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
