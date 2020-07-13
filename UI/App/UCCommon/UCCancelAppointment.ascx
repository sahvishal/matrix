<%@ Control Language="C#" AutoEventWireup="true" Inherits="Falcon.App.UI.App.UCCommon.UCCancelAppointment"
    CodeBehind="UCCancelAppointment.ascx.cs" %>
<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.Core.Finance.Enum" %>
<%@ Import Namespace="Falcon.App.Core.Scheduling.Enum" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="uc" Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" %>
<%@ Register Src="~/App/UCCommon/ViewOrderDetails.ascx" TagName="ViewOrderDetails"
    TagPrefix="orderDetails" %>
<uc:JQueryToolkit ID="_jQueryToolkit" runat="server" IncludeAjax="true" IncludeJQueryUI="true"
    IncudeJQueryAutoComplete="true" IncludeJQueryMaskInput="true" />
<orderDetails:ViewOrderDetails ID="_viewOrderDetailsControl" runat="server" />
<style type="text/css">
    /*---------- bubble tooltip -----------*/ a.tt {
        position: relative;
        z-index: 24;
        color: #3CA3FF;
        font-weight: bold;
        text-decoration: none;
    }

        a.tt span {
            display: none;
        }
        /*background:; ie hack, something must be changed in a for ie to execute it*/ a.tt:hover {
            z-index: 25;
            color: #aaaaff;
        }

            a.tt:hover span.tooltip {
                display: block;
                position: absolute;
                top: 0px;
                left: 0;
                padding: 15px 0 0 0;
                width: 320px;
                color: #993300;
                text-align: left;
                filter: alpha(opacity:90);
                khtmlopacity: 0.90;
                mozopacity: 0.90;
                opacity: 0.90;
            }

            a.tt:hover span.top {
                display: block;
                padding: 30px 8px 0;
                background: url(/App/Images/bubblebig.gif) no-repeat top;
            }

            a.tt:hover span.middle {
                /* different middle bg for stretch */
                display: block;
                padding: 0 8px;
                background: url(/App/Images/bubblefillerbig.gif) repeat bottom;
            }

            a.tt:hover span.bottom {
                display: block;
                padding: 3px 8px 10px;
                color: #548912;
                background: url(/App/Images/bubblebig.gif) no-repeat bottom;
            }
</style>
<script language="javascript" type="text/javascript">

    function txtkeypress(evt) {
        return KeyPress_DecimalAllowedOnly(evt);
    }


    function OpenCloseDiv(ddlpaymentmode_clientid) {
        var ddlpaymentmode = document.getElementById(ddlpaymentmode_clientid);
        if (ddlpaymentmode.selectedIndex == 0)
            return;

        var paymentmode = ddlpaymentmode.options[ddlpaymentmode.selectedIndex].value;

        document.getElementById('<%= bycreditcard.ClientID %>').style.display = 'none';
        document.getElementById('<%= bycheque.ClientID %>').style.display = 'none';
        document.getElementById('<%= byCreditCardOld.ClientID %>').style.display = 'none';
        var hfpaymode = document.getElementById('<%= spdbpaymentmode.ClientID %>');
        hfpaymode.value = paymentmode;

        if (paymentmode == '<%= PaymentType.CreditCard.PersistenceLayerId %>') {
            document.getElementById('<%= bycreditcard.ClientID %>').style.display = 'block';
        }
        else if (paymentmode == '<%= PaymentType.Check.PersistenceLayerId %>') {
            document.getElementById('<%= bycheque.ClientID %>').style.display = 'block';
        }
        else if (paymentmode == '<%= PaymentType.CreditCardOnFile_Value %>') {
            document.getElementById('<%= byCreditCardOld.ClientID %>').style.display = 'block';
        }
}

function Validation() {
    var cancelReasonddlClintId = '<%= CancellationReasonddlList.ClientID %>';
        
    var cancelationReasonddl = Number($("#" + cancelReasonddlClintId).val());
    if (cancelationReasonddl <= 0) {
        alert("Please Select Reason for Cancelation.");
        return false;
    }
    
    if ($('#' + '<%=CancellationSubReasonddlList.ClientID %> option').length > 1 && $('#' + '<%=CancellationSubReasonddlList.ClientID %>').val() <= "0")
    {
        alert("Please Select Sub Reason.");
        return false;
    }
    
    var notes = $('#' + '<%=txtReason.ClientID %>').val();

    if(($("#" + cancelReasonddlClintId).val() === '<%= (long)CancelAppointmentReason.PersonalReasons%>' || $("#" + cancelReasonddlClintId).val() === '<%= (long)CancelAppointmentReason.Other%>') && $.trim(notes) == "")
    {
        alert("Please enter notes.");

        return false;
    }

    if ('<%= IoC.Resolve<ISettings>().IsRefundQueueEnabled %>' == '<%= bool.TrueString %>' && Number('<%= TotalAmountRefundable %>') > 0) {
        if ($("textarea[id='Reason']").val() == '') {
            alert("Refund reason is required.");
            return false;
        }
        return true;
    }
    else if ('<%= IoC.Resolve<ISettings>().IsRefundQueueEnabled %>' == '<%= bool.FalseString %>')
    {
        if ($.trim($("#<%= txtReason.ClientID %>").val()).length == 0) {
            alert("Reason for Cancelation is required.");
            return false;
        }
    }
       

        //debugger;
    var ddlpaymentmode = document.getElementById('<%= ddlpaymentmode.ClientID %>');
        if (parseFloat(document.getElementById('<%= txtAmount.ClientID %>').value) > parseFloat(document.getElementById('<%= spAmountPaid.ClientID %>').innerHTML)) {
            alert('Refund amount cannot be greater than amount paid.Please make sure correct amount is refunded.');
            return false;
        }

        if (ddlpaymentmode != null && ddlpaymentmode.selectedIndex == 0) {
            alert('Please Select a payment mode.');
            return false;
        }

        var paymentmode = '';

        if (ddlpaymentmode != null)
            paymentmode = ddlpaymentmode.options[ddlpaymentmode.selectedIndex].value;
        else
            paymentmode = document.getElementById("<%= spdbpaymentmode.ClientID %>").value;

        if (paymentmode == '<%= PaymentType.CreditCard.PersistenceLayerId %>') {
            var ddlCCType = document.getElementById("<%= ddlcardtype.ClientID %>");
            var txtCCNo = document.getElementById("<%= txtCardNo.ClientID %>");
            var txtExpirationDate = document.getElementById("<%= txtExpirationDate.ClientID %>");
            var txtSecurityNo = document.getElementById("<%= txtSecurityNum.ClientID %>");
            var txtCName = document.getElementById("<%= txtCardHolderName.ClientID %>");

            if ((checkDropDown(ddlCCType, "Credit Card Type") == false))
                return false;

            if (isBlank(txtCCNo, "Credit Card Number"))
                return false;

            if (isValidCreditCard(ddlCCType.options[ddlCCType.selectedIndex].text, txtCCNo.value) == false) {
                alert('Invalid Credit Card format.');
                ddlCCType.focus();
                return false;
            }

            if (isBlank(txtCName, "Name on Card"))
                return false;

            if (isBlank(txtExpirationDate, "Expiry Date"))
                return false;
            //debugger
            if (!validateExpiryDate(txtExpirationDate, "Expiry Date"))
                return false;
            if (!CheckCCExpiryDate(txtExpirationDate, "Credit Card"))
                return false;
            if (isBlank(txtSecurityNo, "Sequrity Number"))
                return false;


            var txtAddress1 = document.getElementById("<%= txtAddress1.ClientID %>");
            var txtCity = document.getElementById("<%= txtCity.ClientID %>");
            var ddlState = document.getElementById("<%= ddlstate.ClientID %>");
            var txtZip = document.getElementById("<%= txtZip.ClientID %>");

            if (isBlank(txtAddress1, "Address")) { return false; }
            if (checkLength(txtAddress1, 500, "Address")) { return false; }
            if (checkDropDown(ddlState, "State for  Address") == false) { return false; }
            if (isBlank(txtCity, "City for  Address")) { return false; }
            if (isBlank(txtZip, "Zip")) { return false; }
        }
        if (paymentmode == '<%= PaymentType.Check.PersistenceLayerId %>') {
            if (isBlank(document.getElementById('<%= txtChequeNum.ClientID %>'), "Check Number")) { return false; }
        }

        $(".buttoncon_default").toggle();

        return true;
    }

    function txtkeypress(evt) {
        return KeyPress_DecimalAllowedOnly(evt);
    }

    function ManageInputBoxes(boldisabled) {
        if (document.getElementById('<%= bycreditcard.ClientID %>').style.display == "block") {
            var ddlCCType = document.getElementById("<%= ddlcardtype.ClientID %>");
            var txtCCNo = document.getElementById("<%= txtCardNo.ClientID %>");
            var txtExpirationDate = document.getElementById("<%= txtExpirationDate.ClientID %>");
            var txtSecurityNo = document.getElementById("<%= txtSecurityNum.ClientID %>");
            var txtCName = document.getElementById("<%= txtCardHolderName.ClientID %>");

            ddlCCType.disabled = boldisabled;
            txtCCNo.disabled = boldisabled;
            txtExpirationDate.disabled = boldisabled;
            txtSecurityNo.disabled = boldisabled;
            txtCName.disabled = boldisabled;

            var txtAddress1 = document.getElementById("<%= txtAddress1.ClientID %>");
            var txtCity = document.getElementById("<%= txtCity.ClientID %>");
            var ddlState = document.getElementById("<%= ddlstate.ClientID %>");
            var ddlCountry = document.getElementById("<%= ddlcountry.ClientID %>");
            var txtZip = document.getElementById("<%= txtZip.ClientID %>");

            txtAddress1.disabled = boldisabled;
            txtCity.disabled = boldisabled;
            ddlState.disabled = boldisabled;
            ddlCountry.disabled = boldisabled;
            txtZip.disabled = boldisabled;
        }
    }

    function ShowOrderDetailPopUp(orderId, orderTotal, paymentTotal, amountOwed, customerName, customerId) {
        ShowOrderDetailsDialog(orderId, orderTotal, paymentTotal, amountOwed, customerName, customerId);
        return false;
    }

    function MaintainAfterPostback() {
        OpenCloseDiv('<%= ddlpaymentmode.ClientID %>');
    }
</script>
<asp:HiddenField ID="hfEventCustomerID" runat="server" />
<asp:HiddenField ID="hfcustomerid" runat="server" />
<asp:HiddenField ID="spdbpaymentmode" runat="server" />
<div class="mainbody_outer">
    <div class="mainbody_inner">
        <div class="main_area_bdrnone">
            <div class="headingbox_top_body">
                <p>
                    <img src="/App/Images/specer.gif" width="700px" height="5px" />
                </p>
                <span class="orngheadtxt_heading" runat="server" id="sptitle">Cancel Appointments:<span
                    id="spCustomerName" runat="server"></span> </span>
            </div>
            <p>
                <img src="/App/Images/specer.gif" width="700px" height="2px" />
            </p>
            <p>
                <img src="/App/Images/specer.gif" width="700px" height="5px" />
            </p>
            <div class="divmainbody_cd">
                <div class="grayboxtop_cl">
                    <p class="grayboxtopbg_cl">
                        <img src="/App/Images/specer.gif" width="746" height="6" alt="" />
                    </p>
                    <p class="grayboxheader_cl">
                        Current Registration Summary
                    </p>
                    <div class="lgtgraybox_cl">
                        <p>
                            <img src="/App/Images/specer.gif" width="700px" height="5px" />
                        </p>
                        <p class="lgtgrayboxrow_cl">
                            <span class="titletext_default">Event (ID:<span id="spEventID" runat="server"></span>):
                            </span><span class="ttxtnowidthnormal_default"><span id="spHost" runat="server"></span>
                                , <span id="spAddress" runat="server"></span></span>
                        </p>
                        <p class="lgtgrayboxrow_cl">
                            <span class="titletext_default">Appointment Time:</span> <span class="ttxtnowidthnormal_default">
                                <span id="spEventDate" runat="server"></span>,<span id="spAppointment" runat="server"></span>
                            </span>
                        </p>
                        <p class="lgtgrayboxrow_cl">
                            <%--<span class="titletext_default">Package:</span> <span class="ttxtnowidthnormal_default"
                                id="spPackageDetails" runat="server"></span>--%>
                            <span class="titletext_default">Order:</span> <a id="_orderLinkAnchor" runat="server"
                                href="#">View Detail</a>
                            <%--<span class="ttxtnowidthnormal_default" runat="server" id="sppackagename">
                                    << Package Name >> </span>--%>
                        </p>
                        <p class="lgtgrayboxrow_cl">
                            <span class="titletext_default">Cost:</span> <span class="ttxtnowidthnormal_default"
                                id="spPackageCost" runat="server"></span><span class="titletextnowidth_default">|</span>
                            <span class="titletextnowidth_default">Source Code:</span> <span class="ttxtnowidthnormal_default"
                                id="spCouponDetails" runat="server"></span>
                        </p>
                        <p class="lgtgrayboxrow_cl">
                            <span class="titletext_default">Payment Details:</span>
                            <a id="_paymentLinkAnchor" runat="server" href="#"><b>Payment&nbsp;Details</b></a>
                        </p>
                        <p>
                            <img src="/App/Images/specer.gif" width="700px" height="5px" />
                        </p>
                    </div>
                    <p class="grayboxbotbg_cl">
                        <img src="/App/Images/specer.gif" width="746" height="4" />
                    </p>
                </div>
            </div>
            <div id="NormoalFlowCancellationDiv" style="float: left; clear: both;">
                <div class="main_area_bdrnone">
                    <div>
                        <img src="/App/Images/CCRep/specer.gif" width="740px" height="10px" />
                    </div>
                    <div id="Div1" class="pgnosymbol_common" runat="server">
                        <img src="/App/Images/page1symbolsmall.gif" />
                    </div>
                    <div class="orngheadtxt16_common">
                        Reason for Cancelation
                    </div>
                </div>
                <p id="NormoalFlowCancellationReasonContainerDiv"></p>
                <div class="main_area_bdrnone" id="CancellationSubReasonContainerDiv" style="display: none;">
                    <span class="ttxtnowidthnormal_default">
                        <img src="/App/Images/specer.gif" width="35px" height="20px" />
                    </span>
                    <span class="ttxtnowidthnormal_default" style="width: 125px"><b>Sub Reason:</b>
                    </span>
                    <span class="ttxtnowidthnormal_default">
                       <asp:DropDownList ID="CancellationSubReasonddlList" runat="server" CssClass="inputf_def" Width="175px"></asp:DropDownList>
                    </span>
                </div>
                <div class="main_area_bdrnone" id="CancellationNotesContainerDiv" style="display: none;">
                    <span class="ttxtnowidthnormal_default">
                        <img src="/App/Images/specer.gif" width="35px" height="20px" />
                    </span>
                    <span class="ttxtnowidthnormal_default" style="width: 125px"><b>Notes:</b>
                    </span>
                    <span class="ttxtnowidthnormal_default">
                        <asp:TextBox ID="txtReason" runat="server" TextMode="MultiLine" Rows="5" CssClass="inputf_def" Width="550px"></asp:TextBox>
                    </span>
                </div>
                <div class="main_area_bdrnone">
                    <div>
                        <img src="/App/Images/CCRep/specer.gif" width="740px" height="10px" />
                    </div>
                    <div id="Div2" class="pgnosymbol_common" runat="server">
                        <img src="/App/Images/page2symbolsmall.gif" />
                    </div>
                    <div class="orngheadtxt16_common">
                        Refund Adjustment
                    </div>
                </div>
                <p class="main_area_bdrnone">
                    <span class="ttxtnowidthnormal_default">
                        <img src="/App/Images/specer.gif" width="40px" height="20px" /></span> <span class="ttxtnowidthnormal_default">
                            <span class="titletext1a_default">Amount Paid:</span><span class="ttxtnowidthnormal_default">$</span>
                            <span class="ttxtnowidthnormal_default" id="spAmountPaid" runat="server"></span>
                        </span>
                </p>
                <p class="main_area_bdrnone">
                    <span class="ttxtnowidthnormal_default">
                        <img src="/App/Images/specer.gif" width="40px" height="20px" /></span> <span class="ttxtnowidthnormal_default">
                            <span class="titletext1a_default">Amount To Refund:</span> <span class="ttxtnowidthnormal_default">
                                <span class="inputconleft_popup_pd">
                                    <asp:TextBox ID="txtAmount" runat="server" CssClass="inputf_def" Width="100px"></asp:TextBox></span>(<%= IoC.Resolve<ISettings>().CompanyName %>
                                to pay Customer) </span></span>
                </p>
                <p class="main_area_bdrnone" runat="server" visible="false" id="CancellationFeeContainer"
                    style="padding-left: 40px; padding-top: 10px; font-style: italic; color: Red">
                    ($ <span runat="server" id="CancellatinFeeSpan"></span>will be charged as cancellation
                    amount.)
                </p>
                <p class="main_area_bdrnone">
                    <span class="ttxtnowidthnormal_default" style="padding-top: 10px;">
                        <img src="/App/Images/specer.gif" width="40px" height="20px" /></span> <span class="ttxtnowidthnormal_default">
                            <span class="titletext1a_default">Refund Method:</span> <span class="ttxtnowidthnormal_default">
                                <%-- <span runat="server" id="spdbpaymentmode1" class="ttxtnowidthnormal_chngepack"></span>--%>
                                <asp:DropDownList ID="ddlpaymentmode" runat="server" CssClass="inputf_def" Width="150px">
                                </asp:DropDownList>
                            </span></span>
                </p>
                <div class="main_area_bdrnone">
                    <div>
                        <img src="/App/Images/CCRep/specer.gif" width="740px" height="10px" />
                    </div>
                    <div id="Div4" class="pgnosymbol_common" runat="server">
                        <img src="/App/Images/page3symbolsmall.gif" />
                    </div>
                    <div class="orngheadtxt16_common">
                        Refund Details
                    </div>
                </div>
                <div class="main_area_bdrnone">
                    <div class="ttxtnowidthnormal_default" style="float: left;">
                        <img src="/App/Images/specer.gif" width="28px" height="50px" />
                    </div>
                    <div style="float: left">
                        <div id="bycreditcard" runat="server" style="height: 250px; float: left; width: 680px;">
                            <p class="ccdiv_common">
                                <span class="titletxt_popup_pd">Credit Card Type<span class="reqiredmark"><sup>*</sup></span>:</span>
                                <span class="inputconleft_popup_pd">
                                    <asp:DropDownList runat="server" ID="ddlcardtype" Width="140px" CssClass="inputf_def">
                                    </asp:DropDownList>
                                </span><span class="titletxt_popup_pd">Credit Card No<span class="reqiredmark"><sup>*</sup></span>:</span>
                                <span class="inputconright_popup_pd">
                                    <asp:TextBox ID="txtCardNo" MaxLength="16" runat="server" CssClass="inputf_def" Width="130px"></asp:TextBox></span>
                            </p>
                            <p class="ccdiv_common">
                                <span class="titletxt_popup_pd">Expiration Date<span class="reqiredmark"><sup>*</sup></span>:</span>
                                <span class="inputconleft_popup_pd">
                                    <asp:TextBox ID="txtExpirationDate" runat="server" CssClass="inputf_def" Width="105px"></asp:TextBox>
                                </span><span class="titletxt_popup_pd">Security No<span class="reqiredmark"><sup>*</sup></span>:</span>
                                <span class="inputconright_popup_pd">
                                    <asp:TextBox ID="txtSecurityNum" TextMode="Password" runat="server" CssClass="inputf_def"
                                        Width="80px"></asp:TextBox></span>
                            </p>
                            <p class="ccdiv_common">
                                <span class="titletxt_popup_pd">Card Holder<span class="reqiredmark"><sup>*</sup></span>:</span>
                                <span class="inputconleft_popup_pd">
                                    <asp:TextBox ID="txtCardHolderName" runat="server" CssClass="inputf_def" Width="105px"></asp:TextBox>
                                </span>
                            </p>
                            <p class="ccdiv_common">
                                <span class="titletxt_popup_pd">Address1<span class="reqiredmark"><sup>*</sup></span>:</span>
                                <span class="inputconleft_popup_pd">
                                    <asp:TextBox ID="txtAddress1" runat="server" CssClass="inputf_def" Width="135px"></asp:TextBox></span>
                            </p>
                            <p class="ccdiv_common">
                                <span class="titletxt_popup_pd">Country<span class="reqiredmark"><sup>*</sup></span>:</span>
                                <span class="inputconleft_popup_pd">
                                    <asp:DropDownList ID="ddlcountry" runat="server" Width="140px" CssClass="inputf_def">
                                    </asp:DropDownList>
                                </span>
                            </p>
                            <p class="ccdiv_common">
                                <span class="titletxt_popup_pd">State<span class="reqiredmark"><sup>*</sup></span>:</span>
                                <span class="inputconleft_popup_pd">
                                    <asp:DropDownList runat="server" ID="ddlstate" Width="140px" CssClass="inputf_def ddl-states">
                                    </asp:DropDownList>
                                </span>
                            </p>
                            <p class="ccdiv_common">
                                <span class="titletxt_popup_pd">City<span class="reqiredmark"><sup>*</sup></span>:</span>
                                <span class="inputconleft_popup_pd">
                                    <asp:TextBox runat="server" ID="txtCity" Width="100px" CssClass="inputf_def auto-search-city">
                                    </asp:TextBox>
                                </span>
                            </p>
                            <p class="ccdiv_common">
                                <span class="titletxt_popup_pd">Zip<span class="reqiredmark"><sup>*</sup></span>:</span>
                                <span class="inputconleft_popup_pd">
                                    <asp:TextBox ID="txtZip" runat="server" CssClass="inputf_def" Width="70px"></asp:TextBox></span>
                            </p>
                        </div>
                        <div id="byCreditCardOld" runat="server" style="display: none; height: 150px; float: left; width: 680px;">
                            <p>
                                <img src="/App/Images/specer.gif" width="700px" height="5px" />
                            </p>
                            <p class="fline_chngepack">
                                <img src="/App/Images/specer.gif" width="1px" height="1px" />
                            </p>
                            <p>
                                <img src="/App/Images/specer.gif" width="700px" height="5px" />
                            </p>
                            <p class="ccdiv_common">
                                <span class="titletxt_popup_pd"><b>Credit Card Type:</b></span> <span runat="server"
                                    id="spcctype" class="inputconleft_popup_pd"></span><span class="titletxt_popup_pd"><b>Credit Card No:</b></span> <span runat="server" id="spccnumber" class="inputconright_popup_pd"></span>
                            </p>
                            <p class="ccdiv_common">
                                <span class="titletxt_popup_pd"><b>Expiration Date:</b></span> <span runat="server"
                                    id="spexpdate" class="inputconleft_popup_pd"></span>
                            </p>
                            <p class="ccdiv_common">
                                <span class="titletxt_popup_pd"><b>Card Holder:</b></span> <span runat="server" id="spcardholder"
                                    class="inputconleft_popup_pd"></span>
                            </p>
                        </div>
                        <div id="bycheque" runat="server" style="display: none; height: 150px; float: left; width: 680px;">
                            <p>
                                <img src="/App/Images/specer.gif" width="700px" height="5px" />
                            </p>
                            <p class="fline_chngepack">
                                <img src="/App/Images/specer.gif" width="1px" height="1px" />
                            </p>
                            <p>
                                <img src="/App/Images/specer.gif" width="700px" height="5px" />
                            </p>
                            <p class="ccdiv_common">
                                <span class="titletxt_popup_pd">Bank Name:</span> <span class="inputconleft_popup_pd">
                                    <asp:TextBox ID="txtBankName" runat="server" CssClass="inputf_def" Width="100px"></asp:TextBox></span>
                                <span class="titletxt1_regcust">A/C Holder:</span> <span class="inputconright_popup_pd">
                                    <asp:TextBox ID="txtAccHolderName" runat="server" CssClass="inputf_def" Width="100px"></asp:TextBox></span>
                            </p>
                            <p class="ccdiv_common">
                                <span class="titletxt_popup_pd">Type of Account:</span> <span class="inputconleft_popup_pd">
                                    <asp:DropDownList runat="server" ID="ddlaccounttype" Width="110px" CssClass="inputf_def">
                                    </asp:DropDownList>
                                </span><span class="titletxt1_regcust">Account No:</span> <span class="inputconright_popup_pd">
                                    <asp:TextBox ID="txtAccountNum" runat="server" CssClass="inputf_def" Width="130px"></asp:TextBox></span>
                            </p>
                            <p class="ccdiv_common">
                                <span class="titletxt_popup_pd">Routing No:</span> <span class="inputconleft_popup_pd">
                                    <asp:TextBox runat="server" ID="txtRoutingNum" Width="110px" CssClass="inputf_def">
                                    </asp:TextBox>
                                </span><span class="titletxt1_regcust">Check No<span class="reqiredmark"><sup>*</sup></span>:</span>
                                <span class="inputconright_popup_pd">
                                    <asp:TextBox ID="txtChequeNum" runat="server" CssClass="inputf_def" Width="130px"></asp:TextBox></span>
                            </p>
                        </div>
                        <div id="byCash" runat="server" style="display: none; height: 150px; float: left; width: 680px;">
                            <p>
                                <img src="/App/Images/specer.gif" width="700px" height="5px" />
                            </p>
                            <p class="fline_chngepack">
                                <img src="/App/Images/specer.gif" width="1px" height="1px" />
                            </p>
                            <p>
                                <img src="/App/Images/specer.gif" width="700px" height="5px" />
                            </p>
                            <%--   <p class="ccdiv_common">
                            <span class="titletxt_popup_pd">Enter Amount:</span> <span class="inputconleft_popup_pd">
                                <asp:TextBox ID="txtAmount" runat="server" CssClass="inputf_def" Width="100px"></asp:TextBox></span>
                        </p>--%>
                        </div>
                    </div>
                </div>
            </div>
            <div class="main_area_bdrnone" style="display: none;" id="RefundRequestDiv">
                <div style="float: left;">
                    <div>
                        <img src="/App/Images/CCRep/specer.gif" width="740px" height="10px" />
                    </div>
                    <div id="Div5" class="pgnosymbol_common" runat="server">
                        <img src="/App/Images/page1symbolsmall.gif" />
                    </div>
                    <div class="orngheadtxt16_common">
                        Refund Requests
                    </div>
                </div>
                <div id="RefundRequestContentDiv" style="clear: both; float: left;">
                    <img src="/App/Images/indicator.gif" alt="" />
                    Loading Request Window
                </div>
                <div id="RefundRequestCancellationReasonContainerDiv" style="clear: both; float: left;"></div>
            </div>
            <div class="main_area_bdrnone" id="CancellationReasonContainerDiv">
                    <span class="ttxtnowidthnormal_default">
                        <img src="/App/Images/specer.gif" width="35px" height="20px" />
                    </span>
                    <span class="ttxtnowidthnormal_default" style="width: 125px"><b>Cancellation Reason:</b>
                    </span>
                    <span class="ttxtnowidthnormal_default">
                       <asp:DropDownList ID="CancellationReasonddlList" runat="server" CssClass="inputf_def" Width="175px"></asp:DropDownList>
                    </span>
                </div>
            <p>
                <img src="/App/Images/specer.gif" width="700px" height="2px" />
            </p>
            <p class="graylinefull_common">
                <img src="/App/Images/specer.gif" width="1px" height="1px" />
            </p>
            <p>
                <img src="/App/Images/specer.gif" width="700px" height="2px" />
            </p>
            <div class="buttonrow_bottom_common">
                <span class="buttoncon_default" style="display: none; text-align: center;" id="spnIndicator">
                    <img src="/App/Images/indicator.gif" alt="Saving record..." />
                </span>
                <span class="buttoncon_default">
                    <asp:ImageButton runat="server" ID="ibtnSave" ImageUrl="~/App/Images/save-button.gif"
                        OnClick="ibtnSave_Click" OnClientClick="return Validation();" />
                </span><span class="buttoncon_default">
                    <asp:ImageButton runat="server" ID="ibtnCancel" ImageUrl="~/App/Images/cancel-btn.gif"
                        OnClick="ibtnCancel_Click" />
                </span>
            </div>
        </div>
    </div>
</div>
<asp:HiddenField ID="hfstate" runat="server" />
<script type="text/javascript" language="javascript">
    var states;
    var subReasons;
    $(document).ready(function () {
        states = <%= GetStates() %> ;
        BindSateDropDown(states);
        $('#<%=ddlcountry.ClientID %>').bind("change", function() { BindSateDropDown(states); });
        
        SetAutoCompleteToControl('.auto-search-city', $('.ddl-states option:selected').val());

        $('.ddl-states').change(function () {
            SetAutoCompleteToControl('.auto-search-city', $('.ddl-states option:selected').val());
            SetState();
        });

        if (window.localStorage.isScriptOpen === "true" && window.localStorage.scriptUrl != null && window.localStorage.scriptUrl.length > 0 && window.localStorage.scriptUrl != "null") {
            openScriptWindow();
        }

        subReasons = <%= GetSubReason() %>;   
    });

    function SetAutoCompleteToControl(controlId, contextKey) {
        $(controlId).autoComplete({
            autoChange: true,
            url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetCityByContextKeyAndPrefixText")%>',
            type: "POST",
            data: "prefixText",
            contextKey: contextKey
        });
    }

</script>
<script type="text/javascript" language="javascript">

    function LoadUiforRefundRequest(amount) {
        $.ajax({ type: "GET",
            cache: false,
            dataType: "html", url: "/Finance/RefundRequest/Create?orderId=<%= OrderId %>&amount=" + amount + "&requestType=<%= (int)RefundRequestType.CustomerCancellation %>", data: '{}',
            success: function (result) {

                $("#RefundRequestDiv").show();
                $("#RefundRequestContentDiv").empty();
                $("#RefundRequestContentDiv").append(result);
            },
            error: function (a, b, c) { $("#RefundRequestDiv").hide(); alert('Some error loading the Request window. Please try opening the page again'); }
        });
    }

    $(document).ready(function () {
        if ('<%= IoC.Resolve<ISettings>().IsRefundQueueEnabled %>' == '<%= bool.TrueString %>' && Number('<%= TotalAmountRefundable %>') > 0) {
            LoadUiforRefundRequest('<%= TotalAmountRefundable.ToString("0.00") %>');
            $("#NormoalFlowCancellationDiv").hide();
            $("#RefundRequestCancellationReasonContainerDiv").html($("#CancellationReasonContainerDiv").html());
        } else {
            $("#NormoalFlowCancellationReasonContainerDiv").html($("#CancellationReasonContainerDiv").html());
        }
        
        $("#CancellationReasonContainerDiv").empty();

        $('#' + '<%=CancellationReasonddlList.ClientID %>').val("0");
        $("#<%= CancellationReasonddlList.ClientID%>").bind("change", function () { bindSubReasonDropdown($("#<%= CancellationReasonddlList.ClientID%>").val()); });
        bindSubReasonDropdown();
    });


</script>
<script type="text/javascript" language="javascript">

    function BindSateDropDown(stateList) {//debugger;
        $('#' + '<%=ddlstate.ClientID %> >option').remove();

        if (stateList.length > 0) {
            $('#' + '<%=ddlstate.ClientID %>').append($('<option></option>').val('0').html('Select State'));
            for (var i = 0; i < stateList.length; i++) {
                if (stateList[i].CountryId == $('#' + '<%=ddlcountry.ClientID %>').val())
                    $('#' + '<%=ddlstate.ClientID %>').append($('<option></option>').val(stateList[i].Id).html(stateList[i].Name));
            }
        }
        else {
            $('#' + '<%=ddlstate.ClientID %>').append($('<option></option>').val('0').html('No State Found'));
        }
        if ($('#<%=hfstate.ClientID %>').val() != '') {
            $("#<%= ddlstate.ClientID %> option:contains('" + $('#<%=hfstate.ClientID %>').val() + "')").first().attr('selected', true);
        }
    }

    function SetState() {
        $('#<%=hfstate.ClientID %>').val($('#<%=ddlstate.ClientID %> option:selected').text());
    }

    var scriptPopup = null;
    
    function openScriptWindow() {
        var properties = "width=" + Number($(window).width() / 2) + ", height=" + Number($(window).height()) + ", resizable=1, scrollbars=1";

        scriptPopup = window.open(window.localStorage.scriptUrl, "Call Center Script", properties);
        window.localStorage.setItem("isScriptOpen", true);
        checkScriptPopupOpen();
    }

    function checkScriptPopupOpen() {
        if (scriptPopup && scriptPopup.closed) {
            window.localStorage.removeItem("isScriptOpen");
            window.localStorage.removeItem("scriptUrl");
        } else {
            window.setTimeout(checkScriptPopupOpen, 500);
        }
    }
    
    function bindSubReasonDropdown(lookupId) {
        $('#' + '<%=CancellationSubReasonddlList.ClientID %>').html('');
        $('#' + '<%=txtReason.ClientID %>').text('');
        
        if (lookupId > 0) {
            if (lookupId === '<%= (long)CancelAppointmentReason.PersonalReasons%>' || lookupId === '<%= (long)CancelAppointmentReason.Other%>') {
                $("#CancellationSubReasonContainerDiv").hide();
                $("#CancellationNotesContainerDiv").show();
                $('#' + '<%=CancellationSubReasonddlList.ClientID %>').append($('<option></option>').val('0').html('--Select--'));
            }
            else {
                $('#' + '<%=CancellationSubReasonddlList.ClientID %>').append($('<option></option>').val('0').html('--Select--'));
                if (subReasons.length > 0) {
                    for (i = 0; i < subReasons.length; i++) {
                        if (subReasons[i].LookupId == $('#' + '<%=CancellationReasonddlList.ClientID %>').val())
                            $('#' + '<%=CancellationSubReasonddlList.ClientID %>').append($('<option></option>').val(subReasons[i].Id).html(subReasons[i].DisplayName));
                    }
                }
                
                $("#CancellationNotesContainerDiv").hide();

                if ($('#' + '<%=CancellationSubReasonddlList.ClientID %> option').length > 1)
                    $("#CancellationSubReasonContainerDiv").show();
                else
                    $("#CancellationSubReasonContainerDiv").hide();
            }
        }
        else {
            $("#CancellationSubReasonContainerDiv").hide();
            $("#CancellationNotesContainerDiv").hide();
        }
    }
</script>
