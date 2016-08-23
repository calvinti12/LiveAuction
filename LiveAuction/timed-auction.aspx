<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Bidder.Master" CodeBehind="timed-auction.aspx.cs"
    Inherits="LiveAuction.timed_auction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="js/custom.js" type="text/javascript"></script>
    <!-- end of slider seciton -->
    <section class="today-item-section">
        <div class="container">
            <div class="row">
            <asp:PlaceHolder ID = "PlaceHolder1" runat="server"/>
            </div>
        </div>
    </section>
    <!-- end of action item section -->
    
    <!-- end of item carousel  section -->
    <section class="today-item-section">
        <div class="container">
            <div class="row">
                <asp:PlaceHolder ID="TodaysDealPlaceholder" runat="server"></asp:PlaceHolder>
                <asp:PlaceHolder ID="UpcomingAuctionPlaceHolder" runat="server"></asp:PlaceHolder>
            </div>
        </div>
    </section>
    <!-- end of action item section -->
    <asp:PlaceHolder ID="PlaceHolder2" runat="server" />
    <script type="text/javascript">
        //console.log(todayDeal);
        var deal = todayDeal
        $(".todaysAction").click(function () {
            var id = $(".auctionId").val();
            // console.log(id + " clicked");
            //var AuctionName = todayDeal[0].auctionName;
            console.log(deal[1]);
            // $("#myModalLabel").html(AuctionName);
            var path = "./Admin/FileUpload/" + deal[1].auctionImageName;
            console.log(path);
            $(".bid-popup-pic").attr("src", path);
            console.log(pic);
        });
    </script>
</asp:Content>
