var testTypeAwv;
var fileTypePDF;
var preventionPlanFileType;
var snapshotSummaryFileType;
var urlPrefix = getUrlPrefix();

function Awv(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = {
            "Id": 0, "TestType": testTypeAwv,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": '0',
            "UnableScreenReason": new Array(),
            "ResultImages": null,
            "TestPerformedExternally": null,
             
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": {
                "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentAwvInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestAwvCheck").attr("checked")
            }
        };
    }
    this.Result = testResult;
}

Awv.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (IsawvResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_AwvcapturebyChat", testResult.TestPerformedExternally)
        }

        $("#DescribeSelfPresentAwvInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);

        $("#technotesAwv").val(testResult.TechnicianNotes);
        $("#conductedbyAwv option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);

        setUnableScreenReason($('.dtl-unabletoscreen-Awv'), testResult.UnableScreenReason);


        if (testResult.ResultImages != null && testResult.ResultImages.length > 0) {
            setAwvFiles(testResult.ResultImages);
        }

        $("#PriorityInQueueTestAwvCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#awv-priorityInQueue-span"), "onClick_PriorityInQueueDataAwv();", testTypeAwv);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#awv-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#Awv-critical-span"), "onClick_CriticalDataAwv();", testTypeAwv);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#Awv-critical-span").parent().addClass("red-band");
            }
        }
    },
    getData: function () {
        var testResult = this.Result;
        if (IsawvResultEntryExternaly == 'True') {
            testResult.TestPerformedExternally = getTestPerformedExternally("chk_AwvcapturebyChat", testResult.TestPerformedExternally)
        }

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-Awv')));

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.ConductedByOrgRoleUserId = $("#conductedbyAwv option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesAwv").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentAwvInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestAwvCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_32").attr("checked");

        if (currentScreenMode != ScreenMode.Physician) {
            testResult.ResultImages = GetMedia();

            if (currentScreenMode != ScreenMode.CorrectionPostEvaluation) testResult.ResultStatus.StateNumber = $("#ResultStatusInputHidden").val();

            if (testResult.ResultStatus.Id > 0) {
                testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.ResultStatus.DataRecorderMetaData.DateModified = currentDate;
            }
            else {
                testResult.ResultStatus.DataRecorderMetaData = { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate };
            }
        }

        if (testResult.ResultStatus.StateNumber < 4) {
            if (testResult.TechnicianNotes.length < 1 && testResult.ConductedByOrgRoleUserId == "0" && testResult.UnableScreenReason == null && $("#DescribeSelfPresentAwvInputCheck").attr("checked") == false)
                return null;
        }

        return testResult;
    }
}

var criticalDataModel_Awv = null;
function onClick_CriticalDataAwv() {
    if ($("#DescribeSelfPresentAwvInputCheck").attr("checked")) {
        loadCriticalLink($("#Awv-critical-span"), "onClick_CriticalDataAwv();", testTypeAwv);
        openCriticalDataDialog(testTypeAwv, $("#conductedbyAwv"), $("#DescribeSelfPresentAwvInputCheck"), setCriticalDataModel_Awv);
    }
    else {
        unloadCriticalLink($("#Awv-critical-span"), testTypeAwv);
    }
}

function setCriticalDataModel_Awv(model, printAfterSave) {
    if (model != null) {
        var testResult = GetAwvData();
        saveSingleTestResult(testResult, model, $("#Awv-critical-span"), "onClick_CriticalDataAwv();", SetAwvData, printAfterSave);
    }
}

function getCriticalDataModel_Awv() {
    if ($("#DescribeSelfPresentAwvInputCheck").attr("checked") && criticalDataModel_Awv != null) {
        criticalDataModel_Awv.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_Awv;
    }
    return null;
}

function onClick_PriorityInQueueDataAwv() {
    if ($("#PriorityInQueueTestAwvCheck").attr("checked")) {
        loadPriorityInQueueLink($("#awv-priorityInQueue-span"), "onClick_PriorityInQueueDataAwv();", testTypeAwv);
        openPriorityInQueueTestDialog(testTypeAwv, $("#conductedbyAwv"), $("#PriorityInQueueTestAwvCheck"), setPriorityInQueueDataModel_Awv);
    }
    else {
        unloadPriorityInQueueLink($("#awv-priorityInQueue-span"), testTypeAwv);
    }
}

function setPriorityInQueueDataModel_Awv(model) {
    if (model != null) {
        var testResult = GetAwvData();
        model.TestId = testTypeAwv;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#awv-priorityInQueue-span"), "onClick_PriorityInQueueDataAwv();", SetAwvData);
    }
}

/**************Upload Images Start**********************/
var awvFileCount = 0;
var awvResultMedia = null;

var awvPreventionPlanPdfPhysicalPath = '';
var awvPreventionPlanPdfFileSize = 0;

var awvSnapshotPdfPhysicalPath = '';
var awvSnapshotPdfFileSize = 0;

function setAwvFiles(jsonMedia) {
    awvResultMedia = jsonMedia;
    awvFileCount = 0;

    $(".uploadAwvPDF").attr("src", "/Content/Images/PageNotFound-Icons.jpg");
    $(".pdf-remove").hide();

    if (jsonMedia == null || jsonMedia.length < 1) return;
    awvFileCount = jsonMedia.length;

    setAwvFileUrlAtStartUp(jsonMedia);
}

function setAwvFileUrlAtStartUp(jsonMedia) {
    var index = 0;
  
    if (jsonMedia == null || jsonMedia.length < 1) return;

    while (index < jsonMedia.length) {
       
        var fileName = jsonMedia[index].File.Path;

        setAwvFileUrl(fileName, jsonMedia[index].FileSize);
        index = index + 1;
    }
}

function setAwvFileUrl(fileName, fileSize) {

    var bolConfirm;
    var awvPreventionPlan = fileName.toLowerCase().match(preventionPlanFileType.toLowerCase());
    var snapshotmatch = fileName.toLowerCase().match(snapshotSummaryFileType.toLowerCase());

    if (awvPreventionPlan != null && awvPreventionPlan != "") {
        if ($.trim(awvPreventionPlanPdfPhysicalPath).length > 0) {
            bolConfirm = confirm("This will overwrite your existing Pdf. Do you want to continue?");
            if (!bolConfirm) return;
        }
        setPreventionPlanFileType(fileName, fileSize);
    }else if (snapshotmatch != null && snapshotmatch != "") {
        if ($.trim(awvSnapshotPdfPhysicalPath).length > 0) {
            bolConfirm = confirm("This will overwrite your existing Pdf. Do you want to continue?");
            if (!bolConfirm) return;
        }
        setSnapshotFile(fileName, fileSize);
    }
}

function setPreventionPlanFileType(fileName, fileSize) {

    var pdf = $(".uploadAwvPDF." + preventionPlanFileType);
    var url = urlPrefix + fileName;
    $(pdf).attr("src", "/App/Images/pdf-icon-mm.gif");

    awvPreventionPlanPdfPhysicalPath = fileName;
    awvPreventionPlanPdfFileSize = fileSize;

    $(pdf).unbind("click");
    
    $(pdf).click(function () {
        window.open(url, '_blank');
    });

    $(".pdf-remove." + preventionPlanFileType).show();
}

function setSnapshotFile(fileName, fileSize) {

    var pdf = $(".uploadAwvPDF." + snapshotSummaryFileType);
    var url = urlPrefix + fileName;
    $(pdf).attr("src", "/App/Images/pdf-icon-mm.gif");

    awvSnapshotPdfPhysicalPath = fileName;
    awvSnapshotPdfFileSize = fileSize;

    $(pdf).unbind("click");
    
    $(pdf).click(function () {
        window.open(url, '_blank');
    });

    $(".pdf-remove." + snapshotSummaryFileType).show();
}


function GetMedia() {
    var pdfFiles = new Array();
    if (awvResultMedia == null || awvResultMedia.length < 1) {

        if ($.trim(awvPreventionPlanPdfPhysicalPath).length > 0) {
            pdfFiles.push({
                "Id": 0,
                "ReadingSource": readingSourceManual,
                "File": { "Path": awvPreventionPlanPdfPhysicalPath, "FileSize": awvPreventionPlanPdfFileSize, "Type": fileTypePDF }
            });
        }
        if ($.trim(awvSnapshotPdfPhysicalPath).length > 0) {
            pdfFiles.push({
                "Id": 0,
                "ReadingSource": readingSourceManual,
                "File": { "Path": awvSnapshotPdfPhysicalPath, "FileSize": awvSnapshotPdfFileSize, "Type": fileTypePDF }
            });
        }
    } else {
        var index = 0;
        while (index < awvResultMedia.length) {
            var expr = null;
            eval("expr = " + awvResultMedia[index].File.UploadedOn + ";");
            eval("awvResultMedia[index].File.UploadedOn = new " + expr.source + ";");

            var pdfObject = null;
            pdfObject = awvResultMedia[index];
            var fileName = pdfObject.File.Path;

            var awvpreventionPlan = fileName.match(preventionPlanFileType.toLowerCase());
            var snapshotmatch = fileName.match(snapshotSummaryFileType.toLowerCase());

            if (awvpreventionPlan != null && awvpreventionPlan != "" && awvPreventionPlanPdfPhysicalPath != '') {
                pdfObject.File.Path = awvPreventionPlanPdfPhysicalPath;
                pdfObject.File.FileSize = awvPreventionPlanPdfFileSize;
                pdfFiles.push(pdfObject);

                awvPreventionPlanPdfPhysicalPath = '';
            }
            else if (snapshotmatch != null && snapshotmatch != "" && awvSnapshotPdfPhysicalPath != '') {

                pdfObject.File.Path = awvSnapshotPdfPhysicalPath;
                pdfObject.File.FileSize = awvSnapshotPdfFileSize;
                pdfFiles.push(pdfObject);

                awvSnapshotPdfPhysicalPath = '';
            }
            index = index + 1;
        }
        if (awvPreventionPlanPdfPhysicalPath != '') {
            pdfFiles.push({
                "Id": 0,
                "ReadingSource": readingSourceManual,
                "File": { "Path": awvPreventionPlanPdfPhysicalPath, "FileSize": awvPreventionPlanPdfFileSize, "Type": fileTypePDF }
            });
        }
        if (awvSnapshotPdfPhysicalPath != '') {
            pdfFiles.push({
                "Id": 0,
                "ReadingSource": readingSourceManual,
                "File": { "Path": awvSnapshotPdfPhysicalPath, "FileSize": awvSnapshotPdfFileSize, "Type": fileTypePDF }
            });
        }
    }
    return pdfFiles;
}

$(document).ready(function () {
    $(".pdf-remove." + preventionPlanFileType).click(function () {
        awvPreventionPlanPdfPhysicalPath = '';
        awvPreventionPlanPdfFileSize = 0;

        var pdf = $(".uploadAwvPDF." + preventionPlanFileType);
        $(pdf).attr("src", "/Content/Images/PageNotFound-Icons.jpg");

        $(pdf).unbind("click");
        
        $(this).hide();
    });

    $(".pdf-remove." + snapshotSummaryFileType).click(function () {
        awvSnapshotPdfPhysicalPath = '';
        awvSnapshotPdfFileSize = 0;

        var pdf = $(".uploadAwvPDF." + snapshotSummaryFileType);
        $(pdf).attr("src", "/Content/Images/PageNotFound-Icons.jpg");

        $(pdf).unbind("click");
        
        $(this).hide();
    });

});
/**************Upload Images Ends**********************************/

