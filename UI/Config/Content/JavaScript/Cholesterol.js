function Cholesterol(testResult) {
    if (testResult == null || testResult == undefined) {

        testResult = {
            "Id": 0, "TestType": testTypeCholesterol,
            "TotalCholesterol": null, "HDL": null,
            "LDL": null,
            "TriGlycerides": null, "TCHDLRatio": null,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": '',
            "UnableScreenReason": new Array(),
            "TestPerformedExternally": null,
             
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": {
                "Id": 0,
                "SelfPresent": $("#SelfPresentCholesterolInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestCholesterolCheck").attr("checked")
            }
        };

    }
    this.Result = testResult;
}

Cholesterol.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (IscholesterolResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_cholesterolcapturebyChat", testResult.TestPerformedExternally)
        }

        if (testResult.TotalCholesterol != null) {
            if (testResult.TotalCholesterol.Reading != null) {
                $("#TotalCholesterolCholesterolInputText").val(testResult.TotalCholesterol.Reading);
            }

            if (testResult.TotalCholesterol.Finding != null) {
                setSelectedFinding($(".tc-Cholesterol-finding"), testResult.TotalCholesterol.Finding.Id);
            }
        }

        if (testResult.HDL != null) {
            if (testResult.HDL.Reading != null) {
                $("#HDLCholesterolInputText").val(testResult.HDL.Reading);
            }

            if (testResult.HDL.Finding != null) {
                setSelectedFinding($(".hdl-Cholesterol-finding"), testResult.HDL.Finding.Id);
            }
        }

        if (testResult.TriGlycerides != null) {
            if (testResult.TriGlycerides.Reading != null) {
                $("#TriglyceridesCholesterolInputText").val(testResult.TriGlycerides.Reading);
            }

            if (testResult.TriGlycerides.Finding != null) {
                setSelectedFinding($(".triglycerides-Cholesterol-finding"), testResult.TriGlycerides.Finding.Id);
            }
        }

        if (testResult.LDL != null) {
            if (testResult.LDL.Reading != null) {
                $("#LDLCholesterolInputText").val(testResult.LDL.Reading);
            }

            if (testResult.LDL.Finding != null) {
                setSelectedFinding($(".ldl-Cholesterol-finding"), testResult.LDL.Finding.Id);
            }
        }


        if (testResult.TCHDLRatio != null) {

            if (testResult.TCHDLRatio.Reading != null)
                $("#TCHDLRatioCholesterolInputText").val(parseFloat(testResult.TCHDLRatio.Reading).toFixed(1));

            if (testResult.TCHDLRatio.Finding != null) {
                setSelectedFinding($(".tchdlratio-Cholesterol-finding"), testResult.TCHDLRatio.Finding.Id);
            }
        }

        $("#technotesCholesterol").val(testResult.TechnicianNotes);
        $("#conductedbyCholesterol option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);
        $("#SelfPresentCholesterolInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);

        $("#PriorityInQueueTestCholesterolCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#cholesterol-priorityInQueue-span"), "onClick_PriorityInQueueDataCholesterol();", testTypeCholesterol);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#cholesterol-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#Cholesterol-critical-span"), "onClick_CriticalDataCholesterol();", testTypeCholesterol);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#Cholesterol-critical-span").parent().addClass("red-band");
                $("#criticalCholesterol").attr("checked", "checked");
            }
        }
        setUnableScreenReason($('.dtl-unable-to-screen-Cholesterol'), testResult.UnableScreenReason);

        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksCholesterol").val(testResult.PhysicianInterpretation.Remarks);
            $("#criticalCholesterol").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }
    },
    getData: function () {
        var testResult = this.Result;
        if (IscholesterolResultEntryExternaly == 'True') {
             testResult.TestPerformedExternally = getTestPerformedExternally("chk_cholesterolcapturebyChat", testResult.TestPerformedExternally)
        }
        
        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unable-to-screen-Cholesterol')));

        testResult.TotalCholesterol = getReading($("#TotalCholesterolCholesterolInputText"), testResult.TotalCholesterol);
        testResult.HDL = getReading($("#HDLCholesterolInputText"), testResult.HDL);

        testResult.TriGlycerides = getReading($("#TriglyceridesCholesterolInputText"), testResult.TriGlycerides);
        testResult.LDL = getReading($("#LDLCholesterolInputText"), testResult.LDL);
        testResult.TCHDLRatio = getReading($("#TCHDLRatioCholesterolInputText"), testResult.TCHDLRatio);

        if (currentScreenMode != ScreenMode.Physician) {
            //testResult.TotalCholesterol = getReading($("#TotalCholesterolCholesterolInputText"), testResult.TotalCholesterol);
            //testResult.HDL = getReading($("#HDLCholesterolInputText"), testResult.HDL);

            //testResult.TriGlycerides = getReading($("#TriglyceridesCholesterolInputText"), testResult.TriGlycerides);
            //testResult.LDL = getReading($("#LDLCholesterolInputText"), testResult.LDL);
            //testResult.TCHDLRatio = getReading($("#TCHDLRatioCholesterolInputText"), testResult.TCHDLRatio);

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
            testResult.TechnicianNotes = $.trim($("#technotesCholesterol").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ConductedByOrgRoleUserId = $("#conductedbyCholesterol option:selected").val();
            testResult.ResultStatus.SelfPresent = $("#SelfPresentCholesterolInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestCholesterolCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_61").attr("checked");

        var tcFinding = getSelectedFinding($(".tc-Cholesterol-finding"));
        if (testResult.TotalCholesterol != null) {
            testResult.TotalCholesterol.Finding = getFindingDataandSynchronized(testResult.TotalCholesterol.Finding, tcFinding);
        }
        else if (tcFinding != null) {
            testResult.TotalCholesterol = { 'Finding': getFindingDataandSynchronized(null, tcFinding), "ReadingSource": readingSourceManual, 'RecorderMetaData': { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate } };
        }

        var hdlFinding = getSelectedFinding($(".hdl-Cholesterol-finding"));
        if (testResult.HDL != null) {
            testResult.HDL.Finding = getFindingDataandSynchronized(testResult.HDL.Finding, hdlFinding);
        }
        else if (hdlFinding != null) {
            testResult.HDL = { 'Finding': getFindingDataandSynchronized(null, hdlFinding), "ReadingSource": readingSourceManual, 'RecorderMetaData': { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate } };
        }

        var tGlyFinding = getSelectedFinding($(".triglycerides-Cholesterol-finding"));
        if (testResult.TriGlycerides != null) {
            testResult.TriGlycerides.Finding = getFindingDataandSynchronized(testResult.TriGlycerides.Finding, tGlyFinding);
        }
        else if (tGlyFinding != null) {
            testResult.TriGlycerides = { 'Finding': getFindingDataandSynchronized(null, tGlyFinding), "ReadingSource": readingSourceManual, 'RecorderMetaData': { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate } };
        }

        var ldlFinding = getSelectedFinding($(".ldl-Cholesterol-finding"));
        if (testResult.LDL != null) {
            testResult.LDL.Finding = getFindingDataandSynchronized(testResult.LDL.Finding, ldlFinding);
        }
        else if (ldlFinding != null) {
            testResult.LDL = { 'Finding': getFindingDataandSynchronized(null, ldlFinding), "ReadingSource": readingSourceManual, 'RecorderMetaData': { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate } };
        }

        var tcHdlFinding = getSelectedFinding($(".tchdlratio-Cholesterol-finding"));
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
                    'Remarks': $("#physicianRemarksCholesterol").val(), 'IsCritical': $("#criticalCholesterol").attr("checked"), 'RecorderMetaData': {
                        'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate
                    }
                };
            }
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksCholesterol").val();
                testResult.PhysicianInterpretation.IsCritical = $("#criticalCholesterol").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }


        if (testResult.ResultStatus.StateNumber < 4) {
            if (!(testResult.TotalCholesterol != null || testResult.HDL != null || testResult.LDL != null ||
                     testResult.TCHDLRatio != null || testResult.TriGlycerides != null ||
                    testResult.TechnicianNotes.length > 0 || testResult.ConductedByOrgRoleUserId != "0" ||
                    (testResult.UnableScreenReason != null && testResult.UnableScreenReason.length > 0) || $("#SelfPresentCholesterolInputCheck").attr("checked") == true))
                return null;
        }

        return testResult;
    }
}


function onblurCalculateCholesterolTCHDLRatio() {
    if ($.trim($("#TotalCholesterolCholesterolInputText").val()).length < 1 ||
            $.trim($("#HDLCholesterolInputText").val()).length < 1) {
        $("#TCHDLRatioCholesterolInputText").val('');
    }
    else if (isNaN($.trim($("#TotalCholesterolCholesterolInputText").val())) == true ||
            isNaN($.trim($("#HDLCholesterolInputText").val())) == true) {
        $("#TCHDLRatioCholesterolInputText").val('');
    }
    else if (Number($.trim($("#TotalCholesterolCholesterolInputText").val())) == 0 ||
            Number($.trim($("#HDLCholesterolInputText").val())) == 0) {
        $("#TCHDLRatioCholesterolInputText").val('');
    }
    else {
        var tcHdlRatio = Number($.trim($("#TotalCholesterolCholesterolInputText").val())) / Number($.trim($("#HDLCholesterolInputText").val()));
        $("#TCHDLRatioCholesterolInputText").val(parseFloat(tcHdlRatio).toFixed(1));
    }

    $("#TCHDLRatioCholesterolInputText").focus();
    $("#TCHDLRatioCholesterolInputText").blur();
}

function onblurCalculateCholesterolLDL() {
    if ($.trim($("#TotalCholesterolCholesterolInputText").val()).length < 1 || $.trim($("#HDLCholesterolInputText").val()).length < 1 || $.trim($("#TriglyceridesCholesterolInputText").val()).length < 1) {
        $("#LDLCholesterolInputText").val('');
    }
    else if (isNaN($.trim($("#TotalCholesterolCholesterolInputText").val())) == true || isNaN($.trim($("#HDLCholesterolInputText").val())) == true || isNaN($.trim($("#TriglyceridesCholesterolInputText").val())) == true) {
        $("#LDLCholesterolInputText").val('');
    }
    else if (Number($.trim($("#TotalCholesterolCholesterolInputText").val())) == 0 || Number($.trim($("#HDLCholesterolInputText").val())) == 0 || Number($.trim($("#TriglyceridesCholesterolInputText").val())) == 0) {
        $("#LDLCholesterolInputText").val('');
    }
    else {
        var ldl = Number($.trim($("#TotalCholesterolCholesterolInputText").val())) - Number($.trim($("#HDLCholesterolInputText").val())) - (Number($.trim($("#TriglyceridesCholesterolInputText").val())) / 5);
        $("#LDLCholesterolInputText").val(parseFloat(ldl).toFixed(0));
    }

    $("#LDLCholesterolInputText").change();
}

function onChangeCholesterolTotalCholesterol(TCinput) {
    var tcInputElement = $(TCinput);
    autoSelectFinding($(".tc-Cholesterol-finding"), tcInputElement, 1);
    onblurCalculateCholesterolTCHDLRatio();

    onblurCalculateCholesterolLDL();

    checkCholesterolTotalCholesterolMinMaxValue(tcInputElement.val());
}

function onChangeCholesterolHDL(HDLinput) {
    var hdlInputElement = $(HDLinput);
    autoSelectFinding($(".hdl-Cholesterol-finding"), hdlInputElement, 1);
    onblurCalculateCholesterolTCHDLRatio();
    onblurCalculateCholesterolLDL();

    checkCholesterolHDLMinMaxValue(hdlInputElement.val());
}


function onChangeCholesterolLdl(ldlInput) {
    var ldlElement = $(ldlInput);
    autoSelectFinding($('.ldl-Cholesterol-finding'), ldlElement, 1);

    checkCholesterolLDLMinMaxValue(ldlElement.val());
}

function onChangeCholesterolTriglycerides(triglyceridesInput) {
    var triglyceridesElement = $(triglyceridesInput);
    autoSelectFinding($(".triglycerides-Cholesterol-finding"), triglyceridesElement, 1);
    onblurCalculateCholesterolLDL();

    checkCholesterolTriglyceridesMinMaxValue(triglyceridesElement.val());
}

var criticalDataModel_Cholesterol = null;
function onClick_CriticalDataCholesterol() {
    if ($("#SelfPresentCholesterolInputCheck").attr("checked")) {
        loadCriticalLink($("#Cholesterol-critical-span"), "onClick_CriticalDataCholesterol();", testTypeCholesterol);
        openCriticalDataDialog(testTypeCholesterol, $("#conductedbyCholesterol"), $("#SelfPresentCholesterolInputCheck"), setcriticalDataModel_Cholesterol);
    }
    else {
        unloadCriticalLink($("#Cholesterol-critical-span"), testTypeCholesterol);
    }
}

function setcriticalDataModel_Cholesterol(model, printAfterSave) {
    if (model != null) {
        var testResult = GetCholesterolData();
        saveSingleTestResult(testResult, model, $("#Cholesterol-critical-span"), "onClick_CriticalDataCholesterol();", SetCholesterolData, printAfterSave);
    }
}

function getcriticalDataModel_Cholesterol() {
    if ($("#SelfPresentCholesterolInputCheck").attr("checked") && criticalDataModel_Cholesterol != null) {
        criticalDataModel_Cholesterol.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_Cholesterol;
    }
    return null;
}
function onClick_PriorityInQueueDataCholesterol() {
    if ($("#PriorityInQueueTestCholesterolCheck").attr("checked")) {
        loadPriorityInQueueLink($("#cholesterol-priorityInQueue-span"), "onClick_PriorityInQueueDataCholesterol();", testTypeCholesterol);
        openPriorityInQueueTestDialog(testTypeCholesterol, $("#conductedbyCholesterol"), $("#PriorityInQueueTestCholesterolCheck"), setPriorityInQueueDataModel_Cholesterol);
    }
    else {
        unloadPriorityInQueueLink($("#cholesterol-priorityInQueue-span"), testTypeCholesterol);
    }
}

function setPriorityInQueueDataModel_Cholesterol(model) {
    if (model != null) {
        var testResult = GetCholesterolData();
        model.TestId = testTypeCholesterol;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#cholesterol-priorityInQueue-span"), "onClick_PriorityInQueueDataCholesterol();", SetCholesterolData);
    }
}

function checkHdlFindingsForGenderChange(isMale) {
    if ($("#CholesterolHdlfindingjson").length < 1) return;

    var hdlFindings = null;
    eval("hdlFindings = " + $("#CholesterolHdlfindingjson").val());
    if (hdlFindings == null) return;

    var gridHdl = $(".hdl-Cholesterol-finding");
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
    $("#HDLCholesterolInputText").change();
}


function KeyPress_NumericAllowedOnly_ForCholesterol(evt) {
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

function clearAllCholesterolSelection() {
    $(".clear-all-Cholesterol-selection input[type=radio]").attr("checked", false);
}


function checkCholestrolPanel() {
    var text = "";

    if ($(".dtl-unable-to-screen-Cholesterol").find("input[type='checkbox']:checked").length > 0)
        return text;

    var cholesterolTestResult = GetCholesterolData();
    if (cholesterolTestResult != null) {
        if (cholesterolTestResult.TotalCholestrol && cholesterolTestResult.TotalCholestrol.Reading != null) {
            if (cholesterolTestResult.TotalCholestrol.Finding == null || cholesterolTestResult.TotalCholestrol.Finding == "") {
                text += "Total Cholestrol Findings are not marked. <br/>";
            }
        }

        if (cholesterolTestResult.HDL != null && cholesterolTestResult.HDL.Reading != null) {
            if (cholesterolTestResult.HDL.Finding == null || cholesterolTestResult.HDL.Finding == "") {
                text += "Hdl Findings are not marked.<br/>";
            }
        }

        if (cholesterolTestResult.TriGlycerides != null && cholesterolTestResult.TriGlycerides.Reading != null) {
            if (cholesterolTestResult.TriGlycerides.Finding == null || cholesterolTestResult.TriGlycerides.Finding == "") {
                text += "TriGlycerides Findings are not marked.<br/>";
            }
        }

        if (cholesterolTestResult.LDL != null && cholesterolTestResult.LDL.Reading != null) {
            if (cholesterolTestResult.LDL.Finding == null || cholesterolTestResult.LDL.Finding == "") {
                text += "Ldl Findings are not marked.<br/>";
            }
        }

        if (cholesterolTestResult.TCHDLRatio != null && cholesterolTestResult.TCHDLRatio.Reading != null) {
            if (cholesterolTestResult.TCHDLRatio.Finding == null || cholesterolTestResult.TCHDLRatio.Finding == "") {
                text += "TcHdlRatio Findings are not marked.<br/>";
            }
        }
    }


    if (text != "")
        text = "Cholestrol Test - <br/>" + text;
    return text;
}