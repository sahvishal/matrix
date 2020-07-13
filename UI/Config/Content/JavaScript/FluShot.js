
function FluShot(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = {
            "Id": 0, "TestType": testTypeFluShot,
            "Finding": null,
            "UnableScreenReason": null,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": "0",
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": {
                "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentFluShotInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestFluShotCheck").attr("checked")
            },
            "TestPerformedExternally": null
        };
    }
    this.Result = testResult;
}

FluShot.prototype = {
    setData: function() {
        var testResult = this.Result;

        if (isFluShotResultentrytype == 'True') {
            setTestPerformedExternally("chk_flushotcapturebyChat", testResult.TestPerformedExternally)
        }

        setboolTypeReading($('#technicallyltdbutreadableFluShotinputcheck'), testResult.TechnicallyLimitedbutReadable);
        setboolTypeReading($('#repeatstudyFluShotinputcheck'), testResult.RepeatStudy);

        setUnableScreenReason($('.dtl-unabletoscreen-FluShot'), testResult.UnableScreenReason);

        setTestNotPerformedReasonForFluShot(testResult.TestNotPerformed);


        $("#DescribeSelfPresentFluShotInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);
        $("#conductedbyFluShot option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);
        $("#PriorityInQueueTestFluShotCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        $("#FluShotManufacturerInputtext").val(testResult.Manufacturer != null ? testResult.Manufacturer.Reading : "");
        $("#FluShotLotNumberInputtext").val(testResult.LotNumber != null ? testResult.LotNumber.Reading : "");

        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#FluShot-priorityInQueue-span"), "onClick_PriorityInQueueDataFluShot();", testTypeFluShot);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#FluShot-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#FluShot-critical-span"), "onClick_CriticalDataFluShot();", testTypeFluShot);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#FluShot-critical-span").parent().addClass("red-band");
                $("#criticalFluShot").attr("checked", "checked");
            }
        }

        $("#technotesFluShot").val(testResult.TechnicianNotes);


        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksFluShot").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpFluShot").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalFluShot").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }
    },
    getData: function() {
        var testResult = this.Result;
        if (isFluShotResultentrytype == 'True') {
            testResult.TestPerformedExternally = getTestPerformedExternally("chk_flushotcapturebyChat", testResult.TestPerformedExternally)
        }
        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-FluShot')));

        testResult.TestNotPerformed = getTestNotPerformedReasonForFluShot(testResult.TestNotPerformed);

        if (currentScreenMode != ScreenMode.Physician) {

            if (currentScreenMode != ScreenMode.CorrectionPostEvaluation && currentScreenMode != ScreenMode.PostAudit) testResult.ResultStatus.StateNumber = $("#ResultStatusInputHidden").val();

            if (testResult.ResultStatus.Id > 0) {
                testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.ResultStatus.DataRecorderMetaData.DateModified = currentDate;
            } else {
                testResult.ResultStatus.DataRecorderMetaData = { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate };
            }

            testResult.Manufacturer = getReading($("#FluShotManufacturerInputtext"), testResult.Manufacturer);
            testResult.LotNumber = getReading($("#FluShotLotNumberInputtext"), testResult.LotNumber);
        }

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.ConductedByOrgRoleUserId = $("#conductedbyFluShot option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesFluShot").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentFluShotInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestFluShotCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_31").attr("checked");

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }


        if (currentScreenMode != ScreenMode.Entry) {
            testResult.TechnicallyLimitedbutReadable = getboolTypeReading($('#technicallyltdbutreadableFluShotinputcheck'), testResult.TechnicallyLimitedbutReadable);
            testResult.RepeatStudy = getboolTypeReading($('#repeatstudyFluShotinputcheck'), testResult.RepeatStudy);

            if (testResult.PhysicianInterpretation == null)
                testResult.PhysicianInterpretation = {
                    'Remarks': $("#physicianRemarksFluShot").val(),
                    'IsCritical': $("#criticalFluShot").attr("checked"),
                    'FollowUp': $("#followUpFluShot").attr("checked"),
                    'RecorderMetaData': {
                        'DataRecorderCreator': { 'Id': currentUser },
                        'DateCreated': currentDate
                    }
                };
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksFluShot").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpFluShot").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalFluShot").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }


        if (testResult.ResultStatus.StateNumber < 4) {
            // To Check if no entry has been done
            if (testResult.Fev1 == null && testResult.UnableScreenReason == null && testResult.TechnicianNotes.length < 1
                && testResult.ConductedByOrgRoleUserId == "0" && $("#DescribeSelfPresentFluShotInputCheck").attr("checked") == false) return null;
        }

        return testResult;
    }
};

var criticalDataModel_FluShot = null;
function onClick_CriticalDataFluShot() {
    if ($("#DescribeSelfPresentFluShotInputCheck").attr("checked")) {
        loadCriticalLink($("#FluShot-critical-span"), "onClick_CriticalDataFluShot();", testTypeFluShot);
        openCriticalDataDialog(testTypeFluShot, $("#conductedbyFluShot"), $("#DescribeSelfPresentFluShotInputCheck"), setCriticalDataModel_FluShot);
    }
    else {
        unloadCriticalLink($("#FluShot-critical-span"), testTypeFluShot);
    }
}

function setCriticalDataModel_FluShot(model, printAfterSave) {
    if (model != null) {
        var testResult = GetFluShotData();
        saveSingleTestResult(testResult, model, $("#FluShot-critical-span"), "onClick_CriticalDataFluShot();", SetFluShotData, printAfterSave);
    }
}

function getCriticalDataModel_FluShot() {
    if ($("#DescribeSelfPresentFluShotInputCheck").attr("checked") && criticalDataModel_FluShot != null) {
        criticalDataModel_FluShot.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_FluShot;
    }
    return null;
}
function onClick_PriorityInQueueDataFluShot() {
    if ($("#PriorityInQueueTestFluShotCheck").attr("checked")) {
        loadPriorityInQueueLink($("#FluShot-priorityInQueue-span"), "onClick_PriorityInQueueDataFluShot();", testTypeFluShot);
        openPriorityInQueueTestDialog(testTypeFluShot, $("#conductedbyFluShot"), $("#PriorityInQueueTestFluShotCheck"), setPriorityInQueueDataModel_FluShot);
    }
    else {
        unloadPriorityInQueueLink($("#FluShot-priorityInQueue-span"), testTypeFluShot);
    }
}

function setPriorityInQueueDataModel_FluShot(model) {
    if (model != null) {
        var testResult = GetFluShotData();
        model.TestId = testTypeFluShot;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#FluShot-priorityInQueue-span"), "onClick_PriorityInQueueDataFluShot();", SetFluShotData);
    }
}
function clearAllFluShotSelection() {
    $(".dtl-unabletoscreen-FluShot input[type=checkbox]").attr("checked", false);
    $("#FluShotManufacturerInputtext").val('');
    $("#FluShotLotNumberInputtext").val('');
}

function setTestNotPerformedReasonForFluShot(testNotPerformed) {
    setTestNotPerformed("testnotPerformedFluShot", testNotPerformed);
    SetTestNotPerformedEnableDisabled("testnotPerformedFluShot");
}

function getTestNotPerformedReasonForFluShot(testNotPerformed) {
    return getTestNotPerformed("testnotPerformedFluShot", testNotPerformed);
}
