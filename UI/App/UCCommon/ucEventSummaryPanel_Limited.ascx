<%@ Control Language="C#" AutoEventWireup="true" Inherits="App_UCCommon_ucEventSummaryPanel_Limited"
    CodeBehind="ucEventSummaryPanel_Limited.ascx.cs" %>
<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>
<%@ Register Src="../UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" TagPrefix="JQueryControl" %>
<JQueryControl:JQueryToolkit ID="_JQueryToolkit" runat="server" IncludeJQueryUI="true"
    IncludeJTemplate="true" IncludeJQueryThickBox="true" IncudeJQueryJTip="true"
    IncludeJQueryCorner="true" />
<style type="text/css">
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
<script language="javascript" type="text/javascript">
    function OpenPopUp(pageUrl) {
        tb_show('Confirm Tech Team', pageUrl + '&keepThis=true&TB_iframe=true&width=690&modal=true', false);
    }

    function ClosePopUp() {
        parent.top.tb_remove();
        window.location = window.location;
    }

    function SetPodTeamInfo(returnval) {
        document.getElementById('<%= this.sppoddetail.ClientID %>').innerHTML = returnval;
        $('.jtipLocal').cluetip({ splitTitle: '|', cursor: 'pointer', tracking: true, cluetipClass: 'jtip', arrows: true, dropShadow: false, hoverIntent: false, width: 330 });
    }

    function SetIsTeamConfigurationLink() {
        document.getElementById('<%= this.spIsTeamConfigured.ClientID %>').style.display = 'none';
    }
                
        
</script>
<script language="javascript" type="text/javascript">
    /***********************************************
    * Image w/ description tooltip- By Dynamic Web Coding (www.dyn-web.com)
    * Copyright 2002-2007 by Sharon Paine
    * Visit Dynamic Drive at http://www.dynamicdrive.com/ for full source code
    ***********************************************/

    /* IMPORTANT: Put script after tooltip div or 
    put tooltip div just before </BODY>. */

    var dom = (document.getElementById) ? true : false;
    var ns5 = (!document.all && dom || window.opera) ? true : false;
    var ie5 = ((navigator.userAgent.indexOf("MSIE") > -1) && dom) ? true : false;
    var ie4 = (document.all && !dom) ? true : false;
    var nodyn = (!ns5 && !ie4 && !ie5 && !dom) ? true : false;

    var origWidth, origHeight;

    // avoid error of passing event object in older browsers
    if (nodyn) { event = "nope" }

    ///////////////////////  CUSTOMIZE HERE   ////////////////////
    // settings for tooltip 
    // Do you want tip to move when mouse moves over link?
    var tipFollowMouse = true;
    // Be sure to set tipWidth wide enough for widest image
    var tipWidth = 695;
    var offX = 20; // how far from mouse to show tip
    var offY = 12;
    var tipFontFamily = "Verdana, arial, helvetica, sans-serif";
    var tipFontSize = "8pt";
    // set default text color and background color for tooltip here
    // individual tooltips can have their own (set in messages arrays)
    // but don't have to
    var tipFontColor = "#000000";
    var tipBgColor = "#CEE1F4";
    var tipBorderColor = "#ccc";
    var tipBorderWidth = 1;
    var tipBorderStyle = "solid";
    var tipPadding = 0;


    // to layout image and text, 2-row table, image centered in top cell
    // these go in var tip in doTooltip function
    // startStr goes before image, midStr goes between image and text
    var startStr = '<table width="' + tipWidth + '"><th> <span style="float: left; font-size: 14px; padding: 3px 0px 0px 5px;"><b>Event Notes </b></span><span style="float: right;"><img src="/App/Images/close-button-symbol.gif" onclick="hideTip();" />';
    startStr = startStr + '</span> </th><tr><td align="center" width="100%"><div style="float: left; width: 690px;">';
    var midStr = ' </div></td></tr><tr><td valign="top">';
    var endStr = '</td></tr></table>';

    ////////////////////////////////////////////////////////////
    //  initTip	- initialization for tooltip.
    //		Global variables for tooltip. 
    //		Set styles
    //		Set up mousemove capture if tipFollowMouse set true.
    ////////////////////////////////////////////////////////////
    var tooltip, tipcss;
    function initTip() {
        if (nodyn) return;
        tooltip = (ie4) ? document.all['tipDiv'] : (ie5 || ns5) ? document.getElementById('tipDiv') : null;
        tipcss = tooltip.style;
        if (ie4 || ie5 || ns5) {	// ns4 would lose all this on rewrites
            tipcss.width = tipWidth + "px";
            tipcss.fontFamily = tipFontFamily;
            tipcss.fontSize = tipFontSize;
            tipcss.color = tipFontColor;
            tipcss.backgroundColor = tipBgColor;
            tipcss.borderColor = tipBorderColor;
            tipcss.borderWidth = tipBorderWidth + "px";
            tipcss.padding = tipPadding + "px";
            tipcss.borderStyle = tipBorderStyle;
        }
        if (tooltip && tipFollowMouse) {
            document.onmousemove = trackMouse;
        }
    }



    /////////////////////////////////////////////////
    //  doTooltip function
    //			Assembles content for tooltip and writes 
    //			it to tipDiv
    /////////////////////////////////////////////////
    var t1, t2; // for setTimeouts
    var tipOn = false; // check if over tooltip link
    //    function doTooltip(evt) 
    //    {
    //        
    //        initTip();
    //	    if (!tooltip) return;
    //	    if (t1) clearTimeout(t1);	if (t2) clearTimeout(t2);
    //	    tipOn = true;
    //	    
    //	    if (ie4||ie5||ns5) {
    //		    var tip = startStr + document.getElementById('divnotes').innerHTML + midStr; //+ '<span style="font-family:' + tipFontFamily + '; font-size:' + tipFontSize + '; color:' + curFontColor + ';">' + messages[num][1] + '</span>' + endStr;
    //		    tipcss.backgroundColor = "#CEE1F4";
    //	 	    tooltip.innerHTML = tip;
    //	    }
    //	    if (!tipFollowMouse) positionTip(evt);
    //	    else t1=setTimeout("tipcss.visibility='visible'; tipcss.display='block';",100);
    //    }

    //<span style="float: left; padding-left:50px;"><a href="javascript:void(0);" onclick="printNotes();";>Print</a></span>
    function printNotes() {//debugger
        if (ie4 || ie5 || ns5) {

            var txtEventNotes = document.getElementById("<%=this.txtEventNotes.ClientID %>");
            var txtnotesdup = document.getElementById("txtnotesdup");
            txtnotesdup.value = txtEventNotes.value;

            var divnotesdup = document.getElementById('divnotesdup');

            var printContent = divnotesdup.innerHTML;
            tipcss.backgroundColor = "#CEE1F4";
            var WinPrint = window.open('', '', 'left=0,top=0,width=1,height=1,toolbar=0,scrollbars=0,status=0');
            WinPrint.document.write(printContent);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();

            return false;
        }
    }
    var mouseX, mouseY;
    function trackMouse(evt) {
        standardbody = (document.compatMode == "CSS1Compat") ? document.documentElement : document.body //create reference to common "body" across doctypes
        mouseX = (ns5) ? evt.pageX : window.event.clientX + standardbody.scrollLeft;
        mouseY = (ns5) ? evt.pageY : window.event.clientY + standardbody.scrollTop;
        if (tipOn) positionTip(evt);
    }

    /////////////////////////////////////////////////////////////
    //  positionTip function
    //		If tipFollowMouse set false, so trackMouse function
    //		not being used, get position of mouseover event.
    //		Calculations use mouseover event position, 
    //		offset amounts and tooltip width to position
    //		tooltip within window.
    /////////////////////////////////////////////////////////////
    function positionTip(evt) {
        //debugger

        var screenwidth = "";
        var screenheight = "";

        var Imgtop, ImgLeft;
        var screenleft, screentop;

        screenwidth = document.body.offsetWidth;
        screentop = document.body.parentNode.scrollTop;


        ImgLeft = (Number(screenwidth) - 700);
        Imgtop = screentop; //((Number(screenheight) - 480)/2) + screentop;

        tipcss.left = ImgLeft + "px";
        tipcss.top = Imgtop + "px";

        if (!tipFollowMouse) t1 = setTimeout("tipcss.visibility='visible'; tipcss.display='block';", 100);
    }

    function hideTip() {
        if (!tooltip) return;
        t2 = setTimeout("tipcss.visibility='hidden'; tipcss.display='none'; ", 100);
        tipOn = false;
    }

    document.write('<div id="tipDiv" style="position:absolute; display:none; visibility:hidden; z-index:100"></div>')

    function popupmenu2(choice, wt, ht) {
        var winOpts = "toolbar=no,location=no,directories=no,status=no,scrolling=auto,scrollbars=yes,menubar=no,width=" + wt + ",height=" + ht;
        confirmWin = window.open(choice, 'theconfirmWin', winOpts);
    }
    function popupmenu3(choice, wt, ht) {
        var winOpts = "toolbar=no,location=no,directories=no,status=no,scrolling=auto,scrollbars=yes,menubar=no,width=" + wt + ",height=" + ht;
        confirmWin = window.open(choice, 'theconfirmWin', winOpts);
    }
    function popupmenu4(choice, wt, ht) {
        var winOpts = "toolbar=no,location=no,resizable=no,directories=no,status=no,scrolling=auto,scrollbars=yes,menubar=no,width=" + wt + ",height=" + ht;
        confirmWin = window.open(choice, 'theconfirmWin', winOpts);
    }
</script>
<script type="text/javascript" language="javascript">
    function popupmenu3(choice, wt, ht) {
        var winOpts = "toolbar=no,location=no,directories=no,status=no,scrolling=auto,scrollbars=no,menubar=no,resizable=yes,width=" + wt + ",height=" + ht;
        confirmWin = window.open(choice, 'theconfirmWin', winOpts);

    }

    function showPopup(EventID) {
        popupmenu3('/App/Common/BulkPrintResult.aspx?EventID=' + EventID, '320', '200');
    }
    function ShowDialog() {
        $('#divnotes').dialog('open');
    }
    function showClinicalForm(key) {
        var url = '/DigitalDelivery.aspx?key=' + key;
        var winOpts = "toolbar=no,location=no,directories=no,status=no,scrolling=auto,scrollbars=no,menubar=no,resizable=yes,width=800,height=600,titlebar=0";
        confirmWin = window.open(url, 'ClinicalForm', winOpts);
    }
    
</script>
<script type="text/javascript" language="javascript">
    function ShowHipaaRatio(hipaaRatio) {
        //var hippa=hipaaRatio.split("|");
        //document.getElementById('<%= this.sppoddetail.ClientID %>').innerHTML
        var _spnHippaStatus = document.getElementById('<%= this._spnHippaStatus.ClientID %>');
        if (hipaaRatio[0] > 0 || hipaaRatio[1] > 0) {
            var hipaaPercentage = hipaaRatio[0] / hipaaRatio[1] * 100;
            _spnHippaStatus.innerHTML = hipaaPercentage.toFixed(2) + '% ' + '(' + hipaaRatio[0] + '/' + hipaaRatio[1] + ')';
        }
        else {
            _spnHippaStatus.innerHTML = '0% (0/0)';
        }
    }
    function SetSlotDropDown(selectedText) {

        var optVal = $("#<%= ddlfiltergrid.ClientID %> option:contains('" + selectedText + "')").attr('value');

        $('#<%= ddlfiltergrid.ClientID %>').val(optVal);
    }
    
</script>
<div class="w_innerdiv">
    <div class="frow">
        <h1 class="left">
            Event Customer List
        </h1>
        <span class="lnkeod" runat="server" id="spEndofDay">
        <% if (IoC.Resolve<ISettings>().ShowPartnerRelease)
           {%>
        <a href="" id="aEndOfDay" runat="server">
            End Of Day </a>
            <% } %></span>
        
        <span class="headingright_default" id="spRegisterCustomer" runat="server">  
                    
            <a runat="server" id="updateHostRankingAnchor" href='#'>Update Host Ranking </a>| 
            <span id="spResultStatus" runat="server">
                <a href="#" runat="server" id="aResultStatus"> Customer Result Status</a> | 
            </span>
            <a id="aDepositeSlip" runat="server" href="javascript:popupmenu3('/App/Franchisee/Technician/GenerateDepositeSlip.aspx',370,500)">Deposit Slip</a> | 
            <a id="aExistingCustomer" runat="server" href=''>Register Walk-In</a> 
            
        </span>
    </div>
    <div class="hr left">
    </div>
    <div class="maindivinnerrow_custlist">
        <span class="orngbold14_default left">Event on <span runat="server" id="speventdate">
        </span>at <span runat="server" id="sphostname"></span></span>
    </div>
    <div class="maindivinnerrow_custlist">
        <span><span runat="server" id="speventloc"></span>&nbsp;[ <a runat="server" id="agmap"
            href="#" target="_blank">Map to Location</a> ] &nbsp;<span id="_addressVerifiedStatus"
                runat="server"><font size="1px"></font></span> | &nbsp;&nbsp;<span style="color: #666"><b>[Host
                    Contact: <span runat="server" id="sphostphone"></span>]</b></span> </span>
    </div>
    <div class="maindivinnerrow_custlist">
        <span class="left"><b>Pods:&nbsp;</b> </span><span id="sppoddetail" runat="server"
            class="left"></span><span class="box_etcr" id="spIsTeamConfigured" runat="server"
                style="display: none">Event Team Configuration Required </span>
    </div>
    <div class="maindivinnerrow_custlist">
        <span class="left" style="width: 90px;"><b>Facility Details:&nbsp;</b> </span><span
            class="left" style="width: 850px;"><span>Plug Points:</span><span id="spPlugPoints"
                runat="server"></span>&nbsp;|&nbsp; <span>Room Size:</span><span id="spRoomSize"
                    runat="server"></span>&nbsp;|&nbsp; <span>Host Ranking:</span><span id="spHostRanking"
                        runat="server"></span>&nbsp;|&nbsp; <span>Internet Access:</span><span id="spInternetAccess"
                            runat="server"></span>&nbsp;|&nbsp; <span>Need to Clear Room?:</span><span id="spRoomNeedCleared"
                                runat="server"></span> </span>
    </div>
    <div class="maindivinnerrow_custlist">
        <span class="lnk_prntr" style="display: none"><a id='aPrintBulkResult' runat="server"
            href='javascript:void(0);'>Print Results</a> </span>
    </div>
    <div runat="server" id="divSummaryTech" class="grayboxtop_custlist">
        <div id="divgrayboxhead" class="greyboxcornr_hdr">
            <div class="left">
                Event Summary (ID:<span runat="server" id="speventid"></span>)</div>
            <div class="rgt">
                <a href="#" onclick="ShowDialog();" class="jtip" title='Concerned Sales Rep |<b><span class="smallttextnowidth_default" runat="server" id="spnSalesrepname"></span></b> (<i><span class="smallntextnowidth_default" runat="server" id="spnContactInfo"></span></i>)<br /> <span class="left graysmalltxt_default"><i>Note:Please click on the link "View <%=RoleDisplayName%> Comments" to view the Notes </i></span>'
                    style="font-weight: normal">View
                    <%=RoleDisplayName%>
                    Comments</a>
            </div>
            <div class="rgt" style="padding-right:10px;">
                <a href="javascript:$('#emr-notes-dialog').dialog('open'); void(0);">EMR Notes </a>
                <script type="text/javascript" language="javascript">

                    function saveEmrNotes() {
                        $(".emr-notes-buttons").toggle();
                        var eventId = Number('<%= Session["EventID"] %>');
                        if (eventId > 0) {
                            $.ajax({
                                type: "POST",
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                url: "/App/Controllers/EventCustomerController.asmx/SaveNotes",
                                data: "{'eventId' : '" + eventId + "', 'text' : '" + $("#emr-notes").val().replace(/'/gi, "\\\'").replace(/"/gi, "\\\"") + "'}",
                                success: function (result) {
                                    alert("Updated!");
                                    $(".emr-notes-buttons").toggle();
                                    $('#emr-notes-dialog').dialog('close');
                                },
                                error: function (a, b, c) {
                                    alert("Some error occured while saving EMR Notes! \nPlease try again or contact the support team!");
                                    $(".emr-notes-buttons").toggle();
                                    $('#emr-notes-dialog').dialog('close');
                                }
                            });
                        }
                    }

                </script>
            </div>
        </div>
        <div id="divgrayboxbdy" class="greyboxcornr_bdy">
            <div class="lgtgboxrow1_custlist">
                <span class="titletext_default">Customers:</span> <span class="normaltxtnowdth_custlist">
                    Registered:&nbsp;
                    <asp:LinkButton runat="server" ID="ancregistered" CommandName="Customer" CommandArgument="Registered"
                        OnClick="lnkCustomerFilter_Click"></asp:LinkButton>
                    &nbsp;|&nbsp;Actual:&nbsp;<asp:LinkButton runat="server" ID="ancactual" CommandName="Customer"
                        CommandArgument="Actual" OnClick="lnkCustomerFilter_Click"></asp:LinkButton>
                    &nbsp;|&nbsp;No Show:&nbsp;<asp:LinkButton runat="server" ID="ancnoshow" CommandName="Customer"
                        CommandArgument="NoShow" OnClick="lnkCustomerFilter_Click"></asp:LinkButton>
                    &nbsp;|&nbsp;Canceled:&nbsp;<span runat="server" id="spncancelled"></span> &nbsp;|&nbsp;Paid:&nbsp;<asp:LinkButton
                        runat="server" ID="ancpaid" CommandName="Customer" CommandArgument="Paid" OnClick="lnkCustomerFilter_Click"></asp:LinkButton>
                    &nbsp;|&nbsp;Unpaid:&nbsp;<asp:LinkButton runat="server" ID="ancunpaid" CommandName="Customer"
                        CommandArgument="UnPaid" OnClick="lnkCustomerFilter_Click"></asp:LinkButton>
                </span>
            </div>
            <div class="lgtgboxrow1_custlist">
                <span class="titletext_default">Revenue:</span> <span class="normaltxtnowdth_custlist">
                    Total:<b>$<span runat="server" id="sptotalpayment"></span></b> &nbsp;|&nbsp; CC:<b>$<span
                        runat="server" id="spcardpayment"></span></b> (<asp:LinkButton runat="server" ID="anccardpaymentcount"
                            CommandName="Payment" CommandArgument="Credit Card" OnClick="lnkCustomerFilter_Click"></asp:LinkButton>)
                    &nbsp;|&nbsp; Checks:<b>$<span runat="server" id="spchequepayment"></span></b> (<asp:LinkButton
                        runat="server" ID="ancchequepaymentcount" CommandName="Payment" CommandArgument="Check"
                        OnClick="lnkCustomerFilter_Click"></asp:LinkButton>) &nbsp;|&nbsp;Cash:<b>$<span
                            runat="server" id="spcashpayment"></span></b> (<asp:LinkButton runat="server" ID="anccashpaymentcount"
                                CommandName="Payment" CommandArgument="Cash" OnClick="lnkCustomerFilter_Click"></asp:LinkButton>)
                    &nbsp; eCheck:<b>$<span runat="server" id="spBPeCheckPayment"></span></b> (<asp:LinkButton
                        runat="server" ID="lnkBPeCheckPayment" CommandName="Payment" CommandArgument="eCheck"
                        OnClick="lnkCustomerFilter_Click"></asp:LinkButton>) &nbsp;|&nbsp;GC:<b>$<span runat="server"
                            id="_spnGcPaymentTotal"></span></b> (<asp:LinkButton runat="server" ID="_lnkGcPaymentCount"
                                CommandName="GiftCertificate" CommandArgument="GiftCertificate" OnClick="lnkCustomerFilter_Click"
                                OnClientClick="alert('Pending functionality.'); return false;"></asp:LinkButton>)
                    &nbsp;|&nbsp; Unpaid:<b>$<span runat="server" id="_spnUnpaidTotal"></span></b> (<asp:LinkButton
                        runat="server" ID="_lnkUnpaidCount" CommandName="Customer" CommandArgument="UnPaidNoShowExcluded"
                        OnClick="lnkCustomerFilter_Click"></asp:LinkButton>) </span>
            </div>
            <div class="lgtgboxrow1_custlist" style="display: none;">
                <span class="titletext_default">Packages:</span> <span class="normaltxtnowdth_custlist"
                    runat="server" id="sppackagecountstring" style="width: 750px"></span>
            </div>
            <div class="lgtgboxrow1_custlist">
                <span class="titletext_default">Tests:</span> <span class="normaltxtnowdth_custlist"
                    runat="server" id="_testNameSpan" style="width: 750px"></span>
            </div>
            <div class="lgtgboxrow1_custlist">
                <span class="titletext_default">Metrics:</span> <span class="normaltxtnowdth_custlist">
                    Onsite:<b>$<span runat="server" id="spOnsiteCount"></span></b> (<asp:LinkButton runat="server"
                        ID="lnkOnsiteCount" CommandName="Metrics" CommandArgument="Onsite" OnClientClick="alert('Pending functionality.'); return false;"
                        OnClick="lnkCustomerFilter_Click"></asp:LinkButton>)&nbsp;|&nbsp; Upgrades:<b>$<span
                            runat="server" id="spUpgradeCount"></span></b> (<asp:LinkButton runat="server" ID="lnkUpgradeCount"
                                CommandName="Metrics" CommandArgument="Upgrade" OnClientClick="alert('Pending functionality.'); return false;"
                                OnClick="lnkCustomerFilter_Click"></asp:LinkButton>)&nbsp;|&nbsp;Downgrades:<b>$<span
                                    runat="server" id="spDowngradeCount"></span></b> (<asp:LinkButton runat="server"
                                        ID="lnkDowngradeCount" CommandName="Metrics" CommandArgument="Downgrade" OnClientClick="alert('Pending functionality.'); return false;"
                                        OnClick="lnkCustomerFilter_Click"></asp:LinkButton>) &nbsp;|&nbsp;Average
                    Revenue / Client:<b>$<span runat="server" id="_spnAverageRevenueCount"></span></b>
                    (<asp:LinkButton runat="server" ID="_lnkAverageCustomers" class="jtip" title='Average Revenue |Average Revenue / Client Excludes the NoShow and Free (100% discounted) Customers.'
                        CommandName="Metrics" CommandArgument="AverageCustomers" OnClientClick="alert('Pending functionality.'); return false;"
                        OnClick="lnkCustomerFilter_Click"></asp:LinkButton>) &nbsp;|&nbsp;<span><b>HIPAA&nbsp;=&nbsp;</b></span>
                    <span runat="server" id="_spnHippaStatus">(XX)</span> </span>
            </div>
            <div class="lgtgboxrow1_custlist">
                <span class="titletext_default">Deposits:</span> <span class="normaltxtnowdth_custlist">
                    <b>$<span runat="server" id="spEIPdeposit"> </span></b>(Cash and Checks)</span>
            </div>
        </div>
    </div>
    <div class="btnrow" style="height: 27px;">
        <span class="left">
            <img src="/App/Images/customerlist-tab-on.gif" id="imgCustomerList" onclick="showCustomers();"
                alt="" />
            <img src="/App/Images/cancelledcustomer-tab-off.gif" id="imgCancelledCustomers" onclick="showCancelledCustomers();"
                style="cursor: pointer;" alt="" />
        </span><span class="smalltxtlnk_hd">
            <asp:DropDownList ID="ddlfiltergrid" runat="server" CssClass="inputf_def" Width="110px"
                AutoPostBack="True" OnSelectedIndexChanged="ddlfiltergrid_SelectedIndexChanged">
                <asp:ListItem Value="All">All</asp:ListItem>
                <asp:ListItem Value="Open">Open</asp:ListItem>
                <asp:ListItem Value="Filled" Selected="True">Filled</asp:ListItem>
                <asp:ListItem Value="Blocked">Blocked</asp:ListItem>
            </asp:DropDownList>
        </span><span class="smalltxtlnk_hd" style="padding-top: 5px;"><b>Slots:&nbsp;&nbsp;</b></span>
        <span class="smalltxtlnk_hd" style="padding: 4px 6px 0 0"><a href="javascript:void(0);"
            runat="server" id="ancopenpopupaddslot" class="thickbox">Add slot </a>&nbsp;|</span>
    </div>
    <div style="float: left; width: 690px; display: none; overflow: hidden" id="divnotes"
        title="Notes">
        <asp:TextBox ID="txtEventNotes" TextMode="MultiLine" Rows="27" ReadOnly="true" runat="server"
            Width="684px" CssClass="inputf_def"></asp:TextBox>
    </div>
</div>
<div id="PodDetailDiv" runat="server" enableviewstate="false" style="display: none">
</div>
<div id="emr-notes-dialog" class="jdbox">
    <div>
        <textarea id="emr-notes" rows="5" cols="50"> <%= EmrNotes %>  </textarea>
    </div>
    <div class="emr-notes-buttons" style="text-align: right;">
        <button id="save-emr-notes" style="width: 70px; height: 25px;" onclick="saveEmrNotes(); return false;">
            Save
        </button>
    </div>
    <div class="emr-notes-buttons" style="display: none; text-align: right;">
        <img src="/App/Images/loading.gif" alt="" />
        Updating
    </div>
</div>
<style type="text/css">
    .jdbox
    {
        float: left;
        width: 450px;
        margin-top: 5px;
    }
    
    .jdbox div
    {
        float: left;
        width: 450px;
        margin-top: 3px;
    }
    .jdbox textarea
    {
        width: 445px;
    }
</style>
<script language="javascript" type="text/javascript">
    $(document).ready(function () {
        $('#emr-notes-dialog').dialog({ width: 480, autoOpen: false, title: 'EMR Notes', resizable: false, draggable: true });
    });

</script>
