<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CancelShippingDetail.aspx.cs"
    MasterPageFile="~/App/CallCenter/NewCallCenterMaster.master" Inherits="Falcon.App.UI.App.CallCenter.CallCenterRep.CancelShippingDetail"
    Title="Cancel Shipping Details" %>

<%@ Register Src="~/App/Shipping/UserControl/CancelShippingDetail.ascx" TagName="CancelShipping"
    TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="wrapper_inpg">
        <asp:HiddenField runat="server" ID="hfCallStartTime" />
        <div class="callbox_dtls rgt" style="width:370px" id="divCall" runat="server">
            <div class="durationtxt">
                Call in Progress</div>
            <div class="timetxt">
                <span id="HH"></span>:<span id="MM"></span>:<span id="SS"></span></div>
            <div class="smalltxt" style="margin-right: 5px">
                (HH:MM:SS)</div>
            <div class="right">
                <asp:ImageButton ID="imgEndCall" runat="server" ImageUrl="~/App/Images/CCRep/endcall-gc.gif"
                    OnClientClick="closeScriptPopup(); CallNotes(); return false;" /></div>
        </div>
        <uc:CancelShipping ID="CancelShippingControl" runat="server" />
    </div>

    <script type="text/javascript" src="../../JavascriptFiles/HttpRequest.js"></script>

    <script type="text/javascript" src="../../../Public/JavaScript/actb.js"></script>

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
