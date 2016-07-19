<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SellerLeftPanel.ascx.cs"
    Inherits="LiveAuction.UserControl.SellerLeftPanel" %>
<div class="col-md-3">
    <div class="cr-accnt">
        <div class="account-selling-lstItem-sec">
            <div class="account-selling-title">
                <strong>
                    <h4>
                        selling</h4>
                </strong>
            </div>
            <div class="account-selling-lstItem">
                <ul class="list-unstyled">
                    <li id="liDashboard"><a href="../seller-track/dashboard.aspx">Dashboard</a></li>
                    <li id="liAdvertise"><a href="../seller-track/advertise.aspx">Advertise</a></li>
                    <li id="liItems"><a href="../seller-track/sell-item.aspx">Items</a></li>
                    <li id="liAuctions"><a href="../seller-track/item-auction.aspx">Auctions</a></li>
                    <li id="liCSVAuctions"><a href="../seller-track/item-csv.aspx">CSV Auctions</a></li>
                    <li id="liItemUpload"><a href="../seller-track/list-item.aspx">Lot Item Upload</a></li>
                    <li id="liDealUpload"><a href="../seller-track/list-deal.aspx">Deals Upload</a></li>
                </ul>
            </div>
        </div>
        <!-- end of item accont selling -->
        <div class="account-selling-lstItem-sec">
            <div class="account-selling-title">
                <strong>
                    <h4>
                        sales</h4>
                </strong>
            </div>
            <div class="account-selling-lstItem">
                <ul class="list-unstyled">
                    <li id="liMoney"><a href="../seller-track/money.aspx">Your money</a></li>
                    <li id="liFeedback"><a href="../seller-track/feedback.aspx">Feedback</a></li>
                    <li id="liStats"><a href="../seller-track/stats.aspx">Stats</a></li>
                </ul>
            </div>
        </div>
        <div class="account-selling-lstItem-sec">
            <div class="account-selling-title">
                <strong>
                    <h4>
                        Account</h4>
                </strong>
            </div>
            <div class="account-selling-lstItem">
                <ul class="list-unstyled">
                    <li id="liAccount"><a href="../seller-track/account-info.aspx">Account info</a></li>
                    <li id="liReminders"><a href="#">Reminders</a></li>
                    <li id="liInbox"><a href="../seller-track/inbox.aspx">Inbox</a></li>
                    <li><a href="#">Sign Out</a></li>
                </ul>
            </div>
        </div>
        <div class="account-selling-lstItem-sec">
            <div class="account-selling-title">
                <strong>
                    <h4>
                        Purchases</h4>
                </strong>
            </div>
            <div class="account-selling-lstItem">
                <ul class="list-unstyled">
                    <li><a href="#">My Orders</a></li>
                </ul>
            </div>
        </div>
        <div class="account-selling-lstItem-sec">
            <div class="account-selling-title">
                <strong>
                    <h4>
                        Help & Support</h4>
                </strong>
            </div>
            <div class="account-selling-lstItem">
                <ul class="list-unstyled">
                    <li><a href="#">Contact Us</a></li>
                    <li><a href="#">Cases</a></li>
                    <li><a href="#">FAQs</a></li>
                    <li><a href="#">Forums</a></li>
                </ul>
            </div>
        </div>
    </div>
    <!-- end of cr-accnt for left sideber -->
</div>
