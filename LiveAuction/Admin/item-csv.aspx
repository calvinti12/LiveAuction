<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
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
             <%--<UCSellerLeftPanel:SellerLeftPanel runat="server" ID="SellerLftPnl" />--%>
              <div class="col-md-12">
                <div class="cr-accnt">
                  <div class="tt">
                      <div class="account-creat-title">
                          <h2>CSV Auction</h2>
                      </div>
                  </div>
                  <div class="tt">
                    <div class="bulk-item-butn">
                      <a class="btn btn-primary btn-blkitem" data-toggle="modal" data-target="#bidpopup">Upload Bulk Items</a>
                      <span class="label label-success successUpload" style="visibility:hidden">File uploaded successfully.</span>
                      <asp:PlaceHolder ID="fileUploadSuccessfull" runat="server"></asp:PlaceHolder>
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
    <!-- start of bid popup -->
    <section class="bid-popup-sector" style="margin-top: 40%">
        <!-- Modal -->
        <div class="modal fade" id="bidpopup" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
          <div class="modal-dialog bid-model-dialog" role="document">
            <div class="modal-content bid-model-content" style="margin-top: 25%;">
              <div class="modal-header bid-model-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title" id="myModalLabel">Upload CSV file</h4>
              </div>
              <div class="modal-body bid-model-body">
                  <div class="row">
                    <div class="col-md-12 col-lg-12">
                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="btn btn-default btn-file" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationExpression="([a-zA-Z0-9\s_\\.\-:])+(.csv|.txt)$"
                                        ControlToValidate="FileUpload1" runat="server" ForeColor="Red" ErrorMessage="Please select a valid CSV file."
                                        Display="Dynamic" />
                                    <asp:Label ID="fileUploadLabel" runat="server" ForeColor="Red"></asp:Label>
                    <div class="col-xs-12"><hr></div><br />
                    <asp:Button ID="Button1"  CssClass="btn btn-default" Text="Upload" OnClick = "Upload" runat="server" />
                      <%--<div class="cr-accnt pop-cr-accnt">
                      
                      </div>--%>
                    </div>
                  </div>
              </div>
            </div>
          </div>
        </div>
      </section>
    <!-- end of bid popup -->
</asp:Content>
