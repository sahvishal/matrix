<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WomenBloodPanel.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.WomenBloodPanel" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/WomenBloodPanel.js?q=<%= VersionNumber %>"></script>
<div id="womenBloodPanel_hip" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
<div class="orange-band test-section-header">
    <h5>
        <span class="org-heading"><strong>Women Blood Panel Results</strong></span>
    </h5>
    <span class="chk_orngband">
        <select id="conductedbyWomenBloodPanel" class="conductedby-ddl">
        </select>
    </span><span class="chk_orngband" id="WomenBloodPanel-critical-span">
        <input type="checkbox" id="DescribeSelfPresentWomenBloodPanelInputCheck" onclick="onClick_CriticalDataWomenBloodPanel();" />Critical</span>
    <span class="chk_orngband" id="womenBloodPanel-priorityInQueue-span">
        <input type="checkbox" id="PriorityInQueueTestWomenBloodPanelCheck" onclick="onClick_PriorityInQueueDataWomenBloodPanel();" />Priority In Queue
    </span>
    <span class="chk_orngband" id="womenBloodPanel-retest-span">
        <input type="checkbox" id="Retest_65" />Retest
    </span>
</div>
<div class="contentrow">
    <div style="float: left; padding: 10px; width: 30%;">
        <strong>TSHSCR: </strong>
        <input type="text" id="WomenBloodPanelTSHSCRtextbox" class="input_bdrbot" style="width: 100px;" />
        <span class="skip-checkbox" style="float: left; width: 100%; display: none;">
            <input type="checkbox" id="WomenBloodPanelTSHSCRSkipCheckBox" style="margin-left: 55px;" />
            Skip
        </span>
    </div>
    <div style="float: left; padding: 10px; width: 30%;">
        <strong>LCRP: </strong>
        <input type="text" id="WomenBloodPanelLCRPtextbox" class="input_bdrbot" style="width: 100px;" />
        <span class="skip-checkbox" style="float: left; width: 100%; display: none;">
            <input type="checkbox" id="WomenBloodPanelLCRPSkipCheckBox" style="margin-left: 55px;" />
            Skip
        </span>
    </div>
    <div style="float: left; padding: 10px; width: 30%;">
        <strong>VitD: </strong>
        <input type="text" id="WomenBloodPanelVitDtextbox" class="input_bdrbot" style="width: 100px;" />
        <span class="skip-checkbox" style="float: left; width: 100%; display: none;">
            <input type="checkbox" id="WomenBloodPanelVitDSkipCheckBox" style="margin-left: 55px;" />
            Skip
        </span>
    </div>
</div>
<div class="left_info1">
    <div class="labelwdt2 finding">
        <asp:DataList runat="server" ID="UnableToScreenWomenBloodPanelDataList" EnableViewState="false"
            RepeatLayout="Flow" CssClass="dtl-unabletoscreen-WomenBloodPanel unable-to-screen-section" GridLines="None"
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
        <textarea id="technotesWomenBloodPanel" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
            rows="2" cols="54"></textarea>
    </div>
</div>
<div class="physician-section" style="float: left; width: 100%; clear: both; margin-top: 5px;">
    <fieldset style="float: left; width: 98%; border-radius: 4px;">
        <legend>Remarks </legend>
        <div style="float: left; width: 40%;">
            <input type="checkbox" id="technicallyltdbutreadableWomenBloodPanelinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Technically limited, but readable</b><br />
            <input type="checkbox" id="repeatstudyWomenBloodPanelinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Repeat Study/Unreadable</b><br />
            <input type="checkbox" id="criticalWomenBloodPanel" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b>
        </div>
        <div style="float: left; width: 58%;">
            <textarea id="physicianRemarksWomenBloodPanel" rows="3" style="width: 98%;"></textarea>
        </div>
    </fieldset>
</div>
    </div>
<div id="womenBloodPanel_chat" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 50%;">
            <span class="org-heading" style="width: 100%;"><strong>Women Blood Panel Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyWomenBloodPanel" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="womenBloodPanel-retest-span">
            <input type="checkbox" id="Retest_65" />Retest
        </span>
    </div>
    <div class="hrows womenBloodPanel-verificationpanel" style="color: Red; background: #fff0a5; border: solid 1px fff0a5; padding: 2px 2px 2px 5px; display: none;">
    </div>
     <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
             
     <div class="hlfbox">
           <div class="hrows">
             <div class="nrow" style="margin-left:12px;">
                  <input type="checkbox" id="chk_womenBloodPanelcapturebyChat" />
                   <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
     </div>
             
     </div>
</div>
<script language="javascript" type="text/javascript">
    var testTypeWomenBloodPanel = '<%= (long)TestType.WomenBloodPanel %>';
    var IswomenBloodPanelResultEntryExternaly = '<%=IsResultEntrybyChat%>'
    var womenBloodPanel = null;
    function SetWomenBloodPanelData(testResult) {
        womenBloodPanel = new WomenBloodPanel(testResult);
        womenBloodPanel.setData();
    }

    function GetWomenBloodPanelData() {
        if (womenBloodPanel == null) womenBloodPanel = new WomenBloodPanel();
        return womenBloodPanel.getData();
    }

</script>
