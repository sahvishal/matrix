<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Eawv.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.Eawv" %>
<%@ Import Namespace="Falcon.App.Core.Application.Domain" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Domain" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>

<script type="text/javascript" src="/Config/Content/JavaScript/Eawv.js?q=<%= VersionNumber %>"></script>

<div id="eAWV_hip" runat="server">
    <div class="orange-band test-section-header">
        <h5>
            <span class="org-heading"><strong>e-AWV Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyEawv" class="conductedby-ddl">
            </select>
        </span><span class="chk_orngband" id="Eawv-critical-span">
            <input type="checkbox" id="DescribeSelfPresentEawvInputCheck" onclick="onClick_CriticalDataEawv();" />Critical</span>
        <span class="chk_orngband" id="eawv-priorityInQueue-span">
            <input type="checkbox" id="PriorityInQueueTestEawvCheck" onclick="onClick_PriorityInQueueDataEawv();" />Priority In Queue
        </span>
        <span class="chk_orngband" id="eawv-retest-span">
            <input type="checkbox" id="Retest_81" />Retest
        </span>
    </div>
    <div class="left_info1">
        <div class="labelwdt2 finding">
            <asp:DataList runat="server" ID="UnableToScreenEawvDataList" EnableViewState="false"
                RepeatLayout="Flow" CssClass="dtl-unabletoscreen-Eawv" GridLines="None" RepeatDirection="Horizontal">
                <ItemTemplate>
                    <input type="checkbox" id="chkUnableScreenReason" />
                    <b>Unable To Screen</b>
                    <input type="hidden" id="hfUnableScreenReasonID" value='<%# Convert.ToString((int)DataBinder.Eval(Container.DataItem, "Reason")) %>' />
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div style="float: left; margin-top: 10px; width: 98%;">
            <div class="left" style="width: 130px; padding-right: 20px; text-align: center">
                <span class="left" style="width: 100%">
                    <img class="uploadeAwvPDF <%=AwvFileTypes.PreventionPlan%>" alt="" src="/Content/Images/PageNotFound-Icons.jpg" /><br />
                    <b>Prevention Plan</b>
                </span>
                <span class="left" style="width: 100%; text-align: center;">
                    <a href="javascript:void(0);" class="pdf-remove-eAwv <%=AwvFileTypes.PreventionPlan%>" style="display: none;">Remove </a>&nbsp;
                <a href="javascript:OpenPopUp('Upload PDF', '330', '/app/franchisee/technician/UploadAwvTestResultFile.aspx?TestType=<%= (long)TestType.eAWV %>&fileType=<%=AwvFileTypes.PreventionPlan%>&height=110', 200);">Upload PDF </a>
                </span>
            </div>

            <div class="left" style="width: 130px; padding-right: 20px; text-align: center">
                <span class="left" style="width: 100%">
                    <img class="uploadeAwvPDF <%=AwvFileTypes.SnapShot%>" alt="" src="/Content/Images/PageNotFound-Icons.jpg" /><br />
                    <b>Snap Shot</b>
                </span>
                <span class="left" style="width: 100%; text-align: center;">
                    <a href="javascript:void(0);" class="pdf-remove-eAwv <%=AwvFileTypes.SnapShot%>" style="display: none;">Remove </a>&nbsp;
                <a href="javascript:OpenPopUp('Upload PDF', '330', '/app/franchisee/technician/UploadAwvTestResultFile.aspx?TestType=<%= (long)TestType.eAWV %>&fileType=<%=AwvFileTypes.SnapShot%>&height=110', 200);">Upload  PDF </a>
                </span>
            </div>

            <div class="left" style="width: 130px; padding-right: 20px; text-align: center">
                <span class="left" style="width: 100%">
                    <img class="uploadeAwvPDF <%=AwvFileTypes.ResultExport%>" alt="" src="/Content/Images/PageNotFound-Icons.jpg" /><br />
                    <b>Result Export</b>
                </span>
                <span class="left" style="width: 100%; text-align: center;">
                    <a href="javascript:void(0);" class="pdf-remove-eAwv <%=AwvFileTypes.ResultExport%>" style="display: none;">Remove </a>&nbsp;
                <a href="javascript:OpenPopUp('Upload PDF', '330', '/app/franchisee/technician/UploadAwvTestResultFile.aspx?TestType=<%= (long)TestType.eAWV %>&fileType=<%=AwvFileTypes.ResultExport%>&height=110', 200);">Upload  PDF </a>
                </span>
            </div>
        </div>
    </div>
    <div class="rgt_info1">
        <div class="rrow">
            <b>Technician Notes: </b>
            <br />
            <textarea id="technotesEawv" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
                rows="2" cols="54"></textarea>
        </div>
        <div class="rrow test-not-performed-section" id="testnotPerformedEawv">
            <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0" />
            <b>Test Not Performed</b>
            <div class="test-not-performed-container" style="display: none;">
                <b>Reason : </b>
                <br />
                <asp:DropDownList ID="ddlTestNotPerformedReasonEawv" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
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
<div id="eAWV_chat" runat="server">
     <div class="orange-band test-section-header">
        <h5>
            <span class="org-heading"><strong>e-AWV Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyEawv" class="conductedby-ddl">
            </select>
        </span>
         <span class="chk_orngband" id="Eawv-critical-span">
            <input type="checkbox" id="DescribeSelfPresentEawvInputCheck" onclick="onClick_CriticalDataEawv();" />Critical</span>

        <span class="chk_orngband" id="eawv-retest-span">
            <input type="checkbox" id="Retest_81" />Retest
        </span>
    </div>
      <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
        <div class="hlfbox">
            <div class="hrows">
                <div class="nrow" style="margin-left: 12px;">
                    <input type="checkbox" id="chk_EawvcapturebyChat" />
                    <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
        </div>
    </div>
</div>

<script type="text/javascript">
    testTypeEawv = '<%= (long)TestType.eAWV %>';
    fileTypePDF = '<%=(long)FileType.Pdf %>';

    var isEawvResultEntryType = '<%= IsResultEntrybyChat %>';

    preventionPlanFileType = "<%= AwvFileTypes.PreventionPlan%>";
    snapshotSummaryFileType = "<%= AwvFileTypes.SnapShot%>";
    resultExportFileType = "<%= AwvFileTypes.ResultExport%>";

    var eawv = null;
    function SetEAWVData(testResult) {
        eawv = new Eawv(testResult);
        eawv.setData();
    }

    function GetEAWVData() {
        if (eawv == null) eawv = new Eawv();
        return eawv.getData();
    }

</script>
