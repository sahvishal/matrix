function Glaucoma(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = {
            "Id": 0, "TestType": testTypeGlaucoma,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": '0',
            "UnableScreenReason": new Array(),
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "TestPerformedExternally": null,
            "ResultStatus": {
                "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentGlaucomaInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestGlaucomaCheck").attr("checked")
            }
        };
    }
    this.Result = testResult;
}

Glaucoma.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (IsglaucomaResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_glaucomacapturebyChat", testResult.TestPerformedExternally)
        }

        if (testResult.AmslerRightEye != null)
            setboolTypeReadingRadioButton($(".amslerRightEye"), testResult.AmslerRightEye);
        if (testResult.AmslerLeftEye != null)
            setboolTypeReadingRadioButton($(".amslerLeftEye"), testResult.AmslerLeftEye);

        if (testResult.RightEyePressure != null)
            setReading($("#RightEyePressureTextBox"), testResult.RightEyePressure);
        if (testResult.LeftEyePressure != null)
            setReading($("#LeftEyePressureTextBox"), testResult.LeftEyePressure);

        $("#DescribeSelfPresentGlaucomaInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);
        $("#PriorityInQueueTestGlaucomaCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#glaucoma-priorityInQueue-span"), "onClick_PriorityInQueueDataGlaucoma();", testTypeGlaucoma);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#glaucoma-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }

        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#glaucoma-critical-span"), "onClick_CriticalDataGlaucoma();", testTypeGlaucoma);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#glaucoma-critical-span").parent().addClass("red-band");
            }
        }

        $("#technotesGlaucoma").val(testResult.TechnicianNotes);
        $("#conductedbyGlaucoma option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);

        setUnableScreenReason($('.dtl-unabletoscreen-Glaucoma'), testResult.UnableScreenReason);

    },
    getData: function () {
        var testResult = this.Result;
        if (IsglaucomaResultEntryExternaly == 'True') {
            testResult.TestPerformedExternally = getTestPerformedExternally("chk_glaucomacapturebyChat", testResult.TestPerformedExternally)
        }

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-Glaucoma')));

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.ConductedByOrgRoleUserId = $("#conductedbyGlaucoma option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesGlaucoma").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentGlaucomaInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestGlaucomaCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_46").attr("checked");

        testResult.AmslerRightEye = getboolTypeReadingRadioButton($(".amslerRightEye"), testResult.AmslerRightEye);
        testResult.AmslerLeftEye = getboolTypeReadingRadioButton($(".amslerLeftEye"), testResult.AmslerLeftEye);

        testResult.RightEyePressure = getReading($("#RightEyePressureTextBox"), testResult.RightEyePressure);
        testResult.LeftEyePressure = getReading($("#LeftEyePressureTextBox"), testResult.LeftEyePressure);


        if (currentScreenMode != ScreenMode.Physician) {

            //testResult.AmslerRightEye = getboolTypeReadingRadioButton($(".amslerRightEye"), testResult.AmslerRightEye);
            //testResult.AmslerLeftEye = getboolTypeReadingRadioButton($(".amslerLeftEye"), testResult.AmslerLeftEye);
            
            //testResult.RightEyePressure = getReading($("#RightEyePressureTextBox"), testResult.RightEyePressure);
            //testResult.LeftEyePressure = getReading($("#LeftEyePressureTextBox"), testResult.LeftEyePressure);

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
            if (testResult.TechnicianNotes.length < 1 && testResult.ConductedByOrgRoleUserId == "0" && testResult.UnableScreenReason == null && $("#DescribeSelfPresentGlaucomaInputCheck").attr("checked") == false
                && testResult.AmslerRightEye == null && testResult.AmslerLeftEye == null && testResult.RightEyePressure == null && testResult.LeftEyePressure == null)
                return null;
        }

        return testResult;
    }
}

var criticalDataModel_Glaucoma = null;
function onClick_CriticalDataGlaucoma() {
    if ($("#DescribeSelfPresentGlaucomaInputCheck").attr("checked")) {
        loadCriticalLink($("#glaucoma-critical-span"), "onClick_CriticalDataGlaucoma();", testTypeGlaucoma);
        openCriticalDataDialog(testTypeGlaucoma, $("#conductedbyGlaucoma"), $("#DescribeSelfPresentGlaucomaInputCheck"), setCriticalDataModel_Glaucoma);
    }
    else {
        unloadCriticalLink($("#glaucoma-critical-span"), testTypeGlaucoma);
    }
}

function setCriticalDataModel_Glaucoma(model, printAfterSave) {
    if (model != null) {
        var testResult = GetGlaucomaData();
        saveSingleTestResult(testResult, model, $("#glaucoma-critical-span"), "onClick_CriticalDataGlaucoma();", SetGlaucomaData, printAfterSave);
    }
}

function getCriticalDataModel_Glaucoma() {
    if ($("#DescribeSelfPresentGlaucomaInputCheck").attr("checked") && criticalDataModel_Glaucoma != null) {
        criticalDataModel_Glaucoma.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_Glaucoma;
    }
    return null;
}

function onClick_PriorityInQueueDataGlaucoma() {
    if ($("#PriorityInQueueTestGlaucomaCheck").attr("checked")) {
        loadPriorityInQueueLink($("#glaucoma-priorityInQueue-span"), "onClick_PriorityInQueueDataGlaucoma();", testTypeGlaucoma);
        openPriorityInQueueTestDialog(testTypeGlaucoma, $("#conductedbyGlaucoma"), $("#PriorityInQueueTestGlaucomaCheck"), setPriorityInQueueDataModel_Glaucoma);
    }
    else {
        unloadPriorityInQueueLink($("#glaucoma-priorityInQueue-span"), testTypeGlaucoma);
    }
}

function setPriorityInQueueDataModel_Glaucoma(model) {
    if (model != null) {
        var testResult = GetGlaucomaData();
        model.TestId = testTypeGlaucoma;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#glaucoma-priorityInQueue-span"), "onClick_PriorityInQueueDataGlaucoma();", SetGlaucomaData);
    }
}