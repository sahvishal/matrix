<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" AutoEventWireup="true" Inherits="App_Franchisor_ManageProspect" Title="Manage Prospects" Codebehind="ManageProspect.aspx.cs" %>
    
<%@ Register src="../UCCommon/UCManageProspects.ascx" tagname="UCManageProspects" tagprefix="uc1" %>
    
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:UCManageProspects ID="UsCtrlManageProspects" runat="server" />
</asp:Content>

