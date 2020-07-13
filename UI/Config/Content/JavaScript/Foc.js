function Foc(testResult) {
    if (testResult == null || testResult == undefined) {

        testResult = {
            "Id": 0, "TestType": testTypeFoc,
            //"TotalCholestrol": null, "HDL": null,
            //"LDL": null, "Glucose": null,
            //"TriGlycerides": null, "TCHDLRatio": null,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": '',
            "UnableScreenReason": new Array(),
            "TestPerformedExternally": null,
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": {
                "Id": 0,
                "SelfPresent": $("#SelfPresentFocInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestFocCheck").attr("checked")
            }
        };

    }
    this.Result = testResult;
}

Foc.prototype = {
    setData: function() {
        var testResult = this.Result;
        if (IsfocResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_foccapturebyChat", testResult.TestPerformedExternally)
        }


        $("#technotesfoc").val(testResult.TechnicianNotes);
        $("#conductedbyfoc option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);
        $("#SelfPresentFocInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);
        //$("#PriorityInQueueTestFocCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);

        //if (testResult.ResultStatus.IsPriorityInQueue) {
        //    loadPriorityInQueueLink($("#foc-priorityInQueue-span"), "onClick_PriorityInQueueDataFoc();", testTypeFoc);
        //    if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
        //        $("#foc-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
        //    }
        //}
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#foc-critical-span"), "onClick_CriticalDataFoc();", testTypeFoc);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#foc-critical-span").parent().addClass("red-band");
                $("#criticalFoc").attr("checked", "checked");
            }
        }

        setUnableScreenReason($('.dtl-unable-to-screen-foc'), testResult.UnableScreenReason);

        setTestNotPerformedReasonForFoc(testResult.TestNotPerformed);

        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksFoc").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpFoc").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalFoc").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }
    },
    getData: function() {
        var testResult = this.Result;
        if (IsfocResultEntryExternaly == 'True') {
            testResult.TestPerformedExternally = getTestPerformedExternally("chk_foccapturebyChat", testResult.TestPerformedExternally)
        }

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unable-to-screen-foc')));
        testResult.TestNotPerformed = getTestNotPerformedReasonForFoc(testResult.TestNotPerformed);

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
            testResult.TechnicianNotes = $.trim($("#technotesfoc").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ConductedByOrgRoleUserId = $("#conductedbyfoc option:selected").val();
            testResult.ResultStatus.SelfPresent = $("#SelfPresentFocInputCheck").attr("checked");
            //testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestFocCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_101").attr("checked");

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }

        if (currentScreenMode != ScreenMode.Entry) {
            if (testResult.PhysicianInterpretation == null) {
                testResult.PhysicianInterpretation = {
                    'Remarks': $("#physicianRemarksFoc").val(),
                    'IsCritical': $("#criticalFoc").attr("checked"),
                    'FollowUp': $("#followUpFoc").attr("checked"),
                    'RecorderMetaData': {
                        'DataRecorderCreator': { 'Id': currentUser },
                        'DateCreated': currentDate
                    }
                };
            } else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksFoc").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpFoc").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalFoc").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }


        if (testResult.ResultStatus.StateNumber < 4) {
            if (!(testResult.TechnicianNotes.length > 0 || testResult.ConductedByOrgRoleUserId != "0" ||
                (testResult.UnableScreenReason != null && testResult.UnableScreenReason.length > 0) || $("#SelfPresentFocInputCheck").attr("checked") == true))
                return null;
        }

        return testResult;
    }
};


function setTestNotPerformedReasonForFoc(testNotPerformed) {
    setTestNotPerformed("testnotPerformedFoc", testNotPerformed);
    SetTestNotPerformedEnableDisabled("testnotPerformedFoc");
}

function getTestNotPerformedReasonForFoc(testNotPerformed) {
    return getTestNotPerformed("testnotPerformedFoc", testNotPerformed);
}

function onblurCalculateTCHDLRatio() {
    if ($.trim($("#TotalCholestrolFocInputText").val()).length < 1 ||
            $.trim($("#HDLFocInputText").val()).length < 1) {
        $("#TCHDLRatioFocInputText").val('');
    }
    else if (isNaN($.trim($("#TotalCholestrolFocInputText").val())) == true ||
            isNaN($.trim($("#HDLFocInputText").val())) == true) {
        $("#TCHDLRatioFocInputText").val('');
    }
    else if (Number($.trim($("#TotalCholestrolFocInputText").val())) == 0 ||
            Number($.trim($("#HDLFocInputText").val())) == 0) {
        $("#TCHDLRatioFocInputText").val('');
    }
    else {
        var tcHdlRatio = Number($.trim($("#TotalCholestrolFocInputText").val())) / Number($.trim($("#HDLFocInputText").val()));
        $("#TCHDLRatioFocInputText").val(parseFloat(tcHdlRatio).toFixed(1));
    }

    $("#TCHDLRatioFocInputText").focus();
    $("#TCHDLRatioFocInputText").blur();
}

function onblurCalculateLDL() {
    if ($.trim($("#TotalCholestrolFocInputText").val()).length < 1 || $.trim($("#HDLFocInputText").val()).length < 1 || $.trim($("#TriglyceridesFocInputText").val()).length < 1) {
        $("#LDLFocInputText").val('');
    }
    else if (isNaN($.trim($("#TotalCholestrolFocInputText").val())) == true || isNaN($.trim($("#HDLFocInputText").val())) == true || isNaN($.trim($("#TriglyceridesFocInputText").val())) == true) {
        $("#LDLFocInputText").val('');
    }
    else if (Number($.trim($("#TotalCholestrolFocInputText").val())) == 0 || Number($.trim($("#HDLFocInputText").val())) == 0 || Number($.trim($("#TriglyceridesFocInputText").val())) == 0) {
        $("#LDLFocInputText").val('');
    }
    else {
        var ldl = Number($.trim($("#TotalCholestrolFocInputText").val())) - Number($.trim($("#HDLFocInputText").val())) - (Number($.trim($("#TriglyceridesFocInputText").val())) / 5);
        $("#LDLFocInputText").val(parseFloat(ldl).toFixed(0));
    }

    $("#LDLFocInputText").change();
}


function onChangeTotalCholestrol(TCinput) {
    var tcInputElement = $(TCinput);
    autoSelectFinding($(".tc-foc-finding"), tcInputElement, 1);
    onblurCalculateTCHDLRatio();
    onblurCalculateLDL();
    checkFocTotalCholesterolMinMaxValue(tcInputElement.val());
}

function onChangeHDL(HDLinput) {
    var hdlInputElement = $(HDLinput);
    autoSelectFinding($(".hdl-foc-finding"), hdlInputElement, 1);
    onblurCalculateTCHDLRatio();
    onblurCalculateLDL();
    checkFocHDLMinMaxValue(hdlInputElement.val());
}

function onChangeLdlFoc(ldlFocInput) {
    var ldlFocElement = $(ldlFocInput);
    autoSelectFinding($('.ldl-foc-finding'), ldlFocElement, 1);
    checkFocLDLMinMaxValue(ldlFocElement.val());
}

function onChangeTriglycerides(triglyceridesInput) {
    var triglyceridesElement = $(triglyceridesInput);
    autoSelectFinding($(".triglycerides-foc-finding"), triglyceridesElement, 1);
    onblurCalculateLDL();
    checkFocTriglyceridesMinMaxValue(triglyceridesElement.val());
}

var criticalDataModel_Foc = null;
function onClick_CriticalDataFoc() {
    if ($("#SelfPresentFocInputCheck").attr("checked")) {
        loadCriticalLink($("#foc-critical-span"), "onClick_CriticalDataFoc();", testTypeFoc);
        openCriticalDataDialog(testTypeFoc, $("#conductedbyfoc"), $("#SelfPresentFocInputCheck"), setCriticalDataModel_Foc);
    }
    else {
        unloadCriticalLink($("#foc-critical-span"), testTypeFoc);
    }
}

function setCriticalDataModel_Foc(model, printAfterSave) {
    if (model != null) {
        var testResult = GetFocData();
        saveSingleTestResult(testResult, model, $("#foc-critical-span"), "onClick_CriticalDataFoc();", SetFocData, printAfterSave);
    }
}

function getCriticalDataModel_Foc() {
    if ($("#SelfPresentFocInputCheck").attr("checked") && criticalDataModel_Foc != null) {
        criticalDataModel_Foc.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_Foc;
    }
    return null;
}

function onClick_PriorityInQueueDataFoc() {
    if ($("#PriorityInQueueTestFocCheck").attr("checked")) {
        loadPriorityInQueueLink($("#foc-priorityInQueue-span"), "onClick_PriorityInQueueDataFoc();", testTypeFoc);
        openPriorityInQueueTestDialog(testTypeFoc, $("#conductedbyfoc"), $("#PriorityInQueueTestFocCheck"), setPriorityInQueueDataModel_Foc);
    }
    else {
        unloadPriorityInQueueLink($("#foc-priorityInQueue-span"), testTypeFoc);
    }
}

function setPriorityInQueueDataModel_Foc(model) {
    if (model != null) {
        var testResult = GetFocData();
        model.TestId = testTypeFoc;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#foc-priorityInQueue-span"), "onClick_PriorityInQueueDataFoc();", SetFocData);
    }
}

function checkHdlFindingsForGenderChange(isMale) {
    if ($("#hdlfindingjson").length < 1) return;

    var hdlFindings = null;
    eval("hdlFindings = " + $("#hdlfindingjson").val());
    if (hdlFindings == null) return;

    var gridHdl = $(".hdl-foc-finding");
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
    $("#HDLFocInputText").change();
}


function KeyPress_NumericAllowedOnly_ForFoc(evt) {
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

function clearAllFocSelection() {
    $(".clear-all-foc-selection input[type=radio]").attr("checked", false);
}
