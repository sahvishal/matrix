<%@ Control Language="C#" AutoEventWireup="true" Inherits="App_UCCommon_ucMedicalHistory"
    CodeBehind="ucMedicalHistory.ascx.cs" %>
<%@ Import Namespace="Falcon.App.Core.Application.Impl" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>
<% var sessioncontext = IoC.Resolve<SessionContext>();
   var isCustomer = sessioncontext.UserSession != null && sessioncontext.UserSession.CurrentOrganizationRole != null && sessioncontext.UserSession.CurrentOrganizationRole.GetSystemRoleId == (long)Falcon.App.Core.Enum.Roles.Customer;
%>
<script type="text/javascript" language="javascript">

    $.ajaxSetup({
        cache: false
    });

    function makeFormReadonly() {
        $('#divcontent_haf').find('input[type="radio"]').attr('disabled', 'disabled');
        $('#divcontent_haf').find('input[type="checkbox"]').attr('disabled', 'disabled');
        $('#divcontent_haf').find('input[type="text"]:visible').attr('disabled', 'disabled');
        $('#divcontent_haf').find('textarea').attr('disabled', 'disabled');
    }

    function addBorder() {
        $('#divcontent_haf').find('input[type="text"]:visible').addClass('input-text-border');
        $('#divcontent_haf').find('textarea').addClass('input-text-border');
        $('#divcontent_haf, #DisclaimerDiv').find('input[type="checkbox"]:visible').addClass('input-text-border');
    }

    var dataLoaded = false;

    function adjustKynDiv() {
        $('.kyn-medication').css('width', '98%');
        $('.kyn-medication .front-radio-block').css('width', '22%');
        $('.kyn-lifestyle').css('width', '98%');
        $('.kyn-lifestyle .front-radio-block').css('width', '22%');
        $('.kyn-lifestyle .front-radio-block-not-required').css('width', '22%');
        $('.kyn-lifestyle').css('margin-left', '0px');
        $('.not-evaluated').css('margin-right', '0px');
    }
    function getHealthAssesmentForm(customerId, eventId, modeReadonly, showkyn) {
        showkyn = showkyn != null && showkyn == "True";
        $.ajax({
            url: '/Medical/Results/HealthAssessmentForm?customerId=' + customerId + "&eventId=" + eventId + "&version=0&showkyn=" + showkyn,
            type: 'Get',
            data: '{}',
            dataType: 'html',
            success: function (htmlData) {
                $("#divcontent_haf").html(htmlData);
                adjustKynDiv();

                if ('<%= isCustomer %>' == "<%= Boolean.FalseString%>")
                  //  setControlswithDefaultAnswer();

                dataLoaded = true;
                if (modeReadonly != null && modeReadonly == true)
                    makeFormReadonly();
                //setMethodonFormSave
            }
        });
    }

    function getVersionedHealthAssesmentForm(customerId, eventId, versionnumber) {
        $.ajax({
            url: '/Medical/Results/HealthAssessmentForm?customerId=' + customerId + "&eventId=" + eventId + "&version=" + versionnumber,
            type: 'Get',
            data: '{}',
            dataType: 'html',
            success: function (htmlData) {
                $("#divcontent_haf").html(htmlData);
                adjustKynDiv();
                if ('<%= isCustomer %>' == "<%= Boolean.FalseString%>")
                    //setControlswithDefaultAnswer();

                dataLoaded = true;
                makeFormReadonly();

            }
        });
    }

    function saveHealthAssesmentForm(successMethod) {
        setMethodonFormSave(successMethod, errorMethod);
        saveForm();
    }

    function errorMethod(a) {
        alert("Some error occured while saving the data. Please re-try!");
    }

</script>
<div id="divcontent_haf" style="float: left; width: 100%;">
    <div style="width: 200px; margin: 0px auto; padding: 100px 0px; text-align: center;">
        <img src="/App/Images/loading_Big_orng.gif" alt="" />
    </div>
</div>
