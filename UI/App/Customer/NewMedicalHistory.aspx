<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewMedicalHistory.aspx.cs" Inherits="Falcon.App.UI.App.Customer.NewMedicalHistory" %>


<%@ Register Src="../UCCommon/ucMedicalHistory.ascx" TagName="ucMedicalHistory" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" style="background-color: #fff; overflow-x: hidden;">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../StyleSheets/Franchisor.css" rel="stylesheet" type="text/css" />
    <link type="text/css" href="/App/jquery/css/ui-lightness/jquery-ui-1.7.2.custom.css"
        rel="Stylesheet" />
    <script src="/scripts/jquery-1.5.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="/Scripts/jquery-ui-1.8.12.custom.min.js"></script>
</head>
<body style="background-color: #fff;">
    <form id="form1" runat="server">
    <div style="float: left; width: 840px; border-bottom: solid 1px gray;">
        <uc1:ucMedicalHistory ID="UcMedicalHistory1" runat="server" />
    </div>
    <div style="float: left; width: 820px; text-align: right; margin-top: 5px;">
        <asp:ImageButton runat="server" ID="ibtnSave" ImageUrl="~/App/Images/save-button.gif" OnClick="ibtnSave_Click" OnClientClick="return saveData();" />
    </div>
    <script language="javascript" type="text/javascript">
        var readonly = '<%= ReadOnly %>' == '<%= Boolean.TrueString%>';
        $(document).ready(function () { getHealthAssesmentForm('<%= CustomerId %>', '<%= EventId %>', readonly); });

        function saveData() {
            if (dataSaveFired) return true;

            if (!ValidateHealthQuestionsOnline()) {
                var confirmation = confirm("Are you sure you want to continue without completing all questions?");
                if (!confirmation)
                    return false;
            }

            saveHealthAssesmentForm(function () {
                dataSaveFired = true;
                $("#<%= ibtnSave.ClientID %>").click();
            });

            return false;
        }

        var dataSaveFired = false;

    </script>
    </form>
</body>
</html>
