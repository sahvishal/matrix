using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Falcon.App.Core.Extensions;
using Falcon.App.Infrastructure.Application.Impl;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class WellCarePcpSummaryLogReportPollingAgent : IWellCarePcpSummaryLogReportPollingAgent
    {
        private readonly ILogger _logger;

        private readonly ICustomSettingManager _customSettingManager;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IBaseExportableReportHelper _baseExportableReportHelper;
        private readonly IPcpSummaryLogReportService _pcpSummaryLogReportService;

        private readonly IEnumerable<long> _accountIds;
        private readonly DateTime _cutOfDate;
        private readonly string _destinationFolderPdfPath;

        private readonly string _wellCarePcpSummaryLogReportSettingPath;
        private readonly DayOfWeek _wellCarePcpSummaryLogReportDayOfWeek;
        private readonly ISettings _settings;

        private bool FirstReportGenerated = false;

        public WellCarePcpSummaryLogReportPollingAgent(ILogManager logManager, ICustomSettingManager customSettingManager, ICorporateAccountRepository corporateAccountRepository,
            IBaseExportableReportHelper baseExportableReportHelper, ISettings settings, IPcpSummaryLogReportService pcpSummaryLogReportService)
        {
            _logger = logManager.GetLogger("WellCarePcpSummaryLogReport");

            _customSettingManager = customSettingManager;
            _corporateAccountRepository = corporateAccountRepository;
            _baseExportableReportHelper = baseExportableReportHelper;
            _pcpSummaryLogReportService = pcpSummaryLogReportService;
            _settings = settings;
            _accountIds = settings.WellCareAccountIds;
            _cutOfDate = settings.WellCarePcpSummaryLogCutOfDate;

            _destinationFolderPdfPath = settings.WellCarePcpSummaryLogDownloadPath;
            _wellCarePcpSummaryLogReportSettingPath = settings.WellCarePcpSummaryLogReportSettingPath;
            _wellCarePcpSummaryLogReportDayOfWeek = settings.WellCarePcpSummaryLogReportDayOfWeek;
        }


        public void PollForPcpLogSummaryReportExport()
        {
            try
            {
                if (_wellCarePcpSummaryLogReportDayOfWeek != DateTime.Today.DayOfWeek)
                {
                    _logger.Info("Report is schedule to run on " + _wellCarePcpSummaryLogReportDayOfWeek);
                    _logger.Info("Today is day of week " + DateTime.Today.DayOfWeek);
                    _logger.Info(string.Format("Set day of week to {0} to run today ", ((int)DateTime.Today.DayOfWeek)));
                    return;
                }

                if (_accountIds.IsNullOrEmpty())
                {
                    _logger.Info("No Account Ids found");
                    return;
                }


                var directoryPath = _destinationFolderPdfPath + "\\";

                CreateDestinationDirectory(directoryPath);

                var toDate = DateTime.Now;

                var fileName = string.Format("PCPSummaryLog-HealthFair-{0}.csv", toDate.ToString("yyyyMMdd"));


                var accounts = _corporateAccountRepository.GetByIds(_accountIds);

                var model = new PcpSummaryLogReportListModel();

                foreach (var account in accounts)
                {
                    _logger.Info("Running Report for Tag: " + account.Tag);

                    try
                    {
                        var serviceReportSettings = string.Format(_wellCarePcpSummaryLogReportSettingPath, account.Tag);
                        var customSettings = _customSettingManager.Deserialize(serviceReportSettings);

                        var fromDate = (customSettings.LastTransactionDate != null) ? customSettings.LastTransactionDate.Value : _cutOfDate;

                        var listModel = PcpSummaryLogReport(account, fromDate, toDate, directoryPath, fileName);
                        if (listModel != null && !listModel.Collection.IsNullOrEmpty())
                        {
                            if (model.Collection.IsNullOrEmpty())
                                model.Collection = listModel.Collection;
                            else
                                model.Collection = model.Collection.Concat(listModel.Collection);
                        }

                        customSettings.LastTransactionDate = toDate;
                        _customSettingManager.SerializeandSave(serviceReportSettings, customSettings);
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Some Error occurred  for Tag" + account.Tag);
                        _logger.Error("Message: " + ex.Message);
                        _logger.Error("Stack Trace: " + ex.StackTrace);
                    }
                }

                if (model != null && !model.Collection.IsNullOrEmpty())
                {
                    model.Collection = model.Collection.OrderBy(x => x.PcpMailedDate).ThenBy(x => x.EventId);

                    var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<PcpSummaryLogReportModel>();

                    _logger.Info("Record count" + model.Collection.Count());

                    if (File.Exists(directoryPath + fileName) && !FirstReportGenerated)
                        File.Delete(directoryPath + fileName);

                    FirstReportGenerated = _baseExportableReportHelper.GenerateCsv(directoryPath + fileName, exporter, model.Collection, skipHeader: FirstReportGenerated);


                    _logger.Info("Destination file " + directoryPath + fileName);
                }
                else
                {
                    _logger.Info(string.Format("No Data found for PCP summary log Period {0} ", toDate));
                }

                if (_settings.SendPdfToWellCareSftp)
                    ExportResultOnWellCareSftp(fileName, directoryPath + fileName);
            }
            catch (Exception ex)
            {
                _logger.Error("Message: " + ex.Message);
                _logger.Error("Stack Trace: " + ex.StackTrace);
            }
        }

        private ListModelBase<PcpSummaryLogReportModel, PcpSummaryLogReportModelFilter> PcpSummaryLogReport(CorporateAccount account, DateTime dateFrom, DateTime dateTo, string directoryPath, string fileName)
        {

            var filter = new PcpSummaryLogReportModelFilter
            {
                DateFrom = dateFrom,
                DateTo = dateTo,
                HealthPlanId = account.Id,
                Tag = account.Tag
            };

            _logger.Info("Generating Summary Log for " + account.Tag);

            var dataGen = new ExportableDataGenerator<PcpSummaryLogReportModel, PcpSummaryLogReportModelFilter>(_pcpSummaryLogReportService.GetPcpSummaryLogReport, _logger);

            var model = dataGen.GetData(filter);


            //if (model != null && !model.Collection.IsNullOrEmpty())
            //{
            //    var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<PcpSummaryLogReportModel>();

            //    _logger.Info("Record count" + model.Collection.Count());

            //    if (File.Exists(directoryPath + fileName) && !FirstReportGenerated)
            //        File.Delete(directoryPath + fileName);

            //    FirstReportGenerated = _baseExportableReportHelper.GenerateCsv(directoryPath + fileName, exporter, model.Collection, skipHeader: FirstReportGenerated);


            //    _logger.Info("Destination file " + directoryPath + fileName);
            //}
            //else
            //{
            //    _logger.Info("No Record Found for Tag" + account.Tag);
            //}

            _logger.Info("Completed Summary Log for " + account.Tag);

            return model;
        }

        private void CreateDestinationDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);
        }

        private void ExportResultOnWellCareSftp(string fileName, string sourcePath)
        {
            _logger.Info("Destination Path:  " + _settings.WellCareSftpPath);
            _logger.Info("File Name Path:  " + fileName);
            _logger.Info("Source Path: " + sourcePath);

            var processFtp = new ProcessFtp(_logger, _settings.WellCareSftpHost, _settings.WellCareSftpUserName, _settings.WellCareSftpPassword);
            processFtp.UploadSingleFile(sourcePath, _settings.WellCareSftpPath, fileName);
        }


    }
}
