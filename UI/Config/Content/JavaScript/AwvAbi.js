function AwvAbi(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = {
            "LeftResultReadings": { "SystolicArm": null, "SystolicAnkle": null, "ABI": null },
            "RightResultReadings": { "SystolicArm": null, "SystolicAnkle": null, "ABI": null },
            "Id": 0, "TestType": testTypeAwvAbi,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": 0,
            "Finding": null,
            "UnableScreenReason": new Array(),
            "TestPerformedExternally": null,
             
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": {
                "Id": 0, "SelfPresent": $("#chkselfAwvAbi").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestAwvAbiCheck").attr("checked")
            }
        };
    }
    this.Result = testResult;
}

AwvAbi.prototype = {
    setData: function () {
        var testResult = this.Result;

        if (IsawvABIResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_awvAbicapturebyChat", testResult.TestPerformedExternally)
        }

        if (testResult.LeftResultReadings != null) {
            setReading($("#txtAwvAbiSystolicLeftArm"), testResult.LeftResultReadings.SystolicArm);
            setReading($("#txtAwvAbiSystolicLeftAnkle"), testResult.LeftResultReadings.SystolicAnkle);
            setReading($("#txtAwvAbiLeftAbi"), testResult.LeftResultReadings.ABI);
        }

        if (testResult.RightResultReadings != null) {
            setReading($("#txtAwvAbiSystolicRightArm"), testResult.RightResultReadings.SystolicArm);
            setReading($("#txtAwvAbiSystolicRightAnkle"), testResult.RightResultReadings.SystolicAnkle);
            setReading($("#txtAwvAbiRightAbi"), testResult.RightResultReadings.ABI);
        }

        $("#chkselfAwvAbi").attr("checked", testResult.ResultStatus.SelfPresent);

        if (testResult.Finding != null) {
            setSelectedFinding($(".gv-findings-AwvAbi"), testResult.Finding.Id);
        }
        $("#PriorityInQueueTestAwvAbiCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#awvAbi-priorityInQueue-span"), "onClick_PriorityInQueueDataAwvAbi();", testTypeAwvAbi);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#awvAbi-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#AwvAbi-critical-span"), "onClick_CriticalDataAwvAbi();", testTypeAwvAbi);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#AwvAbi-critical-span").parent().addClass("red-band");
                $("#criticalAwvAbi").attr("checked", "checked");
            }
        }

        setUnableScreenReason($('.dtl-unabletoscreen-AwvAbi'), testResult.UnableScreenReason);

        setTestNotPerformedReasonForAwvAbi(testResult.TestNotPerformed);

        setboolTypeReading($('#repeatstudyAwvAbiinputcheck'), testResult.RepeatStudy);

        $("#technotesAwvAbi").val(testResult.TechnicianNotes);
        $("#conductedbyAwvAbi option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);

        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksAwvAbi").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpAwvAbi").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalAwvAbi").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }
    },
    getData: function () {
        var testResult = this.Result;

        if (IsawvABIResultEntryExternaly == 'True') {
            testResult.TestPerformedExternally = getTestPerformedExternally("chk_awvAbicapturebyChat", testResult.TestPerformedExternally)
        }

        var padTestFinding = getSelectedFinding($(".gv-findings-AwvAbi"));
        testResult.Finding = getFindingDataandSynchronized(testResult.Finding, padTestFinding);

        if(testResult.Finding != null && testResult.Finding.Id > 0){
            testResult.Finding.WorstCaseOrder = GetWorstCaseOrder(testResult.Finding.Id);
        }

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-AwvAbi')));

        testResult.TestNotPerformed = getTestNotPerformedReasonForAwvAbi(testResult.TestNotPerformed);

        if (testResult.RightResultReadings == null) {
            testResult.RightResultReadings = { "SystolicArm": null, "SystolicAnkle": null, "ABI": null };
        }

        if (testResult.LeftResultReadings == null) {
            testResult.LeftResultReadings = { "SystolicArm": null, "SystolicAnkle": null, "ABI": null };
        }

        testResult.RightResultReadings.SystolicArm = getReading($("#txtAwvAbiSystolicRightArm"), testResult.RightResultReadings.SystolicArm);
        testResult.RightResultReadings.SystolicAnkle = getReading($("#txtAwvAbiSystolicRightAnkle"), testResult.RightResultReadings.SystolicAnkle);
        testResult.RightResultReadings.ABI = getReading($("#txtAwvAbiRightAbi"), testResult.RightResultReadings.ABI);

        testResult.LeftResultReadings.SystolicArm = getReading($("#txtAwvAbiSystolicLeftArm"), testResult.LeftResultReadings.SystolicArm);
        testResult.LeftResultReadings.SystolicAnkle = getReading($("#txtAwvAbiSystolicLeftAnkle"), testResult.LeftResultReadings.SystolicAnkle);
        testResult.LeftResultReadings.ABI = getReading($("#txtAwvAbiLeftAbi"), testResult.LeftResultReadings.ABI);


        if (currentScreenMode != ScreenMode.Physician) {
            //if (testResult.RightResultReadings == null) {
            //    testResult.RightResultReadings = { "SystolicArm": null, "SystolicAnkle": null, "ABI": null };
            //}

            //if (testResult.LeftResultReadings == null) {
            //    testResult.LeftResultReadings = { "SystolicArm": null, "SystolicAnkle": null, "ABI": null };
            //}

            //testResult.RightResultReadings.SystolicArm = getReading($("#txtAwvAbiSystolicRightArm"), testResult.RightResultReadings.SystolicArm);
            //testResult.RightResultReadings.SystolicAnkle = getReading($("#txtAwvAbiSystolicRightAnkle"), testResult.RightResultReadings.SystolicAnkle);
            //testResult.RightResultReadings.ABI = getReading($("#txtAwvAbiRightAbi"), testResult.RightResultReadings.ABI);

            //testResult.LeftResultReadings.SystolicArm = getReading($("#txtAwvAbiSystolicLeftArm"), testResult.LeftResultReadings.SystolicArm);
            //testResult.LeftResultReadings.SystolicAnkle = getReading($("#txtAwvAbiSystolicLeftAnkle"), testResult.LeftResultReadings.SystolicAnkle);
            //testResult.LeftResultReadings.ABI = getReading($("#txtAwvAbiLeftAbi"), testResult.LeftResultReadings.ABI);

            if (currentScreenMode != ScreenMode.CorrectionPostEvaluation && currentScreenMode != ScreenMode.PostAudit) testResult.ResultStatus.StateNumber = $("#ResultStatusInputHidden").val();

            if (testResult.ResultStatus.Id > 0) {
                testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.ResultStatus.DataRecorderMetaData.DateModified = currentDate;
            }
            else {
                testResult.ResultStatus.DataRecorderMetaData = { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate };
            }
        }

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.TechnicianNotes = $.trim($("#technotesAwvAbi").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ConductedByOrgRoleUserId = $("#conductedbyAwvAbi option:selected").val();
            testResult.ResultStatus.SelfPresent = $("#chkselfAwvAbi").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestAwvAbiCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_53").attr("checked");

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }

        if (currentScreenMode != ScreenMode.Entry) {

            testResult.RepeatStudy = getboolTypeReading($('#repeatstudyAwvAbiinputcheck'), testResult.RepeatStudy);

            if (testResult.PhysicianInterpretation == null) {
                testResult.PhysicianInterpretation = {
                    'Remarks': $("#physicianRemarksAwvAbi").val(), 'IsCritical': $("#criticalAwvAbi").attr("checked"), 'FollowUp': $("#followUpAwvAbi").attr("checked"), 'RecorderMetaData': {
                    'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate
                }
                };
            }
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksAwvAbi").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpAwvAbi").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalAwvAbi").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }

        if (testResult.ResultStatus.StateNumber < 4) {
            if (testResult.UnableScreenReason == null && testResult.Finding == null
                && testResult.LeftResultReadings.ABI == null && testResult.LeftResultReadings.SystolicAnkle == null && testResult.LeftResultReadings.SystolicArm == null
                && testResult.RightResultReadings.SystolicAnkle == null && testResult.RightResultReadings.SystolicArm == null && testResult.RightResultReadings.ABI == null
                && testResult.TechnicianNotes.length < 1 && testResult.ConductedByOrgRoleUserId == "0" && $("#chkselfAwvAbi").attr("checked") == false)
                return null;
        }

        return testResult;
    }
}



$(document).ready(function () {
    $("#txtAwvAbiRightAbi").change(function () { SetOnChangeAwvAbiValue($(this), $(this).val(), $("#txtAwvAbiLeftAbi").val(), "Right") });
    $("#txtAwvAbiLeftAbi").change(function () { SetOnChangeAwvAbiValue($(this), $(this).val(), $("#txtAwvAbiRightAbi").val(), "Left") });
});

function SetOnChangeAwvAbiValue(curentObject, currentObjectValue, otherValue, currentSelection) {
    $(".gv-findings-AwvAbi tr").each(function () {
        $(this).find(".rbt-finding").attr("checked", false);
    });

    if ($.trim(currentObjectValue).length < 1 && $.trim(otherValue).length < 1)
        return;

    var rightAbiValue = '';
    var leftAbiValue = '';

    if (currentSelection == "Right") {
        var rightAbiValue = currentObjectValue;
        var leftAbiValue = otherValue;
    }
    else if (currentSelection == "Left") {
        var rightAbiValue = otherValue;
        var leftAbiValue = currentObjectValue;
    }

    var comparisonString = '';

    if ($.trim(rightAbiValue).length < 1) rightAbiValue = '0.95';

    if ($.trim(leftAbiValue).length < 1) leftAbiValue = '0.95';

    var findingSelectionForLeftAbi, findingSelectionForRightAbi;
    findingSelectionForRightAbi = GetFindingReference(rightAbiValue);
    findingSelectionForLeftAbi = GetFindingReference(leftAbiValue);

    var findingToConsider = GetFindingToConsider(findingSelectionForLeftAbi, findingSelectionForRightAbi);
    if (findingToConsider != null) {
        $(".gv-findings-AwvAbi tr").each(function () {
            if ($(this).find(".finding-id").val() == findingToConsider) {
                $(this).find(".rbt-finding").attr("checked", true);
            }
        });
    }
}

function GetFindingToConsider(findingSelectionForLeftAbi, findingSelectionForRightAbi) {
    if (findingSelectionForLeftAbi == null && findingSelectionForRightAbi == null)
        return null;

    var worstCaseLeft = findingSelectionForLeftAbi != null ? GetWorstCaseOrder(Number(findingSelectionForLeftAbi)) : -1;
    var worstCaseRight = findingSelectionForRightAbi != null ? GetWorstCaseOrder(Number(findingSelectionForRightAbi)) : -1;

    if(worstCaseLeft == worstCaseRight && worstCaseLeft == -1) return null;

    return (worstCaseLeft > worstCaseRight ? findingSelectionForLeftAbi : findingSelectionForRightAbi);
}

function GetFindingReference(readingVal) {
    readingVal = parseFloat(readingVal).toFixed(2);

    var findingReference = null;
    $(".gv-findings-AwvAbi tr").each(function () {
        var minValue = $(this).find(".finding-minvalue").val();
        var maxValue = $(this).find(".finding-maxvalue").val();

        if (minValue.length > 0 && maxValue.length > 0) {
            if (Number(readingVal) >= Number(minValue) && Number(readingVal) <= Number(maxValue)) {
                findingReference = $(this).find(".finding-id").val();
                return;
            }
        }
        else if (minValue.length > 0) {
            if (Number(readingVal) >= Number(minValue)) {
                findingReference = $(this).find(".finding-id").val();
                return;
            }
        }
        else if (maxValue.length > 0) {
            if (Number(readingVal) <= Number(maxValue)) {
                findingReference = $(this).find(".finding-id").val();
                return;
            }
        }

        $(this).find(".rbt-finding-AwvAbi").attr("checked", false);

    });

    return findingReference;
}

function GetWorstCaseOrder(findingId) {
    var worstCase = -1;
    $(".gv-findings-AwvAbi tr").each(function () {
        if ($(this).find(".finding-id").val() == findingId) {
            worstCase = $(this).find(".finding-worstcaseorder").val();
            return false;
        }
    });

    return worstCase;
}


var criticalDataModel_AwvAbi = null;
function onClick_CriticalDataAwvAbi() {
    if ($("#chkselfAwvAbi").attr("checked")) {
        loadCriticalLink($("#AwvAbi-critical-span"), "onClick_CriticalDataAwvAbi();", testTypeAwvAbi);
        openCriticalDataDialog(testTypeAwvAbi, $("#conductedbyAwvAbi"), $("#chkselfAwvAbi"), setCriticalDataModel_AwvAbi);
    }
    else {
        unloadCriticalLink($("#AwvAbi-critical-span"), testTypeAwvAbi);
    }
}

function setCriticalDataModel_AwvAbi(model, printAfterSave) {
    if (model != null) {
        var testResult = GetAwvAbiData();
        saveSingleTestResult(testResult, model, $("#AwvAbi-critical-span"), "onClick_CriticalDataAwvAbi();", SetAwvAbiData, printAfterSave);
    }
}

function getCriticalDataModel_AwvAbi() {
    if ($("#chkselfAwvAbi").attr("checked") && criticalDataModel_AwvAbi != null) {
        criticalDataModel_AwvAbi.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_AwvAbi;
    }
    return null;
}

//pad-critical-span
function onClick_PriorityInQueueDataAwvAbi() {
    if ($("#PriorityInQueueTestAwvAbiCheck").attr("checked")) {
        loadPriorityInQueueLink($("#awvAbi-priorityInQueue-span"), "onClick_PriorityInQueueDataAwvAbi();", testTypeAwvAbi);
        openPriorityInQueueTestDialog(testTypeAwvAbi, $("#conductedbyAwvAbi"), $("#PriorityInQueueTestAwvAbiCheck"), setPriorityInQueueDataModel_AwvAbi);
    }
    else {
        unloadPriorityInQueueLink($("#awvAbi-priorityInQueue-span"), testTypeAwvAbi);
    }
}

function setPriorityInQueueDataModel_AwvAbi(model) {
    if (model != null) {
        var testResult = GetAwvAbiData();
        model.TestId = testTypeAwvAbi;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#awvAbi-priorityInQueue-span"), "onClick_PriorityInQueueDataAwvAbi();", SetAwvAbiData);
    }
}


function checkAwvAbiData() {
    var text = "";

    if ($(".dtl-unabletoscreen-AwvAbi").find("input[type='checkbox']:checked").length > 0)
        return text;
    
    if ($("#testnotPerformedAwvAbi").find(".test-not-performed-container:visible").length > 0)
        return text;
    
    var awvAbiTestResult = GetAwvAbiData();
    if (awvAbiTestResult != null) {
        if (awvAbiTestResult.RightResultReadings.ABI == null || awvAbiTestResult.RightResultReadings.ABI == "")
            text += "Right ABI value is missing.";

        if (awvAbiTestResult.LeftResultReadings.ABI == null || awvAbiTestResult.LeftResultReadings.ABI == "")
            text += " Left ABI value is missing.";

        if (text != "")
            text = "PAD/ABI Test - " + text;
    }
    return text;
}

function clearAllAwvAbiSelection() {
    $(".gv-findings-AwvAbi input[type=radio]").attr("checked", false);
}


function setTestNotPerformedReasonForAwvAbi(testNotPerformed) {
    setTestNotPerformed("testnotPerformedAwvAbi", testNotPerformed);
    SetTestNotPerformedEnableDisabled("testnotPerformedAwvAbi");
}

function getTestNotPerformedReasonForAwvAbi(testNotPerformed) {
    return getTestNotPerformed("testnotPerformedAwvAbi", testNotPerformed);
}