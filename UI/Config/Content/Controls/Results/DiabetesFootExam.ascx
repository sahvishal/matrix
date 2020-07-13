<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DiabetesFootExam.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.DiabetesFootExam" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/DiabetesFootExam.js?q=<%= VersionNumber %>"></script>

<div id="DiabetesFootExam_hip" runat="server">
    <div class="orange-band test-section-header">
        <h5>
            <span class="org-heading"><strong>Diabetes Foot Exam Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyDiabetesFootExam" class="conductedby-ddl">
            </select>
        </span><span class="chk_orngband" id="DiabetesFootExam-critical-span">
            <input type="checkbox" id="DescribeSelfPresentDiabetesFootExamInputCheck" onclick="onClick_CriticalDataDiabetesFootExam();" />Critical</span>
        <span class="chk_orngband" id="diabetesFootExam-priorityInQueue-span">
            <input type="checkbox" id="PriorityInQueueTestDiabetesFootExamCheck" onclick="onClick_PriorityInQueueDataDiabetesFootExam();" />Priority In Queue
        </span>
        <span class="chk_orngband" id="diabetesFootExam-retest-span">
            <input type="checkbox" id="Retest_71" />Retest
        </span>
    </div>
    <div class="left_info1">
        <div class="labelwdt2" style="padding-bottom: 10px;">
            <div>
                <span style="width: 80px; display: inline-block;"><strong>Left Foot: </strong></span>
                <span class="leftFootYes">
                    <input type="radio" id="DiabetesFootExamLeftFootYesinputcheck" value="true" name="LeftFoot" />
                    Yes  </span>
                <span class="leftFootNo">
                    <input type="radio" id="DiabetesFootExamLeftFootNoinputcheck" value="true" name="LeftFoot" />
                    No  </span>
            </div>
            <div>
                <span style="width: 80px; display: inline-block;"><strong>Right Foot: </strong></span>
                <span class="rightFootYes">
                    <input type="radio" id="DiabetesFootExamRightFootYesinputcheck" value="true" name="RightFoot" />
                    Yes  </span>
                <span class="rightFootNo">
                    <input type="radio" id="DiabetesFootExamRightFootNoinputcheck" value="true" name="RightFoot" />
                    No  </span>
            </div>
        </div>
        <div class="labelwdt2 finding">
            <asp:DataList runat="server" ID="UnableToScreenDiabetesFootExamDataList" EnableViewState="false"
                RepeatLayout="Flow" CssClass="dtl-unabletoscreen-DiabetesFootExam unable-to-screen-section" GridLines="None"
                RepeatDirection="Horizontal">
                <ItemTemplate>
                    <input type="checkbox" id="chkUnableScreenReason" />
                    <b>Unable To Screen</b>
                    <input type="hidden" id="hfUnableScreenReasonID" value='<%# Convert.ToString((int)DataBinder.Eval(Container.DataItem, "Reason")) %>' />
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
    <div class="rgt_info1">
        <div class="rrow">
            <b>Technician Notes: </b>
            <br />
            <textarea id="technotesDiabetesFootExam" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
                rows="2" cols="54"></textarea>
        </div>
    </div>
    <div class="physician-section" style="float: left; width: 100%; clear: both; margin-top: 5px;">
        <fieldset style="float: left; width: 98%; border-radius: 4px;">
            <legend>Remarks </legend>
            <div style="float: left; width: 40%;">
                <div style="display: none">
                    <input type="checkbox" id="DiabetesFootExamtechnicallyltdbutreadableinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Technically limited, but readable</b><br />
                    <input type="checkbox" id="DiabetesFootExamrepeatstudyinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Repeat Study/Unreadable</b><br />
                </div>

                <div style="float: left;">
                    <input type="checkbox" id="criticalDiabetesFootExam" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b>
                </div>
            </div>
            <div style="float: left; width: 58%;">
                <textarea id="physicianRemarksDiabetesFootExam" rows="3" style="width: 98%;"></textarea>
            </div>
        </fieldset>
    </div>

</div>

<div id="DiabetesFootExam_chat" runat="server">
    <div class="orange-band test-section-header">
        <h5>
            <span class="org-heading"><strong>Diabetes Foot Exam Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyDiabetesFootExam" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="diabetesFootExam-retest-span">
            <input type="checkbox" id="Retest_71" />Retest
        </span>
    </div>
    <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
        <div class="hlfbox">
            <div class="hrows">
                <div class="nrow" style="margin-left: 12px;">
                    <input type="checkbox" id="chk_DiabetesFootExamcapturebyChat" />
                    <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
        </div>
    </div>
</div>


<script language="javascript" type="text/javascript">
    var testTypeDiabetesFootExam = '<%= (long)TestType.DiabetesFootExam %>';

    var isDiabetesFootExamResultEntryType = '<%= IsResultEntrybyChat %>';

    var diabetesFootExam = null;
    function SetDiabetesFootExamData(testResult) {
        diabetesFootExam = new DiabetesFootExam(testResult);
        diabetesFootExam.setData();
    }

    function GetDiabetesFootExamData() {
        if (diabetesFootExam == null) diabetesFootExam = new DiabetesFootExam();
        return diabetesFootExam.getData();
    }

</script>
