<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Phq9.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.Phq9" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/phq9.js?q=<%= VersionNumber %>"></script>


<div id="phq9_hip" runat="server">
    <div class="orange-band test-section-header">
        <h5>
            <span class="org-heading"><strong>Depression Assessment (PHQ 9)</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyPhq9" class="conductedby-ddl">
            </select>
        </span><span class="chk_orngband" id="Phq9-critical-span">
            <input type="checkbox" id="DescribeSelfPresentPhq9InputCheck" onclick="onClick_CriticalDataPhq9();" />Critical</span>
        <span class="chk_orngband" id="Phq9-priorityInQueue-span">
            <input type="checkbox" id="PriorityInQueueTestPhq9Check" onclick="onClick_PriorityInQueueDataPhq9();" />Priority In Queue
        </span>
        <span class="chk_orngband" id="Phq9-retest-span">
            <input type="checkbox" id="Retest_43" />Retest
        </span>
    </div>
    <div class="left_info1">
        <div class="rrow">
            <strong>Score(PHQ-9): </strong>
            <input type="text" id="Phq9Scoretextbox" class="input_bdrbot" style="width: 100px;" />
        </div>
        <div class="labelwdt2 finding">
            <asp:DataList runat="server" ID="UnableToScreenPhq9DataList" EnableViewState="false"
                RepeatLayout="Flow" CssClass="dtl-unabletoscreen-Phq9 unable-to-screen-section" GridLines="None"
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
            <textarea id="technotesPhq9" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
                rows="2" cols="54"></textarea>
        </div>
        <div class="rrow test-not-performed-section" id="testnotPerformedPhq9">
            <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0" />
            <b>Test Not Performed</b>
            <div class="test-not-performed-container" style="display: none;">
                <b>Reason : </b>
                <br />
                <asp:DropDownList ID="ddlTestNotPerformedReasonPhq9" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
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
    <div class="physician-section" style="float: left; width: 100%; clear: both; margin-top: 5px;">
        <fieldset style="float: left; width: 98%; border-radius: 4px;">
            <legend>Remarks </legend>
            <div style="float: left; width: 40%;">
                <div style="display: none;">
                    <input type="checkbox" id="technicallyltdbutreadablePhq9inputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Technically limited, but readable</b><br />
                    <input type="checkbox" id="repeatstudyPhq9inputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Repeat Study/Unreadable</b><br />
                </div>
                <input type="checkbox" id="criticalPhq9" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b>
            </div>
            <div style="float: left; width: 58%;">
                <textarea id="physicianRemarksPhq9" rows="3" style="width: 98%;"></textarea>
            </div>
        </fieldset>
    </div>
</div>

<div id="phq9_chat" runat="server">
    <div class="orange-band test-section-header">
        <h5>
            <span class="org-heading"><strong>Depression Assessment (PHQ 9)</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyPhq9" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="Phq9-retest-span">
            <input type="checkbox" id="Retest_43" />Retest
        </span>
    </div>
    <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
        <div class="hlfbox">
            <div class="hrows">
                <div class="nrow" style="margin-left: 12px;">
                    <input type="checkbox" id="chk_Phq9capturebyChat" />
                    <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
        </div>

    </div>
</div>


<script language="javascript" type="text/javascript">
    var testTypePhq9 = '<%= (long)TestType.PHQ9 %>';
    var isPhq9Resultentrytype = '<%= IsResultEntrybyChat %>';
    var phq9 = null;
    function SetPhq9Data(testResult) {
        phq9 = new Phq9(testResult);
        phq9.setData();
    }

    function GetPhq9Data() {
        if (phq9 == null) phq9 = new Phq9();
        return phq9.getData();
    }

</script>
