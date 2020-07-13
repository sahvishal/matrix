<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" AutoEventWireup="true" Inherits="App_Common_AddNewHost" Title="Untitled Page" Codebehind="AddNewHost.aspx.cs" %>

<%@ Register src="../UCCommon/ucAddProspectHost.ascx" tagname="ucAddProspectHost" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ucAddProspectHost ID="ucAddProspectHost1" runat="server" />
</asp:Content>

