<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DiabeticRetinopathy.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.DiabeticRetinopathy" %>
<%@ Import Namespace="Falcon.App.Core.Application.Domain" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Domain" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>

<script type="text/javascript" src="/Config/Content/JavaScript/DiabeticRetinopathy.js?q=<%= VersionNumber %>"></script>

<div id="DiabeticRetinopathy_hip" runat="server">
    <div class="orange-band test-section-header">
        <h5>
            <span class="org-heading"><strong>Diabetic Retinopathy Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyDiabeticRetinopathy" class="conductedby-ddl">
            </select>
        </span><span class="chk_orngband" id="DiabeticRetinopathy-critical-span">
            <input type="checkbox" id="DescribeSelfPresentDiabeticRetinopathyInputCheck" onclick="onClick_CriticalDataDiabeticRetinopathy();" />Critical</span>
        <span class="chk_orngband" id="diabeticRetinopathy-priorityInQueue-span">
            <input type="checkbox" id="PriorityInQueueTestDiabeticRetinopathyCheck" onclick="onClick_PriorityInQueueDataDiabeticRetinopathy();" />Priority In Queue
        </span>
        <span class="chk_orngband" id="diabeticRetinopathy-retest-span">
            <input type="checkbox" id="Retest_73" />Retest
        </span>
    </div>
    <div class="left_info1">

        <div class="clear-all-DiabeticRetinopathy-selection" style="float: left; clear: both; margin-bottom: 5px; width: 100%">
            <div>
                <b>Diabetic Retinopathy Highest Level Of Specificity</b>
            </div>
            <div>
                <asp:DataList runat="server" ID="DiabeticRetinopathyHighestLevelOfSpecificity" CssClass="DiabeticRetinopathy-HighestLevel-finding gv-Findings-DiabeticRetinopathy"
                    GridLines="None" EnableViewState="false" RepeatDirection="Horizontal">
                    <ItemTemplate>
                        <input type="radio" name="DiabeticRetinopathy-finding-Level" class="rbt-finding" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                        <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                        <input type="hidden" class="finding-worstcaseorder" value='<%# DataBinder.Eval(Container.DataItem, "WorstCaseOrder")%>' />
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
        <div class="clear-all-DiabeticRetinopathy-selection" style="float: left; clear: both; margin-bottom: 5px; width: 100%">
            <div>
                <b>Macular Edema Highest Level Of Specificity</b>
            </div>
            <div>
                <asp:DataList runat="server" ID="DiabeticRetinopathyMacularEdemaLevelOfSpecificity" CssClass="DiabeticRetinopathy-Macular-Edema-finding gv-Findings-DiabeticRetinopathy"
                    GridLines="None" EnableViewState="false" RepeatDirection="Horizontal">
                    <ItemTemplate>
                        <input type="radio" name="Macular-Edema-finding-Level" class="rbt-finding" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                        <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                        <input type="hidden" class="finding-worstcaseorder" value='<%# DataBinder.Eval(Container.DataItem, "WorstCaseOrder")%>' />
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>

        <div style="float: left;">
            <div>
                <b>Has Suspected</b>
            </div>
            <div class="margin-top-small gv-reading-DiabeticRetinopathy" style="float: left; width: 150px;">
                <input type="checkbox" id="DiabeticRetinopathySuspectedVeinOcclusion" />
                Vein Occlusion
            </div>
            <div class="margin-top-small gv-reading-DiabeticRetinopathy" style="float: left; width: 100px;">
                <input type="checkbox" id="DiabeticRetinopathySuspectedWetAmd" />
                Wet Amd
            </div>
            <div class="margin-top-small gv-reading-DiabeticRetinopathy" style="float: left; width: 90px;">
                <input type="checkbox" id="DiabeticRetinopathySuspectedDryAmd" />
                Dry Amd
            </div>
            <div class="margin-top-small gv-reading-DiabeticRetinopathy" style="float: left; width: 130px;">
                <input type="checkbox" id="DiabeticRetinopathySuspectedHtnRetinopathy" />
                Htn Retinopath
            </div>
            <div class="margin-top-small gv-reading-DiabeticRetinopathy" style="float: left; width: 150px;">
                <input type="checkbox" id="DiabeticRetinopathySuspectedEpiretinalMembrane" />
                Epiretinal Membrane
            </div>
            <div class="margin-top-small gv-reading-DiabeticRetinopathy" style="float: left; width: 100px;">
                <input type="checkbox" id="DiabeticRetinopathySuspectedMacularHole" />
                Macular Hole
            </div>
            <div class="margin-top-small gv-reading-DiabeticRetinopathy" style="float: left; width: 90px;">
                <input type="checkbox" id="DiabeticRetinopathySuspectedCataract" />
                Cataract
            </div>
            <div class="margin-top-small gv-reading-DiabeticRetinopathy" style="float: left; width: 130px;">
                <input type="checkbox" id="DiabeticRetinopathySuspectedOtherDisease" />
                Other Disease
            </div>
            <div class="margin-top-small gv-reading-DiabeticRetinopathy" style="float: left; width: 150px;">
                <input type="checkbox" id="DiabeticRetinopathySuspectedGlaucoma" />
                Glaucoma
            </div>
        </div>

        <div style="float: left; margin-top: 10px; width: 98%;">
            <div class="left" style="width: 150px; padding-right: 20px; text-align: center">
                <span class="left" style="width: 100%">
                    <img class="uploaddiabeticRetinopathyPDF" alt="" src="/Content/Images/PageNotFound-Icons.jpg" /><br />
                    <b>Diabetic Retinopathy</b>
                </span>
                <span class="left" style="width: 100%; text-align: center;">
                    <a href="javascript:void(0);" class="pdf-diabeticRetinopathy-remove" style="display: none;">Remove </a>&nbsp;
                <a href="javascript:OpenPopUp('Upload PDF', '330', '/app/franchisee/technician/UploadAwvTestResultFile.aspx?TestType=<%= (long)TestType.DiabeticRetinopathy %>&height=110', 200);">Upload PDF </a>
                </span>
            </div>
        </div>
        <div class="labelwdt2 finding">
            <asp:DataList runat="server" ID="UnableToScreenDiabeticRetinopathyDataList" EnableViewState="false"
                RepeatLayout="Flow" CssClass="dtl-unabletoscreen-DiabeticRetinopathy" GridLines="None" RepeatDirection="Horizontal">
                <ItemTemplate>
                    <input type="checkbox" id="chkUnableScreenReason" />
                    <b>Unable To Screen</b>
                    <input type="hidden" id="hfUnableScreenReasonID" value='<%# Convert.ToString((int)DataBinder.Eval(Container.DataItem, "Reason")) %>' />
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
    <div class="rgt_info1">
        <div class="rrow">
            <b>Technician Notes: </b>
            <br />
            <textarea id="technotesDiabeticRetinopathy" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
                rows="2" cols="54"></textarea>
        </div>
        <div class="rrow test-not-performed-section" id="testnotPerformedDiabeticRetinopathy">
            <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0" />
            <b>Test Not Performed</b>
            <div class="test-not-performed-container" style="display: none">
                <b>Reason : </b>
                <br />
                <asp:DropDownList ID="ddlTestNotPerformedReasonDiabeticRetinopathy" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
                </asp:DropDownList>
                <br />
                <div>
                    <b>Notes :</b>
                    <br />
                    <textarea rows="2" cols="54"></textarea>
                </div>
            </div>
        </div>
        <div class="lrow clear-all-selection" style="padding-top: 10px;">
            <a style="margin-left: 5px;" id="clear-all-DiabeticRetinopathy" href="javascript:void(0);" onclick="clearAllDiabeticRetinopathySelection();">Clear All Selection</a>
        </div>
    </div>

</div>
<div id="DiabeticRetinopathy_chat" runat="server">
    <div class="orange-band test-section-header">
        <h5>
            <span class="org-heading"><strong>Diabetic Retinopathy Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyDiabeticRetinopathy" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="DiabeticRetinopathy-critical-span">
            <input type="checkbox" id="DescribeSelfPresentDiabeticRetinopathyInputCheck" onclick="onClick_CriticalDataDiabeticRetinopathy();" />Critical</span>

        <span class="chk_orngband" id="diabeticRetinopathy-retest-span">
            <input type="checkbox" id="Retest_73" />Retest
        </span>
    </div>
    <div class="contentrow" style="width: 99%; padding-left: 0px;">
        <div class="hlfbox">
            <div class="hrows">
                <div class="nrow" style="margin-left: 12px;">
                    <input type="checkbox" id="chk_DiabeticRetinopathycapturebyChat" />
                    <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
            <div style="float: left; clear: both; margin-top: 10px; width: 98%;">
                <div class="left" style="width: 150px; padding-right: 20px; text-align: center">
                    <span class="left" style="width: 100%">
                        <img class="uploaddiabeticRetinopathyPDF" alt="" src="/Content/Images/PageNotFound-Icons.jpg" /><br />
                        <b>Diabetic Retinopathy</b>
                    </span>
                    <span class="left" style="width: 100%; text-align: center;">
                        <a href="javascript:void(0);" class="pdf-diabeticRetinopathy-remove" style="display: none;">Remove </a>&nbsp;
                <a href="javascript:OpenPopUp('Upload PDF', '330', '/app/franchisee/technician/UploadAwvTestResultFile.aspx?TestType=<%= (long)TestType.DiabeticRetinopathy %>&height=110', 200);">Upload PDF </a>
                    </span>
                </div>
            </div>
        </div>
        <div style="float: left;clear: none;padding-top: 0" class="test-not-performed-section" id="testnotPerformedDiabeticRetinopathy">
                <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0" />
                <b>Test Not Performed</b>
                <div class="test-not-performed-container" style="display: none">
                    <b>Reason : </b>
                    <br />
                    <asp:DropDownList ID="ddlTestNotPerformedReasonDiabeticRetinopathy_CHAT" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
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


<script type="text/javascript">
    testTypeDiabeticRetinopathy = '<%= (long)TestType.DiabeticRetinopathy %>';
    fileTypePDF = '<%=(long)FileType.Pdf %>';

    var isDiabeticRetinopathyResultEntryType = '<%= IsResultEntrybyChat %>';

    var diabeticRetinopathy = null;
    function SetDiabeticRetinopathyData(testResult) {
        diabeticRetinopathy = new DiabeticRetinopathy(testResult);
        diabeticRetinopathy.setData();
    }

    function GetDiabeticRetinopathyData() {
        if (diabeticRetinopathy == null) diabeticRetinopathy = new DiabeticRetinopathy();
        return diabeticRetinopathy.getData();
    }

</script>
