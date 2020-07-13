
var testTypeEawv;
var fileTypePDF;
var urlPrefix = getUrlPrefix();

function Eawv(testResult) {
    if (testResult == null || typeof (testResult) == "undefined") {
        testResult = {
            "Id": 0, "TestType": testTypeEawv,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": '0',
            "UnableScreenReason": new Array(),
            "ResultImages": null,
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": {
                "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentEawvInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestEawvCheck").attr("checked")
            },
            "TestPerformedExternally": null
        };
    }
    this.Result = testResult;
}

Eawv.prototype = {
    setData: function () {
        var testResult = this.Result;

        if (isEawvResultEntryType == 'True') {
            setTestPerformedExternally("chk_EawvcapturebyChat", testResult.TestPerformedExternally)
        }

        $("#DescribeSelfPresentEawvInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);

        $("#technotesEawv").val(testResult.TechnicianNotes);
        $("#conductedbyEawv option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);

        setUnableScreenReason($('.dtl-unabletoscreen-Eawv'), testResult.UnableScreenReason);

        setTestNotPerformedReasonForEawv(testResult.TestNotPerformed);
        
        if (testResult.ResultImages != null && testResult.ResultImages.length > 0) {
            seteAwvFiles(testResult.ResultImages);
        }

        $("#PriorityInQueueTestEawvCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#eawv-priorityInQueue-span"), "onClick_PriorityInQueueDataEawv();", testTypeEawv);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#eawv-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#Eawv-critical-span"), "onClick_CriticalDataEawv();", testTypeEawv);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#Eawv-critical-span").parent().addClass("red-band");
            }
        }
    },
    getData: function () {
        var testResult = this.Result;
        if (isEawvResultEntryType == 'True') {
            testResult.TestPerformedExternally = getTestPerformedExternally("chk_EawvcapturebyChat", testResult.TestPerformedExternally)
        }
        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-Eawv')));

        testResult.TestNotPerformed = getTestNotPerformedReasonForEawv(testResult.TestNotPerformed);

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.ConductedByOrgRoleUserId = $("#conductedbyEawv option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesEawv").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentEawvInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestEawvCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_81").attr("checked");

        if (currentScreenMode != ScreenMode.Physician) {

            testResult.ResultImages = GeteAwvMedia();

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
            if (testResult.TechnicianNotes.length < 1 && testResult.ConductedByOrgRoleUserId == "0" && testResult.UnableScreenReason == null && $("#DescribeSelfPresentEawvInputCheck").attr("checked") == false)
                return null;
        }

        return testResult;
    }
}


var criticalDataModel_Eawv = null;
function onClick_CriticalDataEawv() {
    if ($("#DescribeSelfPresentEawvInputCheck").attr("checked")) {
        loadCriticalLink($("#Eawv-critical-span"), "onClick_CriticalDataEawv();", testTypeEawv);
        openCriticalDataDialog(testTypeEawv, $("#conductedbyEawv"), $("#DescribeSelfPresentEawvInputCheck"), setCriticalDataModel_Eawv);
    }
    else {
        unloadCriticalLink($("#Eawv-critical-span"), testTypeEawv);
    }
}

function setCriticalDataModel_Eawv(model, printAfterSave) {
    if (model != null) {
        var testResult = GetEAWVData();
        saveSingleTestResult(testResult, model, $("#Eawv-critical-span"), "onClick_CriticalDataEawv();", SetEAWVData, printAfterSave);
    }
}

function getCriticalDataModel_Eawv() {
    if ($("#DescribeSelfPresentEawvInputCheck").attr("checked") && criticalDataModel_Eawv != null) {
        criticalDataModel_Eawv.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_Eawv;
    }
    return null;
}

function onClick_PriorityInQueueDataEawv() {
    if ($("#PriorityInQueueTestEawvCheck").attr("checked")) {
        loadPriorityInQueueLink($("#eawv-priorityInQueue-span"), "onClick_PriorityInQueueDataEawv();", testTypeEawv);
        openPriorityInQueueTestDialog(testTypeEawv, $("#conductedbyEawv"), $("#PriorityInQueueTestEawvCheck"), setPriorityInQueueDataModel_Eawv);
    }
    else {
        unloadPriorityInQueueLink($("#eawv-priorityInQueue-span"), testTypeEawv);
    }
}

function setPriorityInQueueDataModel_Eawv(model) {
    if (model != null) {
        var testResult = GetEAWVData();
        model.TestId = testTypeEawv;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#eawv-priorityInQueue-span"), "onClick_PriorityInQueueDataEawv();", SetEAWVData);
    }
}


/**************Upload Images Start**********************/
var eawvFileCount = 0;
var eawvResultMedia = null;

var eawvPreventionPlanPdfPhysicalPath = '';
var eawvPreventionPlanPdfFileSize = 0;

var eawvSnapshotPdfPhysicalPath = '';
var eawvSnapshotPdfFileSize = 0;

var eawvResultExportPdfPhysicalPath = '';
var eawvResultExportPdfFileSize = 0;

function seteAwvFiles(jsonMedia) {
    eawvResultMedia = jsonMedia;
    eawvFileCount = 0;

    $(".uploadeAwvPDF").attr("src", "/Content/Images/PageNotFound-Icons.jpg");
    $(".pdf-remove-eAwv").hide();

    if (jsonMedia == null || jsonMedia.length < 1) return;
    eawvFileCount = jsonMedia.length;

    seteAwvFileUrlAtStartUp(jsonMedia);
}

function seteAwvFileUrlAtStartUp(jsonMedia) {
    var index = 0;

    if (jsonMedia == null || jsonMedia.length < 1) return;

    while (index < jsonMedia.length) {

        var fileName = jsonMedia[index].File.Path;

        seteAwvFileUrl(fileName, jsonMedia[index].FileSize);
        index = index + 1;
    }
}

function seteAwvFileUrl(fileName, fileSize) {
    var bolConfirm;
    var eawvPreventionPlan = fileName.toLowerCase().match(preventionPlanFileType.toLowerCase());
    var eawvsnapshotmatch = fileName.toLowerCase().match(snapshotSummaryFileType.toLowerCase());
    var eawvResultExport = fileName.toLowerCase().match(resultExportFileType.toLowerCase());

    if (eawvPreventionPlan != null && eawvPreventionPlan != "") {
        if ($.trim(eawvPreventionPlanPdfPhysicalPath).length > 0) {
            bolConfirm = confirm("This will overwrite your existing Pdf. Do you want to continue?");
            if (!bolConfirm) return;
        }
        seteAwvPreventionPlanFileType(fileName, fileSize);
    } else if (eawvsnapshotmatch != null && eawvsnapshotmatch != "") {
        if ($.trim(eawvSnapshotPdfPhysicalPath).length > 0) {
            bolConfirm = confirm("This will overwrite your existing Pdf. Do you want to continue?");
            if (!bolConfirm) return;
        }
        seteAwvSnapshotFile(fileName, fileSize);
    } else if (eawvResultExport != null && eawvResultExport != "") {
        if ($.trim(eawvResultExportPdfPhysicalPath).length > 0) {
            bolConfirm = confirm("This will overwrite your existing Pdf. Do you want to continue?");
            if (!bolConfirm) return;
        }
        seteAwvResultExportFile(fileName, fileSize);
    }
}

function seteAwvPreventionPlanFileType(fileName, fileSize) {

    var pdf = $(".uploadeAwvPDF." + preventionPlanFileType);
    var url = urlPrefix + fileName;
    $(pdf).attr("src", "/App/Images/pdf-icon-mm.gif");

    eawvPreventionPlanPdfPhysicalPath = fileName;
    eawvPreventionPlanPdfFileSize = fileSize;

    $(pdf).unbind("click");

    $(pdf).click(function () {
        window.open(url, '_blank');
    });

    $(".pdf-remove-eAwv." + preventionPlanFileType).show();
}

function seteAwvSnapshotFile(fileName, fileSize) {

    var pdf = $(".uploadeAwvPDF." + snapshotSummaryFileType);
    var url = urlPrefix + fileName;
    $(pdf).attr("src", "/App/Images/pdf-icon-mm.gif");

    eawvSnapshotPdfPhysicalPath = fileName;
    eawvSnapshotPdfFileSize = fileSize;

    $(pdf).unbind("click");

    $(pdf).click(function () {
        window.open(url, '_blank');
    });

    $(".pdf-remove-eAwv." + snapshotSummaryFileType).show();
}

function seteAwvResultExportFile(fileName, fileSize) {

    var pdf = $(".uploadeAwvPDF." + resultExportFileType);
    var url = urlPrefix + fileName;
    $(pdf).attr("src", "/App/Images/pdf-icon-mm.gif");

    eawvResultExportPdfPhysicalPath = fileName;
    eawvResultExportPdfFileSize = fileSize;

    $(pdf).unbind("click");

    $(pdf).click(function () {
        window.open(url, '_blank');
    });

    $(".pdf-remove-eAwv." + resultExportFileType).show();
}

function GeteAwvMedia() {
    var pdfFiles = new Array();
    if (eawvResultMedia == null || eawvResultMedia.length < 1) {

        if ($.trim(eawvPreventionPlanPdfPhysicalPath).length > 0) {
            pdfFiles.push({
                "Id": 0,
                "ReadingSource": readingSourceManual,
                "File": { "Path": eawvPreventionPlanPdfPhysicalPath, "FileSize": eawvPreventionPlanPdfFileSize, "Type": fileTypePDF }
            });
        }
        if ($.trim(eawvSnapshotPdfPhysicalPath).length > 0) {
            pdfFiles.push({
                "Id": 0,
                "ReadingSource": readingSourceManual,
                "File": { "Path": eawvSnapshotPdfPhysicalPath, "FileSize": eawvSnapshotPdfFileSize, "Type": fileTypePDF }
            });
        }
        if ($.trim(eawvResultExportPdfPhysicalPath).length > 0) {
            pdfFiles.push({
                "Id": 0,
                "ReadingSource": readingSourceManual,
                "File": { "Path": eawvResultExportPdfPhysicalPath, "FileSize": eawvResultExportPdfFileSize, "Type": fileTypePDF }
            });
        }
    } else {
        var index = 0;
        while (index < eawvResultMedia.length) {
            var expr = null;
            eval("expr = " + eawvResultMedia[index].File.UploadedOn + ";");
            eval("eawvResultMedia[index].File.UploadedOn = new " + expr.source + ";");

            var pdfObject = null;
            pdfObject = eawvResultMedia[index];
            var fileName = pdfObject.File.Path;

            var eawvpreventionPlan = fileName.match(preventionPlanFileType.toLowerCase());
            var eawvsnapshotmatch = fileName.match(snapshotSummaryFileType.toLowerCase());
            var eawvResultExport = fileName.match(resultExportFileType.toLowerCase());

            if (eawvpreventionPlan != null && eawvpreventionPlan != "" && eawvPreventionPlanPdfPhysicalPath != '') {
                pdfObject.File.Path = eawvPreventionPlanPdfPhysicalPath;
                pdfObject.File.FileSize = eawvPreventionPlanPdfFileSize;
                pdfFiles.push(pdfObject);

                eawvPreventionPlanPdfPhysicalPath = '';
            }
            else if (eawvsnapshotmatch != null && eawvsnapshotmatch != "" && eawvSnapshotPdfPhysicalPath != '') {

                pdfObject.File.Path = eawvSnapshotPdfPhysicalPath;
                pdfObject.File.FileSize = eawvSnapshotPdfFileSize;
                pdfFiles.push(pdfObject);

                eawvSnapshotPdfPhysicalPath = '';
            }
            else if (eawvResultExport != null && eawvResultExport != "" && eawvResultExportPdfPhysicalPath != '') {

                pdfObject.File.Path = eawvResultExportPdfPhysicalPath;
                pdfObject.File.FileSize = eawvResultExportPdfFileSize;
                pdfFiles.push(pdfObject);

                eawvResultExportPdfPhysicalPath = '';
            }
            index = index + 1;
        }
        if (eawvPreventionPlanPdfPhysicalPath != '') {
            pdfFiles.push({
                "Id": 0,
                "ReadingSource": readingSourceManual,
                "File": { "Path": eawvPreventionPlanPdfPhysicalPath, "FileSize": eawvPreventionPlanPdfFileSize, "Type": fileTypePDF }
            });
        }
        if (eawvSnapshotPdfPhysicalPath != '') {
            pdfFiles.push({
                "Id": 0,
                "ReadingSource": readingSourceManual,
                "File": { "Path": eawvSnapshotPdfPhysicalPath, "FileSize": eawvSnapshotPdfFileSize, "Type": fileTypePDF }
            });
        }
        if (eawvResultExportPdfPhysicalPath != '') {
            pdfFiles.push({
                "Id": 0,
                "ReadingSource": readingSourceManual,
                "File": { "Path": eawvResultExportPdfPhysicalPath, "FileSize": eawvResultExportPdfFileSize, "Type": fileTypePDF }
            });
        }
    }
    return pdfFiles;
}

$(document).ready(function () {
    $(".pdf-remove-eAwv." + preventionPlanFileType).click(function () {
        eawvPreventionPlanPdfPhysicalPath = '';
        eawvPreventionPlanPdfFileSize = 0;

        var pdf = $(".uploadeAwvPDF." + preventionPlanFileType);
        $(pdf).attr("src", "/Content/Images/PageNotFound-Icons.jpg");

        $(pdf).unbind("click");

        $(this).hide();
    });

    $(".pdf-remove-eAwv." + snapshotSummaryFileType).click(function () {
        eawvSnapshotPdfPhysicalPath = '';
        eawvSnapshotPdfFileSize = 0;

        var pdf = $(".uploadeAwvPDF." + snapshotSummaryFileType);
        $(pdf).attr("src", "/Content/Images/PageNotFound-Icons.jpg");

        $(pdf).unbind("click");

        $(this).hide();
    });

    $(".pdf-remove-eAwv." + resultExportFileType).click(function () {
        eawvResultExportPdfPhysicalPath = '';
        eawvResultExportPdfFileSize = 0;

        var pdf = $(".uploadeAwvPDF." + resultExportFileType);
        $(pdf).attr("src", "/Content/Images/PageNotFound-Icons.jpg");

        $(pdf).unbind("click");

        $(this).hide();
    });

});
/**************Upload Images Ends**********************************/


function setTestNotPerformedReasonForEawv(testNotPerformed) {
    setTestNotPerformed("testnotPerformedEawv", testNotPerformed);
    SetTestNotPerformedEnableDisabled("testnotPerformedEawv");
}

function getTestNotPerformedReasonForEawv(testNotPerformed) {
    return getTestNotPerformed("testnotPerformedEawv", testNotPerformed);
}

function isEawvTestNotPerformedChecked() {
    return $("#testnotPerformedEawv").find("input[type='checkbox']").is(":checked");
}