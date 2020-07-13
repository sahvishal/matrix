function AwvHemaglobin(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = {
            "Id": 0, "TestType": testTypeAwvHemaglobin,
            "Hba1c": null, "TechnicianNotes": '', "ConductedByOrgRoleUserId": '0',
            "UnableScreenReason": new Array(),
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "TestPerformedExternally": null,
            "ResultStatus": {
                "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentAwvHemaglobinInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestAwvHemaglobinCheck").attr("checked")
            }
        };
    }
    this.Result = testResult;
}

AwvHemaglobin.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (IsawvHemaglobinResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_awvHemaglobincapturebyChat", testResult.TestPerformedExternally)
        }

        setReading($("#Awvhba1ctextbox"), testResult.Hba1c);
        $("#DescribeSelfPresentAwvHemaglobinInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);

        $("#technotesAwvHemaglobin").val(testResult.TechnicianNotes);
        $("#conductedbyAwvHemaglobin option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);

        setUnableScreenReason($('.dtl-unabletoscreen-AwvHemaglobin'), testResult.UnableScreenReason);
        
        setTestNotPerformedReasonForAwvHemaglobin(testResult.TestNotPerformed);
        
        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksAwvHemaglobin").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpAwvHemaglobin").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalAwvHemaglobin").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }
        $("#PriorityInQueueTestAwvHemaglobinCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#awvHemaglobin-priorityInQueue-span"), "onClick_PriorityInQueueDataAwvHemaglobin();", testTypeAwvHemaglobin);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#awvHemaglobin-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#AwvHemaglobin-critical-span"), "onClick_CriticalDataAwvHemaglobin();", testTypeAwvHemaglobin);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#AwvHemaglobin-critical-span").parent().addClass("red-band");
            }
        }
    },
    getData: function () {
        var testResult = this.Result;
        if (IsawvHemaglobinResultEntryExternaly == 'True') {
            testResult.TestPerformedExternally = getTestPerformedExternally("chk_awvHemaglobincapturebyChat", testResult.TestPerformedExternally)
        }
                
        testResult.Hba1c = getReading($("#Awvhba1ctextbox"), testResult.Hba1c);

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
        
        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-AwvHemaglobin')));

        testResult.TestNotPerformed = getTestNotPerformedReasonForAwvHemaglobin(testResult.TestNotPerformed);

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.ConductedByOrgRoleUserId = $("#conductedbyAwvHemaglobin option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesAwvHemaglobin").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentAwvHemaglobinInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestAwvHemaglobinCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_59").attr("checked");

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }
        
        if (currentScreenMode != ScreenMode.Entry) {
            if (testResult.PhysicianInterpretation == null)
                testResult.PhysicianInterpretation = {
                    'Remarks': $("#physicianRemarksAwvHemaglobin").val(), 'IsCritical': $("#criticalAwvHemaglobin").attr("checked"), 'FollowUp': $("#followUpAwvHemaglobin").attr("checked"), 'RecorderMetaData': {
                        'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate
                    }
                };
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksAwvHemaglobin").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpAwvHemaglobin").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalAwvHemaglobin").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }

        if (testResult.ResultStatus.StateNumber < 4) {
            if (testResult.Hba1c == null && testResult.TechnicianNotes.length < 1 && testResult.ConductedByOrgRoleUserId == "0" && testResult.UnableScreenReason == null && $("#DescribeSelfPresentAwvHemaglobinInputCheck").attr("checked") == false)
                return null;
        }

        return testResult;
    }
}


var criticalDataModel_AwvHemaglobin = null;
function onClick_CriticalDataAwvHemaglobin() {
    if ($("#DescribeSelfPresentAwvHemaglobinInputCheck").attr("checked")) {
        loadCriticalLink($("#AwvHemaglobin-critical-span"), "onClick_CriticalDataAwvHemaglobin();", testTypeAwvHemaglobin);
        openCriticalDataDialog(testTypeAwvHemaglobin, $("#conductedbyAwvHemaglobin"), $("#DescribeSelfPresentAwvHemaglobinInputCheck"), setCriticalDataModel_AwvHemaglobin);
    }
    else {
        unloadCriticalLink($("#AwvHemaglobin-critical-span"), testTypeAwvHemaglobin);
    }
}

function setCriticalDataModel_AwvHemaglobin(model, printAfterSave) {
    if (model != null) {
        var testResult = GetAwvHemaglobinData();
        saveSingleTestResult(testResult, model, $("#AwvHemaglobin-critical-span"), "onClick_CriticalDataAwvHemaglobin();", SetAwvHemaglobinData, printAfterSave);
    }
}

function getCriticalDataModel_AwvHemaglobin() {
    if ($("#DescribeSelfPresentAwvHemaglobinInputCheck").attr("checked") && criticalDataModel_AwvHemaglobin != null) {
        criticalDataModel_AwvHemaglobin.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_AwvHemaglobin;
    }
    return null;
}

//AwvHemaglobin-critical-span

function onClick_PriorityInQueueDataAwvHemaglobin() {
    if ($("#PriorityInQueueTestAwvHemaglobinCheck").attr("checked")) {
        loadPriorityInQueueLink($("#awvHemaglobin-priorityInQueue-span"), "onClick_PriorityInQueueDataAwvHemaglobin();", testTypeAwvHemaglobin);
        openPriorityInQueueTestDialog(testTypeAwvHemaglobin, $("#conductedbyAwvHemaglobin"), $("#PriorityInQueueTestAwvHemaglobinCheck"), setPriorityInQueueDataModel_AwvHemaglobin);
    }
    else {
        unloadPriorityInQueueLink($("#awvHemaglobin-priorityInQueue-span"), testTypeAwvHemaglobin);
    }
}

function setPriorityInQueueDataModel_AwvHemaglobin(model) {
    if (model != null) {
        var testResult = GetAwvHemaglobinData();
        model.TestId = testTypeAwvHemaglobin;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#awvHemaglobin-priorityInQueue-span"), "onClick_PriorityInQueueDataAwvHemaglobin();", SetAwvHemaglobinData);
    }
}

function setTestNotPerformedReasonForAwvHemaglobin(testNotPerformed) {
    setTestNotPerformed("testnotPerformedAwvHemaglobin", testNotPerformed);
    SetTestNotPerformedEnableDisabled("testnotPerformedAwvHemaglobin");
}

function getTestNotPerformedReasonForAwvHemaglobin(testNotPerformed) {
    return getTestNotPerformed("testnotPerformedAwvHemaglobin", testNotPerformed);
}
