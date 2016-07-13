<%@ Page Language="C#" MasterPageFile="~/seller-track/Seller.Master" AutoEventWireup="true"
    CodeBehind="account-info.aspx.cs" Inherits="LiveAuction.seller_track.account_info" %>

<%@ Register Src="~/UserControl/SellerLeftPanel.ascx" TagName="SellerLeftPanel" TagPrefix="UCSellerLeftPanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $('#liAccount').addClass('sdmnu-active');
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
                     <a href="#" class="incative">Home &raquo; </a><span class="current-page">Reputation Starts</span></div>
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
                          <h2>Reputation Starts</h2>
                      </div>
                  </div>
                  <div class="tt">
                      <div class="form-horizontal crt-acnt-frm">
                        <div class="form-group">
                          <label for="creat-ac-lb" class="col-sm-2 control-label">Name</label>
                          <div class="col-sm-8">
                            <%--<input type="text" class="form-control" id="creat-ac-lb" placeholder="SHANE O'BRIEN">--%>
                            <asp:TextBox ID="txtName" runat="server" class="form-control" placeholder="SHANE O'BRIEN"></asp:TextBox>
                          </div>
                        </div>
                        <div class="form-group">
                          <label for="acc-email" class="col-sm-2 control-label">Email</label>
                          <div class="col-sm-8">
                            <%--<input type="email" class="form-control" id="acc-email" placeholder="brandoitte@gmail.com">--%>
                            <asp:TextBox ID="txtEmail" runat="server" class="form-control" Width="100%" Enabled="false" placeholder="brandoitte@gmail.com"></asp:TextBox>
                          </div>
                        </div>
                        <div class="form-group">
                          <label for="creat-phne-lb" class="col-sm-2 control-label">Phone#</label>
                          <div class="col-sm-8">
                            <%--<input type="text" class="form-control" id="creat-phne-lb" placeholder="">--%>
                            <asp:TextBox ID="txtPhone" runat="server" class="form-control" placeholder="SHANE O'BRIEN"></asp:TextBox>
                          </div>
                        </div>
                        <div class="form-group">
                          <label for="creat-pswrd-lb" class="col-sm-2 control-label">Country</label>
                          <div class="col-sm-8">
                            <%--<select class="form-control">
                              <option>India</option>
                              <option>United States</option>
                              <option>Austrilia</option>
                              <option>China</option>
                              <option>japan</option>
                            </select>--%>
                            <asp:DropDownList ID="ddlCountry" runat="server" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"></asp:DropDownList>
                          </div>
                        </div>
                        <div class="form-group">
                          <label for="creat-pswrd-lb" class="col-sm-2 control-label">Time Zone</label>
                          <div class="col-sm-8">
                          <asp:DropDownList ID="ddlTimeZone" runat="server" Width="100%"></asp:DropDownList>
                            <%--<select class="form-control">
                              <option>(GMT-10.00)Hawaii</option>
                              <option>(GMT-11.00)Hawaii</option>
                              <option>(GMT-11.00)Hawaii</option>
                              <option>(GMT-13.00)Hawaii</option>
                              <option>(GMT-14.00)Hawaii</option>
                            </select>--%>
                          </div>
                        </div>
                        <div class="form-group">
                          <label for="creat-pswrd-lb-re" class="col-sm-2 control-label sr-only">submit button</label>
                          <div class="col-sm-8">
                          <asp:Button ID="btnUpdate" runat="server" class="btn btn-primary btn-block" OnClick="btnUpdate_Click" Text="Update" CausesValidation="false"></asp:Button>
                            <%--<button type="button" class="btn btn-primary btn-block">update</button>--%>
                          </div>
                        </div>
                        <div class="form-group">
                          <label for="creat-pswrd-lb-re" class="col-sm-2 control-label sr-only">connect facebook</label>
                          <div class="col-sm-8">
                            <button type="button" class="btn btn-default btn-block ac-inf-social"><i class="fa fa-facebook-square"></i> Connect Facebook</button>
                          </div>
                        </div>
                        <div class="form-group">
                          <label for="creat-pswrd-lb-re" class="col-sm-2 control-label sr-only">manage cradit cards</label>
                          <div class="col-sm-8">
                            <button type="button" class="btn btn-default btn-block ac-inf-social"><i class="fa fa-credit-card"></i> manage cradit cards</button>
                          </div>
                        </div>
                        <div class="form-group">
                          <label for="creat-pswrd-lb-re" class="col-sm-2 control-label sr-only">manage Address</label>
                          <div class="col-sm-8">
                            <button type="button" class="btn btn-default btn-block ac-inf-social"><i class="fa fa-map-marker"></i> manage Address</button>
                          </div>
                        </div>
                        <div class="form-group">
                          <label for="creat-pswrd-lb-re" class="col-sm-2 control-label sr-only">Change Password</label>
                          <div class="col-sm-8">
                            <button type="button" class="btn btn-default btn-block ac-inf-social"><i class="fa fa-lock"></i> Change Password</button>
                          </div>
                        </div>
                        <div class="form-group">
                          <label for="creat-pswrd-lb-re" class="col-sm-2 control-label sr-only">Email preference</label>
                          <div class="col-sm-8">
                            <button type="button" class="btn btn-default btn-block ac-inf-social"><i class="fa fa-envelope-o"></i> Email preference</button>
                          </div>
                        </div>
                        <div class="form-group">
                          <label for="creat-pswrd-lb-re" class="col-sm-2 control-label sr-only">Cancel Account</label>
                          <div class="col-sm-8">
                            <button type="button" class="btn btn-default btn-block ac-inf-social"><i class="fa fa-times"></i> Cancel Account</button>
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
