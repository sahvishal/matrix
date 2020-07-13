<%@ Control Language="C#" AutoEventWireup="True"
    Inherits="NewucCallCenterLeftPanel" Codebehind="NewucCallCenterLeftPanel.ascx.cs" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

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
    <div class="leftcontainer_header_left" style="display:none; visibility:hidden;">
    </div>
    <div class="leftcontainer_header_mid" style="display:none; visibility:hidden;">
        Call Notes</div>
    <div class="leftcontainer_header_right" style="display:none; visibility:hidden;">
    </div>
    <asp:UpdatePanel ID="upNotes" runat="server">
        <ContentTemplate>
            <div class="lefttopblue_bg_ccrep" style="display:none; visibility:hidden;">
                <img src="/app/Images/CCRep/specer.gif" width="1" height="1" /></div>
            <div id="divCallDetail" runat="server"  visible="false">
                <div class="leftcontainer_header_left">
                </div>
                <div class="leftcontainer_header_mid">Call Details</div>
                <div class="leftcontainer_header_right">    
                </div>
                <div class="leftblue_midbox_ccrep" style="margin-top:4px">
                    <span id="spCallInfo" runat="server" visible="false">
                        <p style="float:left; width:170px;"><span class="titletxt_small_lp" style="width:70px" >Incoming Line:</span><span class="normaltxt_small_lp" id="spIncomingPhone" runat="server"></span></p>
                        <p style="float:left; width:170px;"><span class="titletxt_small_lp" style="width:70px" >Caller's Number:</span><span class="normaltxt_small_lp" id="spCallersPhone" runat="server"></span></p>
                        <p style="float:left; width:170px;"><span class="titletxt_small_lp" style="width:70px" >Name:</span><span class="normaltxt_small_lp" id="spName" runat="server"></span></p>
                        <p style="float:left; width:170px;"><span class="titletxt_small_lp" style="width:70px" >Call back number:</span><span class="normaltxt_small_lp" id="spCallBackNumber" runat="server">1234567890</span></p>
                        <p style="float:left; width:170px;"><span class="titletxt_small_lp" style="width:70px" >Zip Code:</span><span class="normaltxt_small_lp" id="spZipCode" runat="server"></span></p>
                        <p style="float:left; width:170px;"><span class="titletxt_small_lp" style="width:70px">Source Code:</span><span class="normaltxt_small_lp" id="spSourceCode" runat="server"></span></p>
                        <p style="float:left; width:170px;"><span class="titletxt_small_lp" style="width:80px">Customer ID:</span><span class="normaltxt_small_lp" style="width:80px" id="spSearchCustomerID" runat="server"></span></p>
                    </span>
                </div>
                <p><img src="/App/Images/CCRep/specer.gif" width="160px" height="5px" /></p>
            </div>
            <div id="divDetail" runat="server" visible="false">
                <div class="leftcontainer_header_left">
                </div>
                <div class="leftcontainer_header_mid">Customer Details</div>
                <div class="leftcontainer_header_right">    
                </div>
                <div class="leftblue_midbox_ccrep" style="margin-top:4px">
                <span id="spCustomerInfo" runat="server" visible="false">
                    <span class="titletxt_small_lp">CustID:</span><span class="normaltxt_small_lp" id="spCustomerID" runat="server"></span> 
                    <span class="titletxt_small_lp">Name:</span><span class="normaltxt_small_lp" id="spCustName" runat="server"></span> 
                    <span class="titletxt_small_lp">Email:</span><span class="normaltxt_small_lp" style="word-wrap: break-word;" id="spCustEmail" runat="server"></span> 
                    <span class="titletxt_small_lp">Gender:</span><span class="normaltxt_small_lp" id="spCustGender" runat="server"></span> 
                    <span class="titletxt_small_lp">Age:</span><span class="normaltxt_small_lp" id="spCustAge" runat="server"></span>
                    <span class="titletxt_small_lp">DOB:</span><span class="normaltxt_small_lp" id="spCustDOB" runat="server"></span> 
                </span>
                <span id="spEventInfo" runat="server" visible="false">
                    <span class="titletxt_small_lp">E Name:</span><span class="normaltxt_small_lp" id="spEventName" runat="server"></span> 
                    <span class="titletxt_small_lp">E Date:</span><span class="normaltxt_small_lp" id="spEventDate" runat="server"></span>                     
                </span>
                <span id="spSponsorInfo" runat="server" visible="false" style="float:left; width:170px;">
                    <span class="titletxt_small_lp" style="width:65px;">Sponsored by:</span><span class="normaltxt_small_lp" style="width:96px;" id="spHospitalPartnerName" runat="server"></span> 
                    <br />
                </span>
                <span id="spPackageInfo" runat="server" visible="false">
                    <span class="titletxt_small_lp">Order:</span><span class="normaltxt_small_lp" id="spPackageName" runat="server"></span> 
                    <span class="titletxt_small_lp">Time:</span><span class="normaltxt_small_lp" id="spAppointTime" runat="server"></span> 
                </span>
                <span><img src="/App/Images/CCRep/specer.gif" width="160px" height="4px" /></span>
            </div>
            </div>
            <div class="leftbotblue_bg_ccrep" style="display:none; visibility:hidden;">
                <img src="/App/Images/CCRep/specer.gif" width="1px" height="1px" /></div>
            <div id="divAddNotes" runat="server" class="call-center-notes">
                <div class="lefttop_bg_ccrep"><img src="/App/Images/CCRep/specer.gif" width="160px" height="1px" /></div>
                <div class="leftbox_ccrep">
                    <p class="innerrowleftbox_ccrep">
                        <span class="callnotes_icon_ccrep">
                            <img src='<%= ResolveUrl("~/App/Images/CCRep/callnotes_icon.gif") %>' width="17"
                                height="16">
                        </span><span class="headttxt_ccrep add-notes-heading">Add Notes</span>
                    </p>
                    <asp:Panel DefaultButton="imgSaveNotes" ID="pnlNotes" runat="server">
                        <div id="dvNotesStatus" runat="server" style="color: #D60202">
                        </div>
                        <p class="innerrowleftbox_ccrep">
                            <span class="leftboxinput_ccrep">
                                <asp:TextBox ID="txtNotes" runat="server" CssClass="inputlb_ccrep" TextMode="MultiLine" Width="168px"
                                    Rows="25" Columns="29"></asp:TextBox>
                            </span>
                        </p>
                        <p class="innerrowleftbox_ccrep">
                            <span class="savebtn_ccrep">
                                <asp:ImageButton ID="imgSaveNotes" runat="server" CssClass="" ImageUrl="../Images/CCRep/savenotes-btn.gif"
                                    OnClick="imgSaveNotes_Click"></asp:ImageButton>
                            </span>
                        </p>
                    </asp:Panel>
                </div>
                <div class="leftbox_ccrep">
                    <img src="/app/Images/specer.gif" width="5" height="5" /></div>
                <div>
                    <img src='/App/Images/CCRep/specer.gif' width="186" height="5"></div>
            </div>
            <asp:HiddenField ID="EventIdHiddenField" runat="server"/>
            
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
