<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PackageSelection.aspx.cs"
    Inherits="Falcon.App.UI.App.Package.PackageSelection" %>

<%@ Register Src="~/App/UCCommon/OrderItemCart.ascx" TagName="ItemCart" TagPrefix="uc" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <uc:ItemCart ID="ItemCartControl" runat="server" />
    </div>
    </form>
</body>
</html>
