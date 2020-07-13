using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Transactions;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Insurance;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medicare;
using Falcon.App.Core.Medicare.Enum;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.OutboundReport;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using Falcon.Data;
using File = Falcon.App.Core.Application.Domain.File;

namespace Falcon.App.Infrastructure.Operations.Impl
{
    [DefaultImplementation]
    public class MergeCustomerUploadService : IMergeCustomerUploadService
    {
        private readonly IMergeCustomerUploadRepository _mergeCustomerUploadRepository;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly IMediaRepository _mediaRepository;

        private readonly ICustomerRepository _customerRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly ICustomerProfileHistoryRepository _customerProfileHistoryRepository;
        private readonly IMergeCustomerUploadLogRepository _mergeCustomerUploadLogRepository;

        private readonly IMergeCustomerUploadListModelFactory _mergeCustomerUploadListModelFactory;
        private readonly IRapsRepository _rapsRepository;
        private readonly ICustomerBillingAccountRepository _customerBillingAccountRepository;
        private readonly ICustomerPredictedZipRespository _customerPredictedZipRespository;
        private readonly ILogger _logger;
        private readonly IMedicareApiService _medicareApiService;
        private readonly ISettings _settings;
        private readonly ICorporateCustomerCustomTagRepository _corporateCustomerCustomTagRepository;
        private readonly ICustomerEligibilityRepository _customerEligibilityRepository;
        private readonly ICustomerResultPostedRepository _customerResultPostedRepository;
        private readonly ICustomerTargetedRepository _customerTargetedRepository;
        private readonly ICustomerTraleRepository _customerTraleRepository;
        private readonly ICareCodingOutboundRepository _careCodingOutboundRepository;
        private readonly IMedicationRepository _medicationRepository;
        private readonly ISuspectConditionRepository _suspectConditionRepository;
        private readonly ICustomerWarmTransferRepository _customerWarmTransferRepository;
        private readonly ICustomerClinicalQuestionAnswerRepository _customerClinicalQuestionAnswerRepository;

        public MergeCustomerUploadService(IMergeCustomerUploadRepository mergeCustomerUploadRepository, IUniqueItemRepository<File> fileRepository,
            IOrganizationRoleUserRepository organizationRoleUserRepository, IMediaRepository mediaRepository, ICustomerRepository customerRepository,
            IEventCustomerRepository eventCustomerRepository, IEventCustomerResultRepository eventCustomerResultRepository,
            ICustomerProfileHistoryRepository customerProfileHistoryRepository, IMergeCustomerUploadLogRepository mergeCustomerUploadLogRepository,
            IMergeCustomerUploadListModelFactory mergeCustomerUploadListModelFactory, IRapsRepository rapsRepository,
            ICustomerBillingAccountRepository customerBillingAccountRepository, ICustomerPredictedZipRespository customerPredictedZipRespository,
            ILogManager logManager, IMedicareApiService medicareApiService, ISettings settings, ICorporateCustomerCustomTagRepository corporateCustomerCustomTagRepository,
            ICustomerEligibilityRepository customerEligibilityRepository, ICustomerResultPostedRepository customerResultPostedRepository,
            ICustomerTargetedRepository customerTargetedRepository, ICustomerTraleRepository customerTraleRepository,
            ICareCodingOutboundRepository careCodingOutboundRepository, ICustomerWarmTransferRepository customerWarmTransferRepository,
            IMedicationRepository medicationRepository, ISuspectConditionRepository suspectConditionRepository, ICustomerClinicalQuestionAnswerRepository customerClinicalQuestionAnswerRepository)
        {
            _mergeCustomerUploadRepository = mergeCustomerUploadRepository;
            _fileRepository = fileRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _mediaRepository = mediaRepository;

            _customerRepository = customerRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _customerProfileHistoryRepository = customerProfileHistoryRepository;
            _mergeCustomerUploadLogRepository = mergeCustomerUploadLogRepository;
            _mergeCustomerUploadListModelFactory = mergeCustomerUploadListModelFactory;
            _rapsRepository = rapsRepository;
            _customerBillingAccountRepository = customerBillingAccountRepository;
            _customerPredictedZipRespository = customerPredictedZipRespository;
            _medicareApiService = medicareApiService;
            _settings = settings;
            _corporateCustomerCustomTagRepository = corporateCustomerCustomTagRepository;
            _customerEligibilityRepository = customerEligibilityRepository;
            _customerResultPostedRepository = customerResultPostedRepository;
            _customerTargetedRepository = customerTargetedRepository;
            _customerTraleRepository = customerTraleRepository;
            _careCodingOutboundRepository = careCodingOutboundRepository;
            _medicationRepository = medicationRepository;
            _suspectConditionRepository = suspectConditionRepository;
            _customerWarmTransferRepository = customerWarmTransferRepository;
            _customerClinicalQuestionAnswerRepository = customerClinicalQuestionAnswerRepository;
            _logger = logManager.GetLogger("MergeCustomer");
        }

        public MergeCustomerUploadListModel GetMergeCustomerUploadDetails(int pageNumber, int pageSize, MergeCustomerUploadListModelFilter filter, out int totalRecords)
        {
            var mergerCustomerUploads = _mergeCustomerUploadRepository.GetByFilter(pageNumber, pageSize, filter, out totalRecords);

            if (mergerCustomerUploads == null || !mergerCustomerUploads.Any()) return null;

            var successfileIds = mergerCustomerUploads.Select(s => s.FileId).ToArray();

            var failedfileIds = mergerCustomerUploads.Where(x => x.LogFileId.HasValue).Select(s => s.LogFileId.Value).ToArray();

            var fileIds = successfileIds.Concat(failedfileIds).ToArray();

            IEnumerable<FileModel> fileModels = null;

            if (fileIds != null && fileIds.Any())
            {
                var files = _fileRepository.GetByIds(fileIds);

                if (files != null && files.Any())
                {
                    fileModels = GetFileModelFromFile(files, _mediaRepository.GetMergeCustomerUploadMediaFileLocation());
                }
            }

            var uploadByIds = mergerCustomerUploads.Select(c => c.UploadedBy).ToArray();

            IEnumerable<OrderedPair<long, string>> uploadedbyAgentNameIdPair = null;

            if (uploadByIds != null && uploadByIds.Any())
            {
                uploadedbyAgentNameIdPair = _organizationRoleUserRepository.GetNameIdPairofUsers(uploadByIds).ToArray();
            }


            return _mergeCustomerUploadListModelFactory.Create(fileModels, mergerCustomerUploads, uploadedbyAgentNameIdPair);

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


        public MergeCustomerUploadLog ParseMergeCustomerLog(MergeCustomerUploadLog mergeCustomerUploadLog, long orgRoleId)
        {
            try
            {

                var duplicateCustomers = mergeCustomerUploadLog.DuplicateCustomerId;

                Customer customer = null;
                _logger.Info("fetching customer");
                try
                {
                    customer = _customerRepository.GetCustomer(mergeCustomerUploadLog.CustomerId);
                }
                catch (Exception ex)
                {
                    _logger.Error("some error occurred while fetching customer");
                    _logger.Error(string.Format("ex message {0} stack trace {1}", ex.Message, ex.StackTrace));
                    mergeCustomerUploadLog.StatusId = (long)MergeCustomerUploadStatus.ParseFailed;
                    mergeCustomerUploadLog.ErrorMessage = " Customer Id does not exist in system" + " | ";
                    return mergeCustomerUploadLog;
                }

                var duplicateCustomerIds = duplicateCustomers.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim());

                var errorMessage = string.Empty;

                foreach (var duplicateCustomerId in duplicateCustomerIds)
                {
                    try
                    {
                        long dcustomerId;
                        long.TryParse(duplicateCustomerId, out dcustomerId);

                        if (dcustomerId <= 0)
                        {
                            mergeCustomerUploadLog.StatusId = (long)MergeCustomerUploadStatus.ParseFailed;
                            var message = " Duplicate customer Id :" + duplicateCustomerId + " is not valid";
                            errorMessage = errorMessage + message + " | ";
                            _logger.Info(message);
                            continue;
                        }

                        if (customer.CustomerId == dcustomerId)
                        {
                            mergeCustomerUploadLog.StatusId = (long)MergeCustomerUploadStatus.ParseFailed;
                            var message = " Duplicate customer Id :" + duplicateCustomerId + " can not be same as customer id";
                            errorMessage = errorMessage + message + " | ";
                            _logger.Info(message);
                            continue;
                        }

                        Customer duplicateCustomer;
                        _logger.Info("fetching duplicate customer  for " + duplicateCustomerId);
                        try
                        {
                            duplicateCustomer = _customerRepository.GetCustomer(dcustomerId);
                        }
                        catch (Exception)
                        {
                            mergeCustomerUploadLog.StatusId = (long)MergeCustomerUploadStatus.ParseFailed;

                            var message = " Duplicate customer Id " + duplicateCustomerId + " does not exist in system";
                            errorMessage = errorMessage + message + " | ";
                            _logger.Info(message);
                            continue;
                        }

                        var matchCustomerErrorMessage = string.Empty;

                        if (!CheckIfCustomerIsMatching(customer, duplicateCustomer, out matchCustomerErrorMessage))
                        {
                            mergeCustomerUploadLog.StatusId = (long)MergeCustomerUploadStatus.ParseFailed;
                            errorMessage = errorMessage + " " + matchCustomerErrorMessage;
                            continue;
                        }
                        _logger.Info("fetching event customers");
                        var eventCustomers = _eventCustomerRepository.GetbyCustomerId(customer.CustomerId);
                        var duplicateEventCustomers = _eventCustomerRepository.GetbyCustomerId(dcustomerId);


                        List<EventCustomerResult> duplicateEventCustomeResults = null;

                        if (!eventCustomers.IsNullOrEmpty() && !duplicateEventCustomers.IsNullOrEmpty())
                        {
                            _logger.Info("customer and duplicate has been register for event customers. duplicate customer id: " + duplicateCustomer.CustomerId);
                            var eventids = duplicateEventCustomers.Where(x => x.AppointmentId.HasValue).Select(x => x.EventId);

                            if (eventCustomers.Any(x => x.AppointmentId.HasValue && eventids.Contains(x.EventId)))
                            {
                                mergeCustomerUploadLog.StatusId = (long)MergeCustomerUploadStatus.ParseFailed;
                                errorMessage = errorMessage + " Duplicate customer Id :" + duplicateCustomerId + " has appointment on same Event" + " | ";
                                continue;
                            }
                            _logger.Info("customer and duplicate does not have active appointment on same event. duplicate customer id: " + duplicateCustomer.CustomerId);

                        }

                        if (!duplicateEventCustomers.IsNullOrEmpty())
                        {
                            var eventCustomersByDuplicateIds = _eventCustomerResultRepository.GetByIds(duplicateEventCustomers.Select(x => x.Id));
                            duplicateEventCustomeResults = eventCustomersByDuplicateIds.IsNullOrEmpty() ? null : eventCustomersByDuplicateIds.ToList();

                            if (!duplicateEventCustomeResults.IsNullOrEmpty() && duplicateEventCustomeResults.Any(x => x.ResultState >= (int)TestResultStateNumber.ResultsUploaded && x.ResultState < (int)TestResultStateNumber.ResultDelivered))
                            {
                                mergeCustomerUploadLog.StatusId = (long)MergeCustomerUploadStatus.ParseFailed;
                                errorMessage = errorMessage + " Duplicate customer Id :" + duplicateCustomerId + " has result state in between " + (int)TestResultStateNumber.ResultsUploaded + " and " + (int)TestResultStateNumber.ResultDelivered + " | ";
                                continue;
                            }
                        }

                        _logger.Info("fetching records for Raps, Customer Billing Account, Customer Predicted Zip");

                        var customerRaps = _rapsRepository.GetByCustomerId(customer.CustomerId);
                        var customerBillingAccount = _customerBillingAccountRepository.GetCustomerBillingAccounts(customer.CustomerId);
                        var customerPredictedZip = _customerPredictedZipRespository.GetByCustomerId(customer.CustomerId);
                        var customerTag = _corporateCustomerCustomTagRepository.GetByCustomerId(customer.CustomerId);
                        var customerResultPosted = _customerResultPostedRepository.GetByCustomerId(customer.CustomerId);
                        var duplicateCustomerResultPosted = _customerResultPostedRepository.GetByCustomerId(duplicateCustomer.CustomerId);
                        var customerEligibility = _customerEligibilityRepository.GetByCustomerIdAndYear(duplicateCustomer.CustomerId, DateTime.Today.Year);
                        var newCustomerEligibilities = _customerEligibilityRepository.GetByCustomerId(customer.CustomerId);
                        var newCustomerTargets = _customerTargetedRepository.GetCustomerTargetedByCustomerId(customer.CustomerId);
                        var newCustomerTrale = _customerTraleRepository.GetByCustomerId(customer.CustomerId);
                        var careCodingOutbound = _careCodingOutboundRepository.GetByCustomerId(customer.CustomerId);

                        var medicationData = _medicationRepository.GetByCustomerId(customer.CustomerId);
                        var duplicateMedicationData = _medicationRepository.GetByCustomerId(duplicateCustomer.CustomerId);

                        var suspectCondition = _suspectConditionRepository.GetByCustomerId(customer.CustomerId);

                        var duplicatesuspectConditionData = _suspectConditionRepository.GetByCustomerId(duplicateCustomer.CustomerId);

                        var customerWarmTransfersData = _customerWarmTransferRepository.GetByCustomerId(customer.CustomerId);
                        var duplicateCustomerWarmTransfersData = _customerWarmTransferRepository.GetByCustomerId(duplicateCustomer.CustomerId);

                        var customerClinicalQuestionAnswerData = _customerClinicalQuestionAnswerRepository.GetByCustomerId(customer.CustomerId);
                        var duplicatecustomerClinicalQuestionAnswerData = _customerClinicalQuestionAnswerRepository.GetByCustomerId(duplicateCustomer.CustomerId);


                        try
                        {
                            using (var scope = new TransactionScope())
                            {
                                _logger.Info(" creating customer history for duplicate customer id : " + duplicateCustomer.CustomerId);

                                var customerProfileHistoryId = _customerProfileHistoryRepository.CreateCustomerHistory(duplicateCustomer.CustomerId, orgRoleId, customerEligibility);

                                _logger.Info(" Updating customer history id to all event customers. duplicate customer id : " + duplicateCustomer.CustomerId + " Customer history id :" + customerProfileHistoryId);
                                _eventCustomerRepository.UpdateCustomerProfileIdByCustomerId(duplicateCustomer.CustomerId, customerProfileHistoryId);

                                if (!eventCustomers.IsNullOrEmpty() && !duplicateEventCustomers.IsNullOrEmpty())
                                {
                                    var eventid = eventCustomers.Where(x => x.AppointmentId.HasValue).Select(x => x.EventId);
                                    var eventCustomerIds = duplicateEventCustomers.Where(x => !x.AppointmentId.HasValue && eventid.Contains(x.EventId)).Select(x => x.Id).ToArray();

                                    foreach (var eventCustomerId in eventCustomerIds)
                                    {
                                        _logger.Info("deleting event customer data for event customer id: " + eventCustomerId + " customer id: " + duplicateCustomer.CustomerId);
                                        _mergeCustomerUploadLogRepository.DeleteOrderDetails(eventCustomerId);
                                        _logger.Info("deleted event customer data for event customer id: " + eventCustomerId + " customer id: " + duplicateCustomer.CustomerId);
                                    }

                                    eventid = duplicateEventCustomers.Where(x => x.AppointmentId.HasValue).Select(x => x.EventId).ToList();
                                    eventCustomerIds = eventCustomers.Where(x => !x.AppointmentId.HasValue && eventid.Contains(x.EventId)).Select(x => x.Id).ToArray();

                                    foreach (var eventCustomerId in eventCustomerIds)
                                    {
                                        _logger.Info("deleting event customer data for event customer id: " + eventCustomerId + " customer id: " + customer.CustomerId);
                                        _mergeCustomerUploadLogRepository.DeleteOrderDetails(eventCustomerId);
                                        _logger.Info("deleted event customer data for event customer id: " + eventCustomerId + " customer id: " + customer.CustomerId);
                                    }

                                    eventid = eventCustomers.Where(x => !x.AppointmentId.HasValue).Select(x => x.EventId);
                                    eventCustomerIds = duplicateEventCustomers.Where(x => !x.AppointmentId.HasValue && eventid.Contains(x.EventId)).Select(x => x.Id).ToArray();

                                    foreach (var eventCustomerId in eventCustomerIds)
                                    {
                                        _logger.Info("deleting event customer data for event customer id: " + eventCustomerId + " customer id: " + duplicateCustomer.CustomerId);
                                        _mergeCustomerUploadLogRepository.DeleteOrderDetails(eventCustomerId);
                                        _logger.Info("deleted event customer data for event customer id: " + eventCustomerId + " customer id: " + duplicateCustomer.CustomerId);
                                    }

                                }

                                if (!customerTag.IsNullOrEmpty())
                                {
                                    _mergeCustomerUploadLogRepository.DeleteDuplicateCustomerTag(duplicateCustomer.CustomerId, customerTag.Select(x => x.Tag));
                                }

                                _mergeCustomerUploadLogRepository.MergeCustomer(duplicateCustomer.CustomerId, customer.CustomerId, orgRoleId);

                                if (!customerRaps.IsNullOrEmpty())
                                    _mergeCustomerUploadLogRepository.DeleteRaps(duplicateCustomer.CustomerId);

                                if (!customerBillingAccount.IsNullOrEmpty())
                                {
                                    foreach (var billingAccount in customerBillingAccount)
                                    {
                                        _mergeCustomerUploadLogRepository.DeleteCustomerBilllingAccount(duplicateCustomer.CustomerId, billingAccount.BillingAccountId);
                                    }
                                }

                                if (customerResultPosted != null && duplicateCustomerResultPosted != null)
                                {
                                    _mergeCustomerUploadLogRepository.DeleteCustomerResultPosted(duplicateCustomer.CustomerId);
                                }
                                else if (customerResultPosted == null && duplicateCustomerResultPosted != null)
                                {
                                    _mergeCustomerUploadLogRepository.UpdateCustomerResultPosted(duplicateCustomer.CustomerId, customer.CustomerId);
                                }

                                if (!customerPredictedZip.IsNullOrEmpty())
                                {
                                    foreach (var predictedZip in customerPredictedZip)
                                    {
                                        var startDate = new DateTime(predictedZip.DateCreated.Year, 1, 1);
                                        var endDate = new DateTime(predictedZip.DateCreated.Year, 12, 31);

                                        _mergeCustomerUploadLogRepository.DeleteCustomerPredictedZip(duplicateCustomer.CustomerId, startDate, endDate);
                                    }
                                }
                                _mergeCustomerUploadLogRepository.UpdatePredictedZip(duplicateCustomer.CustomerId, customer.CustomerId);
                                _mergeCustomerUploadLogRepository.UpdateCustomerBillingInfo(duplicateCustomer.CustomerId, customer.CustomerId);
                                _mergeCustomerUploadLogRepository.UpdateCustomerRaps(duplicateCustomer.CustomerId, customer.CustomerId);

                                _mergeCustomerUploadLogRepository.UpdateMemberUploadLog(duplicateCustomer.CustomerId, customer.CustomerId);
                                _mergeCustomerUploadLogRepository.UpdateEventCustomerQuestionAnswer(duplicateCustomer.CustomerId, customer.CustomerId);

                                if (!newCustomerEligibilities.IsNullOrEmpty())
                                {
                                    foreach (var newCustomerEligibility in newCustomerEligibilities)
                                    {
                                        _mergeCustomerUploadLogRepository.DeleteCustomerEligibility(duplicateCustomer.CustomerId, newCustomerEligibility.ForYear);
                                    }
                                }

                                _mergeCustomerUploadLogRepository.UpdateCustomerEligibility(duplicateCustomer.CustomerId, customer.CustomerId);

                                if (!newCustomerTargets.IsNullOrEmpty())
                                {
                                    foreach (var newCustomerTarget in newCustomerTargets)
                                    {
                                        _mergeCustomerUploadLogRepository.DeleteCustomerTargeted(duplicateCustomer.CustomerId, newCustomerTarget.ForYear);
                                    }
                                }

                                _mergeCustomerUploadLogRepository.UpdateCustomerTargeted(duplicateCustomer.CustomerId, customer.CustomerId);

                                if (newCustomerTrale != null)
                                {
                                    _mergeCustomerUploadLogRepository.DeleteCustomerTrale(duplicateCustomer.CustomerId);
                                }
                                else
                                {
                                    _mergeCustomerUploadLogRepository.UpdateCustomerTrale(duplicateCustomer.CustomerId, customer.CustomerId);
                                }

                                if (careCodingOutbound != null)
                                {
                                    _mergeCustomerUploadLogRepository.DeleteCareCodeingOutbound(duplicateCustomer.CustomerId);
                                }
                                else
                                {
                                    _mergeCustomerUploadLogRepository.UpdateCareCodingOutbound(duplicateCustomer.CustomerId, customer.CustomerId);
                                }

                                _mergeCustomerUploadLogRepository.UpdateCustomerUnsubscribed(duplicateCustomer.CustomerId, customer.CustomerId);

                                if (!duplicatesuspectConditionData.IsNullOrEmpty())
                                {
                                    if (suspectCondition.IsNullOrEmpty())
                                    {
                                        _mergeCustomerUploadLogRepository.UpdateSuspectCondition(duplicateCustomer.CustomerId, customer.CustomerId);
                                    }
                                    else
                                    {
                                        var conditionIdsToDelete = (from d in duplicatesuspectConditionData
                                                                    where suspectCondition.Any(x => x.ICDCode == d.ICDCode
                                                                             && x.CaptureReferenceDate.HasValue && d.CaptureReferenceDate.HasValue
                                                                             && x.CaptureReferenceDate.Value == d.CaptureReferenceDate.Value)
                                                                    select d.Id).ToArray();


                                        if (!conditionIdsToDelete.IsNullOrEmpty())
                                        {
                                            _mergeCustomerUploadLogRepository.DeleteSuspectCondition(duplicateCustomer.CustomerId, conditionIdsToDelete);
                                        }

                                        _mergeCustomerUploadLogRepository.UpdateSuspectCondition(duplicateCustomer.CustomerId, customer.CustomerId);
                                    }
                                }

                                if (!duplicateMedicationData.IsNullOrEmpty())
                                {
                                    if (medicationData.IsNullOrEmpty())
                                    {
                                        _mergeCustomerUploadLogRepository.UpdateMedication(duplicateCustomer.CustomerId, customer.CustomerId);
                                    }
                                    else
                                    {
                                        var medicationIdToDelete = (from d in duplicateMedicationData
                                                                    where
                                                                        medicationData.Any(m => m.ServiceDate == d.ServiceDate && m.ProprietaryName == d.ProprietaryName)
                                                                    select d.Id).ToArray();
                                        if (!medicationIdToDelete.IsNullOrEmpty())
                                        {
                                            _mergeCustomerUploadLogRepository.DeleteMedication(duplicateCustomer.CustomerId, medicationIdToDelete);
                                        }

                                        _mergeCustomerUploadLogRepository.UpdateMedication(duplicateCustomer.CustomerId, customer.CustomerId);
                                    }
                                }

                                if (!duplicateCustomerWarmTransfersData.IsNullOrEmpty())
                                {
                                    if (!customerWarmTransfersData.IsNullOrEmpty())
                                    {
                                        foreach (var customerWarmTransfer in customerWarmTransfersData)
                                        {
                                            _mergeCustomerUploadLogRepository.DeleteCustomerWarmTransfer(duplicateCustomer.CustomerId, customerWarmTransfer.WarmTransferYear);
                                        }
                                    }

                                    _mergeCustomerUploadLogRepository.UpdateCustomerWarmTransfer(duplicateCustomer.CustomerId, customer.CustomerId);
                                }

                                if (!duplicatecustomerClinicalQuestionAnswerData.IsNullOrEmpty())
                                {
                                    _mergeCustomerUploadLogRepository.UpdateCustomerClinicalQuestionAnswer(duplicateCustomer.CustomerId, customer.CustomerId);
                                }

                                _mergeCustomerUploadLogRepository.DeleteCustomer(duplicateCustomer.CustomerId);

                                _mergeCustomerUploadLogRepository.UpdateCustomerProfileHistory(duplicateCustomer.CustomerId, customerProfileHistoryId);

                                scope.Complete();
                            }
                            var hraMergeCustomerModel = new MergeCustomerHraModel
                            {
                                CustomerId = customer.CustomerId,
                                DuplicateCustomerId = duplicateCustomer.CustomerId
                            };

                            try
                            {
                                if (_settings.SyncWithHra)
                                {
                                    var result = _medicareApiService.PostAnonymous<bool>(_settings.MedicareApiUrl + MedicareApiUrl.MergeCustomer, hraMergeCustomerModel);
                                    if (result)
                                    {
                                        _logger.Info(string.Format("HRA Merge Customer CustomerId : {0} and DuplicateId : {1} completed.", hraMergeCustomerModel.CustomerId, hraMergeCustomerModel.DuplicateCustomerId));
                                    }
                                    else
                                    {
                                        mergeCustomerUploadLog.StatusId = (long)MergeCustomerUploadStatus.ParseFailed;
                                        var msg = string.Format("HRA Merge Customer CustomerId : {0} and DuplicateId : {1} failed.", hraMergeCustomerModel.CustomerId, hraMergeCustomerModel.DuplicateCustomerId);
                                        errorMessage = errorMessage + msg + " | ";
                                    }
                                }
                                else { _logger.Info("Syncing with HRA is off "); }
                                
                            }
                            catch (Exception exception)
                            {
                                _logger.Error(string.Format("Error while HRA Merge Customer CustomerId : {0} and DuplicateId : {1}. Message : {2}, \n Stack trace {3}", hraMergeCustomerModel.CustomerId, hraMergeCustomerModel.DuplicateCustomerId, exception.Message, exception.StackTrace));
                                mergeCustomerUploadLog.StatusId = (long)MergeCustomerUploadStatus.ParseFailed;
                                var msg = string.Format("Error while HRA Merge Customer CustomerId : {0} and DuplicateId : {1}. Message : {2}, \n Stack trace {3}", hraMergeCustomerModel.CustomerId, hraMergeCustomerModel.DuplicateCustomerId, exception.Message, exception.StackTrace);
                                errorMessage = errorMessage + msg + " | ";
                            }

                            if (!duplicateEventCustomeResults.IsNullOrEmpty())
                            {
                                foreach (var decr in duplicateEventCustomeResults)
                                {
                                    _logger.Info("moving media file duplicate  customer Id: " + decr.CustomerId + " event Id: " + decr.EventId);

                                    try
                                    {
                                        var mediaPath = _mediaRepository.GetResultMediaFileLocation(decr.EventId, false);
                                        var sourceMediaPath = Path.Combine(mediaPath.PhysicalPath, decr.CustomerId.ToString());
                                        var destinationMediaPath = Path.Combine(mediaPath.PhysicalPath, customer.CustomerId.ToString());

                                        DirectoryOperationsHelper.DirectoryMove(sourceMediaPath, destinationMediaPath);
                                    }
                                    catch (Exception exception)
                                    {
                                        _logger.Info("some error occurred while moving media file of duplicate customer: " + duplicateCustomer.CustomerId);
                                        _logger.Info("Event Id: " + decr.EventId);
                                        _logger.Info("Message: " + exception.Message);
                                        _logger.Info("stack trace: " + exception.Message);
                                        mergeCustomerUploadLog.StatusId = (long)MergeCustomerUploadStatus.ParseFailed;
                                        var msg = "some error occurred while moving media file of duplicate customer: " + duplicateCustomer.CustomerId;
                                        errorMessage = errorMessage + msg + " | ";
                                    }

                                    try
                                    {
                                        var sourceResultPath = _mediaRepository.GetPremiumVersionResultPdfLocation(decr.EventId, decr.CustomerId, false).PhysicalPath;
                                        var destinationResultPath = _mediaRepository.GetPremiumVersionResultPdfLocation(decr.EventId, customer.CustomerId, false).PhysicalPath;

                                        sourceResultPath = Directory.GetParent(sourceResultPath).FullName;
                                        destinationResultPath = Directory.GetParent(destinationResultPath).FullName;

                                        DirectoryOperationsHelper.DirectoryMove(sourceResultPath, destinationResultPath);
                                    }
                                    catch (Exception exception)
                                    {
                                        _logger.Info("some error occurred while moving result Packet file of duplicate customer: " + duplicateCustomer.CustomerId);
                                        _logger.Info("Event Id: " + decr.EventId);
                                        _logger.Info("Message: " + exception.Message);
                                        _logger.Info("stack trace: " + exception.Message);
                                        mergeCustomerUploadLog.StatusId = (long)MergeCustomerUploadStatus.ParseFailed;
                                        var msg = "some error occurred while moving result Packet file of duplicate customer: " + duplicateCustomer.CustomerId;
                                        errorMessage = errorMessage + msg + " | ";
                                    }

                                    try
                                    {
                                        var kynIntegrationOutput = _mediaRepository.GetKynIntegrationOutputDataLocation(decr.EventId, false);
                                        var sourceKynIntegratioPath = Path.Combine(kynIntegrationOutput.PhysicalPath, decr.CustomerId.ToString());
                                        var destinationKynIntegratioPath = Path.Combine(kynIntegrationOutput.PhysicalPath, customer.CustomerId.ToString());

                                        DirectoryOperationsHelper.DirectoryMove(sourceKynIntegratioPath, destinationKynIntegratioPath);
                                    }
                                    catch (Exception exception)
                                    {
                                        _logger.Info("some error occurred while moving Kyn data file of duplicate customer: " + duplicateCustomer.CustomerId);
                                        _logger.Info("Event Id: " + decr.EventId);
                                        _logger.Info("Message: " + exception.Message);
                                        _logger.Info("stack trace: " + exception.Message);
                                        mergeCustomerUploadLog.StatusId = (long)MergeCustomerUploadStatus.ParseFailed;
                                        var msg = "some error occurred while moving Kyn data file of duplicate customer: " + duplicateCustomer.CustomerId;
                                        errorMessage = errorMessage + msg + " | ";
                                    }

                                    try
                                    {
                                        _logger.Info("moving scanned document file duplicate  customer " + decr.CustomerId + " event Id:" + decr.EventId);

                                        var scannedDocumentmediaLocation = _mediaRepository.GetScannedDocumentStorageFileLocation(decr.EventId);
                                        if (DirectoryOperationsHelper.IsDirectoryExist(scannedDocumentmediaLocation.PhysicalPath))
                                        {
                                            var scannedDocumentPath = scannedDocumentmediaLocation.PhysicalPath;

                                            var customerScannedDocuments = DirectoryOperationsHelper.GetFiles(scannedDocumentPath, "*" + decr.CustomerId + "*");

                                            foreach (var scannedDocument in customerScannedDocuments)
                                            {
                                                var fileName = Path.GetFileName(scannedDocument);
                                                var newFile = fileName.Replace(decr.CustomerId.ToString(), customer.CustomerId.ToString());
                                                var newFilePath = Path.Combine(scannedDocumentPath, newFile);
                                                DirectoryOperationsHelper.MoveFileWithReplace(scannedDocument, newFilePath);
                                            }
                                        }
                                        else
                                        {
                                            _logger.Info("scanned document folder does not exists");
                                        }

                                        _logger.Info("moved scanned document  file duplicate  customer " + decr.CustomerId + " event Id:" + decr.EventId);
                                    }
                                    catch (Exception exception)
                                    {
                                        _logger.Info("some error occurred while moving  Attestation file of duplicate customer: " + duplicateCustomer.CustomerId);
                                        _logger.Info("Event Id: " + decr.EventId);
                                        _logger.Info("Message: " + exception.Message);
                                        _logger.Info("stack trace: " + exception.Message);

                                        var msg = "some error occurred while moving Attestation file of duplicate customer: " + duplicateCustomer.CustomerId;
                                        errorMessage = errorMessage + msg + " | ";
                                    }

                                }
                            }


                            if (mergeCustomerUploadLog.StatusId != (long)MergeCustomerUploadStatus.ParseFailed)
                            {
                                mergeCustomerUploadLog.StatusId = (long)MergeCustomerUploadStatus.Parsed;
                                mergeCustomerUploadLog.IsSuccessful = true;
                            }

                            errorMessage = errorMessage + " Customer Merged Successfully " + duplicateCustomerId + " | ";
                        }
                        catch (Exception ex)
                        {
                            mergeCustomerUploadLog.StatusId = (long)MergeCustomerUploadStatus.ParseFailed;
                            errorMessage = errorMessage + " Duplicate customer Id :" + duplicateCustomerId + ". Some Exception occurred Message: " + ex.Message + " | ";
                            _logger.Error("Duplicate customer Id :" + duplicateCustomerId + ". Some Exception occurred Message: " + ex.Message + " Stack Trace: " + ex.StackTrace);
                        }
                    }
                    catch (Exception exception)
                    {
                        _logger.Error(" some error has occurred while parsing recored: duplicate Customer id: " + duplicateCustomerId);
                        _logger.Error(" message: " + exception.Message);
                        _logger.Error(" stack trace: " + exception.StackTrace);
                        mergeCustomerUploadLog.StatusId = (long)MergeCustomerUploadStatus.ParseFailed;
                        errorMessage = errorMessage + " some error has occurred while parsing recored: duplicate Customer id: " + duplicateCustomerId;
                    }
                }

                mergeCustomerUploadLog.ErrorMessage = errorMessage;
            }
            catch (Exception exception)
            {
                _logger.Error(" some error has occurred while parsing recored: customer id: " + mergeCustomerUploadLog.CustomerId);
                _logger.Error(" message: " + exception.Message);
                _logger.Error(" stack trace: " + exception.StackTrace);
                mergeCustomerUploadLog.StatusId = (long)MergeCustomerUploadStatus.ParseFailed;
                mergeCustomerUploadLog.ErrorMessage = " some error has occurred while parsing recored: customer id: " + mergeCustomerUploadLog.CustomerId;
            }

            return mergeCustomerUploadLog;
        }

        private bool CheckIfCustomerIsMatching(Customer customer, Customer duplicateCustomer, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (!MatchString(customer.Tag, duplicateCustomer.Tag))
            {
                errorMessage = " Customers Tags does not match with duplicate records " + duplicateCustomer.CustomerId + " | ";
                _logger.Info(" tag does not match with duplicate record " + duplicateCustomer.CustomerId);
                return false;
            }
            _logger.Info(" Tag matched with duplicate Customer " + duplicateCustomer.CustomerId);

            if (!customer.DateOfBirth.HasValue || !duplicateCustomer.DateOfBirth.HasValue)
            {
                errorMessage = " Customer/duplicate customer does not have DOB to match. Duplicate customer Id: " + duplicateCustomer.CustomerId + " | ";
                _logger.Info(" Customer/duplicate customer does not have DOB to match. Duplicate customer Id: " + duplicateCustomer.CustomerId);
                return false;
            }

            if (customer.DateOfBirth != duplicateCustomer.DateOfBirth)
            {
                errorMessage = " Customer DoB does not match Records duplicate customer Id: " + duplicateCustomer.CustomerId + " | ";

                _logger.Info(" Customer DoB does not match Records duplicate customer Id: " + duplicateCustomer.CustomerId);
                return false;
            }

            _logger.Info(" DOB matched with duplicate Customer " + duplicateCustomer.CustomerId);

            if (MatchString(customer.Name.FirstName, duplicateCustomer.Name.FirstName) && MatchString(customer.Name.LastName, duplicateCustomer.Name.LastName) && MatchPhoneNumbers(customer, duplicateCustomer))
            {
                _logger.Info("Customer record match with duplicate record on first name, last name, dob, tag, home phone number. Duplicate Customer Id: " + duplicateCustomer.CustomerId);
                return true;
            }

            if (MatchString(customer.Name.FirstName, duplicateCustomer.Name.FirstName) && MatchPhoneNumbers(customer, duplicateCustomer))
            {
                _logger.Info("Customer record match with duplicate record on first name, dob, tag, home phone number. Duplicate Customer Id: " + duplicateCustomer.CustomerId);
                return true;
            }

            if (MatchString(customer.Name.LastName, duplicateCustomer.Name.LastName) && MatchPhoneNumbers(customer, duplicateCustomer))
            {
                _logger.Info("Customer record match with duplicate record on Last name, DOB, tag, home phone number. Duplicate Customer Id: " + duplicateCustomer.CustomerId);
                return true;
            }

            errorMessage = " Customer record does not match with duplicate record on first name, last name, home phone number. Duplicate Customer Id: " + duplicateCustomer.CustomerId + " | ";
            return false;
        }

        private bool MatchString(string value1, string value2)
        {
            if (string.IsNullOrWhiteSpace(value1) && !string.IsNullOrWhiteSpace(value2))
                return false;

            if (!string.IsNullOrWhiteSpace(value1) && string.IsNullOrWhiteSpace(value2))
                return false;

            if (!string.IsNullOrWhiteSpace(value1) && !string.IsNullOrWhiteSpace(value2))
            {
                return value1.ToLower() == value2.ToLower();
            }

            return true;
        }

        private bool MatchPhoneNumbers(Customer customer, Customer duplicateCustomer)
        {
            if (customer.HomePhoneNumber != null && !customer.HomePhoneNumber.IsEmpty() && duplicateCustomer.HomePhoneNumber != null && !duplicateCustomer.HomePhoneNumber.IsEmpty() && customer.HomePhoneNumber.DomesticPhoneNumber == duplicateCustomer.HomePhoneNumber.DomesticPhoneNumber)
                return true;

            if (customer.HomePhoneNumber != null && !customer.HomePhoneNumber.IsEmpty() && duplicateCustomer.OfficePhoneNumber != null && !duplicateCustomer.OfficePhoneNumber.IsEmpty() && customer.HomePhoneNumber.DomesticPhoneNumber == duplicateCustomer.OfficePhoneNumber.DomesticPhoneNumber)
                return true;

            if (customer.HomePhoneNumber != null && !customer.HomePhoneNumber.IsEmpty() && duplicateCustomer.MobilePhoneNumber != null && !duplicateCustomer.MobilePhoneNumber.IsEmpty() && customer.HomePhoneNumber.DomesticPhoneNumber == duplicateCustomer.MobilePhoneNumber.DomesticPhoneNumber)
                return true;


            if (customer.MobilePhoneNumber != null && !customer.MobilePhoneNumber.IsEmpty() && duplicateCustomer.HomePhoneNumber != null && !duplicateCustomer.HomePhoneNumber.IsEmpty() && customer.MobilePhoneNumber.DomesticPhoneNumber == duplicateCustomer.HomePhoneNumber.DomesticPhoneNumber)
                return true;

            if (customer.MobilePhoneNumber != null && !customer.MobilePhoneNumber.IsEmpty() && duplicateCustomer.OfficePhoneNumber != null && !duplicateCustomer.OfficePhoneNumber.IsEmpty() && customer.MobilePhoneNumber.DomesticPhoneNumber == duplicateCustomer.OfficePhoneNumber.DomesticPhoneNumber)
                return true;

            if (customer.MobilePhoneNumber != null && !customer.MobilePhoneNumber.IsEmpty() && duplicateCustomer.MobilePhoneNumber != null && !duplicateCustomer.MobilePhoneNumber.IsEmpty() && customer.MobilePhoneNumber.DomesticPhoneNumber == duplicateCustomer.MobilePhoneNumber.DomesticPhoneNumber)
                return true;


            if (customer.OfficePhoneNumber != null && !customer.OfficePhoneNumber.IsEmpty() && duplicateCustomer.HomePhoneNumber != null && !duplicateCustomer.HomePhoneNumber.IsEmpty()  && customer.OfficePhoneNumber.DomesticPhoneNumber == duplicateCustomer.HomePhoneNumber.DomesticPhoneNumber)
                return true;

            if (customer.OfficePhoneNumber != null && !customer.OfficePhoneNumber.IsEmpty() && duplicateCustomer.OfficePhoneNumber != null && !duplicateCustomer.OfficePhoneNumber.IsEmpty() && customer.OfficePhoneNumber.DomesticPhoneNumber == duplicateCustomer.OfficePhoneNumber.DomesticPhoneNumber)
                return true;

            if (customer.OfficePhoneNumber != null && !customer.OfficePhoneNumber.IsEmpty() && duplicateCustomer.MobilePhoneNumber != null && !duplicateCustomer.MobilePhoneNumber.IsEmpty() && customer.OfficePhoneNumber.DomesticPhoneNumber == duplicateCustomer.MobilePhoneNumber.DomesticPhoneNumber)
                return true;


            return false;
        }
    }
}
