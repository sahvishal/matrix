<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Asi.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.Asi" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/Asi.js?q=<%= VersionNumber %>"></script>
<div id="asi_hip" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
<div class="orange-band test-section-header">
    <h5>
        <span class="org-heading"><strong>Arterial Stiffness Index (ASI) Results</strong></span>
    </h5>
    <span class="chk_orngband">
        <select id="conductedbyasi" class="conductedby-ddl">
        </select>
    </span><span class="chk_orngband" id="asi-critical-span">
        <input type="checkbox" id="DescribeSelfPresentASIInputCheck" onclick="onClick_CriticalDataAsi();" />
        Critical</span>
    <span class="chk_orngband" id="Asi-priorityInQueue-span">
        <input type="checkbox" id="PriorityInQueueTestAsiCheck" onclick="onClick_PriorityInQueueDataAsi();" />Priority In Queue
    </span>
    <span class="chk_orngband" id="Asi-retest-span">
        <input type="checkbox" id="Retest_3" />Retest
    </span>
</div>
<div style="float: left; width: 100%;" id="asiContent">
    <div class="left_info1">
        <div class="lrow finding">
            <asp:GridView runat="server" Style="float: left;" ID="StandardFindingsASIGridView"
                EnableViewState="false" AutoGenerateColumns="False" ShowHeader="False" GridLines="None"
                CssClass="gv-findings-asi finding-section">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="lrow">
                                <input type="radio" id="rbtFindingsASI" name="rbtFindingsASI" class="listchkbox rbt-finding" />
                                <label class="carotidgboxtxt1">
                                    <%# DataBinder.Eval(Container.DataItem, "Label")%></label><label>(<%# DataBinder.Eval(Container.DataItem, "Description")%>)</label>
                                <input type="hidden" id="FindingasiInputHidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                                <input type="hidden" class="finding-minvalue" value='<%# DataBinder.Eval(Container.DataItem, "MinValue")%>' />
                                <input type="hidden" class="finding-maxvalue" value='<%# DataBinder.Eval(Container.DataItem, "MaxValue")%>' />
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="lrow margin-top-small">
            <div class="left" style="width: 32%;">
                <asp:DataList runat="server" ID="ASIUnableToScreenSelectedDataList" GridLines="None"
                    EnableViewState="false" RepeatColumns="3" RepeatDirection="Horizontal" RepeatLayout="Flow"
                    CssClass="dtl-unabletoscreen-asi unable-to-screen-section">
                    <ItemTemplate>
                        <input type="checkbox" id="chkUnableScreenReason" />
                        <b>
                            <%# DataBinder.Eval(Container.DataItem, "DisplayName")%></b>
                        <input type="hidden" id="hfUnableScreenReasonID" value='<%# Convert.ToString((int)DataBinder.Eval(Container.DataItem, "Reason")) %>' />
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
        <div class="lrow clear-all-selection">
            <a style="margin-left: 5px;" id="clear-all-asi" href="javascript:void(0);" onclick="clearAllAsiSelection();">Clear All Selection</a>
        </div>
        <asp:DataList runat="server" ID="ASIIncidentalFindingsSelectedDataList" CssClass="dtl-asi-if incidental-finding-dtl"
            EnableViewState="false" GridLines="None" RepeatDirection="Horizontal" Visible="false"
            RepeatLayout="Flow">
            <ItemTemplate>
                <input type="checkbox" class="chk-if-asi-selected" id="chkIFSelected" />
                <label class="gbox_chk">
                    <%# DataBinder.Eval(Container.DataItem, "Label") %></label>
                <input type="hidden" id="hfIFID" class="hidden-ifid" value='<%# DataBinder.Eval(Container.DataItem, "Id") %>' />
                <input type="hidden" class="hidden-iftransactionid" value='0' />
            </ItemTemplate>
        </asp:DataList>
    </div>
    <div class="rgt_info1">
        <div class="rgtgbox_asi" style="float: right;">
            <div class="grow">
                <div class="left">
                    <strong>ASI:</strong>
                    <input type="text" id="AsiInputtext" class="input_bdrbot" onkeydown="return KeyPress_NumericAllowedOnly(event);"
                        style="width: 150px" />
                    <span id="ASIRawReadingSpan"></span>
                </div>
                <div class="left">
                    Pulse Pressure:<input type="text" id="PulsePressureInputtext" class="input_bdrbot pressurereading-pulsepressure"
                        style="width: 85px" />
                </div>
                <div class="left">
                    Pulse:<input type="text" id="PulseInputtext" class="input_bdrbot pressurereading-pulse"
                        style="width: 135px" />
                </div>
                <div class="left">
                    Pattern:<input type="text" id="PatternInputtext" class="input_bdrbot" style="width: 130px" />
                </div>
            </div>
        </div>
        <div class="rrow">
            <b>Technician Notes: </b>
            <br />
            <textarea id="technotesasi" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
                rows="2" cols="54"></textarea>
        </div>
    </div>
</div>
<div class="physician-section" style="float: left; width: 100%; clear: both; margin-top: 5px;">
    <fieldset style="float: left; width: 98%; border-radius: 4px;">
        <legend>Remarks </legend>
        <div style="float: left; width: 40%;">
            <input type="checkbox" id="repeatstudyasiinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Repeat Study</b><br />
            <input type="checkbox" id="criticalAsi" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b>
        </div>
        <div style="float: left; width: 58%;">
            <textarea id="physicianRemarksAsi" rows="3" style="width: 98%;"></textarea>
        </div>
    </fieldset>
</div>
<div id="ASIAverageFeatureContainerDiv" class="left" style="display: none; width: 250px; overflow: hidden;">
    <div class="left" style="width: 250px; margin-bottom: 10px;">
        <span style="float: left; width: 100px;"><b><u>ASI Values</u></b></span> <span id="AverageASIValContainerSPAN"
            style="width: 130px; float: right;">Averaged ASI: </span>
    </div>
    <div class="left append-input" style="width: 100px; height: 100px; overflow-x: hidden; overflow-y: auto;">
    </div>
    <div class="rgt" style="width: 130px;">
        <span style="float: left"><a href="javascript:void(0);" onclick="CalculateASIAverage();">Calculate </a></span>
        <br />
        <span style="float: left"><a href="javascript:AddMoreReadingBox();">Add More </a>
        </span>
        <br />
        <span style="float: left"><a href="javascript:void(0);" onclick="UpdateASIReadings();">Update </a></span>
    </div>
</div>
</div>


<div id="asi_chat" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 50%;">
            <span class="org-heading" style="width: 100%;"><strong>Arterial Stiffness Index (ASI) Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyasi" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="Asi-retest-span">
            <input type="checkbox" id="Retest_3" />Retest
        </span>
    </div>
    <div class="hrows asi-verificationpanel" style="color: Red; background: #fff0a5; border: solid 1px fff0a5; padding: 2px 2px 2px 5px; display: none;">
    </div>
     <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
             
     <div class="hlfbox">
           <div class="hrows">
             <div class="nrow" style="margin-left:12px;">
                  <input type="checkbox" id="chk_asicapturebyChat" />
                   <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
     </div>
             
     </div>
</div>
<script language="javascript" type="text/javascript">
    var testTypeAsi = '<%= (long)TestType.ASI %>';
    var IsasiResultEntryExternaly = '<%= IsResultEntrybyChat %>';
    var asi = null;

    function SetAsiData(testResult) {
        asi = new Asi(testResult);
        asi.setData();
    }

    function GetAsiData() {
        if (asi == null) asi = new Asi();
        return asi.getData();
    }

</script>
