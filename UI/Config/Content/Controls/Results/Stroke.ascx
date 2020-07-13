<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Stroke.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.Stroke" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/Stroke.js?q=<%= VersionNumber %>"></script>
<div id="stroke_hip" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
<div class="orange-band test-section-header">
    <h5>
        <span class="org-heading"><strong>Stroke / Carotid Artery Disease Results</strong></span>
    </h5>
    <span class="chk_orngband">
        <select id="conductedbystroke" class="conductedby-ddl">
        </select>
    </span><span class="chk_orngband" id="stroke-critical-span">
        <input type="checkbox" id="chkselfStroke" onclick="onClick_CriticalDataStroke();" />Critical</span>
    <span class="chk_orngband" id="stroke-priorityInQueue-span">
        <input type="checkbox" id="PriorityInQueueTestStrokeCheck" onclick="onClick_PriorityInQueueDataStroke();" />Priority In Queue
    </span>
    <span class="chk_orngband" id="stroke-retest-span">
        <input type="checkbox" id="Retest_1" />Retest
    </span>
</div>
<div class="left_info1">
    <div class="lrow finding">
        <asp:GridView runat="server" Style="float: left; width: 100%;" ID="StandardFindingsStrokeGridView"
            EnableViewState="false" AutoGenerateColumns="False" ShowHeader="True" GridLines="None"
            CssClass="gv-Findings-stroke finding-section">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <div class="lrow small">
                            <label class="radiotital">Right</label>
                            <label class="radiotital">Left</label>
                            <label class="radiotital" style="width: 100px; margin-left: 5px; text-align: left;">Stenosis</label>
                        </div>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="lrow">
                            <div style="float: left; width: 13%;">
                                <input type="radio" name="RightStrokeRadioButton" class="listchkbox rbt-finding-stroke-right" />
                                <input type="radio" name="LeftStrokeRadioButton" class="listchkbox rbt-finding-stroke-left" />
                            </div>
                            <div style="float: left; width: 87%;">
                                <label style="float: left; width: 26%;">
                                    <%# DataBinder.Eval(Container.DataItem, "Label")%>
                                </label>
                                <label style="float: left; width: 74%;">
                                    <%# DataBinder.Eval(Container.DataItem, "Description")%>
                                </label>
                            </div>
                        </div>
                        <input type="hidden" id="FindingstrokeInputHidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                        <input type="hidden" class="finding-minvalue" value='<%# DataBinder.Eval(Container.DataItem, "MinValue")%>' />
                        <input type="hidden" class="finding-maxvalue" value='<%# DataBinder.Eval(Container.DataItem, "MaxValue")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</div>
<div class="rgt_info1">
    <div class="rgt_gbox">
        <div class="grow">
            <div class="left stroke-reading-div exclude-hide-evaluation">
                <label class="label2">
                    <strong>RICA:</strong></label>
                <span class="carotidgboxtxt">PSV:<input type="text" id="RICAPSVInputText" class="input_bdrbot"
                    style="width: 60px;" onkeydown="return KeyPress_DecimalAllowedOnly_withsigns(event);" />cm/sec<br />
                    EDV:<input type="text" id="RICAEDVInputText" class="input_bdrbot" style="width: 60px;"
                        onkeydown="return KeyPress_DecimalAllowedOnly_withsigns(event);" />cm/sec
                </span>
            </div>
            <div class="left stroke-reading-div exclude-hide-evaluation">
                <label class="label2">
                    <strong>LICA:</strong></label>
                <span class="carotidgboxtxt">PSV:<input type="text" id="LICAPSVInputText" class="input_bdrbot"
                    style="width: 60px;" onkeydown="return KeyPress_DecimalAllowedOnly_withsigns(event);" />cm/sec<br />
                    EDV:<input type="text" id="LICAEDVInputText" class="input_bdrbot" style="width: 60px;"
                        onkeydown="return KeyPress_DecimalAllowedOnly_withsigns(event);" />cm/sec
                </span>
            </div>
            <div class="exclude-hide-evaluation left">
                <input type="checkbox" id="LowVelocityRICACheckbox" />
                <span id="LowVelocityRICALabel" runat="server"></span>
                <input type="hidden" id="LowVelocityRICAIdHiddenfield" runat="server" value="0" />
            </div>
            <div class="exclude-hide-evaluation right">
                <input type="checkbox" id="LowVelocityLICACheckbox" />
                <span id="LowVelocityLICALabel" runat="server"></span>
                <input type="hidden" id="LowVelocityLICAIdHiddenfield" runat="server" value="0" />
            </div>
        </div>
    </div>
    <div class="rrow">
        <b>Technician Notes: </b>
        <br />
        <textarea id="technotesstroke" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
            rows="2" cols="54"></textarea>
    </div>
    <div class="lrow margin-top-small">
        <asp:DataList runat="server" ID="UnableScreenReasonStrokeDataList" GridLines="None"
            EnableViewState="false" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="dtl-unabletoscreen-stroke unable-to-screen-section">
            <ItemTemplate>
                <input type="checkbox" id="UnableScreenReasonStrokeInputCheck" />
                &nbsp; <b>
                    <%# DataBinder.Eval(Container.DataItem, "DisplayName") %></b>
                <input type="hidden" id="UnableScreenReasonStrokeInputHidden" value='<%# Convert.ToInt64(DataBinder.Eval(Container.DataItem, "Reason")).ToString() %>' />
            </ItemTemplate>
        </asp:DataList>
    </div>
    <div class="lrow clear-all-selection">
        <a style="margin-left: 5px;" id="clear-all-stroke" href="javascript:void(0);" onclick="clearAllStrokeSelection();">Clear All Selection</a>
    </div>
</div>
<div style="display: none;" class="lrow3">
    <div class="left" style="width: 15%;">
        <label class="labels">
            Incidental Findings:</label>
    </div>
    <div class="left" style="width: 85%;">
        <asp:DataList runat="server" ID="IncidentalFindingsStrokeSelectedDataList" CssClass="dtl-stroke-if incidental-finding-dtl"
            EnableViewState="false" GridLines="None" RepeatDirection="Horizontal" RepeatLayout="Flow">
            <ItemTemplate>
                <input type="checkbox" class="chk-if-selected" id="chkIFSelected" />
                <label class="gbox_chk">
                    <%# DataBinder.Eval(Container.DataItem, "Label") %></label>
                <input type="hidden" id="Hidden1" class="hidden-ifid" value='<%# DataBinder.Eval(Container.DataItem, "Id") %>' />
                <input type="hidden" class="hidden-iftransactionid" value='0' />
            </ItemTemplate>
        </asp:DataList>
    </div>
</div>
<div class="contentrowltpad upload-media-section">
    <a href="javascript:OpenPopUp('Upload Media', '710', '/app/franchisee/technician/uploadTestImages.aspx?TestType=<%= (int)TestType.Stroke %>&CustomerId=' + customerId);">Upload Media</a>
</div>
<div id="StrokeImageListDiv" class="contentrow media-container-div">
</div>
<div class="physician-section" style="float: left; width: 100%; clear: both; margin-top: 5px;">
    <fieldset style="float: left; width: 98%; border-radius: 4px;">
        <legend>Remarks </legend>
        <div style="float: left; width: 40%;">
            <input type="checkbox" id="technicallyltdbutreadablestrokeinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Technically limited</b><br />
            <div runat="server" id="strokePhysicianRepeatStudy">
                <input type="checkbox" id="repeatstudystrokeinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Repeat Study/Unreadable</b><br />
            </div>
            <input type="checkbox" id="criticalStroke" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b><br />
            <div class="validate-echo-carotid-aaa" id="strokeOtherModalitiesAdditionalImages" runat="server">
                <input type="radio" id="StrokeConsiderOtherModalities" name="StrokePhysicianAdditionalFindingReading" onclick="clearAllStrokeSelection();" />&nbsp;<b>Consider other modalities</b><br />
                <input type="radio" id="StrokeAdditionalImagesNeeded" name="StrokePhysicianAdditionalFindingReading" onclick="clearAllStrokeSelection();" />&nbsp;<b>Additional images needed to finalize report</b><br />
            </div>
        </div>
        <div style="float: left; width: 58%;">
            <textarea id="physicianRemarksStroke" rows="3" style="width: 98%;"></textarea>
        </div>
    </fieldset>
</div>
    </div>

<div id="stroke_chat" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 50%;">
            <span class="org-heading" style="width: 100%;"><strong>Stroke / Carotid Artery Disease Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbystroke" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="stroke-retest-span">
            <input type="checkbox" id="Retest_1" />Retest
        </span>
    </div>
    <div class="hrows stroke-verificationpanel" style="color: Red; background: #fff0a5; border: solid 1px fff0a5; padding: 2px 2px 2px 5px; display: none;">
    </div>
     <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
             
     <div class="hlfbox">
           <div class="hrows">
             <div class="nrow" style="margin-left:12px;">
                  <input type="checkbox" id="chk_strokecapturebyChat" />
                   <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
     </div>
             
     </div>
</div>


<script language="javascript" type="text/javascript">
    var testTypeStroke = '<%= (long)TestType.Stroke %>';
    var IsstrokeResultEntryExternaly = '<%= IsResultEntrybyChat %>';

    var stroke = null;
    function SetStrokeData(testResult) {
        stroke = new Stroke(testResult);
        stroke.setData();
    }

    function GetStrokeData() {
        if (stroke == null) stroke = new Stroke();
        return stroke.getData();
    }

</script>
