using System;
using System.Linq;
using System.Transactions;
using System.Web.Http;
using API.Areas.Application.Controllers;
using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Insurance;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using FluentValidation;

namespace API.Areas.Finance.Controllers
{
    [AllowAnonymous]
    public class OnlinePaymentController : BaseController
    {
        private readonly IUniqueItemRepository<ProspectCustomer> _prospectCustomerRepository;
        private readonly IToolTipRepository _toolTipRepository;
        private readonly ITempcartService _tempcartService;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProspectCustomerService _prospectCustomerService;
        private readonly IEligibilityService _eligibilityService;
        private readonly IChargeCardRepository _chargeCardRepository;
        private readonly IEventSchedulerService _eventSchedulerService;
        private readonly ISettings _settings;
        private readonly IValidator<PaymentInstrumentEditModel> _paymentValidator;
        private readonly IEventSchedulingSlotService _slotService;
        private readonly IAddressService _addressService;
        private readonly IStateRepository _stateRepository;
        private readonly ICustomerService _customerService;
        private readonly IPaymentController _paymentController;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IEmailNotificationModelsFactory _emailNotificationModelsFactory;
        private readonly IEventRepository _eventRepository;
        private readonly ICustomerRegistrationService _customerRegistrationService;
        private readonly INotifier _notifier;
        private readonly ICallQueueCustomerRepository _callQueueCustomerRepository;
        private readonly IEventSchedulingSlotService _eventSchedulingSlotService;
        private readonly IGiftCertificateService _giftCertificateService;
        private readonly IConfigurationSettingRepository _configurationSettingRepository;
        private const string OnlineAddress1 = "Online Address";
        private readonly bool _enableTexting;

        public OnlinePaymentController(ITempcartService tempcartService, ICustomerRepository customerRepository, IProspectCustomerService prospectCustomerService
            , IEligibilityService eligibilityService, IChargeCardRepository chargeCardRepository, IEventSchedulerService eventSchedulerService, IConfigurationSettingRepository configurationSettingRepository
            , ISettings settings, IValidator<PaymentInstrumentEditModel> paymentValidator, IEventSchedulingSlotService slotService, IAddressService addressService, IStateRepository stateRepository
            , ICustomerService customerService, IPaymentController paymentController, ICorporateAccountRepository corporateAccountRepository, IEmailNotificationModelsFactory emailNotificationModelsFactory
            , IEventRepository eventRepository, ICustomerRegistrationService customerRegistrationService, INotifier notifier, ICallQueueCustomerRepository callQueueCustomerRepository, IEventSchedulingSlotService eventSchedulingSlotService, IGiftCertificateService giftCertificateService, IUniqueItemRepository<ProspectCustomer> uniqueItemRepository, IToolTipRepository toolTipRepository
            )
        {
            _tempcartService = tempcartService;
            _customerRepository = customerRepository;
            _prospectCustomerService = prospectCustomerService;
            _eligibilityService = eligibilityService;
            _chargeCardRepository = chargeCardRepository;
            _eventSchedulerService = eventSchedulerService;
            _settings = settings;
            _paymentValidator = paymentValidator;
            _slotService = slotService;
            _addressService = addressService;
            _stateRepository = stateRepository;
            _customerService = customerService;
            _paymentController = paymentController;
            _corporateAccountRepository = corporateAccountRepository;
            _emailNotificationModelsFactory = emailNotificationModelsFactory;
            _eventRepository = eventRepository;
            _customerRegistrationService = customerRegistrationService;
            _notifier = notifier;
            _callQueueCustomerRepository = callQueueCustomerRepository;
            _eventSchedulingSlotService = eventSchedulingSlotService;
            _giftCertificateService = giftCertificateService;
            _configurationSettingRepository = configurationSettingRepository;
            _enableTexting = Convert.ToBoolean(configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.EnableSmsNotification));
            _prospectCustomerRepository = uniqueItemRepository;
            _toolTipRepository = toolTipRepository;
        }

        public OnlineSchedulingCustomerInfoEditModel GetPaymentInfo(string guid)
        {
            var onlineRequestValidationModel = _tempcartService.ValidateOnlineRequest(guid);
            if (onlineRequestValidationModel.RequestStatus != OnlineRequestStatus.Valid)
                return new OnlineSchedulingCustomerInfoEditModel
                {
                    RequestValidationModel = onlineRequestValidationModel
                };

            var tempCart = onlineRequestValidationModel.TempCart;
            var model = new OnlineSchedulingCustomerInfoEditModel
            {
                ProcessAndCartViewModel = _eventSchedulerService.GetOnlineCart(tempCart),
                EventCustomerOrderSummaryModel = _eventSchedulerService.GetEventCustomerOrderSummaryModel(guid),
                CustomerEditModel = new SchedulingCustomerEditModel { EnableTexting = _enableTexting },
                SourceCodeApplyEditModel = _eventSchedulerService.GetSourceCodeApplied(tempCart),
                RequestValidationModel = onlineRequestValidationModel

            };
            var newsletterprompt = Convert.ToBoolean(_configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.EnableNewsletterPrompt));
            if (newsletterprompt && model.EventCustomerOrderSummaryModel != null &&
                model.EventCustomerOrderSummaryModel.EventType == EventType.Retail)
            {
                model.RequestForNewsLetterDescription =
                    _toolTipRepository.GetToolTipContentByTag(ToolTipType.OnlineNewsletterDescription);
                model.ShowNewsLetterPrompt = true;
            }

            model.EventCustomerOrderSummaryModel = _eventSchedulerService.GetEventCustomerOrderSummaryModel(guid);
            model.StateList = _stateRepository.GetAllStates().ToList().Select(x => new OrderedPair<long, string>(x.Id, x.Name));

            var customer = tempCart.CustomerId.HasValue ? _customerRepository.GetCustomer(tempCart.CustomerId.Value) : null;
            if (customer == null && tempCart.ProspectCustomerId.HasValue && tempCart.ProspectCustomerId.Value > 0)
            {
                model.CustomerEditModel = _prospectCustomerService.GetforProspectCustomerId(tempCart.ProspectCustomerId.Value);
            }
            else if (customer != null)
            {
                model.CustomerEditModel = Mapper.Map<Customer, SchedulingCustomerEditModel>(customer);
                model.CustomerEditModel.ShippingAddress = Mapper.Map<Address, AddressEditModel>(customer.Address);
                model.CustomerEditModel.ConfirmationToEnablTexting = customer.EnableTexting;

                //model.CustomerEditModel.ShippingAddress.Id = tempCart.ShippingAddressId.HasValue ? tempCart.ShippingAddressId.Value : 0;
            }

            //payment
            if (model.PaymentEditModel == null)
            {
                model.PaymentEditModel = new PaymentEditModel
                {
                    PaymentFlow = PaymentFlow.In,
                    Amount = model.EventCustomerOrderSummaryModel.AmountDue.HasValue ? model.EventCustomerOrderSummaryModel.AmountDue.Value : 0,
                    ShippingAddressSameAsBillingAddress = true
                };
            }


            if (customer != null && ((customer.BillingAddress != null && customer.BillingAddress.StreetAddressLine1 != OnlineAddress1) || (customer.Address != null && customer.Address.StreetAddressLine1 != OnlineAddress1)))
            {
                model.PaymentEditModel.ExistingBillingAddress = Mapper.Map<Address, AddressEditModel>(customer.BillingAddress ?? customer.Address);
                model.PaymentEditModel.ExistingBillingAddress.Id = customer.BillingAddress != null ? customer.BillingAddress.Id : 0;

                model.PaymentEditModel.ExistingShippingAddress = Mapper.Map<Address, AddressEditModel>(customer.BillingAddress ?? customer.Address);
                model.PaymentEditModel.ExistingShippingAddress.Id = customer.Address != null ? customer.Address.Id : 0;
            }

            model.RequestForNewsLetter = model.EventCustomerOrderSummaryModel != null && model.EventCustomerOrderSummaryModel.EventType == EventType.Retail;

            model.PaymentEditModel.AllowedPaymentTypes = new[] {
                                             new OrderedPair<long, string>(PaymentType.CreditCard.PersistenceLayerId, PaymentType.CreditCard.Name),
                                             new OrderedPair<long, string>(PaymentType.ElectronicCheck.PersistenceLayerId, PaymentType.ElectronicCheck.Name),
                                             new OrderedPair<long, string>(PaymentType.GiftCertificate.PersistenceLayerId, PaymentType.GiftCertificate.Name)
                                         };

            var payLaterOnlineRegistration = Convert.ToBoolean(_configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.PayLaterOnlineRegistration));
            if (payLaterOnlineRegistration)
            {
                var payLaterOption = new[] { new OrderedPair<long, string>(PaymentType.Onsite_Value, PaymentType.PayLater_Text) };
                model.PaymentEditModel.AllowedPaymentTypes = model.PaymentEditModel.AllowedPaymentTypes.Concat(payLaterOption);

            }

            var eventId = model.EventCustomerOrderSummaryModel.EventId.HasValue ? model.EventCustomerOrderSummaryModel.EventId.Value : 0;
            var packageId = model.SourceCodeApplyEditModel.Package != null ? model.SourceCodeApplyEditModel.Package.FirstValue : 0;
            var addOnTestIds = model.SourceCodeApplyEditModel.SelectedTests != null ? model.SourceCodeApplyEditModel.SelectedTests.Select(st => st.FirstValue).ToArray() : null;

            var testCoveredByInsurance = _eligibilityService.CheckTestCoveredByinsurance(eventId, packageId, addOnTestIds);
            if (testCoveredByInsurance)
            {
                var insurancePaymentOption = new[] { new OrderedPair<long, string>(PaymentType.Insurance.PersistenceLayerId, PaymentType.Insurance.Name) };
                model.PaymentEditModel.AllowedPaymentTypes = model.PaymentEditModel.AllowedPaymentTypes.Concat(insurancePaymentOption);
            }

            if (model.EventCustomerOrderSummaryModel.AmountDue != null && model.EventCustomerOrderSummaryModel.AmountDue > 0)
            {
                if (payLaterOnlineRegistration)
                {
                    model.PaymentEditModel.Payments = new[]
                                                          {
                                                              new PaymentInstrumentEditModel
                                                                  {
                                                                      Amount = model.EventCustomerOrderSummaryModel.AmountDue.Value,
                                                                      PaymentType = Convert.ToInt32(PaymentType.Onsite_Value)
                                                                  }
                                                          };
                }
                else
                {

                    model.PaymentEditModel.Payments = new[]
                                                          {
                                                              new PaymentInstrumentEditModel
                                                                  {
                                                                      Amount = model.EventCustomerOrderSummaryModel.AmountDue.Value,
                                                                      ChargeCard = new ChargeCardPaymentEditModel()
                                                                      {
                                                                          ChargeCard = (tempCart.ChargeCardId.HasValue && tempCart.ChargeCardId.Value > 0)
                                                                          ?_chargeCardRepository.GetById(tempCart.ChargeCardId.Value)
                                                                          :new ChargeCard()
                                                                      }
                                                                  }
                                                          };


                    if (testCoveredByInsurance && tempCart.EligibilityId.HasValue && tempCart.EligibilityId.Value > 0 && tempCart.ChargeCardId.HasValue && tempCart.ChargeCardId.Value > 0)
                    {
                        var insurancePayment = new[]
                        {
                            new PaymentInstrumentEditModel
                            {
                                Insurance = new InsurancePaymentEditModel
                                {
                                    EligibilityId = tempCart.EligibilityId.Value,
                                    ChargeCardId = tempCart.ChargeCardId.Value
                                }
                            }
                        };
                        model.PaymentEditModel.Payments = model.PaymentEditModel.Payments.Concat(insurancePayment);
                    }
                }
            }
            else
            {
                model.PaymentEditModel.ShippingAddressSameAsBillingAddress = false;
            }

            return model;
        }

        [HttpPost]
        public OnlineSchedulingCustomerInfoEditModel SavePaymentInfo(OnlineSchedulingCustomerInfoEditModel model)
        {
            OnlineSchedulingProcessAndCartViewModel cartModel = model.ProcessAndCartViewModel;
            SourceCodeApplyEditModel sourceCodeModel = model.SourceCodeApplyEditModel;
            PaymentEditModel paymentModel = model.PaymentEditModel;

            var onlineRequestValidationModel = _tempcartService.ValidateOnlineRequest(cartModel.CartGuid);
            model.RequestValidationModel = onlineRequestValidationModel;

            if (onlineRequestValidationModel.RequestStatus != OnlineRequestStatus.Valid)
                return model;
            var tempCart = onlineRequestValidationModel.TempCart;


            if (tempCart.EventId.HasValue)
            {
                var summarymodel = _eventSchedulerService.GetEventCustomerOrderSummaryModel(tempCart);

                var couponAmount = sourceCodeModel != null ? sourceCodeModel.DiscountApplied : 0;
                if ((summarymodel.TotalPrice != null && summarymodel.TotalPrice.Value != (paymentModel.Amount + couponAmount)) || (summarymodel.TotalPrice == null && paymentModel.Amount > 0))
                {
                    throw new Exception("Seems like you changed your order. Please go back to the Package screen, and confirm!");
                }

                var result = ValidatePaymentModel(paymentModel);
                if (!result)
                {
                    throw new Exception("Payment error - Please re-enter your payment information or contact our customer care line at " +
                        _settings.PhoneTollFree);
                }

                var isAppointmentTemporarilyBooked = _slotService.IsSlotTemporarilyBooked(tempCart.InChainAppointmentSlotIds);
                if (!isAppointmentTemporarilyBooked)
                {
                    //throw new Exception("The appointment time selected by you is no longer temporarliy booked for you. Please go back to appointment page to choose the time slot");
                    model.PaymentEditModel.IsTemporaryBookedSlotExpired = true;
                    return model;
                }


                var isAppointmentBooked = _slotService.IsSlotBooked(tempCart.InChainAppointmentSlotIds);
                if (isAppointmentBooked)
                    throw new Exception("The appointment slot selected by you seems to have exhausted. Please re-select another slot!");

            }
            bool? paymentSucceded = null;
            Customer customer;

            try
            {
                using (var scope = new TransactionScope())
                {
                    customer = tempCart.CustomerId.HasValue ? _customerRepository.GetCustomer(tempCart.CustomerId.Value) : null;

                    var address = Mapper.Map<AddressEditModel, Address>(paymentModel.ExistingShippingAddress);

                    address = _addressService.SaveAfterSanitizing(address, true);

                    if (customer == null)
                    {
                        throw new Exception("System Failure! Data not saved. Please try again.");
                    }

                    var customerAddress = Mapper.Map<AddressEditModel, Address>(paymentModel.ExistingShippingAddress);
                    customerAddress = _addressService.SaveAfterSanitizing(customerAddress, true);
                    customer.Address = customerAddress;

                    customer.RequestForNewsLetter = model.RequestForNewsLetter;

                    if (paymentModel.Payments != null && paymentModel.Payments.Where(p => p.PaymentType != PaymentType.Onsite_Value && p.PaymentType != PaymentType.GiftCertificate.PersistenceLayerId).Count() > 0)
                    {
                        if (paymentModel.ExistingBillingAddress != null)
                        {
                            if (customer.BillingAddress != null && customer.BillingAddress.Id > 0)
                                paymentModel.ExistingBillingAddress.Id = customer.BillingAddress.Id;

                            var billingAddress = Mapper.Map<AddressEditModel, Address>(paymentModel.ExistingBillingAddress);
                            billingAddress = _addressService.SaveAfterSanitizing(billingAddress, true);

                            customer.BillingAddress = billingAddress;
                        }
                    }
                    else
                    {
                        var billingAddress = Mapper.Map<AddressEditModel, Address>(paymentModel.ExistingShippingAddress);
                        billingAddress = _addressService.SaveAfterSanitizing(billingAddress, true);

                        customer.BillingAddress = billingAddress;
                    }

                    _customerService.SaveCustomer(customer, customer.CustomerId);

                    tempCart.SourceCodeId = sourceCodeModel == null || sourceCodeModel.SourceCodeId < 1
                                                ? null
                                                : (long?)sourceCodeModel.SourceCodeId;

                    tempCart.ShippingAddressId = address.Id;
                    tempCart.ScreenResolution = cartModel.ScreenResolution;

                    if (paymentModel.Payments != null)
                    {
                        tempCart.PaymentMode = "";

                        if (paymentModel.Payments.Any(p => p.ChargeCard != null))
                            tempCart.PaymentMode += PaymentType.CreditCard.Name + ",";

                        if (paymentModel.Payments.Any(p => p.ECheck != null))
                            tempCart.PaymentMode += PaymentType.ElectronicCheck.Name + ",";

                        if (paymentModel.Payments.Any(p => p.GiftCertificate != null))
                            tempCart.PaymentMode += PaymentType.GiftCertificate.Name + ",";

                        if (paymentModel.Payments.Any(p => p.PaymentType == (int)PaymentType.Onsite_Value))
                            tempCart.PaymentMode += PaymentType.PayLater_Text + ",";

                        tempCart.PaymentMode = tempCart.PaymentMode.Substring(0, tempCart.PaymentMode.LastIndexOf(","));
                    }

                    tempCart.PaymentAmount = paymentModel.Amount;
                    try
                    {
                        _eventSchedulerService.CreateOrder(tempCart, paymentModel);
                        paymentSucceded = true;
                    }
                    catch (Exception ex)
                    {
                        _paymentController.VoidCreditCardGatewayRequests(paymentModel);
                        paymentSucceded = false;
                        throw new Exception("\nOnline Payment. Message: " + ex.Message + ". \n\t Stack Trace: " + ex.StackTrace);
                    }

                    tempCart.IsPaymentSuccessful = true;
                    tempCart.IsCompleted = true;
                    _tempcartService.SaveTempCart(tempCart);

                    UpdateProspectCustomer(tempCart, customer);
                    scope.Complete();
                }

                try
                {
                    var account = _corporateAccountRepository.GetbyEventId(tempCart.EventId.Value);

                    if (account == null || account.SendWelcomeEmail)
                    {
                        var welcomeEmailViewModel = _emailNotificationModelsFactory.GetWelcomeWithUserNameNotificationModel(customer.UserLogin.UserName, customer.Name.FullName, customer.DateCreated);
                        _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.CustomerWelcomeEmailWithUsername, EmailTemplateAlias.CustomerWelcomeEmailWithUsername, welcomeEmailViewModel, customer.Id, customer.CustomerId, Request.RequestUri.OriginalString);
                    }

                    var eventData = _eventRepository.GetById(tempCart.EventId.Value);

                    _customerRegistrationService.SendAppointmentConfirmationMail(customer, eventData, customer.CustomerId, Request.RequestUri.OriginalString, account);

                    //If somebody registered within 24 hours of the event Date then send notification.
                    if (eventData.EventDate.AddDays(-1).Date <= DateTime.Now.Date)
                    {
                        var appointmentBookedInTwentyFourHoursNotificationModel = _emailNotificationModelsFactory.GetAppointmentBookedInTwentyFourHoursModel(tempCart.EventId.Value, tempCart.CustomerId.Value);
                        _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.AppointmentBookedInTwentyFourHours, EmailTemplateAlias.AppointmentBookedInTwentyFourHours, appointmentBookedInTwentyFourHoursNotificationModel, 0, customer.CustomerId, Request.RequestUri.OriginalString);
                    }

                    _callQueueCustomerRepository.UpdateOtherCustomerStatus(customer.CustomerId, tempCart.ProspectCustomerId.HasValue ? tempCart.ProspectCustomerId.Value : 0, CallQueueStatus.Completed, customer.CustomerId);

                    _eventSchedulingSlotService.SendEventFillingNotification(tempCart.EventId.Value, customer.CustomerId);

                }
                catch (Exception)
                {
                    //throw  new Exception("\nOnline Payment. Exception caused while sending notification. Message: " + ex.Message);
                }
            }
            catch (InvalidAddressException ex)
            {
                throw new Exception("Address provided by you is not a valid address. " + ex.Message);
            }
            catch (Exception)
            {
                if (paymentSucceded != null && paymentSucceded == false)
                {
                    tempCart.IsPaymentSuccessful = false;
                    tempCart.IsCompleted = false;
                    tempCart.PaymentMode = "";
                    tempCart.SourceCodeId = 0;
                    tempCart.ShippingAddressId = null;
                    _tempcartService.SaveTempCart(tempCart);
                    throw new Exception("OOPS! Payment could not be settled. Please try again or Call our Care Agent at " + _settings.PhoneTollFree);
                }

                throw new Exception("OOPS! Some error while generating the Order. Please try again or Call our Care Agent at " + _settings.PhoneTollFree);
            }

            return model;
        }

        private bool ValidatePaymentModel(PaymentEditModel model)
        {
            bool isValid = true;

            if (model.Payments == null)
            {
                if (model.Amount > 0)
                {
                    isValid = false;
                }
            }
            else
            {
                foreach (var payment in model.Payments)
                {

                    var validationResult = _paymentValidator.Validate(payment);
                    if (!validationResult.IsValid)
                    {
                        isValid = false;

                        var propertyNames = validationResult.Errors.Select(e => e.PropertyName).Distinct();
                        var htmlString = propertyNames.Aggregate("", (current, property) => current + (validationResult.Errors.Where(e => e.PropertyName == property).FirstOrDefault().ErrorMessage + "<br />"));

                        payment.FeedbackMessage = FeedbackMessageModel.CreateFailureMessage(htmlString);
                    }
                }
            }

            return isValid;
        }

        [HttpPost]
        public ApplyGiftCertificateResultModel ApplyGiftCertificate(string claimCode)
        {
            try
            {
                var giftCertificate = _giftCertificateService.GetGiftCertificatebyClaimCode(claimCode);
                return new ApplyGiftCertificateResultModel { Result = true, Message = "", GiftCertificate = giftCertificate };
            }
            catch (ObjectDeactivatedException<GiftCertificate> ex)
            {
                return new ApplyGiftCertificateResultModel { Result = false, Message = ex.Message, GiftCertificate = new GiftCertificate { ClaimCode = claimCode } };
            }
            catch (InvalidOperationException ex)
            {
                return new ApplyGiftCertificateResultModel { Result = false, Message = ex.Message, GiftCertificate = new GiftCertificate { ClaimCode = claimCode } };
            }
            catch (Exception)
            {
                //_logger.Error(string.Concat("Online Scheduling! System Error Occured while Applying Gift Certificate for Code: [", claimCode, "]. Message: ", ex.Message, "\n\t Stack Trace: ", ex.StackTrace));
                return new ApplyGiftCertificateResultModel { Result = false, Message = "Some system error occured! Please call our Care Agent for any assistence, at " + _settings.PhoneTollFree, GiftCertificate = new GiftCertificate { ClaimCode = claimCode } };
            }
        }

        [HttpPost]
        public SourceCodeApplyEditModel ApplySourceCode(string guid, SourceCodeApplyEditModel model)
        {
            var onlineRequestValidationModel = _tempcartService.ValidateOnlineRequest(guid);
            if (onlineRequestValidationModel.RequestStatus != OnlineRequestStatus.Valid)
                return new SourceCodeApplyEditModel
                {
                    RequestValidationModel = onlineRequestValidationModel
                };

            model = _eventSchedulerService.ApplySourceCode(model);
            model.RequestValidationModel = onlineRequestValidationModel;

            var tempCart = onlineRequestValidationModel.TempCart;
            if (model.SourceCodeId > 0)
                tempCart.SourceCodeId = model.SourceCodeId;
            else
                tempCart.SourceCodeId = null;

            _tempcartService.SaveTempCart(tempCart);
            return model;
        }

        private void UpdateProspectCustomer(TempCart tempCart, Customer customer)
        {
            if (tempCart.ProspectCustomerId.HasValue)
            {
                var prospectCustomer = _prospectCustomerRepository.GetById(tempCart.ProspectCustomerId.Value);
                prospectCustomer.CustomerId = customer.CustomerId;
                prospectCustomer.Tag = ProspectCustomerTag.OnlineSignup;
                prospectCustomer.IsConverted = true;
                prospectCustomer.Status = (long)ProspectCustomerConversionStatus.Converted;
                prospectCustomer.ConvertedOnDate = DateTime.Now;
                prospectCustomer.Address.StreetAddressLine1 = customer.Address.StreetAddressLine1;
                prospectCustomer.Address.StreetAddressLine2 = customer.Address.StreetAddressLine2;
                prospectCustomer.Address.City = customer.Address.City;
                prospectCustomer.Address.State = _stateRepository.GetState(customer.Address.StateId).Name;
                prospectCustomer.Address.ZipCode.Zip = customer.Address.ZipCode.Zip;
                prospectCustomer.TagUpdateDate = DateTime.Now;
                _prospectCustomerRepository.Save(prospectCustomer);
            }
            else
            {
                var prospectCustomer = ((IProspectCustomerRepository)_prospectCustomerRepository).GetProspectCustomerByCustomerId(customer.CustomerId);
                if (prospectCustomer != null)
                {
                    prospectCustomer.CustomerId = customer.CustomerId;
                    prospectCustomer.Tag = ProspectCustomerTag.OnlineSignup;
                    prospectCustomer.IsConverted = true;
                    prospectCustomer.Status = (long)ProspectCustomerConversionStatus.Converted;
                    prospectCustomer.ConvertedOnDate = DateTime.Now;
                    prospectCustomer.Address.StreetAddressLine1 = customer.Address.StreetAddressLine1;
                    prospectCustomer.Address.StreetAddressLine2 = customer.Address.StreetAddressLine2;
                    prospectCustomer.Address.City = customer.Address.City;
                    prospectCustomer.Address.State = _stateRepository.GetState(customer.Address.StateId).Name;
                    prospectCustomer.Address.ZipCode.Zip = customer.Address.ZipCode.Zip;
                    prospectCustomer.TagUpdateDate = DateTime.Now;
                    _prospectCustomerRepository.Save(prospectCustomer);
                }
            }
        }
    }
}
