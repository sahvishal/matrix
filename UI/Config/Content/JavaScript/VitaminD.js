function VitaminD(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = { "Id": 0, "TestType": testTypeVitaminD,
            "VitaminDSCR": null, "TechnicianNotes": '', "ConductedByOrgRoleUserId": '0',
            "UnableScreenReason": new Array(),
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "TestPerformedExternally": null,
            "ResultStatus": { "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentVitaminDInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestVitaminDCheck").attr("checked")
            }
        };
    }
    this.Result = testResult;
}

VitaminD.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (IsVitaminDResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_VitaminDcapturebyChat", testResult.TestPerformedExternally)
        }
        
        setReading($("#VitDtextbox"), testResult.VitD);

        $("#DescribeSelfPresentVitaminDInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);

        $("#technotesVitaminD").val(testResult.TechnicianNotes);
        $("#conductedbyVitaminD option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);
		
        setboolTypeReading($('#technicallyltdbutreadableVitaminDinputcheck'), testResult.TechnicallyLimitedbutReadable);
        setboolTypeReading($('#repeatstudyVitaminDinputcheck'), testResult.RepeatStudy);

        setUnableScreenReason($('.dtl-unabletoscreen-VitaminD'), testResult.UnableScreenReason);
        $("#PriorityInQueueTestVitaminDCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#vitaminD-priorityInQueue-span"), "onClick_PriorityInQueueDataVitaminD();", testTypeVitaminD);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#vitaminD-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#VitaminD-critical-span"), "onClick_CriticalDataVitaminD();", testTypeVitaminD);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#VitaminD-critical-span").parent().addClass("red-band");
            }
        }
		
        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksVitaminD").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpVitaminD").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalVitaminD").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }
    },
    getData: function () {
        var testResult = this.Result;
        if (IsVitaminDResultEntryExternaly == 'True') {
             testResult.TestPerformedExternally = getTestPerformedExternally("chk_VitaminDcapturebyChat", testResult.TestPerformedExternally)
        }
                       
        testResult.VitD = getReading($("#VitDtextbox"), testResult.VitD);

        if (currentScreenMode != ScreenMode.Physician) {
            //testResult.VitD = getReading($("#VitDtextbox"), testResult.VitD);
            if (currentScreenMode != ScreenMode.CorrectionPostEvaluation && currentScreenMode != ScreenMode.PostAudit) testResult.ResultStatus.StateNumber = $("#ResultStatusInputHidden").val();

            if (testResult.ResultStatus.Id > 0) {
                testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.ResultStatus.DataRecorderMetaData.DateModified = currentDate;
            }
            else {
                testResult.ResultStatus.DataRecorderMetaData = { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate };
            }
        }

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-VitaminD')));

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.ConductedByOrgRoleUserId = $("#conductedbyVitaminD option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesVitaminD").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentVitaminDInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestVitaminDCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_66").attr("checked");
        
        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }

        if (currentScreenMode != ScreenMode.Entry) {

            testResult.RepeatStudy = getboolTypeReading($('#repeatstudyVitaminDinputcheck'), testResult.RepeatStudy);
            testResult.TechnicallyLimitedbutReadable = getboolTypeReading($('#technicallyltdbutreadableVitaminDinputcheck'), testResult.TechnicallyLimitedbutReadable);

            if (testResult.PhysicianInterpretation == null)
                testResult.PhysicianInterpretation = {
                    'Remarks': $("#physicianRemarksVitaminD").val(), 'IsCritical': $("#criticalVitaminD").attr("checked"), 'FollowUp': $("#followUpVitaminD").attr("checked"), 'RecorderMetaData': {
                        'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate
                    }
                };
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksVitaminD").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpVitaminD").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalVitaminD").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }
        if (testResult.ResultStatus.StateNumber < 4) {
            if (testResult.VitaminDSCR == null && testResult.TechnicianNotes.length < 1 && testResult.ConductedByOrgRoleUserId == "0" && testResult.UnableScreenReason == null && $("#DescribeSelfPresentVitaminDInputCheck").attr("checked") == false)
                return null;
        }

        return testResult;
    }
}


var criticalDataModel_VitaminD = null;
function onClick_CriticalDataVitaminD() {
    if ($("#DescribeSelfPresentVitaminDInputCheck").attr("checked")) {
        loadCriticalLink($("#VitaminD-critical-span"), "onClick_CriticalDataVitaminD();", testTypeVitaminD);
        openCriticalDataDialog(testTypeVitaminD, $("#conductedbyVitaminD"), $("#DescribeSelfPresentVitaminDInputCheck"), setCriticalDataModel_VitaminD);
    }
    else {
        unloadCriticalLink($("#VitaminD-critical-span"), testTypeVitaminD);
    }
}

function setCriticalDataModel_VitaminD(model, printAfterSave) {
    if (model != null) {
        var testResult = GetVitaminDData();
        saveSingleTestResult(testResult, model, $("#VitaminD-critical-span"), "onClick_CriticalDataVitaminD();", SetVitaminDData, printAfterSave);
    }
}

function getCriticalDataModel_VitaminD() {
    if ($("#DescribeSelfPresentVitaminDInputCheck").attr("checked") && criticalDataModel_VitaminD != null) {
        criticalDataModel_VitaminD.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_VitaminD;
    }
    return null;
}

// VitaminD-critical-span

function onClick_PriorityInQueueDataVitaminD() {
    if ($("#PriorityInQueueTestVitaminDCheck").attr("checked")) {
        loadPriorityInQueueLink($("#vitaminD-priorityInQueue-span"), "onClick_PriorityInQueueDataVitaminD();", testTypeVitaminD);
        openPriorityInQueueTestDialog(testTypeVitaminD, $("#conductedbyVitaminD"), $("#PriorityInQueueTestVitaminDCheck"), setPriorityInQueueDataModel_VitaminD);
    }
    else {
        unloadPriorityInQueueLink($("#vitaminD-priorityInQueue-span"), testTypeVitaminD);
    }
}

function setPriorityInQueueDataModel_VitaminD(model) {
    if (model != null) {
        var testResult = GetVitaminDData();
        model.TestId = testTypeVitaminD;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#vitaminD-priorityInQueue-span"), "onClick_PriorityInQueueDataVitaminD();", SetVitaminDData);
    }
}