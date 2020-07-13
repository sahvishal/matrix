<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" CodeBehind="EventDetails.aspx.cs" Inherits="Falcon.App.UI.App.Common.EventDetails" %>

<%@ Register Src="../UCCommon/UCViewEventActivity.ascx" TagName="UCViewEventActivity" TagPrefix="uc6" %>
<%@ Register Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" TagPrefix="JQueryControl" %>
<%@ Register Src="~/App/UCCommon/ViewOrderDetails.ascx" TagName="ViewOrderDetails" TagPrefix="orderDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="/Content/Styles/jquery.qtip.min.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery.qtip.min.js" type="text/javascript"></script>
    <JQueryControl:JQueryToolkit ID="_JQueryToolkit" runat="server" IncludeAjax="true" IncudeJQueryAutoComplete="true" IncludeJQueryUI="true" IncudeJQueryJTip="true" IncludeJTemplate="true" IncludeJQueryCorner="true" IncludeJQueryThickBox="true" />
    <orderDetails:ViewOrderDetails ID="ViewOrderDetailsControl" runat="server" />
    <script type="text/javascript" src="/App/JavascriptFiles/HttpRequest.js" language="javascript"></script>
    <style type="text/css">
        /* Payment details Jtip */.wrappd
        {
            float: left;
            width: 420px;
            padding: 10px;
        }
        .wrappd .subhead
        {
            float: left;
            width: 380px;
            background: #e5e5e5;
            padding: 3px 10px;
            margin: 5px 0;
            font-weight: bold;
        }
        .wrappd .inrcontnr
        {
            float: left;
            padding-left: 30px;
            width: 350px;
        }
        .wrappd .inrcontnr .inrrow
        {
            float: left;
            width: 350px;
        }
        a.apd
        {
            position: relative;
            z-index: 24;
            color: #3CA3FF;
            font-weight: bold;
            text-decoration: none;
        }
        a.apd span
        {
            display: none;
        }
        a.apd:hover
        {
            z-index: 25;
            color: #aaaaff;
        }
        a.apd:hover span.tooltip
        {
            display: block;
            position: absolute;
            top: 0px;
            left: 0;
            padding: 15px 0 0 0;
            width: 260px;
            color: #000;
            text-align: left;
            filter: alpha(opacity:90);
            khtmlopacity: 0.90;
            mozopacity: 0.90;
            opacity: 0.90;
        }
        a.tt
        {
            position: relative;
            z-index: 24;
            color: #3CA3FF;
            font-weight: bold;
            text-decoration: none;
        }
        a.tt span
        {
            display: none;
        }
        /*background:; ie hack, something must be changed in a for ie to execute it*/a.tt:hover
        {
            z-index: 25;
            color: #aaaaff;
        }
        a.tt:hover span.tooltip
        {
            display: block;
            position: absolute;
            top: 0px;
            left: 0;
            padding: 5px 0 0 0;
            width: 200px;
            color: #993300;
            text-align: left;
            filter: alpha(opacity:90);
            khtmlopacity: 0.90;
            mozopacity: 0.90;
            opacity: 0.90;
        }
        a.tt:hover span.top
        {
            display: block;
            padding: 30px 8px 0;
            background: url(/App/Images/bubble.gif) no-repeat top;
        }
        a.tt:hover span.middle
        {
            /* different middle bg for stretch */
            display: block;
            padding: 0 8px;
            background: url(/App/Images/bubble_filler.gif) repeat bottom;
        }
        a.tt:hover span.bottom
        {
            display: block;
            padding: 3px 8px 10px;
            color: #548912;
            background: url(/App/Images/bubble.gif) no-repeat bottom;
        }
    </style>
    <style type="text/css">
        #div
        {
            position: fixed;
            top: 20px;
            left: 10px;
        }
    </style>
    <style type="text/css">
        .wrapper_popt
        {
            float: left;
            width: 502px;
            padding: 10px;
            background-color: #f5f5f5;
        }
        .wrapperin_popt
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
        .orngbold16_default
        {
            font: bold 16px arial;
            color: #F37C00;
            float: left;
        }
        .orngbold14_default
        {
            font: bold 14px arial;
            color: #F37C00;
        }
        .btextblu12
        {
            font: bold 12px arial;
            color: #287AA8;
        }
        .titletextnowidth_default
        {
            float: left;
            margin-right: 5px;
            padding-top: 3px;
            font-weight: bold;
            color: #000;
        }
        .ttxtnowidthnormal_default
        {
            float: left;
            margin-right: 5px;
            padding-top: 3px;
            font-weight: normal;
            color: #000;
        }
    </style>
    
    <script language="javascript" type="text/javascript">
        var pagenumber = 1;
        var pagesize = 10;
        var sortcolumn = '';
        var sortorder = '1';
        var filterstring = '';
        var eventid = '';
        var postRequest = new HttpRequest();
        postRequest.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        postRequest.failureCallback = requestFailed();
        function requestFailed() { }



        function SetImage(currentimage) {
            SetImageOnly(currentimage);
            // reset all flags
            pagenumber = 1;
            pagesize = 10;
            sortcolumn = '';
            sortorder = '1';
            filterstring = '';
            //alert(currentimage);
            // customers
            if (currentimage == 'Customers') {
                GetTable(currentimage);
            }
            // activity
            else if (currentimage == 'Activities') {
                eventid = document.getElementById("<%= hidEventID.ClientID %>").value;
                ViewEventActivity(eventid, pagenumber, pagesize, sortcolumn, sortorder);
            }
           
            else {
                alert('Pending Functionality.');
                return false;
            }
        }
        function SetImageOnly(currentimage) {
            document.getElementById('imgActivities').src = '/App/Images/activities-tab-off.gif';
            document.getElementById('imgCustomers').src = '/App/Images/MarketingPartner/Cusotmers-taboff.gif';
            document.getElementById('imgPerformance').src = '/App/Images/performance-tab-off.gif';

            if (currentimage == 'Activities') document.getElementById('imgActivities').src = '/App/Images/activities-tab-on.gif';
            else if (currentimage == 'Customers') document.getElementById('imgCustomers').src = '/App/Images/MarketingPartner/Cusotmers-tabon.gif';
            else if (currentimage == 'Performance') document.getElementById('imgPerformance').src = '/App/Images/performance-tab-on.gif';
        }
        function HideAllDiv() {
            document.getElementById('divMain').style.display = 'none';
            document.getElementById('divActivity').style.display = 'none';
            document.getElementById('divNoRecord').style.display = 'none';
        }
        // Begin Customers
        // ------------------------------------------------------------------------------------------------------------------------------------------------------

        // on page change
        function GetTablePageChange(type, selpagenumber) {
            pagenumber = selpagenumber;
            eventid = document.getElementById("<%= this.hidEventID.ClientID %>").value;
            // Activity
            if (type == 'Activities') {
                ViewEventActivity(eventid, pagenumber, pagesize, sortcolumn, sortorder);
            }
            else
                GetTable(type);
        }
        // on sort
        function GetSortedWelness(newsortcolumn) {
            sortcolumn = newsortcolumn;
            if (sortorder == 1) sortorder = 0;
            else sortorder = 1;
            eventid = document.getElementById("<%= hidEventID.ClientID %>").value;
            ViewWellness(eventid, pagenumber, pagesize, sortcolumn, sortorder);
            return false;
        }
        // on link change
        function GetCustomersTableLinkClick(filterstringnew) {
            filterstring = filterstringnew;
            SetImageOnly('Customers');
            if (filterstringnew == 'Cancelled') {
                getCancelledCustomers();
            }
            else if (filterstringnew == 'Rescheduled') {
                getRescheduledCustomers();
            }
            else {
                GetTable('Customers');
            }
            return false;
        }

        function getCancelledCustomers() {
            eventid = document.getElementById("<%= hidEventID.ClientID %>").value;
            HideAllDiv();
            document.getElementById('divLoading').style.display = 'block';
            postRequest.url = "/App/Franchisee/Technician/Async_CancelledCustomers.aspx?EventID=" + eventid;
            postRequest.successCallback = SetGrid;
            postRequest.post("");

        }   
        
        function getRescheduledCustomers() {
            eventid = document.getElementById("<%= hidEventID.ClientID %>").value;
            HideAllDiv();
            document.getElementById('divLoading').style.display = 'block';
            postRequest.url = "/App/Franchisee/Technician/AsyncRescheduledCustomers.aspx?EventID=" + eventid;
            postRequest.successCallback = SetGrid;
            postRequest.post("");

        }   

        // on sort
        function GetCustomersTableOnSortOrder() {
            if (sortorder == 1) sortorder = 0;
            else sortorder = 1;
            SetImageOnly('Customers');
            GetTable('Customers');
            return false;
        }
        // load customers
        function GetTable(viewTab) {//debugger;

            HideAllDiv();
            document.getElementById('divLoading').style.display = 'block';
            var url = "/App/Common/AsyncEventDetails.aspx?type=" + viewTab;
            // request parameters

            eventid = document.getElementById("<%= this.hidEventID.ClientID %>").value;
            url = url + '&role=' + document.getElementById("<%= this.hidRole.ClientID %>").value;
            url = url + '&eventid=' + eventid;
            url = url + "&pageindex=" + pagenumber;
            url = url + "&pagesize=" + pagesize;
            //alert(viewTab);
            // customers
            if (viewTab == 'Customers') {
                url = url + "&sortorder=" + sortorder;
                if (filterstring == '') {
                    url = url + "&filterstring=" + $('#<%=ddlfiltergrid.ClientID %>').val();
                }
                else
                    url = url + "&filterstring=" + filterstring;
                //alert(url);
                postRequest.url = url;
                postRequest.successCallback = SetGrid;
                postRequest.failureCallback = requestFailed();
                postRequest.post("");
            }

        }
        function SetGrid(httpRequest) {
            //debugger;
            httpRequest.responseText = httpRequest.responseText.replace('class="grayboxtop_custlist"', 'style="float:left;width:746px;"');
            var result = httpRequest.responseText;
            //RedirectToLogin(result);
            if (result.indexOf('No Record Found') > -1) {
                document.getElementById('divMain').innerHTML = '';
                document.getElementById('divMain').style.display = 'none';
                document.getElementById('divNoRecord').style.display = 'block';
            }
            else if (result.indexOf('Some Error occured') > -1) {
                document.getElementById('divMain').innerHTML = httpRequest.responseText;
                document.getElementById('divMain').style.display = 'block';
                document.getElementById('divNoRecord').style.display = 'none';
            }
            else {
                document.getElementById('divMain').innerHTML = httpRequest.responseText;
                document.getElementById('divMain').style.display = 'block';
                document.getElementById('divNoRecord').style.display = 'none';
            }

            document.getElementById('divLoading').style.display = 'none';
        }
        // End Customers
        // ------------------------------------------------------------------------------------------------------------------------------------------------------

        
        // ------------------------------------------------------------------------------------------------------------------------------------------------------
        // Begin Activity
        function ChangeActivityStatus(type, id) {
            ChangeStatus(type, id);
            eventid = document.getElementById("<%= this.hidEventID.ClientID %>").value;
            ViewEventActivity(eventid, pagenumber, pagesize, sortcolumn, sortorder);
            alert('Activity has been marked as Completed.');
        }
        function ReloadPrintOrder() {
            SetImage('PrintOrder');
        }
    </script>
    <script type="text/javascript">
        function ClosePopUp() {
            parent.top.tb_remove();
            window.location = window.location;
        }

        function OpenPopUp(pageUrl) {
            tb_show('Block Slot', pageUrl, false); //+ '&keepThis=true&TB_iframe=true&width=690&modal=true'
        }
    </script>    
    
    <div class="wrapper_inpg">
        <div id="_divEventDetails" runat="server">
            <h1 class="left">
                Event Details</h1>
            <div class="headingright_default">
                <a href="/App/Common/CreateEventWizard/Step1.aspx?EventID=<%=Eventid%>">Edit Event</a></div>
            <div class="hr left">
            </div>
            <div class="prow">
                <span class="orngbold12_default">Event on <span runat="server" id="speventdate"></span>at <span runat="server" id="sphostname"></span><span class="graybold14_default" id="_eventType" runat="server"></span></span>
                
                <div><a href="#" class="eventNotes" runat="server">Event Instructions</a>&nbsp;|&nbsp;<a id="assignedPhysicians" href="javascript:void(0);">Assigned Physicians</a>
                    <div class="event-notes dgselecttime_pw" style="display: none;">
                        <span style="width: 200px; margin-bottom: auto; margin-top: auto;">
                            <img src="/App/Images/loading.gif" alt="Loading" />
                            Loading... </span>
                    </div>
                </div>
                <div id="assignedPhysicianDiv" style="display:none;">                    
                </div>
                
                <script language="javascript" type="text/javascript">
                    $(document).ready(function () {
                        var EventId = <%=Eventid%>;
                        loadNotes(EventId);
                        loadAssinedPhysicians(EventId);
                    });
                </script>
            </div>
            <div class="prow">
                <span><span runat="server" id="speventloc"></span>&nbsp;[ <a runat="server" id="agmap" href="#" target="_blank">Map to Location</a> ] &nbsp;<span id="_addressVerifiedStatus" runat="server"><font size="1px"></font></span>
                    <br />
                </span>
            </div>
            <div class="prow">
                <b>[Host Contact:<span runat="server" id="sphostphone"></span>]</b>&nbsp;|&nbsp;<b>Pods:</b> <span id="sppoddetail" runat="server"></span>
            </div>
            <div class="prow">
                <span style="float: left;"><b>Status:</b>&nbsp;<span runat="server" id="eventStatusSpan"></span></span> <span runat="server" id="eventNotesSpan" style="float: left; padding-left: 5px;"><a href="javascript:void(0);" id="aNotes">(Reason)</a> <span id="notesSpan" runat="server" style="display: none;"></span></span>
            </div>
            <div class="prow">
                <span style="float: left; display: none;"><a href="javascript:DisplayMABoard();"><b>[Medical Advisory Board]</b></a></span> <span class="linkright_default"><a href="#" id="aBack" runat="server"><b>Back</b></a></span>
            </div>
            <div id="divgrayboxhead" class="greycornrbox">
                <div class="left">
                    Event Summary (ID:<span runat="server" id="speventid"></span>)</div>
                <div class="rgt">
                    <a href="#" class="jtip" id="hrfBookingDetails" runat="server" style="font-weight: normal">Event Booking Details</a></div>
            </div>
            <div id="divgrayboxbdy" class="greycornrbdy">
                <div style="width: 100%">
                    <p class="hzrow">
                        <span class="titletext1b_default">Customers:</span> <span class="ttxtnowidthnormal_default">Registered:
                            <asp:LinkButton runat="server" ID="ancregistered" OnClientClick="return GetCustomersTableLinkClick('Registered');"></asp:LinkButton>
                            &nbsp;|&nbsp; Actual:<asp:LinkButton runat="server" ID="ancactual" OnClientClick="return GetCustomersTableLinkClick('Actual');"></asp:LinkButton>
                            &nbsp;|&nbsp; Paid:<asp:LinkButton runat="server" ID="ancpaid" OnClientClick="return GetCustomersTableLinkClick('Paid');"></asp:LinkButton>
                            &nbsp;|&nbsp; Unpaid:<asp:LinkButton runat="server" ID="ancunpaid" OnClientClick="return GetCustomersTableLinkClick('UnPaid');"></asp:LinkButton>
                            &nbsp;|&nbsp; No Show:<asp:LinkButton runat="server" ID="ancnoshow" OnClientClick="return GetCustomersTableLinkClick('NoShow');"></asp:LinkButton>
                            &nbsp;|&nbsp; Canceled:<asp:LinkButton runat="server" ID="ancuncancel" Text="0" OnClientClick="return GetCustomersTableLinkClick('Cancelled');"></asp:LinkButton>
                            &nbsp;|&nbsp; Rescheduled:<asp:LinkButton runat="server" ID="ancrescheduled" Text="0" OnClientClick="return GetCustomersTableLinkClick('Rescheduled');"></asp:LinkButton>
                            <br />&nbsp;|&nbsp;Left Without Screening:<asp:LinkButton runat="server" ID="leftWithoutScreening" Text="0" OnClientClick="return GetCustomersTableLinkClick('LeftWithoutScreening');"></asp:LinkButton></span>
                    </p>
                    <p class="hzrow">
                        <span class="titletext1b_default">Tests:</span> <span class="ttxtnowidthnormal_default" runat="server" id="_testNameCountString" style="width: 580px"></span>
                    </p>
                    <p class="hzrow">
                        <span class="titletext1b_default">Revenue:</span> <span class="ttxtnowidthnormal_default" style="width: 580px"><span class="left">Total:<b>$<span runat="server" id="sptotalpayment"></span></b> &nbsp;|&nbsp;CC:<b>$<span runat="server" id="spcardpayment"></span></b> (<asp:LinkButton runat="server" ID="anccardpaymentcount" OnClientClick="return GetCustomersTableLinkClick('CreditCard');"></asp:LinkButton>) &nbsp;|&nbsp;Checks:<b>$<span runat="server" id="spchequepayment"></span></b> (<asp:LinkButton runat="server" ID="ancchequepaymentcount" OnClientClick="return GetCustomersTableLinkClick('Check');"></asp:LinkButton>) &nbsp;|&nbsp;Cash:<b>$<span runat="server" id="spcashpayment"></span></b> (<asp:LinkButton runat="server" ID="anccashpaymentcount" OnClientClick="return GetCustomersTableLinkClick('Cash');"></asp:LinkButton>) &nbsp;|&nbsp;eCheck:<b>$<span runat="server" id="spBPeCheckPayment"></span></b> (<asp:LinkButton runat="server" ID="lnkBPeCheckPayment" OnClientClick="return GetCustomersTableLinkClick('ECheck');"></asp:LinkButton>)</span> <span id="_spnUnPaidExcludeNoShow" runat="server" class="left">&nbsp;|&nbsp;Unpaid:<b>$<span runat="server" id="_spnUnpaidTotal"></span></b> (<asp:LinkButton runat="server" ID="_lnkUnpaidCount" OnClientClick="return GetCustomersTableLinkClick('UnPaidNoShowExcluded');"></asp:LinkButton>) </span>&nbsp;|&nbsp;GC:<b>$<span runat="server" id="_spnGcPaymentTotal"></span></b> (<asp:LinkButton runat="server" ID="_lnkGcPaymentCount" OnClientClick="alert('Pending functionality.'); return false;"></asp:LinkButton>) </span>
                    </p>
                    <p class="hzrow">
                        <span class="titletext1b_default">Metrics:</span> <span class="ttxtnowidthnormal_default" style="width: 580px">Phone:<b>$<span runat="server" id="spPhoneTotalAmount">&nbsp;</span></b> (<asp:LinkButton runat="server" ID="lnkPhoneTotal" OnClientClick="alert('Pending Functionality'); return false;"></asp:LinkButton>) &nbsp;|&nbsp;INet:<b>$<span runat="server" id="spnINetAmount">&nbsp;</span></b> (<asp:LinkButton runat="server" ID="lnkINetTotal" OnClientClick="alert('Pending Functionality');return false;"></asp:LinkButton>) &nbsp;|&nbsp;Onsite:<b>$<span runat="server" id="spnOnsiteAmount">&nbsp;</span></b> (<asp:LinkButton runat="server" ID="lnkOnSiteTotal" OnClientClick="alert('Pending Functionality');return false;"></asp:LinkButton>) &nbsp;|&nbsp;Upgrades:<b>$<span runat="server" id="spnUpgradeAmount">&nbsp;</span></b> (<asp:LinkButton runat="server" ID="lnkUpgradeTotal" OnClientClick="alert('Pending Functionality');return false;"></asp:LinkButton>) &nbsp;|&nbsp;Downgrades:<b>$<span runat="server" id="spnDowngradesAmount">&nbsp;</span></b> (<asp:LinkButton runat="server" ID="lnkDowngradeTotal" OnClientClick="alert('Pending Functionality');return false;"></asp:LinkButton>) <span id="_spnAverage" runat="server">&nbsp;|&nbsp;Average Revenue / Client:<b>$<span runat="server" id="_spnAverageRevenueCount"></span></b> (<asp:LinkButton runat="server" ID="_lnkAverageCustomers" class="jtip" title='Average Revenue |Average Revenue / Client Excludes the NoShow and Free (100% discounted) Customers.' OnClientClick="alert('Pending functionality.'); return false;"></asp:LinkButton>) </span></span>
                    </p>
                    <p class="hzrow">
                        <span class="titletext1b_default" style="width: 125px">Host Payment Details:</span> <span style="margin-top: 5px"><a href="#" class="jtipHostPaymentDetails" runat="server" id="_hostPaymentDetails">Details</a> </span>
                    </p>
                </div>
            </div>
            <div style="float: left; width: 740px; height: 27px; margin-top: 10px">
                <img style="cursor: pointer;" src="/App/Images/activities-tab-on.gif" alt="" id="imgActivities" onclick="javascript:SetImage('Activities');" />
                <img style="cursor: pointer;" src="/App/Images/MarketingPartner/Cusotmers-taboff.gif" alt="" id="imgCustomers" onclick="javascript:SetImage('Customers');" />
                <img style="cursor: pointer; display: none;" src="/App/Images/MarketingPartner/Advocates-taboff.gif" alt="" id="imgAdvocate" onclick="javascript:SetImage('Advocate');" />
                <img style="cursor: pointer; display: none;" src="/App/Images/MarketingPartner/campaigns-taboff.gif" alt="" id="imgCampaign" onclick="javascript:SetImage('Campaign');" />
                <img style="cursor: pointer; display: none;" src="/App/Images/wellness-tab-off.gif" alt="" id="imgWellness" onclick="javascript:SetImage('Wellness');" />
                <img style="cursor: pointer; display: none;" src="/App/Images/printorders-tab-off.gif" alt="" id="imgPrintOrder" onclick="javascript:SetImage('PrintOrder');" />
                <img style="cursor: pointer; display: none;" src="/App/Images/promo-tab-off.gif" alt="" id="imgPromo" onclick="javascript:SetImage('Promo');" />
                <img style="cursor: pointer; display: none" src="/App/Images/performance-tab-off.gif" alt="" id="imgPerformance" onclick="javascript:SetImage('Performance');" />
                <div style="float: right;">
                    <span class="smalltxtlnk_hd" style="float: left; padding: 4px 6px 0 0"><a href="javascript:void(0);" runat="server" id="ancopenpopupaddslot" class="thickbox">Add slot </a>&nbsp;|</span>
                    <asp:DropDownList ID="ddlfiltergrid" runat="server" CssClass="inputf_def" Width="110px" AutoPostBack="False">
                        <asp:ListItem Value="All">All</asp:ListItem>
                        <asp:ListItem Value="Open">Open</asp:ListItem>
                        <asp:ListItem Value="Filled" Selected="True">Filled</asp:ListItem>
                        <asp:ListItem Value="Blocked">Blocked</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <%--Begin Customers--%>
            <div style="float: left; width: 746px" id="divMain">
            </div>
            <%--Begin Customers--%>
            <%--Begin Activity --%>
            <div style="float: left; width: 746px; display: block" id="divActivity">
                <uc6:UCViewEventActivity ID="UCViewEventActivity1" runat="server" />
            </div>
            <%--End Activity --%>
            <div id="divLoading" style="float: left; display: block">
                <div style="float: left; width: 744px; border: solid 1px #DFEEF5; height: 120px; padding-top: 70px; text-align: center; display: block" id="imgAdvocateLoading">
                    <img src="/App/Images/indicatorbig.gif" alt="Loading" title="Loading Records" />
                </div>
            </div>
            <div style="float: left; display: none;" id="divNoRecord">
                <div id="" style="float: left; width: 714px; display: block; padding: 10px 10px 10px 20px; border: solid 1px #DFEEF5;">
                    <div class="divnoitemfound1_custdbrd">
                        <p class="divnoitemtxt_custdbrd">
                            <span class="orngbold18_default">No Record Found </span>
                        </p>
                    </div>
                </div>
            </div>
        </div>
        <div style="float: left; display: none;" id="_divNoEventsFound" runat="server">
            <h1 class="left">
                Event Details</h1>
            <div id="Div2" style="float: left; width: 714px; display: block; padding: 10px 10px 10px 20px; border: solid 1px #DFEEF5;">
                <div class="divnoitemfound1_custdbrd">
                    <p class="divnoitemtxt_custdbrd">
                        <span class="orngbold18_default">No Record Found.</span>
                    </p>
                </div>
            </div>
        </div>
    </div>
    <asp:LinkButton runat="server" ID="lnktemp"></asp:LinkButton>
    <input type="hidden" id="hidEventID" runat="server" />
    <input type="hidden" id="hidEventName" runat="server" />
    <input type="hidden" id="hidEventDate" runat="server" />
    <input type="hidden" runat="server" id="hidUserId" />
    <input type="hidden" runat="server" id="hidRole" />
    
    
    
    
    
    <script type="text/javascript">
        $(document).ready(function () {
            $.ajaxSetup({ cache: false });
            $('.jtip').cluetip({ splitTitle: '|', cursor: 'pointer', tracking: true, cluetipClass: 'jtip', arrows: true, dropShadow: false, hoverIntent: false });
            $('.jtipHostPaymentDetails').cluetip({ splitTitle: '|', cursor: 'pointer', tracking: true, cluetipClass: 'jtip', arrows: true, dropShadow: false, hoverIntent: false, width: 450 });
            $('.jtipLocal').cluetip({ splitTitle: '|', cursor: 'pointer', tracking: true, cluetipClass: 'jtip', arrows: true, dropShadow: false, hoverIntent: false, width: 330 });
            
            $('#divgrayboxhead').corner("top");
            $('#divgrayboxbdy').corner("bottom");
            $('.jtippreview').cluetip({ splitTitle: '|', cursor: 'pointer', tracking: true, width: 620, cluetipClass: 'jtip', arrows: true, dropShadow: false, hoverIntent: false, zindex: 5000000 });

            $(".eventNotes").qtip({
                content: {
                    title: "Notes",
                    text: function (api) {
                        return $(this).parent().find("div:first").html();
                    }
                }
            });


            $('#aNotes').qtip({
                content: {
                    title: '<%= CancellationReasonToolTipHeader %>',
                    text: function (api) {
                        return $('#<%= notesSpan.ClientID %>').html();
                    }
                },
                style: {
                    width: '400px'
                }
            });

            $('#<%=ddlfiltergrid.ClientID %>').bind('change', function () { GetTable('Customers'); });


            $("#assignedPhysicians").qtip({
                content: {
                    title: "Assigned Physician(s)",
                    text: function (api) {
                        return $('#assignedPhysicianDiv').html();
                    }
                }
            });

        });

        function loadNotes(eventId) {
            $.ajax({ type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "html", url: "/Scheduling/Event/EventNotes?eventId=" + eventId, data: '{}',
                success: function (result) { setEventNotes(result); }, error: function (a, b, c) {}
            });
        }

        function setEventNotes(eventNotes) {
            $(".eventNotes").parent().find("div:first").html(eventNotes);
        }

        function loadAssinedPhysicians(eventId) {
            //debugger;
            $.ajax({ type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "html", url: "/Operations/PhysicianAssignment/GetAssignedPhysiciansForEvent?id=" + eventId, data: '{}',
                success: function (result) { setPhysicianAssignmentData(result); }, error: function (a, b, c) { }
            });
        }

        function setPhysicianAssignmentData(assignments) {
            //debugger;
            $("#assignedPhysicianDiv").html(assignments);            
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

                    $('#divLoading').hide();
                    alert('Ooops Some error occured');

                }
            });
        }

        function DeleteAppointment(appointmentid) {
            var bolconfirm = confirm('Are you sure you want to delete the slot?');
            if (bolconfirm)
                __doPostBack('DeleteAppointment', appointmentid);
        }
    </script>
    <script type="text/javascript">
        function ShowOrderDetailPopUp(orderId, orderTotal, paymentTotal, amountOwed, customerName, customerId) {
            ShowOrderDetailsDialog(orderId, orderTotal, paymentTotal, amountOwed, customerName, customerId);
            return false;
        }
    </script>
</asp:Content>
