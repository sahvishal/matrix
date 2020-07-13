<%@ Page Language="C#" MasterPageFile="~/App/Franchisee/Technician/TechnicianMaster.master" AutoEventWireup="true" Inherits="App_Franchisee_Technician_TechnicianEditCustomer" Title="Untitled Page" 
    Codebehind="TechnicianEditCustomer.aspx.cs" EnableEventValidation="false" %>

<%@ Register Src="../../UCCommon/UCEditCustomer.ascx" TagName="UCEditCustomer" TagPrefix="uc1" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager runat="server" ID="ScriptManager1" />     
    <uc1:UCEditCustomer ID="UCEditCustomer1" runat="server" />
</asp:Content>

