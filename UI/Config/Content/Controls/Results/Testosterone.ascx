<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Testosterone.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.Testosterone" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/Testosterone.js?q=<%= VersionNumber %>"></script>
<div id="Testosterone_hip" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
<div class="orange-band test-section-header">
    <h5>
        <span class="org-heading"><strong>Testosterone Results</strong></span>
    </h5>
    <span class="chk_orngband">
        <select id="conductedbyTestosterone" class="conductedby-ddl">
        </select>
    </span><span class="chk_orngband" id="testosterone-critical-span">
        <input type="checkbox" id="DescribeSelfPresentTestosteroneInputCheck" onclick="onClick_CriticalDataTestosterone();" />Critical</span>
    <span class="chk_orngband" id="testosterone-priorityInQueue-span">
        <input type="checkbox" id="PriorityInQueueTestTestosteroneCheck" onclick="onClick_PriorityInQueueDataTestosterone();" />Priority In Queue
    </span>
    <span class="chk_orngband" id="testosterone-retest-span">
        <input type="checkbox" id="Retest_28" />Retest
    </span>
</div>
<div class="left_info1">
    <div class="labelwdt2 finding">
        <asp:DataList runat="server" ID="UnableToScreenTestosteroneDataList" EnableViewState="false"
            RepeatLayout="Flow" CssClass="dtl-unabletoscreen-testosterone unable-to-screen-section" GridLines="None"
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
    <div class="rrow" id="TestosteroneReadingDiv" runat="server" style="display: none;">
        <strong>TESTSCRE: </strong>
        <input type="text" id="testScretextbox" class="input_bdrbot" style="width: 100px;" />
    </div>
    <div class="rrow">
        <b>Technician Notes: </b>
        <br />
        <textarea id="technotesTestosterone" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
            rows="2" cols="54"></textarea>
    </div>
</div>
</div>
<div id="Testosterone_chat" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 50%;">
            <span class="org-heading" style="width: 100%;"><strong>Testosterone Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyTestosterone" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="testosterone-retest-span">
            <input type="checkbox" id="Retest_28" />Retest
        </span>
    </div>
    <div class="hrows Testosterone-verificationpanel" style="color: Red; background: #fff0a5; border: solid 1px fff0a5; padding: 2px 2px 2px 5px; display: none;">
    </div>
     <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
             
     <div class="hlfbox">
           <div class="hrows">
             <div class="nrow" style="margin-left:12px;">
                  <input type="checkbox" id="chk_TestosteronecapturebyChat" />
                   <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
     </div>
             
     </div>
</div>
<script language="javascript" type="text/javascript">
    var testTypeTestosterone = '<%= (long)TestType.Testosterone %>';
    var IstestosteroneResultEntryExternaly = '<%= IsResultEntrybyChat %>';
    var testosterone = null;
    function SetTestosteroneData(testResult) {
        testosterone = new Testosterone(testResult);
        testosterone.setData();
    }

    function GetTestosteroneData() {
        if (testosterone == null) testosterone = new Testosterone();
        return testosterone.getData();
    }

</script>
