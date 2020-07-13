<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AwvHemaglobin.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.AwvHemaglobin" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/AwvHemaglobin.js?q=<%= VersionNumber %>"></script>
<div id="awvHemaglobin_hip" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
<div class="orange-band test-section-header">
    <h5>
        <span class="org-heading"><strong>HBA1-C Results</strong></span>
    </h5>
    <span class="chk_orngband">
        <select id="conductedbyAwvHemaglobin" class="conductedby-ddl">
        </select>
    </span><span class="chk_orngband" id="AwvHemaglobin-critical-span">
        <input type="checkbox" id="DescribeSelfPresentAwvHemaglobinInputCheck" onclick="onClick_CriticalDataAwvHemaglobin();" />Critical </span>
    <span class="chk_orngband" id="awvHemaglobin-priorityInQueue-span">
            <input type="checkbox" id="PriorityInQueueTestAwvHemaglobinCheck" onclick="onClick_PriorityInQueueDataAwvHemaglobin();" />Priority In Queue
    </span>
    <span class="chk_orngband" id="awvHemaglobin-retest-span">
            <input type="checkbox" id="Retest_59" />Retest
    </span>
</div>
<div class="left_info1">
    <div class="labelwdt2 finding">
        <asp:DataList runat="server" ID="UnableToScreenAwvHemaglobinDataList" EnableViewState="false"
            RepeatLayout="Flow" CssClass="dtl-unabletoscreen-AwvHemaglobin unable-to-screen-section" GridLines="None"
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
         <div style="height: 40px; float: right;" class="rgtgbox_singleReading">
            <div class="grow">
                <div class="right">
                    A1C:
        <input type="text" id="Awvhba1ctextbox" class="input_bdrbot" style="width: 100px;" onkeydown="return KeyPress_DecimalAllowedOnly(event);" />
                </div>
            </div>
        </div>
    </div> 
    <div class="rrow">
        <b>Technician Notes: </b>
        <br />
        <textarea id="technotesAwvHemaglobin" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
            rows="2" cols="54"></textarea>
    </div>
    <div class="rrow test-not-performed-section" id="testnotPerformedAwvHemaglobin">
        <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0" />
        <b>Test Not Performed</b>
        <div class="test-not-performed-container" style="display: none">
            <b>Reason : </b>
            <br />
            <asp:DropDownList ID="ddlTestNotPerformedReasonAwvHemaglobin" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
            </asp:DropDownList>
            <br />
            <div >
                <b>Notes :</b>
                <br />
                <textarea  rows="2" cols="54"></textarea>
            </div>
        </div>
    </div>
</div>
<div style="float: left; width: 100%; clear: both; margin-top: 5px;" class="physician-section">
    <fieldset style="float: left; width: 98%;  border-radius: 4px;">
        <legend>Remarks </legend>
        <div style="float: left; width: 40%;">            
            <input type="checkbox" id="criticalAwvHemaglobin" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b>
        </div>
        <div style="float: left; width: 58%;">
            <textarea id="physicianRemarksAwvHemaglobin" rows="3" style="width: 98%;"></textarea></div>
    </fieldset>
</div>

    </div>
<div id="awvHemaglobin_chat" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 50%;">
            <span class="org-heading" style="width: 100%;"><strong>HBA1-C Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyAwvHemaglobin" class="conductedby-ddl">
            </select>
        </span>
        
        <span class="chk_orngband" id="AwvHemaglobin-critical-span">
        <input type="checkbox" id="DescribeSelfPresentAwvHemaglobinInputCheck" onclick="onClick_CriticalDataAwvHemaglobin();" />Critical </span>

        <span class="chk_orngband" id="awvHemaglobin-retest-span">
            <input type="checkbox" id="Retest_59" />Retest
        </span>
        
    </div>
    
    <div class="contentrow" style="width: 99%; padding-left: 0px;">
        <div class="hlfbox">
            <div class="hrows">
                <div class="nrow" style="margin-left: 12px;">
                    <input type="checkbox" id="chk_awvHemaglobincapturebyChat" />
                    <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
        </div>
        <div style="float: left; clear: none; padding-top: 0" class="rrow test-not-performed-section" id="testnotPerformedAwvHemaglobin">
            <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0" />
            <b>Test Not Performed</b>
            <div class="test-not-performed-container" style="display: none">
                <b>Reason : </b>
                <br />
                <asp:DropDownList ID="ddlTestNotPerformedReasonAwvHemaglobin_CHAT" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
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
</div>
<script language="javascript" type="text/javascript">
    var testTypeAwvHemaglobin = '<%= (long)TestType.AwvHBA1C %>';
    var IsawvHemaglobinResultEntryExternaly = '<%=IsResultEntrybyChat%>';
    var awvHemaglobin = null;
    function SetAwvHemaglobinData(testResult) {
        awvHemaglobin = new AwvHemaglobin(testResult);
        awvHemaglobin.setData();
    }

    function GetAwvHemaglobinData() {
        if (awvHemaglobin == null) awvHemaglobin = new AwvHemaglobin();
        return awvHemaglobin.getData();
    }

</script>