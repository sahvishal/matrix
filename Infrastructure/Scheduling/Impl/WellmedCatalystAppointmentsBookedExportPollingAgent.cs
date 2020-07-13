using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class WellmedCatalystAppointmentsBookedExportPollingAgent : IWellmedCatalystAppointmentsBookedExportPollingAgent
    {
        private readonly IEventCustomerReportingService _eventCustomerReportingService;
        private readonly IUniqueItemRepository<CorporateAccount> _corporateAccountRepository;

        private readonly ILogger _logger;
        private readonly string _destinationPath;
        private readonly string _groupNameSettings;
        private readonly long _accountId;
        private const string FolderName = "WellmedCatalyst";
        private readonly IAppointmentBookedExportCsvHelper _appointmentBookedExportCsvHelper;
        public WellmedCatalystAppointmentsBookedExportPollingAgent(IEventCustomerReportingService eventCustomerReportingService,
            ILogManager logManager, ISettings settings, IUniqueItemRepository<CorporateAccount> corporateAccountRepository,
            IAppointmentBookedExportCsvHelper appointmentBookedExportCsvHelper)
        {
            _logger = logManager.GetLogger("WellmedCatalystAppointmentsBookedExportPollingAgent");
            _eventCustomerReportingService = eventCustomerReportingService;

            _corporateAccountRepository = corporateAccountRepository;
            _destinationPath = settings.OutTakeReportPath;
            _groupNameSettings = settings.WellmedTxCatalystGroupName;
            _accountId = settings.WellmedTxAccountId;
            _appointmentBookedExportCsvHelper = appointmentBookedExportCsvHelper;
        }

        public void PollForAppointmentBookExport()
        {
            try
            {
                if (_accountId <= 0) return;

                var account = _corporateAccountRepository.GetById(_accountId);

                if (account == null)
                {
                    _logger.Info("Account can't be null");
                    return;
                }

                _logger.Info(string.Format("Generating AppointmentBooked for accountId {0} and account tag {1}. ", account.Id, account.Tag));

                var fromDate = DateTime.Today.GetFirstDateOfYear();
                var toDate = DateTime.Today.GetLastDateOfYear();

                var destination = Path.Combine(string.Format(_destinationPath, FolderName), "Appointments");

                DirectoryOperationsHelper.CreateDirectoryIfNotExist(destination);

                var fileName = "AppointmentsBooked_" + FolderName + "_" + DateTime.Today.ToString("MMddyyyy") + ".csv";

                var sourcePath = Path.Combine(destination, fileName);

                AppointmentsBooked(new AppointmentsBookedListModelFilter { EventFrom = fromDate, EventTo = toDate.Date, AccountId = account.Id, Tag = account.Tag, GroupName = _groupNameSettings }, sourcePath);

            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Main App: \n Error {0} \n Trace: {1} \n\n\n", ex.Message, ex.StackTrace));
            }
        }

        private void AppointmentsBooked(AppointmentsBookedListModelFilter filter, string destinationPath)
        {
            var pageNumber = 1;
            const int pageSize = 100;

            var list = new List<AppointmentsBookedModel>();

            while (true)
            {
                int totalRecords;
                var model = _eventCustomerReportingService.GetAppointmentsBooked(pageNumber, pageSize, filter, out totalRecords);
                if (model == null || model.Collection == null || !model.Collection.Any()) break;

                list.AddRange(model.Collection);
                _logger.Info(String.Format("\n\nPageNumber:{0} Totalrecords: {1}  Current Length: {2}", pageNumber, totalRecords, list.Count));

                pageNumber++;

                if (list.Count >= totalRecords)
                    break;
            }

            if (list.Any())
                _appointmentBookedExportCsvHelper.WriteCsv(list, destinationPath, _logger);
        }

    }
}