<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IFOBT.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.IFOBT" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<%@ Import Namespace="Falcon.App.Core.Application.Domain" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/IFOBT.js?q=<%= VersionNumber %>"></script>
<div id="IFOBT_hip" runat="server">
    <div class="orange-band test-section-header">
        <h5>
            <span class="org-heading"><strong>IFOBT Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyIFOBT" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="IFOBT-critical-span">
            <input type="checkbox" id="DescribeSelfPresentIFOBTInputCheck" onclick="onClick_CriticalDataIFOBT();" />Critical </span>
        <span class="chk_orngband" id="IFOBT-priorityInQueue-span">
            <input type="checkbox" id="PriorityInQueueTestIFOBTCheck" onclick="onClick_PriorityInQueueDataIFOBT();" />Priority In Queue
        </span>
        <span class="chk_orngband" id="IFOBT-retest-span">
            <input type="checkbox" id="Retest_75" />Retest
        </span>
    </div>
    <div class="left_info1">
        <div style="width: 150px; text-align: center;">
            <span class="left" style="width: 100%">
                <img class="uploadIfobtPDF" alt="" src="/Content/Images/PageNotFound-Icons.jpg" /><br />
                <b>IFOBT</b>
            </span>
            <span class="left upload-media-section" style="width: 100%; text-align: center;">
                <a href="javascript:void(0);" class="pdf-ifobt-remove" style="display: none;">Remove </a>&nbsp;
        <a href="javascript:OpenPopUp('Upload PDF', '330', '/app/franchisee/technician/UploadAwvTestResultFile.aspx?TestType=<%= (long)TestType.IFOBT %>&height=110', 200);">Upload PDF </a>
            </span>
        </div>
        <div style="margin-bottom: 10px; width: 275px; margin-left: 193px;">
            <asp:DataList runat="server" ID="gvFindingsIFOBT" CssClass="gv-findings-IFOBT finding-section"
                RepeatDirection="Horizontal" RepeatColumns="4" EnableViewState="false">
                <ItemTemplate>
                    <input type="radio" id="rbtFindingIFOBT" name="rbtFindingIFOBT" class="rbt-finding" />
                    <%# DataBinder.Eval(Container.DataItem, "Label") %>
                    <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                    <input type="hidden" class="finding-minvalue" value='<%# DataBinder.Eval(Container.DataItem, "MinValue")%>' />
                    <input type="hidden" class="finding-maxvalue" value='<%# DataBinder.Eval(Container.DataItem, "MaxValue")%>' />
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div style="width: 275px; margin-left: 196px;">
            Serial Number:<input type="text" id="SerialKeyInputtext" maxlength="20" class="input_bdrbot" style="width: 130px" onkeydown="return txtkeypress_AlphanumericOnly(event);" />
        </div>
        <div style="width: 275px; margin-left: 196px; margin-top: 25px;">
            <asp:DataList runat="server" ID="dtlIFOBTSelectedUnableToScreen" GridLines="None"
                EnableViewState="false" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="dtl-unabletoscreen-IFOBT unable-to-screen-section">
                <ItemTemplate>
                    <input type="checkbox" id="chkUnableScreenReason" class="chk-selected-IFOBT-us" />
                    <b><%# DataBinder.Eval(Container.DataItem, "DisplayName") %></b>
                    <input type="hidden" id="hfUnableScreenReasonID" class="hdn-selected-IFOBT-us" value='<%# Convert.ToString((int)DataBinder.Eval(Container.DataItem, "Reason")) %>' />
                </ItemTemplate>
            </asp:DataList>
            <div class="lrow clear-all-selection">
                <a style="margin-left: 5px;" id="clear-all-IFOBT" href="javascript:void(0);" onclick="clearAllIFOBTSelection();">Clear All Selection</a>
            </div>
        </div>
    </div>

    <div class="rgt_info1">

        <div class="rrow">
            <b>Technician Notes: </b>
            <br />
            <textarea id="technotesIFOBT" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
                rows="2" cols="54"></textarea>
        </div>
        <div class="rrow test-not-performed-section" id="testnotPerformedIFOBT">
            <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0" />
            <b>Test Not Performed</b>
            <div class="test-not-performed-container" style="display: none">
                <b>Reason : </b>
                <br />
                <asp:DropDownList ID="ddlTestNotPerformedReasonIFOBT" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
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
                <div style="display: none;">
                    <input type="checkbox" id="technicallyltdbutreadableIFOBTinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Technically limited, but readable</b><br />
                    <input type="checkbox" id="repeatstudyIFOBTinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Unreadable</b><br />
                </div>
                <input type="checkbox" id="criticalIFOBT" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b>
            </div>
            <div style="float: left; width: 58%;">
                <textarea id="physicianRemarksIFOBT" rows="3" style="width: 98%;"></textarea>
            </div>
        </fieldset>
    </div>

</div>

<div id="IFOBT_chat" runat="server">
     <div class="orange-band test-section-header">
        <h5>
            <span class="org-heading"><strong>IFOBT Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyIFOBT" class="conductedby-ddl">
            </select>
        </span>
         <span class="chk_orngband" id="IFOBT-critical-span">
            <input type="checkbox" id="DescribeSelfPresentIFOBTInputCheck" onclick="onClick_CriticalDataIFOBT();" />Critical </span>

        <span class="chk_orngband" id="IFOBT-retest-span">
            <input type="checkbox" id="Retest_75" />Retest
        </span>
    </div>
    <div class="contentrow "  style="min-height: 50px;" >
         <div class="left_info">
                <div class="nrow" style="margin-left: 12px;">
                    <input type="checkbox" id="chk_IFOBTcapturebyChat" />
                    <b>Entry Completed in CHAT </b>
                </div>
            </div>
        <div class="rgt_info" style="padding-top: 0">
            <div class=" test-not-performed-section" id="testnotPerformedIFOBT" style="padding-top: 0">
                <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0" />
                <b>Test Not Performed</b>
                <div class="test-not-performed-container" style="display: none">
                    <b>Reason : </b>
                    <br />
                    <asp:DropDownList ID="ddlTestNotPerformedReasonIFOBT_chat" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
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
</div>

<script language="javascript" type="text/javascript">
    var testTypeIFOBT = '<%= (long)TestType.IFOBT %>';
    fileTypeIfobtPDF = '<%=(long)FileType.Pdf %>';

    var isIFOBTResultEntryType = '<%= IsResultEntrybyChat %>';

    var ifobt = null;
    function SetIFOBTData(testResult) {
        ifobt = new IFOBT(testResult);
        ifobt.setData();
    }

    function GetIFOBTData() {
        if (ifobt == null) ifobt = new IFOBT();
        return ifobt.getData();
    }

</script>
