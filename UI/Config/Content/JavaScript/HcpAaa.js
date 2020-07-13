function HcpAaa(object) {
    if (object == null || object == undefined) {
        object = {
            "Id": 0, "TestType": testTypeHcpAaa, "AortaSize": null, "Finding": null, "AorticDissection": null, "Plaque": null, "Thrombus": null, 
            "TransverseView": { "FirstValue": null, "SecondValue": null },
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
                "IsPriorityInQueue": $("#PriorityInQueueTestHcpAAACheck").attr("checked")
            }
        };
    }

    this.Result = object;
}

HcpAaa.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (IsHcpaaaResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_HcpaaacapturebyChat", testResult.TestPerformedExternally)
        }

        if (testResult.Finding != null) {
            setSelectedFinding($(".gv-Findings-HcpAAA"), testResult.Finding.Id);
        }

        setReading($("#HcpAortaSizeInputText"), testResult.AortaSize);

        setReading($("#diagnosisCodeHcpAaa"), testResult.DiagnosisCode);

        if (testResult.TransverseView != null) {
            setReading($("#HcpTVDatapointOneTextbox"), testResult.TransverseView.FirstValue);
            setReading($("#HcpTVDatapointTwoTextbox"), testResult.TransverseView.SecondValue);
        }

        setboolTypeReading($("#HcpAorticDissectionCheckbox"), testResult.AorticDissection);
        setboolTypeReading($("#HcpPlaqueCheckbox"), testResult.Plaque);
        setboolTypeReading($("#HcpThrombusCheckbox"), testResult.Thrombus);
        setboolTypeReading($('#technicallyltdbutreadableHcpaaainputcheck'), testResult.TechnicallyLimitedbutReadable);
        setboolTypeReading($('#repeatstudyHcpaaainputcheck'), testResult.RepeatStudy);

        setMultipleFindingDatalist($(".dtl-sagitalview-finding-HcpAAA"), testResult.AortaRangeSaggitalView);
        setMultipleFindingDatalist($(".dtl-transverseview-finding-HcpAAA"), testResult.AortaRangeTransverseView);
        
        setUnableScreenReason($('.dtl-unabletoscreen-Hcpaaa'), testResult.UnableScreenReason);
        setTestNotPerformedReasonForHcpAAA(testResult.TestNotPerformed);

        $("#DescribeSelfPresentHcpAAAInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);
        $("#PriorityInQueueTestHcpAAACheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#hcpaaa-priorityInQueue-span"), "onClick_PriorityInQueueDataHcpAAA();", testTypeHcpAaa);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#hcpaaa-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#Hcpaaa-critical-span"), "onClick_CriticalDataHcpAaa();", testTypeHcpAaa);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#Hcpaaa-critical-span").parent().addClass("red-band");
                $("#criticalHcpAaa").attr("checked", "checked");
            }
        }

        if (testResult.ResultImages && testResult.ResultImages.length > 0) {
            LoadNewImagesHcpAAA(testResult.ResultImages, true);
        }

        $("#technotesHcpaaa").val(testResult.TechnicianNotes);
        $("#conductedbyHcpaaa option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);

        if (testResult.IncidentalFindings != null && testResult.IncidentalFindings.length > 0)
            setSelectedIncidentalFinding($('.dtl-Hcpaaa-if'), testResult.IncidentalFindings);

        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksHcpAaa").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpHcpAaa").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalHcpAaa").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }

    },
    getData: function () {
        var testResult = this.Result;
        if (IsHcpaaaResultEntryExternaly == 'True') {
             testResult.TestPerformedExternally = getTestPerformedExternally("chk_HcpaaacapturebyChat", testResult.TestPerformedExternally)
        }

        var testFindings = getSelectedFinding($(".gv-Findings-HcpAAA"));
        testResult.Finding = getFindingDataandSynchronized(testResult.Finding, testFindings);

        testResult.AorticDissection = getboolTypeReading($("#HcpAorticDissectionCheckbox"), testResult.AorticDissection);
        testResult.Plaque = getboolTypeReading($("#HcpPlaqueCheckbox"), testResult.Plaque);
        testResult.Thrombus = getboolTypeReading($("#HcpThrombusCheckbox"), testResult.Thrombus);
        testResult.TechnicallyLimitedbutReadable = getboolTypeReading($('#technicallyltdbutreadableHcpaaainputcheck'), testResult.TechnicallyLimitedbutReadable);

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-Hcpaaa')));       

        testResult.TestNotPerformed = getTestNotPerformedReasonForHcpAAA(testResult.TestNotPerformed);

        testResult.IncidentalFindings = CompareIfObject(getSelectedIncidentalFindings($('.dtl-Hcpaaa-if')), testResult.IncidentalFindings);
        testResult.AortaSize = getReading($("#HcpAortaSizeInputText"), testResult.AortaSize);

        if (testResult.TransverseView == null)
            testResult.TransverseView = { "FirstValue": null, "SecondValue": null };

        testResult.TransverseView.FirstValue = getReading($("#HcpTVDatapointOneTextbox"), testResult.TransverseView.FirstValue);
        testResult.TransverseView.SecondValue = getReading($("#HcpTVDatapointTwoTextbox"), testResult.TransverseView.SecondValue);

        if (testResult.TransverseView.FirstValue == null && testResult.TransverseView.SecondValue == null) testResult.TransverseView = null;

        testResult.AortaRangeSaggitalView = CompareListfindings(getMultipleFindingDatalist($(".dtl-sagitalview-finding-HcpAAA")), testResult.AortaRangeSaggitalView);
        testResult.AortaRangeTransverseView = CompareListfindings(getMultipleFindingDatalist($(".dtl-transverseview-finding-HcpAAA")), testResult.AortaRangeTransverseView);


        if (currentScreenMode != ScreenMode.Physician) {
            //testResult.AortaSize = getReading($("#HcpAortaSizeInputText"), testResult.AortaSize);

            //if (testResult.TransverseView == null)
            //    testResult.TransverseView = { "FirstValue": null, "SecondValue": null };

            //testResult.TransverseView.FirstValue = getReading($("#HcpTVDatapointOneTextbox"), testResult.TransverseView.FirstValue);
            //testResult.TransverseView.SecondValue = getReading($("#HcpTVDatapointTwoTextbox"), testResult.TransverseView.SecondValue);

            //if (testResult.TransverseView.FirstValue == null && testResult.TransverseView.SecondValue == null) testResult.TransverseView = null;

            //testResult.AortaRangeSaggitalView = CompareListfindings(getMultipleFindingDatalist($(".dtl-sagitalview-finding-HcpAAA")), testResult.AortaRangeSaggitalView);
            //testResult.AortaRangeTransverseView = CompareListfindings(getMultipleFindingDatalist($(".dtl-transverseview-finding-HcpAAA")), testResult.AortaRangeTransverseView);

            var resultMedia = new Array();
            if (HcpaaaResultMedia != null) {
                $.each(HcpaaaResultMedia, function () { resultMedia.push(this); });
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
            testResult.ConductedByOrgRoleUserId = $("#conductedbyHcpaaa option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesHcpaaa").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentHcpAAAInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestHcpAAACheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_49").attr("checked");

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }

        if (currentScreenMode != ScreenMode.Entry) {

            testResult.RepeatStudy = getboolTypeReading($('#repeatstudyHcpaaainputcheck'), testResult.RepeatStudy);

            if (testResult.PhysicianInterpretation == null)
                testResult.PhysicianInterpretation = {
                    'Remarks': $("#physicianRemarksHcpAaa").val(), 'IsCritical': $("#criticalHcpAaa").attr("checked"), 'FollowUp': $("#followUpHcpAaa").attr("checked"), 'RecorderMetaData': {
                        'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate
                    }
                };
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksHcpAaa").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpHcpAaa").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalHcpAaa").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }

        if (testResult.ResultStatus.StateNumber < 4) {
            if (testResult.AortaSize == null && testResult.Finding == null && testResult.IncidentalFindings == null
                && (testResult.AorticDissection == null || testResult.AorticDissection.Reading == false) && (testResult.Plaque == null || testResult.Plaque.Reading == false)
                && (testResult.Thrombus == null || testResult.Thrombus.Reading == false) && testResult.TechnicianNotes.length < 1
                && testResult.ConductedByOrgRoleUserId == "0" && testResult.UnableScreenReason == null && HcpAAAImageCount == 0 && $("#DescribeSelfPresentHcpAAAInputCheck").attr("checked") == false)
                return null;
        }

        return testResult;
    }
}

var HcpAAAImageCount = 0;
var HcpaaaResultMedia = null;
function LoadNewImagesHcpAAA(jsonMedia, correctJson) {
    HcpaaaResultMedia = jsonMedia;
    HcpAAAImageCount = 0;
    $("#HcpAAAImagesContainerDiv").empty();
    if (jsonMedia == null || jsonMedia.length < 1) return;
    HcpAAAImageCount = jsonMedia.length;
    LoadNewMedia(jsonMedia, correctJson, $("#HcpAAAImagesContainerDiv"));
}

function getHcpAaaMedia() {
    return HcpaaaResultMedia;
}

$(document).ready(function () {
    $("#HcpAortaSizeInputText,#HcpTVDatapointOneTextbox,#HcpTVDatapointTwoTextbox").change(function () {
        selectFindings();
    });
});

function selectFindings() {
    var value1 = $("#HcpAortaSizeInputText").val().length > 0 ? Number($("#HcpAortaSizeInputText").val()) : 0;
    var value2 = $("#HcpTVDatapointOneTextbox").val().length > 0 ? Number($("#HcpTVDatapointOneTextbox").val()) : 0;
    var value3 = $("#HcpTVDatapointTwoTextbox").val().length > 0 ? Number($("#HcpTVDatapointTwoTextbox").val()) : 0;

    if (value1 == value2 && value2 == value3) {
        autoSelectFinding($(".gv-Findings-HcpAAA"), $("#HcpAortaSizeInputText"), 1);
    }
    else if (value1 > value2 && value1 > value3) {
        autoSelectFinding($(".gv-Findings-HcpAAA"), $("#HcpAortaSizeInputText"), 1);
    }
    else if (value2 > value3) {
        autoSelectFinding($(".gv-Findings-HcpAAA"), $("#HcpTVDatapointOneTextbox"), 1);
    }
    else {
        autoSelectFinding($(".gv-Findings-HcpAAA"), $("#HcpTVDatapointTwoTextbox"), 1);
    }
}

var criticalDataModel_HcpAaa = null;
function onClick_CriticalDataHcpAaa() {
    if ($("#DescribeSelfPresentHcpAAAInputCheck").attr("checked")) {
        loadCriticalLink($("#Hcpaaa-critical-span"), "onClick_CriticalDataHcpAaa();", testTypeHcpAaa);
        openCriticalDataDialog(testTypeHcpAaa, $("#conductedbyHcpaaa"), $("#DescribeSelfPresentHcpAAAInputCheck"), setCriticalDataModel_HcpAaa);
    }
    else {
        unloadCriticalLink($("#Hcpaaa-critical-span"), testTypeHcpAaa);
    }
}

function setCriticalDataModel_HcpAaa(model, printAfterSave) {
    if (model != null) {
        var testResult = GetHcpAAAData();
        saveSingleTestResult(testResult, model, $("#Hcpaaa-critical-span"), "onClick_CriticalDataHcpAaa();", SetHcpAAAData, printAfterSave);
    }
}

function getCriticalDataModel_HcpAaa() {
    if ($("#DescribeSelfPresentHcpAAAInputCheck").attr("checked") && criticalDataModel_HcpAaa != null) {
        criticalDataModel_HcpAaa.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_HcpAaa;
    }
    return null;
}
function onClick_PriorityInQueueDataHcpAAA() {
    if ($("#PriorityInQueueTestHcpAAACheck").attr("checked")) {
        loadPriorityInQueueLink($("#hcpaaa-priorityInQueue-span"), "onClick_PriorityInQueueDataHcpAAA();", testTypeHcpAaa);
        openPriorityInQueueTestDialog(testTypeHcpAaa, $("#conductedbyHcpaaa"), $("#PriorityInQueueTestHcpAAACheck"), setPriorityInQueueDataModel_HcpAAA);
    }
    else {
        unloadPriorityInQueueLink($("#hcpaaa-priorityInQueue-span"), testTypeHcpAaa);
    }
}

function setPriorityInQueueDataModel_HcpAAA(model) {
    if (model != null) {
        var testResult = GetHcpAAAData();
        model.TestId = testTypeHcpAaa;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#hcpaaa-priorityInQueue-span"), "onClick_PriorityInQueueDataHcpAAA();", SetHcpAAAData);
    }
} 
function clearAllHcpAaaSelection() {
    $(".gv-Findings-HcpAAA input[type=radio], .dtl-sagitalview-finding-HcpAAA input[type=checkbox], .dtl-transverseview-finding-HcpAAA input[type=checkbox], .dtl-Hcpaaa-if input[type=checkbox]").attr("checked", false);
    $("#HcpAorticDissectionCheckbox, #HcpPlaqueCheckbox, #HcpThrombusCheckbox").attr("checked", false);
}


function setTestNotPerformedReasonForHcpAAA(testNotPerformed) {
    setTestNotPerformed("testnotPerformedHcpaaa", testNotPerformed);
    SetTestNotPerformedEnableDisabled("testnotPerformedHcpaaa");
}

function getTestNotPerformedReasonForHcpAAA(testNotPerformed) {
    return getTestNotPerformed("testnotPerformedHcpaaa", testNotPerformed);
}