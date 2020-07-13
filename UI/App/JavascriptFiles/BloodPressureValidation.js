

function onchangeSystolicbp(systolic) {   
    if (systolic == null)
        return false;
    
    var systolicValue = systolic.value;
    if (systolicValue != "" && !isNaN(systolicValue)) {

        if (systolicValue >= 50 && systolicValue <= 300) {
            return true;
        }
        else {
            alert("The value you have entered for Systolic Blood Pressure is outside the possible range. Please consider re-testing for a more suitable value.");
            return false;
        }
    }
}

function onchangeDiastolicbp(diastolic) {
    if (diastolic == null)
        return false;
    var diastolicValue = diastolic.value;
    if (diastolicValue != "" &&  !isNaN(diastolicValue)) {
        if (diastolicValue <= 200) {
            return true;
        }
        else {
            alert("The value you have entered for Diastolic Blood Pressure is outside the possible range. Please consider re-testing for a more suitable value.");
            return false;
        }
    }
}
