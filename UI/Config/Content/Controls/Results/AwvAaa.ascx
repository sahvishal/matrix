<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AwvAaa.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.AwvAaa" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/AwvAaa.js?q=<%= VersionNumber %>"></script>

<div id="AwvAaa_hip" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
<div class="orange-band test-section-header">
    <h5>
        <span class="org-heading"><strong>Abdominal Aortic Aneurysm (AAA) Results</strong></span>
    </h5>
    <span class="chk_orngband">
        <select id="conductedbyAwvAaa" class="conductedby-ddl">
        </select>
    </span><span class="chk_orngband" id="AwvAaa-critical-span">
        <input type="checkbox" id="DescribeSelfPresentAwvAaaInputCheck" onclick="onClick_CriticalDataAwvAaa();" />Critical
    </span>
    <span class="chk_orngband" id="AwvAaa-priorityInQueue-span">
        <input type="checkbox" id="PriorityInQueueTestAwvAaaCheck" onclick="onClick_PriorityInQueueDataAwvAaa();" />Priority In Queue
    </span>
    <span class="chk_orngband" id="AwvAaa-retest-span">
        <input type="checkbox" id="Retest_55" />Retest
    </span>
</div>
<div id="aaaContent">
    <div class="left_info1">
        <div class="lrow finding">
            <asp:GridView runat="server" Style="float: left;" CssClass="gv-Findings-AwvAaa finding-section"
                ID="StandardFindingsAwvAaaGridView" AutoGenerateColumns="False" ShowHeader="False"
                GridLines="None">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="lrow">
                                <div class="listchkbox">
                                    <input type="radio" name="rbtFindingsAwvAaa" class="rbt-finding" />
                                </div>
                                <div class="lfttoppad">
                                    <%# DataBinder.Eval(Container.DataItem, "Label")%>
                                    (<%# DataBinder.Eval(Container.DataItem, "Description")%>)
                                </div>
                            </div>
                            <input type="hidden" id="FindingAwvAaaInputHidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                            <input type="hidden" class="finding-minvalue" value='<%# DataBinder.Eval(Container.DataItem, "MinValue")%>' />
                            <input type="hidden" class="finding-maxvalue" value='<%# DataBinder.Eval(Container.DataItem, "MaxValue")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="lrow margin-top-small">
            <asp:DataList runat="server" ID="UnableToScreenAwvAaaDataList" CssClass="dtl-unabletoscreen-AwvAaa unable-to-screen-section"
                RepeatLayout="Flow" EnableViewState="false" GridLines="None" RepeatDirection="Horizontal">
                <ItemTemplate>
                    <input type="checkbox" id="chkUnableScreenReason" />
                    <b>&nbsp;<%# DataBinder.Eval(Container.DataItem, "DisplayName")%></b>
                    <input type="hidden" id="hfUnableScreenReasonID" value='<%# Convert.ToString((int)DataBinder.Eval(Container.DataItem, "Reason")) %>' />
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div class="lrow clear-all-selection">
            <a style="margin-left: 5px;" id="clear-all-aaa" href="javascript:void(0);" onclick="clearAllAwvAaaSelection();">Clear All Selection</a>
        </div>
    </div>
    <div class="rgt_info1">
        <div class="rgt_gbox">
            <div class="grow exclude-hide-evaluation">
                <strong>Largest Measurement (Sagittal View):<input type="text" id="AwvAaaAortaSizeInputText"
                    class="input_bdrbot" style="width: 80px;" onkeydown="return KeyPress_DecimalAllowedOnly(event);" />cm</strong>
            </div>
            <div class="grow exclude-hide-evaluation" style="padding-left: 20px;">
                <asp:DataList runat="server" ID="AwvAaaSaggitalViewDataList" CssClass="dtl-sagitalview-finding-AwvAaa"
                    GridLines="None" RepeatDirection="Horizontal" RepeatColumns="3">
                    <ItemTemplate>
                        <span style="float: left; padding-right: 10px;">
                            <input type="checkbox" id="chkFindingSView" />
                            <%# DataBinder.Eval(Container.DataItem, "Label")%>
                            <input type="hidden" class="finding-id" id="hfSagittalviewFindingID" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' /></span>
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div class="grow exclude-hide-evaluation" style="margin-top: 10px;">
                <strong>Largest Measurement (Transverse View):<input type="text" id="AwvAaaTVDatapointOneTextbox"
                    class="input_bdrbot" style="width: 40px;" onkeydown="return KeyPress_DecimalAllowedOnly(event);" />cm
                    X
                    <input type="text" id="AwvAaaTVDatapointTwoTextbox" class="input_bdrbot" style="width: 40px;"
                        onkeydown="return KeyPress_DecimalAllowedOnly(event);" />cm</strong>
            </div>
            <div class="grow exclude-hide-evaluation" style="padding-left: 20px;">
                <asp:DataList runat="server" ID="TransverseViewDatalist" CssClass="dtl-transverseview-finding-AwvAaa"
                    GridLines="None" RepeatDirection="Horizontal" RepeatColumns="3">
                    <ItemTemplate>
                        <span style="float: left; padding-right: 10px;">
                            <input type="checkbox" id="chkFindingTView" />
                            <%# DataBinder.Eval(Container.DataItem, "Label")%>
                            <input type="hidden" class="finding-id" id="hfTransverseviewFindingID" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' /></span>
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div class="grow exclude-hide-evaluation">
                <strong>Peak Systolic Velocity:<input type="text" id="AwvAaaPeakSystolicVelocityInputText"
                    class="input_bdrbot" style="width: 80px;" onkeydown="return KeyPress_DecimalAllowedOnly(event);" />cm</strong>
            </div>
            <div class="grow exclude-hide-evaluation" style="padding-left: 20px;">
                <asp:DataList runat="server" ID="PeakSystolicVelocityDatalist" CssClass="dtl-peakSystolicVelocity-finding-AwvAaa"
                    GridLines="None" RepeatDirection="Horizontal" RepeatColumns="3">
                    <ItemTemplate>
                        <span style="float: left; padding-right: 10px;">
                            <input type="checkbox" id="chkFindingTView" />
                            <%# DataBinder.Eval(Container.DataItem, "Label")%>
                            <input type="hidden" class="finding-id" id="hfpeakSystolicVelocityFindingID" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' /></span>
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div class="grow exclude-hide-evaluation" style="margin-top: 10px;">
                <strong>Residual Lumen(Transverse View):<input type="text" id="AwvAaaResidualLumenTVDatapointOneTextbox"
                    class="input_bdrbot" style="width: 40px;" onkeydown="return KeyPress_DecimalAllowedOnly(event);" />cm
                    X
                    <input type="text" id="AwvAaaResidualLumenTVDatapointTwoTextbox" class="input_bdrbot" style="width: 40px;"
                        onkeydown="return KeyPress_DecimalAllowedOnly(event);" />cm</strong>
            </div>
            <div class="grow exclude-hide-evaluation" style="margin-top: 10px;">
                <strong>
                    <span style="float: left; padding-right: 10px;">
                        <input type="checkbox" id="AwvAaaAorticDissectionCheckbox" />Aortic Dissection 
                    </span>
                    <span style="float: left; padding-right: 10px;">
                        <input type="checkbox" id="AwvAaaPlaqueCheckbox" />Plaque/Atherosclerosis 
                    </span>
                    <span style="float: left; padding-right: 5px;">
                        <input type="checkbox" id="AwvAaaThrombusCheckbox" />Thrombus 
                    </span>
                    <span style="float: left;">
                        <asp:DataList runat="server" ID="IncidentalFindingsSelectedAwvAaaDataList" CssClass="dtl-AwvAaa-if incidental-finding-dtl"
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
            <textarea id="technotesAwvAaa" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
                rows="2" cols="54"></textarea>

        </div>
        <div class="rrow test-not-performed-section" id="testnotPerformedAwvAaa">
            <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0" />
            <b>Test Not Performed</b>
            <div class="test-not-performed-container" style="display: none">
                <b>Reason : </b>
                <br />
                <asp:DropDownList ID="ddlTestNotPerformedReasonAwvAaa" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
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
    <%--<div class="lrow3">
        <div class="left" style="width: 15%;">
            <label class="labels">
                Incidental Findings:</label>
        </div>
        
    </div>--%>
    <div class="contentrowltpad upload-media-section">
        <a href="javascript:OpenPopUp('Upload Media', '710', '/app/franchisee/technician/uploadTestImages.aspx?TestType=<%= (int)TestType.AwvAAA %>&CustomerId=' + customerId);">Upload Media</a>
    </div>
    <div id="AwvAaaImagesContainerDiv" class="contentrowltpad media-container-div" style="margin-top: 5px;">
    </div>
</div>
    <div class="physician-section" style="float: left; width: 100%; clear: both; margin-top: 5px;">
    <fieldset style="float: left; width: 98%; border-radius: 4px;">
        <legend>Remarks </legend>
        <div style="float: left; width: 40%;">
            <input type="checkbox" id="technicallyltdbutreadableAwvAaainputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Technically limited</b><br />
            <input type="checkbox" id="repeatstudyAwvAaainputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Repeat Study/Unreadable</b><br />
            <input type="checkbox" id="criticalAwvAaa" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b>
        </div>
        <div style="float: left; width: 58%;">
            <textarea id="physicianRemarksAwvAaa" rows="3" style="width: 98%;"></textarea>
        </div>
    </fieldset>
</div>
    </div>

<div id="AwvAaa_chat" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 50%;">
            <span class="org-heading" style="width: 100%;"><strong>Abdominal Aortic Aneurysm (AAA) Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyAwvAaa" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="AwvAaa-critical-span">
        <input type="checkbox" id="DescribeSelfPresentAwvAaaInputCheck" onclick="onClick_CriticalDataAwvAaa();" />Critical
    </span>
        <span class="chk_orngband" id="AwvAaa-retest-span">
            <input type="checkbox" id="Retest_55" />Retest
        </span>
    </div>
    <div class="hrows AwvAaa-verificationpanel" style="color: Red; background: #fff0a5; border: solid 1px fff0a5; padding: 2px 2px 2px 5px; display: none;">
    </div>
     <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
             
     <div class="hlfbox">
           <div class="hrows">
             <div class="nrow" style="margin-left:12px;">
                  <input type="checkbox" id="chk_AwvAaacapturebyChat" />
                   <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
     </div>
             
     </div>
</div>

<script language="javascript" type="text/javascript">
    var testTypeAwvAaa = '<%= (long)TestType.AwvAAA %>';
    var IsAwvAaaResultEntryExternaly = '<%= IsResultEntrybyChat %>';

    var awvAaa = null;
    function SetAwvAaaData(testResult) {
        awvAaa = new AwvAaa(testResult);
        awvAaa.setData();
    }

    function GetAwvAaaData() {
        if (awvAaa == null) awvAaa = new AwvAaa();
        return awvAaa.getData();
    }

</script>
