<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AwvEkg.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.AwvEkg" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/AwvEkg.js?q=<%= VersionNumber %>"></script>
<div id="awvEkg_hip" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
<div class="orange-band test-section-header">
    <h5>
        <span class="org-heading"><strong>Electrocardiogram (EKG) Results</strong></span>
    </h5>
    <span class="chk_orngband">
        <select id="conductedbyAwvEkg" class="conductedby-ddl">
        </select>
    </span><span class="chk_orngband" id="AwvEkg-critical-span">
        <input type="checkbox" id="DescribeSelfPresentAwvEkgInputCheck" onclick="onClick_CriticalDataAwvEkg();" />Critical </span>
    <span class="chk_orngband" id="awvEkg-priorityInQueue-span">
        <input type="checkbox" id="PriorityInQueueTestAwvEkgCheck" onclick="onClick_PriorityInQueueDataAwvEkg();" />Priority In Queue
    </span>
    <span class="chk_orngband" id="awvEkg-retest-span">
        <input type="checkbox" id="Retest_50" />Retest
    </span>
</div>
<div class="left physician-section clear-all-AwvEkg-selection" style="width: 100%; border-bottom: solid 1px; padding-top: 5px;">
    <asp:DataList runat="server" Style="float: left; width: 500px" ID="AwvEkgFindingsGridView"
        EnableViewState="false" AutoGenerateColumns="False" ShowHeader="False" GridLines="None"
        RepeatDirection="Horizontal" CssClass="tablestyle_fndgs left AwvEkg-finding-grid finding-section"
        CellPadding="0" CellSpacing="0">
        <ItemTemplate>
            <input type="radio" name="AwvEkgFindingsRadioButton" class="ekg-radio rbt-finding" /><%# DataBinder.Eval(Container.DataItem, "Description").ToString().Length > 0 ? DataBinder.Eval(Container.DataItem, "Label")+ "(" + DataBinder.Eval(Container.DataItem, "Description") + ")":DataBinder.Eval(Container.DataItem, "Label") %>
            <input type="hidden" value="<%# DataBinder.Eval(Container.DataItem, "Id")%>" class="finding-id" />
        </ItemTemplate>
    </asp:DataList>
</div>
<div class="physician-section" style="text-align: right; float: right; width: 50%; border-bottom: solid 1px; clear: both;">
    <input type="checkbox" id="AwvEkgRepeatStudyInputCheck" class="alt-conclusion-skipfinding-check" />Repeat
    Study&nbsp;&nbsp;
    <input type="checkbox" id="AwvEkgReversedLeadInputCheck" class="alt-conclusion-skipfinding-check" />Reversed
    Leads&nbsp;&nbsp;
    <input type="checkbox" id="AwvEkgArtifactInputCheck" class="alt-conclusion-skipfinding-check" />Artifact&nbsp;&nbsp;
    <input type="checkbox" id="AwvEkgComparedtoPrevEkgInputCheck" class="alt-conclusion-skipfinding-check" />Compare
    to Previous EKG
</div>
<div class="left physician-section clear-all-AwvEkg-selection" style="width: 100%; padding: 4px 0px; margin-top: 10px;">
    <table cellpadding="2" cellspacing="2" border="0" width="300px" style="font-size: 11px"
        class="left">
        <tr>
            <td>
                <input type="checkbox" id="AwvEkgSinusRythmInputCheck" />
                Sinus Rhythm
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" id="AwvEkgSinusArrythmiaInputCheck" />
                Sinus Arrhythmia
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" id="AwvEkgSinusBradycardiaInputCheck" />
                Sinus Bradycardia <span style="display: none;">&nbsp;&nbsp;<input type="checkbox"
                    id="AwvEkgMildInputCheck" />
                    Mild</span> &nbsp;&nbsp;<input type="checkbox" id="AwvEkgMarkedInputCheck" />Marked
                < 50
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" id="AwvEkgSinusTachycardiaInputCheck" />
                Sinus Tachycardia
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" id="AwvEkgAtrialFibrillationInputCheck" />
                Atrial Fibrillation&nbsp;&nbsp;<input type="checkbox" id="AwvEkgAtrialFlutterInputCheck" />
                Atrial Flutter
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" id="AwvEkgSupraventriculaCheckbox" />
                Supraventricular Arrhythmia
                <input type="checkbox" id="AwvEkgSvtInputCheck" />
                SVT
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" id="AwvEkgPacInputCheck" />
                PAC(s)
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" id="AwvEkgPvcInputCheck" />
                PVC(s)
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" id="AwvEkgPacerRythmCheckbox" />
                Pacer Rhythm
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" id="AwvEkgBundleBranchBlockCheckbox" />
                Bundle Branch Block
            </td>
        </tr>
        <tr>
            <td style="padding-left: 25px;">
                <asp:DataList ID="AwvEkgBundleBranchBlockDatalist" runat="server" RepeatDirection="Horizontal"
                    CssClass="AwvEkg-bundle-branch-finding" EnableViewState="false" RepeatColumns="3">
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
                <input type="checkbox" id="AwvEkgQrsWideningInputCheck" />
                QRS widening
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" id="AwvEkgLeftAxisInputCheck" />
                &nbsp;Left Axis
                <input type="checkbox" id="AwvEkgRightAxisInputCheck" />
                &nbsp;Right Axis
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" id="AwvEkgAbnormalAxisInputCheck" />
                &nbsp;Abnormal Axis
                <input type="checkbox" id="AwvEkgLeftInputCheck" />
                Left
                <input type="checkbox" id="AwvEkgRightInputCheck" />
                Right
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" id="AwvEkgLeftAnteriorfasicularBlockCheckbox" />
                Left Anterior Fasicular Block
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" id="AwvEkgHeartBlockInputCheck" />
                AV Nodal Heart Block
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="2" cellspacing="2" border="0" style="padding-left: 20px;">
                    <tr>
                        <td>
                            <input type="checkbox" id="AwvEkgFirstDegreeBlockInputCheck" />
                        </td>
                        <td>1st  Degree AV Block
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input type="checkbox" id="AwvEkgSecondDegreeBlockCheckbox" />
                        </td>
                        <td>2nd Degree Mobitz I AV Block
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input type="checkbox" id="AwvEkgTypeIIInputCheck" />
                        </td>
                        <td>2nd Degree Mobitz II AV Block
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input type="checkbox" id="AwvEkgThirdDegreeBlockInputCheck" />
                        </td>
                        <td>3rd Degree Complete AV Block
                        </td>
                    </tr>
                </table>
                <div>
                    <input type="checkbox" id="AwvEkgShortPrIntervalInputCheck" />
                    Short P-R interval for rate
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" id="AwvEkgVentricularCheckbox" />
                Consistent with Ventricular Hypertrophy
            </td>
        </tr>
        <tr>
            <td style="padding-left: 25px;">
                <input type="checkbox" id="AwvEkgLeftVentricularCheckbox" />
                Left
                <input type="checkbox" id="AwvEkgRightVentricularCheckbox" />
                Right
            </td>
        </tr>
    </table>
    <table cellpadding="2" cellspacing="2" border="0" width="230px" style="font-size: 11px"
        class="left">
        <tr>
            <td>
                <input id="AwvEkgProlongedQTCheckbox" type="checkbox" />
                Prolonged QTc Interval
            </td>
        </tr>
        <tr>
            <td>
                <input id="AwvEkgISchemicSttCheckbox" type="checkbox" />
                Consistent with Ischemic ST-T changes
            </td>
        </tr>
        <tr>
            <td>
                <input id="AwvEkgNonSpecificSttCheckbox" type="checkbox" />
                Non Specific ST-T changes
            </td>
        </tr>
        <tr>
            <td>
                <input id="AwvEkgPoorRWaveProgressionCheckbox" type="checkbox" />
                Poor R Wave Progression
            </td>
        </tr>
        <tr>
            <td>
                <input id="AwvEkgInfarctionPatternCheckbox" type="checkbox" />
                Consistent with Infarction Pattern
            </td>
        </tr>
        <tr>
            <td style="padding-left: 25px;">
                <asp:DataList ID="AwvEkgInfarctionPatternDatalist" CssClass="AwvEkg-infarction-pattern-finding"
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
                <input id="AwvEkgATypicalWaveCheckbox" type="checkbox" />
                Atypical Q Wave lead III
            </td>
        </tr>
        <tr>
            <td>
                <input id="AwvEkgAtrialEnlargementCheckbox" type="checkbox" />
                Atrial Enlargement
            </td>
        </tr>
        <tr>
            <td style="padding-left: 25px;">
                <input id="AwvEkgLeftAtrialCheckbox" type="checkbox" />
                Left
                <input id="AwvEkgRightAtrialCheckbox" type="checkbox" />
                Right
            </td>
        </tr>
        <tr>
            <td>
                <input id="AwvEkgRepolarizationCheckbox" type="checkbox" />
                Repolarization Variant
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" id="AwvEkgLowVoltageCheckbox" />Low Voltage
            </td>
        </tr>
        <tr>
            <td style="padding-left: 25px;">
                <input type="checkbox" id="AwvEkgLimbLeadsCheckbox" />Limb leads
                <input type="checkbox" id="AwvEkgPrecordialLeadsCheckbox" />Precordial leads
            </td>
        </tr>
    </table>
</div>

<div class="left_info1">
    <div class="labelwdt2 finding">
        <asp:DataList runat="server" ID="UnableToScreenAwvEkgDataList" EnableViewState="false"
            RepeatLayout="Flow" CssClass="dtl-unabletoscreen-AwvEkg unable-to-screen-section" GridLines="None"
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
        <textarea id="technotesAwvEkg" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
            rows="2" cols="54"></textarea>
    </div>
    <div class="rrow test-not-performed-section" id="testnotPerformedAwvEkg">
        <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0" />
        <b>Test Not Performed</b>
        <div class="test-not-performed-container" style="display: none">
            <b>Reason : </b>
            <br />
            <asp:DropDownList ID="ddlTestNotPerformedReasonAwvEkg" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
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
    <a style="margin-left: 5px;" id="clear-all-AwvEkg" href="javascript:void(0);" onclick="clearAllAwvEkgSelection();">Clear All Selection</a>
</div>

<div class="left" style="width: 937px; padding: 3px;">
    <div class="contentrowltpad upload-media-section">
        <a href="javascript:OpenPopUp('Upload Media', '710', '/app/franchisee/technician/uploadTestImages.aspx?RestricttoOne=true&TestType=<%= (int)TestType.AwvEkg %>&CustomerId=' + customerId);">Upload Media</a>
    </div>
    <div id="awvEkgImagesContainerDiv" class="contentrowltpad media-container-div" style="margin-top: 5px;">
    </div>
</div>
<div style="float: left; width: 100%; clear: both; margin-top: 5px;" class="physician-section">
    <fieldset style="float: left; width: 98%; border-radius: 4px;">
        <legend>Remarks </legend>
        <div style="float: left; width: 40%;">
            <input type="checkbox" id="criticalAwvEkg" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b>
        </div>
        <div style="float: left; width: 58%;">
            <textarea id="physicianRemarksAwvEkg" rows="3" style="width: 98%;"></textarea>
        </div>
    </fieldset>
</div>
    </div>
<div id="awvEkg_chat" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 50%;">
            <span class="org-heading" style="width: 100%;"><strong>Electrocardiogram (EKG) Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyAwvEkg" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="AwvEkg-critical-span">
        <input type="checkbox" id="DescribeSelfPresentAwvEkgInputCheck" onclick="onClick_CriticalDataAwvEkg();" />Critical </span>

        <span class="chk_orngband" id="awvEkg-retest-span">
            <input type="checkbox" id="Retest_50" />Retest
        </span>
    </div>
    <div class="hrows awvEkg-verificationpanel" style="color: Red; background: #fff0a5; border: solid 1px fff0a5; padding: 2px 2px 2px 5px; display: none;">
    </div>
     <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
             
     <div class="hlfbox">
           <div class="hrows">
             <div class="nrow" style="margin-left:12px;">
                  <input type="checkbox" id="chk_awvEkgcapturebyChat" />
                   <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
     </div>
             
     </div>
</div>

<script language="javascript" type="text/javascript">
    var testTypeAwvEkg = '<%= (long)TestType.AwvEkg %>';
    var IsawvEkgResultEntryExternaly = '<%= IsResultEntrybyChat %>';    

    var awvEkg = null;
    function SetAwvEkgData(testResult) {
        awvEkg = new AwvEkg(testResult);
        awvEkg.setData();
    }

    function GetAwvEkgData() {
        if (awvEkg == null) awvEkg = new AwvEkg();
        return awvEkg.getData();
    }

</script>
