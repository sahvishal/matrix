<%@ Control Language="C#" AutoEventWireup="true" Inherits="App_Franchisor_leftpanelcalander"
    CodeBehind="ucleftpanelcalander.ascx.cs" %>

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
    function setCheckAllStatus() {
        var ViewAllChk = document.getElementById('ViewAllChk')
        document.getElementById('ViewEventChk').checked = ViewAllChk.checked;
        document.getElementById('ViewMeetingChk').checked = ViewAllChk.checked;
        document.getElementById('ViewCallChk').checked = ViewAllChk.checked;
        document.getElementById('ViewTaskChk').checked = ViewAllChk.checked;
        document.getElementById('ViewSeminarChk').checked = ViewAllChk.checked;
        return ViewCurrentCalendar();
    }
    function setView(ViewChk) {
        
        var ViewAllChk = document.getElementById('ViewAllChk')
        if ((document.getElementById('ViewEventChk').checked == ViewChk.checked) &&
        (document.getElementById('ViewMeetingChk').checked == ViewChk.checked) &&
        (document.getElementById('ViewCallChk').checked == ViewChk.checked) &&
        (document.getElementById('ViewTaskChk').checked == ViewChk.checked) &&
        (document.getElementById('ViewSeminarChk').checked == ViewChk.checked)) {
            ViewAllChk.checked = ViewChk.checked;

        }
        else {
            ViewAllChk.checked = false;
        }
        
        return ViewCurrentCalendar();
    }
    
</script>

<div class="wrapper_lftnmargin">
    <div class="leftheader" style="display:none">
        <div>
            Quick Nav</div>
    </div>
    <div class="lftpnlbox" id="_divQuickLinks" runat="server" style="display:none">
    </div>
    <div class="leftheader">
        <div>Select Territory</div>
    </div>
    
    <div class="lftpnlboxscrl">
    <asp:DataList ID="TerritoryDtl" runat="server" ShowHeader="false" 
            CssClass="listaddterritory territory-table">
        <ItemTemplate>
            <asp:CheckBox ID="TerritoryChkBox" runat="server" CssClass="left" Style="display:none"/>
            <label></label>
        </ItemTemplate>
		<ItemStyle CssClass="row1" />
		<AlternatingItemStyle CssClass ="row2" />              
    </asp:DataList> 
    </div>
    
    <div class="leftheader">
        <div>Select Pod</div>
    </div>
     <div class="lftpnlboxscrl">     
      <asp:DataList ID="PodDtl" runat="server" ShowHeader="false" 
            CssClass="listaddterritory pod-table" >
        <ItemTemplate>
            <asp:CheckBox ID="PodChkBox" runat="server" CssClass="left" Style="display:none"/>
            <label></label>
        </ItemTemplate>              
    </asp:DataList>
     </div>
     
    <div class="leftheader">
      
               
            
        <div> <input type="checkbox"  id="ViewAllChk" onclick="setCheckAllStatus()" />Add Details</div>
    </div>
    <div class="calander_leftinner_con">
        <div class="rowlft">
            <span class="calander_colorboxevent" id="spViewEvent" runat="server">
                <input type="checkbox" checked="checked" id="ViewEventChk"  onclick="return setView(ViewEventChk);"/>
            </span><span class="chkbxtxtadd">Event [ <a href="/App/Common/CreateEventWizard/Step1.aspx?Type=Create&Referrer=Calendar">
                Add</a> ]</span>
        </div>
        <div class="rowlft">
            <span class="calander_colorboxmeeting" id="spViewMeeting" runat="server">
                <input type="checkbox"   id="ViewMeetingChk"  onclick="return setView(ViewMeetingChk);"/>
            </span><span class="chkbxtxtadd"> Meeting [ <a href="../Franchisor/AddMeeting.aspx?Referrer=Calendar">Add</a> ]</span>
        </div>
        <div class="rowlft">
            <span class="calander_colorboxcall" id="spViewCall" runat="server">
                <input type="checkbox"  id="ViewCallChk"  onclick="return setView(ViewCallChk);"/>
            </span><span class="chkbxtxtadd">Call [ <a href="../Franchisor/AddCall.aspx?Referrer=Calendar">Add</a> ] </span>
        </div>
        <div class="rowlft">
            <span class="calander_colorboxtask" id="spViewTask" runat="server">
                <input type="checkbox"  id="ViewTaskChk"  onclick="return setView(ViewTaskChk);"/>
            </span><span class="chkbxtxtadd"> Tasks [ <a href="../Franchisor/AddTask.aspx?Referrer=Calendar">Add</a> ]</span>
        </div>
        <div class="rowlft">
            <span class="calander_colorboxtask" style="background-color: #F8C67D" id="spSeminar"
                runat="server">
                <input type="checkbox"  id="ViewSeminarChk" onclick="return setView(ViewSeminarChk);" />
            </span><span class="chkbxtxtadd"> Seminar [ <a href="javascript:alert('Pending Functionality');">Add</a> ]</span>
        </div>
    </div>
</div>
