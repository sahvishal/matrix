using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Impl;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;


namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class TestNotPerformedReportPollingAgent : ITestNotPerformedReportPollingAgent
    {
        private readonly ITestNotPerformedService _testNotPerformedService;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IBaseExportableReportHelper _baseExportableReportHelper;

        private readonly string _healthPlanTestNotPerformedExportDownloadPath;
        private readonly DayOfWeek _dayOfWeek;
        private readonly ILogger _logger;
        private readonly DateTime _cutOfDate;

        public TestNotPerformedReportPollingAgent(ITestNotPerformedService testNotPerformedService, ISettings settings, ILogManager logManager,
            ICorporateAccountRepository corporateAccountRepository, IBaseExportableReportHelper baseExportableReportHelper)
        {
            _testNotPerformedService = testNotPerformedService;
            _corporateAccountRepository = corporateAccountRepository;
            _baseExportableReportHelper = baseExportableReportHelper;

            _healthPlanTestNotPerformedExportDownloadPath = settings.HealthPlanTestNotPerformedExportDownloadPath;
            _dayOfWeek = settings.HealthPlanTestNotPerformedIntervalDay;
            _logger = logManager.GetLogger("TestNotPerformReports");
            _cutOfDate = settings.HealthPlanTestNotPerformedCutOfDate;
        }

        public void PollForTestNotPerformed()
        {
            try
            {
                if (DateTime.Today.DayOfWeek != _dayOfWeek)
                {
                    _logger.Info(string.Format("todays day : {0}, export set to run on {1}", DateTime.Today.DayOfWeek, _dayOfWeek));
                    return;
                }
                var healthPlans = _corporateAccountRepository.GetAllHealthPlan();
                _logger.Info("Test Not Performed Report Started");

                foreach (var healthPlan in healthPlans)
                {
                    try
                    {
                        _logger.Info(string.Format("Report Generation Started for {0} ", healthPlan.Tag));

                        var toDate = DateTime.Today.Date;
                        var fromDate = DateTime.Today.AddDays(-7);

                        if (fromDate.Year == toDate.Year)
                        {
                            fromDate = new DateTime(fromDate.Year, 1, 1);
                            var filter = new TestNotPerformedListModelFilter
                            {
                                EventDateFrom = _cutOfDate > fromDate ? _cutOfDate : fromDate,
                                EventDateTo = toDate,
                                HealthPlanId = healthPlan.Id,
                            };

                            GenerateTestNotPerformedCsvByFilter(filter, healthPlan);
                        }
                        else
                        {
                            //for Previous Year
                            fromDate = new DateTime(fromDate.Year, 1, 1);

                            var filter = new TestNotPerformedListModelFilter
                            {
                                EventDateFrom = _cutOfDate > fromDate ? _cutOfDate : fromDate,
                                EventDateTo = new DateTime(fromDate.Year, 12, 31),
                                HealthPlanId = healthPlan.Id,
                            };

                            GenerateTestNotPerformedCsvByFilter(filter, healthPlan);

                            //for current Year
                            fromDate = new DateTime(toDate.Year, 1, 1);

                            filter = new TestNotPerformedListModelFilter
                            {
                                EventDateFrom = _cutOfDate > fromDate ? _cutOfDate : fromDate,
                                EventDateTo = toDate,
                                HealthPlanId = healthPlan.Id,
                            };

                            GenerateTestNotPerformedCsvByFilter(filter, healthPlan);

                        }

                        _logger.Info(string.Format("Report Generation Completed for {0} ", healthPlan.Tag));
                    }
                    catch (Exception ex)
                    {
                        _logger.Info(string.Format("Some Error Exception Occured while Generating Report for Tag: {0}  Message: {1} Stack Trace {2}", healthPlan.Tag, ex.Message, ex.StackTrace));
                        _logger.Info(string.Format("Report Generation Completed for {0} ", healthPlan.Tag));
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Info(string.Format("Some Error Exception Occured Message: {0} Stack Trace {1}", ex.Message, ex.StackTrace));
            }
        }

        private void GenerateTestNotPerformedCsvByFilter(TestNotPerformedListModelFilter filter, CorporateAccount healthPlan)
        {
            _logger.Info(string.Format("Generating Report for filter : EventDateFrom: {0}, EventDateTo {1}, HealthPlanId {2} ", filter.EventDateFrom, filter.EventDateTo, filter.HealthPlanId));

            var dataGen = new ExportableDataGenerator<TestNotPerformedViewModel, TestNotPerformedListModelFilter>(_testNotPerformedService.GetTestNotPerformed, _logger);
            var model = dataGen.GetData(filter);

            if (model != null)
            {
                var fileName = GetCsvFileName(filter, healthPlan);

                var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<TestNotPerformedViewModel>();

                if (model.Collection != null && model.Collection.Any())
                {
                    _baseExportableReportHelper.GenerateCsv(fileName, exporter, model.Collection);
                }
            }
        }

        private string GetCsvFileName(TestNotPerformedListModelFilter filter, CorporateAccount healthPlan)
        {
            var folderLocation = string.Format(_healthPlanTestNotPerformedExportDownloadPath, healthPlan.FolderName, filter.EventDateFrom.Value.Year);

            if (!Directory.Exists(folderLocation))
                Directory.CreateDirectory(folderLocation);

            var csvFileName = string.Format("TestNotPerformedReport.csv");

            var fileName = folderLocation + "\\" + csvFileName;

            if (File.Exists(fileName))
                File.Delete(fileName);

            return fileName;
        }
    }
}
