<%@ Page Language="C#" MasterPageFile="~/App/Customer/CustomerMaster.master" AutoEventWireup="true" Inherits="App_MarketingPartner_AdvocateFAQ" Title="Untitled Page" Codebehind="AdvocateFAQ.aspx.cs" %>
<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.Core.Interfaces" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>

<%@ Register Src="~/App/UCCommon/UCCustomerLeftInfo.ascx" TagName="CustomerUC" TagPrefix="CustLeft" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript">
   var GB_ROOT_DIR = "/App/Wizard/greybox/";
    </script>
<script language="javascript" type="text/javascript">
    
    var pnlhgt;
    var heightlimit;
    var curtabopen;
    var curtabclose;
    var divHeight
    
    var divmainid, imgmainid;

    function CallExpandAnswer(divid, imgid)
    {
        pnlhgt=0;
        divmainid = divid;
        imgmainid = imgid;
        document.getElementById(divmainid).style.display = 'block';
        heightlimit = document.getElementById(divmainid).scrollHeight + 25;
        divHeight=heightlimit;
        //document.getElementById(divid).style.height = "0px";
        
        curtabopen = divid;
        
        ExpandAnswer();
        
    }
    
    function ExpandAnswer()
    {
        pnlhgt = pnlhgt + 1;
        document.getElementById(curtabopen).style.height=pnlhgt + 'px';
        Expanddelaypanel();
    }
    
    function Expanddelaypanel()
    {
        if(pnlhgt < heightlimit)
            setTimeout('ExpandAnswer()',1);
        else
        {
            document.getElementById(imgmainid).style.display = 'block';
        }
    }
    
    function CallCollapseAnswer(divid, imgid)
    {
        pnlhgt=divHeight;
        
        divmainid = divid;
        imgmainid = imgid;                
        
        heightlimit = 0;
        
        document.getElementById(imgmainid).style.display = 'none';
        
        curtabclose = divid;
        CollapseAnswer();
             
    }
    
    function CollapseAnswer()
    {
        pnlhgt = pnlhgt - 1;
        document.getElementById(curtabclose).style.height=pnlhgt + 'px';
        Collapsedelaypanel();
    }
    
    function Collapsedelaypanel()
    {
        if(pnlhgt >= heightlimit)
            setTimeout('CollapseAnswer()',1);
        else
        {
             document.getElementById(divmainid).style.display = 'none';
        }
    }
    
</script>
    <div class="maindiv_custdbrd">
        <div class="mindivbgblue_custdbrd">
            <span class="divheadtxt_custdbrd"><%= IoC.Resolve<ISettings>().CompanyName %> Wellness Dashboard</span>
            <div style="float: right; width: 340px; padding-top: 3px;" id="divLastLogin" runat="server">
                <span style="float: left; width: 7px;">
                    <img src="/App/Images/leftroundlastlogin.gif" /></span> <span style="float: left;
                        width: 320px; padding: 1px; text-align: center; background-color: #FFD4A8; border-top: solid 1px #F1B678;
                        border-bottom: solid 1px #F1B678;"><span style="color: #000;" id="spLastLogin" runat="server">
                            Your last login time:</span></span> <span style="float: left">
                                <img src="/App/Images/rightroundlastlogin.gif"></span>
            </div>
        </div>
        <div id="Div1" class="leftcon_main_custdbrd" style="margin-bottom: 5px">
            <CustLeft:CustomerUC ID="uc1" runat="server"  />
        </div>
        
        <%--<--Main Body start here-->--%>
    <div class="main_area_custdbrd">
        <div class="main_row_custdbrd">
            <div class="main_area_bdrnone">    
            <div class="maindivinner_faq" >
            <div class="maindivinnerrow_faq">
            <div class="headingbox_faq">
            <span class="orngheadtxt_default" style="float:left">FAQ</span>
            </div>
            <p><img src="../Images/specer.gif" width="700px" height="3px" /></p>
            <p class="graylinefull_default"><img src="../Images/specer.gif" width="1px" height="1px" /></p>   
            <p><img src="../Images/specer.gif" width="700px" height="10px" /></p> 
            <%--<div class="searchbox_faq">
            <span class="titletextnowidth_default">Search:</span>
            <span class="inputfldnowidth_default"><asp:TextBox ID="TextBox8" runat="server" CssClass="inputf_def" Width="170px"></asp:TextBox></span>
            <span class="gobtn_fadmin"><asp:ImageButton ID="btnEvaluate" runat="server" CssClass="" ImageUrl="~/App/Images/goblue-btn.gif" /></span>

            </div>--%>
            </div>
                <div class="divboxes_faq">
                    <div class="bodytopbg_faq">
                        <img src="../Images/specer.gif" width="5px" height="5px" /></div>
                    <p class="grayheadingbox_faq">
                        <span class="qicon_faq"><a href="javascript:CallExpandAnswer('ans1','ancImage1');">
                            <img src="../Images/q-grayicon-faq.gif" id="imgQ1" /></a></span> <span class="qheadtxt_faq">
                                What are the best resources for learning about the investments of sovereign wealth
                                funds outside of the US?</span>
                    </p>
                    <p class="lgtgray_ansbox_faq" id="ans1" style="overflow:hidden; display: none;">
                        <span class="anstxt_faq">Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nunc
                            vel dolor et diam auctor iaculis. Aenean sit amet orci. Mauris congue, urna vel
                            pretium sollicitudin, nulla ante lobortis ipsum, sed mollis sapien dui at odio.
                            Nullam vitae est. Pellentesque et dui eu lacus semper posuere. Integer sollicitudin,
                            risus non tempus dapibus, dui nibh vestibulum libero, vel euismod lectus erat sed
                            arcu. Duis venenatis pretium dolor. Integer enim.</span> 
                        <span id="ancImage1" style="display:none;" class="backtotop_faq">
                            <a href="javascript:CallCollapseAnswer('ans1','ancImage1');" >
                                <img src="../Images/back2up-icon-faq.gif"/>Back to top</a>
                        </span>
                    </p>
                </div>
                <div class="divboxes_faq">
                    <div class="bluetopbg_faq">
                        <img src="../Images/specer.gif" width="5px" height="5px" /></div>
                    <p class="blueheadingbox_faq">
                        <span class="qicon_faq"><a href="javascript:CallExpandAnswer('ans2','ancImage2');">
                            <img src="../Images/q-blueicon-faq.gif" /></a></span> <span class="qheadtxt_faq">
                                Any investor interested in funding a Patent Bio-tech project to make US$35.9 million/Year?</span>
                    </p>
                    <p class="lgtblue_ansbox_faq" id="ans2" style="overflow:hidden; display: none;">
                        <span class="anstxt_faq">Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nunc
                            vel dolor et diam auctor iaculis. Aenean sit amet orci. Mauris congue, urna vel
                            pretium sollicitudin, nulla ante lobortis ipsum, sed mollis sapien dui at odio.
                            Nullam vitae est.</span> 
                        <span id="ancImage2" style="display:none;" class="backtotop_faq">
                            <a href="javascript:CallCollapseAnswer('ans2','ancImage2');" >
                                <img src="../Images/back2up-icon-faq.gif"/>Back to top</a>
                        </span>
                    </p>
                </div>
            </div>
 </div>
 </div>
 </div>
<%--<--Main Body End here-->--%>
</div>
</asp:Content>
