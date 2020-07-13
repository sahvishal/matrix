<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DiabeticNeuropathy.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.DiabeticNeuropathy" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/DiabeticNeuropathy.js?q=<%= VersionNumber %>"></script>

<div id="DiabeticNeuropathy_hip" runat="server">
    <div class="orange-band test-section-header">
        <h5>
            <span class="org-heading"><strong>Diabetic Neuropathy</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyDiabeticNeuropathy" class="conductedby-ddl">
            </select>
        </span><span class="chk_orngband" id="DiabeticNeuropathy-critical-span">
            <input type="checkbox" id="DescribeSelfPresentDiabeticNeuropathyInputCheck" onclick="onClick_CriticalDataDiabeticNeuropathy();" />Critical
        </span>
        <span class="chk_orngband" id="DiabeticNeuropathy-priorityInQueue-span">
            <input type="checkbox" id="PriorityInQueueTestDiabeticNeuropathyCheck" onclick="onClick_PriorityInQueueDataDiabeticNeuropathy();" />Priority In Queue
        </span>
        <span class="chk_orngband" id="DiabeticNeuropathy-retest-span">
            <input type="checkbox" id="Retest_70" />Retest
        </span>
    </div>
    <div id="aaaContent">
        <div class="left_info1">
            <div class="lrow finding exclude-hide-evaluation">
                <asp:GridView runat="server" ID="gvFindingsDiabeticNeuropathy" AutoGenerateColumns="False" ShowHeader="False"
                    EnableViewState="false" GridLines="None" CssClass="gv-findings-DiabeticNeuropathy finding-section">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <div class="listchkbox">
                                    <input type="radio" id="rbtFindingDiabeticNeuropathy" name="rbtFindingDiabeticNeuropathy" class="rbt-finding" />
                                </div>
                                <div class="lfttoppad">
                                    <%# DataBinder.Eval(Container.DataItem, "Label")%>
                                </div>
                                <input type="hidden" id="FindingDiabeticNeuropathyInputHidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="lrow margin-top-small exclude-hide-evaluation">
                <asp:DataList runat="server" ID="UnableToScreenDiabeticNeuropathyDataList" CssClass="dtl-unabletoscreen-DiabeticNeuropathy unable-to-screen-section"
                    RepeatLayout="Flow" EnableViewState="false" GridLines="None" RepeatDirection="Horizontal">
                    <ItemTemplate>
                        <input type="checkbox" id="chkUnableScreenReason" />
                        <b>&nbsp;<%# DataBinder.Eval(Container.DataItem, "DisplayName")%></b>
                        <input type="hidden" id="hfUnableScreenReasonID" value='<%# Convert.ToString((int)DataBinder.Eval(Container.DataItem, "Reason")) %>' />
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div class="lrow clear-all-selection">
                <a style="margin-left: 5px;" id="clear-all-DiabeticNeuropathy" href="javascript:void(0);" onclick="clearAllDiabeticNeuropathySelection();">Clear All Selection</a>
            </div>
            <div id="DiabeticNeuropathyImagesContainerDiv" class="contentrowltpad media-container-div" style="margin-top: 10px;">
                <a href="javascript:void(0)">
                    <img src="/Config/Content/ResultPacket/content/DPNRefereneRanges.jpg" onclick="showImageForDiabeticNeuropathy('/Config/Content/ResultPacket/content/DPNRefereneRanges.jpg')" style="width: 100px; height: 100px;" />
                </a>
            </div>
        </div>
        <div class="rgt_info1">
            <div class="rgt_gbox">
                <div class="grow">
                    <div style="padding-right: 10px; float: left;">
                        <strong>Amplitude:
                        <input type="text" id="AmplitudeInputText" class="input_bdrbot" style="width: 80px;" onkeydown="return KeyPress_DecimalAllowedOnly(event);" />
                        </strong>
                    </div>
                    <div style="float: left;">
                        <strong>Conduction Velocity:
                        <input type="text" id="ConductionVelocityTextbox" class="input_bdrbot" style="width: 80px;" onkeydown="return KeyPress_DecimalAllowedOnly(event);" />
                        </strong>
                    </div>

                </div>
                <div class="grow" style="margin-top: 10px;">
                </div>
                <div class="grow" style="margin-top: 10px;">
                    <strong>
                        <span style="float: left; padding-right: 10px;">
                            <input type="checkbox" id="RightLegCheckbox" />Right Leg 
                        </span>
                        <span style="float: left; padding-right: 10px;">
                            <input type="checkbox" id="LeftLegCheckbox" />Left Leg
                        </span>
                    </strong>
                </div>
            </div>
            <div class="rrow">
                <b>Technician Notes: </b>
                <br />
                <textarea id="technotesDiabeticNeuropathy" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
                    rows="2" cols="54"></textarea>
            </div>
            <div class="rrow test-not-performed-section" id="testnotPerformedDiabeticNeuropathy">
                <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0" />
                <b>Test Not Performed</b>
                <div class="test-not-performed-container" style="display: none">
                    <b>Reason : </b>
                    <br />
                    <asp:DropDownList ID="ddlTestNotPerformedReasonDiabeticNeuropathy" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
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
                    <input type="checkbox" id="technicallyltdbutreadableDiabeticNeuropathyinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Technically limited</b><br />
                    <input type="checkbox" id="repeatstudyDiabeticNeuropathyinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Unreadable</b><br />
                </div>
                <input type="checkbox" id="criticalDiabeticNeuropathy" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b>
            </div>
            <div style="float: left; width: 58%;">
                <textarea id="physicianRemarksDiabeticNeuropathy" rows="3" style="width: 98%;"></textarea>
            </div>
        </fieldset>
    </div>

</div>

<div id="DiabeticNeuropathy_chat" runat="server">
    <div class="orange-band test-section-header">
        <h5>
            <span class="org-heading"><strong>Diabetic Neuropathy</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyDiabeticNeuropathy" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="DiabeticNeuropathy-retest-span">
            <input type="checkbox" id="Retest_70" />Retest
        </span>
    </div>
    <div class="contentrow" style="width: 99%; padding-left: 0px;">
        <div class="hlfbox">
            <div class="hrows">
                <div class="nrow" style="margin-left: 12px;">
                    <input type="checkbox" id="chk_DiabeticNeuropathycapturebyChat" />
                    <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
        </div>
         <div style="float: left; clear: none; padding-top: 0" class="test-not-performed-section" id="testnotPerformedDiabeticNeuropathy">
                <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0" />
                <b>Test Not Performed</b>
                <div class="test-not-performed-container" style="display: none">
                    <b>Reason : </b>
                    <br />
                    <asp:DropDownList ID="ddlTestNotPerformedReasonDiabeticNeuropathy_CHAT" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
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
    var testTypeDiabeticNeuropathy = '<%= (long)TestType.DiabeticNeuropathy %>';

    var isDiabeticNeuropathyResultentrytype = '<%= IsResultEntrybyChat %>';

    var diabeticNeuropathy = null;
    function SetDiabeticNeuropathyData(testResult) {
        diabeticNeuropathy = new DiabeticNeuropathy(testResult);
        diabeticNeuropathy.setData();
    }

    function GetDiabeticNeuropathyData(testResult) {
        if (diabeticNeuropathy == null) diabeticNeuropathy = new DiabeticNeuropathy();
        return diabeticNeuropathy.getData();
    }


    function showImageForDiabeticNeuropathy(src) {
        $(".media-navigation-next").hide();
        $(".media-navigation-prev").hide();
        onImageClick(src);

    }
</script>
