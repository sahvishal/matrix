function Hkyn(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = { "Id": 0, "TestType": testTypeHkyn,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": '0',
            "UnableScreenReason": new Array(),
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": { "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentHKYNInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestHkynCheck").attr("checked")
            },
            "TestPerformedExternally": null
        };
    }
    this.Result = testResult;
}

Hkyn.prototype = {
    setData: function () {
        var testResult = this.Result;

        if (isHKYNResultEntryType == 'True') {
            setTestPerformedExternally("chk_hkyncapturebyChat", testResult.TestPerformedExternally)
        }
        $("#DescribeSelfPresentHKYNInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);

        $("#technotesHKYN").val(testResult.TechnicianNotes);
        $("#conductedbyHKYN option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);

        setUnableScreenReason($('.dtl-unabletoscreen-HKYN'), testResult.UnableScreenReason);

        $("#PriorityInQueueTestHkynCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#hkyn-priorityInQueue-span"), "onClick_PriorityInQueueDataHkyn();", testTypeHkyn);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#hkyn-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#hkyn-critical-span"), "onClick_CriticalDataHkyn();", testTypeHkyn);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#hkyn-critical-span").parent().addClass("red-band");
            }
        }
    },
    getData: function () {
        var testResult = this.Result;

        if (isHKYNResultEntryType == 'True') {
            testResult.TestPerformedExternally = getTestPerformedExternally("chk_hkyncapturebyChat", testResult.TestPerformedExternally)
        }

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-HKYN')));

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.ConductedByOrgRoleUserId = $("#conductedbyHKYN option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesHKYN").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentHKYNInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestHkynCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_98").attr("checked");

        if (currentScreenMode != ScreenMode.Physician) {

            if (currentScreenMode != ScreenMode.CorrectionPostEvaluation) testResult.ResultStatus.StateNumber = $("#ResultStatusInputHidden").val();

            if (testResult.ResultStatus.Id > 0) {
                testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.ResultStatus.DataRecorderMetaData.DateModified = currentDate;
            }
            else {
                testResult.ResultStatus.DataRecorderMetaData = { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate };
            }
        }

        if (testResult.ResultStatus.StateNumber < 4) {
            if (testResult.TechnicianNotes.length < 1 && testResult.ConductedByOrgRoleUserId == "0" && testResult.UnableScreenReason == null && $("#DescribeSelfPresentHKYNInputCheck").attr("checked") == false)
                return null;
        }

        return testResult;
    }
}


var criticalDataModel_Hkyn = null;
function onClick_CriticalDataHkyn() {
    if ($("#DescribeSelfPresentHKYNInputCheck").attr("checked")) {
        loadCriticalLink($("#hkyn-critical-span"), "onClick_CriticalDataHkyn();", testTypeHkyn);
        openCriticalDataDialog(testTypeHkyn, $("#conductedbyHKYN"), $("#DescribeSelfPresentHKYNInputCheck"), setCriticalDataModel_Hkyn);
    }
    else {
        unloadCriticalLink($("#hkyn-critical-span"), testTypeHkyn);
    }
}

function setCriticalDataModel_Hkyn(model, printAfterSave) {
    if (model != null) {
        var testResult = GetHkynData();
        saveSingleTestResult(testResult, model, $("#hkyn-critical-span"), "onClick_CriticalDataHkyn();", SetHkynData, printAfterSave);
    }
}

function getCriticalDataModel_Hkyn() {
    if ($("#DescribeSelfPresentKYNInputCheck").attr("checked") && criticalDataModel_Hkyn != null) {
        criticalDataModel_Hkyn.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_Hkyn;
    }
    return null;
}

//
function onClick_PriorityInQueueDataHkyn() {
    if ($("#PriorityInQueueTestHkynCheck").attr("checked")) {
        loadPriorityInQueueLink($("#hkyn-priorityInQueue-span"), "onClick_PriorityInQueueDataHkyn();", testTypeHkyn);
        openPriorityInQueueTestDialog(testTypeHkyn, $("#conductedbyHKYN"), $("#PriorityInQueueTestHkynCheck"), setPriorityInQueueDataModel_Hkyn);
    }
    else {
        unloadPriorityInQueueLink($("#hkyn-priorityInQueue-span"), testTypeHkyn);
    }
}

function setPriorityInQueueDataModel_Hkyn(model) {
    if (model != null) {
        var testResult = GetHkynData();
        model.TestId = testTypeHkyn;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#hkyn-priorityInQueue-span"), "onClick_PriorityInQueueDataHkyn();", SetHkynData);
    }
}