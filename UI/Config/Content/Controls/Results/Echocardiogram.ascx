<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Echocardiogram.ascx.cs"
    Inherits="Falcon.App.UI.Config.Content.Controls.Results.Echocardiogram" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<script language="javascript" type="text/javascript" src="/Config/Content/JavaScript/Echocardiogram.js?q=<%= VersionNumber %>"></script>
<div id="echo_hip" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
<div class="orange-band test-section-header">
    <h5>
        <span class="org-heading"><strong>Echocardiogram Results</strong></span>
    </h5>
    <span class="chk_orngband">
        <select id="conductedbyecho" class="conductedby-ddl">
        </select>
    </span><span class="chk_orngband" id="echo-critical-span">
        <input type="checkbox" id="DescribeSelfPresentEchoInputCheck" onclick="onClick_CriticalDataEcho();" />Critical
    </span>
    <span class="chk_orngband" id="echo-priorityInQueue-span">
        <input type="checkbox" id="PriorityInQueueTestEchoCheck" onclick="onClick_PriorityInQueueDataEcho();" />Priority In Queue
    </span>
    <span class="chk_orngband" id="echo-retest-span">
        <input type="checkbox" id="Retest_4" />Retest
    </span>
</div>
<div class="exclude-hide-evaluation physician-section clear-all-echo-selection" style="float: left; clear: both; margin-bottom: 5px; width: 100%">
    <asp:DataList runat="server" ID="EchoFindingsDatalist" CssClass="echo-finding finding-section"
        ShowHeader="false" EnableViewState="false" GridLines="None" RepeatDirection="Horizontal">
        <ItemTemplate>
            <input type="radio" name="EchoFindingsRadioButton" class="rbt-finding" />
            <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id") %>' />
            <%# DataBinder.Eval(Container.DataItem, "Description").ToString().Length > 0 ? DataBinder.Eval(Container.DataItem, "Label")+ "(" + DataBinder.Eval(Container.DataItem, "Description") + ")":DataBinder.Eval(Container.DataItem, "Label") %>
        </ItemTemplate>
    </asp:DataList>
</div>
<div style="float: left; clear: both; margin-bottom: 5px; width: 100%">
    <div class="uppersection_echo exclude-hide-evaluation physician-section clear-all-echo-selection" style="width: 170px;">
        <div>
            <b>Estimated Ejection Fraction </b>
        </div>
        <div>
            <asp:DataList runat="server" ID="EjactionFractionFindingsDatalist" CssClass="ejaction-fraction-finding"
                GridLines="None" EnableViewState="false" RepeatDirection="Vertical">
                <ItemTemplate>
                    <input type="radio" name="finding-ejaction" class="rbt-finding" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                    &nbsp; <i>(<%# DataBinder.Eval(Container.DataItem, "Description") %>)</i>
                    <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
    <div class="uppersection_valve_echo exclude-hide-evaluation physician-section clear-all-echo-selection" style="width: 90px;">
        <div>
            <b>Valve </b>
        </div>
        <div>
            <input type="checkbox" id="ValveAorticCheckbox" />
            Aortic
        </div>
        <div>
            <input type="checkbox" id="ValveMitralCheckbox" />
            Mitral
        </div>
        <div>
            <input type="checkbox" id="ValvePulmonicCheckbox" />
            Pulmonic
        </div>
        <div>
            <input type="checkbox" id="ValveTricuspidCheckbox" />
            Tricuspid
        </div>
    </div>
    <div class="uppersection_echo exclude-hide-evaluation physician-section clear-all-echo-selection" style="width: 270px;">
        <div>
            <div>
                <b>Regurgitation</b>
                <a style="margin-left: 10px; display: none;" id="claer-all-regurgitation" href="javascript:void(0);" onclick="clearAllRegurgitationSelection();">Clear All Selection</a>
            </div>
        </div>
        <div>
            <asp:DataList runat="server" ID="RegurgitationforAorticDatalist" CssClass="aortic-regurgitation-finding"
                RepeatDirection="Horizontal" EnableViewState="false" RepeatColumns="4">
                <ItemTemplate>
                    <input type="radio" name="regurgitationaortic-button" class="rbt-finding" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                    <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div>
            <asp:DataList runat="server" ID="RegurgitationforMitralDatalist" CssClass="mitral-regurgitation-finding"
                RepeatDirection="Horizontal" RepeatColumns="4" EnableViewState="false">
                <ItemTemplate>
                    <input type="radio" name="regurgitationmitral-button" class="rbt-finding" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                    <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div>
            <asp:DataList runat="server" ID="RegurgitationforPulmonicDatalist" CssClass="pulmonic-regurgitation-finding"
                RepeatDirection="Horizontal" RepeatColumns="4" EnableViewState="false">
                <ItemTemplate>
                    <input type="radio" name="regurgitationpulmonic-button" class="rbt-finding" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                    <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div>
            <asp:DataList runat="server" ID="RegurgitationforTricuspidDatalist" CssClass="tricuspid-regurgitation-finding"
                RepeatDirection="Horizontal" RepeatColumns="4" EnableViewState="false">
                <ItemTemplate>
                    <input type="radio" name="regurgitationtricuspid-button" class="rbt-finding" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                    <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
    <div class="uppersection_echo exclude-hide-evaluation physician-section clear-all-echo-selection" style="width: 360px;">
        <div>
            <b>Morphology Characteristics </b>
        </div>
        <div>
            <div style="float: left">
                <asp:DataList runat="server" ID="MorphologyAorticDatalist" CssClass="aortic-morphology-finding"
                    RepeatDirection="Horizontal" RepeatColumns="4" EnableViewState="false">
                    <ItemTemplate>
                        <input type="checkbox" id="morphologyaorticcheckbox" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                        <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div style="float: left">
                &nbsp;&nbsp;Velocity
                <input type="text" style="width: 30px;" id="AorticVelocityTextbox" />
            </div>
        </div>
        <div>
            <div style="float: left">
                <asp:DataList runat="server" ID="MorphologyMitralDatalist" CssClass="mitral-morphology-finding"
                    RepeatDirection="Horizontal" RepeatColumns="4" EnableViewState="false">
                    <ItemTemplate>
                        <input type="checkbox" id="morphologymitralcheckbox" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                        <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div style="float: left">
                &nbsp;&nbsp;P1/2T
                <input type="text" style="width: 30px;" id="PTTextbox" />
            </div>
        </div>
        <div>
            <div style="float: left">
                <asp:DataList runat="server" ID="MorphologyPulmonicDatalist" CssClass="pulmonic-morphology-finding"
                    RepeatDirection="Horizontal" RepeatColumns="4" EnableViewState="false">
                    <ItemTemplate>
                        <input type="checkbox" id="morphologypulmoniccheckbox" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                        <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div style="float: left">
                &nbsp;&nbsp;Velocity
                <input type="text" id="VelocityPulmonicTextbox" style="width: 30px;" />
            </div>
            <div style="clear: both">
            </div>
        </div>
        <div>
            <div style="float: left">
                <asp:DataList runat="server" ID="MorphologyTricuspidDatalist" CssClass="tricuspid-morphology-finding"
                    RepeatDirection="Horizontal" RepeatColumns="4" EnableViewState="false">
                    <ItemTemplate>
                        <input type="checkbox" id="morphologytricuspidcheckbox" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                        <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div style="float: left">
                &nbsp;&nbsp;PAP
                <input type="text" id="PapTextbox" style="width: 30px;" />
                &nbsp;&nbsp;Velocity
                <input type="text" id="VelocityTricuspidTextbox" style="width: 30px;" />
            </div>
        </div>
    </div>
</div>
<div style="float: left; clear: both; margin-bottom: 5px; width: 100%">
    <div style="float: left; width: 185px;" class="exclude-hide-evaluation physician-section clear-all-echo-selection">
        <div class="margin-top-small">
            <input type="checkbox" id="DiastolicDysfunctionCheckbox" />
            Diastolic Dysfunction
        </div>
        <div class="margin-top-small">
            <input type="checkbox" id="PericardialEffusionCheckbox" />
            Pericardial Effusion
        </div>
        <div class="margin-top-small">
            <input type="checkbox" id="VentricularEnlargmentCheckbox" />
            Ventricular Enlargement
        </div>
        <div class="margin-top-small">
            <input type="checkbox" id="AorticRootCheckbox" />
            Aortic Root
        </div>
        <div class="margin-top-small">
            <input type="checkbox" id="VentricularHypertrophyCheckbox" />
            Ventricular Hypertrophy
        </div>
        <div class="margin-top-small">
            <input type="checkbox" id="AtrialEnlargmentCheckbox" />
            Atrial Enlargement
        </div>
        <div class="margin-top-small">
            <input type="checkbox" id="ArrythmiaCheckbox" />
            Arrhythmia
        </div>
    </div>
    <div style="float: left; width: 380px;" class="exclude-hide-evaluation physician-section clear-all-echo-selection">
        <div class="margin-top-small">
            <asp:DataList runat="server" ID="DiastolicDysfunctionFindingDatalist" RepeatDirection="Horizontal"
                CssClass="diastolic-dysfunction-finding" RepeatColumns="4" EnableViewState="false">
                <ItemTemplate>
                    <input type="checkbox" id="diastolicdysfunction" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                    <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div style="clear: both">
        </div>
        <div class="margin-top-small">
            <asp:DataList runat="server" ID="PericardialEffusionFindingDatalist" RepeatDirection="Horizontal"
                CssClass="pericardial-effusion-finding" RepeatColumns="4" EnableViewState="false">
                <ItemTemplate>
                    <input type="checkbox" id="pericardialeffusion" /><%# DataBinder.Eval(Container.DataItem, "Label") %>
                    <input type="hidden" class="finding-id" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div style="clear: both">
        </div>
        <div class="margin-top-small">
            <span style="float: left;">
                <input type="checkbox" id="LeftVEnlargementCheckbox" />
                Left
                <input type="text" style="width: 40px" id="LeftVEnlargementTextbox" />
                cm </span><span style="float: left;">
                    <input type="checkbox" id="RightVEnlargementCheckbox" />
                    Right
                    <input type="text" style="width: 40px" id="RightVEnlargementTextbox" />
                    cm </span>
        </div>
        <div style="clear: both">
        </div>
        <div class="margin-top-small">
            <span style="float: left;">
                <input type="checkbox" id="ScleroticCheckbox" />
                Sclerotic</span><span style="float: left;">
                    <input type="checkbox" id="CalcifiedCheckbox" />
                    Calcified</span><span style="float: left;">
                        <input type="checkbox" id="EnlargedCheckbox" />
                        Enlarged
                        <input type="text" style="width: 40px" id="EnlargedTextbox" />
                        cm </span>
        </div>
        <div style="clear: both">
        </div>
        <div>
            <span style="float: left;">
                <input type="checkbox" id="LeftVHypertrophyCheckbox" />
                Left
                <input type="text" style="width: 40px" id="LeftVHypertrophyTextbox" />
                cm </span><span style="float: left;">
                    <input type="checkbox" id="RightVHypertrophyCheckbox" />
                    Right
                    <input type="text" style="width: 40px" id="RightVHypertrophyTextbox" />
                    cm </span><span style="float: left;">
                        <input type="checkbox" id="IvshCheckbox" />
                        IVSH
                        <input type="text" style="width: 40px" id="IvshTextbox" />
                        cm </span>
        </div>
        <div style="clear: both">
        </div>
        <div>
            <span style="float: left;">
                <input type="checkbox" id="LeftAtrialEnlargementCheckbox" />
                Left
                <input type="text" style="width: 40px" id="LeftAtrialEnlargementTextbox" />
                cm </span><span style="float: left;">
                    <input type="checkbox" id="RightAtrialEnlargementCheckbox" />
                    Right
                    <input type="text" style="width: 40px" id="RightAtrialEnlargementTextbox" />
                    cm </span>
        </div>
        <div style="clear: both">
        </div>
        <div>
            <span style="float: left;">
                <input type="checkbox" id="AsdCheckbox" />
                ASD </span><span style="float: left;">
                    <input type="checkbox" id="PfoCheckbox" />
                    PFO </span><span style="float: left;">
                        <input type="checkbox" id="FlailCheckbox" />
                        Flail AS</span>
        </div>
    </div>
    <div style="float: left; width: 360px;" class="exclude-hide-evaluation physician-section clear-all-echo-selection">
        <div style="float: left;">
            <span style="float: left;">
                <input type="checkbox" id="VsdCheckbox" />
                VSD</span> <span style="float: left;">
                    <input type="checkbox" id="SamCheckbox" />
                    SAM</span> <span style="float: left;">
                        <input type="checkbox" id="LvotoCheckbox" />
                        LVOTO</span> <span style="float: left;">
                            <input type="checkbox" id="MitralAnnularCheckbox" />
                            Mitral annular Ca++</span>
        </div>
        <div style="clear: both">
        </div>
        <div style="float: left;">
            <span style="float: left;">
                <input type="checkbox" id="RestrictedLeafletCheckbox" />
                Restricted Leaflet Motion</span> <span style="float: left;">
                    <input type="checkbox" id="RestrictedLeafletAorticCheckbox" />
                    Aortic</span> <span style="float: left;">
                        <input type="checkbox" id="RestrictedLeafletMitralCheckbox" />
                        Mitral</span> <span style="float: left;">
                            <input type="checkbox" id="RestrictedLeafletPulCheckbox" />
                            Pul</span><span style="float: left;">
                                <input type="checkbox" id="RestrictedLeafletTriCheckbox" />
                                Tri</span>
        </div>
        <div style="clear: both">
        </div>
        <div style="float: left; margin-top: 20px;">
            <div>
                <strong>Wall Motion Abnormality </strong>
            </div>
            <div>
                <span style="float: left">
                    <input type="checkbox" id="HypokineticCheckbox" />
                    Hypokinetic </span><span style="float: left">
                        <input type="checkbox" id="AkineticCheckbox" />
                        Akinetic </span><span style="float: left">
                            <input type="checkbox" id="DyskineticCheckbox" />
                            Dyskinetic </span>
            </div>
            <div style="clear: both">
            </div>
            <div>
                <span style="float: left">
                    <input type="checkbox" id="AnteriorCheckbox" />
                    Anterior </span><span style="float: left">
                        <input type="checkbox" id="PosteriorCheckbox" />
                        Posterior </span><span style="float: left">
                            <input type="checkbox" id="ApicalCheckbox" />
                            Apical </span>
            </div>
            <div style="clear: both">
            </div>
            <div>
                <span style="float: left">
                    <input type="checkbox" id="SeptalCheckbox" />
                    Septal </span><span style="float: left">
                        <input type="checkbox" id="LateralCheckbox" />
                        Lateral </span><span style="float: left">
                            <input type="checkbox" id="InferiorCheckbox" />
                            Inferior </span>
            </div>
        </div>
    </div>
</div>
<div class="left_info1" style="width: 45%;">
    <div class="left margin-top-small" id="unableScreenReasonDiv">
        <asp:DataList runat="server" ID="EchoUnableScreenDatalist" EnableViewState="false"
            RepeatLayout="Flow" RepeatColumns="4" RepeatDirection="Horizontal" CssClass="echo-unabletoscreen-dtl unable-to-screen-section">
            <ItemTemplate>
                <input type="checkbox" class="finding-unablescreen-checkbox" />&nbsp;<b><%# DataBinder.Eval(Container.DataItem, "DisplayName")%></b>
                &nbsp;&nbsp;
                <input type="hidden" class="finding-unablescreen-id" value='<%# Convert.ToString((int)DataBinder.Eval(Container.DataItem, "Reason"))%>' />
            </ItemTemplate>
        </asp:DataList>
    </div>
    <div class="lrow physician-section clear-all-selection">
        <a style="margin-left: 5px;" id="clear-all-echo" href="javascript:void(0);" onclick="clearAllEchoSelection();">Clear All Selection</a>
    </div>
</div>
<div class="rgt margin-top-small" id="Div1" style="width: 48%;">
    <b>Technician Notes: </b>
    <br />
    <textarea id="technotesecho" class="technotes" onkeypress="return imposeMaxLength(event ? event : (this.event ? this.event : window.event), this, 2000);"
        rows="2" cols="54"></textarea>
</div>
<div class="left uploadmedia-echo-div media-container-div" style="width: 937px; padding: 5px;"
    id="EchoMediaDiv">
</div>
<div class="left upload-media-section">
    <a href="javascript:OpenPopUp('Upload Images', '710', '/app/franchisee/technician/uploadTestImages.aspx?TestType=<%= (int)TestType.Echocardiogram %>&CustomerId=' + customerId);">Upload Media </a>
</div>
<div style="float: left; width: 100%; clear: both; margin-top: 5px;" class="physician-section">
    <fieldset style="float: left; width: 98%; border-radius: 4px;">
        <legend>Remarks </legend>
        <div style="float: left; width: 40%;">
            <input type="checkbox" id="technicalltdreadableinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Technically Limited</b><br />
            <div runat="server" id="echoPhysicianRepeatStudy">
                <input type="checkbox" id="repeatstudyunreadableinputcheck" class="alt-conclusion-skipfinding-check" />&nbsp;<b>Repeat Study Unreadable</b><br />
            </div>
            <input type="checkbox" id="criticalEcho" />&nbsp;<b>Critical (Self Submit within 48 hrs)</b>
            <div class="validate-echo-carotid-aaa" id="echoOtherModalitiesAdditionalImages" runat="server">
                <input type="radio" id="EchoConsiderOtherModalities" name="EchoPhysicianAdditionalFindingReading" onclick="clearAllEchoSelection();" />&nbsp;<b>Consider other modalities</b><br />
                <input type="radio" id="EchoAdditionalImagesNeeded" name="EchoPhysicianAdditionalFindingReading" onclick="clearAllEchoSelection();" />&nbsp;<b>Additional images needed to finalize report</b><br />
            </div>
        </div>
        <div style="float: left; width: 58%;">
            <textarea id="physicianRemarksEcho" rows="3" style="width: 98%;"></textarea>
        </div>
    </fieldset>
</div>
    </div>

<div id="echo_chat" class="left_info1" style="width: 100%; padding-left: 0px;" runat="server">
    <div class="orange-band test-section-header">
        <h5 class="left" style="width: 50%;">
            <span class="org-heading" style="width: 100%;"><strong>Echocardiogram Results</strong></span>
        </h5>
        <span class="chk_orngband">
            <select id="conductedbyecho" class="conductedby-ddl">
            </select>
        </span>
        <span class="chk_orngband" id="echo-retest-span">
            <input type="checkbox" id="Retest_4" />Retest
        </span>
    </div>
    <div class="hrows echo-verificationpanel" style="color: Red; background: #fff0a5; border: solid 1px fff0a5; padding: 2px 2px 2px 5px; display: none;">
    </div>
     <div class="contentrow rgtgbox_singleReading" style="width: 99%; padding-left: 0px;">
             
     <div class="hlfbox">
           <div class="hrows">
             <div class="nrow" style="margin-left:12px;">
                  <input type="checkbox" id="chk_echocapturebyChat" />
                   <b>Result Entry Completed in CHAT </b>
                </div>
            </div>
     </div>
             
     </div>
</div>

<script language="javascript" type="text/javascript">
    var testTypeEcho = '<%= (long)TestType.Echocardiogram %>';
    var IsechoResultEntryExternaly = '<%= IsResultEntrybyChat %>';
    var echo = null;

    function SetEchoData(testResult) {
        echo = new Echocardiogram(testResult);
        echo.setData();
    }

    function GetEchoData() {
        if (echo == null) echo = new Echocardiogram();
        return echo.getData();
    }

</script>
