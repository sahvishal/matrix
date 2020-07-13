<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" EnableEventValidation="false" AutoEventWireup="true" Inherits="App_Franchisor_FranchisorRescheduleCustomerAppointment" Codebehind="FranchisorRescheduleCustomerAppointment.aspx.cs" %>

<%@ Register Src="../UCCommon/UCChangeAppointment.ascx" TagName="UCChangeAppointment"
    TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="content1" runat="server">
  <uc1:UCChangeAppointment ID="UCChangeAppointment1" runat="server" />
</asp:Content>
