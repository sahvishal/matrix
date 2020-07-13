<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EventCustomerInformation.ascx.cs"
    Inherits="Falcon.App.UI.App.UCCommon.EventCustomerInformation" %>
<%@ Register Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" TagPrefix="JQueryControl" %>
<%@ Register Src="~/App/UCCommon/ViewOrderDetails.ascx" TagName="ViewOrderDetails"    TagPrefix="orderDetails" %>
<JQueryControl:JQueryToolkit ID="JQueryToolkit1" runat="server" IncludeJQueryUI="true"
    IncludeJQueryCorner="true" />
 <orderDetails:ViewOrderDetails ID="_viewOrderDetailsControl" runat="server" />
<div class="main_area_bdrnone" style="margin-bottom:10px">
    <div id="screeninginfotop" class="greycrnrbox_sinfo">
        Screening Information
    </div>
    <div id="screeninginfobdy" class="gboxcrnrbdy_sinfo">
        <div class="gboxinrow">
            <span class="titletext_default">Event (<asp:Label ID="EventIdLabel" runat="server" />):</span>
            <span class="ttxtnowidthnormal_default">
                <asp:Label ID="EventNameLabel" runat="server" />
                [<asp:Label ID="EventStatusLabel" runat="server" CssClass="orngbold12_default" />]
            </span>
        </div>
        <div class="gboxinrow">
            <span class="titletext_default">Appointment Time:</span>
            <asp:Label ID="AppointmentTimeLabel" runat="server" CssClass="ttxtnowidthnormal_default" />
        </div>
        <%--<div class="gboxinrow">
            <span class="titletext_default">Package:</span>
            <asp:Label ID="PackageNameLabel" runat="server" CssClass="ttxtnowidthnormal_default" />
        </div>--%>
        <div class="gboxinrow">
            <span class="titletext_default">Order:</span>
            <a id="_orderLinkAnchor" runat="server" href="javascript:void(0);">View Detail</a>
        </div>
        <div class="gboxinrow">
            <span class="titletext_default">Cost:</span>
            <asp:Label ID="PackageCostLabel" runat="server" CssClass="ttxtnowidthnormal_default"></asp:Label>
        </div>
        <div class="gboxinrow">
            <span class="titletext_default">Shipping Option:</span>
            <asp:Label ID="ShippingOptionLabel" runat="server" CssClass="ttxtnowidthnormal_default" />
        </div>
    </div>
</div>

<script type="text/javascript">
    $(document).ready(function() {
        $('#screeninginfotop').corner("top");
        $('#screeninginfobdy').corner("bottom");

        var decoded = $("<textarea/>").html($("#<%= EventNameLabel.ClientID %>").html()).text();
        $("#<%= EventNameLabel.ClientID %>").html(decoded);
    });
    function ShowOrderDetailPopUp(orderId, orderTotal, paymentTotal, amountOwed, customerName, customerId) {
        ShowOrderDetailsDialog(orderId, orderTotal, paymentTotal, amountOwed, customerName, customerId);
        return false;
    }
</script>

