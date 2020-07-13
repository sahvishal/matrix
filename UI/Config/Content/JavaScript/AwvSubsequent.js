function AwvSubsequent(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = {
            "Id": 0, "TestType": testTypeAwvSubsequent,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": '0',
            "UnableScreenReason": new Array(),
            "ResultImages": null,
            "TestPerformedExternally": null,
             
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": {
                "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentAwvSubsequentInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestAwvSubsequentCheck").attr("checked")
            }
        };
    }
    this.Result = testResult;
}

AwvSubsequent.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (IsawvSubsequentResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_AwvSubsequentcapturebyChat", testResult.TestPerformedExternally)
        }

        $("#DescribeSelfPresentAwvSubsequentInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);

        $("#technotesAwvSubsequent").val(testResult.TechnicianNotes);
        $("#conductedbyAwvSubsequent option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);

        setUnableScreenReason($('.dtl-unabletoscreen-AwvSubsequent'), testResult.UnableScreenReason);

        if (testResult.ResultImages != null && testResult.ResultImages.length > 0) {
            setSubsequentFiles(testResult.ResultImages);
        }
        $("#PriorityInQueueTestAwvSubsequentCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#awvSubsequent-priorityInQueue-span"), "onClick_PriorityInQueueDataAwvSubsequent();", testTypeAwvSubsequent);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#awvSubsequent-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#AwvSubsequent-critical-span"), "onClick_CriticalDataAwvSubsequent();", testTypeAwvSubsequent);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#AwvSubsequent-critical-span").parent().addClass("red-band");
            }
        }
    },
    getData: function () {
        var testResult = this.Result;
        if (IsawvSubsequentResultEntryExternaly == 'True') {
             testResult.TestPerformedExternally = getTestPerformedExternally("chk_AwvSubsequentcapturebyChat", testResult.TestPerformedExternally)
        }

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-AwvSubsequent')));

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.ConductedByOrgRoleUserId = $("#conductedbyAwvSubsequent option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesAwvSubsequent").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentAwvSubsequentInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestAwvSubsequentCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_41").attr("checked");

        if (currentScreenMode != ScreenMode.Physician) {
                testResult.ResultImages = GetSubsequentMedia();

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
            if (testResult.TechnicianNotes.length < 1 && testResult.ConductedByOrgRoleUserId == "0" && testResult.UnableScreenReason == null && $("#DescribeSelfPresentAwvSubsequentInputCheck").attr("checked") == false)
                return null;
        }

        return testResult;
    }
}


var criticalDataModel_AwvSubsequent = null;
function onClick_CriticalDataAwvSubsequent() {
    if ($("#DescribeSelfPresentAwvSubsequentInputCheck").attr("checked")) {
        loadCriticalLink($("#AwvSubsequent-critical-span"), "onClick_CriticalDataAwvSubsequent();", testTypeAwvSubsequent);
        openCriticalDataDialog(testTypeAwvSubsequent, $("#conductedbyAwvSubsequent"), $("#DescribeSelfPresentAwvSubsequentInputCheck"), setCriticalDataModel_AwvSubsequent);
    }
    else {
        unloadCriticalLink($("#AwvSubsequent-critical-span"), testTypeAwvSubsequent);
    }
}

function setCriticalDataModel_AwvSubsequent(model, printAfterSave) {
    if (model != null) {
        var testResult = GetAwvSubsequentData();
        saveSingleTestResult(testResult, model, $("#AwvSubsequent-critical-span"), "onClick_CriticalDataAwvSubsequent();", SetAwvSubsequentData, printAfterSave);
    }
}

function getCriticalDataModel_AwvSubsequent() {
    if ($("#DescribeSelfPresentAwvSubsequentInputCheck").attr("checked") && criticalDataModel_AwvSubsequent != null) {
        criticalDataModel_AwvSubsequent.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_AwvSubsequent;
    }
    return null;
}

function onClick_PriorityInQueueDataAwvSubsequent() {
    if ($("#PriorityInQueueTestAwvSubsequentCheck").attr("checked")) {
        loadPriorityInQueueLink($("#awvSubsequent-priorityInQueue-span"), "onClick_PriorityInQueueDataAwvSubsequent();", testTypeAwvSubsequent);
        openPriorityInQueueTestDialog(testTypeAwvSubsequent, $("#conductedbyAwvSubsequent"), $("#PriorityInQueueTestAwvSubsequentCheck"), setPriorityInQueueDataModel_AwvSubsequent);
    }
    else {
        unloadPriorityInQueueLink($("#awvSubsequent-priorityInQueue-span"), testTypeAwvSubsequent);
    }
}

function setPriorityInQueueDataModel_AwvSubsequent(model) {
    if (model != null) {
        var testResult = GetAwvSubsequentData();
        model.TestId = testTypeAwvSubsequent;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#awvSubsequent-priorityInQueue-span"), "onClick_PriorityInQueueDataAwvSubsequent();", SetAwvSubsequentData);
    }
}


/**************Upload Images Start**********************/
var subsequentFileCount = 0;
var subsequentResultMedia = null;

var subsequentPreventionPlanPdfPhysicalPath = '';
var subsequentPreventionPlanPdfFileSize = 0;

var subsequentSnapshotPdfPhysicalPath = '';
var subsequentSnapshotPdfFileSize = 0;

function setSubsequentFiles(jsonMedia) {
    subsequentResultMedia = jsonMedia;
    subsequentFileCount = 0;

    $(".uploadsubsequentPDF").attr("src", "/Content/Images/PageNotFound-Icons.jpg");
    $(".uploadsubsequentPDF").attr("src", "/Content/Images/PageNotFound-Icons.jpg");
    $(".pdf-subsequent-remove").hide();

    if (jsonMedia == null || jsonMedia.length < 1) return;
    subsequentFileCount = jsonMedia.length;

    setsubsequentFileUrlAtStartUp(jsonMedia);
}

function setsubsequentFileUrlAtStartUp(jsonMedia) {
    var index = 0;

    if (jsonMedia == null || jsonMedia.length < 1) return;

    while (index < jsonMedia.length) {

        var fileName = jsonMedia[index].File.Path;
        setSubsequentFileUrl(fileName, jsonMedia[index].FileSize);
        index = index + 1;
    }
}

function setSubsequentFileUrl(fileName, fileSize) {
    var bolConfirm;
   
    var subsequentPreventionPlan = fileName.toLowerCase().match(preventionPlanFileType.toLowerCase());
    var snapshotmatch = fileName.toLowerCase().match(snapshotSummaryFileType.toLowerCase());

    if (subsequentPreventionPlan != null && subsequentPreventionPlan != "") {
        if ($.trim(subsequentPreventionPlanPdfPhysicalPath).length > 0) {
            bolConfirm = confirm("This will overwrite your existing Pdf. Do you want to continue?");
            if (!bolConfirm) return;
        }
        setSubsequentPreventionPlanFileType(fileName, fileSize);
    } else if (snapshotmatch != null && snapshotmatch != "") {
        if ($.trim(subsequentSnapshotPdfPhysicalPath).length > 0) {
            bolConfirm = confirm("This will overwrite your existing Pdf. Do you want to continue?");
            if (!bolConfirm) return;
        }
        setSubsequentSnapshotFile(fileName, fileSize);
    }
}

function setSubsequentPreventionPlanFileType(fileName, fileSize) {

    var pdf = $(".uploadsubsequentPDF." + preventionPlanFileType);
    var url = getUrlPrefix() + fileName;
    $(pdf).attr("src", "/App/Images/pdf-icon-mm.gif");

    subsequentPreventionPlanPdfPhysicalPath = fileName;
    subsequentPreventionPlanPdfFileSize = fileSize;

    $(pdf).unbind("click");
    
    $(pdf).click(function () {
        window.open(url, '_blank');
    });

    $(".pdf-subsequent-remove." + preventionPlanFileType).show();
}

function setSubsequentSnapshotFile(fileName, fileSize) {

    var pdf = $(".uploadsubsequentPDF." + snapshotSummaryFileType);
    var url = getUrlPrefix() + fileName;
    $(pdf).attr("src", "/App/Images/pdf-icon-mm.gif");

    subsequentSnapshotPdfPhysicalPath = fileName;
    subsequentSnapshotPdfFileSize = fileSize;

    $(pdf).unbind("click");
    
    $(pdf).click(function () {
        window.open(url, '_blank');
    });

    $(".pdf-subsequent-remove." + snapshotSummaryFileType).show();
}


function GetSubsequentMedia() {
    var pdfFiles = new Array();
    if (subsequentResultMedia == null || subsequentResultMedia.length < 1) {

        if ($.trim(subsequentPreventionPlanPdfPhysicalPath).length > 0) {
            pdfFiles.push({
                "Id": 0,
                "ReadingSource": readingSourceManual,
                "File": { "Path": subsequentPreventionPlanPdfPhysicalPath, "FileSize": subsequentPreventionPlanPdfFileSize, "Type": fileTypePDF }
            });
        }
        if ($.trim(subsequentSnapshotPdfPhysicalPath).length > 0) {
            pdfFiles.push({
                "Id": 0,
                "ReadingSource": readingSourceManual,
                "File": { "Path": subsequentSnapshotPdfPhysicalPath, "FileSize": subsequentSnapshotPdfFileSize, "Type": fileTypePDF }
            });
        }
    } else {
        var index = 0;
        while (index < subsequentResultMedia.length) {
            var expr = null;
            eval("expr = " + subsequentResultMedia[index].File.UploadedOn + ";");
            eval("subsequentResultMedia[index].File.UploadedOn = new " + expr.source + ";");

            var pdfObject = null;
            pdfObject = subsequentResultMedia[index];
            var fileName = pdfObject.File.Path;

            var subsequentpreventionPlan = fileName.match(preventionPlanFileType.toLowerCase());
            var snapshotmatch = fileName.match(snapshotSummaryFileType.toLowerCase());

            if (subsequentpreventionPlan != null && subsequentpreventionPlan != "" && subsequentPreventionPlanPdfPhysicalPath != '') {
                pdfObject.File.Path = subsequentPreventionPlanPdfPhysicalPath;
                pdfObject.File.FileSize = subsequentPreventionPlanPdfFileSize;
                pdfFiles.push(pdfObject);

                subsequentPreventionPlanPdfPhysicalPath = '';
            }
            else if (snapshotmatch != null && snapshotmatch != "" && subsequentSnapshotPdfPhysicalPath != '') {

                pdfObject.File.Path = subsequentSnapshotPdfPhysicalPath;
                pdfObject.File.FileSize = subsequentSnapshotPdfFileSize;
                pdfFiles.push(pdfObject);

                subsequentSnapshotPdfPhysicalPath = '';
            }
            index = index + 1;
        }
        if (subsequentPreventionPlanPdfPhysicalPath != '') {
            pdfFiles.push({
                "Id": 0,
                "ReadingSource": readingSourceManual,
                "File": { "Path": subsequentPreventionPlanPdfPhysicalPath, "FileSize": subsequentPreventionPlanPdfFileSize, "Type": fileTypePDF }
            });
        }
        if (subsequentSnapshotPdfPhysicalPath != '') {
            pdfFiles.push({
                "Id": 0,
                "ReadingSource": readingSourceManual,
                "File": { "Path": subsequentSnapshotPdfPhysicalPath, "FileSize": subsequentSnapshotPdfFileSize, "Type": fileTypePDF }
            });
        }
    }
    return pdfFiles;
}

$(document).ready(function () {
    $(".pdf-subsequent-remove." + preventionPlanFileType).click(function () {
        subsequentPreventionPlanPdfPhysicalPath = '';
        subsequentPreventionPlanPdfFileSize = 0;

        var pdf = $(".uploadsubsequentPDF." + preventionPlanFileType);
        $(pdf).attr("src", "/Content/Images/PageNotFound-Icons.jpg");

        $(pdf).unbind("click");
        
        $(this).hide();
    });

    $(".pdf-subsequent-remove." + snapshotSummaryFileType).click(function () {
        subsequentSnapshotPdfPhysicalPath = '';
        subsequentSnapshotPdfFileSize = 0;

        var pdf = $(".uploadsubsequentPDF." + snapshotSummaryFileType);
        $(pdf).attr("src", "/Content/Images/PageNotFound-Icons.jpg");

        $(pdf).unbind("click");
        
        $(this).hide();
    });

});
/**************Upload Images Ends**********************************/