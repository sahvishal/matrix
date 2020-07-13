<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Hemaglobin.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.Hemaglobin" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/Hemaglobin.js?q=<%= VersionNumber %>"></script>
<div id="hemaglobin_hip" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
<div class="orange-band test-section-header">
    <h5>
        <span class="org-heading"><strong>Hemoglobin A1C Results</strong></span>
    </h5>
    <span class="chk_orngband">
        <select id="conductedbyhemaglobin" class="conductedby-ddl">
        </select>
    </span><span class="chk_orngband" id="a1c-critical-span">
        <input type="checkbox" id="DescribeSelfPresentHemaglobinInputCheck" onclick="onClick_CriticalDatahbA1c();" />Critical </span>
    <span class="chk_orngband" id="a1c-priorityInQueue-span">
        <input type="checkbox" id="PriorityInQueueTestHemaglobinCheck" onclick="onClick_PriorityInQueueDataHemaglobin();" />Priority In Queue
    </span>
    <span class="chk_orngband" id="a1c-retest-span">
        <input type="checkbox" id="Retest_25" />Retest
    </span>
</div>
<div class="left_info1">
    <div class="labelwdt2 finding">
        <asp:DataList runat="server" ID="UnableToScreenHemaglobinDataList" EnableViewState="false"
            RepeatLayout="Flow" CssClass="dtl-unabletoscreen-hemaglobin unable-to-screen-section" GridLines="None"
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
        <strong>A1C: </strong>
        <input type="text" id="hba1ctextbox" class="input_bdrbot" style="width: 100px;" onkeydown="return KeyPress_DecimalAllowedOnly(event);" />
    </div>
    <div class="rrow">
        <b>Technician Notes: </b>
        <br />
        <textarea id="technoteshba1c" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
            rows="2" cols="54"></textarea>
    </div>
</div>

<div style="float: left; width: 100%; clear: both; margin-top: 5px;" class="physician-section">
    <fieldset style="float: left; width: 98%; border-radius: 4px;">
        <legend>Remarks </legend>
        <div style="float: left; width: 40%;">
            <input type="checkbox" id="criticalHemaglobin" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b>
        </div>
        <div style="float: left; width: 58%;">
            <textarea id="physicianRemarksHemaglobin" rows="3" style="width: 98%;"></textarea>
        </div>
    </fieldset>
</div>
</div>


<div id="hemaglobin_chat" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 50%;">
            <span class="org-heading" style="width: 100%;"><strong>Hemoglobin A1C Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyhemaglobin" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="a1c-retest-span">
            <input type="checkbox" id="Retest_25" />Retest
        </span>
    </div>
    <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">

        <div class="hlfbox">
            <div class="hrows">
                <div class="nrow" style="margin-left: 12px;">
                    <input type="checkbox" id="chk_hemaglobincapturebyChat" />
                    <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
        </div>

    </div>
</div>


<script language="javascript" type="text/javascript">
    var testTypeHemaglobin = '<%= (long)TestType.A1C %>';
    var IshemaglobinResultEntryExternaly = '<%= IsResultEntrybyChat %>';

    var hbA1C = null;
    function SetA1cData(testResult) {
        hbA1C = new Hemaglobin(testResult);
        hbA1C.setData();
    }

    function GetA1cData() {
        if (hbA1C == null) hbA1C = new Hemaglobin();
        return hbA1C.getData();
    }

</script>
