<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" AutoEventWireup="true" Inherits="App_Franchisee_SalesRep_SalesRepEventCustomerList" Codebehind="SalesRepEventCustomerList.aspx.cs" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Src="../../UCCommon/UCCustomerList.ascx" TagName="UCCustomerList" TagPrefix="uc1" %>

<asp:Content ID="content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
 <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <uc1:UCCustomerList ID="UCCustomerList1" runat="server" />

</asp:Content>

