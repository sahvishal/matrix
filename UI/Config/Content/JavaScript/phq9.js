function Phq9(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = {
            "Id": 0, "TestType": testTypePhq9,
            "Phq9SCR": null, "TechnicianNotes": '', "ConductedByOrgRoleUserId": '0',
            "UnableScreenReason": new Array(),
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": {
                "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentPhq9InputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestPhq9Check").attr("checked")
            },
            "TestPerformedExternally": null
        };
    }
    this.Result = testResult;
}

Phq9.prototype = {
    setData: function() {
        var testResult = this.Result;

        if (isPhq9Resultentrytype == 'True') {
            setTestPerformedExternally("chk_Phq9capturebyChat", testResult.TestPerformedExternally)
        }

        setReading($("#Phq9Scoretextbox"), testResult.Phq9Score);

        $("#DescribeSelfPresentPhq9InputCheck").attr("checked", testResult.ResultStatus.SelfPresent);

        $("#technotesPhq9").val(testResult.TechnicianNotes);
        $("#conductedbyPhq9 option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);

        setboolTypeReading($('#technicallyltdbutreadablePhq9inputcheck'), testResult.TechnicallyLimitedbutReadable);
        setboolTypeReading($('#repeatstudyPhq9inputcheck'), testResult.RepeatStudy);

        setUnableScreenReason($('.dtl-unabletoscreen-Phq9'), testResult.UnableScreenReason);
        
        setTestNotPerformedReasonForPhq9(testResult.TestNotPerformed);

        $("#PriorityInQueueTestPhq9Check").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#Phq9-priorityInQueue-span"), "onClick_PriorityInQueueDataPhq9();", testTypePhq9);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#Phq9-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#Phq9-critical-span"), "onClick_CriticalDataPhq9();", testTypePhq9);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#Phq9-critical-span").parent().addClass("red-band");
            }
        }

        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksPhq9").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpPhq9").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalPhq9").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }
    },
    getData: function() {
        var testResult = this.Result;

        if (isPhq9Resultentrytype == 'True') {
            testResult.TestPerformedExternally = getTestPerformedExternally("chk_Phq9capturebyChat", testResult.TestPerformedExternally)
        }

        testResult.Phq9Score = getReading($("#Phq9Scoretextbox"), testResult.Phq9Score);
        
        if (currentScreenMode != ScreenMode.Physician) {
            //testResult.Phq9Score = getReading($("#Phq9Scoretextbox"), testResult.Phq9Score);
            if (currentScreenMode != ScreenMode.CorrectionPostEvaluation && currentScreenMode != ScreenMode.PostAudit) testResult.ResultStatus.StateNumber = $("#ResultStatusInputHidden").val();

            if (testResult.ResultStatus.Id > 0) {
                testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.ResultStatus.DataRecorderMetaData.DateModified = currentDate;
            } else {
                testResult.ResultStatus.DataRecorderMetaData = { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate };
            }
        }

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-Phq9')));

        testResult.TestNotPerformed = getTestNotPerformedReasonForPhq9(testResult.TestNotPerformed);

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.ConductedByOrgRoleUserId = $("#conductedbyPhq9 option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesPhq9").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentPhq9InputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestPhq9Check").attr("checked");
        }

        testResult.IsRetest = $("#Retest_43").attr("checked");

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }

        if (currentScreenMode != ScreenMode.Entry) {

            testResult.RepeatStudy = getboolTypeReading($('#repeatstudyPhq9inputcheck'), testResult.RepeatStudy);
            testResult.TechnicallyLimitedbutReadable = getboolTypeReading($('#technicallyltdbutreadablePhq9inputcheck'), testResult.TechnicallyLimitedbutReadable);

            if (testResult.PhysicianInterpretation == null)
                testResult.PhysicianInterpretation = {
                    'Remarks': $("#physicianRemarksPhq9").val(),
                    'IsCritical': $("#criticalPhq9").attr("checked"),
                    'FollowUp': $("#followUpPhq9").attr("checked"),
                    'RecorderMetaData': {
                        'DataRecorderCreator': { 'Id': currentUser },
                        'DateCreated': currentDate
                    }
                };
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksPhq9").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpPhq9").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalPhq9").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }
        if (testResult.ResultStatus.StateNumber < 4) {
            if (testResult.Phq9SCR == null && testResult.TechnicianNotes.length < 1 && testResult.ConductedByOrgRoleUserId == "0" && testResult.UnableScreenReason == null && $("#DescribeSelfPresentPhq9InputCheck").attr("checked") == false)
                return null;
        }

        return testResult;
    }
};


var criticalDataModel_Phq9 = null;
function onClick_CriticalDataPhq9() {
    if ($("#DescribeSelfPresentPhq9InputCheck").attr("checked")) {
        loadCriticalLink($("#Phq9-critical-span"), "onClick_CriticalDataPhq9();", testTypePhq9);
        openCriticalDataDialog(testTypePhq9, $("#conductedbyPhq9"), $("#DescribeSelfPresentPhq9InputCheck"), setCriticalDataModel_Phq9);
    }
    else {
        unloadCriticalLink($("#Phq9-critical-span"), testTypePhq9);
    }
}

function setCriticalDataModel_Phq9(model, printAfterSave) {
    if (model != null) {
        var testResult = GetPhq9Data();
        saveSingleTestResult(testResult, model, $("#Phq9-critical-span"), "onClick_CriticalDataPhq9();", SetPhq9Data, printAfterSave);
    }
}

function getCriticalDataModel_Phq9() {
    if ($("#DescribeSelfPresentPhq9InputCheck").attr("checked") && criticalDataModel_Phq9 != null) {
        criticalDataModel_Phq9.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_Phq9;
    }
    return null;
}

// Phq9-critical-span

function onClick_PriorityInQueueDataPhq9() {
    if ($("#PriorityInQueueTestPhq9Check").attr("checked")) {
        loadPriorityInQueueLink($("#Phq9-priorityInQueue-span"), "onClick_PriorityInQueueDataPhq9();", testTypePhq9);
        openPriorityInQueueTestDialog(testTypePhq9, $("#conductedbyPhq9"), $("#PriorityInQueueTestPhq9Check"), setPriorityInQueueDataModel_Phq9);
    }
    else {
        unloadPriorityInQueueLink($("#Phq9-priorityInQueue-span"), testTypePhq9);
    }
}

function setPriorityInQueueDataModel_Phq9(model) {
    if (model != null) {
        var testResult = GetPhq9Data();
        model.TestId = testTypePhq9;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#Phq9-priorityInQueue-span"), "onClick_PriorityInQueueDataPhq9();", SetPhq9Data);
    }
}


function setTestNotPerformedReasonForPhq9(testNotPerformed) {
    setTestNotPerformed("testnotPerformedPhq9", testNotPerformed);
    SetTestNotPerformedEnableDisabled("testnotPerformedPhq9");
}

function getTestNotPerformedReasonForPhq9(testNotPerformed) {
    return getTestNotPerformed("testnotPerformedPhq9", testNotPerformed);
}