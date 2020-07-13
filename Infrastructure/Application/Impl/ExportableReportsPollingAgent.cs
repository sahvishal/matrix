using System;
using System.IO;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.Extension;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using File = Falcon.App.Core.Application.Domain.File;

namespace Falcon.App.Infrastructure.Application.Impl
{
    [DefaultImplementation]
    public class ExportableReportsPollingAgent : IExportableReportsPollingAgent
    {
        private readonly IExportableReportsQueueRepository _exportableReportsQueueRepository;
        private readonly ISchedulingExportableReportHelper _schedulingExportableReportHelper;
        private readonly ILogger _logger;
        private readonly IEmailNotificationModelsFactory _emailNotificationModelsFactory;
        private readonly INotifier _notifier;
        private readonly IUserRepository<User> _userRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;

        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly IMedicalExportableReportHelper _medicalExportableReportHelper;
        private readonly ICallCenterExportableReportHelper _callCenterExportableReportHelper;
        private readonly IFinanceExportableReportHelper _financeReportHelper;
        private readonly MediaLocation _exportableMediaLocation;
        private readonly bool _isDevEnvironment;

        public ExportableReportsPollingAgent(IExportableReportsQueueRepository exportableReportsQueueRepository, ILogManager logManager, ISchedulingExportableReportHelper schedulingExportableReportHelper,
            IEmailNotificationModelsFactory emailNotificationModelsFactory, INotifier notifier, IUserRepository<User> userRepository, IOrganizationRoleUserRepository organizationRoleUserRepository,
            IUniqueItemRepository<File> fileRepository, ISettings settings, IMediaRepository mediaRepository, IMedicalExportableReportHelper medicalExportableReportHelper,
            ICallCenterExportableReportHelper callCenterExportableReportHelper, IFinanceExportableReportHelper financeReportHelper)
        {
            _exportableReportsQueueRepository = exportableReportsQueueRepository;
            _schedulingExportableReportHelper = schedulingExportableReportHelper;
            _organizationRoleUserRepository = organizationRoleUserRepository;

            _fileRepository = fileRepository;
            _medicalExportableReportHelper = medicalExportableReportHelper;
            _callCenterExportableReportHelper = callCenterExportableReportHelper;
            _financeReportHelper = financeReportHelper;
            _exportableMediaLocation = mediaRepository.GetExportToCsvMediaFileLocation();

            _isDevEnvironment = settings.IsDevEnvironment;
            _logger = logManager.GetLogger("Exportable Report Polling Agent");

            _emailNotificationModelsFactory = emailNotificationModelsFactory;
            _notifier = notifier;
            _userRepository = userRepository;
        }

        public void PollForExportableRequest()
        {
            ExportableReportsQueue exportableReportsQueue = null;
            try
            {
                var timeOfDay = DateTime.Now.TimeOfDay;
                if (_isDevEnvironment || (timeOfDay > new TimeSpan(4, 0, 0)))
                {
                    _logger.Info("Exportable Report Generation Started");

                    exportableReportsQueue = _exportableReportsQueueRepository.GetExportableReportsQueueForService();

                    if (exportableReportsQueue == null)
                    {
                        _logger.Info("No Request pending in queue for generation");
                        return;
                    }

                    var orgRoleUser = _organizationRoleUserRepository.GetOrganizationRoleUser(exportableReportsQueue.RequestedBy);

                    var user = _userRepository.GetUser(orgRoleUser.UserId);
                    var reportType = (ExportableReportType)exportableReportsQueue.ReportId;

                    _logger.Info("Generating Report :" + reportType.GetDescription() + " Requested by " + user.NameAsString);

                    UpdateExportReportStartTimeAndStaus(exportableReportsQueue);
                    var fileName = string.Empty;

                    switch (reportType)
                    {
                        case ExportableReportType.AppointmentsBooked:
                            var appointmentsBookedListModelFilter = Newtonsoft.Json.JsonConvert.DeserializeObject<AppointmentsBookedListModelFilter>(exportableReportsQueue.FilterData);
                            fileName = _schedulingExportableReportHelper.AppointmentBookedReportExport(appointmentsBookedListModelFilter, orgRoleUser.UserId);
                            break;

                        case ExportableReportType.CustomerExport:
                            var customerExportListModelFilter = Newtonsoft.Json.JsonConvert.DeserializeObject<CustomerExportListModelFilter>(exportableReportsQueue.FilterData);
                            fileName = _schedulingExportableReportHelper.CustomerReportExport(customerExportListModelFilter, orgRoleUser.UserId);
                            break;
                        case ExportableReportType.TestPerformed:
                            var testPerformedFilter = Newtonsoft.Json.JsonConvert.DeserializeObject<TestPerformedListModelFilter>(exportableReportsQueue.FilterData);
                            fileName = _medicalExportableReportHelper.TestPerformedReportExport(testPerformedFilter, orgRoleUser.UserId);
                            break;
                        case ExportableReportType.OutreachCallReport:
                            var outreachCallReportModelFilter = Newtonsoft.Json.JsonConvert.DeserializeObject<OutreachCallReportModelFilter>(exportableReportsQueue.FilterData);
                            fileName = _callCenterExportableReportHelper.OutreachCallReportExport(outreachCallReportModelFilter, orgRoleUser.UserId);
                            break;
                        case ExportableReportType.MemberStatusReport:
                            var memberStatusListModelFilter = Newtonsoft.Json.JsonConvert.DeserializeObject<MemberStatusListModelFilter>(exportableReportsQueue.FilterData);
                            fileName = _schedulingExportableReportHelper.MemberStatusReportExport(memberStatusListModelFilter, orgRoleUser.UserId);
                            break;
                        case ExportableReportType.TestNotPerformed:
                            var testNotPerformedFilter = Newtonsoft.Json.JsonConvert.DeserializeObject<TestNotPerformedListModelFilter>(exportableReportsQueue.FilterData);
                            fileName = _medicalExportableReportHelper.TestNotPerformedReportExport(testNotPerformedFilter, orgRoleUser.UserId);
                            break;

                        case ExportableReportType.GapsClosure:
                            var gapsClosureFilter = Newtonsoft.Json.JsonConvert.DeserializeObject<GapsClosureModelFilter>(exportableReportsQueue.FilterData);
                            fileName = _medicalExportableReportHelper.GapsReportExport(gapsClosureFilter, orgRoleUser.UserId);
                            break;

                        case ExportableReportType.GiftCertificate:
                            var giftCertificateFilter = Newtonsoft.Json.JsonConvert.DeserializeObject<GiftCertificateReportFilter>(exportableReportsQueue.FilterData);
                            fileName = _financeReportHelper.GiftCerificateExport(giftCertificateFilter, orgRoleUser.UserId);
                            break;

                        case ExportableReportType.EventArchiveStats:
                            var eventArchiveStatsFilter = Newtonsoft.Json.JsonConvert.DeserializeObject<EventArchiveStatsFilter>(exportableReportsQueue.FilterData);
                            fileName = _medicalExportableReportHelper.EventArchiveStatsExport(eventArchiveStatsFilter, orgRoleUser.UserId);
                            break;

                        case ExportableReportType.CallQueueSchedulingReport:
                            var callQueueCustomerReportFilter = Newtonsoft.Json.JsonConvert.DeserializeObject<CallQueueSchedulingReportFilter>(exportableReportsQueue.FilterData);
                            fileName = _callCenterExportableReportHelper.CallQueueSchedulingReportExport(callQueueCustomerReportFilter, orgRoleUser.UserId);
                            break;

                        case ExportableReportType.TestBooked:
                            var testBookedListModelFilter = Newtonsoft.Json.JsonConvert.DeserializeObject<TestsBookedListModelFilter>(exportableReportsQueue.FilterData);
                            fileName = _schedulingExportableReportHelper.TestBookedReportExport(testBookedListModelFilter, orgRoleUser.UserId);
                            break;
                        case ExportableReportType.CallQueueExcludedCustomerReport:
                            var callQueueExcludedCustomerReportModelFilter = Newtonsoft.Json.JsonConvert.DeserializeObject<CallQueueExcludedCustomerReportModelFilter>(exportableReportsQueue.FilterData);
                            fileName = _callCenterExportableReportHelper.CallQueueExcludedCustomerReportExport(callQueueExcludedCustomerReportModelFilter, orgRoleUser.UserId);
                            break;

                        case ExportableReportType.CallQueueCustomerReport:
                            var outboundCallQueueFilter = Newtonsoft.Json.JsonConvert.DeserializeObject<OutboundCallQueueFilter>(exportableReportsQueue.FilterData);
                            fileName = _callCenterExportableReportHelper.CallQueueCustomersReportExport(outboundCallQueueFilter, orgRoleUser.UserId);
                            break;

                        case ExportableReportType.CustomerWithNoEventsInAreaReport:
                            var customerWithNoEventsInAreaReportModelFilter = Newtonsoft.Json.JsonConvert.DeserializeObject<CustomerWithNoEventsInAreaReportModelFilter>(exportableReportsQueue.FilterData);
                            fileName = _callCenterExportableReportHelper.CustomerWithNoEventsInAreaReportExport(customerWithNoEventsInAreaReportModelFilter, orgRoleUser.UserId);
                            break;

                        case ExportableReportType.CallCenterCallReport:
                            var callCenterCallReportModelFilter = Newtonsoft.Json.JsonConvert.DeserializeObject<CallCenterCallReportModelFilter>(exportableReportsQueue.FilterData);
                            fileName = _callCenterExportableReportHelper.CallCenterCallReportExport(callCenterCallReportModelFilter, orgRoleUser.UserId);
                            break;

                        case ExportableReportType.ConfirmationReport:
                            var confirmationReportFilter = Newtonsoft.Json.JsonConvert.DeserializeObject<ConfirmationReportFilter>(exportableReportsQueue.FilterData);
                            fileName = _callCenterExportableReportHelper.ConfirmationReportExport(confirmationReportFilter, orgRoleUser.UserId);
                            break;

                        case ExportableReportType.CallSkippedReport:
                            var callSkippedFilter = Newtonsoft.Json.JsonConvert.DeserializeObject<CallSkippedReportFilter>(exportableReportsQueue.FilterData);
                            fileName = _callCenterExportableReportHelper.CallSkippedReportExport(callSkippedFilter, orgRoleUser.UserId);
                            break;

                        case ExportableReportType.PcpTrackingReport:
                            var pcpTrackingReportFilter = Newtonsoft.Json.JsonConvert.DeserializeObject<PcpTrackingReportFilter>(exportableReportsQueue.FilterData);
                            fileName = _schedulingExportableReportHelper.PcpTrackingReportExport(pcpTrackingReportFilter, orgRoleUser.UserId);
                            break;

                        case ExportableReportType.CustomerSchedule:
                            var customerScheduleModelFilter = Newtonsoft.Json.JsonConvert.DeserializeObject<CustomerScheduleModelFilter>(exportableReportsQueue.FilterData);
                            fileName = _schedulingExportableReportHelper.CustomerScheduleExport(customerScheduleModelFilter, orgRoleUser.UserId);
                            break;

                        case ExportableReportType.ExcludedCustomerReport:
                            var excludedCustomerReport = Newtonsoft.Json.JsonConvert.DeserializeObject<OutboundCallQueueFilter>(exportableReportsQueue.FilterData);
                            fileName = _callCenterExportableReportHelper.ExcludedCusomerReportExport(excludedCustomerReport, orgRoleUser.UserId);
                            break;

                        case ExportableReportType.DisqualifiedTestReport:
                            var disqualifiedTestReportFilter = Newtonsoft.Json.JsonConvert.DeserializeObject<DisqualifiedTestReportFilter>(exportableReportsQueue.FilterData);
                            fileName = _medicalExportableReportHelper.DisqualifiedTestReportExport(disqualifiedTestReportFilter, orgRoleUser.UserId);
                            break;

                        case ExportableReportType.PreAssessmentReport:
                             var preAssessmentReportFilter = Newtonsoft.Json.JsonConvert.DeserializeObject<PreAssessmentReportFilter>(exportableReportsQueue.FilterData);
                             fileName = _callCenterExportableReportHelper.PreAssessmentReportExport(preAssessmentReportFilter, orgRoleUser.UserId);
                            break;
                    }

                    SaveFile(exportableReportsQueue, fileName);
                    SendNotification(user, reportType.GetDescription(), orgRoleUser.UserId, exportableReportsQueue.RequestedBy);

                    _logger.Info("Report :" + reportType.GetDescription() + " Requested by " + user.NameAsString + " Generated Successfully.");
                }
                else
                {
                    _logger.Info(string.Format("Call Upload Parser can not be called as time of day is {0}", timeOfDay));
                }

            }
            catch (Exception ex)
            {
                if (exportableReportsQueue != null)
                    UpdateExportReportEndTimeAndStaus(exportableReportsQueue, (long)ExportableReportStatus.Failed);

                _logger.Error("ex " + ex.Message + " stack trace: " + ex.StackTrace);
            }
        }


        private void UpdateExportReportStartTimeAndStaus(ExportableReportsQueue exportableReportsQueue)
        {
            exportableReportsQueue.StartedOn = DateTime.Now;
            exportableReportsQueue.StatusId = (long)ExportableReportStatus.InProgress;
            _exportableReportsQueueRepository.Save(exportableReportsQueue);
        }

        private void UpdateExportReportEndTimeAndStaus(ExportableReportsQueue exportableReportsQueue, long statusId)
        {
            exportableReportsQueue.EndedOn = DateTime.Now;
            exportableReportsQueue.StatusId = statusId;
            _exportableReportsQueueRepository.Save(exportableReportsQueue);
        }

        private void SaveFile(ExportableReportsQueue exportableReportsQueue, string fileName)
        {
            var filePath = _exportableMediaLocation.PhysicalPath + fileName;
            var fileInfo = new FileInfo(filePath);

            var file = new File
             {
                 Path = fileName,
                 FileSize = fileInfo.Length,
                 Type = FileType.Compressed,
                 UploadedBy = new OrganizationRoleUser(exportableReportsQueue.RequestedBy),
                 UploadedOn = DateTime.Now
             };

            file = _fileRepository.Save(file);

            exportableReportsQueue.FileId = file.Id;

            UpdateExportReportEndTimeAndStaus(exportableReportsQueue, (long)ExportableReportStatus.Completed);
        }

        private void SendNotification(User user, string reportName, long userId, long requestedBy)
        {
            var customerExportableReportsNotificationViewModel = _emailNotificationModelsFactory.GetCustomerExportableReportsNotificationViewModel(user.NameAsString, reportName);
            _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.ExportToCsvNotification, EmailTemplateAlias.ExportToCsvNotification, customerExportableReportsNotificationViewModel, userId, requestedBy, "Export To Csv Notification");
        }
    }
}
