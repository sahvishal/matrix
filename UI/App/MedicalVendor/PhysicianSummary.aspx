<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PhysicianSummary.aspx.cs" 
    Inherits="Falcon.App.UI.App.MedicalVendor.PhysicianSummary" %>
<div id="PhysicianSummaryDiv"></div>
<script type="text/javascript" language="javascript">
    $(document).ready(function()
    {
        LoadPhysicians();
    })
    
    function LoadPhysicians()
    {
        var containerDiv = 'PhysicianSummaryDiv';
        var messageUrl = 
            '<%=ResolveUrl("~/App/Controllers/MedicalVendorController.asmx/GetMedicalVendorMedicalVendorUsers")%>';
        var parameter = "{'medicalVendorId':'" + <%= _medicalVendorId %> + "'}";
        var successFunction = function (returnData)
        {
            $('#' + containerDiv).setTemplateURL('<%=ResolveUrl("~/App/Templates/MedicalVendorMedicalVendorUserAggregates.html")%>');
            $('#' + containerDiv).processTemplate(returnData.d);

            // TODO: Move to CSS
            $("#MedicalVendorMedicalVendorUserAggregateTable th").css("background-color", "#DDF0F7");
            $("#MedicalVendorMedicalVendorUserAggregateTable tr:even").css("background-color", "#EFF8FD");
            $("#MedicalVendorMedicalVendorUserAggregateTable tr:odd").css("background-color", "#F8FCFF");
        }
        var numberOfRecordsFunction = function(returnData)
        {
            return returnData.d.length;
        }
        var errorMessage = 'An internal server error occurred when trying to load the Physician Summary.';
        AjaxCall(containerDiv, messageUrl, parameter, successFunction, errorMessage, numberOfRecordsFunction);
    }
</script>