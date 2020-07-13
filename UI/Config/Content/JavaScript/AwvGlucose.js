function AwvGlucose(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = {
            "Glucose": null,
            "Id": 0, "TestType": testTypeAwvGlucose,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": '0',
            "UnableScreenReason": new Array(),
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "TestPerformedExternally": null,
            "ResultStatus": {
                "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentAwvGlucoseInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestAwvGlucoseCheck").attr("checked")
            }
        };
    }
    this.Result = testResult;
}

AwvGlucose.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (IsawvGlucoseResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_AwvGlucosecapturebyChat", testResult.TestPerformedExternally)
        }

        if (testResult.Glucose != null) {
            if (testResult.Glucose.Reading != null)
                $("#GlucoseAwvGlucoseInputText").val(testResult.Glucose.Reading);

            if (testResult.Glucose.Finding != null) {
                setSelectedFinding($(".glucose-AwvGlucose-finding"), testResult.Glucose.Finding.Id);
            }
        }

        $("#technotesAwvGlucose").val(testResult.TechnicianNotes);
        $("#conductedbyAwvGlucose option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);
        $("#DescribeSelfPresentAwvGlucoseInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);
        $("#PriorityInQueueTestAwvGlucoseCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#awvGlucose-priorityInQueue-span"), "onClick_PriorityInQueueDataAwvGlucose();", testTypeAwvGlucose);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#awvGlucose-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#AwvGlucose-critical-span"), "onClick_CriticalDataAwvGlucose();", testTypeAwvGlucose);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#AwvGlucose-critical-span").parent().addClass("red-band");
                $("#criticalAwvGlucose").attr("checked", "checked");
            }
        }

        setUnableScreenReason($('.dtl-unabletoscreen-AwvGlucose'), testResult.UnableScreenReason);

        setTestNotPerformedReasonForAwvGlucose(testResult.TestNotPerformed);

        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksAwvGlucose").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpAwvGlucose").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalAwvGlucose").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }

    },
    getData: function () {
        var testResult = this.Result;
        if (IsawvGlucoseResultEntryExternaly == 'True') {
             testResult.TestPerformedExternally = getTestPerformedExternally("chk_AwvGlucosecapturebyChat", testResult.TestPerformedExternally)
        }

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-AwvGlucose')));

        testResult.TestNotPerformed = getTestNotPerformedReasonForAwvGlucose(testResult.TestNotPerformed);
        testResult.Glucose = getReading($("#GlucoseAwvGlucoseInputText"), testResult.Glucose);

        if (currentScreenMode != ScreenMode.Physician) {

            if (currentScreenMode != ScreenMode.CorrectionPostEvaluation && currentScreenMode != ScreenMode.PostAudit) testResult.ResultStatus.StateNumber = $("#ResultStatusInputHidden").val();

            if (testResult.ResultStatus.Id > 0) {
                testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.ResultStatus.DataRecorderMetaData.DateModified = currentDate;
            }
            else {
                testResult.ResultStatus.DataRecorderMetaData = { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate };
            }
        }

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.ConductedByOrgRoleUserId = $("#conductedbyAwvGlucose option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesAwvGlucose").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentAwvGlucoseInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestAwvGlucoseCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_58").attr("checked");

        var gluFinding = getSelectedFinding($(".glucose-AwvGlucose-finding"));
        if (testResult.Glucose != null) {
            testResult.Glucose.Finding = getFindingDataandSynchronized(testResult.Glucose.Finding, gluFinding);
        }
        else if (gluFinding != null) {
            testResult.Glucose = { 'Finding': getFindingDataandSynchronized(null, gluFinding), "ReadingSource": readingSourceManual, 'RecorderMetaData': { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate } };
        }

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }

        if (currentScreenMode != ScreenMode.Entry) {
            if (testResult.PhysicianInterpretation == null) {
                testResult.PhysicianInterpretation = {
                    'Remarks': $("#physicianRemarksAwvGlucose").val(), 'IsCritical': $("#criticalAwvGlucose").attr("checked"), 'FollowUp': $("#followUpAwvGlucose").attr("checked"), 'RecorderMetaData': {
                        'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate
                    }
                };
            }
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksAwvGlucose").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpAwvGlucose").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalAwvGlucose").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }

        if (testResult.ResultStatus.StateNumber < 4) {
            if (testResult.Glucose != null && testResult.TechnicianNotes.length < 1 && testResult.ConductedByOrgRoleUserId == "0" && testResult.UnableScreenReason == null && $("#DescribeSelfPresentAwvGlucoseInputCheck").attr("checked") == false)
                return null;
        }

        return testResult;
    }
}


var criticalDataModel_AwvGlucose = null;
function onClick_CriticalDataAwvGlucose() {
    if ($("#DescribeSelfPresentAwvGlucoseInputCheck").attr("checked")) {
        loadCriticalLink($("#AwvGlucose-critical-span"), "onClick_CriticalDataAwvGlucose();", testTypeAwvGlucose);
        openCriticalDataDialog(testTypeAwvGlucose, $("#conductedbyAwvGlucose"), $("#DescribeSelfPresentAwvGlucoseInputCheck"), setcriticalDataModel_AwvGlucose);
    }
    else {
        unloadCriticalLink($("#AwvGlucose-critical-span"), testTypeAwvGlucose);
    }
}

function setcriticalDataModel_AwvGlucose(model, printAfterSave) {
    if (model != null) {
        var testResult = GetAwvGlucoseData();
        saveSingleTestResult(testResult, model, $("#AwvGlucose-critical-span"), "onClick_CriticalDataAwvGlucose();", SetAwvGlucoseData, printAfterSave);
    }
}

function getcriticalDataModel_AwvGlucose() {
    if ($("#DescribeSelfPresentAwvGlucoseInputCheck").attr("checked") && criticalDataModel_AwvGlucose != null) {
        criticalDataModel_AwvGlucose.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_AwvGlucose;
    }
    return null;
}

function onClick_PriorityInQueueDataAwvGlucose() {
    if ($("#PriorityInQueueTestAwvGlucoseCheck").attr("checked")) {
        loadPriorityInQueueLink($("#awvGlucose-priorityInQueue-span"), "onClick_PriorityInQueueDataAwvGlucose();", testTypeAwvGlucose);
        openPriorityInQueueTestDialog(testTypeAwvGlucose, $("#conductedbyAwvGlucose"), $("#PriorityInQueueTestAwvGlucoseCheck"), setPriorityInQueueDataModel_AwvGlucose);
    }
    else {
        unloadPriorityInQueueLink($("#awvGlucose-priorityInQueue-span"), testTypeAwvGlucose);
    }
}

function setPriorityInQueueDataModel_AwvGlucose(model) {
    if (model != null) {
        var testResult = GetAwvGlucoseData();
        model.TestId = testTypeAwvGlucose;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#awvGlucose-priorityInQueue-span"), "onClick_PriorityInQueueDataAwvGlucose();", SetAwvGlucoseData);
    }
}


function clearAllAwvGlucoseSelection() {
    $(".clear-all-AwvGlucose-selection input[type=radio]").attr("checked", false);
}

function setTestNotPerformedReasonForAwvGlucose(testNotPerformed) {
    setTestNotPerformed("testnotPerformedAwvGlucose", testNotPerformed);
    SetTestNotPerformedEnableDisabled("testnotPerformedAwvGlucose");
}

function getTestNotPerformedReasonForAwvGlucose(testNotPerformed) {
    return getTestNotPerformed("testnotPerformedAwvGlucose", testNotPerformed);
}