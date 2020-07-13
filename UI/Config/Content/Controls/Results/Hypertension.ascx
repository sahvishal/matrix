<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Hypertension.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.Hypertension" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/Hypertension.js?q=<%= VersionNumber %>"></script>
<div id="Hypertension_hip" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
<div class="orange-band test-section-header">
    <h5>
        <span class="org-heading"><strong>Blood Pressure Evaluation Results</strong></span>
    </h5>
    <span class="chk_orngband">
        <select id="conductedbyHypertension" class="conductedby-ddl">
        </select>
    </span><span class="chk_orngband" id="Hypertension-critical-span">
        <input type="checkbox" id="DescribeSelfPresentHypertensionInputCheck" onclick="onClick_CriticalDataHypertension();" />Critical</span>
    <span class="chk_orngband" id="hypertension-priorityInQueue-span">
        <input type="checkbox" id="PriorityInQueueTestHypertensionCheck" onclick="onClick_PriorityInQueueDataHypertension();" />Priority In Queue
    </span>
    <span class="chk_orngband" id="hypertension-retest-span">
        <input type="checkbox" id="Retest_67" />Retest
    </span>
</div>
<div class="contentrow">
    <div style="float: left; padding: 10px; width: 18%;">
        <strong>Systolic: </strong>
        <input type="text" id="HypertensionSystolictextbox" class="input_bdrbot" style="width: 100px;" onkeydown="return KeyPress_NumericAllowedOnly(event);" onchange="return onchangeSystolicbp(this);" />
    </div>
    <div style="float: left; padding: 10px; width: 18%;">
        <strong>Diastolic: </strong>
        <input type="text" id="HypertensionDiastolictextbox" class="input_bdrbot" style="width: 100px;" onkeydown="return KeyPress_NumericAllowedOnly(event);" onchange="return onchangeDiastolicbp(this);" />
    </div>
    <div style="float: left; padding: 10px; width: 20%;">
        <strong>Pulse Rate: </strong>
        <input type="text" id="HypertensionPulseRatetextbox" class="input_bdrbot" style="width: 100px;" onkeydown="return KeyPress_NumericAllowedOnly(event);" />
    </div>
    <div style="float: left; padding: 10px; width: 20%;" class="hypertenstionMeasurement">
        <strong>Tested Arm: </strong>

        <input type="radio" id="HypertensionRightArmBpinputcheck" value="true" name="hypertenstionMeasurement" />
        Right  
        <input type="radio" id="HypertensionLeftArmBpinputcheck" value="false" name="hypertenstionMeasurement" />
        Left 
           
    </div>
    <div style="float: left; padding: 10px; width: 10%;" class="exclude-hide-evaluation">
        <input type="checkbox" id="HypertensionisElevatedBpinputcheck" />
        Abnormal 
    </div>

</div>
<div class="left_info1">
    <div class="labelwdt2 finding">
        <asp:DataList runat="server" ID="UnableToScreenHypertensionDataList" EnableViewState="false"
            RepeatLayout="Flow" CssClass="dtl-unabletoscreen-Hypertension unable-to-screen-section" GridLines="None"
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
        <textarea id="technotesHypertension" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
            rows="2" cols="54"></textarea>
    </div>
    <div class="rrow test-not-performed-section" id="testnotPerformedHypertension" style="clear: both;">
        <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0;" /><b>Test Not Performed</b>
        <div class="test-not-performed-container" style="display: none; padding-top: 5px;">
            <b>Reason : </b>
            <br />
            <asp:DropDownList ID="ddlTestNotPerformedReasonHypertension" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
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
<div class="physician-section" style="float: left; width: 100%; clear: both; margin-top: 5px;">
    <fieldset style="float: left; width: 98%; border-radius: 4px;">
        <legend>Remarks </legend>
        <div style="float: left; width: 40%;">
            <div style="display: none">
                <input type="checkbox" id="Hypertensiontechnicallyltdbutreadableinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Technically limited, but readable</b><br />
                <input type="checkbox" id="Hypertensionrepeatstudyinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Repeat Study/Unreadable</b><br />
            </div>

            <div style="float: left;">
                <input type="checkbox" id="criticalHypertension" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b>
            </div>
        </div>
        <div style="float: left; width: 58%;">
            <textarea id="physicianRemarksHypertension" rows="3" style="width: 98%;"></textarea>
        </div>
    </fieldset>
</div>
    </div>
<div id="Hypertension_chat" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 50%;">
            <span class="org-heading" style="width: 100%;"><strong>Blood Pressure Evaluation Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyHypertension" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="hypertension-retest-span">
            <input type="checkbox" id="Retest_67" />Retest
        </span>
    </div>
    <div class="hrows Hypertension-verificationpanel" style="color: Red; background: #fff0a5; border: solid 1px fff0a5; padding: 2px 2px 2px 5px; display: none;">
    </div>
     <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
             
     <div class="hlfbox">
           <div class="hrows">
             <div class="nrow" style="margin-left:12px;">
                  <input type="checkbox" id="chk_HypertensioncapturebyChat" />
                   <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
     </div>
             
     </div>
</div>

<script language="javascript" type="text/javascript">
    var testTypeHypertension = '<%= (long)TestType.Hypertension %>';
    var IsHypertensionResultEntryExternaly = '<%=IsResultEntrybyChat%>'
    var hypertension = null;
    function SetHypertensionData(testResult) {
        hypertension = new Hypertension(testResult);
        hypertension.setData();
    }

    function GetHypertensionData() {
        if (hypertension == null) hypertension = new Hypertension();
        return hypertension.getData();
    }

    function checkElevatedHypertensionBloodPressure() {

        var systolicValue = $.trim($("#HypertensionSystolictextbox").val()).length > 0 && !isNaN($("#HypertensionSystolictextbox").val()) ? Number($("#HypertensionSystolictextbox").val()) : 0;
        var diastolicValue = $.trim($("#HypertensionDiastolictextbox").val()).length > 0 && !isNaN($("#HypertensionDiastolictextbox").val()) ? Number($("#HypertensionDiastolictextbox").val()) : 0;

        var bolChecked = false;
        if (systolicValue >= 140 || diastolicValue >= 90) bolChecked = true;

        return bolChecked;
    }

    $("#HypertensionDiastolictextbox,#HypertensionSystolictextbox").change(function () {
        var result = checkElevatedHypertensionBloodPressure();

        if (result) {
            $("#HypertensionisElevatedBpinputcheck").attr("checked", "checked");
        }
        else {
            $("#HypertensionisElevatedBpinputcheck").attr("checked", false);
        }
    });


</script>
