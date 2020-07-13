<%@ Page Language="C#" MasterPageFile="~/App/CallCenter/NewCallCenterMaster.master"
    AutoEventWireup="true" Inherits="App_CallCenter_CallCenterRep_CallCenterRepCustomerList" Codebehind="CallCenterRepCustomerList.aspx.cs" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="~/App/UCCommon/UCSearchCustomer.ascx" TagName="UCCustomerList" TagPrefix="uc1" %>
<asp:Content ID="content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="float: left">
        <div class="mainbody_outer">
            <div class="mainbody_inner">
                <div class="main_area_bdrnone">
                    <div class="headingbox_top_body">
                        <p>
                            <img src="/App/Images/specer.gif" width="750px" height="5px" /></p>
                        <div class="orngheadtxt_heading" id="dvTitle" runat="server">
                            Search Customer</div>
                        <div class="headingright_default"  id="divCall" runat="server">
                            <div class="endcall_ccrep_dboard">
                                <span class="endtbtn_ccrep_dboard" style="padding-top: 4px;">
                                    <asp:ImageButton ID="imgEndCall" runat="server" ImageUrl="~/App/Images/CCRep/endcallbtn.gif"
                                        OnClientClick="CallNotes(); return false;" />
                                </span>
                            </div>
                            <div class="timeboard_ccrep_dboard">
                                <div class="timeboxbg_ccrep_dboard">
                                    <p class="tboxrow_ccrep_dboard">
                                        <span class="timetxt_ccrep_dboard"><span id="HH"></span>:<span id="MM"></span>:<span
                                            id="SS"></span></span>
                                    </p>
                                    <p class="tboxrowformat_ccrep_dboard">
                                        <span class="smallgraytxt_ccrep">(HH:MM:SS)</span>
                                    </p>
                                    <p class="tboxrowbtm_ccrep_dboard">
                                        <span class="whttxt_ccrep_dboard">Call in Progress</span>
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <p>
                        <img src="/App/Images/specer.gif" width="750px" height="2px" /></p>
                </div>
            </div>
        </div>
        <div style="float: left">
            <uc1:UCCustomerList ID="UCCustomerList1" runat="server" />
        </div>
    </div>
    <asp:HiddenField runat="server" ID="hfCallStartTime" />

    <script language="javascript">
     //// this will run after page is load
      var hfCallStartTime= document.getElementById("<%= this.hfCallStartTime.ClientID %>");
        StartTimer(hfCallStartTime);
    </script>

</asp:Content>
