<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" AutoEventWireup="true" Inherits="App_Franchisor_ManageHost" Title="Manage Hosts" Codebehind="ManageHost.aspx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %> 
<%@ Register src="~/App/UCCommon/ucManageHost.ascx" tagname="ManageHost" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<uc1:ManageHost ID="UsCtrlManageHosts" runat="server" />
</asp:Content>

