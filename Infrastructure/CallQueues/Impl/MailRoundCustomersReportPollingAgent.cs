using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Falcon.App.Core.Extensions;

namespace Falcon.App.Infrastructure.CallQueues.Impl
{
    [DefaultImplementation]
    public class MailRoundCustomersReportPollingAgent : IMailRoundCustomersReportPollingAgent
    {
        private readonly ISettings _settings;
        private readonly ILogger _logger;
        private readonly ICallQueueCustomerReportService _callQueueCustomerReportService;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly ICallQueueRepository _callQueueRepository;
        private readonly IBaseExportableReportHelper _baseExportableReportHelper;
        private readonly IHealthPlanOutboundCallQueueService _healthPlanOutboundCallQueueService;

        public MailRoundCustomersReportPollingAgent(ISettings settings, ILogManager logManager, ICallQueueCustomerReportService callQueueCustomerReportService,
            ICorporateAccountRepository corporateAccountRepository, ICallQueueRepository callQueueRepository, IBaseExportableReportHelper baseExportableReportHelper,
            IHealthPlanOutboundCallQueueService healthPlanOutboundCallQueueService)
        {
            _settings = settings;
            _logger = logManager.GetLogger("MailRoundCustomersReportPollingAgent");
            _callQueueCustomerReportService = callQueueCustomerReportService;
            _corporateAccountRepository = corporateAccountRepository;
            _callQueueRepository = callQueueRepository;
            _baseExportableReportHelper = baseExportableReportHelper;
            _healthPlanOutboundCallQueueService = healthPlanOutboundCallQueueService;
        }

        public void PollMailRoundCustomersReport()
        {
            try
            {
                _logger.Info("Entering Matrix Report Polling Agent");

                var healthPlans = _corporateAccountRepository.GetAllHealthPlan();
                var callQueues = _callQueueRepository.GetAll(false, true);

                if (callQueues.IsNullOrEmpty())
                {
                    _logger.Info("No call queue found.");
                    return;
                }
                var mailRoundCallQueue = callQueues.FirstOrDefault(x => x.Category == HealthPlanCallQueueCategory.MailRound);
                var fillEventCallQueue = callQueues.FirstOrDefault(x => x.Category == HealthPlanCallQueueCategory.FillEventsHealthPlan);
                var languageBarrierCallQueue = callQueues.FirstOrDefault(x => x.Category == HealthPlanCallQueueCategory.LanguageBarrier);

                foreach (var healthPlan in healthPlans)
                {
                    try
                    {
                        _logger.Info(string.Format("Generating Matrix Report for accountId {0} and account tag {1}. ", healthPlan.Id, healthPlan.Tag));

                        var destinationPath = _settings.MailRoundCustomersReportDestinantionPath;

                        var filePath = Path.Combine(destinationPath, string.Format(@"MatrixReport_{0}_{1}.csv", healthPlan.Tag, DateTime.Now.ToString("MMddyyyy")));

                        DirectoryOperationsHelper.CreateDirectory(destinationPath);

                        var customers = new List<MailRoundCustomersReportViewModel>();

                        _logger.Info("Fetching customers for fill event call queue");
                        var fillEventCustomers = GetCustomersForMatrixReport(healthPlan.Id, fillEventCallQueue);
                        if (!fillEventCustomers.IsNullOrEmpty())
                            customers.AddRange(fillEventCustomers);
                        else
                            _logger.Info("No customers found for fill event call queue");


                        _logger.Info("Fetching customers for mail round call queue");
                        var mailRoundCustomers = GetCustomersForMatrixReport(healthPlan.Id, mailRoundCallQueue);
                        if (!mailRoundCustomers.IsNullOrEmpty())
                        {
                            if (!customers.IsNullOrEmpty())
                            {
                                var existingCustomerIds = customers.Select(c => c.CustomerID);
                                mailRoundCustomers = mailRoundCustomers.Where(x => !existingCustomerIds.Contains(x.CustomerID)).ToList();
                            }
                            customers.AddRange(mailRoundCustomers);
                        }
                        else
                            _logger.Info("No customers found for mail round call queue");


                        _logger.Info("Fetching customers for language barrier call queue");
                        var languageBarrierCustomers = GetCustomersForMatrixReport(healthPlan.Id, languageBarrierCallQueue);
                        if (!languageBarrierCustomers.IsNullOrEmpty())
                        {
                            if (!customers.IsNullOrEmpty())
                            {
                                var existingCustomerIds = customers.Select(c => c.CustomerID);
                                languageBarrierCustomers = languageBarrierCustomers.Where(x => !existingCustomerIds.Contains(x.CustomerID)).ToList();
                            }
                            customers.AddRange(languageBarrierCustomers);
                        }
                        else
                            _logger.Info("No customers found for language barrier call queue");


                        if (customers.Any())
                        {
                            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<MailRoundCustomersReportViewModel>();
                            DirectoryOperationsHelper.DeleteFileIfExist(filePath);

                            _baseExportableReportHelper.GenerateCsv(filePath, exporter, customers);
                            _logger.Error(string.Format("Successfully Matrix Report Generated for AccountId {0} and Account Tag {1}.", healthPlan.Id, healthPlan.Tag));
                        }
                        else
                        {
                            _logger.Error(string.Format("No records found for AccountId {0} and Account Tag {1}. \n\n", healthPlan.Id, healthPlan.Tag));
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(string.Format("Error occured while generating Matrix Report for AccountId {0} and Account Tag {1} : \n Error {2} \n Trace: {3} ", healthPlan.Id, healthPlan.Tag, ex.Message, ex.StackTrace));
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Error occured while generating Matrix Report : \n Error {0} \n Trace: {1} ", ex.Message, ex.StackTrace));
            }
        }

        private List<MailRoundCustomersReportViewModel> GetCustomersForMatrixReport(long healthPlanId, CallQueue callQueue)
        {
            var list = new List<MailRoundCustomersReportViewModel>();
            if (callQueue == null) return list;

            var pageNumber = 1;
            const int pageSize = 100;

            var filter = new OutboundCallQueueFilter();
            filter.HealthPlanId = healthPlanId;
            filter.CallQueueId = callQueue.Id;
            filter.GmsAccountIds = _settings.GmsAccountIds;

            _healthPlanOutboundCallQueueService.GetAccountCallQueueSettingForCallQueue(filter);

            while (true)
            {
                int totalRecords;
                var model = _callQueueCustomerReportService.GetCustomersForMatrixReport(pageNumber, pageSize, filter, callQueue, out totalRecords);
                if (model == null || model.Collection == null || !model.Collection.Any()) break;

                list.AddRange(model.Collection);
                _logger.Info(String.Format("\n\nPageNumber:{0} TotalRecords: {1},  Current Length: {2}", pageNumber, totalRecords, list.Count));

                pageNumber++;

                if (list.Count >= totalRecords)
                    break;
            }
            return list;
        }
    }
}
