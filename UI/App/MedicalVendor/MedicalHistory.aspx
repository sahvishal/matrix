<%@ Page Language="C#" AutoEventWireup="true" Inherits="App_MedicalVendor_MedicalHistory"
    CodeBehind="MedicalHistory.aspx.cs" %>

<%@ Register Src="~/App/UCCommon/ucMedicalHistory.ascx" TagName="ucMedicalHistory" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" style="overflow: scroll;">
<head runat="server">
    <title>Health Assessment Form</title>
    <link href="../StyleSheets/Wizardstyle.css" rel="stylesheet" type="text/css" />
    <script src="/scripts/jquery-1.5.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        function BackPage() {//debugger
            window.history.go(-1);
            return false;
        }
        $(document).ready(function () { getHealthAssesmentForm('<%= CustomerId %>', '<%= EventId %>', true); });


    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="maindiv_mh">
        <div style="float:left;width: 945px; border-bottom: solid 1px gray;" id="kyn-medical-history">
        <uc1:ucMedicalHistory ID="UcMedicalHistory1" runat="server" />    
        </div>
    </div>
    </form>
</body>
</html>
