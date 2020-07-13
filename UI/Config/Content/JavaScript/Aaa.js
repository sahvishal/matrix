function Aaa(object) {
    if (object == null || object == undefined) {
        object = {
            "Id": 0, "TestType": testTypeAaa, "AortaSize": null, "Finding": null, "AorticDissection": null, "Plaque": null, "Thrombus": null,
            "TransverseView": { "FirstValue": null, "SecondValue": null },
            "AortaRangeTransverseView": new Array(), "AortaRangeSaggitalView": new Array(), "UnableScreenReason": new Array(),
            "IncidentalFindings": new Array(),
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": '',
            "TestPerformedExternally": null,
             
            "ResultImages": null,
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": {
                "Id": 0,
                "SelfPresent": false,
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestAAACheck").attr("checked")
            }
        };
    }

    this.Result = object;
}

Aaa.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (IsaaaResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_aaacapturebyChat", testResult.TestPerformedExternally)
        }
        if (testResult.Finding != null) {
            setSelectedFinding($(".gv-Findings-AAA"), testResult.Finding.Id);
        }
      
        setReading($("#AortaSizeInputText"), testResult.AortaSize);
        if (testResult.TransverseView != null) {
            setReading($("#TVDatapointOneTextbox"), testResult.TransverseView.FirstValue);
            setReading($("#TVDatapointTwoTextbox"), testResult.TransverseView.SecondValue);
        }

        setboolTypeReading($("#AorticDissectionCheckbox"), testResult.AorticDissection);
        setboolTypeReading($("#PlaqueCheckbox"), testResult.Plaque);
        setboolTypeReading($("#ThrombusCheckbox"), testResult.Thrombus);
        setboolTypeReading($('#technicallyltdbutreadableaaainputcheck'), testResult.TechnicallyLimitedbutReadable);
        setboolTypeReading($('#repeatstudyaaainputcheck'), testResult.RepeatStudy);

        setboolTypeReading($('#AaaConsiderOtherModalities'), testResult.ConsiderOtherModalities);
        setboolTypeReading($('#AaaAdditionalImagesNeeded'), testResult.AdditionalImagesNeeded);

        setMultipleFindingDatalist($(".dtl-sagitalview-finding-AAA"), testResult.AortaRangeSaggitalView);
        setMultipleFindingDatalist($(".dtl-transverseview-finding-AAA"), testResult.AortaRangeTransverseView);

        setUnableScreenReason($('.dtl-unabletoscreen-aaa'), testResult.UnableScreenReason);

        $("#DescribeSelfPresentAAAInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);
        $("#PriorityInQueueTestAAACheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);

        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#aaa-priorityInQueue-span"), "onClick_PriorityInQueueDataAAA();", testTypeAaa);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#aaa-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#aaa-critical-span"), "onClick_CriticalDataAaa();", testTypeAaa);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#aaa-critical-span").parent().addClass("red-band");
                $("#criticalAaa").attr("checked", "checked");
            }
        }

        if (testResult.ResultImages && testResult.ResultImages.length > 0) {
            LoadNewImagesAAA(testResult.ResultImages, true);
        }

        $("#technotesaaa").val(testResult.TechnicianNotes);
        $("#conductedbyaaa option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);

        if (testResult.IncidentalFindings != null && testResult.IncidentalFindings.length > 0)
            setSelectedIncidentalFinding($('.dtl-aaa-if'), testResult.IncidentalFindings);

        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksAaa").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpAaa").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalAaa").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }
    },
    getData: function () {
        var testResult = this.Result;
        if (IsaaaResultEntryExternaly == 'True') {
            testResult.TestPerformedExternally = getTestPerformedExternally("chk_aaacapturebyChat", testResult.TestPerformedExternally)
        }

        var testFindings = getSelectedFinding($(".gv-Findings-AAA"));
        testResult.Finding = getFindingDataandSynchronized(testResult.Finding, testFindings);

        testResult.AorticDissection = getboolTypeReading($("#AorticDissectionCheckbox"), testResult.AorticDissection);
        testResult.Plaque = getboolTypeReading($("#PlaqueCheckbox"), testResult.Plaque);
        testResult.Thrombus = getboolTypeReading($("#ThrombusCheckbox"), testResult.Thrombus);
        testResult.TechnicallyLimitedbutReadable = getboolTypeReading($('#technicallyltdbutreadableaaainputcheck'), testResult.TechnicallyLimitedbutReadable);

        testResult.ConsiderOtherModalities = getboolTypeReading($('#AaaConsiderOtherModalities'), testResult.ConsiderOtherModalities);
        testResult.AdditionalImagesNeeded = getboolTypeReading($('#AaaAdditionalImagesNeeded'), testResult.AdditionalImagesNeeded);

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-aaa')));

        testResult.IncidentalFindings = CompareIfObject(getSelectedIncidentalFindings($('.dtl-aaa-if')), testResult.IncidentalFindings);
        //if (currentScreenMode != ScreenMode.Physician) {
        testResult.AortaSize = getReading($("#AortaSizeInputText"), testResult.AortaSize);

        if (testResult.TransverseView == null)
            testResult.TransverseView = { "FirstValue": null, "SecondValue": null };

        testResult.TransverseView.FirstValue = getReading($("#TVDatapointOneTextbox"), testResult.TransverseView.FirstValue);
        testResult.TransverseView.SecondValue = getReading($("#TVDatapointTwoTextbox"), testResult.TransverseView.SecondValue);

        if (testResult.TransverseView.FirstValue == null && testResult.TransverseView.SecondValue == null) testResult.TransverseView = null;

        testResult.AortaRangeSaggitalView = CompareListfindings(getMultipleFindingDatalist($(".dtl-sagitalview-finding-AAA")), testResult.AortaRangeSaggitalView);
        testResult.AortaRangeTransverseView = CompareListfindings(getMultipleFindingDatalist($(".dtl-transverseview-finding-AAA")), testResult.AortaRangeTransverseView);

        if (currentScreenMode != ScreenMode.Physician) {

            var resultMedia = new Array();
            if (aaaResultMedia != null) {
                $.each(aaaResultMedia, function () { resultMedia.push(this); });
            }
            testResult.ResultImages = resultMedia;
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
            testResult.ConductedByOrgRoleUserId = $("#conductedbyaaa option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesaaa").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentAAAInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestAAACheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_10").attr("checked");

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }

        if (currentScreenMode != ScreenMode.Entry) {

            testResult.RepeatStudy = getboolTypeReading($('#repeatstudyaaainputcheck'), testResult.RepeatStudy);

            if (testResult.PhysicianInterpretation == null)
                testResult.PhysicianInterpretation = {
                    'Remarks': $("#physicianRemarksAaa").val(), 'IsCritical': $("#criticalAaa").attr("checked"), 'FollowUp': $("#followUpAaa").attr("checked"), 'RecorderMetaData': {
                        'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate
                    }
                };
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksAaa").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpAaa").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalAaa").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }

        if (testResult.ResultStatus.StateNumber < 4) {
            if (testResult.AortaSize == null && testResult.Finding == null && testResult.IncidentalFindings == null
                && (testResult.AorticDissection == null || testResult.AorticDissection.Reading == false) && (testResult.Plaque == null || testResult.Plaque.Reading == false)
                && (testResult.Thrombus == null || testResult.Thrombus.Reading == false) && testResult.TechnicianNotes.length < 1
                && testResult.ConductedByOrgRoleUserId == "0" && testResult.UnableScreenReason == null && AAAImageCount == 0 && $("#DescribeSelfPresentAAAInputCheck").attr("checked") == false)
                return null;
        }

        return testResult;
    }
}

var AAAImageCount = 0;
var aaaResultMedia = null;
function LoadNewImagesAAA(jsonMedia, correctJson) {
    aaaResultMedia = jsonMedia;
    AAAImageCount = 0;
    $("#AAAImagesContainerDiv").empty();
    if (jsonMedia == null || jsonMedia.length < 1) return;
    AAAImageCount = jsonMedia.length;
    LoadNewMedia(jsonMedia, correctJson, $("#AAAImagesContainerDiv"));
}

function getAaaMedia() {
    return aaaResultMedia;
}

$(document).ready(function () {
    $("#AortaSizeInputText,#TVDatapointOneTextbox,#TVDatapointTwoTextbox").change(function () {
        selectFindings();
    });

    $(".gv-Findings-AAA input[type=radio], .dtl-sagitalview-finding-AAA input[type=checkbox], .dtl-transverseview-finding-AAA input[type=checkbox], .dtl-aaa-if input[type=checkbox]").click(function () {
        clearPhysicianAdditionFindingRadio();
    });

    $("#AorticDissectionCheckbox, #PlaqueCheckbox, #ThrombusCheckbox").click(function () {
        clearPhysicianAdditionFindingRadio();
    });

});

function selectFindings() {
    var value1 = $("#AortaSizeInputText").val().length > 0 ? Number($("#AortaSizeInputText").val()) : 0;
    var value2 = $("#TVDatapointOneTextbox").val().length > 0 ? Number($("#TVDatapointOneTextbox").val()) : 0;
    var value3 = $("#TVDatapointTwoTextbox").val().length > 0 ? Number($("#TVDatapointTwoTextbox").val()) : 0;

    if (value1 == value2 && value2 == value3) {
        autoSelectFinding($(".gv-Findings-AAA"), $("#AortaSizeInputText"), 1);
        clearPhysicianAdditionFindingRadio();
    }
    else if (value1 > value2 && value1 > value3) {
        autoSelectFinding($(".gv-Findings-AAA"), $("#AortaSizeInputText"), 1);
        clearPhysicianAdditionFindingRadio();
    }
    else if (value2 > value3) {
        autoSelectFinding($(".gv-Findings-AAA"), $("#TVDatapointOneTextbox"), 1);
        clearPhysicianAdditionFindingRadio();
    }
    else {
        autoSelectFinding($(".gv-Findings-AAA"), $("#TVDatapointTwoTextbox"), 1);
        clearPhysicianAdditionFindingRadio();
    }
}

var criticalDataModel_Aaa = null;
function onClick_CriticalDataAaa() {
    if ($("#DescribeSelfPresentAAAInputCheck").attr("checked")) {
        loadCriticalLink($("#aaa-critical-span"), "onClick_CriticalDataAaa();", testTypeAaa);
        openCriticalDataDialog(testTypeAaa, $("#conductedbyaaa"), $("#DescribeSelfPresentAAAInputCheck"), setCriticalDataModel_Aaa);
    }
    else {
        unloadCriticalLink($("#aaa-critical-span"), testTypeAaa);
    }
}

function setCriticalDataModel_Aaa(model, printAfterSave) {
    if (model != null) {
        var testResult = GetAAAData();
        saveSingleTestResult(testResult, model, $("#aaa-critical-span"), "onClick_CriticalDataAaa();", SetAAAData, printAfterSave);
    }
}

function getCriticalDataModel_Aaa() {
    if ($("#DescribeSelfPresentAAAInputCheck").attr("checked") && criticalDataModel_Aaa != null) {
        criticalDataModel_Aaa.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_Aaa;
    }
    return null;
}

function onClick_PriorityInQueueDataAAA() {
    if ($("#PriorityInQueueTestAAACheck").attr("checked")) {
        loadPriorityInQueueLink($("#aaa-priorityInQueue-span"), "onClick_PriorityInQueueDataAAA();", testTypeAaa);
        openPriorityInQueueTestDialog(testTypeAaa, $("#conductedbyaaa"), $("#PriorityInQueueTestAAACheck"), setPriorityInQueueDataModel_AAA);
    }
    else {
        unloadPriorityInQueueLink($("#aaa-priorityInQueue-span"), testTypeAaa);
    }
}

function setPriorityInQueueDataModel_AAA(model) {
    if (model != null) {
        var testResult = GetAAAData();
        model.TestId = testTypeAaa;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#aaa-priorityInQueue-span"), "onClick_PriorityInQueueDataAAA();", SetAAAData);
    }
}

function clearAllAaaSelection() {
    $(".gv-Findings-AAA input[type=radio], .dtl-sagitalview-finding-AAA input[type=checkbox], .dtl-transverseview-finding-AAA input[type=checkbox], .dtl-aaa-if input[type=checkbox]").attr("checked", false);
    $("#AorticDissectionCheckbox, #PlaqueCheckbox, #ThrombusCheckbox").attr("checked", false);

}

function clearPhysicianAdditionFindingRadio() {
    $("input[name=AaaPhysicianAdditionalFindingReading]:radio").attr('checked', false);
}