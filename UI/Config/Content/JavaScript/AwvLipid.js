function AwvLipid(testResult) {
    if (testResult == null || testResult == undefined) {

        testResult = {
            "Id": 0, "TestType": testTypeAwvLipid,
            "TotalCholestrol": null, "HDL": null,
            "LDL": null, 
            "TriGlycerides": null, "TCHDLRatio": null,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": '',
            "UnableScreenReason": new Array(),
            "TestPerformedExternally": null,
             
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": {
                "Id": 0,
                "SelfPresent": $("#SelfPresentAwvLipidInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestAwvLipidCheck").attr("checked")
            }
        };

    }
    this.Result = testResult;
}

AwvLipid.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (IsawvLipidResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_awvLipidcapturebyChat", testResult.TestPerformedExternally)
        }

        if (testResult.TotalCholestrol != null) {
            if (testResult.TotalCholestrol.Reading != null) {
                $("#TotalCholestrolAwvLipidInputText").val(testResult.TotalCholestrol.Reading);
            }

            if (testResult.TotalCholestrol.Finding != null) {
                setSelectedFinding($(".tc-AwvLipid-finding"), testResult.TotalCholestrol.Finding.Id);
            }
        }

        

        if (testResult.HDL != null) {
            if (testResult.HDL.Reading != null) {
                $("#HDLAwvLipidInputText").val(testResult.HDL.Reading);
            }

            if (testResult.HDL.Finding != null) {
                setSelectedFinding($(".hdl-AwvLipid-finding"), testResult.HDL.Finding.Id);
            }
        }

        if (testResult.TriGlycerides != null) {
            if (testResult.TriGlycerides.Reading != null) {
                $("#TriglyceridesAwvLipidInputText").val(testResult.TriGlycerides.Reading);
            }

            if (testResult.TriGlycerides.Finding != null) {
                setSelectedFinding($(".triglycerides-AwvLipid-finding"), testResult.TriGlycerides.Finding.Id);
            }
        }

        if (testResult.LDL != null) {
            if (testResult.LDL.Reading != null) {
                $("#LDLAwvLipidInputText").val(testResult.LDL.Reading);
            }

            if (testResult.LDL.Finding != null) {
                setSelectedFinding($(".ldl-AwvLipid-finding"), testResult.LDL.Finding.Id);
            }
        }


        if (testResult.TCHDLRatio != null) {

            if (testResult.TCHDLRatio.Reading != null)
                $("#TCHDLRatioAwvLipidInputText").val(parseFloat(testResult.TCHDLRatio.Reading).toFixed(1));

            if (testResult.TCHDLRatio.Finding != null) {
                setSelectedFinding($(".tchdlratio-AwvLipid-finding"), testResult.TCHDLRatio.Finding.Id);
            }
        }

        $("#technotesAwvLipid").val(testResult.TechnicianNotes);
        $("#conductedbyAwvLipid option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);
        $("#SelfPresentAwvLipidInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);

        $("#PriorityInQueueTestAwvLipidCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#awvLipid-priorityInQueue-span"), "onClick_PriorityInQueueDataAwvLipid();", testTypeAwvLipid);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#awvLipid-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#AwvLipid-critical-span"), "onClick_CriticalDataAwvLipid();", testTypeAwvLipid);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#AwvLipid-critical-span").parent().addClass("red-band");
                $("#criticalAwvLipid").attr("checked", "checked");
            }
        }
        setUnableScreenReason($('.dtl-unable-to-screen-AwvLipid'), testResult.UnableScreenReason);

        setTestNotPerformedReasonForAwvLipid(testResult.TestNotPerformed);

        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksAwvLipid").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpAwvLipid").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalAwvLipid").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }
    },
    getData: function () {
        var testResult = this.Result;
        if (IsawvLipidResultEntryExternaly == 'True') {
            testResult.TestPerformedExternally = getTestPerformedExternally("chk_awvLipidcapturebyChat", testResult.TestPerformedExternally)
        }

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unable-to-screen-AwvLipid')));
        
        testResult.TestNotPerformed = getTestNotPerformedReasonForAwvLipid(testResult.TestNotPerformed);
        
        testResult.TotalCholestrol = getReading($("#TotalCholestrolAwvLipidInputText"), testResult.TotalCholestrol);
        testResult.HDL = getReading($("#HDLAwvLipidInputText"), testResult.HDL);

        testResult.TriGlycerides = getReading($("#TriglyceridesAwvLipidInputText"), testResult.TriGlycerides);
        testResult.LDL = getReading($("#LDLAwvLipidInputText"), testResult.LDL);
        testResult.TCHDLRatio = getReading($("#TCHDLRatioAwvLipidInputText"), testResult.TCHDLRatio);

        if (currentScreenMode != ScreenMode.Physician) {
            //testResult.TotalCholestrol = getReading($("#TotalCholestrolAwvLipidInputText"), testResult.TotalCholestrol);
            //testResult.HDL = getReading($("#HDLAwvLipidInputText"), testResult.HDL);
            
            //testResult.TriGlycerides = getReading($("#TriglyceridesAwvLipidInputText"), testResult.TriGlycerides);
            //testResult.LDL = getReading($("#LDLAwvLipidInputText"), testResult.LDL);
            //testResult.TCHDLRatio = getReading($("#TCHDLRatioAwvLipidInputText"), testResult.TCHDLRatio);

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
            testResult.TechnicianNotes = $.trim($("#technotesAwvLipid").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ConductedByOrgRoleUserId = $("#conductedbyAwvLipid option:selected").val();
            testResult.ResultStatus.SelfPresent = $("#SelfPresentAwvLipidInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestAwvLipidCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_57").attr("checked");

        var tcFinding = getSelectedFinding($(".tc-AwvLipid-finding"));
        if (testResult.TotalCholestrol != null) {
            testResult.TotalCholestrol.Finding = getFindingDataandSynchronized(testResult.TotalCholestrol.Finding, tcFinding);
        }
        else if (tcFinding != null) {
            testResult.TotalCholestrol = { 'Finding': getFindingDataandSynchronized(null, tcFinding), "ReadingSource": readingSourceManual, 'RecorderMetaData': { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate } };
        }

        var hdlFinding = getSelectedFinding($(".hdl-AwvLipid-finding"));
        if (testResult.HDL != null) {
            testResult.HDL.Finding = getFindingDataandSynchronized(testResult.HDL.Finding, hdlFinding);
        }
        else if (hdlFinding != null) {
            testResult.HDL = { 'Finding': getFindingDataandSynchronized(null, hdlFinding), "ReadingSource": readingSourceManual, 'RecorderMetaData': { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate } };
        }

        var tGlyFinding = getSelectedFinding($(".triglycerides-AwvLipid-finding"));
        if (testResult.TriGlycerides != null) {
            testResult.TriGlycerides.Finding = getFindingDataandSynchronized(testResult.TriGlycerides.Finding, tGlyFinding);
        }
        else if (tGlyFinding != null) {
            testResult.TriGlycerides = { 'Finding': getFindingDataandSynchronized(null, tGlyFinding), "ReadingSource": readingSourceManual, 'RecorderMetaData': { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate } };
        }

        var ldlFinding = getSelectedFinding($(".ldl-AwvLipid-finding"));
        if (testResult.LDL != null) {
            testResult.LDL.Finding = getFindingDataandSynchronized(testResult.LDL.Finding, ldlFinding);
        }
        else if (ldlFinding != null) {
            testResult.LDL = { 'Finding': getFindingDataandSynchronized(null, ldlFinding), "ReadingSource": readingSourceManual, 'RecorderMetaData': { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate } };
        }

        var tcHdlFinding = getSelectedFinding($(".tchdlratio-AwvLipid-finding"));
        if (testResult.TCHDLRatio != null) {
            testResult.TCHDLRatio.Finding = getFindingDataandSynchronized(testResult.TCHDLRatio.Finding, tcHdlFinding);
        }
        else if (tcHdlFinding != null) {
            testResult.TCHDLRatio = { 'Finding': getFindingDataandSynchronized(null, tcHdlFinding), "ReadingSource": readingSourceManual, 'RecorderMetaData': { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate } };
        }

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }

        if (currentScreenMode != ScreenMode.Entry) {
            if (testResult.PhysicianInterpretation == null) {
                testResult.PhysicianInterpretation = {
                    'Remarks': $("#physicianRemarksAwvLipid").val(), 'IsCritical': $("#criticalAwvLipid").attr("checked"), 'FollowUp': $("#followUpLipid").attr("checked"), 'RecorderMetaData': {
                        'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate
                    }
                };
            }
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksAwvLipid").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpLipid").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalAwvLipid").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }


        if (testResult.ResultStatus.StateNumber < 4) {
            if (!(testResult.TotalCholestrol != null || testResult.HDL != null || testResult.LDL != null ||
                     testResult.TCHDLRatio != null || testResult.TriGlycerides != null ||
                    testResult.TechnicianNotes.length > 0 || testResult.ConductedByOrgRoleUserId != "0" ||
                    (testResult.UnableScreenReason != null && testResult.UnableScreenReason.length > 0) || $("#SelfPresentAwvLipidInputCheck").attr("checked") == true))
                return null;
        }

        return testResult;
    }
}


function onblurCalculateAwvLipidTCHDLRatio() {
    if ($.trim($("#TotalCholestrolAwvLipidInputText").val()).length < 1 ||
            $.trim($("#HDLAwvLipidInputText").val()).length < 1) {
        $("#TCHDLRatioAwvLipidInputText").val('');
    }
    else if (isNaN($.trim($("#TotalCholestrolAwvLipidInputText").val())) == true ||
            isNaN($.trim($("#HDLAwvLipidInputText").val())) == true) {
        $("#TCHDLRatioAwvLipidInputText").val('');
    }
    else if (Number($.trim($("#TotalCholestrolAwvLipidInputText").val())) == 0 ||
            Number($.trim($("#HDLAwvLipidInputText").val())) == 0) {
        $("#TCHDLRatioAwvLipidInputText").val('');
    }
    else {
        var tcHdlRatio = Number($.trim($("#TotalCholestrolAwvLipidInputText").val())) / Number($.trim($("#HDLAwvLipidInputText").val()));
        $("#TCHDLRatioAwvLipidInputText").val(parseFloat(tcHdlRatio).toFixed(1));
    }

    $("#TCHDLRatioAwvLipidInputText").focus();
    $("#TCHDLRatioAwvLipidInputText").blur();
}

function onblurCalculateAwvLipidLDL() {
    if ($.trim($("#TotalCholestrolAwvLipidInputText").val()).length < 1 || $.trim($("#HDLAwvLipidInputText").val()).length < 1 || $.trim($("#TriglyceridesAwvLipidInputText").val()).length < 1) {
        $("#LDLAwvLipidInputText").val('');
    }
    else if (isNaN($.trim($("#TotalCholestrolAwvLipidInputText").val())) == true || isNaN($.trim($("#HDLAwvLipidInputText").val())) == true || isNaN($.trim($("#TriglyceridesAwvLipidInputText").val())) == true) {
        $("#LDLAwvLipidInputText").val('');
    }
    else if (Number($.trim($("#TotalCholestrolAwvLipidInputText").val())) == 0 || Number($.trim($("#HDLAwvLipidInputText").val())) == 0 || Number($.trim($("#TriglyceridesAwvLipidInputText").val())) == 0) {
        $("#LDLAwvLipidInputText").val('');
    }
    else {
        var ldl = Number($.trim($("#TotalCholestrolAwvLipidInputText").val())) - Number($.trim($("#HDLAwvLipidInputText").val())) - (Number($.trim($("#TriglyceridesAwvLipidInputText").val())) / 5);
        $("#LDLAwvLipidInputText").val(parseFloat(ldl).toFixed(0));
    }

    $("#LDLAwvLipidInputText").change();
}

function onChangeAwvLipidTotalCholestrol(TCinput) {
    var tcInputElement = $(TCinput);
    autoSelectFinding($(".tc-AwvLipid-finding"), tcInputElement, 1);
    onblurCalculateAwvLipidTCHDLRatio();
    onblurCalculateAwvLipidLDL();
    checkAwvLipidTotalCholesterolMinMaxValue(tcInputElement.val());
}

function onChangeAwvLipidHDL(HDLinput) {
    var hdlInputElement = $(HDLinput);
    autoSelectFinding($(".hdl-AwvLipid-finding"), hdlInputElement, 1);
    onblurCalculateAwvLipidTCHDLRatio();
    onblurCalculateAwvLipidLDL();
    checkAwvLipidHDLMinMaxValue(hdlInputElement.val());
}

function onChangeLdlAwvLipid(ldlLipidInput) {
    var ldlLipidElement = $(ldlLipidInput);
    autoSelectFinding($('.ldl-AwvLipid-finding'), ldlLipidElement, 1);
    checkAwvLipidLDLMinMaxValue(ldlLipidElement.val());
}

function onChangeAwvLipidTriglycerides(TriglyceridesInput) {
    var triglyceridesElement = $(TriglyceridesInput);
    autoSelectFinding($(".triglycerides-AwvLipid-finding"), triglyceridesElement, 1);
    onblurCalculateAwvLipidLDL();
    checkAwvLipidTriglyceridesMinMaxValue(triglyceridesElement.val());
}

var criticalDataModel_AwvLipid = null;
function onClick_CriticalDataAwvLipid() {
    if ($("#SelfPresentAwvLipidInputCheck").attr("checked")) {
        loadCriticalLink($("#AwvLipid-critical-span"), "onClick_CriticalDataAwvLipid();", testTypeAwvLipid);
        openCriticalDataDialog(testTypeAwvLipid, $("#conductedbyAwvLipid"), $("#SelfPresentAwvLipidInputCheck"), setcriticalDataModel_AwvLipid);
    }
    else {
        unloadCriticalLink($("#AwvLipid-critical-span"), testTypeAwvLipid);
    }
}

function setcriticalDataModel_AwvLipid(model, printAfterSave) {
    if (model != null) {
        var testResult = GetAwvLipidData();
        saveSingleTestResult(testResult, model, $("#AwvLipid-critical-span"), "onClick_CriticalDataAwvLipid();", SetAwvLipidData, printAfterSave);
    }
}

function getcriticalDataModel_AwvLipid() {
    if ($("#SelfPresentAwvLipidInputCheck").attr("checked") && criticalDataModel_AwvLipid != null) {
        criticalDataModel_AwvLipid.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_AwvLipid;
    }
    return null;
}

function onClick_PriorityInQueueDataAwvLipid() {
    if ($("#PriorityInQueueTestAwvLipidCheck").attr("checked")) {
        loadPriorityInQueueLink($("#awvLipid-priorityInQueue-span"), "onClick_PriorityInQueueDataAwvLipid();", testTypeAwvLipid);
        openPriorityInQueueTestDialog(testTypeAwvLipid, $("#conductedbyAwvLipid"), $("#PriorityInQueueTestAwvLipidCheck"), setPriorityInQueueDataModel_AwvLipid);
    }
    else {
        unloadPriorityInQueueLink($("#awvLipid-priorityInQueue-span"), testTypeAwvLipid);
    }
}

function setPriorityInQueueDataModel_AwvLipid(model) {
    if (model != null) {
        var testResult = GetAwvLipidData();
        model.TestId = testTypeAwvLipid;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#awvLipid-priorityInQueue-span"), "onClick_PriorityInQueueDataAwvLipid();", SetAwvLipidData);
    }
}

function checkHdlFindingsForGenderChange(isMale) {
    if ($("#AwvLipidHdlfindingjson").length < 1) return;

    var hdlFindings = null;
    eval("hdlFindings = " + $("#AwvLipidHdlfindingjson").val());
    if (hdlFindings == null) return;

    var gridHdl = $(".hdl-AwvLipid-finding");
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
    $("#HDLAwvLipidInputText").change();
}


function KeyPress_NumericAllowedOnly_ForAwvLipid(evt) {
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

function clearAllAwvLipidSelection() {
    $(".clear-all-AwvLipid-selection input[type=radio]").attr("checked", false);
}

function setTestNotPerformedReasonForAwvLipid(testNotPerformed) {
    setTestNotPerformed("testnotPerformedAwvLipid", testNotPerformed);
    SetTestNotPerformedEnableDisabled("testnotPerformedAwvLipid");
}

function getTestNotPerformedReasonForAwvLipid(testNotPerformed) {
    return getTestNotPerformed("testnotPerformedAwvLipid", testNotPerformed);
}

function checkAwvLipidAssessment() {
    var text = "";

    if ($(".dtl-unable-to-screendtl-unable-to-screen-AwvLipid").find("input[type='checkbox']:checked").length > 0)
        return text;

    if ($("#testnotPerformedAwvLipid").find("input[type='checkbox']:checked").length > 0)
        return text;

    var lipidPanelTestResult = GetAwvLipidData();
    if (lipidPanelTestResult != null) {
        if (lipidPanelTestResult.TotalCholestrol && lipidPanelTestResult.TotalCholestrol.Reading != null) {
            if (lipidPanelTestResult.TotalCholestrol.Finding == null || lipidPanelTestResult.TotalCholestrol.Finding == "") {
                text += "Total Cholestrol Findings are not marked. <br/>";
            }
        }

        if (lipidPanelTestResult.HDL != null && lipidPanelTestResult.HDL.Reading != null) {
            if (lipidPanelTestResult.HDL.Finding == null || lipidPanelTestResult.HDL.Finding == "") {
                text += "Hdl Findings are not marked.<br/>";
            }
        }

        if (lipidPanelTestResult.TriGlycerides != null && lipidPanelTestResult.TriGlycerides.Reading != null) {
            if (lipidPanelTestResult.TriGlycerides.Finding == null || lipidPanelTestResult.TriGlycerides.Finding == "") {
                text += "TriGlycerides Findings are not marked.<br/>";
            }
        }

        if (lipidPanelTestResult.LDL != null && lipidPanelTestResult.LDL.Reading != null) {
            if (lipidPanelTestResult.LDL.Finding == null || lipidPanelTestResult.LDL.Finding == "") {
                text += "Ldl Findings are not marked.<br/>";
            }
        }

        if (lipidPanelTestResult.TCHDLRatio != null && lipidPanelTestResult.TCHDLRatio.Reading != null) {
            if (lipidPanelTestResult.TCHDLRatio.Finding == null || lipidPanelTestResult.TCHDLRatio.Finding == "") {
                text += "TcHdlRatio Findings are not marked.<br/>";
            }
        }
    }


    if (text != "")
        text = "Awv Lipid Panel Test - <br/>" + text;
    return text;
}