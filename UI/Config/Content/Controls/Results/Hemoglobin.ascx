<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Hemoglobin.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.Hemoglobin" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/Hemoglobin.js?q=<%= VersionNumber %>"></script>
<div id="Hemoglobin_hip" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
<div class="orange-band test-section-header">
    <h5>
        <span class="org-heading"><strong>Hemoglobin Results</strong></span>
    </h5>
    <span class="chk_orngband">
        <select id="conductedbyHemoglobin" class="conductedby-ddl">
        </select>
    </span><span class="chk_orngband" id="Hemoglobin-critical-span">
        <input type="checkbox" id="DescribeSelfPresentHemoglobinInputCheck" onclick="onClick_CriticalDataHemoglobin();" />Critical </span>
    <span class="chk_orngband" id="hemoglobin-priorityInQueue-span">
        <input type="checkbox" id="PriorityInQueueTestHemoglobinCheck" onclick="onClick_PriorityInQueueDataHemoglobin();" />Priority In Queue
    </span>
    <span class="chk_orngband" id="hemoglobin-retest-span">
        <input type="checkbox" id="Retest_69" />Retest
    </span>
</div>
<div class="left_info1">
    <div class="hlfbox">
        <div class="hrows" style="height: 140px;">
            <div class="qtrbox">
                <div class="nrow finding">
                    <asp:GridView runat="server" ID="HemoglobinFindingGridView" ShowHeader="false" CssClass="hemoglobin-Hemoglobin-finding clear-all-Hemoglobin-selection"
                        EnableViewState="false" GridLines="None" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <input type="radio" name="rbtHemoglobinHemoglobin" class="rbt-finding" />
                                    <input type="hidden" id="HemoglobinFindingInputHidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
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
                    HEMOGLOBIN 
                    <input type="text" id="hemoglobin-HemoglobinInputText" class="input_bdrbot" onchange="onChangeHemoglobin(this);"
                        style="width: 60px" onkeydown="return KeyPress_DecimalAllowedOnly(event);" />g/dL
                </div>
            </div>
        </div>
    </div>
    <div class="rrow">
        <b>Technician Notes: </b>
        <br />
        <textarea id="technotesHemoglobin" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
            rows="2" cols="54"></textarea>
    </div>
    <div class="labelwdt2 finding" style="margin-top: 10px">
        <asp:DataList runat="server" ID="UnableToScreenHemoglobinDataList" EnableViewState="false"
            RepeatLayout="Flow" CssClass="dtl-unabletoscreen-Hemoglobin unable-to-screen-section" GridLines="None"
            RepeatDirection="Horizontal">
            <ItemTemplate>
                <input type="checkbox" id="chkUnableScreenReason" />
                <b>Unable To Screen</b>
                <input type="hidden" id="hfUnableScreenReasonID" value='<%# Convert.ToString((int)DataBinder.Eval(Container.DataItem, "Reason")) %>' />
            </ItemTemplate>
        </asp:DataList>
        <div class="lrow clear-all-selection">
            <a style="margin-left: 5px;" id="clear-all-Hemoglobin" href="javascript:void(0);" onclick="clearAllHemoglobinSelection();">Clear All Selection</a>
        </div>
    </div>
</div>
<div class="physician-section" style="float: left; width: 100%; clear: both; margin-top: 5px;">
    <fieldset style="float: left; width: 98%; border-radius: 4px;">
        <legend>Remarks </legend>
        <div style="float: left; width: 40%;">
            <input type="checkbox" id="criticalHemoglobin" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b>
        </div>
        <div style="float: left; width: 58%;">
            <textarea id="physicianRemarksHemoglobin" rows="3" style="width: 98%;"></textarea>
        </div>
    </fieldset>
</div>
    </div>
<div id="Hemoglobin_chat" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 50%;">
            <span class="org-heading" style="width: 100%;"><strong>Hemoglobin Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyHemoglobin" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="hemoglobin-retest-span">
            <input type="checkbox" id="Retest_69" />Retest
        </span>
    </div>
    <div class="hrows Hemoglobin-verificationpanel" style="color: Red; background: #fff0a5; border: solid 1px fff0a5; padding: 2px 2px 2px 5px; display: none;">
    </div>
     <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
             
     <div class="hlfbox">
           <div class="hrows">
             <div class="nrow" style="margin-left:12px;">
                  <input type="checkbox" id="chk_HemoglobincapturebyChat" />
                   <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
     </div>
             
     </div>
</div>
<script language="javascript" type="text/javascript">
    var testTypeHemoglobin = '<%= (long)TestType.Hemoglobin %>';
    var IsHemoglobinResultEntryExternaly = '<%=IsResultEntrybyChat%>'

    var hemoglobin = null;
    function SetHemoglobinData(testResult) {
        hemoglobin = new Hemoglobin(testResult);
        hemoglobin.setData();
    }

    function GetHemoglobinData() {
        if (hemoglobin == null) hemoglobin = new Hemoglobin();
        return hemoglobin.getData();
    }

    function checkHemoglobinMinMaxValue(hemoglobinValue) {
        if ('<%= RoleId %>' == '<%= (long)Falcon.App.Core.Enum.Roles.Technician%>') {

            hemoglobinValue = $.trim(hemoglobinValue);

            if ($('#GenderMaleInputRadio').is(":checked")) {
                if (hemoglobinValue != "" && !isNaN(parseFloat(hemoglobinValue))) {
                    if (hemoglobinValue < 13.0 || hemoglobinValue > 18.0) {
                        alert('The value you have entered for Hemoglobin is legitimate or do they need to be repeated.');
                    }
                }
            }
            else if ($('#GenderFemaleInputRadio').is(":checked")) {
                if (hemoglobinValue != "" && !isNaN(parseFloat(hemoglobinValue))) {
                    if (hemoglobinValue < 11.0 || hemoglobinValue > 16.0) {
                        alert('The value you have entered for Hemoglobin is legitimate or do they need to be repeated.');
                    }
                }
            }
        }
    }

</script>
