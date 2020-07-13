using System;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medicare;
using Falcon.App.Core.Medicare.Enum;
using Falcon.App.Core.Medicare.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Infrastructure.Repositories.Screening;
using DateTime = System.DateTime;

namespace Falcon.App.Infrastructure.Medicare.Impl
{
    [DefaultImplementation]
    public class SyncCustomerResultPollingAgent : ISyncCustomerResultPollingAgent
    {
        private readonly ICustomSettingManager _customSettingManager;
        private readonly ILogger _logger;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMedicareApiService _medicareApiService;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IKynLabValuesRepository _kyaLabValuesRepository;
        private readonly ISettings _settings;
        private readonly string _medicareSyncCustomSettingsPath;
        private readonly IPhysicianEvaluationRepository _physicianEvaluationRepsoitory;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly IEventRepository _eventRepository;


        public SyncCustomerResultPollingAgent(ILogManager logManager, ICustomSettingManager customSettingManager, ISettings settings,
            ICustomerRepository customerRepository, IMedicareApiService medicareApiService, IOrganizationRepository organizationRepository,
            IKynLabValuesRepository kyaLabValuesRepository,IPhysicianEvaluationRepository physicianEvaluationRepository,
            IOrganizationRoleUserRepository organizationRoleUserRepository, IEventRepository eventRepository)
        {
            _logger = logManager.GetLogger("SyncCustomerResultPollingAgent");
            _customSettingManager = customSettingManager;
            _settings = settings;
            _customerRepository = customerRepository;
            _medicareApiService = medicareApiService;
            _organizationRepository = organizationRepository;
            _kyaLabValuesRepository = kyaLabValuesRepository;
            _medicareSyncCustomSettingsPath = settings.MedicareSyncCustomSettingsPath;
            _physicianEvaluationRepsoitory = physicianEvaluationRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _eventRepository = eventRepository;
        }
        /// <summary>
        /// This can be rerun any time. The service updates the last run time and will continue 
        /// </summary>
        public void Sync()
        {
            try
            {
                if (!_settings.SyncWithHra)
                {
                    _logger.Info("Syncing with HRA is off ");
                    return;
                }
                //get all tags for IsHealthPlan is true
                var tags = _organizationRepository.GetMedicareSites().Where(x => x.ShowHraQuestionnaire);
                if (tags != null && tags.Any())
                {
                    foreach (var tag in tags)
                    {
                        var newLastTransactionDate = DateTime.Now; //   use the time when exporting for this tag starts, as start date for next day.
                        _logger.Info("Medicare CustomerResult Sync for tag : " + tag.Alias);
                        var path = _medicareSyncCustomSettingsPath + "MedicareCustomerResultSync" + tag.Alias + ".xml";
                        var customSettings = _customSettingManager.Deserialize(path);

                        if (customSettings == null || !customSettings.LastTransactionDate.HasValue)
                        {
                            customSettings = new CustomSettings { LastTransactionDate = DateTime.Now.AddHours(-2) };
                        }

                        if (customSettings.LastTransactionDate != null)
                        {
                            var exportFromTime = customSettings.LastTransactionDate.Value;
                            var customerIds = _customerRepository.GetRecentResultUpdatedForMedicareSync(exportFromTime, tag.Alias).ToArray();
                            if (customerIds.Any())
                            {
                                var events = customerIds.Select(x => x.EventId).Distinct().ToArray();
                                var eventIdsWithMammogramTest = _customerRepository.GetEventWithTest(events, tag.Alias, (long)TestType.Mammogram).ToArray();
                                var eventIdsWithEchocardiogram = _customerRepository.GetEventWithTest(events, tag.Alias, (long)TestType.AwvEcho).ToArray();
                                var eventIdsWithAwvLipid = _customerRepository.GetEventWithTest(events, tag.Alias, (long)TestType.AwvLipid).ToArray();
                                var eventIdsWithAwvSpiro = _customerRepository.GetEventWithTest(events, tag.Alias, (long)TestType.AwvSpiro).ToArray();
                                var eventIdsWithDiabeticRetinopathy = _customerRepository.GetEventWithTest(events, tag.Alias, (long)TestType.DiabeticRetinopathy).ToArray();
                                var eventIdsWithUrineMicroalbumin = _customerRepository.GetEventWithTest(events, tag.Alias, (long)TestType.UrineMicroalbumin).ToArray();
                                var eventIdsWithAwvEkg = _customerRepository.GetEventWithTest(events, tag.Alias, (long)TestType.AwvEkg).ToArray();
                                var eventIdsWithAwvHba1C = _customerRepository.GetEventWithTest(events, tag.Alias, (long)TestType.AwvHBA1C).ToArray();
                                var eventIdsWithAwvAaa = _customerRepository.GetEventWithTest(events, tag.Alias, (long)TestType.AwvAAA).ToArray();
                                var eventIdsWithAwvAbi = _customerRepository.GetEventWithTest(events, tag.Alias, (long)TestType.AwvABI).ToArray();
                                var eventIdsWithQuantaFloAbi = _customerRepository.GetEventWithTest(events, tag.Alias, (long)TestType.QuantaFloABI).ToArray();
                                var eventIdsWithLead = _customerRepository.GetEventWithTest(events, tag.Alias, (long)TestType.Lead).ToArray();
                                var eventIdsWithBp = _customerRepository.GetEventWithTest(events, tag.Alias, (long)TestType.Hypertension).ToArray();
                                var eventList = _eventRepository.GetEvents(events).ToArray();
                                //var eventIdsWithMonoFilament = _customerRepository.GetEventWithTest(events, tag.Alias, (long)TestType.Monofilament).ToArray();
                                const int pageSize = 25;
                                var totalPages = Math.Ceiling((double)(customerIds.Count()) / pageSize);
                                for (int i = 0; i < totalPages; i++)
                                {
                                    var currentList = customerIds.Skip(i * pageSize).Take(pageSize).ToArray();
                                    try
                                    {
                                        foreach (var medicareResultEditModel in currentList)
                                        {
                                            var eventData = eventList.First(e => e.Id == medicareResultEditModel.EventId);
                                            var isNewResultFlow = eventData.EventDate >= _settings.ResultFlowChangeDate;

                                            var evaluatingPhysicians = _physicianEvaluationRepsoitory.GetPhysicianEvaluation(medicareResultEditModel.EventCustomerId);
                                            if (evaluatingPhysicians != null)
                                            {
                                                var primaryEvalRecord = evaluatingPhysicians != null ? evaluatingPhysicians.Where(p => p.IsPrimaryEvaluator).OrderByDescending(p => p.EvaluationEndTime ?? p.EvaluationStartTime).FirstOrDefault() : null;

                                                var primaryPhysicianId = primaryEvalRecord != null ? primaryEvalRecord.PhysicianId : 0;
                                                var overreadPhysicianId = primaryEvalRecord != null ? evaluatingPhysicians.Where(p => !p.IsPrimaryEvaluator && p.EvaluationStartTime > primaryEvalRecord.EvaluationStartTime).OrderByDescending(
                                                    p => p.EvaluationEndTime ?? p.EvaluationStartTime).Select(p => p.PhysicianId).FirstOrDefault() : 0;
                                                medicareResultEditModel.PhysicianOruId= overreadPhysicianId > 0 ? overreadPhysicianId : primaryPhysicianId;

                                            }
                                         


                                            if (eventIdsWithBp.Contains(medicareResultEditModel.EventId)) //1
                                            {
                                                // Blood Pressure Evaluation Test or  Hypertension
                                                var testResultRepository = new HypertensionTestRepository();
                                                var aaaTestResult = testResultRepository.GetTestResults(medicareResultEditModel.CustomerId, medicareResultEditModel.EventId, isNewResultFlow);
                                                var aaaTest = ((Core.Medical.Domain.HypertensionTestResult)aaaTestResult);
                                                if (aaaTest != null && aaaTest.TestNotPerformed == null &&
                                                    aaaTest.UnableScreenReason == null)
                                                {
                                                    medicareResultEditModel.BpReading = new MedicareResultEditModel.Bp();
                                                    medicareResultEditModel.BpReading.Systolic = aaaTest.Systolic != null ? aaaTest.Systolic.Reading : null;
                                                    medicareResultEditModel.BpReading.Diastolic = aaaTest.Diastolic != null ? aaaTest.Diastolic.Reading : null;
                                                }
                                            }
                                            if (eventIdsWithAwvAaa.Contains(medicareResultEditModel.EventId)) //1
                                            {
                                                // Update the AAA result 
                                                var testResultRepository = new AwvAaaTestRepository();
                                                var aaaTestResult = testResultRepository.GetTestResults(medicareResultEditModel.CustomerId, medicareResultEditModel.EventId, isNewResultFlow);
                                                var aaaTest = ((Core.Medical.Domain.AwvAaaTestResult)aaaTestResult);
                                                if (aaaTest != null && aaaTest.Finding != null && aaaTest.TestNotPerformed == null &&
                                                    aaaTest.UnableScreenReason == null)
                                                {
                                                    medicareResultEditModel.AaaResult = new MedicareResultEditModel.AaaReadings();
                                                    medicareResultEditModel.AaaResult.AortaSize = aaaTest.Finding != null ? aaaTest.Finding.Label : null;
                                                    medicareResultEditModel.AaaResult.AorticDissection = aaaTest.AorticDissection != null && aaaTest.AorticDissection.Reading;
                                                    medicareResultEditModel.AaaResult.Plaque = aaaTest.Plaque != null && aaaTest.Plaque.Reading;
                                                    medicareResultEditModel.AaaResult.Thrombus = aaaTest.Thrombus != null && aaaTest.Thrombus.Reading;

                                                    if (aaaTest.IncidentalFindings != null)
                                                    {
                                                        foreach (var standardFinding in aaaTest.IncidentalFindings)
                                                        {
                                                            if (standardFinding.Label == "Aortic Stenosis")
                                                            {
                                                                medicareResultEditModel.AaaResult.AorticStenosis = true;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            if (eventIdsWithAwvAbi.Contains(medicareResultEditModel.EventId))//2
                                            {
                                                // AwvAbi 
                                                var testResultRepository = new AwvAbiTestRepository();
                                                var padTestResult = testResultRepository.GetTestResults(medicareResultEditModel.CustomerId, medicareResultEditModel.EventId, isNewResultFlow);
                                                var aaaTest = ((Core.Medical.Domain.AwvAbiTestResult)padTestResult);
                                                if (aaaTest != null && aaaTest.Finding != null && aaaTest.TestNotPerformed == null &&
                                                    aaaTest.UnableScreenReason == null)
                                                {
                                                    medicareResultEditModel.PadReading = new MedicareResultEditModel.PadTestReadings();
                                                    medicareResultEditModel.PadReading.Finding = aaaTest.Finding.Label;

                                                }
                                            }
                                            if (eventIdsWithQuantaFloAbi.Contains(medicareResultEditModel.EventId))//3
                                            {
                                                // QuantaFlo Abi
                                                var testResultRepository = new QuantaFloABITestRepository();
                                                var padTestResult = testResultRepository.GetTestResults(medicareResultEditModel.CustomerId, medicareResultEditModel.EventId, isNewResultFlow);
                                                var aaaTest = ((Core.Medical.Domain.QuantaFloABITestResult)padTestResult);
                                                if (aaaTest != null && aaaTest.Finding != null && aaaTest.TestNotPerformed == null &&
                                                    aaaTest.UnableScreenReason == null)
                                                {
                                                    medicareResultEditModel.QuantaFloReading = new MedicareResultEditModel.QuantaFloReadings();
                                                    medicareResultEditModel.QuantaFloReading.Finding = aaaTest.Finding.Label;

                                                }
                                            }
                                            if (eventIdsWithLead.Contains(medicareResultEditModel.EventId))//5
                                            {
                                                // Lead  
                                                var testResultRepository = new LeadTestRepository();
                                                var leadTestResult = testResultRepository.GetTestResults(medicareResultEditModel.CustomerId, medicareResultEditModel.EventId, isNewResultFlow);
                                                var leadTest = ((Core.Medical.Domain.LeadTestResult)leadTestResult);
                                                if (leadTest != null && leadTest.TestNotPerformed == null &&
                                                    leadTest.UnableScreenReason == null)
                                                {
                                                    medicareResultEditModel.LeadReading = new MedicareResultEditModel.LeadReadings();
                                                    if (leadTest.LeftResultReadings != null)
                                                    {
                                                        medicareResultEditModel.LeadReading.LNoVisualPlaque = leadTest.LeftResultReadings.NoVisualPlaque != null && leadTest.LeftResultReadings.NoVisualPlaque.Reading.HasValue && leadTest.LeftResultReadings.NoVisualPlaque.Reading.Value;
                                                        medicareResultEditModel.LeadReading.LVisuallyDemonstratedPlaque = leadTest.LeftResultReadings.VisuallyDemonstratedPlaque != null && leadTest.LeftResultReadings.VisuallyDemonstratedPlaque.Reading.HasValue && leadTest.LeftResultReadings.VisuallyDemonstratedPlaque.Reading.Value;
                                                        medicareResultEditModel.LeadReading.LModerateStenosis = leadTest.LeftResultReadings.ModerateStenosis != null && leadTest.LeftResultReadings.ModerateStenosis.Reading.HasValue && leadTest.LeftResultReadings.ModerateStenosis.Reading.Value;
                                                        medicareResultEditModel.LeadReading.LPossibleOcclusion = leadTest.LeftResultReadings.PossibleOcclusion != null && leadTest.LeftResultReadings.PossibleOcclusion.Reading.HasValue && leadTest.LeftResultReadings.PossibleOcclusion.Reading.Value;

                                                    }
                                                    if (leadTest.LowVelocityLeft != null)
                                                    {
                                                        medicareResultEditModel.LeadReading.LowVelocityLeft = true;
                                                    }
                                                    if (leadTest.RightResultReadings != null)
                                                    {
                                                        medicareResultEditModel.LeadReading.RNoVisualPlaque = leadTest.RightResultReadings.NoVisualPlaque != null && leadTest.RightResultReadings.NoVisualPlaque.Reading.HasValue && leadTest.RightResultReadings.NoVisualPlaque.Reading.Value;
                                                        medicareResultEditModel.LeadReading.RVisuallyDemonstratedPlaque = leadTest.RightResultReadings.VisuallyDemonstratedPlaque != null && leadTest.RightResultReadings.VisuallyDemonstratedPlaque.Reading.HasValue && leadTest.RightResultReadings.VisuallyDemonstratedPlaque.Reading.Value;
                                                        medicareResultEditModel.LeadReading.RModerateStenosis = leadTest.RightResultReadings.ModerateStenosis != null && leadTest.RightResultReadings.ModerateStenosis.Reading.HasValue && leadTest.RightResultReadings.ModerateStenosis.Reading.Value;
                                                        medicareResultEditModel.LeadReading.RPossibleOcclusion = leadTest.RightResultReadings.PossibleOcclusion != null && leadTest.RightResultReadings.PossibleOcclusion.Reading.HasValue && leadTest.RightResultReadings.PossibleOcclusion.Reading.Value;

                                                    }
                                                    if (leadTest.LowVelocityRight != null)
                                                    {
                                                        medicareResultEditModel.LeadReading.LowVelocityRight = true;
                                                    }
                                                }
                                            }

                                            if (eventIdsWithMammogramTest.Contains(medicareResultEditModel.EventId))
                                            {
                                                // Update the mammogram result 
                                                var testResultRepository = new MammogramTestRepository();
                                                var mammogramTestResult = testResultRepository.GetTestResults(medicareResultEditModel.CustomerId, medicareResultEditModel.EventId, isNewResultFlow);
                                                var mamoTest = ((Core.Medical.Domain.MammogramTestResult)mammogramTestResult);
                                                if (mamoTest != null && mamoTest.Finding != null && mamoTest.TestNotPerformed == null && mamoTest.UnableScreenReason == null)
                                                    medicareResultEditModel.MammogramReading = mamoTest.Finding.Label;
                                            }
                                            if (eventIdsWithAwvSpiro.Contains(medicareResultEditModel.EventId))
                                            {
                                                var testResultRepository = new AwvSpiroTestRepository();
                                                var awvSpiroTestResult = testResultRepository.GetTestResults(medicareResultEditModel.CustomerId, medicareResultEditModel.EventId, isNewResultFlow);
                                                if (awvSpiroTestResult != null && awvSpiroTestResult.TestNotPerformed == null && awvSpiroTestResult.UnableScreenReason == null)
                                                {
                                                    if (awvSpiroTestResult.ResultStatus != null)
                                                        medicareResultEditModel.AwvSpiroStateNumber = (int)awvSpiroTestResult.ResultStatus.StateNumber;
                                                    var spirotest = ((Core.Medical.Domain.AwvSpiroTestResult)awvSpiroTestResult);
                                                    if (spirotest.Finding != null)
                                                        medicareResultEditModel.AwvSpiroFindingLabel = spirotest.Finding.Label;
                                                    if (spirotest.Obstructive != null)
                                                        medicareResultEditModel.AwvSpiroObstructiveLabel = spirotest.Obstructive.Label.ToString();
                                                }
                                            }
                                            //if (eventIdsWithMonoFilament.Contains(medicareResultEditModel.EventId))
                                            //{
                                            //    var testResultRepository = new MonofilamentTestRepository();
                                            //    var monoTestResult = testResultRepository.GetTestResults(medicareResultEditModel.CustomerId, medicareResultEditModel.EventId);
                                            //    if (monoTestResult != null && monoTestResult.ResultStatus != null)
                                            //    {
                                            //        medicareResultEditModel.MonoFilamentStateNumber = (int)monoTestResult.ResultStatus.StateNumber;
                                            //    }
                                            //}
                                            if (eventIdsWithEchocardiogram.Contains(medicareResultEditModel.EventId))
                                            {
                                                var testResultRepository = new AwvEchocardiogramTestRepository();
                                                var awvEchoTestResult = testResultRepository.GetTestResults(medicareResultEditModel.CustomerId, medicareResultEditModel.EventId, isNewResultFlow);
                                                if (awvEchoTestResult != null && awvEchoTestResult.TestNotPerformed == null && awvEchoTestResult.UnableScreenReason == null)
                                                {
                                                    try
                                                    {

                                                        if (awvEchoTestResult != null && awvEchoTestResult.ResultStatus != null)
                                                            medicareResultEditModel.AwvEchoStateNumber = (int)awvEchoTestResult.ResultStatus.StateNumber;
                                                        var echocartest = ((Core.Medical.Domain.AwvEchocardiogramTestResult)awvEchoTestResult);

                                                        medicareResultEditModel.AwvEchoFindingLabel = echocartest.EstimatedEjactionFraction != null ? echocartest.EstimatedEjactionFraction.Label : null;
                                                        medicareResultEditModel.EchocardiogramReading = new MedicareResultEditModel.EchocardiogramReadings();

                                                        if (echocartest.EstimatedEjactionFraction != null)
                                                        {
                                                            medicareResultEditModel.EchocardiogramReading.EstimatedEjactionFractionMin = echocartest.EstimatedEjactionFraction.MinValue;
                                                            medicareResultEditModel.EchocardiogramReading.EstimatedEjactionFractionMax = echocartest.EstimatedEjactionFraction.MaxValue;
                                                        }
                                                        //Aortic
                                                        medicareResultEditModel.EchocardiogramReading.Aortic = echocartest.Aortic != null && echocartest.Aortic.Reading;
                                                        if (echocartest.AorticMorphology != null)
                                                        {
                                                            foreach (var standardFinding in echocartest.AorticMorphology)
                                                            {
                                                                if (standardFinding.Label == "Stenosis")
                                                                {
                                                                    medicareResultEditModel.EchocardiogramReading.AorticStenosis = true;
                                                                }
                                                            }
                                                        }
                                                        var aorticRegurgitation = echocartest.AorticRegurgitation != null ? echocartest.AorticRegurgitation.Label : null;
                                                        medicareResultEditModel.EchocardiogramReading.AorticRegurgitation = aorticRegurgitation != null ? (aorticRegurgitation == "Mod" ? "Moderate" : aorticRegurgitation) : null;

                                                        //Mitral
                                                        medicareResultEditModel.EchocardiogramReading.Mitral = echocartest.Mitral != null && echocartest.Mitral.Reading;
                                                        if (echocartest.MitralMorphology != null)
                                                        {
                                                            foreach (var standardFinding in echocartest.MitralMorphology)
                                                            {
                                                                if (standardFinding.Label == "Stenosis")
                                                                {
                                                                    medicareResultEditModel.EchocardiogramReading.MitralStenosis = true;
                                                                }
                                                                if (standardFinding.Label == "Mitral Prolapse")
                                                                {
                                                                    medicareResultEditModel.EchocardiogramReading.MitralProlapse = true;
                                                                }
                                                            }
                                                        }
                                                        var mitralRegurgitation = echocartest.MitralRegurgitation != null ? echocartest.MitralRegurgitation.Label : null;
                                                        medicareResultEditModel.EchocardiogramReading.MitralRegurgitation = mitralRegurgitation != null ? (mitralRegurgitation == "Mod" ? "Moderate" : mitralRegurgitation) : null;

                                                        //Pulmonic
                                                        medicareResultEditModel.EchocardiogramReading.Pulmonic = echocartest.Pulmonic != null && echocartest.Pulmonic.Reading;
                                                        var pulmonicRegurgitation = echocartest.PulmonicRegurgitation != null ? echocartest.PulmonicRegurgitation.Label : null;
                                                        medicareResultEditModel.EchocardiogramReading.PulmonicRegurgitation = pulmonicRegurgitation != null ? (pulmonicRegurgitation == "Mod" ? "Moderate" : pulmonicRegurgitation) : null;


                                                        //Tricuspid
                                                        medicareResultEditModel.EchocardiogramReading.Tricuspid = echocartest.Tricuspid != null && echocartest.Tricuspid.Reading;
                                                        medicareResultEditModel.EchocardiogramReading.HighOrGreater = echocartest.MorphologyTricuspidHighOrGreater != null && echocartest.MorphologyTricuspidHighOrGreater.Reading;
                                                        medicareResultEditModel.EchocardiogramReading.TricuspidPap = echocartest.TricuspidPap != null ? echocartest.TricuspidPap.Reading : null;
                                                        var tricuspidRegurgitation = echocartest.TricuspidRegurgitation != null ? echocartest.TricuspidRegurgitation.Label : null;
                                                        medicareResultEditModel.EchocardiogramReading.TricuspidRegurgitation = tricuspidRegurgitation != null ? (tricuspidRegurgitation == "Mod" ? "Moderate" : tricuspidRegurgitation) : null;

                                                        //DiastolicDysfunction
                                                        medicareResultEditModel.EchocardiogramReading.DiastolicDysfunction = echocartest.DiastolicDysfunction != null && echocartest.DiastolicDysfunction.Reading;
                                                        medicareResultEditModel.EchocardiogramReading.DistolicDysfunctionFinding = echocartest.DistolicDysfunctionFinding != null ? echocartest.DistolicDysfunctionFinding.Label : null;
                                                        medicareResultEditModel.EchocardiogramReading.DiastolicDysfunctionEeRatio = echocartest.DiastolicDysfunctionEeRatio != null ? echocartest.DiastolicDysfunctionEeRatio.Reading : null;

                                                        medicareResultEditModel.EchocardiogramReading.AorticRoot = echocartest.AorticRoot != null && echocartest.AorticRoot.Reading;
                                                        medicareResultEditModel.EchocardiogramReading.Sclerotic = echocartest.Sclerotic != null && echocartest.Sclerotic.Reading;
                                                        medicareResultEditModel.EchocardiogramReading.Atherosclerosis = echocartest.Atherosclerosis != null && echocartest.Atherosclerosis.Reading;
                                                        medicareResultEditModel.EchocardiogramReading.VentricularHypertrophy = echocartest.VentricularHypertrophy != null && echocartest.VentricularHypertrophy.Reading;
                                                        medicareResultEditModel.EchocardiogramReading.Arrythmia = echocartest.Arrythmia != null && echocartest.Arrythmia.Reading;
                                                        medicareResultEditModel.EchocardiogramReading.AFib = echocartest.AFib != null && echocartest.AFib.Reading;
                                                        medicareResultEditModel.EchocardiogramReading.AFlutter = echocartest.AFlutter != null && echocartest.AFlutter.Reading;

                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        _logger.Error(" error EchocardiogramReading   Customer : " + medicareResultEditModel.CustomerId + " Message: " + ex.Message + "\n stack Trace: " + ex.StackTrace);
                                                    }
                                                }
                                            }
                                            if (eventIdsWithUrineMicroalbumin.Contains(medicareResultEditModel.EventId))
                                            {
                                                var testResultRepository = new UrineMicroalbuminTestRepository();
                                                var awvUrinTestResult = testResultRepository.GetTestResults(medicareResultEditModel.CustomerId, medicareResultEditModel.EventId, isNewResultFlow);
                                                if (awvUrinTestResult != null && awvUrinTestResult.ResultStatus != null && awvUrinTestResult.TestNotPerformed == null && awvUrinTestResult.UnableScreenReason == null)
                                                {
                                                    medicareResultEditModel.AwvUrinStateNumber = (int)awvUrinTestResult.ResultStatus.StateNumber;
                                                    var urintest = ((Core.Medical.Domain.UrineMicroalbuminTestResult)awvUrinTestResult);
                                                    if (urintest != null && urintest.Finding != null)
                                                        medicareResultEditModel.AwvUrinFindingLabel = urintest.Finding.Label;
                                                }
                                            }


                                            if (eventIdsWithAwvLipid.Contains(medicareResultEditModel.EventId))
                                            {
                                                var testResultRepository = new AwvLipidTestRepository();
                                                var awvLipidTestResult = testResultRepository.GetTestResults(medicareResultEditModel.CustomerId, medicareResultEditModel.EventId, isNewResultFlow);
                                                if (awvLipidTestResult != null && awvLipidTestResult.ResultStatus != null && awvLipidTestResult.TestNotPerformed == null &&
                                                    awvLipidTestResult.UnableScreenReason == null)
                                                {
                                                    medicareResultEditModel.AwvLipidStateNumber = (int)awvLipidTestResult.ResultStatus.StateNumber;
                                                    var awvLipid = ((Core.Medical.Domain.AwvLipidTestResult)awvLipidTestResult);
                                                    if (awvLipid != null)
                                                    {
                                                        medicareResultEditModel.LipidReading = new MedicareResultEditModel.Lipid();
                                                        if (awvLipid.TotalCholestrol != null &&
                                                            awvLipid.TotalCholestrol.Finding != null)
                                                        {
                                                            medicareResultEditModel.AwvLipidTotalCholestrol = awvLipid.TotalCholestrol.Reading;
                                                            medicareResultEditModel.LipidReading.Tc = awvLipid.TotalCholestrol.Reading;
                                                        }
                                                        if (awvLipid.HDL != null && awvLipid.HDL.Finding != null)
                                                            medicareResultEditModel.LipidReading.Hdl = awvLipid.HDL.Reading;
                                                        if (awvLipid.LDL != null && awvLipid.LDL.Finding != null)
                                                            medicareResultEditModel.LipidReading.Ldl = awvLipid.LDL.Reading;
                                                        if (awvLipid.TriGlycerides != null && awvLipid.TriGlycerides.Finding != null)
                                                            medicareResultEditModel.LipidReading.Trig = awvLipid.TriGlycerides.Reading;
                                                    }
                                                }
                                            }
                                            if (eventIdsWithDiabeticRetinopathy.Contains(medicareResultEditModel.EventId))
                                            {
                                                var testResultRepository = new DiabeticRetinopathyTestRepository();
                                                var awvDrsTestResult = testResultRepository.GetTestResults(medicareResultEditModel.CustomerId, medicareResultEditModel.EventId, isNewResultFlow);
                                                if (awvDrsTestResult != null && awvDrsTestResult.ResultStatus != null && awvDrsTestResult.TestNotPerformed == null && awvDrsTestResult.UnableScreenReason == null)
                                                    medicareResultEditModel.AwvDrsStateNumber = (int)awvDrsTestResult.ResultStatus.StateNumber;
                                            }
                                            if (eventIdsWithAwvEkg.Contains(medicareResultEditModel.EventId))
                                            {
                                                var testResultRepository = new AwvEkgTestRepository();
                                                var awvEkgTestResult = testResultRepository.GetTestResults(medicareResultEditModel.CustomerId, medicareResultEditModel.EventId, isNewResultFlow);
                                                if (awvEkgTestResult != null && awvEkgTestResult.ResultStatus != null && awvEkgTestResult.TestNotPerformed == null && awvEkgTestResult.UnableScreenReason == null)
                                                    medicareResultEditModel.AwvEkgStateNumber = (int)awvEkgTestResult.ResultStatus.StateNumber;
                                            }
                                            if (eventIdsWithAwvHba1C.Contains(medicareResultEditModel.EventId))
                                            {
                                                var testResultRepository = new AwvHemaglobinTestRepository();
                                                var awvHba1CTestResult = testResultRepository.GetTestResults(medicareResultEditModel.CustomerId, medicareResultEditModel.EventId, isNewResultFlow);
                                                if (awvHba1CTestResult != null && awvHba1CTestResult.ResultStatus != null && awvHba1CTestResult.TestNotPerformed == null && awvHba1CTestResult.UnableScreenReason == null)
                                                    medicareResultEditModel.AwvHbA1CStateNumber = (int)awvHba1CTestResult.ResultStatus.StateNumber;
                                            }
                                        }
                                        _logger.Info("Medicare Customer Sync Starting  for tag: " + tag.Alias + " Page : " + (i + 1));

                                        var phyids = currentList.Where(x => x.PhysicianOruId>0).Select(x => x.PhysicianOruId).ToArray();
                                        var names = _organizationRoleUserRepository.GetNameIdPairofUsers(phyids);
                                        if (names.Any())
                                        {
                                            foreach (var medicareResultEditModel in currentList.Where(x => x.PhysicianOruId>0))
                                            {
                                                var n =names.FirstOrDefault(x => x.FirstValue == medicareResultEditModel.PhysicianOruId);
                                                if (n != null)
                                                {
                                                    medicareResultEditModel.PhysicianName = n.SecondValue;
                                                }
                                            }
                                        }

                                        var model = new MedicareResultListmodel { EhrResultEditmodels = currentList.ToList() };

                                        var result = _medicareApiService.PostAnonymous<bool>(_settings.MedicareApiUrl + MedicareApiUrl.UpdateCustomerResult, model);
                                        if (result) _logger.Info("Medicare Customer Sync for tag: " + tag.Alias + " Page : " + (i + 1));
                                    }
                                    catch (Exception exception)
                                    {
                                        _logger.Error(" error occur Medicare Customer Sync for tag: " + tag.Alias + " Customer : " + (i + 1) + " Message: " + exception.Message + "\n stack Trace: " + exception.StackTrace);
                                    }
                                }
                            }

                            var kynCustomerIds = _kyaLabValuesRepository.GetRecentKynLabValuesForMedicareSync(exportFromTime, tag.Alias).ToArray();
                            if (kynCustomerIds.Any())
                            {
                                const int pageSize = 25;
                                var totalPages = Math.Ceiling((double)(kynCustomerIds.Count()) / pageSize);
                                for (var i = 0; i < totalPages; i++)
                                {
                                    var currentList = kynCustomerIds.Skip(i * pageSize).Take(pageSize).ToArray();
                                    try
                                    {
                                        _logger.Info("Medicare Customer Sync Starting  for tag: " + tag.Alias + " Page : " + (i + 1));

                                        var model = new MedicareKynResultListmodel() { EhrResultEditmodels = currentList.ToList() };
                                        var result = _medicareApiService.PostAnonymous<bool>(_settings.MedicareApiUrl + MedicareApiUrl.UpdateCustomerKynResult, model);
                                        if (result) _logger.Info("Medicare Customer Sync for tag: " + tag.Alias + " Page : " + (i + 1));
                                    }
                                    catch (Exception exception)
                                    {
                                        _logger.Error(" error occur Medicare Customer Sync for tag: " + tag.Alias + " Customer : " + (i + 1) + " Message: " + exception.Message + "\n stack Trace: " + exception.StackTrace);
                                    }
                                }
                            }
                        }


                        _customSettingManager.SerializeandSave(path, new CustomSettings { LastTransactionDate = newLastTransactionDate });
                    }
                }
            }
            catch (Exception exception)
            {
                _logger.Error("Error occurred for SyncCustomerResultPollingAgent Message: " + exception.Message + "\n stack Trace: " + exception.StackTrace);
            }
        }
    }
}
