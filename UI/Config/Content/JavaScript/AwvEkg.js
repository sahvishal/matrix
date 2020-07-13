function AwvEkg(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = {
            "Id": 0, "TestType": testTypeAwvEkg,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": '0',
            "UnableScreenReason": new Array(),
            "TestPerformedExternally": null,
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": {
                "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentAwvEkgInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestAwvEkgCheck").attr("checked")
            }
        };
    }
    this.Result = testResult;
}

AwvEkg.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (IsawvEkgResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_awvEkgcapturebyChat", testResult.TestPerformedExternally)
        }
        
        setboolTypeReading($("#AwvEkgSinusRythmInputCheck"), testResult.SinusRythm);
        setboolTypeReading($("#AwvEkgSinusArrythmiaInputCheck"), testResult.SinusArrythmia);
        setboolTypeReading($("#AwvEkgSinusBradycardiaInputCheck"), testResult.SinusBradycardia);
        setboolTypeReading($("#AwvEkgMildInputCheck"), testResult.Mild);
        setboolTypeReading($("#AwvEkgMarkedInputCheck"), testResult.Marked);
        setboolTypeReading($("#AwvEkgSinusTachycardiaInputCheck"), testResult.SinusTachycardia);
        setboolTypeReading($("#AwvEkgAtrialFibrillationInputCheck"), testResult.AtrialFibrillation);
        setboolTypeReading($("#AwvEkgAtrialFlutterInputCheck"), testResult.AtrialFlutter);
        setboolTypeReading($("#AwvEkgSupraventriculaCheckbox"), testResult.SupraventricularArrythmia);
        setboolTypeReading($("#AwvEkgSvtInputCheck"), testResult.SVT);
        setboolTypeReading($("#AwvEkgPacInputCheck"), testResult.PACs);
        setboolTypeReading($("#AwvEkgPvcInputCheck"), testResult.PVCs);
        setboolTypeReading($("#AwvEkgPacerRythmCheckbox"), testResult.PacerRythm);

        setboolTypeReading($("#AwvEkgBundleBranchBlockCheckbox"), testResult.BundleBranchBlock);
        setboolTypeReading($("#AwvEkgLeftAnteriorfasicularBlockCheckbox"), testResult.LeftAnteriorFasicularBlock);
        setboolTypeReading($("#AwvEkgVentricularCheckbox"), testResult.VentricularHypertrophy);
        setboolTypeReading($("#AwvEkgLeftVentricularCheckbox"), testResult.LeftVentricularHypertrophy);
        setboolTypeReading($("#AwvEkgRightVentricularCheckbox"), testResult.RightVentricularHypertrophy);
        setboolTypeReading($("#AwvEkgISchemicSttCheckbox"), testResult.IschemicSTTChanges);
        setboolTypeReading($("#AwvEkgNonSpecificSttCheckbox"), testResult.NonSpecificSTTChanges);
        setboolTypeReading($("#AwvEkgPoorRWaveProgressionCheckbox"), testResult.PoorRWaveProgression);
        setboolTypeReading($("#AwvEkgProlongedQTCheckbox"), testResult.ProlongedQTInterval);
        setboolTypeReading($("#AwvEkgInfarctionPatternCheckbox"), testResult.InfarctionPattern);

        setboolTypeReading($("#AwvEkgATypicalWaveCheckbox"), testResult.AtypicalQWaveLead);
        setboolTypeReading($("#AwvEkgAtrialEnlargementCheckbox"), testResult.AtrialEnlargement);
        setboolTypeReading($("#AwvEkgLeftAtrialCheckbox"), testResult.LeftAtrialEnlargement);
        setboolTypeReading($("#AwvEkgRightAtrialCheckbox"), testResult.RightAtrialEnlargement);
        setboolTypeReading($("#AwvEkgRepolarizationCheckbox"), testResult.RepolarizationVariant);

        setboolTypeReading($("#AwvEkgQrsWideningInputCheck"), testResult.QRSWidening);
        setboolTypeReading($("#AwvEkgLeftAxisInputCheck"), testResult.LeftAxis);
        setboolTypeReading($("#AwvEkgRightAxisInputCheck"), testResult.RightAxis);
        setboolTypeReading($("#AwvEkgAbnormalAxisInputCheck"), testResult.AbnormalAxis);
        setboolTypeReading($("#AwvEkgLeftInputCheck"), testResult.Left);
        setboolTypeReading($("#AwvEkgRightInputCheck"), testResult.Right);
        setboolTypeReading($("#AwvEkgHeartBlockInputCheck"), testResult.HeartBlock);
        setboolTypeReading($("#TypeIInputCheck"), testResult.TypeI);
        setboolTypeReading($("#AwvEkgTypeIIInputCheck"), testResult.TypeII);
        setboolTypeReading($("#AwvEkgFirstDegreeBlockInputCheck"), testResult.FirstDegreeBlock);
        setboolTypeReading($("#AwvEkgSecondDegreeBlockCheckbox"), testResult.SecondDegreeBlock);
        setboolTypeReading($("#AwvEkgThirdDegreeBlockInputCheck"), testResult.ThirdDegreeCompleteHeartBlock);
        setboolTypeReading($("#AwvEkgArtifactInputCheck"), testResult.Artifact);
        setboolTypeReading($("#AwvEkgRepeatStudyInputCheck"), testResult.RepeatStudy);
        setboolTypeReading($("#AwvEkgReversedLeadInputCheck"), testResult.ReversedLeads);
        setboolTypeReading($("#AwvEkgComparedtoPrevEkgInputCheck"), testResult.ComparetoEkg);

        setboolTypeReading($("#AwvEkgLowVoltageCheckbox"), testResult.LowVoltage);
        setboolTypeReading($("#AwvEkgLimbLeadsCheckbox"), testResult.LimbLeads);
        setboolTypeReading($("#AwvEkgPrecordialLeadsCheckbox"), testResult.PrecordialLeads);

        setMultipleFindingDatalist($('.AwvEkg-bundle-branch-finding'), testResult.BundleBranchBlockFinding);
        setMultipleFindingDatalist($('.AwvEkg-infarction-pattern-finding'), testResult.InfarctionPatternFinding);


        setboolTypeReading($('#AwvEkgShortPrIntervalInputCheck'), testResult.ShortPrInterval);
        
        $("#DescribeSelfPresentAwvEkgInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);
        $("#PriorityInQueueTestAwvEkgCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#awvEkg-priorityInQueue-span"), "onClick_PriorityInQueueDataAwvEkg();", testTypeAwvEkg);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#awvEkg-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#AwvEkg-critical-span"), "onClick_CriticalDataAwvEkg();", testTypeAwvEkg);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#AwvEkg-critical-span").parent().addClass("red-band");
                $("#criticalAwvEkg").attr("checked", "checked");
            }
        }
        
        if (testResult.Finding != null) {
            setSelectedFindingDatalist($(".AwvEkg-finding-grid"), testResult.Finding.Id);
        }
        setUnableScreenReason($('.dtl-unabletoscreen-AwvEkg'), testResult.UnableScreenReason);
        setTestNotPerformedReasonForAwvEkg(testResult.TestNotPerformed);

        if (testResult.ResultImage != null) {
            var newImageArray = new Array();
            newImageArray.push(testResult.ResultImage);
            LoadNewImagesAwvEkg(newImageArray, true);
        }

        $("#technotesAwvEkg").val(testResult.TechnicianNotes);
        $("#conductedbyAwvEkg option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);

        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksAwvEkg").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpAwvEkg").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalAwvEkg").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }

    },
    getData: function () {
        var testResult = this.Result;
        if (IsawvEkgResultEntryExternaly == 'True') {
            testResult.TestPerformedExternally = getTestPerformedExternally("chk_awvEkgcapturebyChat", testResult.TestPerformedExternally)
        }
        
        if (currentScreenMode != ScreenMode.Entry) {
            testResult.SinusRythm = getboolTypeReading($("#AwvEkgSinusRythmInputCheck"), testResult.SinusRythm);
            testResult.SinusArrythmia = getboolTypeReading($("#AwvEkgSinusArrythmiaInputCheck"), testResult.SinusArrythmia);
            testResult.SinusBradycardia = getboolTypeReading($("#AwvEkgSinusBradycardiaInputCheck"), testResult.SinusBradycardia);
            testResult.Mild = getboolTypeReading($("#AwvEkgMildInputCheck"), testResult.Mild);
            testResult.Marked = getboolTypeReading($("#AwvEkgMarkedInputCheck"), testResult.Marked);
            testResult.SinusTachycardia = getboolTypeReading($("#AwvEkgSinusTachycardiaInputCheck"), testResult.SinusTachycardia);
            testResult.AtrialFibrillation = getboolTypeReading($("#AwvEkgAtrialFibrillationInputCheck"), testResult.AtrialFibrillation);
            testResult.AtrialFlutter = getboolTypeReading($("#AwvEkgAtrialFlutterInputCheck"), testResult.AtrialFlutter);
            testResult.SupraventricularArrythmia = getboolTypeReading($("#AwvEkgSupraventriculaCheckbox"), testResult.SupraventricularArrythmia);
            testResult.SVT = getboolTypeReading($("#AwvEkgSvtInputCheck"), testResult.SVT);
            testResult.PACs = getboolTypeReading($("#AwvEkgPacInputCheck"), testResult.PACs);
            testResult.PVCs = getboolTypeReading($("#AwvEkgPvcInputCheck"), testResult.PVCs);
            testResult.PacerRythm = getboolTypeReading($("#AwvEkgPacerRythmCheckbox"), testResult.PacerRythm);

            testResult.BundleBranchBlock = getboolTypeReading($("#AwvEkgBundleBranchBlockCheckbox"), testResult.BundleBranchBlock);
            testResult.LeftAnteriorFasicularBlock = getboolTypeReading($("#AwvEkgLeftAnteriorfasicularBlockCheckbox"), testResult.LeftAnteriorFasicularBlock);
            testResult.VentricularHypertrophy = getboolTypeReading($("#AwvEkgVentricularCheckbox"), testResult.VentricularHypertrophy);
            testResult.LeftVentricularHypertrophy = getboolTypeReading($("#AwvEkgLeftVentricularCheckbox"), testResult.LeftVentricularHypertrophy);
            testResult.RightVentricularHypertrophy = getboolTypeReading($("#AwvEkgRightVentricularCheckbox"), testResult.RightVentricularHypertrophy);
            testResult.IschemicSTTChanges = getboolTypeReading($("#AwvEkgISchemicSttCheckbox"), testResult.IschemicSTTChanges);
            testResult.NonSpecificSTTChanges = getboolTypeReading($("#AwvEkgNonSpecificSttCheckbox"), testResult.NonSpecificSTTChanges);
            testResult.PoorRWaveProgression = getboolTypeReading($("#AwvEkgPoorRWaveProgressionCheckbox"), testResult.PoorRWaveProgression);
            testResult.ProlongedQTInterval = getboolTypeReading($("#AwvEkgProlongedQTCheckbox"), testResult.ProlongedQTInterval);
            testResult.InfarctionPattern = getboolTypeReading($("#AwvEkgInfarctionPatternCheckbox"), testResult.InfarctionPattern);

            testResult.AtypicalQWaveLead = getboolTypeReading($("#AwvEkgATypicalWaveCheckbox"), testResult.AtypicalQWaveLead);
            testResult.AtrialEnlargement = getboolTypeReading($("#AwvEkgAtrialEnlargementCheckbox"), testResult.AtrialEnlargement);
            testResult.LeftAtrialEnlargement = getboolTypeReading($("#AwvEkgLeftAtrialCheckbox"), testResult.LeftAtrialEnlargement);
            testResult.RightAtrialEnlargement = getboolTypeReading($("#AwvEkgRightAtrialCheckbox"), testResult.RightAtrialEnlargement);
            testResult.RepolarizationVariant = getboolTypeReading($("#AwvEkgRepolarizationCheckbox"), testResult.RepolarizationVariant);

            testResult.QRSWidening = getboolTypeReading($("#AwvEkgQrsWideningInputCheck"), testResult.QRSWidening);
            testResult.LeftAxis = getboolTypeReading($("#AwvEkgLeftAxisInputCheck"), testResult.LeftAxis);
            testResult.RightAxis = getboolTypeReading($("#AwvEkgRightAxisInputCheck"), testResult.RightAxis);
            testResult.AbnormalAxis = getboolTypeReading($("#AwvEkgAbnormalAxisInputCheck"), testResult.AbnormalAxis);
            testResult.Left = getboolTypeReading($("#AwvEkgLeftInputCheck"), testResult.Left);
            testResult.Right = getboolTypeReading($("#AwvEkgRightInputCheck"), testResult.Right);
            testResult.HeartBlock = getboolTypeReading($("#AwvEkgHeartBlockInputCheck"), testResult.HeartBlock);
            testResult.TypeI = getboolTypeReading($("#TypeIInputCheck"), testResult.TypeI);
            testResult.TypeII = getboolTypeReading($("#AwvEkgTypeIIInputCheck"), testResult.TypeII);
            testResult.FirstDegreeBlock = getboolTypeReading($("#AwvEkgFirstDegreeBlockInputCheck"), testResult.FirstDegreeBlock);
            testResult.SecondDegreeBlock = getboolTypeReading($("#AwvEkgSecondDegreeBlockCheckbox"), testResult.SecondDegreeBlock);
            testResult.ThirdDegreeCompleteHeartBlock = getboolTypeReading($("#AwvEkgThirdDegreeBlockInputCheck"), testResult.ThirdDegreeCompleteHeartBlock);
            testResult.Artifact = getboolTypeReading($("#AwvEkgArtifactInputCheck"), testResult.Artifact);
            testResult.RepeatStudy = getboolTypeReading($("#AwvEkgRepeatStudyInputCheck"), testResult.RepeatStudy);
            testResult.ReversedLeads = getboolTypeReading($("#AwvEkgReversedLeadInputCheck"), testResult.ReversedLeads);
            testResult.ComparetoEkg = getboolTypeReading($("#AwvEkgComparedtoPrevEkgInputCheck"), testResult.ComparetoEkg);

            testResult.LowVoltage = getboolTypeReading($("#AwvEkgLowVoltageCheckbox"), testResult.LowVoltage);
            testResult.LimbLeads = getboolTypeReading($("#AwvEkgLimbLeadsCheckbox"), testResult.LimbLeads);
            testResult.PrecordialLeads = getboolTypeReading($("#AwvEkgPrecordialLeadsCheckbox"), testResult.PrecordialLeads);

            var bundleBranchBlock = getMultipleFindingDatalist($('.AwvEkg-bundle-branch-finding'));
            testResult.BundleBranchBlockFinding = getMultipleFindingDataandSynchronized(testResult.BundleBranchBlockFinding, bundleBranchBlock);

            var infarctionFinding = getMultipleFindingDatalist($('.AwvEkg-infarction-pattern-finding'));
            testResult.InfarctionPatternFinding = getMultipleFindingDataandSynchronized(testResult.InfarctionPatternFinding, infarctionFinding);

            testResult.ShortPrInterval = getboolTypeReading($("#AwvEkgShortPrIntervalInputCheck"), testResult.ShortPrInterval);

            var ekgFinding = getSelectedFindingDatalist($(".AwvEkg-finding-grid"));
            testResult.Finding = getFindingDataandSynchronized(testResult.Finding, ekgFinding);

            if (testResult.PhysicianInterpretation == null)
                testResult.PhysicianInterpretation = {
                    'Remarks': $("#physicianRemarksAwvEkg").val(), 'IsCritical': $("#criticalAwvEkg").attr("checked"), 'FollowUp': $("#followUpAwvEkg").attr("checked"), 'RecorderMetaData': {
                        'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate
                    }
                };
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksAwvEkg").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpAwvEkg").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalAwvEkg").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        } 

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-AwvEkg')));
        
        testResult.TestNotPerformed = getTestNotPerformedReasonForAwvEkg(testResult.TestNotPerformed);

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.ConductedByOrgRoleUserId = $("#conductedbyAwvEkg option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesAwvEkg").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentAwvEkgInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestAwvEkgCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_50").attr("checked");
        
        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }

        if (currentScreenMode != ScreenMode.Physician) {

            if (awvEkgResultMedia != null && awvEkgResultMedia.length > 0) {
                if (testResult.ResultImage == null)
                    testResult.ResultImage = awvEkgResultMedia[0];
                else {
                    var resultMedia = awvEkgResultMedia[0];
                    resultMedia.Id = testResult.ResultImage.Id;
                    resultMedia.File.Id = testResult.ResultImage.File.Id;
                    resultMedia.Thumbnail.Id = testResult.ResultImage.Thumbnail.Id;
                    testResult.ResultImage = resultMedia;
                }
            }
            else
                testResult.ResultImage = null;

            if (currentScreenMode != ScreenMode.CorrectionPostEvaluation && currentScreenMode != ScreenMode.PostAudit) testResult.ResultStatus.StateNumber = $("#ResultStatusInputHidden").val();

            if (testResult.ResultStatus.Id > 0) {
                testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.ResultStatus.DataRecorderMetaData.DateModified = currentDate;
            }
            else {
                testResult.ResultStatus.DataRecorderMetaData = { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate };
            }
        }

        if (testResult.ResultStatus.StateNumber < 4) {
            if (testResult.TechnicianNotes.length < 1 && testResult.ResultImage == null && testResult.IncidentalFindings == null && testResult.ConductedByOrgRoleUserId == "0"
                && testResult.UnableScreenReason == null && $("#DescribeSelfPresentAwvEkgInputCheck").attr("checked") == false)
                return null;
        }

        return testResult;
    }
}
var awvEkgImageCount = 0;
var awvEkgResultMedia = null;
function LoadNewImagesAwvEkg(jsonMedia, correctJson) {
    awvEkgResultMedia = jsonMedia;
    awvEkgImageCount = 0;
    $("#awvEkgImagesContainerDiv").empty();
    if (jsonMedia == null || jsonMedia.length < 1) return;
    awvEkgImageCount = jsonMedia.length;
    LoadNewMedia(jsonMedia, correctJson, $("#awvEkgImagesContainerDiv"));
}

var criticalDataModel_AwvEkg = null;
function onClick_CriticalDataAwvEkg() {
    if ($("#DescribeSelfPresentAwvEkgInputCheck").attr("checked")) {
        loadCriticalLink($("#AwvEkg-critical-span"), "onClick_CriticalDataAwvEkg();", testTypeAwvEkg);
        openCriticalDataDialog(testTypeAwvEkg, $("#conductedbyAwvEkg"), $("#DescribeSelfPresentAwvEkgInputCheck"), setCriticalDataModel_AwvEkg);
    }
    else {
        unloadCriticalLink($("#AwvEkg-critical-span"), testTypeAwvEkg);
    }
}

function setCriticalDataModel_AwvEkg(model, printAfterSave) {
    if (model != null) {
        var testResult = GetAwvEkgData();
        saveSingleTestResult(testResult, model, $("#AwvEkg-critical-span"), "onClick_CriticalDataAwvEkg();", SetAwvEkgData, printAfterSave);
    }
}

function getCriticalDataModel_AwvEkg() {
    if ($("#DescribeSelfPresentAwvEkgInputCheck").attr("checked") && criticalDataModel_AwvEkg != null) {
        criticalDataModel_AwvEkg.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_AwvEkg;
    }
    return null;
}

function onClick_PriorityInQueueDataAwvEkg() {
    if ($("#PriorityInQueueTestAwvEkgCheck").attr("checked")) {
        loadPriorityInQueueLink($("#awvEkg-priorityInQueue-span"), "onClick_PriorityInQueueDataAwvEkg();", testTypeAwvEkg);
        openPriorityInQueueTestDialog(testTypeAwvEkg, $("#conductedbyAwvEkg"), $("#PriorityInQueueTestAwvEkgCheck"), setPriorityInQueueDataModel_AwvEkg);
    }
    else {
        unloadPriorityInQueueLink($("#awvEkg-priorityInQueue-span"), testTypeAwvEkg);
    }
}

function setPriorityInQueueDataModel_AwvEkg(model) {
    if (model != null) {
        var testResult = GetAwvEkgData();
        model.TestId = testTypeAwvEkg;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#awvEkg-priorityInQueue-span"), "onClick_PriorityInQueueDataAwvEkg();", SetAwvEkgData);
    }
} 
function clearAllAwvEkgSelection() {
    $(".clear-all-AwvEkg-selection input[type=radio], .clear-all-AwvEkg-selection input[type=checkbox]").attr("checked", false);
}


function setTestNotPerformedReasonForAwvEkg(testNotPerformed) {
    setTestNotPerformed("testnotPerformedAwvEkg", testNotPerformed);
    SetTestNotPerformedEnableDisabled("testnotPerformedAwvEkg");
}

function getTestNotPerformedReasonForAwvEkg(testNotPerformed) {
    return getTestNotPerformed("testnotPerformedAwvEkg", testNotPerformed);
}

function getAwvEkgMedia() {
    return awvEkgResultMedia;
}