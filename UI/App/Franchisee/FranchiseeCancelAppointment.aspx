<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" AutoEventWireup="true" Inherits="App_Franchisee_FranchiseeCancelAppointment" Title="Untitled Page" 
    Codebehind="FranchiseeCancelAppointment.aspx.cs" EnableEventValidation="false" %>

<%@ Register Src="../UCCommon/UCCancelAppointment.ascx" TagName="UCCancelAppointment"
    TagPrefix="uc1" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <uc1:UCCancelAppointment ID="UCCancelAppointment1" runat="server" />
</asp:Content>

