<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PpEchocardiogram.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.PpEchocardiogram" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/PpEchocardiogram.js?q=<%= VersionNumber %>"></script>
<div id="Ppecho_hip" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
<div class="orange-band test-section-header">
    <h5>
        <span class="org-heading"><strong>Echocardiogram Results</strong></span>
    </h5>
    <span class="chk_orngband">
        <select id="conductedbyPpecho" class="conductedby-ddl">
        </select>
    </span><span class="chk_orngband" id="Ppecho-critical-span">
        <input type="checkbox" id="DescribeSelfPresentPpEchoInputCheck" onclick="onClick_CriticalDataPpEcho();" />Critical
    </span>
    <span class="chk_orngband" id="ppecho-priorityInQueue-span">
        <input type="checkbox" id="PriorityInQueueTestPpEchoCheck" onclick="onClick_PriorityInQueueDataPpEcho();" />Priority In Queue
    </span>
    <span class="chk_orngband" id="ppecho-retest-span">
        <input type="checkbox" id="Retest_38" />Retest
    </span>
</div>
<div class="exclude-hide-evaluation physician-section clear-all-ppecho-selection" style="float: left; clear: both; margin-bottom: 5px; width: 100%">
    <asp:DataList runat="server" ID="PpEchoFindingsDatalist" CssClass="Ppecho-finding finding-section"
        ShowHeader="false" EnableViewState="false" GridLines="None" RepeatDirection="Horizontal">
        <ItemTemplate>
            <input type="radio" name="PpEchoFindingsRadioButton" class="rbt-finding" />
            <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id") %>' />
            <%# DataBinder.Eval(Container.DataItem, "Description").ToString().Length > 0 ? DataBinder.Eval(Container.DataItem, "Label")+ "(" + DataBinder.Eval(Container.DataItem, "Description") + ")":DataBinder.Eval(Container.DataItem, "Label") %>
        </ItemTemplate>
    </asp:DataList>
</div>
<div style="float: left; clear: both; margin-bottom: 5px; width: 100%">
    <div class="uppersection_echo exclude-hide-evaluation physician-section clear-all-ppecho-selection" style="width: 170px;">
        <div>
            <b>Estimated Ejection Fraction </b>
        </div>
        <div>
            <asp:DataList runat="server" ID="PpEjactionFractionFindingsDatalist" CssClass="Ppejaction-fraction-finding"
                GridLines="None" EnableViewState="false" RepeatDirection="Vertical">
                <ItemTemplate>
                    <input type="radio" name="finding-Ppejaction" class="rbt-finding" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                    <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                    <input type="hidden" class="finding-worstcaseorder" value='<%# DataBinder.Eval(Container.DataItem, "WorstCaseOrder")%>' />
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
    <div class="uppersection_valve_echo exclude-hide-evaluation physician-section clear-all-ppecho-selection" style="width: 90px;">
        <div>
            <b>Valve </b>
        </div>
        <div>
            <input type="checkbox" id="PpValveAorticCheckbox" />
            Aortic
        </div>
        <div>
            <input type="checkbox" id="PpValveMitralCheckbox" />
            Mitral
        </div>
        <div>
            <input type="checkbox" id="PpValvePulmonicCheckbox" />
            Pulmonic
        </div>
        <div>
            <input type="checkbox" id="PpValveTricuspidCheckbox" />
            Tricuspid
        </div>
    </div>
    <div class="uppersection_echo exclude-hide-evaluation physician-section clear-all-ppecho-selection" style="width: 270px;">
        <div>
            <div>
                <b>Regurgitation</b>
                <a style="margin-left: 10px; display: none;" id="claer-all-Ppregurgitation" href="javascript:void(0);" onclick="clearAllPpRegurgitationSelection();">Clear All Selection</a>
            </div>
        </div>
        <div>
            <asp:DataList runat="server" ID="PpRegurgitationforAorticDatalist" CssClass="Ppaortic-regurgitation-finding regurgitation-finding"
                RepeatDirection="Horizontal" EnableViewState="false" RepeatColumns="4">
                <ItemTemplate>
                    <input type="radio" name="Ppregurgitationaortic-button" class="rbt-finding" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                    <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div>
            <asp:DataList runat="server" ID="PpRegurgitationforMitralDatalist" CssClass="Ppmitral-regurgitation-finding regurgitation-finding"
                RepeatDirection="Horizontal" RepeatColumns="4" EnableViewState="false">
                <ItemTemplate>
                    <input type="radio" name="Ppregurgitationmitral-button" class="rbt-finding" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                    <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div>
            <asp:DataList runat="server" ID="PpRegurgitationforPulmonicDatalist" CssClass="Pppulmonic-regurgitation-finding regurgitation-finding"
                RepeatDirection="Horizontal" RepeatColumns="4" EnableViewState="false">
                <ItemTemplate>
                    <input type="radio" name="Ppregurgitationpulmonic-button" class="rbt-finding" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                    <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div>
            <asp:DataList runat="server" ID="PpRegurgitationforTricuspidDatalist" CssClass="Pptricuspid-regurgitation-finding regurgitation-finding"
                RepeatDirection="Horizontal" RepeatColumns="4" EnableViewState="false">
                <ItemTemplate>
                    <input type="radio" name="Ppregurgitationtricuspid-button" class="rbt-finding" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                    <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
    <div class="uppersection_echo exclude-hide-evaluation physician-section clear-all-ppecho-selection non-normal-diagnosis" style="width: 360px;">
        <div>
            <b>Morphology Characteristics </b>
        </div>
        <div>
            <div style="float: left">
                <asp:DataList runat="server" ID="PpMorphologyAorticDatalist" CssClass="Ppaortic-morphology-finding"
                    RepeatDirection="Horizontal" RepeatColumns="4" EnableViewState="false">
                    <ItemTemplate>
                        <input type="checkbox" id="Ppmorphologyaorticcheckbox" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                        <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div style="float: left">
                &nbsp;&nbsp;Velocity
                <input type="text" style="width: 30px;" id="PpAorticVelocityTextbox" />
            </div>
        </div>
        <div>
            <div style="float: left">
                <asp:DataList runat="server" ID="PpMorphologyMitralDatalist" CssClass="Ppmitral-morphology-finding"
                    RepeatDirection="Horizontal" RepeatColumns="4" EnableViewState="false">
                    <ItemTemplate>
                        <input type="checkbox" id="Ppmorphologymitralcheckbox" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                        <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div style="float: left">
                &nbsp;&nbsp;P1/2T
                <input type="text" style="width: 30px;" id="PpPTTextbox" />
            </div>
        </div>
        <div>
            <div style="float: left">
                <asp:DataList runat="server" ID="PpMorphologyPulmonicDatalist" CssClass="Pppulmonic-morphology-finding"
                    RepeatDirection="Horizontal" RepeatColumns="4" EnableViewState="false">
                    <ItemTemplate>
                        <input type="checkbox" id="Ppmorphologypulmoniccheckbox" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                        <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div style="float: left">
                &nbsp;&nbsp;Velocity
                <input type="text" id="PpVelocityPulmonicTextbox" style="width: 30px;" />
            </div>
            <div style="clear: both">
            </div>
        </div>
        <div>
            <div style="float: left">
                <asp:DataList runat="server" ID="PpMorphologyTricuspidDatalist" CssClass="Pptricuspid-morphology-finding"
                    RepeatDirection="Horizontal" RepeatColumns="4" EnableViewState="false">
                    <ItemTemplate>
                        <input type="checkbox" id="Ppmorphologytricuspidcheckbox" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                        <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div style="float: left">
                &nbsp;&nbsp;PAP
                <input type="text" id="PpPapTextbox" style="width: 30px;" />
                &nbsp;&nbsp;Velocity
                <input type="text" id="PpVelocityTricuspidTextbox" style="width: 30px;" />
            </div>
            <div style="float: left">
                <input type="checkbox" id="PpMorphologyTricuspidHigh35MmHgOrGreaterCheckbox" />
                High, 35mmHg or greater
                <input type="checkbox" id="PpMorphologyTricuspidNormalCheckbox" />
                Normal
            </div>
        </div>
    </div>
</div>
<div style="float: left; clear: both; margin-bottom: 5px; width: 100%" class="non-normal-diagnosis">
    <div style="float: left; width: 185px;" class="exclude-hide-evaluation physician-section clear-all-ppecho-selection">
        <div class="margin-top-small">
            <input type="checkbox" id="PpDiastolicDysfunctionCheckbox" />
            Diastolic Dysfunction
        </div>
        <div class="margin-top-small">
            <input type="checkbox" id="PpPericardialEffusionCheckbox" />
            Pericardial Effusion
        </div>
        <div class="margin-top-small">
            <input type="checkbox" id="PpVentricularEnlargmentCheckbox" />
            Ventricular Enlargement
        </div>
        <div class="margin-top-small">
            <input type="checkbox" id="PpAorticRootCheckbox" />
            Aortic Root
        </div>
        <div class="margin-top-small">
            <input type="checkbox" id="PpVentricularHypertrophyCheckbox" />
            Ventricular Hypertrophy
        </div>
        <div class="margin-top-small">
            <input type="checkbox" id="PpAtrialEnlargmentCheckbox" />
            Atrial Enlargement
        </div>
        <div class="margin-top-small">
            <input type="checkbox" id="PpArrythmiaCheckbox" />
            Arrhythmia
        </div>
        <div class="margin-top-small" style="margin-left: 15px;">
            <input type="checkbox" id="PpAFibCheckbox" />A-Fib
            <input type="checkbox" id="PpAFlutterCheckbox" />A-Flutter
        </div>
        <div class="margin-top-small" style="margin-left: 15px;">
            <input type="checkbox" id="PpPACCheckbox" />PAC
            <input type="checkbox" id="PpPVCCheckbox" />PVC
        </div>
    </div>
    <div style="float: left; width: 380px;" class="exclude-hide-evaluation physician-section clear-all-ppecho-selection">
        <div class="margin-top-small">
            <asp:DataList runat="server" ID="PpDiastolicDysfunctionFindingDatalist" RepeatDirection="Horizontal"
                CssClass="Ppdiastolic-dysfunction-finding" RepeatColumns="4" EnableViewState="false">
                <ItemTemplate>
                    <input type="radio" name="Ppdiastolicdysfunction-button" class="rbt-finding" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                    <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div style="clear: both">
        </div>
        <div class="margin-top-small">
            <asp:DataList runat="server" ID="PpPericardialEffusionFindingDatalist" RepeatDirection="Horizontal"
                CssClass="Pppericardial-effusion-finding" RepeatColumns="4" EnableViewState="false">
                <ItemTemplate>
                    <input type="checkbox" id="Pppericardialeffusion" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                    <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div style="clear: both">
        </div>
        <div class="margin-top-small">
            <span style="float: left;">
                <input type="checkbox" id="PpLeftVEnlargementCheckbox" />
                Left
                <input type="text" style="width: 40px" id="PpLeftVEnlargementTextbox" />
                cm </span><span style="float: left;">
                    <input type="checkbox" id="PpRightVEnlargementCheckbox" />
                    Right
                    <input type="text" style="width: 40px" id="PpRightVEnlargementTextbox" />
                    cm </span>
        </div>
        <div style="clear: both">
        </div>
        <div class="margin-top-small">
            <span style="float: left;">
                <input type="checkbox" id="PpScleroticCheckbox" />
                Sclerotic</span><span style="float: left;">
                    <input type="checkbox" id="PpCalcifiedCheckbox" />
                    Calcified</span><span style="float: left;">
                        <input type="checkbox" id="PpEnlargedCheckbox" />
                        Enlarged
                        <input type="text" style="width: 40px" id="PpEnlargedTextbox" />
                        cm </span>
        </div>
        <div style="clear: both">
        </div>
        <div>
            <span style="float: left;">
                <input type="checkbox" id="PpLeftVHypertrophyCheckbox" />
                Left
                <input type="text" style="width: 40px" id="PpLeftVHypertrophyTextbox" />
                cm </span><span style="float: left;">
                    <input type="checkbox" id="PpRightVHypertrophyCheckbox" />
                    Right
                    <input type="text" style="width: 40px" id="PpRightVHypertrophyTextbox" />
                    cm </span><span style="float: left;">
                        <input type="checkbox" id="PpIvshCheckbox" />
                        IVSH
                        <input type="text" style="width: 40px" id="PpIvshTextbox" />
                        cm </span>
        </div>
        <div style="clear: both">
        </div>
        <div>
            <span style="float: left;">
                <input type="checkbox" id="PpLeftAtrialEnlargementCheckbox" />
                Left
                <input type="text" style="width: 40px" id="PpLeftAtrialEnlargementTextbox" />
                cm </span><span style="float: left;">
                    <input type="checkbox" id="PpRightAtrialEnlargementCheckbox" />
                    Right
                    <input type="text" style="width: 40px" id="PpRightAtrialEnlargementTextbox" />
                    cm </span>
        </div>
        <div style="clear: both">
        </div>
        <div>
            <span style="float: left;">
                <input type="checkbox" id="PpAsdCheckbox" />
                ASD </span><span style="float: left;">
                    <input type="checkbox" id="PpPfoCheckbox" />
                    PFO </span><span style="float: left;">
                        <input type="checkbox" id="PpFlailCheckbox" />
                        Flail AS</span>
        </div>
    </div>
    <div style="float: left; width: 360px;" class="exclude-hide-evaluation physician-section clear-all-ppecho-selection">
        <div style="float: left;">
            <span style="float: left;">
                <input type="checkbox" id="PpVsdCheckbox" />VSD
            </span>
            <span style="float: left;">
                <input type="checkbox" id="PpSamCheckbox" />Systolic Anterior Motion
            </span>
            <span style="float: left;">
                <input type="checkbox" id="PpLvotoCheckbox" />Left Ventricular Outflow Tract Obstruction
            </span>
            <span style="float: left;">
                <input type="checkbox" id="PpMitralAnnularCheckbox" />Mitral annular Ca++
            </span>
        </div>
        <div style="clear: both">
        </div>
        <div style="float: left;">
            <span style="float: left;">
                <input type="checkbox" id="PpRestrictedLeafletCheckbox" />
                Restricted Leaflet Motion</span> <span style="float: left;">
                    <input type="checkbox" id="PpRestrictedLeafletAorticCheckbox" />
                    Aortic</span> <span style="float: left;">
                        <input type="checkbox" id="PpRestrictedLeafletMitralCheckbox" />
                        Mitral</span> <span style="float: left;">
                            <input type="checkbox" id="PpRestrictedLeafletPulCheckbox" />
                            Pul</span><span style="float: left;">
                                <input type="checkbox" id="PpRestrictedLeafletTriCheckbox" />
                                Tri</span>
        </div>
        <div style="clear: both">
        </div>
        <div style="float: left; margin-top: 20px;" class="wall-motion-abnormality">
            <div>
                <strong>Wall Motion Abnormality </strong>
            </div>
            <div>
                <span style="float: left">
                    <input type="checkbox" id="PpHypokineticCheckbox" />
                    Hypokinetic </span><span style="float: left">
                        <input type="checkbox" id="PpAkineticCheckbox" />
                        Akinetic </span><span style="float: left">
                            <input type="checkbox" id="PpDyskineticCheckbox" />
                            Dyskinetic </span>
            </div>
            <div style="clear: both">
            </div>
            <div>
                <span style="float: left">
                    <input type="checkbox" id="PpAnteriorCheckbox" />
                    Anterior </span><span style="float: left">
                        <input type="checkbox" id="PpPosteriorCheckbox" />
                        Posterior </span><span style="float: left">
                            <input type="checkbox" id="PpApicalCheckbox" />
                            Apical </span>
            </div>
            <div style="clear: both">
            </div>
            <div>
                <span style="float: left">
                    <input type="checkbox" id="PpSeptalCheckbox" />
                    Septal </span><span style="float: left">
                        <input type="checkbox" id="PpLateralCheckbox" />
                        Lateral </span><span style="float: left">
                            <input type="checkbox" id="PpInferiorCheckbox" />
                            Inferior </span>
            </div>
        </div>
    </div>
</div>
<div class="left_info1" style="width: 45%;">
    <div class="left margin-top-small" id="unableScreenReasonDiv" style="width: 48%;">
        <asp:DataList runat="server" ID="PpEchoUnableScreenDatalist" EnableViewState="false"
            RepeatLayout="Flow" RepeatColumns="4" RepeatDirection="Horizontal" CssClass="Ppecho-unabletoscreen-dtl unable-to-screen-section">
            <ItemTemplate>
                <input type="checkbox" class="finding-unablescreen-checkbox" />&nbsp;<b><%# DataBinder.Eval(Container.DataItem, "DisplayName")%></b>
                &nbsp;&nbsp;
                <input type="hidden" class="finding-unablescreen-id" value='<%# Convert.ToString((int)DataBinder.Eval(Container.DataItem, "Reason"))%>' />
            </ItemTemplate>
        </asp:DataList>
    </div>
    <div class="lrow physician-section clear-all-selection">
        <a style="margin-left: 5px;" id="clear-all-ppecho" href="javascript:void(0);" onclick="clearAllPpEchoSelection();">Clear All Selection</a>
    </div>
</div>

<div class="rgt margin-top-small" id="Div1" style="width: 48%;">
    <b>Technician Notes: </b>
    <br />
    <textarea id="technotesPpecho" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
        rows="2" cols="54"></textarea>
</div>
<div class="left uploadmedia-Ppecho-div media-container-div" style="width: 937px; padding: 5px;"
    id="PpEchoMediaDiv">
</div>
<div class="left upload-media-section">
    <a href="javascript:OpenPopUp('Upload Images', '710', '/app/franchisee/technician/uploadTestImages.aspx?TestType=<%= (int)TestType.PPEcho %>&CustomerId=' + customerId);">Upload Media </a>
</div>
<div style="float: left; width: 100%; clear: both; margin-top: 5px;" class="physician-section">
    <fieldset style="float: left; width: 98%; border-radius: 4px;">
        <legend>Remarks </legend>
        <div style="float: left; width: 40%;">
            <input type="checkbox" id="technicalltdreadablePpEchoinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Technically Limited</b><br />
            <input type="checkbox" id="repeatstudyunreadablePpEchoinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Unreadable</b><br />
            <input type="checkbox" id="criticalPpEcho" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b>
        </div>
        <div style="float: left; width: 58%;">
            <textarea id="physicianRemarksPpEcho" rows="3" style="width: 98%;"></textarea>
        </div>
        <div style="float: right; width: 58%; margin-right: 2%;">
            <b>Possible diagnosis codes:</b><br />
            <textarea id="diagnosisCodePpEcho" rows="2" style="width: 98%;" readonly="readonly"></textarea>
        </div>
    </fieldset>
</div>
<div style="float: left; width: 100%; clear: both; margin-top: 5px;">
</div>
    </div>
<div id="Ppecho_chat" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 50%;">
            <span class="org-heading" style="width: 100%;"><strong>Echocardiogram Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyPpecho" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="ppecho-retest-span">
            <input type="checkbox" id="Retest_38" />Retest
        </span>
    </div>
    <div class="hrows Ppecho-verificationpanel" style="color: Red; background: #fff0a5; border: solid 1px fff0a5; padding: 2px 2px 2px 5px; display: none;">
    </div>
     <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
             
     <div class="hlfbox">
           <div class="hrows">
             <div class="nrow" style="margin-left:12px;">
                  <input type="checkbox" id="chk_PpechocapturebyChat" />
                   <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
     </div>
             
     </div>
</div>
<script language="javascript" type="text/javascript">
    var testTypePpEcho = '<%= (long)TestType.PPEcho %>';
    var IsPpechoResultEntryExternaly = '<%= IsResultEntrybyChat %>';
    var Ppecho = null;

    function SetPpEchoData(testResult) {
        Ppecho = new PpEchocardiogram(testResult);
        Ppecho.setData();
    }

    function GetPpEchoData() {
        if (Ppecho == null) Ppecho = new PpEchocardiogram();
        return Ppecho.getData();
    }

</script>

