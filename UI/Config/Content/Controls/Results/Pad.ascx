<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Pad.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.Pad" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/Pad.js?q=<%= VersionNumber %>"></script>
<div id="pad_hip" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
<div class="orange-band test-section-header">
    <h5>
        <span class="org-heading"><strong>Peripheral Artery Disease (PAD/ABI) Results</strong></span>
    </h5>
    <span class="chk_orngband">
        <select id="conductedbypad" class="conductedby-ddl">
        </select>
    </span><span class="chk_orngband" id="pad-critical-span">
        <input type="checkbox" id="chkselfPAD" onclick="onClick_CriticalDataPad();" />Critical</span>
    <span class="chk_orngband" id="pad-priorityInQueue-span">
        <input type="checkbox" id="PriorityInQueueTestPadCheck" onclick="onClick_PriorityInQueueDataPad();" />Priority In Queue
    </span>
    <span class="chk_orngband" id="pad-retest-span">
        <input type="checkbox" id="Retest_2" />Retest
    </span>
</div>
<div style="float: left; width: 100%;" id="padContent">
    <div class="left_info1">
        <div class="lrow finding">
            <asp:GridView runat="server" ID="gvFindingsPAD" Style="float: left;" AutoGenerateColumns="False"
                EnableViewState="false" ShowHeader="False" GridLines="None" CssClass="gv-findings-pad finding-section">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="lrow">
                                <input type="radio" name="rbtFindingPAD" class="listchkbox rbt-finding" />
                                <label class="carotidgboxtxt1">
                                    <%# DataBinder.Eval(Container.DataItem, "Label")%></label><label>(<%# DataBinder.Eval(Container.DataItem, "Description")%>)</label>
                                <input type="hidden" id="FindingpadInputHidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                                <input type="hidden" class="finding-minvalue" value='<%# DataBinder.Eval(Container.DataItem, "MinValue")%>' />
                                <input type="hidden" class="finding-maxvalue" value='<%# DataBinder.Eval(Container.DataItem, "MaxValue")%>' />
                                <input type="hidden" class="finding-worstcaseorder" value='<%# DataBinder.Eval(Container.DataItem, "WorstCaseOrder")%>' />
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="lrow margin-top-small">
            <div class="left">
                <asp:DataList runat="server" ID="dtlPADUnableToScreenSelected" GridLines="None" RepeatLayout="Flow"
                    EnableViewState="false" RepeatDirection="Horizontal" CssClass="dtl-unabletoscreen-pad unable-to-screen-section">
                    <ItemTemplate>
                        <input type="checkbox" id="chkUnableScreenReason" class="gbox_chk chk-selected-pad-us" />
                        <label class="gbox_chk">
                            <b>
                                <%# DataBinder.Eval(Container.DataItem, "DisplayName")%></b>
                        </label>
                        <input type="hidden" id="hfUnableScreenReasonID" class="hdn-selected-pad-us" value='<%# Convert.ToString((int)DataBinder.Eval(Container.DataItem, "Reason")) %>' />
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
        <div class="lrow clear-all-selection">
            <a style="margin-left: 5px;" id="clear-all-pad" href="javascript:void(0);" onclick="clearAllPadSelection();">Clear All Selection</a>
        </div>
    </div>
    <div class="rgt_info1">
        <div class="rgt_gbox">
            <div class="grow">
                <div class="left">
                    <span class="carotidgboxbtxt">Systolic R Arm:<input type="text" tabindex="21" id="txtSystolicRightArm"
                        onkeydown="return KeyPress_NumericAllowedOnly(event);" class="inputbdrbot_pad" />
                    </span>
                </div>
                <div class="left">
                    <span class="carotidgboxbtxt">Systolic L Arm:<input type="text" id="txtSystolicLeftArm"
                        onkeydown="return KeyPress_NumericAllowedOnly(event);" class="inputbdrbot_pad"
                        tabindex="24" />
                    </span>
                </div>
                <div class="left">
                    <span class="carotidgboxbtxt">Systolic R Ankle:<input type="text" id="txtSystolicRightAnkle"
                        onkeydown="return KeyPress_NumericAllowedOnly(event);" class="inputbdrbot_pad"
                        style="width: 90px" tabindex="22" />
                    </span>
                </div>
                <div class="left">
                    <span class="carotidgboxbtxt">Systolic L Ankle:<input type="text" id="txtSystolicLeftAnkle"
                        onkeydown="return KeyPress_NumericAllowedOnly(event);" class="inputbdrbot_pad"
                        style="width: 90px" tabindex="25" />
                    </span>
                </div>
                <div class="left">
                    <span class="carotidgboxbtxt">Right ABI:<input type="text" id="txtRightAbi" class="inputbdrbot_pad"
                        onkeydown="return KeyPress_DecimalAllowedOnly(event);" style="width: 135px" tabindex="23" />
                    </span>
                </div>
                <div class="left">
                    <span class="carotidgboxbtxt">Left ABI:<input type="text" id="txtLeftAbi" class="inputbdrbot_pad"
                        onkeydown="return KeyPress_DecimalAllowedOnly(event);" style="width: 135px" tabindex="26" />
                    </span>
                </div>
            </div>
        </div>
        <div class="rrow">
            <b>Technician Notes: </b>
            <br />
            <textarea id="technotespad" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
                rows="2" cols="54"></textarea>
        </div>
    </div>
    <asp:DataList runat="server" ID="dtlPADIncidentalFindingsSelected" CssClass="dtl-pad-if incidental-finding-dtl"
        EnableViewState="false" GridLines="None" RepeatDirection="Horizontal" Visible="false"
        RepeatLayout="Flow">
        <ItemTemplate>
            <input type="checkbox" class="chk-if-selected" id="chkIFSelected" />
            <label class="gbox_chk">
                <%# DataBinder.Eval(Container.DataItem, "Label")%></label>
            <input type="hidden" id="hfIFID" class="hidden-ifid" value='<%# DataBinder.Eval(Container.DataItem, "Id") %>' />
            <input type="hidden" class="hidden-iftransactionid" value='0' />
        </ItemTemplate>
    </asp:DataList>
</div>
<div class="physician-section" style="float: left; width: 100%; clear: both; margin-top: 5px;">
    <fieldset style="float: left; width: 98%; border-radius: 4px;">
        <legend>Remarks </legend>
        <div style="float: left; width: 40%;">
            <input type="checkbox" id="repeatstudypadinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Repeat Study</b><br />
            <input type="checkbox" id="criticalPad" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b>
        </div>
        <div style="float: left; width: 58%;">
            <textarea id="physicianRemarksPad" rows="3" style="width: 98%;"></textarea>
        </div>
    </fieldset>
</div>
</div>

<div id="pad_chat" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 50%;">
            <span class="org-heading" style="width: 100%;"><strong>Peripheral Artery Disease (PAD/ABI) Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbypad" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="pad-critical-span">
        <input type="checkbox" id="chkselfPAD" onclick="onClick_CriticalDataPad();" />Critical</span>
        <span class="chk_orngband" id="pad-retest-span">
            <input type="checkbox" id="Retest_2" />Retest
        </span>
    </div>
    <div class="hrows pad-verificationpanel" style="color: Red; background: #fff0a5; border: solid 1px fff0a5; padding: 2px 2px 2px 5px; display: none;">
    </div>
     <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
             
     <div class="hlfbox">
           <div class="hrows">
             <div class="nrow" style="margin-left:12px;">
                  <input type="checkbox" id="chk_padcapturebyChat" />
                   <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
     </div>
             
     </div>
</div>



<script language="javascript" type="text/javascript">
    var testTypePad = '<%= (long)TestType.PAD %>';
    var IspadResultEntryExternaly = '<%= IsResultEntrybyChat %>';
    var pad = null;

    function SetPadData(testResult) {
        pad = new Pad(testResult);
        pad.setData();
    }

    function GetPadData() {
        if (pad == null) pad = new Pad();
        return pad.getData();
    }

</script>
