<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PreQualificationQuestion.ascx.cs"
	Inherits="Falcon.App.UI.App.UCCommon.PreQualificationQuestion" %>
<%@ Import Namespace="Falcon.App.Core.Extensions" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<%@ Import Namespace="Falcon.App.Core.Scheduling.Enum" %>
<%@ Register Src="JQueryToolkit.ascx" TagName="JQueryToolkit" TagPrefix="JQueryControl" %>
<JQueryControl:JQueryToolkit ID="_jQueryToolkit1" runat="server" IncludeJQueryUI="true"
	IncludeJTemplate="true" IncudeJQueryJTip="true" />
 
<div id="LoadingDiv" class="loading-div" style="display: none">
	<span class="left-text">Please Wait...</span> <span class="left">
		<img src="/App/Images/loading.gif" alt="" /></span>
</div>
 
  
 <style type="text/css">
    .radio-question-block {
        width: 15%;
        float: left;
        margin-left: 20px;
    }

    .question-line-height {
        margin-bottom: 5px;
        margin-top: 5px;
    }
    .no-close .ui-dialog-titlebar-close {
        display: none;
    }
</style> 
<div id="package-selection-info-dialog" class="jdbox" style="display: none;">
    <div id="package-selection-info">
        <div class="left-float container" style="width: 685px;">
            <div class="header-title" style="float: left; width: 665px;">
                <strong>The following information will help us customize a package for you.</strong>
            </div>
            <div class="skipContinueQuestions">
                    <div class="sequence-block" questionname="ChestPain" style="clear: both;">
                        <div style="margin-left: 10px; float: left; width: 80%; margin-bottom: 5px; margin-top: 5px;" class="question-line-height">
                            1. Have you experienced severe chest pain from exertion, activity, or while at rest within the last 4 days?
                        </div>
                        <div class="front-radio-block radio-question-block question-line-height">
                            <span>
                                <input type="radio" value="<%=(long)OnlineScreeningQuestionAnswers.AnswerYes%>" name="chestPain_raidogrp" />
                              <%=OnlineScreeningQuestionAnswers.AnswerYes.GetDescription() %>  
                            </span>
                            <span>
                                <input type="radio" value="<%=(long)OnlineScreeningQuestionAnswers.AnswerNo%>  " name="chestPain_raidogrp" />
                                <%=OnlineScreeningQuestionAnswers.AnswerNo.GetDescription() %>  
                            </span>
                        </div> 
                        <input type="hidden" id="ChestPain" value="0"/>
                    </div>
                    <div class="sequence-block" questionname="DiagnosedHeartProblem" style="clear: both;">
                        <div style="margin-left: 10px; float: left; width: 80%" class="question-line-height">
                            2. In the last 30 days have you seen a Cardiologist for a diagnosed heart condition?
                        </div>
                        <div class="front-radio-block radio-question-block question-line-height">
                            <span>
                                <input type="radio" value="<%=(long)OnlineScreeningQuestionAnswers.AnswerYes%>" name="diagnoseheartProblem_radiogrp" />
                                <%=OnlineScreeningQuestionAnswers.AnswerYes.GetDescription() %>  
                            </span>
                            <span>
                                <input type="radio" value="<%=(long)OnlineScreeningQuestionAnswers.AnswerNo%>" name="diagnoseheartProblem_radiogrp" />
                                <%=OnlineScreeningQuestionAnswers.AnswerNo.GetDescription() %>  
                            </span> 
                            <input type="hidden" id="DiagnosedHeartProblem" value="0" />
                        </div>
                    </div>


                    <div class="sequence-block" questionname="HighBloodPressure" style="clear: both;">
                        <div style="margin-left: 10px; float: left; width: 80%" class="question-line-height">
                            3. Have you ever been told you have high blood pressure?
                        </div>
                        <div class="front-radio-block radio-question-block question-line-height">
                            <span>
                                <input type="radio" value="<%=(long)OnlineScreeningQuestionAnswers.AnswerYes %>" name="highhloodpressure_radiogrp" />
                                <%=OnlineScreeningQuestionAnswers.AnswerYes.GetDescription() %>  
                            </span>
                            <span>
                                <input type="radio" value="<%=(long)OnlineScreeningQuestionAnswers.AnswerNo %>" name="highhloodpressure_radiogrp" />
                                <%=OnlineScreeningQuestionAnswers.AnswerNo.GetDescription() %>  
                            </span> 
                            <input type="hidden" id="HighBloodPressure" value="0" />
                        </div>
                    </div>
                    <div class="sequence-block" questionname="HighCholestrol" style="clear: both;">
                        <div style="margin-left: 10px; float: left; width: 80%" class="question-line-height">
                            4. Have you ever been told you have elevated cholesterol?
                        </div>
                        <div class="front-radio-block radio-question-block question-line-height">
                            <span>
                                <input type="radio" value="<%=(long)OnlineScreeningQuestionAnswers.AnswerYes %>" name="highcholestrol_radiogrp" />
                                <%=OnlineScreeningQuestionAnswers.AnswerYes.GetDescription() %>  
                            </span>
                            <span>
                                <input type="radio" value="<%=(long)OnlineScreeningQuestionAnswers.AnswerNo %>" name="highcholestrol_radiogrp" />
                                <%=OnlineScreeningQuestionAnswers.AnswerNo.GetDescription() %>  
                            </span> 
                            <input type="hidden" id="HighCholestrol" value="0"/>
                        </div>
                    </div>
                    <div class="sequence-block" questionname="Smoker" style="clear: both;">
                        <div style="margin-left: 10px; float: left; width: 80%" class="question-line-height">
                            5. Do you currently smoke or have you smoked in the past?
                        </div>
                        <div class="front-radio-block radio-question-block question-line-height">
                            <span>
                                <input type="radio" value="<%=(long)OnlineScreeningQuestionAnswers.AnswerYes %>" name="smoker_radiogrp" />
                                <%=OnlineScreeningQuestionAnswers.AnswerYes.GetDescription() %>  
                            </span>
                            <span>
                                <input type="radio" value="<%=(long)OnlineScreeningQuestionAnswers.AnswerNo %>" name="smoker_radiogrp" />
                                <%=OnlineScreeningQuestionAnswers.AnswerNo.GetDescription() %>  
                            </span> 
                            <input type="hidden" id="Smoker" value="0"/>
                        </div>
                    </div>


                    <div class="sequence-block" questionname="HeartDisease" style="clear: both; margin-bottom: 5px; margin-top: 5px;">
                        <div style="margin-left: 10px; float: left; width: 80%" class="question-line-height">
                            6. Do you have a family history of any heart related disease or illness?
                        </div>
                        <div class="front-radio-block radio-question-block question-line-height">
                            <span>
                                <input type="radio" value="<%=(long)OnlineScreeningQuestionAnswers.AnswerYes %>" name="heartdisease_radiogrp" />
                                <%=OnlineScreeningQuestionAnswers.AnswerYes.GetDescription() %>  
                            </span>
                            <span>
                                <input type="radio" value="<%=(long)OnlineScreeningQuestionAnswers.AnswerNo %>" name="heartdisease_radiogrp" />
                                <%=OnlineScreeningQuestionAnswers.AnswerNo.GetDescription() %>  
                            </span> 
                            <input type="hidden" id="HeartDisease" value="0"/>
                        </div>
                    </div>
                    <div class="sequence-block" questionname="Diabetic" style="clear: both; margin-bottom: 5px; margin-top: 5px;">
                        <div style="margin-left: 10px; float: left; width: 80%" class="question-line-height">
                            7. Are you a diabetic or have been told you are a diabetic?
                        </div>
                        <div class="front-radio-block radio-question-block question-line-height">
                            <span>
                                <input type="radio" value="<%=(long)OnlineScreeningQuestionAnswers.AnswerYes %>" name="diabetic_radiogrp" />
                                <%=OnlineScreeningQuestionAnswers.AnswerYes.GetDescription() %>  
                            </span>
                            <span>
                                <input type="radio" value="<%=(long)OnlineScreeningQuestionAnswers.AnswerNo %>" name="diabetic_radiogrp" />
                                <%=OnlineScreeningQuestionAnswers.AnswerNo.GetDescription() %>  
                            </span> 
                            <input type="hidden" id="Diabetic" value="0" />
                        </div>
                    </div>
                    <div class="sequence-block" questionname="OverWeight" style="clear: both; margin-bottom: 5px; margin-top: 5px;">
                        <div style="margin-left: 10px; float: left; width: 80%" class="question-line-height">
                            8. Are you overweight or have you been told you are overweight?
                        </div>
                        <div class="front-radio-block radio-question-block question-line-height">
                            <span>
                                <input type="radio" value="<%=(long)OnlineScreeningQuestionAnswers.AnswerYes %>" name="overweight_radiogrp" />
                                <%=OnlineScreeningQuestionAnswers.AnswerYes.GetDescription() %>  
                            </span>
                            <span>
                                <input type="radio" value="<%=(long)OnlineScreeningQuestionAnswers.AnswerNo %>" name="overweight_radiogrp" />
                                <%=OnlineScreeningQuestionAnswers.AnswerNo.GetDescription() %>  
                            </span> 
                            <input type="hidden" id="OverWeight" value="0" />
                        </div>
                    </div>
                </div>
        </div>
        <div class="right-float">
            <input type="button" id="skipContinueButton" value="Skip Questions" width="180px" class="ui-state-default"  onclick="skipPackageSelectionInfo();" />    
            <input type="button" value="Continue" style="width: 180px;"  class="ui-state-default"  onclick='validatePackageSelectionInfo();' />
        </div>
    </div>
</div>
  
<input type="hidden" id="SkipPreQualificationQuestion" value="<%= (SkipPreQualificationQuestion) %>"/> 
 <%-- this dialog box will open if customer is below 18 years  --%>
<div id="age-dialog-message" style="display: none;" class="jdbox">
    <p>
        Customers below <%=Settings.MinimumAgeForScreening%> years of age are not allowed for screening. In case of any queries, please call us at&nbsp;<%=Settings.PhoneTollFree %>
    </p>
</div>

<%--  disclaimer 1--%> 
<div id="disclaimer-emergnecy-message" style="display: none;" class="jdbox">
    <p>
        Due to the symptoms you are experiencing, cardiac screenings may not be appropriate for you. We encourage you to contact you physician or 911 immediately.
    </p>
</div>
 <%--disclaimer 2--%> 
<div id="disclaimer-diagnosed-heart-problem" style="display: none;" class="jdbox">
    <p>
        Since you are currently under the care of a Cardiologist, the cardiac screenings may not be appropriate for you. We encourage you to follow up with your Cardiologist or Primary Care Physician for further evaluation.
    </p>
</div>

  <%--disclaimer 3  --%>
<div id="disclaimer-normal-message" style="display: none;" class="jdbox">
    <p>
        Based on your responses, you are low risk. However, if you would like to continue in scheduling an appointment, I would be more than happy to assist you or you can  <a href="javascript:void(0)" onclick="exitToSiteUrl()" id="exitbtn">Skip the registration</a>.
    </p>
</div>


<%-- disclaimer 4  --%>
<div id="disclaimer-low-risk-message" class="jdbox">
    <p>
        Based on your responses you exhibit risk which qualifies you to participate in our screenings.
    </p>
</div>



<script type="text/javascript" language="javascript">

    $.ajaxSetup({ cache: false });

    var eventId = '<%=EventId %>';
   
    var eventType = '<%=RegistrationMode %>';
    var callId = '<%=CallId %>';
    var answeryes = '<%=OnlineScreeningQuestionAnswers.AnswerYes %>';
    var answerno = '<%=OnlineScreeningQuestionAnswers.AnswerNo %>';
    var guid = '<%=GuId %>';
    var customerId = '<%=CustomerId %>';
</script>

<script type="text/javascript" language="javascript"> 
    function getPackageSelectionInfo() {
        var packageSelectionInfo = new Object(); 

        if ('<%=AskPreQualifierQuestion %>' == '<%= Boolean.TrueString %>')
        {
            packageSelectionInfo.HighBloodPressure = $('#HighBloodPressure').val();
            packageSelectionInfo.HighCholestrol = $("#HighCholestrol").val();
            packageSelectionInfo.Smoker = $('#Smoker').val();
            packageSelectionInfo.HeartDisease = $('#HeartDisease').val();
            packageSelectionInfo.Diabetic = $('#Diabetic').val();
            packageSelectionInfo.ChestPain = $('#ChestPain').val();
            packageSelectionInfo.DiagnosedHeartProblem = $('#DiagnosedHeartProblem').val();
            packageSelectionInfo.OverWeight = $("#OverWeight").val();
        }
        packageSelectionInfo.SkipPreQualificationQuestion = $("#SkipPreQualificationQuestion").val();
        packageSelectionInfo.Dob = '<%= Dob %>';
        packageSelectionInfo.Gender = '<%= Gender %>';
        //packageSelectionInfo.ShowPreQualifiedQuestion = $('#ShowPreQualifiedQuestion').val();
        return packageSelectionInfo;
    }

    $("div.sequence-block input:radio").click(function () {
        $(this).closest("div.sequence-block").find("input:hidden").val($(this).val());
    });
    
    function validatePackageSelectionInfo() {
         
        var isAllQuestionAnswered = true;
        //debugger;
        if ($('#SkipPreQualificationQuestion').val() == "<%=Boolean.FalseString%>") {
            $("#package-selection-info").find("div.sequence-block input[type='hidden']").each(function () {
                var selected = parseInt($(this).val());
                if (selected <= 0 && ( selected != answeryes || selected != answerno)) {
                    isAllQuestionAnswered = false;
                }
            });
        }

        if (!isAllQuestionAnswered) {
            alert("Please answer all questions.");
            return false;
        }

       
        $("#package-selection-info-dialog").dialog("close");
    }
</script>
 
 
 
 
<%-- rules --%>

<script type="text/javascript" language="javascript">
    function getAge(dob) {
        var today = new Date();
        var birthDate = new Date(dob);
        var age = today.getFullYear() - birthDate.getFullYear();
        var m = today.getMonth() - birthDate.getMonth();
        if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
            age--;
        }

        return age;
    }

    function UpdateUserPrefrenceWithPrequalificationQuestion() {

        $.ajax({
            type: 'Post',
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            url: '/CallCenter/Prequalification/UpdateUserPrefrenceWithPrequalificationQuestion',
            data: "{'guid':'" + guid + "'}",
            'success': function () {
                //goToPackagePage();
            },
            'error': function () {
                //goToPackagePage();
            }
        });
    }

    function savePackageSelectionAfterDisclaimer() {
         
        var packageSelectionInfo = getPackageSelectionInfo();

        $.ajax({
            type: 'Post',
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            url: '/CallCenter/PreQualification/SavePreQualificationResult',
            data: "{'eventId':'" + eventId + "','customerId':'" + customerId + "','callId':'" + callId + "','guid':'" + guid + "','packageSelectionInfoEditModel' : " + JSON.stringify(packageSelectionInfo) + "}",
            'success': function () {
                savePackageSelectionInfo(packageSelectionInfo);
            },
            'error': function () {
                //goToPackagePage();
            }
        });
    }
    var minAge = '<%=Settings.MinimumAgeForScreening%>';
    var maximumAge = 45;

    var answeryes = '<%=(long)OnlineScreeningQuestionAnswers.AnswerYes%>';
    var answerno = '<%=(long)OnlineScreeningQuestionAnswers.AnswerNo%>';

    var noOfYesAnsweredByCustomer = 0;
    var noOfNoAnsweredByCustomer = 0;

    function savePackageSelectionInfo(packageSelectionInfo) {
        //debugger;
        noOfYesAnsweredByCustomer = 0;
        noOfNoAnsweredByCustomer = 0; 
        if (packageSelectionInfo.SkipPreQualificationQuestion=='<%= Boolean.TrueString %>' && packageSelectionInfo.Dob!="" && packageSelectionInfo.Gender>0 ) {
            //goToPackagePage();
        } else {

            if ('<%=AskPreQualifierQuestion %>' == '<%= Boolean.TrueString %>')
            {
                showDisclaimerNormalCustomer(packageSelectionInfo);

                if(packageSelectionInfo.ChestPain==answeryes)
                {
                    $("#disclaimer-emergnecy-message").dialog("open");
                }
                else if (packageSelectionInfo.DiagnosedHeartProblem == answeryes) {
                    $("#disclaimer-diagnosed-heart-problem").dialog("open");
                }
                else if (packageSelectionInfo.Dob!="" && getAge(packageSelectionInfo.Dob)<parseInt(minAge)) {
                    $("#age-dialog-message").dialog("open");
                }
                else if (noOfYesAnsweredByCustomer>=2) {
                    $("#disclaimer-low-risk-message").dialog("open");
                }
                else if (noOfNoAnsweredByCustomer>=6) {
                    UpdateUserPrefrenceWithPrequalificationQuestion();
                    $(".disclaimer-normal-message-header").html($("#disclaimer-normal-message").html());
                    $(".disclaimer-normal-message-header").show();
                }
            }
            else
            {
                if (packageSelectionInfo.Dob!="" && getAge(packageSelectionInfo.Dob)<parseInt(minAge)) {
                    $("#age-dialog-message").dialog("open");
                }
                else
                {
                    UpdateUserPrefrenceWithPrequalificationQuestion();
                }
            }
        }
    }

   
 
     
    function showDisclaimerNormalCustomer(packageSelectionInfo) {

        //Are you age 45 or older
        if (packageSelectionInfo.Dob != "" && getAge(packageSelectionInfo.Dob) < parseInt(maximumAge)) {
            noOfNoAnsweredByCustomer = noOfNoAnsweredByCustomer + 1;
        } else if (packageSelectionInfo.Dob != "" && getAge(packageSelectionInfo.Dob) >= parseInt(maximumAge)) {
            noOfYesAnsweredByCustomer = noOfYesAnsweredByCustomer + 1;
        }

        //have you ever been told you have high blood pressure
        if (packageSelectionInfo.HighBloodPressure == answerno) {
            noOfNoAnsweredByCustomer = noOfNoAnsweredByCustomer + 1;
        } else if (packageSelectionInfo.HighBloodPressure == answeryes) {
            noOfYesAnsweredByCustomer = noOfYesAnsweredByCustomer + 1;
        }

        //have you ever been told you have elevated cholesterol
        if (packageSelectionInfo.HighCholestrol == answerno) {
            noOfNoAnsweredByCustomer = noOfNoAnsweredByCustomer + 1;
        } else if (packageSelectionInfo.HighCholestrol == answeryes) {
            noOfYesAnsweredByCustomer = noOfYesAnsweredByCustomer + 1;
        }

        //Do you currenty smoke or have you smoked in the past
        if (packageSelectionInfo.Smoker == answerno) {
            noOfNoAnsweredByCustomer = noOfNoAnsweredByCustomer + 1;
        } else if (packageSelectionInfo.Smoker == answeryes) {
            noOfYesAnsweredByCustomer = noOfYesAnsweredByCustomer + 1;
        }

        //Do you have a family history of any heart realted disease or iliness
        if (packageSelectionInfo.HeartDisease == answerno) {
            noOfNoAnsweredByCustomer = noOfNoAnsweredByCustomer + 1;
        } else if (packageSelectionInfo.HeartDisease == answeryes) {
            noOfYesAnsweredByCustomer = noOfYesAnsweredByCustomer + 1;
        }

        //Diabetic
        if (packageSelectionInfo.Diabetic == answerno) {
            noOfNoAnsweredByCustomer = noOfNoAnsweredByCustomer + 1;
        } else if (packageSelectionInfo.Diabetic == answeryes) {
            noOfYesAnsweredByCustomer = noOfYesAnsweredByCustomer + 1;
        }

        //OverWeight
        if (packageSelectionInfo.OverWeight == answerno) {
            noOfNoAnsweredByCustomer = noOfNoAnsweredByCustomer + 1;
        } else if (packageSelectionInfo.OverWeight == answeryes) {
            noOfYesAnsweredByCustomer = noOfYesAnsweredByCustomer + 1;
        }

    }
    function exitToSiteUrl() {
        if (callId > 0) {
            CallNotes();
        } else {
            var RedirectPath = "/App/CallCenter/CallCenterRep/AddNotes.aspx?guid=" + getParameterByName("guid")+"&Call=No";
            //var RootPath = window.location.protocol + "//" + window.location.host + "/App/";
            window.location = RedirectPath;
            return false;
        }
        
        //window.location.href = "";
    }
</script>
<script type="text/javascript" language="javascript">
    function getPackageSelectionInfoSaved() {
        var packageSelectionInfo = new Object();
        packageSelectionInfo.HighBloodPressure = 0;
         <% if(ObjPqr != null) { %>
        packageSelectionInfo.HighBloodPressure = '<%= ObjPqr.HighBloodPressure %>';
        packageSelectionInfo.HighCholestrol = '<%= ObjPqr.HighCholestrol %>';
        packageSelectionInfo.Smoker = '<%= ObjPqr.Smoker %>';
        packageSelectionInfo.HeartDisease = '<%= ObjPqr.HeartDisease %>';
        packageSelectionInfo.Diabetic = '<%= ObjPqr.Diabetic %>';
        packageSelectionInfo.ChestPain = '<%= ObjPqr.ChestPain %>';
        packageSelectionInfo.DiagnosedHeartProblem = '<%= ObjPqr.DiagnosedHeartProblem %>';
        packageSelectionInfo.OverWeight = '<%= ObjPqr.OverWeight %>';
         
        packageSelectionInfo.SkipPreQualificationQuestion = $("#SkipPreQualificationQuestion").val();
        packageSelectionInfo.Dob = '<%= Dob %>';
        packageSelectionInfo.Gender = '<%= Gender %>';
        //packageSelectionInfo.ShowPreQualifiedQuestion = $('#ShowPreQualifiedQuestion').val();
        <% } %>
        return packageSelectionInfo;
    }

</script>

<%-- this is going to be my function --%>  
<script type="text/javascript" language="javascript">
    function skipPackageSelectionInfo() {

        $("#SkipPreQualificationQuestion").val('<%=Boolean.TrueString%>');
        $("#package-selection-info-dialog").dialog("close");
    }

    function OpenQuestionDialog() {
        //debugger;
        var z = getPackageSelectionInfoSaved();
        if (z.HighBloodPressure > 0) {
            if ($('#SkipPreQualificationQuestion').val() == "<%=Boolean.FalseString%>" && '<%=AgreedWithPrequalificationQuestion%>' == '<%=Boolean.FalseString%>')
                savePackageSelectionInfo(z);
        } else {

            if ($('#SkipPreQualificationQuestion').val() == "<%=Boolean.TrueString%>" || '<%=AgreedWithPrequalificationQuestion%>' == '<%=Boolean.TrueString%>' || '<%=AskPreQualifierQuestion %>' == '<%= Boolean.FalseString %>') {
            } else {
                var openQuestionDialog = $('#package-selection-info-dialog');
                if (openQuestionDialog.length > 0) {

                    openQuestionDialog.dialog({ width: 750, autoOpen: false, title: 'Package Selection Info', modal: true, resizable: false, draggable: true, dialogClass: 'no-close' });
                    openQuestionDialog.bind('dialogclose', savePackageSelectionAfterDisclaimer);
                    openQuestionDialog.dialog("open");
                }
            }
        }
    }

    $(function() {
        $( "#age-dialog-message" ).dialog({
            modal: true,
            width: 400,
            autoOpen: false,
            title: 'Minimum Age Alert',
            buttons: {
                Close: function() {
                    $( this ).dialog( "close" );
                }
            }
        });

       

        $("#disclaimer-low-risk-message").dialog({
            modal: true,
            width: 400,
            autoOpen: false,
            title: 'Disclaimer',
            buttons: [
                {
                    text: "Continue",
                    click: function() {
                        $(this).dialog("close");
                    }
                }
            ]
        }).parent().find('.ui-dialog-buttonset').prepend('<a href="javascript:void(0);" onclick="exitToSiteUrl();" risk="Exhibit Risk" style="margin-right:10px;color:#00A7E5;" id="exitbtnExhibitRisk">No, I don\'t want to schedule</a>');


        $( "#disclaimer-emergnecy-message" ).dialog({
            modal: true,
            width: 400,
            autoOpen: false,
            title: 'Disclaimer',
            buttons:[{
                text: "Ok",
                click: function() {
                    $( this ).dialog( "close" );
                }
            }]
        });

        $("#disclaimer-diagnosed-heart-problem").dialog({
            modal: true,
            width: 400,
            autoOpen: false,
            title: 'Contact your Cardiologist',
            buttons: [
                {
                    text: "Ok",
                    click: function() {
                        $(this).dialog("close");

                    }
                }
            ]
        });


        $("#age-dialog-message").bind('dialogclose', exitToSiteUrl);
        $("#disclaimer-emergnecy-message").bind('dialogclose', exitToSiteUrl);
        $("#disclaimer-diagnosed-heart-problem").bind('dialogclose', exitToSiteUrl);

        $("#disclaimer-normal-message").bind('dialogclose', UpdateUserPrefrenceWithPrequalificationQuestion);
        $("#disclaimer-low-risk-message").bind('dialogclose', UpdateUserPrefrenceWithPrequalificationQuestion);

        OpenQuestionDialog();
    });
    

   
</script>