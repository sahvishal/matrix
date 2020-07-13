<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" AutoEventWireup="true" Inherits="App_Franchisor_ProspectDetails" Title="Untitled Page" Codebehind="ProspectDetails.aspx.cs" %>

<%@ Register Src="~/App/UCCommon/UCProspectDetails.ascx" TagName="UCProspectDetails" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<uc1:UCProspectDetails ID="UCProspectDetails" runat="server" />
</asp:Content>

