<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master"
    AutoEventWireup="true" Inherits="App_Common_Calander" CodeBehind="Calendar.aspx.cs" %>
<%@ Register Src="~/App/UCCommon/JQueryToolkit.ascx" TagPrefix="uc" TagName="JQueryToolkit" %>
<%@ Register Src="~/App/Common/ucYearCalendar.ascx" TagName="cc2" TagPrefix="cc2" %>
<%@ Register Src="~/App/Common/ucWeekCalendar.ascx" TagName="cc3" TagPrefix="cc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc:JQueryToolkit ID="JQueryTookit" runat="server" IncludeAjax="true" IncludeJQueryUI="true"
        IncudeJQueryJTip="true" />
    <style type="text/css">
        .wrapper_pop
        {
            float: left;
            width: 558px;
            padding: 10px;
            background-color: #f5f5f5;
        }
        .wrapperin_pop
        {
            float: left;
            width: 534px;
            border: solid 2px #4888AB;
            padding: 10px;
            background-color: #fff;
        }
        .innermain_pop
        {
            float: left;
            width: 524px;
        }
        .enabled
        {
            font-weight: bold;
            cursor: pointer;
            color: #000;
        }
        .disabled
        {
            font-weight: bold;
            cursor: default;
            color: #999;
            text-decoration: none;
        }
        #divloading
        {
            position: fixed;
            top: 320px;
            left: 120px;
        }
        .table-row
        {
            color: #fff;
        }
    </style>
    <script language="javascript" type="text/javascript">

        function ShowBlockedDayFranchisee(BlockedDayFranchisee, Sender) {
            document.getElementById("BlockedDayDescription").innerHTML = BlockedDayFranchisee;

            var Sender1 = document.getElementById(Sender);
            showTipBubble(Sender1, "BlockedDay");

        }

        function findPos(obj, TypeOfPopUp) {

            var curleft = curtop = 0;
            var curWidth = obj.offsetWidth;
            var curHeight = obj.offsetHeight;
            if (obj.offsetParent) {
                curleft = obj.offsetLeft
                curtop = obj.offsetTop

                while (obj = obj.offsetParent) {
                    curleft += obj.offsetLeft
                    curtop += obj.offsetTop
                }
            }

            var divLeft;
            var divHeight;
            if (TypeOfPopUp == "Event") {
                var showDiv = document.getElementById('dvEventDescShow');
            }
            else if (TypeOfPopUp == "Task") {
                var showDiv = document.getElementById('dvTaskDescShow');
            }
            else if (TypeOfPopUp == "Meeting") {
                var showDiv = document.getElementById('dvMeetingDescShow');
            }
            else if (TypeOfPopUp == "Call") {
                var showDiv = document.getElementById('dvCallDescShow');
            }
            else if (TypeOfPopUp == "BlockedDay") {
                var showDiv = document.getElementById('dvBlockedDayDescShow');
            }
            else if (TypeOfPopUp == "Seminar") {
                var showDiv = document.getElementById('dvSeminarDescShow');
            }

            var arrowposition = "";
            var roundposition = "";
            var objectWidth = showDiv.offsetWidth * 1.07;
            var objectHegiht = showDiv.offsetHeight * 1.07;

            if (screen.availWidth > curleft + curWidth + objectWidth)
            { divLeft = curleft + (curWidth) / 2; arrowposition = "left"; }
            else
            { divLeft = curleft - showDiv.offsetWidth + 10; arrowposition = "right"; }

            if (screen.availHeight < curtop + curHeight + objectHegiht) {
                divHeight = curtop + curHeight / 2;
                arrowposition = arrowposition + "top";
                roundposition = "Top";
            }
            else {
                divHeight = curtop - showDiv.offsetHeight + 20;
                arrowposition = arrowposition + "down";
                roundposition = "Bottom";
            }

            document.getElementById(TypeOfPopUp + "Top").className = "roundcorner_roundmbox";
            document.getElementById(TypeOfPopUp + "Bottom").className = "roundcornerbot_roundmbox";

            document.getElementById(TypeOfPopUp + roundposition).className = arrowposition + "_roundmbox";

            return { left: divLeft, top: divHeight, right: curleft, bottom: curleft };
        }


        function showTipBubble(Package, TypeOfPopUp) {
            var showDiv = document.getElementById('ie5menu');
            if (showDiv.style.display == 'block')
            { return; }
            var bubble;
            if (TypeOfPopUp == "Event") {
                bubble = document.getElementById('dvEventDescShow');
            }
            else if (TypeOfPopUp == "Task") {
                bubble = document.getElementById('dvTaskDescShow');
            }
            else if (TypeOfPopUp == "Meeting") {
                bubble = document.getElementById('dvMeetingDescShow');
            }
            else if (TypeOfPopUp == "Call") {
                bubble = document.getElementById('dvCallDescShow');
            }
            else if (TypeOfPopUp == "BlockedDay") {
                bubble = document.getElementById('dvBlockedDayDescShow');
            }
            else if (TypeOfPopUp == "Seminar") {
                bubble = document.getElementById('dvSeminarDescShow');
            }
            bubble.style.display = 'block';
            bubble.style.position = 'absolute';
            var pos = findPos(Package, TypeOfPopUp);
            bubble.style.top = pos.top + 'px';
            bubble.style.left = pos.left + 'px';

            objIframe1 = document.getElementById('objIframe');
            objIframe1.style.position = "absolute";
            objIframe1.style.left = bubble.offsetLeft + "px";
            objIframe1.style.top = bubble.offsetTop + "px";
            objIframe1.style.height = bubble.offsetHeight + "px";
            objIframe1.style.width = bubble.offsetWidth + "px";
            objIframe1.style.display = 'block';

        }

        function CallPrint() {
            document.getElementById("dvMonth").innerHTML = document.getElementById("spDateRange").innerHTML;
            document.getElementById("dvMonth").style.display = 'block';
            document.getElementById("dvLegands").innerHTML = document.getElementById("spLegands").innerHTML;
            document.getElementById("dvLegands").style.display = 'block';

            var prtContent = document.getElementById("dvCalendar");
            var WinPrint = window.open('', '', 'left=0,top=0,width=1,height=1,toolbar=0,scrollbars=0,status=0');
            WinPrint.document.write(prtContent.innerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
            document.getElementById("dvMonth").style.display = 'none';
            document.getElementById("dvLegands").style.display = 'none';
        }

        function ContextMenu1(senderid) {

            document.onclick = hidemenuie5;

            if ($('#cluetip').length > 0) {
                $('#cluetip').hide();
            }

            if ((senderid == "") || (senderid == null)) {
                var obj = document.getElementById(event.srcElement.parentElement.id);
            }
            else {
                var obj = document.getElementById(senderid);

            }

            if (document.getElementById(selectedCell) != null) {
                document.getElementById(selectedCell).style.backgroundColor = selectedCellClass;
            }

            selectedCell = obj.id;
            selectedCellClass = obj.style.backgroundColor;
            obj.style.backgroundColor = "#FEF2DE";

            var curleft = curtop = 0;
            var curWidth = obj.offsetWidth;
            var curHeight = obj.offsetHeight;
            if (obj.offsetParent) {
                curleft = obj.offsetLeft
                curtop = obj.offsetTop

                while (obj = obj.offsetParent) {
                    curleft += obj.offsetLeft
                    curtop += obj.offsetTop
                }
            }

            var divLeft;
            var divHeight;

            var showDiv = document.getElementById('ie5menu');
            showDiv.style.visibility = "visible"
            showDiv.style.display = 'block';
            showDiv.style.position = 'absolute';

            var objectWidth = showDiv.offsetWidth * 1.07;
            var objectHegiht = showDiv.offsetHeight * 1.07;

            if (screen.availWidth > curleft + curWidth + objectWidth)
            { divLeft = curleft + (curWidth) / 2; }
            else
            { divLeft = curleft - showDiv.offsetWidth + 10; }

            if (screen.availHeight < curtop + curHeight + objectHegiht) {
                divHeight = curtop + curHeight / 2;
            }
            else {
                divHeight = curtop - showDiv.offsetHeight + 50;
            }

            showDiv.style.top = divHeight + 'px';
            showDiv.style.left = divLeft + 'px';
            objIframe1 = document.getElementById('objIframe');
            objIframe1.style.position = "absolute";
            objIframe1.style.left = showDiv.offsetLeft + "px";
            objIframe1.style.top = showDiv.offsetTop + "px";
            objIframe1.style.height = showDiv.offsetHeight + "px";
            objIframe1.style.width = showDiv.offsetWidth + "px";
            objIframe1.style.display = 'block';

            var LinkTasks = document.getElementById("LinkTasks")
            var LinkEvent = document.getElementById("LinkEvent")
            var LinkMeeting = document.getElementById("LinkMeeting")
            var LinkCall = document.getElementById("LinkCall")
            var LinkSeminar = document.getElementById("LinkSeminar")

            var b = senderid;
            var temp = new Array();
            temp = senderid.split('(');
            temp = temp[1].split(')');
            senderid = temp[0];
            LinkTasks.href = "../Franchisor/AddTask.aspx?Referrer=Calendar&Date=" + senderid;
            LinkEvent.href = "/App/Common/CreateEventWizard/Step1.aspx?Type=Create&Referrer=Calendar&Date=" + senderid;
            LinkMeeting.href = "../Franchisor/AddMeeting.aspx?Referrer=Calendar&Date=" + senderid;
            LinkCall.href = "../Franchisor/AddCall.aspx?Referrer=Calendar&Date=" + senderid;
            LinkSeminar.href = "AddSeminars.aspx?Referrer=Calendar&Date=" + senderid;
            var txtBlockDate1 = document.getElementById("<%= this.txtBlockDate.ClientID %>")
            var hfBlockDate = document.getElementById("<%= this.hfBlockDate.ClientID %>")

            if (txtBlockDate1 != null) txtBlockDate1.value = senderid;
            hfBlockDate.value = senderid;
        }

        function ChangeView(view) {
            document.getElementById('4Month').style.display = 'none';
            document.getElementById('Month').style.display = 'none';

            document.getElementById('a4Month').href = "#";
            document.getElementById('aMonth').href = "#";

            document.getElementById(view).style.display = 'block';
            document.getElementById('a' + view).href = 'javascript:void(0);';

        }

        function setContextMenu(strViewType) {

            objCalendar = document.getElementById("divCalendar");

            if (objCalendar == null || objCalendar == "") {
                return;
            }
            objCalendar.oncontextmenu = function () { return false };
            objCalendar.onclick = hidemenuie5;
            document.onclick = hidemenuie5;
            var el = objCalendar.getElementsByTagName("TD");

            for (i = 0; i < el.length; i++) {
                var objTD = el[i];
                if ((objTD.id != "") && (objTD.id != null)) {
                    objTD.oncontextmenu = showmenuie5
                }
            }
        }

        function checkDate() {
            ddlMonth = document.getElementById("<%= this.ddlMonth.ClientID %>");
            ddlYear = document.getElementById("<%= this.ddlYear.ClientID %>");
            if ((checkDropDown(ddlMonth, "Month") == false) || (checkDropDown(ddlYear, "Year") == false)) {
                return false;
            }
        }

        function OpenChild(BlockedDay) {
            var ParmA = BlockedDay;
            var ParmB = '';
            var MyArgs = new Array(ParmA, ParmB);
            var WinSettings = "center:yes;resizable:no;dialogHeight:300px"
            var win = window.openDialog("Block.aspx", "dlg", "");
        }

        function setBlockDay(strBlockOwner, Sender) {

            var Sender1 = document.getElementById(Sender);
            if (strBlockOwner == "Franchisee ") {
                Sender1.style.backgroundColor = "Red";
            }
            else if (strBlockOwner == "Franchisor ") {
                Sender1.parentNode.parentNode.style.backgroundColor = "Red";
            }
        }

        function GridMasterCheck() {
            Grid_MasterCheckBoxClick("<%= this.grdFranchisee.ClientID %>");
            var objtemp = document.createElement("INPUT");
            var numcount = Grid_MultiSelect("<%= this.grdFranchisee.ClientID %>", objtemp);
        }

        function GridChildCheck() {
            Grid_ChildCheckBoxClick("<%= this.grdFranchisee.ClientID %>");

            var objtemp = document.createElement("INPUT");
            var numcount = Grid_MultiSelect("<%= this.grdFranchisee.ClientID %>", objtemp);
        }
        
 
    </script>
    <%--Common function for Calendar--%>
    <script type="text/javascript" language="javascript">
        var currentRole = '<%=CurrentRole %>';

        $.ajaxSetup({ cache: false });
        $.ajaxPrefilter(function (options) {
            options.global = true;
        });


        $(document).ready(function () {
            //debugger;
            BindTerritoriesAndPods();

            $(window).ajaxStop(function () { $(window).unbind('ajaxStop'); ShowMonthCalendar(); });


            $('.sales-rep-ddl').change(function (e) {
                if ($('.sales-rep-ddl option:selected').val() == "0" && currentRole == '<%= Falcon.App.Core.Enum.Roles.FranchisorAdmin %>') {
                    $('.franchisee-ddl option:selected').val() == "0" ? BindTerritoriesForFranchisor() : BindTerritoriesForFranchisee($('.franchisee-ddl option:selected').val());
                    $('.franchisee-ddl option:selected').val() == "0" ? BindPodsForFranchisor() : BindPodsForFranchisee($('.franchisee-ddl option:selected').val());
                }
                else if ($('.sales-rep-ddl option:selected').val() == "0" && currentRole == '<%= Falcon.App.Core.Enum.Roles.FranchiseeAdmin %>') {
                    BindTerritoriesForFranchisee('<%=FranchiseeId %>');
                    BindPodsForFranchisee('<%=FranchiseeId %>');
                }
                else {
                    BindTerritoriesForSalesRep($('.sales-rep-ddl option:selected').val(), '<%=FranchiseeId %>');
                    BindPodsForSalesRep($('.sales-rep-ddl option:selected').val());
                }
            });

            $('.franchisee-ddl').change(function (e) {
                BindSalesRepDropDown($('.franchisee-ddl option:selected').val());
                $('.franchisee-ddl option:selected').val() == "0" ? BindTerritoriesForFranchisor() : BindTerritoriesForFranchisee($('.franchisee-ddl option:selected').val());
                $('.franchisee-ddl option:selected').val() == "0" ? BindPodsForFranchisor() : BindPodsForFranchisee($('.franchisee-ddl option:selected').val());
            });
            $('#divloading').show();
        });

        function LoadCalendarOnPageLoad() {
            if ($('.pod-table tr input:checkbox:checked').length > 0) {
                ShowMonthCalendar();
            }
        }
        
        function BindTerritoriesAndPods() {
            switch (currentRole) {
                case "<%= Falcon.App.Core.Enum.Roles.FranchisorAdmin %>":
                    BindTerritoriesForFranchisor();
                    BindPodsForFranchisor();
                    break;
                case "<%= Falcon.App.Core.Enum.Roles.FranchiseeAdmin %>":
                    BindTerritoriesForFranchisee('<%=FranchiseeId %>');
                    BindPodsForFranchisee('<%=FranchiseeId %>');
                    break;
                case "<%= Falcon.App.Core.Enum.Roles.SalesRep %>":
                    BindTerritoriesForSalesRep('<%=SalesRepId %>', '<%=FranchiseeId %>');
                    BindPodsForSalesRep('<%=SalesRepId %>');
                    break;
            }
            return true;
        }

        // Build the basic calender view.
        CalendarView = new Object();
        CalendarView.ViewType = "Month";
        CalendarView.ViewDate = new Date();
        CalendarView.ViewEvent = $('#ViewEventChk').attr('checked');
        CalendarView.ViewMetting = $('#ViewMeetingChk').attr('checked');
        CalendarView.ViewCall = $('#ViewCallChk').attr('checked');
        CalendarView.ViewTask = $('#ViewTaskChk').attr('checked');
        CalendarView.ViewSeminar = $('#ViewSeminarChk').attr('checked');
        CalendarView.HostName = $('.host-name').val();
        CalendarView.SalesRepId = currentRole == "<%= Falcon.App.Core.Enum.Roles.SalesRep %>" ? '<%=SalesRepId %>' : $('.sales-rep-ddl option:selected').val();
        CalendarView.FranchiseeId = currentRole == "<%= Falcon.App.Core.Enum.Roles.FranchisorAdmin %>" ? $('.franchisee-ddl option:selected').val() : '<%=FranchiseeId %>';
        CalendarView.TerritoryIds = '';
        CalendarView.PodIds = '';

        function LastDayOfMonth(Year, Month) {
            return (new Date((new Date(Year, Month + 1, 1)) - 1));
        }

        function SetCalenderViewObject() {
            CalendarView.ViewEvent = $('#ViewEventChk').attr('checked');
            CalendarView.ViewMetting = $('#ViewMeetingChk').attr('checked');
            CalendarView.ViewCall = $('#ViewCallChk').attr('checked');
            CalendarView.ViewTask = $('#ViewTaskChk').attr('checked');
            CalendarView.ViewSeminar = $('#ViewSeminarChk').attr('checked');
            CalendarView.HostName = $('.host-name').val();
            CalendarView.SalesRepId = currentRole == "<%= Falcon.App.Core.Enum.Roles.SalesRep %>" ? '<%=SalesRepId %>' : $('.sales-rep-ddl option:selected').val();
            CalendarView.FranchiseeId = currentRole == "<%= Falcon.App.Core.Enum.Roles.FranchisorAdmin %>" ? $('.franchisee-ddl option:selected').val() : '<%=FranchiseeId %>';
            CalendarView.TerritoryIds = GetSelectedTerritoryIds() != '' ? GetSelectedTerritoryIds() : '0,';
            CalendarView.PodIds = GetSelectedPodIds() != '' ? GetSelectedPodIds() : '0,';
        }

        function LoadCalendar() {//debugger;
            $('#divloading').show();
            SetCalenderViewObject();
            var queryString = "";
            queryString += "?Type=" + CalendarView.ViewType;
            queryString += "&Date=" + CalendarView.ViewDate.format("mm/dd/yyyy");
            queryString += "&E=" + CalendarView.ViewEvent;
            queryString += "&M=" + CalendarView.ViewMetting;
            queryString += "&C=" + CalendarView.ViewCall;
            queryString += "&T=" + CalendarView.ViewTask;
            queryString += "&S=" + CalendarView.ViewSeminar;
            queryString += "&HN=" + CalendarView.HostName;
            queryString += "&SRI=" + CalendarView.SalesRepId;
            queryString += "&FI=" + CalendarView.FranchiseeId;
            queryString += "&TI=" + CalendarView.TerritoryIds;
            queryString += "&SPI=" + CalendarView.PodIds;
            queryString += "&RN=" + Math.floor(Math.random());

            $('#divCalendar').empty();
            $('#divCalendar').load("AsyncCalendar.aspx" + queryString, null, SuccessCalendarLoad);
            return false;
        }

        function SuccessCalendarLoad(responseText, textStatus, XMLHttpRequest) {//debugger;
            setContextMenu(CalendarView.ViewType);
            switch (CalendarView.ViewType) {
                case "Month":
                    SetMonthCalendarDate();
                    break;
                case "Week":
                    SetWeekCalendarDate();
                    break;
                case "Day":
                    SetDayCalendarDate();
                    break;
                case "Year":
                    SetYearCalendarDate();
                    break;
            }
            $('#divloading').hide();
            $('.jtip').cluetip({ splitTitle: '|', cursor: 'pointer', tracking: true, cluetipClass: 'jtip', arrows: true, dropShadow: false, hoverIntent: false, width: 300 });
        }

        function EnableLinkControls(lnksToEnable) {
            $.each(lnksToEnable, function () {
                $(this).removeClass('disabled');
                $(this).addClass('enabled');
            });
        }

        function DisableLinkControls(linksToDisable) {
            $.each(linksToDisable, function () {
                $(this).addClass('disabled');
                $(this).removeClass('enabled');
            });
        }

        function InvokeService(messageUrl, parameter, successFunction) {
            $('#divloading').show();
            $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    url: messageUrl,
                    data: parameter,
                    cache:false,
                    success: function(result) {
                        successFunction(result);
                        $('#divloading').hide();
                    },
                    error: function(a, b, c) {
                        alert("Oops! something went wrong.");
                        $('#divloading').hide();
                    }
                });
        }

        function ClearFilters() {
            $('.sales-rep-ddl').val('0');
            $('.sales-rep-ddl').change();
            $('.franchisee-ddl').val('0');
            $('.franchisee-ddl').change();
            $('.host-name').val('');
        }
    </script>
    <%--Territory List bind function for Calendar--%>
    <script type="text/javascript" language="javascript">

        function BindSalesRepDropDown(franchiseeId) {
            var successFunction = function(result) {
                AddValuesToDropDown('.sales-rep-ddl', result.d);
            };
            if (franchiseeId != "0") {
                var parameter = "{'franchiseeId':'" + franchiseeId + "'}";
                var messageUrl = '<%=ResolveUrl("~/App/Controllers/FranchiseeUserController.asmx/GetSalesRepresentativesForFranchisee")%>';
            }
            else if (franchiseeId == "0") {
                var parameter = "{}";
                var messageUrl = '<%=ResolveUrl("~/App/Controllers/FranchiseeUserController.asmx/GetAllSalesRepresentatives")%>';
            }
            InvokeService(messageUrl, parameter, successFunction);
        }

        function AddValuesToDropDown(dropDownId, dataToBind) {
            $(dropDownId).empty();
            $(dropDownId).append($('<option></option>').val("0").html("--All--"));
            $.each(dataToBind, function () {
                $(dropDownId).append($('<option></option>').val(this.SalesRepresentativeId).html(this.Name.FullName));
            });
            $(dropDownId).val("0");
        }
    
    </script>
    <%--Territory List bind function for Calendar--%>
    <script type="text/javascript" language="javascript">

        function BindTerritoriesForFranchisor() {
            var successFunction = function (result) {
                AddRowsToTerritoryTable('.territory-table', result.d);
            }
            var parameter = "{}";
            var messageUrl = '<%=ResolveUrl("~/App/Controllers/TerritoryController.asmx/GetFranchisorTerritories")%>';
            InvokeService(messageUrl, parameter, successFunction);
        }

        function BindTerritoriesForFranchisee(franchiseeId) {
            //debugger;
            var successFunction = function(result) {
                AddRowsToTerritoryTable('.territory-table', result.d);
            };
            var parameter = "{'franchiseeId':'" + franchiseeId + "'}";
            var messageUrl = '<%=ResolveUrl("~/App/Controllers/TerritoryController.asmx/GetTerritoriesForFranchisee")%>';
            InvokeService(messageUrl, parameter, successFunction);
        }

        function BindTerritoriesForSalesRep(salesRepresentativeId, franchiseeId) {
            var successFunction = function(result) {
                if ($(result.d).length > 0)
                    AddRowsToTerritoryTable('.territory-table', result.d);
                //                else {
                //                    var parameter = "{'franchiseeId':'" + franchiseeId + "'}";
                //                    var messageUrl = '<%=ResolveUrl("~/App/Controllers/TerritoryController.asmx/GetTerritoriesForFranchisee")%>';
                //                    InvokeService(messageUrl, parameter, successFunction);
                //                }
            };
            var parameter = "{'salesRepId':'" + salesRepresentativeId + "'}";
            var messageUrl = '<%=ResolveUrl("~/App/Controllers/TerritoryController.asmx/GetTerritoriesForSalesRep")%>';
            InvokeService(messageUrl, parameter, successFunction);
        }

        var clonedTerritoryRow = $('.territory-table').find("tr:last").clone();

        function AddRowsToTerritoryTable(tableId, dataToBind) {
            $(tableId).empty();
            clonedTerritoryRow.find('td').attr('style', '');
            $.each(dataToBind, function () {
                var backgroundTerritoryColor = 'rgb(' + Math.floor(Math.random() * 255) + ',' + Math.floor(Math.random() * 255) + ',' + Math.floor(Math.random() * 255) + ')';
                clonedTerritoryRow.find('label').text(this.Name);
                clonedTerritoryRow.find('input:checkbox').val(this.Id);
                clonedTerritoryRow.find('input:checkbox').attr('checked', true);
                clonedTerritoryRow.find('input:checkbox').click(function () { ViewCurrentCalendar(); });
                clonedTerritoryRow.find('span').show();
                $(tableId).append(clonedTerritoryRow);
                clonedTerritoryRow = $(tableId).find("tr:last").clone();
            });
        }

        function GetSelectedTerritoryIds() {
            var selectedTerritoryIds = '';
            $('.territory-table').find("tr input:checkbox:checked").each(function () {
                selectedTerritoryIds += $(this).val() + ',';
            });
            return selectedTerritoryIds;
        }
    </script>
    <%--Pod List bind function for Calendar--%>
    <script type="text/javascript" language="javascript">

        function BindPodsForFranchisor() {
            var successFunction = function(result) {
                AddRowsToPodTable('.pod-table', result.d);
            };
            var parameter = "{}";
            var messageUrl = '<%=ResolveUrl("~/App/Controllers/PodController.asmx/GetAllPods")%>';
            InvokeService(messageUrl, parameter, successFunction);
        }

        function BindPodsForFranchisee(franchiseeId) {
            var successFunction = function(result) {
                AddRowsToPodTable('.pod-table', result.d);
            };
            var parameter = "{'franchiseeId':'" + franchiseeId + "'}";
            var messageUrl = '<%=ResolveUrl("~/App/Controllers/PodController.asmx/GetPodsAssignedToFranchisee")%>';
            InvokeService(messageUrl, parameter, successFunction);
        }

        function BindPodsForSalesRep(salesRepresentativeId) {
            var successFunction = function(result) {
                if ($(result.d).length > 0)
                    AddRowsToPodTable('.pod-table', result.d);
                else {
                    var parameter = "{}";
                    var messageUrl = '<%=ResolveUrl("~/App/Controllers/PodController.asmx/GetAllPods")%>';
                    InvokeService(messageUrl, parameter, successFunction);
                }
            };
            var parameter = "{'salesRepId':'" + salesRepresentativeId + "'}";
            var messageUrl = '<%=ResolveUrl("~/App/Controllers/PodController.asmx/GetPodsAssignedToSalesRep")%>';
            InvokeService(messageUrl, parameter, successFunction);
        }

        var clonedPodRow = $('.territory-table').find("tr:last").clone();

        function AddRowsToPodTable(tableId, dataToBind) {
            $(tableId).empty();
            clonedPodRow.find('td').attr('style', '');
            $.each(dataToBind, function () {
                var backgroundPodColor = 'rgb(' + Math.floor(Math.random() * 255) + ',' + Math.floor(Math.random() * 255) + ',' + Math.floor(Math.random() * 255) + ')';
                clonedPodRow.find('label').text(this.Name);
                clonedPodRow.find('input:checkbox').val(this.Id);
                clonedPodRow.find('input:checkbox').attr('checked', true);
                clonedPodRow.find('input:checkbox').click(function () { ViewCurrentCalendar(); });
                clonedPodRow.find('span').show();
                $(tableId).append(clonedPodRow);
                clonedPodRow = $(tableId).find("tr:last").clone();
            });
            ShowMonthCalendar();
        }

        function GetSelectedPodIds() {
            var selectedPodIds = '';
            $('.pod-table').find("tr input:checkbox:checked").each(function () {
                selectedPodIds += $(this).val() + ',';
            });
            return selectedPodIds;
        }
        
    </script>
    <%-- General methods for applying filters on the page. --%>
    <script type="text/javascript" language="javascript">

        function ViewCurrentCalendar() {
            switch (CalendarView.ViewType) {
                case "Month":
                    ShowMonthCalendar();
                    break;
                case "Week":
                    ShowWeekCalendar();
                    break;
                case "Day":
                    ShowDayCalendar();
                    break;
                case "Year":
                    ShowYearCalendar();
                    break;
            }
            return true;
        }

        function SetDateForCommands(commandName) {
            switch (commandName) {
                case "JumpTo":
                    if ($('.ddl-year option:selected').val() != 0 && $('.ddl-month option:selected').val() != 0) {
                        CalendarView.ViewDate = new Date(parseInt($('.ddl-year option:selected').text()), parseInt($('.ddl-month option:selected').val()) - 1, 1);
                        ViewCurrentCalendar();
                    }
                    break;
                case "Next":
                    switch (CalendarView.ViewType) {
                        case "Month":
                        case "Year":
                            CalendarView.ViewDate = new Date(CalendarView.ViewDate.getFullYear(), CalendarView.ViewDate.getMonth() + 1, 1);
                            ViewCurrentCalendar();
                            break;
                        case "Week":
                            CalendarView.ViewDate = new Date(CalendarView.ViewDate.getFullYear(), CalendarView.ViewDate.getMonth(), CalendarView.ViewDate.getDate() + (7 - CalendarView.ViewDate.getDay()));
                            ViewCurrentCalendar();
                            break;
                        case "Day":
                            CalendarView.ViewDate = new Date(CalendarView.ViewDate.getFullYear(), CalendarView.ViewDate.getMonth(), CalendarView.ViewDate.getDate() + 1);
                            ViewCurrentCalendar();
                            break;
                    }
                    break;
                case "Previous":
                    switch (CalendarView.ViewType) {
                        case "Month":
                        case "Year":
                            CalendarView.ViewDate = new Date(CalendarView.ViewDate.getFullYear(), CalendarView.ViewDate.getMonth() - 1, 1);
                            ViewCurrentCalendar();
                            break;
                        case "Week":
                            CalendarView.ViewDate = new Date(CalendarView.ViewDate.getFullYear(), CalendarView.ViewDate.getMonth(), CalendarView.ViewDate.getDate() + (0 - (CalendarView.ViewDate.getDay() + 1)));
                            ViewCurrentCalendar();
                            break;
                        case "Day":
                            CalendarView.ViewDate = new Date(CalendarView.ViewDate.getFullYear(), CalendarView.ViewDate.getMonth(), CalendarView.ViewDate.getDate() - 1);
                            ViewCurrentCalendar();
                            break;
                    }
                    break;
            }
            return false;
        }
    
    </script>
    <%--Show Month Calendar--%>
    <script type="text/javascript" language="javascript">

        function ShowMonthCalendar() {//debugger;
            LoadCalendar();
            return false;
        }

        function ShowCurrentMonthCalendar() {
            CalendarView.ViewType = "Month";
            CalendarView.ViewDate = new Date();
            ShowMonthCalendar();
        }

        function SetMonthCalendarDate() {
            var lastDateOfThisMonth = LastDayOfMonth(CalendarView.ViewDate.getFullYear(), CalendarView.ViewDate.getMonth());

            $('#spDateRange').text(CalendarView.ViewDate.format("mmmm 1, yyyy") + " - " + lastDateOfThisMonth.format("mmmm dd, yyyy"));

            DisableLinkControls($('#lnkMonth'));

            EnableLinkControls(new Array($('#lnkYear'), $('#lnkWeek'), $('#lnkDay')));
        }
    </script>
    <%--Show Week CalenDar--%>
    <script type="text/javascript" language="javascript">
        function ShowWeekCalendar() {
            LoadCalendar();
            return false;
        }

        function ShowCurrentWeekCalendar() {
            CalendarView.ViewType = "Week";
            CalendarView.ViewDate = new Date();
            ShowWeekCalendar();
        }

        function SetWeekCalendarDate() {
            var firstDayOfThisWeek = new Date(CalendarView.ViewDate.getFullYear(), CalendarView.ViewDate.getMonth(), CalendarView.ViewDate.getDate() - CalendarView.ViewDate.getDay());
            var lastDayOfThisWeek = new Date(CalendarView.ViewDate.getFullYear(), CalendarView.ViewDate.getMonth(), CalendarView.ViewDate.getDate() + (6 - CalendarView.ViewDate.getDay()));

            $('#spDateRange').text(firstDayOfThisWeek.format("mmmm dd, yyyy") + " - " + lastDayOfThisWeek.format("mmmm dd, yyyy"));

            DisableLinkControls($('#lnkWeek'));

            EnableLinkControls(new Array($('#lnkYear'), $('#lnkMonth'), $('#lnkDay')));
        }
    </script>
    <%--Show Day CalenDar--%>
    <script type="text/javascript" language="javascript">
        function ShowDayCalendar() {
            LoadCalendar();
            return false;
        }

        function ShowCurrentDayCalendar() {
            CalendarView.ViewType = "Day";
            CalendarView.ViewDate = new Date();
            ShowDayCalendar();
        }

        function SetDayCalendarDate() {
            $('#spDateRange').text(CalendarView.ViewDate.format("mmmm dd, yyyy"));

            DisableLinkControls($('#lnkDay'));

            EnableLinkControls(new Array($('#lnkYear'), $('#lnkMonth'), $('#lnkWeek')));
        }
    </script>
    <%--Show Year CalenDar--%>
    <script type="text/javascript" language="javascript">
        function ShowYearCalendar() {
            LoadCalendar();
            return false;
        }

        function ShowCurrentYearCalendar() {
            CalendarView.ViewType = "Year";
            CalendarView.ViewDate = new Date();
            ShowYearCalendar();
        }

        function SetYearCalendarDate() {
            var nextFourthMonth = new Date(CalendarView.ViewDate.getFullYear(), CalendarView.ViewDate.getMonth() + 2, 1);
            var lastDateOfFourthMonth = LastDayOfMonth(nextFourthMonth.getFullYear(), nextFourthMonth.getMonth());

            $('#spDateRange').text(new Date(CalendarView.ViewDate.getFullYear(), CalendarView.ViewDate.getMonth() - 1, 1).format("mmmm 1, yyyy") + " - " + lastDateOfFourthMonth.format("mmmm dd, yyyy"));

            DisableLinkControls($('#lnkYear'));

            EnableLinkControls(new Array($('#lnkDay'), $('#lnkMonth'), $('#lnkWeek')));
        }
    </script>
    <iframe id="objIframe" src="" class="iframeforpopup_clndr" frameborder="0"></iframe>
    <div id="divloading" class="loadingdiv_ucecustlist" style="display: none">
        <span class="ltxt">Loading...</span> <span class="left">
            <img src="/App/Images/loading.gif" alt="" /></span>
    </div>
    <%--Div for Blocked Day--%>
    <div id="dvBlockedDayDescShow" class="maindiv_roundmbox">
        <div class="innerdiv_roundmbox">
            <div id="BlockedDayTop" class="roundcorner_roundmbox">
                <img src="../Images/specer.gif" width="254px" height="15px" /></div>
            <div class="midinner_roundmbox">
                <p class="headertxt_roundmbox">
                    Franchisee Blocked
                </p>
                <div id="dvBlockedDayDescText" class="divinnerbody_mbox">
                    <p class='tooltippopuprow'>
                        <span class='ttitletxt_ecl_popup'>Franchisee :</span><span class='detailtxt_ecl_popup'
                            id="BlockedDayDescription"></span></p>
                </div>
            </div>
            <div id="BlockedDayBottom" class="roundcornerbot_roundmbox">
                <img src="../Images/specer.gif" width="254px" height="15px" /></div>
        </div>
    </div>
    <%--Div for Context menu--%>
    <div id="ie5menu" oncontextmenu="return false;" class="contextmenudiv_roundmbox">
        <p>
            <img src="../Images/specer.gif" width="1px" height="5px" /></p>
        <div class="maindiv_clndrrightbox">
            <p class="clndrrightbox_topbg">
                <img src="../Images/specer.gif" width="1px" height="7px" /></p>
            <div class="clndrrightbox_middiv">
                <p class="calander_leftinner_row" onmouseover="style.backgroundColor='#E2F1F9';"
                    onmouseout="style.backgroundColor=''">
                    <span class="calanderleft_lnktxt_inner"><a id="LinkEvent" href="/App/Common/CreateEventWizard/Step1.aspx?Type=Create&Referrer=Calendar">
                        <span class="calander_colorbox_inner">
                            <img src="../Images/addevent-square.gif" /></span> Add Event</a> </span>
                </p>
                <p class="calander_leftinner_row" onmouseover="style.backgroundColor='#E2F1F9';"
                    onmouseout="style.backgroundColor=''">
                    <span class="calanderleft_lnktxt_inner"><a id="LinkMeeting" href="../Franchisor/AddMeeting.aspx?Referrer=Calendar">
                        <span class="calander_colorbox_inner">
                            <img src="../Images/appointments-square.gif" /></span> Meeting</a></span>
                </p>
                <p class="calander_leftinner_row" onmouseover="style.backgroundColor='#E2F1F9';"
                    onmouseout="style.backgroundColor=''">
                    <span class="calanderleft_lnktxt_inner"><a id="LinkCall" href="../Franchisor/AddCall.aspx?Referrer=Calendar">
                        <span class="calander_colorbox_inner">
                            <img src="../Images/reminders-square.gif" /></span> Call</a></span>
                </p>
                <p class="calander_leftinner_row" onmouseover="style.backgroundColor='#E2F1F9';"
                    onmouseout="style.backgroundColor=''">
                    <span class="calanderleft_lnktxt_inner"><a id="LinkTasks" href="../Franchisor/AddTask.aspx?Referrer=Calendar">
                        <span class="calander_colorbox_inner">
                            <img src="../Images/task-square.gif" /></span> Tasks</a></span>
                </p>
                <p class="calander_leftinner_row" onmouseover="style.backgroundColor='#E2F1F9';"
                    onmouseout="style.backgroundColor=''">
                    <span class="calanderleft_lnktxt_inner"><a id="LinkSeminar" href="AddSeminars.aspx">
                        <span class="calander_colorbox_inner">
                            <img src="../Images/addseminar-square.gif" /></span> Seminar</a> </span>
                </p>
                <p id="sBloack" runat="server" class="calander_leftinner_row" onmouseover="style.backgroundColor='#E2F1F9';"
                    onmouseout="style.backgroundColor=''">
                    <span class="calanderleft_lnktxt_inner"><span class="calander_colorbox_inner">
                        <img src="../Images/block-square.gif" /></span>
                        <asp:LinkButton ID="lnkBloack" runat="server" Text="Block Day"></asp:LinkButton>
                    </span>
                </p>
            </div>
            <p class="clndrrightbox_botbg">
                <img src="../Images/specer.gif" width="1px" height="7px" /></p>
        </div>
    </div>
    <%--Div Main page--%>
    <div class="wrapper_inpg">
        <h1 class="left">
            Calendar</h1>
        <div class="hr left">
        </div>
        <div class="maindivredmsgbox" id="divErrorMsg" enableviewstate="false" visible="false"
            runat="server">
        </div>
        <div class="intotxt_clndr">
            Here you can see the list of events in a calendar view. You can mouse over the events
            to see the basic details or click on the event to see more details like registered
            customers,appointments,meetings, tasks and calls etc.
        </div>
        <div class="main_area_bdrnone">
            <div class="filtrbox_cal">
                <div class="fprow">
                    <label>
                        Host Name:</label>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="inputtxt host-name" Width="250px"></asp:TextBox>
                    <span id="SalesRepSpan" runat="server">
                        <label>
                            Sales Rep:</label>
                        <asp:DropDownList ID="SalesRepDropDown" runat="server" Width="240px" CssClass="sales-rep-ddl">
                        </asp:DropDownList>
                    </span>
                </div>
                <div class="fprow">
                    <div class="left">
                        <span id="FranchiseeSpan" runat="server">
                            <label>
                                Franchisee:</label>
                            <asp:DropDownList ID="FranchiseeDropDown" runat="server" Width="255px" CssClass="franchisee-ddl">
                            </asp:DropDownList>
                        </span>
                    </div>
                    <div class="buttoncon_default">
                        <asp:ImageButton ID="ibtnsearch" runat="server" ImageUrl="~/App/Images/search-button.gif"
                            OnClientClick="ViewCurrentCalendar(); return false;" /></div>
                    <div class="buttoncon_default">
                        <asp:ImageButton ID="ibtnclear" runat="server" ImageUrl="~/App/Images/clear-button.gif"
                            OnClientClick="ClearFilters(); return false;" /></div>
                </div>
            </div>
            <div class="mainarearow_clndr">
                <div class="printclndr_clndr">
                    <a href="#" onclick="javascript:CallPrint()">
                        <img src="../Images/print-calander-icon.gif" />
                        Print this Calendar </a>
                </div>
            </div>
            <div class="mainarearow_clndr">
                <div class="arrowcntrol_clndr">
                    <asp:ImageButton runat="server" ID="imgPreviousMonth" ImageUrl="~/App/Images/calander-leftarrow-btn.gif"
                        OnClientClick="return SetDateForCommands('Previous');" ToolTip="Previous" /></div>
                <div class="middivarrow_clndr">
                    <div class="headtxt_clndr" id="spDateRange">
                    </div>
                    <div class="rightlnktext_clndr" id="spViewType">
                        <a id="lnkYear" onclick="return ShowCurrentYearCalendar();" class="">4 Month View</a>&nbsp;|&nbsp;
                        <%--<asp:LinkButton ID="lnkYear" runat="server" Text="" OnClientClick=""></asp:LinkButton>--%>
                        <a id="lnkMonth" onclick="return ShowCurrentMonthCalendar();">Month View</a>&nbsp;|&nbsp;
                        <%--<asp:LinkButton ID="" runat="server" Text="Month View" OnClientClick="return ShowMonthCalendar();"></asp:LinkButton>&nbsp;|&nbsp;--%>
                        <a id="lnkWeek" onclick="return ShowCurrentWeekCalendar();">Week View</a>&nbsp;|&nbsp;
                        <%--<asp:LinkButton ID="lnkWeek" runat="server" Text="Week View" OnClientClick="return ShowWeekCalendar();"></asp:LinkButton>&nbsp;|&nbsp;--%>
                        <a id="lnkDay" onclick="return ShowCurrentDayCalendar();">Day View</a>&nbsp;|&nbsp;
                        <%--<asp:LinkButton ID="lnkDay" runat="server" Text="Day View" OnClientClick="return ShowDayCalendar();"></asp:LinkButton>&nbsp;--%>
                    </div>
                </div>
                <div class="arrowcntrol_clndr">
                    <asp:ImageButton runat="server" ID="imgNextMonth" ImageUrl="~/App/Images/calander-rightarrow-btn.gif"
                        ToolTip="Next" OnClientClick="return SetDateForCommands('Next');" /></div>
            </div>
            <div class="mainarearow_clndr">
                <span id="spLegands" class="notetxt_clnder">Note: &nbsp;<img src="../Images/addevent-square.gif" />
                    = Event,&nbsp;<img src="../Images/appointments-square.gif" />
                    = Meetings, &nbsp;<img src="../Images/reminders-square.gif" />
                    = Call, &nbsp;<img src="../Images/task-square.gif" />
                    = Task, &nbsp;<img src="../Images/addseminar-square.gif" />
                    = Seminar , &nbsp;<img src="../Images/block-square.gif" />
                    = Blocked Day</span><span class="ddownyearmonth_clnder">
                        <asp:ImageButton runat="server" ID="btnview" OnClientClick="return SetDateForCommands('JumpTo');"
                            ImageAlign="Middle" ImageUrl="~/App/Images/view-btn-txt.gif"></asp:ImageButton>
                    </span><span class="ddownyearmonth_clnder">
                        <asp:DropDownList ID="ddlYear" runat="server" Width="100px" CssClass="inputf_def ddl-year">
                            <asp:ListItem Value="0">Select Year</asp:ListItem>
                            <asp:ListItem>2006</asp:ListItem>
                            <asp:ListItem>2007</asp:ListItem>
                            <asp:ListItem>2008</asp:ListItem>
                            <asp:ListItem>2009</asp:ListItem>
                            <asp:ListItem>2010</asp:ListItem>
                            <asp:ListItem>2011</asp:ListItem>
                            <asp:ListItem>2012</asp:ListItem>
                            <asp:ListItem>2013</asp:ListItem>
                            <asp:ListItem>2014</asp:ListItem>
                            <asp:ListItem>2015</asp:ListItem>
                            <asp:ListItem>2016</asp:ListItem>
                            <asp:ListItem>2017</asp:ListItem>
                        </asp:DropDownList>
                    </span><span class="ddownyearmonthl_clnder">
                        <asp:DropDownList ID="ddlMonth" runat="server" Width="100px" CssClass="inputf_def ddl-month">
                            <asp:ListItem Value="0">Select Month</asp:ListItem>
                            <asp:ListItem Value="1">January</asp:ListItem>
                            <asp:ListItem Value="2">February</asp:ListItem>
                            <asp:ListItem Value="3">March</asp:ListItem>
                            <asp:ListItem Value="4">April</asp:ListItem>
                            <asp:ListItem Value="5">May</asp:ListItem>
                            <asp:ListItem Value="6">June</asp:ListItem>
                            <asp:ListItem Value="7">July</asp:ListItem>
                            <asp:ListItem Value="8">August</asp:ListItem>
                            <asp:ListItem Value="9">September</asp:ListItem>
                            <asp:ListItem Value="10">October</asp:ListItem>
                            <asp:ListItem Value="11">November</asp:ListItem>
                            <asp:ListItem Value="12">December</asp:ListItem>
                        </asp:DropDownList>
                    </span>
            </div>
            <div id="divCalendar" style="margin-top: 5px" class="left">
            </div>
        </div>
    </div>
    <!--  Context menu   -->
    <script language="javascript" type="text/javascript">

        var ie5 = document.all && document.getElementById
        var ns6 = document.getElementById && !document.all
        var selectedCell = ""
        var selectedCellClass = ""
        if (ie5 || ns6)
            var menuobj = document.getElementById("ie5menu")

        function showmenuie5(e) {

            hidemenuie5(e);
            //debugger
            var name = navigator.appName
            if (name == "Microsoft Internet Explorer")
                var obj = event.srcElement;
            else
                var obj = e.target;
            var tagName = obj.tagName;
            var senderid = obj.id;
            if (tagName != "TD") {
                while (tagName != "TD") {
                    obj = obj.parentNode;
                    tagName = obj.tagName;
                    senderid = obj.id;
                    if (tagName == "TD")
                    { break; }
                }
            }
            if (obj.innerHTML.indexOf('BlockedDay', 0) == -1) {
                ContextMenu1(senderid);
            }
            else {
                alert("This day is Blocked!");
            }
            return;
        }

        function hidemenuie5(e) {

            menuobj.style.display = "none"
            menuobj.style.visibility = "hidden"
            objIframe1 = document.getElementById('objIframe');
            objIframe1.style.display = "none";
            if (document.getElementById(selectedCell) != null) {
                document.getElementById(selectedCell).style.backgroundColor = selectedCellClass;
            }
        }
        if (ie5 || ns6) {
            menuobj.style.display = ''
            setContextMenu("Month");
            setContextMenu("Year");
            setContextMenu("Week");
        }    
    </script>
    <%--THIS IS FOR aDD NOTES--%>
    <asp:Panel ID="pnlAddFranchisee" runat="server">
        <div class="wrapper_pop">
            <div class="wrapperin_pop">
                <div class="innermain_pop">
                    <h1>
                        Add Block Days</h1>
                    <p class="innermain_pop">
                        <span class="titletextsmallbold_default">Date:</span> <span class="inputfldnowidth_default">
                            <asp:TextBox ID="txtBlockDate" runat="server" CssClass="inputf_def" Width="100px"
                                ReadOnly="true"></asp:TextBox></span>
                    </p>
                    <p class="innermain_pop">
                        <span class="titletextsmallbold_default">Reason:</span> <span class="inputfldnowidth_default">
                            <asp:TextBox ID="txtBlockReason" runat="server" TextMode="MultiLine" Rows="4" CssClass="inputf_def"
                                Width="500px"></asp:TextBox></span>
                    </p>
                    <p class="innermain_pop">
                        <span class="titletextsmallbold_default">
                            <img src="../Images/specer.gif" width="70" height="1" /></span> <span class="inputfldnowidth_default">
                                <asp:CheckBox ID="CheckBox1" Text="Is Active?" runat="server" Visible="False" />
                            </span>
                    </p>
                    <p class="innermain_pop">
                        <span class="titletextnowidth_default">Available Franchisee:</span></p>
                    <div class="innermain_pop" style="height: 100px; overflow-y: auto">
                        <asp:GridView runat="server" ID="grdFranchisee" CssClass="divgrid_cl" GridLines="None"
                            AutoGenerateColumns="false" DataKeyNames="FranchiseeID" OnRowDataBound="grdFranchisee_RowDataBound">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox runat="server" ID="chkboxheader" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="chkboxitem" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Name" HeaderText="Name"></asp:BoundField>
                                <asp:BoundField DataField="Address" HeaderText="Address"></asp:BoundField>
                            </Columns>
                            <RowStyle CssClass="row2" />
                            <HeaderStyle CssClass="row1" />
                            <AlternatingRowStyle CssClass="row3" />
                        </asp:GridView>
                    </div>
                    <p class="innermain_pop">
                        <span class="buttoncon_default">
                            <asp:ImageButton runat="server" ID="ibtnsave" ImageUrl="~/App/Images/save-button.gif"
                                OnClick="ibtnsave_Click" /></span> <span class="buttoncon_default">
                                    <asp:ImageButton runat="server" ID="ibtnCancel" ImageUrl="~/App/Images/cancel-btn.gif" /></span>
                    </p>
                </div>
            </div>
        </div>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="mpeSelectFranchisee" runat="server" BackgroundCssClass="modalBackground"
        CancelControlID="ibtnCancel" PopupControlID="pnlAddFranchisee" TargetControlID="lnkBloack">
    </ajaxToolkit:ModalPopupExtender>
    <asp:LinkButton ID="lnktemphidden" runat="server" Visible="true"></asp:LinkButton>
    <asp:HiddenField ID="hfBlockDate" runat="server" />
</asp:Content>
