<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Monofilament.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.Monofilament" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/Monofilament.js?q=<%= VersionNumber %>"></script>

<div id="Monofilament_hip" runat="server">
    <div class="orange-band test-section-header">
        <h5>
            <span class="org-heading"><strong>Monofilament Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyMonofilament" class="conductedby-ddl">
            </select>
        </span><span class="chk_orngband" id="Monofilament-critical-span">
            <input type="checkbox" id="DescribeSelfPresentMonofilamentInputCheck" onclick="onClick_CriticalDataMonofilament();" />Critical</span>
        <span class="chk_orngband" id="monofilament-priorityInQueue-span">
            <input type="checkbox" id="PriorityInQueueTestMonofilamentCheck" onclick="onClick_PriorityInQueueDataMonofilament();" />Priority In Queue
        </span>
        <span class="chk_orngband" id="monofilament-retest-span">
            <input type="checkbox" id="Retest_91" />Retest
        </span>
    </div>
    <div class="left_info1">
        <div class="labelwdt2" style="padding-bottom: 10px;">
            <div>
                <span style="width: 80px; display: inline-block;"><strong>Right Foot: </strong></span>
                <span class="RightPositive">
                    <input type="radio" id="MonofilamentRightPositiveinputcheck" value="true" name="Right" />
                    Sensation Intact  </span>
                <br />
                <span style="width: 80px; display: inline-block;">&nbsp;</span> <span class="RightNegative">
                    <input type="radio" id="MonofilamentRightNegativeinputcheck" value="true" name="Right" />
                    Sensation not Intact  </span>
            </div>
            <div>
                <span style="width: 80px; display: inline-block;"><strong>Left Foot: </strong></span>
                <span class="LeftPositive">
                    <input type="radio" id="MonofilamentLeftPositiveinputcheck" value="true" name="Left" />
                    Sensation Intact  </span>
                <br />
                <span style="width: 83px; display: inline-block;">&nbsp;</span><span class="LeftNegative"><input type="radio" id="MonofilamentLeftNegativeinputcheck" value="true" name="Left" />
                    Sensation not Intact  </span>
            </div>
        </div>
        <div class="labelwdt2 finding">
            <asp:DataList runat="server" ID="UnableToScreenMonofilamentDataList" EnableViewState="false"
                RepeatLayout="Flow" CssClass="dtl-unabletoscreen-Monofilament unable-to-screen-section" GridLines="None"
                RepeatDirection="Horizontal">
                <ItemTemplate>
                    <input type="checkbox" id="chkUnableScreenReason" />
                    <b>Unable To Screen</b>
                    <input type="hidden" id="hfUnableScreenReasonID" value='<%# Convert.ToString((int)DataBinder.Eval(Container.DataItem, "Reason")) %>' />
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div class="lrow clear-all-selection">
            <a style="margin-left: 5px;" id="clear-all-Monofilament" href="javascript:void(0);" onclick="clearAllMonofilamentSelection();">Clear All Selection</a>
        </div>
    </div>
    <div class="rgt_info1">
        <div class="rrow">
            <b>Technician Notes: </b>
            <br />
            <textarea id="technotesMonofilament" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
                rows="2" cols="54"></textarea>
        </div>
        <div class="rrow test-not-performed-section" id="testnotPerformedMonofilament">
            <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0" />
            <b>Test Not Performed</b>
            <div class="test-not-performed-container" style="display: none;">
                <b>Reason : </b>
                <br />
                <asp:DropDownList ID="ddlTestNotPerformedReasonMonofilament" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
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
                <div style="display: none">
                    <input type="checkbox" id="Monofilamenttechnicallyltdbutreadableinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Technically limited, but readable</b><br />
                    <input type="checkbox" id="Monofilamentrepeatstudyinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Repeat Study/Unreadable</b><br />
                </div>

                <div style="float: left;">
                    <input type="checkbox" id="criticalMonofilament" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b>
                </div>
            </div>
            <div style="float: left; width: 58%;">
                <textarea id="physicianRemarksMonofilament" rows="3" style="width: 98%;"></textarea>
            </div>
        </fieldset>
    </div>
</div>

<div id="Monofilament_chat" runat="server">
    <div class="orange-band test-section-header">
        <h5>
            <span class="org-heading"><strong>Monofilament Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyMonofilament" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="monofilament-retest-span">
            <input type="checkbox" id="Retest_91" />Retest
        </span>
    </div>
    <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
        <div class="hlfbox">
            <div class="hrows">
                <div class="nrow" style="margin-left: 12px;">
                    <input type="checkbox" id="chk_MonofilamentcapturebyChat" />
                    <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
        </div>
    </div>
</div>



<script language="javascript" type="text/javascript">
    var testTypeMonofilament = '<%= (long)TestType.Monofilament %>';

    var isMonofilamentResultEntryType = '<%= IsResultEntrybyChat %>';

    var monofilament = null;
    function SetMonofilamentData(testResult) {
        monofilament = new Monofilament(testResult);
        monofilament.setData();
    }

    function GetMonofilamentData() {
        if (monofilament == null) monofilament = new Monofilament();
        return monofilament.getData();
    }

</script>
