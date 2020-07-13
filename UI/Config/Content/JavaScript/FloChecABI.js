var fileTypePDF;
var urlPrefix = getUrlPrefix();

function FloChecABI(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = {
            "LeftResultReadings": { "BFI": null, "ABI": null },
            "RightResultReadings": { "BFI": null, "ABI": null },
            "Id": 0, "TestType": testTypeFloChecABI,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": 0,
            "Finding": null,
            "UnableScreenReason": new Array(),
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": {
                "Id": 0, "SelfPresent": $("#chkselfFloChecABI").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestFloChecABICheck").attr("checked")
            },
            "TestPerformedExternally": null
        };
    }
    this.Result = testResult;
}

FloChecABI.prototype = {
    setData: function () {
        var testResult = this.Result;

        if (isFloChecABIResultEntryType == 'True') {
            setTestPerformedExternally("chk_FloChecABIcapturebyChat", testResult.TestPerformedExternally)
        }
        if (testResult.LeftResultReadings != null) {
            setReading($("#txtLeftBFI"), testResult.LeftResultReadings.BFI);
            setReading($("#txtLeftFloChecABI"), testResult.LeftResultReadings.ABI);
        }

        if (testResult.RightResultReadings != null) {
            setReading($("#txtRightBFI"), testResult.RightResultReadings.BFI);
            setReading($("#txtRightFloChecABI"), testResult.RightResultReadings.ABI);
        }

        if (testResult.ResultImage != null) {
            var newImageArray = new Array();
            newImageArray.push(testResult.ResultImage);
            LoadNewImagesFloChecABI(newImageArray, true);
        }

        $("#chkselfFloChecABI").attr("checked", testResult.ResultStatus.SelfPresent);

        if (testResult.Finding != null) {
            setSelectedFinding($(".gv-findings-FloChecABI"), testResult.Finding.Id);
        }
        $("#PriorityInQueueTestFloChecABICheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#FloChecABI-priorityInQueue-span"), "onClick_PriorityInQueueDataFloChecABI();", testTypeFloChecABI);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#FloChecABI-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }

        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#FloChecABI-critical-span"), "onClick_CriticalDataFloChecABI();", testTypeFloChecABI);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#FloChecABI-critical-span").parent().addClass("red-band");
                $("#criticalFloChecABI").attr("checked", "checked");
            }
        }

        setUnableScreenReason($('.dtl-unabletoscreen-FloChecABI'), testResult.UnableScreenReason);

        setTestNotPerformedReasonForFloChecABI(testResult.TestNotPerformed);

        setboolTypeReading($('#repeatstudyFloChecABIinputcheck'), testResult.RepeatStudy);

        $("#technotesFloChecABI").val(testResult.TechnicianNotes);
        $("#conductedbyFloChecABI option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);

        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksFloChecABI").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpFloChecABI").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalFloChecABI").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }
    },
    getData: function () {
        var testResult = this.Result;

        if (isFloChecABIResultEntryType == 'True') {
            testResult.TestPerformedExternally = getTestPerformedExternally("chk_FloChecABIcapturebyChat", testResult.TestPerformedExternally)
        }
        var floChecABITestFinding = getSelectedFinding($(".gv-findings-FloChecABI"));
        testResult.Finding = getFindingDataandSynchronized(testResult.Finding, floChecABITestFinding);

        if (testResult.Finding != null && testResult.Finding.Id > 0) {
            testResult.Finding.WorstCaseOrder = GetWorstCaseOrder(testResult.Finding.Id);
        }


        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-FloChecABI')));

        testResult.TestNotPerformed = getTestNotPerformedReasonForFloChecABI(testResult.TestNotPerformed);

        if (testResult.RightResultReadings == null) {
            testResult.RightResultReadings = { "BFI": null, "ABI": null };
        }

        if (testResult.LeftResultReadings == null) {
            testResult.LeftResultReadings = { "BFI": null, "ABI": null };
        }


        testResult.RightResultReadings.BFI = getReading($("#txtRightBFI"), testResult.RightResultReadings.BFI);
        testResult.RightResultReadings.ABI = getReading($("#txtRightFloChecABI"), testResult.RightResultReadings.ABI);


        testResult.LeftResultReadings.BFI = getReading($("#txtLeftBFI"), testResult.LeftResultReadings.BFI);
        testResult.LeftResultReadings.ABI = getReading($("#txtLeftFloChecABI"), testResult.LeftResultReadings.ABI);

        if (currentScreenMode != ScreenMode.Physician) {

            if (FloChecABIResultMedia != null && FloChecABIResultMedia.length > 0) {
                if (testResult.ResultImage == null)
                    testResult.ResultImage = FloChecABIResultMedia[0];
                else {
                    var resultMedia = FloChecABIResultMedia[0];
                    resultMedia.Id = testResult.ResultImage.Id;
                    resultMedia.File.Id = testResult.ResultImage.File.Id;
                    resultMedia.Thumbnail.Id = testResult.ResultImage.Thumbnail.Id;
                    testResult.ResultImage = resultMedia;
                }
            }
            else
                testResult.ResultImage = null;

            //if (testResult.RightResultReadings == null) {
            //    testResult.RightResultReadings = { "BFI": null, "ABI": null };
            //}

            //if (testResult.LeftResultReadings == null) {
            //    testResult.LeftResultReadings = { "BFI": null, "ABI": null };
            //}


            //testResult.RightResultReadings.BFI = getReading($("#txtRightBFI"), testResult.RightResultReadings.BFI);
            //testResult.RightResultReadings.ABI = getReading($("#txtRightFloChecABI"), testResult.RightResultReadings.ABI);


            //testResult.LeftResultReadings.BFI = getReading($("#txtLeftBFI"), testResult.LeftResultReadings.BFI);
            //testResult.LeftResultReadings.ABI = getReading($("#txtLeftFloChecABI"), testResult.LeftResultReadings.ABI);

            if (currentScreenMode != ScreenMode.CorrectionPostEvaluation && currentScreenMode != ScreenMode.PostAudit) testResult.ResultStatus.StateNumber = $("#ResultStatusInputHidden").val();

            if (testResult.ResultStatus.Id > 0) {
                testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.ResultStatus.DataRecorderMetaData.DateModified = currentDate;
            } else {
                testResult.ResultStatus.DataRecorderMetaData = { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate };
            }
        }

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.TechnicianNotes = $.trim($("#technotesFloChecABI").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ConductedByOrgRoleUserId = $("#conductedbyFloChecABI option:selected").val();
            testResult.ResultStatus.SelfPresent = $("#chkselfFloChecABI").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestFloChecABICheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_88").attr("checked");

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }

        if (currentScreenMode != ScreenMode.Entry) {

            testResult.RepeatStudy = getboolTypeReading($('#repeatstudyFloChecABIinputcheck'), testResult.RepeatStudy);

            if (testResult.PhysicianInterpretation == null) {
                testResult.PhysicianInterpretation = {
                    'Remarks': $("#physicianRemarksFloChecABI").val(),
                    'IsCritical': $("#criticalFloChecABI").attr("checked"),
                    'FollowUp': $("#followUpFloChecABI").attr("checked"),
                    'RecorderMetaData': {
                        'DataRecorderCreator': { 'Id': currentUser },
                        'DateCreated': currentDate
                    }
                };
            } else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksFloChecABI").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpFloChecABI").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalFloChecABI").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }

        if (testResult.ResultStatus.StateNumber < 4) {
            if (testResult.UnableScreenReason == null && testResult.Finding == null
                && testResult.LeftResultReadings.ABI == null && testResult.LeftResultReadings.BFI == null
                && testResult.RightResultReadings.ABI == null && testResult.RightResultReadings.BFI == null
                && FloChecABIImageCount == 0
                && testResult.TechnicianNotes.length < 1 && testResult.ConductedByOrgRoleUserId == "0" && $("#chkselfFloChecABI").attr("checked") == false)
                return null;
        }

        return testResult;
    }
};



$(document).ready(function () {
    //debugger;
    $("#txtRightFloChecABI").change(function () { SetOnChangeFloChecABIValue($(this), $(this).val(), $("#txtLeftFloChecABI").val(), "Right"); });
    $("#txtLeftFloChecABI").change(function () { SetOnChangeFloChecABIValue($(this), $(this).val(), $("#txtRightFloChecABI").val(), "Left"); });
});

function SetOnChangeFloChecABIValue(curentObject, currentObjectValue, otherValue, currentSelection) {

    $(".gv-findings-FloChecABI tr").each(function () {
        $(this).find(".rbt-finding").attr("checked", false);
    });

    if ($.trim(currentObjectValue).length < 1 && $.trim(otherValue).length < 1)
        return;

    var rightAbiValue = '';
    var leftAbiValue = '';

    if (currentSelection == "Right") {
        var rightAbiValue = currentObjectValue;
        var leftAbiValue = otherValue;
    }
    else if (currentSelection == "Left") {
        var rightAbiValue = otherValue;
        var leftAbiValue = currentObjectValue;
    }

    var comparisonString = '';

    if ($.trim(rightAbiValue).length < 0) rightAbiValue = '0.00';

    if ($.trim(leftAbiValue).length < 0) leftAbiValue = '0.00';

    var findingSelectionForLeftAbi, findingSelectionForRightAbi;
    findingSelectionForRightAbi = GetFindingReference(rightAbiValue);
    findingSelectionForLeftAbi = GetFindingReference(leftAbiValue);

    var findingToConsider = GetFindingToConsider(findingSelectionForLeftAbi, findingSelectionForRightAbi);
    if (findingToConsider != null) {
        $(".gv-findings-FloChecABI tr").each(function () {
            if ($(this).find(".finding-id").val() == findingToConsider) {
                $(this).find(".rbt-finding").attr("checked", true);
            }
        });
    }
}

function GetFindingToConsider(findingSelectionForLeftAbi, findingSelectionForRightAbi) {
    if (findingSelectionForLeftAbi == null && findingSelectionForRightAbi == null)
        return null;

    var worstCaseLeft = findingSelectionForLeftAbi != null ? GetWorstCaseOrder(Number(findingSelectionForLeftAbi)) : -1;
    var worstCaseRight = findingSelectionForRightAbi != null ? GetWorstCaseOrder(Number(findingSelectionForRightAbi)) : -1;

    if (worstCaseLeft == worstCaseRight && worstCaseLeft == -1) return null;

    return (worstCaseLeft > worstCaseRight ? findingSelectionForLeftAbi : findingSelectionForRightAbi);
}

function GetFindingReference(readingVal) {
    readingVal = parseFloat(readingVal).toFixed(2);

    var findingReference = null;
    $(".gv-findings-FloChecABI tr").each(function () {
        var minValue = $(this).find(".finding-minvalue").val();
        var maxValue = $(this).find(".finding-maxvalue").val();

        if (minValue.length > 0 && maxValue.length > 0) {
            if (Number(readingVal) >= Number(minValue) && Number(readingVal) <= Number(maxValue)) {
                findingReference = $(this).find(".finding-id").val();
                return;
            }
        }
        else if (minValue.length > 0) {
            if (Number(readingVal) >= Number(minValue)) {
                findingReference = $(this).find(".finding-id").val();
                return;
            }
        }
        else if (maxValue.length > 0) {
            if (Number(readingVal) <= Number(maxValue)) {
                findingReference = $(this).find(".finding-id").val();
                return;
            }
        }

        $(this).find(".rbt-finding-FloChecABI").attr("checked", false);

    });

    return findingReference;
}

function GetWorstCaseOrder(findingId) {
    var worstCase = -1;
    $(".gv-findings-FloChecABI tr").each(function () {
        if ($(this).find(".finding-id").val() == findingId) {
            worstCase = $(this).find(".finding-worstcaseorder").val();
            return false;
        }
    });

    return worstCase;
}


var criticalDataModel_FloChecABI = null;
function onClick_CriticalDataFloChecABI() {
    if ($("#chkselfFloChecABI").attr("checked")) {
        loadCriticalLink($("#FloChecABI-critical-span"), "onClick_CriticalDataFloChecABI();", testTypeFloChecABI);
        openCriticalDataDialog(testTypeFloChecABI, $("#conductedbyFloChecABI"), $("#chkselfFloChecABI"), setCriticalDataModel_FloChecABI);
    }
    else {
        unloadCriticalLink($("#FloChecABI-critical-span"), testTypeFloChecABI);
    }
}

function setCriticalDataModel_FloChecABI(model, printAfterSave) {
    if (model != null) {
        var testResult = GetFloChecABIData();
        saveSingleTestResult(testResult, model, $("#FloChecABI-critical-span"), "onClick_CriticalDataFloChecABI();", SetFloChecABIData, printAfterSave);
    }
}

function getCriticalDataModel_FloChecABI() {
    if ($("#chkselfFloChecABI").attr("checked") && criticalDataModel_FloChecABI != null) {
        criticalDataModel_FloChecABI.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_FloChecABI;
    }
    return null;
}

//FloChecABI-critical-span
function onClick_PriorityInQueueDataFloChecABI() {
    if ($("#PriorityInQueueTestFloChecABICheck").attr("checked")) {
        loadPriorityInQueueLink($("#FloChecABI-priorityInQueue-span"), "onClick_PriorityInQueueDataFloChecABI();", testTypeFloChecABI);
        openPriorityInQueueTestDialog(testTypeFloChecABI, $("#conductedbyFloChecABI"), $("#PriorityInQueueTestFloChecABICheck"), setPriorityInQueueDataModel_FloChecABI);
    }
    else {
        unloadPriorityInQueueLink($("#FloChecABI-priorityInQueue-span"), testTypeFloChecABI);
    }
}

function setPriorityInQueueDataModel_FloChecABI(model) {
    if (model != null) {
        var testResult = GetFloChecABIData();
        model.TestId = testTypeFloChecABI;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#FloChecABI-priorityInQueue-span"), "onClick_PriorityInQueueDataFloChecABI();", SetFloChecABIData);
    }
}


function checkFloChecABIData() {
    var text = "";

    if ($(".dtl-unabletoscreen-FloChecABI").find("input[type='checkbox']:checked").length > 0)
        return text;

    if ($("#testnotPerformedFloChecABI").find("input[type='checkbox']:checked").length > 0)
        return text;

    var floChecABITestResult = GetFloChecABIData();
    if (floChecABITestResult != null) {
        /*if (floChecABITestResult.RightResultReadings.ABI == null || floChecABITestResult.RightResultReadings.ABI == "")
            text += "Right ABI value is missing.";

        if (floChecABITestResult.LeftResultReadings.ABI == null || floChecABITestResult.LeftResultReadings.ABI == "")
            text += " Left ABI value is missing.";*/

        if (floChecABITestResult.Finding == null || floChecABITestResult.Finding == "") {
            text += "Findings are not marked.";
        }

        if (text != "")
            text = "FloChec ABI Test - " + text;
    }
    return text;
}

function clearAllFloChecABISelection() {
    $(".gv-findings-FloChecABI input[type=radio]").attr("checked", false);
}


/**************Upload Images Start**********************/
var FloChecABIImageCount = 0;
var FloChecABIResultMedia = null;
function LoadNewImagesFloChecABI(jsonMedia, correctJson) {

    FloChecABIResultMedia = jsonMedia;
    FloChecABIImageCount = 0;
    $("#FloChecABIContainerDiv").empty();
    if (jsonMedia == null || jsonMedia.length < 1) return;
    FloChecABIImageCount = jsonMedia.length;
    LoadNewMedia(jsonMedia, correctJson, $("#FloChecABIContainerDiv"));
}
/**************Upload Images Ends**********************************/


function setTestNotPerformedReasonForFloChecABI(testNotPerformed) {
    setTestNotPerformed("testnotPerformedFloChecABI", testNotPerformed);
    SetTestNotPerformedEnableDisabled("testnotPerformedFloChecABI");
}

function getTestNotPerformedReasonForFloChecABI(testNotPerformed) {
    return getTestNotPerformed("testnotPerformedFloChecABI", testNotPerformed);
}