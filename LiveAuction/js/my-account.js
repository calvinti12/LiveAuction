var password = "";
$("document").ready(function () {
    LoadMyAccountDetails();
    $(".personalInforSuccessMsg").hide();
    $(".cardInforSuccessMsg").hide();
    $(".addressSuccessMsg").hide();
    $(".passwordSuccessMsg").hide();
    $(".updatePersonalInfoBtn").click(function (e) {
        e.preventDefault();
        var fName = $(".firstname").val();
        var lName = $(".lastname").val();
        var email = $(".email").val();
        var telephone = $(".telephone").val();
        var country = $(".country").val();
        UpdatePersonalInfo(fName, lName, email, telephone, country);
    });
    $(".updateCardInfo").click(function (e) {
        e.preventDefault();
        var cardno = $(".cardno").val();
        var strtingmonth = $(".strtingmonth").val();
        var startingyear = $(".startingyear").val();
        var expmonth = $(".expmonth").val();
        var expyear = $(".expyear").val();
        var securitycode = $(".securitycode").val();
        var cardholdername = $(".cardholdername").val();
        UpdateCardInformation(cardno, strtingmonth, startingyear, expmonth, expyear, securitycode, cardholdername);
    });
    $(".updateAddress").click(function (e) {
        e.preventDefault();
        var address = $(".address").val();
        UpdateAddressInformation(address);
    });
    $(".changePass").click(function (e) {
        e.preventDefault();
        var oldPassword = $(".oldPass").val();
        var newPassword = $(".newPass").val();
        var confirmPass = $(".confirmPass").val();
        if (oldPassword.length > 3 && newPassword.length > 0 && confirmPass.length > 3) {
            if (newPassword == confirmPass && password == oldPassword) {
                UpdatePassword(newPassword);
            }
            else { alert("Please check the fields !") }
        }
        else { alert("Password fields can not be blank !") }
    });
});
function LoadMyAccountDetails() {
    $.ajax({
        type: "POST",
        url: "my-account.aspx/LoadAccountDetails",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: onSuccess,
        failure: function (response) { alert("write log failure " + response.d); }
    });
    function onSuccess(response) {
        password = response.d[0].Password;
        $(".firstname").val(response.d[0].FirstName);
        $(".lastname").val(response.d[0].LastName);
        $(".email").val(response.d[0].Email);
        $(".telephone").val(response.d[0].Telephone);
        $(".country").val(response.d[0].Country);

        $(".cardno").val(response.d[0].CardNo);
        $(".strtingmonth").val(response.d[0].CardStartMonth);
        $(".startingyear").val(response.d[0].CardStartYear);
        $(".expmonth").val(response.d[0].CardExpiryMonth);
        $(".expyear").val(response.d[0].CardExpiryYear);
        $(".securitycode").val(response.d[0].SecurityCode);
        $(".cardholdername").val(response.d[0].CardHolderName);

        $(".address").val(response.d[0].Address);
    }
}
function UpdatePersonalInfo(fName, lName, email,telephone, country) {
    data = {
        'FirstName': fName,
        'LastName': lName,
        'Email': email,
        'Telephone': telephone,
        'Country': country
    };
    $.ajax({
        type: "POST",
        url: "my-account.aspx/UpdatePersonalInfo",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: onSuccess,
        failure: function (response) { alert("write log failure " + response.d); }
    });
    function onSuccess(response) {
        $(".personalInforSuccessMsg").show().fadeOut(5000);
     }

 }
function UpdateCardInformation(cardno, strtingmonth, startingyear, expmonth, expyear, securitycode, cardholdername) {
    data = {
        'CardNo': cardno,
        'CardStartMonth': strtingmonth,
        'CardStartYear': startingyear,
        'CardExpiryMonth': expmonth,
        'CardExpiryYear': expyear,
        'SecurityCode': securitycode,
        'CardHolderName': cardholdername
    };
    $.ajax({
        type: "POST",
        url: "my-account.aspx/UpdateCardInfo",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: onSuccess,
        failure: function (response) { alert("write log failure " + response.d); }
    });
    function onSuccess(response) {
        $(".cardInforSuccessMsg").show().fadeOut(5000);
    }
}
function UpdateAddressInformation(address) {
    data = {'Address': address};
    $.ajax({
        type: "POST",
        url: "my-account.aspx/UpdateAddressInfo",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: onSuccess,
        failure: function (response) { alert("write log failure " + response.d); }
    });
    function onSuccess(response) {
        $(".addressSuccessMsg").show().fadeOut(5000);
    }
}
function UpdatePassword(newPassword) {
    data = { 'Password': newPassword };
    $.ajax({
        type: "POST",
        url: "my-account.aspx/UpdatePassword",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: onSuccess,
        failure: function (response) { alert("write log failure " + response.d); }
    });
    function onSuccess(response) {
        $(".passwordSuccessMsg").show().fadeOut(5000);
    
    }
}