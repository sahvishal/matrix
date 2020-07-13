function Lead(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = {
            "Id": '0', "TestType": testTypeLead, "DiagnosisCode": null,
            "LeftResultReadings": { "CFAPSV": null, "PSFAPSV": null, "Finding": null },
            "RightResultReadings": { "CFAPSV": null, "PSFAPSV": null, "Finding": null },
            "LowVelocityLeft": null,
            "LowVelocityRight": null,
            "ResultImages": new Array(),
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": '0',
            "UnableScreenReason": new Array(),
            "TestPerformedExternally": null,
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": {
                "Id": 0, "SelfPresent": false, "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestLeadCheck").attr("checked")
            }
        };
    }
    this.Result = testResult;
}

Lead.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (IsleadResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_leadcapturebyChat", testResult.TestPerformedExternally)
        }
        if (testResult.LeftResultReadings != null) {
            if (testResult.LeftResultReadings.Finding != null) {
                setSelectedFinding($(".gv-Findings-lead"), testResult.LeftResultReadings.Finding.Id, 'rbt-finding-lead-left');
            }
            
            setReading($("#LeftCFAPSVInputText"), testResult.LeftResultReadings.CFAPSV);
            setReading($("#LeftPSFAPSVInputText"), testResult.LeftResultReadings.PSFAPSV);
            
            setboolTypeReading($("#leftNoVisualPlaque"), testResult.LeftResultReadings.NoVisualPlaque);
            setboolTypeReading($("#leftVisuallyDemonstratedPlaque"), testResult.LeftResultReadings.VisuallyDemonstratedPlaque);
            setboolTypeReading($("#leftModerateStenosis"), testResult.LeftResultReadings.ModerateStenosis);
            setboolTypeReading($("#leftPossibleOcclusion"), testResult.LeftResultReadings.PossibleOcclusion);
        }

        if (testResult.RightResultReadings != null) {
            if (testResult.RightResultReadings.Finding != null) {
                setSelectedFinding($(".gv-Findings-lead"), testResult.RightResultReadings.Finding.Id, 'rbt-finding-lead-right');
            }

            setReading($("#RightCFAPSVInputText"),testResult.RightResultReadings.CFAPSV );
            setReading($("#RightPSFAPSVInputText"), testResult.RightResultReadings.PSFAPSV);
            
            setboolTypeReading($("#rightNoVisualPlaque"), testResult.RightResultReadings.NoVisualPlaque);
            setboolTypeReading($("#rightVisuallyDemonstratedPlaque"), testResult.RightResultReadings.VisuallyDemonstratedPlaque);
            setboolTypeReading($("#rightModerateStenosis"), testResult.RightResultReadings.ModerateStenosis);
            setboolTypeReading($("#rightPossibleOcclusion"), testResult.RightResultReadings.PossibleOcclusion);
        }
        $("#PriorityInQueueTestLeadCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#lead-priorityInQueue-span"), "onClick_PriorityInQueueDataLead();", testTypeLead);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#lead-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#lead-critical-span"), "onClick_CriticalDataLead();", testTypeLead);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#lead-critical-span").parent().addClass("red-band");
                $("#criticalLead").attr("checked", "checked");
            }
        }

        setReading($("#diagnosisCodeLead"), testResult.DiagnosisCode);

        $("#LowVelocityLeftCheckbox").attr("checked", testResult.LowVelocityLeft != null ? true : false);
        $("#LowVelocityRightCheckbox").attr("checked", testResult.LowVelocityRight != null ? true : false);

        
        setboolTypeReading($('#technicallyltdbutreadableleadinputcheck'), testResult.TechnicallyLimitedbutReadable);
        setboolTypeReading($('#repeatstudyleadinputcheck'), testResult.RepeatStudy);

        $("#chkselfLead").attr("checked", testResult.ResultStatus.SelfPresent);
        setUnableScreenReason($('.dtl-unabletoscreen-lead'), testResult.UnableScreenReason);
        
        setTestNotPerformedReasonForLead(testResult.TestNotPerformed);

        if (testResult.ResultImages && testResult.ResultImages.length > 0) {
            LoadNewImagesLead(testResult.ResultImages, true);
        }

        $("#technoteslead").val(testResult.TechnicianNotes);
        $("#conductedbylead option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);

        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksLead").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpLead").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalLead").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }
        
        setLeadDiagnosisCode(null);
    },
    getData: function () {
        var testResult = this.Result;
        if (IsleadResultEntryExternaly == 'True') {
            testResult.TestPerformedExternally = getTestPerformedExternally("chk_leadcapturebyChat", testResult.TestPerformedExternally)
        }

        if (testResult.LeftResultReadings == null) {
            testResult.LeftResultReadings = { "CFAPSV": null, "PSFAPSV": null, "Finding": null, "NoVisualPlaque": null, "VisuallyDemonstratedPlaque": null, "ModerateStenosis": null, "PossibleOcclusion": null };
        }
        testResult.LeftResultReadings.Finding = getFindingDataandSynchronized(testResult.LeftResultReadings.Finding, getSelectedFinding($(".gv-Findings-lead"), "rbt-finding-lead-left"));

        if (testResult.RightResultReadings == null) {
            testResult.RightResultReadings = { "CFAPSV": null, "PSFAPSV": null, "Finding": null, "NoVisualPlaque": null, "VisuallyDemonstratedPlaque": null, "ModerateStenosis": null, "PossibleOcclusion": null };
        }
        testResult.RightResultReadings.Finding = getFindingDataandSynchronized(testResult.RightResultReadings.Finding, getSelectedFinding($(".gv-Findings-lead"), "rbt-finding-lead-right"));

        if (testResult.LowVelocityLeft == null && $("#LowVelocityLeftCheckbox").attr("checked")) {
            testResult.LowVelocityLeft = { "Id": $("#LowVelocityLeftCheckbox").parent().find("input[type=hidden]").val() };
        }
        else if (testResult.LowVelocityLeft != null && !$("#LowVelocityLeftCheckbox").attr("checked")) {
            testResult.LowVelocityLeft = null;
        }

        if (testResult.LowVelocityRight == null && $("#LowVelocityRightCheckbox").attr("checked")) {
            testResult.LowVelocityRight = { "Id": $("#LowVelocityRightCheckbox").parent().find("input[type=hidden]").val() };
        }
        else if (testResult.LowVelocityRight != null && !$("#LowVelocityRightCheckbox").attr("checked")) {
            testResult.LowVelocityRight = null;
        }
        
        testResult.LeftResultReadings.NoVisualPlaque = getboolTypeReading($("#leftNoVisualPlaque"), testResult.LeftResultReadings.NoVisualPlaque);
        testResult.LeftResultReadings.VisuallyDemonstratedPlaque = getboolTypeReading($("#leftVisuallyDemonstratedPlaque"), testResult.LeftResultReadings.VisuallyDemonstratedPlaque);
        testResult.LeftResultReadings.ModerateStenosis = getboolTypeReading($("#leftModerateStenosis"), testResult.LeftResultReadings.ModerateStenosis);
        testResult.LeftResultReadings.PossibleOcclusion = getboolTypeReading($("#leftPossibleOcclusion"), testResult.LeftResultReadings.PossibleOcclusion);

        testResult.RightResultReadings.NoVisualPlaque = getboolTypeReading($("#rightNoVisualPlaque"), testResult.RightResultReadings.NoVisualPlaque);
        testResult.RightResultReadings.VisuallyDemonstratedPlaque = getboolTypeReading($("#rightVisuallyDemonstratedPlaque"), testResult.RightResultReadings.VisuallyDemonstratedPlaque);
        testResult.RightResultReadings.ModerateStenosis = getboolTypeReading($("#rightModerateStenosis"), testResult.RightResultReadings.ModerateStenosis);
        testResult.RightResultReadings.PossibleOcclusion = getboolTypeReading($("#rightPossibleOcclusion"), testResult.RightResultReadings.PossibleOcclusion);

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-lead')));
        
        testResult.TestNotPerformed = getTestNotPerformedReasonForLead(testResult.TestNotPerformed);

        testResult.DiagnosisCode = getReading($("#diagnosisCodeLead"), testResult.DiagnosisCode);

        testResult.LeftResultReadings.CFAPSV = getReading($("#LeftCFAPSVInputText"), testResult.LeftResultReadings.CFAPSV);
        testResult.LeftResultReadings.PSFAPSV = getReading($("#LeftPSFAPSVInputText"), testResult.LeftResultReadings.PSFAPSV);

        testResult.RightResultReadings.CFAPSV = getReading($("#RightCFAPSVInputText"), testResult.RightResultReadings.CFAPSV);
        testResult.RightResultReadings.PSFAPSV = getReading($("#RightPSFAPSVInputText"), testResult.RightResultReadings.PSFAPSV);

        if (currentScreenMode != ScreenMode.Physician) {

            var resultMedia = new Array();
            if (leadResultMedia != null) {
                $.each(leadResultMedia, function () { resultMedia.push(this); });
            }
            testResult.ResultImages = resultMedia;
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
            testResult.TechnicianNotes = $.trim($("#technoteslead").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ConductedByOrgRoleUserId = $("#conductedbylead option:selected").val();
            testResult.ResultStatus.SelfPresent = $("#chkselfLead").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestLeadCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_35").attr("checked");

        if (currentScreenMode != ScreenMode.Entry) {
            testResult.TechnicallyLimitedbutReadable = getboolTypeReading($('#technicallyltdbutreadableleadinputcheck'), testResult.TechnicallyLimitedbutReadable);
            testResult.RepeatStudy = getboolTypeReading($('#repeatstudyleadinputcheck'), testResult.RepeatStudy);

            if (testResult.PhysicianInterpretation == null) {
                testResult.PhysicianInterpretation = {
                    'Remarks': $("#physicianRemarksLead").val(), 'IsCritical': $("#criticalLead").attr("checked"), 'FollowUp': $("#followUpLead").attr("checked"), 'RecorderMetaData': {
                        'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate
                    }
                };
            }
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksLead").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpLead").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalLead").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }

        if (testResult.ResultStatus.StateNumber < 4) {
            if (testResult.LeftResultReadings.Finding == null && testResult.RightResultReadings.Finding == null
                    && testResult.UnableScreenReason == null && testResult.LeftResultReadings.CFAPSV == null && testResult.LeftResultReadings.PSFAPSV == null
                    && testResult.RightResultReadings.CFAPSV == null && testResult.RightResultReadings.PSFAPSV == null && testResult.TechnicianNotes.length < 1
                    && testResult.ConductedByOrgRoleUserId == "0" && StrokeImageCount == 0 && $("#chkselfLead").attr("checked") == false)
                return null;
        }

        return testResult;
    }
};

var LeadImageCount = 0;
var leadResultMedia = null;

function getLeadMedia() {
    return leadResultMedia;
}

function LoadNewImagesLead(jsonMedia, correctJson) {
    leadResultMedia = jsonMedia;
    LeadImageCount = 0;
    $("#LeadImageListDiv").empty();
    if (jsonMedia == null || jsonMedia.length < 1) return;
    LeadImageCount = jsonMedia.length;
    LoadNewMedia(jsonMedia, correctJson, $("#LeadImageListDiv"));
}


function getAbsoluteValue(resultReading) {
    if (resultReading != null && resultReading.Reading != null) {
        if (resultReading.Reading < 0) {
            resultReading.Reading = (-1) * resultReading.Reading;
        }
        return resultReading;
    }
    return null;
}

$(document).ready(function () {
    $(".gv-Findings-lead .rbt-finding-lead-right,.gv-Findings-lead .rbt-finding-lead-left,#LowVelocityRightCheckbox,#LowVelocityLeftCheckbox").click(function () {
        setLeadDiagnosisCode(this);
    });
    
    //setLeadDiagnosisCode(null);
});

function setLeadDiagnosisCode(ctrlRef) {
    //debugger;
    $("#diagnosisCodeLead").val("");
    
    var worstCase = -1;
    var rightWorstCase = -1;
    var leftWorstCase = -1;

    $(".gv-Findings-lead").find("tr").each(function () {
        if ($(this).find(".rbt-finding-lead-right").attr("checked") == true) {
            rightWorstCase = $(this).find(".finding-worstcaseorder").val();
        }

        if ($(this).find(".rbt-finding-lead-left").attr("checked") == true) {
            leftWorstCase = $(this).find(".finding-worstcaseorder").val();
        }
    });

    worstCase = rightWorstCase;
    if (leftWorstCase > rightWorstCase)
        worstCase = leftWorstCase;

    if (worstCase == 1 && $("#LowVelocityRightCheckbox").is(":checked") == false && $("#LowVelocityLeftCheckbox").is(":checked") == false) {
        $("#diagnosisCodeLead").val('Normal study');
    }
    else if (worstCase == 1 && ($("#LowVelocityRightCheckbox").is(":checked") == true || $("#LowVelocityLeftCheckbox").is(":checked") == true)) {
        $("#diagnosisCodeLead").val('443.89  peripheral arterial/vascular disease' + '|' + '440.20 atherosclerosis of native arteries of the extremities, unspecified');
    }
    else if (worstCase == 2 || worstCase == 3) {
        $("#diagnosisCodeLead").val('443.89  peripheral arterial/vascular disease'+ '|' +'440.20 atherosclerosis of native arteries of the extremities, unspecified');
    }
    else if (worstCase == 4) {
        $("#diagnosisCodeLead").val('443.89  peripheral arterial/vascular disease'+ '|' +'440.20 atherosclerosis of native arteries of the extremities, unspecified'+ '|' +'440.4 chronic total occlusion of the artery of extremities');
    }
}

var criticalDataModel_Lead = null;
function onClick_CriticalDataLead() {
    if ($("#chkselfLead").attr("checked")) {
        loadCriticalLink($("#lead-critical-span"), "onClick_CriticalDataLead();", testTypeLead);
        openCriticalDataDialog(testTypeLead, $("#conductedbylead"), $("#chkselfLead"), setCriticalDataModel_Lead);
    }
    else {
        unloadCriticalLink($("#lead-critical-span"), testTypeLead);
    }
}

function setCriticalDataModel_Lead(model, printAfterSave) {
    if (model != null) {
        var testResult = GetLeadData();
        saveSingleTestResult(testResult, model, $("#lead-critical-span"), "onClick_CriticalDataLead();", SetLeadData, printAfterSave);
    }
}

function getCriticalDataModel_Lead() {
    if ($("#chkselfLead").attr("checked") && criticalDataModel_Lead != null) {
        criticalDataModel_Lead.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_Lead;
    }
    return null;
}
function onClick_PriorityInQueueDataLead() {
    if ($("#PriorityInQueueTestLeadCheck").attr("checked")) {
        loadPriorityInQueueLink($("#lead-priorityInQueue-span"), "onClick_PriorityInQueueDataLead();", testTypeLead);
        openPriorityInQueueTestDialog(testTypeLead, $("#conductedbylead"), $("#PriorityInQueueTestLeadCheck"), setPriorityInQueueDataModel_Lead);
    }
    else {
        unloadPriorityInQueueLink($("#lead-priorityInQueue-span"), testTypeLead);
    }
}

function setPriorityInQueueDataModel_Lead(model) {
    if (model != null) {
        var testResult = GetLeadData();
        model.TestId = testTypeLead;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#lead-priorityInQueue-span"), "onClick_PriorityInQueueDataLead();", SetLeadData);
    }
}

function clearAllLeadSelection() {
    $(".gv-Findings-lead input[type=radio],.gv-Findings-lead input[type=checkbox], #LowVelocityRightCheckbox, #LowVelocityLeftCheckbox").attr("checked", false);
}


function setTestNotPerformedReasonForLead(testNotPerformed) {
    setTestNotPerformed("testnotPerformedLead", testNotPerformed);
    SetTestNotPerformedEnableDisabled("testnotPerformedLead");
}

function getTestNotPerformedReasonForLead(testNotPerformed) {
    return getTestNotPerformed("testnotPerformedLead", testNotPerformed);
}