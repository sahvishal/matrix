using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ValueType;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class OnlineEventService : IOnlineEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IEventSchedulingSlotRepository _eventSchedulingSlotRepository;
        private readonly IHostRepository _hostRepository;
        private readonly IEventAppointmentStatsService _eventAppointmentStatsService;
        private readonly IZipCodeRepository _zipCodeRepository;
        private readonly IOnlineEventListModelFactory _onlineEventListModelFactory;
        private readonly IHospitalPartnerRepository _hospitalPartnerRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IEventTestRepository _eventTestRepository;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly ISourceCodeRepository _sourceCodeRepository;
        private readonly ITempCartRepository _tempCartRepository;
        private readonly IPreQualificationResultRepository _preQualificationResultRepository;


        public OnlineEventService(IEventRepository eventRepository, IEventSchedulingSlotRepository eventSchedulingSlotRepository, IHostRepository hostRepository, IEventAppointmentStatsService eventAppointmentStatsService,
            IZipCodeRepository zipCodeRepository, IOnlineEventListModelFactory onlineEventListModelFactory, IHospitalPartnerRepository hospitalPartnerRepository, ICorporateAccountRepository corporateAccountRepository,
            IEventTestRepository eventTestRepository, IUniqueItemRepository<File> fileRepository, IMediaRepository mediaRepository, IOrganizationRepository organizationRepository, ISourceCodeRepository sourceCodeRepository,
            ITempCartRepository tempCartRepository, IPreQualificationResultRepository preQualificationResultRepository)
        {
            _eventRepository = eventRepository;
            _eventSchedulingSlotRepository = eventSchedulingSlotRepository;
            _hostRepository = hostRepository;
            _eventAppointmentStatsService = eventAppointmentStatsService;
            _zipCodeRepository = zipCodeRepository;
            _onlineEventListModelFactory = onlineEventListModelFactory;
            _hospitalPartnerRepository = hospitalPartnerRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _eventTestRepository = eventTestRepository;
            _fileRepository = fileRepository;
            _mediaRepository = mediaRepository;
            _organizationRepository = organizationRepository;
            _sourceCodeRepository = sourceCodeRepository;
            _tempCartRepository = tempCartRepository;
            _preQualificationResultRepository = preQualificationResultRepository;
        }

        public IEnumerable<OnlineEventViewModel> GetEvents(OnlineSchedulingEventListModelFilter filter, int maxNumberofRecordstoFetch, int pageSize, out int totalRecords)
        {
            var events = _eventRepository.GetEventsbyFilters(filter, out totalRecords);
            if (events == null || !events.Any())
                return null;

            var todayEventIds = events.Where(e => e.EventDate < DateTime.Now.Date.AddDays(1)).Select(e => e.Id);
            var todaySlots = _eventSchedulingSlotRepository.GetbyEventIds(todayEventIds);

            var eventIds = events.Select(e => e.Id).Distinct().ToArray();
            var hosts = _hostRepository.GetEventHosts(eventIds);

            var eventAppointmentStatsModels = _eventAppointmentStatsService.Get(eventIds);

            ZipCode zipCode = null;
            try
            {
                if (!string.IsNullOrEmpty(filter.ZipCode))
                {
                    zipCode = _zipCodeRepository.GetZipCode(filter.ZipCode).FirstOrDefault();
                }
            }
            catch (ObjectNotFoundInPersistenceException<ZipCode>)
            {
                zipCode = null;
            }

            var eventCollection = _onlineEventListModelFactory.Create(events, hosts, eventAppointmentStatsModels, zipCode, todaySlots, filter.EventId, filter.CutOffHourstoMarkEventforOnlineSelection,
                filter.OrderBy, filter.OrderType, maxNumberofRecordstoFetch, filter.PageNumber, pageSize, out totalRecords);

            eventIds = eventCollection.Select(e => e.EventId).Distinct().ToArray();

            foreach (var theEvent in eventCollection)
            {
                var eventTest = _eventTestRepository.GetByEventAndTestIds(theEvent.EventId, TestGroup.BreastCancer);
                theEvent.HasBreastCancer = eventTest != null && eventTest.Any();
            }


            var eventHpPairs = _hospitalPartnerRepository.GetEventAndHospitalPartnerOrderedPair(eventIds);
            var eventCorporateAccountPairs = _corporateAccountRepository.GetEventIdCorporateAccountPairForSponsoredBy(eventIds);


            var organizations = eventCorporateAccountPairs == null || eventCorporateAccountPairs.Count() < 1 ? null : _organizationRepository.GetOrganizations(eventCorporateAccountPairs.Select(m => m.SecondValue).Distinct().ToArray());
            var fileIds = organizations != null ? organizations.Where(o => o.LogoImageId > 0).Select(o => o.LogoImageId).ToArray() : null;
            var files = fileIds == null ? null : _fileRepository.GetByIds(fileIds);
            if (files != null)
            {
                var location = _mediaRepository.GetOrganizationLogoImageFolderLocation();
                files = files.Select(f =>
                {
                    f.Path = location.Url + f.Path;
                    return f;
                }).ToArray();

                eventCollection = _onlineEventListModelFactory.ManageSponsoredByLogo(eventCollection, eventCorporateAccountPairs, organizations, files);
            }

            organizations = eventHpPairs == null || eventHpPairs.Count() < 1 ? null : _organizationRepository.GetOrganizations(eventHpPairs.Select(m => m.SecondValue).Distinct().ToArray());
            fileIds = organizations != null ? organizations.Where(o => o.LogoImageId > 0).Select(o => o.LogoImageId).ToArray() : null;
            files = fileIds == null ? null : _fileRepository.GetByIds(fileIds);
            if (files != null)
            {
                var location = _mediaRepository.GetOrganizationLogoImageFolderLocation();
                files = files.Select(f =>
                {
                    f.Path = location.Url + f.Path;
                    return f;
                }).ToArray();

                eventCollection = _onlineEventListModelFactory.ManageSponsoredByLogo(eventCollection, eventHpPairs, organizations, files);
            }

            return eventCollection;
        }

        public TempCart SaveSelectedEvent(TempCart tempCart, OnlineSelectedEventEditModel model)
        {
            long sourceCodeId = 0;
            if (!string.IsNullOrEmpty(model.CouponCode))
            {
                var sourceCode = _sourceCodeRepository.GetSourceCodeByCode(model.CouponCode);
                if (sourceCode != null)
                    sourceCodeId = sourceCode.Id;
            }

            if (tempCart == null)
            {
                tempCart = new TempCart
                {
                    ZipCode = model.ZipCode,
                    EventId = model.EventId,
                    InvitationCode = model.InvitationCode,
                    CorpCode = model.InvitationCode,
                    Radius = model.Radius,
                    Guid = Guid.NewGuid().ToString(),
                    EntryPage = model.RequestUrl,
                    ExitPage = model.RequestUrl,
                    SourceCodeId = sourceCodeId > 0 ? (long?)sourceCodeId : null
                };
            }
            else
            {
                if (tempCart.EventId != model.EventId)
                {
                    tempCart.ZipCode = string.IsNullOrEmpty(model.ZipCode) ? tempCart.ZipCode : model.ZipCode;
                    tempCart.Radius = model.Radius.HasValue ? model.Radius : tempCart.Radius;
                    tempCart.EventId = model.EventId;
                    tempCart.ExitPage = model.RequestUrl;
                    tempCart.EventPackageId = null;
                    tempCart.TestId = null;
                    tempCart.ShippingId = null;
                    tempCart.ProductId = null;
                    tempCart.PreliminarySelectedTime = null;
                    tempCart.AppointmentId = null;
                    tempCart.InChainAppointmentSlots = null;

                    if (tempCart.AppointmentId.HasValue)
                    {
                        _eventSchedulingSlotRepository.ReleaseSlots(tempCart.InChainAppointmentSlotIds);
                    }
                }
            }

            if (tempCart.Id > 0)
                tempCart.DateModified = DateTime.Now;
            else
            {
                tempCart.DateCreated = DateTime.Now;
            }

            tempCart = _tempCartRepository.Save(tempCart);

            return tempCart;
        }

        public PreQualificationViewModel SaveAnswer(PreQualificationViewModel model)
        {
            var tempCart = model.RequestValidationModel.TempCart;
            var preQualification = _preQualificationResultRepository.Get(tempCart.Id) ?? new PreQualificationResult() { TempCartId = tempCart.Id, EventId = tempCart.EventId.Value };

            if (model.SkipPreQualificationQuestion)
            {
                preQualification.SkipPreQualificationQuestion = true;
            }
            else
            {
                preQualification.HighBloodPressure = model.HighBloodPressure;
                preQualification.Smoker = model.Smoker;
                preQualification.HeartDisease = model.HeartDisease;
                preQualification.Diabetic = model.Diabetic;
                preQualification.ChestPain = model.ChestPain;
                preQualification.DiagnosedHeartProblem = model.DiagnosedHeartProblem;
                preQualification.HighCholestrol = model.HighCholestrol;
                preQualification.OverWeight = model.OverWeight;
                preQualification.AgreedWithPrequalificationQuestion = model.AgreedWithPrequalificationQuestion;
            }
            preQualification.DateCreated = DateTime.Now;
            _preQualificationResultRepository.Save(preQualification);
            return model;
        }

        public PreQualificationViewModel GetPreQualificationAnswer(TempCart tempCart)
        {
            var preQualification = _preQualificationResultRepository.Get(tempCart.Id);
            if (preQualification != null)
            {
                return new PreQualificationViewModel()
                {
                    HighBloodPressure = preQualification.HighBloodPressure,
                    Smoker = preQualification.Smoker,
                    HeartDisease = preQualification.HeartDisease,
                    Diabetic = preQualification.Diabetic,
                    ChestPain = preQualification.ChestPain,
                    DiagnosedHeartProblem = preQualification.DiagnosedHeartProblem,
                    HighCholestrol = preQualification.HighCholestrol,
                    OverWeight = preQualification.OverWeight,
                    AgreedWithPrequalificationQuestion = preQualification.AgreedWithPrequalificationQuestion,
                    SkipPreQualificationQuestion = preQualification.SkipPreQualificationQuestion
                };
            }
            return null;
        }


    }
}
