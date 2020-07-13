
function Pneumococcal(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = {
            "Id": 0, "TestType": testTypePneumococcal,
            "Finding": null,
            "UnableScreenReason": null,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": "0",
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": {
                "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentPneumococcalInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestPneumococcalCheck").attr("checked")
            },
            "TestPerformedExternally": null
        };
    }
    this.Result = testResult;
}

Pneumococcal.prototype = {
    setData: function () {
        var testResult = this.Result;

        if (isPneumococcalResultEntryType == 'True') {
            setTestPerformedExternally("chk_PneumococcalcapturebyChat", testResult.TestPerformedExternally)
        }


        setboolTypeReading($('#technicallyltdbutreadablePneumococcalinputcheck'), testResult.TechnicallyLimitedbutReadable);
        setboolTypeReading($('#repeatstudyPneumococcalinputcheck'), testResult.RepeatStudy);

        setUnableScreenReason($('.dtl-unabletoscreen-Pneumococcal'), testResult.UnableScreenReason);

        setTestNotPerformedReasonForPneumococcal(testResult.TestNotPerformed);


        $("#DescribeSelfPresentPneumococcalInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);
        $("#conductedbyPneumococcal option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);
        $("#PriorityInQueueTestPneumococcalCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        $("#PneumococcalManufacturerInputtext").val(testResult.Manufacturer != null ? testResult.Manufacturer.Reading : "");
        $("#PneumococcalLotNumberInputtext").val(testResult.LotNumber != null ? testResult.LotNumber.Reading : "");

        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#Pneumococcal-priorityInQueue-span"), "onClick_PriorityInQueueDataPneumococcal();", testTypePneumococcal);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#Pneumococcal-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#Pneumococcal-critical-span"), "onClick_CriticalDataPneumococcal();", testTypePneumococcal);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#Pneumococcal-critical-span").parent().addClass("red-band");
                $("#criticalPneumococcal").attr("checked", "checked");
            }
        }

        $("#technotesPneumococcal").val(testResult.TechnicianNotes);


        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksPneumococcal").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpPneumococcal").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalPneumococcal").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }
    },
    getData: function () {
        var testResult = this.Result;
        if (isPneumococcalResultEntryType == 'True') {
            testResult.TestPerformedExternally = getTestPerformedExternally("chk_PneumococcalcapturebyChat", testResult.TestPerformedExternally)
        }
        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-Pneumococcal')));

        testResult.TestNotPerformed = getTestNotPerformedReasonForPneumococcal(testResult.TestNotPerformed);

        testResult.Manufacturer = getReading($("#PneumococcalManufacturerInputtext"), testResult.Manufacturer);
        testResult.LotNumber = getReading($("#PneumococcalLotNumberInputtext"), testResult.LotNumber);

        if (currentScreenMode != ScreenMode.Physician) {

            if (currentScreenMode != ScreenMode.CorrectionPostEvaluation && currentScreenMode != ScreenMode.PostAudit) testResult.ResultStatus.StateNumber = $("#ResultStatusInputHidden").val();

            if (testResult.ResultStatus.Id > 0) {
                testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.ResultStatus.DataRecorderMetaData.DateModified = currentDate;
            } else {
                testResult.ResultStatus.DataRecorderMetaData = { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate };
            }

            //testResult.Manufacturer = getReading($("#PneumococcalManufacturerInputtext"), testResult.Manufacturer);
            //testResult.LotNumber = getReading($("#PneumococcalLotNumberInputtext"), testResult.LotNumber);
        }

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.ConductedByOrgRoleUserId = $("#conductedbyPneumococcal option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesPneumococcal").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentPneumococcalInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestPneumococcalCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_74").attr("checked");

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }


        if (currentScreenMode != ScreenMode.Entry) {
            testResult.TechnicallyLimitedbutReadable = getboolTypeReading($('#technicallyltdbutreadablePneumococcalinputcheck'), testResult.TechnicallyLimitedbutReadable);
            testResult.RepeatStudy = getboolTypeReading($('#repeatstudyPneumococcalinputcheck'), testResult.RepeatStudy);

            if (testResult.PhysicianInterpretation == null)
                testResult.PhysicianInterpretation = {
                    'Remarks': $("#physicianRemarksPneumococcal").val(),
                    'IsCritical': $("#criticalPneumococcal").attr("checked"),
                    'FollowUp': $("#followUpPneumococcal").attr("checked"),
                    'RecorderMetaData': {
                        'DataRecorderCreator': { 'Id': currentUser },
                        'DateCreated': currentDate
                    }
                };
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksPneumococcal").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpPneumococcal").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalPneumococcal").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }


        if (testResult.ResultStatus.StateNumber < 4) {
            // To Check if no entry has been done
            if (testResult.Fev1 == null && testResult.UnableScreenReason == null && testResult.TechnicianNotes.length < 1
                && testResult.ConductedByOrgRoleUserId == "0" && $("#DescribeSelfPresentPneumococcalInputCheck").attr("checked") == false) testResult = null;
        }

        return testResult;
    }
};

var criticalDataModel_Pneumococcal = null;
function onClick_CriticalDataPneumococcal() {
    if ($("#DescribeSelfPresentPneumococcalInputCheck").attr("checked")) {
        loadCriticalLink($("#Pneumococcal-critical-span"), "onClick_CriticalDataPneumococcal();", testTypePneumococcal);
        openCriticalDataDialog(testTypePneumococcal, $("#conductedbyPneumococcal"), $("#DescribeSelfPresentPneumococcalInputCheck"), setCriticalDataModel_Pneumococcal);
    }
    else {
        unloadCriticalLink($("#Pneumococcal-critical-span"), testTypePneumococcal);
    }
}

function setCriticalDataModel_Pneumococcal(model, printAfterSave) {
    if (model != null) {
        var testResult = GetPneumococcalData();
        saveSingleTestResult(testResult, model, $("#Pneumococcal-critical-span"), "onClick_CriticalDataPneumococcal();", SetPneumococcalData, printAfterSave);
    }
}

function getCriticalDataModel_Pneumococcal() {
    if ($("#DescribeSelfPresentPneumococcalInputCheck").attr("checked") && criticalDataModel_Pneumococcal != null) {
        criticalDataModel_Pneumococcal.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_Pneumococcal;
    }
    return null;
}
function onClick_PriorityInQueueDataPneumococcal() {
    if ($("#PriorityInQueueTestPneumococcalCheck").attr("checked")) {
        loadPriorityInQueueLink($("#Pneumococcal-priorityInQueue-span"), "onClick_PriorityInQueueDataPneumococcal();", testTypePneumococcal);
        openPriorityInQueueTestDialog(testTypePneumococcal, $("#conductedbyPneumococcal"), $("#PriorityInQueueTestPneumococcalCheck"), setPriorityInQueueDataModel_Pneumococcal);
    }
    else {
        unloadPriorityInQueueLink($("#Pneumococcal-priorityInQueue-span"), testTypePneumococcal);
    }
}

function setPriorityInQueueDataModel_Pneumococcal(model) {
    if (model != null) {
        var testResult = GetPneumococcalData();
        model.TestId = testTypePneumococcal;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#Pneumococcal-priorityInQueue-span"), "onClick_PriorityInQueueDataPneumococcal();", SetPneumococcalData);
    }
}
function clearAllPneumococcalSelection() {
    $(".dtl-unabletoscreen-Pneumococcal input[type=checkbox]").attr("checked", false);
    $("#PneumococcalManufacturerInputtext").val('');
    $("#PneumococcalLotNumberInputtext").val('');
}

function setTestNotPerformedReasonForPneumococcal(testNotPerformed) {
    setTestNotPerformed("testnotPerformedPneumococcal", testNotPerformed);
    SetTestNotPerformedEnableDisabled("testnotPerformedPneumococcal");
}

function getTestNotPerformedReasonForPneumococcal(testNotPerformed) {
    return getTestNotPerformed("testnotPerformedPneumococcal", testNotPerformed);
}
