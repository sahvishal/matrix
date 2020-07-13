function PpEchocardiogram(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = {
            'Id': 0, 'UnableScreenReason': null, "Media": new Array(),
            "TestType": testTypePpEcho, "DiagnosisCode": null,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": '0',
            "TestPerformedExternally": null,
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": {
                "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentPpEchoInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestPpEchoCheck").attr("checked")
            }
        };
    }
    this.Result = testResult;
}

PpEchocardiogram.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (IsPpechoResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_PpechocapturebyChat", testResult.TestPerformedExternally)
        }

        setUnableScreenReason($('.Ppecho-unabletoscreen-dtl'), testResult.UnableScreenReason);

        $("#technotesPpecho").val(testResult.TechnicianNotes);
        $("#conductedbyPpecho option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);

        $("#DescribeSelfPresentPpEchoInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);

        if (testResult.Media && testResult.Media.length > 0) {
            LoadNewMediaPpEcho(testResult.Media, true);
        }

        setReading($("#diagnosisCodePpEcho"), testResult.DiagnosisCode);

        setboolTypeReading($('#PpValveAorticCheckbox'), testResult.Aortic);
        setboolTypeReading($('#PpValveMitralCheckbox'), testResult.Mitral);
        setboolTypeReading($('#PpValvePulmonicCheckbox'), testResult.Pulmonic);
        setboolTypeReading($('#PpValveTricuspidCheckbox'), testResult.Tricuspid);

        setboolTypeReading($('#technicalltdreadablePpEchoinputcheck'), testResult.TechnicallyLimitedbutReadable);
        setboolTypeReading($('#repeatstudyunreadablePpEchoinputcheck'), testResult.RepeatStudyUnreadable);

        setReading($('#PpAorticVelocityTextbox'), testResult.AoticVelocity);
        setReading($('#PpPTTextbox'), testResult.MitralPT);
        setReading($('#PpVelocityPulmonicTextbox'), testResult.PulmonicVelocity);
        setReading($('#PpVelocityTricuspidTextbox'), testResult.TricuspidVelocity);
        setReading($('#PpPapTextbox'), testResult.TricuspidPap);


        setboolTypeReading($('#PpRestrictedLeafletCheckbox'), testResult.RestrictedLeafletMotion);
        setboolTypeReading($('#PpRestrictedLeafletAorticCheckbox'), testResult.RestrictedLeafletMotionAortic);
        setboolTypeReading($('#PpRestrictedLeafletMitralCheckbox'), testResult.RestrictedLeafletMotionMitral);
        setboolTypeReading($('#PpRestrictedLeafletPulCheckbox'), testResult.RestrictedLeafletMotionPulmonic);
        setboolTypeReading($('#PpRestrictedLeafletTriCheckbox'), testResult.RestrictedLeafletMotionTricuspid);

        setboolTypeReading($('#PpPericardialEffusionCheckbox'), testResult.PericardialEffusion);
        setboolTypeReading($('#PpDiastolicDysfunctionCheckbox'), testResult.DiastolicDysfunction);

        setboolTypeReading($('#PpVentricularEnlargmentCheckbox'), testResult.VentricularEnlargement);
        setReading($('#PpLeftVEnlargementTextbox'), testResult.LeftVentricularEnlargmentValue);
        setReading($('#PpRightVEnlargementTextbox'), testResult.RightVentricularEnlargmentValue);
        setboolTypeReading($('#PpLeftVEnlargementCheckbox'), testResult.LeftVentricularEnlargment);
        setboolTypeReading($('#PpRightVEnlargementCheckbox'), testResult.RightVentricularEnlargment);

        setboolTypeReading($('#PpAorticRootCheckbox'), testResult.AorticRoot);
        setboolTypeReading($('#PpScleroticCheckbox'), testResult.Sclerotic);
        setboolTypeReading($('#PpCalcifiedCheckbox'), testResult.Calcified);
        setboolTypeReading($('#PpEnlargedCheckbox'), testResult.Enlarged);
        setReading($('#PpEnlargedTextbox'), testResult.EnlargedValue);

        setboolTypeReading($('#PpVentricularHypertrophyCheckbox'), testResult.VentricularHypertrophy);
        setReading($('#PpLeftVHypertrophyTextbox'), testResult.LeftVHypertrophyValue);
        setReading($('#PpRightVHypertrophyTextbox'), testResult.RightVHypertrophyValue);
        setReading($('#PpIvshTextbox'), testResult.IvshHypertrophyValue);

        setboolTypeReading($('#PpLeftVHypertrophyCheckbox'), testResult.LeftVHypertrophy);
        setboolTypeReading($('#PpRightVHypertrophyCheckbox'), testResult.RightVHypertrophy);
        setboolTypeReading($('#PpIvshCheckbox'), testResult.IvshHypertrophy);

        setboolTypeReading($('#PpAtrialEnlargmentCheckbox'), testResult.AtrialEnlargement);
        setReading($('#PpLeftAtrialEnlargementTextbox'), testResult.LeftAtrialEnlargmentValue);
        setReading($('#PpRightAtrialEnlargementTextbox'), testResult.RightAtrialEnlargmentValue);

        setboolTypeReading($('#PpLeftAtrialEnlargementCheckbox'), testResult.LeftAtrialEnlargment);
        setboolTypeReading($('#PpRightAtrialEnlargementCheckbox'), testResult.RightAtrialEnlargment);
        setboolTypeReading($('#PpArrythmiaCheckbox'), testResult.Arrythmia);
        
        setboolTypeReading($('#PpAFibCheckbox'), testResult.AFib);
        setboolTypeReading($('#PpAFlutterCheckbox'), testResult.AFlutter);
        setboolTypeReading($('#PpPACCheckbox'), testResult.PAC);
        setboolTypeReading($('#PpPVCCheckbox'), testResult.PVC);

        setboolTypeReading($('#PpAsdCheckbox'), testResult.ASD);
        setboolTypeReading($('#PpPfoCheckbox'), testResult.PFO);
        setboolTypeReading($('#PpVsdCheckbox'), testResult.VSD);
        setboolTypeReading($('#PpFlailCheckbox'), testResult.FlailAS);
        setboolTypeReading($('#PpSamCheckbox'), testResult.SAM);
        setboolTypeReading($('#PpLvotoCheckbox'), testResult.LVOTO);
        setboolTypeReading($('#PpMitralAnnularCheckbox'), testResult.MitralAnnularCa);

        setboolTypeReading($('#PpHypokineticCheckbox'), testResult.Hypokinetic);
        setboolTypeReading($('#PpAkineticCheckbox'), testResult.Akinetic);
        setboolTypeReading($('#PpDyskineticCheckbox'), testResult.Dyskinetic);
        setboolTypeReading($('#PpAnteriorCheckbox'), testResult.Anterior);
        setboolTypeReading($('#PpPosteriorCheckbox'), testResult.Posterior);
        setboolTypeReading($('#PpApicalCheckbox'), testResult.Apical);
        setboolTypeReading($('#PpSeptalCheckbox'), testResult.Septal);
        setboolTypeReading($('#PpLateralCheckbox'), testResult.Lateral);
        setboolTypeReading($('#PpInferiorCheckbox'), testResult.Inferior);
        
        setboolTypeReading($('#PpMorphologyTricuspidHigh35MmHgOrGreaterCheckbox'), testResult.MorphologyTricuspidHighOrGreater);
        setboolTypeReading($('#PpMorphologyTricuspidNormalCheckbox'), testResult.MorphologyTricuspidNormal);

        if (testResult.Finding != null) {
            setSelectedFindingDatalist($(".Ppecho-finding"), testResult.Finding.Id);
        }

        if (testResult.EstimatedEjactionFraction != null) {
            setSelectedFindingDatalist($(".Ppejaction-fraction-finding"), testResult.EstimatedEjactionFraction.Id);
        }

        if (testResult.AorticRegurgitation != null) {
            setSelectedFindingDatalist($(".Ppaortic-regurgitation-finding"), testResult.AorticRegurgitation.Id);
        }

        if (testResult.MitralRegurgitation != null) {
            setSelectedFindingDatalist($(".Ppmitral-regurgitation-finding"), testResult.MitralRegurgitation.Id);
        }

        if (testResult.PulmonicRegurgitation != null) {
            setSelectedFindingDatalist($(".Pppulmonic-regurgitation-finding"), testResult.PulmonicRegurgitation.Id);
        }

        if (testResult.TricuspidRegurgitation != null) {
            setSelectedFindingDatalist($(".Pptricuspid-regurgitation-finding"), testResult.TricuspidRegurgitation.Id);
        }
        
        if (testResult.DistolicDysfunctionFinding != null) {
            setSelectedFindingDatalist($(".Ppdiastolic-dysfunction-finding"), testResult.DistolicDysfunctionFinding.Id);
        }

        setMultipleFindingDatalist($('.Ppaortic-morphology-finding'), testResult.AorticMorphology);
        setMultipleFindingDatalist($('.Ppmitral-morphology-finding'), testResult.MitralMorphology);
        setMultipleFindingDatalist($('.Pppulmonic-morphology-finding'), testResult.PulmonicMorphology);
        setMultipleFindingDatalist($('.Pptricuspid-morphology-finding'), testResult.TricuspidMorphology);
        setMultipleFindingDatalist($('.Pppericardial-effusion-finding'), testResult.PericardialEffusionFinding);

        $("#PriorityInQueueTestPpEchoCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#ppecho-priorityInQueue-span"), "onClick_PriorityInQueueDataPpEcho();", testTypePpEcho);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#ppecho-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#Ppecho-critical-span"), "onClick_CriticalDataPpEcho();", testTypePpEcho);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#Ppecho-critical-span").parent().addClass("red-band");
                $("#criticalPpEcho").attr("checked", "checked");
            }
        }

        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksPpEcho").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpPpEcho").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalPpEcho").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }

        if (currentScreenMode == ScreenMode.Physician) {
            $("#claer-all-Ppregurgitation").show();
        }
        
        setPpEchoDiagnosisCode(null);
    },
    getData: function () {
        var testResult = this.Result;
        if (IsPpechoResultEntryExternaly == 'True') {
             testResult.TestPerformedExternally = getTestPerformedExternally("chk_PpechocapturebyChat", testResult.TestPerformedExternally)
        }

        testResult.DiagnosisCode = getReading($("#diagnosisCodePpEcho"), testResult.DiagnosisCode);

        if (currentScreenMode != ScreenMode.Entry) {
            testResult.Aortic = getboolTypeReading($('#PpValveAorticCheckbox'), testResult.Aortic);
            testResult.Mitral = getboolTypeReading($('#PpValveMitralCheckbox'), testResult.Mitral);
            testResult.Pulmonic = getboolTypeReading($('#PpValvePulmonicCheckbox'), testResult.Pulmonic);
            testResult.Tricuspid = getboolTypeReading($('#PpValveTricuspidCheckbox'), testResult.Tricuspid);

            testResult.AoticVelocity = getReading($('#PpAorticVelocityTextbox'), testResult.AoticVelocity);
            testResult.MitralPT = getReading($('#PpPTTextbox'), testResult.MitralPT);
            testResult.PulmonicVelocity = getReading($('#PpVelocityPulmonicTextbox'), testResult.PulmonicVelocity);
            testResult.TricuspidVelocity = getReading($('#PpVelocityTricuspidTextbox'), testResult.TricuspidVelocity);
            testResult.TricuspidPap = getReading($('#PpPapTextbox'), testResult.TricuspidPap);

            testResult.PericardialEffusion = getboolTypeReading($('#PpPericardialEffusionCheckbox'), testResult.PericardialEffusion);
            testResult.DiastolicDysfunction = getboolTypeReading($('#PpDiastolicDysfunctionCheckbox'), testResult.DiastolicDysfunction);

            testResult.VentricularEnlargement = getboolTypeReading($('#PpVentricularEnlargmentCheckbox'), testResult.VentricularEnlargement);
            testResult.LeftVentricularEnlargmentValue = getReading($('#PpLeftVEnlargementTextbox'), testResult.LeftVentricularEnlargmentValue);
            testResult.RightVentricularEnlargmentValue = getReading($('#PpRightVEnlargementTextbox'), testResult.RightVentricularEnlargmentValue);
            testResult.LeftVentricularEnlargment = getboolTypeReading($('#PpLeftVEnlargementCheckbox'), testResult.LeftVentricularEnlargment);
            testResult.RightVentricularEnlargment = getboolTypeReading($('#PpRightVEnlargementCheckbox'), testResult.RightVentricularEnlargment);

            testResult.AorticRoot = getboolTypeReading($('#PpAorticRootCheckbox'), testResult.AorticRoot);
            testResult.Sclerotic = getboolTypeReading($('#PpScleroticCheckbox'), testResult.Sclerotic);
            testResult.Calcified = getboolTypeReading($('#PpCalcifiedCheckbox'), testResult.Calcified);
            testResult.Enlarged = getboolTypeReading($('#PpEnlargedCheckbox'), testResult.Enlarged);
            testResult.EnlargedValue = getReading($('#PpEnlargedTextbox'), testResult.EnlargedValue);


            testResult.RestrictedLeafletMotion = getboolTypeReading($('#PpRestrictedLeafletCheckbox'), testResult.RestrictedLeafletMotion);
            testResult.RestrictedLeafletMotionAortic = getboolTypeReading($('#PpRestrictedLeafletAorticCheckbox'), testResult.RestrictedLeafletMotionAortic);
            testResult.RestrictedLeafletMotionMitral = getboolTypeReading($('#PpRestrictedLeafletMitralCheckbox'), testResult.RestrictedLeafletMotionMitral);
            testResult.RestrictedLeafletMotionPulmonic = getboolTypeReading($('#PpRestrictedLeafletPulCheckbox'), testResult.RestrictedLeafletMotionPulmonic);
            testResult.RestrictedLeafletMotionTricuspid = getboolTypeReading($('#PpRestrictedLeafletTriCheckbox'), testResult.RestrictedLeafletMotionTricuspid);


            testResult.VentricularHypertrophy = getboolTypeReading($('#PpVentricularHypertrophyCheckbox'), testResult.VentricularHypertrophy);
            testResult.LeftVHypertrophyValue = getReading($('#PpLeftVHypertrophyTextbox'), testResult.LeftVHypertrophyValue);
            testResult.RightVHypertrophyValue = getReading($('#PpRightVHypertrophyTextbox'), testResult.RightVHypertrophyValue);
            testResult.IvshHypertrophyValue = getReading($('#PpIvshTextbox'), testResult.IvshHypertrophyValue);

            testResult.LeftVHypertrophy = getboolTypeReading($('#PpLeftVHypertrophyCheckbox'), testResult.LeftVHypertrophy);
            testResult.RightVHypertrophy = getboolTypeReading($('#PpRightVHypertrophyCheckbox'), testResult.RightVHypertrophy);
            testResult.IvshHypertrophy = getboolTypeReading($('#PpIvshCheckbox'), testResult.IvshHypertrophy);

            testResult.AtrialEnlargement = getboolTypeReading($('#PpAtrialEnlargmentCheckbox'), testResult.AtrialEnlargement);
            testResult.LeftAtrialEnlargmentValue = getReading($('#PpLeftAtrialEnlargementTextbox'), testResult.LeftAtrialEnlargmentValue);
            testResult.RightAtrialEnlargmentValue = getReading($('#PpRightAtrialEnlargementTextbox'), testResult.RightAtrialEnlargmentValue);

            testResult.LeftAtrialEnlargment = getboolTypeReading($('#PpLeftAtrialEnlargementCheckbox'), testResult.LeftAtrialEnlargment);
            testResult.RightAtrialEnlargment = getboolTypeReading($('#PpRightAtrialEnlargementCheckbox'), testResult.RightAtrialEnlargment);
            testResult.Arrythmia = getboolTypeReading($('#PpArrythmiaCheckbox'), testResult.Arrythmia);
            
            testResult.AFib = getboolTypeReading($('#PpAFibCheckbox'), testResult.AFib);
            testResult.AFlutter = getboolTypeReading($('#PpAFlutterCheckbox'), testResult.AFlutter);
            testResult.PAC = getboolTypeReading($('#PpPACCheckbox'), testResult.PAC);
            testResult.PVC = getboolTypeReading($('#PpPVCCheckbox'), testResult.PVC);

            testResult.ASD = getboolTypeReading($('#PpAsdCheckbox'), testResult.ASD);
            testResult.PFO = getboolTypeReading($('#PpPfoCheckbox'), testResult.PFO);
            testResult.VSD = getboolTypeReading($('#PpVsdCheckbox'), testResult.VSD);
            testResult.FlailAS = getboolTypeReading($('#PpFlailCheckbox'), testResult.FlailAS);
            testResult.SAM = getboolTypeReading($('#PpSamCheckbox'), testResult.SAM);
            testResult.LVOTO = getboolTypeReading($('#PpLvotoCheckbox'), testResult.LVOTO);
            testResult.MitralAnnularCa = getboolTypeReading($('#PpMitralAnnularCheckbox'), testResult.MitralAnnularCa);

            testResult.Hypokinetic = getboolTypeReading($('#PpHypokineticCheckbox'), testResult.Hypokinetic);
            testResult.Akinetic = getboolTypeReading($('#PpAkineticCheckbox'), testResult.Akinetic);
            testResult.Dyskinetic = getboolTypeReading($('#PpDyskineticCheckbox'), testResult.Dyskinetic);
            testResult.Anterior = getboolTypeReading($('#PpAnteriorCheckbox'), testResult.Anterior);
            testResult.Posterior = getboolTypeReading($('#PpPosteriorCheckbox'), testResult.Posterior);
            testResult.Apical = getboolTypeReading($('#PpApicalCheckbox'), testResult.Apical);
            testResult.Septal = getboolTypeReading($('#PpSeptalCheckbox'), testResult.Septal);
            testResult.Lateral = getboolTypeReading($('#PpLateralCheckbox'), testResult.Lateral);
            testResult.Inferior = getboolTypeReading($('#PpInferiorCheckbox'), testResult.Inferior);

            testResult.Finding = getFindingDataandSynchronized(testResult.Finding, getSelectedFindingDatalist($(".Ppecho-finding")));
            testResult.EstimatedEjactionFraction = getFindingDataandSynchronized(testResult.EstimatedEjactionFraction, getSelectedFindingDatalist($(".Ppejaction-fraction-finding")));
            testResult.AorticRegurgitation = getFindingDataandSynchronized(testResult.AorticRegurgitation, getSelectedFindingDatalist($(".Ppaortic-regurgitation-finding")));
            testResult.MitralRegurgitation = getFindingDataandSynchronized(testResult.MitralRegurgitation, getSelectedFindingDatalist($(".Ppmitral-regurgitation-finding")));
            testResult.PulmonicRegurgitation = getFindingDataandSynchronized(testResult.PulmonicRegurgitation, getSelectedFindingDatalist($(".Pppulmonic-regurgitation-finding")));
            testResult.TricuspidRegurgitation = getFindingDataandSynchronized(testResult.TricuspidRegurgitation, getSelectedFindingDatalist($(".Pptricuspid-regurgitation-finding")));
            
            testResult.DistolicDysfunctionFinding = getFindingDataandSynchronized(testResult.DistolicDysfunctionFinding, getSelectedFindingDatalist($(".Ppdiastolic-dysfunction-finding")));

            testResult.AorticMorphology = getMultipleFindingDataandSynchronized(testResult.AorticMorphology, getMultipleFindingDatalist($('.Ppaortic-morphology-finding')));
            testResult.MitralMorphology = getMultipleFindingDataandSynchronized(testResult.MitralMorphology, getMultipleFindingDatalist($('.Ppmitral-morphology-finding')));
            testResult.TricuspidMorphology = getMultipleFindingDataandSynchronized(testResult.TricuspidMorphology, getMultipleFindingDatalist($('.Pptricuspid-morphology-finding')));
            testResult.PulmonicMorphology = getMultipleFindingDataandSynchronized(testResult.PulmonicMorphology, getMultipleFindingDatalist($('.Pppulmonic-morphology-finding')));

            testResult.PericardialEffusionFinding = getMultipleFindingDataandSynchronized(testResult.PericardialEffusionFinding, getMultipleFindingDatalist($('.Pppericardial-effusion-finding')));
            
            testResult.TechnicallyLimitedbutReadable = getboolTypeReading($('#technicalltdreadablePpEchoinputcheck'), testResult.TechnicallyLimitedbutReadable);
            testResult.RepeatStudyUnreadable = getboolTypeReading($('#repeatstudyunreadablePpEchoinputcheck'), testResult.RepeatStudyUnreadable);
            
            testResult.MorphologyTricuspidHighOrGreater = getboolTypeReading($('#PpMorphologyTricuspidHigh35MmHgOrGreaterCheckbox'), testResult.MorphologyTricuspidHighOrGreater);
            testResult.MorphologyTricuspidNormal = getboolTypeReading($('#PpMorphologyTricuspidNormalCheckbox'), testResult.MorphologyTricuspidNormal);

            if (testResult.PhysicianInterpretation == null)
                testResult.PhysicianInterpretation = {
                    'Remarks': $("#physicianRemarksPpEcho").val(), 'IsCritical': $("#criticalPpEcho").attr("checked"), 'FollowUp': $("#followUpPpEcho").attr("checked"), 'RecorderMetaData': {
                        'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate
                    }
                };
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksPpEcho").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpPpEcho").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalPpEcho").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.Ppecho-unabletoscreen-dtl')));

        if (currentScreenMode != ScreenMode.Physician) {
            var resultMedia = new Array();
            if (PpechoResultMedia != null) {
                $.each(PpechoResultMedia, function () { resultMedia.push(this); });
            }

            testResult.Media = resultMedia;
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
            testResult.TechnicianNotes = $.trim($("#technotesPpecho").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ConductedByOrgRoleUserId = $("#conductedbyPpecho option:selected").val();
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentPpEchoInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestPpEchoCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_38").attr("checked");

        if (testResult.ResultStatus.StateNumber < 4 && testResult.TechnicianNotes.length < 1 && testResult.ConductedByOrgRoleUserId == "0" && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.length < 1)
            && $("#DescribeSelfPresentPpEchoInputCheck").attr("checked") == false && PpEchoImageCount < 1)
            testResult = null;

        return testResult;
    }
}


var PpEchoImageCount = 0;
var PpechoResultMedia = null;

function getPpEchoMedia() {
    return PpechoResultMedia;
}

function LoadNewMediaPpEcho(jsonMedia, correctJson) {
    PpechoResultMedia = jsonMedia;
    PpEchoImageCount = 0;
    $("#PpEchoMediaDiv").empty();
    if (jsonMedia == null || jsonMedia.length < 1) return;
    PpEchoImageCount = jsonMedia.length;
    LoadNewMedia(jsonMedia, correctJson, $("#PpEchoMediaDiv"));
}

$(document).ready(function () {
    $(".Ppejaction-fraction-finding .rbt-finding,.regurgitation-finding input[type=radio],.non-normal-diagnosis input[type='checkbox'],.non-normal-diagnosis input[type='radio']").click(function () {
        setPpEchoDiagnosisCode(this);
    });

    //setPpEchoDiagnosisCode(null);
});

function setPpEchoDiagnosisCode(ctrlRef) {
    //debugger;
    $("#diagnosisCodePpEcho").val("");
    var worstCase = -1;

    var radiobtncls = "rbt-finding";

    $(".Ppejaction-fraction-finding").find("tr").each(function () {
        if ($(this).find("." + radiobtncls).attr("checked") == true) {
            worstCase = $(this).find(".finding-worstcaseorder").val();
            return;
        }
    });

    var normalDiagnosis = true;
    if ($(".non-normal-diagnosis input[type='checkbox']:checked,.non-normal-diagnosis input[type='radio']:checked").length > 0) {
        normalDiagnosis = false;
    }

    $(".regurgitation-finding").each(function() {
        if ($(this).find("input[type=radio]:checked").length > 0 && $(this).find("input[type=radio]").first().is(":checked") == false) {
            normalDiagnosis = false;
        }
    });

    var diagnosiscodes = "";
    if ((worstCase == 1 || worstCase == 2) && normalDiagnosis == true) {
        if (diagnosiscodes.length > 0) {
            diagnosiscodes += '|' + 'Normal study';
        } else {
            diagnosiscodes += 'Normal study';
        }
    }
    else if (worstCase > 2) {
        if (diagnosiscodes.length > 0) {
            diagnosiscodes += '|425.8 cardiomyopathy in other dis class elsewhere' + '|' + '428.20 unspec systolic heart failure' + '|' + '428.0 congestive heart failure, unspec';
        } else {
            diagnosiscodes += '425.8 cardiomyopathy in other dis class elsewhere' + '|' + '428.20 unspec systolic heart failure' + '|' + '428.0 congestive heart failure, unspec';
        }
    }

    if ($("#PpMorphologyTricuspidHigh35MmHgOrGreaterCheckbox").is(":checked")) {
        if (diagnosiscodes.length > 0) {
            diagnosiscodes += '|' + '416.0 primary pulmonary hypertension (RV pressure of 35 mmHg or greater)';
        } else {
            diagnosiscodes += '416.0 primary pulmonary hypertension (RV pressure of 35 mmHg or greater)';
        }
    }

    if ($("#PpLvotoCheckbox").is(":checked")) {
        if (diagnosiscodes.length > 0) {
            diagnosiscodes += '|' + '425.11 hypertrophic obstructive cardiomyopathy';
        } else {
            diagnosiscodes += '425.11 hypertrophic obstructive cardiomyopathy';
        }
    }
    
    if ($("#PpDiastolicDysfunctionCheckbox").is(":checked") || $(".Ppdiastolic-dysfunction-finding input[type='radio']:checked").length > 0) {
        if (diagnosiscodes.length > 0) {
            diagnosiscodes += '|' + '428.30 unspec diastolic heart failure';
        } else {
            diagnosiscodes += '428.30 unspec diastolic heart failure';
        }
    }

    if ($(".wall-motion-abnormality input[type='checkbox']:checked").length > 0) {
        if (diagnosiscodes.length > 0) {
            diagnosiscodes += '|' + '412 old myocardial infarction' + '|' + '414.01 coronary artery disease native vessels';
        } else {
            diagnosiscodes += '412 old myocardial infarction' + '|' + '414.01 coronary artery disease native vessels';
        }
    }
    
    if ($("#PpAFibCheckbox").is(":checked")) {
        if (diagnosiscodes.length > 0) {
            diagnosiscodes += '|' + '427.31 atrial fibrillation (afib)';
        } else {
            diagnosiscodes += '427.31 atrial fibrillation (afib)';
        }
    }
    
    if ($("#PpAFlutterCheckbox").is(":checked")) {
        if (diagnosiscodes.length > 0) {
            diagnosiscodes += '|' + '427.32 atrial flutter';
        } else {
            diagnosiscodes += '427.32 atrial flutter';
        }
    }

    $("#diagnosisCodePpEcho").val(diagnosiscodes);
}

var criticalDataModel_PpEcho = null;
function onClick_CriticalDataPpEcho() {
    if ($("#DescribeSelfPresentPpEchoInputCheck").attr("checked")) {
        loadCriticalLink($("#Ppecho-critical-span"), "onClick_CriticalDataPpEcho();", testTypePpEcho);
        openCriticalDataDialog(testTypePpEcho, $("#conductedbyPpecho"), $("#DescribeSelfPresentPpEchoInputCheck"), setCriticalDataModel_PpEcho);
    }
    else {
        unloadCriticalLink($("#Ppecho-critical-span"), testTypePpEcho);
    }
}

function setCriticalDataModel_PpEcho(model, printAfterSave) {
    if (model != null) {
        var testResult = GetPpEchoData();
        saveSingleTestResult(testResult, model, $("#Ppecho-critical-span"), "onClick_CriticalDataPpEcho();", SetPpEchoData, printAfterSave);
    }
}

function getCriticalDataModel_PpEcho() {
    if ($("#DescribeSelfPresentPpEchoInputCheck").attr("checked") && criticalDataModel_PpEcho != null) {
        criticalDataModel_PpEcho.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_PpEcho;
    }
    return null;
}

function clearAllPpRegurgitationSelection() {
    //debugger;
    $(".Ppaortic-regurgitation-finding,.Ppmitral-regurgitation-finding,.Pppulmonic-regurgitation-finding,.Pptricuspid-regurgitation-finding").find("input[type=radio]").attr("checked", false);
}

function onClick_PriorityInQueueDataPpEcho() {
    if ($("#PriorityInQueueTestPpEchoCheck").attr("checked")) {
        loadPriorityInQueueLink($("#ppecho-priorityInQueue-span"), "onClick_PriorityInQueueDataPpEcho();", testTypePpEcho);
        openPriorityInQueueTestDialog(testTypePpEcho, $("#conductedbyPpecho"), $("#PriorityInQueueTestPpEchoCheck"), setPriorityInQueueDataModel_PpEcho);
    }
    else {
        unloadPriorityInQueueLink($("#ppecho-priorityInQueue-span"), testTypePpEcho);
    }
}

function setPriorityInQueueDataModel_PpEcho(model) {
    if (model != null) {
        var testResult = GetPpEchoData();
        model.TestId = testTypePpEcho;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#ppecho-priorityInQueue-span"), "onClick_PriorityInQueueDataPpEcho();", SetPpEchoData);
    }
}

function clearAllPpEchoSelection() {
    $(".clear-all-ppecho-selection input[type=radio], .clear-all-ppecho-selection input[type=checkbox]").attr("checked", false);
    
    setPpEchoDiagnosisCode(null);
}