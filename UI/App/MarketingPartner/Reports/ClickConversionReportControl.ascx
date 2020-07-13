<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClickConversionReportControl.ascx.cs" Inherits="Falcon.App.UI.App.MarketingPartner.Reports.ClickConversionReportControl" %>
<style type="text/css">
    #myMessage .row1 { background-color: #FFFFFF; }
    #myMessage .row2 { background-color: #EFF8FD; }
    label { display: inline-block; width: 100px; font-weight: bold; }    
    .akey { text-decoration: underline; }
</style>
<link rel="Stylesheet" type="text/css" href="<%= ResolveUrl("~/App/jquery/css/ui-lightness/jquery-ui-1.7.2.custom.css") %>"></link>
<script type="text/javascript" src="<%= ResolveUrl("~/App/JavascriptFiles/common.js") %>"></script>
<script type="text/javascript" src="<%= ResolveUrl("~/App/JavascriptFiles/CommonDate.js") %>"></script>
<%--TODO: *Jquery include Remove*--%>
<script type="text/javascript" src="<%= ResolveUrl("../../jquery/js/jquery-1.3.2.min.js") %>"></script>
<script type="text/javascript" src="<%= ResolveUrl("../../jquery/js/jquery-ui-1.7.2.custom.min.js") %>"></script>
<script type="text/javascript" src="<%= ResolveUrl("../../jquery/js/jquery-jtemplate.js") %>"></script>
<script type="text/javascript"><!--
    function AjaxCall(containerDiv, messageUrl, parameter, successFunction, errorMessage)
    {
        parameter = parameter || '{}';
        	    
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
        
    function ResolutionString(width, height)
    {
        return "Resolution: " + width + " by " + height;
    }    

    function LoadClickConversionReportPage(campaignId, startTime, endTime, page, size)
    {
        $("#myMessage").empty();
	    AjaxCall("myMessage", "<%= MethodUrl %>", "{'begin': " + page*size + ", 'count': " + size + ", 'startTime': '" + startTime + "', 'endTime': '" + endTime +"', 'campaignId': " + campaignId + "}",
		    function(data) {
		        data.IsFranchisor = !campaignId;
		        $("#myMessage").processTemplate(data);
		    },
		    "There was an error retrieving the report data from the server."
	    );
    }
    
    function ClickConversionReport()
    {
        var startDateField = $("#StartDateTextBox");
        var endDateField = $("#EndDateTextBox");
        
        if (!ValidateDateRangeControls(startDateField, endDateField)) {
            return false;
        }
        
        var beginDate = startDateField.val();
        var endDate = endDateField.val();
        
        InitClickConversionReport(beginDate, endDate);
    }
    
    function InitClickConversionReport(beginDate, endDate)
    {        
        var campaignId = <%= CampaignId %>;
        var pageSize = 10;
        
        LoadClickConversionReportPage(campaignId, beginDate, endDate, 0, pageSize);
        
        var csvUrl = '<%= ResolveUrl("~/App/MarketingPartner/Reports/ClickConversionReportCSV.ashx") %>' + "?campaignId=" + campaignId;
        $("#ccrCSVExportLink").attr("href", csvUrl);
        
        $.ajax({
            "type": "POST",
            "url": "<%= CountMethodUrl %>",
            data: '{"startTime": "'+beginDate+'", "endTime": "'+endDate+'", "campaignId": '+campaignId+'}',
		    contentType: 'application/json; charset=utf-8',
		    dataType: 'json',
		    success: function(data) {
		        var count = data.d;
		        
		        var pagers = $(".clickConversionPager").empty();
		        
		        var clickFun = function(i)
		        {
		            return "LoadClickConversionReportPage("+campaignId+", '"+beginDate+"', '"+endDate+"', "+i+", "+pageSize+"); return false";
		        }
		        
		        for (var i = 0; i * pageSize < count; ++i)
		        {
		            pagers.append('<a href="#" onclick="' + clickFun(i) + '">' + (i+1) + '</a> ');
		        }
		    },
		    failure: function() {
		        window.alert("Couldn't get number of campaigns from server.");
		    }
        });
    }
    
    function CustomerType(record)
    {
        switch(true)
        {
            case !!record.ProspectCustomer:
                return "Prospect Customer";
            case !!record.Customer:
                return "Customer";
            case !!record.EventCustomer:
                return "Event Customer";
            default: return "";
        }
    }

    jQuery (
        function ($) {
            $('#StartDateTextBox').datepicker();
            $('#EndDateTextBox').datepicker();
        
            $("#myMessage").setTemplateElement("template");
            InitClickConversionReport('1/1/1903', '1/1/2010');
        }
    );
//--></script>


<div><label for="StartDateTextBox" accesskey="b"><span class="akey">B</span>egin Date:</label> <input id="StartDateTextBox" value="8/1/2009" /></div>
<div><label for="EndDateTextBox" accesskey="n">E<span class="akey">n</span>d Date:</label> <input id="EndDateTextBox" value="<%= DateTime.Now.ToShortDateString() %>" /></div>
<button accesskey="s" type="submit" onclick="ClickConversionReport(); return false"><span class="akey">S</span>how Report Within Dates</button>

<p style="display:none"><textarea id="template" rows="0" cols="0"><!--
<table width="100%">	    
    <tr>
        {#if $T.IsFranchisor}<th>Campaign Name</th>{#/if}
        <th>Click</th>
        <th>Conversion To</th>
        <th>Customer</th>
    </tr>
    {#foreach $T.d as record}
    <tr class="{#cycle values=['row1', 'row2']}">
        {#if $T.IsFranchisor}
            <td width="*">
                {$T.record.Campaign.Name}
            </td>
        {#/if}
        <td width="*">
            {FormatTimestamp($T.record.ClickTimestamp)}
            {#if $T.record.Click.ResolutionWidth > 0}
                <br />{ResolutionString($T.record.Click.ResolutionWidth, $T.record.Click.ResolutionHeight)}
            {#/if}
        </td>
        <td width="*">
            {CustomerType($T.record)}
        </td>
        <td width="*">
            {#if ($T.record.ProspectCustomer)}
                <h3>{$T.record.ProspectCustomer.FirstName} {$T.record.ProspectCustomer.LastName}</h3>
            {#/if}
        
            {#if ($T.record.Customer)}
                <h3>{$T.record.Customer.Name.FullName}</h3>
            {#/if}
                    
            {#if ($T.record.EventCustomer)}
                <h3>{$T.record.EventCustomer.FirstName} {$T.record.EventCustomer.LastName}</h3>
                <div class="eventName">{$T.record.EventCustomer.EventName}</div>
                <div class="packageName">{$T.record.EventCustomer.PackageName} (${$T.record.EventCustomer.PaymentAmount})</div>
                <div class="paymentAmount">${$T.record.EventCustomer.PaidAmount} / ${$T.record.EventCustomer.PaymentNet}</div>
            {#/if}
        </td>
    </tr>
    {#/for}
</table>
--></textarea></p>


<div id="myMessage" style="clear: both;"></div>

<div><a id="ccrCSVExportLink">Export As CSV</a> Go to Page: <span class="clickConversionPager"></span></div>