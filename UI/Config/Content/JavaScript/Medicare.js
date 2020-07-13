var preventionPlanFileType;
var snapshotSummaryFileType;
var testTypeMedicare;
var fileTypePDF;
var urlPrefix = getUrlPrefix();
function Medicare(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = {
            "Id": 0, "TestType": testTypeMedicare,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": '0',
            "UnableScreenReason": new Array(),
            "ResultImages": null,
            "TestPerformedExternally": null,
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": {
                "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentMedicareInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestMedicareCheck").attr("checked")
            }
        };
    }
    this.Result = testResult;
}

Medicare.prototype = {
    setData: function () {
        var testResult = this.Result;

        if (IsmedicareResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_MedicarecapturebyChat", testResult.TestPerformedExternally)
        }

        $("#DescribeSelfPresentMedicareInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);

        $("#technotesMedicare").val(testResult.TechnicianNotes);
        $("#conductedbyMedicare option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);

        setUnableScreenReason($('.dtl-unabletoscreen-Medicare'), testResult.UnableScreenReason);

        if (testResult.ResultImages != null && testResult.ResultImages.length > 0) {
            setmedicareFiles(testResult.ResultImages);
        }
        $("#PriorityInQueueTestMedicareCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#medicare-priorityInQueue-span"), "onClick_PriorityInQueueDataMedicare();", testTypeMedicare);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#medicare-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#Medicare-critical-span"), "onClick_CriticalDataMedicare();", testTypeMedicare);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#Medicare-critical-span").parent().addClass("red-band");
            }
        }
    },
    getData: function () {
        var testResult = this.Result;
        if (IsmedicareResultEntryExternaly == 'True') {
             testResult.TestPerformedExternally = getTestPerformedExternally("chk_MedicarecapturebyChat", testResult.TestPerformedExternally)
        }

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-Medicare')));

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.ConductedByOrgRoleUserId = $("#conductedbyMedicare option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesMedicare").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentMedicareInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestMedicareCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_34").attr("checked");

        if (currentScreenMode != ScreenMode.Physician) {
            
            testResult.ResultImages = GetMedicareMedia();

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
            if (testResult.TechnicianNotes.length < 1 && testResult.ConductedByOrgRoleUserId == "0" && testResult.UnableScreenReason == null && $("#DescribeSelfPresentMedicareInputCheck").attr("checked") == false)
                return null;
        }

        return testResult;
    }
}


var criticalDataModel_Medicare = null;
function onClick_CriticalDataMedicare() {
    if ($("#DescribeSelfPresentMedicareInputCheck").attr("checked")) {
        loadCriticalLink($("#Medicare-critical-span"), "onClick_CriticalDataMedicare();", testTypeMedicare);
        openCriticalDataDialog(testTypeMedicare, $("#conductedbyMedicare"), $("#DescribeSelfPresentMedicareInputCheck"), setCriticalDataModel_Medicare);
    }
    else {
        unloadCriticalLink($("#Medicare-critical-span"), testTypeMedicare);
    }
}

function setCriticalDataModel_Medicare(model, printAfterSave) {
    if (model != null) {
        var testResult = GetMedicareData();
        saveSingleTestResult(testResult, model, $("#Medicare-critical-span"), "onClick_CriticalDataMedicare();", SetMedicareData, printAfterSave);
    }
}

function getCriticalDataModel_Medicare() {
    if ($("#DescribeSelfPresentMedicareInputCheck").attr("checked") && criticalDataModel_Medicare != null) {
        criticalDataModel_Medicare.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_Medicare;
    }
    return null;
}

function onClick_PriorityInQueueDataMedicare() {
    if ($("#PriorityInQueueTestMedicareCheck").attr("checked")) {
        loadPriorityInQueueLink($("#medicare-priorityInQueue-span"), "onClick_PriorityInQueueDataMedicare();", testTypeMedicare);
        openPriorityInQueueTestDialog(testTypeMedicare, $("#conductedbyMedicare"), $("#PriorityInQueueTestMedicareCheck"), setPriorityInQueueDataModel_Medicare);
    }
    else {
        unloadPriorityInQueueLink($("#medicare-priorityInQueue-span"), testTypeMedicare);
    }
}

function setPriorityInQueueDataModel_Medicare(model) {
    if (model != null) {
        var testResult = GetMedicareData();
        model.TestId = testTypeMedicare;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#medicare-priorityInQueue-span"), "onClick_PriorityInQueueDataMedicare();", SetMedicareData);
    }
}


/**************Upload Images Start**********************/
var medicareFileCount = 0;
var medicareResultMedia = null;

var medicarePreventionPlanPdfPhysicalPath = '';
var medicarePreventionPlanPdfFileSize = 0;

var medicareSnapshotPdfPhysicalPath = '';
var medicareSnapshotPdfFileSize = 0;

function setmedicareFiles(jsonMedia) {
    medicareResultMedia = jsonMedia;
    medicareFileCount = 0;

    $(".uploadmedicarePDF").attr("src", "/Content/Images/PageNotFound-Icons.jpg");
    $(".pdf-medicare-remove").hide();

    if (jsonMedia == null || jsonMedia.length < 1) return;
    medicareFileCount = jsonMedia.length;

    setmedicareFileUrlAtStartUp(jsonMedia);
}

function setmedicareFileUrlAtStartUp(jsonMedia) {
    var index = 0;

    if (jsonMedia == null || jsonMedia.length < 1) return;

    while (index < jsonMedia.length) {

        var fileName = jsonMedia[index].File.Path;
        setMedicareFileUrl(fileName, jsonMedia[index].FileSize);
        index = index + 1;
    }
}

function setMedicareFileUrl(fileName, fileSize) {
    var bolConfirm;

    var medicarePreventionPlan = fileName.toLowerCase().match(preventionPlanFileType.toLowerCase());
    var snapshotmatch = fileName.toLowerCase().match(snapshotSummaryFileType.toLowerCase());

    if (medicarePreventionPlan != null && medicarePreventionPlan != "") {
        if ($.trim(medicarePreventionPlanPdfPhysicalPath).length > 0) {
            bolConfirm = confirm("This will overwrite your existing Pdf. Do you want to continue?");
            if (!bolConfirm) return;
        }
        setmedicarePreventionPlanFileType(fileName, fileSize);
    } else if (snapshotmatch != null && snapshotmatch != "") {
        if ($.trim(medicareSnapshotPdfPhysicalPath).length > 0) {
            bolConfirm = confirm("This will overwrite your existing Pdf. Do you want to continue?");
            if (!bolConfirm) return;
        }
        setmedicareSnapshotFile(fileName, fileSize);
    }
}

function setmedicarePreventionPlanFileType(fileName, fileSize) {
    
    var pdf = $(".uploadmedicarePDF." + preventionPlanFileType);
    
    var url = urlPrefix + fileName;
    $(pdf).attr("src", "/App/Images/pdf-icon-mm.gif");

    medicarePreventionPlanPdfPhysicalPath = fileName;
    medicarePreventionPlanPdfFileSize = fileSize;

    $(pdf).unbind("click");
    
    $(pdf).click(function () {
        window.open(url, '_blank');
    });

    $(".pdf-medicare-remove." + preventionPlanFileType).show();
}

function setmedicareSnapshotFile(fileName, fileSize) {

    var pdf = $(".uploadmedicarePDF." + snapshotSummaryFileType);
    
    var url = urlPrefix + fileName;
    $(pdf).attr("src", "/App/Images/pdf-icon-mm.gif");

    medicareSnapshotPdfPhysicalPath = fileName;
    medicareSnapshotPdfFileSize = fileSize;

    $(pdf).unbind("click");
    
    $(pdf).click(function () {
        window.open(url, '_blank');
    });

    $(".pdf-medicare-remove." + snapshotSummaryFileType).show();
}


function GetMedicareMedia() {
    var pdfFiles = new Array();
    if (medicareResultMedia == null || medicareResultMedia.length < 1) {

        if ($.trim(medicarePreventionPlanPdfPhysicalPath).length > 0) {
            pdfFiles.push({
                "Id": 0,
                "ReadingSource": readingSourceManual,
                "File": { "Path": medicarePreventionPlanPdfPhysicalPath, "FileSize": medicarePreventionPlanPdfFileSize, "Type": fileTypePDF }
            });
        }
        if ($.trim(medicareSnapshotPdfPhysicalPath).length > 0) {
            pdfFiles.push({
                "Id": 0,
                "ReadingSource": readingSourceManual,
                "File": { "Path": medicareSnapshotPdfPhysicalPath, "FileSize": medicareSnapshotPdfFileSize, "Type": fileTypePDF }
            });
        }
    } else {
        var index = 0;
        while (index < medicareResultMedia.length) {
            var expr = null;
            eval("expr = " + medicareResultMedia[index].File.UploadedOn + ";");
            eval("medicareResultMedia[index].File.UploadedOn = new " + expr.source + ";");

            var pdfObject = null;
            pdfObject = medicareResultMedia[index];
            var fileName = pdfObject.File.Path;

            var medicarepreventionPlan = fileName.match(preventionPlanFileType.toLowerCase());
            var snapshotmatch = fileName.match(snapshotSummaryFileType.toLowerCase());

            if (medicarepreventionPlan != null && medicarepreventionPlan != "" && medicarePreventionPlanPdfPhysicalPath != '') {
                pdfObject.File.Path = medicarePreventionPlanPdfPhysicalPath;
                pdfObject.File.FileSize = medicarePreventionPlanPdfFileSize;
                pdfFiles.push(pdfObject);

                medicarePreventionPlanPdfPhysicalPath = '';
            }
            else if (snapshotmatch != null && snapshotmatch != "" && medicareSnapshotPdfPhysicalPath != '') {

                pdfObject.File.Path = medicareSnapshotPdfPhysicalPath;
                pdfObject.File.FileSize = medicareSnapshotPdfFileSize;
                pdfFiles.push(pdfObject);

                medicareSnapshotPdfPhysicalPath = '';
            }
            index = index + 1;
        }
        if (medicarePreventionPlanPdfPhysicalPath != '') {
            pdfFiles.push({
                "Id": 0,
                "ReadingSource": readingSourceManual,
                "File": { "Path": medicarePreventionPlanPdfPhysicalPath, "FileSize": medicarePreventionPlanPdfFileSize, "Type": fileTypePDF }
            });
        }
        if (medicareSnapshotPdfPhysicalPath != '') {
            pdfFiles.push({
                "Id": 0,
                "ReadingSource": readingSourceManual,
                "File": { "Path": medicareSnapshotPdfPhysicalPath, "FileSize": medicareSnapshotPdfFileSize, "Type": fileTypePDF }
            });
        }
    }
    return pdfFiles;
}

$(document).ready(function () {
    $(".pdf-medicare-remove." + preventionPlanFileType).click(function () {
        medicarePreventionPlanPdfPhysicalPath = '';
        medicarePreventionPlanPdfFileSize = 0;

        var pdf = $(".uploadmedicarePDF." + preventionPlanFileType);
        $(pdf).attr("src", "/Content/Images/PageNotFound-Icons.jpg");

        $(pdf).unbind("click");
        
        $(this).hide();
    });

    $(".pdf-medicare-remove." + snapshotSummaryFileType).click(function () {
        medicareSnapshotPdfPhysicalPath = '';
        medicareSnapshotPdfFileSize = 0;

        var pdf = $(".uploadmedicarePDF." + snapshotSummaryFileType);
        $(pdf).attr("src", "/Content/Images/PageNotFound-Icons.jpg");

        $(pdf).unbind("click");
        
        $(this).hide();
    });

});
/**************Upload Images Ends**********************************/