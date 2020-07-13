<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="ucCallCenterLeftPanel" Codebehind="ucCallCenterLeftPanel.ascx.cs" %>

<script language="javascript" type="text/javascript">
    
    var pnlhgt;
    var heightlimit;
    var curtabopen;

    function CallExpandTab(divid, imgopen, imgdown)
    {
        
        if(document.getElementById(divid).style.height!='0px')
            return;
        
        pnlhgt=0;
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

    function ExpandLeftTab()
    {
        
        pnlhgt = pnlhgt + 1;
        document.getElementById('' + curtabopen + '').style.height=pnlhgt + 'px';
        delaypanel();
    }

    function CollapseAllTab()
    {
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

    function delaypanel()
    {
        if(pnlhgt < heightlimit)
            setTimeout('ExpandLeftTab()',2);
    }
    
</script>

<div class="leftcontainer_inner">
    <div class="leftheader">
        <div>Quick Nav</div>
    </div>
    <div class="lftpnlbox">        
        <span id="spStats" runat="server"></span>        
    </div>
        <div class="lftpnlbox">        
        <span id="spRecentCalls" runat="server"></span>        
    </div>
</div>
