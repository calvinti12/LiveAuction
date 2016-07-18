﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LiveAuction.Admin.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Fine Art &amp; Antique Auctions in Kent</title>
    <!-- Bootstrap core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="fonts/css/font-awesome.min.css" rel="stylesheet">
    <link href="css/animate.min.css" rel="stylesheet">
    <!-- Custom styling plus plugins -->
    <link href="css/custom.css" rel="stylesheet">
    <link href="css/icheck/flat/green.css" rel="stylesheet">
    <script src="~/Scripts/Admin/js/jquery.min.js"></script>
    <!--[if lt IE 9]>
          <script src="../assets/js/ie8-responsive-file-warning.js"></script>
          <![endif]-->
    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
            <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
            <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
          <![endif]-->
</head>
<body style="background: #F7F7F7;">
    <div class="">
        <a class="hiddenanchor" id="toregister"></a><a class="hiddenanchor" id="tologin">
        </a>
        <div id="wrapper">
            <div id="login" class="animate form">
                <section class="login_content">
                    <form runat="server">
                        <h1>Login Form</h1>
                        <div>
                        <asp:TextBox ID="txtUserName" runat="server" placeholder="Username" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Username Required"
                        ControlToValidate="txtUserName" ForeColor="Red"></asp:RequiredFieldValidator>
                           <%-- <input type="text" class="form-control" placeholder="Username" required="" />--%>
                        </div>
                        <div>
                       <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"
                        placeholder="Password"></asp:TextBox>
                        <div>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Password Required"
                        ControlToValidate="txtPassword" ForeColor="Red"></asp:RequiredFieldValidator></div>
                           <%-- <input type="password" class="form-control" placeholder="Password" required="" />--%>
                        </div>
                        <div>
                        <asp:LinkButton CssClass="btn btn-default submit" Text="Log in" runat="server" 
                                ID="btnLogin" onclick="btnLogin_Click" ></asp:LinkButton>
                       <%-- <asp:Button CssClass="btn btn-default submit" Text="Log in" runat="server" ID="btnLogin" />--%>
                          <%--  <a class="btn btn-default submit" href="Dashboard.aspx">Log in</a>--%>
                           <%-- <a class="reset_pass" href="#">Lost your password?</a>--%>
                        </div>
                        <div><asp:Label runat="server" ID="lblError" ForeColor="Red"></asp:Label></div>
                        <div class="clearfix"></div>
                        <div class="separator">
                            <%--<p class="change_link">
                                New to site?
                                <a href="#toregister" class="to_register"> Create Account </a>
                            </p>--%>
                            <div class="clearfix"></div>
                            <br />
                            <div>
                                <h1><i class="fa fa-paw" style="font-size: 26px;"></i> Fine Art &amp; Antique Auctions in Kent</h1>
                                <p>© 2016 Fine Art &amp; Antique Auctions in Kent. All Rights Reserved.</p>
                            </div>
                        </div>
                    </form>
                    <!-- form -->
                </section>
                <!-- content -->
            </div>
            <div id="register" class="animate form">
                <section class="login_content">
                    <form>
                        <h1>Create Account</h1>
                        <div>
                            <input type="text" class="form-control" placeholder="Username" required="" />
                        </div>
                        <div>
                            <input type="email" class="form-control" placeholder="Email" required="" />
                        </div>
                        <div>
                            <input type="password" class="form-control" placeholder="Password" required="" />
                        </div>
                        <div>
                            <a class="btn btn-default submit" href="index.html">Submit</a>
                        </div>
                        <div class="clearfix"></div>
                        <div class="separator">
                            <p class="change_link">
                                Already a member ?
                                <a href="#tologin" class="to_register"> Log in </a>
                            </p>
                            <div class="clearfix"></div>
                            <br />
                            <div>
                                <h1><i class="fa fa-paw" style="font-size: 26px;"></i> Gentelella Alela!</h1>
                                <p>©2015 All Rights Reserved. Gentelella Alela! is a Bootstrap 3 template. Privacy and Terms</p>
                            </div>
                        </div>
                    </form>
                    <!-- form -->
                </section>
                <!-- content -->
            </div>
        </div>
    </div>
</body>
