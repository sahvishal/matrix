// JScript File
function include(file) {

    var script = document.createElement('script');
    script.src = file;
    script.type = 'text/javascript';
    script.defer = true;

    document.getElementsByTagName('head').item(0).appendChild(script);

}


function LTrim(value) {
    var re = /\s*((\S+\s*)*)/;
    return value.replace(re, "$1");
}

function RTrim(value) {
    var re = /((\s*\S+)*)\s*/;
    return value.replace(re, "$1");
}

function trim(value) {
    return LTrim(RTrim(value));
}

function Validate_CheckForBlank(ControlClientID) {////debugger
    var txtcontrol = document.getElementById(ControlClientID);
    if (trim(txtcontrol.value) == '')
        return false;

    return true;
}

function Validate_CheckForSpecialCharacters(ControlClientID) {

    var txtcontrol = document.getElementById(ControlClientID);
    var iChars = "!@#$%^&*()+=-[]\\\';,./{}|\":<>?";

    for (var i = 0; i < trim(txtcontrol.value).length; i++) {
        if (iChars.indexOf(trim(txtcontrol.value).charAt(i)) != -1) {
            return false;
        }
    }
    return true;
}

/*Email Validation Code*/

function validateEmail(Control, returnmessage) {

    var emailStr = Control.value;
    var reg1 = /(@.*@)|(\.\.)|(@\.)|(\.@)|(^\.)/; // not valid
    var reg2 = /^.+\@(\[?)[a-zA-Z0-9\-\.]+\.([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/; // valid
    if (!reg1.test(emailStr) && reg2.test(emailStr)) {
        return true;
    } else {
        alert(returnmessage + ' is not a valid email address.');
        Control.focus();
        return false;
    }
}



//-------------------------------------------------------------------
// isNull(value)
//      Returns true if value is null
//-------------------------------------------------------------------
function isNull(val) { return (val == null); }

//-------------------------------------------------------------------
// isBlank(value)
//   Returns true if value only contains spaces
//-------------------------------------------------------------------
function isBlank(Control, returnmessage) {
    val = Control.value;
    if (val == null) {
        alert(returnmessage + ' ' + 'cannot be left blank');
        Control.focus();
        return true;
    }
    for (var i = 0; i < val.length; i++) {
        if ((val.charAt(i) != ' ') && (val.charAt(i) != "\t") && (val.charAt(i) != "\n") && (val.charAt(i) != "\r")) {

            return false;
        }
    }
    Control.focus();
    alert(returnmessage + ' ' + 'cannot be left blank');
    return true;
}
//isblank with different message
function isBlank1(Control, returnmessage) {
    val = Control.value;
    if (val == null) {
        alert('Please enter either' + ' ' + returnmessage);
        Control.focus();
        return true;
    }
    for (var i = 0; i < val.length; i++) {
        if ((val.charAt(i) != ' ') && (val.charAt(i) != "\t") && (val.charAt(i) != "\n") && (val.charAt(i) != "\r")) {

            return false;
        }
    }
    Control.focus();
    alert('Please enter either' + ' ' + returnmessage);
    return true;
}

//function iswatermarkapplied(Control, watermarktext, returnmessage)
//{
//	return true;
//}

//-------------------------------------------------------------------
// isInteger(value)
//   Returns true if value contains all digits
//-------------------------------------------------------------------
function isInteger(Control, returnmessage) {
    val = Control.value;
    if (isBlank(Control, returnmessage)) {

        Control.focus();
        return false;
    }
    for (var i = 0; i < val.length; i++) {
        if (!isDigit(val.charAt(i))) {
            alert(returnmessage + " cannot be left blank and have some numeric value.");
            Control.focus();
            return false;
        }
    }
    return true;
}

//-------------------------------------------------------------------
// isNumeric(value)
//   Returns true if value contains a positive float value
//-------------------------------------------------------------------
function isNumeric(Control, returnmessage) {
    val = Control.value;
    if ((parseFloat(val, 10) == (val * 1)) == false) {
        alert(returnmessage + " cannot be left blank and have some numeric value.");
        Control.focus();
        return false;
    }
    return true
}
function isNumericbutblank(Control, returnmessage) {
    val = Control.value;
    if ((parseFloat(val, 10) == (val * 1)) == false) {
        alert(returnmessage + " should have some numeric value.");
        Control.focus();
        return false;
    }
    return true
}

//-------------------------------------------------------------------
// isNumeric And Not required(value)
//   Returns true if value contains a positive numeric value
//-------------------------------------------------------------------
function isNumericOnly(Control, returnmessage) {

    val = Control.value;

    if (val == '') {
        return true;
    }
    else if ((parseFloat(val, 10) == (val * 1)) == false) {
        alert(returnmessage + " must have some numeric value.");
        Control.focus();
        return false;
    }
    else {
    }
    return true
}

//-------------------------------------------------------------------
// checkLength(value,limit)
//      Returns true if value is greater then givin limit
//-------------------------------------------------------------------
function checkLength(Control, limit, returnmessage) {
    val = Control.value;
    if (val.length > limit) {
        alert(returnmessage + " should be less than " + limit);
        Control.focus();
        return false;
    }
}

//-------------------------------------------------------------------
// checkDropDown(control,returnmessage)
//      Returns true if selectedindex>0;
// It is assumed that item at 0th index is like 'Select value'
//-------------------------------------------------------------------
function checkDropDown(Control, returnmessage) {
    val = Control.selectedIndex;

    if (val < 1) {
        alert("Please select " + returnmessage);
        Control.focus();
        return false;
    }
    return true;
}

function validateSSN(Control, returnmessage) {
    val = Control.value;
    var matchArr = val.match(/^(\d{3})-?\d{2}-?\d{4}$/);
    var numDashes = val.split('-').length - 1;
    if (matchArr == null || numDashes == 1) {
        alert('Invalid SSN. Must be 9 digits or in the form NNN-NN-NNNN.');
        Control.focus();
        return false;
    }
    else if (parseInt(matchArr[1], 10) == 0) {
        alert("Invalid SSN: SSN's can't start with 000.");
        Control.focus();
        return false;
    }
    else { return true; }
}

function isDigit(num) {
    if (num.length > 1) { return false; }
    var string = "1234567890";
    if (string.indexOf(num) != -1) { return true; }
    return false;
}

function checkMaximum(Control, maximumvalue, returnmessage) {
    val = Control.value;
    if (parseInt(val) > parseInt(maximumvalue)) {
        alert('Maximum allowed value for ' + returnmessage + ' is ' + maximumvalue);
        Control.focus();
        return false;
    }
}

//-------------------------------------------------------------------
// CompareTime(timefrom hour, timefrom min, timeto hour, timeto min)
//      Returns true if time to > timefrom
//-------------------------------------------------------------------
function CompareTime(hh1, mm1, hh2, mm2, fromampm, toampm, msg) {
    //debugger
    hh1v = hh1.value;
    mm1v = mm1.value;
    hh2v = hh2.value;
    mm2v = mm2.value;

    if (fromampm.value == "PM" && parseInt(hh1v) < 12)
        hh1v = Number(hh1v) + 12;

    if (toampm.value == "PM" && parseInt(hh2v) < 12)
        hh2v = Number(hh2v) + 12;

    timefrom = Number(hh1v * 60 * 60 + mm1v * 60);

    //if(hh2v > 12) hh2v = parseInt(hh2v - 2); //24 hr time

    timeto = Number(hh2v * 60 * 60 + mm2v * 60);

    var difference = timeto - timefrom;

    if (difference > 43200) // 10 hours
    {
        alert(msg + " duration should not exceed 12 hrs, please schedule accordingly");
        return false;
    }
    else if (difference < 3600 && difference > 0) // half an hour
    {
        alert(msg + " duration should not be less than 1 hr, Please schedule accordingly");
        return false;
    }
    else if (difference <= 0) {
        alert("Invalid time period selection");
        return false;
    }
    else
        return true;
}

//-------------------------------------------------------------------
// CompareTime(timefrom hour, timefrom min, timeto hour, timeto min)
//      Returns true if time to > timefrom
//-------------------------------------------------------------------
function CompareTimeWithValues(hh1, mm1, hh2, mm2, fromampm, toampm, msg) {
    //debugger
    hh1v = hh1;
    mm1v = mm1;
    hh2v = hh2;
    mm2v = mm2;

    if (fromampm == "PM" && parseInt(hh1v) < 12)
        hh1v = Number(hh1v) + 12;

    if (toampm == "PM" && parseInt(hh2v) < 12)
        hh2v = Number(hh2v) + 12;

    timefrom = Number(hh1v * 60 * 60 + mm1v * 60);

    //if(hh2v > 12) hh2v = parseInt(hh2v - 2); //24 hr time

    timeto = Number(hh2v * 60 * 60 + mm2v * 60);

    var difference = timeto - timefrom;

    if (difference > 43200) // 10 hours
    {
        alert(msg + " duration should not exceed 12 hrs, please schedule accordingly");
        return false;
    }
    else if (difference < 3600 && difference > 0) // half an hour
    {
        alert(msg + " duration should not be less than 1 hr, Please schedule accordingly");
        return false;
    }
    else if (difference <= 0) {
        alert("Invalid time period selection");
        return false;
    }
    else
        return true;
}

//-------------------------------------------------------------------
// Compare given date with current date and alert accordingly
//      Returns false if current date >= given date
//-------------------------------------------------------------------
function CompareDateWithCurrentDate(dateToCompare, msg) {
    var today = new Date();
    var defyear = today.getYear();
    var y = defyear % 100;
    y += (y < 38) ? 2000 : 1900;

    var currentDate = new Date(y, today.getMonth(), today.getDate());

    var dateCompare = new Date(dateToCompare.value.split('/')[2], dateToCompare.value.split('/')[0] - 1, dateToCompare.value.split('/')[1]);

    if (currentDate.getTime() >= dateCompare.getTime()) {
        alert(msg);
        return false;
    }
    else
        return true;
}

//-------------------------------------------------------------------
// Compare given date with current date and alert accordingly
//      Returns false if current date > given date
//-------------------------------------------------------------------
function CompareDateWithCurrentDate2(dateToCompare, msg) {
    var today = new Date();
    var defyear = today.getYear();
    var y = defyear % 100;
    y += (y < 38) ? 2000 : 1900;

    var currentDate = new Date(y, today.getMonth(), today.getDate());

    var dateCompare = new Date(dateToCompare.value.split('/')[2], dateToCompare.value.split('/')[0] - 1, dateToCompare.value.split('/')[1]);

    if (currentDate.getTime() > dateCompare.getTime()) {
        alert(msg);
        return false;
    }
    else
        return true;
}

//-------------------------------------------------------------------
// Compare given date with current date and alert accordingly
//      Returns true if current date > given date
//-------------------------------------------------------------------
function CheckValidDOB(dateToCompare, msg) {
    var today = new Date();
    var defyear = today.getYear();
    var y = defyear % 100;
    y += (y < 38) ? 2000 : 1900;

    var currentDate = new Date(y, today.getMonth(), today.getDate());

    var dateCompare = new Date(dateToCompare.value.split('/')[2], dateToCompare.value.split('/')[0] - 1, dateToCompare.value.split('/')[1]);

    if (currentDate.getTime() <= dateCompare.getTime()) {
        alert(msg);
        return false;
    }
    else
        return true;
}

//-------------------------------------------------------------------
// Return true if date2 >= date1
//-------------------------------------------------------------------
function CompareTwoDates(date1, date2) {
    var today = new Date();
    var defyear = today.getYear();
    var y = defyear % 100;
    y += (y < 38) ? 2000 : 1900;

    var currentDate = new Date(y, today.getMonth(), today.getDate() + 1);

    var dateCompare1 = new Date(date1.split('/')[2], date1.split('/')[0] - 1, date1.split('/')[1]);
    var dateCompare2 = new Date(date2.split('/')[2], date2.split('/')[0] - 1, date2.split('/')[1]);

    if (dateCompare2.getTime() >= dateCompare1.getTime())
        return true;
    else if (dateCompare2.getTime() < currentDate.getTime())
        return true;
    else
        return false;
}

//-------------------------------------------------------------------
// Return true if date2 >= date1
//-------------------------------------------------------------------
function CompareTwoDates1(date1, date2) {

    var dateCompare1 = new Date(date1.split('/')[2], date1.split('/')[0] - 1, date1.split('/')[1]);
    var dateCompare2 = new Date(date2.split('/')[2], date2.split('/')[0] - 1, date2.split('/')[1]);

    if (dateCompare2.getTime() >= dateCompare1.getTime())
        return true;
    else
        return false;
}
//-------------------------------------------------------------------
// Return true if date2 >= date1 and less than currentDate and Yesterday
//-------------------------------------------------------------------
function CompareTwoDatesWithYesterDay(date1, date2) {

    var today = new Date();
    var defyear = today.getYear();
    var y = defyear % 100;
    y += (y < 38) ? 2000 : 1900;

    var currentDate = new Date(y, today.getMonth(), today.getDate() - 1);

    var dateCompare1 = new Date(date1.split('/')[2], date1.split('/')[0] - 1, date1.split('/')[1]);
    var dateCompare2 = new Date(date2.split('/')[2], date2.split('/')[0] - 1, date2.split('/')[1]);


    if (dateCompare2.getTime() > dateCompare1.getTime())
        return true;
    else if (dateCompare2.getTime() < currentDate.getTime())
        return true;
    else
        return false;
}
function ValidateDate(dateStr, returnmessage) {
    // var RegExPattern = /^((((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00)))|(((0[1-9]|[12]\d|3[01])(0[13578]|1[02])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|[12]\d|30)(0[13456789]|1[012])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|1\d|2[0-8])02((1[6-9]|[2-9]\d)?\d{2}))|(2902((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00))))$/;
    var RegExPattern = /^(?=\d)(?:(?:(?:(?:(?:0?[13578]|1[02])(\/|-|\.)31)\1|(?:(?:0?[1,3-9]|1[0-2])(\/|-|\.)(?:29|30)\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})|(?:0?2(\/|-|\.)29\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))|(?:(?:0?[1-9])|(?:1[0-2]))(\/|-|\.)(?:0?[1-9]|1\d|2[0-8])\4(?:(?:1[6-9]|[2-9]\d)?\d{2}))($|\ (?=\d)))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\ [AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$/;
    if (dateStr.match(RegExPattern))
        return true;
    else {
        alert('Please provide a valid ' + returnmessage);
        return false;
    }
}

///* from public */

//function validateDate(dateStr,returnmessage)
//{
//   
//   // var RegExPattern = /^((((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00)))|(((0[1-9]|[12]\d|3[01])(0[13578]|1[02])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|[12]\d|30)(0[13456789]|1[012])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|1\d|2[0-8])02((1[6-9]|[2-9]\d)?\d{2}))|(2902((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00))))$/;
//   var RegExPattern = /^(?=\d)(?:(?:(?:(?:(?:0?[13578]|1[02])(\/|-|\.)31)\1|(?:(?:0?[1,3-9]|1[0-2])(\/|-|\.)(?:29|30)\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})|(?:0?2(\/|-|\.)29\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))|(?:(?:0?[1-9])|(?:1[0-2]))(\/|-|\.)(?:0?[1-9]|1\d|2[0-8])\4(?:(?:1[6-9]|[2-9]\d)?\d{2}))($|\ (?=\d)))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\ [AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$/;
//    if (dateStr.match(RegExPattern)) 
//        return true;
//    else
//    {
//        alert('Please provide a valid '+ returnmessage);
//        return false;
//    }
//}

function KeyPress_NumericAllowedOnly(evt) {

    var key = (evt.which ? evt.which : ((evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : 0)));
    if (((key >= 48 && key <= 57) || key == 9 || key == 13 || key == 8 || (key >= 37 && key <= 40) || (key >= 96 && key <= 105)) && (evt.shiftKey == false)) {
        return true;
    }

    return false;
}

function KeyPress_DecimalAllowedOnly(evt) {

    var key = (evt.which ? evt.which : ((evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : 0)));
    var InpObject = evt.currentTarget ? evt.currentTarget : evt.srcElement;

    if (((key >= 48 && key <= 57) || key == 9 || key == 8 || (key >= 37 && key <= 40) || key == 46 || key == 190 || key == 110 || (key >= 96 && key <= 105)) && (evt.shiftKey == false)) {
        if (key == 46 || key == 190 || key == 110) {
            if (InpObject.value.indexOf(".") >= 0) return false;
        }
        return true;
    }
    return false;
}

function KeyPress_DecimalAllowedOnly_withsigns(evt) {

    var key = (evt.which ? evt.which : ((evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : 0)));
    var InpObject = evt.currentTarget ? evt.currentTarget : evt.srcElement;

    var selIndex = getSelectionStart(InpObject);

    if (((key >= 48 && key <= 57) || key == 9 || key == 8 || (key >= 37 && key <= 40) || key == 46 || ((key == 109 || key == 189) && selIndex == 0) || key == 190 || key == 110 || (key >= 96 && key <= 105)) && (evt.shiftKey == false)) {
        if (key == 46 || key == 190) {
            if (InpObject.value.indexOf(".") >= 0) return false;
        }
        return true;
    }
    return false;
}

// -----------------------------
function getSelectionStart(o) {
    //debugger
    if (o.createTextRange) {
        var r = document.selection.createRange().duplicate()
        r.moveEnd('character', o.value.length)
        if (r.text == '') return o.value.length
        return o.value.lastIndexOf(r.text)
    } else return o.selectionStart
}
//-----------------------------------

function checkMinimumLength(Control, limit, returnmessage) {
    val = Control.value;
    if (val.length < limit) {
        alert(returnmessage + " cannot be less than " + limit);
        Control.focus();
        return true;
    }
}

function moneyFormat(Control, returnmessage) {

    var newValue = Control.value;
    // ignore all but digits and decimal points.
    var bolDecimal = true;
    for (i = 0; i < newValue.length; i++) {
        aChar = newValue.substring(i, i + 1);
        if (aChar < "0" || aChar > "9") {
            if ((aChar != ".") || (bolDecimal != true)) {
                alert(returnmessage + " is not valid value");
                Control.focus();
                return false;
            }
                //           else if (bolDecimal!=true)
                //           {alert(returnmessage + " is not valid value");
                //                Control.focus();
                //                  return false;}
            else { bolDecimal = false; }
        }

    }
    return true;
}
function validateExpiryDate(Control, returnmessage) {

    //var RegExPattern = /^((((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00)))|(((0[1-9]|[12]\d|3[01])(0[13578]|1[02])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|[12]\d|30)(0[13456789]|1[012])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|1\d|2[0-8])02((1[6-9]|[2-9]\d)?\d{2}))|(2902((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00))))$/;
    var dateStr = Control.value;
    var RegExPattern = /^((0[1-9])|(1[0-2]))\/(\d{4})$/;
    if (Control.value == '00/0000') {
        alert('Please provide valid ' + returnmessage);
        return false;
    }
    else if (Control.value.indexOf('/0000') >= 0) {
        alert('Please provide valid ' + returnmessage);
        return false;
    }
    else if (dateStr.match(RegExPattern)) {
        return true;
    }
    else {
        alert('Please provide ' + returnmessage + " in format MM/YYYY");
        return false;
    }


}
//------------------------------------------------------------
//To Check expiry date of Credit Card
//------------------------------------------------------------
function CheckCCExpiryDate(Control, returnmessage) {
    var today = new Date();
    var dateStr = Control.value;
    var ccYear = dateStr.split('/')[1];
    var ccMonth = dateStr.split('/')[0];

    if (ccYear > today.getYear())
        return true;
    else if (ccYear == today.getYear() && ccMonth >= today.getMonth())
        return true;
    else {
        alert('You have entered expired ' + returnmessage + ' date');
        return false;
    }
}
//------------------------------------------------------------
//To Check Date not less than 1/1/1900
//------------------------------------------------------------
function checkDate(date, msg) {
    var year;
    year = date.split('/')[2];
    if (year < 1900) {
        alert(msg + " cannot be less than 1/1/1900");
        return false;
    }
    else {
        return true;
    }
}

//------------------------------------------------------------
//To Check Valid time strings
//------------------------------------------------------------
function IsTime(strTime) {
    var strTestTime = new String(strTime);
    strTestTime.toUpperCase();

    var bolTime = false;

    if (strTestTime.indexOf("PM", 1) != -1 || strTestTime.indexOf("AM", 1))
        bolTime = true;

    if (bolTime && strTestTime.indexOf(":", 0) == 0)
        bolTime = false;

    var nColonPlace = strTestTime.indexOf(":", 1);
    if (bolTime && ((parseInt(nColonPlace) + 5) < (strTestTime.length - 1) || (parseInt(nColonPlace) + 4) > (strTestTime.length - 1)))
        bolTime = false;


    return bolTime;
}

// Checks if time is in HH:MM:SS AM/PM format.
// The seconds and AM/PM are optional.
function IsValidTime(timeStr) {
    var timePat = /^(\d{1,2}):(\d{2})(:(\d{2}))?(\s?(AM|am|PM|pm))?$/;

    var matchArray = timeStr.match(timePat);
    if (matchArray == null) {
        alert("Time is not in a valid format.");
        return false;
    }
    hour = matchArray[1];
    minute = matchArray[2];
    second = matchArray[4];
    ampm = matchArray[6];

    if (second == "") { second = null; }
    if (ampm == "") { ampm = null; }

    if (hour < 0 || hour > 23) {
        alert("Hour must be between 1 and 12. (or 0 and 23 for military time)");
        return false;
    }

    if (hour <= 12 && ampm == null) {
        if (confirm("Please indicate which time format you are using.  OK = Standard Time, CANCEL = Military Time")) {
            alert("You must specify AM or PM.");
            return false;
        }
    }

    if (hour > 12 && ampm != null) {
        alert("Hour factor should be less than equal to 12.");
        return false;
    }

    if (minute < 0 || minute > 59) {
        alert("Minute must be between 0 and 59.");
        return false;
    }

    if (second != null && (second < 0 || second > 59)) {
        alert("Second must be between 0 and 59.");
        return false;
    }
    return true;
}




//------------------------------------------------------------
//Calculate the age from given date of birth
//------------------------------------------------------------

function Age(DateofBirth) {//debugger
    var DOB = DateofBirth;
    var Byear;
    Byear = DOB.split('/')[2];
    var Bmonth;
    Bmonth = DOB.split('/')[0];
    var Bday;
    Bday = DOB.split('/')[1];
    var age;
    var now = new Date();
    Tday = now.getDate();
    Tmo = (now.getMonth());
    Tmo = Tmo + 1; //now.getMonth() gives value from 0 to 11(0 for January)
    Tyr = (now.getFullYear());

    {
        if ((Tmo > Bmonth) || (Tmo == Bmonth & Tday >= Bday))
        { age = Byear }

        else
        { age = parseInt(Byear) + 1 }
        return (parseInt(Tyr) - parseInt(age));
    }
}



// 
//
//

function validatetime(strval) {
    //var strval = document.Form1.TextBox1.value;
    var strval1;

    //minimum lenght is 6. example 1:2 AM
    if (strval.length < 6) {
        alert("Invalid time slots. Time format should be HH:MM AM/PM.");
        return false;
    }

    //Maximum length is 8. example 10:45 AM
    if (strval.length > 8) {
        alert("invalid time slots. Time format should be HH:MM AM/PM.");
        return false;
    }

    //Removing all space
    strval = trimAllSpace(strval);

    //Checking AM/PM
    if (strval.charAt(strval.length - 1) != "M" && strval.charAt(strval.length - 1) != "m") {
        alert("Invalid time slots. Time should be end with AM or PM.");
        return false;

    }
    else if (strval.charAt(strval.length - 2) != 'A' && strval.charAt(strval.length - 2) != 'a' && strval.charAt(strval.length - 2) != 'p' && strval.charAt(strval.length - 2) != 'P') {
        alert("Invalid time slots. Time should be end with AM or PM.");
        return false;

    }

    //Give one space before AM/PM

    strval1 = strval.substring(0, strval.length - 2);
    strval1 = strval1 + ' ' + strval.substring(strval.length - 2, strval.length)

    strval = strval1;

    var pos1 = strval.indexOf(':');
    //document.Form1.TextBox1.value = strval;

    if (pos1 < 0) {
        alert("Invalid time slots. A color(:) is missing between hour and minute.");
        return false;
    }
    else if (pos1 > 2 || pos1 < 1) {
        alert("Invalid time slots. Time format should be HH:MM AM/PM.");
        return false;
    }

    //Checking hours
    var horval = trimString(strval.substring(0, pos1));

    if (horval == -100) {
        alert("Invalid time slots. Hour should contain only integer value (0-11).");
        return false;
    }

    if (horval > 12) {
        alert("Invalid time slots. Hour can not be greater that 12.");
        return false;
    }
    else if (horval < 0) {
        alert("Invalid time slots. Hour can not be hours less than 0.");
        return false;
    }
    //Completes checking hours.

    //Checking minutes.
    var minval = trimString(strval.substring(pos1 + 1, pos1 + 3));

    if (minval == -100) {
        alert("Invalid time slots. Minute should have only integer value (0-59).");
        return false;
    }

    if (minval > 59) {
        alert("Invalid time slots. Minute can not be more than 59.");
        return false;
    }
    else if (minval < 0) {
        alert("Invalid time slots. Minute can not be less than 0.");
        return false;
    }

    //Checking minutes completed.  

    //Checking one space after the mintues 
    minpos = pos1 + minval.length + 1;
    if (strval.charAt(minpos) != ' ') {
        alert("Invalid time slots. Space missing after minute. Time should have HH:MM AM/PM format.");
        return false;
    }


    return true;


}


function trimAllSpace(str) {
    var str1 = '';
    var i = 0;
    while (i != str.length) {
        if (str.charAt(i) != ' ')
            str1 = str1 + str.charAt(i); i++;
    }
    return str1;
}


function trimString(str) {
    var str1 = '';
    var i = 0;
    while (i != str.length) {
        if (str.charAt(i) != ' ') str1 = str1 + str.charAt(i); i++;
    }
    var retval = StringIsNumeric(str1);
    if (retval == false)
        return -100;
    else
        return str1;
}


function StringIsNumeric(strString) {
    var strValidChars = "0123456789";
    var strChar;
    var blnResult = true;
    //var strSequence = document.frmQuestionDetail.txtSequence.value; 
    //test strString consists of valid characters listed above 
    if (strString.length == 0)
        return false;
    for (i = 0; i < strString.length && blnResult == true; i++) {
        strChar = strString.charAt(i);
        if (strValidChars.indexOf(strChar) == -1) {
            blnResult = false;
        }
    }
    return blnResult;
}

var present;
function StartTimer(hfCallStartTime, CallStarted) {//debugger;
    if (hfCallStartTime == undefined || hfCallStartTime == null)
        return;
    var presenttime, elapsed, melapsed, selapsed, timerID;
    var startTime1 = new Date(hfCallStartTime.value);

    var currentTime = $('.currentTime').html();
    if (present == null)
        present = new Date(currentTime);

    present.setSeconds(present.getSeconds() + 1);


    presenttime = present.getTime();
    elapsed = (presenttime - startTime1) / 1000;
    helapsed = Math.floor(elapsed / 3600);
    melapsed = Math.floor(elapsed / 60 - (helapsed * 60));
    // selapsed  = Math.floor(elapsed -(melapsed * 60));
    selapsed = Math.floor(elapsed - ((Math.floor(elapsed / 60)) * 60));

    var HH = document.getElementById("HH");
    var MM = document.getElementById("MM");
    var SS = document.getElementById("SS");

    if (helapsed < 10)
    { helapsed = '0' + helapsed; }
    if (melapsed < 10)
    { melapsed = '0' + melapsed; }
    if (selapsed < 10)
    { selapsed = '0' + selapsed; }

    HH.innerHTML = helapsed;
    MM.innerHTML = melapsed;
    SS.innerHTML = selapsed;

    if ((CallStarted == null) || (CallStarted == true)) {
        timerID = setTimeout("StartTimer(hfCallStartTime)", 1000);
    }
}


function getParameterByName(name) {
    var results = RegExp('[?&]' + name + '=([^&]*)').exec(window.location.search);

    if (results == null)
        return "";
    else
        return decodeURIComponent(results[1].replace(/\+/g, " "));
}

//function getParameterByName(name) {
//    name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
//    var regexS = "[\\?&]" + name + "=([^&#]*)";
//    var regex = new RegExp(regexS);
//    var results = regex.exec(window.location.search);
//    if (results == null)
//        return "";
//    else
//        return decodeURIComponent(results[1].replace(/\+/g, " "));
//}


function CallNotes() {
    //debugger;
    var RedirectPath = "/App/CallCenter/CallCenterRep/AddNotes.aspx?guid=" + getParameterByName("guid");
    var RootPath = window.location.protocol + "//" + window.location.host + "/App/";
    window.location = RedirectPath;
    return false;

}

function CallNotes1() {//debugger;
    window.location = "/App/CallCenter/CallCenterRep/AddNotes.aspx?guid=" + getParameterByName("guid");
    return false;

}

function CallExistingPCP() {
    window.location = window.location.protocol + "//" + window.location.host + "App/CallCenter/CallCenterRep/ExistingCustomer/PrimaryCarePhysician.aspx";
    return false;

}

function TechnicianRegisterPCP() {
    window.location = window.location.protocol + "//" + window.location.host + "App/Common/RegisterCustomer/PrimaryCarePhysician.aspx";
    return false;

}

function TechnicianExistingPCP() {
    window.location = window.location.protocol + "//" + window.location.host + "App/Common/RegisterCustomer/PrimaryCarePhysician.aspx?Customer=Existing";
    return false;

}

function isValidCreditCard(type, ccnum) {

    if (type == "Visa") {

        // Visa: length 16, prefix 4, dashes optional.

        var re = /^4[0-9]{12}(?:[0-9]{3})?$/;

    } else if (type == "Master Card" || type == "MasterCard") {

        // Mastercard: length 16, prefix 51-55, dashes optional.

        var re = /^5[1-5][0-9]{14}$/;

    } else if (type == "Discover") {

        // Discover: length 16, prefix 6011, dashes optional.

        var re = /^6(?:011|5[0-9]{2})[0-9]{12}$/;

    } else if (type == "American Express" || type == "AmericanExpress") {

        // American Express: length 15, prefix 34 or 37.

        var re = /^3[47][0-9]{13}$/;

    } else if (type == "Diners Club" || type == "DinersClub") {

        // Diners: length 14, prefix 30, 36, or 38.

        var re = /^3(?:0[0-5]|[68][0-9])[0-9]{11}$/;

    }

    if (!re.test(ccnum)) return false;

    // Remove all dashes for the checksum checks to eliminate negative numbers

    ccnum = ccnum.split("-").join("");

    // Checksum ("Mod 10")

    // Add even digits in even length strings or odd digits in odd length strings.

    var checksum = 0;

    for (var i = (2 - (ccnum.length % 2)) ; i <= ccnum.length; i += 2) {

        checksum += parseInt(ccnum.charAt(i - 1));

    }

    // Analyze odd digits in even length strings or even digits in odd length strings.

    for (var i = (ccnum.length % 2) + 1; i < ccnum.length; i += 2) {

        var digit = parseInt(ccnum.charAt(i - 1)) * 2;

        if (digit < 10) { checksum += digit; } else { checksum += (digit - 9); }

    }

    if ((checksum % 10) == 0) return true; else return false;

}


function StringToXML(strRequest) {
    try //Internet Explorer
    {
        xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
        xmlDoc.async = "false";
        xmlDoc.loadXML(strRequest);
        return xmlDoc;
    }
    catch (e) {
        try //Firefox, Mozilla, Opera, etc.
        {
            parser = new DOMParser();
            xmlDoc = parser.parseFromString(strRequest, "text/xml");
            return xmlDoc;
        }
        catch (e) { alert(e.message) }
    }


}

//-------------------------------------------------------------------
// Compare given date with current date and alert accordingly
//      Returns false if given date > current date 
//-------------------------------------------------------------------
function CompareDateWithCurrentDate1(dateToCompare) {
    var today = new Date();
    var defyear = today.getYear();
    var y = defyear % 100;
    y += (y < 38) ? 2000 : 1900;

    var currentDate = new Date(y, today.getMonth(), today.getDate());

    var dateCompare = new Date(dateToCompare.split('/')[2], dateToCompare.split('/')[0] - 1, dateToCompare.split('/')[1]);

    if (dateCompare.getTime() > currentDate.getTime()) {

        return false;
    }
    else
        return true;
}

//-------------------------------------------------------------------
// Compare given date with current date and alert accordingly
//      Returns false if current date > given date
//-------------------------------------------------------------------
function CompareDateWithCurrentDate2(dateToCompare, msg) {
    var today = new Date();
    var defyear = today.getYear();
    var y = defyear % 100;
    y += (y < 38) ? 2000 : 1900;

    var currentDate = new Date(y, today.getMonth(), today.getDate());

    var dateCompare = new Date(dateToCompare.value.split('/')[2], dateToCompare.value.split('/')[0] - 1, dateToCompare.value.split('/')[1]);

    if (currentDate.getTime() > dateCompare.getTime()) {
        alert(msg);
        return false;
    }
    else
        return true;
}


function minimum_fourcharacters(Control, returnMsg) {
    var textLength = (Control.value).length;
    if (textLength >= 4)
        return true;
    else {
        alert(returnMsg + " should contain minium 4 characters.");
        return false;
    }
}

function minimum_threecharacters(Control, returnMsg) {
    var textLength = (Control.value).length;
    if (textLength >= 3)
        return true;
    else {
        alert(returnMsg + " should contain minium 4 characters.");
        return false;
    }
}

// to check same characters like "aaaa"
function three_samecharacters(Control, returnMsg) {//debugger
    var txtStr = Control.value;
    var IsSameCharacters = false;
    for (count = 0; count < txtStr.length; count++) {
        var singleChar = txtStr.charAt(count);
        for (i = 1; i < 3; i++) {
            if (singleChar != txtStr.charAt(count + i))
                break;
            if (i == 2)
                IsSameCharacters = true;
        }
        if (IsSameCharacters == true) {
            alert(returnMsg + " can not have same characters like \"aaaa\".");
            return false;
        }
    }
    return true;
}

// to check sequential series like "12345"
function check_sequential(Control, returnMsg) {//debugger
    var i = 0;
    var txtStr = Control.value;
    var IsSequential = false;
    for (count = 0; count < txtStr.length; count++) {
        var singleChar = txtStr.charAt(count);
        if (parseInt(singleChar) + 1 == parseInt(txtStr.charAt(count + 1)))
            i = i + 1;
        else
            i = 0;
        if (i == 3)
            IsSequential = true;

        if (IsSequential == true) {
            alert(returnMsg + " can not have sequential series like \"12345\".");
            return false;
        }
    }
    return true;
}

//script for hand icon change in baloons tooltip 
function changetodefault(spanId) {
    document.getElementById(spanId).style.cursor = "default";
}
function changetopointer(spanId) {
    document.getElementById(spanId).style.cursor = "pointer";
}

function getFutureDate(days) {
    var result = new Date();
    result.setDate(result.getDate() + days);
    var newDate = (result.getMonth() + 1) + "/" + result.getDate() + "/" + result.getFullYear();

    return newDate;
}


var scriptPopup = null;

function openScriptWindow() {
    if (window.localStorage.scriptUrl != null && window.localStorage.scriptUrl != "null") {
        var properties = "width=" + Number($(window).width() / 2) + ", height=" + Number($(window).height()) + ", resizable=1, scrollbars=1";

        scriptPopup = window.open(window.localStorage.scriptUrl, "Call Center Script", properties);
        //window.localStorage.setItem("isScriptOpen", true);
        checkScriptPopupOpen();
    }
}

function checkScriptPopupOpen() {
    if (scriptPopup && scriptPopup.closed) {
        scriptPopup = null;
        window.localStorage.removeItem("isScriptOpen");
        window.localStorage.removeItem("scriptUrl");
    } else {
        window.setTimeout(checkScriptPopupOpen, 500);
    }
}

function closeScriptPopup() {
  
    if (scriptPopup && !scriptPopup.closed) {
        scriptPopup.close();
        scriptPopup = null;
        window.localStorage.removeItem("isScriptOpen");
        window.localStorage.removeItem("scriptUrl");
    }
}

function checkAndOpenScriptPopup() {
    if (window.localStorage.isScriptOpen === "true") {
        openScriptWindow();
    }
}