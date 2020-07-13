<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucEventPackageTest.ascx.cs"
    Inherits="Falcon.App.UI.App.UCCommon.ucEventPackageTest" %>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td colspan="2" style="font-weight: bold">
            <u>Order Detail</u>
        </td>
    </tr>
    <tr id="_lblPackageRow" runat="server">
        <td width="17%" valign="top">
            Package:
        </td>
        <td width="83%" valign="top">
            <b>
                <asp:Label ID="lblPackagename" runat="server" Text=""></asp:Label></b><br />
            <ul style="margin: 0 0 0 15px; padding: 0 0 0 10px" id="_lblTestNames" runat="server">
                  
            </ul>
        </td>
    </tr>
    <tr>
        <td valign="top">
            &nbsp;
        </td>
        <td valign="top">
            &nbsp;
        </td>
    </tr>
    <tr id="_lblAdditionalTestRow" runat="server">
        <td valign="top" id="AdditionalTest" runat="server" style="width:20%">
            Additional Test(s):
        </td>
        <td valign="top" style="width:80%">
            <ul style="margin: 0 0 0 15px; padding: 0 0 0 10px;" id="_lblAdditionalTestNames"
                runat="server">
            </ul>
        </td>
    </tr>
    <%--<tr id="_lblProductNameRow" runat="server">
        <td valign="top" style="width:20%">
            Product:
        </td>
        <td valign="top" style="width:80%">
            <b>
                <asp:Label ID="lblProductName" runat="server" Text=""></asp:Label></b>
        </td>
    </tr>--%>
    <tr>
        <td valign="top" style="width:20%">
            Screening Price:
        </td>
        <td valign="top" style="width:80%">
            <b>
                <asp:Label ID="lblPrice" runat="server" Text=""></asp:Label></b>
        </td>
    </tr>
    <tr id="_lblProductPriceRow" runat="server">
        <td valign="top" style="width:20%">
            Product Price:
        </td>
        <td valign="top" style="width:80%">
            <b>
                <asp:Label ID="lblProductPrice" runat="server" Text=""></asp:Label>
            </b>
        </td>
    </tr>
    <tr>
        <td valign="top" style="width:20%">
            Shipping Price:
        </td>
        <td valign="top" style="width:80%">
            <b>
                <asp:Label ID="lblShippingPrice" runat="server" Text=""></asp:Label>
            </b>
        </td>
    </tr>
    <tr>
        <td valign="top" style="width:20%">
            Order Value:
        </td>
        <td valign="top" style="width:80%">
            <strong>
                <asp:Label ID="lblTotalPrice" runat="server" Text=""></asp:Label>,
                <asp:Label ID="lblPaymentStatus" runat="server" Text=""></asp:Label></strong>
        </td>
    </tr>
</table>
