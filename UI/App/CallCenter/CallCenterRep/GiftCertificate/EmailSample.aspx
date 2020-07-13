<%@ Page Language="C#" MasterPageFile="~/App/CallCenter/NewCallCenterMaster.master" AutoEventWireup="true" CodeBehind="EmailSample.aspx.cs" Inherits="Falcon.App.UI.App.CallCenter.CallCenterRep.GiftCertificate.EmailSample" Title="Gift Certificate Confirmation" %>
<%@ Register Src="~/App/UCCommon/GiftCertificatePreview.ascx" TagName="Preview" TagPrefix="uc"  %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="caontainer_head">
	<h1 class="left">Step <span id="HeadingText" runat="server">5</span>: Gift Certificate Purchase Confirmation</h1>
    <asp:HiddenField runat="server" ID="hfCallStartTime" />
	<div id="CallPanel" runat="server" class="callbox_dtls">
		<div class="durationtxt">Call in Progress</div>
		<div class="timetxt"><span id="HH"></span>:<span id="MM"></span>:<span id="SS"></span></div>
		<div class="smalltxt">(HH:MM:SS)</div>
		<div class="right"><asp:ImageButton ID="imgEndCall" runat="server" ImageUrl="~/App/Images/CCRep/endcall-gc.gif" OnClientClick="closeScriptPopup(); CallNotes(); return false;" /></div>
	</div>
</div>	 
<uc:Preview runat="server" ID="GiftCertificatePreview" />
<script type="text/javascript" src="/App/JavascriptFiles/HttpRequest.js"></script>
<script type="text/javascript" src="/App/JavascriptFiles/actb.js"></script>

<script type="text/javascript" language="javascript">
        
    var hfCallStartTime = document.getElementById("<%= this.hfCallStartTime.ClientID %>");
    
    StartTimer(hfCallStartTime);
    
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
