<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewOrders.ascx.cs"
    Inherits="Falcon.App.UI.App.UCCommon.ViewOrders" %>
<%@ Register Src="JQueryToolkit.ascx" TagName="JQueryToolkit" TagPrefix="JQueryControl" %>
<JQueryControl:JQueryToolkit ID="_jQueryToolkit1" runat="server" IncludeJQueryUI="true"
    IncludeJTemplate="true" />
<h3>
    View Orders</h3>
<div id="ViewOrdersDiv">
</div>
<div id="ViewOrdersPager" style="display: none">
    <a href="#" id="PrevPageLink">Previous Page</a> <span id="ViewOrderPages"></span>
    <a href="#" id="NextPageLink">Next Page</a>
</div>
<div id="ViewOrderDetailsDialogDiv" title="Order Details" style="display: none">
    <div id="ViewOrderDetailsTemplateDiv">
    </div>
    <div id="ViewPaymentDetailsTemplateDiv">
    </div>
    <div id="AmountOwedDiv">
    </div>
</div>

<script type="text/javascript">
    var PAGE_SIZE = 10;
    var totalNumberOfOrders;
    var currentPage = 1;

    $(function() {
        $('#ViewOrderDetailsDialogDiv').dialog({ autoOpen: false, width: 850, buttons: { 'Close': function() { $(this).dialog('close'); } } });
        GetTotalNumberOfOrders();
    })

    function ShowOrderDetailsDialog(orderId, orderTotal, paymentTotal, amountOwed) {
        $('#ViewOrderDetailsDialogDiv').dialog('open');
        FetchOrderDetails(orderId, orderTotal);
        FetchPaymentDetails(orderId, paymentTotal);
        $('#AmountOwedDiv').text('Amount Due: ' + amountOwed);
    }

    function FetchOrderDetails(orderId, orderTotal) {
        var viewOrderDetailsTemplateDiv = $('#ViewOrderDetailsTemplateDiv');
        viewOrderDetailsTemplateDiv.html('');
        viewOrderDetailsTemplateDiv.addClass('loading');
        var messageUrl = '<%=ResolveUrl("~/App/Controllers/OrderController.asmx/GetOrderDetails")%>';
        var parameter = "{'orderId':" + orderId + "}";
        var successFunction = function(returnData) {

            viewOrderDetailsTemplateDiv.setTemplateURL('<%= ResolveUrl("~/App/Templates/OrderDetails.html") %>');
            viewOrderDetailsTemplateDiv.setParam('OrderId', orderId);
            viewOrderDetailsTemplateDiv.setParam('OrderTotal', orderTotal);
            viewOrderDetailsTemplateDiv.setParam('CustomerName', returnData.d[0].CustomerName);
            viewOrderDetailsTemplateDiv.setParam('CustomerId', returnData.d[0].CustomerId);
            viewOrderDetailsTemplateDiv.processTemplate(returnData.d);
        }
        var numberOfRecordsFunction = function(returnData) { return returnData.d.length; }
        var noRecordsFunction = function() {
            alert('This order contains no order details.');
            viewOrderDetailsTemplateDiv.dialog('close');
        }
        var completeFunction = function() { viewOrderDetailsTemplateDiv.removeClass('loading'); }
        var errorFunction = function() {
            alert('The details of this order could not be loaded due to an internal server error.');
            viewOrderDetailsTemplateDiv.dialog('close');
        }
        LoadAjax(messageUrl, parameter, successFunction, errorFunction, completeFunction, numberOfRecordsFunction, noRecordsFunction);
    }

    function FetchPaymentDetails(orderId, paymentTotal) {
        var viewPaymentDetailsTemplateDiv = $('#ViewPaymentDetailsTemplateDiv');
        viewPaymentDetailsTemplateDiv.html('');
        viewPaymentDetailsTemplateDiv.addClass('loading');
        var messageUrl = '<%=ResolveUrl("~/App/Controllers/OrderController.asmx/GetPaymentDetails")%>';
        var parameter = "{'orderId':" + orderId + "}";
        var successFunction = function(returnData) {
            viewPaymentDetailsTemplateDiv.setTemplateURL('<%= ResolveUrl("~/App/Templates/Payments.html") %>');
            viewPaymentDetailsTemplateDiv.setParam('PaymentTotal', paymentTotal);
            viewPaymentDetailsTemplateDiv.processTemplate(returnData.d);
        }
        var numberOfRecordsFunction = function(returnData) { return returnData.d.length; }
        var noRecordsFunction = function() {
            viewPaymentDetailsTemplateDiv.html('This order contains no payments.');
        }
        var completeFunction = function() {
            $('#ViewPaymentDetailsTemplateDiv').removeClass('loading');
        }
        var errorFunction = function() {
            viewPaymentDetailsTemplateDiv.html('The payments of this order could not be loaded due to an internal server error.');
        }
        LoadAjax(messageUrl, parameter, successFunction, errorFunction, completeFunction, numberOfRecordsFunction, noRecordsFunction);
    }

    function ViewOrderDetails() {
        var orderId = parseInt($(this).closest("tr").find(".orderId").text(), 10);
        var orderTotal = $(this).closest("tr").find(".discountedTotal").text();
        var paymentTotal = $(this).closest("tr").find(".amountPaid").text();
        var amountOwed = $(this).closest("tr").find(".amountOwed").text();
        ShowOrderDetailsDialog(orderId, orderTotal, paymentTotal, amountOwed);
        return false;
    }

    function GetTotalNumberOfOrders() {
        var messageUrl = '<%=ResolveUrl("~/App/Controllers/OrderController.asmx/CountAllOrders")%>';
        var parameter = '{}';
        var successFunction = function(returnData) {
            totalNumberOfOrders = returnData.d;
            LoadOrders(currentPage, PAGE_SIZE);
        }
        var numberOfRecordsFunction = function(returnData) { return returnData.d; }
        var noRecordsFunction = function() { alert('There are no orders to display.'); }
        var completeFunction = function() { }
        var errorFunction = function() { alert('Your orders could not be loaded due to an internal server error.'); }
        LoadAjax(messageUrl, parameter, successFunction, errorFunction, completeFunction, numberOfRecordsFunction, noRecordsFunction);
    }

    function LoadOrders(pageNumber, pageSize) {
        $('#ViewOrdersPager').hide();
        var viewOrdersDiv = $('#ViewOrdersDiv');
        viewOrdersDiv.html('');
        viewOrdersDiv.addClass('loading');
        var messageUrl = '<%=ResolveUrl("~/App/Controllers/OrderController.asmx/GetAllOrders")%>';
        var parameter = "{'pageNumber':" + pageNumber + ",'pageSize':" + pageSize + "}";
        var successFunction = function(returnData) {
            viewOrdersDiv.setTemplateURL('<%= ResolveUrl("~/App/Templates/Orders.html") %>');
            viewOrdersDiv.processTemplate(returnData.d);
            viewOrdersDiv.find(".viewOrderDetails").click(ViewOrderDetails);
        }
        var numberOfRecordsFunction = function(returnData) { return returnData.d.length; }
        var noRecordsFunction = function() { alert('No orders found.'); }
        var completeFunction = function() { viewOrdersDiv.removeClass('loading'); Paginate(); }
        var errorFunction = function() { alert('Your orders could not be loaded due to an internal server error.'); }
        LoadAjax(messageUrl, parameter, successFunction, errorFunction, completeFunction, numberOfRecordsFunction, noRecordsFunction);
    }

    function LoadPreviousPage() {
        return GoToPage(currentPage - 1);
    }

    function LoadNextPage() {
        return GoToPage(currentPage + 1);
    }

    function GoToPage(page) {
        currentPage = page;
        LoadOrders(currentPage, PAGE_SIZE);
        return false;
    }

    function Paginate() {
        var previousPageLink = $('#PrevPageLink');
        var nextPageLink = $('#NextPageLink');
        var numberOfPages = totalNumberOfOrders / PAGE_SIZE;
        if (currentPage == 1) {
            previousPageLink.hide();
        }
        else {
            previousPageLink.show();
            previousPageLink.unbind();
            previousPageLink.click(LoadPreviousPage);
        }
        if (currentPage >= numberOfPages) {
            nextPageLink.hide();
        }
        else {
            nextPageLink.show();
            nextPageLink.unbind();
            nextPageLink.click(LoadNextPage);
        }

        /*
        not sure why this isn't working, but it's not the priority right now...
        var pages = $("#ViewOrderPages");
        pages.html('');
        for (var i = 1; i <= numberOfPages; ++i) {
        $("<a href='#'></a>").text(i).click(function(){return GoToPage(i)}).appendTo(pages);
        }
        */

        $('#ViewOrdersPager').show();
    }
</script>

