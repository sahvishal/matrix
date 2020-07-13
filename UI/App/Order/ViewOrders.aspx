<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewOrders.aspx.cs" Title="View Orders"
MasterPageFile="~/App/Franchisor/FranchisorMaster.master" Inherits="Falcon.App.UI.App.Order.ViewOrders" %>
<%@ Register Src="../UCCommon/ViewOrders.ascx" TagName="ViewOrdersControl" TagPrefix="OrdersControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <OrdersControl:ViewOrdersControl ID="_viewOrdersControl" runat="server" />
</asp:Content>