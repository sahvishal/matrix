<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Psa.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.Psa" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/Psa.js?q=<%= VersionNumber %>"></script>

<div id="psa_hip" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">

<div class="orange-band test-section-header">
    <h5>
        <span class="org-heading"><strong>PSA Results</strong></span>
    </h5>
    <span class="chk_orngband">
        <select id="conductedbyPsa" class="conductedby-ddl">
        </select>
    </span><span class="chk_orngband" id="psa-critical-span">
        <input type="checkbox" id="DescribeSelfPresentPsaInputCheck" onclick="onClick_CriticalDataPsa();" />Critical</span>
    <span class="chk_orngband" id="psa-priorityInQueue-span">
        <input type="checkbox" id="PriorityInQueueTestPsaCheck" onclick="onClick_PriorityInQueueDataPsa();" />Priority In Queue
    </span>
    <span class="chk_orngband" id="psa-retest-span">
        <input type="checkbox" id="Retest_20" />Retest
    </span>
</div>
<div class="left_info1">
    <div class="labelwdt2 finding">
        <asp:DataList runat="server" ID="UnableToScreenPsaDataList" EnableViewState="false"
            RepeatLayout="Flow" CssClass="dtl-unabletoscreen-psa unable-to-screen-section" GridLines="None"
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
    <div class="rrow" id="PsaReadingDiv" runat="server" style="display: none;">
        <strong>PSASCR: </strong>
        <input type="text" id="psaScrtextbox" class="input_bdrbot" style="width: 100px;" />
    </div>
    <div class="rrow">
        <b>Technician Notes: </b>
        <br />
        <textarea id="technotesPsa" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
            rows="2" cols="54"></textarea>
    </div>
</div>
    </div>


<div id="psa_chat" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 50%;">
            <span class="org-heading" style="width: 100%;"><strong>PSA Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyPsa" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="psa-retest-span">
            <input type="checkbox" id="Retest_20" />Retest
        </span>
    </div>
    <div class="hrows psa-verificationpanel" style="color: Red; background: #fff0a5; border: solid 1px fff0a5; padding: 2px 2px 2px 5px; display: none;">
    </div>
     <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
             
     <div class="hlfbox">
           <div class="hrows">
             <div class="nrow" style="margin-left:12px;">
                  <input type="checkbox" id="chk_psacapturebyChat" />
                   <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
     </div>
             
     </div>
</div>


<script language="javascript" type="text/javascript">
    var testTypePsa = '<%= (long)TestType.Psa %>';
    var IspsaResultEntryExternaly = '<%= IsResultEntrybyChat %>';
    var psa = null;
    function SetPsaData(testResult) {
        psa = new Psa(testResult);
        psa.setData();
    }

    function GetPsaData() {
        if (psa == null) psa = new Psa();
        return psa.getData();
    }

</script>
