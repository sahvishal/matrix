<%@ Page Language="C#" MasterPageFile="~/App/CallCenter/NewCallCenterMaster.master"
    AutoEventWireup="true" Inherits="Falcon.App.UI.App.CallCenter.CallCenterRep.RequestReport.SendReportStep3"
    CodeBehind="SendReportStep3.aspx.cs" EnableEventValidation="false" %>

<%@ Import Namespace="Falcon.App.Core.Finance.Enum" %>
<%@ Register TagPrefix="uc" Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc:JQueryToolkit ID="_jQueryToolkit" runat="server" IncludeAjax="true" IncludeJQueryUI="true"
        IncudeJQueryAutoComplete="true" IncludeJQueryMaskInput="true" />
    
    <script type="text/javascript" src="/App/JavascriptFiles/HttpRequest.js"></script>
   
    <script language="javascript" type="text/javascript">

        function formatAmount(num) {
            if (isNaN(parseFloat(num))) {
                num = '0.00';
            }
            return parseFloat(num);
            try {
                num = num.replace(/^\s+|\s+$/g, "");
            }
            catch (err) {
                num = num;
            }

            num = parseFloat(num);
            if (isNaN(num)) {
                num = '0.00';
            }

            return parseFloat(num.toFixed(2));
        }

        function CheckBillingAddress() {
            var DVAddress = document.getElementById('<%= this.DVAddress.ClientID %>');
            var rbtBillingAddressY = document.getElementById('<%= this.rbtBillingAddressY.ClientID %>');
            if (rbtBillingAddressY.checked) {
                DVAddress.style.display = "none";
                DVAddress.style.visibility = "hidden";
            }
            else {
                DVAddress.style.display = "block";
                DVAddress.style.visibility = "visible";
            }
            return true;
        }

        function OnsitePayment() {
            // debugger
            var ddlPayMode = document.getElementById("<%= this.ddlPayMode.ClientID %>");
            var ddlCCType = document.getElementById("<%= this.ddlCCType.ClientID %>");
            var txtCCNo = document.getElementById("<%= this.txtCCNo.ClientID %>");
            var txtSequrityNo = document.getElementById("<%= this.txtSequrityNo.ClientID %>");
            var txtExpirationDate = document.getElementById("<%= this.txtExpirationDate.ClientID %>");
            var chkOnsitePayment = document.getElementById("<%= this.chkOnsitePayment.ClientID %>");
            var bolOnSitePayment = chkOnsitePayment.checked;
            ddlCCType.disabled = bolOnSitePayment;
            txtCCNo.disabled = bolOnSitePayment;
            txtSequrityNo.disabled = bolOnSitePayment;
            txtExpirationDate.disabled = bolOnSitePayment;
            var dvPaymode = document.getElementById("dvPaymode");
            if (bolOnSitePayment == true) {
                dvPaymode.style.display = 'none';                
                $('#<%= PaymentModeSpan.ClientID %>').hide();
            }
            else {
                dvPaymode.style.display = '';
                $('#<%= PaymentModeSpan.ClientID %>').show();
            }

        }
        function Validation() {
            //debugger;
            var ddlCCType = document.getElementById("<%= ddlCCType.ClientID %>");
            var txtCCNo = document.getElementById("<%= txtCCNo.ClientID %>");
            var txtExpirationDate = document.getElementById("<%= txtExpirationDate.ClientID %>");
            var txtSequrityNo = document.getElementById("<%= txtSequrityNo.ClientID %>");
            var txtCName = document.getElementById("<%= txtCName.ClientID %>");
            var rbtBillingAddressY = document.getElementById("<%= rbtBillingAddressY.ClientID %>");
            var chkOnsitePayment = document.getElementById("<%= chkOnsitePayment.ClientID %>");
            var dvTotalAmount = document.getElementById("<%=dvTotalAmount.ClientID %>");
            var ddlPayMode = document.getElementById("<%=ddlPayMode.ClientID %>");

            if ((dvTotalAmount.innerHTML != '0.00') && (chkOnsitePayment.checked != true)) {

                if (ddlPayMode.options[ddlPayMode.selectedIndex].value == '<%= PaymentType.CreditCard.PersistenceLayerId %>') {
                    if (isBlank(txtCName, "Name on Card") || (checkDropDown(ddlCCType, "Credit Card Type") == false))
                        return false;

                    if (isBlank(txtCCNo, "Credit Card Number"))
                        return false;
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

            if (rbtBillingAddressY.checked != true) {
                var txtAddress1 = document.getElementById("<%= this.txtAddress1.ClientID %>");
                var txtCity = document.getElementById("<%= this.txtCity.ClientID %>");
                var ddlState = document.getElementById("<%= this.ddlState.ClientID %>");
                var txtZip = document.getElementById("<%= this.txtZip.ClientID %>");

                if (isBlank(txtAddress1, "Address")) { return false; }
                if (checkLength(txtAddress1, 500, "Address")) { return false; }
                if (checkDropDown(ddlState, "State for  Address") == false) { return false; }
                if (isBlank(txtCity, "City for  Address")) { return false; }
                if (isBlank(txtZip, "Zip")) { return false; }

            }

            var spBtn = document.getElementById("spBtn");
            var spIdicator = document.getElementById("spIdicator");
            spBtn.style.display = "none";
            spIdicator.style.display = "block";
            return true;
        }

        function CheckDecimal(evt) {
            return KeyPress_DecimalAllowedOnly(evt);
        }

        function CallEnd() {
            postRequest.url = "ExistingCustomerCall.aspx?CallEnd=True";
            postRequest.post("");
            window.location = "/../../CallCenter/CallCenterRepDashboard/Index";
        }

        function MailReport() {
            //debugger 
            var dvTotalAmount = document.getElementById("<%= dvTotalAmount.ClientID %>");
            var spPrintedReportCost = document.getElementById("<%= spPrintedReportCost.ClientID %>");
            var dvTotalBill = document.getElementById("<%= dvTotalBill.ClientID %>");

            dvTotalAmount.innerHTML = (parseFloat(formatAmount(spPrintedReportCost.innerHTML))).toFixed(2);
            dvTotalBill.innerHTML = (parseFloat(dvTotalAmount.innerHTML)).toFixed(2);
            var hfTotalAmount = document.getElementById("<%= hfTotalAmount.ClientID %>");
            hfTotalAmount.value = dvTotalBill.innerHTML;

        }

        function txtkeypress(evt) {
            return KeyPress_NumericAllowedOnly(evt);
        }
    </script>

    <script type="text/javascript" language="javascript">

        function ShowHide() {//debugger
            var ddlPayMode = document.getElementById("<%=ddlPayMode.ClientID %>");
            var temp = false;
            var bycreditcard = document.getElementById("bycreditcard");
            var bycheque = document.getElementById("bycheque");
            var bycconfile = document.getElementById('byCreditCardOld');

            var hfPaymentMode = document.getElementById("<%=hfPaymentMode.ClientID %>");
            hfPaymentMode.value = ddlPayMode.options[ddlPayMode.selectedIndex].value;

            if (ddlPayMode.options[ddlPayMode.selectedIndex].value == '<%= PaymentType.CreditCard.PersistenceLayerId %>') {
                bycreditcard.style.display = "block";
                bycheque.style.display = "none";
                bycconfile.style.display = "none";
            }
            else if (ddlPayMode.options[ddlPayMode.selectedIndex].value == '<%= PaymentType.Check.PersistenceLayerId %>') {
                bycreditcard.style.display = "none";
                bycheque.style.display = "block";
                bycconfile.style.display = "none";

            }
            else if (ddlPayMode.options[ddlPayMode.selectedIndex].value == '<%= PaymentType.Cash.PersistenceLayerId %>') {
                bycreditcard.style.display = "none";
                bycheque.style.display = "none";
                bycconfile.style.display = "none";
            }
            else if (ddlPayMode.options[ddlPayMode.selectedIndex].value == "<%= PaymentType.Onsite_Value %>") {
                bycreditcard.style.display = "none";
                bycheque.style.display = "none";
                bycconfile.style.display = "none";
            }
            else if (ddlPayMode.options[ddlPayMode.selectedIndex].value == "<%= PaymentType.CreditCardOnFile_Value %>") {
                bycreditcard.style.display = "none";
                bycheque.style.display = "none";
                bycconfile.style.display = "block";
            }
        }

        function SetValuesafterFailedPostBack() {//debugger            

            var bycreditcard = document.getElementById("bycreditcard");
            var bycheque = document.getElementById("bycheque");
            var bycconfile = document.getElementById('byCreditCardOld');

            var hfPaymentMode = document.getElementById("<%=hfPaymentMode.ClientID %>");

            if (hfPaymentMode.value == '<%= PaymentType.CreditCard.PersistenceLayerId %>') {
                bycreditcard.style.display = "block";
                bycheque.style.display = "none";
                bycconfile.style.display = "none";
                CheckBillingAddress();
            }
            else if (hfPaymentMode.value == '<%= PaymentType.Check.PersistenceLayerId %>') {
                bycreditcard.style.display = "none";
                bycheque.style.display = "block";
                bycconfile.style.display = "none";

            }
            else if (hfPaymentMode.value == '<%= PaymentType.Cash.PersistenceLayerId %>') {
                bycreditcard.style.display = "none";
                bycheque.style.display = "none";
                bycconfile.style.display = "none";
            }
            else if (hfPaymentMode.value == '<%= PaymentType.CreditCardOnFile_Value %>') {
                bycreditcard.style.display = "none";
                bycheque.style.display = "none";
                bycconfile.style.display = "block";
            }
        }

        $(document).ready(function() { $("form :input").attr("autocomplete", "off"); });
    </script>
    <asp:HiddenField ID="hfPaymentMode" runat="server" />
    <div class="mainbody_outer">
        <div class="mainbody_inner">
            <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p>
                        <img src="/App/Images/specer.gif" width="750px" height="5px" /></p>
                    <span class="headingright_default"></span>
                </div>
                <p>
                    <img src="/App/Images/specer.gif" width="750px" height="2px" /></p>
            </div>
            <div class="maindivredmsgbox" runat="server" id="divError" visible="false">
            </div>
            <div class="main_area_bdr">
                <div class="maincontentrow_ccrep">
                    <div class="regcust_innercon">
                        <span>
                            <img src="/App/Images/CCRep/specer.gif" width="740px" height="5px" /></span>
                        <div class="regcust_innerrow">
                            <%--<div class="pgnosymbol_regcust">
                                <img src="../../../Images/CCRep/page4symbol.gif" />
                            </div>--%>
                            <div class="middivrow_regcust">
                                <p class="orngheadtxt_regcust">
                                    Payment</p>
                                <p class="fline_regcust">
                                    <img src="/App/Images/CCRep/specer.gif" width="1px" height="1px" /></p>
                                <p class="normaltxt_regcust">
                                    Your Total Billing amout is <strong>$<span runat="server" id="dvTotalAmount">0.00</span></strong>.
                                </p>
                                <div class="flinerowbg_ccrep" id="divScreening" runat="server" style="visibility: hidden;
                                    display: none">
                                    <p class="contentrow_pw">
                                        <span class="titletextbluebold_ccrep">&nbsp;your screening report to be sent via email
                                            for only $<span id="spPrintedReportCost" runat="server"></span></span>
                                    </p>
                                </div>
                                <div>
                                    <span>
                                        <img src="/App/Images/CCRep/specer.gif" width="530px" height="2px" /></span>
                                </div>
                                <div class="dgselectpackage_ccrep">
                                    <table class="gridbillinfo" cellspacing="0" border="0" id="dgBill" style="border-collapse: collapse;">
                                        <tr class="row1" style="display: block; width:500px;">
                                            <td style="width: 300px">
                                                Name/Description
                                            </td>
                                            <td style="width: 60px">
                                                Quantity
                                            </td>
                                            <td style="width: 51px">
                                                Amount
                                            </td>
                                        </tr>
                                        <tr class="row2" id="dvSelectedProduct" runat="server" style="display: none; width:500px;">
                                            <td id="dvSelectedProductDesc" runat="server" style="width: 300px">
                                                Package XXX
                                            </td>
                                            <td style="width: 60px">
                                                01
                                            </td>
                                            <td id="dvSelectedProductAmt" runat="server" style="width: 51px">
                                                $0.00
                                            </td>
                                        </tr>
                                        <tr class="row2" id="dvReportEmail" runat="server" style="display: none; width:500px;">
                                            <td id="dvReportEmailDesc" runat="server" style="width: 300px; height: 24px;">
                                                &nbsp;
                                            </td>
                                            <td style="width: 60px; height: 24px;">
                                                01
                                            </td>
                                            <td id="dvReportEmailAmt" runat="server" style="width: 51px; height: 24px;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr class="row2" id="dvCoupon" style="display: none">
                                            <td id="dvCouponDesc" style="width: 300px">
                                                &nbsp;
                                            </td>
                                            <td style="width: 60px">
                                                01
                                            </td>
                                            <td id="dvCouponAmt" runat="server" style="width: 51px">
                                            </td>
                                        </tr>
                                        <tr class="footer" style="width:500px; display:block;">
                                            <td style="width: 300px">
                                                Total
                                            </td>
                                            <td style="width: 60px">
                                            </td>
                                            <td id="dvTotalBill" runat="server" style="width: 51px">
                                                $00.00
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <span>
                                    <img src="/App/Images/CCRep/specer.gif" width="530px" height="10px" /></span>
                                <div id="DivPaymentDetail" runat="server">
                                    <p class="subheadingbg_ccrep">
                                        <span style="float: left;">Payment Details</span> <span style="float: left; padding-left: 15px;
                                            font-weight: normal;" id="OnSitePaymentSpan" runat="server">
                                            <asp:CheckBox ID="chkOnsitePayment" Text="Onsite Payment" runat="server" AutoPostBack="false"
                                                CssClass="" Checked="false"></asp:CheckBox>
                                        </span><span style="float: right;" id="PaymentModeSpan" runat="server"><span class="titletxt_regcust"
                                            style="width: 100px; font-weight: normal">Payment Mode<span class="reqiredmark"><sup>*</sup></span>:</span>
                                            <span class="inputconright_regcust">
                                                <asp:DropDownList runat="server" ID="ddlPayMode" Width="140px" CssClass="inputfield_ccrep">
                                                </asp:DropDownList>
                                            </span></span>
                                    </p>
                                    <div id="dvPaymode">
                                        <div id="bycreditcard">
                                            <div class="middivrow_regcust">
                                                <span class="titletxt_regcust">Name on Card<span class="reqiredmark"><sup>*</sup></span>:</span>
                                                <span class="inputconleft_regcust">
                                                    <asp:TextBox ID="txtCName" runat="server" CssClass="inputfield_ccrep" Width="130px"
                                                        MaxLength="30"></asp:TextBox>
                                                </span>
                                            </div>
                                            <p class="middivrow_regcust">
                                                <span class="titletxt_regcust">Credit Card No<span class="reqiredmark"><sup>*</sup></span>:</span>
                                                <span class="inputconleft_regcust">
                                                    <asp:TextBox ID="txtCCNo" runat="server" CssClass="inputfield_ccrep" Width="130px"
                                                        MaxLength="16"></asp:TextBox>
                                                </span><span class="titletxt_regcust">Credit Card Type<span class="reqiredmark"><sup>*</sup></span>:</span>
                                                <span class="inputconright_regcust">
                                                    <asp:DropDownList runat="server" ID="ddlCCType" Width="130px" CssClass="inputfield_ccrep">
                                                    </asp:DropDownList>
                                                </span>
                                            </p>
                                            <p class="middivrow_regcust">
                                                <span class="titletxt_regcust">Expiration Date<span class="reqiredmark"><sup>*</sup></span>:</span>
                                                <span class="inputconleft_regcust" style="font-size: 9px; color: #000;">
                                                    <asp:TextBox ID="txtExpirationDate" runat="server" CssClass="inputfield_ccrep mask-date" Width="85px"
                                                        MaxLength="7"></asp:TextBox>&nbsp;MM/YYYY </span><span class="titletxt_regcust">Security
                                                            No<span class="reqiredmark"><sup>*</sup></span>:</span> <span class="inputconright_regcust">
                                                                <asp:TextBox ID="txtSequrityNo" runat="server" CssClass="inputfield_ccrep" Width="80px"
                                                                    MaxLength="4" TextMode="Password"></asp:TextBox>
                                                            </span>
                                            </p>
                                        </div>
                                        <div id="bycheque" style="display: none;">
                                            <p class="fline_regcust">
                                                <img src="/App/Images/CCRep/specer.gif" width="1px" height="1px" /></p>
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
                                        <div id="byCreditCardOld" style="display: none;">                    
                                            <p style="float:left; width:98%; margin-bottom:10px;">
                                                <span class="titletxt_popup_pd" style="width:100px;"><b>Credit Card Type:</b></span> 
                                                <span runat="server" id="spcctype" class="inputconleft_popup_pd" style="width:130px;" ></span>
                                                <span class="titletxt_popup_pd" style="width:100px;"><b>Credit Card No:</b></span> 
                                                <span runat="server" id="spccnumber" class="inputconright_popup_pd"></span>
                                            </p>
                                            <p style="float:left; width:98%; margin-bottom:10px;">
                                                <span class="titletxt_popup_pd" style="width:100px;"><b>Expiration Date:</b></span> 
                                                <span runat="server" id="spexpdate" class="inputconleft_popup_pd"></span>
                                            </p>
                                            <p style="float:left; width:98%; margin-bottom:10px;">
                                                <span class="titletxt_popup_pd" style="width:100px;"><b>Card Holder:</b></span> 
                                                <span runat="server" id="spcardholder" class="inputconright_popup_pd"></span>
                                            </p>
                                        </div>  
                                    </div>
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
                                            <span class="titletxt_regcust">Address1<span class="reqiredmark"><sup>*</sup></span>:</span>
                                            <span class="inputfldnowidth_default">
                                                <asp:TextBox ID="txtAddress1" runat="server" CssClass="inputfield_ccrep" Width="350px"></asp:TextBox></span>
                                        </p>
                                        <p class="middivrow_regcust">
                                            <span class="titletxt_regcust">Suite, Apt, etc.</span> <span class="inputfldnowidth_default">
                                                <asp:TextBox ID="txtAddress2" runat="server" CssClass="inputfield_ccrep" Width="350px"></asp:TextBox></span>
                                        </p>
                                        <p class="middivrow_regcust">
                                            <span class="titletxt_regcust">Country<sup>*</sup></span> <span class="inputfldnowidth_default">
                                                <asp:DropDownList ID="ddlCountry" runat="server" CssClass="inputfield_ccrep ddl-states"
                                                    Width="150px">
                                                </asp:DropDownList>
                                            </span>
                                        </p>
                                        <p class="middivrow_regcust">
                                            <span class="titletxt_regcust">State<span class="reqiredmark"><sup>*</sup></span>:</span>
                                            <span class="inputfldnowidth_default">
                                                <asp:DropDownList runat="server" ID="ddlState" Width="130px" CssClass="inputfield_ccrep ddl-states">
                                                </asp:DropDownList>
                                            </span>
                                        </p>
                                        <p class="middivrow_regcust">
                                            <span class="titletxt_regcust">City<span class="reqiredmark"><sup>*</sup></span>:</span>
                                            <span class="inputfldnowidth_default">
                                                <asp:TextBox ID="txtCity" runat="server" CssClass="inputfield_ccrep auto-Search"
                                                    Width="100px"></asp:TextBox></span>
                                        </p>
                                        <p class="middivrow_regcust">
                                            <span class="titletxt_regcust">Zip<span class="reqiredmark"><sup>*</sup></span>:</span>
                                            <span class="inputfldnowidth_default">
                                                <asp:TextBox ID="txtZip" runat="server" CssClass="inputfield_ccrep" Width="100px"></asp:TextBox></span>
                                        </p>
                                        <p class="middivrow_regcust">
                                            <span class="titletxt_regcust">Phone(Home)<span class="reqiredmark"><sup>*</sup></span>:</span>
                                            <span class="inputfldnowidth_default">
                                                <asp:TextBox ID="txtHPhone" runat="server" CssClass="inputfield_ccrep mask-phone"
                                                    Width="110px"></asp:TextBox></span>
                                        </p>
                                        <p class="fline_regcust">
                                            <img src="/App/Images/CCRep/specer.gif" width="1px" height="1px" /></p>
                                    </div>
                                </div>
                                <div style="display: none;">
                                    <p class="middivrow_regcust">
                                        <span class="graysubheadtxt_regcust">Customer Agreement</span>
                                    </p>
                                    <p class="middivrow_regcust">
                                        <span class="chkbox_accr">
                                            <asp:CheckBox ID="CheckBox1" Checked="true" runat="server" /></span> <span class="titletxtgraynowidth_prr">
                                                I would like to recieve Special Offers.</span>
                                    </p>
                                    <p class="middivrow_regcust">
                                        <span class="chkbox_accr">
                                            <asp:CheckBox ID="CheckBox2" Checked="true" runat="server" /></span> <span class="titletxtgraynowidth_prr">
                                                I agree to the <a href="#">Term And Condition</a></span>
                                    </p>
                                    <p class="fline_regcust">
                                        <img src="/App/Images/CCRep/specer.gif" width="1px" height="1px" /></p>
                                </div>
                                <p class="buttoncellthree_ccrep">
                                    <span style="float: left;" id="spBtn"><span class="buttoncon_ccrep">
                                        <asp:ImageButton ID="imgBack" runat="server" ImageUrl="/App/Images/back-buton.gif"
                                            OnClick="imgBack_Click" />
                                    </span><span class="buttoncon_ccrep">
                                        <asp:ImageButton ID="imgCancel" runat="server" ImageUrl="/App/Images/cancel-button.gif"
                                            OnClick="imgCancel_Click" />
                                    </span><span class="buttoncon_ccrep">
                                        <asp:ImageButton ID="imgSave" runat="server" ImageUrl="/App/Images/submit-button.gif"
                                            OnClientClick="return Validation()" OnClick="imgSave_Click" />
                                    </span></span><span style="float: right; display: none;" id="spIdicator">
                                        <img src="/App/Images/indicator.gif" />
                                    </span>
                                </p>
                                <p>
                                    <img src="/App/Images/specer.gif" width="5px" height="25px" /></p>
                            </div>
                            <div class="rightdivrow_regcust" id="divCall" runat="server">
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
                                <div>
                                    <img src="/App/Images/specer.gif" height="5px" width="2px" /></div>
                                <div class="endcall_ccrep_dboard">
                                    <span class="endtbtn_ccrep_dboard">
                                        <asp:ImageButton ID="imgEndCall" runat="server" ImageUrl="~/App/Images/CCRep/endcallbtn.gif"
                                            OnClientClick=" closeScriptPopup(); CallNotes(); return false;" />
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript" language="javascript">
        var states;
    $(document).ready(function(){
    states = <%= GetStates() %> ;
            BindSateDropDown(states);
            $('#<%=ddlCountry.ClientID %>').bind("change", function() { BindSateDropDown(states); });

            $('#<%=ddlPayMode.ClientID %>').bind("change", function(){ShowHide();});
        
        $('.auto-Search').autoComplete({
		    autoChange: true,
		    url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetCityByContextKeyAndPrefixText")%>',
		    type: "POST",
		    data: "prefixText",
		    contextKey: $('.ddl-states option:selected').val()
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
        $('.mask-date').mask('99/9999');
        $('.mask-phone').mask('(999)-999-9999');
        
        checkAndOpenScriptPopup();
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
    <asp:HiddenField runat="server" ID="hfCallStartTime" />
    
    <script type="text/javascript" language="javascript">
        //// this will run after page is load
        var hfCallStartTime = document.getElementById("<%= this.hfCallStartTime.ClientID %>");
        StartTimer(hfCallStartTime);
        
    </script>
</asp:Content>
