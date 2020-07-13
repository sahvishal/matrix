function AwvSpiro(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = {
            "Id": 0, "TestType": testTypeAwvSpiro,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": '0',
            "UnableScreenReason": new Array(),
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "TestPerformedExternally": null,
            "ResultStatus": {
                "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentAwvSpiroInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestAwvSpiroCheck").attr("checked")
            }
        };
    }
    this.Result = testResult;
}

AwvSpiro.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (IsawvSpiroResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_awvSpirocapturebyChat", testResult.TestPerformedExternally)
        }

        if (testResult.Finding != null) {
            setSelectedFinding($(".gv-findings-AwvSpiro"), testResult.Finding.Id);
        }

        setboolTypeReading($('#technicallyltdbutreadableAwvSpiroinputcheck'), testResult.TechnicallyLimitedbutReadable);
        setboolTypeReading($('#repeatstudyAwvSpiroinputcheck'), testResult.RepeatStudy);

        setboolTypeReading($('#PoorEffortAwvSpiro'), testResult.PoorEffort);
        setboolTypeReading($('#RestrictiveAwvSpiro'), testResult.Restrictive);
        setboolTypeReading($('#ObstructiveAwvSpiro'), testResult.Obstructive);

        setUnableScreenReason($('.dtl-unabletoscreen-AwvSpiro'), testResult.UnableScreenReason);
        
        setTestNotPerformedReasonForAwvSpiro(testResult.TestNotPerformed);
        
        if (testResult.ResultImage != null) {
            var newImageArray = new Array();
            newImageArray.push(testResult.ResultImage);
            LoadNewImagesAwvSpiro(newImageArray, true);
        }

        $("#DescribeSelfPresentAwvSpiroInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);
        $("#conductedbyAwvSpiro option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);
        $("#PriorityInQueueTestAwvSpiroCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#awvSpiro-priorityInQueue-span"), "onClick_PriorityInQueueDataAwvSpiro();", testTypeAwvSpiro);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#awvSpiro-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#AwvSpiro-critical-span"), "onClick_CriticalDataAwvSpiro();", testTypeAwvSpiro);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#AwvSpiro-critical-span").parent().addClass("red-band");
            }
        }

        $("#technotesAwvSpiro").val(testResult.TechnicianNotes);

        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksAwvSpiro").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpAwvSpiro").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalAwvSpiro").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }

    },
    getData: function () {
        var testResult = this.Result;
        if (IsawvSpiroResultEntryExternaly == 'True') {
            testResult.TestPerformedExternally = getTestPerformedExternally("chk_awvSpirocapturebyChat", testResult.TestPerformedExternally)
        }
        
        var testFindings = getSelectedFinding($(".gv-findings-AwvSpiro"));
        testResult.Finding = getFindingDataandSynchronized(testResult.Finding, testFindings);

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-AwvSpiro')));

        testResult.TestNotPerformed = getTestNotPerformedReasonForAwvSpiro(testResult.TestNotPerformed);

        testResult.PoorEffort = getboolTypeReading($('#PoorEffortAwvSpiro'), testResult.PoorEffort);
        testResult.Restrictive = getboolTypeReading($('#RestrictiveAwvSpiro'), testResult.Restrictive);
        testResult.Obstructive = getboolTypeReading($('#ObstructiveAwvSpiro'), testResult.Obstructive);

        if (currentScreenMode != ScreenMode.Physician) {

            if (AwvSpiroResultMedia != null && AwvSpiroResultMedia.length > 0) {
                if (testResult.ResultImage == null)
                    testResult.ResultImage = AwvSpiroResultMedia[0];
                else {
                    var resultMedia = AwvSpiroResultMedia[0];
                    resultMedia.Id = testResult.ResultImage.Id;
                    resultMedia.File.Id = testResult.ResultImage.File.Id;
                    resultMedia.Thumbnail.Id = testResult.ResultImage.Thumbnail.Id;
                    testResult.ResultImage = resultMedia;
                }
            }
            else
                testResult.ResultImage = null;

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
            testResult.ConductedByOrgRoleUserId = $("#conductedbyAwvSpiro option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesAwvSpiro").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentAwvSpiroInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestAwvSpiroCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_52").attr("checked");

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }

        if (currentScreenMode != ScreenMode.Entry) {
            testResult.TechnicallyLimitedbutReadable = getboolTypeReading($('#technicallyltdbutreadableAwvSpiroinputcheck'), testResult.TechnicallyLimitedbutReadable);
            testResult.RepeatStudy = getboolTypeReading($('#repeatstudyAwvSpiroinputcheck'), testResult.RepeatStudy);

            if (testResult.PhysicianInterpretation == null)
                testResult.PhysicianInterpretation = {
                    'Remarks': $("#physicianRemarksAwvSpiro").val(), 'IsCritical': $("#criticalAwvSpiro").attr("checked"), 'FollowUp': $("#followUpSpiro").attr("checked"), 'RecorderMetaData': {
                        'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate
                    }
                };
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksAwvSpiro").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpAwvSpiro").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalAwvSpiro").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }

        if (testResult.ResultStatus.StateNumber < 4) {
            if (testResult.Fev1 == null && testResult.UnableScreenReason == null && testResult.TechnicianNotes.length < 1 && testResult.ConductedByOrgRoleUserId == "0" && testResult.UnableScreenReason == null && $("#DescribeSelfPresentAwvSpiroInputCheck").attr("checked") == false)
                return null;
        }

        return testResult;
    }
}
var AwvSpiroImageCount = 0;
var AwvSpiroResultMedia = null;
function LoadNewImagesAwvSpiro(jsonMedia, correctJson) {
    AwvSpiroResultMedia = jsonMedia;
    AwvSpiroImageCount = 0;
    $("#AwvSpiroImagesContainerDiv").empty();
    if (jsonMedia == null || jsonMedia.length < 1) return;
    AwvSpiroImageCount = jsonMedia.length;
    LoadNewMedia(jsonMedia, correctJson, $("#AwvSpiroImagesContainerDiv"));
}

function getAwvSpiroMedia() {
    return AwvSpiroResultMedia;
}


var criticalDataModel_AwvSpiro = null;
function onClick_CriticalDataAwvSpiro() {
    if ($("#DescribeSelfPresentAwvSpiroInputCheck").attr("checked")) {
        loadCriticalLink($("#AwvSpiro-critical-span"), "onClick_CriticalDataAwvSpiro();", testTypeAwvSpiro);
        openCriticalDataDialog(testTypeAwvSpiro, $("#conductedbyAwvSpiro"), $("#DescribeSelfPresentAwvSpiroInputCheck"), setCriticalDataModel_AwvSpiro);
    }
    else {
        unloadCriticalLink($("#AwvSpiro-critical-span"), testTypeAwvSpiro);
    }
}

function setCriticalDataModel_AwvSpiro(model, printAfterSave) {
    if (model != null) {
        var testResult = GetAwvSpiroData();
        saveSingleTestResult(testResult, model, $("#AwvSpiro-critical-span"), "onClick_CriticalDataAwvSpiro();", SetAwvSpiroData, printAfterSave);
    }
}

function getCriticalDataModel_AwvSpiro() {
    if ($("#DescribeSelfPresentAwvSpiroInputCheck").attr("checked") && criticalDataModel_AwvSpiro != null) {
        criticalDataModel_AwvSpiro.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_AwvSpiro;
    }
    return null;
}

function onClick_PriorityInQueueDataAwvSpiro() {
    if ($("#PriorityInQueueTestAwvSpiroCheck").attr("checked")) {
        loadPriorityInQueueLink($("#awvSpiro-priorityInQueue-span"), "onClick_PriorityInQueueDataAwvSpiro();", testTypeAwvSpiro);
        openPriorityInQueueTestDialog(testTypeAwvSpiro, $("#conductedbyAwvSpiro"), $("#PriorityInQueueTestAwvSpiroCheck"), setPriorityInQueueDataModel_AwvSpiro);
    }
    else {
        unloadPriorityInQueueLink($("#awvSpiro-priorityInQueue-span"), testTypeAwvSpiro);
    }
}

function setPriorityInQueueDataModel_AwvSpiro(model) {
    if (model != null) {
        var testResult = GetAwvSpiroData();
        model.TestId = testTypeAwvSpiro;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#awvSpiro-priorityInQueue-span"), "onClick_PriorityInQueueDataAwvSpiro();", SetAwvSpiroData);
    }
}


function clearAllAwvSpiroSelection() {
    $(".gv-findings-AwvSpiro input[type=radio], #PoorEffortAwvSpiro, #RestrictiveAwvSpiro, #ObstructiveAwvSpiro").attr("checked", false);
}



function setTestNotPerformedReasonForAwvSpiro(testNotPerformed) {
    setTestNotPerformed("testnotPerformedAwvSpiro", testNotPerformed);
    SetTestNotPerformedEnableDisabled("testnotPerformedAwvSpiro");
}

function getTestNotPerformedReasonForAwvSpiro(testNotPerformed) {
    return getTestNotPerformed("testnotPerformedAwvSpiro", testNotPerformed);
}