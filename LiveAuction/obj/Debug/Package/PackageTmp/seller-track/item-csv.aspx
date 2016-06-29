<%@ Page Language="C#" MasterPageFile="~/seller-track/Seller.Master" AutoEventWireup="true"
    CodeBehind="item-csv.aspx.cs" Inherits="LiveAuction.seller_track.item_csv" %>

<%@ Register Src="~/UserControl/SellerLeftPanel.ascx" TagName="SellerLeftPanel" TagPrefix="UCSellerLeftPanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $('#liCSVAuctions').addClass('sdmnu-active');
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
                     <a href="#" class="incative">Home &raquo; </a><span class="current-page">item csv</span></div>
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
                          <h2>CSV Auction</h2>
                      </div>
                  </div>
                  <div class="tt">
                    <div class="bulk-item-butn">
                      <button type="button" class="btn btn-primary btn-blkitem">Upload Bulk Items</button>
                    </div>
                  </div>
                  <div class="tt">
                    <div class="description-table-sec">
                      <div class="description-title">
                        CSV table description and acceptable values:
                      </div>
                      <div class="description-table">
                        <div class="table-responsive">
                          <table class="table table-bordered table-striped table-condensed table-csv">
                            <thead class="btn-primary">
                              <tr class="row">
                                <th class="col-xs-3">HEADER</th>
                                <th class="col-xs-3">REQUIRED</th>
                                <th class="col-xs-3">TYPE</th>
                                <th class="col-xs-3">ACCEPTABLE VALUES</th>
                              </tr>
                            </thead>
                            <tbody>
                              <tr class="row">
                                <td class="col-xs-3">1</td>
                                <td class="col-xs-3">2</td>
                                <td class="col-xs-3">3</td>
                                <td class="col-xs-3">4</td>
                              </tr>
                            </tbody>
                          </table>
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
