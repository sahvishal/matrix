<%@ Page Language="C#" MasterPageFile="~/App/Franchisee/Technician/TechnicianMaster.master" AutoEventWireup="true" Inherits="App_Franchisee_Technician_TechnicianCustomerDetails" Codebehind="TechnicianCustomerDetails.aspx.cs" %>

<%@ Register Src="../../UCCommon/UCCustomerHistory.ascx" TagName="UCCustomerHistory"
    TagPrefix="uc1" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="content1" runat="server">
<asp:ScriptManager runat="server" ID="ScriptManager1" />     
    <uc1:UCCustomerHistory ID="UCCustomerHistory1" runat="server" />


</asp:Content>