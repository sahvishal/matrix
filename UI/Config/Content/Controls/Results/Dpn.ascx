<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Dpn.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.Dpn" %>
<%@ Import Namespace="Falcon.App.Core.Application.Domain" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/Dpn.js?q=<%= VersionNumber %>"></script>
<div id="dpn_hip" runat="server">
<div class="orange-band test-section-header">
    <h5>
        <span class="org-heading"><strong>Diabetic Peripheral Neuropathy</strong></span>
    </h5>
    <span class="chk_orngband">
        <select id="conductedbyDpn" class="conductedby-ddl">
        </select>
    </span><span class="chk_orngband" id="Dpn-critical-span">
        <input type="checkbox" id="DescribeSelfPresentDpnInputCheck" onclick="onClick_CriticalDataDpn();" />Critical
    </span>
    <span class="chk_orngband" id="Dpn-priorityInQueue-span">
        <input type="checkbox" id="PriorityInQueueTestDpnCheck" onclick="onClick_PriorityInQueueDataDpn();" />Priority In Queue
    </span>
    <span class="chk_orngband" id="Dpn-retest-span">
        <input type="checkbox" id="Retest_97" />Retest
    </span>
</div>
<div id="aaaContent">
    <div class="left_info1">
       
        <div class="lrow finding exclude-hide-evaluation" style="width: 150px; text-align: center;">
            <asp:GridView runat="server" ID="gvFindingsDpn" AutoGenerateColumns="False" ShowHeader="False"
                EnableViewState="false" GridLines="None" CssClass="gv-findings-Dpn finding-section">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="listchkbox">
                                <input type="radio" id="rbtFindingDpn" name="rbtFindingDpn" class="rbt-finding" />
                            </div>
                            <div class="lfttoppad">
                                <%# DataBinder.Eval(Container.DataItem, "Label")%>
                            </div>
                            <input type="hidden" id="FindingDpnInputHidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

        <div style="width: 150px; text-align: center;">
            <span class="left" style="width: 100%">
                <img style="float: left;" class="uploadDpnPDF" alt="" src="/Content/Images/PageNotFound-Icons.jpg" /><br />
            </span>
            <span class="left upload-media-section" style="width: 100%; text-align: left;">
                <a href="javascript:void(0);" class="pdf-dpn-remove" style="display: none; padding-left: 30px;">Remove </a>&nbsp;
                <a class="pdf-dpn-upload" href="javascript:OpenPopUp('Upload PDF', '330', '/app/franchisee/technician/UploadAwvTestResultFile.aspx?TestType=<%= (long)TestType.DPN %>&height=110', 200);">Upload PDF </a>
            </span>
        </div>
        <div class="lrow margin-top-small exclude-hide-evaluation">
            <asp:DataList runat="server" ID="UnableToScreenDpnDataList" CssClass="dtl-unabletoscreen-Dpn unable-to-screen-section"
                RepeatLayout="Flow" EnableViewState="false" GridLines="None" RepeatDirection="Horizontal">
                <ItemTemplate>
                    <input type="checkbox" id="chkUnableScreenReason" />
                    <b>&nbsp;<%# DataBinder.Eval(Container.DataItem, "DisplayName")%></b><input type="hidden" id="hfUnableScreenReasonID" value='<%# Convert.ToString((int)DataBinder.Eval(Container.DataItem, "Reason")) %>' />
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div class="lrow clear-all-selection">
            <a style="margin-left: 5px;" id="clear-all-Dpn" href="javascript:void(0);" onclick="clearAllDpnSelection();">Clear All Selection</a>
        </div>
          
        <div id="DpnImagesContainerDiv" class="contentrowltpad media-container-div" style="margin-top: 10px;">
            <a href="javascript:void(0)">
                <img src="/Config/Content/ResultPacket/content/DPNRefereneRanges.jpg" onclick="showImageForDpn('/Config/Content/ResultPacket/content/DPNRefereneRanges.jpg')" style="width: 100px; height: 100px;" />
            </a>
        </div>
    </div>
    <div class="rgt_info1">
        <div class="rgt_gbox">
            <div class="grow">
                <div style="padding-right: 10px; float: left;">
                    <strong>Amplitude:
                        <input type="text" id="DpnAmplitudeInputText" class="input_bdrbot" style="width: 80px;" onkeydown="return KeyPress_DecimalAllowedOnly(event);" />
                    </strong>
                </div>
                <div style="float: left;">
                    <strong>Conduction Velocity:
                        <input type="text" id="DpnConductionVelocityTextbox" class="input_bdrbot" style="width: 80px;" onkeydown="return KeyPress_DecimalAllowedOnly(event);" />
                    </strong>
                </div>

            </div>
            <div class="grow" style="margin-top: 10px;">
            </div>
            <div class="grow" style="margin-top: 10px;">
                <strong>
                    <span style="float: left; padding-right: 10px;">
                        <input type="checkbox" id="DpnRightLegCheckbox" />Right Leg 
                    </span>
                    <span style="float: left; padding-right: 10px;">
                        <input type="checkbox" id="DpnLeftLegCheckbox" />Left Leg
                    </span>
                </strong>
            </div>
        </div>
        <div class="rrow">
            <b>Technician Notes: </b>
            <br />
            <textarea id="technotesDpn" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
                rows="2" cols="54"></textarea>
        </div>
        <div class="rrow test-not-performed-section" id="testnotPerformedDpn">
            <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0" />
            <b>Test Not Performed</b>
            <div class="test-not-performed-container" style="display: none">
                <b>Reason : </b>
                <br />
                <asp:DropDownList ID="ddlTestNotPerformedReasonDpn" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
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
<div class="physician-section" style="float: left; width: 100%; clear: both; margin-top: 5px;">
    <fieldset style="float: left; width: 98%; border-radius: 4px;">
        <legend>Remarks </legend>
        <div style="float: left; width: 40%;">
            <div style="display: none">
                <input type="checkbox" id="technicallyltdbutreadableDpninputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Technically limited</b><br />
                <input type="checkbox" id="repeatstudyDpninputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Unreadable</b><br />
            </div>
            <input type="checkbox" id="criticalDpn" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b>
        </div>
        <div style="float: left; width: 58%;">
            <textarea id="physicianRemarksDpn" rows="3" style="width: 98%;"></textarea>
        </div>
    </fieldset>
</div>
</div>

<div id="dpn_chat" runat="server">
    <div class="orange-band test-section-header">
        <h5>
            <span class="org-heading"><strong>Diabetic Peripheral Neuropathy</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyDpn" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="Dpn-critical-span">
        <input type="checkbox" id="DescribeSelfPresentDpnInputCheck" onclick="onClick_CriticalDataDpn();" />Critical
    </span>

        <span class="chk_orngband" id="Dpn-retest-span">
            <input type="checkbox" id="Retest_97" />Retest
        </span>
    </div>
    <div class="contentrow" style="width: 99%; padding-left: 0px;">
        <div class="hlfbox">
            <div class="hrows">
                <div class="nrow" style="margin-left: 12px;">
                    <input type="checkbox" id="chk_dpncapturebyChat" />
                    <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
           <div style="width: 150px; text-align: center;">
                <span class="left" style="width: 100%">
                    <img style="float: left;" class="uploadDpnPDF" alt="" src="/Content/Images/PageNotFound-Icons.jpg" /><br />
                </span>
                <span class="left upload-media-section" style="width: 100%; text-align: left;">
                    <a href="javascript:void(0);" class="pdf-dpn-remove" style="display: none; padding-left: 30px;">Remove </a>&nbsp;
                <a class="pdf-dpn-upload" href="javascript:OpenPopUp('Upload PDF', '330', '/app/franchisee/technician/UploadAwvTestResultFile.aspx?TestType=<%= (long)TestType.DPN %>&height=110', 200);">Upload PDF </a>
                </span>
            </div>
            <%--<div class="left" style="width: 937px; padding: 3px;">
                <div class="contentrowltpad upload-media-section">
                    <a href="javascript:OpenPopUp('Upload PDF', '330', '/app/franchisee/technician/UploadAwvTestResultFile.aspx?TestType=<%= (long)TestType.DPN %>&height=110', 200);">Upload Media</a>
                </div>
                <div id="dpnImagesContainerDiv" class="contentrowltpad media-container-div" style="margin-top: 5px;">
                </div>
            </div>--%>
        </div>
        <div style="float: left;clear: none;padding-top: 0" class="test-not-performed-section" id="testnotPerformedDpn">
            <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0" />
            <b>Test Not Performed</b>
            <div class="test-not-performed-container" style="display: none">
                <b>Reason : </b>
                <br />
                <asp:DropDownList ID="ddlTestNotPerformedReasonDpn_CHAT" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
                </asp:DropDownList>
                <br />
                <div>
                    <b>Notes :            <b>Notes :</b>
                    <br />
                    <textarea rows="2" cols="54"></textarea>
                </div>
            </div>
        </div>
     </div>
    <div style="float: left;clear: both;padding-left: 15px">
        
          
    </div>
</div>


<script language="javascript" type="text/javascript">
    var testTypeDpn = '<%= (long)TestType.DPN %>';

    fileTypeDPNPDF = '<%=(long)FileType.Pdf %>';

    var isDPNResultEntryType = '<%= IsResultEntrybyChat %>';

    var dpnTest = null;
    function SetDpnData(testResult) {
        dpnTest = new Dpn(testResult);
        dpnTest.setData();
    }

    function GetDpnData() {
        if (dpnTest == null) dpnTest = new Dpn();
        return dpnTest.getData();
    }


    function showImageForDpn(src) {
        $(".media-navigation-next").hide();
        $(".media-navigation-prev").hide();
        onImageClick(src);

    }
</script>
