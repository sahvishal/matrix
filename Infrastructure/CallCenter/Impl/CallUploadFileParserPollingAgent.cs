using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using AutoMapper;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.CallCenter.Interfaces;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using File = Falcon.App.Core.Application.Domain.File;

namespace Falcon.App.Infrastructure.CallCenter.Impl
{
    [DefaultImplementation]
    public class CallUploadFileParserPollingAgent : ICallUploadFileParserPollingAgent
    {
        private readonly ICallUploadRepository _callUploadRepository;
        private readonly ICallUploadLogRepository _callUploadLogRepository;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly ICsvReader _csvReader;
        private readonly ICallUploadHelper _callUploadHelper;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly ICallQueueCustomerRepository _callQueueCustomerRepository;
        private readonly ICallQueueRepository _callQueueRepository;
        private readonly ICallCenterCallRepository _callCenterCallRepository;
        private readonly IEventRepository _eventRepository;
        private readonly ICallQueueCustomerCallRepository _callQueueCustomerCallRepository;
        private readonly IProspectCustomerRepository _prospectCustomerRepository;
        private readonly ICallCenterRepository _callCenterRepository;
        private readonly IProspectCustomerFactory _prospectCustomerFactory;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly ICallCenterNotesRepository _callCenterNotesRepository;
        private readonly ICallUploadRuleEngine _callUploadRuleEngine;
        private readonly IUniqueItemRepository<CustomerCallNotes> _customerCallNotesRepository;
        private readonly IDirectMailRepository _directMailRepository;
        private readonly IDirectMailTypeRepository _directMailTypeRepository;
        private readonly ICampaignRepository _campaignRepository;

        private readonly bool _isDevEnvironment;
        private readonly ILogger _logger;
        private const int PageSize = 15;
        public CallUploadFileParserPollingAgent(ICallUploadRepository callUploadRepository, ICallUploadLogRepository callUploadLogRepository, ILogManager logManager,
            IUniqueItemRepository<File> fileRepository, IMediaRepository mediaRepository, ICsvReader csvReader, ICallUploadHelper callUploadHelper, ICustomerRepository
            customerRepository, ICorporateAccountRepository corporateAccountRepository, ICallQueueCustomerRepository callQueueCustomerRepository,
            ICallQueueRepository callQueueRepository, ICallCenterCallRepository callCenterCallRepository, IEventRepository eventRepository,
            ICallQueueCustomerCallRepository callQueueCustomerCallRepository, IProspectCustomerRepository prospectCustomerRepository,
            ICallCenterRepository callCenterRepository, IProspectCustomerFactory prospectCustomerFactory, IUniqueItemRepository<CustomerCallNotes> customerCallNotesRepository,
            IOrganizationRoleUserRepository organizationRoleUserRepository, ICallCenterNotesRepository callCenterNotesRepository, ICallUploadRuleEngine callUploadRuleEngine,
            IDirectMailRepository directMailRepository, ISettings settings, IDirectMailTypeRepository directMailTypeRepository, ICampaignRepository campaignRepository)
        {
            _callUploadRepository = callUploadRepository;
            _callUploadLogRepository = callUploadLogRepository;
            _fileRepository = fileRepository;
            _mediaRepository = mediaRepository;
            _csvReader = csvReader;
            _callUploadHelper = callUploadHelper;
            _customerRepository = customerRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _callQueueCustomerRepository = callQueueCustomerRepository;
            _callQueueRepository = callQueueRepository;
            _callCenterCallRepository = callCenterCallRepository;
            _eventRepository = eventRepository;
            _callQueueCustomerCallRepository = callQueueCustomerCallRepository;
            _prospectCustomerRepository = prospectCustomerRepository;
            _callCenterRepository = callCenterRepository;
            _prospectCustomerFactory = prospectCustomerFactory;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _callCenterNotesRepository = callCenterNotesRepository;
            _callUploadRuleEngine = callUploadRuleEngine;
            _directMailRepository = directMailRepository;
            _directMailTypeRepository = directMailTypeRepository;
            _campaignRepository = campaignRepository;
            _customerCallNotesRepository = customerCallNotesRepository;

            _isDevEnvironment = settings.IsDevEnvironment;
            _logger = logManager.GetLogger("CallUploadPollingAgent");

        }

        public void PollForParsingCallUpload()
        {

            try
            {
                _logger.Info("Entering In Call Upload File Parser Polling Agent");

                var timeOfDay = DateTime.Now;
                if (_isDevEnvironment || timeOfDay.TimeOfDay > new TimeSpan(4, 0, 0))
                {
                    var callUploads = _callUploadRepository.GetFilesToParse();
                    if (callUploads.IsNullOrEmpty())
                    {
                        _logger.Info("No file found for Parsing");
                        return;
                    }

                    _logger.Info("No Of File Found For parsing: " + callUploads.Count());

                    var uploadedFileIds = callUploads.Select(x => x.FileId);
                    var uploadedFiles = _fileRepository.GetByIds(uploadedFileIds);
                    var location = _mediaRepository.GetCallUploadMediaFileLocation();

                    foreach (var callUploadDomain in callUploads)
                    {
                        try
                        {
                            callUploadDomain.ParseStartTime = DateTime.Now;

                            var fileDomain = uploadedFiles.FirstOrDefault(x => x.Id == callUploadDomain.FileId);

                            if (fileDomain == null)
                            {
                                UpdateParsingStatus(callUploadDomain, (long)CallUploadStatus.FileNotFound);
                                _logger.Info("Parsin Failed: FileNotFound CallUploadId: " + callUploadDomain.Id);
                                continue;
                            }

                            var file = location.PhysicalPath + fileDomain.Path;
                            _logger.Info("Parsing For File " + file);

                            if (!System.IO.File.Exists(file))
                            {
                                UpdateParsingStatus(callUploadDomain, (long)CallUploadStatus.FileNotFound);
                                _logger.Info("Parsin Failed: FileNotFound  CallUploadId: " + callUploadDomain.Id);
                                continue;
                            }

                            var fInfo = new FileInfo(file);
                            if (fInfo.Extension != ".csv")
                            {
                                UpdateParsingStatus(callUploadDomain, (long)CallUploadStatus.InvalidFileFormat);
                                _logger.Info("Parsin Failed: InvalidFileFormat CallUploadId: " + callUploadDomain.Id);
                                continue;
                            }

                            UpdateParsingStatus(callUploadDomain, (long)CallUploadStatus.Parsing, false);

                            var customerTable = _csvReader.ReadWithTextQualifier(file);
                            var totalCustomers = customerTable.Rows.Count;

                            var totalPages = totalCustomers / PageSize + (totalCustomers % PageSize != 0 ? 1 : 0);

                            _logger.Info("Total No Of Pages: " + totalPages + " Total No of Records " + totalCustomers);

                            var pageNumber = 1;
                            var failedCustomerList = new List<CallUploadLog>();
                            var successCustomerList = new List<CallUploadLog>();

                            while (totalPages >= pageNumber)
                            {
                                var query = customerTable.AsEnumerable();
                                _logger.Info("Parsing For Page Number: " + pageNumber);

                                var rows = query.Skip(PageSize * (pageNumber - 1)).Take(PageSize);

                                ParseCallUploadedCalls(rows, failedCustomerList, successCustomerList, callUploadDomain.Id);

                                pageNumber++;
                            }

                            callUploadDomain.SuccessfullUploadCount = successCustomerList.Count();
                            callUploadDomain.ParseEndTime = DateTime.Now;
                            callUploadDomain.StatusId = (long)CallUploadStatus.Parsed;
                            UpdateCallUploadDetail(callUploadDomain, failedCustomerList, file);

                        }
                        catch (Exception exception)
                        {
                            _logger.Error(string.Format("Error on Message: {0} \n StackTrace: {1}", exception.Message, exception.StackTrace));
                        }
                    }
                }
                else
                {
                    _logger.Info(string.Format("Call Upload Parser can not be called as time of day is {0}", timeOfDay.TimeOfDay));
                }

            }
            catch (Exception exception)
            {
                _logger.Error("all Upload Parser Exception: " + exception + "\n Stack Trace:" + exception.StackTrace);
            }
        }

        private void UpdateCallUploadDetail(CallUpload callUpload, List<CallUploadLog> failedCustomerList, string fileName)
        {

            if (failedCustomerList.Any())
            {
                try
                {
                    var location = _mediaRepository.GetCallUploadMediaFileLocation();
                    var failedFilePath = location.PhysicalPath + Path.GetFileNameWithoutExtension(fileName) + "_FailedCustomer.csv";

                    var modelData = Mapper.Map<IEnumerable<CallUploadLog>, IEnumerable<CallUploadLogViewModel>>(failedCustomerList);

                    var exporter = ExportableDataGeneratorProcessManager<ViewModelBase, ModelFilterBase>.GetCsvExporter<CallUploadLogViewModel>();

                    WriteCsv(failedFilePath, exporter, modelData);

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
                    callUpload.FailedUploadCount = failedCustomerList.Count();
                    callUpload.LogFileId = file.Id;
                }
                catch (Exception ex)
                {
                    _logger.Error("exception Raised While Creating Failed Customer Records \n message: " + ex.Message + " stacktrace: " + ex.StackTrace);
                }
            }

            _callUploadRepository.Save(callUpload);
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

        private void ParseCallUploadedCalls(IEnumerable<DataRow> rows, List<CallUploadLog> failedCustomerList, List<CallUploadLog> successCustomerList, long callUploadId)
        {
            var callUploadLogs = rows.Select(row => _callUploadHelper.GetUploadLog(row, callUploadId));

            if (callUploadLogs.IsNullOrEmpty())
            {
                _logger.Info("No Record Found For Parsing in file");
                return;
            }

            SaveFailedCustomers(failedCustomerList, callUploadLogs);

            callUploadLogs = callUploadLogs.Where(x => x.IsSuccessfull);

            if (callUploadLogs.IsNullOrEmpty())
            {
                _logger.Info("No Successfull Customer Found For Parsing in file");
                return;
            }
            var customerIds = callUploadLogs.Select(x => x.CustomerId).Distinct();

            var outboundCustomerIds = callUploadLogs.Where(x => !x.IsDirectMail).Select(x => x.CustomerId).ToArray();

            IEnumerable<Customer> customers = null;

            try
            {
                customers = _customerRepository.GetCustomers(customerIds.ToArray());
            }
            catch (Exception ex)
            {
                _logger.Error(" Exception : " + ex.Message + " \n Stack Trace: " + ex.StackTrace);
            }

            if (customers != null && customers.Any())
            {
                var healthPlans = _corporateAccountRepository.GetAllHealthPlan();

                var events = ((IUniqueItemRepository<Event>)_eventRepository).GetByIds(callUploadLogs.Where(x => x.EventId > 0).Select(x => x.EventId).ToArray());

                var callQueue = _callQueueRepository.GetCallQueueByCategory(HealthPlanCallQueueCategory.CallRound);

                var callQueueCustomers = _callQueueCustomerRepository.GetCallQueueCustomersBuCustomerIds(outboundCustomerIds, callQueue.Id).ToList();

                var prospectCustomers = _prospectCustomerRepository.GetProspectCustomersByCustomerIds(outboundCustomerIds);

                var calls = _callCenterCallRepository.GetCallDetails(outboundCustomerIds);

                var emailIds = callUploadLogs.Select(x => x.Email).Distinct().ToList();

                var userNames = callUploadLogs.Where(x => !string.IsNullOrEmpty(x.UserName)).Select(x => x.UserName).Distinct().ToList();

                var organizationRoleUserEmail = _organizationRoleUserRepository.GetNameIdPairofOrgRoleIdByEmail(emailIds, (long)Roles.CallCenterRep);

                var organizationRoleUserUserName = _organizationRoleUserRepository.GetNameIdPairofOrgRoleIdByUserNames(userNames, (long)Roles.CallCenterRep);

                var directMailTypes = _directMailTypeRepository.GetAll();


                foreach (var callUploadLog in callUploadLogs)
                {
                    try
                    {
                        var customer = customers.SingleOrDefault(x => x.CustomerId == callUploadLog.CustomerId);
                        if (customer == null)
                        {
                            callUploadLog.IsSuccessfull = false;
                            callUploadLog.ErrorMessage = "Customer ID is not valid.";
                            _callUploadLogRepository.SaveCallUploadLog(callUploadLog);
                            failedCustomerList.Add(callUploadLog);
                            continue;
                        }

                        if (string.IsNullOrEmpty(customer.Tag))
                        {
                            callUploadLog.IsSuccessfull = false;
                            callUploadLog.ErrorMessage = "Customer does not belong to any HealthPlan.";
                            _callUploadLogRepository.SaveCallUploadLog(callUploadLog);
                            failedCustomerList.Add(callUploadLog);
                            continue;
                        }

                        var healthPlan = healthPlans.SingleOrDefault(x => x.Tag == customer.Tag);

                        if (healthPlan == null)
                        {
                            callUploadLog.IsSuccessfull = false;
                            callUploadLog.ErrorMessage = "HealthPlan " + customer.Tag + " not found.";
                            _callUploadLogRepository.SaveCallUploadLog(callUploadLog);
                            failedCustomerList.Add(callUploadLog);
                            continue;
                        }

                        var orgRoleId = _callUploadHelper.GetOrganizationRoleId(callUploadLog, organizationRoleUserEmail, organizationRoleUserUserName);

                        if (orgRoleId <= 0)
                        {
                            callUploadLog.IsSuccessfull = false;
                            callUploadLog.ErrorMessage = "Created By Information does not found.";
                            _callUploadLogRepository.SaveCallUploadLog(callUploadLog);
                            failedCustomerList.Add(callUploadLog);
                            continue;
                        }

                        long? directMailTypeId = null;
                        if (callUploadLog.IsDirectMail)
                        {
                            var campaign = _campaignRepository.GetCampaignByName(callUploadLog.CampaignName);

                            if (campaign == null)
                            {
                                callUploadLog.IsSuccessfull = false;
                                callUploadLog.ErrorMessage = " Please provide a valid campaign name.";
                                _callUploadLogRepository.SaveCallUploadLog(callUploadLog);
                                failedCustomerList.Add(callUploadLog);
                                continue;
                            }

                            if (!string.IsNullOrEmpty(callUploadLog.DirectMailType))
                            {
                                var directMailType = directMailTypes.SingleOrDefault(s => s.Name.ToLower() == callUploadLog.DirectMailType.ToLower());

                                if (directMailType == null)
                                {
                                    callUploadLog.IsSuccessfull = false;
                                    callUploadLog.ErrorMessage = " Please provide a valid Direct Mail Type.";
                                    _callUploadLogRepository.SaveCallUploadLog(callUploadLog);
                                    failedCustomerList.Add(callUploadLog);
                                    continue;
                                }
                                directMailTypeId = directMailType.Id;
                            }
                            var isInvalidAddress = false;
                            if (callUploadLog.IsInvalidAddress != null)
                            {
                                isInvalidAddress = callUploadLog.IsInvalidAddress.ToLower().Trim() == "yes" ? true : false;
                            }

                            var directMail = new DirectMail
                            {
                                CustomerId = callUploadLog.CustomerId,
                                MailDate = callUploadLog.OutreachDateTime.Value.Date,
                                CallUploadId = callUploadLog.CallUploadId,
                                CampaignId = campaign.Id,
                                DirectMailTypeId = directMailTypeId,
                                Mailedby = orgRoleId,
                                IsInvalidAddress = isInvalidAddress,
                                Notes = isInvalidAddress ? "Direct Mail returned because of invalid address." : string.Empty,
                            };

                            _directMailRepository.Save(directMail);
                        }
                        else
                        {
                            Event theEventData = null;
                            if (callUploadLog.EventId > 0)
                            {
                                theEventData = events.SingleOrDefault(x => x.Id == callUploadLog.EventId);
                                if (theEventData == null)
                                {
                                    callUploadLog.IsSuccessfull = false;
                                    callUploadLog.ErrorMessage = "Event Id provide is not valid.";
                                    _callUploadLogRepository.SaveCallUploadLog(callUploadLog);
                                    failedCustomerList.Add(callUploadLog);
                                    continue;
                                }
                            }

                            if (callUploadLog.EventId > 0)
                            {
                                var isValidEventForAccount = _eventRepository.ValidateEventForAccount(callUploadLog.EventId, healthPlan.Id);
                                if (!isValidEventForAccount)
                                {
                                    callUploadLog.IsSuccessfull = false;
                                    callUploadLog.ErrorMessage = "Event Id provide is not valid for customer HealthPlan.";
                                    _callUploadLogRepository.SaveCallUploadLog(callUploadLog);
                                    failedCustomerList.Add(callUploadLog);
                                    continue;
                                }
                            }

                            var prospectCustomer = prospectCustomers.FirstOrDefault(x => x.CustomerId == customer.CustomerId);

                            if (prospectCustomer == null && customer != null)
                            {
                                prospectCustomer = _prospectCustomerFactory.CreateProspectCustomerFromCustomer(customer, false);
                                prospectCustomer = ((IUniqueItemRepository<ProspectCustomer>)_prospectCustomerRepository).Save(prospectCustomer);
                            }

                            var callQueueCustomer = SaveCallQueueCustomer(callQueue.Id, callUploadLog, healthPlan.Id,
                                callQueueCustomers);

                            var call = SaveCall(callUploadLog, theEventData != null ? theEventData.Id : 0, orgRoleId, healthPlan.Id);

                            if (prospectCustomer != null)
                            {
                                UpdateContactedInfo(prospectCustomer.Id, call.Id, orgRoleId);
                            }

                            SaveCallQueueCustomerCall(callQueueCustomer, call);
                            SaveCallNotes(callUploadLog, call.Id, orgRoleId);

                            var customerCalls = calls.Where(x => x.CalledCustomerId == callUploadLog.CustomerId);
                            bool isRemovedFromCallQueue;
                            var isRuleApplied = _callUploadRuleEngine.ApplyRuleEngine(callUploadLog, customerCalls, prospectCustomer, orgRoleId, callQueueCustomer.Id, callQueueCustomer.CallQueueId, out isRemovedFromCallQueue, _logger);

                            if (isRemovedFromCallQueue)
                            {
                                callQueueCustomer.Status = CallQueueStatus.Removed;
                                _callQueueCustomerRepository.Save(callQueueCustomer);
                            }

                            callUploadLog.IsRuleApplied = isRuleApplied;
                        }

                        successCustomerList.Add(callUploadLog);

                        _callUploadLogRepository.SaveCallUploadLog(callUploadLog);

                    }
                    catch (Exception ex)
                    {
                        callUploadLog.IsSuccessfull = false;
                        callUploadLog.ErrorMessage = "Message: " + ex.Message + "\n stack Trace: " + ex.StackTrace;
                        failedCustomerList.Add(callUploadLog);
                        _logger.Error("Message: " + ex.Message + "\n stack Trace: " + ex.StackTrace);
                    }
                }
            }
            else
            {
                foreach (var callUploadLog in callUploadLogs)
                {
                    callUploadLog.IsSuccessfull = false;
                    callUploadLog.ErrorMessage = "Please Provide a valid CustomerId";
                    failedCustomerList.Add(callUploadLog);
                }
            }


            SaveFailedCustomers(failedCustomerList, callUploadLogs);

        }

        private void SaveFailedCustomers(List<CallUploadLog> failedCustomerList, IEnumerable<CallUploadLog> callUploadLogs)
        {
            var failedCustomers = callUploadLogs.Where(x => !x.IsSuccessfull).ToList();

            failedCustomerList.AddRange(failedCustomers);

            if (!failedCustomers.IsNullOrEmpty())
            {
                _logger.Info("Failed Customer Count: " + failedCustomers.Count());

                foreach (var failedCustomer in failedCustomers)
                {
                    _callUploadLogRepository.SaveCallUploadLog(failedCustomer);
                }
            }
        }



        private bool UpdateContactedInfo(long prospectCustomerId, long callId, long orgRoleUserId)
        {
            _callCenterRepository.BindCallToProspectCustomer(callId, prospectCustomerId);
            return _prospectCustomerRepository.UpdateContactedStatus(prospectCustomerId, orgRoleUserId);
        }

        private void UpdateParsingStatus(CallUpload callFile, long statusId, bool isCompleted = true)
        {
            callFile.StatusId = statusId; ;
            callFile.ParseEndTime = DateTime.Now;
            callFile.ParseEndTime = isCompleted ? DateTime.Now : (DateTime?)null;

            _callUploadRepository.Save(callFile);
        }

        private CallQueueCustomer SaveCallQueueCustomer(long callQueueId, CallUploadLog callUploadLog, long healthPlanId, List<CallQueueCustomer> callQueueCustomers)
        {

            if (callQueueCustomers.IsNullOrEmpty())
            {
                callQueueCustomers = new List<CallQueueCustomer>();
            }

            var existingCallQueueCustomer = callQueueCustomers.FirstOrDefault(x => x.CustomerId.HasValue && x.CustomerId.Value == callUploadLog.CustomerId);

            var callQueueCustomer = new CallQueueCustomer
            {
                CallQueueId = callQueueId,
                CustomerId = callUploadLog.CustomerId,
                HealthPlanId = healthPlanId
            };

            if (existingCallQueueCustomer == null)
            {
                callQueueCustomer.IsActive = true;
                callQueueCustomer.Attempts = 0;
                callQueueCustomer.DateCreated = callUploadLog.OutreachDateTime.Value;
                callQueueCustomer.Status = CallQueueStatus.Initial;
                callQueueCustomer.CallDate = callUploadLog.OutreachDateTime.Value;
            }
            else
            {
                callQueueCustomer.IsActive = existingCallQueueCustomer.IsActive;
                callQueueCustomer.Attempts = existingCallQueueCustomer.Attempts + 1;
                callQueueCustomer.DateCreated = existingCallQueueCustomer.DateCreated;
                callQueueCustomer.DateModified = callUploadLog.OutreachDateTime.Value;
                callQueueCustomer.Status = existingCallQueueCustomer.Status;
                callQueueCustomer.CallDate = existingCallQueueCustomer.CallDate;
                callQueueCustomer.Id = existingCallQueueCustomer.Id;
            }

            var newCallQueueCustomer = _callQueueCustomerRepository.Save(callQueueCustomer);

            if (existingCallQueueCustomer == null && !callQueueCustomers.IsNullOrEmpty())
            {
                callQueueCustomers.Add(newCallQueueCustomer);
            }

            return newCallQueueCustomer;
        }

        private Call SaveCall(CallUploadLog callLog, long eventId, long orgRoleUserId, long healthPlanId)
        {

            var call = new Call
            {
                CalledCustomerId = callLog.CustomerId,
                StartTime = callLog.OutreachDateTime,
                EndTime = callLog.OutreachDateTime.Value.AddMinutes(2),
                DateCreated = callLog.OutreachDateTime.Value,
                CallStatus = CallType.Existing_Customer.ToString().Replace("_", " "),
                EventId = eventId,
                IsIncoming = false,
                Status = (long)callLog.OutcomeEnum.Value,
                Disposition = callLog.DispositionEnum.HasValue ? ((ProspectCustomerTag)callLog.DispositionEnum.Value).ToString() : string.Empty,
                IsUploaded = true,
                IsNewCustomer = false,
                CreatedByOrgRoleUserId = orgRoleUserId,
                CallDateTime = callLog.OutreachDateTime.Value,
                DateModified = callLog.OutreachDateTime.Value,
                NotInterestedReasonId = callLog.ReasonEnum,
                HealthPlanId = healthPlanId
            };

            return _callCenterCallRepository.Save(call);
        }

        private void SaveCallQueueCustomerCall(CallQueueCustomer callQueueCustomer, Call call)
        {
            _callQueueCustomerCallRepository.Save(new CallQueueCustomerCall { CallId = call.Id, CallQueueCustomerId = callQueueCustomer.Id });
        }

        private void SaveCallNotes(CallUploadLog callUploadLog, long callId, long orgRoleId)
        {
            if (string.IsNullOrEmpty(callUploadLog.Notes)) return;

            _callCenterNotesRepository.Save(new CallCenterNotes
            {
                CallId = callId,
                DateCreated = callUploadLog.OutreachDateTime.Value,
                IsActive = true,
                Notes = callUploadLog.Notes,
                NotesSequence = 1
            });

            SaveRegistrationNotes(callUploadLog.CustomerId, callUploadLog.Notes, orgRoleId, callUploadLog.OutreachDateTime.Value);
        }

        private void SaveRegistrationNotes(long customerId, string notes, long organizationRoleUserId, DateTime notesAddedOn)
        {
            if (customerId <= 0) return;
            var customerRegistrationNotes = new CustomerCallNotes
            {
                CustomerId = customerId,
                EventId = null,
                Notes = notes,
                NotesType = CustomerRegistrationNotesType.AppointmentNote,
                DataRecorderMetaData = new DataRecorderMetaData
                {
                    DateCreated = notesAddedOn,
                    DataRecorderCreator = new OrganizationRoleUser(organizationRoleUserId)
                }
            };

            _customerCallNotesRepository.Save(customerRegistrationNotes);
        }

    }
}
