function RinneWeberHearing(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = {
            "Id": 0, "TestType": testTypeRinneWeberHearing,
            "WeberAbnormal": null, "TechnicianNotes": '', "ConductedByOrgRoleUserId": '0',
            "UnableScreenReason": new Array(),
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": {
                "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentRinneWeberHearingInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestRinneWeberHearingCheck").attr("checked")
            },
            "TestPerformedExternally": null
        };
    }
    this.Result = testResult;
}

RinneWeberHearing.prototype = {
    setData: function () {
        var testResult = this.Result;

        if (isRinneWeberHearingResultEntryType == 'True') {
            setTestPerformedExternally("chk_RinneWeberHearingcapturebyChat", testResult.TestPerformedExternally)
        }
        if (testResult.WeberNormal != null && testResult.WeberNormal.Reading == true) {
            $("#RinneWeberHearingWeberNormalinputcheck").attr("checked", "checked");
        }
        else if (testResult.WeberAbnormal != null && testResult.WeberAbnormal.Reading == true) {
            $("#RinneWeberHearingWeberAbnormalinputcheck").attr("checked", "checked");
        }

        if (testResult.RinneNormal != null && testResult.RinneNormal.Reading == true) {
            $("#RinneWeberHearingRinneNormalinputcheck").attr("checked", "checked");
        }
        else if (testResult.RinneAbnormal != null && testResult.RinneAbnormal.Reading == true) {
            $("#RinneWeberHearingRinneAbnormalinputcheck").attr("checked", "checked");
        }

        $("#DescribeSelfPresentRinneWeberHearingInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);
        $("#technotesRinneWeberHearing").val(testResult.TechnicianNotes);
        $("#conductedbyRinneWeberHearing option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);

        setboolTypeReading($('#RinneWeberHearingtechnicallyltdbutreadableinputcheck'), testResult.TechnicallyLimitedbutReadable);
        setboolTypeReading($('#RinneWeberHearingrepeatstudyinputcheck'), testResult.RepeatStudy);

        setUnableScreenReason($('.dtl-unabletoscreen-RinneWeberHearing'), testResult.UnableScreenReason);

        $("#PriorityInQueueTestRinneWeberHearingCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#rinneWeberHearing-priorityInQueue-span"), "onClick_PriorityInQueueDataRinneWeberHearing();", testTypeRinneWeberHearing);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#rinneWeberHearing-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#RinneWeberHearing-critical-span"), "onClick_CriticalDataRinneWeberHearing();", testTypeRinneWeberHearing);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#RinneWeberHearing-critical-span").parent().addClass("red-band");
                $("#criticalRinneWeberHearing").attr("checked", "checked");
            }
        }

        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksRinneWeberHearing").val(testResult.PhysicianInterpretation.Remarks);
            $("#criticalRinneWeberHearing").attr("checked", testResult.PhysicianInterpretation.IsCritical);

        }

    },
    getData: function () {
        var testResult = this.Result;
        if (isRinneWeberHearingResultEntryType == 'True') {
             testResult.TestPerformedExternally = getTestPerformedExternally("chk_RinneWeberHearingcapturebyChat", testResult.TestPerformedExternally)
        }

        testResult.WeberNormal = getboolTypeReadingRadioButton($(".WeberNormal"), testResult.WeberNormal);
        testResult.WeberAbnormal = getboolTypeReadingRadioButton($(".WeberAbnormal"), testResult.WeberAbnormal);
        testResult.RinneNormal = getboolTypeReadingRadioButton($(".RinneNormal"), testResult.RinneNormal);
        testResult.RinneAbnormal = getboolTypeReadingRadioButton($(".RinneAbnormal"), testResult.RinneAbnormal);

        if (currentScreenMode != ScreenMode.Physician) {

            //testResult.WeberNormal = getboolTypeReadingRadioButton($(".WeberNormal"), testResult.WeberNormal);
            //testResult.WeberAbnormal = getboolTypeReadingRadioButton($(".WeberAbnormal"), testResult.WeberAbnormal);
            //testResult.RinneNormal = getboolTypeReadingRadioButton($(".RinneNormal"), testResult.RinneNormal);
            //testResult.RinneAbnormal = getboolTypeReadingRadioButton($(".RinneAbnormal"), testResult.RinneAbnormal);

            if (currentScreenMode != ScreenMode.CorrectionPostEvaluation && currentScreenMode != ScreenMode.PostAudit) testResult.ResultStatus.StateNumber = $("#ResultStatusInputHidden").val();

            if (testResult.ResultStatus.Id > 0) {
                testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.ResultStatus.DataRecorderMetaData.DateModified = currentDate;
            } else {
                testResult.ResultStatus.DataRecorderMetaData = { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate };
            }
        }

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-RinneWeberHearing')));

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.ConductedByOrgRoleUserId = $("#conductedbyRinneWeberHearing option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesRinneWeberHearing").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentRinneWeberHearingInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestRinneWeberHearingCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_85").attr("checked");

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }

        if (currentScreenMode != ScreenMode.Entry) {

            testResult.RepeatStudy = getboolTypeReading($('#RinneWeberHearingrepeatstudyinputcheck'), testResult.RepeatStudy);
            testResult.TechnicallyLimitedbutReadable = getboolTypeReading($('#RinneWeberHearingtechnicallyltdbutreadableinputcheck'), testResult.TechnicallyLimitedbutReadable);

            if (testResult.PhysicianInterpretation == null)
                testResult.PhysicianInterpretation = {
                    'Remarks': $("#physicianRemarksRinneWeberHearing").val(),
                    'IsCritical': $("#criticalRinneWeberHearing").attr("checked"),
                    'FollowUp': $("#followUpRinneWeberHearing").attr("checked"),
                    'RecorderMetaData': {
                        'DataRecorderCreator': { 'Id': currentUser },
                        'DateCreated': currentDate
                    }
                };
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksRinneWeberHearing").val();
                testResult.PhysicianInterpretation.IsCritical = $("#criticalRinneWeberHearing").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }

        if (testResult.ResultStatus.StateNumber < 4) {
            if (testResult.LeftFootYes == null && testResult.LeftFootNo == null && testResult.RightFootYes == null && testResult.RightFootNo == null && testResult.TechnicianNotes.length < 1 && testResult.ConductedByOrgRoleUserId == "0" && testResult.UnableScreenReason == null && $("#DescribeSelfPresentRinneWeberHearingInputCheck").attr("checked") == false)
                return null;
        }

        return testResult;
    }
};


var criticalDataModel_RinneWeberHearing = null;
function onClick_CriticalDataRinneWeberHearing() {
    if ($("#DescribeSelfPresentRinneWeberHearingInputCheck").attr("checked")) {
        loadCriticalLink($("#RinneWeberHearing-critical-span"), "onClick_CriticalDataRinneWeberHearing();", testTypeRinneWeberHearing);
        openCriticalDataDialog(testTypeRinneWeberHearing, $("#conductedbyRinneWeberHearing"), $("#DescribeSelfPresentRinneWeberHearingInputCheck"), setCriticalDataModel_RinneWeberHearing);
    }
    else {
        unloadCriticalLink($("#RinneWeberHearing-critical-span"), testTypeRinneWeberHearing);
    }
}

function setCriticalDataModel_RinneWeberHearing(model, printAfterSave) {
    if (model != null) {
        var testResult = GetRinneWeberHearingData();
        saveSingleTestResult(testResult, model, $("#RinneWeberHearing-critical-span"), "onClick_CriticalDataRinneWeberHearing();", SetRinneWeberHearingData, printAfterSave);
    }
}

function getCriticalDataModel_RinneWeberHearing() {
    if ($("#DescribeSelfPresentRinneWeberHearingInputCheck").attr("checked") && criticalDataModel_RinneWeberHearing != null) {
        criticalDataModel_RinneWeberHearing.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_RinneWeberHearing;
    }
    return null;
}

function onClick_PriorityInQueueDataRinneWeberHearing() {
    if ($("#PriorityInQueueTestRinneWeberHearingCheck").attr("checked")) {
        loadPriorityInQueueLink($("#rinneWeberHearing-priorityInQueue-span"), "onClick_PriorityInQueueDataRinneWeberHearing();", testTypeRinneWeberHearing);
        openPriorityInQueueTestDialog(testTypeRinneWeberHearing, $("#conductedbyRinneWeberHearing"), $("#PriorityInQueueTestRinneWeberHearingCheck"), setPriorityInQueueDataModel_RinneWeberHearing);
    }
    else {
        unloadPriorityInQueueLink($("#rinneWeberHearing-priorityInQueue-span"), testTypeRinneWeberHearing);
    }
}

function setPriorityInQueueDataModel_RinneWeberHearing(model) {
    if (model != null) {
        var testResult = GetRinneWeberHearingData();
        model.TestId = testTypeRinneWeberHearing;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#rinneWeberHearing-priorityInQueue-span"), "onClick_PriorityInQueueDataRinneWeberHearing();", SetRinneWeberHearingData);
    }
}

function clearAllRinneWeberHearingSelection() {
    $("#RinneWeberHearingWeberNormalinputcheck, #RinneWeberHearingWeberAbnormalinputcheck, #RinneWeberHearingRinneNormalinputcheck,#RinneWeberHearingRinneAbnormalinputcheck").attr("checked", false);
}
function clearAllRinneWeberHearingSelection() {
    $("#RinneWeberHearingWeberNormalinputcheck, #RinneWeberHearingWeberAbnormalinputcheck, #RinneWeberHearingRinneNormalinputcheck,#RinneWeberHearingRinneAbnormalinputcheck").attr("checked", false);
}