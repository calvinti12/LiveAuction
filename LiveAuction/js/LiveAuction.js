$("document").ready(function () {
    var currentLotId;
    var logFileUrl;
    blinkeffect('#blink');
    $("#blink").removeClass("alert alert-danger");
    fetchAllLots();
    startRefresh();
    getUrlVars();
    //-------------------------------------- bid button clicked ---------------------------------
    $("#bidBtn").click(function (e) {
        e.preventDefault();
        var url = logFileUrl;
        var lotId = $('#currentLotId').html();
        logFileUrl = "http://auctionbidplatform.com/TCAG/Admin/log_files/Log_lotNo_" + lotId + ".txt";
        //logFileUrl = "/admin/log_files/Log_lotNo_" + lotId + ".txt";
        $.ajax({
            type: "POST",
            url: "live-auction.aspx/WriteToLog",
            data: '{id:"' + lotId + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: onSuccess,
            failure: function (response) { alert("write log failure " + response.d); }
        });
        function onSuccess(response) {
            if (response.d != "0") {
                //            if (response.d == '0') {
                //                var validUrl = UrlExists(logFileUrl);
                //                if (validUrl) {
                //                    $.get(url, function (response) {
                //                        var logfile = response;
                //                    });
                //                    $(".wel-message").load(url);
                //                    // alert(response.d);
                //                }
                //                else {
                //                }
                //alert(response.d);
                $("#liveBidLogs").html(response.d);
            }
            else {
                //alert(response.d);
                //$("#signInAlert").html("Log in to bid");
                //$("#bidBtn").val("Log in to bid");
                $("#ButtonPlace").html("<a href='#' id='bidBtn' class='btn btn-primary btn-lg btn-bid' data-toggle='modal' data-target='#loginmodal'>Login to Bid</a>");
            }
        }
        function UrlExists(url) {
            var http = new XMLHttpRequest();
            http.open('HEAD', url, false);
            http.send();
            return http.status != 404;
        }
        //        $.ajax({
        //            type: "POST",
        //            url: "live-auction.aspx/FetchAskingBidValue",
        //            data: '{id:"' + lotId + '"}',
        //            contentType: "application/json; charset=utf-8",
        //            dataType: "json",
        //            success: onAskingBidPriceSuccess,
        //            failure: function (response) { alert("failure " + response.d); }
        //        });
        //        function onAskingBidPriceSuccess(response) {
        //            $("#askingBidPrice").html('£ ' + response.d);
        //        }
        fetchAskingBidValue(lotId);
    });
    //------------------------------------- sold button clicked ---------------------------------
    $('#soldBtn').click(function () {
        var lotId = $('#currentLotId').html();
        $.ajax({
            type: "POST",
            url: "live-auction.aspx/SoldItem",
            data: '{id:"' + lotId + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: onSuccess,
            failure: function (response) { alert("write log failure " + response.d); }
        });
        function onSuccess(response) {
            var lots = response.d;
            $('#currentLotImageName').attr('src', lots[0].LotImageUrl);
            $('#currentLotId').html(lots[0].LotId);
            $('#currentLotAuctionName').html(lots[0].AuctionName);
            $('#currentLotDesc').html(lots[0].LotDesc);
            $('#currentLotLowEstimatePrice').html(lots[0].LowEstimatePrice);
            $('#currentLotHighEstimatePrice').html(lots[0].HighEstimatePrice);
            console.log(lots[0].AuctionName);
            var lotsQueue;
            var counter = 0;
            $(lots).each(function (index, element) {
                if (index != 0) {
                    lotsQueue += "<div class='cat-sell-single-item clearfix'><div class='cat-sell-title'><p>" +
                        "<span class='text-primary'><span>Lot&nbsp</span>" + this.LotId + "</span></p></div>" +
							"<div class='cat-sell-tag'><h3>" + this.Title + "</h3>" +
                            "</div>" +
							"<div class='cat-sell-pic-sec'>" +
								"<div class='cat-sell-snt'><img src='" + this.LotImageUrl +
                                "' alt='this is for cat sell snt' class='img-responsive'></div></div></div>";
                }
            });
            $("#lotQueue").html(lotsQueue);
            fetchAllLots();
        }
    });
    //------------------------------------- fair button clicked ---------------------------------
    $('#fairBtn').click(function () {
        $.ajax({
            type: "POST",
            url: "live-auction.aspx/FairWarning",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: onSuccess,
            failure: function (response) { alert("write log failure " + response.d); }
        });
        function onSuccess(response) {
        }
    });
});
//---------------------------------------- fetch all lots section -------------------------------
function fetchAllLots() {
    $.ajax({
        type: "POST",
        url: "live-auction.aspx/FetchAllLots",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: onSuccess,
        failure: function (response) { alert("write log failure " + response.d); }
    });
    function onSuccess(response) {
        var lots = response.d;
        currentLotId = lots[0].LotId;
        $('#currentLotImageName').attr('src', lots[0].LotImageUrl);
        $('#currentLotId').html(lots[0].LotId);
        $('#currentLotAuctionName').html(lots[0].AuctionName);
        $('#currentLotDesc').html(lots[0].LotDesc);
        $('#currentLotLowEstimatePrice').html(lots[0].LowEstimatePrice);
        $('#currentLotHighEstimatePrice').html(lots[0].HighEstimatePrice);

        var currentLot = "<div class='category-sell-item-full-sec'>" +
								"<div class='category-sell-pic'>" +
									"<img id='currentLotImageName' src='" + lots[0].LotImageUrl + "' alt='this is for selling item images' class='img-responsive' />" +
                                 "</div>" +
								"<div class='category-sell-pic-caption text-center'>" +
									"<h1>current lot <span class='currentLotClass'  id='currentLotId'>" + lots[0].LotId + "</span></h1>" +
                                 "</div>" +
							"</div>";  

          var currentLotDescription= "<div class='category-sell-item-des-sec'>"+
                                "<h3 class='text-primary'>Auction : <span id='currentLotAuctionName'>" + lots[0].AuctionName + "</span></h3>"+
                                "<p id='currentLotDesc'>" + lots[0].LotDesc + "</p>"+
                                "<p class='pull-left alert alert-success'>Low estimate price&nbsp;-&nbsp;<span id='currentLotLowEstimatePrice'>£" + lots[0].LowEstimatePrice + "</span></p>"+
                                "<p class='pull-right alert alert-success'>High estimate price&nbsp;-&nbsp;<span id='currentLotHighEstimatePrice'>£" + lots[0].HighEstimatePrice + "</span></p>" +
                            "</div>";

          $("#currentLot").html(currentLot);
          $("#currentLotDesc").html(currentLotDescription);
        var lotsQueue = "";
        var counter = 0;
        $(lots).each(function (index, element) {
            if (index != 0) {
                //                lotsQueue += "<div class='cat-sell-single-item clearfix'><div class='cat-sell-title'><p>" +
                //                        "<span class='text-primary'><span>Lot&nbsp</span>" + this.LotId + "</span></p></div>" +
                //							"<div class='cat-sell-tag'><h3>" + this.Title + "</h3>" +
                //                            "</div>" +
                //							"<div class='cat-sell-pic-sec'>" +
                //								"<div class='cat-sell-snt'><img src='" + this.LotImageUrl +
                //                                "' alt='this is for cat sell snt' class='img-responsive'></div></div></div>";
                //var parsedTitle = showMore(this.Title);
                var parsedTitle = this.Title.slice(0,20)+"..."
                console.log(parsedTitle);
                this.Title = parsedTitle;
                lotsQueue += "<div class='cat-sell-single-item clearfix'>" +
                                "<div class='pull-left'>" +
                                    "<div class='cat-sell-pic'>" +
                                        "<img src='" + this.LotImageUrl + "' />" +
                                        "<p>LOT " + this.LotId + "</p>" +
                                    "</div>" +

                                "</div>" +
                                "<div class='pull-left'>" +
                                    "<div class='cat-sell-dis'>" +
                                        "<p>" + this.Title + "</p>" +
                                    "</div>" +
                                "</div>" +
                            "</div>";
            }
        });
        $("#lotQueue").html(lotsQueue);
        //fetchLotFiles();
        fetchAskingBidValue(currentLotId);
        fetchFairWarning();
    }
}
//----------------------------------------- fetch all text files --------------------------------
function fetchLotFiles() {
    logFileUrl = "http://auctionbidplatform.com/TCAG/Admin/log_files/Log_lotNo_" + lotId + ".txt";
    //logFileUrl = "/admin/log_files/Log_lotNo_" + currentLotId + ".txt";
    console.log(logFileUrl);
    var urlValidate = UrlExists(logFileUrl);
    if (urlValidate) {
        $.get(logFileUrl, function (response) {
            var str = response;
        });
        $(".wel-message").load(logFileUrl);
    }
    else {
        $(".wel-message").html("No bid has been made yet");
    }
}
function UrlExists(url) {
    var http = new XMLHttpRequest();
    http.open('HEAD', url, false);
    http.send();
    return http.status != 404;
}
//----------------------------------------- fetchAskingBidValue ---------------------------------
function fetchAskingBidValue(id) {
    $.ajax({
        type: "POST",
        url: "live-auction.aspx/FetchAskingBidValue",
        data: '{id:"' + id + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: onAskingBidPriceSuccess,
        failure: function (response) { alert("failure " + response.d); }
    });
    function onAskingBidPriceSuccess(response) {
        if (response.d[0].AskingBidOwner != null && response.d[0].AskingBidOwner != "") {
            $("#liveBidLogs").html(response.d[0].AskingBidOwner + ' £' + response.d[0].BidValue);
        }
        else {
            $("#liveBidLogs").html("Item sold <br/> New item has been arrived");
        }

        $("#askingBidPrice").html('£' + response.d[0].BidValue);
    }
}
function fetchFairWarning() {
    $.ajax({
        type: "POST",
        url: "live-auction.aspx/FetchFairWarning",
        data: '{id:"' + currentLotId + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: onfetchFairWarningSuccess,
        failure: function (response) { alert("failure " + response.d); }
    });
    function onfetchFairWarningSuccess(response) {
        if (response.d) {
            $("#blink").addClass("alert alert-danger");
            $("#blink").html('Fair warning !');
        }
        else {
            $("#blink").removeClass("alert alert-danger");
            $("#blink").html(""); 
        }
    }
}
function startRefresh() {
    var lotId = $('#currentLotId').html();
    setTimeout(startRefresh, 1000);
    fetchAllLots();
}
function blinkeffect(selector) {
    $(selector).fadeOut(1000, function () {
        $(this).fadeIn(1000, function () {
            blinkeffect(this);
        });
    });
}
function getUrlVars() {
    var vars = [], hash;
    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < hashes.length; i++) {
        hash = hashes[i].split('=');
        vars.push(hash[0]);
        vars[hash[0]] = hash[1];
    }
    if (vars.cat == 'watch') {
        $("#bidBtn").hide();
    }
}
function showMore(originalContent) {
    var showChar = 8;
    var ellipsestext = "...";
    var moretext = "more";
    var lesstext = "less";
        var content = originalContent;
        if (content.length > showChar) {
            var c = content.substr(0, showChar);
            var html = c + ellipsestext;
            return html;
        }
}