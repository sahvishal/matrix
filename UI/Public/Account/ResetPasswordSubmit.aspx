<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Public/Public.master" Inherits="Falcon.App.UI.Public.Account.ResetPasswordSubmit" EnableEventValidation="false" Codebehind="ResetPasswordSubmit.aspx.cs" %>
<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>

<asp:Content ID="ContentHeader" ContentPlaceHolderID="head" runat="Server">
    <title>Reset Password Submit</title>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="maindivouterlogin_pw" style="margin-left:10px">
    <div class="reuirdfieldrow_pw"></div>
    <div class="header_pw">
    <div class="headertxtbig_pw">Congratulations! Your password has been reset</div>
    </div>
    <div class="body_border_pw">
    
     
    <p class="contentrowlm_pw">
    <span class="normaltextlm_pw"><a href="<%= IoC.Resolve<ISettings>().SiteUrl%>">Click here</a> to go to the homepage.</span>
    </p>
    
    <p class="contentrowlm_pw">
    <span class="normaltextlm_pw"></span>
    </p>
    
    
 
    </div>
    <div class="bottombg_pw"></div>
    
   
    </div>
    </asp:Content>
    
  