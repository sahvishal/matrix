function Stroke(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = {
            "Id": '0', "TestType": testTypeStroke,
            "LeftResultReadings": { "ICAPSV": null, "ICAEDV": null, "Finding": null },
            "RightResultReadings": { "ICAPSV": null, "ICAEDV": null, "Finding": null },
            "LowVelocityLica": null,
            "LowVelocityRica": null,
            "ResultImages": new Array(),
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": '0',
            "UnableScreenReason": new Array(),
            "TestPerformedExternally": null,
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": {
                "Id": 0, "SelfPresent": false,
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestStrokeCheck").attr("checked")
            }
        };
    }
    this.Result = testResult;
}

Stroke.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (IsstrokeResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_strokecapturebyChat", testResult.TestPerformedExternally)
        }

        if (testResult.LeftResultReadings != null) {
            if (testResult.LeftResultReadings.Finding != null) {
                setSelectedFinding($(".gv-Findings-stroke"), testResult.LeftResultReadings.Finding.Id, 'rbt-finding-stroke-left');
            }

            setReading($("#LICAPSVInputText"), getAbsoluteValue(testResult.LeftResultReadings.ICAPSV));
            setReading($("#LICAEDVInputText"), getAbsoluteValue(testResult.LeftResultReadings.ICAEDV));
        }

        if (testResult.RightResultReadings != null) {
            if (testResult.RightResultReadings.Finding != null) {
                setSelectedFinding($(".gv-Findings-stroke"), testResult.RightResultReadings.Finding.Id, 'rbt-finding-stroke-right');
            }

            setReading($("#RICAPSVInputText"), getAbsoluteValue(testResult.RightResultReadings.ICAPSV));
            setReading($("#RICAEDVInputText"), getAbsoluteValue(testResult.RightResultReadings.ICAEDV));
        }
        $("#PriorityInQueueTestStrokeCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#stroke-priorityInQueue-span"), "onClick_PriorityInQueueDataStroke();", testTypeStroke);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#stroke-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#stroke-critical-span"), "onClick_CriticalDataStroke();", testTypeStroke);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#stroke-critical-span").parent().addClass("red-band");
                $("#criticalStroke").attr("checked", "checked");
            }
        }

        $("#LowVelocityLICACheckbox").attr("checked", testResult.LowVelocityLica != null ? true : false);
        $("#LowVelocityRICACheckbox").attr("checked", testResult.LowVelocityRica != null ? true : false);

        setboolTypeReading($('#velocityelevatedright'), testResult.VelocityElevatedOnRight);
        setboolTypeReading($('#velocityelevatedleft'), testResult.VelocityElevatedOnLeft);
        setboolTypeReading($('#technicallyltdbutreadablestrokeinputcheck'), testResult.TechnicallyLimitedbutReadable);
        setboolTypeReading($('#repeatstudystrokeinputcheck'), testResult.RepeatStudy);

        setboolTypeReading($('#StrokeConsiderOtherModalities'), testResult.ConsiderOtherModalities);
        setboolTypeReading($('#StrokeAdditionalImagesNeeded'), testResult.AdditionalImagesNeeded);

        $("#chkselfStroke").attr("checked", testResult.ResultStatus.SelfPresent);
        setUnableScreenReason($('.dtl-unabletoscreen-stroke'), testResult.UnableScreenReason);

        if (testResult.ResultImages && testResult.ResultImages.length > 0) {
            LoadNewImagesCarotid(testResult.ResultImages, true);
        }

        $("#technotesstroke").val(testResult.TechnicianNotes);
        $("#conductedbystroke option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);

        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksStroke").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpStroke").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalStroke").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }
    },
    getData: function () {
        var testResult = this.Result;

        if (IsstrokeResultEntryExternaly == 'True') {
            testResult.TestPerformedExternally = getTestPerformedExternally("chk_strokecapturebyChat", testResult.TestPerformedExternally)
        }

        if (testResult.LeftResultReadings == null) {
            testResult.LeftResultReadings = { "ICAPSV": null, "ICAEDV": null, "Finding": null };
        }
        testResult.LeftResultReadings.Finding = getFindingDataandSynchronized(testResult.LeftResultReadings.Finding, getSelectedFinding($(".gv-Findings-stroke"), "rbt-finding-stroke-left"));

        if (testResult.RightResultReadings == null) {
            testResult.RightResultReadings = { "ICAPSV": null, "ICAEDV": null, "Finding": null };
        }
        testResult.RightResultReadings.Finding = getFindingDataandSynchronized(testResult.RightResultReadings.Finding, getSelectedFinding($(".gv-Findings-stroke"), "rbt-finding-stroke-right"));

        if (testResult.LowVelocityLica == null && $("#LowVelocityLICACheckbox").attr("checked")) {
            testResult.LowVelocityLica = { "Id": $("#LowVelocityLICACheckbox").parent().find("input[type=hidden]").val() };
        }
        else if (testResult.LowVelocityLica != null && !$("#LowVelocityLICACheckbox").attr("checked")) {
            testResult.LowVelocityLica = null;
        }

        if (testResult.LowVelocityRica == null && $("#LowVelocityRICACheckbox").attr("checked")) {
            testResult.LowVelocityRica = { "Id": $("#LowVelocityRICACheckbox").parent().find("input[type=hidden]").val() };
        }
        else if (testResult.LowVelocityRica != null && !$("#LowVelocityRICACheckbox").attr("checked")) {
            testResult.LowVelocityRica = null;
        }

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-stroke')));

        testResult.ConsiderOtherModalities = getboolTypeReading($('#StrokeConsiderOtherModalities'), testResult.ConsiderOtherModalities);
        testResult.AdditionalImagesNeeded = getboolTypeReading($('#StrokeAdditionalImagesNeeded'), testResult.AdditionalImagesNeeded);
        
        testResult.LeftResultReadings.ICAPSV = getReading($("#LICAPSVInputText"), testResult.LeftResultReadings.ICAPSV);
        testResult.LeftResultReadings.ICAEDV = getReading($("#LICAEDVInputText"), testResult.LeftResultReadings.ICAEDV);

        testResult.RightResultReadings.ICAPSV = getReading($("#RICAPSVInputText"), testResult.RightResultReadings.ICAPSV);
        testResult.RightResultReadings.ICAEDV = getReading($("#RICAEDVInputText"), testResult.RightResultReadings.ICAEDV);

       if (currentScreenMode != ScreenMode.Physician) {     
            var resultMedia = new Array();
            if (strokeResultMedia != null) {
                $.each(strokeResultMedia, function () { resultMedia.push(this); });
            }
            testResult.ResultImages = resultMedia;
            if (currentScreenMode != ScreenMode.CorrectionPostEvaluation) testResult.ResultStatus.StateNumber = $("#ResultStatusInputHidden").val();

            if (testResult.ResultStatus.Id > 0) {
                testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.ResultStatus.DataRecorderMetaData.DateModified = currentDate;
            }
            else {
                testResult.ResultStatus.DataRecorderMetaData = { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate };
            }
        }

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.TechnicianNotes = $.trim($("#technotesstroke").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ConductedByOrgRoleUserId = $("#conductedbystroke option:selected").val();
            testResult.ResultStatus.SelfPresent = $("#chkselfStroke").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestStrokeCheck").attr("checked");
        }

        testResult.IsRetest = $("#Stroke").attr("checked");

        if (currentScreenMode != ScreenMode.Entry) {
            testResult.VelocityElevatedOnRight = getboolTypeReading($('#velocityelevatedright'), testResult.VelocityElevatedOnRight);
            testResult.VelocityElevatedOnLeft = getboolTypeReading($('#velocityelevatedleft'), testResult.VelocityElevatedOnLeft);
            testResult.TechnicallyLimitedbutReadable = getboolTypeReading($('#technicallyltdbutreadablestrokeinputcheck'), testResult.TechnicallyLimitedbutReadable);
            testResult.RepeatStudy = getboolTypeReading($('#repeatstudystrokeinputcheck'), testResult.RepeatStudy);

            if (testResult.PhysicianInterpretation == null) {
                testResult.PhysicianInterpretation = {
                    'Remarks': $("#physicianRemarksStroke").val(), 'IsCritical': $("#criticalStroke").attr("checked"), 'FollowUp': $("#followUpStroke").attr("checked"), 'RecorderMetaData': {
                        'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate
                    }
                };
            }
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksStroke").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpStroke").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalStroke").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }

        if (testResult.ResultStatus.StateNumber < 4) {
            if (testResult.LeftResultReadings.Finding == null && testResult.RightResultReadings.Finding == null
                    && testResult.UnableScreenReason == null && testResult.LeftResultReadings.ICAEDV == null && testResult.LeftResultReadings.ICAPSV == null
                    && testResult.RightResultReadings.ICAEDV == null && testResult.RightResultReadings.ICAPSV == null && testResult.TechnicianNotes.length < 1
                    && testResult.ConductedByOrgRoleUserId == "0" && StrokeImageCount == 0 && $("#chkselfStroke").attr("checked") == false)
                return null;
        }

        return testResult;
    }
};

var StrokeImageCount = 0;
var strokeResultMedia = null;

function getStrokeMedia() {
    return strokeResultMedia;
}

function LoadNewImagesCarotid(jsonMedia, correctJson) {
    strokeResultMedia = jsonMedia;
    StrokeImageCount = 0;
    $("#StrokeImageListDiv").empty();
    if (jsonMedia == null || jsonMedia.length < 1) return;
    StrokeImageCount = jsonMedia.length;
    LoadNewMedia(jsonMedia, correctJson, $("#StrokeImageListDiv"));
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


var criticalDataModel_Stroke = null;
function onClick_CriticalDataStroke() {
    if ($("#chkselfStroke").attr("checked")) {
        loadCriticalLink($("#stroke-critical-span"), "onClick_CriticalDataStroke();", testTypeStroke);
        openCriticalDataDialog(testTypeStroke, $("#conductedbystroke"), $("#chkselfStroke"), setCriticalDataModel_Stroke);
    }
    else {
        unloadCriticalLink($("#stroke-critical-span"), testTypeStroke);
    }
}

function setCriticalDataModel_Stroke(model, printAfterSave) {
    if (model != null) {
        var testResult = GetStrokeData();
        saveSingleTestResult(testResult, model, $("#stroke-critical-span"), "onClick_CriticalDataStroke();", SetStrokeData, printAfterSave);
    }
}

function getCriticalDataModel_Stroke() {
    if ($("#chkselfStroke").attr("checked") && criticalDataModel_Stroke != null) {
        criticalDataModel_Stroke.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_Stroke;
    }
    return null;
}
function onClick_PriorityInQueueDataStroke() {
    if ($("#PriorityInQueueTestStrokeCheck").attr("checked")) {
        loadPriorityInQueueLink($("#stroke-priorityInQueue-span"), "onClick_PriorityInQueueDataStroke();", testTypeStroke);
        openPriorityInQueueTestDialog(testTypeStroke, $("#conductedbystroke"), $("#PriorityInQueueTestStrokeCheck"), setPriorityInQueueDataModel_Stroke);
    }
    else {
        unloadPriorityInQueueLink($("#stroke-priorityInQueue-span"), testTypeStroke);
    }
}

function setPriorityInQueueDataModel_Stroke(model) {
    if (model != null) {
        var testResult = GetStrokeData();
        model.TestId = testTypeStroke;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#stroke-priorityInQueue-span"), "onClick_PriorityInQueueDataStroke();", SetStrokeData);
    }
}
function clearAllStrokeSelection() {
    $(".gv-Findings-stroke input[type=radio], #LowVelocityRICACheckbox, #LowVelocityLICACheckbox").attr("checked", false);
}

$(document).ready(function() {

    $(".gv-Findings-stroke input[type=radio], #LowVelocityRICACheckbox, #LowVelocityLICACheckbox").click(function() {
        $("input[name=StrokePhysicianAdditionalFindingReading]:radio").attr("checked", false);
    });
});