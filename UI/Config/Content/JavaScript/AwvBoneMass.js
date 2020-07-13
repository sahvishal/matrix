var urlPrefix = getUrlPrefix();
var fileTypeAwvBoneMassPDF;


function AwvBoneMass(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = {
            "EstimatedTScore": null,
            "Id": 0, "TestType": testTypeAwvBoneMass,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": '0',
            "UnableScreenReason": new Array(),
            "TestPerformedExternally": null,
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": {
                "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentAwvBoneMassInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestAwvBoneMassCheck").attr("checked")
            }
        };
    }
    this.Result = testResult;
}

AwvBoneMass.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (IsAwvBoneMassResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_AwvBoneMasscapturebyChat", testResult.TestPerformedExternally);
        }

        if (testResult.EstimatedTScore != null && testResult.EstimatedTScore.Finding != null) {
            setSelectedFinding($(".gv-findings-AwvBoneMass"), testResult.EstimatedTScore.Finding.Id);
        }

        setReading($("#txtAwvBoneMassTscore"), testResult.EstimatedTScore);
        
        setUnableScreenReason($('.dtl-unabletoscreen-AwvBoneMass'), testResult.UnableScreenReason);

        setTestNotPerformedReasonForAwvBoneMass(testResult.TestNotPerformed);
        
        if (testResult.ResultImage != null) {
            var expr;

            eval("expr = " + testResult.ResultImage.File.UploadedOn + ";");
            eval("testResult.ResultImage.File.UploadedOn = new " + expr.source + ";");

            setAwvBoneMassFiles(testResult.ResultImage);
        }

        $("#DescribeSelfPresentAwvBoneMassInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);
        $("#conductedbyAwvBoneMass option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);
        
        $("#PriorityInQueueTestAwvBoneMassCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#awvBoneMass-priorityInQueue-span"), "onClick_PriorityInQueueDataAwvBoneMass();", testTypeAwvBoneMass);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#awvBoneMass-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#AwvBoneMass-critical-span"), "onClick_CriticalDataAwvBoneMass();", testTypeAwvBoneMass);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#AwvBoneMass-critical-span").parent().addClass("red-band");
            }
        }
        
        $("#technotesAwvBoneMass").val(testResult.TechnicianNotes);
        
        setboolTypeReading($('#repeatstudyAwvBoneMassinputcheck'), testResult.RepeatStudy);

        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksAwvBoneMass").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpAwvBoneMass").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalAwvBoneMass").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }

    },
    getData: function () {
        var testResult = this.Result;
        if (IsAwvBoneMassResultEntryExternaly == 'True') {
             testResult.TestPerformedExternally = getTestPerformedExternally("chk_AwvBoneMasscapturebyChat", testResult.TestPerformedExternally)
        }
        
        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-AwvBoneMass')));

        testResult.TestNotPerformed = getTestNotPerformedReasonForAwvBoneMass(testResult.TestNotPerformed);
        testResult.EstimatedTScore = getReading($("#txtAwvBoneMassTscore"), testResult.EstimatedTScore);
        
        if (currentScreenMode != ScreenMode.Physician) {

            testResult.ResultImage = GetAwvBoneMassMedia();

            if (currentScreenMode != ScreenMode.CorrectionPostEvaluation && currentScreenMode != ScreenMode.PostAudit) testResult.ResultStatus.StateNumber = $("#ResultStatusInputHidden").val();

            if (testResult.ResultStatus.Id > 0) {
                testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.ResultStatus.DataRecorderMetaData.DateModified = currentDate;
            }
            else {
                testResult.ResultStatus.DataRecorderMetaData = { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate };
            }
        }

        var awvBonMassFinding = getSelectedFinding($(".gv-findings-AwvBoneMass"));
        if (testResult.EstimatedTScore == null && awvBonMassFinding != null) {
            testResult.EstimatedTScore = { 'Finding': awvBonMassFinding, "ReadingSource": readingSourceManual, 'RecorderMetaData': { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate } };
        }
        else if (testResult.EstimatedTScore != null) {
            testResult.EstimatedTScore.Finding = getFindingDataandSynchronized(testResult.EstimatedTScore.Finding, awvBonMassFinding);
        }

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.ConductedByOrgRoleUserId = $("#conductedbyAwvBoneMass option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesAwvBoneMass").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentAwvBoneMassInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestAwvBoneMassCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_60").attr("checked");
        
        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }
        
        if (currentScreenMode != ScreenMode.Entry) {
            testResult.RepeatStudy = getboolTypeReading($('#repeatstudyAwvBoneMassinputcheck'), testResult.RepeatStudy);

            if (testResult.PhysicianInterpretation == null)
                testResult.PhysicianInterpretation = {
                    'Remarks': $("#physicianRemarksAwvBoneMass").val(), 'IsCritical': $("#criticalAwvBoneMass").attr("checked"), 'FollowUp': $("#followUpAwvBoneMass").attr("checked"), 'RecorderMetaData': {
                        'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate
                    }
                };
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksAwvBoneMass").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpAwvBoneMass").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalAwvBoneMass").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }

        if (testResult.ResultStatus.StateNumber < 4) {
            if (testResult.EstimatedTScore == null && testResult.TechnicianNotes.length < 1 && testResult.ConductedByOrgRoleUserId == "0" && testResult.UnableScreenReason == null && $("#DescribeSelfPresentAwvBoneMassInputCheck").attr("checked") == false)
                return null;
        }

        return testResult;
    }
}

$(document).ready(function () {
    $("#txtAwvBoneMassTscore").change(function () { autoSelectFinding($(".gv-findings-AwvBoneMass"), $("#txtAwvBoneMassTscore")); });
});

var criticalDataModel_AwvBoneMass = null;

var awvBoneMassFileCount = 0;
var awvBoneMassResultMedia = null;
var awvBoneMassPdfPhysicalPath = '';
var awvBoneMassPdfFileSize = 0;
var awvBoneMassPdfPhysicalPathUrl = '';


function setAwvBoneMassFiles(jsonMedia) {
    awvBoneMassResultMedia = jsonMedia;
    awvBoneMassFileCount = 0;

    $(".uploadAwvBoneMassPDF").attr("src", "/Content/Images/PageNotFound-Icons.jpg");
    $(".pdf-awvbonemass-remove").hide();

    setAwvBoneMassFileUrlAtStartUp(jsonMedia);
}

function setAwvBoneMassFileUrlAtStartUp(jsonMedia) {

    if (jsonMedia == null) return;

    var fileName = jsonMedia.File.Path;
    setAwvBoneMassFileUrl(fileName, jsonMedia.FileSize);
}
function setAwvBoneMassFileUrl(fileName, fileSize) {
    var bolConfirm;

    if (fileName != null && fileName != "") {
        if ($.trim(fileName).length > 0 && awvBoneMassPdfPhysicalPath != null && awvBoneMassPdfPhysicalPath != "") {
            bolConfirm = confirm("This will overwrite your existing Pdf. Do you want to continue?");
            if (!bolConfirm) return;
        }
        setawvBoneMassFileType(fileName, fileSize);
    }
}
function setawvBoneMassFileType(fileName, fileSize) {

    var pdf = $(".uploadAwvBoneMassPDF");

    awvBoneMassPdfPhysicalPathUrl = urlPrefix + fileName;
    $(pdf).attr("src", "/App/Images/pdf-icon-mm.gif");

    awvBoneMassPdfPhysicalPath = fileName;
    awvBoneMassPdfFileSize = fileSize;

    $(pdf).unbind("click");

    $(pdf).click(function () {
        window.open(awvBoneMassPdfPhysicalPathUrl, '_blank');
    });

    $(".pdf-awvbonemass-remove").show();
    $(".pdf-awvbonemass-upload").hide();
}

function GetAwvBoneMassMedia() {
    if ($.trim(awvBoneMassPdfPhysicalPath).length > 0) {
        if (awvBoneMassResultMedia == null) {
            awvBoneMassResultMedia = {
                "Id": 0,
                "ReadingSource": readingSourceManual,
                "File": { "Path": awvBoneMassPdfPhysicalPath, "FileSize": awvBoneMassPdfFileSize, "Type": fileTypeAwvBoneMassPDF }
            };
        } else if (awvBoneMassResultMedia != null && awvBoneMassResultMedia.File.Path != awvBoneMassPdfPhysicalPath) {
            awvBoneMassResultMedia.File.Path = awvBoneMassPdfPhysicalPath;
            awvBoneMassResultMedia.File.FileSize = awvBoneMassPdfFileSize;
        }
    } else {
        awvBoneMassResultMedia = null;
    }

    return awvBoneMassResultMedia;
}
$(document).ready(function () {
    $(".pdf-awvbonemass-remove").click(function () {
        awvBoneMassPdfPhysicalPath = '';
        awvBoneMassPdfFileSize = 0;
        awvBoneMassResultMedia = null;
        var pdf = $(".uploadAwvBoneMassPDF");
        $(pdf).attr("src", "/Content/Images/PageNotFound-Icons.jpg");

        $(pdf).unbind("click");

        $(this).hide();
        $(".pdf-awvbonemass-upload").show();
    });

});


function onClick_CriticalDataAwvBoneMass() {
    if ($("#DescribeSelfPresentAwvBoneMassInputCheck").attr("checked")) {
        loadCriticalLink($("#AwvBoneMass-critical-span"), "onClick_CriticalDataAwvBoneMass();", testTypeAwvBoneMass);
        openCriticalDataDialog(testTypeAwvBoneMass, $("#conductedbyAwvBoneMass"), $("#DescribeSelfPresentAwvBoneMassInputCheck"), setCriticalDataModel_AwvBoneMass);
    }
    else {
        unloadCriticalLink($("#AwvBoneMass-critical-span"), testTypeAwvBoneMass);
    }
}

function setCriticalDataModel_AwvBoneMass(model, printAfterSave) {
    if (model != null) {
        var testResult = GetAwvBoneMassData();
        saveSingleTestResult(testResult, model, $("#AwvBoneMass-critical-span"), "onClick_CriticalDataAwvBoneMass();", SetAwvBoneMassData, printAfterSave);
    }
}

function getCriticalDataModel_AwvBoneMass() {
    if ($("#DescribeSelfPresentAwvBoneMassInputCheck").attr("checked") && criticalDataModel_AwvBoneMass != null) {
        criticalDataModel_AwvBoneMass.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_AwvBoneMass;
    }
    return null;
}
function onClick_PriorityInQueueDataAwvBoneMass() {
    if ($("#PriorityInQueueTestAwvBoneMassCheck").attr("checked")) {
        loadPriorityInQueueLink($("#awvBoneMass-priorityInQueue-span"), "onClick_PriorityInQueueDataAwvBoneMass();", testTypeAwvBoneMass);
        openPriorityInQueueTestDialog(testTypeAwvBoneMass, $("#conductedbyAwvBoneMass"), $("#PriorityInQueueTestAwvBoneMassCheck"), setPriorityInQueueDataModel_AwvBoneMass);
    }
    else {
        unloadPriorityInQueueLink($("#awvBoneMass-priorityInQueue-span"), testTypeAwvBoneMass);
    }
}

function setPriorityInQueueDataModel_AwvBoneMass(model) {
    if (model != null) {
        var testResult = GetAwvBoneMassData();
        model.TestId = testTypeAwvBoneMass;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#awvBoneMass-priorityInQueue-span"), "onClick_PriorityInQueueDataAwvBoneMass();", SetAwvBoneMassData);
    }
}

function clearAllAwvBoneMassSelection() {
    $(".gv-findings-AwvBoneMass input[type=radio]").attr("checked", false);
}


function setTestNotPerformedReasonForAwvBoneMass(testNotPerformed) {
    setTestNotPerformed("testnotPerformedAwvBoneMass", testNotPerformed);
    SetTestNotPerformedEnableDisabled("testnotPerformedAwvBoneMass");
}

function getTestNotPerformedReasonForAwvBoneMass(testNotPerformed) {
    return getTestNotPerformed("testnotPerformedAwvBoneMass", testNotPerformed);
}