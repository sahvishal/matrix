<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" 
Title="Medical Vendor Payment Reports: By Pod" Inherits="Falcon.App.UI.App.Franchisor.Reports.MedicalVendorPaymentsByPod" %>
<%@ Register src="../../UCCommon/JQueryToolkit.ascx" tagname="JQueryToolkit" tagprefix="JQueryControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <JQueryControl:JQueryToolkit ID="JQueryToolkit1" runat="server" IncludeJQueryUI="true" IncludeJTemplate="true"
        IncludeSexyComboBox="true" />
    <div id="MedicalVendorPaymentsByPodDiv" style="width: 750px; margin-left: 20px;">
        <h1>Medical Vendor Payments by Pod</h1>
        <div id="tabs" style="overflow: hidden; min-height: 300px;">
            <ul>
                <li><a href="<%= ResolveUrl("~/App/Franchisor/Reports/MedicalVendorPaymentsByPodByInvoice.aspx") %>">By Single Invoice</a></li>
                <li><a href="<%= ResolveUrl("~/App/Franchisor/Reports/MedicalVendorPaymentsByPodByDate.aspx") %>">By Date Range</a></li>
                <%--<li><a href="">By Single Pod</a></li>--%>
            </ul>
        </div>
    </div>
    <script type="text/javascript" language="javascript">
        $(document).ready(function() 
        {
            $('#tabs').tabs();
        });
    </script>
</asp:Content>