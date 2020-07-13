<%@ Page Language="C#" MasterPageFile="~/App/Franchisee/Technician/TechnicianMaster.master" AutoEventWireup="true" CodeBehind="TechnicianRescheduleCustomerAppointment.aspx.cs"
     Inherits="App_Franchisee_Technician_TechnicianRescheduleCustomerAppointment" EnableEventValidation="false" %>

<%@ Register Src="../../UCCommon/UCChangeAppointment.ascx" TagName="UCChangeAppointment"
    TagPrefix="uc1" %>


<asp:Content ID="content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="scrptmgr_foreventappointmentuc" EnablePageMethods="true">
    </asp:ScriptManager>
 
    <uc1:UCChangeAppointment ID="UCChangeAppointment1" runat="server" />
 
</asp:Content>