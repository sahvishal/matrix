<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" AutoEventWireup="True" Inherits="Falcon.App.UI.App.Franchisee.FranchiseeProspectDetails" Title="Untitled Page" Codebehind="FranchiseeProspectDetails.aspx.cs" %>

<%@ Register Src="~/App/UCCommon/UCProspectDetails.ascx" TagName="UCProspectDetails" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<uc1:UCProspectDetails ID="UCProspectDetails" runat="server" />
</asp:Content>
