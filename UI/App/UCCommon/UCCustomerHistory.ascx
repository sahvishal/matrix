<%@ Control Language="C#" AutoEventWireup="true" Inherits="App_UCCommon_UCCustomerHistory"
    CodeBehind="UCCustomerHistory.ascx.cs" %>
<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.Core.Finance.Interfaces" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" TagPrefix="UC" %>
<%@ Register Src="~/App/UCCommon/ViewOrderDetails.ascx" TagName="ViewOrderDetails"
    TagPrefix="orderDetails" %>
<%@ Register Src="~/App/UCCommon/ViewShippingDetails.ascx" TagName="ViewShippingDetails"
    TagPrefix="shippingDetails" %>
<UC:JQueryToolkit  runat="server" IncludeJQueryMaskInput="true"/>
<script type="text/javascript">
    function changetodefault(spanId) {
        //alert('hello');
        document.getElementById(spanId).style.cursor = "default";
    }
    function changetopointer(spanId) {
        //alert('hello fellow');
        document.getElementById(spanId).style.cursor = "pointer";
    }

    function ShowOrderDetailPopUp(orderId, orderTotal, paymentTotal, amountOwed, customerName, customerId) {
        ShowOrderDetailsDialog(orderId, orderTotal, paymentTotal, amountOwed, customerName, customerId);
        return false;
    }

</script>
<link href="/Content/Styles/jquery.qtip.min.css" rel="stylesheet" type="text/css" />
<script src="/Scripts/jquery.qtip.min.js" type="text/javascript"></script>
<%--for the medicare penguin --%>
<link href="/Content/colorbox/colorbox.css" rel="stylesheet" />

<script type="text/javascript" src="/App/JavascriptFiles/HraQuestionnaire.js?q=<%=VersionNumber %>"></script>
<script type="text/javascript" src="/Content/colorbox/jquery.colorbox.js"></script>
<style type="text/css">
    .wrapper_pop {
        background: #f57c00;
        float: left;
        width: 402px;
        padding: 10px;
    }

    .wrapperin_pop {
        background: #fff;
        float: left;
        width: 380px;
        padding: 10px;
    }

    .innermain_pop {
        float: left;
        width: 363px;
        padding: 0 5px 0 5px;
    }

        .innermain_pop .signrow {
            float: left;
            width: 370px;
        }

            .innermain_pop .signrow .date {
                float: right;
                width: 100px;
            }

            .innermain_pop .signrow .sign {
                float: left;
                width: 150px;
            }

    .innermain_1_pop {
        float: left;
        width: 363px;
        padding-top: 5px;
    }

    .inputfield180px_anp {
        float: left;
        width: 180px;
        font: bold 12px arial;
        color: #000;
    }

    .inputfield160px_anp {
        float: left;
        width: 160px;
        font: bold 12px arial;
        color: #000;
    }

    .subh {
        float: left;
        width: 495px;
        margin-top: 10px;
        padding-left: 5px;
    }

        .subh .nobg {
            width: 495px;
            float: left;
            font-size: 14px;
            font-weight: bold;
        }

        .subh .bg {
            width: 495px;
            float: left;
            font-size: 14px;
            background: #e5e5e5;
            font-weight: bold;
        }

        .subh .plrow {
            width: 455px;
            float: left;
            padding-left: 40px;
        }

    .pnlmva {
        float: left;
        width: 422px;
    }

    .pnlnote {
        float: left;
        padding: 0 10px 0 10px;
        width: 402px;
        font-size: 10px;
        font-style: italic;
        color: #666;
    }

    #div {
        position: fixed;
        top: 20px;
        left: 10px;
    }
    /*---------- bubble tooltipPD -----------*/ a.ttbig {
        position: relative;
        z-index: 24;
        color: #3ca3ff;
        font-weight: bold;
        text-decoration: none;
    }

    a.ttbig {
        position: relative;
        z-index: 24;
        color: #3ca3ff;
        font-weight: bold;
        text-decoration: none;
    }

        a.ttbig span {
            display: none;
        }

        a.ttbig:hover {
            z-index: 25;
            color: #aaf;
        }
            /*background:; ie hack, something must be changed in a for ie to execute it*/ a.ttbig:hover span.tooltipPD {
                display: block;
                position: absolute;
                top: 0;
                left: -280px;
                padding: 15px 0 0 0;
                width: 320px;
                color: #930;
                text-align: left;
                filter: alpha(opacity:90);
                khtmlopacity: 0.90;
                mozopacity: 0.90;
                opacity: 0.90;
            }

            a.ttbig:hover span.top {
                display: block;
                padding: 30px 8px 0;
                background: url(/App/Images/bubblebigleft.gif) no-repeat top;
            }

            a.ttbig:hover span.middle {
                display: block;
                padding: 0 8px;
                background: url(/App/Images/bubblefillerbig.gif) repeat bottom;
            }

            a.ttbig:hover span.bottom {
                display: block;
                padding: 3px 8px 10px;
                color: #548912;
                background: url(/App/Images/bubblebigleft.gif) no-repeat bottom;
            }
</style>
<style type="text/css">
    .spactionlink_cdpage {
        float: right;
        padding-right: 10px;
    }

    .spaction_cdpage {
        width: 148px;
        position: absolute;
        z-index: 100;
        border: solid 1px #2A6E95;
        background-color: White;
    }

    .spactioninner_cdpage {
        width: 148px;
    }

    .spactionelement_cdpage {
        width: 138px;
        padding-left: 10px;
        padding-top: 5px;
        padding-bottom: 5px;
        border-bottom: solid 1px Gray;
        float: left;
    }
</style>
<style type="text/css">
    /*---------- bubble tooltip -----------*/ a.tt {
        position: relative;
        z-index: 24;
        color: #3CA3FF;
        font-weight: bold;
        text-decoration: none;
    }

        a.tt span {
            display: none;
        }
        /*background:; ie hack, something must be changed in a for ie to execute it*/ a.tt:hover {
            z-index: 25;
            color: #aaaaff;
        }

            a.tt:hover span.tooltip {
                display: block;
                position: absolute;
                top: 0px;
                left: 0;
                padding: 15px 0 0 0;
                width: 320px;
                color: #993300;
                text-align: left;
                filter: alpha(opacity:90);
                khtmlopacity: 0.90;
                mozopacity: 0.90;
                opacity: 0.90;
            }

            a.tt:hover span.top {
                display: block;
                padding: 30px 8px 0;
                background: url(/App/Images/bubblebig.gif) no-repeat top;
            }

            a.tt:hover span.middle {
                /* different middle bg for stretch */
                display: block;
                padding: 0 8px;
                background: url(/App/Images/bubblefillerbig.gif) repeat bottom;
            }

            a.tt:hover span.bottom {
                display: block;
                padding: 3px 8px 10px;
                color: #548912;
                background: url(/App/Images/bubblebig.gif) no-repeat bottom;
            }
</style>
<style type="text/css">
    .tab-on {
        width: 100px;
        padding: 5px;
        background-color: #E0F3FA;
        float: left;
        height: 22px;
        font-weight: bold;
        border: 1px solid #E0F3FA;
        border-radius: 4px;
        border-bottom: none;
    }

    .tab-off {
        width: 100px;
        padding: 5px;
        background-color: #fff;
        float: left;
        height: 22px;
        font-weight: bold;
        border: 1px solid #F7C48D;
        border-radius: 4px;
        border-bottom: none;
    }
</style>
<style type="text/css">
    .anchor {
        text-decoration: underline;
        color: #ff6600;
        cursor: pointer;
    }

    .jdialog-row {
        width: 100%;
        margin-top: 5px;
        font-size: 12px;
    }

    .saveWaitAnimation {
        min-height: 30px;
        background-image: url(../Images/indicator.gif);
        background-position: center right;
        background-repeat: no-repeat;
        background-color: Transparent;
    }

    #divloading {
        position: fixed;
        top: 250px;
        left: 150px;
    }
    .inelegible-customer {
        width: 120px !important;
         border: solid 1px black; 
         float: right; 
         padding-left: 10px;
          margin-bottom: 10px;
        margin-right: 35px;
    }
</style>
<style>
    .saveWaitAnimationnew
    {
        background-image: url('/Content/Images/loading_Big_orng.gif');
        background-repeat: no-repeat;
        position:fixed;
        top:0px;
        right:0px;
        width:100%;
        height:100%;
        background-color:#000;
        background-position:center;
        z-index:10000000;
        opacity: 0.4;
        filter: alpha(opacity=40);
    }
    
    #jSuggestContainer ul {
        width:250px;
        max-height: 300px; 
        overflow-y: scroll; 
        overflow-x: hidden;
    }
</style>
<script type="text/javascript" src="/App/JavascriptFiles/HttpRequest.js"></script>
<script language="javascript" type="text/javascript">

    function printPaymentDetails(aprint) {
        //var prtContent = document.getElementById("tipDivPD");
        var prtContent = document.getElementById("divcontentPD");
        document.getElementById('imgclosePD').style.display = 'none';
        document.getElementById(aprint).style.display = 'none';
        $('.info-row').hide();
        //if (document.getElementById('divCustomerDetail'))
        document.getElementById('divCustomerDetail').style.display = 'block';

        var WinPrint = window.open('', '', 'left=0,top=0,width=550,height=630,toolbar=0,scrollbars=0,status=0');
        WinPrint.document.write(prtContent.innerHTML);

        document.getElementById('imgclosePD').style.display = 'block';
        document.getElementById(aprint).style.display = 'block';
        //if (document.getElementById('divCustomerDetail'))
        document.getElementById('divCustomerDetail').style.display = 'none';

        WinPrint.document.close();
        WinPrint.focus();
        WinPrint.print();
        WinPrint.close();

        //return false;
    }

</script>
<script language="javascript" type="text/javascript">
    var postRequestAthInfo = new HttpRequest();
    postRequestAthInfo.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    postRequestAthInfo.failureCallback = requestFailedAth();

    function requestFailedAth()
    { }

    function showClinicalForm(key) {
        var url = '/DigitalDelivery.aspx?key=' + key;
        var winOpts = "toolbar=no,location=no,directories=no,status=no,scrolling=auto,scrollbars=no,menubar=no,resizable=yes,width=800,height=600,titlebar=0";
        confirmWin = window.open(url, 'ClinicalForm', winOpts);
    }

</script>

<script type="text/javascript" language="javascript">

    var GB_ROOT_DIR = "/App/Wizard/greybox/";


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

    // on mouse over
    function DisplayActionLinks(eventid, ancAction) {
        var arrinputelems;
        arrinputelems = ancAction.parentNode.parentNode.parentNode.getElementsByTagName("DIV");

        var loopcounter = 0;
        while (loopcounter < arrinputelems.length) {
            if (arrinputelems[loopcounter].id.indexOf('pEventLinks' + eventid) >= 0)
                break;
            loopcounter = loopcounter + 1;
        }

        if (loopcounter >= arrinputelems.length) return;

        var plinks = document.getElementById(arrinputelems[loopcounter].id);

        plinks.style.display = "block";

        var dim = GetTopLeft(ancAction);

        plinks.style.top = parseInt(dim.Top) + 'px'; //  parseInt(dim.Top + 15) + 'px';
        plinks.style.left = parseInt(dim.Left - 100) + 'px';

    }

    //on mouse out
    function HideActionLinks(eventid, ancAction, evt) {
        var arrinputelems;
        arrinputelems = ancAction.parentNode.parentNode.parentNode.getElementsByTagName("DIV");

        var loopcounter = 0;
        while (loopcounter < arrinputelems.length) {
            if (arrinputelems[loopcounter].id.indexOf('pEventLinks' + eventid) >= 0)
                break;
            loopcounter = loopcounter + 1;
        }

        if (loopcounter >= arrinputelems.length) return;

        var plinks = document.getElementById(arrinputelems[loopcounter].id);

        var dom = (document.getElementById) ? true : false;
        var ns5 = (!document.all && dom || window.opera) ? true : false;
        var standardbody = (document.compatMode == "CSS1Compat") ? document.documentElement : document.body
        var mouseX = (ns5) ? evt.pageX : window.event.clientX + standardbody.scrollLeft;
        var mouseY = (ns5) ? evt.pageY : window.event.clientY + standardbody.scrollTop;

        var topY, leftX, bottomY, rightX;
        topY = plinks.offsetTop;
        leftX = plinks.offsetLeft;
        bottomY = plinks.offsetTop + plinks.clientHeight;
        rightX = plinks.offsetLeft + plinks.clientWidth;

        if (topY < mouseY && leftX < mouseX && bottomY > mouseY && rightX > mouseX) {
            return;
        }

        plinks.style.display = "none";
    }

    function HideActionLinksITSELF(plinks, evt) {
        plinks.parentNode.style.display = "none";
    }

    function DisplayCustomerActionLinks(ancAction) {
        var divActionListID = document.getElementById("divCustomerLinks");
        divActionListID.style.display = "block";

        var dim = GetTopLeft(ancAction);

        divActionListID.style.top = parseInt(dim.Top) + 'px';
        divActionListID.style.left = (parseInt(dim.Left) - 90) + 'px';
    }

    function HideCustomerActionLinks(ancAction, evt) {
        var divActionListID = document.getElementById("divCustomerLinks");

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
</script>
<script type="text/javascript" language="javascript">

    function NextBuild() {
        alert('Please check this in next release');
        return false;
    }

    function popupmenu(choice, wt, ht) {
        //debugger;
        var winOpts = "toolbar=no,location=no,directories=no,status=no,scrolling=no,scrollbars=no,menubar=no,resizable=0,width=" + wt + ",height=" + ht;
        confirmWin = window.open(choice, 'theconfirmWin', winOpts);
    }

    function popupmenu2(choice, wt, ht) {
        if (openedWindow != undefined && !openedWindow.closed) {
            openedWindow.close()
        }
        var winOpts = "toolbar=no,location=no,directories=no,status=no,scrolling=auto,scrollbars=yes,menubar=no,width=" + wt + ",height=" + ht;
        confirmWin = window.open(choice, 'theconfirmWin', winOpts);
        openedWindow = confirmWin;
    }

    function ChageTab(tablLabel) {
        $("#tab-header-appointment, #tab-header-communication, #tab-header-notes, #tab-header-orders, #tab-header-results").removeClass("tab-on").addClass("tab-off");

        if (tablLabel == 'Appointment') {
            $("#tab-header-appointment").removeClass("tab-off").addClass("tab-on");
        }
        else if (tablLabel == 'Communication') {
            $("#tab-header-communication").removeClass("tab-off").addClass("tab-on");
        }
        else if (tablLabel == 'Notes') {
            $("#tab-header-notes").removeClass("tab-off").addClass("tab-on");
        }
        else if (tablLabel == 'Orders') {
            $("#tab-header-orders").removeClass("tab-off").addClass("tab-on");
        }
        else if (tablLabel == 'Results') {
            $("#tab-header-results").removeClass("tab-off").addClass("tab-on");
        }

        return false;
    }

    var IsForceChangePassword = false;
    var IsForceSecurityQuesChange = false;
    var IsResetLoginCount = false;
    var IsPDFRegenrated = false;

    function forceChangePassword() {
        var hfUserID = document.getElementById("<%=this.hfUserID.ClientID %>");
        var confirmation = confirm("Are you sure to force password change on next login?");
        if (confirmation == true) {
            IsForceChangePassword = true;
            IsForceSecurityQuesChange = false;
            IsResetLoginCount = false;
            IsPDFRegenrated = false;
            //ret = AutoCompleteService.ForceChangePassword(hfUserID.value, OnComplete, OnTimeOut, OnError);
            var messageUrl = '<%= ResolveUrl("~/App/AutoCompleteService.asmx/ForceChangePassword") %>';
            var parameter = "{'userid':" + hfUserID.value + "}";
            InvokeAutoCompleteService(messageUrl, parameter, OnComplete);
        }
        return false;
    }

    function ForceSecurityQuesChange() {
        var hfUserID = document.getElementById("<%=this.hfUserID.ClientID %>");
        var confirmation = confirm("Are you sure to force security question change on next login?");
        if (confirmation == true) {
            IsForceChangePassword = false;
            IsForceSecurityQuesChange = true;
            IsResetLoginCount = false;
            IsPDFRegenrated = false;
            //ret = AutoCompleteService.ForceSecurityQuesChange(hfUserID.value, OnComplete, OnTimeOut, OnError);
            var messageUrl = '<%= ResolveUrl("~/App/AutoCompleteService.asmx/ForceSecurityQuesChange") %>';
            var parameter = "{'userid':" + hfUserID.value + "}";
            InvokeAutoCompleteService(messageUrl, parameter, OnComplete);
        }
        return false;
    }

    function ResetLoginCount() {
        var hfUserID = document.getElementById("<%=this.hfUserID.ClientID %>");
        var confirmation = confirm("Are you sure to reset login count?");
        if (confirmation == true) {
            IsForceChangePassword = false;
            IsForceSecurityQuesChange = false;
            IsResetLoginCount = true;
            IsPDFRegenrated = false;
            //ret = AutoCompleteService.UnlockUser(hfUserID.value, OnComplete, OnTimeOut, OnError);

            var messageUrl = '<%= ResolveUrl("~/App/AutoCompleteService.asmx/UnlockUser") %>';
            var parameter = "{'userid':" + hfUserID.value + "}";
            InvokeAutoCompleteService(messageUrl, parameter, OnComplete);
        }
        return false;
    }
    function ReGeneratePDF(eventiId) {
        var confirmation = confirm("Are you sure you want to regenerate the Customer PDF?");
        if (confirmation == true) {
            IsForceChangePassword = false;
            IsForceSecurityQuesChange = false;
            IsResetLoginCount = false;
            IsPDFRegenrated = true;
            //ret = AutoCompleteService.ReGenrateCustomerReportPDF(CustomerEventTestID, OnComplete, OnTimeOut, OnError);
            var messageUrl = '<%= ResolveUrl("~/App/AutoCompleteService.asmx/ReGenrateCustomerReportPDF") %>';
            var parameter = "{'eventId':" + eventiId + ",'customerId':" + '<%=CustomerId %>' + " }";
            InvokeAutoCompleteService(messageUrl, parameter, OnComplete);
        }
        return false;
    }
    function OnComplete(arg) {//debugger
        if (arg == true) {
            if (IsForceChangePassword == true)
                alert("Customer will change the password on next login.");
            else if (IsForceSecurityQuesChange == true)
                alert("Customer will change the security question on next login.");
            else if (IsResetLoginCount == true)
                alert("Customer's login count has been reset.");
            else if (IsPDFRegenrated == true)
                alert("Generation of result PDF is in progress, please view the generated PDF after some time!");
        }

    }

    function OnTimeOut(arg) {
        //alert("Request timeout occurred. Please try again or restart the application to get the requested task done.");
    }

    function OnError(arg) {
        //alert("Error occurred while processing your request. Please try again or restart the application to get the requested task done.");
    }

    function InvokeAutoCompleteService(messageUrl, parameter, successFuntion) {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: messageUrl,
            data: parameter,
            success: function (result) {
                successFuntion(result.d);
            },
            error: function (a, b, c) {
                if (a.status == 401) {
                    alert('You do not have permission to perform the action!');
                }
            }
        });
    }
</script>
<script language="javascript" type="text/javascript" src="/App/JavascriptFiles/GeneralJSPopUp.js"></script>

<script type="text/javascript" src="/App/Wizard/greybox/AJS.js"></script>
<script type="text/javascript" src="/App/Wizard/greybox/AJS_fx.js"></script>
<script type="text/javascript" src="/App/Wizard/greybox/gb_scripts_reloadonclose.js"></script>
<link href="/App/Wizard/greybox/gb_styles.css" rel="stylesheet" type="text/css" />
<UC:JQueryToolkit ID="_jQueryToolkit" runat="server" IncudeJQueryJTip="true" IncludeJQueryThickBox="true" IncludeAjax="true" IncludeJQueryUI="true" IncudeJQueryAutoComplete="true" />
<orderDetails:ViewOrderDetails ID="ViewOrderDetailsControl" runat="server" />
<shippingDetails:ViewShippingDetails ID="ViewShippingDetailsControl" runat="server" />
<script language="javascript" type="text/javascript">
    $(document).ready(function () {
        $('.jTip').cluetip({ splitTitle: '|', cursor: 'pointer', tracking: true, cluetipClass: 'jtip', arrows: true, dropShadow: false, hoverIntent: false });
    });

    function ClosePopUp() {
        parent.top.tb_remove();
    }

</script>
<script language="javascript" type="text/javascript">

    function ShowCallCenterNotes(eventId) {
        if ($('#CCNotesA' + eventId).attr('title').length <= 0) {
            var messageUrl = '<%= ResolveUrl("~/App/AutoCompleteService.asmx/GetCcRepInstruction") %>';
            var parameter = "{'eventId':" + eventId + "}";
            InvokeAsynsService(messageUrl, parameter, eventId);
        }
    }

    function OpenPopUpforProductRemove(eventId, customerId) {
        var pageUrl = '/Finance/Order/RemoveProduct?eventId=' + eventId + '&customerId=' + customerId;
        tb_show('Remove Product', pageUrl + '&keepThis=true&TB_iframe=true&width=600&height=600&modal=true', false);
    }

    function OpenPopUpforManualRefund(eventId, customerId) {
        var pageUrl = '/Finance/Order/ManualRefund?eventId=' + eventId + '&customerId=' + customerId + '&keepThis=true&TB_iframe=true&width=600&height=600&modal=true';
        tb_show('ManualRefund', pageUrl, false);
    }

    function OpenPopUpforChangeUserName(userId) {
        var pageUrl = '/Users/User/ChangeUserName?userId=' + userId + '&keepThis=true&TB_iframe=true&width=430&height=200&modal=true';
        tb_show('Change UserName', pageUrl, false);
    }

    function UpdateUserName(userName) {//debugger;
        parent.top.tb_remove();
        $("#<%= spUserName.ClientID %>").html(userName);
        alert("Username updated successfully.");
    }

    function InvokeAsynsService(messageUrl, parameter, eventId) {
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: messageUrl,
            data: parameter,
            success: function (result) {
                $('#CCNotesA' + eventId).attr('title', 'Call Center Notes |' + result.d.replace("'", "\'"));
                $('.CCNotesJtip').cluetip({ splitTitle: '|', cursor: 'pointer', tracking: true, cluetipClass: 'jtip', arrows: true, dropShadow: false, hoverIntent: false });

            },
            error: function (a, b, c) {

                alert('Oops some error accured ');
            }
        });
    }

    function ShowFullfillmentMessage() {
        alert("There is already a unprocessed shipping request in your order. Duplicate shipping cannot be added till this shipping request is processed.");
        return false;
    }

    function ShowRefundRequestShippingMessage() {
        alert("Customer has already requested for the removal of shipping for this event, the removal request is in process. Re-purchase of shipping is not allowed unless the request is resolved. Please contact your admin.");
        return false;
    }

    function ShowAddOnProductMessage() {
        alert("A product is already attached with the customer's order. Duplicate products are not allowed, please contact your admin.");
        return false;
    }

    function ShowRefundRequestProductMessage() {
        alert("Customer has already requested for the removal of product for this event, the removal request is in process. Re-purchase of product is not allowed unless the request is resolved. Please contact your admin.");
        return false;
    }
    
    function ShowAddOnProductMessageForAdmin() {
        alert("A product is already attached with the customer's order. Duplicate products are not allowed.");
        return false;
    }

    function ShowRefundRequestProductMessageForAdmin() {
        alert("Customer has already requested for the removal of product for this event, the removal request is in process. Re-purchase of product is not allowed unless the request is resolved.");
        return false;
    }

    function ShowUpdateShippingMessageForFutureEvent() {
        alert("You can not update shipping status of future event.");
        return false;
    }
</script>
<div class="mainbody_outer" style="display: block" id="dvCustomerDetails" runat="server">
    <div class="mainbody_inner">
        <div class="main_area_bdrnone">
            <div class="headingbox_top_body">
                <p>
                    <img src="/App/Images/specer.gif" width="750px" height="5px" />
                </p>
                <span class="orngheadtxt_heading">Customer Details</span> <span class="headingright_default">
                    <asp:ImageButton ID="imgBtnBack" runat="server" ImageUrl="~/App/Images/back-lnkbtn.gif"
                        OnClick="imgBtnBack_Click" Style="height: 13px" />
                </span>
            </div>
            <div class="divrightbtnbox_mvdbrd" style="float: right; display: none" id="divPrevNext"
                runat="server">
                <span style="float: right; padding-top: 5px" id="imgENext" runat="server" visible="false">
                    <asp:ImageButton ID="lnkBtnNext" runat="server" ImageUrl="~/App/Images/MV/rightarrow-btn-mvdbrd.gif"
                        OnClick="lnkBtnNext_Click" />
                </span><span style="float: right; padding-top: 5px" id="imgDNext" runat="server"
                    visible="false">
                    <img src='<%=ResolveUrl("~/App/Images/MV/rightarrow-btn-mvdbrd-d.gif") %>' />
                </span><span style="float: right" visible="false">
                    <img src='<%=ResolveUrl("~/App/Images/MV/middlec-btn-customer.gif") %>' />
                </span><span style="float: right; padding-top: 5px" id="imgEPrev" runat="server"
                    visible="false">
                    <asp:ImageButton ID="lnkBtnPrev" runat="server" ImageUrl="~/App/Images/MV/leftarrow-btn-mvdbrd.gif"
                        OnClick="lnkBtnPrev_Click" />
                </span><span style="float: right; padding-top: 5px" id="imgDPrev" runat="server"
                    visible="false">
                    <img src='<%=ResolveUrl("~/App/Images/MV/leftarrow-btn-mvdbrd-d.gif") %>' />
                </span>
            </div>
        </div>
        <p>
            <img src="/App/Images/specer.gif" width="700px" height="5px" />
        </p>
        <p class="graylinefull_default">
            <img src="/App/Images/specer.gif" width="1px" height="1px" />
        </p>
        <p>
            <img src="/App/Images/specer.gif" width="725px" height="10px" />
        </p>
        <div class="maindivgreenmsgbox" id="errordiv" enableviewstate="false" visible="false"
            runat="server">
        </div>
        <div class="divmainbody_cd">
            <div class="detailboxtop_cd" style="margin-bottom: 5px;">
                <div class="leftphotodiv_cd">
                    <p>
                        <img src="/App/Images/specer.gif" width="5px" height="50px" />
                    </p>
                    <p class="divphoto_cd">
                        <asp:Image runat="server" ID="imgMyPicture" Width="130px" Height="178px" ImageUrl="~/App/Images/No-Image-Found.gif" />
                    </p>
                </div>
                <div class="custdetails_cd">
                    <p>
                        <img src="/App/Images/specer.gif" width="5px" height="40px" />
                    </p>
                    <div class="custdetailsrow_cd" style="width: 370px;">
                        <span class="orngheadtxt16_default" style="float: left" runat="server" id="spCustomerName"></span>
                    </div>
                    
                    <div  class="custdetailsrow_cd inelegible-customer" style="<%= (IsEligibleCustomer == "" ? "background-color:yellow" : IsEligibleCustomer == "Yes" ? "background-color:green" : "background-color:red") %>">
                            <span class="titletextnowidth_default" id="IsEligibleLabel" style="float: none;">Is Eligible: <span class="normaltextnowidth_default" id="IsEligibleSpan" runat="server" style="float: none;"></span></span>
                    </div>
                    
                    <div class="custdetailsrow_cd">
                        <div style="float: left;">
                            <span runat="server" id="spEmail" style="float: left;"></span>&nbsp;
                        <img src="/Content/Images/Do-Not-Call.gif" style="width: 20px; height: 20px;" alt="" runat="server" class="donotcontact-infoimage" id="doNotContactInfoImage"
                            visible="false" />
                        <img src="/Content/Images/Do-Not-Mail.jpg" style="width: 20px; height: 20px;" alt="" runat="server" class="donotcontact-infoimage" id="doNotMailInfoImage"
                            visible="false" />
                            <div id="doNotContactDiv" style="display: none;">
                                <div id="doNotContactReasonSpan" runat="server" style="font-weight: bold;">
                                </div>
                                <div id="doNotContactReasonNotesSpan" runat="server" style="font-style: italic;">
                                </div>
                            </div>
                            <script type="text/javascript">
                                $(document).ready(function () {
                                    $('.donotcontact-infoimage').qtip({
                                        content: {
                                            text: function (api) {
                                                return $('#doNotContactDiv').html();
                                            }
                                        },
                                        style: {
                                            width: '300px'
                                        }
                                    });
                                });
                            </script>
                        </div>
                        <div class="spactionlink_cdpage"
                            id="pCustomerLinks" runat="server" style="float: right; width: 160px; padding-right: 20px;">
                            <span style="float: right; width: 160px; text-align: right;"><a href="javascript:void(0);"
                                id="aCustomerAction" onclick="DisplayCustomerActionLinks(this);" onmouseout="HideCustomerActionLinks(this, event);">
                                <b>ACTION </b></a>
                                <img src="/App/Images/downarrowsmall.gif" />
                            </span>
                        </div>
                    </div>
                    <p>
                        <img src="/App/Images/specer.gif" width="200px" height="5px" />
                    </p>
                    <p class="custdetailsrow_cd">
                        <span class="titletextnowidth_default">Customer ID:</span> <span id="spcutomerid"
                            runat="server" class="custidtxtbox_cd customer-id"></span><span class="titletextnowidth_default">Gender:</span> <span id="spGender" runat="server" class="normaltextnowidth_default"
                                style="width: 73px"></span><span class="titletextnowidth_default">Date of Birth:</span>
                        <span id="spdob" runat="server" class="normaltextnowidth_default"></span>
                    </p>
                    <p class="custdetailsrow_cd">
                        <span class="titletextnowidth_default">User Name:</span> <span id="spUserName" runat="server"
                            class="normaltextnowidth_default"></span>
                    </p>
                    <p class="custdetailsrow_cd" style="display: none;" id="pQuestion" runat="server">
                        <span class="titletextnowidth_default">Hint Question:</span> <span id="spQuestion"
                            runat="server" class="normaltextnowidth_default"></span>
                    </p>
                    <p class="custdetailsrow_cd" style="display: none;" id="pAnswer" runat="server">
                        <span class="titletextnowidth_default">Hint Answer:</span> <span id="spAnswer" runat="server"
                            class="normaltextnowidth_default"></span>
                    </p>
                    <p class="custdetailsrow_cd">
                        <span class="titletextnowidth_default">Address:</span> <span id="spAddress" runat="server"
                            class="normaltextnowidth_default"></span>
                    </p>
                    <p class="custdetailsrow_cd">
                        <span class="titletextnowidth_default" id="spPhoneNumber" runat="server"></span>
                        <span id="spPhone" runat="server" class="normaltextnowidth_default"></span>&nbsp;
                        <img src="/Content/Images/Do-Not-Call.gif" style="width: 20px; height: 20px;" alt="" class="donotcontact-infoimage" runat="server" id="doNotContact_phoneInfoImage"
                            visible="false" />
                        <img src="/Content/Images/Do-Not-Mail.jpg" style="width: 20px; height: 20px;" alt="" class="donotcontact-infoimage" runat="server" id="doNotMail_InfoImage"
                            visible="false" />
                    </p>
                    <p class="custdetailsrow_cd">
                        <span class="titletextnowidth_default">Consent Captured:</span> 
                        <span id="spConsentStatus" runat="server" class="normaltextnowidth_default" style="width:30px"></span>
                        <span class="titletextnowidth_default"><a href="javascript:void(0)" onclick="ShowPhoneConsent();" id="viewPhoneConsent">View Phone Consent</a></span>
                    </p>
                    <p class="custdetailsrow_cd">
                        <span class="titletextnowidth_default">Sign up Date:</span>
                        <span class="normaltextnowidth_default" style="padding-right: 180px" id="spSignUpDate" runat="server"></span>
                        <span class="titletextnowidth_default">Last Logged in:</span>
                        <span class="normaltextnowidth_default" id="spLastLogin" runat="server"></span>
                    </p>
                    <p class="custdetailsrow_cd">
                        <span class="titletextnowidth_default">Total Revenue:</span> <span id="spRevenue"
                            runat="server" class="normaltextnowidth_default"></span>
                    </p>
                    <p class="custdetailsrow_cd">
                        <span class="titletextnowidth_default">Sign up:</span> <span class="normaltextnowidth_default"
                            id="spSignUp" runat="server"></span>
                    </p>
                    <p class="custdetailsrow_cd">
                        <span class="titletextnowidth_default">Marketing Source:</span>
                        <span class="normaltextnowidth_default marketing-source-span" style="padding-right: 130px" id="marketingSourceSpan" runat="server"></span>
                        <span id="LastScreeningDateContainerSpan" runat="server">
                            <span class="titletextnowidth_default">Last Screening Date:</span>
                            <span class="normaltextnowidth_default" id="LastScreeningDateSpan" runat="server"></span>
                        </span>
                    </p>
                    <p class="custdetailsrow_cd">
                        <span class="titletextnowidth_default">Requested Newsletter:</span>
                        <span class="normaltextnowidth_default" style="padding-right: 130px" id="requestedNewsletterSpan" runat="server"></span>    
                    </p>
                    <p class="custdetailsrow_cd" id="EmployeeIdInsuranceIdContainer" runat="server">
                        <span id="EmployeeIdContainer" runat="server">
                            <span class="titletextnowidth_default">Employee Id:</span>
                            <span class="normaltextnowidth_default" style="padding-right: 130px" id="EmployeeIdSpan" runat="server"></span>
                        </span>
                        <span id="InsuranceIdContainer" runat="server">
                            <span class="titletextnowidth_default" id="InsuranceIdLabel" runat="server">Insurance Id</span>
                            <span class="normaltextnowidth_default" id="InsuranceIdSpan" runat="server"></span>
                        </span>                      
                    </p>
                    <p class="custdetailsrow_cd">
                        <span class="titletextnowidth_default">HICN Number:</span>
                        <span class="normaltextnowidth_default" style="padding-right: 180px" id="HICNNumber" runat="server">N/A</span>
                    </p>
                     <p class="custdetailsrow_cd">
                        <span class="titletextnowidth_default">MBI Number:</span>
                        <span class="normaltextnowidth_default" style="padding-right: 180px" id="MBINumber" runat="server">N/A</span>
                    </p>
                    <p class="custdetailsrow_cd">
                        <span class="titletextnowidth_default">PCP Name:</span>
                        <span class="normaltextnowidth_default" style="padding-right: 180px" id="PcpName" runat="server">N/A</span>
                    </p>
                    <p class="custdetailsrow_cd">
                        <span class="titletextnowidth_default">PCP Phone Number:</span>
                        <span class="normaltextnowidth_default" id="PcpPhoneNumber" runat="server">N/A</span>
                    </p>
                    <p class="custdetailsrow_cd">
                        <span class="titletextnowidth_default">PCP Address:</span>
                        <span id="PcpAddress" runat="server" class="normaltextnowidth_default">N/A</span>
                    </p>
                    <p class="custdetailsrow_cd">
                        <span class="titletextnowidth_default">Tag:</span>
                        <span class="normaltextnowidth_default" style="padding-right: 180px" id="CorporateTag" runat="server">N/A</span>
                    </p>
                    <p class="custdetailsrow_cd">
                        <span class="titletextnowidth_default">Custom Tags:</span>
                        <span class="normaltextnowidth_default" style="padding-right: 180px" id="CustomTag" runat="server">N/A</span>
                    </p>
                    <div class="custdetailsrow_cd">
                        <div style="width: 21%;padding-top: 0px;float: left;" class="titletextnowidth_default">Pre-Approved Test: </div>
                        <div style="float: left;width: 77%;">
                        <span class="normaltextnowidth_default" style="padding: 0; margin: 0;" id="preapprovedTest" runat="server">N/A</span>    
                        </div>
                    </div>
                    <div class="custdetailsrow_cd">
                        <div style="width: 26%;padding-top: 0px;float: left;" class="titletextnowidth_default">Pre-Approved Package: </div>
                        <div style="float: left;width: 72%;">
                        <span class="normaltextnowidth_default" style="padding: 0; margin: 0;" id="preapprovedPackage" runat="server">N/A</span>    
                        </div>
                    </div>
                      <%-- <div class="custdetailsrow_cd">
                        <div style="width: 26%;padding-top: 0px;float: left;" class="titletextnowidth_default">Required Test: </div>
                        <div style="float: left;width: 72%;">
                        <span class="normaltextnowidth_default" style="padding: 0; margin: 0;" id="requiredTest" runat="server">N/A</span>    
                        </div>
                    </div>--%>
                    <div class="custdetailsrow_cd">
                        <div style="width: 10%;padding-top: 0px;float: left;" class="titletextnowidth_default">Activity: </div>
                        <div style="float: left;width: 72%;">
                        <span class="normaltextnowidth_default" style="padding: 0; margin: 0;" id="activity" runat="server">N/A</span>    
                        </div>
                    </div>
                   
                    <div class="custdetailsrow_cd">
                        <asp:Literal runat="server" ID="ltrAdditionalField" > </asp:Literal>
                    </div>
                     <div class="custdetailsrow_cd">
                        <div style="width: 15%;padding-top: 0px;float: left;" class="titletextnowidth_default">Group Name: </div>
                        <div style="float: left;width: 72%;">
                        <span class="normaltextnowidth_default" style="padding: 0; margin: 0;" id="GroupName" runat="server">N/A</span>    
                        </div>
                    </div>
                    <div class="custdetailsrow_cd">
                        <div style="width: 10%;padding-top: 0px;float: left;" class="titletextnowidth_default">ACES Id: </div>
                        <div style="float: left;width: 72%;">
                        <span class="normaltextnowidth_default" style="padding: 0; margin: 0;" id="AcesId" runat="server">N/A</span>    
                        </div>
                    </div>
                    <div class="custdetailsrow_cd">
                        <div style="width: 10%;padding-top: 0px;float: left;" class="titletextnowidth_default">Product : </div>
                        <div style="float: left;width: 72%;">
                        <span class="normaltextnowidth_default" style="padding: 0; margin: 0;" id="ProductType" runat="server">N/A</span>    
                        </div>
                    </div>
                </div>
            </div>
            <div id="divCustomerLinks" style="display: none;" class="spaction_cdpage" onmouseout="this.style.display = 'none';" onmouseover="this.style.display = 'block';">
                <div id="innerCustomerLinks" onmouseout="HideActionLinksITSELF(this, event);" onmouseover="this.parentNode.style.display = 'block';" class="spactioninner_cdpage">
                    <span id="spLnkRegBtn" runat="server" class="spactionelement_cdpage">
                        <asp:LinkButton ID="lnkRegisterForEvent" runat="server" Text="Register For Event" OnClick="lnkRegisterForEvent_Click" Enabled="true"></asp:LinkButton>
                    </span>
                    <span class="spactionelement_cdpage">
                        <asp:LinkButton ID="lnksendMail" runat="server" Text="Send Welcome Mail" OnClick="lnksendMail_Click"></asp:LinkButton>
                    </span>
                    <span id="spResetPassword" runat="server" class="spactionelement_cdpage">
                        <a runat="server" id="achangepassword" href="#">Reset Password</a>
                    </span>
                    <span class="spactionelement_cdpage">
                        <a runat="server" id="aeditcustomer" href="#" onclick="return confirm('Are you sure want to edit information of this user?');">Edit</a>
                    </span>
                    <span runat="server" id="spDisable" class="spactionelement_cdpage">
                        <asp:LinkButton ID="lnkDisable" runat="server" Text="Disable" OnCommand="Command_Button_Click"></asp:LinkButton>
                    </span>
                    <span id="splnkErase" runat="server" class="spactionelement_cdpage">
                        <asp:LinkButton ID="lnkErase" runat="server" Text="Erase" OnCommand="Command_Button_Click"></asp:LinkButton></span>
                    <span id="lnkForceChangePassword" runat="server" style="display: none;" class="spactionelement_cdpage">
                        <a href="javascript:void(0);" id="aForceChangePassword" onclick="forceChangePassword();">Force Change Password</a>
                    </span>
                   <%-- <span id="lnkForceSecurityQuesChange" runat="server" style="display: none;" class="spactionelement_cdpage">
                        <a href="javascript:void(0);" id="aForceSecurityQuesChange" onclick="ForceSecurityQuesChange();">Force Hint Qtn Change</a>
                    </span>--%>
                    <span id="lnkResetLoginCount" runat="server" style="display: none;" class="spactionelement_cdpage">
                        <a href="javascript:void(0);" id="aResetLoginCount" onclick="ResetLoginCount();">Reset Login Count</a>
                    </span>
                    <span id="spAddNotes" runat="server" class="spactionelement_cdpage">
                        <a href="javascript:void(0);" id="a1" onclick="ShowNotes(0)">Add Customer Notes</a>
                    </span>
                    <span id="ChangeUserNameSpan" runat="server" class="spactionelement_cdpage">
                        <a href="javascript:void(0);" id="ChangeUserNameAnchor" runat="server">Change UserName</a>
                    </span>
                    <span id="lnkDeleteCustomTags" runat="server" style="display: none;" class="spactionelement_cdpage">
                        <a href="javascript:void(0);" id="deleteCustomTags" onclick="deleteCustomTags();">Remove Custom Tag(s)</a>
                    </span>
                </div>
            </div>
            <p>
                <img src="/App/Images/specer.gif" width="725px" height="10px" />
            </p>
            <cc1:TabContainer ActiveTabIndex="0" ID="tbpnlContainer" CssClass="grayboxtop_cl"
                runat="server">
                <cc1:TabPanel runat="server" ID="pnlAppointment">
                    <HeaderTemplate>
                        <span id="tab-header-appointment" class="tab-on"><a href="#" onclick="return ChageTab('Appointment');">Appointment </a></span>
                    </HeaderTemplate>
                    <ContentTemplate>
                        <div style="float: left; border: solid 1px #eee; margin: 0px; padding: 0px;">
                            <div class="headingbox_default" id="divEventsAttended" runat="server" style="width: 743px; padding-bottom: 5px;">
                                <div class="orngheadtxt_default" style="float: left; padding: 5px 0px 0px 20px;">
                                    Events Attended/Attending
                                </div>
                            </div>
                            <div style="width: 748px; float: left;">
                                <asp:GridView ID="grdCustomerEvents" DataKeyNames="EventCustomerID" runat="server"
                                    CssClass="grd-customer-events" OnPreRender="grdCustomerEvents_PreRender" AutoGenerateColumns="False"
                                    ShowHeader="False" GridLines="None" OnRowDataBound="grdCustomerEvents_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="divbottomboxes_cd">
                                                    <div class="divbluboxbodybg_cd" id="divmain" runat="server">
                                                        <p>
                                                            <img src="/App/Images/specer.gif" width="600" height="5" />
                                                        </p>
                                                        <div class="bigbluboxrow_cd">
                                                            <div class="blutxt14ptbold_cd" style="float: left;">
                                                                <%# DataBinder.Eval(Container.DataItem, "EventName")%>
                                                                <span>(ID:<%# DataBinder.Eval(Container.DataItem, "EventID")%>)</span> <a id='CCNotesA<%# DataBinder.Eval(Container.DataItem, "EventID")%>'
                                                                    class="CCNotesJtip" href="javascript:void(0)" title="">HSC Notes</a>
                                                            </div>
                                                            <div class="spactionlink_cdpage">
                                                                <span style="float: left; width: 460px; text-align: right;"><a href="javascript:void(0);"
                                                                    id="aAction" onclick="DisplayActionLinks(<%# DataBinder.Eval(Container.DataItem, "EventID")%>,this);"
                                                                    onmouseout="HideActionLinks(<%# DataBinder.Eval(Container.DataItem, "EventID")%>,this, event);">
                                                                    <b>ACTION </b></a>
                                                                    <img src="/App/Images/downarrowsmall.gif" /></span>
                                                            </div>
                                                            <div id='pEventLinks<%# DataBinder.Eval(Container.DataItem, "EventID")%>' style="display: none;"
                                                                class="spaction_cdpage" onmouseout="this.style.display = 'none';" onmouseover="this.style.display = 'block';">
                                                                <div id="innerEventLinks" onmouseout="HideActionLinksITSELF(this, event);" onmouseover="this.parentNode.style.display = 'block';"
                                                                    class="spactioninner_cdpage">
                                                                    <span class="spactionelement_cdpage" id="spAcceptPayment" runat="server"><a href="#"
                                                                        id="aAcceptPayment" runat="server">Accept Payment</a> </span><span class="spactionelement_cdpage"
                                                                            id="spLnkChangeAppt" runat="server">
                                                                            <asp:LinkButton ID="lnkChangeApp" runat="server" Text="Change Appointment" CommandName='<%# DataBinder.Eval(Container.DataItem, "EventID") %>'
                                                                                CommandArgument='<%# DataBinder.Eval(Container.DataItem, "EventCustomerID") %>'
                                                                                OnClick="lnkChangeApp_Click">
                                                                            </asp:LinkButton>
                                                                        </span><span class="spactionelement_cdpage">
                                                                            <asp:LinkButton ID="lnkChangePackage" runat="server" Text="Adjust Order" CommandName='<%# DataBinder.Eval(Container.DataItem, "EventID") %>'
                                                                                CommandArgument='<%# DataBinder.Eval(Container.DataItem, "EventCustomerID") %>'
                                                                                OnClick="lnkChangePackage_Click">
                                                                            </asp:LinkButton>
                                                                        </span><span id="spLnkApplyCoupon" runat="server" class="spactionelement_cdpage">
                                                                            <asp:LinkButton ID="lnkApplyCoupon" runat="server" Text="Apply Source Code" CommandName='<%# DataBinder.Eval(Container.DataItem, "EventID") %>'
                                                                                CommandArgument='<%# DataBinder.Eval(Container.DataItem, "EventCustomerID") %>'
                                                                                OnClick="lnkApplyCoupon_Click" Enabled="True">
                                                                            </asp:LinkButton>
                                                                        </span>
                                                                    <span class="spactionelement_cdpage" ID="spLnkRSMail" runat="server">
                                                                            <asp:LinkButton CommandArgument='<%# DataBinder.Eval(Container.DataItem, "EventCustomerID") %>'
                                                                                CommandName='<%# DataBinder.Eval(Container.DataItem, "EventID") %>' ID="lnkRSMail"
                                                                                runat="server" Text="Send Reminder Mail" OnClick="lnkRSMail_Click">
                                                                            </asp:LinkButton>
                                                                        </span>
                                                                    <span class="spactionelement_cdpage">
                                                                            <asp:LinkButton ID="lnkDelApp" runat="server" Text="Cancel Appointment" CommandName='<%# DataBinder.Eval(Container.DataItem, "EventID") %>'
                                                                                OnClick="lnkDelApp_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "EventCustomerID") %>'
                                                                                OnClientClick="return confirm('Are you sure you want to cancel this appointment?');">
                                                                            </asp:LinkButton>
                                                                        </span>
                                                                    <span id="spErase" runat="server" visible="false" class="spactionelement_cdpage">
                                                                            <asp:LinkButton ID="lnkErase" runat="server" Text="Erase Results" CommandName='<%# DataBinder.Eval(Container.DataItem, "EventID") %>'
                                                                                OnClick="lnkErase_Click" OnClientClick="return confirm('Are you sure you want to erase the Results?');">
                                                                            </asp:LinkButton>
                                                                        </span>
                                                                    <span id="CancelShippingSpan" runat="server" visible="false" class="spactionelement_cdpage">
                                                                        <asp:LinkButton ID="CancelShippingLinkButton" runat="server" Text="Cancel Shipping"
                                                                            OnClick="CancelShippingLinkButton_Click" OnClientClick="return confirm('Are you sure you want to Cancel Shipping?');">
                                                                        </asp:LinkButton>
                                                                    </span>
                                                                    <span id="sendAppointmentConfirmationSpan" runat="server" visible="false" class="spactionelement_cdpage">
                                                                        <a href="javascript:SendConfirmationSms(<%# DataBinder.Eval(Container.DataItem, "EventID") %>, <%=CustomerId %>); void(0);">Send Appointment Confirmation SMS</a>
                                                                    </span>
                                                                    <span id="sendAppointmentReminderSpan" runat="server" visible="false" class="spactionelement_cdpage">
                                                                        <a href="javascript:SendReminderSms(<%# DataBinder.Eval(Container.DataItem, "EventID") %>, <%=CustomerId %>); void(0);">Send Appointment Reminder SMS</a>
                                                                    </span>
                                                                    <span id="spAddNotes" runat="server" class="spactionelement_cdpage">
                                                                        <a href="javascript:void(0);" id="aNotes" onclick="ShowNotes('<%# DataBinder.Eval(Container.DataItem, "EventID") %>')">Add Event Specific Notes</a>
                                                                    </span>
                                                                    <span runat="server" id="RemoveProductSpan" class="spactionelement_cdpage">
                                                                        <a href="javascript:OpenPopUpforProductRemove(<%# DataBinder.Eval(Container.DataItem, "EventID") %>, <%=CustomerId %>); void(0);">Remove Product</a>
                                                                    </span>
                                                                    <span runat="server" id="ManualRefund" class="spactionelement_cdpage" style="display: block;">
                                                                        <a href="javascript:OpenPopUpforManualRefund(<%# DataBinder.Eval(Container.DataItem, "EventID") %>, <%=CustomerId %>); void(0);">Manual Refund</a>
                                                                    </span>
                                                                    <% if (IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.CheckRole((long)Falcon.App.Core.Enum.Roles.Technician) || IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.CheckRole((long)Falcon.App.Core.Enum.Roles.CallCenterRep)||  IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.CheckRole((long)Falcon.App.Core.Enum.Roles.FranchisorAdmin))
                                                                       {%>
                                                                    <span id="spAddonProduct" runat="server" class="spactionelement_cdpage">
                                                                        <a href="javascript:void(0);" id="aAddonProduct" runat="server">Add On Product</a> </span>
                                                                    <%
                                                                       }
                                                                        if (IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.CheckRole((long)Falcon.App.Core.Enum.Roles.CallCenterRep))
                                                                       {%>

                                                                    <span class="spactionelement_cdpage">
                                                                        <a href="javascript:void(0);" id="FullfillmentOptionAnchor" runat="server">Fullfillment Option</a>
                                                                    </span>
                                                                    <%
                                                                       }
                                                                       else if (IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.CheckRole((long)Falcon.App.Core.Enum.Roles.FranchisorAdmin) || IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.CheckRole((long)Falcon.App.Core.Enum.Roles.OperationManager))
                                                                       {%>
                                                                    <span class="spactionelement_cdpage">
                                                                        <a runat="server" id="AssignPhysicianToCustomer" href='javascript:window.open("/Operations/PhysicianAssignment/AssignPhysicianToCustomer?eventCustomerId=<%# DataBinder.Eval(Container.DataItem, "EventCustomerID") %>","AssignPhysician_Customer","toolbar=no,location=no,directories=no,status=no,scrolling=auto,scrollbars=no,menubar=no,width=550,height=450");void(0);'>Assign Physicians</a>
                                                                    </span>
                                                                    <span class="spactionelement_cdpage" id="UpdateShippingStatusSpan" runat="server">
                                                                        <a id="UpdateShippingStatusAnchor" runat="server" href="javascript:void(0);">Update Shipping Status</a>
                                                                    </span>
                                                                    <% }%>
                                                                    <span id="spPrintReceipt" runat="server" class="spactionelement_cdpage">
                                                                        <asp:LinkButton ID="lnkPrintReceipt" runat="server" Text="Print Receipt" CommandName='<%# DataBinder.Eval(Container.DataItem, "EventID") %>'
                                                                            OnClick="lnkPrintReceipt_Click" Enabled="True">
                                                                        </asp:LinkButton>
                                                                    </span>
                                                                    <span id="spGeneratePDF" runat="server" class="spactionelement_cdpage" style="display: none;">
                                                                        <a id="aReGeneratePDF" href='javascript:void(0)' onclick='ReGeneratePDF(<%# DataBinder.Eval(Container.DataItem, "EventID") %>);'>Generate Results</a>
                                                                    </span>
                                                                    <span id="spTestPDF" runat="server" class="spactionelement_cdpage" style="display: none;"></span>
                                                                    <span id="spPcpAppointment" runat="server" Visible="False" class="spactionelement_cdpage">
                                                                      <a id="aPcpAppointment" target="_blank" href="/Scheduling/EventCustomerList/PcpAppointment?eventCustomerId= <%# DataBinder.Eval(Container.DataItem, "EventCustomerID")%> ">PCP Appointment</a>
                                                                    </span>
                                                                    <span id="spConfirmAppointment" runat="server" Visible="false" class="spactionelement_cdpage">
                                                                        <a id="aConfirmAppointment" href="javascript:void(0);" onclick="confirmAppointment(<%=CustomerId %>, <%# DataBinder.Eval(Container.DataItem, "EventCustomerID") %>)" >Confirm Appointment</a>
                                                                    </span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <p>
                                                            <img src="/App/Images/specer.gif" width="600" height="5" />
                                                        </p>
                                                        <p class="bigbluboxrow_cd">
                                                            <span class="titletextnowidth_default">Event Details:</span> <span class="normaltextnowidth_default">
                                                                <%# DataBinder.Eval(Container.DataItem, "HostName")%>,&nbsp;<%# DataBinder.Eval(Container.DataItem, "Address")%></span></p>
                                                        <p class="bigbluboxrow_cd">
                                                            <span class="titletextnowidth_default">Event Status:</span> <span class="normaltextnowidth_default">
                                                                <%# DataBinder.Eval(Container.DataItem, "EventStatus")%>
                                                            </span>
                                                        </p>
                                                        <p class="bigbluboxrow_cd">
                                                            <span class="titletextnowidth_default">Event Date & Time:</span> <span class="normaltextnowidth_default">
                                                               <span class="serviceDate"> <%# DataBinder.Eval(Container.DataItem, "EventDate")%></span>
                                                                at
                                                                <%# DataBinder.Eval(Container.DataItem, "Appointment")%>
                                                            </span>
                                                        </p>
                                                        <p class="bigbluboxrow_cd">
                                                            <span class="titletextnowidth_default">Pod:</span> <span class="normaltextnowidth_default">
                                                                <%# DataBinder.Eval(Container.DataItem, "PodName")%>
                                                            </span>
                                                        </p>
                                                        <p class="bigbluboxrow_cd">
                                                            <span class="titletextnowidth_default">Sign-in/Sign-out:</span> <span class="normaltextnowidth_default">
                                                                <%# DataBinder.Eval(Container.DataItem, "SignIN")%>
                                                                /
                                                                <%# DataBinder.Eval(Container.DataItem, "SignOut")%>
                                                            </span>
                                                        </p>
                                                        <div class="twocolumnbox_cd">
                                                            <div class="bigbluboxleft_cd">
                                                                <p class="bigbluboxleft_cd">
                                                                    <span class="titletextnowidth_default">Register Date:</span> <span runat="server"
                                                                        id="registerDateSpan" class="normaltextnowidth_default register-date">
                                                                        <%# DataBinder.Eval(Container.DataItem, "RegisterDate")%>
                                                                    </span>
                                                                </p>
                                                                <p class="bigbluboxleft_cd">
                                                                    <span class="titletextnowidth_default">Attended?:</span> <span runat="server" id="attendedSpan" class="normaltextnowidth_default">
                                                                        <%# DataBinder.Eval(Container.DataItem, "ShowUp")%>
                                                                    </span>
                                                                </p>
                                                                <p class="bigbluboxleft_cd" style="display: none">
                                                                    <span class="titletextnowidth_default">Package Name:</span> <span class="normaltextnowidth_default"
                                                                        id="_spPackage" runat="server">
                                                                        <%# DataBinder.Eval(Container.DataItem, "Package")%>
                                                                    </span>
                                                                </p>
                                                                <p class="bigbluboxleft_cd">
                                                                    <span class="titletextnowidth_default">Order:</span> <span class="normaltextnowidth_default"
                                                                        id="_spnPaymentLink" runat="server"><a id="PaymentLinkAnchor" runat="server" href="#">
                                                                            <b>View Detail</b></a></span><%--<span style="float: left; padding: 2px 0px 0px 10px;"
                                                                                id="spAcceptPayment" runat="server">[ <a href="#" id="aAcceptPayment" runat="server">
                                                                                    Accept Payment</a> ] </span>--%></p>
                                                                <p class="bigbluboxleft_cd">
                                                                    <span class="titletextnowidth_default">Shipping:</span> <span class="normaltextnowidth_default"
                                                                        id="ShippingDetailSpan" runat="server"><a id="ShippingDetailAnchor" runat="server"
                                                                            href="#"><strong>Shipping&nbsp;Details</strong></a></span>
                                                                </p>
                                                                <p class="bigbluboxleft_cd">
                                                                    <span class="titletextnowidth_default">Franchisee:</span> <span class="normaltextnowidth_default">
                                                                        <%# DataBinder.Eval(Container.DataItem, "Franchisee")%>
                                                                    </span>
                                                                </p>
                                                                <p class="bigbluboxleft_cd">
                                                                    <span class="titletextnowidth_default">Sign up:</span> <span class="normaltextnowidth_default">
                                                                        <%# DataBinder.Eval(Container.DataItem, "SignUP")%>
                                                                    </span>
                                                                </p>
                                                                <p class="bigbluboxleft_cd">
                                                                    <span class="titletextnowidth_default">Screening Cost:</span> <span class="normaltextnowidth_default"
                                                                        id="_spCost" runat="server">
                                                                        <%# DataBinder.Eval(Container.DataItem, "Cost")%>
                                                                    </span>
                                                                </p>
                                                                <p class="bigbluboxleft_cd">
                                                                    <span class="titletextnowidth_default">Marketing Source:</span> <span runat="server"
                                                                        id="marketingSource" class="normaltextnowidth_default leadSourceSpan"><span class="leadSourceSpanHover">
                                                                            <%# DataBinder.Eval(Container.DataItem, "Source")%></span>
                                                                        <input type="hidden" id="eventCustomerIdHidden" value='<%#DataBinder.Eval(Container.DataItem,"EventCustomerID") %>' />
                                                                    </span>
                                                                </p>
                                                                <p class="bigbluboxleft_cd">
                                                                    <span class="titletextnowidth_default">Source Code:</span>
                                                                    <span class="normaltextnowidth_default couponCodeSpan">
                                                                        <span class="couponCodeSpanHover" id="_spSourceCode" runat="server">
                                                                            <%# DataBinder.Eval(Container.DataItem, "Coupon")%>
                                                                            <%# DataBinder.Eval(Container.DataItem, "Discount")%></span>
                                                                        <input type="hidden" id="Hidden1" value='<%#DataBinder.Eval(Container.DataItem,"EventCustomerID") %>' />
                                                                    </span>
                                                                </p>
                                                                <p class="bigbluboxleft_cd" id="medicalHistoryContainer" runat="server">
                                                                    <span class="titletextnowidth_default">Health Assessment Form:</span>
                                                                    <span class="normaltextnowidth_default">
                                                                        <span id="spMedicalHistory" runat="server"></span>
                                                                        (<a href="#" style="text-decoration: none;" rel="gb_page_center[1100, 500]" runat="server" id="amedicalhistory"></a>)
                                                                    </span>
                                                                </p>
                                                                <p class="bigbluboxleft_cd" id="mspformContainer" runat="server">
                                                                    <span class="titletextnowidth_default">MSP Form:</span>
                                                                    <span class="normaltextnowidth_default">
                                                                        <span id="mspHistory" runat="server"></span>
                                                                        (<a href="#" style="text-decoration: none;" rel="gb_page_center[1000, 500]" runat="server" id="mspHistoryForm">View</a>)
                                                                    </span>
                                                                </p>
                                                                <div id="pcpAppointmentInfo" runat="server">
                                                                    <p class="bigbluboxleft_cd">
                                                                        <span class="titletextnowidth_default"> PCP Appointment Date & Time:</span>
                                                                        <span class="normaltextnowidth_default">
                                                                            <span id="pcpAppointmentDate" runat="server"></span>
                                                                        </span>
                                                                    </p>
                                                                   
                                                                </div>
                                                                  <div id="divEnableTexting" runat="server">
                                                                    <p class="bigbluboxleft_cd">
                                                                  <span class="titletextnowidth_default">Receive SMS :</span> <span class="normaltextnowidth_default" id="EnableTextingSpan" runat="server"><span id="EnableTextInfo" runat="server"></span>
                                                                        <a id="EnableTextingAnchor" class="update-enable-texting-anchor" runat="server" href="javascript:void(0);"><strong>(Update)</strong></a></span>
                                                                </p>
                                                                </div>
                                                                <p class="bigbluboxleft_cd">
                                                                    <span class="titletextnowidth_default">Customer Left Without Screening :</span> <span class="normaltextnowidth_default">
                                                                        <span id="patientLeftWithoutScreening" runat="server">N/A</span>
                                                                    </span>
                                                                </p>
                                                                <div id="divHraQuestionnaire" style="display:none;" runat="server" >
                                                                    <p class="bigbluboxleft_cd">
                                                                        <span class="titletextnowidth_default">HRA Questionnaire :</span> <span class="normaltextnowidth_default">                                                                          
                                                                                <a href="javascript:void(0)" onclick="addColorBoxWrapper('<%=HraQuestionerAppUrl%>', '<%=OrganizationNameForHraQuestioner%>', '<%# DataBinder.Eval(Container.DataItem, "CorporateAccountTag") %>', '<%=HttpUtility.UrlEncode(HraToken)%>', '<%# DataBinder.Eval(Container.DataItem, "EventID") %>',
                                '<%# DataBinder.Eval(Container.DataItem, "EventCustomerID") %>', <%=CustomerId %>, '<%# DataBinder.Eval(Container.DataItem, "MedicareVisitId") %>')">Update</a>
                                                                                <input type="hidden" id="hravisitId_<%# DataBinder.Eval(Container.DataItem, "EventCustomerID") %>" value="" />   
                                                                                <a id="hraLink_<%# DataBinder.Eval(Container.DataItem, "EventCustomerID") %>" style="display: none;"></a>                                                                                                                                                    
                                                                        </span>
                                                                         <span class="info-tip" style="vertical-align: middle;"><img alt="Info" src="/App/Images/info-icon.gif"></span>
                                                                         <span style="display: none" class="hra-questionnaire-help">The HRA of customer needs to be filled on new HRA Application.Please do not fill on Vatica Application.</span>
                                                                    </p>
                                                                </div>
                                                                 <div id="divChatQuestionnaire" style="display:none;" runat="server" >
                                                                    <p class="bigbluboxleft_cd">
                                                                        <span class="titletextnowidth_default">CHAT Questionnaire :</span> <span class="normaltextnowidth_default">                                                                          
                                                                                <a href='<%=ChatQuestionerAppUrl %>' target="_blank" >CHAT</a>
                                                                        </span>
                                                                    </p>
                                                                </div>


                                                                <p class="bigbluboxleft_cd" >
                                                                    <span class="titletextnowidth_default">Medications :</span> <span class="normaltextnowidth_default">
                                                                        <span id="MedicationSpan" runat="server"><a href="javascript:void(0)" onclick="return ShowMedications(this)">View Medications</a></span>
                                                                    </span>
                                                                </p>                                                               
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="divbluboxbotbg_cd" id="divbottom" runat="server">
                                                        <img src="/App/Images/specer.gif" width="50" height="5" />
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <AlternatingRowStyle CssClass="row3" />
                                    <HeaderStyle CssClass="row1" />
                                    <RowStyle CssClass="row2" />
                                </asp:GridView>
                            </div>
                        </div>
                    </ContentTemplate>
                </cc1:TabPanel>
                <cc1:TabPanel ID="pnlCommunication" runat="server">
                    <HeaderTemplate>
                        <span class="tab-off" id="tab-header-communication"><a href="#" onclick="return ChageTab('Communication');">Communication </a></span>
                    </HeaderTemplate>
                    <ContentTemplate>
                        <div runat="server" id="divCommunication">
                            <div style="float: left; width: 746px; border: solid 1px #ccc; padding: 20px 0px 20px 0px; display: none;"
                                id="dvNoItemFound" runat="server">
                                <div class="divnoitemfound_custdbrd">
                                    <p class="divnoitemtxt_custdbrd">
                                        <span class="orngbold18_default">No Communication Found</span>
                                    </p>
                                </div>
                            </div>
                            <div style="float: left; width: 746px;">
                                <asp:GridView ID="grdCommunication" runat="server" CssClass="divgrid_clnew" GridLines="None"
                                    AutoGenerateColumns="False" DataKeyNames="NotificationID" AllowPaging="True"
                                    OnPageIndexChanging="grdCommunication_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="ID" Visible="False">
                                            <ItemTemplate>
                                                <a href="#">
                                                    <%# DataBinder.Eval(Container.DataItem, "NotificationID")%>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date">
                                            <ItemTemplate>
                                                <span id="spnDate">
                                                    <%# DataBinder.Eval(Container.DataItem, "ServicedDate")%></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Communication Info">
                                            <ItemTemplate>
                                                <b>Type:&nbsp;</b><%# DataBinder.Eval(Container.DataItem, "NotificationTypeName")%><br /><b>Medium:&nbsp;</b>&nbsp;
                                                <img alt="<%# DataBinder.Eval(Container.DataItem, "NotificationMedium")%>" src="<%# DataBinder.Eval(Container.DataItem, "ServiceStatus").ToString().Equals("--")?"/App/Images/incomingphone-icon.gif":ImagePath(DataBinder.Eval(Container.DataItem, "NotificationMedium"))%>" />
                                                <br />
                                                <b>Notification ID:&nbsp;</b><%# DataBinder.Eval(Container.DataItem, "NotificationID").ToString().Equals("0") ? "-N/A-" : DataBinder.Eval(Container.DataItem, "NotificationID").ToString()%><br /><b>Status:&nbsp;</b><%# DataBinder.Eval(Container.DataItem, "ServiceStatus")%><br /><b>Notes:&nbsp;</b><%# DataBinder.Eval(Container.DataItem, "IsInvalidAddress")%><br />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Call Details">
                                            <ItemTemplate>
                                                <b>Call Type:</b>&nbsp;<%# DataBinder.Eval(Container.DataItem,"CallType") %><br /><b>CCRep:&nbsp;</b><%# DataBinder.Eval(Container.DataItem, "CCRep")%><br /><b>Call Duration:&nbsp;</b><%# DataBinder.Eval(Container.DataItem, "CallDuration")%><br /><b>Call OutCome:&nbsp;</b><%# DataBinder.Eval(Container.DataItem, "CallOutcome")%><br /><b>Call Disposition:&nbsp;</b><%# DataBinder.Eval(Container.DataItem, "Disposition")%><br /><b>From CallQueue:&nbsp;</b><%# DataBinder.Eval(Container.DataItem, "IsCallQueueCall")%><br /><span style=<%# String.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "Reason").ToString())? "display:none;":""%>><b>Reason:&nbsp;</b><%# DataBinder.Eval(Container.DataItem, "Reason")%><br /></span><div style="float:left;padding-top:3px;"> <b>Call Notes:&nbsp;</b></div>                                             
                                               <div style="float:left;">
                                                    <table id="list-view" style="border:hidden;">                                                   
                                                    <tr>
                                                        <td>
                                                            <a href="javascript:void(0)" class="notes-detail"><b>Notes</b></a>
                                                            <div class="notes-div" style="display:none;">
                                                                <span style="width: 200px;"><%# !String.IsNullOrEmpty(DataBinder.Eval(Container.DataItem, "CallNotes").ToString())? DataBinder.Eval(Container.DataItem, "CallNotes").ToString():"N/A"%></span>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                               </div>                                                                                            
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Communication Pair">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "ServicedBy").ToString().Equals("") && DataBinder.Eval(Container.DataItem, "Name").ToString().Equals("") ? "" : DataBinder.Eval(Container.DataItem, "ServicedBy") + " -To- " + DataBinder.Eval(Container.DataItem, "Name")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <%# Action(DataBinder.Eval(Container.DataItem, "ServiceStatus"), DataBinder.Eval(Container.DataItem, "NotificationID"),DataBinder.Eval(Container.DataItem, "NotificationMedium"))%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <AlternatingRowStyle CssClass="row3" />
                                    <HeaderStyle CssClass="row1" />
                                    <RowStyle CssClass="row2" />
                                </asp:GridView>
                            </div>
                        </div>
                    </ContentTemplate>
                </cc1:TabPanel>
                <cc1:TabPanel ID="pnlNotes" runat="server">
                    <HeaderTemplate>
                        <span class="tab-off" id="tab-header-notes"><a href="#" onclick="return ChageTab('Notes');">Notes </a></span>
                    </HeaderTemplate>
                    <ContentTemplate>
                        <div id="divNotes" style="float: left; width: 95%; padding-left: 10px; padding-top: 10px;">
                        </div>
                        <script language="javascript" type="text/javascript">

                            function loadNotes(CustomerId, eventId) {
                                $.ajax({
                                    type: "GET",
                                    contentType: "application/json; charset=utf-8",
                                    dataType: "html", url: "/Communication/CustomerCallNotes/CustomerCallNotes?customerId=" + CustomerId + "&eventId=" + eventId, data: '{}',
                                    success: function (result) { $("#divNotes").html(result); loadNotesMethod = loadNotes; }, error: function (a, b, c) { }
                                });
                            }

                            $(document).ready(function () { loadNotes('<%= CustomerId %>', 0); });

                        </script>
                    </ContentTemplate>
                </cc1:TabPanel>
                <cc1:TabPanel ID="pnlOrders" runat="server">
                    <HeaderTemplate>
                        <span class="tab-off" id="tab-header-orders"><a href="#" onclick="return ChageTab('Orders');">Orders </a></span>
                    </HeaderTemplate>
                    <ContentTemplate>
                        <div id="divOrders" style="float: left; width: 95%; padding-left: 10px; padding-top: 10px;">
                        </div>
                        <script language="javascript" type="text/javascript">

                            function loadOrders(CustomerId) {
                                $.ajax({
                                    type: "GET",
                                    contentType: "application/json; charset=utf-8",
                                    dataType: "html", url: "/Finance/Reports/CustomerOrders?customerId=" + CustomerId, data: '{}',
                                    success: function (result) { $("#divOrders").append(result); }, error: function (a, b, c) { }
                                });
                            }

                            $(document).ready(function () { loadOrders('<%= CustomerId %>'); });

                        </script>
                    </ContentTemplate>
                </cc1:TabPanel>
                <cc1:TabPanel ID="pnlResults" runat="server">
                    <HeaderTemplate>
                        <span class="tab-off" id="tab-header-results"><a href="#" onclick="return ChageTab('Results');">Results </a></span>
                    </HeaderTemplate>
                    <ContentTemplate>
                        <div id="divResults" style="float: left; width: 95%; padding-left: 10px; padding-top: 10px;">
                        </div>
                        <script language="javascript" type="text/javascript">

                            function loadResults(CustomerId) {
                                $.ajax({
                                    type: "GET",
                                    contentType: "application/json; charset=utf-8",
                                    dataType: "html", url: "/Medical/Results/GetCustomerResultStatus?customerId=" + CustomerId, data: '{}',
                                    success: function (result) { $("#divResults").append(result); }, error: function (a, b, c) { }
                                });
                            }

                            $(document).ready(function () { loadResults('<%= CustomerId %>'); });

                        </script>
                    </ContentTemplate>
                </cc1:TabPanel>
            </cc1:TabContainer>
        </div>
        <p>
            <img src="/App/Images/specer.gif" width="725px" height="40px" />
        </p>
    </div>
</div>
<div class="mainbody_outer" style="display: none" id="dvNoRecordFound" runat="server">
    <div class="mainbody_inner">
        <div class="main_area_bdrnone">
            <div class="orngheadtxt_default" style="padding-top: 8px; float: left;">
                Customer Details
            </div>
            <div class="divnoitemfound_custdbrd">
                <p class="divnoitemtxt_custdbrd">
                    <span class="orngbold18_default">No Record Found</span>
                </p>
            </div>
        </div>
    </div>
</div>

<div id="AddNotesDialogDiv" title="Add Notes">
    <div class="editor-row" style="margin-top: 15px;">
        <div style="float: left; width: 10%">Notes :</div>
        <div style="float: left; width: 60%">
            <textarea id="NotesTextArea" rows="4" cols="65"></textarea>
        </div>
    </div>
</div>

<div id="UpdateShippingStatusDialogDiv" title="Update Shipping Status">
</div>

<div id="customerCustomTagDialogDiv">
    <img src="/App/Images/loading.gif"/>
</div>

<div id="divloading" class="loadingdiv_ucecustlist" style="display: none">
    <span class="ltxt">Processing...</span> <span class="left">
        <img src="/App/Images/loading.gif" alt="" /></span>
</div>
<div id="leadSourceEditDiv" style="display: none" title="Update Marketing Source">
    <div class="jdialog-row marketing-source-error-div" style="color: Red">
        Marketing Source cannot be blank.
    </div>
    <div class="jdialog-row">
        <input type="text" id="leadSourceText" size="40" />
    </div>
    <div class="jdialog-row" id="updateForFirstRegistration" style="display: none">
        <input type="checkbox" id="updateForFirstRegistrationChkBox" />
        Update Marketing Source for Screening Appointment
    </div>
    <div class="jdialog-row" id="updateSignUpMarketingSource" style="display: none">
        <input type="checkbox" id="updateSignUpMarketingSourceChkBox" checked="checked" />
        Update Sign up marketing source
    </div>
    <div class="jdialog-row">
        <input type="button" id="leadSourceButton" value="Update" class="rgt button-click" />
    </div>
    <div class="jdialog-row">
        <input type="button" id="marketingSourceButton" value="Update" class="rgt button-click" />
        <input type="hidden" id="leadSourceId" />
    </div>
</div>
<div id="couponCodeEditDiv" style="display: none" title="Update Source Code">
    <div class="coupon-code-error-div jdialog-row" style="color: Red">
        Source Code cannot be blank.
    </div>
    <div class="coupon-code-invalid-div jdialog-row" style="color: Red">
        Invalid Source Code.
    </div>
    <div class="jdialog-row">
        <input type="text" id="couponCodeText" size="20" />
    </div>
    <div class="jdialog-row">
        <input type="hidden" id="couponCodeId" />
    </div>
    <div class="jdialog-row">
        <input type="button" id="couponCodeButton" value="Update" class="rgt button-click" />
    </div>
</div>
<asp:HiddenField ID="hfUserID" runat="server" Value="0" />
<asp:HiddenField ID="hfGuId" runat="server" Value="0" />
<script type="text/javascript" language="javascript">
    function addColorBoxWrapper(url, name, tag, token, evtId, eventCustId, custId, visitId) {
        checkSession().then(function (data) {
            if ($("#hravisitId_" + eventCustId).val() != "") {
                visitId = $("#hravisitId_" + eventCustId).val();
            }
            initiateHraQuestionare(url, name, tag, token, evtId, true, true);
            addColorBoxCustomerHistory(eventCustId, custId, visitId);
            
            //stop colorbox scroll
            $(document).bind('cbox_open', function () {
                $('body').css({ overflow: 'hidden' });
            }).bind('cbox_closed', function () {
                $('body').css({ overflow: '' });
            });

            $('#hraLink_' + eventCustId).click();
        }, function (data) {
            alert(data);
            window.location.replace("/login");
        });
    }

</script>
<script type="text/javascript" language="javascript">
    var addNotesEventId = 0;

    function ShowNotes(EventId) {
        addNotesEventId = EventId;
        $("#NotesTextArea").val('');
        $('#AddNotesDialogDiv').dialog('open');
    }

    function AddCustomerNotes() {
        if ($.trim($("#NotesTextArea").val()) == '') {
            alert("Please enter notes.");
            return false;
        }
        var parameter = '{"customerId":"' + '<%= CustomerId %>' + '",';
        parameter += '"eventId":"' + addNotesEventId + '",';
        parameter += '"notes":"' + $("#NotesTextArea").val().replace(/\\/gi, "\\\\").replace(/\"/gi, "\\\"") + '"}';
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "html", url: "/Communication/CustomerCallNotes/AddCustomerNotes",
            data: parameter,
            success: function (result) { AddNotesSuccessFunction(result); },
            error: function(a, b, c) {
                if (a.status == 401) {
                    alert('You do not have permission to add customer notes!');
                    $('#AddNotesDialogDiv').dialog('close');
                }
            }
        });
    }

    function AddNotesSuccessFunction(result) {
        if (result == '<%= Boolean.TrueString %>') {
            $('#AddNotesDialogDiv').dialog('close');
            alert("Notes Added.");
            loadNotes('<%= CustomerId %>', 0);
        }
        else {
            alert("Can not add notes.");
        }
    }

    $(document).ready(function () {
        $('#AddNotesDialogDiv').dialog({ autoOpen: false, width: 500, height: 230, closeOnEscape: true, buttons: { 'Close': function () { $(this).dialog('close'); }, 'Save': function () { AddCustomerNotes(); } } });

        $('#UpdateShippingStatusDialogDiv').dialog({ autoOpen: false, width: 550, height: 220, closeOnEscape: true, buttons: { 'Close': function () { $(this).dialog('close'); } } });
    });


</script>

<script type="text/javascript" language="javascript">
    function LoadShippingForUpdateStatus(eventId, customerId) {//debugger;
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "html", url: "/Operations/Shipping/GetShippingDetails?eventId=" + eventId + "&customerId=" + customerId, data: '{}',
            success: function (result) {
                $("#UpdateShippingStatusDialogDiv").html(result);
                $('#UpdateShippingStatusDialogDiv').dialog('open');
            },
            error: function(a, b, c) {
                if (a.status == 401) {
                    alert('You do not have permission to view shipping details!');
                } else {
                    alert('Some error occured!!');
                }
            }
        });
    }
</script>

<script type="text/javascript" language="javascript">

    $(document).ready(function () {
        $.ajaxSetup({ cache: false });
        $('.marketing-source-span').hover(MouseOver, MouseOut);
        //$('.couponCodeSpanHover').hover(MouseOver, MouseOut);
        $('.leadSourceSpanHover').hover(MouseOver, MouseOut);
        BindClickFunction();
        AddDialogBox('couponCodeEditDiv');
        AddDialogBox('leadSourceEditDiv');
        $('#updateForFirstRegistrationChkBox').attr('checked', false);
    });

    function BindClickFunction() {
        $('.marketing-source-span').click(function () { EditMarketingSource(this); });
        $('.leadSourceSpan').click(function () { EditLeadSource(this); });
        //$('.couponCodeSpan').click(function() { EditCouponCode(this); });
    }

    function UnBindClickFunction() {
        $('.marketing-source-span').unbind('click');
        $('.leadSourceSpan').unbind('click');
        //$('.couponCodeSpan').unbind('click');
    }

    function AddDialogBox(controlId) {
        $('#' + controlId).dialog({ width: 300, height: 175, autoOpen: false, resizable: false, draggable: false });
    }

    function MouseOver(e) {
        $(e.target).addClass('anchor');
    }

    function MouseOut(e) {
        $(e.target).removeClass('anchor');
        RemoveClass();
    }

    function RemoveClass() {
        $('.marketing-source-span').removeClass('anchor');
        $('.leadSourceSpan').removeClass('anchor');
        //$('.couponCodeSpan').removeClass('anchor');
    }

    function EditMarketingSource(currentObject) {
        $('.marketing-source-error-div').hide();
        $('#leadSourceEditDiv').dialog('open');
        $('#leadSourceEditDiv').show();

        RemoveClass();

        $('#leadSourceButton').hide();
        $('#marketingSourceButton').show();

        $('#updateForFirstRegistration').show();
        $('#updateForFirstRegistrationChkBox').attr('checked', false);
        $('#updateSignUpMarketingSource').hide();
        $('#leadSourceText').val($.trim($(currentObject).text()));

        var zIndex = $('#leadSourceEditDiv').dialog('option', 'zIndex');

        $('#leadSourceText').autoComplete({
            zindex: zIndex + 2000,
            minchar: 3,
            valueFieldId: "leadSourceId",
            autoChange: true,
            url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetMarketingSourceByPrefixText")%>',
            type: "POST",
            data: "prefixText"
        });

        $('.button-click').unbind('click');
        $('#marketingSourceButton').click(function () {
            if ($.trim($('#leadSourceText').val()) == '' || ($('#leadSourceId').val() != '' || ($.trim($(currentObject).text()) == $.trim($('#leadSourceText').val()) && $.trim($('#leadSourceText').val()) != "N/A"))) {
                var parameter = "{'customerId':'" + $.trim($('.customer-id').text()) + "'";
                parameter += ",'marketingSource':\"" + $.trim($('#leadSourceText').val()) + "\"";
                parameter += ",'isFirstRegistrationUpdateRequired':'" + $('#updateForFirstRegistrationChkBox').attr('checked') + "'}";
                var messageUrl = '<%=ResolveUrl("~/App/Controllers/EventCustomerController.asmx/UpdateCustomerMaketingSource")%>';
                successFunction = function (returnData) {
                    if (returnData.d) {
                        $('#marketingSourceButton').unbind('click');
                        var marketingSource = "N/A";
                        if ($.trim($('#leadSourceText').val()) != '')
                            marketingSource = $.trim($('#leadSourceText').val());
                        $(currentObject).text(marketingSource);
                        if ($('.first-registration').length > 0 && $('#updateForFirstRegistrationChkBox').attr('checked')) {
                            $('.first-registration').find('span').text(marketingSource);
                            $('#updateForFirstRegistrationChkBox').attr('checked', false);
                        }
                    }
                }

                InvokeService(messageUrl, parameter, successFunction)
                $('#leadSourceEditDiv').dialog('close');
                $('#jSuggestContainer').hide();
                $(currentObject).removeClass('anchor');
            }
                //            else if ($.trim($('#leadSourceText').val()) == '') {
                //                $('.marketing-source-error-div').show();
                //                $('.marketing-source-error-div').html("Marketing Source cannot be blank.");
                //                $('#jSuggestContainer').hide();
                //                $(currentObject).removeClass('anchor');
                //            }
            else if ($.trim($('#leadSourceId').val()) == '') {
                $('.marketing-source-error-div').show();
                $('.marketing-source-error-div').html("This marketing source do not exist.");
                $('#jSuggestContainer').hide();
                $(currentObject).removeClass('anchor');
            }
        });
    }

    function EditLeadSource(currentObject) {
        $('.marketing-source-error-div').hide();
        $('#leadSourceEditDiv').dialog('open');

        RemoveClass();

        $('#leadSourceButton').show();
        $('#marketingSourceButton').hide();

        if ($(currentObject).hasClass('first-registration')) {
            $('#updateSignUpMarketingSource').show();
            $('#updateSignUpMarketingSourceChkBox').attr('checked', true);
            $('#updateForFirstRegistration').hide();
            $('#leadSourceText').val($.trim($(currentObject).find('span').text()));
        }
        else {
            $('#updateSignUpMarketingSource').hide();
            $('#updateForFirstRegistration').hide();
            $('#updateForFirstRegistrationChkBox').attr('checked', false);
            $('#leadSourceText').val($.trim($(currentObject).find('span').text()));
        }

        var zIndex = $('#leadSourceEditDiv').dialog('option', 'zIndex');

        $('#leadSourceText').autoComplete({
            zindex: zIndex + 2000,
            minchar: 3,
            valueFieldId: "leadSourceId",
            autoChange: true,
            url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetMarketingSourceByPrefixText")%>',
            type: "POST",
            data: "prefixText"
        });

        $('.button-click').unbind('click');
        $('#leadSourceButton').click(function () {
            if ($.trim($('#leadSourceText').val()) == '' || ($('#leadSourceId').val() != '' || ($.trim($(currentObject).text()) == $.trim($('#leadSourceText').val()) && $.trim($('#leadSourceText').val()) != "N/A"))) {
                var eventCustomerId = $.trim($(currentObject).find('input[type=hidden]').val());
                var isSignUpMarketingSourceRequired = ($(currentObject).hasClass('first-registration') && $('#updateSignUpMarketingSourceChkBox').attr('checked')) ? true : false;
                var parameter = "{'customerId':'" + $.trim($('.customer-id').text()) + "'";
                parameter += ",'eventCustomerId':'" + eventCustomerId + "'";
                parameter += ",'marketingSource':\"" + $.trim($('#leadSourceText').val()) + "\"";
                parameter += ",'isSignUpMarketingSourceRequired':'" + isSignUpMarketingSourceRequired + "'}";
                var messageUrl = '<%=ResolveUrl("~/App/Controllers/EventCustomerController.asmx/UpdateEventCustomerMaketingSource")%>';
                successFunction = function (returnData) {
                    if (returnData.d) {
                        $('#leadSourceButton').unbind('click');
                        var marketingSource = "N/A";
                        if ($.trim($('#leadSourceText').val()) != '')
                            marketingSource = $.trim($('#leadSourceText').val());
                        $(currentObject).find('span').text(marketingSource);
                        if ($(currentObject).hasClass('first-registration') && $('#updateSignUpMarketingSourceChkBox').attr('checked')) {
                            $('.marketing-source-span').text(marketingSource);
                        }
                    }
                }

                InvokeService(messageUrl, parameter, successFunction)
                $('#leadSourceEditDiv').dialog('close');
                $('#jSuggestContainer').hide();
                $(currentObject).removeClass('anchor');
            }
                //            else if ($.trim($('#leadSourceText').val()) == '') {
                //                $('.marketing-source-error-div').show();
                //                $('.marketing-source-error-div').html("Marketing Source cannot be blank.");
                //                $('#jSuggestContainer').hide();
                //                $(currentObject).removeClass('anchor');
                //            }
            else if ($.trim($('#leadSourceId').val()) == '') {
                $('.marketing-source-error-div').show();
                $('.marketing-source-error-div').html("This marketing source do not exist.");
                $('#jSuggestContainer').hide();
                $(currentObject).removeClass('anchor');
            }
        });
    }

    function EditCouponCode(currentObject) {
        $('.coupon-code-error-div').hide();
        $('.coupon-code-invalid-div').hide();
        $('#couponCodeEditDiv').dialog('open');

        RemoveClass();

        if ($.trim($(currentObject).text()) != "-N/A-") {
            var couponCode = $.trim($(currentObject).find('span').text()).split('/');
            if (couponCode && couponCode.length == 2 && couponCode[0]) {
                $('#couponCodeText').val($.trim(couponCode[0]));
            }
        }
        else {
            $('#couponCodeText').val('');
        }

        var zIndex = $('#couponCodeEditDiv').dialog('option', 'zIndex');

        $('#couponCodeText').autoComplete({
            zindex: zIndex + 2000,
            minchar: 3,
            valueFieldId: "couponCodeId",
            autoChange: true,
            url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetCouponsListByPrefixText")%>',
            type: "POST",
            data: "prefixText"
        });

        $('.button-click').unbind('click');
        $('#couponCodeButton').click(function () {
            if ($.trim($('#couponCodeText').val()) != '') {
                $('#couponCodeEditDiv').dialog('close');
                var eventCustomerId = $.trim($(currentObject).find('input[type=hidden]').val());
                var parameter = "{'eventCustomerId':'" + eventCustomerId + "'";
                parameter += ",'sourceCode':'" + $.trim($('#couponCodeText').val()) + "'";
                parameter += ",'userId':'" + '<%= UserId%>' + "'";
                parameter += ",'shellId':'" + '<%= OrganizationId%>' + "'";
                parameter += ",'roleId':'" + '<%= RoleId%>' + "'}";
                var messageUrl = '<%=ResolveUrl("~/App/Controllers/EventCustomerController.asmx/UpdateEventCustomerSourceCode")%>';
                successFunction = function (returnData) {
                    if (returnData.d) {
                        $(currentObject).find('span').text($.trim($('#couponCodeText').val()) + ((couponCode && couponCode.length == 2) ? ' / ' + couponCode[1] : ' / 0.0'));
                        $('#couponCodeButton').unbind('click');
                    }
                    else {
                        $('#couponCodeEditDiv').dialog('open');
                        $('.coupon-code-invalid-div').show();
                        $('.coupon-code-error-div').hide();
                        $('#couponCodeText').val('');
                    }
                }
                //16946
                InvokeService(messageUrl, parameter, successFunction)
                $('#couponCodeEditDiv').dialog('close');
                $('#jSuggestContainer').hide();
                $(currentObject).removeClass('anchor');
            }
            else {
                if ($.trim($('#couponCodeText').val()) == '') {
                    $('.coupon-code-error-div').show();
                    $('.coupon-code-invalid-div').hide();
                }
                $('#jSuggestContainer').hide();
                $(currentObject).removeClass('anchor');
            }
        });
    }

    function AdjustSize(controlId) {
        if ($("#" + controlId).width() != $("#" + controlId).val().length) {
            $("#" + controlId).width('0');
            size = $("#" + controlId).val().length;
            $("#" + controlId).width(size * 6);
        }
    }

    function InvokeService(messageUrl, parameter, successFunction) {
        $('#divloading').show();
        UnBindClickFunction();
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: messageUrl,
            data: parameter,
            success: function (result) {
                successFunction(result);
                $('#divloading').hide();
                BindClickFunction();
            },
            error: function (a, b, c) {
                $('#divloading').hide();
                BindClickFunction();
            }
        });
    }


    function ShowPhysicianToCustomerRestricted() {
        alert("Physician can not be assigned to customer as event has restriction on physician assignment.");
    }
</script>

<script type="text/javascript">
    $(function () {
        $("table#list-view tr:even").addClass("alt-row");
    });

    $('.notes-detail').qtip({
        position: {
            
            viewport: $(window),
            adjust: {
                method: 'shift'
            }

        },
        content: {
            title: "Notes",
            text: function (api) {
                return $(this).parent().find('.notes-div').html();
            }
        }
    });

    $(function () {
        $("tr:not(:has(th))").hover(function () {
            $(this).addClass('row-hover');
        },
            function () {
                $(this).removeClass('row-hover');
            });
    });
</script>
<script type="text/javascript">
    function deleteCustomTags() {
        loadCustomTags();
        $('#customerCustomTagDialogDiv').dialog("open");
        return false;
    }

    function loadCustomTags() {
        var customerId = '<%= CustomerId %>';
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "html", url: "/Sales/CorporateAccount/ManageCustomerTag?customerId=" + customerId, data: '{}',
            success: function(result) {
                $("#customerCustomTagDialogDiv").html(result);
            }, error: function (a, b, c) { }
        });
    }
   
    function DeleteSelectedCustomTags() {
        var checkboxes = $('#customerCustomTagDialogDiv input[type=checkbox]:checked');
        if (checkboxes.length > 0) {
            var answer = confirm("Do you really want to remove tag(s) from customer? If yes, tag(s) will be removed from the customer.");
            if (answer) {

                var customTagIds = new Array();
                var index = 0;
                checkboxes.each(function() {
                    customTagIds[index] = $(this).val();
                    index++;

                });

                if (customTagIds.length > 0) {
                    $.ajax({
                        type: "Post",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        url: "/Sales/CorporateAccount/RemoveCustomerTag",
                        data: "{'tagIds':[" + customTagIds + "]}",
                        success: function(result) {
                            location.reload();
                            $("#customerCustomTagDialogDiv").html('<img src="/App/Images/loading.gif"/>');
                            $('#customerCustomTagDialogDiv').dialog('close');
                        },
                        error: function (a, b, c) {
                            $("#customerCustomTagDialogDiv").html('<img src="/App/Images/loading.gif"/>');
                            $('#customerCustomTagDialogDiv').dialog('close');
                        }
                    });
                } else {
                    $("#customerCustomTagDialogDiv").html('<img src="/App/Images/loading.gif"/>');
                    $('#customerCustomTagDialogDiv').dialog('close');
                }
            }
        } else {
            alert("Please select at least one custom tag.");
        }
        
    }

    $(document).ready(function () {
        
        $('#customerCustomTagDialogDiv').dialog({
            autoOpen: false, width: 300, title: 'Remove Custom Tags', closeOnEscape: true, buttons: {
                'Remove Custom Tags': function () {
                    DeleteSelectedCustomTags();
                }
            }
        });
    });
                   
</script>
<div id="EnableTextingDialogDiv" title="Enable Texting" style="display: none; background: #fff">
    <img src="/App/Images/loading.gif" />
</div>
<script type="text/javascript">
    $(function () {
        $('#EnableTextingDialogDiv').dialog({ autoOpen: false, width: 400, modal: true, resizable: false, draggable: true });
    });
    $(document).ready(function () {
        $(".update-enable-texting-anchor").show();
    });

    function CheckSMSCellPhone() {
        if ($("#chksmsenable").is(':checked')) {
            $("#divPhoneCell").show();
        }
        else { $("#divPhoneCell").hide(); }
    }
    function loadEnableTexting(eventCustomerId) {
        $('#EnableTextingDialogDiv').dialog('open');
        var customerId = '<%= CustomerId %>';
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "html", url: "/Scheduling/EventCustomerList/EnableTexting?eventCustomerId=" + eventCustomerId + '&customerId=' + customerId,
            success: function (result) {
                $("#EnableTextingDialogDiv").html(result);
                CheckSMSCellPhone();
            }, error: function (arg) { alert("Error occured while Getting 'Enable Texting Info'. Please try again!"); }
        });
    }
    $('.info-tip').qtip({       
        content: {
            text: function (api) {
                return $('.hra-questionnaire-help').html();
            }
        },
        style: {
            width: '300px'
        }
    });
</script>

<script type="text/javascript">
    
    function SendConfirmationSms(eventid, customerid) {
        $.ajax({           
            type: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: "/Communication/Notification/SendConfirmationSms?eventId=" + eventid + '&customerId=' + customerid,
            success: function (result) {
                alert(result.message);
            }, error: function (arg) { alert("Error occured while sending confirmation message"); }
        });
    }
    
    function SendReminderSms(eventid, customerid) {
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: "/Communication/Notification/SendReminderSms?eventId=" + eventid + '&customerId=' + customerid,
            success: function (result) {
                alert(result.message);
            }, error: function (arg) { alert("Error occured while sending reminder message"); }
        });
    }

    function confirmAppointment(customerId, eventCustomerId) {
        if (confirm("Are you sure about confirming this appointment?")) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                url: "/Scheduling/EventCustomerList/ConfirmAppointment?customerId=" + customerId + "&eventCustomerId=" + eventCustomerId + "&callId=" + '<%= CallId %>',
                success: function (result) {
                    if (result == true) {
                        alert('Patient confirmation saved successfully.');
                        $("span[id*='spConfirmAppointment']").hide();
                    } else {
                        alert('Error occured while saving appointment confirmation.');
                    }
                },
                error:function() {
                    alert('Error occured while saving appointment confirmation.');
                }
            });
        }
    }
</script>
<div class="saveWaitAnimationnew" style="display:none">
</div>
<div id="ViewMedicationsDialogDiv" title="Medications" style="display: none;
    background: #fff; padding:10px">
    
</div>
<div id="viewPhoneConsentDialogDiv" title="Phone Consent" style="display: none;
    background: #fff; padding:10px">
    <table>
       <tr>
           <td><span class="titletextnowidth_default">Phone (Home):</span> </td>
           <td><span id="spHomePhoneNumber" runat="server" class="normaltextnowidth_default"></span></td>
           <td><span class="titletextnowidth_default">Consent:</span></td>
           <td><span id="spHomePhoneNumberConsent" runat="server" class="normaltextnowidth_default"></span></td>
       </tr>
        <tr>
           <td><span class="titletextnowidth_default">Phone (Cell):</span> </td>
           <td><span id="spCellPhoneNumber" runat="server" class="normaltextnowidth_default"></span></td>
           <td><span class="titletextnowidth_default">Consent:</span></td>
           <td><span id="spCellPhoneNumberConsent" runat="server" class="normaltextnowidth_default"></span></td>
       </tr>
        <tr>
           <td><span class="titletextnowidth_default">Phone (Office):</span> </td>
           <td><span id="spOfficePhoneNumber" runat="server" class="normaltextnowidth_default"></span></td>
           <td><span class="titletextnowidth_default">Consent:</span></td>
           <td><span id="spOfficePhoneNumberConsent" runat="server" class="normaltextnowidth_default"></span></td>
       </tr>
    </table>
</div>

<script>
    function ShowMedications(tag)
    {
        var customerId = '<%= CustomerId %>';
        var serviceDate = $.trim($(tag).closest('tr').find('.serviceDate').text());

        $(".saveWaitAnimationnew").show();
        $.ajax({
            url: '/Medical/Medication/GetMedication',
            type: 'GET',
            cache: false,
            data: { customerId: customerId, serviceDate: serviceDate }
        }).done(function (result) {
            
            $('#ViewMedicationsDialogDiv').html(result);

            $('#ViewMedicationsDialogDiv').dialog('open');
            $(".saveWaitAnimationnew").hide();
        });
        return false;
    }

    $(document).ready(function () {
        $('#ViewMedicationsDialogDiv').dialog({
            autoOpen: false, modal: false, width: 1050, height: 425, top: 600, closeOnEscape: true, buttons: {
                'Save': function () {

                    var medicationNameflag = false;
                    var serviceDateFlag = false;

                    $('#tBodyMedication > tr.medication-row').each(function (index, item) {
                        if ($.trim($(this).find('.medicationName').val()) == '') {
                            $(this).find('.reqiredmark').show();
                            medicationNameflag = true; return false;
                        }
                        if ($.trim($(this).find('.serviceDate').val()) == '') {
                            serviceDateFlag = true; return false;
                        }
                    });

                    if (medicationNameflag) {
                        alert('Please enter medication name.'); return false;
                    }

                    if (serviceDateFlag)
                    { alert('Please enter service date.'); return false; }
                    $(".saveWaitAnimationnew").show();
                    $.ajax({
                        url: '/Medical/Medication/SaveMedication',
                        type: 'POST',
                        data: $('#ViewMedicationsDialogDiv > form').serialize(),
                        success: function (data) {
                            if (data)
                                $('#ViewMedicationsDialogDiv').dialog('close');
                            else
                                alert('some error occurred while saving the data.');

                            $(".saveWaitAnimationnew").hide();
                        },
                        error: function (err) {
                            $(".saveWaitAnimationnew").hide();
                            console.log(JSON.stringify(err));
                            alert('some error occurred while saving the data.');
                        }
                    });
                }
            }
        });

        $('#viewPhoneConsentDialogDiv').dialog({
            autoOpen: false, modal: false, width: 365, height: 150, top: 600, closeOnEscape: true
         });
    });

    function ShowPhoneConsent() {
        $("#viewPhoneConsentDialogDiv").dialog('open');
    }
</script>