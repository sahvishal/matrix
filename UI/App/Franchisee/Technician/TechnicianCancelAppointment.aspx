<%@ Page Language="C#" MasterPageFile="~/App/Franchisee/Technician/TechnicianMaster.master" AutoEventWireup="true" Title="Cancel Customer Appointment"
Inherits="Falcon.App.UI.App.Franchisee.Technician.TechnicianCancelAppointment" Codebehind="TechnicianCancelAppointment.aspx.cs" EnableEventValidation="false" %>

<%@ Register Src="../../UCCommon/UCCancelAppointment.ascx" TagName="UCCancelAppointment"
    TagPrefix="uc1" %>

<asp:Content ID="content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCCancelAppointment ID="UCCancelAppointment1" runat="server" />
</asp:Content>
