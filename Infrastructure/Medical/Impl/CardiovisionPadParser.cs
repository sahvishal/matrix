using System;
using System.Data;
using System.Linq;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    public class CardiovisionPadParser : ICsvTestParser
    {
        private ILogger _logger;
        private string _errorSummary;

        private const string ColumnSystolic = "Systolic(mmHg)";
        private const string ColumnDiastolic = "Diastolic(mmHg)";
        private const string ColumnArmPressure = "Arm Systolic Pressure";
        private const string ColumnRAbi = "Right ABI";
        private const string ColumnLAbi = "Left ABI";
        private const string ColumnRArmSystolic = "Right Arm Systolic(mmHg)";
        private const string ColumnLArmSystolic = "Left Arm Systolic(mmHg)";
        private const string ColumnRAnkleSystolic = "Right Ankle Systolic(mmHg)";
        private const string ColumnLAnkleSystolic = "Left Ankle Systolic(mmHg)";

        private readonly Service.TestResultService _testResultService;

        public CardiovisionPadParser(ILogger logger)
        {
            _testResultService = new Service.TestResultService();
            _logger = logger;
        }

        public static bool IsDatatableConversionfromCsvValid(DataTable dtCardiovision)
        {
            if (dtCardiovision.Columns.Contains(ColumnRAbi) && dtCardiovision.Columns.Contains(ColumnRArmSystolic) && dtCardiovision.Columns.Contains(ColumnRAnkleSystolic) &&
                 dtCardiovision.Columns.Contains(ColumnLAbi) && dtCardiovision.Columns.Contains(ColumnLArmSystolic) && dtCardiovision.Columns.Contains(ColumnLAnkleSystolic) &&
                dtCardiovision.Columns.Contains(ColumnSystolic) && dtCardiovision.Columns.Contains(ColumnDiastolic) && dtCardiovision.Columns.Contains(ColumnArmPressure))
                return true;

            return false;
        }

        public TestResult Parse(DataRow dr)
        {
            _errorSummary = string.Empty;
            var testResult = new PADTestResult();

            if (CheckifRowContainsAnyLreadingData(dr))
                testResult.LeftResultReadings = new PadTestReadings();

            if (CheckifRowContainsAnyRreadingData(dr))
                testResult.RightResultReadings = new PadTestReadings();

            SetBloodPressureValues(testResult, dr);

            if (testResult.LeftResultReadings == null && testResult.RightResultReadings == null && testResult.PressureReadings == null)
                return null;

            long leftFindingId = 0;
            long rightFindingId = 0;

            try
            {
                if (!IsDataRowItemEmpty(dr[ColumnRAbi]))
                {
                    decimal s;
                    if (decimal.TryParse(dr[ColumnRAbi].ToString(), out s))
                    {
                        testResult.RightResultReadings.ABI = new ResultReading<decimal?>(ReadingLabels.RightABI)
                                                                 {
                                                                     ReadingSource = ReadingSource.Automatic,
                                                                     Reading = s
                                                                 };

                        rightFindingId = _testResultService.GetCalculatedStandardFinding(testResult.RightResultReadings.ABI.Reading, (int)TestType.PAD, null);
                    }
                }
            }
            catch (Exception ex)
            {
                _errorSummary += "Data extraction for Right ABI failed. ";
                _logger.Error("\n Data extraction for Right ABI failed! Error: " + ex.Message + "\n\t\t" + ex.StackTrace);
            }

            try
            {
                if (!IsDataRowItemEmpty(dr[ColumnRAnkleSystolic]))
                {
                    int s;
                    if (int.TryParse(dr[ColumnRAnkleSystolic].ToString(), out s))
                    {
                        testResult.RightResultReadings.SystolicAnkle =
                            new ResultReading<int?>(ReadingLabels.SystolicRAnkle)
                                {
                                    ReadingSource = ReadingSource.Automatic,
                                    Reading = s
                                };
                    }
                }
            }
            catch (Exception ex)
            {
                _errorSummary += "Data extraction for Right Ankle Systolic failed. ";
                _logger.Error("\n Data extraction for Right Ankle Systolic failed! Error: " + ex.Message + "\n\t\t" + ex.StackTrace);
            }

            try
            {
                if (!IsDataRowItemEmpty(dr[ColumnRArmSystolic]))
                {
                    int s;
                    if (int.TryParse(dr[ColumnRArmSystolic].ToString(), out s))
                    {
                        testResult.RightResultReadings.SystolicArm = new ResultReading<int?>(ReadingLabels.SystolicRArm)
                                                                         {
                                                                             ReadingSource = ReadingSource.Automatic,
                                                                             Reading = s
                                                                         };
                    }
                }
            }
            catch (Exception ex)
            {
                _errorSummary += "Data extraction for Right Arm Systolic failed. ";
                _logger.Error("\n Data extraction for Right Arm Systolic failed! Error: " + ex.Message + "\n\t\t" + ex.StackTrace);
            }

            try
            {
                if (!IsDataRowItemEmpty(dr[ColumnLAbi]))
                {
                    decimal s;
                    if (decimal.TryParse(dr[ColumnLAbi].ToString(), out s))
                    {
                        testResult.LeftResultReadings.ABI = new ResultReading<decimal?>(ReadingLabels.LeftABI)
                                                                {
                                                                    ReadingSource = ReadingSource.Automatic,
                                                                    Reading = s
                                                                };

                        leftFindingId = _testResultService.GetCalculatedStandardFinding(testResult.LeftResultReadings.ABI.Reading, (int)TestType.PAD, null);
                    }
                }
            }
            catch (Exception ex)
            {
                _errorSummary += "Data extraction for Left ABI failed. ";
                _logger.Error("\n Data extraction for Left ABI failed! Error: " + ex.Message + "\n\t\t" + ex.StackTrace);
            }

            try
            {
                if (!IsDataRowItemEmpty(dr[ColumnLAnkleSystolic]))
                {
                    int s;
                    if (int.TryParse(dr[ColumnLAnkleSystolic].ToString(), out s))
                    {
                        testResult.LeftResultReadings.SystolicAnkle =
                            new ResultReading<int?>(ReadingLabels.SystolicLAnkle)
                                {
                                    ReadingSource = ReadingSource.Automatic,
                                    Reading = s
                                };
                    }
                }
            }
            catch (Exception ex)
            {
                _errorSummary += "Data extraction for Left Ankle Systolic failed. ";
                _logger.Error("\n Data extraction for Left Ankle Systolic failed! Error: " + ex.Message + "\n\t\t" + ex.StackTrace);
            }

            try
            {
                if (!IsDataRowItemEmpty(dr[ColumnLArmSystolic]))
                {
                    int s = 0;
                    if (int.TryParse(dr[ColumnLArmSystolic].ToString(), out s))
                    {
                        testResult.LeftResultReadings.SystolicArm = new ResultReading<int?>(ReadingLabels.SystolicLArm)
                                                                        {
                                                                            ReadingSource = ReadingSource.Automatic,
                                                                            Reading = s
                                                                        };
                    }
                }
            }
            catch (Exception ex)
            {
                _errorSummary += "Data extraction for Left Arm Systolic failed. ";
                _logger.Error("\n Data extraction for Left Arm Systolic failed! Error: " + ex.Message + "\n\t\t" + ex.StackTrace);
            }

            testResult.Finding = GetPadFindingToConsider(leftFindingId, rightFindingId);
            return testResult;
        }

        private void SetBloodPressureValues(PADTestResult testResult, DataRow dr)
        {
            bool isRight = true;
            if (!IsDataRowItemEmpty(dr[ColumnArmPressure]))
            {
                if (dr[ColumnArmPressure].ToString().Trim().ToLower().Equals("left"))
                    isRight = false;
            }

            if (!IsDataRowItemEmpty(dr[ColumnSystolic]) || !IsDataRowItemEmpty(dr[ColumnDiastolic]))
                testResult.PressureReadings = new CardiovisionPressureReadings();

            try
            {
                if (!IsDataRowItemEmpty(dr[ColumnSystolic]))
                {
                    int s = 0;
                    if (int.TryParse(dr[ColumnSystolic].ToString(), out s))
                    {
                        if (!isRight)
                        {
                            testResult.PressureReadings.SystolicLeftArm = new ResultReading<int?>(ReadingLabels.SystolicLeft)
                            {
                                ReadingSource = ReadingSource.Automatic,
                                Reading = s
                            };
                        }
                        else
                        {
                            testResult.PressureReadings.SystolicRightArm = new ResultReading<int?>(ReadingLabels.SystolicRight)
                            {
                                ReadingSource = ReadingSource.Automatic,
                                Reading = s
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _errorSummary += "Data extraction for BP Systolic failed. ";
                _logger.Error("\n Data extraction for BP Systolic failed! Error: " + ex.Message + "\n\t\t" + ex.StackTrace);
            }


            try
            {
                if (!IsDataRowItemEmpty(dr[ColumnDiastolic]))
                {
                    int s = 0;
                    if (int.TryParse(dr[ColumnDiastolic].ToString(), out s))
                    {
                        if (!isRight)
                        {
                            testResult.PressureReadings.DiastolicLeftArm = new ResultReading<int?>(ReadingLabels.DiastolicLeft)
                            {
                                ReadingSource = ReadingSource.Automatic,
                                Reading = s
                            };
                        }
                        else
                        {
                            testResult.PressureReadings.DiastolicRightArm = new ResultReading<int?>(ReadingLabels.DiastolicRight)
                            {
                                ReadingSource = ReadingSource.Automatic,
                                Reading = s
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _errorSummary += "Data extraction for BP Systolic failed. ";
                _logger.Error("\n Data extraction for BP Systolic failed! Error: " + ex.Message + "\n\t\t" + ex.StackTrace);
            }

        }

        private StandardFinding<decimal> GetPadFindingToConsider(long leftFindingId, long rightFindingId)
        {
            if (leftFindingId == 0 && rightFindingId == 0) return null;

            var allFindings = _testResultService.GetAllStandardFindings<decimal>((int)TestType.PAD);

            var leftFinding = leftFindingId > 0 ? allFindings.Where(f => f.Id == leftFindingId).SingleOrDefault() : null;
            var rightFinding = rightFindingId > 0 ? allFindings.Where(f => f.Id == rightFindingId).SingleOrDefault() : null;

            if (leftFinding == null && rightFinding == null) return null;

            if (leftFinding == null) return rightFinding;
            if (rightFinding == null) return leftFinding;

            return (leftFinding.WorstCaseOrder > rightFinding.WorstCaseOrder ? leftFinding : rightFinding);
        }

        private static bool CheckifRowContainsAnyLreadingData(DataRow dr)
        {
            if (IsDataRowItemEmpty(dr[ColumnLAbi]) && IsDataRowItemEmpty(dr[ColumnLArmSystolic]) && IsDataRowItemEmpty(dr[ColumnLAnkleSystolic]))
                return false;

            return true;
        }


        private static bool CheckifRowContainsAnyRreadingData(DataRow dr)
        {
            if (IsDataRowItemEmpty(dr[ColumnRAbi]) && IsDataRowItemEmpty(dr[ColumnRArmSystolic]) && IsDataRowItemEmpty(dr[ColumnRAnkleSystolic]))
                return false;

            return true;
        }

        private static bool IsDataRowItemEmpty(Object obj)
        {
            if (obj != null && obj != DBNull.Value && !string.IsNullOrEmpty(obj.ToString()))
                return false;

            return true;
        }


        public string ErrorSummary
        {
            get { return _errorSummary; }
        }
    }
}
