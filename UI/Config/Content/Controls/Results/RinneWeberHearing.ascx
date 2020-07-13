<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RinneWeberHearing.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.RinneWeberHearing" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/RinneWeberHearing.js?q=<%= VersionNumber %>"></script>

<div id="RinneWeberHearing_hip" runat="server">
    <div class="orange-band test-section-header">
        <h5>
            <span class="org-heading"><strong>Rinne and Weber Hearing Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyRinneWeberHearing" class="conductedby-ddl">
            </select>
        </span><span class="chk_orngband" id="RinneWeberHearing-critical-span">
            <input type="checkbox" id="DescribeSelfPresentRinneWeberHearingInputCheck" onclick="onClick_CriticalDataRinneWeberHearing();" />Critical</span>
        <span class="chk_orngband" id="rinneWeberHearing-priorityInQueue-span">
            <input type="checkbox" id="PriorityInQueueTestRinneWeberHearingCheck" onclick="onClick_PriorityInQueueDataRinneWeberHearing();" />Priority In Queue
        </span>
        <span class="chk_orngband" id="rinneWeberHearing-retest-span">
            <input type="checkbox" id="Retest_85" />Retest
        </span>
    </div>
    <div class="left_info1">
        <div class="labelwdt2" style="padding-bottom: 10px;">
            <div>
                <span style="width: 80px; display: inline-block;"><strong>Weber: </strong></span>
                <span class="WeberNormal">
                    <input type="radio" id="RinneWeberHearingWeberNormalinputcheck" value="true" name="Weber" />
                    Normal  </span>
                <span class="WeberAbnormal">
                    <input type="radio" id="RinneWeberHearingWeberAbnormalinputcheck" value="true" name="Weber" />
                    Abnormal  </span>
            </div>
            <div>
                <span style="width: 80px; display: inline-block;"><strong>Rinne: </strong></span>
                <span class="RinneNormal">
                    <input type="radio" id="RinneWeberHearingRinneNormalinputcheck" value="true" name="Rinne" />
                    Normal  </span>
                <span class="RinneAbnormal">
                    <input type="radio" id="RinneWeberHearingRinneAbnormalinputcheck" value="true" name="Rinne" />
                    Abnormal  </span>
            </div>
        </div>
        <div class="labelwdt2 finding">
            <asp:DataList runat="server" ID="UnableToScreenRinneWeberHearingDataList" EnableViewState="false"
                RepeatLayout="Flow" CssClass="dtl-unabletoscreen-RinneWeberHearing unable-to-screen-section" GridLines="None"
                RepeatDirection="Horizontal">
                <ItemTemplate>
                    <input type="checkbox" id="chkUnableScreenReason" />
                    <b>Unable To Screen</b>
                    <input type="hidden" id="hfUnableScreenReasonID" value='<%# Convert.ToString((int)DataBinder.Eval(Container.DataItem, "Reason")) %>' />
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div class="lrow clear-all-selection">
            <a style="margin-left: 5px;" id="clear-all-RinneWeberHearing" href="javascript:void(0);" onclick="clearAllRinneWeberHearingSelection();">Clear All Selection</a>
        </div>
    </div>
    <div class="rgt_info1">
        <div class="rrow">
            <b>Technician Notes: </b>
            <br />
            <textarea id="technotesRinneWeberHearing" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
                rows="2" cols="54"></textarea>
        </div>
    </div>
    <div class="physician-section" style="float: left; width: 100%; clear: both; margin-top: 5px;">
        <fieldset style="float: left; width: 98%; border-radius: 4px;">
            <legend>Remarks </legend>
            <div style="float: left; width: 40%;">
                <div style="display: none">
                    <input type="checkbox" id="RinneWeberHearingtechnicallyltdbutreadableinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Technically limited, but readable</b><br />
                    <input type="checkbox" id="RinneWeberHearingrepeatstudyinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Repeat Study/Unreadable</b><br />
                </div>

                <div style="float: left;">
                    <input type="checkbox" id="criticalRinneWeberHearing" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b>
                </div>
            </div>
            <div style="float: left; width: 58%;">
                <textarea id="physicianRemarksRinneWeberHearing" rows="3" style="width: 98%;"></textarea>
            </div>
        </fieldset>
    </div>

</div>
<div id="RinneWeberHearing_chat" runat="server">
    <div class="orange-band test-section-header">
        <h5>
            <span class="org-heading"><strong>Rinne and Weber Hearing Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyRinneWeberHearing" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="rinneWeberHearing-retest-span">
            <input type="checkbox" id="Retest_85" />Retest
        </span>
    </div>
     <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
        <div class="hlfbox">
            <div class="hrows">
                <div class="nrow" style="margin-left: 12px;">
                    <input type="checkbox" id="chk_RinneWeberHearingcapturebyChat" />
                    <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
        </div>
    </div>
</div>

<script language="javascript" type="text/javascript">
    var testTypeRinneWeberHearing = '<%= (long)TestType.RinneWeberHearing %>';

    var isRinneWeberHearingResultEntryType = '<%= IsResultEntrybyChat %>';

    var rinneWeberHearing = null;
    function SetRinneWeberHearingData(testResult) {
        rinneWeberHearing = new RinneWeberHearing(testResult);
        rinneWeberHearing.setData();
    }

    function GetRinneWeberHearingData() {
        if (rinneWeberHearing == null) rinneWeberHearing = new RinneWeberHearing();
        return rinneWeberHearing.getData();
    }

</script>
