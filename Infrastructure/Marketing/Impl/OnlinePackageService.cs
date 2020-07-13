using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ValueType;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Infrastructure.Scheduling.Repositories;

namespace Falcon.App.Infrastructure.Marketing.Impl
{
    [DefaultImplementation]
    public class OnlinePackageService : IOnlinePackageService
    {

        private readonly IEventRepository _eventRepository;
        private readonly IEventPackageRepository _eventPackageRepository;
        private readonly IEventTestRepository _eventTestRepository;
        private readonly IShippingOptionRepository _shippingOptionRepository;
        private readonly EventSchedulingSlotRepository _eventSchedulingSlotRepository;
        private readonly IElectronicProductRepository _electronicProductRepository;
        private readonly IEventPackageSelectorService _eventPackageSelectorService;
        private readonly IEventSchedulingSlotService _eventSchedulingSlotService;
        private readonly ITempcartService _tempcartService;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IUniqueItemRepository<Test> _testRepository;
        private readonly IHospitalPartnerRepository _hospitalPartnerRepository;

        readonly long[] _upsellTests = { (long)TestType.Echocardiogram, (long)TestType.Kyn, (long)TestType.HKYN, (long)TestType.MenBloodPanel, (long)TestType.WomenBloodPanel };

        public OnlinePackageService(IEventRepository eventRepository,
            IEventPackageRepository eventPackageRepository, IEventTestRepository eventTestRepository, IShippingOptionRepository shippingOptionRepository,
            EventSchedulingSlotRepository eventSchedulingSlotRepository, IElectronicProductRepository electronicProductRepository, IEventPackageSelectorService eventPackageSelectorService,
            IEventSchedulingSlotService eventSchedulingSlotService, ITempcartService tempcartService, ICorporateAccountRepository corporateAccountRepository,
            IUniqueItemRepository<Test> testRepository, IHospitalPartnerRepository hospitalPartnerRepository)
        {
            _eventRepository = eventRepository;
            _eventPackageRepository = eventPackageRepository;
            _eventTestRepository = eventTestRepository;
            _shippingOptionRepository = shippingOptionRepository;
            _eventSchedulingSlotRepository = eventSchedulingSlotRepository;
            _electronicProductRepository = electronicProductRepository;
            _eventPackageSelectorService = eventPackageSelectorService;
            _eventSchedulingSlotService = eventSchedulingSlotService;
            _tempcartService = tempcartService;
            _corporateAccountRepository = corporateAccountRepository;
            _testRepository = testRepository;
            _hospitalPartnerRepository = hospitalPartnerRepository;
        }

        public OrderPlaceEditModel GetEventPackageList(TempCart tempCart)
        {
            var model = new OrderPlaceEditModel();

            var userGender = !string.IsNullOrEmpty(tempCart.Gender) ? ((long)(Gender)Enum.Parse(typeof(Gender), tempCart.Gender, true)) : (long)Gender.Unspecified;

            if (tempCart.EventId != null)
            {
                var theEvent = _eventRepository.GetById(tempCart.EventId.Value);

                model.RecommendPackageForEvent = theEvent.RecommendPackage;

                var eventPackages = _eventPackageRepository.GetPackagesForEventByRole(tempCart.EventId.Value, (long)Roles.Customer, userGender);
                if (theEvent.EventType == EventType.Corporate)
                    eventPackages = eventPackages != null
                        ? eventPackages.OrderByDescending(d => d.Price).ThenBy(d => d.Package.RelativeOrder)
                        : null;
                else
                    eventPackages = eventPackages != null ? eventPackages.OrderByDescending(d => d.Price) : null;

                model.AllEventPackages =
                    Mapper.Map<IEnumerable<EventPackage>, IEnumerable<EventPackageOrderItemViewModel>>(eventPackages);


                var age = 0;
                if (tempCart.Dob.HasValue)
                {
                    age = tempCart.Dob.Value.GetAge();
                }

                if (age > 0)
                {
                    foreach (var eventPackage in model.AllEventPackages)
                    {
                        foreach (var test in eventPackage.Tests)
                        {
                            if (test.MinAge > 0 && age < test.MinAge)
                            {
                                eventPackage.NotAvailable = true;
                                eventPackage.NotAvailabilityMessage = "includes " + test.Name +
                                                                      " for which minimum age required is " +
                                                                      test.MinAge;
                                break;
                            }
                            if (test.MaxAge > 0 && age > test.MaxAge)
                            {
                                eventPackage.NotAvailable = true;
                                eventPackage.NotAvailabilityMessage = "includes " + test.Name +
                                                                      " for which maximum age required is " +
                                                                      test.MaxAge;
                                break;
                            }
                        }
                    }
                }

                if (model.AllEventPackages != null && model.AllEventPackages.Any())
                {
                    EventPackageOrderItemViewModel package = null;
                    Gender gender;
                    Enum.TryParse(tempCart.Gender, out gender);

                    package = EventPackageOrderItemViewModel(model.AllEventPackages, eventPackages, gender);

                    foreach (var eventPackage in model.AllEventPackages)
                    {
                        eventPackage.IsRecommended = package != null && eventPackage.PackageId == package.PackageId;
                    }

                    int sequence = 1;
                    //if (tempCart.EventPackageId > 0)
                    //{
                    //    var selectedPackage = model.AllEventPackages.Where(ep => ep.EventPackageId == tempCart.EventPackageId);
                    //    if (selectedPackage.Any())
                    //    {
                    //        selectedPackage.First().DisplaySequence = sequence;
                    //        sequence = sequence + 1;
                    //    }
                    //}

                    var bestValuePackage = model.AllEventPackages.Where(ep => ep.BestValue);

                    //if (tempCart.EventPackageId > 0)
                    //{
                    //    bestValuePackage = model.AllEventPackages.Where(ep => ep.BestValue && ep.EventPackageId != tempCart.EventPackageId);
                    //}

                    if (bestValuePackage.Any())
                    {
                        bestValuePackage.First().DisplaySequence = sequence;
                        sequence = sequence + 1;
                    }

                    var mostPopularPackage = model.AllEventPackages.Where(ep => ep.MostPopular);

                    //if (tempCart.EventPackageId > 0)
                    //{
                    //    mostPopularPackage = model.AllEventPackages.Where(ep => ep.MostPopular && ep.EventPackageId != tempCart.EventPackageId);
                    //}

                    if (mostPopularPackage.Any())
                    {
                        mostPopularPackage.First().DisplaySequence = sequence;
                        sequence = sequence + 1;
                    }

                    //var lowestpricePackage = model.AllEventPackages.OrderBy(s => s.Price).First();
                    //if (lowestpricePackage != null)
                    //{
                    //    lowestpricePackage.IsLowestPrice = true;
                    //    lowestpricePackage.DisplaySequence = sequence;
                    //    sequence = sequence + 1;
                    //}

                    var highestpricePackage = model.AllEventPackages.OrderByDescending(s => s.Price).First();
                    if (highestpricePackage != null)
                    {
                        highestpricePackage.IsHighestPrice = true;
                    }

                    foreach (var packageItem in model.AllEventPackages.OrderByDescending(s => s.Price).Where(x => x.IsLowestPrice == false && x.MostPopular == false && x.BestValue == false)) //&& (!(tempCart.EventPackageId > 0) || x.EventPackageId != tempCart.EventPackageId)
                    {
                        packageItem.DisplaySequence = sequence;
                        sequence = sequence + 1;
                    }

                    model.AllEventPackages = model.AllEventPackages.OrderBy(d => d.DisplaySequence);
                }

                _eventPackageSelectorService.LoadPackageImagePath(eventPackages, model.AllEventPackages);
            }

            return UpdatePanelTests(model);
        }

        public void UpdateTestPurchased(TempCart tempCart)
        {
            if (tempCart.EventPackageId.HasValue)
            {
                var userGender = !string.IsNullOrEmpty(tempCart.Gender) ? ((long)(Gender)Enum.Parse(typeof(Gender), tempCart.Gender, true)) : (long)Gender.Unspecified;
                var theEvent = _eventRepository.GetById(tempCart.EventId.Value);
                var eventPackage = _eventPackageRepository.GetById(tempCart.EventPackageId.Value);
                var eventTests = theEvent.EnableAlaCarteOnline ? _eventTestRepository.GetTestsForEventByRole(tempCart.EventId.Value, (long)Roles.Customer, userGender) : null;

                if (eventPackage.Tests.Any())
                {
                    var packageTestIds = eventPackage.Tests.Select(x => x.Id).ToList();
                    var panelTestId = (long)(userGender == (long)Gender.Male ? TestType.MenBloodPanel : TestType.WomenBloodPanel);
                    var panelTestGroup = (panelTestId == (long)TestType.MenBloodPanel ? TestGroup.MensBloodPanelTestIds : TestGroup.WomenBloodPanelTestIds);
                    long panelEventTestId = 0;
                    var panelEventTestGroup = new List<long>();

                    if (!eventTests.IsNullOrEmpty())
                    {
                        panelEventTestId = eventTests.Any(x => x.TestId == panelTestId) ? eventTests.First(x => x.TestId == panelTestId).Id : 0;

                        panelEventTestGroup = eventTests.Where(et => panelTestGroup.Contains(et.TestId)).Select(x => x.Id).ToList();
                    }


                    var seletectedTests = new List<long>();

                    var purchasedPanelTest = false;


                    if (!string.IsNullOrWhiteSpace(tempCart.TestId))
                    {
                        seletectedTests.AddRange(tempCart.TestId.Split(',').Select(long.Parse).ToList());
                    }

                    if (seletectedTests.Any() && packageTestIds.Any() && panelEventTestId > 0)
                    {
                        seletectedTests = seletectedTests.Where(x => !packageTestIds.Contains(x)).ToList();
                        purchasedPanelTest = packageTestIds.Any(x => x == panelEventTestId);
                    }

                    if (purchasedPanelTest)
                    {
                        seletectedTests = seletectedTests.Where(x => !panelEventTestGroup.Contains(x)).ToList();
                    }

                    tempCart.TestId = null;
                    if (seletectedTests.Any())
                    {
                        var selectedTestIds = string.Join(",", seletectedTests);
                        tempCart.TestId = selectedTestIds;
                    }
                }
            }


        }

        private EventPackageOrderItemViewModel EventPackageOrderItemViewModel(IEnumerable<EventPackageOrderItemViewModel> packages, IEnumerable<EventPackage> eventPackages, Gender gender)
        {
            EventPackageOrderItemViewModel package = null;

            if (!eventPackages.IsNullOrEmpty() && eventPackages.Any(x => x.IsRecommended))
            {
                var eventPackage = eventPackages.FirstOrDefault(x => x.IsRecommended && x.Gender == (long)gender && x.Gender != (long)Gender.Unspecified);
                if (eventPackage != null)
                {
                    package = packages.Single(x => x.PackageId == eventPackage.PackageId);
                }
                else
                {
                    eventPackage = eventPackages.FirstOrDefault(x => x.IsRecommended && x.Gender == (long)Gender.Unspecified);
                    if (eventPackage != null)
                    {
                        package = packages.Single(x => x.PackageId == eventPackage.PackageId);
                    }
                }
            }

            return package;//  ?? (GetHighestPriceOrderItemViewModel(gender, packages));
        }

        private EventPackageOrderItemViewModel GetHighestPriceOrderItemViewModel(Gender gender, IEnumerable<EventPackageOrderItemViewModel> packages)
        {
            EventPackageOrderItemViewModel package = null;

            var prices = packages.OrderByDescending(p => p.Price).Select(p => p.Price).Distinct().ToArray();
            if (prices.Count() > 1)
            {
                var highestPrice = prices.ElementAt(0);

                if (gender == Gender.Male)
                {
                    package = packages.Where(p => p.Name.Contains("Men's") && p.Price == highestPrice).Select(p => p).FirstOrDefault();
                }
                else if (gender == Gender.Female)//(Gender)Enum.Parse(typeof(Gender), tempCart.Gender, true)
                {
                    package = packages.Where(p => p.Name.Contains("Women's") && p.Price == highestPrice).Select(p => p).FirstOrDefault();
                }
                if (package == null)
                    package = packages.Where(p => p.Price == highestPrice).Select(p => p).First();
            }
            else
            {
                package = packages.First();
            }

            return package;
        }

        public OnlineProductShippingEditModel GetShippingOption(TempCart tempCart)
        {
            var model = new OnlineProductShippingEditModel();

            if (tempCart.EventId != null)
            {
                var theEvent = _eventRepository.GetById(tempCart.EventId.Value);
                var products = _electronicProductRepository.GetAllProductsForEvent(tempCart.EventId.Value);
                var shippingOptions = _shippingOptionRepository.GetAllShippingOptionsForBuyingProcess();

                var shippingOptionsToBind = new List<ShippingOption>();
                if (theEvent.EventType == EventType.Retail)
                {
                    var hospitalPartnerId = _hospitalPartnerRepository.GetHospitalPartnerIdForEvent(tempCart.EventId.Value);
                    if (hospitalPartnerId > 0)
                    {
                        var hospitalPartner = _hospitalPartnerRepository.GetHospitalPartnerforaVendor(hospitalPartnerId);
                        if (hospitalPartner.ShowOnlineShipping)
                        {
                            var onlineShippingOption = _shippingOptionRepository.GetOnlineShippingOption();
                            shippingOptionsToBind.Add(onlineShippingOption);
                        }

                        model.IsHospitalPartnerEvent = true;

                        shippingOptions = _shippingOptionRepository.GetAllShippingOptionForHospitalPartner(hospitalPartnerId);
                        if (shippingOptions != null && shippingOptions.Count > 0)
                        {
                            shippingOptionsToBind.AddRange(shippingOptions);

                            if (shippingOptions.Count > 1 && shippingOptions.Any(so => so.Price > 0))
                                model.IsHospitalPartnerEvent = false;
                        }

                    }
                    else
                    {
                        var onlineShippingOption = _shippingOptionRepository.GetOnlineShippingOption();
                        shippingOptionsToBind.Add(onlineShippingOption);

                        if (shippingOptions != null && shippingOptions.Count > 0)
                        {
                            // shippingOptions.RemoveAll(so => so.Price == 0);
                            shippingOptionsToBind.AddRange(shippingOptions);
                        }
                    }

                    model.EventType = EventType.Retail;
                }
                else if (theEvent.EventType == EventType.Corporate)
                {
                    var onlineShippingOption = _shippingOptionRepository.GetOnlineShippingOption();
                    shippingOptionsToBind.Add(onlineShippingOption);

                    shippingOptions = _shippingOptionRepository.GetAllShippingOptionForCorporate(theEvent.AccountId.HasValue ? theEvent.AccountId.Value : 0);
                    if (shippingOptions != null && shippingOptions.Count > 0)
                    {
                        shippingOptionsToBind.AddRange(shippingOptions);
                    }
                    else
                    {
                        tempCart.ShippingId = onlineShippingOption.Id;
                    }

                    model.EventType = EventType.Corporate;
                    if (shippingOptionsToBind.Any(so => so.Id > 0))
                    {
                        shippingOptionsToBind.RemoveAll(so => so.Id == 0);
                    }
                }

                products = products != null ? products.OrderBy(d => d.Price).ToList() : null;
                model.EnableImageUpsell = IsImageUpsellEnabled(tempCart.EventId.Value);
                model.AllShippingOptions = Mapper.Map<IEnumerable<ShippingOption>, IEnumerable<ShippingOptionOrderItemViewModel>>(shippingOptionsToBind);
                model.AllProducts = Mapper.Map<IEnumerable<ElectronicProduct>, IEnumerable<ProductOrderItemViewModel>>(products);
            }

            return model;
        }

        private bool IsImageUpsellEnabled(long eventId)
        {
            var account = _corporateAccountRepository.GetbyEventId(eventId);

            return account == null || account.EnableImageUpsell;
        }

        public IEnumerable<EventTestOrderItemViewModel> GetAdditionalTest(TempCart tempCart)
        {
            var userGender = !string.IsNullOrEmpty(tempCart.Gender) ? ((long)(Gender)Enum.Parse(typeof(Gender), tempCart.Gender, true)) : (long)Gender.Unspecified;

            var theEvent = _eventRepository.GetById(tempCart.EventId.Value);
            var eventPackage = _eventPackageRepository.GetById(tempCart.EventPackageId.Value);
            var eventTests = theEvent.EnableAlaCarteOnline ? _eventTestRepository.GetTestsForEventByRole(tempCart.EventId.Value, (long)Roles.Customer, userGender) : null;

            var seletectedTests = new List<long>();

            var panelTestId = (long)(userGender == (long)Gender.Male ? TestType.MenBloodPanel : TestType.WomenBloodPanel);

            var alreadyPurchasedPanelTest = false;
            if (!string.IsNullOrWhiteSpace(tempCart.TestId) && !eventTests.IsNullOrEmpty())
            {
                seletectedTests.AddRange(tempCart.TestId.Split(',').Select(long.Parse).ToList());

                var selectedEventTestIds = eventTests.Where(et => seletectedTests.Contains(et.Id)).Select(x => x.TestId);

                alreadyPurchasedPanelTest = selectedEventTestIds.Any(x => x == panelTestId);
            }

            if (!eventTests.IsNullOrEmpty())
                eventTests = eventTests.Where(et => et.Test.ShowInAlaCarte).Select(et => et).ToArray();

            if (eventPackage.Tests.Any() && !eventTests.IsNullOrEmpty())
            {
                var packageTestsIds = eventPackage.Tests.Select(x => x.TestId);
                eventTests = eventTests.Where(et => !packageTestsIds.Contains(et.TestId) && !_upsellTests.Contains(et.TestId)).Select(et => et).ToArray();

                if (!alreadyPurchasedPanelTest)
                {
                    alreadyPurchasedPanelTest = packageTestsIds.Any(x => x == panelTestId);
                }
            }

            if (alreadyPurchasedPanelTest && !eventTests.IsNullOrEmpty())
            {
                var panelTestGroup = (panelTestId == (long)TestType.MenBloodPanel ? TestGroup.MensBloodPanelTestIds : TestGroup.WomenBloodPanelTestIds);

                eventTests = eventTests.Where(x => !panelTestGroup.Contains(x.TestId));
            }

            eventTests = eventTests != null ? eventTests.OrderByDescending(d => d.Price) : null;
            var model = Mapper.Map<IEnumerable<EventTest>, IEnumerable<EventTestOrderItemViewModel>>(eventTests);

            var age = 0;
            if (tempCart.Dob.HasValue)
            {
                age = tempCart.Dob.Value.GetAge();
            }

            foreach (var test in model)
            {
                if (test.MinAge > 0 && age < test.MinAge)
                {
                    test.NotAvailable = true;
                    test.NotAvailabilityMessage = "For this test minimum age required is " + test.MinAge;
                    break;
                }
                if (test.MaxAge > 0 && age > test.MaxAge)
                {
                    test.NotAvailable = true;
                    test.NotAvailabilityMessage = "For this test maximum age required is " + test.MaxAge;
                    break;
                }
            }
            return model;
        }

        public void ReleaseSlotsOnScreeningtimeChanged(TempCart tempCart, long newEventPackageId, string newEventTestIds)
        {
            var newEvenTestIds = new List<long>();
            if (!string.IsNullOrEmpty(newEventTestIds))
            {
                newEventTestIds.Split(',').ToList().ForEach(t => newEvenTestIds.Add(Convert.ToInt64(t)));
                newEvenTestIds.RemoveAll(t => t == 0);
            }

            //var existingEventTestIds = new List<long>();
            //if (!string.IsNullOrEmpty(tempCart.TestId))
            //{
            //    tempCart.TestId.Split(',').ToList().ForEach(t => existingEventTestIds.Add(Convert.ToInt64(t)));
            //    existingEventTestIds.RemoveAll(t => t == 0);
            //}

            //var isOrderChanged = newEventPackageId != tempCart.EventPackageId || (!newEvenTestIds.All(existingEventTestIds.Contains) || !existingEventTestIds.All(newEvenTestIds.Contains));

            var screeningTime = _eventPackageSelectorService.GetScreeningTime(tempCart.EventPackageId.Value, newEvenTestIds);

            if (!tempCart.InChainAppointmentSlotIds.IsNullOrEmpty())//&& isOrderChanged
            {
                var testIds = new List<long>();
                if (newEvenTestIds != null && newEvenTestIds.Any())
                {
                    var eventTests = _eventTestRepository.GetbyIds(newEvenTestIds);
                    if (eventTests != null && !eventTests.IsNullOrEmpty())
                        eventTests.ForEach(et => testIds.Add(et.TestId));
                }

                var newPackageId = _eventPackageRepository.GetById(newEventPackageId).PackageId;

                var theEvent = _eventRepository.GetById(tempCart.EventId.Value);

                var slots = _eventSchedulingSlotService.AdjustAppointmentSlot(tempCart.EventId.Value, screeningTime, tempCart.InChainAppointmentSlotIds, newPackageId, testIds, theEvent.LunchStartTime, theEvent.LunchDuration);

                if (slots == null)
                {
                    _eventSchedulingSlotRepository.ReleaseSlots(tempCart.InChainAppointmentSlotIds);
                    tempCart.AppointmentId = null;
                    tempCart.InChainAppointmentSlots = null;
                    tempCart.PreliminarySelectedTime = null;
                }
                else
                {
                    var eventSchedulingSlots = slots as EventSchedulingSlot[] ?? slots.ToArray();
                    tempCart.AppointmentId = eventSchedulingSlots.OrderBy(s => s.StartTime).First().Id;
                    tempCart.PreliminarySelectedTime = eventSchedulingSlots.OrderBy(s => s.StartTime).First().StartTime;
                    tempCart.InChainAppointmentSlots = string.Join(",", eventSchedulingSlots.Select(s => s.Id.ToString()).ToArray());
                }

                _tempcartService.SaveTempCart(tempCart);
            }
        }

        public IEnumerable<EventTestOrderItemViewModel> UpsaleTest(long eventId, long eventPackageId, Gender gender)
        {
            var eventPackage = _eventPackageRepository.GetById(eventPackageId);

            var eventTests = _eventTestRepository.GetTestsForEventByRole(eventId, (long)Roles.Customer, (long)gender);

            var eventPackageTestIds = eventPackage.Tests.Select(t => t.TestId).ToArray();
            var eventTestsTestIds = eventTests.Select(et => et.TestId).ToArray();

            var upsellEventTests = new List<EventTest>();

            if (!eventPackageTestIds.Contains((long)TestType.Echocardiogram) && eventTestsTestIds.Contains((long)TestType.Echocardiogram))
            {
                var eventTest = eventTests.Single(et => et.TestId == (long)TestType.Echocardiogram);
                upsellEventTests.Add(eventTest);
            }

            if (!eventPackageTestIds.Contains((long)TestType.Kyn) && eventTestsTestIds.Contains((long)TestType.Kyn))
            {
                var eventTest = eventTests.Single(et => et.TestId == (long)TestType.Kyn);
                upsellEventTests.Add(eventTest);
            }

            if (!eventPackageTestIds.Contains((long)TestType.HKYN) && eventTestsTestIds.Contains((long)TestType.HKYN))
            {
                var eventTest = eventTests.Single(et => et.TestId == (long)TestType.HKYN);
                upsellEventTests.Add(eventTest);
            }

            if (gender == Gender.Male && eventTestsTestIds.Contains((long)TestType.MenBloodPanel) && !eventPackageTestIds.Contains((long)TestType.MenBloodPanel))
            {
                var eventTest = eventTests.Single(et => et.TestId == (long)TestType.MenBloodPanel);
                upsellEventTests.Add(eventTest);
            }
            else if (gender == Gender.Female && eventTestsTestIds.Contains((long)TestType.WomenBloodPanel) && !eventPackageTestIds.Contains((long)TestType.WomenBloodPanel))
            {
                var eventTest = eventTests.Single(et => et.TestId == (long)TestType.WomenBloodPanel);
                upsellEventTests.Add(eventTest);
            }

            if (upsellEventTests.Any())
            {
                var upSelltests = Mapper.Map<IEnumerable<EventTest>, IEnumerable<EventTestOrderItemViewModel>>(upsellEventTests);
                if (upSelltests != null && upSelltests.Any())
                {
                    if (gender == Gender.Male)
                    {
                        var eventTest = upSelltests.SingleOrDefault(et => et.TestId == (long)TestType.MenBloodPanel);
                        if (eventTest != null)
                        {
                            var panelEventTests = _testRepository.GetByIds(TestGroup.MensBloodPanelTestIds.ToList());
                            if (panelEventTests.Any())
                                eventTest.Tests = panelEventTests;
                        }
                    }
                    else
                    {
                        var eventTest = upSelltests.SingleOrDefault(et => et.TestId == (long)TestType.WomenBloodPanel);
                        if (eventTest != null)
                        {
                            var panelEventTests = _testRepository.GetByIds(TestGroup.WomenBloodPanelTestIds.ToList());
                            if (panelEventTests.Any())
                                eventTest.Tests = panelEventTests;
                        }
                    }
                }
                return upSelltests;
            }

            return null;
        }

        public bool SaveUpsellTestIds(UpsellTestEditModel model)
        {
            var tempCart = model.RequestValidationModel.TempCart;
            if (tempCart.EventId.HasValue && tempCart.EventId > 0 && !string.IsNullOrEmpty(tempCart.Gender) && tempCart.EventPackageId.HasValue)
            {
                Gender gender;
                Enum.TryParse(tempCart.Gender, out gender);
                var upsellTests = UpsaleTest(tempCart.EventId.Value, tempCart.EventPackageId.Value, gender);
                var testIds = new List<long>();

                if (!string.IsNullOrWhiteSpace(tempCart.TestId))
                {
                    var panelTestId = (long)(gender == Gender.Male ? TestType.MenBloodPanel : TestType.WomenBloodPanel);
                    var panelTestGroup = (panelTestId == (long)TestType.MenBloodPanel ? TestGroup.MensBloodPanelTestIds : TestGroup.WomenBloodPanelTestIds);

                    var theEvent = _eventRepository.GetById(tempCart.EventId.Value);
                    var eventTests = theEvent.EnableAlaCarteOnline ? _eventTestRepository.GetTestsForEventByRole(tempCart.EventId.Value, (long)Roles.Customer, (long)gender) : null;

                    testIds = tempCart.TestId.Split(',').Select(long.Parse).ToList();

                    if (!eventTests.IsNullOrEmpty() && !testIds.IsNullOrEmpty())
                    {
                        var panelTest = eventTests.FirstOrDefault(x => x.TestId == panelTestId);

                        if (panelTest != null && model.SelectedEventTestIds.Any(x => x == panelTest.Id))
                        {
                            var panelEventTestGroup = eventTests.Where(et => panelTestGroup.Contains(et.TestId)).Select(x => x.Id).ToList();
                            if (!panelEventTestGroup.IsNullOrEmpty())
                            {
                                testIds = testIds.Where(x => !panelEventTestGroup.Contains(x)).ToList();
                            }
                        }
                    }

                    var upsellTestList = upsellTests.Select(x => x.EventTestId).Distinct().ToList();

                    testIds = testIds.Where(x => !upsellTestList.Contains(x)).ToList();
                }
                if (model.SelectedEventTestIds != null && model.SelectedEventTestIds.Any())
                {
                    testIds.AddRange(model.SelectedEventTestIds);
                }

                tempCart.TestId = null;

                if (testIds.Any())
                {
                    tempCart.TestId = string.Join(",", testIds);
                }

                _tempcartService.SaveTempCart(tempCart);
            }
            return true;
        }

        public bool SaveaAlacarteTestIds(TempCart tempCart, string selectedTestIds, bool saveBloodPanel)
        {
            if (tempCart.EventId.HasValue && tempCart.EventId > 0 && !string.IsNullOrEmpty(tempCart.Gender) && tempCart.EventPackageId.HasValue)
            {
                Gender gender;
                Enum.TryParse(tempCart.Gender, out gender);
                var upsellTests = UpsaleTest(tempCart.EventId.Value, tempCart.EventPackageId.Value, gender);
                var testIds = new List<long>();

                if (!string.IsNullOrWhiteSpace(tempCart.TestId) && !upsellTests.IsNullOrEmpty())
                {
                    var upsellTestIds = upsellTests.Select(x => x.EventTestId).Distinct().ToList();
                    testIds = tempCart.TestId.Split(',').Select(long.Parse).ToList();
                    testIds = testIds.Where(upsellTestIds.Contains).ToList();
                }

                if (!string.IsNullOrWhiteSpace(selectedTestIds))
                {
                    var selectedEventTestIds = selectedTestIds.Split(',').Select(long.Parse).Distinct().ToList();
                    testIds.AddRange(selectedEventTestIds);
                }
                if (saveBloodPanel)
                {
                    var panelTestId = (long)(gender == Gender.Male ? TestType.MenBloodPanel : TestType.WomenBloodPanel);
                    var panelTestGroup = (panelTestId == (long)TestType.MenBloodPanel ? TestGroup.MensBloodPanelTestIds : TestGroup.WomenBloodPanelTestIds);

                    var theEvent = _eventRepository.GetById(tempCart.EventId.Value);
                    var eventTests = theEvent.EnableAlaCarteOnline ? _eventTestRepository.GetTestsForEventByRole(tempCart.EventId.Value, (long)Roles.Customer, (long)gender) : null;
                    if (eventTests != null)
                    {
                        var eventtestIds = eventTests.Where(x => panelTestGroup.Contains(x.TestId)).Select(x => x.Id);
                        testIds = testIds.Where(x => !eventtestIds.Contains(x)).ToList();
                    }
                    var paneltestEventetstId = eventTests.Where(x => x.TestId == panelTestId);

                    if (paneltestEventetstId != null && paneltestEventetstId.Count() > 0 && !testIds.Contains(paneltestEventetstId.First().Id))
                        testIds.Add(paneltestEventetstId.First().Id);
                }

                tempCart.TestId = null;

                if (testIds.Any())
                {
                    tempCart.TestId = string.Join(",", testIds);
                }

                _tempcartService.SaveTempCart(tempCart);
            }
            return true;
        }

        private OrderPlaceEditModel UpdatePanelTests(OrderPlaceEditModel model)
        {
            if (model == null) return model;
            var eventPackages = model.AllEventPackages;
            if (eventPackages != null && eventPackages.Any())
            {
                var mensBloodPanel = _testRepository.GetByIds(TestGroup.MensBloodPanelTestIds);
                var womenBloodPanel = _testRepository.GetByIds(TestGroup.WomenBloodPanelTestIds);

                foreach (var eventPackageOrderItemViewModel in eventPackages)
                {
                    var mensBloodPanelTest = eventPackageOrderItemViewModel.Tests.FirstOrDefault(x => x.TestId == (long)TestType.MenBloodPanel);
                    if (mensBloodPanelTest != null)
                    {
                        mensBloodPanelTest.Tests = mensBloodPanel;
                    }

                    var womenBloodPanelTest = eventPackageOrderItemViewModel.Tests.FirstOrDefault(x => x.TestId == (long)TestType.WomenBloodPanel);
                    if (womenBloodPanelTest != null)
                    {
                        womenBloodPanelTest.Tests = womenBloodPanel;
                    }
                }
            }
            model.AllEventPackages = eventPackages;

            return model;
        }

        public bool IsUpsellTestAvailable(TempCart tempCart)
        {
            var account = _corporateAccountRepository.GetbyEventId(tempCart.EventId.Value);
            if (account == null || account.UpsellTest)
            {
                Gender gender;
                Enum.TryParse(tempCart.Gender, out gender);
                var upsellTests = UpsaleTest(tempCart.EventId.Value, tempCart.EventPackageId.Value, gender);
                return upsellTests != null && upsellTests.Any();
            }

            return false;
        }
    }
}