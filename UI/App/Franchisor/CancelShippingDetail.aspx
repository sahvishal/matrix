<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CancelShippingDetail.aspx.cs"
    MasterPageFile="~/App/Franchisor/FranchisorMaster.master" Inherits="Falcon.App.UI.App.Franchisor.CancelShippingDetail"
    Title="Cancel Shipping Details" %>

<%@ Register Src="~/App/Shipping/UserControl/CancelShippingDetail.ascx" TagName="CancelShipping"
    TagPrefix="uc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="wrapper_inpg">
        <uc:CancelShipping ID="CancelShippingControl" runat="server" />
    </div>
</asp:Content>
