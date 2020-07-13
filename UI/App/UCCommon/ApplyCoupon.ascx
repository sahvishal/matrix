<%@ Control Language="C#" AutoEventWireup="true" Inherits="Falcon.App.UI.App.UCCommon.ApplyCoupon"
    CodeBehind="ApplyCoupon.ascx.cs" %>
<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.Core.Finance.Enum" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>
<%@ Register Src="~/App/UCCommon/GiftCertificateApply.ascx" TagPrefix="uc" TagName="GCApply" %>
<%@ Register TagPrefix="uc" Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" %>
<%@ Register Src="~/App/UCCommon/ViewOrderDetails.ascx" TagName="ViewOrderDetails"
    TagPrefix="orderDetails" %>
<uc:JQueryToolkit ID="_jQueryToolkit" runat="server" IncludeAjax="true" IncludeJQueryUI="true"
    IncudeJQueryAutoComplete="true" IncludeJQueryMaskInput="true" />
<orderDetails:ViewOrderDetails ID="_viewOrderDetailsControl" runat="server" />
<script type="text/javascript" language="javascript">

    function ShowOrderDetailPopUp(orderId, orderTotal, paymentTotal, amountOwed, customerName, customerId) {
        ShowOrderDetailsDialog(orderId, orderTotal, paymentTotal, amountOwed, customerName, customerId);
        return false;
    }
    function txtkeypress(evt) {
        return KeyPress_NumericAllowedOnly(evt);
    }


    function OpenCloseDiv(ddlpaymentmode_clientid) {
        var ddlpaymentmode = document.getElementById(ddlpaymentmode_clientid);
        if (ddlpaymentmode.selectedIndex == 0)
            return;

        var paymentmode = ddlpaymentmode.options[ddlpaymentmode.selectedIndex].value;

        document.getElementById('<%=bycreditcard.ClientID %>').style.display = 'none';
        document.getElementById('<%=bycheque.ClientID %>').style.display = 'none';
        document.getElementById('<%=byCreditCardOld.ClientID %>').style.display = 'none';
        document.getElementById('<%=byCash.ClientID %>').style.display = 'none';
        document.getElementById('<%=_divGiftCertificate.ClientID %>').style.display = 'none';

        if (paymentmode == '<%= PaymentType.CreditCard.PersistenceLayerId %>') {
            document.getElementById('<%=bycreditcard.ClientID %>').style.display = 'block';
        }
        else if (paymentmode == '<%= PaymentType.Check.PersistenceLayerId %>') {
            document.getElementById('<%=bycheque.ClientID %>').style.display = 'block';
        }
        else if (paymentmode == '<%= PaymentType.Cash.PersistenceLayerId %>') {
            //document.getElementById('<%=byCash.ClientID %>').style.display = 'block';
        }
        else if (paymentmode == '<%= PaymentType.CreditCardOnFile_Value %>') {
            document.getElementById('<%=byCreditCardOld.ClientID %>').style.display = 'block';
        }
        else if (paymentmode == '<%= PaymentType.GiftCertificate.PersistenceLayerId %>') {
            document.getElementById('<%=_divGiftCertificate.ClientID %>').style.display = 'block';
            SelectGC();
        }

        document.getElementById('<%=hfPaymentMode.ClientID %>').value = paymentmode;
    }


    /* *********************** Apply Coupon Code ********************* */
    function couponvalidation() {
        if (isBlank(document.getElementById("<%=txtcoupon.ClientID %>"), "Source Code"))
            return false;
    }


    function ExtractCouponData(result) {
        //debugger;
        var model = null;
        eval("model = " + result);
        var ddlpaymentmode = document.getElementById('<%=ddlpaymentmode.ClientID %>');
        var hfcouponid = document.getElementById('<%=hfcouponid.ClientID %>');
        var hfcouponamount = document.getElementById('<%=hfcouponamount.ClientID %>');
        var hfcouponapplied = document.getElementById('<%=hfcouponapplied.ClientID %>');
        var hfdiffamount = document.getElementById('<%=hfdiffamount.ClientID %>');

        if (model.SourceCodeId < 1 && model.FeedbackMessage != null) {
            alert(model.FeedbackMessage.Message);
            hfcouponid.value = "";
            hfcouponapplied.value = false;
            return false;
        }
        hfcouponamount.value = formatAmount(model.DiscountApplied).toFixed(2);
        hfcouponid.value = model.SourceCodeId;
        hfcouponapplied.value = true;

        var hfcurrentcoupon = document.getElementById('<%=hfcurrentcoupon.ClientID %>');
        var hfcurrentcouponcost = document.getElementById('<%=hfcurrentcouponamount.ClientID %>');

        if (hfcurrentcoupon.value.length > 0) {
            hfdiffamount.value = (parseFloat(hfcurrentcouponcost.value) - parseFloat(hfcouponamount.value)).toFixed(2);
        }
        else
            hfdiffamount.value = (-1 * parseFloat(hfcouponamount.value)).toFixed(2);

        document.getElementById('<%=divCouponamountadjustment.ClientID %>').style.display = "block";
        document.getElementById('<%=spSave.ClientID %>').style.display = "block";

        var spcouponamount = document.getElementById('<%=spcouponadjust.ClientID %>');
        if (parseFloat(hfdiffamount.value) >= 0.00)
            spcouponamount.innerHTML = "(-) $" + hfdiffamount.value + " (" + document.getElementById('<%=txtcoupon.ClientID %>').value + ")";
        else
            spcouponamount.innerHTML = "$" + (-1 * (parseFloat(hfdiffamount.value))) + " (" + document.getElementById('<%=txtcoupon.ClientID %>').value + ")";

        var hfnetpayment = document.getElementById('<%=hfcurrentpayable.ClientID %>');
        document.getElementById('<%=spamountpaid.ClientID %>').innerHTML = "$" + document.getElementById('<%=hfpaidamount.ClientID %>').value;
        if (parseFloat(hfnetpayment.value) > 0.00) {

            var diffamount = parseFloat(hfdiffamount.value);
            if (diffamount < 0.00)
                diffamount = -1 * diffamount;

            if (hfdiffamount.value > 0.00) {
                document.getElementById('<%=spchangeeffect.ClientID %>').innerHTML = "Amount owed:";
                document.getElementById('<%=spchangeamount.ClientID %>').innerHTML = "$" + (parseFloat(diffamount) + parseFloat(hfnetpayment.value)).toFixed(2);
            }
            else {
                if (parseFloat(hfnetpayment.value) >= parseFloat(diffamount)) {
                    document.getElementById('<%=spchangeeffect.ClientID %>').innerHTML = "Amount owed:";
                    document.getElementById('<%=spchangeamount.ClientID %>').innerHTML = "$" + (parseFloat(hfnetpayment.value) - parseFloat(diffamount)).toFixed(2);

                    if (parseFloat(hfnetpayment.value) == parseFloat(diffamount)) {//this means there will be zero amount owed.
                        document.getElementById('divpaymentmode').style.display = "none";
                        document.getElementById('divadjustmentdetails').style.display = "none";
                    }
                }
                else {
                    if ('<%= IoC.Resolve<ISettings>().IsRefundQueueEnabled %>' == '<%= bool.TrueString %>') {
                        isRefund = true;
                        LoadUiforRefundRequest((parseFloat(diffamount) - parseFloat(hfnetpayment.value)).toFixed(2));
                        document.getElementById('<%=divCouponamountadjustment.ClientID %>').style.display = "none";
                    }
                    else {
                        document.getElementById('<%=spchangeeffect.ClientID %>').innerHTML = "Amount to refund:";
                        document.getElementById('<%=spchangeamount.ClientID %>').innerHTML = "$" + (parseFloat(diffamount) - parseFloat(hfnetpayment.value)).toFixed(2);
                        removeOnsiteOption();
                        removeGiftCertificateOption();
                        if ($('#<%= IsValidCardHiddenFieldName %>').val() == '<%= Boolean.FalseString %>') {
                            RemoveCardonFileOption();
                        }
                    }
                }
            }

        }
        else {
            //considered the net payable by customer is zero, as refund to customer can not stay onsite.   
            var diffamount = parseFloat(hfdiffamount.value) + parseFloat(hfnetpayment.value);

            if (diffamount > 0.00) {
                document.getElementById('<%=spchangeeffect.ClientID %>').innerHTML = "Amount owed:";
                document.getElementById('<%=spchangeamount.ClientID %>').innerHTML = "$" + diffamount.toFixed(2);
            }
            else if (diffamount < 0.00) {
                if ('<%= IoC.Resolve<ISettings>().IsRefundQueueEnabled %>' == '<%= bool.TrueString %>') {
                    isRefund = true;
                    LoadUiforRefundRequest((diffamount * -1).toFixed(2));
                    document.getElementById('<%=divCouponamountadjustment.ClientID %>').style.display = "none";
                }
                else {
                    document.getElementById('<%=spchangeeffect.ClientID %>').innerHTML = "Amount to refund:";
                    document.getElementById('<%=spchangeamount.ClientID %>').innerHTML = "$" + (diffamount * -1).toFixed(2);
                    removeOnsiteOption();
                    removeGiftCertificateOption();
                    if ($('#<%= IsValidCardHiddenFieldName %>').val() == '<%= Boolean.FalseString %>') {
                        RemoveCardonFileOption();
                    }
                }
            }
            else if (diffamount == 0.00) {
                document.getElementById('<%=spchangeeffect.ClientID %>').innerHTML = "Amount owed:";
                document.getElementById('<%=spchangeamount.ClientID %>').innerHTML = "$" + (diffamount).toFixed(2);
                document.getElementById('divpaymentmode').style.display = "none";
                document.getElementById('divadjustmentdetails').style.display = "none";
            }
        }
    }

    function SetValuesafterFailedPostBack() {
        var hfnetpayment = document.getElementById('<%=hfcurrentpayable.ClientID %>');
        var hfdiffamount = document.getElementById('<%=hfdiffamount.ClientID %>');
        var hfcouponamount = document.getElementById('<%=hfcouponamount.ClientID %>');
        var hfcouponapplied = document.getElementById('<%=hfcouponapplied.ClientID %>');

        document.getElementById('<%=spamountpaid.ClientID %>').innerHTML = "$" + document.getElementById('<%=hfpaidamount.ClientID %>').value;
        var spcouponamount = document.getElementById('<%=spcouponadjust.ClientID %>');
        spcouponamount.innerHTML = "$" + hfcouponamount.value + " (" + document.getElementById('<%=txtcoupon.ClientID %>').value + ")";
        document.getElementById('<%=spSave.ClientID %>').style.display = "block";
        if (parseFloat(hfnetpayment.value) > 0.00) {
            var diffamount = parseFloat(hfdiffamount.value);
            if (diffamount < 0.00)
                diffamount = -1 * diffamount;

            if (hfdiffamount.value > 0.00) {
                document.getElementById('<%=spchangeeffect.ClientID %>').innerHTML = "Amount owed:";
                document.getElementById('<%=spchangeamount.ClientID %>').innerHTML = "$" + (parseFloat(diffamount) + parseFloat(hfnetpayment.value)).toFixed(2);
            }
            else {
                if (parseFloat(hfnetpayment.value) >= parseFloat(diffamount)) {
                    document.getElementById('<%=spchangeeffect.ClientID %>').innerHTML = "Amount owed:";
                    document.getElementById('<%=spchangeamount.ClientID %>').innerHTML = "$" + (parseFloat(hfnetpayment.value) - parseFloat(diffamount)).toFixed(2);
                }
                else {
                    if ('<%= IoC.Resolve<ISettings>().IsRefundQueueEnabled %>' == '<%= bool.TrueString %>') {
                        isRefund = true;
                        LoadUiforRefundRequest((parseFloat(diffamount) - parseFloat(hfnetpayment.value)).toFixed(2));
                        document.getElementById('<%=divCouponamountadjustment.ClientID %>').style.display = "none";
                    }
                    else {
                        document.getElementById('<%=spchangeeffect.ClientID %>').innerHTML = "Amount to refund:";
                        document.getElementById('<%=spchangeamount.ClientID %>').innerHTML = "$" + (parseFloat(diffamount) - parseFloat(hfnetpayment.value)).toFixed(2);
                        removeOnsiteOption();
                        removeGiftCertificateOption();
                        if ($('#<%= IsValidCardHiddenFieldName %>').val() == '<%= Boolean.FalseString %>') {
                            RemoveCardonFileOption();
                        }
                    }
                }

            }

        }
        else {

            if (hfdiffamount.value > 0.00) {
                document.getElementById('<%=spchangeeffect.ClientID %>').innerHTML = "Amount owed:";
                document.getElementById('<%=spchangeamount.ClientID %>').innerHTML = "$" + (parseFloat(hfdiffamount.value)).toFixed(2);
            }
            else if (hfdiffamount.value < 0.00) {
                if ('<%= IoC.Resolve<ISettings>().IsRefundQueueEnabled %>' == '<%= bool.TrueString %>') {
                    isRefund = true;
                    LoadUiforRefundRequest(parseFloat(hfdiffamount.value) * -1);
                    document.getElementById('<%=divCouponamountadjustment.ClientID %>').style.display = "none";
                }
                else {
                    document.getElementById('<%=spchangeeffect.ClientID %>').innerHTML = "Amount to refund:";
                    document.getElementById('<%=spchangeamount.ClientID %>').innerHTML = "$" + (parseFloat(hfdiffamount.value) * -1).toFixed(2);
                    removeOnsiteOption();
                    removeGiftCertificateOption();
                    if ($('#<%= IsValidCardHiddenFieldName %>').val() == '<%= Boolean.FalseString %>') {
                        RemoveCardonFileOption();
                    }
                }
            }
            else if (hfdiffamount.value == 0.00) {
                document.getElementById('divpaymentmode').style.display = "none";
                document.getElementById('divadjustmentdetails').style.display = "none";

                document.getElementById('<%=spchangeeffect.ClientID %>').innerHTML = "Amount owed:";
                document.getElementById('<%=spchangeamount.ClientID %>').innerHTML = "$" + (parseFloat(hfdiffamount.value)).toFixed(2);
            }
        }
        document.getElementById('<%=spchangeeffect.ClientID %>').innerHTML = "Amount owed:";
        var ddlpaymentmode = document.getElementById('<%=ddlpaymentmode.ClientID %>');
        var paymentmode = ddlpaymentmode.options[ddlpaymentmode.selectedIndex].value;

        if (paymentmode == '<%= PaymentType.CreditCard.PersistenceLayerId %>') {
            document.getElementById('<%=bycreditcard.ClientID %>').style.display = 'block';
        }
        else if (paymentmode == '<%= PaymentType.GiftCertificate.PersistenceLayerId %>') {
            document.getElementById('<%=_divGiftCertificate.ClientID %>').style.display = 'block';
            if (document.getElementById('GCApplychk')) {
                document.getElementById('GCApplychk').checked = true;
            }
        }
    }
    var isRefund = false;
</script>
<input type="hidden" runat="server" id="RefundRequestAmount" value="0.00" />
<script language="javascript" type="text/javascript">
    function LoadUiforRefundRequest(amount) {

        var refundRequestAmount = $('#<%= RefundRequestAmount.ClientID%>').val();
        amount = amount - refundRequestAmount;
        $.ajax({ type: "GET",
            cache: false,
            dataType: "html", url: "/Finance/RefundRequest/Create?orderId=<%= OrderId %>&amount=" + amount + "&requestType=<%= (int)RefundRequestType.ApplySourceCode %>", data: '{}',
            success: function (result) {

                $("#RefundRequestDiv").show();
                $("#RefundRequestContentDiv").empty();
                $("#RefundRequestContentDiv").append(result);
            },
            error: function (a, b, c) { $("#RefundRequestDiv").hide(); alert('Some error loading the Request window. Please try opening the page again'); }
        });

    } 
    
</script>
<script language="javascript" type="text/javascript">
    
    function formatAmount(num) {
        if (isNaN(parseFloat(num))) {
            num = '0.00'; 
        }
        return parseFloat(num);
    }
    
    function Confirmation() {
        var bolresult = Validation();
        if (!bolresult) return false;

        var divCnfrmMsg = document.getElementById("divCnfrmMsg");

        var rBtnCnfrm = document.getElementById("<%=this.rBtnCnfrm.ClientID %>");
        var spNewCouponCode = document.getElementById("spNewCouponCode");
        var spNewCouponAmt = document.getElementById("spNewCouponAmt");

        var hfcouponamount = document.getElementById("<%=this.hfcouponamount.ClientID %>");
        var txtcoupon = document.getElementById("<%=this.txtcoupon.ClientID %>");

        if (divCnfrmMsg.style.display == "none") {
            rBtnCnfrm.rows[0].cells[1].childNodes[0].checked = true;
        }
        
        divCnfrmMsg.style.display = "block";
        divCnfrmMsg.style.visibility = "visible";
        
        var str = txtcoupon.value;
        spNewCouponCode.innerHTML = str.toUpperCase();
        spNewCouponAmt.innerHTML = hfcouponamount.value;

        if (divCnfrmMsg.style.display == "block" && rBtnCnfrm.rows[0].cells[0].childNodes[0].checked == true) {
            var spApplyCouponBtn = document.getElementById("spApplyCouponBtn");
            var spSave = document.getElementById("<%=this.spSave.ClientID %>");
            var spCancel = document.getElementById("spCancel");
            spApplyCouponBtn.style.display = "none";
            spSave.style.display = "none";
            spCancel.style.display = "none";
            return true;
        }
        return false;
    }

    function removeOnsiteOption() {//debugger
        var ddlpaymentmode = document.getElementById('<%=ddlpaymentmode.ClientID %>');
        var hfRole = document.getElementById("<%=this.hfRole.ClientID %>");
        var count = 0;
        for (count = 0; count < ddlpaymentmode.length; count++) {

            if (ddlpaymentmode.options[count].value == "<%= PaymentType.Onsite_Value %>") {
                ddlpaymentmode.options[count] = null;
            }
            if (hfRole.value == "Technician" && ddlpaymentmode.options[count].value == "<%= PaymentType.Check.PersistenceLayerId %>") {
                ddlpaymentmode.options[count] = null;
            }

        }
    }

    function removeGiftCertificateOption() {
        var ddlpaymentmode = document.getElementById('<%=ddlpaymentmode.ClientID %>');
        var count = 0;
        for (count = 0; count < ddlpaymentmode.length; count++) {
            if (ddlpaymentmode.options[count].value == "<%= PaymentType.GiftCertificate.PersistenceLayerId %>") {
                ddlpaymentmode.options[count] = null;
            }
        }
    }

    function RemoveCardonFileOption() {
        $('#<%= ddlpaymentmode.ClientID %> option[value=<%= PaymentType.CreditCardOnFile_Value %>]').attr("disabled", "disabled");
    }

    function AddCardonFileOption() {
        $('#<%= ddlpaymentmode.ClientID %> option[value=<%= PaymentType.CreditCardOnFile_Value %>]').attr("disabled", "");
    }

    function Validation() {

        if (!isRefund) {
            var ddlpaymentmode = document.getElementById('<%=ddlpaymentmode.ClientID %>');

            if (ddlpaymentmode == null) return true;
            if (ddlpaymentmode.disabled == true) return true;

            if (document.getElementById('divpaymentmode').style.display != "none") {
                if (ddlpaymentmode != null && ddlpaymentmode.selectedIndex == 0 && ddlpaymentmode.disabled != true) {
                    alert('Please Select a payment mode.');
                    return false;
                }
            }
            else
            { return true; }

            var paymentmode = '';
            paymentmode = ddlpaymentmode.options[ddlpaymentmode.selectedIndex].value;

            if (paymentmode == '<%= PaymentType.CreditCard.PersistenceLayerId %>') {
                var ddlCCType = document.getElementById("<%=ddlcardtype.ClientID %>");
                var txtCCNo = document.getElementById("<%=txtCardNo.ClientID %>");
                var txtExpirationDate = document.getElementById("<%=txtExpirationDate.ClientID %>");
                var txtSecurityNo = document.getElementById("<%=txtSecurityNum.ClientID %>");
                var txtCName = document.getElementById("<%=txtCardHolderName.ClientID %>");

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
                if (!validateExpiryDate(txtExpirationDate, "Expiry Date"))
                    return false;
                if (isBlank(txtSecurityNo, "Security Number"))
                    return false;
                    
                var txtAddress1 = document.getElementById("<%=txtAddress1.ClientID %>");
                var txtCity = document.getElementById("<%=txtCity.ClientID %>");
                var ddlState = document.getElementById("<%=ddlstate.ClientID %>");
                var txtZip = document.getElementById("<%=txtZip.ClientID %>");

                if (isBlank(txtAddress1, "Address")) { return false; }
                if (checkLength(txtAddress1, 500, "Address")) { return false; }
                if (checkDropDown(ddlState, "State for  Address") == false) { return false; }
                if (isBlank(txtCity, "City for  Address")) { return false; }
                if (isBlank(txtZip, "Zip")) { return false; }
            }
            else if (paymentmode == '<%= PaymentType.Check.PersistenceLayerId %>') {
                if (isBlank(document.getElementById('<%=txtChequeNum.ClientID %>'), "Check Number")) { return false; }
                if (Validate_CheckForSpecialCharacters("<%=txtChequeNum.ClientID %>") == false) { alert('Please enter only alphanumeric characters'); return false; }
            }
        } else {
            if ($("textarea[id='Reason']").val() == '') {
                alert("Refund reason is required.");
                return false;
            }
        }
        return true;
    }
        
</script>
<div class="mainbody_outer">
    <div class="mainbody_inner">
        <div class="main_area_bdrnone">
            <div class="headingbox_top_body">
                <p>
                    <img src="/App/Images/specer.gif" width="700px" height="5px" /></p>
                <span class="orngheadtxt_heading">Apply Source Code - <span runat="server" id="spcustomerdetail">
                </span></span>
            </div>
            <p>
                <img src="/App/Images/specer.gif" width="700px" height="2px" /></p>
            <p class="graylinefull_common">
                <img src="/App/Images/specer.gif" width="1px" height="1px" /></p>
            <p>
                <img src="/App/Images/specer.gif" width="700px" height="5px" /></p>
            <div class="divmainbody_cd">
                <div class="grayboxtop_cl">
                    <p class="grayboxtopbg_cl">
                        <img src="/App/Images/specer.gif" width="746" height="6" alt="" /></p>
                    <p class="grayboxheader_cl">
                        Current Registration Summary</p>
                    <div class="lgtgraybox_cl">
                        <p>
                            <img src="/App/Images/specer.gif" width="700px" height="5px" /></p>
                        <p class="lgtgrayboxrow_cl">
                            <span class="titletext_default">Event (ID:<span runat="server" id="speventid"> </span>
                                ): </span><span class="ttxtnowidthnormal_default"><span runat="server" id="sphostname">
                                </span>, <span runat="server" id="spaddress"></span></span>
                        </p>
                        <p class="lgtgrayboxrow_cl">
                            <span class="titletext_default">Appointment Time:</span> <span class="ttxtnowidthnormal_default">
                                <span runat="server" id="speventdate"></span>, <span runat="server" id="spapptime">
                                </span></span>
                        </p>
                        <p class="lgtgrayboxrow_cl">
                            <span class="titletext_default">Order:</span> <a id="_paymentLinkAnchor" runat="server"
                                href="#">View Detail</a>
                            <%--<span class="ttxtnowidthnormal_default" runat="server" id="sppackagename">
                                    << Package Name >> </span>--%>
                        </p>
                        <p class="lgtgrayboxrow_cl">
                            <span class="titletext_default">Cost:</span> <span class="ttxtnowidthnormal_default"
                                runat="server" id="sppackagecost"></span><span class="titletextnowidth_default">|</span>
                            <span class="titletextnowidth_default">Source Code:</span> <span class="ttxtnowidthnormal_default"
                                runat="server" id="spcoupon"></span>
                        </p>
                        <p class="lgtgrayboxrow_cl">
                            <span class="titletext_default">Payment Details:</span> <span runat="server" id="sppaymentdetails"
                                class="ttxtnowidthnormal_default"></span>
                        </p>
                        <p>
                            <img src="/App/Images/specer.gif" width="700px" height="5px" /></p>
                    </div>
                    <p class="grayboxbotbg_cl">
                        <img src="/App/Images/specer.gif" width="746" height="4" /></p>
                </div>
            </div>
            <div class="main_area_bdrnone">
                <div>
                    <img src="/App/Images/CCRep/specer.gif" width="740px" height="10px" /></div>
                <div id="Div1" class="pgnosymbol_common" runat="server">
                    <img src="/App/Images/page1symbolsmall.gif" /></div>
                <div class="orngheadtxt16_common">
                    Source Code Adjustment Option</div>
            </div>
            <p class="main_area_bdrnone">
                <span class="ttxtnowidthnormal_default">
                    <img src="/App/Images/specer.gif" width="35px" height="25px" /></span> <span class="ttxtnowidthnormal_default">
                        <asp:RadioButton ID="rbtapplycoupon" Enabled="false" runat="server" Text="Apply new Source Code " /></span>
            </p>
            <p class="main_area_bdrnone">
                <span class="ttxtnowidthnormal_default">
                    <img src="/App/Images/specer.gif" width="35px" height="20px" /></span> <span class="ttxtnowidthnormal_default">
                        <asp:RadioButton ID="rbtreplaceexisting" Enabled="false" runat="server" Text="Replace Existing Source Code" /></span>
            </p>
            <div class="main_area_bdrnone">
                <div>
                    <img src="/App/Images/CCRep/specer.gif" width="740px" height="10px" /></div>
                <div id="Div2" class="pgnosymbol_common" runat="server">
                    <img src="/App/Images/page2symbolsmall.gif" /></div>
                <div class="orngheadtxt16_common">
                    Apply Source Code (Optional)?</div>
            </div>
            <p class="main_area_bdrnone">
                <span class="ttxtnowidthnormal_default">
                    <img src="/App/Images/specer.gif" width="38px" height="10px" /></span> <span class="ttxtnowidthnormal_default">
                        <span class="inputfldnowidth_default">
                            <asp:TextBox ID="txtcoupon" runat="server" CssClass="inputf_def" Width="150px"></asp:TextBox></span>
                        <span class="button_con_nowidth" id="spApplyCouponBtn">
                            <asp:ImageButton runat="server" ID="ibtnapplycoupon" OnClientClick="return couponvalidation();"
                                ImageUrl="~/App/Images/apply-btn.gif" OnClick="ibtnapplycoupon_Click" />
                        </span></span>
            </p>
            <div runat="server" id="divCouponamountadjustment" style="display: none; float: left">
                <div class="main_area_bdrnone">
                    <div>
                        <img src="/App/Images/CCRep/specer.gif" width="740px" height="10px" /></div>
                    <div id="Div4" class="pgnosymbol_common" runat="server">
                        <img src="/App/Images/page3symbolsmall.gif" /></div>
                    <div class="orngheadtxt16_common">
                        Source Code Amount Adjustment
                    </div>
                </div>
                <div class="main_area_bdrnone">
                    <span class="ttxtnowidthnormal_default">
                        <img src="/App/Images/specer.gif" width="40px" height="20px" /></span> <span class="ttxtnowidthnormal_default">
                            <span class="titletext1a_default">Amount Paid:</span> <span class="ttxtnowidthnormal_default"
                                runat="server" id="spamountpaid"></span></span>
                </div>
                <div class="main_area_bdrnone">
                    <span class="ttxtnowidthnormal_default">
                        <img src="/App/Images/specer.gif" width="40px" height="20px" /></span> <span class="ttxtnowidthnormal_default">
                            <span class="titletext1a_default">Source Code Adjustment:</span> <span class="ttxtnowidthnormal_default"
                                runat="server" id="spcouponadjust"></span></span>
                </div>
                <div class="main_area_bdrnone">
                    <span class="ttxtnowidthnormal_default">
                        <img src="/App/Images/specer.gif" width="40px" height="20px" /></span> <span class="ttxtnowidthnormal_default">
                            <span class="titletext1a_default" runat="server" id="spchangeeffect">Amount to Refund:</span>
                            <span class="ttxtnowidthnormal_default total-amount-span" runat="server" id="spchangeamount">
                            </span></span>
                </div>
                <div id="divpaymentmode" class="main_area_bdrnone">
                    <span class="ttxtnowidthnormal_default">
                        <img src="/App/Images/specer.gif" width="40px" height="20px" /></span> <span class="ttxtnowidthnormal_default">
                            <span class="titletext1a_default">Payment Method:</span> <span class="ttxtnowidthnormal_default">
                                <asp:DropDownList ID="ddlpaymentmode" runat="server" CssClass="inputf_def" Width="140px">                                    
                                </asp:DropDownList>
                            </span></span>
                </div>
                <div id="divadjustmentdetails" class="main_area_bdrnone">
                    <div>
                        <img src="/App/Images/CCRep/specer.gif" width="740px" height="10px" /></div>
                    <div id="Div3" class="pgnosymbol_common" runat="server">
                        <img src="/App/Images/page4symbolsmall.gif" /></div>
                    <div class="orngheadtxt16_common">
                        Payment Details
                    </div>
                </div>
                <div class="main_area_bdrnone">
                    <div class="ttxtnowidthnormal_default">
                        <img src="/App/Images/specer.gif" width="28px" height="20px" /></div>
                    <div class="ccdiv1_common">
                        <div id="bycreditcard" runat="server" style="float: left; height: 250px; display: none;">
                            <p class="ccdiv1_common">
                                <span class="titletxt_popup_pd">Credit Card Type<span class="reqiredmark"><sup>*</sup></span>:</span>
                                <span class="inputconleft_popup_pd">
                                    <asp:DropDownList runat="server" ID="ddlcardtype" Width="140px" CssClass="inputf_def">
                                    </asp:DropDownList>
                                </span><span class="titletxt_popup_pd">Credit Card No<span class="reqiredmark"><sup>*</sup></span>:</span>
                                <span class="inputconright_popup_pd">
                                    <asp:TextBox ID="txtCardNo" MaxLength="16" runat="server" CssClass="inputf_def" Width="130px"></asp:TextBox></span>
                            </p>
                            <p class="ccdiv1_common">
                                <span class="titletxt_popup_pd">Expiration Date<span class="reqiredmark"><sup>*</sup></span>:</span>
                                <span class="inputconleft_popup_pd">
                                    <asp:TextBox ID="txtExpirationDate" runat="server" CssClass="inputf_def" Width="105px"
                                        MaxLength="12"></asp:TextBox>
                                </span><span class="titletxt_popup_pd">Security No<span class="reqiredmark"><sup>*</sup></span>:</span>
                                <span class="inputconright_popup_pd">
                                    <asp:TextBox ID="txtSecurityNum" TextMode="Password" runat="server" CssClass="inputf_def"
                                        Width="80px" MaxLength="4"></asp:TextBox></span>
                            </p>
                            <p class="ccdiv1_common">
                                <span class="titletxt_popup_pd">Card Holder<span class="reqiredmark"><sup>*</sup></span>:</span>
                                <span class="inputconleft_popup_pd">
                                    <asp:TextBox ID="txtCardHolderName" runat="server" CssClass="inputf_def" Width="105px"></asp:TextBox>
                                </span>
                            </p>
                            <p class="ccdiv1_common">
                                <span class="titletxt_popup_pd">Address1<span class="reqiredmark"><sup>*</sup></span>:</span>
                                <span class="inputconleft_popup_pd">
                                    <asp:TextBox ID="txtAddress1" runat="server" CssClass="inputf_def" Width="135px"></asp:TextBox></span>
                            </p>
                            <p class="ccdiv1_common">
                                <span class="titletxt_popup_pd">Suite, Apt, etc:</span> <span class="inputconleft_popup_pd">
                                    <asp:TextBox ID="txtaddress2" runat="server" CssClass="inputf_def" Width="135px"></asp:TextBox></span>
                            </p>
                            <p class="ccdiv1_common">
                                <span class="titletxt_popup_pd">Country<span class="reqiredmark"><sup>*</sup></span>:</span>
                                <span class="inputconleft_popup_pd">
                                    <asp:DropDownList ID="ddlcountry" runat="server" Width="140px" CssClass="inputf_def">
                                    </asp:DropDownList>
                                </span>
                            </p>
                            <p class="ccdiv1_common">
                                <span class="titletxt_popup_pd">State<span class="reqiredmark"><sup>*</sup></span>:</span>
                                <span class="inputconleft_popup_pd">
                                    <asp:DropDownList runat="server" ID="ddlstate" Width="140px" CssClass="inputf_def ddl-states">
                                    </asp:DropDownList>
                                </span>
                            </p>
                            <p class="ccdiv1_common">
                                <span class="titletxt_popup_pd">City<span class="reqiredmark"><sup>*</sup></span>:</span>
                                <span class="inputconleft_popup_pd">
                                    <asp:TextBox runat="server" ID="txtCity" Width="100px" CssClass="inputf_def auto-search-city">
                                    </asp:TextBox>
                                </span>
                            </p>
                            <p class="ccdiv1_common">
                                <span class="titletxt_popup_pd">Zip<span class="reqiredmark"><sup>*</sup></span>:</span>
                                <span class="inputconleft_popup_pd">
                                    <asp:TextBox ID="txtZip" runat="server" CssClass="inputf_def" Width="70px"></asp:TextBox></span>
                            </p>
                        </div>
                        <div id="byCreditCardOld" runat="server" style="float: left; display: none;">
                            <p>
                                <img src="/App/Images/specer.gif" width="700px" height="5px" /></p>
                            <p class="fline_chngepack">
                                <img src="/App/Images/specer.gif" width="1px" height="1px" /></p>
                            <p>
                                <img src="/App/Images/specer.gif" width="700px" height="5px" /></p>
                            <p class="ccdiv1_common">
                                <span class="titletxt_popup_pd"><b>Credit Card Type:</b></span> <span runat="server"
                                    id="spcctype" class="inputconleft_popup_pd"></span><span class="titletxt_popup_pd"><b>
                                        Credit Card No:</b></span> <span runat="server" id="spccnumber" class="inputconright_popup_pd">
                                        </span>
                            </p>
                            <p class="ccdiv1_common">
                                <span class="titletxt_popup_pd"><b>Expiration Date:</b></span> <span runat="server"
                                    id="spexpdate" class="inputconleft_popup_pd"></span>
                            </p>
                            <p class="ccdiv1_common">
                                <span class="titletxt_popup_pd"><b>Card Holder:</b></span> <span runat="server" id="spcardholder"
                                    class="inputconleft_popup_pd"></span>
                            </p>
                        </div>
                        <div id="bycheque" runat="server" style="float: left; display: none;">
                            <p>
                                <img src="/App/Images/specer.gif" width="700px" height="5px" /></p>
                            <p class="fline_chngepack">
                                <img src="/App/Images/specer.gif" width="1px" height="1px" /></p>
                            <p>
                                <img src="/App/Images/specer.gif" width="700px" height="5px" /></p>
                            <p class="ccdiv1_common">
                                <span class="titletxt_popup_pd">Bank Name:</span> <span class="inputconleft_popup_pd">
                                    <asp:TextBox ID="txtBankName" runat="server" CssClass="inputf_def" Width="100px"></asp:TextBox></span>
                                <span class="titletxt1_regcust">A/C Holder:</span> <span class="inputconright_popup_pd">
                                    <asp:TextBox ID="txtAccHolderName" runat="server" CssClass="inputf_def" Width="100px"></asp:TextBox></span>
                            </p>
                            <p class="ccdiv1_common">
                                <span class="titletxt_popup_pd">Type of Account:</span> <span class="inputconleft_popup_pd">
                                    <asp:DropDownList runat="server" ID="ddlaccounttype" Width="110px" CssClass="inputf_def">
                                    </asp:DropDownList>
                                </span><span class="titletxt1_regcust">Account No:</span> <span class="inputconright_popup_pd">
                                    <asp:TextBox ID="txtAccountNum" runat="server" CssClass="inputf_def" Width="130px"></asp:TextBox></span>
                            </p>
                            <p class="ccdiv1_common">
                                <span class="titletxt_popup_pd">Routing No:</span> <span class="inputconleft_popup_pd">
                                    <asp:TextBox runat="server" ID="txtRoutingNum" Width="110px" CssClass="inputf_def">
                                    </asp:TextBox>
                                </span><span class="titletxt1_regcust">Check No<span class="reqiredmark"><sup>*</sup></span>:</span>
                                <span class="inputconright_popup_pd">
                                    <asp:TextBox ID="txtChequeNum" runat="server" CssClass="inputf_def" Width="130px"></asp:TextBox></span>
                            </p>
                        </div>
                        <div id="byCash" runat="server" style="float: left; display: none;">
                            <p>
                                <img src="/App/Images/specer.gif" width="700px" height="5px" /></p>
                            <p class="fline_chngepack">
                                <img src="/App/Images/specer.gif" width="1px" height="1px" /></p>
                            <p>
                                <img src="/App/Images/specer.gif" width="700px" height="5px" /></p>
                            <p class="ccdiv1_common">
                                <span class="titletxt_popup_pd">Enter Amount:</span> <span class="inputconleft_popup_pd">
                                    <asp:TextBox ID="txtcashamount" runat="server" CssClass="inputf_def" Width="100px"></asp:TextBox></span>
                            </p>
                        </div>
                        <div id="_divGiftCertificate" runat="server" style="float: left; display: none; width: 400px">
                            <uc:GCApply ID="GCApply" runat="server" />
                        </div>
                    </div>
                    <p>
                        <img src="/App/Images/specer.gif" width="700px" height="2px" /></p>
                    <p class="graylinefull_common">
                        <img src="/App/Images/specer.gif" width="1px" height="1px" /></p>
                    <p>
                        <img src="/App/Images/specer.gif" width="700px" height="2px" /></p>
                </div>
            </div>
            <div class="main_area_bdrnone" style="display: none;" id="RefundRequestDiv">
                <div style="float: left;">
                    <div>
                        <img src="/App/Images/CCRep/specer.gif" width="740px" height="10px" /></div>
                    <div id="Div5" class="pgnosymbol_common" runat="server">
                        <img src="/App/Images/page3symbolsmall.gif" /></div>
                    <div class="orngheadtxt16_common">
                        Refund Requests</div>
                </div>
                <div id="RefundRequestContentDiv" style="clear: both; float: left;">
                    <img src="/App/Images/indicator.gif" alt="" />
                    Loading Request Window
                </div>
            </div>
            <div id="divCnfrmMsg" style="float: right; width: 350px; display: none; visibility: hidden;">
                <div style="float: left; border: solid 1px #ddd; padding: 5px; background-color: #f8f8f8">
                    <div id="divOldCouponInfo" style="display: none; visibility: hidden;">
                        <p style="float: left; width: 300px; padding-right: 20px">
                            <span style="float: left; width: 110px;"><b>Old Source Code:</b></span> <span style="float: left;
                                width: 190px;"><span id="spOldCouponCode"></span><span>&nbsp;($</span> <span id="spOldCouponAmt">
                                </span><span>)</span> </span>
                        </p>
                    </div>
                    <div id="divNewCouponInfo">
                        <p style="float: left; width: 300px; padding-right: 20px">
                            <span style="float: left; width: 110px;"><b>New Source Code:</b></span> <span style="float: left;
                                width: 190px;"><span id="spNewCouponCode"></span></span>
                        </p>
                        <p style="float: left; width: 300px; padding-right: 20px">
                            <span style="float: left; width: 110px;"><b>Source Code Amt.:</b></span> <span style="float: left;
                                width: 190px;"><span>$&nbsp;</span> <span id="spNewCouponAmt"></span></span>
                        </p>
                    </div>
                </div>
                <p style="float: right; width: 300px; padding-right: 20px">
                    <span style="float: left;">Are you sure to apply this Source Code</span> <span style="float: left;">
                        <asp:RadioButtonList ID="rBtnCnfrm" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Yes"></asp:ListItem>
                            <asp:ListItem Text="No" Selected="True"></asp:ListItem>
                        </asp:RadioButtonList>
                    </span>
                </p>
            </div>
            <div class="buttonrow_bottom_common">
                <span id="spSave" runat="server" class="buttoncon_default" style="display: none;">
                    <asp:ImageButton runat="server" ID="ibtnsave" ImageUrl="~/App/Images/save-button.gif"
                        OnClick="ibtnsave_Click" OnClientClick="return Confirmation();" />
                </span><span id="spCancel" class="buttoncon_default">
                    <asp:ImageButton runat="server" ID="ibtncancel" ImageUrl="~/App/Images/cancel-btn.gif"
                        OnClick="ibtncancel_Click" /></span>
            </div>
        </div>
    </div>
</div>
<%-- **************************** ALL HIDDEN FIELDS ************************** --%>
<asp:HiddenField runat="server" ID="hfdiffamount" Value="0.00" />
<asp:HiddenField runat="server" ID="hfcurrentpayable" Value="0.00" />
<asp:HiddenField runat="server" ID="hfcurrentcouponamount" Value="0.00" />
<asp:HiddenField runat="server" ID="hfcurrentcoupon" Value="" />
<asp:HiddenField runat="server" ID="hfpaidamount" Value="0.00" />
<asp:HiddenField runat="server" ID="hfcouponid" Value="0" />
<asp:HiddenField runat="server" ID="hfcouponamount" Value="0.00" />
<asp:HiddenField runat="server" ID="hfcouponapplied" Value="false" />
<asp:HiddenField runat="server" ID="hfPaymentMode" Value="" />
<asp:HiddenField runat="server" ID="hfPackageCost" Value="0.00" />
<asp:HiddenField runat="server" ID="hfRole" Value="" />
<asp:HiddenField ID="hfstate" runat="server" />
<%-- ************************************************************************* --%>
<script type="text/javascript" language="javascript">
    var states;
    $(document).ready(function() {
        
        states = <%= GetStates() %> ;
        BindSateDropDown(states);
        $('#<%=ddlcountry.ClientID %>').bind("change", function() { BindSateDropDown(states); });

        $('.auto-search-city').autoComplete({
                autoChange: true,
                url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetCityByContextKeyAndPrefixText")%>',
                type: "POST",
                data: "prefixText",
                contextKey: $('.ddl-states option:selected').val()
            });

        $('.ddl-states').change(function() {
            $('.auto-search-city').autoComplete({
                    autoChange: true,
                    url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetCityByContextKeyAndPrefixText")%>',
                    type: "POST",
                    data: "prefixText",
                    contextKey: $('.ddl-states option:selected').val()
                });
            SetState();
        });
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
   
</script>
