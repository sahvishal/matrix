<%@ Page Language="C#" MasterPageFile="~/App/Franchisee/Technician/TechnicianMaster.master"
    AutoEventWireup="true" Inherits="App_Franchisee_Technician_TechnicianCustomerList" Codebehind="TechnicianCustomerList.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register TagName="UCSearchCustomer" TagPrefix="UC1" Src="~/App/UCCommon/UCSearchCustomer.ascx" %>
<asp:Content ID="content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="float:left;">
    <UC1:UCSearchCustomer ID="UCSearchCustomer1" runat="server" />
</div>
</asp:Content>
