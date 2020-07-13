var fileTypePDF;
var urlPrefix = getUrlPrefix();

function QuantaFloABI(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = {
            "Id": 0, "TestType": testTypeQuantaFloABI,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": 0,
            "Finding": null,
            "UnableScreenReason": new Array(),
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": {
                "Id": 0, "SelfPresent": $("#chkselfQuantaFloABI").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestQuantaFloABICheck").attr("checked")
            },
            "TestPerformedExternally": null
        };
    }
    this.Result = testResult;
}

QuantaFloABI.prototype = {
    setData: function () {
        var testResult = this.Result;

        if (isQuantaFloABIResultEntryType == 'True') {
            setTestPerformedExternally("chk_quantafloabicapturebyChat", testResult.TestPerformedExternally)
        }

        if (testResult.ResultImage != null) {
            var newImageArray = new Array();
            newImageArray.push(testResult.ResultImage);
            LoadNewImagesQuantaFloABI(newImageArray, true);
        }

        $("#chkselfQuantaFloABI").attr("checked", testResult.ResultStatus.SelfPresent);

        if (testResult.Finding != null) {
            setSelectedFinding($(".gv-findings-QuantaFloABI"), testResult.Finding.Id);
        }
        
        $("#PriorityInQueueTestQuantaFloABICheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#QuantaFloABI-priorityInQueue-span"), "onClick_PriorityInQueueDataQuantaFloABI();", testTypeQuantaFloABI);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#QuantaFloABI-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }

        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#QuantaFloABI-critical-span"), "onClick_CriticalDataQuantaFloABI();", testTypeQuantaFloABI);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#QuantaFloABI-critical-span").parent().addClass("red-band");
                $("#criticalQuantaFloABI").attr("checked", "checked");
            }
        }

        setUnableScreenReason($('.dtl-unabletoscreen-QuantaFloABI'), testResult.UnableScreenReason);

        setTestNotPerformedReasonForQuantaFloABI(testResult.TestNotPerformed);

        setboolTypeReading($('#repeatstudyQuantaFloABIinputcheck'), testResult.RepeatStudy);

        $("#technotesQuantaFloABI").val(testResult.TechnicianNotes);
        $("#conductedbyQuantaFloABI option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);

        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksQuantaFloABI").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpQuantaFloABI").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalQuantaFloABI").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }
    },
    getData: function () {
        var testResult = this.Result;
        if (isQuantaFloABIResultEntryType == 'True') {
            testResult.TestPerformedExternally = getTestPerformedExternally("chk_quantafloabicapturebyChat", testResult.TestPerformedExternally)
        }

        var quantaFloABITestFinding = getSelectedFinding($(".gv-findings-QuantaFloABI"));
        
        testResult.Finding = getFindingDataandSynchronized(testResult.Finding, quantaFloABITestFinding);

        if (testResult.Finding != null && testResult.Finding.Id > 0) {
            testResult.Finding.WorstCaseOrder = GetQuantaFloABIWorstCaseOrder(testResult.Finding.Id);
        }


        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-QuantaFloABI')));

        testResult.TestNotPerformed = getTestNotPerformedReasonForQuantaFloABI(testResult.TestNotPerformed);

        if (currentScreenMode != ScreenMode.Physician) {

            if (QuantaFloABIResultMedia != null && QuantaFloABIResultMedia.length > 0) {
                if (testResult.ResultImage == null)
                    testResult.ResultImage = QuantaFloABIResultMedia[0];
                else {
                    var resultMedia = QuantaFloABIResultMedia[0];
                    resultMedia.Id = testResult.ResultImage.Id;
                    resultMedia.File.Id = testResult.ResultImage.File.Id;
                    resultMedia.Thumbnail.Id = testResult.ResultImage.Thumbnail.Id;
                    testResult.ResultImage = resultMedia;
                }
            }
            else
                testResult.ResultImage = null;
            
            if (currentScreenMode != ScreenMode.CorrectionPostEvaluation && currentScreenMode != ScreenMode.PostAudit) testResult.ResultStatus.StateNumber = $("#ResultStatusInputHidden").val();

            if (testResult.ResultStatus.Id > 0) {
                testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.ResultStatus.DataRecorderMetaData.DateModified = currentDate;
            } else {
                testResult.ResultStatus.DataRecorderMetaData = { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate };
            }
        }

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.TechnicianNotes = $.trim($("#technotesQuantaFloABI").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ConductedByOrgRoleUserId = $("#conductedbyQuantaFloABI option:selected").val();
            testResult.ResultStatus.SelfPresent = $("#chkselfQuantaFloABI").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestQuantaFloABICheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_94").attr("checked");

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }

        if (currentScreenMode != ScreenMode.Entry) {

            testResult.RepeatStudy = getboolTypeReading($('#repeatstudyQuantaFloABIinputcheck'), testResult.RepeatStudy);

            if (testResult.PhysicianInterpretation == null) {
                testResult.PhysicianInterpretation = {
                    'Remarks': $("#physicianRemarksQuantaFloABI").val(),
                    'IsCritical': $("#criticalQuantaFloABI").attr("checked"),
                    'FollowUp': $("#followUpQuantaFloABI").attr("checked"),
                    'RecorderMetaData': {
                        'DataRecorderCreator': { 'Id': currentUser },
                        'DateCreated': currentDate
                    }
                };
            } else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksQuantaFloABI").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpQuantaFloABI").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalQuantaFloABI").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }

        if (testResult.ResultStatus.StateNumber < 4) {
            if (testResult.UnableScreenReason == null && testResult.Finding == null && QuantaFloABIImageCount == 0
                && testResult.TechnicianNotes.length < 1 && testResult.ConductedByOrgRoleUserId == "0" && $("#chkselfQuantaFloABI").attr("checked") == false)
                return null;
        }

        return testResult;
    }
};

function GetQuantaFloABIWorstCaseOrder(findingId) {
    var worstCase = -1;
    $(".gv-findings-QuantaFloABI tr").each(function () {
        if ($(this).find(".finding-id").val() == findingId) {
            worstCase = $(this).find(".finding-worstcaseorder").val();
            return false;
        }
    });

    return worstCase;
}

var criticalDataModel_QuantaFloABI = null;
function onClick_CriticalDataQuantaFloABI() {
    if ($("#chkselfQuantaFloABI").attr("checked")) {
        loadCriticalLink($("#QuantaFloABI-critical-span"), "onClick_CriticalDataQuantaFloABI();", testTypeQuantaFloABI);
        openCriticalDataDialog(testTypeQuantaFloABI, $("#conductedbyQuantaFloABI"), $("#chkselfQuantaFloABI"), setCriticalDataModel_QuantaFloABI);
    }
    else {
        unloadCriticalLink($("#QuantaFloABI-critical-span"), testTypeQuantaFloABI);
    }
}

function setCriticalDataModel_QuantaFloABI(model, printAfterSave) {
    if (model != null) {
        var testResult = GetQuantaFloABIData();
        saveSingleTestResult(testResult, model, $("#QuantaFloABI-critical-span"), "onClick_CriticalDataQuantaFloABI();", SetQuantaFloABIData, printAfterSave);
    }
}

function getCriticalDataModel_QuantaFloABI() {
    if ($("#chkselfQuantaFloABI").attr("checked") && criticalDataModel_QuantaFloABI != null) {
        criticalDataModel_QuantaFloABI.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_QuantaFloABI;
    }
    return null;
}

//QuantaFloABI-critical-span
function onClick_PriorityInQueueDataQuantaFloABI() {
    if ($("#PriorityInQueueTestQuantaFloABICheck").attr("checked")) {
        loadPriorityInQueueLink($("#QuantaFloABI-priorityInQueue-span"), "onClick_PriorityInQueueDataQuantaFloABI();", testTypeQuantaFloABI);
        openPriorityInQueueTestDialog(testTypeQuantaFloABI, $("#conductedbyQuantaFloABI"), $("#PriorityInQueueTestQuantaFloABICheck"), setPriorityInQueueDataModel_QuantaFloABI);
    }
    else {
        unloadPriorityInQueueLink($("#QuantaFloABI-priorityInQueue-span"), testTypeQuantaFloABI);
    }
}

function setPriorityInQueueDataModel_QuantaFloABI(model) {
    if (model != null) {
        var testResult = GetQuantaFloABIData();
        model.TestId = testTypeQuantaFloABI;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#QuantaFloABI-priorityInQueue-span"), "onClick_PriorityInQueueDataQuantaFloABI();", SetQuantaFloABIData);
    }
}


function checkQuantaFloABIData() {
    var text = "";

    if ($(".dtl-unabletoscreen-QuantaFloABI").find("input[type='checkbox']:checked").length > 0)
        return text;

    if ($("#testnotPerformedQuantaFloABI").find("input[type='checkbox']:checked").length > 0)
        return text;

    var quantaFloAbiTestResult = GetQuantaFloABIData();
    if (quantaFloAbiTestResult != null) {
        if (quantaFloAbiTestResult.Finding == null || quantaFloAbiTestResult.Finding == "") {
            text += "Findings are not marked.";
        }
        if (text != "")
            text = "Quanta Flo ABI Test - " + text;
    }
    return text;
}

function clearAllQuantaFloABISelection() {
    $(".gv-findings-QuantaFloABI input[type=radio]").attr("checked", false);
}


/**************Upload Images Start**********************/
var QuantaFloABIImageCount = 0;
var QuantaFloABIResultMedia = null;
function LoadNewImagesQuantaFloABI(jsonMedia, correctJson) {

    QuantaFloABIResultMedia = jsonMedia;
    QuantaFloABIImageCount = 0;
    $("#QuantaFloABIContainerDiv").empty();
    if (jsonMedia == null || jsonMedia.length < 1) return;
    QuantaFloABIImageCount = jsonMedia.length;
    LoadNewMedia(jsonMedia, correctJson, $("#QuantaFloABIContainerDiv"));
}


function getQuantaFloABIMedia() {
    return QuantaFloABIResultMedia;
}
/**************Upload Images Ends**********************************/


function setTestNotPerformedReasonForQuantaFloABI(testNotPerformed) {
    setTestNotPerformed("testnotPerformedQuantaFloABI", testNotPerformed);
    SetTestNotPerformedEnableDisabled("testnotPerformedQuantaFloABI");
}

function getTestNotPerformedReasonForQuantaFloABI(testNotPerformed) {
    return getTestNotPerformed("testnotPerformedQuantaFloABI", testNotPerformed);
}