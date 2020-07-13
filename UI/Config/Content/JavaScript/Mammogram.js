
var testTypeMammogram;
var fileTypeMammogramPDF;
var urlPrefix = getUrlPrefix();

function Mammogram(testResult) {
    if (testResult == null || typeof (testResult) == "undefined") {
        testResult = {
            "Id": 0, "TestType": testTypeMammogram,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": '0',
            "UnableScreenReason": new Array(),
            "ResultImages": null,
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": {
                "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentMammogramInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestMammogramCheck").attr("checked")
            },
            "TestPerformedExternally": null
        };
    }
    this.Result = testResult;
}

Mammogram.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (isMammogramResultentrytype == 'True') {
            setTestPerformedExternally("chk_mammogramcapturebyChat", testResult.TestPerformedExternally)
        }
        $("#DescribeSelfPresentMammogramInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);

        $("#technotesMammogram").val(testResult.TechnicianNotes);
        $("#conductedbyMammogram option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);

        setUnableScreenReason($('.dtl-unabletoscreen-Mammogram'), testResult.UnableScreenReason);

        setTestNotPerformedReasonForMammogram(testResult.TestNotPerformed);

        if (testResult.ResultImage != null) {
            var expr;

            eval("expr = " + testResult.ResultImage.File.UploadedOn + ";");
            eval("testResult.ResultImage.File.UploadedOn = new " + expr.source + ";");

            setmammogramFiles(testResult.ResultImage);
        }
        $("#PriorityInQueueTestMammogramCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.Finding != null) {
            setSelectedFinding($(".gv-findings-Mammogram"), testResult.Finding.Id);
        }
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#mammogram-priorityInQueue-span"), "onClick_PriorityInQueueDataMammogram();", testTypeMammogram);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#mammogram-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#Mammogram-critical-span"), "onClick_CriticalDataMammogram();", testTypeMammogram);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#Mammogram-critical-span").parent().addClass("red-band");
            }
        }
    },
    getData: function () {
        var testResult = this.Result;
        if (isMammogramResultentrytype == 'True') {
             testResult.TestPerformedExternally = getTestPerformedExternally("chk_mammogramcapturebyChat", testResult.TestPerformedExternally)
        }
        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-Mammogram')));

        testResult.TestNotPerformed = getTestNotPerformedReasonForMammogram(testResult.TestNotPerformed);
        
        var mammogramTestFinding = getSelectedFinding($(".gv-findings-Mammogram"));
        testResult.Finding = getFindingDataandSynchronized(testResult.Finding, mammogramTestFinding);

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.ConductedByOrgRoleUserId = $("#conductedbyMammogram option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesMammogram").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentMammogramInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestMammogramCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_29").attr("checked");

        if (currentScreenMode != ScreenMode.Physician) {

            testResult.ResultImage = GetMammogramMedia();

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
            if (testResult.TechnicianNotes.length < 1 && testResult.ConductedByOrgRoleUserId == "0" && testResult.UnableScreenReason == null && $("#DescribeSelfPresentMammogramInputCheck").attr("checked") == false)
                return null;
        }

        return testResult;
    }
}


var criticalDataModel_Mammogram = null;
function onClick_CriticalDataMammogram() {
    if ($("#DescribeSelfPresentMammogramInputCheck").attr("checked")) {
        loadCriticalLink($("#Mammogram-critical-span"), "onClick_CriticalDataMammogram();", testTypeMammogram);
        openCriticalDataDialog(testTypeMammogram, $("#conductedbyMammogram"), $("#DescribeSelfPresentMammogramInputCheck"), setCriticalDataModel_Mammogram);
    }
    else {
        unloadCriticalLink($("#Mammogram-critical-span"), testTypeMammogram);
    }
}

function setCriticalDataModel_Mammogram(model, printAfterSave) {
    if (model != null) {
        var testResult = GetMammogramData();
        saveSingleTestResult(testResult, model, $("#Mammogram-critical-span"), "onClick_CriticalDataMammogram();", SetMammogramData, printAfterSave);
    }
}

function getCriticalDataModel_Mammogram() {
    if ($("#DescribeSelfPresentMammogramInputCheck").attr("checked") && criticalDataModel_Mammogram != null) {
        criticalDataModel_Mammogram.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_Mammogram;
    }
    return null;
}

function onClick_PriorityInQueueDataMammogram() {
    if ($("#PriorityInQueueTestMammogramCheck").attr("checked")) {
        loadPriorityInQueueLink($("#mammogram-priorityInQueue-span"), "onClick_PriorityInQueueDataMammogram();", testTypeMammogram);
        openPriorityInQueueTestDialog(testTypeMammogram, $("#conductedbyMammogram"), $("#PriorityInQueueTestMammogramCheck"), setPriorityInQueueDataModel_Mammogram);
    }
    else {
        unloadPriorityInQueueLink($("#mammogram-priorityInQueue-span"), testTypeMammogram);
    }
}

function setPriorityInQueueDataModel_Mammogram(model) {
    if (model != null) {
        var testResult = GetMammogramData();
        model.TestId = testTypeMammogram;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#mammogram-priorityInQueue-span"), "onClick_PriorityInQueueDataMammogram();", SetMammogramData);
    }
}


/**************Upload Images Start**********************/
var mammogramFileCount = 0;
var mammogramResultMedia = null;

var mammogramPdfPhysicalPath = '';
var mammogramPdfFileSize = 0;
var mammogramPdfPhysicalPathUrl = '';


function setmammogramFiles(jsonMedia) {
    mammogramResultMedia = jsonMedia;
    mammogramFileCount = 0;

    $(".uploadmammogramPDF").attr("src", "/Content/Images/PageNotFound-Icons.jpg");
    $(".pdf-mammogram-remove").hide();

    setMammogramFileUrlAtStartUp(jsonMedia);
}

function setMammogramFileUrlAtStartUp(jsonMedia) {

    if (jsonMedia == null) return;

    var fileName = jsonMedia.File.Path;
    setMammogramFileUrl(fileName, jsonMedia.FileSize);
}

function setMammogramFileUrl(fileName, fileSize) {
    var bolConfirm;

    if (fileName != null && fileName != "") {
        if ($.trim(fileName).length > 0 && mammogramPdfPhysicalPath != null && mammogramPdfPhysicalPath != "") {
            bolConfirm = confirm("This will overwrite your existing Pdf. Do you want to continue?");
            if (!bolConfirm) return;
        }
        setMammogramFileType(fileName, fileSize);
    }
}

function setMammogramFileType(fileName, fileSize) {

    var pdf = $(".uploadmammogramPDF");

    mammogramPdfPhysicalPathUrl = urlPrefix + fileName;
    $(pdf).attr("src", "/App/Images/pdf-icon-mm.gif");

    mammogramPdfPhysicalPath = fileName;
    mammogramPdfFileSize = fileSize;

    $(pdf).unbind("click");

    $(pdf).click(function () {
        window.open(mammogramPdfPhysicalPathUrl, '_blank');
    });

    $(".pdf-mammogram-remove").show();
}

function GetMammogramMedia() {
    if ($.trim(mammogramPdfPhysicalPath).length > 0) {
        if (mammogramResultMedia == null) {
            mammogramResultMedia = {
                "Id": 0,
                "ReadingSource": readingSourceManual,
                "File": { "Path": mammogramPdfPhysicalPath, "FileSize": mammogramPdfFileSize, "Type": fileTypeMammogramPDF }
            };
        } else if (mammogramResultMedia.File.Path != mammogramPdfPhysicalPath) {
            mammogramResultMedia.File.Path = mammogramPdfPhysicalPath;
            mammogramResultMedia.File.FileSize = mammogramPdfFileSize;
        }
    } else {
        mammogramResultMedia = null;
    }

    return mammogramResultMedia;
}

$(document).ready(function () {
    $(".pdf-mammogram-remove").click(function () {
        mammogramPdfPhysicalPath = '';
        mammogramPdfFileSize = 0;

        var pdf = $(".uploadmammogramPDF");
        $(pdf).attr("src", "/Content/Images/PageNotFound-Icons.jpg");

        $(pdf).unbind("click");

        $(this).hide();
    });

});
/**************Upload Images Ends**********************************/

function setTestNotPerformedReasonForMammogram(testNotPerformed) {
    setTestNotPerformed("testnotPerformedMammogram", testNotPerformed);
    SetTestNotPerformedEnableDisabled("testnotPerformedMammogram");
}

function getTestNotPerformedReasonForMammogram(testNotPerformed) {
    return getTestNotPerformed("testnotPerformedMammogram", testNotPerformed);
}

function clearAllMammogramSelection() {
    $(".clear-all-Mammogram-selection input[type=radio], .clear-all-Mammogram-selection input[type=checkbox]").attr("checked", false);
}