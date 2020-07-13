
function AwvFluShot(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = {
            "Id": 0, "TestType": testTypeAwvFluShot,
            "Finding": null,
            "UnableScreenReason": null,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": "0",
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": {
                "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentAwvFluShotInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestAwvFluShotCheck").attr("checked")
            },
            "TestPerformedExternally": null
        };
    }
    this.Result = testResult;
}

AwvFluShot.prototype = {
    setData: function () {
        var testResult = this.Result;

        if (isAwvFluShotResultEntryType == 'True') {
            setTestPerformedExternally("chk_AwvFluShotcapturebyChat", testResult.TestPerformedExternally)
        }

        setboolTypeReading($('#technicallyltdbutreadableAwvFluShotinputcheck'), testResult.TechnicallyLimitedbutReadable);
        setboolTypeReading($('#repeatstudyAwvFluShotinputcheck'), testResult.RepeatStudy);

        setUnableScreenReason($('.dtl-unabletoscreen-AwvFluShot'), testResult.UnableScreenReason);

        setTestNotPerformedReasonForAwvFluShot(testResult.TestNotPerformed);


        $("#DescribeSelfPresentAwvFluShotInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);
        $("#conductedbyAwvFluShot option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);
        $("#PriorityInQueueTestAwvFluShotCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        $("#AwvFluShotManufacturerInputtext").val(testResult.Manufacturer != null ? testResult.Manufacturer.Reading : "");
        $("#AwvFluShotLotNumberInputtext").val(testResult.LotNumber != null ? testResult.LotNumber.Reading : "");

        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#AwvFluShot-priorityInQueue-span"), "onClick_PriorityInQueueDataAwvFluShot();", testTypeAwvFluShot);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#AwvFluShot-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#AwvFluShot-critical-span"), "onClick_CriticalDataAwvFluShot();", testTypeAwvFluShot);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#AwvFluShot-critical-span").parent().addClass("red-band");
                $("#criticalAwvFluShot").attr("checked", "checked");
            }
        }

        $("#technotesAwvFluShot").val(testResult.TechnicianNotes);


        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksAwvFluShot").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpAwvFluShot").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalAwvFluShot").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }
    },
    getData: function () {
        var testResult = this.Result;

        if (isAwvFluShotResultEntryType == 'True') {
            testResult.TestPerformedExternally = getTestPerformedExternally("chk_AwvFluShotcapturebyChat", testResult.TestPerformedExternally)
        }

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-AwvFluShot')));

        testResult.TestNotPerformed = getTestNotPerformedReasonForAwvFluShot(testResult.TestNotPerformed);
        
        testResult.Manufacturer = getReading($("#AwvFluShotManufacturerInputtext"), testResult.Manufacturer);
        testResult.LotNumber = getReading($("#AwvFluShotLotNumberInputtext"), testResult.LotNumber);
        
        if (currentScreenMode != ScreenMode.Physician) {

            if (currentScreenMode != ScreenMode.CorrectionPostEvaluation && currentScreenMode != ScreenMode.PostAudit) testResult.ResultStatus.StateNumber = $("#ResultStatusInputHidden").val();

            if (testResult.ResultStatus.Id > 0) {
                testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.ResultStatus.DataRecorderMetaData.DateModified = currentDate;
            } else {
                testResult.ResultStatus.DataRecorderMetaData = { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate };
            }
        }

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.ConductedByOrgRoleUserId = $("#conductedbyAwvFluShot option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesAwvFluShot").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentAwvFluShotInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestAwvFluShotCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_83").attr("checked");

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }


        if (currentScreenMode != ScreenMode.Entry) {
            testResult.TechnicallyLimitedbutReadable = getboolTypeReading($('#technicallyltdbutreadableAwvFluShotinputcheck'), testResult.TechnicallyLimitedbutReadable);
            testResult.RepeatStudy = getboolTypeReading($('#repeatstudyAwvFluShotinputcheck'), testResult.RepeatStudy);

            if (testResult.PhysicianInterpretation == null)
                testResult.PhysicianInterpretation = {
                    'Remarks': $("#physicianRemarksAwvFluShot").val(),
                    'IsCritical': $("#criticalAwvFluShot").attr("checked"),
                    'FollowUp': $("#followUpAwvFluShot").attr("checked"),
                    'RecorderMetaData': {
                        'DataRecorderCreator': { 'Id': currentUser },
                        'DateCreated': currentDate
                    }
                };
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksAwvFluShot").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpAwvFluShot").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalAwvFluShot").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }


        if (testResult.ResultStatus.StateNumber < 4) {
            // To Check if no entry has been done
            if (testResult.Fev1 == null && testResult.UnableScreenReason == null && testResult.TechnicianNotes.length < 1
                && testResult.ConductedByOrgRoleUserId == "0" && $("#DescribeSelfPresentAwvFluShotInputCheck").attr("checked") == false) testResult = null;
        }

        return testResult;
    }
};

var criticalDataModel_AwvFluShot = null;
function onClick_CriticalDataAwvFluShot() {
    if ($("#DescribeSelfPresentAwvFluShotInputCheck").attr("checked")) {
        loadCriticalLink($("#AwvFluShot-critical-span"), "onClick_CriticalDataAwvFluShot();", testTypeAwvFluShot);
        openCriticalDataDialog(testTypeAwvFluShot, $("#conductedbyAwvFluShot"), $("#DescribeSelfPresentAwvFluShotInputCheck"), setCriticalDataModel_AwvFluShot);
    }
    else {
        unloadCriticalLink($("#AwvFluShot-critical-span"), testTypeAwvFluShot);
    }
}

function setCriticalDataModel_AwvFluShot(model, printAfterSave) {
    if (model != null) {
        var testResult = GetAwvFluShotData();
        saveSingleTestResult(testResult, model, $("#AwvFluShot-critical-span"), "onClick_CriticalDataAwvFluShot();", SetAwvFluShotData, printAfterSave);
    }
}

function getCriticalDataModel_AwvFluShot() {
    if ($("#DescribeSelfPresentAwvFluShotInputCheck").attr("checked") && criticalDataModel_AwvFluShot != null) {
        criticalDataModel_AwvFluShot.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_AwvFluShot;
    }
    return null;
}
function onClick_PriorityInQueueDataAwvFluShot() {
    if ($("#PriorityInQueueTestAwvFluShotCheck").attr("checked")) {
        loadPriorityInQueueLink($("#AwvFluShot-priorityInQueue-span"), "onClick_PriorityInQueueDataAwvFluShot();", testTypeAwvFluShot);
        openPriorityInQueueTestDialog(testTypeAwvFluShot, $("#conductedbyAwvFluShot"), $("#PriorityInQueueTestAwvFluShotCheck"), setPriorityInQueueDataModel_AwvFluShot);
    }
    else {
        unloadPriorityInQueueLink($("#AwvFluShot-priorityInQueue-span"), testTypeAwvFluShot);
    }
}

function setPriorityInQueueDataModel_AwvFluShot(model) {
    if (model != null) {
        var testResult = GetAwvFluShotData();
        model.TestId = testTypeAwvFluShot;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#AwvFluShot-priorityInQueue-span"), "onClick_PriorityInQueueDataAwvFluShot();", SetAwvFluShotData);
    }
}
function clearAllAwvFluShotSelection() {
    $(".dtl-unabletoscreen-AwvFluShot input[type=checkbox]").attr("checked", false);
    $("#AwvFluShotManufacturerInputtext").val('');
    $("#AwvFluShotLotNumberInputtext").val('');
}

function setTestNotPerformedReasonForAwvFluShot(testNotPerformed) {
    setTestNotPerformed("testnotPerformedAwvFluShot", testNotPerformed);
    SetTestNotPerformedEnableDisabled("testnotPerformedAwvFluShot");
}

function getTestNotPerformedReasonForAwvFluShot(testNotPerformed) {
    return getTestNotPerformed("testnotPerformedAwvFluShot", testNotPerformed);
}
