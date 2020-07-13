<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AwvBoneMass.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.AwvBoneMass" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<%@ Import Namespace="Falcon.App.Core.Application.Domain" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/AwvBoneMass.js?q=<%= VersionNumber %>"></script>

<div id="AwvBoneMass_hip" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
<div class="orange-band test-section-header">
    <h5>
        <span class="org-heading"><strong>Bone Mass Measurement Results</strong></span>
    </h5>
    <span class="chk_orngband">
        <select id="conductedbyAwvBoneMass" class="conductedby-ddl">
        </select>
    </span><span class="chk_orngband" id="AwvBoneMass-critical-span">
        <input type="checkbox" id="DescribeSelfPresentAwvBoneMassInputCheck" onclick="onClick_CriticalDataAwvBoneMass();" />Critical </span>
    <span class="chk_orngband" id="awvBoneMass-priorityInQueue-span">
        <input type="checkbox" id="PriorityInQueueTestAwvBoneMassCheck" onclick="onClick_PriorityInQueueDataAwvBoneMass();" />Priority In Queue
    </span>
    <span class="chk_orngband" id="awvBoneMass-retest-span">
        <input type="checkbox" id="Retest_60" />Retest
    </span>
</div>
<div class="left_info1">
    <div style="width: 150px; text-align: center;">
        <span class="left" style="width: 100%">
            <img style="float: left;" class="uploadAwvBoneMassPDF" alt="" src="/Content/Images/PageNotFound-Icons.jpg" /><br />
        </span>
        <span class="left upload-media-section" style="width: 100%; text-align: left;">
            <a href="javascript:void(0);" class="pdf-awvbonemass-remove" style="display: none;">Remove </a>&nbsp;
        <a class="pdf-awvbonemass-upload" href="javascript:OpenPopUp('Upload PDF', '330', '/app/franchisee/technician/UploadAwvTestResultFile.aspx?TestType=<%= (long)TestType.AwvBoneMass %>&height=110', 200);">Upload PDF </a>
        </span>
    </div>
    <div class="labelwdt2 finding">
        <asp:GridView runat="server" ID="gvFindingsAwvBoneMass" AutoGenerateColumns="False" ShowHeader="False"
            EnableViewState="false" GridLines="None" CssClass="gv-findings-AwvBoneMass finding-section">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <div class="listchkbox">
                            <input type="radio" id="rbtFindingAwvBoneMass" name="rbtFindingAwvBoneMass" class="rbt-finding" />
                        </div>
                        <div class="lfttoppad">
                            <%# DataBinder.Eval(Container.DataItem, "Label")%>
                            (<%# DataBinder.Eval(Container.DataItem, "Description")%>)
                        </div>
                        <input type="hidden" id="FindingAwvBoneMassInputHidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                        <input type="hidden" class="finding-minvalue" value='<%# DataBinder.Eval(Container.DataItem, "MinValue")%>' />
                        <input type="hidden" class="finding-maxvalue" value='<%# DataBinder.Eval(Container.DataItem, "MaxValue")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div class="lrow margin-top-small">
        <asp:DataList runat="server" ID="UnableToScreenAwvBoneMassDataList" EnableViewState="false"
            RepeatLayout="Flow" CssClass="dtl-unabletoscreen-AwvBoneMass unable-to-screen-section" GridLines="None"
            RepeatDirection="Horizontal">
            <ItemTemplate>
                <input type="checkbox" id="chkUnableScreenReason" />
                <b>Unable To Screen</b>
                <input type="hidden" id="hfUnableScreenReasonID" value='<%# Convert.ToString((int)DataBinder.Eval(Container.DataItem, "Reason")) %>' />
            </ItemTemplate>
        </asp:DataList>
    </div>
    <div class="lrow clear-all-selection">
        <a style="margin-left: 5px;" id="clear-all-pad" href="javascript:void(0);" onclick="clearAllAwvBoneMassSelection();">Clear All Selection</a>
    </div>
</div>
<div class="rgt_info1">
    <div style="height: 40px; float: right;" class="rgtgbox_singleReading">
        <div class="grow">
            <div class="right">
                Est. Heel BMD T.Score
                <input type="text" id="txtAwvBoneMassTscore" class="input_bdrbot" onkeydown="return KeyPress_DecimalAllowedOnly_withsigns(event);"
                    style="width: 50px" />
            </div>
        </div>
    </div>
    <div class="rrow">
        <b>Technician Notes: </b>
        <br />
        <textarea id="technotesAwvBoneMass" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
            rows="2" cols="54"></textarea>
    </div>
    <div class="rrow test-not-performed-section" id="testnotPerformedAwvBoneMass">
        <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0" />
        <b>Test Not Performed</b>
        <div class="test-not-performed-container" style="display: none;">
            <b>Reason : </b>
            <br />
            <asp:DropDownList ID="ddlTestNotPerformedReasonAwvBoneMass" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
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
            <div style="display: none;">
                <input type="checkbox" id="repeatstudyAwvBoneMassinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Repeat Study</b><br />
            </div>
            <input type="checkbox" id="criticalAwvBoneMass" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b>
        </div>
        <div style="float: left; width: 58%;">
            <textarea id="physicianRemarksAwvBoneMass" rows="3" style="width: 98%;"></textarea>
        </div>
    </fieldset>
</div>
    </div>
<div id="AwvBoneMass_chat" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 50%;">
            <span class="org-heading" style="width: 100%;"><strong>Bone Mass Measurement Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyAwvBoneMass" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="awvBoneMass-retest-span">
            <input type="checkbox" id="Retest_60" />Retest
        </span>
    </div>

    <div class="contentrow" style="width: 99%; padding-left: 0px;">
        <div class="hlfbox">
            <div class="hrows">
                <div class="nrow" style="margin-left: 12px;">
                    <input type="checkbox" id="chk_AwvBoneMasscapturebyChat" />
                    <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
            <div class="hrows" style="padding-left: 30px">
                <div style="width: 150px; text-align: center;">
                    <span class="left" style="width: 100%">
                        <img style="float: left;" class="uploadAwvBoneMassPDF" alt="" src="/Content/Images/PageNotFound-Icons.jpg" /><br />
                    </span>
                    <span class="left upload-media-section" style="width: 100%; text-align: left;">
                        <a href="javascript:void(0);" class="pdf-awvbonemass-remove" style="display: none;">Remove </a>&nbsp;
        <a class="pdf-awvbonemass-upload" href="javascript:OpenPopUp('Upload PDF', '330', '/app/franchisee/technician/UploadAwvTestResultFile.aspx?TestType=<%= (long)TestType.AwvBoneMass %>&height=110', 200);">Upload PDF </a>
                    </span>
                </div>
            </div>
        </div>
        <div style="float: left;clear: none;padding-top: 0"  class="test-not-performed-section" id="testnotPerformedAwvBoneMass">
            <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0" />
            <b>Test Not Performed</b>
            <div class="test-not-performed-container" style="display: none;">
                <b>Reason : </b>
                <br />
                <asp:DropDownList ID="ddlTestNotPerformedReasonAwvBoneMass_CHAT" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
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
    var testTypeAwvBoneMass = '<%= (long)TestType.AwvBoneMass %>';
    fileTypeAwvBoneMassPDF = '<%=(long)FileType.Pdf %>';
    var IsAwvBoneMassResultEntryExternaly = '<%= IsResultEntrybyChat %>';
    var awvBoneMass = null;
    function SetAwvBoneMassData(testResult) {
        awvBoneMass = new AwvBoneMass(testResult);
        awvBoneMass.setData();
    }

    function GetAwvBoneMassData() {
        if (awvBoneMass == null) awvBoneMass = new AwvBoneMass();
        return awvBoneMass.getData();
    }

</script>
