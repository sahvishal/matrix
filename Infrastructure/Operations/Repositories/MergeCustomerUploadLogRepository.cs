using System;
using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System.Linq;

namespace Falcon.App.Infrastructure.Operations.Repositories
{
    [DefaultImplementation]
    public class MergeCustomerUploadLogRepository : PersistenceRepository, IMergeCustomerUploadLogRepository
    {
        public bool MergeCustomer(long oldCustomerId, long newCustomerId, long orgRoleId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var eventCustomer = new EventCustomersEntity { CustomerId = newCustomerId };
                var eventCustomerBucket = new RelationPredicateBucket(EventCustomersFields.CustomerId == oldCustomerId);
                adapter.UpdateEntitiesDirectly(eventCustomer, eventCustomerBucket);

                eventCustomer = new EventCustomersEntity { CreatedByOrgRoleUserId = newCustomerId };
                eventCustomerBucket = new RelationPredicateBucket(EventCustomersFields.CreatedByOrgRoleUserId == oldCustomerId);
                adapter.UpdateEntitiesDirectly(eventCustomer, eventCustomerBucket);

                var eventAppointment = new EventAppointmentEntity { ScheduledByOrgRoleUserId = newCustomerId };
                var eventAppointmentBucket = new RelationPredicateBucket(EventAppointmentFields.ScheduledByOrgRoleUserId == oldCustomerId);
                adapter.UpdateEntitiesDirectly(eventAppointment, eventAppointmentBucket);

                var customerEventTestFinding = new CustomerEventTestFindingEntity { CustomerId = newCustomerId };
                var customerEventTestBucket = new RelationPredicateBucket(CustomerEventTestFindingFields.CustomerId == oldCustomerId);
                adapter.UpdateEntitiesDirectly(customerEventTestFinding, customerEventTestBucket);

                var hospitalPartnerCustomer = new HospitalPartnerCustomerEntity { CustomerId = newCustomerId };
                var hospitalPartnerCustomerBucket = new RelationPredicateBucket(HospitalPartnerCustomerFields.CustomerId == oldCustomerId);
                adapter.UpdateEntitiesDirectly(hospitalPartnerCustomer, hospitalPartnerCustomerBucket);

                var customerPrimaryCarePhysician = new CustomerPrimaryCarePhysicianEntity
                {
                    CustomerId = newCustomerId,
                    IsActive = false,
                    DateModified = DateTime.Now,
                    UpdatedByOrganizationRoleUserId = orgRoleId
                };

                var customerPrimaryCarePhysicianBucket = new RelationPredicateBucket(CustomerPrimaryCarePhysicianFields.CustomerId == oldCustomerId);
                adapter.UpdateEntitiesDirectly(customerPrimaryCarePhysician, customerPrimaryCarePhysicianBucket);

                var preApprovedTest = new PreApprovedTestEntity
                {
                    CustomerId = newCustomerId,
                    IsActive = false,
                    DateEnd = DateTime.Now
                };

                var preApprovedTestBucket = new RelationPredicateBucket(PreApprovedTestFields.CustomerId == oldCustomerId);
                adapter.UpdateEntitiesDirectly(preApprovedTest, preApprovedTestBucket);

                var preApprovedPackage = new PreApprovedPackageEntity
                {
                    CustomerId = newCustomerId,
                    IsActive = false,
                    DateEnd = DateTime.Now
                };

                var preApprovedPackageBucket = new RelationPredicateBucket(PreApprovedPackageFields.CustomerId == oldCustomerId);
                adapter.UpdateEntitiesDirectly(preApprovedPackage, preApprovedPackageBucket);

                var customerIcdCode = new CustomerIcdCodeEntity
                {
                    CustomerId = newCustomerId,
                    IsActive = false,
                    DateEnd = DateTime.Now
                };

                var customerIcdCodeBucket = new RelationPredicateBucket(CustomerIcdCodeFields.CustomerId == oldCustomerId);
                adapter.UpdateEntitiesDirectly(customerIcdCode, customerIcdCodeBucket);

                var currentMedication = new CurrentMedicationEntity
                {
                    CustomerId = newCustomerId,
                    IsActive = false,
                    DateEnd = DateTime.Now
                };

                var currentMedicationBucket = new RelationPredicateBucket(CurrentMedicationFields.CustomerId == oldCustomerId);
                adapter.UpdateEntitiesDirectly(currentMedication, currentMedicationBucket);

                var chaseOutbound = new ChaseOutboundEntity
                {
                    CustomerId = newCustomerId,
                    IsActive = false,
                    EndDate = DateTime.Now
                };

                var chaseOutboundBucket = new RelationPredicateBucket(ChaseOutboundFields.CustomerId == oldCustomerId);
                adapter.UpdateEntitiesDirectly(chaseOutbound, chaseOutboundBucket);


                var customerChaseCampaign = new CustomerChaseCampaignEntity
               {
                   CustomerId = newCustomerId,
                   IsActive = false
               };

                var customerChaseCampaignBucket = new RelationPredicateBucket(CustomerChaseCampaignFields.CustomerId == oldCustomerId);
                adapter.UpdateEntitiesDirectly(customerChaseCampaign, customerChaseCampaignBucket);

                var customerChaseChannel = new CustomerChaseChannelEntity
               {
                   CustomerId = newCustomerId
               };

                var customerChaseChannelBucket = new RelationPredicateBucket(CustomerChaseChannelFields.CustomerId == oldCustomerId);
                adapter.UpdateEntitiesDirectly(customerChaseChannel, customerChaseChannelBucket);


                var customerChaseProduct = new CustomerChaseProductEntity
                {
                    CustomerId = newCustomerId
                };

                var customerChaseProductBucket = new RelationPredicateBucket(CustomerChaseProductFields.CustomerId == oldCustomerId);
                adapter.UpdateEntitiesDirectly(customerChaseProduct, customerChaseProductBucket);


                var orderDetail = new OrderDetailEntity
                {
                    ForOrganizationRoleUserId = newCustomerId
                };

                var orderDetailBucket = new RelationPredicateBucket(OrderDetailFields.ForOrganizationRoleUserId == oldCustomerId);
                adapter.UpdateEntitiesDirectly(orderDetail, orderDetailBucket);

                var order = new OrderEntity
                {
                    OrganizationRoleUserCreatorId = newCustomerId
                };

                var orderBucket = new RelationPredicateBucket(OrderFields.OrganizationRoleUserCreatorId == oldCustomerId);
                adapter.UpdateEntitiesDirectly(order, orderBucket);

                var eventCustomerResult = new EventCustomerResultEntity
                {
                    CustomerId = newCustomerId
                };

                var eventCustomerResultBucket = new RelationPredicateBucket(EventCustomerResultFields.CustomerId == oldCustomerId);
                adapter.UpdateEntitiesDirectly(eventCustomerResult, eventCustomerResultBucket);

                var eventCustomerResultHistory = new EventCustomerResultHistoryEntity
                {
                    CustomerId = newCustomerId
                };

                var eventCustomerResultHistoryBucket = new RelationPredicateBucket(EventCustomerResultHistoryFields.CustomerId == oldCustomerId);
                adapter.UpdateEntitiesDirectly(eventCustomerResultHistory, eventCustomerResultHistoryBucket);

                var resultArchiveUploadLog = new ResultArchiveUploadLogEntity
                {
                    CustomerId = newCustomerId
                };

                var resultArchiveUploadLogBucket = new RelationPredicateBucket(ResultArchiveUploadLogFields.CustomerId == oldCustomerId);
                adapter.UpdateEntitiesDirectly(resultArchiveUploadLog, resultArchiveUploadLogBucket);

                var customerHealthInfo = new CustomerHealthInfoEntity
                {
                    CustomerId = newCustomerId
                };

                var customerHealthInfoBucket = new RelationPredicateBucket(CustomerHealthInfoFields.CustomerId == oldCustomerId);
                adapter.UpdateEntitiesDirectly(customerHealthInfo, customerHealthInfoBucket);

                var customerHealthInfoArchive = new CustomerHealthInfoArchiveEntity
                {
                    CustomerId = newCustomerId
                };

                var customerHealthInfoArchiveBucket = new RelationPredicateBucket(CustomerHealthInfoArchiveFields.CustomerId == oldCustomerId);
                adapter.UpdateEntitiesDirectly(customerHealthInfoArchive, customerHealthInfoArchiveBucket);

                var customerTag = new CustomerTagEntity
                {
                    CustomerId = newCustomerId
                };

                var customerTagBucket = new RelationPredicateBucket(CustomerTagFields.CustomerId == oldCustomerId);
                adapter.UpdateEntitiesDirectly(customerTag, customerTagBucket);

                var customerRegistrationNotes = new CustomerRegistrationNotesEntity
                {
                    CustomerId = newCustomerId
                };

                var customerRegistrationNotesBucket = new RelationPredicateBucket(CustomerRegistrationNotesFields.CustomerId == oldCustomerId);
                adapter.UpdateEntitiesDirectly(customerRegistrationNotes, customerRegistrationNotesBucket);

                var directMail = new DirectMailEntity
                {
                    CustomerId = newCustomerId
                };

                var directMailBucket = new RelationPredicateBucket(DirectMailFields.CustomerId == oldCustomerId);
                adapter.UpdateEntitiesDirectly(directMail, directMailBucket);

                var calls = new CallsEntity
               {
                   CalledCustomerId = newCustomerId
               };

                var callsBucket = new RelationPredicateBucket(CallsFields.CalledCustomerId == oldCustomerId);
                adapter.UpdateEntitiesDirectly(calls, callsBucket);

                var callQueueCustomer = new CallQueueCustomerEntity
               {
                   CustomerId = newCustomerId,
                   Status = (int)CallQueueStatus.Removed
               };

                var callQueueCustomerBucket = new RelationPredicateBucket(CallQueueCustomerFields.CustomerId == oldCustomerId);
                adapter.UpdateEntitiesDirectly(callQueueCustomer, callQueueCustomerBucket);

                var customerHistory = new CustomerProfileHistoryEntity() { CustomerId = newCustomerId };
                var customerHistoryBucket = new RelationPredicateBucket(CustomerProfileHistoryFields.CustomerId == oldCustomerId);

                adapter.UpdateEntitiesDirectly(customerHistory, customerHistoryBucket);

                var preQualificationResult = new PreQualificationResultEntity { CustomerId = newCustomerId };
                var preQualificationResultBucket = new RelationPredicateBucket(PreQualificationResultFields.CustomerId == oldCustomerId);

                adapter.UpdateEntitiesDirectly(preQualificationResult, preQualificationResultBucket);

                var customerCallQueueCallAttempt = new CustomerCallQueueCallAttemptEntity { CustomerId = newCustomerId };
                var customerCallQueueCallAttemptBucket = new RelationPredicateBucket(CustomerCallQueueCallAttemptFields.CustomerId == oldCustomerId);

                adapter.UpdateEntitiesDirectly(customerCallQueueCallAttempt, customerCallQueueCallAttemptBucket);

            }

            return true;
        }

        public bool DeleteRaps(long oldCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var bucket = new RelationPredicateBucket(RapsFields.CustomerId == oldCustomerId);
                adapter.DeleteEntitiesDirectly(typeof(RapsEntity), bucket);
            }
            return true;
        }

        public bool UpdateCustomerBillingInfo(long oldCustomerId, long newCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var customerBillingAccountBucket = new RelationPredicateBucket(CustomerBillingAccountFields.CustomerId == oldCustomerId);
                var entities = new EntityCollection<CustomerBillingAccountEntity>();

                adapter.FetchEntityCollection(entities, customerBillingAccountBucket);

                foreach (var cba in entities)
                {
                    cba.CustomerId = newCustomerId;
                    adapter.SaveEntity(cba);
                }
            }
            return true;
        }

        public bool UpdateMemberUploadLog(long oldCustomerId, long newCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var memberUploadLogBucket = new RelationPredicateBucket(MemberUploadLogFields.CustomerId == oldCustomerId);
                var entities = new EntityCollection<MemberUploadLogEntity>();

                adapter.FetchEntityCollection(entities, memberUploadLogBucket);

                foreach (var cba in entities)
                {
                    cba.CustomerId = newCustomerId;
                    adapter.SaveEntity(cba);
                }
            }
            return true;
        }

        public bool UpdateEventCustomerQuestionAnswer(long oldCustomerId, long newCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var eventCustomerQuestionAnswerBucket = new RelationPredicateBucket(EventCustomerQuestionAnswerFields.CustomerId == oldCustomerId);
                var entities = new EntityCollection<EventCustomerQuestionAnswerEntity>();

                adapter.FetchEntityCollection(entities, eventCustomerQuestionAnswerBucket);

                foreach (var cba in entities)
                {
                    cba.CustomerId = newCustomerId;
                    adapter.SaveEntity(cba);
                }
            }
            return true;
        }

        public bool UpdateCustomerRaps(long oldCustomerId, long newCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var customerBillingAccountBucket = new RelationPredicateBucket(RapsFields.CustomerId == oldCustomerId);
                var entities = new EntityCollection<RapsEntity>();

                adapter.FetchEntityCollection(entities, customerBillingAccountBucket);

                foreach (var cba in entities)
                {
                    cba.CustomerId = newCustomerId;
                    adapter.SaveEntity(cba);
                }
            }

            return true;
        }

        public bool DeleteCustomerBilllingAccount(long oldCustomerId, long oldBillingAccountId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var bucket = new RelationPredicateBucket(CustomerBillingAccountFields.CustomerId == oldCustomerId);
                bucket.PredicateExpression.AddWithAnd(CustomerBillingAccountFields.BillingAccountId == oldBillingAccountId);
                adapter.DeleteEntitiesDirectly(typeof(CustomerBillingAccountEntity), bucket);
            }
            return true;
        }

        public bool DeleteCustomerPredictedZip(long customerId, DateTime startDate, DateTime endDate)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var bucket = new RelationPredicateBucket(CustomerPredictedZipFields.CustomerId == customerId);
                bucket.PredicateExpression.AddWithAnd(CustomerPredictedZipFields.DateCreated >= startDate);
                bucket.PredicateExpression.AddWithAnd(CustomerPredictedZipFields.DateCreated <= endDate);
                adapter.DeleteEntitiesDirectly(typeof(CustomerPredictedZipEntity), bucket);
            }
            return true;

        }

        public bool UpdatePredictedZip(long oldCustomerId, long newCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var customerPredictedZip = new CustomerPredictedZipEntity { CustomerId = newCustomerId };
                var customerPredictedZipBucket = new RelationPredicateBucket(CustomerPredictedZipFields.CustomerId == oldCustomerId);
                adapter.UpdateEntitiesDirectly(customerPredictedZip, customerPredictedZipBucket);
            }
            return true;
        }

        public bool DeleteDuplicateCustomerTag(long oldCustomerId, IEnumerable<string> tag)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var bucket = new RelationPredicateBucket(CustomerTagFields.CustomerId == oldCustomerId);
                bucket.PredicateExpression.AddWithAnd(CustomerTagFields.Tag == tag.ToArray());
                adapter.DeleteEntitiesDirectly(typeof(CustomerTagEntity), bucket);
            }
            return true;
        }

        public bool DeleteOrderDetails(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var orderDetailIds = (from ecod in linqMetaData.EventCustomerOrderDetail
                                      where ecod.EventCustomerId == eventCustomerId
                                      select ecod.OrderDetailId).ToArray();

                var shippingDetailIds = (from sdod in linqMetaData.ShippingDetailOrderDetail
                                         where orderDetailIds.Contains(sdod.OrderDetailId)
                                         select sdod.ShippingDetailId).ToArray();

                var orderIds = (from od in linqMetaData.OrderDetail where orderDetailIds.Contains(od.OrderDetailId) select od.OrderId).ToArray();

                var shippindDetailOrderDetail = new RelationPredicateBucket(ShippingDetailOrderDetailFields.OrderDetailId == orderDetailIds);
                adapter.DeleteEntitiesDirectly(typeof(ShippingDetailOrderDetailEntity), shippindDetailOrderDetail);

                var shippingDetail = new RelationPredicateBucket(ShippingDetailFields.ShippingDetailId == shippingDetailIds);
                adapter.DeleteEntitiesDirectly(typeof(ShippingDetailEntity), shippingDetail);

                var bucket = new RelationPredicateBucket(EventCustomerOrderDetailFields.EventCustomerId == eventCustomerId);
                adapter.DeleteEntitiesDirectly(typeof(EventCustomerOrderDetailEntity), bucket);

                var orderDetail = new RelationPredicateBucket(OrderDetailFields.OrderId == orderIds);
                adapter.DeleteEntitiesDirectly(typeof(OrderDetailEntity), orderDetail);

                var order = new RelationPredicateBucket(OrderFields.OrderId == orderIds);
                adapter.DeleteEntitiesDirectly(typeof(OrderEntity), order);

                adapter.DeleteEntitiesDirectly(typeof(EventAppointmentChangeLogEntity), new RelationPredicateBucket(EventAppointmentChangeLogFields.EventCustomerId == eventCustomerId));
                adapter.DeleteEntitiesDirectly(typeof(EventCustomerBasicBioMetricEntity), new RelationPredicateBucket(EventCustomerBasicBioMetricFields.EventCustomerId == eventCustomerId));
                adapter.DeleteEntitiesDirectly(typeof(EventCustomerBarrierEntity), new RelationPredicateBucket(EventCustomerBarrierFields.EventCustomerId == eventCustomerId));
                adapter.DeleteEntitiesDirectly(typeof(CustomerHealthInfoEntity), new RelationPredicateBucket(CustomerHealthInfoFields.EventCustomerId == eventCustomerId));
                adapter.DeleteEntitiesDirectly(typeof(CustomerHealthInfoArchiveEntity), new RelationPredicateBucket(CustomerHealthInfoArchiveFields.EventCustomerId == eventCustomerId));
                adapter.DeleteEntitiesDirectly(typeof(EventCustomerNotificationEntity), new RelationPredicateBucket(EventCustomerNotificationFields.EventCustomerId == eventCustomerId));
                adapter.DeleteEntitiesDirectly(typeof(PcpAppointmentEntity), new RelationPredicateBucket(PcpAppointmentFields.EventCustomerId == eventCustomerId));
                adapter.DeleteEntitiesDirectly(typeof(PcpDispositionEntity), new RelationPredicateBucket(PcpDispositionFields.EventCustomerId == eventCustomerId));
                adapter.DeleteEntitiesDirectly(typeof(EventCustomerPreApprovedTestEntity), new RelationPredicateBucket(EventCustomerPreApprovedTestFields.EventCustomerId == eventCustomerId));
                adapter.DeleteEntitiesDirectly(typeof(EventAppointmentCancellationLogEntity), new RelationPredicateBucket(EventAppointmentCancellationLogFields.EventCustomerId == eventCustomerId));
                adapter.DeleteEntitiesDirectly(typeof(EventCustomerPreApprovedPackageTestEntity), new RelationPredicateBucket(EventCustomerPreApprovedPackageTestFields.EventCustomerId == eventCustomerId));
                adapter.DeleteEntitiesDirectly(typeof(EventCustomerPrimaryCarePhysicianEntity), new RelationPredicateBucket(EventCustomerPrimaryCarePhysicianFields.EventCustomerId == eventCustomerId));
                adapter.DeleteEntitiesDirectly(typeof(CheckListAnswerEntity), new RelationPredicateBucket(CheckListAnswerFields.EventCustomerId == eventCustomerId));
                adapter.DeleteEntitiesDirectly(typeof(EventCustomerIcdCodesEntity), new RelationPredicateBucket(EventCustomerIcdCodesFields.EventCustomerId == eventCustomerId));
                adapter.DeleteEntitiesDirectly(typeof(EventCustomerCurrentMedicationEntity), new RelationPredicateBucket(EventCustomerCurrentMedicationFields.EventCustomerId == eventCustomerId));
                adapter.DeleteEntitiesDirectly(typeof(EventCustomerDiagnosisEntity), new RelationPredicateBucket(EventCustomerDiagnosisFields.EventCustomerId == eventCustomerId));

                adapter.UpdateEntitiesDirectly(new CallQueueCustomerEntity { EventCustomerId = null }, new RelationPredicateBucket(CallQueueCustomerFields.EventCustomerId == eventCustomerId));
                adapter.DeleteEntitiesDirectly(typeof(EventCustomerRetestEntity), new RelationPredicateBucket(EventCustomerRetestFields.EventCustomerId == eventCustomerId));

                adapter.DeleteEntitiesDirectly(typeof(EventCustomerQuestionAnswerEntity), new RelationPredicateBucket(EventCustomerQuestionAnswerFields.EventCustomerId == eventCustomerId));
                adapter.DeleteEntitiesDirectly(typeof(DisqualifiedTestEntity), new RelationPredicateBucket(DisqualifiedTestFields.EventCustomerId == eventCustomerId));

                adapter.DeleteEntitiesDirectly(typeof(FluConsentAnswerEntity), new RelationPredicateBucket(FluConsentAnswerFields.EventCustomerId == eventCustomerId));
                adapter.DeleteEntitiesDirectly(typeof(FluConsentSignatureEntity), new RelationPredicateBucket(FluConsentSignatureFields.EventCustomerId == eventCustomerId));
                adapter.DeleteEntitiesDirectly(typeof(ParticipationConsentSignatureEntity), new RelationPredicateBucket(ParticipationConsentSignatureFields.EventCustomerId == eventCustomerId));
                adapter.DeleteEntitiesDirectly(typeof(PhysicianRecordRequestSignatureEntity), new RelationPredicateBucket(PhysicianRecordRequestSignatureFields.EventCustomerId == eventCustomerId));
                adapter.DeleteEntitiesDirectly(typeof(ChaperoneAnswerEntity), new RelationPredicateBucket(ChaperoneAnswerFields.EventCustomerId == eventCustomerId));
                adapter.DeleteEntitiesDirectly(typeof(ChaperoneSignatureEntity), new RelationPredicateBucket(ChaperoneSignatureFields.EventCustomerId == eventCustomerId));
                adapter.DeleteEntitiesDirectly(typeof(ExitInterviewAnswerEntity), new RelationPredicateBucket(ExitInterviewAnswerFields.EventCustomerId == eventCustomerId));
                adapter.DeleteEntitiesDirectly(typeof(SurveyAnswerEntity), new RelationPredicateBucket(SurveyAnswerFields.EventCustomerId == eventCustomerId));
                adapter.DeleteEntitiesDirectly(typeof(EventCustomerGiftCardEntity), new RelationPredicateBucket(EventCustomerGiftCardFields.EventCustomerId == eventCustomerId));
                adapter.DeleteEntitiesDirectly(typeof(CustomerOrderHistoryEntity), new RelationPredicateBucket(CustomerOrderHistoryFields.EventCustomerId == eventCustomerId));

                bucket = new RelationPredicateBucket(EventCustomersFields.EventCustomerId == eventCustomerId);

                adapter.DeleteEntitiesDirectly(typeof(EventCustomersEntity), bucket);

            }

            return true;
        }

        public MergeCustomerUploadLog Save(MergeCustomerUploadLog domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = AutoMapper.Mapper.Map<MergeCustomerUploadLog, MergeCustomerUploadLogEntity>(domain);
                if (!adapter.SaveEntity(entity, true))
                    throw new PersistenceFailureException("Could not save Call Upload Log");

                return AutoMapper.Mapper.Map<MergeCustomerUploadLogEntity, MergeCustomerUploadLog>(entity);
            }
        }

        public IEnumerable<MergeCustomerUploadLog> GetUploadLogsForMerge(long uploadId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from mcul in linqMetaData.MergeCustomerUploadLog
                                where mcul.StatusId == (long)MergeCustomerUploadStatus.Uploaded && mcul.UploadId == uploadId
                                select mcul).ToArray();
                return AutoMapper.Mapper.Map<IEnumerable<MergeCustomerUploadLogEntity>, IEnumerable<MergeCustomerUploadLog>>(entities);
            }
        }

        public IEnumerable<MergeCustomerUploadLog> GetFailedCustomers(long uploadId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from mcul in linqMetaData.MergeCustomerUploadLog
                                where mcul.StatusId == (long)MergeCustomerUploadStatus.ParseFailed && mcul.UploadId == uploadId
                                select mcul).ToArray();
                return AutoMapper.Mapper.Map<IEnumerable<MergeCustomerUploadLogEntity>, IEnumerable<MergeCustomerUploadLog>>(entities);
            }
        }

        public long GetSuccessfulCustomersCount(long uploadId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var count = (from mcul in linqMetaData.MergeCustomerUploadLog
                             where mcul.StatusId == (long)MergeCustomerUploadStatus.Parsed && mcul.UploadId == uploadId
                             select mcul).Count();
                return count;

            }
        }

        public bool DeleteCustomer(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var userId = (from oru in linqMetaData.OrganizationRoleUser where oru.OrganizationRoleUserId == customerId select oru.UserId).FirstOrDefault();

                var prospectCustomerId = (from pc in linqMetaData.ProspectCustomer where pc.CustomerId == customerId select pc.ProspectCustomerId).ToArray();

                {
                    var prospectCustomerCall = new RelationPredicateBucket(ProspectCustomerCallFields.ProspectCustomerId == prospectCustomerId);
                    adapter.DeleteEntitiesDirectly(typeof(ProspectCustomerCallEntity), prospectCustomerCall);


                    var tempCartIds = (from tc in linqMetaData.TempCart
                                       where tc.ProspectCustomerId.HasValue && prospectCustomerId.Contains(tc.ProspectCustomerId.Value)
                                       select tc.Id).ToArray();

                    var preQualificationResult = new RelationPredicateBucket(PreQualificationResultFields.TempCartId == tempCartIds);
                    adapter.DeleteEntitiesDirectly(typeof(PreQualificationResultEntity), preQualificationResult);

                    var tempCart = new RelationPredicateBucket(TempCartFields.ProspectCustomerId == prospectCustomerId);
                    adapter.DeleteEntitiesDirectly(typeof(TempCartEntity), tempCart);

                    tempCart = new RelationPredicateBucket(TempCartFields.CustomerId == customerId);
                    adapter.DeleteEntitiesDirectly(typeof(TempCartEntity), tempCart);

                    var prospectCustomer = new RelationPredicateBucket(ProspectCustomerFields.ProspectCustomerId == prospectCustomerId);
                    adapter.DeleteEntitiesDirectly(typeof(ProspectCustomerEntity), prospectCustomer);

                    var customerAccountGlocomNumber = new RelationPredicateBucket(CustomerAccountGlocomNumberFields.CustomerId == customerId);
                    adapter.DeleteEntitiesDirectly(typeof(CustomerAccountGlocomNumberEntity), customerAccountGlocomNumber);

                    var customerProfile = new RelationPredicateBucket(CustomerProfileFields.CustomerId == customerId);
                    adapter.DeleteEntitiesDirectly(typeof(CustomerProfileEntity), customerProfile);

                }

                {
                    var notificationId = (from n in linqMetaData.Notification where n.UserId == userId select n.NotificationId).ToArray();


                    var eventCustomerNotification = new RelationPredicateBucket(EventCustomerNotificationFields.NotificationId == notificationId);
                    adapter.DeleteEntitiesDirectly(typeof(EventCustomerNotificationEntity), eventCustomerNotification);


                    var notificationEmail = new RelationPredicateBucket(NotificationEmailFields.NotificationEmailId == notificationId);
                    adapter.DeleteEntitiesDirectly(typeof(NotificationEmailEntity), notificationEmail);

                    var notificationPhone = new RelationPredicateBucket(NotificationPhoneFields.NotificationPhoneId == notificationId);
                    adapter.DeleteEntitiesDirectly(typeof(NotificationPhoneEntity), notificationPhone);

                    var notification = new RelationPredicateBucket(NotificationFields.UserId == userId);
                    adapter.DeleteEntitiesDirectly(typeof(NotificationEntity), notification);

                }

                {
                    var organizationUser = new OrganizationRoleUserEntity { IsActive = false };
                    var organizationUserBucket = new RelationPredicateBucket(OrganizationRoleUserFields.OrganizationRoleUserId == customerId);

                    adapter.UpdateEntitiesDirectly(organizationUser, organizationUserBucket);


                    var userLogin = new UserLoginEntity { IsActive = false };
                    var userLoginBucket = new RelationPredicateBucket(UserLoginFields.UserLoginId == userId);

                    adapter.UpdateEntitiesDirectly(userLogin, userLoginBucket);

                    var user = new UserEntity { IsActive = false, Email1 = string.Empty };

                    var userBucket = new RelationPredicateBucket(UserFields.UserId == userId);

                    adapter.UpdateEntitiesDirectly(user, userBucket);

                }
            }

            return true;
        }

        public bool DeleteCustomerResultPosted(long oldCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var bucket = new RelationPredicateBucket(CustomerResultPostedFields.CustomerId == oldCustomerId);
                adapter.DeleteEntitiesDirectly(typeof(CustomerResultPostedEntity), bucket);
            }
            return true;
        }

        public bool UpdateCustomerResultPosted(long oldCustomerId, long newCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var customerBillingAccountBucket = new RelationPredicateBucket(CustomerResultPostedFields.CustomerId == oldCustomerId);
                var entities = new EntityCollection<CustomerResultPostedEntity>();

                adapter.FetchEntityCollection(entities, customerBillingAccountBucket);

                foreach (var cba in entities)
                {
                    cba.CustomerId = newCustomerId;
                    adapter.SaveEntity(cba);
                }
            }
            return true;
        }

        public bool DeleteCustomerEligibility(long oldCustomerId, int forYear)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var bucket = new RelationPredicateBucket(CustomerEligibilityFields.CustomerId == oldCustomerId);
                bucket.PredicateExpression.AddWithAnd(CustomerEligibilityFields.ForYear == forYear);
                adapter.DeleteEntitiesDirectly(typeof(CustomerEligibilityEntity), bucket);
            }
            return true;
        }

        public bool UpdateCustomerEligibility(long oldCustomerId, long newCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var customerPredictedZip = new CustomerEligibilityEntity { CustomerId = newCustomerId };
                var customerPredictedZipBucket = new RelationPredicateBucket(CustomerEligibilityFields.CustomerId == oldCustomerId);
                adapter.UpdateEntitiesDirectly(customerPredictedZip, customerPredictedZipBucket);
            }
            return true;
        }

        public bool DeleteCustomerTargeted(long oldCustomerId, int forYear)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var bucket = new RelationPredicateBucket(CustomerTargetedFields.CustomerId == oldCustomerId);
                bucket.PredicateExpression.AddWithAnd(CustomerTargetedFields.ForYear == forYear);
                adapter.DeleteEntitiesDirectly(typeof(CustomerTargetedEntity), bucket);
            }
            return true;
        }

        public bool UpdateCustomerTargeted(long oldCustomerId, long newCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var customerPredictedZip = new CustomerTargetedEntity { CustomerId = newCustomerId };
                var customerPredictedZipBucket = new RelationPredicateBucket(CustomerTargetedFields.CustomerId == oldCustomerId);
                adapter.UpdateEntitiesDirectly(customerPredictedZip, customerPredictedZipBucket);
            }
            return true;
        }

        public bool DeleteCustomerTrale(long oldCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var bucket = new RelationPredicateBucket(CustomerTraleFields.CustomerId == oldCustomerId);
                adapter.DeleteEntitiesDirectly(typeof(CustomerTraleEntity), bucket);
            }
            return true;
        }

        public bool UpdateCustomerTrale(long oldCustomerId, long newCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var customerPredictedZipBucket = new RelationPredicateBucket(CustomerTraleFields.CustomerId == oldCustomerId);
                var entities = new EntityCollection<CustomerTraleEntity>();

                adapter.FetchEntityCollection(entities, customerPredictedZipBucket);

                foreach (var cba in entities)
                {
                    cba.CustomerId = newCustomerId;
                    adapter.SaveEntity(cba);
                }
            }
            return true;
        }

        public bool DeleteCareCodeingOutbound(long oldCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var bucket = new RelationPredicateBucket(CareCodingOutboundFields.CustomerId == oldCustomerId);
                adapter.DeleteEntitiesDirectly(typeof(CareCodingOutboundEntity), bucket);
            }
            return true;
        }

        public bool UpdateCareCodingOutbound(long oldCustomerId, long newCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {

                var careCodingOutboundBucket = new RelationPredicateBucket(CareCodingOutboundFields.CustomerId == oldCustomerId);
                var entities = new EntityCollection<CareCodingOutboundEntity>();

                adapter.FetchEntityCollection(entities, careCodingOutboundBucket);

                foreach (var cba in entities)
                {
                    cba.CustomerId = newCustomerId;
                    adapter.SaveEntity(cba);
                }
            }
            return true;
        }

        public bool DeleteCustomerUnsubscribed(long oldCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var bucket = new RelationPredicateBucket(CustomerUnsubscribedSmsNotificationFields.CustomerId == oldCustomerId);
                adapter.DeleteEntitiesDirectly(typeof(CustomerUnsubscribedSmsNotificationEntity), bucket);
            }
            return true;
        }

        public bool UpdateCustomerUnsubscribed(long oldCustomerId, long newCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {

                var careCodingOutboundBucket = new RelationPredicateBucket(CustomerUnsubscribedSmsNotificationFields.CustomerId == oldCustomerId);
                var entities = new EntityCollection<CustomerUnsubscribedSmsNotificationEntity>();

                adapter.FetchEntityCollection(entities, careCodingOutboundBucket);

                foreach (var cba in entities)
                {
                    cba.CustomerId = newCustomerId;
                    adapter.SaveEntity(cba);
                }
            }

            return true;
        }

        public bool UpdateSuspectCondition(long oldCustomerId, long newCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var suspectCondition = new SuspectConditionEntity { CustomerId = newCustomerId };
                var suspectConditionBucket = new RelationPredicateBucket(SuspectConditionFields.CustomerId == oldCustomerId);
                adapter.UpdateEntitiesDirectly(suspectCondition, suspectConditionBucket);
            }
            return true;
        }

        public bool DeleteSuspectCondition(long oldCustomerId, IEnumerable<long> suspectId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var bucket = new RelationPredicateBucket(SuspectConditionFields.Id == suspectId.ToArray());
                bucket.PredicateExpression.AddWithAnd(SuspectConditionFields.CustomerId == oldCustomerId);
                adapter.DeleteEntitiesDirectly(typeof(SuspectConditionEntity), bucket);
            }
            return true;
        }

        public bool UpdateMedication(long oldCustomerId, long newCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var medication = new MedicationEntity { CustomerId = newCustomerId };
                var bucket = new RelationPredicateBucket(MedicationFields.CustomerId == oldCustomerId);

                adapter.UpdateEntitiesDirectly(medication, bucket);
            }
            return true;
        }

        public bool DeleteMedication(long oldCustomerId, IEnumerable<long> medicationId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var bucket = new RelationPredicateBucket(SuspectConditionFields.Id == medicationId.ToArray());
                bucket.PredicateExpression.AddWithAnd(SuspectConditionFields.CustomerId == oldCustomerId);
                adapter.DeleteEntitiesDirectly(typeof(SuspectConditionEntity), bucket);
            }
            return true;
        }

        public bool UpdateCustomerProfileHistory(long mergedCustomerId, long customerProfileHistoryId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var customerProfileHistory = new CustomerProfileHistoryEntity { MergedCustomerId = mergedCustomerId };
                var bucket = new RelationPredicateBucket(CustomerProfileHistoryFields.Id == customerProfileHistoryId);

                adapter.UpdateEntitiesDirectly(customerProfileHistory, bucket);
            }
            return true;
        }

        public bool DeleteCustomerWarmTransfer(long oldCustomerId, int forYear)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var bucket = new RelationPredicateBucket(CustomerWarmTransferFields.CustomerId == oldCustomerId);
                bucket.PredicateExpression.AddWithAnd(CustomerWarmTransferFields.WarmTransferYear == forYear);
                adapter.DeleteEntitiesDirectly(typeof(CustomerWarmTransferEntity), bucket);
            }

            return true;
        }

        public bool UpdateCustomerWarmTransfer(long oldCustomerId, long newCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var medication = new CustomerWarmTransferEntity { CustomerId = newCustomerId };
                var bucket = new RelationPredicateBucket(CustomerWarmTransferFields.CustomerId == oldCustomerId);

                adapter.UpdateEntitiesDirectly(medication, bucket);
            }

            return true;
        }

        public bool UpdateCustomerClinicalQuestionAnswer(long oldCustomerId, long newCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var medication = new CustomerClinicalQuestionAnswerEntity { CustomerId = newCustomerId };
                var bucket = new RelationPredicateBucket(CustomerClinicalQuestionAnswerFields.CustomerId == oldCustomerId);

                adapter.UpdateEntitiesDirectly(medication, bucket);
            }

            return true;
        }
    }
}
