<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectAppointment.aspx.cs"
    MasterPageFile="~/App/CallCenter/NewCallCenterMaster.master" Inherits="Falcon.App.UI.App.CallCenter.CallCenterRep.ExistingCustomer.SelectAppointment"
    Title="Select Appointment and Fullfillment Option" EnableEventValidation="false" %>

<%@ Register Src="~/App/UCCommon/OrderSummary.ascx" TagName="OrderSummary" TagPrefix="SummaryControl" %>
<%@ Register Src="~/App/UCCommon/UCEventAppointment.ascx" TagName="UCEventAppointment"
    TagPrefix="uc1" %>
<%@ Register Src="~/App/UCCommon/UcShippingDetails.ascx" TagPrefix="uc" TagName="ShippingOption" %>
<%@ Register Src="~/App/UCCommon/ProductOptions.ascx" TagPrefix="uc" TagName="Product" %>
<%@ Import Namespace="Falcon.App.Core.Scheduling.Enum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="/Content/JavaScript/StartUp.js"></script>

    <script type="text/javascript" language="javascript">

        function selectResultOrder(resultOrderId) {

            var hfResultOrderID = document.getElementById("<%= hfResultOrderID.ClientID %>");
            var hfResultOrderPrice = document.getElementById("<%= hfResultOrderPrice.ClientID %>");
            var hfResultOrderDesc = document.getElementById("<%= hfResultOrderDesc.ClientID %>");

            var SelectedOrderRadio = document.getElementById("rbtn" + resultOrderId);
            if (SelectedOrderRadio.checked == true) {
                var spSalePrice = document.getElementById("spSalePrice" + resultOrderId);
                var spTitle = document.getElementById("spTitle" + resultOrderId);
                hfResultOrderID.value = resultOrderId;
                hfResultOrderPrice.value = spSalePrice.innerHTML;
                hfResultOrderDesc.value = spTitle.innerHTML;
                SetFulfillmentOption(spTitle.innerHTML, spSalePrice.innerHTML);

            }
            return true;
        }

        function FirstTimeLoad(resultOrderId) {//debugger;
            var SelectedOrderRadio = document.getElementById("rbtn" + resultOrderId);
            SelectedOrderRadio.checked = true;
            selectResultOrder(resultOrderId);
        }

        function MaintainAfterFailedPostBack() {
            //for maintaing state after postback made for applying coupon           

            var hfResultOrderID = document.getElementById("<%= hfResultOrderID.ClientID %>");
            var SelectedOrderRadio = document.getElementById("rbtn" + hfResultOrderID.value);
            SelectedOrderRadio.checked = true;
            selectResultOrder(parseInt(hfResultOrderID.value));
        }
    </script>

    <script type="text/javascript" language="javascript">

        function NextButtonClick() {
            OpenUpsellCDDialog(Validation);
            return false;
        }

        function Validation() {

            if (!isAppointmentSelected()) {
                alert("Please select an appointment.");
                return false;
            }

            if (!ValidateShippingAddress())
                return false;
            $("#SpanNextButton").hide();
            $("#spnNextButtonIndicator").show();

            __doPostBack('NextButton', 'Click');
        }
    </script>

    <div class="wrapper_inpg">
        <div class="maindivredmsgbox" id="ErrorDiv" runat="server" visible="false">
        </div>
        <div class="main_bdrccrep">
            <div class="maincontentrow_ccrep">
                <div class="regcust_innercon">
                    <div class="pgnosymbol_regcust">
                        <img src="/App/Images/CCRep/page4symbol.gif" alt="" />
                    </div>
                    <div class="middivrow_regcust" style="width: 430px;">
                        <p class="contentrow_regcust">
                            <span class="orngheadtxt_regcust" runat="server" id="StepTitleContainer">Existing Customer</span>
                        </p>
                        <p class="fline_regcust" style="width: 420px;">
                        </p>
                        <div style="display: none;">
                            <p class="contentrow_regcust" style="width: 420px;">
                                <span class="orngsmalltxt_regcust">What appointment time is best for you? Let me tell
                                    you what we have available.</span>
                            </p>
                            <p class="contentrow_regcust" style="width: 420px;">
                                <span class="centertxtfieldcon_pw">
                                    <asp:TextBox ID="txtSlot" runat="server" CssClass="inputblue_pw" ReadOnly="true"
                                        Text="" Width="180px"></asp:TextBox>
                                </span>
                            </p>
                            <p style="float: left; width: auto; padding-left: 150px;">
                                <span style="float: left; width: 200px; text-align: center;">
                                    <asp:Label runat="server" ID="lblTimeZone" CssClass="gridselectpackage_testname" />
                                </span>
                            </p>
                        </div>
                        <uc1:UCEventAppointment ID="_ucEventAppointment1" runat="server" />
                        <div class="fline_regcust" style="width: 420px;">
                        </div>
                        <div style="float: left; width: 420px;" id="ProductOptionDiv">
                            <div class="dgselectpackage_ccrep">
                                <uc:Product ID="ProductOption" runat="server" />
                            </div>
                            <div class="fline_regcust" style="width: 420px;">
                            </div>
                        </div>
                        <p class="contentrow_regcust" style="display: none;">
                            <span class="bluesmalltxt_regcust">Do you want your screening report to be shipped at
                                your place</span> <span class="radiatxtbox_pw">
                                    <asp:RadioButton ID="rbtReportMailY" Checked="true" runat="server" GroupName="ReportMail"
                                        AutoPostBack="false" />YES </span><span class="radiatxtbox_pw">
                                            <asp:RadioButton ID="rbtReportMailN" runat="server" GroupName="ReportMail" AutoPostBack="false" />NO</span>
                            <span class="fline_regcust" style="width: 420px;"></span>
                        </p>
                        <div id="divOrderCatalog" runat="server" style="float: left; width: 420px;">
                            <p class="contentrow_regcust">
                                <span class="orngsmalltxt_regcust">Select your fulfillment option</span>
                            </p>
                            <div class="dgselectpackage_ccrep">
                                <uc:ShippingOption ID="ResultOption" runat="server" />
                            </div>
                        </div>
                        <div class="fline_regcust" style="width: 420px;">
                        </div>
                        <div style="width: 420px;">
                            <p class="buttoncell_ccrep">
                                <span class="buttoncon_ccrep">
                                    <asp:ImageButton ID="ibtnBack" runat="server" ImageUrl="~/App/Images/back-button.gif"
                                        OnClick="ibtnBack_Click" />
                                </span><span class="buttoncon_ccrep" style="visibility: hidden; display: none;" id="spnNextButtonIndicator">
                                    <img src="/App/Images/indicator.gif" />
                                </span><span class="buttoncon_ccrep" style="visibility: visible; display: block;"
                                    id="SpanNextButton">
                                    <asp:ImageButton ID="ibtnSubmit" runat="server" ImageUrl="~/App/Images/next-buton.gif"
                                        OnClientClick="return NextButtonClick();" />
                                </span>
                            </p>
                        </div>
                    </div>
                    <div style="width: auto; float: right;">
                        <div class="rightdivrow_regcust" id="divCall" runat="server" style="float: right;">
                            <div class="timeboard_ccrep_dboard">
                                <div class="timeboxbg_ccrep_dboard">
                                    <p class="tboxrow_ccrep_dboard">
                                        <span class="timetxt_ccrep_dboard"><span id="HH"></span>:<span id="MM"></span>:<span
                                            id="SS"></span></span>
                                    </p>
                                    <p class="tboxrowformat_ccrep_dboard">
                                        <span class="smallgraytxt_ccrep">(HH:MM:SS)</span>
                                    </p>
                                    <p class="tboxrowbtm_ccrep_dboard">
                                        <span class="whttxt_ccrep_dboard">Call in Progress</span>
                                    </p>
                                </div>
                            </div>
                            <div class="endcall_ccrep_dboard">
                                <span class="endtbtn_ccrep_dboard">
                                    <asp:ImageButton ID="imgEndCall" runat="server" ImageUrl="~/App/Images/CCRep/endcallbtn.gif"
                                        OnClientClick="closeScriptPopup(); CallNotes(); return false;" />
                                </span>
                            </div>
                        </div>
                        <div class="both">
                        </div>
                        <div style="width: 255px; float: left; margin-top: 10px">
                            <SummaryControl:OrderSummary ID="OrderSummaryControl" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField runat="server" ID="hfCallStartTime" />
    <asp:HiddenField runat="server" ID="hfResultOrderID" Value="0" />
    <asp:HiddenField runat="server" ID="hfResultOrderPrice" Value="" />
    <asp:HiddenField runat="server" ID="hfResultOrderDesc" />
    <script language="javascript" type="text/javascript">
        //// this will run after page is load
        var hfCallStartTime = document.getElementById("<%= this.hfCallStartTime.ClientID %>");
        StartTimer(hfCallStartTime);
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            _setOrderSummaryAppointmentTime = SetAppointmentTime;

            checkAndOpenScriptPopup();
        });

    </script>
    <script type="text/javascript">
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
            m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', 'https://www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-957361-18', 'auto');
        ga('send', 'pageview');

        
    </script>
</asp:Content>
