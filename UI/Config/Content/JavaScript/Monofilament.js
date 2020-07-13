function Monofilament(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = {
            "Id": 0, "TestType": testTypeMonofilament,
            "RightNegative": null, "TechnicianNotes": '', "ConductedByOrgRoleUserId": '0',
            "UnableScreenReason": new Array(),
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": {
                "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentMonofilamentInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestMonofilamentCheck").attr("checked")
            },
            "TestPerformedExternally": null
        };
    }
    this.Result = testResult;
}

Monofilament.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (isMonofilamentResultEntryType == 'True') {
            setTestPerformedExternally("chk_MonofilamentcapturebyChat", testResult.TestPerformedExternally)
        }

        if (testResult.RightPositive != null && testResult.RightPositive.Reading == true) {
            $("#MonofilamentRightPositiveinputcheck").attr("checked", "checked");
        }
        else if (testResult.RightNegative != null && testResult.RightNegative.Reading == true) {
            $("#MonofilamentRightNegativeinputcheck").attr("checked", "checked");
        }

        if (testResult.LeftPositive != null && testResult.LeftPositive.Reading == true) {
            $("#MonofilamentLeftPositiveinputcheck").attr("checked", "checked");
        }
        else if (testResult.LeftNegative != null && testResult.LeftNegative.Reading == true) {
            $("#MonofilamentLeftNegativeinputcheck").attr("checked", "checked");
        }

        $("#DescribeSelfPresentMonofilamentInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);
        $("#technotesMonofilament").val(testResult.TechnicianNotes);
        $("#conductedbyMonofilament option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);

        setboolTypeReading($('#Monofilamenttechnicallyltdbutreadableinputcheck'), testResult.TechnicallyLimitedbutReadable);
        setboolTypeReading($('#Monofilamentrepeatstudyinputcheck'), testResult.RepeatStudy);

        setUnableScreenReason($('.dtl-unabletoscreen-Monofilament'), testResult.UnableScreenReason);

        setTestNotPerformedReasonForMonofilament(testResult.TestNotPerformed);

        $("#PriorityInQueueTestMonofilamentCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#monofilament-priorityInQueue-span"), "onClick_PriorityInQueueDataMonofilament();", testTypeMonofilament);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#monofilament-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#Monofilament-critical-span"), "onClick_CriticalDataMonofilament();", testTypeMonofilament);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#Monofilament-critical-span").parent().addClass("red-band");
                $("#criticalMonofilament").attr("checked", "checked");
            }
        }

        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksMonofilament").val(testResult.PhysicianInterpretation.Remarks);
            $("#criticalMonofilament").attr("checked", testResult.PhysicianInterpretation.IsCritical);

        }

    },
    getData: function () {
        var testResult = this.Result;

        if (isMonofilamentResultEntryType == 'True') {
            testResult.TestPerformedExternally = getTestPerformedExternally("chk_MonofilamentcapturebyChat", testResult.TestPerformedExternally)
        }

        testResult.RightPositive = getboolTypeReadingRadioButton($(".RightPositive"), testResult.RightPositive);
        testResult.RightNegative = getboolTypeReadingRadioButton($(".RightNegative"), testResult.RightNegative);
        testResult.LeftPositive = getboolTypeReadingRadioButton($(".LeftPositive"), testResult.LeftPositive);
        testResult.LeftNegative = getboolTypeReadingRadioButton($(".LeftNegative"), testResult.LeftNegative);

        if (currentScreenMode != ScreenMode.Physician) {

            //testResult.RightPositive = getboolTypeReadingRadioButton($(".RightPositive"), testResult.RightPositive);
            //testResult.RightNegative = getboolTypeReadingRadioButton($(".RightNegative"), testResult.RightNegative);
            //testResult.LeftPositive = getboolTypeReadingRadioButton($(".LeftPositive"), testResult.LeftPositive);
            //testResult.LeftNegative = getboolTypeReadingRadioButton($(".LeftNegative"), testResult.LeftNegative);

            if (currentScreenMode != ScreenMode.CorrectionPostEvaluation && currentScreenMode != ScreenMode.PostAudit) testResult.ResultStatus.StateNumber = $("#ResultStatusInputHidden").val();

            if (testResult.ResultStatus.Id > 0) {
                testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.ResultStatus.DataRecorderMetaData.DateModified = currentDate;
            } else {
                testResult.ResultStatus.DataRecorderMetaData = { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate };
            }
        }

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-Monofilament')));

        testResult.TestNotPerformed = getTestNotPerformedReasonForMonofilament(testResult.TestNotPerformed);

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.ConductedByOrgRoleUserId = $("#conductedbyMonofilament option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesMonofilament").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentMonofilamentInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestMonofilamentCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_91").attr("checked");

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }

        if (currentScreenMode != ScreenMode.Entry) {

            testResult.RepeatStudy = getboolTypeReading($('#Monofilamentrepeatstudyinputcheck'), testResult.RepeatStudy);
            testResult.TechnicallyLimitedbutReadable = getboolTypeReading($('#Monofilamenttechnicallyltdbutreadableinputcheck'), testResult.TechnicallyLimitedbutReadable);

            if (testResult.PhysicianInterpretation == null)
                testResult.PhysicianInterpretation = {
                    'Remarks': $("#physicianRemarksMonofilament").val(),
                    'IsCritical': $("#criticalMonofilament").attr("checked"),
                    'FollowUp': $("#followUpMonofilament").attr("checked"),
                    'RecorderMetaData': {
                        'DataRecorderCreator': { 'Id': currentUser },
                        'DateCreated': currentDate
                    }
                };
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksMonofilament").val();
                testResult.PhysicianInterpretation.IsCritical = $("#criticalMonofilament").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }

        if (testResult.ResultStatus.StateNumber < 4) {
            if (testResult.LeftFootYes == null && testResult.LeftFootNo == null && testResult.RightFootYes == null && testResult.RightFootNo == null && testResult.TechnicianNotes.length < 1 && testResult.ConductedByOrgRoleUserId == "0" && testResult.UnableScreenReason == null && $("#DescribeSelfPresentMonofilamentInputCheck").attr("checked") == false)
                return null;
        }

        return testResult;
    }
};


var criticalDataModel_Monofilament = null;
function onClick_CriticalDataMonofilament() {
    if ($("#DescribeSelfPresentMonofilamentInputCheck").attr("checked")) {
        loadCriticalLink($("#Monofilament-critical-span"), "onClick_CriticalDataMonofilament();", testTypeMonofilament);
        openCriticalDataDialog(testTypeMonofilament, $("#conductedbyMonofilament"), $("#DescribeSelfPresentMonofilamentInputCheck"), setCriticalDataModel_Monofilament);
    }
    else {
        unloadCriticalLink($("#Monofilament-critical-span"), testTypeMonofilament);
    }
}

function setCriticalDataModel_Monofilament(model, printAfterSave) {
    if (model != null) {
        var testResult = GetMonofilamentData();
        saveSingleTestResult(testResult, model, $("#Monofilament-critical-span"), "onClick_CriticalDataMonofilament();", SetMonofilamentData, printAfterSave);
    }
}

function getCriticalDataModel_Monofilament() {
    if ($("#DescribeSelfPresentMonofilamentInputCheck").attr("checked") && criticalDataModel_Monofilament != null) {
        criticalDataModel_Monofilament.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_Monofilament;
    }
    return null;
}

function onClick_PriorityInQueueDataMonofilament() {
    if ($("#PriorityInQueueTestMonofilamentCheck").attr("checked")) {
        loadPriorityInQueueLink($("#monofilament-priorityInQueue-span"), "onClick_PriorityInQueueDataMonofilament();", testTypeMonofilament);
        openPriorityInQueueTestDialog(testTypeMonofilament, $("#conductedbyMonofilament"), $("#PriorityInQueueTestMonofilamentCheck"), setPriorityInQueueDataModel_Monofilament);
    }
    else {
        unloadPriorityInQueueLink($("#monofilament-priorityInQueue-span"), testTypeMonofilament);
    }
}

function setPriorityInQueueDataModel_Monofilament(model) {
    if (model != null) {
        var testResult = GetMonofilamentData();
        model.TestId = testTypeMonofilament;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#monofilament-priorityInQueue-span"), "onClick_PriorityInQueueDataMonofilament();", SetMonofilamentData);
    }
}

function clearAllMonofilamentSelection() {
    $("#MonofilamentRightPositiveinputcheck, #MonofilamentRightNegativeinputcheck, #MonofilamentLeftPositiveinputcheck,#MonofilamentLeftNegativeinputcheck").attr("checked", false);
}


function setTestNotPerformedReasonForMonofilament(testNotPerformed) {
    setTestNotPerformed("testnotPerformedMonofilament", testNotPerformed);
    SetTestNotPerformedEnableDisabled("testnotPerformedMonofilament");
}

function getTestNotPerformedReasonForMonofilament(testNotPerformed) {
    return getTestNotPerformed("testnotPerformedMonofilament", testNotPerformed);
}