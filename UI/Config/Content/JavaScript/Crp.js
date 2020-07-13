function Crp(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = { "Id": 0, "TestType": testTypeCrp,
            "LCRP": null, "TechnicianNotes": '', "ConductedByOrgRoleUserId": '0',
            "UnableScreenReason": new Array(),
            "TestPerformedExternally": null,
             
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": { "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentCrpInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestCrpCheck").attr("checked")
            }
        };
    }
    this.Result = testResult;
}

Crp.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (IscrpResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_crpcapturebyChat", testResult.TestPerformedExternally)
        }

        setReading($("#lcrptextbox"), testResult.LCRP);
        
        $("#DescribeSelfPresentCrpInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);

        $("#PriorityInQueueTestCrpCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#crp-priorityInQueue-span"), "onClick_PriorityInQueueDataCrp();", testTypeCrp);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#crp-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#crp-critical-span"), "onClick_CriticalDataCrp();", testTypeCrp);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#crp-critical-span").parent().addClass("red-band");
            }
        }

        $("#technotesCrp").val(testResult.TechnicianNotes);
        $("#conductedbyCrp option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);

        setUnableScreenReason($('.dtl-unabletoscreen-Crp'), testResult.UnableScreenReason);

    },
    getData: function () {
        var testResult = this.Result;
        if (IscrpResultEntryExternaly == 'True') {
             testResult.TestPerformedExternally = getTestPerformedExternally("chk_crpcapturebyChat", testResult.TestPerformedExternally)
        }
        
        testResult.LCRP = getReading($("#lcrptextbox"), testResult.LCRP);
        
        if (currentScreenMode != ScreenMode.Physician) {
            //testResult.LCRP = getReading($("#lcrptextbox"), testResult.LCRP);
            if (currentScreenMode != ScreenMode.CorrectionPostEvaluation && currentScreenMode != ScreenMode.PostAudit) testResult.ResultStatus.StateNumber = $("#ResultStatusInputHidden").val();

            if (testResult.ResultStatus.Id > 0) {
                testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.ResultStatus.DataRecorderMetaData.DateModified = currentDate;
            }
            else {
                testResult.ResultStatus.DataRecorderMetaData = { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate };
            }
        }

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-Crp')));

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.ConductedByOrgRoleUserId = $("#conductedbyCrp option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesCrp").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentCrpInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestCrpCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_17").attr("checked");

        if (testResult.ResultStatus.StateNumber < 4) {
            if (testResult.LCRP == null && testResult.TechnicianNotes.length < 1 && testResult.ConductedByOrgRoleUserId == "0" && testResult.UnableScreenReason == null && $("#DescribeSelfPresentCrpInputCheck").attr("checked") == false)
                return null;
        }

        return testResult;
    }
}


var criticalDataModel_Crp = null;
function onClick_CriticalDataCrp() {
    if ($("#DescribeSelfPresentCrpInputCheck").attr("checked")) {
        loadCriticalLink($("#crp-critical-span"), "onClick_CriticalDataCrp();", testTypeCrp);
        openCriticalDataDialog(testTypeCrp, $("#conductedbyCrp"), $("#DescribeSelfPresentCrpInputCheck"), setCriticalDataModel_Crp);
    }
    else {
        unloadCriticalLink($("#crp-critical-span"), testTypeCrp);
    }
}

function setCriticalDataModel_Crp(model, printAfterSave) {
    if (model != null) {
        var testResult = GetCrpData();
        saveSingleTestResult(testResult, model, $("#crp-critical-span"), "onClick_CriticalDataCrp();", SetCrpData, printAfterSave);
    }
}

function getCriticalDataModel_Crp() {
    if ($("#DescribeSelfPresentCrpInputCheck").attr("checked") && criticalDataModel_Crp != null) {
        criticalDataModel_Crp.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_Crp;
    }
    return null;
}
function onClick_PriorityInQueueDataCrp() {
    if ($("#PriorityInQueueTestCrpCheck").attr("checked")) {
        loadPriorityInQueueLink($("#crp-priorityInQueue-span"), "onClick_PriorityInQueueDataCrp();", testTypeCrp);
        openPriorityInQueueTestDialog(testTypeCrp, $("#conductedbyCrp"), $("#PriorityInQueueTestCrpCheck"), setPriorityInQueueDataModel_Crp);
    }
    else {
        unloadPriorityInQueueLink($("#crp-priorityInQueue-span"), testTypeCrp);
    }
}

function setPriorityInQueueDataModel_Crp(model) {
    if (model != null) {
        var testResult = GetCrpData();
        model.TestId = testTypeCrp;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#crp-priorityInQueue-span"), "onClick_PriorityInQueueDataCrp();", SetCrpData);
    }
}