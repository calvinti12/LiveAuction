<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="live-auction.aspx.cs" Inherits="LiveAuction.live_auction"
    MasterPageFile="~/Bidder.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="js/custom.js" type="text/javascript"></script>
    <script type="text/javascript">
        function blinkeffect(selector) {
            $(selector).fadeOut(1000, function () {
                $(this).fadeIn(1000, function () {
                    blinkeffect(this);
                });
            });
        }
        $("document").ready(function () {
           // $('.blink').blink({ delay: 150 });
            // $(".blink").effect("pulsate", { times: 5 }, 3000);
            blinkeffect('.blink');
            var lotId = $(".currentLotClass").html();
            //var logFileUrl = "http://auctionbidplatform.com/TCAG/Admin/log_files/Log_lotNo_" + lotId + ".txt";
            var logFileUrl = "Admin/log_files/Log_lotNo_" + lotId + ".txt";
            console.log(logFileUrl);
            var urlValidate = UrlExists(logFileUrl);
            if (urlValidate) {
                $.get(logFileUrl, function (response) {
                    var str = response;
                    //                    var res = str.match(/\b\d{2}[-]?\d{2}[-]?\d{4}? \d{2}?:\d{2}?:\d{2}\b/g);
                    //                    for (var i = 0; i < res.length; i++) {
                    //                        var date = new Date(res[i]);
                    //                        var day = "2016-05-08 09:08:04";
                    //                        var tDate = new Date(day).toLocaleString();
                    //                        console.log(tDate);
                    //                    }
                });
                $(".wel-message").load(logFileUrl);
            }
            else {
                $(".wel-message").html("No bid has been made yet");
            }
            $(".bidBtn").click(function (e) {
                e.preventDefault();
                var url = logFileUrl;
                $.ajax({
                    type: "POST",
                    url: "live-auction.aspx/WriteToLog",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: onSuccess,
                    failure: function (response) { alert("write log failure " + response.d); }
                });
                function onSuccess(response) {
                    var validUrl = UrlExists(url);
                    if (validUrl) {
                        $.get(url, function (response) {
                            var logfile = response;
                            console.log(logfile)
                        });
                        $(".wel-message").load(url);
                        // alert(response.d);
                    }
                    else {
                    }
                }
                function UrlExists(url) {
                    var http = new XMLHttpRequest();
                    http.open('HEAD', url, false);
                    http.send();
                    return http.status != 404;
                }
                $.ajax({
                    type: "POST",
                    url: "live-auction.aspx/FetchAskingBidValue",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: onAskingBidPriceSuccess,
                    failure: function (response) { alert("failure " + response.d); }
                });
                function onAskingBidPriceSuccess(response) {
                    $("#askingBidPrice").html((response.d));
                }
            });
            function UrlExists(url) {
                var http = new XMLHttpRequest();
                http.open('HEAD', url, false);
                http.send();
                return http.status != 404;
            }
        });
    </script>
    <!-- this is the breadcumbs area -->
    <section class="breadcumbs-area-sec">
         <div class="container">
             <div class="row">
                 <div class="col-md-12">
                     <div class="breadcumb">
                     <a href="index.aspx" class="incative">Home &raquo; </a>Live Auctions &raquo;</div>
                 </div>
             </div>
         </div>
     </section>
    <!-- end of breadcumbs area -->
    <!-- this is the start of category display sell page -->
    <section class="category-sell">
		<div class="container">
			<div class="row">
				<div class="col-md-8 col-sm-12 col-xs-12">
					<div class="row">
                        <asp:PlaceHolder ID = "PlaceHolderCurrentLot" runat="server"/>
						<div class="col-md-6 col-sm-6 col-xs-12">
							<div class="category-curent-itm-dis">
								<div class="panel panel-default">
								  <div class="panel-heading">
								    <h3 class="text-primary panel-ttle-cat">Live video</h3>
                                    <div class="">
                                     <video width="320" height="240" controls  poster="video_contents/video.gif">
                                        <%--<source src="video_contents/movie.mp4" type="video/mp4">
                                        <source src="video_contents/movie.ogg" type="video/ogg">--%>
                                        Your browser does not support the video tag.
                                     </video> 
                                     </div>
								  </div>
								  <div class="panel-body">
								    <div class="cat-it-dis">
								    	<p class="text-success">successfully conected to server</p>
								    	<div class="wel-message" style="font-size:12px;"></div>
								    </div>
								  </div>
								  <div class="panel-footer">
								  	<div class="ttll-pnl-foot clearfix">
								  		<div class="pull-left">
											<h2>Asking Bid</h2>
                                            <asp:PlaceHolder ID="PlaceHolderAskingBid" runat="server"></asp:PlaceHolder>
										</div>
                                        <div class="pull-left" style="margin-left:10%;color:#a94442">
											<h4 id="counterDiv">30sec</h4>
                                            <h4><span class="blink"></span></h4>
										</div>
                                        <script type='text/javascript'>
                                            $(function () {
                                                //var austDay = new Date();
                                                //austDay = new Date('2016-09-09T12:00:00');
                                                Timer();
                                                function Timer() {
                                                    var time = new Date();
                                                    time.setSeconds(time.getSeconds() + 10);
                                                    $('#counterDiv').countdown({ until: time, compact: true,
                                                        format: 'S', description: 'sec', onExpiry: liftOff
                                                    });
                                                }
                                                function liftOff() {
                                                    //alert('Time expired');

                                                    Timer();
//                                                    $.ajax({
//                                                        type: "POST",
//                                                        url: "live-auction.aspx/UpdateCurrentLot",
//                                                        contentType: "application/json; charset=utf-8",
//                                                        dataType: "json",
//                                                        success: onUpdateCurrentLotSuccess,
//                                                        failure: function (response) { alert("failure " + response.d); }
//                                                    });
                                                    function onUpdateCurrentLotSuccess(response) {
                                                          $.ajax({
                                                          type: "POST",
                                                          url: "live-auction.aspx/FetchCurrentLot",
                                                          contentType: "application/json; charset=utf-8",
                                                          dataType: "json",
                                                          success: function (response) { alert("failure " + response.d); },
                                                          failure: function (response) { alert("failure " + response.d); }
                                                          });
                                                    }
                                                }
                                            });
                                        </script>
										<div class="pull-right">
                                            <asp:PlaceHolder ID="PlaceHolderBidButton" runat="server"></asp:PlaceHolder>
										</div>
								  	</div>
								  </div>
								</div>
							</div>
						</div>
					</div>
				</div>
				<div class="col-md-4 col-sm-12 col-xs-12">
					<div class="catergory-sell-item-sw clearfix">
                        <asp:PlaceHolder ID = "PlaceHolderQueueLot" runat="server"/>
					</div>
				</div>
			</div>
		</div>

	</section>
    <!-- this is the start of category display  sell page -->
</asp:Content>
