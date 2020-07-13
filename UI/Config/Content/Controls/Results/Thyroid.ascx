<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Thyroid.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.Thyroid" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/Thyroid.js?q=<%= VersionNumber %>"></script>
<div id="thyroid_hip" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
<div class="orange-band test-section-header">
    <h5>
        <span class="org-heading"><strong>Thyroid Results</strong></span>
    </h5>
    <span class="chk_orngband">
        <select id="conductedbythyroid" class="conductedby-ddl">
        </select>
    </span><span class="chk_orngband" id="thyroid-critical-span">
        <input type="checkbox" id="DescribeSelfPresentThyroidInputCheck" onclick="onClick_CriticalDataThyroid();" />Critical</span>
    <span class="chk_orngband" id="thyroid-priorityInQueue-span">
        <input type="checkbox" id="PriorityInQueueTestThyroidCheck" onclick="onClick_PriorityInQueueDataThyroid();" />Priority In Queue
    </span>
    <span class="chk_orngband" id="thyroid-retest-span">
        <input type="checkbox" id="Retest_5" />Retest
    </span>
</div>
<div class="left_info1">
    <div class="labelwdt2 finding">
        <asp:DataList runat="server" ID="UnableToScreenThyroidDataList" EnableViewState="false"
            CssClass="dtl-unabletoscreen-thyroid unable-to-screen-section" GridLines="None" RepeatDirection="Horizontal"
            RepeatLayout="Flow">
            <ItemTemplate>
                <input type="checkbox" id="chkUnableScreenReason" />
                <b>Unable To Screen</b>
                <input type="hidden" id="hfUnableScreenReasonID" value='<%# Convert.ToString((int)DataBinder.Eval(Container.DataItem, "Reason")) %>' />
            </ItemTemplate>
        </asp:DataList>
    </div>
</div>
<div class="rgt_info1">
    <div class="rrow" id="ThyroidReadingDiv" runat="server" style="display: none;">
        <strong>TSHSCR: </strong>
        <input type="text" id="tshScrtextbox" class="input_bdrbot" style="width: 100px;" />
    </div>
    <div class="rrow">
        <b>Technician Notes: </b>
        <br />
        <textarea id="technotesthyroid" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
            rows="2" cols="54"></textarea>
    </div>
</div>
    </div>

<div id="thyroid_chat" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 50%;">
            <span class="org-heading" style="width: 100%;"><strong>Thyroid Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbythyroid" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="thyroid-retest-span">
            <input type="checkbox" id="Retest_5" />Retest
        </span>
    </div>
    <div class="hrows thyroid-verificationpanel" style="color: Red; background: #fff0a5; border: solid 1px fff0a5; padding: 2px 2px 2px 5px; display: none;">
    </div>
     <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
             
     <div class="hlfbox">
           <div class="hrows">
             <div class="nrow" style="margin-left:12px;">
                  <input type="checkbox" id="chk_thyroidcapturebyChat" />
                   <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
     </div>
             
     </div>
</div>



<script language="javascript" type="text/javascript">
    var testTypeThyroid = '<%= (long)TestType.Thyroid %>';
    var IsthyroidResultEntryExternaly = '<%= IsResultEntrybyChat %>';
  
    var thyroid = null;
    function SetThyroidData(testResult) {
        thyroid = new Thyroid(testResult);
        thyroid.setData();
    }

    function GetThyroidData() {
        if (thyroid == null) thyroid = new Thyroid();
        return thyroid.getData();
    }

</script>
