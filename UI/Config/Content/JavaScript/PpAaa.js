function PpAaa(object) {
    if (object == null || object == undefined) {
        object = {
            "Id": 0, "TestType": testTypePpAaa, "AortaSize": null, "Finding": null, "AorticDissection": null, "Plaque": null, "Thrombus": null, "DiagnosisCode": null,
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
                "IsPriorityInQueue": $("#PriorityInQueueTestPpAAACheck").attr("checked")
            }
        };
    }

    this.Result = object;
}

PpAaa.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (IsPpaaaResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_PpaaacapturebyChat", testResult.TestPerformedExternally)
        }
        if (testResult.Finding != null) {
            setSelectedFinding($(".gv-Findings-PpAAA"), testResult.Finding.Id);
        }
       


        setReading($("#PpAortaSizeInputText"), testResult.AortaSize);

        setReading($("#diagnosisCodePpAaa"), testResult.DiagnosisCode);

        if (testResult.TransverseView != null) {
            setReading($("#PpTVDatapointOneTextbox"), testResult.TransverseView.FirstValue);
            setReading($("#PpTVDatapointTwoTextbox"), testResult.TransverseView.SecondValue);
        }

        setboolTypeReading($("#PpAorticDissectionCheckbox"), testResult.AorticDissection);
        setboolTypeReading($("#PpPlaqueCheckbox"), testResult.Plaque);
        setboolTypeReading($("#PpThrombusCheckbox"), testResult.Thrombus);
        setboolTypeReading($('#technicallyltdbutreadablePpaaainputcheck'), testResult.TechnicallyLimitedbutReadable);
        setboolTypeReading($('#repeatstudyPpaaainputcheck'), testResult.RepeatStudy);

        setMultipleFindingDatalist($(".dtl-sagitalview-finding-PpAAA"), testResult.AortaRangeSaggitalView);
        setMultipleFindingDatalist($(".dtl-transverseview-finding-PpAAA"), testResult.AortaRangeTransverseView);

        setUnableScreenReason($('.dtl-unabletoscreen-Ppaaa'), testResult.UnableScreenReason);

        $("#DescribeSelfPresentPpAAAInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);
        $("#PriorityInQueueTestPpAAACheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#ppaaa-priorityInQueue-span"), "onClick_PriorityInQueueDataPpAAA();", testTypePpAaa);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#ppaaa-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#Ppaaa-critical-span"), "onClick_CriticalDataPpAaa();", testTypePpAaa);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#Ppaaa-critical-span").parent().addClass("red-band");
                $("#criticalPpAaa").attr("checked", "checked");
            }
        }

        if (testResult.ResultImages && testResult.ResultImages.length > 0) {
            LoadNewImagesPpAAA(testResult.ResultImages, true);
        }

        $("#technotesPpaaa").val(testResult.TechnicianNotes);
        $("#conductedbyPpaaa option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);

        if (testResult.IncidentalFindings != null && testResult.IncidentalFindings.length > 0)
            setSelectedIncidentalFinding($('.dtl-Ppaaa-if'), testResult.IncidentalFindings);

        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksPpAaa").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpPpAaa").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalPpAaa").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }
        
        setPpAaaDiagnosisCode(null);

    },
    getData: function () {
        var testResult = this.Result;
        if (IsPpaaaResultEntryExternaly == 'True') {
             testResult.TestPerformedExternally = getTestPerformedExternally("chk_PpaaacapturebyChat", testResult.TestPerformedExternally)
        }
        
        var testFindings = getSelectedFinding($(".gv-Findings-PpAAA"));
        testResult.Finding = getFindingDataandSynchronized(testResult.Finding, testFindings);

        testResult.AorticDissection = getboolTypeReading($("#PpAorticDissectionCheckbox"), testResult.AorticDissection);
        testResult.Plaque = getboolTypeReading($("#PpPlaqueCheckbox"), testResult.Plaque);
        testResult.Thrombus = getboolTypeReading($("#PpThrombusCheckbox"), testResult.Thrombus);
        testResult.TechnicallyLimitedbutReadable = getboolTypeReading($('#technicallyltdbutreadablePpaaainputcheck'), testResult.TechnicallyLimitedbutReadable);

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-Ppaaa')));

        testResult.IncidentalFindings = CompareIfObject(getSelectedIncidentalFindings($('.dtl-Ppaaa-if')), testResult.IncidentalFindings);

        testResult.DiagnosisCode = getReading($("#diagnosisCodePpAaa"), testResult.DiagnosisCode);
        testResult.AortaSize = getReading($("#PpAortaSizeInputText"), testResult.AortaSize);

        if (testResult.TransverseView == null)
            testResult.TransverseView = { "FirstValue": null, "SecondValue": null };

        testResult.TransverseView.FirstValue = getReading($("#PpTVDatapointOneTextbox"), testResult.TransverseView.FirstValue);
        testResult.TransverseView.SecondValue = getReading($("#PpTVDatapointTwoTextbox"), testResult.TransverseView.SecondValue);

        if (testResult.TransverseView.FirstValue == null && testResult.TransverseView.SecondValue == null) testResult.TransverseView = null;

        testResult.AortaRangeSaggitalView = CompareListfindings(getMultipleFindingDatalist($(".dtl-sagitalview-finding-PpAAA")), testResult.AortaRangeSaggitalView);
        testResult.AortaRangeTransverseView = CompareListfindings(getMultipleFindingDatalist($(".dtl-transverseview-finding-PpAAA")), testResult.AortaRangeTransverseView);



        if (currentScreenMode != ScreenMode.Physician) {
            //testResult.AortaSize = getReading($("#PpAortaSizeInputText"), testResult.AortaSize);

            //if (testResult.TransverseView == null)
            //    testResult.TransverseView = { "FirstValue": null, "SecondValue": null };

            //testResult.TransverseView.FirstValue = getReading($("#PpTVDatapointOneTextbox"), testResult.TransverseView.FirstValue);
            //testResult.TransverseView.SecondValue = getReading($("#PpTVDatapointTwoTextbox"), testResult.TransverseView.SecondValue);

            //if (testResult.TransverseView.FirstValue == null && testResult.TransverseView.SecondValue == null) testResult.TransverseView = null;

            //testResult.AortaRangeSaggitalView = CompareListfindings(getMultipleFindingDatalist($(".dtl-sagitalview-finding-PpAAA")), testResult.AortaRangeSaggitalView);
            //testResult.AortaRangeTransverseView = CompareListfindings(getMultipleFindingDatalist($(".dtl-transverseview-finding-PpAAA")), testResult.AortaRangeTransverseView);



            var resultMedia = new Array();
            if (PpaaaResultMedia != null) {
                $.each(PpaaaResultMedia, function () { resultMedia.push(this); });
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
            testResult.ConductedByOrgRoleUserId = $("#conductedbyPpaaa option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesPpaaa").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentPpAAAInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestPpAAACheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_37").attr("checked");

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }

        if (currentScreenMode != ScreenMode.Entry) {

            testResult.RepeatStudy = getboolTypeReading($('#repeatstudyPpaaainputcheck'), testResult.RepeatStudy);

            if (testResult.PhysicianInterpretation == null)
                testResult.PhysicianInterpretation = {
                    'Remarks': $("#physicianRemarksPpAaa").val(), 'IsCritical': $("#criticalPpAaa").attr("checked"), 'FollowUp': $("#followUpPpAaa").attr("checked"), 'RecorderMetaData': {
                        'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate
                    }
                };
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksPpAaa").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpPpAaa").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalPpAaa").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }

        if (testResult.ResultStatus.StateNumber < 4) {
            if (testResult.AortaSize == null && testResult.Finding == null && testResult.IncidentalFindings == null
                && (testResult.AorticDissection == null || testResult.AorticDissection.Reading == false) && (testResult.Plaque == null || testResult.Plaque.Reading == false)
                && (testResult.Thrombus == null || testResult.Thrombus.Reading == false) && testResult.TechnicianNotes.length < 1
                && testResult.ConductedByOrgRoleUserId == "0" && testResult.UnableScreenReason == null && PpAAAImageCount == 0 && $("#DescribeSelfPresentPpAAAInputCheck").attr("checked") == false)
                return null;
        }

        return testResult;
    }
}

var PpAAAImageCount = 0;
var PpaaaResultMedia = null;
function LoadNewImagesPpAAA(jsonMedia, correctJson) {
    PpaaaResultMedia = jsonMedia;
    PpAAAImageCount = 0;
    $("#PpAAAImagesContainerDiv").empty();
    if (jsonMedia == null || jsonMedia.length < 1) return;
    PpAAAImageCount = jsonMedia.length;
    LoadNewMedia(jsonMedia, correctJson, $("#PpAAAImagesContainerDiv"));
}

function getPpAaaMedia() {
    return PpaaaResultMedia;
}

$(document).ready(function () {
    $("#PpAortaSizeInputText,#PpTVDatapointOneTextbox,#PpTVDatapointTwoTextbox").change(function () {
        selectFindings();
        setPpAaaDiagnosisCode(null);
    });
    
    $(".gv-Findings-PpAAA .rbt-finding").click(function () {
        setPpAaaDiagnosisCode(this);
    });

    $("#PpPlaqueCheckbox").click(function () {
        setPpAaaDiagnosisCode(null);
    });

    //setPpAaaDiagnosisCode(null);
});

function setPpAaaDiagnosisCode(ctrlRef) {
    //debugger;
    $("#diagnosisCodePpAaa").val("");
    var worstCase = -1;
    if (ctrlRef == null) {
        var radiobtncls = "rbt-finding";

        $(".gv-Findings-PpAAA").find("tr").each(function () {
            if ($(this).find("." + radiobtncls).attr("checked") == true) {
                worstCase = $(this).find(".finding-worstcaseorder").val();
                return;
            }
        });
    } else
        worstCase = $(ctrlRef).parent().find(".finding-worstcaseorder").val();

    var diagnosidCode = '';
    if (worstCase == 1 && $("#PpPlaqueCheckbox").is(":checked") == false && $("#PpAorticDissectionCheckbox").is(":checked") == false) {
        diagnosidCode = 'Normal study';
    }
    else if (worstCase == 2) {
        diagnosidCode = '447.72 abdominal aortic ectasia';
    }

    else if (worstCase == 3) {
        diagnosidCode = '441.4 abdominal aortic aneurysm without mention of rupture';
    }

    if ($("#PpPlaqueCheckbox").is(":checked")) {
        if (diagnosidCode.length > 0)
            diagnosidCode += '|' + '440.0 atherosclerosis of aorta';
        else
            diagnosidCode = '440.0 atherosclerosis of aorta';
    }
    
    if ($("#PpAorticDissectionCheckbox").is(":checked")) {
        if (diagnosidCode.length > 0)
            diagnosidCode += '|' + '441.0 aortic dissection';
        else
            diagnosidCode = '441.0 aortic dissection';
    }
    
    $("#diagnosisCodePpAaa").val(diagnosidCode);
}
function selectFindings() {
    var value1 = $("#PpAortaSizeInputText").val().length > 0 ? Number($("#PpAortaSizeInputText").val()) : 0;
    var value2 = $("#PpTVDatapointOneTextbox").val().length > 0 ? Number($("#PpTVDatapointOneTextbox").val()) : 0;
    var value3 = $("#PpTVDatapointTwoTextbox").val().length > 0 ? Number($("#PpTVDatapointTwoTextbox").val()) : 0;

    if (value1 == value2 && value2 == value3) {
        autoSelectFinding($(".gv-Findings-PpAAA"), $("#PpAortaSizeInputText"), 1);
    }
    else if (value1 > value2 && value1 > value3) {
        autoSelectFinding($(".gv-Findings-PpAAA"), $("#PpAortaSizeInputText"), 1);
    }
    else if (value2 > value3) {
        autoSelectFinding($(".gv-Findings-PpAAA"), $("#PpTVDatapointOneTextbox"), 1);
    }
    else {
        autoSelectFinding($(".gv-Findings-PpAAA"), $("#PpTVDatapointTwoTextbox"), 1);
    }
}

var criticalDataModel_PpAaa = null;
function onClick_CriticalDataPpAaa() {
    if ($("#DescribeSelfPresentPpAAAInputCheck").attr("checked")) {
        loadCriticalLink($("#Ppaaa-critical-span"), "onClick_CriticalDataPpAaa();", testTypePpAaa);
        openCriticalDataDialog(testTypePpAaa, $("#conductedbyPpaaa"), $("#DescribeSelfPresentPpAAAInputCheck"), setCriticalDataModel_PpAaa);
    }
    else {
        unloadCriticalLink($("#Ppaaa-critical-span"), testTypePpAaa);
    }
}

function setCriticalDataModel_PpAaa(model, printAfterSave) {
    if (model != null) {
        var testResult = GetPpAAAData();
        saveSingleTestResult(testResult, model, $("#Ppaaa-critical-span"), "onClick_CriticalDataPpAaa();", SetPpAAAData, printAfterSave);
    }
}

function getCriticalDataModel_PpAaa() {
    if ($("#DescribeSelfPresentPpAAAInputCheck").attr("checked") && criticalDataModel_PpAaa != null) {
        criticalDataModel_PpAaa.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_PpAaa;
    }
    return null;
}
function onClick_PriorityInQueueDataPpAAA() {
    if ($("#PriorityInQueueTestPpAAACheck").attr("checked")) {
        loadPriorityInQueueLink($("#ppaaa-priorityInQueue-span"), "onClick_PriorityInQueueDataPpAAA();", testTypePpAaa);
        openPriorityInQueueTestDialog(testTypePpAaa, $("#conductedbyPpaaa"), $("#PriorityInQueueTestPpAAACheck"), setPriorityInQueueDataModel_PpAAA);
    }
    else {
        unloadPriorityInQueueLink($("#ppaaa-priorityInQueue-span"), testTypePpAaa);
    }
}

function setPriorityInQueueDataModel_PpAAA(model) {
    if (model != null) {
        var testResult = GetPpAAAData();
        model.TestId = testTypePpAaa;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#ppaaa-priorityInQueue-span"), "onClick_PriorityInQueueDataPpAAA();", SetPpAAAData);
    }
}

function clearAllPpAaaSelection() {
    $(".gv-Findings-PpAAA input[type=radio], .dtl-sagitalview-finding-PpAAA input[type=checkbox], .dtl-transverseview-finding-PpAAA input[type=checkbox], .dtl-Ppaaa-if input[type=checkbox]").attr("checked", false);
    $("#PpAorticDissectionCheckbox, #PpPlaqueCheckbox, #PpThrombusCheckbox").attr("checked", false);
    setPpAaaDiagnosisCode(null);
}