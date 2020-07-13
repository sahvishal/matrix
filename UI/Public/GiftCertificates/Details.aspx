<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Public/Public.master"
    CodeBehind="Details.aspx.cs" Inherits="Falcon.App.UI.Public.GiftCertificates.Details" Title="Gift Certificate Details"%>

<%@ Register Src="~/App/UCCommon/GiftCertificateDetails.ascx" TagPrefix="uc" TagName="Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <div class="divouter_pw">	
	<span class="headingtxt">Step 2: Personalize your gift certificate</span>
</div>
<uc:Details runat="server" ID="GiftCertificateDetails" OnnavigateOnChangeAmountClick="NavigateOnChangeAmountClick"
        OnnavigateOnSubmitClick="NavigateOnSubmitClick" />
</asp:Content>
