$("document").ready(function () {
    var currentLotId;
    var logFileUrl;
    blinkeffect('.blink');
    fetchAllLots();
    startRefresh();
    //----------------------- bid button clicked ---------------------------------
    $(".bidBtn").click(function (e) {
        e.preventDefault();
        var url = logFileUrl;
        var lotId = $('#currentLotId').html();
        //logFileUrl = "http://auctionbidplatform.com/TCAG/Admin/log_files/Log_lotNo_" + lotId + ".txt";
        logFileUrl = "/admin/log_files/Log_lotNo_" + lotId + ".txt";
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
            if (response.d == '0') {

                var validUrl = UrlExists(logFileUrl);
                if (validUrl) {

                    $.get(url, function (response) {
                        var logfile = response;
                    });
                    $(".wel-message").load(url);
                    // alert(response.d);
                }
                else {
                }
            }
            else {
                alert(response.d);
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
            data: '{id:"' + lotId + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: onAskingBidPriceSuccess,
            failure: function (response) { alert("failure " + response.d); }
        });
        function onAskingBidPriceSuccess(response) {
            $("#askingBidPrice").html('£ ' + response.d);
        }
    });
    //--------------------------- sold button clicked ------------------------------------------
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
    //------------------------------ fair button clicked ---------------------------------------------------------
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
//----------------------------------- fetch all lots section ------------------------------------------------
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
        console.log('current lot id ' + currentLotId);
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
							"</div>" +
							"<div class='category-sell-item-des-sec'>" +
								"<h3 class='text-primary'>Auction : <span id='currentLotAuctionName'>" + lots[0].AuctionName + "</span></h3>" +
                                "<p id='currentLotDesc'>" + lots[0].LotDesc + "</p>" +
                                "<p>Low estimate price&nbsp-&nbsp<span id='currentLotLowEstimatePrice'>" + lots[0].LowEstimatePrice + "</span>£</p>" +
                                "<p>High estimate price&nbsp-&nbsp<span id='currentLotHighEstimatePrice'>" + lots[0].HighEstimatePrice + "</span>£</p>" +
                                "</div>";
        $("#currentLot").html(currentLot)
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
        //fetchLotFiles();
        fetchAskingBidValue(currentLotId);
        fetchFairWarning();
    }
}
//-------------------------------- fetch all text files ------------------------------------------------------------------
function fetchLotFiles() {
     //logFileUrl = "http://auctionbidplatform.com/TCAG/Admin/log_files/Log_lotNo_" + lotId + ".txt";
    console.log('lot id ' + currentLotId);
    logFileUrl = "/admin/log_files/Log_lotNo_" + currentLotId + ".txt";
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
//------------------------------ fetchAskingBidValue -----------------------------------------------
function fetchAskingBidValue(id) {

    console.log("currentLotId" + id);
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
        $("#askingBidPrice").html('£ '+response.d);
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
        console.log(response.d);
        if (response.d) {
            $(".blink").html('Fair warning !');
        }
        else
        { $(".blink").html(''); }
    }
}
function startRefresh() {
 var lotId = $('#currentLotId').html();
    setTimeout(startRefresh, 1000);
    console.log('refresh made');
    fetchAllLots();
}
function blinkeffect(selector) {
    $(selector).fadeOut(1000, function () {
        $(this).fadeIn(1000, function () {
            blinkeffect(this);
        });
    });
}