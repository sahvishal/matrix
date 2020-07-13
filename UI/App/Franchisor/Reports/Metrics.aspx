<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" AutoEventWireup="true" CodeBehind="Metrics.aspx.cs" Inherits="Falcon.App.UI.App.Franchisor.Reports.Metrics" Title="Call Center Metric" %>
<%@ Register Src="~/App/UCCommon/ucCallCenterMetrics.ascx" TagName="Metrics" TagPrefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Metrics runat="server" ID="MetricsUserControl"></uc1:Metrics>
</asp:Content>
