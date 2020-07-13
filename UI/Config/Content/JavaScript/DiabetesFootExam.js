function DiabetesFootExam(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = {
            "Id": 0, "TestType": testTypeDiabetesFootExam,
            "LeftFootYes": null, "TechnicianNotes": '', "ConductedByOrgRoleUserId": '0',
            "UnableScreenReason": new Array(),
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "TestPerformedExternally": null,
            "ResultStatus": { "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentDiabetesFootExamInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestDiabetesFootExamCheck").attr("checked")
            }
        };
    }
    this.Result = testResult;
}

DiabetesFootExam.prototype = {
    setData: function() {
        var testResult = this.Result; 

        if (isDiabetesFootExamResultEntryType == 'True') {
            setTestPerformedExternally("chk_DiabetesFootExamcapturebyChat", testResult.TestPerformedExternally)
        }

        if (testResult.LeftFootYes != null && testResult.LeftFootYes.Reading == true) {
            $("#DiabetesFootExamLeftFootYesinputcheck").attr("checked", "checked");
        }
        else if (testResult.LeftFootNo != null && testResult.LeftFootNo.Reading == true) {
            $("#DiabetesFootExamLeftFootNoinputcheck").attr("checked", "checked");
        }
        
        if (testResult.RightFootYes != null && testResult.RightFootYes.Reading == true) {
            $("#DiabetesFootExamRightFootYesinputcheck").attr("checked", "checked");
        }
        else if (testResult.RightFootNo != null && testResult.RightFootNo.Reading == true) {
            $("#DiabetesFootExamRightFootNoinputcheck").attr("checked", "checked");
        }

        $("#DescribeSelfPresentDiabetesFootExamInputCheck").attr("checked", testResult.ResultStatus.SelfPresent); 
        $("#technotesDiabetesFootExam").val(testResult.TechnicianNotes);
        $("#conductedbyDiabetesFootExam option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);

        setboolTypeReading($('#DiabetesFootExamtechnicallyltdbutreadableinputcheck'), testResult.TechnicallyLimitedbutReadable);
        setboolTypeReading($('#DiabetesFootExamrepeatstudyinputcheck'), testResult.RepeatStudy);

        setUnableScreenReason($('.dtl-unabletoscreen-DiabetesFootExam'), testResult.UnableScreenReason);

        $("#PriorityInQueueTestDiabetesFootExamCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#diabetesFootExam-priorityInQueue-span"), "onClick_PriorityInQueueDataDiabetesFootExam();", testTypeDiabetesFootExam);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#diabetesFootExam-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#DiabetesFootExam-critical-span"), "onClick_CriticalDataDiabetesFootExam();", testTypeDiabetesFootExam);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#DiabetesFootExam-critical-span").parent().addClass("red-band");
                $("#criticalDiabetesFootExam").attr("checked", "checked");
            }
        }

        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksDiabetesFootExam").val(testResult.PhysicianInterpretation.Remarks);
            $("#criticalDiabetesFootExam").attr("checked", testResult.PhysicianInterpretation.IsCritical);

        }

    },
    getData: function() {
        var testResult = this.Result; 
        if (isDiabetesFootExamResultEntryType == 'True') {
            testResult.TestPerformedExternally = getTestPerformedExternally("chk_DiabetesFootExamcapturebyChat", testResult.TestPerformedExternally)
        }
        testResult.LeftFootYes = getboolTypeReadingRadioButton($(".leftFootYes"), testResult.LeftFootYes);
        testResult.LeftFootNo = getboolTypeReadingRadioButton($(".leftFootNo"), testResult.LeftFootNo);
        testResult.RightFootYes = getboolTypeReadingRadioButton($(".rightFootYes"), testResult.RightFootYes);
        testResult.RightFootNo = getboolTypeReadingRadioButton($(".rightFootNo"), testResult.RightFootNo);

         
        if (currentScreenMode != ScreenMode.Physician) {

            //testResult.LeftFootYes = getboolTypeReadingRadioButton($(".leftFootYes"), testResult.LeftFootYes);
            //testResult.LeftFootNo = getboolTypeReadingRadioButton($(".leftFootNo"), testResult.LeftFootNo);
            //testResult.RightFootYes = getboolTypeReadingRadioButton($(".rightFootYes"), testResult.RightFootYes);
            //testResult.RightFootNo = getboolTypeReadingRadioButton($(".rightFootNo"), testResult.RightFootNo);

            if (currentScreenMode != ScreenMode.CorrectionPostEvaluation && currentScreenMode != ScreenMode.PostAudit) testResult.ResultStatus.StateNumber = $("#ResultStatusInputHidden").val();

            if (testResult.ResultStatus.Id > 0) {
                testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.ResultStatus.DataRecorderMetaData.DateModified = currentDate;
            } else {
                testResult.ResultStatus.DataRecorderMetaData = { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate };
            }
        }

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-DiabetesFootExam')));

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.ConductedByOrgRoleUserId = $("#conductedbyDiabetesFootExam option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesDiabetesFootExam").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentDiabetesFootExamInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestDiabetesFootExamCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_71").attr("checked");

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }

        if (currentScreenMode != ScreenMode.Entry) {

            testResult.RepeatStudy = getboolTypeReading($('#DiabetesFootExamrepeatstudyinputcheck'), testResult.RepeatStudy);
            testResult.TechnicallyLimitedbutReadable = getboolTypeReading($('#DiabetesFootExamtechnicallyltdbutreadableinputcheck'), testResult.TechnicallyLimitedbutReadable);

            if (testResult.PhysicianInterpretation == null)
                testResult.PhysicianInterpretation = {
                    'Remarks': $("#physicianRemarksDiabetesFootExam").val(),
                    'IsCritical': $("#criticalDiabetesFootExam").attr("checked"),
                    'FollowUp': $("#followUpDiabetesFootExam").attr("checked"),
                    'RecorderMetaData': {
                        'DataRecorderCreator': { 'Id': currentUser },
                        'DateCreated': currentDate
                    }
                };
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksDiabetesFootExam").val();
                testResult.PhysicianInterpretation.IsCritical = $("#criticalDiabetesFootExam").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }

        if (testResult.ResultStatus.StateNumber < 4) {
            if (testResult.LeftFootYes == null && testResult.LeftFootNo == null && testResult.RightFootYes == null && testResult.RightFootNo == null && testResult.TechnicianNotes.length < 1 && testResult.ConductedByOrgRoleUserId == "0" && testResult.UnableScreenReason == null && $("#DescribeSelfPresentDiabetesFootExamInputCheck").attr("checked") == false)
                return null;
        }

        return testResult;
    }
};


var criticalDataModel_DiabetesFootExam = null;
function onClick_CriticalDataDiabetesFootExam() {
    if ($("#DescribeSelfPresentDiabetesFootExamInputCheck").attr("checked")) {
        loadCriticalLink($("#DiabetesFootExam-critical-span"), "onClick_CriticalDataDiabetesFootExam();", testTypeDiabetesFootExam);
        openCriticalDataDialog(testTypeDiabetesFootExam, $("#conductedbyDiabetesFootExam"), $("#DescribeSelfPresentDiabetesFootExamInputCheck"), setCriticalDataModel_DiabetesFootExam);
    }
    else {
        unloadCriticalLink($("#DiabetesFootExam-critical-span"), testTypeDiabetesFootExam);
    }
}

function setCriticalDataModel_DiabetesFootExam(model, printAfterSave) {
    if (model != null) {
        var testResult = GetDiabetesFootExamData();
        saveSingleTestResult(testResult, model, $("#DiabetesFootExam-critical-span"), "onClick_CriticalDataDiabetesFootExam();", SetDiabetesFootExamData, printAfterSave);
    }
}

function getCriticalDataModel_DiabetesFootExam() {
    if ($("#DescribeSelfPresentDiabetesFootExamInputCheck").attr("checked") && criticalDataModel_DiabetesFootExam != null) {
        criticalDataModel_DiabetesFootExam.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_DiabetesFootExam;
    }
    return null;
}

function onClick_PriorityInQueueDataDiabetesFootExam() {
    if ($("#PriorityInQueueTestDiabetesFootExamCheck").attr("checked")) {
        loadPriorityInQueueLink($("#diabetesFootExam-priorityInQueue-span"), "onClick_PriorityInQueueDataDiabetesFootExam();", testTypeDiabetesFootExam);
        openPriorityInQueueTestDialog(testTypeDiabetesFootExam, $("#conductedbyDiabetesFootExam"), $("#PriorityInQueueTestDiabetesFootExamCheck"), setPriorityInQueueDataModel_DiabetesFootExam);
    }
    else {
        unloadPriorityInQueueLink($("#diabetesFootExam-priorityInQueue-span"), testTypeDiabetesFootExam);
    }
}

function setPriorityInQueueDataModel_DiabetesFootExam(model) {
    if (model != null) {
        var testResult = GetDiabetesFootExamData();
        model.TestId = testTypeDiabetesFootExam;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#diabetesFootExam-priorityInQueue-span"), "onClick_PriorityInQueueDataDiabetesFootExam();", SetDiabetesFootExamData);
    }
}