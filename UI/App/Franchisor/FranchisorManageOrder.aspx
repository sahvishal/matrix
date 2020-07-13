<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" AutoEventWireup="true" Inherits="App_Franchisor_FranchisorManageOrder" Title="Manage Orders" Codebehind="FranchisorManageOrder.aspx.cs" %>
<%@ Register Src="~/App/UCCommon/ucManageOrder.ascx" TagName="ucManageOrder" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%--<cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
         <Services>
                <asp:ServiceReference Path="/App/AutoCompleteService.asmx" />
            </Services>
    </cc1:ToolkitScriptManager>--%>
    <div>
        <uc1:ucManageOrder ID="ucManageOrder1" runat="server"></uc1:ucManageOrder>
    </div>
</asp:Content>

