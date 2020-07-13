function Kyn(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = { "Id": 0, "TestType": testTypeKyn,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": '0',
            "UnableScreenReason": new Array(),
            "TestPerformedExternally": null,
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": { "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentKYNInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestKynCheck").attr("checked")
            }
        };
    }
    this.Result = testResult;
}

Kyn.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (IskynResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_kyncapturebyChat", testResult.TestPerformedExternally)
        }

        $("#DescribeSelfPresentKYNInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);

        $("#technotesKYN").val(testResult.TechnicianNotes);
        $("#conductedbyKYN option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);

        setUnableScreenReason($('.dtl-unabletoscreen-KYN'), testResult.UnableScreenReason);

        $("#PriorityInQueueTestKynCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#kyn-priorityInQueue-span"), "onClick_PriorityInQueueDataKyn();", testTypeKyn);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#kyn-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#kyn-critical-span"), "onClick_CriticalDataKyn();", testTypeKyn);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#kyn-critical-span").parent().addClass("red-band");
            }
        }
    },
    getData: function () {
        var testResult = this.Result;
     
        if (IskynResultEntryExternaly == 'True') {
            testResult.TestPerformedExternally = getTestPerformedExternally("chk_kyncapturebyChat", testResult.TestPerformedExternally)
        }

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-KYN')));

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.ConductedByOrgRoleUserId = $("#conductedbyKYN option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesKYN").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentKYNInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestKynCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_23").attr("checked");

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
            if (testResult.TechnicianNotes.length < 1 && testResult.ConductedByOrgRoleUserId == "0" && testResult.UnableScreenReason == null && $("#DescribeSelfPresentKYNInputCheck").attr("checked") == false)
                return null;
        }

        return testResult;
    }
}


var criticalDataModel_Kyn = null;
function onClick_CriticalDataKyn() {
    if ($("#DescribeSelfPresentKYNInputCheck").attr("checked")) {
        loadCriticalLink($("#kyn-critical-span"), "onClick_CriticalDataKyn();", testTypeKyn);
        openCriticalDataDialog(testTypeKyn, $("#conductedbyKYN"), $("#DescribeSelfPresentKYNInputCheck"), setCriticalDataModel_Kyn);
    }
    else {
        unloadCriticalLink($("#kyn-critical-span"), testTypeKyn);
    }
}

function setCriticalDataModel_Kyn(model, printAfterSave) {
    if (model != null) {
        var testResult = GetKynData();
        saveSingleTestResult(testResult, model, $("#kyn-critical-span"), "onClick_CriticalDataKyn();", SetKynData, printAfterSave);
    }
}

function getCriticalDataModel_Kyn() {
    if ($("#DescribeSelfPresentKYNInputCheck").attr("checked") && criticalDataModel_Kyn != null) {
        criticalDataModel_Kyn.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_Kyn;
    }
    return null;
}

//
function onClick_PriorityInQueueDataKyn() {
    if ($("#PriorityInQueueTestKynCheck").attr("checked")) {
        loadPriorityInQueueLink($("#kyn-priorityInQueue-span"), "onClick_PriorityInQueueDataKyn();", testTypeKyn);
        openPriorityInQueueTestDialog(testTypeKyn, $("#conductedbyKYN"), $("#PriorityInQueueTestKynCheck"), setPriorityInQueueDataModel_Kyn);
    }
    else {
        unloadPriorityInQueueLink($("#kyn-priorityInQueue-span"), testTypeKyn);
    }
}

function setPriorityInQueueDataModel_Kyn(model) {
    if (model != null) {
        var testResult = GetKynData();
        model.TestId = testTypeKyn;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#kyn-priorityInQueue-span"), "onClick_PriorityInQueueDataKyn();", SetKynData);
    }
}