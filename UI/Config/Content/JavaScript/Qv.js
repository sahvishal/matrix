function Qv(testResult) {
    if (testResult == null || testResult == undefined) {

        testResult = {
            "Id": 0, "TestType": testTypeQv,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": '',
            "UnableScreenReason": new Array(),
            "TestPerformedExternally": null,
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": {
                "Id": 0,
                "SelfPresent": $("#SelfPresentQvInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestQvCheck").attr("checked")
            }
        };

    }
    this.Result = testResult;
}

Qv.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (IsqvResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_qvcapturebyChat", testResult.TestPerformedExternally)
        }


        $("#technotesqv").val(testResult.TechnicianNotes);
        $("#conductedbyqv option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);
        $("#SelfPresentQvInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);

        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#qv-critical-span"), "onClick_CriticalDataQv();", testTypeQv);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#qv-critical-span").parent().addClass("red-band");
                $("#criticalQv").attr("checked", "checked");
            }
        }

        setUnableScreenReason($('.dtl-unable-to-screen-qv'), testResult.UnableScreenReason);

        setTestNotPerformedReasonForQv(testResult.TestNotPerformed);

        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksQv").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpQv").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalQv").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }
    },
    getData: function () {
        var testResult = this.Result;
        if (IsqvResultEntryExternaly == 'True') {
            testResult.TestPerformedExternally = getTestPerformedExternally("chk_qvcapturebyChat", testResult.TestPerformedExternally)
        }

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unable-to-screen-qv')));
        testResult.TestNotPerformed = getTestNotPerformedReasonForQv(testResult.TestNotPerformed);

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
            testResult.TechnicianNotes = $.trim($("#technotesqv").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ConductedByOrgRoleUserId = $("#conductedbyqv option:selected").val();
            testResult.ResultStatus.SelfPresent = $("#SelfPresentQvInputCheck").attr("checked");
            //testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestQvCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_102").attr("checked");

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }

        if (currentScreenMode != ScreenMode.Entry) {
            if (testResult.PhysicianInterpretation == null) {
                testResult.PhysicianInterpretation = {
                    'Remarks': $("#physicianRemarksQv").val(),
                    'IsCritical': $("#criticalQv").attr("checked"),
                    'FollowUp': $("#followUpQv").attr("checked"),
                    'RecorderMetaData': {
                        'DataRecorderCreator': { 'Id': currentUser },
                        'DateCreated': currentDate
                    }
                };
            } else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksQv").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpQv").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalQv").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }


        if (testResult.ResultStatus.StateNumber < 4) {
            if (!(testResult.TechnicianNotes.length > 0 || testResult.ConductedByOrgRoleUserId != "0" ||
                (testResult.UnableScreenReason != null && testResult.UnableScreenReason.length > 0) || $("#SelfPresentQvInputCheck").attr("checked") == true))
                return null;
        }

        return testResult;
    }
};


function setTestNotPerformedReasonForQv(testNotPerformed) {
    setTestNotPerformed("testnotPerformedQv", testNotPerformed);
    SetTestNotPerformedEnableDisabled("testnotPerformedQv");
}

function getTestNotPerformedReasonForQv(testNotPerformed) {
    return getTestNotPerformed("testnotPerformedQv", testNotPerformed);
}

var criticalDataModel_Qv = null;
function onClick_CriticalDataQv() {
    if ($("#SelfPresentQvInputCheck").attr("checked")) {
        loadCriticalLink($("#qv-critical-span"), "onClick_CriticalDataQv();", testTypeQv);
        openCriticalDataDialog(testTypeQv, $("#conductedbyqv"), $("#SelfPresentQvInputCheck"), setCriticalDataModel_Qv);
    }
    else {
        unloadCriticalLink($("#qv-critical-span"), testTypeQv);
    }
}

function setCriticalDataModel_Qv(model, printAfterSave) {
    if (model != null) {
        var testResult = GetQvData();
        saveSingleTestResult(testResult, model, $("#qv-critical-span"), "onClick_CriticalDataQv();", SetQvData, printAfterSave);
    }
}

function getCriticalDataModel_Qv() {
    if ($("#SelfPresentQvInputCheck").attr("checked") && criticalDataModel_Qv != null) {
        criticalDataModel_Qv.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_Qv;
    }
    return null;
}

function onClick_PriorityInQueueDataQv() {
    if ($("#PriorityInQueueTestQvCheck").attr("checked")) {
        loadPriorityInQueueLink($("#qv-priorityInQueue-span"), "onClick_PriorityInQueueDataQv();", testTypeQv);
        openPriorityInQueueTestDialog(testTypeQv, $("#conductedbyqv"), $("#PriorityInQueueTestQvCheck"), setPriorityInQueueDataModel_Qv);
    }
    else {
        unloadPriorityInQueueLink($("#qv-priorityInQueue-span"), testTypeQv);
    }
}

function setPriorityInQueueDataModel_Qv(model) {
    if (model != null) {
        var testResult = GetQvData();
        model.TestId = testTypeQv;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#qv-priorityInQueue-span"), "onClick_PriorityInQueueDataQv();", SetQvData);
    }
}

function checkHdlFindingsForGenderChange(isMale) {
    if ($("#hdlfindingjson").length < 1) return;

    var hdlFindings = null;
    eval("hdlFindings = " + $("#hdlfindingjson").val());
    if (hdlFindings == null) return;

    var gridHdl = $(".hdl-qv-finding");
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
    $("#HDLQvInputText").change();
}


function KeyPress_NumericAllowedOnly_ForQv(evt) {
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

function clearAllQvSelection() {
    $(".clear-all-qv-selection input[type=radio]").attr("checked", false);
}
