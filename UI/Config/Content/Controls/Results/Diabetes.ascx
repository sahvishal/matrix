<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Diabetes.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.Diabetes" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/Diabetes.js?q=<%= VersionNumber %>"></script>
<div id="Diabetes_hip" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
<div class="orange-band test-section-header">
    <h5>
        <span class="org-heading"><strong>Diabetes Results</strong></span>
    </h5>
    <span class="chk_orngband">
        <select id="conductedbyDiabetes" class="conductedby-ddl">
        </select>
    </span><span class="chk_orngband" id="Diabetes-critical-span">
        <input type="checkbox" id="DescribeSelfPresentDiabetesInputCheck" onclick="onClick_CriticalDataDiabetes();" />Critical </span>
    <span class="chk_orngband" id="diabetes-priorityInQueue-span">
        <input type="checkbox" id="PriorityInQueueTestDiabetesCheck" onclick="onClick_PriorityInQueueDataDiabetes();" />Priority In Queue
    </span>
    <span class="chk_orngband" id="diabetes-retest-span">
        <input type="checkbox" id="Retest_62" />Retest
    </span>
</div>
<div class="left_info1">
    <div class="hlfbox">
        <div class="hrows" style="height: 140px;">
            <div class="qtrbox small">
                <div class="nrow finding">
                    <asp:GridView runat="server" ID="GlucoseFindingGridView" ShowHeader="false" CssClass="glucose-Diabetes-finding finding-section clear-all-Diabetes-selection"
                        EnableViewState="false" GridLines="None" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <input type="radio" name="rbtGlucoseDiabetes" class="rbt-finding" />
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
                    <input type="text" id="GlucoseDiabetesInputText" class="input_bdrbot" onblur="autoSelectFinding($('.glucose-Diabetes-finding'), $(this), 1);"
                        style="width: 60px" onkeydown="return KeyPress_NumericAllowedOnly(event);" />
                </div>
            </div>
        </div>
    </div>
    <div class="rrow">
        <b>Technician Notes: </b>
        <br />
        <textarea id="technotesDiabetes" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
            rows="2" cols="54"></textarea>
    </div>
    <div class="labelwdt2 finding" style="margin-top: 10px">
        <asp:DataList runat="server" ID="UnableToScreenDiabetesDataList" EnableViewState="false"
            RepeatLayout="Flow" CssClass="dtl-unabletoscreen-Diabetes unable-to-screen-section" GridLines="None"
            RepeatDirection="Horizontal">
            <ItemTemplate>
                <input type="checkbox" id="chkUnableScreenReason" />
                <b>Unable To Screen</b>
                <input type="hidden" id="hfUnableScreenReasonID" value='<%# Convert.ToString((int)DataBinder.Eval(Container.DataItem, "Reason")) %>' />
            </ItemTemplate>
        </asp:DataList>
        <div class="lrow clear-all-selection">
            <a style="margin-left: 5px;" id="clear-all-Diabetes" href="javascript:void(0);" onclick="clearAllDiabetesSelection();">Clear All Selection</a>
        </div>
    </div>
</div>
<div class="physician-section" style="float: left; width: 100%; clear: both; margin-top: 5px;">
    <fieldset style="float: left; width: 98%; border-radius: 4px;">
        <legend>Remarks </legend>
        <div style="float: left; width: 40%;">
            <input type="checkbox" id="criticalDiabetes" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b>
        </div>
        <div style="float: left; width: 58%;">
            <textarea id="physicianRemarksDiabetes" rows="3" style="width: 98%;"></textarea>
        </div>
    </fieldset>
</div>
    </div>

<div id="Diabetes_chat" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 50%;">
            <span class="org-heading" style="width: 100%;"><strong>Diabetes Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyDiabetes" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="diabetes-retest-span">
            <input type="checkbox" id="Retest_62" />Retest
        </span>
    </div>
    <div class="hrows Diabetes-verificationpanel" style="color: Red; background: #fff0a5; border: solid 1px fff0a5; padding: 2px 2px 2px 5px; display: none;">
    </div>
     <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
             
     <div class="hlfbox">
           <div class="hrows">
             <div class="nrow" style="margin-left:12px;">
                  <input type="checkbox" id="chk_DiabetescapturebyChat" />
                   <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
     </div>
             
     </div>
</div>


<script language="javascript" type="text/javascript">
    var testTypeDiabetes = '<%= (long)TestType.Diabetes %>';
    var IsdiabetesResultEntryExternaly = '<%= IsResultEntrybyChat %>';

    var diabetes = null;
    function SetDiabetesData(testResult) {
        diabetes = new Diabetes(testResult);
        diabetes.setData();
    }

    function GetDiabetesData() {
        if (diabetes == null) diabetes = new Diabetes();
        return diabetes.getData();
    }

</script>
