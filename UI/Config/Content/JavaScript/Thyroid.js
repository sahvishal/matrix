function Thyroid(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = { "Id": 0, "TestType": testTypeThyroid,
            "TSHSCR": null, "TechnicianNotes": '', "ConductedByOrgRoleUserId": '0',
            "UnableScreenReason": new Array(),
            "TestPerformedExternally": null,
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": { "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentThyroidInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestThyroidCheck").attr("checked")
            }
        };
    }
    this.Result = testResult;
}

Thyroid.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (IsthyroidResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_thyroidcapturebyChat", testResult.TestPerformedExternally)
        }
        
        setReading($("#tshScrtextbox"), testResult.TSHSCR);
        
        $("#DescribeSelfPresentThyroidInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);

        $("#technotesthyroid").val(testResult.TechnicianNotes);
        $("#conductedbythyroid option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);

        setUnableScreenReason($('.dtl-unabletoscreen-thyroid'), testResult.UnableScreenReason);
        $("#PriorityInQueueTestThyroidCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#thyroid-priorityInQueue-span"), "onClick_PriorityInQueueDataThyroid();", testTypeThyroid);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#thyroid-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#thyroid-critical-span"), "onClick_CriticalDataThyroid();", testTypeThyroid);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#thyroid-critical-span").parent().addClass("red-band");
            }
        }
		
    },
    getData: function () {
        var testResult = this.Result;
        if (IsthyroidResultEntryExternaly == 'True') {
             testResult.TestPerformedExternally = getTestPerformedExternally("chk_thyroidcapturebyChat", testResult.TestPerformedExternally)
        }

        testResult.TSHSCR = getReading($("#tshScrtextbox"), testResult.TSHSCR);
        if (currentScreenMode != ScreenMode.Physician) {
            //testResult.TSHSCR = getReading($("#tshScrtextbox"), testResult.TSHSCR);
            if (currentScreenMode != ScreenMode.CorrectionPostEvaluation && currentScreenMode != ScreenMode.PostAudit) testResult.ResultStatus.StateNumber = $("#ResultStatusInputHidden").val();

            if (testResult.ResultStatus.Id > 0) {
                testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.ResultStatus.DataRecorderMetaData.DateModified = currentDate;
            }
            else {
                testResult.ResultStatus.DataRecorderMetaData = { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate };
            }
        }

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-thyroid')));

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.ConductedByOrgRoleUserId = $("#conductedbythyroid option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesthyroid").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentThyroidInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestThyroidCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_5").attr("checked");

        if (testResult.ResultStatus.StateNumber < 4) {
            if (testResult.TSHSCR == null && testResult.TechnicianNotes.length < 1 && testResult.ConductedByOrgRoleUserId == "0" && testResult.UnableScreenReason == null && $("#DescribeSelfPresentThyroidInputCheck").attr("checked") == false)
                return null;
        }

        return testResult;
    }
}


var criticalDataModel_Thyroid = null;
function onClick_CriticalDataThyroid() {
    if ($("#DescribeSelfPresentThyroidInputCheck").attr("checked")) {
        loadCriticalLink($("#thyroid-critical-span"), "onClick_CriticalDataThyroid();", testTypeThyroid);
        openCriticalDataDialog(testTypeThyroid, $("#conductedbythyroid"), $("#DescribeSelfPresentThyroidInputCheck"), setCriticalDataModel_Thyroid);
    }
    else {
        unloadCriticalLink($("#thyroid-critical-span"), testTypeThyroid);
    }
}

function setCriticalDataModel_Thyroid(model, printAfterSave) {
    if (model != null) {
        var testResult = GetThyroidData();
        saveSingleTestResult(testResult, model, $("#thyroid-critical-span"), "onClick_CriticalDataThyroid();", SetThyroidData, printAfterSave);
    }
}

function getCriticalDataModel_Thyroid() {
    if ($("#DescribeSelfPresentThyroidInputCheck").attr("checked") && criticalDataModel_Thyroid != null) {
        criticalDataModel_Thyroid.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_Thyroid;
    }
    return null;
}

//thyroid-critical-span

function onClick_PriorityInQueueDataThyroid() {
    if ($("#PriorityInQueueTestThyroidCheck").attr("checked")) {
        loadPriorityInQueueLink($("#thyroid-priorityInQueue-span"), "onClick_PriorityInQueueDataThyroid();", testTypeThyroid);
        openPriorityInQueueTestDialog(testTypeThyroid, $("#conductedbythyroid"), $("#PriorityInQueueTestThyroidCheck"), setPriorityInQueueDataModel_Thyroid);
    }
    else {
        unloadPriorityInQueueLink($("#thyroid-priorityInQueue-span"), testTypeThyroid);
    }
}

function setPriorityInQueueDataModel_Thyroid(model) {
    if (model != null) {
        var testResult = GetThyroidData();
        model.TestId = testTypeThyroid;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#thyroid-priorityInQueue-span"), "onClick_PriorityInQueueDataThyroid();", SetThyroidData);
    }
}