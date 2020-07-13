<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master"
    Title="Post Audit" AutoEventWireup="true" CodeBehind="PostAudit.aspx.cs" Inherits="Falcon.App.UI.App.Common.PostAudit" %>

<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.Core.Application.Extension" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>
<%@ Import Namespace="Falcon.App.Core.Users.Enum" %>

<%@ Register Src="~/Config/Content/Controls/Results/ViewableResult.ascx" TagName="ViewableResult" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #bloodTestValidationMessage {
            padding-left: 15px;
        }

            #bloodTestValidationMessage ul li {
                padding-left: 0px;
            }

        .jdbox-validation-message {
            float: left;
            width: 540px;
            margin-top: 5px;
            padding-left: 10px;
            padding-right: 10px;
            min-height: 70px;
        }

        .rollover-menu {
            margin: 0;
            padding: 0;
        }

            .rollover-menu li {
                list-style: none;
                font-weight: bold;
                overflow: visible;
            }

                .rollover-menu li a {
                    display: block;
                    padding: 3px 15px 3px 3px;
                    white-space: nowrap;
                    background: url('/Content/Images/Icons/navlist_arrow_down.png') no-repeat 52px 6px;
                }

                .rollover-menu li ul {
                    margin: 0;
                    padding: 0;
                    position: absolute;
                    visibility: hidden;
                    border: 1px solid #ababab;
                }

                    .rollover-menu li ul li {
                        float: none;
                        margin: 0px;
                        padding: 0px;
                        overflow: visible;
                        border-bottom: 1px solid #ababab;
                    }

                        .rollover-menu li ul li a {
                            display: block;
                            padding: 8px 10px 8px 25px;
                            background: #ffffff url('/Content/Images/arrow-bulletbig.gif') no-repeat 5px 7px;
                            color: #000;
                            text-decoration: none;
                            font-weight: bold;
                        }

            .rollover-menu:hover ul {
                visibility: visible;
            }
    </style>

    <style type="text/css">
          .dropup-menu {
            margin: 0;
            padding: 0;
        }

            .dropup-menu li {
                list-style: none;
                font-weight: bold;
                overflow: visible;
            }

                .dropup-menu li a {
                    display: block;
                    padding: 3px 15px 3px 3px;
                    white-space: nowrap;
                    background: url('/Content/Images/Icons/navlist_arrow_down.png') no-repeat 52px 6px;
                }

                .dropup-menu li ul {
                    margin: 0;
                    padding: 0;
                    position: absolute;
                    visibility: hidden;
                    border: 1px solid #ababab;
                    bottom: 25px;
                    z-index: 1;
                    left: 12px;
                }

                    .dropup-menu li ul li {
                        float: none;
                        margin: 0px;
                        padding: 0px;
                        overflow: visible;
                        border-bottom: 1px solid #ababab;
                    }

                        .dropup-menu li ul li a {
                            display: block;
                            padding: 8px 10px 8px 25px;
                            background: #ffffff url('/Content/Images/arrow-bulletbig.gif') no-repeat 5px 7px;
                            color: #000;
                            text-decoration: none;
                            font-weight: bold;
                        }

            .dropup-menu:hover ul {
                visibility: visible;
            }


    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript" type="text/javascript" src="/App/JavascriptFiles/PostAuditEvaluation.js?q=<%= VersionNumber %>"></script>
    <script language="javascript" type="text/javascript">

        $(document).ready(function () { currentScreenMode = ScreenMode.PostAudit; });

    </script>
    <div style="text-align: right; margin-bottom: 10px;float: right;padding-right: 12px">
         <div style="float: left;margin-top: 5px;">
            <input type="button" id="cancelevaluation" value="Close" onclick="successFunction();" />
     </div>
    <div id="actionLinkContainer" style="float: left;" class="save-button-container">
        <ul class="rollover-menu" style="float: right; width: 80px; z-index: 10000; text-align: left; margin-top: 5px;">
            <li>
                <a href="javascript:void(0);" style="font-size: 14px;">Action</a>
                <ul style="width: 165px;">
                    <li>
                        <a class="RevertToCoding" href="javascript:void(0);" onclick="RevertToCodingState(); return false;">Revert To Coding</a>
                    </li>
                    <li>
                        <a class="RevertToNPReview" href="javascript:void(0);" onclick="RevertToNPForReview(); return false;">Revert To Review (NP)</a>
                    </li>
                    <li>
                        <a class="RevertToEvaluation" href="javascript:void(0);" onclick="RevertToPhysicianData(); return false;">Send Back To Physician</a>
                    </li>
                    <li>
                        <a class="RevertToPreAudit" href="javascript:void(0);" onclick="RevertToPreAuditState(); return false;">(Undo) Pre-Audit</a>
                    </li>
                     <li>
                        <a class="saveandnext" href="javascript:void(0);" onclick="SaveTestResultData(true); return false;">Audit And Next</a>
                    </li>
                     <li>
                        <a class="saveandclose" href="javascript:void(0);" onclick="SaveTestResultData(false); return false;">Audit And Save</a>
                    </li>
                     <li>
                        <a class="saveonly" href="javascript:void(0);" onclick="SaveAndCloseTestResultData(); return false;">Save And Close</a>
                    </li>
                </ul>
                
            </li>
        </ul>
    </div>
    </div>
   

    <uc:ViewableResult runat="server" ID="ViewableResult" />

     <div style="text-align: right; margin-bottom: 10px;float: right;padding-right: 12px">
         <div style="float: left;margin-top: 5px;">
            <input type="button" class="cancelevaluation" value="Close" onclick="successFunction();" />
     </div>
    <div id="actionLinkContainerbottom" style="float: left;" class="save-button-container">
        <ul class="dropup-menu" style="float: right; width: 80px; z-index: 1; text-align: left; margin-top: 0px; position:relative;">
            <li>
                <a href="javascript:void(0);" style="font-size: 14px;">Action</a>
                <ul style="width: 165px;">
                    <li>
                        <a class="RevertToCoding" href="javascript:void(0);" onclick="RevertToCodingState(); return false;">Revert To Coding</a>
                    </li>
                    <li>
                        <a class="RevertToNPReview" href="javascript:void(0);" onclick="RevertToNPForReview(); return false;">Revert To Review (NP)</a>
                    </li>
                    <li>
                        <a class="RevertToEvaluation" href="javascript:void(0);" onclick="RevertToPhysicianData(); return false;">Send Back To Physician</a>
                    </li>
                    <li>
                        <a class="RevertToPreAudit" href="javascript:void(0);" onclick="RevertToPreAuditState(); return false;">(Undo) Pre-Audit</a>
                    </li>
                     <li>
                        <a class="saveandnext" href="javascript:void(0);" onclick="SaveTestResultData(true); return false;">Audit And Next</a>
                    </li>
                     <li>
                        <a class="saveandclose" href="javascript:void(0);" onclick="SaveTestResultData(false); return false;">Audit And Save</a>
                    </li>
                     <li>
                        <a class="saveonly" href="javascript:void(0);" onclick="SaveAndCloseTestResultData(); return false;">Save And Close</a>
                    </li>
                </ul>
                
            </li>
        </ul>
    </div>
    </div>


    <div class="left save-button-container" id="savebuttoncontainer" style="width: 100%; clear: both; display: none;">
        <div id="MarkAsPennedBackDiv" runat="server" style="float: left; text-align: left; margin-left: 14px;" Visible="False">
            <input type="checkbox" id="MarkAsPennedBackCheckbox" runat="server" />&nbsp;<b>Mark as Penned Back</b>
        </div>
       <%-- <div style="text-align: right; margin-bottom: 10px;">
            <input type="button" id="cancelevaluation" value="Close" onclick="successFunction();" />
            <input type="button" id="saveandnext" value="Audit And Next" onclick="SaveTestResultData(true); return false;" />
            <input type="button" id="saveandclose" value="Audit And Save" onclick="SaveTestResultData(false); return false;" />
            <input type="button" id="saveonly" value="Save And Close" onclick="SaveAndCloseTestResultData(); return false;" />
        </div>--%>
    </div>
    <div id="divSaveWaitAnimation" class="saveWaitAnimation save-button-container contentrow"
        style="display: none;">
    </div>
    <div id="postAudit-validation-div" style="display: none;">
        <div id="bloodTestValidationMessage">
        </div>
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
    <div id="revertStateValidationdiv" style="display: none;" class="jdbox-validations">
        <div class="jdbox-validation-message" id="revertStateValidationdivmessagediv" style="padding: 10px;">
            <textarea rows="5" cols="75" id="revertMessage"></textarea>
            <input type="hidden" id="isRevertToCoding" value="false" />
            <input type="hidden" id="isRevertToNP" value="false" />
            <input type="hidden" id="isRevertToEvaluation" value="false" />
            <input type="hidden" id="isRevertToPreAudit" value="false" />
        </div>
        <div class="jdbox-validation-button">
            <div class="rgt">
                <input type="button" id="btncancel" class="button" value="Stay Back & Complete" onclick='$("#revertStateValidationdiv").dialog("close");' />
                <input type="button" id="btnOk" class="button" value="Revert Back" onclick='SendResultToBackStateAndSave();' />
            </div>
        </div>
    </div>

    <script language="javascript" type="text/javascript">
        var isNextCustomer = false;
        var validationString = "";
        
        

        $(function () {
            $("#postAudit-validation-div").dialog({
                modal: true,
                width: 380,
                autoOpen: false,
                title: 'Validations',
                resizable: false,
                draggable: true,
                buttons: {
                    Close: function () {
                        $(this).dialog("close");
                    }
                }
            });
            $("#testnotperformedvalidationdiv").dialog({ width: 590, autoOpen: false, title: 'Test Not Performed Validations', resizable: false, draggable: true, modal: true });
            //$('#testnotperformedvalidationdiv').bind('dialogclose', onCloseTestNotPerformedDiv);
        });

        function SaveTestResultData(toNavigatetoNextCustomer) {
          
            $(".save-button-container").toggle();
            ValidateBloodTest();

            if ($.trim(validationString).length > 0) {
                $("#bloodTestValidationMessage").html("<ul>" + validationString + "</ul>");
                $("#postAudit-validation-div").dialog("open");
                $(".save-button-container").toggle();
            }
            else if(TestNotPerformedValidation())
            {
                isNextCustomer = toNavigatetoNextCustomer;

                PostAuditEvaluatoin.IsPostAudit();
                //SaveTestResultPostAuditData(true, false);
                SaveTestResultPostAuditData();
                                                                                <%--var parameter = "{'eventId' : '" + eventId + "', 'customerId' : '" + customerId + "', 'orgRoleUserId' : '<%= IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId %>'}";
                InvokeServicewithErrorMethodName("/App/Controllers/ManualEntryAndAuditController.asmx/SaveNewTestResultsforPostAudit", parameter, successFunction, onFailure);
                --%>
            }
        }
        function SaveAndCloseTestResultData() {
            $(".save-button-container").toggle();
            ValidateBloodTest();

            if ($.trim(validationString).length > 0) {
                $("#bloodTestValidationMessage").html("<ul>" + validationString + "</ul>");
                $("#postAudit-validation-div").dialog("open");
                $(".save-button-container").toggle();
            }
            else if(TestNotPerformedValidation()){
                isNextCustomer = false;
                //SaveTestResultPostAuditData(false, false);
                //PostAuditEvaluatoin.SetRevertStatus(false, false, false, false,false, "");
                SaveTestResultPostAuditData();
            }
        }

        function successFunction() {
            if (!isNextCustomer)
                window.location = "/Medical/Results/ResultStatusList?EventId=" + eventId;
            else {
                if (nextCustomerId > 0)
                    window.location = "/App/Common/PostAudit.aspx?EventId=" + eventId + "&CustomerId=" + nextCustomerId;
                else {
                    alert("Reached at the end of list!");
                    window.location = "/Medical/Results/ResultStatusList?EventId=" + eventId;
                }
            }
        }

        function ValidateBloodTest() {
            validationString = "";
            if ($(".thyroidDiv:visible").length > 0) {
                ValidateBloodTestData("Thyroid", $(".thyroidDiv"), $("#tshScrtextbox"));
            }
            if ($(".CrpDiv:visible").length > 0) {
                ValidateBloodTestData("CRP", $(".CrpDiv"), $("#lcrptextbox"));
            }
            if ($(".PsaDiv:visible").length > 0) {
                ValidateBloodTestData("PSA", $(".PsaDiv"), $("#psaScrtextbox"));
            }
            if ($(".TestosteroneDiv:visible").length > 0) {
                ValidateBloodTestData("Testosterone", $(".TestosteroneDiv"), $("#testScretextbox"));
            }

            if ($(".MenBloodPanelDiv:visible").length > 0) {
                
                if ($("#menBloodPanelPSASCRSkipCheckBox").is(":checked") == false)
                    ValidateBloodTestData("PSA", $(".MenBloodPanelDiv"), $("#menBloodPanelPSASCRtextbox"));
                
                if ($("#menBloodPanelLCRPSkipCheckBox").is(":checked") == false)
                    ValidateBloodTestData("CRP", $(".MenBloodPanelDiv"), $("#menBloodPanelLCRPtextbox"));

                if ($("#menBloodPanelTESTSCRESkipCheckBox").is(":checked") == false)
                    ValidateBloodTestData("Testosterone", $(".MenBloodPanelDiv"), $("#menBloodPanelTESTSCREtextbox"));
            }
            
            if ($(".WomenBloodPanelDiv:visible").length > 0) {

                if ($("#WomenBloodPanelTSHSCRSkipCheckBox").is(":checked") == false)
                    ValidateBloodTestData("Thyroid", $(".WomenBloodPanelDiv"), $("#WomenBloodPanelTSHSCRtextbox"));

                if ($("#WomenBloodPanelLCRPSkipCheckBox").is(":checked") == false)
                    ValidateBloodTestData("CRP", $(".WomenBloodPanelDiv"), $("#WomenBloodPanelLCRPtextbox"));

                if ($("#WomenBloodPanelVitDSkipCheckBox").is(":checked") == false)
                    ValidateBloodTestData("VitaminD", $(".WomenBloodPanelDiv"), $("#WomenBloodPanelVitDtextbox"));
            }
            
            if ($(".VitaminDDiv:visible").length > 0) {
                ValidateBloodTestData("VitaminD", $(".VitaminDDiv"), $("#VitDtextbox"));
            }

        }

        function ValidateBloodTestData(testName, divCotainer, control) {

            if (divCotainer.find(".unable-to-screen-section").find("input[type='checkbox']:checked").length > 0)
                return true;

            if (control.val() != '')
                return true;

            validationString += "<li> Value is missing for " + testName + " test.</li>";

            return false;
        }

        function onFailure() {
            alert("OOPS! Some error occured.");
            window.location = "/Medical/Results/ResultStatusList?EventId=" + eventId;
        }


        function CheckIfPageLoaded() {

            if (dataLoaded() == true) {
                $("#savebuttoncontainer").show();
                $("#actionLinkContainer").show();
                $("#actionLinkContainerbottom").show();
                window.clearInterval(id);
                EnableBloodtests();
                EnableSpiroTest();
            }
        }

        var id = 0;
        $(document).ready(function () {
            id = window.setInterval("CheckIfPageLoaded()", 500);
            $(".clear-all-selection").hide();
            hideAll();
        });

        function EnableTests(containerDiv) {
            
            $(containerDiv).find("input").removeAttr("disabled");
            $(containerDiv).find("input:checkbox").not(".test-not-performed-section input:checkbox").attr("disabled", "disabled");
            
            $(containerDiv).find("select").removeAttr("disabled");
            $(containerDiv).find(".upload-media-section").show();
            $(containerDiv).find(".skip-checkbox").show();
            $(containerDiv).find(".test-section-header").find("input").attr("disabled", "disabled");
            $(containerDiv).find(".test-section-header").find("select").attr("disabled", "disabled");
            
            //$(containerDiv).find(".test-not-performed-section").find("select").attr("disabled", "disabled");
            //$(containerDiv).find(".test-not-performed-section").find("input").attr("disabled", "disabled");
        }

        function EnableBloodtests() {

            if ($(".thyroidDiv:visible").length > 0 ) {
                EnableTests($(".thyroidDiv"));
            }
            if ($(".CrpDiv:visible").length > 0) {
                EnableTests($(".CrpDiv"));
            }
            if ($(".PsaDiv:visible").length > 0) {
                EnableTests($(".PsaDiv"));
            }
            if ($(".TestosteroneDiv:visible").length > 0) {
                EnableTests($(".TestosteroneDiv"));
            }
            if ($(".MenBloodPanelDiv:visible").length > 0) {
                EnableTests($(".MenBloodPanelDiv"));
            }
            if ($(".WomenBloodPanelDiv:visible").length > 0) {
                EnableTests($(".WomenBloodPanelDiv"));
            }
            if ($(".VitaminDDiv:visible").length > 0) {
                EnableTests($(".VitaminDDiv"));
            }
            if ($(".DiabeticRetinopathyDiv:visible").length > 0) {
                EnableTests($(".DiabeticRetinopathyDiv"));
            }
            if ($(".EAWVDiv:visible").length > 0) {
                EnableTests($(".EAWVDiv"));
            }
            if ($(".mammogramDiv:visible").length > 0) {
                EnableTests($(".mammogramDiv"));
            }
            if ($(".DiabetesFootExamDiv:visible").length > 0) {
                EnableTests($(".DiabetesFootExamDiv"));
            }
            
            if ($(".DiabeticNeuropathyDiv:visible").length > 0) {
                EnableTests($(".DiabeticNeuropathyDiv"));
            }
            if ($(".focAttestation:visible").length > 0) {
                EnableTests($(".focAttestation"));
            }
            if ($(".IFOBTDiv:visible").length > 0) {
                EnableTests($(".IFOBTDiv"));
            }
            if ($(".UrineMicroalbuminDiv:visible").length > 0) {
                EnableTests($(".UrineMicroalbuminDiv"));
            }
            if ($(".FloChecABIDiv:visible").length > 0) {
                EnableTests($(".FloChecABIDiv"));
            }
            
            if ($(".MonofilamentDiv:visible").length > 0) {
                EnableTests($(".MonofilamentDiv"));
            }
            
            if ($(".fluShotDiv:visible").length > 0) {
                EnableTests($(".fluShotDiv"));
            }
            
            if ($(".awvFluShotDiv:visible").length > 0) {
                EnableTests($(".awvFluShotDiv"));
            }
            
            if ($(".PneumococcalDiv:visible").length > 0) {
                EnableTests($(".PneumococcalDiv"));
            }

            if ($(".chlamydiaDiv:visible").length > 0) {
                EnableTests($(".chlamydiaDiv"));
            }
            if ($(".QuantaFloABIDiv:visible").length > 0) {
                EnableTests($(".QuantaFloABIDiv"));
            }
            if ($(".DpnDiv:visible").length > 0) {
                EnableTests($(".DpnDiv"));
            }
            if ($(".myBioCheckAssessmentDiv:visible").length > 0) {
                EnableTests($(".myBioCheckAssessmentDiv"));
            }
            if ($(".focDiv:visible").length > 0) {
                EnableTests($(".focDiv"));
            }
            if ($(".csDiv:visible").length > 0) {
                EnableTests($(".csDiv"));
            }
            if ($(".qvDiv:visible").length > 0) {
                EnableTests($(".qvDiv"));
            }
        }

        function EnableSpiroTest()
        {
            if ($(".spiroDiv:visible").length > 0) {
                EnableTests($(".spiroDiv"));
            }
            if ($(".awvSpiroDiv:visible").length > 0) {
                EnableTests($(".awvSpiroDiv"));
            }
        }

    </script>
    <script type="text/javascript">
        function SaveTestResultPostAuditData() {

            
            var newTestArray = new Array();

            if ($(".osteoDiv:visible").length > 0) {
                var osteoTestResult = GetOsteoData();
                if (osteoTestResult != null) {
                    newTestArray.push(correctObject(osteoTestResult));
                }
            }
           
            if ($(".leadDiv:visible").length > 0) {
                var leadTestResult = GetLeadData();
                if (leadTestResult != null) {
                    newTestArray.push(correctObject(leadTestResult));
                }
            }

            if ($(".AwvAaaDiv:visible").length > 0) {

                var awvAaaTestResult = GetAwvAaaData();
                if (awvAaaTestResult != null) {
                    newTestArray.push(correctObject(awvAaaTestResult));
                }
            }

            if ($(".AwvAbiDiv:visible").length > 0) {
                var awvAbiTestResult = GetAwvAbiData();
                if (awvAbiTestResult != null) {
                    newTestArray.push(correctObject(awvAbiTestResult));
                }
            }

            if ($(".awvLipidDiv:visible").length > 0) {
                var awvLipidTestResults = GetAwvLipidData();
                if (awvLipidTestResults != null) {
                    newTestArray.push(correctObject(awvLipidTestResults));
                }
            }

            if ($(".imtDiv:visible").length > 0) {
                var imtTestResult = GetImtData();
                if (imtTestResult != null) {
                    newTestArray.push(correctObject(imtTestResult));
                }
            }

            if ($(".thyroidDiv:visible").length > 0) {
                var thyroidTestResult = GetThyroidData();
                if (thyroidTestResult != null) {
                    newTestArray.push(correctObject(thyroidTestResult));
                }
            }

            if ($(".pulmonaryDiv:visible").length > 0) {
                var pulmonaryTestResult = GetPulmonaryData();
                if (pulmonaryTestResult != null) {
                    newTestArray.push(correctObject(pulmonaryTestResult));
                }
            }

            if ($(".a1cDiv:visible").length > 0) {
                var a1cTestResult = GetA1cData();
                if (a1cTestResult != null) {
                    newTestArray.push(correctObject(a1cTestResult));
                }
            }

            if ($(".PsaDiv:visible").length > 0) {
                var PsaTestResult = GetPsaData();
                if (PsaTestResult != null) {
                    newTestArray.push(correctObject(PsaTestResult));
                }
            }
            if ($(".MenBloodPanelDiv:visible").length > 0) {
                var menBloodPanelTestResult = GetMenBloodPanelData();
                if (menBloodPanelTestResult != null) {
                    newTestArray.push(correctObject(menBloodPanelTestResult));
                }
            }
            if ($(".WomenBloodPanelDiv:visible").length > 0) {
                var womenBloodPanelTestResult = GetWomenBloodPanelData();
                if (womenBloodPanelTestResult != null) {
                    newTestArray.push(correctObject(womenBloodPanelTestResult));
                }
            }
            if ($(".VitaminDDiv:visible").length > 0) {
                var VitaminDTestResult = GetVitaminDData();
                if (VitaminDTestResult != null) {
                    newTestArray.push(correctObject(VitaminDTestResult));
                }
            }
            if ($(".HypertensionDiv:visible").length > 0) {
                var HypertensionTestResult = GetHypertensionData();
                if (HypertensionTestResult != null) {
                    newTestArray.push(correctObject(HypertensionTestResult));
                }
            }
            if ($(".CrpDiv:visible").length > 0) {
                var CrpTestResult = GetCrpData();
                if (CrpTestResult != null) {
                    newTestArray.push(correctObject(CrpTestResult));
                }
            }

           

            if ($(".awvBoneMassDiv:visible").length > 0) {
                var awvBoneMassTestResult = GetAwvBoneMassData();
                if (awvBoneMassTestResult != null) {
                    newTestArray.push(correctObject(awvBoneMassTestResult));
                }
            }

            if ($(".awvEkgDiv:visible").length > 0) {
                var awvEkgTestResult = GetAwvEkgData();
                if (awvEkgTestResult != null) {
                    newTestArray.push(correctObject(awvEkgTestResult));
                }
            }
            if ($(".awvEkgIPPEDiv:visible").length > 0) {
                var awvEkgIppeTestResult = GetAwvEkgIPPEData();
                if (awvEkgIppeTestResult != null) {
                    newTestArray.push(correctObject(awvEkgIppeTestResult));
                }
            }
            if ($(".awvSpiroDiv:visible").length > 0) {
                var awvSpiroTestResult = GetAwvSpiroData();
                if (awvSpiroTestResult != null) {
                    newTestArray.push(correctObject(awvSpiroTestResult));
                }
            }
            if ($(".awvHemaglobinDiv:visible").length > 0) {
                var awvHemaglobinDivTestResult = GetAwvHemaglobinData();
                if (awvHemaglobinDivTestResult != null) {
                    newTestArray.push(correctObject(awvHemaglobinDivTestResult));
                }
            }
            if ($(".awvGlucoseDiv:visible").length > 0) {
                var awvGlucoseDivTestResult = GetAwvGlucoseData();
                if (awvGlucoseDivTestResult != null) {
                    newTestArray.push(correctObject(awvGlucoseDivTestResult));
                }
            }


            if ($(".TestosteroneDiv:visible").length > 0) {
                var TestosteroneTestResult = GetTestosteroneData();
                if (TestosteroneTestResult != null) {
                    newTestArray.push(correctObject(TestosteroneTestResult));
                }
            }

           
            if ($(".HearingDiv:visible").length > 0) {
                var hearingTestResult = GetHearingData();
                if (hearingTestResult != null) {
                    newTestArray.push(correctObject(hearingTestResult));
                }
            }
            if ($(".VisionDiv:visible").length > 0) {
                var visionTestResult = GetVisionData();
                if (visionTestResult != null) {
                    newTestArray.push(correctObject(visionTestResult));
                }
            }
           

            if ($(".HcpaaaDiv:visible").length > 0) {
                var HcpaaaTestResult = GetHcpAAAData();
                if (HcpaaaTestResult != null) {
                    newTestArray.push(correctObject(HcpaaaTestResult));
                }
            }

            if ($(".HcpCarotidDiv:visible").length > 0) {
                var hcpCarotidTestResult = GetHcpCarotidData();
                if (hcpCarotidTestResult != null) {
                    newTestArray.push(correctObject(hcpCarotidTestResult));
                }
            }

            if ($(".HcpEchoDiv:visible").length > 0) {
                var HcpEchoTestResult = GetHcpEchoData();
                if (HcpEchoTestResult != null) {
                    newTestArray.push(correctObject(HcpEchoTestResult));
                }
            }
            if ($(".awvEchoDiv:visible").length > 0) {
                var awvEchoTestResult = GetAwvEchoData();
                if (awvEchoTestResult != null) {
                    newTestArray.push(correctObject(awvEchoTestResult));
                }
            }
            if ($(".HemoglobinDiv:visible").length > 0) {
                var hemoglobinTestResult = GetHemoglobinData();
                if (hemoglobinTestResult != null) {
                    newTestArray.push(correctObject(hemoglobinTestResult));
                }
            }
            if ($(".DiabeticRetinopathyDiv:visible").length > 0) {
                var diabeticRetinopathyTestResult = GetDiabeticRetinopathyData();
                if (diabeticRetinopathyTestResult != null) {
                    newTestArray.push(correctObject(diabeticRetinopathyTestResult));
                }
            }
            if ($(".EAWVDiv:visible").length > 0) {
                var eawvTestResult = GetEAWVData();
                if (eawvTestResult != null) {
                    newTestArray.push(correctObject(eawvTestResult));
                }
            }

            if ($(".DiabetesFootExamDiv:visible").length > 0) {
                var diabetesFootExamTestResult = GetDiabetesFootExamData();
                if (diabetesFootExamTestResult != null) {
                    newTestArray.push(correctObject(diabetesFootExamTestResult));
                }
            }

           

            if ($(".MonofilamentDiv:visible").length > 0) {
                var monofilamentTestResult = GetMonofilamentData();
                if (monofilamentTestResult != null) {
                    newTestArray.push(correctObject(monofilamentTestResult));
                }
            }

            if ($(".DiabeticNeuropathyDiv:visible").length > 0) {
                var diabeticNeuropathyTestResult = GetDiabeticNeuropathyData();
                if (diabeticNeuropathyTestResult != null) {
                    newTestArray.push(correctObject(diabeticNeuropathyTestResult));
                }
            }

            if ($(".FloChecABIDiv:visible").length > 0) {
                var floChecABITestResult = GetFloChecABIData();
                if (floChecABITestResult != null) {
                    newTestArray.push(correctObject(floChecABITestResult));
                }
            }

            if ($(".IFOBTDiv:visible").length > 0) {
                var iFOBTTestResult = GetIFOBTData();
                if (iFOBTTestResult != null) {
                    newTestArray.push(correctObject(iFOBTTestResult));
                }
            }

            if ($(".QualityMeasuresDiv:visible").length > 0) {
                var qualityMeasuresTestResult = GetQualityMeasuresData();
                if (qualityMeasuresTestResult != null) {
                    newTestArray.push(correctObject(qualityMeasuresTestResult));
                }
            }

            if ($(".phq9Div:visible").length > 0) {
                var phq9TestResult = GetPhq9Data();
                if (phq9TestResult != null) {
                    newTestArray.push(correctObject(phq9TestResult));
                }
            }

            if ($(".focAttestation:visible").length > 0) {
                var focAttestationTestResult = GetFocAttestationData();
                if (focAttestationTestResult != null) {
                    newTestArray.push(correctObject(focAttestationTestResult));
                }
            }
            if ($(".mammogramDiv:visible").length > 0) {
                var mammogramTestResult = GetMammogramData();
                if (mammogramTestResult != null) {
                    newTestArray.push(correctObject(mammogramTestResult));
                }
            }
            if ($(".UrineMicroalbuminDiv:visible").length > 0) {
                var urineMicroalbuminTestResult = GetUrineMicroalbuminData();
                if (urineMicroalbuminTestResult != null) {
                    newTestArray.push(correctObject(urineMicroalbuminTestResult));
                }
            }

            if ($(".fluShotDiv:visible").length > 0) {
                var fluShotTestResult = GetFluShotData();
                if (fluShotTestResult != null) {
                    newTestArray.push(correctObject(fluShotTestResult));
                }
            }

            if ($(".awvFluShotDiv:visible").length > 0) {
                var awvFluShotTestResult = GetAwvFluShotData();
                if (awvFluShotTestResult != null) {
                    newTestArray.push(correctObject(awvFluShotTestResult));
                }
            }

            if ($(".PneumococcalDiv:visible").length > 0) {
                var pneumococcalTestResult = GetPneumococcalData();
                if (pneumococcalTestResult != null) {
                    newTestArray.push(correctObject(pneumococcalTestResult));
                }
            }
            if ($(".chlamydiaDiv:visible").length > 0) {
                var chlamydiaTestResult = GetChlamydiaData();
                if (chlamydiaTestResult != null) {
                    newTestArray.push(correctObject(chlamydiaTestResult));
                }
            }

            if ($(".QuantaFloABIDiv:visible").length > 0) {
                var quantaFloAbiTestResult = GetQuantaFloABIData();
                if (quantaFloAbiTestResult != null) {
                    newTestArray.push(correctObject(quantaFloAbiTestResult));
                }
            }

            if ($(".DpnDiv:visible").length > 0) {
                var dpnTestResult = GetDpnData();
                if (dpnTestResult != null) {
                    newTestArray.push(correctObject(dpnTestResult));
                }
            }
            

            if ($(".myBioCheckAssessmentDiv:visible").length > 0) {
                var myBioCheckAssessmentTestResults = GetMyBioCheckAssessmentData();
                if (myBioCheckAssessmentTestResults != null) {
                    newTestArray.push(correctObject(myBioCheckAssessmentTestResults));
                }
            }
          
            if ($(".spiroDiv:visible").length > 0) {
                var spiroTestResults = GetSpiroData();
                if (spiroTestResults != null) {
                    newTestArray.push(correctObject(spiroTestResults));
                }
            }

            if ($(".focDiv:visible").length > 0) {
                var focTestResults = GetFocData();
                if (focTestResults != null) {
                    newTestArray.push(correctObject(focTestResults));
                }
            }

            if ($(".csDiv:visible").length > 0) {
                var csTestResults = GetCsData();
                if (csTestResults != null) {
                    newTestArray.push(correctObject(csTestResults));
                }
            }

            if ($(".qvDiv:visible").length > 0) {
                var qvTestResults = GetQvData();
                if (qvTestResults != null) {
                    newTestArray.push(correctObject(qvTestResults));
                }
            }
            //var isPennedBack = $("input[id*='MarkAsPennedBackCheckbox']").is(":checked");
            //var isNewResultflow = $("#IsNewResultFlowInputHidden").val();
            PostAuditEvaluatoin.SetEventHraStatus(isHealthPlan, showHraQuestions, isEawvTestPurchased, isEawvTestNotPerformed);
            PostAuditEvaluatoin.SetCustomerEventId(customerId, eventId, newTestArray);
            var model = PostAuditEvaluatoin.get();
            var messageUrl = '<%= ResolveUrl("~/App/Controllers/ManualEntryAndAuditController.asmx/SetAllResultsforPostEvaluationEdit") %>';
            //var parameter = "{'customerId' : '" + customerId + "', 'eventId' : '" + eventId + "', 'testResultStrings' : " + JSON.stringify(newTestArray) + ", 'doPostAudit': '" + doPostAudit + "', 'doReque' : '" + doReque + "', 'organizationRoleUserId' : '" + '<%= IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId %>' + "', 'isNewResultflow' : '" + isNewResultflow + "', 'isPennedBack' : '" + isPennedBack + "', 'isRevertToCoding' : '" + isRevertToCoding + "', 'isRevertToNp' : '" + isRevertToNp + "', 'message' : '" + JSON.stringify(message) + "'}";
            var parameter = "{'model' : " + JSON.stringify(model) + "}";
            
            InvokeServicewithErrorMethodName(messageUrl, parameter, successFunction, onFailure);
        }

        function correctObject(obj) {
            obj.TechnicianNotes = obj.TechnicianNotes.replace(/\?\?+/gi, "?");
            if (obj.PhysicianInterpretation != null)
            {
                if(obj.PhysicianInterpretation.Remarks != null && obj.PhysicianInterpretation.Remarks != 'undefined')
                    obj.PhysicianInterpretation.Remarks = obj.PhysicianInterpretation.Remarks.replace(/\?\?+/gi, "?");;
            }
            
            return JSON.stringify(obj);
        }
        $(document).ready(function () {
            $(".test-not-performed-section").find("select").removeAttr("disabled");
            $(".test-not-performed-section").find("input").removeAttr("disabled");
            $(".test-not-performed-section").find("textarea").removeAttr("disabled");
        });
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
                if ((reasonId === patientRefused || reasonId === contraindication || reasonId === equipmentMalfunction || reasonId === testPreviouslyPerformed) && reasonNotes === '' && isNotesProvided) {
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
    </script>

    <script type="text/javascript">
        var isHealthPlan = '<%= IsHealthPlan.ToString() %>' == '<%=Boolean.TrueString %>';
        var containTestForEvaluation = '<%= ViewableResult.ContainTestForEvaluation.ToString() %>' == '<%=Boolean.TrueString %>';
        var showHraQuestions = '<%= ShowHraQuestions.ToString() %>' == '<%=Boolean.TrueString %>';
        var isEawvTestPurchased = '<%= IsEawvTestPurchased.ToString() %>' == '<%=Boolean.TrueString %>';
        
        var isEawvTestNotPerformed = '<%= IsEawvTestNotPerformed.ToString() %>' == '<%=Boolean.TrueString %>';
        var ischatQuestionnaire = '<%= QuestionnaireType %>' =='<%=QuestionnaireType.ChatQuestionnaire %>';
        $(document).ready(function() {
            //debugger;
            $("#revertStateValidationdiv").dialog({ width: 590, autoOpen: false, title: 'Revert message', resizable: false, draggable: true, modal: true });
            
            $(".RevertToNPReview").closest("li").hide();
            $(".RevertToCoding").closest("li").hide();
            $(".RevertToEvaluation").closest("li").hide();
            $(".RevertToPreAudit").closest("li").hide();

            var isNewResultFlow =Boolean.parse($("#IsNewResultFlowInputHidden").val());
            
            if (isNewResultFlow == true) {
                
                if (isHealthPlan && !isEawvTestNotPerformed) {
                    
                    if (ischatQuestionnaire === false && isAnyTestInHip === true) {
                        $(".RevertToCoding").closest("li").show();    
                    }
                                        
                    if (containTestForEvaluation) {
                        if (isEawvTestPurchased && showHraQuestions) {
                            $(".RevertToNPReview").closest("li").show();     
                        }
                       $(".RevertToEvaluation").closest("li").show();
                    } else {
                        $(".RevertToPreAudit").closest("li").show();
                    }
                } else {
                    if (containTestForEvaluation) {
                        $(".RevertToEvaluation").closest("li").show();   
                    } else {
                        $(".RevertToPreAudit").closest("li").show();
                    }
                }
            } 
            
        });
         
        //function onCloseRevertStateDiv() {
            
        //    $("#revertStateValidationdiv").find("#isRevertToCoding").val(false);
        //    $("#revertStateValidationdiv").find("#isRevertToNP").val(false);
        //    $("#revertStateValidationdiv").find("#isRevertToEvaluation").val(false);
        //    $("#revertStateValidationdiv").find("#isRevertToPreAudit").val(false);
            
        //    $("#revertStateValidationdiv").find("#revertMessage").val('');

        //    $(".save-button-container").toggle();
        //}
        
        function RevertToPhysicianData() {
            //$("#revertStateValidationdiv").find("#isRevertToCoding").val(false);
            //$("#revertStateValidationdiv").find("#isRevertToNP").val(false);
            //$("#revertStateValidationdiv").find("#isRevertToEvaluation").val(true);
            //$("#revertStateValidationdiv").find("#isRevertToPreAudit").val(false);
            
            $(".save-button-container").toggle();
             
            //$("#revertStateValidationdiv").dialog({
            //    title: 'Revert To Physician Review'
            //});
             
            //$("#revertStateValidationdiv").dialog("open");
            PostAuditEvaluatoin.SetDoReque();
            SaveTestResultPostAuditData();
        }
         
        function RevertToCodingState() {
            //$(".save-button-container").toggle();

            //$("#revertStateValidationdiv").find("#isRevertToCoding").val(true);
            //$("#revertStateValidationdiv").find("#isRevertToNP").val(false);
            //$("#revertStateValidationdiv").find("#isRevertToEvaluation").val(false);
            //$("#revertStateValidationdiv").find("#isRevertToPreAudit").val(false);
            
            //$("#revertStateValidationdiv").dialog({
            //    title: 'Revert To Coding Review'
            //});
             
             
            //$("#revertStateValidationdiv").dialog("open");
            $(".save-button-container").toggle();
            PostAuditEvaluatoin.SetRevertForCoding();
            SaveTestResultPostAuditData();
        }
         
        function RevertToNPForReview() {
            //$("#revertStateValidationdiv").find("#isRevertToCoding").val(false);
            //$("#revertStateValidationdiv").find("#isRevertToNP").val(true);
            //$("#revertStateValidationdiv").find("#isRevertToEvaluation").val(false);
            //$("#revertStateValidationdiv").find("#isRevertToPreAudit").val(false);
            
            //$(".save-button-container").toggle();
             
            //$("#revertStateValidationdiv").dialog({
            //    title: 'Revert To NP For Review'
            //});
             
            //$("#revertStateValidationdiv").dialog("open");
            $(".save-button-container").toggle();
            PostAuditEvaluatoin.SetRevertToNpForReview();
            SaveTestResultPostAuditData();
        }
         
       
        
        function RevertToPreAuditState() {
            //$("#revertStateValidationdiv").find("#isRevertToCoding").val(false);
            //$("#revertStateValidationdiv").find("#isRevertToNP").val(false);
            //$("#revertStateValidationdiv").find("#isRevertToEvaluation").val(false);
            //$("#revertStateValidationdiv").find("#isRevertToPreAudit").val(true);
            
            //$(".save-button-container").toggle();
             

            //$("#revertStateValidationdiv").dialog({
            //    title: '(Undo) PreAudit'
            //});

             
            //$("#revertStateValidationdiv").dialog("open");
            $(".save-button-container").toggle();
            PostAuditEvaluatoin.SetRevertToPreAudit();
            SaveTestResultPostAuditData();
        }
        
        function SendResultToBackStateAndSave() {
           
            //var isRevertToCoding =  $("#revertStateValidationdiv").find("#isRevertToCoding").val();
            //var isRevertToNp = $("#revertStateValidationdiv").find("#isRevertToNP").val();
            //var isRevertToEvaluation = $("#revertStateValidationdiv").find("#isRevertToEvaluation").val();
            //var isRevertToPreAudit=$("#revertStateValidationdiv").find("#isRevertToPreAudit").val();
            
            //var message = $("#revertStateValidationdiv").find("#revertMessage").val();
            //message = message.replace(/\?\?+/gi, "?");
            
            //PostAuditEvaluatoin.SetRevertStatus(false, isRevertToCoding,isRevertToNp,isRevertToEvaluation,isRevertToPreAudit,message);
            $(".save-button-container").toggle();
            SaveTestResultPostAuditData();
        }
        

    </script>


</asp:Content>
