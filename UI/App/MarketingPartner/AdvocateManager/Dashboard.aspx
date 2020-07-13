<%@ Page Language="C#" MasterPageFile="~/App/MarketingPartner/AdvocateManager/AdvocateManager.master"
    AutoEventWireup="true" Inherits="App_MarketingPartner_AdvocateManager_Dashboard" Codebehind="Dashboard.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="~/App/UCCommon/UCCustomerLeftInfo.ascx" TagName="CustomerUC" TagPrefix="CustLeft" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" language="javascript">
  
      var GB_ROOT_DIR = "/App/Wizard/greybox/";
    </script>

    <div class="mainbody_outer">
        <div class="mainbody_inner">
            <div class="main_area_bdrnone">
                <div class="maindivinnerrow_faq">
                    <div class="headingbox_faq" style="margin-top:5px">
                        <span class="orngheadtxt_heading" style="float: left">Summary of Activities </span>
                    </div>
                    <span class="headingright_default"></span>
                </div>
                
                
                <div class="maindivredmsgbox" id="errordiv" visible="false" runat="server">
                </div>
                <div class="grayboxtop_cl" style="margin-top:10px;">
                    <div style="float: left; padding: 0px; margin: 0px; height: 27px;" id="divDateRange"
                        runat="server">
                        <asp:ImageButton CommandName="Today" ID="ibtnEToday" runat="server" ImageUrl="~/App/Images/MarketingPartner/today-tab-OFF_mp.gif" OnClick="ibtnCampaign_Click" />
                        <asp:ImageButton CommandName="ThisWeek" ID="ibtnEThisWeek" runat="server" ImageUrl="~/App/Images/MarketingPartner/thisweek-tab-off_mp.gif" OnClick="ibtnCampaign_Click" />
                        <asp:ImageButton CommandName="ThisMonth" ID="ibtnEThisMonth" runat="server" ImageUrl="~/App/Images/MarketingPartner/thismonth-tab-off_mp.gif" OnClick="ibtnCampaign_Click" />
                        <asp:ImageButton CommandName="All" ID="ibtnEAll" runat="server" ImageUrl="~/App/Images/MarketingPartner/All-tab-off_mp.gif" OnClick="ibtnCampaign_Click" />
                    </div>
                    <div class="lgtgraybox_cl" style="background-color: #F7FCFE; border:solid 1px #D8EAF8;">
                        <p class="lgtgrayboxrow_cl" style="padding-top: 10px;">
                            <span class="orngbold14_default" style="float: left; width: 160px; padding-top: 10px;
                                ">Campaigns: </span><span id="spCallsRecieved1" class="detailbox_advmanager"
                                          runat="server"><span id="spCampaignCount" runat="server">
                                        0</span> </span><span style="float: left; width: 25px; padding: 8px 85px 0px 10px;">
                                           
                                        </span><span class="orngbold14_default" style="float: left; width: 200px; padding-top: 10px">
                                            Advanced Advocates:</span> <span class="detailbox_advmanager"><span id="spAdvancedAdvocateCount" runat="server"></span></span>
                            
                        </p>
                        
                        <p><img src="../../Images/specer.gif" width="700px" height="10px" /></p>
                        <p class="lgtgrayboxrow_cl">
                            <span class="orngbold14_default" style="float: left; width: 160px; padding-top: 10px">
                                Marketing Materials:</span> <span class="detailbox_advmanager"><span id="spMarketingMaterialCount" runat="server"></span></span><span style="float: left;
                                        width: 25px; padding: 8px 85px 0px 10px;">
                                       
                                    </span><span class="orngbold14_default" style="float: left; width: 200px; padding-top: 10px">Express Advocates:</span>
                            <span class="detailbox_advmanager">
                                    <span id="spExpressAdvocateCount" runat="server">0</span></span><span style="float: left;
                                        width: 25px; padding: 8px 0px 0px 10px;">
                                    </span>
                        </p>
                        <p><img src="../../Images/specer.gif" width="700px" height="10px" /></p>
                        <p class="lgtgrayboxrow_cl">
                            <span class="orngbold14_default" style="float: left; width: 160px; padding-top: 10px">
                                Total Clients:</span> <span class="detailbox_advmanager">
                                    <span id="spTotalClient" runat="server"></span></span><span style="float: left;
                                        width: 25px; padding: 8px 85px 0px 10px;">
                                      
                                    </span><span class="orngbold14_default" style="float: left; width: 200px; padding-top: 10px">Total Revenue (In $):</span>
                            <span class="detailbox_advmanager"><span id="spCommission"
                                    runat="server">0.00</span></span><span style="float: left; width: 25px; padding: 8px 0px 0px 10px;">
                                    </span>
                        </p>
                          <p class="lgtgrayboxrow_cl"><img src="../../Images/specer.gif" width="500" height="5px" /></p>
                    </div>
                </div>
                <%--<--Main Body End here-->--%>
            </div>
        </div>
    </div>        
</asp:Content>
