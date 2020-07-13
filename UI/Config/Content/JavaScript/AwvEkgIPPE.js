function AwvEkgIPPE(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = {
            "Id": 0, "TestType": testTypeAwvEkgIPPE,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": '0',
            "UnableScreenReason": new Array(),
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "TestPerformedExternally": null,
            "ResultStatus": {
                "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentAwvEkgIPPEInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestAwvEkgIPPECheck").attr("checked")
            }
        };
    }
    this.Result = testResult;
}

AwvEkgIPPE.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (IsawvEkgIPPEResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_AwvEkgIPPEcapturebyChat", testResult.TestPerformedExternally)
        }

        setboolTypeReading($("#AwvEkgIppeSinusRythmInputCheck"), testResult.SinusRythm);
        setboolTypeReading($("#AwvEkgIppeSinusArrythmiaInputCheck"), testResult.SinusArrythmia);
        setboolTypeReading($("#AwvEkgIppeSinusBradycardiaInputCheck"), testResult.SinusBradycardia);
        setboolTypeReading($("#AwvEkgIppeMildInputCheck"), testResult.Mild);
        setboolTypeReading($("#AwvEkgIppeMarkedInputCheck"), testResult.Marked);
        setboolTypeReading($("#AwvEkgIppeSinusTachycardiaInputCheck"), testResult.SinusTachycardia);
        setboolTypeReading($("#AwvEkgIppeAtrialFibrillationInputCheck"), testResult.AtrialFibrillation);
        setboolTypeReading($("#AwvEkgIppeAtrialFlutterInputCheck"), testResult.AtrialFlutter);
        setboolTypeReading($("#AwvEkgIppeSupraventriculaCheckbox"), testResult.SupraventricularArrythmia);
        setboolTypeReading($("#AwvEkgIppeSvtInputCheck"), testResult.SVT);
        setboolTypeReading($("#AwvEkgIppePacInputCheck"), testResult.PACs);
        setboolTypeReading($("#AwvEkgIppePvcInputCheck"), testResult.PVCs);
        setboolTypeReading($("#AwvEkgIppePacerRythmCheckbox"), testResult.PacerRythm);

        setboolTypeReading($("#AwvEkgIppeBundleBranchBlockCheckbox"), testResult.BundleBranchBlock);
        setboolTypeReading($("#AwvEkgIppeLeftAnteriorfasicularBlockCheckbox"), testResult.LeftAnteriorFasicularBlock);
        setboolTypeReading($("#AwvEkgIppeVentricularCheckbox"), testResult.VentricularHypertrophy);
        setboolTypeReading($("#AwvEkgIppeLeftVentricularCheckbox"), testResult.LeftVentricularHypertrophy);
        setboolTypeReading($("#AwvEkgIppeRightVentricularCheckbox"), testResult.RightVentricularHypertrophy);
        setboolTypeReading($("#AwvEkgIppeISchemicSttCheckbox"), testResult.IschemicSTTChanges);
        setboolTypeReading($("#AwvEkgIppeNonSpecificSttCheckbox"), testResult.NonSpecificSTTChanges);
        setboolTypeReading($("#AwvEkgIppePoorRWaveProgressionCheckbox"), testResult.PoorRWaveProgression);
        setboolTypeReading($("#AwvEkgIppeProlongedQTCheckbox"), testResult.ProlongedQTInterval);
        setboolTypeReading($("#AwvEkgIppeInfarctionPatternCheckbox"), testResult.InfarctionPattern);

        setboolTypeReading($("#AwvEkgIppeATypicalWaveCheckbox"), testResult.AtypicalQWaveLead);
        setboolTypeReading($("#AwvEkgIppeAtrialEnlargementCheckbox"), testResult.AtrialEnlargement);
        setboolTypeReading($("#AwvEkgIppeLeftAtrialCheckbox"), testResult.LeftAtrialEnlargement);
        setboolTypeReading($("#AwvEkgIppeRightAtrialCheckbox"), testResult.RightAtrialEnlargement);
        setboolTypeReading($("#AwvEkgIppeRepolarizationCheckbox"), testResult.RepolarizationVariant);

        setboolTypeReading($("#AwvEkgIppeQrsWideningInputCheck"), testResult.QRSWidening);
        setboolTypeReading($("#AwvEkgIppeLeftAxisInputCheck"), testResult.LeftAxis);
        setboolTypeReading($("#AwvEkgIppeRightAxisInputCheck"), testResult.RightAxis);
        setboolTypeReading($("#AwvEkgIppeAbnormalAxisInputCheck"), testResult.AbnormalAxis);
        setboolTypeReading($("#AwvEkgIppeLeftInputCheck"), testResult.Left);
        setboolTypeReading($("#AwvEkgIppeRightInputCheck"), testResult.Right);
        setboolTypeReading($("#AwvEkgIppeHeartBlockInputCheck"), testResult.HeartBlock);
        setboolTypeReading($("#TypeIInputCheck"), testResult.TypeI);
        setboolTypeReading($("#AwvEkgIppeTypeIIInputCheck"), testResult.TypeII);
        setboolTypeReading($("#AwvEkgIppeFirstDegreeBlockInputCheck"), testResult.FirstDegreeBlock);
        setboolTypeReading($("#AwvEkgIppeSecondDegreeBlockCheckbox"), testResult.SecondDegreeBlock);
        setboolTypeReading($("#AwvEkgIppeThirdDegreeBlockInputCheck"), testResult.ThirdDegreeCompleteHeartBlock);
        setboolTypeReading($("#AwvEkgIppeArtifactInputCheck"), testResult.Artifact);
        setboolTypeReading($("#AwvEkgIppeRepeatStudyInputCheck"), testResult.RepeatStudy);
        setboolTypeReading($("#AwvEkgIppeReversedLeadInputCheck"), testResult.ReversedLeads);
        setboolTypeReading($("#AwvEkgIppeComparedtoPrevEkgInputCheck"), testResult.ComparetoEkg);

        setboolTypeReading($("#AwvEkgIppeLowVoltageCheckbox"), testResult.LowVoltage);
        setboolTypeReading($("#AwvEkgIppeLimbLeadsCheckbox"), testResult.LimbLeads);
        setboolTypeReading($("#AwvEkgIppePrecordialLeadsCheckbox"), testResult.PrecordialLeads);

        setMultipleFindingDatalist($('.AwvEkgIppe-bundle-branch-finding'), testResult.BundleBranchBlockFinding);
        setMultipleFindingDatalist($('.AwvEkgIppe-infarction-pattern-finding'), testResult.InfarctionPatternFinding);
        
        $("#DescribeSelfPresentAwvEkgIPPEInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);
        $("#PriorityInQueueTestAwvEkgIPPECheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#awvEkgIPPE-priorityInQueue-span"), "onClick_PriorityInQueueDataAwvEkgIPPE();", testTypeAwvEkgIPPE);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#awvEkgIPPE-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#AwvEkgIPPE-critical-span"), "onClick_CriticalDataAwvEkgIPPE();", testTypeAwvEkgIPPE);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#AwvEkgIPPE-critical-span").parent().addClass("red-band");
                $("#criticalAwvEkgIppe").attr("checked", "checked");
            }
        }

        if (testResult.Finding != null) {
            setSelectedFindingDatalist($(".AwvEkgIppe-finding-grid"), testResult.Finding.Id);
        }

        setUnableScreenReason($('.dtl-unabletoscreen-AwvEkgIPPE'), testResult.UnableScreenReason);

        setTestNotPerformedReasonForAwvEkgIPPE(testResult.TestNotPerformed);

        if (testResult.ResultImage != null) {
            var newImageArray = new Array();
            newImageArray.push(testResult.ResultImage);
            LoadNewImagesAwvEkgIppe(newImageArray, true);
        }
        
        $("#technotesAwvEkgIPPE").val(testResult.TechnicianNotes);
        $("#conductedbyAwvEkgIPPE option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);

        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksAwvEkgIppe").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpAwvEkgIppe").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalAwvEkgIppe").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }
    },
    getData: function () {
        var testResult = this.Result;
        if (IsawvEkgIPPEResultEntryExternaly == 'True') {
            testResult.TestPerformedExternally = getTestPerformedExternally("chk_AwvEkgIPPEcapturebyChat", testResult.TestPerformedExternally)
        }

        if (currentScreenMode != ScreenMode.Entry) {
            testResult.SinusRythm = getboolTypeReading($("#AwvEkgIppeSinusRythmInputCheck"), testResult.SinusRythm);
            testResult.SinusArrythmia = getboolTypeReading($("#AwvEkgIppeSinusArrythmiaInputCheck"), testResult.SinusArrythmia);
            testResult.SinusBradycardia = getboolTypeReading($("#AwvEkgIppeSinusBradycardiaInputCheck"), testResult.SinusBradycardia);
            testResult.Mild = getboolTypeReading($("#AwvEkgIppeMildInputCheck"), testResult.Mild);
            testResult.Marked = getboolTypeReading($("#AwvEkgIppeMarkedInputCheck"), testResult.Marked);
            testResult.SinusTachycardia = getboolTypeReading($("#AwvEkgIppeSinusTachycardiaInputCheck"), testResult.SinusTachycardia);
            testResult.AtrialFibrillation = getboolTypeReading($("#AwvEkgIppeAtrialFibrillationInputCheck"), testResult.AtrialFibrillation);
            testResult.AtrialFlutter = getboolTypeReading($("#AwvEkgIppeAtrialFlutterInputCheck"), testResult.AtrialFlutter);
            testResult.SupraventricularArrythmia = getboolTypeReading($("#AwvEkgIppeSupraventriculaCheckbox"), testResult.SupraventricularArrythmia);
            testResult.SVT = getboolTypeReading($("#AwvEkgIppeSvtInputCheck"), testResult.SVT);
            testResult.PACs = getboolTypeReading($("#AwvEkgIppePacInputCheck"), testResult.PACs);
            testResult.PVCs = getboolTypeReading($("#AwvEkgIppePvcInputCheck"), testResult.PVCs);
            testResult.PacerRythm = getboolTypeReading($("#AwvEkgIppePacerRythmCheckbox"), testResult.PacerRythm);

            testResult.BundleBranchBlock = getboolTypeReading($("#AwvEkgIppeBundleBranchBlockCheckbox"), testResult.BundleBranchBlock);
            testResult.LeftAnteriorFasicularBlock = getboolTypeReading($("#AwvEkgIppeLeftAnteriorfasicularBlockCheckbox"), testResult.LeftAnteriorFasicularBlock);
            testResult.VentricularHypertrophy = getboolTypeReading($("#AwvEkgIppeVentricularCheckbox"), testResult.VentricularHypertrophy);
            testResult.LeftVentricularHypertrophy = getboolTypeReading($("#AwvEkgIppeLeftVentricularCheckbox"), testResult.LeftVentricularHypertrophy);
            testResult.RightVentricularHypertrophy = getboolTypeReading($("#AwvEkgIppeRightVentricularCheckbox"), testResult.RightVentricularHypertrophy);
            testResult.IschemicSTTChanges = getboolTypeReading($("#AwvEkgIppeISchemicSttCheckbox"), testResult.IschemicSTTChanges);
            testResult.NonSpecificSTTChanges = getboolTypeReading($("#AwvEkgIppeNonSpecificSttCheckbox"), testResult.NonSpecificSTTChanges);
            testResult.PoorRWaveProgression = getboolTypeReading($("#AwvEkgIppePoorRWaveProgressionCheckbox"), testResult.PoorRWaveProgression);
            testResult.ProlongedQTInterval = getboolTypeReading($("#AwvEkgIppeProlongedQTCheckbox"), testResult.ProlongedQTInterval);
            testResult.InfarctionPattern = getboolTypeReading($("#AwvEkgIppeInfarctionPatternCheckbox"), testResult.InfarctionPattern);

            testResult.AtypicalQWaveLead = getboolTypeReading($("#AwvEkgIppeATypicalWaveCheckbox"), testResult.AtypicalQWaveLead);
            testResult.AtrialEnlargement = getboolTypeReading($("#AwvEkgIppeAtrialEnlargementCheckbox"), testResult.AtrialEnlargement);
            testResult.LeftAtrialEnlargement = getboolTypeReading($("#AwvEkgIppeLeftAtrialCheckbox"), testResult.LeftAtrialEnlargement);
            testResult.RightAtrialEnlargement = getboolTypeReading($("#AwvEkgIppeRightAtrialCheckbox"), testResult.RightAtrialEnlargement);
            testResult.RepolarizationVariant = getboolTypeReading($("#AwvEkgIppeRepolarizationCheckbox"), testResult.RepolarizationVariant);

            testResult.QRSWidening = getboolTypeReading($("#AwvEkgIppeQrsWideningInputCheck"), testResult.QRSWidening);
            testResult.LeftAxis = getboolTypeReading($("#AwvEkgIppeLeftAxisInputCheck"), testResult.LeftAxis);
            testResult.RightAxis = getboolTypeReading($("#AwvEkgIppeRightAxisInputCheck"), testResult.RightAxis);
            testResult.AbnormalAxis = getboolTypeReading($("#AwvEkgIppeAbnormalAxisInputCheck"), testResult.AbnormalAxis);
            testResult.Left = getboolTypeReading($("#AwvEkgIppeLeftInputCheck"), testResult.Left);
            testResult.Right = getboolTypeReading($("#AwvEkgIppeRightInputCheck"), testResult.Right);
            testResult.HeartBlock = getboolTypeReading($("#AwvEkgIppeHeartBlockInputCheck"), testResult.HeartBlock);
            testResult.TypeI = getboolTypeReading($("#TypeIInputCheck"), testResult.TypeI);
            testResult.TypeII = getboolTypeReading($("#AwvEkgIppeTypeIIInputCheck"), testResult.TypeII);
            testResult.FirstDegreeBlock = getboolTypeReading($("#AwvEkgIppeFirstDegreeBlockInputCheck"), testResult.FirstDegreeBlock);
            testResult.SecondDegreeBlock = getboolTypeReading($("#AwvEkgIppeSecondDegreeBlockCheckbox"), testResult.SecondDegreeBlock);
            testResult.ThirdDegreeCompleteHeartBlock = getboolTypeReading($("#AwvEkgIppeThirdDegreeBlockInputCheck"), testResult.ThirdDegreeCompleteHeartBlock);
            testResult.Artifact = getboolTypeReading($("#AwvEkgIppeArtifactInputCheck"), testResult.Artifact);
            testResult.RepeatStudy = getboolTypeReading($("#AwvEkgIppeRepeatStudyInputCheck"), testResult.RepeatStudy);
            testResult.ReversedLeads = getboolTypeReading($("#AwvEkgIppeReversedLeadInputCheck"), testResult.ReversedLeads);
            testResult.ComparetoEkg = getboolTypeReading($("#AwvEkgIppeComparedtoPrevEkgInputCheck"), testResult.ComparetoEkg);

            testResult.LowVoltage = getboolTypeReading($("#AwvEkgIppeLowVoltageCheckbox"), testResult.LowVoltage);
            testResult.LimbLeads = getboolTypeReading($("#AwvEkgIppeLimbLeadsCheckbox"), testResult.LimbLeads);
            testResult.PrecordialLeads = getboolTypeReading($("#AwvEkgIppePrecordialLeadsCheckbox"), testResult.PrecordialLeads);

            var bundleBranchBlock = getMultipleFindingDatalist($('.AwvEkgIppe-bundle-branch-finding'));
            testResult.BundleBranchBlockFinding = getMultipleFindingDataandSynchronized(testResult.BundleBranchBlockFinding, bundleBranchBlock);

            var infarctionFinding = getMultipleFindingDatalist($('.AwvEkgIppe-infarction-pattern-finding'));
            testResult.InfarctionPatternFinding = getMultipleFindingDataandSynchronized(testResult.InfarctionPatternFinding, infarctionFinding);

            var ekgFinding = getSelectedFindingDatalist($(".AwvEkgIppe-finding-grid"));
            testResult.Finding = getFindingDataandSynchronized(testResult.Finding, ekgFinding);

            if (testResult.PhysicianInterpretation == null)
                testResult.PhysicianInterpretation = {
                    'Remarks': $("#physicianRemarksAwvEkgIppe").val(), 'IsCritical': $("#criticalAwvEkgIppe").attr("checked"), 'FollowUp': $("#followUpAwvEkgIppe").attr("checked"), 'RecorderMetaData': {
                        'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate
                    }
                };
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksAwvEkgIppe").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpAwvEkgIppe").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalAwvEkgIppe").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-AwvEkgIPPE')));

        testResult.TestNotPerformed = getTestNotPerformedReasonForAwvEkgIPPE(testResult.TestNotPerformed);

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.ConductedByOrgRoleUserId = $("#conductedbyAwvEkgIPPE option:selected").val();
            testResult.TechnicianNotes = $.trim($("#technotesAwvEkgIPPE").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentAwvEkgIPPEInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestAwvEkgIPPECheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_51").attr("checked");
        
        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }

        if (currentScreenMode != ScreenMode.Physician) {

            if (awvEkgIppeResultMedia != null && awvEkgIppeResultMedia.length > 0) {
                if (testResult.ResultImage == null)
                    testResult.ResultImage = awvEkgIppeResultMedia[0];
                else {
                    var resultMedia = awvEkgIppeResultMedia[0];
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
            if (testResult.TechnicianNotes.length < 1 && testResult.ConductedByOrgRoleUserId == "0" && testResult.UnableScreenReason == null && $("#DescribeSelfPresentAwvEkgIPPEInputCheck").attr("checked") == false)
                return null;
        }

        return testResult;
    }
}

var awvEkgIppeImageCount = 0;
var awvEkgIppeResultMedia = null;
function LoadNewImagesAwvEkgIppe(jsonMedia, correctJson) {
    awvEkgIppeResultMedia = jsonMedia;
    awvEkgIppeImageCount = 0;
    $("#awvEkgIppeImagesContainerDiv").empty();
    if (jsonMedia == null || jsonMedia.length < 1) return;
    awvEkgIppeImageCount = jsonMedia.length;
    LoadNewMedia(jsonMedia, correctJson, $("#awvEkgIppeImagesContainerDiv"));
}

var criticalDataModel_AwvEkgIPPE = null;
function onClick_CriticalDataAwvEkgIPPE() {
    if ($("#DescribeSelfPresentAwvEkgIPPEInputCheck").attr("checked")) {
        loadCriticalLink($("#AwvEkgIPPE-critical-span"), "onClick_CriticalDataAwvEkgIPPE();", testTypeAwvEkgIPPE);
        openCriticalDataDialog(testTypeAwvEkgIPPE, $("#conductedbyAwvEkgIPPE"), $("#DescribeSelfPresentAwvEkgIPPEInputCheck"), setCriticalDataModel_AwvEkgIPPE);
    }
    else {
        unloadCriticalLink($("#AwvEkgIPPE-critical-span"), testTypeAwvEkgIPPE);
    }
}

function setCriticalDataModel_AwvEkgIPPE(model, printAfterSave) {
    if (model != null) {
        var testResult = GetAwvEkgIPPEData();
        saveSingleTestResult(testResult, model, $("#AwvEkgIPPE-critical-span"), "onClick_CriticalDataAwvEkgIPPE();", SetAwvEkgIPPEData, printAfterSave);
    }
}

function getCriticalDataModel_AwvEkgIPPE() {
    if ($("#DescribeSelfPresentAwvEkgIPPEInputCheck").attr("checked") && criticalDataModel_AwvEkgIPPE != null) {
        criticalDataModel_AwvEkgIPPE.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_AwvEkgIPPE;
    }
    return null;
}

function onClick_PriorityInQueueDataAwvEkgIPPE() {
    if ($("#PriorityInQueueTestAwvEkgIPPECheck").attr("checked")) {
        loadPriorityInQueueLink($("#awvEkgIPPE-priorityInQueue-span"), "onClick_PriorityInQueueDataAwvEkgIPPE();", testTypeAwvEkgIPPE);
        openPriorityInQueueTestDialog(testTypeAwvEkgIPPE, $("#conductedbyAwvEkgIPPE"), $("#PriorityInQueueTestAwvEkgIPPECheck"), setPriorityInQueueDataModel_AwvEkgIPPE);
    }
    else {
        unloadPriorityInQueueLink($("#awvEkgIPPE-priorityInQueue-span"), testTypeAwvEkgIPPE);
    }
}

function setPriorityInQueueDataModel_AwvEkgIPPE(model) {
    if (model != null) {
        var testResult = GetAwvEkgIPPEData();
        model.TestId = testTypeAwvEkgIPPE;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#awvEkgIPPE-priorityInQueue-span"), "onClick_PriorityInQueueDataAwvEkgIPPE();", SetAwvEkgIPPEData);
    }
}

function clearAllAwvEkgIppeSelection() {
    $(".clear-all-AwvEkgIppe-selection input[type=radio], .clear-all-AwvEkgIppe-selection input[type=checkbox]").attr("checked", false);
}


function setTestNotPerformedReasonForAwvEkgIPPE(testNotPerformed) {
    setTestNotPerformed("testnotPerformedAwvEkgIPPE", testNotPerformed);
    SetTestNotPerformedEnableDisabled("testnotPerformedAwvEkgIPPE");
}

function getTestNotPerformedReasonForAwvEkgIPPE(testNotPerformed) {
    return getTestNotPerformed("testnotPerformedAwvEkgIPPE", testNotPerformed);
}

function getAwvEkgIpppeMedia()
{
    return awvEkgIppeResultMedia;
}