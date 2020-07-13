
var testTypeDiabeticRetinopathy;
var fileTypePDF;
var urlPrefix = getUrlPrefix();

function DiabeticRetinopathy(testResult) {
    if (testResult == null || typeof (testResult) == "undefined") {
        testResult = {
            "Id": 0, "TestType": testTypeDiabeticRetinopathy,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": '0',
            "UnableScreenReason": new Array(),
            "ResultImages": null,
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": {
                "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentDiabeticRetinopathyInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestDiabeticRetinopathyCheck").attr("checked")
            },
            "TestPerformedExternally": null
        };
    }
    this.Result = testResult;
}

DiabeticRetinopathy.prototype = {
    setData: function() {
        var testResult = this.Result;
        if (isDiabeticRetinopathyResultEntryType == 'True') {
            setTestPerformedExternally("chk_DiabeticRetinopathycapturebyChat", testResult.TestPerformedExternally)
        }
        $("#DescribeSelfPresentDiabeticRetinopathyInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);

        $("#technotesDiabeticRetinopathy").val(testResult.TechnicianNotes);
        $("#conductedbyDiabeticRetinopathy option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);

        setUnableScreenReason($('.dtl-unabletoscreen-DiabeticRetinopathy'), testResult.UnableScreenReason);

        setTestNotPerformedReasonForDiabeticRetinopathy(testResult.TestNotPerformed);

        setboolTypeReading($('#DiabeticRetinopathySuspectedVeinOcclusion'), testResult.SuspectedVeinOcclusion);
        setboolTypeReading($('#DiabeticRetinopathySuspectedWetAmd'), testResult.SuspectedWetAmd);
        setboolTypeReading($('#DiabeticRetinopathySuspectedHtnRetinopathy'), testResult.SuspectedHtnRetinopathy);
        setboolTypeReading($('#DiabeticRetinopathySuspectedEpiretinalMembrane'), testResult.SuspectedEpiretinalMembrane);
        setboolTypeReading($('#DiabeticRetinopathySuspectedMacularHole'), testResult.SuspectedMacularHole);
        setboolTypeReading($('#DiabeticRetinopathySuspectedCataract'), testResult.SuspectedCataract);
        setboolTypeReading($('#DiabeticRetinopathySuspectedOtherDisease'), testResult.SuspectedOtherDisease);
        setboolTypeReading($('#DiabeticRetinopathySuspectedGlaucoma'), testResult.SuspectedGlaucoma);
        setboolTypeReading($('#DiabeticRetinopathySuspectedDryAmd'), testResult.SuspectedDryAmd);
        
        if (testResult.DiabeticRetinopathyLevel != null) {
            setSelectedFindingDatalist($(".DiabeticRetinopathy-HighestLevel-finding"), testResult.DiabeticRetinopathyLevel.Id);
        }

        if (testResult.MacularEdemaLevel != null) {
            setSelectedFindingDatalist($(".DiabeticRetinopathy-Macular-Edema-finding"), testResult.MacularEdemaLevel.Id);
        }

        if (testResult.ResultImage != null) {
            var expr;

            eval("expr = " + testResult.ResultImage.File.UploadedOn + ";");
            eval("testResult.ResultImage.File.UploadedOn = new " + expr.source + ";");

            setdiabeticRetinopathyFiles(testResult.ResultImage);
        }
        $("#PriorityInQueueTestDiabeticRetinopathyCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#diabeticRetinopathy-priorityInQueue-span"), "onClick_PriorityInQueueDataDiabeticRetinopathy();", testTypeDiabeticRetinopathy);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#diabeticRetinopathy-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#DiabeticRetinopathy-critical-span"), "onClick_CriticalDataDiabeticRetinopathy();", testTypeDiabeticRetinopathy);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#DiabeticRetinopathy-critical-span").parent().addClass("red-band");
            }
        }
    },
    getData: function() {
        var testResult = this.Result;
        if (isDiabeticRetinopathyResultEntryType == 'True') {
            testResult.TestPerformedExternally = getTestPerformedExternally("chk_DiabeticRetinopathycapturebyChat", testResult.TestPerformedExternally)
        }
        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-DiabeticRetinopathy')));

        testResult.TestNotPerformed = getTestNotPerformedReasonForDiabeticRetinopathy(testResult.TestNotPerformed);

        testResult.DiabeticRetinopathyLevel = getFindingDataandSynchronized(testResult.DiabeticRetinopathyLevel, getSelectedFindingDatalist($(".DiabeticRetinopathy-HighestLevel-finding")));
        testResult.MacularEdemaLevel = getFindingDataandSynchronized(testResult.MacularEdemaLevel, getSelectedFindingDatalist($(".DiabeticRetinopathy-Macular-Edema-finding")));
        
        testResult.SuspectedVeinOcclusion = getboolTypeReading($('#DiabeticRetinopathySuspectedVeinOcclusion'), testResult.SuspectedVeinOcclusion);
        testResult.SuspectedWetAmd = getboolTypeReading($('#DiabeticRetinopathySuspectedWetAmd'), testResult.SuspectedWetAmd);
        testResult.SuspectedHtnRetinopathy = getboolTypeReading($('#DiabeticRetinopathySuspectedHtnRetinopathy'), testResult.SuspectedHtnRetinopathy);
        testResult.SuspectedEpiretinalMembrane = getboolTypeReading($('#DiabeticRetinopathySuspectedEpiretinalMembrane'), testResult.SuspectedEpiretinalMembrane);
        testResult.SuspectedMacularHole = getboolTypeReading($('#DiabeticRetinopathySuspectedMacularHole'), testResult.SuspectedMacularHole);
        testResult.SuspectedCataract = getboolTypeReading($('#DiabeticRetinopathySuspectedCataract'), testResult.SuspectedCataract);
        testResult.SuspectedOtherDisease = getboolTypeReading($('#DiabeticRetinopathySuspectedOtherDisease'), testResult.SuspectedOtherDisease);
        testResult.SuspectedGlaucoma = getboolTypeReading($('#DiabeticRetinopathySuspectedGlaucoma'), testResult.SuspectedGlaucoma);
        testResult.SuspectedDryAmd = getboolTypeReading($('#DiabeticRetinopathySuspectedDryAmd'), testResult.SuspectedDryAmd);

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.ConductedByOrgRoleUserId = $("#conductedbyDiabeticRetinopathy option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesDiabeticRetinopathy").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentDiabeticRetinopathyInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestDiabeticRetinopathyCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_73").attr("checked");

        if (currentScreenMode != ScreenMode.Physician) {

            testResult.ResultImage = GetDiabeticRetinopathyMedia();

            if (currentScreenMode != ScreenMode.CorrectionPostEvaluation && currentScreenMode != ScreenMode.PostAudit) testResult.ResultStatus.StateNumber = $("#ResultStatusInputHidden").val();

            if (testResult.ResultStatus.Id > 0) {
                testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.ResultStatus.DataRecorderMetaData.DateModified = currentDate;
            } else {
                testResult.ResultStatus.DataRecorderMetaData = { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate };
            }
        }

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }

        if (testResult.ResultStatus.StateNumber < 4) {
            if (testResult.TechnicianNotes.length < 1 && testResult.ConductedByOrgRoleUserId == "0" && testResult.UnableScreenReason == null && $("#DescribeSelfPresentDiabeticRetinopathyInputCheck").attr("checked") == false)
                return null;
        }

        return testResult;
    }
};


var criticalDataModel_DiabeticRetinopathy = null;
function onClick_CriticalDataDiabeticRetinopathy() {
    if ($("#DescribeSelfPresentDiabeticRetinopathyInputCheck").attr("checked")) {
        loadCriticalLink($("#DiabeticRetinopathy-critical-span"), "onClick_CriticalDataDiabeticRetinopathy();", testTypeDiabeticRetinopathy);
        openCriticalDataDialog(testTypeDiabeticRetinopathy, $("#conductedbyDiabeticRetinopathy"), $("#DescribeSelfPresentDiabeticRetinopathyInputCheck"), setCriticalDataModel_DiabeticRetinopathy);
    }
    else {
        unloadCriticalLink($("#DiabeticRetinopathy-critical-span"), testTypeDiabeticRetinopathy);
    }
}

function setCriticalDataModel_DiabeticRetinopathy(model, printAfterSave) {
    if (model != null) {
        var testResult = GetDiabeticRetinopathyData();
        saveSingleTestResult(testResult, model, $("#DiabeticRetinopathy-critical-span"), "onClick_CriticalDataDiabeticRetinopathy();", SetDiabeticRetinopathyData, printAfterSave);
    }
}

function getCriticalDataModel_DiabeticRetinopathy() {
    if ($("#DescribeSelfPresentDiabeticRetinopathyInputCheck").attr("checked") && criticalDataModel_DiabeticRetinopathy != null) {
        criticalDataModel_DiabeticRetinopathy.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_DiabeticRetinopathy;
    }
    return null;
}

function onClick_PriorityInQueueDataDiabeticRetinopathy() {
    if ($("#PriorityInQueueTestDiabeticRetinopathyCheck").attr("checked")) {
        loadPriorityInQueueLink($("#diabeticRetinopathy-priorityInQueue-span"), "onClick_PriorityInQueueDataDiabeticRetinopathy();", testTypeDiabeticRetinopathy);
        openPriorityInQueueTestDialog(testTypeDiabeticRetinopathy, $("#conductedbyDiabeticRetinopathy"), $("#PriorityInQueueTestDiabeticRetinopathyCheck"), setPriorityInQueueDataModel_DiabeticRetinopathy);
    }
    else {
        unloadPriorityInQueueLink($("#diabeticRetinopathy-priorityInQueue-span"), testTypeDiabeticRetinopathy);
    }
}

function setPriorityInQueueDataModel_DiabeticRetinopathy(model) {
    if (model != null) {
        var testResult = GetDiabeticRetinopathyData();
        model.TestId = testTypeDiabeticRetinopathy;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#diabeticRetinopathy-priorityInQueue-span"), "onClick_PriorityInQueueDataDiabeticRetinopathy();", SetDiabeticRetinopathyData);
    }
}


/**************Upload Images Start**********************/
var diabeticRetinopathyFileCount = 0;
var diabeticRetinopathyResultMedia = null;

var diabeticRetinopathyPdfPhysicalPath = '';
var diabeticRetinopathyPdfFileSize = 0;
var diabeticRetinopathyPdfPhysicalPathUrl = '';


function setdiabeticRetinopathyFiles(jsonMedia) {
    diabeticRetinopathyResultMedia = jsonMedia;
    diabeticRetinopathyFileCount = 0;

    $(".uploaddiabeticRetinopathyPDF").attr("src", "/Content/Images/PageNotFound-Icons.jpg");
    $(".pdf-diabeticRetinopathy-remove").hide();

    setDiabeticRetinopathyFileUrlAtStartUp(jsonMedia);
}

function setDiabeticRetinopathyFileUrlAtStartUp(jsonMedia) {

    if (jsonMedia == null) return;

    var fileName = jsonMedia.File.Path;
    setDiabeticRetinopathyFileUrl(fileName, jsonMedia.FileSize);
}

function setDiabeticRetinopathyFileUrl(fileName, fileSize) {
    var bolConfirm;

    if (fileName != null && fileName != "") {
        if ($.trim(fileName).length > 0 && diabeticRetinopathyPdfPhysicalPath != null && diabeticRetinopathyPdfPhysicalPath != "") {
            bolConfirm = confirm("This will overwrite your existing Pdf. Do you want to continue?");
            if (!bolConfirm) return;
        }
        setDiabeticRetinopathyFileType(fileName, fileSize);
    }
}

function setDiabeticRetinopathyFileType(fileName, fileSize) {

    var pdf = $(".uploaddiabeticRetinopathyPDF");

    diabeticRetinopathyPdfPhysicalPathUrl = urlPrefix + fileName;
    $(pdf).attr("src", "/App/Images/pdf-icon-mm.gif");

    diabeticRetinopathyPdfPhysicalPath = fileName;
    diabeticRetinopathyPdfFileSize = fileSize;
    
    $(pdf).unbind("click");

    $(pdf).click(function () {
        window.open(diabeticRetinopathyPdfPhysicalPathUrl, '_blank');
    });
    
    $(".pdf-diabeticRetinopathy-remove").show();
}

function GetDiabeticRetinopathyMedia() {
    if ($.trim(diabeticRetinopathyPdfPhysicalPath).length > 0) {
        if (diabeticRetinopathyResultMedia == null) {
            diabeticRetinopathyResultMedia = {
                "Id": 0,
                "ReadingSource": readingSourceManual,
                "File": { "Path": diabeticRetinopathyPdfPhysicalPath, "FileSize": diabeticRetinopathyPdfFileSize, "Type": fileTypePDF }
            };
        } else if (diabeticRetinopathyResultMedia.File.Path != diabeticRetinopathyPdfPhysicalPath) {
            diabeticRetinopathyResultMedia.File.Path = diabeticRetinopathyPdfPhysicalPath;
            diabeticRetinopathyResultMedia.File.FileSize = diabeticRetinopathyPdfFileSize;
        }
    } else {
        diabeticRetinopathyResultMedia = null;
    }

    return diabeticRetinopathyResultMedia;
}

$(document).ready(function () {
    $(".pdf-diabeticRetinopathy-remove").click(function () {
        diabeticRetinopathyPdfPhysicalPath = '';
        diabeticRetinopathyPdfFileSize = 0;

        var pdf = $(".uploaddiabeticRetinopathyPDF");
        $(pdf).attr("src", "/Content/Images/PageNotFound-Icons.jpg");
        
        $(pdf).unbind("click");

        $(this).hide();
    });

    //$(".uploaddiabeticRetinopathyPDF").click(function () {
    //    if (diabeticRetinopathyPdfPhysicalPathUrl != null && $.trim(diabeticRetinopathyPdfPhysicalPathUrl).length > 0) {
    //        window.open(diabeticRetinopathyPdfPhysicalPathUrl, '_blank');
    //    }
    //});
});
/**************Upload Images Ends**********************************/

function setTestNotPerformedReasonForDiabeticRetinopathy(testNotPerformed) {
    setTestNotPerformed("testnotPerformedDiabeticRetinopathy", testNotPerformed);
    SetTestNotPerformedEnableDisabled("testnotPerformedDiabeticRetinopathy");
}

function getTestNotPerformedReasonForDiabeticRetinopathy(testNotPerformed) {
    return getTestNotPerformed("testnotPerformedDiabeticRetinopathy", testNotPerformed);
}
function clearAllDiabeticRetinopathySelection() {
    $(".gv-Findings-DiabeticRetinopathy input[type=radio], .gv-reading-DiabeticRetinopathy input[type=checkbox]").attr("checked", false);
}