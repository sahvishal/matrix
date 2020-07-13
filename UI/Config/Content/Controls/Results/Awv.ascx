<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Awv.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.Awv" %>
<%@ Import Namespace="Falcon.App.Core.Application.Domain" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Domain" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>

<script type="text/javascript" src="/Config/Content/JavaScript/Awv.js?q=<%= VersionNumber %>"></script>
<div id="Awv_hip" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
<div class="orange-band test-section-header">
    <h5>
        <span class="org-heading"><strong>Annual Wellness Visit (AWV) Results</strong></span>
    </h5>
    <span class="chk_orngband">
        <select id="conductedbyAwv" class="conductedby-ddl">
        </select>
    </span><span class="chk_orngband" id="Awv-critical-span">
        <input type="checkbox" id="DescribeSelfPresentAwvInputCheck" onclick="onClick_CriticalDataAwv();" />Critical</span>
    <span class="chk_orngband" id="awv-priorityInQueue-span">
        <input type="checkbox" id="PriorityInQueueTestAwvCheck" onclick="onClick_PriorityInQueueDataAwv();" />Priority In Queue
    </span>
    <span class="chk_orngband" id="awv-retest-span">
        <input type="checkbox" id="Retest_32" />Retest
    </span>
</div>
<div class="left_info1">
    <div class="labelwdt2 finding">
        <asp:DataList runat="server" ID="UnableToScreenAwvDataList" EnableViewState="false"
            RepeatLayout="Flow" CssClass="dtl-unabletoscreen-Awv" GridLines="None" RepeatDirection="Horizontal">
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
                <img class="uploadAwvPDF <%=AwvFileTypes.PreventionPlan%>" alt="" src="/Content/Images/PageNotFound-Icons.jpg" /><br />
                <b>Prevention Plan</b>
            </span>
            <span class="left" style="width: 100%; text-align: center;">
                <a href="javascript:void(0);" class="pdf-remove <%=AwvFileTypes.PreventionPlan%>" style="display: none;">Remove </a>&nbsp;
                <a href="javascript:OpenPopUp('Upload PDF', '330', '/app/franchisee/technician/UploadAwvTestResultFile.aspx?TestType=<%= (long)TestType.AWV %>&fileType=<%=AwvFileTypes.PreventionPlan%>&height=110', 200);">Upload PDF </a>
            </span>
        </div>

        <div class="left" style="width: 150px; padding-right: 20px; text-align: center">
            <span class="left" style="width: 100%">
                <img class="uploadAwvPDF <%=AwvFileTypes.SnapShot%>" alt="" src="/Content/Images/PageNotFound-Icons.jpg" /><br />
                <b>Snap Shot</b>
            </span>
            <span class="left" style="width: 100%; text-align: center;">
                <a href="javascript:void(0);" class="pdf-remove <%=AwvFileTypes.SnapShot%>" style="display: none;">Remove </a>&nbsp;
                <a href="javascript:OpenPopUp('Upload PDF', '330', '/app/franchisee/technician/UploadAwvTestResultFile.aspx?TestType=<%= (long)TestType.AWV %>&fileType=<%=AwvFileTypes.SnapShot%>&height=110', 200);">Upload  PDF </a>
            </span>
        </div>
    </div>
</div>
<div class="rgt_info1">
    <div class="rrow">
        <b>Technician Notes: </b>
        <br />
        <textarea id="technotesAwv" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
            rows="2" cols="54"></textarea>
    </div>
</div>
    </div>
<div id="Awv_chat" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 50%;">
            <span class="org-heading" style="width: 100%;"><strong>Echocardiogram Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyAwv" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="awv-retest-span">
            <input type="checkbox" id="Retest_32" />Retest
        </span>
    </div>
    <div class="hrows Awv-verificationpanel" style="color: Red; background: #fff0a5; border: solid 1px fff0a5; padding: 2px 2px 2px 5px; display: none;">
    </div>
     <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
             
     <div class="hlfbox">
           <div class="hrows">
             <div class="nrow" style="margin-left:12px;">
                  <input type="checkbox" id="chk_AwvcapturebyChat" />
                   <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
     </div>
             
     </div>
</div>

<script type="text/javascript">
    testTypeAwv = '<%= (long)TestType.AWV %>';
    fileTypePDF = '<%=(long)FileType.Pdf %>';
    preventionPlanFileType = "<%= AwvFileTypes.PreventionPlan%>";
    snapshotSummaryFileType = "<%= AwvFileTypes.SnapShot%>";
    var IsawvResultEntryExternaly = '<%= IsResultEntrybyChat %>';

    var awv = null;
    function SetAwvData(testResult) {
        awv = new Awv(testResult);
        awv.setData();
    }

    function GetAwvData() {
        if (awv == null) awv = new Awv();
        return awv.getData();
    }
</script>
