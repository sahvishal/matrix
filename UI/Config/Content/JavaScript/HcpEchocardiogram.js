function HcpEchocardiogram(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = {
            'Id': 0, 'UnableScreenReason': null, "Media": new Array(),
            "TestType": testTypeHcpEcho,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": '0',
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "TestPerformedExternally": null,
            "ResultStatus": {
                "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentHcpEchoInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestHcpEchoCheck").attr("checked")
            }
        };
    }
    this.Result = testResult;
}

HcpEchocardiogram.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (IsHcpEchoResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_HcpEchocapturebyChat", testResult.TestPerformedExternally)
        }

        setUnableScreenReason($('.HcpEcho-unabletoscreen-dtl'), testResult.UnableScreenReason);

        setTestNotPerformedReasonForHcpEcho(testResult.TestNotPerformed);

        $("#technotesHcpEcho").val(testResult.TechnicianNotes);
        $("#conductedbyHcpEcho option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);

        $("#DescribeSelfPresentHcpEchoInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);

        if (testResult.Media && testResult.Media.length > 0) {
            LoadNewMediaHcpEcho(testResult.Media, true);
        }
        
        setboolTypeReading($('#HcpEchoValveAorticCheckbox'), testResult.Aortic);
        setboolTypeReading($('#HcpEchoValveMitralCheckbox'), testResult.Mitral);
        setboolTypeReading($('#HcpEchoValvePulmonicCheckbox'), testResult.Pulmonic);
        setboolTypeReading($('#HcpEchoValveTricuspidCheckbox'), testResult.Tricuspid);

        setboolTypeReading($('#technicalltdreadableHcpEchoinputcheck'), testResult.TechnicallyLimitedbutReadable);
        setboolTypeReading($('#repeatstudyunreadableHcpEchoinputcheck'), testResult.RepeatStudyUnreadable);

        setReading($('#HcpEchoAorticVelocityTextbox'), testResult.AoticVelocity);
        setReading($('#HcpEchoPTTextbox'), testResult.MitralPT);
        setReading($('#HcpEchoVelocityPulmonicTextbox'), testResult.PulmonicVelocity);
        setReading($('#HcpEchoVelocityTricuspidTextbox'), testResult.TricuspidVelocity);
        setReading($('#HcpEchoPapTextbox'), testResult.TricuspidPap);


        setboolTypeReading($('#HcpEchoRestrictedLeafletCheckbox'), testResult.RestrictedLeafletMotion);
        setboolTypeReading($('#HcpEchoRestrictedLeafletAorticCheckbox'), testResult.RestrictedLeafletMotionAortic);
        setboolTypeReading($('#HcpEchoRestrictedLeafletMitralCheckbox'), testResult.RestrictedLeafletMotionMitral);
        setboolTypeReading($('#HcpEchoRestrictedLeafletPulCheckbox'), testResult.RestrictedLeafletMotionPulmonic);
        setboolTypeReading($('#HcpEchoRestrictedLeafletTriCheckbox'), testResult.RestrictedLeafletMotionTricuspid);

        setboolTypeReading($('#HcpEchoPericardialEffusionCheckbox'), testResult.PericardialEffusion);
        setboolTypeReading($('#HcpEchoDiastolicDysfunctionCheckbox'), testResult.DiastolicDysfunction);

        setboolTypeReading($('#HcpEchoVentricularEnlargmentCheckbox'), testResult.VentricularEnlargement);
        setReading($('#HcpEchoLeftVEnlargementTextbox'), testResult.LeftVentricularEnlargmentValue);
        setReading($('#HcpEchoRightVEnlargementTextbox'), testResult.RightVentricularEnlargmentValue);
        setboolTypeReading($('#HcpEchoLeftVEnlargementCheckbox'), testResult.LeftVentricularEnlargment);
        setboolTypeReading($('#HcpEchoRightVEnlargementCheckbox'), testResult.RightVentricularEnlargment);

        setboolTypeReading($('#HcpEchoAorticRootCheckbox'), testResult.AorticRoot);
        setboolTypeReading($('#HcpEchoScleroticCheckbox'), testResult.Sclerotic);
        setboolTypeReading($('#HcpEchoCalcifiedCheckbox'), testResult.Calcified);
        setboolTypeReading($('#HcpEchoEnlargedCheckbox'), testResult.Enlarged);
        setReading($('#HcpEchoEnlargedTextbox'), testResult.EnlargedValue);

        setboolTypeReading($('#HcpEchoVentricularHypertrophyCheckbox'), testResult.VentricularHypertrophy);
        setReading($('#HcpEchoLeftVHypertrophyTextbox'), testResult.LeftVHypertrophyValue);
        setReading($('#HcpEchoRightVHypertrophyTextbox'), testResult.RightVHypertrophyValue);
        setReading($('#HcpEchoIvshTextbox'), testResult.IvshHypertrophyValue);

        setboolTypeReading($('#HcpEchoLeftVHypertrophyCheckbox'), testResult.LeftVHypertrophy);
        setboolTypeReading($('#HcpEchoRightVHypertrophyCheckbox'), testResult.RightVHypertrophy);
        setboolTypeReading($('#HcpEchoIvshCheckbox'), testResult.IvshHypertrophy);

        setboolTypeReading($('#HcpEchoAtrialEnlargmentCheckbox'), testResult.AtrialEnlargement);
        setReading($('#HcpEchoLeftAtrialEnlargementTextbox'), testResult.LeftAtrialEnlargmentValue);
        setReading($('#HcpEchoRightAtrialEnlargementTextbox'), testResult.RightAtrialEnlargmentValue);

        setboolTypeReading($('#HcpEchoLeftAtrialEnlargementCheckbox'), testResult.LeftAtrialEnlargment);
        setboolTypeReading($('#HcpEchoRightAtrialEnlargementCheckbox'), testResult.RightAtrialEnlargment);
        setboolTypeReading($('#HcpEchoArrythmiaCheckbox'), testResult.Arrythmia);

        setboolTypeReading($('#HcpEchoAFibCheckbox'), testResult.AFib);
        setboolTypeReading($('#HcpEchoAFlutterCheckbox'), testResult.AFlutter);
        setboolTypeReading($('#HcpEchoPACCheckbox'), testResult.PAC);
        setboolTypeReading($('#HcpEchoPVCCheckbox'), testResult.PVC);

        setboolTypeReading($('#HcpEchoAsdCheckbox'), testResult.ASD);
        setboolTypeReading($('#HcpEchoPfoCheckbox'), testResult.PFO);
        setboolTypeReading($('#HcpEchoVsdCheckbox'), testResult.VSD);
        setboolTypeReading($('#HcpEchoFlailCheckbox'), testResult.FlailAS);
        setboolTypeReading($('#HcpEchoSamCheckbox'), testResult.SAM);
        setboolTypeReading($('#HcpEchoLvotoCheckbox'), testResult.LVOTO);
        setboolTypeReading($('#HcpEchoMitralAnnularCheckbox'), testResult.MitralAnnularCa);

        setboolTypeReading($('#HcpEchoHypokineticCheckbox'), testResult.Hypokinetic);
        setboolTypeReading($('#HcpEchoAkineticCheckbox'), testResult.Akinetic);
        setboolTypeReading($('#HcpEchoDyskineticCheckbox'), testResult.Dyskinetic);
        setboolTypeReading($('#HcpEchoAnteriorCheckbox'), testResult.Anterior);
        setboolTypeReading($('#HcpEchoPosteriorCheckbox'), testResult.Posterior);
        setboolTypeReading($('#HcpEchoApicalCheckbox'), testResult.Apical);
        setboolTypeReading($('#HcpEchoSeptalCheckbox'), testResult.Septal);
        setboolTypeReading($('#HcpEchoLateralCheckbox'), testResult.Lateral);
        setboolTypeReading($('#HcpEchoInferiorCheckbox'), testResult.Inferior);

        setboolTypeReading($('#HcpEchoMorphologyTricuspidHigh35MmHgOrGreaterCheckbox'), testResult.MorphologyTricuspidHighOrGreater);
        setboolTypeReading($('#HcpEchoMorphologyTricuspidNormalCheckbox'), testResult.MorphologyTricuspidNormal);

        if (testResult.Finding != null) {
            setSelectedFindingDatalist($(".HcpEcho-finding"), testResult.Finding.Id);
        }

        if (testResult.EstimatedEjactionFraction != null) {
            setSelectedFindingDatalist($(".HcpEchoejaction-fraction-finding"), testResult.EstimatedEjactionFraction.Id);
        }

        if (testResult.AorticRegurgitation != null) {
            setSelectedFindingDatalist($(".HcpEchoaortic-regurgitation-finding"), testResult.AorticRegurgitation.Id);
        }

        if (testResult.MitralRegurgitation != null) {
            setSelectedFindingDatalist($(".HcpEchomitral-regurgitation-finding"), testResult.MitralRegurgitation.Id);
        }

        if (testResult.PulmonicRegurgitation != null) {
            setSelectedFindingDatalist($(".HcpEchopulmonic-regurgitation-finding"), testResult.PulmonicRegurgitation.Id);
        }

        if (testResult.TricuspidRegurgitation != null) {
            setSelectedFindingDatalist($(".HcpEchotricuspid-regurgitation-finding"), testResult.TricuspidRegurgitation.Id);
        }

        if (testResult.DistolicDysfunctionFinding != null) {
            setSelectedFindingDatalist($(".HcpEchodiastolic-dysfunction-finding"), testResult.DistolicDysfunctionFinding.Id);
        }

        setMultipleFindingDatalist($('.HcpEchoaortic-morphology-finding'), testResult.AorticMorphology);
        setMultipleFindingDatalist($('.HcpEchomitral-morphology-finding'), testResult.MitralMorphology);
        setMultipleFindingDatalist($('.HcpEchopulmonic-morphology-finding'), testResult.PulmonicMorphology);
        setMultipleFindingDatalist($('.HcpEchotricuspid-morphology-finding'), testResult.TricuspidMorphology);
        setMultipleFindingDatalist($('.HcpEchopericardial-effusion-finding'), testResult.PericardialEffusionFinding);

        $("#PriorityInQueueTestHcpEchoCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#hcpEcho-priorityInQueue-span"), "onClick_PriorityInQueueDataHcpEcho();", testTypeHcpEcho);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#hcpEcho-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }

        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#HcpEcho-critical-span"), "onClick_CriticalDataHcpEcho();", testTypeHcpEcho);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#HcpEcho-critical-span").parent().addClass("red-band");
                $("#criticalHcpEcho").attr("checked", "checked");
            }
        }

        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksHcpEcho").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpHcpEcho").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalHcpEcho").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }

        if (currentScreenMode == ScreenMode.Physician) {
            $("#claer-all-HcpEchoregurgitation").show();
        }

    },
    getData: function () {
        var testResult = this.Result;
        if (IsHcpEchoResultEntryExternaly == 'True') {
             testResult.TestPerformedExternally = getTestPerformedExternally("chk_HcpEchocapturebyChat", testResult.TestPerformedExternally)
        }

        if (currentScreenMode != ScreenMode.Entry) {
            testResult.Aortic = getboolTypeReading($('#HcpEchoValveAorticCheckbox'), testResult.Aortic);
            testResult.Mitral = getboolTypeReading($('#HcpEchoValveMitralCheckbox'), testResult.Mitral);
            testResult.Pulmonic = getboolTypeReading($('#HcpEchoValvePulmonicCheckbox'), testResult.Pulmonic);
            testResult.Tricuspid = getboolTypeReading($('#HcpEchoValveTricuspidCheckbox'), testResult.Tricuspid);

            testResult.AoticVelocity = getReading($('#HcpEchoAorticVelocityTextbox'), testResult.AoticVelocity);
            testResult.MitralPT = getReading($('#HcpEchoPTTextbox'), testResult.MitralPT);
            testResult.PulmonicVelocity = getReading($('#HcpEchoVelocityPulmonicTextbox'), testResult.PulmonicVelocity);
            testResult.TricuspidVelocity = getReading($('#HcpEchoVelocityTricuspidTextbox'), testResult.TricuspidVelocity);
            testResult.TricuspidPap = getReading($('#HcpEchoPapTextbox'), testResult.TricuspidPap);

            testResult.PericardialEffusion = getboolTypeReading($('#HcpEchoPericardialEffusionCheckbox'), testResult.PericardialEffusion);
            testResult.DiastolicDysfunction = getboolTypeReading($('#HcpEchoDiastolicDysfunctionCheckbox'), testResult.DiastolicDysfunction);

            testResult.VentricularEnlargement = getboolTypeReading($('#HcpEchoVentricularEnlargmentCheckbox'), testResult.VentricularEnlargement);
            testResult.LeftVentricularEnlargmentValue = getReading($('#HcpEchoLeftVEnlargementTextbox'), testResult.LeftVentricularEnlargmentValue);
            testResult.RightVentricularEnlargmentValue = getReading($('#HcpEchoRightVEnlargementTextbox'), testResult.RightVentricularEnlargmentValue);
            testResult.LeftVentricularEnlargment = getboolTypeReading($('#HcpEchoLeftVEnlargementCheckbox'), testResult.LeftVentricularEnlargment);
            testResult.RightVentricularEnlargment = getboolTypeReading($('#HcpEchoRightVEnlargementCheckbox'), testResult.RightVentricularEnlargment);

            testResult.AorticRoot = getboolTypeReading($('#HcpEchoAorticRootCheckbox'), testResult.AorticRoot);
            testResult.Sclerotic = getboolTypeReading($('#HcpEchoScleroticCheckbox'), testResult.Sclerotic);
            testResult.Calcified = getboolTypeReading($('#HcpEchoCalcifiedCheckbox'), testResult.Calcified);
            testResult.Enlarged = getboolTypeReading($('#HcpEchoEnlargedCheckbox'), testResult.Enlarged);
            testResult.EnlargedValue = getReading($('#HcpEchoEnlargedTextbox'), testResult.EnlargedValue);


            testResult.RestrictedLeafletMotion = getboolTypeReading($('#HcpEchoRestrictedLeafletCheckbox'), testResult.RestrictedLeafletMotion);
            testResult.RestrictedLeafletMotionAortic = getboolTypeReading($('#HcpEchoRestrictedLeafletAorticCheckbox'), testResult.RestrictedLeafletMotionAortic);
            testResult.RestrictedLeafletMotionMitral = getboolTypeReading($('#HcpEchoRestrictedLeafletMitralCheckbox'), testResult.RestrictedLeafletMotionMitral);
            testResult.RestrictedLeafletMotionPulmonic = getboolTypeReading($('#HcpEchoRestrictedLeafletPulCheckbox'), testResult.RestrictedLeafletMotionPulmonic);
            testResult.RestrictedLeafletMotionTricuspid = getboolTypeReading($('#HcpEchoRestrictedLeafletTriCheckbox'), testResult.RestrictedLeafletMotionTricuspid);


            testResult.VentricularHypertrophy = getboolTypeReading($('#HcpEchoVentricularHypertrophyCheckbox'), testResult.VentricularHypertrophy);
            testResult.LeftVHypertrophyValue = getReading($('#HcpEchoLeftVHypertrophyTextbox'), testResult.LeftVHypertrophyValue);
            testResult.RightVHypertrophyValue = getReading($('#HcpEchoRightVHypertrophyTextbox'), testResult.RightVHypertrophyValue);
            testResult.IvshHypertrophyValue = getReading($('#HcpEchoIvshTextbox'), testResult.IvshHypertrophyValue);

            testResult.LeftVHypertrophy = getboolTypeReading($('#HcpEchoLeftVHypertrophyCheckbox'), testResult.LeftVHypertrophy);
            testResult.RightVHypertrophy = getboolTypeReading($('#HcpEchoRightVHypertrophyCheckbox'), testResult.RightVHypertrophy);
            testResult.IvshHypertrophy = getboolTypeReading($('#HcpEchoIvshCheckbox'), testResult.IvshHypertrophy);

            testResult.AtrialEnlargement = getboolTypeReading($('#HcpEchoAtrialEnlargmentCheckbox'), testResult.AtrialEnlargement);
            testResult.LeftAtrialEnlargmentValue = getReading($('#HcpEchoLeftAtrialEnlargementTextbox'), testResult.LeftAtrialEnlargmentValue);
            testResult.RightAtrialEnlargmentValue = getReading($('#HcpEchoRightAtrialEnlargementTextbox'), testResult.RightAtrialEnlargmentValue);

            testResult.LeftAtrialEnlargment = getboolTypeReading($('#HcpEchoLeftAtrialEnlargementCheckbox'), testResult.LeftAtrialEnlargment);
            testResult.RightAtrialEnlargment = getboolTypeReading($('#HcpEchoRightAtrialEnlargementCheckbox'), testResult.RightAtrialEnlargment);
            testResult.Arrythmia = getboolTypeReading($('#HcpEchoArrythmiaCheckbox'), testResult.Arrythmia);

            testResult.AFib = getboolTypeReading($('#HcpEchoAFibCheckbox'), testResult.AFib);
            testResult.AFlutter = getboolTypeReading($('#HcpEchoAFlutterCheckbox'), testResult.AFlutter);
            testResult.PAC = getboolTypeReading($('#HcpEchoPACCheckbox'), testResult.PAC);
            testResult.PVC = getboolTypeReading($('#HcpEchoPVCCheckbox'), testResult.PVC);

            testResult.ASD = getboolTypeReading($('#HcpEchoAsdCheckbox'), testResult.ASD);
            testResult.PFO = getboolTypeReading($('#HcpEchoPfoCheckbox'), testResult.PFO);
            testResult.VSD = getboolTypeReading($('#HcpEchoVsdCheckbox'), testResult.VSD);
            testResult.FlailAS = getboolTypeReading($('#HcpEchoFlailCheckbox'), testResult.FlailAS);
            testResult.SAM = getboolTypeReading($('#HcpEchoSamCheckbox'), testResult.SAM);
            testResult.LVOTO = getboolTypeReading($('#HcpEchoLvotoCheckbox'), testResult.LVOTO);
            testResult.MitralAnnularCa = getboolTypeReading($('#HcpEchoMitralAnnularCheckbox'), testResult.MitralAnnularCa);

            testResult.Hypokinetic = getboolTypeReading($('#HcpEchoHypokineticCheckbox'), testResult.Hypokinetic);
            testResult.Akinetic = getboolTypeReading($('#HcpEchoAkineticCheckbox'), testResult.Akinetic);
            testResult.Dyskinetic = getboolTypeReading($('#HcpEchoDyskineticCheckbox'), testResult.Dyskinetic);
            testResult.Anterior = getboolTypeReading($('#HcpEchoAnteriorCheckbox'), testResult.Anterior);
            testResult.Posterior = getboolTypeReading($('#HcpEchoPosteriorCheckbox'), testResult.Posterior);
            testResult.Apical = getboolTypeReading($('#HcpEchoApicalCheckbox'), testResult.Apical);
            testResult.Septal = getboolTypeReading($('#HcpEchoSeptalCheckbox'), testResult.Septal);
            testResult.Lateral = getboolTypeReading($('#HcpEchoLateralCheckbox'), testResult.Lateral);
            testResult.Inferior = getboolTypeReading($('#HcpEchoInferiorCheckbox'), testResult.Inferior);

            testResult.Finding = getFindingDataandSynchronized(testResult.Finding, getSelectedFindingDatalist($(".HcpEcho-finding")));
            testResult.EstimatedEjactionFraction = getFindingDataandSynchronized(testResult.EstimatedEjactionFraction, getSelectedFindingDatalist($(".HcpEchoejaction-fraction-finding")));
            testResult.AorticRegurgitation = getFindingDataandSynchronized(testResult.AorticRegurgitation, getSelectedFindingDatalist($(".HcpEchoaortic-regurgitation-finding")));
            testResult.MitralRegurgitation = getFindingDataandSynchronized(testResult.MitralRegurgitation, getSelectedFindingDatalist($(".HcpEchomitral-regurgitation-finding")));
            testResult.PulmonicRegurgitation = getFindingDataandSynchronized(testResult.PulmonicRegurgitation, getSelectedFindingDatalist($(".HcpEchopulmonic-regurgitation-finding")));
            testResult.TricuspidRegurgitation = getFindingDataandSynchronized(testResult.TricuspidRegurgitation, getSelectedFindingDatalist($(".HcpEchotricuspid-regurgitation-finding")));

            testResult.DistolicDysfunctionFinding = getFindingDataandSynchronized(testResult.DistolicDysfunctionFinding, getSelectedFindingDatalist($(".HcpEchodiastolic-dysfunction-finding")));

            testResult.AorticMorphology = getMultipleFindingDataandSynchronized(testResult.AorticMorphology, getMultipleFindingDatalist($('.HcpEchoaortic-morphology-finding')));
            testResult.MitralMorphology = getMultipleFindingDataandSynchronized(testResult.MitralMorphology, getMultipleFindingDatalist($('.HcpEchomitral-morphology-finding')));
            testResult.TricuspidMorphology = getMultipleFindingDataandSynchronized(testResult.TricuspidMorphology, getMultipleFindingDatalist($('.HcpEchotricuspid-morphology-finding')));
            testResult.PulmonicMorphology = getMultipleFindingDataandSynchronized(testResult.PulmonicMorphology, getMultipleFindingDatalist($('.HcpEchopulmonic-morphology-finding')));

            testResult.PericardialEffusionFinding = getMultipleFindingDataandSynchronized(testResult.PericardialEffusionFinding, getMultipleFindingDatalist($('.HcpEchopericardial-effusion-finding')));

            testResult.TechnicallyLimitedbutReadable = getboolTypeReading($('#technicalltdreadableHcpEchoinputcheck'), testResult.TechnicallyLimitedbutReadable);
            testResult.RepeatStudyUnreadable = getboolTypeReading($('#repeatstudyunreadableHcpEchoinputcheck'), testResult.RepeatStudyUnreadable);

            testResult.MorphologyTricuspidHighOrGreater = getboolTypeReading($('#HcpEchoMorphologyTricuspidHigh35MmHgOrGreaterCheckbox'), testResult.MorphologyTricuspidHighOrGreater);
            testResult.MorphologyTricuspidNormal = getboolTypeReading($('#HcpEchoMorphologyTricuspidNormalCheckbox'), testResult.MorphologyTricuspidNormal);

            if (testResult.PhysicianInterpretation == null)
                testResult.PhysicianInterpretation = {
                    'Remarks': $("#physicianRemarksHcpEcho").val(), 'IsCritical': $("#criticalHcpEcho").attr("checked"), 'FollowUp': $("#followUpHcpEcho").attr("checked"), 'RecorderMetaData': {
                        'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate
                    }
                };
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksHcpEcho").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpHcpEcho").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalHcpEcho").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.HcpEcho-unabletoscreen-dtl')));

        testResult.TestNotPerformed = getTestNotPerformedReasonForHcpEcho(testResult.TestNotPerformed);

        if (currentScreenMode != ScreenMode.Physician) {
            var resultMedia = new Array();
            if (HcpEchoResultMedia != null) {
                $.each(HcpEchoResultMedia, function () { resultMedia.push(this); });
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
            testResult.TechnicianNotes = $.trim($("#technotesHcpEcho").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ConductedByOrgRoleUserId = $("#conductedbyHcpEcho option:selected").val();
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentHcpEchoInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestHcpEchoCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_47").attr("checked");

        if (testResult.ResultStatus.StateNumber < 4 && testResult.TechnicianNotes.length < 1 && testResult.ConductedByOrgRoleUserId == "0" && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.length < 1)
            && $("#DescribeSelfPresentHcpEchoInputCheck").attr("checked") == false && HcpEchoImageCount < 1)
            testResult = null;

        return testResult;
    }
}


var HcpEchoImageCount = 0;
var HcpEchoResultMedia = null;

function getHcpEchoMedia() {
    return HcpEchoResultMedia;
}

function LoadNewMediaHcpEcho(jsonMedia, correctJson) {
    HcpEchoResultMedia = jsonMedia;
    HcpEchoImageCount = 0;
    $("#HcpEchoMediaDiv").empty();
    if (jsonMedia == null || jsonMedia.length < 1) return;
    HcpEchoImageCount = jsonMedia.length;
    LoadNewMedia(jsonMedia, correctJson, $("#HcpEchoMediaDiv"));
}

var criticalDataModel_HcpEcho = null;
function onClick_CriticalDataHcpEcho() {
    if ($("#DescribeSelfPresentHcpEchoInputCheck").attr("checked")) {
        loadCriticalLink($("#HcpEcho-critical-span"), "onClick_CriticalDataHcpEcho();", testTypeHcpEcho);
        openCriticalDataDialog(testTypeHcpEcho, $("#conductedbyHcpEcho"), $("#DescribeSelfPresentHcpEchoInputCheck"), setCriticalDataModel_HcpEcho);
    }
    else {
        unloadCriticalLink($("#HcpEcho-critical-span"), testTypeHcpEcho);
    }
}

function setCriticalDataModel_HcpEcho(model, printAfterSave) {
    if (model != null) {
        var testResult = GetHcpEchoData();
        saveSingleTestResult(testResult, model, $("#HcpEcho-critical-span"), "onClick_CriticalDataHcpEcho();", SetHcpEchoData, printAfterSave);
    }
}

function getCriticalDataModel_HcpEcho() {
    if ($("#DescribeSelfPresentHcpEchoInputCheck").attr("checked") && criticalDataModel_HcpEcho != null) {
        criticalDataModel_HcpEcho.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_HcpEcho;
    }
    return null;
}

function onClick_PriorityInQueueDataHcpEcho() {
    if ($("#PriorityInQueueTestHcpEchoCheck").attr("checked")) {
        loadPriorityInQueueLink($("#hcpEcho-priorityInQueue-span"), "onClick_PriorityInQueueDataHcpEcho();", testTypeHcpEcho);
        openPriorityInQueueTestDialog(testTypeHcpEcho, $("#conductedbyHcpEcho"), $("#PriorityInQueueTestHcpEchoCheck"), setPriorityInQueueDataModel_HcpEcho);
    }
    else {
        unloadPriorityInQueueLink($("#hcpEcho-priorityInQueue-span"), testTypeHcpEcho);
    }
}

function setPriorityInQueueDataModel_HcpEcho(model) {
    if (model != null) {
        var testResult = GetHcpEchoData();
        model.TestId = testTypeHcpEcho;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#hcpEcho-priorityInQueue-span"), "onClick_PriorityInQueueDataHcpEcho();", SetHcpEchoData);
    }
}

function clearAllHcpEchoRegurgitationSelection() {
    //debugger;
    $(".HcpEchoaortic-regurgitation-finding,.HcpEchomitral-regurgitation-finding,.HcpEchopulmonic-regurgitation-finding,.HcpEchotricuspid-regurgitation-finding").find("input[type=radio]").attr("checked", false);
}

function clearAllHcpEchoSelection() {
    $(".clear-all-HcpEcho-selection input[type=radio], .clear-all-HcpEcho-selection input[type=checkbox]").attr("checked", false);

}



function setTestNotPerformedReasonForHcpEcho(testNotPerformed) {
    setTestNotPerformed("testnotPerformedHcpEcho", testNotPerformed);
    SetTestNotPerformedEnableDisabled("testnotPerformedHcpEcho");
}

function getTestNotPerformedReasonForHcpEcho(testNotPerformed) {
    return getTestNotPerformed("testnotPerformedHcpEcho", testNotPerformed);
}