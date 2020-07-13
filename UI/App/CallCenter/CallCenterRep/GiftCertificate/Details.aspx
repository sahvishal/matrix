<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App/CallCenter/NewCallCenterMaster.master"
    CodeBehind="Details.aspx.cs" Inherits="Falcon.App.UI.App.CallCenter.CallCenterRep.GiftCertificate.Details" Title="Gift Certificate Details" %>

<%@ Register Src="~/App/UCCommon/GiftCertificateDetails.ascx" TagPrefix="uc" TagName="Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="caontainer_head">
<asp:HiddenField runat="server" ID="hfCallStartTime" />
<h1 class="left">Step 2: Personalize your gift certificate</h1>
	<div id="CallPanel" runat="server" class="callbox_dtls">
		<div class="durationtxt">Call in Progress</div>
		<div class="timetxt"><span id="HH"></span>:<span id="MM"></span>:<span id="SS"></span></div>
		<div class="smalltxt">(HH:MM:SS)</div>
		<div class="right"><asp:ImageButton ID="imgEndCall" runat="server" ImageUrl="~/App/Images/CCRep/endcall-gc.gif" OnClientClick="closeScriptPopup(); CallNotes(); return false;" /></div>
	</div>
</div>	
 <uc:Details runat="server" ID="GiftCertificateDetails" OnnavigateOnChangeAmountClick="NavigateOnChangeAmountClick" OnnavigateOnSubmitClick="NavigateOnSubmitClick" />
 
<script type="text/javascript" src="/App/JavascriptFiles/HttpRequest.js"></script>
<script type="text/javascript" src="/App/JavascriptFiles/actb.js"></script>

<script type="text/javascript" language="javascript">

    var hfCallStartTime = document.getElementById("<%= this.hfCallStartTime.ClientID %>");
    if ('<%= NotInCall %>' == '<%= bool.FalseString %>') {
        StartTimer(hfCallStartTime);
    }

    var postRequest = new HttpRequest(); 
    postRequest.setRequestHeader("Content-Type", "application/x-www-form-urlencoded"); 
    postRequest.failureCallback = requestFailed(); 
    
    function requestFailed()
    {
        
    }

    function CallEnd() {
        postRequest.url = "RegisterCustomerCall.aspx?CallEnd=True"; 
        postRequest.post("");
        window.location = "/../../CallCenter/CallCenterRepDashboard/Index";
    }
    

    $(document).ready(function () {
        checkAndOpenScriptPopup();
    });
</script>
</asp:Content>
