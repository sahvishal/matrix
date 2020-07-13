using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Extension;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;

namespace Falcon.App.Infrastructure.CallQueues.Repositories
{
    [DefaultImplementation]
    public class GmsExcludedCustomerRepository : PersistenceRepository, IGmsExcludedCustomerRepository
    {
        private readonly IZipCodeRepository _zipCodeRepository;
        private const string CommaString = ",";

        public GmsExcludedCustomerRepository(IZipCodeRepository zipCodeRepository)
        {
            _zipCodeRepository = zipCodeRepository;
        }

        public IEnumerable<GmsExcludedCustomerViewModel> GetExcludedCallQueueCustomers(int pageNumber, int pageSize, OutboundCallQueueFilter filter, CallQueue callQueue, SuppressionFilterType suppressionType, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var startOfYear = new DateTime(DateTime.Now.Year, 1, 1);
                var notInterested = ProspectCustomerTag.NotInterested.ToString();
                var declinedMobileAndHomeVisit = ProspectCustomerTag.DeclinedMobileAndHomeVisit.ToString();
                var recentlySawDoc = ProspectCustomerTag.RecentlySawDoc.ToString();
                var transportationIssue = ProspectCustomerTag.TransportationIssue.ToString();
                var declinedMemberNotMammoAvailableNoEventsInArea = ProspectCustomerTag.DeclinedMemberNotMammoAvailableNoEventsInArea.ToString();
                var declinedMammoNotinterestedInMammogram = ProspectCustomerTag.DeclinedMammoNotinterestedInMammogram.ToString();

                var dateTimeConflict = ProspectCustomerTag.DateTimeConflict.ToString();
                var cancelAppointment = ProspectCustomerTag.CancelAppointment.ToString();
                var leftMessagewithOther = ProspectCustomerTag.LeftMessage.ToString();
                var languageBarrier = ProspectCustomerTag.LanguageBarrier.ToString();
                var noShow = ProspectCustomerTag.NoShow.ToString();

                var othersFilterDate = DateTime.Today.AddDays(-(filter.NumberOfDaysForOthers - 1));
                var leftVoiceMailDate = DateTime.Today.AddDays(-(filter.NumberOfDaysForLeftVoiceMail - 1));
                var refusalDate = DateTime.Today.AddDays(-(filter.NumberOfDaysForRefusedCustomer - 1));

                var linqMetaData = new LinqMetaData(adapter);

                var maxAttemptForQueue = filter.MaxAttempt > 0 ? filter.MaxAttempt : callQueue.Attempts;

                var query = (from cqcca in linqMetaData.VwCallQueueCustomerCriteraAssignmentForStats
                             where cqcca.CallQueueId == callQueue.Id && cqcca.CriteriaId == filter.CriteriaId
                             && cqcca.HealthPlanId == filter.HealthPlanId
                             select cqcca);

                var zipIdsString = string.Empty;
                var customTags = string.Empty;

                var eventId = filter.EventId ?? 0;

                if (eventId > 0)
                {
                    var zipQuery = (from ez in linqMetaData.EventZip where ez.EventId == eventId select ez.ZipId);
                    query = (from q in query where zipQuery.Contains(q.ZipId) select q);
                }

                if (!string.IsNullOrEmpty(filter.ZipCode))
                {
                    if (filter.Radius > 0)
                    {
                        long zipCodeId = 0;
                        var zipCode = _zipCodeRepository.GetZipCode(filter.ZipCode).FirstOrDefault();
                        if (zipCode != null)
                            zipCodeId = zipCode.Id;

                        var zipRadiusDistance = (from zrd in linqMetaData.ZipRadiusDistance
                                                 where zrd.SourceZipId == zipCodeId && zrd.Radius <= filter.Radius
                                                 select zrd.DestinationZipId);

                        query = from a in query
                                where zipRadiusDistance.Contains(a.ZipId)
                                select a;
                    }
                    else
                    {
                        var zipCodes = _zipCodeRepository.GetZipCode(filter.ZipCode);
                        if (zipCodes != null && zipCodes.Any())
                        {
                            var zipIds = zipCodes.Select(z => z.Id).ToArray();
                            query = from q in query
                                    where zipIds.Contains(q.ZipId)
                                    select q;
                        }
                    }
                }

                if (!string.IsNullOrWhiteSpace(filter.CustomCorporateTag))
                {
                    customTags = CommaString + filter.CustomCorporateTag + CommaString;

                    var tagCustomers = (from ct in linqMetaData.VwGetCustomerTagForCallQueue where ct.IsActive && customTags.IndexOf(CommaString + ct.Tag + CommaString) >= 0 select ct.CustomerId);

                    query = (from q in query where tagCustomers.Contains(q.CustomerId) select q);
                }

                if (filter.DirectMailDate.HasValue)
                {
                    var mailedCustomerIds = (from dm in linqMetaData.VwGetDirectMailForCallQueue where dm.CampaignId == filter.CampaignId && dm.MailDate >= filter.DirectMailDate.Value && dm.MailDate < filter.DirectMailDate.Value.AddDays(1) select dm.CustomerId);

                    query = (from q in query where mailedCustomerIds.Contains(q.CustomerId) select q);
                }

                var eventZip = (from aez in linqMetaData.AccountEventZip where aez.AccountId == filter.HealthPlanId select aez.ZipId);
                var substituteZip = (from aezs in linqMetaData.AccountEventZipSubstitute where aezs.AccountId == filter.HealthPlanId select aezs.ZipId);
                var refusalTags = GetRefusalTag();

                IQueryable<VwCallQueueCustomerCriteraAssignmentForStatsEntity> entities = null;

                if (suppressionType != SuppressionFilterType.MaxAttempt)
                {
                    if (filter.IsMaxAttemptPerHealthPlan)
                    {
                        query = (from q in query where q.CallCount < maxAttemptForQueue select q);
                    }
                    else
                    {
                        query = (from q in query where q.Attempts < maxAttemptForQueue select q);
                    }
                }
                if (callQueue.Category != HealthPlanCallQueueCategory.LanguageBarrier)
                {
                    switch (suppressionType)
                    {
                        case SuppressionFilterType.MaxAttempt:
                            if (filter.IsMaxAttemptPerHealthPlan)
                            {
                                entities = (from q in query
                                            where q.CallCount >= maxAttemptForQueue
                                            select q);
                            }
                            else
                            {
                                entities = (from q in query
                                            where q.Attempts >= maxAttemptForQueue
                                            select q);
                            }
                            break;

                        case SuppressionFilterType.NotEligible:
                            entities = (from cqc in query
                                        where (cqc.IsEligble == false)
                                        select cqc);
                            break;

                        case SuppressionFilterType.NonTargeted:
                            entities = (from cqc in query
                                        where cqc.IsEligble == true
                                        && (cqc.TargetedYear != startOfYear.Year || cqc.IsTargeted == false)
                                        select cqc);
                            break;

                        //case SuppressionFilterType.DoNotContact:
                        //    entities = (from cqc in query
                        //                where cqc.IsEligble
                        //                      && (cqc.TargetedYear == startOfYear.Year && cqc.IsTargeted == true)
                        //                      && ((cqc.DoNotContactUpdateDate > startOfYear
                        //                           && (cqc.DoNotContactTypeId == (long)DoNotContactType.DoNotContact || cqc.DoNotContactTypeId == (long)DoNotContactType.DoNotCall))
                        //                          || (cqc.DoNotContactUpdateSource == (long)DoNotContactSource.Manual && cqc.DoNotContactTypeId != (long)DoNotContactType.DoNotMail))
                        //                select cqc);
                        //    break;

                        case SuppressionFilterType.DoNotContact:
                            entities = (from cqc in query
                                        where cqc.IsEligble
                                              && (cqc.TargetedYear == startOfYear.Year && cqc.IsTargeted == true)
                                              && (cqc.DoNotContactTypeId == (long)DoNotContactType.DoNotContact || cqc.DoNotContactTypeId == (long)DoNotContactType.DoNotCall)
                                        select cqc);
                            break;

                        case SuppressionFilterType.DoNotCallActivity:
                            entities = (from cp in query
                                        where cp.IsEligble
                                        && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                        && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                        && (cp.ActivityId == (long)UploadActivityType.MailOnly || cp.ActivityId == (long)UploadActivityType.DoNotCallDoNotMail)
                                        select cp);
                            break;

                        case SuppressionFilterType.LanguageBarrier:
                            entities = (from cp in query
                                        where cp.IsEligble
                                        && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                        && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                        && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                        && (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear)
                                        select cp);
                            break;

                        case SuppressionFilterType.IncorrectPhone:
                            entities = (from cp in query
                                        where cp.IsEligble
                                        && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                        && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)

                                        && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                        && (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate >= startOfYear)
                                        && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                        select cp);
                            break;

                        case SuppressionFilterType.NoPhone:
                            entities = (from cp in query
                                        where cp.IsEligble
                                        && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                        && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                        && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                        && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                        && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                        && ((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))

                                        select cp);
                            break;

                        case SuppressionFilterType.AppointmentBooked:
                            entities = (from cp in query
                                        where cp.IsEligble == true
                                           && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                           && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                           && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                           && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                           && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                           && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
                                           && (cp.AppointmentDate >= startOfYear)
                                        select cp);
                            break;

                        case SuppressionFilterType.Deceased:
                            entities = (from cp in query
                                        where cp.IsEligble
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
                                            && (cp.AppointmentDate <= startOfYear)
                                            && (cp.Disposition == ProspectCustomerTag.Deceased.ToString())
                                        select cp);
                            break;

                        case SuppressionFilterType.HomeVisitRequested:
                            entities = (from cp in query
                                        where cp.IsEligble
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
                                            && (cp.AppointmentDate <= startOfYear)
                                            && (cp.ContactedDate >= startOfYear && cp.Disposition == ProspectCustomerTag.HomeVisitRequested.ToString())
                                        select cp);
                            break;

                        case SuppressionFilterType.MobilityIssue:
                            entities = (from cp in query
                                        where cp.IsEligble
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
                                            && (cp.AppointmentDate <= startOfYear)
                                            && (cp.ContactedDate >= startOfYear && cp.Disposition == ProspectCustomerTag.MobilityIssue.ToString())
                                        select cp);
                            break;

                        case SuppressionFilterType.InLongTermCareNursingHome:
                            entities = (from cp in query
                                        where cp.IsEligble
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
                                            && (cp.AppointmentDate <= startOfYear)
                                            && (cp.ContactedDate >= startOfYear && cp.Disposition == ProspectCustomerTag.InLongTermCareNursingHome.ToString())
                                        select cp);
                            break;

                        case SuppressionFilterType.MobilityIssues_LeftMessageWithOther:
                            entities = (from cp in query
                                        where cp.IsEligble
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
                                            && (cp.AppointmentDate <= startOfYear)
                                            && (cp.ContactedDate >= startOfYear && cp.Disposition == ProspectCustomerTag.MobilityIssues_LeftMessageWithOther.ToString())
                                        select cp);
                            break;

                        case SuppressionFilterType.NoLongeronInsurancePlan:
                            entities = (from cp in query
                                        where cp.IsEligble
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
                                            && (cp.AppointmentDate <= startOfYear)
                                            && (cp.ContactedDate >= startOfYear && cp.Disposition == ProspectCustomerTag.NoLongeronInsurancePlan.ToString())
                                        select cp);
                            break;

                        case SuppressionFilterType.DebilitatingDisease:
                            entities = (from cp in query
                                        where cp.IsEligble
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
                                            && (cp.AppointmentDate <= startOfYear)
                                            && (cp.ContactedDate >= startOfYear && cp.Disposition == ProspectCustomerTag.DebilitatingDisease.ToString())
                                        select cp);
                            break;


                        case SuppressionFilterType.CallBackLater:
                            entities = (from cp in query
                                        where cp.IsEligble == true
                                           && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                           && (cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail || cp.DoNotContactTypeId == 0)
                                           && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                           && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
                                           && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                           && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                           && (cp.AppointmentDate <= startOfYear)
                                           && cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now
                                        select cp);
                            break;

                        case SuppressionFilterType.NoEventsInArea:
                            entities = (from cp in query
                                        where cp.IsEligble == true
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                            && (cp.AppointmentDate <= startOfYear)
                                            && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                            && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                            && !(eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                        select cp);
                            break;



                        case SuppressionFilterType.LeftVoiceMessage:
                            entities = (from cp in query
                                        where cp.IsEligble == true
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                            && (cp.AppointmentDate <= startOfYear)
                                            && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                            && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                            && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                            && (cp.ContactedDate >= leftVoiceMailDate && cp.CallStatus == (long)CallStatus.VoiceMessage)
                                        select cp);
                            break;

                        case SuppressionFilterType.NotInterested:
                            entities = (from cp in query
                                        where cp.IsEligble == true
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                            && (cp.AppointmentDate <= startOfYear)
                                            && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                            && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                            && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                            && (cp.ContactedDate >= refusalDate && (cp.CallStatus != (long)CallStatus.CallSkipped && cp.CallStatus != (long)CallStatus.VoiceMessage) && (cp.Disposition == notInterested || cp.Disposition == declinedMobileAndHomeVisit))
                                        select cp);
                            break;

                        case SuppressionFilterType.RecentlySawDoc:
                            entities = (from cp in query
                                        where cp.IsEligble == true
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                            && (cp.AppointmentDate <= startOfYear)
                                            && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                            && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                            && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                            && (cp.ContactedDate >= refusalDate && (cp.CallStatus != (long)CallStatus.CallSkipped && cp.CallStatus != (long)CallStatus.VoiceMessage) && (cp.Disposition == recentlySawDoc))
                                        select cp);
                            break;

                        case SuppressionFilterType.TransportationIssue:
                            entities = (from cp in query
                                        where cp.IsEligble == true
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                            && (cp.AppointmentDate <= startOfYear)
                                            && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                            && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                            && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                            && (cp.ContactedDate >= refusalDate && (cp.CallStatus != (long)CallStatus.CallSkipped && cp.CallStatus != (long)CallStatus.VoiceMessage) && (cp.Disposition == transportationIssue))
                                        select cp);
                            break;

                        case SuppressionFilterType.AppointmentCancelledDate:
                            entities = (from cp in query
                                        where cp.IsEligble == true
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                            && (cp.AppointmentDate <= startOfYear)
                                                      && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                                      && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                                      && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                                      && cp.AppointmentCancellationDate >= leftVoiceMailDate
                                        select cp);
                            break;

                        case SuppressionFilterType.NoShowMarkDate:
                            entities = (from cp in query
                                        where cp.IsEligble == true
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                            && (cp.AppointmentDate <= startOfYear)
                                                      && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                                      && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                                      && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                                      && cp.NoShowDate >= leftVoiceMailDate
                                        select cp);
                            break;

                        case SuppressionFilterType.CallSkipped:
                            entities = (from cp in query
                                        where cp.IsEligble == true
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                            && (cp.AppointmentDate <= startOfYear)
                                            && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                            && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                            && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                            && (cp.ContactedDate >= DateTime.Today && (cp.CallStatus == (long)CallStatus.CallSkipped))
                                        select cp);
                            break;

                        case SuppressionFilterType.CallInitiated:
                            entities = (from cp in query
                                        where cp.IsEligble == true
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                            && (cp.AppointmentDate <= startOfYear)
                                            && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                            && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                            && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                            && (cp.ContactedDate >= DateTime.Today && (cp.CallStatus == (long)CallStatus.Initiated))
                                        select cp);
                            break;

                        case SuppressionFilterType.MovedRelocated:
                            entities = (from cp in query
                                        where cp.IsEligble == true
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                            && (cp.AppointmentDate <= startOfYear)
                                            && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                            && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                            && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                            && (cp.ContactedDate >= othersFilterDate && cp.CallStatus != (long)CallStatus.CallSkipped && (cp.Disposition != ProspectCustomerTag.CallBackLater.ToString()
                                            && cp.Disposition != ProspectCustomerTag.LanguageBarrier.ToString()) && (cp.Disposition == ProspectCustomerTag.MovedRelocated.ToString()))
                                        select cp);
                            break;

                        case SuppressionFilterType.WillSpeakWithPhysician:
                            entities = (from cp in query
                                        where cp.IsEligble == true
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                            && (cp.AppointmentDate <= startOfYear)
                                            && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                            && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                            && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                            && (cp.ContactedDate >= othersFilterDate && cp.CallStatus != (long)CallStatus.CallSkipped && (cp.Disposition != ProspectCustomerTag.CallBackLater.ToString()
                                            && cp.Disposition != ProspectCustomerTag.LanguageBarrier.ToString()) && (cp.Disposition == ProspectCustomerTag.SpeakWithPhysician.ToString()))
                                        select cp);
                            break;

                        case SuppressionFilterType.DateTimeConflict:
                            entities = (from cp in query
                                        where cp.IsEligble == true
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                            && (cp.AppointmentDate <= startOfYear)
                                                      && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                                      && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                                      && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                                      && (cp.ContactedDate >= leftVoiceMailDate && cp.CallStatus != (long)CallStatus.CallSkipped && (cp.Disposition != ProspectCustomerTag.CallBackLater.ToString()
                                                      && cp.Disposition != ProspectCustomerTag.LanguageBarrier.ToString()) && (cp.Disposition == ProspectCustomerTag.DateTimeConflict.ToString()))
                                        select cp);
                            break;

                        case SuppressionFilterType.NoAnswer:
                            entities = (from cp in query
                                        where cp.IsEligble == true
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                            && (cp.AppointmentDate <= startOfYear)
                                                      && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                                      && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                                      && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                                      && (cp.ContactedDate >= leftVoiceMailDate && (cp.CallStatus == (long)CallStatus.NoAnswer))
                                        select cp);
                            break;

                        case SuppressionFilterType.NoEventsInAreaCallStatus:
                            entities = (from cp in query
                                        where cp.IsEligble == true
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                            && (cp.AppointmentDate <= startOfYear)
                                            && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                            && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                            && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                            && (cp.ContactedDate >= othersFilterDate && (cp.CallStatus == (long)CallStatus.NoEventsInArea))
                                        select cp);
                            break;

                        case SuppressionFilterType.LeftMessageWithOthers:
                            entities = (from cp in query
                                        where cp.IsEligble == true
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                            && (cp.AppointmentDate <= startOfYear)
                                                      && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                                      && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                                      && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                                      && (cp.ContactedDate >= leftVoiceMailDate && (cp.CallStatus == (long)CallStatus.LeftMessageWithOther))
                                        select cp);
                            break;

                        case SuppressionFilterType.InvalidNumber:
                            entities = (from cp in query
                                        where cp.IsEligble == true
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                            && (cp.AppointmentDate <= startOfYear)
                                            && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                            && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                            && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                            && (cp.ContactedDate >= othersFilterDate && (cp.CallStatus == (long)CallStatus.InvalidNumber))
                                        select cp);
                            break;

                        case SuppressionFilterType.DeclinedMemberNotMammoAvailableNoEventsInArea:
                            entities = (from cp in query
                                        where cp.IsEligble == true
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                            && (cp.AppointmentDate <= startOfYear)
                                            && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                            && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                            && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                            && (cp.ContactedDate >= refusalDate && (cp.CallStatus != (long)CallStatus.CallSkipped && cp.CallStatus != (long)CallStatus.VoiceMessage) && (cp.Disposition == declinedMemberNotMammoAvailableNoEventsInArea))
                                        select cp);
                            break;

                        case SuppressionFilterType.DeclinedMammoNotinterestedInMammogram:
                            entities = (from cp in query
                                        where cp.IsEligble == true
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                            && (cp.AppointmentDate <= startOfYear)
                                            && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                            && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                            && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                            && (cp.ContactedDate >= refusalDate && (cp.CallStatus != (long)CallStatus.CallSkipped && cp.CallStatus != (long)CallStatus.VoiceMessage) && (cp.Disposition == declinedMammoNotinterestedInMammogram))
                                        select cp);
                            break;
                    }
                }
                else
                {
                    switch (suppressionType)
                    {
                        case SuppressionFilterType.MaxAttempt:
                            if (filter.IsMaxAttemptPerHealthPlan)
                            {
                                entities = (from q in query
                                            where q.CallCount >= maxAttemptForQueue
                                            select q);
                            }
                            else
                            {
                                entities = (from q in query
                                            where q.Attempts >= maxAttemptForQueue
                                            select q);
                            }
                            break;

                        case SuppressionFilterType.NotEligible:
                            entities = (from cqc in query
                                        where (cqc.IsEligble == false)
                                        select cqc);
                            break;

                        case SuppressionFilterType.NonTargeted:
                            entities = (from cqc in query
                                        where cqc.IsEligble == true
                                        && (cqc.TargetedYear != startOfYear.Year || cqc.IsTargeted == false)
                                        select cqc);
                            break;

                        case SuppressionFilterType.DoNotContact:
                            entities = (from cqc in query
                                        where cqc.IsEligble
                                            && (cqc.TargetedYear == startOfYear.Year && cqc.IsTargeted == false)
                                            && (cqc.DoNotContactTypeId == (long)DoNotContactType.DoNotContact || cqc.DoNotContactTypeId == (long)DoNotContactType.DoNotCall)
                                        select cqc);
                            break;

                        case SuppressionFilterType.DoNotCallActivity:
                            entities = (from cp in query
                                        where cp.IsEligble && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                        && (cp.ActivityId == (long)UploadActivityType.MailOnly || cp.ActivityId == (long)UploadActivityType.DoNotCallDoNotMail)
                                        select cp);
                            break;

                        case SuppressionFilterType.IncorrectPhone:
                            entities = (from cp in query
                                        where cp.IsEligble
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate >= startOfYear)
                                            && ((cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear))
                                        select cp);
                            break;

                        case SuppressionFilterType.NoPhone:
                            entities = (from cp in query
                                        where cp.IsEligble
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && ((cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear))
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && ((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))

                                        select cp);
                            break;

                        case SuppressionFilterType.AppointmentBooked:
                            entities = (from cp in query
                                        where cp.IsEligble == true
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && ((cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear))
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
                                            && (cp.AppointmentDate >= startOfYear)
                                        select cp);
                            break;

                        case SuppressionFilterType.Deceased:
                            entities = (from cp in query
                                        where cp.IsEligble
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && ((cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear))
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
                                            && (cp.AppointmentDate <= startOfYear)
                                            && (cp.Disposition == ProspectCustomerTag.Deceased.ToString())
                                        select cp);
                            break;

                        case SuppressionFilterType.HomeVisitRequested:
                            entities = (from cp in query
                                        where cp.IsEligble
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && ((cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear))
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
                                            && (cp.AppointmentDate <= startOfYear)
                                            && (cp.ContactedDate >= startOfYear && cp.Disposition == ProspectCustomerTag.HomeVisitRequested.ToString())
                                        select cp);
                            break;

                        case SuppressionFilterType.MobilityIssue:
                            entities = (from cp in query
                                        where cp.IsEligble
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && ((cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear))
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
                                            && (cp.AppointmentDate <= startOfYear)
                                            && (cp.ContactedDate >= startOfYear && cp.Disposition == ProspectCustomerTag.MobilityIssue.ToString())
                                        select cp);
                            break;

                        case SuppressionFilterType.InLongTermCareNursingHome:
                            entities = (from cp in query
                                        where cp.IsEligble
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && ((cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear))
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
                                            && (cp.AppointmentDate <= startOfYear)
                                            && (cp.ContactedDate >= startOfYear && cp.Disposition == ProspectCustomerTag.InLongTermCareNursingHome.ToString())
                                        select cp);
                            break;

                        case SuppressionFilterType.MobilityIssues_LeftMessageWithOther:
                            entities = (from cp in query
                                        where cp.IsEligble
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && ((cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear))
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
                                            && (cp.AppointmentDate <= startOfYear)
                                            && (cp.ContactedDate >= startOfYear && cp.Disposition == ProspectCustomerTag.MobilityIssues_LeftMessageWithOther.ToString())
                                        select cp);
                            break;

                        case SuppressionFilterType.NoLongeronInsurancePlan:
                            entities = (from cp in query
                                        where cp.IsEligble
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && ((cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear))
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
                                            && (cp.AppointmentDate <= startOfYear)
                                            && (cp.ContactedDate >= startOfYear && cp.Disposition == ProspectCustomerTag.NoLongeronInsurancePlan.ToString())
                                        select cp);
                            break;

                        case SuppressionFilterType.DebilitatingDisease:
                            entities = (from cp in query
                                        where cp.IsEligble
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && ((cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear))
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
                                            && (cp.AppointmentDate <= startOfYear)
                                            && (cp.ContactedDate >= startOfYear && cp.Disposition == ProspectCustomerTag.DebilitatingDisease.ToString())
                                        select cp);
                            break;


                        case SuppressionFilterType.CallBackLater:
                            entities = (from cp in query
                                        where cp.IsEligble == true
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail || cp.DoNotContactTypeId == 0)
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && ((cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear))
                                            && (cp.AppointmentDate <= startOfYear)
                                            && cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now
                                        select cp);
                            break;

                        case SuppressionFilterType.NoEventsInArea:
                            entities = (from cp in query
                                        where cp.IsEligble == true
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && ((cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear))
                                            && (cp.AppointmentDate <= startOfYear)
                                            && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                            && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                            && !(eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                        select cp);
                            break;



                        case SuppressionFilterType.LeftVoiceMessage:
                            entities = (from cp in query
                                        where cp.IsEligble == true
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && ((cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear))
                                            && (cp.AppointmentDate <= startOfYear)
                                            && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                            && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                            && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                            && (cp.ContactedDate >= leftVoiceMailDate && cp.CallStatus == (long)CallStatus.VoiceMessage)
                                        select cp);
                            break;

                        case SuppressionFilterType.NotInterested:
                            entities = (from cp in query
                                        where cp.IsEligble == true
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && ((cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear))
                                            && (cp.AppointmentDate <= startOfYear)
                                            && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                            && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                            && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                            && (cp.ContactedDate >= refusalDate && (cp.CallStatus != (long)CallStatus.CallSkipped && cp.CallStatus != (long)CallStatus.VoiceMessage) && (cp.Disposition == notInterested || cp.Disposition == declinedMobileAndHomeVisit))
                                        select cp);
                            break;

                        case SuppressionFilterType.RecentlySawDoc:
                            entities = (from cp in query
                                        where cp.IsEligble == true
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && ((cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear))
                                            && (cp.AppointmentDate <= startOfYear)
                                            && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                            && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                            && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                            && (cp.ContactedDate >= refusalDate && (cp.CallStatus != (long)CallStatus.CallSkipped && cp.CallStatus != (long)CallStatus.VoiceMessage) && (cp.Disposition == recentlySawDoc))
                                        select cp);
                            break;

                        case SuppressionFilterType.TransportationIssue:
                            entities = (from cp in query
                                        where cp.IsEligble == true
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && ((cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear))
                                            && (cp.AppointmentDate <= startOfYear)
                                            && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                            && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                            && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                            && (cp.ContactedDate >= refusalDate && (cp.CallStatus != (long)CallStatus.CallSkipped && cp.CallStatus != (long)CallStatus.VoiceMessage) && (cp.Disposition == transportationIssue))
                                        select cp);
                            break;

                        case SuppressionFilterType.AppointmentCancelledDate:
                            entities = (from cp in query
                                        where cp.IsEligble == true
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && ((cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear))
                                            && (cp.AppointmentDate <= startOfYear)
                                                      && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                                      && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                                      && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                                      && cp.AppointmentCancellationDate >= leftVoiceMailDate
                                        select cp);
                            break;

                        case SuppressionFilterType.NoShowMarkDate:
                            entities = (from cp in query
                                        where cp.IsEligble == true
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && ((cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear))
                                            && (cp.AppointmentDate <= startOfYear)
                                                      && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                                      && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                                      && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                                      && cp.NoShowDate >= leftVoiceMailDate
                                        select cp);
                            break;

                        case SuppressionFilterType.CallSkipped:
                            entities = (from cp in query
                                        where cp.IsEligble == true
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && ((cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear))
                                            && (cp.AppointmentDate <= startOfYear)
                                            && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                            && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                            && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                            && (cp.ContactedDate >= DateTime.Today && (cp.CallStatus == (long)CallStatus.CallSkipped))
                                        select cp);
                            break;

                        case SuppressionFilterType.CallInitiated:
                            entities = (from cp in query
                                        where cp.IsEligble == true
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && ((cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear))
                                            && (cp.AppointmentDate <= startOfYear)
                                            && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                            && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                            && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                            && (cp.ContactedDate >= DateTime.Today && (cp.CallStatus == (long)CallStatus.Initiated))
                                        select cp);
                            break;

                        case SuppressionFilterType.MovedRelocated:
                            entities = (from cp in query
                                        where cp.IsEligble == true
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && ((cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear))
                                            && (cp.AppointmentDate <= startOfYear)
                                            && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                            && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                            && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                            && (cp.ContactedDate >= othersFilterDate && cp.CallStatus != (long)CallStatus.CallSkipped && (cp.Disposition != ProspectCustomerTag.CallBackLater.ToString()
                                            && cp.Disposition != ProspectCustomerTag.LanguageBarrier.ToString()) && (cp.Disposition == ProspectCustomerTag.MovedRelocated.ToString()))
                                        select cp);
                            break;

                        case SuppressionFilterType.WillSpeakWithPhysician:
                            entities = (from cp in query
                                        where cp.IsEligble == true
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && ((cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear))
                                            && (cp.AppointmentDate <= startOfYear)
                                            && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                            && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                            && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                            && (cp.ContactedDate >= othersFilterDate && cp.CallStatus != (long)CallStatus.CallSkipped && (cp.Disposition != ProspectCustomerTag.CallBackLater.ToString()
                                            && cp.Disposition != ProspectCustomerTag.LanguageBarrier.ToString()) && (cp.Disposition == ProspectCustomerTag.SpeakWithPhysician.ToString()))
                                        select cp);
                            break;

                        case SuppressionFilterType.DateTimeConflict:
                            entities = (from cp in query
                                        where cp.IsEligble == true
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && ((cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear))
                                            && (cp.AppointmentDate <= startOfYear)
                                                      && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                                      && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                                      && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                                      && (cp.ContactedDate >= leftVoiceMailDate && cp.CallStatus != (long)CallStatus.CallSkipped && (cp.Disposition != ProspectCustomerTag.CallBackLater.ToString()
                                                      && cp.Disposition != ProspectCustomerTag.LanguageBarrier.ToString()) && (cp.Disposition == ProspectCustomerTag.DateTimeConflict.ToString()))
                                        select cp);
                            break;

                        case SuppressionFilterType.NoAnswer:
                            entities = (from cp in query
                                        where cp.IsEligble == true
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && ((cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear))
                                            && (cp.AppointmentDate <= startOfYear)
                                                      && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                                      && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                                      && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                                      && (cp.ContactedDate >= leftVoiceMailDate && (cp.CallStatus == (long)CallStatus.NoAnswer))
                                        select cp);
                            break;

                        case SuppressionFilterType.NoEventsInAreaCallStatus:
                            entities = (from cp in query
                                        where cp.IsEligble == true
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && ((cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear))
                                            && (cp.AppointmentDate <= startOfYear)
                                            && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                            && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                            && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                            && (cp.ContactedDate >= othersFilterDate && (cp.CallStatus == (long)CallStatus.NoEventsInArea))
                                        select cp);
                            break;

                        case SuppressionFilterType.LeftMessageWithOthers:
                            entities = (from cp in query
                                        where cp.IsEligble == true
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && ((cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear))
                                            && (cp.AppointmentDate <= startOfYear)
                                                      && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                                      && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                                      && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                                      && (cp.ContactedDate >= leftVoiceMailDate && (cp.CallStatus == (long)CallStatus.LeftMessageWithOther))
                                        select cp);
                            break;

                        case SuppressionFilterType.InvalidNumber:
                            entities = (from cp in query
                                        where cp.IsEligble == true
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                                      && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                                      && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                                      && ((cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear))
                                                      && (cp.AppointmentDate <= startOfYear)
                                                      && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                                      && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                                      && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                                      && (cp.ContactedDate >= othersFilterDate && (cp.CallStatus == (long)CallStatus.InvalidNumber))
                                        select cp);
                            break;



                        case SuppressionFilterType.DeclinedMemberNotMammoAvailableNoEventsInArea:
                            entities = (from cp in query
                                        where cp.IsEligble == true
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && ((cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear))
                                            && (cp.AppointmentDate <= startOfYear)
                                            && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                            && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                            && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                            && (cp.ContactedDate >= refusalDate && (cp.CallStatus != (long)CallStatus.CallSkipped && cp.CallStatus != (long)CallStatus.VoiceMessage) && (cp.Disposition == declinedMemberNotMammoAvailableNoEventsInArea))
                                        select cp);
                            break;

                        case SuppressionFilterType.DeclinedMammoNotinterestedInMammogram:
                            entities = (from cp in query
                                        where cp.IsEligble == true
                                            && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                            && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                            && ((cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear))
                                            && (cp.AppointmentDate <= startOfYear)
                                            && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                            && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                            && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                            && (cp.ContactedDate >= refusalDate && (cp.CallStatus != (long)CallStatus.CallSkipped && cp.CallStatus != (long)CallStatus.VoiceMessage) && (cp.Disposition == declinedMammoNotinterestedInMammogram))
                                        select cp);
                            break;
                    }
                }


                if (entities == null)
                {
                    totalRecords = 0;
                    return new List<GmsExcludedCustomerViewModel>();
                }

                totalRecords = entities.Count();

                var pagedEntities = entities.OrderBy(x => x.CustomerId).TakePage(pageNumber, pageSize).ToArray();

                return pagedEntities.Select(x => new GmsExcludedCustomerViewModel
                {
                    CustomerId = x.CustomerId,
                    Name = new Name(x.FirstName, x.MiddleName, x.LastName),
                    ZipCode = x.ZipCode,
                    Reason = suppressionType == SuppressionFilterType.NotInterested ? EnumExtensions.GetDescription((ProspectCustomerTag)Enum.Parse(typeof(ProspectCustomerTag), x.Disposition)) : EnumExtension.GetDescription(suppressionType)
                });
            }
        }

        private IEnumerable<string> GetRefusalTag()
        {
            var homeVisitRequested = ProspectCustomerTag.HomeVisitRequested.ToString();
            var doNotContact = ProspectCustomerTag.DoNotCall.ToString();
            var deceased = ProspectCustomerTag.Deceased.ToString();
            var mobilityIssue = ProspectCustomerTag.MobilityIssue.ToString();
            var inLongTermCareNursingHome = ProspectCustomerTag.InLongTermCareNursingHome.ToString();
            var mobilityIssue_LeftMessageWithOther = ProspectCustomerTag.MobilityIssues_LeftMessageWithOther.ToString();
            var noLongeronInsuracnePlan = ProspectCustomerTag.NoLongeronInsurancePlan.ToString();
            var debilitatingDisease = ProspectCustomerTag.DebilitatingDisease.ToString();

            string[] refusalTag = { homeVisitRequested, doNotContact, deceased, mobilityIssue, inLongTermCareNursingHome, mobilityIssue_LeftMessageWithOther, noLongeronInsuracnePlan, debilitatingDisease };
            return refusalTag;
        }

        public IEnumerable<GmsExcludedCustomerViewModel> GetGmsExcludedCallQueueCustomers(int pageNumber, int pageSize, OutboundCallQueueFilter filter, CallQueue callQueue, SuppressionFilterType suppressionType, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var startOfYear = new DateTime(DateTime.Now.Year, 1, 1);
                var notInterested = ProspectCustomerTag.NotInterested.ToString();
                var declinedMobileAndHomeVisit = ProspectCustomerTag.DeclinedMobileAndHomeVisit.ToString();
                var recentlySawDoc = ProspectCustomerTag.RecentlySawDoc.ToString();
                var transportationIssue = ProspectCustomerTag.TransportationIssue.ToString();
                var declinedMammoNotinterestedInMammogram = ProspectCustomerTag.DeclinedMammoNotinterestedInMammogram.ToString();
                var declinedMemberNotMammoAvailableNoEventsInArea = ProspectCustomerTag.DeclinedMemberNotMammoAvailableNoEventsInArea.ToString();

                var othersFilterDate = DateTime.Today.AddDays(-(filter.NumberOfDaysForOthers - 1));
                var leftVoiceMailDate = DateTime.Today.AddDays(-(filter.NumberOfDaysForLeftVoiceMail - 1));
                var refusalDate = DateTime.Today.AddDays(-(filter.NumberOfDaysForRefusedCustomer - 1));

                var linqMetaData = new LinqMetaData(adapter);

                var maxAttemptForQueue = filter.MaxAttempt > 0 ? filter.MaxAttempt : callQueue.Attempts;

                var query = (from cqcca in linqMetaData.VwCallQueueCustomerCriteraAssignmentForGmsStats
                             where cqcca.CallQueueId == callQueue.Id && cqcca.CriteriaId == filter.CriteriaId
                             && cqcca.HealthPlanId == filter.HealthPlanId
                             select cqcca);

                var zipIdsString = string.Empty;
                var customTags = string.Empty;

                var eventId = filter.EventId ?? 0;

                if (eventId > 0)
                {
                    var zipQuery = (from ez in linqMetaData.EventZip where ez.EventId == eventId select ez.ZipId);
                    query = (from q in query where zipQuery.Contains(q.ZipId) select q);
                }

                if (!string.IsNullOrEmpty(filter.ZipCode))
                {
                    if (filter.Radius > 0)
                    {
                        long zipCodeId = 0;
                        var zipCode = _zipCodeRepository.GetZipCode(filter.ZipCode).FirstOrDefault();
                        if (zipCode != null)
                            zipCodeId = zipCode.Id;

                        var zipRadiusDistance = (from zrd in linqMetaData.ZipRadiusDistance
                                                 where zrd.SourceZipId == zipCodeId && zrd.Radius <= filter.Radius
                                                 select zrd.DestinationZipId);

                        query = from a in query
                                where zipRadiusDistance.Contains(a.ZipId)
                                select a;
                    }
                    else
                    {
                        var zipCodes = _zipCodeRepository.GetZipCode(filter.ZipCode);
                        if (zipCodes != null && zipCodes.Any())
                        {
                            var zipIds = zipCodes.Select(z => z.Id).ToArray();
                            query = from q in query
                                    where zipIds.Contains(q.ZipId)
                                    select q;
                        }
                    }
                }

                if (!string.IsNullOrWhiteSpace(filter.CustomCorporateTag))
                {
                    customTags = CommaString + filter.CustomCorporateTag + CommaString;

                    var tagCustomers = (from ct in linqMetaData.VwGetCustomerTagForCallQueue where ct.IsActive && customTags.IndexOf(CommaString + ct.Tag + CommaString) >= 0 select ct.CustomerId);

                    query = (from q in query where tagCustomers.Contains(q.CustomerId) select q);
                }

                if (filter.DirectMailDate.HasValue)
                {
                    var mailedCustomerIds = (from dm in linqMetaData.VwGetDirectMailForCallQueue where dm.CampaignId == filter.CampaignId && dm.MailDate >= filter.DirectMailDate.Value && dm.MailDate < filter.DirectMailDate.Value.AddDays(1) select dm.CustomerId);

                    query = (from q in query where mailedCustomerIds.Contains(q.CustomerId) select q);
                }

                var eventZip = (from aez in linqMetaData.AccountEventZip where aez.AccountId == filter.HealthPlanId select aez.ZipId);
                var substituteZip = (from aezs in linqMetaData.AccountEventZipSubstitute where aezs.AccountId == filter.HealthPlanId select aezs.ZipId);
                var refusalTags = GetRefusalTag();

                IQueryable<VwCallQueueCustomerCriteraAssignmentForGmsStatsEntity> entities = null;

                if (suppressionType != SuppressionFilterType.MaxAttempt)
                {
                    if (filter.IsMaxAttemptPerHealthPlan)
                    {
                        query = (from q in query where q.CallCount < maxAttemptForQueue select q);
                    }
                    else
                    {
                        query = (from q in query where q.Attempts < maxAttemptForQueue select q);
                    }
                }

                switch (suppressionType)
                {
                    case SuppressionFilterType.MaxAttempt:
                        if (filter.IsMaxAttemptPerHealthPlan)
                        {
                            entities = (from q in query
                                        where q.CallCount >= maxAttemptForQueue
                                        select q);
                        }
                        else
                        {
                            entities = (from q in query
                                        where q.Attempts >= maxAttemptForQueue
                                        select q);
                        }
                        break;

                    case SuppressionFilterType.NotEligible:
                        entities = (from cqc in query
                                    where (cqc.IsEligble == false)
                                    select cqc);
                        break;

                    case SuppressionFilterType.NonTargeted:
                        entities = (from cqc in query
                                    where cqc.IsEligble == true
                                      && (cqc.TargetedYear != startOfYear.Year || cqc.IsTargeted == false)
                                    select cqc);
                        break;

                    case SuppressionFilterType.DoNotContact:
                        entities = (from cqc in query
                                    where cqc.IsEligble
                                        && (cqc.TargetedYear == startOfYear.Year && cqc.IsTargeted == true)
                                        && (cqc.DoNotContactTypeId == (long)DoNotContactType.DoNotContact || cqc.DoNotContactTypeId == (long)DoNotContactType.DoNotCall)
                                    select cqc);
                        break;

                    case SuppressionFilterType.DoNotCallActivity:
                        entities = (from cp in query
                                    where cp.IsEligble
                                        && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                        && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                        && (cp.ActivityId == (long)UploadActivityType.MailOnly || cp.ActivityId == (long)UploadActivityType.DoNotCallDoNotMail)
                                    select cp);
                        break;

                    case SuppressionFilterType.LanguageBarrier:
                        entities = (from cp in query
                                    where cp.IsEligble
                                        && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                        && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                        && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                        && (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear)
                                    select cp);
                        break;

                    case SuppressionFilterType.IncorrectPhone:
                        entities = (from cp in query
                                    where cp.IsEligble
                                        && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                        && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                        && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                        && (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate >= startOfYear)
                                        && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                    select cp);
                        break;

                    case SuppressionFilterType.NoPhone:
                        entities = (from cp in query
                                    where cp.IsEligble
                                        && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                        && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                        && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                        && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                        && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                        && ((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))

                                    select cp);
                        break;

                    case SuppressionFilterType.AppointmentBooked:
                        entities = (from cp in query
                                    where cp.IsEligble == true
                                        && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                        && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                        && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                        && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                        && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                        && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
                                        && (cp.AppointmentDate >= startOfYear)
                                    select cp);
                        break;

                    case SuppressionFilterType.Deceased:
                        entities = (from cp in query
                                    where cp.IsEligble
                                        && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                        && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                        && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                        && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                        && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                        && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
                                        && (cp.AppointmentDate <= startOfYear)
                                        && (cp.Disposition == ProspectCustomerTag.Deceased.ToString())
                                    select cp);
                        break;

                    case SuppressionFilterType.HomeVisitRequested:
                        entities = (from cp in query
                                    where cp.IsEligble
                                        && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                        && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                        && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                        && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                        && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                        && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
                                        && (cp.AppointmentDate <= startOfYear)
                                        && (cp.ContactedDate >= startOfYear && cp.Disposition == ProspectCustomerTag.HomeVisitRequested.ToString())
                                    select cp);
                        break;

                    case SuppressionFilterType.MobilityIssue:
                        entities = (from cp in query
                                    where cp.IsEligble
                                        && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                        && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                        && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                        && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                        && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                        && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
                                        && (cp.AppointmentDate <= startOfYear)
                                        && (cp.ContactedDate >= startOfYear && cp.Disposition == ProspectCustomerTag.MobilityIssue.ToString())
                                    select cp);
                        break;

                    case SuppressionFilterType.InLongTermCareNursingHome:
                        entities = (from cp in query
                                    where cp.IsEligble
                                        && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                        && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                        && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                        && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                        && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                        && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
                                        && (cp.AppointmentDate <= startOfYear)
                                        && (cp.ContactedDate >= startOfYear && cp.Disposition == ProspectCustomerTag.InLongTermCareNursingHome.ToString())
                                    select cp);
                        break;

                    case SuppressionFilterType.MobilityIssues_LeftMessageWithOther:
                        entities = (from cp in query
                                    where cp.IsEligble
                                        && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                        && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                        && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                        && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                        && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                        && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
                                        && (cp.AppointmentDate <= startOfYear)
                                        && (cp.ContactedDate >= startOfYear && cp.Disposition == ProspectCustomerTag.MobilityIssues_LeftMessageWithOther.ToString())
                                    select cp);
                        break;

                    case SuppressionFilterType.NoLongeronInsurancePlan:
                        entities = (from cp in query
                                    where cp.IsEligble
                                        && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                        && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                        && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                        && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                        && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                        && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
                                        && (cp.AppointmentDate <= startOfYear)
                                        && (cp.ContactedDate >= startOfYear && cp.Disposition == ProspectCustomerTag.NoLongeronInsurancePlan.ToString())
                                    select cp);
                        break;

                    case SuppressionFilterType.DebilitatingDisease:
                        entities = (from cp in query
                                    where cp.IsEligble
                                        && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                        && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                        && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                        && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                        && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                        && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
                                        && (cp.AppointmentDate <= startOfYear)
                                        && (cp.ContactedDate >= startOfYear && cp.Disposition == ProspectCustomerTag.DebilitatingDisease.ToString())
                                    select cp);
                        break;


                    case SuppressionFilterType.CallBackLater:
                        entities = (from cp in query
                                    where cp.IsEligble == true
                                        && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                        && (cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail || cp.DoNotContactTypeId == 0)
                                        && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                        && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
                                        && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                        && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                        && (cp.AppointmentDate <= startOfYear)
                                        && cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now
                                    select cp);
                        break;

                    case SuppressionFilterType.NoEventsInArea:
                        entities = (from cp in query
                                    where cp.IsEligble == true
                                        && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                        && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                        && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                        && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                        && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                        && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                        && (cp.AppointmentDate <= startOfYear)
                                        && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                        && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                        && !(eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                    select cp);
                        break;



                    case SuppressionFilterType.LeftVoiceMessage:
                        entities = (from cp in query
                                    where cp.IsEligble == true
                                        && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                        && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                        && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                        && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                        && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                        && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                        && (cp.AppointmentDate <= startOfYear)
                                        && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                        && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                        && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                        && (cp.ContactedDate >= leftVoiceMailDate && cp.CallStatus == (long)CallStatus.VoiceMessage)
                                    select cp);
                        break;

                    case SuppressionFilterType.NotInterested:
                        entities = (from cp in query
                                    where cp.IsEligble == true
                                        && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                        && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                        && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                        && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                        && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                        && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                        && (cp.AppointmentDate <= startOfYear)
                                        && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                        && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                        && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                        && (cp.ContactedDate >= refusalDate && (cp.CallStatus != (long)CallStatus.CallSkipped && cp.CallStatus != (long)CallStatus.VoiceMessage) && (cp.Disposition == notInterested || cp.Disposition == declinedMobileAndHomeVisit))
                                    select cp);
                        break;

                    case SuppressionFilterType.RecentlySawDoc:
                        entities = (from cp in query
                                    where cp.IsEligble == true
                                        && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                        && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                        && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                        && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                        && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                        && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                        && (cp.AppointmentDate <= startOfYear)
                                        && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                        && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                        && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                        && (cp.ContactedDate >= refusalDate && (cp.CallStatus != (long)CallStatus.CallSkipped && cp.CallStatus != (long)CallStatus.VoiceMessage) && (cp.Disposition == recentlySawDoc))
                                    select cp);
                        break;

                    case SuppressionFilterType.TransportationIssue:
                        entities = (from cp in query
                                    where cp.IsEligble == true
                                        && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                        && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                        && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                        && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                        && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                        && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                        && (cp.AppointmentDate <= startOfYear)
                                        && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                        && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                        && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                        && (cp.ContactedDate >= refusalDate && (cp.CallStatus != (long)CallStatus.CallSkipped && cp.CallStatus != (long)CallStatus.VoiceMessage) && (cp.Disposition == transportationIssue))
                                    select cp);
                        break;

                    case SuppressionFilterType.AppointmentCancelledDate:
                        entities = (from cp in query
                                    where cp.IsEligble == true
                                        && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                        && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                        && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                        && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                        && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                        && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                        && (cp.AppointmentDate <= startOfYear)
                                                  && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                                  && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                                  && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                                  && cp.AppointmentCancellationDate >= leftVoiceMailDate
                                    select cp);
                        break;

                    case SuppressionFilterType.NoShowMarkDate:
                        entities = (from cp in query
                                    where cp.IsEligble == true
                                        && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                        && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                        && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                        && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                        && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                        && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                        && (cp.AppointmentDate <= startOfYear)
                                                  && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                                  && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                                  && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                                  && cp.NoShowDate >= leftVoiceMailDate
                                    select cp);
                        break;

                    case SuppressionFilterType.CallSkipped:
                        entities = (from cp in query
                                    where cp.IsEligble == true
                                        && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                        && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                        && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                        && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                        && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                        && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                        && (cp.AppointmentDate <= startOfYear)
                                        && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                        && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                        && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                        && (cp.ContactedDate >= DateTime.Today && (cp.CallStatus == (long)CallStatus.CallSkipped))
                                    select cp);
                        break;

                    case SuppressionFilterType.CallInitiated:
                        entities = (from cp in query
                                    where cp.IsEligble == true
                                        && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                        && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                        && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                        && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                        && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                        && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                        && (cp.AppointmentDate <= startOfYear)
                                        && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                        && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                        && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                        && (cp.ContactedDate >= DateTime.Today && (cp.CallStatus == (long)CallStatus.Initiated))
                                    select cp);
                        break;

                    case SuppressionFilterType.MovedRelocated:
                        entities = (from cp in query
                                    where cp.IsEligble == true
                                        && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                        && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                        && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                        && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                        && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                        && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                        && (cp.AppointmentDate <= startOfYear)
                                        && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                        && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                        && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                        && (cp.ContactedDate >= othersFilterDate && cp.CallStatus != (long)CallStatus.CallSkipped && (cp.Disposition != ProspectCustomerTag.CallBackLater.ToString()
                                        && cp.Disposition != ProspectCustomerTag.LanguageBarrier.ToString()) && (cp.Disposition == ProspectCustomerTag.MovedRelocated.ToString()))
                                    select cp);
                        break;

                    case SuppressionFilterType.WillSpeakWithPhysician:
                        entities = (from cp in query
                                    where cp.IsEligble == true
                                        && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                        && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                        && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                        && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                        && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                        && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                        && (cp.AppointmentDate <= startOfYear)
                                        && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                        && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                        && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                        && (cp.ContactedDate >= othersFilterDate && cp.CallStatus != (long)CallStatus.CallSkipped && (cp.Disposition != ProspectCustomerTag.CallBackLater.ToString()
                                        && cp.Disposition != ProspectCustomerTag.LanguageBarrier.ToString()) && (cp.Disposition == ProspectCustomerTag.SpeakWithPhysician.ToString()))
                                    select cp);
                        break;

                    case SuppressionFilterType.DateTimeConflict:
                        entities = (from cp in query
                                    where cp.IsEligble == true
                                        && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                        && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                        && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                        && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                        && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                        && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                        && (cp.AppointmentDate <= startOfYear)
                                                  && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                                  && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                                  && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                                  && (cp.ContactedDate >= leftVoiceMailDate && cp.CallStatus != (long)CallStatus.CallSkipped && (cp.Disposition != ProspectCustomerTag.CallBackLater.ToString()
                                                  && cp.Disposition != ProspectCustomerTag.LanguageBarrier.ToString()) && (cp.Disposition == ProspectCustomerTag.DateTimeConflict.ToString()))
                                    select cp);
                        break;

                    case SuppressionFilterType.NoAnswer:
                        entities = (from cp in query
                                    where cp.IsEligble == true
                                        && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                        && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                        && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                        && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                        && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                        && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                        && (cp.AppointmentDate <= startOfYear)
                                                  && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                                  && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                                  && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                                  && (cp.ContactedDate >= leftVoiceMailDate && (cp.CallStatus == (long)CallStatus.NoAnswer))
                                    select cp);
                        break;

                    case SuppressionFilterType.NoEventsInAreaCallStatus:
                        entities = (from cp in query
                                    where cp.IsEligble == true
                                        && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                        && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                        && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                        && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                        && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                        && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                        && (cp.AppointmentDate <= startOfYear)
                                        && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                        && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                        && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                        && (cp.ContactedDate >= othersFilterDate && (cp.CallStatus == (long)CallStatus.NoEventsInArea))
                                    select cp);
                        break;

                    case SuppressionFilterType.LeftMessageWithOthers:
                        entities = (from cp in query
                                    where cp.IsEligble == true
                                        && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                        && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                        && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                        && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                        && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                        && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                        && (cp.AppointmentDate <= startOfYear)
                                                  && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                                  && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                                  && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                                  && (cp.ContactedDate >= leftVoiceMailDate && (cp.CallStatus == (long)CallStatus.LeftMessageWithOther))
                                    select cp);
                        break;

                    case SuppressionFilterType.InvalidNumber:
                        entities = (from cp in query
                                    where cp.IsEligble == true
                                        && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                        && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                        && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                        && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                        && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                        && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                        && (cp.AppointmentDate <= startOfYear)
                                        && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                        && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                        && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                        && (cp.ContactedDate >= othersFilterDate && (cp.CallStatus == (long)CallStatus.InvalidNumber))
                                    select cp);
                        break;

                    case SuppressionFilterType.DeclinedMemberNotMammoAvailableNoEventsInArea:
                        entities = (from cp in query
                                    where cp.IsEligble == true
                                        && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                        && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                        && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                        && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                        && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                        && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                        && (cp.AppointmentDate <= startOfYear)
                                        && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                        && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                        && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                        && (cp.ContactedDate >= refusalDate && (cp.CallStatus != (long)CallStatus.CallSkipped && cp.CallStatus != (long)CallStatus.VoiceMessage) && (cp.Disposition == declinedMemberNotMammoAvailableNoEventsInArea))
                                    select cp);
                        break;

                    case SuppressionFilterType.DeclinedMammoNotinterestedInMammogram:
                        entities = (from cp in query
                                    where cp.IsEligble == true
                                        && (cp.TargetedYear == startOfYear.Year && cp.IsTargeted == true)
                                        && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                        && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                        && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                        && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                        && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                        && (cp.AppointmentDate <= startOfYear)
                                        && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                        && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                        && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                        && (cp.ContactedDate >= refusalDate && (cp.CallStatus != (long)CallStatus.CallSkipped && cp.CallStatus != (long)CallStatus.VoiceMessage) && (cp.Disposition == declinedMammoNotinterestedInMammogram))
                                    select cp);
                        break;
                }


                if (entities == null)
                {
                    totalRecords = 0;
                    return new List<GmsExcludedCustomerViewModel>();
                }

                totalRecords = entities.Count();

                var pagedEntities = entities.OrderBy(x => x.CustomerId).TakePage(pageNumber, pageSize).ToArray();

                return pagedEntities.Select(x => new GmsExcludedCustomerViewModel
                {
                    CustomerId = x.CustomerId,
                    Name = new Name(x.FirstName, x.MiddleName, x.LastName),
                    ZipCode = x.ZipCode,
                    Reason = suppressionType == SuppressionFilterType.NotInterested ? EnumExtensions.GetDescription((ProspectCustomerTag)Enum.Parse(typeof(ProspectCustomerTag), x.Disposition)) : EnumExtension.GetDescription(suppressionType)
                });
            }
        }
    }
}
