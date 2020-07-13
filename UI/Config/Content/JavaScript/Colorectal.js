function Colorectal(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = { "Id": 0, "TestType": testTypeColorectal,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": '0',
            "UnableScreenReason": new Array(),
            "TestPerformedExternally": null,
             
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": { "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentColorectalInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestColorectalCheck").attr("checked")
            }
        };
    }
    this.Result = testResult;
}

Colorectal.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (IscolorectalResultEntryExternaly) {
            setTestPerformedExternally("chk_colorectalcapturebyChat", testResult.TestPerformedExternally)
        }
        $("#DescribeSelfPresentColorectalInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);

        $("#technotesColorectal").val(testResult.TechnicianNotes);
        $("#conductedbyColorectal option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);

        $("#PriorityInQueueTestColorectalCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#colorectal-priorityInQueue-span"), "onClick_PriorityInQueueDataColorectal();", testTypeColorectal);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#colorectal-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#colorectal-critical-span"), "onClick_CriticalDataColorectal();", testTypeColorectal);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#colorectal-critical-span").parent().addClass("red-band");
            }
        }
		
        setUnableScreenReason($('.dtl-unabletoscreen-Colorectal'), testResult.UnableScreenReason);

    },
    getData: function () {
        var testResult = this.Result;
       
        if (IscolorectalResultEntryExternaly) {
            testResult.TestPerformedExternally = getTestPerformedExternally("chk_colorectalcapturebyChat", testResult.TestPerformedExternally)
        }

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-Colorectal')));

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.ConductedByOrgRoleUserId = $("#conductedbyColorectal option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesColorectal").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentColorectalInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestColorectalCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_15").attr("checked");

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
            if (testResult.TechnicianNotes.length < 1 && testResult.ConductedByOrgRoleUserId == "0" && testResult.UnableScreenReason == null && $("#DescribeSelfPresentColorectalInputCheck").attr("checked") == false)
                return null;
        }

        return testResult;
    }
}


var criticalDataModel_Colorectal = null;
function onClick_CriticalDataColorectal() {
    if ($("#DescribeSelfPresentColorectalInputCheck").attr("checked")) {
        loadCriticalLink($("#colorectal-critical-span"), "onClick_CriticalDataColorectal();", testTypeColorectal);
        openCriticalDataDialog(testTypeColorectal, $("#conductedbyColorectal"), $("#DescribeSelfPresentColorectalInputCheck"), setCriticalDataModel_Colorectal);
    }
    else {
        unloadCriticalLink($("#colorectal-critical-span"), testTypeColorectal);
    }
}

function setCriticalDataModel_Colorectal(model, printAfterSave) {
    if (model != null) {
        var testResult = GetColorectalData();
        saveSingleTestResult(testResult, model, $("#colorectal-critical-span"), "onClick_CriticalDataColorectal();", SetColorectalData, printAfterSave);
    }
}

function getCriticalDataModel_Colorectal() {
    if ($("#DescribeSelfPresentColorectalInputCheck").attr("checked") && criticalDataModel_Colorectal != null) {
        criticalDataModel_Colorectal.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_Colorectal;
    }
    return null;
}

//colorectal-critical-span
function onClick_PriorityInQueueDataColorectal() {
    if ($("#PriorityInQueueTestColorectalCheck").attr("checked")) {
        loadPriorityInQueueLink($("#colorectal-priorityInQueue-span"), "onClick_PriorityInQueueDataColorectal();", testTypeColorectal);
        openPriorityInQueueTestDialog(testTypeColorectal, $("#conductedbyColorectal"), $("#PriorityInQueueTestColorectalCheck"), setPriorityInQueueDataModel_Colorectal);
    }
    else {
        unloadPriorityInQueueLink($("#colorectal-priorityInQueue-span"), testTypeColorectal);
    }
}

function setPriorityInQueueDataModel_Colorectal(model) {
    if (model != null) {
        var testResult = GetColorectalData();
        model.TestId = testTypeColorectal;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#colorectal-priorityInQueue-span"), "onClick_PriorityInQueueDataColorectal();", SetColorectalData);
    }
}