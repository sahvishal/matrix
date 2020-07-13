<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MedicalHistory.aspx.cs"
    Inherits="HealthYes.Web.App.Common.MedicalHistory" %>
<%@ Import Namespace="Falcon.App.Core.Application.Impl" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>
<%@ Register Src="../UCCommon/ucMedicalHistory.ascx" TagName="ucMedicalHistory" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <script src="/scripts/jquery-1.5.2.min.js" type="text/javascript"></script>
</head>
<body style="background-color: #fff;width: 945px;">
    <form id="form1" runat="server">
        <% var sessioncontext = IoC.Resolve<SessionContext>();
           var isCallCenterAgent = sessioncontext.UserSession != null && sessioncontext.UserSession.CurrentOrganizationRole != null && sessioncontext.UserSession.CurrentOrganizationRole.GetSystemRoleId == (long)Falcon.App.Core.Enum.Roles.CallCenterRep;
        %>
        <div style="float:left; width: 935px; text-align: right; margin-top: 5px;margin-bottom: 5px;" class="kyn-medical-history-btn">
             <asp:ImageButton runat="server" ID="saveButtonTop" ImageUrl="~/App/Images/save-button.gif" OnClick="ibtnSave_Click" OnClientClick="return saveData();" />
        </div>
        <div style="float:left;width: 945px; border-bottom: solid 1px gray;" id="kyn-medical-history">
            <uc1:ucMedicalHistory ID="UcMedicalHistory1" runat="server" />
        </div>
        <div style="float:left;width: 935px; text-align: right; margin-top: 5px;" class="kyn-medical-history-btn">
            <asp:ImageButton runat="server" ID="ibtnSave" ImageUrl="~/App/Images/save-button.gif"
                OnClick="ibtnSave_Click" OnClientClick="return saveData();" />
        </div>
        <script language="javascript" type="text/javascript">

            $(document).ready(function () { getHealthAssesmentForm('<%= CustomerId %>', '<%= EventId %>', false, '<%= ShowKyn %>');
                changeFormWidthForKyn();
            });


            function saveData() {
                $(".kyn-medical-history-btn").hide();

                if (dataSaveFired) return true;

                if ('<%= isCallCenterAgent %>' == "<%= Boolean.TrueString%>") {
                    if (!ValidateHealthQuestionsWithHighLightedText()) {
                        $(".kyn-medical-history-btn").show();
                        return false;
                    }
                } else {
                    if (!ValidateHealthQuestions()) {
                        $(".kyn-medical-history-btn").show();
                        return false;
                    }
                }

                saveHealthAssesmentForm(function () {
                    dataSaveFired = true;
                    $("#<%= ibtnSave.ClientID %>").click();
                });

                return false;
            }

            var dataSaveFired = false;
            function changeFormWidthForKyn() {

                if ('<%= ShowKyn %>' == "<%= Boolean.TrueString%>") {
                    $("#kyn-medical-history").css('width','960px');
                    $(".kyn-medical-history-btn").css('width','945px');
                }

        }
        </script>
    </form>
</body>
</html>
