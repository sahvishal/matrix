function HPylori(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = {
            "Id": 0, "TestType": testTypeHPylori,
            "Finding": null,
            "UnableScreenReason": null,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": "0",
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "TestPerformedExternally": null,
            "ResultStatus": {
                "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentHPyloriInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestHPyloriCheck").attr("checked")
            }
        };
    }
    this.Result = testResult;
}

HPylori.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (IshPyloriResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_hpyloricapturebyChat", testResult.TestPerformedExternally)
        }

        if (testResult.Finding != null) {
            setSelectedFinding($(".gv-findings-HPylori"), testResult.Finding.Id);
        }

        setboolTypeReading($('#technicallyltdbutreadableHPyloriinputcheck'), testResult.TechnicallyLimitedbutReadable);
        setboolTypeReading($('#repeatstudyHPyloriinputcheck'), testResult.RepeatStudy);

        setUnableScreenReason($('.dtl-unabletoscreen-HPylori'), testResult.UnableScreenReason);

        $("#DescribeSelfPresentHPyloriInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);
        $("#conductedbyHPylori option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);
        $("#PriorityInQueueTestHPyloriCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#hpylori-priorityInQueue-span"), "onClick_PriorityInQueueDataHPylori();", testTypeHPylori);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#hpylori-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#HPylori-critical-span"), "onClick_CriticalDataHPylori();", testTypeHPylori);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#HPylori-critical-span").parent().addClass("red-band");
                $("#criticalHPylori").attr("checked", "checked");
            }
        }

        $("#technotesHPylori").val(testResult.TechnicianNotes);


        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksHPylori").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpHPylori").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalHPylori").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }
    },
    getData: function () {
        var testResult = this.Result;
        if (IshPyloriResultEntryExternaly == 'True') {
            testResult.TestPerformedExternally = getTestPerformedExternally("chk_hpyloricapturebyChat", testResult.TestPerformedExternally)
        }

        var testFindings = getSelectedFinding($(".gv-findings-HPylori"));
        testResult.Finding = getFindingDataandSynchronized(testResult.Finding, testFindings);

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-HPylori')));

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
        
        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.ConductedByOrgRoleUserId = $("#conductedbyHPylori option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesHPylori").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentHPyloriInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestHPyloriCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_63").attr("checked");

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }


        if (currentScreenMode != ScreenMode.Entry) {
            testResult.TechnicallyLimitedbutReadable = getboolTypeReading($('#technicallyltdbutreadableHPyloriinputcheck'), testResult.TechnicallyLimitedbutReadable);
            testResult.RepeatStudy = getboolTypeReading($('#repeatstudyHPyloriinputcheck'), testResult.RepeatStudy);

            if (testResult.PhysicianInterpretation == null)
                testResult.PhysicianInterpretation = {
                    'Remarks': $("#physicianRemarksHPylori").val(), 'IsCritical': $("#criticalHPylori").attr("checked"), 'FollowUp': $("#followUpHPylori").attr("checked"), 'RecorderMetaData': {
                        'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate
                    }
                };
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksHPylori").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpHPylori").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalHPylori").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }


        if (testResult.ResultStatus.StateNumber < 4) {
            // To Check if no entry has been done
            if (testResult.Fev1 == null && testResult.UnableScreenReason == null && testResult.TechnicianNotes.length < 1
                && testResult.ConductedByOrgRoleUserId == "0" && $("#chkselfHPylori").attr("checked") == false) return null;
        }

        return testResult;
    }
}

var criticalDataModel_HPylori = null;
function onClick_CriticalDataHPylori() {
    if ($("#DescribeSelfPresentHPyloriInputCheck").attr("checked")) {
        loadCriticalLink($("#HPylori-critical-span"), "onClick_CriticalDataHPylori();", testTypeHPylori);
        openCriticalDataDialog(testTypeHPylori, $("#conductedbyHPylori"), $("#DescribeSelfPresentHPyloriInputCheck"), setCriticalDataModel_HPylori);
    }
    else {
        unloadCriticalLink($("#HPylori-critical-span"), testTypeHPylori);
    }
}

function setCriticalDataModel_HPylori(model, printAfterSave) {
    if (model != null) {
        var testResult = GetHPyloriData();
        saveSingleTestResult(testResult, model, $("#HPylori-critical-span"), "onClick_CriticalDataHPylori();", SetHPyloriData, printAfterSave);
    }
}

function getCriticalDataModel_HPylori() {
    if ($("#DescribeSelfPresentHPyloriInputCheck").attr("checked") && criticalDataModel_HPylori != null) {
        criticalDataModel_HPylori.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_HPylori;
    }
    return null;
}
function onClick_PriorityInQueueDataHPylori() {
    if ($("#PriorityInQueueTestHPyloriCheck").attr("checked")) {
        loadPriorityInQueueLink($("#hpylori-priorityInQueue-span"), "onClick_PriorityInQueueDataHPylori();", testTypeHPylori);
        openPriorityInQueueTestDialog(testTypeHPylori, $("#conductedbyHPylori"), $("#PriorityInQueueTestHPyloriCheck"), setPriorityInQueueDataModel_HPylori);
    }
    else {
        unloadPriorityInQueueLink($("#hpylori-priorityInQueue-span"), testTypeHPylori);
    }
}

function setPriorityInQueueDataModel_HPylori(model) {
    if (model != null) {
        var testResult = GetHPyloriData();
        model.TestId = testTypeHPylori;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#hpylori-priorityInQueue-span"), "onClick_PriorityInQueueDataHPylori();", SetHPyloriData);
    }
}
function clearAllHPyloriSelection() {
    $(".gv-findings-HPylori input[type=radio]").attr("checked", false);
}