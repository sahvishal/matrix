function checkTotalCholesterolOutsidePossibleRange(tcValue) {
    tcValue = $.trim(tcValue);
    if (tcValue != "" && !isNaN(parseFloat(tcValue))) {
        if (tcValue > 240) {
            alert('The value you have entered for Total Cholesterol is outside the possible range. Please consider re-testing for a more suitable value.');
        }
    }
}


function checkHDLOutsidePossibleRange(hdlValue) {
    hdlValue = $.trim(hdlValue);
    if (hdlValue != "" && !isNaN(parseFloat(hdlValue))) {
        if (hdlValue > 70 || hdlValue < 30) {
            alert('The value you have entered for HDL is outside the possible range. Please consider re-testing for a more suitable value.');
        }
    }
}

function checkLdlOutsidePossibleRange(ldlValue) {
    ldlValue = $.trim(ldlValue);
    if (ldlValue != "" && !isNaN(parseFloat(ldlValue))) {
        if (ldlValue > 190 || ldlValue < 60) {
            alert('The value you have entered for LDL is outside the possible range. Please consider re-testing for a more suitable value.');

        }
    }
}
function checkTriglyceridesOutsidePossibleRange(tgValue) {
    tgValue = $.trim(tgValue);
    if (tgValue != "" && !isNaN(parseFloat(tgValue))) {
        if (tgValue > 350 || tgValue < 80) {
            alert('The value you have entered for Triglycerides is outside the possible range. Please consider re-testing for a more suitable value.');
        }
    }
}

function checkTotalNonCholesterolOutsidePossibleRange(tcValue) {
    tcValue = $.trim(tcValue);
    if (tcValue != "" && !isNaN(parseFloat(tcValue))) {
        if (tcValue > 220 || tgValue < 100) {
            alert('The value you have entered for Total Cholesterol is outside the possible range. Please consider re-testing for a more suitable value.');
        }
    }
}