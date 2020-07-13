<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Chlamydia.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.Chlamydia" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<%@ Import Namespace="Falcon.App.Core.Application.Domain" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/Chlamydia.js?q=<%= VersionNumber %>"></script>

<div id="chlamydia_hip" runat="server">
    <div class="orange-band test-section-header">
        <h5>
            <span class="org-heading"><strong>Chlamydia Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyChlamydia" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="Chlamydia-critical-span">
            <input type="checkbox" id="DescribeSelfPresentChlamydiaInputCheck" onclick="onClick_CriticalDataChlamydia();" />Critical </span>
        <span class="chk_orngband" id="Chlamydia-priorityInQueue-span">
            <input type="checkbox" id="PriorityInQueueTestChlamydiaCheck" onclick="onClick_PriorityInQueueDataChlamydia();" />Priority In Queue
        </span>
        <span class="chk_orngband" id="Chlamydia-retest-span">
            <input type="checkbox" id="Retest_93" />Retest
        </span>
    </div>
    <div class="left_info1">
        <div style="width: 150px; text-align: center;">
            <span class="left" style="width: 100%">
                <img class="uploadchlamydiaPDF" alt="" src="/Content/Images/PageNotFound-Icons.jpg" /><br />
                <b>Chlamydia</b>
            </span>
            <span class="left upload-media-section" style="width: 100%; text-align: center;">
                <a href="javascript:void(0);" class="pdf-chlamydia-remove" style="display: none;">Remove </a>&nbsp;
        <a href="javascript:OpenPopUp('Upload PDF', '330', '/app/franchisee/technician/UploadAwvTestResultFile.aspx?TestType=<%= (long)TestType.Chlamydia %>&height=110', 200);">Upload PDF </a>
            </span>
        </div>
        <div style="margin-bottom: 10px; width: 275px; margin-left: 193px;">
            <asp:DataList runat="server" ID="gvFindingsChlamydia" CssClass="gv-findings-chlamydia finding-section"
                RepeatDirection="Horizontal" RepeatColumns="4" EnableViewState="false">
                <ItemTemplate>
                    <input type="radio" id="rbtFindingChlamydia" name="rbtFindingChlamydia" class="rbt-finding" />
                    <%# DataBinder.Eval(Container.DataItem, "Label") %>
                    <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                    <input type="hidden" class="finding-minvalue" value='<%# DataBinder.Eval(Container.DataItem, "MinValue")%>' />
                    <input type="hidden" class="finding-maxvalue" value='<%# DataBinder.Eval(Container.DataItem, "MaxValue")%>' />
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div style="width: 275px; margin-left: 196px; margin-top: 25px;">
            <asp:DataList runat="server" ID="dtlChlamydiaSelectedUnableToScreen" GridLines="None"
                EnableViewState="false" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="dtl-unabletoscreen-chlamydia unable-to-screen-section">
                <ItemTemplate>
                    <input type="checkbox" id="chkUnableScreenReason" class="chk-selected-Chlamydia-us" />
                    <b><%# DataBinder.Eval(Container.DataItem, "DisplayName") %></b>
                    <input type="hidden" id="hfUnableScreenReasonID" class="hdn-selected-chlamydia-us" value='<%# Convert.ToString((int)DataBinder.Eval(Container.DataItem, "Reason")) %>' />
                </ItemTemplate>
            </asp:DataList>
            <div class="lrow clear-all-selection">
                <a style="margin-left: 5px;" id="clear-all-chlamydia" href="javascript:void(0);" onclick="clearAllChlamydiaSelection();">Clear All Selection</a>
            </div>
        </div>
    </div>

    <div class="rgt_info1">

        <div class="rrow">
            <b>Technician Notes: </b>
            <br />
            <textarea id="technotesChlamydia" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
                rows="2" cols="54"></textarea>
        </div>
        <div class="rrow test-not-performed-section" id="testnotPerformedChlamydia">
            <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0" />
            <b>Test Not Performed</b>
            <div class="test-not-performed-container" style="display: none">
                <b>Reason : </b>
                <br />
                <asp:DropDownList ID="ddlTestNotPerformedReasonChlamydia" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
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
                    <input type="checkbox" id="technicallyltdbutreadableChlamydiainputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Technically limited, but readable</b><br />
                    <input type="checkbox" id="repeatstudyChlamydiainputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Unreadable</b><br />
                </div>
                <input type="checkbox" id="criticalChlamydia" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b>
            </div>
            <div style="float: left; width: 58%;">
                <textarea id="physicianRemarksChlamydia" rows="3" style="width: 98%;"></textarea>
            </div>
        </fieldset>
    </div>
</div>
<div id="chlamydia_chat" runat="server">
    <div class="orange-band test-section-header">
        <h5>
            <span class="org-heading"><strong>Chlamydia Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyChlamydia" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="Chlamydia-retest-span">
            <input type="checkbox" id="Retest_93" />Retest
        </span>
    </div>
    <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
        <div class="hlfbox">
            <div class="hrows">
                <div class="nrow" style="margin-left: 12px;">
                    <input type="checkbox" id="chk_chlamydiacapturebyChat" />
                    <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
        </div>

    </div>

</div>


<script language="javascript" type="text/javascript">
    var testTypeChlamydia = '<%= (long)TestType.Chlamydia %>';
    fileTypeChlamydiaPDF = '<%=(long)FileType.Pdf %>';

    var isChlamydiaResultEntryType = '<%= IsResultEntrybyChat %>';

    var chlamydia = null;
    function SetChlamydiaData(testResult) {
        chlamydia = new Chlamydia(testResult);
        chlamydia.setData();
    }

    function GetChlamydiaData() {
        if (chlamydia == null) chlamydia = new Chlamydia();
        return chlamydia.getData();
    }



</script>
