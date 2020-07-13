function WomenBloodPanel(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = {
            "Id": 0, "TestType": testTypeWomenBloodPanel,
            "PSASCR": null, "TechnicianNotes": '', "ConductedByOrgRoleUserId": '0',
            "UnableScreenReason": new Array(),
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "TestPerformedExternally": null,
            "ResultStatus": { "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentWomenBloodPanelInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestWomenBloodPanelCheck").attr("checked")
            }
        };
    }
    this.Result = testResult;
}

WomenBloodPanel.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (IswomenBloodPanelResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_womenBloodPanelcapturebyChat", testResult.TestPerformedExternally)
        }
        
        setReading($("#WomenBloodPanelTSHSCRtextbox"), testResult.TSHSCR);
        setReading($("#WomenBloodPanelLCRPtextbox"), testResult.LCRP);
        setReading($("#WomenBloodPanelVitDtextbox"), testResult.VitD);

        $("#DescribeSelfPresentWomenBloodPanelInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);

        $("#technotesWomenBloodPanel").val(testResult.TechnicianNotes);
        $("#conductedbyWomenBloodPanel option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);

        setboolTypeReading($('#technicallyltdbutreadableWomenBloodPanelinputcheck'), testResult.TechnicallyLimitedbutReadable);
        setboolTypeReading($('#repeatstudyWomenBloodPanelinputcheck'), testResult.RepeatStudy);

        setUnableScreenReason($('.dtl-unabletoscreen-menBloodPanel'), testResult.UnableScreenReason);
        $("#PriorityInQueueTestWomenBloodPanelCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#womenBloodPanel-priorityInQueue-span"), "onClick_PriorityInQueueDataWomenBloodPanel();", testTypeWomenBloodPanel);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#womenBloodPanel-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#womenBloodPanel-critical-span"), "onClick_CriticalDataWomenBloodPanel();", testTypeWomenBloodPanel);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#womenBloodPanel-critical-span").parent().addClass("red-band");
                $("#criticalWomenBloodPanel").attr("checked", "checked");
            }
        }

        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksWomenBloodPanel").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpWomenBloodPanel").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalWomenBloodPanel").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }
		
    },
    getData: function () {
        var testResult = this.Result;
        if (IswomenBloodPanelResultEntryExternaly == 'True') {
            testResult.TestPerformedExternally = getTestPerformedExternally("chk_womenBloodPanelcapturebyChat", testResult.TestPerformedExternally)
        }
        
        testResult.TSHSCR = getReading($("#WomenBloodPanelTSHSCRtextbox"), testResult.TSHSCR);
        testResult.LCRP = getReading($("#WomenBloodPanelLCRPtextbox"), testResult.LCRP);
        testResult.VitD = getReading($("#WomenBloodPanelVitDtextbox"), testResult.VitD);

        if (currentScreenMode != ScreenMode.Physician) {

            //testResult.TSHSCR = getReading($("#WomenBloodPanelTSHSCRtextbox"), testResult.TSHSCR);
            //testResult.LCRP = getReading($("#WomenBloodPanelLCRPtextbox"), testResult.LCRP);
            //testResult.VitD = getReading($("#WomenBloodPanelVitDtextbox"), testResult.VitD);

            if (currentScreenMode != ScreenMode.CorrectionPostEvaluation && currentScreenMode != ScreenMode.PostAudit) testResult.ResultStatus.StateNumber = $("#ResultStatusInputHidden").val();

            if (testResult.ResultStatus.Id > 0) {
                testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.ResultStatus.DataRecorderMetaData.DateModified = currentDate;
            }
            else {
                testResult.ResultStatus.DataRecorderMetaData = { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate };
            }
        }

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-womenBloodPanel')));
        
        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.ConductedByOrgRoleUserId = $("#conductedbyWomenBloodPanel option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesWomenBloodPanel").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentWomenBloodPanelInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestWomenBloodPanelCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_65").attr("checked");

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }

        if (currentScreenMode != ScreenMode.Entry) {

            testResult.RepeatStudy = getboolTypeReading($('#repeatstudyWomenBloodPanelinputcheck'), testResult.RepeatStudy);
            testResult.TechnicallyLimitedbutReadable = getboolTypeReading($('#technicallyltdbutreadableWomenBloodPanelinputcheck'), testResult.TechnicallyLimitedbutReadable);

            if (testResult.PhysicianInterpretation == null)
                testResult.PhysicianInterpretation = {
                    'Remarks': $("#physicianRemarksWomenBloodPanel").val(), 'IsCritical': $("#criticalWomenBloodPanel").attr("checked"), 'FollowUp': $("#followUpWomenBloodPanel").attr("checked"), 'RecorderMetaData': {
                        'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate
                    }
                };
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksWomenBloodPanel").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpWomenBloodPanel").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalWomenBloodPanel").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }

        if (testResult.ResultStatus.StateNumber < 4) {
            if (testResult.WomenBloodPanelSCR == null && testResult.TechnicianNotes.length < 1 && testResult.ConductedByOrgRoleUserId == "0" && testResult.UnableScreenReason == null && $("#DescribeSelfPresentWomenBloodPanelInputCheck").attr("checked") == false)
                return null;
        }

        return testResult;
    }
}


var criticalDataModel_MenBloodPanel = null;
function onClick_CriticalDataWomenBloodPanel() {
    if ($("#DescribeSelfPresentWomenBloodPanelInputCheck").attr("checked")) {
        loadCriticalLink($("#womenBloodPanel-critical-span"), "onClick_CriticalDataWomenBloodPanel();", testTypeWomenBloodPanel);
        openCriticalDataDialog(testTypeWomenBloodPanel, $("#conductedbyWomenBloodPanel"), $("#DescribeSelfPresentWomenBloodPanelInputCheck"), setCriticalDataModel_WomenBloodPanel);
    }
    else {
        unloadCriticalLink($("#womenBloodPanel-critical-span"), testTypeWomenBloodPanel);
    }
}

function setCriticalDataModel_WomenBloodPanel(model, printAfterSave) {
    if (model != null) {
        var testResult = GetWomenBloodPanelData();
        saveSingleTestResult(testResult, model, $("#womenBloodPanel-critical-span"), "onClick_CriticalDataWomenBloodPanel();", SetWomenBloodPanelData, printAfterSave);
    }
}

function getCriticalDataModel_WomenBloodPanel() {
    if ($("#DescribeSelfPresentWomenBloodPanelInputCheck").attr("checked") && criticalDataModel_WomenBloodPanel != null) {
        criticalDataModel_WomenBloodPanel.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_WomenBloodPanel;
    }
    return null;
}

function onClick_PriorityInQueueDataWomenBloodPanel() {
    if ($("#PriorityInQueueTestWomenBloodPanelCheck").attr("checked")) {
        loadPriorityInQueueLink($("#womenBloodPanel-priorityInQueue-span"), "onClick_PriorityInQueueDataWomenBloodPanel();", testTypeWomenBloodPanel);
        openPriorityInQueueTestDialog(testTypeWomenBloodPanel, $("#conductedbyWomenBloodPanel"), $("#PriorityInQueueTestWomenBloodPanelCheck"), setPriorityInQueueDataModel_WomenBloodPanel);
    }
    else {
        unloadPriorityInQueueLink($("#womenBloodPanel-priorityInQueue-span"), testTypeWomenBloodPanel);
    }
}

function setPriorityInQueueDataModel_WomenBloodPanel(model) {
    if (model != null) {
        var testResult = GetWomenBloodPanelData();
        model.TestId = testTypeWomenBloodPanel;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#womenBloodPanel-priorityInQueue-span"), "onClick_PriorityInQueueDataWomenBloodPanel();", SetWomenBloodPanelData);
    }
}