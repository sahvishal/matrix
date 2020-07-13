<%@ Control Language="C#" AutoEventWireup="true" Inherits="App_UCCommon_UCManageProspects"
    CodeBehind="UCManageProspects.ascx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<script type="text/javascript" src="/App/JavascriptFiles/HttpRequest.js" language="javascript"></script>
<script src="/App/JavascriptFiles/MaskEdit.js" language="javascript" type="text/javascript"></script>
<script type="text/javascript">

    var pagenumber = 1;
    var pagesize = 10;
    var issearch = false;
    var isreset = false;
    var curviewmode = 'ALL';
    var sortcolumn = '';
    var sortorder = 'Desc';
    var url = '';
    var blnsortflag = false;
    var startdate = '';
    var enddate = '';
    var currentTime = new Date();

    function Validate() {

        var txtPastStartDate = document.getElementById("<%= this.txtStartDate.ClientID %>");
        var txtPastEndDate = document.getElementById("<%= this.txtEndDate.ClientID %>");
        var ddlDistance = document.getElementById("<%= this.ddlDistance.ClientID %>");
        var txtZipcode = document.getElementById("<%= this.txtZipcode.ClientID %>");

        if (txtPastStartDate.value != "" && txtPastEndDate.value != "") {

            if (ValidateDate(txtPastStartDate.value, 'Date Range') == false) {
                return false;
            }
            if (ValidateDate(txtPastEndDate.value, 'Date Range') == false) {
                return false;
            }
            if (CompareTwoDates1(txtPastStartDate.value, txtPastEndDate.value) == false) {
                alert("EndDate should be grater than or equals to StartDate ");
                txtPastEndDate.focus();
                return false;
            }
        }

        else if (ddlDistance.value != "0" && txtZipcode.value == "") {
            alert('Please enter zipcode');
            txtZipcode.focus();
            return false;
        }
        else if (txtZipcode.value != "" && ddlDistance.value == "0") {
            alert('Please Select the distance');
            ddlDistance.focus();
            return false;
        }

        pagenumber = 1;
        GetProspectGridTable('All');
        return false;
    }
    function txtkeypress(evt) {
        return KeyPress_NumericAllowedOnly(evt);

    }
    function ValidateTask() {
        var txtTask = document.getElementById("<%= this.txtTask.ClientID %>");
        var txtDueDate = document.getElementById("<%= this.txtDueDate.ClientID %>");
        var txtDueTime = document.getElementById("<%= this.txtDueTime.ClientID %>");
        if (txtTask.value == '' && txtDueDate.value == '' && txtDueTime.value == '') {
            alert('Please enter atleast one task details');
            return false;
        }
    }

    function AddTask(ProspectID, AssignedStatus) {
        document.getElementById("<%= this.txtTask.ClientID %>").value = '';
        document.getElementById("<%= this.txtDueDate.ClientID %>").value = '';
        document.getElementById("<%= this.txtDueTime.ClientID %>").value = '';
        document.getElementById("<%= this.hidProspectid.ClientID %>").value = ProspectID;
        document.getElementById("<%= this.hidAssignedStatus.ClientID %>").value = AssignedStatus;
        $find('mdlPopup1').show();
        return false;
    }
    function HideTaskPopup() {
        $find('mdlPopup1').hide();
        return false;
    }

    var postRequest = new HttpRequest();
    postRequest.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    postRequest.failureCallback = requestFailed();
    function requestFailed() {

    }
    function SaveTask() {

        //var postRequest1 = new HttpRequest();
        var url = "/App/Common/AsyncAddTask.aspx?Add=Task";
        // task details
        var txtTask = document.getElementById("<%= this.txtTask.ClientID %>");
        var txtDueDate = document.getElementById("<%= this.txtDueDate.ClientID %>");
        var txtDueTime = document.getElementById("<%= this.txtDueTime.ClientID %>");
        var Prospectid = document.getElementById("<%= this.hidProspectid.ClientID %>").value;
        var hidUserId = document.getElementById("<%= this.hidUserId.ClientID %>").value;
        var hidRole = document.getElementById("<%= this.hidRole.ClientID %>").value;
        var hidAssignedStatus = document.getElementById("<%= this.hidAssignedStatus.ClientID %>").value;

        url = url + "&subject=" + txtTask.value;
        url = url + "&duedate=" + txtDueDate.value;
        url = url + "&duetime=" + txtDueTime.value;
        url = url + "&prospectid=" + Prospectid;
        url = url + "&assignedstatus=" + hidAssignedStatus;
        postRequest.url = url;
        postRequest.successCallback = requestSucess;
        postRequest.post("");
        return false;
    }
    function DeleteProspect(ProspectId) {
        if (confirm('Are you sure to delete prospect?')) {
            document.getElementById('divloading').style.visibility = "visible";
            document.getElementById('divloading').style.display = "block";
            //var postRequest1 = new HttpRequest();
            var url = "/App/Common/AsyncAddTask.aspx?Delete=Prospect";
            // Delete Prospect
            url = url + "&prospectid=" + ProspectId;
            postRequest.url = url;
            postRequest.successCallback = SucessDeleteProspect;
            postRequest.post("");
        }
        return false;
    }

    function SucessDeleteProspect(httpRequest) {
        if (httpRequest.responseText != "") {
            document.getElementById('divloading').style.visibility = "hidden";
            document.getElementById('divloading').style.display = "none";

            var hidPageNumber = document.getElementById("<%= this.hidPageNumber.ClientID %>").value;
            var result = '';
            //alert(httpRequest.responseText);
            result = httpRequest.responseText;
            var result1 = result.substr(46, 1);
            //alert(result1);
            if (result1 == 1) {
                GetProspectGridTable(curviewmode);
                alert('Prospect Deleted Successfully!');
            }
            else if (result1 == 0) {
                alert('Error occured in dtabase whiling deleting prospect.');
            }
        }
    }

    function requestSucess(httpRequest) {
        if (httpRequest.responseText != "") {
            var hidPageNumber = document.getElementById("<%= this.hidPageNumber.ClientID %>").value;
            var result = '';
            //alert(httpRequest.responseText);

            result = httpRequest.responseText;

            var result1 = result.substr(46, 1);
            //alert(result1);
            if (result1 == 1) {
                $find('mdlPopup1').hide();
                GetProspectGridTable(curviewmode);
                alert('Task Added Sucessfully');

            }
            else if (result1 == 0) {
                $find('mdlPopup1').hide();
                alert('Task Added Sucessfully');

            }
            else {
                alert('Please enter atleast one task details');
            }
        }
    }

    function RedirectCall(prospectid, noofcalls) {
        if (noofcalls > 0) {
            window.location = "/App/Franchisor/ViewCall.aspx?Type=Prospect&ProspectId=" + prospectid;
        }
        else {
            alert('No call to view');
        }
    }
    function RedirectContact(prospectid, noofcontacts) {
        if (noofcontacts > 0) {
            window.location = "/App/Franchisor/ViewContact.aspx?ProspectID=" + prospectid;
        }
        else {
            alert('No contacts to view');
        }
    }
    function RedirectMeeting(prospectid, noofmeetings) {
        if (noofmeetings > 0) {
            window.location = "/App/Franchisor/ViewMeetings.aspx?Type=Prospect&ProspectID=" + prospectid;
        }
        else {
            alert('No meetings to view');
        }
    }

    function AddSlotAutoFill(textbox) {
        dFilter_AutoFill(textbox);
    }
    function FilterTime(key, textbox, dFilterMask) {
        return dFilter(key, textbox, dFilterMask);
    }

    //on click
    function ShowActionList(userid, ancAction) {
        //alert ( "divActionList");alert(userid);
        var divActionListID = document.getElementById("divActionList" + userid);
        divActionListID.style.display = "block";

        var dim = GetTopLeft(ancAction);

        divActionListID.style.top = parseInt(dim.Top) + 2 + 'px';
        divActionListID.style.left = (parseInt(dim.Left) - 72) + 'px';
    }

    //on mouse out
    function HideActionList(userid, evt) {//debugger
        var divActionListID = document.getElementById("divActionList" + userid);

        var dom = (document.getElementById) ? true : false;
        var ns5 = (!document.all && dom || window.opera) ? true : false;
        var standardbody = (document.compatMode == "CSS1Compat") ? document.documentElement : document.body
        var mouseX = (ns5) ? evt.pageX : window.event.clientX + standardbody.scrollLeft;
        var mouseY = (ns5) ? evt.pageY : window.event.clientY + standardbody.scrollTop;

        var topY, leftX, bottomY, rightX;
        topY = divActionListID.offsetTop;
        leftX = divActionListID.offsetLeft;
        bottomY = divActionListID.offsetTop + divActionListID.clientHeight;
        rightX = divActionListID.offsetLeft + divActionListID.clientWidth;

        if (topY < mouseY && leftX < mouseX && bottomY > mouseY && rightX > mouseX) {
            return;
        }
        divActionListID.style.display = "none";
    }
    function HideActionLinksITSELF(alinks, evt) {
        alinks.parentNode.style.display = "none";
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
    /// Async Manage Prospects

    var postRequest = new HttpRequest();
    postRequest.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    function LoadProspectTable(viewmode) {

        SetImage(viewmode);
        curviewmode = viewmode;
        GetProspectGridTable(viewmode);

    }

    function LoadProspectTableonPageSizeChange() {
        var newpagesize;
        newpagesize = document.getElementById('<%= this.ddlProspectRecords.ClientID %>').options[document.getElementById('<%= this.ddlProspectRecords.ClientID %>').selectedIndex].text;

        //alert(newpagesize);
        if (document.getElementById('<%= this.hidPageNumber.ClientID %>').value != '') {
            pagenumber = document.getElementById('<%= this.hidPageNumber.ClientID %>').value;
        }
        var newpagenum = (((pagenumber - 1) * pagesize) / newpagesize) + 1;

        pagenumber = newpagenum;
        pagesize = newpagesize;
        GetProspectGridTable(curviewmode);
    }

    function LoadProspectTableonPageChange(selpagenumber) {
        pagenumber = selpagenumber;
        GetProspectGridTable(curviewmode);
    }

    function LoadProspectTableonSort(sortcolumn_new) {
        if (sortcolumn == sortcolumn_new) {
            if (sortorder == 'asc') sortorder = 'desc'; else sortorder = 'asc'
        } else sortorder = 'asc';
        sortcolumn = sortcolumn_new;
        GetProspectGridTable(curviewmode);
        return false;
    }


    function GetProspectGridTable(viewmode) {
        SetImage(viewmode);
        //document.getElementById('divProspect').disabled="disabled";
        document.getElementById('<%= this.divProspect.ClientID %>').disabled = 'disabled';
        document.getElementById('spLoading').style.display = 'block';
        curviewmode = viewmode;
        GetUrl();
        postRequest.url = url;
        postRequest.successCallback = SetGrid;
        postRequest.failureCallback = requestFailed();
        postRequest.post("");

    }
    function GetProspectGridTableOnButton(viewmode) {
        // set date and 
        if (viewmode != '') {
            setdate(viewmode);
        }
        pagenumber = 1;
        SetImage(viewmode);
        curviewmode = viewmode;
        GetProspectGridTable(curviewmode);
        return false;
    }

    function SetImage(viewmode) {

        if (viewmode == 'All') {
            document.getElementById('<%= this.ibtnEAll.ClientID %>').src = '/App/Images/MarketingPartner/All-tab-active_mp.gif';
            document.getElementById('<%= this.ibtnEThisMonth.ClientID %>').src = '/App/Images/MarketingPartner/thismonth-tab-off_mp.gif';
            document.getElementById('<%= this.ibtnEThisWeek.ClientID %>').src = '/App/Images/MarketingPartner/thisweek-tab-off_mp.gif';
            document.getElementById('<%= this.ibtnEToday.ClientID %>').src = '/App/Images/MarketingPartner/today-tab-off_mp.gif';
        }
        else if (viewmode == 'ThisMonth') {
            document.getElementById('<%= this.ibtnEAll.ClientID %>').src = '/App/Images/MarketingPartner/All-tab-off_mp.gif';
            document.getElementById('<%= this.ibtnEThisMonth.ClientID %>').src = '/App/Images/MarketingPartner/thismonth-tab-active_mp.gif';
            document.getElementById('<%= this.ibtnEThisWeek.ClientID %>').src = '/App/Images/MarketingPartner/thisweek-tab-off_mp.gif';
            document.getElementById('<%= this.ibtnEToday.ClientID %>').src = '/App/Images/MarketingPartner/today-tab-off_mp.gif';
        }
        else if (viewmode == 'ThisWeek') {
            document.getElementById('<%= this.ibtnEAll.ClientID %>').src = '/App/Images/MarketingPartner/All-tab-off_mp.gif';
            document.getElementById('<%= this.ibtnEThisMonth.ClientID %>').src = '/App/Images/MarketingPartner/thismonth-tab-off_mp.gif';
            document.getElementById('<%= this.ibtnEThisWeek.ClientID %>').src = '/App/Images/MarketingPartner/thisweek-tab-active_mp.gif';
            document.getElementById('<%= this.ibtnEToday.ClientID %>').src = '/App/Images/MarketingPartner/today-tab-off_mp.gif';
        }
        else if (viewmode == 'Today') {
            document.getElementById('<%= this.ibtnEAll.ClientID %>').src = '/App/Images/MarketingPartner/All-tab-off_mp.gif';
            document.getElementById('<%= this.ibtnEThisMonth.ClientID %>').src = '/App/Images/MarketingPartner/thismonth-tab-off_mp.gif';
            document.getElementById('<%= this.ibtnEThisWeek.ClientID %>').src = '/App/Images/MarketingPartner/thisweek-tab-off_mp.gif';
            document.getElementById('<%= this.ibtnEToday.ClientID %>').src = '/App/Images/MarketingPartner/today-tab-active_mp.gif';
        }
    }

    function GetUrl() {

        url = "/App/Common/AsyncManageProspect.aspx?ishost=false";
        // search details
        var txtProspectName = document.getElementById("<%= this.txtProspectName.ClientID %>");
        var txtStartDate = document.getElementById("<%= this.txtStartDate.ClientID %>");
        var txtEndDate = document.getElementById("<%= this.txtEndDate.ClientID %>");
        var ddlSalesPerson = document.getElementById("<%= this.ddlSalesPerson.ClientID %>");
        var ddlFranchisee = document.getElementById("<%= this.ddlFranchisee.ClientID %>");
        var ddlDistance = document.getElementById("<%= this.ddlDistance.ClientID %>");
        var txtZipcode = document.getElementById("<%= this.txtZipcode.ClientID %>");
        var ddlProgress = document.getElementById("<%= this.ddlProgress.ClientID %>");
        var ddlType = document.getElementById("<%= this.ddlType.ClientID %>");
        var ddlAssignedStatus = document.getElementById("<%= this.ddlAssignedStatus.ClientID %>");
        var ddlTerritory = document.getElementById("<%= this.ddlTerritory.ClientID %>");
        var ddlWillPromote = document.getElementById("<%= this.ddlWillPromote.ClientID %>");
        var ddlHostStatus = document.getElementById("<%= this.ddlHostStatus.ClientID %>");
        var ddlHostedInPast = document.getElementById("<%= this.ddlHostedInPast.ClientID %>");
        var hidRole = document.getElementById("<%= this.hidRole.ClientID %>").value;
        var ProspectListID = document.getElementById("<%= this.hidProspectListID.ClientID %>").value;
        var _assignedTo = document.getElementById("<%= this._assignedTo.ClientID %>");
        var quickSearch = '<%=QuickSearch %>';

        url = url + "&prospectname=" + txtProspectName.value;

        if (txtStartDate.value != '')
            url = url + "&startdate=" + txtStartDate.value;
        else url = url + "&startdate=" + startdate;

        if (txtEndDate.value != '')
            url = url + "&enddate=" + txtEndDate.value;
        else url = url + "&enddate=" + enddate;
        if (hidRole == 'FranchisorAdmin' && ddlFranchisee != null) {
            url = url + "&franchiseeid=" + ddlFranchisee.value;
            if (ddlSalesPerson != null)
                url = url + "&salesrepid=" + ddlSalesPerson.value;
        }
        else if (hidRole == 'FranchiseeAdmin' && ddlSalesPerson != null) {
            url = url + "&salesrepid=" + ddlSalesPerson.value;
        }
        else if (hidRole == 'SalesRep' && ddlSalesPerson != null) {
            if (ddlSalesPerson.value != '0')
                url = url + "&salesrepid=" + ddlSalesPerson.value;
            else
                url = url + "&salesrepid=" + document.getElementById("<%= this.hidUserId.ClientID %>").value;
        }
        url = url + "&role=" + hidRole;
        url = url + "&distance=" + ddlDistance.value;
        url = url + "&zipcode=" + txtZipcode.value;
        url = url + "&progress=" + ddlProgress.value;
        url = url + "&type=" + ddlType.value;
        url = url + "&assignedstatus=" + ddlAssignedStatus.value;
        if (ddlTerritory != null)
            url = url + "&territory=" + ddlTerritory.value;

        url = url + "&willpromote=" + ddlWillPromote.value;
        url = url + "&willhost=" + ddlHostStatus.value;
        url = url + "&hostedinpast=" + ddlHostedInPast.value;
        if (ProspectListID != '' && ProspectListID > 0)
            url = url + "&prospectlistid=" + ProspectListID;
        url = url + "&pagenumber=" + pagenumber;
        url = url + "&pagesize=" + pagesize;

        url = url + "&sortcolumn=" + sortcolumn;
        url = url + "&sortorder=" + sortorder;
        url = url + "&QuickSearch=" + quickSearch;
        url = url + "&assignedTo=" + _assignedTo.value;

        if (isreset == true) url = url + "&isreset=true";
        //alert(url);

    }

    function SetGrid(httpRequest) {

        var result = httpRequest.responseText;
        var firstindex = result.indexOf('spnTotalRecordAsync');
        var lastindex = result.lastIndexOf('</span>');

        var mainresult = result.substring(0, firstindex - 1);
        var totalrecord = result.substring(firstindex + 20, lastindex);
        spCount = document.getElementById("<%= this.spCount.ClientID %>");
        RedirectToLogin(result);

        if (result.indexOf('No Records Found') > -1) {
            //document.getElementById('divProspect').innerHTML = httpRequest.responseText;
            document.getElementById('<%= this.divProspect.ClientID %>').innerHTML = httpRequest.responseText;
            spCount.innerHTML = '';
        }
        else if (result.indexOf('Some Error occured') > -1) {
            document.getElementById('<%= this.divProspect.ClientID %>').innerHTML = httpRequest.responseText;
            spCount.innerHTML = '';
        }
        else if (result.indexOf('QuickSearch=True') > -1) {
            window.location = httpRequest.responseText;
        }
        else {

            spCount.innerHTML = totalrecord + " Results Found";
            document.getElementById('<%= this.divProspect.ClientID %>').innerHTML = mainresult;
        }
        //alert(httpRequest.responseText);

        document.getElementById('<%= this.divProspect.ClientID %>').disabled = '';
        document.getElementById('spLoading').style.display = 'none';
    }
    function RedirectToLogin(result) {
        var firstindex = result.indexOf('<title>');
        var lastindex = result.indexOf('</title>');
        var pagetitle = result.substring(firstindex + 7, lastindex);
        //alert(pagetitle);alert(pagetitle.length);
        if (pagetitle.indexOf('HealthYes::User Login') > 0) {
            document.getElementById('<%= this.divProspect.ClientID %>').innerHTML = '';
            window.location = "/App/default.aspx";

        }
    }
    function resetsearchpanel() {

        document.getElementById("<%= this.txtProspectName.ClientID %>").value = '';
        document.getElementById("<%= this.txtStartDate.ClientID %>").value = '';
        document.getElementById("<%= this.txtEndDate.ClientID %>").value = '';

        startdate = ''; enddate = '';

        ddlFranchisee = document.getElementById("<%= this.ddlFranchisee.ClientID %>");
        if (ddlFranchisee != null)
            ddlFranchisee.options[0].selected = true;

        document.getElementById("<%= this.ddlProspectRecords.ClientID %>").options[1].selected = true;
        document.getElementById("<%= this.ddlDistance.ClientID %>").options[0].selected = true;
        document.getElementById("<%= this.txtZipcode.ClientID %>").value = '';
        document.getElementById("<%= this.ddlProgress.ClientID %>").options[0].selected = true;
        document.getElementById("<%= this.ddlType.ClientID %>").options[0].selected = true;
        document.getElementById("<%= this.ddlAssignedStatus.ClientID %>").options[0].selected = true;
        if (document.getElementById("<%= this.ddlTerritory.ClientID %>") != null)
            document.getElementById("<%= this.ddlTerritory.ClientID %>").options[0].selected = true;

        document.getElementById("<%= this.ddlWillPromote.ClientID %>").options[0].selected = true;
        document.getElementById("<%= this.ddlHostStatus.ClientID %>").options[0].selected = true;
        document.getElementById("<%= this.ddlHostedInPast.ClientID %>").options[0].selected = true;
        document.getElementById("<%= this.hidProspectListID.ClientID %>").value = '';

        if (document.getElementById("<%= this._assignedTo.ClientID %>") != null && document.getElementById("<%= this._assignedTo.ClientID %>").options[0] != null)
            document.getElementById("<%= this._assignedTo.ClientID %>").options[0].selected = true;

        if (document.getElementById("<%= this.ddlSalesPerson.ClientID %>") != null && document.getElementById("<%= this.ddlSalesPerson.ClientID %>").options[0] != null)
            document.getElementById("<%= this.ddlSalesPerson.ClientID %>").options[0].selected = true;

        pagenumber = 1; pagesize = 10; sortcolumn = ''; sortorder = 'Desc';
        viewmode = 'All';
        isreset = true;
        SetImage(viewmode);
        curviewmode = viewmode;
        GetProspectGridTable(curviewmode);
        return false;
    }
    function RelatedProspect(zipcode, assignedstatus) {
        document.getElementById("<%= this.ddlDistance.ClientID %>").options[1].selected = true;
        var ddlAssignedStatus = document.getElementById("<%= this.ddlDistance.ClientID %>")
        document.getElementById("<%= this.txtZipcode.ClientID %>").value = zipcode;
        if (assignedstatus == 1) ddlAssignedStatus.options[1].selected = true;
        else if (assignedstatus == 2) ddlAssignedStatus.options[2].selected = true;
        pagenumber = 1;
        GetProspectGridTable('All');
        return false;
    }
    function setdate(viewmode_new) {
        document.getElementById("<%= this.txtStartDate.ClientID %>").value = '';
        document.getElementById("<%= this.txtEndDate.ClientID %>").value = '';

        if (viewmode_new == 'Today') {
            var todaysDate = CalculateOffset(currentTime, 0);
            startdate = todaysDate;
            enddate = todaysDate;
        }
        else if (viewmode_new == 'ThisWeek') {
            var firstDay = CalculateOffset(currentTime, currentTime.getDay());
            var lastDay = CalculateOffset(currentTime, -(6 - currentTime.getDay()));
            startdate = firstDay;
            enddate = lastDay;
        }
        else if (viewmode_new == 'ThisMonth') {
            var month = currentTime.getMonth() + 1;
            var year = currentTime.getFullYear();

            var lastDay;
            if (currentTime.getMonth() == 0 || currentTime.getMonth() == 2 || currentTime.getMonth() == 4 || currentTime.getMonth() == 6 || currentTime.getMonth() == 7 || currentTime.getMonth() == 9 || currentTime.getMonth() == 11)
                lastDay = "31";
            else if (currentTime.getMonth() == 3 || currentTime.getMonth() == 5 || currentTime.getMonth() == 8 || currentTime.getMonth() == 10)
                lastDay = "30";
            else if (currentTime.getMonth() == 1 && year % 4 == 0)
                lastDay = "29";
            else if (currentTime.getMonth() == 1 && year % 4 != 0)
                lastDay = "28"

            startdate = month + "/01/" + year;
            enddate = month + "/" + lastDay + "/" + year;
        }
        else if (viewmode_new == 'All') {
            startdate = ''; enddate = '';
        }
        //alert(startdate);alert(enddate);
    }

    function CalculateOffset(today, offset) {

        var day = today.getDate();
        var month = today.getMonth() + 1;
        var year = today.getFullYear();

        if (offset != 0) {
            day = day - offset;
            if (day < 1) {
                if (month == 1) day = 31 + day;
                if (month == 2) day = 31 + day;
                if (month == 3) {
                    if ((year == 00) || (year == 04)) {
                        day = 29 + day;
                    }
                    else {
                        day = 28 + day;
                    }
                    year = year - 1;
                }
                if (month == 4) day = 31 + day;
                if (month == 5) day = 30 + day;
                if (month == 6) day = 31 + day;
                if (month == 7) day = 30 + day;
                if (month == 8) day = 31 + day;
                if (month == 9) day = 31 + day;
                if (month == 10) day = 30 + day;
                if (month == 11) day = 31 + day;
                if (month == 12) day = 30 + day;
                if (month == 1) {
                    month = 12;
                    year = year - 1;
                }
                else {
                    month = month - 1;
                }
            }

            if (day > 31 && (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)) {
                day = day - 31;

                if (month == 12) {
                    month = "01";
                    year = year + 1;
                }
                else
                    month = 1 + month;
            }
            else if (day > 30 && (month == 4 || month == 6 || month == 9 || month == 11)) {
                day = day - 30;
                month = 1 + month;
            }
            else if (day > 28 && month == 2 && year % 4 != 0) {
                day = day - 28;
                month = 1 + month
            }
            else if (day > 29 && month == 2 && year % 4 == 0) {
                day = day - 29;
                month = 1 + month
            }
        }

        if (day.toString().length == 1)
            day = "0" + day;


        return month + "/" + day + "/" + year;

    }
    
</script>
<style type="text/css">
    .spactionlink_cdpage
    {
        width: 460px;
        float: left;
        text-align: right;
        padding-right: 10px;
    }
    .spaction_cdpage
    {
        width: 135px;
        position: absolute;
        z-index: 100;
        border: solid 1px #2A6E95;
        background-color: White;
    }
    .spactioninner_cdpage
    {
        width: 135px;
    }
    .spactionelement_cdpage
    {
        width: 125px;
        padding-left: 10px;
        padding-top: 5px;
        padding-bottom: 5px;
        border-bottom: solid 1px Gray;
        float: left;
    }
</style>
<style type="text/css">
    /*---------- bubble tooltip -----------*/
    a.tt
    {
        position: relative;
        z-index: 24;
        color: #287AA8;
        font-weight: normal;
        text-decoration: none;
    }
    a.tt span
    {
        display: none;
    }
    /*background:; ie hack, something must be changed in a for ie to execute it*/
    a.tt:hover
    {
        z-index: 25;
        color: #ff6600;
        text-decoration: none;
    }
    a.tt:hover span.tooltip
    {
        display: block;
        position: absolute;
        top: 0px;
        left: 0;
        padding: 15px 0 0 0;
        width: 200px;
        color: #287AA8;
        text-align: left;
        filter: alpha(opacity:90);
        khtmlopacity: 0.90;
        mozopacity: 0.90;
        opacity: 0.90;
        text-decoration: none;
    }
    a.tt:hover span.top
    {
        display: block;
        padding: 30px 8px 0;
        background: url(/App/Images/bubble.gif) no-repeat top;
        text-decoration: none;
    }
    a.tt:hover span.middle
    {
        /* different middle bg for stretch */
        display: block;
        padding: 0 8px;
        background: url(/App/Images/bubble_filler.gif) repeat bottom;
        color: #000;
        text-decoration: none;
    }
    a.tt:hover span.bottom
    {
        display: block;
        padding: 3px 8px 10px;
        color: #ff6600;
        background: url(/App/Images/bubble.gif) no-repeat bottom;
        text-decoration: none;
    }
    
    .greybox_anp
    {
        float: left;
        width: 500px;
        padding: 10px;
        background-color: #fff;
        border: solid 2px #ccc;
    }
    .greybox_anp .row
    {
        float: left;
        width: 494px;
        font-weight: bold;
    }
    .inputfield110px_anp
    {
        float: left;
        width: 110px;
        font: bold 12px arial;
        color: #000;
    }
</style>
<style type="text/css">
    .wrapper_pop
    {
        float: left;
        width: 502px;
        padding: 10px;
        background-color: #f5f5f5;
    }
    .wrapperin_pop
    {
        float: left;
        width: 478px;
        border: solid 2px #4888AB;
        padding: 10px;
        background-color: #fff;
    }
    .innermain_pop
    {
        float: left;
        width: 458px;
        padding: 0px 5px 0px 5px;
    }
    .innermain_1_pop
    {
        float: left;
        width: 463px;
        padding-top: 5px;
    }
</style>
<style type="text/css">
    #divloading
    {
        position: fixed;
        top: 20px;
        left: 10px;
    }
</style>
<div class="mainbody_outer" style="margin-top: 0px">
    <div id="divloading" class="loadingdiv_ucecustlist" style="visibility: hidden; display: none;">
        <span style="float: left; padding-right: 5px" class="blktext14px_default">Loading...</span>
        <span style="float: left">
            <img src="/App/Images/loading.gif" /></span>
    </div>
    <div class="mainbody_inner">
        <div class="main_area_bdrnone">
            <div class="headingbox_top_body">
                <p>
                    <img src="/App/Images/specer.gif" width="750px" height="5px" /></p>
                <span class="orngheadtxt_heading" id="sptitle" runat="server">Manage Prospects</span>
                <span class="headingright_default"><a href="/App/Common/AddNewProspect.aspx" runat="server"
                    id="lnkNewProspect">+ Add new Prospect</a></span>
            </div>
            <p>
                <img src="/App/Images/specer.gif" width="750px" height="2px" /></p>
            <p class="graylinefull_common">
                <img src="/App/Images/specer.gif" width="1px" height="1px" /></p>
        </div>
        <div class="maindivredmsgbox" id="errordiv" enableviewstate="false" visible="false"
            runat="server">
        </div>
        <div class="main_area_bdrnone">
            <p>
                <img src="../Images/specer.gif" width="720px" height="5px" /></p>
            <div class="grayboxtop_cl">
                <asp:Panel ID="Panel1" it="PnlSearch" runat="server" DefaultButton="ibtnSearch">
                    <p class="grayboxtopbg_cl">
                        <img src="/App/Images/specer.gif" width="746" height="6" alt="" /></p>
                    <p class="grayboxheader_cl">
                        Filter Prospects</p>
                    <div class="lgtgraybox_cl" id="divStartCallSearch" runat="server">
                        <p class="lgtgrayboxrow_cl" style="padding-top: 10px;">
                            <span class="titletext_default">Name:</span> <span class="inputfieldright_default">
                                <asp:TextBox ID="txtProspectName" runat="server" Width="145px"></asp:TextBox></span>
                            <span class="titletext_default">Created Between:</span> <span class="dateinputfldnowidth_cl">
                                <asp:TextBox ID="txtStartDate" runat="server" CssClass="inputf_def date-picker" Width="80px"></asp:TextBox></span>
                            <span class="calendarcntrl_default"></span><span class="dateinputfldnowidth_cl">&nbsp;&nbsp;-To-&nbsp;&nbsp;<asp:TextBox
                                ID="txtEndDate" runat="server" CssClass="inputf_def date-picker" Width="80px"></asp:TextBox></span>
                        </p>
                        <p class="lgtgrayboxrow_cl" style="padding-top: 10px;">
                            <span id="spanFranchisee" runat="server"><span id="Span3" class="titletext_default"
                                runat="server">Franchisee:</span> <span class="inputfieldright_default">
                                    <asp:DropDownList ID="ddlFranchisee" runat="server" Width="150px">
                                    </asp:DropDownList>
                                </span></span><span class="titletext_default" id="_spnDistance" runat="server">Distance:</span>
                            <span class="dateinputfldnowidth_cl" id="SpanDistanceDrpoDown" runat="server">
                                <asp:DropDownList ID="ddlDistance" runat="server" Width="115px">
                                </asp:DropDownList>
                                &nbsp; </span><span class="dateinputfldnowidth_cl">&nbsp;From Zip Code&nbsp;</span>
                            <span class="dateinputfldnowidth_cl">
                                <asp:TextBox ID="txtZipcode" runat="server" CssClass="inputf_def" Width="80px" MaxLength="10"></asp:TextBox>
                            </span>
                        </p>
                        <p class="lgtgrayboxrow_cl" style="padding-top: 10px;">
                            <span class="titletext_default">Prospect Category:</span> <span class="inputfieldright_default">
                                <asp:DropDownList ID="ddlProgress" runat="server" Width="100px" CssClass="inputf_def">
                                </asp:DropDownList>
                            </span><span class="titletextsmallbld1_default">Type:</span> <span class="dateinputfldnowidth_cl">
                                <asp:DropDownList ID="ddlType" runat="server" Width="300px" CssClass="inputf_def">
                                </asp:DropDownList>
                            </span>
                        </p>
                        <p class="lgtgrayboxrow_cl" style="padding-top: 10px;">
                            <span class="titletext_default">Status:</span> <span class="inputfieldright_default">
                                <asp:DropDownList ID="ddlAssignedStatus" runat="server" Width="100px" Height="21px">
                                </asp:DropDownList>
                            </span><span id="spTerritory" runat="server"><span class="titletextsmallbld1_default">
                                Territory:</span> <span class="dateinputfldnowidth_cl">
                                    <asp:DropDownList ID="ddlTerritory" runat="server" Width="200px" CssClass="inputf_def">
                                    </asp:DropDownList>
                                </span></span>
                        </p>
                        <p class="lgtgrayboxrow_cl" style="padding-top: 10px;">
                            <span class="titletext_default">Will Promote:</span> <span class="inputfieldright_default">
                                <asp:DropDownList ID="ddlWillPromote" runat="server" Width="100px">
                                    <asp:ListItem Text="All" Value="3" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Unknown" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                            </span><span id="Span5" runat="server"><span class="titletextsmallbld1_default">Will
                                Host:</span> <span class="dateinputfldnowidth_cl">
                                    <asp:DropDownList ID="ddlHostStatus" runat="server" Width="100px">
                                        <asp:ListItem Text="All" Value="3" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Unknown" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                </span></span>
                        </p>
                        <p class="lgtgrayboxrow_cl" style="padding-top: 10px;">
                            <span id="Span6" runat="server"><span class="titletext_default">Hosted In Past:</span>
                                <span class="inputfieldright_default">
                                    <asp:DropDownList ID="ddlHostedInPast" runat="server" Width="100px">
                                        <asp:ListItem Text="All" Value="3" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Unknown" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                </span></span><span id="_spnAssignedTo" runat="server"><span class="titletextsmallbld1_default">
                                    Assigned To:</span> <span class="dateinputfldnowidth_cl">
                                        <asp:DropDownList ID="_assignedTo" runat="server" Width="150px">
                                        </asp:DropDownList>
                                    </span></span><span id="spanSalesPerson" runat="server"><span class="titletextsmallbld1_default">
                                        HSC:</span> <span class="dateinputfldnowidth_cl" style="margin-right: 25px;">
                                            <asp:DropDownList ID="ddlSalesPerson" runat="server" Width="200px">
                                            </asp:DropDownList>
                                        </span></span>
                        </p>
                    </div>
                    <div class="lgtgraybox_cl">
                        <span class="buttoncon_default">
                            <asp:ImageButton ID="ibtnSearch" runat="server" ImageUrl="~/App/Images/search-smallbtn.gif"
                                OnClientClick="return Validate();" />
                        </span><span class="buttoncon_default">
                            <asp:ImageButton ID="ibtnReset" runat="server" ImageUrl="~/App/Images/reset-btn.gif"
                                OnClientClick="return resetsearchpanel();" /></span>
                    </div>
                    <p class="grayboxbotbg_cl">
                        <img src="/App/Images/specer.gif" width="746" height="4" /></p>
                </asp:Panel>
            </div>
            <p>
                <img src="../Images/specer.gif" width="720px" height="5px" /></p>
            <p>
                <img src="/App/Images/specer.gif" width="700px" height="5px" /></p>
            <p class="divmainbody_cd">
                <%-- <span class="blkheadtxt_regcust" id="spnTotalText" runat="server" style="float: left;"></span>--%>
                <span class="blueheadtxt_regcust" id="Span2" runat="server" style="float: left;"><span
                    id="spCount" runat="server" style="float: left;"></span></span><span class="rightlnktxt_cl">
                        <asp:DropDownList ID="ddlProspectRecords" AutoPostBack="false" CssClass="inputf_def"
                            Width="50px" runat="server">
                            <asp:ListItem Value="5">5</asp:ListItem>
                            <asp:ListItem Value="10" Selected="True">10</asp:ListItem>
                            <asp:ListItem Value="20">20</asp:ListItem>
                            <asp:ListItem Value="30">30</asp:ListItem>
                            <asp:ListItem Value="40">40</asp:ListItem>
                            <asp:ListItem Value="50">50</asp:ListItem>
                        </asp:DropDownList>
                    </span><span class="rightlnktxt_cl">Records Per Page :&nbsp;</span>
            </p>
            <p>
                <img src="/App/Images/specer.gif" width="720px" height="5px" /></p>
            <p class="graylinefull_default">
                <img src="/App/Images/specer.gif" width="1px" height="1px" /></p>
            <p>
                <img src="/App/Images/specer.gif" width="725px" height="5px" /></p>
            <div class="grayboxtop_cl">
                <div class="grayboxtop_cl" style="float: left; padding: 0px; margin: 0px; height: 27px;"
                    id="divDateRange" runat="server">
                    <span style="float: left">
                        <asp:ImageButton ID="ibtnEToday" runat="server" ImageUrl="~/App/Images/MarketingPartner/today-tab-off_mp.gif"
                            OnClientClick="return GetProspectGridTableOnButton('Today');" />
                        <asp:ImageButton ID="ibtnEThisWeek" runat="server" ImageUrl="~/App/Images/MarketingPartner/thisweek-tab-off_mp.gif"
                            OnClientClick="return GetProspectGridTableOnButton('ThisWeek');" />
                        <asp:ImageButton ID="ibtnEThisMonth" runat="server" ImageUrl="~/App/Images/MarketingPartner/thismonth-tab-off_mp.gif"
                            OnClientClick="return GetProspectGridTableOnButton('ThisMonth');" />
                        <asp:ImageButton ID="ibtnEAll" runat="server" ImageUrl="~/App/Images/MarketingPartner/All-tab-off_mp.gif"
                            OnClientClick="return GetProspectGridTableOnButton('All');" />
                    </span>
                    <%--Begin Loading Span--%>
                    <span id="spLoading" style="float: left; display: none;"><span style="float: left;
                        padding-right: 5px" class="blktext14px_default">Loading...</span> <span style="float: left">
                            <img src="/App/Images/loading.gif" /></span> </span>
                    <%--End Loading Span--%>
                    <span style="float: right; font-size: 11px;"><span style="float: right">
                        <img src="/App/Images/warm-icon.gif" alt="Warm" /></span> <span style="float: right;
                            padding: 2px 5px 0px 0px;">Warm</span> <span style="float: right; padding-right: 10px;">
                                <img src="/App/Images/cold-icon.gif" alt="Cold" /></span> <span style="float: right;
                                    padding: 2px 5px 0px 0px;">Cold</span> <span style="float: right; padding-right: 10px;">
                                        <img src="/App/Images/hot-icon.gif" alt="Hot" /></span> <span style="float: right;
                                            padding: 2px 5px 0px 0px;">Hot</span> </span>
                </div>
                <%--Begin Main Div For Prospects--%>
                <div style="float: left; width: 746px" id="divProspect" runat="server">
                </div>
                <%--End Main Div For Prospects--%>
                <div style="float: left; width: 746px; border: solid 1px #E7F0F5; padding: 10px 0px 10px 0px;
                    display: none;" id="dvNoProspectFound" runat="server">
                    <div class="divnoitemfound_custdbrd" style="margin-top: 0px;">
                        <p class="divnoitemtxt_custdbrd">
                            <span class="orngbold18_default">No Records Found</span>
                        </p>
                    </div>
                </div>
                <p>
                    <img src="/App/Images/specer.gif" width="725px" height="10px" alt="" /></p>
            </div>
        </div>
    </div>
</div>
<asp:LinkButton runat="server" ID="lnktemp"></asp:LinkButton>
<asp:Panel ID="pnlTask" runat="server" Style="display: none;">
    <div class="wrapper_pop">
        <div class="wrapperin_pop">
            <div class="innermain_pop">
                <p class="innermain_pop">
                    <span class="orngbold16_default" id="Span4" style="float: left">Add New Task</span>
                    <span style="float: right">
                        <asp:ImageButton OnClientClick="return HideTaskPopup();" ID="ibtnClose" runat="server"
                            ImageUrl="~/App/Images/close-button-symbol.gif" />
                    </span>
                </p>
                <p class="innermain_1_pop" style="border-top: solid 1px #ccc;">
                    <span class="titletext1b_default">
                        <img src="../Images/specer.gif" width="1px" height="1px" /></span>
                </p>
                <div class="innermain_pop">
                    <p class="innermain_pop">
                        <span class="inputfield110px_anp">Subject:
                            <asp:TextBox ID="txtTask" runat="server" CssClass="inputf_def" Width="300px"></asp:TextBox>
                        </span>
                    </p>
                    <p class="innermain_pop">
                        <span class="inputfield110px_anp">Due Date:
                            <asp:TextBox ID="txtDueDate" runat="server" CssClass="inputf_def date-picker" Width="100px"></asp:TextBox>
                            <span style="font-size: 9px; color: #666;">(mm/dd/yyyy)</span> </span>
                    </p>
                    <p class="innermain_pop">
                        <span class="inputfield110px_anp">Time:
                            <asp:TextBox ID="txtDueTime" runat="server" CssClass="inputf_def" Width="110px" onblur="javascript:AddSlotAutoFill(this);"
                                onkeydown="javascript:return FilterTime(event.keyCode, this, '##:## AM');"></asp:TextBox>
                            <span style="font-size: 9px; color: #666;">(hh:mm)</span> </span>
                    </p>
                    <p class="innermain_pop">
                        <span class="buttoncon_default">
                            <asp:ImageButton runat="server" CausesValidation="true" ID="ibtnSaveTask" ImageUrl="~/App/Images/save-button.gif"
                                OnClientClick="return SaveTask();" />
                        </span><span class="buttoncon_default">
                            <asp:ImageButton runat="server" ID="ibnCancelTask" ImageUrl="~/App/Images/cancel-button.gif"
                                OnClientClick="return HideTaskPopup();" />
                        </span>
                    </p>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript" language="javascript">

        $(document).ready(function () {            
            $(".date-picker").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "-10:+50"//,
                //beforeShow: function () { $('#<%=pnlTask.ClientID %>').maxZIndex(10); }

            });
        });

//        $.maxZIndex = $.fn.maxZIndex = function (opt) {            

//            /// <summary>
//            /// Returns the max zOrder in the document (no parameter)
//            /// Sets max zOrder by passing a non-zero number
//            /// which gets added to the highest zOrder.
//            /// </summary>    
//            /// <param name="opt" type="object">
//            /// inc: increment value, 
//            /// group: selector for zIndex elements to find max for
//            /// </param>
//            /// <returns type="jQuery" />
//            var def = { inc: 10, group: "*" };
//            $.extend(def, opt);
//            var zmax = 0;
//            $(def.group).each(function () {
//                var cur = parseInt($(this).css('z-index'));
//                zmax = cur > zmax ? cur : zmax;
//            });
//            if (!this.jquery)
//                return zmax;

//            return this.each(function () {
//                zmax += def.inc;
//                $(this).css("z-index", zmax);
//            });
//        }
    </script>
</asp:Panel>
<asp:HiddenField ID="hidProspectid" runat="server" />
<asp:HiddenField ID="hidUserId" runat="server" />
<asp:HiddenField ID="hidRole" runat="server" />
<asp:HiddenField ID="hidAssignedStatus" runat="server" />
<asp:HiddenField ID="hidPageNumber" runat="server" />
<asp:HiddenField ID="hidPageSize" runat="server" />
<asp:HiddenField ID="hidProspectListID" runat="server" />
<cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="lnktemp"
        PopupControlID="pnlTask" BackgroundCssClass="modalBackground" CancelControlID="lnktemp"
        BehaviorID="mdlPopup1" />