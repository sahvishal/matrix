<%@ Page Language="C#" MasterPageFile="~/App/Franchisee/Technician/TechnicianMaster.master" AutoEventWireup="true" Inherits="App_Franchisee_Technician_ChangePackage" Title="Untitled Page" Codebehind="ChangePackage.aspx.cs" EnableEventValidation="false" %>

<%@ Register Src="../../UCCommon/ucChangePackage.ascx" TagName="ucChangePackage"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ucChangePackage ID="UcChangePackage1" runat="server" />
</asp:Content>

