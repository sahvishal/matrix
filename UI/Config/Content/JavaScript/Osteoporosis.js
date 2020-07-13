var urlPrefix = getUrlPrefix();
var fileTypeOsteoporosisPDF;

function Osteoporosis(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = { "EstimatedTScore": null,
            "Id": 0, "TestType": testTypeOsteoporosis,
            "UnableScreenReason": null,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": "0",
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "TestPerformedExternally": null,
            "ResultStatus": { "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentOsteoInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestOsteoCheck").attr("checked")
            }
        };
    }
    this.Result = testResult;
}

Osteoporosis.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (IsosteoResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_osteocapturebyChat", testResult.TestPerformedExternally)
        }
        if (testResult.EstimatedTScore != null && testResult.EstimatedTScore.Finding != null) {
            setSelectedFinding($(".gv-findings-osteo"), testResult.EstimatedTScore.Finding.Id);
        }

        setReading($("#txtTscoreOsteo"), testResult.EstimatedTScore);

        setUnableScreenReason($('.dtl-unabletoscreen-osteo'), testResult.UnableScreenReason);

        setTestNotPerformedReasonForOsteo(testResult.TestNotPerformed);


        if (testResult.ResultImage != null) {
            var expr;

            eval("expr = " + testResult.ResultImage.File.UploadedOn + ";");
            eval("testResult.ResultImage.File.UploadedOn = new " + expr.source + ";");

            setOsteoporosisFiles(testResult.ResultImage);
        }

        $("#DescribeSelfPresentOsteoInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);
        $("#conductedbyosteo option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);
        $("#PriorityInQueueTestOsteoCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#osteo-priorityInQueue-span"), "onClick_PriorityInQueueDataOsteo();", testTypeOsteoporosis);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#osteo-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#osteo-critical-span"), "onClick_CriticalDataOsteo();", testTypeOsteoporosis);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#osteo-critical-span").parent().addClass("red-band");
                $("#criticalOsteo").attr("checked", "checked");
            }
        }

        $("#technotesosteo").val(testResult.TechnicianNotes);
        setboolTypeReading($('#repeatstudyosteoinputcheck'), testResult.RepeatStudy);

        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksOsteo").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpOsteo").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalOsteo").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }
    },
    getData: function () {
        var testResult = this.Result;
        if (IsosteoResultEntryExternaly == 'True') {
             testResult.TestPerformedExternally = getTestPerformedExternally("chk_osteocapturebyChat", testResult.TestPerformedExternally)
        }
        
        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-osteo')));

        testResult.TestNotPerformed = getTestNotPerformedReasonForOsteo(testResult.TestNotPerformed);

        testResult.EstimatedTScore = getReading($("#txtTscoreOsteo"), testResult.EstimatedTScore);
        
        if (currentScreenMode != ScreenMode.Physician) {
            testResult.ResultImage = GetOsteoporosisMedia();

            //testResult.EstimatedTScore = getReading($("#txtTscoreOsteo"), testResult.EstimatedTScore);

            if (currentScreenMode != ScreenMode.CorrectionPostEvaluation && currentScreenMode != ScreenMode.PostAudit) testResult.ResultStatus.StateNumber = $("#ResultStatusInputHidden").val();

            if (testResult.ResultStatus.Id > 0) {
                testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.ResultStatus.DataRecorderMetaData.DateModified = currentDate;
            }
            else {
                testResult.ResultStatus.DataRecorderMetaData = { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate };
            }
        }

        var osteoFinding = getSelectedFinding($(".gv-findings-osteo"));
        if (testResult.EstimatedTScore == null && osteoFinding != null) {
            testResult.EstimatedTScore = { 'Finding': osteoFinding, "ReadingSource": readingSourceManual, 'RecorderMetaData': { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate}  };
        }
        else if (testResult.EstimatedTScore != null) {
            testResult.EstimatedTScore.Finding = getFindingDataandSynchronized(testResult.EstimatedTScore.Finding, osteoFinding);
        }

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.ConductedByOrgRoleUserId = $("#conductedbyosteo option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesosteo").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentOsteoInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestOsteoCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_9").attr("checked");

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }

        if (currentScreenMode != ScreenMode.Entry) {
            testResult.RepeatStudy = getboolTypeReading($('#repeatstudyosteoinputcheck'), testResult.RepeatStudy);
            
            if (testResult.PhysicianInterpretation == null)
                testResult.PhysicianInterpretation = { 'Remarks': $("#physicianRemarksOsteo").val(), 'IsCritical': $("#criticalOsteo").attr("checked"), 'FollowUp': $("#followUpOsteo").attr("checked"), 'RecorderMetaData': {
                    'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate
                }
                };
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksOsteo").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpOsteo").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalOsteo").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }


        if (testResult.ResultStatus.StateNumber < 4) {
            // To Check if no entry has been done
            if (testResult.EstimatedTScore == null && testResult.UnableScreenReason == null && testResult.TechnicianNotes.length < 1
                && testResult.ConductedByOrgRoleUserId == "0" && $("#chkselfOsteo").attr("checked") == false) return null;
        }

        return testResult;
    }
}


$(document).ready(function () {
    $("#txtTscoreOsteo").change(function () { autoSelectFinding($(".gv-findings-osteo"), $("#txtTscoreOsteo")); });
});

var criticalDataModel_Osteo = null;

var osteoporosisFileCount = 0;
var osteoporosisResultMedia = null;
var osteoporosisPdfPhysicalPath = '';
var osteoporosisPdfFileSize = 0;
var osteoporosisPdfPhysicalPathUrl = '';


function setOsteoporosisFiles(jsonMedia) {
    osteoporosisResultMedia = jsonMedia;
    osteoporosisFileCount = 0;

    $(".uploadOsteoporosisPDF").attr("src", "/Content/Images/PageNotFound-Icons.jpg");
    $(".pdf-osteoporosis-remove").hide();

    setOsteoporosisFileUrlAtStartUp(jsonMedia);
}

function setOsteoporosisFileUrlAtStartUp(jsonMedia) {

    if (jsonMedia == null) return;

    var fileName = jsonMedia.File.Path;
    setOsteoporosisFileUrl(fileName, jsonMedia.FileSize);
}
function setOsteoporosisFileUrl(fileName, fileSize) {
    var bolConfirm;

    if (fileName != null && fileName != "") {
        if ($.trim(fileName).length > 0 && osteoporosisPdfPhysicalPath != null && osteoporosisPdfPhysicalPath != "") {
            bolConfirm = confirm("This will overwrite your existing Pdf. Do you want to continue?");
            if (!bolConfirm) return;
        }
        setOsteoporosisFileType(fileName, fileSize);
    }
}
function setOsteoporosisFileType(fileName, fileSize) {

    var pdf = $(".uploadOsteoporosisPDF");

    osteoporosisPdfPhysicalPathUrl = urlPrefix + fileName;
    $(pdf).attr("src", "/App/Images/pdf-icon-mm.gif");

    osteoporosisPdfPhysicalPath = fileName;
    osteoporosisPdfFileSize = fileSize;

    $(pdf).unbind("click");

    $(pdf).click(function () {
        window.open(osteoporosisPdfPhysicalPathUrl, '_blank');
    });

    $(".pdf-osteoporosis-remove").show();
    $(".pdf-osteoporosis-upload").hide();
}

function GetOsteoporosisMedia() {
    if ($.trim(osteoporosisPdfPhysicalPath).length > 0) {
        if (osteoporosisResultMedia == null) {
            osteoporosisResultMedia = {
                "Id": 0,
                "ReadingSource": readingSourceManual,
                "File": { "Path": osteoporosisPdfPhysicalPath, "FileSize": osteoporosisPdfFileSize, "Type": fileTypeOsteoporosisPDF }
            };
        } else if (osteoporosisResultMedia != null && osteoporosisResultMedia.File.Path != osteoporosisPdfPhysicalPath) {
            osteoporosisResultMedia.File.Path = osteoporosisPdfPhysicalPath;
            osteoporosisResultMedia.File.FileSize = osteoporosisPdfFileSize;
        }
    } else {
        osteoporosisResultMedia = null;
    }

    return osteoporosisResultMedia;
}
$(document).ready(function () {
    $(".pdf-osteoporosis-remove").click(function () {
        osteoporosisPdfPhysicalPath = '';
        osteoporosisPdfFileSize = 0;
        osteoporosisResultMedia = null;
        var pdf = $(".uploadOsteoporosisPDF");
        $(pdf).attr("src", "/Content/Images/PageNotFound-Icons.jpg");

        $(pdf).unbind("click");

        $(this).hide();
        $(".pdf-osteoporosis-upload").show();
    });

});


function onClick_CriticalDataOsteo() {
    if ($("#DescribeSelfPresentOsteoInputCheck").attr("checked")) {
        loadCriticalLink($("#osteo-critical-span"), "onClick_CriticalDataOsteo();", testTypeOsteoporosis);
        openCriticalDataDialog(testTypeOsteoporosis, $("#conductedbyosteo"), $("#DescribeSelfPresentOsteoInputCheck"), setCriticalDataModel_Osteo);
    }
    else {
        unloadCriticalLink($("#osteo-critical-span"), testTypeOsteoporosis);
    }
}

function setCriticalDataModel_Osteo(model, printAfterSave) {
    if (model != null) {
        var testResult = GetOsteoData();
        saveSingleTestResult(testResult, model, $("#osteo-critical-span"), "onClick_CriticalDataOsteo();", SetOsteoData, printAfterSave);
    }
}

function getCriticalDataModel_Osteo() {
    if ($("#DescribeSelfPresentOsteoInputCheck").attr("checked") && criticalDataModel_Osteo != null) {
        criticalDataModel_Osteo.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_Osteo;
    }
    return null;
}

function onClick_PriorityInQueueDataOsteo() {
    if ($("#PriorityInQueueTestOsteoCheck").attr("checked")) {
        loadPriorityInQueueLink($("#osteo-priorityInQueue-span"), "onClick_PriorityInQueueDataOsteo();", testTypeOsteoporosis);
        openPriorityInQueueTestDialog(testTypeOsteoporosis, $("#conductedbyosteo"), $("#PriorityInQueueTestOsteoCheck"), setPriorityInQueueDataModel_Osteo);
    }
    else {
        unloadPriorityInQueueLink($("#osteo-priorityInQueue-span"), testTypeOsteoporosis);
    }
}

function setPriorityInQueueDataModel_Osteo(model) {
    if (model != null) {
        var testResult = GetOsteoData();
        model.TestId = testTypeOsteoporosis;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#osteo-priorityInQueue-span"), "onClick_PriorityInQueueDataOsteo();", SetOsteoData);
    }
}
function clearAllOsteoSelection() {
    $(".gv-findings-osteo input[type=radio]").attr("checked", false);
}

function setTestNotPerformedReasonForOsteo(testNotPerformed) {
    setTestNotPerformed("testnotPerformedOsteo", testNotPerformed);
    SetTestNotPerformedEnableDisabled("testnotPerformedOsteo");
}

function getTestNotPerformedReasonForOsteo(testNotPerformed) {
    return getTestNotPerformed("testnotPerformedOsteo", testNotPerformed);
}