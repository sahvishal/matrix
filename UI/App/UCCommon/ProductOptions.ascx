<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductOptions.ascx.cs" Inherits="Falcon.App.UI.App.UCCommon.ProductOptions" %>
<%@ Register Src="JQueryToolkit.ascx" TagName="JQueryToolkit" TagPrefix="JQueryControl" %>
<JQueryControl:JQueryToolkit ID="JQueryToolkit" runat="server" IncudeJQueryJTip="true" IncludeJTemplate="true" />
<%@ Import Namespace="Falcon.App.Core.Enum" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript">
    $(document).ready(function () {
        $('.productJTip').cluetip({ splitTitle: '|', cursor: 'pointer', tracking: true, cluetipClass: 'jtip', arrows: true, dropShadow: false, hoverIntent: false });
    });

</script>
<script language="javascript" type="text/javascript">

    function ShowHideProduct() {//debugger;
        if ($('#<%= ProductCheckbox.ClientID %>').attr('checked')) {

            $('#ProductDiv').show();
            $('.main-product-table').find('.main-product-table-row input:radio:first').attr('checked', true);
            $('.main-product-table').find('.main-product-table-row input:radio:first').click();
        }
        else {
            $('#ProductDiv').hide();
            SetProduct('', 0, false);
            $('#<%= hfProfuctID.ClientID %>').val(0);
            $('#<%= hfProductPrice.ClientID %>').val(0);
            $('#<%= hfProductName.ClientID %>').val('');
        }
    }

    function SelectProduct(productId, productPrice, setShippingOption) {//debugger;
        $('#ProductDiv').show();
        $('#<%= ProductCheckbox.ClientID %>').attr('checked', true);
        $('#rbtnProduct' + productId).attr('checked', true);

        productPrice = parseFloat(productPrice);
        var productName = $('#spProductTitle' + productId).html();

        $('#<%= hfProfuctID.ClientID %>').val(productId);
        $('#<%= hfProductPrice.ClientID %>').val(productPrice);
        $('#<%= hfProductName.ClientID %>').val(productName);
        
        SetProduct(productName, productPrice, true);
    }
</script>
<script type="text/javascript" language="javascript">

    $.ajaxSetup({ cache: false });

    //    $(function () {

    //        AttachDialogBoxes();
    //    });

    function AttachDialogBoxes() {

        $('#AddCDDialogDiv').dialog({ autoOpen: false, hide: 'slide', width: 550, height: 250, modal: true, buttons: { 'No Thanks': function () { NoThanksForCDClick(); } }, close: function () { AddCDDialogClosing(); } });
    }

    var callBackValidationMethod = null;
    function AddCDDialogClosing() {
        if (callBackValidationMethod != null)
            callBackValidationMethod();
    }

    function AddCDButtonClick(selectedProductId, price) {
        //Set product details
        SelectProduct(selectedProductId, price);
        $('#AddCDDialogDiv').dialog('close');
    }

    function NoThanksForCDClick() {
        $('#AddCDDialogDiv').dialog('close');
    }
    
    function checkTestForUpsell() {
        var hasTestForUpsell = false;
        if (selectedPackageTests != null && selectedPackageTests.length > 0) {
            $.each(selectedPackageTests, function() {
                if (this.Id == parseInt('<%=(long)TestType.AAA %>') || this.Id == parseInt('<%=(long)TestType.Stroke %>') || this.Id == parseInt('<%=(long)TestType.Echocardiogram %>'))
                {
                    hasTestForUpsell = true;
                    return;
                }
            });
        }
        
        if (selectedAddOnTests != null && selectedAddOnTests.length > 0) {
            $.each(selectedAddOnTests, function() {
                if (this.Id == parseInt('<%=(long)TestType.AAA %>') || this.Id == parseInt('<%=(long)TestType.Stroke %>') || this.Id == parseInt('<%=(long)TestType.Echocardiogram %>'))
                {
                    hasTestForUpsell = true;
                    return;
                }
            });
        }
        return hasTestForUpsell;
    }

    function OpenUpsellCDDialog(validationMethod) {
        AttachDialogBoxes();
        callBackValidationMethod = validationMethod;
        var hasTestForUpsell = checkTestForUpsell();
        var isImageUpsellallowed = '<%=IsUpsellImageAllowed%>';

        if ($('#<%=ProductOptionDiv.ClientID %>').css('display') == "none" || hasTestForUpsell == false ||isImageUpsellallowed=='<%=Boolean.FalseString%>' ) {
            callBackValidationMethod();
        }
        else {
            var productId = $('#<%= hfProfuctID.ClientID %>').val();
            if (parseInt(productId)<=0) {
                var messageUrl = '<%=ResolveUrl("~/App/Controllers/ProductController.asmx/GetProductDetail")%>';
                var parameter = "{'productId':'" + "<%= UpsellProductId %>" + "'}";

                var successFunction = function (resultData) {
                    //debugger;
                    if (resultData != null && resultData.d != null) {                        
                        $('#productNameSpan').html(resultData.d.Name);
                        $('#productDescriptionSpan').html(resultData.d.ShortDescription);
                        $('#AddCDButton').val("Yes, I want " + resultData.d.Name);
                        $('#AddCDButton').bind("click", function () {
                            AddCDButtonClick(resultData.d.Id, resultData.d.Price);
                        });

                        if (!$('#AddCDDialogDiv').dialog('isOpen'))
                            $('#AddCDDialogDiv').dialog('open');
                    }
                };
                var errorFunction = function() {
                    alert('Some error occured while processing your request, please try again later.');
                };

                InvokeAsyncService(messageUrl, parameter, successFunction, errorFunction);

            }
            else
                callBackValidationMethod();
        }

    }

    function InvokeAsyncService(messageUrl, parameter, successFunction, errorFunction) {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: messageUrl,
            data: parameter,
            success: function (result) {
                successFunction(result);
            },
            error: function (a, b, c) {
                errorFunction();
            }
        });
    }
</script>
<style type="text/css">
    .wrapper_sd {
        float: left;
        width: 540px;
        padding: 3px 0 3px 0;
    }

        .wrapper_sd .hrow {
            float: left;
            width: 100%;
            padding-top: 5px;
        }

        .wrapper_sd .hrow1 {
            float: left;
            width: 100%;
            padding: 10px 5px;
        }

        .wrapper_sd .hrow .lbl {
            float: left;
            width: 105px;
            padding: 0 5px 0 10px;
        }

        .wrapper_sd .inputtxt {
            border: 1px solid #7F9DB9;
            background-color: #fff;
            z-index: -5;
            font: normal 12px arial;
            color: #333;
            padding: 2px;
            float: left;
        }

    .blutxt_sd {
        color: #009fc3;
        font-weight: bold;
    }

    .divbg_sd {
        float: left;
        width: 540px;
        padding: 5px 5px;
        background: #f8f8f8;
    }

        .divbg_sd .lbl {
            float: left;
            padding-right: 5px;
        }
</style>
<asp:HiddenField runat="server" ID="hfProfuctID" Value="0" />
<asp:HiddenField runat="server" ID="hfProductPrice" Value="0" />
<asp:HiddenField runat="server" ID="hfProductName" />
<asp:HiddenField runat="server" ID="hfUpsellProductId" Value="0" />
<div id="ProductOptionDiv" runat="server">
    <div>
        <span class="orngsmalltxt_regcust">
            <asp:CheckBox ID="ProductCheckbox" runat="server" Text="Buy Digital High Quality Images" onclick="ShowHideProduct();" />
        </span>
    </div>
    <div class="wrapper_sd" style="width: 420px; display: none;" id="ProductDiv">
        <asp:GridView ID="grdvProduct" runat="server" AutoGenerateColumns="false" ShowHeader="false"
            GridLines="None" CssClass="gridselectpackage main-product-table">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <span style="float: left; width: 40px;">
                            <input type='radio' id='rbtnProduct<%#DataBinder.Eval(Container.DataItem,"Id") %>'
                                name='ProductOption' onclick='SelectProduct("<%#DataBinder.Eval(Container.DataItem,"Id") %>    ","<%# Decimal.Round(Convert.ToDecimal(DataBinder.Eval(Container.DataItem, "Price")),2) %>    ",true)' />
                        </span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <span id="spProductTitle<%#DataBinder.Eval(Container.DataItem,"Id") %>" style="padding-right: 5px">
                            <%# DataBinder.Eval(Container.DataItem, "Name")%>
                        </span><span class="productJTip" title='Description|<%#DataBinder.Eval(Container.DataItem,"ShortDescription") %>'
                            id="spMoreInfo"><span class="smalltxtblu">[More Info]</span></span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <span style="float: left; width: 60px;"><span style="float: left; padding-right: 4px;">$</span> <span style="float: left;" id='spProductPrice<%# DataBinder.Eval(Container.DataItem, "Id")%>'>
                            <%# Decimal.Round(Convert.ToDecimal(DataBinder.Eval(Container.DataItem, "Price")),2) %></span>
                        </span>
                    </ItemTemplate>
                    <ItemStyle ForeColor="#E78839" />
                </asp:TemplateField>
            </Columns>
            <RowStyle CssClass="row2 main-product-table-row" />
        </asp:GridView>
    </div>
</div>
<div id="AddCDDialogDiv" style="display: none;" title="May We Recommend!">
    <div id="AddCDTemplateDiv" style="height: 120px; overflow: hidden;">
        <h3 class="orngbold14_default">Images of your ultrasounds is also available!</h3>
        <table class="gridselectpackage" cellspacing="0" border="0" cellpadding="5">
            <tr class="row2">
                <td>
                    <span id="productNameSpan"></span>
                    <br />
                    <span class="gridselectpackage_testname" id="productDescriptionSpan"></span>
                </td>
            </tr>
            <tr>
                <td align="right" style="color: #E78839; padding-right: 10px;" valign="center">
                    <input type="button" id="AddCDButton" value='Yes, I want a Ultrasound Images' class="ui-state-default ui-corner-all" style="width: 260px;" />
                </td>
            </tr>
        </table>
    </div>
</div>
