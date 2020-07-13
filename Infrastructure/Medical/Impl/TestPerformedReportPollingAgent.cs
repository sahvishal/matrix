using System;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class TestPerformedReportPollingAgent : ITestPerformedReportPollingAgent
    {
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly ITestResultService _testResultService;
        //private readonly IBaseExportableReportHelper _baseExportableReportHelper;
        private readonly ITestPerformedCsvExportHelper _testPerformedCsvExportHelper;
        private readonly ILogger _logger;
        private readonly int _dayOfMonth;
        private readonly string _reportDestinationPath;

        public TestPerformedReportPollingAgent(ICorporateAccountRepository corporateAccountRepository, ILogManager logManager, ISettings settings,
            ITestResultService testResultService, ITestPerformedCsvExportHelper testPerformedCsvExportHelper)
        {
            _corporateAccountRepository = corporateAccountRepository;
            _testResultService = testResultService;
            //_baseExportableReportHelper = baseExportableReportHelper;
            _testPerformedCsvExportHelper = testPerformedCsvExportHelper;
            _reportDestinationPath = settings.ReportDestinationPath;
            _dayOfMonth = settings.DayOfMonthServiceRun;
            _logger = logManager.GetLogger("Reporting Service");
        }

        public void PollForTestPerformedReports()
        {
            try
            {
                if (_dayOfMonth != DateTime.Today.Day)
                {
                    _logger.Info(string.Format("Report will not be generated today as it set to {0} of every month", _dayOfMonth));
                    return;
                }

                var healthPlans = _corporateAccountRepository.GetAllHealthPlan();
                _logger.Info(string.Format("health plan count " + healthPlans.Count()));

                if (!healthPlans.Any()) return;

                _logger.Info(string.Format("destination Path for All Reports {0}", _reportDestinationPath));

                foreach (var healthPlan in healthPlans)
                {
                    try
                    {
                        var directoryPath = string.Format(_reportDestinationPath, healthPlan.Tag);

                        CreateDistinationDirectory(directoryPath);
                        var reportingMonth = DateTime.Today.AddMonths(-1);

                        var dateFrom = reportingMonth.GetFirstDayOfMonth();
                        var dateTo = reportingMonth.GetLastDayOfMonth();

                        var fileName = string.Format("{0}_{1}_{2}.csv", healthPlan.Tag, dateFrom.ToString("MMMM"), dateFrom.ToString("yyyy"));

                        var filter = new TestPerformedListModelFilter
                        {
                            EventDateFrom = dateFrom,
                            EventDateTo = dateTo,
                            HealthPlanId = healthPlan.Id,
                            Tag = healthPlan.Tag
                        };

                        _logger.Info("generating Report for " + healthPlan.Tag);

                        var dataGen = new ExportableDataGenerator<TestPerformedViewModel, TestPerformedListModelFilter>(_testResultService.GetTestPerformed, _logger);

                        var model = dataGen.GetData(filter);

                        if (model != null && !model.Collection.IsNullOrEmpty())
                        {
                            var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<TestPerformedViewModel>();

                            _logger.Info("Record count" + model.Collection.Count());

                            if (File.Exists(directoryPath + fileName)) File.Delete(directoryPath + fileName);
                            //_baseExportableReportHelper.GenerateCsv(directoryPath + fileName, exporter, model.Collection);
                            _testPerformedCsvExportHelper.WriteCsvTestPerformed(directoryPath, fileName, model.Collection);
                        }
                        else
                        {
                            _logger.Info("No Record Found for Tag" + healthPlan.Tag);
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.Error("Some Error occurred  for Tag" + healthPlan.Tag);
                        _logger.Error("Message: " + ex.Message);
                        _logger.Error("Stack Trace: " + ex.StackTrace);
                    }

                }
            }
            catch (Exception exception)
            {
                _logger.Error("Some Error occurred  ");
                _logger.Error("Message: " + exception.Message);
                _logger.Error("Stack Trace: " + exception.StackTrace);
            }

        }

        private void CreateDistinationDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);
        }
    }
}
