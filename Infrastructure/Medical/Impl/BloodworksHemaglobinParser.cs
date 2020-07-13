using System;
using System.Data;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    public class BloodworksHemaglobinParser : ICsvTestParser
    {
        private ILogger _logger;
        private string _errorSummary;
        public string ErrorSummary
        {
            get { return _errorSummary; }
        }

        private const string ColumnA1c = "A1C";

        public BloodworksHemaglobinParser(ILogger logger)
        {
            _logger = logger;
        }

        public TestResult Parse(DataRow dr)
        {
            _errorSummary = string.Empty;
            var testResult = new HemaglobinA1CTestResult();
            if (IsDataRowItemEmpty(dr[ColumnA1c])) return null;

            try
            {
                if (!IsDataRowItemEmpty(dr[ColumnA1c]))
                {
                    testResult.Hba1c = new ResultReading<string>(ReadingLabels.Hba1c)
                                           {
                                               ReadingSource = ReadingSource.Automatic,
                                               Reading = dr[ColumnA1c].ToString()
                                           };
                }
            }
            catch (Exception ex)
            {
                _errorSummary += "Data extraction for Hba1c failed. ";
                _logger.Error("\n Data extraction for Hba1c failed! Error: " + ex.Message + "\n\t\t" + ex.StackTrace);
            }

            return testResult;
        }

        private static bool IsDataRowItemEmpty(Object obj)
        {
            if (obj != null && obj != DBNull.Value && !string.IsNullOrEmpty(obj.ToString()))
                return false;

            return true;
        }

    }
}