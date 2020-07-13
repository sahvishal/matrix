using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Infrastructure.Scheduling.Services
{
    public class EventPackageSelectorService : IEventPackageSelectorService
    {
        private readonly IPackageRepository _packageRepository;
        private readonly IEventPackageRepository _eventPackageRepository;
        private readonly IEventTestRepository _eventTestRepository;
        private readonly IElectronicProductRepository _productRepository;
        private readonly IShippingOptionRepository _shippingOptionRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IConfigurationSettingRepository _configurationRepository;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventSchedulingSlotService _slotService;
        private readonly IAccountPackageRepository _accountPackageRepository;
        private readonly IHospitalPartnerPackageRepository _hospitalPartnerPackageRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IRoleRepository _roleRepository;
        private const int MinimumScreeningTime = 5;

        public EventPackageSelectorService(IPackageRepository packageRepository, IEventPackageRepository eventPackageRepository, IEventTestRepository eventTestRepository, IElectronicProductRepository productRepository,
            IEventRepository eventRepository, IShippingOptionRepository shippingOptionRepository, IConfigurationSettingRepository configurationRepository, IUniqueItemRepository<File> fileRepository, IMediaRepository mediaRepository,
            ICustomerRepository customerRepository, IEventSchedulingSlotService slotService, IAccountPackageRepository accountPackageRepository, IHospitalPartnerPackageRepository hospitalPartnerPackageRepository, ICorporateAccountRepository corporateAccountRepository, IRoleRepository roleRepository)
        {
            _packageRepository = packageRepository;
            _eventPackageRepository = eventPackageRepository;
            _eventTestRepository = eventTestRepository;
            _productRepository = productRepository;
            _shippingOptionRepository = shippingOptionRepository;
            _eventRepository = eventRepository;
            _configurationRepository = configurationRepository;
            _mediaRepository = mediaRepository;
            _fileRepository = fileRepository;
            _customerRepository = customerRepository;
            _slotService = slotService;
            _accountPackageRepository = accountPackageRepository;
            _hospitalPartnerPackageRepository = hospitalPartnerPackageRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _roleRepository = roleRepository;
        }

        public IEnumerable<EventPackageEditModel> GetEventPackage(long accountId, long hospitalPartnerId, long territoryId, EventType eventType)
        {
            IEnumerable<Package> packages = null;
            IEnumerable<EventPackageEditModel> eventPackages = null;
            if (accountId > 0)
            {
                packages = _packageRepository.GetPackagesByAccount(accountId);
                if (packages != null && packages.Any())
                {
                    eventPackages = Mapper.Map<IEnumerable<Package>, IEnumerable<EventPackageEditModel>>(packages);
                    var accountPackages = _accountPackageRepository.GetByAccountId(accountId);

                    foreach (var eventPackageEditModel in eventPackages)
                    {
                        var accountPackage = accountPackages.Single(ap => ap.PackageId == eventPackageEditModel.PackageId);
                        eventPackageEditModel.IsRecommended = accountPackage.IsRecommended;
                    }
                    return eventPackages;
                }

            }

            if (hospitalPartnerId > 0)
            {
                packages = _packageRepository.GetPackagesByHospitalPartner(hospitalPartnerId);
                if (packages != null && packages.Any())
                {
                    eventPackages = Mapper.Map<IEnumerable<Package>, IEnumerable<EventPackageEditModel>>(packages);
                    var hospitalPartnerPackages = _hospitalPartnerPackageRepository.GetByHospitalpartnerId(hospitalPartnerId);

                    foreach (var eventPackageEditModel in eventPackages)
                    {
                        var hospitalPartnerPackage = hospitalPartnerPackages.Single(ap => ap.PackageId == eventPackageEditModel.PackageId);
                        eventPackageEditModel.IsRecommended = hospitalPartnerPackage.IsRecommended;
                    }

                    return eventPackages;
                }

            }

            if (territoryId > 0)
            {
                packages = _packageRepository.GetPackagesByTerritory(territoryId);
                if (packages != null && packages.Any())
                {
                    eventPackages = Mapper.Map<IEnumerable<Package>, IEnumerable<EventPackageEditModel>>(packages);
                    return eventPackages;
                }
            }

            packages = _packageRepository.GetPackagesByEventType(eventType);
            if (packages != null && packages.Any())
            {
                eventPackages = Mapper.Map<IEnumerable<Package>, IEnumerable<EventPackageEditModel>>(packages);
                return eventPackages;
            }
            return eventPackages;
        }

        public OrderPlaceEditModel GetEventPackage(TempCart tempCart, long eventId, Roles role)
        {
            var model = new OrderPlaceEditModel();
            model = GetEventPackage(model, eventId, role, (tempCart != null && tempCart.CustomerId.HasValue ? tempCart.CustomerId.Value : 0), tempCart);

            //var defaultShippingId = model.AllShippingOptions != null && model.AllShippingOptions.Count() > 0
            //                            ? model.AllShippingOptions.OrderByDescending(m => m.Price).Last().
            //                            ShippingOptionId : 0;
            long defaultShippingId = model.AllShippingOptions != null && model.AllShippingOptions.Count() > 0 ? -1 : 0;
            if (tempCart != null)
            {
                model.SelectedPackageId = tempCart.EventPackageId.HasValue ? tempCart.EventPackageId.Value : 0;
                model.SelectedShippingOptionId = tempCart.ShippingId.HasValue ? tempCart.ShippingId.Value : defaultShippingId;

                model.SelectedTestIds = !string.IsNullOrEmpty(tempCart.TestId)
                                            ? tempCart.TestId.Split(new[] { ',' }).Select(t => Convert.ToInt64(t.Trim()))
                                            : new long[0];

                model.SelectedProductIds = !string.IsNullOrEmpty(tempCart.ProductId)
                                            ? tempCart.ProductId.Split(new[] { ',' }).Select(t => Convert.ToInt64(t.Trim()))
                                            : new long[0];
            }
            else
            {
                model.SelectedShippingOptionId = defaultShippingId;
            }

            return model;
        }

        private long GetParentRoleIdByRoleId(long roleId)
        {
            var role = _roleRepository.GetByRoleId(roleId);

            if (role == null) return 0;

            return role.ParentId ?? 0;
        }

        public OrderPlaceEditModel GetEventPackage(OrderPlaceEditModel model, long eventId, Roles role, long customerId, TempCart tempCart)
        {
            var theEvent = _eventRepository.GetById(eventId);
            var userGender = !string.IsNullOrEmpty(tempCart.Gender) ? ((long)(Gender)Enum.Parse(typeof(Gender), tempCart.Gender, true)) : (long)Gender.Unspecified;
            var enableAlaCarte = Convert.ToBoolean(_configurationRepository.GetConfigurationValue(ConfigurationSettingName.EnableAlaCarte));

            var parentRole = (Roles)GetParentRoleIdByRoleId((long)role);

            if (enableAlaCarte)
            {
                if (role == Roles.Customer || parentRole == Roles.Customer)
                    enableAlaCarte = theEvent.EnableAlaCarteOnline;
                else if (role == Roles.CallCenterRep || role == Roles.CallCenterManager || parentRole == Roles.CallCenterRep || parentRole == Roles.CallCenterManager)
                    enableAlaCarte = theEvent.EnableAlaCarteCallCenter;
                else if (role == Roles.Technician || parentRole == Roles.Technician)
                    enableAlaCarte = theEvent.EnableAlaCarteTechnician;
                else if (!(theEvent.EnableAlaCarteOnline || theEvent.EnableAlaCarteCallCenter || theEvent.EnableAlaCarteTechnician))
                    enableAlaCarte = false;
            }

            var eventPackages = _eventPackageRepository.GetPackagesForEventByRole(eventId, (long)role, userGender);

            var eventTests = enableAlaCarte ? _eventTestRepository.GetTestsForEventByRole(eventId, (long)role, userGender) : null;
            if (eventTests != null && eventTests.Count() > 0)
                eventTests = eventTests.Where(et => et.Test.ShowInAlaCarte).Select(et => et).ToArray();
            var products = _productRepository.GetAllProductsForEvent(eventId);
            var shippingOptions = _shippingOptionRepository.GetAllShippingOptionsForBuyingProcess();

            var shippingOptionsToBind = new List<ShippingOption>();
            if (theEvent.EventType == EventType.Retail)
            {
                var onlineShippingOption = _shippingOptionRepository.GetOnlineShippingOption();
                shippingOptionsToBind.Add(onlineShippingOption);

                if (shippingOptions != null && shippingOptions.Count > 0)
                {
                    shippingOptions.RemoveAll(so => so.Price == 0);
                    shippingOptionsToBind.AddRange(shippingOptions);
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
            }

            if (theEvent.EventType == EventType.Corporate)
                eventPackages = eventPackages != null ? eventPackages.OrderByDescending(d => d.Price).ThenBy(d => d.Package.RelativeOrder) : null;
            else
                eventPackages = eventPackages != null ? eventPackages.OrderByDescending(d => d.Price) : null;

            eventTests = eventTests != null ? eventTests.OrderByDescending(d => d.Price) : null;
            products = products != null ? products.OrderBy(d => d.Price).ToList() : null;


            model.AllEventPackages = Mapper.Map<IEnumerable<EventPackage>, IEnumerable<EventPackageOrderItemViewModel>>(eventPackages);
            model.AllEventTests = Mapper.Map<IEnumerable<EventTest>, IEnumerable<EventTestOrderItemViewModel>>(eventTests);
            model.AllProducts = Mapper.Map<IEnumerable<ElectronicProduct>, IEnumerable<ProductOrderItemViewModel>>(products);
            model.AllShippingOptions = Mapper.Map<IEnumerable<ShippingOption>, IEnumerable<ShippingOptionOrderItemViewModel>>(shippingOptionsToBind);

            int age = 0;
            if (customerId > 0)
            {
                var customer = _customerRepository.GetCustomer(customerId);
                age = customer.DateOfBirth.HasValue ? customer.DateOfBirth.Value.GetAge() : 0;
            }
            else if (tempCart.Dob.HasValue)
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
                            eventPackage.NotAvailabilityMessage = "includes " + test.Name + " for which minimum age required is " + test.MinAge;
                            break;
                        }
                        if (test.MaxAge > 0 && age > test.MaxAge)
                        {
                            eventPackage.NotAvailable = true;
                            eventPackage.NotAvailabilityMessage = "includes " + test.Name + " for which maximum age required is " + test.MaxAge;
                            break;
                        }
                    }
                }

                foreach (var test in model.AllEventTests)
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
            }

            if (model.AllEventPackages != null && model.AllEventPackages.Any())
            {
                EventPackageOrderItemViewModel package = null;
                Gender gender;
                Enum.TryParse(tempCart.Gender, out gender);

                package = EventPackageOrderItemViewModel(model.AllEventPackages, eventPackages, gender);

                foreach (var eventPackage in model.AllEventPackages)
                {
                    eventPackage.IsRecommended = eventPackage.PackageId == package.PackageId;
                }
            }

            LoadPackageImagePath(eventPackages, model.AllEventPackages);

            model.EnableImageUpsell = IsImageUpsellEnabled(eventId);

            return model;
        }

        private bool IsImageUpsellEnabled(long eventId)
        {
            var account = _corporateAccountRepository.GetbyEventId(eventId);

            return account == null || account.EnableImageUpsell;
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

            return package ?? (GetHighestPriceOrderItemViewModel(gender, packages));
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

        public void LoadPackageImagePath(IEnumerable<EventPackage> eventPackages, IEnumerable<EventPackageOrderItemViewModel> eventPackageModelCollection)
        {
            var location = _mediaRepository.GetPackageImageFolderLocation();
            foreach (var eventPackage in eventPackages)
            {
                if (!eventPackage.Package.ForOrderDisplayFileId.HasValue || eventPackage.Package.ForOrderDisplayFileId.Value < 1) continue;

                var file = _fileRepository.GetById(eventPackage.Package.ForOrderDisplayFileId.Value);
                var eventPackageModel = eventPackageModelCollection.Where(ep => ep.EventPackageId == eventPackage.Id).Single();

                if (System.IO.File.Exists(location.PhysicalPath + file.Path))
                {
                    eventPackageModel.ImageUrlForOnlineDisplay = new MediaLocation
                                                                 {
                                                                     PhysicalPath = location.PhysicalPath + file.Path,
                                                                     Url = location.Url + file.Path
                                                                 };
                }
            }
        }

        public OnSiteRegistrationEditModel SetEventAndPackageDetail(OnSiteRegistrationEditModel model, long eventId, Roles role)
        {
            if (model == null)
                model = new OnSiteRegistrationEditModel();

            var theEvent = _eventRepository.GetById(eventId);
            model.EventId = theEvent.Id;
            model.EventDate = theEvent.EventDate;
            model.EventName = theEvent.Name;

            var eventPackages = _eventPackageRepository.GetPackagesForEventByRole(eventId, (long)role);

            var parentRole = (Roles)GetParentRoleIdByRoleId((long)role);

            var enableAlaCarte = Convert.ToBoolean(_configurationRepository.GetConfigurationValue(ConfigurationSettingName.EnableAlaCarte));
            if (enableAlaCarte)
            {
                if (role == Roles.Customer || parentRole == Roles.Customer)
                    enableAlaCarte = theEvent.EnableAlaCarteOnline;
                else if (role == Roles.CallCenterRep || role == Roles.CallCenterManager || parentRole == Roles.CallCenterRep || parentRole == Roles.CallCenterManager)
                    enableAlaCarte = theEvent.EnableAlaCarteCallCenter;
                else if (role == Roles.Technician || parentRole == Roles.Technician)
                    enableAlaCarte = theEvent.EnableAlaCarteTechnician;
                else if (!(theEvent.EnableAlaCarteOnline || theEvent.EnableAlaCarteCallCenter || theEvent.EnableAlaCarteTechnician))
                    enableAlaCarte = false;
            }
            var eventTests = enableAlaCarte ? _eventTestRepository.GetTestsForEventByRole(eventId, (long)role) : null;

            eventPackages = eventPackages != null ? eventPackages.OrderByDescending(d => d.Price) : null;
            eventTests = eventTests != null ? eventTests.OrderByDescending(d => d.Price) : null;

            model.AllEventPackages = Mapper.Map<IEnumerable<EventPackage>, IEnumerable<EventPackageOrderItemViewModel>>(eventPackages);
            model.AllEventTests = Mapper.Map<IEnumerable<EventTest>, IEnumerable<EventTestOrderItemViewModel>>(eventTests);

            model.Appointments = _slotService.GetSlots(model.EventId, AppointmentStatus.Free);

            return model;
        }

        public int GetScreeningTime(long eventId, long packageId, IEnumerable<long> testIds)
        {
            var eventPackage = _eventPackageRepository.GetByEventAndPackageIds(eventId, packageId);
            var eventTests = !testIds.IsNullOrEmpty() ? _eventTestRepository.GetByEventAndTestIds(eventId, testIds) : null;

            return GetScreeningTime(eventPackage, eventTests);
        }

        public int GetScreeningTime(Order order)
        {
            var eventPackageOrderItem = order.OrderDetails.SingleOrDefault(od => od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess && od.DetailType == OrderItemType.EventPackageItem);
            EventPackage eventPackage = null;
            if (eventPackageOrderItem != null)
            {
                var eventPackageId = eventPackageOrderItem.OrderItem.ItemId;
                eventPackage = _eventPackageRepository.GetById(eventPackageId);
            }

            var eventTestIds = order.OrderDetails.Where(od => od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess && od.DetailType == OrderItemType.EventTestItem).Select(od => od.OrderItem.ItemId).ToArray();
            var eventTests = eventTestIds.Any() ? _eventTestRepository.GetbyIds(eventTestIds) : null;

            return GetScreeningTime(eventPackage, eventTests);
        }

        public int GetScreeningTime(long eventPackageId, IEnumerable<long> eventTestIds)
        {
            EventPackage eventPackage = null;
            if (eventPackageId > 0)
                eventPackage = _eventPackageRepository.GetById(eventPackageId);

            var eventTests = eventTestIds.IsNullOrEmpty() ? null : _eventTestRepository.GetbyIds(eventTestIds);
            return GetScreeningTime(eventPackage, eventTests);
        }

        private int GetScreeningTime(EventPackage eventPackage, IEnumerable<EventTest> eventTests)
        {
            int screeningTime = 0;

            if (eventPackage != null)
            {
                screeningTime += eventPackage.Package.ScreeningTime;
            }

            if (!eventTests.IsNullOrEmpty())
            {
                screeningTime += eventTests.Sum(et => et.Test.ScreeningTime);
            }

            if (eventPackage != null || (eventTests != null && eventTests.Any()))
            {
                var eventId = eventPackage != null ? eventPackage.EventId : eventTests.First().EventId;

                var eventData = _eventRepository.GetById(eventId);

                if (eventData.IsDynamicScheduling && screeningTime == 0)
                {
                    screeningTime = MinimumScreeningTime;
                }

                if (eventPackage != null && eventData.IsDynamicScheduling && eventData.IsPackageTimeOnly)
                {
                    screeningTime = eventPackage.Package.ScreeningTime > 0 ? eventPackage.Package.ScreeningTime : MinimumScreeningTime;
                }
            }

            return screeningTime;
        }
    }
}