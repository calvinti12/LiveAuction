<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Bidder.Master" CodeBehind="catalogue.aspx.cs" 
    Inherits="LiveAuction.catalogue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<script src="js/jquery-1.7.2.min.js" type="text/javascript"></script>--%>
    <style type="text/css">
        .relatepro
        {
            background-color: #ffffff;
            border: 1px solid #dfd1ba;
            -webkit-border-radius: 4px;
            -moz-border-radius: 4px;
            border-radius: 4px;
            margin: 5px 0 20px 0;
        }
        .relatepro h2
        {
            background-color: #eae6db;
            border-bottom: 1px solid #dfd1ba;
            height: 44px;
            color: #b23213;
            font: bold 20px/44px Arial, Helvetica, sans-serif;
            padding: 0 0 0 17px;
            -webkit-border-radius: 0 0 4px 4px;
            -moz-border-radius: 0 0 4px 4px;
            border-radius: 0 0 4px 4px;
        }
        .relatecont
        {
            padding: 8px 20px;
        }
        .relatecont ul
        {
            margin: 0;
            padding: 0;
        }
        .relatecont ul li
        {
            padding: 0 0 14px 0;
            margin: 14px 0 0 0;
            background: url(images/reldivider.jpg) repeat-x 0 100%;
            overflow: hidden;
        }
        .relatecont ul li td.imgarea img
        {
            max-height: 90px;
            max-width: 120px;
        }
        .relatecont ul li p.relcontent
        {
            float: left;
            width: 546px;
            color: #3a624b;
            font: normal 12px/16px Arial, Helvetica, sans-serif;
            padding: 5px 0 0 0;
        }
        
        .relatecont ul li span.dollartxt
        {
            float: left;
            display: block;
            width: 140px;
            text-align: center;
            color: #3a624b;
            font: bold 12px/60px Arial, Helvetica, sans-serif;
        }
    </style>
    <style>
        ul.simplePagerNav li
        {
            display: block;
            float: left;
            font-family: georgia;
            font-size: 14px;
            margin-bottom: 10px;
            padding: 10px;
            background: none;
        }
        ul.simplePagerNav li.currentPage
        {
            background: none repeat scroll 0 0 #FF9500;
        }
        #content
        {
            background-color: white;
        }
        #content a:not(.seelivedemo)
        {
            color: #FD5927;
        }
    </style>
    <%--<script src="js/jquery.quick.pagination.min.js" type="text/javascript"></script>--%>
    <%--<script type="text/javascript">
        $(document).ready(function () {
            //	$("ul.pagination1").quickPagination();
            //	$("ul.pagination2").quickPagination({pagerLocation:"both"});
            $("ul.pagination3").quickPagination({ pageSize: "6" });
        });

       
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="breadcumbs-area-sec">
         <div class="container">
             <div class="row">
                 <div class="col-md-12">
                     <div class="breadcumb">
                     <a href="index.aspx" class="incative">Home &raquo; </a><a href="auctions.aspx" class="incative">Timed Event &raquo; </a><span class="current-page">Auction List</span></div>
                 </div>
             </div>
         </div>
     </section>
    <!-- end of breadcumbs area -->
    <section class="creat-account-sec">
        <div class="container">
            <div class="row">

             <div class="bodymaincont">
        <div class="relatepro">
            <h2>
                <%=strHeading%> Lots</h2>
                <%--<button type="submit" class="btn btn-primary btn-cta" onclick="btnExportToExcel_Click">Export to Excel</button>--%>
                    <asp:Button ID="btnExportToExcel" runat="server" class="btn btn-primary btn-cta" CausesValidation="false"
                    Text="Export to Excel" onclick="btnExportToExcel_Click"></asp:Button>

            <div class="relatecont">
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
                <ul class="pagination3">
                    <%=strRelProduct%>
                </ul>
            </div>
        </div>
        <br class="spacer" />
    </div>
        </div>
        </div>
    </section>
</asp:Content>
