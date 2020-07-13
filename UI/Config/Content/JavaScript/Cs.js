function Cs(testResult) {
    if (testResult == null || testResult == undefined) {

        testResult = {
            "Id": 0, "TestType": testTypeCs,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": '',
            "UnableScreenReason": new Array(),
            "TestPerformedExternally": null,
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": {
                "Id": 0,
                "SelfPresent": $("#SelfPresentCsInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestCsCheck").attr("checked")
            }
        };

    }
    this.Result = testResult;
}

Cs.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (IscsResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_cscapturebyChat", testResult.TestPerformedExternally)
        }


        $("#technotescs").val(testResult.TechnicianNotes);
        $("#conductedbycs option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);
        $("#SelfPresentCsInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);

        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#cs-critical-span"), "onClick_CriticalDataCs();", testTypeCs);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#cs-critical-span").parent().addClass("red-band");
                $("#criticalCs").attr("checked", "checked");
            }
        }

        setUnableScreenReason($('.dtl-unable-to-screen-cs'), testResult.UnableScreenReason);

        setTestNotPerformedReasonForCs(testResult.TestNotPerformed);

        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksCs").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpCs").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalCs").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }
    },
    getData: function () {
        var testResult = this.Result;
        if (IscsResultEntryExternaly == 'True') {
            testResult.TestPerformedExternally = getTestPerformedExternally("chk_cscapturebyChat", testResult.TestPerformedExternally)
        }

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unable-to-screen-cs')));
        testResult.TestNotPerformed = getTestNotPerformedReasonForCs(testResult.TestNotPerformed);

        if (currentScreenMode != ScreenMode.Physician) {

            if (currentScreenMode != ScreenMode.CorrectionPostEvaluation) testResult.ResultStatus.StateNumber = $("#ResultStatusInputHidden").val();

            if (testResult.ResultStatus.Id > 0) {
                testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.ResultStatus.DataRecorderMetaData.DateModified = currentDate;
            } else {
                testResult.ResultStatus.DataRecorderMetaData = { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate };
            }
        }

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.TechnicianNotes = $.trim($("#technotescs").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ConductedByOrgRoleUserId = $("#conductedbycs option:selected").val();
            testResult.ResultStatus.SelfPresent = $("#SelfPresentCsInputCheck").attr("checked");
            //testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestCsCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_102").attr("checked");

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }

        if (currentScreenMode != ScreenMode.Entry) {
            if (testResult.PhysicianInterpretation == null) {
                testResult.PhysicianInterpretation = {
                    'Remarks': $("#physicianRemarksCs").val(),
                    'IsCritical': $("#criticalCs").attr("checked"),
                    'FollowUp': $("#followUpCs").attr("checked"),
                    'RecorderMetaData': {
                        'DataRecorderCreator': { 'Id': currentUser },
                        'DateCreated': currentDate
                    }
                };
            } else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksCs").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpCs").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalCs").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }


        if (testResult.ResultStatus.StateNumber < 4) {
            if (!(testResult.TechnicianNotes.length > 0 || testResult.ConductedByOrgRoleUserId != "0" ||
                (testResult.UnableScreenReason != null && testResult.UnableScreenReason.length > 0) || $("#SelfPresentCsInputCheck").attr("checked") == true))
                return null;
        }

        return testResult;
    }
};


function setTestNotPerformedReasonForCs(testNotPerformed) {
    setTestNotPerformed("testnotPerformedCs", testNotPerformed);
    SetTestNotPerformedEnableDisabled("testnotPerformedCs");
}

function getTestNotPerformedReasonForCs(testNotPerformed) {
    return getTestNotPerformed("testnotPerformedCs", testNotPerformed);
}

var criticalDataModel_Cs = null;
function onClick_CriticalDataCs() {
    if ($("#SelfPresentCsInputCheck").attr("checked")) {
        loadCriticalLink($("#cs-critical-span"), "onClick_CriticalDataCs();", testTypeCs);
        openCriticalDataDialog(testTypeCs, $("#conductedbycs"), $("#SelfPresentCsInputCheck"), setCriticalDataModel_Cs);
    }
    else {
        unloadCriticalLink($("#cs-critical-span"), testTypeCs);
    }
}

function setCriticalDataModel_Cs(model, printAfterSave) {
    if (model != null) {
        var testResult = GetCsData();
        saveSingleTestResult(testResult, model, $("#cs-critical-span"), "onClick_CriticalDataCs();", SetCsData, printAfterSave);
    }
}

function getCriticalDataModel_Cs() {
    if ($("#SelfPresentCsInputCheck").attr("checked") && criticalDataModel_Cs != null) {
        criticalDataModel_Cs.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_Cs;
    }
    return null;
}

function onClick_PriorityInQueueDataCs() {
    if ($("#PriorityInQueueTestCsCheck").attr("checked")) {
        loadPriorityInQueueLink($("#cs-priorityInQueue-span"), "onClick_PriorityInQueueDataCs();", testTypeCs);
        openPriorityInQueueTestDialog(testTypeCs, $("#conductedbycs"), $("#PriorityInQueueTestCsCheck"), setPriorityInQueueDataModel_Cs);
    }
    else {
        unloadPriorityInQueueLink($("#cs-priorityInQueue-span"), testTypeCs);
    }
}

function setPriorityInQueueDataModel_Cs(model) {
    if (model != null) {
        var testResult = GetCsData();
        model.TestId = testTypeCs;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#cs-priorityInQueue-span"), "onClick_PriorityInQueueDataCs();", SetCsData);
    }
}

function checkHdlFindingsForGenderChange(isMale) {
    if ($("#hdlfindingjson").length < 1) return;

    var hdlFindings = null;
    eval("hdlFindings = " + $("#hdlfindingjson").val());
    if (hdlFindings == null) return;

    var gridHdl = $(".hdl-cs-finding");
    gridHdl.find('input[type=radio]').attr("checked", false);

    var count = 0;
    var toCheckFor = isMale ? "male - " : "female - ";

    for (var i = 0; i < hdlFindings.length; i++) {
        var finding = hdlFindings[i];
        if (finding.Label.toLowerCase().indexOf(toCheckFor) == 0) {
            var row = $(gridHdl.find("tr")[count]);
            row.find(".finding-id").val(finding.Id);
            row.find(".finding-minvalue").val(finding.MinValue);
            row.find(".finding-maxvalue").val(finding.MaxValue);

            var cell = $(row.find("td")[1]);
            cell.empty();
            cell.text(finding.Label.substring(toCheckFor.length - 1, finding.Label.length) + " " + finding.Description);
            count++;
        }
    }
    $("#HDLCsInputText").change();
}


function KeyPress_NumericAllowedOnly_ForCs(evt) {
    var key = (evt.which ? evt.which : ((evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : 0)));
    var InpObject = evt.currentTarget ? evt.currentTarget : evt.srcElement;

    var valarray = InpObject.value.split('');
    var bolContainsSign = false;
    var count = 0;
    while (count < valarray.length) {
        if (valarray[count] == "<" || valarray[count] == ">") {
            bolContainsSign = true;
            break;
        }
        count++;
    }

    var selIndex = getSelectionStart(InpObject);
    if (((key >= 48 && key <= 57 && (bolContainsSign == false || (selIndex > 0 && bolContainsSign == true))) || key == 9 || key == 13 || key == 8 || (key >= 37 && key <= 40)
                || (key >= 96 && key <= 105 && (bolContainsSign == false || (selIndex > 0 && bolContainsSign == true)))) && (evt.shiftKey == false)) {
        return true;
    }

    if ((key == 190 || key == 188) && selIndex == 0 && evt.shiftKey == true) {
        if (bolContainsSign == true)
            return false;

        return true;

    }
    return false;
}

function clearAllCsSelection() {
    $(".clear-all-cs-selection input[type=radio]").attr("checked", false);
}
