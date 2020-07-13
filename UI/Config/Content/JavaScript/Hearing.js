function Hearing(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = {
            "Id": 0, "TestType": testTypeHearing,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": '0',
            "UnableScreenReason": new Array(),
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "TestPerformedExternally": null,
            "ResultStatus": {
                "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentHearingInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestHearingCheck").attr("checked")
            }
        };
    }
    this.Result = testResult;
}

Hearing.prototype = {
    setData: function () {
        var testResult = this.Result;

        if (IshearingResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_hearingcapturebyChat", testResult.TestPerformedExternally)
        }

        if (testResult.HearingSummary != null)
            setboolTypeReadingRadioButton($(".hearingSummary"), testResult.HearingSummary);

        if (testResult.RightEar500Hz != null)
            setReading($("#RightEar500HzTextBox"), testResult.RightEar500Hz);
        if (testResult.LeftEar500Hz != null)
            setReading($("#LeftEar500HzTextBox"), testResult.LeftEar500Hz);

        if (testResult.RightEar1000Hz != null)
            setReading($("#RightEar1000HzTextBox"), testResult.RightEar1000Hz);
        if (testResult.LeftEar1000Hz != null)
            setReading($("#LeftEar1000HzTextBox"), testResult.LeftEar1000Hz);

        if (testResult.RightEar2000Hz != null)
            setReading($("#RightEar2000HzTextBox"), testResult.RightEar2000Hz);
        if (testResult.LeftEar2000Hz != null)
            setReading($("#LeftEar2000HzTextBox"), testResult.LeftEar2000Hz);

        if (testResult.RightEar3000Hz != null)
            setReading($("#RightEar3000HzTextBox"), testResult.RightEar3000Hz);
        if (testResult.LeftEar3000Hz != null)
            setReading($("#LeftEar3000HzTextBox"), testResult.LeftEar3000Hz);

        if (testResult.RightEar4000Hz != null)
            setReading($("#RightEar4000HzTextBox"), testResult.RightEar4000Hz);
        if (testResult.LeftEar4000Hz != null)
            setReading($("#LeftEar4000HzTextBox"), testResult.LeftEar4000Hz);

        if (testResult.RightEar6000Hz != null)
            setReading($("#RightEar6000HzTextBox"), testResult.RightEar6000Hz);
        if (testResult.LeftEar6000Hz != null)
            setReading($("#LeftEar6000HzTextBox"), testResult.LeftEar6000Hz);

        if (testResult.RightEar8000Hz != null)
            setReading($("#RightEar8000HzTextBox"), testResult.RightEar8000Hz);
        if (testResult.LeftEar8000Hz != null)
            setReading($("#LeftEar8000HzTextBox"), testResult.LeftEar8000Hz);


        $("#DescribeSelfPresentHearingInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);

        $("#PriorityInQueueTestHearingCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#hearing-priorityInQueue-span"), "onClick_PriorityInQueueDataHearing();", testTypeHearing);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#hearing-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#hearing-critical-span"), "onClick_CriticalDataHearing();", testTypeHearing);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#hearing-critical-span").parent().addClass("red-band");
            }
        }

        $("#technotesHearing").val(testResult.TechnicianNotes);
        $("#conductedbyHearing option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);

        setUnableScreenReason($('.dtl-unabletoscreen-Hearing'), testResult.UnableScreenReason);

    },
    getData: function () {
        var testResult = this.Result;
        if (IshearingResultEntryExternaly == 'True') {
            testResult.TestPerformedExternally = getTestPerformedExternally("chk_hearingcapturebyChat", testResult.TestPerformedExternally)
        }

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-Hearing')));

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.ConductedByOrgRoleUserId = $("#conductedbyHearing option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesHearing").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentHearingInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestHearingCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_45").attr("checked");
        
        testResult.HearingSummary = getboolTypeReadingRadioButton($(".hearingSummary"), testResult.HearingSummary);
        testResult.RightEar500Hz = getReading($("#RightEar500HzTextBox"), testResult.RightEar500Hz);
        testResult.LeftEar500Hz = getReading($("#LeftEar500HzTextBox"), testResult.LeftEar500Hz);

        testResult.RightEar1000Hz = getReading($("#RightEar1000HzTextBox"), testResult.RightEar1000Hz);
        testResult.LeftEar1000Hz = getReading($("#LeftEar1000HzTextBox"), testResult.LeftEar1000Hz);

        testResult.RightEar2000Hz = getReading($("#RightEar2000HzTextBox"), testResult.RightEar2000Hz);
        testResult.LeftEar2000Hz = getReading($("#LeftEar2000HzTextBox"), testResult.LeftEar2000Hz);

        testResult.RightEar3000Hz = getReading($("#RightEar3000HzTextBox"), testResult.RightEar3000Hz);
        testResult.LeftEar3000Hz = getReading($("#LeftEar3000HzTextBox"), testResult.LeftEar3000Hz);

        testResult.RightEar4000Hz = getReading($("#RightEar4000HzTextBox"), testResult.RightEar4000Hz);
        testResult.LeftEar4000Hz = getReading($("#LeftEar4000HzTextBox"), testResult.LeftEar4000Hz);

        testResult.RightEar6000Hz = getReading($("#RightEar6000HzTextBox"), testResult.RightEar6000Hz);
        testResult.LeftEar6000Hz = getReading($("#LeftEar6000HzTextBox"), testResult.LeftEar6000Hz);

        testResult.RightEar8000Hz = getReading($("#RightEar8000HzTextBox"), testResult.RightEar8000Hz);
        testResult.LeftEar8000Hz = getReading($("#LeftEar8000HzTextBox"), testResult.LeftEar8000Hz);

        if (currentScreenMode != ScreenMode.Physician) {
            
            //testResult.HearingSummary = getboolTypeReadingRadioButton($(".hearingSummary"), testResult.HearingSummary);
            //testResult.RightEar500Hz = getReading($("#RightEar500HzTextBox"), testResult.RightEar500Hz);
            //testResult.LeftEar500Hz = getReading($("#LeftEar500HzTextBox"), testResult.LeftEar500Hz);
            
            //testResult.RightEar1000Hz = getReading($("#RightEar1000HzTextBox"), testResult.RightEar1000Hz);
            //testResult.LeftEar1000Hz = getReading($("#LeftEar1000HzTextBox"), testResult.LeftEar1000Hz);
            
            //testResult.RightEar2000Hz = getReading($("#RightEar2000HzTextBox"), testResult.RightEar2000Hz);
            //testResult.LeftEar2000Hz = getReading($("#LeftEar2000HzTextBox"), testResult.LeftEar2000Hz);
            
            //testResult.RightEar3000Hz = getReading($("#RightEar3000HzTextBox"), testResult.RightEar3000Hz);
            //testResult.LeftEar3000Hz = getReading($("#LeftEar3000HzTextBox"), testResult.LeftEar3000Hz);
            
            //testResult.RightEar4000Hz = getReading($("#RightEar4000HzTextBox"), testResult.RightEar4000Hz);
            //testResult.LeftEar4000Hz = getReading($("#LeftEar4000HzTextBox"), testResult.LeftEar4000Hz);
            
            //testResult.RightEar6000Hz = getReading($("#RightEar6000HzTextBox"), testResult.RightEar6000Hz);
            //testResult.LeftEar6000Hz = getReading($("#LeftEar6000HzTextBox"), testResult.LeftEar6000Hz);
            
            //testResult.RightEar8000Hz = getReading($("#RightEar8000HzTextBox"), testResult.RightEar8000Hz);
            //testResult.LeftEar8000Hz = getReading($("#LeftEar8000HzTextBox"), testResult.LeftEar8000Hz);

            if (currentScreenMode != ScreenMode.CorrectionPostEvaluation) testResult.ResultStatus.StateNumber = $("#ResultStatusInputHidden").val();

            if (testResult.ResultStatus.Id > 0) {
                testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.ResultStatus.DataRecorderMetaData.DateModified = currentDate;
            }
            else {
                testResult.ResultStatus.DataRecorderMetaData = { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate };
            }
        }

        if (testResult.ResultStatus.StateNumber < 4) {
            if (testResult.TechnicianNotes.length < 1 && testResult.ConductedByOrgRoleUserId == "0" && testResult.UnableScreenReason == null && $("#DescribeSelfPresentHearingInputCheck").attr("checked") == false
                && testResult.HearingSummary == null && testResult.RightEar500Hz == null && testResult.LeftEar500Hz == null && testResult.RightEar1000Hz == null && testResult.LeftEar1000Hz == null
                && testResult.RightEar2000Hz == null && testResult.LeftEar2000Hz == null && testResult.RightEar3000Hz == null && testResult.LeftEar3000Hz == null && testResult.RightEar4000Hz == null
                && testResult.LeftEar4000Hz == null && testResult.RightEar6000Hz == null && testResult.LeftEar6000Hz == null && testResult.RightEar8000Hz == null && testResult.LeftEar8000Hz == null)
                return null;
        }

        return testResult;
    }
}

var criticalDataModel_Hearing = null;
function onClick_CriticalDataHearing() {
    if ($("#DescribeSelfPresentHearingInputCheck").attr("checked")) {
        loadCriticalLink($("#hearing-critical-span"), "onClick_CriticalDataHearing();", testTypeHearing);
        openCriticalDataDialog(testTypeHearing, $("#conductedbyHearing"), $("#DescribeSelfPresentHearingInputCheck"), setCriticalDataModel_Hearing);
    }
    else {
        unloadCriticalLink($("#hearing-critical-span"), testTypeHearing);
    }
}

function setCriticalDataModel_Hearing(model, printAfterSave) {
    if (model != null) {
        var testResult = GetHearingData();
        saveSingleTestResult(testResult, model, $("#hearing-critical-span"), "onClick_CriticalDataHearing();", SetHearingData, printAfterSave);
    }
}

function getCriticalDataModel_Hearing() {
    if ($("#DescribeSelfPresentHearingInputCheck").attr("checked") && criticalDataModel_Hearing != null) {
        criticalDataModel_Hearing.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_Hearing;
    }
    return null;
}

function onClick_PriorityInQueueDataHearing() {
    if ($("#PriorityInQueueTestHearingCheck").attr("checked")) {
        loadPriorityInQueueLink($("#hearing-priorityInQueue-span"), "onClick_PriorityInQueueDataHearing();", testTypeHearing);
        openPriorityInQueueTestDialog(testTypeHearing, $("#conductedbyHearing"), $("#PriorityInQueueTestHearingCheck"), setPriorityInQueueDataModel_Hearing);
    }
    else {
        unloadPriorityInQueueLink($("#hearing-priorityInQueue-span"), testTypeHearing);
    }
}

function setPriorityInQueueDataModel_Hearing(model) {
    if (model != null) {
        var testResult = GetHearingData();
        model.TestId = testTypeHearing;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#hearing-priorityInQueue-span"), "onClick_PriorityInQueueDataHearing();", SetHearingData);
    }
}