<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FluShot.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.FluShot" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<%@ Import Namespace="Falcon.App.Core.Application.Domain" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/FluShot.js?q=<%= VersionNumber %>"></script>


<div runat="server" id="fluShot_hip">
    <div class="orange-band test-section-header">
        <h5>
            <span class="org-heading"><strong>FluShot Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyFluShot" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="FluShot-critical-span">
            <input type="checkbox" id="DescribeSelfPresentFluShotInputCheck" onclick="onClick_CriticalDataFluShot();" />Critical </span>
        <span class="chk_orngband" id="FluShot-priorityInQueue-span">
            <input type="checkbox" id="PriorityInQueueTestFluShotCheck" onclick="onClick_PriorityInQueueDataFluShot();" />Priority In Queue
        </span>
        <span class="chk_orngband" id="FluShot-retest-span">
            <input type="checkbox" id="Retest_31" />Retest
        </span>
    </div>
    <div class="left_info1">
        <div style="width: 220px; float: left; padding: 10px 10px 10px 5px;"><b>Manufacturer:</b><input type="text" id="FluShotManufacturerInputtext" maxlength="20" class="input_bdrbot" style="width: 130px" onkeydown="return txtkeypress_AlphanumericOnly(event);" /></div>
        <div style="width: 220px; float: left; padding: 10px;"><b>Lot Number:</b><input type="text" id="FluShotLotNumberInputtext" maxlength="20" class="input_bdrbot" style="width: 130px" onkeydown="return txtkeypress_AlphanumericOnly(event);" /></div>

        <div style="width: 275px; margin-top: 25px; clear: both;">
            <asp:DataList runat="server" ID="dtlFluShotSelectedUnableToScreen" GridLines="None"
                EnableViewState="false" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="dtl-unabletoscreen-FluShot unable-to-screen-section">
                <ItemTemplate>
                    <input type="checkbox" id="chkUnableScreenReason" class="chk-selected-FluShot-us" />
                    <b><%# DataBinder.Eval(Container.DataItem, "DisplayName") %></b>
                    <input type="hidden" id="hfUnableScreenReasonID" class="hdn-selected-FluShot-us" value='<%# Convert.ToString((int)DataBinder.Eval(Container.DataItem, "Reason")) %>' />
                </ItemTemplate>
            </asp:DataList>
            <div class="lrow clear-all-selection">
                <a style="margin-left: 5px;" id="clear-all-FluShot" href="javascript:void(0);" onclick="clearAllFluShotSelection();">Clear All Selection</a>
            </div>
        </div>
    </div>

    <div class="rgt_info1">

        <div class="rrow">
            <b>Technician Notes: </b>
            <br />
            <textarea id="technotesFluShot" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
                rows="2" cols="54"></textarea>
        </div>
        <div class="rrow test-not-performed-section" id="testnotPerformedFluShot">
            <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0" />
            <b>Test Not Performed</b>
            <div class="test-not-performed-container" style="display: none">
                <b>Reason : </b>
                <br />
                <asp:DropDownList ID="ddlTestNotPerformedReasonFluShot" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
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
    <%--Right Part Starts here--%>
    <div class="physician-section" style="float: left; width: 100%; clear: both; margin-top: 5px;">
        <fieldset style="float: left; width: 98%; border-radius: 4px;">
            <legend>Remarks </legend>
            <div style="float: left; width: 40%;">
                <div style="display: none;">
                    <input type="checkbox" id="technicallyltdbutreadableFluShotinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Technically limited, but readable</b><br />
                    <input type="checkbox" id="repeatstudyFluShotinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Unreadable</b><br />
                </div>
                <input type="checkbox" id="criticalFluShot" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b>
            </div>
            <div style="float: left; width: 58%;">
                <textarea id="physicianRemarksFluShot" rows="3" style="width: 98%;"></textarea>
            </div>
        </fieldset>
    </div>


</div>
<div runat="server" id="fluShot_chat">
    <div class="orange-band test-section-header">
        <h5>
            <span class="org-heading"><strong>FluShot Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyFluShot" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="FluShot-retest-span">
            <input type="checkbox" id="Retest_31" />Retest
        </span>
    </div>
     <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
        <div class="hlfbox">
            <div class="hrows">
                <div class="nrow" style="margin-left: 12px;">
                    <input type="checkbox" id="chk_flushotcapturebyChat" />
                    <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
        </div>

    </div>
</div>
<script language="javascript" type="text/javascript">
    var testTypeFluShot = '<%= (long)TestType.FluShot %>';

    var isFluShotResultentrytype = '<%= IsResultEntrybyChat %>';

    var fluShot = null;
    function SetFluShotData(testResult) {
        fluShot = new FluShot(testResult);
        fluShot.setData();
    }

    function GetFluShotData() {
        if (fluShot == null) fluShot = new FluShot();
        return fluShot.getData();
    }

</script>
