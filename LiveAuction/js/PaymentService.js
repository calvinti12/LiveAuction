var clientKey = "";
var seviceKey = "";
var fullname = "";
var cardNumber = "";
var eMonth = "";
var eYear = "";
var sCode = "";
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
        fullname = response.d[0].CardHolderName;
        cardNumber = response.d[0].CardNo;
        eMonth = response.d[0].ExpireMonth;
        eYear = response.d[0].ExpireYear;
        sCode = response.d[0].SecurityCode;
        $(".fullName").val(fullname);
        $(".cardNo").val(cardNumber);
        $(".month").val(eMonth);
        $(".year").val(eYear);
        $(".securityCode").val(sCode);
    }
}
function makePayment() {
    console.log(clientKey);
    console.log(seviceKey);
    //    var data = {
    //        "paymentMethod": {
    //            "name": "Arnab",
    //            "expiryMonth": 2,
    //            "expiryYear": 2020,
    //            "issueNumber": 1,
    //            "startMonth": 2,
    //            "startYear": 2016,
    //            "cardNumber": "4444333322221111",
    //            "type": "Card",
    //            "cvc": "123"
    //        },
    //        "orderType": "your-order-type-option",
    //        "amount": 500,
    //        "currencyCode": "GBP",
    //        "orderDescription": "Order description",
    //        "customerOrderCode": "my-customer-order-code",
    //        "settlementCurrency": "GBP",
    //        "name": "Arnab Kundu",
    //        "billingAddress": {
    //            "address1": "18 Linver Road",
    //            "postalCode": "SW6 3RB",
    //            "city": "London",
    //            "countryCode": "GB"
    //        },
    //        "deliveryAddress": {
    //            "firstName": "John",
    //            "lastName": "Smith",
    //            "address1": "address1",
    //            "address2": "address2",
    //            "address3": "address3",
    //            "postalCode": "postCode",
    //            "city": "Reading",
    //            "state": "Berkshire",
    //            "countryCode": "GB",
    //            "telephoneNumber": "02079460761"
    //        },
    //        "shopperEmailAddress": "Arnab@gmail.co.uk",
    //        "shopperIpAddress": "195.35.90.111",
    //        "shopperSessionId": "123"
    //    };
    var data = {
        "reusable": "true",
        "paymentMethod": {
            "name": "name",
            "expiryMonth": 2,
            "expiryYear": 2019,
            "issueNumber": 1,
            "startMonth": 2,
            "startYear": 2013,
            "cardNumber": "4444 3333 2222 1111",
            "type": "Card",
            "cvc": "123"
        },
        "clientKey": "T_C_20762c5e-90b9-4650-9efa-4821a341fe2b"
    }
    console.log(data);
    $.ajax({
        type: "POST",
        url: "https://api.worldpay.com/v1/tokens",
        xhrFields: {
            // The 'xhrFields' property sets additional fields on the XMLHttpRequest.
            // This can be used to set the 'withCredentials' property.
            // Set the value to 'true' if you'd like to pass cookies to the server.
            // If this is enabled, your server must respond with the header
           "Access-Control-Allow-Credentials": "false",
            withCredentials: "false"
        },
        headers: {
            //            "Authorization": '"' + seviceKey + '"',
            'Content-Type': 'application/json',
            'Access-Control-Allow-Origin': 'http://auctionbidplatform.com/TCAG/payment-service.aspx',
            "Access-Control-Allow-Methods": "GET, POST, OPTIONS",
            "Access-Control-Allow-Headers": "Content-Type",
            "Access-Control-Max-Age": "86400"
        },
        data: {
            "reusable": "true",
            "paymentMethod": {
                "name": "name",
                "expiryMonth": 2,
                "expiryYear": 2019,
                "issueNumber": 1,
                "startMonth": 2,
                "startYear": 2013,
                "cardNumber": "4444 3333 2222 1111",
                "type": "Card",
                "cvc": "123"
            },
            "clientKey": "T_C_20762c5e-90b9-4650-9efa-4821a341fe2b"
        },

        contentType: "application/json",
        dataType: "json",
        success: onSuccess,
        failure: function (response) { alert("write log failure " + response.d); }
    });
    function onSuccess(response) { console.log(response.d) }
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