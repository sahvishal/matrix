<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentSummary.aspx.cs" 
    Inherits="Falcon.App.UI.App.MedicalVendor.PaymentSummary" %>
<form id="PaymentSummaryForm" runat="server">
<div style="text-align: right;">
    Show Records From:
    <input type="text" id="PaymentStartDateTextBox" size="10" />                                 
    to                             
    <input type="text" id="PaymentEndDateTextBox" size="10" />
    for
    <asp:DropDownList id="PhysicianDropDownList" runat="server" />
    <input type="button" id="PaymentDateFilterButton" class="ui-state-default ui-corner-all" value="Filter" 
        onclick="FilterPayments()" />
</div>
<div id="PaymentSummaryDiv"></div>
<div id="ViewInvoiceDialogDiv" title="View Invoice" style="display: none">
    <div id="InvoiceDiv"></div>
</div>
</form>
<script type="text/javascript" language="javascript">
    var paymentPageSize = 50;
    var paymentCurrentPage = 1;
    var paymentLastPage = 1;
    var paymentContainerDiv = 'PaymentSummaryDiv';
    
    $(document).ready(function() 
    {
        $('#PaymentStartDateTextBox').datepicker();
        $('#PaymentStartDateTextBox').val('');
        $('#PaymentEndDateTextBox').datepicker();
        $('#PaymentEndDateTextBox').val('');
        $('#ViewInvoiceDialogDiv').dialog({ width: 800 , height: 600 , autoOpen: false });
        LoadMedicalVendorUserEarningAggregates('<%= new DateTime(2000, 1, 1).ToString() %>','<%= DateTime.Today.ToString() %>',
            paymentCurrentPage);
    })
    
    function LoadInvoiceDialog(invoiceId)
    {
        var invoiceContainerDiv = 'InvoiceDiv';
        var messageUrl = '<%=ResolveUrl("~/App/Controllers/MedicalVendorPaymentWebService.asmx/GetInvoice")%>';
        var parameter = "{'invoiceId':'" + invoiceId + "'}";
        var successFunction = function(returnData)
        {
            alert("here1");
            $('#' + invoiceContainerDiv).setTemplateURL('<%=ResolveUrl("~/App/Templates/MedicalVendorInvoice.html")%>');
            alert("here2");
            $('#' + invoiceContainerDiv).processTemplate(returnData.d);
            alert("here3");
            // TODO: Move to CSS
            $('#MedicalVendorInvoiceItemTable th').css('background-color', '#DDF0F7');
            $('#MedicalVendorInvoiceItemTable tr:even').css('background-color', '#EFF8FD');
            $('#MedicalVendorInvoiceItemTable tr:odd').css('background-color', '#F8FCFF');
        }
        var errorMessage = 'An internal server error occurred when trying to load the invoice.';
        $('#ViewInvoiceDialogDiv').dialog('open');
        AjaxCall(invoiceContainerDiv, messageUrl, parameter, successFunction, errorMessage);
    }
    
    function LoadMedicalVendorUserEarningAggregates(startDate,endDate,pageNumber)
    {
        $('#' + paymentContainerDiv).html('');
        var parameter;
        var messageUrl;
        if ($('#PhysicianDropDownList').val() == 0)
        {
            messageUrl = 
                '<%=ResolveUrl("~/App/Controllers/MedicalVendorUserPaymentController.asmx/GetInvoiceStatisticsAndCountForVendor")%>';
            parameter = "{'medicalVendorId':'" + <%= _medicalVendorId %> + "'";
        }
        else
        {
            messageUrl = 
                '<%=ResolveUrl("~/App/Controllers/MedicalVendorUserPaymentController.asmx/GetInvoiceStatisticsAndCount")%>';
            parameter = "{'organizationRoleUserId':'" + $('#PhysicianDropDownList').val() + "'";
        }
        parameter += ",'startDate':'" + startDate + "'";
        parameter += ",'endDate':'" + endDate + "'";
        parameter += ",'pageNumber':'" + pageNumber + "'";                
        parameter += ",'pageSize':'" + paymentPageSize + "'}";
        var successFunction = function(returnData)
        {
            paymentLastPage = Math.ceil(returnData.d.FirstValue / paymentPageSize);
            $('#' + paymentContainerDiv).setTemplateURL('<%=ResolveUrl("~/App/Templates/MedicalVendorInvoiceStatistic.html")%>');
            $('#' + paymentContainerDiv).processTemplate(returnData.d.SecondValue);

            // TODO: Move to CSS
            $('#MedicalVendorStatisticTable th').css('background-color', '#DDF0F7');
            $('#MedicalVendorStatisticTable tr:even').css('background-color', '#EFF8FD');
            $('#MedicalVendorStatisticTable tr:odd').css('background-color', '#F8FCFF');
            UpdatePaging();
        }
        var numberOfRecordsFunction = function(returnData)
        {
            return returnData.d.FirstValue;
        }
        var errorMessage = 'An internal server error occurred when trying to load the Payment Summary.';
        AjaxCall(paymentContainerDiv, messageUrl, parameter, successFunction, errorMessage, numberOfRecordsFunction);
    }
            
    function ApplyTemplate(templateData) 
    {
        $("#PaymentSummaryDiv").setTemplateURL('<%=ResolveUrl("~/App/Templates/MedicalVendorInvoiceStatistic.html")%>');
        $("#PaymentSummaryDiv").processTemplate(templateData);

        // TODO: Move to CSS
        $("#MedicalVendorStatisticTable th").css("background-color", "#DDF0F7");
        $("#MedicalVendorStatisticTable tr:even").css("background-color", "#EFF8FD");
        $("#MedicalVendorStatisticTable tr:odd").css("background-color", "#F8FCFF");
    }

    function DisplayNoRecordsFoundMessage()
    {
        $('#PaymentSummaryDiv').
            html('<div class="divnoitemfound_mvpe" style="margin-top: 15px;"><p class="divnoitemtxt_mvpe"></p></div>');
        $('#PaymentSummaryDiv p').html('<span class="orngbold18_default">No Records Found</span>');
    }
    
    function DisplayErrorMessage()
    {
        alert("Internal Server Error");
        DisplayNoRecordsFoundMessage();
    }
    
    function DisplayProgressIndication()
    {
        $('#PagingDiv').hide();

        // Clean up our event handlers to avoid memory leaks.
        $('#PrevPage').unbind();
        $('#NextPage').unbind();

        DisplayInitialTable();
        $('#MedicalVendorPaymentTable tbody td').addClass('loading');
    }
    
    function DisplayInitialTable()
    {
        $('#PaymentSummaryDiv').html('<table id="MedicalVendorPaymentTable" class="divgrid_clnew" cellspacing="3" width="100%"></table>');
        $('#MedicalVendorPaymentTable').html('<thead></thead><tbody></tbody>');
        $('#MedicalVendorPaymentTable thead').html('<tr><th></th></tr>');
        $('#MedicalVendorPaymentTable tbody').html('<tr><td colspan="4"></td></tr>');
    }
    
    function UpdatePaging()
    {
        if (paymentCurrentPage != 1) 
        {
            $('#PrevPage').attr('href', '#');
            $('#PrevPage').click(PrevPage);
        }
        else
        {
            $('#PrevPage').hide();
        }

        if (paymentCurrentPage != paymentLastPage) 
        {
            $('#NextPage').attr('href', '#');
            $('#NextPage').click(NextPage);
        }
        else
        {
            $('#NextPage').hide();
        }
        
        if (paymentCurrentPage == 1 || paymentCurrentPage == paymentLastPage)
        {
            $('#PagingLinksSeparator').hide();
        }
    }
    
    function NextPage(evt) 
    {
        evt.preventDefault();
        if ($('#PaymentStartDateTextBox').val() == '' || $('#PaymentEndDateTextBox').val() == '')
        {
            LoadMedicalVendorUserEarningAggregates('<%= new DateTime(2000, 1, 1).ToString() %>','<%= DateTime.Today.ToString() %>',
                ++paymentCurrentPage);
        }
        else
        {
            LoadMedicalVendorUserEarningAggregates($('#PaymentStartDateTextBox').val(),$('#PaymentEndDateTextBox').val(),
                ++paymentCurrentPage);
        }
    }

    function PrevPage(evt)
    {
        evt.preventDefault();
        if ($('#PaymentStartDateTextBox').val() == '' || $('#PaymentEndDateTextBox').val() == '')
        {
            LoadMedicalVendorUserEarningAggregates('<%= new DateTime(2000, 1, 1).ToString() %>','<%= DateTime.Today.ToString() %>',
                --paymentCurrentPage);
        }
        else
        {
            LoadMedicalVendorUserEarningAggregates($('#PaymentStartDateTextBox').val(),$('#PaymentEndDateTextBox').val(),
                --paymentCurrentPage);
        }
    }
    
    function FilterPayments()
    {
        paymentCurrentPage = 1;
        if ($('#PaymentStartDateTextBox').val() == '' || $('#PaymentEndDateTextBox').val() == '')
        {
            LoadMedicalVendorUserEarningAggregates('<%= new DateTime(2000, 1, 1).ToString() %>','<%= DateTime.Today.ToString() %>',
                paymentCurrentPage);
        }
        else
        {
            LoadMedicalVendorUserEarningAggregates($('#PaymentStartDateTextBox').val(), $('#PaymentEndDateTextBox').val(),
                paymentCurrentPage);
        }
    }
</script>