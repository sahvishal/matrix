<%@ Page Language="C#" MasterPageFile="~/Public/Public.master" AutoEventWireup="true"
    CodeBehind="CustomerDetailStep2.aspx.cs" Inherits="Falcon.App.UI.Public.GiftCertificates.CustomerDetailStep2"
    Title="Customer Details" %>

<%@ Register Src="~/Public/Controls/ucUserLoginInfo.ascx" TagName="ucUserLoginInfo"
    TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="float:left;padding:7px 0 0 15px"><img src="/Content/Images/Step4-gc.gif" alt="" /></div>
    <div class="maindiv_errormsgnew" enableviewstate="false" visible="false" id="divErrortop"
        runat="server">
        <p class="topbg_errormsgnew">
            <img src="<%= ResolveUrl("~/Content/images/spacer.gif") %>" width="663px" height="7px" /></p>
        <div class="midbg_errormsgnew">
            <span style="float: left; padding: 0px 10px 0px 10px">
                <img src="/Content/Images/error-icon.gif" /></span> <span id="spErrorMsgtop" runat="server"
                    class="txt_errormsgnew"></span>
        </div>
        <p class="botbg_errormsgnew">
            <img src="<%= ResolveUrl("~/Content/images/spacer.gif") %>" width="663px" height="7px" /></p>
    </div>
    <div style="float: left">
        <uc1:ucUserLoginInfo ID="ucUserLoginInfo" runat="server" OnErrorGeneratedOnClick="ErrorGeneratedOnClick" />
    </div>
    <div class="maindiv_errormsgnew" enableviewstate="false" visible="false" id="divErrorbottom"
        runat="server" style="margin-left: 0px">
        <p class="topbg_errormsgnew">
            <img src="<%= ResolveUrl("~/Content/images/spacer.gif") %>" width="663px" height="7px" /></p>
        <div class="midbg_errormsgnew">
            <span id="spErrorMsgbottom" runat="server" class="txt_errormsgnew" style="padding-left: 10px">
            </span>
        </div>
        <p class="botbg_errormsgnew">
            <img src="<%= ResolveUrl("~/Content/images/spacer.gif") %>" width="663px" height="7px" /></p>
    </div>
</asp:Content>
