<%@ Control Language="C#" AutoEventWireup="true" Inherits="App_CallCenter_CallCenterRep_UcleftpanelCCrepNew"
    CodeBehind="UcleftpanelCCrepNew.ascx.cs" %>
<script language="javascript" type="text/javascript">

    var pnlhgt;
    var heightlimit;
    var curtabopen;

    function CallExpandTab(divid, imgopen, imgdown) {

        if (document.getElementById(divid).style.height != '0px')
            return;

        pnlhgt = 0;
        CollapseAllTab();

        document.getElementById(imgopen).style.visibility = 'visible';
        document.getElementById(imgdown).style.visibility = 'hidden';

        document.getElementById(imgopen).style.display = 'block';
        document.getElementById(imgdown).style.display = 'none';

        heightlimit = 120;
        document.getElementById(divid).style.height = "0px";

        curtabopen = divid;
        ExpandLeftTab();
    }

    function ExpandLeftTab() {

        pnlhgt = pnlhgt + 1;
        document.getElementById('' + curtabopen + '').style.height = pnlhgt + 'px';
        delaypanel();
    }

    function CollapseAllTab() {
        document.getElementById('divkpiweek').style.height = "0px";
        document.getElementById('divkpimonth').style.height = "0px";
        document.getElementById('divkpiyear').style.height = "0px";
        document.getElementById('divkpilife').style.height = "0px";
        document.getElementById('divsearchleft').style.height = "0px";

        document.getElementById('imgwopen').style.visibility = "hidden";
        document.getElementById('imgmopen').style.visibility = "hidden";
        document.getElementById('imgyopen').style.visibility = "hidden";
        document.getElementById('imglopen').style.visibility = "hidden";
        document.getElementById('imgsopen').style.visibility = "hidden";

        document.getElementById('imgwopen').style.display = "none";
        document.getElementById('imgmopen').style.display = "none";
        document.getElementById('imgyopen').style.display = "none";
        document.getElementById('imglopen').style.display = "none";
        document.getElementById('imgsopen').style.display = "none";

        document.getElementById('imgwdown').style.visibility = "visible";
        document.getElementById('imgmdown').style.visibility = "visible";
        document.getElementById('imgydown').style.visibility = "visible";
        document.getElementById('imgldown').style.visibility = "visible";
        document.getElementById('imgsdown').style.visibility = "visible";

        document.getElementById('imgwdown').style.display = "block";
        document.getElementById('imgmdown').style.display = "block";
        document.getElementById('imgydown').style.display = "block";
        document.getElementById('imgldown').style.display = "block";
        document.getElementById('imgsdown').style.display = "block";

    }

    function delaypanel() {
        if (pnlhgt < heightlimit)
            setTimeout('ExpandLeftTab()', 2);
    }


    function NextBuild() {
        alert('Please check this in next release');
        return false;
    }


</script>
<style type="text/css">
    .grdLinks_leftpanel
    {
        float: left;
        width: 100%;
    }
    .leftsearchboxbg_leftpanel
    {
        background: url(/App/images/left-searchboxbg.gif) repeat-x;
        background-position: bottom;
    }
    .leftnavlnkbg_leftpanel
    {
        float: left;
        width: 182px;
        height: 29px;
        background: url(/App/images/left-nav-bg.gif) repeat-x;
    }
    .leftnavarrow_leftpanel
    {
        float: left;
        width: 17px;
        height: 12px;
        padding: 9px 5px 0px 5px;
    }
    .leftnavtxt_leftpanel
    {
        float: left;
        width: 140px;
        padding-top: 8px;
        text-overflow: ellipsis;
        overflow: hidden;
        white-space: nowrap;
    }
    .leftnavtxt_leftpanel a:link
    {
        text-decoration: none;
    }
    .leftnavtxt_leftpanel a:visited
    {
        text-decoration: none;
    }
    .leftnavtxt_leftpanel a:hover
    {
        text-decoration: none;
    }
</style>
<div class="wrapper_leftnpad">
    <div class="leftheader">
        <div>
            Quick Nav</div>
    </div>
    <div class="lftpnlbox">
        <div class="leftnav">
            <img src="/App/Images/left-nav-arrow.gif" alt="" />
            <a id="aCustomerList" href="/App/CallCenter/CallCenterRep/CallCenterRepCustomerList.aspx?Call=No">
                Off Call Customer Service</a>
        </div>
         <div class="leftnav">
            <img src="/App/Images/left-nav-arrow.gif" alt="" />
            <a href="/Scheduling/Event/Index?showUpcoming=true">
                Off Call Event Service</a>
        </div>
    </div>
    <div class="leftheader">
        <div>
            Today's Stat</div>
    </div>
    <div class="lftpnlboxbg">
        <div class="hrow">
            <label>
                Total Calls Today:</label>
            <span class="valuebox_ccrep" runat="server" id="spTotal"></span>
        </div>
        <div class="hrow">
            <label>
                Avg. Call Duration:</label>
            <span class="valuebox_ccrep" runat="server" id="spAvg"></span>
        </div>
        <div class="hrow">
            <label>
                Max Call Duration:</label>
            <span class="valuebox_ccrep" runat="server" id="spMax"></span>
        </div>
        <div class="hrow">
            <label>
                Min Call Duration:</label>
            <span class="valuebox_ccrep" runat="server" id="spMin"></span>
        </div>
        <div class="hrow">
            <span class="rgt"><a href="/App/CallCenter/CallCenterRep/Metrics.aspx">
                <img src="/App/Images/CCRep/viewallstat-btn.gif" /></a></span>
        </div>
        <div class="normaltxtleft_inner" style="height: 66px; display: none;">
            <%--<a href="CallCenterRepCustomerList.aspx">Customer List </a>--%>
            <a id="aSearchCustomer" runat="server" href='/App/CallCenter/CallCenterRep/CallCenterRepCustomerList.aspx?Type=ExistingCustomer&Call=No'>
                Search Customer </a>
        </div>
        <div style="display: none">
            <ul class="ccrlpanellnktxt">
                <li><a href="#">ABCD</a></li>
                <li>ABCD</li>
                <li>ABCD</li>
            </ul>
            <div class="leftcontainerbdrn_inner">
                <p class="headtxtnotifc_inner">
                    Notification</p>
                <p class="normaltxtleft_inner">
                    <strong>Subject:</strong> Ut pretium rutrum lorem
                    <br />
                    <br />
                    Cras sed arcu. Morbi mi neque, vestibulum a, tincidunt ac, luctus nec, mauris
                </p>
                <p class="buttonscon_leftp">
                    <span class="buttoncontext_leftp">
                        <asp:ImageButton ID="ImageButton2" runat="server" CssClass="" ImageUrl="~/App/Images/context-butt.gif" /></span>
                    <span class="buttonremove_leftp">
                        <asp:ImageButton ID="ImageButton1" runat="server" CssClass="" ImageUrl="~/App/Images/remove-samll-butt.gif" /></span>
                </p>
            </div>
        </div>
    </div>
    <div class="leftheader" style="display: none;">
        <div>
            Recent Calls</div>
    </div>
    <div class="leftcontainerbdrall_inner" style="background-color: #F5F5F5; display: none;">
        <p class="divnewleftuc_ccrep" style="padding: 0px">
            <span class="lefttxtleftuc_ccrep" style="width: 170px" runat="server" id="spRecent1">
            </span>
        </p>
        <p class="divnewleftuc_ccrep" style="padding: 0px">
            <span style="float: right"><a href="javascript:alert('Please see this functionality in coming release.'); ">
                More </a>
                <img src="/App/Images/CCRep/dbl-arrows.gif" /></span>
        </p>
        <p class="divnewleftuc_ccrep" style="padding: 0px">
            <span class="lefttxtleftuc_ccrep" style="width: 170px" runat="server" id="spRecent2">
            </span>
        </p>
        <p class="divnewleftuc_ccrep" style="padding: 0px">
            <span style="float: right"><a href="javascript:alert('Please see this functionality in coming release.');">
                More </a>
                <img src="/App/Images/CCRep/dbl-arrows.gif" /></span>
        </p>
        <p class="divnewleftuc_ccrep">
            <span style="float: right">
                <asp:ImageButton runat="server" ID="ImageButton3" ImageUrl="~/App/Images/CCRep/viewallstat-btn.gif"
                    OnClientClick="return NextBuild();" /></span>
        </p>
    </div>
</div>
