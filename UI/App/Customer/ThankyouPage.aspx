<%@ Page Language="C#" MasterPageFile="~/App/Customer/CustomerMaster.master" AutoEventWireup="True" Inherits="App_Customer_ThankyouPage" Title="Untitled Page" Codebehind="ThankyouPage.aspx.cs" %>
<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.Core.Interfaces" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>

 <%@ Register Src="~/App/UCCommon/UCCustomerLeftInfo.ascx" TagName="CustomerUC" TagPrefix="CustLeft" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript" language="javascript">
 
   var GB_ROOT_DIR = "/App/Wizard/greybox/";
   </script><div class="maindiv_custdbrd">
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
         <CustLeft:CustomerUC ID="uc1" runat="server" OnLoad="SetName" AdvocateView="false" />
        </div>
    
    
       <div class="main_area_custdbrd">
        <div class="main_row_custdbrd"><a href="SearchEvent.aspx"><img src="../Images/MarketingPartner/thankyou-banner.jpg"/></a> </div>
        <%--<div class="main_row_custdbrd">
        <div class="headingbox_default"><span class="orngheadtxt_default">Welcome XYZ,</span>
                </div>
        <p><img src="../Images/specer.gif" width="740px" height="5px" /></p>
        </div>--%>
       <p><img src="../Images/specer.gif" width="740px" height="5px" /></p>
        <div class="main_row_custdbrd">
        <span class="bluheadtxt12_osteo">  We have sent an invitation email to: <span style="font-weight:normal; text-decoration:underline"> Xyz@domain.com</span> <span id="spFullName" runat="server">  </span></span><br />
        If they sign up  using the above email, you will get a credit of $ <XX>. You can redeem this for cash or credit towards future screenings.</div>
        <p><img src="../Images/specer.gif" width="740px" height="10px" /></p>     
        <p class="main_row_custdbrd">
        <span class="orngbold14_default">Referrer More Friends and Family</span>
        </p>
        <p class="main_row_custdbrd">
        <span>If you think someone can benefit from a <%= IoC.Resolve<ISettings>().CompanyName %> preventative screening, just enter their name and email address below and we will send them an invitation to sign up for a screening. If they sign up using the email below, you will get a $<XX> credit.
        </span>
        </p>
         <p><img src="../Images/specer.gif" width="740px" height="15px" /></p> 
        <div class="main_row_custdbrd">
        <p class="phonerecordboxrow_ccrep">
         <span class="titletextsmallbld_default" >Full Name:</span> <span class="inputfldnowidth_default"
        style="padding-right: 50px">
        <asp:TextBox ID="txt" runat="server" Width="110px" CssClass="inputf_pbox_ccrep"></asp:TextBox></span>
        <span class="titletextsmallbld_default"  >Email:</span>
        <span class="inputfldnowidth_default"><asp:TextBox ID="txtemail" runat="server" Width="110px" CssClass="inputf_pbox_ccrep"></asp:TextBox>
         </span>
        </p>
         <p><img src="../Images/specer.gif" width="740px" height="15px" /></p>
                 <p class="phonerecordboxrow_ccrep">
         <span class="titletextsmallbld_default" >Full Name:</span> <span class="inputfldnowidth_default"
        style="padding-right: 50px">
        <asp:TextBox ID="TextBox1" runat="server" Width="110px" CssClass="inputf_pbox_ccrep"></asp:TextBox></span>
        <span class="titletextsmallbld_default"  >Email:</span>
        <span class="inputfldnowidth_default"><asp:TextBox ID="TextBox2" runat="server" Width="110px" CssClass="inputf_pbox_ccrep"></asp:TextBox>
         </span>
        </p>
        <p><img src="../Images/specer.gif" width="740px" height="15px" /></p>
         <p class="phonerecordboxrow_ccrep">
         <span class="titletextsmallbld_default" >Full Name:</span> <span class="inputfldnowidth_default"
        style="padding-right: 50px">
        <asp:TextBox ID="TextBox3" runat="server" Width="110px" CssClass="inputf_pbox_ccrep"></asp:TextBox></span>
        <span class="titletextsmallbld_default"  >Email:</span>
        <span class="inputfldnowidth_default"><asp:TextBox ID="TextBox4" runat="server" Width="110px" CssClass="inputf_pbox_ccrep"></asp:TextBox>
         </span>
        </p>
        <p><img src="../Images/specer.gif" width="740px" height="15px" /></p>
         <p class="phonerecordboxrow_ccrep" style="width:430px"> <span style="float:right;"><asp:ImageButton ID="ibtnsendinvitation" runat="server" ImageUrl="~/App/Images/calculatebmi-btn.gif" /></span></p>
        
        </div>
        
   
       
       
       </div>
    
    
    </div>
</asp:Content>

