<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PpAaaa.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.PpAaaa" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/PpAaa.js?q=<%= VersionNumber %>"></script>
<div id="Ppaaa_hip" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
<div class="orange-band test-section-header">
    <h5>
        <span class="org-heading"><strong>Abdominal Aortic Aneurysm (AAA) Results</strong></span>
    </h5>
    <span class="chk_orngband">
        <select id="conductedbyPpaaa" class="conductedby-ddl">
        </select>
    </span><span class="chk_orngband" id="Ppaaa-critical-span">
        <input type="checkbox" id="DescribeSelfPresentPpAAAInputCheck" onclick="onClick_CriticalDataPpAaa();" />Critical
    </span>
    <span class="chk_orngband" id="ppaaa-priorityInQueue-span">
        <input type="checkbox" id="PriorityInQueueTestPpAAACheck" onclick="onClick_PriorityInQueueDataPpAAA();" />Priority In Queue
    </span>
    <span class="chk_orngband" id="ppaaa-retest-span">
        <input type="checkbox" id="Retest_37" />Retest
    </span>
</div>
<div id="aaaContent">
    <div class="left_info1">
        <div class="lrow finding">
            <asp:GridView runat="server" Style="float: left;" CssClass="gv-Findings-PpAAA finding-section"
                ID="StandardFindingsPpAAAGridView" AutoGenerateColumns="False" ShowHeader="False"
                GridLines="None">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="lrow">
                                <div class="listchkbox">
                                    <input type="radio" name="rbtFindingsPpAAA" class="rbt-finding" />
                                    <input type="hidden" class="finding-worstcaseorder" value='<%# DataBinder.Eval(Container.DataItem, "WorstCaseOrder")%>' />
                                </div>
                                <div class="lfttoppad">
                                    <%# DataBinder.Eval(Container.DataItem, "Label")%>
                                    (<%# DataBinder.Eval(Container.DataItem, "Description")%>)
                                </div>
                            </div>
                            <input type="hidden" id="FindingPpaaaInputHidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                            <input type="hidden" class="finding-minvalue" value='<%# DataBinder.Eval(Container.DataItem, "MinValue")%>' />
                            <input type="hidden" class="finding-maxvalue" value='<%# DataBinder.Eval(Container.DataItem, "MaxValue")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="lrow margin-top-small">
            <asp:DataList runat="server" ID="UnableToScreenPpAAADataList" CssClass="dtl-unabletoscreen-Ppaaa unable-to-screen-section"
                RepeatLayout="Flow" EnableViewState="false" GridLines="None" RepeatDirection="Horizontal">
                <ItemTemplate>
                    <input type="checkbox" id="chkUnableScreenReason" />
                    <b>&nbsp;<%# DataBinder.Eval(Container.DataItem, "DisplayName")%></b>
                    <input type="hidden" id="hfUnableScreenReasonID" value='<%# Convert.ToString((int)DataBinder.Eval(Container.DataItem, "Reason")) %>' />
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div class="lrow clear-all-selection">
            <a style="margin-left: 5px;" id="clear-all-ppaaa" href="javascript:void(0);" onclick="clearAllPpAaaSelection();">Clear All Selection</a>
        </div>
    </div>
    <div class="rgt_info1">
        <div class="rgt_gbox">
            <div class="grow">
                <strong>Largest Measurement (Sagittal View):<input type="text" id="PpAortaSizeInputText"
                    class="input_bdrbot" style="width: 80px;" onkeydown="return KeyPress_DecimalAllowedOnly(event);" />cm</strong>
            </div>
            <div class="grow" style="padding-left: 20px;">
                <asp:DataList runat="server" ID="PpSaggitalViewDataList" CssClass="dtl-sagitalview-finding-PpAAA"
                    GridLines="None" RepeatDirection="Horizontal" RepeatColumns="3">
                    <ItemTemplate>
                        <span style="float: left; padding-right: 10px;">
                            <input type="checkbox" id="chkFindingSView" />
                            <%# DataBinder.Eval(Container.DataItem, "Label")%>
                            <input type="hidden" class="finding-id" id="hfPpSagittalviewFindingID" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' /></span>
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div class="grow" style="margin-top: 10px;">
                <strong>Largest Measurement (Transverse View):<input type="text" id="PpTVDatapointOneTextbox"
                    class="input_bdrbot" style="width: 40px;" onkeydown="return KeyPress_DecimalAllowedOnly(event);" />cm
                    X
                    <input type="text" id="PpTVDatapointTwoTextbox" class="input_bdrbot" style="width: 40px;"
                        onkeydown="return KeyPress_DecimalAllowedOnly(event);" />cm</strong>
            </div>
            <div class="grow" style="padding-left: 20px;">
                <asp:DataList runat="server" ID="PpTransverseViewDatalist" CssClass="dtl-transverseview-finding-PpAAA"
                    GridLines="None" RepeatDirection="Horizontal" RepeatColumns="3">
                    <ItemTemplate>
                        <span style="float: left; padding-right: 10px;">
                            <input type="checkbox" id="chkFindingTView" />
                            <%# DataBinder.Eval(Container.DataItem, "Label")%>
                            <input type="hidden" class="finding-id" id="hfPpTransverseviewFindingID" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' /></span>
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div class="grow exclude-hide-evaluation" style="margin-top: 10px;">
                <strong>
                    <span style="float: left; padding-right: 10px;">
                        <input type="checkbox" id="PpAorticDissectionCheckbox" />Aortic Dissection 
                    </span>
                    <span style="float: left; padding-right: 10px;">
                        <input type="checkbox" id="PpPlaqueCheckbox" />Plaque/Atherosclerosis 
                    </span>
                    <span style="float: left; padding-right: 5px;">
                        <input type="checkbox" id="PpThrombusCheckbox" />Thrombus 
                    </span>
                    <span style="float: left;">
                        <asp:DataList runat="server" ID="IncidentalFindingsSelectedPpAAADataList" CssClass="dtl-Ppaaa-if incidental-finding-dtl"
                            EnableViewState="false" GridLines="None" RepeatLayout="Flow" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <input type="checkbox" class="chk-if-selected" id="chkIFSelected" />
                                <label class="gbox_chk">
                                    <%# DataBinder.Eval(Container.DataItem, "Label")%></label>
                                <input type="hidden" id="hfIFID" class="hidden-ifid" value='<%# DataBinder.Eval(Container.DataItem, "Id") %>' />
                                <input type="hidden" class="hidden-iftransactionid" value='0' />
                            </ItemTemplate>
                        </asp:DataList>
                    </span>
                </strong>
            </div>
        </div>
        <div class="rrow">
            <b>Technician Notes: </b>
            <br />
            <textarea id="technotesPpaaa" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
                rows="2" cols="54"></textarea>
        </div>
    </div>
    <%--<div class="lrow3">
        <div class="left" style="width: 15%;">
            <label class="labels">
                Incidental Findings:</label>
        </div>
        
    </div>--%>
    <div class="contentrowltpad upload-media-section">
        <a href="javascript:OpenPopUp('Upload Media', '710', '/app/franchisee/technician/uploadTestImages.aspx?TestType=<%= (int)TestType.PPAAA %>&CustomerId=' + customerId);">Upload Media</a>
    </div>
    <div id="PpAAAImagesContainerDiv" class="contentrowltpad media-container-div" style="margin-top: 5px;">
    </div>
</div>
<div class="physician-section" style="float: left; width: 100%; clear: both; margin-top: 5px;">
    <fieldset style="float: left; width: 98%; border-radius: 4px;">
        <legend>Remarks </legend>
        <div style="float: left; width: 40%;">
            <input type="checkbox" id="technicallyltdbutreadablePpaaainputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Technically limited</b><br />
            <input type="checkbox" id="repeatstudyPpaaainputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Unreadable</b><br />
            <input type="checkbox" id="criticalPpAaa" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b>
        </div>
        <div style="float: left; width: 58%;">
            <textarea id="physicianRemarksPpAaa" rows="3" style="width: 98%;"></textarea>
        </div>
        <div style="float: right; width: 58%; margin-right: 2%;">
            <b>Possible diagnosis codes:</b><br />
            <textarea id="diagnosisCodePpAaa" rows="2" style="width: 98%;" readonly="readonly"></textarea>
        </div>
    </fieldset>
</div>
</div>
<div id="Ppaaa_chat" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 50%;">
            <span class="org-heading" style="width: 100%;"><strong>Colorectal Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyPpaaa" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="ppaaa-retest-span">
            <input type="checkbox" id="Retest_37" />Retest
        </span>
    </div>
    <div class="hrows Ppaaa-verificationpanel" style="color: Red; background: #fff0a5; border: solid 1px fff0a5; padding: 2px 2px 2px 5px; display: none;">
    </div>
     <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
             
     <div class="hlfbox">
           <div class="hrows">
             <div class="nrow" style="margin-left:12px;">
                  <input type="checkbox" id="chk_PpaaacapturebyChat" />
                   <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
     </div>
             
     </div>
</div>
<script language="javascript" type="text/javascript">
    var testTypePpAaa = '<%= (long)TestType.PPAAA %>';
    var IsPpaaaResultEntryExternaly = '<%= IsResultEntrybyChat %>';
    var Ppaaa = null;
    function SetPpAAAData(testResult) {
        Ppaaa = new PpAaa(testResult);
        Ppaaa.setData();
    }

    function GetPpAAAData(testResult) {
        if (Ppaaa == null) Ppaaa = new PpAaa();
        return Ppaaa.getData();
    }

</script>
