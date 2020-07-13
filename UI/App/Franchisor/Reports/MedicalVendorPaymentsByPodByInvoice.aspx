<div id="MedicalVendorPaymentReportsByInvoiceDiv">
    <div id="MedicalVendorInvoiceSelectionComboBoxDiv"></div>
</div>
<div id="MedicalVendorInvoiceSummaryDiv" style="clear: both; padding-bottom: 30px"></div>
<div id="PodEarningSummaryDiv" style="clear: both"></div>
<script type="text/javascript" language="javascript">
    $(document).ready(function() 
    {
        LoadComboBox();
    });
    
    function LoadComboBox()
    {
        var containerDiv = 'MedicalVendorPaymentReportsByInvoiceDiv';
        var messageUrl = '<%=ResolveUrl("~/App/Controllers/MedicalVendorInvoiceController.asmx/GetAllComboBoxInvoiceStatistics")%>';
        var successFunction = function(returnData)
        {
            CreateComboBox(returnData.d);
        }
        var errorMessage = 'An internal server error occurred when attempting to retrieve the list of invoices.';
        AjaxCall(containerDiv, messageUrl, '', successFunction, errorMessage);
    }   
    
    function CreateComboBox(data)
    {
        var containerDiv = 'MedicalVendorInvoiceSelectionComboBoxDiv'
        $.sexyCombo.create(
        {
            id: 'MedicalVendorInvoiceSelectionComboBox',
            name: 'MedicalVendorInvoiceSelectionComboBox',
            container: '#' + containerDiv,
            emptyText: 'Select an invoice...',
            changeCallback: function() { ShowInvoiceSummaryAndPodEarnings(this.getHiddenValue()) },
            data: data
        });

        var comboBoxWidth = 600;
        $('#' + containerDiv)
            .find('input[type=text]').css('width', comboBoxWidth).end()
            .find('.icon').css('left', comboBoxWidth).end()
            .find('.list-wrapper').css('width', comboBoxWidth-2).end();                    
    }
    
    function ShowInvoiceSummaryAndPodEarnings(invoiceId)
    {
        if (invoiceId == parseInt(invoiceId))
        {
            ShowInvoiceSummary(invoiceId);
            ShowPodEarnings(invoiceId);
        }
    }

    function ShowInvoiceSummary(invoiceId)
    {
        var containerDiv = 'MedicalVendorInvoiceSummaryDiv';
        $('#' + containerDiv).html('');
        var messageUrl = '<%=ResolveUrl("~/App/Controllers/MedicalVendorInvoiceController.asmx/GetMedicalVendorInvoiceStatistic")%>';
        var parameter = "{'medicalVendorInvoiceId':'" + invoiceId + "'}";
        var successFunction = function(returnData)
        {
            $('#' + containerDiv).
                setTemplateURL('<%=ResolveUrl("~/App/Templates/MedicalVendorInvoiceSummary.html")%>');
            $('#' + containerDiv).processTemplate(returnData.d);
        }
        var errorMessage = 'An internal server error occurred when attempting to retrieve the summary of invoice #' +
            invoiceId + '.';
        AjaxCall(containerDiv, messageUrl, parameter, successFunction, errorMessage);
    }
    
    function ShowPodEarnings(invoiceId)
    {
        var containerDiv = 'PodEarningSummaryDiv';
        $('#' + containerDiv).html('');
        var messageUrl = '<%=ResolveUrl("~/App/Controllers/PodPerformanceController.asmx/GetPodViewDataForInvoice")%>';
        var parameter = "{'medicalVendorInvoiceId':'" + invoiceId + "'}";
        var successFunction = function(returnData)
        {
            $('#' + containerDiv).setTemplateURL('<%=ResolveUrl("~/App/Templates/PodViewData.html")%>');
            $('#' + containerDiv).processTemplate(returnData.d);

            // TODO: Move to CSS
            $('#' + containerDiv + ' tr:even').css("background-color", "#EFF8FD");
            $('#' + containerDiv + ' tr:odd').css("background-color", "#F8FCFF");
        }
        var errorMessage = 'An internal server error occurred when attempting to retrieve the pod earnings of invoice #' +
            invoiceId + '.';
        AjaxCall(containerDiv, messageUrl, parameter, successFunction, errorMessage);
    }
    
    function AjaxCall(containerDiv, messageUrl, parameter, successFunction, errorMessage)
    {
        if (parameter == '')
        {
            parameter = '{}';
        }
        $('#' + containerDiv).addClass('loading');
        $.ajax
        ({
            type: 'POST',
            url: messageUrl,
            data: parameter,
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function(returnData)
            {
                successFunction(returnData);
                $('#' + containerDiv).removeClass('loading');
            },
            error: function()
            {
                alert(errorMessage);
                $('#' + containerDiv).removeClass('loading');
            }
        });
    }
</script>