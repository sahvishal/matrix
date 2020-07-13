<%@ Page Language="C#" MasterPageFile="~/App/Customer/CustomerMaster.master" AutoEventWireup="true" Inherits="App_Customer_TestMasterPage" Title="Untitled Page" Codebehind="TestMasterPage.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style="float:left">
<object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0" width="600" height="100">
      <param name="movie" value="test.swf" />
      <param name="quality" value="high" />
      <embed src="../Images/customer/test.swf"" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" width="600" height="100"></embed>
    </object>
    </div>
</asp:Content>

