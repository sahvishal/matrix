<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Public/Public.master"
    CodeBehind="GiftCertificateSample.aspx.cs" Inherits="Falcon.App.UI.Public.GiftCertificates.GiftCertificateSample" Title="Gift Certificate"%>

<%@ Register Src="~/App/UCCommon/GiftCertificatePreview.ascx" TagName="GiftCertificatePreview"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <img src="/Content/Images/Step6-gc.gif" alt="" />
    <div id="GiftCertificateContainerDiv" style="float: left">
        <uc1:GiftCertificatePreview ID="GiftCertificatePreview" runat="server" />
    </div>
</asp:Content>
