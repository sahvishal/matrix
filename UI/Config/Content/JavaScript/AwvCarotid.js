function AwvCarotid(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = {
            "Id": '0', "TestType": testTypeAwvCarotid,
            "LeftResultReadings": {
                "CCAProximalPSV": null,
                "CCAProximalEDV": null,

                "CCADistalPSV": null,
                "CCADistalEDV": null,

                "BulbPSV": null,
                "BulbEDV": null,

                "ExtCarotidArtPSV": null,

                "ICAProximalPSV": null,
                "ICAProximalEDV": null,

                "ICADistalPSV": null,
                "ICADistalEDV": null,

                "VertebralArtPSV": null,
                "VertebralArtEDV": null,

                "Finding": null
            },
            "RightResultReadings": {
                "CCAProximalPSV": null,
                "CCAProximalEDV": null,

                "CCADistalPSV": null,
                "CCADistalEDV": null,

                "BulbPSV": null,
                "BulbEDV": null,

                "ExtCarotidArtPSV": null,

                "ICAProximalPSV": null,
                "ICAProximalEDV": null,

                "ICADistalPSV": null,
                "ICADistalEDV": null,

                "VertebralArtPSV": null,
                "VertebralArtEDV": null,

                "Finding": null
            },
            "LowVelocityLica": null,
            "LowVelocityRica": null,
            "ResultImages": new Array(),
            "TechnicianNotes": '', "ConductedByLoadNewImagesCarotidOrgRoleUserId": '0',
            "UnableScreenReason": new Array(),
            "TestPerformedExternally": null,
             
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": {
                "Id": 0, "SelfPresent": false,
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestAwvCarotidCheck").attr("checked")
            }
        };
    }
    this.Result = testResult;
}

AwvCarotid.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (IsawvCarotidResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_awvCarotidcapturebyChat", testResult.TestPerformedExternally)
        }

        if (testResult.LeftResultReadings != null) {
            if (testResult.LeftResultReadings.Finding != null) {
                setSelectedFinding($(".gv-Findings-AwvCarotid"), testResult.LeftResultReadings.Finding.Id, 'rbt-finding-AwvCarotid-left');
            }
            setReading($("#LCCAProximalPSVInputText"), testResult.LeftResultReadings.CCAProximalPSV);
            setReading($("#LCCAProximalEDVInputText"), testResult.LeftResultReadings.CCAProximalEDV);

            setReading($("#LCCADistalPSVInputText"), testResult.LeftResultReadings.CCADistalPSV);
            setReading($("#LCCADistalEDVInputText"), testResult.LeftResultReadings.CCADistalEDV);

            setReading($("#LBulbPSVInputText"), testResult.LeftResultReadings.BulbPSV);
            setReading($("#LBulbEDVInputText"), testResult.LeftResultReadings.BulbEDV);

            setReading($("#LExtCarotidArtPSVInputText"), testResult.LeftResultReadings.ExtCarotidArtPSV);

            setReading($("#LICAProximalPSVInputText"), testResult.LeftResultReadings.ICAProximalPSV);
            setReading($("#LICAProximalEDVInputText"), testResult.LeftResultReadings.ICAProximalEDV);

            setReading($("#LICADistalPSVInputText"), testResult.LeftResultReadings.ICADistalPSV);
            setReading($("#LICADistalEDVInputText"), testResult.LeftResultReadings.ICADistalEDV);

            setReading($("#LVertebralArtPSVInputText"), testResult.LeftResultReadings.VertebralArtPSV);
            setReading($("#LVertebralArtEDVInputText"), testResult.LeftResultReadings.VertebralArtEDV);
        }

        if (testResult.RightResultReadings != null) {
            if (testResult.RightResultReadings.Finding != null) {
                setSelectedFinding($(".gv-Findings-AwvCarotid"), testResult.RightResultReadings.Finding.Id, 'rbt-finding-AwvCarotid-right');
            }

            setReading($("#RCCAProximalPSVInputText"), testResult.RightResultReadings.CCAProximalPSV);
            setReading($("#RCCAProximalEDVInputText"), testResult.RightResultReadings.CCAProximalEDV);

            setReading($("#RCCADistalPSVInputText"), testResult.RightResultReadings.CCADistalPSV);
            setReading($("#RCCADistalEDVInputText"), testResult.RightResultReadings.CCADistalEDV);

            setReading($("#RBulbPSVInputText"), testResult.RightResultReadings.BulbPSV);
            setReading($("#RBulbEDVInputText"), testResult.RightResultReadings.BulbEDV);

            setReading($("#RExtCarotidArtPSVInputText"), testResult.RightResultReadings.ExtCarotidArtPSV);

            setReading($("#RICAProximalPSVInputText"), testResult.RightResultReadings.ICAProximalPSV);
            setReading($("#RICAProximalEDVInputText"), testResult.RightResultReadings.ICAProximalEDV);

            setReading($("#RICADistalPSVInputText"), testResult.RightResultReadings.ICADistalPSV);
            setReading($("#RICADistalEDVInputText"), testResult.RightResultReadings.ICADistalEDV);

            setReading($("#RVertebralArtPSVInputText"), testResult.RightResultReadings.VertebralArtPSV);
            setReading($("#RVertebralArtEDVInputText"), testResult.RightResultReadings.VertebralArtEDV);
        }
        $("#PriorityInQueueTestAwvCarotidCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#awvCarotid-priorityInQueue-span"), "onClick_PriorityInQueueDataAwvCarotid();", testTypeAwvCarotid);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#awvCarotid-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#AwvCarotid-critical-span"), "onClick_CriticalDataAwvCarotid();", testTypeAwvCarotid);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#AwvCarotid-critical-span").parent().addClass("red-band");
                $("#criticalAwvCarotid").attr("checked", "checked");
            }
        }


        $("#LowVelocityLICAProximalCheckbox").attr("checked", testResult.LowVelocityLica != null ? true : false);
        $("#LowVelocityRICAProximalCheckbox").attr("checked", testResult.LowVelocityRica != null ? true : false);

        setboolTypeReading($('#velocityelevatedright'), testResult.VelocityElevatedOnRight);
        setboolTypeReading($('#velocityelevatedleft'), testResult.VelocityElevatedOnLeft);
        setboolTypeReading($('#technicallyltdbutreadableAwvCarotidinputcheck'), testResult.TechnicallyLimitedbutReadable);
        setboolTypeReading($('#repeatstudyAwvCarotidinputcheck'), testResult.RepeatStudy);

        $("#chkselfAwvCarotid").attr("checked", testResult.ResultStatus.SelfPresent);
        setUnableScreenReason($('.dtl-unabletoscreen-AwvCarotid'), testResult.UnableScreenReason);

        setTestNotPerformedReasonForAwvCarotid(testResult.TestNotPerformed);

        if (testResult.ResultImages && testResult.ResultImages.length > 0) {
            LoadNewImagesAwvCarotid(testResult.ResultImages, true);
        }

        $("#technotesAwvCarotid").val(testResult.TechnicianNotes);
        $("#conductedbyAwvCarotid option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);

        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksAwvCarotid").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpAwvCarotid").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalAwvCarotid").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }
    },
    getData: function () {
        var testResult = this.Result;
        if (IsawvCarotidResultEntryExternaly == 'True') {
            testResult.TestPerformedExternally = getTestPerformedExternally("chk_awvCarotidcapturebyChat", testResult.TestPerformedExternally)
        }

        if (testResult.LeftResultReadings == null) {
            testResult.LeftResultReadings = { "ICAPSV": null, "ICAEDV": null, "Finding": null };
        }
        testResult.LeftResultReadings.Finding = getFindingDataandSynchronized(testResult.LeftResultReadings.Finding, getSelectedFinding($(".gv-Findings-AwvCarotid"), "rbt-finding-AwvCarotid-left"));

        testResult.TestNotPerformed = getTestNotPerformedReasonForAwvCarotid(testResult.TestNotPerformed);

        if (testResult.RightResultReadings == null) {
            testResult.RightResultReadings = { "ICAPSV": null, "ICAEDV": null, "Finding": null };
        }
        testResult.RightResultReadings.Finding = getFindingDataandSynchronized(testResult.RightResultReadings.Finding, getSelectedFinding($(".gv-Findings-AwvCarotid"), "rbt-finding-AwvCarotid-right"));

        if (testResult.LowVelocityLica == null && $("#LowVelocityLICAProximalCheckbox").attr("checked")) {
            testResult.LowVelocityLica = { "Id": $("#LowVelocityLICAProximalCheckbox").parent().find("input[type=hidden]").val() };
        }
        else if (testResult.LowVelocityLica != null && !$("#LowVelocityLICAProximalCheckbox").attr("checked")) {
            testResult.LowVelocityLica = null;
        }

        if (testResult.LowVelocityRica == null && $("#LowVelocityRICAProximalCheckbox").attr("checked")) {
            testResult.LowVelocityRica = { "Id": $("#LowVelocityRICAProximalCheckbox").parent().find("input[type=hidden]").val() };
        }
        else if (testResult.LowVelocityRica != null && !$("#LowVelocityRICAProximalCheckbox").attr("checked")) {
            testResult.LowVelocityRica = null;
        }

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-AwvCarotid')));

        //Left Result Readings
        testResult.LeftResultReadings.CCAProximalPSV = getReading($("#LCCAProximalPSVInputText"), testResult.LeftResultReadings.CCAProximalPSV);
        testResult.LeftResultReadings.CCAProximalEDV = getReading($("#LCCAProximalEDVInputText"), testResult.LeftResultReadings.CCAProximalEDV);

        testResult.LeftResultReadings.CCADistalPSV = getReading($("#LCCADistalPSVInputText"), testResult.LeftResultReadings.CCADistalPSV);
        testResult.LeftResultReadings.CCADistalEDV = getReading($("#LCCADistalEDVInputText"), testResult.LeftResultReadings.CCADistalEDV);

        testResult.LeftResultReadings.BulbPSV = getReading($("#LBulbPSVInputText"), testResult.LeftResultReadings.BulbPSV);
        testResult.LeftResultReadings.BulbEDV = getReading($("#LBulbEDVInputText"), testResult.LeftResultReadings.BulbEDV);

        testResult.LeftResultReadings.ExtCarotidArtPSV = getReading($("#LExtCarotidArtPSVInputText"), testResult.LeftResultReadings.ExtCarotidArtPSV);

        testResult.LeftResultReadings.ICAProximalPSV = getReading($("#LICAProximalPSVInputText"), testResult.LeftResultReadings.ICAProximalPSV);
        testResult.LeftResultReadings.ICAProximalEDV = getReading($("#LICAProximalEDVInputText"), testResult.LeftResultReadings.ICAProximalEDV);

        testResult.LeftResultReadings.ICADistalPSV = getReading($("#LICADistalPSVInputText"), testResult.LeftResultReadings.ICADistalPSV);
        testResult.LeftResultReadings.ICADistalEDV = getReading($("#LICADistalEDVInputText"), testResult.LeftResultReadings.ICADistalEDV);

        testResult.LeftResultReadings.VertebralArtPSV = getReading($("#LVertebralArtPSVInputText"), testResult.LeftResultReadings.VertebralArtPSV);
        testResult.LeftResultReadings.VertebralArtEDV = getReading($("#LVertebralArtEDVInputText"), testResult.LeftResultReadings.VertebralArtEDV);

        /****************************************************Right Result Readings*********************************************************************/
        testResult.RightResultReadings.CCAProximalPSV = getReading($("#RCCAProximalPSVInputText"), testResult.RightResultReadings.CCAProximalPSV);
        testResult.RightResultReadings.CCAProximalEDV = getReading($("#RCCAProximalEDVInputText"), testResult.RightResultReadings.CCAProximalEDV);

        testResult.RightResultReadings.CCADistalPSV = getReading($("#RCCADistalPSVInputText"), testResult.RightResultReadings.CCADistalPSV);
        testResult.RightResultReadings.CCADistalEDV = getReading($("#RCCADistalEDVInputText"), testResult.RightResultReadings.CCADistalEDV);

        testResult.RightResultReadings.BulbPSV = getReading($("#RBulbPSVInputText"), testResult.RightResultReadings.BulbPSV);
        testResult.RightResultReadings.BulbEDV = getReading($("#RBulbEDVInputText"), testResult.RightResultReadings.BulbEDV);

        testResult.RightResultReadings.ExtCarotidArtPSV = getReading($("#RExtCarotidArtPSVInputText"), testResult.RightResultReadings.ExtCarotidArtPSV);

        testResult.RightResultReadings.ICAProximalPSV = getReading($("#RICAProximalPSVInputText"), testResult.RightResultReadings.ICAProximalPSV);
        testResult.RightResultReadings.ICAProximalEDV = getReading($("#RICAProximalEDVInputText"), testResult.RightResultReadings.ICAProximalEDV);

        testResult.RightResultReadings.ICADistalPSV = getReading($("#RICADistalPSVInputText"), testResult.RightResultReadings.ICADistalPSV);
        testResult.RightResultReadings.ICADistalEDV = getReading($("#RICADistalEDVInputText"), testResult.RightResultReadings.ICADistalEDV);

        testResult.RightResultReadings.VertebralArtPSV = getReading($("#RVertebralArtPSVInputText"), testResult.RightResultReadings.VertebralArtPSV);
        testResult.RightResultReadings.VertebralArtEDV = getReading($("#RVertebralArtEDVInputText"), testResult.RightResultReadings.VertebralArtEDV);

        if (currentScreenMode != ScreenMode.Physician) {
            var resultMedia = new Array();
            if (awvCarotidResultMedia != null) {
                $.each(awvCarotidResultMedia, function () { resultMedia.push(this); });
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
            testResult.TechnicianNotes = $.trim($("#technotesAwvCarotid").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ConductedByOrgRoleUserId = $("#conductedbyAwvCarotid option:selected").val();
            testResult.ResultStatus.SelfPresent = $("#chkselfAwvCarotid").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestAwvCarotidCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_56").attr("checked");

        if (currentScreenMode != ScreenMode.Entry) {
            testResult.VelocityElevatedOnRight = getboolTypeReading($('#velocityelevatedright'), testResult.VelocityElevatedOnRight);
            testResult.VelocityElevatedOnLeft = getboolTypeReading($('#velocityelevatedleft'), testResult.VelocityElevatedOnLeft);
            testResult.TechnicallyLimitedbutReadable = getboolTypeReading($('#technicallyltdbutreadableAwvCarotidinputcheck'), testResult.TechnicallyLimitedbutReadable);
            testResult.RepeatStudy = getboolTypeReading($('#repeatstudyAwvCarotidinputcheck'), testResult.RepeatStudy);

            if (testResult.PhysicianInterpretation == null) {
                testResult.PhysicianInterpretation = {
                    'Remarks': $("#physicianRemarksAwvCarotid").val(), 'IsCritical': $("#criticalAwvCarotid").attr("checked"), 'FollowUp': $("#followUpAwvCarotid").attr("checked"), 'RecorderMetaData': {
                        'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate
                    }
                };
            }
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksAwvCarotid").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpAwvCarotid").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalAwvCarotid").attr("checked");
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
                    && testResult.ConductedByOrgRoleUserId == "0" && awvCarotidImageCount == 0 && $("#chkselfAwvCarotid").attr("checked") == false)
                return null;
        }

        return testResult;
    }
};

var awvCarotidImageCount = 0;
var awvCarotidResultMedia = null;

function getAwvCarotidMedia() {
    return awvCarotidResultMedia;
}

function LoadNewImagesAwvCarotid(jsonMedia, correctJson) {
    awvCarotidResultMedia = jsonMedia;
    awvCarotidImageCount = 0;
    $("#AwvCarotidImageListDiv").empty();
    if (jsonMedia == null || jsonMedia.length < 1) return;
    awvCarotidImageCount = jsonMedia.length;
    LoadNewMedia(jsonMedia, correctJson, $("#AwvCarotidImageListDiv"));
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

var criticalDataModel_AwvCarotid = null;
function onClick_CriticalDataAwvCarotid() {
    if ($("#chkselfAwvCarotid").attr("checked")) {
        loadCriticalLink($("#AwvCarotid-critical-span"), "onClick_CriticalDataAwvCarotid();", testTypeAwvCarotid);
        openCriticalDataDialog(testTypeAwvCarotid, $("#conductedbyAwvCarotid"), $("#chkselfAwvCarotid"), setCriticalDataModel_AwvCarotid);
    }
    else {
        unloadCriticalLink($("#AwvCarotid-critical-span"), testTypeAwvCarotid);
    }
}

function setCriticalDataModel_AwvCarotid(model, printAfterSave) {
    if (model != null) {
        var testResult = GetAwvCarotidData();
        saveSingleTestResult(testResult, model, $("#AwvCarotid-critical-span"), "onClick_CriticalDataAwvCarotid();", SetAwvCarotidData, printAfterSave);
    }
}

function getCriticalDataModel_AwvCarotid() {
    if ($("#chkselfAwvCarotid").attr("checked") && criticalDataModel_AwvCarotid != null) {
        criticalDataModel_AwvCarotid.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_AwvCarotid;
    }
    return null;
}
function onClick_PriorityInQueueDataAwvCarotid() {
    if ($("#PriorityInQueueTestAwvCarotidCheck").attr("checked")) {
        loadPriorityInQueueLink($("#awvCarotid-priorityInQueue-span"), "onClick_PriorityInQueueDataAwvCarotid();", testTypeAwvCarotid);
        openPriorityInQueueTestDialog(testTypeAwvCarotid, $("#conductedbyAwvCarotid"), $("#PriorityInQueueTestAwvCarotidCheck"), setPriorityInQueueDataModel_AwvCarotid);
    }
    else {
        unloadPriorityInQueueLink($("#awvCarotid-priorityInQueue-span"), testTypeAwvCarotid);
    }
}

function setPriorityInQueueDataModel_AwvCarotid(model) {
    if (model != null) {
        var testResult = GetAwvCarotidData();
        model.TestId = testTypeAwvCarotid;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#awvCarotid-priorityInQueue-span"), "onClick_PriorityInQueueDataAwvCarotid();", SetAwvCarotidData);
    }
}
function clearAllAwvCarotidSelection() {
    $(".gv-Findings-AwvCarotid input[type=radio], #LowVelocityRICAProximalCheckbox, #LowVelocityLICAProximalCheckbox").attr("checked", false);
}


function setTestNotPerformedReasonForAwvCarotid(testNotPerformed) {
    setTestNotPerformed("testnotPerformedAwvCarotid", testNotPerformed);
    SetTestNotPerformedEnableDisabled("testnotPerformedAwvCarotid");
}

function getTestNotPerformedReasonForAwvCarotid(testNotPerformed) {
    return getTestNotPerformed("testnotPerformedAwvCarotid", testNotPerformed);
}