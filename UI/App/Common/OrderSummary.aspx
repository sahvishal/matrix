<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="OrderSummary.aspx.cs"
    Inherits="Falcon.App.UI.App.Common.OrderSummary" %>

<%@ Register Src="~/App/UCCommon/ViewOrderDetails.ascx" TagName="ViewOrderDetail"
    TagPrefix="vod" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link type="text/css" href="<%=ResolveUrl("~/App/jquery/css/ui-lightness/jquery-ui-1.7.2.custom.css")%>"
        rel="Stylesheet" />
        <link type="text/css" href="../StyleSheets/UC.css"
        rel="Stylesheet" />
        <link type="text/css" href="../StyleSheets/CommonStyle.css"
        rel="Stylesheet" />
    <script src="/scripts/jquery-1.5.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="/Scripts/jquery-ui-1.8.12.custom.min.js"></script>
    <link type="text/css" href="/Content/Styles/jquery-ui-1.8.12.custom.css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="float:left; padding: 0px 15px; width:700px;">
        <vod:ViewOrderDetail runat="server" ID="ViewOrderDetail" />
    </div>
    </form>
</body>
</html>
