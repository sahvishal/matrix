<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewOrderDetails.ascx.cs"
    Inherits="Falcon.App.UI.App.UCCommon.ViewOrderDetails" %>
<%@ Register Src="JQueryToolkit.ascx" TagName="JQueryToolkit" TagPrefix="JQueryControl" %>
<JQueryControl:JQueryToolkit ID="_jQueryToolkit1" runat="server" IncludeJQueryUI="true"
    IncludeJTemplate="true" />
<div id="ViewOrderDetailsDialogDiv" title="Order Details/Payment Details" style="display: none;
    background: #fff;">
    <div id="ViewOrderDetailsTemplateDiv">
    </div>
    <br />
    <div style="display:none">
        <a onclick="return ShowRefundOrderDialog();" style="display:none" href="#" id="RefundOrderAnchor">Refund
            Order</a>
    </div>
    <br />
    <div id="ViewPaymentDetailsTemplateDiv">
    </div>
    <br />
    <div id="AmountOwedDiv" class="rgt orngbold16_default">
    </div>
</div>
<div id="RefundOrderDialogDiv" title="Refund Order" style="display: none; background: #fff;">
    <div id="MainDiv" class="jtp_sd" style="width: 600px">
        <label class="txtdtls">
            Refund Amount:
        </label>
        <span class="lbln">
            <input type="text" id="RefundAmountInput" style="width: 90px" /></span>
        <label class="txtdtls">
            Notes:
        </label>
        <input type="text" id="NotesInput" style="width: 200px" /><br />
        <br />
        <label class="txtdtls">
            Refund Mode:
        </label>
        <span class="lbln">
            <asp:DropDownList ID="RefundModeCombo" runat="server" CssClass="refund-mode-combo"
                Height="25px">
                <asp:ListItem Text="Cash" Value="4" />
                <asp:ListItem Text="Check" Value="1" />
                <asp:ListItem Text="Credit Card" Value="2" />
            </asp:DropDownList>
        </span>
        <div id="CheckDetailsDiv" style="display: none;">
            <label class="txtdtls">
                Check Number:
            </label>
            <span class="lbln">
                <input type="text" id="CheckNumberInput" /></span>
        </div>
    </div>
    <div id="LoadingDiv" style="display: none;">
    </div>
</div>
<div>
    <script type="text/javascript" language="javascript">
        var currentOrderId = 0;
        var currentCustomerId = 0;
        var currentPaymentTotal = 0;

        var organiozationRoleUserId = '<%= OrganizationRoleUserId %>';
        var roleId = '<%=RoleId %>';

        $(function () {
            if ('<%= ShowasJDialog %>' == '<%= bool.TrueString %>') {
                $('#ViewOrderDetailsDialogDiv').dialog({ autoOpen: false, width: 700, buttons: { 'Close': function () { $(this).dialog('close'); } } });
            }
        });

        function ShowOrderDetailsDialog(orderId, orderTotal, paymentTotal, amountOwed, customerName, customerId) {
            currentOrderId = orderId; currentCustomerId = customerId;
            currentPaymentTotal = paymentTotal;
            $('#ViewOrderDetailsDialogDiv').dialog('open');
            FetchOrderDetails(orderId, orderTotal, customerName, customerId, paymentTotal);
            $('#AmountOwedDiv').text('Amount Due: $' + amountOwed);
        }

        function ShowOrderDetailsDialog1(orderId, orderTotal, paymentTotal, amountOwed, customerName, customerId) {
            
            currentOrderId = orderId; currentCustomerId = customerId;
            currentPaymentTotal = paymentTotal;
            $('#ViewOrderDetailsDialogDiv').show();
            FetchOrderDetails(orderId, orderTotal, customerName, customerId, paymentTotal);
            $('#AmountOwedDiv').text('Amount Due: $' + amountOwed);
        }

        function FetchOrderDetails(orderId, orderTotal, customerName, customerId, paymentTotal) {
            var viewOrderDetailsTemplateDiv = $('#ViewOrderDetailsTemplateDiv');
            viewOrderDetailsTemplateDiv.html('');
            viewOrderDetailsTemplateDiv.addClass('loading');

            var viewPaymentDetailsTemplateDiv = $('#ViewPaymentDetailsTemplateDiv');
            viewPaymentDetailsTemplateDiv.html('');
            viewPaymentDetailsTemplateDiv.addClass('loading');

            var messageUrl = '<%=ResolveUrl("~/App/Controllers/OrderController.asmx/GetOrderDetails")%>';
            var parameter = "{'orderId':" + orderId + "}";

            var successFunction = function(returnData) {


                viewOrderDetailsTemplateDiv.setTemplateURL('<%= ResolveUrl("~/App/Templates/OrderDetails.html") %>');
                viewOrderDetailsTemplateDiv.setParam('OrderId', orderId);
                viewOrderDetailsTemplateDiv.setParam('OrderTotal', orderTotal);
                viewOrderDetailsTemplateDiv.setParam('CustomerName', customerName);
                viewOrderDetailsTemplateDiv.setParam('CustomerId', customerId);
                viewOrderDetailsTemplateDiv.setParam('RoleId', roleId);

                viewOrderDetailsTemplateDiv.processTemplate(returnData.d);

                // TODO: This is done to avoid thread deadlock in async call. Should be called simultaneously.
                FetchPaymentDetails(orderId, paymentTotal);
            };

            var numberOfRecordsFunction = function(returnData) { return returnData.d.length; };

            var noRecordsFunction = function() {
                alert('This order contains no order details.');
                viewOrderDetailsTemplateDiv.dialog('close');
            };

            var completeFunction = function() { viewOrderDetailsTemplateDiv.removeClass('loading'); };

            var errorFunction = function() {
                alert('The details of this order could not be loaded due to an internal server error.');
                viewOrderDetailsTemplateDiv.dialog('close');
            };

            LoadAjax(messageUrl, parameter, successFunction, errorFunction, completeFunction, numberOfRecordsFunction, noRecordsFunction, false);
        }

        function FetchPaymentDetails(orderId, paymentTotal) {
            var viewPaymentDetailsTemplateDiv = $('#ViewPaymentDetailsTemplateDiv');

            var messageUrl = '<%=ResolveUrl("~/App/Controllers/OrderController.asmx/GetPaymentDetails")%>';
            var parameter = "{'orderId':" + orderId + "}";

            var successFunction = function(returnData) {

                viewPaymentDetailsTemplateDiv.setTemplateURL('<%= ResolveUrl("~/App/Templates/Payments.html") %>');
                viewPaymentDetailsTemplateDiv.setParam('PaymentTotal', paymentTotal);
                viewPaymentDetailsTemplateDiv.setParam('RoleId', roleId);
                viewPaymentDetailsTemplateDiv.processTemplate(returnData.d);

                if (roleId == '<%=(int)Falcon.App.Core.Enum.Roles.Customer %>')
                    $('.executed-by-role').hide();
                else
                    $('.executed-by-role').show();
            };

            var numberOfRecordsFunction = function (returnData) { return returnData.d.length; }

            var noRecordsFunction = function() {
                //$('#RefundOrderAnchor').hide();
                viewPaymentDetailsTemplateDiv.html('This order contains no payments.');
            };

            var completeFunction = function() {
                $('#ViewPaymentDetailsTemplateDiv').removeClass('loading');
            };

            var errorFunction = function() {
                viewPaymentDetailsTemplateDiv.html('The payments of this order could not be loaded due to an internal server error.');
            };

            LoadAjax(messageUrl, parameter, successFunction, errorFunction, completeFunction, numberOfRecordsFunction, noRecordsFunction, false);
        }

    </script>
    <script language="javascript" type="text/javascript">
        function ShowRefundOrderDialog() {
            if (currentOrderId > 0) {
                $('#ViewOrderDetailsDialogDiv').dialog('close');
                AddRemoveChargeCardOption();
            }
            else
                alert('Please choose a valid order to refund payment.');
        }

        function AddRemoveChargeCardOption() {
            var messageUrl = '<%=ResolveUrl("~/App/Controllers/OrderController.asmx/IsPaymentUsingChargeCard")%>';
            var parameter = "{'orderId':" + currentOrderId + "}";

            var successFunction = function (resultData) {
                if (!resultData.d)
                    $(".refund-mode-combo option[value='2']").remove();
                $('#RefundOrderDialogDiv').dialog('open');
            }
            var errorFunction = function () { alert('There was some error loading the data. Please try again.'); }
            InvokeAsyncService(messageUrl, parameter, successFunction, errorFunction);
        }
    </script>
    <script type="text/javascript" language="javascript">

        $.ajaxSetup({ cache: false });

        $(function () {
//            if (roleId == 1 || roleId == 2)
//                $('#RefundOrderAnchor').show();
//            else
//                $('#RefundOrderAnchor').hide();

            $('#RefundAmountInput').numeric({ allow: "." });

            $('#RefundOrderDialogDiv').dialog({ autoOpen: false, width: 700, buttons: { 'Refund': function () { RefundOrder(); }, 'Close': function () { $(this).dialog('close'); } } });

            $('.refund-mode-combo').change(function (e) {
                if ($(this).find('option:selected').val() == 1) {
                    $('#CheckDetailsDiv').show();
                    return;
                }
                $('#CheckDetailsDiv').hide();
            });

        });

        function RefundOrder() {
            if ($.trim($('#RefundAmountInput').val()).length <= 0) {
                alert('Please enter a valid amount to refund.');
                return false;
            }
            else if ($.trim($('#RefundAmountInput').val()) > currentPaymentTotal) {
                alert('You can not refund more than the amount paid. Please enter a valid amount to be refund.');
                return false;
            }
            if ($('.refund-mode-combo option:selected').val() == 1 && $.trim($('#CheckNumberInput').val()).length < 0) {
                alert('Please enter a valid check number.');
                return false;
            }
            var messageUrl = '<%=ResolveUrl("~/App/Controllers/OrderController.asmx/RefundOrder")%>';

            var parameter = "{'orderId':" + currentOrderId + ",";
            parameter += "'amount':" + $.trim($('#RefundAmountInput').val()) + ",";
            parameter += "'refundMode':" + $('.refund-mode-combo option:selected').val() + ",";
            parameter += "'notes':'" + $.trim($('#NotesInput').val()) + "',";
            parameter += "'checkNumber':'" + $.trim($('#CheckNumberInput').val()) + "',";
            parameter += "'customerId':" + currentCustomerId + ",";
            parameter += "'organizationRoleUserId':" + organiozationRoleUserId + "}";

            var successFunction = function (resultData) {
                if (!resultData.d) {
                    alert('OOps some error occoured while processing, please refund after some time.');
                    HideLoadingIkon();
                }
                else {
                    location.reload(true);
                    HideLoadingIkon();
                }
            }
            var errorFunction = function () { alert('OOps some error occoured while processing, please refund after some time.'); HideLoadingIkon(); }

            SaveRefundData(messageUrl, parameter, successFunction, errorFunction);
        }
    </script>
    <script type="text/javascript" language="javascript">

        function SaveRefundData(messageUrl, parameter, successFunction, errorFunction) {
            ShowLoadingIkon();
            InvokeAsyncService(messageUrl, parameter, successFunction, errorFunction);
        }

        function ShowLoadingIkon() {
            $('#MainDiv').hide();
            $('#LoadingDiv').show();
            $('#LoadingDiv').addClass('loading');
        }

        function HideLoadingIkon() {
            $('#MainDiv').show();
            $('#LoadingDiv').hide();
            $('#LoadingDiv').removeClass('loading');
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
</div>
