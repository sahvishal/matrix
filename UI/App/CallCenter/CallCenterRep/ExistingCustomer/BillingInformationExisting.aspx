<%@ Page Language="C#" MasterPageFile="~/App/CallCenter/NewCallCenterMaster.master"
    AutoEventWireup="true" Inherits="Falcon.App.UI.App.CallCenter.CallCenterRep.ExistingCustomer.BillingInformation"
    CodeBehind="BillingInformationExisting.aspx.cs" EnableEventValidation="false" %>
<%@ Import Namespace="Falcon.App.Core.Finance.Enum" %>

<%@ Register Src="~/App/UCCommon/OrderSummary.ascx" TagName="OrderSummary" TagPrefix="SummaryControl" %>
<%@ Register TagPrefix="uc" Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" %>
<%@ Register Src="~/App/UCCommon/GiftCertificateApply.ascx" TagPrefix="uc" TagName="GCApply" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc:JQueryToolkit ID="_jQueryToolkit" runat="server" IncludeAjax="true" IncludeJQueryUI="true"
        IncudeJQueryAutoComplete="true" IncludeJQueryMaskInput="true" />
    <script language="javascript" type="text/javascript" src="/Scripts/jquery.unobtrusive-ajax.js"></script>
    
    <script type="text/javascript" language="javascript">
        $(function () {
            if ('<%=IsGiftCertificate %>' == 'True') {
                $('.gc-purchase').show();
                $('#SourceCodeApplyDiv').hide();
            }
            else {
                $('.gc-purchase').hide();
                $('#SourceCodeApplyDiv').show();
            }
        });
    </script>
    <script type="text/javascript">
        window.history.forward(1);
    </script>   
    <script type="text/javascript" src="/App/JavascriptFiles/HttpRequest.js"></script>    
    <script language="javascript" type="text/javascript">
        var postRequest = new HttpRequest();
        postRequest.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        postRequest.failureCallback = requestFailed();

        function requestFailed() {
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
        function CheckBillingAddress() {
            var DVAddress = document.getElementById('<%= this.DVAddress.ClientID %>');
            var rbtBillingAddressY = document.getElementById('<%= this.rbtBillingAddressY.ClientID %>');
            var hfBillingAddress = document.getElementById("<%=this.hfBillingAddress.ClientID %>");
            if (rbtBillingAddressY.checked) {
                DVAddress.style.display = "none";
                DVAddress.style.visibility = "hidden";
                hfBillingAddress.value = "1";
            }
            else {
                DVAddress.style.display = "block";
                DVAddress.style.visibility = "visible";
                hfBillingAddress.value = "0";
            }
            return true;
        }
        function OnsitePayment() {

            var ddlPayMode = document.getElementById("<%= ddlPayMode.ClientID %>");
            var ddlCCType = document.getElementById("<%= ddlCCType.ClientID %>");
            var txtCCNo = document.getElementById("<%= txtCCNo.ClientID %>");
            var txtSequrityNo = document.getElementById("<%= txtSequrityNo.ClientID %>");
            var txtExpirationDate = document.getElementById("<%= txtExpirationDate.ClientID %>");
            var chkOnsitePayment = document.getElementById("<%= chkOnsitePayment.ClientID %>");
            var bolOnSitePayment = chkOnsitePayment.checked;

            ddlCCType.disabled = bolOnSitePayment;
            txtCCNo.disabled = bolOnSitePayment;
            txtSequrityNo.disabled = bolOnSitePayment;
            txtExpirationDate.disabled = bolOnSitePayment;
            var dvPaymode = document.getElementById("dvPaymode");
            var hfOnsitePayment = document.getElementById("<%= hfOnsitePayment.ClientID %>");
            var divGiftCertificatepayment = document.getElementById("DivGiftCertificatepayment");
            if (bolOnSitePayment == true) {
                //CancelAppliedGC();
                dvPaymode.style.display = 'none';
                hfOnsitePayment.value = "1";
                //divGiftCertificatepayment.style.display = "none";
            }
            else {
                dvPaymode.style.display = '';
                hfOnsitePayment.value = "0";
                //divGiftCertificatepayment.style.display = "block";
            }
            ddlPayMode.disabled = bolOnSitePayment;
        }
        
        function Validation() {
            var ddlCCType = document.getElementById("<%= ddlCCType.ClientID %>");
            var txtCCNo = document.getElementById("<%= txtCCNo.ClientID %>");
            var txtExpirationDate = document.getElementById("<%= txtExpirationDate.ClientID %>");
            var txtSequrityNo = document.getElementById("<%= txtSequrityNo.ClientID %>");
            var txtCName = document.getElementById("<%= txtCName.ClientID %>");
            var rbtBillingAddressY = document.getElementById("<%= rbtBillingAddressY.ClientID %>");
            var chkOnsitePayment = document.getElementById("<%= chkOnsitePayment.ClientID %>");
            var dvTotalAmount = document.getElementById("<%= dvTotalAmount.ClientID %>");
            var hfTempTotalAmount = document.getElementById("<%= hfTempTotalAmount.ClientID %>");
            hfTempTotalAmount.value = dvTotalAmount.innerHTML;
            var ddlPayMode = document.getElementById("<%= ddlPayMode.ClientID %>");
            var paymentmode = ddlPayMode.options[ddlPayMode.selectedIndex].text;
            
            var isGiftCertificate = '<%=IsGiftCertificate %>';
            if (isGiftCertificate == "False")
                isGiftCertificate = false;
            else
                isGiftCertificate = true;
            if (hfTempTotalAmount.value != "0.00") {
                if (chkOnsitePayment == null || chkOnsitePayment.checked != true) {
                    /// skip the validation of CC and Echeck if all payment i smade through GC

                    if (isGiftCertificate || (!isGiftCertificate && (onlyGCApplied == null || onlyGCApplied == undefined || !onlyGCApplied(hfTempTotalAmount.value)))) {
                        if (paymentmode == "Credit Card") {
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
                        else if (paymentmode == "eCheck") {
                            var txtERoutingNo = document.getElementById("<%=this.txtERoutingNo.ClientID %>")
                            var txtEAccountNo = document.getElementById("<%=this.txtEAccountNo.ClientID %>");
                            var ddlEAccountType = document.getElementById("<%=this.ddlEAccountType.ClientID %>");
                            var txtECheckNo = document.getElementById("<%=this.txtECheckNo.ClientID %>");
                            var txtEBankName = document.getElementById("<%=this.txtEBankName.ClientID %>");
                            var txtEAccHolderName = document.getElementById("<%=this.txtEAccHolderName.ClientID %>");

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
                        }
                    }
                }
                if (rbtBillingAddressY.checked != true) {
                    var txtAddress1 = document.getElementById("<%= this.txtAddress1.ClientID %>");
                    var txtAddress2 = document.getElementById("<%= this.txtAddress2.ClientID %>");

                    var txtCity = document.getElementById("<%= this.txtCity.ClientID %>");
                    var ddlState = document.getElementById("<%= this.ddlState.ClientID %>");


                    var txtZip = document.getElementById("<%= this.txtZip.ClientID %>");
                    var txtHPhone = document.getElementById("<%= this.txtHPhone.ClientID %>");


                    if (isBlank(txtAddress1, "Address1")) { return false; }
                    if (checkLength(txtAddress1, 500, "Address1")) { return false; }
                    if (checkLength(txtAddress2, 500, "Address2")) { return false; }

                    if (checkDropDown(ddlState, "State for  Address") == false) { return false; }
                    if (isBlank(txtCity, "City for  Address")) { return false; }
                    if (isBlank(txtZip, "Zip")) { return false; }

                }
            }
            var imgSave = document.getElementById("<%=this.imgSave.ClientID %>");
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
            postRequest.url = "ExistingCustomerCall.aspx?CallEnd=True";
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
            CallExistingPCP();
        }
        function SetValuesafterFailedPostBack() {//debugger
            var dvPaymode = document.getElementById("dvPaymode");
            var hfOnsitePayment = document.getElementById("<%= hfOnsitePayment.ClientID %>");
            var DVAddress = document.getElementById('<%= DVAddress.ClientID %>');
            var hfBillingAddress = document.getElementById("<%= hfBillingAddress.ClientID %>");

            var ddlPayMode = document.getElementById("<%= ddlPayMode.ClientID %>");
            var byCreditCard = document.getElementById("byCreditCard");
            var byECheck = document.getElementById("byECheck");

            if (hfOnsitePayment.value == "1") {
                dvPaymode.style.display = 'none';
                ddlPayMode.disabled = true;
            }
            else {
                dvPaymode.style.display = '';
                ddlPayMode.disabled = false;
                var paymentmode = ddlPayMode.options[ddlPayMode.selectedIndex].text;
                if (paymentmode == "Credit Card") {
                    byCreditCard.style.display = "block";
                    byECheck.style.display = "none";

                    if ($('#<%= ddlCCType.ClientID %> option:selected').val() == '<%= (int)ChargeCardType.AmericanExpress %>') {
                        $("#<%=AmountPercentageSelect.ClientID %> option[value=50]").attr("selected", true);
                        $("#<%=AmountPercentageSelect.ClientID %> option[value!=50]").attr("disabled", true);
                        $("#<%=AmountPercentageSelect.ClientID %>").change();
                    }
                    else
                        $("#<%=AmountPercentageSelect.ClientID %> option[value!=50]").attr("disabled", false);

                }
                else if (paymentmode == "eCheck") {
                    byCreditCard.style.display = "none";
                    byECheck.style.display = "block";
                }
            }
            if (hfBillingAddress.value == "0") {
                DVAddress.style.display = "block";
                DVAddress.style.visibility = "visible";
            }
            else {
                DVAddress.style.display = "none";
                DVAddress.style.visibility = "hidden";
            }
        }

        function checkPaymentMode() {
            var ddlPayMode = document.getElementById("<%=this.ddlPayMode.ClientID %>");
            var byCreditCard = document.getElementById("byCreditCard");
            var byECheck = document.getElementById("byECheck");

            var paymentmode = ddlPayMode.options[ddlPayMode.selectedIndex].text;
            if (paymentmode == "Credit Card") {
                byCreditCard.style.display = "block";
                byECheck.style.display = "none";
            }
            else if (paymentmode == "eCheck") {
                byCreditCard.style.display = "none";
                byECheck.style.display = "block";
            }
        }
    </script>

    <script type="text/javascript" language="javascript">
        function CouponValidation() {//debugger;
            var txtCouponCode = $("#<%= txtCouponCode.ClientID %>");
            if (txtCouponCode.val() == '') {
                alert('Please enter source code.');
                return false;
            } 

            var spIndicator = document.getElementById("spIndicator");
            spIndicator.style.visibility = "visible";
            spIndicator.style.display = "block";

            var txtCouponCode = $("#<%= txtCouponCode.ClientID %>");

            var addOntestIds = new Array();
            if (selectedAddOnTests != null && selectedAddOnTests.length > 0)
            {
                $.each(selectedAddOnTests, function() {
                    addOntestIds.push(this.Id);
                });
            }

            var parameter = "{'packageId':'" + '<%= PackageId.HasValue?PackageId.Value:0 %>' + "'"; 
            parameter += ",'addOnTestIds':'" + addOntestIds.join(',') + "'";           
            parameter += ",'couponCode':'" + txtCouponCode.val() + "'";
            parameter += ",'eventId':'" + <%= EventId.HasValue?EventId.Value:0 %> + "'";
            parameter += ",'customerId':'" + <%= CustomerId %> + "'";
            parameter += ",'orderTotal':'" + <%= OrderTotal %> + "'";
            parameter += ",'shippingAmount':'" + <%= OrderSummaryControl.ShippingOptionPrice %> + "'";
            parameter += ",'productAmount':'" + <%= OrderSummaryControl.ProductPrice %> + "'}";

            var messageUrl = '<%=ResolveUrl("~/App/CallCenter/CallCenterRep/ExistingCustomer/BillingInformationExisting.aspx/GetCoupon")%>';
            var successFunction = function (result) {
                ApplyCouponAmount(result.d);
            };
            var errorFunction = function () { alert('There was a problem retrieving the data, please try again later.'); }
            InvokeAsyncService(messageUrl, parameter, successFunction, errorFunction);
            return false;
        }
        var discountAmount=0;
        function ApplyCouponAmount(result) {

            //for maintaing state after postback made for applying coupon
            var spIndicator = document.getElementById("spIndicator");
            spIndicator.style.visibility = "hidden";
            spIndicator.style.display = "none";

            var model = result;
            
            var CouponDiscount = formatAmount(model.DiscountApplied).toFixed(2);          

            ////// If the Coupon return error
            if (model.SourceCodeId < 1 && model.FeedbackMessage != null) {
                alert(model.FeedbackMessage.Message);                
                SetSourceCodeDetail(0,'');
                ShowHideSourceCodeAmountDiv(false);   
                discountAmount = 0;
                calculateAmount();                
                return false;
            } //if coupon amount is 0.00
            else if (model.SourceCodeId > 0 && formatAmount(model.DiscountApplied).toFixed(2) == "0.00") {                  
                SetSourceCodeDetail(0,$("#<%= txtCouponCode.ClientID %>").val());
                ShowHideSourceCodeAmountDiv(true); 
                discountAmount = 0;
                calculateAmount();               
                return false;
            }             
                      
            SetSourceCodeDetail((parseFloat(formatAmount(CouponDiscount))).toFixed(2),$("#<%= txtCouponCode.ClientID %>").val());
            ShowHideSourceCodeAmountDiv(true);  
            discountAmount = (parseFloat(formatAmount(CouponDiscount))).toFixed(2);
            calculateAmount();         
            
            var value = '<%= OrderTotal %>';
            if (isNaN(value))
                value = 0;
            else
                value = value - discountAmount;
            if(value>0)
            {
                $('#<%=divPaymentDetails.ClientID %>').show();
                $('.payby-gc').show();
                
                if ('<%=IsTestCoveredByInsurance %>' == '<%=Boolean.TrueString %>') {
                    $("#InsurancePaymentModeDiv").show();
                    
                    var eligibilityId = parseInt($("#<%= EligibilityIdHiddenField.ClientID%>").val());
            
                    if (eligibilityId <= 0) {
                        calculateInsuranceAmount();
                    }
                } 
            }
            else
            {
                $('#<%=divPaymentDetails.ClientID %>').hide();
                $('.payby-gc').hide();
                $("#InsurancePaymentModeDiv").hide();
            }
            return false;
        }

        function ResetAmount() 
        {
            SetSourceCodeDetail(0,'');
            ShowHideSourceCodeAmountDiv(false);   
            discountAmount = 0;
            calculateAmount();              

            $('#<%=divPaymentDetails.ClientID %>').show();
            $('.payby-gc').show();            
        }

        function InvokeAsyncService(messageUrl, parameter, successFunction, errorFunction) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                url: messageUrl,
                data: parameter,
                success: function(result) {
                    successFunction(result);
                },
                error: function(a, b, c) {
                    if (a.status == 401) {
                        alert("You do not have the permission.");
                    }
                    else
                        errorFunction();
                }
            });
        }
        $(document).ready(function() { $("form :input").attr("autocomplete", "off"); });
    </script>
    <div class="wrapper_inpg">
        <div class="maindivredmsgbox" id="errordiv" runat="server" visible="false">
        </div>
        <h1 runat="server" id="StepTitleContainer">
            Existing Customer</h1>
        <div class="contnr_bdr">
            <div class="pgnosymbol_regcust" id="StepSymbolDiv" runat="server">
                <img src="/App/Images/CCRep/page5symbol.gif" alt="" />
            </div>
            <div class="middivrow_regcust">
                <p class="orngheadtxt_regcust">
                    Billing Information</p>
                <div class="fline_regcust">
                </div>
                <p class="normaltxt_regcust" id="TotalBillingAmountP" runat="server">
                    Your Total Billing amout is <strong><u>$<span runat="server" id="dvTotalAmount" class="total-amount-span">0.00</span></u></strong>.
                </p>
                <div style="width: 530px; float: left; margin: 10px 0px" id="OrderSummaryDiv" runat="server">
                    <SummaryControl:OrderSummary ID="OrderSummaryControl" runat="server" />                   

                    <div style="clear:both; border: solid 1px #CCCCCC; margin-top:5px; margin-bottom: 5px; padding: 10px 5px;">
                        <span> <b>How much are you going to pre-pay?</b> </span> <span> <select id="AmountPercentageSelect" runat="server" onchange="calculateAmount();">
                        <option value="100"> 100 %</option>
                        <option value="75"> 75 %</option>
                        <option value="50"> 50 %</option>
                        <option value="25"> 25 %</option> 
                        <option value="25.00"> $ 25</option></select>                        
                        </span>
                        <span>
                           $ <asp:TextBox runat="server" ID="AmountTobePaidTextbox" Width="40px"></asp:TextBox></span>
                        <span style="margin-left: 15px;">
                            Amount Due: $ <asp:TextBox runat="server" ID="AmountDueTextbox" ReadOnly="true" Width="40px"></asp:TextBox>
                        </span>
                    </div>
                    <script language="javascript" type="text/javascript">
                        function calculateAmount() {//debugger;

                            var value = '<%= OrderTotal %>';
                            if (isNaN(value))
                                value = 0;
                            else
                                value = value - discountAmount - insuranceAmount + copayamount;

                            var percentageAmount = Number($("#<%=AmountPercentageSelect.ClientID %> option:selected").val());
                            if ($("#<%=AmountPercentageSelect.ClientID %> option:selected").text().indexOf('%') >0) {

                                $("#<%= AmountTobePaidTextbox.ClientID %>").val(parseFloat((value * percentageAmount) / 100).toFixed(2));
                                $("#<%= AmountDueTextbox.ClientID %>").val(parseFloat(value - ((value * percentageAmount) / 100)).toFixed(2));
                                $('#<%=dvTotalAmount.ClientID %>').html(parseFloat((value * percentageAmount) / 100).toFixed(2));
                            }
                            else {
                                $("#<%= AmountTobePaidTextbox.ClientID %>").val(parseFloat(percentageAmount).toFixed(2));
                                $("#<%= AmountDueTextbox.ClientID %>").val(parseFloat(value - percentageAmount).toFixed(2));
                                $('#<%=dvTotalAmount.ClientID %>').html(parseFloat(percentageAmount).toFixed(2));
                            }
                        }

                        $(document).ready(function () {
                            if ('<%=IsGiftCertificate %>' == 'False') {
                                $("#<%= AmountTobePaidTextbox.ClientID %>").attr("readonly", "readonly");
                                $('#<%= ddlCCType.ClientID %>').change(function () {
                                    SetAmexAmount();
                                });


                                $('form').submit(function () {
                                    $("#<%= AmountTobePaidTextbox.ClientID %>").attr("readonly", "");
                                });
                            }
                        });

                        function SetAmexAmount() {
                            if ($('#<%= ddlCCType.ClientID %> option:selected').val() == '<%= (int)ChargeCardType.AmericanExpress %>') {
                                $("#<%=AmountPercentageSelect.ClientID %> option[value=50]").attr("selected", true);
                                $("#<%=AmountPercentageSelect.ClientID %> option[value!=50]").attr("disabled", true);
                                $("#<%=AmountPercentageSelect.ClientID %>").change();
                            }
                            else
                                $("#<%=AmountPercentageSelect.ClientID %> option[value!=50]").attr("disabled", false);
                        }
    
                    </script>

                    <div class="sourcecode_cc" id="SourceCodeApplyDiv">
						<asp:Panel DefaultButton="imgCouponApply" ID="SourceCodePanel" runat="server">
							<span id="spnSourceCodeMessage" runat="server"><b>Enter Source Code:</b></span> 
                            <span style="margin-left:10px;">
									<asp:TextBox ID="txtCouponCode" runat="server" CssClass="inputfield_ccrep" Width="95px"></asp:TextBox>
							</span>
                            <span class="button_con_nowidth" style="float:right;">
									<asp:ImageButton ID="imgCouponApply" runat="server" ImageUrl="~/App/Images/apply-btn.gif"
										OnClientClick="return CouponValidation();"></asp:ImageButton>
							</span>
                            <span id="spnSourcecodeNotes" runat="server" style="float: left; display: none;margin-top: 3px;">
                                <a href="javascript:void(0);" class="tt" runat="server" id="ahrefToolTipIsPaid">
										    <b>Notes</b>
                                            <span class="tooltip">
                                                <span class="top"></span>
                                                <span class="middle" id="spndefcursor" onmouseover="changetodefault('spndefcursor');" onmouseout="changetopointer('spndefcursor');">
											    Source code is not applicable for this private event. 
                                                </span>
                                                <span class="bottom"></span>
                                            </span>
                                </a>
                            </span>
                            <span id="spIndicator" style="visibility: hidden; display: none;">
								<img id="imgIdicator" src="/App/images/indicator.gif" />
							</span>
						</asp:Panel>
					</div>
                </div>
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
                <div id="DivGiftCertificatepayment">
                    <p class="normaltxt_regcust gc-purchase">
                        Item Purchased: Gift Certificate for $<span id="GiftCertificateAmount" runat="server"
                            style="font-weight: bold;"></span>
                    </p>
                    <div class="normaltxt_regcust payby-gc">
                        <uc:GCApply ID="GCApply" runat="server" />
                    </div>
                </div>
                <div style="float:left; width: 95%;" class="info-box" id="PrepayDiv" runat="server">
                    <span id="PrepayTooltipText" runat="server"></span>
                </div>
                <div id="divPaymentDetails" runat="server">
                    <p class="subheadingbg_ccrep">
                        <span style="float: left;">Payment Details</span>
                        <span style="float: left; padding-left: 15px; font-weight: normal;" id="OnSitePaymentSpan" runat="server">                            
                            <asp:CheckBox ID="chkOnsitePayment" Text="Onsite Payment" runat="server" AutoPostBack="false" CssClass="" Checked="false"></asp:CheckBox>
                        </span>                                                
                        <span style="float: right;"><span class="titletxt_regcust" style="width: 100px;
                            font-weight: normal">Payment Mode<span class="reqiredmark"><sup>*</sup></span>:</span>
                            <span class="inputconright_regcust">
                                <asp:DropDownList runat="server" ID="ddlPayMode" Width="100px" CssClass="inputfield_ccrep">
                                </asp:DropDownList>
                            </span></span>
                    </p>
                    <div id="dvPaymode">
                        <div id="byCreditCard">
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
                                    <asp:TextBox ID="txtExpirationDate" runat="server" CssClass="inputfield_ccrep mask-date" Width="85px"
                                        MaxLength="7"></asp:TextBox>&nbsp;MM/YYYY </span><span class="titletxt_regcust">Security
                                            Code<span class="reqiredmark"><sup>*</sup></span>:</span> <span class="inputconright_regcust">
                                                <asp:TextBox ID="txtSequrityNo" runat="server" CssClass="inputfield_ccrep" Width="80px"
                                                    MaxLength="4"></asp:TextBox>
                                            </span>
                            </p>
                            <p class="middivrow_regcust">
                                <span style="font-style: italic;">(If you select American Express as card type then you can charge only 50% of the total amount.)</span>
                            </p>
                        </div>
                        <div id="byECheck" style="display: none;">
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
                                <span class="titletxt_regcust">Account Type:<span class="reqiredmark"><sup>*</sup></span></span>
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
                                        Width="100px"></asp:TextBox></span>
                            </p>
                            <p class="middivrow_regcust">
                                <span class="titletxt_regcust">Zip Code<sup>*</sup></span> <span class="inputfldnowidth_default">
                                    <asp:TextBox ID="txtZip" runat="server" CssClass="inputfield_ccrep" Width="100px"></asp:TextBox></span>
                            </p>
                            <p class="middivrow_regcust">
                                <span class="titletxt_regcust">Phone<sup>*</sup></span><span class="inputfldnowidth_default">
                                    <asp:TextBox ID="txtHPhone" runat="server" CssClass="inputfield_ccrep mask-phone"
                                        Width="140px"></asp:TextBox></span>
                            </p>
                        </div>
                    </div>
                </div>
                <div id="divTotalFree" runat="server" style="display: none; visibility: hidden;">
                    <p class="middivrow_regcust">
                        <span style="float: left; width: 20px;">
                            <img src="/App/Images/error-icon.gif" /></span> <span style="float: left; width: 500px;">
                                &nbsp;As you have given 100% discount source code, no billing information is required
                                from your side. Please click on Submit button to get confirmation receipt.</span>
                    </p>
                </div>
                <div class="fline_regcust">
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
                    <span style="font-weight: bold; padding-right: 5px; color: Red;">Payment Gateway RequestID:
                    </span><span id="spnRequestID" runat="server" style="color: Red;"></span>
                </p>
                <p class="buttoncell_ccrep">
                    <span class="buttoncon_ccrep">
                        <asp:ImageButton ID="imgBack" runat="server" ImageUrl="/App/Images/back-buton.gif"
                            OnClick="imgBack_Click" />
                    </span><span class="buttoncon_ccrep" style="visibility: hidden; display: none;" id="spnIndicator">
                        <img src="/App/Images/indicator.gif" />
                    </span><span class="buttoncon_ccrep" id="spansave">
                        <asp:ImageButton ID="imgSave" runat="server" ImageUrl="/App/Images/submit-button.gif"
                            OnClientClick="return Validation()" OnClick="imgSave_Click" />
                    </span>
                </p>
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
                <div class="endcall_ccrep_dboard" style="margin-top: 5px">
                    <span class="endtbtn_ccrep_dboard">
                        <asp:ImageButton ID="imgEndCall" runat="server" ImageUrl="~/App/Images/CCRep/endcallbtn.gif"
                            OnClientClick="closeScriptPopup(); CallNotes(); return false;" />
                    </span>
                </div>
            </div>
        </div>
    </div>
    <div id="insurance-eligibility-div-dialog">
    </div>
    <input type="hidden" id="TotalAmountHiddenbox" value="<%= TotalAmount.HasValue ? TotalAmount.Value : 0 %>" />
    
    <script type="text/javascript">
        var insuranceAmount = 0;
        var copayamount = 0;
        function calculateInsuranceAmount() {
            //debugger;
            insuranceAmount = (parseFloat(formatAmount($("#<%= InsuranceAmountHiddenField.ClientID%>").val())));
            copayamount = (parseFloat(formatAmount($("#<%= CoPayAmountHiddenField.ClientID%>").val())));

            if (insuranceAmount > 0) {
                var value = '<%= OrderTotal %>';
                if (isNaN(value))
                    value = 0;
                else
                    value = value - discountAmount;

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
                error: function(a, arg2) {
                    if (a.status == 401) {
                        alert("You do not have the permission.");
                    } 
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
                error: function(a, arg2) {
                    if (a.status == 401) {
                        alert("You do not have the permission.");
                    } 
                }
            });
        }

    </script>
    <script type="text/javascript" language="javascript">
        var states;
        $(document).ready(function() {
            $('.mask-date').mask('99/9999');
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

            $('#<%=txtCouponCode.ClientID %>').bind("blur", function(){ResetAmount();});

            if ('<%=IsGiftCertificate %>' == 'False') 
            {
                calculateAmount();
                SetAmexAmount();
            }

            var txtCouponCode = $("#<%= txtCouponCode.ClientID %>");
            if ($.trim(txtCouponCode.val()).length > 0)
                CouponValidation();
            
            $("#insurance-eligibility-div-dialog").dialog({ width: 650, autoOpen: false, title: 'Check Eligibility', modal: true, resizable: false, draggable: true });
            $("#insurance-eligibility-div-dialog").bind('dialogclose', function() { onCloseEligibilityDialog(); });
            
            if ('<%=IsTestCoveredByInsurance %>' == '<%=Boolean.FalseString %>') {
                $("#InsurancePaymentModeDiv").hide();
            } else {
                $("#InsurancePaymentModeDiv").show();
                onCloseEligibilityDialog();
            }
            
            if ('<%=DoNotAllowPrePayment %>' == '<%= Boolean.TrueString %>') {
                $("#<%= chkOnsitePayment.ClientID%>").attr("checked", "checked");
                OnsitePayment();
                $("#<%= chkOnsitePayment.ClientID%>").attr("disabled", "disabled");
                $("#<%= PrepayTooltipText.ClientID %>").html("Note: Customers registering for AWV event will pay after screening.");
                $("#<%= PrepayDiv.ClientID %>").show();
            }

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
    <asp:HiddenField ID="hfOnsitePayment" runat="server" Value="0" />
    <asp:HiddenField ID="hfBillingAddress" runat="server" Value="1" />
    <asp:HiddenField ID="hfTempTotalAmount" runat="server" />
    <asp:HiddenField ID="hfTempNetAmount" runat="server" />
    <script type="text/javascript" language="javascript">
        //// this will run after page is load
        var hfCallStartTime = document.getElementById("<%= this.hfCallStartTime.ClientID %>");
        StartTimer(hfCallStartTime);
    </script>
</asp:Content>
