<%@ Page Language="C#" MasterPageFile="~/Bidder.Master" AutoEventWireup="true" CodeBehind="signup.aspx.cs"
    Inherits="LiveAuction.signup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">
        function validate() {
            if (RequiredTxt('ContentPlaceHolder1_txtEmail', 'Email is required')) {
                return false;
            }
            if (ValEMail('ContentPlaceHolder1_txtEmail', 'Invalid  Email')) {
                return false;
            }
            if (RequiredTxt('ContentPlaceHolder1_txtPassword', 'Password is required')) {
                return false;
            }
            if (RequiredMatch('ContentPlaceHolder1_txtPassword', 'ContentPlaceHolder1_txtCnfPassword', 'Password mismatch')) {
                return false;
            }
            return true;
        }
    </script>
    <script language="javascript" type="text/javascript">
        function trG(str) {
            jAlert('<b style="color:green;font-size:1.0em;">' + str + '</b>');
        }

        function trR(str) {
            jAlert('<b style="color:red;font-size:1.0em;">' + str + '</b>');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- this is the breadcumbs area -->
    <section class="breadcumbs-area-sec">
         <div class="container">
             <div class="row">
                 <div class="col-md-12">
                     <div class="breadcumb">
                     <a href="#" class="incative">Home &raquo; </a><a href="#" class="incative">Live Auctions &raquo; </a><span class="current-page">Registration</span></div>
                 </div>
             </div>
         </div>
     </section>
    <!-- end of breadcumbs area -->
    <section class="creat-account-sec">
        <div class="container">
            <div class="row">
              <div class="col-md-12">
              <div class="cr-accnt">
                <div class="col-md-12">
                    <div class="account-creat-title">
                        <h2>Create your auction account</h2>
                    </div>
                </div>
                <div class="col-md-8">
                    <div class="form-horizontal crt-acnt-frm">
                      <div class="form-group">
                        <label for="creat-ac-lb" class="col-sm-3 control-label">Email</label>
                        <div class="col-sm-9">
                          <%--<input type="email" class="form-control" id="creat-ac-lb" placeholder="Email">--%>
                           <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="Email"></asp:TextBox>
                        </div>
                      </div>
                      <div class="form-group">
                        <label for="creat-pswrd-lb" class="col-sm-3 control-label">Password</label>
                        <div class="col-sm-9">
                          <%--<input type="password" class="form-control" id="creat-pswrd-lb" placeholder="Password">--%>
                          <asp:TextBox ID="txtPassword" runat="server" class="form-control" TextMode="Password" placeholder="Password"></asp:TextBox>
                        </div>
                      </div>
                      <div class="form-group">
                        <label for="creat-pswrd-lb-re" class="col-sm-3 control-label">Confirm password</label>
                        <div class="col-sm-9">
                          <%--<input type="password" class="form-control" id="creat-pswrd-lb-re" placeholder="Password">--%>
                          <asp:TextBox ID="txtCnfPassword" runat="server" class="form-control" TextMode="Password" placeholder="Password"></asp:TextBox>
                        </div>
                      </div>
                      <div class="form-group">
                        <label for="creat-pswrd-lb-re" class="col-sm-3 control-label">User Type</label>
                        <div class="col-sm-9" style="padding: 5px 0 0 15px;">
                         <asp:RadioButtonList ID="rdbtnlistUserType" runat="server" RepeatDirection="Horizontal"
                                    Font-Bold="false">
                                    <asp:ListItem Text="Bidder" Value="1" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Seller" Value="2"></asp:ListItem>
                                </asp:RadioButtonList>
                        </div>
                      </div>
                      <div class="form-group">
                        <div class="col-sm-offset-3 col-sm-9">
                          <div class="check-top-para">Tell us what you are interested in and will tailor our emails to you</div>
                        </div>
                      </div>
                      <div class="form-group">
                        <div class="col-sm-offset-3 col-sm-9">
                          <div class="checkbox crt-ac-ck">
                            <label>
                              <input type="checkbox" id="chkAgree" runat="server"> I have read and agree to  Unified <a href="#">User Agreement</a> and <a href="#">Privacy Policy</a>. 
                            </label>
                          </div>
                        </div>
                      </div>
                      <div class="form-group">
                        <div class="col-sm-offset-3 col-sm-9">
                         <asp:Button runat="server" ID="btnCreateAcc" class="btn btn-default btn-danger" Text="Create my account now" OnClientClick="return validate();"
                    OnClick="btnCreateAcc_Click" />
                          <%--<button type="submit" class="btn btn-default btn-danger" >Create my account now</button>--%>
                        </div>
                      </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="why-creat-sec">
                        <div class="why-ct-icon pull-left">
                            <p class="text-center">?</p>
                        </div>
                        <div class="why-ct-txt">
                            This gets you access to features like auction alarts and adding items to your watch list
                        </div>
                    </div>
                </div>
              </div>
              </div>
            </div>
        </div>
    </section>
</asp:Content>
