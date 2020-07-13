<%@ Page Language="C#" AutoEventWireup="true" Inherits="App_Franchisor_MedicalHistory"
    CodeBehind="MedicalHistory.aspx.cs" %>
<%@ Import Namespace="Falcon.App.Core.Application.Impl" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>
<%@ Register Src="../UCCommon/ucMedicalHistory.ascx" TagName="ucMedicalHistory" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" style="background-color: #fff; overflow-x: hidden;">
<head runat="server">
    <title>Untitled Page</title>
    <link href="../StyleSheets/Franchisor.css" rel="stylesheet" type="text/css" />
    <link type="text/css" href="/App/jquery/css/ui-lightness/jquery-ui-1.7.2.custom.css"
        rel="Stylesheet" />
    <script src="/scripts/jquery-1.5.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="/Scripts/jquery-ui-1.8.12.custom.min.js"></script>
</head>
<body style="background-color: #fff;">
    <form id="form1" runat="server">
        <% var sessioncontext = IoC.Resolve<SessionContext>();
           var isCallCenterAgent = sessioncontext.UserSession != null && sessioncontext.UserSession.CurrentOrganizationRole != null && sessioncontext.UserSession.CurrentOrganizationRole.GetSystemRoleId == (long)Falcon.App.Core.Enum.Roles.CallCenterRep;
           var isTechnician = sessioncontext.UserSession != null && sessioncontext.UserSession.CurrentOrganizationRole != null && sessioncontext.UserSession.CurrentOrganizationRole.GetSystemRoleId == (long)Falcon.App.Core.Enum.Roles.Technician;
           var isNursePractitioner = sessioncontext.UserSession != null && sessioncontext.UserSession.CurrentOrganizationRole != null && sessioncontext.UserSession.CurrentOrganizationRole.GetSystemRoleId == (long)Falcon.App.Core.Enum.Roles.NursePractitioner;
        %>
        <div style="float: left; width: 1080px; border-bottom: solid 1px gray;">
            <uc1:ucMedicalHistory ID="UcMedicalHistory1" runat="server" />
        </div>
        <div style="float: left; width: 1080px; text-align: right; margin-top: 5px;">
            <asp:ImageButton runat="server" ID="ibtnSave" ImageUrl="~/App/Images/save-button.gif"
                OnClick="ibtnSave_Click" OnClientClick="return saveData();"  CssClass="medical-history-savebtn"/>
        </div>
        <script language="javascript" type="text/javascript">

            $(document).ready(function () { getHealthAssesmentForm('<%= CustomerId %>', '<%= EventId %>'); });

            function saveData() {
                $(".medical-history-savebtn").hide();
                if (dataSaveFired) return true;

                if ('<%= isCallCenterAgent %>' == "<%= Boolean.TrueString%>") {
                    if (!ValidateHealthQuestionsWithHighLightedText())
                    { $(".medical-history-savebtn").show(); return false; }
                }
                else {
                    if ('<%= isTechnician %>' == "<%= Boolean.TrueString%>" || '<%= isNursePractitioner %>' == "<%= Boolean.TrueString%>") {
                        if (!ValidateHealthQuestions()) {
                            $(".medical-history-savebtn").show();
                            return false;
                        }
                    }
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
