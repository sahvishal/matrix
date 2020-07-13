<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App/Franchisor/FranchisorMaster.master"
    CodeBehind="Step2.aspx.cs" Inherits="Falcon.App.UI.App.Common.CreateEventWizard.Step2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" TagPrefix="JQueryControl" %>
<%@ Register Src="~/App/UCCommon/Message.ascx" TagName="messages" TagPrefix="messagecontrol" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <JQueryControl:JQueryToolkit ID="JQueryToolkit1" runat="server" IncludeJQueryUI="true"
        IncludeJTemplate="true" IncudeJQueryJTip="true" />
    <style type="text/css">
        .maindivpagemainrow_anp
        {
            float: left;
            padding-left: 31px;
            width: 718px;
        }
        .pagemainrow_anp
        {
            float: left;
            width: 718px;
            padding-top: 2px;
        }
        .greybox_cew
        {
            background: #f5f5f5;
            float: left;
            padding: 5px;
            width: 700px;
            border: solid 1px #eee;
        }
        .greybox_cew .row
        {
            float: left;
            width: 688px;
        }
        .inputfield150px_anp
        {
            float: left;
            width: 150px;
            margin-right: 25px;
            font: bold 12px arial;
            color: #000;
        }
        .inputfield170px_anp
        {
            float: left;
            width: 180px;
            margin-right: 20px;
            font: bold 12px arial;
            color: #000;
        }
        .inputfield250px_anp
        {
            float: left;
            width: 250px;
            margin-right: 50px;
            font: bold 12px arial;
            color: #000;
        }
        .inputfield350px_anp
        {
            float: left;
            width: 350px;
            margin-right: 50px;
            font: bold 12px arial;
            color: #000;
        }
        .msgtxt_cew
        {
            float: left;
            width: 350px;
            padding-top: 9px;
            font: normal 10px arial;
        }
        .wrapper_pop
        {
            background: #f5f5f5;
            float: left;
            width: 552px;
            padding: 10px;
        }
        .wrapperin_pop
        {
            background: #fff;
            float: left;
            width: 528px;
            border: solid 2px #4888ab;
            padding: 10px;
        }
        .innermain_pop
        {
            float: left;
            width: 528px;
        }
        .prenextband
        {
            background: #dfe7ed;
            float: left;
            width: 516px;
            border: solid 1px #ccc;
            padding: 4px 5px 4px 5px;
        }
        .subhead
        {
            float: left;
            width: 750px;
            margin-top: 5px;
        }
        .subhead img
        {
            float: left;
            margin-right: 5px;
        }
        .subhead .toppad
        {
            float: left;
            padding-top: 5px;
        }
    </style>
    <script type="text/javascript" language="javascript">

        var GB_ROOT_DIR = "/App/Wizard/greybox/";

        /* Called by child window, TemplateTimeSlots.aspx */
        function ReturnChangeScheduleTemplate() {
            var templatedropdown = document.getElementById('<%= this.ddlScheduleTemplate.ClientID %>');

            var selvalue = templatedropdown.options[templatedropdown.selectedIndex].value;

            return selvalue;
        }

        function CheckChangeDropDown() {
            var templatedropdown = document.getElementById('<%= this.ddlScheduleTemplate.ClientID %>');
            if (templatedropdown.selectedIndex == 0) {
                document.getElementById('spnlinkviewslots').style.visibility = 'hidden';
                document.getElementById('spnlinkviewslots').style.display = 'none';
            }
            else {
                document.getElementById('spnlinkviewslots').style.visibility = 'visible';
                document.getElementById('spnlinkviewslots').style.display = 'block';
            }
        }
        
        
    </script>
    <script type="text/javascript" src="/App/JavascriptFiles/HttpRequest.js" language="javascript"></script>
    <script type="text/javascript" language="javascript">

        var eventDate;
        $(function () {
            var EventDate = document.getElementById('<%= this.txtEventDate.ClientID %>')
            $(EventDate).focus(function () {
                eventDate = $.trim($(this).val());
            });
        });
        var postRequest = new HttpRequest();
        postRequest.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        postRequest.failureCallback = requestFailed();

        function checkEventDate() {
            var EventDate = document.getElementById('<%= this.txtEventDate.ClientID %>')
            var RegExPattern = /^(?=\d)(?:(?:(?:(?:(?:0?[13578]|1[02])(\/|-|\.)31)\1|(?:(?:0?[1,3-9]|1[0-2])(\/|-|\.)(?:29|30)\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})|(?:0?2(\/|-|\.)29\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))|(?:(?:0?[1-9])|(?:1[0-2]))(\/|-|\.)(?:0?[1-9]|1\d|2[0-8])\4(?:(?:1[6-9]|[2-9]\d)?\d{2}))($|\ (?=\d)))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\ [AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$/;

            if (EventDate.value.match(RegExPattern)) {
                document.getElementById("divInvalidEventDate").style.display = "none";
                document.getElementById("divValidEventDate").style.display = "block";
            }
            else {
                document.getElementById("divInvalidEventDate").style.display = "block";
                document.getElementById("divValidEventDate").style.display = "none";
            }
        }
        function FillPOD(franchiseeid, salesRepId, txtEventDateClientID, eventId) {//debugger
            checkEventDate();
            var EventDate = document.getElementById(txtEventDateClientID);
            if (EventDate.value == "") {
                return true;
            }
            else {
                var RegExPattern = /^(?=\d)(?:(?:(?:(?:(?:0?[13578]|1[02])(\/|-|\.)31)\1|(?:(?:0?[1,3-9]|1[0-2])(\/|-|\.)(?:29|30)\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})|(?:0?2(\/|-|\.)29\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))|(?:(?:0?[1-9])|(?:1[0-2]))(\/|-|\.)(?:0?[1-9]|1\d|2[0-8])\4(?:(?:1[6-9]|[2-9]\d)?\d{2}))($|\ (?=\d)))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\ [AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$/;
                if (EventDate.value.match(RegExPattern)) {
                    var divPODDetails = document.getElementById("divPODDetails");
                    var grdPOD = document.getElementById('<%= this.gvPOD.ClientID %>');
                    var PackageAvailableDiv = document.getElementById('<%= this.PackageAvailableDiv.ClientID %>');
                    var NoPackageAvailableDiv = document.getElementById('<%= this.NoPackageAvailableDiv.ClientID %>');

                    if (eventDate != EventDate.value) {
                        PackageAvailableDiv.style.display = "none";
                        NoPackageAvailableDiv.style.display = "block";
                        divPODDetails.style.display = "none";
                        if (grdPOD != null)
                            divPODDetails.innerHTML = "";

                        var spEventDate = document.getElementById("spEventDate");
                        spEventDate.innerHTML = EventDate.value;
                        postRequest.url = "AsyncEventWizard.aspx?POD=True&FranchiseeID=" + franchiseeid + "&SalesRepId=" + salesRepId + "&EventDate=" + EventDate.value;
                        postRequest.successCallback = fillPODDropDown;
                        postRequest.post("");
                        return false;
                    }
                }
                else
                    return true;
            }

        }

        function requestFailed() {

        }
        function fillPODDropDown(httpRequest) {//debugger
            var spddlPOD = document.getElementById("spddlPOD");
            spddlPOD.innerHTML = httpRequest.responseText;
        }

        function GetPodDetails() {//debugger
            var txtEventDate = document.getElementById("<%=this.txtEventDate.ClientID %>");
            var ddlPOD = document.getElementById("ddlPOD");
            if (ddlPOD == null) {
                ddlPOD = document.getElementById("<%=this.ddlPOD.ClientID %>");
            }
            if (ddlPOD.value == "0") {
                alert("Please select a Pod.");
                return false;
            }
            var hfPodID = document.getElementById("<%=this.hfPodID.ClientID %>");
            hfPodID.value = ddlPOD.value;
            return true;
        }

        function FillPodDetails(httpRequest) {
            var divPODDetails = document.getElementById("divPODDetails");
            divPODDetails.innerHTML = httpRequest.responseText;
        }

        function CheckPodDelete() {
            return confirm('Are you sure about deleting the pod?');
        }
        function InitiateRemoveMember(podid, teammemberid, eventroleid) {
            var returnval = confirm('Are you sure about removing this team member from pod?');
            if (returnval == true)
                __doPostBack('RemoveMember', podid + '-' + teammemberid + '-' + eventroleid);

        }

        function tryfun() {
            __doPostBack('BindGrid', '');
        }


        function checkDuration() {//debugger
            var hh1 = document.getElementById("<%=this.ddlHHStartTime.ClientID %>");
            var mm1 = document.getElementById("<%=this.ddlMMStartTime.ClientID %>");
            var fromampm = document.getElementById("<%=this.ddlAMPMStartTime.ClientID %>");

            var hh2 = document.getElementById("<%=this.ddlHHEndTime.ClientID %>");
            var mm2 = document.getElementById("<%=this.ddlMMEndTime.ClientID %>");
            var toampm = document.getElementById("<%=this.ddlAMPMEndTime.ClientID %>");

            var txtDuration = document.getElementById("<%=this.txtDuration.ClientID %>");

            hh1v = hh1.value;
            mm1v = mm1.value;
            hh2v = hh2.value;
            mm2v = mm2.value;

            if (fromampm.value == "PM" && parseInt(hh1v) < 12)
                hh1v = Number(hh1v) + 12;

            if (toampm.value == "PM" && parseInt(hh2v) < 12)
                hh2v = Number(hh2v) + 12;

            timefrom = Number(hh1v * 60 * 60 + mm1v * 60);

            //if(hh2v > 12) hh2v = parseInt(hh2v - 2); //24 hr time

            timeto = Number(hh2v * 60 * 60 + mm2v * 60);

            var difference = timeto - timefrom;
            var hr = 0;
            var min = 0;
            if (difference > 0) {
                hr = difference / 3600;
                hr = parseInt(hr);
                min = (difference % 3600) / 60;
                txtDuration.value = hr + " hrs " + min + " mins";
            }
        }

        function VaidateEvent() {//debugger
            if (isBlank(document.getElementById('<%= this.txtEventDate.ClientID %>'), 'Event date'))
                return false;
            if (!ValidateDate(document.getElementById('<%= this.txtEventDate.ClientID %>').value, 'Event date'))
                return false;
            if (!CompareDateWithCurrentDate2(document.getElementById('<%= this.txtEventDate.ClientID %>'), 'Event date should be of future date.'))
                return false;
            if (!CompareTime(document.getElementById('<%= this.ddlHHStartTime.ClientID %>'), document.getElementById('<%= this.ddlMMStartTime.ClientID %>'), document.getElementById('<%= this.ddlHHEndTime.ClientID %>'), document.getElementById('<%= this.ddlMMEndTime.ClientID %>'), document.getElementById('<%= this.ddlAMPMStartTime.ClientID %>'), document.getElementById('<%= this.ddlAMPMEndTime.ClientID %>'), 'Event'))
                return false;
            if (isBlank(document.getElementById('<%= this.ddlTimeZone.ClientID %>'), 'Time zone'))
                return false;
            if (!checkDropDown(document.getElementById('<%= this.ddlScheduleTemplate.ClientID %>'), 'Schedule Template'))
                return false;
            var ddlEventType = document.getElementById("<%=this.ddlEventType.ClientID %>");
            if (ddlEventType.options[ddlEventType.selectedIndex].text == "Private") {
                if (isBlank(document.getElementById('<%= this.txtInvitationCode.ClientID %>'), 'Invitation Code'))
                    return false;
            }
            var grdPOD = document.getElementById('<%= this.gvPOD.ClientID %>');
            if (grdPOD == null || grdPOD.rows == null || grdPOD.rows.length == 0) {
                if (document.getElementById('<%= this.ddlPOD.ClientID %>') != null) {
                    if (!checkDropDown(document.getElementById('<%= this.ddlPOD.ClientID %>'), 'POD'))
                        return false;
                }
                else {
                    if (!checkDropDown(document.getElementById('ddlPOD'), 'POD'))
                        return false;
                }
            }

            if (grdPOD == null || grdPOD.rows == null || grdPOD.rows.length == 0) {
                alert("Please attach the selected POD.");
                return false;
            }

            var TargetBaseControl = document.getElementById('<%=this.grdSelectPackage.ClientID %>');
            var TargetChildControl = "chkRowChild";
            var Inputs = TargetBaseControl.getElementsByTagName("input");
            var packageSelected = false;
            for (var iCount = 0; iCount < Inputs.length; ++iCount) {
                if (Inputs[iCount].type == 'checkbox' && Inputs[iCount].id.indexOf(TargetChildControl, 0) >= 0) {
                    packageSelected = Inputs[iCount].checked;
                    if (packageSelected)
                        break;
                }
            }
            var testSelected = true;
            var selectTestLength = $('.test-checkbox:checked').length;

            if (selectTestLength == 0)
                testSelected = false;

            if (packageSelected == false && testSelected == false) {
                alert("Please select atleast one package or atleast one test.");
                return false;
            }
             
            var ddlEventStatus = document.getElementById("<%=ddlEventStatus.ClientID %>");
            if (ddlEventStatus.value == "Suspended" || ddlEventStatus.value == "Canceled") {
                if (isBlank(document.getElementById('<%= this.txtNotes.ClientID %>'), 'Notes'))
                    return false;
            }
            var ddlEventCancellationReason = document.getElementById("<%= ddlEventCancellationReason.ClientID %>");
            if (ddlEventStatus.value == "Canceled") {
                if (ddlEventCancellationReason.value == "-1") {
                    alert("Please select event cancelation reason.");
                    return false;
                }
            }

            var currentRole = '<%=CurrentRole %>';
            var hhStartIme = document.getElementById("<%=this.ddlHHStartTime.ClientID %>");
            var mmStartTime = document.getElementById("<%=this.ddlMMStartTime.ClientID %>");
            var fromAMPM = document.getElementById("<%=this.ddlAMPMStartTime.ClientID %>");

            var hhEndIme = document.getElementById("<%=this.ddlHHEndTime.ClientID %>");
            var mmEndTime = document.getElementById("<%=this.ddlMMEndTime.ClientID %>");
            var toAMPM = document.getElementById("<%=this.ddlAMPMEndTime.ClientID %>");
            if (currentRole = "SalesRep" && ddlEventStatus.value == "Suspended") {
                if (hhStartIme.value != "08" || mmStartTime.value != "00" || fromAMPM.value != "AM" || hhEndIme.value != "05" || mmEndTime.value != "00" || toAMPM.value != "PM") {
                    var isProcced = confirm("The team arrival/departure time selected by you do not match with standard time defined. The event will be in suspended mode if created. Please contact your admin.");
                    if (!isProcced)
                        return false;
                }
            }
            return true;
            //            var isValidated = ValidateSelectedPackage();
            //            if (isValidated==false) return false;
            //            else return true;

        }

        function SelectAllPackage(CheckBox) {
            var TargetBaseControl = document.getElementById('<%=this.grdSelectPackage.ClientID %>');
            var TargetChildControl = "chkRowChild";
            var Inputs = TargetBaseControl.getElementsByTagName("input");
            for (var iCount = 0; iCount < Inputs.length; ++iCount) {
                if (Inputs[iCount].type == 'checkbox' && Inputs[iCount].id.indexOf(TargetChildControl, 0) >= 0) {
                    Inputs[iCount].checked = CheckBox.checked;

                }
            }
        }

        function SelectAllTest(checkBox) {
            if ($(checkBox).attr("checked") == true)
                $('.test-checkbox').attr("checked", true);
            else
                $('.test-checkbox').attr("checked", false);
        }

        function showHideInvitaionCode() {
            var ddlEventType = document.getElementById("<%=this.ddlEventType.ClientID %>");
            var divInvitaionCode = document.getElementById("divInvitaionCode");
            var spPrivateMsg = document.getElementById("spPrivateMsg");
            if (ddlEventType.options[ddlEventType.selectedIndex].text == "Private") {
                divInvitaionCode.style.display = "block";
                spPrivateMsg.style.display = "block";
            }
            else {
                divInvitaionCode.style.display = "none";
                spPrivateMsg.style.display = "none";
            }
        }

        function showEventDate() {
            var EventDate = document.getElementById('<%= this.txtEventDate.ClientID %>');
            var RegExPattern = /^(?=\d)(?:(?:(?:(?:(?:0?[13578]|1[02])(\/|-|\.)31)\1|(?:(?:0?[1,3-9]|1[0-2])(\/|-|\.)(?:29|30)\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})|(?:0?2(\/|-|\.)29\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))|(?:(?:0?[1-9])|(?:1[0-2]))(\/|-|\.)(?:0?[1-9]|1\d|2[0-8])\4(?:(?:1[6-9]|[2-9]\d)?\d{2}))($|\ (?=\d)))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\ [AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$/;
            if (EventDate.value.match(RegExPattern)) {
                var spEventDate = document.getElementById("spEventDate");
                spEventDate.innerHTML = EventDate.value;

            }
        }

        function showToolTip() {//debugger
            var divToolTip = document.getElementById("<%= this.divToolTip.ClientID %>");
            var aToolTip = document.getElementById("aToolTip");
            var dim = GetTopLeft(aToolTip);
            divToolTip.style.top = parseInt(dim.Top) - 100 + 'px';
            divToolTip.style.left = (parseInt(dim.Left) + 10) + 'px';
            divToolTip.style.display = "block";
        }
        function hideToolTip() {
            var divToolTip = document.getElementById("<%= this.divToolTip.ClientID %>");
            var aToolTip = document.getElementById("aToolTip");
            divToolTip.style.display = "none";
        }

        function GetTopLeft(elm) {

            var x, y = 0;

            //set x to elm’s offsetLeft
            x = elm.offsetLeft;

            //set y to elm’s offsetTop
            y = elm.offsetTop;

            //set elm to its offsetParent
            elm = elm.offsetParent;

            //use while loop to check if elm is null
            // if not then add current elm’s offsetLeft to x
            //offsetTop to y and set elm to its offsetParent 
            while (elm != null) {

                x = parseInt(x) + parseInt(elm.offsetLeft);
                y = parseInt(y) + parseInt(elm.offsetTop);
                elm = elm.offsetParent;
            }

            //here is interesting thing
            //it return Object with two properties
            //Top and Left
            return { Top: y, Left: x };

        }

        function AllowNumericOnly(evt) {
            return KeyPress_DecimalAllowedOnly(evt);

        }
        var currentMonth;
        var currentYear;
        function showCalendar() {//debugger
            var ddlPOD = document.getElementById("ddlPOD");
            if (ddlPOD == null) {
                ddlPOD = document.getElementById("<%=this.ddlPOD.ClientID %>");
            }
            if (ddlPOD.value == "" || ddlPOD.value == "0") {
                alert("Please select a Pod.");
                return false;
            }
            var txtEventDate = document.getElementById("<%=this.txtEventDate.ClientID %>");
            var now = new Date(txtEventDate.value);
            currentYear = now.getFullYear();
            currentMonth = (now.getMonth()) + 1;
            postRequest.url = "AsyncPodCalendar.aspx?PodID=" + ddlPOD.value + "&Month=" + currentMonth + "&Year=" + currentYear;
            postRequest.successCallback = FillPodCalendar;
            postRequest.post("");
        }

        function FillPodCalendar(httpRequest) {//debugger
            var divCalendar = document.getElementById("divCalendar");
            divCalendar.innerHTML = httpRequest.responseText;
            $('#ViewPodCalendar').dialog('open');
            var zIndex = $('#ViewPodCalendar').dialog('option', 'zIndex');
            $('.jtip').cluetip({ splitTitle: '|', cursor: 'pointer', tracking: true, cluetipClass: 'jtip', arrows: true, dropShadow: false, hoverIntent: false, cluezIndex: 5000 + zIndex });

        }

        function showPrevMonthPodCal() {//debugger

            currentMonth = currentMonth - 1;
            if (currentMonth == 0) {
                currentYear = currentYear - 1;
                currentMonth = 12;
            }
            var ddlPOD = document.getElementById("ddlPOD");
            if (ddlPOD == null) {
                ddlPOD = document.getElementById("<%=this.ddlPOD.ClientID %>");
            }
            postRequest.url = "AsyncPodCalendar.aspx?PodID=" + ddlPOD.value + "&Month=" + currentMonth + "&Year=" + currentYear;
            postRequest.successCallback = FillPodCalendar;
            postRequest.post("");
        }

        function showNextMonthPodCal() {//debugger

            currentMonth = currentMonth + 1;
            if (currentMonth == 13) {
                currentYear = currentYear + 1;
                currentMonth = 1;
            }
            var ddlPOD = document.getElementById("ddlPOD");
            if (ddlPOD == null) {
                ddlPOD = document.getElementById("<%=this.ddlPOD.ClientID %>");
            }
            postRequest.url = "AsyncPodCalendar.aspx?PodID=" + ddlPOD.value + "&Month=" + currentMonth + "&Year=" + currentYear;
            postRequest.successCallback = FillPodCalendar;
            postRequest.post("");
        }

        function showEventTemplateActivity() {
            var ddlEventTaskTemplate = document.getElementById("<%=this.ddlEventTaskTemplate.ClientID %>");
            if (ddlEventTaskTemplate.value == "" || ddlEventTaskTemplate.value == "0") {
                alert("Please select a Template.");
                return false;
            }
            postRequest.url = "AsyncEventActivityTemplate.aspx?EventActivityTemplateID=" + ddlEventTaskTemplate.value;
            postRequest.successCallback = FillTemplateActivity;
            postRequest.post("");
        }
        function FillTemplateActivity(httpRequest) {//debugger
            var divActivity = document.getElementById("divActivity");
            divActivity.innerHTML = httpRequest.responseText;
            $find('mdlEventActivity').show();
        }

        function maintainAfterPostBack() {
            CheckChangeDropDown();
            checkEventDate();
            ShowHideEventNotes();
            ShowHideEventCancellationReason();
        }
    </script>
    <%--Show/Hide EventNotes--%>
    <script language="javascript" type="text/javascript">
        function ShowHideEventNotes() { 
            var ddlEventStatus = document.getElementById("<%=ddlEventStatus.ClientID %>");
            var pEventNotes = document.getElementById("pEventNotes");
            if (ddlEventStatus.value == "Suspended" || ddlEventStatus.value == "Canceled") {
                pEventNotes.style.display = "block";
            }
            else {
                pEventNotes.style.display = "none";
            }
        }
        function ShowHideEventCancellationReason() { 
            var ddlEventStatus = document.getElementById("<%=ddlEventStatus.ClientID %>");
            var pEventCancellationReason = document.getElementById("pEventCancellationReason");
            if (ddlEventStatus.value == "Canceled") {
                pEventCancellationReason.style.display = "block";
            }
            else {
                pEventCancellationReason.style.display = "none";
                var ddlEventCancellationReason = document.getElementById("<%= ddlEventCancellationReason.ClientID %>");
                ddlEventCancellationReason.selectedIndex = 0;
            }
        }
    </script>
    <%--set controls data--%>
    <script type="text/javascript" language="javascript">
        var postRequestSetControls = new HttpRequest();
        postRequestSetControls.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        postRequestSetControls.failureCallback = requestFailed();
        function Notask() { }
        function SetEventDate() {
            var txtEventDate = document.getElementById("<%= txtEventDate.ClientID %>");
            postRequestSetControls.url = "AsyncEventWizard.aspx?Type=SettingControlsdata&Data=EventDate&Value=" + txtEventDate.value;
            postRequestSetControls.successCallback = Notask();
            postRequestSetControls.post("");
            return false;
        }
        function SetTeamArrivalTime() {
            var ddlHHStartTime = document.getElementById("<%= ddlHHStartTime.ClientID %>");
            var ddlMMStartTime = document.getElementById("<%= ddlMMStartTime.ClientID %>");
            var ddlAMPMStartTime = document.getElementById("<%= ddlAMPMStartTime.ClientID %>");
            postRequestSetControls.url = "AsyncEventWizard.aspx?Type=SettingControlsdata&Data=TeamArrivalTime&Value=" + ddlHHStartTime.value + ":" + ddlMMStartTime.value + " " + ddlAMPMStartTime.value;
            postRequestSetControls.successCallback = Notask();
            postRequestSetControls.post("");
            return false;
        }
        function SetTeamDepartureTime() {
            var ddlHHEndTime = document.getElementById("<%= ddlHHEndTime.ClientID %>");
            var ddlMMEndTime = document.getElementById("<%= ddlMMEndTime.ClientID %>");
            var ddlAMPMEndTime = document.getElementById("<%= ddlAMPMEndTime.ClientID %>");
            postRequestSetControls.url = "AsyncEventWizard.aspx?Type=SettingControlsdata&Data=TeamDepartureTime&Value=" + ddlHHEndTime.value + ":" + ddlMMEndTime.value + " " + ddlAMPMEndTime.value;
            postRequestSetControls.successCallback = Notask();
            postRequestSetControls.post("");
            return false;
        }
        function SetTimeZone() {//debugger
            var ddlTimeZone = document.getElementById("<%= ddlTimeZone.ClientID %>");
            postRequestSetControls.url = "AsyncEventWizard.aspx?Type=SettingControlsdata&Data=TimeZone&Value=" + ddlTimeZone.value;
            postRequestSetControls.successCallback = Notask();
            postRequestSetControls.post("");
            return false;
        }
        function SetScheduleTemplate() {
            var ddlScheduleTemplate = document.getElementById("<%= ddlScheduleTemplate.ClientID %>");
            postRequestSetControls.url = "AsyncEventWizard.aspx?Type=SettingControlsdata&Data=ScheduleTemplate&Value=" + ddlScheduleTemplate.value;
            postRequestSetControls.successCallback = Notask();
            postRequestSetControls.post("");
            return false;
        }
        function SetEventType() {
            var ddlEventType = document.getElementById("<%= ddlEventType.ClientID %>");
            postRequestSetControls.url = "AsyncEventWizard.aspx?Type=SettingControlsdata&Data=EventType&Value=" + ddlEventType.value;
            postRequestSetControls.successCallback = Notask();
            postRequestSetControls.post("");
            return false;
        }
        function SetInvitationCode() {
            var txtInvitationCode = document.getElementById("<%= txtInvitationCode.ClientID %>");
            postRequestSetControls.url = "AsyncEventWizard.aspx?Type=SettingControlsdata&Data=InvitationCode&Value=" + txtInvitationCode.value;
            postRequestSetControls.successCallback = Notask();
            postRequestSetControls.post("");
            return false;
        }
        function SetEventStatus() {
            var ddlEventStatus = document.getElementById("<%= ddlEventStatus.ClientID %>");
            var value = "1";
            if (ddlEventStatus.value == "Active")
                value = "1";
            else if (ddlEventStatus.value == "Suspended")
                value = "2";
            else if (ddlEventStatus.value == "Canceled")
                value = "3";
            postRequestSetControls.url = "AsyncEventWizard.aspx?Type=SettingControlsdata&Data=EventStatus&Value=" + value;
            postRequestSetControls.successCallback = Notask();
            postRequestSetControls.post("");
            return false;
        }
        function SetEventNotes() {
            var txtNotes = document.getElementById("<%= txtNotes.ClientID %>");
            postRequestSetControls.url = "AsyncEventWizard.aspx?Type=SettingControlsdata&Data=EventNotes&Value=" + txtNotes.value;
            postRequestSetControls.successCallback = Notask();
            postRequestSetControls.post("");
            return false;
        }
        function SetEventTaskTemplate() {
            var ddlEventTaskTemplate = document.getElementById("<%= ddlEventTaskTemplate.ClientID %>");
            postRequestSetControls.url = "AsyncEventWizard.aspx?Type=SettingControlsdata&Data=EventTaskTemplate&Value=" + ddlEventTaskTemplate.value;
            postRequestSetControls.successCallback = Notask();
            postRequestSetControls.post("");
            return false;
        }
        
    </script>
    <%--Check standard Event time --%>
    <script language="javascript" type="text/javascript">
        var isNonStadardTimeSelected = false;
        function CheckStandardEventStartTime() {//debugger;
            var hhStartIme = document.getElementById("<%=this.ddlHHStartTime.ClientID %>");
            var mmStartTime = document.getElementById("<%=this.ddlMMStartTime.ClientID %>");
            var fromAMPM = document.getElementById("<%=this.ddlAMPMStartTime.ClientID %>");

            var hhEndIme = document.getElementById("<%=this.ddlHHEndTime.ClientID %>");
            var mmEndTime = document.getElementById("<%=this.ddlMMEndTime.ClientID %>");
            var toAMPM = document.getElementById("<%=this.ddlAMPMEndTime.ClientID %>");

            var ddlEventStatus = document.getElementById("<%= ddlEventStatus.ClientID %>");
            var txtNotes = document.getElementById("<%=txtNotes.ClientID %>")

            if (hhStartIme.value != "08" || mmStartTime.value != "00" || fromAMPM.value != "AM" || hhEndIme.value != "05" || mmEndTime.value != "00" || toAMPM.value != "PM") {
                ddlEventStatus.selectedIndex = 1;
                ddlEventStatus.disabled = 'disabled';
                txtNotes.value = "Due to non standard team arrival/departure time, event has been suspended!.";
                ShowHideEventNotes();
                ShowHideEventCancellationReason();
                SetEventStatus();
                if (!isNonStadardTimeSelected) {
                    isNonStadardTimeSelected = true;
                    alert("The team arrival/departure time selected by you do not match with standard time defined. The event will be in suspended mode if created. Please contact your admin.");
                }
            }
            else {
                ddlEventStatus.selectedIndex = 0;
                ddlEventStatus.disabled = '';
                txtNotes.value = "";
                ShowHideEventCancellationReason(); 
                SetEventStatus();
                isNonStadardTimeSelected = false;
            }
            //SetTeamArrivalTime();
            //SetTeamDepartureTime();             
        }
    </script>
    <%--Validate Package (Check Wether all test are selected for selected package)--%>
    <script language="javascript" type="text/javascript">
        function ValidateSelectedPackage() {

            var selectPackages = '';
            var selectedTests = '';

            for (var i = 0; i < $('.package-checkbox:checked').length; i++) {
                var packageCheckBox = $('.package-checkbox:checked')[i];
                var packageid = $(packageCheckBox).parents('tr').find('.package-id').html();
                selectPackages = selectPackages + packageid + ",";
            }
            for (var i = 0; i < $('.test-checkbox:checked').length; i++) {
                var testCheckBox = $('.test-checkbox:checked')[i];
                var testid = $(testCheckBox).parents('tr').find('.test-id').html();
                selectedTests = selectedTests + testid + ",";
            }

            var successFunction = function (result) {
                //debugger;
                var testIds = result.d;
                if (testIds != '') {
                    var IsContinue = confirm("The selected test is not the combination of all tests for seleted package,please click ok to continue and will select all combination of tests for selected package.");
                    if (!IsContinue)
                        return false;

                    var testIds_array = testIds.split(",");
                    // Split TestIds and select those tests
                    for (var i = 0; i < $('.test-checkbox').length; i++) {
                        var testCheckBox = $('.test-checkbox')[i];
                        var testid = $(testCheckBox).parents('tr').find('.test-id').html();
                        for (var j = 0; j < testIds_array.length; j++) {
                            if (testid == testIds_array[j]) {
                                $(testCheckBox).attr("checked", true);
                            }
                        }
                    }
                    return true;
                }
                else return false;
            }
            var parameter = "{'packageIds':'" + selectPackages + "'";
            parameter += ",'testIds':'" + selectedTests + "'}";
            var messageUrl = '<%=ResolveUrl("~/App/Controllers/PackageTestDependencyRule.asmx/CheckPackageTestDependencyRule")%>';
            InvokeService(messageUrl, parameter, successFunction);
        }

        function InvokeService(messageUrl, parameter, successFunction) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                url: messageUrl,
                data: parameter,
                success: function (result) {
                    successFunction(result);
                },
                error: function (a, b, c) {
                    alert(a.responseText);
                }
            })
        }
    </script>
    <script type="text/javascript" src="/App/Wizard/greybox/AJS.js"></script>
    <script type="text/javascript" src="/App/Wizard/greybox/AJS_fx.js"></script>
    <script type="text/javascript" src="/App/Wizard/greybox/gb_scripts.js"></script>
    <link href="/App/Wizard/greybox/gb_styles.css" rel="stylesheet" type="text/css" />
    <div class="wrapper_inpg">
        <div class="maindivredmsgbox" runat="server" id="divtopmessage" style="display: none">
        </div>
        <h1 class="left" id="headingEventWizard" runat="server">
            Create Event Wizard</h1>
        <div class="hr left">
        </div>
        <div id="_divMessage" runat="server" style="display: none">
            <messagecontrol:messages ID="_messageControlPrivatePublic" runat="server" />
        </div>
        <div class="headingbox_top_body">
            Here you can create your event and setup all event related activities – like selecting
            advocates
        </div>
        <div class="headingbox_top_body">
            <img src="../../Images/createeventwizardstep2.gif" alt="" />
        </div>
        <div class="headingbox_top_body">
            <span class="graysmalltxt_default" id="spHostName" runat="server"><< Host Name >></span>
            <br />
            <span class="graysmalltxt_default" id="spHostAddress" runat="server"><< Address >></span>
            <br />
            <span class="graysmalltxt_default">[<a href="Step1.aspx" style="font-size: 11px">Change</a>]</span><br />
        </div>
        <div class="headingbox_top_body" style="margin-top: 10px">
            <span class="orngbold18_default">Step 2 : Event Information </span>
        </div>
        <div class="hr left">
        </div>
        <div class="subhead">
            <img src="/App/Images/page1symbolvsmall.gif" alt="" />
            <h2 class="toppad">
                Date and time of the event</h2>
        </div>
        <div class="main_area_bdrnone">
            <div class="maindivpagemainrow_anp">
                <p class="pagemainrow_anp">
                    <span class="inputfield150px_anp">Event Date:<span class="reqiredmark"><sup>*</sup></span>
                        <asp:TextBox ID="txtEventDate" runat="server" CssClass="inputf_def date-picker" Width="140px"></asp:TextBox>
                    </span><span class="inputfield170px_anp">Team Arrival Time:<span class="reqiredmark"><sup>*</sup></span><span
                        class="inputfield170px_anp">
                        <asp:DropDownList ID="ddlHHStartTime" runat="server" CssClass="inputf_def" Width="40px">
                            <asp:ListItem Text="05" Value="05"></asp:ListItem>
                            <asp:ListItem Text="06" Value="06"></asp:ListItem>
                            <asp:ListItem Text="07" Value="07"></asp:ListItem>
                            <asp:ListItem Text="08" Value="08" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="09" Value="09"></asp:ListItem>
                            <asp:ListItem Text="10" Value="10"></asp:ListItem>
                            <asp:ListItem Text="11" Value="11"></asp:ListItem>
                            <asp:ListItem Text="12" Value="12"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlMMStartTime" runat="server" CssClass="inputf_def" Width="40px">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlAMPMStartTime" runat="server" CssClass="inputf_def" Width="50px">
                            <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                            <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                        </asp:DropDownList>
                        <span class="chkboxtxt_prsmall"><em>(Standard time is 08:00 AM)</em></span> </span>
                    </span><span class="inputfield170px_anp" style="margin-right: 5px;"><span class="inputfield170px_anp"
                        style="margin-right: 5px;">Team Departure Time:<span class="reqiredmark"><sup>*</sup></span></span>
                        <span class="inputfield170px_anp" style="margin-right: 5px;">
                            <asp:DropDownList ID="ddlHHEndTime" runat="server" CssClass="inputf_def" Width="45px">
                                <asp:ListItem Text="01" Value="01"></asp:ListItem>
                                <asp:ListItem Text="02" Value="02"></asp:ListItem>
                                <asp:ListItem Text="03" Value="03"></asp:ListItem>
                                <asp:ListItem Text="04" Value="04"></asp:ListItem>
                                <asp:ListItem Text="05" Value="05" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="06" Value="06"></asp:ListItem>
                                <asp:ListItem Text="07" Value="07"></asp:ListItem>
                                <asp:ListItem Text="08" Value="08"></asp:ListItem>
                                <asp:ListItem Text="09" Value="09"></asp:ListItem>
                                <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                <asp:ListItem Text="12" Value="12"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlMMEndTime" runat="server" CssClass="inputf_def" Width="40px">
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlAMPMEndTime" runat="server" CssClass="inputf_def" Width="50px">
                                <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                <asp:ListItem Text="PM" Value="PM" Selected="True"></asp:ListItem>
                            </asp:DropDownList>
                            <span class="chkboxtxt_prsmall"><em>(Standard time is 05:00 PM)</em></span>
                        </span></span><span style="float: left; padding-top: 14px;">
                            <asp:TextBox ID="txtDuration" runat="server" CssClass="inputf_def" Width="80px" ReadOnly="true"></asp:TextBox>
                            Duration </span>
                </p>
                <p class="pagemainrow_anp">
                    <span class="inputfield250px_anp">Time Zone:<span class="reqiredmark"><sup>*</sup></span>
                        <asp:DropDownList ID="ddlTimeZone" runat="server" CssClass="inputf_def" Width="250px">
                            <asp:ListItem Text="pt">U.S. Pacific</asp:ListItem>
                            <asp:ListItem Text="mt">U.S. Mountain</asp:ListItem>
                            <asp:ListItem Text="ct">U.S. Central</asp:ListItem>
                            <asp:ListItem Text="et">U.S. Eastern</asp:ListItem>
                            <asp:ListItem Text="ak">U.S. Alaska</asp:ListItem>
                            <asp:ListItem Text="hi">U.S. Hawaii</asp:ListItem>
                            <asp:ListItem Text="">--------------------</asp:ListItem>
                            <asp:ListItem Text="-12">GMT -12:00  Dateline</asp:ListItem>
                            <asp:ListItem Text="-11">GMT -11:00  Samoa</asp:ListItem>
                            <asp:ListItem Text="-10">GMT -10:00  U.S. Hawaiian Time</asp:ListItem>
                            <asp:ListItem Text="-9.5">GMT -09:30  Marquesas</asp:ListItem>
                            <asp:ListItem Text="-9">GMT -09:00  U.S. Alaska Time</asp:ListItem>
                            <asp:ListItem Text="-8.5">GMT -08:30  Pitcarn</asp:ListItem>
                            <asp:ListItem Text="-8">GMT -08:00  Pacific Time</asp:ListItem>
                            <asp:ListItem Text="-7">GMT -07:00  U.S. Mountain Time</asp:ListItem>
                            <asp:ListItem Text="az">GMT -07:00  U.S. Mountain Time (Arizona)</asp:ListItem>
                            <asp:ListItem Text="-6" Selected="True">GMT -06:00  U.S. Central Time</asp:ListItem>
                            <asp:ListItem Text="mx">GMT -06:00  Mexico</asp:ListItem>
                            <asp:ListItem Text="-5">GMT -05:00  U.S. Eastern Time</asp:ListItem>
                            <asp:ListItem Text="in">GMT -05:00  U.S. Eastern Time (Indiana)</asp:ListItem>
                            <asp:ListItem Text="pe">GMT -05:00  Columbia, Peru, South America</asp:ListItem>
                            <asp:ListItem Text="-4">GMT -04:00  Atlantic Time</asp:ListItem>
                            <asp:ListItem Text="-3.5">GMT -03:30  Newfoundland, Canada</asp:ListItem>
                            <asp:ListItem Text="-3">GMT -03:00  Argentina</asp:ListItem>
                            <asp:ListItem Text="br">GMT -03:00  Brazil</asp:ListItem>
                            <asp:ListItem Text="-2">GMT -02:00  Mid-Atlantic</asp:ListItem>
                            <asp:ListItem Text="-1">GMT -01:00  Azores</asp:ListItem>
                            <asp:ListItem Text="+0">GMT U.K., Spain</asp:ListItem>
                            <asp:ListItem Text="+1">GMT +01:00  Western Europe</asp:ListItem>
                            <asp:ListItem Text="+2">GMT +02:00  Eastern Europe</asp:ListItem>
                            <asp:ListItem Text="eg">GMT +02:00  Egypt</asp:ListItem>
                            <asp:ListItem Text="il">GMT +02:00  Israel</asp:ListItem>
                            <asp:ListItem Text="+3">GMT +03:00  Russia</asp:ListItem>
                            <asp:ListItem Text="iq">GMT +03:00  Saudi Arabia</asp:ListItem>
                            <asp:ListItem Text="+3.5">GMT +03:30  Iran</asp:ListItem>
                            <asp:ListItem Text="+4">GMT +04:00  Arabian</asp:ListItem>
                            <asp:ListItem Text="+4.5">GMT +04:30  Afghanistan</asp:ListItem>
                            <asp:ListItem Text="+5">GMT +05:00  Pakistan, West Asia</asp:ListItem>
                            <asp:ListItem Text="+5.5">GMT +05:30  India</asp:ListItem>
                            <asp:ListItem Text="+6">GMT +06:00  Bangladesh, Central Asia</asp:ListItem>
                            <asp:ListItem Text="+6.5">GMT +06:30  Burma</asp:ListItem>
                            <asp:ListItem Text="+7">GMT +07:00  Bangkok, Hanoi, Jakarta</asp:ListItem>
                            <asp:ListItem Text="+8">GMT +08:00  China, Taiwan</asp:ListItem>
                            <asp:ListItem Text="sg">GMT +08:00  Singapore</asp:ListItem>
                            <asp:ListItem Text="+8">GMT +08:00  Australia (WT)</asp:ListItem>
                            <asp:ListItem Text="+9">GMT +09:00  Japan</asp:ListItem>
                            <asp:ListItem Text="kr">GMT +09:00  Korea</asp:ListItem>
                            <asp:ListItem Text="+9.5">GMT +09:30  Australia (CT)</asp:ListItem>
                            <asp:ListItem Text="+10">GMT +10:00  Australia (ET)</asp:ListItem>
                            <asp:ListItem Text="+10.5">GMT +10:30  Australia (Lord Howe)</asp:ListItem>
                            <asp:ListItem Text="+11">GMT +11:00  Central Pacific</asp:ListItem>
                            <asp:ListItem Text="+11.5">GMT +11:30  Norfolk Islands</asp:ListItem>
                            <asp:ListItem Text="+12">GMT +12:00  Fiji, New Zealand</asp:ListItem>
                        </asp:DropDownList>
                    </span><span class="inputfield250px_anp" style="margin-right: 10px">Schedule Template:<span
                        class="reqiredmark"><sup>*</sup></span>
                        <asp:DropDownList ID="ddlScheduleTemplate" runat="server" CssClass="inputf_def" Width="250px"
                            onChange="CheckChangeDropDown();">
                        </asp:DropDownList>
                    </span><span id="spnlinkviewslots" style="float: left; padding-top: 18px;"><a href="/App/Franchisee/SalesRep/TemplateTimeSlots.aspx"
                        id="ancTemplate" runat="server" rel="gb_page_center[270, 250]">View</a> </span>
                </p>
            </div>
        </div>
        <div class="subhead">
            <img src="/App/Images/page2symbolvsmall.gif" alt="" />
            <h2 class="toppad">
                Registration Mode</h2>
        </div>
        <div class="main_area_bdrnone">
            <div class="maindivpagemainrow_anp">
                <div class="pagemainrow_anp">
                    <span class="inputfield250px_anp" style="margin-right: 0;">Registration Mode:
                        <asp:DropDownList ID="ddlEventType" runat="server" CssClass="inputf_def" Width="90px">
                        </asp:DropDownList>
                    </span><span class="msgtxt_cew" id="spPrivateMsg">Private events will not show on general
                        registration on the website or call center. Private events will need an invitation
                        code to register. </span>
                </div>
                <div class="pagemainrow_anp" style="margin-top: 10px" id="divInvitaionCode">
                    <div class="greybox_cew" style="width: 400px;">
                        <asp:UpdatePanel ID="pnlCouponCode" runat="server">
                            <ContentTemplate>
                                <div class="row" style="font-weight: bold">
                                    <span class="titletextnowidth_default">Invitation Code:<span class="reqiredmark"><sup>*</sup></span></span>
                                    <span class="inputfldnowidth_default" style="margin-right: 5px;">
                                        <asp:TextBox ID="txtInvitationCode" runat="server" CssClass="inputf_def" Width="180px"></asp:TextBox>
                                    </span><span class="titletextnowidth_default">
                                        <asp:LinkButton ID="lnkGenerate" OnClick="lnkGenerate_Click" runat="server">Generate</asp:LinkButton>
                                    </span>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="pagemainrow_anp">
                    <span class="inputfield250px_anp" style="margin-right: 0; font-weight: normal;"><b>Event
                        Type:</b>
                        <asp:RadioButton ID="rbtnRetail" runat="server" Text="Retail" GroupName="EventType" />
                        <asp:RadioButton ID="rbtnCooperate" runat="server" Text="Cooperate" GroupName="EventType" />
                    </span>
                </div>
            </div>
            <div class="maindivpagemainrow_anp" style="margin-top: 5px;">
                <p class="pagemainrow_anp">
                    <span class="inputfield250px_anp" style="margin-right: 0" style="margin-top: 10px;
                        display: none;" id="divAccounts">Accounts:
                        <asp:DropDownList ID="ddlAccounts" runat="server" CssClass="inputf_def" Width="140px">
                        </asp:DropDownList>
                    </span><span class="inputfield350px_anp" style="margin-right: 0">Hospital Partnership:
                        <asp:DropDownList ID="ddlHospitalPartner" runat="server" CssClass="inputf_def" Width="140px">
                        </asp:DropDownList>
                    </span>
                </p>
            </div>
        </div>
        <div class="subhead">
            <img src="/App/Images/page3symbolvsmall.gif" alt="" />
            <h2 class="toppad">
                Pod</h2>
        </div>
        <div class="main_area_bdrnone" style="display: block" id="divInvalidEventDate">
            <div class="maindivpagemainrow_anp">
                <div class="greybox_cew">
                    <div class="row" style="font-weight: bold; color: #D60202;">
                        Please select an event date before you can select a pod
                    </div>
                </div>
            </div>
        </div>
        <div class="main_area_bdrnone" style="display: none" id="divValidEventDate">
            <div class="maindivpagemainrow_anp">
                <div class="pagemainrow_anp">
                    <span class="inputfield250px_anp" style="margin-right: 10px;">Pods Available on <span
                        id="spEventDate"></span>: <span id="spddlPOD">
                            <asp:DropDownList ID="ddlPOD" runat="server" CssClass="inputf_def" Width="250px">
                            </asp:DropDownList>
                        </span></span><span class="inputfldnowidth_default" style="padding-top: 12px; margin-right: 10px">
                            <a href="javascript:void(0);" onclick="showCalendar();">View Pod Calendar</a>
                    </span><span class="inputfldnowidth_default" style="padding-top: 12px;">
                        <asp:ImageButton ID="ibtnAtach" runat="server" ImageUrl="~/App/Images/attach-btn.gif"
                            OnClientClick="return GetPodDetails();" OnClick="ibtnAtach_Click" />
                    </span>
                </div>
                <div class="pagemainrow_anp" id="divPODDetails">
                    <div style="float: left; width: 600px; padding: 2px;">
                        <asp:GridView ID="gvPOD" GridLines="None" runat="server" CssClass="grid" DataKeyNames="PodID"
                            ShowHeader="false" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <div class="divaddpod_sne" id="Div2">
                                            <p class="middivrownopad_sne">
                                                <span class="boldtxt_sne">
                                                    <%# DataBinder.Eval(Container.DataItem, "PodName")%>
                                                </span><span class="removelnkright_sne">
                                                    <asp:LinkButton runat="server" ID="lnkRemovePod" Text="Remove" OnClick="lnkRemovePod_Click"
                                                        OnClientClick="return CheckPodDelete();" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "PodID")%>'></asp:LinkButton>
                                                </span>
                                            </p>
                                            <p class="middivrownopad_sne">
                                                <span class="titletxtgraynowidth_sne">
                                                    <%# DataBinder.Eval(Container.DataItem, "VanName")%>(<%# DataBinder.Eval(Container.DataItem, "Make")%>)
                                                    -
                                                    <%# DataBinder.Eval(Container.DataItem, "RegistrationNumber")%>
                                                </span>
                                            </p>
                                            <p class="middivrownopad_sne" style="display: none;">
                                                <span class="boldtxt_sne">Team Members</span>&nbsp;&nbsp; <span><a href="<%# DataBinder.Eval(Container.DataItem, "AddMemberURL")%>"
                                                    rel="gb_page_center[290, 285]">[ Add Member ]</a></span>
                                            </p>
                                            <div class="middivrownopad_sne" style="display: none;">
                                                <%# DataBinder.Eval(Container.DataItem, "TeamDescription")%>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <AlternatingRowStyle BackColor="White" />
                            <RowStyle BackColor="White" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
        <div class="subhead">
            <img src="/App/Images/page4symbolvsmall.gif" alt="" />
            <h2 class="toppad">
                Select Packages/Tests</h2>
        </div>
        <div class="main_area_bdrnone" style="display: block" id="NoPackageAvailableDiv"
            runat="server">
            <div class="maindivpagemainrow_anp">
                <div class="greybox_cew">
                    <div class="row" style="font-weight: bold; color: #D60202;">
                        Please attach a pod to get packages/tests.
                    </div>
                </div>
            </div>
        </div>
        <div class="main_area_bdrnone">
            <div class="maindivpagemainrow_anp" style="display: none" id="PackageAvailableDiv"
                runat="server">
                <div class="pagemainrow_anp">
                    <asp:GridView runat="server" ID="grdSelectPackage" AutoGenerateColumns="False" CssClass="divgrid_cl"
                        GridLines="None" OnRowDataBound="grdSelectPackage_RowDataBound">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkSelectAllPackage" runat="server" onclick="SelectAllPackage(this);" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <input class="package-checkbox" type="checkbox" id="chkRowChild" checked='<%#DataBinder.Eval(Container.DataItem, "IsSelectedByDefaultForEvent")%>'
                                        runat="server" />
                                    <span style="display: none;" class="package-id">
                                        <%#DataBinder.Eval(Container.DataItem, "PackageID")%></span>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Package Name">
                                <ItemTemplate>
                                    <%#DataBinder.Eval(Container.DataItem, "PackageName")%>
                                    <asp:HiddenField ID='hfPackageID' runat='server' Value='<%#DataBinder.Eval(Container.DataItem, "PackageID")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Standard Package Price">
                                <ItemTemplate>
                                    $&nbsp;<%#DataBinder.Eval(Container.DataItem, "Price")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Event Package Price">
                                <ItemTemplate>
                                    <asp:TextBox ID='txtEPPrice' runat='server' Text='<%#DataBinder.Eval(Container.DataItem, "Price")%>'
                                        Width='60px'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle CssClass="row2" />
                        <HeaderStyle CssClass="row1" />
                        <AlternatingRowStyle CssClass="row3" />
                    </asp:GridView>
                </div>
            </div>
            <div class="maindivpagemainrow_anp" style="display: none" id="_testDiv" runat="server">
                <div class="pagemainrow_anp">
                    <asp:GridView runat="server" ID="_testGrid" AutoGenerateColumns="False" CssClass="divgrid_cl"
                        GridLines="None" OnRowDataBound="testGrid_RowDataBound">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkSelectAllTest" runat="server" onclick="SelectAllTest(this);" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <span style="display: none;" class="test-id" id="_testIdSpan" runat="server">
                                        <%#DataBinder.Eval(Container.DataItem, "TestID")%></span>
                                    <input class="test-checkbox" type="checkbox" id="chkTestSelected" checked='<%#DataBinder.Eval(Container.DataItem, "IsTestDefaultSelected")%>'
                                        runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <span id="_testName" runat="server">
                                        <%#DataBinder.Eval(Container.DataItem, "Name")%></span>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Standard Test Price">
                                <ItemTemplate>
                                    $&nbsp;<%#DataBinder.Eval(Container.DataItem, "RecommendedPrice")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Event Test Price">
                                <ItemTemplate>
                                    <asp:TextBox ID='_txtEventTestPrice' runat='server' Text='<%#DataBinder.Eval(Container.DataItem, "RecommendedPrice")%>'
                                        Width='60px'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle CssClass="row2" />
                        <HeaderStyle CssClass="row1" />
                        <AlternatingRowStyle CssClass="row3" />
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div class="subhead">
            <img src="/App/Images/page4symbolvsmall.gif" alt="" />
            <h2 class="toppad">
                Event Status</h2>
        </div>
        <div class="main_area_bdrnone">
            <div class="maindivpagemainrow_anp">
                <p class="pagemainrow_anp">
                    <span class="inputfield250px_anp" style="margin-right: 10px;">
                        <asp:DropDownList ID="ddlEventStatus" runat="server" CssClass="inputf_def" Width="250px">
                        </asp:DropDownList>
                    </span><span class="inputfldnowidth_default"><a id="aToolTip" href="javascript:void(0);"
                        style="font-size: 18px; font-weight: bold" onmouseover="showToolTip();" onmouseout="hideToolTip();">
                        ?</a> </span>
                </p>
                <p class="pagemainrow_anp" id="pEventCancellationReason" style="display: none;">
                    <span class="inputfield250px_anp" style="margin-right: 5px;">Event Cancellation Reason:<span class="reqiredmark"><sup>*</sup></span>
                        <asp:DropDownList ID="ddlEventCancellationReason" runat="server" CssClass="inputf_def"
                            Width="250px">
                        </asp:DropDownList>
                    </span>
                </p>
                <p class="pagemainrow_anp" id="pEventNotes" style="display: none;">
                    <span class="inputfield250px_anp">Notes<span class="reqiredmark"><sup>*</sup></span>
                        <asp:TextBox ID="txtNotes" runat="server" CssClass="inputf_def" Width="250px" TextMode="MultiLine"></asp:TextBox>
                    </span>
                </p>
            </div>
        </div>
        <div class="subhead" id="divTaskAndSalesRepHeading" runat="server">
            <img src="/App/Images/page5symbolvsmall.gif" alt="" />
            <h2 class="toppad">
                Task and Sales Rep assignment</h2>
        </div>
        <div class="main_area_bdrnone">
            <div class="maindivpagemainrow_anp" id="divTaskAndSalesRepDetails" runat="server">
                <p class="pagemainrow_anp">
                    <span class="inputfield250px_anp" style="margin-right: 5px;">Event Task Template:
                        <asp:DropDownList ID="ddlEventTaskTemplate" runat="server" CssClass="inputf_def"
                            Width="250px">
                        </asp:DropDownList>
                    </span><span class="inputfldnowidth_default" style="padding-top: 12px;"><a href="javascript:void(0);"
                        onclick="showEventTemplateActivity();">View Activities</a> </span>
                </p>
            </div>
            <div class="maindivpagemainrow_anp" style="margin-top: 10px">
                <span class="buttoncon_default">
                    <asp:ImageButton ID="ibtnNext" runat="server" ImageUrl="~/App/Images/next-button.gif"
                          OnClientClick="return VaidateEvent();" />
                </span><span class="buttoncon4_default">
                    <asp:ImageButton ID="ibtnSaveClose" runat="server" ImageUrl="~/App/Images/save-n-close-gif.gif"
                        OnClick="ibtnSaveClose_Click" OnClientClick="return VaidateEvent();" />
                </span><span class="buttoncon_default">
                    <asp:ImageButton ID="ibtnBack" runat="server" ImageUrl="~/App/Images/back-buton.gif"
                        OnClick="ibtnBack_Click" />
                </span><span class="buttoncon_default">
                    <asp:ImageButton ID="ibtnCancel" runat="server" ImageUrl="~/App/Images/cancel-btn.gif"
                        OnClick="ibtnCancel_Click" />
                </span>
            </div>
            <div class="main_area_bdrnone">
                <span style="float: right; font: normal 10px arial; margin-bottom: 5px;">Next step you
                    get to define the advocates that can help promote the event. </span><span style="float: right;
                        padding-top: 3px; margin-bottom: 5px;">
                        <img src="/App/Images/small-orng-arrow.gif" /></span>
            </div>
        </div>
    </div>
    <div id="divToolTip" runat="server" style="position: absolute; display: none; border: solid 1px #FEF399;
        background-color: #FFFCDF; padding: 2px;">
    </div>
    <asp:HiddenField ID="hfPodID" runat="server" />
    <asp:LinkButton ID="lnkbtnTemp" runat="server"></asp:LinkButton>
    <%--BEGIN Pod Calendar DIV --%>
    <div id="ViewPodCalendar" title="View Pod Calendar" style="display: none">
        <div class="wrapperin_pop">
            <div class="innermain_pop" id="divCalendar">
            </div>
            <div class="prenextband" style="border-top: none;">
                <span style="float: left"><a href="javascript:void(0)" onclick="showPrevMonthPodCal();">
                    <img src="/App/Images/premonth-cal_event.gif" alt="Previous Month" /></a></span>
                <span style="float: right"><a href="javascript:void(0)" onclick="showNextMonthPodCal();">
                    <img src="/App/Images/nextmonth-cal_event.gif" alt="Next Month" /></a></span>
            </div>
        </div>
    </div>
    <%--END Pod Calendar DIV --%>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="lnkbtnTemp"
        PopupControlID="pnlEventActivity" BackgroundCssClass="modalBackground" CancelControlID="imgBtnCloseActivity"
        BehaviorID="mdlEventActivity" />
    <asp:Panel ID="pnlEventActivity" runat="server">
        <div class="wrapper_pop">
            <div class="wrapperin_pop">
                <div class="innermain_pop" id="divActivity">
                </div>
                <div class="innermain_pop" style="text-align: right; margin-top: 5px">
                    <asp:ImageButton runat="server" ID="imgBtnCloseActivity" ImageUrl="~/App/Images/close-btn.gif" />
                </div>
            </div>
        </div>
    </asp:Panel>
    <script type="text/javascript">
        $(document).ready(function () {
            //debugger;
            $('#ViewPodCalendar').dialog({ width: 580, height: 380, autoOpen: false, resizable: false, draggable: false });

            $(".date-picker").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "-10:+50"
            });

            $('#<%=rbtnCooperate.ClientID %>').bind("click", function () {
                ShowHideCooperateAccount();
            });

            $('#<%=rbtnRetail.ClientID %>').bind("click", function () {
                ShowHideCooperateAccount();
            });
        });

        function ShowHideCooperateAccount() {//debugger;
            if ($('#<%=rbtnCooperate.ClientID %>').attr('checked')) {
                $('#divAccounts').show();
            }
            else {
                $('#divAccounts').hide();
            }
        }

    </script>
</asp:Content>
