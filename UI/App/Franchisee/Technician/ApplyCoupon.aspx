<%@ Page Language="C#" MasterPageFile="~/App/Franchisee/Technician/TechnicianMaster.master"
    AutoEventWireup="true" Inherits="App_Franchisee_Technician_ApplyCoupon"
    Title="Untitled Page" Codebehind="ApplyCoupon.aspx.cs" EnableEventValidation="false" %>

<%@ Register Src="../../UCCommon/ApplyCoupon.ascx" TagName="ApplyCoupon" TagPrefix="uc1" %>
    


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:ApplyCoupon ID="Ucapplycoupon1" runat="server" />

    
</asp:Content>
