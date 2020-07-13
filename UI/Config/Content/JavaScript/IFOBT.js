var fileTypeIfobtPDF;
var urlPrefix = getUrlPrefix();

function IFOBT(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = {
            "Id": 0, "TestType": testTypeIFOBT,
            "Finding": null,
            "UnableScreenReason": null,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": "0",
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": {
                "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentIFOBTInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestIFOBTCheck").attr("checked")
            },
            "TestPerformedExternally": null
        };
    }
    this.Result = testResult;
}

IFOBT.prototype = {
    setData: function () {
        var testResult = this.Result;

        if (isIFOBTResultEntryType == 'True') {
            setTestPerformedExternally("chk_IFOBTcapturebyChat", testResult.TestPerformedExternally)
        }
        if (testResult.Finding != null) {
            setSelectedFinding_Horizontal($(".gv-findings-IFOBT"), testResult.Finding.Id);
        }

        setboolTypeReading($('#technicallyltdbutreadableIFOBTinputcheck'), testResult.TechnicallyLimitedbutReadable);
        setboolTypeReading($('#repeatstudyIFOBTinputcheck'), testResult.RepeatStudy);

        setUnableScreenReason($('.dtl-unabletoscreen-IFOBT'), testResult.UnableScreenReason);

        setTestNotPerformedReasonForIFOBT(testResult.TestNotPerformed);

        if (testResult.ResultImage != null) {
            var expr;

            eval("expr = " + testResult.ResultImage.File.UploadedOn + ";");
            eval("testResult.ResultImage.File.UploadedOn = new " + expr.source + ";");

            setIfobtFiles(testResult.ResultImage);
        }

        $("#DescribeSelfPresentIFOBTInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);
        $("#conductedbyIFOBT option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);
        $("#PriorityInQueueTestIFOBTCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        $("#SerialKeyInputtext").val(testResult.SerialKey != null ? testResult.SerialKey.Reading : "");
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#IFOBT-priorityInQueue-span"), "onClick_PriorityInQueueDataIFOBT();", testTypeIFOBT);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#IFOBT-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#IFOBT-critical-span"), "onClick_CriticalDataIFOBT();", testTypeIFOBT);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#IFOBT-critical-span").parent().addClass("red-band");
                $("#criticalIFOBT").attr("checked", "checked");
            }
        }

        $("#technotesIFOBT").val(testResult.TechnicianNotes);


        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksIFOBT").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpIFOBT").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalIFOBT").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }
    },
    getData: function () {
        var testResult = this.Result;
        if (isIFOBTResultEntryType == 'True') {
            testResult.TestPerformedExternally = getTestPerformedExternally("chk_IFOBTcapturebyChat", testResult.TestPerformedExternally)
        }
        var testFindings = getSelectedFinding_Horizontal($(".gv-findings-IFOBT"));
        testResult.Finding = getFindingDataandSynchronized(testResult.Finding, testFindings);

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-IFOBT')));

        testResult.TestNotPerformed = getTestNotPerformedReasonForIFOBT(testResult.TestNotPerformed);
        testResult.SerialKey = getReading($("#SerialKeyInputtext"), testResult.SerialKey);
        
        if (currentScreenMode != ScreenMode.Physician) {

            testResult.ResultImage = GetIfobtMedia();

            if (currentScreenMode != ScreenMode.CorrectionPostEvaluation && currentScreenMode != ScreenMode.PostAudit) testResult.ResultStatus.StateNumber = $("#ResultStatusInputHidden").val();

            if (testResult.ResultStatus.Id > 0) {
                testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.ResultStatus.DataRecorderMetaData.DateModified = currentDate;
            }
            else {
                testResult.ResultStatus.DataRecorderMetaData = { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate };
            }
            
            //testResult.SerialKey = getReading($("#SerialKeyInputtext"), testResult.SerialKey);
        }

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.ConductedByOrgRoleUserId = $("#conductedbyIFOBT option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesIFOBT").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentIFOBTInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestIFOBTCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_75").attr("checked");

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }


        if (currentScreenMode != ScreenMode.Entry) {
            testResult.TechnicallyLimitedbutReadable = getboolTypeReading($('#technicallyltdbutreadableIFOBTinputcheck'), testResult.TechnicallyLimitedbutReadable);
            testResult.RepeatStudy = getboolTypeReading($('#repeatstudyIFOBTinputcheck'), testResult.RepeatStudy);

            if (testResult.PhysicianInterpretation == null)
                testResult.PhysicianInterpretation = {
                    'Remarks': $("#physicianRemarksIFOBT").val(), 'IsCritical': $("#criticalIFOBT").attr("checked"), 'FollowUp': $("#followUpIFOBT").attr("checked"), 'RecorderMetaData': {
                        'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate
                    }
                };
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksIFOBT").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpIFOBT").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalIFOBT").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }


        if (testResult.ResultStatus.StateNumber < 4) {
            // To Check if no entry has been done
            if (testResult.Fev1 == null && testResult.UnableScreenReason == null && testResult.TechnicianNotes.length < 1
                && testResult.ConductedByOrgRoleUserId == "0" && $("#chkselfIFOBT").attr("checked") == false) return null;
        }

        return testResult;
    }
}

var criticalDataModel_IFOBT = null;
function onClick_CriticalDataIFOBT() {
    if ($("#DescribeSelfPresentIFOBTInputCheck").attr("checked")) {
        loadCriticalLink($("#IFOBT-critical-span"), "onClick_CriticalDataIFOBT();", testTypeIFOBT);
        openCriticalDataDialog(testTypeIFOBT, $("#conductedbyIFOBT"), $("#DescribeSelfPresentIFOBTInputCheck"), setCriticalDataModel_IFOBT);
    }
    else {
        unloadCriticalLink($("#IFOBT-critical-span"), testTypeIFOBT);
    }
}

function setCriticalDataModel_IFOBT(model, printAfterSave) {
    if (model != null) {
        var testResult = GetIFOBTData();
        saveSingleTestResult(testResult, model, $("#IFOBT-critical-span"), "onClick_CriticalDataIFOBT();", SetIFOBTData, printAfterSave);
    }
}

function getCriticalDataModel_IFOBT() {
    if ($("#DescribeSelfPresentIFOBTInputCheck").attr("checked") && criticalDataModel_IFOBT != null) {
        criticalDataModel_IFOBT.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_IFOBT;
    }
    return null;
}
function onClick_PriorityInQueueDataIFOBT() {
    if ($("#PriorityInQueueTestIFOBTCheck").attr("checked")) {
        loadPriorityInQueueLink($("#IFOBT-priorityInQueue-span"), "onClick_PriorityInQueueDataIFOBT();", testTypeIFOBT);
        openPriorityInQueueTestDialog(testTypeIFOBT, $("#conductedbyIFOBT"), $("#PriorityInQueueTestIFOBTCheck"), setPriorityInQueueDataModel_IFOBT);
    }
    else {
        unloadPriorityInQueueLink($("#IFOBT-priorityInQueue-span"), testTypeIFOBT);
    }
}

function setPriorityInQueueDataModel_IFOBT(model) {
    if (model != null) {
        var testResult = GetIFOBTData();
        model.TestId = testTypeIFOBT;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#IFOBT-priorityInQueue-span"), "onClick_PriorityInQueueDataIFOBT();", SetIFOBTData);
    }
}
function clearAllIFOBTSelection() {
    $(".gv-findings-IFOBT input[type=radio]").attr("checked", false);
}




/**************Upload Images Start**********************/
var ifobtFileCount = 0;
var ifobtResultMedia = null;

var ifobtPdfPhysicalPath = '';
var ifobtPdfFileSize = 0;
var ifobtPdfPhysicalPathUrl = '';


function setIfobtFiles(jsonMedia) {
    ifobtResultMedia = jsonMedia;
    ifobtFileCount = 0;

    $(".uploadIfobtPDF").attr("src", "/Content/Images/PageNotFound-Icons.jpg");
    $(".pdf-ifobt-remove").hide();

    setIfobtFileUrlAtStartUp(jsonMedia);
}

function setIfobtFileUrlAtStartUp(jsonMedia) {

    if (jsonMedia == null) return;

    var fileName = jsonMedia.File.Path;
    setIfobtFileUrl(fileName, jsonMedia.FileSize);
}

function setIfobtFileUrl(fileName, fileSize) {
    var bolConfirm;

    if (fileName != null && fileName != "") {
        if ($.trim(fileName).length > 0 && ifobtPdfPhysicalPath != null && ifobtPdfPhysicalPath != "") {
            bolConfirm = confirm("This will overwrite your existing Pdf. Do you want to continue?");
            if (!bolConfirm) return;
        }
        setIfobtFileType(fileName, fileSize);
    }
}

function setIfobtFileType(fileName, fileSize) {

    var pdf = $(".uploadIfobtPDF");

    ifobtPdfPhysicalPathUrl = urlPrefix + fileName;
    $(pdf).attr("src", "/App/Images/pdf-icon-mm.gif");

    ifobtPdfPhysicalPath = fileName;
    ifobtPdfFileSize = fileSize;

    $(pdf).unbind("click");

    $(pdf).click(function () {
        window.open(ifobtPdfPhysicalPathUrl, '_blank');
    });

    $(".pdf-ifobt-remove").show();
}

function GetIfobtMedia() {
    if ($.trim(ifobtPdfPhysicalPath).length > 0) {
        if (ifobtResultMedia == null) {
            ifobtResultMedia = {
                "Id": 0,
                "ReadingSource": readingSourceManual,
                "File": { "Path": ifobtPdfPhysicalPath, "FileSize": ifobtPdfFileSize, "Type": fileTypeIfobtPDF }
            };
        } else if (ifobtResultMedia != null && ifobtResultMedia.File.Path != ifobtPdfPhysicalPath) {
            ifobtResultMedia.File.Path = ifobtPdfPhysicalPath;
            ifobtResultMedia.File.FileSize = ifobtPdfFileSize;
        }
    } else {
        ifobtResultMedia = null;
    }

    return ifobtResultMedia;
}

$(document).ready(function () {
    $(".pdf-ifobt-remove").click(function () {
        ifobtPdfPhysicalPath = '';
        ifobtPdfFileSize = 0;
        ifobtResultMedia = null;
        var pdf = $(".uploadIfobtPDF");
        $(pdf).attr("src", "/Content/Images/PageNotFound-Icons.jpg");

        $(pdf).unbind("click");

        $(this).hide();
    });

});
/**************Upload Images Ends**********************************/

function setTestNotPerformedReasonForIFOBT(testNotPerformed) {
    setTestNotPerformed("testnotPerformedIFOBT", testNotPerformed);
    SetTestNotPerformedEnableDisabled("testnotPerformedIFOBT");
}

function getTestNotPerformedReasonForIFOBT(testNotPerformed) {
    return getTestNotPerformed("testnotPerformedIFOBT", testNotPerformed);
}
