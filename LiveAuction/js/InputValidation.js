// JScript File



// function for required textbox
function RequiredTxt(strControlName, strAlertMessage) {
    //alert("RequiredTxt");
    if (document.getElementById(strControlName).value == "" || document.getElementById(strControlName).value.match(/^\s[ \t]*$/)) {
        inlineMsg(strControlName, strAlertMessage, 2);
        document.getElementById(strControlName).value = "";
        document.getElementById(strControlName).focus();
        //alert("Required");
        return true;
    }
    return false;
}

function ValMobile(strControlName, strAlertMessage) {
    if (document.getElementById(strControlName).value.match(/^[789]\d{9}$/)) {
        return false; 
    }
    else {
        document.getElementById(strControlName).value = "";
        inlineMsg(strControlName, strAlertMessage, 2);
       return true;
    }
}

function RequiredTxtNew(strControlName, strControlShow, strAlertMessage) {

    if (document.getElementById(strControlName).value == "" || document.getElementById(strControlName).value.match(/^\s[ \t]*$/)) {
        inlineMsg(strControlShow, strAlertMessage, 2);
        document.getElementById(strControlName).value = "";
        document.getElementById(strControlName).focus();
        return true;
    }
    return false;
}
//function for Password character count

function PasswordCount(strControlName, strAlertMessage) {
    var obj = document.getElementById(strControlName).value;
    if (obj.length < 6 || obj.length > 200) {
        inlineMsg(strControlName, strAlertMessage, 2);
        document.getElementById(strControlName).value = "";
        document.getElementById(strControlName).focus();
        return true;
    }
    return false;
}

// function for required DDL
function RequiredDDl(strControlName, strAlertMessage) {
    if (document.getElementById(strControlName).selectedIndex == 0) {
        inlineMsg(strControlName, strAlertMessage, 2);
        document.getElementById(strControlName).focus();
        return true;
    }
    return false;
}

// function for required matching of two textbox
function RequiredMatch(strCtrl1, strCtrl2, strMsg) {
    if (document.getElementById(strCtrl1).value != document.getElementById(strCtrl2).value) {
        inlineMsg(strCtrl2, strMsg, 2);
        document.getElementById(strCtrl2).value = "";
        document.getElementById(strCtrl2).focus();
        return true;
    }
    return false;
}
// function for Start date and End date Checking

function EndDateCheck(strCtrl1, strCtrl2, strMsg) {
    var startDate = new Date(document.getElementById(strCtrl1).value);
    var finishDate = new Date(document.getElementById(strCtrl2).value);
    if (startDate > finishDate) {
        inlineMsg(strCtrl2, strMsg, 2);
        document.getElementById(strCtrl2).value = "";
        document.getElementById(strCtrl2).focus();
        return true;
    }
    return false;
}

// function for Capcha matching of two textbox in lower case  // Added by anjan
function CapchaMatch(strCtrl1, strCtrl2, strMsg) {
    if (document.getElementById(strCtrl1).value.toLowerCase() != document.getElementById(strCtrl2).value.toLowerCase()) {
        inlineMsg(strCtrl2, strMsg, 2);
        document.getElementById(strCtrl2).value = "";
        document.getElementById(strCtrl2).focus();
        return true;
    }
    return false;
}

// function for validate Email
function ValEMail(strControlName, strAlertMessage) {
    if (document.getElementById(strControlName).value.length != 0) {
        if (!document.getElementById(strControlName).value.match(/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[­A-Za-z0-9]+$/)) {
            inlineMsg(strControlName, strAlertMessage, 2);
            document.getElementById(strControlName).focus();
            return true;
        }
        return false;
    }
    return false;
}

// function for validate website
function ValWebSite(strControlName, strAlertMessage) {
    if (document.getElementById(strControlName).value.length != 0) {
        if (!document.getElementById(strControlName).value.match(/\w+([-.]\w+)*\.\w+([-.]\w+)*/)) {
            inlineMsg(strControlName, strAlertMessage, 2);
            document.getElementById(strControlName).focus();
            return true;
        }
    }
}

// function for validate for numeric
function ValNumeric(strControlName, strAlertMessage) {
    if (document.getElementById(strControlName).value.length != 0) {
        if (document.getElementById(strControlName).value.match(/[^0-9]/)) {
            inlineMsg(strControlName, strAlertMessage, 2);
            document.getElementById(strControlName).focus();
            return true;
        }
    }
}
function CheckTwoNumber(strControlName,strControlName1, strAlertMessage) {
    if (document.getElementById(strControlName).value.length != 0&& document.getElementById(strControlName1).value.length != 0) {
    var Value1=parseInt(document.getElementById(strControlName).value);
    var Value2=parseInt(document.getElementById(strControlName1).value);
    if (Value1 < Value2) {
            inlineMsg(strControlName1, strAlertMessage, 2);
            document.getElementById(strControlName1).focus();
            return true;
        }
    }
}
function CheckTwoDLL(strControlName,strControlName1,strAlertMessage) {
    if (document.getElementById(strControlName).selectedIndex == document.getElementById(strControlName1).selectedIndex) {
        inlineMsg(strControlName1, strAlertMessage, 2);
        document.getElementById(strControlName1).focus();
        return true;
    }
    return false;
}
// function for required selection in checkboxlist
function CblCheckReq(strControlName, strAlertMessage) {
    var chkList1 = document.getElementById(strControlName);
    var arrayOfCheckBoxes = chkList1.getElementsByTagName("input");
    for (var i = 0; i < arrayOfCheckBoxes.length; i++) {
        if (arrayOfCheckBoxes[i].checked == true) {
            return false;
        }
    }
    inlineMsg(strControlName, strAlertMessage, 2);
    document.getElementById(strControlName).focus();
    return true;
}

// function for required selection in radiobuttonlist
function RadbtnLstCheckReq(strControlName, strAlertMessage) {
    var rdbtnlst = document.getElementById(strControlName);
    var arrayOfRadioButtons = rdbtnlst.getElementsByTagName("input");
    for (var i = 0; i < arrayOfRadioButtons.length; i++) {
        if (arrayOfRadioButtons[i].checked == true) {
            return false;
        }
    }
    inlineMsg(strControlName, strAlertMessage, 2);
    document.getElementById(strControlName).focus();
    return true;
}

// function for valid numeric
function ValNumeric(strControlName, strAlertMessage) {
    if (document.getElementById(strControlName).value.length != 0) {
        if (document.getElementById(strControlName).value.match(/[^0-9]/)) {
            inlineMsg(strControlName, strAlertMessage, 2);
            document.getElementById(strControlName).focus();
            return true;
        }
        return false;
    }
    return false;
}

//Alphanumeric

function alphaNumeric(strControlName, strAlertMessage) {
    //document.getElementById(strPassword).value = document.getElementById(strControlName).value;

    var obj = document.getElementById(strControlName).value;

    if (!obj.match(/([a-zA-Z]+[0-9][a-zA-Z0-9]*)|([0-9]+[a-zA-Z][a-zA-Z0-9]*)$/)) {

        inlineMsg(strControlName, strAlertMessage, 2);
        document.getElementById(strControlName).value = "";
        document.getElementById(strControlName).focus();
        return true;
    }
    return false;
}





// function for must select listbox
function RequiredLB(strControlName, strAlertMessage) {
    if (document.getElementById(strControlName).value == 0) {
        inlineMsg(strControlName, strAlertMessage, 2);
        document.getElementById(strControlName).focus();
        return true;
    }
}
// START OF MESSAGE SCRIPT //

var MSGTIMER = 90;
var MSGSPEED = 5;
var MSGOFFSET = 3;
var MSGHIDE = 3;


// build out the divs, set attributes and call the fade function //
function showMsg(target, string, autohide) {

    var msg;
    var msgcontent;
    if (!document.getElementById('msg')) {
        msg = document.createElement('div');
        msg.id = 'msg';
        msgcontent = document.createElement('div');
        msgcontent.id = 'msgcontent';
        document.body.appendChild(msg);
        msg.appendChild(msgcontent);
        msg.style.filter = 'alpha(opacity=0)';
        msg.style.opacity = 0;
        msg.alpha = 0;
    } else {
        msg = document.getElementById('msg');
        msgcontent = document.getElementById('msgcontent');
    }
    msgcontent.innerHTML = string;
    msg.style.display = 'block';
    var msgheight = msg.offsetHeight;
    var targetdiv = target;
    targetdiv.focus();
    var targetheight = targetdiv.offsetHeight;
    var targetwidth = targetdiv.offsetWidth;
    var topposition = topPosition(targetdiv) - ((msgheight - targetheight) / 2);
    var leftposition = leftPosition(targetdiv) + targetwidth + MSGOFFSET;
    msg.style.top = topposition + 'px';
    msg.style.left = leftposition + 'px';
    clearInterval(msg.timer);
    msg.timer = setInterval("fadeMsg(1)", MSGTIMER);
    if (!autohide) {
        autohide = MSGHIDE;
    }
    window.setTimeout("hideMsg()", (autohide * 3000));
}
// build out the divs, set attributes and call the fade function //
function sucessMsg(target, string, autohide) {

    var msg;
    var sucessmsgcontent;
    if (!document.getElementById('msg')) {
        msg = document.createElement('div');
        msg.id = 'msg';
        sucessmsgcontent = document.createElement('div');
        sucessmsgcontent.id = 'sucessmsgcontent';
        document.body.appendChild(msg);
        msg.appendChild(sucessmsgcontent);
        msg.style.filter = 'alpha(opacity=0)';
        msg.style.opacity = 0;
        msg.alpha = 0;
    } else {
        msg = document.getElementById('msg');
        sucessmsgcontent = document.getElementById('sucessmsgcontent');
    }
    sucessmsgcontent.innerHTML = string;
    msg.style.display = 'block';
    var msgheight = msg.offsetHeight;
    var targetdiv = document.getElementById(target);
    targetdiv.focus();
    var targetheight = targetdiv.offsetHeight;
    var targetwidth = targetdiv.offsetWidth;
    var topposition = topPosition(targetdiv) - ((msgheight - targetheight) / 2);
    var leftposition = leftPosition(targetdiv) + targetwidth + MSGOFFSET;
    msg.style.top = topposition + 'px';
    msg.style.left = leftposition + 'px';
    clearInterval(msg.timer);
    msg.timer = setInterval("fadeMsg(1)", MSGTIMER);
    if (!autohide) {
        autohide = MSGHIDE;
    }
    window.setTimeout("hideMsg()", (autohide * 2500));
}
// build out the divs, set attributes and call the fade function //
function inlineMsg(target, string, autohide) {
//    alert("inlineMsg");
    var msg;
    var msgcontent;
    if (!document.getElementById('msg')) {
        msg = document.createElement('div');
        msg.id = 'msg';
        msgcontent = document.createElement('div');
        msgcontent.id = 'msgcontent';
        document.body.appendChild(msg);
        msg.appendChild(msgcontent);
        msg.style.filter = 'alpha(opacity=0)';
        msg.style.opacity = 0;
        msg.alpha = 0;
    } else {
        msg = document.getElementById('msg');
        msgcontent = document.getElementById('msgcontent');
    }
    msgcontent.innerHTML = string;
    msg.style.display = 'block';
    var msgheight = msg.offsetHeight;
    var targetdiv = document.getElementById(target);
    targetdiv.focus();
    var targetheight = targetdiv.offsetHeight;
    var targetwidth = targetdiv.offsetWidth;
    var topposition = topPosition(targetdiv) - ((msgheight - targetheight) / 2);
    var leftposition = leftPosition(targetdiv) + targetwidth + MSGOFFSET;
    msg.style.top = topposition + 'px';
    msg.style.left = leftposition + 'px';
    msg.cssName = "errormsg";
//    alert(msg.style.top + " : " + msg.style.left + " : " + msg.cssName);
    clearInterval(msg.timer);
    msg.timer = setInterval("fadeMsg(1)", MSGTIMER);
    if (!autohide) {
        autohide = MSGHIDE;
    }
    window.setTimeout("hideMsg()", (autohide * 1000));
}

// hide the form alert //
function hideMsg(msg) {
    var msg = document.getElementById('msg');
    if (!msg.timer) {
        msg.timer = setInterval("fadeMsg(0)", MSGTIMER);
    }
}

// face the message box //
function fadeMsg(flag) {
    if (flag == null) {
        flag = 1;
    }
    var msg = document.getElementById('msg');
    var value;
    if (flag == 1) {
        value = msg.alpha + MSGSPEED;
    } else {
        value = msg.alpha - MSGSPEED;
    }
    msg.alpha = value;
    msg.style.opacity = (value / 100);
    msg.style.filter = 'alpha(opacity=' + value + ')';
    if (value >= 99) {
        clearInterval(msg.timer);
        msg.timer = null;
    } else if (value <= 1) {
        msg.style.display = "none";
        clearInterval(msg.timer);
    }
}

// calculate the position of the element in relation to the left of the browser //
function leftPosition(target) {
    var left = 0;
    if (target.offsetParent) {
        while (1) {
            left += target.offsetLeft;
            if (!target.offsetParent) {
                break;
            }
            target = target.offsetParent;
        }
    } else if (target.x) {
        left += target.x;
    }
    return left;
}

// calculate the position of the element in relation to the top of the browser window //
function topPosition(target) {
    var top = 0;
    if (target.offsetParent) {
        while (1) {
            top += target.offsetTop;
            if (!target.offsetParent) {
                break;
            }
            target = target.offsetParent;
        }
    } else if (target.y) {
        top += target.y;
    }
    return top;
}

// preload the arrow //
if (document.images) {
    arrow = new Image(7, 80);
    arrow.src = "images/msg_arrow.gif";
}




//Comparing Two Dates

function CompareDates(strControl1, strControl2, alertmessage) {

    var objStart = document.getElementById(strControl1).value;
    var startDateSplit = objStart.split('/');
    var objStartDay = parseInt(startDateSplit[0]);
    var objStartMonth = parseInt(startDateSplit[1]);
    var objStartYear = parseInt(startDateSplit[2]);
    var startdate = objStartMonth + "/" + objStartDay + "/" + objStartYear;

    var objEnd = document.getElementById(strControl2).value;
    var endDateSplit = objEnd.split('/');
    var objEndDay = parseInt(endDateSplit[0]);
    var objEndMonth = parseInt(endDateSplit[1]);
    var objEndYear = parseInt(endDateSplit[2]);
    var enddate = objEndMonth + "/" + objEndDay + "/" + objEndYear;

    var startdates = new Date(startdate);
    var enddates = new Date(enddate);

    if (enddates < startdates) {
        inlineMsg(strControl2, alertmessage, 2);
        document.getElementById(strControl2).value = "";
        document.getElementById(strControl2).focus();
        return true;

    }
    return false;

}

