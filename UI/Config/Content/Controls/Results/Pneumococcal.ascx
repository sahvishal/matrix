<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Pneumococcal.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.Pneumococcal" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<%@ Import Namespace="Falcon.App.Core.Application.Domain" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/Pneumococcal.js?q=<%= VersionNumber %>"></script>


<div id="Pneumococcal_hip" runat="server">
    <div class="orange-band test-section-header">
        <h5>
            <span class="org-heading"><strong>Pneumococcal Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyPneumococcal" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="Pneumococcal-critical-span">
            <input type="checkbox" id="DescribeSelfPresentPneumococcalInputCheck" onclick="onClick_CriticalDataPneumococcal();" />Critical </span>
        <span class="chk_orngband" id="Pneumococcal-priorityInQueue-span">
            <input type="checkbox" id="PriorityInQueueTestPneumococcalCheck" onclick="onClick_PriorityInQueueDataPneumococcal();" />Priority In Queue
        </span>
        <span class="chk_orngband" id="Pneumococcal-retest-span">
            <input type="checkbox" id="Retest_74" />Retest
        </span>
    </div>
    <div class="left_info1">
        <div style="width: 220px; float: left; padding: 10px 10px 10px 5px;"><b>Manufacturer:</b><input type="text" id="PneumococcalManufacturerInputtext" maxlength="20" class="input_bdrbot" style="width: 130px" onkeydown="return txtkeypress_AlphanumericOnly(event);" /></div>
        <div style="width: 220px; float: left; padding: 10px;"><b>Lot Number:</b><input type="text" id="PneumococcalLotNumberInputtext" maxlength="20" class="input_bdrbot" style="width: 130px" onkeydown="return txtkeypress_AlphanumericOnly(event);" /></div>

        <div style="width: 275px; margin-top: 25px; clear: both;">
            <asp:DataList runat="server" ID="dtlPneumococcalSelectedUnableToScreen" GridLines="None"
                EnableViewState="false" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="dtl-unabletoscreen-Pneumococcal unable-to-screen-section">
                <ItemTemplate>
                    <input type="checkbox" id="chkUnableScreenReason" class="chk-selected-Pneumococcal-us" />
                    <b><%# DataBinder.Eval(Container.DataItem, "DisplayName") %></b>
                    <input type="hidden" id="hfUnableScreenReasonID" class="hdn-selected-Pneumococcal-us" value='<%# Convert.ToString((int)DataBinder.Eval(Container.DataItem, "Reason")) %>' />
                </ItemTemplate>
            </asp:DataList>
            <div class="lrow clear-all-selection">
                <a style="margin-left: 5px;" id="clear-all-Pneumococcal" href="javascript:void(0);" onclick="clearAllPneumococcalSelection();">Clear All Selection</a>
            </div>
        </div>
    </div>

    <div class="rgt_info1">

        <div class="rrow">
            <b>Technician Notes: </b>
            <br />
            <textarea id="technotesPneumococcal" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
                rows="2" cols="54"></textarea>
        </div>
        <div class="rrow test-not-performed-section" id="testnotPerformedPneumococcal">
            <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0" />
            <b>Test Not Performed</b>
            <div class="test-not-performed-container" style="display: none">
                <b>Reason : </b>
                <br />
                <asp:DropDownList ID="ddlTestNotPerformedReasonPneumococcal" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
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
                    <input type="checkbox" id="technicallyltdbutreadablePneumococcalinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Technically limited, but readable</b><br />
                    <input type="checkbox" id="repeatstudyPneumococcalinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Unreadable</b><br />
                </div>
                <input type="checkbox" id="criticalPneumococcal" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b>
            </div>
            <div style="float: left; width: 58%;">
                <textarea id="physicianRemarksPneumococcal" rows="3" style="width: 98%;"></textarea>
            </div>
        </fieldset>
    </div>
</div>
<div id="Pneumococcal_chat" runat="server">
    <div class="orange-band test-section-header">
        <h5>
            <span class="org-heading"><strong>Pneumococcal Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyPneumococcal" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="Pneumococcal-retest-span">
            <input type="checkbox" id="Retest_74" />Retest
        </span>
    </div>
     <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
        <div class="hlfbox">
            <div class="hrows">
                <div class="nrow" style="margin-left: 12px;">
                    <input type="checkbox" id="chk_PneumococcalcapturebyChat" />
                    <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
        </div>

    </div>
</div>

<script language="javascript" type="text/javascript">
    var testTypePneumococcal = '<%= (long)TestType.Pneumococcal %>';

    var isPneumococcalResultEntryType = '<%= IsResultEntrybyChat %>';

    var pneumococcal = null;
    function SetPneumococcalData(testResult) {
        pneumococcal = new Pneumococcal(testResult);
        pneumococcal.setData();
    }

    function GetPneumococcalData() {
        if (pneumococcal == null) pneumococcal = new Pneumococcal();
        return pneumococcal.getData();
    }

</script>

