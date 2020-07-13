using System;
using System.Data;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    public class CardiovisionAsiParser : ICsvTestParser
    {
        private ILogger _logger;
        private string _errorSummary;

        private const string ColumnAsi = "ASI";
        private const string ColumnSystolic = "Systolic(mmHg)";
        private const string ColumnDiastolic = "Diastolic(mmHg)";
        private const string ColumnArmPressure = "Arm Systolic Pressure";
        private const string ColumnPattern = "Pattern";
        private const string ColumnPulse = "Pulse";
        private const string ColumnPulsePressure = "Pulse Pressure(mmHg)";

        private readonly Service.TestResultService _testResultService;

        public CardiovisionAsiParser(ILogger logger)
        {
            _testResultService = new Service.TestResultService();
            _logger = logger;
        }

        public static bool IsDatatableConversionfromCsvValid(DataTable dtCardiovision)
        {
            if (dtCardiovision.Columns.Contains(ColumnAsi) && dtCardiovision.Columns.Contains(ColumnPulse) && dtCardiovision.Columns.Contains(ColumnSystolic) && dtCardiovision.Columns.Contains(ColumnArmPressure) &&
                dtCardiovision.Columns.Contains(ColumnPattern) && dtCardiovision.Columns.Contains(ColumnPulsePressure) && dtCardiovision.Columns.Contains(ColumnDiastolic))
                return true;

            return false;
        }

        public TestResult Parse(DataRow dr)
        {
            _errorSummary = string.Empty;

            if (!CheckifRowContainsAnyReadingData(dr)) return null;
            var testResult = new ASITestResult();

            if (!IsDataRowItemEmpty(dr[ColumnPulse]) || !IsDataRowItemEmpty(dr[ColumnPulsePressure]) || !IsDataRowItemEmpty(dr[ColumnSystolic]) || !IsDataRowItemEmpty(dr[ColumnDiastolic]))
                testResult.PressureReadings = new CardiovisionPressureReadings();

            SetBloodPressureValues(testResult, dr);

            try
            {
                if (!IsDataRowItemEmpty(dr[ColumnAsi]))
                {
                    int s = 0;
                    if (int.TryParse(dr[ColumnAsi].ToString(), out s))
                    {
                        var findingId = _testResultService.GetCalculatedStandardFinding(s, (int) TestType.ASI,
                                                                                        (int) ReadingLabels.ASI);
                        testResult.ASI = new CompoundResultReading<int?>(ReadingLabels.ASI)
                                             {
                                                 ReadingSource = ReadingSource.Automatic,
                                                 Reading = s,
                                                 Finding = findingId > 0 ? new StandardFinding<int?>(findingId) : null
                                             };
                    }
                }
            }
            catch(Exception ex)
            {
                _errorSummary += "Data extraction for ASI failed. ";
                _logger.Error("\n Data extraction for ASI failed! Error: " + ex.Message + "\n\t\t" + ex.StackTrace);
            }

            try
            {
                if (!IsDataRowItemEmpty(dr[ColumnPulse]))
                {
                    int s = 0;
                    if (int.TryParse(dr[ColumnPulse].ToString(), out s))
                    {
                        testResult.PressureReadings.Pulse = new ResultReading<int?>(ReadingLabels.Pulse)
                                                                {
                                                                    ReadingSource = ReadingSource.Automatic,
                                                                    Reading = s
                                                                };
                    }
                }
            }
            catch(Exception ex)
            {
                _errorSummary += "Data extraction for Pulse failed. ";
                _logger.Error("\n Data extraction for Pulse failed! Error: " + ex.Message + "\n\t\t" + ex.StackTrace);
            }

            try
            {
                if (!IsDataRowItemEmpty(dr[ColumnPulsePressure]))
                {
                    int s = 0;
                    if (int.TryParse(dr[ColumnPulsePressure].ToString(), out s))
                    {
                        testResult.PressureReadings.PulsePressure = new ResultReading<int?>(ReadingLabels.PulsePressure)
                                                                        {
                                                                            ReadingSource = ReadingSource.Automatic,
                                                                            Reading = s
                                                                        };
                    }
                }
            }
            catch(Exception ex)
            {
                _errorSummary += "Data extraction for Pulse Pressure failed. ";
                _logger.Error("\n Data extraction for Pulse Pressure failed! Error: " + ex.Message + "\n\t\t" + ex.StackTrace);
            }

            try
            {
                if (!IsDataRowItemEmpty(dr[ColumnPattern]))
                {
                    testResult.Pattern = new ResultReading<string>(ReadingLabels.Pattern)
                                             {
                                                 ReadingSource = ReadingSource.Automatic,
                                                 Reading = dr[ColumnPattern].ToString()
                                             };
                }
            }
            catch(Exception ex)
            {
                _errorSummary += "Data extraction for Pattern failed. ";
                _logger.Error("\n Data extraction for Pattern failed! Error: " + ex.Message + "\n\t\t" + ex.StackTrace);
            }

            return testResult;
        }

        private void SetBloodPressureValues(ASITestResult testResult, DataRow dr)
        {
            bool isRight = true;
            if (!IsDataRowItemEmpty(dr[ColumnArmPressure]))
            {
                if(dr[ColumnArmPressure].ToString().Trim().ToLower().Equals("left"))
                    isRight = false;
            }

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

        private static bool CheckifRowContainsAnyReadingData(DataRow dr)
        {
            if (IsDataRowItemEmpty(dr[ColumnAsi]) && IsDataRowItemEmpty(dr[ColumnPattern]) && IsDataRowItemEmpty(dr[ColumnPulse]) && IsDataRowItemEmpty(dr[ColumnPulsePressure]))
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