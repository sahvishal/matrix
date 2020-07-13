<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TestSectionContainer.ascx.cs"
    Inherits="Falcon.App.UI.Config.Content.Controls.Results.TestSectionContainer" %>
<%@ Register Src="~/Config/Content/Controls/Results/Aaa.ascx" TagName="ucAuditAAA"
    TagPrefix="uc1" %>
<%@ Register Src="~/Config/Content/Controls/Results/Osteoporosis.ascx" TagName="ucAuditOsteoporosis"
    TagPrefix="uc2" %>
<%@ Register Src="~/Config/Content/Controls/Results/Stroke.ascx" TagName="ucAuditStroke"
    TagPrefix="uc3" %>
<%@ Register Src="~/Config/Content/Controls/Results/Asi.ascx" TagName="ucAuditASI"
    TagPrefix="uc4" %>
<%@ Register Src="~/Config/Content/Controls/Results/Pad.ascx" TagName="ucAuditPAD"
    TagPrefix="uc5" %>
<%@ Register Src="~/Config/Content/Controls/Results/Ekg.ascx" TagName="ucAuditEKG"
    TagPrefix="uc6" %>
<%@ Register Src="~/Config/Content/Controls/Results/Lipid.ascx" TagName="ucAuditLipid"
    TagPrefix="uc7" %>
<%@ Register Src="~/Config/Content/Controls/Results/Echocardiogram.ascx" TagName="Echocardiogram"
    TagPrefix="uc11" %>
<%@ Register Src="~/Config/Content/Controls/Results/Imt.ascx" TagName="Imt" TagPrefix="ucImt" %>
<%@ Register Src="~/Config/Content/Controls/Results/Thyroid.ascx" TagName="Thyroid"
    TagPrefix="ucThyroid" %>
<%@ Register Src="~/Config/Content/Controls/Results/Pulmonary.ascx" TagName="Pulmonary"
    TagPrefix="ucPulm" %>
<%@ Register Src="~/Config/Content/Controls/Results/Hemaglobin.ascx" TagName="Hemaglobin"
    TagPrefix="uchemaglobin" %>
<%@ Register Src="~/Config/Content/Controls/Results/Psa.ascx" TagName="Psa" TagPrefix="ucPsa" %>
<%@ Register Src="~/Config/Content/Controls/Results/VitaminD.ascx" TagName="VitaminD" TagPrefix="ucVitaminD" %>
<%@ Register Src="~/Config/Content/Controls/Results/MenBloodPanel.ascx" TagName="MenBloodPanel" TagPrefix="ucMenBloodPanel" %>
<%@ Register Src="~/Config/Content/Controls/Results/WomenBloodPanel.ascx" TagName="WomenBloodPanel" TagPrefix="ucWomenBloodPanel" %>
<%@ Register Src="~/Config/Content/Controls/Results/Hypertension.ascx" TagName="Hypertension" TagPrefix="ucHypertension" %>
<%@ Register Src="~/Config/Content/Controls/Results/Crp.ascx" TagName="Crp" TagPrefix="ucCrp" %>
<%@ Register Src="~/Config/Content/Controls/Results/Colorectal.ascx" TagName="Colorectal"
    TagPrefix="ucColorectal" %>
<%@ Register Src="~/Config/Content/Controls/Results/Kyn.ascx" TagName="Kyn" TagPrefix="ucKyn" %>
<%@ Register Src="~/Config/Content/Controls/Results/Testosterone.ascx" TagName="Testosterone" TagPrefix="ucTestosterone" %>
<%@ Register Src="~/Config/Content/Controls/Results/PpAaaa.ascx" TagName="ucAuditPpAAA" TagPrefix="ucPpAaa" %>
<%@ Register Src="~/Config/Content/Controls/Results/PpEchocardiogram.ascx" TagName="PpEchocardiogram" TagPrefix="ucPpEcho" %>
<%@ Register Src="~/Config/Content/Controls/Results/Spiro.ascx" TagName="Spiro" TagPrefix="ucSpiro" %>
<%@ Register Src="~/Config/Content/Controls/Results/Lead.ascx" TagName="Lead" TagPrefix="ucLead" %>

<%@ Register Src="~/Config/Content/Controls/Results/Awv.ascx" TagName="Awv" TagPrefix="ucAwv" %>
<%@ Register Src="~/Config/Content/Controls/Results/AwvSubsequent.ascx" TagName="AwvSubsequent" TagPrefix="ucAwvSubsequent" %>
<%@ Register Src="~/Config/Content/Controls/Results/Medicare.ascx" TagName="Medicare" TagPrefix="ucMedicare" %>
<%@ Register Src="~/Config/Content/Controls/Results/Hearing.ascx" TagName="Hearing" TagPrefix="ucHearing" %>
<%@ Register Src="~/Config/Content/Controls/Results/Vision.ascx" TagName="Vision" TagPrefix="ucVision" %>
<%@ Register Src="~/Config/Content/Controls/Results/Glaucoma.ascx" TagName="Glaucoma" TagPrefix="ucGlaucoma" %>

<%@ Register Src="~/Config/Content/Controls/Results/HcpAaa.ascx" TagName="HcpAAA" TagPrefix="ucHcpAaa" %>
<%@ Register Src="~/Config/Content/Controls/Results/HcpCarotid.ascx" TagName="HcpCarotid" TagPrefix="ucHcpCarotid" %>
<%@ Register Src="~/Config/Content/Controls/Results/HcpEchocardiogram.ascx" TagName="HcpEchocardiogram" TagPrefix="ucHcpEcho" %>
<%@ Register Src="~/Config/Content/Controls/Results/AwvAbi.ascx" TagName="ucAuditAwvAbi" TagPrefix="ucAwvAbi" %>
<%@ Register Src="~/Config/Content/Controls/Results/AwvAaa.ascx" TagName="AwvAaa" TagPrefix="ucAwvAaa" %>
<%@ Register Src="~/Config/Content/Controls/Results/AwvCarotid.ascx" TagName="AwvCarotid" TagPrefix="ucAwvCarotid" %>
<%@ Register Src="~/Config/Content/Controls/Results/AwvEchocardiogram.ascx" TagName="AwvEcho" TagPrefix="ucAwv" %>

<%@ Register Src="~/Config/Content/Controls/Results/AwvBoneMass.ascx" TagName="AwvBoneMass" TagPrefix="ucAwv" %>
<%@ Register Src="~/Config/Content/Controls/Results/AwvEkg.ascx" TagName="AwvEkg" TagPrefix="ucAwv" %>
<%@ Register Src="~/Config/Content/Controls/Results/AwvEkgIPPE.ascx" TagName="AwvEkgIPPE" TagPrefix="ucAwv" %>
<%@ Register Src="~/Config/Content/Controls/Results/AwvSpiro.ascx" TagName="AwvSpiro" TagPrefix="ucAwv" %>
<%@ Register Src="~/Config/Content/Controls/Results/AwvHemaglobin.ascx" TagName="AwvHBA1C" TagPrefix="ucAwv" %>
<%@ Register Src="~/Config/Content/Controls/Results/AwvGlucose.ascx" TagName="AwvGlucose" TagPrefix="ucAwv" %>
<%@ Register Src="~/Config/Content/Controls/Results/AwvLipid.ascx" TagName="AwvLipid" TagPrefix="ucAwv" %>

<%@ Register Src="~/Config/Content/Controls/Results/Cholesterol.ascx" TagName="Cholesterol" TagPrefix="ucCholesterol" %>
<%@ Register Src="~/Config/Content/Controls/Results/Diabetes.ascx" TagName="Diabetes" TagPrefix="ucDiabetes" %>

<%@ Register Src="~/Config/Content/Controls/Results/HPylori.ascx" TagName="HPylori" TagPrefix="ucHPylori" %>
<%@ Register Src="~/Config/Content/Controls/Results/Hemoglobin.ascx" TagName="Hemoglobin" TagPrefix="ucHemoglobin" %>
<%@ Register Src="~/Config/Content/Controls/Results/DiabeticRetinopathy.ascx" TagName="DiabeticRetinopathy" TagPrefix="ucDiabeticRetinopathy" %>
<%@ Register Src="~/Config/Content/Controls/Results/Eawv.ascx" TagName="Eawv" TagPrefix="ucEawv" %>
<%@ Register Src="~/Config/Content/Controls/Results/DiabetesFootExam.ascx" TagName="DiabetesFootExam" TagPrefix="ucDiabetesFootExam" %>
<%@ Register Src="~/Config/Content/Controls/Results/RinneWeberHearing.ascx" TagName="RinneWeberHearing" TagPrefix="ucRinneWeberHearing" %>
<%@ Register Src="~/Config/Content/Controls/Results/DiabeticNeuropathy.ascx" TagName="DiabeticNeuropathy" TagPrefix="ucDiabeticNeuropathy" %>
<%@ Register Src="~/Config/Content/Controls/Results/FloChecABI.ascx" TagName="FloChecABI" TagPrefix="ucFloChecABI" %>
<%@ Register Src="~/Config/Content/Controls/Results/IFOBT.ascx" TagName="IFOBT" TagPrefix="ucIFOBT" %>
<%@ Register Src="~/Config/Content/Controls/Results/QualityMeasures.ascx" TagName="QualityMeasures" TagPrefix="ucQualityMeasures" %>
<%@ Register Src="~/Config/Content/Controls/Results/Monofilament.ascx" TagName="Monofilament" TagPrefix="ucMonofilament" %>
<%@ Register Src="~/Config/Content/Controls/Results/Phq9.ascx" TagName="phq9" TagPrefix="ucPhq9" %>
<%@ Register Src="~/Config/Content/Controls/Results/FocAttestation.ascx" TagName="FocAttestation" TagPrefix="ucFocAttestation" %>
<%@ Register Src="~/Config/Content/Controls/Results/Mammogram.ascx" TagName="mammogram" TagPrefix="ucMammogram" %>
<%@ Register Src="~/Config/Content/Controls/Results/UrineMicroalbumin.ascx" TagName="UrineMicroalbumin" TagPrefix="ucUrineMicroalbumin" %>
<%@ Register Src="~/Config/Content/Controls/Results/FluShot.ascx" TagName="flushot" TagPrefix="ucFluShot" %>
<%@ Register Src="~/Config/Content/Controls/Results/AwvFluShot.ascx" TagName="awvFluShot" TagPrefix="ucAwvFluShot" %>
<%@ Register Src="~/Config/Content/Controls/Results/Pneumococcal.ascx" TagName="pneumococcal" TagPrefix="ucPneumococcal" %>
<%@ Register Src="~/Config/Content/Controls/Results/Chlamydia.ascx" TagName="Chlamydia" TagPrefix="ucChlamydia" %>
<%@ Register Src="~/Config/Content/Controls/Results/QuantaFloABI.ascx" TagName="QuantaFloABI" TagPrefix="ucQuantaFloABI" %>
<%@ Register Src="~/Config/Content/Controls/Results/Dpn.ascx" TagName="Dpn" TagPrefix="ucDpn" %>
<%@ Register Src="~/Config/Content/Controls/Results/Hkyn.ascx" TagPrefix="UcHkyn" TagName="Hkyn" %>
<%@ Register Src="~/Config/Content/Controls/Results/MyBioCheckAssessment.ascx" TagPrefix="ucBioCheck" TagName="MyBioCheckAssessment" %>
<%@ Register Src="~/Config/Content/Controls/Results/Foc.ascx" TagPrefix="ucFoc" TagName="Foc" %>
<%@ Register Src="~/Config/Content/Controls/Results/Cs.ascx" TagPrefix="ucCs" TagName="Cs" %>
<%@ Register Src="~/Config/Content/Controls/Results/Qv.ascx" TagPrefix="ucQv" TagName="Qv" %>


<script language="javascript" type="text/javascript" src="/Config/Content/Javascript/SetScreen.js?q=<%= VersionNumber %>"></script>
<script language="javascript" type="text/javascript" src="/App/JavascriptFiles/CheckLipidValues.js?q=<%= VersionNumber %>"></script>
<script language="javascript" type="text/javascript" src="/App/JavascriptFiles/BloodPressureValidation.js?q=<%= VersionNumber %>"></script>
<div class="contentrow">
    <%--Test Portion Starts Here--%>
    <div class="lipidDiv clearfix" style="display: none">
        <uc7:ucAuditLipid ID="ucAuditLipid" Visible="false" runat="server" />
    </div>
    <div class="awvLipidDiv clearfix" style="display: none">
        <ucAwv:AwvLipid ID="auditAwvLipid" Visible="false" runat="server" />
    </div>
     <div class="myBioCheckAssessmentDiv clearfix" style="display: none">
        <ucBioCheck:MyBioCheckAssessment ID="MyBioCheckAssessment" Visible="false" runat="server" />
    </div>
    <div class="CholesterolDiv clearfix" style="display: none">
        <ucCholesterol:Cholesterol ID="CholesterolControl" Visible="false" runat="server" />
    </div>
    <div class="awvGlucoseDiv clearfix" style="display: none">
        <ucAwv:AwvGlucose runat="server" Visible="false" ID="awvGlucose" />
    </div>
    <div class="DiabetesDiv clearfix" style="display: none">
        <ucDiabetes:Diabetes runat="server" Visible="false" ID="DiabetesControl" />
    </div>
    <div class="DiabeticRetinopathyDiv clearfix" style="display: none">
        <ucDiabeticRetinopathy:DiabeticRetinopathy runat="server" Visible="false" ID="diabeticRetinopathy" />
    </div>
    <div class="DiabeticNeuropathyDiv clearfix" style="display: none">
        <ucDiabeticNeuropathy:DiabeticNeuropathy runat="server" Visible="False" ID="diabeticNeuropathy" />
    </div>
    <div class="DpnDiv clearfix" style="display: none">
        <ucDpn:Dpn runat="server" Visible="False" ID="dpnControl" />
    </div>
    <div class="KynDiv clearfix" style="display: none">
        <ucKyn:Kyn runat="server" Visible="false" ID="KynControl" />
    </div>
    <div class="HkynDiv clearfix" style="display: none">
        <UcHkyn:Hkyn runat="server" Visible="false" ID="hkynControl" />
    </div>
    <div class="a1cDiv clearfix" style="display: none">
        <uchemaglobin:Hemaglobin runat="server" Visible="false" ID="hemaglobinControl" />
    </div>
    <div class="HemoglobinDiv clearfix" style="display: none">
        <ucHemoglobin:Hemoglobin runat="server" Visible="false" ID="hemoglobinControl" />
    </div>
     <div class="awvHemaglobinDiv clearfix" style="display: none">
        <ucAwv:AwvHBA1C runat="server" Visible="false" ID="AwvHBA1C" />
    </div>
    <div class="thyroidDiv clearfix" style="display: none">
        <ucThyroid:Thyroid runat="server" Visible="false" ID="ThyroidControl" />
    </div>
    <div class="CrpDiv clearfix" style="display: none">
        <ucCrp:Crp runat="server" Visible="false" ID="CrpControl" />
    </div>
    <div class="PsaDiv clearfix" style="display: none">
        <ucPsa:Psa runat="server" Visible="false" ID="PsaControl" />
    </div>
    <div class="ColorectalDiv clearfix" style="display: none">
        <ucColorectal:Colorectal runat="server" Visible="false" ID="ColorectalControl" />
    </div>
    <div class="TestosteroneDiv clearfix" style="display: none">
        <ucTestosterone:Testosterone runat="server" Visible="false" ID="TestosteroneControl" />
    </div>
    <div class="VitaminDDiv clearfix" style="display: none">
        <ucVitaminD:VitaminD runat="server" Visible="false" ID="VitaminDControl" />
    </div> 
     <div class="MenBloodPanelDiv clearfix" style="display: none">
        <ucMenBloodPanel:MenBloodPanel runat="server" Visible="false" ID="MenBloodPanelControl" />
    </div>
    <div class="WomenBloodPanelDiv clearfix" style="display: none">
        <ucWomenBloodPanel:WomenBloodPanel runat="server" Visible="false" ID="WomenBloodPanelControl" />
    </div>
    <div class="HypertensionDiv clearfix" style="display: none">
        <ucHypertension:Hypertension runat="server" Visible="false" ID="HypertensionControl" />
    </div>
    <div class="echoDiv clearfix" style="display: none">
        <uc11:Echocardiogram ID="Echocardiogram" Visible="false" runat="server" />
    </div>
    <div class="PpechoDiv clearfix" style="display: none">
        <ucPpEcho:PpEchocardiogram ID="PpEchocardiogram" Visible="false" runat="server" />
    </div>
    <div class="HcpEchoDiv clearfix" style="display: none">
        <ucHcpEcho:HcpEchocardiogram ID="HcpEchocardiogram" Visible="false" runat="server" />
    </div>
    <div class="awvEchoDiv clearfix" style="display: none">
        <ucAwv:AwvEcho ID="awvEchocardiogram" Visible="false" runat="server" />
    </div>
    <div class="aaaDiv clearfix" style="display: none">
        <uc1:ucAuditAAA ID="ucAuditAAA1" Visible="false" runat="server" />
    </div>
    <div class="AwvAaaDiv clearfix" style="display: none">
        <ucAwvAaa:AwvAaa ID="ucAuditAwvAaa" Visible="false" runat="server" />
    </div>
    <div class="PpaaaDiv clearfix" style="display: none">
        <ucPpAaa:ucAuditPpAAA ID="ucAuditPpAAA" Visible="false" runat="server" />
    </div>
    <div class="HcpaaaDiv clearfix" style="display: none">
        <ucHcpAaa:HcpAAA ID="ucAuditHcpAAA" Visible="false" runat="server" />
    </div>
    <div class="strokeDiv clearfix" style="display: none">
        <uc3:ucAuditStroke ID="ucAuditStroke1" Visible="false" runat="server" />
    </div>
    <div class="awvCarotidDiv clearfix" style="display: none">
        <ucAwvCarotid:AwvCarotid ID="auditAwvCarotid" Visible="false" runat="server" />
    </div>
    <div class="HcpCarotidDiv clearfix" style="display: none">
        <ucHcpCarotid:HcpCarotid ID="HcpCarotid" Visible="false" runat="server" />
    </div>
    <div class="leadDiv clearfix" style="display: none">
        <ucLead:Lead ID="ucAuditLead" Visible="false" runat="server" />
    </div>
    <div class="imtDiv clearfix" style="display: none">
        <ucImt:Imt runat="server" Visible="false" ID="ImtControl" />
    </div>
    <div class="padDiv clearfix" style="display: none">
        <uc5:ucAuditPAD ID="ucAuditPAD1" Visible="false" runat="server" />
    </div>
    <div class="AwvAbiDiv clearfix" style="display: none">
        <ucAwvAbi:ucAuditAwvAbi ID="ucAuditAwvAbi" Visible="false" runat="server" />
    </div>
    <div class="FloChecABIDiv clearfix" style="display: none;">
        <ucFloChecABI:FloChecABI ID="ucFloChecABIControl" Visible="False" runat="server" />
    </div>
    <div class="QuantaFloABIDiv clearfix" style="display: none;">
        <ucQuantaFloABI:QuantaFloABI ID="ucQuantaFloABIControl" Visible="False" runat="server" />
    </div>
    <div class="asiDiv clearfix" style="display: none">
        <uc4:ucAuditASI ID="ucAuditASI1" Visible="false" runat="server" />
    </div>
    <div class="ekgDiv clearfix" style="display: none">
        <uc6:ucAuditEKG ID="ucAuditEkg" Visible="false" runat="server" />
    </div>
    <div class="awvEkgDiv clearfix" style="display: none;clear: both;">
        <ucAwv:AwvEkg ID="ucAuditAwvEkg" Visible="false" runat="server" />
    </div>
    <div class="awvEkgIPPEDiv clearfix" style="display: none">
        <ucAwv:AwvEkgIPPE ID="AwvEkgIppe1" Visible="false" runat="server" />
    </div>
    <div class="osteoDiv clearfix" style="display: none">
        <uc2:ucAuditOsteoporosis ID="ucAuditOsteoporosis1" Visible="false" runat="server" />
    </div>
    <div class="awvBoneMassDiv clearfix" style="display: none">
        <ucAwv:AwvBoneMass runat="server" Visible="false" ID="awvBoneMass" />
    </div>
    <div class="spiroDiv clearfix" style="display: none">
        <ucSpiro:Spiro runat="server" Visible="false" ID="SpiroControl" />
    </div>
    <div class="awvSpiroDiv clearfix" style="display: none">
        <ucAwv:AwvSpiro ID="awvspiroAudit" Visible="false" runat="server" />
    </div>
    <div class="HPyloriDiv clearfix" style="display: none">
        <ucHPylori:HPylori ID="HPyloriControl" Visible="false" runat="server" />
    </div>
     <div class="IFOBTDiv clearfix" style="display: none">
        <ucIFOBT:IFOBT ID="IFOBTControl" Visible="false" runat="server" />
    </div>
    <div class="pulmonaryDiv clearfix" style="display: none">
        <ucPulm:Pulmonary runat="server" Visible="false" ID="PulmonaryControl" />
    </div>
    <div class="AwvDiv clearfix" style="display: none">
        <ucAwv:Awv runat="server" Visible="false" ID="AwvControl" />
    </div>
    <div class="AwvSubsequentDiv clearfix" style="display: none">
        <ucAwvSubsequent:AwvSubsequent runat="server" Visible="false" ID="AwvSubsequentControl" />
    </div>
    <div class="MedicareDiv clearfix"  style="display: none">
        <ucMedicare:Medicare runat="server" Visible="false" ID="MedicareControl" />
    </div>
    <div class="EAWVDiv clearfix" style="display: none">
        <ucEawv:Eawv runat="server" Visible="false" ID="eawvControl" />
    </div>
    <div class="HearingDiv clearfix" style="display: none">
        <ucHearing:Hearing runat="server" Visible="false" ID="HearingControl" />
    </div>
    <div class="RinneWeberHearingDiv clearfix" style="display: none">
        <ucRinneWeberHearing:RinneWeberHearing runat="server" Visible="false" ID="RinneWeberHearingControl" />
    </div>
     <div class="MonofilamentDiv clearfix" style="display: none">
        <ucMonofilament:Monofilament runat="server" Visible="false" ID="MonofilamentControl" />
    </div>
    <div class="VisionDiv clearfix" style="display: none">
        <ucVision:Vision runat="server" Visible="false" ID="VisionControl" />
    </div>
    <div class="GlaucomaDiv clearfix" style="display: none">
        <ucGlaucoma:Glaucoma runat="server" Visible="false" ID="GlaucomaControl" />
    </div>
    <div class="framinghamRiskDiv clearfix" style="display: none">
    </div>
    <div class="hlfboxrgt liverDiv clearfix" style="display: none">
    </div>
    <div class="DiabetesFootExamDiv clearfix" style="display: none">
        <ucDiabetesFootExam:DiabetesFootExam runat="server" Visible="false" ID="DiabetesFootExamControl" />
    </div>
    <div class="QualityMeasuresDiv clearfix" style="display: none">
        <ucQualityMeasures:QualityMeasures runat="server" Visible="false" ID="QualityMeasuresControl" />
    </div>
    <div class="phq9Div clearfix" style="display: none">
        <ucPhq9:phq9 runat="server" Visible="false" ID="phq9Control" />
    </div>
    <div class="focAttestation clearfix" style="display: none">
        <ucFocAttestation:FocAttestation runat="server" Visible="False" ID="focAttestationControl" />
    </div>
    <div class="mammogramDiv clearfix" style="display: none">
        <ucMammogram:mammogram runat="server" Visible="False" ID="mammogramControl" />
    </div>
    <div class="UrineMicroalbuminDiv clearfix" style="display: none">
        <ucUrineMicroalbumin:urineMicroalbumin runat="server" Visible="False" ID="UrineMicroalbuminControl" />
    </div>
    <div class="fluShotDiv clearfix" style="display: none">
        <ucFluShot:flushot runat="server" Visible="False" ID="flushotControl" />
    </div>
    <div class="awvFluShotDiv clearfix" style="display: none">
        <ucAwvFluShot:awvFluShot runat="server" Visible="False" ID="awvFluShotControl" />
    </div>
    <div class="PneumococcalDiv clearfix" style="display: none">
        <ucPneumococcal:pneumococcal runat="server" Visible="False" ID="pneumococcalControl" />
    </div>
     <div class="chlamydiaDiv clearfix" style="display: none">
        <ucChlamydia:Chlamydia runat="server" Visible="False" ID="chlamydiaControl" />
    </div>
    <div class="focDiv clearfix" style="display: none">
        <ucFoc:Foc runat="server" Visible="False" ID="focControl" />
    </div>
    <div class="csDiv clearfix" style="display: none">
        <ucCs:Cs runat="server" Visible="False" ID="csControl" />
    </div>

     <div class="qvDiv clearfix" style="display: none">
        <ucQv:Qv runat="server" Visible="False" ID="qvControl" />
    </div>
    <%--Test Portion Ends Here--%>
</div>

<script type="text/javascript">
    var isAnyTestInHip = '<%= IsAnyTestInHip.ToString() %>' == '<%=Boolean.TrueString %>';
</script>