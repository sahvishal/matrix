<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FloChecABI.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.FloChecABI" %>
<%@ Import Namespace="Falcon.App.Core.Application.Domain" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/FloChecABI.js?q=<%= VersionNumber %>"></script>

<div id="FloChecABI_hip" runat="server">
    <div class="orange-band test-section-header">
        <h5>
            <span class="org-heading"><strong>Flo Chec Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyFloChecABI" class="conductedby-ddl">
            </select>
        </span><span class="chk_orngband" id="FloChecABI-critical-span">
            <input type="checkbox" id="chkselfFloChecABI" onclick="onClick_CriticalDataFloChecABI();" />Critical</span>
        <span class="chk_orngband" id="FloChecABI-priorityInQueue-span">
            <input type="checkbox" id="PriorityInQueueTestFloChecABICheck" onclick="onClick_PriorityInQueueDataFloChecABI();" />Priority In Queue
        </span>
        <span class="chk_orngband" id="FloChecABI-retest-span">
            <input type="checkbox" id="Retest_88" />Retest
        </span>
    </div>
    <div style="float: left; width: 100%;" id="FloChecABIContent">
        <div class="left_info1">
            <div class="lrow finding">
                <asp:GridView runat="server" ID="gvFindingsFloChecABI" Style="float: left;" AutoGenerateColumns="False"
                    EnableViewState="false" ShowHeader="False" GridLines="None" CssClass="gv-findings-FloChecABI finding-section">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <div class="lrow">
                                    <input type="radio" name="rbtFindingFloChecABI" class="listchkbox rbt-finding" />
                                    <label class="findingFloChecABIcheckBox">
                                        <%# DataBinder.Eval(Container.DataItem, "Label")%>
                                    </label>
                                    <label><%# DataBinder.Eval(Container.DataItem, "Description").ToString().Length > 0 ? "(" + DataBinder.Eval(Container.DataItem, "Description") + ")":"" %></label>
                                    <input type="hidden" id="FindingFloChecABIInputHidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                                    <input type="hidden" class="finding-minvalue" value='<%# DataBinder.Eval(Container.DataItem, "MinValue")%>' />
                                    <input type="hidden" class="finding-maxvalue" value='<%# DataBinder.Eval(Container.DataItem, "MaxValue")%>' />
                                    <input type="hidden" class="finding-worstcaseorder" value='<%# DataBinder.Eval(Container.DataItem, "WorstCaseOrder")%>' />
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="lrow margin-top-small">
                <div class="left">
                    <asp:DataList runat="server" ID="dtlFloChecABIUnableToScreenSelected" GridLines="None" RepeatLayout="Flow"
                        EnableViewState="false" RepeatDirection="Horizontal" CssClass="dtl-unabletoscreen-FloChecABI unable-to-screen-section">
                        <ItemTemplate>
                            <input type="checkbox" id="chkUnableScreenReason" class="gbox_chk chk-selected-FloChecABI-us" />
                            <label class="gbox_chk">
                                <b>
                                    <%# DataBinder.Eval(Container.DataItem, "DisplayName")%></b>
                            </label>
                            <input type="hidden" id="hfUnableScreenReasonID" class="hdn-selected-FloChecABI-us" value='<%# Convert.ToString((int)DataBinder.Eval(Container.DataItem, "Reason")) %>' />
                        </ItemTemplate>
                    </asp:DataList>
                </div>
            </div>
            <div class="left" style="width: 937px; padding: 3px;">
                <div id="FloChecABIContainerDiv" class="contentrowltpad media-container-div" style="margin-top: 5px;">
                </div>
                <div class="contentrowltpad upload-media-section">
                    <a href="javascript:OpenPopUp('Upload Media', '710', '/app/franchisee/technician/uploadTestImages.aspx?RestricttoOne=true&TestType=<%= (int)TestType.FloChecABI %>&CustomerId=' + customerId);">Upload Media</a>
                </div>
            </div>

        </div>
        <div class="rgt_info1">
            <div class="rgt_gbox" style="display: none;">
                <div class="grow">
                    <div class="left">
                        <span class="carotidgboxbtxt">Right Foot dABI:<input type="text" id="txtRightFloChecABI" class="inputbdrbot_pad"
                            onkeydown="return KeyPress_DecimalAllowedOnly(event);" style="width: 70px" tabindex="23" />
                        </span>
                    </div>
                    <div class="left">
                        <span class="carotidgboxbtxt">Left Foot dABI:<input type="text" id="txtLeftFloChecABI" class="inputbdrbot_pad"
                            onkeydown="return KeyPress_DecimalAllowedOnly(event);" style="width: 70px" tabindex="26" />
                        </span>
                    </div>
                    <div class="left">
                        <span class="carotidgboxbtxt">Right Hand BFI:<input type="text" id="txtRightBFI" class="inputbdrbot_pad"
                            onkeydown="return KeyPress_DecimalAllowedOnly(event);" style="width: 70px" tabindex="23" />
                        </span>
                    </div>
                    <div class="left">
                        <span class="carotidgboxbtxt">Left Hand BFI:<input type="text" id="txtLeftBFI" class="inputbdrbot_pad"
                            onkeydown="return KeyPress_DecimalAllowedOnly(event);" style="width: 70px" tabindex="26" />
                        </span>
                    </div>
                </div>
            </div>
            <div class="rrow">
                <b>Technician Notes: </b>
                <br />
                <textarea id="technotesFloChecABI" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
                    rows="2" cols="54"></textarea>
            </div>
            <div class="rrow test-not-performed-section" id="testnotPerformedFloChecABI">
                <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0" />
                <b>Test Not Performed</b>
                <div class="test-not-performed-container" style="display: none;">
                    <b>Reason : </b>
                    <br />
                    <asp:DropDownList ID="ddlTestNotPerformedReasonFloChecABI" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
                    </asp:DropDownList>
                    <br />
                    <div>
                        <b>Notes :</b>
                        <br />
                        <textarea rows="2" cols="54"></textarea>
                    </div>
                </div>
            </div>
            <div class="lrow clear-all-selection" style="margin-top: 10px;">
                <a style="margin-left: 5px;" id="clear-all-FloChecABI" href="javascript:void(0);" onclick="clearAllFloChecABISelection();">Clear All Selection</a>
            </div>
        </div>
    </div>
    <div class="physician-section" style="float: left; width: 100%; clear: both; margin-top: 5px;">
        <fieldset style="float: left; width: 98%; border-radius: 4px;">
            <legend>Remarks </legend>
            <div style="float: left; width: 40%;">
                <input type="checkbox" id="repeatstudyFloChecABIinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Repeat Study</b><br />
                <input type="checkbox" id="criticalFloChecABI" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b>
            </div>
            <div style="float: left; width: 58%;">
                <textarea id="physicianRemarksFloChecABI" rows="3" style="width: 98%;"></textarea>
            </div>
        </fieldset>
    </div>

</div>
<div id="FloChecABI_chat" runat="server">
    <div class="orange-band test-section-header">
        <h5>
            <span class="org-heading"><strong>Flo Chec Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyFloChecABI" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="FloChecABI-critical-span">
            <input type="checkbox" id="chkselfFloChecABI" onclick="onClick_CriticalDataFloChecABI();" />Critical</span>

        <span class="chk_orngband" id="FloChecABI-retest-span">
            <input type="checkbox" id="Retest_88" />Retest
        </span>
    </div>
    <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
        <div class="hlfbox">
            <div class="hrows">
                <div class="nrow" style="margin-left: 12px;">
                    <input type="checkbox" id="chk_FloChecABIcapturebyChat" />
                    <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
        </div>

    </div>
</div>

<script language="javascript" type="text/javascript">
    var testTypeFloChecABI = '<%= (long)TestType.FloChecABI %>';
    fileTypePDF = '<%=(long)FileType.Pdf %>';

    var isFloChecABIResultEntryType = '<%= IsResultEntrybyChat %>';

    var floChecABI = null;

    function SetFloChecABIData(testResult) {
        floChecABI = new FloChecABI(testResult);
        floChecABI.setData();
    }

    function GetFloChecABIData() {
        if (floChecABI == null) floChecABI = new FloChecABI();
        return floChecABI.getData();
    }

</script>
