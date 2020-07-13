function Diabetes(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = {
            "Glucose": null,
            "Id": 0, "TestType": testTypeDiabetes,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": '0',
            "UnableScreenReason": new Array(),
            "TestPerformedExternally": null,
             
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": {
                "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentDiabetesInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestDiabetesCheck").attr("checked")
            }
        };
    }
    this.Result = testResult;
}

Diabetes.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (IsdiabetesResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_DiabetescapturebyChat", testResult.TestPerformedExternally)
        }
        if (testResult.Glucose != null) {
            if (testResult.Glucose.Reading != null)
                $("#GlucoseDiabetesInputText").val(testResult.Glucose.Reading);

            if (testResult.Glucose.Finding != null) {
                setSelectedFinding($(".glucose-Diabetes-finding"), testResult.Glucose.Finding.Id);
            }
        }

        $("#technotesDiabetes").val(testResult.TechnicianNotes);
        $("#conductedbyDiabetes option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);
        $("#DescribeSelfPresentDiabetesInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);
        $("#PriorityInQueueTestDiabetesCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#diabetes-priorityInQueue-span"), "onClick_PriorityInQueueDataDiabetes();", testTypeDiabetes);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#diabetes-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#Diabetes-critical-span"), "onClick_CriticalDataDiabetes();", testTypeDiabetes);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#Diabetes-critical-span").parent().addClass("red-band");
                $("#criticalDiabetes").attr("checked", "checked");
            }
        }

        setUnableScreenReason($('.dtl-unabletoscreen-Diabetes'), testResult.UnableScreenReason);

        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksDiabetes").val(testResult.PhysicianInterpretation.Remarks);
            $("#criticalDiabetes").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }

    },
    getData: function () {
        var testResult = this.Result;
        if (IsdiabetesResultEntryExternaly == 'True') {
            testResult.TestPerformedExternally = getTestPerformedExternally("chk_DiabetescapturebyChat", testResult.TestPerformedExternally)
        }

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-Diabetes')));
        testResult.Glucose = getReading($("#GlucoseDiabetesInputText"), testResult.Glucose);

        if (currentScreenMode != ScreenMode.Physician) {
            
            //testResult.Glucose = getReading($("#GlucoseDiabetesInputText"), testResult.Glucose);

            if (currentScreenMode != ScreenMode.CorrectionPostEvaluation) testResult.ResultStatus.StateNumber = $("#ResultStatusInputHidden").val();

            if (testResult.ResultStatus.Id > 0) {
                testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.ResultStatus.DataRecorderMetaData.DateModified = currentDate;
            }
            else {
                testResult.ResultStatus.DataRecorderMetaData = { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate };
            }
        }

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.ConductedByOrgRoleUserId = $("#conductedbyDiabetes option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesDiabetes").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentDiabetesInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestDiabetesCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_62").attr("checked");

        var gluFinding = getSelectedFinding($(".glucose-Diabetes-finding"));
        if (testResult.Glucose != null) {
            testResult.Glucose.Finding = getFindingDataandSynchronized(testResult.Glucose.Finding, gluFinding);
        }
        else if (gluFinding != null) {
            testResult.Glucose = { 'Finding': getFindingDataandSynchronized(null, gluFinding), "ReadingSource": readingSourceManual, 'RecorderMetaData': { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate } };
        }

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }

        if (currentScreenMode != ScreenMode.Entry) {
            if (testResult.PhysicianInterpretation == null) {
                testResult.PhysicianInterpretation = {
                    'Remarks': $("#physicianRemarksDiabetes").val(), 'IsCritical': $("#criticalDiabetes").attr("checked"), 'RecorderMetaData': {
                        'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate
                    }
                };
            }
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksDiabetes").val();
                testResult.PhysicianInterpretation.IsCritical = $("#criticalDiabetes").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }

        if (testResult.ResultStatus.StateNumber < 4) {
            if (testResult.Glucose != null && testResult.TechnicianNotes.length < 1 && testResult.ConductedByOrgRoleUserId == "0" && testResult.UnableScreenReason == null && $("#DescribeSelfPresentDiabetesInputCheck").attr("checked") == false)
                return null;
        }

        return testResult;
    }
}


var criticalDataModel_Diabetes = null;
function onClick_CriticalDataDiabetes() {
    if ($("#DescribeSelfPresentDiabetesInputCheck").attr("checked")) {
        loadCriticalLink($("#Diabetes-critical-span"), "onClick_CriticalDataDiabetes();", testTypeDiabetes);
        openCriticalDataDialog(testTypeDiabetes, $("#conductedbyDiabetes"), $("#DescribeSelfPresentDiabetesInputCheck"), setcriticalDataModel_Diabetes);
    }
    else {
        unloadCriticalLink($("#Diabetes-critical-span"), testTypeDiabetes);
    }
}

function setcriticalDataModel_Diabetes(model, printAfterSave) {
    if (model != null) {
        var testResult = GetDiabetesData();
        saveSingleTestResult(testResult, model, $("#Diabetes-critical-span"), "onClick_CriticalDataDiabetes();", SetDiabetesData, printAfterSave);
    }
}

function getcriticalDataModel_Diabetes() {
    if ($("#DescribeSelfPresentDiabetesInputCheck").attr("checked") && criticalDataModel_Diabetes != null) {
        criticalDataModel_Diabetes.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_Diabetes;
    }
    return null;
}
function onClick_PriorityInQueueDataDiabetes() {
    if ($("#PriorityInQueueTestDiabetesCheck").attr("checked")) {
        loadPriorityInQueueLink($("#diabetes-priorityInQueue-span"), "onClick_PriorityInQueueDataDiabetes();", testTypeDiabetes);
        openPriorityInQueueTestDialog(testTypeDiabetes, $("#conductedbyDiabetes"), $("#PriorityInQueueTestDiabetesCheck"), setPriorityInQueueDataModel_Diabetes);
    }
    else {
        unloadPriorityInQueueLink($("#diabetes-priorityInQueue-span"), testTypeDiabetes);
    }
}

function setPriorityInQueueDataModel_Diabetes(model) {
    if (model != null) {
        var testResult = GetDiabetesData();
        model.TestId = testTypeDiabetes;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#diabetes-priorityInQueue-span"), "onClick_PriorityInQueueDataDiabetes();", SetDiabetesData);
    }
}
function clearAllDiabetesSelection() {
    $(".clear-all-Diabetes-selection input[type=radio]").attr("checked", false);
}

