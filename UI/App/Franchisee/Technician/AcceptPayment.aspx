<%@ Page Language="C#" AutoEventWireup="True" Inherits="Falcon.App.UI.App.Franchisee.Technician.AcceptPayment"
    CodeBehind="AcceptPayment.aspx.cs" EnableEventValidation="false" %>
<%@ Import Namespace="Falcon.App.Core.Finance.Enum" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit2" TagPrefix="JQueryControl2" %>
<%@ Register Src="~/App/UCCommon/GiftCertificateApply.ascx" TagPrefix="uc" TagName="GCApply" %>
<%@ Register Src="~/App/UCCommon/UcShippingDetails.ascx" TagPrefix="uc" TagName="ShippingOption" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" style="overflow-y: auto;">
<head runat="server">
    <title>Customer Payment</title>
    <link href="../../StyleSheets/Wizardstyle.css" rel="stylesheet" type="text/css" />
    
    <script src="/scripts/jquery-1.5.2.min.js" type="text/javascript"></script>
    <script src="/App/JavascriptFiles/validations.js?v=<%=DateTime.Now.Ticks %>" language="javascript" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">


        function cancelform() {
            parent.parent.GB_hide();
            return false;
        }

        function OpenCloseDivatSave() {
            var ddlpaymentmode = document.getElementById('<%= ddlpaymentmode.ClientID %>');
            if (ddlpaymentmode.selectedIndex == 0)
                return;
            showOrderCatalog();
            var paymentmode = ddlpaymentmode.options[ddlpaymentmode.selectedIndex].value;
            var hfnetpayment = document.getElementById("<%= hfnetpayment.ClientID %>");

            document.getElementById('bycreditcard').style.display = 'none';
            document.getElementById('bycheque').style.display = 'none';
            document.getElementById('bycash').style.display = 'none';
            
            document.getElementById('bycreditcard').style.visibility = 'hidden';
            document.getElementById('bycheque').style.visibility = 'hidden';
            document.getElementById('bycash').style.visibility = 'hidden';

            document.getElementById('byCreditCardOld').style.display = 'none';
            document.getElementById('byCreditCardOld').style.visibility = 'hidden';

            document.getElementById('divBillingOption').style.display = 'none';
            document.getElementById('divBillingOption').style.visibility = 'hidden';
            document.getElementById('byecheck').style.display = 'none';
            document.getElementById('byecheck').style.visibility = 'hidden';

            if (paymentmode == '<%= PaymentType.CreditCard.PersistenceLayerId %>') {
                document.getElementById('bycreditcard').style.display = 'block';
                document.getElementById('bycreditcard').style.visibility = 'visible';
                document.getElementById('divBillingOption').style.display = 'block';
                document.getElementById('divBillingOption').style.visibility = 'visible';
            }
            else if (paymentmode == '<%= PaymentType.ElectronicCheck.PersistenceLayerId %>') {
                document.getElementById('byecheck').style.display = 'block';
                document.getElementById('byecheck').style.visibility = 'visible';
                document.getElementById('divBillingOption').style.display = 'block';
                document.getElementById('divBillingOption').style.visibility = 'visible';
            }
            else if (paymentmode == '<%= PaymentType.Check.PersistenceLayerId %>') {
                document.getElementById('bycheque').style.display = 'block';
                document.getElementById('bycheque').style.visibility = 'visible';
            }
            else if (paymentmode == '<%= PaymentType.Cash.PersistenceLayerId %>') {
                document.getElementById('bycash').style.display = 'block';
                document.getElementById('bycash').style.visibility = 'visible';
                document.getElementById('<%= txtCashAmount.ClientID %>').value = hfnetpayment.value;
            }
            else if (paymentmode == '<%= PaymentType.CreditCardOnFile_Value %>') {
                document.getElementById('byCreditCardOld').style.display = 'block';
                document.getElementById('byCreditCardOld').style.visibility = 'visible';                
            }
        }

        function OpenCloseDiv(ddlpaymentmodeClientid) {
            var ddlpaymentmode = document.getElementById(ddlpaymentmodeClientid);
            if (ddlpaymentmode.selectedIndex == 0)
                return;

            var paymentmode = ddlpaymentmode.options[ddlpaymentmode.selectedIndex].value;
            var hfnetpayment = document.getElementById("<%= hfnetpayment.ClientID %>");

            document.getElementById('bycreditcard').style.display = 'none';
            document.getElementById('bycheque').style.display = 'none';
            document.getElementById('bycash').style.display = 'none';
            document.getElementById('bycreditcard').style.visibility = 'hidden';
            document.getElementById('bycheque').style.visibility = 'hidden';
            document.getElementById('bycash').style.visibility = 'hidden';

            document.getElementById('divBillingOption').style.display = 'none';
            document.getElementById('divBillingOption').style.visibility = 'hidden';
            document.getElementById('byecheck').style.display = 'none';
            document.getElementById('byecheck').style.visibility = 'hidden';

            document.getElementById('byCreditCardOld').style.display = 'none';
            document.getElementById('byCreditCardOld').style.visibility = 'hidden';

            if (paymentmode == '<%= PaymentType.CreditCard.PersistenceLayerId %>') {
                document.getElementById('bycreditcard').style.display = 'block';
                document.getElementById('bycreditcard').style.visibility = 'visible';
                document.getElementById('divBillingOption').style.display = 'block';
                document.getElementById('divBillingOption').style.visibility = 'visible';
                CleanCreditCardControls();
                FillCreditCardInfo();
            }
            else if (paymentmode == '<%= PaymentType.ElectronicCheck.PersistenceLayerId %>') {
                document.getElementById('byecheck').style.display = 'block';
                document.getElementById('byecheck').style.visibility = 'visible';
                document.getElementById('divBillingOption').style.display = 'block';
                document.getElementById('divBillingOption').style.visibility = 'visible';
            }
            else if (paymentmode == '<%= PaymentType.Check.PersistenceLayerId %>') {
                document.getElementById('bycheque').style.display = 'block';
                document.getElementById('bycheque').style.visibility = 'visible';
                CleanChequeControls();
            }
            else if (paymentmode == '<%= PaymentType.Cash.PersistenceLayerId %>') {
                document.getElementById('bycash').style.display = 'block';
                document.getElementById('bycash').style.visibility = 'visible';
                document.getElementById('<%= txtCashAmount.ClientID %>').value = hfnetpayment.value;
            }
            else if (paymentmode == '<%= PaymentType.CreditCardOnFile_Value %>') {
                document.getElementById('byCreditCardOld').style.display = 'block';
                document.getElementById('byCreditCardOld').style.visibility = 'visible';                
            }
        }

        function CleanCreditCardControls() {
            document.getElementById('<%= ddlcardtype.ClientID %>').options[0].selected = true;
            document.getElementById('<%= txtCardNo.ClientID %>').value = '';
            document.getElementById('<%= txtExpirationDate.ClientID %>').value = '';
            document.getElementById('<%= txtSecurityNum.ClientID %>').value = '';
            document.getElementById('<%= rbtBilingAddressSame.ClientID %>').checked = true;
            document.getElementById('<%= rbtBilingAddressDiff.ClientID %>').checked = false;

        }

        function CleanChequeControls() {
            document.getElementById('<%= ddlaccounttype.ClientID %>').options[0].selected = true;
            document.getElementById('<%= txtBankName.ClientID %>').value = '';
            document.getElementById('<%= txtAccHolderName.ClientID %>').value = '';
            document.getElementById('<%= txtAccountNum.ClientID %>').value = '';
            document.getElementById('<%= txtRoutingNum.ClientID %>').value = '';
            document.getElementById('<%= txtChequeNum.ClientID %>').value = '';

        }

        function FillCreditCardInfo() {

            $('.address-text').val(document.getElementById('<%= hfaddress1.ClientID %>').value);
            $('.address2-text').val(document.getElementById('<%= hfaddress2.ClientID %>').value);
            $('.city-text').val(document.getElementById('<%= hfcityname.ClientID %>').value);
            $('.zip-text').val(document.getElementById('<%= hfzipcode.ClientID %>').value);
            document.getElementById('<%= ddlcountry.ClientID %>').value = document.getElementById('<%= hfcountryid.ClientID %>').value;
            $("#<%= ddlstate.ClientID %> option:contains('" + $('#<%=hfstate.ClientID %>').val() + "')").first().attr('selected', true);

            $('.address-text').attr('disabled', 'disabled');
            $('.address2-text').attr('disabled', 'disabled');
            $('.city-text').attr('disabled', 'disabled');
            $('.zip-text').attr('disabled', 'disabled');
            document.getElementById('<%= ddlcountry.ClientID %>').disabled = 'disabled';
            document.getElementById('<%= ddlstate.ClientID %>').disabled = 'disabled';
        }

        function NavigateBillAddress(bolSame) {//debugger;
            if (bolSame == 'Yes') {
                FillCreditCardInfo();
            }
            else {
                $('.address-text').removeAttr('disabled');
                $('.address2-text').removeAttr('disabled');
                $('.city-text').removeAttr('disabled');
                $('.zip-text').removeAttr('disabled');
                document.getElementById('<%= ddlcountry.ClientID %>').disabled = '';
                document.getElementById('<%= ddlstate.ClientID %>').disabled = '';
            }
        }
        function ShowHide() {

        }

        function Validation() {
            var hfnetpayment = document.getElementById("<%= hfnetpayment.ClientID %>");
            if (hfnetpayment.value != "0.00") {
                var IsFullfillmentOption = "<%=IsFullfillmentOption %>";
                if (IsFullfillmentOption == "True") {
                    if (!ValidateShippingAddress())
                        return false;
                }
                var ddlpaymentmode = document.getElementById('<%= ddlpaymentmode.ClientID %>');
                

                var paymentmode = ddlpaymentmode.options[ddlpaymentmode.selectedIndex].value;
                if ((onlyGCApplied == null || onlyGCApplied == undefined || !onlyGCApplied($('#<%=AmountTobePaidTextbox.ClientID %>').val()))) {

                    if (ddlpaymentmode.selectedIndex == 0) {
                        alert('Please Select a payment mode.');
                        return false;
                    }
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
                        if (!validateExpiryDate(txtExpirationDate, "Expiry Date"))
                            return false;
                        if (isBlank(txtSecurityNo, "Security Number"))
                            return false;


                        var txtAddress1 = $('.address-text');
                        var txtCity = $('.city-text');
                        var ddlState = document.getElementById("<%= ddlstate.ClientID %>");
                        var txtZip = $('.zip-text');

                        if (IsBlank(txtAddress1, "Address")) { return false; }
                        if (VerifyLength(txtAddress1, 500, "Address")) { return false; }

                        if (checkDropDown(ddlState, "State for  Address") == false) { return false; }
                        if (IsBlank(txtCity, "City for  Address")) { return false; }
                        if (IsBlank(txtZip, "Zip")) { return false; }
                    }
                    if (paymentmode == '<%= PaymentType.ElectronicCheck.PersistenceLayerId %>') {
                        var txtERoutingNo = document.getElementById("<%= txtERoutingNo.ClientID %>");
                        var txtEAccountNo = document.getElementById("<%= txtEAccountNo.ClientID %>");
                        var ddlEAccountType = document.getElementById("<%= ddlEAccountType.ClientID %>");
                        var txtECheckNo = document.getElementById("<%= txtECheckNo.ClientID %>");
                        var txtEBankName = document.getElementById("<%= txtEBankName.ClientID %>");
                        var txtEAccHolderName = document.getElementById("<%= txtEAccHolderName.ClientID %>");

                        if (isBlank(txtERoutingNo, "Routing No."))
                            return false;
                        if (isBlank(txtEAccountNo, "Account No."))
                            return false;
                        if (checkDropDown(ddlEAccountType, "Account Type") == false)
                            return false;
                        if (isBlank(txtECheckNo, "Check No."))
                            return false;
                        if (isBlank(txtEBankName, "Bank Name."))
                            return false;
                        if (isBlank(txtEAccHolderName, "A/C Holder Name."))
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
                    if (paymentmode == '<%= PaymentType.Cash.PersistenceLayerId %>') {
                        if (isBlank(document.getElementById('<%= txtCashAmount.ClientID %>'), "Amount")) { return false; }
                    }
                    //                if (paymentmode == 'Gift Certificate') {
                    //                    if (!onlyGCApplied($('#<%= hfnetpayment.ClientID %>').val())) {
                    //                        alert("Gift certificate has insufficient amount.");
                    //                        return false;
                    //                    }
                    //                }
                }
            }
            
            if ('<%= (long)CurrentRole %>' == '<%= (long) Falcon.App.Core.Enum.Roles.Customer %>' && !$("#AcceptTermsCheckbox").is(":checked")) {
                alert("Please read and accept our terms and conditions before moving ahead.");
                return false;
            }
            
            document.getElementById("spansave").style.display = 'none';
            document.getElementById("spnIndicator").style.visibility = 'visible';
            document.getElementById("spnIndicator").style.display = 'block';
            return true;
        }

        function IsBlank(Control, returnmessage) {
            val = Control.val();
            if (val == null) {
                alert(returnmessage + ' ' + 'cannot be left blank');
                Control.focus();
                return true;
            }
            for (var i = 0; i < val.length; i++) {
                if ((val.charAt(i) != ' ') && (val.charAt(i) != "\t") && (val.charAt(i) != "\n") && (val.charAt(i) != "\r")) {

                    return false;
                }
            }
            Control.focus();
            alert(returnmessage + ' ' + 'cannot be left blank');
            return true;
        }

        function VerifyLength(Control, limit, returnmessage) {
            val = Control.val();
            if (val.length > limit) {
                alert(returnmessage + " should be less than " + limit);
                Control.focus();
                return false;
            }
        }

        function IsInteger(Control, returnmessage) {
            val = Control.val();
            if (IsBlank(Control, returnmessage)) {
                Control.focus();
                return false;
            }
            for (var i = 0; i < val.length; i++) {
                if (!isDigit(val.charAt(i))) {
                    alert(returnmessage + " cannot be left blank and have some numeric value.");
                    Control.focus();
                    return false;
                }
            }
            return true;
        }

        function txtkeypress(evt) {
            return KeyPress_NumericAllowedOnly(evt);
        }

        function txtkeypressdecimalallowed(evt) {
            return KeyPress_DecimalAllowedOnly(evt);
        }



        function ApplyCouponAmount(result) {//debugger;

            var model = null;
            eval("model = " + result);

            var hfcost = document.getElementById("<%= hfcost.ClientID %>");
            var hfcouponcode = document.getElementById("<%= hfcouponcode.ClientID %>");

            hfcost.value = formatAmount(model.DiscountApplied).toFixed(2);
            hfcouponcode.value = model.SourceCode;

            var hfreportcost = document.getElementById("<%= hfreportcost.ClientID %>");
            var hftoatalcost = document.getElementById("<%= hftoatalcost.ClientID %>");
            var hfnetpayment = document.getElementById("<%= hfnetpayment.ClientID %>");
            var hfpackagecost = document.getElementById("<%= hfpackagecost.ClientID %>");
            var spbillingamount = document.getElementById("<%= spbillingamount.ClientID %>");

            hfreportcost.value = formatAmount(hftoatalcost.value).toFixed(2) - formatAmount(hfpackagecost.value).toFixed(2);

            var dvCoupon = document.getElementById("dvCouponError");
            if (model.SourceCodeId < 1 && model.FeedbackMessage != null) {
                dvCoupon.innerHTML = model.FeedbackMessage.Message;
                hfcouponcode.value = "";
                dvCoupon.style.display = 'block';

                spbillingamount.innerHTML = "$" + hftoatalcost.value;
                hfnetpayment.value = hftoatalcost.value;
                calculateAmount();
                OpenCloseDivatSave();
                return false;
            }
            else {

                dvCoupon.style.display = 'none';

                hfnetpayment.value = formatAmount(hfreportcost.value) + formatAmount(hfpackagecost.value) - formatAmount(hfcost.value);  
                hfnetpayment.value = formatAmount(hfnetpayment.value).toFixed(2);
                spbillingamount.innerHTML = "$" + formatAmount(hfnetpayment.value).toFixed(2);
                calculateAmount();
                document.getElementById('<%= txtCashAmount.ClientID %>').value = formatAmount(hfnetpayment.value).toFixed(2);

                if (hfnetpayment.value == "0.00") {
                    var divPaymentDetails = document.getElementById("<%= divPaymentDetails.ClientID %>");
                    var divTotalFree = document.getElementById("<%= divTotalFree.ClientID %>");

                    divPaymentDetails.style.display = "none";
                    divPaymentDetails.style.visibility = "hidden";

                    divTotalFree.style.display = "block";
                    divTotalFree.style.visibility = "visible";
                }
            }

            OpenCloseDivatSave();
            return false;
        }

        function formatAmount(num) {
            if (isNaN(parseFloat(num)))
            { num = '0.00'; }
            return parseFloat(num);
            try
             { num = num.replace(/^\s+|\s+$/g, ""); }
            catch (err)
             { num = num }

            num = parseFloat(num);
            if (isNaN(num))
            { num = '0.00'; }

            return parseFloat(num.toFixed(2));
        }
        function ReloadParentPage() {
            window.close();
            window.opener.location.reload();
        }
    </script>

    <script type="text/javascript" language="javascript">
        function FirstTimeLoad(resultOrderId) {//debugger
            var IsFullfillmentOption = "<%=IsFullfillmentOption %>";
            if (IsFullfillmentOption == "True") {
                var SelectedOrderRadio = document.getElementById("rbtn" + resultOrderId);
                SelectedOrderRadio.checked = true;
                selectResultOrder(resultOrderId);
            }
        }
        function selectResultOrder(resultOrderId) {//debugger;
            var IsFullfillmentOption = "<%=IsFullfillmentOption %>";
            if (IsFullfillmentOption == "True") {
                var hfResultOrderID = document.getElementById("<%= hfResultOrderID.ClientID %>");
                var SelectedOrderRadio = document.getElementById("rbtn" + resultOrderId);
                var hfnetpayment = document.getElementById("<%= hfnetpayment.ClientID %>");
                var divPaymentDetails = document.getElementById("<%= divPaymentDetails.ClientID %>");
                if (SelectedOrderRadio.checked == true) {
                    var spSalePrice = document.getElementById("spSalePrice" + resultOrderId);
                    var spTitle = document.getElementById("spTitle" + resultOrderId);
                    hfResultOrderID.value = resultOrderId;
                    hfnetpayment.value = spSalePrice.innerHTML;
                    var spbillingamount = document.getElementById("<%=spbillingamount.ClientID %>");
                    spbillingamount.innerHTML = "$" + spSalePrice.innerHTML;

                    calculateAmount();
                }

                if (hfnetpayment.value == "0.00") {
                    divPaymentDetails.style.display = "none";
                    divPaymentDetails.style.visibility = "hidden";
                }
                else {
                    divPaymentDetails.style.display = "block";
                    divPaymentDetails.style.visibility = "visible";
                }
            }
            return true;
        }
        function showOrderCatalog() {
            var IsFullfillmentOption = "<%=IsFullfillmentOption %>";
            if (IsFullfillmentOption == "True") {
                var DivFullfillmentOption = document.getElementById("<%= DivFullfillmentOption.ClientID %>");
                var DivAcceptPayment = document.getElementById("<%=DivAcceptPayment.ClientID %>");
                DivFullfillmentOption.style.display = "block";
                DivAcceptPayment.style.display = "none";
                var hfResultOrderID = document.getElementById("<%= hfResultOrderID.ClientID %>");
                if (parseInt(hfResultOrderID.value) > 0) {
                    var SelectedOrderRadio = document.getElementById("rbtn" + hfResultOrderID.value);
                    SelectedOrderRadio.checked = true;
                    selectResultOrder(parseInt(hfResultOrderID.value));
                }
            }
        }
        function MaintainAfterFailedPostBack() {
            OpenCloseDivatSave();
        }
        $(document).ready(function() { $("form :input").attr("autocomplete", "off"); });
    </script>
    
    <style type="text/css">
    #temrsandconditions-div .tm-header
    {
        float: left;
        padding: 5px;
        width: 98%;
        font-size: 11pt;
        /*background-color: #63A160;*/
        background-color: #1A5EA1;
        margin-bottom: 5px;
        color: #F3FDFF;
        font-weight: bold;
    }
    #temrsandconditions-div .tm-content
    {
        padding: 5px;
        font-size: 10pt;
        margin-bottom: 15px;
        text-align: justify;
    }

    /*.ui-widget-content
    {
        background: #B3D4A7;
        border: 2px solid #496340;
    }

    .ui-widget-header
    {
        background: #B3D4A7;
        color: #000000;
        border: none;
        font-size: 11pt;
    }*/


    </style>
</head>
<body style="background: #fff; overflow-y: auto;">
    <form id="form1" runat="server">
    <JQueryControl2:JQueryToolkit2 ID="JQueryToolkit2" runat="server" IncudeJQueryAutoComplete="true" IncludeJQueryMaskInput="true" IncludeJQueryUI="true" />
    <asp:HiddenField runat="server" ID="hfaddress1" />
    <asp:HiddenField runat="server" ID="hfaddress2" />
    <asp:HiddenField runat="server" ID="hfphonehome" />
    <asp:HiddenField runat="server" ID="hfcountryid" />
    <asp:HiddenField runat="server" ID="hfstate" />
    <asp:HiddenField runat="server" ID="hfcityname" />
    <asp:HiddenField runat="server" ID="hfzipcode" />
    <asp:HiddenField runat="server" ID="hfeventid" />
    <asp:HiddenField runat="server" ID="hfpackagecost" />
    <asp:HiddenField runat="server" ID="hfcouponcode" />
    <asp:HiddenField runat="server" ID="hfcost" />
    <asp:HiddenField runat="server" ID="hfreportcost" />
    <asp:HiddenField runat="server" ID="hfnetpayment" />
    <asp:HiddenField runat="server" ID="hftoatalcost" />
    <asp:HiddenField runat="server" ID="TotalAmountPaid" />    
    <asp:HiddenField runat="server" ID="hfResultOrderID" Value="0" />
    <div class="maindiv_popup">
        <div class="maindivinner_popup">
            <div id="DivAcceptPayment" runat="server">
                <p class="middivrow_regcust_popup">
                    <span style="float: left; padding-left: 5px; font-weight: bold; color: #ff6600;"
                        runat="server" id="spancustomer"></span>
                </p>
                <div id="divapplycoupon" runat="server">
                    <p class="fline_popup_pdt">
                        <img src="../../Images/CCRep/specer.gif" width="1" height="1" /></p>
                    <p class="middivrow_regcust_popup">
                        <span style="padding-bottom: 2px;">If you have 100% discount source code, please Click
                            on apply button to bypass entering billing information.</span>
                    </p>
                    <p class="flinerowbg1_ccrep">
                        <span class="titletxtbldbig_regcust">Enter Source Code:</span> <span class="inputconccoderegcust">
                            <asp:TextBox ID="txtCoupon" runat="server" CssClass="inputfield_ccrep" Width="160px"></asp:TextBox></span>
                        <span class="applycpnbtncon_ccrep">
                            <asp:ImageButton ID="ibtnApplyCoupon" runat="server" ImageUrl="/App/Images/apply-btn.gif"
                                OnClick="ibtnApplyCoupon_Click" />
                        </span>
                    </p>
                </div>
            </div>
            <div id="DivFullfillmentOption" runat="server">
                <p class="subheadingbgpopup_pd">
                    <span class="headtxtleft_popup">Select your fulfillment option</span>
                </p>
                <div class="dgselectpackage_ccrep">
                    <uc:ShippingOption ID="ShippingOption" runat="server" />
                </div>
                <p class="fline_regcust">
                    <img src="/App/Images/CCRep/specer.gif" width="1px" height="1px" /></p>
            </div>
            <p class="normaltxtpopup_popup" style="width: 280px">
                Your total Billing amount is <span id="spbillingamount" runat="server" class="orngbold12_default">
                    <strong>$ 300</strong></span>.
                <span id="AmountToBePaidSpan" class="total-amount-span" style="display:none;">0.00</span>
            </p>
            <div class="" id="dvCouponError" style="width: 250px; color: red; float: left;">
            </div>
            <div style="clear:both; border: solid 1px #CCCCCC; margin-top:5px; margin-bottom: 5px; padding: 10px 5px;" id="PartialPaymentDiv" runat="server">
                <span> <b>How much are you going to pre-pay?</b> </span> <span> <select id="AmountPercentageSelect" onchange="calculateAmount();">
                <option value="100"> 100 %</option>
                <option value="75"> 75 %</option>
                <option value="50"> 50 %</option>
                <option value="25"> 25 %</option> 
                <option value="25.00"> $ 25</option> </select> &nbsp; = &nbsp; </span>
                <span>
                    $ <asp:TextBox runat="server" ID="AmountTobePaidTextbox" Width="40px"></asp:TextBox></span>
                <span style="margin-left: 15px;">
                    Amount Due: $ <asp:TextBox runat="server" ID="AmountDueTextbox" ReadOnly="true" Width="40px"></asp:TextBox>
                </span>
            </div>
            <script language="javascript" type="text/javascript">
                function calculateAmount() {//debugger;

                    var value = $("#<%=hfnetpayment.ClientID %>").val();
                    if (isNaN(value))
                        value = 0;

                    var percentageAmount = Number($("#AmountPercentageSelect option:selected").val());
                    if ($("#AmountPercentageSelect option:selected").text().indexOf('%') >0) {

                        $("#<%= AmountTobePaidTextbox.ClientID %>").val(parseFloat((value * percentageAmount) / 100).toFixed(2));
                        $("#<%= AmountDueTextbox.ClientID %>").val(parseFloat(value - ((value * percentageAmount) / 100)).toFixed(2));
                        $('#AmountToBePaidSpan').html(parseFloat((value * percentageAmount) / 100).toFixed(2));
                    }
                    else {
                        $("#<%= AmountTobePaidTextbox.ClientID %>").val(parseFloat(percentageAmount).toFixed(2));
                        $("#<%= AmountDueTextbox.ClientID %>").val(parseFloat(value - percentageAmount).toFixed(2));
                        $('#AmountToBePaidSpan').html(parseFloat(percentageAmount).toFixed(2));
                    }

                    //$("#<%= AmountTobePaidTextbox.ClientID %>").val(parseFloat((value * percentageAmount) / 100).toFixed(2));
                    //$("#<%= AmountDueTextbox.ClientID %>").val(parseFloat(value - ((value * percentageAmount) / 100)).toFixed(2));
                    //$('#AmountToBePaidSpan').html(parseFloat((value * percentageAmount) / 100).toFixed(2));
                }

                $(document).ready(function () {
                    $("#<%= AmountTobePaidTextbox.ClientID %>").attr("readonly", "readonly");

                    if ('<%=(long)CurrentRole %>' == '<%= (long)Falcon.App.Core.Enum.Roles.CallCenterRep %>') {
                        $('#<%= ddlcardtype.ClientID %>').change(function () {
                            SetAmexAmount();
                        });
                        SetAmexAmount();
                    }

                    calculateAmount();

                    $('form').submit(function () {
                        $("#<%= AmountTobePaidTextbox.ClientID %>").attr("readonly", "");
                    });

                });

                function SetAmexAmount() {
                    if ($('#<%= ddlcardtype.ClientID %> option:selected').val() == '<%= (int)ChargeCardType.AmericanExpress %>' && document.getElementById("<%= TotalAmountPaid.ClientID %>").value == 0) {
                        $("#AmountPercentageSelect option[value=50]").attr("selected", true);
                        $("#AmountPercentageSelect option[value!=50]").attr("disabled", true);
                        $("#AmountPercentageSelect").change();
                    }
                    else {
                        $("#AmountPercentageSelect option[value!=50]").attr("disabled", false);
                        //$("#AmountPercentageSelect option[text=100]").attr("selected", true);
                        calculateAmount();
                    }
                }
    
            </script>
            <div id="DivGiftCertificatePayment" style="float: left;">
                <uc:GCApply ID="GCApply" runat="server" />
            </div>
            <div id="divPaymentDetails" runat="server">
                <p class="subheadingbgpopup_pd">
                    <span class="headtxtleft_popup">Payment Details</span> <span class="headingrightinput_popup">
                        <asp:DropDownList runat="server" ID="ddlpaymentmode" Width="110px" CssClass="inputfield_ccrep">
                        </asp:DropDownList>
                    </span><span class="headingrighttxt_popup">Payment Mode :</span>
                </p>
                <div id="bycreditcard" style="height: 90px; float: left;">
                    <p class="middivrow_regcust_popup">
                        <span class="titletxt_popup_pd">Credit Card Type<span class="reqiredmark"><sup>*</sup></span>:</span>
                        <span class="inputconleft_popup_pd">
                            <asp:DropDownList runat="server" ID="ddlcardtype" Width="140px" CssClass="inputfield_ccrep">
                            </asp:DropDownList>
                        </span><span class="titletxt_popup_pd">Credit Card No<span class="reqiredmark"><sup>*</sup></span>:</span>
                        <span class="inputconright_popup_pd">
                            <asp:TextBox ID="txtCardNo" MaxLength="16" runat="server" CssClass="inputfield_ccrep"
                                Width="130px"></asp:TextBox></span>
                    </p>
                    <p class="middivrow_regcust_popup">
                        <span class="titletxt_popup_pd">Expiration Date<span class="reqiredmark"><sup>*</sup></span>:</span>
                        <span class="inputconleft_popup_pd">
                            <asp:TextBox ID="txtExpirationDate" runat="server" CssClass="inputfield_ccrep mask-date" Width="105px"></asp:TextBox>
                        </span><span class="titletxt_popup_pd">Security No<span class="reqiredmark"><sup>*</sup></span>:</span>
                        <span class="inputconright_popup_pd">
                            <asp:TextBox ID="txtSecurityNum" TextMode="Password" runat="server" autocomplete="off" CssClass="inputfield_ccrep" Width="80px" MaxLength="4"></asp:TextBox></span>
                    </p>
                    <p class="middivrow_regcust_popup">
                        <span class="titletxt_popup_pd">Card Holder<span class="reqiredmark"><sup>*</sup></span>:</span>
                        <span class="inputconleft_popup_pd">
                            <asp:TextBox ID="txtCardHolderName" runat="server" CssClass="inputfield_ccrep" Width="105px"></asp:TextBox>
                        </span>
                    </p>
                </div>
                <div id="byecheck" style="height: 90px; float: left;">
                    <p class="middivrow_regcust_popup">
                        <span class="titletxt_popup_pd">Routing No:<span class="reqiredmark"><sup>*</sup></span>:</span>
                        <span class="inputconleft_popup_pd">
                            <asp:TextBox ID="txtERoutingNo" runat="server" CssClass="inputfield_ccrep" Width="130px"></asp:TextBox>
                        </span><span class="titletxt_popup_pd">Account No:<span class="reqiredmark"><sup>*</sup></span>:</span>
                        <span class="inputconright_popup_pd">
                            <asp:TextBox ID="txtEAccountNo" runat="server" CssClass="inputfield_ccrep" Width="120px"></asp:TextBox>
                        </span>
                    </p>
                    <p class="middivrow_regcust_popup">
                        <span class="titletxt_popup_pd">Type of Account:<span class="reqiredmark"><sup>*</sup></span>:</span>
                        <span class="inputconleft_popup_pd">
                            <asp:DropDownList runat="server" ID="ddlEAccountType" Width="135px" CssClass="inputf_def">
                            </asp:DropDownList>
                        </span><span class="titletxt_popup_pd">Check No:<span class="reqiredmark"><sup>*</sup></span>:</span>
                        <span class="inputconright_popup_pd">
                            <asp:TextBox ID="txtECheckNo" runat="server" CssClass="inputfield_ccrep" Width="120px"
                                MaxLength="20"></asp:TextBox>
                        </span>
                    </p>
                    <p class="middivrow_regcust_popup">
                        <span class="titletxt_popup_pd">Bank Name:<span class="reqiredmark"><sup>*</sup></span>:</span>
                        <span class="inputconleft_popup_pd">
                            <asp:TextBox ID="txtEBankName" runat="server" CssClass="inputfield_ccrep" Width="130px"></asp:TextBox>
                        </span><span class="titletxt_popup_pd">A/C Holder:<span class="reqiredmark"><sup>*</sup></span>:</span>
                        <span class="inputconright_popup_pd">
                            <asp:TextBox ID="txtEAccHolderName" runat="server" CssClass="inputfield_ccrep" Width="120px"></asp:TextBox>
                        </span>
                    </p>
                </div>
                <div id="divBillingOption" style="height: 200px; float: left;">
                    <div class="flinerowbg_ccrep" style="width: 530px; float: left;">
                        <p class="contentrow_pw" style="width: 520px; float: left;">
                            <span class="titletextblueboldpopup_ccrep">Is Billing Address same as Contact Address?</span>
                            <span class="radiatxtbox2_popup_pd">
                                <asp:RadioButton ID="rbtBilingAddressSame" onClick="NavigateBillAddress('Yes');"
                                    runat="server" GroupName="BillingAddress" />
                                YES</span> <span class="radiatxtbox2_popup_pd">
                                    <asp:RadioButton ID="rbtBilingAddressDiff" onClick="NavigateBillAddress('No');" runat="server"
                                        GroupName="BillingAddress" />
                                    NO</span>
                        </p>
                    </div>
                    <p class="middivrow_regcust_popup">
                        <span class="titletxt_popup_pd">Address1<span class="reqiredmark"><sup>*</sup></span>:</span>
                        <span class="inputconleft_popup_pd">
                            <asp:TextBox ID="txtAddress1" runat="server" CssClass="inputfield_ccrep address-text"
                                Width="135px"></asp:TextBox></span>
                    </p>
                    <p class="middivrow_regcust_popup">
                        <span class="titletxt_popup_pd">Suite/Apt<span class="reqiredmark"><sup>*</sup></span>:</span>
                        <span class="inputconleft_popup_pd">
                            <asp:TextBox ID="txtAddress2" runat="server" CssClass="inputfield_ccrep address2-text"
                                Width="135px"></asp:TextBox></span>
                    </p>
                    <p class="middivrow_regcust_popup">
                        <span class="titletxt_popup_pd">Country<span class="reqiredmark"><sup>*</sup></span>:</span>
                        <span class="inputconleft_popup_pd">
                            <asp:DropDownList ID="ddlcountry" runat="server" Width="140px" CssClass="inputfield_ccrep">
                            </asp:DropDownList>
                        </span>
                    </p>
                    <p class="middivrow_regcust_popup">
                        <span class="titletxt_popup_pd">State<span class="reqiredmark"><sup>*</sup></span>:</span>
                        <span class="inputconleft_popup_pd">
                            <asp:DropDownList runat="server" ID="ddlstate" Width="140px" CssClass="inputfield_ccrep ddl-states">
                            </asp:DropDownList>
                        </span>
                    </p> 
                    <p class="middivrow_regcust_popup">
                        <span class="titletxt_popup_pd">City<span class="reqiredmark"><sup>*</sup></span>:</span>
                        <span class="inputconleft_popup_pd">
                            <asp:TextBox runat="server" ID="txtCity" Width="100px" CssClass="inputfield_ccrep auto-Search city-text">
                            </asp:TextBox>
                        </span>
                    </p>                                       
                    <p class="middivrow_regcust_popup">
                        <span class="titletxt_popup_pd">Zip<span class="reqiredmark"><sup>*</sup></span>:</span>
                        <span class="inputconleft_popup_pd">
                            <asp:TextBox ID="txtZip" runat="server" CssClass="inputfield_ccrep zip-text" Width="70px"></asp:TextBox></span>
                    </p>
                </div>
                <div id="bycheque" style="height: 290px; float: left;">
                    <p class="middivrow_regcust_popup">
                        <span class="titletxt_popup_pd">Bank Name:</span> <span class="inputconleft_popup_pd">
                            <asp:TextBox ID="txtBankName" runat="server" CssClass="inputfield_ccrep" Width="100px"></asp:TextBox></span>
                        <span class="titletxt1_regcust">A/C Holder:</span> <span class="inputconright_popup_pd">
                            <asp:TextBox ID="txtAccHolderName" runat="server" CssClass="inputfield_ccrep" Width="100px"></asp:TextBox></span>
                    </p>
                    <p class="middivrow_regcust_popup">
                        <span class="titletxt_popup_pd">Type of Account:</span> <span class="inputconleft_popup_pd">
                            <asp:DropDownList runat="server" ID="ddlaccounttype" Width="110px" CssClass="inputfield_ccrep">
                            </asp:DropDownList>
                        </span><span class="titletxt1_regcust">Account No:</span> <span class="inputconright_popup_pd">
                            <asp:TextBox ID="txtAccountNum" runat="server" CssClass="inputfield_ccrep" Width="130px"></asp:TextBox></span>
                    </p>
                    <p class="middivrow_regcust_popup">
                        <span class="titletxt_popup_pd">Routing No:</span> <span class="inputconleft_popup_pd">
                            <asp:TextBox runat="server" ID="txtRoutingNum" Width="110px" CssClass="inputfield_ccrep">
                            </asp:TextBox>
                        </span><span class="titletxt1_regcust">Check No<span class="reqiredmark"><sup>*</sup></span>:</span>
                        <span class="inputconright_popup_pd">
                            <asp:TextBox ID="txtChequeNum" runat="server" CssClass="inputfield_ccrep" Width="130px"></asp:TextBox></span>
                    </p>
                </div>
                <div id="bycash" style="height: 290px; float: left;">
                    <p class="middivrow_regcust_popup">
                        <span class="titletxt_popup_pd">Amount<span class="reqiredmark"><sup>*</sup></span>:</span>
                        <span class="inputconleft_popup_pd">
                            <asp:TextBox ID="txtCashAmount" runat="server" CssClass="inputfield_ccrep" Width="130px"></asp:TextBox></span>
                    </p>
                </div>
                <div id="byCreditCardOld" style="height: 290px; float: left;">                    
                    <p style="float:left; width:98%; margin-bottom:10px;">
                        <span class="titletxt_popup_pd"><b>Credit Card Type:</b></span> 
                        <span runat="server" id="spcctype" class="inputconleft_popup_pd"></span>
                        <span class="titletxt_popup_pd"><b>Credit Card No:</b></span> 
                        <span runat="server" id="spccnumber" class="inputconright_popup_pd"></span>
                    </p>
                    <p style="float:left; width:98%; margin-bottom:10px;">
                        <span class="titletxt_popup_pd"><b>Expiration Date:</b></span> 
                        <span runat="server" id="spexpdate" class="inputconleft_popup_pd"></span>
                    </p>
                    <p style="float:left; width:98%; margin-bottom:10px;">
                        <span class="titletxt_popup_pd"><b>Card Holder:</b></span> 
                        <span runat="server" id="spcardholder" class="inputconright_popup_pd"></span>
                    </p>
                </div>              
            </div>
            <div id="divTotalFree" runat="server" style="display: none; visibility: hidden;">
                <p class="fline_popup_pdt">
                    <img src="../../Images/CCRep/specer.gif" width="1" height="1" /></p>
                <p class="middivrow_regcust_popup">
                    <span style="float: left; width: 20px;">
                        <img src="/App/Images/error-icon.gif" /></span> <span style="float: left; width: 500px;">
                            &nbsp;As you have given 100% discount source code, no billing information is required
                            from your side. Please click on Submit button to get confirmation receipt.</span>
                </p>
            </div>
            <p class="fline_popup_pdt">
                <img src="../../Images/CCRep/specer.gif" width="1" height="1" /></p>
            <div style="float:left; width:400px; display: none;" id="TermsAndConditionDiv">
                <input type="checkbox" id="AcceptTermsCheckbox"/> I agree with <a href="javascript:void(0);" onclick="openTermsAndConditions();">Terms &amp; conditions and cancellation policy. </a>
            </div>
            <p class="buttoncell_ccrep" style="margin-top: 5px">
                <span class="buttoncon_ccrep" style="visibility: hidden; display: none;">
                    <asp:ImageButton ID="ImageButton2" OnClientClick="return cancelform();" runat="server" ImageUrl="../../Images/cancel-button.gif" />
                </span> 
                <span class="buttoncon_ccrep" style="float: right; visibility: hidden; display: none;" id="spnIndicator">
                    <img src="/App/Images/indicator.gif" />
                </span>
                <span class="buttoncon_ccrep" style="float: right;" id="spansave">
                    <asp:ImageButton ID="ibtnAccept" runat="server" ImageUrl="../../Images/accept-button.gif" OnClick="ibtnAccept_Click" OnClientClick="return Validation();" />
                </span>
            </p>
        </div>
    </div>
    <div id="temrsandconditions-div" style="display: none;">
        <% Response.WriteFile("/Config/Content/Views/Shared/TermsAndConditions.cshtml"); %>
        <p style="border-top: solid 1px #1a5ea1; padding-top: 10px; text-align: right;">
            <input name="Accept1" type="button" id="Accept1" value="Close" class="button_green" onclick="$('#temrsandconditions-div').dialog('close');" />
        </p>
    </div>

    <script type="text/javascript" language="javascript">
        var states;
        $(document).ready(function() {
            
            $('.mask-date').mask('99/9999');

            states = <%= GetStates() %> ;
            BindSateDropDown(states);
            $('#<%=ddlcountry.ClientID %>').bind("change", function() { BindSateDropDown(states); });

            $('.auto-Search').autoComplete({
                    autoChange: true,
                    url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetCityByContextKeyAndPrefixText")%>',
                    type: "POST",
                    data: "prefixText",
                    contextKey: $('.ddl-states option:selected').val()
                });

            $('.ddl-states').change(function() {
                $('.auto-Search').autoComplete({
                        autoChange: true,
                        url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetCityByContextKeyAndPrefixText")%>',
                        type: "POST",
                        data: "prefixText",
                        contextKey: $('.ddl-states option:selected').val()
                    });
                SetState();
            });
            
            $("#temrsandconditions-div").dialog({ width: 600, autoOpen: false, title: 'Terms & Conditions', modal: true, resizable: false, draggable: true });
            
            if ('<%=(long)CurrentRole %>' == '<%= (long)Falcon.App.Core.Enum.Roles.Customer %>') {
                $("#TermsAndConditionDiv").show();
            }
        });
        
        function openTermsAndConditions() {
            $('#temrsandconditions-div').dialog('open');
        }
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

    <asp:HiddenField ID="hfPaymentTypeID" Value="0" runat="server" />
    </form>
</body>
</html>
