<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HcpCarotid.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.HcpCarotid" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/HcpCarotid.js?q=<%= VersionNumber %>"></script>
<div id="hcpCarotid_hip" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
<div class="orange-band test-section-header">
    <h5>
        <span class="org-heading"><strong>Stroke / Carotid Artery Disease Results</strong></span>
    </h5>
    <span class="chk_orngband">
        <select id="conductedbyHcpCarotid" class="conductedby-ddl">
        </select>
    </span><span class="chk_orngband" id="HcpCarotid-critical-span">
        <input type="checkbox" id="chkselfHcpCarotid" onclick="onClick_CriticalDataHcpCarotid();" />Critical</span>
    <span class="chk_orngband" id="hcpCarotid-priorityInQueue-span">
        <input type="checkbox" id="PriorityInQueueTestHcpCarotidCheck" onclick="onClick_PriorityInQueueDataHcpCarotid();" />Priority In Queue
    </span>
    <span class="chk_orngband" id="hcpCarotid-retest-span">
        <input type="checkbox" id="Retest_48" />Retest
    </span>
</div>
<div class="left_info1">
    <div class="lrow finding">
        <asp:GridView runat="server" Style="float: left; width: 100%;" ID="StandardFindingsHcpCarotidGridView"
            EnableViewState="false" AutoGenerateColumns="False" ShowHeader="True" GridLines="None"
            CssClass="gv-Findings-HcpCarotid finding-section">
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
                                <input type="radio" name="RightHcpCarotidRadioButton" class="listchkbox rbt-finding-HcpCarotid-right" />
                                <input type="radio" name="LeftHcpCarotidRadioButton" class="listchkbox rbt-finding-HcpCarotid-left" />
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
                        <input type="hidden" id="FindingHcpCarotidInputHidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
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
            <div class="left">
                <label class="label2">
                    <strong>RICA:</strong></label>
                <span class="carotidgboxtxt">PSV:<input type="text" id="HcpCarotidRICAPSVInputText" class="input_bdrbot"
                    style="width: 60px;" onkeydown="return KeyPress_DecimalAllowedOnly_withsigns(event);" />cm/sec<br />
                    EDV:<input type="text" id="HcpCarotidRICAEDVInputText" class="input_bdrbot" style="width: 60px;"
                        onkeydown="return KeyPress_DecimalAllowedOnly_withsigns(event);" />cm/sec
                </span>
            </div>
            <div class="left">
                <label class="label2">
                    <strong>LICA:</strong></label>
                <span class="carotidgboxtxt">PSV:<input type="text" id="HcpCarotidLICAPSVInputText" class="input_bdrbot"
                    style="width: 60px;" onkeydown="return KeyPress_DecimalAllowedOnly_withsigns(event);" />cm/sec<br />
                    EDV:<input type="text" id="HcpCarotidLICAEDVInputText" class="input_bdrbot" style="width: 60px;"
                        onkeydown="return KeyPress_DecimalAllowedOnly_withsigns(event);" />cm/sec
                </span>
            </div>
            <div class="exclude-hide-evaluation left">
                <input type="checkbox" id="HcpCarotidLowVelocityRICACheckbox" />
                <span id="HcpCarotidLowVelocityRICALabel" runat="server"></span>
                <input type="hidden" id="HcpCarotidLowVelocityRICAIdHiddenfield" runat="server" value="0" />
            </div>
            <div class="exclude-hide-evaluation right">
                <input type="checkbox" id="HcpCarotidLowVelocityLICACheckbox" />
                <span id="HcpCarotidLowVelocityLICALabel" runat="server"></span>
                <input type="hidden" id="HcpCarotidLowVelocityLICAIdHiddenfield" runat="server" value="0" />
            </div>
        </div>
    </div>
    <div class="rrow">
        <b>Technician Notes: </b>
        <br />
        <textarea id="technotesHcpCarotid" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
            rows="2" cols="54"></textarea>
    </div>
    <div class="rrow test-not-performed-section" id="testnotPerformedHcpCarotid">
        <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0" />
        <b>Test Not Performed</b>
        <div class="test-not-performed-container" style="display: none;">
            <b>Reason : </b>
            <br />
            <asp:DropDownList ID="ddlTestNotPerformedReasonHcpCarotid" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
            </asp:DropDownList>
            <br />
            <div>
                <b>Notes :</b>
                <br />
                <textarea rows="2" cols="54"></textarea>
            </div>
        </div>
    </div>
    <div class="lrow margin-top-small">
        <asp:DataList runat="server" ID="UnableScreenReasonHcpCarotidDataList" GridLines="None"
            EnableViewState="false" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="dtl-unabletoscreen-HcpCarotid unable-to-screen-section">
            <ItemTemplate>
                <input type="checkbox" id="UnableScreenReasonHcpCarotidInputCheck" style="margin-left: 0" />
                &nbsp; <b>
                    <%# DataBinder.Eval(Container.DataItem, "DisplayName") %></b>
                <input type="hidden" id="UnableScreenReasonHcpCarotidInputHidden" value='<%# Convert.ToInt64(DataBinder.Eval(Container.DataItem, "Reason")).ToString() %>' />
            </ItemTemplate>
        </asp:DataList>
    </div>
    <div class="lrow clear-all-selection">
        <a style="margin-left: 5px;" id="clear-all-HcpCarotid" href="javascript:void(0);" onclick="clearAllHcpCarotidSelection();">Clear All Selection</a>
    </div>
</div>
<div style="display: none;" class="lrow3">
    <div class="left" style="width: 15%;">
        <label class="labels">
            Incidental Findings:</label>
    </div>
    <div class="left" style="width: 85%;">
        <asp:DataList runat="server" ID="IncidentalFindingsHcpCarotidSelectedDataList" CssClass="dtl-HcpCarotid-if incidental-finding-dtl"
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
    <a href="javascript:OpenPopUp('Upload Media', '710', '/app/franchisee/technician/uploadTestImages.aspx?TestType=<%= (int)TestType.HCPCarotid %>&CustomerId=' + customerId);">Upload Media</a>
</div>
<div id="HcpCarotidImageListDiv" class="contentrow media-container-div">
</div>
<div class="physician-section" style="float: left; width: 100%; clear: both; margin-top: 5px;">
    <fieldset style="float: left; width: 98%; border-radius: 4px;">
        <legend>Remarks </legend>
        <div style="float: left; width: 40%;">
            <input type="checkbox" id="technicallyltdbutreadableHcpCarotidinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Technically limited</b><br />
            <input type="checkbox" id="repeatstudyHcpCarotidinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Repeat Study/Unreadable</b><br />
            <input type="checkbox" id="criticalHcpCarotid" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b><br />
        </div>
        <div style="float: left; width: 58%;">
            <textarea id="physicianRemarksHcpCarotid" rows="3" style="width: 98%;"></textarea>
        </div>
    </fieldset>
</div>
    </div>
<div id="hcpCarotid_chat" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 50%;">
            <span class="org-heading" style="width: 100%;"><strong>Stroke / Carotid Artery Disease Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyHcpCarotid" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="hcpCarotid-retest-span">
            <input type="checkbox" id="Retest_48" />Retest
        </span>
    </div>
    <div class="hrows hcpCarotid-verificationpanel" style="color: Red; background: #fff0a5; border: solid 1px fff0a5; padding: 2px 2px 2px 5px; display: none;">
    </div>
     <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
             
     <div class="hlfbox">
           <div class="hrows">
             <div class="nrow" style="margin-left:12px;">
                  <input type="checkbox" id="chk_hcpCarotidcapturebyChat" />
                   <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
     </div>
             
     </div>
</div>
<script language="javascript" type="text/javascript">
    var testTypeHcpCarotid = '<%= (long)TestType.HCPCarotid %>';
    var IshcpCarotidResultEntryExternaly = '<%= IsResultEntrybyChat %>';
    var hcpCarotid = null;
    function SetHcpCarotidData(testResult) {
        hcpCarotid = new HcpCarotid(testResult);
        hcpCarotid.setData();
    }

    function GetHcpCarotidData() {
        if (hcpCarotid == null) hcpCarotid = new HcpCarotid();
        return hcpCarotid.getData();
    }

</script>
