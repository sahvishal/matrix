function HcpCarotid(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = {
            "Id": '0', "TestType": testTypeHcpCarotid,
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
                "IsPriorityInQueue": $("#PriorityInQueueTestHcpCarotidCheck").attr("checked")
            }
        };
    }
    this.Result = testResult;
}

HcpCarotid.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (IshcpCarotidResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_hcpCarotidcapturebyChat", testResult.TestPerformedExternally)
        }


        if (testResult.LeftResultReadings != null) {
            if (testResult.LeftResultReadings.Finding != null) {
                setSelectedFinding($(".gv-Findings-HcpCarotid"), testResult.LeftResultReadings.Finding.Id, 'rbt-finding-HcpCarotid-left');
            }

            setReading($("#HcpCarotidLICAPSVInputText"), getAbsoluteValue(testResult.LeftResultReadings.ICAPSV));
            setReading($("#HcpCarotidLICAEDVInputText"), getAbsoluteValue(testResult.LeftResultReadings.ICAEDV));
        }

        if (testResult.RightResultReadings != null) {
            if (testResult.RightResultReadings.Finding != null) {
                setSelectedFinding($(".gv-Findings-HcpCarotid"), testResult.RightResultReadings.Finding.Id, 'rbt-finding-HcpCarotid-right');
            }

            setReading($("#HcpCarotidRICAPSVInputText"), getAbsoluteValue(testResult.RightResultReadings.ICAPSV));
            setReading($("#HcpCarotidRICAEDVInputText"), getAbsoluteValue(testResult.RightResultReadings.ICAEDV));
        }
        $("#PriorityInQueueTestHcpCarotidCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#hcpCarotid-priorityInQueue-span"), "onClick_PriorityInQueueDataHcpCarotid();", testTypeHcpCarotid);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#hcpCarotid-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#HcpCarotid-critical-span"), "onClick_CriticalDataHcpCarotid();", testTypeHcpCarotid);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#HcpCarotid-critical-span").parent().addClass("red-band");
                $("#criticalHcpCarotid").attr("checked", "checked");
            }
        }


        $("#HcpCarotidLowVelocityLICACheckbox").attr("checked", testResult.LowVelocityLica != null ? true : false);
        $("#HcpCarotidLowVelocityRICACheckbox").attr("checked", testResult.LowVelocityRica != null ? true : false);

        setboolTypeReading($('#HcpCarotidvelocityelevatedright'), testResult.VelocityElevatedOnRight);
        setboolTypeReading($('#HcpCarotidvelocityelevatedleft'), testResult.VelocityElevatedOnLeft);
        setboolTypeReading($('#technicallyltdbutreadableHcpCarotidinputcheck'), testResult.TechnicallyLimitedbutReadable);
        setboolTypeReading($('#repeatstudyHcpCarotidinputcheck'), testResult.RepeatStudy);

        $("#chkselfHcpCarotid").attr("checked", testResult.ResultStatus.SelfPresent);
        setUnableScreenReason($('.dtl-unabletoscreen-HcpCarotid'), testResult.UnableScreenReason);

        setTestNotPerformedReasonForHcpCarotid(testResult.TestNotPerformed);

        if (testResult.ResultImages && testResult.ResultImages.length > 0) {
            LoadNewImagesHcpCarotid(testResult.ResultImages, true);
        }

        $("#technotesHcpCarotid").val(testResult.TechnicianNotes);
        $("#conductedbyHcpCarotid option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);

        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksHcpCarotid").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpHcpCarotid").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalHcpCarotid").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }
    },
    getData: function () {
        var testResult = this.Result;
        if (IshcpCarotidResultEntryExternaly == 'True') {
            testResult.TestPerformedExternally = getTestPerformedExternally("chk_hcpCarotidcapturebyChat", testResult.TestPerformedExternally)
        }
        
        if (testResult.LeftResultReadings == null) {
            testResult.LeftResultReadings = { "ICAPSV": null, "ICAEDV": null, "Finding": null };
        }
        testResult.LeftResultReadings.Finding = getFindingDataandSynchronized(testResult.LeftResultReadings.Finding, getSelectedFinding($(".gv-Findings-HcpCarotid"), "rbt-finding-HcpCarotid-left"));

        if (testResult.RightResultReadings == null) {
            testResult.RightResultReadings = { "ICAPSV": null, "ICAEDV": null, "Finding": null };
        }
        testResult.RightResultReadings.Finding = getFindingDataandSynchronized(testResult.RightResultReadings.Finding, getSelectedFinding($(".gv-Findings-HcpCarotid"), "rbt-finding-HcpCarotid-right"));

        if (testResult.LowVelocityLica == null && $("#HcpCarotidLowVelocityLICACheckbox").attr("checked")) {
            testResult.LowVelocityLica = { "Id": $("#HcpCarotidLowVelocityLICACheckbox").parent().find("input[type=hidden]").val() };
        }
        else if (testResult.LowVelocityLica != null && !$("#HcpCarotidLowVelocityLICACheckbox").attr("checked")) {
            testResult.LowVelocityLica = null;
        }

        if (testResult.LowVelocityRica == null && $("#HcpCarotidLowVelocityRICACheckbox").attr("checked")) {
            testResult.LowVelocityRica = { "Id": $("#HcpCarotidLowVelocityRICACheckbox").parent().find("input[type=hidden]").val() };
        }
        else if (testResult.LowVelocityRica != null && !$("#HcpCarotidLowVelocityRICACheckbox").attr("checked")) {
            testResult.LowVelocityRica = null;
        }

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-HcpCarotid')));

        testResult.TestNotPerformed = getTestNotPerformedReasonForHcpCarotid(testResult.TestNotPerformed);
        testResult.LeftResultReadings.ICAPSV = getReading($("#HcpCarotidLICAPSVInputText"), testResult.LeftResultReadings.ICAPSV);
        testResult.LeftResultReadings.ICAEDV = getReading($("#HcpCarotidLICAEDVInputText"), testResult.LeftResultReadings.ICAEDV);

        testResult.RightResultReadings.ICAPSV = getReading($("#HcpCarotidRICAPSVInputText"), testResult.RightResultReadings.ICAPSV);
        testResult.RightResultReadings.ICAEDV = getReading($("#HcpCarotidRICAEDVInputText"), testResult.RightResultReadings.ICAEDV);
        
        if (currentScreenMode != ScreenMode.Physician) {
            //testResult.LeftResultReadings.ICAPSV = getReading($("#HcpCarotidLICAPSVInputText"), testResult.LeftResultReadings.ICAPSV);
            //testResult.LeftResultReadings.ICAEDV = getReading($("#HcpCarotidLICAEDVInputText"), testResult.LeftResultReadings.ICAEDV);

            //testResult.RightResultReadings.ICAPSV = getReading($("#HcpCarotidRICAPSVInputText"), testResult.RightResultReadings.ICAPSV);
            //testResult.RightResultReadings.ICAEDV = getReading($("#HcpCarotidRICAEDVInputText"), testResult.RightResultReadings.ICAEDV);

            var resultMedia = new Array();
            if (HcpCarotidResultMedia != null) {
                $.each(HcpCarotidResultMedia, function () { resultMedia.push(this); });
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
            testResult.TechnicianNotes = $.trim($("#technotesHcpCarotid").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ConductedByOrgRoleUserId = $("#conductedbyHcpCarotid option:selected").val();
            testResult.ResultStatus.SelfPresent = $("#chkselfHcpCarotid").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestHcpCarotidCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_48").attr("checked");

        if (currentScreenMode != ScreenMode.Entry) {
            testResult.VelocityElevatedOnRight = getboolTypeReading($('#HcpCarotidvelocityelevatedright'), testResult.VelocityElevatedOnRight);
            testResult.VelocityElevatedOnLeft = getboolTypeReading($('#HcpCarotidvelocityelevatedleft'), testResult.VelocityElevatedOnLeft);
            testResult.TechnicallyLimitedbutReadable = getboolTypeReading($('#technicallyltdbutreadableHcpCarotidinputcheck'), testResult.TechnicallyLimitedbutReadable);
            testResult.RepeatStudy = getboolTypeReading($('#repeatstudyHcpCarotidinputcheck'), testResult.RepeatStudy);

            if (testResult.PhysicianInterpretation == null) {
                testResult.PhysicianInterpretation = {
                    'Remarks': $("#physicianRemarksHcpCarotid").val(), 'IsCritical': $("#criticalHcpCarotid").attr("checked"), 'FollowUp': $("#followUpHcpCarotid").attr("checked"), 'RecorderMetaData': {
                        'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate
                    }
                };
            }
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksHcpCarotid").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpHcpCarotid").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalHcpCarotid").attr("checked");
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
                    && testResult.ConductedByOrgRoleUserId == "0" && HcpCarotidImageCount == 0 && $("#chkselfHcpCarotid").attr("checked") == false)
                return null;
        }

        return testResult;
    }
};

var HcpCarotidImageCount = 0;
var HcpCarotidResultMedia = null;

function getHcpCarotidMedia() {
    return HcpCarotidResultMedia;
}

function LoadNewImagesHcpCarotid(jsonMedia, correctJson) {
    HcpCarotidResultMedia = jsonMedia;
    HcpCarotidImageCount = 0;
    $("#HcpCarotidImageListDiv").empty();
    if (jsonMedia == null || jsonMedia.length < 1) return;
    HcpCarotidImageCount = jsonMedia.length;
    LoadNewMedia(jsonMedia, correctJson, $("#HcpCarotidImageListDiv"));
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


var criticalDataModel_HcpCarotid = null;
function onClick_CriticalDataHcpCarotid() {
    if ($("#chkselfHcpCarotid").attr("checked")) {
        loadCriticalLink($("#HcpCarotid-critical-span"), "onClick_CriticalDataHcpCarotid();", testTypeHcpCarotid);
        openCriticalDataDialog(testTypeHcpCarotid, $("#conductedbyHcpCarotid"), $("#chkselfHcpCarotid"), setCriticalDataModel_HcpCarotid);
    }
    else {
        unloadCriticalLink($("#HcpCarotid-critical-span"), testTypeHcpCarotid);
    }
}

function setCriticalDataModel_HcpCarotid(model, printAfterSave) {
    if (model != null) {
        var testResult = GetHcpCarotidData();
        saveSingleTestResult(testResult, model, $("#HcpCarotid-critical-span"), "onClick_CriticalDataHcpCarotid();", SetHcpCarotidData, printAfterSave);
    }
}

function getCriticalDataModel_HcpCarotid() {
    if ($("#chkselfHcpCarotid").attr("checked") && criticalDataModel_HcpCarotid != null) {
        criticalDataModel_HcpCarotid.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_HcpCarotid;
    }
    return null;
}

function onClick_PriorityInQueueDataHcpCarotid() {
    if ($("#PriorityInQueueTestHcpCarotidCheck").attr("checked")) {
        loadPriorityInQueueLink($("#hcpCarotid-priorityInQueue-span"), "onClick_PriorityInQueueDataHcpCarotid();", testTypeHcpCarotid);
        openPriorityInQueueTestDialog(testTypeHcpCarotid, $("#conductedbyHcpCarotid"), $("#PriorityInQueueTestHcpCarotidCheck"), setPriorityInQueueDataModel_HcpCarotid);
    }
    else {
        unloadPriorityInQueueLink($("#hcpCarotid-priorityInQueue-span"), testTypeHcpCarotid);
    }
}

function setPriorityInQueueDataModel_HcpCarotid(model) {
    if (model != null) {
        var testResult = GetHcpCarotidData();
        model.TestId = testTypeHcpCarotid;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#hcpCarotid-priorityInQueue-span"), "onClick_PriorityInQueueDataHcpCarotid();", SetHcpCarotidData);
    }
}

function clearAllHcpCarotidSelection() {
    $(".gv-Findings-HcpCarotid input[type=radio], #HcpCarotidLowVelocityRICACheckbox, #HcpCarotidLowVelocityLICACheckbox").attr("checked", false);
}


function setTestNotPerformedReasonForHcpCarotid(testNotPerformed) {
    setTestNotPerformed("testnotPerformedHcpCarotid", testNotPerformed);
    SetTestNotPerformedEnableDisabled("testnotPerformedHcpCarotid");
}

function getTestNotPerformedReasonForHcpCarotid(testNotPerformed) {
    return getTestNotPerformed("testnotPerformedHcpCarotid", testNotPerformed);
}