using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class AppointmentEncounterPollingAgent : IAppointmentEncounterPollingAgent
    {
        private readonly IAppointmentEncounterService _appointmentEncounterService;
        private readonly ISettings _settings;
        private readonly IUniqueItemRepository<CorporateAccount> _corporateAccountRepository;
        private readonly IBaseExportableReportHelper _baseExportableReportHelper;
        private readonly ILogger _logger;



        public AppointmentEncounterPollingAgent(IAppointmentEncounterService appointmentEncounterService, ILogManager logManager,
            ISettings settings, IUniqueItemRepository<CorporateAccount> corporateAccountRepository, IBaseExportableReportHelper baseExportableReportHelper)
        {
            _appointmentEncounterService = appointmentEncounterService;
            _settings = settings;
            _corporateAccountRepository = corporateAccountRepository;
            _baseExportableReportHelper = baseExportableReportHelper;
            _logger = logManager.GetLogger("AppointmentEncounterPollingAgent");
        }

        public void PollForAppointmentEncounterData()
        {
            try
            {
                if (_settings.AppointmentEncounterReportAccountIds.IsNullOrEmpty())
                {
                    _logger.Info("No Account found for AppointmentHeader");
                    return;
                }

                var corporateAccounts = _corporateAccountRepository.GetByIds(_settings.AppointmentEncounterReportAccountIds);
                if (corporateAccounts.IsNullOrEmpty())
                {
                    _logger.Info("No Account found for AppointmentHeader");
                    return;
                }

                foreach (var account in corporateAccounts)
                {
                    try
                    {
                        _logger.Info("running Report for account tag " + account.Tag);

                        var fromDate = DateTime.Today.GetFirstDateOfYear();
                        var toDate = DateTime.Today.GetLastDateOfYear();

                        var filter = new AppointmentEncounterFilter
                        {
                            AccountId = account.Id,
                            EventFromDate = fromDate,
                            EventToDate = toDate,
                            Tag = account.Tag
                        };

                        var dataGen = new ExportableDataGenerator<AppointmentEncounterModel, AppointmentEncounterFilter>(_appointmentEncounterService.GetAppointmentEncounterReport, _logger);
                        var model = dataGen.GetData(filter);

                        if (model != null && !model.Collection.IsNullOrEmpty())
                        {
                            _logger.Info("Writing Event Schedule Report");
                            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<AppointmentEncounterModel>();

                            _logger.Info("Record count" + model.Collection.Count());
                            var folderLocation = string.Format(_settings.AppointmentEncounterReportPath, account.FolderName);

                            if (_settings.OptumAccountIds.Contains(account.Id))
                            {
                                try
                                {
                                    DirectoryOperationsHelper.DeleteDirectory(folderLocation, true);
                                }
                                catch (Exception ex)
                                {
                                    _logger.Error("Some error occurred while deleting directory at path: " + folderLocation);
                                    _logger.Error("Message: " + ex.Message);
                                    _logger.Error("Stack Trace: " + ex.StackTrace);
                                }
                            }

                            DirectoryOperationsHelper.CreateDirectoryIfNotExist(folderLocation);
                            var fileName = string.Format("EncounterHeader_{0}.csv", DateTime.Today.ToString("yyyyMMdd"));

                            var completePath = Path.Combine(folderLocation, fileName);
                            DirectoryOperationsHelper.DeleteFileIfExist(completePath);

                            _baseExportableReportHelper.GenerateCsv(completePath, exporter, model.Collection);

                            _logger.Info("completed Report for account tag " + account.Tag);
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("some Error occurred While Appointment Encounter for Account Tag: " + account.Tag);
                        _logger.Error("Message: " + ex.Message);
                        _logger.Error("Stack Trace: " + ex.StackTrace);
                    }

                }
            }
            catch (Exception ex)
            {
                _logger.Error("some Error occurred While Appointment Encounter: ");
                _logger.Error("Message: " + ex.Message);
                _logger.Error("Stack Trace: " + ex.StackTrace);
            }
        }
    }
}
