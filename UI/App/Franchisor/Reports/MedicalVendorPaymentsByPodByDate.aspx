<form id="MedicalVendorPaymentByPodByDateForm" runat="server">
    <div style="text-align: right;">
        Show Pod Earnings from:
        <input type="text" id="StartDateTextBox" size="10" />                                 
        to                             
        <input type="text" id="EndDateTextBox" size="10" />
        <input type="button" id="PodEarningDateFilterButton" class="ui-state-default ui-corner-all" 
            value="Filter" onclick="GetPodEarningsForDateRange()" />
    </div>
</form>
<div id="PodEarningSummaryByDateDiv" style="clear: both"></div>
<script type="text/javascript" language="javascript">
    $(document).ready(function() 
    {
        $('#StartDateTextBox').datepicker();
        $('#EndDateTextBox').datepicker();
    });
    
    function IsValidDate(sDate)
    {
        var re = /^\d{1,2}\/\d{1,2}\/\d{4}$/
        if (re.test(sDate))
        {
            var dArr = sDate.split("/");
            var d = new Date(sDate);
            return d.getMonth() + 1 == dArr[0] && d.getDate() == dArr[1] && d.getFullYear() == dArr[2];
        }
        return false;
    }
    
    function GetPodEarningsForDateRange()
    {
        var startDate = $('#StartDateTextBox').val();
        var endDate = $('#EndDateTextBox').val();
        if (startDate == '')
        {
            alert('Please enter a start date.');
            $('#StartDateTextBox').focus();
        }
        else if (!IsValidDate(startDate)) 
        {
            alert('Please enter a valid start date.');
            $('#StartDateTextBox').focus();
        }
        else if (endDate == '')
        {
            alert('Please enter an end date.');
            $('#EndDateTextBox').focus();
        }
        else if (!IsValidDate(endDate)) 
        {
            alert('Please enter a valid end date.');
            $('#EndDateTextBox').focus();
        }
        else 
        {
            ShowPodEarnings(startDate, endDate);
        }
    }
    
    function ShowPodEarnings(startDate, endDate)
    {
        var containerDiv = 'PodEarningSummaryByDateDiv';
        $('#' + containerDiv).html('');
        var messageUrl = '<%=ResolveUrl("~/App/Controllers/PodPerformanceController.asmx/GetPodViewDataForDateRange")%>';
        var parameter = "{'startDate':'" + startDate + "',";
        parameter += "'endDate':'" + endDate + "'}";
        var successFunction = function(returnData)
        {
            if (returnData.d.length > 0)
            {
                $('#' + containerDiv).setTemplateURL('<%=ResolveUrl("~/App/Templates/PodViewData.html")%>');
                $('#' + containerDiv).processTemplate(returnData.d);

                // TODO: Move to CSS
                $('#' + containerDiv + ' tr:even').css("background-color", "#EFF8FD");
                $('#' + containerDiv + ' tr:odd').css("background-color", "#F8FCFF");
            }
            else
            {
                alert("No invoices were found for the given date range.");
            }
        }
        var errorMessage = 'An internal server error occurred when attempting to retrieve the pod earnings.';
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