<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" AutoEventWireup="True" Inherits="App_Franchisee_FranchiseeRescheduleCustomerAppointment" Codebehind="FranchiseeRescheduleCustomerAppointment.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../UCCommon/UCChangeAppointment.ascx" TagName="UCChangeAppointment"
    TagPrefix="uc1" %>

<asp:Content ID="conent1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <uc1:UCChangeAppointment ID="UCChangeAppointment1" runat="server" />

</asp:Content>