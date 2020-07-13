

function setSectionforPhysician() {
    $(".upload-media-section").hide();
    $(".conductedby-ddl").attr("disabled", "disabled");
    $(".unable-to-screen-section input").attr("disabled", "disabled");
    setSectionDisabledForPhysician();
    currentScreenMode = ScreenMode.Physician;
}

function setSectionforEntry() {
    $(".physician-section").hide();
    currentScreenMode = ScreenMode.Entry;
}

function setSectionforCorrectionPreEvaluation() {
    $(".physician-section").hide();
    $(".test-section-header input, .test-section-header select").attr("disabled", "disabled");
    currentScreenMode = ScreenMode.CorrectionPreEvaluation;
}

function setSectionforCorrectionPostEvaluation() {
    $(".technotes").attr("disabled", "disabled");
    $(".test-section-header input, .test-section-header select").attr("disabled", "disabled");
    currentScreenMode = ScreenMode.CorrectionPostEvaluation;
}


function CheckElevatedBP(systolicValue, diastolicValue) {

    systolicValue = $.trim($("#systolicbp").val()).length > 0 && !isNaN($("#systolicbp").val()) ? Number($("#systolicbp").val()) : 0;
    diastolicValue = $.trim($("#diastolicbp").val()).length > 0 && !isNaN($("#diastolicbp").val()) ? Number($("#diastolicbp").val()) : 0;

    var bolChecked = false;
    if (systolicValue >= 140 || diastolicValue >= 90) bolChecked = true;

    return bolChecked;
}
