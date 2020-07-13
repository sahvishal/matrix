<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Glaucoma.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.Glaucoma" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/Glaucoma.js?q=<%= VersionNumber %>"></script>
<div id="glaucoma_hip" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
<div class="orange-band test-section-header">
    <h5>
        <span class="org-heading"><strong>Glaucoma Results</strong></span>
    </h5>
    <span class="chk_orngband">
        <select id="conductedbyGlaucoma" class="conductedby-ddl">
        </select>
    </span><span class="chk_orngband" id="glaucoma-critical-span">
        <input type="checkbox" id="DescribeSelfPresentGlaucomaInputCheck" onclick="onClick_CriticalDataGlaucoma();" />Critical </span>
    <span class="chk_orngband" id="glaucoma-priorityInQueue-span">
        <input type="checkbox" id="PriorityInQueueTestGlaucomaCheck" onclick="onClick_PriorityInQueueDataGlaucoma();" />Priority In Queue
    </span>
    <span class="chk_orngband" id="glaucoma-retest-span">
        <input type="checkbox" id="Retest_46" />Retest
    </span>
</div>
<div class="left_info1">
    <div class="labelwdt2">
        <div class="rgt_gbox">
            <div class="grow amslerRightEye">
                <span><b>AMSLER:</b></span><br />
                <span class="left" style="width: 150px;"><span style="float: left; width: 80px;">Right Eye:</span><input type="radio" value="true" name="AmslerRightEye" />Pass</span>
                <span class="right">
                    <input type="radio" value="false" name="AmslerRightEye" />
                    Fail</span>
            </div>
            <div class="grow amslerLeftEye">
                <span class="left" style="width: 150px;"><span style="float: left; width: 80px;">Left Eye:</span><input type="radio" value="true" name="AmslerLeftEye" />Pass</span>
                <span class="right">
                    <input type="radio" value="false" name="AmslerLeftEye" />
                    Fail</span>
            </div>
            <div class="grow">
                <span><b>Eye Pressure:</b></span><br />
                <span class="left" style="width: 225px;">Right Eye:&nbsp;&nbsp;<input type="text" id="RightEyePressureTextBox" class="input_bdrbot input_width_small" onkeydown="return KeyPress_NumericAllowedOnly(event);" />mmHg</span>
                <span class="right">Left Eye:&nbsp;&nbsp;<input type="text" id="LeftEyePressureTextBox" class="input_bdrbot input_width_small" onkeydown="return KeyPress_NumericAllowedOnly(event);" />mmHg</span>
            </div>
        </div>
    </div>
    <div class="labelwdt2">
        <asp:DataList runat="server" ID="UnableToScreenGlaucomaDataList" EnableViewState="false"
            RepeatLayout="Flow" CssClass="dtl-unabletoscreen-Hearing" GridLines="None"
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
        <textarea id="technotesGlaucoma" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
            rows="2" cols="54"></textarea>
    </div>
</div>

    </div>
<div id="glaucoma_chat" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 50%;">
            <span class="org-heading" style="width: 100%;"><strong>Glaucoma Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyGlaucoma" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="glaucoma-retest-span">
            <input type="checkbox" id="Retest_46" />Retest
        </span>
    </div>
    <div class="hrows glaucoma-verificationpanel" style="color: Red; background: #fff0a5; border: solid 1px fff0a5; padding: 2px 2px 2px 5px; display: none;">
    </div>
     <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
             
     <div class="hlfbox">
           <div class="hrows">
             <div class="nrow" style="margin-left:12px;">
                  <input type="checkbox" id="chk_glaucomacapturebyChat" />
                   <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
     </div>
             
     </div>
</div>
<script language="javascript" type="text/javascript">
    var testTypeGlaucoma = '<%= (long)TestType.Glaucoma %>';
    var IsglaucomaResultEntryExternaly = '<%= IsResultEntrybyChat %>';
    var glaucoma = null;
    function SetGlaucomaData(testResult) {
        glaucoma = new Glaucoma(testResult);
        glaucoma.setData();
    }

    function GetGlaucomaData() {
        if (glaucoma == null) glaucoma = new Glaucoma();
        return glaucoma.getData();
    }

</script>
