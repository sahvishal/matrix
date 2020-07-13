<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AwvLipid.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.AwvLipid" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>

<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/AwvLipid.js?q=<%= VersionNumber %>"></script>
<style type="text/css">
    .dob_pop {
        width: 302px;
        padding: 10px;
        background-color: #f5f5f5;
    }

    .dob_popin {
        width: 278px;
        padding: 10px;
    }

    .dob_popinmain {
        float: left;
        width: 100%;
        margin-top: 5px;
    }

        .dob_popinmain label {
            font-weight: bold;
            padding-top: 20px;
        }

        .dob_popinmain .inpt {
            border: 1px solid #7F9DB9;
            background-color: #fff;
            z-index: -5;
            font: normal 12px arial;
            color: #333;
            padding: 2px;
            margin-right: 20px;
        }

    .btnrgt {
        float: right;
        padding-right: 5px;
    }

    .input-small {
        border-bottom: 1px solid #535353;
        border-left: 0px;
        background-color: transparent;
        border-right: 0px;
        border-top: 0px;
        width: 40px;
        font-size: 10px;
        color: #666666;
        padding-left: 5px;
    }

    .lnkred {
        color: red;
        text-decoration: none;
    }

        .lnkred a:link {
            color: red;
            text-decoration: underline;
        }

        .lnkred a:visited {
            color: red;
            text-decoration: underline;
        }

        .lnkred a:hover {
            color: red;
            text-decoration: underline;
        }
</style>
<div id="AwvLipid_hip" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 120px">
            <span class="org-heading" style="width: 120px"><strong>Lipid Panel Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyAwvLipid" class="conductedby-ddl">
            </select>
        </span><span class="chk_orngband" id="AwvLipid-critical-span">
            <input type="checkbox" id="SelfPresentAwvLipidInputCheck" onclick="onClick_CriticalDataAwvLipid();" />Critical</span>
        <span class="chk_orngband" id="awvLipid-priorityInQueue-span">
            <input type="checkbox" id="PriorityInQueueTestAwvLipidCheck" onclick="onClick_PriorityInQueueDataAwvLipid();" />Priority In Queue
        </span>
        <span class="chk_orngband" id="awvLipid-retest-span">
            <input type="checkbox" id="Retest_57" />Retest
        </span>
    </div>
    <div class="hrows lipid-verificationpanel" style="color: Red; background: #fff0a5; border: solid 1px fff0a5; padding: 2px 2px 2px 5px; display: none;">
    </div>
    <div class="hlfbox">
        <div class="hrows" style="height: 130px;">
            <div class="qtrbox small">
                <div class="nrow">
                    TOTAL CHOLESTEROL =
                    <input type="text" id="TotalCholestrolAwvLipidInputText" class="input_bdrbot" onchange="onChangeAwvLipidTotalCholestrol(this);"
                        style="width: 60px" onkeydown="return KeyPress_NumericAllowedOnly_ForAwvLipid(event);" />
                </div>
                <div class="nrow finding">
                    <asp:GridView runat="server" ID="AwvLipidTotalCholestrolFindingGridView" CssClass="tc-AwvLipid-finding finding-section clear-all-AwvLipid-selection"
                        EnableViewState="false" ShowHeader="false" GridLines="None" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <input type="radio" name="rbtTCAwvLipid" class="rbt-finding" />
                                    <input type="hidden" id="TCFindingLipidInputHidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                                    <input type="hidden" class="finding-minvalue" value='<%# DataBinder.Eval(Container.DataItem, "MinValue")%>' />
                                    <input type="hidden" class="finding-maxvalue" value='<%# DataBinder.Eval(Container.DataItem, "MaxValue")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%# DataBinder.Eval(Container.DataItem, "Label") %>
                                    <%# DataBinder.Eval(Container.DataItem, "Description") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="qtrbox small">
                <div class="nrow">
                    LDL =<input type="text" id="LDLAwvLipidInputText" class="input_bdrbot" onchange="onChangeLdlAwvLipid(this);"
                        style="width: 60px" onkeydown="return KeyPress_NumericAllowedOnly(event);" />
                </div>
                <div class="nrow finding">
                    <asp:GridView runat="server" ID="LDLAwvLipidFindingGridView" CssClass="ldl-AwvLipid-finding finding-section clear-all-AwvLipid-selection"
                        EnableViewState="false" ShowHeader="false" GridLines="None" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <input type="radio" name="rbtLdlAwvLipid" class="rbt-finding" />
                                    <input type="hidden" id="LDLFindingInputHidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                                    <input type="hidden" class="finding-minvalue" value='<%# DataBinder.Eval(Container.DataItem, "MinValue")%>' />
                                    <input type="hidden" class="finding-maxvalue" value='<%# DataBinder.Eval(Container.DataItem, "MaxValue")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%# DataBinder.Eval(Container.DataItem, "Label")%>
                                    <%# DataBinder.Eval(Container.DataItem, "Description")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div class="hrows" style="height: 130px;">
            <div class="qtrbox small">
                <div class="nrow">
                    HDL =
                    <input type="text" id="HDLAwvLipidInputText" class="input_bdrbot" onchange="onChangeAwvLipidHDL(this);"
                        style="width: 100px" onkeydown="return KeyPress_NumericAllowedOnly_ForAwvLipid(event);" />
                </div>
                <div class="nrow finding">
                    <asp:GridView runat="server" ID="HDLAwvLipidFindingGridView" CssClass="hdl-AwvLipid-finding finding-section clear-all-AwvLipid-selection"
                        EnableViewState="false" ShowHeader="false" GridLines="None" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <input type="radio" name="rbtHdlAwvLipid" class="rbt-finding" />
                                    <input type="hidden" id="HDLFindingInputHidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                                    <input type="hidden" class="finding-minvalue" value='<%# DataBinder.Eval(Container.DataItem, "MinValue")%>' />
                                    <input type="hidden" class="finding-maxvalue" value='<%# DataBinder.Eval(Container.DataItem, "MaxValue")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%# DataBinder.Eval(Container.DataItem, "Label")%>&nbsp;
                                    <%# DataBinder.Eval(Container.DataItem, "Description")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <div class="hlfbox">
        <div class="hrows" style="height: 130px;">
            <div class="qtrbox small">
                <div class="nrow">
                    TRIGLYCERIDES =
                    <input type="text" id="TriglyceridesAwvLipidInputText" class="input_bdrbot" onchange="onChangeAwvLipidTriglycerides(this);"
                        style="width: 100px" onkeydown="return KeyPress_NumericAllowedOnly_ForAwvLipid(event);" />
                </div>
                <div class="nrow finding">
                    <asp:GridView runat="server" ID="TriglyceridesAwvLipidFindingGridView" ShowHeader="false"
                        EnableViewState="false" CssClass="triglycerides-AwvLipid-finding finding-section clear-all-AwvLipid-selection" GridLines="None"
                        AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <input type="radio" name="rbtTgAwvLipid" class="rbt-finding" />
                                    <input type="hidden" id="TriglyceridesFindingInputHidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                                    <input type="hidden" class="finding-minvalue" value='<%# DataBinder.Eval(Container.DataItem, "MinValue")%>' />
                                    <input type="hidden" class="finding-maxvalue" value='<%# DataBinder.Eval(Container.DataItem, "MaxValue")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%# DataBinder.Eval(Container.DataItem, "Label")%>
                                    <%# DataBinder.Eval(Container.DataItem, "Description")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="qtrbox small">
                <div class="nrow">
                    TC/HDL RATIO =
                    <input type="text" id="TCHDLRatioAwvLipidInputText" class="input_bdrbot" onblur="autoSelectFinding($('.tchdlratio-AwvLipid-finding'), $(this), 1);"
                        style="width: 100px" onkeydown="return KeyPress_DecimalAllowedOnly(event);" />
                </div>
                <div class="nrow finding">
                    <asp:GridView runat="server" ID="TCHDLRatioAwvLipidFindingGridView" CssClass="tchdlratio-AwvLipid-finding finding-section clear-all-AwvLipid-selection"
                        EnableViewState="false" ShowHeader="false" GridLines="None" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <input type="radio" name="rbtTchdlAwvLipid" class="rbt-finding" />
                                    <input type="hidden" id="TCHDLRatioFindingInputHidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                                    <input type="hidden" class="finding-minvalue" value='<%# DataBinder.Eval(Container.DataItem, "MinValue")%>' />
                                    <input type="hidden" class="finding-maxvalue" value='<%# DataBinder.Eval(Container.DataItem, "MaxValue")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%# DataBinder.Eval(Container.DataItem, "Label")%>
                                    <%# DataBinder.Eval(Container.DataItem, "Description")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <div class="hlfbox" style="clear: both; padding: 3px 0">
        <i>Note: HDL range differs for Male/Female. </i>
    </div>
    <div class="hlfbox" style="clear: both; padding: 3px 0">
        <asp:DataList runat="server" ID="UnableToScreenAwvLipidDataList" CssClass="dtl-unable-to-screen-AwvLipid unable-to-screen-section"
            EnableViewState="false" GridLines="None" RepeatDirection="Horizontal" RepeatLayout="Flow">
            <ItemTemplate>
                <input type="checkbox" id="chkUnableScreenReason" />
                <b>Unable To Screen</b>&nbsp;(<%# DataBinder.Eval(Container.DataItem, "DisplayName")%>)
                <input type="hidden" id="hfUnableScreenReasonID" value='<%# Convert.ToString((int)DataBinder.Eval(Container.DataItem, "Reason")) %>' />
            </ItemTemplate>
        </asp:DataList>
        <div class="lrow clear-all-selection">
            <a style="margin-left: 5px;" id="clear-all-lipid" href="javascript:void(0);" onclick="clearAllAwvLipidSelection();">Clear All Selection</a>
        </div>
    </div>
    <div class="hlfbox" style="padding: 3px 0">
        <div class="rrow">
            <b>Technician Notes </b>
            <br />
            <textarea id="technotesAwvLipid" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
                rows="2" cols="54"></textarea>
        </div>
        <div class="rrow test-not-performed-section" id="testnotPerformedAwvLipid">
            <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0" />
            <b>Test Not Performed</b>
            <div class="test-not-performed-container" style="display: none">
                <b>Reason : </b>
                <br />
                <asp:DropDownList ID="ddlTestNotPerformedReasonAwvLipid" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
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
                <input type="checkbox" id="criticalAwvLipid" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b>
            </div>
            <div style="float: left; width: 58%;">
                <textarea id="physicianRemarksAwvLipid" rows="3" style="width: 98%;"></textarea>
            </div>
        </fieldset>
    </div>
</div>



<div id="AwvLipid_chat" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 50%;">
            <span class="org-heading" style="width: 100%;"><strong>Lipid Panel Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyAwvLipid" class="conductedby-ddl">
            </select>
        </span>
          <span class="chk_orngband" id="AwvLipid-critical-span">
            <input type="checkbox" id="SelfPresentAwvLipidInputCheck" onclick="onClick_CriticalDataAwvLipid();" />Critical</span>

        <span class="chk_orngband" id="awvLipid-retest-span">
            <input type="checkbox" id="Retest_57" />Retest
        </span>
      
    </div>
    <div class="contentrow" style="width: 99%; padding-left: 0px;">
        <div class="hlfbox">
            <div class="nrow" style="margin-left: 12px;">
                <input type="checkbox" id="chk_awvLipidcapturebyChat" />
                <b>Result Entry Completed in CHAT </b>
            </div>
        </div>
        <div style="float: left; clear: none; padding-top: 0" class="test-not-performed-section" id="testnotPerformedAwvLipid">
            <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0" />
            <b>Test Not Performed</b>
            <div class="test-not-performed-container" style="display: none">
                <b>Reason : </b>
                <br />
                <asp:DropDownList ID="ddlTestNotPerformedReasonAwvLipid_Chat" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
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
</div>


<script language="javascript" type="text/javascript">
    var testTypeAwvLipid = '<%= (long)TestType.AwvLipid %>';
    var IsawvLipidResultEntryExternaly = '<%= IsResultEntrybyChat %>';
    var awvLipid = null;
    function SetAwvLipidData(testResult) {
        awvLipid = new AwvLipid(testResult);
        awvLipid.setData();
    }

    function GetAwvLipidData() {
        if (awvLipid == null) awvLipid = new AwvLipid();
        return awvLipid.getData();
    }

    function checkAwvLipidTotalCholesterolMinMaxValue(tcValue) {
        if ('<%= RoleId %>' == '<%= (long)Falcon.App.Core.Enum.Roles.Technician%>' || '<%= RoleId %>' == '<%= (long)Falcon.App.Core.Enum.Roles.NursePractitioner%>') {
            checkTotalCholesterolOutsidePossibleRange(tcValue);
        }
    }
    function checkAwvLipidHDLMinMaxValue(hdlValue) {
        if ('<%= RoleId %>' == '<%= (long)Falcon.App.Core.Enum.Roles.Technician%>' || '<%= RoleId %>' == '<%= (long)Falcon.App.Core.Enum.Roles.NursePractitioner%>') {
            checkHDLOutsidePossibleRange(hdlValue);
        }
    }
    function checkAwvLipidLDLMinMaxValue(ldlValue) {
        if ('<%= RoleId %>' == '<%= (long)Falcon.App.Core.Enum.Roles.Technician%>' || '<%= RoleId %>' == '<%= (long)Falcon.App.Core.Enum.Roles.NursePractitioner%>') {
            checkLdlOutsidePossibleRange(ldlValue);
        }
    }
    function checkAwvLipidTriglyceridesMinMaxValue(tgValue) {
        if ('<%= RoleId %>' == '<%= (long)Falcon.App.Core.Enum.Roles.Technician%>' || '<%= RoleId %>' == '<%= (long)Falcon.App.Core.Enum.Roles.NursePractitioner%>') {
            checkTriglyceridesOutsidePossibleRange(tgValue);
        }
    }


</script>
