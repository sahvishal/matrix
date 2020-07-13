// JScript File
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

function Validate_CheckForBlank(ControlClientID) {//debugger
    var txtcontrol = document.getElementById(ControlClientID);
    if (trim(txtcontrol.value) == '')
        return false;

    return true;
}

function Validate_CheckForSpecialCharacters(ControlClientID) {
    var txtcontrol = document.getElementById(ControlClientID);
    var iChars = "!@#$%^&*()+=-[]\\\';,./{}|\":<>?";

    for (var i = 0; i < trim(txtName.value).length; i++) {
        if (iChars.indexOf(trim(txtName.value).charAt(i)) != -1) {
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
    }
    else {
        alert('Please provide a valid ' + returnmessage + ' address');
        Control.focus();
        return false;
    }
}

/* Date Validation Code */

function validateDate(dateStr, returnmessage) {

    // var RegExPattern = /^((((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00)))|(((0[1-9]|[12]\d|3[01])(0[13578]|1[02])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|[12]\d|30)(0[13456789]|1[012])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|1\d|2[0-8])02((1[6-9]|[2-9]\d)?\d{2}))|(2902((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00))))$/;
    var RegExPattern = /^(?=\d)(?:(?:(?:(?:(?:0?[13578]|1[02])(\/|-|\.)31)\1|(?:(?:0?[1,3-9]|1[0-2])(\/|-|\.)(?:29|30)\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})|(?:0?2(\/|-|\.)29\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))|(?:(?:0?[1-9])|(?:1[0-2]))(\/|-|\.)(?:0?[1-9]|1\d|2[0-8])\4(?:(?:1[6-9]|[2-9]\d)?\d{2}))($|\ (?=\d)))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\ [AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$/;
    if (dateStr.match(RegExPattern))
        return true;
    else {
        alert('Please provide a valid ' + returnmessage);
        return false;
    }
}

function validateExpiryDate(Control, returnmessage) {

    // var RegExPattern = /^((((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00)))|(((0[1-9]|[12]\d|3[01])(0[13578]|1[02])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|[12]\d|30)(0[13456789]|1[012])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|1\d|2[0-8])02((1[6-9]|[2-9]\d)?\d{2}))|(2902((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00))))$/;
    var dateStr = Control.value;
    var RegExPattern = /^((0[1-9])|(1[0-2]))\/(\d{4})$/;
    if (dateStr.match(RegExPattern))
        return true;
    else {
        alert('Please provide ' + returnmessage + " in MM/YYYY format");
        return false;
    }


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

function validateDateControl(Control, returnmessage) {

    var dateStr = Control.value;

    var RegExPattern = /^(?=\d)(?:(?:(?:(?:(?:0?[13578]|1[02])(\/|-|\.)31)\1|(?:(?:0?[1,3-9]|1[0-2])(\/|-|\.)(?:29|30)\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})|(?:0?2(\/|-|\.)29\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))|(?:(?:0?[1-9])|(?:1[0-2]))(\/|-|\.)(?:0?[1-9]|1\d|2[0-8])\4(?:(?:1[6-9]|[2-9]\d)?\d{2}))($|\ (?=\d)))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\ [AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$/;
    if (dateStr.match(RegExPattern))
        return true;
    else {
        alert('Please provide a valid ' + returnmessage);
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
function isBlank(Control, returnmessage) {//debugger
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
            alert(returnmessage + " is not numeric");
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
        alert(returnmessage + " is not numeric");
        Control.focus();
        return false;
    }
    return true
}

//-------------------------------------------------------------------
// checkLength(value,limit)
//      Returns true if value is greater then givin limit
//-------------------------------------------------------------------
function checkLength(Control, limit, returnmessage) {
    val = Control.value;
    if (val.length < limit) {
        alert(returnmessage + " should not be less than " + limit);
        Control.focus();
        return false;
    }
    return true;
}

//-------------------------------------------------------------------
// checkDropDown(control,returnmessage)
//      Returns true if selectedindex>0;
// It is assumed that item at 0th index is like 'Select value'
//-------------------------------------------------------------------
function checkDropDown(Control, returnmessage) {
    val = Control.selectedIndex;

    if (val < 1) {
        alert("Please select the " + returnmessage);
        if (!Control.disabled)
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
    else
    { return true; }
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
    for (var i = (2 - (ccnum.length % 2)); i <= ccnum.length; i += 2) {
        checksum += parseInt(ccnum.charAt(i - 1));
    }
    // Analyze odd digits in even length strings or even digits in odd length strings.
    for (var i = (ccnum.length % 2) + 1; i < ccnum.length; i += 2) {
        var digit = parseInt(ccnum.charAt(i - 1)) * 2;
        if (digit < 10) { checksum += digit; } else { checksum += (digit - 9); }
    }
    if ((checksum % 10) == 0) return true; else return false;
}

//To check the valid credit card number using Luhn Algorithm
function CheckCreditCardNumber(cardNumber, cardType) {
    //debugger

    var isValid = false;
    var ccCheckRegExp = /[^\d ]/;
    isValid = !ccCheckRegExp.test(cardNumber);

    if (isValid) {
        var cardNumbersOnly = cardNumber.replace(/ /g, "");
        var cardNumberLength = cardNumbersOnly.length;
        var lengthIsValid = false;
        var prefixIsValid = false;
        var prefixRegExp;

        switch (cardType) {
            case "Master Card":
                lengthIsValid = (cardNumberLength == 16);
                prefixRegExp = /^5[1-5]/;
                break;

            case "Visa":
                lengthIsValid = (cardNumberLength == 16 || cardNumberLength == 13);
                prefixRegExp = /^4/;
                break;

            case "American Express":
                lengthIsValid = (cardNumberLength == 15);
                prefixRegExp = /^3(4|7)/;
                break;

            default:
                prefixRegExp = /^$/;
                alert("Card type not found");
        }

        prefixIsValid = prefixRegExp.test(cardNumbersOnly);
        isValid = prefixIsValid && lengthIsValid;
    }

    if (isValid) {
        var numberProduct;
        var numberProductDigitIndex;
        var checkSumTotal = 0;

        for (digitCounter = cardNumberLength - 1; digitCounter >= 0; digitCounter--) {
            checkSumTotal += parseInt(cardNumbersOnly.charAt(digitCounter));
            digitCounter--;
            numberProduct = String((cardNumbersOnly.charAt(digitCounter) * 2));
            for (var productDigitCounter = 0; productDigitCounter < numberProduct.length; productDigitCounter++) {
                checkSumTotal += parseInt(numberProduct.charAt(productDigitCounter));
            }
        }

        isValid = (checkSumTotal % 10 == 0);
    }
    return isValid;
}


function KeyPress_DecimalAllowedOnly(evt) {
    //debugger;
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

function KeyPress_NumericAllowedOnly(evt) {

    var key = (evt.which ? evt.which : ((evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : 0)));
    if (((key >= 48 && key <= 57) || key == 9 || key == 13 || key == 8 || (key >= 37 && key <= 40) || (key >= 96 && key <= 105)) && (evt.shiftKey == false)) {
        return true;
    }

    return false;
}

function minimum_fourcharacters(Control, returnMsg) {
    var textLength = (Control.value).length;
    if (textLength >= 3)
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

// to check file name
function Validate_CheckForFileName(evt) {
    var key = (evt.which ? evt.which : ((evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : 0)));
    if ((key == 56 && evt.shiftKey == true) || key == 106 || key == 220 || key == 191 || key == 111 || (key == 222 && evt.shiftKey == true) || (key == 188 && evt.shiftKey == true)
        || (key == 190 && evt.shiftKey == true) || (key == 186 && evt.shiftKey == true)) {
        return false;
    }

    return true;
}