function Asi(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = { "ASI": asi,
            "PressureReadings":
                                {
                                    "PulsePressure": null,
                                    "Pulse": null
                                },
            "Pattern": null,
            "Id": 0, "UnableScreenReason": null, "TestType": testTypeAsi,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": '0',
            "IncidentalFindings": new Array(),
            "RawASI": new Array(),
            "TestPerformedExternally": null,
             
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": { "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentASIInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestAsiCheck").attr("checked")
            }
        };
    }
    this.Result = testResult;
}

Asi.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (IsasiResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_asicapturebyChat", testResult.TestPerformedExternally)
        }

        if (testResult.ASI != null) {
            if (testResult.ASI.Reading != null)
                setReading($("#AsiInputtext"), testResult.ASI);

            if (testResult.ASI.Finding != null) {
                setSelectedFinding($(".gv-findings-asi"), testResult.ASI.Finding.Id);
            }
        }

        if (testResult.PressureReadings != null) {
            $("#PulsePressureInputtext").val(testResult.PressureReadings.PulsePressure != null ? testResult.PressureReadings.PulsePressure.Reading : "");
            $("#PulseInputtext").val(testResult.PressureReadings.Pulse != null ? testResult.PressureReadings.Pulse.Reading : "");
        }

        $("#DescribeSelfPresentASIInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);
        $("#conductedbyasi option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);
        $("#PriorityInQueueTestAsiCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#Asi-priorityInQueue-span"), "onClick_PriorityInQueueDataAsi();", testTypeAsi);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#Asi-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#asi-critical-span"), "onClick_CriticalDataAsi();", testTypeAsi);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#asi-critical-span").parent().addClass("red-band");
                $("#criticalAsi").attr("checked", "checked");               
            }
        }

        $("#PatternInputtext").val(testResult.Pattern != null ? testResult.Pattern.Reading : "");

        setboolTypeReading($('#repeatstudyasiinputcheck'), testResult.RepeatStudy);

        if (testResult.RawASI != null && testResult.RawASI.length > 0) {
            var stringAsiRawReadingHtml = '';
            stringAsiRawReadingHtml = "<br /> <i> Averaged (";

            listAsiReadingsforUpdateonLast = new Array();

            var commaSeperatedAsiReading = '';
            $.each(testResult.RawASI, function () {
                commaSeperatedAsiReading += this.Reading + ", ";
                listAsiReadingsforUpdateonLast.push(this.Reading);
            });

            commaSeperatedAsiReading = commaSeperatedAsiReading.substring(0, commaSeperatedAsiReading.lastIndexOf(", "));
            stringAsiRawReadingHtml += commaSeperatedAsiReading + ") </i>";
            $("#ASIRawReadingSpan").empty();

            if (currentScreenMode != ScreenMode.Physician) {
                $("#ASIRawReadingSpan").append("<a href='javascript:LoadASIAveragingJTip(\"" + commaSeperatedAsiReading + "\");'>" + stringAsiRawReadingHtml + "</a>");
            }
            else {
                $("#ASIRawReadingSpan").html(stringAsiRawReadingHtml);
            }

            $("#ASIRawReadingSpan").show();
        }

        $("#technotesasi").val(testResult.TechnicianNotes);

        setUnableScreenReason($('.dtl-unabletoscreen-asi'), testResult.UnableScreenReason);

        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksAsi").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpAsi").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalAsi").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }
    },
    getData: function () {
        var testResult = this.Result;
        if (IsasiResultEntryExternaly == 'True') {
            testResult.TestPerformedExternally = getTestPerformedExternally("chk_asicapturebyChat", testResult.TestPerformedExternally)
        }

        if (currentScreenMode != ScreenMode.Physician) {
            testResult.ASI = getReading($("#AsiInputtext"), testResult.ASI);

            if (testResult.PressureReadings == null) {
                testResult.PressureReadings = { "PulsePressure": null, "Pulse": null };
            }

            testResult.PressureReadings.PulsePressure = getReading($("#PulsePressureInputtext"), testResult.PressureReadings.PulsePressure);
            testResult.PressureReadings.Pulse = getReading($("#PulseInputtext"), testResult.PressureReadings.Pulse);
            testResult.Pattern = getReading($("#PatternInputtext"), testResult.Pattern);
            
            if (currentScreenMode != ScreenMode.CorrectionPostEvaluation) testResult.ResultStatus.StateNumber = $("#ResultStatusInputHidden").val();

            if (testResult.ResultStatus.Id > 0) {
                testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.ResultStatus.DataRecorderMetaData.DateModified = currentDate;
            }
            else {
                testResult.ResultStatus.DataRecorderMetaData = { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate };
            }

            if (listAsiReadingsforUpdateonLast != null && listAsiReadingsforUpdateonLast.length > 0) {
                var counter = 0;
                if (testResult.RawASI == null) testResult.RawASI = new Array();

                $.each(listAsiReadingsforUpdateonLast, function () {
                    if (testResult.RawASI.length > counter) {
                        testResult.RawASI[counter].Reading = this;
                        testResult.RawASI[counter].RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                        testResult.RawASI[counter].RecorderMetaData.DateModified = currentDate;
                    }
                    else {
                        testResult.RawASI.push({ "Reading": this, "Id": 0, "ReadingSource": readingSourceManual, 'RecorderMetaData': {
                            'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate
                        }
                        });
                    }

                    counter++;
                });
            }
        }

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentASIInputCheck").attr("checked");
            testResult.TechnicianNotes = $.trim($("#technotesasi").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ConductedByOrgRoleUserId = $("#conductedbyasi option:selected").val();
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestAsiCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_3").attr("checked");

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }

        if (currentScreenMode != ScreenMode.Entry) {

            testResult.RepeatStudy = getboolTypeReading($('#repeatstudyasiinputcheck'), testResult.RepeatStudy);

            if (testResult.PhysicianInterpretation == null)
                testResult.PhysicianInterpretation = { 'Remarks': $("#physicianRemarksAsi").val(), 'IsCritical': $("#criticalAsi").attr("checked"), 'FollowUp': $("#followUpAsi").attr("checked"), 'RecorderMetaData': {
                    'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate
                }
                };
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksAsi").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpAsi").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalAsi").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }
        var asiFinding = getSelectedFinding($(".gv-findings-asi"));

        if (testResult.ASI == null && asiFinding != null) {
            testResult.ASI = { 'Finding': asiFinding, "ReadingSource": readingSourceManual, 'RecorderMetaData': { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate} };
        }
        else if (testResult.ASI != null) {
            testResult.ASI.Finding = getFindingDataandSynchronized(testResult.ASI.Finding, asiFinding);
        }

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-asi')));
        
        if (testResult.ResultStatus.StateNumber < 4) {
            if (testResult.UnableScreenReason == null && testResult.ASI == null && testResult.Pattern == null && testResult.PressureReadings.PulsePressure == null
                && testResult.PressureReadings.Pulse == null && testResult.TechnicianNotes.length < 1
                && testResult.ConductedByOrgRoleUserId == "0" && $("#DescribeSelfPresentASIInputCheck").attr("checked") == false)
                return null;
        }

        return testResult;
    }
}



function CalculateASIAverage() {
    var sumVal = 0;
    var index = 0;

    $(".append-input input.asi-raw-reading").each(function () {
        if ($.trim($(this).val()).length > 0)
            sumVal = sumVal + Number($.trim($(this).val()));
        else
            return;

        index++;
    });

    var averageAsi = 0;
    if (index > 0) {
        averageAsi = parseInt(sumVal / index);
        $("#AverageASIValContainerSPAN").empty();
        $("#AverageASIValContainerSPAN").append("Averaged ASI: " + averageAsi);
    }
    return averageAsi;
}



var listAsiReadingsforUpdateonLast = null;
function UpdateASIReadings() {
    var arrAsiRawReadings = new Array();
    $(".append-input input.asi-raw-reading").each(function () {
        if ($.trim($(this).val()).length > 0)
            arrAsiRawReadings.push($.trim($(this).val()));
    });

    if (arrAsiRawReadings.length > 1)
        listAsiReadingsforUpdateonLast = arrAsiRawReadings;

    ReturnSuccess();
}


function ReturnSuccess() {
    var ASIaverage = CalculateASIAverage();

    if (ASIaverage > 0) {
        $("#AsiInputtext").val(ASIaverage);
        $("#AsiInputtext").change();
    }
    else
        $("#AsiInputtext").val('');

    var stringAsiRawReadingHtml = '';
    stringAsiRawReadingHtml = "<br /> <i> Averaged (";

    var commaSeperatedAsiReadings = '';
    var index = 0;

    $(".append-input input.asi-raw-reading").each(function () {
        if ($.trim($(this).val()).length > 0) {
            commaSeperatedAsiReadings += Number($(this).val()) + ", ";
            index++;
        }
    });

    commaSeperatedAsiReadings = commaSeperatedAsiReadings.substring(0, commaSeperatedAsiReadings.lastIndexOf(", "));

    stringAsiRawReadingHtml += commaSeperatedAsiReadings + ") </i>";
    $("#ASIRawReadingSpan").empty();
    if (index > 1)
        $("#ASIRawReadingSpan").append("<a href='javascript:LoadASIAveragingJTip(\"" + commaSeperatedAsiReadings + "\");'>" + stringAsiRawReadingHtml + "</a>");
    else
        $("#ASIRawReadingSpan").append("<a href='javascript:LoadASIAveragingJTip(\"\");'> Calculate ASI Average </a>");

    $('#ASIAverageFeatureContainerDiv').dialog('close');
    $("#AsiInputtext").focus();
    $("#AsiInputtext").blur();
}


function ReturnTimeOut() {
    alert("Request timeout occurred. Please try again or restart the application to get the requested task done.");
}


function ReturnError() {
    alert("Error occurred while processing your request. Please try again or restart the application to get the requested task done.");
}


function AddMoreReadingBox() {
    $(".append-input").append("<input type=\"text\" onkeydown=\"return KeyPress_NumericAllowedOnly(event);\" class=\"input_bdrbot asi-raw-reading\" style=\"width: 80px\" />");
}


function LoadASIAveragingJTip(commaSeperatedAsiReadings) {
    $(".append-input").empty();

    if ($.trim(commaSeperatedAsiReadings).length > 0) {
        var arrAsiReadings = commaSeperatedAsiReadings.split(",");
        var index = 0;

        while (index < arrAsiReadings.length) {
            $(".append-input").append("<input type=\"text\" onkeydown=\"return KeyPress_NumericAllowedOnly(event);\" class=\"input_bdrbot asi-raw-reading\" value=\"" + $.trim(arrAsiReadings[index]) + "\" style=\"width: 80px\" />");
            index++;
        }
        AddMoreReadingBox();
    }
    else {
        $(".append-input").append("<input type=\"text\" onkeydown=\"return KeyPress_NumericAllowedOnly(event);\" class=\"input_bdrbot asi-raw-reading\" value=\"" + $("#AsiInputtext").val() + "\" style=\"width: 80px\" />");
        AddMoreReadingBox();
        AddMoreReadingBox();
    }

    CalculateASIAverage();
    $('#ASIAverageFeatureContainerDiv').dialog('open');
}


$(document).ready(function () {
    if (currentScreenMode != ScreenMode.Physician) {
        $('#ASIAverageFeatureContainerDiv').dialog({ width: 290, height: 200, autoOpen: false, resizable: false, draggable: false });
    }

    $("#AsiInputtext").change(function () {
        autoSelectFinding($(".gv-findings-asi"), $("#AsiInputtext"));
    });
});

var criticalDataModel_Asi = null;
function onClick_CriticalDataAsi() {
    if ($("#DescribeSelfPresentASIInputCheck").attr("checked")) {
        loadCriticalLink($("#asi-critical-span"), "onClick_CriticalDataAsi();", testTypeAsi);
        openCriticalDataDialog(testTypeAsi, $("#conductedbyasi"), $("#DescribeSelfPresentASIInputCheck"), setCriticalDataModel_Asi);
    }
    else {
        unloadCriticalLink($("#asi-critical-span"), testTypeAsi);
    }
}

function setCriticalDataModel_Asi(model, printAfterSave) {
    if (model != null) {
        var testResult = GetAsiData();
        saveSingleTestResult(testResult, model, $("#asi-critical-span"), "onClick_CriticalDataAsi();", SetAsiData, printAfterSave);
    }
}

function getCriticalDataModel_Asi() {
    if ($("#DescribeSelfPresentASIInputCheck").attr("checked") && criticalDataModel_Asi != null) {
        criticalDataModel_Asi.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_Asi;
    }
    return null;
}

//asi-critical-span
function onClick_PriorityInQueueDataAsi() {
    if ($("#PriorityInQueueTestAsiCheck").attr("checked")) {
        loadPriorityInQueueLink($("#Asi-priorityInQueue-span"), "onClick_PriorityInQueueDataAsi();", testTypeAsi);
        openPriorityInQueueTestDialog(testTypeAsi, $("#conductedbyAsi"), $("#PriorityInQueueTestAsiCheck"), setPriorityInQueueDataModel_Asi);
    }
    else {
        unloadPriorityInQueueLink($("#Asi-priorityInQueue-span"), testTypeAsi);
    }
}

function setPriorityInQueueDataModel_Asi(model) {
    if (model != null) {
        var testResult = GetAsiData();
        model.TestId = testTypeAsi;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#Asi-priorityInQueue-span"), "onClick_PriorityInQueueDataAsi();", SetAsiData);
    }
}

function checkAsiData() {
    var text = "";
    
    if ($(".dtl-unabletoscreen-asi").find("input[type='checkbox']:checked").length > 0)
        return text;
    
    var asiTestResult = GetAsiData();
    if (asiTestResult != null) {
        if (asiTestResult.ASI == null || asiTestResult.ASI == "")
            text += "ASI value is missing.";
        
        if (asiTestResult.Pattern == null || asiTestResult.Pattern == "")
            text += " Pattern value is missing.";

        if (text != "")
            text = "ASI Test - " + text;
    }
    return text;
}

function clearAllAsiSelection() {
    $(".gv-findings-asi input[type=radio]").attr("checked", false);
}