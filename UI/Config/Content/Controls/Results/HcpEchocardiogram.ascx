<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HcpEchocardiogram.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.HcpEchocardiogram" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/HcpEchocardiogram.js?q=<%= VersionNumber %>"></script>
<div id="HcpEcho_hip" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
<div class="orange-band test-section-header">
    <h5>
        <span class="org-heading"><strong>Echocardiogram Results</strong></span>
    </h5>
    <span class="chk_orngband">
        <select id="conductedbyHcpEcho" class="conductedby-ddl">
        </select>
    </span><span class="chk_orngband" id="HcpEcho-critical-span">
        <input type="checkbox" id="DescribeSelfPresentHcpEchoInputCheck" onclick="onClick_CriticalDataHcpEcho();" />Critical
    </span>
    <span class="chk_orngband" id="hcpEcho-priorityInQueue-span">
        <input type="checkbox" id="PriorityInQueueTestHcpEchoCheck" onclick="onClick_PriorityInQueueDataHcpEcho();" />Priority In Queue
    </span>
    <span class="chk_orngband" id="hcpEcho-retest-span">
        <input type="checkbox" id="Retest_47" />Retest
    </span>
</div>
<div class="exclude-hide-evaluation physician-section clear-all-HcpEcho-selection" style="float: left; clear: both; margin-bottom: 5px; width: 100%">
    <asp:DataList runat="server" ID="HcpEchoFindingsDatalist" CssClass="HcpEcho-finding finding-section"
        ShowHeader="false" EnableViewState="false" GridLines="None" RepeatDirection="Horizontal">
        <ItemTemplate>
            <input type="radio" name="HcpEchoFindingsRadioButton" class="rbt-finding" />
            <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id") %>' />
            <%# DataBinder.Eval(Container.DataItem, "Description").ToString().Length > 0 ? DataBinder.Eval(Container.DataItem, "Label")+ "(" + DataBinder.Eval(Container.DataItem, "Description") + ")":DataBinder.Eval(Container.DataItem, "Label") %>
        </ItemTemplate>
    </asp:DataList>
</div>
<div style="float: left; clear: both; margin-bottom: 5px; width: 100%">
    <div class="uppersection_echo exclude-hide-evaluation physician-section clear-all-HcpEcho-selection" style="width: 170px;">
        <div>
            <b>Estimated Ejection Fraction </b>
        </div>
        <div>
            <asp:DataList runat="server" ID="HcpEchoEjactionFractionFindingsDatalist" CssClass="HcpEchoejaction-fraction-finding"
                GridLines="None" EnableViewState="false" RepeatDirection="Vertical">
                <ItemTemplate>
                    <input type="radio" name="finding-HcpEchoejaction" class="rbt-finding" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                    <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                    <input type="hidden" class="finding-worstcaseorder" value='<%# DataBinder.Eval(Container.DataItem, "WorstCaseOrder")%>' />
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
    <div class="uppersection_valve_echo exclude-hide-evaluation physician-section clear-all-HcpEcho-selection" style="width: 90px;">
        <div>
            <b>Valve </b>
        </div>
        <div>
            <input type="checkbox" id="HcpEchoValveAorticCheckbox" />
            Aortic
        </div>
        <div>
            <input type="checkbox" id="HcpEchoValveMitralCheckbox" />
            Mitral
        </div>
        <div>
            <input type="checkbox" id="HcpEchoValvePulmonicCheckbox" />
            Pulmonic
        </div>
        <div>
            <input type="checkbox" id="HcpEchoValveTricuspidCheckbox" />
            Tricuspid
        </div>
    </div>
    <div class="uppersection_echo exclude-hide-evaluation physician-section clear-all-HcpEcho-selection" style="width: 270px;">
        <div>
            <div>
                <b>Regurgitation</b>
                <a style="margin-left: 10px; display: none;" id="claer-all-HcpEchoregurgitation" href="javascript:void(0);" onclick="clearAllHcpEchoRegurgitationSelection();">Clear All Selection</a>
            </div>
        </div>
        <div>
            <asp:DataList runat="server" ID="HcpEchoRegurgitationforAorticDatalist" CssClass="HcpEchoaortic-regurgitation-finding regurgitation-finding"
                RepeatDirection="Horizontal" EnableViewState="false" RepeatColumns="4">
                <ItemTemplate>
                    <input type="radio" name="HcpEchoregurgitationaortic-button" class="rbt-finding" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                    <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div>
            <asp:DataList runat="server" ID="HcpEchoRegurgitationforMitralDatalist" CssClass="HcpEchomitral-regurgitation-finding regurgitation-finding"
                RepeatDirection="Horizontal" RepeatColumns="4" EnableViewState="false">
                <ItemTemplate>
                    <input type="radio" name="HcpEchoregurgitationmitral-button" class="rbt-finding" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                    <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div>
            <asp:DataList runat="server" ID="HcpEchoRegurgitationforPulmonicDatalist" CssClass="HcpEchopulmonic-regurgitation-finding regurgitation-finding"
                RepeatDirection="Horizontal" RepeatColumns="4" EnableViewState="false">
                <ItemTemplate>
                    <input type="radio" name="HcpEchoregurgitationpulmonic-button" class="rbt-finding" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                    <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div>
            <asp:DataList runat="server" ID="HcpEchoRegurgitationforTricuspidDatalist" CssClass="HcpEchotricuspid-regurgitation-finding regurgitation-finding"
                RepeatDirection="Horizontal" RepeatColumns="4" EnableViewState="false">
                <ItemTemplate>
                    <input type="radio" name="HcpEchoregurgitationtricuspid-button" class="rbt-finding" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                    <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
    <div class="uppersection_echo exclude-hide-evaluation physician-section clear-all-HcpEchoecho-selection non-normal-diagnosis" style="width: 360px;">
        <div>
            <b>Morphology Characteristics </b>
        </div>
        <div>
            <div style="float: left">
                <asp:DataList runat="server" ID="HcpEchoMorphologyAorticDatalist" CssClass="HcpEchoaortic-morphology-finding"
                    RepeatDirection="Horizontal" RepeatColumns="4" EnableViewState="false">
                    <ItemTemplate>
                        <input type="checkbox" id="HcpEchomorphologyaorticcheckbox" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                        <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div style="float: left">
                &nbsp;&nbsp;Velocity
                <input type="text" style="width: 30px;" id="HcpEchoAorticVelocityTextbox" />
            </div>
        </div>
        <div>
            <div style="float: left">
                <asp:DataList runat="server" ID="HcpEchoMorphologyMitralDatalist" CssClass="HcpEchomitral-morphology-finding"
                    RepeatDirection="Horizontal" RepeatColumns="4" EnableViewState="false">
                    <ItemTemplate>
                        <input type="checkbox" id="HcpEchomorphologymitralcheckbox" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                        <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div style="float: left">
                &nbsp;&nbsp;P1/2T
                <input type="text" style="width: 30px;" id="HcpEchoPTTextbox" />
            </div>
        </div>
        <div>
            <div style="float: left">
                <asp:DataList runat="server" ID="HcpEchoMorphologyPulmonicDatalist" CssClass="HcpEchopulmonic-morphology-finding"
                    RepeatDirection="Horizontal" RepeatColumns="4" EnableViewState="false">
                    <ItemTemplate>
                        <input type="checkbox" id="HcpEchomorphologypulmoniccheckbox" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                        <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div style="float: left">
                &nbsp;&nbsp;Velocity
                <input type="text" id="HcpEchoVelocityPulmonicTextbox" style="width: 30px;" />
            </div>
            <div style="clear: both">
            </div>
        </div>
        <div>
            <div style="float: left">
                <asp:DataList runat="server" ID="HcpEchoMorphologyTricuspidDatalist" CssClass="HcpEchotricuspid-morphology-finding"
                    RepeatDirection="Horizontal" RepeatColumns="4" EnableViewState="false">
                    <ItemTemplate>
                        <input type="checkbox" id="HcpEchomorphologytricuspidcheckbox" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                        <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div style="float: left">
                &nbsp;&nbsp;PAP
                <input type="text" id="HcpEchoPapTextbox" style="width: 30px;" />
                &nbsp;&nbsp;Velocity
                <input type="text" id="HcpEchoVelocityTricuspidTextbox" style="width: 30px;" />
            </div>
            <div style="float: left">
                <input type="checkbox" id="HcpEchoMorphologyTricuspidHigh35MmHgOrGreaterCheckbox" />
                High, 35mmHg or greater
                <input type="checkbox" id="HcpEchoMorphologyTricuspidNormalCheckbox" />
                Normal
            </div>
        </div>
    </div>
</div>
<div style="float: left; clear: both; margin-bottom: 5px; width: 100%" class="non-normal-diagnosis">
    <div style="float: left; width: 185px;" class="exclude-hide-evaluation physician-section clear-all-HcpEcho-selection">
        <div class="margin-top-small">
            <input type="checkbox" id="HcpEchoDiastolicDysfunctionCheckbox" />
            Diastolic Dysfunction
        </div>
        <div class="margin-top-small">
            <input type="checkbox" id="HcpEchoPericardialEffusionCheckbox" />
            Pericardial Effusion
        </div>
        <div class="margin-top-small">
            <input type="checkbox" id="HcpEchoVentricularEnlargmentCheckbox" />
            Ventricular Enlargement
        </div>
        <div class="margin-top-small">
            <input type="checkbox" id="HcpEchoAorticRootCheckbox" />
            Aortic Root
        </div>
        <div class="margin-top-small">
            <input type="checkbox" id="HcpEchoVentricularHypertrophyCheckbox" />
            Ventricular Hypertrophy
        </div>
        <div class="margin-top-small">
            <input type="checkbox" id="HcpEchoAtrialEnlargmentCheckbox" />
            Atrial Enlargement
        </div>
        <div class="margin-top-small">
            <input type="checkbox" id="HcpEchoArrythmiaCheckbox" />
            Arrhythmia
        </div>
        <div class="margin-top-small" style="margin-left: 15px;">
            <input type="checkbox" id="HcpEchoAFibCheckbox" />A-Fib
            <input type="checkbox" id="HcpEchoAFlutterCheckbox" />A-Flutter
        </div>
        <div class="margin-top-small" style="margin-left: 15px;">
            <input type="checkbox" id="HcpEchoPACCheckbox" />PAC
            <input type="checkbox" id="HcpEchoPVCCheckbox" />PVC
        </div>
    </div>
    <div style="float: left; width: 380px;" class="exclude-hide-evaluation physician-section clear-all-HcpEcho-selection">
        <div class="margin-top-small">
            <asp:DataList runat="server" ID="HcpEchoDiastolicDysfunctionFindingDatalist" RepeatDirection="Horizontal"
                CssClass="HcpEchodiastolic-dysfunction-finding" RepeatColumns="4" EnableViewState="false">
                <ItemTemplate>
                    <input type="radio" name="HcpEchodiastolicdysfunction-button" class="rbt-finding" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                    <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div style="clear: both">
        </div>
        <div class="margin-top-small">
            <asp:DataList runat="server" ID="HcpEchoPericardialEffusionFindingDatalist" RepeatDirection="Horizontal"
                CssClass="HcpEchopericardial-effusion-finding" RepeatColumns="4" EnableViewState="false">
                <ItemTemplate>
                    <input type="checkbox" id="HcpEchopericardialeffusion" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                    <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div style="clear: both">
        </div>
        <div class="margin-top-small">
            <span style="float: left;">
                <input type="checkbox" id="HcpEchoLeftVEnlargementCheckbox" />
                Left
                <input type="text" style="width: 40px" id="HcpEchoLeftVEnlargementTextbox" />
                cm </span><span style="float: left;">
                    <input type="checkbox" id="HcpEchoRightVEnlargementCheckbox" />
                    Right
                    <input type="text" style="width: 40px" id="HcpEchoRightVEnlargementTextbox" />
                    cm </span>
        </div>
        <div style="clear: both">
        </div>
        <div class="margin-top-small">
            <span style="float: left;">
                <input type="checkbox" id="HcpEchoScleroticCheckbox" />
                Sclerotic</span><span style="float: left;">
                    <input type="checkbox" id="HcpEchoCalcifiedCheckbox" />
                    Calcified</span><span style="float: left;">
                        <input type="checkbox" id="HcpEchoEnlargedCheckbox" />
                        Enlarged
                        <input type="text" style="width: 40px" id="HcpEchoEnlargedTextbox" />
                        cm </span>
        </div>
        <div style="clear: both">
        </div>
        <div>
            <span style="float: left;">
                <input type="checkbox" id="HcpEchoLeftVHypertrophyCheckbox" />
                Left
                <input type="text" style="width: 40px" id="HcpEchoLeftVHypertrophyTextbox" />
                cm </span><span style="float: left;">
                    <input type="checkbox" id="HcpEchoRightVHypertrophyCheckbox" />
                    Right
                    <input type="text" style="width: 40px" id="HcpEchoRightVHypertrophyTextbox" />
                    cm </span><span style="float: left;">
                        <input type="checkbox" id="HcpEchoIvshCheckbox" />
                        IVSH
                        <input type="text" style="width: 40px" id="HcpEchoIvshTextbox" />
                        cm </span>
        </div>
        <div style="clear: both">
        </div>
        <div>
            <span style="float: left;">
                <input type="checkbox" id="HcpEchoLeftAtrialEnlargementCheckbox" />
                Left
                <input type="text" style="width: 40px" id="HcpEchoLeftAtrialEnlargementTextbox" />
                cm </span><span style="float: left;">
                    <input type="checkbox" id="HcpEchoRightAtrialEnlargementCheckbox" />
                    Right
                    <input type="text" style="width: 40px" id="HcpEchoRightAtrialEnlargementTextbox" />
                    cm </span>
        </div>
        <div style="clear: both">
        </div>
        <div>
            <span style="float: left;">
                <input type="checkbox" id="HcpEchoAsdCheckbox" />
                ASD </span><span style="float: left;">
                    <input type="checkbox" id="HcpEchoPfoCheckbox" />
                    PFO </span><span style="float: left;">
                        <input type="checkbox" id="HcpEchoFlailCheckbox" />
                        Flail AS</span>
        </div>
    </div>
    <div style="float: left; width: 360px;" class="exclude-hide-evaluation physician-section clear-all-HcpEcho-selection">
        <div style="float: left;">
            <span style="float: left;">
                <input type="checkbox" id="HcpEchoVsdCheckbox" />VSD
            </span>
            <span style="float: left;">
                <input type="checkbox" id="HcpEchoSamCheckbox" />Systolic Anterior Motion
            </span>
            <span style="float: left;">
                <input type="checkbox" id="HcpEchoLvotoCheckbox" />Left Ventricular Outflow Tract Obstruction
            </span>
            <span style="float: left;">
                <input type="checkbox" id="HcpEchoMitralAnnularCheckbox" />Mitral annular Ca++
            </span>
        </div>
        <div style="clear: both">
        </div>
        <div style="float: left;">
            <span style="float: left;">
                <input type="checkbox" id="HcpEchoRestrictedLeafletCheckbox" />
                Restricted Leaflet Motion</span> <span style="float: left;">
                    <input type="checkbox" id="HcpEchoRestrictedLeafletAorticCheckbox" />
                    Aortic</span> <span style="float: left;">
                        <input type="checkbox" id="HcpEchoRestrictedLeafletMitralCheckbox" />
                        Mitral</span> <span style="float: left;">
                            <input type="checkbox" id="HcpEchoRestrictedLeafletPulCheckbox" />
                            Pul</span><span style="float: left;">
                                <input type="checkbox" id="HcpEchoRestrictedLeafletTriCheckbox" />
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
                    <input type="checkbox" id="HcpEchoHypokineticCheckbox" />
                    Hypokinetic </span><span style="float: left">
                        <input type="checkbox" id="HcpEchoAkineticCheckbox" />
                        Akinetic </span><span style="float: left">
                            <input type="checkbox" id="HcpEchoDyskineticCheckbox" />
                            Dyskinetic </span>
            </div>
            <div style="clear: both">
            </div>
            <div>
                <span style="float: left">
                    <input type="checkbox" id="HcpEchoAnteriorCheckbox" />
                    Anterior </span><span style="float: left">
                        <input type="checkbox" id="HcpEchoPosteriorCheckbox" />
                        Posterior </span><span style="float: left">
                            <input type="checkbox" id="HcpEchoApicalCheckbox" />
                            Apical </span>
            </div>
            <div style="clear: both">
            </div>
            <div>
                <span style="float: left">
                    <input type="checkbox" id="HcpEchoSeptalCheckbox" />
                    Septal </span><span style="float: left">
                        <input type="checkbox" id="HcpEchoLateralCheckbox" />
                        Lateral </span><span style="float: left">
                            <input type="checkbox" id="HcpEchoInferiorCheckbox" />
                            Inferior </span>
            </div>
        </div>
    </div>
</div>
<div class="left_info1">
    <div class="left margin-top-small" id="unableScreenReasonDiv" style="width: 48%;">
        <asp:DataList runat="server" ID="HcpEchoUnableScreenDatalist" EnableViewState="false"
            RepeatLayout="Flow" RepeatColumns="4" RepeatDirection="Horizontal" CssClass="HcpEcho-unabletoscreen-dtl unable-to-screen-section">
            <ItemTemplate>
                <input type="checkbox" class="finding-unablescreen-checkbox" />&nbsp;<b><%# DataBinder.Eval(Container.DataItem, "DisplayName")%></b>
                &nbsp;&nbsp;
                <input type="hidden" class="finding-unablescreen-id" value='<%# Convert.ToString((int)DataBinder.Eval(Container.DataItem, "Reason"))%>' />
            </ItemTemplate>
        </asp:DataList>
    </div>
    <div class="lrow physician-section clear-all-selection">
        <a style="margin-left: 5px;" id="clear-all-HcpEcho" href="javascript:void(0);" onclick="clearAllHcpEchoSelection();">Clear All Selection</a>
    </div>
</div>

<div class="rgt_info1">
    <div class="rrow margin-top-small">
        <b>Technician Notes: </b>
        <br />
        <textarea id="technotesHcpEcho" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
            rows="2" cols="54"></textarea>
    </div>
    <div class="rrow test-not-performed-section" id="testnotPerformedHcpEcho">
        <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0" />
        <b>Test Not Performed</b>
        <div class="test-not-performed-container" style="display: none;">
            <b>Reason : </b>
            <br />
            <asp:DropDownList ID="ddlTestNotPerformedReasonHcpEcho" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
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
<div class="left uploadmedia-HcpEcho-div media-container-div" style="width: 937px; padding: 5px;"
    id="HcpEchoMediaDiv">
</div>
<div class="left upload-media-section">
    <a href="javascript:OpenPopUp('Upload Images', '710', '/app/franchisee/technician/uploadTestImages.aspx?TestType=<%= (int)TestType.HCPEcho %>&CustomerId=' + customerId);">Upload Media </a>
</div>
<div style="float: left; width: 100%; clear: both; margin-top: 5px;" class="physician-section">
    <fieldset style="float: left; width: 98%; border-radius: 4px;">
        <legend>Remarks </legend>
        <div style="float: left; width: 40%;">
            <input type="checkbox" id="technicalltdreadableHcpEchoinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Technically Limited</b><br />
            <input type="checkbox" id="repeatstudyunreadableHcpEchoinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Unreadable</b><br />
            <input type="checkbox" id="criticalHcpEcho" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b>
        </div>
        <div style="float: left; width: 58%;">
            <textarea id="physicianRemarksHcpEcho" rows="3" style="width: 98%;"></textarea>
        </div>
    </fieldset>
</div>
<div style="float: left; width: 100%; clear: both; margin-top: 5px;">
</div>
    </div>
<div id="HcpEcho_chat" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 50%;">
            <span class="org-heading" style="width: 100%;"><strong>Echocardiogram Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyHcpEcho" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="hcpEcho-retest-span">
            <input type="checkbox" id="Retest_47" />Retest
        </span>
    </div>
    <div class="hrows HcpEcho-verificationpanel" style="color: Red; background: #fff0a5; border: solid 1px fff0a5; padding: 2px 2px 2px 5px; display: none;">
    </div>
     <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
             
     <div class="hlfbox">
           <div class="hrows">
             <div class="nrow" style="margin-left:12px;">
                  <input type="checkbox" id="chk_HcpEchocapturebyChat" />
                   <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
     </div>
             
     </div>
</div>
<script language="javascript" type="text/javascript">
    var testTypeHcpEcho = '<%= (long)TestType.HCPEcho %>';
    var IsHcpEchoResultEntryExternaly = '<%= IsResultEntrybyChat %>';
    var HcpEcho = null;

    function SetHcpEchoData(testResult) {
        HcpEcho = new HcpEchocardiogram(testResult);
        HcpEcho.setData();
    }

    function GetHcpEchoData() {
        if (HcpEcho == null) HcpEcho = new HcpEchocardiogram();
        return HcpEcho.getData();
    }

</script>
