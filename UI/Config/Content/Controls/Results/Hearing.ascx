<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Hearing.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.Hearing" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/Hearing.js?q=<%= VersionNumber %>"></script>
<div id="Hearing_hip" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
<div class="orange-band test-section-header">
    <h5>
        <span class="org-heading"><strong>Hearing Results</strong></span>
    </h5>
    <span class="chk_orngband">
        <select id="conductedbyHearing" class="conductedby-ddl">
        </select>
    </span><span class="chk_orngband" id="hearing-critical-span">
        <input type="checkbox" id="DescribeSelfPresentHearingInputCheck" onclick="onClick_CriticalDataHearing();" />Critical </span>
    <span class="chk_orngband" id="hearing-priorityInQueue-span">
        <input type="checkbox" id="PriorityInQueueTestHearingCheck" onclick="onClick_PriorityInQueueDataHearing();" />Priority In Queue
    </span>
    <span class="chk_orngband" id="hearing-retest-span">
        <input type="checkbox" id="Retest_45" />Retest
    </span>
</div>
<div class="left_info1">
    <div class="labelwdt2">
        <table style="height: 150px;">
            <tr>
                <td style="width: 130px;"><b>Frequency:</b></td>
                <td style="width: 100px;"><b>Right (Ear)</b></td>
                <td><b>Left (Ear)</b></td>
            </tr>
            <tr>
                <td>500 Hz</td>
                <td>
                    <input type="text" id="RightEar500HzTextBox" class="input_bdrbot input_width_small" onkeydown="return KeyPress_NumericAllowedOnly(event);" />dB
                </td>
                <td>
                    <input type="text" id="LeftEar500HzTextBox" class="input_bdrbot input_width_small" onkeydown="return KeyPress_NumericAllowedOnly(event);" />dB
                </td>
            </tr>
            <tr>
                <td>1000 Hz
                </td>
                <td>
                    <input type="text" id="RightEar1000HzTextBox" class="input_bdrbot input_width_small" onkeydown="return KeyPress_NumericAllowedOnly(event);" />dB
                </td>
                <td>
                    <input type="text" id="LeftEar1000HzTextBox" class="input_bdrbot input_width_small" onkeydown="return KeyPress_NumericAllowedOnly(event);" />dB
                </td>
            </tr>
            <tr>
                <td>2000 Hz
                </td>
                <td>
                    <input type="text" id="RightEar2000HzTextBox" class="input_bdrbot input_width_small" onkeydown="return KeyPress_NumericAllowedOnly(event);" />dB
                </td>
                <td>
                    <input type="text" id="LeftEar2000HzTextBox" class="input_bdrbot input_width_small" onkeydown="return KeyPress_NumericAllowedOnly(event);" />dB
                </td>
            </tr>
            <tr>
                <td>3000 Hz
                </td>
                <td>
                    <input type="text" id="RightEar3000HzTextBox" class="input_bdrbot input_width_small" onkeydown="return KeyPress_NumericAllowedOnly(event);" />dB
                </td>
                <td>
                    <input type="text" id="LeftEar3000HzTextBox" class="input_bdrbot input_width_small" onkeydown="return KeyPress_NumericAllowedOnly(event);" />dB
                </td>
            </tr>
            <tr>
                <td>4000 Hz
                </td>
                <td>
                    <input type="text" id="RightEar4000HzTextBox" class="input_bdrbot input_width_small" onkeydown="return KeyPress_NumericAllowedOnly(event);" />dB
                </td>
                <td>
                    <input type="text" id="LeftEar4000HzTextBox" class="input_bdrbot input_width_small" onkeydown="return KeyPress_NumericAllowedOnly(event);" />dB
                </td>
            </tr>
            <tr>
                <td>6000 Hz
                </td>
                <td>
                    <input type="text" id="RightEar6000HzTextBox" class="input_bdrbot input_width_small" onkeydown="return KeyPress_NumericAllowedOnly(event);" />dB
                </td>
                <td>
                    <input type="text" id="LeftEar6000HzTextBox" class="input_bdrbot input_width_small" onkeydown="return KeyPress_NumericAllowedOnly(event);" />dB
                </td>
            </tr>
            <tr>
                <td>8000 Hz
                </td>
                <td>
                    <input type="text" id="RightEar8000HzTextBox" class="input_bdrbot input_width_small" onkeydown="return KeyPress_NumericAllowedOnly(event);" />dB
                </td>
                <td>
                    <input type="text" id="LeftEar8000HzTextBox" class="input_bdrbot input_width_small" onkeydown="return KeyPress_NumericAllowedOnly(event);" />dB
                </td>
            </tr>
        </table>
        <asp:DataList runat="server" ID="UnableToScreenHearingDataList" EnableViewState="false"
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
    <div class="rgt_gbox">
        <div class="grow hearingSummary">
            <span class="left" style="width: 150px;"><b>Summary:&nbsp;&nbsp;</b><input type="radio" value="true" name="HearingSummary" />Pass</span>
            <span class="right">
                <input type="radio" value="false" name="HearingSummary" />
                Fail</span>
        </div>
    </div>
    <div class="rrow">

        <b>Technician Notes: </b>
        <br />
        <textarea id="technotesHearing" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
            rows="2" cols="54"></textarea>
    </div>
</div>
</div>
<div id="Hearing_chat" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 50%;">
            <span class="org-heading" style="width: 100%;"><strong>Hearing Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyHearing" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="hearing-retest-span">
            <input type="checkbox" id="Retest_45" />Retest
        </span>
    </div>
    <div class="hrows hearing-verificationpanel" style="color: Red; background: #fff0a5; border: solid 1px fff0a5; padding: 2px 2px 2px 5px; display: none;">
    </div>
     <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
             
     <div class="hlfbox">
           <div class="hrows">
             <div class="nrow" style="margin-left:12px;">
                  <input type="checkbox" id="chk_hearingcapturebyChat" />
                   <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
     </div>
             
     </div>
</div>

<script language="javascript" type="text/javascript">
    var testTypeHearing = '<%= (long)TestType.Hearing %>';
    var IshearingResultEntryExternaly = '<%= IsResultEntrybyChat %>';
    var hearing = null;
    function SetHearingData(testResult) {
        hearing = new Hearing(testResult);
        hearing.setData();
    }

    function GetHearingData() {
        if (hearing == null) hearing = new Hearing();
        return hearing.getData();
    }

</script>
