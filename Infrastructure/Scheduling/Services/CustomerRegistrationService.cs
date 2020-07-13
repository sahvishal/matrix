using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.Enum;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Core.Users.Enum;

namespace Falcon.App.Infrastructure.Scheduling.Services
{
    public class CustomerRegistrationService : ICustomerRegistrationService
    {
        private readonly IMassRegistrationEditModelFactory _massRegistrationEditModelFactory;
        private readonly ISessionContext _sessionContext;
        private readonly ICustomerService _customerService;
        private readonly IOrganizationRoleUserRepository _orgRoleUserRepository;
        private readonly IEventPackageRepository _eventPackageRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IOrderController _orderController;
        private readonly IAddressService _addressService;
        private readonly IShippingOptionRepository _shippingOptionRepository;
        private readonly IShippingController _shippingController;
        private readonly INotifier _notifier;
        private readonly IEmailNotificationModelsFactory _emailNotificationModelsFactory;
        private readonly IEventTestRepository _eventTestRepository;
        private readonly ISettings _settings;
        private readonly IStateRepository _stateRepository;
        private readonly IEventAppointmentService _eventAppointmentService;
        private readonly IEventPackageSelectorService _eventPackageSelectorService;
        private readonly IEventSchedulingSlotService _eventSchedulingSlotService;
        private readonly IEventRepository _eventRepository;
        private readonly IPhoneNotificationModelsFactory _smsNotificationModelsFactory;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IEmailTemplateRepository _emailTemplateRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerNotesService _customerNotesService;

        private readonly ILanguageRepository _languageRepository;
        private readonly ILabRepository _labRepository;
        private readonly IUserLoginRepository _userLoginRepository;
        private readonly CryptographyService _cryptographyService = new PasswordCryptographyService();

        private readonly IEventCustomerNotificationRepository _eventCustomerNotificationRepository;

        private readonly ILogger _logger;
        private readonly ICorporateCustomerUploadService _corporateCustomerUploadService;
        private readonly ICurrentMedicationRepository _currentMedicationRepository;
        private readonly ICustomerIcdCodesRepository _customerIcdCodesRepository;
        private readonly IEventCustomerCurrentMedicationRepository _eventCustomerCurrentMedicationRepository;
        private readonly IEventCustomerIcdCodesRepository _eventCustomerIcdCodesRepository;


        public CustomerRegistrationService(IMassRegistrationEditModelFactory massRegistrationEditModelFactory, ISessionContext sessionContext,
            ICustomerService customerService, IOrganizationRoleUserRepository orgRoleUserRepository,
            IEventPackageRepository eventPackageRepository, IEventCustomerRepository eventCustomerRepository, IOrderController orderController,
            IAddressService addressService, IShippingOptionRepository shippingOptionRepository, IShippingController shippingController, INotifier notifier,
            IEmailNotificationModelsFactory emailNotificationModelsFactory, IEventTestRepository eventTestRepository, ISettings settings, IStateRepository stateRepository,
            IEventAppointmentService eventAppointmentService, IEventPackageSelectorService eventPackageSelectorService, IEventSchedulingSlotService eventSchedulingSlotService,
            IEventRepository eventRepository, IPhoneNotificationModelsFactory smsNotificationModelsFactory, ICorporateAccountRepository corporateAccountRepository,
            IEmailTemplateRepository emailTemplateRepository, ICustomerRepository customerRepository, ICustomerNotesService customerNotesService,
            ILanguageRepository languageRepository, ILabRepository labRepository, IUserLoginRepository userLoginRepository, ILogManager logManager,
            IEventCustomerNotificationRepository eventCustomerNotificationRepository, ICorporateCustomerUploadService corporateCustomerUploadService,
            ICurrentMedicationRepository currentMedicationRepository, ICustomerIcdCodesRepository customerIcdCodesRepository,
            IEventCustomerCurrentMedicationRepository eventCustomerCurrentMedicationRepository, IEventCustomerIcdCodesRepository eventCustomerIcdCodesRepository)
        {
            _massRegistrationEditModelFactory = massRegistrationEditModelFactory;
            _sessionContext = sessionContext;
            _customerService = customerService;
            _orgRoleUserRepository = orgRoleUserRepository;
            _eventPackageRepository = eventPackageRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _orderController = orderController;
            _addressService = addressService;
            _shippingOptionRepository = shippingOptionRepository;
            _shippingController = shippingController;
            _notifier = notifier;
            _emailNotificationModelsFactory = emailNotificationModelsFactory;
            _eventTestRepository = eventTestRepository;
            _settings = settings;
            _stateRepository = stateRepository;
            _eventAppointmentService = eventAppointmentService;
            _eventPackageSelectorService = eventPackageSelectorService;
            _eventSchedulingSlotService = eventSchedulingSlotService;
            _eventRepository = eventRepository;
            _smsNotificationModelsFactory = smsNotificationModelsFactory;
            _corporateAccountRepository = corporateAccountRepository;
            _emailTemplateRepository = emailTemplateRepository;
            _customerRepository = customerRepository;
            _customerNotesService = customerNotesService;

            _languageRepository = languageRepository;
            _labRepository = labRepository;
            _userLoginRepository = userLoginRepository;

            _eventCustomerNotificationRepository = eventCustomerNotificationRepository;

            _corporateCustomerUploadService = corporateCustomerUploadService;
            _currentMedicationRepository = currentMedicationRepository;
            _customerIcdCodesRepository = customerIcdCodesRepository;
            _eventCustomerCurrentMedicationRepository = eventCustomerCurrentMedicationRepository;
            _eventCustomerIcdCodesRepository = eventCustomerIcdCodesRepository;
            _logger = logManager.GetLogger("Customer Registration Service");
        }

        public bool RegisterCustomer(MassRegistrationEditModel model, long eventId, EventType eventType)
        {
            var createdByOrgRoleUser = Mapper.Map<OrganizationRoleUserModel, OrganizationRoleUser>(_sessionContext.UserSession.CurrentOrganizationRole);
            if (model.Address != null && string.IsNullOrEmpty(model.Address.StreetAddressLine1) && string.IsNullOrEmpty(model.Address.City) && string.IsNullOrEmpty(model.Address.ZipCode))
            {
                var state = _stateRepository.GetStatebyCode(_settings.State) ??
                            _stateRepository.GetState(_settings.State);
                model.Address.StreetAddressLine1 = _settings.Address1;
                model.Address.StreetAddressLine2 = _settings.Address2;
                model.Address.City = _settings.City;
                model.Address.StateId = state != null ? state.Id : model.Address.StateId;
                model.Address.ZipCode = _settings.ZipCode;
            }
            var customer = _massRegistrationEditModelFactory.CreateCustomer(model, createdByOrgRoleUser);
            _customerService.SaveCustomer(customer, createdByOrgRoleUser.Id);

            var forOrgRoleUser = _orgRoleUserRepository.GetOrganizationRoleUser(customer.CustomerId);

            var orderables = new List<IOrderable>();

            if (model.PackageId > 0)
            {
                orderables.Add(_eventPackageRepository.GetByEventAndPackageIds(eventId, model.PackageId));
            }
            if (orderables.IsNullOrEmpty()) return false;

            var screeningTime = _eventPackageSelectorService.GetScreeningTime(eventId, model.PackageId, null);
            var slots = _eventSchedulingSlotService.BookSlotTemporarily(model.AppointmentId, screeningTime, model.PackageId, null);

            if (slots.IsNullOrEmpty())
            {
                throw new InvalidOperationException("Slot is booked by some other customer.");
            }

            var eventCustomer = SaveEventCustomer(createdByOrgRoleUser, model.AppointmentId, eventId, customer.CustomerId);

            ShippingDetail shippingDetail = null;
            if (model.AddFreeShipping)
            {
                var shippingAddress = Mapper.Map<AddressEditModel, Address>(model.Address);

                shippingDetail = SaveShippingDetail(shippingAddress, createdByOrgRoleUser);
            }
            PlaceOrder(forOrgRoleUser, createdByOrgRoleUser, orderables, eventCustomer, null, shippingDetail);

            if (model.SendNotification)
            {
                var eventData = _eventRepository.GetById(eventId);
                SendNotification(customer, eventData, createdByOrgRoleUser, "/Scheduling/MassRegistration/Create");
            }

            try
            {
                _eventSchedulingSlotService.SendEventFillingNotification(eventId, createdByOrgRoleUser.Id);
            }
            catch (Exception)
            {

            }
            return true;
        }

        public Order RegisterOnsiteCustomer(OnSiteRegistrationEditModel model)
        {
            var createdByOrgRoleUser = Mapper.Map<OrganizationRoleUserModel, OrganizationRoleUser>(_sessionContext.UserSession.CurrentOrganizationRole);
            var customer = _massRegistrationEditModelFactory.CreateCustomer(model, createdByOrgRoleUser);
            _customerService.SaveCustomer(customer, createdByOrgRoleUser.Id);

            var forOrgRoleUser = _orgRoleUserRepository.GetOrganizationRoleUser(customer.CustomerId);

            var orderables = new List<IOrderable>();

            long packageId = 0;
            IEnumerable<long> testIds = null;

            if (model.SelectedPackageId > 0)
            {
                var eventPackage = _eventPackageRepository.GetById(model.SelectedPackageId);
                packageId = eventPackage.PackageId;
                orderables.Add(eventPackage);
            }

            if (model.SelectedTestIds != null && model.SelectedTestIds.Count() > 0)
            {
                var eventTests = _eventTestRepository.GetbyIds(model.SelectedTestIds);
                testIds = eventTests.Select(et => et.TestId).ToArray();
                if (model.SelectedPackageId > 0)
                {
                    foreach (var eventTest in eventTests)
                    {
                        eventTest.Price = eventTest.WithPackagePrice;
                    }
                }
                orderables.AddRange(eventTests);
            }

            var screeningTime = _eventPackageSelectorService.GetScreeningTime(model.SelectedPackageId, model.SelectedTestIds);
            var slots = _eventSchedulingSlotService.BookSlotTemporarily(model.SelectedAppointmentId, screeningTime, packageId, testIds);

            if (slots.IsNullOrEmpty())
            {
                throw new InvalidOperationException("Slot is booked by some other customer.");
            }

            var eventCustomer = SaveEventCustomer(createdByOrgRoleUser, model.SelectedAppointmentId, model.EventId, customer.CustomerId);

            //var shippingAddress = Mapper.Map<AddressEditModel, Address>(model.Address);

            //var shippingDetail = SaveShippingDetail(shippingAddress, createdByOrgRoleUser);

            var order = PlaceOrder(forOrgRoleUser, createdByOrgRoleUser, orderables, eventCustomer, null, null);

            var eventData = _eventRepository.GetById(model.EventId);

            SendNotification(customer, eventData, createdByOrgRoleUser, "/Scheduling/OnSiteRegistration/Create");
            order.CustomerId = customer.CustomerId;

            try
            {
                _eventSchedulingSlotService.SendEventFillingNotification(model.EventId, createdByOrgRoleUser.Id);
            }
            catch (Exception)
            {

            }
            return order;
        }

        private EventCustomer SaveEventCustomer(OrganizationRoleUser createdByOrgRoleUser, long slotId, long eventId, long customerId)
        {
            var appointment = _eventAppointmentService.CreateAppointment(new[] { slotId }, createdByOrgRoleUser.Id);
            var eventCustomer = new EventCustomer
                                    {
                                        AppointmentId = appointment.Id,
                                        EventId = eventId,
                                        CustomerId = customerId,
                                        DataRecorderMetaData = new DataRecorderMetaData
                                                                   {
                                                                       DataRecorderCreator = createdByOrgRoleUser,
                                                                       DateCreated = DateTime.Now
                                                                   },
                                        OnlinePayment = false,
                                        MarketingSource = "",
                                        NoShow = false,
                                        TestConducted = false,
                                        HIPAAStatus = RegulatoryState.Unknown,
                                        PcpConsentStatus = RegulatoryState.Unknown
                                    };
            eventCustomer = _eventCustomerRepository.Save(eventCustomer);

            return eventCustomer;
        }

        private ShippingDetail SaveShippingDetail(Address address, OrganizationRoleUser createdByOrgRoleUser)
        {
            var shippingOptions = _shippingOptionRepository.GetAllShippingOptionsForBuyingProcess();
            if (shippingOptions != null && shippingOptions.Count > 0)
            {
                var shippingOption = shippingOptions.Where(so => so.Price == 0).Select(so => so).FirstOrDefault();
                if (shippingOption != null)
                {
                    address = _addressService.SaveAfterSanitizing(address);
                    var shippingDetail = new ShippingDetail
                                             {
                                                 ShippingOption = new ShippingOption(),
                                                 DataRecorderMetaData =
                                                     new DataRecorderMetaData
                                                         {
                                                             DataRecorderCreator = createdByOrgRoleUser,
                                                             DateCreated = DateTime.Now,
                                                             DateModified = DateTime.Now
                                                         },
                                                 Status = ShipmentStatus.Processing,
                                                 ShippingAddress = address
                                             };


                    shippingDetail.ShippingOption.Id = shippingOption.Id;
                    shippingDetail.ActualPrice = shippingOption.Price;

                    shippingDetail = _shippingController.OrderShipping(shippingDetail);
                    return shippingDetail;
                }
                return null;
            }
            return null;
        }

        private Order PlaceOrder(DomainObjectBase forOrganizationRoleUser, DomainObjectBase creatorOrganizationRoleUser, IEnumerable<IOrderable> orderables, EventCustomer eventCustomer, SourceCode sourceCode, ShippingDetail shippingDetail)
        {
            bool indentedLineItemsAdded = false;

            foreach (var orderable in orderables)
            {
                if (!indentedLineItemsAdded && (orderable.OrderItemType == OrderItemType.EventPackageItem || orderable.OrderItemType == OrderItemType.EventTestItem))
                {
                    _orderController.AddItem(orderable, 1, forOrganizationRoleUser.Id, creatorOrganizationRoleUser.Id,
                                           sourceCode,
                                           eventCustomer, shippingDetail, OrderStatusState.FinalSuccess);
                    indentedLineItemsAdded = true;
                }
                else
                    _orderController.AddItem(orderable, 1, forOrganizationRoleUser.Id, creatorOrganizationRoleUser.Id,
                                            OrderStatusState.FinalSuccess);
            }
            return _orderController.PlaceOrder(OrderType.Retail, creatorOrganizationRoleUser.Id);
        }

        private void SendNotification(Customer customer, Event eventData, OrganizationRoleUser createdByOrgRoleUser, string source)
        {
            var account = _corporateAccountRepository.GetbyEventId(eventData.Id);

            if (account == null || account.SendWelcomeEmail)
            {
                var welcomeEmailViewModel = _emailNotificationModelsFactory.GetWelcomeWithUserNameNotificationModel(customer.UserLogin.UserName, customer.Name.FullName, customer.DateCreated);
                _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.CustomerWelcomeEmailWithUsername, EmailTemplateAlias.CustomerWelcomeEmailWithUsername, welcomeEmailViewModel, customer.Id, createdByOrgRoleUser.Id, source);
                SendResetPasswordMail(customer.Id, customer.Name.FullName, createdByOrgRoleUser.Id, source);
            }

            SendAppointmentConfirmationMail(customer, eventData, createdByOrgRoleUser.Id, source, account);
        }

        public void SendAppointmentConfirmationMail(Customer customer, Event eventData, long createdByOrgRoleUserId, string source, CorporateAccount account)
        {
            var sendNotification = false;

            if (eventData.EventType == EventType.Retail)
                sendNotification = true;
            else if (eventData.AccountId.HasValue && eventData.AccountId.Value > 0 && account != null)
            {
                // account = ((IUniqueItemRepository<CorporateAccount>)_corporateAccountRepository).GetById(eventData.AccountId.Value);
                sendNotification = account.SendAppointmentMail && account.AppointmentConfirmationMailTemplateId > 0;
            }

            if (sendNotification)
            {
                var appointmentConfirmationViewModel = _emailNotificationModelsFactory.GetAppointmentConfirmationModel(eventData.Id, customer.CustomerId);

                string emailTemplateAlias = EmailTemplateAlias.AppointmentConfirmationWithEventDetails;
                if (account != null && account.AppointmentConfirmationMailTemplateId > 0)
                {
                    var emailTemplate = _emailTemplateRepository.GetById(account.AppointmentConfirmationMailTemplateId);
                    emailTemplateAlias = emailTemplate.Alias;
                }

                _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.AppointmentConfirmationWithEventDetails, emailTemplateAlias, appointmentConfirmationViewModel, customer.Id, createdByOrgRoleUserId, source, useAlternateEmail: true);
            }

            var eventCustomer = _eventCustomerRepository.Get(eventData.Id, customer.CustomerId);

            if (customer.IsSubscribed == null || customer.IsSubscribed.Value == false)
            {
                _logger.Info("Customer has not subscribed for SMS " + customer.CustomerId);
                return;
            }

            if (account != null && !account.EnableSms)
            {
                _logger.Info("SMS feature has been disabled by corporate account: " + account.Tag + " EventId: " + eventData.Id);
                return;
            }

            var messageAlreadySentList = _eventCustomerNotificationRepository.GetAllByEventCustomerId(eventCustomer.Id, NotificationTypeAlias.AppointmentConfirmation);

            var messageCount = (messageAlreadySentList != null && messageAlreadySentList.Any()) ? messageAlreadySentList.Count() : 0;

            if (account != null && messageCount >= account.MaximumSms)
            {
                _logger.Info(string.Format("Maximum Number of reminder message sms has been sent for this event. eventId {0} Customer Id: {1}", eventCustomer.EventId, eventCustomer.Id));
                return;
            }

            var smsTemplateAlias = EmailTemplateAlias.AppointmentConfirmation;
            if (account != null && account.ConfirmationSmsTemplateId.HasValue && account.ConfirmationSmsTemplateId.Value > 0)
            {
                var smsTemplate = _emailTemplateRepository.GetById(account.ConfirmationSmsTemplateId.Value);
                smsTemplateAlias = smsTemplate.Alias;
            }

            if (eventCustomer.EnableTexting)
            {
                var smsAppointmentConfirmation = _smsNotificationModelsFactory.GetScreeningReminderSmsNotificationModel(customer, eventData);
                var notification = _notifier.NotifyViaSms(NotificationTypeAlias.AppointmentConfirmation, smsTemplateAlias, smsAppointmentConfirmation, customer.Id, createdByOrgRoleUserId, source);

                if (notification != null)
                {
                    var eventCustomerNotification = new EventCustomerNotification { EventCustomerId = eventCustomer.Id, NotificationId = notification.Id, NotificationTypeId = notification.NotificationType.Id };
                    _eventCustomerNotificationRepository.Save(eventCustomerNotification);
                }
            }
        }

        public Customer RegisterCorporateCustomer(Customer customer, CorporateCustomerEditModel model, string tag, OrganizationRoleUser createdByOrgRoleUser, IEnumerable<Language> languages,
            IEnumerable<Lab> labs, StringBuilder sb, long activityTypeId, long? source, out bool isNewCustomer)
        {
            //if (customerWithAcesId != null && customer == null)
            //{
            //    throw new Exception("Aces Id can not be duplicate, Aces Id : " + model.AcesId + " already assigned.");
            //}

            //if (customerWithAcesId != null && customer != null && customerWithAcesId.CustomerId != customer.CustomerId)
            //{
            //    throw new Exception("Aces Id can not be duplicate, Aces Id : " + model.AcesId + " already assigned.");
            //}

            //if (customer == null && (sb != null && sb.ToString() != ""))
            //{
            //    throw new Exception("");
            //}
            //else
            //{
            //    sb = new StringBuilder();
            //}

            var language = GetLanguage(model, createdByOrgRoleUser, languages);
            var lab = GetLab(model, createdByOrgRoleUser, labs);

            var previousIncorrectPhoneNumberStatus = customer != null && customer.IsIncorrectPhoneNumber;

            var customerOldCellNumber = (customer != null && customer.MobilePhoneNumber != null) ? PhoneNumber.Create(PhoneNumber.ToNumber(customer.MobilePhoneNumber.ToString()), PhoneNumberType.Mobile).ToString() : string.Empty;
            var customerOldHomeNumber = (customer != null && customer.HomePhoneNumber != null) ? PhoneNumber.Create(PhoneNumber.ToNumber(customer.HomePhoneNumber.ToString()), PhoneNumberType.Home).ToString() : string.Empty;

            customer = _massRegistrationEditModelFactory.CreateCustomer(model, tag, createdByOrgRoleUser, customer, language, lab, activityTypeId, source);

            var oldCustomerId = customer.CustomerId;

            var currentIncorrectPhoneNumberStatus = customer.IsIncorrectPhoneNumber;
            _customerService.SaveCustomer(customer, createdByOrgRoleUser.Id);

            isNewCustomer = customer.CustomerId > 0 && oldCustomerId != customer.CustomerId;

            var customerNewCellNumber = (customer.MobilePhoneNumber != null) ? PhoneNumber.Create(PhoneNumber.ToNumber(customer.MobilePhoneNumber.ToString()), PhoneNumberType.Mobile).ToString() : string.Empty;
            var customerNewHomeNumber = (customer.HomePhoneNumber != null) ? PhoneNumber.Create(PhoneNumber.ToNumber(customer.HomePhoneNumber.ToString()), PhoneNumberType.Home).ToString() : string.Empty;

            if (previousIncorrectPhoneNumberStatus && !currentIncorrectPhoneNumberStatus)
            {
                _logger.Info("customer Id: " + customer.CustomerId + " and Old Cell Number: " + customerOldCellNumber + "  New Cell Number: " + customerNewCellNumber);
                _logger.Info("customer Id: " + customer.CustomerId + " and Old Home Number: " + customerOldHomeNumber + "  New Home Number: " + customerNewHomeNumber);

                _customerNotesService.SavePhoneNumberUpdatedMessage(customer.CustomerId, createdByOrgRoleUser.Id);
            }


            //always save eligibility after saving customer , because history is maintained by SaveCustomer/SaveCustomerOnly function.
            //Here Eligibility is updated within function coded below
            _corporateCustomerUploadService.UpdateCustomerData(model, createdByOrgRoleUser, customer, _logger);

            return customer;
        }

        public string ValidateZipCodes(string zipCodes)
        {
            return _corporateCustomerUploadService.ValidateZipCodes(zipCodes);
        }

        private Language GetLanguage(CorporateCustomerEditModel model, OrganizationRoleUser createdByOrgRoleUser, IEnumerable<Language> languages)
        {
            Language language = null;

            if (!string.IsNullOrEmpty(model.Language))
            {
                language = languages.FirstOrDefault(l => l.Name.Trim().ToLower() == model.Language.Trim().ToLower());
                if (language == null)
                {
                    language = _languageRepository.GetByName(model.Language);
                    if (language == null)
                    {
                        language = new Language
                        {
                            Name = model.Language,
                            Alias = model.Language,
                            IsActive = true,
                            CreatedByOrgRoleUserId = createdByOrgRoleUser.Id,
                            DateCreated = DateTime.Now
                        };

                        language = _languageRepository.Save(language);
                    }
                }
            }
            return language;
        }

        private Lab GetLab(CorporateCustomerEditModel model, OrganizationRoleUser createdByOrgRoleUser, IEnumerable<Lab> labs)
        {
            Lab lab = null;
            if (!string.IsNullOrEmpty(model.Lab))
            {
                lab = labs.FirstOrDefault(l => l.Name.Trim().ToLower() == model.Lab.Trim().ToLower());
                if (lab == null)
                {
                    lab = _labRepository.GetByName(model.Lab);
                    if (lab == null)
                    {
                        lab = new Lab
                        {
                            Name = model.Lab,
                            Alias = model.Lab,
                            IsActive = true,
                            CreatedByOrgRoleUserId = createdByOrgRoleUser.Id,
                            DateCreated = DateTime.Now
                        };

                        lab = _labRepository.Save(lab);
                    }
                }
            }

            return lab;
        }

        public void SendResetPasswordMail(long userId, string fullname, long createdByOrgRoleUserId, string source)
        {
            string resetPasswordQueryString = _cryptographyService.Encrypt(DateTime.Now.ToLongDateString()).Replace("+", "X");

            _userLoginRepository.UpdateResetPasswordQueryString(userId, resetPasswordQueryString);

            var resetPassword = _emailNotificationModelsFactory.GetResetNotificationModel(userId, fullname, resetPasswordQueryString);
            _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.ResetMail, EmailTemplateAlias.ResetPassword, resetPassword, userId, createdByOrgRoleUserId, source);
        }

        public void ExistingCustomerEventRegistrationTasks(long eventId, long customerId)
        {
            //Saving Icd codes and CurrentMedication at EVENT LEVEL
            var currentMedication = _currentMedicationRepository.GetByCustomerId(customerId);
            var eventCustomer = _eventCustomerRepository.Get(eventId, customerId);
            var icdCodes = _customerIcdCodesRepository.GetIcdByCustomerId(customerId);

            if (!currentMedication.IsNullOrEmpty())
            {
                var list = currentMedication.Select(medication => new EventCustomerCurrentMedication
                {
                    EventCustomerId = eventCustomer.Id,
                    IsOtc = medication.IsOtc,
                    IsPrescribed = medication.IsPrescribed,
                    NdcId = medication.NdcId
                }).ToList();

                _eventCustomerCurrentMedicationRepository.Save(eventCustomer.Id, list);
            }

            if (icdCodes.Any())
            {
                _eventCustomerIcdCodesRepository.SaveAll(eventCustomer.Id, icdCodes.Select(x => x.IcdCodeId));
            }
        }

        public List<Customer> GetCustomersByAcesId(string acesId)
        {
            return _customerRepository.GetCustomersByAcesId(acesId);
        }

    }
}