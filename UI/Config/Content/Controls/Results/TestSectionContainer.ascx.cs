using System;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Medical.Repositories;
using Falcon.App.Infrastructure.Repositories;

namespace Falcon.App.UI.Config.Content.Controls.Results
{
    public partial class TestSectionContainer : System.Web.UI.UserControl
    {
        public Boolean ContainsReviewableTests { get; set; }
        private long _customerId = 0;
        private long _eventId = 0;
        public long CustomerId
        {
            get
            {
                return String.IsNullOrEmpty(Request.QueryString["CustomerId"]) ? _customerId : Convert.ToInt64(Request.QueryString["CustomerId"]);
            }
            set { _customerId = value; }
        }

        public long EventId
        {
            get
            {
                return String.IsNullOrEmpty(Request.QueryString["EventId"]) ? _eventId : Convert.ToInt64(Request.QueryString["EventId"]);
            }
            set { _eventId = value; }
        }

        public bool ShowHideRepeatStudyCheckBox { get; set; }

        protected string VersionNumber { get; set; }

        protected bool IsAnyTestInHip { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
            VersionNumber = systemInformationRepository.GetBuildNumber();

            ucAuditStroke1.EventId = EventId;
            ucAuditStroke1.CustomerId = CustomerId;

            ucAuditAwvAaa.EventId = EventId;
            ucAuditAwvAaa.CustomerId = CustomerId;

            var eventRepository = IoC.Resolve<IEventRepository>();
            var eventData = eventRepository.GetById(EventId);

            ThyroidControl.EventId = EventId;
            ThyroidControl.EventDate = eventData.EventDate;

            PsaControl.EventId = EventId;
            PsaControl.EventDate = eventData.EventDate;

            CrpControl.EventId = EventId;
            CrpControl.EventDate = eventData.EventDate;

            TestosteroneControl.EventId = EventId;
            TestosteroneControl.EventDate = eventData.EventDate;

            VisionControl.EventId = EventId;
            VisionControl.EventDate = eventData.EventDate;

            awvEchocardiogram.EventId = EventId;
            awvEchocardiogram.CustomerId = CustomerId;

            ucAuditLead.EventId = EventId;
            ucAuditLead.CustomerId = CustomerId;

            ShowHideRepeatStudyCheckBox = false;

            var showHideRepeatStudyDate = IoC.Resolve<ISettings>().ShowHideRepeatStudyDate;

            if (eventData.EventDate.Date <= showHideRepeatStudyDate.Date)
            {
                var physicianEvaluationRepository = IoC.Resolve<PhysicianEvaluationRepository>();
                var physicianEvaluation = physicianEvaluationRepository.GetPhysicianEvaluationbyEventIdCustomerId(EventId, CustomerId);

                ShowHideRepeatStudyCheckBox = physicianEvaluation != null && physicianEvaluation.EvaluationStartTime < showHideRepeatStudyDate.Date;
            }

            ShowHideRepeatStudyControl();
        }

        private void ShowHideRepeatStudyControl()
        {
            ucAuditAAA1.ShowHideRepeatStudyCheckBox = ShowHideRepeatStudyCheckBox;
            ucAuditStroke1.ShowHideRepeatStudyCheckBox = ShowHideRepeatStudyCheckBox;
            Echocardiogram.ShowHideRepeatStudyCheckBox = ShowHideRepeatStudyCheckBox;
        }

        public void SetSectionShowHide(bool showHideHypertention)
        {
            var orderId = IoC.Resolve<IOrderRepository>().GetOrderIdByEventIdCustomerId(EventId, CustomerId);
            var package = IoC.Resolve<IEventPackageRepository>().GetPackageForOrder(orderId);
            var eventTests = IoC.Resolve<IEventTestRepository>().GetTestsForOrder(orderId);

            if (package != null)
                eventTests = eventTests.Concat(package.Tests.ToArray());

            var tests = eventTests.Select(et => et.Test).ToArray();

            ContainsReviewableTests = tests.Any(t => t.IsReviewable && (t.ResultEntryTypeId.HasValue == false || t.ResultEntryTypeId == (long)ResultEntryType.Hip));

            tests = tests.Where(t => t.IsRecordable).ToArray();
            IsAnyTestInHip = tests.Any(x => x.ResultEntryTypeId.HasValue == false || x.ResultEntryTypeId.Value == (long)ResultEntryType.Hip);
            foreach (var test in tests)
            {
                switch ((TestType)test.Id)
                {
                    case TestType.AAA:
                        ucAuditAAA1.Visible = true;
                        ucAuditAAA1.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;

                    case TestType.AwvAAA:
                        ucAuditAwvAaa.Visible = true;
                        ucAuditAwvAaa.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;

                    case TestType.ASI:
                        ucAuditASI1.Visible = true;
                        ucAuditASI1.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;

                    case TestType.A1C:
                        hemaglobinControl.Visible = true;
                        hemaglobinControl.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;

                    case TestType.PAD:
                        ucAuditPAD1.Visible = true;
                        ucAuditPAD1.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;

                    case TestType.AwvABI:
                        ucAuditAwvAbi.Visible = true;
                        ucAuditAwvAbi.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;

                    case TestType.EKG:
                        ucAuditEkg.Visible = true;
                        ucAuditEkg.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;

                    case TestType.Echocardiogram:
                        Echocardiogram.Visible = true;
                        Echocardiogram.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;

                    case TestType.Stroke:
                        ucAuditStroke1.Visible = true;
                        ucAuditStroke1.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;

                    case TestType.AwvCarotid:
                        auditAwvCarotid.Visible = true;
                        auditAwvCarotid.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;

                    case TestType.Lead:
                        ucAuditLead.Visible = true;
                        ucAuditLead.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;

                    case TestType.Lipid:
                        ucAuditLipid.Visible = true;
                        ucAuditLipid.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;

                    case TestType.AwvLipid:
                        auditAwvLipid.Visible = true;
                        auditAwvLipid.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;

                    case TestType.Cholesterol:
                        CholesterolControl.Visible = true;
                        CholesterolControl.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;

                    case TestType.Diabetes:
                        DiabetesControl.Visible = true;
                        DiabetesControl.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;

                    case TestType.Osteoporosis:
                        ucAuditOsteoporosis1.Visible = true;
                        ucAuditOsteoporosis1.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;

                    case TestType.Spiro:
                        SpiroControl.Visible = true;
                        SpiroControl.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;

                    case TestType.IMT:
                        ImtControl.Visible = true;
                        ImtControl.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;

                    case TestType.Thyroid:
                        ThyroidControl.Visible = true;
                        ThyroidControl.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;

                    case TestType.Psa:
                        PsaControl.Visible = true;
                        PsaControl.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;

                    case TestType.Crp:
                        CrpControl.Visible = true;
                        CrpControl.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;

                    case TestType.Colorectal:
                        ColorectalControl.Visible = true;
                        ColorectalControl.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;

                    case TestType.Kyn:
                        KynControl.Visible = true;
                        KynControl.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;

                    case TestType.PulmonaryFunction: //H
                        PulmonaryControl.Visible = true;
                        PulmonaryControl.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;

                    case TestType.Testosterone:
                        TestosteroneControl.Visible = true;
                        TestosteroneControl.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;

                    case TestType.PPAAA:
                        ucAuditPpAAA.Visible = true;
                        ucAuditPpAAA.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;

                    case TestType.PPEcho:
                        PpEchocardiogram.Visible = true;
                        PpEchocardiogram.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;

                    case TestType.AWV:
                        AwvControl.Visible = true;
                        AwvControl.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;

                    case TestType.Medicare:
                        MedicareControl.Visible = true;
                        MedicareControl.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;

                    case TestType.AwvSubsequent:
                        AwvSubsequentControl.Visible = true;
                        AwvSubsequentControl.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;

                    case TestType.Hearing:
                        HearingControl.Visible = true;
                        HearingControl.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;

                    case TestType.Vision:
                        VisionControl.Visible = true;
                        VisionControl.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;

                    case TestType.Glaucoma:
                        GlaucomaControl.Visible = true;
                        GlaucomaControl.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;

                    case TestType.HCPAAA:
                        ucAuditHcpAAA.Visible = true;
                        ucAuditHcpAAA.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;

                    case TestType.HCPCarotid:
                        HcpCarotid.Visible = true;
                        HcpCarotid.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;

                    case TestType.HCPEcho:
                        HcpEchocardiogram.Visible = true;
                        HcpEchocardiogram.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;

                    case TestType.AwvEcho:
                        awvEchocardiogram.Visible = true;
                        awvEchocardiogram.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;

                    case TestType.AwvBoneMass:
                        awvBoneMass.Visible = true;
                        awvBoneMass.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;

                    case TestType.AwvEkg:
                        ucAuditAwvEkg.Visible = true;
                        ucAuditAwvEkg.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;

                    case TestType.AwvEkgIPPE:
                        AwvEkgIppe1.Visible = true;
                        AwvEkgIppe1.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;

                    case TestType.AwvSpiro:
                        awvspiroAudit.Visible = true;
                        awvspiroAudit.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;

                    case TestType.AwvHBA1C:
                        AwvHBA1C.Visible = true;
                        AwvHBA1C.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;

                    case TestType.AwvGlucose:
                        awvGlucose.Visible = true;
                        awvGlucose.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;

                    case TestType.HPylori:
                        HPyloriControl.Visible = true;
                        HPyloriControl.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;
                    case TestType.WomenBloodPanel:
                        WomenBloodPanelControl.Visible = true;
                        WomenBloodPanelControl.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;

                    case TestType.VitaminD:
                        VitaminDControl.Visible = true;
                        VitaminDControl.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;
                    case TestType.Hypertension:
                        HypertensionControl.Visible = showHideHypertention;
                        HypertensionControl.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;
                    case TestType.Hemoglobin:
                        hemoglobinControl.Visible = true;
                        hemoglobinControl.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;

                    case TestType.DiabeticRetinopathy:
                        diabeticRetinopathy.Visible = true;
                        diabeticRetinopathy.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;

                    case TestType.eAWV:
                        eawvControl.Visible = true;
                        eawvControl.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;

                    case TestType.MenBloodPanel:
                        MenBloodPanelControl.Visible = true;
                        MenBloodPanelControl.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;
                    case TestType.DiabetesFootExam:
                        DiabetesFootExamControl.Visible = true;
                        DiabetesFootExamControl.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;
                    case TestType.RinneWeberHearing:
                        RinneWeberHearingControl.Visible = true;
                        RinneWeberHearingControl.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;
                    case TestType.Monofilament:
                        MonofilamentControl.Visible = true;
                        MonofilamentControl.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;
                    case TestType.DiabeticNeuropathy:
                        diabeticNeuropathy.Visible = true;
                        diabeticNeuropathy.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;
                    case TestType.FloChecABI:
                        ucFloChecABIControl.Visible = true;
                        ucFloChecABIControl.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;
                    case TestType.IFOBT:
                        IFOBTControl.Visible = true;
                        IFOBTControl.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;
                    case TestType.QualityMeasures:
                        QualityMeasuresControl.Visible = true;
                        QualityMeasuresControl.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId == (long)ResultEntryType.Chat ? true : false;
                        break;
                    case TestType.PHQ9:
                        phq9Control.Visible = true;
                        phq9Control.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId == (long)ResultEntryType.Chat ? true : false;
                        break;
                    case TestType.FocAttestation:
                        focAttestationControl.Visible = true;
                        focAttestationControl.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;
                    case TestType.Mammogram:
                        mammogramControl.Visible = true;
                        mammogramControl.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;
                    case TestType.UrineMicroalbumin:
                        UrineMicroalbuminControl.Visible = true;
                        UrineMicroalbuminControl.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId == (long)ResultEntryType.Chat ? true : false;
                        break;
                    case TestType.FluShot:
                        flushotControl.Visible = true;
                        flushotControl.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId == (long)ResultEntryType.Chat ? true : false;
                        break;
                    case TestType.AwvFluShot:
                        awvFluShotControl.Visible = true;
                        awvFluShotControl.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId == (long)ResultEntryType.Chat ? true : false;
                        break;
                    case TestType.Pneumococcal:
                        pneumococcalControl.Visible = true;
                        pneumococcalControl.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId == (long)ResultEntryType.Chat ? true : false;
                        break;
                    case TestType.Chlamydia:
                        chlamydiaControl.Visible = true;
                        chlamydiaControl.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId == (long)ResultEntryType.Chat ? true : false;
                        break;
                    case TestType.QuantaFloABI:
                        ucQuantaFloABIControl.Visible = true;
                        ucQuantaFloABIControl.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId == (long)ResultEntryType.Chat ? true : false;
                        break;
                    case TestType.DPN:
                        dpnControl.Visible = true;
                        dpnControl.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId == (long)ResultEntryType.Chat ? true : false;
                        break;
                    case TestType.HKYN:
                        hkynControl.Visible = true;
                        hkynControl.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId == (long)ResultEntryType.Chat ? true : false;
                        break;
                    case TestType.MyBioCheckAssessment:
                        MyBioCheckAssessment.Visible = true;
                        MyBioCheckAssessment.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;
                    case TestType.Foc:
                        focControl.Visible = true;
                        focControl.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;
                    case TestType.Cs:
                        csControl.Visible = true;
                        csControl.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;
                    case TestType.Qv:
                        qvControl.Visible = true;
                        qvControl.IsResultEntrybyChat = test.ResultEntryTypeId.HasValue && test.ResultEntryTypeId.Value == (long)ResultEntryType.Chat ? true : false;
                        break;
                }
            }
        }

        public void SetSectionShowHideEvaluation(long eventId, long customerId, bool showHideHypertention)
        {
            var orderId = IoC.Resolve<IOrderRepository>().GetOrderIdByEventIdCustomerId(eventId, customerId);
            var package = IoC.Resolve<IEventPackageRepository>().GetPackageForOrder(orderId);
            var eventTests = IoC.Resolve<IEventTestRepository>().GetTestsForOrder(orderId);

            if (package != null)
                eventTests = eventTests.Concat(package.Tests.ToArray());

            var tests = eventTests.Where(t => t.Test.IsReviewable && (t.Test.ResultEntryTypeId.HasValue == false || t.Test.ResultEntryTypeId == (long)ResultEntryType.Hip)).Select(t => t.Test).ToList();
            foreach (var test in tests)
            {
                switch ((TestType)test.Id)
                {
                    case TestType.AAA:
                        ucAuditAAA1.Visible = true;
                        break;
                    case TestType.AwvAAA:
                        ucAuditAwvAaa.Visible = true;
                        break;

                    case TestType.ASI:
                        ucAuditASI1.Visible = true;
                        break;

                    case TestType.A1C:
                        hemaglobinControl.Visible = true;
                        break;

                    case TestType.PAD:
                        ucAuditPAD1.Visible = true;
                        break;

                    case TestType.AwvABI:
                        ucAuditAwvAbi.Visible = true;
                        break;

                    case TestType.EKG:
                        ucAuditEkg.Visible = true;
                        break;

                    case TestType.Echocardiogram:
                        Echocardiogram.Visible = true;
                        break;

                    case TestType.Stroke:
                        ucAuditStroke1.Visible = true;
                        break;

                    case TestType.AwvCarotid:
                        auditAwvCarotid.Visible = true;
                        break;

                    case TestType.Lead:
                        ucAuditLead.Visible = true;
                        break;

                    case TestType.Lipid:
                        ucAuditLipid.Visible = true;
                        break;

                    case TestType.AwvLipid:
                        auditAwvLipid.Visible = true;
                        break;

                    case TestType.Cholesterol:
                        CholesterolControl.Visible = true;
                        break;

                    case TestType.Diabetes:
                        DiabetesControl.Visible = true;
                        break;

                    case TestType.Osteoporosis:
                        ucAuditOsteoporosis1.Visible = true;
                        break;

                    case TestType.Spiro:
                        SpiroControl.Visible = true;
                        break;

                    case TestType.IMT:
                        ImtControl.Visible = true;
                        break;

                    case TestType.Thyroid:
                        ThyroidControl.Visible = true;
                        break;

                    case TestType.Psa:
                        PsaControl.Visible = true;
                        break;

                    case TestType.Crp:
                        CrpControl.Visible = true;
                        break;

                    case TestType.Colorectal:
                        ColorectalControl.Visible = true;
                        break;

                    case TestType.Kyn:
                        KynControl.Visible = true;
                        break;

                    case TestType.PulmonaryFunction:
                        PulmonaryControl.Visible = true;
                        break;

                    case TestType.Testosterone:
                        TestosteroneControl.Visible = true;
                        break;

                    case TestType.PPAAA:
                        ucAuditPpAAA.Visible = true;
                        break;

                    case TestType.PPEcho:
                        PpEchocardiogram.Visible = true;
                        break;

                    case TestType.AWV:
                        AwvControl.Visible = true;
                        break;

                    case TestType.Medicare:
                        MedicareControl.Visible = true;
                        break;

                    case TestType.AwvSubsequent:
                        AwvSubsequentControl.Visible = true;
                        break;

                    case TestType.Hearing:
                        HearingControl.Visible = true;
                        break;

                    case TestType.Vision:
                        VisionControl.Visible = true;
                        break;

                    case TestType.Glaucoma:
                        GlaucomaControl.Visible = true;
                        break;

                    case TestType.HCPAAA:
                        ucAuditHcpAAA.Visible = true;
                        break;

                    case TestType.HCPCarotid:
                        HcpCarotid.Visible = true;
                        break;

                    case TestType.HCPEcho:
                        HcpEchocardiogram.Visible = true;
                        break;
                    case TestType.AwvEcho:
                        awvEchocardiogram.Visible = true;
                        break;
                    case TestType.AwvBoneMass:
                        awvBoneMass.Visible = true;
                        break;

                    case TestType.AwvEkg:
                        ucAuditAwvEkg.Visible = true;
                        break;

                    case TestType.AwvEkgIPPE:
                        AwvEkgIppe1.Visible = true;
                        break;

                    case TestType.AwvSpiro:
                        awvspiroAudit.Visible = true;
                        break;

                    case TestType.AwvHBA1C:
                        AwvHBA1C.Visible = true;
                        break;

                    case TestType.AwvGlucose:
                        awvGlucose.Visible = true;
                        break;

                    case TestType.HPylori:
                        HPyloriControl.Visible = true;
                        break;

                    case TestType.MenBloodPanel:
                        MenBloodPanelControl.Visible = true;
                        break;

                    case TestType.WomenBloodPanel:
                        WomenBloodPanelControl.Visible = true;
                        break;
                    case TestType.VitaminD:
                        VitaminDControl.Visible = true;
                        break;
                    case TestType.Hypertension:
                        HypertensionControl.Visible = showHideHypertention;
                        break;
                    case TestType.Hemoglobin:
                        hemoglobinControl.Visible = true;
                        break;
                    case TestType.DiabeticRetinopathy:
                        diabeticRetinopathy.Visible = true;
                        break;
                    case TestType.eAWV:
                        eawvControl.Visible = true;
                        break;
                    case TestType.DiabetesFootExam:
                        DiabetesFootExamControl.Visible = true;
                        break;
                    case TestType.RinneWeberHearing:
                        RinneWeberHearingControl.Visible = true;
                        break;
                    case TestType.Monofilament:
                        MonofilamentControl.Visible = true;
                        break;
                    case TestType.DiabeticNeuropathy:
                        diabeticNeuropathy.Visible = true;
                        break;
                    case TestType.FloChecABI:
                        ucFloChecABIControl.Visible = true;
                        break;
                    case TestType.IFOBT:
                        IFOBTControl.Visible = true;
                        break;
                    case TestType.QualityMeasures:
                        QualityMeasuresControl.Visible = true;
                        break;
                    case TestType.PHQ9:
                        phq9Control.Visible = true;
                        break;
                    case TestType.FocAttestation:
                        focAttestationControl.Visible = true;
                        break;
                    case TestType.Mammogram:
                        mammogramControl.Visible = true;
                        break;
                    case TestType.UrineMicroalbumin:
                        UrineMicroalbuminControl.Visible = true;
                        break;
                    case TestType.FluShot:
                        flushotControl.Visible = true;
                        break;
                    case TestType.AwvFluShot:
                        awvFluShotControl.Visible = true;
                        break;
                    case TestType.Pneumococcal:
                        pneumococcalControl.Visible = true;
                        break;
                    case TestType.Chlamydia:
                        chlamydiaControl.Visible = true;
                        break;
                    case TestType.QuantaFloABI:
                        ucQuantaFloABIControl.Visible = true;
                        break;
                    case TestType.DPN:
                        dpnControl.Visible = true;
                        break;
                    case TestType.HKYN:
                        hkynControl.Visible = true;
                        break;
                    case TestType.MyBioCheckAssessment:
                        MyBioCheckAssessment.Visible = true;
                        break;
                    case TestType.Foc:
                        focControl.Visible = true;
                        break;
                    case TestType.Cs:
                        csControl.Visible = true;
                        break;
                    case TestType.Qv:
                        qvControl.Visible = true;
                        break;
                }
            }

        }

    }
}