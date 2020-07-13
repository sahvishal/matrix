<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Ekg.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.Ekg" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/Ekg.js?q=<%= VersionNumber %>"></script>
<div id="ekg_hip" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
<div class="orange-band test-section-header">
    <h5>
        <span class="org-heading"><strong>Electrocardiogram (EKG) Results</strong></span>
    </h5>
    <span class="chk_orngband">
        <select id="conductedbyekg" class="conductedby-ddl">
        </select>
    </span><span class="chk_orngband" id="ekg-critical-span">
        <input type="checkbox" id="SelfPresentEKGInputCheck" onclick="onClick_CriticalDataEkg();" />Critical
    </span>
    <span class="chk_orngband" id="ekg-priorityInQueue-span">
        <input type="checkbox" id="PriorityInQueueTestEKGCheck" onclick="onClick_PriorityInQueueDataEKG();" />Priority In Queue
    </span>
    <span class="chk_orngband" id="ekg-retest-span">
        <input type="checkbox" id="Retest_11" />Retest
    </span>
</div>
<div class="left physician-section clear-all-ekg-selection" style="width: 100%; border-bottom: solid 1px; padding-top: 5px;">
    <asp:DataList runat="server" Style="float: left; width: 500px" ID="EKGFindingsGridView"
        EnableViewState="false" AutoGenerateColumns="False" ShowHeader="False" GridLines="None"
        RepeatDirection="Horizontal" CssClass="tablestyle_fndgs left ekg-finding-grid finding-section"
        CellPadding="0" CellSpacing="0">
        <ItemTemplate>
            <input type="radio" name="EKGFindingsRadioButton" class="ekg-radio rbt-finding" /><%# DataBinder.Eval(Container.DataItem, "Description").ToString().Length > 0 ? DataBinder.Eval(Container.DataItem, "Label")+ "(" + DataBinder.Eval(Container.DataItem, "Description") + ")":DataBinder.Eval(Container.DataItem, "Label") %>
            <input type="hidden" value="<%# DataBinder.Eval(Container.DataItem, "Id")%>" class="finding-id" />
        </ItemTemplate>
    </asp:DataList>
</div>
<div class="physician-section" style="text-align: right; float: right; width: 50%; border-bottom: solid 1px; clear: both;">
    <input type="checkbox" id="RepeatStudyInputCheck" class="alt-conclusion-skipfinding-check" />Repeat
    Study&nbsp;&nbsp;
    <input type="checkbox" id="ReversedLeadInputCheck" class="alt-conclusion-skipfinding-check" />Reversed
    Leads&nbsp;&nbsp;
    <input type="checkbox" id="ArtifactInputCheck" class="alt-conclusion-skipfinding-check" />Artifact&nbsp;&nbsp;
    <input type="checkbox" id="ComparedtoPrevEkgInputCheck" class="alt-conclusion-skipfinding-check" />Compare
    to Previous EKG
</div>
<div class="left physician-section clear-all-ekg-selection" style="width: 100%; padding: 4px 0px; margin-top: 10px;">
    <table cellpadding="2" cellspacing="2" border="0" width="300px" style="font-size: 11px"
        class="left">
        <tr>
            <td>
                <input type="checkbox" id="sinusRythmInputCheck" />
                Sinus Rhythm
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" id="sinusArrythmiaInputCheck" />
                Sinus Arrhythmia
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" id="sinusBradycardiaInputCheck" />
                Sinus Bradycardia <span style="display: none;">&nbsp;&nbsp;<input type="checkbox"
                    id="mildInputCheck" />
                    Mild</span> &nbsp;&nbsp;<input type="checkbox" id="markedInputCheck" />Marked
                < 50
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" id="sinusTachycardiaInputCheck" />
                Sinus Tachycardia
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" id="atrialFibrillationInputCheck" />
                Atrial Fibrillation&nbsp;&nbsp;<input type="checkbox" id="AtrialFlutterInputCheck" />
                Atrial Flutter
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" id="SupraventriculaCheckbox" />
                Supraventricular Arrhythmia
                <input type="checkbox" id="svtInputCheck" />
                SVT
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" id="pacInputCheck" />
                PAC(s)
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" id="pvcInputCheck" />
                PVC(s)
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" id="PacerRythmCheckbox" />
                Pacer Rhythm
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" id="BundleBranchBlockCheckbox" />
                Bundle Branch Block
            </td>
        </tr>
        <tr>
            <td style="padding-left: 25px;">
                <asp:DataList ID="BundleBranchBlockDatalist" runat="server" RepeatDirection="Horizontal"
                    CssClass="bundle-branch-finding" EnableViewState="false" RepeatColumns="3">
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
                <input type="checkbox" id="qrsWideningInputCheck" />
                QRS widening
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" id="leftAxisInputCheck" />
                &nbsp;Left Axis
                <input type="checkbox" id="RightAxisInputCheck" />
                &nbsp;Right Axis
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" id="AbnormalAxisInputCheck" />
                &nbsp;Abnormal Axis
                <input type="checkbox" id="LeftInputCheck" />
                Left
                <input type="checkbox" id="RightInputCheck" />
                Right
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" id="LeftAnteriorfasicularBlockCheckbox" />
                Left Anterior Fasicular Block
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" id="HeartBlockInputCheck" />
                AV Nodal Heart Block
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="2" cellspacing="2" border="0" style="padding-left: 20px;">
                    <tr>
                        <td>
                            <input type="checkbox" id="FirstDegreeBlockInputCheck" />
                        </td>
                        <td>1st  Degree AV Block
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input type="checkbox" id="SecondDegreeBlockCheckbox" />
                        </td>
                        <td>2nd Degree Mobitz I AV Block
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input type="checkbox" id="TypeIIInputCheck" />
                        </td>
                        <td>2nd Degree Mobitz II AV Block
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input type="checkbox" id="ThirdDegreeBlockInputCheck" />
                        </td>
                        <td>3rd Degree Complete AV Block
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" id="EkgVentricularCheckbox" />
                Consistent with Ventricular Hypertrophy
            </td>
        </tr>
        <tr>
            <td style="padding-left: 25px;">
                <input type="checkbox" id="LeftVentricularCheckbox" />
                Left
                <input type="checkbox" id="RightVentricularCheckbox" />
                Right
            </td>
        </tr>
    </table>
    <table cellpadding="2" cellspacing="2" border="0" width="230px" style="font-size: 11px"
        class="left">
        <tr>
            <td>
                <input id="ProlongedQTCheckbox" type="checkbox" />
                Prolonged QTc Interval
            </td>
        </tr>
        <tr>
            <td>
                <input id="ISchemicSttCheckbox" type="checkbox" />
                Consistent with Ischemic ST-T changes
            </td>
        </tr>
        <tr>
            <td>
                <input id="NonSpecificSttCheckbox" type="checkbox" />
                Non Specific ST-T changes
            </td>
        </tr>
        <tr>
            <td>
                <input id="PoorRWaveProgressionCheckbox" type="checkbox" />
                Poor R Wave Progression
            </td>
        </tr>
        <tr>
            <td>
                <input id="InfarctionPatternCheckbox" type="checkbox" />
                Consistent with Infarction Pattern
            </td>
        </tr>
        <tr>
            <td style="padding-left: 25px;">
                <asp:DataList ID="InfarctionPatternDatalist" CssClass="infarction-pattern-finding"
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
                <input id="ATypicalWaveCheckbox" type="checkbox" />
                Atypical Q Wave lead III
            </td>
        </tr>
        <tr>
            <td>
                <input id="EkgAtrialEnlargementCheckbox" type="checkbox" />
                Atrial Enlargement
            </td>
        </tr>
        <tr>
            <td style="padding-left: 25px;">
                <input id="EkgLeftAtrialCheckbox" type="checkbox" />
                Left
                <input id="EkgRightAtrialCheckbox" type="checkbox" />
                Right
            </td>
        </tr>
        <tr>
            <td>
                <input id="RepolarizationCheckbox" type="checkbox" />
                Repolarization Variant
            </td>
        </tr>
        <tr>
            <td>
                <input type="checkbox" id="EkgLowVoltageCheckbox" />Low Voltage
            </td>
        </tr>
        <tr>
            <td style="padding-left: 25px;">
                <input type="checkbox" id="EkgLimbLeadsCheckbox" />Limb leads
                <input type="checkbox" id="EkgPrecordialLeadsCheckbox" />Precordial leads
            </td>
        </tr>
    </table>
</div>
<div class="left" style="width: 937px; padding: 3px;">
    <div class="left margin-top-small" style="display: block;">
        <div class="left pdf-upload-ekg-img-div media-container-div" style="display: none; width: 80px; padding-right: 20px;">
            <span class="left" style="width: 100%">
                <img id="PDFUploadImage" alt="" src="/App/Images/pdf-icon-mm.gif" /></span>
            <span class="left remove-image" style="width: 100%; text-align: center;"><a href="javascript:RemoveEKGImage();">Remove </a></span><span class="main-image" style="display: none;">
                <img src="/App/Images/No-Image-Found.gif" style="width: 690px;" alt="No Image" />
            </span>
        </div>
        <div class="left upload-media-section">
            <a href="javascript:OpenPopUp('Upload PDF', '330', '/app/franchisee/technician/PdfFileUpload.aspx?height=110', 200);">Upload PDF </a>
        </div>
    </div>
    <div class="rgt" style="display: block;">
        <b>Technician Notes: </b>
        <br />
        <textarea id="technotesekg" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
            rows="2" cols="54"></textarea>
    </div>
</div>
<div class="left" style="width: 937px; padding: 5px;">
    <asp:DataList runat="server" ID="UnableToScreenEkgDataList" CssClass="dtl-unabletoscreen-ekg unable-to-screen-section"
        RepeatLayout="Flow" EnableViewState="false" GridLines="None" RepeatDirection="Horizontal">
        <ItemTemplate>
            <input type="checkbox" id="chkUnableScreenReason" />
            <b>
                <%# DataBinder.Eval(Container.DataItem, "DisplayName")%></b>
            <input type="hidden" id="hfUnableScreenReasonID" value='<%# Convert.ToString((int)DataBinder.Eval(Container.DataItem, "Reason")) %>' />
        </ItemTemplate>
    </asp:DataList>
</div>
<div class="lrow physician-section clear-all-selection">
    <a style="margin-left: 5px;" id="clear-all-ekg" href="javascript:void(0);" onclick="clearAllEkgSelection();">Clear All Selection</a>
</div>
<div style="float: left; width: 100%; clear: both; margin-top: 5px;" class="physician-section">
    <fieldset style="float: left; width: 98%; border-radius: 4px;">
        <legend>Remarks </legend>
        <div style="float: left; width: 40%;">
            <input type="checkbox" id="criticalEkg" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b>
        </div>
        <div style="float: left; width: 58%;">
            <textarea id="physicianRemarksEkg" rows="3" style="width: 98%;"></textarea>
        </div>
    </fieldset>
</div>
    </div>


<div id="ekg_chat" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 50%;">
            <span class="org-heading" style="width: 100%;"><strong>Electrocardiogram (EKG) Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyekg" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="ekg-retest-span">
            <input type="checkbox" id="Retest_11" />Retest
        </span>
    </div>
    <div class="hrows ekg-verificationpanel" style="color: Red; background: #fff0a5; border: solid 1px fff0a5; padding: 2px 2px 2px 5px; display: none;">
    </div>
     <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
             
     <div class="hlfbox">
           <div class="hrows">
             <div class="nrow" style="margin-left:12px;">
                  <input type="checkbox" id="chk_ekgcapturebyChat" />
                   <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
     </div>
             
     </div>
</div>


<script language="javascript" type="text/javascript">
    var testTypeEkg = '<%= (long)TestType.EKG %>';
    var IsekgResultEntryExternaly = '<%= IsResultEntrybyChat %>';

    var ekg = null;
    function SetEKGData(testResult) {
        ekg = new Ekg(testResult);
        ekg.setData();
    }

    function GetEKGData() {
        if (ekg == null) ekg = new Ekg();
        return ekg.getData();
    }

</script>
