<%@ Page Title="Edit Results" Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master"
    AutoEventWireup="true" CodeBehind="EditResult.aspx.cs" Inherits="Falcon.App.UI.App.Common.EditResult" %>
<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.Core.Application.Extension" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>
<%@ Register Src="~/Config/Content/Controls/Results/ViewableResult.ascx" TagName="ViewableResult" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript" src="/App/JavascriptFiles/PostAuditEvaluation.js?q=<%= VersionNumber %>"></script>
    <uc:viewableresult runat="server" id="ViewableResult" />
    <div class="left save-button-container" id="savebuttoncontainer" style="width: 100%;
        clear: both; display: none; text-align: right; margin-bottom: 10px;">
        <input type="button" id="cancelevaluation" value="Close" onclick="successFunction();" />
        <input type="button" id="saveandsendtophysician" value="Save And Send to Physician" onclick="SaveTestResultData(false, true); return false;" />
    </div>
    <div id="divSaveWaitAnimation" class="saveWaitAnimation save-button-container contentrow"
        style="display: none;">
    </div>
    <div id="testnotperformedvalidationdiv" style="display: none;" class="jdbox-validations">
        <div class="jdbox-validation-message" id="testnotperformedvalidationmessagediv">
        </div>
        <div class="jdbox-validation-button">
            <div class="rgt">
                <input type="button" id="btncancel" class="button" value="Stay Back & Complete" onclick='$("#testnotperformedvalidationdiv").dialog("close");' />
            </div>
        </div>
    </div>

    <script language="javascript" type="text/javascript">
        var isNextCustomer = false;
        
        function SaveTestResultData(doPostAudit, doReque) {
            
            if (TestNotPerformedValidation() == false) return;
            PostAuditEvaluatoin.SetRevertStatus(doPostAudit, false, false, doReque, "");
            $(".save-button-container").toggle();

            var osteoTestResult = $(".osteoDiv:visible").length > 0 ? GetOsteoData() : null;
            var spiroTestResult = $(".spiroDiv:visible").length > 0 ? GetSpiroData() : null;
            var strokeTestResult = $(".strokeDiv:visible").length > 0 ? GetStrokeData() : null;
            var awvCarotidTestResult = $(".awvCarotidDiv:visible").length > 0 ? GetAwvCarotidData() : null;
            var leadTestResult = $(".leadDiv:visible").length > 0 ? GetLeadData() : null;
            var aaaTestResult = $(".aaaDiv:visible").length > 0 ? GetAAAData() : null;
            var awvAaaTestResult = $(".AwvAaaDiv:visible").length > 0 ? GetAwvAaaData() : null;
            var asiTestResult = $(".asiDiv:visible").length > 0 ? GetAsiData() : null;
            var padTestResult = $(".padDiv:visible").length > 0 ? GetPadData() : null;
            var awvAbiTestResult = $(".AwvAbiDiv:visible").length > 0 ? GetAwvAbiData() : null;
            var echoTestResult = $(".echoDiv:visible").length > 0 ? GetEchoData() : null;

            var ekgTestResults = $(".ekgDiv:visible").length > 0 ? GetEKGData() : null;
            var lipidTestResults = $(".lipidDiv:visible").length > 0 ? GetLipidData() : null;
            var awvLipidTestResults = $(".awvLipidDiv:visible").length > 0 ? GetAwvLipidData() : null;
            var cholesterolTestResults = $(".CholesterolDiv:visible").length > 0 ? GetCholesterolData() : null;
            var diabetesTestResults = $(".DiabetesDiv:visible").length > 0 ? GetDiabetesData() : null;
            var liverTestResults = $(".liverDiv:visible").length > 0 ? GetLiverData() : null;
            var framinghamRiskTestResults = $(".framinghamRiskDiv:visible").length > 0 ? GetFraminghamRiskData() : null;
            var imtTestResult = $(".imtDiv:visible").length > 0 ? GetImtData() : null;
            var thyroidTestResult = $(".thyroidDiv:visible").length > 0 ? GetThyroidData() : null;
            var pulmonaryTestResult = $(".pulmonaryDiv:visible").length > 0 ? GetPulmonaryData() : null;
            var a1cTestResult = $(".a1cDiv:visible").length > 0 ? GetA1cData() : null;
            var PsaTestResult = $(".PsaDiv:visible").length > 0 ? GetPsaData() : null;
            var MenBloodPanelTestResult = $(".MenBloodPanelDiv:visible").length > 0 ? GetMenBloodPanelData() : null;
            var WomenBloodPanelTestResult = $(".WomenBloodPanelDiv:visible").length > 0 ? GetWomenBloodPanelData() : null;
            var VitaminDTestResult = $(".VitaminDDiv:visible").length > 0 ? GetVitaminDData() : null;
            var HypertensionTestResult = $(".HypertensionDiv:visible").length > 0 ? GetHypertensionData() : null;
            var CrpTestResult = $(".CrpDiv:visible").length > 0 ? GetCrpData() : null;
            var ColorectalTestResult = $(".ColorectalDiv:visible").length > 0 ? GetColorectalData() : null;
            
            var awvBoneMass = $(".awvBoneMassDiv:visible").length > 0 ? GetAwvBoneMassData() : null;
            var awvEkg = $(".awvEkgDiv:visible").length > 0 ? GetAwvEkgData() : null;
            var awvEkgIPPE = $(".awvEkgIPPEDiv:visible").length > 0 ? GetAwvEkgIPPEData() : null;
            var awvSpiro = $(".awvSpiroDiv:visible").length > 0 ? GetAwvSpiroData() : null;
            var awvHBA1C = $(".awvHemaglobinDiv:visible").length > 0 ? GetAwvHemaglobinData() : null;
            var awvGlucose = $(".awvGlucoseDiv:visible").length > 0 ? GetAwvGlucoseData() : null;
            
            var KynTestResult = $(".KynDiv:visible").length > 0 ? GetKynData() : null;
            var HkynTestResult = $(".HkynDiv:visible").length > 0 ? GetKynData() : null;
            var TestosteroneTestResult = $(".TestosteroneDiv:visible").length > 0 ? GetTestosteroneData() : null;
            
            var PpaaaTestResult = $(".PpaaaDiv:visible").length > 0 ? GetPpAAAData() : null;
            var PpechoTestResult = $(".PpechoDiv:visible").length > 0 ? GetPpEchoData() : null;
            
            var awvTestResult = $(".AwvDiv:visible").length > 0 ? GetAwvData() : null;
            var medicareTestResult = $(".MedicareDiv:visible").length > 0 ? GetMedicareData() : null;
            var awvSubsequentResult = $(".AwvSubsequentDiv:visible").length > 0 ? GetAwvSubsequentData() : null;
            var hearingResult = $(".HearingDiv:visible").length > 0 ? GetHearingData() : null;
            var visionResult = $(".VisionDiv:visible").length > 0 ? GetVisionData() : null;
            var glaucomaResult = $(".GlaucomaDiv:visible").length > 0 ? GetGlaucomaData() : null;

            var HcpaaaTestResult = $(".HcpaaaDiv:visible").length > 0 ? GetHcpAAAData() : null;
            var HcpCarotidTestResult = $(".HcpCarotidDiv:visible").length > 0 ? GetHcpCarotidData() : null;
            var HcpEchoTestResult = $(".HcpEchoDiv:visible").length > 0 ? GetHcpEchoData() : null;
            var awvEchoTestResult = $(".awvEchoDiv:visible").length > 0 ? GetAwvEchoData() : null;
            var hPylori = $(".HPyloriDiv:visible").length > 0 ? GetHPyloriData() : null;
            var hemoglobinTestResult = $(".HemoglobinDiv:visible").length > 0 ? GetHemoglobinData() : null;
            var diabeticRetinopathyTestResult = $(".DiabeticRetinopathyDiv:visible").length > 0 ? GetDiabeticRetinopathyData() : null;
            var eawvTestResult = $(".EAWVDiv:visible").length > 0 ? GetEAWVData() : null;
            var diabetesFootExamTestResult = $(".DiabetesFootExamDiv:visible").length > 0 ? GetDiabetesFootExamData() : null;
            var rinneWeberHearingTestResult = $(".RinneWeberHearingDiv:visible").length > 0 ? GetRinneWeberHearingData() : null;
            var monofilamentTestResult = $(".MonofilamentDiv:visible").length > 0 ? GetMonofilamentData() : null;
            var diabeticNeuropathyTestResult = $(".DiabeticNeuropathyDiv:visible").length > 0 ? GetDiabeticNeuropathyData() : null;
            var floChecABITestResult = $(".FloChecABI:visible").length > 0 ? GetFloChecABIData() : null;
            var iFOBT = $(".IFOBTDiv:visible").length > 0 ? GetIFOBTData() : null;
            var qualityMeasuresTestResult = $(".QualityMeasuresDiv:visible").length > 0 ? GetQualityMeasuresData() : null;
            var phq9TestResult = $(".phq9Div:visible").length > 0 ? GetPhq9Data() : null;
            var focAttestationTestResult = $(".focAttestation:visible").length > 0 ? GetFocAttestationData() : null;
            var mammogramTestResult = $(".mammogramDiv:visible").length > 0 ? GetMammogramData() : null;
            var urineMicroalbuminTestResult = $(".UrineMicroalbuminDiv:visible").length > 0 ? GetUrineMicroalbuminData() : null;
            var fluShotTestResult = $(".fluShotDiv:visible").length > 0 ? GetFluShotData() : null;
            var awvFluShotTestResult = $(".awvFluShotDiv:visible").length > 0 ? GetAwvFluShotData() : null;
            var pneumococcalTestResult = $(".PneumococcalDiv:visible").length > 0 ? GetPneumococcalData() : null;
            var chlamydiaTestResult = $(".chlamydiaDiv:visible").length > 0 ? GetChlamydiaData() : null;
            var quantaFloABITestResult = $(".QuantaFloABIDiv:visible").length > 0 ? GetQuantaFloABIData() : null;
            var dpnTestResult = $(".DpnDiv:visible").length > 0 ? GetDpnData() : null;
            var mybioCheckTestResult = $(".myBioCheckAssessmentDiv:visible").length > 0 ? GetMyBioCheckAssessmentData() : null;
            var focTestResult = $(".focDiv:visible").length > 0 ? GetFocData() : null;
            var csTestResult = $(".csDiv:visible").length > 0 ? GetCsData() : null;
            var qvTestResult = $(".qvDiv:visible").length > 0 ? GetQvData() : null;
            // debugger;
            var newTestArray = new Array();
            if (echoTestResult != null) {
                newTestArray.push(correctObject(echoTestResult));
            }

            if (ColorectalTestResult != null) {
                newTestArray.push(correctObject(ColorectalTestResult));
            }
            
            if (awvBoneMass != null) {
                newTestArray.push(correctObject(awvBoneMass));
            }
            
            if (awvEkg != null) {
                newTestArray.push(correctObject(awvEkg));
            }
            
            if (awvEkgIPPE != null) {
                newTestArray.push(correctObject(awvEkgIPPE));
            }
            
            if (awvSpiro != null) {
                newTestArray.push(correctObject(awvSpiro));
            }
           
            if (awvHBA1C != null) {
                newTestArray.push(correctObject(awvHBA1C));
            }
            
            if (awvGlucose != null) {
                newTestArray.push(correctObject(awvGlucose));
            }

            if (KynTestResult != null) {
                newTestArray.push(correctObject(KynTestResult));
            }
            
            if (HkynTestResult != null) {
                newTestArray.push(correctObject(HkynTestResult));
            }

            if (PsaTestResult != null) {
                newTestArray.push(correctObject(PsaTestResult));
            }
            if (MenBloodPanelTestResult != null) {
                newTestArray.push(correctObject(MenBloodPanelTestResult));
            }

            if (WomenBloodPanelTestResult != null) {
                newTestArray.push(correctObject(WomenBloodPanelTestResult));
            }

            if (VitaminDTestResult != null) {
                newTestArray.push(correctObject(VitaminDTestResult));
            }
            if (HypertensionTestResult != null) {
                newTestArray.push(correctObject(HypertensionTestResult));
            }
            
            if (CrpTestResult != null) {
                newTestArray.push(correctObject(CrpTestResult));
            }

            if (a1cTestResult != null) {
                newTestArray.push(correctObject(a1cTestResult));
            }

            if (ekgTestResults != null) {
                newTestArray.push(correctObject(ekgTestResults));
            }

            if (lipidTestResults != null) {
                newTestArray.push(correctObject(lipidTestResults));
            }
            
            if (awvLipidTestResults != null) {
                newTestArray.push(correctObject(awvLipidTestResults));
            }
            
            if (cholesterolTestResults != null) {
                newTestArray.push(correctObject(cholesterolTestResults));
            }
            
            if (diabetesTestResults != null) {
                newTestArray.push(correctObject(diabetesTestResults));
            }

            if (liverTestResults != null) {
                newTestArray.push(correctObject(liverTestResults));
            }

            if (framinghamRiskTestResults != null) {
                newTestArray.push(correctObject(framinghamRiskTestResults));
            }

            if (aaaTestResult != null) {
                newTestArray.push(correctObject(aaaTestResult));
            }
            
            if (awvAaaTestResult != null) {
                newTestArray.push(correctObject(awvAaaTestResult));
            }

            if (strokeTestResult != null) {
                newTestArray.push(correctObject(strokeTestResult));
            }
            
            if (awvCarotidTestResult != null) {
                newTestArray.push(correctObject(awvCarotidTestResult));
            }
            
            if (leadTestResult != null) {
                newTestArray.push(correctObject(leadTestResult));
            }

            if (padTestResult != null) {
                newTestArray.push(correctObject(padTestResult));
            }
            
            if (awvAbiTestResult != null) {
                newTestArray.push(correctObject(awvAbiTestResult));
            }

            if (asiTestResult != null) {
                newTestArray.push(correctObject(asiTestResult));
            }

            if (osteoTestResult != null) {
                newTestArray.push(correctObject(osteoTestResult));
            }

            if (spiroTestResult != null) {
                newTestArray.push(correctObject(spiroTestResult));
            }

            if (imtTestResult != null) {
                newTestArray.push(correctObject(imtTestResult));
            }

            if (pulmonaryTestResult != null) {
                newTestArray.push(correctObject(pulmonaryTestResult));
            }

            if (thyroidTestResult != null) {
                newTestArray.push(correctObject(thyroidTestResult));
            }
            
            if (TestosteroneTestResult != null) {
                newTestArray.push(correctObject(TestosteroneTestResult));
            }
            
            if (PpaaaTestResult != null) {
                newTestArray.push(correctObject(PpaaaTestResult));
            }

            if (PpechoTestResult != null) {
                newTestArray.push(correctObject(PpechoTestResult));
            }
            
            if (awvTestResult != null) {
                newTestArray.push(correctObject(awvTestResult));
            }
            
            if (medicareTestResult != null) {
                newTestArray.push(correctObject(medicareTestResult));
            }

            if (awvSubsequentResult != null) {
                newTestArray.push(correctObject(awvSubsequentResult));
            }

            if (hearingResult != null) {
                newTestArray.push(correctObject(hearingResult));
            }

            if (visionResult != null) {
                newTestArray.push(correctObject(visionResult));
            }

            if (glaucomaResult != null) {
                newTestArray.push(correctObject(glaucomaResult));
            }

            if (HcpaaaTestResult != null) {
                newTestArray.push(correctObject(HcpaaaTestResult));
            }

            if (HcpCarotidTestResult != null) {
                newTestArray.push(correctObject(HcpCarotidTestResult));
            }

            if (HcpEchoTestResult != null) {
                newTestArray.push(correctObject(HcpEchoTestResult));
            }

            if (awvEchoTestResult != null) {
                newTestArray.push(correctObject(awvEchoTestResult));
            }

            if (hPylori != null) {
                newTestArray.push(correctObject(hPylori));
            }

            if (iFOBT != null) {
                newTestArray.push(correctObject(iFOBT));
            }

            if (hemoglobinTestResult != null) {
                newTestArray.push(correctObject(hemoglobinTestResult));
            }

            if (diabeticRetinopathyTestResult != null) {
                newTestArray.push(correctObject(diabeticRetinopathyTestResult));
            }

            if (eawvTestResult != null) {
                newTestArray.push(correctObject(eawvTestResult));
            }
            
            if (diabetesFootExamTestResult != null) {
                newTestArray.push(correctObject(diabetesFootExamTestResult));
            }
            
            if (rinneWeberHearingTestResult != null) {
                newTestArray.push(correctObject(rinneWeberHearingTestResult));
            }
            if (monofilamentTestResult != null) {
                newTestArray.push(correctObject(monofilamentTestResult));
            }
            
            if (diabeticNeuropathyTestResult != null) {
                newTestArray.push(correctObject(diabeticNeuropathyTestResult));
            }
            if (floChecABITestResult != null) {
                newTestArray.push(correctObject(floChecABITestResult));
            }
            if (qualityMeasuresTestResult != null) {
                newTestArray.push(correctObject(qualityMeasuresTestResult));
            }
            
            if (phq9TestResult != null) {
                newTestArray.push(correctObject(phq9TestResult));
            }
            
            if (focAttestationTestResult != null) {
                newTestArray.push(correctObject(focAttestationTestResult));
            }

            if (mammogramTestResult != null) {
                newTestArray.push(correctObject(mammogramTestResult));
            }
            if (urineMicroalbuminTestResult != null) {
                newTestArray.push(correctObject(urineMicroalbuminTestResult));
            }
            
            if (fluShotTestResult != null) {
                newTestArray.push(correctObject(fluShotTestResult));
            }
            
            if (awvFluShotTestResult != null) {
                newTestArray.push(correctObject(awvFluShotTestResult));
            }
            
            if (pneumococcalTestResult != null) {
                newTestArray.push(correctObject(pneumococcalTestResult));
            }

            if (chlamydiaTestResult != null) {
                newTestArray.push(correctObject(chlamydiaTestResult));
            }
            
            if (quantaFloABITestResult != null) {
                newTestArray.push(correctObject(quantaFloABITestResult));
            }

            if (dpnTestResult != null) {
                newTestArray.push(correctObject(dpnTestResult));
            }
            
            if (mybioCheckTestResult != null) {
                newTestArray.push(correctObject(mybioCheckTestResult));
            }

            if (focTestResult != null) {
                newTestArray.push(correctObject(focTestResult));
            } 
            
            if (csTestResult != null) {
                newTestArray.push(correctObject(csTestResult));
            } 
            if (qvTestResult != null) {
                newTestArray.push(correctObject(qvTestResult));
            } 
            
            PostAuditEvaluatoin.SetCustomerEventId(customerId, eventId, newTestArray);
            var model = PostAuditEvaluatoin.get();
            //var isPennedBack = false;
            //var isNewResultflow = $("#IsNewResultFlowInputHidden").val();
            var messageUrl = '<%= ResolveUrl("~/App/Controllers/ManualEntryAndAuditController.asmx/SetAllResultsforPostEvaluationEdit") %>';
            //var parameter = "{'customerId' : '" + customerId + "', 'eventId' : '" + eventId + "', 'testResultStrings' : " + JSON.stringify(newTestArray) + ", 'doPostAudit': '" + doPostAudit + "', 'doReque' : '" + doReque + "', 'organizationRoleUserId' : '" + currentUser + "', 'isNewResultflow' : '" + isNewResultflow + "', 'isPennedBack' : '" + isPennedBack + "'}";
            var parameter = "{'model' : " + JSON.stringify(model) + "}";
            InvokeService(messageUrl, parameter, successFunction);
        }
        
        function correctObject(obj) {
            obj.TechnicianNotes = obj.TechnicianNotes.replace(/\?\?+/gi, "?");
            if (obj.PhysicianInterpretation != null)
                obj.PhysicianInterpretation.Remarks = obj.PhysicianInterpretation.Remarks.replace(/\?\?+/gi, "?");;
            return JSON.stringify(obj);
        }

        function successFunction() {
            window.location = "/Medical/Results/ResultStatusList?EventId=" + eventId;
        }

        function onFailure() {
            alert("OOPS! Some error occured.");
            window.location = "/Medical/Results/ResultStatusList?EventId=" + eventId;
        }
        
        function CheckIfPageLoaded() {

            if (dataLoaded() == true) {
                $("#savebuttoncontainer").show();
                window.clearInterval(id);
            }
        }
        var id = 0;
        $(document).ready(function () {
            id = window.setInterval("CheckIfPageLoaded()", 500);
            setSectionforCorrectionPostEvaluation();
            
            $("#testnotperformedvalidationdiv").dialog({ width: 590, autoOpen: false, title: 'Test Not Performed Validations', resizable: false, draggable: true, modal: true });
            $('#testnotperformedvalidationdiv').bind('dialogclose', onCloseTestNotPerformedDiv);

            var parameter = "{'customerId':'" + customerId + "'";
            parameter += ",'eventId':'" + eventId + "','urlPath':'<%= Request.Url.AbsolutePath %>'}";
            var messageUrl = '<%= ResolveUrl("~/App/Controllers/ManualEntryAndAuditController.asmx/GetRetestData") %>';
            InvokeService(messageUrl, parameter, setRetestCheckbox);
        });

        function onCloseTestNotPerformedDiv() {
            $(".save-button-container").toggle();
        }
    </script>
    <script type="text/javascript">
        function TestNotPerformedValidation() {
            var patientRefused = <%=(long)TestNotPerformedReasonType.PatientRefused %>;
            var contraindication = <%= (long)TestNotPerformedReasonType.Contraindication %>;
            var equipmentMalfunction = <%=(long)TestNotPerformedReasonType.EquipmentMalfunction %>;
            var testPreviouslyPerformed = <%=(long)TestNotPerformedReasonType.TestPreviouslyPerformedThisYear %>;
            
            var isAllTestNotPerformedDataProvided = true;
            var isReasonIdProvided = true;
            var isNotesProvided = true;

            $(".test-not-performed-container:visible").each(function () {
                var reasonId = Number($(this).find("select").val());
                var reasonNotes = $(this).find("textarea").val();
                if (reasonId <= 0 && isReasonIdProvided) {
                    isAllTestNotPerformedDataProvided = false;
                    isReasonIdProvided = false;
                }
                if ((reasonId === patientRefused || reasonId === contraindication || reasonId === equipmentMalfunction || reasonId === testPreviouslyPerformed ) && reasonNotes === '' && isNotesProvided) {
                    isAllTestNotPerformedDataProvided = false;
                    isNotesProvided = false;
                }
            });

            if (isAllTestNotPerformedDataProvided === false) {
                var validationMessage = '';
                if (isReasonIdProvided === false) {
                    validationMessage = validationMessage + '<li> Test Not Performed Reason is missing for few test. This is mandatory to mark for all the tests marked as "Test Not Performed". ';
                }
                if (isNotesProvided === false) {
                    validationMessage = validationMessage + '<li> If you have selected test not performed reason as "<%= TestNotPerformedReasonType.PatientRefused.GetDescription() %>" or "<%= TestNotPerformedReasonType.Contraindication.GetDescription() %>" or "<%= TestNotPerformedReasonType.EquipmentMalfunction.GetDescription() %>" or "<%= TestNotPerformedReasonType.TestPreviouslyPerformedThisYear.GetDescription() %>"  then it is mandatory to enter notes.';
                }

                $("#testnotperformedvalidationmessagediv").html("<ul> " + validationMessage + "</ul>");
                $(".save-button-container").toggle();
                $("#testnotperformedvalidationdiv").dialog("open");
            }
            
            return isAllTestNotPerformedDataProvided;
        }
    </script>
    
    <script type="text/javascript">
        function SetTestNotPerformedEnableDisabled(controlId) {
            var isAdminUser = '<%= IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.CheckRole((long)Falcon.App.Core.Enum.Roles.FranchisorAdmin) %>';
            var contraller = $("#" + controlId);
            var booleanFalse = '<%= Boolean.FalseString %>';
            var selectedValue = $(contraller).find("select :selected").val();
            var testNotReadable = '<%= (long) TestNotPerformedReasonType.TestUnreadable %>';
            if (selectedValue === testNotReadable && isAdminUser === booleanFalse ) {
                //$(contraller).find("input").attr("disabled", true);
                $(contraller).find("select,input,textArea").attr("disabled", true);
            } else if(isAdminUser === booleanFalse) {
                $(contraller).find("select option").each(function() {
                    if ($(this).val() === testNotReadable) {
                        $(this).hide();
                    }
                });
            }
        }

        function setRetestCheckbox(entity) {
            if (entity != null && entity.d != null) {
                $.each(entity.d, function (index, testId) {
                    $("#Retest_" + testId).attr("checked", true);
                });
            }
        }
    </script>    
</asp:Content>
