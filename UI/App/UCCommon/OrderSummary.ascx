<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrderSummary.ascx.cs"
    Inherits="Falcon.App.UI.App.UCCommon.OrderSummary" %>
<%@ Register Src="JQueryToolkit.ascx" TagName="JQueryToolkit" TagPrefix="JQueryControl" %>
<JQueryControl:JQueryToolkit ID="_jQueryToolkit1" runat="server" IncludeJQueryUI="true"
    IncludeJTemplate="true" IncudeJQueryJTip="true" />
<style type="text/css">
    .ordersummary {
        font: 12px Arial, Helvetica, sans-serif;
        color: #000;
    }

        .ordersummary .hd {
            padding-left: 8px;
            margin: 0px;
            background: url(/App/Images/shoppingcart_orngcorners.gif) no-repeat;
            height: 34px;
        }

            .ordersummary .hd div {
                padding: 0px 10px 0px 2px;
                margin: 0px;
                background: #e1eaf3 url(/App/Images/shoppingcart_orngcorners.gif) no-repeat right -36px;
                height: 34px;
                color: #F37C00;
                font: 13px Arial, Helvetica, sans-serif;
                font-weight: bold;
                line-height: 34px;
            }

        .ordersummary .discription {
            border: 1px solid #ccc;
            padding: 8px;
            background: #fff;
        }

    .packagesummary {
        margin-top: 10px;
    }

    .paymentsummary {
        margin-top: 10px;
        text-align: right;
    }

    .productname {
        width: 100px;
        float: left;
    }

    .rates {
        color: #F00;
        float: right;
        width: auto;
    }

    .topbtm_bdr {
        border-top: 1px dashed #ccc;
        border-bottom: 1px dashed #ccc;
        width: 100%;
        float: left;
        padding: 5px 0px;
        margin: 5px 0px;
    }

    .sourcecode_hd {
        font: 13px Arial, Helvetica, sans-serif;
        color: #F60;
        font-weight: bold;
    }

    .remove_button {
        margin: 0px;
        width: auto;
        padding: 3px 5px;
        background: #fe912a;
        color: #fff;
        font: 12px Verdana, Geneva, sans-serif;
        font-weight: bold;
        overflow: visible;
    }
</style>
<div class="ordersummary order-summary">
    <div class="hd">
        <div>
            My Order Summary
        </div>
    </div>
    <div class="discription">
        <div class="locationsummary">
            <div>
                <p style="margin: 0px; font: 12px arial;">
                    <strong>My Screening Location</strong>
                </p>
                <div style="padding-left: 5px;">
                    <asp:Label ID="EventNameLabel" runat="server" /><br />
                    <asp:Label ID="EventAddressLabel" runat="server" />
                </div>
            </div>
        </div>
        <div class="packagesummary">
            <p style="margin: 0px; font: 12px arial;">
                <strong>My Screening Date</strong>
            </p>
            <div style="padding-left: 5px;">
                <asp:Label ID="EventDateLabel" runat="server" /><br />
            </div>
        </div>
        <div class="packagesummary" id="SponsoredInfoDiv" runat="server" visible="false">
            <p style="margin: 0px; font: 12px arial;">
                <strong>Sponsored By</strong>
            </p>
            <div style="padding-left: 5px;">
                <asp:Label ID="HospitalPartnerLabel" runat="server" /><br />
            </div>
        </div>
        <div id="AppointmentSummaryDiv" style="display: none">
            <div class="packagesummary">
                <p style="margin: 0px; font: 12px arial;">
                    <strong>My Screening Appointment:</strong>&nbsp;<span id="AppointmentTimeSpan"></span>
                </p>
                <div style="margin: 0px 0px 0px 5px;">
                </div>
            </div>
        </div>
        <div class="packagesummary">
            <p style="margin: 0px; font: 12px arial;">
                <strong>My Screening Package</strong>
            </p>
            <div>
                <div id="ViewSelectedPackageAndTests" style="padding-left: 5px;">
                    <p style="margin-bottom: 10px;">
                        No Items Selected.
                    </p>
                </div>
            </div>
        </div>
        <div id="ProductSummaryDiv" style="display: none">
            <div class="packagesummary">
                <p style="margin: 0px; font: 12px arial;">
                    <span style="color: #f39814; width: auto; float: right;">$<span id="ProductPriceSpan"
                        style="color: #f39814;"> </span></span><strong>My Result PDF Option:</strong>&nbsp;<span
                            id="ProductNameSpan"></span>
                </p>
            </div>
        </div>
        <div id="FulfillmentOptionSummaryDiv" style="display: none">
            <div class="packagesummary">
                <p style="margin: 0px; font: 12px arial;">
                    <span style="color: #f39814; width: auto; float: right;">$<span id="FulfillmentOptionPriceSpan"
                        style="color: #f39814;"> </span></span><strong>My Screening Fulfillment Option:</strong>&nbsp;<br />
                    <span
                        id="FulfillmentOptionSpan"></span>
                </p>
            </div>
        </div>
        <div id="PackageSummaryDiv" style="display: none">
            <div class="paymentsummary">
                <div>
                    <label>
                        <strong>Retail Price :</strong></label>
                    <span style="color: #f39814;">$</span> <span id="RetailPriceSpan" style="color: #f39814;"></span>
                    <br />
                    <label>
                        <strong>You Saved :</strong></label>
                    <span style="color: #f39814;">$</span> <span id="SavingAmountSpan" style="color: #f39814;"></span>
                    <br />
                    <div id="SourceCodeAmountDiv" style="display: none; float: right; text-align: right;">
                        <span style="float: left">
                            <strong>Source Code [<span id="SorceCodeSpan"><%=SourceCode %></span>] :</strong></span>
                        <span style="float: left; color: #f39814;">(-)$</span> <span id="SourceCodeAmountSpan" style="color: #f39814; float: left;"></span>
                    </div>
                    <br />
                    <label>
                        <strong>Total Amount:</strong></label>
                    <strong><span style="color: #ff6600;">$</span> <span id="OfferPriceSpan" style="color: #ff6600;"></span></strong>
                </div>
            </div>
        </div>
    </div>
</div>

<script type="text/javascript" language="javascript">

    $.ajaxSetup({ cache: false });

    var eventId = '<%=EventId %>';
	var roleId = '<%=RoleId %>';
    var eventType = '<%=EventType %>';
    var retailPrice = 0.00;
    var savings = 0.00;
    var appointmentTime = '<%=AppointmentTime %>';
	var shippingOption = '<%=ShippingOption %>';
    var shippingOptionPrice = parseFloat('<%=ShippingOptionPrice %>');
    var isSourceCodeApplied = '<%=IsSourceCodeApplied %>' == 'False' ? false : true;
    //var SourceCode = '<%=SourceCode %>';
    var sourceCodeAmount = parseFloat('<%=SourceCodeAmount %>');
    var isGiftCertificate = '<%=IsGiftCertificate %>' == 'False' ? false : true;
    var isFulfillmentOptionPurchase = '<%=IsFulfillmentOptionPurchase %>' == 'False' ? false : true;
    var isPurchaseImageOption = '<%=IsPurchaseImageOption %>' == 'False' ? false : true;

    var productOption = '<%=ProductName %>';
    var productOptionPrice = parseFloat('<%= ProductPrice %>');

    $(function () {
        if (!isGiftCertificate && !isFulfillmentOptionPurchase && !isPurchaseImageOption) {
            var selectedPackage = selectedPackages != null && selectedPackages.length > 0 ? selectedPackages[0] : null;
            var selectedTemplateViewData = CreateSelectedOrderTemplateData(selectedPackage, selectedPackageTests, selectedAddOnTests);
            BindSelectedOrderTemplate(selectedTemplateViewData);
            DisableControls();
            CalculateAndSetPrice(selectedPackage, selectedPackageTests, selectedAddOnTests);
            if (appointmentTime != null && appointmentTime.length > 0) SetAppointmentTime(appointmentTime);
            if (shippingOption != null && shippingOption.length > 0) SetFulfillmentOption(shippingOption, shippingOptionPrice);
            if (isSourceCodeApplied) SetSourceCodeDiscount(sourceCodeAmount);
            if (productOption != null && productOption.length > 0) SetProduct(productOption, productOptionPrice.toFixed(2), true);
        }
    });

    function DisableControls() {
        $('.my-order-package-select').hide();
        $('.my-order-independent-test-select').hide();
        $('.my-order-package-test-select').hide();
        $('#RemoveSelectedButton').hide();
    }

</script>

<script type="text/javascript" language="javascript">

    function CreateSelectedOrderTemplateData(selectedPackage, selectedPackageTests, selectedAddOnTests) {
        var selectedTemplateViewData = { "Package": { "PackageId": 0, "PackageName": '', "OfferPrice": parseFloat(0) }, "PackageTests": new Array(), "AddOnTests": new Array() };
        if (selectedPackage != null) {
            selectedTemplateViewData.Package = { "PackageId": 0, "PackageName": '', "OfferPrice": parseFloat(0) };
            selectedTemplateViewData.Package.PackageId = 0;
            selectedTemplateViewData.Package.PackageName = selectedPackage.Name;
            selectedTemplateViewData.Package.OfferPrice = parseFloat(selectedPackage.Price);
        }
        else selectedTemplateViewData.Package = null;

        if (selectedPackageTests != null && selectedPackageTests.length > 0) {
            $.each(selectedPackageTests, function () {
                var packageTest = { "TestId": 0, "TestName": '', "TestDescription": 'INCLUDED', "RetailPrice": parseFloat(0), "OfferPrice": parseFloat(0) };
                packageTest.TestId = 0;
                packageTest.TestName = this.Name;
                packageTest.RetailPrice = parseFloat(this.Price);
                packageTest.OfferPrice = parseFloat(this.PackagePrice);
                selectedTemplateViewData.PackageTests.push(packageTest);
            });
        }

        if (selectedAddOnTests != null && selectedAddOnTests.length > 0) {
            $.each(selectedAddOnTests, function () {
                var addOnTest = { "TestId": 0, "TestName": '', "RetailPrice": parseFloat(0), "OfferPrice": parseFloat(0) };
                addOnTest.TestId = 0;
                addOnTest.TestName = this.Name;
                if (selectedPackage != null) {
                    addOnTest.RetailPrice = parseFloat(this.WithPackagePrice);
                    addOnTest.OfferPrice = parseFloat(this.WithPackagePrice);
                }
                else {
                    addOnTest.RetailPrice = parseFloat(this.Price);
                    addOnTest.OfferPrice = parseFloat(this.Price);
                }
                selectedTemplateViewData.AddOnTests.push(addOnTest);
            });
        }

        return selectedTemplateViewData;
    }

    function BindSelectedOrderTemplate(selectedTemplateViewData) {
        var viewSelectedPackageAndTests = $('#ViewSelectedPackageAndTests');
        viewSelectedPackageAndTests.setTemplateURL('<%= ResolveUrl("~/App/Templates/SelectedOrder.html") %>');

	    if (selectedTemplateViewData.Package != null || (selectedTemplateViewData.AddOnTests != null && selectedTemplateViewData.AddOnTests.length > 0)) {
	        var selectedTemplateViewDataArray = new Array();
	        selectedTemplateViewDataArray.push(selectedTemplateViewData);
	        viewSelectedPackageAndTests.processTemplate(selectedTemplateViewDataArray);
	    }
	    else
	        viewSelectedPackageAndTests.html('<p>No Items Selected.</p>');
    }

</script>

<script type="text/javascript" language="javascript">

    function CalculateAndSetPrice(selectedPackage, selectedPackageTests, selectedAddOnTests) {//debugger;
        var offerPrice = 0.00;
        if (selectedPackage != null && selectedPackageTests != null && selectedPackageTests.length > 0) {
            offerPrice += selectedPackage.Price;
            $.each(selectedPackageTests, function () {
                retailPrice += this.Price;
            });
        }

        if (selectedAddOnTests != null && selectedAddOnTests.length > 0) {
            $.each(selectedAddOnTests, function () {
                if (selectedPackage != null) {
                    retailPrice += this.WithPackagePrice;
                    offerPrice += this.WithPackagePrice;
                }
                else {
                    retailPrice += this.Price;
                    offerPrice += this.Price;
                }
            });
        }
        savings = retailPrice - offerPrice;

        if (retailPrice > 0.00 && retailPrice > offerPrice ) {
            $('#RetailPriceSpan').text(retailPrice.toFixed(2));
            $('#SavingAmountSpan').text(savings.toFixed(2));
            $('#OfferPriceSpan').text(offerPrice.toFixed(2));
            $('#PackageSummaryDiv').show();
        } else if (offerPrice > 0) {
            $('#RetailPriceSpan').text(retailPrice.toFixed(2));
            $('#SavingAmountSpan').text(0.00);
            $('#OfferPriceSpan').text(offerPrice.toFixed(2));
            $('#PackageSummaryDiv').show();
        }
        else {
            $('#RetailPriceSpan').text(0.00);
            $('#SavingAmountSpan').text(0.00);
            $('#OfferPriceSpan').text(0.00);
            $('#PackageSummaryDiv').hide();
        }
        return offerPrice;
    }

</script>

<script type="text/javascript" language="javascript">

    function ShowHideSourceCodeAmountDiv(show) {
        if (show)
            $('#SourceCodeAmountDiv').show();
        else
            $('#SourceCodeAmountDiv').hide();
    }

    function SetSourceCodeDiscount(discountAmount) {
        sourceCodeAmount = parseFloat(discountAmount);
        $('#SourceCodeAmountDiv').show();
        $('#SourceCodeAmountSpan').text(parseFloat(discountAmount).toFixed(2));
        AdjustOrderPrice(sourceCodeAmount, shippingOptionPrice, productOptionPrice);
    }

    function SetSourceCodeDetail(discountAmount, sourcecode) {
        sourceCodeAmount = parseFloat(discountAmount);
        $('#SourceCodeAmountDiv').show();
        $('#SourceCodeAmountSpan').text(parseFloat(discountAmount).toFixed(2));
        $('#SorceCodeSpan').text(sourcecode);
        AdjustOrderPrice(sourceCodeAmount, shippingOptionPrice, productOptionPrice);
    }

    function SetAppointmentTime(appointmentTime) {
        if (appointmentTime == '0') {
            $('#AppointmentSummaryDiv').hide();
            $('#AppointmentTimeSpan').html('');
            return;
        }
        $('#AppointmentSummaryDiv').show();
        $('#AppointmentTimeSpan').html(appointmentTime);
    }


    function SetFulfillmentOption(fulfillmentOption, fulfillmentPrice) {
        shippingOptionPrice = parseFloat(fulfillmentPrice);
        $('#FulfillmentOptionSummaryDiv').show();
        $('#FulfillmentOptionSpan').html(fulfillmentOption);
        $('#FulfillmentOptionPriceSpan').html(fulfillmentPrice);
        AdjustOrderPrice(sourceCodeAmount, shippingOptionPrice, productOptionPrice);
    }

    function SetProduct(productName, productPrice, isVisible) {
        productOptionPrice = parseFloat(productPrice);
        if (isVisible)
            $('#ProductSummaryDiv').show();
        else
            $('#ProductSummaryDiv').hide();
        $('#ProductNameSpan').html(productName);
        $('#ProductPriceSpan').html(productPrice);
        AdjustOrderPrice(sourceCodeAmount, shippingOptionPrice, productOptionPrice);
    }
    function AdjustOrderPrice(discountAmount, fulfillmentPrice, productPrice) {
        var offerPrice = (((parseFloat(retailPrice) + parseFloat(productPrice) + parseFloat(fulfillmentPrice)) - parseFloat(savings)) - parseFloat(discountAmount)).toFixed(2);
        $('#RetailPriceSpan').text(parseFloat(retailPrice + shippingOptionPrice).toFixed(2))
        $('#OfferPriceSpan').text(offerPrice);
    }

    $(document).ready(function () {
        var decoded = $("<textarea/>").html($("#<%=EventAddressLabel.ClientID %>").html()).text();
	    $("#<%=EventAddressLabel.ClientID %>").html(decoded);
	});

</script>

