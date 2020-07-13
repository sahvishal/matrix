using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using DateTime = System.DateTime;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class KynHealthAssessmentFactory : IKynHealthAssessmentFactory
    {
        private const int SystolicAbnormalValue = 140;
        private const int DiastolicAbnormalValue = 90;

        public TestResult GetLipidTestResultDomain(KynHealthAssessmentEditModel model, LipidTestResult inpersistence, long uploadedby, bool isNewResultFlow)
        {
            if (!IsLipidReadingProvided(model) && inpersistence == null) return inpersistence;

            decimal? tchol = null;
            decimal? hdl = null;
            decimal? triglycerides = null;

            if (inpersistence == null)
            {
                inpersistence = new LipidTestResult
                {
                    ResultStatus = new TestResultState
                    {
                        StateNumber = isNewResultFlow ? (int)NewTestResultStateNumber.ResultEntryPartial : (int)TestResultStateNumber.ManualEntry
                    }
                };

            }

            inpersistence.TotalCholestrol = GetTotalColesterolReading(model.TotalCholesterol, ref tchol);
            inpersistence.HDL = GetHdlReading(model.HDLCholesterol, ref hdl);
            inpersistence.TriGlycerides = GetTriglyceridesReading(model.Triglycerides, ref triglycerides);
            inpersistence.TCHDLRatio = CalculateTchdlRatio(tchol, hdl, TestType.Lipid);
            inpersistence.LDL = CalculateLdlReading(hdl, tchol, triglycerides, TestType.Lipid);

            inpersistence.Glucose = GetGlucoseReading(model.Glucose);

            inpersistence.DataRecorderMetaData = SetDataRecorderMetaData(inpersistence.DataRecorderMetaData, uploadedby);
            inpersistence.ResultStatus.DataRecorderMetaData = SetDataRecorderMetaData(inpersistence.ResultStatus.DataRecorderMetaData, uploadedby);

            return inpersistence;
        }

        private bool IsLipidReadingProvided(KynHealthAssessmentEditModel model)
        {
            return !string.IsNullOrEmpty(model.TotalCholesterol) || !string.IsNullOrEmpty(model.HDLCholesterol) ||
                   !string.IsNullOrEmpty(model.Triglycerides) || model.Glucose.HasValue;
        }

        public BasicBiometric GetBasicTestResultBiometricDomain(KynHealthAssessmentEditModel model, BasicBiometric inpersistence, long uploadedby)
        {
            if (inpersistence == null)
            {
                inpersistence = new BasicBiometric
                {
                    SystolicPressure = model.SystolicPressure,
                    DiastolicPressure = model.DiastolicPressure,
                    PulseRate = model.PulseRate,
                    CreatedByOrgRoleUserId = uploadedby,
                    CreatedOn = DateTime.Now,
                    IsBloodPressureElevated = (model.SystolicPressure.HasValue && model.SystolicPressure.Value >= SystolicAbnormalValue)
                                                || (model.DiastolicPressure.HasValue && model.DiastolicPressure.Value >= DiastolicAbnormalValue)
                };
            }
            else
            {
                inpersistence.SystolicPressure = model.SystolicPressure;
                inpersistence.DiastolicPressure = model.DiastolicPressure;
                inpersistence.PulseRate = model.PulseRate;
                inpersistence.CreatedByOrgRoleUserId = uploadedby;
                inpersistence.CreatedOn = DateTime.Now;
                inpersistence.IsBloodPressureElevated = (model.SystolicPressure.HasValue && model.SystolicPressure.Value >= SystolicAbnormalValue)
                                                            || (model.DiastolicPressure.HasValue && model.DiastolicPressure.Value >= DiastolicAbnormalValue);
            }

            return inpersistence;
        }

        public Customer GetCustomerDomain(KynHealthAssessmentEditModel model, Customer inpersistence, long uploadedby)
        {
            if (inpersistence == null)
                inpersistence = new Customer();

            if (model.HeightInFeet.HasValue || model.HeightInInches.HasValue)
            {
                inpersistence.Height = inpersistence.Height == null
                    ? new Height(model.HeightInFeet ?? 0, model.HeightInInches ?? 0)
                    : new Height(model.HeightInFeet ?? inpersistence.Height.Feet,
                        model.HeightInInches ?? inpersistence.Height.Inches);
            }

            if (model.KynWeight.HasValue && model.KynWeight.Value > 0)
                inpersistence.Weight = new Weight((double)model.KynWeight);

            if (model.WaistSize.HasValue && model.WaistSize.Value > 0)
                inpersistence.Waist = model.WaistSize.Value;

            inpersistence.DataRecorderMetaData = SetDataRecorderMetaData(inpersistence.DataRecorderMetaData, uploadedby);

            return inpersistence;
        }

        public TestResult GetAsiTestResultDomain(KynHealthAssessmentEditModel model, ASITestResult inpersistence, long uploadedby, bool isNewResultFlow)
        {
            if (inpersistence == null)
            {
                inpersistence = new ASITestResult
                {
                    PressureReadings = new CardiovisionPressureReadings
               {
                   Pulse = new ResultReading<int?> { Reading = model.PulseRate },
                   DiastolicLeftArm = new ResultReading<int?>(),
                   SystolicLeftArm = new ResultReading<int?>(),
                   DiastolicRightArm = new ResultReading<int?>(),
                   SystolicRightArm = new ResultReading<int?>()
               },
                    ResultStatus = new TestResultState
                    {
                        StateNumber = isNewResultFlow ? (int)NewTestResultStateNumber.ResultEntryPartial : (int)TestResultStateNumber.ManualEntry
                    }
                };
            }
            else
            {
                if (inpersistence.PressureReadings == null)
                {
                    inpersistence.PressureReadings = new CardiovisionPressureReadings
                    {
                        Pulse = new ResultReading<int?> { Reading = model.PulseRate },
                        DiastolicLeftArm = new ResultReading<int?>(),
                        SystolicLeftArm = new ResultReading<int?>(),
                        DiastolicRightArm = new ResultReading<int?>(),
                        SystolicRightArm = new ResultReading<int?>()
                    };
                }
                else
                {
                    inpersistence.PressureReadings.Pulse = new ResultReading<int?> { Reading = model.PulseRate };
                }
            }

            inpersistence.ResultStatus.DataRecorderMetaData = SetDataRecorderMetaData(inpersistence.ResultStatus.DataRecorderMetaData, uploadedby);
            inpersistence.DataRecorderMetaData = SetDataRecorderMetaData(inpersistence.DataRecorderMetaData, uploadedby);

            return inpersistence;
        }

        public TestResult GetKynTestResultDomain(KynHealthAssessmentEditModel model, TestResult inpersistence, long uploadedby, long testTypeId, bool isNewResultFlow)
        {
            if (inpersistence == null)
            {
                inpersistence = new TestResult((TestType)testTypeId)
                {
                    TechnicianNotes = model.Notes,
                    ResultStatus = new TestResultState
                    {
                        StateNumber = isNewResultFlow ? (int)NewTestResultStateNumber.ResultEntryPartial : (int)TestResultStateNumber.ManualEntry
                    }
                };
            }
            else
            {
                inpersistence.TechnicianNotes = model.Notes;
            }

            inpersistence.ResultStatus.DataRecorderMetaData = SetDataRecorderMetaData(inpersistence.ResultStatus.DataRecorderMetaData, uploadedby);
            inpersistence.DataRecorderMetaData = SetDataRecorderMetaData(inpersistence.DataRecorderMetaData, uploadedby);

            return inpersistence;
        }

        private DataRecorderMetaData SetDataRecorderMetaData(DataRecorderMetaData dataRecorder, long uploadedby)
        {
            if (dataRecorder == null)
            {
                dataRecorder = new DataRecorderMetaData(new OrganizationRoleUser(uploadedby), DateTime.Now, null);
            }
            else
            {
                dataRecorder.DataRecorderModifier = new OrganizationRoleUser(uploadedby);
                dataRecorder.DateModified = DateTime.Now;
            }

            return dataRecorder;
        }

        public KynLabValues GetKynLabValues(KynHealthAssessmentEditModel model)
        {
            int s;
            return new KynLabValues
            {
                Glucose = model.Glucose.HasValue && model.Glucose.Value > 0 ? model.Glucose.Value : (int?)null,
                TotalCholesterol = int.TryParse(model.TotalCholesterol, out s) ? s : (int?)null,
                Hdl = int.TryParse(model.HDLCholesterol, out s) ? s : (int?)null,
                Triglycerides = int.TryParse(model.Triglycerides, out s) ? s : (int?)null,
                FastingStatus = model.FastingStatus > 0 ? model.FastingStatus : (long?)null,
                ManualSystolic = model.ManualSystolic,
                ManualDiastolic = model.ManualDiastolic,
                A1c = model.A1c,

                LdlCholestrol = model.LdlCholestrol,
                BodyFat = model.BodyFat,
                BoneDensity = model.BoneDensity,
                Psa = model.Psa,
                NonHdlCholestrol = model.NonHdlCholestrol,
                Nicotine = model.Nicotine,
                Cotinine = model.Cotinine,
                Smoker = model.Smoker,
                Notes = model.Notes
            };
        }

        public TestResult GetAwvLipidTestResultDomain(KynHealthAssessmentEditModel model, AwvLipidTestResult inpersistence, long uploadedby, bool isNewResultFlow)
        {
            if (!IsLipidReadingProvided(model) && inpersistence == null) return inpersistence;

            decimal? tchol = null;
            decimal? hdl = null;
            decimal? triglycerides = null;

            if (inpersistence == null)
            {
                inpersistence = new AwvLipidTestResult
                {
                    ResultStatus = new TestResultState
                    {
                        StateNumber = isNewResultFlow ? (int)NewTestResultStateNumber.ResultEntryPartial : (int)TestResultStateNumber.ManualEntry
                    }
                };
            }

            inpersistence.TotalCholestrol = GetTotalColesterolReading(model.TotalCholesterol, ref tchol);
            inpersistence.HDL = GetHdlReading(model.HDLCholesterol, ref hdl);
            inpersistence.TriGlycerides = GetTriglyceridesReading(model.Triglycerides, ref triglycerides);
            inpersistence.TCHDLRatio = CalculateTchdlRatio(tchol, hdl, TestType.AwvLipid);
            inpersistence.LDL = CalculateLdlReading(hdl, tchol, triglycerides, TestType.AwvLipid);

            inpersistence.DataRecorderMetaData = SetDataRecorderMetaData(inpersistence.DataRecorderMetaData, uploadedby);
            inpersistence.ResultStatus.DataRecorderMetaData = SetDataRecorderMetaData(inpersistence.ResultStatus.DataRecorderMetaData, uploadedby);

            return inpersistence;
        }

        public TestResult GetAwvGlucoseTestResultDomain(KynHealthAssessmentEditModel model, AwvGlucoseTestResult inpersistence, long uploadedby, bool isNewResultFlow)
        {
            if (!IsLipidReadingProvided(model) && inpersistence == null) return inpersistence;

            if (inpersistence == null)
            {
                inpersistence = new AwvGlucoseTestResult
                {
                    ResultStatus = new TestResultState
                    {
                        StateNumber = isNewResultFlow ? (int)NewTestResultStateNumber.ResultEntryPartial : (int)TestResultStateNumber.ManualEntry
                    }
                };

            }

            inpersistence.Glucose = GetGlucoseReading(model.Glucose);

            inpersistence.DataRecorderMetaData = SetDataRecorderMetaData(inpersistence.DataRecorderMetaData, uploadedby);
            inpersistence.ResultStatus.DataRecorderMetaData = SetDataRecorderMetaData(inpersistence.ResultStatus.DataRecorderMetaData, uploadedby);

            return inpersistence;
        }

        public TestResult GetDiabetesTestResultDomain(KynHealthAssessmentEditModel model, DiabetesTestResult inpersistence, long uploadedby, bool isNewResultFlow)
        {
            if (!IsLipidReadingProvided(model) && inpersistence == null) return inpersistence;

            if (inpersistence == null)
            {
                inpersistence = new DiabetesTestResult
                {
                    ResultStatus = new TestResultState
                    {
                        StateNumber = isNewResultFlow ? (int)NewTestResultStateNumber.ResultEntryPartial : (int)TestResultStateNumber.ManualEntry
                    }
                };

            }

            inpersistence.Glucose = GetGlucoseReading(model.Glucose);

            inpersistence.DataRecorderMetaData = SetDataRecorderMetaData(inpersistence.DataRecorderMetaData, uploadedby);
            inpersistence.ResultStatus.DataRecorderMetaData = SetDataRecorderMetaData(inpersistence.ResultStatus.DataRecorderMetaData, uploadedby);

            return inpersistence;
        }

        public TestResult GetCholesterolTestResultDomain(KynHealthAssessmentEditModel model, CholesterolTestResult inpersistence, long uploadedby, bool isNewResultFlow)
        {
            if (!IsLipidReadingProvided(model) && inpersistence == null) return inpersistence;

            decimal? tchol = null;
            decimal? hdl = null;
            decimal? triglycerides = null;

            if (inpersistence == null)
            {
                inpersistence = new CholesterolTestResult
                {
                    ResultStatus = new TestResultState
                    {
                        StateNumber = isNewResultFlow ? (int)NewTestResultStateNumber.ResultEntryPartial : (int)TestResultStateNumber.ManualEntry
                    }
                };
            }

            inpersistence.TotalCholesterol = GetTotalColesterolReading(model.TotalCholesterol, ref tchol);
            inpersistence.HDL = GetHdlReading(model.HDLCholesterol, ref hdl);
            inpersistence.TriGlycerides = GetTriglyceridesReading(model.Triglycerides, ref triglycerides);
            inpersistence.TCHDLRatio = CalculateTchdlRatio(tchol, hdl, TestType.Cholesterol);
            inpersistence.LDL = CalculateLdlReading(hdl, tchol, triglycerides, TestType.Cholesterol);


            inpersistence.DataRecorderMetaData = SetDataRecorderMetaData(inpersistence.DataRecorderMetaData, uploadedby);
            inpersistence.ResultStatus.DataRecorderMetaData = SetDataRecorderMetaData(inpersistence.ResultStatus.DataRecorderMetaData, uploadedby);

            return inpersistence;
        }

        private CompoundResultReading<int?> GetGlucoseReading(int? glucose)
        {
            if (glucose.HasValue)
            {
                return new CompoundResultReading<int?>
                 {
                     Reading = glucose,
                     Label = ReadingLabels.Glucose,
                     ReadingSource = ReadingSource.Manual
                 };
            }

            return null;
        }

        private CompoundResultReading<int?> CalculateLdlReading(decimal? hdl, decimal? tchol, decimal? triglycerides, TestType testType)
        {
            if (!hdl.HasValue || hdl.Value <= 0 || !tchol.HasValue || tchol.Value <= 0 || !triglycerides.HasValue || triglycerides.Value <= 0) return null;
            var testResultService = new Service.TestResultService();
            var ldl = tchol.Value - hdl.Value - (triglycerides.Value / 5);

            return new CompoundResultReading<int?>
            {
                Reading = Convert.ToInt32(ldl),
                Label = ReadingLabels.LDL,
                ReadingSource = ReadingSource.Manual,
                Finding = new StandardFinding<int?>(testResultService.GetCalculatedStandardFinding(Convert.ToInt32(ldl), (int)testType, (int)ReadingLabels.LDL))
            };
        }

        private CompoundResultReading<decimal?> CalculateTchdlRatio(decimal? totalCholesterol, decimal? hdl, TestType testType)
        {
            if (hdl == null || totalCholesterol == null) return null;
            var testResultService = new Service.TestResultService();

            var s = totalCholesterol.Value / hdl.Value;
            s = decimal.Round(s, 2);

            return new CompoundResultReading<decimal?>
             {
                 Reading = s,
                 Label = ReadingLabels.TCHDLRatio,
                 ReadingSource = ReadingSource.Manual,
                 Finding = new StandardFinding<decimal?>(testResultService.GetCalculatedStandardFinding(s, (int)testType, (int)ReadingLabels.TCHDLRatio))
             };
        }

        private CompoundResultReading<string> GetTriglyceridesReading(string triglyceridesReading, ref decimal? triglycerides)
        {
            if (string.IsNullOrEmpty(triglyceridesReading)) return null;

            int s;
            int.TryParse(triglyceridesReading, out s);
            if (s > 0) triglycerides = s;

            return new CompoundResultReading<string>
            {
                Reading = triglyceridesReading,
                Label = ReadingLabels.TriGlycerides,
                ReadingSource = ReadingSource.Manual
            };


        }

        private CompoundResultReading<string> GetHdlReading(string hdlCholesterol, ref decimal? hdl)
        {
            if (string.IsNullOrEmpty(hdlCholesterol)) return null;

            int s;
            int.TryParse(hdlCholesterol, out s);
            if (s > 0) hdl = s;

            return new CompoundResultReading<string>
            {
                Reading = hdlCholesterol,
                Label = ReadingLabels.HDL,
                ReadingSource = ReadingSource.Manual
            };
        }

        private CompoundResultReading<string> GetTotalColesterolReading(string totalCholesterol, ref decimal? tchol)
        {
            if (string.IsNullOrEmpty(totalCholesterol)) return null;

            int s;
            int.TryParse(totalCholesterol, out s);
            if (s > 0) tchol = s;

            return new CompoundResultReading<string>
            {
                Reading = totalCholesterol,
                Label = ReadingLabels.TotalCholestrol,
                ReadingSource = ReadingSource.Manual
            };
        }

        private bool IsHypertensionReadingProvided(KynHealthAssessmentEditModel model)
        {
            return model.DiastolicPressure.HasValue || model.SystolicPressure.HasValue || model.PulseRate.HasValue;
        }

        public TestResult GetHypertensionTestResultDomain(KynHealthAssessmentEditModel model, HypertensionTestResult inpersistence, long uploadedby, bool isNewResultFlow)
        {
            if (!IsHypertensionReadingProvided(model) && inpersistence == null) return inpersistence;

            var isBloodPressureElevated = (model.SystolicPressure.HasValue && model.SystolicPressure.Value >= SystolicAbnormalValue) ||
                                          (model.DiastolicPressure.HasValue && model.DiastolicPressure.Value >= DiastolicAbnormalValue);
            if (inpersistence == null)
            {
                inpersistence = new HypertensionTestResult
                {
                    Pulse = new ResultReading<int?>
                    {
                        Reading = model.PulseRate,
                        Label = ReadingLabels.Pulse,
                        ReadingSource = ReadingSource.Manual
                    },
                    Diastolic = new ResultReading<int?>
                    {
                        Reading = model.DiastolicPressure,
                        Label = ReadingLabels.DiastolicRight,
                        ReadingSource = ReadingSource.Manual
                    },
                    Systolic = new ResultReading<int?>
                    {
                        Reading = model.SystolicPressure,
                        Label = ReadingLabels.SystolicRight,
                        ReadingSource = ReadingSource.Manual
                    },
                    BloodPressureElevated = new ResultReading<bool>
                    {
                        Reading = isBloodPressureElevated,
                        Label = ReadingLabels.BloodPressureElevated,
                        ReadingSource = ReadingSource.Manual
                    },
                    ResultStatus = new TestResultState
                    {
                        StateNumber = isNewResultFlow ? (int)NewTestResultStateNumber.ResultEntryPartial : (int)TestResultStateNumber.ManualEntry
                    }
                };
            }
            else
            {
                inpersistence.Pulse = new ResultReading<int?>
                {
                    Reading = model.PulseRate,
                    Label = ReadingLabels.Pulse,
                    ReadingSource = ReadingSource.Manual
                };
                inpersistence.Diastolic = new ResultReading<int?>
                {
                    Reading = model.DiastolicPressure,
                    Label = ReadingLabels.DiastolicRight,
                    ReadingSource = ReadingSource.Manual
                };
                inpersistence.Systolic = new ResultReading<int?>
                {
                    Reading = model.SystolicPressure,
                    Label = ReadingLabels.SystolicRight,
                    ReadingSource = ReadingSource.Manual
                };
                inpersistence.BloodPressureElevated = new ResultReading<bool>
                {
                    Reading = isBloodPressureElevated,
                    Label = ReadingLabels.BloodPressureElevated,
                    ReadingSource = ReadingSource.Manual
                };
            }

            inpersistence.ResultStatus.DataRecorderMetaData = SetDataRecorderMetaData(inpersistence.ResultStatus.DataRecorderMetaData, uploadedby);
            inpersistence.DataRecorderMetaData = SetDataRecorderMetaData(inpersistence.DataRecorderMetaData, uploadedby);

            return inpersistence;
        }

        private bool IsHemaglobinA1CTestReadingProvided(KynHealthAssessmentEditModel model)
        {
            return model.A1c.HasValue;
        }

        public TestResult GetHemaglobinA1CTestResultDomain(KynHealthAssessmentEditModel model, HemaglobinA1CTestResult inpersistence, long uploadedby, bool isNewResultFlow)
        {
            if (!IsHemaglobinA1CTestReadingProvided(model) && inpersistence == null) return inpersistence;

            if (inpersistence == null)
            {
                inpersistence = new HemaglobinA1CTestResult
                {
                    Hba1c = new ResultReading<string>
                    {
                        Reading = model.A1c.HasValue ? model.A1c.Value.ToString() : string.Empty,
                        Label = ReadingLabels.Hba1c,
                        ReadingSource = ReadingSource.Manual
                    },
                    ResultStatus = new TestResultState
                    {
                        StateNumber = isNewResultFlow ? (int)NewTestResultStateNumber.ResultEntryPartial : (int)TestResultStateNumber.ManualEntry
                    }
                };
            }
            else
            {
                inpersistence.Hba1c = new ResultReading<string>
                {
                    Reading = model.A1c.HasValue ? model.A1c.Value.ToString() : string.Empty,
                    Label = ReadingLabels.Hba1c,
                    ReadingSource = ReadingSource.Manual
                };
            }

            inpersistence.ResultStatus.DataRecorderMetaData = SetDataRecorderMetaData(inpersistence.ResultStatus.DataRecorderMetaData, uploadedby);
            inpersistence.DataRecorderMetaData = SetDataRecorderMetaData(inpersistence.DataRecorderMetaData, uploadedby);

            return inpersistence;
        }

        public TestResult GetAwvHemaglobinTestResultDomain(KynHealthAssessmentEditModel model, AwvHemaglobinTestResult inpersistence, long uploadedby, bool isNewResultFlow)
        {
            if (!IsHemaglobinA1CTestReadingProvided(model) && inpersistence == null) return inpersistence;

            if (inpersistence == null)
            {
                inpersistence = new AwvHemaglobinTestResult
                {
                    Hba1c = new ResultReading<string>
                    {
                        Reading = model.A1c.HasValue ? model.A1c.Value.ToString() : string.Empty,
                        Label = ReadingLabels.Hba1c,
                        ReadingSource = ReadingSource.Manual
                    },
                    ResultStatus = new TestResultState
                    {
                        StateNumber = isNewResultFlow ? (int)NewTestResultStateNumber.ResultEntryPartial : (int)TestResultStateNumber.ManualEntry
                    }
                };
            }
            else
            {
                inpersistence.Hba1c = new ResultReading<string>
                {
                    Reading = model.A1c.HasValue ? model.A1c.Value.ToString() : string.Empty,
                    Label = ReadingLabels.Hba1c,
                    ReadingSource = ReadingSource.Manual
                };
            }

            inpersistence.ResultStatus.DataRecorderMetaData = SetDataRecorderMetaData(inpersistence.ResultStatus.DataRecorderMetaData, uploadedby);
            inpersistence.DataRecorderMetaData = SetDataRecorderMetaData(inpersistence.DataRecorderMetaData, uploadedby);

            return inpersistence;
        }

        public TestResult GetMyBioCheckAssessmentTestResultDomain(KynHealthAssessmentEditModel model, MyBioAssessmentTestResult inpersistence, long uploadedby, bool isNewResultFlow)
        {
            if (!IsLipidReadingProvided(model) && inpersistence == null) return inpersistence;

            decimal? tchol = null;
            decimal? hdl = null;
            decimal? triglycerides = null;

            if (inpersistence == null)
            {
                inpersistence = new MyBioAssessmentTestResult
                {
                    ResultStatus = new TestResultState
                    {
                        StateNumber = isNewResultFlow ? (int)NewTestResultStateNumber.ResultEntryPartial : (int)TestResultStateNumber.ManualEntry
                    }
                };

            }

            inpersistence.TotalCholestrol = GetTotalColesterolReading(model.TotalCholesterol, ref tchol);
            inpersistence.Hdl = GetHdlReading(model.HDLCholesterol, ref hdl);
            inpersistence.TriGlycerides = GetTriglyceridesReading(model.Triglycerides, ref triglycerides);
            inpersistence.TcHdlRatio = CalculateTchdlRatio(tchol, hdl, TestType.MyBioCheckAssessment);
            inpersistence.Ldl = CalculateLdlReading(hdl, tchol, triglycerides, TestType.MyBioCheckAssessment);

            inpersistence.Glucose = GetGlucoseReading(model.Glucose);

            inpersistence.DataRecorderMetaData = SetDataRecorderMetaData(inpersistence.DataRecorderMetaData, uploadedby);
            inpersistence.ResultStatus.DataRecorderMetaData = SetDataRecorderMetaData(inpersistence.ResultStatus.DataRecorderMetaData, uploadedby);

            return inpersistence;
        }
    }
}
