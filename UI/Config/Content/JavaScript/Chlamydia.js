var fileTypeChlamydiaPDF;
var urlPrefix = getUrlPrefix();

function Chlamydia(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = {
            "Id": 0, "TestType": testTypeChlamydia,
            "Finding": null,
            "UnableScreenReason": null,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": "0",
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": {
                "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentChlamydiaInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestChlamydiaCheck").attr("checked")
            },
            "TestPerformedExternally": null
        };
    }
    this.Result = testResult;
}

Chlamydia.prototype = {
    setData: function () {
        var testResult = this.Result;

        if (isChlamydiaResultEntryType == 'True') {
            setTestPerformedExternally("chk_chlamydiacapturebyChat", testResult.TestPerformedExternally)
        }

        if (testResult.Finding != null) {
            setSelectedFinding_Horizontal($(".gv-findings-chlamydia"), testResult.Finding.Id);
        }

        setboolTypeReading($('#technicallyltdbutreadableChlamydiainputcheck'), testResult.TechnicallyLimitedbutReadable);
        setboolTypeReading($('#repeatstudyChlamydiainputcheck'), testResult.RepeatStudy);

        setUnableScreenReason($('.dtl-unabletoscreen-chlamydia'), testResult.UnableScreenReason);

        setTestNotPerformedReasonForChlamydia(testResult.TestNotPerformed);

        if (testResult.ResultImage != null) {
            var expr;

            eval("expr = " + testResult.ResultImage.File.UploadedOn + ";");
            eval("testResult.ResultImage.File.UploadedOn = new " + expr.source + ";");

            setChlamydiaFiles(testResult.ResultImage);
        }

        $("#DescribeSelfPresentChlamydiaInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);
        $("#conductedbyChlamydia option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);
        $("#PriorityInQueueTestChlamydiaCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#Chlamydia-priorityInQueue-span"), "onClick_PriorityInQueueDataChlamydia();", testTypeChlamydia);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#Chlamydia-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#Chlamydia-critical-span"), "onClick_CriticalDataChlamydia();", testTypeChlamydia);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#Chlamydia-critical-span").parent().addClass("red-band");
                $("#criticalChlamydia").attr("checked", "checked");
            }
        }

        $("#technotesChlamydia").val(testResult.TechnicianNotes);


        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksChlamydia").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpChlamydia").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalChlamydia").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }
    },
    getData: function () {
        var testResult = this.Result;
        if (isChlamydiaResultEntryType == 'True') {
            testResult.TestPerformedExternally = getTestPerformedExternally("chk_chlamydiacapturebyChat", testResult.TestPerformedExternally)
        }

        var testFindings = getSelectedFinding_Horizontal($(".gv-findings-chlamydia"));
        testResult.Finding = getFindingDataandSynchronized(testResult.Finding, testFindings);

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-chlamydia')));

        testResult.TestNotPerformed = getTestNotPerformedReasonForChlamydia(testResult.TestNotPerformed);

        if (currentScreenMode != ScreenMode.Physician) {

            testResult.ResultImage = GetChlamydiaMedia();

            if (currentScreenMode != ScreenMode.CorrectionPostEvaluation && currentScreenMode != ScreenMode.PostAudit) testResult.ResultStatus.StateNumber = $("#ResultStatusInputHidden").val();

            if (testResult.ResultStatus.Id > 0) {
                testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.ResultStatus.DataRecorderMetaData.DateModified = currentDate;
            }
            else {
                testResult.ResultStatus.DataRecorderMetaData = { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate };
            }
        }

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.ConductedByOrgRoleUserId = $("#conductedbyChlamydia option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesChlamydia").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentChlamydiaInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestChlamydiaCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_93").attr("checked");

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }


        if (currentScreenMode != ScreenMode.Entry) {
            testResult.TechnicallyLimitedbutReadable = getboolTypeReading($('#technicallyltdbutreadableChlamydiainputcheck'), testResult.TechnicallyLimitedbutReadable);
            testResult.RepeatStudy = getboolTypeReading($('#repeatstudyChlamydiainputcheck'), testResult.RepeatStudy);

            if (testResult.PhysicianInterpretation == null)
                testResult.PhysicianInterpretation = {
                    'Remarks': $("#physicianRemarksChlamydia").val(), 'IsCritical': $("#criticalChlamydia").attr("checked"), 'FollowUp': $("#followUpChlamydia").attr("checked"), 'RecorderMetaData': {
                        'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate
                    }
                };
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksChlamydia").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpChlamydia").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalChlamydia").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }


        if (testResult.ResultStatus.StateNumber < 4) {
            // To Check if no entry has been done
            if (testResult.Fev1 == null && testResult.UnableScreenReason == null && testResult.TechnicianNotes.length < 1
                && testResult.ConductedByOrgRoleUserId == "0" && $("#chkselfChlamydia").attr("checked") == false) return null;
        }

        return testResult;
    }
}

var criticalDataModel_Chlamydia = null;
function onClick_CriticalDataChlamydia() {
    if ($("#DescribeSelfPresentChlamydiaInputCheck").attr("checked")) {
        loadCriticalLink($("#Chlamydia-critical-span"), "onClick_CriticalDataChlamydia();", testTypeChlamydia);
        openCriticalDataDialog(testTypeChlamydia, $("#conductedbyChlamydia"), $("#DescribeSelfPresentChlamydiaInputCheck"), setCriticalDataModel_Chlamydia);
    }
    else {
        unloadCriticalLink($("#Chlamydia-critical-span"), testTypeChlamydia);
    }
}

function setCriticalDataModel_Chlamydia(model, printAfterSave) {
    if (model != null) {
        var testResult = GetChlamydiaData();
        saveSingleTestResult(testResult, model, $("#Chlamydia-critical-span"), "onClick_CriticalDataChlamydia();", SetChlamydiaData, printAfterSave);
    }
}

function getCriticalDataModel_Chlamydia() {
    if ($("#DescribeSelfPresentChlamydiaInputCheck").attr("checked") && criticalDataModel_Chlamydia != null) {
        criticalDataModel_Chlamydia.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_Chlamydia;
    }
    return null;
}
function onClick_PriorityInQueueDataChlamydia() {
    if ($("#PriorityInQueueTestChlamydiaCheck").attr("checked")) {
        loadPriorityInQueueLink($("#Chlamydia-priorityInQueue-span"), "onClick_PriorityInQueueDataChlamydia();", testTypeChlamydia);
        openPriorityInQueueTestDialog(testTypeChlamydia, $("#conductedbyChlamydia"), $("#PriorityInQueueTestChlamydiaCheck"), setPriorityInQueueDataModel_Chlamydia);
    }
    else {
        unloadPriorityInQueueLink($("#Chlamydia-priorityInQueue-span"), testTypeChlamydia);
    }
}

function setPriorityInQueueDataModel_Chlamydia(model) {
    if (model != null) {
        var testResult = GetChlamydiaData();
        model.TestId = testTypeChlamydia;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#Chlamydia-priorityInQueue-span"), "onClick_PriorityInQueueDataChlamydia();", SetChlamydiaData);
    }
}

function clearAllChlamydiaSelection() {   
    $(".gv-findings-chlamydia input[type=radio]").attr("checked", false);
}

/**************Upload Images Start**********************/
var chlamydiaFileCount = 0;
var chlamydiaResultMedia = null;

var chlamydiaPdfPhysicalPath = '';
var chlamydiaPdfFileSize = 0;
var chlamydiaPdfPhysicalPathUrl = '';


function setChlamydiaFiles(jsonMedia) {
    chlamydiaResultMedia = jsonMedia;
    chlamydiaFileCount = 0;

    $(".uploadchlamydiaPDF").attr("src", "/Content/Images/PageNotFound-Icons.jpg");
    $(".pdf-chlamydia-remove").hide();

    setChlamydiaFileUrlAtStartUp(jsonMedia);
}

function setChlamydiaFileUrlAtStartUp(jsonMedia) {

    if (jsonMedia == null) return;

    var fileName = jsonMedia.File.Path;
    setChlamydiaFileUrl(fileName, jsonMedia.FileSize);
}

function setChlamydiaFileUrl(fileName, fileSize) {
    var bolConfirm;

    if (fileName != null && fileName != "") {
        if ($.trim(fileName).length > 0 && chlamydiaPdfPhysicalPath != null && chlamydiaPdfPhysicalPath != "") {
            bolConfirm = confirm("This will overwrite your existing Pdf. Do you want to continue?");
            if (!bolConfirm) return;
        }
        setChlamydiaFileType(fileName, fileSize);
    }
}

function setChlamydiaFileType(fileName, fileSize) {

    var pdf = $(".uploadchlamydiaPDF");

    chlamydiaPdfPhysicalPathUrl = urlPrefix + fileName;
    $(pdf).attr("src", "/App/Images/pdf-icon-mm.gif");

    chlamydiaPdfPhysicalPath = fileName;
    chlamydiaPdfFileSize = fileSize;

    $(pdf).unbind("click");

    $(pdf).click(function () {
        window.open(chlamydiaPdfPhysicalPathUrl, '_blank');
    });

    $(".pdf-chlamydia-remove").show();
}

function GetChlamydiaMedia() {
    if ($.trim(chlamydiaPdfPhysicalPath).length > 0) {
        if (chlamydiaResultMedia == null) {
            chlamydiaResultMedia = {
                "Id": 0,
                "ReadingSource": readingSourceManual,
                "File": { "Path": chlamydiaPdfPhysicalPath, "FileSize": chlamydiaPdfFileSize, "Type": fileTypeChlamydiaPDF }
            };
        } else if (chlamydiaResultMedia != null && chlamydiaResultMedia.File.Path != chlamydiaPdfPhysicalPath) {
            chlamydiaResultMedia.File.Path = chlamydiaPdfPhysicalPath;
            chlamydiaResultMedia.File.FileSize = chlamydiaPdfFileSize;
        }
    } else {
        chlamydiaResultMedia = null;
    }

    return chlamydiaResultMedia;
}

$(document).ready(function () {
    $(".pdf-chlamydia-remove").click(function () {
        chlamydiaPdfPhysicalPath = '';
        chlamydiaPdfFileSize = 0;
        chlamydiaResultMedia = null;
        var pdf = $(".uploadchlamydiaPDF");
        $(pdf).attr("src", "/Content/Images/PageNotFound-Icons.jpg");

        $(pdf).unbind("click");

        $(this).hide();
    });

});
/**************Upload Images Ends**********************************/

function setTestNotPerformedReasonForChlamydia(testNotPerformed) {
    setTestNotPerformed("testnotPerformedChlamydia", testNotPerformed);
    SetTestNotPerformedEnableDisabled("testnotPerformedChlamydia");
}

function getTestNotPerformedReasonForChlamydia(testNotPerformed) {
    return getTestNotPerformed("testnotPerformedChlamydia", testNotPerformed);
}
