<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Crp.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.Crp" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/Crp.js?q=<%= VersionNumber %>"></script>
<div id="Crp_hip" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
<div class="orange-band test-section-header">
    <h5>
        <span class="org-heading"><strong>CRP Results</strong></span>
    </h5>
    <span class="chk_orngband">
        <select id="conductedbyCrp" class="conductedby-ddl">
        </select>
    </span><span class="chk_orngband" id="crp-critical-span">
        <input type="checkbox" id="DescribeSelfPresentCrpInputCheck" onclick="onClick_CriticalDataCrp();" />Critical </span>
    <span class="chk_orngband" id="crp-priorityInQueue-span">
        <input type="checkbox" id="PriorityInQueueTestCrpCheck" onclick="onClick_PriorityInQueueDataCrp();" />Priority In Queue
    </span>
    <span class="chk_orngband" id="crp-retest-span">
        <input type="checkbox" id="Retest_17" />Retest
    </span>
</div>
<div class="left_info1">
    <div class="labelwdt2 finding">
        <asp:DataList runat="server" ID="UnableToScreenCrpDataList" EnableViewState="false"
            RepeatLayout="Flow" CssClass="dtl-unabletoscreen-Crp unable-to-screen-section" GridLines="None"
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
    <div class="rrow" id="CrpReadingDiv" runat="server" style="display: none;">
        <strong>LCRP: </strong>
        <input type="text" id="lcrptextbox" class="input_bdrbot" style="width: 100px;" />
    </div>
    <div class="rrow">
        <b>Technician Notes: </b>
        <br />
        <textarea id="technotesCrp" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
            rows="2" cols="54"></textarea>
    </div>
</div>
    </div>

<div id="Crp_chat" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 50%;">
            <span class="org-heading" style="width: 100%;"><strong>CRP Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyCrp" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="crp-retest-span">
            <input type="checkbox" id="Retest_17" />Retest
        </span>
    </div>
    <div class="hrows Crp-verificationpanel" style="color: Red; background: #fff0a5; border: solid 1px fff0a5; padding: 2px 2px 2px 5px; display: none;">
    </div>
     <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
             
     <div class="hlfbox">
           <div class="hrows">
             <div class="nrow" style="margin-left:12px;">
                  <input type="checkbox" id="chk_crpcapturebyChat" />
                   <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
     </div>
             
     </div>
</div>


<script language="javascript" type="text/javascript">
    var testTypeCrp = '<%= (long)TestType.Crp %>';
    var IscrpResultEntryExternaly = '<%= IsResultEntrybyChat %>';
    var crp = null;
    function SetCrpData(testResult) {
        crp = new Crp(testResult);
        crp.setData();
    }

    function GetCrpData() {
        if (crp == null) crp = new Crp();
        return crp.getData();
    }

</script>
