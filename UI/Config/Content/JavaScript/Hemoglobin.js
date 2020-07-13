function Hemoglobin(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = {
            "Hemoglobin": null,
            "Id": 0, "TestType": testTypeHemoglobin,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": '0',
            "UnableScreenReason": new Array(),
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "TestPerformedExternally": null,
            "ResultStatus": {
                "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentHemoglobinInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestHemoglobinCheck").attr("checked")
            }
        };
    }
    this.Result = testResult;
}

Hemoglobin.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (IsHemoglobinResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_HemoglobincapturebyChat", testResult.TestPerformedExternally)
        }

        if (testResult.Hemoglobin != null) {
            if (testResult.Hemoglobin.Reading != null)
                $("#hemoglobin-HemoglobinInputText").val(testResult.Hemoglobin.Reading);

            if (testResult.Hemoglobin.Finding != null) {
                setSelectedFinding($(".hemoglobin-Hemoglobin-finding"), testResult.Hemoglobin.Finding.Id);
            }
        }

        $("#technotesHemoglobin").val(testResult.TechnicianNotes);
        $("#conductedbyHemoglobin option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);
        $("#DescribeSelfPresentHemoglobinInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);
        $("#PriorityInQueueTestHemoglobinCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#hemoglobin-priorityInQueue-span"), "onClick_PriorityInQueueDataHemoglobin();", testTypeHemoglobin);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#hemoglobin-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#Hemoglobin-critical-span"), "onClick_CriticalDataHemoglobin();", testTypeHemoglobin);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#Hemoglobin-critical-span").parent().addClass("red-band");
                $("#criticalHemoglobin").attr("checked", "checked");
            }
        }

        setUnableScreenReason($('.dtl-unabletoscreen-Hemoglobin'), testResult.UnableScreenReason);

        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksHemoglobin").val(testResult.PhysicianInterpretation.Remarks);
            $("#criticalHemoglobin").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }

    },
    getData: function () {
        var testResult = this.Result;
        if (IsHemoglobinResultEntryExternaly == 'True') {
             testResult.TestPerformedExternally = getTestPerformedExternally("chk_HemoglobincapturebyChat", testResult.TestPerformedExternally)
        }

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-Hemoglobin')));
        testResult.Hemoglobin = getReading($("#hemoglobin-HemoglobinInputText"), testResult.Hemoglobin);
        
        if (currentScreenMode != ScreenMode.Physician) {

            //testResult.Hemoglobin = getReading($("#hemoglobin-HemoglobinInputText"), testResult.Hemoglobin);

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
            testResult.ConductedByOrgRoleUserId = $("#conductedbyHemoglobin option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesHemoglobin").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentHemoglobinInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestHemoglobinCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_69").attr("checked");

        var hemoglobinFinding = getSelectedFinding($(".hemoglobin-Hemoglobin-finding"));
        if (testResult.Hemoglobin != null) {
            testResult.Hemoglobin.Finding = getFindingDataandSynchronized(testResult.Hemoglobin.Finding, hemoglobinFinding);
        }
        else if (hemoglobinFinding != null) {
            testResult.Hemoglobin = { 'Finding': getFindingDataandSynchronized(null, hemoglobinFinding), "ReadingSource": readingSourceManual, 'RecorderMetaData': { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate } };
        }

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }

        if (currentScreenMode != ScreenMode.Entry) {
            
            if (testResult.PhysicianInterpretation == null) {
                testResult.PhysicianInterpretation = {
                    'Remarks': $("#physicianRemarksHemoglobin").val(), 'IsCritical': $("#criticalHemoglobin").attr("checked"), 'RecorderMetaData': {
                        'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate
                    }
                };
            }
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksHemoglobin").val();
                testResult.PhysicianInterpretation.IsCritical = $("#criticalHemoglobin").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }

        if (testResult.ResultStatus.StateNumber < 4) {
            if (testResult.Hemoglobin != null && testResult.TechnicianNotes.length < 1 && testResult.ConductedByOrgRoleUserId == "0" && testResult.UnableScreenReason == null && $("#DescribeSelfPresentHemoglobinInputCheck").attr("checked") == false)
                return null;
        }

        return testResult;
    }
}


var criticalDataModel_Hemoglobin = null;
function onClick_CriticalDataHemoglobin() {
    if ($("#DescribeSelfPresentHemoglobinInputCheck").attr("checked")) {
        loadCriticalLink($("#Hemoglobin-critical-span"), "onClick_CriticalDataHemoglobin();", testTypeHemoglobin);
        openCriticalDataDialog(testTypeHemoglobin, $("#conductedbyHemoglobin"), $("#DescribeSelfPresentHemoglobinInputCheck"), setcriticalDataModel_Hemoglobin);
    }
    else {
        unloadCriticalLink($("#Hemoglobin-critical-span"), testTypeHemoglobin);
    }
}

function setcriticalDataModel_Hemoglobin(model, printAfterSave) {
    if (model != null) {
        var testResult = GetHemoglobinData();
        saveSingleTestResult(testResult, model, $("#Hemoglobin-critical-span"), "onClick_CriticalDataHemoglobin();", SetHemoglobinData, printAfterSave);
    }
}

function getcriticalDataModel_Hemoglobin() {
    if ($("#DescribeSelfPresentHemoglobinInputCheck").attr("checked") && criticalDataModel_Hemoglobin != null) {
        criticalDataModel_Hemoglobin.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_Hemoglobin;
    }
    return null;
}
function onClick_PriorityInQueueDataHemoglobin() {
    if ($("#PriorityInQueueTestHemoglobinCheck").attr("checked")) {
        loadPriorityInQueueLink($("#hemoglobin-priorityInQueue-span"), "onClick_PriorityInQueueDataHemoglobin();", testTypeHemoglobin);
        openPriorityInQueueTestDialog(testTypeHemoglobin, $("#conductedbyHemoglobin"), $("#PriorityInQueueTestHemoglobinCheck"), setPriorityInQueueDataModel_Hemoglobin);
    }
    else {
        unloadPriorityInQueueLink($("#hemoglobin-priorityInQueue-span"), testTypeHemoglobin);
    }
}

function setPriorityInQueueDataModel_Hemoglobin(model) {
    if (model != null) {
        var testResult = GetHemoglobinData();
        model.TestId = testTypeHemoglobin;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#hemoglobin-priorityInQueue-span"), "onClick_PriorityInQueueDataHemoglobin();", SetHemoglobinData);
    }
}
function clearAllHemoglobinSelection() {
    $(".clear-all-Hemoglobin-selection input[type=radio]").attr("checked", false);
}

function onChangeHemoglobin(hemoglobinInput) {
    
    var hemoglobinInputElement = $(hemoglobinInput);
    autoSelectFinding($(".hemoglobin-Hemoglobin-finding"), hemoglobinInputElement, 1);

    checkHemoglobinMinMaxValue(hemoglobinInputElement.val());
}

function checkHemoglobinFindingsForGenderChange(isMale) {
    if ($("#hemoglobinfindingjson").length < 1) return;

    var hemoglobinfindings = null;
    eval("hemoglobinfindings = " + $("#hemoglobinfindingjson").val());
    if (hemoglobinfindings == null) return;

    var gridhemoglobin = $(".hemoglobin-Hemoglobin-finding");
    gridhemoglobin.find('input[type=radio]').attr("checked", false);

    var count = 0;
    var toCheckFor = isMale ? "male - " : "female - ";

    for (var i = 0; i < hemoglobinfindings.length; i++) {
        var finding = hemoglobinfindings[i];
        if (finding.Label.toLowerCase().indexOf(toCheckFor) == 0) {
            var row = $(gridhemoglobin.find("tr")[count]);
            row.find(".finding-id").val(finding.Id);
            row.find(".finding-minvalue").val(finding.MinValue);
            row.find(".finding-maxvalue").val(finding.MaxValue);

            var cell = $(row.find("td")[1]);
            cell.empty();
            cell.html(finding.Label.substring(toCheckFor.length - 1, finding.Label.length) + " " + finding.Description);
            count++;
        }
    }

    $("#hemoglobin-HemoglobinInputText").change();
}

