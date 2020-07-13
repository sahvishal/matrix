<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewShippingDetails.ascx.cs"
    Inherits="Falcon.App.UI.App.UCCommon.ViewShippingDetails" %>
<%@ Register Src="JQueryToolkit.ascx" TagName="JQueryToolkit" TagPrefix="JQueryControl" %>
<JQueryControl:JQueryToolkit ID="_jQueryToolkit1" runat="server" IncludeJQueryUI="true"
    IncludeJTemplate="true" />
<div id="ViewShippingDetailsDialogDiv" title="Shipping Details" style="display: none;
    background: #fff">
    <div id="ViewShippingDetailsTemplateDiv">
    </div>
</div>
<div>
<script type="text/javascript" src="/App/JavascriptFiles/JSonHelper.js"></script>
    <script type="text/javascript" language="javascript">

        $(function() {
            $('#ViewShippingDetailsDialogDiv').dialog({ autoOpen: false, width: 700, buttons: { 'Close': function() { $(this).dialog('close'); } } });
        });

        function ShowShippingDetailsDialog(orderDetailId, totalPrice) {
            $('#ViewShippingDetailsDialogDiv').dialog('open');
            FetchShippingDetails(orderDetailId, totalPrice);
            return false;
        }

        function FetchShippingDetails(orderDetailId, totalPrice) {

            var viewShippingDetailsTemplateDiv = $('#ViewShippingDetailsTemplateDiv');

            viewShippingDetailsTemplateDiv.html('');
            viewShippingDetailsTemplateDiv.addClass('loading');

            var messageUrl = '<%=ResolveUrl("~/App/Controllers/ShippingController.asmx/GetShippingDetailsForOrder")%>';
            var parameter = "{'orderDetailId':" + orderDetailId + "}";

            var successFunction = function(returnData) {
                viewShippingDetailsTemplateDiv.setTemplateURL('<%= ResolveUrl("~/App/Templates/ShippingDetails.html") %>');
                viewShippingDetailsTemplateDiv.setParam('TotalPrice', totalPrice);
                viewShippingDetailsTemplateDiv.processTemplate(returnData.d);
            }

            var numberOfRecordsFunction = function(returnData) { return returnData.d.length; }

            var noRecordsFunction = function() {
                alert('This Customer has not purchased any shipping options');
                viewShippingDetailsTemplateDiv.dialog('close');
            }

            var completeFunction = function() { viewShippingDetailsTemplateDiv.removeClass('loading'); }

            var errorFunction = function() {
                alert('The details of this customer could not be loaded due to an internal server error.');
                viewShippingDetailsTemplateDiv.dialog('close');
            }

            LoadAjax(messageUrl, parameter, successFunction, errorFunction, completeFunction, numberOfRecordsFunction, noRecordsFunction);
        }

    </script>

</div>
