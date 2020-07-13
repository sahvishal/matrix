<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" AutoEventWireup="true" Inherits="App_Franchisor_blankdiv" Codebehind="blankdiv.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="maindiv_sr">
<div class="dggrid_sr"></div>
<p class="butoncell_sr">
<span class="btncon_sr"><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/App/Images/close-button.gif" />  </span>
</p>
</div>

<div class="divbtnright">
<p class="btncellright">
<span class="buttoncon_default"><asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/App/Images/cancel-button.gif" /></span>

<span class="buttoncon4_default"><asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/App/Images/save-n-continue.gif" /> </span>
</p>

</div>



</asp:Content>