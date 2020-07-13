<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HPylori.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.HPylori" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/HPylori.js?q=<%= VersionNumber %>"></script>
<div id="hpylori_hip" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
<div class="orange-band test-section-header">
    <h5>
        <span class="org-heading"><strong>Helicobacter Pylori Results</strong></span>
    </h5>
    <span class="chk_orngband">
        <select id="conductedbyHPylori" class="conductedby-ddl">
        </select>
    </span>
    <span class="chk_orngband" id="HPylori-critical-span">
        <input type="checkbox" id="DescribeSelfPresentHPyloriInputCheck" onclick="onClick_CriticalDataHPylori();" />Critical </span>
    <span class="chk_orngband" id="hpylori-priorityInQueue-span">
        <input type="checkbox" id="PriorityInQueueTestHPyloriCheck" onclick="onClick_PriorityInQueueDataHPylori();" />Priority In Queue
    </span>
    <span class="chk_orngband" id="hpylori-retest-span">
        <input type="checkbox" id="Retest_63" />Retest
    </span>
</div>
<div class="left_info1">
    <div class="labelwdt2 finding" style="width: 300px;">
        <asp:GridView runat="server" ID="gvFindingsHPylori" AutoGenerateColumns="False" ShowHeader="False"
            EnableViewState="false" GridLines="None" CssClass="gv-findings-HPylori finding-section">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <div class="listchkbox">
                            <input type="radio" id="rbtFindingHPylori" name="rbtFindingHPylori" class="rbt-finding" />
                        </div>
                        <div class="lfttoppad">
                            <%# DataBinder.Eval(Container.DataItem, "Label")%>
                            <input type="hidden" id="FindingHPyloriInputHidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                            <input type="hidden" class="finding-minvalue" value='<%# DataBinder.Eval(Container.DataItem, "MinValue")%>' />
                            <input type="hidden" class="finding-maxvalue" value='<%# DataBinder.Eval(Container.DataItem, "MaxValue")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</div>

<div class="left_info1">

    <div class="left" style="width: 32%;">
        <asp:DataList runat="server" ID="dtlHPyloriSelectedUnableToScreen" GridLines="None"
            EnableViewState="false" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="dtl-unabletoscreen-HPylori unable-to-screen-section">
            <ItemTemplate>
                <input type="checkbox" id="chkUnableScreenReason" class="chk-selected-HPylori-us" />
                <b><%# DataBinder.Eval(Container.DataItem, "DisplayName") %></b>
                <input type="hidden" id="hfUnableScreenReasonID" class="hdn-selected-HPylori-us" value='<%# Convert.ToString((int)DataBinder.Eval(Container.DataItem, "Reason")) %>' />
            </ItemTemplate>
        </asp:DataList>
    </div>
    <div class="lrow clear-all-selection">
        <a style="margin-left: 5px;" id="clear-all-HPylori" href="javascript:void(0);" onclick="clearAllHPyloriSelection();">Clear All Selection</a>
    </div>
</div>
<div class="rgt_info1">
    <div class="rrow">
        <b>Technician Notes: </b>
        <br />
        <textarea id="technotesHPylori" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
            rows="2" cols="54"></textarea>
    </div>
</div>
<%--Right Part Starts here--%>
<div class="physician-section" style="float: left; width: 100%; clear: both; margin-top: 5px;">
    <fieldset style="float: left; width: 98%; border-radius: 4px;">
        <legend>Remarks </legend>
        <div style="float: left; width: 40%;">
            <div style="display: none;">
                <input type="checkbox" id="technicallyltdbutreadableHPyloriinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Technically limited, but readable</b><br />
                <input type="checkbox" id="repeatstudyHPyloriinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Unreadable</b><br />
            </div>
            <input type="checkbox" id="criticalHPylori" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b>
        </div>
        <div style="float: left; width: 58%;">
            <textarea id="physicianRemarksHPylori" rows="3" style="width: 98%;"></textarea>
        </div>
    </fieldset>
</div>
    </div>
<div id="hpylori_chat" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 50%;">
            <span class="org-heading" style="width: 100%;"><strong>Helicobacter Pylori Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyHPylori" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="hpylori-retest-span">
            <input type="checkbox" id="Retest_63" />Retest
        </span>
    </div>
    <div class="hrows hpylori-verificationpanel" style="color: Red; background: #fff0a5; border: solid 1px fff0a5; padding: 2px 2px 2px 5px; display: none;">
    </div>
     <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
             
     <div class="hlfbox">
           <div class="hrows">
             <div class="nrow" style="margin-left:12px;">
                  <input type="checkbox" id="chk_hpyloricapturebyChat" />
                   <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
     </div>
             
     </div>
</div>
<script language="javascript" type="text/javascript">
    var testTypeHPylori = '<%= (long)TestType.HPylori %>';
    var IshPyloriResultEntryExternaly = '<%=IsResultEntrybyChat%>'

    var hPylori = null;
    function SetHPyloriData(testResult) {
        hPylori = new HPylori(testResult);
        hPylori.setData();
    }

    function GetHPyloriData() {
        if (hPylori == null) hPylori = new HPylori();
        return hPylori.getData();
    }

</script>
