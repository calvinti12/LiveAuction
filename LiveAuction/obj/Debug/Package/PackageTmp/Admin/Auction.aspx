<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/Admin.Master"
    CodeBehind="Auction.aspx.cs" Inherits="LiveAuction.Admin.Auction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="">
        <div class="page-title">
            <div class="title_left">
                <h3>
                    Auction
                </h3>
            </div>
            <div class="title_right">
                <%--<div class="col-md-5 col-sm-5 col-xs-12 form-group pull-right top_search">
                    <div class="input-group">
                        <input type="text" class="form-control" placeholder="Search for...">
                        <span class="input-group-btn">
                            <button class="btn btn-default" type="button">
                                Go!</button>
                        </span>
                    </div>
                </div>--%>
            </div>
        </div>
        <div class="clearfix">
        </div>
        <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>
                            Auction Form <small>Add</small></h2>
                        <ul class="nav navbar-right panel_toolbox">
                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a></li>
                            <%--<li class="dropdown">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false"><i class="fa fa-wrench"></i></a>
                                <ul class="dropdown-menu" role="menu">
                                    <li>
                                        <a href="#">Settings 1</a>
                                    </li>
                                    <li>
                                        <a href="#">Settings 2</a>
                                    </li>
                                </ul>
                            </li>
                            <li>
                                <a class="close-link"><i class="fa fa-close"></i></a>
                            </li>--%>
                        </ul>
                        <div class="clearfix">
                        </div>
                    </div>
                    <div class="x_content">
                        <div class="form-horizontal form-label-left" novalidate>
                            <span class="section">Auction Info</span>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">
                                    Auction Name <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                <asp:TextBox ID="txtAuctionName" runat="server" class="form-control col-md-7 col-xs-12" data-validate-length-range="6"
                                        data-validate-words="2" name="name" placeholder="Ring Showcase"></asp:TextBox>
                                         <asp:RequiredFieldValidator runat="server" ErrorMessage="Auction name Required"
                        ControlToValidate="txtAuctionName" ForeColor="Red" ValidationGroup="Auction"></asp:RequiredFieldValidator>
                                    <%--<input id="name" class="form-control col-md-7 col-xs-12" data-validate-length-range="6"
                                        data-validate-words="2" name="name" placeholder="Ring Showcase" required="required"
                                        type="text">--%>
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="email">
                                    Auction Date <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                <asp:TextBox ID="auctiondate" ClientIDMode="Static" runat="server" class="date-picker form-control col-md-7 col-xs-12" ></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ErrorMessage="Auction date Required"
                        ControlToValidate="auctiondate" ForeColor="Red" ValidationGroup="Auction"></asp:RequiredFieldValidator>
                                   <%-- <input id="auctiondate" class="date-picker form-control col-md-7 col-xs-12" required="required"
                                        type="text">--%>
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="website">
                                    Auction Time <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                <asp:TextBox ID="auctiontime" runat="server" class="time form-control col-md-7 col-xs-12"
                                        placeholder="17:00"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" ErrorMessage="Auction time Required"
                        ControlToValidate="auctiontime" ForeColor="Red" ValidationGroup="Auction"></asp:RequiredFieldValidator>
                                  <%--  <input type="url" id="auctiontime" name="time" required="required" class="time form-control col-md-7 col-xs-12"
                                        placeholder="17:00">--%>
                                </div>
                            </div>
                            <div class="item form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="number">
                                    Commission(%) <span class="required">*</span>
                                </label>
                                <div class="col-md-6 col-sm-6 col-xs-12">
                                <asp:TextBox ID="number" runat="server" data-validate-minmax="10,100" type="number"
                                        class="form-control col-md-7 col-xs-12"></asp:TextBox>
                                         <asp:RequiredFieldValidator runat="server" ErrorMessage="Commission Required"
                        ControlToValidate="number" ForeColor="Red" ValidationGroup="Auction"></asp:RequiredFieldValidator>
                                   <%-- <input type="number" id="number" name="number" required="required" data-validate-minmax="10,100"
                                        class="form-control col-md-7 col-xs-12">--%>
                                </div>
                            </div>
                             <div class="item form-group">
                             <asp:Label runat="server" ID="lblMessage" ForeColor="Red"></asp:Label>
                             </div>
                            <div class="ln_solid">
                            </div>
                            <div class="form-group">
                                <div class="col-md-6 col-md-offset-3">
                                <asp:Button ID="btnCancel" runat="server" class="btn btn-primary" Text="Cancel" 
                                        onclick="btnCancel_Click" />
                                    <%--<button type="submit" class="btn btn-primary">
                                        Cancel</button>--%>
                                        <asp:Button ID="btnSubmit" runat="server" class="btn btn-success" 
                                        Text="Submit" ValidationGroup="Auction" onclick="btnSubmit_Click" />
                                   <%-- <button id="send" type="submit" class="btn btn-success">
                                        Submit</button>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                    <script type="text/javascript">
                        $(document).ready(function () {
                            $('#auctiondate').daterangepicker({
                                singleDatePicker: true,
                                calender_style: "picker_4"
                            }, function (start, end, label) {
                                console.log(start.toISOString(), end.toISOString(), label);
                            });
                        });
                    </script>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
