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
                      <a class="btn btn-primary btn-blkitem" data-toggle="modal" data-target="#bidpopup">Upload Bulk Items</a>
                      <asp:FileUpload ID="FileUpload1" runat="server" /><asp:Button ID="Button1" Text="Upload" OnClick = "Upload" runat="server" />
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
        <!-- this is for login modal section -->
    <section class="login-form-sec">
        <!-- Modal -->
        <div class="modal fade" id="loginmodal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
          <div class="modal-dialog citius-modal-dialog" role="document">
            <div class="modal-content citius-modal-content">
              <div class="modal-header citius-modal-header">
                <button type="button" class="close citius-close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title citius-modal-title text-center" id="myModalLabel">login form</h4>
              </div>
              <div class="modal-body citius-modal-body">
                <form>
                  <div class="form-group">
                    <label for="citius-email">Email address</label>
                    <input type="email" class="form-control" id="citius-email" placeholder="Email">
                  </div>
                  <div class="form-group citis-form-password">
                    <label for="citius-password">Password</label>
                    <input type="password" class="form-control" id="citius-password" placeholder="Password">
                    <i class="fa fa-eye"></i>
                  </div>
                  <div class="checkbox text-center">
                    <label>
                      <input type="checkbox"> Remember me?
                    </label>
                  </div>
                  <div class="citius-submit-button text-center">
                    <button type="submit" class="btn btn-default btn-custom-login">Login</button>
                  </div>
                  <div class="form-group">
                    <div class="dont-account text-center">
                        <ul class="list-inline">
                            <li>Don't Have an account?</li>
                            <li><a href="signup.html"><i class="fa fa-long-arrow-left"></i> &nbsp;Sign Up</a></li>
                        </ul>
                    </div>
                    <div class="forget-password text-center">
                        <a href="#">Forgotten Password?</a>
                    </div>
                  </div>
                </form>
              </div>
             
            </div>
          </div>
        </div>
    </section>
    <!-- this is for end of login modal section -->
</asp:Content>
