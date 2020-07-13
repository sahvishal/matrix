<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Lead.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.Lead" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/Lead.js?q=<%= VersionNumber %>"></script>
<div id="lead_hip" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
<div class="orange-band test-section-header">
    <h5>
        <span class="org-heading"><strong>Lower Extremity Arterial Duplex (LEAD) Results</strong></span>
    </h5>
    <span class="chk_orngband">
        <select id="conductedbylead" class="conductedby-ddl">
        </select>
    </span><span class="chk_orngband" id="lead-critical-span">
        <input type="checkbox" id="chkselfLead" onclick="onClick_CriticalDataLead();" />Critical</span>
    <span class="chk_orngband" id="lead-priorityInQueue-span">
        <input type="checkbox" id="PriorityInQueueTestLeadCheck" onclick="onClick_PriorityInQueueDataLead();" />Priority In Queue
    </span>
    <span class="chk_orngband" id="lead-retest-span">
        <input type="checkbox" id="Retest_35" />Retest
    </span>
</div>
<div class="left_info1">
    <div class="lrow finding" style="display: none;" id="LeadStandardFindingsView">
        <asp:GridView runat="server" Style="float: left; width: 100%;" ID="StandardFindingsLeadGridView"
            EnableViewState="false" AutoGenerateColumns="False" ShowHeader="True" GridLines="None"
            CssClass="gv-Findings-lead finding-section">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <div class="lrow small">
                            <label class="radiotital">Right</label>
                            <label class="radiotital">Left</label>
                        </div>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="lrow">
                            <div style="float: left; width: 13%;">
                                <input type="radio" name="RightLeadRadioButton" class="listchkbox rbt-finding-lead-right" />
                                <input type="radio" name="LeftLeadRadioButton" class="listchkbox rbt-finding-lead-left" />
                                <input type="hidden" class="finding-worstcaseorder" value='<%# DataBinder.Eval(Container.DataItem, "WorstCaseOrder")%>' />
                            </div>
                            <div style="float: left; width: 87%;">
                                <label style="float: left; width: 99%;">
                                    <%# DataBinder.Eval(Container.DataItem, "Label")%>
                                </label>
                            </div>
                        </div>
                        <input type="hidden" id="FindingleadInputHidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                        <input type="hidden" class="finding-minvalue" value='<%# DataBinder.Eval(Container.DataItem, "MinValue")%>' />
                        <input type="hidden" class="finding-maxvalue" value='<%# DataBinder.Eval(Container.DataItem, "MaxValue")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div class="lrow finding" id="LeadTestReadingView">
        <table class="gv-Findings-lead finding-section-checkbox" style="border-collapse: collapse; float: left; width: 100%;" cellspacing="0" border="0">
            <tbody>
                <tr>
                    <th scope="col">
                        <div class="lrow small">
                            <label class="radiotital">Right</label>
                            <label class="radiotital">Left</label>
                        </div>
                    </th>
                </tr>
                <tr>
                    <td>
                        <div class="lrow">
                            <div style="float: left; width: 13%;">
                                <input name="RightLeadRadioButton" class="listchkbox rbt-finding-lead-right" id="rightNoVisualPlaque" type="checkbox">
                                <input name="LeftLeadRadioButton" class="listchkbox rbt-finding-lead-left" id="leftNoVisualPlaque" type="checkbox">
                            </div>
                            <div style="float: left; width: 87%;">
                                <label style="float: left; width: 99%;">
                                    No visual plaque shown
                                </label>
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="lrow">
                            <div style="float: left; width: 13%;">
                                <input name="RightLeadRadioButton" class="listchkbox rbt-finding-lead-right" id="rightVisuallyDemonstratedPlaque" type="checkbox">
                                <input name="LeftLeadRadioButton" class="listchkbox rbt-finding-lead-left" id="leftVisuallyDemonstratedPlaque" type="checkbox">
                            </div>
                            <div style="float: left; width: 87%;">
                                <label style="float: left; width: 99%;">
                                    Visually demonstrated plaque/calcification
                                </label>
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="lrow">
                            <div style="float: left; width: 13%;">
                                <input name="RightLeadRadioButton" class="listchkbox rbt-finding-lead-right" id="rightModerateStenosis" type="checkbox">
                                <input name="LeftLeadRadioButton" class="listchkbox rbt-finding-lead-left" id="leftModerateStenosis" type="checkbox">
                            </div>
                            <div style="float: left; width: 87%;">
                                <label style="float: left; width: 99%;">
                                    Moderate stenosis or greater(PSV Greater than 200cm/s)
                                </label>
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="lrow">
                            <div style="float: left; width: 13%;">
                                <input name="RightLeadRadioButton" class="listchkbox rbt-finding-lead-right" id="rightPossibleOcclusion" type="checkbox">
                                <input name="LeftLeadRadioButton" class="listchkbox rbt-finding-lead-left" id="leftPossibleOcclusion" type="checkbox">
                            </div>
                            <div style="float: left; width: 87%;">
                                <label style="float: left; width: 99%;">
                                    Possible Occlusion
                                </label>
                            </div>
                        </div>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div class="rrow" style="float: left; clear: both; padding-top: 10px; padding-left: 4px;">
        <b>Technician Notes: </b>
        <br />
        <textarea id="technoteslead" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
            rows="2" cols="54"></textarea>
    </div>
    <div class="lrow margin-top-small">
        <asp:DataList runat="server" ID="UnableScreenReasonLeadDataList" GridLines="None"
            EnableViewState="false" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="dtl-unabletoscreen-lead unable-to-screen-section">
            <ItemTemplate>
                <input type="checkbox" id="UnableScreenReasonLeadInputCheck" />
                &nbsp; <b>
                    <%# DataBinder.Eval(Container.DataItem, "DisplayName") %></b>
                <input type="hidden" id="UnableScreenReasonLeadInputHidden" value='<%# Convert.ToInt64(DataBinder.Eval(Container.DataItem, "Reason")).ToString() %>' />
            </ItemTemplate>
        </asp:DataList>
    </div>
    <div class="lrow clear-all-selection">
        <a style="margin-left: 5px;" id="clear-all-lead" href="javascript:void(0);" onclick="clearAllLeadSelection();">Clear All Selection</a>
    </div>
</div>
<div class="rgt_info1">
    <div class="rgt_gbox">
        <div class="grow">
            <div class="exclude-hide-evaluation left" style="width: 420px;">
                <label class="label2"><strong>Right:</strong></label><br />
                <span class="carotidgboxtxt" style="width: 410px;">CFA (Common femoral artery) PSV:
                    <input type="text" id="RightCFAPSVInputText" class="input_bdrbot" style="width: 60px;" onkeydown="return KeyPress_DecimalAllowedOnly_withsigns(event);" />cm/sec<br />
                    PSFA (Proximal femoral artery) PSV:
                    <input type="text" id="RightPSFAPSVInputText" class="input_bdrbot" style="width: 60px;" onkeydown="return KeyPress_DecimalAllowedOnly_withsigns(event);" />cm/sec
                </span>
            </div>
            <div class="exclude-hide-evaluation left" style="width: 420px;">
                <input type="checkbox" id="LowVelocityRightCheckbox" />
                <span id="LowVelocityRightLabel" runat="server"></span>
                <input type="hidden" id="LowVelocityRightIdHiddenfield" runat="server" value="0" />
            </div>
            <div class="exclude-hide-evaluation left" style="width: 420px;">
                <label class="label2"><strong>Left:</strong></label><br />
                <span class="carotidgboxtxt" style="width: 410px;">CFA (Common femoral artery) PSV:
                    <input type="text" id="LeftCFAPSVInputText" class="input_bdrbot" style="width: 60px;" onkeydown="return KeyPress_DecimalAllowedOnly_withsigns(event);" />cm/sec<br />
                    PSFA (Proximal femoral artery) PSV:
                    <input type="text" id="LeftPSFAPSVInputText" class="input_bdrbot" style="width: 60px;" onkeydown="return KeyPress_DecimalAllowedOnly_withsigns(event);" />cm/sec
                </span>
            </div>
            <div class="exclude-hide-evaluation right" style="width: 420px;">
                <input type="checkbox" id="LowVelocityLeftCheckbox" />
                <span id="LowVelocityLeftLabel" runat="server"></span>
                <input type="hidden" id="LowVelocityLeftIdHiddenfield" runat="server" value="0" />
            </div>
        </div>
    </div>
    <div class="rrow test-not-performed-section" id="testnotPerformedLead">
        <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0" />
        <b>Test Not Performed</b>
        <div class="test-not-performed-container" style="display: none;">
            <b>Reason : </b>
            <br />
            <asp:DropDownList ID="ddlTestNotPerformedReasonLead" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
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
<div style="display: none;" class="lrow3">
    <div class="left" style="width: 15%;">
        <label class="labels">
            Incidental Findings:</label>
    </div>
    <div class="left" style="width: 85%;">
        <asp:DataList runat="server" ID="IncidentalFindingsLeadSelectedDataList" CssClass="dtl-lead-if incidental-finding-dtl"
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
<div class="contentrowltpad upload-media-section" style="padding-top: 10px; padding-left: 15px;">
    <a href="javascript:OpenPopUp('Upload Media', '710', '/app/franchisee/technician/uploadTestImages.aspx?TestType=<%= (int)TestType.Lead %>&CustomerId=' + customerId);">Upload Media</a>
</div>
<div id="LeadImageListDiv" class="contentrow media-container-div">
</div>
<div class="physician-section" style="float: left; width: 100%; clear: both; margin-top: 5px;">
    <fieldset style="float: left; width: 98%; border-radius: 4px;">
        <legend>Remarks </legend>
        <div style="float: left; width: 40%;">
            <input type="checkbox" id="technicallyltdbutreadableleadinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Technically limited, but readable</b><br />
            <input type="checkbox" id="repeatstudyleadinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Unreadable</b><br />
            <input type="checkbox" id="criticalLead" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b><br />
        </div>
        <div style="float: left; width: 58%;">
            <textarea id="physicianRemarksLead" rows="3" style="width: 98%;"></textarea>
        </div>
        <div style="float: right; width: 58%; margin-right: 2%; display: none" id="diagnosisCodeLeadContainer">
            <b>Possible diagnosis codes:</b><br />
            <textarea id="diagnosisCodeLead" rows="2" style="width: 98%;" readonly="readonly"></textarea>
        </div>
    </fieldset>
</div>
    </div>

<div id="lead_chat" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 50%;">
            <span class="org-heading" style="width: 100%;"><strong>Lower Extremity Arterial Duplex (LEAD) Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbylead" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="lead-critical-span">
        <input type="checkbox" id="chkselfLead" onclick="onClick_CriticalDataLead();" />Critical</span>

        <span class="chk_orngband" id="lead-retest-span">
            <input type="checkbox" id="Retest_35" />Retest
        </span>
    </div>
    <div class="hrows lead-verificationpanel" style="color: Red; background: #fff0a5; border: solid 1px fff0a5; padding: 2px 2px 2px 5px; display: none;">
    </div>
     <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
             
     <div class="hlfbox">
           <div class="hrows">
             <div class="nrow" style="margin-left:12px;">
                  <input type="checkbox" id="chk_leadcapturebyChat" />
                   <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
     </div>
             
     </div>
</div>

<script language="javascript" type="text/javascript">
    var testTypeLead = '<%= (long)TestType.Lead %>';
    var IsleadResultEntryExternaly = '<%= IsResultEntrybyChat%>';
    var lead = null;
    function SetLeadData(testResult) {
        lead = new Lead(testResult);
        lead.setData();
    }

    function GetLeadData() {
        if (lead == null) lead = new Lead();
        return lead.getData();
    }

    if ('<%= HideDiagnosisCodeLead %>' === '<%= Boolean.TrueString %>') {
        $("#diagnosisCodeLeadContainer").hide();
        $("#LeadStandardFindingsView").hide();
        $("#LeadTestReadingView").show();
    }
    else {
        $("#diagnosisCodeLeadContainer").show();
        $("#LeadStandardFindingsView").show();
        $("#LeadTestReadingView").hide();
    }

</script>
