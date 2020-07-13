<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AwvCarotid.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.AwvCarotid" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/AwvCarotid.js?q=<%= VersionNumber %>"></script>
<div id="awvCarotid_hip" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
<div class="orange-band test-section-header">
    <h5>
        <span class="org-heading"><strong>Stroke / Carotid Artery Disease Results</strong></span>
    </h5>
    <span class="chk_orngband">
        <select id="conductedbyAwvCarotid" class="conductedby-ddl">
        </select>
    </span><span class="chk_orngband" id="AwvCarotid-critical-span">
        <input type="checkbox" id="chkselfAwvCarotid" onclick="onClick_CriticalDataAwvCarotid();" />Critical</span>
    <span class="chk_orngband" id="awvCarotid-priorityInQueue-span">
        <input type="checkbox" id="PriorityInQueueTestAwvCarotidCheck" onclick="onClick_PriorityInQueueDataAwvCarotid();" />Priority In Queue
    </span>
    <span class="chk_orngband" id="awvCarotid-retest-span">
        <input type="checkbox" id="Retest_56" />Retest
    </span>
</div>
<div class="left_info1">
    <div class="lrow finding">
        <asp:GridView runat="server" Style="float: left; width: 100%;" ID="StandardFindingsAwvCarotidGridView"
            EnableViewState="false" AutoGenerateColumns="False" ShowHeader="True" GridLines="None"
            CssClass="gv-Findings-AwvCarotid finding-section">
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
                                <input type="radio" name="RightAwvCarotidRadioButton" class="listchkbox rbt-finding-AwvCarotid-right" />
                                <input type="radio" name="LeftAwvCarotidRadioButton" class="listchkbox rbt-finding-AwvCarotid-left" />
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
                        <input type="hidden" id="FindingAwvCarotidInputHidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                        <input type="hidden" class="finding-minvalue" value='<%# DataBinder.Eval(Container.DataItem, "MinValue")%>' />
                        <input type="hidden" class="finding-maxvalue" value='<%# DataBinder.Eval(Container.DataItem, "MaxValue")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

    <div class="rrow" style="padding-top: 15px; clear: both;">
        <b>Technician Notes: </b>
        <br />
        <textarea id="technotesAwvCarotid" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
            rows="2" cols="54"></textarea>
    </div>
    <div class="lrow margin-top-small">
        <asp:DataList runat="server" ID="UnableScreenReasonAwvCarotidDataList" GridLines="None"
            EnableViewState="false" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="dtl-unabletoscreen-AwvCarotid unable-to-screen-section">
            <ItemTemplate>
                <input type="checkbox" id="UnableScreenReasonAwvCarotidInputCheck" />
                &nbsp; <b>
                    <%# DataBinder.Eval(Container.DataItem, "DisplayName") %></b>
                <input type="hidden" id="UnableScreenReasonAwvCarotidInputHidden" value='<%# Convert.ToInt64(DataBinder.Eval(Container.DataItem, "Reason")).ToString() %>' />
            </ItemTemplate>
        </asp:DataList>
    </div>
    <div class="lrow clear-all-selection">
        <a style="margin-left: 5px;" id="clear-all-stroke" href="javascript:void(0);" onclick="clearAllAwvCarotidSelection();">Clear All Selection</a>
    </div>
    <div class="rrow test-not-performed-section" id="testnotPerformedAwvCarotid">
        <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" />
        <b>Test Not Performed</b>
        <div class="test-not-performed-container" style="display: none;">
            <b>Reason : </b>
            <br />
            <asp:DropDownList ID="ddlTestNotPerformedReasonAwvCarotid" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
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
<div class="rgt_info1">
    <div class="rgt_gbox exclude-hide-evaluation">
        <div class="grow">
            <div class="left">
                <label class="carotidreading-label">
                    <strong>R CCA PROXIMAL:</strong></label>
                <span class="carotidgboxtxt">PSV:<input type="text" id="RCCAProximalPSVInputText" class="input_bdrbot"
                    style="width: 60px;" onkeydown="return KeyPress_DecimalAllowedOnly_withsigns(event);" />cm/sec<br />
                    EDV:<input type="text" id="RCCAProximalEDVInputText" class="input_bdrbot" style="width: 60px;"
                        onkeydown="return KeyPress_DecimalAllowedOnly_withsigns(event);" />cm/sec
                </span>
            </div>
            <div class="left">
                <label class="carotidreading-label">
                    <strong>L CCA PROXIMAL:</strong></label>
                <span class="carotidgboxtxt">PSV:<input type="text" id="LCCAProximalPSVInputText" class="input_bdrbot"
                    style="width: 60px;" onkeydown="return KeyPress_DecimalAllowedOnly_withsigns(event);" />cm/sec<br />
                    EDV:<input type="text" id="LCCAProximalEDVInputText" class="input_bdrbot" style="width: 60px;"
                        onkeydown="return KeyPress_DecimalAllowedOnly_withsigns(event);" />cm/sec
                </span>
            </div>
            <div class="left">
                <label class="carotidreading-label">
                    <strong>R CCA DISTAL:</strong></label>
                <span class="carotidgboxtxt">PSV:<input type="text" id="RCCADistalPSVInputText" class="input_bdrbot"
                    style="width: 60px;" onkeydown="return KeyPress_DecimalAllowedOnly_withsigns(event);" />cm/sec<br />
                    EDV:<input type="text" id="RCCADistalEDVInputText" class="input_bdrbot" style="width: 60px;"
                        onkeydown="return KeyPress_DecimalAllowedOnly_withsigns(event);" />cm/sec
                </span>
            </div>
            <div class="left">
                <label class="carotidreading-label">
                    <strong>L CCA DISTAL:</strong></label>
                <span class="carotidgboxtxt">PSV:<input type="text" id="LCCADistalPSVInputText" class="input_bdrbot"
                    style="width: 60px;" onkeydown="return KeyPress_DecimalAllowedOnly_withsigns(event);" />cm/sec<br />
                    EDV:<input type="text" id="LCCADistalEDVInputText" class="input_bdrbot" style="width: 60px;"
                        onkeydown="return KeyPress_DecimalAllowedOnly_withsigns(event);" />cm/sec
                </span>
            </div>
            <div class="left">
                <label class="carotidreading-label">
                    <strong>R BULB:</strong></label>
                <span class="carotidgboxtxt">PSV:<input type="text" id="RBulbPSVInputText" class="input_bdrbot"
                    style="width: 60px;" onkeydown="return KeyPress_DecimalAllowedOnly_withsigns(event);" />cm/sec<br />
                    EDV:<input type="text" id="RBulbEDVInputText" class="input_bdrbot" style="width: 60px;"
                        onkeydown="return KeyPress_DecimalAllowedOnly_withsigns(event);" />cm/sec
                </span>
            </div>
            <div class="left">
                <label class="carotidreading-label">
                    <strong>L BULB:</strong></label>
                <span class="carotidgboxtxt">PSV:<input type="text" id="LBulbPSVInputText" class="input_bdrbot"
                    style="width: 60px;" onkeydown="return KeyPress_DecimalAllowedOnly_withsigns(event);" />cm/sec<br />
                    EDV:<input type="text" id="LBulbEDVInputText" class="input_bdrbot" style="width: 60px;"
                        onkeydown="return KeyPress_DecimalAllowedOnly_withsigns(event);" />cm/sec
                </span>
            </div>
            <div class="left">
                <label class="carotidreading-label">
                    <strong>R EXT CAROTID ART:</strong></label>
                <span class="carotidgboxtxt">PSV:<input type="text" id="RExtCarotidArtPSVInputText" class="input_bdrbot"
                    style="width: 60px;" onkeydown="return KeyPress_DecimalAllowedOnly_withsigns(event);" />cm/sec<br />
                </span>
            </div>
            <div class="left">
                <label class="carotidreading-label">
                    <strong>L EXT CAROTID ART:</strong></label>
                <span class="carotidgboxtxt">PSV:<input type="text" id="LExtCarotidArtPSVInputText" class="input_bdrbot"
                    style="width: 60px;" onkeydown="return KeyPress_DecimalAllowedOnly_withsigns(event);" />cm/sec<br />
                </span>
            </div>
            <div class="left">
                <label class="carotidreading-label">
                    <strong>R ICA PROXIMAL:</strong></label>
                <span class="carotidgboxtxt">PSV:<input type="text" id="RICAProximalPSVInputText" class="input_bdrbot"
                    style="width: 60px;" onkeydown="return KeyPress_DecimalAllowedOnly_withsigns(event);" />cm/sec<br />
                    EDV:<input type="text" id="RICAProximalEDVInputText" class="input_bdrbot" style="width: 60px;"
                        onkeydown="return KeyPress_DecimalAllowedOnly_withsigns(event);" />cm/sec
                </span>
            </div>
            <div class="left">
                <label class="carotidreading-label">
                    <strong>L ICA PROXIMAL:</strong></label>
                <span class="carotidgboxtxt">PSV:<input type="text" id="LICAProximalPSVInputText" class="input_bdrbot"
                    style="width: 60px;" onkeydown="return KeyPress_DecimalAllowedOnly_withsigns(event);" />cm/sec<br />
                    EDV:<input type="text" id="LICAProximalEDVInputText" class="input_bdrbot" style="width: 60px;"
                        onkeydown="return KeyPress_DecimalAllowedOnly_withsigns(event);" />cm/sec
                </span>
            </div>
            <div class="left">
                <label class="carotidreading-label">
                    <strong>R ICA DISTAL:</strong></label>
                <span class="carotidgboxtxt">PSV:<input type="text" id="RICADistalPSVInputText" class="input_bdrbot"
                    style="width: 60px;" onkeydown="return KeyPress_DecimalAllowedOnly_withsigns(event);" />cm/sec<br />
                    EDV:<input type="text" id="RICADistalEDVInputText" class="input_bdrbot" style="width: 60px;"
                        onkeydown="return KeyPress_DecimalAllowedOnly_withsigns(event);" />cm/sec
                </span>
            </div>
            <div class="left">
                <label class="carotidreading-label">
                    <strong>L ICA DISTAL:</strong></label>
                <span class="carotidgboxtxt">PSV:<input type="text" id="LICADistalPSVInputText" class="input_bdrbot"
                    style="width: 60px;" onkeydown="return KeyPress_DecimalAllowedOnly_withsigns(event);" />cm/sec<br />
                    EDV:<input type="text" id="LICADistalEDVInputText" class="input_bdrbot" style="width: 60px;"
                        onkeydown="return KeyPress_DecimalAllowedOnly_withsigns(event);" />cm/sec
                </span>
            </div>
            <div class="left">
                <label class="carotidreading-label">
                    <strong>R VERTEBRAL ART:</strong></label>
                <span class="carotidgboxtxt">PSV:<input type="text" id="RVertebralArtPSVInputText" class="input_bdrbot"
                    style="width: 60px;" onkeydown="return KeyPress_DecimalAllowedOnly_withsigns(event);" />cm/sec<br />
                    EDV:<input type="text" id="RVertebralArtEDVInputText" class="input_bdrbot" style="width: 60px;"
                        onkeydown="return KeyPress_DecimalAllowedOnly_withsigns(event);" />cm/sec
                </span>
            </div>
            <div class="left">
                <label class="carotidreading-label">
                    <strong>L VERTEBRAL ART:</strong></label>
                <span class="carotidgboxtxt">PSV:<input type="text" id="LVertebralArtPSVInputText" class="input_bdrbot"
                    style="width: 60px;" onkeydown="return KeyPress_DecimalAllowedOnly_withsigns(event);" />cm/sec<br />
                    EDV:<input type="text" id="LVertebralArtEDVInputText" class="input_bdrbot" style="width: 60px;"
                        onkeydown="return KeyPress_DecimalAllowedOnly_withsigns(event);" />cm/sec
                </span>
            </div>
            <div class="exclude-hide-evaluation left">
                <input type="checkbox" id="LowVelocityRICAProximalCheckbox" />
                <span id="LowVelocityRICALabel" runat="server"></span>
                <input type="hidden" id="LowVelocityRICAIdProximalHiddenfield" runat="server" value="0" />
            </div>
            <div class="exclude-hide-evaluation right">
                <input type="checkbox" id="LowVelocityLICAProximalCheckbox" />
                <span id="LowVelocityLICALabel" runat="server"></span>
                <input type="hidden" id="LowVelocityLICAIdProximalHiddenfield" runat="server" value="0" />
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
        <asp:DataList runat="server" ID="IncidentalFindingsAwvCarotidSelectedDataList" CssClass="dtl-stroke-if incidental-finding-dtl"
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
    <a href="javascript:OpenPopUp('Upload Media', '710', '/app/franchisee/technician/uploadTestImages.aspx?TestType=<%= (int)TestType.AwvCarotid %>&CustomerId=' + customerId);">Upload Media</a>
</div>
<div id="AwvCarotidImageListDiv" class="contentrow media-container-div">
</div>
<div class="physician-section" style="float: left; width: 100%; clear: both; margin-top: 5px;">
    <fieldset style="float: left; width: 98%; border-radius: 4px;">
        <legend>Remarks </legend>
        <div style="float: left; width: 40%;">
            <input type="checkbox" id="technicallyltdbutreadableAwvCarotidinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Technically limited</b><br />
            <input type="checkbox" id="repeatstudyAwvCarotidinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Repeat Study/Unreadable</b><br />
            <input type="checkbox" id="criticalAwvCarotid" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b><br />
        </div>
        <div style="float: left; width: 58%;">
            <textarea id="physicianRemarksAwvCarotid" rows="3" style="width: 98%;"></textarea>
        </div>
    </fieldset>
</div>
    </div>

<div id="awvCarotid_chat" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 50%;">
            <span class="org-heading" style="width: 100%;"><strong>Stroke / Carotid Artery Disease Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyAwvCarotid" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="awvCarotid-retest-span">
            <input type="checkbox" id="Retest_56" />Retest
        </span>
    </div>
    <div class="hrows awvCarotid-verificationpanel" style="color: Red; background: #fff0a5; border: solid 1px fff0a5; padding: 2px 2px 2px 5px; display: none;">
    </div>
     <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
             
     <div class="hlfbox">
           <div class="hrows">
             <div class="nrow" style="margin-left:12px;">
                  <input type="checkbox" id="chk_awvCarotidcapturebyChat" />
                   <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
     </div>
             
     </div>
</div>

<script language="javascript" type="text/javascript">
    var testTypeAwvCarotid = '<%= (long)TestType.AwvCarotid %>';
    var IsawvCarotidResultEntryExternaly = '<%= IsResultEntrybyChat %>';
    var awvCarotid = null;
    function SetAwvCarotidData(testResult) {
        awvCarotid = new AwvCarotid(testResult);
        awvCarotid.setData();
    }

    function GetAwvCarotidData() {
        if (awvCarotid == null) awvCarotid = new AwvCarotid();
        return awvCarotid.getData();
    }

</script>
