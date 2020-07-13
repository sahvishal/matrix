<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QualityMeasures.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.QualityMeasures" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/QualityMeasures.js?q=<%= VersionNumber %>"></script>
<style type="text/css">
    .qm-ddl select {
        width: 150px;
        margin: 0px 0px 0px 5px;
        background-color: #ffffff;
        border: 1px solid;
        color: #010105;
    }

    .qm-controlgroup {
        width: 400px;
        margin-top: 10px;
        float: left;
        clear: both;
    }
</style>

<div id="QualityMeasures_hip" runat="server">

    <div class="orange-band test-section-header">
        <h5>
            <span class="org-heading"><strong>Quality Measures</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyQualityMeasures" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="QualityMeasures-critical-span">
            <input type="checkbox" id="DescribeSelfPresentQualityMeasuresInputCheck" onclick="onClick_CriticalDataQualityMeasures();" />Critical </span>
        <span class="chk_orngband" id="QualityMeasures-priorityInQueue-span">
            <input type="checkbox" id="PriorityInQueueTestQualityMeasuresCheck" onclick="onClick_PriorityInQueueDataQualityMeasures();" />Priority In Queue
        </span>
        <span class="chk_orngband" id="QualityMeasures-retest-span">
            <input type="checkbox" id="Retest_84" />Retest
        </span>
    </div>
    <div class="left_info1">
        <div class="labelwdt2 finding qm-ddl qm-controlgroup ddl-functional-assessment">
            Functional Assessment Score(Katz):
        <asp:DropDownList runat="server" ID="ddlFunctionalAssessment" />
        </div>
        <div class="labelwdt2 finding qm-ddl qm-controlgroup ddl-pain-assessment">
            Pain Assessment Score: 
        <asp:DropDownList runat="server" ID="ddlPainAssessmentScore" />
        </div>

        <div class="qm-controlgroup">
            Memory recall score:
        <input type="text" style="width: 80px" class="input_bdrbot" id="MemoryRecallScore" onkeydown="return KeyPress_DecimalAllowedOnly_withsigns(event);" />
        </div>
    </div>
    <div class="rgt_info1">
        <div class="qm-controlgroup">
            <span style="width: 80px; display: inline-block;"><strong>Clock: </strong></span>
            <span class="ClockPass">
                <input type="radio" id="qualitymeasuresClockPassRbtn" value="true" name="clock" />
                Pass  </span>
            <span class="ClockFail">
                <input type="radio" id="qualitymeasuresClockFailRbtn" value="true" name="clock" />
                Fail  </span>
        </div>
        <div class="qm-controlgroup">
            <span style="width: 80px; display: inline-block;"><strong>Gait: </strong></span>
            <span class="GaitPass">
                <input type="radio" id="qualitymeasuresGaitPassRbtn" value="true" name="Gait" />
                Pass  </span>
            <span class="GaitFail">
                <input type="radio" id="qualitymeasuresGaitFailRbtn" value="true" name="Gait" />
                Fail  </span>
        </div>
    </div>
    <div class="left_info1">
        <div class="left" style="width: 32%;">
            <asp:DataList runat="server" ID="dtlQualityMeasuresSelectedUnableToScreen" GridLines="None"
                EnableViewState="false" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="dtl-unabletoscreen-QualityMeasures unable-to-screen-section">
                <ItemTemplate>
                    <input type="checkbox" id="chkUnableScreenReason" class="chk-selected-QualityMeasures-us" />
                    <b><%# DataBinder.Eval(Container.DataItem, "DisplayName") %></b>
                    <input type="hidden" id="hfUnableScreenReasonID" class="hdn-selected-QualityMeasures-us" value='<%# Convert.ToString((int)DataBinder.Eval(Container.DataItem, "Reason")) %>' />
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div class="lrow clear-all-selection">
            <a style="margin-left: 5px;" id="clear-all-QualityMeasures" href="javascript:void(0);" onclick="clearAllQualityMeasuresSelection();">Clear All Selection</a>
        </div>
    </div>
    <div class="rgt_info1">
        <div class="rrow">
            <b>Technician Notes: </b>
            <br />
            <textarea id="technotesQualityMeasures" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
                rows="2" cols="54"></textarea>
        </div>
        <div class="rrow test-not-performed-section" id="testnotPerformedQualityMeasures">
            <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0" />
            <b>Test Not Performed</b>
            <div class="test-not-performed-container" style="display: none;">
                <b>Reason : </b>
                <br />
                <asp:DropDownList ID="ddlTestNotPerformedReasonQualityMeasures" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
                </asp:DropDownList>
                <br />
                <div>
                    <b>Notes :</b>
                    <br />
                    <textarea rows="2" cols="54"></textarea>
                </div>
            </div>
        </div>
    </div>

    <%--Right Part Starts here--%>
    <div class="physician-section" style="float: left; width: 100%; clear: both; margin-top: 5px;">
        <fieldset style="float: left; width: 98%; border-radius: 4px;">
            <legend>Remarks </legend>
            <div style="float: left; width: 40%;">
                <div style="display: none;">
                    <input type="checkbox" id="technicallyltdbutreadableQualityMeasuresinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Technically limited, but readable</b><br />
                    <input type="checkbox" id="repeatstudyQualityMeasuresinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Unreadable</b><br />
                </div>
                <input type="checkbox" id="criticalQualityMeasures" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b>
            </div>
            <div style="float: left; width: 58%;">
                <textarea id="physicianRemarksQualityMeasures" rows="3" style="width: 98%;"></textarea>
            </div>
        </fieldset>
    </div>

</div>
<div id="QualityMeasures_chat" runat="server">

    <div class="orange-band test-section-header">
        <h5>
            <span class="org-heading"><strong>Quality Measures</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyQualityMeasures" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="QualityMeasures-retest-span">
            <input type="checkbox" id="Retest_84" />Retest
        </span>
    </div>
    <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
        <div class="hlfbox">
            <div class="hrows">
                <div class="nrow" style="margin-left: 12px;">
                    <input type="checkbox" id="chk_QualityMeasurescapturebyChat" />
                    <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
        </div>

    </div>

</div>


<script language="javascript" type="text/javascript">
    var testTypeQualityMeasures = '<%= (long)TestType.QualityMeasures %>';

    var isQualityMeasuresResultEntryType = '<%= IsResultEntrybyChat %>';

    var qualityMeasures = null;
    function SetQualityMeasuresData(testResult) {
        qualityMeasures = new QualityMeasures(testResult);
        qualityMeasures.setData();
    }

    function GetQualityMeasuresData() {
        if (qualityMeasures == null) qualityMeasures = new QualityMeasures();
        return qualityMeasures.getData();
    }

</script>
