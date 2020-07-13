function QualityMeasures(testResult) {
    if (testResult == null || testResult == 'undefined') {
        testResult = {
            "Id": 0, "TestType": testTypeQualityMeasures,
            "UnableScreenReason": null,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": "0",
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": {
                "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentQualityMeasuresInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestQualityMeasuresCheck").attr("checked")
            },
            "TestPerformedExternally": null
        };
    }
    this.Result = testResult;
}

QualityMeasures.prototype = {
    setData: function () {
        var testResult = this.Result;

        if (isQualityMeasuresResultEntryType == 'True') {
            setTestPerformedExternally("chk_QualityMeasurescapturebyChat", testResult.TestPerformedExternally)
        }


        if (testResult.ClockPass != null && testResult.ClockPass.Reading == true) {
            $("#qualitymeasuresClockPassRbtn").attr("checked", "checked");
        }
        else if (testResult.ClockFail != null && testResult.ClockFail.Reading == true) {
            $("#qualitymeasuresClockFailRbtn").attr("checked", "checked");
        }

        if (testResult.GaitPass != null && testResult.GaitPass.Reading == true) {
            $("#qualitymeasuresGaitPassRbtn").attr("checked", "checked");
        }
        else if (testResult.GaitFail != null && testResult.GaitFail.Reading == true) {
            $("#qualitymeasuresGaitFailRbtn").attr("checked", "checked");
        }

        setReading($('#MemoryRecallScore'), testResult.MemoryRecallScore);

        SetDropdownListReading(".ddl-functional-assessment select", testResult.FunctionalAssessmentScore);
        SetDropdownListReading(".ddl-pain-assessment select", testResult.PainAssessmentScore);

        setboolTypeReading($('#technicallyltdbutreadableQualityMeasuresinputcheck'), testResult.TechnicallyLimitedbutReadable);
        setboolTypeReading($('#repeatstudyQualityMeasuresinputcheck'), testResult.RepeatStudy);

        setUnableScreenReason($('.dtl-unabletoscreen-QualityMeasures'), testResult.UnableScreenReason);

        setTestNotPerformedReasonForQualityMeasures(testResult.TestNotPerformed);

        $("#DescribeSelfPresentQualityMeasuresInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);
        $("#conductedbyQualityMeasures option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);
        $("#PriorityInQueueTestQualityMeasuresCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#QualityMeasures-priorityInQueue-span"), "onClick_PriorityInQueueDataQualityMeasures();", testTypeQualityMeasures);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#QualityMeasures-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#QualityMeasures-critical-span"), "onClick_CriticalDataQualityMeasures();", testTypeQualityMeasures);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#QualityMeasures-critical-span").parent().addClass("red-band");
                $("#criticalQualityMeasures").attr("checked", "checked");
            }
        }

        $("#technotesQualityMeasures").val(testResult.TechnicianNotes);


        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksQualityMeasures").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpQualityMeasures").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalQualityMeasures").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }
    },
    getData: function () {
        var testResult = this.Result;
        if (isQualityMeasuresResultEntryType == 'True') {
            testResult.TestPerformedExternally = getTestPerformedExternally("chk_QualityMeasurescapturebyChat", testResult.TestPerformedExternally)
        }

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-QualityMeasures')));

        testResult.TestNotPerformed = getTestNotPerformedReasonForQualityMeasures(testResult.TestNotPerformed);

        testResult.ClockPass = getboolTypeReadingRadioButton($(".ClockPass"), testResult.ClockPass);
        testResult.ClockFail = getboolTypeReadingRadioButton($(".ClockFail"), testResult.ClockFail);
        testResult.GaitPass = getboolTypeReadingRadioButton($(".GaitPass"), testResult.GaitPass);
        testResult.GaitFail = getboolTypeReadingRadioButton($(".GaitFail"), testResult.GaitFail);
        testResult.MemoryRecallScore = getReading($('#MemoryRecallScore'), testResult.MemoryRecallScore);

        testResult.FunctionalAssessmentScore = getFindingDataandSynchronized(testResult.FunctionalAssessmentScore, GetDropdownListReading(".ddl-functional-assessment select"));
        testResult.PainAssessmentScore = getFindingDataandSynchronized(testResult.PainAssessmentScore, GetDropdownListReading(".ddl-pain-assessment select"));


        if (currentScreenMode != ScreenMode.Physician) {

            //testResult.ClockPass = getboolTypeReadingRadioButton($(".ClockPass"), testResult.ClockPass);
            //testResult.ClockFail = getboolTypeReadingRadioButton($(".ClockFail"), testResult.ClockFail);
            //testResult.GaitPass = getboolTypeReadingRadioButton($(".GaitPass"), testResult.GaitPass);
            //testResult.GaitFail = getboolTypeReadingRadioButton($(".GaitFail"), testResult.GaitFail);
            //testResult.MemoryRecallScore = getReading($('#MemoryRecallScore'), testResult.MemoryRecallScore);


            //testResult.FunctionalAssessmentScore = getFindingDataandSynchronized(testResult.FunctionalAssessmentScore, GetDropdownListReading(".ddl-functional-assessment select"));
            //testResult.PainAssessmentScore = getFindingDataandSynchronized(testResult.PainAssessmentScore, GetDropdownListReading(".ddl-pain-assessment select"));

            if (currentScreenMode != ScreenMode.CorrectionPostEvaluation && currentScreenMode != ScreenMode.PostAudit) testResult.ResultStatus.StateNumber = $("#ResultStatusInputHidden").val();

            if (testResult.ResultStatus.Id > 0) {
                testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.ResultStatus.DataRecorderMetaData.DateModified = currentDate;
            }
            else {
                testResult.ResultStatus.DataRecorderMetaData = { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate };
            }
        }

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.ConductedByOrgRoleUserId = $("#conductedbyQualityMeasures option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesQualityMeasures").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentQualityMeasuresInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestQualityMeasuresCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_84").attr("checked");

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }


        if (currentScreenMode != ScreenMode.Entry) {
            testResult.TechnicallyLimitedbutReadable = getboolTypeReading($('#technicallyltdbutreadableQualityMeasuresinputcheck'), testResult.TechnicallyLimitedbutReadable);
            testResult.RepeatStudy = getboolTypeReading($('#repeatstudyQualityMeasuresinputcheck'), testResult.RepeatStudy);

            if (testResult.PhysicianInterpretation == null)
                testResult.PhysicianInterpretation = {
                    'Remarks': $("#physicianRemarksQualityMeasures").val(), 'IsCritical': $("#criticalQualityMeasures").attr("checked"), 'FollowUp': $("#followUpQualityMeasures").attr("checked"), 'RecorderMetaData': {
                        'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate
                    }
                };
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksQualityMeasures").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpQualityMeasures").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalQualityMeasures").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }


        if (testResult.ResultStatus.StateNumber < 4) {
            // To Check if no entry has been done
            if (testResult.Fev1 == null && testResult.UnableScreenReason == null && testResult.TechnicianNotes.length < 1
                && testResult.ConductedByOrgRoleUserId == "0" && $("#chkselfQualityMeasures").attr("checked") == false) return null;
        }

        return testResult;
    }
}

var criticalDataModel_QualityMeasures = null;
function onClick_CriticalDataQualityMeasures() {
    if ($("#DescribeSelfPresentQualityMeasuresInputCheck").attr("checked")) {
        loadCriticalLink($("#QualityMeasures-critical-span"), "onClick_CriticalDataQualityMeasures();", testTypeQualityMeasures);
        openCriticalDataDialog(testTypeQualityMeasures, $("#conductedbyQualityMeasures"), $("#DescribeSelfPresentQualityMeasuresInputCheck"), setCriticalDataModel_QualityMeasures);
    }
    else {
        unloadCriticalLink($("#QualityMeasures-critical-span"), testTypeQualityMeasures);
    }
}

function setCriticalDataModel_QualityMeasures(model, printAfterSave) {
    if (model != null) {
        var testResult = GetQualityMeasuresData();
        saveSingleTestResult(testResult, model, $("#QualityMeasures-critical-span"), "onClick_CriticalDataQualityMeasures();", SetQualityMeasuresData, printAfterSave);
    }
}

function getCriticalDataModel_QualityMeasures() {
    if ($("#DescribeSelfPresentQualityMeasuresInputCheck").attr("checked") && criticalDataModel_QualityMeasures != null) {
        criticalDataModel_QualityMeasures.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_QualityMeasures;
    }
    return null;
}
function onClick_PriorityInQueueDataQualityMeasures() {
    if ($("#PriorityInQueueTestQualityMeasuresCheck").attr("checked")) {
        loadPriorityInQueueLink($("#QualityMeasures-priorityInQueue-span"), "onClick_PriorityInQueueDataQualityMeasures();", testTypeQualityMeasures);
        openPriorityInQueueTestDialog(testTypeQualityMeasures, $("#conductedbyQualityMeasures"), $("#PriorityInQueueTestQualityMeasuresCheck"), setPriorityInQueueDataModel_QualityMeasures);
    }
    else {
        unloadPriorityInQueueLink($("#QualityMeasures-priorityInQueue-span"), testTypeQualityMeasures);
    }
}

function setPriorityInQueueDataModel_QualityMeasures(model) {
    if (model != null) {
        var testResult = GetQualityMeasuresData();
        model.TestId = testTypeQualityMeasures;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#QualityMeasures-priorityInQueue-span"), "onClick_PriorityInQueueDataQualityMeasures();", SetQualityMeasuresData);
    }
}
function clearAllQualityMeasuresSelection() {
    $(".ddl-functional-assessment select").val(-1);
    $(".ddl-pain-assessment select").val(-1);

    $("input[type='radio'][name='clock']").attr("checked", false);
    $("input[type='radio'][name='Gait']").attr("checked", false);
    $("#MemoryRecallScore").val('');
}


function setTestNotPerformedReasonForQualityMeasures(testNotPerformed) {
    setTestNotPerformed("testnotPerformedQualityMeasures", testNotPerformed);
    SetTestNotPerformedEnableDisabled("testnotPerformedQualityMeasures");
}

function getTestNotPerformedReasonForQualityMeasures(testNotPerformed) {
    return getTestNotPerformed("testnotPerformedQualityMeasures", testNotPerformed);
}