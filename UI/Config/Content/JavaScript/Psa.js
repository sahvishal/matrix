function Psa(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = { "Id": 0, "TestType": testTypePsa,
            "PSASCR": null, "TechnicianNotes": '', "ConductedByOrgRoleUserId": '0',
            "UnableScreenReason": new Array(),
            "TestPerformedExternally": null,
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": { "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentPsaInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestPsaCheck").attr("checked")
            }
        };
    }
    this.Result = testResult;
}

Psa.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (IspsaResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_psacapturebyChat", testResult.TestPerformedExternally)
        }
        
        setReading($("#psaScrtextbox"), testResult.PSASCR);

        $("#DescribeSelfPresentPsaInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);

        $("#technotesPsa").val(testResult.TechnicianNotes);
        $("#conductedbyPsa option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);

        setUnableScreenReason($('.dtl-unabletoscreen-psa'), testResult.UnableScreenReason);
        $("#PriorityInQueueTestPsaCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#psa-priorityInQueue-span"), "onClick_PriorityInQueueDataPsa();", testTypePsa);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#psa-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#psa-critical-span"), "onClick_CriticalDataPsa();", testTypePsa);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#psa-critical-span").parent().addClass("red-band");
            }
        }
		
    },
    getData: function () {
        var testResult = this.Result;
        if (IspsaResultEntryExternaly == 'True') {
             testResult.TestPerformedExternally = getTestPerformedExternally("chk_psacapturebyChat", testResult.TestPerformedExternally)
        }

        testResult.PSASCR = getReading($("#psaScrtextbox"), testResult.PSASCR);
        
        if (currentScreenMode != ScreenMode.Physician) {
            //testResult.PSASCR = getReading($("#psaScrtextbox"), testResult.PSASCR);
            if (currentScreenMode != ScreenMode.CorrectionPostEvaluation && currentScreenMode != ScreenMode.PostAudit) testResult.ResultStatus.StateNumber = $("#ResultStatusInputHidden").val();

            if (testResult.ResultStatus.Id > 0) {
                testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.ResultStatus.DataRecorderMetaData.DateModified = currentDate;
            }
            else {
                testResult.ResultStatus.DataRecorderMetaData = { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate };
            }
        }

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-psa')));

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.ConductedByOrgRoleUserId = $("#conductedbyPsa option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesPsa").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentPsaInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestPsaCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_20").attr("checked");
        
        if (testResult.ResultStatus.StateNumber < 4) {
            if (testResult.PSASCR == null && testResult.TechnicianNotes.length < 1 && testResult.ConductedByOrgRoleUserId == "0" && testResult.UnableScreenReason == null && $("#DescribeSelfPresentPsaInputCheck").attr("checked") == false)
                return null;
        }

        return testResult;
    }
}


var criticalDataModel_Psa = null;
function onClick_CriticalDataPsa() {
    if ($("#DescribeSelfPresentPsaInputCheck").attr("checked")) {
        loadCriticalLink($("#psa-critical-span"), "onClick_CriticalDataPsa();", testTypePsa);
        openCriticalDataDialog(testTypePsa, $("#conductedbyPsa"), $("#DescribeSelfPresentPsaInputCheck"), setCriticalDataModel_Psa);
    }
    else {
        unloadCriticalLink($("#psa-critical-span"), testTypePsa);
    }
}

function setCriticalDataModel_Psa(model, printAfterSave) {
    if (model != null) {
        var testResult = GetPsaData();
        saveSingleTestResult(testResult, model, $("#psa-critical-span"), "onClick_CriticalDataPsa();", SetPsaData, printAfterSave);
    }
}

function getCriticalDataModel_Psa() {
    if ($("#DescribeSelfPresentPsaInputCheck").attr("checked") && criticalDataModel_Psa != null) {
        criticalDataModel_Psa.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_Psa;
    }
    return null;
}

// psa-critical-span
function onClick_PriorityInQueueDataPsa() {
    if ($("#PriorityInQueueTestPsaCheck").attr("checked")) {
        loadPriorityInQueueLink($("#psa-priorityInQueue-span"), "onClick_PriorityInQueueDataPsa();", testTypePsa);
        openPriorityInQueueTestDialog(testTypePsa, $("#conductedbyPsa"), $("#PriorityInQueueTestPsaCheck"), setPriorityInQueueDataModel_Psa);
    }
    else {
        unloadPriorityInQueueLink($("#psa-priorityInQueue-span"), testTypePsa);
    }
}

function setPriorityInQueueDataModel_Psa(model) {
    if (model != null) {
        var testResult = GetPsaData();
        model.TestId = testTypePsa;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#psa-priorityInQueue-span"), "onClick_PriorityInQueueDataPsa();", SetPsaData);
    }
}