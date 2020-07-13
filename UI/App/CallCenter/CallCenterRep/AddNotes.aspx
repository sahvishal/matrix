<%@ Page Language="C#" MasterPageFile="~/App/CallCenter/CallCenterMaster.master"
    Title="Add Notes" AutoEventWireup="true" Inherits="Falcon.App.UI.App.CallCenter.CallCenterRep.AddNotes"
    CodeBehind="AddNotes.aspx.cs" %>

<%@ Import Namespace="Falcon.App.Core.Enum" %>

<%@ Register Src="~/App/UCCommon/UcEventRegistrationSummary.ascx" TagName="EventDetail"
    TagPrefix="UC" %>
<%@ Register Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="_jQueryToolKit" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="../../JavascriptFiles/MaskEdit.js"></script>
    <script language="javascript" type="text/javascript" src="/App/jquery/js/jquery.maskedinput-1.2.2.js"></script>
    <script language="javascript" type="text/javascript">

        $(function () {
            $(".scheduled-time").mask("23:59");
            $('.mask-phone').mask('(999)-999-9999');
        });

        function setAssignmentChangedStatus() {
            window.localStorage.setItem('AssignmentChanged', 'true');
            window.location = '/CallCenter/CallCenterRepDashBoard/Index#/dashboard';
        }

        function EndCall() {
            var hfConclusion = document.getElementById("<%= this.hfConclusion.ClientID %>");
            if (hfConclusion.value != "") {
                alert(hfConclusion.value);
            }

        }

        function ValidateEndCall() {
            var scheduleDate = $('.scheduleddate-dp').val();
            if ($("#ScheduleInputContainerDiv:visible").length > 0) {
                if (!IsValidDate(scheduleDate)) {
                    alert('Please enter a valid Schedule Date.');
                    $('.scheduleddate-dp').focus();
                    return false;
                }
            }

            var gotOneChecked = false;
            $(".callstatus-rbtn-list input").each(function () {
                if ($(this).attr("checked") == true)
                    gotOneChecked = true;
            });

            if (!gotOneChecked) {
                var callStatus = confirm("Not selecting any of the Call Status implies that call was attended. \nClick 'Cancel' to go back and change the status!");
                if (!callStatus)
                    return false;
            }

            return true;
        }

        function FilterTime(evt, textbox, dFilterMask) {
            var key = (evt.which ? evt.which : ((evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : 0)));
            return dFilter(key, textbox, dFilterMask);
        }

        function EndCallValidation() {

            if ($("#<%= CallDispositionDiv.ClientID %>").is(':visible')) {
                if (parseInt($("#<%= CallDispositionDropdown.ClientID %>").val()) <= 0) {
                    alert("Please select reason for call disposition.");
                    return false;
                }
            }

            var scheduleDate = $('.scheduleddate-dp').val();
            if ($("#ScheduleInputContainerDiv:visible").length > 0) {
                if (!IsValidDate(scheduleDate)) {
                    alert('Please enter a valid Schedule Date.');
                    $('.scheduleddate-dp').focus();
                    return false;
                }
            }

            if ('<%= IsHealthPlanCallQueue%>' == '<%= Boolean.TrueString %>') {
                if ($("#ScheduleInputContainerDiv:visible").length > 0) {
                    var ctrl = $("#<%= CallDispositionDropdown.ClientID%>");
                    if (ctrl.val() == '<%= ProspectCustomerTag.CallBackLater %>') {
                        if ($("#<%= ScheduledTimeText.ClientID %>").val() == '') {
                            alert('Please enter a valid Schedule time.');
                            $("#<%= ScheduledTimeText.ClientID %>").focus();
                            return false;
                        }
                    }
                }
            }

            if ($("#NotIntrestedReasonDiv:visible").length > 0) {
                if ($("#<%= NotIntrestedDropDownList.ClientID %>").is(':visible')) {
                    if (parseInt($("#<%= NotIntrestedDropDownList.ClientID %>").val()) <= 0) {
                        alert("Please select reason.");
                        return false;
                    }
                }
            }

            if ($("#notesRequired:visible").length > 0) {
                if ($("#<%= CallDispositionDiv.ClientID %>").is(':visible')) {
                    if ($("#<%= txtNotes.ClientID %>").val().trim() == '') {
                        alert("Please enter Notes.");
                        return false;
                    }
                }
            }

            if (scriptPopup && !scriptPopup.closed) {
                scriptPopup.close();
            }
            return true;
        }

        $(document).ready(function () {
            if ($("#<%= CallDispositionDiv.ClientID %>").is(':visible')) {
                $("#<%=CallStatusRadioList.ClientID%> input[type=radio]").bind("click", function () {
                    //debugger;
                    if ($(this).val() == '<%=(long)Falcon.App.Core.CallCenter.Enum.CallStatus.Attended%>') {
                        $("#<%= CallDispositionDiv.ClientID %>").show();
                    } else {
                        $("#<%= CallDispositionDiv.ClientID %>").hide();
                    }
                });
            }

            checkAndOpenScriptPopup();

            function init() {

                if ($("#<%=CallBackOptionsRadioList.ClientID%> input[type=radio]:checked").val() == '<%=(long)RequeueOption.Automatic%>') {
                    $("#ScheduleInputContainerDiv").hide();
                } else {
                    $("#ScheduleInputContainerDiv").show();
                }
            }


            $("#<%=CallBackOptionsRadioList.ClientID%> input[type=radio]").bind("click", function () {
                if ($(this).val() == '<%=(long)RequeueOption.Automatic%>') {
                    $("#ScheduleInputContainerDiv").hide();
                } else {
                    $("#ScheduleInputContainerDiv").show();
                }
            });


            if ('<%= IsHealthPlanCallQueue%>' == '<%= Boolean.TrueString %>') {
                init();
                $("#<%= CallDispositionDropdown.ClientID%>").change(function () {
                    var ctrl = $(this);
                    if (ctrl.val() == '<%= ProspectCustomerTag.CallBackLater %>') {
                        $("#<%= CallBackOptionsContainerDiv.ClientID %>").show();
                    } else {
                        $("#<%= CallBackOptionsContainerDiv.ClientID %>").hide();
                    }

                    if (ctrl.val() == '<%= ProspectCustomerTag.NotInterested %>') {
                        $("#NotIntrestedReasonDiv").show();
                    } else {
                        $("#NotIntrestedReasonDiv").hide();
                    }

                    if (isNotesMandatory()) {
                        $('#notesRequired').show();
                    } else {
                        $('#notesRequired').hide();
                    }
                });
            }
            function isNotesMandatory() {
                var ctrl = $("#<%= CallDispositionDropdown.ClientID%>");
                var tag = ctrl.val();
                if (tag == '<%= ProspectCustomerTag.RecentlySawDoc %>' || tag == '<%= ProspectCustomerTag.NotInterested %>' || tag == '<%= ProspectCustomerTag.DateTimeConflict %>' ||
                    tag == '<%= ProspectCustomerTag.HomeVisitRequested %>' || tag == '<%= ProspectCustomerTag.LanguageBarrier %>' || tag == '<%= ProspectCustomerTag.InLongTermCareNursingHome %>') {
                    return true;
                }
                return false;
            }

            var myMask = "29:69ghi";
            $('#<%= ScheduledTimeText.ClientID%>').mask(myMask, { message: "Please provide a valid input. The valid format is XX.XX AM/PM." });

            $("#spFinalThankYou").html($("#<%=hfThankYou.ClientID %>").val());
            $("#<%=hfThankYou.ClientID %>").val("");

            $("#<%=hfHpCallQueueId.ClientID %>").val(window.localStorage.hpCallQueueId);
            $("#<%=hfEventId.ClientID %>").val(window.localStorage.hpEventId);
            $("#<%=hfHpHealthPlanId.ClientID %>").val(window.localStorage.hpHealthPlanId);
            $("#<%=hfHpFillEventZipCode.ClientID %>").val(window.localStorage.hpFillEventZipCode);
            $("#<%=hfHpRadius.ClientID %>").val(window.localStorage.hpRadius);
            $("#<%=hfHpCriteriaId.ClientID %>").val(window.localStorage.hpCriteriaId);
            $("#<%=hfHpCampaignId.ClientID %>").val(window.localStorage.hpCampaignId);
        });
    </script>
    <uc1:_jQueryToolKit ID="ucJquery" runat="server" IncludeJQueryUI="true" IncludeJQueryMaskInput="true" />
    <div class="mainbody_outer">
        <div class="mainbody_inner">
            <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p>
                        <img src="/App/Images/specer.gif" width="750px" height="5px" />
                    </p>
                    <span class="orngheadtxt_heading" id="dvTitle" runat="server">Call Summary</span>
                    <span id="spnRestrictedNotes" runat="server" style="float: left; margin-left: 5px; margin-top: 2px; font: bold 20px arial;">( Do not transfer these patients to Itel )</span>
                    <span class="headingright_default"></span>
                </div>
                <p>
                    <img src="/App/Images/specer.gif" width="750px" height="2px" />
                </p>
            </div>
            <div class="maindivredmsgbox" id="divErrorMsg" enableviewstate="false" visible="false"
                runat="server">
            </div>
            <div class="main_area_bdr">
                <div id="dvEventsummary" runat="server" class="welcomemsgbox_addnotes" style="display: none; visibility: hidden">
                    <p class="wcomemsgboxrow_addnotes">
                        <span class="orng14pxtxt_addnotes" id="spFinalThankYou"></span>
                    </p>
                    <p class="graylinefull_addnotes">
                        <img src="../../Images/CCRep/specer.gif" width="1px" height="1px" />
                    </p>
                    <p>
                        <img src="../../Images/CCRep/specer.gif" width="700px" height="10px" />
                    </p>
                    <UC:EventDetail ID="_eventDetail" runat="server" />
                </div>
                <div class="maincontentrow_ccrep">
                    <div class="regcust_innercon">
                        <p>
                            <img src="../../Images/specer.gif" width="740" height="5" />
                        </p>
                        <div class="regcust_innerrow">
                            <div class="middivrow_regcust">
                                <div id="ProspectCallStatusDiv" class="callstatus-rbtn-list rdonotes" style="margin-bottom: 10px;">
                                    <asp:RadioButtonList ID="CallStatusRadioList" runat="server" RepeatDirection="Vertical">
                                    </asp:RadioButtonList>
                                </div>
                                <div id="RemoveFromQueueDiv" runat="server" style="margin-bottom: 10px; display: none;">
                                    <asp:CheckBox ID="RemoveFromQueueChkBx" runat="server"></asp:CheckBox>
                                    Remove From Queue
                                    <asp:CheckBox ID="DoNotCallChkBx" runat="server"></asp:CheckBox>
                                    Do Not Call
                                </div>
                                <div class="rdonotes" id="CallBackOptionsContainerDiv" runat="server" style="padding: 5px; background: #f5f5f5; border: solid 1px #e7e7e7; display: none;">
                                    <div style="float: left; width: 100%; display: none;" id="AllAttemptsExhaustedDiv" runat="server">
                                        <i><b>Note: All the permitted attempts have exhausted. If you still want to re-queue, Please select second option i.e. Specific.</b></i>
                                    </div>
                                    <div style="float: left; width: 100%">
                                        <label id="requeueLabel" runat="server">
                                            <strong>Re-Queue? </strong>
                                        </label>
                                        <asp:RadioButtonList ID="CallBackOptionsRadioList" runat="server" RepeatDirection="Horizontal">
                                        </asp:RadioButtonList>
                                    </div>
                                    <div id="ScheduleInputContainerDiv" style="float: left; width: 100%; margin-top: 5px; display: none;">
                                        <label>
                                            <strong>Schedule on:</strong></label>
                                        <span style="width: 100px;">
                                            <i>Date:</i>
                                            <asp:TextBox ID="ScheduledDateText" runat="server" Width="80px" class="scheduleddate-dp date-picker" MaxLength="12"></asp:TextBox>
                                        </span>
                                        <span>
                                            <i>Time:</i>
                                            <asp:TextBox ID="ScheduledTimeText" runat="server" Width="50px"></asp:TextBox>
                                        </span>
                                    </div>
                                </div>
                                <div id="CallDispositionDiv" runat="server" style="float: left; width: 100%; margin-top: 5px;">
                                    <span>Call Disposition:</span>
                                    <span>
                                        <asp:DropDownList ID="CallDispositionDropdown" runat="server"></asp:DropDownList></span>
                                </div>
                                <div id="NotIntrestedReasonDiv" style="float: left; width: 100%; margin-top: 15px; margin-bottom: 15px; display: none;">
                                    <span style="width: 92px; display: inline-block;">Reason:<sup class="reqiredmark">*</sup></span>
                                    <span>
                                        <asp:DropDownList ID="NotIntrestedDropDownList" runat="server"></asp:DropDownList></span>
                                </div>

                                <!-- PhoneConsent Div -->
                                <div id="PhoneConsent" style="float: left; width: 515px; margin-top: 10px; margin-bottom: 10px; display: none;" runat="Server">
                                    <fieldset style="width: 95%;">
                                        <legend><b>Save Phone and Consent</b></legend>
                                        <div style="clear: both; padding-bottom: 5px;">
                                            <span class="titletext_editp">Phone (Home): </span>
                                            <span class="inputfieldcon_editp" style="margin: 0; width: 140px; padding-right: 20px;">
                                                <asp:TextBox ID="txtphonehome" runat="server" CssClass="inputf_editp mask-phone" Width="140px"></asp:TextBox>
                                            </span>

                                            <span class="titletxt_regcust" style="width: 50px;"><b>Consent:</b></span>
                                            <asp:DropDownList ID="ddlPatientConsentPrimary" runat="server" Width="90px" CssClass="inputf_pw">
                                            </asp:DropDownList>
                                        </div>

                                        <br />

                                        <div style="clear: both; padding-bottom: 5px;">
                                            <span class="titletext_editp">Phone (Office): </span>
                                            <span class="inputfieldcon_editp" style="width: 90px; margin: 0; padding-right: 10px;">
                                                <asp:TextBox ID="txtphoneoffice" runat="server" CssClass="inputf_editp mask-phone"
                                                    Width="90px"></asp:TextBox>
                                            </span>

                                            <span class="inputfieldcon_editp" style="width: 40px; margin: 0; padding-right: 20px;">
                                                <asp:TextBox ID="PhoneOfficeExtension" placeholder="Ext" runat="server" CssClass="inputf_editp" Width="40px" />
                                            </span>

                                            <span class="titletxt_regcust" style="width: 50px;"><b>Consent:</b></span>
                                            <asp:DropDownList ID="ddlPatientConsentOffice" runat="server" Width="90px" CssClass="inputf_pw">
                                            </asp:DropDownList>
                                        </div>

                                        <br />

                                        <div style="clear: both; padding-bottom: 5px;">
                                            <span class="titletext_editp">Phone (Cell):</span>
                                            <span class="inputfieldcon_editp" style="margin: 0; width: 140px; padding-right: 20px;">
                                                <asp:TextBox ID="txtphonecell" runat="server" CssClass="inputf_editp mask-phone" Width="140px"></asp:TextBox>
                                            </span>

                                            <span class="titletxt_regcust" style="width: 50px;"><b>Consent:</b></span>
                                            <asp:DropDownList ID="ddlPatientConsentCell" runat="server" Width="90px" CssClass="inputf_pw">
                                            </asp:DropDownList>
                                        </div>

                                        <asp:ImageButton ID="imgSaveConsent" style="padding-right: 10px;" runat="server" CssClass="" ImageAlign="Right" ImageUrl="~/App/Images/save-button.gif" 
                                            OnClick="imgSaveConsent_Click" OnClientClick="return SaveConsentValidation();"></asp:ImageButton>
                                    </fieldset>
                                </div>

                                <p class="contentrow_regcust">
                                    <span class="orngheadtxt_regcust" id="spSearchType" runat="server">Search Customer</span> <sup class="reqiredmark" id="notesRequired" style="display: none;">*</sup>
                                </p>
                                <div>
                                    <%--THIS IS FOR aDD NOTES--%>
                                    <asp:Panel ID="Panel1" runat="server">
                                        <div>
                                            <%--THIS IS FOR aDD NOTES--%>
                                            <asp:Panel ID="Panel2" runat="server">
                                                <div class="maindiv_ecpopup">
                                                    <p>
                                                        <img src='<%= ResolveUrl("~/App/Images/CCRep/specer.gif") %>' width="480" height="20" />
                                                    </p>
                                                    <p class="innerrow_ecpopup">
                                                        <asp:TextBox CssClass="inputf_def" runat="server" ID="txtNotes" TextMode="MultiLine"
                                                            Rows="5" Columns="80"></asp:TextBox>
                                                    </p>
                                                    <p>
                                                        <img src='<%= ResolveUrl("~/App/Images/CCRep/specer.gif") %>' width="480" height="10" />
                                                    </p>
                                                    <p>
                                                        <img src='<%= ResolveUrl("~/App/Images/CCRep/specer.gif") %>' width="480" height="10" />
                                                    </p>
                                                    <p class="innerrow_ecpopup" id="pNewCust" style="display: none;" runat="server">
                                                        <span>Do you wish to Register any of your Spouse/Relative etc.</span><br />
                                                        <br />
                                                        <%--<span>Is New Customer [<asp:LinkButton ID="lnkRegNewCust" runat="server" OnClick="lnkRegNewCust_Click">New Customer</asp:LinkButton>]</span><br />--%>
                                                        <span>Is Spouse/Relative [<asp:LinkButton ID="lnkRegExistCust" runat="server" OnClick="lnkRegExistCust_Click">Spouse/Relative</asp:LinkButton>]</span>
                                                    </p>
                                                    <p class="innerrow_ecpopup">
                                                        <span class="buttoncon_default">
                                                            <asp:ImageButton ID="imgEndCall" runat="server" CssClass="" ImageUrl="~/App/Images/finish-button.gif"
                                                                OnClick="imgEndCall_Click" OnClientClick="return EndCallValidation();"></asp:ImageButton>
                                                        </span><span class="buttoncon5_default" id="spContinueCall" runat="server">
                                                            <asp:ImageButton ID="imgContinueCall" runat="server" CssClass="" ImageUrl="~/App/Images/continue-call-btn.gif"
                                                                OnClick="imgContinueCall_Click" OnClientClick="return EndCallValidation();"></asp:ImageButton>
                                                        </span>
                                                    </p>
                                                </div>
                                            </asp:Panel>
                                        </div>
                                    </asp:Panel>
                                </div>
                            </div>
                            <asp:HiddenField ID="hfConclusion" runat="server" />
                            <asp:HiddenField ID="hfCallStartTime" runat="server" />
                            <asp:HiddenField ID="hfThankYou" runat="server" />
                            <asp:HiddenField ID="hfHpCallQueueId" runat="server" />
                            <asp:HiddenField ID="hfEventId" runat="server" />
                            <asp:HiddenField ID="hfHpHealthPlanId" runat="server" />
                            <asp:HiddenField ID="hfHpFillEventZipCode" runat="server" />
                            <asp:HiddenField ID="hfHpRadius" runat="server" />
                            <asp:HiddenField ID="hfHpCriteriaId" runat="server" />
                            <asp:HiddenField ID="hfHpCampaignId" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
            m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', 'https://www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-957361-18', 'auto');
        ga('send', 'pageview');

        var scriptPopup = null;

       

        function ShowConsentSaveSuccessAlert() {
            alert("Consent saved successfully!");
        }

        function SaveConsentValidation() {
            var txtHPhone = document.getElementById("<%= this.txtphonehome.ClientID %>");
            var txtCPhone = $("input:text[name$='txtphonecell']");
            var txtOPhone = $("input:text[name$='txtphoneoffice']");
            var phoneHomeConsent = document.getElementById("<%=this.ddlPatientConsentPrimary.ClientID %>");
            var phoneCellConsent = document.getElementById("<%=this.ddlPatientConsentCell.ClientID %>");
            var phoneOfficeConsent = document.getElementById("<%=this.ddlPatientConsentOffice.ClientID %>");

            if ($(phoneHomeConsent).val() != '<%= (long)Falcon.App.Core.Users.Enum.PatientConsent.Unknown%>' && ($(txtHPhone).val() == "(___)-___-____" || $(txtHPhone).val() == "")) {
                alert("Enter Phone(Home) to save consent");
                return false;
            }

            if ($(phoneOfficeConsent).val() != '<%= (long)Falcon.App.Core.Users.Enum.PatientConsent.Unknown%>' && ($(txtOPhone).val() == "(___)-___-____" || $(txtOPhone).val() == "")) {
                alert("Enter Phone(Office) to save consent");
                return false;
            }
            if ($(phoneCellConsent).val() != '<%= (long)Falcon.App.Core.Users.Enum.PatientConsent.Unknown%>' && ($(txtCPhone).val() == "(___)-___-____" || $(txtCPhone).val() == "")) {
                alert("Enter Phone(Cell) to save consent");
                return false;
            }

            if ($(phoneCellConsent).val() == '<%= (long)Falcon.App.Core.Users.Enum.PatientConsent.Unknown%>'
                && $(phoneOfficeConsent).val() == '<%= (long)Falcon.App.Core.Users.Enum.PatientConsent.Unknown%>'
                && $(phoneHomeConsent).val() == '<%= (long)Falcon.App.Core.Users.Enum.PatientConsent.Unknown%>') {
                var isContinue = confirm("Consent for all phone numbers is set to Unknown. Do you want to continue?");

                if (!isContinue)
                    return false;
            }

            return true;
        }

    </script>
</asp:Content>
