<%@ Page Language="C#" MasterPageFile="~/App/Franchisee/Technician/TechnicianMaster.master" AutoEventWireup="true" Inherits="App_Franchisee_Technician_MissingResultReport" Title="Untitled Page" Codebehind="MissingResultReport.aspx.cs" %>

<%@ Register src="../../UCCommon/ucCustomerResultReport.ascx" tagname="ucCustomerResultReport" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ucCustomerResultReport ID="ucCustomerResultReport1" runat="server" />
</asp:Content>

