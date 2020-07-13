var urlPrefix = getUrlPrefix();
var fileTypeMyBioCheckPDF;

function MyBioCheckAssessment(testResult) {
    if (testResult == null || testResult == undefined) {

        testResult = {
            "Id": 0, "TestType": testTypeMyBioCheckAssessment,
            "TotalCholestrol": null, "Hdl": null,
            "Ldl": null, "Glucose": null,
            "TriGlycerides": null, "TcHdlRatio": null,
            "TechnicianNotes": '', "ConductedByOrgRoleUserId": '',
            "UnableScreenReason": new Array(),
            "TestPerformedExternally": null,
            "IsNewResultFlow": $("#IsNewResultFlowInputHidden").val(),
            "IsResultEntrybyChat" : false,
            "ResultStatus": {
                "Id": 0,
                "SelfPresent": $("#SelfPresentMyBioCheckAssessmentInputCheck").attr("checked"),
                "StateNumber": $("#ResultStatusInputHidden").val(),
                "IsPriorityInQueue": $("#PriorityInQueueTestMyBioCheckAssessmentCheck").attr("checked")
            }
        };

    }
    this.Result = testResult;
}

MyBioCheckAssessment.prototype = {
    setData: function() {
        var testResult = this.Result;
        if (isMybiocheckResultentrytype == 'True') {
            setTestPerformedExternally("chk_mybiocheckcapturebyChat", testResult.TestPerformedExternally)
        }
        
        if (testResult.TotalCholestrol != null) {
            if (testResult.TotalCholestrol.Reading != null) {
                $("#TotalCholestrolMyBioCheckAssessmentInputText").val(testResult.TotalCholestrol.Reading);
            }

            if (testResult.TotalCholestrol.Finding != null) {
                setSelectedFinding($(".tc-myBioCheckAssessment-finding"), testResult.TotalCholestrol.Finding.Id);
            }
        }

        if (testResult.ResultImage != null) {
            var expr;

            eval("expr = " + testResult.ResultImage.File.UploadedOn + ";");
            eval("testResult.ResultImage.File.UploadedOn = new " + expr.source + ";");

            setMyBioCheckFiles(testResult.ResultImage);
        }

        if (testResult.Glucose != null) {
            if (testResult.Glucose.Reading != null)
                $("#GlucoseMyBioCheckAssessmentInputText").val(testResult.Glucose.Reading);

            if (testResult.Glucose.Finding != null) {
                setSelectedFinding($(".glucose-myBioCheckAssessment-finding"), testResult.Glucose.Finding.Id);
            }
        }

        if (testResult.Hdl != null) {
            if (testResult.Hdl.Reading != null) {
                $("#HDLMyBioCheckAssessmentInputText").val(testResult.Hdl.Reading);
            }

            if (testResult.Hdl.Finding != null) {
                setSelectedFinding($(".hdl-myBioCheckAssessment-finding"), testResult.Hdl.Finding.Id);
            }
        }

        if (testResult.TriGlycerides != null) {
            if (testResult.TriGlycerides.Reading != null) {
                $("#TriglyceridesMyBioCheckAssessmentInputText").val(testResult.TriGlycerides.Reading);
            }

            if (testResult.TriGlycerides.Finding != null) {
                setSelectedFinding($(".triglycerides-myBioCheckAssessment-finding"), testResult.TriGlycerides.Finding.Id);
            }
        }

        if (testResult.Ldl != null) {
            if (testResult.Ldl.Reading != null) {
                $("#LDLMyBioCheckAssessmentInputText").val(testResult.Ldl.Reading);
            }

            if (testResult.Ldl.Finding != null) {
                setSelectedFinding($(".ldl-myBioCheckAssessment-finding"), testResult.Ldl.Finding.Id);
            }
        }


        if (testResult.TcHdlRatio != null) {

            if (testResult.TcHdlRatio.Reading != null)
                $("#TCHDLRatioMyBioCheckAssessmentInputText").val(parseFloat(testResult.TcHdlRatio.Reading).toFixed(1));

            if (testResult.TcHdlRatio.Finding != null) {
                setSelectedFinding($(".tchdlratio-myBioCheckAssessment-finding"), testResult.TcHdlRatio.Finding.Id);
            }
        }

        $("#technotesmyBioCheckAssessment").val(testResult.TechnicianNotes);
        $("#conductedbymyBioCheckAssessment option[value=" + testResult.ConductedByOrgRoleUserId + "]").attr("selected", true);
        $("#SelfPresentMyBioCheckAssessmentInputCheck").attr("checked", testResult.ResultStatus.SelfPresent);
        $("#PriorityInQueueTestMyBioCheckAssessmentCheck").attr("checked", testResult.ResultStatus.IsPriorityInQueue);
        
        if (testResult.ResultStatus.IsPriorityInQueue) {
            loadPriorityInQueueLink($("#myBioCheckAssessment-priorityInQueue-span"), "onClick_PriorityInQueueDataMyBioCheckAssessment();", testTypeMyBioCheckAssessment);
            if (currentScreenMode == ScreenMode.Physician && !testResult.ResultStatus.SelfPresent) {
                $("#myBioCheckAssessment-priorityInQueue-span").parent().addClass("yellow-band"); // must be overWritten by Critical
            }
        }
        if (testResult.ResultStatus.SelfPresent) {
            loadCriticalLink($("#myBioCheckAssessment-critical-span"), "onClick_CriticalDataMyBioCheckAssessment();", testTypeMyBioCheckAssessment);

            if (currentScreenMode == ScreenMode.Physician) {
                $("#myBioCheckAssessment-critical-span").parent().addClass("red-band");
                $("#criticalMyBioCheckAssessment").attr("checked", "checked");
            }
        }
        
        SetTestNotPerformedReasonForMyBioCheck(testResult.TestNotPerformed);
        setUnableScreenReason($('.dtl-unable-to-screen-myBioCheckAssessment'), testResult.UnableScreenReason);

        if (testResult.PhysicianInterpretation != null) {
            $("#physicianRemarksMyBioCheckAssessment").val(testResult.PhysicianInterpretation.Remarks);
            $("#followUpMyBioCheckAssessment").attr("checked", testResult.PhysicianInterpretation.FollowUp);
            $("#criticalMyBioCheckAssessment").attr("checked", testResult.PhysicianInterpretation.IsCritical);
        }
    },
    getData: function() {
        var testResult = this.Result;
        if (isMybiocheckResultentrytype == 'True') {
            testResult.TestPerformedExternally = getTestPerformedExternally("chk_mybiocheckcapturebyChat", testResult.TestPerformedExternally)
        } else {
            testResult.TestPerformedExternally = null;
        }

        testResult.UnableScreenReason = SynchronizeUnableScreenReason(testResult.UnableScreenReason, getUnableScreenReason($('.dtl-unable-to-screen-myBioCheckAssessment')));
        testResult.TestNotPerformed = getTestNotPerformedReasonForMyBioCheck(testResult.TestNotPerformed);
        
        testResult.TotalCholestrol = getReading($("#TotalCholestrolMyBioCheckAssessmentInputText"), testResult.TotalCholestrol);
        testResult.Hdl = getReading($("#HDLMyBioCheckAssessmentInputText"), testResult.Hdl);
        testResult.Glucose = getReading($("#GlucoseMyBioCheckAssessmentInputText"), testResult.Glucose);
        testResult.TriGlycerides = getReading($("#TriglyceridesMyBioCheckAssessmentInputText"), testResult.TriGlycerides);
        testResult.Ldl = getReading($("#LDLMyBioCheckAssessmentInputText"), testResult.Ldl);
        testResult.TcHdlRatio = getReading($("#TCHDLRatioMyBioCheckAssessmentInputText"), testResult.TcHdlRatio);
        testResult.ResultImage = GetMyBioCheckMedia();
        if (currentScreenMode != ScreenMode.Physician) {

            if (currentScreenMode != ScreenMode.CorrectionPostEvaluation && currentScreenMode != ScreenMode.PostAudit) testResult.ResultStatus.StateNumber = $("#ResultStatusInputHidden").val();

            if (testResult.ResultStatus.Id > 0) {
                testResult.ResultStatus.DataRecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.ResultStatus.DataRecorderMetaData.DateModified = currentDate;
            } else {
                testResult.ResultStatus.DataRecorderMetaData = { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate };
            }
        }

        if (currentScreenMode == ScreenMode.Entry || currentScreenMode == ScreenMode.CorrectionPreEvaluation) {
            testResult.TechnicianNotes = $.trim($("#technotesmyBioCheckAssessment").val());
            testResult.TechNotesSource = readingSourceManual;
            testResult.ConductedByOrgRoleUserId = $("#conductedbymyBioCheckAssessment option:selected").val();
            testResult.ResultStatus.SelfPresent = $("#SelfPresentMyBioCheckAssessmentInputCheck").attr("checked");
            testResult.ResultStatus.IsPriorityInQueue = $("#PriorityInQueueTestMyBioCheckAssessmentCheck").attr("checked");
        }

        testResult.IsRetest = $("#Retest_99").attr("checked");

        var tcFinding = getSelectedFinding($(".tc-myBioCheckAssessment-finding"));
        if (testResult.TotalCholestrol != null) {
            testResult.TotalCholestrol.Finding = getFindingDataandSynchronized(testResult.TotalCholestrol.Finding, tcFinding);
        } else if (tcFinding != null) {
            testResult.TotalCholestrol = { 'Finding': getFindingDataandSynchronized(null, tcFinding), "ReadingSource": readingSourceManual, 'RecorderMetaData': { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate } };
        }

        var gluFinding = getSelectedFinding($(".glucose-myBioCheckAssessment-finding"));
        if (testResult.Glucose != null) {
            testResult.Glucose.Finding = getFindingDataandSynchronized(testResult.Glucose.Finding, gluFinding);
        } else if (gluFinding != null) {
            testResult.Glucose = { 'Finding': getFindingDataandSynchronized(null, gluFinding), "ReadingSource": readingSourceManual, 'RecorderMetaData': { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate } };
        }

        var hdlFinding = getSelectedFinding($(".hdl-myBioCheckAssessment-finding"));
        if (testResult.Hdl != null) {
            testResult.Hdl.Finding = getFindingDataandSynchronized(testResult.Hdl.Finding, hdlFinding);
        } else if (hdlFinding != null) {
            testResult.Hdl = { 'Finding': getFindingDataandSynchronized(null, hdlFinding), "ReadingSource": readingSourceManual, 'RecorderMetaData': { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate } };
        }

        var tGlyFinding = getSelectedFinding($(".triglycerides-myBioCheckAssessment-finding"));
        if (testResult.TriGlycerides != null) {
            testResult.TriGlycerides.Finding = getFindingDataandSynchronized(testResult.TriGlycerides.Finding, tGlyFinding);
        } else if (tGlyFinding != null) {
            testResult.TriGlycerides = { 'Finding': getFindingDataandSynchronized(null, tGlyFinding), "ReadingSource": readingSourceManual, 'RecorderMetaData': { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate } };
        }

        var ldlFinding = getSelectedFinding($(".ldl-myBioCheckAssessment-finding"));
        if (testResult.Ldl != null) {
            testResult.Ldl.Finding = getFindingDataandSynchronized(testResult.Ldl.Finding, ldlFinding);
        } else if (ldlFinding != null) {
            testResult.Ldl = { 'Finding': getFindingDataandSynchronized(null, ldlFinding), "ReadingSource": readingSourceManual, 'RecorderMetaData': { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate } };
        }

        var tcHdlFinding = getSelectedFinding($(".tchdlratio-myBioCheckAssessment-finding"));
        if (testResult.TcHdlRatio != null) {
            testResult.TcHdlRatio.Finding = getFindingDataandSynchronized(testResult.TcHdlRatio.Finding, tcHdlFinding);
        } else if (tcHdlFinding != null) {
            testResult.TcHdlRatio = { 'Finding': getFindingDataandSynchronized(null, tcHdlFinding), "ReadingSource": readingSourceManual, 'RecorderMetaData': { 'DataRecorderCreator': { 'Id': currentUser }, 'DateCreated': currentDate } };
        }

        if (currentScreenMode == ScreenMode.Physician) {
            testResult = setPhysicianResultStatus(testResult, IsTestPermitted(testResult.TestType));
        }

        if (currentScreenMode != ScreenMode.Entry) {
            if (testResult.PhysicianInterpretation == null) {
                testResult.PhysicianInterpretation = {
                    'Remarks': $("#physicianRemarksMyBioCheckAssessment").val(),
                    'IsCritical': $("#criticalMyBioCheckAssessment").attr("checked"),
                    'FollowUp': $("#followUpMyBioCheckAssessment").attr("checked"),
                    'RecorderMetaData': {
                        'DataRecorderCreator': { 'Id': currentUser },
                        'DateCreated': currentDate
                    }
                };
            } else {
                testResult.PhysicianInterpretation.Remarks = $("#physicianRemarksMyBioCheckAssessment").val();
                testResult.PhysicianInterpretation.FollowUp = $("#followUpMyBioCheckAssessment").attr("checked");
                testResult.PhysicianInterpretation.IsCritical = $("#criticalMyBioCheckAssessment").attr("checked");
                testResult.PhysicianInterpretation.RecorderMetaData.DataRecorderModifier = { 'Id': currentUser };
                testResult.PhysicianInterpretation.RecorderMetaData.DateModified = currentDate;
            }
        }


        if (testResult.ResultStatus.StateNumber < 4) {
            if (!(testResult.TotalCholestrol != null || testResult.Hdl != null || testResult.Ldl != null ||
                testResult.Glucose != null || testResult.TcHdlRatio != null || testResult.TriGlycerides != null ||
                testResult.TechnicianNotes.length > 0 || testResult.ConductedByOrgRoleUserId != "0" ||
                (testResult.UnableScreenReason != null && testResult.UnableScreenReason.length > 0) || $("#SelfPresentMyBioCheckAssessmentInputCheck").attr("checked") == true))
                return null;
        }

        return testResult;
    }
};


function onblurCalculateTCHDLRatio() {
    if ($.trim($("#TotalCholestrolMyBioCheckAssessmentInputText").val()).length < 1 ||
            $.trim($("#HDLMyBioCheckAssessmentInputText").val()).length < 1) {
        $("#TCHDLRatioMyBioCheckAssessmentInputText").val('');
    }
    else if (isNaN($.trim($("#TotalCholestrolMyBioCheckAssessmentInputText").val())) == true ||
            isNaN($.trim($("#HDLMyBioCheckAssessmentInputText").val())) == true) {
        $("#TCHDLRatioMyBioCheckAssessmentInputText").val('');
    }
    else if (Number($.trim($("#TotalCholestrolMyBioCheckAssessmentInputText").val())) == 0 ||
            Number($.trim($("#HDLMyBioCheckAssessmentInputText").val())) == 0) {
        $("#TCHDLRatioMyBioCheckAssessmentInputText").val('');
    }
    else {
        var tcHdlRatio = Number($.trim($("#TotalCholestrolMyBioCheckAssessmentInputText").val())) / Number($.trim($("#HDLMyBioCheckAssessmentInputText").val()));
        $("#TCHDLRatioMyBioCheckAssessmentInputText").val(parseFloat(tcHdlRatio).toFixed(1));
    }

    $("#TCHDLRatioMyBioCheckAssessmentInputText").focus();
    $("#TCHDLRatioMyBioCheckAssessmentInputText").blur();
}

function onblurCalculateLDL() {
    if ($.trim($("#TotalCholestrolMyBioCheckAssessmentInputText").val()).length < 1 || $.trim($("#HDLMyBioCheckAssessmentInputText").val()).length < 1 || $.trim($("#TriglyceridesMyBioCheckAssessmentInputText").val()).length < 1) {
        $("#LDLMyBioCheckAssessmentInputText").val('');
    }
    else if (isNaN($.trim($("#TotalCholestrolMyBioCheckAssessmentInputText").val())) == true || isNaN($.trim($("#HDLMyBioCheckAssessmentInputText").val())) == true || isNaN($.trim($("#TriglyceridesMyBioCheckAssessmentInputText").val())) == true) {
        $("#LDLMyBioCheckAssessmentInputText").val('');
    }
    else if (Number($.trim($("#TotalCholestrolMyBioCheckAssessmentInputText").val())) == 0 || Number($.trim($("#HDLMyBioCheckAssessmentInputText").val())) == 0 || Number($.trim($("#TriglyceridesMyBioCheckAssessmentInputText").val())) == 0) {
        $("#LDLMyBioCheckAssessmentInputText").val('');
    }
    else {
        var ldl = Number($.trim($("#TotalCholestrolMyBioCheckAssessmentInputText").val())) - Number($.trim($("#HDLMyBioCheckAssessmentInputText").val())) - (Number($.trim($("#TriglyceridesMyBioCheckAssessmentInputText").val())) / 5);
        $("#LDLMyBioCheckAssessmentInputText").val(parseFloat(ldl).toFixed(0));
    }

    $("#LDLMyBioCheckAssessmentInputText").change();
}


function SetTestNotPerformedReasonForMyBioCheck(testNotPerformed) {
    setTestNotPerformed("testnotPerformedMyBioCheckAssessment", testNotPerformed);
    SetTestNotPerformedEnableDisabled("testnotPerformedMyBioCheckAssessment");
}

function getTestNotPerformedReasonForMyBioCheck(testNotPerformed) {
    return getTestNotPerformed("testnotPerformedMyBioCheckAssessment", testNotPerformed);
}

function onChangeTotalCholestrol(TCinput) {
    var tcInputElement = $(TCinput);
    autoSelectFinding($(".tc-myBioCheckAssessment-finding"), tcInputElement, 1);
    onblurCalculateTCHDLRatio();
    onblurCalculateLDL();
    checkMyBioCheckAssessmentTotalCholesterolMinMaxValue(tcInputElement.val());
}

function onChangeHDL(HDLinput) {
    var hdlInputElement = $(HDLinput);
    autoSelectFinding($(".hdl-myBioCheckAssessment-finding"), hdlInputElement, 1);
    onblurCalculateTCHDLRatio();
    onblurCalculateLDL();
    checkMyBioCheckAssessmentHDLMinMaxValue(hdlInputElement.val());
}

function onChangeLdlMyBioCheckAssessment(ldlMyBioCheckAssessmentInput) {
    var ldlMyBioCheckAssessmentElement = $(ldlMyBioCheckAssessmentInput);
    autoSelectFinding($('.ldl-myBioCheckAssessment-finding'), ldlMyBioCheckAssessmentElement, 1);
    checkMyBioCheckAssessmentLDLMinMaxValue(ldlMyBioCheckAssessmentElement.val());
}

function onChangeTriglycerides(triglyceridesInput) {
    var triglyceridesElement = $(triglyceridesInput);
    autoSelectFinding($(".triglycerides-myBioCheckAssessment-finding"), triglyceridesElement, 1);
    onblurCalculateLDL();
    checkMyBioCheckAssessmentTriglyceridesMinMaxValue(triglyceridesElement.val());
}

var criticalDataModel_MyBioCheckAssessment = null;
function onClick_CriticalDataMyBioCheckAssessment() {
    if ($("#SelfPresentMyBioCheckAssessmentInputCheck").attr("checked")) {
        loadCriticalLink($("#myBioCheckAssessment-critical-span"), "onClick_CriticalDataMyBioCheckAssessment();", testTypeMyBioCheckAssessment);
        openCriticalDataDialog(testTypeMyBioCheckAssessment, $("#conductedbymyBioCheckAssessment"), $("#SelfPresentMyBioCheckAssessmentInputCheck"), setCriticalDataModel_MyBioCheckAssessment);
    }
    else {
        unloadCriticalLink($("#myBioCheckAssessment-critical-span"), testTypeMyBioCheckAssessment);
    }
}

function setCriticalDataModel_MyBioCheckAssessment(model, printAfterSave) {
    if (model != null) {
        var testResult = GetMyBioCheckAssessmentData();
        saveSingleTestResult(testResult, model, $("#myBioCheckAssessment-critical-span"), "onClick_CriticalDataMyBioCheckAssessment();", SetMyBioCheckAssessmentData, printAfterSave);
    }
}

function getCriticalDataModel_MyBioCheckAssessment() {
    if ($("#SelfPresentMyBioCheckAssessmentInputCheck").attr("checked") && criticalDataModel_MyBioCheckAssessment != null) {
        criticalDataModel_MyBioCheckAssessment.PrimaryCarePhysicianName = getPcp();
        return criticalDataModel_MyBioCheckAssessment;
    }
    return null;
}

function onClick_PriorityInQueueDataMyBioCheckAssessment() {
    if ($("#PriorityInQueueTestMyBioCheckAssessmentCheck").attr("checked")) {
        loadPriorityInQueueLink($("#myBioCheckAssessment-priorityInQueue-span"), "onClick_PriorityInQueueDataMyBioCheckAssessment();", testTypeMyBioCheckAssessment);
        openPriorityInQueueTestDialog(testTypeMyBioCheckAssessment, $("#conductedbymyBioCheckAssessment"), $("#PriorityInQueueTestMyBioCheckAssessmentCheck"), setPriorityInQueueDataModel_MyBioCheckAssessment);
    }
    else {
        unloadPriorityInQueueLink($("#myBioCheckAssessment-priorityInQueue-span"), testTypeMyBioCheckAssessment);
    }
}

function setPriorityInQueueDataModel_MyBioCheckAssessment(model) {
    if (model != null) {
        var testResult = GetMyBioCheckAssessmentData();
        model.TestId = testTypeMyBioCheckAssessment;
        saveSingleTestPriorityInQueueResult(testResult, model, $("#myBioCheckAssessment-priorityInQueue-span"), "onClick_PriorityInQueueDataMyBioCheckAssessment();", SetMyBioCheckAssessmentData);
    }
}

function checkHdlFindingsForGenderChange(isMale) {
    if ($("#hdlfindingjson").length < 1) return;

    var hdlFindings = null;
    eval("hdlFindings = " + $("#hdlfindingjson").val());
    if (hdlFindings == null) return;

    var gridHdl = $(".hdl-myBioCheckAssessment-finding");
    gridHdl.find('input[type=radio]').attr("checked", false);

    var count = 0;
    var toCheckFor = isMale ? "male - " : "female - ";

    for (var i = 0; i < hdlFindings.length; i++) {
        var finding = hdlFindings[i];
        if (finding.Label.toLowerCase().indexOf(toCheckFor) == 0) {
            var row = $(gridHdl.find("tr")[count]);
            row.find(".finding-id").val(finding.Id);
            row.find(".finding-minvalue").val(finding.MinValue);
            row.find(".finding-maxvalue").val(finding.MaxValue);

            var cell = $(row.find("td")[1]);
            cell.empty();
            cell.text(finding.Label.substring(toCheckFor.length - 1, finding.Label.length) + " " + finding.Description);
            count++;
        }
    }
    $("#HDLMyBioCheckAssessmentInputText").change();
}


function KeyPress_NumericAllowedOnly_ForMyBioCheckAssessment(evt) {
    var key = (evt.which ? evt.which : ((evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : 0)));
    var InpObject = evt.currentTarget ? evt.currentTarget : evt.srcElement;

    var valarray = InpObject.value.split('');
    var bolContainsSign = false;
    var count = 0;
    while (count < valarray.length) {
        if (valarray[count] == "<" || valarray[count] == ">") {
            bolContainsSign = true;
            break;
        }
        count++;
    }

    var selIndex = getSelectionStart(InpObject);
    if (((key >= 48 && key <= 57 && (bolContainsSign == false || (selIndex > 0 && bolContainsSign == true))) || key == 9 || key == 13 || key == 8 || (key >= 37 && key <= 40)
                || (key >= 96 && key <= 105 && (bolContainsSign == false || (selIndex > 0 && bolContainsSign == true)))) && (evt.shiftKey == false)) {
        return true;
    }

    if ((key == 190 || key == 188) && selIndex == 0 && evt.shiftKey == true) {
        if (bolContainsSign == true)
            return false;

        return true;

    }
    return false;
}

function clearAllMyBioCheckAssessmentSelection() {
    $(".clear-all-myBioCheckAssessment-selection input[type=radio]").attr("checked", false);
}


var myBioCheckFileCount = 0;
var myBioCheckResultMedia = null;
var myBioCheckPdfPhysicalPath = '';
var myBioCheckPdfFileSize = 0;
var myBioCheckPdfPhysicalPathUrl = '';


function setMyBioCheckFiles(jsonMedia) {
    myBioCheckResultMedia = jsonMedia;
    myBioCheckFileCount = 0;

    $(".uploadMyBioCheckPDF").attr("src", "/Content/Images/PageNotFound-Icons.jpg");
    $(".pdf-awvbonemass-remove").hide();

    setMyBioCheckFileUrlAtStartUp(jsonMedia);
}

function setMyBioCheckFileUrlAtStartUp(jsonMedia) {

    if (jsonMedia == null) return;

    var fileName = jsonMedia.File.Path;
    setMyBioCheckFileUrl(fileName, jsonMedia.FileSize);
}
function setMyBioCheckFileUrl(fileName, fileSize) {
    var bolConfirm;
    
    if (fileName != null && fileName != "") {
        if ($.trim(fileName).length > 0 && myBioCheckPdfPhysicalPath != null && myBioCheckPdfPhysicalPath != "" && myBioCheckPdfPhysicalPath != fileName) {
            bolConfirm = confirm("This will overwrite your existing Pdf. Do you want to continue?");
            if (!bolConfirm) return;
        }
        setmyBioCheckFileType(fileName, fileSize);
    }
}
function setmyBioCheckFileType(fileName, fileSize) {

    var pdf = $(".uploadMyBioCheckPDF");

    myBioCheckPdfPhysicalPathUrl = urlPrefix + fileName;
    $(pdf).attr("src", "/App/Images/pdf-icon-mm.gif");

    myBioCheckPdfPhysicalPath = fileName;
    myBioCheckPdfFileSize = fileSize;

    $(pdf).unbind("click");

    $(pdf).click(function () {
        window.open(myBioCheckPdfPhysicalPathUrl, '_blank');
    });

    $(".pdf-myBioCheck-remove").show();
    $(".pdf-myBioCheck-upload").hide();
}

function GetMyBioCheckMedia() {
    if ($.trim(myBioCheckPdfPhysicalPath).length > 0) {
        if (myBioCheckResultMedia == null) {
            myBioCheckResultMedia = {
                "Id": 0,
                "ReadingSource": readingSourceManual,
                "File": { "Path": myBioCheckPdfPhysicalPath, "FileSize": myBioCheckPdfFileSize, "Type": fileTypeMyBioCheckPDF }
            };
        } else if (myBioCheckResultMedia != null && myBioCheckResultMedia.File.Path != myBioCheckPdfPhysicalPath) {
            myBioCheckResultMedia.File.Path = myBioCheckPdfPhysicalPath;
            myBioCheckResultMedia.File.FileSize = myBioCheckPdfFileSize;
        }
    } else {
        myBioCheckResultMedia = null;
    }

    return myBioCheckResultMedia;
}

$(document).ready(function () {
    $(".pdf-myBioCheck-remove").click(function () {
        myBioCheckPdfPhysicalPath = '';
        myBioCheckPdfFileSize = 0;
        myBioCheckResultMedia = null;
        var pdf = $(".uploadMyBioCheckPDF");
        $(pdf).attr("src", "/Content/Images/PageNotFound-Icons.jpg");

        $(pdf).unbind("click");

        $(this).hide();
        $(".pdf-myBioCheck-upload").show();
    });

});



function checkBioCheckAssessment() {
    var text = "";

    if ($(".dtl-unable-to-screen-myBioCheckAssessment").find("input[type='checkbox']:checked").length > 0)
        return text;

    if ($("#testnotPerformedMyBioCheckAssessment").find("input[type='checkbox']:checked").length > 0)
        return text;

    var myBioCheckAssessmentTestResult = GetMyBioCheckAssessmentData();
    if (myBioCheckAssessmentTestResult != null) {
        if (myBioCheckAssessmentTestResult.TotalCholestrol && myBioCheckAssessmentTestResult.TotalCholestrol.Reading != null) {
            if (myBioCheckAssessmentTestResult.TotalCholestrol.Finding == null || myBioCheckAssessmentTestResult.TotalCholestrol.Finding == "") {
                text += "Total Cholestrol Findings are not marked. <br/>";
            }
        }

        if (myBioCheckAssessmentTestResult.Glucose != null && myBioCheckAssessmentTestResult.Glucose.Reading != null) {
            if (myBioCheckAssessmentTestResult.Glucose.Finding == null || myBioCheckAssessmentTestResult.Glucose.Finding == "") {
                text += "Glucose Findings are not marked.<br/>";
            }

        }

        if (myBioCheckAssessmentTestResult.Hdl != null && myBioCheckAssessmentTestResult.Hdl.Reading != null) {
            if (myBioCheckAssessmentTestResult.Hdl.Finding == null || myBioCheckAssessmentTestResult.Hdl.Finding == "") {
                text += "Hdl Findings are not marked.<br/>";
            }
        }

        if (myBioCheckAssessmentTestResult.TriGlycerides != null && myBioCheckAssessmentTestResult.TriGlycerides.Reading != null) {
            if (myBioCheckAssessmentTestResult.TriGlycerides.Finding == null || myBioCheckAssessmentTestResult.TriGlycerides.Finding == "") {
                text += "TriGlycerides Findings are not marked.<br/>";
            }
        }

        if (myBioCheckAssessmentTestResult.Ldl != null && myBioCheckAssessmentTestResult.Ldl.Reading != null) {
            if (myBioCheckAssessmentTestResult.Ldl.Finding == null || myBioCheckAssessmentTestResult.Ldl.Finding == "") {
                text += "Ldl Findings are not marked.<br/>";
            }
        }

        if (myBioCheckAssessmentTestResult.TcHdlRatio != null && myBioCheckAssessmentTestResult.TcHdlRatio.Reading != null) {
            if (myBioCheckAssessmentTestResult.TcHdlRatio.Finding == null || myBioCheckAssessmentTestResult.TcHdlRatio.Finding == "") {
                text += "TcHdlRatio Findings are not marked.<br/>";
            }
        }
    }
    

    if (text != "")
        text = "My Bio-Check Assessment Test - <br/>" + text;
    return text;
}