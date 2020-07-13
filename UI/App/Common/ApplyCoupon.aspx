   <%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" AutoEventWireup="true" Inherits="App_Common_ApplyCoupon" Title="Untitled Page" Codebehind="ApplyCoupon.aspx.cs" EnableEventValidation="false" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="../UCCommon/ApplyCoupon.ascx" TagName="ApplyCoupon" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ApplyCoupon ID="Ucapplycoupon1" runat="server" />
</asp:Content>

