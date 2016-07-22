<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="sell-item.aspx.cs" Inherits="LiveAuction.seller_track.sell_item" %>

<%@ Register Src="~/UserControl/SellerLeftPanel.ascx" TagName="SellerLeftPanel" TagPrefix="UCSellerLeftPanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $('#liItems').addClass('sdmnu-active');

            $('#apply').click(function () {
                var val = [];
                $(':checkbox:checked').each(function (i) {
                    val[i] = $(this).val();
                    //alert($(this).val() + "Lot id" + $("#lotId" + $(this).val()).val());
                    $.ajax({
                        type: "POST",
                        url: "sell-item.aspx/ActionSchedule",
                        data: '{id: "' + $(this).val() + '" }',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) { console.log(response.d); },
                        failure: function (response) { console.log(response.d); }
                    });
                });
            });

            $("#selectAll").change(function () {
                $("input:checkbox").prop('checked', $(this).prop("checked"));
            });
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
                     <a href="#" class="incative">Home &raquo; </a><span class="current-page">Sell item</span></div>
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
                          <h2>Want to sell in higher volume?</h2>
                      </div>
                  </div>
                  <div class="tt">
                    <div class="sell-item-condition">
                      <p>Apply for a <strong>partner Condition</strong>, and exclusive auction event, to sell <strong>50 or more items in a day.</strong>  </p>
                    </div>
                    <div class="sell-apply">
                      <button type="button" class="btn btn-primary" id="apply">Apply Now</button>
                    </div>
                  </div>
                  <div class="tt">
                    <div class="row">
                      <form class="form-inline">
                        <div class="col-sm-6">
                          <div class="form-group">
                            <div class="dropdown">
                              <button class="btn btn-default dropdown-toggle" type="button" id="feedbackdropdown" data-toggle="dropdown" aria-haspopup="true" aria-expanded="true">
                                All
                                <span class="caret"></span>
                              </button>
                              <ul class="dropdown-menu" aria-labelledby="feedbackdropdown">
                                <li><a href="#">All</a></li>
                                <li><a href="#">Unlisted</a></li>
                                <li><a href="#">Listed</a></li>
                                <li><a href="#">Scheduled</a></li>
                                <li><a href="#">Unsold</a></li>
                                <li><a href="#">Unpaid</a></li>
                                <li><a href="#">Paid Unshift (Newer first)</a></li>
                                <li><a href="#">Paid Unshift (Older first)</a></li>
                                <li><a href="#">Pending Verification</a></li>
                                <li><a href="#">Preparing Order</a></li>
                                <li><a href="#">Shipped</a></li>
                                <li><a href="#">Tracked</a></li>
                                <li><a href="#">Canceled</a></li>
                                <li><a href="#">Refunded</a></li>
                                <li><a href="#">Archived</a></li>
                                <li><a href="#">Unlisted</a></li>
                              </ul>
                            </div>
                          </div>
                          <div class="form-group">
                            <div class="dropdown">
                              <button class="btn btn-default dropdown-toggle" type="button" id="feedbackdropdown" data-toggle="dropdown" aria-haspopup="true" aria-expanded="true">
                                Bulk Action
                                <span class="caret"></span>
                              </button>
                              <ul class="dropdown-menu" aria-labelledby="feedbackdropdown">
                                <li><a href="#">Select All</a></li>
                                <li><a href="#">Relist</a></li>
                                <li><a href="#">Archive</a></li>
                                <li><a href="#">Export</a></li>
                              </ul>
                            </div>
                          </div>
                        </div>
                        
                        <div class="col-sm-6">
                          <div class="form-group">
                            <div class="dropdown">
                              <button class="btn btn-default dropdown-toggle" type="button" id="feedbackdropdown" data-toggle="dropdown" aria-haspopup="true" aria-expanded="true">
                                All
                                <span class="caret"></span>
                              </button>
                              <ul class="dropdown-menu" aria-labelledby="feedbackdropdown">
                                <li><a href="#">Action</a></li>
                                <li><a href="#">Another action</a></li>
                              </ul>
                            </div>
                          </div>
                          <div class="form-group">
                            <div class="input-group">
                              <input type="text" class="form-control" placeholder="item order or buyers">
                              <span class="input-group-btn">
                                <button class="btn btn-default" type="button">search</button>
                              </span>
                            </div><!-- /input-group -->
                          </div>
                        </div>
                      </form>
                    </div>
                  </div>  <!-- end of search and dropdown -->
                  <div class="tt">
                    <div class="sell-item-sector">
                      <div class="sell-itm-set-title">
                        Displaying | Select All <input id="selectAll" type="checkbox" />
                      </div>
                      <asp:PlaceHolder ID = "PlaceHolder1" runat="server"/>
                    </div>
                  </div>
                </div>
              </div>
            </div>
        </div>
    </section>
</asp:Content>
