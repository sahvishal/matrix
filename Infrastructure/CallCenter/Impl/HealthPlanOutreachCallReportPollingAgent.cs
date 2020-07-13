using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.CallCenter.Enum;

namespace Falcon.App.Infrastructure.CallCenter.Impl
{
    [DefaultImplementation]
    public class HealthPlanOutreachCallReportPollingAgent : IHealthPlanOutreachCallReportPollingAgent
    {
        private readonly ICallCenterExportableReportHelper _callCenterExportableReportHelper;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly ILogger _logger;
        private readonly ISettings _settings;

        private readonly string _healthPlanOutreachReportExportDownloadPath;
        private readonly DayOfWeek _dayOfWeek;
        private readonly DateTime _cutOfDate;
        private readonly IEnumerable<long> _healthPlanIds;

        public HealthPlanOutreachCallReportPollingAgent(ICallCenterExportableReportHelper callCenterExportableReportHelper, ICorporateAccountRepository corporateAccountRepository, ILogManager logManager, ISettings settings)
        {
            _callCenterExportableReportHelper = callCenterExportableReportHelper;
            _corporateAccountRepository = corporateAccountRepository;
            _logger = logManager.GetLogger("HealthPlanOutreachCallReport");
            _settings = settings;

            _healthPlanOutreachReportExportDownloadPath = settings.HealthPlanOutreachReportExportDownloadPath;
            _dayOfWeek = settings.HealthPlanOutreachReportIntervalDay;
            _cutOfDate = settings.HealthPlanOutreachReportCutOfDate;
            _healthPlanIds = settings.HealthPlanOutreachReportAccountIds;
        }

        public void PollForOutreachReport()
        {
            try
            {
                var today = DateTime.Today;
                if (today.DayOfWeek != _dayOfWeek)
                {
                    _logger.Info(string.Format("todays day : {0}, export set to run on {1}", today.DayOfWeek, _dayOfWeek));
                    return;
                }
                _logger.Info("Polling for Out reach report started");

                var healthPlans = _corporateAccountRepository.GetAllHealthPlan().Where(hp => _healthPlanIds.Contains(hp.Id));

                foreach (var healthPlan in healthPlans)
                {
                    _logger.Info(string.Format("Polling for Out reach report started for Account Id {0} ", healthPlan.Id));
                    try
                    {
                        var fromDate = DateTime.Today.AddDays(-7);

                        if (fromDate.Year == today.Year)
                        {
                            fromDate = new DateTime(fromDate.Year, 1, 1);
                            var filter = new OutreachCallReportModelFilter
                            {
                                Tag = healthPlan.Tag,
                                DateFrom = _cutOfDate > fromDate ? _cutOfDate : fromDate,
                                DateTo = today,
                                CallAttemptFilter = CallAttemptFilterStatus.All,
                            };

                            var filePath = GetOutreachFilePath(healthPlan, today.Year);

                            _callCenterExportableReportHelper.OutreachCallReportExport(filter, filePath, _logger);

                        }
                        else
                        {
                            //for Previous Year
                            fromDate = new DateTime(fromDate.Year, 1, 1);

                            var filter = new OutreachCallReportModelFilter
                            {
                                DateFrom = _cutOfDate > fromDate ? _cutOfDate : fromDate,
                                DateTo = new DateTime(fromDate.Year, 12, 31),
                                CallAttemptFilter = CallAttemptFilterStatus.All,
                            };

                            var filePath = GetOutreachFilePath(healthPlan, fromDate.Year);

                            _callCenterExportableReportHelper.OutreachCallReportExport(filter, filePath, _logger);

                            //for current Year
                            fromDate = new DateTime(today.Year, 1, 1);

                            filter = new OutreachCallReportModelFilter
                            {
                                DateFrom = _cutOfDate > fromDate ? _cutOfDate : fromDate,
                                DateTo = today,
                                CallAttemptFilter = CallAttemptFilterStatus.All,
                            };

                            filePath = GetOutreachFilePath(healthPlan, fromDate.Year);

                            _callCenterExportableReportHelper.OutreachCallReportExport(filter, filePath, _logger);
                        }
                    }
                    catch (Exception exception)
                    {
                        _logger.Error(string.Format("Exception occured while polling for outreach report for Account Id {0}.  Exception Message : {1}, Stack  Trace {2}", healthPlan.Id, exception.Message, exception.StackTrace));
                    }

                    _logger.Info(string.Format("Polling for Outreach report completed for Account Id {0} ", healthPlan.Id));
                }
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Exception occured while polling for outreach report.  Exception Message : {0}, Stack  Trace {1}", ex.Message, ex.StackTrace));
            }
        }

        private string GetOutreachFilePath(CorporateAccount healthPlan, int year)
        {
            var folderLocation = string.Format(_healthPlanOutreachReportExportDownloadPath, healthPlan.FolderName, year);
            var filePath = folderLocation + "\\" + "OutreachCallReport.csv";

            if (healthPlan.Id == _settings.ConnecticareAccountId || healthPlan.Id == _settings.ConnecticareMaAccountId)
            {
                folderLocation = string.Format(_settings.HealthPlanDownloadPath, healthPlan.FolderName);
                filePath = folderLocation + "\\" + "OutreachCallReport_" + DateTime.Today.ToString("yyyy-MM-dd") + ".csv";
            }

            DirectoryOperationsHelper.CreateDirectoryIfNotExist(folderLocation);

            DirectoryOperationsHelper.DeleteFileIfExist(filePath);

            return filePath;
        }
    }
}
