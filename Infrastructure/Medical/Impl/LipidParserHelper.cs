using System;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Enum;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class LipidParserHelper : ILipidParserHelper
    {
        private ILogger _logger;
        private readonly Service.TestResultService _testResultService;
        private readonly ICustomerRepository _customerRepository;

        public LipidParserHelper(ILogManager logManager, ICustomerRepository customerRepository)
        {
            _logger = logManager.GetLogger<LipidParserHelper>();
            _testResultService = new Service.TestResultService();
            _customerRepository = customerRepository;
        }

        public void SetLogger(ILogger logger)
        {
            _logger = logger;
        }

        private CompoundResultReading<T> GetResultReading<T>(T reading, ReadingLabels label, int? readingForFinding, TestType type, ref string errorSummary)
        {
            try
            {
                var resultReading = new CompoundResultReading<T>
                {
                    Label = label,
                    ReadingSource = ReadingSource.Automatic,
                    Reading = reading
                };

                if (readingForFinding != null)
                {
                    resultReading.Finding = new StandardFinding<T>(_testResultService.GetCalculatedStandardFinding(readingForFinding, (int)type, (int)label));
                }

                return resultReading;
            }
            catch (Exception ex)
            {
                string message = string.Format("Exception while extracting value for {0}. Message: {1} ", label.ToString(), ex.Message);
                _logger.Error(message);
                errorSummary += message;
            }

            return null;
        }

        private CompoundResultReading<decimal?> GetResultReading(decimal reading, ReadingLabels label, TestType type, ref string errorSummary)
        {
            try
            {
                var resultReading = new CompoundResultReading<decimal?>
                {
                    Label = label,
                    ReadingSource = ReadingSource.Automatic,
                    Reading = reading,
                    Finding = new StandardFinding<decimal?>(_testResultService.GetCalculatedStandardFinding(reading, (int)type, (int)label))
                };

                return resultReading;
            }
            catch (Exception ex)
            {
                string message = string.Format("Exception while extracting value for {0}. Message: {1} ", label.ToString(), ex.Message);
                _logger.Error(message);
                errorSummary += message;
            }

            return null;
        }

        private CompoundResultReading<string> GetResultReadingHdl(string reading, int? readingForFinding, long customerId, TestType type, ref string errorSummary)
        {
            try
            {
                var resultReading = new CompoundResultReading<string>
                {
                    Label = ReadingLabels.HDL,
                    ReadingSource = ReadingSource.Automatic,
                    Reading = reading
                };

                string gender = string.Empty;
                var customer = _customerRepository.GetCustomer(customerId);
                if (customer.Gender == Gender.Male)
                    gender = Gender.Male.ToString();
                else if (customer.Gender == Gender.Female)
                    gender = Gender.Female.ToString();

                if (readingForFinding != null && !string.IsNullOrEmpty(gender))
                {
                    var findings = _testResultService.GetAllStandardFindings<int?>((int)type, (int)ReadingLabels.HDL);

                    var specificFindings = findings.Where(x => x.Label.ToLower().StartsWith(gender.ToLower())).ToList();

                    resultReading.Finding = new StandardFinding<string>(_testResultService.GetCalculatedStandardFinding(readingForFinding, (int)type, (int)ReadingLabels.HDL, specificFindings));
                }

                return resultReading;
            }
            catch (Exception ex)
            {
                string message = string.Format("Exception while extracting value for {0}. Message: {1} ", ReadingLabels.HDL, ex.Message);
                _logger.Error(message);
                errorSummary += message;
            }

            return null;
        }

        public CompoundResultReading<int?> GetReading(string reading, ReadingLabels label, TestType type, ref string errorSummary)
        {
            if (!string.IsNullOrEmpty(reading))
            {
                int s;
                if (int.TryParse(reading, out s))
                {
                    return GetResultReading((int?)s, label, s, type, ref errorSummary);
                }
            }
            return null;
        }

        public CompoundResultReading<string> GetReading(string reading, ReadingLabels label, ref decimal? value, TestType type, ref string errorSummary)
        {
            if (!string.IsNullOrEmpty(reading))
            {
                int s;
                if (!int.TryParse(reading, out s)) return GetResultReading(s.ToString(), label, null, type, ref  errorSummary);
                if (s > 0) value = s;
                return GetResultReading(s.ToString(), label, s, type, ref  errorSummary);
            }
            return null;
        }

        public CompoundResultReading<string> GetHdlReading(string reading, long customerId, ref decimal? value, TestType type, ref string errorSummary)
        {
            if (!string.IsNullOrEmpty(reading))
            {
                int s;

                if (!int.TryParse(reading, out s)) return GetResultReading(reading, ReadingLabels.HDL, null, type, ref errorSummary);
                value = s;

                return GetResultReadingHdl(reading, s, customerId, type, ref errorSummary);
            }

            return null;
        }

        public CompoundResultReading<decimal?> GetHdlTclRatio(decimal? hdl, decimal? tchol, TestType type, ref string errorSummary)
        {
            if (hdl == null || tchol == null) return null;

            var s = tchol.Value / hdl.Value;
            s = decimal.Round(s, 2);
            return GetResultReading(s, ReadingLabels.TCHDLRatio, type, ref errorSummary);
        }
    }
}