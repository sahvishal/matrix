<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Public/Public.master" Inherits="Falcon.App.UI.Public.Account.ResetPasswordStep3" EnableEventValidation="false" Codebehind="ResetPasswordStep3.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="maindivouterlogin_pw" style="margin-left:20px;">  
    <div class="header_pw">
    <div class="headertxt_pw" runat="Server" id="divHeading">
        Forgot Reset Your Password</div>
    </div>
    <div class="body_border_pw">
    
    <div class="errormsgtxtreg_pw" id="errordiv" runat="server" ></div>
     <div class="headbgnonelm_pw">
     <div class="headtxt_pw" id="div1" runat="server">Password changed successfully.</div>
     </div>
     
    <p class="contentrowlm_pw">
    <span class="normaltextlm_pw" id="spnMessage" runat="server"></span>
    </p>  
    <p class="contentrowlm_pw" style="text-align:left">
    <span><a href="/login"><img src="/Content/Images/home-btn.gif" /></a></span>
    </p>  
    </div>
    <div class="bottombg_pw"></div>
    </div>
 </asp:Content>
    
   
   