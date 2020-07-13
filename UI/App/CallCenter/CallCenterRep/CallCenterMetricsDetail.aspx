<%@ Page Language="C#" MasterPageFile="~/App/CallCenter/CallCenterMaster.master" AutoEventWireup="true" CodeBehind="CallCenterMetricsDetail.aspx.cs" Inherits="Falcon.App.UI.App.CallCenter.CallCenterRep.CallCenterMetricsDetail" Title="Untitled Page" %>

<%@ Register Src="~/App/UCCommon/ucCallCenterMetricsDetail.ascx" TagName="MetricsDetails" TagPrefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:MetricsDetails runat="server" Id="CallCenterMetricDetail"></uc1:MetricsDetails>
</asp:Content>
