function DiabeticNeuropathy(object) {
    if (object == null || object == undefined) {
        object = {
            "Id": 0, "TestType": testTypeDiabeticNeuropathy,
            "Amplitude": null, "Finding": null, "ConductionVelocity": null, "RightLeg": null, "LeftLeg": null,
            "UnableScreenReason": new Array(),
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": '',
            "ResultImages": null,
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": {
                "Id": 0,
                "SelfPresent": false,
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestDiabeticNeuropathyCheck").attr("checked")
            },
            "TestPerformedExternally": null
        };
    }

    this.Result = object;
}

DiabeticNeuropathy.prototype = {
    setData: function() {
        var testResult = this.Result;
        if (isDiabeticNeuropathyResultentrytype == 'True') {
            setTestPerformedExternally("chk_DiabeticNeuropathycapturebyChat", testResult.TestPerformedExternally)
        }
        if (testResult.Finding != null) {
            setSelectedFinding($(".gv-findings-DiabeticNeuropathy"), testResult.Finding.Id);
        }

        setReading($("#AmplitudeInputText"), testResult.Amplitude);
        setReading($("#ConductionVelocityTextbox"), testResult.ConductionVelocity);

        setboolTypeReading($("#RightLegCheckbox"), testResult.RightLeg);
        setboolTypeReading($("#LeftLegCheckbox"), testResult.LeftLeg);


        setboolTypeReading($('#technicallyltdbutreadableDiabeticNeuropathyinputcheck'), testResult.TechnicallyLimitedbutReadable);
        setboolTypeReading($('#repeatstudyDiabeticNeuropathyinputcheck'), testResult.RepeatStudy);


        setUnableScreenReason($('.dtl-unabletoscreen-DiabeticNeuropathy'), testResult.UnableScreenReason);

        setTestNotPerformedReasonForDiabeticNeuropathy(testResult.TestNotPerformed);

        $("#DescribeSelfPresentDiabeticNeuropathyInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);
        $("#PriorityInQueueTestDiabeticNeuropathyCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#DiabeticNeuropathy-priorityInQueue-span"), "onClick_PriorityInQueueDataDiabeticNeuropathy();", testTypeDiabeticNeuropathy);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#DiabeticNeuropathy-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#DiabeticNeuropathy-critical-span"), "onClick_CriticalDataDiabeticNeuropathy();", testTypeDiabeticNeuropathy);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#DiabeticNeuropathy-critical-span").parent().addClass("red-band");
                $("#criticalDiabeticNeuropathy").attr("checked", "checked");
            }
        }

        $("#technotesDiabeticNeuropathy").val(testResult.TechnicianNotes);
        $("#conductedbyDiabeticNeuropathy option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);


        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksDiabeticNeuropathy").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpDiabeticNeuropathy").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalDiabeticNeuropathy").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }

    },
    getData: function() {
        
        var testResult = this.Result;

        if (isDiabeticNeuropathyResultentrytype == 'True') {
            testResult.TestPerformedExternally = getTestPerformedExternally("chk_DiabeticNeuropathycapturebyChat", testResult.TestPerformedExternally)
        }
        var testFindings = getSelectedFinding($(".gv-findings-DiabeticNeuropathy"));
        testResult.Finding = getFindingDataandSynchronized(testResult.Finding, testFindings);

        testResult.RightLeg = getboolTypeReading($("#RightLegCheckbox"), testResult.RightLeg);
        testResult.LeftLeg = getboolTypeReading($("#LeftLegCheckbox"), testResult.LeftLeg);

        testResult.TechnicallyLimitedbutReadable = getboolTypeReading($('#technicallyltdbutreadableDiabeticNeuropathyinputcheck'), testResult.TechnicallyLimitedbutReadable);

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-DiabeticNeuropathy')));

        testResult.TestNotPerformed = getTestNotPerformedReasonForDiabeticNeuropathy(testResult.TestNotPerformed);

        testResult.Amplitude = getReading($("#AmplitudeInputText"), testResult.Amplitude);
        testResult.ConductionVelocity = getReading($("#ConductionVelocityTextbox"), testResult.ConductionVelocity);

        if (currentScreenMode != ScreenMode.Physician) {

            if (currentScreenMode != ScreenMode.CorrectionPostEvaluation && currentScreenMode != ScreenMode.PostAudit) testResult.ResultStatus.StateNumber = $("#ResultStatusInputHidden").val();

            if (testResult.ResultStatus.Id > 0) {
                testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.ResultStatus.DataRecorderMetaData.DateModified = currentDate;
            } else {
                testResult.ResultStatus.DataRecorderMetaData = { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate };
            }

        }

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.ConductedByOrgRoleUserId = $("#conductedbyDiabeticNeuropathy option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesDiabeticNeuropathy").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentDiabeticNeuropathyInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestDiabeticNeuropathyCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_70").attr("checked");

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }

        if (currentScreenMode != ScreenMode.Entry) {

            testResult.RepeatStudy = getboolTypeReading($('#repeatstudyDiabeticNeuropathyinputcheck'), testResult.RepeatStudy);

            if (testResult.PhysicianInterpretation == null)
                testResult.PhysicianInterpretation = {
                    'Remarks': $("#physicianRemarksDiabeticNeuropathy").val(),
                    'IsCritical': $("#criticalDiabeticNeuropathy").attr("checked"),
                    'FollowUp': $("#followUpDiabeticNeuropathy").attr("checked"),
                    'RecorderMetaData': {
                        'DataRecorderCreator': { 'Id': currentUser },
                        'DateCreated': currentDate
                    }
                };
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksDiabeticNeuropathy").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpDiabeticNeuropathy").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalDiabeticNeuropathy").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }

        if (testResult.ResultStatus.StateNumber < 4) {
            if (testResult.Amplitude == null && testResult.Finding == null && testResult.ConductionVelocity == null
                && (testResult.RightLeg == null || testResult.RightLeg.Reading == false) && (testResult.LeftLeg == null || testResult.LeftLeg.Reading == false)
                && testResult.TechnicianNotes.length < 1 && testResult.ConductedByOrgRoleUserId == "0" &&
                testResult.UnableScreenReason == null && $("#DescribeSelfPresentDiabeticNeuropathyInputCheck").attr("checked") == false)
                return null;
        }

        return testResult;
    }
};


var criticalDataModel_DiabeticNeuropathy = null;
function onClick_CriticalDataDiabeticNeuropathy() {
    if ($("#DescribeSelfPresentDiabeticNeuropathyInputCheck").attr("checked")) {
        loadCriticalLink($("#DiabeticNeuropathy-critical-span"), "onClick_CriticalDataDiabeticNeuropathy();", testTypeDiabeticNeuropathy);
        openCriticalDataDialog(testTypeDiabeticNeuropathy, $("#conductedbyDiabeticNeuropathy"), $("#DescribeSelfPresentDiabeticNeuropathyInputCheck"), setCriticalDataModel_DiabeticNeuropathy);
    }
    else {
        unloadCriticalLink($("#DiabeticNeuropathy-critical-span"), testTypeDiabeticNeuropathy);
    }
}

function setCriticalDataModel_DiabeticNeuropathy(model, printAfterSave) {
    if (model != null) {
        var testResult = GetDiabeticNeuropathyData();
        saveSingleTestResult(testResult, model, $("#DiabeticNeuropathy-critical-span"), "onClick_CriticalDataDiabeticNeuropathy();", SetDiabeticNeuropathyData, printAfterSave);
    }
}

function getCriticalDataModel_DiabeticNeuropathy() {
    if ($("#DescribeSelfPresentDiabeticNeuropathyInputCheck").attr("checked") && criticalDataModel_DiabeticNeuropathy != null) {
        criticalDataModel_DiabeticNeuropathy.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_DiabeticNeuropathy;
    }
    return null;
}

function onClick_PriorityInQueueDataDiabeticNeuropathy() {
    if ($("#PriorityInQueueTestDiabeticNeuropathyCheck").attr("checked")) {
        loadPriorityInQueueLink($("#DiabeticNeuropathy-priorityInQueue-span"), "onClick_PriorityInQueueDataDiabeticNeuropathy();", testTypeDiabeticNeuropathy);
        openPriorityInQueueTestDialog(testTypeDiabeticNeuropathy, $("#conductedbyDiabeticNeuropathy"), $("#PriorityInQueueTestDiabeticNeuropathyCheck"), setPriorityInQueueDataModel_DiabeticNeuropathy);
    }
    else {
        unloadPriorityInQueueLink($("#DiabeticNeuropathy-priorityInQueue-span"), testTypeDiabeticNeuropathy);
    }
}

function setPriorityInQueueDataModel_DiabeticNeuropathy(model) {
    if (model != null) {
        var testResult = GetDiabeticNeuropathyData();
        model.TestId = testTypeDiabeticNeuropathy;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#DiabeticNeuropathy-priorityInQueue-span"), "onClick_PriorityInQueueDataDiabeticNeuropathy();", SetDiabeticNeuropathyData);
    }
}

function clearAllDiabeticNeuropathySelection() {
    $(".gv-findings-DiabeticNeuropathy input[type=radio]").attr("checked", false);
    $("#RightLegCheckbox, #LeftLegCheckbox").attr("checked", false);
}

function setTestNotPerformedReasonForDiabeticNeuropathy(testNotPerformed) {
    setTestNotPerformed("testnotPerformedDiabeticNeuropathy", testNotPerformed);
    SetTestNotPerformedEnableDisabled("testnotPerformedDiabeticNeuropathy");
}

function getTestNotPerformedReasonForDiabeticNeuropathy(testNotPerformed) {
    return getTestNotPerformed("testnotPerformedDiabeticNeuropathy", testNotPerformed);
}