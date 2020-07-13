<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyBioCheckAssessment.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.MyBioCheckAssessment" %>
<%@ Import Namespace="Falcon.App.Core.Application.Domain" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>

<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/MyBioCheckAssessment.js?q=<%= VersionNumber %>"></script>
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
<div id="mybiocheck_hip" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server" >
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 239px;">
            <span class="org-heading" style="width: 239px;"><strong>My Bio-Check Assessment Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbymyBioCheckAssessment" class="conductedby-ddl">
            </select>
        </span><span class="chk_orngband" id="myBioCheckAssessment-critical-span">
            <input type="checkbox" id="SelfPresentMyBioCheckAssessmentInputCheck" onclick="onClick_CriticalDataMyBioCheckAssessment();" />Critical</span>
        <span class="chk_orngband" id="myBioCheckAssessment-priorityInQueue-span">
            <input type="checkbox" id="PriorityInQueueTestMyBioCheckAssessmentCheck" onclick="onClick_PriorityInQueueDataMyBioCheckAssessment();" />Priority In Queue
        </span>
        <span class="chk_orngband" id="myBioCheckAssessment-retest-span">
            <input type="checkbox" id="Retest_99" />Retest
        </span>
    </div>
    <div class="hrows myBioCheckAssessment-verificationpanel" style="color: Red; background: #fff0a5; border: solid 1px fff0a5; padding: 2px 2px 2px 5px; display: none;">
    </div>
    <div class="hlfbox">
        <div class="hrows" style="height: 130px;">
            <div class="qtrbox small">
                <div class="nrow">
                    TOTAL CHOLESTEROL =
                    <input type="text" id="TotalCholestrolMyBioCheckAssessmentInputText" class="input_bdrbot" onchange="onChangeTotalCholestrol(this);"
                        style="width: 60px" onkeydown="return KeyPress_NumericAllowedOnly_ForMyBioCheckAssessment(event);" />
                </div>
                <div class="nrow finding">
                    <asp:GridView runat="server" ID="MyBioCheckTotalCholestrolFindingGridView" CssClass="tc-myBioCheckAssessment-finding finding-section clear-all-myBioCheckAssessment-selection"
                        EnableViewState="false" ShowHeader="false" GridLines="None" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <input type="radio" name="rbtTCMyBioCheck" class="rbt-finding" />
                                    <input type="hidden" id="TCFindingMyBioCheckAssessmentInputHidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
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
                    LDL =<input type="text" id="LDLMyBioCheckAssessmentInputText" class="input_bdrbot" onchange="onChangeLdlMyBioCheckAssessment(this);"
                        style="width: 60px" onkeydown="return KeyPress_NumericAllowedOnly(event);" />
                </div>
                <div class="nrow finding">
                    <asp:GridView runat="server" ID="LDLMyBioCheckFindingGridView" CssClass="ldl-myBioCheckAssessment-finding finding-section clear-all-myBioCheckAssessment-selection"
                        EnableViewState="false" ShowHeader="false" GridLines="None" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <input type="radio" name="rbtLdlMyBioCheck" class="rbt-finding" />
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
                    <input type="text" id="HDLMyBioCheckAssessmentInputText" class="input_bdrbot" onchange="onChangeHDL(this);"
                        style="width: 100px" onkeydown="return KeyPress_NumericAllowedOnly_ForMyBioCheckAssessment(event);" />
                </div>
                <div class="nrow finding">
                    <asp:GridView runat="server" ID="HDLMyBioCheckFindingGridView" CssClass="hdl-myBioCheckAssessment-finding finding-section clear-all-myBioCheckAssessment-selection"
                        EnableViewState="false" ShowHeader="false" GridLines="None" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <input type="radio" name="rbtMyBioCheckHdl" class="rbt-finding" />
                                    <input type="hidden" id="HDLMyBioCheckFindingInputHidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
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
            <div class="qtrbox small">
                <div class="nrow">
                    TC/HDL RATIO =
                    <input type="text" id="TCHDLRatioMyBioCheckAssessmentInputText" class="input_bdrbot" onblur="autoSelectFinding($('.tchdlratio-myBioCheckAssessment-finding'), $(this), 1);"
                        style="width: 100px" onkeydown="return KeyPress_DecimalAllowedOnly(event);" />
                </div>
                <div class="nrow finding">
                    <asp:GridView runat="server" ID="TCHDLRatioMyBioCheckFindingGridView" CssClass="tchdlratio-myBioCheckAssessment-finding finding-section clear-all-myBioCheckAssessment-selection"
                        EnableViewState="false" ShowHeader="false" GridLines="None" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <input type="radio" name="rbtMyBioCheckTchdl" class="rbt-finding" />
                                    <input type="hidden" id="TCHDLRatioMyBioCheckFindingInputHidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
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
    <div class="hlfbox">
        <div class="hrows" style="height: 110px;">
            <div class="qtrbox small">
                <div class="nrow">
                    GLUCOSE (Blood Sugar) =
                    <input type="text" id="GlucoseMyBioCheckAssessmentInputText" class="input_bdrbot" onblur="autoSelectFinding($('.glucose-myBioCheckAssessment-finding'), $(this), 1);"
                        style="width: 60px" onkeydown="return KeyPress_NumericAllowedOnly(event);" />
                </div>
                <div class="nrow finding">
                    <asp:GridView runat="server" ID="GlucoseMyBioCheckFindingGridView" ShowHeader="false" CssClass="glucose-myBioCheckAssessment-finding finding-section clear-all-myBioCheckAssessment-selection"
                        EnableViewState="false" GridLines="None" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <input type="radio" name="rbtGlucoseMyBioCheck" class="rbt-finding" />
                                    <input type="hidden" id="GlucoseMyBioCheckFindingInputHidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
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
                    TRIGLYCERIDES =
                    <input type="text" id="TriglyceridesMyBioCheckAssessmentInputText" class="input_bdrbot" onchange="onChangeTriglycerides(this);"
                        style="width: 100px" onkeydown="return KeyPress_NumericAllowedOnly_ForMyBioCheckAssessment(event);" />
                </div>
                <div class="nrow finding">
                    <asp:GridView runat="server" ID="TriglyceridesMyBioCheckFindingGridView" ShowHeader="false"
                        EnableViewState="false" CssClass="triglycerides-myBioCheckAssessment-finding finding-section clear-all-myBioCheckAssessment-selection" GridLines="None"
                        AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <input type="radio" name="rbtTgMyBioCheck" class="rbt-finding" />
                                    <input type="hidden" id="TriglyceridesMyBioCheckFindingInputHidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
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
        <div class="rrow" style="clear: both; float: left; padding-bottom: 10px;">
            <div style="width: 150px; text-align: center;">
                <span class="left" style="width: 100%">
                    <img style="float: left;" class="uploadMyBioCheckPDF" alt="" src="/Content/Images/PageNotFound-Icons.jpg" /><br />
                </span>
                <span class="left upload-media-section" style="width: 100%; text-align: left;">
                    <a href="javascript:void(0);" class="pdf-myBioCheck-remove" style="display: none; padding-left: 30px;">Remove </a>&nbsp;
                <a class="pdf-myBioCheck-upload" href="javascript:OpenPopUp('Upload PDF', '330', '/app/franchisee/technician/UploadAwvTestResultFile.aspx?TestType=<%= (long)TestType.MyBioCheckAssessment %>&height=110', 200);">Upload PDF </a>
                </span>
            </div>
        </div>
        <div class="rrow" style="clear: both; float: left;">
            <asp:DataList runat="server" ID="UnableToScreenMyBioCheckAssessmentDataList" CssClass="dtl-unable-to-screen-myBioCheckAssessment unable-to-screen-section"
                EnableViewState="false" GridLines="None" RepeatDirection="Horizontal" RepeatLayout="Flow">
                <ItemTemplate>
                    <input type="checkbox" id="chkUnableScreenReason" />
                    <b>Unable To Screen</b>&nbsp;(<%# DataBinder.Eval(Container.DataItem, "DisplayName")%>)
                <input type="hidden" id="hfUnableScreenReasonID" value='<%# Convert.ToString((int)DataBinder.Eval(Container.DataItem, "Reason")) %>' />
                </ItemTemplate>
            </asp:DataList>
            <div class="lrow clear-all-selection">
                <a style="margin-left: 5px;" id="clear-all-myBioCheckAssessment" href="javascript:void(0);" onclick="clearAllMyBioCheckAssessmentSelection();">Clear All Selection</a>
            </div>
        </div>
    </div>
    <div class="hlfbox" style="padding: 3px 0">
        <div class="rrow">
            <b>Technician Notes </b>
            <br />
            <textarea id="technotesmyBioCheckAssessment" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
                rows="2" cols="54"></textarea>
        </div>
        <div class="rrow test-not-performed-section" id="testnotPerformedMyBioCheckAssessment">
            <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0" />
            <b>Test Not Performed</b>
            <div class="test-not-performed-container" style="display: none">
                <b>Reason : </b>
                <br />
                <asp:DropDownList ID="ddlTestNotPerformedReasonMyBioCheckAssessment" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
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
            <input type="checkbox" id="criticalMyBioCheckAssessment" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b>
        </div>
        <div style="float: left; width: 58%;">
            <textarea id="physicianRemarksMyBioCheckAssessment" rows="3" style="width: 98%;"></textarea>
        </div>
    </fieldset>
</div>

</div>

<div id="mybiocheck_chat" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server" >
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 50%;">
            <span class="org-heading" style="width: 100%;"><strong>My Bio-Check Assessment Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbymyBioCheckAssessment" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="myBioCheckAssessment-retest-span">
            <input type="checkbox" id="Retest_99" />Retest
        </span>
    </div>
    <div class="hrows myBioCheckAssessment-verificationpanel" style="color: Red; background: #fff0a5; border: solid 1px fff0a5; padding: 2px 2px 2px 5px; display: none;">
    </div>
     <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
             
     <div class="hlfbox">
           <div class="hrows">
             <div class="nrow" style="margin-left:12px;">
                  <input type="checkbox" id="chk_mybiocheckcapturebyChat" />
                   <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
     </div>
             
     </div>
</div>


<script language="javascript" type="text/javascript">
    var testTypeMyBioCheckAssessment = '<%= (long)TestType.MyBioCheckAssessment %>';

    var isMybiocheckResultentrytype = '<%= IsResultEntrybyChat %>';

    fileTypeMyBioCheckPDF = '<%=(long)FileType.Pdf %>';
    var myBioCheckAssessment = null;
    function SetMyBioCheckAssessmentData(testResult) {
        myBioCheckAssessment = new MyBioCheckAssessment(testResult);
        myBioCheckAssessment.setData();
    }

    function GetMyBioCheckAssessmentData() {
        if (myBioCheckAssessment == null) myBioCheckAssessment = new MyBioCheckAssessment();
        return myBioCheckAssessment.getData();
    }

    function checkMyBioCheckAssessmentTotalCholesterolMinMaxValue(tcValue) {
        if ('<%= RoleId %>' == '<%= (long)Falcon.App.Core.Enum.Roles.Technician%>' || '<%= RoleId %>' == '<%= (long)Falcon.App.Core.Enum.Roles.NursePractitioner%>') {
            checkTotalCholesterolOutsidePossibleRange(tcValue);
        }
    }
    function checkMyBioCheckAssessmentHDLMinMaxValue(hdlValue) {
        if ('<%= RoleId %>' == '<%= (long)Falcon.App.Core.Enum.Roles.Technician%>' || '<%= RoleId %>' == '<%= (long)Falcon.App.Core.Enum.Roles.NursePractitioner%>') {
            checkHDLOutsidePossibleRange(hdlValue);
        }
    }
    function checkMyBioCheckAssessmentLDLMinMaxValue(ldlValue) {
        if ('<%= RoleId %>' == '<%= (long)Falcon.App.Core.Enum.Roles.Technician%>' || '<%= RoleId %>' == '<%= (long)Falcon.App.Core.Enum.Roles.NursePractitioner%>') {
            checkLdlOutsidePossibleRange(ldlValue);
        }
    }
    function checkMyBioCheckAssessmentTriglyceridesMinMaxValue(tgValue) {
        if ('<%= RoleId %>' == '<%= (long)Falcon.App.Core.Enum.Roles.Technician%>' || '<%= RoleId %>' == '<%= (long)Falcon.App.Core.Enum.Roles.NursePractitioner%>') {
            checkTriglyceridesOutsidePossibleRange(tgValue);
        }
    }
   

</script>
