<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EndOfDayProcess.aspx.cs"
    Inherits="HealthYes.Web.App.Franchisee.Technician.EndOfDayProcess" %>

<%@ Register TagPrefix="uc" Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" %>
<%@ Import Namespace="Falcon.App.Core.Sales.Enum" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .wrapper_pop
        {
            float: left;
            width: 502px;
            padding: 10px;
            background-color: #f5f5f5;
            font: normal 12px arial;
        }
        .wrapperin_pop
        {
            float: left;
            width: 478px;
            border: solid 2px #4888AB;
            padding: 10px;
            background-color: #fff;
        }
        .innermain_pop
        {
            float: left;
            width: 468px;
            padding: 0px 5px 0px 5px;
        }
        .txttechteam
        {
            float: left;
            width: 468px;
            padding: 0 5px;
            color: red;
            font-size: 14px;
            font-weight: bold;
        }
        .innermain_1_pop
        {
            float: left;
            width: 463px;
            padding-top: 5px;
        }
        .orngbold16_default
        {
            font: bold 16px arial;
            color: #F37C00;
            float: left;
        }
        .orngbold14_default
        {
            float: left;
            font: bold 14px arial;
            color: #F37C00;
        }
        .btextblu12
        {
            font: bold 12px arial;
            color: #287AA8;
        }
        .titletextnowidth_default
        {
            float: left;
            margin-right: 5px;
            padding-top: 3px;
            font-weight: bold;
            color: #000;
        }
        .ttxtnowidthnormal_default
        {
            float: left;
            margin-right: 5px;
            padding-top: 3px;
            font-weight: normal;
            color: #000;
        }
        .innerscrolldiv_popup
        {
            float: left;
            width: 478px;
            overflow-y: scroll;
            overflow-x: hidden;
            height: 500px;
            margin-top: 10px;
        }
        .innerscrolldiv_popup .row
        {
            float: left;
            width: 478px;
        }
        .orngheadtxt_heading
        {
            float: left;
            font: bold 20px arial;
            color: #F37C00;
        }
        .right
        {
            float: right;
        }
        .left
        {
            float: left;
        }
        .leftprt_row
        {
            float: left;
            width: 300px;
        }
        .leftprt_row ul
        {
            margin: 10px 0 0 10px;
            padding-left: 10px;
        }
        .leftprt_row ul li
        {
            margin-left: 10px;
            padding-left: 0px;
            line-height: 18px;
            list-style-type: square;
        }
        .rgtprt_row
        {
            float: left;
            width: 100px;
        }
        .rgtprt_row .row
        {
            float: left;
            width: 100px;
            line-height: 18px;
        }
        .divalogin
        {
            float: left;
            width: 100%;
        }
        .divalogin div
        {
            float: left;
            width: 100%;
            padding-top: 10px;
        }
        .divalogin .upldimg
        {
            float: left;
            width: 100%;
            display: block;
            margin-top: 10px;
        }
        .divalogin .btndiv
        {
            float: right;
            padding-right: 100px;
            width: 300px;
            text-align: right;
        }
        .divalogin .label
        {
            float: left;
            font-weight: bold;
            color: #000;
            width: 100px;
        }
        .divalogin .label3
        {
            float: left;
            width: 50%;
        }
        .divalogin .label2
        {
            float: left;
            font-weight: bold;
            color: #000;
            width: 130px;
        }
        .divLeftWidth
        {
            float: left;
            width: 100%;
        }
    </style>
    
    <script src="/scripts/jquery-1.5.2.min.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">

        var wincustomerinfo = null;
        
        function OpenCustomerWindow(customerid)
        {
            var enterwindow = true;
        
            if (wincustomerinfo!=undefined && !wincustomerinfo.closed)
            {
                enterwindow = confirm('There is already a window open, with a Customer Detail. Would you like to close it?');
            }
            
            if(enterwindow == true)
                wincustomerinfo = window.open("/App/Common/EditCustomer.aspx?OpenAsPopUp=true&CustomerID=" + customerid, "CustomerInfo", "toolbar=no,location=no,directories=no,status=no,scrolling=auto,scrollbars=yes,menubar=no,resizable=yes,width=820,height=500");
        }

        var winmedicalhistory = null;
        
        function OpenMedicalHistoryWindow(customerid)
        {            
            var enterwindow = true;
        
            if (winmedicalhistory!=undefined && !winmedicalhistory.closed)
            {
                enterwindow = confirm('There is already a window open, with a Customer Detail. Would you like to close it?');
            }
            
            if(enterwindow == true)
                winmedicalhistory = window.open("/App/Common/MedicalHistory.aspx?CustomerID=" + customerid + "&EventId=<%=EventId %>", "CustomerInfo", "toolbar=no,location=no,directories=no,status=no,scrolling=auto,scrollbars=yes,menubar=no,resizable=yes,width=820,height=500");
        }
    
        function closePopup()
        {//debugger
            if (winmedicalhistory!=undefined && !winmedicalhistory.closed)
            {
                var closeMH = true;
                closeMH = confirm('There is a Health Assessment window open, with a Customer Detail. Would you like to close it?');
                if(closeMH)
                    winmedicalhistory.close();
                else return false;
            }
            
            if (wincustomerinfo!=undefined && !wincustomerinfo.closed)
            {
                var closeCustomer = true;
                closeCustomer = confirm('There is an Edit Customer window open. Would you like to close it?');
                if(closeCustomer)
                    wincustomerinfo.close();
                else return false;
            }
            return true;
        }
    
        function VerifyLoginInfo()
        {
            if (document.getElementById('<%=this._txtUserName.ClientID %>').value=='')
            {
            alert('Username can not left blank.');return false;
            }
            else if (document.getElementById('<%=this._txtPassword.ClientID %>').value=='')
            {
                alert('Password can not left blank.');return false;
            }
            if(document.getElementById('<%= this._chkIagree.ClientID %>').checked == false)
            { 
                alert('Please check I Agree.');  return false; 
            }
            return true;
        }

        function RefereshWindow()
        {
            self.location.reload(true);
        }
    
    </script>

    <script language="javascript" type="text/javascript">
                
        function ValidateHostRanking()
        {
            if($("#<%= this.HostRankingDropDown.ClientID %> option:selected").length < 1
                || $("#<%= this.HostRankingDropDown.ClientID %> option:selected").attr("value") == "0")
            {
                alert("Please select a Host Ranking.")
                return false;
            }
            
            if($("#<%= this.HostRankingDropDown.ClientID %> option:selected").attr("value") == "<%= HostViabilityRanking.Difficult.PersistenceLayerId %>"
                || $("#<%= this.HostRankingDropDown.ClientID %> option:selected").attr("value") == "<%= HostViabilityRanking.LastResort.PersistenceLayerId %>"
                || $("#<%= this.HostRankingDropDown.ClientID %> option:selected").attr("value") == "<%= HostViabilityRanking.DoNotSchedule.PersistenceLayerId %>")
            {
                if($.trim($("#<%= this.CommentsForHostRankingInputBox.ClientID %>").val()).length < 1)
                {
                    alert("Please provide some feedback based on your experience, about the Screening Site.")
                    return false;
                }
                else
                {
                    var bolConfFeedback = confirm("Are you sure? If you hit 'OK' this will be forwarded available to management for review");
                    if(!bolConfFeedback) return false;            
                }
            }            
            
            return true;          
        }

    </script>

</head>
<body onunload="closePopup();">
    <form id="form1" runat="server">
    <uc:JQueryToolkit ID="_jQueryToolkit" runat="server" IncludeJQueryUI="true" />
    <div class="wrapper_pop">
        <div class="wrapperin_pop">
            <div class="innermain_pop" id="divCalendar">
                <div class="innermain_pop" id="LinksEodDiv" runat="server">
                    <span class="orngheadtxt_heading" id="spEventName" runat="server"></span><span style="float: right;
                        padding-right: 20px;">
                    </span><span style="float: right; padding-right: 10px;">
                        <asp:LinkButton runat="server" ID="UpdateHostRankingLink" Text="Update Host Ranking"
                            OnClick="UpdateHostRanking_Click"></asp:LinkButton>
                    </span>
                </div>
                <div class="txttechteam" id="_divTechTeam" runat="server" style="display: none">
                    Tech Team not Selected
                </div>
                <div class="innermain_pop" style="border-top: solid 1px #ccc;">
                    <div class="divalogin" id="_divSignoffInfo" runat="server" style="display: none">
                        <div style="color: Green" id="_divSignoffCompleted" runat="server">
                            <b>End-of-day data for this event is completed.</b>
                        </div>
                        <div id="_divCustomerRegisterAfterSignoff" runat="server" style="display: none; color: red">
                            Note: Customers registered after signoff process.<br />
                            You need to signoff again.
                        </div>
                        <div>
                            <label class="label2">
                                Signoff by:</label>
                            <label id="_lblSignoffBy" runat="server" class="label3">
                            </label>
                        </div>
                        <div>
                            <label class="label2">
                                Signoff Date & Time:</label>
                            <label id="_lblSignoffDatetime" runat="server" class="label3">
                            </label>
                        </div>
                    </div>
                    <div class="innerscrolldiv_popup" runat="server" id="divCustomerList" style="display: none">
                        <div class="left" id="Customer1">
                            <div class="row">
                                <span class="orngbold14_default"><< Customer >> </span>
                            </div>
                            <div class="row">
                                <div class="leftprt_row">
                                    <ul>
                                        <li>Sample text</li>
                                        <li>Sample text</li>
                                        <li>Sample text</li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="innermain_pop" id="HostRankingDiv" runat="server" style="display: none;
                        margin-top: 20px">
                        <div class="divalogin">
                            <div class="orngbold14_default">
                                Host Facility Viability</div>
                            <div class="divLeftWidth">
                                <span style="float: left;">
                                    <label class="label2">
                                        Host Ranking:</label></span> <span style="float: left;">
                                            <asp:DropDownList ID="HostRankingDropDown" runat="server" Width="150px">
                                            </asp:DropDownList>
                                        </span>
                            </div>
                            <div class="divLeftWidth">
                                <span style="float: left;">
                                    <label class="label2">
                                        Comments:</label></span> <span style="float: left;">
                                            <asp:TextBox ID="CommentsForHostRankingInputBox" TextMode="MultiLine" Rows="10" runat="server"
                                                Width="280px"></asp:TextBox></span>
                            </div>
                            <div class="upldimg">
                                <span style="float: left;">
                                    <label class="label2">
                                        Upload Images:</label></span>
                                <div class="left" style="width: 300px">
                                    <asp:FileUpload ID="HostImageUploader1" runat="server" size="35px" Width="300px" />
                                    <asp:FileUpload ID="HostImageUploader2" runat="server" size="35px" Width="300px" />
                                    <asp:FileUpload ID="HostImageUploader3" runat="server" size="35px" Width="300px" />
                                    <asp:FileUpload ID="HostImageUploader4" runat="server" size="35px" Width="300px" />
                                    <asp:FileUpload ID="HostImageUploader5" runat="server" size="35px" Width="300px" />
                                </div>
                            </div>
                            <div  class="divLeftWidth">
                                <span style="float: left;">
                                    <asp:LinkButton ID="DoItLaterLink" runat="server" Text="Do It Later" OnClick="DoItLaterLink_Click"></asp:LinkButton>
                                </span><span class="right">
                                    <asp:Button ID="SaveButton" runat="server" CssClass="button" Text="Save" OnClientClick="return ValidateHostRanking();"
                                        OnClick="SaveButton_Click" />
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="divalogin" id="_divLoginInfo" runat="server" style="display: none">
                        <div>
                            <label class="label">
                                Username:</label>
                            <asp:TextBox ID="_txtUserName" runat="server" Width="180px"></asp:TextBox>
                        </div>
                        <div>
                            <label class="label">
                                Password:</label>
                            <asp:TextBox ID="_txtPassword" runat="server" Width="180px" TextMode="Password" autocomplete="off"></asp:TextBox>
                        </div>
                        <div style="color: Red; display: none" id="_divErrorMessage" runat="server">
                        </div>
                        <div>
                            <asp:CheckBox ID="_chkIagree" runat="server" Text="I verify all the end-of-day data for this event is completed" />
                        </div>
                        <div class="btndiv">
                            <asp:ImageButton ID="_ibtnSignoff" runat="server" ImageUrl="~/App/Images/signoff-btn.gif"
                                OnClientClick="return VerifyLoginInfo();" OnClick="_ibtnSignoff_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
