function AwvAaa(object) {
    
    if (object == null || object == undefined) {
        object = {
            "Id": 0, "TestType": testTypeAwvAaa, "AortaSize": null, "Finding": null, "AorticDissection": null, "Plaque": null, "Thrombus": null,
            "TransverseView": { "FirstValue": null, "SecondValue": null }, "PeakSystolicVelocity": null,
            "AortaRangeTransverseView": new Array(), "AortaRangeSaggitalView": new Array(), "UnableScreenReason": new Array(),
            "IncidentalFindings": new Array(),
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": '',
            "ResultImages": null,
            "TestPerformedExternally": null,
             
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": {
                "Id": 0,
                "SelfPresent": false,
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestAwvAaaCheck").attr("checked")
            }
        };
    }

    this.Result = object;
}

AwvAaa.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (IsAwvAaaResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_AwvAaacapturebyChat", testResult.TestPerformedExternally)
        }

        if (testResult.Finding != null) {
            setSelectedFinding($(".gv-Findings-AwvAaa"), testResult.Finding.Id);
        }
        
        setReading($("#AwvAaaAortaSizeInputText"), testResult.AortaSize);
        setReading($("#AwvAaaPeakSystolicVelocityInputText"), testResult.PeakSystolicVelocity);

        if (testResult.TransverseView != null) {
            setReading($("#AwvAaaTVDatapointOneTextbox"), testResult.TransverseView.FirstValue);
            setReading($("#AwvAaaTVDatapointTwoTextbox"), testResult.TransverseView.SecondValue);
        }

        if (testResult.ResidualLumenStandardFindings != null) {
            setReading($("#AwvAaaResidualLumenTVDatapointOneTextbox"), testResult.ResidualLumenStandardFindings.FirstValue);
            setReading($("#AwvAaaResidualLumenTVDatapointTwoTextbox"), testResult.ResidualLumenStandardFindings.SecondValue);
        }

        setboolTypeReading($("#AwvAaaAorticDissectionCheckbox"), testResult.AorticDissection);
        setboolTypeReading($("#AwvAaaPlaqueCheckbox"), testResult.Plaque);
        setboolTypeReading($("#AwvAaaThrombusCheckbox"), testResult.Thrombus);
        setboolTypeReading($('#technicallyltdbutreadableAwvAaainputcheck'), testResult.TechnicallyLimitedbutReadable);
        setboolTypeReading($('#repeatstudyAwvAaainputcheck'), testResult.RepeatStudy);

        setMultipleFindingDatalist($(".dtl-sagitalview-finding-AwvAaa"), testResult.AortaRangeSaggitalView);
        setMultipleFindingDatalist($(".dtl-transverseview-finding-AwvAaa"), testResult.AortaRangeTransverseView);
        setMultipleFindingDatalist($(".dtl-peakSystolicVelocity-finding-AwvAaa"), testResult.PeakSystolicVelocityStandardFindings);

        setUnableScreenReason($('.dtl-unabletoscreen-AwvAaa'), testResult.UnableScreenReason);
        
        setTestNotPerformedReasonForAwvAaa(testResult.TestNotPerformed);

        $("#DescribeSelfPresentAwvAaaInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);
        $("#PriorityInQueueTestAwvAaaCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#AwvAaa-priorityInQueue-span"), "onClick_PriorityInQueueDataAwvAaa();", testTypeAwvAaa);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#AwvAaa-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#AwvAaa-critical-span"), "onClick_CriticalDataAwvAaa();", testTypeAwvAaa);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#AwvAaa-critical-span").parent().addClass("red-band");
                $("#criticalAwvAaa").attr("checked", "checked");
            }
        }

        if (testResult.ResultImages && testResult.ResultImages.length > 0) {
            LoadNewImagesAwvAaa(testResult.ResultImages, true);
        }

        $("#technotesAwvAaa").val(testResult.TechnicianNotes);
        $("#conductedbyAwvAaa option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);

        if (testResult.IncidentalFindings != null && testResult.IncidentalFindings.length > 0)
            setSelectedIncidentalFinding($('.dtl-AwvAaa-if'), testResult.IncidentalFindings);

        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksAwvAaa").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpAwvAaa").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalAwvAaa").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }
    },
    getData: function () {
        var testResult = this.Result;
        if (IsAwvAaaResultEntryExternaly == 'True') {
             testResult.TestPerformedExternally = getTestPerformedExternally("chk_AwvAaacapturebyChat", testResult.TestPerformedExternally)
        }

        var testFindings = getSelectedFinding($(".gv-Findings-AwvAaa"));
        testResult.Finding = getFindingDataandSynchronized(testResult.Finding, testFindings);

        testResult.AorticDissection = getboolTypeReading($("#AwvAaaAorticDissectionCheckbox"), testResult.AorticDissection);
        testResult.Plaque = getboolTypeReading($("#AwvAaaPlaqueCheckbox"), testResult.Plaque);
        testResult.Thrombus = getboolTypeReading($("#AwvAaaThrombusCheckbox"), testResult.Thrombus);
        testResult.TechnicallyLimitedbutReadable = getboolTypeReading($('#technicallyltdbutreadableAwvAaainputcheck'), testResult.TechnicallyLimitedbutReadable);

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-AwvAaa')));

        testResult.TestNotPerformed = getTestNotPerformedReasonForAwvAaa(testResult.TestNotPerformed);

        testResult.IncidentalFindings = CompareIfObject(getSelectedIncidentalFindings($('.dtl-AwvAaa-if')), testResult.IncidentalFindings);


        testResult.AortaSize = getReading($("#AwvAaaAortaSizeInputText"), testResult.AortaSize);
        testResult.PeakSystolicVelocity = getReading($("#AwvAaaPeakSystolicVelocityInputText"), testResult.PeakSystolicVelocity);

        if (testResult.TransverseView == null)
            testResult.TransverseView = { "FirstValue": null, "SecondValue": null };

        testResult.TransverseView.FirstValue = getReading($("#AwvAaaTVDatapointOneTextbox"), testResult.TransverseView.FirstValue);
        testResult.TransverseView.SecondValue = getReading($("#AwvAaaTVDatapointTwoTextbox"), testResult.TransverseView.SecondValue);

        if (testResult.TransverseView.FirstValue == null && testResult.TransverseView.SecondValue == null) testResult.TransverseView = null;

        if (testResult.ResidualLumenStandardFindings == null)
            testResult.ResidualLumenStandardFindings = { "FirstValue": null, "SecondValue": null };

        testResult.ResidualLumenStandardFindings.FirstValue = getReading($("#AwvAaaResidualLumenTVDatapointOneTextbox"), testResult.ResidualLumenStandardFindings.FirstValue);
        testResult.ResidualLumenStandardFindings.SecondValue = getReading($("#AwvAaaResidualLumenTVDatapointTwoTextbox"), testResult.ResidualLumenStandardFindings.SecondValue);
        
        if (testResult.ResidualLumenStandardFindings.FirstValue == null && testResult.ResidualLumenStandardFindings.SecondValue == null) testResult.ResidualLumenStandardFindings = null;

        testResult.AortaRangeSaggitalView = CompareListfindings(getMultipleFindingDatalist($(".dtl-sagitalview-finding-AwvAaa")), testResult.AortaRangeSaggitalView);
        testResult.AortaRangeTransverseView = CompareListfindings(getMultipleFindingDatalist($(".dtl-transverseview-finding-AwvAaa")), testResult.AortaRangeTransverseView);
        testResult.PeakSystolicVelocityStandardFindings = CompareListfindings(getMultipleFindingDatalist($(".dtl-peakSystolicVelocity-finding-AwvAaa")), testResult.PeakSystolicVelocityStandardFindings);

        if (currentScreenMode != ScreenMode.Physician) {

            var resultMedia = new Array();
            if (AwvAaaResultMedia != null) {
                $.each(AwvAaaResultMedia, function () { resultMedia.push(this); });
            }
            testResult.ResultImages = resultMedia;
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
            testResult.ConductedByOrgRoleUserId = $("#conductedbyAwvAaa option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesAwvAaa").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentAwvAaaInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestAwvAaaCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_55").attr("checked");

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }

        if (currentScreenMode != ScreenMode.Entry) {

            testResult.RepeatStudy = getboolTypeReading($('#repeatstudyAwvAaainputcheck'), testResult.RepeatStudy);

            if (testResult.PhysicianInterpretation == null)
                testResult.PhysicianInterpretation = {
                    'Remarks': $("#physicianRemarksAwvAaa").val(), 'IsCritical': $("#criticalAwvAaa").attr("checked"), 'FollowUp': $("#followUpAwvAaa").attr("checked"), 'RecorderMetaData': {
                        'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate
                    }
                };
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksAwvAaa").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpAwvAaa").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalAwvAaa").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }

        if (testResult.ResultStatus.StateNumber < 4) {
            if (testResult.AortaSize == null && testResult.Finding == null && testResult.IncidentalFindings == null
                && (testResult.AorticDissection == null || testResult.AorticDissection.Reading == false) && (testResult.Plaque == null || testResult.Plaque.Reading == false)
                && (testResult.Thrombus == null || testResult.Thrombus.Reading == false) && testResult.TechnicianNotes.length < 1
                && testResult.ConductedByOrgRoleUserId == "0" && testResult.UnableScreenReason == null && AwvAaaImageCount == 0 && $("#DescribeSelfPresentAwvAaaInputCheck").attr("checked") == false)
                return null;
        }

        return testResult;
    }
}

var AwvAaaImageCount = 0;
var AwvAaaResultMedia = null;
function LoadNewImagesAwvAaa(jsonMedia, correctJson) {
    AwvAaaResultMedia = jsonMedia;
    AwvAaaImageCount = 0;
    $("#AwvAaaImagesContainerDiv").empty();
    if (jsonMedia == null || jsonMedia.length < 1) return;
    AwvAaaImageCount = jsonMedia.length;
    LoadNewMedia(jsonMedia, correctJson, $("#AwvAaaImagesContainerDiv"));
}

function getAwvAaaMedia() {
    return AwvAaaResultMedia;
}

$(document).ready(function () {
    $("#AwvAaaAortaSizeInputText,#AwvAaaTVDatapointOneTextbox,#AwvAaaTVDatapointTwoTextbox").change(function () {
        selectFindings();
    });
});

function selectFindings() {
    var value1 = $("#AwvAaaAortaSizeInputText").val().length > 0 ? Number($("#AwvAaaAortaSizeInputText").val()) : 0;
    var value2 = $("#AwvAaaTVDatapointOneTextbox").val().length > 0 ? Number($("#AwvAaaTVDatapointOneTextbox").val()) : 0;
    var value3 = $("#AwvAaaTVDatapointTwoTextbox").val().length > 0 ? Number($("#AwvAaaTVDatapointTwoTextbox").val()) : 0;

    if (value1 == value2 && value2 == value3) {
        autoSelectFinding($(".gv-Findings-AwvAaa"), $("#AwvAaaAortaSizeInputText"), 1);
    }
    else if (value1 > value2 && value1 > value3) {
        autoSelectFinding($(".gv-Findings-AwvAaa"), $("#AwvAaaAortaSizeInputText"), 1);
    }
    else if (value2 > value3) {
        autoSelectFinding($(".gv-Findings-AwvAaa"), $("#AwvAaaTVDatapointOneTextbox"), 1);
    }
    else {
        autoSelectFinding($(".gv-Findings-AwvAaa"), $("#AwvAaaTVDatapointTwoTextbox"), 1);
    }
}

var criticalDataModel_AwvAaa = null;
function onClick_CriticalDataAwvAaa() {
    if ($("#DescribeSelfPresentAwvAaaInputCheck").attr("checked")) {
        loadCriticalLink($("#AwvAaa-critical-span"), "onClick_CriticalDataAwvAaa();", testTypeAwvAaa);
        openCriticalDataDialog(testTypeAwvAaa, $("#conductedbyAwvAaa"), $("#DescribeSelfPresentAwvAaaInputCheck"), setcriticalDataModel_AwvAaa);
    }
    else {
        unloadCriticalLink($("#AwvAaa-critical-span"), testTypeAwvAaa);
    }
}

function setcriticalDataModel_AwvAaa(model, printAfterSave) {
    if (model != null) {
        var testResult = GetAwvAaaData();
        saveSingleTestResult(testResult, model, $("#AwvAaa-critical-span"), "onClick_CriticalDataAwvAaa();", SetAwvAaaData, printAfterSave);
    }
}

function getcriticalDataModel_AwvAaa() {
    if ($("#DescribeSelfPresentAwvAaaInputCheck").attr("checked") && criticalDataModel_AwvAaa != null) {
        criticalDataModel_AwvAaa.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_AwvAaa;
    }
    return null;
}

function onClick_PriorityInQueueDataAwvAaa() {
    if ($("#PriorityInQueueTestAwvAaaCheck").attr("checked")) {
        loadPriorityInQueueLink($("#AwvAaa-priorityInQueue-span"), "onClick_PriorityInQueueDataAwvAaa();", testTypeAwvAaa);
        openPriorityInQueueTestDialog(testTypeAwvAaa, $("#conductedbyAwvAaa"), $("#PriorityInQueueTestAwvAaaCheck"), setPriorityInQueueDataModel_AwvAaa);
    }
    else {
        unloadPriorityInQueueLink($("#AwvAaa-priorityInQueue-span"), testTypeAwvAaa);
    }
}

function setPriorityInQueueDataModel_AwvAaa(model) {
    if (model != null) {
        var testResult = GetAwvAaaData();
        model.TestId = testTypeAwvAaa;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#AwvAaa-priorityInQueue-span"), "onClick_PriorityInQueueDataAwvAaa();", SetAwvAaaData);
    }
}

function clearAllAwvAaaSelection() {
    $(".gv-Findings-AwvAaa input[type=radio], .dtl-sagitalview-finding-AwvAaa input[type=checkbox], .dtl-transverseview-finding-AwvAaa input[type=checkbox], .dtl-AwvAaa-if input[type=checkbox]").attr("checked", false);
    $("#AwvAaaAorticDissectionCheckbox, #AwvAaaPlaqueCheckbox, #AwvAaaThrombusCheckbox").attr("checked", false);
}


function setTestNotPerformedReasonForAwvAaa(testNotPerformed) {
    setTestNotPerformed("testnotPerformedAwvAaa", testNotPerformed);
    SetTestNotPerformedEnableDisabled("testnotPerformedAwvAaa");
}

function getTestNotPerformedReasonForAwvAaa(testNotPerformed) {
    return getTestNotPerformed("testnotPerformedAwvAaa", testNotPerformed);
}