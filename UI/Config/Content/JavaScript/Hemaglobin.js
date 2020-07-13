function Hemaglobin(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = { "Id": 0, "TestType": testTypeHemaglobin,
            "Hba1c": null, "TechnicianNotes": '', "ConductedByOrgRoleUserId": '0',
            "UnableScreenReason": new Array(),
            "TestPerformedExternally": null,
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": { "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentHemaglobinInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestHemaglobinCheck").attr("checked")
            }
        };
    }
    this.Result = testResult;
}

Hemaglobin.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (IshemaglobinResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_hemaglobincapturebyChat", testResult.TestPerformedExternally)
        }
        setReading($("#hba1ctextbox"), testResult.Hba1c);

        $("#DescribeSelfPresentHemaglobinInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);

        $("#technoteshba1c").val(testResult.TechnicianNotes);
        $("#conductedbyhemaglobin option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);

        setUnableScreenReason($('.dtl-unabletoscreen-hemaglobin'), testResult.UnableScreenReason);

        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksHemaglobin").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpHemaglobin").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalHemaglobin").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }
        
        $("#PriorityInQueueTestHemaglobinCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#a1c-priorityInQueue-span"), "onClick_PriorityInQueueDataHemaglobin();", testTypeHemaglobin);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#a1c-priorityInQueue-span").parent().addClass("yellow-band");  
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#a1c-critical-span"), "onClick_CriticalDatahbA1c();", testTypeHemaglobin);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#a1c-critical-span").parent().addClass("red-band");
                $("#criticalHemaglobin").attr("checked", "checked");
            }
        }
    },
    getData: function () {
        var testResult = this.Result;
        if (IshemaglobinResultEntryExternaly == 'True') {
             testResult.TestPerformedExternally = getTestPerformedExternally("chk_hemaglobincapturebyChat", testResult.TestPerformedExternally)
        }

        testResult.Hba1c = getReading($("#hba1ctextbox"), testResult.Hba1c);
        
        if (currentScreenMode != ScreenMode.Physician) {
            //testResult.Hba1c = getReading($("#hba1ctextbox"), testResult.Hba1c);
            if (currentScreenMode != ScreenMode.CorrectionPostEvaluation) testResult.ResultStatus.StateNumber = $("#ResultStatusInputHidden").val();

            if (testResult.ResultStatus.Id > 0) {
                testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.ResultStatus.DataRecorderMetaData.DateModified = currentDate;
            }
            else {
                testResult.ResultStatus.DataRecorderMetaData = { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate };
            }
        }
        
        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-hemaglobin')));

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.ConductedByOrgRoleUserId = $("#conductedbyhemaglobin option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technoteshba1c").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentHemaglobinInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestHemaglobinCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_25").attr("checked");

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }

        if (currentScreenMode != ScreenMode.Entry) {
            if (testResult.PhysicianInterpretation == null)
                testResult.PhysicianInterpretation = { 'Remarks': $("#physicianRemarksHemaglobin").val(), 'IsCritical': $("#criticalHemaglobin").attr("checked"), 'FollowUp': $("#followUpHemaglobin").attr("checked"), 'RecorderMetaData': {
                    'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate
                }
                };
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksHemaglobin").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpHemaglobin").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalHemaglobin").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }

        if (testResult.ResultStatus.StateNumber < 4) {
            if (testResult.Hba1c == null && testResult.TechnicianNotes.length < 1 && testResult.ConductedByOrgRoleUserId == "0" && testResult.UnableScreenReason == null && $("#DescribeSelfPresentHemaglobinInputCheck").attr("checked") == false)
                return null;
        }

        return testResult;
    }
}


var criticalDataModel_hbA1c = null;
function onClick_CriticalDatahbA1c() {
    if ($("#DescribeSelfPresentHemaglobinInputCheck").attr("checked")) {
        loadCriticalLink($("#a1c-critical-span"), "onClick_CriticalDatahbA1c();", testTypeHemaglobin);
        openCriticalDataDialog(testTypeHemaglobin, $("#conductedbyhemaglobin"), $("#DescribeSelfPresentHemaglobinInputCheck"), setCriticalDataModel_hbA1c);
    }
    else {
        unloadCriticalLink($("#a1c-critical-span"), testTypeHemaglobin);
    }
}

function setCriticalDataModel_hbA1c(model, printAfterSave) {
    if (model != null) {
        var testResult = GetA1cData();
        saveSingleTestResult(testResult, model, $("#a1c-critical-span"), "onClick_CriticalDatahbA1c();", SetA1cData, printAfterSave);
    }
}

function getCriticalDataModel_hbA1c() {
    if ($("#DescribeSelfPresentHemaglobinInputCheck").attr("checked") && criticalDataModel_hbA1c != null) {
        criticalDataModel_hbA1c.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_hbA1c;
    }
    return null;
}

//
function onClick_PriorityInQueueDataHemaglobin() {
    if ($("#PriorityInQueueTestHemaglobinCheck").attr("checked")) {
        loadPriorityInQueueLink($("#a1c-priorityInQueue-span"), "onClick_PriorityInQueueDataHemaglobin();", testTypeHemaglobin);
        openPriorityInQueueTestDialog(testTypeHemaglobin, $("#conductedbyhemaglobin"), $("#PriorityInQueueTestHemaglobinCheck"), setPriorityInQueueDataModel_Hemaglobin);
    }
    else {
        unloadPriorityInQueueLink($("#a1c-priorityInQueue-span"), testTypeHemaglobin);
    }
}

function setPriorityInQueueDataModel_Hemaglobin(model) {
    if (model != null) {
        var testResult = GetA1cData();
        model.TestId = testTypeHemaglobin;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#a1c-priorityInQueue-span"), "onClick_PriorityInQueueDataHemaglobin();", SetA1cData);
    }
}
