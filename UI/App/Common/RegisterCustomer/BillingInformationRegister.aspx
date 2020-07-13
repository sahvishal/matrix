<%@ Page Language="C#" MasterPageFile="~/App/Franchisee/Technician/TechnicianMaster.master"
    Title="Payment Details" AutoEventWireup="true" Inherits="Falcon.App.UI.App.Common.RegisterCustomer.BillingInformation"
    CodeBehind="BillingInformationRegister.aspx.cs" EnableEventValidation="false" %>

<%@ Import Namespace="Falcon.App.Core.Finance.Enum" %>
<%@ Register TagPrefix="uc" Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" %>
<%@ Register Src="~/App/UCCommon/GiftCertificateApply.ascx" TagPrefix="uc" TagName="GCApply" %>
<%@ Register Src="~/App/UCCommon/OrderSummary.ascx" TagName="OrderSummary" TagPrefix="SummaryControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc:JQueryToolkit ID="_jQueryToolkit" runat="server" IncludeAjax="true" IncludeJQueryUI="true"
        IncudeJQueryAutoComplete="true" IncludeJQueryMaskInput="true" />
    <script language="javascript" type="text/javascript" src="/Scripts/jquery.unobtrusive-ajax.js"></script>
    <script language="javascript" type="text/javascript">
//<![CDATA[
        var cot_loc0 = (window.location.protocol == "https:") ? "https://secure.comodo.net/trustlogo/javascript/cot.js" :
            "http://www.trustlogo.com/trustlogo/javascript/cot.js";
        document.writeln('<scr' + 'ipt language="JavaScript" src="' + cot_loc0 + '" type="text\/javascript">' + '<\/scr' + 'ipt>');
//]]>
    </script>
    <script type="text/javascript" language="javascript">
        window.history.forward(1);
    </script>
    <script type="text/javascript" src="../../JavascriptFiles/HttpRequest.js"></script>
    <script type="text/javascript" language="javascript">
        var postRequest = new HttpRequest();
        postRequest.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        postRequest.failureCallback = requestFailed();

        function requestFailed()
        { }

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
        function CheckBillingAddress() {
            var DVAddress = document.getElementById('<%= DVAddress.ClientID %>');
            var rbtBillingAddressY = document.getElementById('<%= rbtBillingAddressY.ClientID %>');
            var hfBillingAdd = document.getElementById("<%=hfBillingAdd.ClientID %>");
            if (rbtBillingAddressY.checked) {
                DVAddress.style.display = "none";
                DVAddress.style.visibility = "hidden";
                hfBillingAdd.value = "1";
            }
            else {
                DVAddress.style.display = "block";
                DVAddress.style.visibility = "visible";
                hfBillingAdd.value = "0";
            }
            return true;
        }

        function Validation() {

            var ddlCCType = document.getElementById("<%= ddlCCType.ClientID %>");
            var txtCCNo = document.getElementById("<%= txtCCNo.ClientID %>");
            var txtExpirationDate = document.getElementById("<%= txtExpirationDate.ClientID %>");
            var txtSequrityNo = document.getElementById("<%= txtSequrityNo.ClientID %>");
            var txtCName = document.getElementById("<%= txtCName.ClientID %>");
            var rbtBillingAddressY = document.getElementById("<%= rbtBillingAddressY.ClientID %>");
            var hfNetPayableAmount = document.getElementById("<%= hfNetPayableAmount.ClientID %>");
            var ddlPayMode = document.getElementById("<%=ddlPayMode.ClientID %>");

            if (parseFloat(hfNetPayableAmount.value) > 0) {
                if (!onlyGCApplied(hfNetPayableAmount.value)) {

                    if (checkDropDown(ddlPayMode, "Payment mode") == false)
                        return false;
                    if (ddlPayMode.options[ddlPayMode.selectedIndex].value == '<%= PaymentType.CreditCard.PersistenceLayerId %>') {
                        if (isBlank(txtCName, "Name on Card") || (checkDropDown(ddlCCType, "Credit Card Type") == false))
                            return false;

                        if (isBlank(txtCCNo, "Credit Card Number"))
                            return false;
                        //debugger;
                        var isReturn = isValidCreditCard(ddlCCType.options[ddlCCType.selectedIndex].text, txtCCNo.value);

                        if (!isReturn) {
                            alert("Please enter a valid credit card number");
                            txtCCNo.focus();
                            return false;
                        }
                        if (isBlank(txtExpirationDate, "Expiry Date"))
                            return false;
                        if (!validateExpiryDate(txtExpirationDate, "Expiry Date"))
                            return false;
                        if (isBlank(txtSequrityNo, "Security Number"))
                            return false;

                        if (rbtBillingAddressY.checked != true) {
                            var txtAddress1 = document.getElementById("<%= txtAddress1.ClientID %>");
                            var txtAddress2 = document.getElementById("<%= txtAddress2.ClientID %>");
                            var txtCity = document.getElementById("<%= txtCity.ClientID %>");
                            var ddlState = document.getElementById("<%= ddlState.ClientID %>");
                            var txtZip = document.getElementById("<%= txtZip.ClientID %>");
                            var txtHPhone = document.getElementById("<%= txtHPhone.ClientID %>");


                            if (isBlank(txtAddress1, "Address1")) { return false; }
                            if (checkLength(txtAddress1, 500, "Address1")) { return false; }
                            if (checkLength(txtAddress2, 500, "Address2")) { return false; }
                            if (checkDropDown(ddlState, "State for  Address") == false) { return false; }
                            if (isBlank(txtCity, "City for  Address")) { return false; }
                            if (isBlank(txtZip, "Zip")) { return false; }

                        }
                    }
                    else if (ddlPayMode.options[ddlPayMode.selectedIndex].value == '<%= PaymentType.ElectronicCheck.PersistenceLayerId %>') {
                        var txtERoutingNo = document.getElementById("<%=txtERoutingNo.ClientID %>")
                        var txtEAccountNo = document.getElementById("<%=txtEAccountNo.ClientID %>");
                        var ddlEAccountType = document.getElementById("<%=ddlEAccountType.ClientID %>");
                        var txtECheckNo = document.getElementById("<%=txtECheckNo.ClientID %>");
                        var txtEBankName = document.getElementById("<%=txtEBankName.ClientID %>");
                        var txtEAccHolderName = document.getElementById("<%=txtEAccHolderName.ClientID %>");

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

                        if (rbtBillingAddressY.checked != true) {
                            var txtAddress1 = document.getElementById("<%= txtAddress1.ClientID %>");
                            var txtAddress2 = document.getElementById("<%= txtAddress2.ClientID %>");
                            var txtCity = document.getElementById("<%= txtCity.ClientID %>");
                            var ddlState = document.getElementById("<%= ddlState.ClientID %>");

                            var txtZip = document.getElementById("<%= txtZip.ClientID %>");
                            var txtHPhone = document.getElementById("<%= txtHPhone.ClientID %>");


                            if (isBlank(txtAddress1, "Address1")) { return false; }
                            if (checkLength(txtAddress1, 500, "Address1")) { return false; }
                            if (checkLength(txtAddress2, 500, "Address2")) { return false; }

                            if (checkDropDown(ddlState, "State for  Address") == false) { return false; }
                            if (isBlank(txtCity, "City for  Address")) { return false; }
                            if (isBlank(txtZip, "Zip")) { return false; }

                        }
                    }
                    else if (ddlPayMode.options[ddlPayMode.selectedIndex].value == '<%= PaymentType.Check.PersistenceLayerId %>') {
                        var txtChequeNum = document.getElementById("<%=txtChequeNum.ClientID %>");
                        if (isBlank(txtChequeNum, "Check Number"))
                            return false;
                        if (Validate_CheckForSpecialCharacters('<%= txtChequeNum.ClientID %>') == false) {
                            alert('Please input alphanumeric characters only for Check No.');
                            return false;
                        }
                    }
                }
            }
            else {
                var rbtBillingAddressY = document.getElementById('<%= rbtBillingAddressY.ClientID %>');
                rbtBillingAddressY.checked = true;
                var hfBillingAdd = document.getElementById("<%=hfBillingAdd.ClientID %>");
                hfBillingAdd.value = "1";
            }
            document.getElementById("spansave").style.display = 'none';
            document.getElementById("spnIndicator").style.visibility = 'visible';
            document.getElementById("spnIndicator").style.display = 'block';
            __doPostBack('save', '');

            return false;
        }

        function CheckDecimal(evt) {
            return KeyPress_DecimalAllowedOnly(evt);
        }

        function CallEnd() {
            postRequest.url = "RegisterCustomerCall.aspx?CallEnd=True";
            postRequest.post("");
            window.location = "/../../CallCenter/CallCenterRepDashboard/Index";
        }
        function PrintReceipt() {
            // debugger
            postRequest.url = "../Receipt.aspx";
            postRequest.successCallback = GenerateReceipt;
            postRequest.post("");
            return false;
        }
        function GenerateReceipt(httpRequest) {
            TechnicianRegisterPCP();
        }

        function ExistingCustomerPrintReceipt() {
            // debugger
            postRequest.url = "../Receipt.aspx";
            postRequest.successCallback = ExistingCustomerGenerateReceipt;
            postRequest.post("");
            return false;
        }

        function ExistingCustomerGenerateReceipt(httpRequest) {
            TechnicianExistingPCP();
        }

        function ShowHide() {//debugger
            var ddlPayMode = document.getElementById("<%=ddlPayMode.ClientID %>");
            var temp = false;
            var bycreditcard = document.getElementById("<%=bycreditcard.ClientID %>");
            var bycheque = document.getElementById("<%=bycheque.ClientID %>");
            var divBillingOption = document.getElementById("<%=divBillingOption.ClientID %>");
            var byECheck = document.getElementById("<%=byECheck.ClientID %>");
            var hfPaymentMode = document.getElementById("<%=hfPaymentMode.ClientID %>");
            hfPaymentMode.value = ddlPayMode.options[ddlPayMode.selectedIndex].value;

            bycreditcard.style.display = "none";
            byECheck.style.display = "none";
            divBillingOption.style.display = "none";
            bycheque.style.display = "none";

            if (ddlPayMode.options[ddlPayMode.selectedIndex].value == '<%= PaymentType.CreditCard.PersistenceLayerId %>') {
                bycreditcard.style.display = "block";
                divBillingOption.style.display = "block";
            }
            else if (ddlPayMode.options[ddlPayMode.selectedIndex].value == '<%= PaymentType.ElectronicCheck.PersistenceLayerId %>') {
                byECheck.style.display = "block";
                divBillingOption.style.display = "block";
            }
            else if (ddlPayMode.options[ddlPayMode.selectedIndex].value == '<%= PaymentType.Check.PersistenceLayerId %>') {
                bycheque.style.display = "block";
                var rbtBillingAddressY = document.getElementById('<%= rbtBillingAddressY.ClientID %>');
                rbtBillingAddressY.checked = true;
                var hfBillingAdd = document.getElementById("<%=hfBillingAdd.ClientID %>");
                hfBillingAdd.value = "1";
            }
            else if (ddlPayMode.options[ddlPayMode.selectedIndex].value == '<%= PaymentType.Cash.PersistenceLayerId %>') {
                var rbtBillingAddressY = document.getElementById('<%= rbtBillingAddressY.ClientID %>');
                rbtBillingAddressY.checked = true;
                var hfBillingAdd = document.getElementById("<%=hfBillingAdd.ClientID %>");
                hfBillingAdd.value = "1";
            }
        }

        function SetValuesafterFailedPostBack() {//debugger

            var bycreditcard = document.getElementById("<%=bycreditcard.ClientID %>");
            var bycheque = document.getElementById("<%=bycheque.ClientID %>");
            var byECheck = document.getElementById("<%=byECheck.ClientID %>");
            var divBillingOption = document.getElementById("<%=divBillingOption.ClientID %>");
            var hfPaymentMode = document.getElementById("<%=hfPaymentMode.ClientID %>");

            bycreditcard.style.display = "none";
            byECheck.style.display = "none";
            divBillingOption.style.display = "none";
            bycheque.style.display = "none";

            if (hfPaymentMode.value == '<%= PaymentType.CreditCard.PersistenceLayerId %>') {
                bycreditcard.style.display = "block";
                divBillingOption.style.display = "block";

                var hfBillingAdd = document.getElementById("<%=hfBillingAdd.ClientID %>");
                var DVAddress = document.getElementById('<%= DVAddress.ClientID %>');

                if (hfBillingAdd.value == "1") {
                    DVAddress.style.display = "none";
                    DVAddress.style.visibility = "hidden";
                }
                else if (hfBillingAdd.value == "0") {
                    DVAddress.style.display = "block";
                    DVAddress.style.visibility = "visible";
                }
            }
            else if (hfPaymentMode.value == '<%= PaymentType.ElectronicCheck.PersistenceLayerId %>') {                
                byECheck.style.display = "block";
                divBillingOption.style.display = "block";
                

                var hfBillingAdd = document.getElementById("<%=hfBillingAdd.ClientID %>");
                var DVAddress = document.getElementById('<%= DVAddress.ClientID %>');
                if (hfBillingAdd.value == "1") {
                    DVAddress.style.display = "none";
                    DVAddress.style.visibility = "hidden";
                }
                else if (hfBillingAdd.value == "0") {
                    DVAddress.style.display = "block";
                    DVAddress.style.visibility = "visible";
                }
            }
            else if (hfPaymentMode.value == '<%= PaymentType.Check.PersistenceLayerId %>') {
                bycheque.style.display = "block";
            }
        }
        $(document).ready(function() { $("form :input").attr("autocomplete", "off"); });
    </script>
    <div class="mainbody_outer">
        <div class="mainbody_inner">
            <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p>
                        <img src="/App/Images/specer.gif" width="700px" height="5px" /></p>
                    <span class="orngheadtxt_heading" id="dvTitle" runat="server">Technician Register Customer</span>
                </div>
            </div>
            <div class="maindivredmsgbox" id="errordiv" runat="server" visible="false">
            </div>
            <div class="main_area_bdr">
                <div class="maincontentrow_ccrep">
                    <div class="regcust_innercon">
                        <span>
                            <img src="../../Images/CCRep/specer.gif" width="740px" height="5px" /></span>
                        <div class="regcust_innerrow">
                            <div class="pgnosymbol_regcust">
                                <img src="../../Images/CCRep/page5symbol.gif" id="imgSymbol" runat="server" />
                            </div>
                            <div class="middivrow_regcust">
                                <p class="orngheadtxt_regcust" style="visibility: hidden; display: none;">
                                    Register New Customer</p>
                                <p class="fline_regcust" style="visibility: hidden; display: none;">
                                    <img src="../../Images/CCRep/specer.gif" width="1px" height="1px" /></p>
                                <p class="contentrow_regcust">
                                    <span class="orngbold16_default">Billing Information</span></p>
                                <p class="fline_regcust">
                                    <img src="../../Images/CCRep/specer.gif" width="1px" height="1px" /></p>
                                <div style="width: 530px; float: left; margin: 10px 0px">
                                    <SummaryControl:OrderSummary ID="OrderSummaryControl" runat="server" />
                                </div>
                                <div style="display:none;"> <span class="total-amount-span"><%=TotalAmount%></span></div>
                                <div class="sourcecode_cc" id="InsurancePaymentModeDiv">
                                    <div>
                                        <b>Do you have insurance?</b>
                                        <input type="radio" onclick="insurancePaymentMode(true)" name="eligibility" id="EligibilityYesRadioButton"/>Yes
                                        <input type="radio" title="No" onclick="insurancePaymentMode(false)" name="eligibility" id="EligibilityNoRadioButton"/>No
                                    </div>
                                    <div class="insurance-payment-detail" style="display: none;">
                                        <span>Amount covered by insurance:</span>
                                        <span id="insurance-amount"></span>
                                    </div>
                                    <div class="insurance-payment-detail" style="display: none;">
                                        <span>Co Pay:</span>
                                        <span id="copay-amount"></span>
                                    </div>
                                    <input type="hidden" id="EligibilityIdHiddenField" runat="server" value="0"/>
                                    <input type="hidden" id="ChargeCardIdHiddenField" runat="server" value="0"/>
                                    <input type="hidden" id="InsuranceAmountHiddenField" runat="server" value="0"/>
                                    <input type="hidden" id="CoPayAmountHiddenField" runat="server" value="0"/>
                                </div>
                                <p class="normaltxt_regcust payby-gc">
                                    <uc:GCApply ID="GCApply" runat="server" />
                                </p>
                                <div id="divPaymentDetails" runat="server" class="other-payment-mode-detail">
                                    <p class="subheadingbg_ccrep">
                                        Payment Details
                                    </p>
                                    <div>
                                        <p class="middivrow_regcust">
                                            <span class="titletxt_regcust">Payment Mode<span class="reqiredmark"><sup>*</sup></span>:</span>
                                            <span class="inputconright_regcust">
                                                <asp:DropDownList runat="server" ID="ddlPayMode" Width="150px" CssClass="inputfield_ccrep cancel-other-payment-mode">
                                                </asp:DropDownList>
                                            </span>
                                        </p>
                                    </div>
                                    <div id="bycreditcard" runat="server" style="display: none;">
                                        <p class="fline_regcust">
                                            <img src="../../Images/CCRep/specer.gif" width="1px" height="1px" /></p>
                                        <p class="middivrow_regcust">
                                            <span class="titletxt_regcust">Name on Card<span class="reqiredmark"><sup>*</sup></span>:</span>
                                            <span class="inputconleft_regcust">
                                                <asp:TextBox ID="txtCName" runat="server" CssClass="inputfield_ccrep" Width="130px"></asp:TextBox>
                                            </span>
                                        </p>
                                        <p class="middivrow_regcust">
                                            <span class="titletxt_regcust">Credit Card No<span class="reqiredmark"><sup>*</sup></span>:</span>
                                            <span class="inputconright_regcust" style="width: 150px">
                                                <asp:TextBox ID="txtCCNo" runat="server" CssClass="inputfield_ccrep" Width="130px"
                                                    MaxLength="16"></asp:TextBox>
                                            </span><span class="titletxt_regcust">Credit Card Type<span class="reqiredmark"><sup>*</sup></span>:</span>
                                            <span class="inputconleft_regcust">
                                                <asp:DropDownList runat="server" ID="ddlCCType" Width="140px" CssClass="inputfield_ccrep">
                                                </asp:DropDownList>
                                            </span>
                                        </p>
                                        <p class="middivrow_regcust">
                                            <span class="titletxt_regcust">Expiration Date<span class="reqiredmark"><sup>*</sup></span>:</span>
                                            <span class="inputconleft_regcust" style="font-size: 9px; color: #000;">
                                                <asp:TextBox ID="txtExpirationDate" runat="server" CssClass="inputfield_ccrep" Width="85px"
                                                    MaxLength="7"></asp:TextBox>&nbsp;MM/YYYY </span><span class="titletxt_regcust">Security
                                                        Code<span class="reqiredmark"><sup>*</sup></span>:</span> <span class="inputconright_regcust">
                                                            <asp:TextBox ID="txtSequrityNo" runat="server" CssClass="inputfield_ccrep" Width="80px"
                                                                MaxLength="4"></asp:TextBox>
                                                        </span>
                                        </p>
                                    </div>
                                    <div id="byECheck" runat="server" style="display: none;">
                                        <p class="fline_regcust">
                                            <img src="../../Images/CCRep/specer.gif" width="1px" height="1px" /></p>
                                        <p class="middivrow_regcust">
                                            <span class="titletxt_regcust">Routing No:<span class="reqiredmark"><sup>*</sup></span></span>
                                            <span class="inputconleft_regcust">
                                                <asp:TextBox ID="txtERoutingNo" runat="server" CssClass="inputfield_ccrep" Width="130px"></asp:TextBox>
                                            </span><span class="titletxt_regcust">Account No:<span class="reqiredmark"><sup>*</sup></span></span>
                                            <span class="inputconright_regcust">
                                                <asp:TextBox ID="txtEAccountNo" runat="server" CssClass="inputfield_ccrep" Width="120px"></asp:TextBox>
                                            </span>
                                        </p>
                                        <p class="middivrow_regcust">
                                            <span class="titletxt_regcust">Type of Account:<span class="reqiredmark"><sup>*</sup></span></span>
                                            <span class="inputconleft_regcust">
                                                <asp:DropDownList runat="server" ID="ddlEAccountType" Width="135px" CssClass="inputf_def">
                                                </asp:DropDownList>
                                            </span><span class="titletxt_regcust">Check No:<span class="reqiredmark"><sup>*</sup></span></span>
                                            <span class="inputconright_regcust">
                                                <asp:TextBox ID="txtECheckNo" runat="server" CssClass="inputfield_ccrep" Width="120px"
                                                    MaxLength="20"></asp:TextBox>
                                            </span>
                                        </p>
                                        <p class="middivrow_regcust">
                                            <span class="titletxt_regcust">Bank Name:<span class="reqiredmark"><sup>*</sup></span></span>
                                            <span class="inputconleft_regcust">
                                                <asp:TextBox ID="txtEBankName" runat="server" CssClass="inputfield_ccrep" Width="130px"></asp:TextBox>
                                            </span><span class="titletxt_regcust">A/C Holder:<span class="reqiredmark"><sup>*</sup></span></span>
                                            <span class="inputconright_regcust">
                                                <asp:TextBox ID="txtEAccHolderName" runat="server" CssClass="inputfield_ccrep" Width="120px"></asp:TextBox>
                                            </span>
                                        </p>
                                        <p class="middivrow_regcust">
                                            <span style="float: left; padding-left: 10px;">
                                                <img src="/App/Images/check-routing-sample.gif" /></span>
                                        </p>
                                    </div>
                                    <div id="divBillingOption" runat="server" style="display: none;">
                                        <div class="flinerowbg_ccrep">
                                            <p class="contentrow_pw">
                                                <span class="titletextbluebold_ccrep">Is Billing Address same as Contact Address?</span>
                                                <span class="radiatxtbox_ccrep">
                                                    <asp:RadioButton ID="rbtBillingAddressY" runat="server" GroupName="BillingAddress"
                                                        AutoPostBack="false" Checked="True"></asp:RadioButton>
                                                    YES</span> <span class="radiatxtbox_ccrep">
                                                        <asp:RadioButton ID="rbtBillingAddressN" runat="server" GroupName="BillingAddress"
                                                            AutoPostBack="false"></asp:RadioButton>
                                                        NO</span>
                                            </p>
                                        </div>
                                        <div id="DVAddress" runat="server" style="display: none; visibility: hidden;">
                                            <p class="middivrow_regcust">
                                                <span class="titletxt_regcust">Address<sup>*</sup></span> <span class="inputfldnowidth_default">
                                                    <asp:TextBox ID="txtAddress1" runat="server" CssClass="inputfield_ccrep" Width="350px"></asp:TextBox>
                                                </span>
                                            </p>
                                            <p class="middivrow_regcust">
                                                <span class="titletxt_regcust">Suite, Apt, etc.</span> <span class="inputfldnowidth_default">
                                                    <asp:TextBox ID="txtAddress2" runat="server" CssClass="inputfield_ccrep" Width="350px"></asp:TextBox>
                                                </span>
                                            </p>
                                            <p class="middivrow_regcust">
                                                <span class="titletxt_regcust">Country<sup>*</sup></span> <span class="inputfldnowidth_default">
                                                    <asp:DropDownList ID="ddlCountry" runat="server" CssClass="inputfield_ccrep ddl-states"
                                                        Width="150px">
                                                    </asp:DropDownList>
                                                </span>
                                            </p>
                                            <p class="middivrow_regcust">
                                                <span class="titletxt_regcust">State<sup>*</sup></span> <span class="inputfldnowidth_default">
                                                    <asp:DropDownList ID="ddlState" runat="server" CssClass="inputfield_ccrep ddl-states"
                                                        Width="150px">
                                                        <asp:ListItem Text="Select State"></asp:ListItem>
                                                        <asp:ListItem Text="Alabama"></asp:ListItem>
                                                        <asp:ListItem Text="California"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </span>
                                            </p>
                                            <p class="middivrow_regcust">
                                                <span class="titletxt_regcust">City<sup>*</sup></span> <span class="inputfldnowidth_default">
                                                    <asp:TextBox ID="txtCity" runat="server" CssClass="inputfield_ccrep auto-Search"
                                                        Width="100px"></asp:TextBox>
                                                </span>
                                            </p>
                                            <p class="middivrow_regcust">
                                                <span class="titletxt_regcust">Zip Code<sup>*</sup></span> <span class="inputfldnowidth_default">
                                                    <asp:TextBox ID="txtZip" runat="server" CssClass="inputfield_ccrep" Width="100px"></asp:TextBox>
                                                </span>
                                            </p>
                                            <p class="middivrow_regcust">
                                                <span class="titletxt_regcust">Phone<sup>*</sup></span><span class="inputfldnowidth_default">
                                                    <asp:TextBox ID="txtHPhone" runat="server" CssClass="inputfield_ccrep mask-phone"
                                                        Width="140px"></asp:TextBox>
                                                </span>
                                            </p>
                                        </div>
                                    </div>
                                    <div id="bycheque" runat="server" style="display: none;">
                                        <p class="fline_regcust">
                                            <img src="../../Images/CCRep/specer.gif" width="1px" height="1px" /></p>
                                        <p class="middivrow_regcust">
                                            <span class="titletxt_regcust">Bank Name:</span> <span class="inputconleft_regcust">
                                                <asp:TextBox ID="txtBankName" runat="server" CssClass="inputfield_ccrep" Width="130px"></asp:TextBox>
                                            </span><span class="titletxt_regcust">A/C Holder:</span> <span class="inputconright_regcust">
                                                <asp:TextBox ID="txtAccHolderName" runat="server" CssClass="inputfield_ccrep" Width="120px"></asp:TextBox>
                                            </span>
                                        </p>
                                        <p class="middivrow_regcust">
                                            <span class="titletxt_regcust">Type of Account:</span> <span class="inputconleft_regcust">
                                                <asp:DropDownList runat="server" ID="ddlaccounttype" Width="135px" CssClass="inputf_def">
                                                </asp:DropDownList>
                                            </span><span class="titletxt_regcust">Account No:</span> <span class="inputconright_regcust">
                                                <asp:TextBox ID="txtAccountNum" runat="server" CssClass="inputfield_ccrep" Width="120px"></asp:TextBox>
                                            </span>
                                        </p>
                                        <p class="middivrow_regcust">
                                            <span class="titletxt_regcust">Routing No:</span> <span class="inputconleft_regcust">
                                                <asp:TextBox ID="txtRoutingNum" runat="server" CssClass="inputfield_ccrep" Width="130px"
                                                    MaxLength="4"></asp:TextBox>
                                            </span><span class="titletxt_regcust">Check No:<span class="reqiredmark"><sup>*</sup></span></span>
                                            <span class="inputconright_regcust">
                                                <asp:TextBox ID="txtChequeNum" runat="server" CssClass="inputfield_ccrep" Width="120px"
                                                    MaxLength="20"></asp:TextBox>
                                            </span>
                                        </p>
                                    </div>
                                </div>
                                <div id="divTotalFree" runat="server" style="display: none; visibility: hidden;">
                                    <p class="middivrow_regcust">
                                        <span style="float: left">
                                            <img src="/App/Images/error-icon.gif" /></span> <span style="float: left">&nbsp;As you
                                                have given 100% discount source code, no billing information is required from your
                                                side. Please click on Submit button to get confirmation receipt.</span>
                                    </p>
                                </div>
                                <p class="middivrow_regcust" id="pDecision" runat="server" visible="false">
                                    <span style="font-weight: bold; padding-right: 5px; color: Red;">Payment Status:
                                    </span><span id="spnDecision" runat="server" style="color: Red;"></span>
                                </p>
                                <p class="middivrow_regcust" id="pReasonCode" runat="server" visible="false">
                                    <span style="font-weight: bold; padding-right: 5px; color: Red;">Reason: </span>
                                    <span id="spnReasonCode" runat="server" style="color: Red;"></span>
                                </p>
                                <p class="middivrow_regcust" id="pRequestID" runat="server" visible="false">
                                    <span style="font-weight: bold; padding-right: 5px; color: Red;">Payment Gateway Request
                                        ID: </span><span id="spnRequestID" runat="server" style="color: Red;"></span>
                                </p>
                                <p class="buttoncell_ccrep">
                                    <span class="buttoncon_ccrep">
                                        <asp:ImageButton ID="imgBack" runat="server" ImageUrl="../../Images/back-buton.gif"
                                            OnClick="imgBack_Click" /></span> <span class="buttoncon_ccrep" style="visibility: hidden;
                                                display: none;" id="spnIndicator">
                                                <img src="../../Images/indicator.gif" />
                                            </span><span class="buttoncon_ccrep" id="spansave">
                                                <asp:ImageButton ID="imgSave" runat="server" ImageUrl="../../Images/submit-button.gif"
                                                    OnClientClick="return Validation()" OnClick="imgSave_Click" /></span>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="insurance-eligibility-div-dialog">
    </div>
    <script type="text/javascript">
        function calculateAmount() { //debugger;
            var value = '<%= TotalAmount.HasValue ? TotalAmount.Value : 0 %>';
            if (isNaN(value))
                value = 0;
            else
                value = value - insuranceAmount + copayamount;
            
            $("#<%= hfNetPayableAmount.ClientID %>").val(parseFloat(value).toFixed(2));
            $('.total-amount-span').html(parseFloat(value).toFixed(2));
        }
    </script>
    <script type="text/javascript">
        var insuranceAmount = 0;
        var copayamount = 0;
        function calculateInsuranceAmount() {
            //debugger;
            insuranceAmount = (parseFloat(formatAmount($("#<%= InsuranceAmountHiddenField.ClientID%>").val())));
            copayamount = (parseFloat(formatAmount($("#<%= CoPayAmountHiddenField.ClientID%>").val())));
            
            var value = '<%= TotalAmount.HasValue ? TotalAmount.Value : 0 %>';
            
            if (insuranceAmount > 0) {
                if (isNaN(value))
                    value = 0;

                if (value <= insuranceAmount) {
                    insuranceAmount = value;
                    
                    $("#<%= InsuranceAmountHiddenField.ClientID%>").val(insuranceAmount);
                    
                    $('#<%=divPaymentDetails.ClientID %>').hide();
                    $('.payby-gc').hide();
                }
                else {
                    $('#<%=divPaymentDetails.ClientID %>').show();
                    $('.payby-gc').show();
                }
            }
            else {
                $('#<%=divPaymentDetails.ClientID %>').show();
                $('.payby-gc').show();
            }
            calculateAmount();
        }
        
        function insurancePaymentMode(hasInsurance) {
            //debugger;
            if (hasInsurance) {
                $("#insurance-eligibility-div-dialog").dialog("open");
                checkEligibility();
            } else {
                $("#<%= EligibilityIdHiddenField.ClientID%>").val(0);
                $("#<%= ChargeCardIdHiddenField.ClientID%>").val(0);
                $("#<%= InsuranceAmountHiddenField.ClientID%>").val(0);
                $("#<%= CoPayAmountHiddenField.ClientID%>").val(0);
                $(".insurance-payment-detail").hide();
                calculateInsuranceAmount();
            }
        }
        
        function setCardDetails(cardDetails) {
            //debugger;
            $("#<%= txtCName.ClientID%>").val(cardDetails.NameOnCard);

            var expiryDate = "";
            if (cardDetails.ExpirationDate != null) {
                var parts = cardDetails.ExpirationDate.split("/");
                if (parts[0].length == 1)
                    expiryDate = "0" + cardDetails.ExpirationDate;
                else 
                    expiryDate = cardDetails.ExpirationDate;
            }
            $("#<%= txtExpirationDate.ClientID%>").val(expiryDate);

            $("#<%= txtCCNo.ClientID%>").val(cardDetails.Number);
            $("#<%= txtSequrityNo.ClientID%>").val(cardDetails.CVV);
            $("#<%= ddlCCType.ClientID%> option[value=" + cardDetails.TypeId + "]").attr("selected", true);
        }
        
        function saveEligibilityInfo(eligibilityId, chargeCardId, cardDetails) {
            //debugger;
            $("#<%= EligibilityIdHiddenField.ClientID%>").val(eligibilityId);
            $("#<%= ChargeCardIdHiddenField.ClientID%>").val(chargeCardId);
            if (eligibilityId > 0 && chargeCardId > 0) {
                setCardDetails(cardDetails);
            }
        }

        function getEligibilityDetail() {
            //debugger;
            var addOntestIds = new Array();
            if (selectedAddOnTests != null && selectedAddOnTests.length > 0)
            {
                $.each(selectedAddOnTests, function() {
                    addOntestIds.push(this.Id);
                });
            }
            
            var parameter = "{'eligibilityId':'" + $("#<%= EligibilityIdHiddenField.ClientID%>").val() + "'"; 
            parameter += ",'eventId':'" + <%= EventId.HasValue?EventId.Value:0 %> + "'";
            parameter += ",'packageId':'" + <%= PackageId.HasValue?PackageId.Value:0 %> + "'"; 
            parameter += ",'addOnTestIds':" + JSON.stringify(addOntestIds) + "}";  
            
            $.ajax({
                url: '/Scheduling/Insurance/GetInsuranceDetail',
                type: 'Post',
                cache: false,
                contentType: "application/json; charset=utf-8",
                dataType: 'json',
                data: parameter,
                success: function(result) {
                    //debugger;
                    $("#<%= InsuranceAmountHiddenField.ClientID%>").val(result.AmountCovered);
                    $("#<%= CoPayAmountHiddenField.ClientID%>").val(result.CoPayAmount);
                    
                    $("#insurance-amount").html("$ " + result.AmountCovered.toFixed(2));
                    $("#copay-amount").html("$ " + result.CoPayAmount.toFixed(2));
                    
                    $(".insurance-payment-detail").show();
                    
                    calculateInsuranceAmount();
                },
                error: function(arg1, arg2) {

                }
            });
        }
        
        function onCloseEligibilityDialog() {
            //debugger;
            var eligibilityId = parseInt($("#<%= EligibilityIdHiddenField.ClientID%>").val());
            var chargeCardId = parseInt($("#<%= ChargeCardIdHiddenField.ClientID%>").val());
            
            if (eligibilityId <= 0 || chargeCardId <= 0) {
                $("#EligibilityNoRadioButton").attr("checked", true);
                $("#EligibilityYesRadioButton").attr("checked", false);
                insurancePaymentMode(false);
            } else {
                $("#EligibilityNoRadioButton").attr("checked", false);
                $("#EligibilityYesRadioButton").attr("checked", true);
                getEligibilityDetail();
            }
            
            if ($("#insurance-eligibility-div-dialog").dialog("isOpen") == true) {
                $("#insurance-eligibility-div-dialog").dialog("close");
            }
        }
        
        function closeEligibilityDialog() {
            if ($("#insurance-eligibility-div-dialog").dialog("isOpen") == true) {
                $("#insurance-eligibility-div-dialog").dialog("close");
            }
        }
        
        function checkEligibility() {
            $("#insurance-eligibility-div-dialog").html("<div style='width:90%; margin: 10px auto; text-align: center; padding: 30px 0px;'> <img src='/App/Images/loading.gif' alt=''> Loading.... </div>");
            
            $.ajax({
                url: '/Scheduling/Insurance/Edit',
                type: 'Post',
                cache: false,
                contentType: "application/json; charset=utf-8",
                dataType: 'html',
                data: "{}",
                success: function(result) {
                    $("#insurance-eligibility-div-dialog").html(result);
                    setSuccessandCloseMethod(saveEligibilityInfo, closeEligibilityDialog);
                },
                error: function(arg1, arg2) {

                }
            });
        }

    </script>
    <script type="text/javascript" language="javascript">
        var states;
        $(document).ready(function() {

            states = <%= GetStates() %> ;
            BindSateDropDown(states);
            $('#<%=ddlCountry.ClientID %>').bind("change", function() { BindSateDropDown(states); });

            $('.auto-Search').autoComplete({
                autoChange: true,
                url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetCityByContextKeyAndPrefixText")%>',
                type: "POST",
                data: "prefixText",
                contextKey: $('#<%=ddlState.ClientID %>').val()
            });

            $('.ddl-states').change(function()
            {
                $('.auto-Search').autoComplete({
                    autoChange: true,
                    url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetCityByContextKeyAndPrefixText")%>',
                    type: "POST",
                    data: "prefixText",
                    contextKey: $('.ddl-states option:selected').val()
                });
                SetState();
            });
            $('.mask-phone').mask('(999)-999-9999');
            
            $("#insurance-eligibility-div-dialog").dialog({ width: 650, autoOpen: false, title: 'Check Eligibility', modal: true, resizable: false, draggable: true });
            $("#insurance-eligibility-div-dialog").bind('dialogclose', function() { onCloseEligibilityDialog(); });
            
            if ('<%=IsTestCoveredByInsurance %>' == '<%=Boolean.FalseString %>') {
                $("#InsurancePaymentModeDiv").hide();
            } else {
                $("#InsurancePaymentModeDiv").show();
                onCloseEligibilityDialog();
            }
        });

    </script>
    <script type="text/javascript" language="javascript">

        function BindSateDropDown(stateList) {//debugger;
            $('#' + '<%=ddlState.ClientID %> >option').remove();

            if (stateList.length > 0) {
                $('#' + '<%=ddlState.ClientID %>').append($('<option></option>').val('0').html('Select State'));
                for (var i = 0; i < stateList.length; i++) {
                    if (stateList[i].CountryId == $('#' + '<%=ddlCountry.ClientID %>').val())
                        $('#' + '<%=ddlState.ClientID %>').append($('<option></option>').val(stateList[i].Id).html(stateList[i].Name));
                }
            }
            else {
                $('#' + '<%=ddlState.ClientID %>').append($('<option></option>').val('0').html('No State Found'));
            }
            if ($('#<%=hfstate.ClientID %>').val() != '') {
                $("#<%= ddlState.ClientID %> option:contains('" + $('#<%=hfstate.ClientID %>').val() + "')").first().attr('selected', true);
            }
        }

        function SetState() {
            $('#<%=hfstate.ClientID %>').val($('#<%=ddlState.ClientID %> option:selected').text());
        }
    
    </script>
    <asp:HiddenField ID="hfstate" runat="server" />
    <asp:HiddenField ID="hfEventID" runat="server" />
    <asp:HiddenField ID="hfTotalAmount" runat="server" />
    <asp:HiddenField ID="hfNetPayableAmount" runat="server" />
    <asp:HiddenField ID="hfPaymentMode" runat="server" />
    <asp:HiddenField ID="hfBillingAdd" runat="server" Value="1" />
</asp:Content>
