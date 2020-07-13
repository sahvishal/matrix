<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master"
    AutoEventWireup="true" Inherits="App_Franchisor_FranchisorCustomerDetails" ValidateRequest="false"
    CodeBehind="FranchisorCustomerDetails.aspx.cs" %>

<%@ Register Src="../UCCommon/UCCustomerHistory.ascx" TagName="UCCustomerHistory" TagPrefix="uc1" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="content1" runat="server">    
    <uc1:UCCustomerHistory ID="UCCustomerHistory1" runat="server" />
</asp:Content>
