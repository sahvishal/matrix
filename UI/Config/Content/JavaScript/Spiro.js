function Spiro(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = {
            "Id": 0, "TestType": testTypeSpiro,
            "Finding": null,
            "UnableScreenReason": null,
            "TestPerformedExternally": null,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": "0",
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": {
                "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentSpiroInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestSpiroCheck").attr("checked")
            }
        };
    }
    this.Result = testResult;
}

Spiro.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (IsspiroResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_spirocapturebyChat", testResult.TestPerformedExternally)
        }
        if (testResult.Finding != null) {
            setSelectedFinding($(".gv-findings-spiro"), testResult.Finding.Id);
        }
        
        setboolTypeReading($('#technicallyltdbutreadablespiroinputcheck'), testResult.TechnicallyLimitedbutReadable);
        setboolTypeReading($('#repeatstudyspiroinputcheck'), testResult.RepeatStudy);
        
        setboolTypeReading($('#PoorEffortSpiro'), testResult.PoorEffort);
        setboolTypeReading($('#RestrictiveSpiro'), testResult.Restrictive);
        setboolTypeReading($('#ObstructiveSpiro'), testResult.Obstructive);

        setUnableScreenReason($('.dtl-unabletoscreen-spiro'), testResult.UnableScreenReason);

        setTestNotPerformedReasonForSpiro(testResult.TestNotPerformed);

        if (testResult.ResultImage != null) {
            var newImageArray = new Array();
            newImageArray.push(testResult.ResultImage);
            LoadNewImagesSpiro(newImageArray, true);
        }

        $("#DescribeSelfPresentSpiroInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);
        $("#conductedbyspiro option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);
        $("#PriorityInQueueTestSpiroCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#spiro-priorityInQueue-span"), "onClick_PriorityInQueueDataSpiro();", testTypeSpiro);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#spiro-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#spiro-critical-span"), "onClick_CriticalDataSpiro();", testTypeSpiro);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#spiro-critical-span").parent().addClass("red-band");
                $("#criticalSpiro").attr("checked", "checked");
            }
        }

        $("#technotesspiro").val(testResult.TechnicianNotes);


        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksSpiro").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpSpiro").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalSpiro").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }
    },
    getData: function () {
        var testResult = this.Result;
        if (IsspiroResultEntryExternaly == 'True') {
            testResult.TestPerformedExternally = getTestPerformedExternally("chk_spirocapturebyChat", testResult.TestPerformedExternally);
        }

        var testFindings = getSelectedFinding($(".gv-findings-spiro"));
        testResult.Finding = getFindingDataandSynchronized(testResult.Finding, testFindings);
        
        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-spiro')));
        
        testResult.TestNotPerformed = getTestNotPerformedReasonForSpiro(testResult.TestNotPerformed);

        testResult.PoorEffort = getboolTypeReading($('#PoorEffortSpiro'), testResult.PoorEffort);
        testResult.Restrictive = getboolTypeReading($('#RestrictiveSpiro'), testResult.Restrictive);
        testResult.Obstructive = getboolTypeReading($('#ObstructiveSpiro'), testResult.Obstructive);

        if (currentScreenMode != ScreenMode.Physician) {
            
            if (spiroResultMedia != null && spiroResultMedia.length > 0) {
                if (testResult.ResultImage == null)
                    testResult.ResultImage = spiroResultMedia[0];
                else {
                    var resultMedia = spiroResultMedia[0];
                    resultMedia.Id = testResult.ResultImage.Id;
                    resultMedia.File.Id = testResult.ResultImage.File.Id;
                    resultMedia.Thumbnail.Id = testResult.ResultImage.Thumbnail.Id;
                    testResult.ResultImage = resultMedia;
                }
            }
            else
                testResult.ResultImage = null;
            
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
            testResult.ConductedByOrgRoleUserId = $("#conductedbyspiro option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesspiro").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentSpiroInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestSpiroCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_36").attr("checked");

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }

        
        if (currentScreenMode != ScreenMode.Entry) {
            testResult.TechnicallyLimitedbutReadable = getboolTypeReading($('#technicallyltdbutreadablespiroinputcheck'), testResult.TechnicallyLimitedbutReadable);
            testResult.RepeatStudy = getboolTypeReading($('#repeatstudyspiroinputcheck'), testResult.RepeatStudy);
            
            if (testResult.PhysicianInterpretation == null)
                testResult.PhysicianInterpretation = {
                    'Remarks': $("#physicianRemarksSpiro").val(), 'IsCritical': $("#criticalSpiro").attr("checked"), 'FollowUp': $("#followUpSpiro").attr("checked"), 'RecorderMetaData': {
                        'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate
                    }
                };
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksSpiro").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpSpiro").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalSpiro").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }


        if (testResult.ResultStatus.StateNumber < 4) {
            // To Check if no entry has been done
            if (testResult.Fev1 == null && testResult.UnableScreenReason == null && testResult.TechnicianNotes.length < 1
                && testResult.ConductedByOrgRoleUserId == "0" && $("#chkselfSpiro").attr("checked") == false) return null;
        }

        return testResult;
    }
}

var SpiroImageCount = 0;
var spiroResultMedia = null;
function LoadNewImagesSpiro(jsonMedia, correctJson) {
    spiroResultMedia = jsonMedia;
    SpiroImageCount = 0;
    $("#SpiroImagesContainerDiv").empty();
    if (jsonMedia == null || jsonMedia.length < 1) return;
    SpiroImageCount = jsonMedia.length;
    LoadNewMedia(jsonMedia, correctJson, $("#SpiroImagesContainerDiv"));
}

function getSpiroMedia() {
    return spiroResultMedia;
}

$(document).ready(function () {
    
});

var criticalDataModel_Spiro = null;
function onClick_CriticalDataSpiro() {
    if ($("#DescribeSelfPresentSpiroInputCheck").attr("checked")) {
        loadCriticalLink($("#spiro-critical-span"), "onClick_CriticalDataSpiro();", testTypeSpiro);
        openCriticalDataDialog(testTypeSpiro, $("#conductedbyspiro"), $("#DescribeSelfPresentSpiroInputCheck"), setCriticalDataModel_Spiro);
    }
    else {
        unloadCriticalLink($("#spiro-critical-span"), testTypeSpiro);
    }
}

function setCriticalDataModel_Spiro(model, printAfterSave) {
    if (model != null) {
        var testResult = GetSpiroData();
        saveSingleTestResult(testResult, model, $("#spiro-critical-span"), "onClick_CriticalDataSpiro();", SetSpiroData, printAfterSave);
    }
}

function getCriticalDataModel_Spiro() {
    if ($("#DescribeSelfPresentSpiroInputCheck").attr("checked") && criticalDataModel_Spiro != null) {
        criticalDataModel_Spiro.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_Spiro;
    }
    return null;
}
function onClick_PriorityInQueueDataSpiro() {
    if ($("#PriorityInQueueTestSpiroCheck").attr("checked")) {
        loadPriorityInQueueLink($("#spiro-priorityInQueue-span"), "onClick_PriorityInQueueDataSpiro();", testTypeSpiro);
        openPriorityInQueueTestDialog(testTypeSpiro, $("#conductedbyspiro"), $("#PriorityInQueueTestSpiroCheck"), setPriorityInQueueDataModel_Spiro);
    }
    else {
        unloadPriorityInQueueLink($("#spiro-priorityInQueue-span"), testTypeSpiro);
    }
}

function setPriorityInQueueDataModel_Spiro(model) {
    if (model != null) {
        var testResult = GetSpiroData();
        model.TestId = testTypeSpiro;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#spiro-priorityInQueue-span"), "onClick_PriorityInQueueDataSpiro();", SetSpiroData);
    }
}

function clearAllSpiroSelection() {
    $(".gv-findings-spiro input[type=radio], #PoorEffortSpiro, #RestrictiveSpiro, #ObstructiveSpiro").attr("checked", false);
}

function setTestNotPerformedReasonForSpiro(testNotPerformed) {
    setTestNotPerformed("testnotPerformedSpiro", testNotPerformed);
    SetTestNotPerformedEnableDisabled("testnotPerformedSpiro");
}

function getTestNotPerformedReasonForSpiro(testNotPerformed) {
    return getTestNotPerformed("testnotPerformedSpiro", testNotPerformed);
}