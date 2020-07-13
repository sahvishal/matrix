<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewableResult.ascx.cs" Inherits="Falcon.App.UI.App.UCCommon.ViewableResult" %>
<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.Core.Application.Domain" %>
<%@ Import Namespace="Falcon.App.Core.Extensions" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<%@ Import Namespace="Falcon.App.Core.Users.Enum" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>
<%@ Register Src="~/Config/Content/Controls/Results/TestSectionContainer.ascx" TagName="_TestSection"
    TagPrefix="uc" %>
<%@ Register Src="~/Config/Content/Controls/Results/BasicBiometric.ascx"
    TagName="_BasicBiometric" TagPrefix="uc" %>
<%@ Register Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="_jQueryToolKit" TagPrefix="uc" %>
<%@ Register Src="~/App/UCCommon/Message.ascx" TagName="messages" TagPrefix="messagecontrol" %>
<uc:_jQueryToolKit ID="ucJquery" IncludeAjax="true" runat="server" IncudeJQueryJTip="true"
    IncludeJQueryUI="true" IncludeJQueryThickBox="true" />
<script language="javascript" type="text/javascript" src="/App/JavascriptFiles/JSonHelper.js?q=<%= VersionNumber %>"></script>
<script language="javascript" type="text/javascript" src="/App/JavascriptFiles/EditResult.js?q=<%= VersionNumber %>"></script>
<script language="javascript" type="text/javascript" src="/Config/Content/Javascript/SetScreen.js?q=<%= VersionNumber %>"></script>
<link href="/App/StyleSheets/ManualEntry.css" type="text/css" rel="Stylesheet" />
<script type="text/javascript" src="/Scripts/json2.min.js?q=<%= VersionNumber %>"></script>
<script type="text/javascript" src="/Scripts/flowplayer-3.2.6.js?q=<%= VersionNumber %>"></script>
<script type="text/javascript" src="/Scripts/Video/video.js?q=<%= VersionNumber %>"></script>
<link href="/Scripts/Video/video-js.css" rel="stylesheet" type="text/css" />
<style type="text/css">
    fieldset {
        border-color: #F37C00;
    }

        fieldset legend {
            font-weight: bold;
        }

    #results {
        position: absolute;
        float: left;
        display: none;
        background-color: #fff;
        height: 100px;
        overflow-y: auto;
        overflow-x: hidden;
        font-size: 11px;
        border: solid 1px #7F9DB9;
    }

    .searchresult {
        height: 20px;
        width: 200px;
        border-bottom: 1px solid #7F9DB9;
        vertical-align: top;
        background: #f5f5f5;
    }

    .small {
        font: normal 9px arial;
    }

    .searchresult:hover {
        background-color: #ddd;
        cursor: hand;
    }

    .match {
        background-color: Yellow;
    }

    .jdbox {
        float: left;
        width: 350px;
        margin-top: 5px;
    }

    .button {
        background: #5996b5;
        height: 25px;
        color: #fff;
        font: bold 12px arial;
        border: 0;
        padding: 0 3px;
    }

    input[type=text] {
        border: none;
        background-color: transparent;
        border-color: -moz-use-text-color -moz-use-text-color #535353;
        border-style: none none solid;
    }
</style>
<asp:DropDownList runat="server" ID="Conductedby" EnableViewState="false" CssClass="conducted-by"
    Style="display: none;">
    <asp:ListItem Text="-- Conducted By --" Value="0"></asp:ListItem>
</asp:DropDownList>
<div id="LoadingGifContainerDiv" class="loading" style="clear: both">
</div>
<div id="MainContainerDiv" class="container_all" style="display: none;">
    <messagecontrol:messages ID="PriorityInQueueMessage" Visible="false" runat="server" />
    <div class="left" style="width: 100%; margin-bottom: 10px;">
        <fieldset>
            <legend>
                <h2>
                    <span id="customername"></span>: <span id="customerid"></span>
                </h2>
            </legend>
            <div style="float: left; width: 25%;">
                <strong>Age:</strong> <span id="customerage"></span>
            </div>
            <div style="float: left; width: 25%;" class="hide-in-patient-portal">
                <strong>Height:</strong> <span id="customerheight"></span>
            </div>
            <div style="float: left; width: 25%;" class="hide-in-patient-portal">
                <strong>Weight:</strong> <span id="customerweight"></span>
            </div>
            <div style="float: left; width: 24%;" class="hide-in-patient-portal">
                <strong>DOB:</strong> <span id="customerDob"></span>
            </div>

            <div style="float: left; width: 25%;">
                <strong>Gender:</strong> <span id="customergender"></span>
            </div>
            <div style="float: left; width: 25%;" class="hide-in-patient-portal">
                <strong>Race:</strong> <span id="customerrace"></span>
            </div>
            <div style="float: left; width: 25%;" class="hide-in-patient-portal">
                <strong>Waist:</strong> <span id="customerwaist"></span>
            </div>
            <div style="float: left; width: 25%;" class="hide-in-patient-portal">
                <strong>BMI:</strong> <span id="customerbmi"></span>
            </div>

            <div style="float: left; width: 25%;" class="hide-in-patient-portal">
                <strong>PCP:</strong> <span id="pcpname">PcpName</span>
            </div>
            <div style="float: left; width: 25%;" class="hide-in-patient-portal">
                <strong>Member Id:</strong> <span id="memberid"></span>
            </div>
            <div style="float: left; width: 25%;" class="hide-in-patient-portal">
                <strong>HICN Number:</strong> <span id="hicnnumber"></span>
            </div>
            <div style="float: left; width: 25%;" class="hide-in-patient-portal">
                <strong>ACES Id:</strong> <span id="acesid"></span>
            </div>
        </fieldset>
    </div>
    <div class="lrow showhideFastingStatus" style="float: left">
        <label class="labels">
            Is Customer On Fast? :
        </label>
        <input type="radio" disabled="disabled" name="CustomerOnFast" id="customerOnFastYesRadio" />Yes
            <input type="radio" disabled="disabled" name="CustomerOnFast" id="customerOnFastNoRadio" />No
    </div>
    <uc:_BasicBiometric runat="server" ID="BasicBiometric" Disabled="true" />
    <div class="left" id="testdatasectiondiv" style="width: 100%; margin-bottom: 10px; clear: both">
        <uc:_TestSection runat="server" ID="TestSection" />
    </div>
</div>
<div id="videoplayerfortestmediadiv" style="display: none; width: 850px;" class="jdbox">
    <table cellspacing="2" style="float: left; width: 100%;">
        <tr>
            <td colspan="3" style="text-align: right; padding-bottom: 5px;">
                <a href="#" target="_blank" id="ViewImageAnchor">View Image</a>
            </td>
        </tr>
        <tr>
            <td style='width: 40px; text-align: center; vertical-align: middle;'>
                <img src="/App/Images/left_arrow_black.gif" alt="Previous" style="cursor: pointer;"
                    class="media-navigation-prev" onclick="onPreviousClick_MediaTraversing();" />
            </td>
            <td style='text-align: center; vertical-align: middle;' id="imgcontainer"></td>
            <td style='width: 40px; text-align: center; vertical-align: middle;'>
                <img src="/App/Images/right_arrow_black.gif" alt="Previous" style="cursor: pointer;"
                    class="media-navigation-next" onclick="onNextClick_MediaTraversing();" />
            </td>
        </tr>
    </table>
</div>
<div id="customerCriticalDataDiv" style="display: none;">
    <div class="loading" style="clear: both">
    </div>
</div>
<div id="customerPriorityinQueueTestDiv" style="display: none;">
    <div class="loading" style="clear: both">
    </div>
</div>
<script language="javascript" type="text/javascript">

    var fileTypeImage = '<%= (int)FileType.Image %>';
    var readingSourceManual = "<%= (short)ReadingSource.Manual %>";
    var currentUser = '<%= IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId %>';
    var currentDate = '<%= DateTime.Now %>';

    var stateNumberEvaluation = '<%= TestResultStateNumber.Evaluated %>';
    var stateNumberPostAudit = '<%= TestResultStateNumber.PostAudit %>';
    var stateNumberPreAudit = '<%= TestResultStateNumber.PreAudit %>';

    var statusComplete = '<%= TestResultStatus.Complete %>';
    var statusIncomplete = '<%= TestResultStatus.Incomplete %>';

    var eventId = '<%= EventId %>';
    var customerId = '<%= CustomerId %>';

    var pcpName = '<%= PcpName.Replace("'", "\\\'").Replace("\"", "\\\"").Replace("\r", " ").Replace("\n", "{newlinefeed}") %>';
    var loadCounter = 0;

    function ErrorMethodFetchData() {
        setLoadCounter();
        alert("Oops! a problem occured in the system.");
    }

    $(document).ready(function () {

        fillConductedBy();
        initialSettingsIncidentalFinding();
        hideTechnicianNotes();
        hideDemographicData();
        $('#customerCriticalDataDiv').dialog({ width: 650, autoOpen: false, title: 'Preliminary Test Result', resizable: false, draggable: true, modal: true });
        $('#customerCriticalDataDiv').bind('dialogclose', onCloseCustomerCriticalDataDiv);

        $('#customerPriorityinQueueTestDiv').dialog({ width: 650, autoOpen: false, title: 'Priority In Queue Reason', resizable: false, draggable: true, modal: true });
        $('#customerPriorityinQueueTestDiv').bind('dialogclose', onClosePriorityInQueueTest);

        var parameter = "{'customerId':'" + customerId + "'";
        parameter += ",'eventId':'" + eventId + "','urlPath':'<%= Request.Url.AbsolutePath %>'}";

        var messageUrl = '<%= ResolveUrl("~/App/Controllers/ManualEntryAndAuditController.asmx/GetCustomerEditModel") %>';
        InvokeServicewithErrorMethodName(messageUrl, parameter, SetCustomerData, ErrorMethodFetchData);

        messageUrl = '<%= ResolveUrl("~/App/Controllers/ManualEntryAndAuditController.asmx/GetTestResults") %>';
        InvokeServicewithErrorMethodName(messageUrl, parameter, SetTestControlData, ErrorMethodFetchData);

        messageUrl = '<%= ResolveUrl("~/App/Controllers/ManualEntryAndAuditController.asmx/GetBasicBiometric") %>';
        InvokeService(messageUrl, parameter, setbiometricdata);

        messageUrl = '<%= ResolveUrl("~/App/Controllers/ManualEntryAndAuditController.asmx/GetRetestData") %>';
        InvokeService(messageUrl, parameter, setRetestCheckbox);

        if ("<%= ShowHideFastingStatus%>" == "<%= Boolean.TrueString%>") {
            messageUrl = '<%= ResolveUrl("~/App/Controllers/ManualEntryAndAuditController.asmx/GetFastingStatus") %>';
            InvokeServicewithErrorMethodName(messageUrl, parameter, setFastingData, ErrorMethodFetchData);
            $(".showhideFastingStatus").show();
        } else {
            $(".showhideFastingStatus").hide();
        }

    });

    function hideTechnicianNotes() {
        var currentRole = '<%= IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.GetSystemRoleId %>';
        if (currentRole == '<%=(long)Falcon.App.Core.Enum.Roles.Customer %>') {
            $('.technotes').parent().hide();
        }
    }

    function hideDemographicData() {
        var currentRole = '<%= IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.GetSystemRoleId %>';
        if (currentRole == '<%=(long)Falcon.App.Core.Enum.Roles.Customer %>') {
            $('.hide-in-patient-portal').hide();
        }
    }

    function setFastingData(result) {
        if (result.d == null) return;

        if (result.d.IsFasting == null) {
            $("#customerOnFastYesRadio").attr("checked", false);
            $("#customerOnFastNoRadio").attr("checked", false);
        }
        else if (result.d.IsFasting == true) {
            $("#customerOnFastYesRadio").attr("checked", true);
            $("#customerOnFastNoRadio").attr("checked", false);
        }
        else if (result.d.IsFasting == false) {
            $("#customerOnFastYesRadio").attr("checked", false);
            $("#customerOnFastNoRadio").attr("checked", true);
        }
    }

    function setbiometricdata(result) {
        if (result.d == null) return;

        if (result.d.SystolicPressure != null)
            $("#systolicbp").val(result.d.SystolicPressure);

        if (result.d.DiastolicPressure != null)
            $("#diastolicbp").val(result.d.DiastolicPressure);

        if (result.d.IsRightArmBpMeasurement) {
            $("#rightArmBp").attr("checked", true);
        }
        else if (result.d.SystolicPressure != null || result.d.DiastolicPressure != null) {
            $("#leftArmBp").attr("checked", true);
        }

        if (result.d.IsBloodPressureElevated == true) {
            $("#isElevatedBp").attr("checked", true);
        }

        if (result.d.PulseRate != null)
            $("#pulseratebb").val(result.d.PulseRate);
    }

    var nextCustomerId = 0;

    function setLoadCounter() {
        loadCounter++;
        if (loadCounter == 2) {
            $("#LoadingGifContainerDiv").hide();
            $("#MainContainerDiv").show();
        }
    }

    function dataLoaded() {
        return ($("#MainContainerDiv:visible").length > 0);
    }

    function CalculateBMI(height, pounds) {
        if (height.TotalInches > 1 && pounds > 1)
            return (pounds / Math.pow(height.TotalInches, 2) * 703).toFixed(1);

        return "N/A";
    }

    function SetCustomerData(entity) {
        setLoadCounter();
        var customer = entity.d;

        $("#customername").text(customer.FullName.FullName);
        $("#customerid").text(customerId);

        if (customer.CustomerProfile.Height != null) {
            var heightFeet = customer.CustomerProfile.Height.Feet;
            var heightInch = customer.CustomerProfile.Height.Inches;

            $("#customerheight").text(heightFeet + " ft " + heightInch + " in");
        }
        else
            $("#customerheight").text("N/A");

        if (customer.CustomerProfile.Weight != null)
            $("#customerweight").text(customer.CustomerProfile.Weight.Pounds + " lbs");
        else
            $("#customerweight").text("N/A");

        if (customer.CustomerProfile.Waist != null)
            $("#customerwaist").text(customer.CustomerProfile.Waist + " in");
        else
            $("#customerwaist").text("N/A");

        if (customer.CustomerProfile.Weight != null && customer.CustomerProfile.Height != null)
            $("#customerbmi").text(CalculateBMI(customer.CustomerProfile.Height, customer.CustomerProfile.Weight.Pounds));
        else
            $("#customerbmi").text("N/A");

        if (customer.DateOfBirth != null) {
            customer.DateOfBirth = correctDateExpression(customer.DateOfBirth);
            $("#customerage").text(Age((customer.DateOfBirth.getMonth() + 1) + "/" + customer.DateOfBirth.getDate() + "/" + customer.DateOfBirth.getFullYear()));
        }
        else {
            $("#customerage").text("N/A");
        }

        if (customer.CustomerProfile.Gender == "<%= (int)Gender.Male %>")
            $("#customergender").text("<%= Gender.Male %>");
        else if (customer.CustomerProfile.Gender == "<%= (int)Gender.Female %>")
            $("#customergender").text("<%= Gender.Female %>");
        else
            $("#customergender").text("N/A");

    if (customer.CustomerProfile.Race == '<%= (int)Race.Caucasian %>')
            $("#customerrace").text('<%= Race.Caucasian %>');
    else if (customer.CustomerProfile.Race == '<%= (int)Race.Hispanic %>')
        $("#customerrace").text('<%= Race.Hispanic %>');
    else if (customer.CustomerProfile.Race == '<%= (int)Race.NativeAmerican %>')
        $("#customerrace").text('<%= Race.NativeAmerican %>');
        else if (customer.CustomerProfile.Race == '<%= (int)Race.Asian %>')
            $("#customerrace").text('<%= Race.Asian %>');
        else if (customer.CustomerProfile.Race == '<%= (int)Race.AfricanAmerican %>')
            $("#customerrace").text('<%= Race.AfricanAmerican %>');
        else if (customer.CustomerProfile.Race == '<%= (int)Race.Latino %>')
            $("#customerrace").text('<%= Race.Latino %>');
        else if (customer.CustomerProfile.Race == '<%= (int)Race.DeclinesToReport %>')
            $("#customerrace").text('<%= Race.DeclinesToReport.GetDescription() %>');
        else
            $("#customerrace").text("N/A");

    if (customer.DateOfBirth != null)
        $("#customerDob").text((customer.DateOfBirth.getMonth() + 1) + "/" + customer.DateOfBirth.getDate() + "/" + customer.DateOfBirth.getFullYear());
    else
        $("#customerDob").text("N/A");

    if (pcpName != null && pcpName != '')
        $("#pcpname").text(pcpName);
    else
        $("#pcpname").text("N/A");

    if (customer.CustomerProfile.Hicn != null && customer.CustomerProfile.Hicn != "")
        $("#hicnnumber").text(customer.CustomerProfile.Hicn);
    else
        $("#hicnnumber").text("N/A");

    if (customer.CustomerProfile.AcesId != null && customer.CustomerProfile.AcesId != "")
        $("#acesid").text(customer.CustomerProfile.AcesId);
    else
        $("#acesid").text("N/A");

    if (customer.CustomerProfile.InsuranceId != null && customer.CustomerProfile.InsuranceId != "")
        $("#memberid").text(customer.CustomerProfile.InsuranceId);
    else
        $("#memberid").text("N/A");
}

function removeTypeAttribute(testResult) {
    s = JSON.stringify(testResult);
    var match = /\"__type\":\"([^\\\"]|\\.)*\",/;
    s = s.replace(/\"__type\":\"([^\\\"]|\\.)*\",/, "");
    eval("testResult = " + s);
    return testResult;
}

function SetTestControlData(entity) {
    setLoadCounter();
    var currentRole = '<%= IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.GetSystemRoleId %>';
    $.each(entity.d, function () {
        var testResult = removeTypeAttribute(this);
        testResult = CorrectDateissue(testResult);

        if (this.TestType == '<%= (short)TestType.EKG %>') {
            SetEKGData(testResult);
            $(".ekgDiv").show();
        }
        if (this.TestType == '<%= (short)TestType.Echocardiogram %>') {
            SetEchoData(testResult);
            $(".echoDiv").show();
        }
        if (this.TestType == '<%= (short)TestType.PulmonaryFunction %>') {
            SetPulmonaryData(testResult);
            $(".pulmonaryDiv").show();
        }
        if (this.TestType == '<%= (short)TestType.IMT %>') {
            SetImtData(testResult);
            $(".imtDiv").show();
        }
        if (this.TestType == '<%= (short)TestType.Thyroid %>' && currentRole != '<%=(long)Falcon.App.Core.Enum.Roles.Customer %>') {
            SetThyroidData(testResult);
            $(".thyroidDiv").show();
        }
        else if (this.TestType == '<%= (short)TestType.Lipid %>') {
                SetLipidData(testResult);
                $(".lipidDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.AwvLipid %>') {
                SetAwvLipidData(testResult);
                $(".awvLipidDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.Cholesterol %>') {
                SetCholesterolData(testResult);
                $(".CholesterolDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.Diabetes %>') {
                SetDiabetesData(testResult);
                $(".DiabetesDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.Liver %>') {
                SetLiverData(testResult);
                $(".liverDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.FraminghamRisk %>') {
                SetFraminghamRiskData(testResult);
                $(".framinghamRiskDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.AAA %>') {
                SetAAAData(testResult);
                $(".aaaDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.AwvAAA %>') {
                SetAwvAaaData(testResult);
                $(".AwvAaaDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.Stroke %>') {
                SetStrokeData(testResult);
                $(".strokeDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.AwvCarotid %>') {
                SetAwvCarotidData(testResult);
                $(".awvCarotidDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.Lead %>') {
                SetLeadData(testResult);
                $(".leadDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.PAD %>') {
                SetPadData(testResult);
                $(".padDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.AwvABI %>') {
                SetAwvAbiData(testResult);
                $(".AwvAbiDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.ASI %>') {
                SetAsiData(testResult);
                $(".asiDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.Osteoporosis %>') {
                SetOsteoData(testResult);
                $(".osteoDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.Spiro %>') {
                SetSpiroData(testResult);
                $(".spiroDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.HPylori %>') {
                SetHPyloriData(testResult);
                $(".HPyloriDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.A1C %>') {
                SetA1cData(testResult);
                $(".a1cDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.Psa %>' && currentRole != '<%=(long)Falcon.App.Core.Enum.Roles.Customer %>') {
                SetPsaData(testResult);
                $(".PsaDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.Crp %>' && currentRole != '<%=(long)Falcon.App.Core.Enum.Roles.Customer %>') {
                SetCrpData(testResult);
                $(".CrpDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.Kyn %>') {
                SetKynData(testResult);
                $(".KynDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.HKYN %>') {
                SetHkynData(testResult);
                $(".HkynDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.Colorectal %>') {
                SetColorectalData(testResult);
                $(".ColorectalDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.AwvBoneMass %>') {
                SetAwvBoneMassData(testResult);
                $(".awvBoneMassDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.AwvEkg %>') {
                SetAwvEkgData(testResult);
                $(".awvEkgDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.AwvEkgIPPE %>') {
                SetAwvEkgIPPEData(testResult);
                $(".awvEkgIPPEDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.AwvSpiro %>') {
                SetAwvSpiroData(testResult);
                $(".awvSpiroDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.AwvHBA1C %>') {
                SetAwvHemaglobinData(testResult);
                $(".awvHemaglobinDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.AwvGlucose %>') {
                SetAwvGlucoseData(testResult);
                $(".awvGlucoseDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.Testosterone %>' && currentRole != '<%=(long)Falcon.App.Core.Enum.Roles.Customer %>') {
                SetTestosteroneData(testResult);
                $(".TestosteroneDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.PPAAA %>') {
                SetPpAAAData(testResult);
                $(".PpaaaDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.PPEcho %>') {
                SetPpEchoData(testResult);
                $(".PpechoDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.AWV %>') {
                SetAwvData(testResult);
                $(".AwvDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.Medicare %>') {
                SetMedicareData(testResult);
                $(".MedicareDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.AwvSubsequent %>') {
                SetAwvSubsequentData(testResult);
                $(".AwvSubsequentDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.Hearing %>') {
                SetHearingData(testResult);
                $(".HearingDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.Vision %>') {
                SetVisionData(testResult);
                $(".VisionDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.Glaucoma %>') {
                SetGlaucomaData(testResult);
                $(".GlaucomaDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.HCPAAA %>') {
                SetHcpAAAData(testResult);
                $(".HcpaaaDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.HCPCarotid %>') {
                SetHcpCarotidData(testResult);
                $(".HcpCarotidDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.HCPEcho %>') {
                SetHcpEchoData(testResult);
                $(".HcpEchoDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.AwvEcho %>') {
                SetAwvEchoData(testResult);
                $(".awvEchoDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.MenBloodPanel %>') {
                SetMenBloodPanelData(testResult);
                $(".MenBloodPanelDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.WomenBloodPanel %>') {
                SetWomenBloodPanelData(testResult);
                $(".WomenBloodPanelDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.VitaminD %>' && currentRole != '<%=(long)Falcon.App.Core.Enum.Roles.Customer %>') {
                SetVitaminDData(testResult);
                $(".VitaminDDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.Hypertension %>') {
                SetHypertensionData(testResult);
                $(".HypertensionDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.Hemoglobin %>') {
                SetHemoglobinData(testResult);
                $(".HemoglobinDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.DiabeticRetinopathy %>') {
                SetDiabeticRetinopathyData(testResult);
                $(".DiabeticRetinopathyDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.eAWV %>') {
                SetEAWVData(testResult);
                $(".EAWVDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.DiabetesFootExam %>') {
                SetDiabetesFootExamData(testResult);
                $(".DiabetesFootExamDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.RinneWeberHearing %>') {
                SetRinneWeberHearingData(testResult);
                $(".RinneWeberHearingDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.Monofilament %>') {
                SetMonofilamentData(testResult);
                $(".MonofilamentDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.DiabeticNeuropathy %>') {
                SetDiabeticNeuropathyData(testResult);
                $(".DiabeticNeuropathyDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.FloChecABI %>') {
                SetFloChecABIData(testResult);
                $(".FloChecABIDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.IFOBT %>') {
                SetIFOBTData(testResult);
                $(".IFOBTDiv").show();
            } else if (this.TestType == '<%= (short)TestType.QualityMeasures %>') {
                SetQualityMeasuresData(testResult);
                $(".QualityMeasuresDiv").show();
            } else if (this.TestType == '<%= (short)TestType.PHQ9 %>') {
                SetPhq9Data(testResult);
                $(".phq9Div").show();
            } else if (this.TestType == '<%= (short)TestType.FocAttestation %>') {
                SetFocAttestationData(testResult);
                $(".focAttestation").show();
            } else if (this.TestType == '<%= (short)TestType.Mammogram %>') {
                SetMammogramData(testResult);
                $(".mammogramDiv").show();
            } else if (this.TestType == '<%= (short)TestType.UrineMicroalbumin %>') {
                SetUrineMicroalbuminData(testResult);
                $(".UrineMicroalbuminDiv").show();
            } else if (this.TestType == '<%= (short)TestType.FluShot %>') {
                SetFluShotData(testResult);
                $(".fluShotDiv").show();
            } else if (this.TestType == '<%= (short)TestType.AwvFluShot %>') {
                SetAwvFluShotData(testResult);
                $(".awvFluShotDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.Pneumococcal %>') {
                SetPneumococcalData(testResult);
                $(".PneumococcalDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.Chlamydia %>') {
                SetChlamydiaData(testResult);
                $(".chlamydiaDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.QuantaFloABI %>') {
                SetQuantaFloABIData(testResult);
                $(".QuantaFloABIDiv").show();
            } else if (this.TestType == '<%= (short)TestType.DPN %>') {
                SetDpnData(testResult);
                $(".DpnDiv").show();
            } else if (this.TestType == '<%= (short)TestType.HKYN %>') {
                SetHkynData(testResult);
                $(".HkynDiv").show();
            } else if (this.TestType == '<%= (short)TestType.MyBioCheckAssessment %>') {
                SetMyBioCheckAssessmentData(testResult);
                $(".myBioCheckAssessmentDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.Foc %>') {
                SetFocData(testResult);
                $(".focDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.Cs %>') {
                SetCsData(testResult);
                $(".csDiv").show();
            }
            else if (this.TestType == '<%= (short)TestType.Qv %>') {
                SetQvData(testResult);
                $(".qvDiv").show();
            }
    });

}

</script>
<script language="javascript" type="text/javascript">

    function OpenPopUp(title, width, pageUrl, height) {
        if (height == null) height = 700;

        var windowHeight = $(window).height();
        if (Number(windowHeight) <= Number(height))
            height = Number(windowHeight) - 40;

        tb_show(title, pageUrl + '&keepThis=true&TB_iframe=true&height=' + height + '&width=' + width + '&modal=true', false);
    }

    function ClosePopUp() {
        parent.top.tb_remove();
    }

    var fileTypeImage = '<%= (int)FileType.Image %>';
    function DefaultErrorMethod() {
        alert("Oops! a problem occured in the system.");
    }

    function InvokeService(messageUrl, parameter, successFunction) {
        InvokeServicewithErrorMethodName(messageUrl, parameter, successFunction, DefaultErrorMethod);
    }

    function InvokeServicewithErrorMethodName(messageUrl, parameter, successFunction, errorMethod) {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: messageUrl,
            data: parameter,
            success: function (result) {
                successFunction(result);
            },
            error: function (a, b, c) {

                errorMethod();
            }

        });
    }


</script>
<script language="javascript" type="text/javascript">
    function loadScreen(testId, technicianControl, setMethodRef) {

        $.ajax({
            type: "GET",
            cache: false,
            dataType: "html",
            url: "/Medical/CustomerEventCriticalData/Edit?theeventId=" + eventId + "&thecustomerId=" + customerId + "&thetestId=" + testId,
            data: "{}",
            success: function (result) {
                $("#customerCriticalDataDiv").empty();
                $("#customerCriticalDataDiv").append(result);

                loadControl(setMethodRef, (function () { $("#customerCriticalDataDiv").dialog('close'); }), '<%= TestResultStateNumber.PostAudit %>');

            },
            error: function (a, b, c) { alert('Some error loading the Customer Critical Data. Please try opening the page again'); $("#customerCriticalDataDiv").dialog('close'); }
        });
    }

    function openCriticalDataDialog(testId, technicianControl, criticalCheckboxRef, setMethodRef) {
        $("#customerCriticalDataDiv").dialog('open');
        loadScreen(testId, technicianControl, setMethodRef);
    }

    function loadCriticalLink(criticalSpanJobj, loadMethodstring, testId) {
        //if (criticalSpanJobj.find("img.critical-data-load-img").length < 1) {
        //    criticalSpanJobj.append("<img class='critical-data-load-img' src='/App/Images/info-icon-red.gif' style='padding-left:1px;padding-right:1px;margin-top:1px;' alt='' onclick='" + loadMethodstring + "' /> ");
        //    criticalSpanJobj.append("<a target='_blank' href='/Medical/CustomerEventCriticalData/Print?eventId=" + eventId + "&customerId=" + customerId + "&testId=" + testId + "'><img class='critical-data-print-img' src='/App/Images/printer.gif' style='padding-left:1px;padding-right:1px;margin-top:1px;' alt='' /></a>");
        //}
    }

    function unloadCriticalLink(criticalSpanJobj, testId) {
        if (criticalSpanJobj.find("img.critical-data-load-img").length > 0) {
            criticalSpanJobj.find("img.critical-data-load-img").remove();
            criticalSpanJobj.find("img.critical-data-print-img").remove();
        }
    }

    function onCloseCustomerCriticalDataDiv() {
        $('#customerCriticalDataDiv').html("<div class='loading' style='clear: both;'> &nbsp; </div>");
    }
</script>

<script language="javascript" type="text/javascript">

    var _savePriorityInQueTestForm = false;
    var _priorityInqueueTestCheckBoxRef = null;
    function onClosePriorityInQueueTest() {
        if (!_savePriorityInQueTestForm && _priorityInqueueTestCheckBoxRef != null) {

            _priorityInqueueTestCheckBoxRef.attr("checked", false);
            _priorityInqueueTestCheckBoxRef.click();
            _priorityInqueueTestCheckBoxRef.attr("checked", false);
        }
    }

    function loadPriorityInQueueTestScreen(testId, technicianControl, setMethodRef) {

        $.ajax({
            type: "GET",
            cache: false,
            dataType: "html",
            url: "/Medical/CustomerEventPriorityInQueueData/Edit?theeventId=" + eventId + "&thecustomerId=" + customerId + "&thetestId=" + testId,
            data: "{}",
            success: function (result) {
                $("#customerPriorityinQueueTestDiv").empty();
                $("#customerPriorityinQueueTestDiv").append(result);

                loadPriorityinQueueTestPopup(setMethodRef, (function () { $("#customerPriorityinQueueTestDiv").dialog('close'); }), '<%= TestResultStateNumber.PostAudit %>');

                if (isPriorityInQueueTestOpenForEdit) {
                    _savePriorityInQueTestForm = true;
                }
            },
            error: function (a, b, c) { alert('Some error loading the Priority in queue note. Please try opening the page again'); $("#customerPriorityinQueueTestDiv").dialog('close'); }
        });
    }

    function openPriorityInQueueTestDialog(testId, technicianControl, priorityInQueueCheckboxRef, setMethodRef) {
        $("#customerPriorityinQueueTestDiv").dialog('open');
        _priorityInqueueTestCheckBoxRef = priorityInQueueCheckboxRef;
        loadPriorityInQueueTestScreen(testId, technicianControl, setMethodRef);
    }

    function loadPriorityInQueueLink(piqSpanJobj, loadMethodstring, testId) {
        if (piqSpanJobj.find("img.priorityInQueue-data-load-img").length < 1) {
            piqSpanJobj.append("<img class='priorityInQueue-data-load-img' src='/App/Images/info-icon-red.gif' style='padding-left:1px;padding-right:1px;margin-top:1px;' alt='' onclick='" + loadMethodstring + "' /> ");
        }
    }

    function unloadPriorityInQueueLink(priorityInQueueSpanJobj, testId) {
        if (priorityInQueueSpanJobj.find("img.priorityInQueue-data-load-img").length > 0) {
            priorityInQueueSpanJobj.find("img.priorityInQueue-data-load-img").remove();
        }
    }
</script>
<script type="text/javascript">
    function SetTestNotPerformedEnableDisabled(controlId) {
        var isAdminUser = '<%= IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.CheckRole((long)Falcon.App.Core.Enum.Roles.FranchisorAdmin) %>';
        var contraller = $("#" + controlId);
        var booleanFalse = '<%= Boolean.FalseString %>';
        var selectedValue = $(contraller).find("select :selected").val();
        var testNotReadable = '<%= (long) TestNotPerformedReasonType.TestUnreadable %>';
            if (selectedValue === testNotReadable && isAdminUser === booleanFalse) {
                //$(contraller).find("input").attr("disabled", true);
                $(contraller).find("select,input,textArea").attr("disabled", true);
            } else if (isAdminUser === booleanFalse) {
                $(contraller).find("select option").each(function () {
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
