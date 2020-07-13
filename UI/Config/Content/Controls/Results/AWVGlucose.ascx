<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AwvGlucose.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.AwvGlucose" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/AwvGlucose.js?q=<%= VersionNumber %>"></script>
<div id="AwvGlucose_hip" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
<div class="orange-band test-section-header">
    <h5>
        <span class="org-heading"><strong>Glucose Results</strong></span>
    </h5>
    <span class="chk_orngband">
        <select id="conductedbyAwvGlucose" class="conductedby-ddl">
        </select>
    </span><span class="chk_orngband" id="AwvGlucose-critical-span">
        <input type="checkbox" id="DescribeSelfPresentAwvGlucoseInputCheck" onclick="onClick_CriticalDataAwvGlucose();" />Critical </span>
    <span class="chk_orngband" id="awvGlucose-priorityInQueue-span">
            <input type="checkbox" id="PriorityInQueueTestAwvGlucoseCheck" onclick="onClick_PriorityInQueueDataAwvGlucose();" />Priority In Queue
        </span>
    <span class="chk_orngband" id="awvGlucose-retest-span">
        <input type="checkbox" id="Retest_58" />Retest
    </span>
</div>
<div class="left_info1">
    <div class="hlfbox">
        <div class="hrows" style="height: 140px;">
            <div class="qtrbox small">
                <div class="nrow finding">
                    <asp:GridView runat="server" ID="GlucoseFindingGridView" ShowHeader="false" CssClass="glucose-AwvGlucose-finding finding-section clear-all-AwvGlucose-selection"
                        EnableViewState="false" GridLines="None" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <input type="radio" name="rbtGlucoseAwvGlucose" class="rbt-finding" />
                                    <input type="hidden" id="GlucoseFindingInputHidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
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
</div>
<div class="rgt_info1">
    <div class="nrow">
        <div style="height: 40px; float: right;" class="rgtgbox_singleReading">
            <div class="grow">
                <div class="right">
                    GLUCOSE (Blood Sugar) =
                    <input type="text" id="GlucoseAwvGlucoseInputText" class="input_bdrbot" onblur="autoSelectFinding($('.glucose-AwvGlucose-finding'), $(this), 1);"
                        style="width: 60px" onkeydown="return KeyPress_NumericAllowedOnly(event);" />
                </div>
            </div>
        </div>
    </div>
    <div class="rrow">
        <b>Technician Notes: </b>
        <br />
        <textarea id="technotesAwvGlucose" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
            rows="2" cols="54">
        </textarea>
    </div>
    <div class="labelwdt2 finding" style="margin-top: 10px">
        <asp:DataList runat="server" ID="UnableToScreenAwvGlucoseDataList" EnableViewState="false"
            RepeatLayout="Flow" CssClass="dtl-unabletoscreen-AwvGlucose unable-to-screen-section" GridLines="None"
            RepeatDirection="Horizontal">
            <ItemTemplate>
                <input type="checkbox" id="chkUnableScreenReason" style="margin-left: 0" />
                <b>Unable To Screen</b>
                <input type="hidden" id="hfUnableScreenReasonID" value='<%# Convert.ToString((int)DataBinder.Eval(Container.DataItem, "Reason")) %>' />
            </ItemTemplate>
        </asp:DataList>
        <div class="lrow clear-all-selection">
            <a style="margin-left: 5px;" id="clear-all-AwvGlucose" href="javascript:void(0);" onclick="clearAllAwvGlucoseSelection();"> Clear All Selection</a>
        </div>
    </div>
    <div class="rrow test-not-performed-section" id="testnotPerformedAwvGlucose">
        <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0" />
        <b>Test Not Performed</b>
        <div class="test-not-performed-container" style="display: none">
            <b>Reason : </b>
            <br />
            <asp:DropDownList ID="ddlTestNotPerformedReasonAwvGlucose" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
            </asp:DropDownList>
            <br />
            <div >
                <b>Notes :</b>
                <br />
                <textarea  rows="2" cols="54"></textarea>
            </div>
        </div>
    </div>
</div>
<div class="physician-section" style="float: left; width: 100%; clear: both; margin-top: 5px;">
    <fieldset style="float: left; width: 98%;  border-radius: 4px;">
        <legend>Remarks </legend>
        <div style="float: left; width: 40%;">
            <input type="checkbox" id="criticalAwvGlucose" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b>
        </div>
        <div style="float: left; width: 58%;">
            <textarea id="physicianRemarksAwvGlucose" rows="3" style="width: 98%;"></textarea></div>
    </fieldset>
</div>
    </div>
<div id="AwvGlucose_chat" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 50%;">
            <span class="org-heading" style="width: 100%;"><strong>Spirometry Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyAwvGlucose" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="awvGlucose-retest-span">
            <input type="checkbox" id="Retest_58" />Retest
        </span>
    </div>
    <div class="hrows AwvGlucose-verificationpanel" style="color: Red; background: #fff0a5; border: solid 1px fff0a5; padding: 2px 2px 2px 5px; display: none;">
    </div>
     <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
             
     <div class="hlfbox">
           <div class="hrows">
             <div class="nrow" style="margin-left:12px;">
                  <input type="checkbox" id="chk_AwvGlucosecapturebyChat" />
                   <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
     </div>
             
     </div>
</div>
<script language="javascript" type="text/javascript">
    var testTypeAwvGlucose = '<%= (long)TestType.AwvGlucose %>';
    var IsawvGlucoseResultEntryExternaly = '<%=IsResultEntrybyChat%>'
    var awvGlucose = null;
    function SetAwvGlucoseData(testResult) {
        awvGlucose = new AwvGlucose(testResult);
        awvGlucose.setData();
    }

    function GetAwvGlucoseData() {
        if (awvGlucose == null) awvGlucose = new AwvGlucose();
        return awvGlucose.getData();
    }

</script>
