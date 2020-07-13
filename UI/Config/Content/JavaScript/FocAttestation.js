
var testTypeFocAttestation;
var fileTypeFocAttestationPDF;
var urlPrefix = getUrlPrefix();

function FocAttestation(testResult) {
    if (testResult == null || typeof (testResult) == "undefined") {
        testResult = {
            "Id": 0, "TestType": testTypeFocAttestation,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": '0',
            "UnableScreenReason": new Array(),
            "ResultImages": null,
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": {
                "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentFocAttestationInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestFocAttestationCheck").attr("checked")
            },
            "TestPerformedExternally": null
        };
    }
    this.Result = testResult;
}

FocAttestation.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (isFocAttestationResultEntryType == 'True') {
            setTestPerformedExternally("chk_focattestationcapturebyChat", testResult.TestPerformedExternally)
        }
        $("#DescribeSelfPresentFocAttestationInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);

        $("#technotesFocAttestation").val(testResult.TechnicianNotes);
        $("#conductedbyFocAttestation option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);

        setUnableScreenReason($('.dtl-unabletoscreen-FocAttestation'), testResult.UnableScreenReason);

        setTestNotPerformedReasonForFocAttestation(testResult.TestNotPerformed);

        if (testResult.ResultImage != null) {
            var expr;

            eval("expr = " + testResult.ResultImage.File.UploadedOn + ";");
            eval("testResult.ResultImage.File.UploadedOn = new " + expr.source + ";");

            setfocAttestationFiles(testResult.ResultImage);
        }
        $("#PriorityInQueueTestFocAttestationCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#focAttestation-priorityInQueue-span"), "onClick_PriorityInQueueDataFocAttestation();", testTypeFocAttestation);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#focAttestation-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#FocAttestation-critical-span"), "onClick_CriticalDataFocAttestation();", testTypeFocAttestation);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#FocAttestation-critical-span").parent().addClass("red-band");
            }
        }
    },
    getData: function () {
        var testResult = this.Result;
        if (isFocAttestationResultEntryType == 'True') {
            testResult.TestPerformedExternally = getTestPerformedExternally("chk_focattestationcapturebyChat", testResult.TestPerformedExternally)
        }
        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-FocAttestation')));

        testResult.TestNotPerformed = getTestNotPerformedReasonForFocAttestation(testResult.TestNotPerformed);

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.ConductedByOrgRoleUserId = $("#conductedbyFocAttestation option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesFocAttestation").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentFocAttestationInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestFocAttestationCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_92").attr("checked");

        if (currentScreenMode != ScreenMode.Physician) {

            testResult.ResultImage = GetFocAttestationMedia();

            if (currentScreenMode != ScreenMode.CorrectionPostEvaluation && currentScreenMode != ScreenMode.PostAudit) testResult.ResultStatus.StateNumber = $("#ResultStatusInputHidden").val();

            if (testResult.ResultStatus.Id > 0) {
                testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.ResultStatus.DataRecorderMetaData.DateModified = currentDate;
            }
            else {
                testResult.ResultStatus.DataRecorderMetaData = { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate };
            }
        }

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }

        if (testResult.ResultStatus.StateNumber < 4) {
            if (testResult.TechnicianNotes.length < 1 && testResult.ConductedByOrgRoleUserId == "0" && testResult.UnableScreenReason == null && $("#DescribeSelfPresentFocAttestationInputCheck").attr("checked") == false)
                return null;
        }

        return testResult;
    }
}


var criticalDataModel_FocAttestation = null;
function onClick_CriticalDataFocAttestation() {
    if ($("#DescribeSelfPresentFocAttestationInputCheck").attr("checked")) {
        loadCriticalLink($("#FocAttestation-critical-span"), "onClick_CriticalDataFocAttestation();", testTypeFocAttestation);
        openCriticalDataDialog(testTypeFocAttestation, $("#conductedbyFocAttestation"), $("#DescribeSelfPresentFocAttestationInputCheck"), setCriticalDataModel_FocAttestation);
    }
    else {
        unloadCriticalLink($("#FocAttestation-critical-span"), testTypeFocAttestation);
    }
}

function setCriticalDataModel_FocAttestation(model, printAfterSave) {
    if (model != null) {
        var testResult = GetFocAttestationData();
        saveSingleTestResult(testResult, model, $("#FocAttestation-critical-span"), "onClick_CriticalDataFocAttestation();", SetFocAttestationData, printAfterSave);
    }
}

function getCriticalDataModel_FocAttestation() {
    if ($("#DescribeSelfPresentFocAttestationInputCheck").attr("checked") && criticalDataModel_FocAttestation != null) {
        criticalDataModel_FocAttestation.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_FocAttestation;
    }
    return null;
}

function onClick_PriorityInQueueDataFocAttestation() {
    if ($("#PriorityInQueueTestFocAttestationCheck").attr("checked")) {
        loadPriorityInQueueLink($("#focAttestation-priorityInQueue-span"), "onClick_PriorityInQueueDataFocAttestation();", testTypeFocAttestation);
        openPriorityInQueueTestDialog(testTypeFocAttestation, $("#conductedbyFocAttestation"), $("#PriorityInQueueTestFocAttestationCheck"), setPriorityInQueueDataModel_FocAttestation);
    }
    else {
        unloadPriorityInQueueLink($("#focAttestation-priorityInQueue-span"), testTypeFocAttestation);
    }
}

function setPriorityInQueueDataModel_FocAttestation(model) {
    if (model != null) {
        var testResult = GetFocAttestationData();
        model.TestId = testTypeFocAttestation;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#focAttestation-priorityInQueue-span"), "onClick_PriorityInQueueDataFocAttestation();", SetFocAttestationData);
    }
}


/**************Upload Images Start**********************/
var focAttestationFileCount = 0;
var focAttestationResultMedia = null;

var focAttestationPdfPhysicalPath = '';
var focAttestationPdfFileSize = 0;
var focAttestationPdfPhysicalPathUrl = '';


function setfocAttestationFiles(jsonMedia) {
    focAttestationResultMedia = jsonMedia;
    focAttestationFileCount = 0;

    $(".uploadfocAttestationPDF").attr("src", "/Content/Images/PageNotFound-Icons.jpg");
    $(".pdf-focAttestation-remove").hide();

    setFocAttestationFileUrlAtStartUp(jsonMedia);
}

function setFocAttestationFileUrlAtStartUp(jsonMedia) {

    if (jsonMedia == null) return;

    var fileName = jsonMedia.File.Path;
    setFocAttestationFileUrl(fileName, jsonMedia.FileSize);
}

function setFocAttestationFileUrl(fileName, fileSize) {
    var bolConfirm;

    if (fileName != null && fileName != "") {
        if ($.trim(fileName).length > 0 && focAttestationPdfPhysicalPath != null && focAttestationPdfPhysicalPath != "") {
            bolConfirm = confirm("This will overwrite your existing Pdf. Do you want to continue?");
            if (!bolConfirm) return;
        }
        setFocAttestationFileType(fileName, fileSize);
    }
}

function setFocAttestationFileType(fileName, fileSize) {

    var pdf = $(".uploadfocAttestationPDF");

    focAttestationPdfPhysicalPathUrl = urlPrefix + fileName;
    $(pdf).attr("src", "/App/Images/pdf-icon-mm.gif");

    focAttestationPdfPhysicalPath = fileName;
    focAttestationPdfFileSize = fileSize;

    $(pdf).unbind("click");

    $(pdf).click(function () {
        window.open(focAttestationPdfPhysicalPathUrl, '_blank');
    });

    $(".pdf-focAttestation-remove").show();
}

function GetFocAttestationMedia() {
    if ($.trim(focAttestationPdfPhysicalPath).length > 0) {
        if (focAttestationResultMedia == null) {
            focAttestationResultMedia = {
                "Id": 0,
                "ReadingSource": readingSourceManual,
                "File": { "Path": focAttestationPdfPhysicalPath, "FileSize": focAttestationPdfFileSize, "Type": fileTypeFocAttestationPDF }
            };
        } else if (focAttestationResultMedia.File.Path != focAttestationPdfPhysicalPath) {
            focAttestationResultMedia.File.Path = focAttestationPdfPhysicalPath;
            focAttestationResultMedia.File.FileSize = focAttestationPdfFileSize;
        }
    } else {
        focAttestationResultMedia = null;
    }

    return focAttestationResultMedia;
}

$(document).ready(function () {
    $(".pdf-focAttestation-remove").click(function () {
        focAttestationPdfPhysicalPath = '';
        focAttestationPdfFileSize = 0;

        var pdf = $(".uploadfocAttestationPDF");
        $(pdf).attr("src", "/Content/Images/PageNotFound-Icons.jpg");

        $(pdf).unbind("click");

        $(this).hide();
    });
    
});
/**************Upload Images Ends**********************************/

function setTestNotPerformedReasonForFocAttestation(testNotPerformed) {
    setTestNotPerformed("testnotPerformedFocAttestation", testNotPerformed);
    SetTestNotPerformedEnableDisabled("testnotPerformedFocAttestation");
}

function getTestNotPerformedReasonForFocAttestation(testNotPerformed) {
    return getTestNotPerformed("testnotPerformedFocAttestation", testNotPerformed);
}
