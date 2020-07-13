<%@ Page Language="C#" MasterPageFile="~/Public/Public.master" AutoEventWireup="true"
    Inherits="Falcon.App.UI.Public.Customer.RegisterCustomerSubmit" EnableEventValidation="false"
    CodeBehind="RegisterCustomerSubmit.aspx.cs" %>

<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>
<%@ Register Src="~/App/UCCommon/ucEventPackageTest.ascx" TagName="OrderPackage"
    TagPrefix="uc1" %>
<%@ Register Src="~/App/UCCommon/SponsoredByInfo.ascx" TagPrefix="uc2" TagName="SponsoredByInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">

        function popupmenu2(choice, wt, ht) {
            //debugger
            var winOpts = "toolbar=no,location=no,directories=no,status=no,scrolling=auto,scrollbars=no,menubar=no,width=" + wt + ",height=" + ht;
            confirmWin = window.open(choice, 'theconfirmWin', winOpts);
            //window.open(choice,'theconfirmWin',winOpts);
        }
        $(document).ready(function () {
            var decoded = $("<textarea/>").html($("#<%= lblVenue.ClientID %>").html()).text();
             $("#<%= lblVenue.ClientID %>").html(decoded);
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
            background: ;;;}
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
        
        .btn-submit-style { -moz-border-radius: 3px;}
    </style>
    <div class="divheadingtxtnew" id="headingtxt" runat="server">
    </div>
    <div style="width: 654px; clear: both;">
        <uc2:SponsoredByInfo ID="SponsoredByInfo" runat="server" />
    </div>
    <div style="width: 650px;">
        <div>
            <div style="float: left; width: 650px;">
                <div class="thankumsgrownew_prsmall1">
                    Step 6: Confirmation</div>
                <div class="maindivnonenew_prsmall1" style="padding-right: 10px; margin-top: 10px;">
                    <div class="graytxtright_prsmall">
                        <a href="#" style="font: normal 12px arial; color: #666;" id="aSmallReciept" runat="server">
                            <img src="/Content/Images/printer-icon.gif" />
                        </a>
                    </div>
                    <div class="graytxtright_prsmall">
                        <a href="#" style="font: normal 12px arial; color: #666;" id="imgPrintReciept" runat="server">
                            <img src="/Content/Images/appontmentconfirmation-icon.gif" />
                        </a>
                    </div>
                </div>
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
                                                    <img src="<%=IoC.Resolve<ISettings>().SmallLogo%>" width="239px" height="78px" />
                                                </td>
                                                <td align="right" style="color: #5DB3ED; width: 350px">
                                                    <u>Screening Appointment Confirmation&nbsp;</u>
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
                                        Below are your screening appointment details:<br />
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
                                                        <asp:Label ID="lblVenue" runat="server" Text=""></asp:Label></b><a href="" target="_blank" id="googleMapUrl" runat="server">[Map to the location]</a>
                                                        <br />
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                        <uc1:OrderPackage ID="_orderPackageTest" runat="server" />
                                        <%--<strong>Preparation for the screening:</strong> To learn how to prepare for your
                                        screening please follow the link below:<br />
                                        <a href="<%=IoC.Resolve<ISettings>().TestPreparationInstructions%>" target="_blank">Test Preparation</a><br />
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
                <div style="float: left;" id="divEmail" runat="server">
                    <i>The above information will be emailed to <b><span id="spEmail" runat="server"></span>
                    </b></i>within the hour.
                </div>
            </div>            
            <br />
            <p>
                <span style="float: right; padding-right: 35px;">
                    <%--<asp:ImageButton ID="ibtnNext" runat="server" OnClick="ibtnNext_Click" ImageUrl="~/Content/Images/next-orngbtn-PW.gif" />--%>
                    <asp:Button ID="NextButton" runat="server" onclick="NextButton_Click" Text="Next" CssClass="btn-submit-style" />
                </span>
            </p>
        </div>
    </div>
</asp:Content>
