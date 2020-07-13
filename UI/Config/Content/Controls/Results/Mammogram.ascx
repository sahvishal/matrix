<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Mammogram.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.Mammogram" %>
<%@ Import Namespace="Falcon.App.Core.Application.Domain" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Domain" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>

<script type="text/javascript" src="/Config/Content/JavaScript/Mammogram.js?q=<%= VersionNumber %>"></script>


<div id="Mammogram_hip" runat="server">
    <div class="orange-band test-section-header">
        <h5>
            <span class="org-heading"><strong>Mammogram</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyMammogram" class="conductedby-ddl">
            </select>
        </span><span class="chk_orngband" id="Mammogram-critical-span">
            <input type="checkbox" id="DescribeSelfPresentMammogramInputCheck" onclick="onClick_CriticalDataMammogram();" />Critical</span>
        <span class="chk_orngband" id="Mammogram-priorityInQueue-span">
            <input type="checkbox" id="PriorityInQueueTestMammogramCheck" onclick="onClick_PriorityInQueueDataMammogram();" />Priority In Queue
        </span>
        <span class="chk_orngband" id="Mammogram-retest-span">
            <input type="checkbox" id="Retest_29" />Retest
        </span>
    </div>
    <div class="left_info1">
        <div class="labelwdt2 finding clear-all-Mammogram-selection" style="width: 300px;">
            <asp:GridView runat="server" ID="gvFindingsMammogram" AutoGenerateColumns="False" ShowHeader="False"
                EnableViewState="false" GridLines="None" CssClass="gv-findings-Mammogram finding-section">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="listchkbox">
                                <input type="radio" id="rbtFindingMammogram" name="rbtFindingMammogram" class="rbt-finding" />
                            </div>
                            <div class="lfttoppad"><%# DataBinder.Eval(Container.DataItem, "Label")%> <%# DataBinder.Eval(Container.DataItem, "Description")%></div>
                            <input type="hidden" id="FindingMammogramInputHidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                            <input type="hidden" class="finding-minvalue" value='<%# DataBinder.Eval(Container.DataItem, "MinValue")%>' />
                            <input type="hidden" class="finding-maxvalue" value='<%# DataBinder.Eval(Container.DataItem, "MaxValue")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <asp:DataList runat="server" ID="UnableToScreenmammogramDataList" EnableViewState="false"
                RepeatLayout="Flow" CssClass="dtl-unabletoscreen-Mammogram" GridLines="None" RepeatDirection="Horizontal">
                <ItemTemplate>
                    <input type="checkbox" id="chkUnableScreenReason" />
                    <b>Unable To Screen</b>
                    <input type="hidden" id="hfUnableScreenReasonID" value='<%# Convert.ToString((int)DataBinder.Eval(Container.DataItem, "Reason")) %>' />
                </ItemTemplate>
            </asp:DataList>
            <div class="lrow clear-all-selection">
                <a style="margin-left: 5px;" id="clear-all-Mammogram" href="javascript:void(0);" onclick="clearAllMammogramSelection();">Clear All Selection</a>
            </div>
        </div>
        <div style="float: left; width: 35%;">
            <div class="left" style="width: 150px; padding-right: 20px; text-align: center">
                <span class="left" style="width: 100%">
                    <img class="uploadmammogramPDF" alt="" src="/Content/Images/PageNotFound-Icons.jpg" /><br />
                    <b>Mammogram</b>
                </span>
                <span class="left upload-media-section" style="width: 100%; text-align: center;">
                    <a href="javascript:void(0);" class="pdf-mammogram-remove" style="display: none;">Remove </a>&nbsp;
                <a href="javascript:OpenPopUp('Upload PDF', '330', '/app/franchisee/technician/UploadAwvTestResultFile.aspx?TestType=<%= (long)TestType.Mammogram %>&height=110', 200);">Upload PDF </a>
                </span>
            </div>
        </div>
    </div>
    <div class="rgt_info1">
        <div class="rrow">
            <b>Technician Notes: </b>
            <br />
            <textarea id="technotesMammogram" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
                rows="2" cols="54"></textarea>
        </div>
        <div class="rrow test-not-performed-section" id="testnotPerformedMammogram">
            <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0" />
            <b>Test Not Performed</b>
            <div class="test-not-performed-container" style="display: none">
                <b>Reason : </b>
                <br />
                <asp:DropDownList ID="ddlTestNotPerformedReasonMammogram" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
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

<div id="Mammogram_chat" runat="server">
    <div class="orange-band test-section-header">
        <h5>
            <span class="org-heading"><strong>Mammogram</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyMammogram" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="Mammogram-critical-span">
            <input type="checkbox" id="DescribeSelfPresentMammogramInputCheck" onclick="onClick_CriticalDataMammogram();" />Critical</span>
        <span class="chk_orngband" id="Mammogram-retest-span">
            <input type="checkbox" id="Retest_29" />Retest
        </span>
    </div>
    <%-- <div class="contentrow" style="width: 99%; padding-left: 0px;">--%>
    <div class="left_info1">
        <div class="hlfbox">
            <div class="hrows">
                <div class="nrow" style="margin-left: 12px;">
                    <input type="checkbox" id="chk_mammogramcapturebyChat" />
                    <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
        </div>

        <div style="float: left; width: 35%;">
            <div class="left" style="width: 150px; margin-top: 10px; padding-right: 20px; text-align: center">
                <span class="left" style="width: 100%">
                    <img class="uploadmammogramPDF" alt="" src="/Content/Images/PageNotFound-Icons.jpg" /><br />
                    <b>Mammogram</b>
                </span>
                <span class="left upload-media-section" style="width: 100%; text-align: center;">
                    <a href="javascript:void(0);" class="pdf-mammogram-remove" style="display: none;">Remove </a>&nbsp;
                <a href="javascript:OpenPopUp('Upload PDF', '330', '/app/franchisee/technician/UploadAwvTestResultFile.aspx?TestType=<%= (long)TestType.Mammogram %>&height=110', 200);">Upload PDF </a>
                </span>
            </div>
        </div>

    </div>
    <div class="rgt_info1">
        <div style="float: left; clear: none; padding-top: 0" class="test-not-performed-section" id="testnotPerformedMammogram">
            <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0" />
            <b>Test Not Performed</b>
            <div class="test-not-performed-container" style="display: none">
                <b>Reason : </b>
                <br />
                <asp:DropDownList ID="ddlTestNotPerformedReasonMammogram_CHAT" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
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
    <%-- </div>--%>
</div>


<script type="text/javascript">
    testTypeMammogram = '<%= (long)TestType.Mammogram %>';
    fileTypeMammogramPDF = '<%=(long)FileType.Pdf %>';

    var isMammogramResultentrytype = '<%= IsResultEntrybyChat %>';

    var mammogram = null;
    function SetMammogramData(testResult) {
        mammogram = new Mammogram(testResult);
        mammogram.setData();
    }

    function GetMammogramData() {
        if (mammogram == null) mammogram = new Mammogram();
        return mammogram.getData();
    }

</script>
