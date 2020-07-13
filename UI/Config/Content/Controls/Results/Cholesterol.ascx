<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Cholesterol.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.Cholesterol" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>

<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/Cholesterol.js?q=<%= VersionNumber %>"></script>
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
<div id="Cholesterol_hip" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 120px">
            <span class="org-heading" style="width: 170px"><strong>Cholesterol Results </strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyCholesterol" class="conductedby-ddl">
            </select>
        </span><span class="chk_orngband" id="Cholesterol-critical-span">
            <input type="checkbox" id="SelfPresentCholesterolInputCheck" onclick="onClick_CriticalDataCholesterol();" />Critical</span>
        <span class="chk_orngband" id="cholesterol-priorityInQueue-span">
            <input type="checkbox" id="PriorityInQueueTestCholesterolCheck" onclick="onClick_PriorityInQueueDataCholesterol();" />Priority In Queue
        </span>
        <span class="chk_orngband" id="cholesterol-retest-span">
            <input type="checkbox" id="Retest_61" />Retest
        </span>
    </div>
    <div class="hrows lipid-verificationpanel" style="color: Red; background: #fff0a5; border: solid 1px fff0a5; padding: 2px 2px 2px 5px; display: none;">
    </div>
    <div class="hlfbox">
        <div class="hrows" style="height: 110px;">
            <div class="qtrbox small">
                <div class="nrow">
                    TOTAL CHOLESTEROL =
                    <input type="text" id="TotalCholesterolCholesterolInputText" class="input_bdrbot" onchange="onChangeCholesterolTotalCholesterol(this);"
                        style="width: 60px" onkeydown="return KeyPress_NumericAllowedOnly_ForCholesterol(event);" />
                </div>
                <div class="nrow finding">
                    <asp:GridView runat="server" ID="CholesterolTotalCholesterolFindingGridView" CssClass="tc-Cholesterol-finding finding-section clear-all-Cholesterol-selection"
                        EnableViewState="false" ShowHeader="false" GridLines="None" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <input type="radio" name="rbtTCCholesterol" class="rbt-finding" />
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
                    LDL =<input type="text" id="LDLCholesterolInputText" class="input_bdrbot" onchange="onChangeCholesterolLdl(this)"
                        style="width: 60px" onkeydown="return KeyPress_NumericAllowedOnly(event);" />
                </div>
                <div class="nrow finding">
                    <asp:GridView runat="server" ID="LDLCholesterolFindingGridView" CssClass="ldl-Cholesterol-finding finding-section clear-all-Cholesterol-selection"
                        EnableViewState="false" ShowHeader="false" GridLines="None" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <input type="radio" name="rbtLdlCholesterol" class="rbt-finding" />
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
        <div class="hrows" style="height: 110px;">
            <div class="qtrbox small">
                <div class="nrow">
                    HDL =
                    <input type="text" id="HDLCholesterolInputText" class="input_bdrbot" onchange="onChangeCholesterolHDL(this);"
                        style="width: 100px" onkeydown="return KeyPress_NumericAllowedOnly_ForCholesterol(event);" />
                </div>
                <div class="nrow finding">
                    <asp:GridView runat="server" ID="HDLCholesterolFindingGridView" CssClass="hdl-Cholesterol-finding finding-section clear-all-Cholesterol-selection"
                        EnableViewState="false" ShowHeader="false" GridLines="None" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <input type="radio" name="rbtHdlCholesterol" class="rbt-finding" />
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
        <div class="hrows" style="height: 110px;">
            <div class="qtrbox small">
                <div class="nrow">
                    TRIGLYCERIDES =
                    <input type="text" id="TriglyceridesCholesterolInputText" class="input_bdrbot" onchange="onChangeCholesterolTriglycerides(this);"
                        style="width: 100px" onkeydown="return KeyPress_NumericAllowedOnly_ForCholesterol(event);" />
                </div>
                <div class="nrow finding">
                    <asp:GridView runat="server" ID="TriglyceridesCholesterolFindingGridView" ShowHeader="false"
                        EnableViewState="false" CssClass="triglycerides-Cholesterol-finding finding-section clear-all-Cholesterol-selection" GridLines="None"
                        AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <input type="radio" name="rbtTgCholesterol" class="rbt-finding" />
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
                    <input type="text" id="TCHDLRatioCholesterolInputText" class="input_bdrbot" onblur="autoSelectFinding($('.tchdlratio-Cholesterol-finding'), $(this), 1);"
                        style="width: 100px" onkeydown="return KeyPress_DecimalAllowedOnly(event);" />
                </div>
                <div class="nrow finding">
                    <asp:GridView runat="server" ID="TCHDLRatioCholesterolFindingGridView" CssClass="tchdlratio-Cholesterol-finding finding-section clear-all-Cholesterol-selection"
                        EnableViewState="false" ShowHeader="false" GridLines="None" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <input type="radio" name="rbtTchdlCholesterol" class="rbt-finding" />
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
        <asp:DataList runat="server" ID="UnableToScreenCholesterolDataList" CssClass="dtl-unable-to-screen-Cholesterol unable-to-screen-section"
            EnableViewState="false" GridLines="None" RepeatDirection="Horizontal" RepeatLayout="Flow">
            <ItemTemplate>
                <input type="checkbox" id="chkUnableScreenReason" />
                <b>Unable To Screen</b>&nbsp;(<%# DataBinder.Eval(Container.DataItem, "DisplayName")%>)
                <input type="hidden" id="hfUnableScreenReasonID" value='<%# Convert.ToString((int)DataBinder.Eval(Container.DataItem, "Reason")) %>' />
            </ItemTemplate>
        </asp:DataList>
        <div class="lrow clear-all-selection">
            <a style="margin-left: 5px;" id="clear-all-Cholesterol" href="javascript:void(0);" onclick="clearAllCholesterolSelection();">Clear All Selection</a>
        </div>
    </div>
    <div class="hlfbox" style="padding: 3px 0">
        <b>Technician Notes </b>
        <br />
        <textarea id="technotesCholesterol" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
            rows="2" cols="54"></textarea>
    </div>
    <div class="physician-section" style="float: left; width: 100%; clear: both; margin-top: 5px;">
    <fieldset style="float: left; width: 98%; border-radius: 4px;">
        <legend>Remarks </legend>
        <div style="float: left; width: 40%;">
            <input type="checkbox" id="criticalCholesterol" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b>
        </div>
        <div style="float: left; width: 58%;">
            <textarea id="physicianRemarksCholesterol" rows="3" style="width: 98%;"></textarea>
        </div>
    </fieldset>
</div>
</div>


<div id="Cholesterol_chat" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 50%;">
            <span class="org-heading" style="width: 100%;"><strong>Cholesterol Results </strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyCholesterol" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="cholesterol-retest-span">
            <input type="checkbox" id="Retest_61" />Retest
        </span>
    </div>
    <div class="hrows cholesterol-verificationpanel" style="color: Red; background: #fff0a5; border: solid 1px fff0a5; padding: 2px 2px 2px 5px; display: none;">
    </div>
     <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
             
     <div class="hlfbox">
           <div class="hrows">
             <div class="nrow" style="margin-left:12px;">
                  <input type="checkbox" id="chk_cholesterolcapturebyChat" />
                   <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
     </div>
             
     </div>
</div>

<script language="javascript" type="text/javascript">
    var testTypeCholesterol = '<%= (long)TestType.Cholesterol %>';
    var IscholesterolResultEntryExternaly = '<%= IsResultEntrybyChat %>';
    var cholesterol = null;
    function SetCholesterolData(testResult) {
        cholesterol = new Cholesterol(testResult);
        cholesterol.setData();
    }

    function GetCholesterolData() {
        if (cholesterol == null) cholesterol = new Cholesterol();
        return cholesterol.getData();
    }


    function checkCholesterolTotalCholesterolMinMaxValue(tcValue) {
        if ('<%= RoleId %>' == '<%= (long)Falcon.App.Core.Enum.Roles.Technician%>') {
            checkTotalCholesterolOutsidePossibleRange(tcValue);
        }
    }
    function checkCholesterolHDLMinMaxValue(hdlValue) {
        if ('<%= RoleId %>' == '<%= (long)Falcon.App.Core.Enum.Roles.Technician%>') {
            checkHDLOutsidePossibleRange(hdlValue);
        }
    }
    function checkCholesterolLDLMinMaxValue(ldlValue) {
        if ('<%= RoleId %>' == '<%= (long)Falcon.App.Core.Enum.Roles.Technician%>') {
            checkLdlOutsidePossibleRange(ldlValue);
        }
    }
    function checkCholesterolTriglyceridesMinMaxValue(tgValue) {
        if ('<%= RoleId %>' == '<%= (long)Falcon.App.Core.Enum.Roles.Technician%>') {
            checkTriglyceridesOutsidePossibleRange(tgValue);
        }
    }

</script>
