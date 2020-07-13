function MenBloodPanel(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = {
            "Id": 0, "TestType": testTypeMenBloodPanel,
            "PSASCR": null, "TechnicianNotes": '', "ConductedByOrgRoleUserId": '0',
            "UnableScreenReason": new Array(),
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": { "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentMenBloodPanelInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestMenBloodPanelCheck").attr("checked")
            },
            "TestPerformedExternally": null
        };
    }
    this.Result = testResult;
}

MenBloodPanel.prototype = {
    setData: function () {
        var testResult = this.Result;

        if (isMenBloodPanelResultEntryType == 'True') {
            setTestPerformedExternally("chk_MenBloodPanelcapturebyChat", testResult.TestPerformedExternally)
        }
        setReading($("#menBloodPanelPSASCRtextbox"), testResult.PSASCR);
        setReading($("#menBloodPanelLCRPtextbox"), testResult.LCRP);
        setReading($("#menBloodPanelTESTSCREtextbox"), testResult.TESTSCRE);
        $("#DescribeSelfPresentMenBloodPanelInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);

        $("#technotesMenBloodPanel").val(testResult.TechnicianNotes);
        $("#conductedbyMenBloodPanel option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);

        setboolTypeReading($('#technicallyltdbutreadableMenBloodPanelinputcheck'), testResult.TechnicallyLimitedbutReadable);
        setboolTypeReading($('#repeatstudyMenBloodPanelinputcheck'), testResult.RepeatStudy);

        setUnableScreenReason($('.dtl-unabletoscreen-menBloodPanel'), testResult.UnableScreenReason);
        $("#PriorityInQueueTestMenBloodPanelCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#menBloodPanel-priorityInQueue-span"), "onClick_PriorityInQueueDataMenBloodPanel();", testTypeMenBloodPanel);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#menBloodPanel-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#menBloodPanel-critical-span"), "onClick_CriticalDataMenBloodPanel();", testTypeMenBloodPanel);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#menBloodPanel-critical-span").parent().addClass("red-band");
                $("#criticalMenBloodPanel").attr("checked", "checked");
            }
        }

        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksMenBloodPanel").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpMenBloodPanel").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalMenBloodPanel").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }
		
    },
    getData: function () {
        var testResult = this.Result;

        if (isMenBloodPanelResultEntryType == 'True') {
            testResult.TestPerformedExternally = getTestPerformedExternally("chk_MenBloodPanelcapturebyChat", testResult.TestPerformedExternally)
        }
        testResult.PSASCR = getReading($("#menBloodPanelPSASCRtextbox"), testResult.PSASCR);
        testResult.LCRP = getReading($("#menBloodPanelLCRPtextbox"), testResult.LCRP);
        testResult.TESTSCRE = getReading($("#menBloodPanelTESTSCREtextbox"), testResult.TESTSCRE);
        
        if (currentScreenMode != ScreenMode.Physician) {

            //testResult.PSASCR = getReading($("#menBloodPanelPSASCRtextbox"), testResult.PSASCR);
            //testResult.LCRP = getReading($("#menBloodPanelLCRPtextbox"), testResult.LCRP);
            //testResult.TESTSCRE = getReading($("#menBloodPanelTESTSCREtextbox"), testResult.TESTSCRE);

            if (currentScreenMode != ScreenMode.CorrectionPostEvaluation && currentScreenMode != ScreenMode.PostAudit) testResult.ResultStatus.StateNumber = $("#ResultStatusInputHidden").val();

            if (testResult.ResultStatus.Id > 0) {
                testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.ResultStatus.DataRecorderMetaData.DateModified = currentDate;
            }
            else {
                testResult.ResultStatus.DataRecorderMetaData = { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate };
            }
        }

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-menBloodPanel')));
        
        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.ConductedByOrgRoleUserId = $("#conductedbyMenBloodPanel option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesMenBloodPanel").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentMenBloodPanelInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestMenBloodPanelCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_64").attr("checked");

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }

        if (currentScreenMode != ScreenMode.Entry) {

            testResult.RepeatStudy = getboolTypeReading($('#repeatstudyMenBloodPanelinputcheck'), testResult.RepeatStudy);
            testResult.TechnicallyLimitedbutReadable = getboolTypeReading($('#technicallyltdbutreadableMenBloodPanelinputcheck'), testResult.TechnicallyLimitedbutReadable);

            if (testResult.PhysicianInterpretation == null)
                testResult.PhysicianInterpretation = {
                    'Remarks': $("#physicianRemarksMenBloodPanel").val(), 'IsCritical': $("#criticalMenBloodPanel").attr("checked"), 'FollowUp': $("#followUpMenBloodPanel").attr("checked"), 'RecorderMetaData': {
                        'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate
                    }
                };
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksMenBloodPanel").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpMenBloodPanel").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalMenBloodPanel").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }

        if (testResult.ResultStatus.StateNumber < 4) {
            if (testResult.MenBloodPanelSCR == null && testResult.TechnicianNotes.length < 1 && testResult.ConductedByOrgRoleUserId == "0" && testResult.UnableScreenReason == null && $("#DescribeSelfPresentMenBloodPanelInputCheck").attr("checked") == false)
                return null;
        }

        return testResult;
    }
}


var criticalDataModel_MenBloodPanel = null;
function onClick_CriticalDataMenBloodPanel() {
    if ($("#DescribeSelfPresentMenBloodPanelInputCheck").attr("checked")) {
        loadCriticalLink($("#menBloodPanel-critical-span"), "onClick_CriticalDataMenBloodPanel();", testTypeMenBloodPanel);
        openCriticalDataDialog(testTypeMenBloodPanel, $("#conductedbyMenBloodPanel"), $("#DescribeSelfPresentMenBloodPanelInputCheck"), setCriticalDataModel_MenBloodPanel);
    }
    else {
        unloadCriticalLink($("#menBloodPanel-critical-span"), testTypeMenBloodPanel);
    }
}

function setCriticalDataModel_MenBloodPanel(model, printAfterSave) {
    if (model != null) {
        var testResult = GetMenBloodPanelData();
        saveSingleTestResult(testResult, model, $("#menBloodPanel-critical-span"), "onClick_CriticalDataMenBloodPanel();", SetMenBloodPanelData, printAfterSave);
    }
}

function getCriticalDataModel_MenBloodPanel() {
    if ($("#DescribeSelfPresentMenBloodPanelInputCheck").attr("checked") && criticalDataModel_MenBloodPanel != null) {
        criticalDataModel_MenBloodPanel.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_MenBloodPanel;
    }
    return null;
}


function onClick_PriorityInQueueDataMenBloodPanel() {
    if ($("#PriorityInQueueTestMenBloodPanelCheck").attr("checked")) {
        loadPriorityInQueueLink($("#menBloodPanel-priorityInQueue-span"), "onClick_PriorityInQueueDataMenBloodPanel();", testTypeMenBloodPanel);
        openPriorityInQueueTestDialog(testTypeMenBloodPanel, $("#conductedbyMenBloodPanel"), $("#PriorityInQueueTestMenBloodPanelCheck"), setPriorityInQueueDataModel_MenBloodPanel);
    }
    else {
        unloadPriorityInQueueLink($("#menBloodPanel-priorityInQueue-span"), testTypeMenBloodPanel);
    }
}

function setPriorityInQueueDataModel_MenBloodPanel(model) {
    if (model != null) {
        var testResult = GetMenBloodPanelData();
        model.TestId = testTypeMenBloodPanel;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#menBloodPanel-priorityInQueue-span"), "onClick_PriorityInQueueDataMenBloodPanel();", SetMenBloodPanelData);
    }
}