<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" AutoEventWireup="true" CodeBehind="MetricDetail.aspx.cs" Inherits="Falcon.App.UI.App.Franchisor.Reports.MetricDetail" Title="Untitled Page" %>
<%@ Register Src="~/App/UCCommon/UcCallCenterMetricsDetail.ascx" TagName="MetricsDetails" TagPrefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:MetricsDetails runat="server" Id="CallCenterMetricDetail"></uc1:MetricsDetails>
</asp:Content>
