<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" AutoEventWireup="True" Inherits="App_Franchisee_SalesRep_SalesRepManageProspects" Title="Manage Prospects" Codebehind="SalesRepManageProspects.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>   
    
<%@ Register src="../../UCCommon/UCManageProspects.ascx" tagname="UCManageProspects" tagprefix="uc1" %>
    
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:UCManageProspects ID="UsCtrlManageProspects" runat="server" />
</asp:Content>

