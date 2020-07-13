<%@ Page Language="C#" MasterPageFile="~/App/Customer/CustomerMaster.master" AutoEventWireup="true" CodeBehind="OpenIdeas.aspx.cs" Inherits="HealthYes.Web.App.Customer.OpenIdeas" %>
<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.Core.Interfaces" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>
<%@ Register Src="~/App/UCCommon/UCCustomerLeftInfo.ascx" TagName="CustomerUC" TagPrefix="CustLeft" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<script type="text/javascript" language="javascript">
 
   var GB_ROOT_DIR = "/App/Wizard/greybox/";
</script>
    <div class="maindiv_custdbrd">
     
        <div class="mindivbgblue_custdbrd">
            <span class="divheadtxt_custdbrd"><%= IoC.Resolve<ISettings>().CompanyName %> Wellness Dashboard</span>
            <div style="float:right; width:340px; padding-top:3px;" id="divLastLogin" runat="server">
                <span style="float:left; width:7px;"><img src="/App/Images/leftroundlastlogin.gif" /></span>
                <span style=" float:left;width:320px; padding:1px; text-align:center; background-color:#FFD4A8; border-top:solid 1px #F1B678;  border-bottom:solid 1px #F1B678;" >
                <span style="color:#000;" id="spLastLogin" runat="server">Your last login time:</span></span>
                <span style="float:left"><img src="/App/Images/rightroundlastlogin.gif"></span>
            </div>
        </div>
        
         <div id="Div1" class="leftcon_main_custdbrd" style="margin-bottom: 5px">
         <CustLeft:CustomerUC ID="uc1" runat="server" OnLoad="SetName" />
        </div>
        
         <div class="main_area_custdbrd">
          <div class="main_row_custdbrd">
            <div class="headingbox_default">
                <span class="orngheadtxt_heading">Open for Ideas</span>
            </div>
            <p><img src="../Images/specer.gif" height="2px" width="750px" /></p>
            <p class="graylinefull_common"><img src="../Images/specer.gif" height="1px" width="750px" /></p>
             <p><img src="../Images/specer.gif" height="5px" width="750px" /></p>
            </div>
             <div class="main_row_custdbrd" >
             <div class="main_row_custdbrd" style="font:bold 14px arial; color:#666">
             <ul>
             <li>Pushes to screenings that we don't offer ... for example mammograms for females, </li>
             <li>Content provided by St. Davids, or </li>
             <li>Really anything we can dream up.</li>
             </ul>
             
             </div>
             </div>
         
            <div class="main_row_custdbrd" style="margin-top:50px" >
                <div style="float:left; width:744px; border:solid 1px #EE872C; text-align:center">
                <img src="../Images/underconstrction-icon.gif" />
                </div>
            </div>
        </div>
        
        
        
        
    </div>




</asp:Content>