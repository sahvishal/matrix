<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Public/Public.master"
    CodeBehind="Catalog.aspx.cs" Inherits="Falcon.App.UI.Public.GiftCertificates.Catalog"
    Title="Gift Certificate Catalog" %>
<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.Core.Interfaces" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>

<%@ Register Src="~/App/UCCommon/GiftCertificateCatalog.ascx" TagPrefix="uc" TagName="GiftCertificateCatalog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="divouter_pw">
        <div style="font: 13px verdana; color:#000"><br />Are you looking for a perfect gift to show that special someone just how important they are to you?  
           If so, a <%= IoC.Resolve<ISettings>().CompanyName %><font size="-2"><sup>&#0174;</sup></font> Gift Certificate is the perfect way to &ldquo;give the gift of health&rdquo; to someone you love.  Simply <u>click</u> on 
           'Buy Gift Certificate' next to the appropriate gift certificate below, or enter a custom amount.  After a few simple steps, you will be able to provide 
           that special someone a Gift Certificate which is valid at any <%= IoC.Resolve<ISettings>().CompanyName %><font size="-2"><sup>&#0174;</sup></font> Preventive Screening.
           <br /><br />
           If you are looking to schedule a screening for yourself, please <span class="biglnk"><a href="/Public/Events/Default.aspx" >click here</a></span>.
         </div>
        <span class="headingtxt">Step 1: Select a Gift Certificate</span>
    </div>
    <uc:GiftCertificateCatalog runat="server" ID="giftCertificateCatalog"></uc:GiftCertificateCatalog>
</asp:Content>
