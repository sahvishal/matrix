<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UrineMicroalbumin.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.UrineMicroalbumin" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<%@ Import Namespace="Falcon.App.Core.Application.Domain" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/UrineMicroalbumin.js?q=<%= VersionNumber%>"></script>



<div id="UrineMicroalbumin_hip" runat="server">

    <div class="orange-band test-section-header">
        <h5>
            <span class="org-heading"><strong>Urine Microalbumin Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyUrineMicroalbumin" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="UrineMicroalbumin-critical-span">
            <input type="checkbox" id="DescribeSelfPresentUrineMicroalbuminInputCheck" onclick="onClick_CriticalDataUrineMicroalbumin();" />Critical </span>
        <span class="chk_orngband" id="UrineMicroalbumin-priorityInQueue-span">
            <input type="checkbox" id="PriorityInQueueTestUrineMicroalbuminCheck" onclick="onClick_PriorityInQueueDataUrineMicroalbumin();" />Priority In Queue
        </span>
        <span class="chk_orngband" id="UrineMicroalbumin-retest-span">
            <input type="checkbox" id="Retest_89" />Retest
        </span>
    </div>
    <div class="left_info1">
        <div class="lrow finding" style="margin-top: 10px;">
            <asp:GridView runat="server" Style="float: left;" ID="StandardFindingsUrineMicroalbuminGridView"
                EnableViewState="false" AutoGenerateColumns="False" ShowHeader="False" GridLines="None"
                CssClass="gv-findings-UrineMicroalbumin finding-section">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <input type="radio" name="rbtTg" class="listchkbox rbt-finding" />
                            <input type="hidden" id="UrineMicroalbuminFindingInputHidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                            <input type="hidden" class="finding-minvalue" value='<%# DataBinder.Eval(Container.DataItem, "MinValue")%>' />
                            <input type="hidden" class="finding-maxvalue" value='<%# DataBinder.Eval(Container.DataItem, "MaxValue")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <label class="carotidgboxtxt1 urnlbl"><%# DataBinder.Eval(Container.DataItem, "Label")%></label>
                            <label class="urnDescription"><%# DataBinder.Eval(Container.DataItem, "Description")%></label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div style="width: 150px; text-align: center; margin-top: 10px; float: left; padding-right: 20px">
            <span class="left" style="width: 100%">
                <img class="uploadUrineMicroalbuminPDF" alt="" src="/Content/Images/PageNotFound-Icons.jpg" /><br />
                <b>Urine Microalbumin</b>
            </span>
            <span class="left upload-media-section" style="width: 100%; text-align: center;">
                <a href="javascript:void(0);" class="pdf-UrineMicroalbumin-remove" style="display: none;">Remove </a>&nbsp;
        <a href="javascript:OpenPopUp('Upload PDF', '330', '/app/franchisee/technician/UploadAwvTestResultFile.aspx?TestType=<%= (long)TestType.UrineMicroalbumin %>&height=110', 200);">Upload PDF </a>
            </span>
        </div>
        <div style="margin-top: 15px; float: left;">
            <%--Microalbumin Value:<input type="text" id="MicroalbuminValueKeyInputtext" maxlength="5" class="input_bdrbot" style="width: 130px" onkeydown="return KeyPress_DecimalAllowedOnly(event);" />--%>
        Microalbumin Value:<input type="text" id="MicroalbuminValueKeyInputtext" maxlength="5" class="input_bdrbot" style="width: 130px" />
        </div>
        <div style="margin-top: 15px; float: left;">
            Serial Number:<input type="text" id="MicroalbuminSerialKeyInputtext" maxlength="20" class="input_bdrbot" style="width: 130px" onkeydown="return txtkeypress_AlphanumericOnly(event);" />
        </div>

        <div style="margin-top: 20px; float: left;">

            <asp:DataList runat="server" ID="dtlUrineMicroalbuminSelectedUnableToScreen" GridLines="None"
                EnableViewState="false" RepeatLayout="Flow" RepeatDirection="Horizontal" CssClass="dtl-unabletoscreen-UrineMicroalbumin unable-to-screen-section">
                <ItemTemplate>
                    <input type="checkbox" id="chkUnableScreenReason" class="chk-selected-UrineMicroalbumin-us" />
                    <b><%# DataBinder.Eval(Container.DataItem, "DisplayName") %></b>
                    <input type="hidden" id="hfUnableScreenReasonID" class="hdn-selected-UrineMicroalbumin-us" value='<%# Convert.ToString((int)DataBinder.Eval(Container.DataItem, "Reason")) %>' />
                </ItemTemplate>
            </asp:DataList>
            <div class="lrow clear-all-selection">
                <a style="margin-left: 5px;" id="clear-all-UrineMicroalbumin" href="javascript:void(0);" onclick="clearAllUrineMicroalbuminSelection();">Clear All Selection</a>
            </div>
        </div>
    </div>
    <div class="rgt_info1">
        <div class="rrow">
            <b>Technician Notes: </b>
            <br />
            <textarea id="technotesUrineMicroalbumin" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
                rows="2" cols="54"></textarea>
        </div>
        <div class="rrow test-not-performed-section" id="testnotPerformedUrineMicroalbumin">
            <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0" />
            <b>Test Not Performed</b>
            <div class="test-not-performed-container" style="display: none;">
                <b>Reason : </b>
                <br />
                <asp:DropDownList ID="ddlTestNotPerformedReasonUrineMicroalbumin" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
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
                    <input type="checkbox" id="technicallyltdbutreadableUrineMicroalbumininputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Technically limited, but readable</b><br />
                    <input type="checkbox" id="repeatstudyUrineMicroalbumininputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Unreadable</b><br />
                </div>
                <input type="checkbox" id="criticalUrineMicroalbumin" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b>
            </div>
            <div style="float: left; width: 58%;">
                <textarea id="physicianRemarksUrineMicroalbumin" rows="3" style="width: 98%;"></textarea>
            </div>
        </fieldset>
    </div>
</div>

<div id="UrineMicroalbumin_chat" runat="server">
    <div class="orange-band test-section-header">
        <h5>
            <span class="org-heading"><strong>Urine Microalbumin Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyUrineMicroalbumin" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="UrineMicroalbumin-critical-span">
            <input type="checkbox" id="DescribeSelfPresentUrineMicroalbuminInputCheck" onclick="onClick_CriticalDataUrineMicroalbumin();" />Critical </span>

        <span class="chk_orngband" id="UrineMicroalbumin-retest-span">
            <input type="checkbox" id="Retest_89" />Retest
        </span>
    </div>
    <div class="contentrow" style="min-height: 50px;" >
        <div class="left_info">
            <div class="hrows">
                <div class="nrow" style="margin-left: 12px;">
                    <input type="checkbox" id="chk_urineMicroalbumincapturebyChat" />
                    <b>Entry Completed in CHAT </b>
                </div>
            </div>
        </div>
        <div class="rgt_info" style="padding-top: 0">
            <div class="test-not-performed-section" id="testnotPerformedUrineMicroalbumin" style="padding-top: 0">
                <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0" />
                <b>Test Not Performed</b>
                <div class="test-not-performed-container" style="display: none;">
                    <b>Reason : </b>
                    <br />
                    <asp:DropDownList ID="ddlTestNotPerformedReasonUrineMicroalbumin_chat" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
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
    var testTypeUrineMicroalbumin = '<%= (long)TestType.UrineMicroalbumin %>';
    fileTypeUrineMicroalbuminPDF = '<%=(long)FileType.Pdf %>';

    var isUrineMicroalbuminResultEntryType = '<%= IsResultEntrybyChat %>';

    var urineMicroalbumin = null;
    function SetUrineMicroalbuminData(testResult) {
        urineMicroalbumin = new UrineMicroalbumin(testResult);
        urineMicroalbumin.setData();
    }

    function GetUrineMicroalbuminData() {
        if (urineMicroalbumin == null) urineMicroalbumin = new UrineMicroalbumin();
        return urineMicroalbumin.getData();
    }

</script>
