<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FocAttestation.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.FocAttestation" %>
<%@ Import Namespace="Falcon.App.Core.Application.Domain" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Domain" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>

<script type="text/javascript" src="/Config/Content/JavaScript/FocAttestation.js?q=<%= VersionNumber %>"></script>

<div id="focattestation_hip" runat="server">
    <div class="orange-band test-section-header">
        <h5>
            <span class="org-heading"><strong>FOC/Attestation</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyFocAttestation" class="conductedby-ddl">
            </select>
        </span><span class="chk_orngband" id="FocAttestation-critical-span">
            <input type="checkbox" id="DescribeSelfPresentFocAttestationInputCheck" onclick="onClick_CriticalDataFocAttestation();" />Critical</span>
        <span class="chk_orngband" id="focAttestation-priorityInQueue-span">
            <input type="checkbox" id="PriorityInQueueTestFocAttestationCheck" onclick="onClick_PriorityInQueueDataFocAttestation();" />Priority In Queue
        </span>
        <span class="chk_orngband" id="focAttestation-retest-span">
            <input type="checkbox" id="Retest_92" />Retest
        </span>
    </div>
    <div class="left_info1">
        <div class="labelwdt2 finding" style="display: none;">
            <asp:DataList runat="server" ID="UnableToScreenFocAttestationDataList" EnableViewState="false"
                RepeatLayout="Flow" CssClass="dtl-unabletoscreen-FocAttestation" GridLines="None" RepeatDirection="Horizontal">
                <ItemTemplate>
                    <input type="checkbox" id="chkUnableScreenReason" />
                    <b>Unable To Screen</b>
                    <input type="hidden" id="hfUnableScreenReasonID" value='<%# Convert.ToString((int)DataBinder.Eval(Container.DataItem, "Reason")) %>' />
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div style="float: left; margin-top: 10px; width: 98%;">
            <div class="left" style="width: 150px; padding-right: 20px; text-align: center">
                <span class="left" style="width: 100%">
                    <img class="uploadfocAttestationPDF" alt="" src="/Content/Images/PageNotFound-Icons.jpg" /><br />
                    <b>FOC/Attestation</b>
                </span>
                <span class="left upload-media-section" style="width: 100%; text-align: center;">
                    <a href="javascript:void(0);" class="pdf-focAttestation-remove" style="display: none;">Remove </a>&nbsp;
                <a href="javascript:OpenPopUp('Upload PDF', '330', '/app/franchisee/technician/UploadAwvTestResultFile.aspx?TestType=<%= (long)TestType.FocAttestation %>&height=110', 200);">Upload PDF </a>
                </span>
            </div>
        </div>
    </div>
    <div class="rgt_info1">
        <div class="rrow">
            <b>Technician Notes: </b>
            <br />
            <textarea id="technotesFocAttestation" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
                rows="2" cols="54"></textarea>
        </div>
          <div style="display: none;">
        <div class="rrow test-not-performed-section" id="testnotPerformedFocAttestation">
            <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0" />
            <b>Test Not Performed</b>
            <div class="test-not-performed-container" style="display: none">
                <b>Reason : </b>
                <br />
                <asp:DropDownList ID="ddlTestNotPerformedReasonFocAttestation" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
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
</div>
<div id="focattestation_chat" runat="server">
    <div class="orange-band test-section-header">
        <h5>
            <span class="org-heading"><strong>FOC/Attestation</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyFocAttestation" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="FocAttestation-critical-span">
            <input type="checkbox" id="DescribeSelfPresentFocAttestationInputCheck" onclick="onClick_CriticalDataFocAttestation();" />Critical
        </span>
        <span class="chk_orngband" id="focAttestation-retest-span">
            <input type="checkbox" id="Retest_92" />Retest
        </span>
    </div>
    <div class="contentrow" style="width: 99%; padding-left: 0px;">
        <div class="hlfbox">
            <div class="hrows">
                <div class="nrow" style="margin-left: 12px;">
                    <input type="checkbox" id="chk_focattestationcapturebyChat" />
                    <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
            <div class="left" style="width: 150px; padding-right: 20px; text-align: center">
                <span class="left" style="width: 100%">
                    <img class="uploadfocAttestationPDF" alt="" src="/Content/Images/PageNotFound-Icons.jpg" /><br />
                    <b>FOC/Attestation</b>
                </span>
                <span class="left upload-media-section" style="width: 100%; text-align: center;">
                    <a href="javascript:void(0);" class="pdf-focAttestation-remove" style="display: none;">Remove </a>&nbsp;
                <a href="javascript:OpenPopUp('Upload PDF', '330', '/app/franchisee/technician/UploadAwvTestResultFile.aspx?TestType=<%= (long)TestType.FocAttestation %>&height=110', 200);">Upload PDF </a>
                </span>
            </div>
        </div>        
        <div style="display: none;">
        <div style="float: left; clear: none; padding-top: 0; padding-left: 35px;" class="test-not-performed-section" id="testnotPerformedFocAttestation">
            <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0"  />
            <b>Test Not Performed</b>
            <div class="test-not-performed-container" style="display: none">
                <b>Reason : </b>
                <br />
                <asp:DropDownList ID="ddlTestNotPerformedReasonFocAttestation_Chat" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
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

</div>




<script type="text/javascript">
    testTypeFocAttestation = '<%= (long)TestType.FocAttestation %>';
    fileTypeFocAttestationPDF = '<%=(long)FileType.Pdf %>';

    var isFocAttestationResultEntryType = '<%= IsResultEntrybyChat %>';

    var focAttestation = null;
    function SetFocAttestationData(testResult) {
        focAttestation = new FocAttestation(testResult);
        focAttestation.setData();
    }

    function GetFocAttestationData() {
        if (focAttestation == null) focAttestation = new FocAttestation();
        return focAttestation.getData();
    }

</script>
