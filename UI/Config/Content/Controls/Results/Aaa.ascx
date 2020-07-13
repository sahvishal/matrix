<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Aaa.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.Aaa" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/Aaa.js?q=<%= VersionNumber %>"></script>
<div id="aaa_hip" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
<div class="orange-band test-section-header">
    <h5>
        <span class="org-heading"><strong>Abdominal Aortic Aneurysm (AAA) Results</strong></span>
    </h5>
    <span class="chk_orngband">
        <select id="conductedbyaaa" class="conductedby-ddl">
        </select>
    </span><span class="chk_orngband" id="aaa-critical-span">
        <input type="checkbox" id="DescribeSelfPresentAAAInputCheck" onclick="onClick_CriticalDataAaa();" />Critical
    </span>
    <span class="chk_orngband" id="aaa-priorityInQueue-span">
        <input type="checkbox" id="PriorityInQueueTestAAACheck" onclick="onClick_PriorityInQueueDataAAA();" />Priority In Queue
    </span>
    <span class="chk_orngband" id="aaa-retest-span">
        <input type="checkbox" id="Retest_10" />Retest
    </span>
</div>
<div id="aaaContent">
    <div class="left_info1">
        <div class="lrow finding">
            <asp:GridView runat="server" Style="float: left;" CssClass="gv-Findings-AAA finding-section"
                ID="StandardFindingsAAAGridView" AutoGenerateColumns="False" ShowHeader="False"
                GridLines="None">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="lrow">
                                <div class="listchkbox">
                                    <input type="radio" name="rbtFindingsAAA" class="rbt-finding" />
                                </div>
                                <div class="lfttoppad">
                                    <%# DataBinder.Eval(Container.DataItem, "Label")%>
                                    (<%# DataBinder.Eval(Container.DataItem, "Description")%>)
                                </div>
                            </div>
                            <input type="hidden" id="FindingaaaInputHidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                            <input type="hidden" class="finding-minvalue" value='<%# DataBinder.Eval(Container.DataItem, "MinValue")%>' />
                            <input type="hidden" class="finding-maxvalue" value='<%# DataBinder.Eval(Container.DataItem, "MaxValue")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="lrow margin-top-small">
            <asp:DataList runat="server" ID="UnableToScreenAAADataList" CssClass="dtl-unabletoscreen-aaa unable-to-screen-section"
                RepeatLayout="Flow" EnableViewState="false" GridLines="None" RepeatDirection="Horizontal">
                <ItemTemplate>
                    <input type="checkbox" id="chkUnableScreenReason" />
                    <b>&nbsp;<%# DataBinder.Eval(Container.DataItem, "DisplayName")%></b>
                    <input type="hidden" id="hfUnableScreenReasonID" value='<%# Convert.ToString((int)DataBinder.Eval(Container.DataItem, "Reason")) %>' />
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div class="lrow clear-all-selection">
            <a style="margin-left: 5px;" id="clear-all-aaa" href="javascript:void(0);" onclick="clearAllAaaSelection();">Clear All Selection</a>
        </div>
    </div>
    <div class="rgt_info1">
        <div class="rgt_gbox">
            <div class="grow aaa-reading-div exclude-hide-evaluation">
                <strong>Largest Measurement (Sagittal View):<input type="text" id="AortaSizeInputText"
                    class="input_bdrbot" style="width: 80px;" onkeydown="return KeyPress_DecimalAllowedOnly(event);" />cm</strong>
            </div>
            <div class="grow exclude-hide-evaluation" style="padding-left: 20px;">
                <asp:DataList runat="server" ID="SaggitalViewDataList" CssClass="dtl-sagitalview-finding-AAA"
                    GridLines="None" RepeatDirection="Horizontal" RepeatColumns="3">
                    <ItemTemplate>
                        <span style="float: left; padding-right: 10px;">
                            <input type="checkbox" id="chkFindingSView" />
                            <%# DataBinder.Eval(Container.DataItem, "Label")%>
                            <input type="hidden" class="finding-id" id="hfSagittalviewFindingID" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' /></span>
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div class="grow aaa-reading-div exclude-hide-evaluation" style="margin-top: 10px;">
                <strong>Largest Measurement (Transverse View):<input type="text" id="TVDatapointOneTextbox"
                    class="input_bdrbot" style="width: 40px;" onkeydown="return KeyPress_DecimalAllowedOnly(event);" />cm
                    X
                    <input type="text" id="TVDatapointTwoTextbox" class="input_bdrbot" style="width: 40px;"
                        onkeydown="return KeyPress_DecimalAllowedOnly(event);" />cm</strong>
            </div>
            <div class="grow exclude-hide-evaluation" style="padding-left: 20px;">
                <asp:DataList runat="server" ID="TransverseViewDatalist" CssClass="dtl-transverseview-finding-AAA"
                    GridLines="None" RepeatDirection="Horizontal" RepeatColumns="3">
                    <ItemTemplate>
                        <span style="float: left; padding-right: 10px;">
                            <input type="checkbox" id="chkFindingTView" />
                            <%# DataBinder.Eval(Container.DataItem, "Label")%>
                            <input type="hidden" class="finding-id" id="hfTransverseviewFindingID" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' /></span>
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div class="grow exclude-hide-evaluation" style="margin-top: 10px;">
                <strong>
                    <span style="float: left; padding-right: 10px;">
                        <input type="checkbox" id="AorticDissectionCheckbox" />Aortic Dissection 
                    </span>
                    <span style="float: left; padding-right: 10px;">
                        <input type="checkbox" id="PlaqueCheckbox" />Plaque 
                    </span>
                    <span style="float: left; padding-right: 5px;">
                        <input type="checkbox" id="ThrombusCheckbox" />Thrombus 
                    </span>
                    <span style="float: left;">
                        <asp:DataList runat="server" ID="IncidentalFindingsSelectedAAADataList" CssClass="dtl-aaa-if incidental-finding-dtl"
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
            <textarea id="technotesaaa" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
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
        <a href="javascript:OpenPopUp('Upload Media', '710', '/app/franchisee/technician/uploadTestImages.aspx?TestType=<%= (int)TestType.AAA %>&CustomerId=' + customerId);">Upload Media</a>
    </div>
    <div id="AAAImagesContainerDiv" class="contentrowltpad media-container-div" style="margin-top: 5px;">
    </div>
</div>
<div class="physician-section" style="float: left; width: 100%; clear: both; margin-top: 5px;">
    <fieldset style="float: left; width: 98%; border-radius: 4px;">
        <legend>Remarks </legend>
        <div style="float: left; width: 40%;">
            <input type="checkbox" id="technicallyltdbutreadableaaainputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Technically limited</b><br />
            <div runat="server" id="physicianRepeatStudy">
                <input type="checkbox" id="repeatstudyaaainputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Repeat Study/Unreadable</b><br />
            </div>
            <input type="checkbox" id="criticalAaa" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b>
            <div class="validate-echo-carotid-aaa" id="aaaOtherModalitiesAdditionalImages" runat="server">
                <input type="radio" id="AaaConsiderOtherModalities" name="AaaPhysicianAdditionalFindingReading" onclick="clearAllAaaSelection();" />&nbsp;<b>Consider other modalities</b><br />
                <input type="radio" id="AaaAdditionalImagesNeeded" name="AaaPhysicianAdditionalFindingReading" onclick="clearAllAaaSelection();" />&nbsp;<b>Additional images needed to finalize report</b><br />
            </div>
        </div>
        <div style="float: left; width: 58%;">
            <textarea id="physicianRemarksAaa" rows="3" style="width: 98%;"></textarea>
        </div>
    </fieldset>
</div>

    </div>

<div id="aaa_chat" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 50%;">
            <span class="org-heading" style="width: 100%;"><strong>Abdominal Aortic Aneurysm (AAA) Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyaaa" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="aaa-retest-span">
            <input type="checkbox" id="Retest_10" />Retest
        </span>
    </div>
    <div class="hrows aaa-verificationpanel" style="color: Red; background: #fff0a5; border: solid 1px fff0a5; padding: 2px 2px 2px 5px; display: none;">
    </div>
     <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
             
     <div class="hlfbox">
           <div class="hrows">
             <div class="nrow" style="margin-left:12px;">
                  <input type="checkbox" id="chk_aaacapturebyChat" />
                   <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
     </div>
             
     </div>
</div>
<script language="javascript" type="text/javascript">
    var testTypeAaa = '<%= (long)TestType.AAA %>';
    var IsaaaResultEntryExternaly = '<%= IsResultEntrybyChat %>';

    var aaa = null;
    function SetAAAData(testResult) {
        aaa = new Aaa(testResult);
        aaa.setData();
    }

    function GetAAAData(testResult) {
        if (aaa == null) aaa = new Aaa();
        return aaa.getData();
    }

</script>
