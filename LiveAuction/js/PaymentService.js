var clientKey = "";
var seviceKey = "";
$("document").ready(function () {
    GetUserData();
    ApiKeys();
    $(".makePayment").click(function (e) {
        e.preventDefault();
        makePayment();
    });
});
function GetUserData() {
    $.ajax({
        type: "POST",
        url: "payment-service.aspx/GetCardDetail",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: onSuccess,
        failure: function (response) { alert("write log failure " + response.d); }
    });
    function onSuccess(response) {
        $(".fullName").val(response.d[0].CardHolderName);
        $(".cardNo").val(response.d[0].CardNo);
        $(".month").val(response.d[0].ExpireMonth);
        $(".year").val(response.d[0].ExpireYear);
        $(".securityCode").val(response.d[0].SecurityCode);
    }
}
function makePayment() {

    console.log(clientKey);
    console.log(seviceKey);
//    $.ajax({
//        type: "POST",
//        url: "payment-service.aspx/GetCardDetail",
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        success: onSuccess,
//        failure: function (response) { alert("write log failure " + response.d); }
//    });
//    function onSuccess(response) {
//        $(".fullName").val(response.d[0].CardHolderName);
//        $(".cardNo").val(response.d[0].CardNo);
//        $(".month").val(response.d[0].ExpireMonth);
//        $(".year").val(response.d[0].ExpireYear);
//        $(".securityCode").val(response.d[0].SecurityCode);
//    }
}
function ApiKeys() { 
$.ajax({
        type: "POST",
        url: "payment-service.aspx/FetchApiKeys",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: onSuccess,
        failure: function (response) { alert("write log failure " + response.d); }
    });
    function onSuccess(response) {
        clientKey = response.d[0].ClientKey;
        seviceKey = response.d[0].ServiceKey;
    }
}