using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.CallQueues.Repositories
{
    [DefaultImplementation]
    public class ExcludedCustomerRepository : PersistenceRepository, IExcludedCustomerRepository
    {
        private readonly IZipCodeRepository _zipCodeRepository;
        private const string CommaString = ",";

        public ExcludedCustomerRepository(IZipCodeRepository zipCodeRepository)
        {
            _zipCodeRepository = zipCodeRepository;
        }

        public CallQueueCustomersStatsViewModel GetExcludedCustomers(OutboundCallQueueFilter filter, CallQueue callQueue)
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

                var query = (from cqcca in linqMetaData.VwCallQueueCustomerCriteraAssignmentForStats
                             where cqcca.CallQueueId == filter.CallQueueId && cqcca.CriteriaId == filter.CriteriaId
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

                    if (filter.UseCustomTagExclusively)
                    {
                        var customersWithSingleTag = (from cwst in linqMetaData.VwGetCustomerIdsHavingSingleTagForCallQueue select cwst.CustomerId);

                        tagCustomers = (from ct in linqMetaData.VwGetCustomerTagForCallQueue where ct.IsActive && customTags.IndexOf(CommaString + ct.Tag + CommaString) >= 0 && customersWithSingleTag.Contains(ct.CustomerId) select ct.CustomerId);
                    }

                    query = (from q in query where tagCustomers.Contains(q.CustomerId) select q);
                }

                if (filter.DirectMailDate.HasValue)
                {
                    var mailedCustomerIds = (from dm in linqMetaData.VwGetDirectMailForCallQueue where dm.CampaignId == filter.CampaignId && dm.MailDate >= filter.DirectMailDate.Value && dm.MailDate < filter.DirectMailDate.Value.AddDays(1) select dm.CustomerId);

                    query = (from q in query where mailedCustomerIds.Contains(q.CustomerId) select q);
                }

                var expectedCustomers = query.Count();
                var showLanguageBarrierCount = callQueue.Category == HealthPlanCallQueueCategory.LanguageBarrier;

                var maxAttempt = 0;
                var notEligibleCount = 0;
                var doNotContactCount = 0;
                var uploadActivityCount = 0;
                var languageBarrierCount = 0;
                var incorrectPhoneCount = 0;
                var noPhoneCount = 0;
                var appointmentBookedCount = 0;
                var deceasedCount = 0;
                var homeVisitRequestedCount = 0;
                var mobilityIssueCount = 0;
                var inLongTermCareNursingHomeCount = 0;
                var mobilityIssuesLeftMessageWithOtherCount = 0;
                var noLongeronInsurancePlanCount = 0;
                var debilitatingDiseaseCount = 0;
                var callBackForFutureDateCount = 0;
                var customerNoEventsInAreaCount = 0;
                var leftVoiceMessageCount = 0;
                var notInterestedCount = 0;
                var recentlySawDocCount = 0;
                var transportationIssueCount = 0;
                var appointmentCancelledDateCount = 0;
                var noShowMarkDateCount = 0;
                var callSkippedCount = 0;
                var callInitiatedCount = 0;
                var movedRelocatedCount = 0;
                var willSpeakWithPhysicianCount = 0;
                var dateTimeConflictCount = 0;
                var noAnswerCount = 0;
                var noEventsInAreaCallStatusCount = 0;
                var leftMessageWithOthersCount = 0;
                var invalidNumberCount = 0;
                var notinterestedInMammogramCount = 0;
                var memberNotMammoAvailableNoEventsInAreaCount = 0;
                var nonTargetedCount = 0;


                if (filter.IsMaxAttemptPerHealthPlan)
                {
                    maxAttempt = (from q in query
                                  where q.CallCount >= maxAttemptForQueue
                                  select q.CustomerId).Distinct().Count();

                    query = (from q in query where q.CallCount < maxAttemptForQueue select q);
                }
                else
                {
                    maxAttempt = (from q in query
                                  where q.Attempts >= maxAttemptForQueue
                                  select q.CustomerId).Distinct().Count();

                    query = (from q in query where q.Attempts < maxAttemptForQueue select q);
                }

                notEligibleCount = (from cqc in query
                                    where (cqc.IsEligble == false)
                                    select cqc.CustomerId).Distinct().Count();

                nonTargetedCount = (from cqc in query
                                    where cqc.IsEligble == true
                                       && (cqc.TargetedYear != startOfYear.Year || cqc.IsTargeted == false)
                                    select cqc.CustomerId).Distinct().Count();

                query = (from cqc in query
                         where (cqc.TargetedYear == startOfYear.Year && cqc.IsTargeted == true)
                         select cqc);

                //doNotContactCount = (from cqc in query
                //                     where cqc.IsEligble
                //                           && ((cqc.DoNotContactUpdateDate > startOfYear
                //                                && (cqc.DoNotContactTypeId == (long)DoNotContactType.DoNotContact || cqc.DoNotContactTypeId == (long)DoNotContactType.DoNotCall))
                //                               || (cqc.DoNotContactUpdateSource == (long)DoNotContactSource.Manual && cqc.DoNotContactTypeId != (long)DoNotContactType.DoNotMail))
                //                     select cqc.CustomerId).Distinct().Count();

                doNotContactCount = (from cqc in query
                                     where cqc.IsEligble
                                           && (cqc.DoNotContactTypeId == (long)DoNotContactType.DoNotContact || cqc.DoNotContactTypeId == (long)DoNotContactType.DoNotCall)
                                     select cqc.CustomerId).Distinct().Count();

                uploadActivityCount = (from cp in query
                                       where cp.IsEligble && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail) //(cp.DoNotContactUpdateDate < startOfYear && cp.DoNotContactUpdateSource != (long)DoNotContactSource.Manual) || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                             && (cp.ActivityId == (long)UploadActivityType.MailOnly || cp.ActivityId == (long)UploadActivityType.DoNotCallDoNotMail)
                                       select cp.CustomerId).Distinct().Count();
                var eventZip = (from aez in linqMetaData.AccountEventZip where aez.AccountId == filter.HealthPlanId select aez.ZipId);
                var substituteZip = (from aezs in linqMetaData.AccountEventZipSubstitute where aezs.AccountId == filter.HealthPlanId select aezs.ZipId);

                var productZip = (from q in query
                                  join cp in linqMetaData.CustomerProfile on q.CustomerId equals cp.CustomerId
                                  join pz in linqMetaData.EventZipProductType on cp.ProductTypeId equals pz.ProductTypeId
                                  join zrd in linqMetaData.ZipRadiusDistance on pz.ZipId equals zrd.SourceZipId
                                  where zrd.Radius <= 60
                                  select zrd.DestinationZipId);

                var refusalTags = GetRefusalTag();

                if (!showLanguageBarrierCount)
                {
                    languageBarrierCount = (from cp in query
                                            where cp.IsEligble
                                                  && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                                  && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                                  && (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear)
                                            select cp.CustomerId).Distinct().Count();

                    incorrectPhoneCount = (from cp in query
                                           where cp.IsEligble
                                                 && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)

                                                 && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                                 && (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate >= startOfYear)
                                                 && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                           select cp.CustomerId).Distinct().Count();

                    noPhoneCount = (from cp in query
                                    where cp.IsEligble
                                          && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                          && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                          && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                          && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                          && ((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))

                                    select cp.CustomerId).Distinct().Count();

                    appointmentBookedCount = (from cp in query
                                              where cp.IsEligble == true
                                                    && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                                    && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                                    && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                                    && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                                    && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
                                                    && (cp.AppointmentDate >= startOfYear)
                                              select cp.CustomerId).Distinct().Count();

                    deceasedCount = (from cp in query
                                     where cp.IsEligble
                                           && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                           && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                           && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                           && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                           && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
                                           && (cp.AppointmentDate <= startOfYear)
                                           && (cp.Disposition == ProspectCustomerTag.Deceased.ToString())
                                     select cp.CustomerId).Distinct().Count();


                    homeVisitRequestedCount = (from cp in query
                                               where cp.IsEligble
                                                     && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                                     && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                                     && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                                     && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                                     && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
                                                     && (cp.AppointmentDate <= startOfYear)
                                                     && (cp.ContactedDate >= startOfYear && cp.Disposition == ProspectCustomerTag.HomeVisitRequested.ToString())
                                               select cp.CustomerId).Distinct().Count();


                    mobilityIssueCount = (from cp in query
                                          where cp.IsEligble
                                                && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                                && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                                && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                                && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                                && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
                                                && (cp.AppointmentDate <= startOfYear)
                                                && (cp.ContactedDate >= startOfYear && cp.Disposition == ProspectCustomerTag.MobilityIssue.ToString())
                                          select cp.CustomerId).Distinct().Count();

                    inLongTermCareNursingHomeCount = (from cp in query
                                                      where cp.IsEligble
                                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                                            && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                                            && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
                                                            && (cp.AppointmentDate <= startOfYear)
                                                            && (cp.ContactedDate >= startOfYear && cp.Disposition == ProspectCustomerTag.InLongTermCareNursingHome.ToString())
                                                      select cp.CustomerId).Distinct().Count();

                    mobilityIssuesLeftMessageWithOtherCount = (from cp in query
                                                               where cp.IsEligble
                                                                     && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                                                     && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                                                     && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                                                     && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                                                     && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
                                                                     && (cp.AppointmentDate <= startOfYear)
                                                                     && (cp.ContactedDate >= startOfYear && cp.Disposition == ProspectCustomerTag.MobilityIssues_LeftMessageWithOther.ToString())
                                                               select cp.CustomerId).Distinct().Count();

                    noLongeronInsurancePlanCount = (from cp in query
                                                    where cp.IsEligble
                                                          && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                                          && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                                          && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                                          && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                                          && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
                                                          && (cp.AppointmentDate <= startOfYear)
                                                          && (cp.ContactedDate >= startOfYear && cp.Disposition == ProspectCustomerTag.NoLongeronInsurancePlan.ToString())
                                                    select cp.CustomerId).Distinct().Count();

                    debilitatingDiseaseCount = (from cp in query
                                                where cp.IsEligble
                                                      && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                                      && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                                      && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                                      && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                                      && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
                                                      && (cp.AppointmentDate <= startOfYear)
                                                      && (cp.ContactedDate >= startOfYear && cp.Disposition == ProspectCustomerTag.DebilitatingDisease.ToString())
                                                select cp.CustomerId).Distinct().Count();



                    callBackForFutureDateCount = (from cp in query
                                                  where cp.IsEligble == true
                                                        && (cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail || cp.DoNotContactTypeId == 0)
                                                        && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                                        && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
                                                        && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                                        && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                                        && (cp.AppointmentDate <= startOfYear)
                                                        && cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now
                                                  select cp.CustomerId).Distinct().Count();

                    customerNoEventsInAreaCount = (from cp in query
                                                   where cp.IsEligble == true
                                                         && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                                         && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                                         && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                                         && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                                         && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                                         && (cp.AppointmentDate <= startOfYear)
                                                         && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                                         && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                                       && !(eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId) || (productZip.Contains(cp.ZipId)))

                                                   select cp.CustomerId).Distinct().Count();

                    leftVoiceMessageCount = (from cp in query
                                             where cp.IsEligble == true
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
                                             select cp.CustomerId).Distinct().Count();

                    notInterestedCount = (from cp in query
                                          where cp.IsEligble == true
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
                                          select cp.CustomerId).Distinct().Count();
                    recentlySawDocCount = (from cp in query
                                           where cp.IsEligble == true
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
                                           select cp.CustomerId).Distinct().Count();

                    transportationIssueCount = (from cp in query
                                                where cp.IsEligble == true
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
                                                select cp.CustomerId).Distinct().Count();
                    appointmentCancelledDateCount = (from cp in query
                                                     where cp.IsEligble == true
                                                           && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                                           && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                                           && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                                           && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                                           && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                                           && (cp.AppointmentDate <= startOfYear)
                                                           && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                                           && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                                           && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                                           && cp.AppointmentCancellationDate >= othersFilterDate
                                                     select cp.CustomerId).Distinct().Count();
                    noShowMarkDateCount = (from cp in query
                                           where cp.IsEligble == true
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
                                           select cp.CustomerId).Distinct().Count();
                    callSkippedCount = (from cp in query
                                        where cp.IsEligble == true
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
                                        select cp.CustomerId).Distinct().Count();

                    callInitiatedCount = (from cp in query
                                          where cp.IsEligble == true
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
                                          select cp.CustomerId).Distinct().Count();

                    movedRelocatedCount = (from cp in query
                                           where cp.IsEligble == true
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
                                           select cp.CustomerId).Distinct().Count();

                    willSpeakWithPhysicianCount = (from cp in query
                                                   where cp.IsEligble == true
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
                                                   select cp.CustomerId).Distinct().Count();
                    dateTimeConflictCount = (from cp in query
                                             where cp.IsEligble == true
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
                                             select cp.CustomerId).Distinct().Count();

                    noAnswerCount = (from cp in query
                                     where cp.IsEligble == true
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
                                     select cp.CustomerId).Distinct().Count();

                    noEventsInAreaCallStatusCount = (from cp in query
                                                     where cp.IsEligble == true
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
                                                     select cp.CustomerId).Distinct().Count();

                    leftMessageWithOthersCount = (from cp in query
                                                  where cp.IsEligble == true
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
                                                  select cp.CustomerId).Distinct().Count();

                    invalidNumberCount = (from cp in query
                                          where cp.IsEligble == true
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
                                          select cp.CustomerId).Distinct().Count();

                    notinterestedInMammogramCount = (from cp in query
                                                     where cp.IsEligble == true
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
                                                     select cp.CustomerId).Distinct().Count();

                    memberNotMammoAvailableNoEventsInAreaCount = (from cp in query
                                                                  where cp.IsEligble == true
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
                                                                  select cp.CustomerId).Distinct().Count();

                }
                else
                {
                    incorrectPhoneCount = (from cp in query
                                           where cp.IsEligble
                                                 && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)

                                                 && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                                 && (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate >= startOfYear)
                                                 && ((cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear))
                                           select cp.CustomerId).Distinct().Count();

                    noPhoneCount = (from cp in query
                                    where cp.IsEligble
                                          && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                          && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                          && ((cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear))
                                          && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                          && ((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))

                                    select cp.CustomerId).Distinct().Count();

                    appointmentBookedCount = (from cp in query
                                              where cp.IsEligble == true
                                                    && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                                    && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                                    && ((cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear))
                                                    && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                                    && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
                                                    && (cp.AppointmentDate >= startOfYear)
                                              select cp.CustomerId).Distinct().Count();

                    deceasedCount = (from cp in query
                                     where cp.IsEligble
                                           && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                           && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                           && ((cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear))
                                           && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                           && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
                                           && (cp.AppointmentDate <= startOfYear)
                                           && (cp.Disposition == ProspectCustomerTag.Deceased.ToString())
                                     select cp.CustomerId).Distinct().Count();


                    homeVisitRequestedCount = (from cp in query
                                               where cp.IsEligble
                                                     && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                                     && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                                     && ((cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear))
                                                     && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                                     && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
                                                     && (cp.AppointmentDate <= startOfYear)
                                                     && (cp.ContactedDate >= startOfYear && cp.Disposition == ProspectCustomerTag.HomeVisitRequested.ToString())
                                               select cp.CustomerId).Distinct().Count();


                    mobilityIssueCount = (from cp in query
                                          where cp.IsEligble
                                                && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                                && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                                && ((cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear))
                                                && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                                && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
                                                && (cp.AppointmentDate <= startOfYear)
                                                && (cp.ContactedDate >= startOfYear && cp.Disposition == ProspectCustomerTag.MobilityIssue.ToString())
                                          select cp.CustomerId).Distinct().Count();

                    inLongTermCareNursingHomeCount = (from cp in query
                                                      where cp.IsEligble
                                                            && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                                            && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                                            && ((cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear))
                                                            && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                                            && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
                                                            && (cp.AppointmentDate <= startOfYear)
                                                            && (cp.ContactedDate >= startOfYear && cp.Disposition == ProspectCustomerTag.InLongTermCareNursingHome.ToString())
                                                      select cp.CustomerId).Distinct().Count();

                    mobilityIssuesLeftMessageWithOtherCount = (from cp in query
                                                               where cp.IsEligble
                                                                     && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                                                     && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                                                     && ((cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear))
                                                                     && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                                                     && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
                                                                     && (cp.AppointmentDate <= startOfYear)
                                                                     && (cp.ContactedDate >= startOfYear && cp.Disposition == ProspectCustomerTag.MobilityIssues_LeftMessageWithOther.ToString())
                                                               select cp.CustomerId).Distinct().Count();

                    noLongeronInsurancePlanCount = (from cp in query
                                                    where cp.IsEligble
                                                          && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                                          && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                                          && ((cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear))
                                                          && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                                          && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
                                                          && (cp.AppointmentDate <= startOfYear)
                                                          && (cp.ContactedDate >= startOfYear && cp.Disposition == ProspectCustomerTag.NoLongeronInsurancePlan.ToString())
                                                    select cp.CustomerId).Distinct().Count();

                    debilitatingDiseaseCount = (from cp in query
                                                where cp.IsEligble
                                                      && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                                      && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                                      && ((cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear))
                                                      && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                                      && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
                                                      && (cp.AppointmentDate <= startOfYear)
                                                      && (cp.ContactedDate >= startOfYear && cp.Disposition == ProspectCustomerTag.DebilitatingDisease.ToString())
                                                select cp.CustomerId).Distinct().Count();

                    callBackForFutureDateCount = (from cp in query
                                                  where cp.IsEligble == true
                                                        && (cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail || cp.DoNotContactTypeId == 0)
                                                        && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                                        && ((cp.PhoneCell != "") || (cp.PhoneHome != "") || (cp.PhoneOffice != ""))
                                                        && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                                        && ((cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear))
                                                        && (cp.AppointmentDate <= startOfYear)
                                                        && cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now
                                                  select cp.CustomerId).Distinct().Count();

                    customerNoEventsInAreaCount = (from cp in query
                                                   where cp.IsEligble == true
                                                         && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                                         && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                                         && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                                         && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                                         && ((cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear))
                                                         && (cp.AppointmentDate <= startOfYear)
                                                         && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                                         && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                                          && !(eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId) || (productZip.Contains(cp.ZipId)))
                                                   select cp.CustomerId).Distinct().Count();

                    leftVoiceMessageCount = (from cp in query
                                             where cp.IsEligble == true
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
                                             select cp.CustomerId).Distinct().Count();

                    notInterestedCount = (from cp in query
                                          where cp.IsEligble == true
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
                                          select cp.CustomerId).Distinct().Count();
                    recentlySawDocCount = (from cp in query
                                           where cp.IsEligble == true
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
                                           select cp.CustomerId).Distinct().Count();

                    transportationIssueCount = (from cp in query
                                                where cp.IsEligble == true
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
                                                select cp.CustomerId).Distinct().Count();
                    appointmentCancelledDateCount = (from cp in query
                                                     where cp.IsEligble == true
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
                                                     select cp.CustomerId).Distinct().Count();

                    noShowMarkDateCount = (from cp in query
                                           where cp.IsEligble == true
                                                 && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                                 && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                                 && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                                 && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                                 && (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear)
                                                 && (cp.AppointmentDate <= startOfYear)
                                                 && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                                 && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                                 && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId))
                                                 && cp.NoShowDate >= leftVoiceMailDate
                                           select cp.CustomerId).Distinct().Count();

                    callSkippedCount = (from cp in query
                                        where cp.IsEligble == true
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
                                        select cp.CustomerId).Distinct().Count();

                    callInitiatedCount = (from cp in query
                                          where cp.IsEligble == true
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
                                          select cp.CustomerId).Distinct().Count();

                    movedRelocatedCount = (from cp in query
                                           where cp.IsEligble == true
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
                                           select cp.CustomerId).Distinct().Count();

                    willSpeakWithPhysicianCount = (from cp in query
                                                   where cp.IsEligble == true
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
                                                   select cp.CustomerId).Distinct().Count();
                    dateTimeConflictCount = (from cp in query
                                             where cp.IsEligble == true
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
                                             select cp.CustomerId).Distinct().Count();

                    noAnswerCount = (from cp in query
                                     where cp.IsEligble == true
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
                                     select cp.CustomerId).Distinct().Count();

                    noEventsInAreaCallStatusCount = (from cp in query
                                                     where cp.IsEligble == true
                                                           && (cp.DoNotContactTypeId == 0 || cp.DoNotContactTypeId == (long)DoNotContactType.DoNotMail)
                                                           && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall)
                                                           && !((cp.PhoneCell == "") && (cp.PhoneHome == "") && (cp.PhoneOffice == ""))
                                                           && (!cp.IsIncorrectPhoneNumber || (cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate < startOfYear))
                                                           && ((cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear))
                                                           && (cp.AppointmentDate <= startOfYear)
                                                           && !(cp.Disposition == ProspectCustomerTag.Deceased.ToString() || (cp.ContactedDate >= startOfYear && refusalTags.Contains(cp.Disposition)))
                                                           && !(cp.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cp.CallBackRequestedDate > DateTime.Now)
                                                           && (eventZip.Contains(cp.ZipId) || substituteZip.Contains(cp.ZipId) || (productZip.Contains(cp.ZipId)))
                                                           && (cp.ContactedDate >= othersFilterDate && (cp.CallStatus == (long)CallStatus.NoEventsInArea))
                                                           && (productZip.Contains(cp.ZipId))
                                                     select cp.CustomerId).Distinct().Count();

                    leftMessageWithOthersCount = (from cp in query
                                                  where cp.IsEligble == true
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
                                                  select cp.CustomerId).Distinct().Count();

                    invalidNumberCount = (from cp in query
                                          where cp.IsEligble == true
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
                                          select cp.CustomerId).Distinct().Count();

                    notinterestedInMammogramCount = (from cp in query
                                                     where cp.IsEligble == true
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
                                                     select cp.CustomerId).Distinct().Count();

                    memberNotMammoAvailableNoEventsInAreaCount = (from cp in query
                                                                  where cp.IsEligble == true
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
                                                                  select cp.CustomerId).Distinct().Count();

                }

                return new CallQueueCustomersStatsViewModel
                {
                    TotalCustomerInCallQueue = expectedCustomers,
                    MaxAttempt = maxAttempt,
                    NotEligible = notEligibleCount,
                    AppointmentBooked = appointmentBookedCount,
                    DoNotContact = doNotContactCount,
                    Activity = uploadActivityCount,
                    IncorrectPhone = incorrectPhoneCount,
                    NoPhone = noPhoneCount,
                    Deceased = deceasedCount,
                    HomeVisitRequested = homeVisitRequestedCount,
                    MobilityIssue = mobilityIssueCount,
                    InLongTermCareNursingHome = inLongTermCareNursingHomeCount,
                    MobilityIssuesLeftMessageWithOther = mobilityIssuesLeftMessageWithOtherCount,
                    NoLongeronInsurancePlan = noLongeronInsurancePlanCount,
                    DebilitatingDisease = debilitatingDiseaseCount,
                    CallBackLater = callBackForFutureDateCount,
                    NoEventsInArea = customerNoEventsInAreaCount,
                    LeftVoiceMessage = leftVoiceMessageCount,
                    NotInterested = notInterestedCount,
                    RecentlySawDoc = recentlySawDocCount,
                    TransportationIssue = transportationIssueCount,
                    AppointmentCancelledDate = appointmentCancelledDateCount,
                    CallSkipped = callSkippedCount,
                    CallInitiated = callInitiatedCount,
                    MovedRelocated = movedRelocatedCount,
                    WillSpeakWithPhysician = willSpeakWithPhysicianCount,
                    DateTimeConflict = dateTimeConflictCount,
                    NoAnswer = noAnswerCount,
                    NoEventsInAreaCallStatus = noEventsInAreaCallStatusCount,
                    LeftMessageWithOthers = leftMessageWithOthersCount,
                    LanguageBarrier = languageBarrierCount,
                    NoShowCustomers = noShowMarkDateCount,
                    InvalidNumbers = invalidNumberCount,
                    NotinterestedInMammogramCount = notinterestedInMammogramCount,
                    MemberNotMammoAvailableNoEventsInAreaCount = memberNotMammoAvailableNoEventsInAreaCount,
                    NonTargetedCount = nonTargetedCount
                };
            }
        }

        private IEnumerable<string> GetRefusalTag()
        {
            var deceased = ProspectCustomerTag.Deceased.ToString();
            var homeVisitRequested = ProspectCustomerTag.HomeVisitRequested.ToString();
            var mobilityIssue = ProspectCustomerTag.MobilityIssue.ToString();
            var inLongTermCareNursingHome = ProspectCustomerTag.InLongTermCareNursingHome.ToString();
            var mobilityIssue_LeftMessageWithOther = ProspectCustomerTag.MobilityIssues_LeftMessageWithOther.ToString();
            var noLongeronInsuracnePlan = ProspectCustomerTag.NoLongeronInsurancePlan.ToString();
            var debilitatingDisease = ProspectCustomerTag.DebilitatingDisease.ToString();

            string[] refusalTag =
            {
                homeVisitRequested, deceased, mobilityIssue, inLongTermCareNursingHome,
                mobilityIssue_LeftMessageWithOther, noLongeronInsuracnePlan, debilitatingDisease
            };
            return refusalTag;
        }
    }
}