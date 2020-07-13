using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.CallCenter.Enum;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class HealthPlanMemberStatusReportPollingAgent : IHealthPlanMemberStatusReportPollingAgent
    {
        private readonly IEventCustomerReportingService _eventCustomerReportingService;
        private readonly IUniqueItemRepository<CorporateAccount> _corporateAccountRepository;
        private readonly IBaseExportableReportHelper _baseExportableReportHelper;
        private readonly ILogger _logger;
        private readonly ISettings _settings;

        private readonly string _healthPlanMemberStatusDestinationPath;
        private readonly IEnumerable<long> _accountIds;
        private readonly string _bcbsSouthCarolinaCustomTag;
        public HealthPlanMemberStatusReportPollingAgent(IEventCustomerReportingService eventCustomerReportingService, IUniqueItemRepository<CorporateAccount> corporateAccountRepository,
            ILogManager logManager, ISettings settings, IBaseExportableReportHelper baseExportableReportHelper)
        {
            _eventCustomerReportingService = eventCustomerReportingService;
            _corporateAccountRepository = corporateAccountRepository;
            _baseExportableReportHelper = baseExportableReportHelper;
            _logger = logManager.GetLogger("Health Plan Member Status Report ");
            _settings = settings;

            _accountIds = settings.HealthPlanMemberStatusReportAccountIds;
            _healthPlanMemberStatusDestinationPath = settings.HealthPlanMemberStatusReportFileReportPath;
            _bcbsSouthCarolinaCustomTag = settings.BcbsSouthCarolinaCustomTag;
        }

        public void PollForMemberStatusReport()
        {
            try
            {
                if (_accountIds.IsNullOrEmpty())
                {
                    _logger.Info("Corporate Account Ids Not found");
                    return;
                }

                var accounts = _corporateAccountRepository.GetByIds(_accountIds);

                if (accounts.IsNullOrEmpty())
                {
                    _logger.Info("Corporate Accounts Not found");
                    return;
                }

                foreach (var account in accounts)
                {
                    try
                    {
                        _logger.Info("Starting for Member Status Report for " + account.Tag);

                        var bcbsTags = new string[0];

                        if (account.Id == _settings.BcbsScAccountId && !string.IsNullOrEmpty(_bcbsSouthCarolinaCustomTag))
                        {
                            bcbsTags = _bcbsSouthCarolinaCustomTag.Split(',').ToArray();
                            bcbsTags = bcbsTags.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                        }

                        var filter = new MemberStatusListModelFilter
                        {
                            EligibleStatus = EligibleFilterStatus.OnlyEligible,
                            IncludeDoNotContact = true,
                            DoNotContactOnly = false,
                            Tag = account.Tag,
                            CustomTags = bcbsTags,
                            CallAttemptFilter = CallAttemptFilterStatus.All,
                        };

                        GenerateMemberStatusListCsvByFilter(filter, account);

                        _logger.Info("Completed for Member Status Report for " + account.Tag);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Some error occured on Member status Report for Account Tag : " + account.Tag);
                        _logger.Error("Exception: " + ex.Message);
                        _logger.Error("Stack Trace: " + ex.StackTrace);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Some error occured on Member status Report");
                _logger.Error("Exception: " + ex.Message);
                _logger.Error("Stack Trace: " + ex.StackTrace);
            }
        }
        private void GenerateMemberStatusListCsvByFilter(MemberStatusListModelFilter filter, CorporateAccount account)
        {
            _logger.Info(string.Format("Generating Member Status Report for filter :  Tag {0}", filter.Tag));

            var dataGen = new ExportableDataGenerator<MemberStatusModel, MemberStatusListModelFilter>(_eventCustomerReportingService.GetMemberStatusReport, _logger);
            var model = dataGen.GetData(filter);

            if (model != null)
            {
                var fileName = GetCsvFileName(account);

                var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<MemberStatusModel>();

                if (model.Collection != null && model.Collection.Any())
                {
                    _baseExportableReportHelper.GenerateCsv(fileName, exporter, model.Collection);
                }
            }
        }
        private string GetCsvFileName(CorporateAccount account)
        {
            var folderLocation = string.Format(_settings.HealthPlanExportRootPath, account.FolderName);

            if (!Directory.Exists(folderLocation))
                Directory.CreateDirectory(folderLocation);

            var csvFileName = string.Format("MemberStatusReport.csv");

            var fileName = folderLocation + "\\" + csvFileName;

            if (File.Exists(fileName))
                File.Delete(fileName);

            return fileName;
        }
    }
}