function Vision(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = {
            "Id": 0, "TestType": testTypeVision,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": '0',
            "UnableScreenReason": new Array(),
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "TestPerformedExternally": null,
            "ResultStatus": {
                "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentVisionInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestVisionCheck").attr("checked")
            }
        };
    }
    this.Result = testResult;
}

Vision.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (IsvisionResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_visioncapturebyChat", testResult.TestPerformedExternally)
        }
        
        if (testResult.BothEyesLeftUpperQuadrant != null)
            setboolTypeReadingRadioButton($(".bothEyesLeftUpperQuadrant"), testResult.BothEyesLeftUpperQuadrant);
        if (testResult.BothEyesLeftLowerQuadrant != null)
            setboolTypeReadingRadioButton($(".bothEyesLeftLowerQuadrant"), testResult.BothEyesLeftLowerQuadrant);
        if (testResult.BothEyesRightUpperQuadrant != null)
            setboolTypeReadingRadioButton($(".bothEyesRightUpperQuadrant"), testResult.BothEyesRightUpperQuadrant);
        if (testResult.BothEyesRightLowerQuadrant != null)
            setboolTypeReadingRadioButton($(".bothEyesRightLowerQuadrant"), testResult.BothEyesRightLowerQuadrant);
        
        if (testResult.RightEyeLeftUpperQuadrant != null)
            setboolTypeReadingRadioButton($(".rightEyeLeftUpperQuadrant"), testResult.RightEyeLeftUpperQuadrant);
        if (testResult.RightEyeLeftLowerQuadrant != null)
            setboolTypeReadingRadioButton($(".rightEyeLeftLowerQuadrant"), testResult.RightEyeLeftLowerQuadrant);
        if (testResult.RightEyeRightUpperQuadrant != null)
            setboolTypeReadingRadioButton($(".rightEyeRightUpperQuadrant"), testResult.RightEyeRightUpperQuadrant);
        if (testResult.RightEyeRightLowerQuadrant != null)
            setboolTypeReadingRadioButton($(".rightEyeRightLowerQuadrant"), testResult.RightEyeRightLowerQuadrant);
        
        if (testResult.LeftEyeLeftUpperQuadrant != null)
            setboolTypeReadingRadioButton($(".leftEyeLeftUpperQuadrant"), testResult.LeftEyeLeftUpperQuadrant);
        if (testResult.LeftEyeLeftLowerQuadrant != null)
            setboolTypeReadingRadioButton($(".leftEyeLeftLowerQuadrant"), testResult.LeftEyeLeftLowerQuadrant);
        if (testResult.LeftEyeRightUpperQuadrant != null)
            setboolTypeReadingRadioButton($(".leftEyeRightUpperQuadrant"), testResult.LeftEyeRightUpperQuadrant);
        if (testResult.LeftEyeRightLowerQuadrant != null)
            setboolTypeReadingRadioButton($(".leftEyeRightLowerQuadrant"), testResult.LeftEyeRightLowerQuadrant);
        
        if (testResult.RightEyeCylindrical != null)
            setReading($("#RightEyeCylindrical"), testResult.RightEyeCylindrical);
        if (testResult.RightEyeSpherical != null)
            setReading($("#RightEyeSpherical"), testResult.RightEyeSpherical);
        
        if (testResult.LeftEyeCylindrical != null)
            setReading($("#LeftEyeCylindrical"), testResult.LeftEyeCylindrical);
        if (testResult.LeftEyeSpherical != null)
            setReading($("#LeftEyeSpherical"), testResult.LeftEyeSpherical);


        $("#DescribeSelfPresentVisionInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);

        $("#PriorityInQueueTestVisionCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#vision-priorityInQueue-span"), "onClick_PriorityInQueueDataVision();", testTypeVision);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#vision-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#vision-critical-span"), "onClick_CriticalDataVision();", testTypeVision);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#vision-critical-span").parent().addClass("red-band");
            }
        }

        $("#technotesVision").val(testResult.TechnicianNotes);
        $("#conductedbyVision option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);

        setUnableScreenReason($('.dtl-unabletoscreen-Vision'), testResult.UnableScreenReason);
        
        setTestNotPerformedReasonForVision(testResult.TestNotPerformed);
    },
    getData: function () {
        var testResult = this.Result;
        if (IsvisionResultEntryExternaly == 'True') {
             testResult.TestPerformedExternally = getTestPerformedExternally("chk_visioncapturebyChat", testResult.TestPerformedExternally)
        }

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-Vision')));

        testResult.TestNotPerformed = getTestNotPerformedReasonForVision(testResult.TestNotPerformed);

        testResult.BothEyesLeftUpperQuadrant = getboolTypeReadingRadioButton($(".bothEyesLeftUpperQuadrant"), testResult.BothEyesLeftUpperQuadrant);
        testResult.BothEyesLeftLowerQuadrant = getboolTypeReadingRadioButton($(".bothEyesLeftLowerQuadrant"), testResult.BothEyesLeftLowerQuadrant);
        testResult.BothEyesRightUpperQuadrant = getboolTypeReadingRadioButton($(".bothEyesRightUpperQuadrant"), testResult.BothEyesRightUpperQuadrant);
        testResult.BothEyesRightLowerQuadrant = getboolTypeReadingRadioButton($(".bothEyesRightLowerQuadrant"), testResult.BothEyesRightLowerQuadrant);

        testResult.RightEyeLeftUpperQuadrant = getboolTypeReadingRadioButton($(".rightEyeLeftUpperQuadrant"), testResult.RightEyeLeftUpperQuadrant);
        testResult.RightEyeLeftLowerQuadrant = getboolTypeReadingRadioButton($(".rightEyeLeftLowerQuadrant"), testResult.RightEyeLeftLowerQuadrant);
        testResult.RightEyeRightUpperQuadrant = getboolTypeReadingRadioButton($(".rightEyeRightUpperQuadrant"), testResult.RightEyeRightUpperQuadrant);
        testResult.RightEyeRightLowerQuadrant = getboolTypeReadingRadioButton($(".rightEyeRightLowerQuadrant"), testResult.RightEyeRightLowerQuadrant);

        testResult.LeftEyeLeftUpperQuadrant = getboolTypeReadingRadioButton($(".leftEyeLeftUpperQuadrant"), testResult.LeftEyeLeftUpperQuadrant);
        testResult.LeftEyeLeftLowerQuadrant = getboolTypeReadingRadioButton($(".leftEyeLeftLowerQuadrant"), testResult.LeftEyeLeftLowerQuadrant);
        testResult.LeftEyeRightUpperQuadrant = getboolTypeReadingRadioButton($(".leftEyeRightUpperQuadrant"), testResult.LeftEyeRightUpperQuadrant);
        testResult.LeftEyeRightLowerQuadrant = getboolTypeReadingRadioButton($(".leftEyeRightLowerQuadrant"), testResult.LeftEyeRightLowerQuadrant);

        testResult.RightEyeCylindrical = getReading($("#RightEyeCylindrical"), testResult.RightEyeCylindrical);
        testResult.RightEyeSpherical = getReading($("#RightEyeSpherical"), testResult.RightEyeSpherical);

        testResult.LeftEyeCylindrical = getReading($("#LeftEyeCylindrical"), testResult.LeftEyeCylindrical);
        testResult.LeftEyeSpherical = getReading($("#LeftEyeSpherical"), testResult.LeftEyeSpherical);


        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.ConductedByOrgRoleUserId = $("#conductedbyVision option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesVision").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentVisionInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestVisionCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_44").attr("checked");

        if (currentScreenMode != ScreenMode.Physician) {
            
            //testResult.BothEyesLeftUpperQuadrant = getboolTypeReadingRadioButton($(".bothEyesLeftUpperQuadrant"), testResult.BothEyesLeftUpperQuadrant);
            //testResult.BothEyesLeftLowerQuadrant = getboolTypeReadingRadioButton($(".bothEyesLeftLowerQuadrant"), testResult.BothEyesLeftLowerQuadrant);
            //testResult.BothEyesRightUpperQuadrant = getboolTypeReadingRadioButton($(".bothEyesRightUpperQuadrant"), testResult.BothEyesRightUpperQuadrant);
            //testResult.BothEyesRightLowerQuadrant = getboolTypeReadingRadioButton($(".bothEyesRightLowerQuadrant"), testResult.BothEyesRightLowerQuadrant);
            
            //testResult.RightEyeLeftUpperQuadrant = getboolTypeReadingRadioButton($(".rightEyeLeftUpperQuadrant"), testResult.RightEyeLeftUpperQuadrant);
            //testResult.RightEyeLeftLowerQuadrant = getboolTypeReadingRadioButton($(".rightEyeLeftLowerQuadrant"), testResult.RightEyeLeftLowerQuadrant);
            //testResult.RightEyeRightUpperQuadrant = getboolTypeReadingRadioButton($(".rightEyeRightUpperQuadrant"), testResult.RightEyeRightUpperQuadrant);
            //testResult.RightEyeRightLowerQuadrant = getboolTypeReadingRadioButton($(".rightEyeRightLowerQuadrant"), testResult.RightEyeRightLowerQuadrant);
            
            //testResult.LeftEyeLeftUpperQuadrant = getboolTypeReadingRadioButton($(".leftEyeLeftUpperQuadrant"), testResult.LeftEyeLeftUpperQuadrant);
            //testResult.LeftEyeLeftLowerQuadrant = getboolTypeReadingRadioButton($(".leftEyeLeftLowerQuadrant"), testResult.LeftEyeLeftLowerQuadrant);
            //testResult.LeftEyeRightUpperQuadrant = getboolTypeReadingRadioButton($(".leftEyeRightUpperQuadrant"), testResult.LeftEyeRightUpperQuadrant);
            //testResult.LeftEyeRightLowerQuadrant = getboolTypeReadingRadioButton($(".leftEyeRightLowerQuadrant"), testResult.LeftEyeRightLowerQuadrant);
            
            //testResult.RightEyeCylindrical = getReading($("#RightEyeCylindrical"), testResult.RightEyeCylindrical);
            //testResult.RightEyeSpherical = getReading($("#RightEyeSpherical"), testResult.RightEyeSpherical);

            //testResult.LeftEyeCylindrical = getReading($("#LeftEyeCylindrical"), testResult.LeftEyeCylindrical);
            //testResult.LeftEyeSpherical = getReading($("#LeftEyeSpherical"), testResult.LeftEyeSpherical);

            if (currentScreenMode != ScreenMode.CorrectionPostEvaluation && currentScreenMode != ScreenMode.PostAudit) testResult.ResultStatus.StateNumber = $("#ResultStatusInputHidden").val();

            if (testResult.ResultStatus.Id > 0) {
                testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.ResultStatus.DataRecorderMetaData.DateModified = currentDate;
            }
            else {
                testResult.ResultStatus.DataRecorderMetaData = { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate };
            }
        }

        if (testResult.ResultStatus.StateNumber < 4) {
            if (testResult.TechnicianNotes.length < 1 && testResult.ConductedByOrgRoleUserId == "0" && testResult.UnableScreenReason == null && $("#DescribeSelfPresentVisionInputCheck").attr("checked") == false
                && testResult.BothEyesLeftUpperQuadrant == null && testResult.BothEyesLeftLowerQuadrant == null && testResult.BothEyesRightUpperQuadrant == null && testResult.BothEyesRightLowerQuadrant == null
                && testResult.RightEyeLeftUpperQuadrant == null && testResult.RightEyeLeftLowerQuadrant == null && testResult.RightEyeRightUpperQuadrant == null && testResult.RightEyeRightLowerQuadrant == null
                && testResult.LeftEyeLeftUpperQuadrant == null && testResult.LeftEyeLeftLowerQuadrant == null && testResult.LeftEyeRightUpperQuadrant == null && testResult.LeftEyeRightLowerQuadrant == null
                && testResult.RightEyeCylindrical == null && testResult.RightEyeSpherical == null && testResult.LeftEyeCylindrical == null && testResult.LeftEyeSpherical == null)
                return null;
        }

        return testResult;
    }
}

var criticalDataModel_Vision = null;
function onClick_CriticalDataVision() {
    if ($("#DescribeSelfPresentVisionInputCheck").attr("checked")) {
        loadCriticalLink($("#vision-critical-span"), "onClick_CriticalDataVision();", testTypeVision);
        openCriticalDataDialog(testTypeVision, $("#conductedbyVision"), $("#DescribeSelfPresentVisionInputCheck"), setCriticalDataModel_Vision);
    }
    else {
        unloadCriticalLink($("#vision-critical-span"), testTypeVision);
    }
}

function setCriticalDataModel_Vision(model, printAfterSave) {
    if (model != null) {
        var testResult = GetVisionData();
        saveSingleTestResult(testResult, model, $("#vision-critical-span"), "onClick_CriticalDataVision();", SetVisionData, printAfterSave);
    }
}

function getCriticalDataModel_Vision() {
    if ($("#DescribeSelfPresentVisionInputCheck").attr("checked") && criticalDataModel_Vision != null) {
        criticalDataModel_Vision.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_Vision;
    }
    return null;
}

function onClick_PriorityInQueueDataVision() {
    if ($("#PriorityInQueueTestVisionCheck").attr("checked")) {
        loadPriorityInQueueLink($("#vision-priorityInQueue-span"), "onClick_PriorityInQueueDataVision();", testTypeVision);
        openPriorityInQueueTestDialog(testTypeVision, $("#conductedbyVision"), $("#PriorityInQueueTestVisionCheck"), setPriorityInQueueDataModel_Vision);
    }
    else {
        unloadPriorityInQueueLink($("#vision-priorityInQueue-span"), testTypeVision);
    }
}

function setPriorityInQueueDataModel_Vision(model) {
    if (model != null) {
        var testResult = GetVisionData();
        model.TestId = testTypeVision;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#vision-priorityInQueue-span"), "onClick_PriorityInQueueDataVision();", SetVisionData);
    }
}

function setTestNotPerformedReasonForVision(testNotPerformed) {
    setTestNotPerformed("testnotPerformedVision", testNotPerformed);
    SetTestNotPerformedEnableDisabled("testnotPerformedVision");
}

function getTestNotPerformedReasonForVision(testNotPerformed) {
    return getTestNotPerformed("testnotPerformedVision", testNotPerformed);
}