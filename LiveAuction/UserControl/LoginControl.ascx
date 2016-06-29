<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginControl.ascx.cs"
    Inherits="LiveAuction.UserControl.LoginControl" %>
<style>
    #LoginCtrl_rdbtnlistUserType td label
    {
        font-weight: lighter;
    }
    #LoginCtrl_rdbtnlistUserType tdforgot-modal
    {
        padding-left: 10px;
    }
</style>
<script type="text/javascript">
    $(document).ready(function () {
        $('.forgot-modal').click(function () {
            $('#loginmodal').modal('hide');
        });
    });
</script>
<div class="modal fade" id="loginmodal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
    <div class="modal-dialog citius-modal-dialog" role="document">
        <div class="modal-content citius-modal-content">
            <div class="modal-header citius-modal-header">
                <button type="button" class="close citius-close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title citius-modal-title text-center" id="myModalLabel">
                    Login Form</h4>
            </div>
            <div class="modal-body citius-modal-body">
                <div class="form-group">
                    <label for="citius-email">
                        Email address</label>
                    <%--<input type="email" class="form-control" id="citius-email" placeholder="Email">--%>
                    <asp:TextBox ID="txtLoginEmail" runat="server" class="form-control" placeholder="Email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Email Required"
                        ControlToValidate="txtLoginEmail" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group citis-form-password">
                    <label for="citius-password">
                        Password</label>
                    <%-- <input type="password" class="form-control" id="citius-password" placeholder="Password">--%>
                    <asp:TextBox ID="txtLoginPassword" runat="server" class="form-control" TextMode="Password"
                        placeholder="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Password Required"
                        ControlToValidate="txtLoginPassword" ForeColor="Red"></asp:RequiredFieldValidator>
                    <i class="fa fa-eye"></i>
                </div>
                <div class="form-group">
                    <table cellpadding="5" cellspacing="5">
                        <tr>
                            <td>
                                <label for="citius-usertype">
                                    Login User Type : &nbsp;&nbsp;&nbsp;
                                </label>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rdbtnlistUserType" runat="server" RepeatDirection="Horizontal"
                                    Font-Bold="false">
                                    <asp:ListItem Text="Bidder" Value="1" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Seller" Value="2"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="checkbox text-center">
                    <label>
                        <input type="checkbox" id="chkPwdSave" runat="server">
                        Remember me?
                    </label>
                </div>
                <div class="citius-submit-button text-center">
                    <%--<button type="submit" class="btn btn-default btn-custom-login">Login</button>--%>
                    <asp:Button runat="server" ID="btnLogin" class="btn btn-default btn-custom-login" CausesValidation="false"
                        Text="Login" _OnClientClick="return LoginValidate();" OnClick="btnLogin_Click" />
                </div>
                <div class="form-group">
                    <div class="dont-account text-center">
                        <ul class="list-inline">
                            <li>Don't Have an account?</li>
                            <li><a href="../signup.aspx"><i class="fa fa-long-arrow-left"></i>&nbsp;Sign Up</a></li>
                        </ul>
                    </div>
                    <div class="forget-password text-center">
                        <a href="#" data-toggle="modal" data-target="#forgotmodal" class="forgot-modal">Forgotten
                            Password?</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="modal fade" id="forgotmodal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
    <div class="modal-dialog citius-modal-dialog" role="document">
        <div class="modal-content citius-modal-content">
            <div class="modal-header citius-modal-header">
                <button type="button" class="close citius-close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title citius-modal-title text-center" id="myModalLabelForgot">
                    Forgot Password</h4>
            </div>
            <div class="modal-body citius-modal-body">
                <div class="form-group">
                    <label for="citius-email">
                        Email address</label>
                    <%--<input type="email" class="form-control" id="citius-email" placeholder="Email">--%>
                    <asp:TextBox ID="txtForgotEmail" runat="server" class="form-control" placeholder="Email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Email Required"
                        ControlToValidate="txtForgotEmail" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <table cellpadding="5" cellspacing="5">
                        <tr>
                            <td>
                                <label for="citius-usertype">
                                    User Type : &nbsp;&nbsp;&nbsp;
                                </label>
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rdbtnlistFGUserType" runat="server" RepeatDirection="Horizontal"
                                    Font-Bold="false">
                                    <asp:ListItem Text="Bidder" Value="1" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Seller" Value="2"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="citius-submit-button text-center">
                    <%--<button type="submit" class="btn btn-default btn-custom-login">Login</button>--%>
                    <asp:Button runat="server" ID="btnForgot" class="btn btn-default btn-custom-login" CausesValidation="false"
                        Text="Send"  OnClick="btnForgot_Click" />
                </div>
            </div>
        </div>
    </div>
</div>
