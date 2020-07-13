<%@ Page Language="C#" MasterPageFile="~/App/MedicalVendor/MedicalVendorMaster.master" AutoEventWireup="true" 
Inherits="Falcon.App.UI.App.MedicalVendor.MedicalVendorDashboard" Codebehind="MVDashBoard.aspx.cs" Title="Medical Vendor Dashboard" %>
<%@ Register Src="../UCCommon/LastLogin.ascx" TagName="LastLogin" TagPrefix="LastLoginControl" %>
<%@ Register src="../UCCommon/JQueryToolkit.ascx" tagname="JQueryToolkit" tagprefix="JQueryControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <JQueryControl:JQueryToolkit ID="JQueryToolkit1" runat="server" IncludeJQueryUI="true" IncludeJTemplate="true" />
    <LastLoginControl:LastLogin ID="LastLogin1" runat="server" />
    <h1>Medical Vendor Dashboard</h1>
    <div id="DoctorTabs" style="overflow:hidden;">
        <ul> 
            <li><a href="<%= ResolveUrl("~/App/MedicalVendor/PhysicianSummary.aspx") %>">Physician Summary</a></li>
            <li><a href="<%= ResolveUrl("~/App/MedicalVendor/EarningSummary.aspx") %>">Earning Summary</a></li>
            <li><a href="<%= ResolveUrl("~/App/MedicalVendor/PaymentSummary.aspx") %>">Payment Summary</a></li>
        </ul>
        <div id="TabContentDiv">&nbsp;</div>
    </div>
    
    <script type="text/javascript" language="javascript">
        $(document).ready(function()
        {
            $('#DoctorTabs').tabs();
        })
    </script>
</asp:Content>