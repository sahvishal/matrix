<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AwvSpiro.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.AwvSpiro" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/AwvSpiro.js?q=<%= VersionNumber %>"></script>
<div id="awvSpiro_hip" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
<div class="orange-band test-section-header">
    <h5>
        <span class="org-heading"><strong>Spirometry Results</strong></span>
    </h5>
    <span class="chk_orngband">
        <select id="conductedbyAwvSpiro" class="conductedby-ddl">
        </select>
    </span><span class="chk_orngband" id="AwvSpiro-critical-span">
        <input type="checkbox" id="DescribeSelfPresentAwvSpiroInputCheck" onclick="onClick_CriticalDataAwvSpiro();" />Critical </span>
    <span class="chk_orngband" id="awvSpiro-priorityInQueue-span">
        <input type="checkbox" id="PriorityInQueueTestAwvSpiroCheck" onclick="onClick_PriorityInQueueDataAwvSpiro();" />Priority In Queue
    </span>
    <span class="chk_orngband" id="awvSpiro-retest-span">
        <input type="checkbox" id="Retest_52" />Retest
    </span>
</div>
<div class="left_info1">
    <div class="labelwdt2 finding" style="width: 300px;">
        <asp:GridView runat="server" ID="gvFindingsAwvSpiro" AutoGenerateColumns="False" ShowHeader="False"
            EnableViewState="false" GridLines="None" CssClass="gv-findings-AwvSpiro finding-section">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <div class="listchkbox">
                            <input type="radio" id="rbtFindingAwvSpiro" name="rbtFindingAwvSpiro" class="rbt-finding" />
                        </div>
                        <div class="lfttoppad">
                            <%# DataBinder.Eval(Container.DataItem, "Label")%>
                            <input type="hidden" id="FindingAwvSpiroInputHidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                            <input type="hidden" class="finding-minvalue" value='<%# DataBinder.Eval(Container.DataItem, "MinValue")%>' />
                            <input type="hidden" class="finding-maxvalue" value='<%# DataBinder.Eval(Container.DataItem, "MaxValue")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</div>
<div class="rgt_info1 exclude-hide-evaluation">
    <input type="checkbox" id="PoorEffortAwvSpiro" />&nbsp;Poor Effort
</div>
<div class="left_info1">
    <div class="left exclude-hide-evaluation" style="width: 99%; margin-bottom: 5px;">
        <b>Incidental Finding: </b>
        <br />
        <input type="checkbox" id="RestrictiveAwvSpiro" />&nbsp;Restrictive&nbsp;&nbsp;
        <input type="checkbox" id="ObstructiveAwvSpiro" />&nbsp;Obstructive
    </div>
    <div class="labelwdt2 finding">
        <asp:DataList runat="server" ID="UnableToScreenAwvSpiroDataList" EnableViewState="false"
            RepeatLayout="Flow" CssClass="dtl-unabletoscreen-AwvSpiro unable-to-screen-section" GridLines="None"
            RepeatDirection="Horizontal">
            <ItemTemplate>
                <input type="checkbox" id="chkUnableScreenReason" />
                <b>Unable To Screen</b>
                <input type="hidden" id="hfUnableScreenReasonID" value='<%# Convert.ToString((int)DataBinder.Eval(Container.DataItem, "Reason")) %>' />
            </ItemTemplate>
        </asp:DataList>
    </div>
    <div class="lrow clear-all-selection">
        <a style="margin-left: 5px;" id="clear-all-spiro" href="javascript:void(0);" onclick="clearAllAwvSpiroSelection();">Clear All Selection</a>
    </div>
</div>
<div class="rgt_info1">
    <div class="rrow">
        <b>Technician Notes: </b>
        <br />
        <textarea id="technotesAwvSpiro" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
            rows="2" cols="54"></textarea>
    </div>
    <div class="rrow test-not-performed-section" id="testnotPerformedAwvSpiro">
        <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0" />
        <b>Test Not Performed</b>
        <div class="test-not-performed-container" style="display: none;">
            <b>Reason : </b>
            <br />
            <asp:DropDownList ID="ddlTestNotPerformedReasonAwvSpiro" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
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
<div class="left" style="width: 937px; padding: 3px;">
    <div class="contentrowltpad upload-media-section">
        <a href="javascript:OpenPopUp('Upload Media', '710', '/app/franchisee/technician/uploadTestImages.aspx?RestricttoOne=true&TestType=<%= (int)TestType.AwvSpiro %>&CustomerId=' + customerId);">Upload Media</a>
    </div>
    <div id="AwvSpiroImagesContainerDiv" class="contentrowltpad media-container-div" style="margin-top: 5px;">
    </div>
</div>
<div class="physician-section" style="float: left; width: 100%; clear: both; margin-top: 5px;">
    <fieldset style="float: left; width: 98%; border-radius: 4px;">
        <legend>Remarks </legend>
        <div style="float: left; width: 40%;">
            <input type="checkbox" id="technicallyltdbutreadableAwvSpiroinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Technically limited, but readable</b><br />
            <input type="checkbox" id="repeatstudyAwvSpiroinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Unreadable</b><br />
            <input type="checkbox" id="criticalAwvSpiro" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b>
        </div>
        <div style="float: left; width: 58%;">
            <textarea id="physicianRemarksAwvSpiro" rows="3" style="width: 98%;"></textarea>
        </div>
    </fieldset>
</div>
    </div>
<div id="awvSpiro_chat" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 50%;">
            <span class="org-heading" style="width: 100%;"><strong>Spirometry Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyAwvSpiro" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="AwvSpiro-critical-span">
        <input type="checkbox" id="DescribeSelfPresentAwvSpiroInputCheck" onclick="onClick_CriticalDataAwvSpiro();" />Critical </span>

        <span class="chk_orngband" id="awvSpiro-retest-span">
            <input type="checkbox" id="Retest_52" />Retest
        </span>
    </div>
    <div class="hrows awvSpiro-verificationpanel" style="color: Red; background: #fff0a5; border: solid 1px fff0a5; padding: 2px 2px 2px 5px; display: none;">
    </div>
    <div class="contentrow" style="width: 99%; padding-left: 0px;">
        <div class="hlfbox">
            <div class="hrows">
                <div class="nrow" style="margin-left: 12px;">
                    <input type="checkbox" id="chk_awvSpirocapturebyChat" />
                    <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
            <div class="hrows" style="width: 937px; padding: 3px;padding-left: 30px;">
                <div class="contentrowltpad upload-media-section">
                    <a href="javascript:OpenPopUp('Upload Media', '710', '/app/franchisee/technician/uploadTestImages.aspx?RestricttoOne=true&TestType=<%= (int)TestType.AwvSpiro %>&CustomerId=' + customerId);">Upload Media</a>
                </div>
                <div id="AwvSpiroImagesContainerDiv" class="contentrowltpad media-container-div" style="margin-top: 5px;">
                </div>
            </div>
        </div>
        <div style="float: left; clear: none; padding-top: 0" class="test-not-performed-section" id="testnotPerformedAwvSpiro">
            <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0" />
            <b>Test Not Performed</b>
            <div class="test-not-performed-container" style="display: none;">
                <b>Reason : </b>
                <br />
                <asp:DropDownList ID="ddlTestNotPerformedReasonAwvSpiro_CHAT" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
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
    var testTypeAwvSpiro = '<%= (long)TestType.AwvSpiro %>';
    var IsawvSpiroResultEntryExternaly = '<%=IsResultEntrybyChat%>';
    
    var awvSpiro = null;
    function SetAwvSpiroData(testResult) {
        awvSpiro = new AwvSpiro(testResult);
        awvSpiro.setData();
    }

    function GetAwvSpiroData() {
        if (awvSpiro == null) awvSpiro = new AwvSpiro();
        return awvSpiro.getData();
    }
</script>
