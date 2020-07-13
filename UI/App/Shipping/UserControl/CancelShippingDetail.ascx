<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CancelShippingDetail.ascx.cs"
    Inherits="Falcon.App.UI.App.Shipping.UserControl.CancelShippingDetail" %>
<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.Core.Finance.Enum" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>
<%@ Register Src="~/App/UCCommon/Message.ascx" TagName="Message" TagPrefix="uc" %>
<%@ Register Src="~/App/UCCommon/JQueryToolkit.ascx" TagPrefix="ToolKit" TagName="JQuery" %>
<ToolKit:JQuery ID="JQuryToolkit" runat="server" IncludeJQueryUI="true" IncudeJQueryJTip="true" />
<h1>
    Cancel Shipping Details</h1>
<div class="hr left">
</div>
<uc:Message ID="MessageBox" runat="server" />
<div id="DataGridDiv" runat="server">
    <div class="fltrdv bold" style="margin: 5px 0">
        Following Shipping Details are available for cancellation</div>
    <div>
        <asp:HiddenField ID="Address1Hidden" runat="server" />
        <asp:HiddenField ID="CityHidden" runat="server" />
        <asp:HiddenField ID="ZipHidden" runat="server" />
        <asp:HiddenField ID="CountryIdHidden" runat="server" />
        <asp:HiddenField ID="StateIdHidden" runat="server" />
        <asp:GridView ID="AvailableShippingDetailsGrid" runat="server" GridLines="none" OnRowDataBound="AvailableShippingDetailsGrid_RowDataBound"
            AutoGenerateColumns="false" CssClass="select-table divgrid_clnew">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <div>
                            <asp:CheckBox ID="chkSelectAll" runat="server" /></div>
                    </HeaderTemplate>
                    <HeaderStyle CssClass="check-all" />
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect" runat="server" CssClass="chk-select" />
                        <span id="BeyondProcessingStatusSpan" runat="server" visible="false" class="jTip"
                            title="Cancel Shipping|This shipping option can be cancelled because it has gone beyond processing stage.">
                            ?</span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Shipping Option">
                    <ItemTemplate>
                        <asp:Literal ID="ShippingDetailIdLiteral" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Id") %>'
                            Visible="false" />
                        <asp:Literal ID="OrderDetailIdLiteral" runat="server" Visible="false" />
                        <asp:Literal ID="ShippingOptionNameLiteral" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"ShippingOption.Name") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <asp:Literal ID="ShipmentStatusLiteral" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Status").ToString() %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Price">
                    <ItemTemplate>
                        <asp:Label ID="PriceLabel" runat="server" CssClass="price-label" Text='<%#Convert.ToDecimal(DataBinder.Eval(Container.DataItem,"ActualPrice")).ToString("0.00") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="row1" />
            <RowStyle CssClass="row2" />
            <AlternatingRowStyle CssClass="row3" />
        </asp:GridView>
    </div>
    <p class="main_area_bdrnone payment-amount" style="display: none">
        <span class="ttxtnowidthnormal_default"></span><span class="ttxtnowidthnormal_default">
            <span class="titletextlarge_default">Total Refund Amount:</span> <span class="ttxtnowidthnormal_default">
                <span id="RefundAmount"></span></span></span>
    </p>
    <p class="main_area_bdrnone payment-mode-select">
        <span class="ttxtnowidthnormal_default"></span><span class="ttxtnowidthnormal_default">
            <span class="titletextlarge_default">Refund Method:</span> <span class="ttxtnowidthnormal_default">
                <asp:DropDownList ID="PaymentModeCombo" runat="server" CssClass="inputf_def payment-mode-combo"
                    Width="150px">
                </asp:DropDownList>
            </span></span>
    </p>
    <div class="main_area_bdrnone details-div" style="display: none">
        <div class="orngheadtxt16_common">
            Refund Details</div>
    </div>
    <div class="main_area_bdrnone">
        <div class="ttxtnowidthnormal_default" style="float: left;">
            <div style="float: left">
                <div id="NewCreditCardDiv" runat="server" style="display: none; float: left; width: 680px;">
                    <p class="ccdiv_common">
                        <span class="titletxt_popup_pd">Credit Card Type<span class="reqiredmark"><sup>*</sup></span>:</span>
                        <span class="inputconleft_popup_pd">
                            <asp:DropDownList runat="server" ID="CreditCardTypeDropDown" Width="140px" CssClass="inputf_def">
                            </asp:DropDownList>
                        </span><span class="titletxt_popup_pd">Credit Card No<span class="reqiredmark"><sup>*</sup></span>:</span>
                        <span class="inputconright_popup_pd">
                            <asp:TextBox ID="CreditCardNumberText" MaxLength="16" runat="server" CssClass="inputf_def numeric"
                                Width="130px"></asp:TextBox></span>
                    </p>
                    <p class="ccdiv_common">
                        <span class="titletxt_popup_pd">Expiration Date<span class="reqiredmark"><sup>*</sup></span>:</span>
                        <span class="inputconleft_popup_pd">
                            <asp:TextBox ID="CreditCardExpirationDateText" runat="server" CssClass="inputf_def"
                                Width="105px"></asp:TextBox>
                        </span><span class="titletxt_popup_pd">Security No<span class="reqiredmark"><sup>*</sup></span>:</span>
                        <span class="inputconright_popup_pd">
                            <asp:TextBox ID="CreditCardSecurityNumberText" MaxLength="4" TextMode="Password"
                                runat="server" CssClass="inputf_def numeric" Width="80px"></asp:TextBox></span>
                    </p>
                    <p class="ccdiv_common">
                        <span class="titletxt_popup_pd">Card Holder<span class="reqiredmark"><sup>*</sup></span>:</span>
                        <span class="inputconleft_popup_pd">
                            <asp:TextBox ID="CreditCardHolderNameText" runat="server" CssClass="inputf_def" Width="105px"></asp:TextBox>
                        </span>
                    </p>
                    <div id="divBillingOption" style="height: 200px; float: left;">
                        <div class="flinerowbg_ccrep" style="width: 530px; float: left;">
                            <p class="contentrow_pw" style="width: 520px; float: left;">
                                <span class="titletextblueboldpopup_ccrep">Is Billing Address same as Contact Address?</span>
                                <span class="radiatxtbox2_popup_pd">
                                    <asp:RadioButton ID="BillingAddressSameRadio" onClick="NavigateBillingAddress('Yes');"
                                        runat="server" GroupName="BillingAddress" />
                                    YES</span> <span class="radiatxtbox2_popup_pd">
                                        <asp:RadioButton ID="BillingAddressDifferentRadio" onClick="NavigateBillingAddress('No');"
                                            runat="server" GroupName="BillingAddress" />
                                        NO</span>
                            </p>
                        </div>
                        <p class="ccdiv_common">
                            <span class="titletxt_popup_pd">Address1<span class="reqiredmark"><sup>*</sup></span>:</span>
                            <span class="inputconleft_popup_pd">
                                <asp:TextBox ID="Address1Text" runat="server" CssClass="inputf_def" Width="135px"></asp:TextBox></span>
                        </p>
                        <p class="ccdiv_common">
                            <span class="titletxt_popup_pd">Country<span class="reqiredmark"><sup>*</sup></span>:</span>
                            <span class="inputconleft_popup_pd">
                                <asp:DropDownList ID="CountryDropDown" runat="server" Width="140px" CssClass="inputf_def">
                                </asp:DropDownList>
                            </span>
                        </p>
                        <p class="ccdiv_common">
                            <span class="titletxt_popup_pd">State<span class="reqiredmark"><sup>*</sup></span>:</span>
                            <span class="inputconleft_popup_pd">
                                <asp:DropDownList runat="server" ID="StateDropDown" Width="140px" CssClass="inputf_def ddl-states">
                                </asp:DropDownList>
                            </span>
                        </p>
                        <p class="ccdiv_common">
                            <span class="titletxt_popup_pd">City<span class="reqiredmark"><sup>*</sup></span>:</span>
                            <span class="inputconleft_popup_pd">
                                <asp:TextBox runat="server" ID="CityText" Width="100px" CssClass="inputf_def auto-search-city">
                                </asp:TextBox>
                            </span>
                        </p>
                        <p class="ccdiv_common">
                            <span class="titletxt_popup_pd">Zip<span class="reqiredmark"><sup>*</sup></span>:</span>
                            <span class="inputconleft_popup_pd">
                                <asp:TextBox ID="ZipText" runat="server" CssClass="inputf_def numeric" Width="70px"></asp:TextBox></span>
                        </p>
                    </div>
                </div>
                <div id="ExistingCreditCardDiv" runat="server" style="display: none; float: left;
                    width: 680px;">
                    <p class="ccdiv_common">
                        <span class="titletxt_popup_pd"><b>Credit Card Type:</b></span>
                        <asp:Label ID="CreditCardTypeLabel" runat="server" CssClass="inputconleft_popup_pd" />
                        <span class="titletxt_popup_pd"><b>Credit Card No:</b></span>
                        <asp:Label ID="CreditCardNumberLabel" runat="server" CssClass="inputconleft_popup_pd" />
                    </p>
                    <p class="ccdiv_common">
                        <span class="titletxt_popup_pd"><b>Expiration Date:</b></span>
                        <asp:Label ID="ExpirationDateLabel" runat="server" CssClass="inputconleft_popup_pd" />
                    </p>
                    <p class="ccdiv_common">
                        <span class="titletxt_popup_pd"><b>Card Holder:</b></span>
                        <asp:Label ID="CreditCardHolderName" runat="server" CssClass="inputconleft_popup_pd" />
                    </p>
                </div>
                <div id="ChequeDiv" runat="server" style="display: none; height: 150px; float: left;
                    width: 680px;">
                    <p class="ccdiv_common">
                        <span class="titletxt_popup_pd">Bank Name:</span> <span class="inputconleft_popup_pd">
                            <asp:TextBox ID="BankNameText" runat="server" CssClass="inputf_def" Width="100px"></asp:TextBox></span>
                        <span class="titletxt1_regcust">A/C Holder:</span> <span class="inputconright_popup_pd">
                            <asp:TextBox ID="AccountHolderNameText" runat="server" CssClass="inputf_def" Width="100px"></asp:TextBox></span>
                    </p>
                    <p class="ccdiv_common">
                        <span class="titletxt_popup_pd">Type of Account:</span> <span class="inputconleft_popup_pd">
                            <asp:DropDownList runat="server" ID="AccountTypeCombo" Width="110px" CssClass="inputf_def">
                            </asp:DropDownList>
                        </span><span class="titletxt1_regcust">Account No:</span> <span class="inputconright_popup_pd">
                            <asp:TextBox ID="AccountNumberText" runat="server" CssClass="inputf_def numeric"
                                Width="130px"></asp:TextBox></span>
                    </p>
                    <p class="ccdiv_common">
                        <span class="titletxt_popup_pd">Routing No:</span> <span class="inputconleft_popup_pd">
                            <asp:TextBox runat="server" ID="RoutingNumberText" Width="110px" CssClass="inputf_def numeric">
                            </asp:TextBox>
                        </span><span class="titletxt1_regcust">Check No<span class="reqiredmark"><sup>*</sup></span>:</span>
                        <span class="inputconright_popup_pd">
                            <asp:TextBox ID="ChequeNumberText" runat="server" CssClass="inputf_def numeric" Width="130px"></asp:TextBox></span>
                    </p>                    
                </div>
                <div id="CashDiv" runat="server" style="display: none; height: 150px; float: left;
                    width: 680px;">
                    <label>
                        Amount to be refunded:</label>
                    <span id="CashSpan"></span>
                </div>
            </div>
        </div>
    </div>
    <div class="main_area_bdrnone" style="display: none;" id="RefundRequestDiv">
        <div style="float: left;">
            <div class="pgnosymbolvsmall_common">
                <img src="/App/Images/page3symbolvsmall.gif" /></div>
            <div class="orngheadtxt16_common">
                Refund Requests
            </div>
        </div>
        <div id="RefundRequestContentDiv" style="clear: both; float: left;">
            <img src="/App/Images/indicator.gif" alt="" />
            Loading Request Window
        </div>
    </div>
    <div class="main_area_bdrnone list-options">
        <div class="rgt">
            <span class="buttoncon4_default" style="width: 120px"><span id="spansave">
                <asp:Button ID="SaveButton" Text="Cancel Shipping" runat="server" Width="120px" OnClick="SaveButton_Click"
                    OnClientClick="return BulkCancel()" CssClass="button" />
            </span><span style="visibility: hidden; display: none;" id="spnIndicator">
                <img src="/App/Images/indicator.gif" alt="" /></span> </span><span class="buttoncon_default">
                    <asp:Button ID="CancelButton" Text="Back" runat="server" CssClass="button" OnClick="CancelButton_Click" /></span>
        </div>
    </div>
    <div class="left" style="margin-top: 20px">
        <div class="divnoitemfound_custdbrd" id="dvNoQueueItemFound" runat="server">
            <p class="divnoitemtxt_custdbrd">
                <span class="orngbold18_default">No Record Found!</span>
            </p>
        </div>
    </div>
    <div>
        <script language="javascript" type="text/javascript">
            $(document).ready(function () {

                $('.numeric').numeric();
                $('.jTip').cluetip({ splitTitle: '|', cursor: 'pointer', tracking: true, cluetipClass: 'jtip', arrows: true, dropShadow: false, hoverIntent: false });

                $('#<%= BillingAddressSameRadio.ClientID %>').attr('checked', true);
                $('#<%= BillingAddressSameRadio.ClientID %>').click();

                if ($(".select-table tbody :checkbox").filter(':checked').length < 1) {
                    $(".list-options").addClass("disabled");
                    //SetTotalPaymentAmount();
                    $('.payment-mode-select').hide();
                }
                else {
                    $(".list-options").removeClass("disabled");
                    SetTotalPaymentAmount();
                }

                $(".select-table tbody tr :checkbox").click(function () {

                    if ($(this).is(':checked')) {
                        if (!$(this).parent().hasClass('not-clickable'))
                            $(this).attr("checked", true);
                        $(".list-options").removeClass("disabled");
                        SetTotalPaymentAmount();
                    } else {
                        $(this).attr("checked", false);
                        $(".check-all :checkbox").attr("checked", false);
                        if ($(".select-table tbody :checkbox").filter(':checked').length < 1)
                            $(".list-options").addClass("disabled");
                        SetTotalPaymentAmount();
                    }
                });

                $(".check-all :checkbox").click(function () {

                    if ($(this).is(':checked')) {
                        $(".select-table tbody :checkbox").each(function () {
                            if (!$(this).parent().hasClass('not-clickable'))
                                $(this).attr("checked", true);
                        });
                        $(".list-options").removeClass("disabled");
                        SetTotalPaymentAmount();
                    } else {
                        $(".select-table tbody :checkbox").attr("checked", false);
                        $(".list-options").addClass("disabled");
                        SetTotalPaymentAmount();
                    }
                });

                $('.payment-mode-combo').change(function () {
                    HideAllPaymentOptionDivs();
                    ClearPaymentOptionControls();
                    if ($('.payment-mode-combo option:selected').val() == '0')
                        return;

                    $('.details-div').show();

                    var selectedPaymentMode = $('.payment-mode-combo option:selected').text();

                    if (selectedPaymentMode == 'Credit Card')
                        $('#<%= NewCreditCardDiv.ClientID %>').show();

                    if (selectedPaymentMode == 'Check')
                        $('#<%= ChequeDiv.ClientID %>').show();

                    if (selectedPaymentMode == 'Credit Card on File')
                        $('#<%= ExistingCreditCardDiv.ClientID %>').show();

                    if (selectedPaymentMode == 'Cash') {
                        $('.details-div').hide();

                        $('#<%= CashDiv.ClientID %>').hide();
                        var totalRefundAmount = 0.00;
                        $(".select-table tbody tr").each(function () {
                            if ($(this).find('.chk-select :checkbox').attr('checked')) {
                                totalRefundAmount += parseFloat($(this).find('.price-label').text());
                            }
                        });
                        $('#CashSpan').text(FormatAmount(totalRefundAmount).toFixed(2));
                    }
                });
            });

            function SetTotalPaymentAmount() {//debugger;
                var totalRefundAmount = 0.00;
                $(".select-table tbody tr").each(function () {
                    if ($(this).find('.chk-select :checkbox').attr('checked')) {
                        totalRefundAmount += parseFloat($(this).find('.price-label').text());
                    }
                });

                $("#RefundRequestDiv").hide();
                $("#RefundRequestContentDiv").empty();
                //debugger;    
                totalRefundAmount = FormatAmount(totalRefundAmount.toFixed(2));
                var amountPaid = FormatAmount('<%= AmountPaid %>');
                var discountedTotal = FormatAmount('<%= DiscountedTotal %>');

                if (amountPaid < (discountedTotal - totalRefundAmount)) {
                    totalRefundAmount = 0;
                }
                else {
                    totalRefundAmount = amountPaid - (discountedTotal - totalRefundAmount);
                }

                var refundRequestAmount = $('#<%= RefundRequestAmount.ClientID%>').val();
                totalRefundAmount = totalRefundAmount - refundRequestAmount;

                if (totalRefundAmount > 0.00) {
                    if ('<%= IoC.Resolve<ISettings>().IsRefundQueueEnabled %>' == '<%= bool.TrueString %>') {
                        isRefund = true;
                        LoadUiforRefundRequest(totalRefundAmount);
                        $('.payment-mode-select').hide();
                        HideAllPaymentOptionDivs();
                    }
                    else {
                        $('.payment-amount').show();
                        $('#RefundAmount').text(totalRefundAmount);
                        $('.payment-mode-select').show();
                    }
                }
                else {
                    $('.payment-amount').hide();
                    $('#RefundAmount').text('');
                    $('.payment-mode-select').hide();
                    HideAllPaymentOptionDivs();
                }
            }

            function BulkCancel() {//debugger;
                if ($(".list-options").filter('.disabled').length > 0) {
                    alert('Please select atleast one shipping option to cancel.');
                    return false;
                }
                if ($('.payment-mode-select').is(':visible') && $('.payment-mode-combo option:selected').val() == '0') {
                    alert('Please select a refund method.');
                    return false;
                }
                if (ValidatePaymentData() == true) {
                    document.getElementById("spansave").style.display = 'none';
                    document.getElementById("spnIndicator").style.visibility = 'visible';
                    document.getElementById("spnIndicator").style.display = 'block';
                    return true;
                }
                return false;
            }

            function HideAllPaymentOptionDivs() {
                $('.details-div').hide();
                $('#<%= NewCreditCardDiv.ClientID %>').hide();
                $('#<%= ExistingCreditCardDiv.ClientID %>').hide();
                $('#<%= ChequeDiv.ClientID %>').hide();
                $('#<%= CashDiv.ClientID %>').hide();
            }

            function ClearPaymentOptionControls() {
                $("#<%= CreditCardTypeCombo.ClientID %>").val('0');
                $("#<%= CreditCardNumberText.ClientID %>").val('');
                $("#<%= CreditCardExpirationDateText.ClientID %>").val('');
                $("#<%= CreditCardSecurityNumberText.ClientID %>").val('');
                $("#<%= CreditCardHolderNameText.ClientID %>").val('');
                $('#<%= ChequeNumberText.ClientID %>').val('');
                $('#<%= BankNameText.ClientID %>').val('');
                $('#<%= AccountHolderNameText.ClientID %>').val('');
                $('#<%= AccountTypeCombo.ClientID %>').val('0');
                $('#<%= AccountNumberText.ClientID %>').val('');
                $('#<%= RoutingNumberText.ClientID %>').val('');
                $('#CashSpan').text('');
            }

            function NavigateBillingAddress(selectionChoice) {
                if (selectionChoice == 'Yes') {
                    $('#<%= Address1Text.ClientID %>').attr('disabled', 'disabled');
                    $('#<%= CityText.ClientID %>').attr('disabled', 'disabled');
                    $('#<%= ZipText.ClientID %>').attr('disabled', 'disabled');
                    $('#<%= CountryDropDown.ClientID %>').attr('disabled', 'disabled');
                    $('#<%= StateDropDown.ClientID %>').attr('disabled', 'disabled');
                    $('#<%= Address1Text.ClientID %>').val($('#<%= Address1Hidden.ClientID %>').val());
                    $('#<%= CityText.ClientID %>').val($('#<%= CityHidden.ClientID %>').val());
                    $('#<%= ZipText.ClientID %>').val($('#<%= ZipHidden.ClientID %>').val());
                    $('#<%= CountryDropDown.ClientID %>').val($('#<%= CountryIdHidden.ClientID %>').val());
                    $('#<%= StateDropDown.ClientID %>').val($('#<%= StateIdHidden.ClientID %>').val());
                }
                else {
                    $('#<%= Address1Text.ClientID %>').attr('disabled', '');
                    $('#<%= CityText.ClientID %>').attr('disabled', '');
                    $('#<%= ZipText.ClientID %>').attr('disabled', '');
                    $('#<%= CountryDropDown.ClientID %>').attr('disabled', '');
                    $('#<%= StateDropDown.ClientID %>').attr('disabled', '');
                }
            }

        </script>
        <input type="hidden" runat="server" id="RefundRequestAmount" value="0.00" />
        <input type="hidden" runat="server" id="TotalPaymentAmount" value="0.00" />
        <input type="hidden" runat="server" id="DiscountedTotalAmount" value="0.00" />
        <script language="javascript" type="text/javascript">
            var isRefund = false;

            function LoadUiforRefundRequest(amount) {//debugger;                

                $.ajax({ type: "GET",
                    cache: false,
                    dataType: "html", url: "/Finance/RefundRequest/Create?orderId=<%= OrderId %>&amount=" + amount + "&requestType=<%= (int)RefundRequestType.CancelShipping %>", data: '{}',
                    success: function (result) {

                        $("#RefundRequestDiv").show();
                        $("#RefundRequestContentDiv").empty();
                        $("#RefundRequestContentDiv").append(result);
                    },
                    error: function (a, b, c) { $("#RefundRequestDiv").hide(); alert('Some error loading the Request window. Please try opening the page again'); }
                });

            } 
    
        </script>
        <script type="text/javascript" language="javascript">

            function FormatAmount(amount) {
                if (isNaN(parseFloat(amount))) {
                    num = '0.00';
                }
                return parseFloat(amount);
                try {
                    amount = amount.replace(/^\s+|\s+$/g, "");
                }
                catch (err) {
                    amount = amount
                }

                amount = parseFloat(amount);
                if (isNaN(amount)) {
                    num = '0.00';
                }

                return parseFloat(amount.toFixed(2));
            }

            function ValidatePaymentData() {
                if (isRefund) return true;

                if ($('.payment-mode-select').is(':visible') == false) return true;

                var selectedPaymentMode = $('.payment-mode-combo option:selected').text();

                if (selectedPaymentMode == 'Credit Card') {
                    var ddlCCType = document.getElementById("<%= CreditCardTypeCombo.ClientID %>");
                    var txtCCNo = document.getElementById("<%= CreditCardNumberText.ClientID %>");
                    var txtExpirationDate = document.getElementById("<%= CreditCardExpirationDateText.ClientID %>");
                    var txtSecurityNo = document.getElementById("<%= CreditCardSecurityNumberText.ClientID %>");
                    var txtCName = document.getElementById("<%= CreditCardHolderNameText.ClientID %>");

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
                    if (!CheckCCExpiryDate(txtExpirationDate, "Credit Card"))
                        return false;
                    if (isBlank(txtSecurityNo, "Sequrity Number"))
                        return false;


                    var txtAddress1 = document.getElementById("<%= Address1Text.ClientID %>");
                    var txtCity = document.getElementById("<%= CityText.ClientID %>");
                    var ddlState = document.getElementById("<%= StateDropDown.ClientID %>");
                    var ddlCountry = document.getElementById("<%= CountryDropDown.ClientID %>");
                    var txtZip = document.getElementById("<%= ZipText.ClientID %>");

                    if (isBlank(txtAddress1, "Address")) { return false; }
                    if (checkLength(txtAddress1, 500, "Address")) { return false; }
                    if (checkDropDown(ddlCountry, "Country for  Address") == false) { return false; }
                    if (checkDropDown(ddlState, "State for  Address") == false) { return false; }
                    if (isBlank(txtCity, "City for  Address")) { return false; }
                    if (isInteger(txtZip, "Zip") != true) { return false; }
                }

                if (selectedPaymentMode == 'Check') {
                    if (isBlank(document.getElementById('<%= ChequeNumberText.ClientID %>'), "Check Number")) { return false; }                    
                }

                return true;
            }
                
        </script>
    </div>
</div>
