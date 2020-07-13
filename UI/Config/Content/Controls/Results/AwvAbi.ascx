<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AwvABI.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.AwvABI" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/AwvAbi.js?q=<%= VersionNumber %>"></script>
<div id="awvAbi_hip" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
<div class="orange-band test-section-header">
    <h5>
        <span class="org-heading"><strong>Peripheral Artery Disease (PAD/ABI) Results</strong></span>
    </h5>
    <span class="chk_orngband">
        <select id="conductedbyAwvAbi" class="conductedby-ddl">
        </select>
    </span><span class="chk_orngband" id="AwvAbi-critical-span">
        <input type="checkbox" id="chkselfAwvAbi" onclick="onClick_CriticalDataAwvAbi();" />Critical</span>
    <span class="chk_orngband" id="awvAbi-priorityInQueue-span">
        <input type="checkbox" id="PriorityInQueueTestAwvAbiCheck" onclick="onClick_PriorityInQueueDataAwvAbi();" />Priority In Queue
    </span>
    <span class="chk_orngband" id="awvAbi-retest-span">
        <input type="checkbox" id="Retest_53" />Retest
    </span>
</div>
<div style="float: left; width: 100%;" id="AwvAbiContent">
    <div class="left_info1">
        <div class="lrow finding">
            <asp:GridView runat="server" ID="gvFindingsAwvAbi" Style="float: left;" AutoGenerateColumns="False"
                EnableViewState="false" ShowHeader="False" GridLines="None" CssClass="gv-findings-AwvAbi finding-section">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="lrow">
                                <input type="radio" name="rbtFindingAwvAbi" class="listchkbox rbt-finding" />
                                <label class="carotidgboxtxt1">
                                    <%# DataBinder.Eval(Container.DataItem, "Label")%></label><label>(<%# DataBinder.Eval(Container.DataItem, "Description")%>)</label>
                                <input type="hidden" id="FindingAwvAbiInputHidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
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
                <asp:DataList runat="server" ID="dtlAwvAbiUnableToScreenSelected" GridLines="None" RepeatLayout="Flow"
                    EnableViewState="false" RepeatDirection="Horizontal" CssClass="dtl-unabletoscreen-AwvAbi unable-to-screen-section">
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
            <a style="margin-left: 5px;" id="clear-all-pad" href="javascript:void(0);" onclick="clearAllAwvAbiSelection();">Clear All Selection</a>
        </div>
    </div>
    <div class="rgt_info1">
        <div class="rgt_gbox">
            <div class="grow">
                <div class="left">
                    <span class="carotidgboxbtxt">Systolic R Arm:<input type="text" tabindex="21" id="txtAwvAbiSystolicRightArm"
                        onkeydown="return KeyPress_NumericAllowedOnly(event);" class="inputbdrbot_pad" />
                    </span>
                </div>
                <div class="left">
                    <span class="carotidgboxbtxt">Systolic L Arm:<input type="text" id="txtAwvAbiSystolicLeftArm"
                        onkeydown="return KeyPress_NumericAllowedOnly(event);" class="inputbdrbot_pad"
                        tabindex="24" />
                    </span>
                </div>
                <div class="left">
                    <span class="carotidgboxbtxt">Systolic R Ankle:<input type="text" id="txtAwvAbiSystolicRightAnkle"
                        onkeydown="return KeyPress_NumericAllowedOnly(event);" class="inputbdrbot_pad"
                        style="width: 90px" tabindex="22" />
                    </span>
                </div>
                <div class="left">
                    <span class="carotidgboxbtxt">Systolic L Ankle:<input type="text" id="txtAwvAbiSystolicLeftAnkle"
                        onkeydown="return KeyPress_NumericAllowedOnly(event);" class="inputbdrbot_pad"
                        style="width: 90px" tabindex="25" />
                    </span>
                </div>
                <div class="left">
                    <span class="carotidgboxbtxt">Right ABI:<input type="text" id="txtAwvAbiRightAbi" class="inputbdrbot_pad"
                        onkeydown="return KeyPress_DecimalAllowedOnly(event);" style="width: 135px" tabindex="23" />
                    </span>
                </div>
                <div class="left">
                    <span class="carotidgboxbtxt">Left ABI:<input type="text" id="txtAwvAbiLeftAbi" class="inputbdrbot_pad"
                        onkeydown="return KeyPress_DecimalAllowedOnly(event);" style="width: 135px" tabindex="26" />
                    </span>
                </div>
            </div>
        </div>
        <div class="rrow">
            <b>Technician Notes: </b>
            <br />
            <textarea id="technotesAwvAbi" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
                rows="2" cols="54"></textarea>
        </div>
        <div class="rrow test-not-performed-section" id="testnotPerformedAwvAbi">
            <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0" />
            <b>Test Not Performed</b>
            <div class="test-not-performed-container" style="display: none;">
                <b>Reason : </b>
                <br />
                <asp:DropDownList ID="ddlTestNotPerformedReasonAwvAbi" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
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
    <asp:DataList runat="server" ID="dtlAwvAbiIncidentalFindingsSelected" CssClass="dtl-pad-if incidental-finding-dtl"
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
            <input type="checkbox" id="repeatstudyAwvAbiinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Repeat Study</b><br />
            <input type="checkbox" id="criticalAwvAbi" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b>
        </div>
        <div style="float: left; width: 58%;">
            <textarea id="physicianRemarksAwvAbi" rows="3" style="width: 98%;"></textarea>
        </div>
    </fieldset>
</div>
</div>

<div id="awvAbi_chat" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 50%;">
            <span class="org-heading" style="width: 100%;"><strong>Peripheral Artery Disease (PAD/ABI) Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyAwvAbi" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="AwvAbi-critical-span">
        <input type="checkbox" id="chkselfAwvAbi" onclick="onClick_CriticalDataAwvAbi();" />Critical</span>

        <span class="chk_orngband" id="awvAbi-retest-span">
            <input type="checkbox" id="Retest_53" />Retest
        </span>
    </div>
    <div class="hrows awvAbi-verificationpanel" style="color: Red; background: #fff0a5; border: solid 1px fff0a5; padding: 2px 2px 2px 5px; display: none;">
    </div>
     <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
             
     <div class="hlfbox">
           <div class="hrows">
             <div class="nrow" style="margin-left:12px;">
                  <input type="checkbox" id="chk_awvAbicapturebyChat" />
                   <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
     </div>
             
     </div>
</div>


<script language="javascript" type="text/javascript">
    var testTypeAwvAbi = '<%= (long)TestType.AwvABI %>';
    var IsawvABIResultEntryExternaly = '<%= IsResultEntrybyChat %>';
    var awvAbi = null;

    function SetAwvAbiData(testResult) {
        awvAbi = new AwvAbi(testResult);
        awvAbi.setData();
    }

    function GetAwvAbiData() {
        if (awvAbi == null) awvAbi = new AwvAbi();
        return awvAbi.getData();
    }

</script>

