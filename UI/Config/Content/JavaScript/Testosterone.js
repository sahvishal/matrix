function Testosterone(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = {
            "Id": 0, "TestType": testTypeTestosterone,
            "TESTSCRE": null, "TechnicianNotes": '', "ConductedByOrgRoleUserId": '0',
            "UnableScreenReason": new Array(),
            "TestPerformedExternally": null,
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": {
                "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentTestosteroneInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestTestosteroneCheck").attr("checked")
            }
        };
    }
    this.Result = testResult;
}

Testosterone.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (IstestosteroneResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_TestosteronecapturebyChat", testResult.TestPerformedExternally)
        }


        setReading($("#testScretextbox"), testResult.TESTSCRE);

        $("#DescribeSelfPresentTestosteroneInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);

        $("#technotesTestosterone").val(testResult.TechnicianNotes);
        $("#conductedbyTestosterone option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);

        setUnableScreenReason($('.dtl-unabletoscreen-testosterone'), testResult.UnableScreenReason);
        $("#PriorityInQueueTestTestosteroneCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#testosterone-priorityInQueue-span"), "onClick_PriorityInQueueDataTestosterone();", testTypeTestosterone);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#testosterone-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#testosterone-critical-span"), "onClick_CriticalDataTestosterone();", testTypeTestosterone);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#testosterone-critical-span").parent().addClass("red-band");
            }
        }

    },
    getData: function () {
        var testResult = this.Result;
        if (IstestosteroneResultEntryExternaly == 'True') {
             testResult.TestPerformedExternally = getTestPerformedExternally("chk_TestosteronecapturebyChat", testResult.TestPerformedExternally)
        }

        testResult.TESTSCRE = getReading($("#testScretextbox"), testResult.TESTSCRE);
        
        if (currentScreenMode != ScreenMode.Physician) {
            //   testResult.TESTSCRE = getReading($("#testScretextbox"), testResult.TESTSCRE);
            if (currentScreenMode != ScreenMode.CorrectionPostEvaluation && currentScreenMode != ScreenMode.PostAudit) testResult.ResultStatus.StateNumber = $("#ResultStatusInputHidden").val();

            if (testResult.ResultStatus.Id > 0) {
                testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.ResultStatus.DataRecorderMetaData.DateModified = currentDate;
            }
            else {
                testResult.ResultStatus.DataRecorderMetaData = { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate };
            }
        }

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-testosterone')));

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.ConductedByOrgRoleUserId = $("#conductedbyTestosterone option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesTestosterone").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentTestosteroneInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestTestosteroneCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_28").attr("checked");

        if (testResult.ResultStatus.StateNumber < 4) {
            if (testResult.TESTSCRE == null && testResult.TechnicianNotes.length < 1 && testResult.ConductedByOrgRoleUserId == "0" && testResult.UnableScreenReason == null && $("#DescribeSelfPresentTestosteroneInputCheck").attr("checked") == false)
                return null;
        }

        return testResult;
    }
}


var criticalDataModel_Testosterone = null;
function onClick_CriticalDataTestosterone() {
    if ($("#DescribeSelfPresentTestosteroneInputCheck").attr("checked")) {
        loadCriticalLink($("#testosterone-critical-span"), "onClick_CriticalDataTestosterone();", testTypeTestosterone);
        openCriticalDataDialog(testTypeTestosterone, $("#conductedbyTestosterone"), $("#DescribeSelfPresentTestosteroneInputCheck"), setCriticalDataModel_Testosterone);
    }
    else {
        unloadCriticalLink($("#testosterone-critical-span"), testTypeTestosterone);
    }
}

function setCriticalDataModel_Testosterone(model, printAfterSave) {
    if (model != null) {
        var testResult = GetTestosteroneData();
        saveSingleTestResult(testResult, model, $("#testosterone-critical-span"), "onClick_CriticalDataTestosterone();", SetTestosteroneData, printAfterSave);
    }
}

function getCriticalDataModel_Testosterone() {
    if ($("#DescribeSelfPresentTestosteroneInputCheck").attr("checked") && criticalDataModel_Testosterone != null) {
        criticalDataModel_Testosterone.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_Testosterone;
    }
    return null;
}

function onClick_PriorityInQueueDataTestosterone() {
    if ($("#PriorityInQueueTestTestosteroneCheck").attr("checked")) {
        loadPriorityInQueueLink($("#testosterone-priorityInQueue-span"), "onClick_PriorityInQueueDataTestosterone();", testTypeTestosterone);
        openPriorityInQueueTestDialog(testTypeTestosterone, $("#conductedbyTestosterone"), $("#PriorityInQueueTestTestosteroneCheck"), setPriorityInQueueDataModel_Testosterone);
    }
    else {
        unloadPriorityInQueueLink($("#testosterone-priorityInQueue-span"), testTypeTestosterone);
    }
}

function setPriorityInQueueDataModel_Testosterone(model) {
    if (model != null) {
        var testResult = GetTestosteroneData();
        model.TestId = testTypeTestosterone;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#testosterone-priorityInQueue-span"), "onClick_PriorityInQueueDataTestosterone();", SetTestosteroneData);
    }
}