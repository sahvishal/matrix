<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Colorectal.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.Colorectal" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/Colorectal.js?q=<%= VersionNumber %>"></script>
<div id="colorectal_hip" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
<div class="orange-band test-section-header">
    <h5>
        <span class="org-heading"><strong>Colorectal Results</strong></span>
    </h5>
    <span class="chk_orngband">
        <select id="conductedbyColorectal" class="conductedby-ddl">
        </select>
    </span><span class="chk_orngband" id="colorectal-critical-span">
        <input type="checkbox" id="DescribeSelfPresentColorectalInputCheck" onclick="onClick_CriticalDataColorectal();" />Critical </span>
    <span class="chk_orngband" id="colorectal-priorityInQueue-span">
        <input type="checkbox" id="PriorityInQueueTestColorectalCheck" onclick="onClick_PriorityInQueueDataColorectal();" />Priority In Queue
    </span>
    <span class="chk_orngband" id="colorectal-retest-span">
        <input type="checkbox" id="Retest_15" />Retest
    </span>
</div>
<div class="left_info1">
    <div class="labelwdt2 finding">
        <asp:DataList runat="server" ID="UnableToScreenColorectalDataList" EnableViewState="false"
            RepeatLayout="Flow" CssClass="dtl-unabletoscreen-Colorectal" GridLines="None"
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
        <b>Technician Notes: </b>
        <br />
        <textarea id="technotesColorectal" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
            rows="2" cols="54"></textarea>
    </div>
</div>
        </div>

<div id="colorectal_chat" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 50%;">
            <span class="org-heading" style="width: 100%;"><strong>Colorectal Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyColorectal" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="colorectal-retest-span">
            <input type="checkbox" id="Retest_15" />Retest
        </span>
    </div>
    <div class="hrows colorectal-verificationpanel" style="color: Red; background: #fff0a5; border: solid 1px fff0a5; padding: 2px 2px 2px 5px; display: none;">
    </div>
     <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
             
     <div class="hlfbox">
           <div class="hrows">
             <div class="nrow" style="margin-left:12px;">
                  <input type="checkbox" id="chk_colorectalcapturebyChat" />
                   <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
     </div>
             
     </div>
</div>


<script language="javascript" type="text/javascript">
    var testTypeColorectal = '<%= (long)TestType.Colorectal %>';
    var IscolorectalResultEntryExternaly = '<%= IsResultEntrybyChat %>';

    var colorectal = null;
    function SetColorectalData(testResult) {
        colorectal = new Colorectal(testResult);
        colorectal.setData();
    }

    function GetColorectalData() {
        if (colorectal == null) colorectal = new Colorectal();
        return colorectal.getData();
    }

</script>
