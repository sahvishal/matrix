function Hypertension(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = {
            "Id": 0, "TestType": testTypeHypertension,
            "Systolic": null, "TechnicianNotes": '', "ConductedByOrgRoleUserId": '0',
            "UnableScreenReason": new Array(),
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "TestPerformedExternally": null,
            "ResultStatus": { "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentHypertensionInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestHypertensionCheck").attr("checked")
            }
        };
    }
    this.Result = testResult;
}

Hypertension.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (IsHypertensionResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_HypertensioncapturebyChat", testResult.TestPerformedExternally)
        }
        
        setReading($("#HypertensionSystolictextbox"), testResult.Systolic);
        setReading($("#HypertensionDiastolictextbox"), testResult.Diastolic);
        //debugger;
        if (testResult.RightArmBpMeasurement != null && testResult.RightArmBpMeasurement.Reading == true) {
            $("#HypertensionRightArmBpinputcheck").attr("checked", "checked");
        } else {
            $("#HypertensionLeftArmBpinputcheck").attr("checked", "checked");
        }
        
        setReading($("#HypertensionPulseRatetextbox"), testResult.Pulse);
        
        setboolTypeReading($("#HypertensionisElevatedBpinputcheck"), testResult.BloodPressureElevated);
        
        $("#DescribeSelfPresentHypertensionInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);
        setTestNotPerformedReasonForHypertension(testResult.TestNotPerformed);

        $("#technotesHypertension").val(testResult.TechnicianNotes);
        $("#conductedbyHypertension option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);

        setboolTypeReading($('#Hypertensiontechnicallyltdbutreadableinputcheck'), testResult.TechnicallyLimitedbutReadable);
        setboolTypeReading($('#Hypertensionrepeatstudyinputcheck'), testResult.RepeatStudy);

        setUnableScreenReason($('.dtl-unabletoscreen-Hypertension'), testResult.UnableScreenReason);
        
        $("#PriorityInQueueTestHypertensionCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#hypertension-priorityInQueue-span"), "onClick_PriorityInQueueDataHypertension();", testTypeHypertension);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#hypertension-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#Hypertension-critical-span"), "onClick_CriticalDataHypertension();", testTypeHypertension);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#Hypertension-critical-span").parent().addClass("red-band");
                $("#criticalHypertension").attr("checked", "checked");
            }
        }

        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksHypertension").val(testResult.PhysicianInterpretation.Remarks);
            $("#criticalHypertension").attr("checked", testResult.PhysicianInterpretation.IsCritical);
            
        }
		
    },
    getData: function () {
        var testResult = this.Result;
        
        if (IsHypertensionResultEntryExternaly == 'True') {
             testResult.TestPerformedExternally = getTestPerformedExternally("chk_HypertensioncapturebyChat", testResult.TestPerformedExternally)
        }
        
        testResult.BloodPressureElevated = getboolTypeReading($("#HypertensionisElevatedBpinputcheck"), testResult.BloodPressureElevated);
        
        testResult.Systolic = getReading($("#HypertensionSystolictextbox"), testResult.Systolic);
        testResult.Diastolic = getReading($("#HypertensionDiastolictextbox"), testResult.Diastolic);
        testResult.Pulse = getReading($("#HypertensionPulseRatetextbox"), testResult.Pulse);

        if ($('#HypertensionRightArmBpinputcheck').is(':checked') == false) {
            $("#HypertensionLeftArmBpinputcheck").attr("checked", "checked");
        }

        testResult.RightArmBpMeasurement = getboolTypeReadingRadioButton($(".hypertenstionMeasurement"), testResult.RightArmBpMeasurement);

        if (currentScreenMode != ScreenMode.Physician) {

            //testResult.Systolic  = getReading($("#HypertensionSystolictextbox"), testResult.Systolic);
            //testResult.Diastolic = getReading($("#HypertensionDiastolictextbox"), testResult.Diastolic);
            //testResult.Pulse = getReading($("#HypertensionPulseRatetextbox"), testResult.Pulse);
              
            //if ($('#HypertensionRightArmBpinputcheck').is(':checked') == false) {
            //    $("#HypertensionLeftArmBpinputcheck").attr("checked", "checked");
            //}
            
            //testResult.RightArmBpMeasurement = getboolTypeReadingRadioButton($(".hypertenstionMeasurement"), testResult.RightArmBpMeasurement);
            
            
            if (currentScreenMode != ScreenMode.CorrectionPostEvaluation && currentScreenMode != ScreenMode.PostAudit) testResult.ResultStatus.StateNumber = $("#ResultStatusInputHidden").val();

            if (testResult.ResultStatus.Id > 0) {
                testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.ResultStatus.DataRecorderMetaData.DateModified = currentDate;
            }
            else {
                testResult.ResultStatus.DataRecorderMetaData = { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate };
            }
        }

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-Hypertension')));
        
        testResult.TestNotPerformed = getTestNotPerformedReasonForHypertension(testResult.TestNotPerformed);
        
        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.ConductedByOrgRoleUserId = $("#conductedbyHypertension option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesHypertension").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentHypertensionInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestHypertensionCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_67").attr("checked");

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }

        if (currentScreenMode != ScreenMode.Entry) {

            testResult.RepeatStudy = getboolTypeReading($('#Hypertensionrepeatstudyinputcheck'), testResult.RepeatStudy);
            testResult.TechnicallyLimitedbutReadable = getboolTypeReading($('#Hypertensiontechnicallyltdbutreadableinputcheck'), testResult.TechnicallyLimitedbutReadable);

            if (testResult.PhysicianInterpretation == null)
                testResult.PhysicianInterpretation = {
                    'Remarks': $("#physicianRemarksHypertension").val(), 'IsCritical': $("#criticalHypertension").attr("checked"), 'FollowUp': $("#followUpHypertension").attr("checked"), 'RecorderMetaData': {
                        'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate
                    }
                };
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksHypertension").val();
                testResult.PhysicianInterpretation.IsCritical = $("#criticalHypertension").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }

        if (testResult.ResultStatus.StateNumber < 4) {
            if (testResult.HypertensionSCR == null && testResult.TechnicianNotes.length < 1 && testResult.ConductedByOrgRoleUserId == "0" && testResult.UnableScreenReason == null && $("#DescribeSelfPresentHypertensionInputCheck").attr("checked") == false)
                return null;
        }

        return testResult;
    }
}


var criticalDataModel_Hypertension = null;
function onClick_CriticalDataHypertension() {
    if ($("#DescribeSelfPresentHypertensionInputCheck").attr("checked")) {
        loadCriticalLink($("#Hypertension-critical-span"), "onClick_CriticalDataHypertension();", testTypeHypertension);
        openCriticalDataDialog(testTypeHypertension, $("#conductedbyHypertension"), $("#DescribeSelfPresentHypertensionInputCheck"), setCriticalDataModel_Hypertension);
    }
    else {
        unloadCriticalLink($("#Hypertension-critical-span"), testTypeHypertension);
    }
}

function setCriticalDataModel_Hypertension(model, printAfterSave) {
    if (model != null) {
        var testResult = GetHypertensionData();
        saveSingleTestResult(testResult, model, $("#Hypertension-critical-span"), "onClick_CriticalDataHypertension();", SetHypertensionData, printAfterSave);
    }
}

function getCriticalDataModel_Hypertension() {
    if ($("#DescribeSelfPresentHypertensionInputCheck").attr("checked") && criticalDataModel_Hypertension != null) {
        criticalDataModel_Hypertension.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_Hypertension;
    }
    return null;
}

function onClick_PriorityInQueueDataHypertension() {
    if ($("#PriorityInQueueTestHypertensionCheck").attr("checked")) {
        loadPriorityInQueueLink($("#hypertension-priorityInQueue-span"), "onClick_PriorityInQueueDataHypertension();", testTypeHypertension);
        openPriorityInQueueTestDialog(testTypeHypertension, $("#conductedbyHypertension"), $("#PriorityInQueueTestHypertensionCheck"), setPriorityInQueueDataModel_Hypertension);
    }
    else {
        unloadPriorityInQueueLink($("#hypertension-priorityInQueue-span"), testTypeHypertension);
    }
}

function setPriorityInQueueDataModel_Hypertension(model) {
    if (model != null) {
        var testResult = GetHypertensionData();
        model.TestId = testTypeHypertension;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#hypertension-priorityInQueue-span"), "onClick_PriorityInQueueDataHypertension();", SetHypertensionData);
    }
}

function setTestNotPerformedReasonForHypertension(testNotPerformed) {
    setTestNotPerformed("testnotPerformedHypertension", testNotPerformed);
    SetTestNotPerformedEnableDisabled("testnotPerformedHypertension");
}

function getTestNotPerformedReasonForHypertension(testNotPerformed) {
    return getTestNotPerformed("testnotPerformedHypertension", testNotPerformed);
}