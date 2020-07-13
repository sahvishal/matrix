using System;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.Extension;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Enum;

namespace Falcon.App.Infrastructure.CallCenter.Impl
{
    [DefaultImplementation]
    public class CallUploadService : ICallUploadService
    {
        private readonly ICallUploadListModelFactory _callUploadListModelFactory;
        private readonly ICallUploadRepository _callUploadRepository;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly ICallQueueRepository _callQueueRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly ICallCenterCallRepository _callCenterCallRepository;
        private readonly ICallQueueCustomerRepository _callQueueCustomerRepository;
        private readonly ICallQueueCustomerCallRepository _callQueueCustomerCallRepository;
        private readonly ICallQueueCustomerContactService _callQueueCustomerContactService;
        private readonly ICustomerAccountGlocomNumberService _customerAccountGlocomNumberService;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProspectCustomerRepository _prospectCustomerRepository;
        private readonly ICustomerService _customerService;

        public CallUploadService(ICallUploadListModelFactory callUploadListModelFactory, ICallUploadRepository callUploadRepository, IUniqueItemRepository<File> fileRepository, IOrganizationRoleUserRepository organizationRoleUserRepository,
            IMediaRepository mediaRepository, ICallQueueRepository callQueueRepository, ICorporateAccountRepository corporateAccountRepository, ICallCenterCallRepository callCenterCallRepository,
            ICallQueueCustomerRepository callQueueCustomerRepository, ICallQueueCustomerCallRepository callQueueCustomerCallRepository, ICallQueueCustomerContactService callQueueCustomerContactService,
            ICustomerAccountGlocomNumberService customerAccountGlocomNumberService, ICustomerRepository customerRepository, IProspectCustomerRepository prospectCustomerRepository,
            ICustomerService customerService)
        {
            _callUploadListModelFactory = callUploadListModelFactory;
            _callUploadRepository = callUploadRepository;
            _fileRepository = fileRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _mediaRepository = mediaRepository;
            _callQueueRepository = callQueueRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _callCenterCallRepository = callCenterCallRepository;
            _callQueueCustomerRepository = callQueueCustomerRepository;
            _callQueueCustomerCallRepository = callQueueCustomerCallRepository;
            _callQueueCustomerContactService = callQueueCustomerContactService;
            _customerAccountGlocomNumberService = customerAccountGlocomNumberService;
            _customerRepository = customerRepository;
            _prospectCustomerRepository = prospectCustomerRepository;
            _customerService = customerService;
        }

        public CallUploadListModel GetCallUploadDetails(int pageNumber, int pageSize, CallUploadListModelFilter filter, out int totalRecords)
        {
            var callUploads = _callUploadRepository.GetByFilter(pageNumber, pageSize, filter, out totalRecords);

            if (callUploads == null || !callUploads.Any()) return null;

            var successfileIds = callUploads.Select(s => s.FileId).ToArray();

            var failedfileIds = callUploads.Where(x => x.LogFileId.HasValue).Select(s => s.LogFileId.Value).ToArray();

            var fileIds = successfileIds.Concat(failedfileIds).ToArray();

            IEnumerable<FileModel> fileModels = null;

            if (fileIds != null && fileIds.Any())
            {
                var files = _fileRepository.GetByIds(fileIds);

                if (files != null && files.Any())
                {
                    fileModels = GetFileModelFromFile(files, _mediaRepository.GetCallUploadMediaFileLocation());
                }
            }

            var callUploadByIds = callUploads.Select(c => c.UploadedBy).ToArray();

            IEnumerable<OrderedPair<long, string>> uploadedbyAgentNameIdPair = null;

            if (callUploadByIds != null && callUploadByIds.Any())
            {
                uploadedbyAgentNameIdPair = _organizationRoleUserRepository.GetNameIdPairofUsers(callUploadByIds).ToArray();
            }

            return _callUploadListModelFactory.Create(fileModels, callUploads, uploadedbyAgentNameIdPair);
        }

        private IEnumerable<FileModel> GetFileModelFromFile(IEnumerable<File> files, MediaLocation location)
        {
            var collection = new List<FileModel>();
            files.ToList().ForEach(f =>
            {
                var fileModel = new FileModel
                {
                    Id = f.Id,
                    Caption = System.IO.Path.GetFileNameWithoutExtension(f.Path),
                    FileName = f.Path,
                    FileSize = f.FileSize,
                    FileType = (long)f.Type,
                    PhisicalPath = f.Path,
                    UploadedBy = f.UploadedBy.Id,
                    Url = location.Url
                };
                collection.Add(fileModel);
            });
            return collection;
        }

        public long SaveGmsDialerCall(GmsDialerCallModel model, long orgRoleUserId, ILogger logger)
        {
            var callDateTime = Convert.ToDateTime(model.CallDate + " " + model.CallTime);

            long status = 0;
            var disposition = string.Empty;

            if (model.CallDisposition.ToUpper() == "ANS.MACH")//Left Voice mail
                status = (long)CallStatus.VoiceMessage;
            else if (model.CallDisposition.ToUpper() == "NO.ANS") //No Answer/Busy/Mail Full
                status = (long)CallStatus.NoAnswer;
            else if (model.CallDisposition.ToUpper() == "BUSY") //No Answer/Busy/Mail Full
                status = (long)CallStatus.NoAnswer;
            else if (model.CallDisposition.ToUpper() == "DEAD")
            { //Incorrect Phone number
                status = (long)CallStatus.TalkedtoOtherPerson;
                disposition = ProspectCustomerTag.IncorrectPhoneNumber_TalkedToOthers.ToString();
            }

            var callQueue = _callQueueRepository.GetCallQueueByCategory(HealthPlanCallQueueCategory.MailRound);

            long customerId = Convert.ToInt64(model.CustomerId);
            var customer = _customerRepository.GetCustomer(customerId);

            var healthPlanId = _corporateAccountRepository.GetHealthPlanIdByAccountName(model.HealthPlan);
            if (healthPlanId == 0)
            {
                logger.Info(string.Format("Unable to parse for Customer Id : {0}. Healthplan not found by Name : {1}", model.CustomerId, model.HealthPlan));
                return 0;
            }

            var calledNumber = !string.IsNullOrEmpty(model.PhoneHome) ? model.PhoneHome : !string.IsNullOrEmpty(model.PhoneOffice) ? model.PhoneOffice : model.PhoneCell;

            var callQueueCustomer = _callQueueCustomerRepository.GetCallQueueCustomerByCustomerIdAndHealthPlanId(customerId, healthPlanId, HealthPlanCallQueueCategory.MailRound);
            if (callQueueCustomer == null)
            {
                logger.Info(string.Format("Unable to parse for Customer Id : {0}. Call Queue Customer not found.", model.CustomerId));
                return 0;
            }

            bool? isContacted = false;
            if (callQueue.Category == HealthPlanCallQueueCategory.AppointmentConfirmation)
                isContacted = null;
            else
                isContacted = (status == (long)CallStatus.Attended || status == (long)CallStatus.VoiceMessage || status == (long)CallStatus.LeftMessageWithOther);

            var call = new Call()
            {
                CallDateTime = callDateTime,
                StartTime = callDateTime,
                EndTime = callDateTime,
                CallStatus = CallType.Existing_Customer.GetDescription(),
                IsIncoming = false,
                CalledCustomerId = customerId,
                Status = status,
                CreatedByOrgRoleUserId = orgRoleUserId,
                IsNewCustomer = false,
                DateCreated = callDateTime,
                DateModified = callDateTime,
                ReadAndUnderstood = true,
                HealthPlanId = healthPlanId,
                CallQueueId = callQueue.Id,
                DialerType = (long)DialerType.Gms,
                CalledInNumber = model.CallerId,
                CallerNumber = calledNumber,
                CallBackNumber = calledNumber,
                IsContacted = isContacted,
                Disposition = disposition,
                ProductTypeId = customer.ProductTypeId
            };

            call = _callCenterCallRepository.Save(call);

            if (status == (long)CallStatus.TalkedtoOtherPerson && disposition == ProspectCustomerTag.IncorrectPhoneNumber_TalkedToOthers.ToString())
            {
                _customerService.UpdateIsIncorrectPhoneNumber(customerId, true, orgRoleUserId);
            }

            var callQueueCustomerCall = new CallQueueCustomerCall { CallQueueCustomerId = callQueueCustomer.Id, CallId = call.Id };
            _callQueueCustomerCallRepository.Save(callQueueCustomerCall);

            var customerAccountGlocomNumber = new CustomerAccountGlocomNumber
            {
                CallId = call.Id,
                CustomerId = customerId,
                GlocomNumber = PhoneNumber.ToNumber(model.CallerId),
                CreatedDate = callDateTime,
                IsActive = true
            };
            _customerAccountGlocomNumberService.SaveAccountCheckoutPhoneNumber(customerAccountGlocomNumber);

            bool removeFromCallQueue = status == (long)CallStatus.TalkedtoOtherPerson;
            var callQueueStatus = CallQueueStatus.Initial;
            if (removeFromCallQueue)
                callQueueStatus = CallQueueStatus.Removed;

            callQueueCustomer.Disposition = disposition;

            _callQueueCustomerContactService.SetCallQueueCustomerStatus(callQueueCustomer, callQueueStatus, orgRoleUserId, false, status, callDateTime);


            var prospectCustomerId = callQueueCustomer.ProspectCustomerId ?? 0;

            if (prospectCustomerId == 0)
            {
                var prospectCustomer = _prospectCustomerRepository.GetProspectCustomerByCustomerId(customerId);
                if (prospectCustomer != null)
                {
                    prospectCustomerId = prospectCustomer.Id;
                }
            }

            _callQueueCustomerRepository.UpdateOtherCustomerAttempt(callQueueCustomer.Id, customerId, prospectCustomerId, orgRoleUserId, callQueueCustomer.CallDate, removeFromCallQueue, callQueueCustomer.CallQueueId, status, callDateTime, isForParsing: true, disposition: disposition);

            return call.Id;
        }

        public long SaveViciDialerCall(ViciDialerCallModel model, long orgRoleUserId)
        {
            long status = 0;
            var disposition = string.Empty;

            if (model.Disposition.ToUpper() == "ANS.MACH")//Left Voice mail
                status = (long)CallStatus.VoiceMessage;
            else if (model.Disposition.ToUpper() == "NO.ANS" || model.Disposition.ToUpper() == "BUSY") //No Answer/Busy/Mail Full
                status = (long)CallStatus.NoAnswer;
            else if (model.Disposition.ToUpper() == "DEAD") //Incorrect Phone number
            {
                status = (long)CallStatus.TalkedtoOtherPerson;
                disposition = ProspectCustomerTag.IncorrectPhoneNumber_TalkedToOthers.ToString();
            }
            CallQueue callQueue = null;
            if (model.CallQueueId > 0)
                callQueue = _callQueueRepository.GetById(model.CallQueueId);

            var customer = _customerRepository.GetCustomer(model.CustomerId);
            var account = _corporateAccountRepository.GetByTag(customer.Tag);

            bool? isContacted = false;
            if (callQueue == null || callQueue.Category == HealthPlanCallQueueCategory.AppointmentConfirmation)
                isContacted = null;
            else
                isContacted = (status == (long)CallStatus.Attended || status == (long)CallStatus.VoiceMessage || status == (long)CallStatus.LeftMessageWithOther);

            var call = new Call()
            {
                CallDateTime = model.CallStartDateTime,
                StartTime = model.CallStartDateTime,
                EndTime = model.CallEndDateTime,
                CallStatus = CallType.Existing_Customer.GetDescription(),
                IsIncoming = false,
                CalledCustomerId = model.CustomerId,
                Status = status,
                CreatedByOrgRoleUserId = orgRoleUserId,
                IsNewCustomer = false,
                DateCreated = model.CallStartDateTime,
                DateModified = model.CallStartDateTime,
                ReadAndUnderstood = true,
                HealthPlanId = account != null ? account.Id : (long?)null,
                CallQueueId = callQueue != null ? callQueue.Id : (long?)null,
                DialerType = (long)DialerType.Vici,
                CalledInNumber = model.CallerId,
                CallerNumber = model.CallerPhoneNumber,
                CallBackNumber = model.CallerPhoneNumber,
                IsContacted = isContacted,
                Disposition = disposition,
                ProductTypeId=customer.ProductTypeId
            };

            call = _callCenterCallRepository.Save(call);

            if (status == (long)CallStatus.TalkedtoOtherPerson && disposition == ProspectCustomerTag.IncorrectPhoneNumber_TalkedToOthers.ToString())
            {
                _customerService.UpdateIsIncorrectPhoneNumber(model.CustomerId, true, orgRoleUserId);
            }

            if (!string.IsNullOrEmpty(model.CallerId))
            {
                var customerAccountGlocomNumber = new CustomerAccountGlocomNumber
                {
                    CallId = call.Id,
                    CustomerId = model.CustomerId,
                    GlocomNumber = PhoneNumber.ToNumber(model.CallerId),
                    CreatedDate = model.CallStartDateTime,
                    IsActive = true
                };
                _customerAccountGlocomNumberService.SaveAccountCheckoutPhoneNumber(customerAccountGlocomNumber);
            }

            if (callQueue != null)
            {
                var callQueueCustomer = _callQueueCustomerRepository.GetCallQueueCustomerByCustomerIdAndHealthPlanId(model.CustomerId, account.Id, callQueue.Category);

                var callQueueCustomerCall = new CallQueueCustomerCall { CallQueueCustomerId = callQueueCustomer.Id, CallId = call.Id };
                _callQueueCustomerCallRepository.Save(callQueueCustomerCall);



                bool removeFromCallQueue = status == (long)CallStatus.TalkedtoOtherPerson;
                var callQueueStatus = CallQueueStatus.Initial;
                if (removeFromCallQueue)
                    callQueueStatus = CallQueueStatus.Removed;

                _callQueueCustomerContactService.SetCallQueueCustomerStatus(callQueueCustomer, callQueueStatus, orgRoleUserId, false, status, model.CallStartDateTime);


                var prospectCustomerId = callQueueCustomer.ProspectCustomerId ?? 0;

                if (prospectCustomerId == 0)
                {
                    var prospectCustomer = _prospectCustomerRepository.GetProspectCustomerByCustomerId(model.CustomerId);
                    if (prospectCustomer != null)
                    {
                        prospectCustomerId = prospectCustomer.Id;
                    }
                }

                _callQueueCustomerRepository.UpdateOtherCustomerAttempt(callQueueCustomer.Id, model.CustomerId, prospectCustomerId, orgRoleUserId, callQueueCustomer.CallDate, removeFromCallQueue, callQueueCustomer.CallQueueId, status, model.CallStartDateTime, isForParsing: true, disposition: disposition);
            }

            return call.Id;
        }
    }
}
