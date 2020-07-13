<%@ Page Language="C#" MasterPageFile="~/App/Customer/CustomerMaster.master" AutoEventWireup="true"
    Inherits="Falcon.App.UI.App.Customer.ConfirmationReciept" CodeBehind="ConfirmationReciept.aspx.cs" %>

<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.Core.Interfaces" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>
<%@ Register Src="~/App/UCCommon/UCCustomerLeftInfo.ascx" TagName="CustomerUC" TagPrefix="CustLeft" %>
<%@ Register Src="~/App/UCCommon/ucEventPackageTest.ascx" TagName="OrderPackage"
    TagPrefix="uc1" %>
<asp:Content ID="content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script language="javascript" type="text/javascript">

        var GB_ROOT_DIR = "/App/Wizard/greybox/";

        function popupmenu2(choice, wt, ht) {
            //debugger
            var winOpts = "toolbar=no,location=no,directories=no,status=no,scrolling=auto,scrollbars=no,menubar=no,width=" + wt + ",height=" + ht;
            confirmWin = window.open(choice, 'theconfirmWin', winOpts);
            //window.open(choice,'theconfirmWin',winOpts);
        }

        $(document).ready(function() {
            var decoded = $("<textarea/>").html($("#<%=lblVenue.ClientID %>").html()).text();
            $("#<%=lblVenue.ClientID %>").html(decoded);
        });
    </script>
    <style type="text/css">
        /* ---------------- bubble tip for pod details --------------------*/a.apd
        {
            position: relative;
            z-index: 24;
            color: #3CA3FF;
            font-weight: bold;
            text-decoration: none;
        }
        a.apd span
        {
            display: none;
        }
        a.apd:hover
        {
            z-index: 25;
            color: #aaaaff;
        }
        a.apd:hover span.tooltip
        {
            display: block;
            position: absolute;
            top: 0px;
            left: 0;
            padding: 15px 0 0 0;
            width: 260px;
            color: #000;
            text-align: left;
            filter: alpha(opacity:90);
            khtmlopacity: 0.90;
            mozopacity: 0.90;
            opacity: 0.90;
        }
        /* ---------------- --------------------*//*---------- bubble tooltip -----------*/a.tt
        {
            position: relative;
            z-index: 24;
            color: #3CA3FF;
            font-weight: bold;
            text-decoration: none;
        }
        a.tt span
        {
            display: none;
        }
        /*background:; ie hack, something must be changed in a for ie to execute it*/a.tt:hover
        {
            z-index: 25;
            color: #aaaaff;
            background: ;;;;}
        a.tt:hover span.tooltip
        {
            display: block;
            position: absolute;
            top: 0px;
            left: 0;
            padding: 10px 0 0 0;
            width: 200px;
            color: #993300;
            text-align: left;
            filter: alpha(opacity:90);
            khtmlopacity: 0.90;
            mozopacity: 0.90;
            opacity: 0.90;
        }
        a.tt:hover span.top
        {
            display: block;
            padding: 30px 8px 0;
            background: url(/App/Images/bubble.gif) no-repeat top;
        }
        a.tt:hover span.middle
        {
            /* different middle bg for stretch */
            display: block;
            padding: 0 8px;
            background: url(/App/Images/bubble_filler.gif) repeat bottom;
        }
        a.tt:hover span.bottom
        {
            display: block;
            padding: 3px 8px 10px;
            color: #548912;
            background: url(/App/Images/bubble.gif) no-repeat bottom;
        }
        
    </style>
    <div class="maindiv_custdbrd">
        <div class="mindivbgblue_custdbrd" style="margin-top: 5px;">
            <span class="divheadtxt_custdbrd">Register Event</span>
        </div>
        <div id="Div1" class="leftcon_main_custdbrd" style="margin-bottom: 5px">
            <CustLeft:CustomerUC ID="uc1" runat="server" OnLoad="SetName" />
        </div>
        <div class="main_area_custdbrd">
            <div class="main_row_custdbrd">
                <div class="maindivredmsgbox" style="visibility: hidden; display: none">
                </div>
                <div class="main_area_bdrnone">
                    <div class="divsteps_re">
                        <img src="../Images/Customer_step6n.gif" alt="" />
                    </div>
                    <div style="width: 650px;">
                        <div id="divPrint" runat="server">
                            <div class="thankumsgrownew_prsmall">
                                <b>Registration Successful!</b> Thank you for your time.</div>
                            <div>
                                <img src="../Images/CCRep/specer.gif" height="20px" width="650px" />
                            </div>
                            <div style="float: right; width: 275px">
                                <p style="float: right; width: 263px; padding: 2px 40px 2px 4px;">
                                    <%--<asp:ImageButton id="imgBtnPrint" runat="server" ImageUrl="~/App/Images/appontmentconfirmation-icon.gif" OnClientClick="javascript:CallPrint()" />--%>
                                    <span style="padding-right: 5px;"><a href="#" class="tt" id="imgBtnPrint" runat="server">
                                        <img src="/App/Images/appontmentconfirmation-icon.gif" />
                                    </a></span><span><a href="#" class="tt" id="aSmallReciept" runat="server">
                                        <img src="/App/Images/printer-icon.gif" />
                                    </a></span>
                                </p>
                            </div>
                            <div style="width: 650px; float: left; margin: 0px 0px 10px 10px; display: block"
                                id="divConfirmation" runat="server">
                                <table cellspacing="0px" cellpadding="0px" border="1px" width="600px" style="border-collapse: collapse;
                                    border-color: black;">
                                    <tr>
                                        <td style="vertical-align: top;">
                                            <table cellspacing="0px" cellpadding="2px" border="0px" width="600px" style="font-family: Arial">
                                                <tr>
                                                    <td style="height: 100px">
                                                        <table cellspacing="0px" cellpadding="2px" border="0px" width="600px">
                                                            <tr>
                                                                <td style="width: 250px">
                                                                    <img src="<%= IoC.Resolve<ISettings>().SmallLogo%>" width="239px" height="78px" />
                                                                </td>
                                                                <td align="right" style="color: #5DB3ED; width: 350px">
                                                                    Screening Appointment Confirmation&nbsp;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="font-size: 13px" class="normaltxt_pw">
                                                        Dear
                                                        <asp:Label ID="lblFullName" runat="server" Text=""></asp:Label>,<br />
                                                        <br />
                                                        Below are your preventive screening appointment details:<br />
                                                        <br />
                                                        When: <b>
                                                            <asp:Label ID="lblWhen" runat="server" Text=""></asp:Label></b><br />
                                                        <table cellspacing="0px" cellpadding="0px" style="border-collapse: collapse; border-color: black;">
                                                            <tr>
                                                                <td style="font-size: 13px; vertical-align: top;">
                                                                    Where:
                                                                </td>
                                                                <td style="font-size: 13px">
                                                                    <b>
                                                                        <asp:Label ID="lblVenue" runat="server" Text=""></asp:Label></b><a href="" target="_blank"
                                                                            id="googleMapUrl" runat="server">[Map to the location]</a>
                                                                    <br />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <br />
                                                        <uc1:OrderPackage ID="_orderPackageTest" runat="server" />
                                                        <em>*If payment status is 'Unpaid', please bring payment to your scheduled appointment
                                                            in the form of credit card, check or cash. If 'Paid', thank you for saying "Yes
                                                            to your Health!"</em><br />
                                                        <br />
                                                        <%--<strong>Preparation for the screening:</strong> To learn how to prepare for your
                                                        screening please follow the link below:<br />--%>
                                                        <%--TODO: Check With Yasir--%>
                                                        <%--<a href="http://www.HealthYes.com/Public/Misc/PrepareYourScreening.aspx" target="_blank">
                                                            http://www.HealthYes.com/Public/Misc/PrepareYourScreening.aspx</a><br />
                                                        (If the link is not clickable, please copy and paste it into your browser’s address
                                                        field.)
                                                        <br />--%>
                                                        <br />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div style="float: left; width: 620px; padding-bottom: 10px;">
                                <span style="float: right; padding-right: 5px;">
                                    <input type="button" id="BtnHome" runat="server" value="Continue To Home Page" onserverclick="BtnHome_Click" style="background: #4090AE; color: #FFFFFF;" />
                                </span><span style="float: right; padding-right: 5px; display:none;">
                                    <input type="button" id="BtnFillMedicalHistory" runat="server" value="Fill Your Health Assessment Form" onserverclick="BtnFillMedicalHistory_Click" style="background: #4090AE; color: #FFFFFF;" />
                                </span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
