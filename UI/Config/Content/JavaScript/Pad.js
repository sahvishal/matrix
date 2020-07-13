function Pad(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = {
            "LeftResultReadings": { "SystolicArm": null, "SystolicAnkle": null, "ABI": null },
            "RightResultReadings": { "SystolicArm": null, "SystolicAnkle": null, "ABI": null },
            "Id": 0, "TestType": testTypePad,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": 0,
            "Finding": null,
            "UnableScreenReason": new Array(),
            "TestPerformedExternally": null,
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": {
                "Id": 0, "SelfPresent": $("#chkselfPAD").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestPadCheck").attr("checked")
            }
        };
    }
    this.Result = testResult;
}

Pad.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (IspadResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_padcapturebyChat", testResult.TestPerformedExternally)
        }
        if (testResult.LeftResultReadings != null) {
            setReading($("#txtSystolicLeftArm"), testResult.LeftResultReadings.SystolicArm);
            setReading($("#txtSystolicLeftAnkle"), testResult.LeftResultReadings.SystolicAnkle);
            setReading($("#txtLeftAbi"), testResult.LeftResultReadings.ABI);
        }

        if (testResult.RightResultReadings != null) {
            setReading($("#txtSystolicRightArm"), testResult.RightResultReadings.SystolicArm);
            setReading($("#txtSystolicRightAnkle"), testResult.RightResultReadings.SystolicAnkle);
            setReading($("#txtRightAbi"), testResult.RightResultReadings.ABI);
        }

        $("#chkselfPAD").attr("checked", testResult.ResultStatus.SelfPresent);

        if (testResult.Finding != null) {
            setSelectedFinding($(".gv-findings-pad"), testResult.Finding.Id);
        }
        $("#PriorityInQueueTestPadCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#pad-priorityInQueue-span"), "onClick_PriorityInQueueDataPad();", testTypePad);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#pad-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }

        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#pad-critical-span"), "onClick_CriticalDataPad();", testTypePad);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#pad-critical-span").parent().addClass("red-band");
                $("#criticalPad").attr("checked", "checked");
            }
        }

        setUnableScreenReason($('.dtl-unabletoscreen-pad'), testResult.UnableScreenReason);

        setboolTypeReading($('#repeatstudypadinputcheck'), testResult.RepeatStudy);

        $("#technotespad").val(testResult.TechnicianNotes);
        $("#conductedbypad option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);

        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksPad").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpPad").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalPad").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }
    },
    getData: function () {
        var testResult = this.Result;
        if (IspadResultEntryExternaly == 'True') {
            testResult.TestPerformedExternally = getTestPerformedExternally("chk_padcapturebyChat", testResult.TestPerformedExternally)
        }

        var padTestFinding = getSelectedFinding($(".gv-findings-pad"));
        testResult.Finding = getFindingDataandSynchronized(testResult.Finding, padTestFinding);

        if(testResult.Finding != null && testResult.Finding.Id > 0){
            testResult.Finding.WorstCaseOrder = GetWorstCaseOrder(testResult.Finding.Id);
        }

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-pad')));

        if (testResult.RightResultReadings == null) {
            testResult.RightResultReadings = { "SystolicArm": null, "SystolicAnkle": null, "ABI": null };
        }

        if (testResult.LeftResultReadings == null) {
            testResult.LeftResultReadings = { "SystolicArm": null, "SystolicAnkle": null, "ABI": null };
        }

        testResult.RightResultReadings.SystolicArm = getReading($("#txtSystolicRightArm"), testResult.RightResultReadings.SystolicArm);
        testResult.RightResultReadings.SystolicAnkle = getReading($("#txtSystolicRightAnkle"), testResult.RightResultReadings.SystolicAnkle);
        testResult.RightResultReadings.ABI = getReading($("#txtRightAbi"), testResult.RightResultReadings.ABI);

        testResult.LeftResultReadings.SystolicArm = getReading($("#txtSystolicLeftArm"), testResult.LeftResultReadings.SystolicArm);
        testResult.LeftResultReadings.SystolicAnkle = getReading($("#txtSystolicLeftAnkle"), testResult.LeftResultReadings.SystolicAnkle);
        testResult.LeftResultReadings.ABI = getReading($("#txtLeftAbi"), testResult.LeftResultReadings.ABI);

        if (currentScreenMode != ScreenMode.Physician) {
            //if (testResult.RightResultReadings == null) {
            //    testResult.RightResultReadings = { "SystolicArm": null, "SystolicAnkle": null, "ABI": null };
            //}

            //if (testResult.LeftResultReadings == null) {
            //    testResult.LeftResultReadings = { "SystolicArm": null, "SystolicAnkle": null, "ABI": null };
            //}

            //testResult.RightResultReadings.SystolicArm = getReading($("#txtSystolicRightArm"), testResult.RightResultReadings.SystolicArm);
            //testResult.RightResultReadings.SystolicAnkle = getReading($("#txtSystolicRightAnkle"), testResult.RightResultReadings.SystolicAnkle);
            //testResult.RightResultReadings.ABI = getReading($("#txtRightAbi"), testResult.RightResultReadings.ABI);

            //testResult.LeftResultReadings.SystolicArm = getReading($("#txtSystolicLeftArm"), testResult.LeftResultReadings.SystolicArm);
            //testResult.LeftResultReadings.SystolicAnkle = getReading($("#txtSystolicLeftAnkle"), testResult.LeftResultReadings.SystolicAnkle);
            //testResult.LeftResultReadings.ABI = getReading($("#txtLeftAbi"), testResult.LeftResultReadings.ABI);

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
            testResult.TechnicianNotes = $.trim($("#technotespad").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ConductedByOrgRoleUserId = $("#conductedbypad option:selected").val();
            testResult.ResultStatus.SelfPresent = $("#chkselfPAD").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestPadCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_2").attr("checked");

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }

        if (currentScreenMode != ScreenMode.Entry) {

            testResult.RepeatStudy = getboolTypeReading($('#repeatstudypadinputcheck'), testResult.RepeatStudy);

            if (testResult.PhysicianInterpretation == null) {
                testResult.PhysicianInterpretation = { 'Remarks': $("#physicianRemarksPad").val(), 'IsCritical': $("#criticalPad").attr("checked"), 'FollowUp': $("#followUpPad").attr("checked"), 'RecorderMetaData': {
                    'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate
                }
                };
            }
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksPad").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpPad").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalPad").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }

        if (testResult.ResultStatus.StateNumber < 4) {
            if (testResult.UnableScreenReason == null && testResult.Finding == null
                && testResult.LeftResultReadings.ABI == null && testResult.LeftResultReadings.SystolicAnkle == null && testResult.LeftResultReadings.SystolicArm == null
                && testResult.RightResultReadings.SystolicAnkle == null && testResult.RightResultReadings.SystolicArm == null && testResult.RightResultReadings.ABI == null
                && testResult.TechnicianNotes.length < 1 && testResult.ConductedByOrgRoleUserId == "0" && $("#chkselfPAD").attr("checked") == false)
                return null;
        }

        return testResult;
    }
}



$(document).ready(function () {
    $("#txtRightAbi").change(function () { SetOnChangePadValue($(this), $(this).val(), $("#txtLeftAbi").val(), "Right") });
    $("#txtLeftAbi").change(function () { SetOnChangePadValue($(this), $(this).val(), $("#txtRightAbi").val(), "Left") });
});

function SetOnChangePadValue(curentObject, currentObjectValue, otherValue, currentSelection) {
    $(".gv-findings-pad tr").each(function () {
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
        $(".gv-findings-pad tr").each(function () {
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
    $(".gv-findings-pad tr").each(function () {
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

        $(this).find(".rbt-finding-pad").attr("checked", false);

    });

    return findingReference;
}

function GetWorstCaseOrder(findingId) {
    var worstCase = -1;
    $(".gv-findings-pad tr").each(function () {
        if ($(this).find(".finding-id").val() == findingId) {
            worstCase = $(this).find(".finding-worstcaseorder").val();
            return false;
        }
    });

    return worstCase;
}


var criticalDataModel_Pad = null;
function onClick_CriticalDataPad() {
    if ($("#chkselfPAD").attr("checked")) {
        loadCriticalLink($("#pad-critical-span"), "onClick_CriticalDataPad();", testTypePad);
        openCriticalDataDialog(testTypePad, $("#conductedbypad"), $("#chkselfPAD"), setCriticalDataModel_Pad);
    }
    else {
        unloadCriticalLink($("#pad-critical-span"), testTypePad);
    }
}

function setCriticalDataModel_Pad(model, printAfterSave) {
    if (model != null) {
        var testResult = GetPadData();
        saveSingleTestResult(testResult, model, $("#pad-critical-span"), "onClick_CriticalDataPad();", SetPadData, printAfterSave);
    }
}

function getCriticalDataModel_Pad() {
    if ($("#chkselfPAD").attr("checked") && criticalDataModel_Pad != null) {
        criticalDataModel_Pad.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_Pad;
    }
    return null;
}

//pad-critical-span
function onClick_PriorityInQueueDataPad() {
    if ($("#PriorityInQueueTestPadCheck").attr("checked")) {
        loadPriorityInQueueLink($("#pad-priorityInQueue-span"), "onClick_PriorityInQueueDataPad();", testTypePad);
        openPriorityInQueueTestDialog(testTypePad, $("#conductedbypad"), $("#PriorityInQueueTestPadCheck"), setPriorityInQueueDataModel_Pad);
    }
    else {
        unloadPriorityInQueueLink($("#pad-priorityInQueue-span"), testTypePad);
    }
}

function setPriorityInQueueDataModel_Pad(model) {
    if (model != null) {
        var testResult = GetPadData();
        model.TestId = testTypePad;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#pad-priorityInQueue-span"), "onClick_PriorityInQueueDataPad();", SetPadData);
    }
}


function checkPadData() {
    var text = "";

    if ($(".dtl-unabletoscreen-pad").find("input[type='checkbox']:checked").length > 0)
        return text;
    
    var padTestResult = GetPadData();
    if (padTestResult != null) {
        if (padTestResult.RightResultReadings.ABI == null || padTestResult.RightResultReadings.ABI == "")
            text += "Right ABI value is missing.";

        if (padTestResult.LeftResultReadings.ABI == null || padTestResult.LeftResultReadings.ABI == "")
            text += " Left ABI value is missing.";

        if (text != "")
            text = "PAD/ABI Test - " + text;
    }
    return text;
}

function clearAllPadSelection() {
    $(".gv-findings-pad input[type=radio]").attr("checked", false);
}