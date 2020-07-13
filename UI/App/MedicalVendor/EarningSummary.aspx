<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EarningSummary.aspx.cs" 
    Inherits="Falcon.App.UI.App.MedicalVendor.EarningSummary" %>
<form id="EarningSummaryForm" runat="server">
<div style="text-align: right;">
    Show Records From:
    <input type="text" id="StartDateTextBox" size="10" />                                 
    to                             
    <input type="text" id="EndDateTextBox" size="10" />
    for
    <asp:DropDownList id="PhysicianDropDownList" runat="server" />
    <input type="button" id="EarningDateFilterButton" class="ui-state-default ui-corner-all" value="Filter" 
        onclick="FilterEarnings()" />
</div>
<div id="EarningSummaryDiv"></div>
</form>
<script type="text/javascript" language="javascript">
    var pageSize = 50;
    var currentPage = 1;
    var lastPage = 1;
    var containerDiv = 'EarningSummaryDiv';
    
    $(document).ready(function() 
    {
        $('#StartDateTextBox').datepicker();
        $('#StartDateTextBox').val('');
        $('#EndDateTextBox').datepicker();
        $('#EndDateTextBox').val('');
        LoadMedicalVendorUserEarningAggregates('<%= new DateTime(2000, 1, 1).ToString() %>','<%= DateTime.Today.ToString() %>',
            currentPage);
    })
    
    function LoadMedicalVendorUserEarningAggregates(startDate,endDate,pageNumber)
    {
        $('#' + containerDiv).html('');
        var parameter;
        var messageUrl;
        if ($('#PhysicianDropDownList').val() == 0)
        {
            messageUrl = 
                '<%=ResolveUrl("~/App/Controllers/MedicalVendorUserEarningController.asmx/GetEarningCustomerAggregatesAndAggregateCountForVendor")%>';
            parameter = "{'medicalVendorId':'" + <%= _medicalVendorId %> + "'";
        }
        else
        {
            messageUrl = 
                '<%=ResolveUrl("~/App/Controllers/MedicalVendorUserEarningController.asmx/GetEarningCustomerAggregatesAndAggregateCount")%>';
            parameter = "{'organizationRoleUserId':'" + $('#PhysicianDropDownList').val() + "'";
        }
        parameter += ",'startDate':'" + startDate + "'";
        parameter += ",'endDate':'" + endDate + "'";
        parameter += ",'pageNumber':'" + pageNumber + "'";                
        parameter += ",'pageSize':'" + pageSize + "'}";
        var successFunction = function(returnData)
        {
            lastPage = Math.ceil(returnData.d.FirstValue / pageSize);
            ApplyTemplate(returnData.d.SecondValue);
            UpdatePaging();
        }
        var numberOfRecordsFunction = function(returnData)
        {
            return returnData.d.FirstValue;
        }
        var errorMessage = 'An internal server error occurred when trying to load the Earning Summary.';
        AjaxCall(containerDiv, messageUrl, parameter, successFunction, errorMessage, numberOfRecordsFunction);
    }
            
    function ApplyTemplate(templateData) 
    {
        $('#EarningSummaryDiv').setTemplateURL('<%=ResolveUrl("~/App/Templates/MedicalVendorEarningSummary.html")%>');
        $('#EarningSummaryDiv').processTemplate(templateData);

        // TODO: Move to CSS
        $('#MedicalVendorEarningSummaryTable th').css('background-color', '#DDF0F7');
        $('#MedicalVendorEarningSummaryTable tr:even').css('background-color', '#EFF8FD');
        $('#MedicalVendorEarningSummaryTable tr:odd').css('background-color', '#F8FCFF');
    }

    function UpdatePaging()
    {
        if (currentPage != 1) 
        {
            $('#PrevPage').attr('href', '#');
            $('#PrevPage').click(PrevPage);
        }
        else
        {
            $('#PrevPage').hide();
        }

        if (currentPage != lastPage) 
        {
            $('#NextPage').attr('href', '#');
            $('#NextPage').click(NextPage);
        }
        else
        {
            $('#NextPage').hide();
        }
        
        if (currentPage == 1 || currentPage == lastPage)
        {
            $('#PagingLinksSeparator').hide();
        }
    }
    
    function NextPage(evt) 
    {
        evt.preventDefault();
        if ($('#StartDateTextBox').val() == '' || $('#EndDateTextBox').val() == '')
        {
            LoadMedicalVendorUserEarningAggregates('<%= new DateTime(2000, 1, 1).ToString() %>','<%= DateTime.Today.ToString() %>',
                ++currentPage);
        }
        else
        {
            LoadMedicalVendorUserEarningAggregates($('#StartDateTextBox').val(),$('#EndDateTextBox').val(),
                ++currentPage);
        }
    }

    function PrevPage(evt)
    {
        evt.preventDefault();
        if ($('#StartDateTextBox').val() == '' || $('#EndDateTextBox').val() == '')
        {
            LoadMedicalVendorUserEarningAggregates('<%= new DateTime(2000, 1, 1).ToString() %>','<%= DateTime.Today.ToString() %>',
                --currentPage);
        }
        else
        {
            LoadMedicalVendorUserEarningAggregates($('#StartDateTextBox').val(),$('#EndDateTextBox').val(),
                --currentPage);
        }
    }
    
    function FilterEarnings()
    {
        currentPage = 1;
        if ($('#StartDateTextBox').val() == '' || $('#EndDateTextBox').val() == '')
        {
            LoadMedicalVendorUserEarningAggregates('<%= new DateTime(2000, 1, 1).ToString() %>','<%= DateTime.Today.ToString() %>',
                currentPage);
        }
        else
        {
            LoadMedicalVendorUserEarningAggregates($('#StartDateTextBox').val(), $('#EndDateTextBox').val(),
                currentPage);
        }
    }
</script>