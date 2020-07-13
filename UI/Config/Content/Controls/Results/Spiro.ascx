<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Spiro.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.Spiro" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/Spiro.js?q=<%= VersionNumber %>"></script>
<div id="spiro_hip" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
<div class="orange-band test-section-header">
    <h5>
        <span class="org-heading"><strong>Spirometry Results</strong></span>
    </h5>
    <span class="chk_orngband">
        <select id="conductedbyspiro" class="conductedby-ddl">
        </select>
    </span>
    <span class="chk_orngband" id="spiro-critical-span">
        <input type="checkbox" id="DescribeSelfPresentSpiroInputCheck" onclick="onClick_CriticalDataSpiro();" />Critical </span>
    <span class="chk_orngband" id="spiro-priorityInQueue-span">
        <input type="checkbox" id="PriorityInQueueTestSpiroCheck" onclick="onClick_PriorityInQueueDataSpiro();" />Priority In Queue
    </span>
    <span class="chk_orngband" id="spiro-retest-span">
        <input type="checkbox" id="Retest_36" />Retest
    </span>
</div>
<div class="left_info1">
    <div class="labelwdt2 finding" style="width: 300px;">
        <asp:GridView runat="server" ID="gvFindingsSpiro" AutoGenerateColumns="False" ShowHeader="False"
            EnableViewState="false" GridLines="None" CssClass="gv-findings-spiro finding-section">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <div class="listchkbox">
                            <input type="radio" id="rbtFindingSpiro" name="rbtFindingSpiro" class="rbt-finding" />
                        </div>
                        <div class="lfttoppad">
                            <%# DataBinder.Eval(Container.DataItem, "Label")%>
                            <input type="hidden" id="FindingspiroInputHidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                            <input type="hidden" class="finding-minvalue" value='<%# DataBinder.Eval(Container.DataItem, "MinValue")%>' />
                            <input type="hidden" class="finding-maxvalue" value='<%# DataBinder.Eval(Container.DataItem, "MaxValue")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</div>
<div class="rgt_info1 exclude-hide-evaluation">
    <input type="checkbox" id="PoorEffortSpiro" />&nbsp;Poor Effort
</div>
<div class="left_info1">
    <div class="left exclude-hide-evaluation" style="width: 99%; margin-bottom: 5px;">
        <b>Incidental Finding: </b>
        <br />
        <input type="checkbox" id="RestrictiveSpiro" />&nbsp;Restrictive&nbsp;&nbsp;
        <input type="checkbox" id="ObstructiveSpiro" />&nbsp;Obstructive
    </div>
    <div class="left" style="width: 32%;">
        <asp:DataList runat="server" ID="dtlSpiroSelectedUnableToScreen" GridLines="None"
            EnableViewState="false" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="dtl-unabletoscreen-spiro unable-to-screen-section">
            <ItemTemplate>
                <input type="checkbox" id="chkUnableScreenReason" class="chk-selected-spiro-us" />
                <b><%# DataBinder.Eval(Container.DataItem, "DisplayName") %></b>
                <input type="hidden" id="hfUnableScreenReasonID" class="hdn-selected-spiro-us" value='<%# Convert.ToString((int)DataBinder.Eval(Container.DataItem, "Reason")) %>' />
            </ItemTemplate>
        </asp:DataList>
    </div>
    <div class="lrow clear-all-selection">
        <a style="margin-left: 5px;" id="clear-all-spiro" href="javascript:void(0);" onclick="clearAllSpiroSelection();">Clear All Selection</a>
    </div>
</div>
<div class="rgt_info1">
    <div class="rrow">
        <b>Technician Notes: </b>
        <br />
        <textarea id="technotesspiro" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
            rows="2" cols="54"></textarea>
    </div>
</div>
<div class="left" style="width: 937px; padding: 3px;">
    <div class="contentrowltpad upload-media-section">
        <a href="javascript:OpenPopUp('Upload Media', '710', '/app/franchisee/technician/uploadTestImages.aspx?RestricttoOne=true&TestType=<%= (int)TestType.Spiro %>&CustomerId=' + customerId);">Upload Media</a>
    </div>
    <div id="SpiroImagesContainerDiv" class="contentrowltpad media-container-div" style="margin-top: 5px;">
    </div>
</div>
<div class="rgt_info1">
    <div class="rrow">
        <b>Technician Notes: </b>
        <br />
        <textarea id="technotesAwvSpiro" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
            rows="2" cols="54"></textarea>
    </div>
    <div class="rrow test-not-performed-section" id="testnotPerformedSpiro">
        <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0" />
        <b>Test Not Performed</b>
        <div class="test-not-performed-container" style="display: none;">
            <b>Reason : </b>
            <br />
            <asp:DropDownList ID="ddlTestNotPerformedReasonSpiro" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
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
<%--Right Part Starts here--%>
<div class="physician-section" style="float: left; width: 100%; clear: both; margin-top: 5px;">
    <fieldset style="float: left; width: 98%; border-radius: 4px;">
        <legend>Remarks </legend>
        <div style="float: left; width: 40%;">
            <input type="checkbox" id="technicallyltdbutreadablespiroinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Technically limited, but readable</b><br />
            <input type="checkbox" id="repeatstudyspiroinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Unreadable</b><br />
            <input type="checkbox" id="criticalSpiro" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b>
        </div>
        <div style="float: left; width: 58%;">
            <textarea id="physicianRemarksSpiro" rows="3" style="width: 98%;"></textarea>
        </div>
    </fieldset>
</div>
    </div>

<div id="spiro_chat" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 50%;">
            <span class="org-heading" style="width: 100%;"><strong>Spirometry Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyspiro" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="spiro-retest-span">
            <input type="checkbox" id="Retest_36" />Retest
        </span>
    </div>
    
    <div class="contentrow" style="width: 99%; padding-left: 0px;">
        <div class="hlfbox">
            <div class="hrows">
                <div class="nrow" style="margin-left: 12px;">
                    <input type="checkbox" id="chk_spirocapturebyChat" />
                    <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
            <div class="hrows" style="float: left; clear: both; padding-left: 30px">
                <div class="left" style="width: 937px; padding: 3px;">
                    <div class="contentrowltpad upload-media-section">
                        <a href="javascript:OpenPopUp('Upload Media', '710', '/app/franchisee/technician/uploadTestImages.aspx?RestricttoOne=true&TestType=<%= (int)TestType.Spiro %>&CustomerId=' + customerId);">Upload Media</a>
                    </div>
                    <div id="SpiroImagesContainerDiv" class="contentrowltpad media-container-div" style="margin-top: 5px;">
                    </div>
                </div>
            </div>
        </div>
        <div style="float: left; clear: none; padding-top: 0" class="test-not-performed-section" id="testnotPerformedSpiro">
            <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0" />
            <b>Test Not Performed</b>
            <div class="test-not-performed-container" style="display: none;">
                <b>Reason : </b>
                <br />
                <asp:DropDownList ID="ddlTestNotPerformedReasonSpiro_CHAT" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
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
    var testTypeSpiro = '<%= (long)TestType.Spiro %>';
    var IsspiroResultEntryExternaly = '<%= IsResultEntrybyChat %>';
    var spiro = null;
    function SetSpiroData(testResult) {
        spiro = new Spiro(testResult);
        spiro.setData();
    }

    function GetSpiroData() {
        if (spiro == null) spiro = new Spiro();
        return spiro.getData();
    }

</script>
