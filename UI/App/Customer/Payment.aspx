<%@ Page Language="C#" MasterPageFile="~/App/Customer/CustomerMaster.master" AutoEventWireup="true" Title="Payment Details"
Inherits="Falcon.App.UI.App.Customer.Payment" Codebehind="Payment.aspx.cs" EnableEventValidation="false" %>

<%@ Register TagPrefix="uc" Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" %>
<%@ Register Src="~/App/UCCommon/UCCustomerLeftInfo.ascx" TagName="CustomerUC" TagPrefix="CustLeft" %>
<%@ Register Src="~/App/UCCommon/EventCustomerInformation.ascx" TagPrefix="EventCustomer" TagName="Information" %>
<%@ Register Src="~/App/UCCommon/OrderSummary.ascx" TagName="OrderSummary" TagPrefix="SummaryControl" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="content1" runat="server">
 <uc:JQueryToolkit ID="_jQueryToolkit" runat="server" IncludeAjax="true" IncludeJQueryUI="true"
        IncudeJQueryAutoComplete="true" IncludeJQueryMaskInput="true" />
    <script language="javascript" type="text/javascript" src="/Scripts/jquery.unobtrusive-ajax.js"></script>
    <script language="javascript" type="text/javascript">
        window.history.forward(1);
    </script>

    <script language="javascript" type="text/javascript">


        var GB_ROOT_DIR = "/App/Wizard/greybox/";
        function formatAmount(num) {
            if (isNaN(parseFloat(num)))
            { num = '0.00'; }
            return parseFloat(num);            
        }

        function CheckBillingAddress() {
            var DVAddress = document.getElementById('<%= DVAddress.ClientID %>');
            var rbtBillingAddressY = document.getElementById('<%= rbtBillingAddressY.ClientID %>');
            var hfBillingAddress = document.getElementById("<%=hfBillingAddress.ClientID %>");
            if (rbtBillingAddressY.checked) {
                DVAddress.style.display = "none";
                DVAddress.style.visibility = "hidden";
                hfBillingAddress.value = "1";
            } else {
                DVAddress.style.display = "block";
                DVAddress.style.visibility = "visible";
                hfBillingAddress.value = "0";
            }
            return true;
        }

        function OnsitePayment() {
            // debugger divAddress
            var ddlPayMode = document.getElementById("<%= ddlPayMode.ClientID %>");
            var divAddress = document.getElementById("<%= divAddress.ClientID %>");
            var ddlCCType = document.getElementById("<%= ddlCCType.ClientID %>");
            var txtCCNo = document.getElementById("<%= txtCCNo.ClientID %>");
            var txtSequrityNo = document.getElementById("<%= txtSequrityNo.ClientID %>");
            var txtExpirationDate = document.getElementById("<%= txtExpirationDate.ClientID %>");
            var chkOnsitePayment = document.getElementById("<%= chkOnsitePayment.ClientID %>");
            var bolOnSitePayment = chkOnsitePayment.checked;
            //ddlPayMode.disabled = bolOnSitePayment;
            ddlCCType.disabled = bolOnSitePayment;
            txtCCNo.disabled = bolOnSitePayment;
            txtSequrityNo.disabled = bolOnSitePayment;
            txtExpirationDate.disabled = bolOnSitePayment;
            var byCreditCard = document.getElementById("byCreditCard");
            var hfOnsitePayment = document.getElementById("<%=hfOnsitePayment.ClientID %>");
            if (bolOnSitePayment == true) {
                byCreditCard.style.display = 'none';
                divAddress.style.display = 'none';
                hfOnsitePayment.value = "1";
            } else {
                byCreditCard.style.display = '';
                divAddress.style.display = '';
                hfOnsitePayment.value = "0";
            }

        }

        function Validation() {
            //debugger
            var ddlCCType = document.getElementById("<%= ddlCCType.ClientID %>");
            var txtCCNo = document.getElementById("<%= txtCCNo.ClientID %>");
            var txtExpirationDate = document.getElementById("<%= txtExpirationDate.ClientID %>");
            var txtSequrityNo = document.getElementById("<%= txtSequrityNo.ClientID %>");
            var txtCName = document.getElementById("<%= txtCName.ClientID %>");
            var rbtBillingAddressY = document.getElementById("<%= rbtBillingAddressY.ClientID %>");
            var chkOnsitePayment = document.getElementById("<%= chkOnsitePayment.ClientID %>");
            var hfNetPayableAmount = document.getElementById("<%= hfNetPayableAmount.ClientID %>");
            var dvTotalAmount = document.getElementById("<%= dvTotalAmount.ClientID %>");
            hfNetPayableAmount.value = dvTotalAmount.innerHTML;
            var ddlPayMode = document.getElementById("<%=ddlPayMode.ClientID %>");
            var paymentmode = ddlPayMode.options[ddlPayMode.selectedIndex].text;

            if (hfNetPayableAmount.value != "0.00") {
                if (chkOnsitePayment.checked != true) {
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
                    } else if (paymentmode == "eCheck") {
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
                    }
                }
                if (rbtBillingAddressY.checked != true) {
                    var txtAddress1 = document.getElementById("<%= txtAddress1.ClientID %>");
                    var txtCity = document.getElementById("<%= txtCity.ClientID %>");
                    var ddlState = document.getElementById("<%= ddlState.ClientID %>");
                    var txtZip = document.getElementById("<%= txtZip.ClientID %>");


                    if (isBlank(txtAddress1, "Address")) {
                        return false;
                    }
                    if (checkLength(txtAddress1, 500, "Address")) {
                        return false;
                    }
                    if (checkDropDown(ddlState, "State for  Address") == false) {
                        return false;
                    }
                    if (isBlank(txtCity, "City for  Address")) {
                        return false;
                    }
                    if (isBlank(txtZip, "Zip")) {
                        return false;
                    }

                }
            }
            document.getElementById("spansave").style.display = 'none';
            document.getElementById("spnIndicator").style.visibility = 'visible';
            document.getElementById("spnIndicator").style.display = 'block';

            var isNewFullfillmentOption = '<%=IsNewFullfillmentOption %>' == 'True' ? true : false;
            var isNewPurchaseImageOption = '<%=IsNewPurchaseImageOption %>' == 'True' ? true : false;

            if (!isNewFullfillmentOption && !isNewPurchaseImageOption) {
                __doPostBack('save', '');
            } else if (isNewFullfillmentOption) {
                __doPostBack('isNewFullfillmentOption', '');
            } else if (isNewPurchaseImageOption) {
                __doPostBack('isNewPurchaseImageOption', '');
            }

            return false;
        }

        function CheckDecimal(evt) {
            return KeyPress_DecimalAllowedOnly(evt);
        }

        function SetValuesafterFailedPostBack() {
            var byCreditCard = document.getElementById("byCreditCard");
            var byECheck = document.getElementById("byECheck");
            var hfOnsitePayment = document.getElementById("<%=hfOnsitePayment.ClientID %>");
            var DVAddress = document.getElementById('<%= DVAddress.ClientID %>');
            var hfBillingAddress = document.getElementById("<%=hfBillingAddress.ClientID %>");
            var ddlPayMode = document.getElementById("<%=ddlPayMode.ClientID %>");
            var paymentmode = ddlPayMode.options[ddlPayMode.selectedIndex].text;
            if (hfOnsitePayment.value == "1") {
                byCreditCard.style.display = 'none';
            } else {
                if (paymentmode == "Credit Card") {
                    byCreditCard.style.display = "block";
                    byECheck.style.display = "none";
                } else if (paymentmode == "eCheck") {
                    byCreditCard.style.display = "none";
                    byECheck.style.display = "block";
                }

            }
            if (hfBillingAddress.value == "0") {
                DVAddress.style.display = "block";
                DVAddress.style.visibility = "visible";
            } else {
                DVAddress.style.display = "none";
                DVAddress.style.visibility = "hidden";
            }
        }

        function checkPaymentMode() {
            var ddlPayMode = document.getElementById("<%=ddlPayMode.ClientID %>");
            var byCreditCard = document.getElementById("byCreditCard");
            var byECheck = document.getElementById("byECheck");

            var paymentmode = ddlPayMode.options[ddlPayMode.selectedIndex].text;
            if (paymentmode == "Credit Card") {
                byCreditCard.style.display = "block";
                byECheck.style.display = "none";
            } else if (paymentmode == "eCheck") {
                byCreditCard.style.display = "none";
                byECheck.style.display = "block";
            }
        }

        function popupmenu2(choice, wt, ht) {
            var winOpts = "toolbar=no,location=no,directories=no,status=no,scrolling=auto,scrollbars=yes,menubar=no,width=" + wt + ",height=" + ht;
            confirmWin = window.open(choice, 'theconfirmWin', winOpts);
            window.open(choice, 'theconfirmWin', winOpts);
        }
    </script>

<script type="text/javascript" language="javascript">
    $(function() {
        var isFullfillmentOption = '<%=IsNewFullfillmentOption %>' == 'True' ? true : false;
        var isNewPurchaseImageOption = '<%=IsNewPurchaseImageOption %>' == 'True' ? true : false;

        if (isFullfillmentOption || isNewPurchaseImageOption) {
            $('#RegisterStepsDiv').hide();
            $('#EventInformationDiv').show();
        }
        else {
            $('#RegisterStepsDiv').show();
            $('#EventInformationDiv').hide();
        }
    });
</script>

    <div class="maindiv_custdbrd">
        <%--<div id="dvTitle" runat="server" class="mainbody_titletxtleft">
                    Register Event</div>--%>
        <div class="mindivbgblue_custdbrd">
            <span class="divheadtxt_custdbrd">Register Event</span>
        </div>
        <div id="Div1" class="leftcon_main_custdbrd" style="margin-bottom:5px;height:900px">
            <CustLeft:CustomerUC ID="uc1" runat="server" />
        </div>
        <div class="main_area_custdbrd">
           <div class="main_row_custdbrd">
                <div class="maindivredmsgbox" id="errordiv" runat="server" visible="false">
                </div>
                <div class="main_area_bdrnone">
                    <div class="divsteps_re">
                        <div id="RegisterStepsDiv">
                             <img src="../Images/Customer_step5n.gif" alt="" />
                        </div>					                       
                        <div class="main_area_bdrnone">
						    <div class="middivrow_regcust">
                                <div class="maincontentrow_re">
                                    <p class="maincontentrow_re">
                                        <span class="orngheadtxt_heading">Billing Information</span></p>
                                    <p class="fline_re">
                                        <img src="/App/Images/CCRep/specer.gif" width="1px" height="1px" /></p>
							        <div id="EventInformationDiv">
								        <EventCustomer:Information ID="EventCustomerControl" runat="server" />
								        </div>
							        <div id="TotalAmountDiv" runat="server">
                                        <p class="maincontentrow_re">
                                            <span class="normaltxt_regcust" style="color:#F37C00;">Total Amount due: <strong>$<span runat="server"
                                                id="dvTotalAmount">0.00</span></strong></span></p>
                                        <p class="fline_re">
                                            <img src="../Images/specer.gif" width="1" height="1" /></p>
                                    </div>
                                </div>
                                <div class="maincontentrow_re">
                                    <div style="width: 520px; float: left;" id="OrderSummaryDiv" runat="server">
					                    <SummaryControl:OrderSummary ID="OrderSummaryControl" runat="server" />
				                    </div>
                                </div>
                                <div class="sourcecode_cc" id="InsurancePaymentModeDiv" style="margin-top: 10px; width: 98%; padding: 5px;">
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
                                <div id="divPaymentDetails" runat="server" class="left">
                                    <p class="subheadingbg_ccrep">
                                        <span style="float:left;">Payment Details</span>
                                        <span style="float:right;">
                                            <span class="titletxt_regcust">Payment Mode<span class="reqiredmark"><sup>*</sup></span>:</span>
                                            <span class="inputconright_regcust">
                                                <asp:DropDownList runat="server" ID="ddlPayMode" Width="100px" CssClass="inputfield_ccrep">
                                                </asp:DropDownList>
                                            </span>
                                        </span>
                                        <span style="display:none;">
                                            <asp:CheckBox ID="chkOnsitePayment" Text="Onsite Payment" runat="server" AutoPostBack="false" CssClass="" Checked="false"></asp:CheckBox>
                                        </span>
                                    </p>
                                    <div id="byCreditCard">
                                        <p class="middivrow_regcust">
                                            <span class="titletxt_regcust">Name on Card<span class="reqiredmark"><sup>*</sup></span>:</span>
                                            <span class="inputconleft_regcust">
                                                <asp:TextBox ID="txtCName" runat="server" CssClass="inputfield_ccrep" Width="130px"
                                                    MaxLength="30"></asp:TextBox>
                                            </span>
                                        </p>
                                        <p class="middivrow_regcust">
                                            <span class="titletxt_regcust" style="width:100px;">Credit Card Number<span class="reqiredmark"><sup>*</sup></span>:</span>
                                            <span class="inputconleft_regcust">
                                                <asp:TextBox ID="txtCCNo" runat="server" CssClass="inputfield_ccrep" Width="120px"
                                                    MaxLength="16"></asp:TextBox>
                                            </span>
                                            <span class="titletxt_regcust">Credit Card Type<span class="reqiredmark"><sup>*</sup></span>:</span>
                                            <span class="inputconright_regcust">
                                                <asp:DropDownList runat="server" ID="ddlCCType" Width="140px" CssClass="inputfield_ccrep">
                                                </asp:DropDownList>
                                            </span>                                                
                                        </p>
                                        <p class="middivrow_regcust">
                                            <span class="titletxt_regcust">Expiration Date<span class="reqiredmark"><sup>*</sup></span>:</span>
                                            <span class="inputconleft_regcust" style="font-size: 9px; color: #000;">
                                                <asp:TextBox ID="txtExpirationDate" runat="server" CssClass="inputfield_ccrep" Width="85px"
                                                    MaxLength="7"></asp:TextBox>&nbsp;MM/YYYY </span>
                                            <span class="titletxt_regcust" style="width:120px;">Security Code<span class="reqiredmark"><sup>*</sup></span>:</span>
                                            <span class="inputconright_regcust">
                                                <asp:TextBox ID="txtSequrityNo" runat="server" CssClass="inputfield_ccrep" Width="80px"
                                                    MaxLength="4" TextMode="Password"></asp:TextBox>
                                                <span class="whtisthis_payment1" style="float:left;"><a href="javascript:popupmenu2('/Public/Customer/cvv.htm',660,700)"  id="aWhat">What is this?</a></span>
                                            </span>

                                        </p>
                                    </div>
                                    <div id="byECheck" style="display:none;">
                                        <p class="middivrow_regcust">
                                            <span class="titletxt_regcust">Routing Number:<span class="reqiredmark"><sup>*</sup></span></span>
                                            <span class="inputconleft_regcust">
                                                <asp:TextBox ID="txtERoutingNo" runat="server" CssClass="inputfield_ccrep" Width="130px"></asp:TextBox>
                                            </span>
                                            <span class="titletxt_regcust">Account Number:<span class="reqiredmark"><sup>*</sup></span></span>
                                            <span class="inputconright_regcust">
                                                <asp:TextBox ID="txtEAccountNo" runat="server" CssClass="inputfield_ccrep" Width="120px"></asp:TextBox>
                                            </span>
                                        </p>
                                        <p class="middivrow_regcust">
                                            <span class="titletxt_regcust">Type of Account:<span class="reqiredmark"><sup>*</sup></span></span>
                                            <span class="inputconleft_regcust">
                                                <asp:DropDownList runat="server" ID="ddlEAccountType" Width="135px" CssClass="inputf_def">
                                                </asp:DropDownList>
                                            </span>
                                            <span class="titletxt_regcust">Check Number:<span class="reqiredmark"><sup>*</sup></span></span>
                                            <span class="inputconright_regcust">
                                                <asp:TextBox ID="txtECheckNo" runat="server" CssClass="inputfield_ccrep" Width="120px" MaxLength="20"></asp:TextBox>
                                            </span>
                                        </p>
                                        <p class="middivrow_regcust">
                                            <span class="titletxt_regcust">Bank Name:<span class="reqiredmark"><sup>*</sup></span></span>
                                            <span class="inputconleft_regcust">
                                                <asp:TextBox ID="txtEBankName" runat="server" CssClass="inputfield_ccrep" Width="130px"></asp:TextBox>
                                            </span>
                                            <span class="titletxt_regcust">Account Holder:<span class="reqiredmark"><sup>*</sup></span></span>
                                            <span class="inputconright_regcust">
                                                <asp:TextBox ID="txtEAccHolderName" runat="server" CssClass="inputfield_ccrep" Width="120px"></asp:TextBox>
                                            </span>
                                        </p>
                                        <p class="middivrow_regcust">
                                            <span style="float:left; padding-left:10px;"><img src="/App/Images/check-routing-sample.gif" /></span>
                                        </p>
                                    </div>
                                    <div class="flinerowbg_ccrep" id="divAddress" runat="server">
                                        <p class="contentrow_pw">
                                            <span class="titletextbluebold_ccrep">Is Your Billing Address The Same As Your Contact Address?</span>
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
                                            <span class="titletxt_regcust">Address<span class="reqiredmark"><sup>*</sup></span>:</span>
                                            <span class="inputconleft_regcust">
                                                <asp:TextBox ID="txtAddress1" runat="server" CssClass="inputfield_ccrep" Width="350px"></asp:TextBox>
                                            </span>

                                        </p>
                                        <p class="middivrow_regcust">
                                            <span class="titletxt_regcust">Suite, Apt, etc.</span>
                                            <span class="inputfldnowidth_default">
                                                <asp:TextBox ID="txtAddress2" runat="server" CssClass="inputfield_ccrep" Width="350px"></asp:TextBox>
                                            </span>
                                        </p>
                                        <p class="middivrow_regcust">
                                            <span class="titletxt_regcust">Country<sup>*</sup></span> <span class="inputfldnowidth_default">
                                                <asp:DropDownList ID="ddlCountry" runat="server" CssClass="inputfield_ccrep ddl-states" Width="150px">                                                        
                                                </asp:DropDownList>
                                            </span>
                                        </p>
                                        <p class="middivrow_regcust">
                                            <span class="titletxt_regcust">State<span class="reqiredmark"><sup>*</sup></span>:</span>
                                            <span class="inputconleft_regcust">
                                                <asp:DropDownList runat="server" ID="ddlState" Width="110px" CssClass="inputfield_ccrep ddl-states">
                                                </asp:DropDownList>
                                            </span>
                                        </p>    
                                        <p class="middivrow_regcust">
                                            <span class="titletxt_regcust">City<span class="reqiredmark"><sup>*</sup></span>:</span>
                                            <span class="inputconleft_regcust">
                                                <asp:TextBox ID="txtCity" runat="server" CssClass="inputfield_ccrep auto-Search" Width="100px"></asp:TextBox></span>
                                        </p>
                                        <p class="middivrow_regcust">
                                            <span class="titletxt_regcust">Zip<span class="reqiredmark"><sup>*</sup></span>:</span>
                                            <span class="inputconleft_regcust">
                                                <asp:TextBox ID="txtZip" runat="server" CssClass="inputfield_ccrep" Width="70px"></asp:TextBox></span>
                                        </p>
                                        <p class="middivrow_regcust">
                                            <span class="titletxt_regcust">Phone(Home):</span> <span class="inputconright_regcust">
                                                <asp:TextBox ID="txtHPhone" runat="server" CssClass="inputfield_ccrep mask-phone" Width="110px"></asp:TextBox>
                                            </span>
                                        </p>
                                        <p class="fline_regcust">
                                            <img src="/App/Images/CCRep/specer.gif" width="1px" height="1px" /></p>
                                    </div>
                                </div>
                                <div id="divTotalFree" runat="server" style="display:none;visibility:hidden;">
                                    <p class="middivrow_regcust">
                                        <span style="float: left">
                                            <img src="/App/Images/error-icon.gif" /></span> <span style="float: left">&nbsp;As you
                                                have given 100% discount source code, no billing information is required from your
                                                side. Please click on Submit button to get confirmation receipt.</span>
                                    </p>
                                </div>
                                <div class="middivrow_regcust" id="pDecision" runat="server" visible="false">
                                    <span style="font-weight: bold; padding-right: 5px; color: Red;">Payment Status:</span>
                                    <span id="spnDecision" runat="server" style="color: Red;"></span>
                                </div>
                                <div class="middivrow_regcust" id="pReasonCode" runat="server" visible="false">
                                    <span style="font-weight: bold; padding-right: 5px; color: Red;">Reason: </span>
                                    <span id="spnReasonCode" runat="server" style="color: Red;"></span>
                                </div>
                                <div id="pRequestID" runat="server" visible="false">
                                    <div class="middivrow_regcust">
                                        <span style="font-weight: bold; padding-right: 5px; color: Red;">Payment Gateway Request ID: </span>
                                        <span id="spnRequestID" runat="server" style="color: Red;"></span>
                                    </div>
                                    <div class="fline_regcust">
                                        <img src="../Images/CCRep/specer.gif" width="1px" height="1px" /></div>
                                </div>
                                <div class="buttoncell_ccrep" style="width:170px; margin-top:10px; float:right;">
                                    <span class="buttoncon_ccrep">
                                        <asp:ImageButton ID="imgBack" runat="server" ImageUrl="../Images/back-buton.gif" OnClick="imgBack_Click" />
                                    </span> 
                                    <span class="buttoncon_ccrep" id="spansave">
                                        <asp:ImageButton ID="imgSave" runat="server" ImageUrl="../Images/submit-button.gif" OnClientClick="return Validation()" OnClick="imgSave_Click" />
                                    </span>
                                    <span class="buttoncon_ccrep" style="visibility: hidden; display: none;" id="spnIndicator">
                                        <img src="../Images/indicator.gif" />
                                    </span>
                                </div>
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
            $('#<%= dvTotalAmount.ClientID %>').html(parseFloat(value).toFixed(2));
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
    <asp:HiddenField runat="server" ID="hfCallStartTime" />
    <asp:HiddenField ID="hfOnsitePayment" runat="server" Value="0" />
    <asp:HiddenField ID="hfBillingAddress" runat="server" Value="1" />
    <asp:HiddenField ID="hfNetPayableAmount" runat="server" />
</asp:Content>
