<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Medicare.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.Medicare" %>
<%@ Import Namespace="Falcon.App.Core.Application.Domain" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Domain" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>

<script type="text/javascript" src="/Config/Content/JavaScript/Medicare.js?q=<%= VersionNumber %>"></script>
<div id="Medicare_hip" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
<div class="orange-band test-section-header">
    <h5>
        <span class="org-heading"><strong>Welcome to Medicare (IPPE) Results</strong></span>
    </h5>
    <span class="chk_orngband">
        <select id="conductedbyMedicare" class="conductedby-ddl">
        </select>
    </span><span class="chk_orngband" id="Medicare-critical-span">
        <input type="checkbox" id="DescribeSelfPresentMedicareInputCheck" onclick="onClick_CriticalDataMedicare();" />Critical</span>
    <span class="chk_orngband" id="medicare-priorityInQueue-span">
        <input type="checkbox" id="PriorityInQueueTestMedicareCheck" onclick="onClick_PriorityInQueueDataMedicare();" />Priority In Queue
    </span>
    <span class="chk_orngband" id="medicare-retest-span">
        <input type="checkbox" id="Retest_34" />Retest
    </span>
</div>
<div class="left_info1">
    <div class="labelwdt2 finding">
        <asp:DataList runat="server" ID="UnableToScreenMedicareDataList" EnableViewState="false"
            RepeatLayout="Flow" CssClass="dtl-unabletoscreen-Medicare" GridLines="None" RepeatDirection="Horizontal">
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
                <img class="uploadmedicarePDF <%=AwvFileTypes.PreventionPlan%>" alt="" src="/Content/Images/PageNotFound-Icons.jpg" /><br />
                <b>Prevention Plan</b>
            </span>
            <span class="left" style="width: 100%; text-align: center;">
                <a href="javascript:void(0);" class="pdf-medicare-remove <%=AwvFileTypes.PreventionPlan%>" style="display: none;">Remove </a>&nbsp;
                <a href="javascript:OpenPopUp('Upload PDF', '330', '/app/franchisee/technician/UploadAwvTestResultFile.aspx?TestType=<%= (long)TestType.Medicare %>&fileType=<%=AwvFileTypes.PreventionPlan%>&height=110', 200);">Upload PDF </a>
            </span>
        </div>

        <div class="left" style="width: 150px; padding-right: 20px; text-align: center">
            <span class="left" style="width: 100%">
                <img class="uploadmedicarePDF <%=AwvFileTypes.SnapShot%>" alt="" src="/Content/Images/PageNotFound-Icons.jpg" /><br />
                <b>Snap Shot</b>
            </span>
            <span class="left" style="width: 100%; text-align: center;">
                <a href="javascript:void(0);" class="pdf-medicare-remove <%=AwvFileTypes.SnapShot%>" style="display: none;">Remove </a>&nbsp;
                <a href="javascript:OpenPopUp('Upload PDF', '330', '/app/franchisee/technician/UploadAwvTestResultFile.aspx?TestType=<%= (long)TestType.Medicare %>&fileType=<%=AwvFileTypes.SnapShot%>&height=110', 200);">Upload  PDF </a>
            </span>
        </div>
    </div>
</div>
<div class="rgt_info1">
    <div class="rrow">
        <b>Technician Notes: </b>
        <br />
        <textarea id="technotesMedicare" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
            rows="2" cols="54"></textarea>
    </div>
</div>
</div>
<div id="Medicare_chat" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 50%;">
            <span class="org-heading" style="width: 100%;"><strong>Welcome to Medicare (IPPE) Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyMedicare" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="medicare-retest-span">
            <input type="checkbox" id="Retest_34" />Retest
        </span>
    </div>
    <div class="hrows Medicare-verificationpanel" style="color: Red; background: #fff0a5; border: solid 1px fff0a5; padding: 2px 2px 2px 5px; display: none;">
    </div>
     <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
             
     <div class="hlfbox">
           <div class="hrows">
             <div class="nrow" style="margin-left:12px;">
                  <input type="checkbox" id="chk_MedicarecapturebyChat" />
                   <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
     </div>
             
     </div>
</div>


<script type="text/javascript">
    testTypeMedicare = '<%= (long)TestType.Medicare %>';
    fileTypePDF = '<%=(long)FileType.Pdf %>';
    preventionPlanFileType = "<%= AwvFileTypes.PreventionPlan%>";
    snapshotSummaryFileType = "<%= AwvFileTypes.SnapShot%>";
    var IsmedicareResultEntryExternaly = '<%= IsResultEntrybyChat %>';

    var medicare = null;
    function SetMedicareData(testResult) {
        medicare = new Medicare(testResult);
        medicare.setData();
    }

    function GetMedicareData() {
        if (medicare == null) medicare = new Medicare();
        return medicare.getData();
    }

</script>
