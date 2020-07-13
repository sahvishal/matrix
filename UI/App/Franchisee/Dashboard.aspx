<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" AutoEventWireup="True" Inherits="Franchisee_Dashboard" Title="Dashboard" Codebehind="Dashboard.aspx.cs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style type="text/css">
.divmainboxbig_fdb{float:left; width:741px; padding-top:5px;}
.divgrayboxbig_fdb{float:left; width:731px; padding-left:10px;}
.boxheadingbgbig_fdb{float:left; width:718px; height:25px; background-image: url(../Images/headbgboxbig_fdashboard.gif); padding-left:13px; padding-top:14px; font:bold 14px arial; color:#000;    }
.boxbotbgbig_fdb{float:left; width:731px; height:16px; background-image: url(../Images/botbgboxbig_fdashboard.gif);}
.divlistoflink_fdb{float:left; width:729px; border-left:1px solid #E5E5E5; border-right:1px solid #E5E5E5; background-color:#F2F2F2;}
.linkscon_fdb{float:left; width:210px; padding-left:10px;}
.linkscon_fdb ul{float:left; padding-left: 20px; font:normal 12px arial; color:#000000; width:200px;}
.linkscon_fdb li{float:left; padding-left: 10px; list-style-image: url('/App/Images/blue-arrow-lnks.gif'); font:normal 12px arial; color:#000000; width:200px; height:20px;}

.main_content_area_mvdb{ float:left; width:745px; padding-bottom:5px;}
.divgraybox_mvdb{float:left; width:450px; padding-left:10px;}
</style>
<div class="mainbody_outer">
            <div class="mainbody_inner">
            
            <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p><img src="/App/Images/specer.gif" width="700px" height="5px" /></p>
                    <span class="orngheadtxt_heading" id="dvTitle" runat="server">Franchisee Dashboard</span>
                    <div style="float:right; width:340px" id="divLastLogin" runat="server">
                        <span style="float:left; width:7px;"><img src="/App/Images/leftroundlastlogin.gif" /></span>
                        <span style=" float:left;width:320px; padding:1px; text-align:center; background-color:#FFD4A8; border-top:solid 1px #F1B678;  border-bottom:solid 1px #F1B678;" >
                        <span style="color:#000;" id="spLastLogin" runat="server">Your last login time:</span></span>
                        <span style="float:left"><img src="/App/Images/rightroundlastlogin.gif"></span>
                    </div>
                </div>
            </div>
            <%--<div class="mainbody_inner_left">
            </div>
            <div class="mainbody_inner_mid">
            <div class="mainbody_titletxtleft">Fanchisee Dashboard</div>
            </div>
            <div class="mainbody_inner_right">
            </div>--%>
            <div class="main_area_bdr">
            <div class="main_content_area_mvdb">
			<div class="divmainboxbig_fdb">
			<div class="divgrayboxbig_fdb">
			<p class="boxheadingbgbig_fdb"> Links Title</p>
			
			<div class="divlistoflink_fdb">
			        <asp:TreeView id="treeFranchisor" CssClass="linkscon_fdb" runat="server" ShowLines="true" ExpandDepth="0"></asp:TreeView>
			    </div>
			</div>
			<div class="divgraybox_mvdb">
			<p class="boxbotbgbig_fdb"></p>
			</div>
			</div>
			
                      
            
            	
            
            </div>
            </div>
    </div>
    </div>
</asp:Content>