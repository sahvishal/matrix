function Echocardiogram(testResult) {
    if (testResult == null || testResult == undefined) {
        testResult = { 'Id': 0, 'UnableScreenReason': null, "Media": new Array(),
            "TestType": testTypeEcho,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": '0',
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "TestPerformedExternally": null,
             
            "ResultStatus": { "Id": 0,
                "SelfPresent": $("#DescribeSelfPresentEchoInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestEchoCheck").attr("checked")
            }
        };
    }
    this.Result = testResult;
}

Echocardiogram.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (IsechoResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_echocapturebyChat", testResult.TestPerformedExternally)
        }

        setUnableScreenReason($('.echo-unabletoscreen-dtl'), testResult.UnableScreenReason);

        $("#technotesecho").val(testResult.TechnicianNotes);
        $("#conductedbyecho option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);

        $("#DescribeSelfPresentEchoInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);

        if (testResult.Media && testResult.Media.length > 0) {
            LoadNewMediaEcho(testResult.Media, true);
        }

        setboolTypeReading($('#ValveAorticCheckbox'), testResult.Aortic);
        setboolTypeReading($('#ValveMitralCheckbox'), testResult.Mitral);
        setboolTypeReading($('#ValvePulmonicCheckbox'), testResult.Pulmonic);
        setboolTypeReading($('#ValveTricuspidCheckbox'), testResult.Tricuspid);

        setboolTypeReading($('#technicalltdreadableinputcheck'), testResult.TechnicallyLimitedbutReadable);
        setboolTypeReading($('#repeatstudyunreadableinputcheck'), testResult.RepeatStudyUnreadable);

        setboolTypeReading($('#EchoConsiderOtherModalities'), testResult.ConsiderOtherModalities);
        setboolTypeReading($('#EchoAdditionalImagesNeeded'), testResult.AdditionalImagesNeeded);

        setReading($('#AorticVelocityTextbox'), testResult.AoticVelocity);
        setReading($('#PTTextbox'), testResult.MitralPT);
        setReading($('#VelocityPulmonicTextbox'), testResult.PulmonicVelocity);
        setReading($('#VelocityTricuspidTextbox'), testResult.TricuspidVelocity);
        setReading($('#PapTextbox'), testResult.TricuspidPap);


        setboolTypeReading($('#RestrictedLeafletCheckbox'), testResult.RestrictedLeafletMotion);
        setboolTypeReading($('#RestrictedLeafletAorticCheckbox'), testResult.RestrictedLeafletMotionAortic);
        setboolTypeReading($('#RestrictedLeafletMitralCheckbox'), testResult.RestrictedLeafletMotionMitral);
        setboolTypeReading($('#RestrictedLeafletPulCheckbox'), testResult.RestrictedLeafletMotionPulmonic);
        setboolTypeReading($('#RestrictedLeafletTriCheckbox'), testResult.RestrictedLeafletMotionTricuspid);

        setboolTypeReading($('#PericardialEffusionCheckbox'), testResult.PericardialEffusion);
        setboolTypeReading($('#DiastolicDysfunctionCheckbox'), testResult.DiastolicDysfunction);

        setboolTypeReading($('#VentricularEnlargmentCheckbox'), testResult.VentricularEnlargement);
        setReading($('#LeftVEnlargementTextbox'), testResult.LeftVentricularEnlargmentValue);
        setReading($('#RightVEnlargementTextbox'), testResult.RightVentricularEnlargmentValue);
        setboolTypeReading($('#LeftVEnlargementCheckbox'), testResult.LeftVentricularEnlargment);
        setboolTypeReading($('#RightVEnlargementCheckbox'), testResult.RightVentricularEnlargment);

        setboolTypeReading($('#AorticRootCheckbox'), testResult.AorticRoot);
        setboolTypeReading($('#ScleroticCheckbox'), testResult.Sclerotic);
        setboolTypeReading($('#CalcifiedCheckbox'), testResult.Calcified);
        setboolTypeReading($('#EnlargedCheckbox'), testResult.Enlarged);
        setReading($('#EnlargedTextbox'), testResult.EnlargedValue);

        setboolTypeReading($('#VentricularHypertrophyCheckbox'), testResult.VentricularHypertrophy);
        setReading($('#LeftVHypertrophyTextbox'), testResult.LeftVHypertrophyValue);
        setReading($('#RightVHypertrophyTextbox'), testResult.RightVHypertrophyValue);
        setReading($('#IvshTextbox'), testResult.IvshHypertrophyValue);

        setboolTypeReading($('#LeftVHypertrophyCheckbox'), testResult.LeftVHypertrophy);
        setboolTypeReading($('#RightVHypertrophyCheckbox'), testResult.RightVHypertrophy);
        setboolTypeReading($('#IvshCheckbox'), testResult.IvshHypertrophy);

        setboolTypeReading($('#AtrialEnlargmentCheckbox'), testResult.AtrialEnlargement);
        setReading($('#LeftAtrialEnlargementTextbox'), testResult.LeftAtrialEnlargmentValue);
        setReading($('#RightAtrialEnlargementTextbox'), testResult.RightAtrialEnlargmentValue);

        setboolTypeReading($('#LeftAtrialEnlargementCheckbox'), testResult.LeftAtrialEnlargment);
        setboolTypeReading($('#RightAtrialEnlargementCheckbox'), testResult.RightAtrialEnlargment);
        setboolTypeReading($('#ArrythmiaCheckbox'), testResult.Arrythmia);

        setboolTypeReading($('#AsdCheckbox'), testResult.ASD);
        setboolTypeReading($('#PfoCheckbox'), testResult.PFO);
        setboolTypeReading($('#VsdCheckbox'), testResult.VSD);
        setboolTypeReading($('#FlailCheckbox'), testResult.FlailAS);
        setboolTypeReading($('#SamCheckbox'), testResult.SAM);
        setboolTypeReading($('#LvotoCheckbox'), testResult.LVOTO);
        setboolTypeReading($('#MitralAnnularCheckbox'), testResult.MitralAnnularCa);

        setboolTypeReading($('#HypokineticCheckbox'), testResult.Hypokinetic);
        setboolTypeReading($('#AkineticCheckbox'), testResult.Akinetic);
        setboolTypeReading($('#DyskineticCheckbox'), testResult.Dyskinetic);
        setboolTypeReading($('#AnteriorCheckbox'), testResult.Anterior);
        setboolTypeReading($('#PosteriorCheckbox'), testResult.Posterior);
        setboolTypeReading($('#ApicalCheckbox'), testResult.Apical);
        setboolTypeReading($('#SeptalCheckbox'), testResult.Septal);
        setboolTypeReading($('#LateralCheckbox'), testResult.Lateral);
        setboolTypeReading($('#InferiorCheckbox'), testResult.Inferior);

        if (testResult.Finding != null) {
            setSelectedFindingDatalist($(".echo-finding"), testResult.Finding.Id);
        }

        if (testResult.EstimatedEjactionFraction != null) {
            setSelectedFindingDatalist($(".ejaction-fraction-finding"), testResult.EstimatedEjactionFraction.Id);
        }

        if (testResult.AorticRegurgitation != null) {
            setSelectedFindingDatalist($(".aortic-regurgitation-finding"), testResult.AorticRegurgitation.Id);
        }

        if (testResult.MitralRegurgitation != null) {
            setSelectedFindingDatalist($(".mitral-regurgitation-finding"), testResult.MitralRegurgitation.Id);
        }

        if (testResult.PulmonicRegurgitation != null) {
            setSelectedFindingDatalist($(".pulmonic-regurgitation-finding"), testResult.PulmonicRegurgitation.Id);
        }

        if (testResult.TricuspidRegurgitation != null) {
            setSelectedFindingDatalist($(".tricuspid-regurgitation-finding"), testResult.TricuspidRegurgitation.Id);
        }

        setMultipleFindingDatalist($('.aortic-morphology-finding'), testResult.AorticMorphology);
        setMultipleFindingDatalist($('.mitral-morphology-finding'), testResult.MitralMorphology);
        setMultipleFindingDatalist($('.pulmonic-morphology-finding'), testResult.PulmonicMorphology);
        setMultipleFindingDatalist($('.tricuspid-morphology-finding'), testResult.TricuspidMorphology);
        setMultipleFindingDatalist($('.pericardial-effusion-finding'), testResult.PericardialEffusionFinding);
        setMultipleFindingDatalist($('.diastolic-dysfunction-finding'), testResult.DistolicDysfunctionFinding);

        $("#PriorityInQueueTestEchoCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#echo-priorityInQueue-span"), "onClick_PriorityInQueueDataEcho();", testTypeEcho);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#echo-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#echo-critical-span"), "onClick_CriticalDataEcho();", testTypeEcho);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#echo-critical-span").parent().addClass("red-band");
                $("#criticalEcho").attr("checked", "checked");
            }
        }

        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksEcho").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpEcho").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalEcho").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }
        
        if (currentScreenMode == ScreenMode.Physician) {
            $("#claer-all-regurgitation").show();
        }
    },
    getData: function () {
        var testResult = this.Result;

        if (IsechoResultEntryExternaly == 'True') {
             testResult.TestPerformedExternally = getTestPerformedExternally("chk_echocapturebyChat", testResult.TestPerformedExternally)
        }

        if (currentScreenMode != ScreenMode.Entry) {
            testResult.Aortic = getboolTypeReading($('#ValveAorticCheckbox'), testResult.Aortic);
            testResult.Mitral = getboolTypeReading($('#ValveMitralCheckbox'), testResult.Mitral);
            testResult.Pulmonic = getboolTypeReading($('#ValvePulmonicCheckbox'), testResult.Pulmonic);
            testResult.Tricuspid = getboolTypeReading($('#ValveTricuspidCheckbox'), testResult.Tricuspid);

            testResult.AoticVelocity = getReading($('#AorticVelocityTextbox'), testResult.AoticVelocity);
            testResult.MitralPT = getReading($('#PTTextbox'), testResult.MitralPT);
            testResult.PulmonicVelocity = getReading($('#VelocityPulmonicTextbox'), testResult.PulmonicVelocity);
            testResult.TricuspidVelocity = getReading($('#VelocityTricuspidTextbox'), testResult.TricuspidVelocity);
            testResult.TricuspidPap = getReading($('#PapTextbox'), testResult.TricuspidPap);

            testResult.PericardialEffusion = getboolTypeReading($('#PericardialEffusionCheckbox'), testResult.PericardialEffusion);
            testResult.DiastolicDysfunction = getboolTypeReading($('#DiastolicDysfunctionCheckbox'), testResult.DiastolicDysfunction);

            testResult.VentricularEnlargement = getboolTypeReading($('#VentricularEnlargmentCheckbox'), testResult.VentricularEnlargement);
            testResult.LeftVentricularEnlargmentValue = getReading($('#LeftVEnlargementTextbox'), testResult.LeftVentricularEnlargmentValue);
            testResult.RightVentricularEnlargmentValue = getReading($('#RightVEnlargementTextbox'), testResult.RightVentricularEnlargmentValue);
            testResult.LeftVentricularEnlargment = getboolTypeReading($('#LeftVEnlargementCheckbox'), testResult.LeftVentricularEnlargment);
            testResult.RightVentricularEnlargment = getboolTypeReading($('#RightVEnlargementCheckbox'), testResult.RightVentricularEnlargment);

            testResult.AorticRoot = getboolTypeReading($('#AorticRootCheckbox'), testResult.AorticRoot);
            testResult.Sclerotic = getboolTypeReading($('#ScleroticCheckbox'), testResult.Sclerotic);
            testResult.Calcified = getboolTypeReading($('#CalcifiedCheckbox'), testResult.Calcified);
            testResult.Enlarged = getboolTypeReading($('#EnlargedCheckbox'), testResult.Enlarged);
            testResult.EnlargedValue = getReading($('#EnlargedTextbox'), testResult.EnlargedValue);


            testResult.RestrictedLeafletMotion = getboolTypeReading($('#RestrictedLeafletCheckbox'), testResult.RestrictedLeafletMotion);
            testResult.RestrictedLeafletMotionAortic = getboolTypeReading($('#RestrictedLeafletAorticCheckbox'), testResult.RestrictedLeafletMotionAortic);
            testResult.RestrictedLeafletMotionMitral = getboolTypeReading($('#RestrictedLeafletMitralCheckbox'), testResult.RestrictedLeafletMotionMitral);
            testResult.RestrictedLeafletMotionPulmonic = getboolTypeReading($('#RestrictedLeafletPulCheckbox'), testResult.RestrictedLeafletMotionPulmonic);
            testResult.RestrictedLeafletMotionTricuspid = getboolTypeReading($('#RestrictedLeafletTriCheckbox'), testResult.RestrictedLeafletMotionTricuspid);


            testResult.VentricularHypertrophy = getboolTypeReading($('#VentricularHypertrophyCheckbox'), testResult.VentricularHypertrophy);
            testResult.LeftVHypertrophyValue = getReading($('#LeftVHypertrophyTextbox'), testResult.LeftVHypertrophyValue);
            testResult.RightVHypertrophyValue = getReading($('#RightVHypertrophyTextbox'), testResult.RightVHypertrophyValue);
            testResult.IvshHypertrophyValue = getReading($('#IvshTextbox'), testResult.IvshHypertrophyValue);

            testResult.LeftVHypertrophy = getboolTypeReading($('#LeftVHypertrophyCheckbox'), testResult.LeftVHypertrophy);
            testResult.RightVHypertrophy = getboolTypeReading($('#RightVHypertrophyCheckbox'), testResult.RightVHypertrophy);
            testResult.IvshHypertrophy = getboolTypeReading($('#IvshCheckbox'), testResult.IvshHypertrophy);

            testResult.AtrialEnlargement = getboolTypeReading($('#AtrialEnlargmentCheckbox'), testResult.AtrialEnlargement);
            testResult.LeftAtrialEnlargmentValue = getReading($('#LeftAtrialEnlargementTextbox'), testResult.LeftAtrialEnlargmentValue);
            testResult.RightAtrialEnlargmentValue = getReading($('#RightAtrialEnlargementTextbox'), testResult.RightAtrialEnlargmentValue);

            testResult.LeftAtrialEnlargment = getboolTypeReading($('#LeftAtrialEnlargementCheckbox'), testResult.LeftAtrialEnlargment);
            testResult.RightAtrialEnlargment = getboolTypeReading($('#RightAtrialEnlargementCheckbox'), testResult.RightAtrialEnlargment);
            testResult.Arrythmia = getboolTypeReading($('#ArrythmiaCheckbox'), testResult.Arrythmia);

            testResult.ASD = getboolTypeReading($('#AsdCheckbox'), testResult.ASD);
            testResult.PFO = getboolTypeReading($('#PfoCheckbox'), testResult.PFO);
            testResult.VSD = getboolTypeReading($('#VsdCheckbox'), testResult.VSD);
            testResult.FlailAS = getboolTypeReading($('#FlailCheckbox'), testResult.FlailAS);
            testResult.SAM = getboolTypeReading($('#SamCheckbox'), testResult.SAM);
            testResult.LVOTO = getboolTypeReading($('#LvotoCheckbox'), testResult.LVOTO);
            testResult.MitralAnnularCa = getboolTypeReading($('#MitralAnnularCheckbox'), testResult.MitralAnnularCa);

            testResult.Hypokinetic = getboolTypeReading($('#HypokineticCheckbox'), testResult.Hypokinetic);
            testResult.Akinetic = getboolTypeReading($('#AkineticCheckbox'), testResult.Akinetic);
            testResult.Dyskinetic = getboolTypeReading($('#DyskineticCheckbox'), testResult.Dyskinetic);
            testResult.Anterior = getboolTypeReading($('#AnteriorCheckbox'), testResult.Anterior);
            testResult.Posterior = getboolTypeReading($('#PosteriorCheckbox'), testResult.Posterior);
            testResult.Apical = getboolTypeReading($('#ApicalCheckbox'), testResult.Apical);
            testResult.Septal = getboolTypeReading($('#SeptalCheckbox'), testResult.Septal);
            testResult.Lateral = getboolTypeReading($('#LateralCheckbox'), testResult.Lateral);
            testResult.Inferior = getboolTypeReading($('#InferiorCheckbox'), testResult.Inferior);

            testResult.Finding = getFindingDataandSynchronized(testResult.Finding, getSelectedFindingDatalist($(".echo-finding")));
            testResult.EstimatedEjactionFraction = getFindingDataandSynchronized(testResult.EstimatedEjactionFraction, getSelectedFindingDatalist($(".ejaction-fraction-finding")));
            testResult.AorticRegurgitation = getFindingDataandSynchronized(testResult.AorticRegurgitation, getSelectedFindingDatalist($(".aortic-regurgitation-finding")));
            testResult.MitralRegurgitation = getFindingDataandSynchronized(testResult.MitralRegurgitation, getSelectedFindingDatalist($(".mitral-regurgitation-finding")));
            testResult.PulmonicRegurgitation = getFindingDataandSynchronized(testResult.PulmonicRegurgitation, getSelectedFindingDatalist($(".pulmonic-regurgitation-finding")));
            testResult.TricuspidRegurgitation = getFindingDataandSynchronized(testResult.TricuspidRegurgitation, getSelectedFindingDatalist($(".tricuspid-regurgitation-finding")));

            testResult.AorticMorphology = getMultipleFindingDataandSynchronized(testResult.AorticMorphology, getMultipleFindingDatalist($('.aortic-morphology-finding')));
            testResult.MitralMorphology = getMultipleFindingDataandSynchronized(testResult.MitralMorphology, getMultipleFindingDatalist($('.mitral-morphology-finding')));
            testResult.TricuspidMorphology = getMultipleFindingDataandSynchronized(testResult.TricuspidMorphology, getMultipleFindingDatalist($('.tricuspid-morphology-finding')));
            testResult.PulmonicMorphology = getMultipleFindingDataandSynchronized(testResult.PulmonicMorphology, getMultipleFindingDatalist($('.pulmonic-morphology-finding')));

            testResult.PericardialEffusionFinding = getMultipleFindingDataandSynchronized(testResult.PericardialEffusionFinding, getMultipleFindingDatalist($('.pericardial-effusion-finding')));
            testResult.DistolicDysfunctionFinding = getMultipleFindingDataandSynchronized(testResult.DistolicDysfunctionFinding, getMultipleFindingDatalist($('.diastolic-dysfunction-finding')));

            testResult.TechnicallyLimitedbutReadable = getboolTypeReading($('#technicalltdreadableinputcheck'), testResult.TechnicallyLimitedbutReadable);
            testResult.RepeatStudyUnreadable = getboolTypeReading($('#repeatstudyunreadableinputcheck'), testResult.RepeatStudyUnreadable);

            testResult.ConsiderOtherModalities = getboolTypeReading($('#EchoConsiderOtherModalities'), testResult.ConsiderOtherModalities);
            testResult.AdditionalImagesNeeded = getboolTypeReading($('#EchoAdditionalImagesNeeded'), testResult.AdditionalImagesNeeded);
            
            if (testResult.PhysicianInterpretation == null)
                testResult.PhysicianInterpretation = { 'Remarks': $("#physicianRemarksEcho").val(), 'IsCritical': $("#criticalEcho").attr("checked"), 'FollowUp': $("#followUpEcho").attr("checked"), 'RecorderMetaData': {
                    'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate
                }
                };
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksEcho").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpEcho").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalEcho").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.echo-unabletoscreen-dtl')));

        if (currentScreenMode != ScreenMode.Physician) {
            var resultMedia = new Array();
            if (echoResultMedia != null) {
                $.each(echoResultMedia, function () { resultMedia.push(this); });
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
            testResult.TechnicianNotes = $.trim($("#technotesecho").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ConductedByOrgRoleUserId = $("#conductedbyecho option:selected").val();
            testResult.ResultStatus.SelfPresent = $("#DescribeSelfPresentEchoInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestEchoCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_4").attr("checked");

        if (testResult.ResultStatus.StateNumber < 4 && testResult.TechnicianNotes.length < 1 && testResult.ConductedByOrgRoleUserId == "0" && (testResult.UnableScreenReason == null || testResult.UnableScreenReason.length < 1)
            && $("#DescribeSelfPresentEchoInputCheck").attr("checked") == false && EchoImageCount < 1)
            testResult = null;

        return testResult;
    }
}


var EchoImageCount = 0;
var echoResultMedia = null;

function getEchoMedia() {
    return echoResultMedia;
}

function LoadNewMediaEcho(jsonMedia, correctJson) {
    echoResultMedia = jsonMedia;
    EchoImageCount = 0;
    $("#EchoMediaDiv").empty();
    if (jsonMedia == null || jsonMedia.length < 1) return;
    EchoImageCount = jsonMedia.length;
    LoadNewMedia(jsonMedia, correctJson, $("#EchoMediaDiv"));
}

var criticalDataModel_Echo = null;
function onClick_CriticalDataEcho() {
    if ($("#DescribeSelfPresentEchoInputCheck").attr("checked")) {
        loadCriticalLink($("#echo-critical-span"), "onClick_CriticalDataEcho();", testTypeEcho);
        openCriticalDataDialog(testTypeEcho, $("#conductedbyecho"), $("#DescribeSelfPresentEchoInputCheck"), setCriticalDataModel_Echo);
    }
    else {
        unloadCriticalLink($("#echo-critical-span"), testTypeEcho);
    }
}

function setCriticalDataModel_Echo(model, printAfterSave) {
    if (model != null) {
        var testResult = GetEchoData();
        saveSingleTestResult(testResult, model, $("#echo-critical-span"), "onClick_CriticalDataEcho();", SetEchoData, printAfterSave);
    }
}

function getCriticalDataModel_Echo() {
    if ($("#DescribeSelfPresentEchoInputCheck").attr("checked") && criticalDataModel_Echo != null) {
        criticalDataModel_Echo.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_Echo;
    }
    return null;
}
function onClick_PriorityInQueueDataEcho() {
    if ($("#PriorityInQueueTestEchoCheck").attr("checked")) {
        loadPriorityInQueueLink($("#echo-priorityInQueue-span"), "onClick_PriorityInQueueDataEcho();", testTypeEcho);
        openPriorityInQueueTestDialog(testTypeEcho, $("#conductedbyecho"), $("#PriorityInQueueTestEchoCheck"), setPriorityInQueueDataModel_Echo);
    }
    else {
        unloadPriorityInQueueLink($("#echo-priorityInQueue-span"), testTypeEcho);
    }
}

function setPriorityInQueueDataModel_Echo(model) {
    if (model != null) {
        var testResult = GetEchoData();
        model.TestId = testTypeEcho;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#echo-priorityInQueue-span"), "onClick_PriorityInQueueDataEcho();", SetEchoData);
    }
}

function clearAllRegurgitationSelection() {
    //debugger;
    $(".aortic-regurgitation-finding,.mitral-regurgitation-finding,.pulmonic-regurgitation-finding,.tricuspid-regurgitation-finding").find("input[type=radio]").attr("checked", false);
}

function clearAllEchoSelection() {
    $(".clear-all-echo-selection input[type=radio], .clear-all-echo-selection input[type=checkbox]").attr("checked", false);
    $(".clear-all-echo-selection input[type=text]").val('');
}

$(document).ready(function() {
    $(".clear-all-echo-selection input[type=radio], .clear-all-echo-selection input[type=checkbox]").click(function () {
        $("input[name=EchoPhysicianAdditionalFindingReading]:radio").attr("checked", false);
    });
});