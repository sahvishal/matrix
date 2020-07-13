<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AwvSubsequent.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.AwvSubsequent" %>
<%@ Import Namespace="Falcon.App.Core.Application.Domain" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Domain" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>

<script type="text/javascript" src="/Config/Content/JavaScript/AwvSubsequent.js?q=<%= VersionNumber %>"></script>
<div id="AwvSubsequent_hip" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
<div class="orange-band test-section-header">
    <h5>
        <span class="org-heading"><strong>Annual wellness visit Subsequent Results</strong></span>
    </h5>
    <span class="chk_orngband">
        <select id="conductedbyAwvSubsequent" class="conductedby-ddl">
        </select>
    </span><span class="chk_orngband" id="AwvSubsequent-critical-span">
        <input type="checkbox" id="DescribeSelfPresentAwvSubsequentInputCheck" onclick="onClick_CriticalDataAwvSubsequent();" />Critical</span>
    <span class="chk_orngband" id="awvSubsequent-priorityInQueue-span">
        <input type="checkbox" id="PriorityInQueueTestAwvSubsequentCheck" onclick="onClick_PriorityInQueueDataAwvSubsequent();" />Priority In Queue
    </span>
    <span class="chk_orngband" id="awvSubsequent-retest-span">
        <input type="checkbox" id="Retest_41" />Retest
    </span>
</div>
<div class="left_info1">
    <div class="labelwdt2 finding">
        <asp:DataList runat="server" ID="UnableToScreenAwvSubsequentDataList" EnableViewState="false"
            RepeatLayout="Flow" CssClass="dtl-unabletoscreen-AwvSubsequent" GridLines="None" RepeatDirection="Horizontal">
            <ItemTemplate>
                <input type="checkbox" id="chkUnableScreenReason" />
                <b>Unable To Screen</b>
                <input type="hidden" id="hfUnableScreenReasonID" value='<%# Convert.ToString((int)DataBinder.Eval(Container.DataItem, "Reason")) %>' />
            </ItemTemplate>
        </asp:DataList>
    </div>

    <div style="float: left; margin-top: 10px; width: 98%;">
        <div class="left media-container-div" style="width: 160px; padding-right: 20px; text-align: center">
            <span class="left" style="width: 100%">
                <img class="uploadsubsequentPDF <%=AwvFileTypes.PreventionPlan%>" alt="" src="/Content/Images/PageNotFound-Icons.jpg" /><br />
                <b>Prevention Plan</b> </span>
            <span class="left remove-image" style="width: 100%; text-align: center;">
                <a style="display: none;" href="javascript:void(0);" class="pdf-subsequent-remove <%=AwvFileTypes.PreventionPlan%>">Remove </a>
                &nbsp;<a href="javascript:OpenPopUp('Upload PDF', '330', '/app/franchisee/technician/UploadAwvTestResultFile.aspx?TestType=<%= (long)TestType.AwvSubsequent %>&fileType=<%=AwvFileTypes.PreventionPlan%>&height=110', 200);">Upload PDF </a>
            </span>
        </div>

        <div class="left media-container-div" style="width: 160px; padding-right: 20px; text-align: center">
            <span class="left" style="width: 100%">
                <img class="uploadsubsequentPDF <%=AwvFileTypes.SnapShot%>" alt="" src="/Content/Images/PageNotFound-Icons.jpg" /><br />
                <b>Snap Shot</b> </span>
            <span class="left remove-image" style="width: 100%; text-align: center;">
                <a style="display: none;" href="javascript:void(0);" class="pdf-subsequent-remove <%=AwvFileTypes.SnapShot%>">Remove </a>
                &nbsp;<a href="javascript:OpenPopUp('Upload PDF', '330', '/app/franchisee/technician/UploadAwvTestResultFile.aspx?TestType=<%= (long)TestType.AwvSubsequent %>&fileType=<%=AwvFileTypes.SnapShot%>&height=110', 200);">Upload PDF </a>
            </span>
        </div>
    </div>
</div>
<div class="rgt_info1">
    <div class="rrow">
        <b>Technician Notes: </b>
        <br />
        <textarea id="technotesAwvSubsequent" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
            rows="2" cols="54"></textarea>
    </div>
</div>
</div>
<div id="AwvSubsequent_chat" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 50%;">
            <span class="org-heading" style="width: 100%;"><strong>Annual wellness visit Subsequent Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyAwvSubsequent" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="awvSubsequent-retest-span">
            <input type="checkbox" id="Retest_41" />Retest
        </span>
    </div>
    <div class="hrows AwvSubsequent-verificationpanel" style="color: Red; background: #fff0a5; border: solid 1px fff0a5; padding: 2px 2px 2px 5px; display: none;">
    </div>
     <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
             
     <div class="hlfbox">
           <div class="hrows">
             <div class="nrow" style="margin-left:12px;">
                  <input type="checkbox" id="chk_AwvSubsequentcapturebyChat" />
                   <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
     </div>
             
     </div>
</div>
<script type="text/javascript">
    var testTypeAwvSubsequent = '<%= (long)TestType.AwvSubsequent %>';
    var fileTypePDF = '<%=(long)FileType.Pdf %>';

    var preventionPlanFileType = "<%= AwvFileTypes.PreventionPlan%>";
    var snapshotSummaryFileType = "<%= AwvFileTypes.SnapShot%>";
    var IsawvSubsequentResultEntryExternaly = '<%= IsResultEntrybyChat %>';

    var awvSubsequent = null;
    function SetAwvSubsequentData(testResult) {
        awvSubsequent = new AwvSubsequent(testResult);
        awvSubsequent.setData();
    }

    function GetAwvSubsequentData() {
        if (awvSubsequent == null) awvSubsequent = new AwvSubsequent();
        return awvSubsequent.getData();
    }
</script>
