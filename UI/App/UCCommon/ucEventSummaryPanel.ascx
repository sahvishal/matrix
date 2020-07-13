<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="App_UCCommon_ucEventSummaryPanel" Codebehind="ucEventSummaryPanel.ascx.cs" %>
<%@ Register src="../UCCommon/JQueryToolkit.ascx" tagname="JQueryToolkit" tagprefix="JQueryControl" %>
<JQueryControl:JQueryToolkit ID="JQueryToolkit1" runat="server" IncludeJQueryUI="true"
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
        color: #aaaaff;}
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
        
        function OpenPopUp(pageUrl)
        {
            tb_show('Confirm Tech Team', pageUrl + '&keepThis=true&TB_iframe=true&width=690&modal=true', false);
        }

        function ClosePopUp()
        {
            parent.top.tb_remove();
        }
        
        function SetPodTeamInfo(returnval)
        {
            document.getElementById('<%= this.sppoddetail.ClientID %>').innerHTML = returnval;
        }  
        
        function SetIsTeamConfigurationLink()
        {
            document.getElementById('<%= this.spIsTeamConfigured.ClientID %>').style.display = 'none';
        }
        
//        function SetPodTeamInfo(returnval, context)
//        {
//            document.getElementById('<%= this.sppoddetail.ClientID %>').innerHTML = returnval;
//        }
//        
//        function onerror(message, context) {
//            alert('An unhandled exception has occurred:\n' + message);
//         }
    </script>

<script type="text/javascript" language="javascript">
    function popupmenu3(choice,wt,ht)
    {
        var winOpts = "toolbar=no,location=no,directories=no,status=no,scrolling=auto,scrollbars=no,menubar=no,resizable=yes,width=" + wt + ",height=" + ht;
        confirmWin = window.open(choice,'theconfirmWin',winOpts);
        
    }
    
    function showPopup(EventID, pdftype)
    {
        popupmenu3('/App/Common/BulkPrintResult.aspx?EventID=' + EventID + '&PDFType=' + pdftype,'320','200');
    }
    function showClinicalForm(key)
    {
        var url='/DigitalDelivery.aspx?key=' + key;
        var winOpts = "toolbar=no,location=no,directories=no,status=no,scrolling=auto,scrollbars=no,menubar=no,resizable=yes,width=800,height=600,titlebar=0";
        confirmWin = window.open(url,'ClinicalForm',winOpts);
    }
</script>

<script type="text/javascript" language="javascript">
    function ShowHipaaRatio(hipaaRatio)
    {
        var hippa=hipaaRatio.split("|");
        //document.getElementById('<%= this.sppoddetail.ClientID %>').innerHTML
        var _spnHippaStatus=document.getElementById('<%= this._spnHippaStatus.ClientID %>');
        if (hippa[0] > 0 || hippa[1] >0)
        {
            var hipaaPercentage = hippa[0] / hippa[1] * 100;
            _spnHippaStatus.innerHTML = hipaaPercentage.toFixed(2) + '% ' + '(' + hippa[0] + '/' + hippa[1] + ')';
        }
        else 
        {
           _spnHippaStatus.innerHTML = '0% (0/0)';
        }
    }
</script>

<div class="w_innerdiv">
    <div class="frow">
        <h1 class="left">Event Customer List </h1>
        <span class="headingright_default">
            <a href="#" runat="server" id="aResultStatus"> Customer Result Status </a>
        </span>
    </div>
     <div class="hr left">
    </div>
    <div class="maindivinnerrow_custlist">
        <span class="orngbold14_default left">Event on <span runat="server"
            id="speventdate"></span> at <span runat="server" id="sphostname"></span></span>
    </div>
    <div class="maindivinnerrow_custlist">
         <span><span runat="server" id="speventloc"></span>&nbsp;[ <a runat="server" id="agmap"
            href="#" target="_blank">Map to Location</a> ] &nbsp;&nbsp; |&nbsp;&nbsp; <span style="color:#666"><b>[Host Contact:
                <span runat="server" id="sphostphone"></span>]</b></span> </span>
                
    </div>
    <div class="maindivinnerrow_custlist">
        <span class="left"> <b>Pods:&nbsp;</b> </span> <span id="sppoddetail" runat="server" class="left"></span>
            <span class="left" style="display:none;">&nbsp;<a id="aConfigureTeam" runat="server" href="#"> Confirm Today’s Tech Team </a> </span>
            <span id="spIsTeamConfigured" runat="server" class="box_etcr" style="display:none"> < Event Team Configuration Required </span>
    </div>
    <div class="maindivinnerrow_custlist">
        <span class="left"> <a href="javascript:DisplayMABoard();"><b>[Medical Advisory Board]</b></a> </span>
        <span class="rgt"> <b> Print: </b> <a id='aPrintBulkResult' runat="server" href='javascript:void(0);'>Results</a> | <a id='aPrintBulkClinicalForm' runat="server" href='javascript:void(0);'>Clinical Form</a>
        </span>
    </div>        
        
        <div runat="server" id="divSummary" class="grayboxtop_custlist">
              <div id="divgrayboxhead" class="greyboxcornr_hdr">
                Event Summary (ID:<span runat="server" id="spBPEventID"></span>)
                </div>
             <div id="divgrayboxbdy" class="greyboxcornr_bdy">
                <p class="lgtgboxrow1_custlist">
                    <span class="titlefixwdth1_custlist">Customers:</span> 
                    <span class="normaltxtnowdth_custlist">
                        Registered:&nbsp;
                        <asp:LinkButton runat="server" ID="lnkBPRegCustomer" CommandName="Customer" CommandArgument="Registered"
                            OnClick="lnkCustomerFilter_Click"></asp:LinkButton>
                        &nbsp;|&nbsp;Actual:&nbsp;<asp:LinkButton runat="server" ID="lnkBPActCustomer" CommandName="Customer"
                            CommandArgument="Actual" OnClick="lnkCustomerFilter_Click"></asp:LinkButton>                        
                        &nbsp;|&nbsp;No Show:&nbsp;<asp:LinkButton runat="server" ID="lnkBPNoshowCustomer"
                            CommandName="Customer" CommandArgument="NoShow" OnClick="lnkCustomerFilter_Click"></asp:LinkButton>
                        &nbsp;|&nbsp;Canceled:&nbsp;<span runat="server" id="spBPCanceledCustomer"></span>
                        &nbsp;|&nbsp;Paid:&nbsp;<asp:LinkButton runat="server" ID="lnkBPPaidCustomer" CommandName="Customer"
                            CommandArgument="Paid" OnClick="lnkCustomerFilter_Click"></asp:LinkButton>
                        &nbsp;|&nbsp;Unpaid:&nbsp;<asp:LinkButton runat="server" ID="lnkBPUnpaidCustomer"
                            CommandName="Customer" CommandArgument="UnPaid" OnClick="lnkCustomerFilter_Click"></asp:LinkButton>
                    </span>
                </p>
                <p class="lgtgboxrow1_custlist" style="display:none;">
                    <span class="titlefixwdth1_custlist">Packages:</span> 
                    <span class="normaltxtnowdth_custlist" runat="server" id="sppackagecountstring" style="width:750px"></span>
                </p>
                <p class="lgtgboxrow1_custlist">
                    <span class="titlefixwdth1_custlist">Tests:</span> 
                    <span class="normaltxtnowdth_custlist" runat="server" id="_testNameSpan" style="width:750px"></span>
                </p>
                <p class="lgtgboxrow1_custlist">
                    <span class="titlefixwdth1_custlist">Revenue:</span> 
                    <span class="normaltxtnowdth_custlist">
                        Total:<b>$<span runat="server" id="spBPTotalPayment"></span></b> &nbsp;|&nbsp;
                        CC:<b>$<span runat="server" id="spBPCardPayment"></span></b>
                            (<asp:LinkButton runat="server" ID="lnkBPCardPaymentCount" CommandName="Payment" CommandArgument="Credit Card" OnClick="lnkCustomerFilter_Click"></asp:LinkButton>)
                            &nbsp;|&nbsp;
                        Checks:<b>$<span runat="server" id="spBPCheckPayment"></span></b>
                            (<asp:LinkButton runat="server" ID="lnkBPCheckPayment" CommandName="Payment" CommandArgument="Check" OnClick="lnkCustomerFilter_Click"></asp:LinkButton>) 
                            &nbsp;|&nbsp;
                        Cash:<b>$<span runat="server" id="spBPCashPayment"></span></b>
                            (<asp:LinkButton runat="server" ID="lnkBPCashPayment" CommandName="Payment" CommandArgument="Cash" OnClick="lnkCustomerFilter_Click"></asp:LinkButton>)
                            &nbsp;|&nbsp;
                        eCheck:<b>$<span runat="server" id="spBPeCheckPayment"></span></b>
                        (<asp:LinkButton runat="server" ID="lnkBPeCheckPayment" CommandName="Payment" CommandArgument="eCheck" OnClick="lnkCustomerFilter_Click"></asp:LinkButton>)
                        &nbsp;|&nbsp;
                        GC:<b>$<span runat="server" id="_spnGcPaymentTotal"></span></b>
                        (<asp:LinkButton runat="server" ID="_lnkGcPaymentCount" CommandName="GiftCertificate" CommandArgument="GiftCertificate" OnClick="lnkCustomerFilter_Click" OnClientClick="alert('Pending functionality.'); return false;"></asp:LinkButton>)

                        &nbsp;|&nbsp;
                        Unpaid:<b>$<span runat="server" id="_spnUnpaidTotal"></span></b>
                        (<asp:LinkButton runat="server" ID="_lnkUnpaidCount" CommandName="Customer" CommandArgument="UnPaidNoShowExcluded" OnClick="lnkCustomerFilter_Click"></asp:LinkButton>)
                                            </span>
                </p>
                <p class="lgtgboxrow1_custlist">
                <span class="titlefixwdth1_custlist">Metrics:</span> <span class="normaltxtnowdth_custlist" style="width:800px;">
                    Phone:<b>$<span runat="server" id="spPhoneCount"></span></b> (<asp:LinkButton runat="server"
                        ID="lnkPhoneCount" CommandName="Metrics" CommandArgument="Phone" OnClientClick="alert('Pending functionality.'); return false;"
                        OnClick="lnkCustomerFilter_Click"></asp:LinkButton>) &nbsp;|&nbsp;INet:<b>$<span
                            runat="server" id="spINetCount"></span></b> (<asp:LinkButton runat="server" ID="lnkInetCount"
                                CommandName="Metrics" CommandArgument="Inet" OnClientClick="alert('Pending functionality.'); return false;"
                                OnClick="lnkCustomerFilter_Click"></asp:LinkButton>) &nbsp;|&nbsp;Onsite:<b>$<span
                                    runat="server" id="spOnsiteCount"></span></b> (<asp:LinkButton runat="server" ID="lnkOnsiteCount"
                                        CommandName="Metrics" CommandArgument="Onsite" OnClientClick="alert('Pending functionality.'); return false;"
                                        OnClick="lnkCustomerFilter_Click"></asp:LinkButton>) &nbsp;|&nbsp;Upgrades:<b>$<span
                                            runat="server" id="spUpgradeCount"></span></b> (<asp:LinkButton runat="server" ID="lnkUpgradeCount"
                                                CommandName="Metrics" CommandArgument="Upgrade" OnClientClick="alert('Pending functionality.'); return false;"
                                                OnClick="lnkCustomerFilter_Click"></asp:LinkButton>)
                    &nbsp;|&nbsp;Downgrades:<b>$<span runat="server" id="spDowngradeCount"></span></b>
                    (<asp:LinkButton runat="server" ID="lnkDowngradeCount" CommandName="Metrics" CommandArgument="Downgrade"
                        OnClientClick="alert('Pending functionality.'); return false;" OnClick="lnkCustomerFilter_Click"></asp:LinkButton>)
                    &nbsp;|&nbsp; Average Revenue / Client:<b>$<span runat="server" id="_spnAverageRevenueAmount"></span></b>
                    (<asp:LinkButton runat="server" ID="_lnkAverageCustomers" class="jtip" title='Average Revenue |Average Revenue / Client Excludes the NoShow and Free (100% discounted) Customers.'
                        CommandName="Metrics" CommandArgument="AverageCustomers" OnClientClick="alert('Pending functionality.'); return false;"
                        OnClick="lnkCustomerFilter_Click"></asp:LinkButton>)&nbsp;&nbsp; |&nbsp;&nbsp;
                <span><b>HIPAA&nbsp;=&nbsp;</b></span>
           <span runat="server" id="_spnHippaStatus"> (XX)</span>
                </span>
            </p>
                <p class="lgtgboxrow1_custlist">
                    <span class="titlefixwdth1_custlist">Deposits to EIP:</span> <span class="normaltxtnowdth_custlist">
                        <b>$<span runat="server" id="spBPEIPDeposit"> </span></b>(Cash and Checks)</span>
                </p>
            </div>
        </div>
        <div class="btnrow">
            <span class="orngbold14_default" style="float: left">Customer List </span><span class="smalltxtlnk_hd">
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
</div>
