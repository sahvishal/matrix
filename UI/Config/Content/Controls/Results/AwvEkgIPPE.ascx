<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AwvEkgIPPE.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.AwvEkgIPPE" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/AwvEkgIPPE.js?q=<%= VersionNumber %>"></script>
<div id="AwvEkgIPPE_hip" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
<div class="orange-band test-section-header">
    <h5>
        <span class="org-heading"><strong>EKG IPPE Results</strong></span>
    </h5>
    <span class="chk_orngband">
        <select id="conductedbyAwvEkgIPPE" class="conductedby-ddl">
        </select>
    </span><span class="chk_orngband" id="AwvEkgIPPE-critical-span">
        <input type="checkbox" id="DescribeSelfPresentAwvEkgIPPEInputCheck" onclick="onClick_CriticalDataAwvEkgIPPE();" />Critical </span>
    <span class="chk_orngband" id="awvEkgIPPE-priorityInQueue-span">
        <input type="checkbox" id="PriorityInQueueTestAwvEkgIPPECheck" onclick="onClick_PriorityInQueueDataAwvEkgIPPE();" />Priority In Queue
    </span>
    <span class="chk_orngband" id="awvEkgIPPE-retest-span">
        <input type="checkbox" id="Retest_51" />Retest
    </span>
</div>

<div class="left physician-section clear-all-AwvEkgIppe-selection" style="width: 100%; border-bottom: solid 1px; padding-top: 5px;">
    <asp:DataList runat="server" Style="float: left; width: 500px" ID="AwvEkgIppeFindingsGridView"
        EnableViewState="false" AutoGenerateColumns="False" ShowHeader="False" GridLines="None"
        RepeatDirection="Horizontal" CssClass="tablestyle_fndgs left AwvEkgIppe-finding-grid finding-section"
        CellPadding="0" CellSpacing="0">
        <ItemTemplate>
            <input type="radio" name="AwvEkgIppeFindingsRadioButton" class="ekg-radio rbt-finding" /><%# DataBinder.Eval(Container.DataItem, "Description").ToString().Length > 0 ? DataBinder.Eval(Container.DataItem, "Label")+ "(" + DataBinder.Eval(Container.DataItem, "Description") + ")":DataBinder.Eval(Container.DataItem, "Label") %>
            <input type="hidden" value="<%# DataBinder.Eval(Container.DataItem, "Id")%>" class="finding-id" />
        </ItemTemplate>
    </asp:DataList>
</div>
<div class="physician-section" style="text-align: right; float: right; width: 50%; border-bottom: solid 1px; clear: both;">
    <input type="checkbox" id="AwvEkgIppeRepeatStudyInputCheck" class="alt-conclusion-skipfinding-check" />Repeat
    Study&nbsp;&nbsp;
    <input type="checkbox" id="AwvEkgIppeReversedLeadInputCheck" class="alt-conclusion-skipfinding-check" />Reversed
    Leads&nbsp;&nbsp;
    <input type="checkbox" id="AwvEkgIppeArtifactInputCheck" class="alt-conclusion-skipfinding-check" />Artifact&nbsp;&nbsp;
    <input type="checkbox" id="AwvEkgIppeComparedtoPrevEkgInputCheck" class="alt-conclusion-skipfinding-check" />Compare
    to Previous EKG
</div>
<div class="left physician-section clear-all-AwvEkgIppe-selection" style="width: 100%; padding: 4px 0px; margin-top: 10px;">
    <table cellpadding="2" cellspacing="2" border="0" width="300px" style="font-size: 11px"
        class="left">
        <tr>
            <td>
                <input type="checkbox" id="AwvEkgIppeSinusRythmInputCheck" />
                Sinus Rhythm
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" id="AwvEkgIppeSinusArrythmiaInputCheck" />
                Sinus Arrhythmia
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" id="AwvEkgIppeSinusBradycardiaInputCheck" />
                Sinus Bradycardia <span style="display: none;">&nbsp;&nbsp;<input type="checkbox"
                    id="AwvEkgIppeMildInputCheck" />
                    Mild</span> &nbsp;&nbsp;<input type="checkbox" id="AwvEkgIppeMarkedInputCheck" />Marked
                < 50
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" id="AwvEkgIppeSinusTachycardiaInputCheck" />
                Sinus Tachycardia
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" id="AwvEkgIppeAtrialFibrillationInputCheck" />
                Atrial Fibrillation&nbsp;&nbsp;<input type="checkbox" id="AwvEkgIppeAtrialFlutterInputCheck" />
                Atrial Flutter
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" id="AwvEkgIppeSupraventriculaCheckbox" />
                Supraventricular Arrhythmia
                <input type="checkbox" id="AwvEkgIppeSvtInputCheck" />
                SVT
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" id="AwvEkgIppePacInputCheck" />
                PAC(s)
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" id="AwvEkgIppePvcInputCheck" />
                PVC(s)
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" id="AwvEkgIppePacerRythmCheckbox" />
                Pacer Rhythm
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" id="AwvEkgIppeBundleBranchBlockCheckbox" />
                Bundle Branch Block
            </td>
        </tr>
        <tr>
            <td style="padding-left: 25px;">
                <asp:DataList ID="AwvEkgIppeBundleBranchBlockDatalist" runat="server" RepeatDirection="Horizontal"
                    CssClass="AwvEkgIppe-bundle-branch-finding" EnableViewState="false" RepeatColumns="3">
                    <ItemTemplate>
                        <input type="checkbox" id="BundleBlockCheckbox" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                        <input type="hidden" value='<%# DataBinder.Eval(Container.DataItem, "Id") %>' class="finding-id" />
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
    </table>
    <table cellpadding="2" cellspacing="2" border="0" width="330px" style="font-size: 11px"
        class="left">
        <tr>
            <td>
                <input type="checkbox" id="AwvEkgIppeQrsWideningInputCheck" />
                QRS widening
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" id="AwvEkgIppeLeftAxisInputCheck" />
                &nbsp;Left Axis
                <input type="checkbox" id="AwvEkgIppeRightAxisInputCheck" />
                &nbsp;Right Axis
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" id="AwvEkgIppeAbnormalAxisInputCheck" />
                &nbsp;Abnormal Axis
                <input type="checkbox" id="AwvEkgIppeLeftInputCheck" />
                Left
                <input type="checkbox" id="AwvEkgIppeRightInputCheck" />
                Right
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" id="AwvEkgIppeLeftAnteriorfasicularBlockCheckbox" />
                Left Anterior Fasicular Block
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" id="AwvEkgIppeHeartBlockInputCheck" />
                AV Nodal Heart Block
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="2" cellspacing="2" border="0" style="padding-left: 20px;">
                    <tr>
                        <td>
                            <input type="checkbox" id="AwvEkgIppeFirstDegreeBlockInputCheck" />
                        </td>
                        <td>1st  Degree AV Block
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input type="checkbox" id="AwvEkgIppeSecondDegreeBlockCheckbox" />
                        </td>
                        <td>2nd Degree Mobitz I AV Block
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input type="checkbox" id="AwvEkgIppeTypeIIInputCheck" />
                        </td>
                        <td>2nd Degree Mobitz II AV Block
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input type="checkbox" id="AwvEkgIppeThirdDegreeBlockInputCheck" />
                        </td>
                        <td>3rd Degree Complete AV Block
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" id="AwvEkgIppeVentricularCheckbox" />
                Consistent with Ventricular Hypertrophy
            </td>
        </tr>
        <tr>
            <td style="padding-left: 25px;">
                <input type="checkbox" id="AwvEkgIppeLeftVentricularCheckbox" />
                Left
                <input type="checkbox" id="AwvEkgIppeRightVentricularCheckbox" />
                Right
            </td>
        </tr>
    </table>
    <table cellpadding="2" cellspacing="2" border="0" width="230px" style="font-size: 11px"
        class="left">
        <tr>
            <td>
                <input id="AwvEkgIppeProlongedQTCheckbox" type="checkbox" />
                Prolonged QTc Interval
            </td>
        </tr>
        <tr>
            <td>
                <input id="AwvEkgIppeISchemicSttCheckbox" type="checkbox" />
                Consistent with Ischemic ST-T changes
            </td>
        </tr>
        <tr>
            <td>
                <input id="AwvEkgIppeNonSpecificSttCheckbox" type="checkbox" />
                Non Specific ST-T changes
            </td>
        </tr>
        <tr>
            <td>
                <input id="AwvEkgIppePoorRWaveProgressionCheckbox" type="checkbox" />
                Poor R Wave Progression
            </td>
        </tr>
        <tr>
            <td>
                <input id="AwvEkgIppeInfarctionPatternCheckbox" type="checkbox" />
                Consistent with Infarction Pattern
            </td>
        </tr>
        <tr>
            <td style="padding-left: 25px;">
                <asp:DataList ID="AwvEkgIppeInfarctionPatternDatalist" CssClass="AwvEkgIppe-infarction-pattern-finding"
                    runat="server" RepeatDirection="Horizontal" EnableViewState="false" RepeatColumns="2">
                    <ItemTemplate>
                        <input type="checkbox" id="patternOption" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                        <input type="hidden" value='<%# DataBinder.Eval(Container.DataItem, "Id") %>' class="finding-id" />
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
        <tr>
            <td>
                <input id="AwvEkgIppeATypicalWaveCheckbox" type="checkbox" />
                Atypical Q Wave lead III
            </td>
        </tr>
        <tr>
            <td>
                <input id="AwvEkgIppeAtrialEnlargementCheckbox" type="checkbox" />
                Atrial Enlargement
            </td>
        </tr>
        <tr>
            <td style="padding-left: 25px;">
                <input id="AwvEkgIppeLeftAtrialCheckbox" type="checkbox" />
                Left
                <input id="AwvEkgIppeRightAtrialCheckbox" type="checkbox" />
                Right
            </td>
        </tr>
        <tr>
            <td>
                <input id="AwvEkgIppeRepolarizationCheckbox" type="checkbox" />
                Repolarization Variant
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" id="AwvEkgIppeLowVoltageCheckbox" />Low Voltage
            </td>
        </tr>
        <tr>
            <td style="padding-left: 25px;">
                <input type="checkbox" id="AwvEkgIppeLimbLeadsCheckbox" />Limb leads
                <input type="checkbox" id="AwvEkgIppePrecordialLeadsCheckbox" />Precordial leads
            </td>
        </tr>
    </table>
</div>

<div class="left_info1">
    <div class="labelwdt2 finding">
        <asp:DataList runat="server" ID="UnableToScreenAwvEkgIPPEDataList" EnableViewState="false"
            RepeatLayout="Flow" CssClass="dtl-unabletoscreen-AwvEkgIPPE unable-to-screen-section" GridLines="None"
            RepeatDirection="Horizontal">
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
        <textarea id="technotesAwvEkgIPPE" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
            rows="2" cols="54"></textarea>
    </div>
    <div class="rrow test-not-performed-section" id="testnotPerformedAwvEkgIPPE">
        <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0" />
        <b>Test Not Performed</b>
        <div class="test-not-performed-container" style="display: none">
            <b>Reason : </b>
            <br />
            <asp:DropDownList ID="ddlTestNotPerformedReasonAwvEkgIPPE" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
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
<div class="lrow physician-section clear-all-selection">
    <a style="margin-left: 5px;" id="clear-all-ekg" href="javascript:void(0);" onclick="clearAllAwvEkgIppeSelection();">Clear All Selection</a>
</div>
<div style="float: left; width: 100%; clear: both; margin-top: 5px;" class="physician-section">
    <fieldset style="float: left; width: 98%; border-radius: 4px;">
        <legend>Remarks </legend>
        <div style="float: left; width: 40%;">
            <input type="checkbox" id="criticalAwvEkgIppe" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b>
        </div>
        <div style="float: left; width: 58%;">
            <textarea id="physicianRemarksAwvEkgIppe" rows="3" style="width: 98%;"></textarea>
        </div>
    </fieldset>
</div>
<div class="left" style="width: 937px; padding: 3px;">
    <div class="contentrowltpad upload-media-section">
        <a href="javascript:OpenPopUp('Upload Media', '710', '/app/franchisee/technician/uploadTestImages.aspx?RestricttoOne=true&TestType=<%= (int)TestType.AwvEkgIPPE %>&CustomerId=' + customerId);">Upload Media</a>
    </div>
    <div id="awvEkgIppeImagesContainerDiv" class="contentrowltpad media-container-div" style="margin-top: 5px;">
    </div>
</div>

    </div>

<div id="AwvEkgIPPE_chat" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 50%;">
            <span class="org-heading" style="width: 100%;"><strong>EKG IPPE Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyAwvEkgIPPE" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="awvEkgIPPE-retest-span">
            <input type="checkbox" id="Retest_51" />Retest
        </span>
    </div>
    <div class="hrows AwvEkgIPPE-verificationpanel" style="color: Red; background: #fff0a5; border: solid 1px fff0a5; padding: 2px 2px 2px 5px; display: none;">
    </div>
     <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
             
     <div class="hlfbox">
           <div class="hrows">
             <div class="nrow" style="margin-left:12px;">
                  <input type="checkbox" id="chk_AwvEkgIPPEcapturebyChat" />
                   <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
     </div>
             
     </div>
</div>
<script language="javascript" type="text/javascript">
    var testTypeAwvEkgIPPE = '<%= (long)TestType.AwvEkgIPPE %>';
    var IsawvEkgIPPEResultEntryExternaly = '<%=IsResultEntrybyChat%>'

    var awvEkgIPPE = null;
    function SetAwvEkgIPPEData(testResult) {
        awvEkgIPPE = new AwvEkgIPPE(testResult);
        awvEkgIPPE.setData();
    }

    function GetAwvEkgIPPEData() {
        if (awvEkgIPPE == null) awvEkgIPPE = new AwvEkgIPPE();
        return awvEkgIPPE.getData();
    }

</script>
