function Lipid(testResult) {
    if (testResult == null || testResult == undefined) {

        testResult = {
            "Id": 0, "TestType": testTypeLipid,
            "TotalCholestrol": null, "HDL": null,
            "LDL": null, "Glucose": null,
            "TriGlycerides": null, "TCHDLRatio": null,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": '',
            "UnableScreenReason": new Array(),
            "TestPerformedExternally": null,
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": {
                "Id": 0,
                "SelfPresent": $("#SelfPresentLipidInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestLipidCheck").attr("checked")
            }
        };

    }
    this.Result = testResult;
}

Lipid.prototype = {
    setData: function() {
        var testResult = this.Result;
        if (IslipidResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_lipidcapturebyChat", testResult.TestPerformedExternally)
        }


        if (testResult.TotalCholestrol != null) {
            if (testResult.TotalCholestrol.Reading != null) {
                $("#TotalCholestrolLipidInputText").val(testResult.TotalCholestrol.Reading);
            }

            if (testResult.TotalCholestrol.Finding != null) {
                setSelectedFinding($(".tc-lipid-finding"), testResult.TotalCholestrol.Finding.Id);
            }
        }

        if (testResult.Glucose != null) {
            if (testResult.Glucose.Reading != null)
                $("#GlucoseLipidInputText").val(testResult.Glucose.Reading);

            if (testResult.Glucose.Finding != null) {
                setSelectedFinding($(".glucose-lipid-finding"), testResult.Glucose.Finding.Id);
            }
        }

        if (testResult.HDL != null) {
            if (testResult.HDL.Reading != null) {
                $("#HDLLipidInputText").val(testResult.HDL.Reading);
            }

            if (testResult.HDL.Finding != null) {
                setSelectedFinding($(".hdl-lipid-finding"), testResult.HDL.Finding.Id);
            }
        }

        if (testResult.TriGlycerides != null) {
            if (testResult.TriGlycerides.Reading != null) {
                $("#TriglyceridesLipidInputText").val(testResult.TriGlycerides.Reading);
            }

            if (testResult.TriGlycerides.Finding != null) {
                setSelectedFinding($(".triglycerides-lipid-finding"), testResult.TriGlycerides.Finding.Id);
            }
        }

        if (testResult.LDL != null) {
            if (testResult.LDL.Reading != null) {
                $("#LDLLipidInputText").val(testResult.LDL.Reading);
            }

            if (testResult.LDL.Finding != null) {
                setSelectedFinding($(".ldl-lipid-finding"), testResult.LDL.Finding.Id);
            }
        }


        if (testResult.TCHDLRatio != null) {

            if (testResult.TCHDLRatio.Reading != null)
                $("#TCHDLRatioLipidInputText").val(parseFloat(testResult.TCHDLRatio.Reading).toFixed(1));

            if (testResult.TCHDLRatio.Finding != null) {
                setSelectedFinding($(".tchdlratio-lipid-finding"), testResult.TCHDLRatio.Finding.Id);
            }
        }

        $("#technoteslipid").val(testResult.TechnicianNotes);
        $("#conductedbylipid option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);
        $("#SelfPresentLipidInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);
        $("#PriorityInQueueTestLipidCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);

        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#lipid-priorityInQueue-span"), "onClick_PriorityInQueueDataLipid();", testTypeLipid);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#lipid-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#lipid-critical-span"), "onClick_CriticalDataLipid();", testTypeLipid);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#lipid-critical-span").parent().addClass("red-band");
                $("#criticalLipid").attr("checked", "checked");
            }
        }

        setUnableScreenReason($('.dtl-unable-to-screen-lipid'), testResult.UnableScreenReason);

        setTestNotPerformedReasonForLipid(testResult.TestNotPerformed);

        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksLipid").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpLipid").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalLipid").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }
    },
    getData: function() {
        var testResult = this.Result;
        if (IslipidResultEntryExternaly == 'True') {
            testResult.TestPerformedExternally = getTestPerformedExternally("chk_lipidcapturebyChat", testResult.TestPerformedExternally)
        }

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unable-to-screen-lipid')));
        testResult.TestNotPerformed = getTestNotPerformedReasonForLipid(testResult.TestNotPerformed);

        testResult.TotalCholestrol = getReading($("#TotalCholestrolLipidInputText"), testResult.TotalCholestrol);
        testResult.HDL = getReading($("#HDLLipidInputText"), testResult.HDL);
        testResult.Glucose = getReading($("#GlucoseLipidInputText"), testResult.Glucose);
        testResult.TriGlycerides = getReading($("#TriglyceridesLipidInputText"), testResult.TriGlycerides);
        testResult.LDL = getReading($("#LDLLipidInputText"), testResult.LDL);
        testResult.TCHDLRatio = getReading($("#TCHDLRatioLipidInputText"), testResult.TCHDLRatio);

        if (currentScreenMode != ScreenMode.Physician) {
            //testResult.TotalCholestrol = getReading($("#TotalCholestrolLipidInputText"), testResult.TotalCholestrol);
            //testResult.HDL = getReading($("#HDLLipidInputText"), testResult.HDL);
            //testResult.Glucose = getReading($("#GlucoseLipidInputText"), testResult.Glucose);
            //testResult.TriGlycerides = getReading($("#TriglyceridesLipidInputText"), testResult.TriGlycerides);
            //testResult.LDL = getReading($("#LDLLipidInputText"), testResult.LDL);
            //testResult.TCHDLRatio = getReading($("#TCHDLRatioLipidInputText"), testResult.TCHDLRatio);

            if (currentScreenMode != ScreenMode.CorrectionPostEvaluation) testResult.ResultStatus.StateNumber = $("#ResultStatusInputHidden").val();

            if (testResult.ResultStatus.Id > 0) {
                testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.ResultStatus.DataRecorderMetaData.DateModified = currentDate;
            } else {
                testResult.ResultStatus.DataRecorderMetaData = { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate };
            }
        }

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.TechnicianNotes = $.trim($("#technoteslipid").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ConductedByOrgRoleUserId = $("#conductedbylipid option:selected").val();
            testResult.ResultStatus.SelfPresent = $("#SelfPresentLipidInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestLipidCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_12").attr("checked");

        var tcFinding = getSelectedFinding($(".tc-lipid-finding"));
        if (testResult.TotalCholestrol != null) {
            testResult.TotalCholestrol.Finding = getFindingDataandSynchronized(testResult.TotalCholestrol.Finding, tcFinding);
        } else if (tcFinding != null) {
            testResult.TotalCholestrol = { 'Finding': getFindingDataandSynchronized(null, tcFinding), "ReadingSource": readingSourceManual, 'RecorderMetaData': { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate } };
        }

        var gluFinding = getSelectedFinding($(".glucose-lipid-finding"));
        if (testResult.Glucose != null) {
            testResult.Glucose.Finding = getFindingDataandSynchronized(testResult.Glucose.Finding, gluFinding);
        } else if (gluFinding != null) {
            testResult.Glucose = { 'Finding': getFindingDataandSynchronized(null, gluFinding), "ReadingSource": readingSourceManual, 'RecorderMetaData': { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate } };
        }

        var hdlFinding = getSelectedFinding($(".hdl-lipid-finding"));
        if (testResult.HDL != null) {
            testResult.HDL.Finding = getFindingDataandSynchronized(testResult.HDL.Finding, hdlFinding);
        } else if (hdlFinding != null) {
            testResult.HDL = { 'Finding': getFindingDataandSynchronized(null, hdlFinding), "ReadingSource": readingSourceManual, 'RecorderMetaData': { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate } };
        }

        var tGlyFinding = getSelectedFinding($(".triglycerides-lipid-finding"));
        if (testResult.TriGlycerides != null) {
            testResult.TriGlycerides.Finding = getFindingDataandSynchronized(testResult.TriGlycerides.Finding, tGlyFinding);
        } else if (tGlyFinding != null) {
            testResult.TriGlycerides = { 'Finding': getFindingDataandSynchronized(null, tGlyFinding), "ReadingSource": readingSourceManual, 'RecorderMetaData': { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate } };
        }

        var ldlFinding = getSelectedFinding($(".ldl-lipid-finding"));
        if (testResult.LDL != null) {
            testResult.LDL.Finding = getFindingDataandSynchronized(testResult.LDL.Finding, ldlFinding);
        } else if (ldlFinding != null) {
            testResult.LDL = { 'Finding': getFindingDataandSynchronized(null, ldlFinding), "ReadingSource": readingSourceManual, 'RecorderMetaData': { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate } };
        }

        var tcHdlFinding = getSelectedFinding($(".tchdlratio-lipid-finding"));
        if (testResult.TCHDLRatio != null) {
            testResult.TCHDLRatio.Finding = getFindingDataandSynchronized(testResult.TCHDLRatio.Finding, tcHdlFinding);
        } else if (tcHdlFinding != null) {
            testResult.TCHDLRatio = { 'Finding': getFindingDataandSynchronized(null, tcHdlFinding), "ReadingSource": readingSourceManual, 'RecorderMetaData': { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate } };
        }

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }

        if (currentScreenMode != ScreenMode.Entry) {
            if (testResult.PhysicianInterpretation == null) {
                testResult.PhysicianInterpretation = {
                    'Remarks': $("#physicianRemarksLipid").val(),
                    'IsCritical': $("#criticalLipid").attr("checked"),
                    'FollowUp': $("#followUpLipid").attr("checked"),
                    'RecorderMetaData': {
                        'DataRecorderCreator': { 'Id': currentUser },
                        'DateCreated': currentDate
                    }
                };
            } else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksLipid").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpLipid").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalLipid").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }


        if (testResult.ResultStatus.StateNumber < 4) {
            if (!(testResult.TotalCholestrol != null || testResult.HDL != null || testResult.LDL != null ||
                testResult.Glucose != null || testResult.TCHDLRatio != null || testResult.TriGlycerides != null ||
                testResult.TechnicianNotes.length > 0 || testResult.ConductedByOrgRoleUserId != "0" ||
                (testResult.UnableScreenReason != null && testResult.UnableScreenReason.length > 0) || $("#SelfPresentLipidInputCheck").attr("checked") == true))
                return null;
        }

        return testResult;
    }
};


function setTestNotPerformedReasonForLipid(testNotPerformed) {
    setTestNotPerformed("testnotPerformedLipid", testNotPerformed);
    SetTestNotPerformedEnableDisabled("testnotPerformedLipid");
}

function getTestNotPerformedReasonForLipid(testNotPerformed) {
    return getTestNotPerformed("testnotPerformedLipid", testNotPerformed);
}

function onblurCalculateTCHDLRatio() {
    if ($.trim($("#TotalCholestrolLipidInputText").val()).length < 1 ||
            $.trim($("#HDLLipidInputText").val()).length < 1) {
        $("#TCHDLRatioLipidInputText").val('');
    }
    else if (isNaN($.trim($("#TotalCholestrolLipidInputText").val())) == true ||
            isNaN($.trim($("#HDLLipidInputText").val())) == true) {
        $("#TCHDLRatioLipidInputText").val('');
    }
    else if (Number($.trim($("#TotalCholestrolLipidInputText").val())) == 0 ||
            Number($.trim($("#HDLLipidInputText").val())) == 0) {
        $("#TCHDLRatioLipidInputText").val('');
    }
    else {
        var tcHdlRatio = Number($.trim($("#TotalCholestrolLipidInputText").val())) / Number($.trim($("#HDLLipidInputText").val()));
        $("#TCHDLRatioLipidInputText").val(parseFloat(tcHdlRatio).toFixed(1));
    }

    $("#TCHDLRatioLipidInputText").focus();
    $("#TCHDLRatioLipidInputText").blur();
}

function onblurCalculateLDL() {
    if ($.trim($("#TotalCholestrolLipidInputText").val()).length < 1 || $.trim($("#HDLLipidInputText").val()).length < 1 || $.trim($("#TriglyceridesLipidInputText").val()).length < 1) {
        $("#LDLLipidInputText").val('');
    }
    else if (isNaN($.trim($("#TotalCholestrolLipidInputText").val())) == true || isNaN($.trim($("#HDLLipidInputText").val())) == true || isNaN($.trim($("#TriglyceridesLipidInputText").val())) == true) {
        $("#LDLLipidInputText").val('');
    }
    else if (Number($.trim($("#TotalCholestrolLipidInputText").val())) == 0 || Number($.trim($("#HDLLipidInputText").val())) == 0 || Number($.trim($("#TriglyceridesLipidInputText").val())) == 0) {
        $("#LDLLipidInputText").val('');
    }
    else {
        var ldl = Number($.trim($("#TotalCholestrolLipidInputText").val())) - Number($.trim($("#HDLLipidInputText").val())) - (Number($.trim($("#TriglyceridesLipidInputText").val())) / 5);
        $("#LDLLipidInputText").val(parseFloat(ldl).toFixed(0));
    }

    $("#LDLLipidInputText").change();
}


function onChangeTotalCholestrol(TCinput) {
    var tcInputElement = $(TCinput);
    autoSelectFinding($(".tc-lipid-finding"), tcInputElement, 1);
    onblurCalculateTCHDLRatio();
    onblurCalculateLDL();
    checkLipidTotalCholesterolMinMaxValue(tcInputElement.val());
}

function onChangeHDL(HDLinput) {
    var hdlInputElement = $(HDLinput);
    autoSelectFinding($(".hdl-lipid-finding"), hdlInputElement, 1);
    onblurCalculateTCHDLRatio();
    onblurCalculateLDL();
    checkLipidHDLMinMaxValue(hdlInputElement.val());
}

function onChangeLdlLipid(ldlLipidInput) {
    var ldlLipidElement = $(ldlLipidInput);
    autoSelectFinding($('.ldl-lipid-finding'), ldlLipidElement, 1);
    checkLipidLDLMinMaxValue(ldlLipidElement.val());
}

function onChangeTriglycerides(triglyceridesInput) {
    var triglyceridesElement = $(triglyceridesInput);
    autoSelectFinding($(".triglycerides-lipid-finding"), triglyceridesElement, 1);
    onblurCalculateLDL();
    checkLipidTriglyceridesMinMaxValue(triglyceridesElement.val());
}

var criticalDataModel_Lipid = null;
function onClick_CriticalDataLipid() {
    if ($("#SelfPresentLipidInputCheck").attr("checked")) {
        loadCriticalLink($("#lipid-critical-span"), "onClick_CriticalDataLipid();", testTypeLipid);
        openCriticalDataDialog(testTypeLipid, $("#conductedbylipid"), $("#SelfPresentLipidInputCheck"), setCriticalDataModel_Lipid);
    }
    else {
        unloadCriticalLink($("#lipid-critical-span"), testTypeLipid);
    }
}

function setCriticalDataModel_Lipid(model, printAfterSave) {
    if (model != null) {
        var testResult = GetLipidData();
        saveSingleTestResult(testResult, model, $("#lipid-critical-span"), "onClick_CriticalDataLipid();", SetLipidData, printAfterSave);
    }
}

function getCriticalDataModel_Lipid() {
    if ($("#SelfPresentLipidInputCheck").attr("checked") && criticalDataModel_Lipid != null) {
        criticalDataModel_Lipid.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_Lipid;
    }
    return null;
}

function onClick_PriorityInQueueDataLipid() {
    if ($("#PriorityInQueueTestLipidCheck").attr("checked")) {
        loadPriorityInQueueLink($("#lipid-priorityInQueue-span"), "onClick_PriorityInQueueDataLipid();", testTypeLipid);
        openPriorityInQueueTestDialog(testTypeLipid, $("#conductedbylipid"), $("#PriorityInQueueTestLipidCheck"), setPriorityInQueueDataModel_Lipid);
    }
    else {
        unloadPriorityInQueueLink($("#lipid-priorityInQueue-span"), testTypeLipid);
    }
}

function setPriorityInQueueDataModel_Lipid(model) {
    if (model != null) {
        var testResult = GetLipidData();
        model.TestId = testTypeLipid;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#lipid-priorityInQueue-span"), "onClick_PriorityInQueueDataLipid();", SetLipidData);
    }
}

function checkHdlFindingsForGenderChange(isMale) {
    if ($("#hdlfindingjson").length < 1) return;

    var hdlFindings = null;
    eval("hdlFindings = " + $("#hdlfindingjson").val());
    if (hdlFindings == null) return;

    var gridHdl = $(".hdl-lipid-finding");
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
    $("#HDLLipidInputText").change();
}


function KeyPress_NumericAllowedOnly_ForLipid(evt) {
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

function clearAllLipidSelection() {
    $(".clear-all-lipid-selection input[type=radio]").attr("checked", false);
}


function checkLipidAssessment() {
    var text = "";

    if ($(".dtl-unable-to-screen-lipid").find("input[type='checkbox']:checked").length > 0)
        return text;

    var lipidPanelTestResult = GetLipidData();
    if (lipidPanelTestResult != null) {
        if (lipidPanelTestResult.TotalCholestrol && lipidPanelTestResult.TotalCholestrol.Reading != null) {
            if (lipidPanelTestResult.TotalCholestrol.Finding == null || lipidPanelTestResult.TotalCholestrol.Finding == "") {
                text += "Total Cholestrol Findings are not marked. <br/>";
            }
        }

        if (lipidPanelTestResult.Glucose != null && lipidPanelTestResult.Glucose.Reading != null) {
            if (lipidPanelTestResult.Glucose.Finding == null || lipidPanelTestResult.Glucose.Finding == "") {
                text += "Glucose Findings are not marked.<br/>";
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
        text = "Lipid Panel Test - <br/>" + text;
    return text;
}