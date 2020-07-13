<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuantaFloABI.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.QuantaFloABI" %>
<%@ Import Namespace="Falcon.App.Core.Application.Domain" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/QuantaFloABI.js?q=<%= VersionNumber %>"></script>



<div id="QuantaFloABI_hip" runat="server">
    <div class="orange-band test-section-header">
        <h5>
            <span class="org-heading"><strong>QuantaFlo ABI Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyQuantaFloABI" class="conductedby-ddl">
            </select>
        </span><span class="chk_orngband" id="QuantaFloABI-critical-span">
            <input type="checkbox" id="chkselfQuantaFloABI" onclick="onClick_CriticalDataQuantaFloABI();" />Critical</span>
        <span class="chk_orngband" id="QuantaFloABI-priorityInQueue-span">
            <input type="checkbox" id="PriorityInQueueTestQuantaFloABICheck" onclick="onClick_PriorityInQueueDataQuantaFloABI();" />Priority In Queue
        </span>
        <span class="chk_orngband" id="QuantaFloABI-retest-span">
            <input type="checkbox" id="Retest_94" />Retest
        </span>
    </div>
    <div style="float: left; width: 100%;" id="QuantaFloABIContent">
        <div class="left_info1">
            <div class="lrow finding">
                <asp:GridView runat="server" ID="gvFindingsQuantaFloABI" Style="float: left;" AutoGenerateColumns="False"
                    EnableViewState="false" ShowHeader="False" GridLines="None" CssClass="gv-findings-QuantaFloABI finding-section">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <div class="lrow">
                                    <input type="radio" name="rbtFindingQuantaFloABI" class="listchkbox rbt-finding" />
                                    <label class="findingQuantaFloABIcheckBox">
                                        <%# DataBinder.Eval(Container.DataItem, "Label")%>
                                    </label>
                                    <label style="display: none;"><%# DataBinder.Eval(Container.DataItem, "Description").ToString().Length > 0 ? "(" + DataBinder.Eval(Container.DataItem, "Description") + ")":"" %></label>
                                    <input type="hidden" id="FindingQuantaFloABIInputHidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
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
                    <asp:DataList runat="server" ID="dtlQuantaFloABIUnableToScreenSelected" GridLines="None" RepeatLayout="Flow"
                        EnableViewState="false" RepeatDirection="Horizontal" CssClass="dtl-unabletoscreen-QuantaFloABI unable-to-screen-section">
                        <ItemTemplate>
                            <input type="checkbox" id="chkUnableScreenReason" class="gbox_chk chk-selected-QuantaFloABI-us" />
                            <label class="gbox_chk">
                                <b>
                                    <%# DataBinder.Eval(Container.DataItem, "DisplayName")%></b>
                            </label>
                            <input type="hidden" id="hfUnableScreenReasonID" class="hdn-selected-QuantaFloABI-us" value='<%# Convert.ToString((int)DataBinder.Eval(Container.DataItem, "Reason")) %>' />
                        </ItemTemplate>
                    </asp:DataList>
                </div>
            </div>
            <div class="left" style="width: 937px; padding: 3px;">
                <div id="QuantaFloABIContainerDiv" class="contentrowltpad media-container-div" style="margin-top: 5px;">
                </div>
                <div class="contentrowltpad upload-media-section">
                    <a href="javascript:OpenPopUp('Upload Media', '710', '/app/franchisee/technician/uploadTestImages.aspx?RestricttoOne=true&TestType=<%= (int)TestType.QuantaFloABI %>&CustomerId=' + customerId);">Upload Media</a>
                </div>
            </div>
        </div>
        <div class="rgt_info1">
            <div class="rrow">
                <b>Technician Notes: </b>
                <br />
                <textarea id="technotesQuantaFloABI" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
                    rows="2" cols="54"></textarea>
            </div>
            <div class="rrow test-not-performed-section" id="testnotPerformedQuantaFloABI">
                <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0" />
                <b>Test Not Performed</b>
                <div class="test-not-performed-container" style="display: none;">
                    <b>Reason : </b>
                    <br />
                    <asp:DropDownList ID="ddlTestNotPerformedReasonQuantaFloABI" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
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
                <a style="margin-left: 5px;" id="clear-all-QuantaFloABI" href="javascript:void(0);" onclick="clearAllQuantaFloABISelection();">Clear All Selection</a>
            </div>
        </div>
    </div>
    <div class="physician-section" style="float: left; width: 100%; clear: both; margin-top: 5px;">
        <fieldset style="float: left; width: 98%; border-radius: 4px;">
            <legend>Remarks </legend>
            <div style="float: left; width: 40%;">
                <input type="checkbox" id="repeatstudyQuantaFloABIinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Repeat Study</b><br />
                <input type="checkbox" id="criticalQuantaFloABI" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b>
            </div>
            <div style="float: left; width: 58%;">
                <textarea id="physicianRemarksQuantaFloABI" rows="3" style="width: 98%;"></textarea>
            </div>
        </fieldset>
    </div>
</div>
<div id="QuantaFloABI_chat" runat="server">
    <div class="orange-band test-section-header">
        <h5>
            <span class="org-heading"><strong>QuantaFlo ABI Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyQuantaFloABI" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="QuantaFloABI-critical-span">
            <input type="checkbox" id="chkselfQuantaFloABI" onclick="onClick_CriticalDataQuantaFloABI();" />Critical</span>

        <span class="chk_orngband" id="QuantaFloABI-retest-span">
            <input type="checkbox" id="Retest_94" />Retest
        </span>
    </div>
    <div class="contentrow" style="width: 99%; padding-left: 0px;">
        <div class="hlfbox">
            <div class="nrow" style="margin-left: 12px;">
                <input type="checkbox" id="chk_quantafloabicapturebyChat" />
                <b>Result Entry Completed in CHAT </b>
            </div>
            <div class="left" style="width: 937px; padding: 3px;">
                <div id="QuantaFloABIContainerDiv" class="contentrowltpad media-container-div" style="margin-top: 5px;">
                </div>
                <div class="contentrowltpad upload-media-section">
                    <a href="javascript:OpenPopUp('Upload Media', '710', '/app/franchisee/technician/uploadTestImages.aspx?RestricttoOne=true&TestType=<%= (int)TestType.QuantaFloABI %>&CustomerId=' + customerId);">Upload Media</a>
                </div>
            </div>

        </div>
        <div style="float: left;clear: none;padding-top: 0" class="rrow test-not-performed-section" id="testnotPerformedQuantaFloABI">
            <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0" />
            <b>Test Not Performed</b>
            <div class="test-not-performed-container" style="display: none;">
                <b>Reason : </b>
                <br />
                <asp:DropDownList ID="ddlTestNotPerformedReasonQuantaFloABI_CHAT" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
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
    var testTypeQuantaFloABI = '<%= (long)TestType.QuantaFloABI %>';
    fileTypePDF = '<%=(long)FileType.Pdf %>';
    var isQuantaFloABIResultEntryType = '<%= IsResultEntrybyChat %>';
    var quantaFloABI = null;

    function SetQuantaFloABIData(testResult) {
        quantaFloABI = new QuantaFloABI(testResult);
        quantaFloABI.setData();
    }

    function GetQuantaFloABIData() {
        if (quantaFloABI == null) quantaFloABI = new QuantaFloABI();
        return quantaFloABI.getData();
    }
</script>
