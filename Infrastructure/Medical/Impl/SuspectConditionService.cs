using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class SuspectConditionService : ISuspectConditionService
    {
        private readonly ISuspectConditionUploadRepository _suspectConditionUploadRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly ISuspectConditionUploadLogRepository _suspectConditionUploadLogRepository;
        private readonly ISuspectConditionRepository _suspectConditionRepository;
        private readonly ICustomerRepository _customerRepository;

        public SuspectConditionService(ISuspectConditionUploadRepository suspectConditionUploadRepository, IOrganizationRoleUserRepository organizationRoleUserRepository,
            ISuspectConditionUploadLogRepository suspectConditionUploadLogRepository, ISuspectConditionRepository suspectConditionRepository, ICustomerRepository customerRepository)
        {
            _suspectConditionUploadRepository = suspectConditionUploadRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _suspectConditionUploadLogRepository = suspectConditionUploadLogRepository;
            _suspectConditionRepository = suspectConditionRepository;
            _customerRepository = customerRepository;
        }

        public IEnumerable<SuspectConditionUploadModel> GetUploadList(int pageNumber, int pageSize, SuspectConditionUploadListModelFilter filter, out int totalRecords)
        {
            var list = _suspectConditionUploadRepository.GetUploadList(pageNumber, pageSize, filter, out totalRecords).ToArray();
            var uploadByIds = list.Select(c => c.UploadedBy).Distinct().ToArray();

            IEnumerable<OrderedPair<long, string>> uploadedbyAgentNameIdPair = null;

            if (uploadByIds != null && uploadByIds.Any())
            {
                uploadedbyAgentNameIdPair = _organizationRoleUserRepository.GetNameIdPairofUsers(uploadByIds).ToArray();
            }
            foreach (var suspectConditionUploadModel in list)
            {
                if (uploadedbyAgentNameIdPair != null && uploadedbyAgentNameIdPair.Any())
                {
                    suspectConditionUploadModel.UploadedName = uploadedbyAgentNameIdPair.Single(ap => ap.FirstValue == suspectConditionUploadModel.UploadedBy).SecondValue;
                }
            }
            return list;
        }

        public void ParseSuspectCondition(List<SuspectConditionUploadLog> suspectConditionUploadLogs, List<SuspectConditionUploadLog> failedRecordsList)
        {
            foreach (var suspectConditionUploadLog in suspectConditionUploadLogs)
            {
                try
                {
                    if (!suspectConditionUploadLog.IsSuccessFull)
                    {
                        _suspectConditionUploadLogRepository.SaveSuspectConditionUploadLog(suspectConditionUploadLog);
                        failedRecordsList.Add(suspectConditionUploadLog);
                        continue;
                    }
                    var memberDob = Convert.ToDateTime(suspectConditionUploadLog.DOB);
                    var customers = _customerRepository.GetCustomerForSuspectConditionUpload(suspectConditionUploadLog.GMPI, suspectConditionUploadLog.MemberID, suspectConditionUploadLog.MemberName, memberDob);
                    if (customers != null)
                    {
                        var customerIds = customers.Select(x => x.CustomerId);
                        var captureReferenceDate = Convert.ToDateTime(suspectConditionUploadLog.CaptureReferenceDate);
                        var isExisting = _suspectConditionRepository.IsCustoemrExistForIcdCodeAndDate(customerIds, suspectConditionUploadLog.ICDCode, captureReferenceDate);

                        if (isExisting)
                        {
                            suspectConditionUploadLog.IsSuccessFull = false;
                            suspectConditionUploadLog.ErrorMessage = "Record already exist in the system for given ICDCode and CaptureReferenceDate.";
                            _suspectConditionUploadLogRepository.SaveSuspectConditionUploadLog(suspectConditionUploadLog);
                            failedRecordsList.Add(suspectConditionUploadLog);
                            continue;
                        }

                        foreach (var customer in customers)
                        {
                            //if ((customer.Name.LastName + "," + customer.Name.FirstName + "" + customer.Name.MiddleName).Trim().ToLower() != suspectConditionUploadLog.MemberName.Replace(" ", "").Trim().ToLower())
                            //{
                            //    suspectConditionUploadLog.IsSuccessFull = false;
                            //    suspectConditionUploadLog.ErrorMessage = "Member Name does not match with existing record for given GMPI.";
                            //    _suspectConditionUploadLogRepository.SaveSuspectConditionUploadLog(suspectConditionUploadLog);
                            //    failedRecordsList.Add(suspectConditionUploadLog);
                            //    continue;
                            //}

                            //if (customer.DateOfBirth.HasValue && customer.DateOfBirth.Value.ToString("MM/dd/yyyy") != suspectConditionUploadLog.DOB)
                            //{
                            //    suspectConditionUploadLog.IsSuccessFull = false;
                            //    suspectConditionUploadLog.ErrorMessage = "DOB does not match with existing record for given GMPI.";
                            //    _suspectConditionUploadLogRepository.SaveSuspectConditionUploadLog(suspectConditionUploadLog);
                            //    failedRecordsList.Add(suspectConditionUploadLog);
                            //    continue;
                            //}



                            var suspectCondition = new SuspectCondition
                            {
                                CaptureAction = suspectConditionUploadLog.CaptureAction,
                                CaptureLocation = suspectConditionUploadLog.CaptureLocation,
                                CaptureReasonDescription = suspectConditionUploadLog.CaptureReasonDescription,
                                CaptureReferenceDate = Convert.ToDateTime(suspectConditionUploadLog.CaptureReferenceDate),
                                CustomerId = customer.CustomerId,
                                DOB = Convert.ToDateTime(suspectConditionUploadLog.DOB),
                                GMPI = suspectConditionUploadLog.GMPI,
                                HCC = suspectConditionUploadLog.HCC,
                                HCCDesc = suspectConditionUploadLog.HCCDesc,
                                ICDCode = suspectConditionUploadLog.ICDCode,
                                ICDCodeVersion = suspectConditionUploadLog.ICDCodeVersion,
                                ICDDesc = suspectConditionUploadLog.ICDDesc,
                                FirstName = customer.Name.FirstName,
                                MiddleName = customer.Name.MiddleName,
                                LastName = customer.Name.LastName,
                                SectionName = suspectConditionUploadLog.SectionName,
                                SubscriberID = suspectConditionUploadLog.SubscriberID,
                                SuspectConditionUploadId = suspectConditionUploadLog.SuspectConditionUploadId,
                                MemberID = suspectConditionUploadLog.MemberID,
                            };

                            _suspectConditionUploadLogRepository.SaveSuspectConditionUploadLog(suspectConditionUploadLog);
                            _suspectConditionRepository.SaveSuspectCondition(suspectCondition);

                        }
                    }
                    else
                    {
                        suspectConditionUploadLog.IsSuccessFull = false;
                        if (!string.IsNullOrEmpty(suspectConditionUploadLog.GMPI) && !string.IsNullOrEmpty(suspectConditionUploadLog.MemberID))
                            suspectConditionUploadLog.ErrorMessage = "No customer found for given GMPI, Member ID, Member Name and DOB";
                        else if (!string.IsNullOrEmpty(suspectConditionUploadLog.GMPI) && string.IsNullOrEmpty(suspectConditionUploadLog.MemberID))
                            suspectConditionUploadLog.ErrorMessage = "No customer found for given GMPI, Member Name and DOB";
                        else
                            suspectConditionUploadLog.ErrorMessage = "No customer found for given Member ID, Member Name and DOB";

                        _suspectConditionUploadLogRepository.SaveSuspectConditionUploadLog(suspectConditionUploadLog);
                        failedRecordsList.Add(suspectConditionUploadLog);
                        continue;
                    }
                }
                catch (Exception ex)
                {
                    suspectConditionUploadLog.ErrorMessage = ex.Message;
                    suspectConditionUploadLog.IsSuccessFull = false;
                    _suspectConditionUploadLogRepository.SaveSuspectConditionUploadLog(suspectConditionUploadLog);
                    failedRecordsList.Add(suspectConditionUploadLog);
                }
            }
        }
    }
}
