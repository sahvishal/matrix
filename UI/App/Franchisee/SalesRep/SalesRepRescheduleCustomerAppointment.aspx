<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" AutoEventWireup="true" Inherits="App_Franchisee_SalesRep_SalesRepRescheduleCustomerAppointment" Codebehind="SalesRepRescheduleCustomerAppointment.aspx.cs" %>

<%@ Register Src="../../UCCommon/UCChangeAppointment.ascx" TagName="UCChangeAppointment"
    TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content  ID="content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<cc1:ToolkitScriptManager runat="Server" ID="SManager" />
    <uc1:UCChangeAppointment ID="UCChangeAppointment1" runat="server" />

</asp:Content>

