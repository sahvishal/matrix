using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Impl;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Medical.Repositories;
using Falcon.App.Infrastructure.Repositories.Screening;

namespace Falcon.App.Infrastructure.Service
{
    public class TestResultService
    {
        private readonly IFraminghamRiskCalculationRepository _framinghamRiskCalculationRepository;
        private readonly IFraminghamTestResultRepository _framinghamTestResultRepository;
        private readonly ISettings _settings;
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;

        public TestResultService()
        {
            _framinghamRiskCalculationRepository = new FraminghamRiskCalculationRepository();
            _framinghamTestResultRepository = new FraminghamRiskTestResultRepository();
            _settings = new Settings();
            _eventCustomerResultRepository = new EventCustomerResultRepository();
        }

        public bool IsTestPurchasedByCustomer(long eventId, long customerId, long testId)
        {
            IEventCustomerPackageTestDetailService eventCustomerPackageTestDetailService = new EventCustomerPackageTestDetailService();
            var tests = eventCustomerPackageTestDetailService.GetTestsPurchasedByCustomer(eventId, customerId);

            return tests != null && tests.Any(t => t.Id == testId);
        }

        public int GetCalculatedStandardFinding(int? reading, int testId, int? readingId, List<StandardFinding<int?>> listStandardFinding = null)
        {
            var standardFindingRepository = new StandardFindingRepository();

            if (listStandardFinding == null)
            {
                if (readingId == null)
                    listStandardFinding = standardFindingRepository.GetAllStandardFindings<int?>(testId);
                else
                    listStandardFinding = standardFindingRepository.GetAllStandardFindings<int?>(testId, readingId.Value);
            }

            return StandardFindingService.GetCalculatedStandardFinding(listStandardFinding, reading);
        }

        public int GetCalculatedStandardFinding(decimal? reading, int testId, int? readingId)
        {
            var standardFindingRepository = new StandardFindingRepository();

            List<StandardFinding<decimal?>> listStandardFinding;

            if (readingId == null)
                listStandardFinding = standardFindingRepository.GetAllStandardFindings<decimal?>(testId);
            else
                listStandardFinding = standardFindingRepository.GetAllStandardFindings<decimal?>(testId, readingId.Value);

            return StandardFindingService.GetCalculatedStandardFinding(listStandardFinding, reading);
        }

        public int GetCalculatedStandardFinding(long eventId, long customerId, decimal? reading, int testId, int readingId)
        {
            var standardFindingRepository = new StandardFindingRepository();

            List<StandardFinding<decimal?>> listStandardFinding;

            if (_settings.AwvAaaFindingChangeDate.HasValue)
            {
                var eventCustomerResult = _eventCustomerResultRepository.GetByCustomerIdAndEventId(customerId, eventId);
                if (eventCustomerResult != null && eventCustomerResult.DataRecorderMetaData.DateCreated < _settings.AwvAaaFindingChangeDate.Value)
                {

                    listStandardFinding = standardFindingRepository.GetAllStandardFindings<decimal?>(testId, readingId, _settings.AwvAaaFindingChangeDate.Value, true);
                }
                else
                {

                    listStandardFinding = standardFindingRepository.GetAllStandardFindings<decimal?>(testId, readingId, _settings.AwvAaaFindingChangeDate.Value, false);
                }
            }
            else
            {
                listStandardFinding = standardFindingRepository.GetAllStandardFindings<decimal?>(testId, readingId);
            }

            return StandardFindingService.GetCalculatedStandardFinding(listStandardFinding, reading);
        }

        public IEnumerable<long> GetMultipleCalculatedStandardFinding(int? reading, int testId, int? readingId)
        {
            var standardFindingRepository = new StandardFindingRepository();

            List<StandardFinding<int?>> listStandardFinding;

            if (readingId == null)
                listStandardFinding = standardFindingRepository.GetAllStandardFindings<int?>(testId);
            else
                listStandardFinding = standardFindingRepository.GetAllStandardFindings<int?>(testId, readingId.Value);

            return StandardFindingService.GetMulitpleCalculatedStandardFinding(listStandardFinding, reading);
        }

        public IEnumerable<long> GetMultipleCalculatedStandardFinding(decimal? reading, int testId, int? readingId)
        {
            var standardFindingRepository = new StandardFindingRepository();

            List<StandardFinding<decimal?>> listStandardFinding;

            if (readingId == null)
                listStandardFinding = standardFindingRepository.GetAllStandardFindings<decimal?>(testId);
            else
                listStandardFinding = standardFindingRepository.GetAllStandardFindings<decimal?>(testId, readingId.Value);

            return StandardFindingService.GetMulitpleCalculatedStandardFinding(listStandardFinding, reading);
        }

        public List<StandardFinding<T>> GetAllStandardFindings<T>(int testId)
        {
            //TODO: Temporary, Extract interface for this service.
            return new StandardFindingRepository().GetAllStandardFindings<T>(testId);
        }

        public List<StandardFinding<T>> GetAllStandardFindings<T>(int testId, int readingId)
        {
            //TODO: Temporary, Extract interface for this service.
            return new StandardFindingRepository().GetAllStandardFindings<T>(testId, readingId);
        }

        public long GetStandardFindingTestReadingIdForStandardFinding(int testId, int? readingId, long standardFindingId)
        {
            //TODO: Temporary, Extract interface for this service.
            return new StandardFindingRepository().GetStandardFindingTestReadingIdForStandardFinding(testId, readingId, standardFindingId);
        }

        public UnableToScreenReason GetUnableToScreenReason(long testId, long testUnableScreenReasonId)
        {
            // TODO: After entity in LLBLGEN is generated
            throw new NotImplementedException();
        }

        public byte GetTestUnableScreenReasonId(int testId, int unableScreenReasonId)
        {
            return new UnableToScreenStatusRepository().GetTestUnableScreenReasonId(testId, unableScreenReasonId);
        }

        public decimal? GetFraminghamRisk(int age, bool isGenderMale, int? totalCholestrol, int hdl, int? ldl, int systolic,
                                                            int diastolic, bool isSmoker, bool isDiabetic)
        {
            var framinghamCalculationSourceList = new FraminghamRiskCalculationRepository().GetFraminghamCalculationSource();
            int score = new FraminghamRiskCalculationService().GetScoreForCalculatingFraminghamRisk(age, isGenderMale,
                                                totalCholestrol, hdl, ldl, systolic, diastolic, isSmoker, isDiabetic, framinghamCalculationSourceList);

            return new FraminghamRiskCalculationRepository().GetFraminghamRiskforScoreRange(score, isGenderMale);
        }

        public byte ReCalculateFraminghamRisk(long customerId, bool isSmoker, bool isDiabetic)
        {
            var framinghamTestResults = _framinghamTestResultRepository.GetTestResults(customerId);

            if (framinghamTestResults == null || framinghamTestResults.Count <= 0)
                return 0;

            if (framinghamTestResults.All(framinghamTestResult => (int)framinghamTestResult.ResultStatus.StateNumber < 2 || (int)framinghamTestResult.ResultStatus.StateNumber > 4))
            {
                return
                    framinghamTestResults.Max(
                        framinghamTestResult => (byte)framinghamTestResult.ResultStatus.StateNumber);
            }

            foreach (var framinghamTestResult in framinghamTestResults)
            {
                if (!(framinghamTestResult.FraminghamRisk != null && framinghamTestResult.FraminghamRisk.Id > 0)) continue;

                if ((framinghamTestResult.TotalCholestrol == null && framinghamTestResult.LDL == null)
                    || framinghamTestResult.HDL == null)
                {
                    continue;
                }

                if ((int)framinghamTestResult.ResultStatus.StateNumber >= 2 && (int)framinghamTestResult.ResultStatus.StateNumber <= 4)
                {
                    decimal? framinghamScore = GetFraminghamRisk(framinghamTestResult.Age.Reading.Value,
                                                                 framinghamTestResult.Gender.Reading == Gender.Male
                                                                     ? true
                                                                     : false,
                                                                     framinghamTestResult.TotalCholestrol == null ? null : framinghamTestResult.TotalCholestrol.Reading,
                                                                 framinghamTestResult.HDL.Reading.Value,
                                                                  framinghamTestResult.LDL == null ? null : framinghamTestResult.LDL.Reading,
                                                                 framinghamTestResult.Systolic.Reading.Value,
                                                                 framinghamTestResult.Diastolic.Reading.Value, isSmoker,
                                                                 isDiabetic);
                    if (framinghamScore.HasValue)
                    {
                        var isPersisted = _framinghamTestResultRepository.UpdateFraminghamValue(framinghamTestResult.Id,
                                                                                          framinghamScore.Value);
                    }
                }
            }
            return default(byte);
        }

        public LipidTestResult CalculateMissingLipidValue(LipidTestResult testResult)
        {
            if (testResult == null) return null;

            if ((int)testResult.ResultStatus.StateNumber >= (int)TestResultStateNumber.PreAudit)
                return testResult;

            int outputTG, outputTC, outputHdl;
            outputTG = outputTC = outputHdl = 0;

            bool isHdlPresent, isLdlPresent, isTcPresent, isTgPresent;
            isHdlPresent = isLdlPresent = isTcPresent = isTgPresent = false;

            if (testResult.HDL != null && !string.IsNullOrEmpty(testResult.HDL.Reading))
                isHdlPresent = true;
            if (testResult.LDL != null && testResult.LDL.Reading != null)
                isLdlPresent = true;
            if (testResult.TotalCholestrol != null && !string.IsNullOrEmpty(testResult.TotalCholestrol.Reading))
                isTcPresent = true;
            if (testResult.TriGlycerides != null && !string.IsNullOrEmpty(testResult.TriGlycerides.Reading))
                isTgPresent = true;

            // TODO: To implement a proper catch block here
            try
            {
                if (!isHdlPresent && isLdlPresent && isTcPresent && isTgPresent)
                {
                    #region "Missing HDL Calculation"

                    if (int.TryParse(testResult.TriGlycerides.Reading, out outputTG) == false)
                        return testResult;

                    if (int.TryParse(testResult.TotalCholestrol.Reading, out outputTC) == false)
                        return testResult;

                    if (testResult.HDL != null)
                    {
                        testResult.HDL.Reading = Convert.ToString(outputTC - testResult.LDL.Reading.Value - Convert.ToInt32(decimal.Round((decimal)outputTG / 5, 0)));
                    }
                    else
                    {
                        testResult.HDL = new CompoundResultReading<string>()
                        {
                            Label = ReadingLabels.HDL,
                            Reading = Convert.ToString(outputTC - testResult.LDL.Reading.Value - Convert.ToInt32(decimal.Round((decimal)outputTG / 5, 0)))
                        };
                    }

                    #endregion
                }
                else if (!isLdlPresent && isHdlPresent && isTcPresent && isTgPresent)
                {
                    #region "Missing LDL Calculation"

                    if (int.TryParse(testResult.TriGlycerides.Reading, out outputTG) == false)
                        return testResult;
                    if (int.TryParse(testResult.TotalCholestrol.Reading, out outputTC) == false)
                        return testResult;
                    if (int.TryParse(testResult.HDL.Reading, out outputHdl) == false)
                        return testResult;

                    if (testResult.LDL != null)
                    {
                        testResult.LDL.Reading = outputTC - outputHdl - Convert.ToInt32(decimal.Round((decimal)outputTG / 5, 0));
                    }
                    else
                    {
                        testResult.LDL = new CompoundResultReading<int?>()
                        {
                            Label = ReadingLabels.LDL,
                            Reading = outputTC - outputHdl - Convert.ToInt32(decimal.Round((decimal)outputTG / 5, 0))
                        };
                    }

                    //testResult.LDL.Finding = new StandardFinding<int?>((new TestResultService()).
                    //                                                     GetCalculatedStandardFinding(testResult.LDL.Reading,
                    //                                                     (int)TestType.Lipid, (int)ReadingLabels.LDL));

                    //if (testResult.LDL.Finding != null)
                    //    testResult.LDL.Finding = new TestResultService().GetAllStandardFindings<int?>((int)TestType.Lipid, (int)ReadingLabels.LDL).Find(standardFinding => standardFinding.Id == testResult.LDL.Finding.Id);

                    #endregion
                }
                else if (!isTgPresent && isLdlPresent && isTcPresent && isHdlPresent)
                {
                    #region "Missing Triglyceride Calculation"

                    if (int.TryParse(testResult.TotalCholestrol.Reading, out outputTC) == false)
                        return testResult;
                    if (int.TryParse(testResult.HDL.Reading, out outputHdl) == false)
                        return testResult;

                    if (testResult.TriGlycerides != null)
                    {
                        testResult.TriGlycerides.Reading = Convert.ToString((outputTC - outputHdl - testResult.LDL.Reading.Value) * 5);
                    }
                    else
                    {
                        testResult.TriGlycerides = new CompoundResultReading<string>()
                        {
                            Label = ReadingLabels.TriGlycerides,
                            Reading = Convert.ToString((outputTC - outputHdl - testResult.LDL.Reading.Value) * 5)
                        };
                    }
                    //testResult.TriGlycerides.Finding = new StandardFinding<string>((new TestResultService()).
                    //                                                     GetCalculatedStandardFinding((int?)Convert.ToInt32(testResult.TriGlycerides.Reading),
                    //                                                     (int)TestType.Lipid, (int)ReadingLabels.TriGlycerides));
                    //if (testResult.TriGlycerides.Finding != null)
                    //    testResult.TriGlycerides.Finding = new TestResultService().GetAllStandardFindings<string>((int)TestType.Lipid, (int)ReadingLabels.TriGlycerides).Find(standardFinding => standardFinding.Id == testResult.TriGlycerides.Finding.Id);

                    #endregion
                }
                else if (!isTcPresent && isLdlPresent && isHdlPresent && isTgPresent)
                {
                    #region "Missing Total Cholestrol Calculation"

                    if (int.TryParse(testResult.TriGlycerides.Reading, out outputTG) == false)
                        return testResult;
                    if (int.TryParse(testResult.HDL.Reading, out outputHdl) == false)
                        return testResult;
                    if (testResult.TotalCholestrol != null)
                    {
                        testResult.TotalCholestrol.Reading = Convert.ToString(testResult.LDL.Reading.Value + outputHdl + Convert.ToInt32(decimal.Round((decimal)outputTG / 5, 0)));
                    }
                    else
                    {
                        testResult.TotalCholestrol = new CompoundResultReading<string>()
                        {
                            Label = ReadingLabels.TotalCholestrol,
                            Reading = Convert.ToString(testResult.LDL.Reading.Value + outputHdl + Convert.ToInt32(decimal.Round((decimal)outputTG / 5, 0)))
                        };
                    }

                    //testResult.TotalCholestrol.Finding = new StandardFinding<string>((new TestResultService()).
                    //                                                     GetCalculatedStandardFinding((int?)Convert.ToInt32(testResult.TotalCholestrol.Reading),
                    //                                                     (int)TestType.Lipid, (int)ReadingLabels.TotalCholestrol));
                    //if (testResult.TotalCholestrol.Finding != null)
                    //    testResult.TotalCholestrol.Finding = new TestResultService().GetAllStandardFindings<string>((int)TestType.Lipid, (int)ReadingLabels.TotalCholestrol).Find(standardFinding => standardFinding.Id == testResult.TotalCholestrol.Finding.Id);

                    #endregion
                }
            }
            catch
            {
                return testResult;
            }
            return testResult;
        }

        public void SaveTestResult(TestResult testResult, long eventId, long customerId, long uploadedBy, ILogger logger, ReadingSource readingSource = ReadingSource.Manual)
        {
            int tryOut = 0;
            bool exceptionRaised = true;
            TestResultRepository testResultRepository;
            const int maxTryoutCount = 2;
            var eventCustomerResultRepository = new EventCustomerResultRepository();
            var eventCustomerResult = eventCustomerResultRepository.GetByCustomerIdAndEventId(customerId, eventId);

            // SaveKynLabFastingStatus(eventId, customerId, uploadedBy, eventCustomerResult);

            do
            {
                if (tryOut > 0) Thread.Sleep(5000);
                tryOut++;
                try
                {
                    if (testResult is AAATestResult)
                    {
                        testResultRepository = new AAATestRepository(readingSource);
                    }
                    else if (testResult is AwvAaaTestResult)
                    {
                        testResultRepository = new AwvAaaTestRepository(readingSource);
                    }
                    else if (testResult is StrokeTestResult)
                    {
                        testResultRepository = new StrokeTestRepository(readingSource);
                    }
                    else if (testResult is AwvCarotidTestResult)
                    {
                        testResultRepository = new AwvCarotidTestRepository(readingSource);
                    }
                    else if (testResult is LeadTestResult)
                    {
                        testResultRepository = new LeadTestRepository(readingSource);
                    }
                    else if (testResult is LipidTestResult)
                    {
                        testResultRepository = new LipidTestRepository(readingSource);
                        if (testResult.TestPerformedExternally == null)
                            SaveKynLabValues(testResult as LipidTestResult, customerId, eventId, uploadedBy);
                    }
                    else if (testResult is AwvLipidTestResult)
                    {
                        testResultRepository = new AwvLipidTestRepository(readingSource);
                        if (testResult.TestPerformedExternally == null)
                            SaveKynLabValuesForAwvLipid(testResult as AwvLipidTestResult, customerId, eventId, uploadedBy);
                    }
                    else if (testResult is AwvGlucoseTestResult)
                    {
                        testResultRepository = new AwvGlucoseTestRepository(readingSource);
                        if (testResult.TestPerformedExternally == null)
                            SaveKynLabValuesForAwvGlucose(testResult as AwvGlucoseTestResult, customerId, eventId, uploadedBy);
                    }
                    else if (testResult is PADTestResult)
                    {
                        testResultRepository = new PadTestRepository(readingSource);
                    }
                    else if (testResult is AwvAbiTestResult)
                    {
                        testResultRepository = new AwvAbiTestRepository(readingSource);
                    }
                    else if (testResult is ASITestResult)
                    {
                        testResultRepository = new ASITestRepository(readingSource);
                    }
                    else if (testResult is EchocardiogramTestResult)
                    {
                        testResultRepository = new EchocardiogramTestRepository(readingSource);
                    }
                    else if (testResult is EKGTestResult)
                    {
                        testResultRepository = new EKGTestRepository(readingSource);
                    }
                    else if (testResult is AwvEkgTestResult)
                    {
                        testResultRepository = new AwvEkgTestRepository(readingSource);
                    }
                    else if (testResult is AwvEkgIppeTestResult)
                    {
                        testResultRepository = new AwvEkgIppeTestRepository(readingSource);
                    }
                    else if (testResult is ImtTestResult)
                    {
                        testResultRepository = new ImtTestRepository(readingSource);
                    }
                    else if (testResult is PulmonaryFunctionTestResult)
                    {
                        testResultRepository = new PulmonaryFunctionTestRepository(readingSource);
                    }
                    else if (testResult is OsteoporosisTestResult)
                    {
                        testResultRepository = new OsteoporosisTestRepository(readingSource);
                    }
                    else if (testResult is AwvBoneMassTestResult)
                    {
                        testResultRepository = new AwvBoneMassTestRepository(readingSource);
                    }
                    else if (testResult is SpiroTestResult)
                    {
                        testResultRepository = new SpiroTestRepository(readingSource);
                    }
                    else if (testResult is AwvSpiroTestResult)
                    {
                        testResultRepository = new AwvSpiroTestRepository(readingSource);
                    }
                    else if (testResult is PpAaaTestResult)
                    {
                        testResultRepository = new PpAaaTestRepository(readingSource);
                    }
                    else if (testResult is PpEchocardiogramTestResult)
                    {
                        testResultRepository = new PpEchocardiogramTestRepository(readingSource);
                    }
                    else if (testResult is AwvTestResult)
                    {
                        testResultRepository = new AwvTestRepository(readingSource);
                    }
                    else if (testResult is MedicareTestResult)
                    {
                        testResultRepository = new MedicareTestRepository(readingSource);
                    }
                    else if (testResult is AwvSubsequentTestResult)
                    {
                        testResultRepository = new AwvSubsequentTestRepository(readingSource);
                    }
                    else if (testResult is HemaglobinA1CTestResult)
                    {
                        testResultRepository = new HemaglobinTestRepository(readingSource);
                        if (testResult.TestPerformedExternally == null)
                            SaveHemaglobinA1C(testResult as HemaglobinA1CTestResult, customerId, eventId, uploadedBy, eventCustomerResult);
                    }
                    else if (testResult is AwvHemaglobinTestResult)
                    {
                        testResultRepository = new AwvHemaglobinTestRepository(readingSource);
                        if (testResult.TestPerformedExternally == null)
                            SaveAwvHemaglobin(testResult as AwvHemaglobinTestResult, customerId, eventId, uploadedBy, eventCustomerResult);
                    }
                    else if (testResult is HemoglobinTestResult)
                    {
                        testResultRepository = new HemoglobinTestRepository(readingSource);
                    }
                    else if (testResult is ThyroidTestResult)
                    {
                        testResultRepository = new ThyroidTestRepository(readingSource);
                        if (testResult.TestPerformedExternally == null)
                        {
                            var thyroidTestResult = testResult as ThyroidTestResult;
                            if (thyroidTestResult != null && thyroidTestResult.TSHSCR != null && !string.IsNullOrEmpty(thyroidTestResult.TSHSCR.Reading))
                                SaveEventCustomerResultBloodLab(eventCustomerResult.Id, true, uploadedBy);
                        }
                    }
                    else if (testResult is PsaTestResult)
                    {
                        testResultRepository = new PsaTestRepository(readingSource);
                        if (testResult.TestPerformedExternally == null)
                        {
                            var psaTestResult = testResult as PsaTestResult;
                            if (psaTestResult != null && psaTestResult.PSASCR != null && !string.IsNullOrEmpty(psaTestResult.PSASCR.Reading))
                                SaveEventCustomerResultBloodLab(eventCustomerResult.Id, true, uploadedBy);
                        }
                    }
                    else if (testResult is CrpTestResult)
                    {
                        testResultRepository = new CrpTestRepository(readingSource);
                        if (testResult.TestPerformedExternally == null)
                        {
                            var crpTestResult = testResult as CrpTestResult;
                            if (crpTestResult != null && crpTestResult.LCRP != null && !string.IsNullOrEmpty(crpTestResult.LCRP.Reading))
                                SaveEventCustomerResultBloodLab(eventCustomerResult.Id, true, uploadedBy);
                        }
                    }
                    else if (testResult is TestosteroneTestResult)
                    {
                        testResultRepository = new TestosteroneTestRepository(readingSource);
                        if (testResult.TestPerformedExternally == null)
                        {
                            var testosteroneTestResult = testResult as TestosteroneTestResult;
                            if (testosteroneTestResult != null && testosteroneTestResult.TESTSCRE != null && !string.IsNullOrEmpty(testosteroneTestResult.TESTSCRE.Reading))
                                SaveEventCustomerResultBloodLab(eventCustomerResult.Id, true, uploadedBy);
                        }
                    }
                    else if (testResult is HearingTestResult)
                    {
                        testResultRepository = new HearingTestRepository(readingSource);
                    }
                    else if (testResult is VisionTestResult)
                    {
                        testResultRepository = new VisionTestRepository(readingSource);
                    }
                    else if (testResult is GlaucomaTestResult)
                    {
                        testResultRepository = new GlaucomaTestRepository(readingSource);
                    }
                    else if (testResult is HcpAaaTestResult)
                    {
                        testResultRepository = new HcpAaaTestRepository(readingSource);
                    }
                    else if (testResult is HcpCarotidTestResult)
                    {
                        testResultRepository = new HcpCarotidTestRepository(readingSource);
                    }
                    else if (testResult is HcpEchocardiogramTestResult)
                    {
                        testResultRepository = new HcpEchocardiogramTestRepository(readingSource);
                    }
                    else if (testResult is AwvEchocardiogramTestResult)
                    {
                        testResultRepository = new AwvEchocardiogramTestRepository(readingSource);
                    }
                    else if (testResult is DiabetesTestResult)
                    {
                        testResultRepository = new DiabetesTestRepository(readingSource);
                        if (testResult.TestPerformedExternally == null)
                            SaveKynLabValuesForDiabetes(testResult as DiabetesTestResult, customerId, eventId, uploadedBy);
                    }
                    else if (testResult is CholesterolTestResult)
                    {
                        testResultRepository = new CholesterolTestRepository(readingSource);
                        if (testResult.TestPerformedExternally == null)
                            SaveKynLabValuesForCholesterol(testResult as CholesterolTestResult, customerId, eventId, uploadedBy);
                    }
                    else if (testResult is HPyloriTestResult)
                    {
                        testResultRepository = new HPyloriTestRepository(readingSource);
                    }
                    else if (testResult is IFOBTTestResult)
                    {
                        testResultRepository = new IFOBTTestRepository(readingSource);
                    }
                    else if (testResult is MenBloodPanelTestResult)
                    {
                        testResultRepository = new MenBloodPanelTestRepository(readingSource);
                        if (testResult.TestPerformedExternally == null)
                        {
                            var menBloodPanelTestResult = testResult as MenBloodPanelTestResult;
                            if (menBloodPanelTestResult != null &&
                                ((menBloodPanelTestResult.LCRP != null && !string.IsNullOrEmpty(menBloodPanelTestResult.LCRP.Reading))
                                 || (menBloodPanelTestResult.PSASCR != null && !string.IsNullOrEmpty(menBloodPanelTestResult.PSASCR.Reading))
                                 || (menBloodPanelTestResult.TESTSCRE != null && !string.IsNullOrEmpty(menBloodPanelTestResult.TESTSCRE.Reading))))
                            {
                                SaveEventCustomerResultBloodLab(eventCustomerResult.Id, true, uploadedBy);
                            }
                        }


                    }
                    else if (testResult is WomenBloodPanelTestResult)
                    {
                        testResultRepository = new WomenBloodPanelTestRepository(readingSource);
                        if (testResult.TestPerformedExternally == null)
                        {

                            var womenBloodPanelTestResult = testResult as WomenBloodPanelTestResult;
                            if (womenBloodPanelTestResult != null &&
                                ((womenBloodPanelTestResult.LCRP != null && !string.IsNullOrEmpty(womenBloodPanelTestResult.LCRP.Reading))
                                 || (womenBloodPanelTestResult.TSHSCR != null && !string.IsNullOrEmpty(womenBloodPanelTestResult.TSHSCR.Reading))
                                 || (womenBloodPanelTestResult.VitD != null && !string.IsNullOrEmpty(womenBloodPanelTestResult.VitD.Reading))))
                            {
                                SaveEventCustomerResultBloodLab(eventCustomerResult.Id, true, uploadedBy);
                            }

                            SaveEventCustomerResultBloodLab(eventCustomerResult.Id, true, uploadedBy);
                        }
                    }
                    else if (testResult is VitaminDTestResult)
                    {
                        testResultRepository = new VitaminDTestRepository(readingSource);
                        if (testResult.TestPerformedExternally == null)
                        {
                            var vitaminTestResult = testResult as VitaminDTestResult;
                            if (vitaminTestResult != null && vitaminTestResult.VitD != null && !string.IsNullOrEmpty(vitaminTestResult.VitD.Reading))
                                SaveEventCustomerResultBloodLab(eventCustomerResult.Id, true, uploadedBy);
                        }

                    }
                    else if (testResult is HypertensionTestResult)
                    {
                        testResultRepository = new HypertensionTestRepository(readingSource);
                        if (testResult.TestPerformedExternally == null)
                        {
                            SaveKynLabValuesForHypertension(testResult as HypertensionTestResult, customerId, eventId, uploadedBy, eventCustomerResult);
                            SaveBasicBiometricForHypertension(testResult as HypertensionTestResult, customerId, eventId, uploadedBy, eventCustomerResult);
                        }

                    }
                    else if (testResult is DiabeticRetinopathyTestResult)
                    {
                        testResultRepository = new DiabeticRetinopathyTestRepository(readingSource);
                    }
                    else if (testResult is EAwvTestResult)
                    {
                        testResultRepository = new EAwvTestRepository(readingSource);
                    }
                    else if (testResult is DiabetesFootExamTestResult)
                    {
                        testResultRepository = new DiabetesFootExamTestRepository(readingSource);
                    }
                    else if (testResult is RinneWeberHearingTestResult)
                    {
                        testResultRepository = new RinneWeberHearingTestRepository(readingSource);
                    }
                    else if (testResult is MonofilamentTestResult)
                    {
                        testResultRepository = new MonofilamentTestRepository(readingSource);
                    }
                    else if (testResult is DiabeticNeuropathyTestResult)
                    {
                        testResultRepository = new DiabeticNeuropathyTestRepository(readingSource);
                    }
                    else if (testResult is FloChecABITestResult)
                    {
                        testResultRepository = new FloChecABITestRepository(readingSource);
                    }
                    else if (testResult is QualityMeasuresTestResult)
                    {
                        testResultRepository = new QualityMeasuresTestRepository(readingSource);
                    }
                    else if (testResult is Phq9TestResult)
                    {
                        testResultRepository = new Phq9TestRepository(readingSource);
                    }
                    else if (testResult is FocAttestationTestResult)
                    {
                        testResultRepository = new FocAttestationTestRepository(readingSource);
                    }
                    else if (testResult is MammogramTestResult)
                    {
                        testResultRepository = new MammogramTestRepository(readingSource);
                    }
                    else if (testResult is UrineMicroalbuminTestResult)
                    {
                        testResultRepository = new UrineMicroalbuminTestRepository(readingSource);
                    }
                    else if (testResult is FluShotTestResult)
                    {
                        testResultRepository = new FluShotTestRepository(readingSource);
                    }
                    else if (testResult is AwvFluShotTestResult)
                    {
                        testResultRepository = new AwvFluShotTestRepository(readingSource);
                    }
                    else if (testResult is PneumococcalTestResult)
                    {
                        testResultRepository = new PneumococcalTestRepository(readingSource);
                    }
                    else if (testResult is ChlamydiaTestResult)
                    {
                        testResultRepository = new ChlamydiaTestRepository(readingSource);
                    }
                    else if (testResult is QuantaFloABITestResult)
                    {
                        testResultRepository = new QuantaFloABITestRepository(readingSource);
                    }
                    else if (testResult is DpnTestResult)
                    {
                        testResultRepository = new DpnTestRepository(readingSource);
                    }
                    else if (testResult is MyBioAssessmentTestResult)
                    {
                        testResultRepository = new MyBioAssessmentTestRepository(readingSource);
                        if (testResult.TestPerformedExternally == null)
                            SaveKynLabValues(testResult as MyBioAssessmentTestResult, customerId, eventId, uploadedBy);
                    }
                    else if (testResult is LiverTestResult)
                    {
                        testResultRepository = new LiverTestRepository(readingSource);
                    }
                    else if (testResult is FocTestResult)
                    {
                        testResultRepository = new FocTestRepository(readingSource);
                    }
                    else if (testResult is CsTestResult)
                    {
                        testResultRepository = new CsTestRepository(readingSource);
                    }
                    else if (testResult is QvTestResult)
                    {
                        testResultRepository = new QvTestRepository(readingSource);
                    }
                    else
                    {
                        testResultRepository = new TestResultRepository(readingSource);
                    }

                    testResultRepository.SaveTestResults(testResult, customerId, eventId, uploadedBy);
                    tryOut++;
                    exceptionRaised = false;

                }
                catch (Exception ex)
                {
                    if (tryOut == maxTryoutCount)
                        logger.Error("\n\nSave failed for " + testResult.TestType + ", Customer[Id: " + customerId + "] & Event[Id: " + eventId + "]. Error: " + ex.Message + " \n\t" + ex.StackTrace);
                }

            } while (tryOut < maxTryoutCount);

            if (exceptionRaised)
            {
                throw new Exception("Exception raised while saving test data!");
            }

        }

        private void SaveKynLabValues(MyBioAssessmentTestResult testResult, long customerId, long eventId, long uploadedBy)
        {
            if (testResult != null)
            {
                var isMybioPurchased = IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.MyBioCheckAssessment);
                var isKynPurchased = IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.Kyn);
                var isHkynPurchased = IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.HKYN);

                if (isKynPurchased)
                {
                    SaveKynValues(customerId, eventId, uploadedBy, testResult.Glucose, testResult.TotalCholestrol, testResult.TriGlycerides, testResult.Hdl, testResult.Ldl, (long)TestType.Kyn);
                }

                if (isHkynPurchased)
                {
                    SaveKynValues(customerId, eventId, uploadedBy, testResult.Glucose, testResult.TotalCholestrol, testResult.TriGlycerides, testResult.Hdl, testResult.Ldl, (long)TestType.HKYN);
                }

                if (isMybioPurchased)
                {
                    SaveKynValues(customerId, eventId, uploadedBy, testResult.Glucose, testResult.TotalCholestrol, testResult.TriGlycerides, testResult.Hdl, testResult.Ldl, (long)TestType.MyBioCheckAssessment);
                }
            }

        }

        public void SaveKynLabFastingStatus(long eventId, long customerId, long uploadedBy, bool? isFasting, long eventCustomerResultId)
        {

            var isKynPurchased = IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.Kyn);
            var isHkynPurchased = IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.HKYN);
            var isMybioPurchased = IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.MyBioCheckAssessment);

            if (isKynPurchased)
            {
                SetFastingStatus(uploadedBy, isFasting, eventCustomerResultId, TestType.Kyn);
            }
            if (isHkynPurchased)
            {
                SetFastingStatus(uploadedBy, isFasting, eventCustomerResultId, TestType.HKYN);
            }
            if (isMybioPurchased)
            {
                SetFastingStatus(uploadedBy, isFasting, eventCustomerResultId, TestType.MyBioCheckAssessment);
            }
        }

        private static void SetFastingStatus(long uploadedBy, bool? isFasting, long eventCustomerResultId, TestType test)
        {
            var kynLabValueRepository = new KynLabValuesRepository();

            var kynLabValues = kynLabValueRepository.Get(eventCustomerResultId, (long)test) ??
                               new KynLabValues { EventCustomerResultId = eventCustomerResultId, TestId = (long)test };

            if (isFasting == true)
            {
                kynLabValues.FastingStatus = (long)FastingStatus.Fasting;
            }
            else
            {
                kynLabValues.FastingStatus = (long)FastingStatus.NonFasting;
            }

            kynLabValueRepository.Save(kynLabValues, uploadedBy);
        }

        private void SaveKynLabValues(LipidTestResult testResult, long customerId, long eventId, long uploadedBy)
        {
            var isKynPurchased = IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.Kyn);
            var isHkynPurchased = IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.HKYN);
            var isMyBioPurchased = IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.MyBioCheckAssessment);

            if (testResult != null)
            {
                if (isKynPurchased)
                {
                    SaveKynValues(customerId, eventId, uploadedBy, testResult.Glucose, testResult.TotalCholestrol, testResult.TriGlycerides, testResult.HDL, testResult.LDL, (long)TestType.Kyn);
                }
                if (isHkynPurchased)
                {
                    SaveKynValues(customerId, eventId, uploadedBy, testResult.Glucose, testResult.TotalCholestrol, testResult.TriGlycerides, testResult.HDL, testResult.LDL, (long)TestType.HKYN);
                }

                if (isMyBioPurchased)
                {
                    SaveKynValues(customerId, eventId, uploadedBy, testResult.Glucose, testResult.TotalCholestrol, testResult.TriGlycerides, testResult.HDL, testResult.LDL, (long)TestType.MyBioCheckAssessment);
                }
            }

        }

        private void SaveKynLabValuesForAwvLipid(AwvLipidTestResult testResult, long customerId, long eventId, long uploadedBy)
        {
            var isKynPurchased = IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.Kyn);
            var isHkynPurchased = IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.HKYN);
            var isMyBioPurchased = IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.MyBioCheckAssessment);

            if (testResult != null)
            {
                if (isKynPurchased)
                {
                    SaveKynValues(customerId, eventId, uploadedBy, null, testResult.TotalCholestrol, testResult.TriGlycerides, testResult.HDL, testResult.LDL, (long)TestType.Kyn);
                }
                if (isHkynPurchased)
                {
                    SaveKynValues(customerId, eventId, uploadedBy, null, testResult.TotalCholestrol, testResult.TriGlycerides, testResult.HDL, testResult.LDL, (long)TestType.HKYN);
                }
                if (isMyBioPurchased)
                {
                    SaveKynValues(customerId, eventId, uploadedBy, null, testResult.TotalCholestrol, testResult.TriGlycerides, testResult.HDL, testResult.LDL, (long)TestType.MyBioCheckAssessment);
                }
            }
        }

        private void SaveKynLabValuesForAwvGlucose(AwvGlucoseTestResult testResult, long customerId, long eventId, long uploadedBy)
        {
            var isKynPurchased = IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.Kyn);
            var isHkynPurchased = IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.HKYN);
            var isMyBioPurchased = IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.MyBioCheckAssessment);

            if (testResult != null)
            {
                if (isKynPurchased)
                {
                    SaveKynValues(customerId, eventId, uploadedBy, testResult.Glucose, null, null, null, null, (long)TestType.Kyn);
                }
                if (isHkynPurchased)
                {
                    SaveKynValues(customerId, eventId, uploadedBy, testResult.Glucose, null, null, null, null, (long)TestType.HKYN);
                }
                if (isMyBioPurchased)
                {
                    SaveKynValues(customerId, eventId, uploadedBy, testResult.Glucose, null, null, null, null, (long)TestType.MyBioCheckAssessment);
                }
            }

        }

        private void SaveKynLabValuesForDiabetes(DiabetesTestResult testResult, long customerId, long eventId, long uploadedBy)
        {
            var isKynPurchased = IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.Kyn);
            var isHkynPurchased = IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.HKYN);
            var isMyBioPurchased = IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.MyBioCheckAssessment);

            if (testResult != null)
            {
                if (isKynPurchased)
                {
                    SaveKynValues(customerId, eventId, uploadedBy, testResult.Glucose, null, null, null, null, (long)TestType.Kyn);
                }

                if (isHkynPurchased)
                {
                    SaveKynValues(customerId, eventId, uploadedBy, testResult.Glucose, null, null, null, null, (long)TestType.HKYN);
                }

                if (isMyBioPurchased)
                {
                    SaveKynValues(customerId, eventId, uploadedBy, testResult.Glucose, null, null, null, null, (long)TestType.MyBioCheckAssessment);
                }
            }

        }

        private void SaveKynLabValuesForCholesterol(CholesterolTestResult testResult, long customerId, long eventId, long uploadedBy)
        {
            var isKynPurchased = IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.Kyn);
            var isHkynPurchased = IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.HKYN);
            var isMyBioPurchased = IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.MyBioCheckAssessment);

            if (testResult != null)
            {
                if (isKynPurchased)
                {
                    SaveKynValues(customerId, eventId, uploadedBy, null, testResult.TotalCholesterol, testResult.TriGlycerides, testResult.HDL, testResult.LDL, (long)TestType.Kyn);
                }
                if (isHkynPurchased)
                {
                    SaveKynValues(customerId, eventId, uploadedBy, null, testResult.TotalCholesterol, testResult.TriGlycerides, testResult.HDL, testResult.LDL, (long)TestType.HKYN);
                }
                if (isMyBioPurchased)
                {
                    SaveKynValues(customerId, eventId, uploadedBy, null, testResult.TotalCholesterol, testResult.TriGlycerides, testResult.HDL, testResult.LDL, (long)TestType.MyBioCheckAssessment);
                }
            }

        }

        private void SaveKynLabValuesForHypertension(HypertensionTestResult testResult, long customerId, long eventId, long uploadedby, EventCustomerResult eventCustomerResult)
        {
            var isKynPurchased = IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.Kyn);
            var isHkynPurchased = IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.HKYN);
            var isMybioPurchased = IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.MyBioCheckAssessment);

            if (testResult != null)
            {
                if (isKynPurchased)
                {
                    SetKynLabValueForHypertesion(testResult, uploadedby, eventCustomerResult, TestType.Kyn);
                }
                if (isHkynPurchased)
                {
                    SetKynLabValueForHypertesion(testResult, uploadedby, eventCustomerResult, TestType.HKYN);
                }
                if (isMybioPurchased)
                {
                    SetKynLabValueForHypertesion(testResult, uploadedby, eventCustomerResult, TestType.MyBioCheckAssessment);
                }
            }
        }

        private static void SetKynLabValueForHypertesion(HypertensionTestResult testResult, long uploadedby, EventCustomerResult eventCustomerResult, TestType test)
        {
            var kynLabValueRepository = new KynLabValuesRepository();

            if (eventCustomerResult == null)
                return;

            var kynLabValues = kynLabValueRepository.Get(eventCustomerResult.Id, (long)test);

            if (kynLabValues == null)
                kynLabValues = new KynLabValues { EventCustomerResultId = eventCustomerResult.Id, TestId = (long)test };

            if (testResult.Systolic != null && testResult.Systolic.ReadingSource == ReadingSource.Manual)
            {
                kynLabValues.ManualSystolic = testResult.Systolic.Reading;
            }

            if (testResult.Diastolic != null && testResult.Diastolic.ReadingSource == ReadingSource.Manual)
            {
                kynLabValues.ManualDiastolic = testResult.Diastolic.Reading;
            }

            kynLabValueRepository.Save(kynLabValues, uploadedby);
        }

        private void SaveBasicBiometricForHypertension(HypertensionTestResult testResult, long customerId, long eventId, long uploadedby, EventCustomerResult eventCustomerResult)
        {
            const int systolicAbnormalValue = 140;
            const int diastolicAbnormalValue = 90;
            var basicBiometricRepository = new BasicBiometricRepository();
            var basicBiometric = basicBiometricRepository.Get(eventId, customerId);

            if (testResult == null) return;
            if (eventCustomerResult == null) return;

            if (basicBiometric == null)
            {
                basicBiometric = new BasicBiometric
                {
                    Id = eventCustomerResult.Id
                };
            }

            if (testResult.Systolic != null && testResult.Systolic.Reading.HasValue)
                basicBiometric.SystolicPressure = testResult.Systolic.Reading.Value;

            if (testResult.Diastolic != null && testResult.Diastolic.Reading.HasValue)
                basicBiometric.DiastolicPressure = testResult.Diastolic.Reading.Value;

            if (testResult.Pulse != null && testResult.Pulse.Reading.HasValue)
                basicBiometric.PulseRate = testResult.Pulse.Reading.Value;

            if (testResult.RightArmBpMeasurement != null)
                basicBiometric.IsRightArmBpMeasurement = testResult.RightArmBpMeasurement.Reading;

            basicBiometric.CreatedByOrgRoleUserId = uploadedby;
            basicBiometric.CreatedOn = DateTime.Now;

            basicBiometric.IsBloodPressureElevated = (testResult.Systolic != null && testResult.Systolic.Reading.HasValue && testResult.Systolic.Reading.Value >= systolicAbnormalValue) ||
                                    (testResult.Diastolic != null && testResult.Diastolic.Reading.HasValue && testResult.Diastolic.Reading.Value >= diastolicAbnormalValue);

            ((IRepository<BasicBiometric>)basicBiometricRepository).Save(basicBiometric);
        }

        public void SaveKynValues(long customerId, long eventId, long uploadedBy, CompoundResultReading<int?> glucose, CompoundResultReading<string> totalCholesterol, CompoundResultReading<string> triGlycerides, CompoundResultReading<string> hdl, CompoundResultReading<int?> ldl, long test)
        {
            var eventCustomerResultRepository = new EventCustomerResultRepository();
            var kynLabValueRepository = new KynLabValuesRepository();

            var eventCustomerResult = eventCustomerResultRepository.GetByCustomerIdAndEventId(customerId, eventId);
            if (eventCustomerResult == null)
                return;

            var kynLabValues = kynLabValueRepository.Get(eventCustomerResult.Id, test);
            if (kynLabValues == null)
                kynLabValues = new KynLabValues { EventCustomerResultId = eventCustomerResult.Id, TestId = test };

            if (glucose != null && glucose.ReadingSource == ReadingSource.Manual)
            {
                kynLabValues.Glucose = glucose.Reading;
            }

            if (totalCholesterol != null && totalCholesterol.ReadingSource == ReadingSource.Manual)
            {
                int s;
                kynLabValues.TotalCholesterol = int.TryParse(totalCholesterol.Reading, out s) ? s : (int?)null;
            }

            if (triGlycerides != null && triGlycerides.ReadingSource == ReadingSource.Manual)
            {
                int s;
                kynLabValues.Triglycerides = int.TryParse(triGlycerides.Reading, out s) ? s : (int?)null;
            }

            if (hdl != null && hdl.ReadingSource == ReadingSource.Manual)
            {
                int s;
                kynLabValues.Hdl = int.TryParse(hdl.Reading, out s) ? s : (int?)null;
            }

            if (hdl != null && hdl.ReadingSource == ReadingSource.Manual)
            {
                int s;
                kynLabValues.Hdl = int.TryParse(hdl.Reading, out s) ? s : (int?)null;
            }
            if (ldl != null && ldl.ReadingSource == ReadingSource.Manual)
            {
                kynLabValues.LdlCholestrol = ldl.Reading;
            }


            kynLabValueRepository.Save(kynLabValues, uploadedBy);
        }

        private void SaveEventCustomerResultBloodLab(long eventCustomerResulId, bool isNew, long updatedBy)
        {
            var eventCustomerResultBloodLabRepository = new EventCustomerResultBloodLabRepository();
            var domain = new EventCustomerResultBloodLab
            {
                EventCustomerResultId = eventCustomerResulId,
                IsFromNewLab = isNew,
                CreatedByOrgRoleUserid = updatedBy,
                DateCreated = DateTime.Now
            };

            eventCustomerResultBloodLabRepository.Save(domain);
        }

        private void SaveAwvHemaglobin(AwvHemaglobinTestResult testResult, long customerId, long eventId, long uploadedby, EventCustomerResult eventCustomerResult)
        {

            var isHkynPurchased = IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.HKYN);
            var iskynPurchased = IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.Kyn);
            var isMyBioPurchased = IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.MyBioCheckAssessment);

            if (testResult != null)
            {
                if (isHkynPurchased)
                {
                    SetAwvHemaGlobin(testResult.Hba1c, uploadedby, eventCustomerResult, TestType.HKYN);
                }
                if (iskynPurchased)
                {
                    SetAwvHemaGlobin(testResult.Hba1c, uploadedby, eventCustomerResult, TestType.Kyn);
                }
                if (isMyBioPurchased)
                {
                    SetAwvHemaGlobin(testResult.Hba1c, uploadedby, eventCustomerResult, TestType.MyBioCheckAssessment);
                }

            }

        }

        private static void SetAwvHemaGlobin(ResultReading<string> A1c, long uploadedby, EventCustomerResult eventCustomerResult, TestType test)
        {

            var kynLabValueRepository = new KynLabValuesRepository();

            if (eventCustomerResult == null)
                return;

            var kynLabValues = kynLabValueRepository.Get(eventCustomerResult.Id, (long)test);

            if (kynLabValues == null)
                kynLabValues = new KynLabValues { EventCustomerResultId = eventCustomerResult.Id, TestId = (long)test };

            if (A1c != null && A1c.ReadingSource == ReadingSource.Manual)
            {
                decimal s;
                kynLabValues.A1c = decimal.TryParse(A1c.Reading, out s) ? s : (decimal?)null;
            }

            kynLabValueRepository.Save(kynLabValues, uploadedby);

        }

        private void SaveHemaglobinA1C(HemaglobinA1CTestResult testResult, long customerId, long eventId, long uploadedby, EventCustomerResult eventCustomerResult)
        {

            var isHkynPurchased = IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.HKYN);
            var iskynPurchased = IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.Kyn);
            var isMyBioPurchased = IsTestPurchasedByCustomer(eventId, customerId, (long)TestType.MyBioCheckAssessment);

            if (testResult != null)
            {
                if (isHkynPurchased)
                {
                    SetAwvHemaGlobin(testResult.Hba1c, uploadedby, eventCustomerResult, TestType.HKYN);
                }
                if (iskynPurchased)
                {
                    SetAwvHemaGlobin(testResult.Hba1c, uploadedby, eventCustomerResult, TestType.Kyn);
                }
                if (isMyBioPurchased)
                {
                    SetAwvHemaGlobin(testResult.Hba1c, uploadedby, eventCustomerResult, TestType.MyBioCheckAssessment);
                }
            }
        }

        public bool IsTestPurchasedByCustomer(long eventcustomerId, long testId)
        {
            IEventCustomerPackageTestDetailService eventCustomerPackageTestDetailService = new EventCustomerPackageTestDetailService();
            var tests = eventCustomerPackageTestDetailService.GetTestsPurchasedByEventCustomerId(eventcustomerId);

            return tests != null && tests.Any(t => t.Id == testId);
        }
    }
}
