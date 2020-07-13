function Ekg(testResult) {
    if (testResult == null || testResult == undefined) {
        var testResult = { "Id": 0, "TestType": testTypeEkg,
            "UnableScreenReason": new Array(),
            "ResultImage": null,
            "EKGStandardFinding": null,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": '0',
            "TestPerformedExternally": null,             
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "ResultStatus": { "Id": 0,
                "SelfPresent": $("#SelfPresentEKGInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestEKGCheck").attr("checked")
            }
        };
    }
    this.Result = testResult;
}

Ekg.prototype = {
    setData: function () {
        var testResult = this.Result;
        if (IsekgResultEntryExternaly == 'True') {
            setTestPerformedExternally("chk_ekgcapturebyChat", testResult.TestPerformedExternally)
        }

        setboolTypeReading($("#sinusRythmInputCheck"), testResult.SinusRythm);
        setboolTypeReading($("#sinusArrythmiaInputCheck"), testResult.SinusArrythmia);
        setboolTypeReading($("#sinusBradycardiaInputCheck"), testResult.SinusBradycardia);
        setboolTypeReading($("#mildInputCheck"), testResult.Mild);
        setboolTypeReading($("#markedInputCheck"), testResult.Marked);
        setboolTypeReading($("#sinusTachycardiaInputCheck"), testResult.SinusTachycardia);
        setboolTypeReading($("#atrialFibrillationInputCheck"), testResult.AtrialFibrillation);
        setboolTypeReading($("#AtrialFlutterInputCheck"), testResult.AtrialFlutter);
        setboolTypeReading($("#SupraventriculaCheckbox"), testResult.SupraventricularArrythmia);
        setboolTypeReading($("#svtInputCheck"), testResult.SVT);
        setboolTypeReading($("#pacInputCheck"), testResult.PACs);
        setboolTypeReading($("#pvcInputCheck"), testResult.PVCs);
        setboolTypeReading($("#PacerRythmCheckbox"), testResult.PacerRythm);

        setboolTypeReading($("#BundleBranchBlockCheckbox"), testResult.BundleBranchBlock);
        setboolTypeReading($("#LeftAnteriorfasicularBlockCheckbox"), testResult.LeftAnteriorFasicularBlock);
        setboolTypeReading($("#EkgVentricularCheckbox"), testResult.VentricularHypertrophy);
        setboolTypeReading($("#LeftVentricularCheckbox"), testResult.LeftVentricularHypertrophy);
        setboolTypeReading($("#RightVentricularCheckbox"), testResult.RightVentricularHypertrophy);
        setboolTypeReading($("#ISchemicSttCheckbox"), testResult.IschemicSTTChanges);
        setboolTypeReading($("#NonSpecificSttCheckbox"), testResult.NonSpecificSTTChanges);
        setboolTypeReading($("#PoorRWaveProgressionCheckbox"), testResult.PoorRWaveProgression);
        setboolTypeReading($("#ProlongedQTCheckbox"), testResult.ProlongedQTInterval);
        setboolTypeReading($("#InfarctionPatternCheckbox"), testResult.InfarctionPattern);

        setboolTypeReading($("#ATypicalWaveCheckbox"), testResult.AtypicalQWaveLead);
        setboolTypeReading($("#EkgAtrialEnlargementCheckbox"), testResult.AtrialEnlargement);
        setboolTypeReading($("#EkgLeftAtrialCheckbox"), testResult.LeftAtrialEnlargement);
        setboolTypeReading($("#EkgRightAtrialCheckbox"), testResult.RightAtrialEnlargement);
        setboolTypeReading($("#RepolarizationCheckbox"), testResult.RepolarizationVariant);

        setboolTypeReading($("#qrsWideningInputCheck"), testResult.QRSWidening);
        setboolTypeReading($("#leftAxisInputCheck"), testResult.LeftAxis);
        setboolTypeReading($("#RightAxisInputCheck"), testResult.RightAxis);
        setboolTypeReading($("#AbnormalAxisInputCheck"), testResult.AbnormalAxis);
        setboolTypeReading($("#LeftInputCheck"), testResult.Left);
        setboolTypeReading($("#RightInputCheck"), testResult.Right);
        setboolTypeReading($("#HeartBlockInputCheck"), testResult.HeartBlock);
        setboolTypeReading($("#TypeIInputCheck"), testResult.TypeI);
        setboolTypeReading($("#TypeIIInputCheck"), testResult.TypeII);
        setboolTypeReading($("#FirstDegreeBlockInputCheck"), testResult.FirstDegreeBlock);
        setboolTypeReading($("#SecondDegreeBlockCheckbox"), testResult.SecondDegreeBlock);
        setboolTypeReading($("#ThirdDegreeBlockInputCheck"), testResult.ThirdDegreeCompleteHeartBlock);
        setboolTypeReading($("#ArtifactInputCheck"), testResult.Artifact);
        setboolTypeReading($("#RepeatStudyInputCheck"), testResult.RepeatStudy);
        setboolTypeReading($("#ReversedLeadInputCheck"), testResult.ReversedLeads);
        setboolTypeReading($("#ComparedtoPrevEkgInputCheck"), testResult.ComparetoEkg);

        setboolTypeReading($("#EkgLowVoltageCheckbox"), testResult.LowVoltage);
        setboolTypeReading($("#EkgLimbLeadsCheckbox"), testResult.LimbLeads);
        setboolTypeReading($("#EkgPrecordialLeadsCheckbox"), testResult.PrecordialLeads);

        setMultipleFindingDatalist($('.bundle-branch-finding'), testResult.BundleBranchBlockFinding);
        setMultipleFindingDatalist($('.infarction-pattern-finding'), testResult.InfarctionPatternFinding);

        $("#SelfPresentEKGInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);
        $("#PriorityInQueueTestEKGCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#ekg-priorityInQueue-span"), "onClick_PriorityInQueueDataEKG();", testTypeEkg);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#ekg-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#ekg-critical-span"), "onClick_CriticalDataEkg();", testTypeEkg);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#ekg-critical-span").parent().addClass("red-band");
                $("#criticalEkg").attr("checked", "checked");
            }
        }

        if (testResult.Finding != null) {
            setSelectedFindingDatalist($(".ekg-finding-grid"), testResult.Finding.Id);
        }

        setUnableScreenReason($('.dtl-unabletoscreen-ekg'), testResult.UnableScreenReason);

        if (testResult.ResultImage != null) {
            var expr;
            eval("expr = " + testResult.ResultImage.Thumbnail.UploadedOn + ";");
            eval("testResult.ResultImage.Thumbnail.UploadedOn = new " + expr.source + ";");

            eval("expr = " + testResult.ResultImage.File.UploadedOn + ";");
            eval("testResult.ResultImage.File.UploadedOn = new " + expr.source + ";");

            SetPdfImageUrl(testResult.ResultImage.File.Path, testResult.ResultImage.File.FileSize, testResult.ResultImage.Thumbnail.Path, testResult.ResultImage.Thumbnail.FileSize, true);
        }

        $("#technotesekg").val(testResult.TechnicianNotes);
        $("#conductedbyekg option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);

        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksEkg").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpEkg").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalEkg").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }
    },
    getData: function () {
        var testResult = this.Result;

        if (IsekgResultEntryExternaly == 'True') {
             testResult.TestPerformedExternally = getTestPerformedExternally("chk_ekgcapturebyChat", testResult.TestPerformedExternally)
        }

        if (currentScreenMode != ScreenMode.Entry) {
            testResult.SinusRythm = getboolTypeReading($("#sinusRythmInputCheck"), testResult.SinusRythm);
            testResult.SinusArrythmia = getboolTypeReading($("#sinusArrythmiaInputCheck"), testResult.SinusArrythmia);
            testResult.SinusBradycardia = getboolTypeReading($("#sinusBradycardiaInputCheck"), testResult.SinusBradycardia);
            testResult.Mild = getboolTypeReading($("#mildInputCheck"), testResult.Mild);
            testResult.Marked = getboolTypeReading($("#markedInputCheck"), testResult.Marked);
            testResult.SinusTachycardia = getboolTypeReading($("#sinusTachycardiaInputCheck"), testResult.SinusTachycardia);
            testResult.AtrialFibrillation = getboolTypeReading($("#atrialFibrillationInputCheck"), testResult.AtrialFibrillation);
            testResult.AtrialFlutter = getboolTypeReading($("#AtrialFlutterInputCheck"), testResult.AtrialFlutter);
            testResult.SupraventricularArrythmia = getboolTypeReading($("#SupraventriculaCheckbox"), testResult.SupraventricularArrythmia);
            testResult.SVT = getboolTypeReading($("#svtInputCheck"), testResult.SVT);
            testResult.PACs = getboolTypeReading($("#pacInputCheck"), testResult.PACs);
            testResult.PVCs = getboolTypeReading($("#pvcInputCheck"), testResult.PVCs);
            testResult.PacerRythm = getboolTypeReading($("#PacerRythmCheckbox"), testResult.PacerRythm);

            testResult.BundleBranchBlock = getboolTypeReading($("#BundleBranchBlockCheckbox"), testResult.BundleBranchBlock);
            testResult.LeftAnteriorFasicularBlock = getboolTypeReading($("#LeftAnteriorfasicularBlockCheckbox"), testResult.LeftAnteriorFasicularBlock);
            testResult.VentricularHypertrophy = getboolTypeReading($("#EkgVentricularCheckbox"), testResult.VentricularHypertrophy);
            testResult.LeftVentricularHypertrophy = getboolTypeReading($("#LeftVentricularCheckbox"), testResult.LeftVentricularHypertrophy);
            testResult.RightVentricularHypertrophy = getboolTypeReading($("#RightVentricularCheckbox"), testResult.RightVentricularHypertrophy);
            testResult.IschemicSTTChanges = getboolTypeReading($("#ISchemicSttCheckbox"), testResult.IschemicSTTChanges);
            testResult.NonSpecificSTTChanges = getboolTypeReading($("#NonSpecificSttCheckbox"), testResult.NonSpecificSTTChanges);
            testResult.PoorRWaveProgression = getboolTypeReading($("#PoorRWaveProgressionCheckbox"), testResult.PoorRWaveProgression);
            testResult.ProlongedQTInterval = getboolTypeReading($("#ProlongedQTCheckbox"), testResult.ProlongedQTInterval);
            testResult.InfarctionPattern = getboolTypeReading($("#InfarctionPatternCheckbox"), testResult.InfarctionPattern);

            testResult.AtypicalQWaveLead = getboolTypeReading($("#ATypicalWaveCheckbox"), testResult.AtypicalQWaveLead);
            testResult.AtrialEnlargement = getboolTypeReading($("#EkgAtrialEnlargementCheckbox"), testResult.AtrialEnlargement);
            testResult.LeftAtrialEnlargement = getboolTypeReading($("#EkgLeftAtrialCheckbox"), testResult.LeftAtrialEnlargement);
            testResult.RightAtrialEnlargement = getboolTypeReading($("#EkgRightAtrialCheckbox"), testResult.RightAtrialEnlargement);
            testResult.RepolarizationVariant = getboolTypeReading($("#RepolarizationCheckbox"), testResult.RepolarizationVariant);

            testResult.QRSWidening = getboolTypeReading($("#qrsWideningInputCheck"), testResult.QRSWidening);
            testResult.LeftAxis = getboolTypeReading($("#leftAxisInputCheck"), testResult.LeftAxis);
            testResult.RightAxis = getboolTypeReading($("#RightAxisInputCheck"), testResult.RightAxis);
            testResult.AbnormalAxis = getboolTypeReading($("#AbnormalAxisInputCheck"), testResult.AbnormalAxis);
            testResult.Left = getboolTypeReading($("#LeftInputCheck"), testResult.Left);
            testResult.Right = getboolTypeReading($("#RightInputCheck"), testResult.Right);
            testResult.HeartBlock = getboolTypeReading($("#HeartBlockInputCheck"), testResult.HeartBlock);
            testResult.TypeI = getboolTypeReading($("#TypeIInputCheck"), testResult.TypeI);
            testResult.TypeII = getboolTypeReading($("#TypeIIInputCheck"), testResult.TypeII);
            testResult.FirstDegreeBlock = getboolTypeReading($("#FirstDegreeBlockInputCheck"), testResult.FirstDegreeBlock);
            testResult.SecondDegreeBlock = getboolTypeReading($("#SecondDegreeBlockCheckbox"), testResult.SecondDegreeBlock);
            testResult.ThirdDegreeCompleteHeartBlock = getboolTypeReading($("#ThirdDegreeBlockInputCheck"), testResult.ThirdDegreeCompleteHeartBlock);
            testResult.Artifact = getboolTypeReading($("#ArtifactInputCheck"), testResult.Artifact);
            testResult.RepeatStudy = getboolTypeReading($("#RepeatStudyInputCheck"), testResult.RepeatStudy);
            testResult.ReversedLeads = getboolTypeReading($("#ReversedLeadInputCheck"), testResult.ReversedLeads);
            testResult.ComparetoEkg = getboolTypeReading($("#ComparedtoPrevEkgInputCheck"), testResult.ComparetoEkg);

            testResult.LowVoltage = getboolTypeReading($("#EkgLowVoltageCheckbox"), testResult.LowVoltage);
            testResult.LimbLeads = getboolTypeReading($("#EkgLimbLeadsCheckbox"), testResult.LimbLeads);
            testResult.PrecordialLeads = getboolTypeReading($("#EkgPrecordialLeadsCheckbox"), testResult.PrecordialLeads);

            var bundleBranchBlock = getMultipleFindingDatalist($('.bundle-branch-finding'));
            testResult.BundleBranchBlockFinding = getMultipleFindingDataandSynchronized(testResult.BundleBranchBlockFinding, bundleBranchBlock);

            var infarctionFinding = getMultipleFindingDatalist($('.infarction-pattern-finding'));
            testResult.InfarctionPatternFinding = getMultipleFindingDataandSynchronized(testResult.InfarctionPatternFinding, infarctionFinding);

            var ekgFinding = getSelectedFindingDatalist($(".ekg-finding-grid"));
            testResult.Finding = getFindingDataandSynchronized(testResult.Finding, ekgFinding);

            if (testResult.PhysicianInterpretation == null)
                testResult.PhysicianInterpretation = { 'Remarks': $("#physicianRemarksEkg").val(), 'IsCritical': $("#criticalEkg").attr("checked"), 'FollowUp': $("#followUpEkg").attr("checked"), 'RecorderMetaData': {
                    'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate
                }
                };
            else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksEkg").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpEkg").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalEkg").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }

        if (currentScreenMode != ScreenMode.Physician) {
            if ($.trim(pdfImagePhysicalPath).length > 0) {
                if (testResult.ResultImage == null)
                    testResult.ResultImage = { "Id": 0, "ReadingSource": readingSourceManual,
                        "File": { "Path": pdfImagePhysicalPath, "FileSize": pdfImageFileSize, "Type": fileTypeImage },
                        "Thumbnail": { "Path": pdfThumbnailImagePhysicalPath, "FileSize": pdfThumbnailImageFileSize, "Type": fileTypeImage }
                    };
                else if (testResult.ResultImage.File.Path != pdfImagePhysicalPath) {
                    testResult.ResultImage.File.Path = pdfImagePhysicalPath;
                    testResult.ResultImage.File.FileSize = pdfImageFileSize;

                    testResult.ResultImage.Thumbnail.Path = pdfThumbnailImagePhysicalPath;
                    testResult.ResultImage.Thumbnail.FileSize = pdfThumbnailImageFileSize;
                }
            }
            else
                testResult.ResultImage = null;

            if (currentScreenMode != ScreenMode.CorrectionPostEvaluation) testResult.ResultStatus.StateNumber = $("#ResultStatusInputHidden").val();

            if (testResult.ResultStatus.Id > 0) {
                testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.ResultStatus.DataRecorderMetaData.DateModified = currentDate;
            }
            else {
                testResult.ResultStatus.DataRecorderMetaData = { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate };
            }
        }

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unabletoscreen-ekg')));

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.TechnicianNotes = $.trim($("#technotesekg").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ConductedByOrgRoleUserId = $("#conductedbyekg option:selected").val();
            testResult.ResultStatus.SelfPresent = $("#SelfPresentEKGInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestEKGCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_11").attr("checked");

        if (testResult.ResultStatus.StateNumber < 4) {
            if (!(testResult.TechnicianNotes.length > 0 || testResult.ResultImage != null || testResult.IncidentalFindings != null || testResult.ConductedByOrgRoleUserId != "0" ||
                    (testResult.UnableScreenReason != null && testResult.UnableScreenReason.length > 0) || $("#SelfPresentEKGInputCheck").attr("checked") == true)) return null;
        }

        return testResult;
    }
}


var pdfImagePhysicalPath = '';
var pdfImageFileSize = 0;
var pdfThumbnailImagePhysicalPath = '';
var pdfThumbnailImageFileSize = 0;

function SetPdfImageUrl(imgName, fileSize, thumbnailImgName, thumbnailFileSize, isFirstTimeUpload) {
    if(isFirstTimeUpload == null)
        isFirstTimeUpload = false;

    if ($.trim(pdfImagePhysicalPath).length > 0 && !isFirstTimeUpload) {
        var bolConfirm = confirm("This will overwrite your existing Pdf. Do you want to continue?");
        if (!bolConfirm) return;
    }

    pdfImagePhysicalPath = imgName;
    pdfThumbnailImagePhysicalPath = thumbnailImgName;
    pdfImageFileSize = fileSize;
    pdfThumbnailImageFileSize = thumbnailFileSize;

    $("#PDFUploadImage").attr("src", getUrlPrefix() + thumbnailImgName);

    $("#PDFUploadImage").click(function () {

        currentReference = $(this);
        checkNextPrevAvailable();

        var imgSrc = getUrlPrefix() + imgName;
        //if (currentScreenMode != ScreenMode.Physician) {
            onImageClick(imgSrc);
        //} else {
        //    viewEkgImage(imgSrc);
        //}
        
    });

    $(".pdf-upload-ekg-img-div").show();
}

function RemoveEKGImage() {
    pdfImagePhysicalPath = "";
    pdfThumbnailImagePhysicalPath = "";
    pdfImageFileSize = 0;
    pdfThumbnailImageFileSize = 0;

    $("#PDFUploadImage").attr("src", "");
    $(".pdf-upload-ekg-img-div").hide();
}

$(document).ready(function () {
    
    if (currentScreenMode == ScreenMode.Physician) {
        $(".remove-image").hide();
    }
});

var criticalDataModel_Ekg = null;
function onClick_CriticalDataEkg() {
    if ($("#SelfPresentEKGInputCheck").attr("checked")) {
        loadCriticalLink($("#ekg-critical-span"), "onClick_CriticalDataEkg();", testTypeEkg);
        openCriticalDataDialog(testTypeEkg, $("#conductedbyekg"), $("#SelfPresentEKGInputCheck"), setCriticalDataModel_Ekg);
    }
    else {
        unloadCriticalLink($("#ekg-critical-span"), testTypeEkg);
    }
}

function setCriticalDataModel_Ekg(model, printAfterSave) {
    if (model != null) {
        var testResult = GetEKGData();
        saveSingleTestResult(testResult, model, $("#ekg-critical-span"), "onClick_CriticalDataEkg();", SetEKGData, printAfterSave);
    }
}

function getCriticalDataModel_Ekg() {
    if ($("#SelfPresentEKGInputCheck").attr("checked") && criticalDataModel_Ekg != null) {
        criticalDataModel_Ekg.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_Ekg;
    }
    return null;
}
function onClick_PriorityInQueueDataEKG() {
    if ($("#PriorityInQueueTestEKGCheck").attr("checked")) {
        loadPriorityInQueueLink($("#ekg-priorityInQueue-span"), "onClick_PriorityInQueueDataEKG();", testTypeEkg);
        openPriorityInQueueTestDialog(testTypeEkg, $("#conductedbyekg"), $("#PriorityInQueueTestEKGCheck"), setPriorityInQueueDataModel_EKG);
    }
    else {
        unloadPriorityInQueueLink($("#ekg-priorityInQueue-span"), testTypeEkg);
    }
}

function setPriorityInQueueDataModel_EKG(model) {
    if (model != null) {
        var testResult = GetEKGData();
        model.TestId = testTypeEkg;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#ekg-priorityInQueue-span"), "onClick_PriorityInQueueDataEKG();", SetEKGData);
    }
}

function clearAllEkgSelection() {
    $(".clear-all-ekg-selection input[type=radio], .clear-all-ekg-selection input[type=checkbox]").attr("checked", false);
}