<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master"
    AutoEventWireup="true" Inherits="App_Franchisee_FranchiseeCustomerDetails" Codebehind="FranchiseeCustomerDetails.aspx.cs" %>

<%@ Register Src="../UCCommon/UCCustomerHistory.ascx" TagName="UCCustomerHistory"
    TagPrefix="uc1" %>

<asp:Content ID="content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCCustomerHistory ID="UCCustomerHistory1" runat="server" />
    
</asp:Content>
