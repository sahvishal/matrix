
var fileTypeDPNPDF;
var urlPrefix = getUrlPrefix();

function Dpn(object) {
    if (object == null || object == undefined) {
        object = {
            "Id": 0, "TestType": testTypeDpn,
            "Amplitude": null, "Finding": null, "ConductionVelocity": null, "RightLeg": null, "LeftLeg": null,
            "UnableScreenReason": new Array(),
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": '',
            "ResultImages": null,
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(), "IsResultEntrybyChat": false,
            "ResultStatus": {
                "Id": 0,
                "SelfPresent": false,
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestDpnCheck").attr("checked")
            },
            "TestPerformedExternally": null
        };
    }

    this.Result = object;
}

Dpn.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (isDPNResultEntryType == 'True') {
            setTestPerformedExternally("chk_dpncapturebyChat", testResult.TestPerformedExternally)
        }

        if (testResult.Finding != null) {
            setSelectedFinding($(".gv-findings-Dpn"), testResult.Finding.Id);
        }

        setReading($("#DpnAmplitudeInputText"), testResult.Amplitude);
        setReading($("#DpnConductionVelocityTextbox"), testResult.ConductionVelocity);

        setboolTypeReading($("#DpnRightLegCheckbox"), testResult.RightLeg);
        setboolTypeReading($("#DpnLeftLegCheckbox"), testResult.LeftLeg);


        setboolTypeReading($('#technicallyltdbutreadableDpninputcheck'), testResult.TechnicallyLimitedbutReadable);
        setboolTypeReading($('#repeatstudyDpninputcheck'), testResult.RepeatStudy);


        setUnableScreenReason($('.dtl-unabletoscreen-Dpn'), testResult.UnableScreenReason);

        if (testResult.ResultImage != null) {

            var expr;

            eval("expr = " + testResult.ResultImage.File.UploadedOn + ";");
            eval("testResult.ResultImage.File.UploadedOn = new " + expr.source + ";");

            setDPNFiles(testResult.ResultImage);
        }


        setTestNotPerformedReasonForDpn(testResult.TestNotPerformed);

        $("#DescribeSelfPresentDpnInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);
        $("#PriorityInQueueTestDpnCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);

        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#Dpn-priorityInQueue-span"), "onClick_PriorityInQueueDataDpn();", testTypeDpn);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#Dpn-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#Dpn-critical-span"), "onClick_CriticalDataDpn();", testTypeDpn);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#Dpn-critical-span").parent().addClass("red-band");
                $("#criticalDpn").attr("checked", "checked");
            }
        }

        $("#technotesDpn").val(testResult.TechnicianNotes);
        $("#conductedbyDpn option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);


        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksDpn").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpDpn").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalDpn").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }

    },
    getData: function () {

        var testResult = this.Result;
        if (isDPNResultEntryType == 'True') {
            testResult.TestPerformedExternally = getTestPerformedExternally("chk_dpncapturebyChat", testResult.TestPerformedExternally)
        } else {
            testResult.TestPerformedExternally = null;
        }

        var testFindings = getSelectedFinding($(".gv-findings-Dpn"));
        testResult.Finding = getFindingDataandSynchronized(testResult.Finding, testFindings);

        testResult.RightLeg = getboolTypeReading($("#DpnRightLegCheckbox"), testResult.RightLeg);
        testResult.LeftLeg = getboolTypeReading($("#DpnLeftLegCheckbox"), testResult.LeftLeg);

        testResult.TechnicallyLimitedbutReadable = getboolTypeReading($('#technicallyltdbutreadableDpninputcheck'), testResult.TechnicallyLimitedbutReadable);

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-Dpn')));

        testResult.TestNotPerformed = getTestNotPerformedReasonForDpn(testResult.TestNotPerformed);

        testResult.Amplitude = getReading($("#DpnAmplitudeInputText"), testResult.Amplitude);
        testResult.ConductionVelocity = getReading($("#DpnConductionVelocityTextbox"), testResult.ConductionVelocity);

        if (currentScreenMode != ScreenMode.Physician) {

            testResult.ResultImage = GetDpnMedia();

            if (currentScreenMode != ScreenMode.CorrectionPostEvaluation && currentScreenMode != ScreenMode.PostAudit) testResult.ResultStatus.StateNumber = $("#ResultStatusInputHidden").val();

            if (testResult.ResultStatus.Id > 0) {
                testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.ResultStatus.DataRecorderMetaData.DateModified = currentDate;
            } else {
                testResult.ResultStatus.DataRecorderMetaData = { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate };
            }

        }

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.ConductedByOrgRoleUserId = $("#conductedbyDpn option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesDpn").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentDpnInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestDpnCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_97").attr("checked");

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }

        if (currentScreenMode != ScreenMode.Entry) {

            testResult.RepeatStudy = getboolTypeReading($('#repeatstudyDpninputcheck'), testResult.RepeatStudy);

            if (testResult.PhysicianInterpretation == null)
                testResult.PhysicianInterpretation = {
                    'Remarks': $("#physicianRemarksDpn").val(),
                    'IsCritical': $("#criticalDpn").attr("checked"),
                    'FollowUp': $("#followUpDpn").attr("checked"),
                    'RecorderMetaData': {
                        'DataRecorderCreator': { 'Id': currentUser },
                        'DateCreated': currentDate
                    }
                };
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksDpn").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpDpn").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalDpn").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }

        if (testResult.ResultStatus.StateNumber < 4) {
            if (testResult.Amplitude == null && testResult.Finding == null && testResult.ConductionVelocity == null
                && (testResult.RightLeg == null || testResult.RightLeg.Reading == false) && (testResult.LeftLeg == null || testResult.LeftLeg.Reading == false)
                && testResult.TechnicianNotes.length < 1 && testResult.ConductedByOrgRoleUserId == "0" &&
                testResult.UnableScreenReason == null && $("#DescribeSelfPresentDpnInputCheck").attr("checked") == false)
                return null;
        }

        return testResult;
    }
};


var criticalDataModel_Dpn = null;
function onClick_CriticalDataDpn() {
    if ($("#DescribeSelfPresentDpnInputCheck").attr("checked")) {
        loadCriticalLink($("#Dpn-critical-span"), "onClick_CriticalDataDpn();", testTypeDpn);
        openCriticalDataDialog(testTypeDpn, $("#conductedbyDpn"), $("#DescribeSelfPresentDpnInputCheck"), setCriticalDataModel_Dpn);
    }
    else {
        unloadCriticalLink($("#Dpn-critical-span"), testTypeDpn);
    }
}

function setCriticalDataModel_Dpn(model, printAfterSave) {
    if (model != null) {
        var testResult = GetDpnData();
        saveSingleTestResult(testResult, model, $("#Dpn-critical-span"), "onClick_CriticalDataDpn();", SetDpnData, printAfterSave);
    }
}

function getCriticalDataModel_Dpn() {
    if ($("#DescribeSelfPresentDpnInputCheck").attr("checked") && criticalDataModel_Dpn != null) {
        criticalDataModel_Dpn.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_Dpn;
    }
    return null;
}

function onClick_PriorityInQueueDataDpn() {
    if ($("#PriorityInQueueTestDpnCheck").attr("checked")) {
        loadPriorityInQueueLink($("#Dpn-priorityInQueue-span"), "onClick_PriorityInQueueDataDpn();", testTypeDpn);
        openPriorityInQueueTestDialog(testTypeDpn, $("#conductedbyDpn"), $("#PriorityInQueueTestDpnCheck"), setPriorityInQueueDataModel_Dpn);
    }
    else {
        unloadPriorityInQueueLink($("#Dpn-priorityInQueue-span"), testTypeDpn);
    }
}

function setPriorityInQueueDataModel_Dpn(model) {
    if (model != null) {
        var testResult = GetDpnData();
        model.TestId = testTypeDpn;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#Dpn-priorityInQueue-span"), "onClick_PriorityInQueueDataDpn();", SetDpnData);
    }
}

function clearAllDpnSelection() {
    $(".gv-findings-Dpn input[type=radio]").attr("checked", false);
    $("#DpnRightLegCheckbox, #DpnLeftLegCheckbox").attr("checked", false);
}

function setTestNotPerformedReasonForDpn(testNotPerformed) {
    setTestNotPerformed("testnotPerformedDpn", testNotPerformed);
    SetTestNotPerformedEnableDisabled("testnotPerformedDpn");
}

function getTestNotPerformedReasonForDpn(testNotPerformed) {
    return getTestNotPerformed("testnotPerformedDpn", testNotPerformed);
}

var dpnImageCount = 0;
var dpnResultMedia = null;
var dpnPdfPhysicalPath = '';
var dpnPdfFileSize = 0;

var dpnPdfPhysicalPathUrl = '';

function setDPNFiles(jsonMedia) {
    dpnResultMedia = jsonMedia;
    dpnImageCount = 0;
    
    $(".uploadDpnPdf").attr("src", "/Content/Images/PageNotFound-Icons.jpg");
    $(".pdf-dpn-remove").hide();

    setDpnFileUrlAtStartUp(jsonMedia);
}

function setDpnFileUrlAtStartUp(jsonMedia) {

    if (jsonMedia == null) return;

    var fileName = jsonMedia.File.Path;
    setDpnFileUrl(fileName, jsonMedia.FileSize);
}

function setDpnFileUrl(fileName, fileSize) {
    var bolConfirm;
    
    if (fileName != null && fileName != "") {
        if ($.trim(fileName).length > 0 && dpnPdfPhysicalPath != null && dpnPdfPhysicalPath != "" && dpnPdfPhysicalPath != fileName) {
            bolConfirm = confirm("This will overwrite your existing Pdf. Do you want to continue?");
            if (!bolConfirm) return;
        }
        setDpnFileType(fileName, fileSize);
    }
}

function setDpnFileType(fileName, fileSize) {

    var pdf = $(".uploadDpnPDF");

    dpnPdfPhysicalPathUrl = urlPrefix + fileName;
    $(pdf).attr("src", "/App/Images/pdf-icon-mm.gif");

    dpnPdfPhysicalPath = fileName;
    dpnPdfFileSize = fileSize;

    $(pdf).unbind("click");

    $(pdf).click(function () {
        window.open(dpnPdfPhysicalPathUrl, '_blank');
    });

    $(".pdf-dpn-remove").show();
    $(".pdf-dpn-upload").hide();
}


function GetDpnMedia() {
    
    if ($.trim(dpnPdfPhysicalPath).length > 0) {
        if (dpnResultMedia == null) {
            dpnResultMedia = {
                "Id": 0,
                "ReadingSource": readingSourceManual,
                "File": { "Path": dpnPdfPhysicalPath, "FileSize": dpnPdfFileSize, "Type": fileTypeDPNPDF }
            };
        } else if (dpnResultMedia != null && dpnResultMedia.File.Path != dpnPdfPhysicalPath) {
            dpnResultMedia.File.Path = dpnPdfPhysicalPath;
            dpnResultMedia.File.FileSize = dpnPdfFileSize;
        }
    } else {
        dpnResultMedia = null;
    }

    return dpnResultMedia;
}


$(document).ready(function () {
  
    $(".pdf-dpn-remove").click(function () {
        dpnPdfPhysicalPath = '';
        dpnPdfFileSize = 0;
        dpnResultMedia = null;
        var pdf = $(".uploadDpnPDF");
        $(pdf).attr("src", "/Content/Images/PageNotFound-Icons.jpg");

        $(pdf).unbind("click");

        $(this).hide();
        $(".pdf-dpn-upload").show();
    });
});

/**************Upload Images Ends**********************************/
