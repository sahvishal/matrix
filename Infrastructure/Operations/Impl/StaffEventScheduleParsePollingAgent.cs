using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using File = Falcon.App.Core.Application.Domain.File;

namespace Falcon.App.Infrastructure.Operations.Impl
{
    [DefaultImplementation]
    public class StaffEventScheduleParsePollingAgent : IStaffEventScheduleParsePollingAgent
    {
        private readonly IStaffEventScheduleUploadRepository _staffEventScheduleUploadRepository;
        private readonly IEventStaffAssignmentService _eventStaffAssignmentService;
        private readonly IMediaRepository _mediaRepository;
        private readonly ISettings _settings;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly ICsvReader _csvReader;
        private readonly IEventRoleRepository _eventRoleRepository;
        private readonly IPodRepository _podRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly IEventPodRepository _eventPodRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IStaffEventScheduleUploadLogRepository _staffEventScheduleUploadLogRepository;
        private readonly IEventStaffAssignmentRepository _eventStaffAssignmentRepository;
        private readonly ILogger _logger;

        private readonly bool _isDevEnvironment;

        public StaffEventScheduleParsePollingAgent(IStaffEventScheduleUploadRepository staffEventScheduleUploadRepository, IEventStaffAssignmentService eventStaffAssignmentService,
            IMediaRepository mediaRepository, ISettings settings, IUniqueItemRepository<File> fileRepository, ICsvReader csvReader, ILogManager logManager, IEventRoleRepository eventRoleRepository,
            IPodRepository podRepository, IOrganizationRoleUserRepository organizationRoleUserRepository, IEventPodRepository eventPodRepository,
            IEventRepository eventRepository, IStaffEventScheduleUploadLogRepository staffEventScheduleUploadLogRepository, IEventStaffAssignmentRepository eventStaffAssignmentRepository)
        {
            _staffEventScheduleUploadRepository = staffEventScheduleUploadRepository;
            _eventStaffAssignmentService = eventStaffAssignmentService;
            _mediaRepository = mediaRepository;
            _settings = settings;
            _fileRepository = fileRepository;
            _csvReader = csvReader;
            _eventRoleRepository = eventRoleRepository;
            _podRepository = podRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _eventPodRepository = eventPodRepository;
            _eventRepository = eventRepository;
            _staffEventScheduleUploadLogRepository = staffEventScheduleUploadLogRepository;
            _eventStaffAssignmentRepository = eventStaffAssignmentRepository;
            _logger = logManager.GetLogger("StaffEventScheduleParsePollingAgent");
            _isDevEnvironment = settings.IsDevEnvironment;
        }

        public void PollForStaffEventScheduleParse()
        {
            try
            {
                var timeOfDay = DateTime.Now;
                if (_isDevEnvironment || timeOfDay.TimeOfDay > new TimeSpan(3, 0, 0))
                {
                    _logger.Info("Entering StaffEventSchedule parse polling agent @:" + timeOfDay);

                    var filesToParse = (IReadOnlyCollection<StaffEventScheduleUpload>)_staffEventScheduleUploadRepository.GetFilesToParse();

                    if (filesToParse.IsNullOrEmpty())
                    {
                        _logger.Info("No file found for parsing , exiting");
                        return;
                    }
                    _logger.Info("No. of files to Parse:" + filesToParse.Count());

                    var parseFileIds = filesToParse.Select(x => x.FileId);
                    var uploadedFileDomains = (IReadOnlyCollection<File>)_fileRepository.GetByIds(parseFileIds);
                    var filesLocation = _mediaRepository.GetStaffScheduleUploadMediaFileLocation();

                    var eventStaffRoles = _eventRoleRepository.GetAllActiveRoles();
                    var pods = _podRepository.GetAllPods();

                    foreach (var staffEventScheduleUploadDomain in filesToParse)
                    {
                        var failedRecords = new List<StaffEventScheduleUploadLogViewModel>();
                        var staffEventScheduleUploadLogCollection = new List<StaffEventScheduleUploadLog>();
                        try
                        {
                            staffEventScheduleUploadDomain.ParseStartTime = DateTime.Now;
                            var fileDomainCurrent = uploadedFileDomains.FirstOrDefault(x => x.Id == staffEventScheduleUploadDomain.FileId);
                            if (fileDomainCurrent == null)
                            {
                                UpdateParsingStatus(staffEventScheduleUploadDomain, (long)StaffEventScheduleParseStatus.FileNotFound);
                                _logger.Info("Parsing Failed: FileNotFound StaffScheduleUpload Id: " + staffEventScheduleUploadDomain.Id);
                                continue;
                            }

                            var filePhysicalLocation = filesLocation.PhysicalPath + fileDomainCurrent.Path;
                            _logger.Info("Parsing for File: " + filePhysicalLocation);

                            if (!System.IO.File.Exists(filePhysicalLocation))
                            {
                                UpdateParsingStatus(staffEventScheduleUploadDomain, (long)StaffEventScheduleParseStatus.FileNotFound);
                                _logger.Info("Parsing Failed: FileNotFound on Physical Storage File name: " + fileDomainCurrent.Path);
                                continue;
                            }

                            var fInfo = new FileInfo(filePhysicalLocation);
                            if (fInfo.Extension != ".csv")
                            {
                                UpdateParsingStatus(staffEventScheduleUploadDomain, (long)StaffEventScheduleParseStatus.InvalidFileFormat);
                                _logger.Info("Parsing Failed: InvalidFileFormat File name: " + fileDomainCurrent.Path);
                                continue;
                            }

                            _logger.Error("Beginning to Parse File : File name: " + fileDomainCurrent.Path);
                            UpdateParsingStatus(staffEventScheduleUploadDomain, (long)StaffEventScheduleParseStatus.Parsing, false);

                            var staffEventScheduleTable = _csvReader.ReadWithTextQualifier(filePhysicalLocation);
                            var recordsInFile = staffEventScheduleTable.Rows.Count;

                            IEnumerable<StaffEventScheduleParsedDataViewModel> tempParsedRecords = null;
                            var rows = staffEventScheduleTable.AsEnumerable();
                            tempParsedRecords = ParseScheduleUpload(rows, failedRecords, staffEventScheduleUploadLogCollection);
                            if (tempParsedRecords.IsNullOrEmpty())
                            {
                                staffEventScheduleUploadDomain.StatusId = (long)StaffEventScheduleParseStatus.ParseFailed;
                                UpdateStaffScheduleUploadDetail(staffEventScheduleUploadDomain, failedRecords, filePhysicalLocation, staffEventScheduleUploadLogCollection);
                                continue;
                            }

                            UpdateStaffEventSchedule(tempParsedRecords, fileDomainCurrent.UploadedBy.Id, eventStaffRoles, pods, staffEventScheduleUploadLogCollection);

                            staffEventScheduleUploadDomain.SuccessUploadCount = tempParsedRecords.Count(x => x.IsSuccess == true);
                            staffEventScheduleUploadDomain.ParseEndTime = DateTime.Now;
                            staffEventScheduleUploadDomain.StatusId = (long)StaffEventScheduleParseStatus.Parsed;

                            failedRecords.AddRange(tempParsedRecords
                                .Where(x => x.IsSuccess == false)
                                .Select(x => new StaffEventScheduleUploadLogViewModel
                            {
                                EmployeeId = x.EmployeeId,
                                ErrorMessage = x.ErrorMessage,
                                EventDate = x.EventDate.ToString("MM/dd/yyyy"),
                                Name = x.Name,
                                Pod = x.Pod,
                                Role = x.Role
                            }).ToList());

                            UpdateStaffScheduleUploadDetail(staffEventScheduleUploadDomain, failedRecords, filePhysicalLocation, staffEventScheduleUploadLogCollection);
                            _logger.Error("Parse Succeeded : File name: " + fileDomainCurrent.Path);
                        }
                        catch (Exception ex)
                        {
                            var fileDomain = uploadedFileDomains.FirstOrDefault(x => x.Id == staffEventScheduleUploadDomain.FileId);

                            if (fileDomain != null)
                            {
                                _logger.Error("Failed to parse File , File name: " + fileDomain.Path);
                                var filePhysicalLocation = filesLocation.PhysicalPath + fileDomain.Path;
                                staffEventScheduleUploadDomain.StatusId = (long)StaffEventScheduleParseStatus.ParseFailed;
                                UpdateStaffScheduleUploadDetail(staffEventScheduleUploadDomain, failedRecords, filePhysicalLocation, staffEventScheduleUploadLogCollection);
                            }
                            else
                                _logger.Error("Record does not exist in file table");

                            _logger.Error("ExceptionMessage: " + ex.Message + "\n\tStackTrace: " + ex.StackTrace);
                            continue;
                        }
                    }
                }
                else
                {
                    _logger.Info(string.Format("StaffEventSchedule Parser can not be invoked as time of day is {0}", timeOfDay.TimeOfDay));
                }
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Exception occurred during execution of polling agent\nException Message: {0}\n\tStackTrace:{1}", ex.Message, ex.StackTrace));
                return;
            }
        }

        private void UpdateParsingStatus(StaffEventScheduleUpload domain, long statusId, bool isCompleted = true)
        {
            domain.StatusId = statusId; ;
            domain.ParseEndTime = DateTime.Now;
            domain.ParseEndTime = isCompleted ? DateTime.Now : (DateTime?)null;

            _staffEventScheduleUploadRepository.Save(domain);
        }

        private void UpdateStaffScheduleUploadDetail(StaffEventScheduleUpload staffEventScheduleUploadDomain, List<StaffEventScheduleUploadLogViewModel> failedRecordsList, string fileName,
            IEnumerable<StaffEventScheduleUploadLog> staffEventScheduleUploadLogCollection)
        {
            if (failedRecordsList.Any())
            {
                try
                {
                    var location = _mediaRepository.GetStaffScheduleUploadMediaFileLocation();
                    var failedFilePath = location.PhysicalPath + Path.GetFileNameWithoutExtension(fileName) + "_Failed.csv";
                    var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<StaffEventScheduleUploadLogViewModel>();
                    WriteCsv(failedFilePath, exporter, failedRecordsList);
                    var failedRecords = new FileInfo(failedFilePath);
                    var file = new File
                    {
                        Path = failedRecords.Name,
                        FileSize = failedRecords.Length,
                        Type = FileType.Csv,
                        UploadedBy = new OrganizationRoleUser(1),
                        UploadedOn = DateTime.Now
                    };
                    file = _fileRepository.Save(file);
                    staffEventScheduleUploadDomain.FailedUploadCount = failedRecordsList.Count();
                    staffEventScheduleUploadDomain.LogFileId = file.Id;

                    if (!staffEventScheduleUploadLogCollection.IsNullOrEmpty())
                    {
                        staffEventScheduleUploadLogCollection.ForEach(x => x.UploadId = staffEventScheduleUploadDomain.Id);
                        _staffEventScheduleUploadLogRepository.Save(staffEventScheduleUploadLogCollection);
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error("Exception Raised while creating failed records CSV\n message: " + ex.Message + " stacktrace: " + ex.StackTrace);
                }
            }
            _staffEventScheduleUploadRepository.Save(staffEventScheduleUploadDomain);
        }

        private void WriteCsv<T>(string fileName, CSVExporter<T> exporter, IEnumerable<T> modelData)
        {
            var csvStringBuilder = new StringBuilder();
            csvStringBuilder.Append(exporter.Header + Environment.NewLine);
            foreach (string line in exporter.ExportObjects(modelData))
            {
                csvStringBuilder.Append(line + Environment.NewLine);
            }
            System.IO.File.AppendAllText(fileName, csvStringBuilder.ToString());
        }

        private IEnumerable<StaffEventScheduleParsedDataViewModel> ParseScheduleUpload(IEnumerable<DataRow> rows, List<StaffEventScheduleUploadLogViewModel> failedRecords,
            List<StaffEventScheduleUploadLog> staffEventScheduleUploadLogCollection)
        {
            var collection = new List<StaffEventScheduleParsedDataViewModel>();

            foreach (DataRow row in rows)
            {
                var parsedData = GetDataRow(row);

                if (parsedData.EmployeeId == null)
                {
                    failedRecords.Add(GetFailedRecordDataParsingDataTable(row, "Invalid Employee ID provided", staffEventScheduleUploadLogCollection));
                    continue;
                }
                if (string.IsNullOrEmpty(parsedData.Name))
                {
                    failedRecords.Add(GetFailedRecordDataParsingDataTable(row, "Staff name not provided", staffEventScheduleUploadLogCollection));
                    continue;
                }
                if (parsedData.EventDate == DateTime.MinValue)
                {
                    failedRecords.Add(GetFailedRecordDataParsingDataTable(row, "Format invalid, must be mm/dd/yyyy", staffEventScheduleUploadLogCollection));
                    continue;
                }

                if (string.IsNullOrEmpty(parsedData.Pod))
                {
                    failedRecords.Add(GetFailedRecordDataParsingDataTable(row, "Pod name not provided", staffEventScheduleUploadLogCollection));
                    continue;
                }
                if (string.IsNullOrEmpty(parsedData.Role))
                {
                    failedRecords.Add(GetFailedRecordDataParsingDataTable(row, "Role not provided", staffEventScheduleUploadLogCollection));
                    continue;
                }
                collection.Add(parsedData);
            }
            return collection;
        }

        private StaffEventScheduleParsedDataViewModel GetDataRow(DataRow row)
        {
            var staffEventSchedule = new StaffEventScheduleParsedDataViewModel
            {
                Name = GetRowValue(row, StaffEventScheduleUploadColumn.StaffName.GetDescription()).Trim(),
                EmployeeId = GetRowValue(row, StaffEventScheduleUploadColumn.EmployeeId.GetDescription()),
                EventDate = ConvertToDate(GetRowValue(row, StaffEventScheduleUploadColumn.EventDate.GetDescription())),
                //EventId = ConvertToLong(GetRowValue(row, StaffEventScheduleUploadColumn.EventId.GetDescription())),
                Pod = GetRowValue(row, StaffEventScheduleUploadColumn.Pod.GetDescription()).Trim(),
                Role = GetRowValue(row, StaffEventScheduleUploadColumn.Role.GetDescription()).Trim()
            };
            return staffEventSchedule;
        }

        private StaffEventScheduleUploadLogViewModel GetFailedRecordDataParsingDataTable(DataRow row, string errorMessage, List<StaffEventScheduleUploadLog> staffEventScheduleUploadLogCollection)
        {
            var employeeId = GetRowValue(row, StaffEventScheduleUploadColumn.EmployeeId.GetDescription());
            var eventDate = GetRowValue(row, StaffEventScheduleUploadColumn.EventDate.GetDescription());
            //var eventId = GetRowValue(row, StaffEventScheduleUploadColumn.EventId.GetDescription());
            var name = GetRowValue(row, StaffEventScheduleUploadColumn.StaffName.GetDescription());
            var pod = GetRowValue(row, StaffEventScheduleUploadColumn.Pod.GetDescription());
            var role = GetRowValue(row, StaffEventScheduleUploadColumn.Role.GetDescription());

            staffEventScheduleUploadLogCollection.Add(new StaffEventScheduleUploadLog
            {
                ErrorMessage = errorMessage,
                Pod = pod,
                EventDate = eventDate,
                //EventId = eventId,
                IsSuccessful = false,
                EmployeeId = employeeId,
                StaffName = name,
                Role = role
            });
            return new StaffEventScheduleUploadLogViewModel
            {
                EmployeeId = employeeId,
                EventDate = eventDate,
                //EventId = eventId,
                Name = name,
                Pod = pod,
                Role = role,
                ErrorMessage = errorMessage
            };
        }

        private string GetRowValue(DataRow row, string fieldName)
        {
            if (row == null || row[fieldName] == null || row[fieldName] == DBNull.Value) return string.Empty;
            return row[fieldName].ToString().Trim();
        }

        private long ConvertToLong(string eventId)
        {
            long customerId;
            long.TryParse(eventId, out customerId);

            return customerId;
        }

        private DateTime ConvertToDate(string eventDate)               //if conversion fails , it will return min date
        {
            DateTime parsedDate;
            DateTime.TryParse(eventDate, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate);
            return parsedDate;
        }

        private void UpdateStaffEventSchedule(IEnumerable<StaffEventScheduleParsedDataViewModel> parsedRecords, long fileUploader,
            IEnumerable<StaffEventRole> staffEventRoles, IEnumerable<Pod> pods, List<StaffEventScheduleUploadLog> staffEventScheduleUploadLogCollection)
        {
            var eventDatePodPair = parsedRecords.GroupBy(x => new { x.EventDate, x.Pod }).Select(x => new OrderedPair<DateTime, string>() { FirstValue = x.Key.EventDate, SecondValue = x.Key.Pod }).ToArray();

            foreach (var eventDatePod in eventDatePodPair)
            {
                try
                {
                    var events = _eventRepository.GetEventByEventDateAndPod(eventDatePod.FirstValue, eventDatePod.SecondValue);
                    if (!events.IsNullOrEmpty())
                    {
                        var recordsForEventId = parsedRecords.Where(x => x.EventDate == eventDatePod.FirstValue && x.Pod == eventDatePod.SecondValue).Select(x => x);
                        var employeeIds = recordsForEventId.Select(x => x.EmployeeId.ToUpper()).ToList();
                        var employeeIdOruPair = _organizationRoleUserRepository.GetActiveOruIdEmployeeIdPairByEmployeeIdAndRole(employeeIds, (long)Roles.Technician);

                        foreach (var @event in events)
                        {
                            var validRecords = new List<StaffEventScheduleParsedDataViewModel>();
                            var eventId = @event.Id;
                            try
                            {
                                var eventPods = _eventPodRepository.GetByEventId(eventId);
                                if (eventPods.IsNullOrEmpty())
                                {
                                    _logger.Info("No Event Pod found for EventId:" + eventId);
                                    parsedRecords.Where(x => x.EventDate == eventDatePod.FirstValue && x.Pod == eventDatePod.SecondValue).ForEach(x => { x.IsSuccess = false; x.ErrorMessage = "No pod Exist for this EventId"; });
                                    continue;
                                }

                                var podNamesInCsvForEvent = parsedRecords.Select(x => x.Pod);
                                var validPodsForEventFromCsv = pods.Where(x => podNamesInCsvForEvent.Contains(x.Name) && eventPods.First().PodId == x.Id);

                                if (validPodsForEventFromCsv.IsNullOrEmpty())
                                {
                                    _logger.Info("No valid Pod provided for EventId:" + eventId);
                                    parsedRecords.Where(x => x.EventDate == eventDatePod.FirstValue && x.Pod == eventDatePod.SecondValue).ForEach(x => { x.IsSuccess = false; x.ErrorMessage = "Pod not attached to this Event"; });
                                    continue;
                                }

                                var selectedPodId = validPodsForEventFromCsv.First().Id;
                                var selectedPod = pods.First(x => x.Id == selectedPodId);

                                foreach (var record in recordsForEventId)
                                {
                                    var staff = employeeIdOruPair.FirstOrDefault(x => x.SecondValue.Trim().ToUpper() == record.EmployeeId.ToUpper());
                                    if (staff == null)
                                    {
                                        parsedRecords.Where(x => x.EventDate == eventDatePod.FirstValue && x.Pod == eventDatePod.SecondValue && x.EmployeeId == record.EmployeeId && x.Name == record.Name && x.Role == record.Role)
                                            .ForEach(x => { x.IsSuccess = false; x.ErrorMessage = "Provided Employee Id does not exist"; });

                                        continue;
                                    }

                                    var role = staffEventRoles.FirstOrDefault(x => string.Compare(x.Name.Trim(), record.Role, StringComparison.InvariantCultureIgnoreCase) == 0);
                                    if (role == null)
                                    {
                                        parsedRecords.Where(x => x.EventDate == eventDatePod.FirstValue && x.Pod == eventDatePod.SecondValue && x.EmployeeId == record.EmployeeId && x.Name == record.Name && x.Role == record.Role)
                                            .ForEach(x => { x.IsSuccess = false; x.ErrorMessage = "Provided role does not exist or Inactive"; });
                                        continue;
                                    }

                                    var pod = pods.FirstOrDefault(x => x.Name.Trim().ToUpper() == record.Pod.ToUpper());
                                    if (pod == null)
                                    {
                                        parsedRecords.Where(x => x.EventDate == eventDatePod.FirstValue && x.Pod == eventDatePod.SecondValue && x.EmployeeId == record.EmployeeId && x.Name == record.Name && x.Role == record.Role)
                                            .ForEach(x => { x.IsSuccess = false; x.ErrorMessage = "Provided pod does not exist"; });
                                        continue;
                                    }

                                    if (pod.Id != selectedPodId && eventPods.Select(x => x.PodId).Contains(pod.Id))
                                    {
                                        parsedRecords.Where(x => x.EventDate == eventDatePod.FirstValue && x.Pod == eventDatePod.SecondValue && x.EmployeeId == record.EmployeeId && x.Name == record.Name && x.Role == record.Role)
                                            .ForEach(x => { x.IsSuccess = false; x.ErrorMessage = "Record Discarded for :" + record.Pod.ToUpper() + ", Successfully attached :" + selectedPod.Name.ToUpper(); });
                                        continue;
                                    }

                                    if (record.EventDate != @event.EventDate)
                                    {
                                        parsedRecords.Where(x => x.EventDate == eventDatePod.FirstValue && x.Pod == eventDatePod.SecondValue && x.EmployeeId == record.EmployeeId && x.Name == record.Name && x.Role == record.Role)
                                            .ForEach(x => { x.IsSuccess = false; x.ErrorMessage = "Provided event date doesn't match with the eventId"; });
                                        continue;
                                    }

                                    parsedRecords.Where(x => x.EventDate == eventDatePod.FirstValue && x.Pod == eventDatePod.SecondValue && x.EmployeeId == record.EmployeeId && x.Name == record.Name && x.Role == record.Role)
                                            .ForEach(x => { x.IsSuccess = true; });

                                    staffEventScheduleUploadLogCollection.Add(new StaffEventScheduleUploadLog
                                    {
                                        ErrorMessage = null,
                                        EventDate = record.EventDate.ToString("MM/dd/yyyy"),
                                        IsSuccessful = true,
                                        Pod = record.Pod,
                                        Role = record.Role,
                                        EmployeeId = record.EmployeeId.ToString(),
                                        StaffName = record.Name
                                    });
                                    validRecords.Add(record);
                                }
                                if (!validRecords.IsNullOrEmpty())
                                {
                                    //parsed records eventStaffBasicInfoModelCollection
                                    var eventStaffBasicInfoModelCollection = GetEventStaffModel(validRecords, staffEventRoles, selectedPodId, employeeIdOruPair).ToList();

                                    //Appending records from DB to our parsed records
                                    var alreadyAssignedStaffForEvent = (IReadOnlyCollection<EventStaffAssignment>)_eventStaffAssignmentRepository.GetForEvent(eventId);
                                    if (alreadyAssignedStaffForEvent.Any())
                                    {
                                        eventStaffBasicInfoModelCollection.AddRange(MapEventStaffAssignmentToEventBasicInfoModel(alreadyAssignedStaffForEvent, selectedPodId));
                                    }

                                    //now filtering only unique combination of ScheduledStaffOrgRoleUserId and EventRoleId
                                    //because one Staff can be assigned some role only once

                                    var uniqueEntriesInEventStaffBasicInfoModel = new List<EventStaffBasicInfoModel>();
                                    foreach (var eventStaffBasicInfoModel in eventStaffBasicInfoModelCollection)
                                    {
                                        var data = eventStaffBasicInfoModel;
                                        if (uniqueEntriesInEventStaffBasicInfoModel.FirstOrDefault(
                                            x =>
                                                x.ScheduledStaffOrgRoleUserId == eventStaffBasicInfoModel.ScheduledStaffOrgRoleUserId
                                                && x.EventRoleId == eventStaffBasicInfoModel.EventRoleId) == null)
                                        {
                                            uniqueEntriesInEventStaffBasicInfoModel.Add(data);
                                        }
                                    }

                                    _eventStaffAssignmentService.Save(@event.Id, selectedPodId, fileUploader, uniqueEntriesInEventStaffBasicInfoModel);
                                }
                            }
                            catch (Exception ex)
                            {
                                _logger.Info("Exception Occurred while saving staff Assignment for EventId:" + eventId + "\nMarking all Records as Failed");

                                parsedRecords.Where(x => x.EventDate == eventDatePod.FirstValue && x.Pod == eventDatePod.SecondValue)
                                            .ForEach(x => { x.IsSuccess = false; x.ErrorMessage = "Internal Error Occured"; });

                                _logger.Error("ExceptionMessage: " + ex.Message + "\n\tStackTrace: " + ex.StackTrace);
                                continue;
                            }
                        }
                    }
                    else
                    {
                        parsedRecords.Where(x => x.EventDate == eventDatePod.FirstValue && x.Pod == eventDatePod.SecondValue)
                                            .ForEach(x => { x.IsSuccess = false; x.ErrorMessage = "Event Date and Pod pair does not exist"; });
                        continue;
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error("ExceptionMessage: " + ex.Message + "\n\tStackTrace: " + ex.StackTrace);
                }
            }
        }


        private IEnumerable<EventStaffBasicInfoModel> GetEventStaffModel(IEnumerable<StaffEventScheduleParsedDataViewModel> validRecords, IEnumerable<StaffEventRole> staffEventRoles,
            long podId, IEnumerable<OrderedPair<long, string>> emailIdOruPair)
        {
            var eventStaffBasicModelCollection = new List<EventStaffBasicInfoModel>();

            foreach (var record in validRecords)
            {
                eventStaffBasicModelCollection.Add(new EventStaffBasicInfoModel
                {
                    ActualStaffOrgRoleUserId = null,
                    EventRoleId = staffEventRoles.First(x => string.Compare(x.Name.Trim(), record.Role.Trim(), StringComparison.InvariantCultureIgnoreCase) == 0).Id,
                    Notes = null,
                    PodId = podId,
                    ScheduledStaffOrgRoleUserId = emailIdOruPair.First(x => x.SecondValue.Trim().ToUpper() == record.EmployeeId.ToUpper()).FirstValue
                });
            }
            return eventStaffBasicModelCollection;
        }

        private List<EventStaffBasicInfoModel> MapEventStaffAssignmentToEventBasicInfoModel(IEnumerable<EventStaffAssignment> recordsFromDb, long podId)
        {
            var mappedList = new List<EventStaffBasicInfoModel>();
            foreach (var eventStaffAssignment in recordsFromDb)
            {
                mappedList.Add(new EventStaffBasicInfoModel
                {
                    ActualStaffOrgRoleUserId = null,
                    EventRoleId = eventStaffAssignment.StaffEventRoleId,
                    Notes = null,
                    PodId = podId,
                    ScheduledStaffOrgRoleUserId = eventStaffAssignment.ScheduledStaffOrgRoleUserId
                });
            }
            return mappedList;
        }
    }

}
