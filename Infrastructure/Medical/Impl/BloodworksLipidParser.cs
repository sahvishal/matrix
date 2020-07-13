using System;
using System.Data;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    public class BloodworksLipidParser : ICsvTestParser
    {
        private ILogger _logger;
        private string _errorSummary;
        public string ErrorSummary
        {
            get { return _errorSummary; }
        }


        private const string ColumnTc = "TC";
        private const string ColumnHdl = "HDL";
        private const string ColumnLdl = "LDL";
        private const string ColumnGlu = "GLUCOSE";
        private const string ColumnTrig = "TRI";
        private const string ColumnTchdl = "TCHDL";

        private readonly Service.TestResultService _testResultService;

        public BloodworksLipidParser(ILogger logger)
        {
            _testResultService = new Service.TestResultService();
            _logger = logger;
        }

        public TestResult Parse(DataRow dr)
        {
            _errorSummary = string.Empty;
            var testResult = new LipidTestResult();
            if (!CheckifRowContainsAnyReadingData(dr)) return null;

            try
            {
                if (!IsDataRowItemEmpty(dr[ColumnGlu]))
                {
                    int s = 0;
                    if (int.TryParse(dr[ColumnGlu].ToString(), out s))
                    {
                        var findingId = _testResultService.GetCalculatedStandardFinding(s, (int)TestType.Lipid, (int)ReadingLabels.Glucose);
                        testResult.Glucose = new CompoundResultReading<int?>(ReadingLabels.Glucose)
                        {
                            ReadingSource = ReadingSource.Automatic,
                            Reading = s,
                            Finding = findingId > 0 ? new StandardFinding<int?>(findingId) : null
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                _errorSummary += "Data extraction for Glucose failed. ";
                _logger.Error("\n Data extraction for Glucose failed! Error: " + ex.Message + "\n\t\t" + ex.StackTrace);
            }

            try
            {
                if (!IsDataRowItemEmpty(dr[ColumnLdl]))
                {
                    int s = 0;
                    if (int.TryParse(dr[ColumnLdl].ToString(), out s))
                    {
                        var findingId = _testResultService.GetCalculatedStandardFinding(s, (int)TestType.Lipid,
                                                                                        (int)ReadingLabels.LDL);
                        testResult.LDL = new CompoundResultReading<int?>(ReadingLabels.LDL)
                        {
                            ReadingSource = ReadingSource.Automatic,
                            Reading = s,
                            Finding = findingId > 0 ? new StandardFinding<int?>(findingId) : null
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                _errorSummary += "Data extraction for LDL failed. ";
                _logger.Error("\n Data extraction for LDL failed! Error: " + ex.Message + "\n\t\t" + ex.StackTrace);
            }


            try
            {
                if (!IsDataRowItemEmpty(dr[ColumnTc]))
                {
                    testResult.TotalCholestrol = new CompoundResultReading<string>(ReadingLabels.TotalCholestrol)
                    {
                        ReadingSource = ReadingSource.Automatic,
                        Reading = dr[ColumnTc].ToString()
                    };

                    int s;
                    if (int.TryParse(dr[ColumnTc].ToString(), out s))
                    {
                        var findingId = _testResultService.GetCalculatedStandardFinding(s, (int)TestType.Lipid, (int)ReadingLabels.TotalCholestrol);
                        testResult.TotalCholestrol.Finding = findingId > 0 ? new StandardFinding<string>(findingId) : null;
                    }
                }
            }
            catch (Exception ex)
            {
                _errorSummary += "Data extraction for Total Cholestrol failed. ";
                _logger.Error("\n Data extraction for Total Cholestrol failed! Error: " + ex.Message + "\n\t\t" + ex.StackTrace);
            }

            try
            {
                if (!IsDataRowItemEmpty(dr[ColumnHdl]))
                {
                    testResult.HDL = new CompoundResultReading<string>(ReadingLabels.HDL)
                    {
                        ReadingSource = ReadingSource.Automatic,
                        Reading = dr[ColumnHdl].ToString()
                    };

                    //int s;
                    //if (int.TryParse(dr[ColumnHdl].ToString(), out s))
                    //{
                    //    var findingId = _testResultService.GetCalculatedStandardFinding(s, (int)TestType.Lipid, (int)ReadingLabels.HDL);
                    //    testResult.HDL.Finding = findingId > 0 ? new StandardFinding<string>(findingId) : null;
                    //}
                }
            }
            catch (Exception ex)
            {
                _errorSummary += "Data extraction for HDL failed. ";
                _logger.Error("\n Data extraction for HDL failed! Error: " + ex.Message + "\n\t\t" + ex.StackTrace);
            }

            try
            {
                if (!IsDataRowItemEmpty(dr[ColumnTrig]))
                {
                    testResult.TriGlycerides = new CompoundResultReading<string>(ReadingLabels.TriGlycerides)
                    {
                        ReadingSource = ReadingSource.Automatic,
                        Reading = dr[ColumnTrig].ToString()
                    };

                    int s;
                    if (int.TryParse(dr[ColumnTrig].ToString(), out s))
                    {
                        var findingId = _testResultService.GetCalculatedStandardFinding(s, (int)TestType.Lipid, (int)ReadingLabels.TriGlycerides);
                        testResult.TriGlycerides.Finding = findingId > 0 ? new StandardFinding<string>(findingId) : null;
                    }
                }
            }
            catch (Exception ex)
            {
                _errorSummary += "Data extraction for Triglycerides failed. ";
                _logger.Error("\n Data extraction for Triglycerides failed! Error: " + ex.Message + "\n\t\t" + ex.StackTrace);
            }


            try
            {
                decimal? value = null;
                if (!IsDataRowItemEmpty(dr[ColumnTchdl]))
                {
                    decimal s = 0;
                    if (decimal.TryParse(dr[ColumnTchdl].ToString(), out s))
                    {
                        value = s;
                    }
                }
                else
                {
                    int tc = 0;
                    int hdl = 0;
                    if (testResult.TotalCholestrol != null && int.TryParse(testResult.TotalCholestrol.Reading, out tc) && testResult.HDL != null && int.TryParse(testResult.HDL.Reading, out hdl))
                    {
                        value = ((decimal)tc / hdl);
                    }
                }

                if (value != null)
                {
                    var findingId = _testResultService.GetCalculatedStandardFinding(value, (int)TestType.Lipid, (int)ReadingLabels.TCHDLRatio);
                    testResult.TCHDLRatio = new CompoundResultReading<decimal?>(ReadingLabels.TCHDLRatio)
                                                {
                                                    ReadingSource = ReadingSource.Automatic,
                                                    Reading = value,
                                                    Finding = new StandardFinding<decimal?>(findingId)
                                                };
                }
            }
            catch (Exception ex)
            {
                _errorSummary += "Data extraction for TC-HDL failed. ";
                _logger.Error("\n Data extraction for TC-HDL failed! Error: " + ex.Message + "\n\t\t" + ex.StackTrace);
            }
            return testResult;
        }

        public static bool IsDatatableConversionfromCsvValid(DataTable dtCardiovision)
        {
            if (dtCardiovision.Columns.Contains(ColumnTc) && dtCardiovision.Columns.Contains(ColumnLdl) && dtCardiovision.Columns.Contains(ColumnTrig) &&
                dtCardiovision.Columns.Contains(ColumnHdl) && dtCardiovision.Columns.Contains(ColumnGlu))
                return true;

            return false;
        }

        private static bool CheckifRowContainsAnyReadingData(DataRow dr)
        {
            if (IsDataRowItemEmpty(dr[ColumnTc]) && IsDataRowItemEmpty(dr[ColumnHdl]) && IsDataRowItemEmpty(dr[ColumnLdl]) && IsDataRowItemEmpty(dr[ColumnGlu]) && IsDataRowItemEmpty(dr[ColumnTrig]))
                return false;

            return true;
        }

        private static bool IsDataRowItemEmpty(Object obj)
        {
            if (obj != null && obj != DBNull.Value && !string.IsNullOrEmpty(obj.ToString()))
                return false;

            return true;
        }
    }
}