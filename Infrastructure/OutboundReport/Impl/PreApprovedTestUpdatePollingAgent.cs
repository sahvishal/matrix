using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.OutboundReport;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.OutboundReport.Impl
{
    [DefaultImplementation]
    public class PreApprovedTestUpdatePollingAgent : IPreApprovedTestUpdatePollingAgent
    {
        private readonly ISettings _settings;
        private readonly ICsvReader _csvReader;
        private readonly ILogger _logger;
        private readonly IChaseOutboundRepository _chaseOutboundRepository;
        private readonly IPreApprovedTestRepository _preApprovedTestRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;

        public PreApprovedTestUpdatePollingAgent(ISettings settings, ICsvReader csvReader, ILogManager logManager, IChaseOutboundRepository chaseOutboundRepository, IPreApprovedTestRepository preApprovedTestRepository,
            IOrganizationRoleUserRepository organizationRoleUserRepository)
        {
            _settings = settings;
            _csvReader = csvReader;
            _chaseOutboundRepository = chaseOutboundRepository;
            _preApprovedTestRepository = preApprovedTestRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _logger = logManager.GetLogger("PreApprovedTestUpdate");
        }

        public void PollForUpdate()
        {
            var files = DirectoryOperationsHelper.GetFiles(_settings.MediaLocation + "\\PreAppprovedTest", "*PreAppprovedTest*.csv");

            var createdBy = _organizationRoleUserRepository.GetOrganizationRoleUser(1);

            foreach (var file in files)
            {
                _logger.Info("Parsing file : " + file);

                DataTable table = _csvReader.ReadWithTextQualifier(file);

                if (table.Rows.Count <= 0)
                {
                    _logger.Info("No records found.");
                    continue;
                }

                foreach (DataRow row in table.Rows)
                {
                    var clientId = GetRowValue(row, "Client_Id");
                    //var contractNumber = GetRowValue(row, "Contract_Number");
                    var preApprovedTests = GetPreApprovedTests(row, "Pre-approved tests");

                    if (string.IsNullOrEmpty(clientId))// || string.IsNullOrEmpty(contractNumber)
                    {
                        _logger.Info("Skipping row : Client Id blank.");//or Contract Number 
                        continue;
                    }

                    var chaseOutbound = _chaseOutboundRepository.GetByClientId(clientId);

                    if (chaseOutbound == null)
                    {
                        _logger.Info(string.Format("Chase data not found for Client Id : {0}", clientId));
                        continue;
                    }

                    if (preApprovedTests != null && preApprovedTests.Any())
                    {
                        var pairs = TestType.A1C.GetNameValuePairs();
                        var preApprovedTestExists = pairs.Where(x => preApprovedTests.Contains(x.SecondValue.ToLower())).Select(x => x.SecondValue.ToLower());

                        var testNotExist = string.Empty;

                        if (preApprovedTestExists != null && preApprovedTestExists.Any() && (preApprovedTestExists.Count() != preApprovedTests.Count()))
                        {
                            var testNotExistInSystem = preApprovedTests.Where(x => !preApprovedTestExists.Contains(x.ToLower())).Select(x => x).ToArray();

                            testNotExist = string.Join(",", testNotExistInSystem);
                        }
                        else if (preApprovedTestExists == null || !preApprovedTestExists.Any())
                        {
                            testNotExist = string.Join(",", preApprovedTests);
                        }

                        if (!string.IsNullOrEmpty(testNotExist))
                        {
                            _logger.Info(testNotExist + " test alias name does not exist in HIP");
                            continue;
                        }

                        var preApprovedTestIds = pairs.Where(x => preApprovedTests.Contains(x.SecondValue.ToLower())).Select(x => (long)x.FirstValue);
                        if (preApprovedTestIds != null && preApprovedTestIds.Any())
                        {
                            _preApprovedTestRepository.SavePreApprovedTests(chaseOutbound.CustomerId, preApprovedTestIds, createdBy.Id);

                            _logger.Info(string.Format("Pre-approved tests updated for Client Id : {0}", clientId));
                        }
                    }
                }

                _logger.Info("Parsed file : " + file);
            }
        }

        private static string GetRowValue(DataRow row, string fieldName, bool format = false)
        {
            if (row == null || row[fieldName] == null || row[fieldName] == DBNull.Value) return string.Empty;
            if (format)
                return FormatSentence(row[fieldName].ToString().Trim());
            return row[fieldName].ToString().Trim();
        }

        private static string FormatSentence(string source)
        {
            var words = source.Split(' ').Select(t => t.ToCharArray()).ToList();
            words.ForEach(t =>
            {
                for (int i = 0; i < t.Length; i++)
                {
                    t[i] = i.Equals(0) ? char.ToUpper(t[i]) : char.ToLower(t[i]);
                }
            });
            return string.Join(" ", words.Select(t => new string(t)));
        }

        public IEnumerable<string> GetPreApprovedTests(DataRow row, string fieldName)
        {
            if (row == null || row[fieldName] == null || row[fieldName] == DBNull.Value || string.IsNullOrWhiteSpace(row[fieldName].ToString())) return null;

            return row[fieldName].ToString().Split(',').Select(x => x.Trim().ToLower()).ToList();
        }
    }
}
