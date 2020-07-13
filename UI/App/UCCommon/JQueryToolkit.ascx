<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JQueryToolkit.ascx.cs"
    Inherits="Falcon.App.UI.App.UCCommon.JQueryToolkit" %>
<%--This script is written below the page. This is the reason JTip was not appearing in Public site--%>
<%--<script type="text/javascript" src="<%=ResolveUrl("~/App/jquery/js/jquery-1.5.1.min.js")%>"></script>--%>
<script type="text/javascript" src="<%=ResolveUrl("~/App/jquery/js/jquery.alphanumeric.js")%>"></script>
<script type="text/javascript" src="<%=ResolveUrl("~/App/jquery/js/Formatter.js")%>"></script>
<script type="text/javascript" src="<%=ResolveUrl("~/App/jquery/js/jquery.clipboard.min.js")%>"></script>
<% if (IncludeJQueryValidators)
   {%>
<script type="text/javascript" src="<%=ResolveUrl("~/App/jquery/js/jquery.validate.js") %>"></script>
<% }

   if (IncudeJQueryAutoComplete)
   {%>
<script type="text/javascript" src="<%=ResolveUrl("~/App/jquery/js/jQuery.autoCompleteExtender.js") %>"></script>
<link type="text/css" href="<%=ResolveUrl("~/App/jquery/css/AutoComplete/auto-search.css") %>"
    rel="Stylesheet" />
<% }

   if (IncludeJQueryCorner)
   { %>
<script type="text/javascript" src="<%=ResolveUrl("~/App/jquery/js/jquery.corner.js")%>"></script>
<% }

   if (IncludeJQueryUI)
   { %>
<link type="text/css" href="/Content/Styles/jquery-ui-1.8.12.custom.css" rel="Stylesheet" />
<script type="text/javascript" src="/Scripts/jquery-ui-1.8.12.custom.min.js"></script>
<%--This tag contains the code to attach date picker for date of birth text boxes.--%>
<%--This code is written at one place so that can be modified one time only. --%>
<%--All we need to do is attch date-picker-dob class to the text box control for date of birth. --%>
<script type="text/javascript" language="javascript">

    $(document).ready(function () {
        var currentDate = new Date();

        $(".date-picker-dob").datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: ("1900:" + currentDate.getFullYear()),
            defaultDate: new Date("01/01/1950"),
            maxDate: currentDate,
            minDate: new Date("01/01/1900")
        });

        $(".date-picker").datepicker({
            changeMonth: true,
            changeYear: true,
            defaultDate: currentDate,
            minDate: new Date("01/01/1950")
        });
    });

</script>
<% }

   if (IncludeJQueryMaskInput)
   { %>
<script type="text/javascript" src="<%=ResolveUrl("~/App/jquery/js/jquery.maskedinput-1.2.2.js")%>"></script>
<% }

   if (IncludeSexyComboBox)
   {
%>
<script type="text/javascript" src="<%=ResolveUrl("~/App/jquery/js/jquery.sexy-combo-2.0.6.js") %>"></script>
<link type="text/css" href="<%=ResolveUrl("~/App/jquery/css/sexy-combo.css") %>"
    rel="Stylesheet" />
<link type="text/css" href="<%=ResolveUrl("~/App/jquery/css/sexy.css") %>" rel="Stylesheet" />
<% }

 if (IncludeJQueryThickBox)
 { %>
<script type="text/javascript" src="<%=ResolveUrl("~/App/jquery/js/thickbox-compressed.js")%>"></script>
<script type="text/javascript" src="<%=ResolveUrl("~/App/jquery/js/thickbox-iframeEscFix.js")%>"></script>
<link type="text/css" href="<%=ResolveUrl("~/App/jquery/css/ThickBox/thickbox.css")%>"
    rel="Stylesheet" />
<% }

   if (IncludeJQueryCookie)
   { %>
<script type="text/javascript" src="<%=ResolveUrl("~/App/jquery/js/jquery.cookie.js")%>"></script>
<% }

   if (IncludeJTemplate)
   { %>
<script type="text/javascript" src="<%=ResolveUrl("~/App/jquery/js/jquery-jtemplate.js")%>"></script>
<% } %>
<%if (IncudeJQuerySelectable)
  { %>
<link type="text/css" href="<%=ResolveUrl("~/App/jquery/css/JQuery-Selectable/Selectable.css")%>"
    rel="Stylesheet" />
<% } %>
<%if (IncudeJQueryJTip)
  { %>
<link type="text/css" href="<%=ResolveUrl("~/App/jquery/css/JTip/jquery.cluetip.css")%>"
    rel="Stylesheet" />
<script type="text/javascript" src="<%=ResolveUrl("~/App/jquery/js/jquery.cluetip.js")%>"></script>
<script type="text/javascript" src="<%=ResolveUrl("~/App/jquery/js/jquery.hoverIntent.js")%>"></script>
<% } %>
<%if (IncludeJQueryBounceBox)
  {%>
<script type="text/javascript" src="<%=ResolveUrl("~/App/jquery/js/jquery.bouncebox.1.0.js") %>"></script>
<script type="text/javascript" src="<%=ResolveUrl("~/App/jquery/js/jquery.easing.1.3.js") %>"></script>
<link type="text/css" href="<%=ResolveUrl("~/App/jquery/css/BounceBox/BounceBox.css") %>"
    rel="Stylesheet" />
<% }%>
<%if (IncludeJQueryWaterMark)
  {%>
<script type="text/javascript" src="<%=ResolveUrl("~/App/jquery/js/jquery.bb.watermark.js") %>"></script>
<% }%>
<% if (IncludeAjax || IncludeJTemplate)
   { %>
<script type="text/javascript">
function MakeAjaxCall(messageUrl, parameter, successFunction, numberOfRecords)
{
    MakeAjaxCall(messageUrl, parameter, successFunction, numberOfRecords, 1, 1, null, null);
}

function MakeAjaxCall(messageUrl, parameter, successFunction, numberOfRecords, pageToFetch, pageSize,
    nextPageFunction, prevPageFunction)
{
    $.ajax
    ({
        type: "POST",
        url: messageUrl,
        data: parameter,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(returnData)
        {
            if (numberOfRecords(returnData) != 0)
            {
                successFunction(returnData);
                <% if(IncludePaging) { %>
                    var lastPage = Math.ceil(numberOfRecords(returnData) / pageSize);
                    UpdatePaging(pageToFetch, lastPage, nextPageFunction, prevPageFunction);
                <% } %>
            }
            else
            {
                DisplayNoRecordsFoundMessage('No Records Found');
            }
        },
        error: function()
        {
            DisplayErrorMessage();
        }
    });
}

function ApplyTemplate(templateData, templateUrl, tableId)
{
    ApplyTemplate(templateData, templateUrl, tableId, 'True');
}

function ApplyTemplate(templateData, templateUrl, tableId, canSeeEarnings)
{
    $('#' + divContainingTableId).setTemplateURL(templateUrl);
    $('#' + divContainingTableId).processTemplate(templateData);
    if (canSeeEarnings == 'False') {
        HideAmounts();
    }
    // TODO: Move to CSS
    $('#' + tableId + " th").css("background-color", "#DDF0F7");
    $('#' + tableId + " tr:even").css("background-color", "#EFF8FD");
    $('#' + tableId + " tr:odd").css("background-color", "#F8FCFF");
}

function HideAmounts() {
    $('.amt').hide();
}

function DisplayProgressIndication(tableId, divContainingTableId, numberOfColumnsInTable)
{
    $('#PagingDiv').hide();

    // Clean up our event handlers to avoid memory leaks.
    $('#PrevPage').unbind();
    $('#NextPage').unbind();

    DisplayInitialTable(tableId, divContainingTableId, numberOfColumnsInTable);
}

function DisplayNoRecordsFoundMessage(message)
{
    $('#' + divContainingTableId).
                html('<div class="divnoitemfound_mvpe" style="margin-top: 15px;"><p class="divnoitemtxt_mvpe"></p></div>');
    $('#' + divContainingTableId + ' p').html('<span class="orngbold18_default">' + message + '</span>');
}

function DisplayErrorMessage()
{
    DisplayNoRecordsFoundMessage('An Internal Server Error Occurred');
}

function DisplayInitialTable(tableId, divContainingTableId, numberOfColumnsInTable)
{
    $('#' + divContainingTableId).html('<table id="' + tableId + '" class="divgrid_clnew" cellspacing="3" width="100%"></table>');
    $('#' + tableId).html('<thead></thead><tbody></tbody>');
    $('#' + tableId + ' thead').html('<tr><th></th></tr>');
    $('#' + tableId + ' tbody').html('<tr><td colspan="' + numberOfColumnsInTable + '"></td></tr>');
    $('#' + tableId + ' tbody td').addClass('loading');
}
</script>
<script type="text/javascript" src="<%=ResolveUrl("~/App/jquery/js/jquery.json-2.2.min.js") %>"></script>
<% }

   if (IncludePaging)
   { %>
<script type="text/javascript">
    function UpdatePaging(page, lastPage, nextPageFunction, prevPageFunction) {
        HidePagingLinks();
        if (page != lastPage) {

            $('#NextPage').show();
            $('#NextPage').attr('href', '#');
            $('#NextPage').click(function () { nextPageFunction(); });
        }

        if (page != 1) {
            $('#PrevPage').show();
            $('#PrevPage').attr('href', '#');
            $('#PrevPage').click(function () { prevPageFunction(); });
        }

        if (page != 1 && page != lastPage) {
            $('#PagingLinksSeparator').show();
        }
    }

    function HidePagingLinks() {
        $('#NextPage').hide();
        $('#PrevPage').hide();
        $('#PagingLinksSeparator').hide();
    }
</script>
<% } %>
<script type="text/javascript">
    function AjaxCall(containerDiv, messageUrl, parameter, successFunction, errorMessage) {
        var numberOfRecordsFunction = function (returnData) {
            return 1;
        }
        if (jQuery.isFunction(numberOfRecordsFunction)) {
            alert("It is a function!");
        }
        AjaxCall(containerDiv, messageUrl, parameter, successFunction, errorMessage, numberOfRecordsFunction);
    }

    function AjaxCall(containerDiv, messageUrl, parameter, successFunction, errorMessage, numberOfRecordsFunction) {
        if (parameter == '') {
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
        success: function (returnData) {
            if (numberOfRecordsFunction(returnData) > 0) {
                successFunction(returnData);
            }
            else {
                $('#' + containerDiv).
                    html('<div class="divnoitemfound_mvpe" style="margin-top: 15px; margin-left: 0px"><p class="divnoitemtxt_mvpe"></p></div>');
                $('#' + containerDiv + ' p').html('<span class="orngbold18_default">No Records Found</span>');
            }
            $('#' + containerDiv).removeClass('loading');
        },
        error: function () {
            alert(errorMessage);
            $('#' + containerDiv).removeClass('loading');
        }
    });
    }

    function LoadAjax(messageUrl, parameter, successFunction, errorFunction, completeFunction, numberOfRecordsFunction, noRecordsFunction) {
        LoadAjax(messageUrl, parameter, successFunction, errorFunction, completeFunction, numberOfRecordsFunction, noRecordsFunction, true);
    }

    function LoadAjax(messageUrl, parameter, successFunction, errorFunction, completeFunction, numberOfRecordsFunction, noRecordsFunction, cache) {
        $.ajax
    ({
        type: 'POST',
        url: messageUrl,
        data: parameter,
        cache: cache,
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (returnData) {
            if (numberOfRecordsFunction(returnData) > 0) {
                successFunction(returnData);
            }
            else {
                noRecordsFunction();
            }
        },
        error: function (a, b) { errorFunction(); },
        complete: function () { completeFunction(); }
    });
    }

    function IsValidDate(sDate) {
        var re = /^\d{1,2}\/\d{1,2}\/\d{4}$/
        if (re.test(sDate)) {
            var dArr = sDate.split("/");
            var d = new Date(sDate);
            return d.getMonth() + 1 == dArr[0] && d.getDate() == dArr[1] && d.getFullYear() == dArr[2];
        }
        return false;
    }

</script>
