<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCallCenterMetrics.ascx.cs"
    Inherits="Falcon.App.UI.App.UCCommon.ucCallCenterMetrics" %>
<%@ Import Namespace="Falcon.App.Core.Extensions" %>
<%@ Import Namespace="Falcon.App.Core.Enum" %>
<%@ Register Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" TagPrefix="JQueryControl" %>
<JQueryControl:JQueryToolkit ID="JQueryToolkit1" runat="server" IncludeJQueryUI="true"
    IncludeJTemplate="true" IncudeJQueryJTip="true" />
<style type="text/css">
    .trheight
    {
        height: 46px;
		vertical-align:top;
    }
        .trhead
    {
		vertical-align:top;
    }
</style>
<div class="wrapper_ecl">
    <h1 class="mt_medium">
        <%= Page.Title %></h1>
    <div class="hr">
    </div>
    <div class="chklistdiv">
        <div class="left">
            <span class="bold">Select Personal Statistics Date Range:</span>
            <select id="DateRangeDDL">
                <option value="Today">Today</option>
                <option value="ThisWeek">This Week</option>
                <option value="ThisMonth">This Month</option>
                <option value="Last7Days" selected="selected">Last 7 Days</option>
                <option value="Last30Days">Last 30 Days</option>
                <option value="ThisQuarter">This Quarter</option>
                <option value="LastQuarter">Last Quarter</option>
                <option value="SelectDateRange">Select Date Range</option>
            </select>
        </div>
        <div id="CustomDateRangeDiv" class="left" style="display: none; width: 290px">
            <span class="bold">Show metrics from</span>
            <input type="text" id="StartDateTextBox" style="width: 70px" />
            to
            <input type="text" id="EndDateTextBox" style="width: 70px" />
        </div>
        <div class="left">
            <input type="button" id="DateRangeFilterButton" onclick="SetFilterDatesForMetrics()"
                value="Filter" class="button" />
        </div>
    </div>
    <div id="StatisticsWrapperDiv" class="lheight" style="display: none;">
        <h3>
            My Statistics</h3>
        <div id="PersonalStatisticsDiv">
        </div>
    </div>
    <div class="lheight" style="width:100%">
        <h3>Global Metrics</h3>
    </div>
    <div id="globalMetricsDiv" class="divgrd_mtrcs">
        <div id="GlobalMetricsBookingPercentageDiv" class="smlgrd_mtrcs">
        </div>
        <div id="GlobalMetricsClosingPercentageDiv" class="smlgrd_mtrcs">
        </div>
        <div id="GlobalMetricsAverageSalesDiv" class="smlgrd_mtrcs">
        </div>
<%--        <div id="GlobalMetricsSpouseBookingPercentageDiv" class="smlgrd_mtrcs" style="display:none">
        </div>--%>
    </div>
</div>

<script type="text/javascript" language="javascript">

    $.ajaxSetup({ cache: false });
    
    function SetLinkofDetailsforBooking() {
        var linkPrefix = $('#MetricDetailLinkInputHidden').val();
        $("#GlobalMetricsBookingPercentageDiv .ccrepid-input-hidden").each(function() {
            var id = $(this).val();
            $(this).parent().find('.detail-anchor').attr('href', linkPrefix + '?Type=booking&Rep=' + id + '&From=' + selectedStartDate + '&To=' + selectedEndDate);
            $(this).parent().parent().find('.ccrep-amount').toggle();
        });
    }

//    function SetLinkofDetailsforSpouseBooking() {
//        var linkPrefix = $('#MetricDetailLinkInputHidden').val();
//        $("#GlobalMetricsSpouseBookingPercentageDiv .ccrepid-input-hidden").each(function() {
//            var id = $(this).val();
//            $(this).parent().find('.detail-anchor').attr('href', linkPrefix + '?Type=spousebooking&Rep=' + id + '&From=' + selectedStartDate + '&To=' + selectedEndDate);
//            $(this).parent().parent().find('.ccrep-amount').toggle();
//        });
//    }

    function SetLinkofDetailsforClosing() {
        var linkPrefix = $('#MetricDetailLinkInputHidden').val();
        $("#GlobalMetricsClosingPercentageDiv .ccrepid-input-hidden").each(function() {
            var id = $(this).val();
            $(this).parent().find('.detail-anchor').attr('href', linkPrefix + '?Type=closing&Rep=' + id + '&From=' + selectedStartDate + '&To=' + selectedEndDate);
            $(this).parent().parent().find('.ccrep-amount').toggle();
        });
    }

    function SetLinkofDetailsforASR() {
        var linkPrefix = $('#MetricDetailLinkInputHidden').val();
        $("#GlobalMetricsAverageSalesDiv .ccrepid-input-hidden").each(function() {
            var id = $(this).val();
            $(this).parent().find('.detail-anchor').attr('href', linkPrefix + '?Type=asr&Rep=' + id + '&From=' + selectedStartDate + '&To=' + selectedEndDate);
            $(this).parent().parent().find('.ccrep-amount').toggle();
        });
    }

</script>

<script type="text/javascript">

    var personalStatisticsDiv = $('#PersonalStatisticsDiv');

    $(function() {
        SetFilterDatesForMetrics();
        $('#StartDateTextBox').datepicker();
        $('#EndDateTextBox').datepicker();
        $('#DateRangeDDL').change
        (
            function() {
                if ($(this).val() == 'SelectDateRange') {
                    $('#CustomDateRangeDiv').fadeIn();
                }
                else {
                    $('#CustomDateRangeDiv').fadeOut();
                }
            }
        );
    });

    var selectedStartDate, selectedEndDate;

    function SetFilterDatesForMetrics() {
        var startDate;
        var endDate = '<%= DateTime.Now.ToString() %>';
        switch ($('#DateRangeDDL').val()) {
            case 'Today':
                startDate = '<%= DateTime.Today.ToString() %>';
                break;
            case 'ThisWeek':
                startDate = '<%= DateTime.Today.GetFirstDayOfWeek().ToString() %>';
                break;
            case 'ThisMonth':
                startDate = '<%= DateTime.Today.GetFirstDayOfMonth().ToString() %>';
                break;
            case 'Last7Days':
                startDate = '<%= DateTime.Today.AddDays(-7).ToString() %>';
                break;
            case 'Last30Days':
                startDate = '<%= DateTime.Today.AddDays(-30).ToString() %>';
                break;
            case 'LastQuarter':
                startDate = '<%= DateTime.Today.GetFirstDayOfQuarter().AddDays(-2).GetFirstDayOfQuarter().ToString() %>';
                endDate = '<%= DateTime.Today.GetFirstDayOfQuarter().AddDays(-1).ToString() %>';
                break;
            case 'ThisQuarter':
                startDate = '<%= DateTime.Today.GetFirstDayOfQuarter().ToString() %>';
                break;
            case 'SelectDateRange':
                startDate = $('#StartDateTextBox').val();
                endDate = $('#EndDateTextBox').val();
                if (!IsValidDate(startDate)) {
                    alert('Please enter a valid start date.');
                    $('#StartDateTextBox').focus();
                    return;
                }
                else if (!IsValidDate(endDate)) {
                    alert('Please enter a valid end date.');
                    $('#EndDateTextBox').focus();
                    return;
                }
                startDate += ' 12:00:00 AM';
                endDate += ' 11:59:59 PM';
                break;
            default:
                return;
        }

        selectedStartDate = startDate;
        selectedEndDate = endDate;

        //GetCallCenterRepMetrics(startDate, endDate);
        GetGlobalMetrics(startDate, endDate);
    }

</script>

<script type="text/javascript">

    function GetCallCenterRepMetrics(startDate, endDate) {
        if ('<%= UserRole %>' != '<%= Falcon.App.Core.Enum.Roles.CallCenterRep %>')
            return;

        $('#StatisticsWrapperDiv').fadeIn('slow');
        GetPersonalStatistics(startDate, endDate);
    }

    function GetPersonalStatistics(startDate, endDate) {
        
        personalStatisticsDiv.html('');
        personalStatisticsDiv.addClass('loading');
        var messageUrl = '/App/Controllers/CallCenterRepMetricController.asmx/GetMetricForUser';
        var parameter = "{'callCenterCallCenterUserId':'<%= CallCenterCallCenterUserId %>',";
        parameter += "'startDate':'" + startDate + "',";
        parameter += "'endDate':'" + endDate + "'}";
        var successFunction = function (returnData) {
            
            personalStatisticsDiv.html('');
            var bookingPercentage = (returnData.d.BookingPercentage * 100).toFixed(2);
            //            var spouseBookingPercentage = (returnData.d.SpouseBookingPercentage * 100).toFixed(2);
            var closingPercentage = (returnData.d.ClosingPercentage * 100).toFixed(2);
            var averageSaleAmount = returnData.d.AverageSaleAmount.toFixed(2);
            ShowPersonalStatistics(bookingPercentage, 0, closingPercentage, averageSaleAmount);
        };
        var numberOfRecordsFunction = function(returnData) { return returnData.d == null ? 0 : 1; };
        var noRecordsFunction = function() { alert('No statistics found.'); };
        var completeFunction = function() { personalStatisticsDiv.removeClass('loading'); };
        var errorFunction = function() { alert('Your personal statistics could not be loaded due to an internal server error.'); };
        LoadAjax(messageUrl, parameter, successFunction, errorFunction, completeFunction, numberOfRecordsFunction, noRecordsFunction, false);
    }

    function ShowPersonalStatistics(bookingPercentage, spouseBookingPercentage, closingPercentage, averageSaleAmount) {
        var bookingPercentageClueTipText = "Percentage of incoming prospect calls that you converted to customers with screening appointments " +
            "[customers/incoming prospect calls = booking percentage]. This metric demonstrates your effectiveness of turning an incoming " +
            "prospect call to a customer with a screening appointment.";
//        var spouseBookingPercentageClueTipText = "Percentage of customers that you booked which also booked a " +
//            "spousal appointment [customers booked with spouse/total customers booked = spousal booking percentage]." +
//            "This metric demonstrates your effectiveness of selling a booked customer on the idea of booking their spouse a screening appointment.";
        var closingPercentageClueTipText = "Percentage of customers that prepay as follows [prepaid customers/customers = closing percentage]. " +
            "This metric demonstrates your effectiveness in getting customers with a screening appoointment to prepay.";
        var averageSaleAmountClueTipText = "Average Revenue Per Client for the customers you booked " +
            "[total revenue booked/total # of customers = average sales].  This metric demonstrates your effectiveness in upselling.";

        personalStatisticsDiv.append('<span class="my_mtrcs" id="BookingPercentagePersonalStatisticsDiv" title="Booking Percentage|' + bookingPercentageClueTipText
            + '"><strong>Booking Percentage:</strong> ' + bookingPercentage + '%</span>');
        personalStatisticsDiv.append('<span class="my_mtrcs" id="ClosingPercentagePersonalStatisticsDiv" title="Closing Percentage|' + closingPercentageClueTipText
            + '"><strong>Closing Percentage:</strong> ' + closingPercentage + '%</span>');
        personalStatisticsDiv.append('<span class="my_mtrcs" id="AverageSaleAmountPersonalStatisticsDiv" title="Average Sales Amount|' + averageSaleAmountClueTipText
            + '"><strong>Average Sales Amount:</strong> ' + averageSaleAmount + '</span>');
//        personalStatisticsDiv.append('<span class="my_mtrcs" id="SpouseBookingPercentagePersonalStatisticsDiv" title="Spouse Booking Percentage|' + spouseBookingPercentageClueTipText
//            + '"><strong>Spouse Booking Percentage:</strong> ' + spouseBookingPercentage + '%</span>');

        $('#BookingPercentagePersonalStatisticsDiv').cluetip({ splitTitle: '|' });
        //$('#SpouseBookingPercentagePersonalStatisticsDiv').cluetip({ splitTitle: '|' });
        $('#ClosingPercentagePersonalStatisticsDiv').cluetip({ splitTItle: '|' });
        $('#AverageSaleAmountPersonalStatisticsDiv').cluetip({ splitTItle: '|' });
    }

    function GetGlobalMetrics(startDate, endDate) {
        var globalMetricsBookingPercentageDiv = $('#GlobalMetricsBookingPercentageDiv');
        globalMetricsBookingPercentageDiv.html('').addClass('loading');
        //var globalMetricsSpouseBookingPercentageDiv = $('#GlobalMetricsSpouseBookingPercentageDiv');
        //globalMetricsSpouseBookingPercentageDiv.html('').addClass('loading');
        var globalMetricsClosingPercentageDiv = $('#GlobalMetricsClosingPercentageDiv');
        globalMetricsClosingPercentageDiv.html('').addClass('loading');
        var globalMetricsAverageSalesDiv = $('#GlobalMetricsAverageSalesDiv');
        globalMetricsAverageSalesDiv.html('').addClass('loading');
        var messageUrl = '/App/Controllers/CallCenterRepMetricController.asmx/GetMetricsForAllUsers';
        var parameter = "{'startDate':'" + startDate + "',";
        parameter += "'endDate':'" + endDate + "'}";
        var successFunction = function(returnData) {
            globalMetricsBookingPercentageDiv.setTemplateURL('/App/Templates/BookingPercentageGlobalMetrics.html');
            globalMetricsBookingPercentageDiv.setParam('callCenterCallCenterUserId', '<%= CallCenterCallCenterUserId %>');
            globalMetricsBookingPercentageDiv.processTemplate(returnData.d.BookingPercentageViewData);
            
            var bookingPercentage = 0;
            $.each(returnData.d.BookingPercentageViewData, function(){
                if (this.FirstValue.CallCenterRepId == '<%= CallCenterCallCenterUserId %>')
                {
                    bookingPercentage = (this.SecondValue.BookingPercentage * 100).toFixed(2);
                }
            });

            // TODO: Move to CSS
            $('#BookingPercentageGlobalMetricsTable th').css('background-color', '#DDF0F7');
            $('#BookingPercentageGlobalMetricsTable tr:even').css('background-color', '#EFF8FD');
            $('#BookingPercentageGlobalMetricsTable tr:odd').css('background-color', '#F8FCFF');

            //globalMetricsSpouseBookingPercentageDiv.setTemplateURL('/App/Templates/SpouseBookingPercentageGlobalMetrics.html');
//            globalMetricsSpouseBookingPercentageDiv.setParam('callCenterCallCenterUserId', '<%= CallCenterCallCenterUserId %>');
//            globalMetricsSpouseBookingPercentageDiv.processTemplate(returnData.d.SpouseBookingPercentageViewData);

//            var spouseBookingPercentage = 0;
//            $.each(returnData.d.SpouseBookingPercentageViewData, function(){
            //                if(this.FirstValue.CallCenterRepId == '<%= CallCenterCallCenterUserId %>')
//                {
//                    spouseBookingPercentage = (this.SecondValue.SpouseBookingPercentage * 100).toFixed(2);
//                }
//            });

            // TODO: Move to CSS
//            $('#SpouseBookingPercentageGlobalMetricsTable th').css('background-color', '#DDF0F7');
//            $('#SpouseBookingPercentageGlobalMetricsTable tr:even').css('background-color', '#EFF8FD');
//            $('#SpouseBookingPercentageGlobalMetricsTable tr:odd').css('background-color', '#F8FCFF');

            globalMetricsClosingPercentageDiv.setTemplateURL('/App/Templates/ClosingPercentageGlobalMetrics.html');
            globalMetricsClosingPercentageDiv.setParam('callCenterCallCenterUserId', '<%= CallCenterCallCenterUserId %>');
            globalMetricsClosingPercentageDiv.processTemplate(returnData.d.ClosingPercentageViewData);

            var closingPercentage = 0;
            $.each(returnData.d.ClosingPercentageViewData, function(){
                if (this.FirstValue.CallCenterRepId == '<%= CallCenterCallCenterUserId %>')
                {
                    closingPercentage = (this.SecondValue.ClosingPercentage * 100).toFixed(2);
                }
            });

            // TODO: Move to CSS
            $('#ClosingPercentageGlobalMetricsTable th').css('background-color', '#DDF0F7');
            $('#ClosingPercentageGlobalMetricsTable tr:even').css('background-color', '#EFF8FD');
            $('#ClosingPercentageGlobalMetricsTable tr:odd').css('background-color', '#F8FCFF');

            globalMetricsAverageSalesDiv.setTemplateURL('/App/Templates/AverageSalesGlobalMetrics.html');
            globalMetricsAverageSalesDiv.setParam('callCenterCallCenterUserId', '<%= CallCenterCallCenterUserId %>');
            globalMetricsAverageSalesDiv.processTemplate(returnData.d.AverageSaleAmountViewData);

            var asrValue = 0;
            $.each(returnData.d.AverageSaleAmountViewData, function(){
                if(this.FirstValue.CallCenterRepId == '<%= CallCenterCallCenterUserId %>')
                {
                    asrValue = FormatCurrency(this.SecondValue.AverageSaleAmount);
                }
            });
            
            // TODO: Move to CSS
            $('#AverageSalesGlobalMetricsTable th').css('background-color', '#DDF0F7');
            $('#AverageSalesGlobalMetricsTable tr:even').css('background-color', '#EFF8FD');
            $('#AverageSalesGlobalMetricsTable tr:odd').css('background-color', '#F8FCFF');
            
            if ('<%= UserRole %>' == '<%= Falcon.App.Core.Enum.Roles.CallCenterRep %>')
            {
                $('#StatisticsWrapperDiv').fadeIn('slow');
                personalStatisticsDiv.html('');
                ShowPersonalStatistics(bookingPercentage, 0, closingPercentage, asrValue);
            }
            
            SetLinkofDetailsforBooking();
//            SetLinkofDetailsforSpouseBooking();
            SetLinkofDetailsforClosing();
            SetLinkofDetailsforASR();
        }
        var numberOfRecordsFunction = function(returnData) { return returnData.d == null ? 0 : 1; }
        var noRecordsFunction = function() { alert('No global metrics found for the selected period.'); }
        var completeFunction = function() {
            globalMetricsBookingPercentageDiv.removeClass('loading');
            globalMetricsClosingPercentageDiv.removeClass('loading');
            globalMetricsAverageSalesDiv.removeClass('loading');
//            globalMetricsSpouseBookingPercentageDiv.removeClass('loading');
        }
        var errorFunction = function() { alert('Global metrics could not be loaded due to an internal server error.'); }
        LoadAjax(messageUrl, parameter, successFunction, errorFunction, completeFunction, numberOfRecordsFunction, noRecordsFunction, false);
    }
        
</script>

