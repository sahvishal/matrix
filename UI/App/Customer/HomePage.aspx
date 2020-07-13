<%@ Page Language="C#" MasterPageFile="~/App/Customer/CustomerMaster.master" AutoEventWireup="True"
    Inherits="App_Customer_NewCustomerDashboard" Title="Untitled Page" CodeBehind="HomePage.aspx.cs" %>

<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.Core.Interfaces" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>
<%@ Import Namespace="Falcon.App.Core.Enum" %>
<%@ Register Src="~/App/UCCommon/UCCustomerLeftInfo.ascx" TagName="CustomerUC" TagPrefix="CustLeft" %>
<%@ Register Src="~/App/UCCommon/ucHospitalPartnerBanner.ascx" TagName="HPBanner"
    TagPrefix="HPBanner" %>
<%@ Register Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" TagPrefix="UC" %>
<%@ Register Src="~/App/UCCommon/ViewOrderDetails.ascx" TagName="ViewOrderDetails"
    TagPrefix="orderDetails" %>
<%@ Register Src="~/App/UCCommon/ViewShippingDetails.ascx" TagName="ViewShippingDetails"
    TagPrefix="shippingDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <UC:JQueryToolkit ID="_jQuesryToolkit" runat="server" IncudeJQueryJTip="true" />
    <orderDetails:ViewOrderDetails ID="ViewOrderDetailsControl" runat="server" />
    <shippingDetails:ViewShippingDetails ID="ViewShippingDetailsControl" runat="server" />
    <script type="text/javascript" language="javascript">
        var GB_ROOT_DIR = "/App/Customer/Wizard/greybox/";
    </script>
    <script type="text/javascript" src="/App/Customer/Wizard/greybox/AJS.js"></script>
    <script type="text/javascript" src="/App/Customer/Wizard/greybox/AJS_fx.js"></script>
    <script type="text/javascript" src="/App/Customer/Wizard/greybox/gb_scripts_reloadonclose.js"></script>
    <link href="/App/Customer/Wizard/greybox/gb_styles.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">

        $(function () {
            $('.ready-crcstatus-tip').cluetip(
        {
            splitTitle: '|', cursor: 'pointer', tracking: true, cluetipClass: 'jtip', arrows: true, dropShadow: false, hoverIntent: false

        });
        });

        function ShowOrderDetailPopUp(orderId, orderTotal, paymentTotal, amountOwed, customerName, customerId) {
            ShowOrderDetailsDialog(orderId, orderTotal, paymentTotal, amountOwed, customerName, customerId);
            return false;
        }

        function NextBuild() {
            alert('Please check this in next release');
            return false;
        }

        function OpenPDFWindow(strurl) {
            var winOpts = "toolbar=no,location=no,directories=no,status=no,scrolling=auto,scrollbars=no,menubar=no,width=900,height=600";
            window.open(strurl, 'ResultsWindow', winOpts);
        }

        function popupmenu2(choice, wt, ht) {
            //debugger
            var winOpts = "toolbar=no,location=no,directories=no,status=no,scrolling=auto,scrollbars=yes,menubar=no,resizable=yes,width=" + wt + ",height=" + ht;
            confirmWin = window.open(choice, 'theconfirmWin', winOpts);
        }

        var openedWindow;
        function popupmenu3(choice, wt, ht) {
            if (openedWindow != undefined && !openedWindow.closed) {
                openedWindow.close();
            }
            var winOpts = "toolbar=no,location=no,directories=no,status=no,scrolling=auto,scrollbars=yes,menubar=no,width=" + wt + ",height=" + ht;
            confirmWin = window.open(choice, 'theconfirmWin', winOpts);
            openedWindow = confirmWin;
        }

        function showClinicalForm(key) {//debugger;
            var url = '/DigitalDelivery.aspx?key=' + key;
            var winOpts = "toolbar=no,location=no,directories=no,status=no,scrolling=auto,scrollbars=yes,menubar=no,resizable=yes,width=800,height=600,titlebar=0";
            confirmWin = window.open(url, 'ClinicalForm', winOpts);
        }

    </script>
    <style type="text/css">
        .wrapper_pop {
            float: left;
            width: 402px;
            padding: 10px;
            background-color: #F57C00;
        }

        .wrapperin_pop {
            float: left;
            width: 380px;
            padding: 10px;
            background-color: #fff;
        }

        .innermain_pop {
            float: left;
            width: 363px;
            padding: 0px 5px 0px 5px;
        }

        .innermain_1_pop {
            float: left;
            width: 363px;
            padding-top: 5px;
        }

        .inputfield180px_anp {
            float: left;
            width: 180px;
            font: bold 12px arial;
            color: #000;
        }

        .inputfield160px_anp {
            float: left;
            width: 160px;
            font: bold 12px arial;
            color: #000;
        }
    </style>
    <style type="text/css">
        .wrapper_pop {
            background: #f57c00;
            float: left;
            width: 402px;
            padding: 10px;
        }

        .wrapperin_pop {
            background: #fff;
            float: left;
            width: 380px;
            padding: 10px;
        }

        .innermain_pop {
            float: left;
            width: 363px;
            padding: 0 5px 0 5px;
        }

            .innermain_pop .signrow {
                float: left;
                width: 370px;
            }

                .innermain_pop .signrow .date {
                    float: right;
                    width: 100px;
                }

                .innermain_pop .signrow .sign {
                    float: left;
                    width: 150px;
                }

        .innermain_1_pop {
            float: left;
            width: 363px;
            padding-top: 5px;
        }

        .inputfield180px_anp {
            float: left;
            width: 180px;
            font: bold 12px arial;
            color: #000;
        }

        .inputfield160px_anp {
            float: left;
            width: 160px;
            font: bold 12px arial;
            color: #000;
        }

        .container {
            background: #fff;
            width: 500px;
            float: left;
        }

        .customerdetail {
            width: 491px;
            margin-top: 5px;
            border: dashed 2px #000;
            padding-left: 5px;
            float: left;
            display: none;
        }

            .customerdetail .inner {
                width: 460px;
                float: left;
                padding: 5px 0 5px 0;
            }

        .labelb {
            float: left;
            width: 140px;
            font-weight: bold;
        }

        .labeln {
            float: left;
            width: 310px;
        }

        .subh {
            float: left;
            width: 495px;
            margin-top: 10px;
            padding-left: 5px;
        }

            .subh .nobg {
                width: 495px;
                float: left;
                font-size: 14px;
                font-weight: bold;
            }

            .subh .bg {
                width: 495px;
                float: left;
                font-size: 14px;
                background: #e5e5e5;
                font-weight: bold;
            }

            .subh .plrow {
                width: 455px;
                float: left;
                padding-left: 40px;
            }

        .pnlmva {
            float: left;
            width: 422px;
        }

        .pnlnote {
            float: left;
            padding: 0 10px 0 10px;
            width: 402px;
            font-size: 10px;
            font-style: italic;
            color: #666;
        }

        #div {
            position: fixed;
            top: 20px;
            left: 10px;
        }
        /*---------- bubble tooltipPD -----------*/
        a.ttbig {
            position: relative;
            z-index: 24;
            color: #3ca3ff;
            font-weight: bold;
            text-decoration: none;
        }

        a.ttbig {
            position: relative;
            z-index: 24;
            color: #3ca3ff;
            font-weight: bold;
            text-decoration: none;
        }

            a.ttbig span {
                display: none;
            }

            a.ttbig:hover {
                z-index: 25;
                color: #aaf;
            }
                /*background:; ie hack, something must be changed in a for ie to execute it*/
                a.ttbig:hover span.tooltipPD {
                    display: block;
                    position: absolute;
                    top: 0;
                    left: -280px;
                    padding: 15px 0 0 0;
                    width: 320px;
                    color: #930;
                    text-align: left;
                    filter: alpha(opacity:90);
                    khtmlopacity: 0.90;
                    mozopacity: 0.90;
                    opacity: 0.90;
                }

                a.ttbig:hover span.top {
                    display: block;
                    padding: 30px 8px 0;
                    background: url(/App/Images/bubblebigleft.gif) no-repeat top;
                }

                a.ttbig:hover span.middle {
                    display: block;
                    padding: 0 8px;
                    background: url(/App/Images/bubblefillerbig.gif) repeat bottom;
                }

                a.ttbig:hover span.bottom {
                    display: block;
                    padding: 3px 8px 10px;
                    color: #548912;
                    background: url(/App/Images/bubblebigleft.gif) no-repeat bottom;
                }
    </style>

    <style type="text/css">
        input[type="button"].anchor-button {
            font-family: Arial;
            background: -moz-linear-gradient(to bottom, #FCB97E 0%, #F07605 100%) repeat scroll 0 0 transparent;
            background: -webkit-linear-gradient(to bottom, #FCB97E 0%, #F07605 100%) repeat scroll 0 0 transparent;
            background: linear-gradient(to bottom, #FCB97E 0%, #F07605 100%) repeat scroll 0 0 transparent;
            border: 1px solid #F07605;
            border-radius: 0.5em 0.5em 0.5em 0.5em;
            box-shadow: 0 1px 2px rgba(0, 0, 0, 0.2);
            color: #FFFFFF;
            cursor: pointer;
            display: inline-block;
            font-size: 13px;
            font-weight: bold;
            line-height: 13px;
            outline: medium none;
            padding: 5px 8px !important;
            text-align: center;
            text-decoration: none;
            text-shadow: 0 1px 1px rgba(0, 0, 0, 0.3);
            vertical-align: baseline;
        }
    </style>
    <script type="text/javascript" src="/App/JavascriptFiles/HttpRequest.js"></script>
    <script language="javascript" type="text/javascript" src="/App/JavascriptFiles/GeneralJSPopUp.js"></script>
    
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $('.jTip').cluetip({ splitTitle: '|', cursor: 'pointer', tracking: true, cluetipClass: 'jtip', arrows: true, dropShadow: false, hoverIntent: false });
        });
    </script>
    <script type="text/javascript" language="javascript">
        function popupacrobat(choice, wt, ht) {
            var winOpts = "toolbar=no,location=no,directories=no,status=no,scrolling=auto,scrollbars=yes,menubar=no,width=" + wt + ",height=" + ht;
            confirmWin = window.open(choice, 'theconfirmWin', winOpts);
            window.open(choice, 'theconfirmWin', winOpts);
        }

        function updateDownloadInfo(cdContentTrackingId) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json", url: "/Operations/CdContentTracking/UpdateDowloadinfo?id=" + cdContentTrackingId, data: '{}',
                success: function (result) { }, error: function (a, b, c) { }
            });
        }

        function ShowFullfillmentMessage() {
            alert("There is already a unprocessed shipping request in your order. Duplicate shipping cannot be added till this shipping request is processed.");
            return false;
        }

        function ShowRefundRequestShippingMessage() {
            alert('You have already requested for the removal of shipping for this event, the removal request is in process. Re-purchase of shipping is not allowed unless the request is resolved. Please call <%= IoC.Resolve<ISettings>().CustomerPortalPhoneTollFree %> (Toll-free) for assistance.');
            return false;
        }

        function ShowAddOnProductMessage() {
            alert("You have already purchased the images. Duplicate images are not allowed, Please call <%= IoC.Resolve<ISettings>().CustomerPortalPhoneTollFree %> (Toll-free) for assistance.");
            return false;
        }

        function ShowRefundRequestProductMessage() {
            alert("You has already requested for the removal of images for this event, the removal request is in process. Re-purchase of images is not allowed unless the request is resolved. Please call <%= IoC.Resolve<ISettings>().CustomerPortalPhoneTollFree %> (Toll-free) for assistance.");
            return false;
        }
    </script>
    <div class="maindiv_custdbrd">
        <div class="mindivbgblue_custdbrd">
            <span class="divheadtxt_custdbrd">
                <%= IoC.Resolve<ISettings>().CompanyName%>
                Wellness Portal</span>
            <div style="float: right; width: 340px; padding-top: 3px;" id="divLastLogin" runat="server">
                <span style="float: left; width: 7px;">
                    <img src="/App/Images/leftroundlastlogin.gif" alt="" /></span> <span style="float: left; width: 320px; padding: 1px; text-align: center; background-color: #FFD4A8; border-top: solid 1px #F1B678; border-bottom: solid 1px #F1B678;"><span style="color: #000;" id="spLastLogin" runat="server">Your last login time:</span></span> <span style="float: left">
                        <img src="/App/Images/rightroundlastlogin.gif" alt="" /></span>
            </div>
        </div>
        <div id="Div1" class="leftcon_main_custdbrd" style="margin-bottom: 5px">
            <CustLeft:CustomerUC ID="uc1" runat="server" OnLoad="SetName" />
        </div>
        <div class="main_area_custdbrd">
            <HPBanner:HPBanner ID="ucHPBanner" runat="server" />
            <div class="main_row_custdbrd">
                <div class="headingbox_default">
                    <span class="orngheadtxt_default">My Screening History</span>
                </div>
                <div class="divrightbtnbox_mvdbrd" style="float: right; display: none">
                    <span style="float: right; padding-top: 5px">
                        <asp:ImageButton ID="ibtTopNext" runat="server" ImageUrl="~/App/Images/MV/rightarrow-btn-mvdbrd-d.gif"
                            OnClick="lnknavigation_Click" CommandArgument="N" CommandName="Navigation" Enabled="False" />
                    </span><span style="float: right">
                        <img src="../Images/MV/middlec-btn-event.gif" /></span> <span style="float: right; padding-top: 5px">
                            <asp:ImageButton ID="ibtTopPrevious" runat="server" ImageUrl="~/App/Images/MV/leftarrow-btn-mvdbrd-d.gif"
                                OnClick="lnknavigation_Click" CommandArgument="P" CommandName="Navigation" Enabled="False" /></span>
                </div>
            </div>
            <%--::::::::::::::::::::::::::::::::::::::::::--%>
            <div class="main_row_custdbrd">
                <asp:GridView ID="grdCustomerEvents" DataKeyNames="EventCustomerID" runat="server"
                    AutoGenerateColumns="false" ShowHeader="false" GridLines="None" OnRowDataBound="grdCustomerEvents_RowDataBound">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <div class="hr">
                                </div>
                                <div class="divbottomboxes_cd">
                                    <div class="divbluboxbodybg_cd" id="divmain" runat="server">
                                        <div class="bigbluboxrow_cd">
                                            <span class="blutxt14ptbold_cd" id="spEventName" runat="server"><span>
                                                <%# DataBinder.Eval(Container.DataItem, "EventName")%>
                                            </span></span>
                                        </div>
                                        <div class="bigbluboxrow_cd">
                                            <span class="titletextnowidth_default">Venue:</span> <span class="normaltextnowidth_default">
                                                <%# DataBinder.Eval(Container.DataItem,"Address") %>
                                                [&nbsp;<a href='<%# DataBinder.Eval(Container.DataItem,"GoogleMap") %>' style='font-size: 8pt;'
                                                    target='_blank'>Map to this location</a> &nbsp;] </span>
                                        </div>
                                        <div class="twocolumnbox_cd">
                                            <div style="float: left; width: 400px;">
                                                <div class="bigbluboxleft_custdbrd">
                                                    <p class="bigbluboxleftrow_custdbrd">
                                                        <span class="titletextnowidth_default">Date Registered:</span> <span class="normaltextnowidth_default">
                                                            <%# DataBinder.Eval(Container.DataItem, "RegisterDate")%>
                                                        </span>
                                                    </p>
                                                    <p class="bigbluboxleftrow_custdbrd">
                                                        <span class="titletextnowidth_default">When:</span> <span class="normaltextnowidth_default">
                                                            <%# DataBinder.Eval(Container.DataItem,"EventDate") %>
                                                            at
                                                            <%# DataBinder.Eval(Container.DataItem,"Appointment") %>
                                                        </span>
                                                    </p>
                                                    <p class="bigbluboxleftrow_custdbrd">
                                                        <span class="titletextnowidth_default">Screening Cost:</span> <span class="normaltextnowidth_default">
                                                            <%# DataBinder.Eval(Container.DataItem,"Cost") %>
                                                        </span>
                                                    </p>
                                                    <p class="bigbluboxleftrow_custdbrd">
                                                        <span id="spDiscount" runat="server"><span class="titletextnowidth_default">Discount:
                                                        </span><span class="normaltextnowidth_default">
                                                            <%# DataBinder.Eval(Container.DataItem,"Discount") %>
                                                        </span></span>
                                                    </p>
                                                    <p class="bigbluboxleftrow_custdbrd">
                                                        <span class="titletextnowidth_default">Order:</span> <span class="normaltextnowidth_default"
                                                            id="_spnPaymentDetails" runat="server"><a id="PaymentLinkAnchor" runat="server" href="#">
                                                                <b>View&nbsp;Detail</b></a></span><span style="float: left; padding: 2px 0px 0px 2px;"
                                                                    id="spAcceptPayment" runat="server">[ <a href="#" id="aAcceptPayment" runat="server">Make Payment</a> ] </span>
                                                    </p>
                                                    <p class="bigbluboxleftrow_custdbrd">
                                                        <span class="titletextnowidth_default">Shipping:</span> <span class="normaltextnowidth_default"
                                                            id="ShippingDetailSpan" runat="server"><a id="ShippingDetailAnchor" runat="server"
                                                                href="#"><strong>Shipping&nbsp;Details</strong></a></span>
                                                    </p>
                                                    <p class="bigbluboxleftrow_custdbrd" id="medicalHistoryContainer" runat="server">
                                                        <span class="titletextnowidth_default" style="margin-top: 6px;">Health Assessment Form:</span>
                                                        <span class="normaltextnowidth_default">
                                                            <span id="spMedicalHistory" runat="server"></span>
                                                            <a href="#" style="text-decoration: none;" rel="gb_page_center[860, 500]" runat="server" id="amedicalhistory"></a>
                                                        </span>
                                                    </p>

                                                    <p class="bigbluboxleftrow_custdbrd" id="mspformContainer" runat="server">
                                                        <span class="titletextnowidth_default">MSP Form:</span>
                                                        <span class="normaltextnowidth_default">
                                                            <span id="mspHistory" runat="server"></span>
                                                            (<a href="#" style="text-decoration: none;" rel="gb_page_center[1000, 500]" runat="server" id="mspHistoryForm">View</a>)
                                                        </span>
                                                    </p>

                                                    <div class="bigbluboxleftrow_custdbrd" id="divGeneratePdf" runat="server" style="margin-top: 90px; display: none;">
                                                        <span style="float: left;"><a href='javascript:void(0);' id="aPDFReport" runat="server">
                                                            <img src="/App/Images/Customer/downloadResults-btn.gif" />
                                                        </a></span>
                                                    </div>
                                                   
                                                    <div class="bigbluboxleftrow_custdbrd" id="CdContainerDiv" runat="server" style="margin-top: 10px; display: none;">
                                                        <span style="float: left;"><a href='javascript:void(0);' id="CdDownloadAnchor" runat="server" target="_blank">
                                                            <img src="/App/Images/Customer/downloadImage-btn.gif" /></a> </span>
                                                    </div>
                                                    <div class="bigbluboxleftrow_custdbrd" id="PremiumReportContainerDiv" runat="server" style="margin-top: 10px; display: none;">
                                                        <span style="float: left;">
                                                            <a href='javascript:void(0);' id="aPdfReportWithImages" runat="server">
                                                                <img src="/App/Images/Customer/DownloadPremiumPDF.gif" />
                                                            </a>
                                                        </span>
                                                    </div>
                                                    <div class="bigbluboxleftrow_custdbrd" id="ViewResults" runat="server" style="margin-top: 10px; display: none;">
                                                        <span style="float: left;"><a id="ViewResultsLink" runat="server">
                                                            <img src="/App/Images/customer/ViewResults.gif" /></a> </span>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="smallboxrightmain_custdbrd" style="text-align: center;">
                                                <div class="smallboxright_custdbrd">
                                                    <div class="smallblubox_custdbrd">
                                                        <p class="smallbluboxtopbg_custdbrd">
                                                            <img src="../Images/specer.gif" height="8" width="210" />
                                                        </p>
                                                        <div class="smallbluboxmidbg_custdbrd">
                                                            <p class="smallbluboxmidrow_custdbrd">
                                                                <span class="titletextnowidth_default">Event Status:</span> <span class="normaltextnowidth_default">
                                                                    <%#DataBinder.Eval(Container.DataItem, "EventStatus")%>
                                                                </span>
                                                            </p>
                                                            <p class="smallbluboxmidrow_custdbrd" id="ViewResultsContainer" runat="server" style="display: none;">
                                                                <span class="titletextnowidth_default">Result Status:&nbsp;<%#DataBinder.Eval(Container.DataItem, "TestResult")%></span>
                                                            </p>
                                                            <%--<p class="smallbluboxmidrow_custdbrd">
                                                                <span class="titletextnowidth_default">Screening Authorization:</span> <span class="normaltextnowidth_default">
                                                                    <a href="javascript:void(0);" id="aViewAuthorization" runat="server">View</a>
                                                                </span>
                                                            </p>--%>
                                                            <p class="smallbluboxmidrow_custdbrd">
                                                                <span class="titletextnowidth_default">Print:</span> <span class="normaltextnowidth_default">
                                                                    <a id="aReciept" runat="server" href="#">Appointment Confirmation</a> </span>
                                                            </p>
                                                            <p class="smallbluboxmidrow_custdbrd">
                                                                <span class="titletextnowidth_default">Print:</span> <span class="normaltextnowidth_default">
                                                                    <a id="aSmallReciept" runat="server" href="#">Payment Receipt</a> </span>
                                                            </p>
                                                        </div>
                                                        <p class="smallbluboxbotbg_custdbrd">
                                                            <img src="../Images/specer.gif" height="7px" width="210px" />
                                                        </p>
                                                    </div>
                                                    <div id="ShippingOptionDiv" runat="server" style="float: left; width: 210px; margin-top: 10px; height: 30px; padding-top: 8px; color: #000000; border-radius: 5px; border: solid 1px #999999; background: -moz-linear-gradient(center top , #F5F5F5, #E8E8E8) repeat scroll 0 0 transparent;">
                                                        <a id="ShippingOptionAnchor" runat="server" style="text-decoration: none; color: #000000;">
                                                            <b>Purchase Additional Copy of Results</b>
                                                        </a>
                                                    </div>
                                                    <div id="ImagesOptionDiv" runat="server" style="float: left; width: 210px; margin-top: 10px; height: 30px; padding-top: 8px; color: #000000; border-radius: 5px; border: solid 1px #999999; background: -moz-linear-gradient(center top , #F5F5F5, #E8E8E8) repeat scroll 0 0 transparent;">
                                                        <a id="ImagesOptionAnchor" runat="server" style="text-decoration: none; color: #000000;">
                                                            <b>Purchase Images</b>
                                                        </a>
                                                    </div>
                                                    <%--<img src="/App/Images/customer/btn-addcopyresult.gif" alt="" />--%>
                                                    <div style="float: left; width: 220px; margin-top: 30px; padding: 5px; background: #fff; border: dashed 1px #4989ac; display: none;" id="DownlodAdobeReaderDiv" runat="server">
                                                        <h3>Trouble viewing your results?</h3>
                                                        Make sure the latest version of Adobe Reader is installed on your computer.<br />
                                                        <a href="javascript:popupmenu2('AcrobatDownload.aspx',620,450)">Click here to download
                                                            Acrobat Reader</a>
                                                    </div>
                                                    <div style="float: left; width: 220px; margin-top: 30px; padding: 5px; background: #fff; border: dashed 1px #4989ac; display: none;"
                                                        id="ImageDownloadInstructions" runat="server">
                                                        <h3>Image Download Instructions.</h3>
                                                        <a href="../../Config/Content/Html/CDDownloadInstructions.pdf" target="_blank">Click here to get step
                                                            by step instructions how to download images.</a>
                                                    </div>
                                                </div>
                                                <asp:Panel ID="divHighRiskPanel" runat="server" CssClass="wrapper_hrbox">
                                                    <div class="top">
                                                        <img src="../Images/specer.gif" height="8px" width="252px" />
                                                    </div>
                                                    <div class="mid">
                                                        <p class="row" style="text-align: center; display: none;">
                                                            <img src="../Images/customer/highrisk-symbol.gif" />
                                                        </p>
                                                        <p class="row" style="margin-top: 5px">
                                                            If you have questions about your results, call toll-free:
                                                            <%# DataBinder.Eval(Container.DataItem, "AssociatedPhoneNumber")%>
                                                        </p>
                                                        <p class="row" style="margin-top: 15px; display: none;">
                                                            <span style="float: left; padding-top: 6px; padding-left: 20px">
                                                                <img src="../Images/customer/findaphysician.gif" /></span> <span style="float: left; padding-left: 10px;">
                                                                    <asp:ImageButton ID="ibtnsearch" runat="server" ImageUrl="~/App/Images/search-orng-btn.gif"
                                                                        OnClientClick="alert('Will connect to St David\'s database.'); return false;" /></span>
                                                        </p>
                                                    </div>
                                                    <div class="bot">
                                                        <img src="../Images/specer.gif" height="8px" width="252px" />
                                                    </div>
                                                </asp:Panel>
                                            </div>
                                        </div>
                                        <p class="bigbluboxrow_cd" style="width: 610px;">
                                            <span class="nbtndiv_custdbrd" style="display: none;">
                                                <asp:ImageButton ID="imgReview" runat="server" ImageUrl="~/App/Images/Customer/write-review-nbtn.gif"
                                                    Visible="false" />
                                            </span><span class="nbtndiv_custdbrd" id="spimgReschedule" runat="server" style="margin-top: 5px">
                                                <asp:ImageButton ID="imgReschedule" runat="server" ImageUrl="~/App/Images/Customer/Reschedule-nbtn.gif"
                                                    CommandName='<%# DataBinder.Eval(Container.DataItem,"EventID") %>' CommandArgument='<%#DataBinder.Eval(Container.DataItem,"EventCustomerID") %>'
                                                    OnClick="imgReschedule_Click" />
                                            </span><span class="nbtndiv_custdbrd" style="display: none;">
                                                <asp:ImageButton ID="ibtnviewresults" runat="server" ImageUrl="~/App/Images/Customer/view-results-nbtn.gif"
                                                    Visible="false" />
                                            </span>
                                        </p>
                                        <p>
                                            <img src="/App/Images/specer.gif" width="600" height="10" />
                                        </p>
                                    </div>
                                    <div class="divbluboxbotbg_cd" id="divbottom" runat="server">
                                        <img src="/App/Images/specer.gif" width="50" height="5" />
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle CssClass="row1" />
                    <RowStyle CssClass="row2" />
                    <AlternatingRowStyle CssClass="row3" />
                </asp:GridView>
            </div>
            <br />
            <div class="divnoitemfound_custdbrd" style="display: block" id="dvNoItemFound" runat="server">
                <p class="divnoitemtxt_custdbrd">
                    <span class="orngbold18_default">No Event Found</span>
                </p>
            </div>
            <%--:::::::::::::::::::::::::::::::::::::::::::--%>
        </div>
    </div>
    <a id="aSmallRecieptSecond" runat="server" href="#"></a>
</asp:Content>
