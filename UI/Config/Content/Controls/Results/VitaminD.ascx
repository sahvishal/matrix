<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VitaminD.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.VitaminD" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/VitaminD.js?q=<%= VersionNumber %>"></script>
<div id="VitaminD_hip" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
<div class="orange-band test-section-header">
    <h5>
        <span class="org-heading"><strong>VitaminD Results</strong></span>
    </h5>
    <span class="chk_orngband">
        <select id="conductedbyVitaminD" class="conductedby-ddl">
        </select>
    </span><span class="chk_orngband" id="VitaminD-critical-span">
        <input type="checkbox" id="DescribeSelfPresentVitaminDInputCheck" onclick="onClick_CriticalDataVitaminD();" />Critical</span>
    <span class="chk_orngband" id="vitaminD-priorityInQueue-span">
        <input type="checkbox" id="PriorityInQueueTestVitaminDCheck" onclick="onClick_PriorityInQueueDataVitaminD();" />Priority In Queue
    </span>
    <span class="chk_orngband" id="vitaminD-retest-span">
        <input type="checkbox" id="Retest_66" />Retest
    </span>
</div>
<div class="left_info1">
    <div class="labelwdt2 finding">
        <asp:DataList runat="server" ID="UnableToScreenVitaminDDataList" EnableViewState="false"
            RepeatLayout="Flow" CssClass="dtl-unabletoscreen-VitaminD unable-to-screen-section" GridLines="None"
            RepeatDirection="Horizontal">
            <ItemTemplate>
                <input type="checkbox" id="chkUnableScreenReason" />
                <b>Unable To Screen</b>
                <input type="hidden" id="hfUnableScreenReasonID" value='<%# Convert.ToString((int)DataBinder.Eval(Container.DataItem, "Reason")) %>' />
            </ItemTemplate>
        </asp:DataList>
    </div>
</div>
<div class="rgt_info1">
    <div class="rrow">
        <strong>VitD: </strong>
        <input type="text" id="VitDtextbox" class="input_bdrbot" style="width: 100px;" />
    </div>
    <div class="rrow">
        <b>Technician Notes: </b>
        <br />
        <textarea id="technotesVitaminD" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
            rows="2" cols="54"></textarea>
    </div>
</div>
<div class="physician-section" style="float: left; width: 100%; clear: both; margin-top: 5px;">
    <fieldset style="float: left; width: 98%; border-radius: 4px;">
        <legend>Remarks </legend>
        <div style="float: left; width: 40%;">
            <input type="checkbox" id="technicallyltdbutreadableVitaminDinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Technically limited, but readable</b><br />
            <input type="checkbox" id="repeatstudyVitaminDinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Repeat Study/Unreadable</b><br />
            <input type="checkbox" id="criticalVitaminD" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b>
        </div>
        <div style="float: left; width: 58%;">
            <textarea id="physicianRemarksVitaminD" rows="3" style="width: 98%;"></textarea>
        </div>
    </fieldset>
</div>
    </div>
<div id="VitaminD_chat" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 50%;">
            <span class="org-heading" style="width: 100%;"><strong>VitaminD Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyVitaminD" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="vitaminD-retest-span">
            <input type="checkbox" id="Retest_66" />Retest
        </span>
    </div>
    <div class="hrows VitaminD-verificationpanel" style="color: Red; background: #fff0a5; border: solid 1px fff0a5; padding: 2px 2px 2px 5px; display: none;">
    </div>
     <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
             
     <div class="hlfbox">
           <div class="hrows">
             <div class="nrow" style="margin-left:12px;">
                  <input type="checkbox" id="chk_VitaminDcapturebyChat" />
                   <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
     </div>
             
     </div>
</div>

<script language="javascript" type="text/javascript">
    var testTypeVitaminD = '<%= (long)TestType.VitaminD %>';
    var IsVitaminDResultEntryExternaly = '<%=IsResultEntrybyChat%>'
    var vitaminD = null;
    function SetVitaminDData(testResult) {
        vitaminD = new VitaminD(testResult);
        vitaminD.setData();
    }

    function GetVitaminDData() {
        if (vitaminD == null) vitaminD = new VitaminD();
        return vitaminD.getData();
    }

</script>
