function Imt(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = { "Id": 0, "TestType": testTypeImt,
            "QimtLeft": null,
            "QimtRight": null,
            "ExpectedQimt": null,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": "0",
            "Finding": null,
            "ResultMedia": null,
            "TestPerformedExternally": null,
            "UnableScreenReason": new Array(),
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": { "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentImtInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestImtCheck").attr("checked")
            }
        };
    }
    this.Result = testResult;
}

Imt.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (IsimtResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_imtcapturebyChat", testResult.TestPerformedExternally)
        }

        if (testResult.Finding != null) {
            setSelectedFinding($(".gv-findings-imt"), testResult.Finding.Id);
        }

        if (testResult.ResultMedia && testResult.ResultMedia.length > 0) {
            LoadNewImagesImt(testResult.ResultMedia, true);
        }

        setReading($("#qimtlefttextbox"), testResult.QimtLeft);
        setReading($("#qimtrighttextbox"), testResult.QimtRight);
        setReading($("#expectedqimttextbox"), testResult.ExpectedQimt);

        setUnableScreenReason($('.dtl-unabletoscreen-imt'), testResult.UnableScreenReason);

        $("#DescribeSelfPresentImtInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);

        $("#technotesimt").val(testResult.TechnicianNotes);
        $("#conductedbyimt option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);

        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksImt").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpImt").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalImt").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }

        $("#PriorityInQueueTestImtCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#imt-priorityInQueue-span"), "onClick_PriorityInQueueDataImt();", testTypeImt);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#imt-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#imt-critical-span"), "onClick_CriticalDataImt();", testTypeImt);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#imt-critical-span").parent().addClass("red-band");
                $("#criticalImt").attr("checked", "checked");
            }
        }
		
    },
    getData: function () {
        var testResult = this.Result;

        if (IsimtResultEntryExternaly == 'True') {
             testResult.TestPerformedExternally = getTestPerformedExternally("chk_imtcapturebyChat", testResult.TestPerformedExternally)
        }

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-imt')));

        testResult.QimtLeft = getReading($("#qimtlefttextbox"), testResult.QimtLeft);
        testResult.QimtRight = getReading($("#qimtrighttextbox"), testResult.QimtRight);
        testResult.ExpectedQimt = getReading($("#expectedqimttextbox"), testResult.ExpectedQimt);

        if (currentScreenMode != ScreenMode.Physician) {
            //testResult.QimtLeft = getReading($("#qimtlefttextbox"), testResult.QimtLeft);
            //testResult.QimtRight = getReading($("#qimtrighttextbox"), testResult.QimtRight);
            //testResult.ExpectedQimt = getReading($("#expectedqimttextbox"), testResult.ExpectedQimt);

            if (currentScreenMode != ScreenMode.CorrectionPostEvaluation) testResult.ResultStatus.StateNumber = $("#ResultStatusInputHidden").val();

            if (testResult.ResultStatus.Id > 0) {
                testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.ResultStatus.DataRecorderMetaData.DateModified = currentDate;
            }
            else {
                testResult.ResultStatus.DataRecorderMetaData = { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate };
            }

            var resultMedia = new Array();
            if (imtResultMedia != null) {
                $.each(imtResultMedia, function () { resultMedia.push(this); });
            }
            testResult.ResultMedia = resultMedia;
        }

        testResult.Finding = getFindingDataandSynchronized(testResult.Finding, getSelectedFinding($(".gv-findings-imt")));
        
        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.ConductedByOrgRoleUserId = $("#conductedbyimt option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesimt").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentImtInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestImtCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_8").attr("checked");

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }

        if (currentScreenMode != ScreenMode.Entry) {
            if (testResult.PhysicianInterpretation == null)
                testResult.PhysicianInterpretation = { 'Remarks': $("#physicianRemarksImt").val(), 'IsCritical': $("#criticalImt").attr("checked"), 'FollowUp': $("#followUpImt").attr("checked"), 'RecorderMetaData': {
                    'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate
                }
                };
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksImt").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpImt").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalImt").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }

        if (testResult.ResultStatus.StateNumber < 4) {
            //To Check if no entry has been done
            if (testResult.QimtLeft == null && testResult.Finding == null && testResult.QimtRight == null && testResult.ExpectedQimt == null && testResult.UnableScreenReason == null 
				&& testResult.TechnicianNotes.length < 1 && resultMedia.length < 1 && testResult.ConductedByOrgRoleUserId == "0" && $("#DescribeSelfPresentImtInputCheck").attr("checked") == false)
                return null;
        }


        return testResult;
    }
}

var ImtImageCount = 0;
var imtResultMedia = null;

function getImtMedia() {
    return imtResultMedia;
}

function LoadNewImagesImt(jsonMedia, correctJson) {
    imtResultMedia = jsonMedia;
    ImtImageCount = 0;
    $("#imtImagesContainerDiv").empty();
    if (jsonMedia == null || jsonMedia.length < 1) return;
    ImtImageCount = jsonMedia.length;
    LoadNewMedia(jsonMedia, correctJson, $("#imtImagesContainerDiv"));
}


var criticalDataModel_Imt = null;
function onClick_CriticalDataImt() {
    if ($("#DescribeSelfPresentImtInputCheck").attr("checked")) {
        loadCriticalLink($("#imt-critical-span"), "onClick_CriticalDataImt();", testTypeImt);
        openCriticalDataDialog(testTypeImt, $("#conductedbyimt"), $("#DescribeSelfPresentImtInputCheck"), setcriticalDataModel_Imt);
    }
    else {
        unloadCriticalLink($("#imt-critical-span"), testTypeImt);
    }
}

function setcriticalDataModel_Imt(model, printAfterSave) {
    if (model != null) {
        var testResult = GetImtData();
        saveSingleTestResult(testResult, model, $("#imt-critical-span"), "onClick_CriticalDataImt();", SetImtData, printAfterSave);
    }
}

function getcriticalDataModel_Imt() {
    if ($("#DescribeSelfPresentImtInputCheck").attr("checked") && criticalDataModel_Imt != null) {
        criticalDataModel_Imt.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_Imt;
    }
    return null;
}

function onClick_PriorityInQueueDataImt() {
    if ($("#PriorityInQueueTestImtCheck").attr("checked")) {
        loadPriorityInQueueLink($("#imt-priorityInQueue-span"), "onClick_PriorityInQueueDataImt();", testTypeImt);
        openPriorityInQueueTestDialog(testTypeImt, $("#conductedbyimt"), $("#PriorityInQueueTestImtCheck"), setPriorityInQueueDataModel_Imt);
    }
    else {
        unloadPriorityInQueueLink($("#imt-priorityInQueue-span"), testTypeImt);
    }
}

function setPriorityInQueueDataModel_Imt(model) {
    if (model != null) {
        var testResult = GetImtData();
        model.TestId = testTypeImt;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#imt-priorityInQueue-span"), "onClick_PriorityInQueueDataImt();", SetImtData);
    }
}