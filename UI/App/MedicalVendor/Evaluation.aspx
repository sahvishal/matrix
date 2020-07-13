<%@ Page Title="Evaluation" Language="C#" MasterPageFile="~/App/MedicalVendor/MedicalVendorMaster.master"
    AutoEventWireup="true" CodeBehind="Evaluation.aspx.cs" Inherits="Falcon.App.UI.App.MedicalVendor.Evaluation" %>

<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.Core.Extensions" %>
<%@ Import Namespace="Falcon.App.Core.Users.Enum" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>
<%@ Import Namespace="Falcon.App.Core.Application.Domain" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<%@ Register Src="~/Config/Content/Controls/Results/TestSectionContainer.ascx"
    TagName="_TestSection" TagPrefix="uc" %>
<%@ Register Src="~/Config/Content/Controls/Results/BasicBiometric.ascx"
    TagName="_BasicBiometric" TagPrefix="uc" %>
<%@ Register Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="_jQueryToolKit" TagPrefix="uc" %>
<%@ Register Src="~/App/UCCommon/Message.ascx" TagName="messages" TagPrefix="messagecontrol" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <uc:_jQueryToolKit ID="ucJquery" IncludeAjax="true" runat="server" IncudeJQueryJTip="true"
        IncludeJQueryUI="true" />
    <script language="javascript" type="text/javascript" src="/App/JavascriptFiles/JSonHelper.js"></script>
    <script language="javascript" type="text/javascript" src="/App/JavascriptFiles/EditResult.js"></script>
    <link href="/App/StyleSheets/ManualEntry.css" type="text/css" rel="Stylesheet" />
    <script type="text/javascript" src="/Scripts/json2.min.js"></script>
    <script type="text/javascript" src="/Scripts/flowplayer-3.2.6.js"></script>
    <script type="text/javascript" src="/Scripts/Video/video.js"></script>
    <link href="/Scripts/Video/video-js.css" rel="stylesheet" type="text/css" />
    <link href="/Content/Styles/jquery.qtip.min.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery.qtip.min.js" type="text/javascript"></script>
    
    <script type="text/javascript" src="/App/JavascriptFiles/HraQuestionnaire.js?q=<%=VersionNumber %>"></script>
    <script type="text/javascript" src="/Content/colorbox/jquery.colorbox.js"></script>
    <link href="/Content/colorbox/colorbox.css" rel="stylesheet" />
    <style type="text/css">
        fieldset {
            border-color: #F37C00;
        }

            fieldset legend {
                font-weight: bold;
            }

        #results {
            position: absolute;
            float: left;
            display: none;
            background-color: #fff;
            height: 100px;
            overflow-y: auto;
            overflow-x: hidden;
            font-size: 11px;
            border: solid 1px #7F9DB9;
        }

        .searchresult {
            height: 20px;
            width: 200px;
            border-bottom: 1px solid #7F9DB9;
            vertical-align: top;
            background: #f5f5f5;
        }

        .small {
            font: normal 9px arial;
        }

        .searchresult:hover {
            background-color: #ddd;
            cursor: hand;
        }

        .match {
            background-color: Yellow;
        }

        .jdbox {
            float: left;
            width: 350px;
            margin-top: 5px;
        }

        .jdbox-validations {
            float: left;
            width: 560px;
            margin-top: 5px;
        }

        .jdbox-validation-message {
            float: left;
            width: 540px;
            margin-top: 5px;
            padding-left: 10px;
            padding-right: 10px;
            overflow: visible;
        }

        .jdbox-validation-button {
            float: left;
            width: 560px;
            margin-top: 5px;
            border-top: 1px solid;
            padding-top: 5px;
        }

        .button {
            background: #5996b5;
            height: 25px;
            color: #fff;
            font: bold 12px arial;
            border: 0;
            padding: 0 3px;
        }

        input[type=text] {
            border: none;
            background-color: transparent;
            border-color: -moz-use-text-color -moz-use-text-color #535353;
            border-style: none none solid;
        }

        .CriticalStyle {
            float: left;
            color: White;
            background-color: Red;
            border: 2px solid;
            border-radius: 14px;
            width: 150px;
            text-align: center;
            margin: 0px 5px 0px 5px;
        }

        .critical-info {
            font-size: 14px;
            margin-top: 10px;
            margin-bottom: 10px;
        }
        .linkbutton {
          font: bold 11px Arial;
          text-decoration: none !important;
          background-color: #EEEEEE;
          color: #333333 !important; 
            border: 1px solid #999999;
    border-radius: 3px 3px 3px 3px;
          box-shadow: 0 0 1px #FFFFFF inset, 1px 1px 1px rgba(102, 102, 102, 0.3); 
        cursor: pointer;
        padding: 2px 12px 2px;
        text-align: center;
        }

        .saveWaitAnimationnew {
            background-image: url('/Content/Images/loading_Big_orng.gif');
            background-repeat: no-repeat;
            position: fixed;
            top: 0px;
            right: 0px;
            width: 100%;
            height: 100%;
            background-color: #000;
            background-position: center;
            z-index: 10000000;
            opacity: 0.4;
            filter: alpha(opacity=40);
        }

    </style>
    <script language="javascript" type="text/javascript">
        currentScreenMode = ScreenMode.Physician; 
    </script>
    <script type="text/javascript" language="javascript">
        function addColorBoxWrapper(url, name, tag, token, evtId, eventCustId, custId, visitId) {
            checkSession().then(function() {
                initiateHraQuestionare(url, name, tag, token, evtId, false);
                addColorBox(eventCustId, custId, visitId);
                
                //stop colorbox scroll
                $(document).bind('cbox_open', function () {
                    $('body').css({ overflow: 'hidden' });
                }).bind('cbox_closed', function () {
                    $('body').css({ overflow: '' });
                });

                $('#hraLink_' + eventCustId).click();
            }, function(data) {
                alert(data);
                window.location.replace("/login");
            });
        }

</script>
    <asp:DropDownList runat="server" ID="Conductedby" EnableViewState="false" CssClass="conducted-by"
        Style="display: none;">
        <asp:ListItem Text="-- Conducted By --" Value="0"></asp:ListItem>
    </asp:DropDownList>
    <div id="LoadingGifContainerDiv" class="loading" style="clear: both">
    </div>
    <div id="MainContainerDiv" class="container_all" style="display: none;">
        <div id="headerifoverreaddiv" runat="server" visible="false" class="contentrow" style="margin-bottom: 10px;">
        </div>
        <messagecontrol:messages ID="FranchiseeCommentsMessage" Visible="false" runat="server" />
        <messagecontrol:messages ID="PriorityInQueueMessage" Visible="false" runat="server" />
        <div class="contentrow" style="margin-bottom: 10px;">
            <fieldset>
                <legend>
                    <h2>
                        <span id="criticalPatient" title="Critical Patient"></span><span id="customername"></span>: <span id="customerid"></span>
                    </h2>
                </legend>
                <div style="float: left; width: 10%;">
                    <strong>Age:</strong> <span id="customerage" style="padding-left: 3px;"></span>
                </div>
                <div style="float: left; width: 13%;">
                    <strong>Height:</strong> <span id="customerheight" style="padding-left: 3px;"></span>
                </div>
                <div style="float: left; width: 12%;">
                    <strong>Weight:</strong> <span id="customerweight" style="padding-left: 3px;"></span>
                </div>
                <div style="float: left; width: 13%;">
                    <strong>Gender:</strong> <span id="customergender" style="padding-left: 3px;"></span>
                </div>
                <div style="float: left; width: 20%;">
                    <strong>Race:</strong> <span id="customerrace" style="padding-left: 3px;"></span>
                </div>
                <div style="float: left; width: 12%;">
                    <strong>Waist:</strong> <span id="customerwaist" style="padding-left: 3px;"></span>
                </div>
                 <div style="float: left; width: 12%;">
                    <strong>ACES Id:</strong> <span id="acesid" style="padding-left: 3px;"></span>
                </div>
                <div style="float: right; width: 20%; text-align: right;" class="medical-history-div">
                    (<a href="MedicalHistory.aspx?CustomerID=<%= CustomerId %>&EventId=<%= EventId %>" target="_blank">Health Assessment Form</a>)
                </div>
                <div style="float: left; width: 100%; border-top: 1px dashed; margin-top: 10px; padding-top: 8px; padding-bottom: 2px;">
                    <div style="float: left; clear: both; width: 10%;">
                        <strong>Contact At - </strong>
                    </div>
                    <div style="float: left; width: 60%;">
                        <strong>Address:</strong><span id="customer-address" style="padding-left: 3px;"></span>
                    </div>
                    <div style="float: left; clear: both; width: 10%;">
                        &nbsp;
                    </div>
                    <div style="float: left; width: 50%;">
                        <strong>Phone:</strong> <span id="customerphone" style="padding-left: 3px;"></span>
                    </div>
                    <div style="float: right; text-align: right; width: 25%;">
                        <strong>Email:</strong> <span id="customeremail" style="padding-left: 3px;"></span>
                    </div>
                </div>
                <div style="float: left; clear: both; width: 100%;">
                    <hr style="width: 100%;" />
                </div>
                <div style="float: left; width: 85%; padding-bottom: 5px; clear: both;">
                    <strong>Screened At:</strong> <span id="screeninglocation" runat="server"></span>
                </div>
                
                <div style="float: left; width: 30%;">
                    <strong>Screened On:</strong> <span id="screeningdate" runat="server"></span>
                </div>
                <div style="float: left; width: 30%;">
                    <strong>Vehicle:</strong> <span id="eventvehicle" runat="server"></span>
                </div>
                <div style="float: left; text-align: left; width: 25%;">
                    <strong>Event Id:</strong> <span id="eventId" style="padding-left: 3px;"><%= EventId %></span>
                </div>

                <div id="ShowCheckListForm" style="float: left; text-align: left; width: 13%;">
                    (<a href="/Scheduling/EventCustomerList/CustomerCheckListForm?customerId=<%= CustomerId %>&eventId=<%= EventId %>" target="_blank">Check List Form</a>)  
                </div>
            </fieldset>
        </div>

        <div class="lrow showhideFastingStatus" style="float: left;">
            <div style="float: left;">
                <label class="labels">
                    Is Customer On Fast? :
                </label>
                <input type="radio" disabled="disabled" name="CustomerOnFast" id="customerOnFastYesRadio" />Yes
        
                <input type="radio" disabled="disabled" name="CustomerOnFast" id="customerOnFastNoRadio" />No
            </div>
            <%--<div style="width: 20%; float: right;">
                <a id="criticalQuestions" href="javascript:void(0);" onclick="openCriticalQuestionDialog();" style="float: right; display: none;">Critical Patient Info</a>
            </div>--%>
            <div id="dvShowChatAssesmentLink" style="width: 17%; float: right; display: none">
                <a id="getAssessmentPdf" class="linkbutton" href="javascript:void(0);" onclick="getChatAssessmentPdf();" style="float: right;">CHAT Assessment PDF</a>
            </div>

            <div style="float: right; text-align: left; padding-top:3px; width: 15%; display: <%=ShowHraLink%>;">
                <a href="javascript:void(0)" class="linkbutton" onclick="addColorBoxWrapper('<%=HraQuestionerAppUrl%>', '<%=OrganizationNameForHraQuestioner%>', '<%= Tag %>', '<%=HttpUtility.UrlEncode(HraToken)%>', '<%= EventId %>',
                                '<%= EventCustomerId %>', <%=CustomerId %>, '<%= MedicareVisitId %>')">HRA Questionnaire</a>
                <a id="hraLink_<%= EventCustomerId %>" style="display: none;"></a>
            </div>

            <div style="float: right; text-align: left; padding-top:3px; width: 15%; display: <%=ShowChatLink%>;">
                <a href='<%=ChatQuestionerAppUrl %>' target="_blank" class="linkbutton">CHAT Questionnaire</a>
            </div>
        </div>
        


        <uc:_BasicBiometric runat="server" ID="BasicBiometric" Disabled="true" EnableAbnormalBp="true" />
        <div class="left" id="testdatasectiondiv" style="width: 100%; margin-bottom: 10px; clear: both">
            <uc:_TestSection runat="server" ID="TestSection" />
        </div>
        <div class="left save-button-container" style="width: 98%; clear: both;">
            <div class="left">
                <input type="button" id="sendbackforcorrection" value="Send Back for Correction"
                    onclick="$('#ReasonForSendBackCorrectionDiv').dialog('open'); return false;" />
            </div>
            <div style="float: right;">
                <input type="button" id="cancelevaluation" onclick="onClose(); return false;" value="Cancel" />
                <input type="button" id="saveandnext" value="Save And Next" onclick="SaveData('<%= ConstForSaveAndNext %>'); return false;" />
                <input type="button" id="saveandclose" value="Save And Close" onclick="SaveData('<%= ConstForSaveAndClose %>'); return false;" />
            </div>
        </div>
        <div id="divSaveWaitAnimation" class="saveWaitAnimation save-button-container contentrow"
            style="display: none;">
        </div>
        <asp:LinkButton runat="server" ID="linkbuttonfordopostback"></asp:LinkButton>
    </div>
    <div id="videoplayerfortestmediadiv" style="display: none; width: 850px;" class="jdbox">
        <table cellspacing="2" style="float: left; width: 100%;">
            <tr>
                <td colspan="3" style="text-align: right; padding-bottom: 5px;">
                    <a href="#" target="_blank" id="ViewImageAnchor">View Image</a>
                </td>
            </tr>
            <tr>
                <td style='width: 40px; text-align: center; vertical-align: middle;'>
                    <img src="/App/Images/left_arrow_black.gif" alt="Previous" style="cursor: pointer;"
                        class="media-navigation-prev" onclick="onPreviousClick_MediaTraversing();" />
                </td>
                <td style='text-align: center; vertical-align: middle;' id="imgcontainer"></td>
                <td style='width: 40px; text-align: center; vertical-align: middle;'>
                    <img src="/App/Images/right_arrow_black.gif" alt="Previous" style="cursor: pointer;"
                        class="media-navigation-next" onclick="onNextClick_MediaTraversing();" />
                </td>
            </tr>
        </table>
    </div>
    <div id="ReasonForSendBackCorrectionDiv" title="Send Back For Correction" style="display: none;"
        class="jdbox">
        <div class="jdbox">
            Please describe the consolidated issues with this screening. Our team will refer
            only to these comments, while rectifying the results.
        </div>
        <div class="jdbox">
            <textarea id="CorrectionReasonInputText" rows="5" style="width: 340px"></textarea>
        </div>
        <div class="jdbox">
            <div class="rgt">
                <input type="button" id="CancelSendForCorrectionButton" onclick='$("#ReasonForSendBackCorrectionDiv").dialog("close");'
                    class="button" value="Cancel" />
                <asp:Button ID="SendMailForCorrectionButton" runat="server" CssClass="button" Text="Send"
                    OnClientClick='SendMailForCorrection_onClick();' />
            </div>
        </div>
    </div>
    <div id="evaluation-validation-div" style="display: none;" class="jdbox-validations">
        <div class="jdbox-validation-message" id="validationmessagediv">
        </div>
        <div class="jdbox-validation-button">
            <div class="rgt">
                <input type="button" id="btncancel" class="button" value="Stay Back & Complete" onclick='$("#evaluation-validation-div").dialog("close");' />
            </div>
        </div>
    </div>
    <div id="customerCriticalDataDiv" style="display: none;">
        <div class="loading" style="clear: both">
        </div>
    </div>
    <div id="customerPriorityinQueueTestDiv" style="display: none;">
        <div class="loading" style="clear: both">
        </div>
    </div>

    <div id="critical-question-data" style="display: none;">
        <div id="critical-question-div">
            <div class="editor-row critical-info">
                <span style="float: left; width: 300px;">Did patient fast?
                &nbsp;&nbsp;
                </span>
                <span questionid="1" style="float: left; width: 90px;"></span>
                <a questionid="1" class="answer-note" style="display: none;">View Notes</a>
                <div class="answer-note-div" style="display: none;"></div>
            </div>
            <div class="editor-row critical-info">
                <span style="float: left; width: 300px;">Is patient on a statin?
                &nbsp;&nbsp;
                </span>
                <span questionid="2" style="float: left; width: 90px;"></span>
                <a questionid="2" class="answer-note" style="display: none;">View Notes</a>
                <div class="answer-note-div" style="display: none;"></div>
            </div>
            <div class="editor-row critical-info">
                <span style="float: left; width: 300px;">Is patient on cholesterol Med?
                &nbsp;&nbsp;
                </span>
                <span questionid="3" style="float: left; width: 90px;"></span>
                <a questionid="3" class="answer-note" style="display: none;">View Notes</a>
                <div class="answer-note-div" style="display: none;"></div>
            </div>
            <div class="editor-row critical-info">
                <span style="float: left; width: 300px;">Was patient stable at time of transfer?
                &nbsp;&nbsp;
                </span>
                <span questionid="4" style="float: left; width: 90px;"></span>
                <a questionid="4" class="answer-note" style="display: none;">View Notes</a>
                <div class="answer-note-div" style="display: none;"></div>
            </div>
            <div class="editor-row critical-info">
                <span style="float: left; width: 300px;">Was pcp contacted?
                &nbsp;&nbsp;
                </span>
                <span questionid="5" style="float: left; width: 90px;"></span>
                <a questionid="5" class="answer-note" style="display: none;">View Notes</a>
                <div class="answer-note-div" style="display: none;"></div>
            </div>
            <div class="editor-row critical-info">
                <span style="float: left; width: 300px;">Was patient symptomatic?
                &nbsp;&nbsp;
                </span>
                <span questionid="6" style="float: left; width: 90px;"></span>
                <a questionid="6" class="answer-note" style="display: none;">View Notes</a>
                <div class="answer-note-div" style="display: none;"></div>
            </div>
            <div class="editor-row critical-info">
                <span style="float: left; width: 300px;">Did patient refuse transfer?
                &nbsp;&nbsp;
                </span>
                <span questionid="7" style="float: left; width: 90px;"></span>
                <a questionid="7" class="answer-note" style="display: none;">View Notes</a>
                <div class="answer-note-div" style="display: none;"></div>
            </div>
            <div class="editor-row critical-info">
                <span style="float: left; width: 300px;">Where was the patient sent?
                &nbsp;&nbsp;
                </span>
                <span questionid="8" style="float: left; width: 90px;"></span>
                <a questionid="8" class="answer-note" style="display: none;">View Notes</a>
                <div class="answer-note-div" style="display: none;"></div>
            </div>
        </div>
    </div>

    <div id="divChatAssessmentPdf" title="CHAT assessment PDF" style="display: none; background: #fff; padding: 10px">
    </div>
    <div class="saveWaitAnimationnew" style="display: none">
	</div>
    <asp:HiddenField ID="hfIsPdfVerified" runat="server" Value="0" />
    <script language="javascript" type="text/javascript">

        var fileTypeImage = '<%= (int)FileType.Image %>';
        var readingSourceManual = "<%= (short)ReadingSource.Manual %>";
        var currentUser = '<%= IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId %>';
        var currentDate = '<%= DateTime.Now %>';

        var stateNumberEvaluation = '<%= (int) TestResultStateNumber.Evaluated %>';
        var stateNumberPreAudit = '<%= TestResultStateNumber.PreAudit %>';

        var statusComplete = '<%= TestResultStatus.Complete %>';
        var statusIncomplete = '<%= TestResultStatus.Incomplete %>';

        var eventId = '<%= EventId %>';
        var customerId = '<%= CustomerId %>';
        var loadCounter = 0;

        function ErrorMethodFetchData() {
            setLoadCounter();
            alert("Oops! a problem occured in the system.");
        }

        function setLoadCounter() {
            loadCounter++;
            if (loadCounter == 2) {
                $("#LoadingGifContainerDiv").hide();
                $("#MainContainerDiv").show();
            }
        }

        function SaveData(etarget) {
            var result = checkBeforeSavingResults();
            if (result)
                SaveTestResultData(etarget);
        }

        function checkBeforeSavingResults() {
            $(".save-button-container").toggle();
            if (!isOverReadAvailable || '<%= IsforOveread %>' == '<%= bool.TrueString %>') {
                Validate();

                if ($.trim(validationString).length > 0) {
                    $("#validationmessagediv").html(validationString);
                    $("#evaluation-validation-div").dialog("open");
                    return false;
                }
            }
            return true;
        }

        function onClosevalidationDiv() {
            $(".save-button-container").toggle();
        }

        $(document).ready(function () {
            $('#ReasonForSendBackCorrectionDiv').dialog({ width: 380, autoOpen: false, title: 'Send Back For Correction', resizable: false, draggable: true });
            fillConductedBy();
            initialSettingsIncidentalFinding();

            $('#evaluation-validation-div').dialog({ width: 580, autoOpen: false, title: 'Validations', resizable: false, draggable: true });
            $('#evaluation-validation-div').bind('dialogclose', onClosevalidationDiv);

            $('#customerCriticalDataDiv').dialog({ width: 650, autoOpen: false, title: 'Preliminary Test Result', resizable: false, draggable: true, modal: true });
            $('#customerCriticalDataDiv').bind('dialogclose', onCloseCustomerCriticalDataDiv);
            
            $('#customerPriorityinQueueTestDiv').dialog({ width: 650, autoOpen: false, title: 'Priority In Queue Reason', resizable: false, draggable: true, modal: true });
            $('#customerPriorityinQueueTestDiv').bind('dialogclose', onClosePriorityInQueueTest);

            $('#critical-question-data').dialog({ width: 500, autoOpen: false, title: 'Critical Patient Info', resizable: false, draggable: true, modal: true });
            $('#critical-question-data').bind('dialogclose');

            $('#divChatAssessmentPdf').dialog({ width: 865, autoOpen: false, title: 'CHAT Assessment PDF', resizable: false, draggable: true, modal: true, buttons : 
                {
                    'Save': function () {
                        $("#divChatAssessmentPdf").dialog('close'); 
                        <%--var isforOveread = '<%= IsforOveread %>'=='True' ? true : false;
                        var isVerified = $("#chkAssessmentVerified").is(":checked");
                        var eventId = '<%= EventId%>';
                        var customerId = '<%= CustomerId%>';
                        
                        if(!isVerified)
                        {
                            if(!confirm("You have not verified Assessment PDF, are you sure want to save?"))
                                return false;
                        }

                        $('#<%= hfIsPdfVerified.ClientID%>').val(isVerified ? '1' : '0');
                        $(".saveWaitAnimationnew").show();
                        $.ajax({ 
                            type: 'POST',
                            cache: false,
                            url: '/Scheduling/ChatAssessment/SaveChatAssessmentPdfReview',
                            data: JSON.stringify({
                                eventId: eventId, 
                                customerId: customerId, 
                                isVerified: isVerified, 
                                isforOveread: isforOveread
                            }),
                            contentType: "application/json; charset=utf-8",
                            success: function (result) {
                                $(".saveWaitAnimationnew").hide();
                                alert('Chat Assessment Save Successfully.');
                                $("#divChatAssessmentPdf").dialog('close'); 
                               // hideShowSaveButtons();

                            },
                            error: function (a, b, c) { 
                                $(".saveWaitAnimationnew").hide();
                                alert('Some error occurred while saving data. Please try after some time'); 
                                $("#divChatAssessmentPdf").dialog('close'); 
                            }
                        });--%>
                    },
                    'Cancel' : function() {
                        $("#divChatAssessmentPdf").dialog('close'); 
                    }
                } 
            });

            var parameter = "{'customerId':'" + customerId + "'";
            parameter += ",'eventId':'" + eventId + "' ,'urlPath':'<%= Request.Url.AbsolutePath %>'}";

            var messageUrl = '<%= ResolveUrl("~/App/Controllers/ManualEntryAndAuditController.asmx/GetCustomer") %>';
            InvokeService(messageUrl, parameter, SetCustomerData);

            messageUrl = '<%= ResolveUrl("~/App/Controllers/ManualEntryAndAuditController.asmx/GetTestResultsPhysician") %>';
            InvokeService(messageUrl, parameter, SetTestControlData);

            messageUrl = '<%= ResolveUrl("~/App/Controllers/ManualEntryAndAuditController.asmx/GetBasicBiometric") %>';
            InvokeService(messageUrl, parameter, setbiometricdata);

            messageUrl = '<%= ResolveUrl("~/App/Controllers/ManualEntryAndAuditController.asmx/GetRetestData") %>';
            InvokeService(messageUrl, parameter, setRetestCheckbox);
            
            if ("<%= ShowHideFastingStatus%>" == "<%= Boolean.TrueString%>") {
                messageUrl = '<%= ResolveUrl("~/App/Controllers/ManualEntryAndAuditController.asmx/GetFastingStatus") %>';
                InvokeServicewithErrorMethodName(messageUrl, parameter, setFastingData, DefaultErrorMethod);
                $(".showhideFastingStatus").show();
            } else {
                $(".showhideFastingStatus").hide();
            }
            
            if ("<%= ShowCheckListForm%>" == "<%= Boolean.TrueString%>") {
                $("#ShowCheckListForm").show();
            } else {
                $("#ShowCheckListForm").hide();
            }
            
            if ("<%= CaptureHaf%>" == "<%= Boolean.TrueString%>") {
                $(".medical-history-div").show();
            } else {
                $(".medical-history-div").hide();
            }

            if ("<%=ShowCriticalPatientData%>" == "<%=Boolean.TrueString%>") {
                $('#criticalQuestions').show();
            }

            $('.answer-note').qtip({
                position: {
                    my: 'left top'
                },
                content: {
                    title:'Note',
                    text: function(api) {
                        return $(this).parent().find('.answer-note-div').html();
                    }
                },
                style: {
                    width: '250px'
                }
            });
                        
        });
        function setFastingData(result) {
            if (result.d == null) return;

            if (result.d.IsFasting == null) {
                $("#customerOnFastYesRadio").attr("checked", false);
                $("#customerOnFastNoRadio").attr("checked", false);
            }
            else if (result.d.IsFasting == true) {
                $("#customerOnFastYesRadio").attr("checked", true);
                $("#customerOnFastNoRadio").attr("checked", false);
            }
            else if (result.d.IsFasting == false) {
                $("#customerOnFastYesRadio").attr("checked", false);
                $("#customerOnFastNoRadio").attr("checked", true);
            }
        }
        function setbiometricdata(result) {
            if (result.d == null) return;

            if (result.d.SystolicPressure != null)
                $("#systolicbp").val(result.d.SystolicPressure);

            if (result.d.DiastolicPressure != null)
                $("#diastolicbp").val(result.d.DiastolicPressure);

            if (result.d.IsRightArmBpMeasurement) {
                $("#rightArmBp").attr("checked", true);
            }
            else if (result.d.SystolicPressure != null || result.d.DiastolicPressure != null) {
                $("#leftArmBp").attr("checked", true);
            }

            if (result.d.IsBloodPressureElevated == true) {
                $("#isElevatedBp").attr("checked", true);
            }
            
            if (result.d.PulseRate != null)
                $("#pulseratebb").val(result.d.PulseRate);
        }


        function SetCustomerData(entity) {
            setLoadCounter();
            var customer = entity.d;
            $("#customername").text(customer.NameAsString);
            $("#customerid").text(customerId);

            if (customer.Height != null) {
                var heightFeet = customer.Height.Feet;
                var heightInch = customer.Height.Inches;

                $("#customerheight").text(heightFeet + " ft " + heightInch + " in");
            }
            else
                $("#customerheight").text("N/A");

            if (customer.Weight != null)
                $("#customerweight").text(customer.Weight.Pounds + " lbs");
            else
                $("#customerweight").text("N/A");
            
            if (customer.Waist != null)
                $("#customerwaist").text(customer.Waist + " in");
            else
                $("#customerwaist").text("N/A");

            if (customer.AcesId != null && customer.AcesId != "")
            {
                $("#acesid").text(customer.AcesId);
                if('<%= ShowChatAssesmentLink %>' == 'True')
                    $("#dvShowChatAssesmentLink").show();
                else
                    $("#dvShowChatAssesmentLink").hide();
            }
            else
            {
                $("#acesid").text("N/A");
               $("#dvShowChatAssesmentLink").hide();
            }

            if (customer.DateOfBirth != null) {
                customer.DateOfBirth = correctDateExpression(customer.DateOfBirth);
                $("#customerage").text(Age((customer.DateOfBirth.getMonth() + 1) + "/" + customer.DateOfBirth.getDate() + "/" + customer.DateOfBirth.getFullYear()));
            }
            else {
                $("#customerage").text("N/A");
            }

            if (customer.Gender == "<%= (int)Gender.Male %>")
                $("#customergender").text("<%= Gender.Male %>");
            else if (customer.Gender == "<%= (int)Gender.Female %>")
                $("#customergender").text("<%= Gender.Female %>");
            else
                $("#customergender").text("N/A");

        if (customer.Race == '<%= (int)Race.Caucasian %>')
                $("#customerrace").text('<%= Race.Caucasian %>');
        else if (customer.Race == '<%= (int)Race.Hispanic %>')
            $("#customerrace").text('<%= Race.Hispanic %>');
        else if (customer.Race == '<%= (int)Race.NativeAmerican %>')
            $("#customerrace").text('<%= Race.NativeAmerican %>');
        else if (customer.Race == '<%= (int)Race.Asian %>')
            $("#customerrace").text('<%= Race.Asian %>');
            else if (customer.Race == '<%= (int)Race.AfricanAmerican %>')
                $("#customerrace").text('<%= Race.AfricanAmerican %>');
            else if (customer.Race == '<%= (int)Race.Latino %>')
                $("#customerrace").text('<%= Race.Latino %>');
            else if (customer.Race == '<%= (int)Race.DeclinesToReport %>')
                $("#customerrace").text('<%= Race.DeclinesToReport.GetDescription() %>');
            else
                $("#customerrace").text("N/A");

    var phoneNumber = '';
    if (customer.HomePhoneNumber != null && customer.HomePhoneNumber.DomesticPhoneNumber.length > 0) {
        phoneNumber += customer.HomePhoneNumber.DomesticPhoneNumber + ' (H) ';
    }
    if (customer.OfficePhoneNumber != null && customer.OfficePhoneNumber.DomesticPhoneNumber.length > 0) {
        phoneNumber += (phoneNumber.length > 0 ? ", " : "") + customer.OfficePhoneNumber.DomesticPhoneNumber + ' (O) ';
    }
    if (customer.MobilePhoneNumber != null && customer.MobilePhoneNumber.DomesticPhoneNumber.length > 0) {
        phoneNumber += (phoneNumber.length > 0 ? ", " : "") + customer.MobilePhoneNumber.DomesticPhoneNumber + ' (C) ';
    }
    $("#customerphone").text(phoneNumber);

    if (customer.Email != null && customer.Email.Address.length > 0) {
        $("#customeremail").text(customer.Email.Address + "@" + customer.Email.DomainName);
    }

    var address = customer.Address;
    $("#customer-address").text(address.StreetAddressLine1 + (address.StreetAddressLine2.length > 0 ? ", " + address.StreetAddressLine2 : "") + ", " + address.City + ", " + address.State + ", " + address.Country + " - " + address.ZipCode.Zip);
            
   // hideShowSaveButtons();
}
    </script>
    <script language="javascript" type="text/javascript">

        function SetTestControlData(entity) {

            setLoadCounter();
            setSectionforPhysician();
            $.each(entity.d, function() {

                var testResult = removeTypeAttribute(this);
                testResult = CorrectDateissue(testResult);

                if ($('#criticalPatient').html() == '') {
                    if (this.ResultStatus.SelfPresent) {
                        $('#criticalPatient').addClass('CriticalStyle');
                        $('#criticalPatient').html('Critical Patient');
                    }
                }
                
                if (this.TestType == '<%= (short)TestType.EKG %>' && $(".ekgDiv div").length > 0) {
                    SetEKGData(testResult);
                    $(".ekgDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".ekgDiv"));
                } else if (this.TestType == '<%= (short)TestType.Echocardiogram %>' && $(".echoDiv div").length > 0) {
                    SetEchoData(testResult);
                    $(".echoDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".echoDiv"));
                } else if (this.TestType == '<%= (short)TestType.PulmonaryFunction %>' && $(".pulmonaryDiv div").length > 0) {
                    SetPulmonaryData(testResult);
                    $(".pulmonaryDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".pulmonaryDiv"));
                } else if (this.TestType == '<%= (short)TestType.IMT %>' && $(".imtDiv div").length > 0) {
                    SetImtData(testResult);
                    $(".imtDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".imtDiv"));
                } else if (this.TestType == '<%= (short)TestType.Thyroid %>' && $(".thyroidDiv div").length > 0) {
                    SetThyroidData(testResult);
                    $(".thyroidDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".thyroidDiv"));
                } else if (this.TestType == '<%= (short)TestType.Lipid %>' && $(".lipidDiv div").length > 0) {
                    SetLipidData(testResult);
                    $(".lipidDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".lipidDiv"));
                } else if (this.TestType == '<%= (short)TestType.AwvLipid %>' && $(".awvLipidDiv div").length > 0) {
                    SetAwvLipidData(testResult);
                    $(".awvLipidDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".awvLipidDiv"));
                } else if (this.TestType == '<%= (short)TestType.Cholesterol %>' && $(".CholesterolDiv div").length > 0) {
                    SetCholesterolData(testResult);
                    $(".CholesterolDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".CholesterolDiv"));
                } else if (this.TestType == '<%= (short)TestType.Diabetes %>' && $(".DiabetesDiv div").length > 0) {
                    SetDiabetesData(testResult);
                    $(".DiabetesDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".DiabetesDiv"));
                } else if (this.TestType == '<%= (short)TestType.AAA %>' && $(".aaaDiv div").length > 0) {
                    SetAAAData(testResult);
                    $(".aaaDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".aaaDiv"));
                } else if (this.TestType == '<%= (short)TestType.AwvAAA %>' && $(".AwvAaaDiv div").length > 0) {
                    SetAwvAaaData(testResult);
                    $(".AwvAaaDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".AwvAaaDiv"));
                } else if (this.TestType == '<%= (short)TestType.Stroke %>' && $(".strokeDiv div").length > 0) {
                    SetStrokeData(testResult);
                    $(".strokeDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".strokeDiv"));
                } else if (this.TestType == '<%= (short)TestType.AwvCarotid %>' && $(".awvCarotidDiv div").length > 0) {
                    SetAwvCarotidData(testResult);
                    $(".awvCarotidDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".awvCarotidDiv"));
                } else if (this.TestType == '<%= (short)TestType.Lead %>' && $(".leadDiv div").length > 0) {
                    SetLeadData(testResult);
                    $(".leadDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".leadDiv"));
                } else if (this.TestType == '<%= (short)TestType.PAD %>' && $(".padDiv div").length > 0) {
                    SetPadData(testResult);
                    $(".padDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".padDiv"));
                } else if (this.TestType == '<%= (short)TestType.AwvABI %>' && $(".AwvAbiDiv div").length > 0) {
                    SetAwvAbiData(testResult);
                    $(".AwvAbiDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".AwvAbiDiv"));
                } else if (this.TestType == '<%= (short)TestType.ASI %>' && $(".asiDiv div").length > 0) {
                    SetAsiData(testResult);
                    $(".asiDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".asiDiv"));
                } else if (this.TestType == '<%= (short)TestType.Osteoporosis %>' && $(".osteoDiv div").length > 0) {
                    SetOsteoData(testResult);
                    $(".osteoDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".osteoDiv"));
                } else if (this.TestType == '<%= (short)TestType.Spiro %>' && $(".spiroDiv div").length > 0) {
                    SetSpiroData(testResult);
                    $(".spiroDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".spiroDiv"));
                } else if (this.TestType == '<%= (short)TestType.A1C %>' && $(".a1cDiv div").length > 0) {
                    SetA1cData(testResult);
                    $(".a1cDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".a1cDiv"));
                } else if (this.TestType == '<%= (short)TestType.Psa %>' && $(".PsaDiv div").length > 0) {
                    SetPsaData(testResult);
                    $(".PsaDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".PsaDiv"));
                } else if (this.TestType == '<%= (short)TestType.MenBloodPanel %>' && $(".MenBloodPanelDiv div").length > 0) {
                    SetMenBloodPanelData(testResult);
                    $(".MenBloodPanelDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".MenBloodPanelDiv"));
                } else if (this.TestType == '<%= (short)TestType.WomenBloodPanel %>' && $(".WomenBloodPanelDiv div").length > 0) {
                    SetWomenBloodPanelData(testResult);
                    $(".WomenBloodPanelDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".WomenBloodPanelDiv"));
                } else if (this.TestType == '<%= (short)TestType.VitaminD %>' && $(".VitaminDDiv div").length > 0) {
                    SetVitaminDData(testResult);
                    $(".VitaminDDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".VitaminDDiv"));
                } else if (this.TestType == '<%= (short)TestType.Hypertension %>' && $(".HypertensionDiv div").length > 0) {
                    SetHypertensionData(testResult);
                    $(".HypertensionDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".HypertensionDiv"));
                } else if (this.TestType == '<%= (short)TestType.Crp %>' && $(".CrpDiv div").length > 0) {
                    SetCrpData(testResult);
                    $(".CrpDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".CrpDiv"));
                } else if (this.TestType == '<%= (short)TestType.Kyn %>' && $(".KynDiv div").length > 0) {
                    SetKynData(testResult);
                    $(".KynDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".KynDiv"));
                }else if (this.TestType == '<%= (short)TestType.HKYN %>' && $(".HkynDiv div").length > 0) {
                    SetHkynData(testResult);
                    $(".HkynDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".HkynDiv"));
                    
                } else if (this.TestType == '<%= (short)TestType.Colorectal %>' && $(".ColorectalDiv div").length > 0) {
                    SetColorectalData(testResult);
                    $(".ColorectalDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".ColorectalDiv"));
                } else if (this.TestType == '<%= (short)TestType.AwvBoneMass %>' && $(".awvBoneMassDiv div").length > 0) {
                    SetAwvBoneMassData(testResult);
                    $(".awvBoneMassDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".awvBoneMassDiv"));
                } else if (this.TestType == '<%= (short)TestType.AwvEkg %>' && $(".awvEkgDiv div").length > 0) {
                    SetAwvEkgData(testResult);
                    $(".awvEkgDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".awvEkgDiv"));
                } else if (this.TestType == '<%= (short)TestType.AwvEkgIPPE %>' && $(".awvEkgIPPEDiv div").length > 0) {
                    SetAwvEkgIPPEData(testResult);
                    $(".awvEkgIPPEDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".awvEkgIPPEDiv"));
                } else if (this.TestType == '<%= (short)TestType.AwvSpiro %>' && $(".awvSpiroDiv div").length > 0) {
                    SetAwvSpiroData(testResult);
                    $(".awvSpiroDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".awvSpiroDiv"));
                } else if (this.TestType == '<%= (short)TestType.AwvHBA1C %>' && $(".awvHemaglobinDiv div").length > 0) {
                    SetAwvHemaglobinData(testResult);
                    $(".awvHemaglobinDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".awvHemaglobinDiv"));
                } else if (this.TestType == '<%= (short)TestType.AwvGlucose %>' && $(".awvGlucoseDiv div").length > 0) {
                    SetAwvGlucoseData(testResult);
                    $(".awvGlucoseDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".awvGlucoseDiv"));
                } else if (this.TestType == '<%= (short)TestType.Testosterone %>' && $(".TestosteroneDiv div").length > 0) {
                    SetTestosteroneData(testResult);
                    $(".TestosteroneDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".TestosteroneDiv"));
                } else if (this.TestType == '<%= (short)TestType.PPAAA %>' && $(".PpaaaDiv div").length > 0) {
                    SetPpAAAData(testResult);
                    $(".PpaaaDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".PpaaaDiv"));
                } else if (this.TestType == '<%= (short)TestType.PPEcho %>' && $(".PpechoDiv div").length > 0) {
                    SetPpEchoData(testResult);
                    $(".PpechoDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".PpechoDiv"));
                } else if (this.TestType == '<%= (short)TestType.AWV %>' && $(".AwvDiv div").length > 0) {
                    SetAwvData(testResult);
                    $(".AwvDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".AwvDiv"));
                } else if (this.TestType == '<%= (short)TestType.Medicare %>' && $(".MedicareDiv div").length > 0) {
                    SetMedicareData(testResult);
                    $(".MedicareDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".MedicareDiv"));
                } else if (this.TestType == '<%= (short)TestType.AwvSubsequent %>' && $(".AwvSubsequentDiv div").length > 0) {
                    SetAwvSubsequentData(testResult);
                    $(".AwvSubsequentDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".AwvSubsequentDiv"));
                } else if (this.TestType == '<%= (short)TestType.Hearing %>' && $(".HearingDiv div").length > 0) {
                    SetHearingData(testResult);
                    $(".HearingDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".HearingDiv"));
                } else if (this.TestType == '<%= (short)TestType.Vision %>' && $(".VisionDiv div").length > 0) {
                    SetVisionData(testResult);
                    $(".VisionDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".VisionDiv"));
                } else if (this.TestType == '<%= (short)TestType.Glaucoma %>' && $(".GlaucomaDiv div").length > 0) {
                    SetGlaucomaData(testResult);
                    $(".GlaucomaDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".GlaucomaDiv"));
                } else if (this.TestType == '<%= (short)TestType.HCPAAA %>' && $(".HcpaaaDiv div").length > 0) {
                    SetHcpAAAData(testResult);
                    $(".HcpaaaDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".HcpaaaDiv"));
                } else if (this.TestType == '<%= (short)TestType.HCPCarotid %>' && $(".HcpCarotidDiv div").length > 0) {
                    SetHcpCarotidData(testResult);
                    $(".HcpCarotidDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".HcpCarotidDiv"));
                } else if (this.TestType == '<%= (short)TestType.HCPEcho %>' && $(".HcpEchoDiv div").length > 0) {
                    SetHcpEchoData(testResult);
                    $(".HcpEchoDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".HcpEchoDiv"));
                } else if (this.TestType == '<%= (short)TestType.AwvEcho %>' && $(".awvEchoDiv div").length > 0) {
                    SetAwvEchoData(testResult);
                    $(".awvEchoDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".awvEchoDiv"));
                } else if (this.TestType == '<%= (short)TestType.HPylori %>' && $(".HPyloriDiv div").length > 0) {
                    SetHPyloriData(testResult);
                    $(".HPyloriDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".HPyloriDiv"));
                } else if (this.TestType == '<%= (short)TestType.IFOBT %>' && $(".IFOBTDiv div").length > 0) {
                    SetIFOBTData(testResult);
                    $(".IFOBTDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".IFOBTDiv"));
                } else if (this.TestType == '<%= (short)TestType.Hemoglobin %>' && $(".HemoglobinDiv div").length > 0) {
                    SetHemoglobinData(testResult);
                    $(".HemoglobinDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".HemoglobinDiv"));
                } else if (this.TestType == '<%= (short)TestType.DiabeticRetinopathy %>' && $(".DiabeticRetinopathyDiv div").length > 0) {
                    SetDiabeticRetinopathyData(testResult);
                    $(".DiabeticRetinopathyDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".DiabeticRetinopathyDiv"));
                } else if (this.TestType == '<%= (short)TestType.eAWV %>' && $(".EAWVDiv div").length > 0) {
                    SetEAWVData(testResult);
                    $(".EAWVDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".EAWVDiv"));
                }
                else if (this.TestType == '<%= (short)TestType.DiabetesFootExam %>' && $(".DiabetesFootExamDiv div").length > 0) {
                    SetDiabetesFootExamData(testResult);
                    $(".DiabetesFootExamDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".DiabetesFootExamDiv"));
                }
                else if (this.TestType == '<%= (short)TestType.RinneWeberHearing %>' && $(".RinneWeberHearingDiv div").length > 0) {
                    SetRinneWeberHearingData(testResult);
                    $(".RinneWeberHearingDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".RinneWeberHearingDiv"));
                }
                else if (this.TestType == '<%= (short)TestType.Monofilament %>' && $(".MonofilamentDiv div").length > 0) {
                    SetMonofilamentData(testResult);
                    $(".MonofilamentDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".MonofilamentDiv"));
                }
                else if (this.TestType == '<%= (short)TestType.DiabeticNeuropathy %>' && $(".DiabeticNeuropathyDiv div").length > 0) {
                    SetDiabeticNeuropathyData(testResult);
                    $(".DiabeticNeuropathyDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".DiabeticNeuropathyDiv"));
                }
                else if (this.TestType == '<%= (short)TestType.FloChecABI %>' && $(".FloChecABIDiv div").length > 0) {
                    SetFloChecABIData(testResult);
                    $(".FloChecABIDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".FloChecABIDiv"));
                }
                else if (this.TestType == '<%= (short)TestType.QualityMeasures %>' && $(".QualityMeasuresDiv div").length > 0) {
                    SetQualityMeasuresData(testResult);
                    $(".QualityMeasuresDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".QualityMeasuresDiv"));
                }
                else if (this.TestType == '<%= (short)TestType.PHQ9 %>' && $(".phq9Div div").length > 0) {
                    SetPhq9Data(testResult);
                    $(".phq9Div").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".phq9Div"));
                }
                else if (this.TestType == '<%= (short)TestType.FocAttestation %>' && $(".focAttestation div").length > 0) {
                    SetFocAttestationData(testResult);
                    $(".focAttestation").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".focAttestation"));
                }
                else if (this.TestType == '<%= (short)TestType.Mammogram %>' && $(".mammogramDiv div").length > 0) {
                    SetMammogramData(testResult);
                    $(".mammogramDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".mammogramDiv"));
                }
                else if (this.TestType == '<%= (short)TestType.UrineMicroalbumin %>' && $(".UrineMicroalbuminDiv div").length > 0) {
                    SetUrineMicroalbuminData(testResult);
                    $(".UrineMicroalbuminDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".UrineMicroalbuminDiv"));
                }
                else if (this.TestType == '<%= (short)TestType.FluShot %>' && $(".fluShotDiv div").length > 0) {
                    SetFluShotData(testResult);
                    $(".fluShotDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".fluShotDiv"));
                }
                else if (this.TestType == '<%= (short)TestType.AwvFluShot %>' && $(".awvFluShotDiv div").length > 0) {
                    SetAwvFluShotData(testResult);
                    $(".awvFluShotDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".awvFluShotDiv"));
                }
                else if (this.TestType == '<%= (short)TestType.Pneumococcal %>' && $(".Pneumococcal div").length > 0) {
                    SetPneumococcalData(testResult);
                    $(".PneumococcalDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".PneumococcalDiv"));
                }
                else if (this.TestType == '<%= (short)TestType.Chlamydia %>' && $(".chlamydiaDiv div").length > 0) {
                    SetChlamydiaData(testResult);
                    $(".chlamydiaDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".chlamydiaDiv"));
                }
                else if (this.TestType == '<%= (short)TestType.QuantaFloABI %>' && $(".QuantaFloABIDiv div").length > 0) {
                    SetQuantaFloABIData(testResult);
                    $(".QuantaFloABIDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".QuantaFloABIDiv"));
                } else if (this.TestType == '<%= (short)TestType.DPN %>' && $(".DpnDiv div").length > 0) {
                    SetDpnData(testResult);
                    $(".DpnDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".DpnDiv"));
                }else if (this.TestType == '<%= (short)TestType.MyBioCheckAssessment %>' && $(".myBioCheckAssessmentDiv div").length > 0) {
                    SetMyBioCheckAssessmentData(testResult);
                    $(".myBioCheckAssessmentDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".myBioCheckAssessmentDiv"));
                }else if (this.TestType == '<%= (short)TestType.Foc %>' && $(".focDiv div").length > 0) {
                    SetFocData(testResult);
                    $(".focDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".focDiv"));
                }else if (this.TestType == '<%= (short)TestType.Cs %>' && $(".csDiv div").length > 0) {
                    SetCsData(testResult);
                    $(".csDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".csDiv"));
                }else if (this.TestType == '<%= (short)TestType.Qv %>' && $(".qvDiv div").length > 0) {
                    SetQvData(testResult);
                    $(".qvDiv").show();
                    if (IsTestPermitted(this.TestType))
                        excludeFromHiding($(".qvDiv"));
                }
                
            });
}

var validationString = "";

function Validate() {
    validationString = "";
    if (IsTestPermitted('<%= (short)TestType.EKG %>')) {
        validateTest($(".ekgDiv"), "EKG/ECG");
    }
    if (IsTestPermitted('<%= (short)TestType.Echocardiogram %>')) {
        if (!ValidateEchoCarotidAaa(".echoDiv")) {
            validateTest($(".echoDiv"), "Echocardiogram");
        }
    }
    if (IsTestPermitted('<%= (short)TestType.PulmonaryFunction %>')) {
        validateTest($(".pulmonaryDiv"), "Pulmonary Function");
    }
    if (IsTestPermitted('<%= (short)TestType.IMT %>')) {
        validateTest($(".imtDiv"), "IMT");
    }
    if (IsTestPermitted('<%= (short)TestType.Thyroid %>')) {
        validateTest($(".thyroidDiv"), "Thyroid");
    }
    if (IsTestPermitted('<%= (short)TestType.Lipid %>')) {
        validateTest($(".lipidDiv"), "Lipid Profile");
    }
    if (IsTestPermitted('<%= (short)TestType.AwvLipid %>')) {
        validateTest($(".awvLipidDiv"), "Lipid Profile");
    }
    if (IsTestPermitted('<%= (short)TestType.Cholesterol %>')) {
        validateTest($(".CholesterolDiv"), "Cholesterol");
    }
    if (IsTestPermitted('<%= (short)TestType.Diabetes %>')) {
        validateTest($(".DiabetesDiv"), "Diabetes");
    }
    if (IsTestPermitted('<%= (short)TestType.AAA %>')) {
        if (!ValidateEchoCarotidAaa($(".aaaDiv"))) {
            validateTest($(".aaaDiv"), "AAA");
        }
    }
    if (IsTestPermitted('<%= (short)TestType.AwvAAA %>')) {
        validateTest($(".AwvAaaDiv"), "AAA");
    }
    if (IsTestPermitted('<%= (short)TestType.Stroke %>')) {
        if (!ValidateEchoCarotidAaa(".strokeDiv")) {
            validateTest($(".strokeDiv"), "Stroke");
        }
    }
    if (IsTestPermitted('<%= (short)TestType.AwvCarotid %>')) {
        validateTest($(".awvCarotidDiv"), "Stroke");
    }
    if (IsTestPermitted('<%= (short)TestType.Lead %>')) {
        validateTest($(".leadDiv"), "Lead");
    }
    if (IsTestPermitted('<%= (short)TestType.PAD %>')) {
        validateTest($(".padDiv"), "PAD");
    }
    if (IsTestPermitted('<%= (short)TestType.AwvABI %>')) {
        validateTest($(".AwvABIDiv"), "PAD");
    }
    if (IsTestPermitted('<%= (short)TestType.ASI %>')) {
        validateTest($(".asiDiv"), "ASI");
    }
    if (IsTestPermitted('<%= (short)TestType.Osteoporosis %>')) {
        validateTest($(".osteoDiv"), "Osteoporosis");
    }
    if (IsTestPermitted('<%= (short)TestType.Spiro %>')) {
        validateTest($(".spiroDiv"), "Spiro");
    }
    if (IsTestPermitted('<%= (short)TestType.HPylori %>')) {
        validateTest($(".HPyloriDiv"), "HPylori");
    }
    if (IsTestPermitted('<%= (short)TestType.IFOBT %>')) {
        validateTest($(".IFOBTDiv"), "IFOBT");
    }
    if (IsTestPermitted('<%= (short)TestType.A1C %>')) {
        validateTest($(".a1cDiv"), "Hemaglobin");
    }
    if (IsTestPermitted('<%= (short)TestType.Psa %>')) {
        validateTest($(".PsaDiv"), "PSA");
    }
    if (IsTestPermitted('<%= (short)TestType.MenBloodPanel %>')) {
        validateTest($(".MenBloodPanelDiv"), "MenBloodPanel");
    }
    if (IsTestPermitted('<%= (short)TestType.WomenBloodPanel %>')) {
        validateTest($(".WomenBloodPanelDiv"), "WomenBloodPanel");
    }
    if (IsTestPermitted('<%= (short)TestType.VitaminD %>')) {
        validateTest($(".VitaminDDiv"), "VitaminD");
    }
    if (IsTestPermitted('<%= (short)TestType.Hypertension %>')) {
        validateTest($(".HypertensionDiv"), "Hypertension");
    }
    if (IsTestPermitted('<%= (short)TestType.Crp %>')) {
        validateTest($(".CrpDiv"), "CRP");
    }
    if (IsTestPermitted('<%= (short)TestType.Kyn %>')) {
        validateTest($(".KynDiv"), "KYN");
    }
    if (IsTestPermitted('<%= (short)TestType.Colorectal %>')) {
        validateTest($(".ColorectalDiv"), "Colorectal");
    }
    if (IsTestPermitted('<%= (short)TestType.AwvBoneMass %>')) {
        validateTest($(".awvBoneMassDiv"), "AwvBoneMass");
    }
    if (IsTestPermitted('<%= (short)TestType.AwvEkg %>')) {
        validateTest($(".awvEkgDiv"), "EKG/ECG");
    }
    if (IsTestPermitted('<%= (short)TestType.AwvEkgIPPE %>')) {
        validateTest($(".awvEkgIPPEDiv"), "EKG IPPE");
    }
    if (IsTestPermitted('<%= (short)TestType.AwvSpiro %>')) {
        validateTest($(".awvSpiroDiv"), "Spiro");
    }
    if (IsTestPermitted('<%= (short)TestType.AwvHBA1C %>')) {
        validateTest($(".awvHemaglobinDiv"), "Hemaglobin");
    }
    if (IsTestPermitted('<%= (short)TestType.AwvGlucose %>')) {
        validateTest($(".awvGlucoseDiv"), "Glucose");
    }
    if (IsTestPermitted('<%= (short)TestType.Testosterone %>')) {
        validateTest($(".TestosteroneDiv"), "Testosterone");
    }
    if (IsTestPermitted('<%= (short)TestType.PPAAA %>')) {
        validateTest($(".PpaaaDiv"), "AAA");
    }
    if (IsTestPermitted('<%= (short)TestType.PPEcho %>')) {
        validateTest($(".PpechoDiv"), "Echocardiogram");
    }
    if (IsTestPermitted('<%= (short)TestType.AWV %>')) {
        validateTest($(".AwvDiv"), "AWV");
    }
    if (IsTestPermitted('<%= (short)TestType.Medicare %>')) {
        validateTest($(".MedicareDiv"), "Medicare");
    }
    if (IsTestPermitted('<%= (short)TestType.AwvSubsequent %>')) {
        validateTest($(".AwvSubsequentDiv"), "AwvSubsequent");
    }
    if (IsTestPermitted('<%= (short)TestType.Hearing %>')) {
        validateTest($(".HearingDiv"), "Hearing");
    }
    if (IsTestPermitted('<%= (short)TestType.Vision %>')) {
        validateTest($(".VisionDiv"), "Vision");
    }
    if (IsTestPermitted('<%= (short)TestType.Glaucoma %>')) {
        validateTest($(".GlaucomaDiv"), "Glaucoma");
    }
    if (IsTestPermitted('<%= (short)TestType.HCPAAA %>')) {
        validateTest($(".HcpaaaDiv"), "AAA");
    }
    if (IsTestPermitted('<%= (short)TestType.HCPCarotid %>')) {
        validateTest($(".HcpCarotidDiv"), "Stroke");
    }
    if (IsTestPermitted('<%= (short)TestType.HCPEcho %>')) {
        validateTest($(".HcpEchoDiv"), "Echocardiogram");
    }
    if (IsTestPermitted('<%= (short)TestType.AwvEcho %>')) {
        validateTest($(".awvEchoDiv"), "Echocardiogram");
    }
    if (IsTestPermitted('<%= (short)TestType.Hemoglobin %>')) {
        validateTest($(".HemoglobinDiv"), "Hemoglobin");
    }
    if (IsTestPermitted('<%= (short)TestType.DiabeticRetinopathy %>')) {
        validateTest($(".DiabeticRetinopathyDiv"), "DiabeticRetinopathy");
    }
    if (IsTestPermitted('<%= (short)TestType.eAWV %>')) {
        validateTest($(".EAWVDiv"), "eAWV");
    }
    if (IsTestPermitted('<%= (short)TestType.DiabetesFootExam %>')) {
        validateTest($(".DiabetesFootExamDiv"), "DiabetesFootExam");
    }
    if (IsTestPermitted('<%= (short)TestType.RinneWeberHearing %>')) {
        validateTest($(".RinneWeberHearingDiv"), "RinneWeberHearing");
    }
    if (IsTestPermitted('<%= (short)TestType.Monofilament %>')) {
        validateTest($(".MonofilamentDiv"), "Monofilament");
    }
    if (IsTestPermitted('<%= (short)TestType.DiabeticNeuropathy %>')) {
        validateTest($(".DiabeticNeuropathyDiv"), "DiabeticNeuropathy");
    }
    if (IsTestPermitted('<%= (short)TestType.FloChecABI %>')) {
        validateTest($(".FloChecABIDiv"), "Flo Chec");
    }
    if (IsTestPermitted('<%= (short)TestType.QualityMeasures %>')) {
        validateTest($(".QualityMeasuresDiv"), "QualityMeasures");
    }
    if (IsTestPermitted('<%= (short)TestType.PHQ9 %>')) {
        validateTest($(".phq9Div"), "PHQ9");
    }
            
    if (IsTestPermitted('<%= (short)TestType.FocAttestation %>')) {
        validateTest($(".focAttestation"), "FocAttestation");
    }
  <%--  if (IsTestPermitted('<%= (short)TestType.Mammogram %>')) {
        validateTest($(".mammogramDiv"), "Mammogram");
    }--%>
    if (IsTestPermitted('<%= (short)TestType.UrineMicroalbumin %>')) {
        validateTest($(".UrineMicroalbuminDiv"), "UrineMicroalbumin");
    }
    if (IsTestPermitted('<%= (short)TestType.FluShot %>')) {
        validateTest($(".fluShotDiv"), "FluShot");
    }
    if (IsTestPermitted('<%= (short)TestType.AwvFluShot %>')) {
        validateTest($(".awvFluShotDiv"), "FluShot");
    }
    if (IsTestPermitted('<%= (short)TestType.Pneumococcal %>')) {
        validateTest($(".PneumococcalDiv"), "Pneumococcal");
    }
    if (IsTestPermitted('<%= (short)TestType.Chlamydia %>')) {
        validateTest($(".chlamydiaDiv"), "Chlamydia");
    }
    if (IsTestPermitted('<%= (short)TestType.QuantaFloABI %>')) {
        validateTest($(".QuantaFloABIDiv"), "QuantaFloABI");
    }
    if (IsTestPermitted('<%= (short)TestType.DPN %>')) {
                validateTest($(".DpnDiv"), "DPN");
    }
    if (IsTestPermitted('<%= (short)TestType.MyBioCheckAssessment %>')) {
        validateTest($(".myBioCheckAssessmentDiv"), "My Bio-Check Assessment");
    }
    if (IsTestPermitted('<%= (short)TestType.Foc %>')) {
        validateTest($(".focDiv"), "FOC");
    }
    //Open a Jdialog ....
}

function validateTest(sectionToCheck, testname) {
    if (sectionToCheck.length < 1) return true;

    var html = "";
    if (sectionToCheck.find(".unable-to-screen-section").find("input[type='checkbox']:checked").length > 0)
        return true;

    if (sectionToCheck.find("input[type='checkbox'].alt-conclusion-skipfinding-check:checked").length > 0)
        return true;

    if (sectionToCheck.find("input[type='radio'].alt-conclusion-skipfinding-check:checked").length > 0)
        return true;

    if (sectionToCheck.find(".test-not-performed-container:visible").length > 0)
        return true;

    if (sectionToCheck.find(".finding-section:visible").length > 1) {
        var allFindings = true;
        sectionToCheck.find(".finding-section:visible").each(function() {
            if ($(this).find("input[type='radio']:checked").length < 1) {
                allFindings = false;
            }
        });
        if (!allFindings) html += "<li> Findings are not marked. </li>";
    } else if (sectionToCheck.find(".finding-section:visible").length > 0 && sectionToCheck.find(".finding-section:visible").find("input[type='radio']:checked").length < 1) {
        html += "<li> Findings are not marked. </li>";
    }
            
    if (sectionToCheck.find(".finding-section-checkbox:visible").length > 1) {
        var allFindings = true;
        sectionToCheck.find(".finding-section-checkbox:visible").each(function() {
            if ($(this).find("input[type='checkbox']:checked").length < 1) {
                allFindings = false;
            }
        });
        if (!allFindings) html += "<li> Findings are not marked. </li>";
    } else if (sectionToCheck.find(".finding-section-checkbox:visible").length > 0 && sectionToCheck.find(".finding-section-checkbox:visible").find("input[type='checkbox']:checked").length < 1) {
        html += "<li> Findings are not marked. </li>";
    }

    //PP Echo
    if (sectionToCheck.find("#PpDiastolicDysfunctionCheckbox").length == 1 && $("#PpDiastolicDysfunctionCheckbox").is(":checked") && $(".Ppdiastolic-dysfunction-finding input[type='radio']:checked").length == 0) {
        html += "<li> Please select Grade for Diastolic dysfunction. </li>";
    }

    if ($.trim(html).length > 0)
        validationString += "<div style='clear:both;'> <b> " + testname + "</b><br/> <ul>" + html + "</ul></div>";
    return false;
}

function ValidateEchoCarotidAaa(sectionToCheck) {
    if ($(sectionToCheck).length < 1) return true;

    if ($(sectionToCheck).find(".validate-echo-carotid-aaa input[type='radio']:checked").length > 0) return true;

    return false;
}

    </script>
    <script language="javascript" type="text/javascript">
        var isSentForCorrection = false;

        function SendMailForCorrection_onClick() {
            if ($.trim($("#CorrectionReasonInputText").val()).length < 1) {
                alert('Please provide some input. It will assist the technician in resolving the issue easily');
                return;
            }

            $("#ReasonForSendBackCorrectionDiv").dialog("close");
            InvokeService("/App/MedicalVendor/Evaluation.aspx/RecordNotesforSendDataforCorrection", "{'physicianNotes' : '" + $.trim($("#CorrectionReasonInputText").val()) + "', 'physicianId' : '" + currentUser + "', "
                                        + "'eventId' : '" + eventId + "', 'customerId' : '" + customerId + "'}", function () {
                                            SaveTestResultData('<%= ConstForSaveAndNext %>');
                                        });
                isSentForCorrection = true;
                $(".save-button-container").toggle();
            }

            var eventTarget = "";
            function SaveTestResultData(etarget) {

                eventTarget = etarget;

                var osteoTestResult = $(".osteoDiv:visible").length > 0 ? GetOsteoData() : null;
                var spiroTestResult = $(".spiroDiv:visible").length > 0 ? GetSpiroData() : null;
                var strokeTestResult = $(".strokeDiv:visible").length > 0 ? GetStrokeData() : null;
                var awvCarotidTestResult = $(".awvCarotidDiv:visible").length > 0 ? GetAwvCarotidData() : null;
                var leadTestResult = $(".leadDiv:visible").length > 0 ? GetLeadData() : null;
                var aaaTestResult = $(".aaaDiv:visible").length > 0 ? GetAAAData() : null;
                var awvAaaTestResult = $(".AwvAaaDiv:visible").length > 0 ? GetAwvAaaData() : null;
                var asiTestResult = $(".asiDiv:visible").length > 0 ? GetAsiData() : null;
                var padTestResult = $(".padDiv:visible").length > 0 ? GetPadData() : null;
                var awvAbiTestResult = $(".AwvAbiDiv:visible").length > 0 ? GetAwvAbiData() : null;
                var echoTestResult = $(".echoDiv:visible").length > 0 ? GetEchoData() : null;

                var ekgTestResults = $(".ekgDiv:visible").length > 0 ? GetEKGData() : null;
                var lipidTestResults = $(".lipidDiv:visible").length > 0 ? GetLipidData() : null;
                var awvLipidTestResults = $(".awvLipidDiv:visible").length > 0 ? GetAwvLipidData() : null;
                var cholesterolTestResults = $(".CholesterolDiv:visible").length > 0 ? GetCholesterolData() : null;
                var diabetesTestResults = $(".DiabetesDiv:visible").length > 0 ? GetDiabetesData() : null;
                var liverTestResults = $(".liverDiv:visible").length > 0 ? GetLiverData() : null;
                var framinghamRiskTestResults = $(".framinghamRiskDiv:visible").length > 0 ? GetFraminghamRiskData() : null;
                var imtTestResult = $(".imtDiv:visible").length > 0 ? GetImtData() : null;
                var thyroidTestResult = $(".thyroidDiv:visible").length > 0 ? GetThyroidData() : null;
                var pulmonaryTestResult = $(".pulmonaryDiv:visible").length > 0 ? GetPulmonaryData() : null;
                var a1cTestResult = $(".a1cDiv:visible").length > 0 ? GetA1cData() : null;
                var PsaTestResult = $(".PsaDiv:visible").length > 0 ? GetPsaData() : null;
                var MenBloodPanelTestResult = $(".MenBloodPanelDiv:visible").length > 0 ? GetMenBloodPanelData() : null;
                var WomenBloodPanelTestResult = $(".WomenBloodPanelDiv:visible").length > 0 ? GetWomenBloodPanelData() : null;
                var VitaminDTestResult = $(".VitaminDDiv:visible").length > 0 ? GetVitaminDData() : null;
                var HypertensionTestResult = $(".HypertensionDiv:visible").length > 0 ? GetHypertensionData() : null;
                var CrpTestResult = $(".CrpDiv:visible").length > 0 ? GetCrpData() : null;
                var ColorectalTestResult = $(".ColorectalDiv:visible").length > 0 ? GetColorectalData() : null;

                var awvBoneMass = $(".awvBoneMassDiv:visible").length > 0 ? GetAwvBoneMassData() : null;
                var awvEkg = $(".awvEkgDiv:visible").length > 0 ? GetAwvEkgData() : null;
                var awvEkgIPPE = $(".awvEkgIPPEDiv:visible").length > 0 ? GetAwvEkgIPPEData() : null;
                var awvSpiro = $(".awvSpiroDiv:visible").length > 0 ? GetAwvSpiroData() : null;
                var awvHBA1C = $(".awvHemaglobinDiv:visible").length > 0 ? GetAwvHemaglobinData() : null;
                var awvGlucose = $(".awvGlucoseDiv:visible").length > 0 ? GetAwvGlucoseData() : null;

                var KynTestResult = $(".KynDiv:visible").length > 0 ? GetKynData() : null;
                var HkynTestResult = $(".HkynDiv:visible").length > 0 ? GetHkynData() : null;
                var TestosteroneTestResult = $(".TestosteroneDiv:visible").length > 0 ? GetTestosteroneData() : null;
            
                var PpaaaTestResult = $(".PpaaaDiv:visible").length > 0 ? GetPpAAAData() : null;
                var PpechoTestResult = $(".PpechoDiv:visible").length > 0 ? GetPpEchoData() : null;

                var awvTestResult= $(".AwvDiv:visible").length > 0 ? GetAwvData() : null;
                var medicareTestResult= $(".MedicareDiv:visible").length > 0 ? GetMedicareData() : null;
                var awvSubsequentResult= $(".AwvSubsequentDiv:visible").length > 0 ? GetAwvSubsequentData() : null;
                var hearingResult= $(".HearingDiv:visible").length > 0 ? GetHearingData() : null;
                var visionResult= $(".VisionDiv:visible").length > 0 ? GetVisionData() : null;
                var glaucomaResult= $(".GlaucomaDiv:visible").length > 0 ? GetGlaucomaData() : null;
            
                var HcpaaaTestResult = $(".HcpaaaDiv:visible").length > 0 ? GetHcpAAAData() : null;
                var HcpCarotidTestResult = $(".HcpCarotidDiv:visible").length > 0 ? GetHcpCarotidData() : null;
                var HcpEchoTestResult = $(".HcpEchoDiv:visible").length > 0 ? GetHcpEchoData() : null;
                var awvEchoTestResult = $(".awvEchoDiv:visible").length > 0 ? GetAwvEchoData() : null;
                var hPyloriTestResult = $(".HPyloriDiv:visible").length > 0 ? GetHPyloriData() : null;
                var hemoglobinTestResult = $(".HemoglobinDiv:visible").length > 0 ? GetHemoglobinData() : null;
                var diabeticRetinopathyTestResult = $(".DiabeticRetinopathyDiv:visible").length > 0 ? GetDiabeticRetinopathyData() : null;
                var eawvTestResult = $(".EAWVDiv:visible").length > 0 ? GetEAWVData() : null;
                var diabetesFootExamTestResult = $(".DiabetesFootExamDiv:visible").length > 0 ? GetDiabetesFootExamData() : null;
                var rinneWeberHearingTestResult = $(".RinneWeberHearingDiv:visible").length > 0 ? GetRinneWeberHearingData() : null;
                var monofilamentTestResult = $(".MonofilamentDiv:visible").length > 0 ? GetMonofilamentData() : null;
                var diabeticNeuropathyTestResult = $(".DiabeticNeuropathyDiv:visible").length > 0 ? GetDiabeticNeuropathyData() : null;
                var floChecABITestResult = $(".FloChecABIDiv:visible").length > 0 ? GetFloChecABIData() : null;
                var iFOBTTestResult = $(".IFOBTDiv:visible").length > 0 ? GetIFOBTData() : null;
                
                var qualityMeasuresTestResult = $(".QualityMeasuresDiv:visible").length > 0 ? GetQualityMeasuresData() : null;
                var phq9TestResult = $(".phq9Div:visible").length > 0 ? GetPhq9Data() : null;
                
                var focAttestationTestResult = $(".focAttestation:visible").length > 0 ? GetFocAttestationData() : null;
                var mammogramTestResult = $(".mammogramDiv:visible").length > 0 ? GetMammogramData() : null;
                var urineMicroalbuminTestResult = $(".UrineMicroalbuminDiv:visible").length > 0 ? GetUrineMicroalbuminData() : null;
                
                var fluShotTestResult = $(".fluShotDiv:visible").length > 0 ? GetFluShotData() : null;
                var awvFluShotTestResult = $(".awvFluShotDiv:visible").length > 0 ? GetAwvFluShotData() : null;
                var pneumococcalTestResult = $(".PneumococcalDiv:visible").length > 0 ? GetPneumococcalData() : null;
                var chlamydiaTestResult = $(".chlamydiaDiv:visible").length > 0 ? GetChlamydiaData() : null;
                var quantaFloABITestResult = $(".QuantaFloABIDiv:visible").length > 0 ? GetQuantaFloABIData() : null;
                
                var dpnTestResult = $(".DpnDiv:visible").length > 0 ? GetDpnData() : null;

                var myBioCheckAssessmentTestResults = $(".myBioCheckAssessmentDiv:visible").length > 0 ? GetMyBioCheckAssessmentData() : null;
                var focTestResults = $(".focDiv:visible").length > 0 ? GetFocData() : null;

                var newTestArray = new Array();
                if (echoTestResult != null) {
                    newTestArray.push(correctObject(echoTestResult));
                }

                if (ColorectalTestResult != null) {
                    newTestArray.push(correctObject(ColorectalTestResult));
                }
                if (awvBoneMass != null) {
                    newTestArray.push(correctObject(awvBoneMass));
                }
                if (awvEkg != null) {
                    newTestArray.push(correctObject(awvEkg));
                }
                if (awvEkgIPPE != null) {
                    newTestArray.push(correctObject(awvEkgIPPE));
                }
                if (awvSpiro != null) {
                    newTestArray.push(correctObject(awvSpiro));
                }
                if (awvHBA1C != null) {
                    newTestArray.push(correctObject(awvHBA1C));
                }
                if (awvGlucose != null) {
                    newTestArray.push(correctObject(awvGlucose));
                }

                if (KynTestResult != null) {
                    newTestArray.push(correctObject(KynTestResult));
                }
                
                if (HkynTestResult != null) {
                    newTestArray.push(correctObject(HkynTestResult));
                }

                if (PsaTestResult != null) {
                    newTestArray.push(correctObject(PsaTestResult));
                }

                if (MenBloodPanelTestResult != null) {
                    newTestArray.push(correctObject(MenBloodPanelTestResult));
                }

                if (WomenBloodPanelTestResult != null) {
                    newTestArray.push(correctObject(WomenBloodPanelTestResult));
                }

                if (VitaminDTestResult != null) {
                    newTestArray.push(correctObject(VitaminDTestResult));
                }
                if (HypertensionTestResult != null) {
                    newTestArray.push(correctObject(HypertensionTestResult));
                }
                if (CrpTestResult != null) {
                    newTestArray.push(correctObject(CrpTestResult));
                }

                if (a1cTestResult != null) {
                    newTestArray.push(correctObject(a1cTestResult));
                }

                if (ekgTestResults != null) {
                    newTestArray.push(correctObject(ekgTestResults));
                }

                if (lipidTestResults != null) {
                    newTestArray.push(correctObject(lipidTestResults));
                }
                
                if (awvLipidTestResults != null) {
                    newTestArray.push(correctObject(awvLipidTestResults));
                }
                
                if (cholesterolTestResults != null) {
                    newTestArray.push(correctObject(cholesterolTestResults));
                }
                
                if (diabetesTestResults != null) {
                    newTestArray.push(correctObject(diabetesTestResults));
                }
               
                if (liverTestResults != null) {
                    newTestArray.push(correctObject(liverTestResults));
                }

                if (framinghamRiskTestResults != null) {
                    newTestArray.push(correctObject(framinghamRiskTestResults));
                }

                if (aaaTestResult != null) {
                    newTestArray.push(correctObject(aaaTestResult));
                }

                if (awvAaaTestResult != null) {
                    newTestArray.push(correctObject(awvAaaTestResult));
                }
                
                if (strokeTestResult != null) {
                    newTestArray.push(correctObject(strokeTestResult));
                }
                if (awvCarotidTestResult != null) {
                    newTestArray.push(correctObject(awvCarotidTestResult));
                }

                if (leadTestResult != null) {
                    newTestArray.push(correctObject(leadTestResult));
                }
            
                if (padTestResult != null) {
                    newTestArray.push(correctObject(padTestResult));
                }

                if (awvAbiTestResult != null) {
                    newTestArray.push(correctObject(awvAbiTestResult));
                }

                if (asiTestResult != null) {
                    newTestArray.push(correctObject(asiTestResult));
                }

                if (osteoTestResult != null) {
                    newTestArray.push(correctObject(osteoTestResult));
                }
            
                if (spiroTestResult != null) {
                    newTestArray.push(correctObject(spiroTestResult));
                }

                if (imtTestResult != null) {
                    newTestArray.push(correctObject(imtTestResult));
                }

                if (pulmonaryTestResult != null) {
                    newTestArray.push(correctObject(pulmonaryTestResult));
                }

                if (thyroidTestResult != null) {
                    newTestArray.push(correctObject(thyroidTestResult));
                }

                if (TestosteroneTestResult != null) {
                    newTestArray.push(correctObject(TestosteroneTestResult));
                }
            
                if (PpaaaTestResult != null) {
                    newTestArray.push(correctObject(PpaaaTestResult));
                }
            
                if (PpechoTestResult != null) {
                    newTestArray.push(correctObject(PpechoTestResult));
                }

                if (awvTestResult != null) {
                    newTestArray.push(correctObject(awvTestResult));
                }

                if (medicareTestResult != null) {
                    newTestArray.push(correctObject(medicareTestResult));
                }

                if (awvSubsequentResult != null) {
                    newTestArray.push(correctObject(awvSubsequentResult));
                }
            
                if (hearingResult != null) {
                    newTestArray.push(correctObject(hearingResult));
                }
            
                if (visionResult != null) {
                    newTestArray.push(correctObject(visionResult));
                }
            
                if (glaucomaResult != null) {
                    newTestArray.push(correctObject(glaucomaResult));
                }
            
                if (HcpaaaTestResult != null) {
                    newTestArray.push(correctObject(HcpaaaTestResult));
                }
            
                if (HcpCarotidTestResult != null) {
                    newTestArray.push(correctObject(HcpCarotidTestResult));
                }
            
                if (HcpEchoTestResult != null) {
                    newTestArray.push(correctObject(HcpEchoTestResult));
                }
               
                if (awvEchoTestResult != null) {
                    newTestArray.push(correctObject(awvEchoTestResult));
                }

                if (hPyloriTestResult != null) {
                    newTestArray.push(correctObject(hPyloriTestResult));
                }

                if (iFOBTTestResult != null) {
                    newTestArray.push(correctObject(iFOBTTestResult));
                }

                if (hemoglobinTestResult != null) {
                    newTestArray.push(correctObject(hemoglobinTestResult));
                }

                if (diabeticRetinopathyTestResult != null) {
                    newTestArray.push(correctObject(diabeticRetinopathyTestResult));
                }
                if (eawvTestResult != null) {
                    newTestArray.push(correctObject(eawvTestResult));
                }

                if (diabetesFootExamTestResult != null) {
                    newTestArray.push(correctObject(diabetesFootExamTestResult));
                }
                
                if (rinneWeberHearingTestResult != null) {
                    newTestArray.push(correctObject(rinneWeberHearingTestResult));
                }
                if (monofilamentTestResult != null) {
                    newTestArray.push(correctObject(monofilamentTestResult));
                }
                
                if (diabeticNeuropathyTestResult != null) {
                    newTestArray.push(correctObject(diabeticNeuropathyTestResult));
                }
                
                if (floChecABITestResult != null) {
                    newTestArray.push(correctObject(floChecABITestResult));
                }
                
                if (qualityMeasuresTestResult != null) {
                    newTestArray.push(correctObject(qualityMeasuresTestResult));
                }
                
                if (phq9TestResult != null) {
                    newTestArray.push(correctObject(phq9TestResult));
                }
                
                if (focAttestationTestResult != null) {
                    newTestArray.push(correctObject(focAttestationTestResult));
                }
                if (mammogramTestResult != null) {
                    newTestArray.push(correctObject(mammogramTestResult));
                }
                if (urineMicroalbuminTestResult != null) {
                    newTestArray.push(correctObject(urineMicroalbuminTestResult));
                }
                
                if (fluShotTestResult != null) {
                    newTestArray.push(correctObject(fluShotTestResult));
                }
                
                if (awvFluShotTestResult != null) {
                    newTestArray.push(correctObject(awvFluShotTestResult));
                }
                
                if (pneumococcalTestResult != null) {
                    newTestArray.push(correctObject(pneumococcalTestResult));
                }

                if (chlamydiaTestResult != null) {
                    newTestArray.push(correctObject(chlamydiaTestResult));
                }
                
                if (quantaFloABITestResult != null) {
                    newTestArray.push(correctObject(quantaFloABITestResult));
                }

                if (dpnTestResult != null) {
                    newTestArray.push(correctObject(dpnTestResult));
                }
                
                if (myBioCheckAssessmentTestResults != null) {
                    newTestArray.push(correctObject(myBioCheckAssessmentTestResults));
                }

                if (focTestResults != null) {
                    newTestArray.push(correctObject(focTestResults));
                }                

                var idBpElevated = $("#isElevatedBp").attr("checked");
            
                var parameter = "{'customerId':'" + customerId + "'";
                parameter += ",'eventId':'" + eventId + "',";
                parameter += "'testResultStrings' : " + JSON.stringify(newTestArray) + ", 'organizationRoleUserId' : '" + currentUser + "', 'isPrimaryPhysicianUpdate' : " + (!isOverReadAvailable ? "'False'" : "'<%= !IsforOveread %>'") + ", 'isSendForCorrection' : '" + isSentForCorrection + "', 'isBpElevated' : '" + idBpElevated + "' }";
                
                InvokeService("/App/Controllers/ManualEntryAndAuditController.asmx/SetAllResultsforPhysician", parameter, successFunction);
            }

            function correctObject(obj) {
                obj.TechnicianNotes = obj.TechnicianNotes.replace(/\?\?+/gi, "?");;
                if (obj.PhysicianInterpretation != null)
                    obj.PhysicianInterpretation.Remarks = obj.PhysicianInterpretation.Remarks.replace(/\?\?+/gi, "?");;
                return JSON.stringify(obj);
            }
        
        
        
            function successFunction() {
                var isNewResultFlowInputHidden = $("#IsNewResultFlowInputHidden").val();
                
                InvokeService("/App/MedicalVendor/Evaluation.aspx/CompletePhysicianEvaluation", "{'eventCustomerId' : '<%= EventCustomerId %>', 'physicianId' : '" + currentUser + "', 'isSendForCorrection' : " + isSentForCorrection + " , 'isNewResultFlow' : " + isNewResultFlowInputHidden + "}", function () {
                    if (eventTarget == '<%= ConstForSaveAndNext %>') {
                        if ('<%= IsforOveread %>' == '<%= Boolean.TrueString %>') {
                            InvokeService("/Users/Dashboard/GetAvailableEventCustomerIdforOverread", "{ }", loadNextPage);
                        }
                        else {
                            InvokeService("/Users/Dashboard/GetAvailableEventCustomerIdforEvaluation", "{ }", loadNextPage);
                        }
                    }
                    else if (eventTarget == '<%= ConstForSaveAndClose %>') {
                        window.location = '/Users/Dashboard/Physician';
                    }
                },
            function () {
                alert("OOPS! Some error occured");
                window.location = '/Users/Dashboard/Physician';
            }
            );
            }

            function onClose() {
                InvokeService("/App/MedicalVendor/Evaluation.aspx/ReleaseLock", "{'eventCustomerId' : '<%= EventCustomerId %>'}", function () {
                window.location = '/Users/Dashboard/Physician';
            },
            function () {
                alert("OOPS! Some error occured");
                window.location = '/Users/Dashboard/Physician';
            }
            );
        }

        function loadNextPage(result) {
            if (result > 0) {
                window.location = "/App/MedicalVendor/Evaluation.aspx?EventCustomerId=" + result;
            } else {
                alert("No more records available for Evaluation!");
                window.location = '/Users/Dashboard/Physician';
            }
        }

    </script>
    <script language="javascript" type="text/javascript">

        function DefaultErrorMethod() {
            alert("Oops! a problem occured in the system.");
            window.location = '/Users/Dashboard/Physician';
        }

        function InvokeService(messageUrl, parameter, successFunction) {
            InvokeServicewithErrorMethodName(messageUrl, parameter, successFunction, DefaultErrorMethod)
        }

        function InvokeServicewithErrorMethodName(messageUrl, parameter, successFunction, errorMethod) {
            
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                url: messageUrl,
                data: parameter,
                success: function (result) {
                    successFunction(result);
                },
                error: function (a, b, c) {

                    errorMethod();
                }

            });
        }


    </script>
    <script language="javascript" type="text/javascript">
        function loadScreen(testId, technicianControl, setMethodRef) {

            $.ajax({ type: "GET",
                cache: false,
                dataType: "html",
                url: "/Medical/CustomerEventCriticalData/Edit?theeventId=" + eventId + "&thecustomerId=" + customerId + "&thetestId=" + testId,
                data: "{}",
                success: function (result) {
                    $("#customerCriticalDataDiv").empty();
                    $("#customerCriticalDataDiv").append(result);

                    loadControl(setMethodRef, (function () { $("#customerCriticalDataDiv").dialog('close'); }), '<%= TestResultStateNumber.Evaluated %>');

                },
                error: function (a, b, c) { alert('Some error loading the Customer Critical Data. Please try opening the page again'); $("#customerCriticalDataDiv").dialog('close'); }
            });
        }

        function openCriticalDataDialog(testId, technicianControl, criticalCheckboxRef, setMethodRef) {
            $("#customerCriticalDataDiv").dialog('open');
            loadScreen(testId, technicianControl, setMethodRef);
        }

        function saveSingleTestResult(testResult, criticalTestData, criticalSpanJobj, loadMethodstring, setDataMethod, printAfterSave) {//debugger;

            var testResultString = '';
            if (testResult != null) {
                testResultString = JSON.stringify(testResult);
            }

            var criticalTestDataString = '';
            if (criticalTestData != null) {
                criticalTestDataString = JSON.stringify(criticalTestData);
                criticalTestDataString = criticalTestDataString.replace(/'/gi, "\\\'").replace(/\\\"/gi, "\\\\\"");
            }

            messageUrl = '<%= ResolveUrl("~/App/Controllers/ManualEntryAndAuditController.asmx/SetTestResult") %>';
            parameter = "{'customerId' : '" + customerId + "', 'eventId' : '" + eventId + "', 'testResultString' : " + JSON.stringify(testResultString) + ", 'criticalDataString' : '" + criticalTestDataString + "', 'organizationRoleUserId' : '" + currentUser + "', 'resultState' : '" + '<%= (int)TestResultStateNumber.Evaluated %>' + "', 'pageUrl':'<%= Request.Url.AbsolutePath %>'}";
            InvokeServicewithErrorMethodName(messageUrl, parameter, function (result) {
                var testResult = removeTypeAttribute(result.d);
                testResult = CorrectDateissue(testResult);
                setDataMethod(testResult);
                $("#customerCriticalDataDiv").dialog('close');
                if (printAfterSave) {
                    var linkTag = criticalSpanJobj.find("img.critical-data-print-img").parents("a:first");
                    if (linkTag.length > 0) {
                        window.open(linkTag.attr("href"), "Print", "width=500, height=100");
                    }
                }
            }, function () { alert("Some error occured while saving the data."); $("#customerCriticalDataDiv").dialog('close'); });
        }


        function loadCriticalLink(criticalSpanJobj, loadMethodstring, testId) {
            //if (criticalSpanJobj.find("img.critical-data-load-img").length < 1) {
            //    criticalSpanJobj.append("<img class='critical-data-load-img' src='/App/Images/info-icon-red.gif' style='padding-left:1px;padding-right:1px;margin-top:1px;' alt='' onclick='" + loadMethodstring + "' /> ");
            //    criticalSpanJobj.append("<a target='_blank' href='/Medical/CustomerEventCriticalData/Print?eventId=" + eventId + "&customerId=" + customerId + "&testId=" + testId + "'><img class='critical-data-print-img' src='/App/Images/printer.gif' style='padding-left:1px;padding-right:1px;margin-top:1px;' alt='' /></a>");
            //}
        }

        function unloadCriticalLink(criticalSpanJobj, testId) {
            //if (criticalSpanJobj.find("img.critical-data-load-img").length > 0) {
            //    criticalSpanJobj.find("img.critical-data-load-img").remove();
            //    criticalSpanJobj.find("img.critical-data-print-img").remove();
            //}
        }

        function onCloseCustomerCriticalDataDiv() {
            $('#customerCriticalDataDiv').html("<div class='loading' style='clear: both;'> &nbsp; </div>");
        }
        function KeyPress_DecimalAllowedOnly(evt) {

            var key = (evt.which ? evt.which : ((evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : 0)));
            var InpObject = evt.currentTarget ? evt.currentTarget : evt.srcElement;

            if (((key >= 48 && key <= 57) || key == 9 || key == 8 || (key >= 37 && key <= 40) || key == 46 || key == 190 || key == 110 || (key >= 96 && key <= 105)) && (evt.shiftKey == false)) {
                if (key == 46 || key == 110 || key == 190) {
                    if (InpObject.value.indexOf(".") >= 0) return false;
                }
                return true;
            }
            return false;
        }

        function KeyPress_DecimalAllowedOnly_withsigns(evt) {

            var key = (evt.which ? evt.which : ((evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : 0)));
            var InpObject = evt.currentTarget ? evt.currentTarget : evt.srcElement;

            var selIndex = getSelectionStart(InpObject);

            if (((key >= 48 && key <= 57) || key == 9 || key == 8 || (key >= 37 && key <= 40) || key == 46 || ((key == 109 || key == 173 || key == 189) && selIndex == 0) || key == 190 || key == 110 || (key >= 96 && key <= 105)) && (evt.shiftKey == false)) {
                if (key == 46 || key == 110 || key == 190) {
                    if (InpObject.value.indexOf(".") >= 0) return false;
                }
                return true;
            }
            return false;
        }
        function getSelectionStart(o) {
            //debugger
            if (o.createTextRange) {
                var r = document.selection.createRange().duplicate();
                r.moveEnd('character', o.value.length);
                if (r.text == '') return o.value.length;
                return o.value.lastIndexOf(r.text);
            } else return o.selectionStart;
        }
    </script>
    <script language="javascript" type="text/javascript">
        
        var _savePriorityInQueTestForm = false;
        var _priorityInqueueTestCheckBoxRef = null;
        function onClosePriorityInQueueTest() {
            if ( !_savePriorityInQueTestForm  && _priorityInqueueTestCheckBoxRef != null) {
              
                _priorityInqueueTestCheckBoxRef.attr("checked", false);
                _priorityInqueueTestCheckBoxRef.click();
                _priorityInqueueTestCheckBoxRef.attr("checked", false);
            }
        }

        function loadPriorityInQueueTestScreen(testId, technicianControl, setMethodRef) {

            $.ajax({
                type: "GET",
                cache: false,
                dataType: "html",
                url: "/Medical/CustomerEventPriorityInQueueData/Edit?theeventId=" + eventId + "&thecustomerId=" + customerId + "&thetestId=" + testId,
                data: "{}",
                success: function (result) {
                    $("#customerPriorityinQueueTestDiv").empty();
                    $("#customerPriorityinQueueTestDiv").append(result);

                    loadPriorityinQueueTestPopup(setMethodRef, (function () { $("#customerPriorityinQueueTestDiv").dialog('close'); }), '<%= TestResultStateNumber.Evaluated %>');
                    
                    if (isPriorityInQueueTestOpenForEdit) {
                        _savePriorityInQueTestForm = true;
                    }
                },
                error: function (a, b, c) { alert('Some error loading the Priority in queue note. Please try opening the page again'); $("#customerPriorityinQueueTestDiv").dialog('close'); }
            });
        }

        function openPriorityInQueueTestDialog(testId, technicianControl, priorityInQueueCheckboxRef, setMethodRef) {
            $("#customerPriorityinQueueTestDiv").dialog('open');
            _priorityInqueueTestCheckBoxRef = priorityInQueueCheckboxRef;
            loadPriorityInQueueTestScreen(testId, technicianControl, setMethodRef);
        }    
        
        function loadPriorityInQueueLink(piqSpanJobj, loadMethodstring, testId) {
            if (piqSpanJobj.find("img.priorityInQueue-data-load-img").length < 1) {
                piqSpanJobj.append("<img class='priorityInQueue-data-load-img' src='/App/Images/info-icon-red.gif' style='padding-left:1px;padding-right:1px;margin-top:1px;' alt='' onclick='" + loadMethodstring + "' /> ");
            }
        }

        function unloadPriorityInQueueLink(priorityInQueueSpanJobj, testId) {
            if (priorityInQueueSpanJobj.find("img.priorityInQueue-data-load-img").length > 0) {
                priorityInQueueSpanJobj.find("img.priorityInQueue-data-load-img").remove();
            }
        }
    </script>
    <script type="text/javascript">
        function setSectionDisabledForPhysician() {
            
            if ('<%=CanPhysicianUpdateResultEntery %>' === '<%=Boolean.FalseString%>') {
                $("#testdatasectiondiv").find("input").attr("disabled", "disabled");
                $("#testdatasectiondiv").find("textarea").attr("disabled", "disabled");
                $("#testdatasectiondiv").find("select").attr("disabled", "disabled");
            }
            $("span[id*='critical']").find(":checkbox").attr("disabled", "disabled");
            $("span[id*='priorityInQueue']").find(":checkbox").attr("disabled", "disabled");
            $("span[id*='retest']").find(":checkbox").attr("disabled", "disabled");
            $(".test-not-performed-section").find("select").attr("disabled", "disabled");
            $(".test-not-performed-section").find("input").attr("disabled", "disabled");;
            $(".test-not-performed-section").find("textarea").attr("disabled", "disabled"); 
            
            $(".upload-media-section").hide();
        }
        
        function getSelectionStart(o) {
            //debugger
            if (o.createTextRange) {
                var r = document.selection.createRange().duplicate();
                r.moveEnd('character', o.value.length);
                if (r.text == '') return o.value.length;
                return o.value.lastIndexOf(r.text);
            } else return o.selectionStart;
        }

        function KeyPress_NumericAllowedOnly(evt) {
            var key = (evt.which ? evt.which : ((evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : 0)));
            var InpObject = evt.currentTarget ? evt.currentTarget : evt.srcElement;

            var selIndex = getSelectionStart(InpObject);
            if (((key >= 48 && key <= 57) || key == 9 || key == 13 || key == 8 || (key >= 37 && key <= 40) || ((key == 109 || key == 189) && selIndex == 0) || (key >= 96 && key <= 105)) && (evt.shiftKey == false)) {
                return true;
            }

            return false;
        }

        function KeyPress_DecimalAllowedOnly(evt) {

            var key = (evt.which ? evt.which : ((evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : 0)));
            var InpObject = evt.currentTarget ? evt.currentTarget : evt.srcElement;

            if (((key >= 48 && key <= 57) || key == 9 || key == 8 || (key >= 37 && key <= 40) || key == 46 || key == 190 || key == 110 || (key >= 96 && key <= 105)) && (evt.shiftKey == false)) {
                if (key == 46 || key == 110 || key == 190) {
                    if (InpObject.value.indexOf(".") >= 0) return false;
                }
                return true;
            }
            return false;
        }

        function KeyPress_DecimalAllowedOnly_withsigns(evt) {

            var key = (evt.which ? evt.which : ((evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : 0)));
            var InpObject = evt.currentTarget ? evt.currentTarget : evt.srcElement;

            var selIndex = getSelectionStart(InpObject);

            if (((key >= 48 && key <= 57) || key == 9 || key == 8 || (key >= 37 && key <= 40) || key == 46 || ((key == 109 || key == 173 || key == 189) && selIndex == 0) || key == 190 || key == 110 || (key >= 96 && key <= 105)) && (evt.shiftKey == false)) {
                if (key == 46 || key == 110 || key == 190) {
                    if (InpObject.value.indexOf(".") >= 0) return false;
                }
                return true;
            }
            return false;
        }
    </script>
    <script type="text/javascript">
        function SetTestNotPerformedEnableDisabled(controlId) {
            //debugger;
            var isAdminUser = '<%= IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.CheckRole((long)Falcon.App.Core.Enum.Roles.FranchisorAdmin) %>';
            var contraller = $("#" + controlId);
            var booleanFalse = '<%= Boolean.FalseString %>';
            var selectedValue = $(contraller).find("select :selected").val();
            var testNotReadable = '<%= (long) TestNotPerformedReasonType.TestUnreadable %>';
            if (selectedValue === testNotReadable && isAdminUser === booleanFalse ) {
                //$(contraller).find("input").attr("disabled", true);
                $(contraller).find("select,input,textArea").attr("disabled", true);
            } else if(isAdminUser === booleanFalse) {
                $(contraller).find("select option").each(function() {
                    if ($(this).val() === testNotReadable) {
                        $(this).hide();
                    }
                });
            }
        }

        function openCriticalQuestionDialog() {
            $.ajax({
                type:"GET",
                url:"/Medical/CustomerEventCriticalData/GetCriticalPatientData?eventId=" + '<%= EventId %>' + "&customerId=" + '<%= CustomerId %>',
                 success:function(result) {
                     if (result != null && result.Answers != null && result.Answers.length > 0) {
                         $("#critical-question-data").dialog("open");
                         setAnswers(result.Answers);
                     }
                 },
                 error:function() {
                     alert("Some error occurred while getting critical patient data.");
                 }
             });
        }
        
        function setAnswers(questionAnswers) {

            $.each(questionAnswers, function(index, qa) {
                var span = $("span[questionId='" + qa.QuestionId + "']");

                if (qa.Answer !== '') {
                    $(span).html(qa.Answer);
                }
                
                if (qa.Note != null && qa.Note !== '') {
                    $('a[questionid="' + qa.QuestionId + '"]').show();
                    $(span).parent().find('.answer-note-div').html(qa.Note);
                }
            });
        }

        function setRetestCheckbox(entity) {
            if (entity != null && entity.d != null) {
                $.each(entity.d, function(index, testId) {
                    $("#Retest_" + testId).attr("checked", true);
                });
            }
        }

        function getChatAssessmentPdf()
        {
            $(".saveWaitAnimationnew").show();
            
            var eventId = '<%= EventId%>';
            var acesId = $("#acesid").text();
            
            $.ajax({
                url: '/Scheduling/ChatAssessment/GetChatAssessmentPdf',
                type: 'POST',
                cache: false,
                data: JSON.stringify({ eventId: eventId, acesId : acesId }),
                traditional: true,
                contentType: "application/json; charset=utf-8",
                dataType: "html",
            }).done(function (result) {
                $('#divChatAssessmentPdf').html(result);
                
                var isforOveread = '<%= IsforOveread %>'=='True' ? true : false;
                var eventId = '<%= EventId%>';
                var customerId = '<%= CustomerId%>';
                
                $(".saveWaitAnimationnew").show();
                $('#divChatAssessmentPdf').dialog('open');
                $(".saveWaitAnimationnew").hide();
                $.ajax({ 
                    type: 'POST',
                    cache: false,
                    url: '/Scheduling/ChatAssessment/SaveChatAssessmentPdfReview',
                    data: JSON.stringify({
                        eventId: eventId, 
                        customerId: customerId, 
                        isVerified: true, 
                        isforOveread: isforOveread
                    }),
                    contentType: "application/json; charset=utf-8",
                });
                
            }).error(function(xhr, status, error){    
                $(".saveWaitAnimationnew").hide();
                
                var err = $(xhr.responseText).filter('title').text();
                if(err!='')
                    alert(err);
                else
                    alert(error);
            });
        }

        <%--function hideShowSaveButtons()
        {
            var isPdfVerified = $('#<%= hfIsPdfVerified.ClientID%>').val() == '1' ? true :false;
            var isAssessmentPdfVerified = $("#chkAssessmentVerified").is(":checked");
            var showChatAssesmentLink = '<%= ShowChatAssesmentLink%>' == 'True' ? true : false;
            var acesd = $('#acesid').text();
            
            if(showChatAssesmentLink && acesd != '' && acesd != 'N/A')
            {
                
                if(isPdfVerified || isAssessmentPdfVerified){
                    $('#saveandnext').show();
                    $('#saveandclose').show();
                }
                else
                {
                    $('#saveandnext').hide();
                    $('#saveandclose').hide();
                }
            }
            else{
                $('#saveandnext').show();
                $('#saveandclose').show();
            }
        }--%>

    </script>
</asp:Content>
