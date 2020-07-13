function AwvEcho(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = {
            'Id': 0, 'UnableScreenReason': null, "Media": new Array(),
            "TestType": testTypeAwvEcho,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": '0',
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "TestPerformedExternally": null,
             
            "ResultStatus": {
                "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentAwvEchoInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestAwvEchoCheck").attr("checked")
            }
        };
    }
    this.Result = testResult;
}

AwvEcho.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (IsawvEchoResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_awvEchocapturebyChat", testResult.TestPerformedExternally)
        }

        setUnableScreenReason($('.AwvEcho-unabletoscreen-dtl'), testResult.UnableScreenReason);

        setTestNotPerformedReasonForAwvEcho(testResult.TestNotPerformed);

        $("#technotesAwvEcho").val(testResult.TechnicianNotes);
        $("#conductedbyAwvEcho option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);

        $("#DescribeSelfPresentAwvEchoInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);

        if (testResult.Media && testResult.Media.length > 0) {
            LoadNewMediaAwvEcho(testResult.Media, true);
        }

        setboolTypeReading($('#AwvEchoValveAorticCheckbox'), testResult.Aortic);
        setboolTypeReading($('#AwvEchoValveMitralCheckbox'), testResult.Mitral);
        setboolTypeReading($('#AwvEchoValvePulmonicCheckbox'), testResult.Pulmonic);
        setboolTypeReading($('#AwvEchoValveTricuspidCheckbox'), testResult.Tricuspid);

        setboolTypeReading($('#AwvEchotechnicalltdreadableinputcheck'), testResult.TechnicallyLimitedbutReadable);
        setboolTypeReading($('#AwvEchorepeatstudyunreadableinputcheck'), testResult.RepeatStudyUnreadable);

        setReading($('#AwvEchoAorticVelocityTextbox'), testResult.AoticVelocity);
        setReading($('#PeakGradient'), testResult.PeakGradient);
        setReading($('#AwvEchoPTTextbox'), testResult.MitralPT);
        setReading($('#AwvEchoVelocityPulmonicTextbox'), testResult.PulmonicVelocity);
        setReading($('#AwvEchoVelocityTricuspidTextbox'), testResult.TricuspidVelocity);
        setReading($('#AwvEchoPapTextbox'), testResult.TricuspidPap);

        setReading($('#AorticEstimatedValveArea'), testResult.AorticEstimatedValveArea);
        setReading($('#MitralEstimatedValveArea'), testResult.MitralEstimatedValveArea);
        setReading($('#PulmonicEstimatedValveArea'), testResult.PulmonicEstimatedValveArea);
        setReading($('#TricuspidEstimatedValveArea'), testResult.TricuspidEstimatedValveArea);
        
        setReading($('#AorticEstimatedRightValve'), testResult.AorticEstimatedRightValve);
        setReading($('#MitralEstimatedRightValve'), testResult.MitralEstimatedRightValve);

        setboolTypeReading($('#AwvEchoRestrictedLeafletCheckbox'), testResult.RestrictedLeafletMotion);
        setboolTypeReading($('#AwvEchoRestrictedLeafletAorticCheckbox'), testResult.RestrictedLeafletMotionAortic);
        setboolTypeReading($('#AwvEchoRestrictedLeafletMitralCheckbox'), testResult.RestrictedLeafletMotionMitral);
        setboolTypeReading($('#AwvEchoRestrictedLeafletPulCheckbox'), testResult.RestrictedLeafletMotionPulmonic);
        setboolTypeReading($('#AwvEchoRestrictedLeafletTriCheckbox'), testResult.RestrictedLeafletMotionTricuspid);

        setboolTypeReading($('#AwvEchoPericardialEffusionCheckbox'), testResult.PericardialEffusion);
        setboolTypeReading($('#AwvEchoDiastolicDysfunctionCheckbox'), testResult.DiastolicDysfunction);
        
        setReading($('#DiastolicDysfunctionEeRatio'), testResult.DiastolicDysfunctionEeRatio);

        setboolTypeReading($('#AwvEchoVentricularEnlargmentCheckbox'), testResult.VentricularEnlargement);
        setReading($('#AwvEchoLeftVEnlargementTextbox'), testResult.LeftVentricularEnlargmentValue);
        setReading($('#AwvEchoRightVEnlargementTextbox'), testResult.RightVentricularEnlargmentValue);
        setboolTypeReading($('#AwvEchoLeftVEnlargementCheckbox'), testResult.LeftVentricularEnlargment);
        setboolTypeReading($('#AwvEchoRightVEnlargementCheckbox'), testResult.RightVentricularEnlargment);

        setboolTypeReading($('#AwvEchoAorticRootCheckbox'), testResult.AorticRoot);
        setboolTypeReading($('#AwvEchoScleroticCheckbox'), testResult.Sclerotic);
        setboolTypeReading($('#AwvEchoCalcifiedCheckbox'), testResult.Calcified);
        setboolTypeReading($('#AwvEchoEnlargedCheckbox'), testResult.Enlarged);
        setReading($('#AwvEchoEnlargedTextbox'), testResult.EnlargedValue);
        
        setboolTypeReading($('#AwvEchoAscendingAortaArchCheckbox'), testResult.AscendingAortaArch);
        setboolTypeReading($('#AwvEchoAtherosclerosisCheckbox'), testResult.Atherosclerosis);

        setboolTypeReading($('#AwvEchoVentricularHypertrophyCheckbox'), testResult.VentricularHypertrophy);
        setReading($('#AwvEchoLeftVHypertrophyTextbox'), testResult.LeftVHypertrophyValue);
        setReading($('#AwvEchoRightVHypertrophyTextbox'), testResult.RightVHypertrophyValue);
        setReading($('#AwvEchoIvshTextbox'), testResult.IvshHypertrophyValue);

        setboolTypeReading($('#AwvEchoLeftVHypertrophyCheckbox'), testResult.LeftVHypertrophy);
        setboolTypeReading($('#AwvEchoRightVHypertrophyCheckbox'), testResult.RightVHypertrophy);
        setboolTypeReading($('#AwvEchoIvshCheckbox'), testResult.IvshHypertrophy);

        setboolTypeReading($('#AwvEchoAtrialEnlargmentCheckbox'), testResult.AtrialEnlargement);
        setReading($('#AwvEchoLeftAtrialEnlargementTextbox'), testResult.LeftAtrialEnlargmentValue);
        setReading($('#AwvEchoRightAtrialEnlargementTextbox'), testResult.RightAtrialEnlargmentValue);

        setboolTypeReading($('#AwvEchoLeftAtrialEnlargementCheckbox'), testResult.LeftAtrialEnlargment);
        setboolTypeReading($('#AwvEchoRightAtrialEnlargementCheckbox'), testResult.RightAtrialEnlargment);
        setboolTypeReading($('#AwvEchoArrythmiaCheckbox'), testResult.Arrythmia);

        setboolTypeReading($('#AwvEchoAFibCheckbox'), testResult.AFib);
        setboolTypeReading($('#AwvEchoAFlutterCheckbox'), testResult.AFlutter);
        setboolTypeReading($('#AwvEchoPACCheckbox'), testResult.PAC);
        setboolTypeReading($('#AwvEchoPVCCheckbox'), testResult.PVC);

        setboolTypeReading($('#AwvEchoAsdCheckbox'), testResult.ASD);
        setboolTypeReading($('#AwvEchoPfoCheckbox'), testResult.PFO);
        setboolTypeReading($('#AwvEchoVsdCheckbox'), testResult.VSD);
        setboolTypeReading($('#AwvEchoFlailCheckbox'), testResult.FlailAS);
        
        setboolTypeReading($('#AwvEchoMitralAnnularCheckbox'), testResult.MitralAnnularCa);

        setboolTypeReading($('#AwvEchoHypokineticCheckbox'), testResult.Hypokinetic);
        setboolTypeReading($('#AwvEchoAkineticCheckbox'), testResult.Akinetic);
        setboolTypeReading($('#AwvEchoDyskineticCheckbox'), testResult.Dyskinetic);
        setboolTypeReading($('#AwvEchoAnteriorCheckbox'), testResult.Anterior);
        setboolTypeReading($('#AwvEchoPosteriorCheckbox'), testResult.Posterior);
        setboolTypeReading($('#AwvEchoApicalCheckbox'), testResult.Apical);
        setboolTypeReading($('#AwvEchoSeptalCheckbox'), testResult.Septal);
        setboolTypeReading($('#AwvEchoLateralCheckbox'), testResult.Lateral);
        setboolTypeReading($('#AwvEchoInferiorCheckbox'), testResult.Inferior);

        setboolTypeReading($('#AwvEchoMorphologyTricuspidHigh35MmHgOrGreaterCheckbox'), testResult.MorphologyTricuspidHighOrGreater);
        setboolTypeReading($('#AwvEchoMorphologyTricuspidNormalCheckbox'), testResult.MorphologyTricuspidNormal);

        /**********************************************************************************************************************************************/
        setReading($('#Conclusion'), testResult.Conclusion);

        setboolTypeReading($('#AwvEchoConsistentLvDiastolicFailureCheckbox'), testResult.ConsistentLvDiastolicFailure);
        setboolTypeReading($('#AwvEchoConsistentHypertensiveHeartDiseaseWithDiastolicHeartFailureCheckbox'), testResult.ConsistentHypertensiveHeartDiseaseWithDiastolicHeartFailure);
        setboolTypeReading($('#AwvEchoConsistentHypertensiveHeartDiseaseWithoutDiastolicHeartFailureCheckbox'), testResult.ConsistentHypertensiveHeartDiseaseWithoutDiastolicHeartFailure);

        //Left Ventricle
        setboolTypeReading($('#LeftVentricleOverallFunctionNotEvaluated'), testResult.LeftVentricleOverallFunctionNotEvaluated);
        setboolTypeReading($('#LeftVentricleOverallFunctionNormal'), testResult.LeftVentricleOverallFunctionNormal);
        setboolTypeReading($('#LeftVentricleOverallFunctionReduced'), testResult.LeftVentricleOverallFunctionReduced);
        setboolTypeReading($('#LeftVentricleOverallFunctionBorderline'), testResult.LeftVentricleOverallFunctionBorderline);
        setboolTypeReading($('#LeftVentricleOverallFunctionHyperkinesis'), testResult.LeftVentricleOverallFunctionHyperkinesis);
        setboolTypeReading($('#LeftVentricleOverallFunctionHypokinesis'), testResult.LeftVentricleOverallFunctionHypokinesis);
        setboolTypeReading($('#LeftVentricleOverallFunctionConsistentLvSystolicFailure'), testResult.LeftVentricleOverallFunctionConsistentLvSystolicFailure);

        setboolTypeReading($('#LeftVentricleDimensionsNotEvaluated'), testResult.LeftVentricleDimensionsNotEvaluated);
        setboolTypeReading($('#LeftVentricleDimensionsNormal'), testResult.LeftVentricleDimensionsNormal);
        setboolTypeReading($('#LeftVentricleDimensionsSmall'), testResult.LeftVentricleDimensionsSmall);
        setboolTypeReading($('#LeftVentricleDimensionsDilated'), testResult.LeftVentricleDimensionsDilated);
        setboolTypeReading($('#LeftVentricleDimensionsSlightlyEnlarged'), testResult.LeftVentricleDimensionsSlightlyEnlarged);
        setboolTypeReading($('#LeftVentricleDimensionsSeverelyDilated'), testResult.LeftVentricleDimensionsSeverelyDilated);

        setboolTypeReading($('#LeftVentricleThicknessesNotEvaluated'), testResult.LeftVentricleThicknessesNotEvaluated);
        setboolTypeReading($('#LeftVentricleThicknessesNormal'), testResult.LeftVentricleThicknessesNormal);
        setboolTypeReading($('#LeftVentricleThicknessesApicalHypertrophy'), testResult.LeftVentricleThicknessesApicalHypertrophy);
        setboolTypeReading($('#LeftVentricleThicknessesAsymmetricalHypertrophy'), testResult.LeftVentricleThicknessesAsymmetricalHypertrophy);
        setboolTypeReading($('#LeftVentricleThicknessesIVSeptumObstructiveHypertrophy'), testResult.LeftVentricleThicknessesIVSeptumObstructiveHypertrophy);
        setboolTypeReading($('#LeftVentricleThicknessesMinorModerateIVSeptumHypertrophy'), testResult.LeftVentricleThicknessesMinorModerateIVSeptumHypertrophy);
        setboolTypeReading($('#LeftVentricleThicknessesSevereIVSeptumHypertrophy'), testResult.LeftVentricleThicknessesSevereIVSeptumHypertrophy);
        setboolTypeReading($('#LeftVentricleThicknessesMinorModerateSymmetricHypertrophy'), testResult.LeftVentricleThicknessesMinorModerateSymmetricHypertrophy);
        setboolTypeReading($('#LeftVentricleThicknessesSevereSymmetricHypertrophy'), testResult.LeftVentricleThicknessesSevereSymmetricHypertrophy);
        setReading($('#LeftVentricleComment'), testResult.LeftVentricleComment);

        //Left Atrium + IAS
        setboolTypeReading($('#LeftAtriumIASLADimensionsNotEvaluated'), testResult.LeftAtriumIASLADimensionsNotEvaluated);
        setboolTypeReading($('#LeftAtriumIASLADimensionsNormal'), testResult.LeftAtriumIASLADimensionsNormal);
        setboolTypeReading($('#LeftAtriumIASLADimensionsMildlyDilated'), testResult.LeftAtriumIASLADimensionsMildlyDilated);
        setboolTypeReading($('#LeftAtriumIASLADimensionsModeratelyDilated'), testResult.LeftAtriumIASLADimensionsModeratelyDilated);
        setboolTypeReading($('#LeftAtriumIASLADimensionsSeverelyDilated'), testResult.LeftAtriumIASLADimensionsSeverelyDilated);
        setReading($('#LeftAtriumIASComment'), testResult.LeftAtriumIASComment);

        //Right Ventricle
        setboolTypeReading($('#RightVentricleOverallFunctionNotEvaluated'), testResult.RightVentricleOverallFunctionNotEvaluated);
        setboolTypeReading($('#RightVentricleOverallFunctionNormal'), testResult.RightVentricleOverallFunctionNormal);
        setboolTypeReading($('#RightVentricleOverallFunctionReduced'), testResult.RightVentricleOverallFunctionReduced);
        setboolTypeReading($('#RightVentricleOverallFunctionBorderline'), testResult.RightVentricleOverallFunctionBorderline);
        setboolTypeReading($('#RightVentricleOverallFunctionHyperkinesis'), testResult.RightVentricleOverallFunctionHyperkinesis);
        setboolTypeReading($('#RightVentricleOverallFunctionHypokinesis'), testResult.RightVentricleOverallFunctionHypokinesis);

        setboolTypeReading($('#RightVentricleDimensionsNotEvaluated'), testResult.RightVentricleDimensionsNotEvaluated);
        setboolTypeReading($('#RightVentricleDimensionsNormal'), testResult.RightVentricleDimensionsNormal);
        setboolTypeReading($('#RightVentricleDimensionsSmall'), testResult.RightVentricleDimensionsSmall);
        setboolTypeReading($('#RightVentricleDimensionsDilated'), testResult.RightVentricleDimensionsDilated);
        setboolTypeReading($('#RightVentricleDimensionsSlightlyEnlarged'), testResult.RightVentricleDimensionsSlightlyEnlarged);
        setboolTypeReading($('#RightVentricleDimensionsSeverelyDilated'), testResult.RightVentricleDimensionsSeverelyDilated);

        setboolTypeReading($('#RightVentricleThicknessesNotEvaluated'), testResult.RightVentricleThicknessesNotEvaluated);
        setboolTypeReading($('#RightVentricleThicknessesNormal'), testResult.RightVentricleThicknessesNormal);
        setboolTypeReading($('#RightVentricleThicknessesApicalHypertrophy'), testResult.RightVentricleThicknessesApicalHypertrophy);
        setboolTypeReading($('#RightVentricleThicknessesAsymmetricalHypertrophy'), testResult.RightVentricleThicknessesAsymmetricalHypertrophy);
        setboolTypeReading($('#RightVentricleThicknessesIVSeptumObstructiveHypertrophy'), testResult.RightVentricleThicknessesIVSeptumObstructiveHypertrophy);
        setboolTypeReading($('#RightVentricleThicknessesMinorModerateIVSeptumHypertrophy'), testResult.RightVentricleThicknessesMinorModerateIVSeptumHypertrophy);
        setboolTypeReading($('#RightVentricleThicknessesSevereIVSeptumHypertrophy'), testResult.RightVentricleThicknessesSevereIVSeptumHypertrophy);
        setboolTypeReading($('#RightVentricleThicknessesMinorModerateSymmetricHypertrophy'), testResult.RightVentricleThicknessesMinorModerateSymmetricHypertrophy);
        setboolTypeReading($('#RightVentricleThicknessesSevereSymmetricHypertrophy'), testResult.RightVentricleThicknessesSevereSymmetricHypertrophy);
        setReading($('#RightVentricleComment'), testResult.RightVentricleComment);

        // RightAtrium
        setboolTypeReading($('#RightAtriumRADimensionsNotEvaluated'), testResult.RightAtriumRADimensionsNotEvaluated);
        setboolTypeReading($('#RightAtriumRADimensionsNormal'), testResult.RightAtriumRADimensionsNormal);
        setboolTypeReading($('#RightAtriumRADimensionsMildlyDilated'), testResult.RightAtriumRADimensionsMildlyDilated);
        setboolTypeReading($('#RightAtriumRADimensionsModeratelyDilated'), testResult.RightAtriumRADimensionsModeratelyDilated);
        setboolTypeReading($('#RightAtriumRADimensionsSeverelyDilated'), testResult.RightAtriumRADimensionsSeverelyDilated);
        setReading($('#RightAtriumComment'), testResult.RightAtriumComment);

        //Aorta
        setboolTypeReading($('#AortaInsufficiencyAbsent'), testResult.AortaInsufficiencyAbsent);
        setboolTypeReading($('#AortaInsufficiencyMinor'), testResult.AortaInsufficiencyMinor);
        setboolTypeReading($('#AortaInsufficiencyModerate'), testResult.AortaInsufficiencyModerate);
        setboolTypeReading($('#AortaInsufficiencySevere'), testResult.AortaInsufficiencySevere);

        setboolTypeReading($('#AortaLeafletsNotEvaluated'), testResult.AortaLeafletsNotEvaluated);
        setboolTypeReading($('#AortaLeafletsNormal'), testResult.AortaLeafletsNormal);
        setboolTypeReading($('#AortaLeafletsMildStenosis'), testResult.AortaLeafletsMildStenosis);
        setboolTypeReading($('#AortaLeafletsModerateStenosis'), testResult.AortaLeafletsModerateStenosis);
        setboolTypeReading($('#AortaLeafletsSevereStenosis'), testResult.AortaLeafletsSevereStenosis);

        setboolTypeReading($('#AortaValveNotEvaluated'), testResult.AortaValveNotEvaluated);
        setboolTypeReading($('#AortaValveBicuspid'), testResult.AortaValveBicuspid);
        setboolTypeReading($('#AortaValveAtherosclerotic'), testResult.AortaValveAtherosclerotic);
        setboolTypeReading($('#AortaValveNormalFunctioningBiologicalProsthesis'), testResult.AortaValveNormalFunctioningBiologicalProsthesis);
        setboolTypeReading($('#AortaValveNormalFunctioningMechanicalProsthesis'), testResult.AortaValveNormalFunctioningMechanicalProsthesis);
        setboolTypeReading($('#AortaValveMalfunctioningBiologicalProsthesis'), testResult.AortaValveMalfunctioningBiologicalProsthesis);
        setboolTypeReading($('#AortaValveMalfunctioningMechanicalProsthesis'), testResult.AortaValveMalfunctioningMechanicalProsthesis);
        setboolTypeReading($('#AortaValveDilatedAorticRoot'), testResult.AortaValveDilatedAorticRoot);
        setboolTypeReading($('#AortaValveSinusValsalvaAneurysm'), testResult.AortaValveSinusValsalvaAneurysm);
        setReading($('#AortaComment'), testResult.AortaComment);

        //Mitral
        setboolTypeReading($('#MitralInsufficiencyAbsent'), testResult.MitralInsufficiencyAbsent);
        setboolTypeReading($('#MitralInsufficiencyMinor'), testResult.MitralInsufficiencyMinor);
        setboolTypeReading($('#MitralInsufficiencyModerate'), testResult.MitralInsufficiencyModerate);
        setboolTypeReading($('#MitralInsufficiencySevere'), testResult.MitralInsufficiencySevere);

        setboolTypeReading($('#MitralLeafletsNotEvaluated'), testResult.MitralLeafletsNotEvaluated);
        setboolTypeReading($('#MitralLeafletsNormal'), testResult.MitralLeafletsNormal);
        setboolTypeReading($('#MitralLeafletsRedundant'), testResult.MitralLeafletsRedundant);
        setboolTypeReading($('#MitralLeafletsMildStenosis'), testResult.MitralLeafletsMildStenosis);
        setboolTypeReading($('#MitralLeafletsModerateStenosis'), testResult.MitralLeafletsModerateStenosis);
        setboolTypeReading($('#MitralLeafletsSevereStenosis'), testResult.MitralLeafletsSevereStenosis);

        setboolTypeReading($('#MitralValveNotEvaluated'), testResult.MitralValveNotEvaluated);
        setboolTypeReading($('#MitralValveBicuspid'), testResult.MitralValveBicuspid);
        setboolTypeReading($('#MitralValveAtherosclerotic'), testResult.MitralValveAtherosclerotic);
        setboolTypeReading($('#MitralValveNormalFunctioningBiologicalProsthesis'), testResult.MitralValveNormalFunctioningBiologicalProsthesis);
        setboolTypeReading($('#MitralValveNormalFunctioningMechanicalProsthesis'), testResult.MitralValveNormalFunctioningMechanicalProsthesis);
        setboolTypeReading($('#MitralValveMalfunctioningBiologicalProsthesis'), testResult.MitralValveMalfunctioningBiologicalProsthesis);
        setboolTypeReading($('#MitralValveMalfunctioningMechanicalProsthesis'), testResult.MitralValveMalfunctioningMechanicalProsthesis);
        setReading($('#MitralValveComment'), testResult.MitralValveComment);

        //Pulmonary
        setboolTypeReading($('#PulmonaryInsufficiencyAbsent'), testResult.PulmonaryInsufficiencyAbsent);
        setboolTypeReading($('#PulmonaryInsufficiencyMinor'), testResult.PulmonaryInsufficiencyMinor);
        setboolTypeReading($('#PulmonaryInsufficiencyModerate'), testResult.PulmonaryInsufficiencyModerate);
        setboolTypeReading($('#PulmonaryInsufficiencySevere'), testResult.PulmonaryInsufficiencySevere);

        setboolTypeReading($('#PulmonaryLeafletsNormal'), testResult.PulmonaryLeafletsNormal);
        setboolTypeReading($('#PulmonaryLeafletsThickened'), testResult.PulmonaryLeafletsThickened);
        setboolTypeReading($('#PulmonaryLeafletsStenotic'), testResult.PulmonaryLeafletsStenotic);
        setboolTypeReading($('#PulmonaryLeafletsMildStenosis'), testResult.PulmonaryLeafletsMildStenosis);
        setboolTypeReading($('#PulmonaryLeafletsModerateStenosis'), testResult.PulmonaryLeafletsModerateStenosis);
        setboolTypeReading($('#PulmonaryLeafletsSevereStenosis'), testResult.PulmonaryLeafletsSevereStenosis);

        setboolTypeReading($('#PulmonaryValveNotEvaluated'), testResult.PulmonaryValveNotEvaluated);
        setboolTypeReading($('#PulmonaryValveBicuspid'), testResult.PulmonaryValveBicuspid);
        setboolTypeReading($('#PulmonaryValveAtherosclerotic'), testResult.PulmonaryValveAtherosclerotic);
        setboolTypeReading($('#PulmonaryValveNormalFunctioningBiologicalProsthesis'), testResult.PulmonaryValveNormalFunctioningBiologicalProsthesis);
        setboolTypeReading($('#PulmonaryValveNormalFunctioningMechanicalProsthesis'), testResult.PulmonaryValveNormalFunctioningMechanicalProsthesis);
        setboolTypeReading($('#PulmonaryValveMalfunctioningBiologicalProsthesis'), testResult.PulmonaryValveMalfunctioningBiologicalProsthesis);
        setboolTypeReading($('#PulmonaryValveMalfunctioningMechanicalProsthesis'), testResult.PulmonaryValveMalfunctioningMechanicalProsthesis);
        setReading($('#PulmonaryComment'), testResult.PulmonaryComment);

        //Tricuspid
        setboolTypeReading($('#TricuspidInsufficiencyAbsent'), testResult.TricuspidInsufficiencyAbsent);
        setboolTypeReading($('#TricuspidInsufficiencyMinor'), testResult.TricuspidInsufficiencyMinor);
        setboolTypeReading($('#TricuspidInsufficiencyModerate'), testResult.TricuspidInsufficiencyModerate);
        setboolTypeReading($('#TricuspidInsufficiencySevere'), testResult.TricuspidInsufficiencySevere);

        setboolTypeReading($('#TricuspidLeafletsNormal'), testResult.TricuspidLeafletsNormal);
        setboolTypeReading($('#TricuspidLeafletsThickened'), testResult.TricuspidLeafletsThickened);
        setboolTypeReading($('#TricuspidLeafletsRedundant'), testResult.TricuspidLeafletsRedundant);
        setboolTypeReading($('#TricuspidLeafletsMildStenosis'), testResult.TricuspidLeafletsMildStenosis);
        setboolTypeReading($('#TricuspidLeafletsModerateStenosis'), testResult.TricuspidLeafletsModerateStenosis);
        setboolTypeReading($('#TricuspidLeafletsSevereStenosis'), testResult.TricuspidLeafletsSevereStenosis);

        setboolTypeReading($('#TricuspidValveNotEvaluated'), testResult.TricuspidValveNotEvaluated);
        setboolTypeReading($('#TricuspidValveBicuspid'), testResult.TricuspidValveBicuspid);
        setboolTypeReading($('#TricuspidValveAtherosclerotic'), testResult.TricuspidValveAtherosclerotic);
        setboolTypeReading($('#TricuspidValveNormalFunctioningBiologicalProsthesis'), testResult.TricuspidValveNormalFunctioningBiologicalProsthesis);
        setboolTypeReading($('#TricuspidValveNormalFunctioningMechanicalProsthesis'), testResult.TricuspidValveNormalFunctioningMechanicalProsthesis);
        setboolTypeReading($('#TricuspidValveMalfunctioningBiologicalProsthesis'), testResult.TricuspidValveMalfunctioningBiologicalProsthesis);
        setboolTypeReading($('#TricuspidValveMalfunctioningMechanicalProsthesis'), testResult.TricuspidValveMalfunctioningMechanicalProsthesis);

        setReading($('#TricuspidComment'), testResult.TricuspidComment);

        /**********************************************************************************************************************************************/

        if (testResult.Finding != null) {
            setSelectedFindingDatalist($(".AwvEcho-finding"), testResult.Finding.Id);
        }

        if (testResult.EstimatedEjactionFraction != null) {
            setSelectedFindingDatalist($(".AwvEcho-ejaction-fraction-finding"), testResult.EstimatedEjactionFraction.Id);
        }

        if (testResult.AorticRegurgitation != null) {
            setSelectedFindingDatalist($(".AwvEchoaortic-regurgitation-finding"), testResult.AorticRegurgitation.Id);
        }

        if (testResult.MitralRegurgitation != null) {
            setSelectedFindingDatalist($(".AwvEchomitral-regurgitation-finding"), testResult.MitralRegurgitation.Id);
        }

        if (testResult.PulmonicRegurgitation != null) {
            setSelectedFindingDatalist($(".AwvEchopulmonic-regurgitation-finding"), testResult.PulmonicRegurgitation.Id);
        }

        if (testResult.TricuspidRegurgitation != null) {
            setSelectedFindingDatalist($(".AwvEchotricuspid-regurgitation-finding"), testResult.TricuspidRegurgitation.Id);
        }

        if (testResult.DistolicDysfunctionFinding != null) {
            setSelectedFindingDatalist($(".AwvEchodiastolic-dysfunction-finding"), testResult.DistolicDysfunctionFinding.Id);
        }

        setMultipleFindingDatalist($('.AwvEchoaortic-morphology-finding'), testResult.AorticMorphology);
        setMultipleFindingDatalist($('.AwvEchomitral-morphology-finding'), testResult.MitralMorphology);
        setMultipleFindingDatalist($('.AwvEchopulmonic-morphology-finding'), testResult.PulmonicMorphology);
        setMultipleFindingDatalist($('.AwvEchotricuspid-morphology-finding'), testResult.TricuspidMorphology);
        setMultipleFindingDatalist($('.AwvEchopericardial-effusion-finding'), testResult.PericardialEffusionFinding);

        $("#PriorityInQueueTestAwvEchoCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#awvEcho-priorityInQueue-span"), "onClick_PriorityInQueueDataAwvEcho();", testTypeAwvEcho);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#awvEcho-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#AwvEcho-critical-span"), "onClick_CriticalDataAwvEcho();", testTypeAwvEcho);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#AwvEcho-critical-span").parent().addClass("red-band");
                $("#criticalAwvEcho").attr("checked", "checked");
            }
        }

        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksAwvEcho").val(testResult.PhysicianInterpretation.Remarks);
            $("#criticalAwvEcho").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalAwvEcho").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }

        if (currentScreenMode == ScreenMode.Physician) {
            $("#clear-all-regurgitationAwvEcho").show();
        }
        //setAwvEchoConclusion();
    },
    getData: function () {
        var testResult = this.Result;
        if (IsawvEchoResultEntryExternaly == 'True') {
             testResult.TestPerformedExternally = getTestPerformedExternally("chk_awvEchocapturebyChat", testResult.TestPerformedExternally)
        }
        
        if (currentScreenMode != ScreenMode.Entry) {
            testResult.Aortic = getboolTypeReading($('#AwvEchoValveAorticCheckbox'), testResult.Aortic);
            testResult.Mitral = getboolTypeReading($('#AwvEchoValveMitralCheckbox'), testResult.Mitral);
            testResult.Pulmonic = getboolTypeReading($('#AwvEchoValvePulmonicCheckbox'), testResult.Pulmonic);
            testResult.Tricuspid = getboolTypeReading($('#AwvEchoValveTricuspidCheckbox'), testResult.Tricuspid);

            testResult.AoticVelocity = getReading($('#AwvEchoAorticVelocityTextbox'), testResult.AoticVelocity);
            testResult.PeakGradient = getReading($('#PeakGradient'), testResult.PeakGradient);
            testResult.MitralPT = getReading($('#AwvEchoPTTextbox'), testResult.MitralPT);
            testResult.PulmonicVelocity = getReading($('#AwvEchoVelocityPulmonicTextbox'), testResult.PulmonicVelocity);
            testResult.TricuspidVelocity = getReading($('#AwvEchoVelocityTricuspidTextbox'), testResult.TricuspidVelocity);
            testResult.TricuspidPap = getReading($('#AwvEchoPapTextbox'), testResult.TricuspidPap);

            testResult.AorticEstimatedValveArea = getReading($('#AorticEstimatedValveArea'), testResult.AorticEstimatedValveArea);
            testResult.MitralEstimatedValveArea = getReading($('#MitralEstimatedValveArea'), testResult.MitralEstimatedValveArea);
            testResult.PulmonicEstimatedValveArea = getReading($('#PulmonicEstimatedValveArea'), testResult.PulmonicEstimatedValveArea);
            testResult.TricuspidEstimatedValveArea = getReading($('#TricuspidEstimatedValveArea'), testResult.TricuspidEstimatedValveArea);
            
            testResult.AorticEstimatedRightValve = getReading($('#AorticEstimatedRightValve'), testResult.AorticEstimatedRightValve);
            testResult.MitralEstimatedRightValve = getReading($('#MitralEstimatedRightValve'), testResult.MitralEstimatedRightValve);

            testResult.PericardialEffusion = getboolTypeReading($('#AwvEchoPericardialEffusionCheckbox'), testResult.PericardialEffusion);
            testResult.DiastolicDysfunction = getboolTypeReading($('#AwvEchoDiastolicDysfunctionCheckbox'), testResult.DiastolicDysfunction);
            
            testResult.DiastolicDysfunctionEeRatio = getReading($('#DiastolicDysfunctionEeRatio'), testResult.DiastolicDysfunctionEeRatio);

            testResult.VentricularEnlargement = getboolTypeReading($('#AwvEchoVentricularEnlargmentCheckbox'), testResult.VentricularEnlargement);
            testResult.LeftVentricularEnlargmentValue = getReading($('#AwvEchoLeftVEnlargementTextbox'), testResult.LeftVentricularEnlargmentValue);
            testResult.RightVentricularEnlargmentValue = getReading($('#AwvEchoRightVEnlargementTextbox'), testResult.RightVentricularEnlargmentValue);
            testResult.LeftVentricularEnlargment = getboolTypeReading($('#AwvEchoLeftVEnlargementCheckbox'), testResult.LeftVentricularEnlargment);
            testResult.RightVentricularEnlargment = getboolTypeReading($('#AwvEchoRightVEnlargementCheckbox'), testResult.RightVentricularEnlargment);

            testResult.AorticRoot = getboolTypeReading($('#AwvEchoAorticRootCheckbox'), testResult.AorticRoot);
            testResult.Sclerotic = getboolTypeReading($('#AwvEchoScleroticCheckbox'), testResult.Sclerotic);
            testResult.Calcified = getboolTypeReading($('#AwvEchoCalcifiedCheckbox'), testResult.Calcified);
            testResult.Enlarged = getboolTypeReading($('#AwvEchoEnlargedCheckbox'), testResult.Enlarged);
            testResult.EnlargedValue = getReading($('#AwvEchoEnlargedTextbox'), testResult.EnlargedValue);
            
            testResult.AscendingAortaArch = getboolTypeReading($('#AwvEchoAscendingAortaArchCheckbox'), testResult.AscendingAortaArch);
            testResult.Atherosclerosis = getboolTypeReading($('#AwvEchoAtherosclerosisCheckbox'), testResult.Atherosclerosis);


            testResult.RestrictedLeafletMotion = getboolTypeReading($('#AwvEchoRestrictedLeafletCheckbox'), testResult.RestrictedLeafletMotion);
            testResult.RestrictedLeafletMotionAortic = getboolTypeReading($('#AwvEchoRestrictedLeafletAorticCheckbox'), testResult.RestrictedLeafletMotionAortic);
            testResult.RestrictedLeafletMotionMitral = getboolTypeReading($('#AwvEchoRestrictedLeafletMitralCheckbox'), testResult.RestrictedLeafletMotionMitral);
            testResult.RestrictedLeafletMotionPulmonic = getboolTypeReading($('#AwvEchoRestrictedLeafletPulCheckbox'), testResult.RestrictedLeafletMotionPulmonic);
            testResult.RestrictedLeafletMotionTricuspid = getboolTypeReading($('#AwvEchoRestrictedLeafletTriCheckbox'), testResult.RestrictedLeafletMotionTricuspid);


            testResult.VentricularHypertrophy = getboolTypeReading($('#AwvEchoVentricularHypertrophyCheckbox'), testResult.VentricularHypertrophy);
            testResult.LeftVHypertrophyValue = getReading($('#AwvEchoLeftVHypertrophyTextbox'), testResult.LeftVHypertrophyValue);
            testResult.RightVHypertrophyValue = getReading($('#AwvEchoRightVHypertrophyTextbox'), testResult.RightVHypertrophyValue);
            testResult.IvshHypertrophyValue = getReading($('#AwvEchoIvshTextbox'), testResult.IvshHypertrophyValue);

            testResult.LeftVHypertrophy = getboolTypeReading($('#AwvEchoLeftVHypertrophyCheckbox'), testResult.LeftVHypertrophy);
            testResult.RightVHypertrophy = getboolTypeReading($('#AwvEchoRightVHypertrophyCheckbox'), testResult.RightVHypertrophy);
            testResult.IvshHypertrophy = getboolTypeReading($('#AwvEchoIvshCheckbox'), testResult.IvshHypertrophy);

            testResult.AtrialEnlargement = getboolTypeReading($('#AwvEchoAtrialEnlargmentCheckbox'), testResult.AtrialEnlargement);
            testResult.LeftAtrialEnlargmentValue = getReading($('#AwvEchoLeftAtrialEnlargementTextbox'), testResult.LeftAtrialEnlargmentValue);
            testResult.RightAtrialEnlargmentValue = getReading($('#AwvEchoRightAtrialEnlargementTextbox'), testResult.RightAtrialEnlargmentValue);

            testResult.LeftAtrialEnlargment = getboolTypeReading($('#AwvEchoLeftAtrialEnlargementCheckbox'), testResult.LeftAtrialEnlargment);
            testResult.RightAtrialEnlargment = getboolTypeReading($('#AwvEchoRightAtrialEnlargementCheckbox'), testResult.RightAtrialEnlargment);
            testResult.Arrythmia = getboolTypeReading($('#AwvEchoArrythmiaCheckbox'), testResult.Arrythmia);

            testResult.AFib = getboolTypeReading($('#AwvEchoAFibCheckbox'), testResult.AFib);
            testResult.AFlutter = getboolTypeReading($('#AwvEchoAFlutterCheckbox'), testResult.AFlutter);
            testResult.PAC = getboolTypeReading($('#AwvEchoPACCheckbox'), testResult.PAC);
            testResult.PVC = getboolTypeReading($('#AwvEchoPVCCheckbox'), testResult.PVC);

            testResult.ASD = getboolTypeReading($('#AwvEchoAsdCheckbox'), testResult.ASD);
            testResult.PFO = getboolTypeReading($('#AwvEchoPfoCheckbox'), testResult.PFO);
            testResult.VSD = getboolTypeReading($('#AwvEchoVsdCheckbox'), testResult.VSD);
            testResult.FlailAS = getboolTypeReading($('#AwvEchoFlailCheckbox'), testResult.FlailAS);
          
            testResult.MitralAnnularCa = getboolTypeReading($('#AwvEchoMitralAnnularCheckbox'), testResult.MitralAnnularCa);

            testResult.Hypokinetic = getboolTypeReading($('#AwvEchoHypokineticCheckbox'), testResult.Hypokinetic);
            testResult.Akinetic = getboolTypeReading($('#AwvEchoAkineticCheckbox'), testResult.Akinetic);
            testResult.Dyskinetic = getboolTypeReading($('#AwvEchoDyskineticCheckbox'), testResult.Dyskinetic);
            testResult.Anterior = getboolTypeReading($('#AwvEchoAnteriorCheckbox'), testResult.Anterior);
            testResult.Posterior = getboolTypeReading($('#AwvEchoPosteriorCheckbox'), testResult.Posterior);
            testResult.Apical = getboolTypeReading($('#AwvEchoApicalCheckbox'), testResult.Apical);
            testResult.Septal = getboolTypeReading($('#AwvEchoSeptalCheckbox'), testResult.Septal);
            testResult.Lateral = getboolTypeReading($('#AwvEchoLateralCheckbox'), testResult.Lateral);
            testResult.Inferior = getboolTypeReading($('#AwvEchoInferiorCheckbox'), testResult.Inferior);

            testResult.Finding = getFindingDataandSynchronized(testResult.Finding, getSelectedFindingDatalist($(".AwvEcho-finding")));
            testResult.EstimatedEjactionFraction = getFindingDataandSynchronized(testResult.EstimatedEjactionFraction, getSelectedFindingDatalist($(".AwvEcho-ejaction-fraction-finding")));
            testResult.AorticRegurgitation = getFindingDataandSynchronized(testResult.AorticRegurgitation, getSelectedFindingDatalist($(".AwvEchoaortic-regurgitation-finding")));
            testResult.MitralRegurgitation = getFindingDataandSynchronized(testResult.MitralRegurgitation, getSelectedFindingDatalist($(".AwvEchomitral-regurgitation-finding")));
            testResult.PulmonicRegurgitation = getFindingDataandSynchronized(testResult.PulmonicRegurgitation, getSelectedFindingDatalist($(".AwvEchopulmonic-regurgitation-finding")));
            testResult.TricuspidRegurgitation = getFindingDataandSynchronized(testResult.TricuspidRegurgitation, getSelectedFindingDatalist($(".AwvEchotricuspid-regurgitation-finding")));

            testResult.AorticMorphology = getMultipleFindingDataandSynchronized(testResult.AorticMorphology, getMultipleFindingDatalist($('.AwvEchoaortic-morphology-finding')));
            testResult.MitralMorphology = getMultipleFindingDataandSynchronized(testResult.MitralMorphology, getMultipleFindingDatalist($('.AwvEchomitral-morphology-finding')));
            testResult.TricuspidMorphology = getMultipleFindingDataandSynchronized(testResult.TricuspidMorphology, getMultipleFindingDatalist($('.AwvEchotricuspid-morphology-finding')));
            testResult.PulmonicMorphology = getMultipleFindingDataandSynchronized(testResult.PulmonicMorphology, getMultipleFindingDatalist($('.AwvEchopulmonic-morphology-finding')));

            testResult.PericardialEffusionFinding = getMultipleFindingDataandSynchronized(testResult.PericardialEffusionFinding, getMultipleFindingDatalist($('.AwvEchopericardial-effusion-finding')));
            testResult.DistolicDysfunctionFinding = getFindingDataandSynchronized(testResult.DistolicDysfunctionFinding, getSelectedFindingDatalist($('.AwvEchodiastolic-dysfunction-finding')));

            testResult.TechnicallyLimitedbutReadable = getboolTypeReading($('#AwvEchotechnicalltdreadableinputcheck'), testResult.TechnicallyLimitedbutReadable);
            testResult.RepeatStudyUnreadable = getboolTypeReading($('#AwvEchorepeatstudyunreadableinputcheck'), testResult.RepeatStudyUnreadable);

            testResult.MorphologyTricuspidHighOrGreater = getboolTypeReading($('#AwvEchoMorphologyTricuspidHigh35MmHgOrGreaterCheckbox'), testResult.MorphologyTricuspidHighOrGreater);
            testResult.MorphologyTricuspidNormal = getboolTypeReading($('#AwvEchoMorphologyTricuspidNormalCheckbox'), testResult.MorphologyTricuspidNormal);

            /**********************************************************************************************************************************************/
            testResult.Conclusion = getReading($('#Conclusion'), testResult.Conclusion);

            testResult.ConsistentLvDiastolicFailure = getboolTypeReading($('#AwvEchoConsistentLvDiastolicFailureCheckbox'), testResult.ConsistentLvDiastolicFailure);
            testResult.ConsistentHypertensiveHeartDiseaseWithDiastolicHeartFailure = getboolTypeReading($('#AwvEchoConsistentHypertensiveHeartDiseaseWithDiastolicHeartFailureCheckbox'), testResult.ConsistentHypertensiveHeartDiseaseWithDiastolicHeartFailure);
            testResult.ConsistentHypertensiveHeartDiseaseWithoutDiastolicHeartFailure = getboolTypeReading($('#AwvEchoConsistentHypertensiveHeartDiseaseWithoutDiastolicHeartFailureCheckbox'), testResult.ConsistentHypertensiveHeartDiseaseWithoutDiastolicHeartFailure);

            //LeftVentricle
            testResult.LeftVentricleOverallFunctionNotEvaluated = getboolTypeReading($('#LeftVentricleOverallFunctionNotEvaluated'), testResult.LeftVentricleOverallFunctionNotEvaluated);
            testResult.LeftVentricleOverallFunctionNormal = getboolTypeReading($('#LeftVentricleOverallFunctionNormal'), testResult.LeftVentricleOverallFunctionNormal);
            testResult.LeftVentricleOverallFunctionReduced = getboolTypeReading($('#LeftVentricleOverallFunctionReduced'), testResult.LeftVentricleOverallFunctionReduced);
            testResult.LeftVentricleOverallFunctionBorderline = getboolTypeReading($('#LeftVentricleOverallFunctionBorderline'), testResult.LeftVentricleOverallFunctionBorderline);
            testResult.LeftVentricleOverallFunctionHyperkinesis = getboolTypeReading($('#LeftVentricleOverallFunctionHyperkinesis'), testResult.LeftVentricleOverallFunctionHyperkinesis);
            testResult.LeftVentricleOverallFunctionHypokinesis = getboolTypeReading($('#LeftVentricleOverallFunctionHypokinesis'), testResult.LeftVentricleOverallFunctionHypokinesis);
            testResult.LeftVentricleOverallFunctionConsistentLvSystolicFailure = getboolTypeReading($('#LeftVentricleOverallFunctionConsistentLvSystolicFailure'), testResult.LeftVentricleOverallFunctionConsistentLvSystolicFailure);

            testResult.LeftVentricleDimensionsNotEvaluated = getboolTypeReading($('#LeftVentricleDimensionsNotEvaluated'), testResult.LeftVentricleDimensionsNotEvaluated);
            testResult.LeftVentricleDimensionsNormal = getboolTypeReading($('#LeftVentricleDimensionsNormal'), testResult.LeftVentricleDimensionsNormal);
            testResult.LeftVentricleDimensionsSmall = getboolTypeReading($('#LeftVentricleDimensionsSmall'), testResult.LeftVentricleDimensionsSmall);
            testResult.LeftVentricleDimensionsDilated = getboolTypeReading($('#LeftVentricleDimensionsDilated'), testResult.LeftVentricleDimensionsDilated);
            testResult.LeftVentricleDimensionsSlightlyEnlarged = getboolTypeReading($('#LeftVentricleDimensionsSlightlyEnlarged'), testResult.LeftVentricleDimensionsSlightlyEnlarged);
            testResult.LeftVentricleDimensionsSeverelyDilated = getboolTypeReading($('#LeftVentricleDimensionsSeverelyDilated'), testResult.LeftVentricleDimensionsSeverelyDilated);

            testResult.LeftVentricleThicknessesNotEvaluated = getboolTypeReading($('#LeftVentricleThicknessesNotEvaluated'), testResult.LeftVentricleThicknessesNotEvaluated);
            testResult.LeftVentricleThicknessesNormal = getboolTypeReading($('#LeftVentricleThicknessesNormal'), testResult.LeftVentricleThicknessesNormal);
            testResult.LeftVentricleThicknessesApicalHypertrophy = getboolTypeReading($('#LeftVentricleThicknessesApicalHypertrophy'), testResult.LeftVentricleThicknessesApicalHypertrophy);
            testResult.LeftVentricleThicknessesAsymmetricalHypertrophy = getboolTypeReading($('#LeftVentricleThicknessesAsymmetricalHypertrophy'), testResult.LeftVentricleThicknessesAsymmetricalHypertrophy);
            testResult.LeftVentricleThicknessesIVSeptumObstructiveHypertrophy = getboolTypeReading($('#LeftVentricleThicknessesIVSeptumObstructiveHypertrophy'), testResult.LeftVentricleThicknessesIVSeptumObstructiveHypertrophy);
            testResult.LeftVentricleThicknessesMinorModerateIVSeptumHypertrophy = getboolTypeReading($('#LeftVentricleThicknessesMinorModerateIVSeptumHypertrophy'), testResult.LeftVentricleThicknessesMinorModerateIVSeptumHypertrophy);
            testResult.LeftVentricleThicknessesSevereIVSeptumHypertrophy = getboolTypeReading($('#LeftVentricleThicknessesSevereIVSeptumHypertrophy'), testResult.LeftVentricleThicknessesSevereIVSeptumHypertrophy);
            testResult.LeftVentricleThicknessesMinorModerateSymmetricHypertrophy = getboolTypeReading($('#LeftVentricleThicknessesMinorModerateSymmetricHypertrophy'), testResult.LeftVentricleThicknessesMinorModerateSymmetricHypertrophy);
            testResult.LeftVentricleThicknessesSevereSymmetricHypertrophy = getboolTypeReading($('#LeftVentricleThicknessesSevereSymmetricHypertrophy'), testResult.LeftVentricleThicknessesSevereSymmetricHypertrophy);
            testResult.LeftVentricleComment = getReading($('#LeftVentricleComment'), testResult.LeftVentricleComment);

            //LeftAtrium
            testResult.LeftAtriumIASLADimensionsNotEvaluated = getboolTypeReading($('#LeftAtriumIASLADimensionsNotEvaluated'), testResult.LeftAtriumIASLADimensionsNotEvaluated);
            testResult.LeftAtriumIASLADimensionsNormal = getboolTypeReading($('#LeftAtriumIASLADimensionsNormal'), testResult.LeftAtriumIASLADimensionsNormal);
            testResult.LeftAtriumIASLADimensionsMildlyDilated = getboolTypeReading($('#LeftAtriumIASLADimensionsMildlyDilated'), testResult.LeftAtriumIASLADimensionsMildlyDilated);
            testResult.LeftAtriumIASLADimensionsModeratelyDilated = getboolTypeReading($('#LeftAtriumIASLADimensionsModeratelyDilated'), testResult.LeftAtriumIASLADimensionsModeratelyDilated);
            testResult.LeftAtriumIASLADimensionsSeverelyDilated = getboolTypeReading($('#LeftAtriumIASLADimensionsSeverelyDilated'), testResult.LeftAtriumIASLADimensionsSeverelyDilated);
            testResult.LeftAtriumIASComment = getReading($('#LeftAtriumIASComment'), testResult.LeftAtriumIASComment);

            //RightVentricle
            testResult.RightVentricleOverallFunctionNotEvaluated = getboolTypeReading($('#RightVentricleOverallFunctionNotEvaluated'), testResult.RightVentricleOverallFunctionNotEvaluated);
            testResult.RightVentricleOverallFunctionNormal = getboolTypeReading($('#RightVentricleOverallFunctionNormal'), testResult.RightVentricleOverallFunctionNormal);
            testResult.RightVentricleOverallFunctionReduced = getboolTypeReading($('#RightVentricleOverallFunctionReduced'), testResult.RightVentricleOverallFunctionReduced);
            testResult.RightVentricleOverallFunctionBorderline = getboolTypeReading($('#RightVentricleOverallFunctionBorderline'), testResult.RightVentricleOverallFunctionBorderline);
            testResult.RightVentricleOverallFunctionHyperkinesis = getboolTypeReading($('#RightVentricleOverallFunctionHyperkinesis'), testResult.RightVentricleOverallFunctionHyperkinesis);
            testResult.RightVentricleOverallFunctionHypokinesis = getboolTypeReading($('#RightVentricleOverallFunctionHypokinesis'), testResult.RightVentricleOverallFunctionHypokinesis);

            testResult.RightVentricleDimensionsNotEvaluated = getboolTypeReading($('#RightVentricleDimensionsNotEvaluated'), testResult.RightVentricleDimensionsNotEvaluated);
            testResult.RightVentricleDimensionsNormal = getboolTypeReading($('#RightVentricleDimensionsNormal'), testResult.RightVentricleDimensionsNormal);
            testResult.RightVentricleDimensionsSmall = getboolTypeReading($('#RightVentricleDimensionsSmall'), testResult.RightVentricleDimensionsSmall);
            testResult.RightVentricleDimensionsDilated = getboolTypeReading($('#RightVentricleDimensionsDilated'), testResult.RightVentricleDimensionsDilated);
            testResult.RightVentricleDimensionsSlightlyEnlarged = getboolTypeReading($('#RightVentricleDimensionsSlightlyEnlarged'), testResult.RightVentricleDimensionsSlightlyEnlarged);
            testResult.RightVentricleDimensionsSeverelyDilated = getboolTypeReading($('#RightVentricleDimensionsSeverelyDilated'), testResult.RightVentricleDimensionsSeverelyDilated);

            testResult.RightVentricleThicknessesNotEvaluated = getboolTypeReading($('#RightVentricleThicknessesNotEvaluated'), testResult.RightVentricleThicknessesNotEvaluated);
            testResult.RightVentricleThicknessesNormal = getboolTypeReading($('#RightVentricleThicknessesNormal'), testResult.RightVentricleThicknessesNormal);
            testResult.RightVentricleThicknessesApicalHypertrophy = getboolTypeReading($('#RightVentricleThicknessesApicalHypertrophy'), testResult.RightVentricleThicknessesApicalHypertrophy);
            testResult.RightVentricleThicknessesAsymmetricalHypertrophy = getboolTypeReading($('#RightVentricleThicknessesAsymmetricalHypertrophy'), testResult.RightVentricleThicknessesAsymmetricalHypertrophy);
            testResult.RightVentricleThicknessesIVSeptumObstructiveHypertrophy = getboolTypeReading($('#RightVentricleThicknessesIVSeptumObstructiveHypertrophy'), testResult.RightVentricleThicknessesIVSeptumObstructiveHypertrophy);
            testResult.RightVentricleThicknessesMinorModerateIVSeptumHypertrophy = getboolTypeReading($('#RightVentricleThicknessesMinorModerateIVSeptumHypertrophy'), testResult.RightVentricleThicknessesMinorModerateIVSeptumHypertrophy);
            testResult.RightVentricleThicknessesSevereIVSeptumHypertrophy = getboolTypeReading($('#RightVentricleThicknessesSevereIVSeptumHypertrophy'), testResult.RightVentricleThicknessesSevereIVSeptumHypertrophy);
            testResult.RightVentricleThicknessesMinorModerateSymmetricHypertrophy = getboolTypeReading($('#RightVentricleThicknessesMinorModerateSymmetricHypertrophy'), testResult.RightVentricleThicknessesMinorModerateSymmetricHypertrophy);
            testResult.RightVentricleThicknessesSevereSymmetricHypertrophy = getboolTypeReading($('#RightVentricleThicknessesSevereSymmetricHypertrophy'), testResult.RightVentricleThicknessesSevereSymmetricHypertrophy);
            testResult.RightVentricleComment = getReading($('#RightVentricleComment'), testResult.RightVentricleComment);

            // RightAtrium
            testResult.RightAtriumRADimensionsNotEvaluated = getboolTypeReading($('#RightAtriumRADimensionsNotEvaluated'), testResult.RightAtriumRADimensionsNotEvaluated);
            testResult.RightAtriumRADimensionsNormal = getboolTypeReading($('#RightAtriumRADimensionsNormal'), testResult.RightAtriumRADimensionsNormal);
            testResult.RightAtriumRADimensionsMildlyDilated = getboolTypeReading($('#RightAtriumRADimensionsMildlyDilated'), testResult.RightAtriumRADimensionsMildlyDilated);
            testResult.RightAtriumRADimensionsModeratelyDilated = getboolTypeReading($('#RightAtriumRADimensionsModeratelyDilated'), testResult.RightAtriumRADimensionsModeratelyDilated);
            testResult.RightAtriumRADimensionsSeverelyDilated = getboolTypeReading($('#RightAtriumRADimensionsSeverelyDilated'), testResult.RightAtriumRADimensionsSeverelyDilated);
            testResult.RightAtriumComment = getReading($('#RightAtriumComment'), testResult.RightAtriumComment);

            //Aorta
            testResult.AortaInsufficiencyAbsent = getboolTypeReading($('#AortaInsufficiencyAbsent'), testResult.AortaInsufficiencyAbsent);
            testResult.AortaInsufficiencyMinor = getboolTypeReading($('#AortaInsufficiencyMinor'), testResult.AortaInsufficiencyMinor);
            testResult.AortaInsufficiencyModerate = getboolTypeReading($('#AortaInsufficiencyModerate'), testResult.AortaInsufficiencyModerate);
            testResult.AortaInsufficiencySevere = getboolTypeReading($('#AortaInsufficiencySevere'), testResult.AortaInsufficiencySevere);

            testResult.AortaLeafletsNotEvaluated = getboolTypeReading($('#AortaLeafletsNotEvaluated'), testResult.AortaLeafletsNotEvaluated);
            testResult.AortaLeafletsNormal = getboolTypeReading($('#AortaLeafletsNormal'), testResult.AortaLeafletsNormal);
            testResult.AortaLeafletsMildStenosis = getboolTypeReading($('#AortaLeafletsMildStenosis'), testResult.AortaLeafletsMildStenosis);
            testResult.AortaLeafletsModerateStenosis = getboolTypeReading($('#AortaLeafletsModerateStenosis'), testResult.AortaLeafletsModerateStenosis);
            testResult.AortaLeafletsSevereStenosis = getboolTypeReading($('#AortaLeafletsSevereStenosis'), testResult.AortaLeafletsSevereStenosis);

            testResult.AortaValveNotEvaluated = getboolTypeReading($('#AortaValveNotEvaluated'), testResult.AortaValveNotEvaluated);
            testResult.AortaValveBicuspid = getboolTypeReading($('#AortaValveBicuspid'), testResult.AortaValveBicuspid);
            testResult.AortaValveAtherosclerotic = getboolTypeReading($('#AortaValveAtherosclerotic'), testResult.AortaValveAtherosclerotic);
            testResult.AortaValveNormalFunctioningBiologicalProsthesis = getboolTypeReading($('#AortaValveNormalFunctioningBiologicalProsthesis'), testResult.AortaValveNormalFunctioningBiologicalProsthesis);
            testResult.AortaValveNormalFunctioningMechanicalProsthesis = getboolTypeReading($('#AortaValveNormalFunctioningMechanicalProsthesis'), testResult.AortaValveNormalFunctioningMechanicalProsthesis);
            testResult.AortaValveMalfunctioningBiologicalProsthesis = getboolTypeReading($('#AortaValveMalfunctioningBiologicalProsthesis'), testResult.AortaValveMalfunctioningBiologicalProsthesis);
            testResult.AortaValveMalfunctioningMechanicalProsthesis = getboolTypeReading($('#AortaValveMalfunctioningMechanicalProsthesis'), testResult.AortaValveMalfunctioningMechanicalProsthesis);
            testResult.AortaValveDilatedAorticRoot = getboolTypeReading($('#AortaValveDilatedAorticRoot'), testResult.AortaValveDilatedAorticRoot);
            testResult.AortaValveSinusValsalvaAneurysm = getboolTypeReading($('#AortaValveSinusValsalvaAneurysm'), testResult.AortaValveSinusValsalvaAneurysm);
            testResult.AortaComment = getReading($('#AortaComment'), testResult.AortaComment);
            
            //Mitral
            testResult.MitralInsufficiencyAbsent = getboolTypeReading($('#MitralInsufficiencyAbsent'), testResult.MitralInsufficiencyAbsent);
            testResult.MitralInsufficiencyMinor = getboolTypeReading($('#MitralInsufficiencyMinor'), testResult.MitralInsufficiencyMinor);
            testResult.MitralInsufficiencyModerate = getboolTypeReading($('#MitralInsufficiencyModerate'), testResult.MitralInsufficiencyModerate);
            testResult.MitralInsufficiencySevere = getboolTypeReading($('#MitralInsufficiencySevere'), testResult.MitralInsufficiencySevere);

            testResult.MitralLeafletsNotEvaluated = getboolTypeReading($('#MitralLeafletsNotEvaluated'), testResult.MitralLeafletsNotEvaluated);
            testResult.MitralLeafletsNormal = getboolTypeReading($('#MitralLeafletsNormal'), testResult.MitralLeafletsNormal);
            testResult.MitralLeafletsRedundant = getboolTypeReading($('#MitralLeafletsRedundant'), testResult.MitralLeafletsRedundant);
            testResult.MitralLeafletsMildStenosis = getboolTypeReading($('#MitralLeafletsMildStenosis'), testResult.MitralLeafletsMildStenosis);
            testResult.MitralLeafletsModerateStenosis = getboolTypeReading($('#MitralLeafletsModerateStenosis'), testResult.MitralLeafletsModerateStenosis);
            testResult.MitralLeafletsSevereStenosis = getboolTypeReading($('#MitralLeafletsSevereStenosis'), testResult.MitralLeafletsSevereStenosis);

            testResult.MitralValveNotEvaluated = getboolTypeReading($('#MitralValveNotEvaluated'), testResult.MitralValveNotEvaluated);
            testResult.MitralValveBicuspid = getboolTypeReading($('#MitralValveBicuspid'), testResult.MitralValveBicuspid);
            testResult.MitralValveAtherosclerotic = getboolTypeReading($('#MitralValveAtherosclerotic'), testResult.MitralValveAtherosclerotic);
            testResult.MitralValveNormalFunctioningBiologicalProsthesis = getboolTypeReading($('#MitralValveNormalFunctioningBiologicalProsthesis'), testResult.MitralValveNormalFunctioningBiologicalProsthesis);
            testResult.MitralValveNormalFunctioningMechanicalProsthesis = getboolTypeReading($('#MitralValveNormalFunctioningMechanicalProsthesis'), testResult.MitralValveNormalFunctioningMechanicalProsthesis);
            testResult.MitralValveMalfunctioningBiologicalProsthesis = getboolTypeReading($('#MitralValveMalfunctioningBiologicalProsthesis'), testResult.MitralValveMalfunctioningBiologicalProsthesis);
            testResult.MitralValveMalfunctioningMechanicalProsthesis = getboolTypeReading($('#MitralValveMalfunctioningMechanicalProsthesis'), testResult.MitralValveMalfunctioningMechanicalProsthesis);
            testResult.MitralValveComment = getReading($('#MitralValveComment'), testResult.MitralValveComment);

            //Pulmonary
            testResult.PulmonaryInsufficiencyAbsent = getboolTypeReading($('#PulmonaryInsufficiencyAbsent'), testResult.PulmonaryInsufficiencyAbsent);
            testResult.PulmonaryInsufficiencyMinor = getboolTypeReading($('#PulmonaryInsufficiencyMinor'), testResult.PulmonaryInsufficiencyMinor);
            testResult.PulmonaryInsufficiencyModerate = getboolTypeReading($('#PulmonaryInsufficiencyModerate'), testResult.PulmonaryInsufficiencyModerate);
            testResult.PulmonaryInsufficiencySevere = getboolTypeReading($('#PulmonaryInsufficiencySevere'), testResult.PulmonaryInsufficiencySevere);

            testResult.PulmonaryLeafletsNormal = getboolTypeReading($('#PulmonaryLeafletsNormal'), testResult.PulmonaryLeafletsNormal);
            testResult.PulmonaryLeafletsThickened = getboolTypeReading($('#PulmonaryLeafletsThickened'), testResult.PulmonaryLeafletsThickened);
            testResult.PulmonaryLeafletsStenotic = getboolTypeReading($('#PulmonaryLeafletsStenotic'), testResult.PulmonaryLeafletsStenotic);
            testResult.PulmonaryLeafletsMildStenosis = getboolTypeReading($('#PulmonaryLeafletsMildStenosis'), testResult.PulmonaryLeafletsMildStenosis);
            testResult.PulmonaryLeafletsModerateStenosis = getboolTypeReading($('#PulmonaryLeafletsModerateStenosis'), testResult.PulmonaryLeafletsModerateStenosis);
            testResult.PulmonaryLeafletsSevereStenosis = getboolTypeReading($('#PulmonaryLeafletsSevereStenosis'), testResult.PulmonaryLeafletsSevereStenosis);

            testResult.PulmonaryValveNotEvaluated = getboolTypeReading($('#PulmonaryValveNotEvaluated'), testResult.PulmonaryValveNotEvaluated);
            testResult.PulmonaryValveBicuspid = getboolTypeReading($('#PulmonaryValveBicuspid'), testResult.PulmonaryValveBicuspid);
            testResult.PulmonaryValveAtherosclerotic = getboolTypeReading($('#PulmonaryValveAtherosclerotic'), testResult.PulmonaryValveAtherosclerotic);
            testResult.PulmonaryValveNormalFunctioningBiologicalProsthesis = getboolTypeReading($('#PulmonaryValveNormalFunctioningBiologicalProsthesis'), testResult.PulmonaryValveNormalFunctioningBiologicalProsthesis);
            testResult.PulmonaryValveNormalFunctioningMechanicalProsthesis = getboolTypeReading($('#PulmonaryValveNormalFunctioningMechanicalProsthesis'), testResult.PulmonaryValveNormalFunctioningMechanicalProsthesis);
            testResult.PulmonaryValveMalfunctioningBiologicalProsthesis = getboolTypeReading($('#PulmonaryValveMalfunctioningBiologicalProsthesis'), testResult.PulmonaryValveMalfunctioningBiologicalProsthesis);
            testResult.PulmonaryValveMalfunctioningMechanicalProsthesis = getboolTypeReading($('#PulmonaryValveMalfunctioningMechanicalProsthesis'), testResult.PulmonaryValveMalfunctioningMechanicalProsthesis);
            testResult.PulmonaryComment = getReading($('#PulmonaryComment'), testResult.PulmonaryComment);

            //Tricuspid
            testResult.TricuspidInsufficiencyAbsent = getboolTypeReading($('#TricuspidInsufficiencyAbsent'), testResult.TricuspidInsufficiencyAbsent);
            testResult.TricuspidInsufficiencyMinor = getboolTypeReading($('#TricuspidInsufficiencyMinor'), testResult.TricuspidInsufficiencyMinor);
            testResult.TricuspidInsufficiencyModerate = getboolTypeReading($('#TricuspidInsufficiencyModerate'), testResult.TricuspidInsufficiencyModerate);
            testResult.TricuspidInsufficiencySevere = getboolTypeReading($('#TricuspidInsufficiencySevere'), testResult.TricuspidInsufficiencySevere);

            testResult.TricuspidLeafletsNormal = getboolTypeReading($('#TricuspidLeafletsNormal'), testResult.TricuspidLeafletsNormal);
            testResult.TricuspidLeafletsThickened = getboolTypeReading($('#TricuspidLeafletsThickened'), testResult.TricuspidLeafletsThickened);
            testResult.TricuspidLeafletsRedundant = getboolTypeReading($('#TricuspidLeafletsRedundant'), testResult.TricuspidLeafletsRedundant);
            testResult.TricuspidLeafletsMildStenosis = getboolTypeReading($('#TricuspidLeafletsMildStenosis'), testResult.TricuspidLeafletsMildStenosis);
            testResult.TricuspidLeafletsModerateStenosis = getboolTypeReading($('#TricuspidLeafletsModerateStenosis'), testResult.TricuspidLeafletsModerateStenosis);
            testResult.TricuspidLeafletsSevereStenosis = getboolTypeReading($('#TricuspidLeafletsSevereStenosis'), testResult.TricuspidLeafletsSevereStenosis);

            testResult.TricuspidValveNotEvaluated = getboolTypeReading($('#TricuspidValveNotEvaluated'), testResult.TricuspidValveNotEvaluated);
            testResult.TricuspidValveBicuspid = getboolTypeReading($('#TricuspidValveBicuspid'), testResult.TricuspidValveBicuspid);
            testResult.TricuspidValveAtherosclerotic = getboolTypeReading($('#TricuspidValveAtherosclerotic'), testResult.TricuspidValveAtherosclerotic);
            testResult.TricuspidValveNormalFunctioningBiologicalProsthesis = getboolTypeReading($('#TricuspidValveNormalFunctioningBiologicalProsthesis'), testResult.TricuspidValveNormalFunctioningBiologicalProsthesis);
            testResult.TricuspidValveNormalFunctioningMechanicalProsthesis = getboolTypeReading($('#TricuspidValveNormalFunctioningMechanicalProsthesis'), testResult.TricuspidValveNormalFunctioningMechanicalProsthesis);
            testResult.TricuspidValveMalfunctioningBiologicalProsthesis = getboolTypeReading($('#TricuspidValveMalfunctioningBiologicalProsthesis'), testResult.TricuspidValveMalfunctioningBiologicalProsthesis);
            testResult.TricuspidValveMalfunctioningMechanicalProsthesis = getboolTypeReading($('#TricuspidValveMalfunctioningMechanicalProsthesis'), testResult.TricuspidValveMalfunctioningMechanicalProsthesis);

            testResult.TricuspidComment = getReading($('#TricuspidComment'), testResult.TricuspidComment);

            /***********************************************************************************************************************************************/


            if (testResult.PhysicianInterpretation == null)
                testResult.PhysicianInterpretation = {
                    'Remarks': $("#physicianRemarksAwvEcho").val(), 'IsCritical': $("#criticalAwvEcho").attr("checked"), 'FollowUp': $("#followUpAwvEcho").attr("checked"), 'RecorderMetaData': {
                        'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate
                    }
                };
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksAwvEcho").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpAwvEcho").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalAwvEcho").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.AwvEcho-unabletoscreen-dtl')));

        testResult.TestNotPerformed = getTestNotPerformedReasonForAwvEcho(testResult.TestNotPerformed);

        if (currentScreenMode != ScreenMode.Physician) {
            var resultMedia = new Array();
            if (AwvEchoResultMedia != null) {
                $.each(AwvEchoResultMedia, function () { resultMedia.push(this); });
            }

            testResult.Media = resultMedia;
            if (currentScreenMode != ScreenMode.CorrectionPostEvaluation && currentScreenMode != ScreenMode.PostAudit) testResult.ResultStatus.StateNumber = $("#ResultStatusInputHidden").val();

            if (testResult.ResultStatus.Id > 0) {
                testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.ResultStatus.DataRecorderMetaData.DateModified = currentDate;
            }
            else {
                testResult.ResultStatus.DataRecorderMetaData = { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate };
            }
        }

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.TechnicianNotes = $.trim($("#technotesAwvEcho").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ConductedByOrgRoleUserId = $("#conductedbyAwvEcho option:selected").val();
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentAwvEchoInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestAwvEchoCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_54").attr("checked");


        if (testResult.ResultStatus.StateNumber < 4 && testResult.TechnicianNotes.length < 1 && testResult.ConductedByOrgRoleUserId == "0" && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.length < 1)
            && $("#DescribeSelfPresentAwvEchoInputCheck").attr("checked") == false && AwvEchoImageCount < 1)
            testResult = null;

        return testResult;
    }
}


var AwvEchoImageCount = 0;
var AwvEchoResultMedia = null;

function getAwvEchoMedia() {
    return AwvEchoResultMedia;
}

function LoadNewMediaAwvEcho(jsonMedia, correctJson) {
    AwvEchoResultMedia = jsonMedia;
    AwvEchoImageCount = 0;
    $("#AwvEchoMediaDiv").empty();
    if (jsonMedia == null || jsonMedia.length < 1) return;
    AwvEchoImageCount = jsonMedia.length;
    LoadNewMedia(jsonMedia, correctJson, $("#AwvEchoMediaDiv"));
}

var criticalDataModel_Echo = null;
function onClick_CriticalDataAwvEcho() {
    if ($("#DescribeSelfPresentAwvEchoInputCheck").attr("checked")) {
        loadCriticalLink($("#AwvEcho-critical-span"), "onClick_CriticalDataAwvEcho();", testTypeAwvEcho);
        openCriticalDataDialog(testTypeAwvEcho, $("#conductedbyAwvEcho"), $("#DescribeSelfPresentAwvEchoInputCheck"), setCriticalDataModel_Echo);
    }
    else {
        unloadCriticalLink($("#AwvEcho-critical-span"), testTypeAwvEcho);
    }
}

function setCriticalDataModel_Echo(model, printAfterSave) {
    if (model != null) {
        var testResult = GetAwvEchoData();
        saveSingleTestResult(testResult, model, $("#AwvEcho-critical-span"), "onClick_CriticalDataAwvEcho();", SetAwvEchoData, printAfterSave);
    }
}

function getCriticalDataModel_Echo() {
    if ($("#DescribeSelfPresentAwvEchoInputCheck").attr("checked") && criticalDataModel_Echo != null) {
        criticalDataModel_Echo.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_Echo;
    }
    return null;
}


function onClick_PriorityInQueueDataAwvEcho() {
    if ($("#PriorityInQueueTestAwvEchoCheck").attr("checked")) {
        loadPriorityInQueueLink($("#awvEcho-priorityInQueue-span"), "onClick_PriorityInQueueDataAwvEcho();", testTypeAwvEcho);
        openPriorityInQueueTestDialog(testTypeAwvEcho, $("#conductedbyAwvEcho"), $("#PriorityInQueueTestAwvEchoCheck"), setPriorityInQueueDataModel_AwvEcho);
    }
    else {
        unloadPriorityInQueueLink($("#awvEcho-priorityInQueue-span"), testTypeAwvEcho);
    }
}

function setPriorityInQueueDataModel_AwvEcho(model) {
    if (model != null) {
        var testResult = GetAwvEchoData();
        model.TestId = testTypeAwvEcho;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#awvEcho-priorityInQueue-span"), "onClick_PriorityInQueueDataAwvEcho();", SetAwvEchoData);
    }
}


function clearAllAwvEchoRegurgitationSelection() {
    //debugger;
    $(".AwvEchoaortic-regurgitation-finding,.AwvEchomitral-regurgitation-finding,.AwvEchopulmonic-regurgitation-finding,.AwvEchotricuspid-regurgitation-finding").find("input[type=radio]").attr("checked", false);
}

function clearAllAwvEchoSelection() {
    $(".clear-all-AwvEcho-selection input[type=radio], .clear-all-AwvEcho-selection input[type=checkbox]").attr("checked", false);
}

$(document).ready(function () {
    $(".conclusion-section input[type='checkbox'],#AwvEchoPericardialEffusionCheckbox,#AwvEchoAorticRootCheckbox,.AwvEchodiastolic-dysfunction-finding input[type='radio'],.AwvEchopericardial-effusion-finding input[type='checkbox']").click(function () {
        setAwvEchoConclusion();
    });

    $("input[type='radio'][name='AwvEcho-finding-ejaction']").click(function () {
        setConsistentLvSystolicFailure(this);
    });
});

function setAwvEchoConclusion() {
    $("#Conclusion").val('');
    var value = '';

    if ($("#AwvEchoDiastolicDysfunctionCheckbox").is(":checked") && $(".AwvEchodiastolic-dysfunction-finding input[type='radio']:checked").length > 0) {
        var dysfunctionConclusion = "";
        $(".AwvEchodiastolic-dysfunction-finding input[type='radio']:checked").each(function () {
            if (dysfunctionConclusion == '') {
                dysfunctionConclusion = $(this).parent().find('label').text();
            } else {
                dysfunctionConclusion = dysfunctionConclusion + "," + $(this).parent().find('label').text();
            }
        });

        value = "Diastolic Dysfunction " + dysfunctionConclusion;
    }

    if ($("#AwvEchoPericardialEffusionCheckbox").is(":checked") && $(".AwvEchopericardial-effusion-finding input[type='checkbox']:checked").length > 0) {

        var pericardialConclusion = "";
        $(".AwvEchopericardial-effusion-finding input[type='checkbox']:checked").each(function () {
            if (pericardialConclusion == '') {
                pericardialConclusion = $(this).parent().find('label').text();
            } else {
                pericardialConclusion = pericardialConclusion + "," + $(this).parent().find('label').text();
            }
        });

        pericardialConclusion = "Pericardial Effusion " + pericardialConclusion;
        if (value == '') {
            value = pericardialConclusion;
        } else {
            value = value + "|" + pericardialConclusion;
        }
    }

    $(".conclusion-section input[type='checkbox']:checked").each(function () {
        if (value == '') {
            value = $(this).parent().find('label').text();
        } else {
            value = value + "|" + $(this).parent().find('label').text();
        }
    });
    
    $("#Conclusion").val(value);
}


function setTestNotPerformedReasonForAwvEcho(testNotPerformed) {
    setTestNotPerformed("testnotPerformedAwvEcho", testNotPerformed);
    SetTestNotPerformedEnableDisabled("testnotPerformedAwvEcho");
}

function getTestNotPerformedReasonForAwvEcho(testNotPerformed) {
    return getTestNotPerformed("testnotPerformedAwvEcho", testNotPerformed);
}

function setConsistentLvSystolicFailure(element) {
    if (Number($(element).parent().find(".finding-worstcaseorder").val()) >= 3) {
        $("#LeftVentricleOverallFunctionConsistentLvSystolicFailure").attr('checked', true);
    } else {
        $("#LeftVentricleOverallFunctionConsistentLvSystolicFailure").attr('checked', false);
    }
}