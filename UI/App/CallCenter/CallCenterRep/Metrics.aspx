<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Metrics.aspx.cs" MasterPageFile="~/App/CallCenter/CallCenterMaster.master"
Inherits="Falcon.App.UI.App.CallCenter.CallCenterRep.Metrics" Title="Call Center Representative Metrics" %>
<%@ Register Src="~/App/UCCommon/ucCallCenterMetrics.ascx" TagName="Metrics" TagPrefix="uc1" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="content1" runat="server">

    <uc1:Metrics runat="server" ID="MetricsUserControl"></uc1:Metrics>
</asp:Content>