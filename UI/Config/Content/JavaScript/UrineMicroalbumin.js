var fileTypeUrineMicroalbuminPDF;
var urlPrefix = getUrlPrefix();

function UrineMicroalbumin(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = {
            "Id": 0, "TestType": testTypeUrineMicroalbumin,
            "Finding": null,
            "UnableScreenReason": null,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": "0",
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": {
                "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentUrineMicroalbuminInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestUrineMicroalbuminCheck").attr("checked")
            },
            "TestPerformedExternally": null
        };
    }
    this.Result = testResult;
}

UrineMicroalbumin.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (isUrineMicroalbuminResultEntryType == 'True') {
            setTestPerformedExternally("chk_urineMicroalbumincapturebyChat", testResult.TestPerformedExternally)
        }
        if (testResult.Finding != null) {
            setSelectedFinding($(".gv-findings-UrineMicroalbumin"), testResult.Finding.Id);
        }

        setboolTypeReading($('#technicallyltdbutreadableUrineMicroalbumininputcheck'), testResult.TechnicallyLimitedbutReadable);
        setboolTypeReading($('#repeatstudyUrineMicroalbumininputcheck'), testResult.RepeatStudy);

        setUnableScreenReason($('.dtl-unabletoscreen-UrineMicroalbumin'), testResult.UnableScreenReason);

        setTestNotPerformedReasonForUrineMicroalbumin(testResult.TestNotPerformed);

        if (testResult.ResultImage != null) {
            var expr;

            eval("expr = " + testResult.ResultImage.File.UploadedOn + ";");
            eval("testResult.ResultImage.File.UploadedOn = new " + expr.source + ";");

            setUrineMicroalbuminFiles(testResult.ResultImage);
        }

        $("#DescribeSelfPresentUrineMicroalbuminInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);
        $("#conductedbyUrineMicroalbumin option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);
        $("#PriorityInQueueTestUrineMicroalbuminCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        $("#MicroalbuminSerialKeyInputtext").val(testResult.SerialKey != null ? testResult.SerialKey.Reading : "");
        $("#MicroalbuminValueKeyInputtext").val(testResult.MicroalbuminValue != null ? testResult.MicroalbuminValue.Reading : "");

        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#UrineMicroalbumin-priorityInQueue-span"), "onClick_PriorityInQueueDataUrineMicroalbumin();", testTypeUrineMicroalbumin);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#UrineMicroalbumin-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#UrineMicroalbumin-critical-span"), "onClick_CriticalDataUrineMicroalbumin();", testTypeUrineMicroalbumin);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#UrineMicroalbumin-critical-span").parent().addClass("red-band");
                $("#criticalUrineMicroalbumin").attr("checked", "checked");
            }
        }

        $("#technotesUrineMicroalbumin").val(testResult.TechnicianNotes);


        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksUrineMicroalbumin").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpUrineMicroalbumin").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalUrineMicroalbumin").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }
    },
    getData: function () {
        var testResult = this.Result;
        if (isUrineMicroalbuminResultEntryType == 'True') {
            testResult.TestPerformedExternally = getTestPerformedExternally("chk_urineMicroalbumincapturebyChat", testResult.TestPerformedExternally)
        }

        var testFindings = getSelectedFinding($(".gv-findings-UrineMicroalbumin"));
        testResult.Finding = getFindingDataandSynchronized(testResult.Finding, testFindings);

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-UrineMicroalbumin')));

        testResult.TestNotPerformed = getTestNotPerformedReasonForUrineMicroalbumin(testResult.TestNotPerformed);
        testResult.SerialKey = getReading($("#MicroalbuminSerialKeyInputtext"), testResult.SerialKey);
        testResult.MicroalbuminValue = getReading($("#MicroalbuminValueKeyInputtext"), testResult.MicroalbuminValue);
        
        if (currentScreenMode != ScreenMode.Physician) {

            testResult.ResultImage = GetUrineMicroalbuminMedia();

            if (currentScreenMode != ScreenMode.CorrectionPostEvaluation && currentScreenMode != ScreenMode.PostAudit) testResult.ResultStatus.StateNumber = $("#ResultStatusInputHidden").val();

            if (testResult.ResultStatus.Id > 0) {
                testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.ResultStatus.DataRecorderMetaData.DateModified = currentDate;
            } else {
                testResult.ResultStatus.DataRecorderMetaData = { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate };
            }
            
            //testResult.SerialKey = getReading($("#MicroalbuminSerialKeyInputtext"), testResult.SerialKey);
        }

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.ConductedByOrgRoleUserId = $("#conductedbyUrineMicroalbumin option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesUrineMicroalbumin").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentUrineMicroalbuminInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestUrineMicroalbuminCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_89").attr("checked");

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }


        if (currentScreenMode != ScreenMode.Entry) {
            testResult.TechnicallyLimitedbutReadable = getboolTypeReading($('#technicallyltdbutreadableUrineMicroalbumininputcheck'), testResult.TechnicallyLimitedbutReadable);
            testResult.RepeatStudy = getboolTypeReading($('#repeatstudyUrineMicroalbumininputcheck'), testResult.RepeatStudy);

            if (testResult.PhysicianInterpretation == null)
                testResult.PhysicianInterpretation = {
                    'Remarks': $("#physicianRemarksUrineMicroalbumin").val(),
                    'IsCritical': $("#criticalUrineMicroalbumin").attr("checked"),
                    'FollowUp': $("#followUpUrineMicroalbumin").attr("checked"),
                    'RecorderMetaData': {
                        'DataRecorderCreator': { 'Id': currentUser },
                        'DateCreated': currentDate
                    }
                };
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksUrineMicroalbumin").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpUrineMicroalbumin").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalUrineMicroalbumin").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }


        if (testResult.ResultStatus.StateNumber < 4) {
            // To Check if no entry has been done
            if (testResult.Fev1 == null && testResult.UnableScreenReason == null && testResult.TechnicianNotes.length < 1
                && testResult.ConductedByOrgRoleUserId == "0" && $("#chkselfUrineMicroalbumin").attr("checked") == false) return null;
        }

        return testResult;
    }
};

var criticalDataModel_UrineMicroalbumin = null;
function onClick_CriticalDataUrineMicroalbumin() {
    if ($("#DescribeSelfPresentUrineMicroalbuminInputCheck").attr("checked")) {
        loadCriticalLink($("#UrineMicroalbumin-critical-span"), "onClick_CriticalDataUrineMicroalbumin();", testTypeUrineMicroalbumin);
        openCriticalDataDialog(testTypeUrineMicroalbumin, $("#conductedbyUrineMicroalbumin"), $("#DescribeSelfPresentUrineMicroalbuminInputCheck"), setCriticalDataModel_UrineMicroalbumin);
    }
    else {
        unloadCriticalLink($("#UrineMicroalbumin-critical-span"), testTypeUrineMicroalbumin);
    }
}

function setCriticalDataModel_UrineMicroalbumin(model, printAfterSave) {
    if (model != null) {
        var testResult = GetUrineMicroalbuminData();
        saveSingleTestResult(testResult, model, $("#UrineMicroalbumin-critical-span"), "onClick_CriticalDataUrineMicroalbumin();", SetUrineMicroalbuminData, printAfterSave);
    }
}

function getCriticalDataModel_UrineMicroalbumin() {
    if ($("#DescribeSelfPresentUrineMicroalbuminInputCheck").attr("checked") && criticalDataModel_UrineMicroalbumin != null) {
        criticalDataModel_UrineMicroalbumin.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_UrineMicroalbumin;
    }
    return null;
}
function onClick_PriorityInQueueDataUrineMicroalbumin() {
    if ($("#PriorityInQueueTestUrineMicroalbuminCheck").attr("checked")) {
        loadPriorityInQueueLink($("#UrineMicroalbumin-priorityInQueue-span"), "onClick_PriorityInQueueDataUrineMicroalbumin();", testTypeUrineMicroalbumin);
        openPriorityInQueueTestDialog(testTypeUrineMicroalbumin, $("#conductedbyUrineMicroalbumin"), $("#PriorityInQueueTestUrineMicroalbuminCheck"), setPriorityInQueueDataModel_UrineMicroalbumin);
    }
    else {
        unloadPriorityInQueueLink($("#UrineMicroalbumin-priorityInQueue-span"), testTypeUrineMicroalbumin);
    }
}

function setPriorityInQueueDataModel_UrineMicroalbumin(model) {
    if (model != null) {
        var testResult = GetUrineMicroalbuminData();
        model.TestId = testTypeUrineMicroalbumin;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#UrineMicroalbumin-priorityInQueue-span"), "onClick_PriorityInQueueDataUrineMicroalbumin();", SetUrineMicroalbuminData);
    }
}
function clearAllUrineMicroalbuminSelection() {
    $(".gv-findings-UrineMicroalbumin input[type=radio]").attr("checked", false);
}




/**************Upload Images Start**********************/
var urineMicroalbuminFileCount = 0;
var urineMicroalbuminResultMedia = null;

var urineMicroalbuminPdfPhysicalPath = '';
var urineMicroalbuminPdfFileSize = 0;
var urineMicroalbuminPdfPhysicalPathUrl = '';


function setUrineMicroalbuminFiles(jsonMedia) {
    urineMicroalbuminResultMedia = jsonMedia;
    urineMicroalbuminFileCount = 0;

    $(".uploadUrineMicroalbuminPDF").attr("src", "/Content/Images/PageNotFound-Icons.jpg");
    $(".pdf-UrineMicroalbumin-remove").hide();

    setUrineMicroalbuminFileUrlAtStartUp(jsonMedia);
}

function setUrineMicroalbuminFileUrlAtStartUp(jsonMedia) {

    if (jsonMedia == null) return;

    var fileName = jsonMedia.File.Path;
    setUrineMicroalbuminFileUrl(fileName, jsonMedia.FileSize);
}

function setUrineMicroalbuminFileUrl(fileName, fileSize) {
    var bolConfirm;

    if (fileName != null && fileName != "") {
        if ($.trim(fileName).length > 0 && urineMicroalbuminPdfPhysicalPath != null && urineMicroalbuminPdfPhysicalPath != "") {
            bolConfirm = confirm("This will overwrite your existing Pdf. Do you want to continue?");
            if (!bolConfirm) return;
        }
        setUrineMicroalbuminFileType(fileName, fileSize);
    }
}

function setUrineMicroalbuminFileType(fileName, fileSize) {

    var pdf = $(".uploadUrineMicroalbuminPDF");

    urineMicroalbuminPdfPhysicalPathUrl = urlPrefix + fileName;
    $(pdf).attr("src", "/App/Images/pdf-icon-mm.gif");

    urineMicroalbuminPdfPhysicalPath = fileName;
    urineMicroalbuminPdfFileSize = fileSize;

    $(pdf).unbind("click");

    $(pdf).click(function () {
        window.open(urineMicroalbuminPdfPhysicalPathUrl, '_blank');
    });

    $(".pdf-UrineMicroalbumin-remove").show();
}

function GetUrineMicroalbuminMedia() {
    if ($.trim(urineMicroalbuminPdfPhysicalPath).length > 0) {
        if (urineMicroalbuminResultMedia == null) {
            urineMicroalbuminResultMedia = {
                "Id": 0,
                "ReadingSource": readingSourceManual,
                "File": { "Path": urineMicroalbuminPdfPhysicalPath, "FileSize": urineMicroalbuminPdfFileSize, "Type": fileTypeUrineMicroalbuminPDF }
            };
        } else if (urineMicroalbuminResultMedia != null && urineMicroalbuminResultMedia.File.Path != urineMicroalbuminPdfPhysicalPath) {
            urineMicroalbuminResultMedia.File.Path = urineMicroalbuminPdfPhysicalPath;
            urineMicroalbuminResultMedia.File.FileSize = urineMicroalbuminPdfFileSize;
        }
    } else {
        urineMicroalbuminResultMedia = null;
    }

    return urineMicroalbuminResultMedia;
}

$(document).ready(function () {
    $(".pdf-UrineMicroalbumin-remove").click(function () {
        urineMicroalbuminPdfPhysicalPath = '';
        urineMicroalbuminPdfFileSize = 0;
        urineMicroalbuminResultMedia = null;

        var pdf = $(".uploadUrineMicroalbuminPDF");
        $(pdf).attr("src", "/Content/Images/PageNotFound-Icons.jpg");

        $(pdf).unbind("click");

        $(this).hide();
    });

});


function checkUrineMicroalbuminFindingsForGenderChange(isMale) {
    if ($("#UrineMicroalbuminfindingjson").length < 1) return;

    var urineMicroalbuminFindings = null;
    eval("urineMicroalbuminFindings = " + $("#UrineMicroalbuminfindingjson").val());
    if (urineMicroalbuminFindings == null) return;

    var gridUrineMicroalbumin = $(".gv-findings-UrineMicroalbumin");
    gridUrineMicroalbumin.find('input[type=radio]').attr("checked", false);

    var count = 0;
    var toCheckFor = isMale ? "male - " : "female - ";

    for (var i = 0; i < urineMicroalbuminFindings.length; i++) {
        var finding = urineMicroalbuminFindings[i];
        if (finding.Label.toLowerCase().indexOf(toCheckFor) == 0) {
            var row = $(gridUrineMicroalbumin.find("tr")[count]);
            row.find(".finding-id").val(finding.Id);
            row.find(".finding-minvalue").val(finding.MinValue);
            row.find(".finding-maxvalue").val(finding.MaxValue);
          
            var labelcell = $(row.find(".urnlbl"));
            var descriptionCell = $(row.find(".urnDescription"));

            $(labelcell).text(finding.Label.substring(toCheckFor.length - 1, finding.Label.length));
            $(descriptionCell).html(finding.Description);
                  
            count++;
        }
    }
}

/**************Upload Images Ends**********************************/



function setTestNotPerformedReasonForUrineMicroalbumin(testNotPerformed) {
    setTestNotPerformed("testnotPerformedUrineMicroalbumin", testNotPerformed);
    SetTestNotPerformedEnableDisabled("testnotPerformedUrineMicroalbumin");
}

function getTestNotPerformedReasonForUrineMicroalbumin(testNotPerformed) {
    return getTestNotPerformed("testnotPerformedUrineMicroalbumin", testNotPerformed);
}