<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" AutoEventWireup="True" Inherits="App_Franchisee_SalesRep_SalesRepProspectDetails" Title="Untitled Page" Codebehind="SalesRepProspectDetails.aspx.cs" %>

<%@ Register Src="../../UCCommon/UCProspectDetails.ascx" TagName="UCProspectDetails" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<uc1:UCProspectDetails ID="UCProspectDetails" runat="server" />
</asp:Content>

