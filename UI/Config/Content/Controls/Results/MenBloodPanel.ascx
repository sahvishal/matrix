<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenBloodPanel.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.MenBloodPanel" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/MenBloodPanel.js?q=<%= VersionNumber %>"></script>

<div id="MenBloodPanel_hip" runat="server">
    <div class="orange-band test-section-header">
        <h5>
            <span class="org-heading"><strong>Men Blood Panel Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyMenBloodPanel" class="conductedby-ddl">
            </select>
        </span><span class="chk_orngband" id="menBloodPanel-critical-span">
            <input type="checkbox" id="DescribeSelfPresentMenBloodPanelInputCheck" onclick="onClick_CriticalDataMenBloodPanel();" />Critical</span>
        <span class="chk_orngband" id="menBloodPanel-priorityInQueue-span">
            <input type="checkbox" id="PriorityInQueueTestMenBloodPanelCheck" onclick="onClick_PriorityInQueueDataMenBloodPanel();" />Priority In Queue
        </span>
        <span class="chk_orngband" id="menBloodPanel-retest-span">
            <input type="checkbox" id="Retest_64" />Retest
        </span>
    </div>
    <div class="contentrow">
        <div style="float: left; padding: 10px; width: 30%;">
            <strong>PSASCR: </strong>
            <input type="text" id="menBloodPanelPSASCRtextbox" class="input_bdrbot" style="width: 100px;" />
            <span class="skip-checkbox" style="float: left; width: 100%; display: none;">
                <input type="checkbox" id="menBloodPanelPSASCRSkipCheckBox" style="margin-left: 55px;" />
                Skip
            </span>
        </div>
        <div style="float: left; padding: 10px; width: 30%;">
            <strong>LCRP: </strong>
            <input type="text" id="menBloodPanelLCRPtextbox" class="input_bdrbot" style="width: 100px;" />
            <span class="skip-checkbox" style="float: left; width: 100%; display: none;">
                <input type="checkbox" id="menBloodPanelLCRPSkipCheckBox" style="margin-left: 38px;" />
                Skip
            </span>
        </div>
        <div style="float: left; padding: 10px; width: 30%;">
            <strong>TESTSCRE: </strong>
            <input type="text" id="menBloodPanelTESTSCREtextbox" class="input_bdrbot" style="width: 100px;" />
            <span class="skip-checkbox" style="float: left; width: 100%; display: none;">
                <input type="checkbox" id="menBloodPanelTESTSCRESkipCheckBox" style="margin-left: 67px;" />
                Skip
            </span>
        </div>
    </div>
    <div class="left_info1">
        <div class="labelwdt2 finding">
            <asp:DataList runat="server" ID="UnableToScreenMenBloodPanelDataList" EnableViewState="false"
                RepeatLayout="Flow" CssClass="dtl-unabletoscreen-menBloodPanel unable-to-screen-section" GridLines="None"
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
            <textarea id="technotesMenBloodPanel" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
                rows="2" cols="54"></textarea>
        </div>
    </div>
    <div class="physician-section" style="float: left; width: 100%; clear: both; margin-top: 5px;">
        <fieldset style="float: left; width: 98%; border-radius: 4px;">
            <legend>Remarks </legend>
            <div style="float: left; width: 40%;">
                <input type="checkbox" id="technicallyltdbutreadableMenBloodPanelinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Technically limited, but readable</b><br />
                <input type="checkbox" id="repeatstudyMenBloodPanelinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Repeat Study/Unreadable</b><br />
                <input type="checkbox" id="criticalMenBloodPanel" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b>
            </div>
            <div style="float: left; width: 58%;">
                <textarea id="physicianRemarksMenBloodPanel" rows="3" style="width: 98%;"></textarea>
            </div>
        </fieldset>
    </div>

</div>
<div id="MenBloodPanel_chat" runat="server">
    <div class="orange-band test-section-header">
        <h5>
            <span class="org-heading"><strong>Men Blood Panel Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyMenBloodPanel" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="menBloodPanel-retest-span">
            <input type="checkbox" id="Retest_64" />Retest
        </span>
    </div>
     <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
        <div class="hlfbox">
            <div class="hrows">
                <div class="nrow" style="margin-left: 12px;">
                    <input type="checkbox" id="chk_MenBloodPanelcapturebyChat" />
                    <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
        </div>
    </div>
</div>

<script language="javascript" type="text/javascript">
    var testTypeMenBloodPanel = '<%= (long)TestType.MenBloodPanel %>';

    var isMenBloodPanelResultEntryType = '<%= IsResultEntrybyChat %>';

    var menBloodPanel = null;
    function SetMenBloodPanelData(testResult) {
        menBloodPanel = new MenBloodPanel(testResult);
        menBloodPanel.setData();
    }

    function GetMenBloodPanelData() {
        if (menBloodPanel == null) menBloodPanel = new MenBloodPanel();
        return menBloodPanel.getData();
    }

</script>
