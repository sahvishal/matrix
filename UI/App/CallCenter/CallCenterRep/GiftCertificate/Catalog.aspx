<%@ Page Language="C#" MasterPageFile="~/App/CallCenter/NewCallCenterMaster.master" AutoEventWireup="true" CodeBehind="Catalog.aspx.cs" Inherits="Falcon.App.UI.App.CallCenter.CallCenterRep.GiftCertificate.Catalog" Title="Gift Certificate Catalog" %>
<%@ Register Src="~/App/UCCommon/GiftCertificateCatalog.ascx" TagName="Catalog" TagPrefix="uc" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="caontainer_head">
	<h1 class="left">Step 1: Select a Gift Certificate</h1>
    <asp:HiddenField runat="server" ID="hfCallStartTime" />
	<div id="CallPanel" runat="server" class="callbox_dtls">
		<div class="durationtxt">Call in Progress</div>
		<div class="timetxt"><span id="HH"></span>:<span id="MM"></span>:<span id="SS"></span></div>
		<div class="smalltxt">(HH:MM:SS)</div>
		<div class="right"><asp:ImageButton ID="imgEndCall" runat="server" ImageUrl="~/App/Images/CCRep/endcall-gc.gif" OnClientClick="closeScriptPopup(); CallNotes(); return false;" /></div>
	</div>
</div>	
<uc:Catalog runat="server" ID="GiftCertificateCatalog" />
<script type="text/javascript" src="/App/JavascriptFiles/HttpRequest.js"></script>
<script type="text/javascript" src="/App/JavaScriptFiles/actb.js"></script>

<script type="text/javascript" language="javascript">
        
    var hfCallStartTime = document.getElementById("<%= this.hfCallStartTime.ClientID %>");
    
    StartTimer(hfCallStartTime);
    
    var postRequest = new HttpRequest(); 
    postRequest.setRequestHeader("Content-Type", "application/x-www-form-urlencoded"); 
    postRequest.failureCallback = requestFailed(); 

    checkAndOpenScriptPopup();

    function requestFailed()
    {
        
    }

    function CallEnd() {
        postRequest.url = "RegisterCustomerCall.aspx?CallEnd=True"; 
        postRequest.post(""); 
        window.location = "/../../CallCenter/CallCenterRepDashboard/Index";
    }
</script>

</asp:Content>
