using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class PatientInputFilePollingAgent : IPatientInputFilePollingAgent
    {
        private readonly IPatientInputFileService _patientInputFileService;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IEnumerable<long> _accountIds;
        private readonly string _patientInputFileDestinationPath;
        private readonly ILogger _logger;
        private const int PageSize = 200;

        public PatientInputFilePollingAgent(IPatientInputFileService patientInputFileService, ICorporateAccountRepository corporateAccountRepository, IEventRepository eventRepository, ISettings settings, ILogManager logManager)
        {
            _patientInputFileService = patientInputFileService;
            _corporateAccountRepository = corporateAccountRepository;
            _eventRepository = eventRepository;
            _accountIds = settings.PatientInputFileAccountIds;
            _patientInputFileDestinationPath = settings.PatientInputFileReportPath;
            _logger = logManager.GetLogger("Patient Input File Polling Agent");
        }

        public void PollForPatientInputFiles()
        {
            _logger.Info("Started Patient Input File");
            try
            {
                if (_accountIds.IsNullOrEmpty()) return;
                var corporateAccounts = _corporateAccountRepository.GetByIds(_accountIds);

                foreach (var account in corporateAccounts)
                {
                    try
                    {
                        var eventDate = DateTime.Today.AddDays(-1);
                        var destinationPath = string.Format(_patientInputFileDestinationPath, account.FolderName, eventDate.Year);

                        _logger.Info(string.Format("Started Patient Input File For Account Id: {0} Tag: {1} for event Date: {2}", account.Id, account.Tag, eventDate));

                        var filter = new EventBasicInfoViewModelFilter
                        {
                            AccountId = account.Id,
                            DateTo = eventDate.Date,
                            DateFrom = eventDate.Date
                        };
                        var fileName = "PatientInputfiles_" + eventDate.ToString("MMddyyyy") + ".csv";
                        var csvFilePath = destinationPath + "\\" + fileName;

                        if (File.Exists(csvFilePath))
                            File.Delete(csvFilePath);

                        int pageNumber = 1;

                        while (true)
                        {
                            int totalRecords = 0;
                            var events = _eventRepository.GetEventsbyFilters(filter, pageNumber++, PageSize, out totalRecords);

                            if (events.IsNullOrEmpty()) break;

                            _logger.Info("total event count :" + totalRecords);

                            foreach (var eventData in events)
                            {
                                var model = _patientInputFileService.GetPatientFileInputByEvent(eventData, account.Tag);

                                if (model != null && model.Any())
                                {
                                    _logger.Info("event id : " + eventData.Id + " customer for Event " + model.Count());
                                    WriteCsvAppointmentBooked(model, destinationPath, fileName);
                                }
                                else
                                {
                                    _logger.Info("event id : " + eventData.Id + " no customer found for event ");
                                }
                            }
                        }

                        _logger.Info(string.Format("Completed Patient Input File For Account Id: {0} Tag: {1} for event Date: {2}", account.Id, account.Tag, eventDate));
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(string.Format("some Error occured for while generating file for Tag {0} Message: {1} Stack Trace {2}", account.Tag, ex.Message, ex.StackTrace));
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Error occured Message: {0} Stack trace {1}", ex.Message, ex.StackTrace));
            }

            _logger.Info("Completed Patient Input File");
        }

        private void WriteCsvAppointmentBooked(IEnumerable<PatientInputFileViewModel> modelData, string folderLocation, string csvFilePath)
        {
            var csvStringBuilder = new StringBuilder();
            var members = (typeof(PatientInputFileViewModel)).GetMembers();

            if (!File.Exists(folderLocation + "\\" + csvFilePath))
            {
                var header = new List<string>();
                foreach (var memberInfo in members)
                {
                    if (memberInfo.MemberType != MemberTypes.Property)
                        continue;

                    var propInfo = (memberInfo as PropertyInfo);
                    if (propInfo != null)
                    {
                        if (propInfo.PropertyType == typeof(FeedbackMessageModel))
                            continue;
                    }
                    else
                        continue;

                    string propertyName = memberInfo.Name;
                    bool isHidden = false;

                    var attributes = propInfo.GetCustomAttributes(false);
                    if (!attributes.IsNullOrEmpty())
                    {
                        foreach (var attribute in attributes)
                        {
                            if (attribute is HiddenAttribute)
                            {
                                isHidden = true;
                                break;
                            }
                            if (attribute is DisplayNameAttribute)
                            {
                                propertyName = (attribute as DisplayNameAttribute).DisplayName;
                            }
                        }
                    }

                    if (isHidden) continue;

                    header.Add(propertyName);
                }

                csvStringBuilder.Append(string.Join("|", header.ToArray()) + Environment.NewLine);

            }

            var sanitizer = new CSVSanitizer();
            foreach (var model in modelData)
            {
                var values = new List<string>();
                foreach (var memberInfo in members)
                {
                    if (memberInfo.MemberType != MemberTypes.Property)
                        continue;

                    var propInfo = (memberInfo as PropertyInfo);

                    if (propInfo == null)
                        continue;

                    if (propInfo.PropertyType == typeof(FeedbackMessageModel))
                        continue;

                    bool isHidden = false;
                    FormatAttribute formatter = null;

                    var attributes = propInfo.GetCustomAttributes(false);
                    if (!attributes.IsNullOrEmpty())
                    {
                        foreach (var attribute in attributes)
                        {
                            if (attribute is HiddenAttribute)
                            {
                                isHidden = true;
                                break;
                            }
                            if (attribute is FormatAttribute)
                            {
                                formatter = (FormatAttribute)attribute;
                            }
                        }
                    }

                    if (isHidden) continue;
                    var obj = propInfo.GetValue(model, null);
                    if (obj == null)
                        values.Add(string.Empty);
                    else if (formatter != null)
                        values.Add(formatter.ToString(obj));
                    else
                        values.Add(sanitizer.EscapeString(obj.ToString()));

                }

                csvStringBuilder.Append(string.Join("|", values.ToArray()) + Environment.NewLine);

            }

            SaveToFile(csvStringBuilder.ToString(), csvFilePath, folderLocation);
        }

        private bool SaveToFile(string fileContent, string filePath, string folderLocation)
        {
            CheckIfDirectoryExist(folderLocation);
            filePath = folderLocation + "\\" + filePath;

            using (var streamWriter = new StreamWriter(filePath, true))
            {
                streamWriter.Write(fileContent);
                streamWriter.Close();
            }

            return true;
        }

        private void CheckIfDirectoryExist(string folderLocation)
        {

            if (!Directory.Exists(folderLocation))
            {
                _logger.Info("folder Location " + folderLocation);
                Directory.CreateDirectory(folderLocation);
            }
        }
    }
}
