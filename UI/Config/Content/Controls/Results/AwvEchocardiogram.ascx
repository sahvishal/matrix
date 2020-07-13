<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AwvEchocardiogram.ascx.cs" Inherits="Falcon.App.UI.Config.Content.Controls.Results.AwvEcho" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/AwvEchocardiogram.js?q=<%= VersionNumber %>"></script>
<style type="text/css">
    .fourcolumn, .threecolumn, .two-column {
        width: 100%;
        float: left;
    }

    .column {
        float: left;
        padding-right: 10px;
    }

    .fourcolumn .column {
        width: 25%;
        padding-right: 0 !important;
    }

    .threecolumn .first-column {
        width: 31%;
        float: left;
    }

    .threecolumn .second-column {
        width: 35%;
        float: left;
    }

    .threecolumn .third-column {
        width: 33%;
        float: left;
    }

    .two-column .first-column {
        width: 50%;
        float: left;
    }

    .two-column .second-column {
        width: 50%;
        float: left;
    }

    .conclusion-section fieldset {
        border-radius: 4px;
    }

    .AwvEcho-ejaction-fraction-finding td {
        display: inline;
        padding-right: 15px;
    }
</style>

<div id="awvEcho_hip" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
<div class="orange-band test-section-header">
    <h5>
        <span class="org-heading"><strong>Echocardiogram Results</strong></span>
    </h5>
    <span class="chk_orngband">
        <select id="conductedbyAwvEcho" class="conductedby-ddl">
        </select>
    </span><span class="chk_orngband" id="AwvEcho-critical-span">
        <input type="checkbox" id="DescribeSelfPresentAwvEchoInputCheck" onclick="onClick_CriticalDataAwvEcho();" />Critical
    </span>
    <span class="chk_orngband" id="awvEcho-priorityInQueue-span">
        <input type="checkbox" id="PriorityInQueueTestAwvEchoCheck" onclick="onClick_PriorityInQueueDataAwvEcho();" />Priority In Queue
    </span>
    <span class="chk_orngband" id="awvEcho-retest-span">
        <input type="checkbox" id="Retest_54" />Retest
    </span>
</div>
<div class="exclude-hide-evaluation physician-section clear-all-AwvEcho-selection" style="float: left; clear: both; margin-bottom: 5px; width: 100%">
    <asp:DataList runat="server" ID="AwvEchoFindingsDatalist" CssClass="AwvEcho-finding finding-section"
        ShowHeader="false" EnableViewState="false" GridLines="None" RepeatDirection="Horizontal">
        <ItemTemplate>
            <input type="radio" name="AwvEchoFindingsRadioButton" class="rbt-finding" />
            <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id") %>' />
            <%# DataBinder.Eval(Container.DataItem, "Description").ToString().Length > 0 ? DataBinder.Eval(Container.DataItem, "Label")+ "(" + DataBinder.Eval(Container.DataItem, "Description") + ")":DataBinder.Eval(Container.DataItem, "Label") %>
        </ItemTemplate>
    </asp:DataList>
</div>
<div class="exclude-hide-evaluation physician-section clear-all-AwvEcho-selection" style="float: left; clear: both; margin-bottom: 5px; width: 100%">
    <div>
        <b>Estimated Ejection Fraction </b>
    </div>
    <div>
        <asp:DataList runat="server" ID="AwvEchoEjactionFractionFindingsDatalist" CssClass="AwvEcho-ejaction-fraction-finding"
            GridLines="None" EnableViewState="false" RepeatDirection="Horizontal">
            <ItemTemplate>
                <input type="radio" name="AwvEcho-finding-ejaction" class="rbt-finding" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                <input type="hidden" class="finding-worstcaseorder" value='<%# DataBinder.Eval(Container.DataItem, "WorstCaseOrder")%>' />
            </ItemTemplate>
        </asp:DataList>
    </div>
</div>
<div style="float: left; clear: both; margin-bottom: 5px; width: 100%">
    <div class="uppersection_valve_echo exclude-hide-evaluation physician-section clear-all-AwvEcho-selection" style="width: 90px;">
        <div>
            <b>Valve </b>
        </div>
        <div>
            <input type="checkbox" id="AwvEchoValveAorticCheckbox" />
            Aortic
        </div>
        <div>
            <input type="checkbox" id="AwvEchoValveMitralCheckbox" />
            Mitral
        </div>
        <div>
            <input type="checkbox" id="AwvEchoValvePulmonicCheckbox" />
            Pulmonic
        </div>
        <div>
            <input type="checkbox" id="AwvEchoValveTricuspidCheckbox" />
            Tricuspid
        </div>
    </div>
    <div class="uppersection_echo exclude-hide-evaluation physician-section clear-all-AwvEcho-selection" style="width: 210px;">
        <div>
            <div>
                <b>Regurgitation</b>
                <a style="margin-left: 10px; display: none;" id="clear-all-regurgitationAwvEcho" href="javascript:void(0);" onclick="clearAllAwvEchoRegurgitationSelection();">Clear All Selection</a>
            </div>
        </div>
        <div>
            <asp:DataList runat="server" ID="AwvEchoRegurgitationforAorticDatalist" CssClass="AwvEchoaortic-regurgitation-finding"
                RepeatDirection="Horizontal" EnableViewState="false" RepeatColumns="4">
                <ItemTemplate>
                    <input type="radio" name="AwvEchoregurgitationaortic-button" class="rbt-finding" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                    <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div>
            <asp:DataList runat="server" ID="AwvEchoRegurgitationforMitralDatalist" CssClass="AwvEchomitral-regurgitation-finding"
                RepeatDirection="Horizontal" RepeatColumns="4" EnableViewState="false">
                <ItemTemplate>
                    <input type="radio" name="AwvEchoregurgitationmitral-button" class="rbt-finding" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                    <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div>
            <asp:DataList runat="server" ID="AwvEchoRegurgitationforPulmonicDatalist" CssClass="AwvEchopulmonic-regurgitation-finding"
                RepeatDirection="Horizontal" RepeatColumns="4" EnableViewState="false">
                <ItemTemplate>
                    <input type="radio" name="AwvEchoregurgitationpulmonic-button" class="rbt-finding" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                    <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div>
            <asp:DataList runat="server" ID="AwvEchoRegurgitationforTricuspidDatalist" CssClass="AwvEchotricuspid-regurgitation-finding"
                RepeatDirection="Horizontal" RepeatColumns="4" EnableViewState="false">
                <ItemTemplate>
                    <input type="radio" name="AwvEchoregurgitationtricuspid-button" class="rbt-finding" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                    <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
    <div class="uppersection_echo exclude-hide-evaluation physician-section" style="width: 550px;">
        <div style="float: left; clear: both;">
            <b>Morphology Characteristics </b>
        </div>
        <div style="float: left; clear: both;">
            <div style="float: left">
                <asp:DataList runat="server" ID="AwvEchoMorphologyAorticDatalist" CssClass="AwvEchoaortic-morphology-finding"
                    RepeatDirection="Horizontal" RepeatColumns="4" EnableViewState="false">
                    <ItemTemplate>
                        <input type="checkbox" id="AwvEchomorphologyaorticcheckbox" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                        <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div style="float: left">
                &nbsp;&nbsp;Velocity
                <input type="text" style="width: 30px;" id="AwvEchoAorticVelocityTextbox" />
            </div>
            <div style="float: left">
                &nbsp;&nbsp;Peak Gradient
                <input type="text" style="width: 30px;" id="PeakGradient" />
            </div>
            <div style="float: left">
                &nbsp;&nbsp;Est. VA
                <input type="text" style="width: 30px;" id="AorticEstimatedValveArea" />
            </div>
            <div style="float: left">
                &nbsp;&nbsp;Est. RV
                <input type="text" style="width: 30px;" id="AorticEstimatedRightValve" />
            </div>
        </div>
        <div style="float: left; clear: both;">
            <div style="float: left">
                <asp:DataList runat="server" ID="AwvEchoMorphologyMitralDatalist" CssClass="AwvEchomitral-morphology-finding"
                    RepeatDirection="Horizontal" RepeatColumns="4" EnableViewState="false">
                    <ItemTemplate>
                        <input type="checkbox" id="AwvEchomorphologymitralcheckbox" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                        <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div style="float: left">
                &nbsp;&nbsp;P1/2T
                <input type="text" style="width: 30px;" id="AwvEchoPTTextbox" />
            </div>
            <div style="float: left">
                &nbsp;&nbsp;Est. VA
                <input type="text" style="width: 30px;" id="MitralEstimatedValveArea" />
            </div>
            <div style="float: left">
                &nbsp;&nbsp;Est. RV
                <input type="text" style="width: 30px;" id="MitralEstimatedRightValve" />
            </div>
        </div>
        <div style="float: left; clear: both;">
            <div style="float: left">
                <asp:DataList runat="server" ID="AwvEchoMorphologyPulmonicDatalist" CssClass="AwvEchopulmonic-morphology-finding"
                    RepeatDirection="Horizontal" RepeatColumns="4" EnableViewState="false">
                    <ItemTemplate>
                        <input type="checkbox" id="AwvEchomorphologypulmoniccheckbox" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                        <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div style="float: left">
                &nbsp;Velocity
                <input type="text" id="AwvEchoVelocityPulmonicTextbox" style="width: 30px;" />
            </div>
            <div style="float: left">
                &nbsp;&nbsp;Est. VA
                <input type="text" style="width: 30px;" id="PulmonicEstimatedValveArea" />
            </div>
        </div>
        <div style="float: left; clear: both;">
            <div style="float: left">
                <asp:DataList runat="server" ID="AwvEchoMorphologyTricuspidDatalist" CssClass="AwvEchotricuspid-morphology-finding"
                    RepeatDirection="Horizontal" RepeatColumns="4" EnableViewState="false">
                    <ItemTemplate>
                        <input type="checkbox" id="AwvEchomorphologytricuspidcheckbox" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                        <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div style="float: left">
                &nbsp;&nbsp;PAP
                <input type="text" id="AwvEchoPapTextbox" style="width: 30px;" />
                &nbsp;&nbsp;Velocity
                <input type="text" id="AwvEchoVelocityTricuspidTextbox" style="width: 30px;" />
            </div>
            <div style="float: left">
                &nbsp;&nbsp;Est. VA
                <input type="text" style="width: 30px;" id="TricuspidEstimatedValveArea" />
            </div>
            <div style="float: left; clear: both">
                <input type="checkbox" id="AwvEchoMorphologyTricuspidHigh35MmHgOrGreaterCheckbox" />
                High, 35mmHg or greater
                <input type="checkbox" id="AwvEchoMorphologyTricuspidNormalCheckbox" />
                Normal
            </div>
        </div>
    </div>
</div>
<div style="float: left; clear: both; margin-bottom: 5px; width: 100%">
    <div style="float: left; width: 175px;" class="exclude-hide-evaluation physician-section clear-all-AwvEcho-selection">
        <div class="margin-top-small">
            <input type="checkbox" id="AwvEchoDiastolicDysfunctionCheckbox" />
            Diastolic Dysfunction
        </div>
        <div class="margin-top-small">
            <span style="float: left; width: 23px;">
                <input type="checkbox" id="AwvEchoConsistentLvDiastolicFailureCheckbox" />
            </span>
            <span>
                Consistent with LV Diastolic Failure
            </span>
        </div>
        <div class="margin-top-small" style="display: block; white-space: nowrap;">
            <span style="float: left; width: 23px;">
                <input type="checkbox" id="AwvEchoConsistentHypertensiveHeartDiseaseWithDiastolicHeartFailureCheckbox" />
            </span>
            <span>
                Consistent with Hypertensive Heart Disease with Diastolic Heart Failure
            </span>
        </div>
        <div class="margin-top-small" style="padding-top: 2px;">
            <input type="checkbox" id="AwvEchoPericardialEffusionCheckbox" />
            Pericardial Effusion
        </div>
        <div class="margin-top-small" style="padding-top: 3px;">
            <input type="checkbox" id="AwvEchoAorticRootCheckbox" />
            Aortic Root
        </div>
        <div class="margin-top-small" style="padding-top: 27px;">
            <input type="checkbox" id="AwvEchoVentricularEnlargmentCheckbox" />
            Ventricular Enlargement
        </div>
        <div class="margin-top-small">
            <input type="checkbox" id="AwvEchoVentricularHypertrophyCheckbox" />
            Ventricular Hypertrophy
        </div>
        <div class="margin-top-small">
            <input type="checkbox" id="AwvEchoAtrialEnlargmentCheckbox" />
            Atrial Enlargement
        </div>
        <div class="margin-top-small">
            <input type="checkbox" id="AwvEchoArrythmiaCheckbox" />
            Arrhythmia
        </div>
        <div class="margin-top-small" style="margin-left: 15px;">
            <input type="checkbox" id="AwvEchoAFibCheckbox" />A-Fib
            <input type="checkbox" id="AwvEchoAFlutterCheckbox" />A-Flutter
        </div>
        <div class="margin-top-small" style="margin-left: 15px;">
            <input type="checkbox" id="AwvEchoPACCheckbox" />PAC
            <input type="checkbox" id="AwvEchoPVCCheckbox" />PVC
        </div>
    </div>
    <div style="float: left; width: 390px;" class="exclude-hide-evaluation physician-section clear-all-AwvEcho-selection">
        <div class="margin-top-small">
            <div style="float: left;">
                <asp:DataList runat="server" ID="AwvEchoDiastolicDysfunctionFindingDatalist" RepeatDirection="Horizontal"
                    CssClass="AwvEchodiastolic-dysfunction-finding" RepeatColumns="4" EnableViewState="false">
                    <ItemTemplate>
                        <input type="radio" id="AwvEchodiastolicdysfunction" class="rbt-finding" name="AwvEchodiastolicdysfunction" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                        <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                        <label style="display: none"><%# DataBinder.Eval(Container.DataItem, "Label") %></label>
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div style="float: left; padding-left: 5px; padding-top: 3px;">
                E/e' Ratio
                <input type="text" style="width: 40px" id="DiastolicDysfunctionEeRatio" />
            </div>
        </div>
        <div style="clear: both">
        </div>
        <div class="margin-top-small">
            <span style="float: left; width: 23px;">
                <input type="checkbox" id="AwvEchoConsistentHypertensiveHeartDiseaseWithoutDiastolicHeartFailureCheckbox" />
            </span>
            <span>
                Consistent with Hypertensive Heart Disease without Diastolic Heart Failure
            </span>
        </div>
        <div class="margin-top-small" style="margin-top: 26px;">
            <asp:DataList runat="server" ID="AwvEchoPericardialEffusionFindingDatalist" RepeatDirection="Horizontal"
                CssClass="AwvEchopericardial-effusion-finding" RepeatColumns="4" EnableViewState="false">
                <ItemTemplate>
                    <input type="checkbox" id="AwvEchopericardialeffusion" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                    <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                    <label style="display: none"><%# DataBinder.Eval(Container.DataItem, "Label") %></label>
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div style="clear: both">
        </div>
        <div class="margin-top-small">
            <span style="float: left;">
                <input type="checkbox" id="AwvEchoScleroticCheckbox" />Sclerotic
            </span>
            <span style="float: left;">
                <input type="checkbox" id="AwvEchoCalcifiedCheckbox" />Calcified
            </span>
            <span style="float: left; padding-left: 20px; padding-top: 2px;">
                <input type="checkbox" id="AwvEchoEnlargedCheckbox" style="display: none;" />Dimension
                <input type="text" style="width: 40px" id="AwvEchoEnlargedTextbox" />cm 
            </span>
        </div>
        <div style="clear: both">
        </div>
        <div class="margin-top-small">
            <span style="float: left;">
                <input type="checkbox" id="AwvEchoAscendingAortaArchCheckbox" />Ascending Aorta/Arch
            </span>
            <span style="float: left;">
                <input type="checkbox" id="AwvEchoAtherosclerosisCheckbox" />Atherosclerosis
            </span>
        </div>
        <div style="clear: both">
        </div>
        <div class="margin-top-small">
            <span style="float: left;">
                <input type="checkbox" id="AwvEchoLeftVEnlargementCheckbox" />
                Left
                <input type="text" style="width: 40px" id="AwvEchoLeftVEnlargementTextbox" />
                cm </span><span style="float: left;">
                    <input type="checkbox" id="AwvEchoRightVEnlargementCheckbox" />
                    Right
                    <input type="text" style="width: 40px" id="AwvEchoRightVEnlargementTextbox" />
                    cm </span>
        </div>
        <div style="clear: both">
        </div>

        <div>
            <span style="float: left;">
                <input type="checkbox" id="AwvEchoLeftVHypertrophyCheckbox" />Left
                <input type="text" style="width: 40px" id="AwvEchoLeftVHypertrophyTextbox" />cm 
            </span>
            <span style="float: left;">
                <input type="checkbox" id="AwvEchoRightVHypertrophyCheckbox" />Right
                <input type="text" style="width: 40px" id="AwvEchoRightVHypertrophyTextbox" />cm 
            </span>
            <span style="float: left;">
                <input type="checkbox" id="AwvEchoIvshCheckbox" />IVSH
                <input type="text" style="width: 40px" id="AwvEchoIvshTextbox" />cm 
            </span>
        </div>
        <div style="clear: both">
        </div>
        <div>
            <span style="float: left;">
                <input type="checkbox" id="AwvEchoLeftAtrialEnlargementCheckbox" />Left
                <input type="text" style="width: 40px" id="AwvEchoLeftAtrialEnlargementTextbox" />cm 
            </span>
            <span style="float: left;">
                <input type="checkbox" id="AwvEchoRightAtrialEnlargementCheckbox" />Right
                    <input type="text" style="width: 40px" id="AwvEchoRightAtrialEnlargementTextbox" />cm 
            </span>
        </div>
        <div style="clear: both">
        </div>
        <div>
            <span style="float: left;">
                <input type="checkbox" id="AwvEchoAsdCheckbox" />ASD 
            </span>
            <span style="float: left;">
                <input type="checkbox" id="AwvEchoPfoCheckbox" />PFO 
            </span>
            <span style="float: left;">
                <input type="checkbox" id="AwvEchoFlailCheckbox" />Aneurysmal AS
            </span>
            <span style="float: left;">
                <input type="checkbox" id="AwvEchoVsdCheckbox" />VSD
            </span>
        </div>
    </div>
    <div style="float: left; width: 360px;" class="exclude-hide-evaluation physician-section clear-all-AwvEcho-selection">
        <div style="float: left;">
            <span style="float: left;" class="conclusion-section">
                <input type="checkbox" id="AwvEchoMitralAnnularCheckbox" />Mitral annular Ca++
                <label style="display: none">Mitral annular Ca++</label>
            </span>
        </div>
        <div style="clear: both">
        </div>
        <div style="float: left;">
            <span style="float: left;">
                <input type="checkbox" id="AwvEchoRestrictedLeafletCheckbox" />Restricted Leaflet Motion
            </span>
            <span style="float: left;">
                <input type="checkbox" id="AwvEchoRestrictedLeafletAorticCheckbox" />Aortic
            </span>
            <span style="float: left;">
                <input type="checkbox" id="AwvEchoRestrictedLeafletMitralCheckbox" />Mitral
            </span>
            <span style="float: left;">
                <input type="checkbox" id="AwvEchoRestrictedLeafletPulCheckbox" />Pul
            </span>
            <span style="float: left;">
                <input type="checkbox" id="AwvEchoRestrictedLeafletTriCheckbox" />Tri
            </span>
        </div>
        <div style="clear: both">
        </div>
        <div style="float: left; margin-top: 20px;">
            <div>
                <strong>Wall Motion Abnormality </strong>
            </div>
            <div>
                <span style="float: left">
                    <input type="checkbox" id="AwvEchoHypokineticCheckbox" />
                    Hypokinetic </span><span style="float: left">
                        <input type="checkbox" id="AwvEchoAkineticCheckbox" />
                        Akinetic </span><span style="float: left">
                            <input type="checkbox" id="AwvEchoDyskineticCheckbox" />
                            Dyskinetic </span>
            </div>
            <div style="clear: both">
            </div>
            <div>
                <span style="float: left">
                    <input type="checkbox" id="AwvEchoAnteriorCheckbox" />
                    Anterior </span><span style="float: left">
                        <input type="checkbox" id="AwvEchoPosteriorCheckbox" />
                        Posterior </span><span style="float: left">
                            <input type="checkbox" id="AwvEchoApicalCheckbox" />
                            Apical </span>
            </div>
            <div style="clear: both">
            </div>
            <div>
                <span style="float: left">
                    <input type="checkbox" id="AwvEchoSeptalCheckbox" />
                    Septal </span><span style="float: left">
                        <input type="checkbox" id="AwvEchoLateralCheckbox" />
                        Lateral </span><span style="float: left">
                            <input type="checkbox" id="AwvEchoInferiorCheckbox" />
                            Inferior </span>
            </div>
        </div>
    </div>
</div>

<div style="clear: both; margin-bottom: 5px; width: 100%;" class="exclude-hide-evaluation physician-section clear-all-AwvEcho-selection conclusion-section">
    <fieldset>
        <legend>Left Ventricle</legend>

        <div style="clear: both; float: left;">
            <div style="clear: both"><strong>Overall Function:</strong></div>
            <div class="column">
                <input type="checkbox" id="LeftVentricleOverallFunctionNotEvaluated" />
                Not Evaluated
                <label style="display: none;">Left Ventricle - Overall Function - Not Evaluated</label>
            </div>
            <div class="column">
                <input type="checkbox" id="LeftVentricleOverallFunctionNormal" />
                Normal
                <label style="display: none;">Left Ventricle - Overall Function - Normal</label>
            </div>
            <div class="column">
                <input type="checkbox" id="LeftVentricleOverallFunctionReduced" />
                Reduced
                <label style="display: none;">Left Ventricle - Overall Function - Reduced</label>
            </div>
            <div class="column">
                <input type="checkbox" id="LeftVentricleOverallFunctionBorderline" />
                Borderline
                <label style="display: none;">Left Ventricle - Overall Function - Borderline</label>
            </div>
            <div class="column">
                <input type="checkbox" id="LeftVentricleOverallFunctionHyperkinesis" />
                Hyperkinesis
                <label style="display: none;">Left Ventricle - Overall Function - Hyperkinesis</label>
            </div>
            <div class="column">
                <input type="checkbox" id="LeftVentricleOverallFunctionHypokinesis" />
                Hypokinesis
                <label style="display: none;">Left Ventricle - Overall Function - Hypokinesis</label>
            </div>
            <div class="column">
                <input type="checkbox" id="LeftVentricleOverallFunctionConsistentLvSystolicFailure" />
                Consistent with LV Systolic Failure
                <label style="display: none;">Left Ventricle - Overall Function - Consistent with LV Systolic Failure</label>
            </div>
        </div>
        <div style="clear: both; float: left;">
            <div style="clear: both"><strong>Dimensions:</strong></div>
            <div class="column">
                <input type="checkbox" id="LeftVentricleDimensionsNotEvaluated" />
                Not evaluated
                <label style="display: none;">Left Ventricle - Dimensions - Not evaluated</label>
            </div>
            <div class="column">
                <input type="checkbox" id="LeftVentricleDimensionsNormal" />
                Normal 
                <label style="display: none;">Left Ventricle - Dimensions - Normal</label>
            </div>
            <div class="column">
                <input type="checkbox" id="LeftVentricleDimensionsSmall" />
                Small
                <label style="display: none;">Left Ventricle - Dimensions - Small</label>
            </div>
            <div class="column">
                <input type="checkbox" id="LeftVentricleDimensionsDilated" />
                Dilated
                <label style="display: none;">Left Ventricle - Dimensions - Dilated</label>
            </div>
            <div class="column">
                <input type="checkbox" id="LeftVentricleDimensionsSlightlyEnlarged" />
                Slightly Enlarged
                <label style="display: none;">Left Ventricle - Dimensions - Slightly Enlarged</label>
            </div>
            <div class="column">
                <input type="checkbox" id="LeftVentricleDimensionsSeverelyDilated" />
                Severely Dilated
                <label style="display: none;">Left Ventricle - Dimensions - Severely Dilated</label>
            </div>
        </div>
        <div style="clear: both; float: left;">
            <div style="clear: both"><strong>Thicknesses:</strong></div>
            <div class="column">
                <input type="checkbox" id="LeftVentricleThicknessesNotEvaluated" />
                Not Evaluated
                <label style="display: none;">Left Ventricle - Thicknesses - Not Evaluated</label>
            </div>
            <div class="column">
                <input type="checkbox" id="LeftVentricleThicknessesNormal" />
                Normal
                <label style="display: none;">Left Ventricle - Thicknesses - Normal</label>
            </div>
            <div class="column">
                <input type="checkbox" id="LeftVentricleThicknessesApicalHypertrophy" />
                Apical Hypertrophy
                <label style="display: none;">Left Ventricle - Thicknesses - Apical Hypertrophy</label>
            </div>
            <div class="column">
                <input type="checkbox" id="LeftVentricleThicknessesAsymmetricalHypertrophy" />
                Asymmetrical Hypertrophy
                <label style="display: none;">Left Ventricle - Thicknesses - Asymmetrical Hypertrophy</label>
            </div>
            <div class="column">
                <input type="checkbox" id="LeftVentricleThicknessesIVSeptumObstructiveHypertrophy" />
                IV Septum Obstructive Hypertrophy
                <label style="display: none;">Left Ventricle - Thicknesses - IV Septum Obstructive Hypertrophy</label>
            </div>
            <div class="column">
                <input type="checkbox" id="LeftVentricleThicknessesMinorModerateIVSeptumHypertrophy" />
                Mild-Moderate IV Septum Hypertrophy
            <label style="display: none;">Left Ventricle - Thicknesses - Mild-Moderate IV Septum Hypertrophy</label>
            </div>
            <div class="column">
                <input type="checkbox" id="LeftVentricleThicknessesSevereIVSeptumHypertrophy" />
                Severe IV Septum Hypertrophy
            <label style="display: none;">Left Ventricle - Thicknesses - Severe IV Septum Hypertrophy</label>
            </div>
            <div class="column">
                <input type="checkbox" id="LeftVentricleThicknessesMinorModerateSymmetricHypertrophy" />
                Mild-Moderate Symmetric Hypertrophy
                <label style="display: none;">Left Ventricle - Thicknesses - Mild-Moderate Symmetric Hypertrophy</label>
            </div>
            <div class="column">
                <input type="checkbox" id="LeftVentricleThicknessesSevereSymmetricHypertrophy" />
                Severe Symmetric Hypertrophy
                <label style="display: none;">Left Ventricle - Thicknesses - Severe Symmetric Hypertrophy</label>
            </div>
        </div>
        <div class="left_info1 margin-top-small" style="width: 48%;">
            <b>Comment: </b>
            <br />
            <textarea id="LeftVentricleComment" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
                rows="2" cols="54"></textarea>
        </div>
    </fieldset>
</div>

<div style="clear: both; margin-bottom: 5px; width: 100%;" class="exclude-hide-evaluation physician-section clear-all-AwvEcho-selection conclusion-section">
    <fieldset>
        <legend>Left Atrium + IAS</legend>
        <div class="left_info1" style="width: 48%;">
            <div style="clear: both"><strong>LA Dimensions:</strong></div>
            <div class="threecolumn">
                <div class="first-column">
                    <input type="checkbox" id="LeftAtriumIASLADimensionsNotEvaluated" />
                    Not Evaluated
                <label style="display: none;">Left Atrium + IAS - LA Dimensions - Not Evaluated</label>
                </div>
                <div class="second-column">
                    <input type="checkbox" id="LeftAtriumIASLADimensionsNormal" />
                    Normal
                <label style="display: none;">Left Atrium + IAS - LA Dimensions - Normal</label>
                </div>
                <div class="third-column">
                    <input type="checkbox" id="LeftAtriumIASLADimensionsMildlyDilated" />
                    Mildly Dilated
                <label style="display: none;">Left Atrium + IAS - LA Dimensions - Mildly Dilated</label>
                </div>
            </div>
            <div class="threecolumn">
                <div class="first-column">
                    <input type="checkbox" id="LeftAtriumIASLADimensionsModeratelyDilated" />
                    Moderately Dilated
                <label style="display: none;">Left Atrium + IAS - LA Dimensions - Moderately Dilated</label>
                </div>
                <div class="second-column">
                    <input type="checkbox" id="LeftAtriumIASLADimensionsSeverelyDilated" />
                    Severely Dilated
                <label style="display: none;">Left Atrium + IAS - LA Dimensions - Severely Dilated</label>
                </div>
            </div>
        </div>
        <div class="margin-top-small rgt_info1" style="width: 48%;">
            <b>Comment: </b>
            <br />
            <textarea id="LeftAtriumIASComment" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
                rows="2" cols="54"></textarea>
        </div>
    </fieldset>
</div>

<div style="clear: both; margin-bottom: 5px; width: 100%;" class="exclude-hide-evaluation physician-section clear-all-AwvEcho-selection conclusion-section">
    <fieldset>
        <legend>Right Ventricle</legend>
        <div style="clear: both; float: left;">
            <div style="clear: both"><strong>Overall Function:</strong></div>
            <div class="column">
                <input type="checkbox" id="RightVentricleOverallFunctionNotEvaluated" />
                Not Evaluated
                <label style="display: none;">Right Ventricle - Overall Function - Not Evaluated</label>
            </div>
            <div class="column">
                <input type="checkbox" id="RightVentricleOverallFunctionNormal" />
                Normal
                <label style="display: none;">Right Ventricle - Overall Function - Normal</label>
            </div>
            <div class="column">
                <input type="checkbox" id="RightVentricleOverallFunctionReduced" />
                Reduced
                <label style="display: none;">Right Ventricle - Overall Function - Reduced</label>
            </div>
            <div class="column">
                <input type="checkbox" id="RightVentricleOverallFunctionBorderline" />
                Borderline
                <label style="display: none;">Right Ventricle - Overall Function - Borderline</label>
            </div>
            <div class="column">
                <input type="checkbox" id="RightVentricleOverallFunctionHyperkinesis" />
                Hyperkinesis
                <label style="display: none;">Right Ventricle - Overall Function - Hyperkinesis</label>
            </div>
            <div class="column">
                <input type="checkbox" id="RightVentricleOverallFunctionHypokinesis" />
                Hypokinesis
                <label style="display: none;">Right Ventricle - Overall Function - Hypokinesis</label>
            </div>
        </div>
        <div style="clear: both; float: left;">
            <div style="clear: both"><strong>Dimensions:</strong></div>
            <div class="column">
                <input type="checkbox" id="RightVentricleDimensionsNotEvaluated" />
                Not evaluated
                <label style="display: none;">Right Ventricle - Dimensions - Not evaluated</label>
            </div>
            <div class="column">
                <input type="checkbox" id="RightVentricleDimensionsNormal" />
                Normal 
                <label style="display: none;">Right Ventricle - Dimensions - Normal</label>
            </div>
            <div class="column">
                <input type="checkbox" id="RightVentricleDimensionsSmall" />
                Small
                <label style="display: none;">Right Ventricle - Dimensions - Small</label>
            </div>
            <div class="column">
                <input type="checkbox" id="RightVentricleDimensionsDilated" />
                Dilated
                <label style="display: none;">Right Ventricle - Dimensions - Dilated</label>
            </div>
            <div class="column">
                <input type="checkbox" id="RightVentricleDimensionsSlightlyEnlarged" />
                Slightly Enlarged
                <label style="display: none;">Right Ventricle - Dimensions - Slightly Enlarged</label>
            </div>
            <div class="column">
                <input type="checkbox" id="RightVentricleDimensionsSeverelyDilated" />
                Severely Dilated
                <label style="display: none;">Right Ventricle - Dimensions - Severely Dilated</label>
            </div>
        </div>
        <div style="clear: both; float: left;">
            <div style="clear: both"><strong>Thicknesses:</strong></div>
            <div class="column">
                <input type="checkbox" id="RightVentricleThicknessesNotEvaluated" />
                Not Evaluated
                <label style="display: none;">Right Ventricle - Thicknesses - Not Evaluated</label>
            </div>
            <div class="column">
                <input type="checkbox" id="RightVentricleThicknessesNormal" />
                Normal
                <label style="display: none;">Right Ventricle - Thicknesses - Normal</label>
            </div>
            <div class="column">
                <input type="checkbox" id="RightVentricleThicknessesApicalHypertrophy" />
                Apical Hypertrophy
                <label style="display: none;">Right Ventricle - Thicknesses - Apical Hypertrophy</label>
            </div>
            <div class="column">
                <input type="checkbox" id="RightVentricleThicknessesAsymmetricalHypertrophy" />
                Asymmetrical Hypertrophy
                <label style="display: none;">Right Ventricle - Thicknesses - Asymmetrical Hypertrophy</label>
            </div>
            <div class="column">
                <input type="checkbox" id="RightVentricleThicknessesIVSeptumObstructiveHypertrophy" />
                IV Septum Obstructive Hypertrophy
                <label style="display: none;">Right Ventricle - Thicknesses - IV Septum Obstructive Hypertrophy</label>
            </div>
            <div class="column">
                <input type="checkbox" id="RightVentricleThicknessesMinorModerateIVSeptumHypertrophy" />
                Mild-Moderate IV Septum Hypertrophy
                <label style="display: none;">Right Ventricle - Thicknesses - Mild-Moderate IV Septum Hypertrophy</label>
            </div>
            <div class="column">
                <input type="checkbox" id="RightVentricleThicknessesSevereIVSeptumHypertrophy" />
                Severe IV Septum Hypertrophy
                <label style="display: none;">Right Ventricle - Thicknesses - Severe IV Septum Hypertrophy</label>
            </div>
            <div class="column">
                <input type="checkbox" id="RightVentricleThicknessesMinorModerateSymmetricHypertrophy" />
                Mild-Moderate Symmetric Hypertrophy
                <label style="display: none;">Right Ventricle - Thicknesses - Mild-Moderate Symmetric Hypertrophy</label>
            </div>
            <div class="column">
                <input type="checkbox" id="RightVentricleThicknessesSevereSymmetricHypertrophy" />
                Severe Symmetric Hypertrophy
                <label style="display: none;">Right Ventricle - Thicknesses - Severe Symmetric Hypertrophy</label>
            </div>
        </div>
        <div class="left_info1 margin-top-small" style="width: 48%;">
            <b>Comment: </b>
            <br />
            <textarea id="RightVentricleComment" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
                rows="2" cols="54"></textarea>
        </div>
    </fieldset>
</div>

<div style="clear: both; margin-bottom: 5px; width: 100%;" class="exclude-hide-evaluation physician-section clear-all-AwvEcho-selection conclusion-section">
    <fieldset>
        <legend>Right Atrium</legend>
        <div class="left_info1" style="width: 48%;">
            <div style="clear: both"><strong>RA Dimensions:</strong></div>
            <div class="threecolumn">
                <div class="first-column">
                    <input type="checkbox" id="RightAtriumRADimensionsNotEvaluated" />
                    Not Evaluated
                <label style="display: none;">Right Atrium - RA Dimensions - Not Evaluated</label>
                </div>
                <div class="second-column">
                    <input type="checkbox" id="RightAtriumRADimensionsNormal" />
                    Normal
                <label style="display: none;">Right Atrium - RA Dimensions - Normal</label>
                </div>
                <div class="third-column">
                    <input type="checkbox" id="RightAtriumRADimensionsMildlyDilated" />
                    Mildly Dilated
                <label style="display: none;">Right Atrium - RA Dimensions - Mildly Dilated</label>
                </div>
            </div>
            <div class="threecolumn">
                <div class="first-column">
                    <input type="checkbox" id="RightAtriumRADimensionsModeratelyDilated" />
                    Moderately Dilated
                <label style="display: none;">Right Atrium - RA Dimensions - Moderately Dilated</label>
                </div>
                <div class="second-column">
                    <input type="checkbox" id="RightAtriumRADimensionsSeverelyDilated" />
                    Severely Dilated
                <label style="display: none;">Right Atrium - RA Dimensions - Severely Dilated</label>
                </div>
            </div>
        </div>
        <div class="rgt_info1 margin-top-small" style="width: 48%;">
            <b>Comment: </b>
            <br />
            <textarea id="RightAtriumComment" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
                rows="2" cols="54"></textarea>
        </div>
    </fieldset>
</div>

<div style="clear: both; margin-bottom: 5px; width: 100%;" class="exclude-hide-evaluation physician-section clear-all-AwvEcho-selection conclusion-section">
    <fieldset>
        <legend>Aorta</legend>
        <div style="clear: both; float: left;">
            <div style="clear: both"><strong>Insufficiency:</strong></div>
            <div class="column">
                <input type="checkbox" id="AortaInsufficiencyAbsent" />
                Absent
                <label style="display: none;">Aorta - Insufficiency - Absent</label>
            </div>
            <div class="column">
                <input type="checkbox" id="AortaInsufficiencyMinor" />
                Mild 
                <label style="display: none;">Aorta - Insufficiency - Mild</label>
            </div>
            <div class="column">
                <input type="checkbox" id="AortaInsufficiencyModerate" />
                Moderate
                <label style="display: none;">Aorta - Insufficiency - Moderate</label>
            </div>
            <div class="column">
                <input type="checkbox" id="AortaInsufficiencySevere" />
                Severe
                <label style="display: none;">Aorta - Insufficiency - Severe</label>
            </div>
        </div>
        <div style="float: left; clear: both;">
            <div style="clear: both;"><strong>Leaflets:</strong></div>
            <div class="column">
                <input type="checkbox" id="AortaLeafletsNotEvaluated" />
                Not Evaluated
                <label style="display: none;">Aorta - Leaflets - Not Evaluated</label>
            </div>
            <div class="column">
                <input type="checkbox" id="AortaLeafletsNormal" />
                Normal 
                <label style="display: none;">Aorta - Leaflets - Normal</label>
            </div>
            <div class="column">
                <input type="checkbox" id="AortaLeafletsMildStenosis" />
                Mild Stenosis
                <label style="display: none;">Aorta - Leaflets - Mild Stenosis</label>
            </div>
            <div class="column">
                <input type="checkbox" id="AortaLeafletsModerateStenosis" />
                Moderate Stenosis
                <label style="display: none;">Aorta - Leaflets - Moderate Stenosis</label>
            </div>
            <div class="column">
                <input type="checkbox" id="AortaLeafletsSevereStenosis" />
                Severe Stenosis
                <label style="display: none;">Aorta - Leaflets - Severe Stenosis</label>
            </div>
        </div>
        <div style="clear: both; float: left;">
            <div style="clear: both"><strong>Valve:</strong></div>
            <div class="column">
                <input type="checkbox" id="AortaValveNotEvaluated" />
                Not Evaluated
                <label style="display: none;">Aorta - Valve - Not Evaluated</label>
            </div>
            <div class="column">
                <input type="checkbox" id="AortaValveBicuspid" />
                Bicuspid
                <label style="display: none;">Aorta - Valve - Bicuspid</label>
            </div>
            <div class="column">
                <input type="checkbox" id="AortaValveAtherosclerotic" />
                Atherosclerotic
                <label style="display: none;">Aorta - Valve - Atherosclerotic</label>
            </div>
            <div class="column">
                <input type="checkbox" id="AortaValveNormalFunctioningBiologicalProsthesis" />
                Normal Functioning Biological Prosthesis
                <label style="display: none;">Aorta - Valve - Normal Functioning Biological Prosthesis</label>
            </div>
            <div class="column">
                <input type="checkbox" id="AortaValveNormalFunctioningMechanicalProsthesis" />
                Normal Functioning Mechanical Prosthesis
                <label style="display: none;">Aorta - Valve - Normal Functioning Mechanical Prosthesis</label>
            </div>
            <div class="column">
                <input type="checkbox" id="AortaValveMalfunctioningBiologicalProsthesis" />
                Malfunctioning Biological Prosthesis
                <label style="display: none;">Aorta - Valve - Malfunctioning Biological Prosthesis</label>
            </div>
            <div class="column">
                <input type="checkbox" id="AortaValveMalfunctioningMechanicalProsthesis" />
                Malfunctioning Mechanical Prosthesis
                <label style="display: none;">Aorta - Valve - Malfunctioning Mechanical Prosthesis</label>
            </div>
            <div class="column">
                <input type="checkbox" id="AortaValveDilatedAorticRoot" />
                Dilated Aortic Root
                <label style="display: none;">Aorta - Valve - Dilated Aortic Root</label>
            </div>
            <div class="column">
                <input type="checkbox" id="AortaValveSinusValsalvaAneurysm" />
                Sinus of Valsalva Aneurysm
                <label style="display: none;">Aorta - Valve - Sinus of Valsalva Aneurysm</label>
            </div>
        </div>
        <div class="left_info1 margin-top-small" style="width: 48%;">
            <b>Comment: </b>
            <br />
            <textarea id="AortaComment" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
                rows="2" cols="54"></textarea>
        </div>
    </fieldset>
</div>

<div style="clear: both; margin-bottom: 5px; width: 100%;" class="exclude-hide-evaluation physician-section clear-all-AwvEcho-selection conclusion-section">
    <fieldset>
        <legend>Mitral</legend>
        <div style="float: left; clear: both;">
            <div style="clear: both"><strong>Insufficiency</strong></div>
            <div class="column">
                <input type="checkbox" id="MitralInsufficiencyAbsent" />
                Absent
                <label style="display: none;">Mitral - Insufficiency - Absent</label>
            </div>
            <div class="column">
                <input type="checkbox" id="MitralInsufficiencyMinor" />
                Mild
                <label style="display: none;">Mitral - Insufficiency - Mild</label>
            </div>
            <div class="column">
                <input type="checkbox" id="MitralInsufficiencyModerate" />
                Moderate
                <label style="display: none;">Mitral - Insufficiency - Moderate</label>
            </div>
            <div class="column">
                <input type="checkbox" id="MitralInsufficiencySevere" />
                Severe
                <label style="display: none;">Mitral - Insufficiency - Severe</label>
            </div>
        </div>
        <div style="float: left; clear: both;">
            <div style="clear: both;"><strong>Leaflets:</strong></div>
            <div class="column">
                <input type="checkbox" id="MitralLeafletsNotEvaluated" />
                Not Evaluated
                <label style="display: none;">Mitral - Leaflets - Not Evaluated</label>
            </div>
            <div class="column">
                <input type="checkbox" id="MitralLeafletsNormal" />
                Normal 
                <label style="display: none;">Mitral - Leaflets - Normal</label>
            </div>
            <div class="column">
                <input type="checkbox" id="MitralLeafletsRedundant" />
                Redundant
                <label style="display: none;">Mitral - Leaflets - Redundant</label>
            </div>
            <div class="column">
                <input type="checkbox" id="MitralLeafletsMildStenosis" />
                Mild Stenosis
                <label style="display: none;">Mitral - Leaflets - Mild Stenosis</label>
            </div>
            <div class="column">
                <input type="checkbox" id="MitralLeafletsModerateStenosis" />
                Moderate Stenosis
                <label style="display: none;">Mitral - Leaflets - Moderate Stenosis</label>
            </div>
            <div class="column">
                <input type="checkbox" id="MitralLeafletsSevereStenosis" />
                Severe Stenosis
                <label style="display: none;">Mitral - Leaflets - Severe Stenosis</label>
            </div>
        </div>
        <div style="float: left; clear: both;">
            <div style="clear: both"><strong>Valve:</strong></div>
            <div class="column">
                <input type="checkbox" id="MitralValveNotEvaluated" />
                Not Evaluated
                <label style="display: none;">Mitral - Valve - Not Evaluated</label>
            </div>
            <div class="column">
                <input type="checkbox" id="MitralValveBicuspid" />
                Bicuspid
                <label style="display: none;">Mitral - Valve - Bicuspid</label>
            </div>
            <div class="column">
                <input type="checkbox" id="MitralValveAtherosclerotic" />
                Atherosclerotic
                <label style="display: none;">Mitral - Valve - Atherosclerotic</label>
            </div>
            <div class="column">
                <input type="checkbox" id="MitralValveNormalFunctioningBiologicalProsthesis" />
                Normal Functioning Biological Prosthesis
                <label style="display: none;">Mitral - Valve - Normal Functioning Biological Prosthesis</label>
            </div>
            <div class="column">
                <input type="checkbox" id="MitralValveNormalFunctioningMechanicalProsthesis" />
                Normal Functioning Mechanical Prosthesis
                <label style="display: none;">Mitral - Valve - Normal Functioning Mechanical Prosthesis</label>
            </div>
            <div class="column">
                <input type="checkbox" id="MitralValveMalfunctioningBiologicalProsthesis" />
                Malfunctioning Biological Prosthesis
                <label style="display: none;">Mitral - Valve - Malfunctioning Biological Prosthesis</label>
            </div>
            <div class="column">
                <input type="checkbox" id="MitralValveMalfunctioningMechanicalProsthesis" />
                Malfunctioning Mechanical Prosthesis
                <label style="display: none;">Mitral - Valve - Malfunctioning Mechanical Prosthesis</label>
            </div>
        </div>
        <div class="left_info1 margin-top-small" style="width: 48%;">
            <b>Comment: </b>
            <br />
            <textarea id="MitralValveComment" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
                rows="2" cols="54"></textarea>
        </div>
    </fieldset>
</div>

<div style="clear: both; margin-bottom: 5px; width: 100%;" class="exclude-hide-evaluation physician-section clear-all-AwvEcho-selection conclusion-section">
    <fieldset>
        <legend>Pulmonary</legend>
        <div style="clear: both; float: left;">
            <div style="clear: both;"><strong>Insufficiency:</strong></div>
            <div class="column">
                <input type="checkbox" id="PulmonaryInsufficiencyAbsent" />Absent
                <label style="display: none;">Pulmonary - Insufficiency - Absent</label>
            </div>
            <div class="column">
                <input type="checkbox" id="PulmonaryInsufficiencyMinor" />Mild
                <label style="display: none;">Pulmonary - Insufficiency - Mild</label>
            </div>
            <div class="column">
                <input type="checkbox" id="PulmonaryInsufficiencyModerate" />Moderate
                <label style="display: none;">Pulmonary - Insufficiency - Moderate</label>
            </div>
            <div class="column">
                <input type="checkbox" id="PulmonaryInsufficiencySevere" />Severe
                <label style="display: none;">Pulmonary - Insufficiency - Severe</label>
            </div>
        </div>
        <div style="clear: both; float: left;">
            <div style="clear: both;"><strong>Leaflets:</strong></div>
            <div class="column">
                <input type="checkbox" id="PulmonaryLeafletsNormal" />Normal
                <label style="display: none;">Pulmonary - Leaflets - Normal</label>
            </div>
            <div class="column">
                <input type="checkbox" id="PulmonaryLeafletsThickened" />Thickened
                <label style="display: none;">Pulmonary - Leaflets - Thickened</label>
            </div>
            <div class="column" style="display: none;">
                <input type="checkbox" id="PulmonaryLeafletsStenotic" />Stenotic
                <label style="display: none;">Pulmonary - Leaflets - Stenotic</label>
            </div>
            <div class="column">
                <input type="checkbox" id="PulmonaryLeafletsMildStenosis" />
                Mild Stenosis
                <label style="display: none;">Pulmonary - Leaflets - Mild Stenosis</label>
            </div>
            <div class="column">
                <input type="checkbox" id="PulmonaryLeafletsModerateStenosis" />
                Moderate Stenosis
                <label style="display: none;">Pulmonary - Leaflets - Moderate Stenosis</label>
            </div>
            <div class="column">
                <input type="checkbox" id="PulmonaryLeafletsSevereStenosis" />
                Severe Stenosis
                <label style="display: none;">Pulmonary - Leaflets - Severe Stenosis</label>
            </div>
        </div>
        <div style="float: left; clear: both;">
            <div style="clear: both"><strong>Valve:</strong></div>
            <div class="column">
                <input type="checkbox" id="PulmonaryValveNotEvaluated" />
                Not Evaluated
                <label style="display: none;">Pulmonary - Valve - Not Evaluated</label>
            </div>
            <div class="column">
                <input type="checkbox" id="PulmonaryValveBicuspid" />
                Bicuspid
                <label style="display: none;">Pulmonary - Valve - Bicuspid</label>
            </div>
            <div class="column">
                <input type="checkbox" id="PulmonaryValveAtherosclerotic" />
                Atherosclerotic
                <label style="display: none;">Pulmonary - Valve - Atherosclerotic</label>
            </div>
            <div class="column">
                <input type="checkbox" id="PulmonaryValveNormalFunctioningBiologicalProsthesis" />
                Normal Functioning Biological Prosthesis
                <label style="display: none;">Pulmonary - Valve - Normal Functioning Biological Prosthesis</label>
            </div>
            <div class="column">
                <input type="checkbox" id="PulmonaryValveNormalFunctioningMechanicalProsthesis" />
                Normal Functioning Mechanical Prosthesis
                <label style="display: none;">Pulmonary - Valve - Normal Functioning Mechanical Prosthesis</label>
            </div>
            <div class="column">
                <input type="checkbox" id="PulmonaryValveMalfunctioningBiologicalProsthesis" />
                Malfunctioning Biological Prosthesis
                <label style="display: none;">Pulmonary - Valve - Malfunctioning Biological Prosthesis</label>
            </div>
            <div class="column">
                <input type="checkbox" id="PulmonaryValveMalfunctioningMechanicalProsthesis" />
                Malfunctioning Mechanical Prosthesis
                <label style="display: none;">Pulmonary - Valve - Malfunctioning Mechanical Prosthesis</label>
            </div>
        </div>
        <div class="left_info1 margin-top-small" style="width: 48%;">
            <b>Comment: </b>
            <br />
            <textarea id="PulmonaryComment" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
                rows="2" cols="54"></textarea>
        </div>
    </fieldset>
</div>

<div style="clear: both; margin-bottom: 5px; width: 100%;" class="exclude-hide-evaluation physician-section clear-all-AwvEcho-selection conclusion-section">
    <fieldset>
        <legend>Tricuspid</legend>
        <div style="clear: both; float: left;">
            <div style="clear: both;"><strong>Insufficiency:</strong></div>
            <div class="column">
                <input type="checkbox" id="TricuspidInsufficiencyAbsent" />Absent
                <label style="display: none;">Tricuspid - Insufficiency - Absent</label>
            </div>
            <div class="column">
                <input type="checkbox" id="TricuspidInsufficiencyMinor" />Mild
                <label style="display: none;">Tricuspid - Insufficiency - Mild</label>
            </div>
            <div class="column">
                <input type="checkbox" id="TricuspidInsufficiencyModerate" />Moderate
                <label style="display: none;">Tricuspid - Insufficiency - Moderate</label>
            </div>
            <div class="column">
                <input type="checkbox" id="TricuspidInsufficiencySevere" />Severe
                <label style="display: none;">Tricuspid - Insufficiency - Severe</label>
            </div>
        </div>
        <div style="clear: both; float: left;">
            <div style="clear: both;"><strong>Leaflets:</strong></div>
            <div class="column">
                <input type="checkbox" id="TricuspidLeafletsNormal" />Normal
                <label style="display: none;">Tricuspid - Leaflets - Normal</label>
            </div>
            <div class="column">
                <input type="checkbox" id="TricuspidLeafletsThickened" />Thickened
                <label style="display: none;">Tricuspid - Leaflets - Thickened</label>
            </div>
            <div class="column" style="display: none;">
                <input type="checkbox" id="TricuspidLeafletsRedundant" />Redundant
                <label style="display: none;">Tricuspid - Leaflets - Redundant</label>
            </div>
            <div class="column">
                <input type="checkbox" id="TricuspidLeafletsMildStenosis" />
                Mild Stenosis
                <label style="display: none;">Tricuspid - Leaflets - Mild Stenosis</label>
            </div>
            <div class="column">
                <input type="checkbox" id="TricuspidLeafletsModerateStenosis" />
                Moderate Stenosis
                <label style="display: none;">Tricuspid - Leaflets - Moderate Stenosis</label>
            </div>
            <div class="column">
                <input type="checkbox" id="TricuspidLeafletsSevereStenosis" />
                Severe Stenosis
                <label style="display: none;">Tricuspid - Leaflets - Severe Stenosis</label>
            </div>
        </div>
        <div style="float: left; clear: both;">
            <div style="clear: both"><strong>Valve:</strong></div>
            <div class="column">
                <input type="checkbox" id="TricuspidValveNotEvaluated" />
                Not Evaluated
                <label style="display: none;">Tricuspid - Valve - Not Evaluated</label>
            </div>
            <div class="column">
                <input type="checkbox" id="TricuspidValveBicuspid" />
                Bicuspid
                <label style="display: none;">Tricuspid - Valve - Bicuspid</label>
            </div>
            <div class="column">
                <input type="checkbox" id="TricuspidValveAtherosclerotic" />
                Atherosclerotic
                <label style="display: none;">Tricuspid - Valve - Atherosclerotic</label>
            </div>
            <div class="column">
                <input type="checkbox" id="TricuspidValveNormalFunctioningBiologicalProsthesis" />
                Normal Functioning Biological Prosthesis
                <label style="display: none;">Tricuspid - Valve - Normal Functioning Biological Prosthesis</label>
            </div>
            <div class="column">
                <input type="checkbox" id="TricuspidValveNormalFunctioningMechanicalProsthesis" />
                Normal Functional Mechanical Prosthesis
                <label style="display: none;">Tricuspid - Valve - Normal Functioning Mechanical Prosthesis</label>
            </div>
            <div class="column">
                <input type="checkbox" id="TricuspidValveMalfunctioningBiologicalProsthesis" />
                Malfunctioning Biological Prosthesis
                <label style="display: none;">Tricuspid - Valve - Malfunctioning Biological Prosthesis</label>
            </div>
            <div class="column">
                <input type="checkbox" id="TricuspidValveMalfunctioningMechanicalProsthesis" />
                Malfunctioning Mechanical Prosthesis
                <label style="display: none;">Tricuspid - Valve - Malfunctioning Mechanical Prosthesis</label>
            </div>
        </div>
        <div class="left_info1 margin-top-small" style="width: 48%;">
            <b>Comment: </b>
            <br />
            <textarea id="TricuspidComment" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
                rows="2" cols="54"></textarea>
        </div>
    </fieldset>
</div>

<div class="left_info1" style="width: 45%;">
    <div class="left margin-top-small" id="unableScreenReasonDiv">
        <asp:DataList runat="server" ID="AwvEchoUnableScreenDatalist" EnableViewState="false"
            RepeatLayout="Flow" RepeatColumns="4" RepeatDirection="Horizontal" CssClass="AwvEcho-unabletoscreen-dtl unable-to-screen-section">
            <ItemTemplate>
                <input type="checkbox" class="finding-unablescreen-checkbox" />&nbsp;<b><%# DataBinder.Eval(Container.DataItem, "DisplayName")%></b>
                &nbsp;&nbsp;
                <input type="hidden" class="finding-unablescreen-id" value='<%# Convert.ToString((int)DataBinder.Eval(Container.DataItem, "Reason"))%>' />
            </ItemTemplate>
        </asp:DataList>
    </div>
    <div class="lrow physician-section clear-all-selection">
        <a style="margin-left: 5px;" id="clear-all-AweEcho" href="javascript:void(0);" onclick="clearAllAwvEchoSelection();">Clear All Selection</a>
    </div>
</div>
<div class="rgt margin-top-small" id="Div1" style="width: 48%;">
    <b>Technician Notes: </b>
    <br />
    <textarea id="technotesAwvEcho" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
        rows="2" cols="54"></textarea>
    <div class="rrow test-not-performed-section" id="testnotPerformedAwvEcho">
        <input type="checkbox" onclick="ShowTestNotPerformedSection(this)" style="margin-left: 0" />
        <b>Test Not Performed</b>
        <div class="test-not-performed-container" style="display: none">
            <b>Reason : </b>
            <br />
            <asp:DropDownList ID="ddlTestNotPerformedReasonAwvEcho" runat="server" CssClass="inputf_accm" Width="276px" AutoPostBack="False">
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
<div class="left uploadmedia-echo-div media-container-div" style="width: 937px; padding: 5px;"
    id="AwvEchoMediaDiv">
</div>
<div class="left upload-media-section">
    <a href="javascript:OpenPopUp('Upload Images', '710', '/app/franchisee/technician/uploadTestImages.aspx?TestType=<%= (int)TestType.AwvEcho %>&CustomerId=' + customerId);">Upload Media </a>
</div>
<div style="float: left; width: 100%; clear: both; margin-top: 5px;" class="physician-section">
    <fieldset style="float: left; width: 98%; border-radius: 4px;">
        <legend>Remarks </legend>
        <div style="float: left; width: 40%;">
            <input type="checkbox" id="AwvEchotechnicalltdreadableinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Technically Limited</b><br />
            <input type="checkbox" id="AwvEchorepeatstudyunreadableinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Repeat Study/Unreadable</b><br />
            <input type="checkbox" id="criticalAwvEcho" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b>
        </div>
        <div style="float: left; width: 58%;">
            <textarea id="physicianRemarksAwvEcho" rows="3" style="width: 98%;"></textarea>
        </div>
        <div style="float: left; width: 99%;">
            <b>Conclusion:</b><br />
            <textarea id="Conclusion" rows="5" style="width: 98%;" readonly="readonly"></textarea>
        </div>
    </fieldset>
</div>

    </div>
<div id="awvEcho_chat" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 50%;">
            <span class="org-heading" style="width: 100%;"><strong>Echocardiogram Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyAwvEcho" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="AwvEcho-critical-span">
        <input type="checkbox" id="DescribeSelfPresentAwvEchoInputCheck" onclick="onClick_CriticalDataAwvEcho();" />Critical
    </span>

        <span class="chk_orngband" id="awvEcho-retest-span">
            <input type="checkbox" id="Retest_54" />Retest
        </span>
    </div>
    <div class="hrows awvEcho-verificationpanel" style="color: Red; background: #fff0a5; border: solid 1px fff0a5; padding: 2px 2px 2px 5px; display: none;">
    </div>
     <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
             
     <div class="hlfbox">
           <div class="hrows">
             <div class="nrow" style="margin-left:12px;">
                  <input type="checkbox" id="chk_awvEchocapturebyChat" />
                   <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
     </div>
             
     </div>
</div>
<script language="javascript" type="text/javascript">
    var testTypeAwvEcho = '<%= (long)TestType.AwvEcho %>';
    var IsawvEchoResultEntryExternaly = '<%= IsResultEntrybyChat %>';
    var awvEcho = null;

    function SetAwvEchoData(testResult) {
        awvEcho = new AwvEcho(testResult);
        awvEcho.setData();
    }

    function GetAwvEchoData() {
        if (awvEcho == null) awvEcho = new AwvEcho();
        return awvEcho.getData();
    }

</script>
