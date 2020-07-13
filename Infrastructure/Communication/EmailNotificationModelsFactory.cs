using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.Extension;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.ViewModels;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Domain.ViewData;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Infrastructure.Communication
{

    public class EmailNotificationModelsFactory : IEmailNotificationModelsFactory
    {
        private readonly ISettings _settings;

        private readonly IEventService _eventService;

        private readonly IOrderRepository _orderRepository;

        private readonly IOrderController _orderController;

        private readonly ICustomerRepository _customerRepository;

        private readonly IEventCustomerPackageTestDetailService _eventCustomerPackageTestDetailService;
        private readonly ICustomerCriticalDataRepository _customerCriticalDataRepository;
        private readonly IUniqueItemRepository<Test> _testRepository;
        private readonly IPhysicianRepository _physicianRepository;
        private readonly IEventCustomerResultRepository _evenCustomerResultRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly IPodRepository _podRepository;
        private readonly IHospitalPartnerRepository _hospitalPartnerRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly ISourceCodeRepository _sourceCodeRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IPrimaryCarePhysicianRepository _primaryCarePhysicianRepository;
        private readonly ICustomerEventPriorityInQueueDataRepository _customerEventPriorityInQueueDataRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IUserRepository<User> _userRepository;
        private readonly IAppointmentRepository _appointmentRepository;

        public EmailNotificationModelsFactory
                            (ISettings settings,
                            IEventService eventService,
                            IOrderRepository orderRepository,
                            IOrderController orderController,
                            ICustomerRepository customerRepository,
                            IEventCustomerPackageTestDetailService eventCustomerPackageTestDetailService, ICustomerCriticalDataRepository customerCriticalDataRepository,
                            IUniqueItemRepository<Test> testRepository, IPhysicianRepository physicianRepository, IEventCustomerResultRepository evenCustomerResultRepository,
                            IOrganizationRoleUserRepository organizationRoleUserRepository, IPodRepository podRepository, IHospitalPartnerRepository hospitalPartnerRepository,
                            IOrganizationRepository organizationRepository, IUniqueItemRepository<File> fileRepository, IMediaRepository mediaRepository, ISourceCodeRepository sourceCodeRepository,
                            IEventCustomerRepository eventCustomerRepository, IEventRepository eventRepository, IPrimaryCarePhysicianRepository primaryCarePhysicianRepository,
                            ICustomerEventPriorityInQueueDataRepository customerEventPriorityInQueueDataRepository, ICorporateAccountRepository corporateAccountRepository,
                            IUserRepository<User> userRepository, IAppointmentRepository appointmentRepository)
        {
            _settings = settings;
            _eventService = eventService;
            _orderRepository = orderRepository;
            _orderController = orderController;
            _customerRepository = customerRepository;
            _eventCustomerPackageTestDetailService = eventCustomerPackageTestDetailService;
            _customerCriticalDataRepository = customerCriticalDataRepository;
            _testRepository = testRepository;
            _physicianRepository = physicianRepository;
            _evenCustomerResultRepository = evenCustomerResultRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _podRepository = podRepository;
            _hospitalPartnerRepository = hospitalPartnerRepository;
            _organizationRepository = organizationRepository;
            _fileRepository = fileRepository;
            _mediaRepository = mediaRepository;
            _sourceCodeRepository = sourceCodeRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _eventRepository = eventRepository;
            _primaryCarePhysicianRepository = primaryCarePhysicianRepository;
            _customerEventPriorityInQueueDataRepository = customerEventPriorityInQueueDataRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _userRepository = userRepository;
            _appointmentRepository = appointmentRepository;
        }


        private EmailCommunicationViewModelBase CreateBase()
        {
            return Mapper.Map<ISettings, EmailCommunicationViewModelBase>(_settings);
        }


        public WelcomeWithUserNameNotificationModel GetWelcomeWithUserNameNotificationModel(string userName, string fullName, DateTime signUpDate)
        {
            return new WelcomeWithUserNameNotificationModel(CreateBase())
                    {
                        UserName = userName,
                        SingupDate = signUpDate,
                        FullName = fullName

                    };
        }

        public GiftCertificateNotificationModel GetGiftCertificateNotificationModel(string claimCode, string fromName, string toName, string message, decimal value)
        {
            return new GiftCertificateNotificationModel(CreateBase())
            {
                FromName = fromName,
                ToName = toName,
                ClaimCode = claimCode,
                Message = message,
                Value = value
            };
        }

        public GiftCertificateNotificationModel GetDummyDataGiftCertificateNotificationModel()
        {
            return new GiftCertificateNotificationModel(CreateBase())
            {
                FromName = "[From Name]",
                ToName = "[To Name]",
                ClaimCode = "[F60521]",
                Message = "[Some Custom Message from the person who purchased the Certificate]",
                Value = 200
            };
        }



        public WelcomeWithUserNameNotificationModel GetDummyDataWelcomeWithUserNameNotificationModel()
        {
            return new WelcomeWithUserNameNotificationModel(CreateBase())
            {
                UserName = "[UserName]",
                SingupDate = DateTime.Now,
                FullName = "[Customer Name]"
            };
        }

        public WelcomeWithPasswordNotificationModel GetWelcomeWithPasswordNotificationModel(string fullName, string password, string resetPasswordQueryString, long userId = 0)
        {
            return new WelcomeWithPasswordNotificationModel(CreateBase())
                       {
                           Password = password,
                           ResetPasswordQueryString = resetPasswordQueryString,
                           FullName = fullName,
                           UserId = userId
                       };
        }

        public WelcomeWithPasswordNotificationModel GetDummyDataWelcomeWithPasswordNotificationModel()
        {
            return new WelcomeWithPasswordNotificationModel(CreateBase())
            {
                Password = "[Password]",
                FullName = "[Customer Name]",
                ResetPasswordQueryString = "[Some Querystring]",
                UserId = 3
            };
        }

        public ResetPasswordNotificationModel GetResetNotificationModel(long userId, string fullName, string resetPasswordQueryString)
        {
            return new ResetPasswordNotificationModel(CreateBase())
                       {
                           UserId = userId,
                           ResetPasswordQueryString = resetPasswordQueryString,
                           FullName = fullName
                       };
        }

        public ResetPasswordNotificationModel GetDummyDataResetModificationModel()
        {
            return new ResetPasswordNotificationModel(CreateBase())
            {
                UserId = 2,
                ResetPasswordQueryString = "[Some Querystring]",
                FullName = "[Customer Name]"
            };
        }

        private EventCustomerPackageTestDetailViewData ResetTestDetails(EventCustomerPackageTestDetailViewData model)
        {
            if (model.Package != null && !model.Package.Tests.IsNullOrEmpty())
            {
                model.Package.Tests = model.Package.Tests.Where(x => x.Id != (long)TestType.PPIntake).ToList();
            }
            if (!model.Tests.IsNullOrEmpty())
            {
                model.Tests = model.Tests.Where(x => x.Id != (long)TestType.PPIntake).ToList();
            }
            return model;
        }

        public AppointmentConfirmationViewModel GetAppointmentConfirmationModel(long eventId, long customerId)
        {
            var eventCustomer = _eventCustomerRepository.Get(eventId, customerId);
            var order = _orderRepository.GetOrderByEventCustomerId(eventCustomer.Id);

            var orderDetail = _orderController.GetActiveOrderDetail(order);

            var customer = _customerRepository.GetCustomer(customerId);

            Appointment appointment = null;
            if (eventCustomer.AppointmentId.HasValue)
                appointment = _appointmentRepository.GetById(eventCustomer.AppointmentId.Value);

            var eventCustomerPackageTestDetailViewData =
                _eventCustomerPackageTestDetailService.GetEventPackageDetails(eventId, customerId);

            eventCustomerPackageTestDetailViewData = ResetTestDetails(eventCustomerPackageTestDetailViewData);

            decimal shippingPrice = orderDetail.ShippingDetailOrderDetails.Sum(shippingDetailOrderDetail => shippingDetailOrderDetail.Amount);
            decimal totalAmount = order.DiscountedTotal;
            decimal screeningPrice = order.OrderValue;

            var eventHostViewData = _eventService.GetById(eventId);

            var hospitalPartnerLogoFilePathUrl = string.Empty;
            var accountLogoFilePathUrl = string.Empty;

            var account = _corporateAccountRepository.GetbyEventId(eventId);
            if (account != null)
            {
                var organization = _organizationRepository.GetOrganizationbyId(account.Id);
                if (organization != null && organization.LogoImageId > 0)
                {
                    var file = _fileRepository.GetById(organization.LogoImageId);
                    if (file != null)
                    {
                        var location = _mediaRepository.GetOrganizationLogoImageFolderLocation();
                        accountLogoFilePathUrl = location.Url + file.Path;
                    }
                }
            }

            var hospitalPartnerId = _hospitalPartnerRepository.GetHospitalPartnerIdForEvent(eventId);
            if (hospitalPartnerId > 0)
            {
                var organization = _organizationRepository.GetOrganizationbyId(hospitalPartnerId);
                if (organization != null && organization.LogoImageId > 0)
                {
                    var file = _fileRepository.GetById(organization.LogoImageId);
                    if (file != null)
                    {
                        var location = _mediaRepository.GetOrganizationLogoImageFolderLocation();
                        hospitalPartnerLogoFilePathUrl = location.Url + file.Path;
                    }
                }
            }

            var discountCode = string.Empty;
            decimal? discountPrice = null;
            if (orderDetail.SourceCodeOrderDetail != null && orderDetail.SourceCodeOrderDetail.SourceCodeId > 0)
            {
                discountPrice = orderDetail.SourceCodeOrderDetail.Amount;
                var coupon = _sourceCodeRepository.GetSourceCodeById(orderDetail.SourceCodeOrderDetail.SourceCodeId);
                if (coupon != null)
                    discountCode = coupon.CouponCode;
            }

            var pcp = _primaryCarePhysicianRepository.Get(customerId);
            var model = new AppointmentConfirmationViewModel(CreateBase())
                       {
                           CustomerName = customer.Name.FullName,
                           EventDate = eventHostViewData.EventDate,
                           LocationName = eventHostViewData.OrganizationName,
                           AddressOfVenue = new AddressViewModel()
                                                {
                                                    StreetAddressLine1 = eventHostViewData.StreetAddressLine1,
                                                    StreetAddressLine2 = eventHostViewData.StreetAddressLine2,
                                                    City = eventHostViewData.City,
                                                    State = eventHostViewData.State,
                                                    ZipCode = eventHostViewData.Zip,
                                                    Country = "USA"
                                                },
                           Packages = eventCustomerPackageTestDetailViewData.Package,
                           Tests = eventCustomerPackageTestDetailViewData.Tests,
                           TotalDue = totalAmount,
                           AddlnProductPrice = eventCustomerPackageTestDetailViewData.ElectronicProduct != null ? eventCustomerPackageTestDetailViewData.ElectronicProduct.Price : 0,
                           PackagePrice = screeningPrice,
                           PaymentStatus = (order.TotalAmountPaid - order.DiscountedTotal) >= 0 ? "Paid" : order.TotalAmountPaid > 0 ? "Partially Paid" : "Not Paid",
                           ShippingPrice = shippingPrice,
                           HospitalPartnerLogoFilePathUrl = (!string.IsNullOrEmpty(accountLogoFilePathUrl)) ? accountLogoFilePathUrl : hospitalPartnerLogoFilePathUrl,
                           HasAddlnProduct = eventCustomerPackageTestDetailViewData.ElectronicProduct != null ? true : false,
                           DiscountPrice = discountPrice,
                           DiscountCode = discountCode,
                           PcpPhoneNumber = pcp != null && pcp.Primary != null ? pcp.Primary.FormatPhoneNumber : string.Empty,
                           CustomerFirstName = customer.Name.FirstName,
                           CustomerId = customer.CustomerId
                       };

            if (appointment != null)
                model.AppointmentTime = appointment.StartTime;

            return model;
        }


        public AppointmentBookedInTwentyFourHoursNotificationModel GetAppointmentBookedInTwentyFourHoursModel(long eventId, long customerId)
        {
            var eventCustomer = _eventCustomerRepository.Get(eventId, customerId);
            var order = _orderRepository.GetOrderByEventCustomerId(eventCustomer.Id);

            var orderDetail = _orderController.GetActiveOrderDetail(order);

            var customer = _customerRepository.GetCustomer(customerId);

            Appointment appointment = null;
            if (eventCustomer.AppointmentId.HasValue)
                appointment = _appointmentRepository.GetById(eventCustomer.AppointmentId.Value);

            var eventCustomerPackageTestDetailViewData =
                _eventCustomerPackageTestDetailService.GetEventPackageDetails(eventId, customerId);


            decimal shippingPrice = orderDetail.ShippingDetailOrderDetails.Sum(shippingDetailOrderDetail => shippingDetailOrderDetail.Amount);
            decimal totalAmount = order.DiscountedTotal;
            decimal screeningPrice = order.OrderValue - order.OrderDiscount;

            var eventHostViewData = _eventService.GetById(eventId);

            var model = new AppointmentBookedInTwentyFourHoursNotificationModel(CreateBase())
            {
                CustomerId = customer.CustomerId,
                CustomerName = customer.Name.FullName,
                AddressOfCustomer = new Address()
                {
                    StreetAddressLine1 = customer.BillingAddress.StreetAddressLine1,
                    StreetAddressLine2 = customer.BillingAddress.StreetAddressLine2,
                    City = customer.BillingAddress.City,
                    State = customer.BillingAddress.State,
                    ZipCode = customer.BillingAddress.ZipCode,
                    Country = "USA"
                },
                EventId = eventId,
                EventDate = eventHostViewData.EventDate,
                AddressOfVenue = new AddressViewModel()
                {
                    StreetAddressLine1 = eventHostViewData.StreetAddressLine1,
                    StreetAddressLine2 = eventHostViewData.StreetAddressLine2,
                    City = eventHostViewData.City,
                    State = eventHostViewData.State,
                    ZipCode = eventHostViewData.Zip,
                    Country = "USA"
                },
                Packages = eventCustomerPackageTestDetailViewData.Package,
                Tests = eventCustomerPackageTestDetailViewData.Tests,
                TotalDue = totalAmount,
                AddlnProductPrice = eventCustomerPackageTestDetailViewData.ElectronicProduct != null ? eventCustomerPackageTestDetailViewData.ElectronicProduct.Price : 0,
                PackagePrice = screeningPrice,
                PaymentStatus = (order.TotalAmountPaid - order.DiscountedTotal) >= 0 ? "Paid" : order.TotalAmountPaid > 0 ? "Partially Paid" : "Not Paid",
                ShippingPrice = shippingPrice
            };

            if (appointment != null)
                model.AppointmentTime = appointment.StartTime;

            return model;
        }

        public AppointmentBookedInTwentyFourHoursNotificationModel GetDummyAppointmentBookedInTwentyFourHoursModel()
        {
            return new AppointmentBookedInTwentyFourHoursNotificationModel(CreateBase())
            {
                CustomerName = "[Customer Name]",
                EventDate = DateTime.Now,
                AppointmentTime = DateTime.Now,
                AddressOfCustomer = new Address()
                {
                    StreetAddressLine1 = "[Dummy Address 1]",
                    StreetAddressLine2 = "",
                    City = "[Dummy City]",
                    State = "[Dummy State]",
                    ZipCode = new ZipCode("[Dummy Zip]"),
                    Country = "USA"
                },
                AddressOfVenue = new AddressViewModel()
                {
                    StreetAddressLine1 = "[Dummy Address 1]",
                    StreetAddressLine2 = "",
                    City = "[Dummy City]",
                    State = "[Dummy State]",
                    ZipCode = "[Dummy Zip]",
                    Country = "USA"
                },
                Packages = new Package
                {
                    Description = "[Dummy Package Description]",
                    Name = "[Dummy Package Name]",
                    Tests = new List<Test>(){ new Test
                                                {
                                                    Name = "[Dummy Test A]", Price = 50
                                                }, new Test
                                                {
                                                    Name = "[Dummy Test B]", Price = 40
                                                },new Test
                                                {
                                                    Name = "[Dummy Test C]", Price = 34
                                                },new Test
                                                {
                                                    Name = "[Dummy Test D]", Price = 60
                                                } }
                },
                Tests = null,
                TotalDue = 179,
                AddlnProductPrice = 0,
                PackagePrice = 174,
                PaymentStatus = "Paid",
                ShippingPrice = 5
            };
        }

        public CriticalCustomerNotificationViewModel GetCriticalCustomerNotificationModel(long eventId, long customerId, long testId = 0)
        {
            var customer = _customerRepository.GetCustomer(customerId);

            var eventHostViewData = _eventService.GetById(eventId);

            var criticalTests = _customerCriticalDataRepository.Get(eventId, customerId);

            var customerResultStatusViewModel = _evenCustomerResultRepository.GetTestResultStatusforEventCustomer(eventId, customerId);

            var tests = _testRepository.GetByIds(customerResultStatusViewModel.TestResults.Where(tr => tr.IsCritical).Select(tr => tr.TestId).ToArray());
            if (testId > 0)
                tests = tests.Where(t => t.Id == testId).Select(t => t).ToArray();

            var pods = _podRepository.GetPodsForEvent(eventId);

            var hospitalPartnerId = _hospitalPartnerRepository.GetHospitalPartnerIdForEvent(eventId);

            var healthPlan = _corporateAccountRepository.GetbyEventId(eventId);

            Organization organization = null;
            if (hospitalPartnerId > 0)
            {
                organization = _organizationRepository.GetOrganizationbyId(hospitalPartnerId);
            }
            var healthPlanName = "N/A";

            if (healthPlan != null && healthPlan.IsHealthPlan)
            {
                var healthPlanorganization = _organizationRepository.GetOrganizationbyId(healthPlan.Id);
                if (healthPlanorganization != null)
                    healthPlanName = healthPlanorganization.Name;
            }

            var model = new CriticalCustomerNotificationViewModel(CreateBase())
                            {
                                CustomerId = customer.CustomerId,
                                MemberId = string.IsNullOrEmpty(customer.InsuranceId) ? "N/A" : customer.InsuranceId,
                                EventId = eventId,
                                EventDate = eventHostViewData.EventDate,
                                Pod = string.Join(", ", pods.Select(ep => ep.Name)),
                                HospitalPartner = organization != null ? organization.Name : "N/A",
                                HealthPlan = healthPlanName
                            };
            
            var testName = tests.Select(t => t.Alias).ToArray();
            model.TestName = string.Join(", ", testName);
            return model;
        }

        public CriticalCustomerNotificationViewModel GetDummyCriticalCustomerNotificationModel()
        {
            return new CriticalCustomerNotificationViewModel(CreateBase())
                {
                    CustomerId = 250021,
                    MemberId = "[Member Id]",
                    EventDate = DateTime.Now.AddDays(10),
                    EventId = 12,
                    HospitalPartner = "[Hospital Partner Name]",
                    HealthPlan = "[Healthplan Name]",
                    Pod = "[Pod Name]",
                    TestName = "[Test-1, Test-2]"
                       
                };
        }

        public PriorityInQueueNotificationViewModel GetPriorityInQueueNotificationModel(long eventId, long customerId, string note, long eventCustomerResultId)
        {
            var customer = _customerRepository.GetCustomer(customerId);

            var eventHostViewData = _eventService.GetById(eventId);

            var pods = _podRepository.GetPodsForEvent(eventId);

            var priorityTests = _customerEventPriorityInQueueDataRepository.GetPriorityInQueueViewDataByEventCustomerResultId(eventCustomerResultId);

            var tests = _testRepository.GetByIds(priorityTests.Select(tr => tr.TestId).ToArray());

            var hospitalPartnerId = _hospitalPartnerRepository.GetHospitalPartnerIdForEvent(eventId);
            Organization organization = null;
            if (hospitalPartnerId > 0)
            {
                organization = _organizationRepository.GetOrganizationbyId(hospitalPartnerId);
            }
            var model = new PriorityInQueueNotificationViewModel(CreateBase())
            {
                CustomerId = customer.CustomerId,
                EventId = eventId,
                EventDate = eventHostViewData.EventDate,
                Pod = string.Join(", ", pods.Select(ep => ep.Name)),
                HospitalPartner = organization != null ? organization.Name : "N/A",
                PriorityInQueueNote = note
            };

            foreach (var customerEventPriorityInQueueData in priorityTests)
            {
                customerEventPriorityInQueueData.TestName = tests.First(t => t.Id == customerEventPriorityInQueueData.TestId).Name;
            }

            model.Tests = priorityTests;
            return model;
        }

        public PriorityInQueueNotificationViewModel GetDummyPriorityInQueueNotificationModel()
        {
            var tests = new List<CustomerEventPriorityInQueueDataViewModel>();
            tests.Add(new CustomerEventPriorityInQueueDataViewModel { TestName = "[Test Name 1]", PriorityInQueueReason = "[Reason for test 1]" });
            tests.Add(new CustomerEventPriorityInQueueDataViewModel { TestName = "[Test Name 2]", PriorityInQueueReason = "[Reason for test 2]" });
            return new PriorityInQueueNotificationViewModel(CreateBase())
            {
                CustomerId = 250021,
                EventDate = DateTime.Now.AddDays(10),
                EventId = 12,
                HospitalPartner = "[Hospital Partner Name]",
                Pod = "[Pod Name]",
                PriorityInQueueNote = "[Reason for priority in Queue]",
                Tests = tests
            };
        }

        public EvaluationReminderNotificationViewModel GetEvaluationReminderNotificationModel(long physicianId)
        {
            var overReadEvaluationPair = _physicianRepository.GetEventCustomerIdForOverReadPhysicianEvaluation(physicianId);
            var evaluationPair = _physicianRepository.GetEventCustomerIdForPhysicianEvaluation(physicianId);

            var physician = _physicianRepository.GetPhysician(physicianId);
            return new EvaluationReminderNotificationViewModel(CreateBase())
                       {
                           PhysicianName = physician.Name.FullName,
                           PrimaryEvaluationQueueCount = evaluationPair.ItemsAvailable,
                           OverReadEvaluationQueueCount = overReadEvaluationPair.ItemsAvailable,
                           CriticalEvaluationQueueCount =
                               evaluationPair.CriticalsInQueue + overReadEvaluationPair.CriticalsInQueue
                       };
        }

        public EvaluationReminderNotificationViewModel GetDummyEvaluationReminderNotificationModel()
        {
            return new EvaluationReminderNotificationViewModel(CreateBase())
                {
                    CriticalEvaluationQueueCount = 2,
                    OverReadEvaluationQueueCount = 20,
                    PhysicianName = "[Physician Name]",
                    PrimaryEvaluationQueueCount = 15
                };
        }

        public SentBackForCorrectionNotificationViewModel GetSentBackForCorrectionModel(long eventId, long customerId)
        {
            throw new NotImplementedException();
        }

        public ResultReadyNotificationViewModel GetResultReadyModel(string customerName, string userName, bool isPaperCopyPurchased, long eventId)
        {
            var hospitalPartnerLogoFilePathUrl = string.Empty;
            var hospitalPartnerId = _hospitalPartnerRepository.GetHospitalPartnerIdForEvent(eventId);
            if (hospitalPartnerId > 0)
            {
                var organization = _organizationRepository.GetOrganizationbyId(hospitalPartnerId);
                if (organization != null && organization.LogoImageId > 0)
                {
                    var file = _fileRepository.GetById(organization.LogoImageId);
                    if (file != null)
                    {
                        var location = _mediaRepository.GetOrganizationLogoImageFolderLocation();
                        hospitalPartnerLogoFilePathUrl = location.Url + file.Path;
                    }
                }
            }
            return new ResultReadyNotificationViewModel(CreateBase())
            {
                CustomerName = customerName,
                UserName = userName,
                IsPaperCopyPurchased = isPaperCopyPurchased,
                HospitalPartnerLogoFilePathUrl = hospitalPartnerLogoFilePathUrl
            };
        }

        public ResultReadyNotificationViewModel GetDummyResultReadyModel()
        {
            return new ResultReadyNotificationViewModel(this.CreateBase())
                {
                    CustomerName = "[Customer Name]",
                    IsPaperCopyPurchased = true,
                    UserName = "[User_Name]"
                };
        }

        public AppointmentConfirmationViewModel GetDummyDataAppointmentConfirmationModel()
        {
            return new AppointmentConfirmationViewModel(CreateBase())
            {
                CustomerName = "[Customer Name]",
                EventDate = DateTime.Now,
                AppointmentTime = DateTime.Now,
                LocationName = "Location Name",
                AddressOfVenue = new AddressViewModel()
                {
                    StreetAddressLine1 = "[Dummy Address 1]",
                    StreetAddressLine2 = "",
                    City = "[Dummy City]",
                    State = "[Dummy State]",
                    ZipCode = "[Dummy Zip]",
                    Country = "USA"
                },
                Packages = new Package()
                {
                    Description = "[Dummy Package Description]",
                    Name = "[Dummy Package Name]",
                    Tests = new List<Test>(){ new Test()
                                                {
                                                    Name = "[Dummy Test A]", Price = 50
                                                }, new Test()
                                                {
                                                    Name = "[Dummy Test B]", Price = 40
                                                },new Test()
                                                {
                                                    Name = "[Dummy Test C]", Price = 34
                                                },new Test()
                                                {
                                                    Name = "[Dummy Test D]", Price = 60
                                                } }
                },
                Tests = null,
                TotalDue = 179,
                AddlnProductPrice = 0,
                PackagePrice = 174,
                PaymentStatus = "Paid",
                ShippingPrice = 5,
                PcpPhoneNumber = "543-343-4767",
                CustomerFirstName = "First Name",
                CustomerId = 123456789
            };
        }

        public AmountRefundNotificationViewModel GetAmountRefundNotificationViewModel(string fullName, decimal amountRefunded)
        {
            return new AmountRefundNotificationViewModel(CreateBase())
            {
                FullName = fullName,
                AmountRefunded = amountRefunded
            };
        }

        public AmountRefundNotificationViewModel GetDummyAmountRefundNotificationViewModel()
        {
            return new AmountRefundNotificationViewModel(this.CreateBase())
                {
                    AmountRefunded = 20,
                    FullName = "[Customer Name]"
                };
        }

        public AnnualReminderNotificationViewModel GetAnnualReminderNotificationViewModel(Customer customer, string sourceCode, string checkOutUrl, string annualReminderPhoneTollFree, IEnumerable<OnlineSchedulingEventViewModel> events)
        {
            var eventCustomers = _eventCustomerRepository.GetbyCustomerId(customer.CustomerId);

            var eventIds = eventCustomers.Where(ec => ec.AppointmentId.HasValue && !ec.NoShow && !ec.LeftWithoutScreeningReasonId.HasValue).Select(ec => ec.EventId).ToArray();

            var screenedEvents = _eventRepository.GetEventswithPodbyIds(eventIds);
            var lastScreenedEvent = screenedEvents.Select(se => se).OrderBy(se => se.EventDate).Last();
            var eventHostViewData = _eventService.GetById(lastScreenedEvent.Id);

            return new AnnualReminderNotificationViewModel(CreateBase())
                      {
                          CustomerName = customer.Name.FullName,
                          SourceCode = sourceCode,
                          CheckOutUrl = checkOutUrl,
                          AnnualReminderPhoneTollFree = annualReminderPhoneTollFree,
                          Events = events,
                          CustomerAddress = new AddressViewModel
                                                {
                                                    StreetAddressLine1 = customer.Address.StreetAddressLine1,
                                                    StreetAddressLine2 = customer.Address.StreetAddressLine2,
                                                    City = customer.Address.City,
                                                    State = customer.Address.State,
                                                    ZipCode = customer.Address.ZipCode.Zip,
                                                    Country = customer.Address.Country
                                                },
                          LastScreeningDate = lastScreenedEvent.EventDate,
                          LastScreeningLocation = new AddressViewModel
                                                      {
                                                          StreetAddressLine1 = eventHostViewData.StreetAddressLine1,
                                                          StreetAddressLine2 = eventHostViewData.StreetAddressLine2,
                                                          City = eventHostViewData.City,
                                                          State = eventHostViewData.State,
                                                          ZipCode = eventHostViewData.Zip,
                                                          Country = "USA"
                                                      }

                      };
        }

        public AnnualReminderNotificationViewModel GetDummyAnnualReminderNotificationViewModel()
        {
            return new AnnualReminderNotificationViewModel(CreateBase())
                       {
                           CustomerName = "[Customer Name 1]",
                           SourceCode = "",
                           CheckOutUrl = _settings.AppUrl + "/Scheduling/Online/AnnualReminderCheckout?Radius=50&ZipCode=17011",
                           AnnualReminderPhoneTollFree = _settings.AnnualReminderPhoneTollFree,
                           CustomerAddress = new AddressViewModel
                           {
                               StreetAddressLine1 = "[Dummy Address 1]",
                               StreetAddressLine2 = "",
                               City = "[Dummy City]",
                               State = "[Dummy State]",
                               ZipCode = "[Dummy Zip]",
                               Country = "USA"
                           },
                           LastScreeningLocation = new AddressViewModel
                           {
                               StreetAddressLine1 = "[Dummy Address 1]",
                               StreetAddressLine2 = "",
                               City = "[Dummy City]",
                               State = "[Dummy State]",
                               ZipCode = "[Dummy Zip]",
                               Country = "USA"
                           },
                           LastScreeningDate = DateTime.Now.AddYears(-1),
                           Events = new[]
                                        {
                                            new OnlineSchedulingEventViewModel
                                                {
                                                    EventId = 218,
                                                    EventDate = DateTime.Now,
                                                    HostName = "[Host Name]",
                                                    DistanceFromZip = 2,
                                                    SponsorImage = "",
                                                    EventLocation = new AddressViewModel
                                                                        {
                                                                            StreetAddressLine1 = "[StreetAddressLine1]",
                                                                            StreetAddressLine2 = "[StreetAddressLine2]",
                                                                            City = "[City]",
                                                                            State = "[State]",
                                                                            ZipCode = "[Zipcode]"
                                                                        }
                                                },
                                            new OnlineSchedulingEventViewModel
                                                {
                                                    EventId = 218,
                                                    EventDate = DateTime.Now,
                                                    HostName = "[Host Name]",
                                                    DistanceFromZip = 2,
                                                    SponsorImage = "",
                                                    EventLocation = new AddressViewModel
                                                                        {
                                                                            StreetAddressLine1 = "[StreetAddressLine1]",
                                                                            StreetAddressLine2 = "[StreetAddressLine2]",
                                                                            City = "[City]",
                                                                            State = "[State]",
                                                                            ZipCode = "[Zipcode]"
                                                                        }
                                                },
                                            new OnlineSchedulingEventViewModel
                                                {
                                                    EventId = 218,
                                                    EventDate = DateTime.Now,
                                                    HostName = "[Host Name]",
                                                    DistanceFromZip = 2,
                                                    SponsorImage = "",
                                                    EventLocation = new AddressViewModel
                                                                        {
                                                                            StreetAddressLine1 = "[StreetAddressLine1]",
                                                                            StreetAddressLine2 = "[StreetAddressLine2]",
                                                                            City = "[City]",
                                                                            State = "[State]",
                                                                            ZipCode = "[Zipcode]"
                                                                        }
                                                }
                                        }
                       };
        }

        public SurveyEmailNotificationModel GetSurveyNotificationModel(Customer customer, Event @event, IEnumerable<Pod> pods)
        {
            var hospitalPartnerLogoFilePathUrl = string.Empty;
            var hospitalPartnerId = _hospitalPartnerRepository.GetHospitalPartnerIdForEvent(@event.Id);
            if (hospitalPartnerId > 0)
            {
                var organization = _organizationRepository.GetOrganizationbyId(hospitalPartnerId);
                if (organization != null && organization.LogoImageId > 0)
                {
                    var file = _fileRepository.GetById(organization.LogoImageId);
                    if (file != null)
                    {
                        var location = _mediaRepository.GetOrganizationLogoImageFolderLocation();
                        hospitalPartnerLogoFilePathUrl = location.Url + file.Path;
                    }
                }
            }

            return new SurveyEmailNotificationModel(this.CreateBase())
                {
                    CustomerId = customer.CustomerId,
                    CustomerName = customer.Name,
                    EventDate = @event.EventDate,
                    EventId = @event.Id,
                    PodName = string.Join(" ", @pods.Select(p => p.Name).ToArray()),
                    CustomerEmail = customer.Email != null ? customer.Email.ToString() : string.Empty,
                    HospitalPartnerLogoFilePathUrl = hospitalPartnerLogoFilePathUrl
                };
        }

        public SurveyEmailNotificationModel GetDummySurveyNotificationModel()
        {
            return new SurveyEmailNotificationModel(this.CreateBase())
            {
                CustomerId = 123456,
                CustomerName = new Name("Customer's", "", "Name's"),
                EventDate = DateTime.Now.AddDays(-1),
                EventId = 123,
                PodName = "vb001",
                CustomerEmail = "email@mailinator.com"
            };
        }

        public ProspectCustomerFollowupNotificationViewModel GetProspectCustomerFollowupNotificationViewModel(string fullName, string checkoutUrl, IEnumerable<OnlineSchedulingEventViewModel> events)
        {
            return new ProspectCustomerFollowupNotificationViewModel(CreateBase())
                       {
                           CustomerName = fullName,
                           CheckOutUrl = checkoutUrl,
                           Events = events
                       };
        }

        public ProspectCustomerFollowupNotificationViewModel GetDummyProspectCustomerFollowupNotificationViewModel()
        {
            return new ProspectCustomerFollowupNotificationViewModel(CreateBase())
            {
                CustomerName = "[Customer Name 1]",
                CheckOutUrl = _settings.AppUrl + "/Scheduling/Online/AnnualReminderCheckout?Radius=50&ZipCode=60015",
                Events = new[]
                                        {
                                            new OnlineSchedulingEventViewModel
                                                {
                                                    EventId = 26984,
                                                    EventDate = DateTime.Now,
                                                    HostName = "[Host Name]",
                                                    DistanceFromZip = 2,
                                                    SponsorImage = "",
                                                    EventLocation = new AddressViewModel
                                                                        {
                                                                            StreetAddressLine1 = "[StreetAddressLine1]",
                                                                            StreetAddressLine2 = "[StreetAddressLine2]",
                                                                            City = "[City]",
                                                                            State = "[State]",
                                                                            ZipCode = "[Zipcode]"
                                                                        }
                                                },
                                            new OnlineSchedulingEventViewModel
                                                {
                                                    EventId = 26984,
                                                    EventDate = DateTime.Now,
                                                    HostName = "[Host Name]",
                                                    DistanceFromZip = 2,
                                                    SponsorImage = "",
                                                    EventLocation = new AddressViewModel
                                                                        {
                                                                            StreetAddressLine1 = "[StreetAddressLine1]",
                                                                            StreetAddressLine2 = "[StreetAddressLine2]",
                                                                            City = "[City]",
                                                                            State = "[State]",
                                                                            ZipCode = "[Zipcode]"
                                                                        }
                                                },
                                            new OnlineSchedulingEventViewModel
                                                {
                                                    EventId = 26984,
                                                    EventDate = DateTime.Now,
                                                    HostName = "[Host Name]",
                                                    DistanceFromZip = 2,
                                                    SponsorImage = "",
                                                    EventLocation = new AddressViewModel
                                                                        {
                                                                            StreetAddressLine1 = "[StreetAddressLine1]",
                                                                            StreetAddressLine2 = "[StreetAddressLine2]",
                                                                            City = "[City]",
                                                                            State = "[State]",
                                                                            ZipCode = "[Zipcode]"
                                                                        }
                                                }
                                        }
            };
        }

        public EventFillingNotificationViewModel GetEventFillingNotificationViewModel(long eventId, int totalSlots, int availableSlots)
        {
            var eventHostViewData = _eventService.GetById(eventId);
            var pods = _podRepository.GetPodsForEvent(eventId);
            return new EventFillingNotificationViewModel(CreateBase())
                       {
                           EventId = eventHostViewData.EventId,
                           EventDate = eventHostViewData.EventDate,
                           TotalSlots = totalSlots,
                           AvailableSlots = availableSlots,
                           Pods = pods != null && pods.Any() ? string.Join(",", pods.Select(p => p.Name)) : string.Empty,
                           AddressOfVenue = new AddressViewModel
                                                {
                                                    StreetAddressLine1 = eventHostViewData.StreetAddressLine1,
                                                    StreetAddressLine2 = eventHostViewData.StreetAddressLine2,
                                                    City = eventHostViewData.City,
                                                    State = eventHostViewData.State,
                                                    ZipCode = eventHostViewData.Zip,
                                                    Country = "USA"
                                                },
                       };
        }

        public EventFillingNotificationViewModel GetDummyEventFillingNotificationViewModel()
        {
            return new EventFillingNotificationViewModel(CreateBase())
                       {
                           EventId = 1234,
                           EventDate = DateTime.Now,
                           TotalSlots = 40,
                           AvailableSlots = 20,
                           Pods = "VB006",
                           AddressOfVenue = new AddressViewModel()
                                                {
                                                    StreetAddressLine1 = "[Dummy Address 1]",
                                                    StreetAddressLine2 = "",
                                                    City = "[Dummy City]",
                                                    State = "[Dummy State]",
                                                    ZipCode = "[Dummy Zip]",
                                                    Country = "USA"
                                                },
                       };
        }

        public PurchaseShippingNotificationViewModel GetPurchaseShippingNotificationViewModel(long eventId, long customerId)
        {
            var eventHostViewData = _eventService.GetById(eventId);
            var customer = _customerRepository.GetCustomer(customerId);

            return new PurchaseShippingNotificationViewModel(CreateBase())
                       {
                           EventId = eventHostViewData.EventId,
                           EventDate = eventHostViewData.EventDate,
                           AddressOfVenue = new AddressViewModel
                                                {
                                                    StreetAddressLine1 = eventHostViewData.StreetAddressLine1,
                                                    StreetAddressLine2 = eventHostViewData.StreetAddressLine2,
                                                    City = eventHostViewData.City,
                                                    State = eventHostViewData.State,
                                                    ZipCode = eventHostViewData.Zip,
                                                    Country = "USA"
                                                },
                           CustomerId = customer.CustomerId,
                           CustomerName = customer.Name.FullName
                       };
        }

        public PurchaseShippingNotificationViewModel GetDummyPurchaseShippingNotificationViewModel()
        {
            return new PurchaseShippingNotificationViewModel(CreateBase())
                       {
                           EventId = 1234,
                           EventDate = DateTime.Now,
                           AddressOfVenue = new AddressViewModel()
                                                {
                                                    StreetAddressLine1 = "[Dummy Address 1]",
                                                    StreetAddressLine2 = "",
                                                    City = "[Dummy City]",
                                                    State = "[Dummy State]",
                                                    ZipCode = "[Dummy Zip]",
                                                    Country = "USA"
                                                },
                           CustomerId = 12345,
                           CustomerName = "[Customer Name]"
                       };
        }

        public UrgentCustomerNotificationViewModel GetUrgentCustomerNotificationModel(long eventId, long customerId, IEnumerable<TestResultStatusViewModel> urgentTests)
        {
            var customer = _customerRepository.GetCustomer(customerId);

            var eventHostViewData = _eventService.GetById(eventId);
            var eventCustomer = _eventCustomerRepository.Get(eventId, customerId);

            if (!urgentTests.Any())
                return null;

            var tests = _testRepository.GetByIds(urgentTests.Select(tr => tr.TestId).ToArray());

            var pods = _podRepository.GetPodsForEvent(eventId);

            var hospitalPartnerId = _hospitalPartnerRepository.GetHospitalPartnerIdForEvent(eventId);

            var healthPlan = _corporateAccountRepository.GetbyEventId(eventId);

            Organization organization = null;
            if (hospitalPartnerId > 0)
            {
                organization = _organizationRepository.GetOrganizationbyId(hospitalPartnerId);
            }

            var healthPlanName = "N/A";

            if (healthPlan != null && healthPlan.IsHealthPlan)
            {
                var healthPlanorganization = _organizationRepository.GetOrganizationbyId(healthPlan.Id);
                if (healthPlanorganization != null)
                    healthPlanName = healthPlanorganization.Name;
            }

            var model = new UrgentCustomerNotificationViewModel(CreateBase())
                {
                    CustomerId = customer.CustomerId,
                    MemberId = string.IsNullOrEmpty(customer.InsuranceId) ? "N/A" : customer.InsuranceId,
                    EventId = eventId,
                    EventDate = eventHostViewData.EventDate,
                    Pod = string.Join(", ", pods.Select(ep => ep.Name)),
                    HospitalPartner = organization != null ? organization.Name : "N/A",
                    HealthPlan = healthPlanName,
                    HospitalRelease =
                        organization != null
                            ? (int)eventCustomer.PartnerRelease > 0
                                  ? EnumExtensions.GetDescription(eventCustomer.PartnerRelease)
                                  : EnumExtensions.GetDescription(RegulatoryState.Unknown)
                            : "N/A"
                };
            var urgentDataViewModels = new List<CustomerEventUrgentTestDataViewModel>();

            foreach (var test in tests)
            {
                var urgentTest = urgentTests.Single(ur => ur.TestId == test.Id);
                var urgentDataViewModel = new CustomerEventUrgentTestDataViewModel
                {
                    TestName = test.Name,
                    TestId = urgentTest.TestId,
                    PhysicianName = urgentTest.EvaluatedBy,
                    PhysicianRemarks = string.IsNullOrEmpty(urgentTest.PhysicianRemarks) ? "N/A" : urgentTest.PhysicianRemarks
                };

                urgentDataViewModels.Add(urgentDataViewModel);
            }
            model.Tests = urgentDataViewModels;
            return model;
        }

        public UrgentCustomerNotificationViewModel GetDummyUrgentCustomerNotificationModel()
        {
            return new UrgentCustomerNotificationViewModel(CreateBase())
            {
                CustomerId = 250021,
                EventDate = DateTime.Now.AddDays(10),
                MemberId = "[Member Id]",
                EventId = 12,
                HospitalPartner = "[Hospital Partner Name]",
                HealthPlan = "[Healthplan Name]",
                HospitalRelease = EnumExtensions.GetDescription(RegulatoryState.Signed),
                Pod = "[Pod Name]",
                Tests =
                    new[]
                            {
                                new CustomerEventUrgentTestDataViewModel
                                    {
                                        TestId = 1,
                                        TestName = "Text X",
                                        PhysicianName = "Physician A",
                                        PhysicianRemarks = "Some Remarks"
                                    },
                                    new CustomerEventUrgentTestDataViewModel
                                    {
                                        TestId = 1,
                                        TestName = "Text Y",
                                        PhysicianName = "Physician B",
                                        PhysicianRemarks = "Some Remarks"
                                    }
                            }
            };
        }

        public TestUpsellNotificationModel GetTestUpsellNotificationModel(Customer customer, IEnumerable<Test> tests)
        {
            return new TestUpsellNotificationModel(CreateBase())
                {
                    CustomerId = customer.CustomerId,
                    CustomerName = customer.Name.FullName,
                    Tests = tests
                };
        }

        public TestUpsellNotificationModel GetDummyTestUpsellNotificationModel()
        {
            return new TestUpsellNotificationModel(CreateBase())
                {
                    CustomerId = 123456,
                    CustomerName = "Customer Name",
                    Tests = new[]
                        {
                            new Test
                                {
                                    Name = "Thyroid",
                                    Description = "Thyroid Description"
                                },
                            new Test
                                {
                                    Name = "PSA",
                                    Description = "PSA Description"
                                },
                            new Test
                                {
                                    Name = "CRP",
                                    Description = "CRP Description"
                                },
                        }
                };
        }

        public EventResultReadyNotificationViewModel GetEventResultReadyNotificationViewModel(User user, EventHostViewData eventHostViewData)
        {
            var pods = _podRepository.GetPodsForEvent(eventHostViewData.EventId);

            return new EventResultReadyNotificationViewModel(CreateBase())
                {
                    Name = user.Name.FullName,
                    EventName = eventHostViewData.OrganizationName,
                    EventId = eventHostViewData.EventId,
                    EventDate = eventHostViewData.EventDate,
                    Pods = pods != null && pods.Any() ? string.Join(",", pods.Select(p => p.Name)) : string.Empty,
                    AddressOfVenue = new AddressViewModel
                                        {
                                            StreetAddressLine1 = eventHostViewData.StreetAddressLine1,
                                            StreetAddressLine2 = eventHostViewData.StreetAddressLine2,
                                            City = eventHostViewData.City,
                                            State = eventHostViewData.State,
                                            ZipCode = eventHostViewData.Zip,
                                            Country = "USA"
                                        },
                };
        }

        public EventResultReadyNotificationViewModel GetDummyEventResultReadyNotificationViewModel()
        {
            return new EventResultReadyNotificationViewModel(CreateBase())
             {
                 Name = "Care Coordinator Name",
                 EventName = "Test Event",
                 EventId = 1234,
                 EventDate = DateTime.Now,
                 Pods = "[Pod Name]",
                 AddressOfVenue = new AddressViewModel()
                 {
                     StreetAddressLine1 = "[Dummy Address 1]",
                     StreetAddressLine2 = "",
                     City = "[Dummy City]",
                     State = "[Dummy State]",
                     ZipCode = "[Dummy Zip]",
                     Country = "USA"
                 },
             };
        }

        public KynNotificationViewModel GetKynNotificationViewModel(Customer customer, EventHostViewData eventHostViewData, Appointment appointment, bool isDemographicInfoFilled, bool isHafFilled)
        {
            return new KynNotificationViewModel(CreateBase())
            {
                CustomerName = customer.NameAsString,
                UserId = customer.Id,
                CustomerId = customer.CustomerId,
                AppointmentTime = appointment.StartTime,
                EventDate = eventHostViewData.EventDate,
                EventName = eventHostViewData.OrganizationName,
                AddressOfVenue = new AddressViewModel
                                        {
                                            StreetAddressLine1 = eventHostViewData.StreetAddressLine1,
                                            StreetAddressLine2 = eventHostViewData.StreetAddressLine2,
                                            City = eventHostViewData.City,
                                            State = eventHostViewData.State,
                                            ZipCode = eventHostViewData.Zip,
                                            Country = "USA"
                                        },
                IsDemographicInfoFilled = isDemographicInfoFilled,
                IsHafFilled = isHafFilled
            };
        }

        public KynNotificationViewModel GetDummyKynNotificationViewModel()
        {
            return new KynNotificationViewModel(CreateBase())
            {
                CustomerName = "Customer Name",
                CustomerId = 123456,
                UserId = 343535,
                AppointmentTime = DateTime.Now,
                EventDate = DateTime.Now,
                EventName = "[Dummy Event Name]",
                AddressOfVenue = new AddressViewModel()
                {
                    StreetAddressLine1 = "[Dummy Address 1]",
                    StreetAddressLine2 = "",
                    City = "[Dummy City]",
                    State = "[Dummy State]",
                    ZipCode = "[Dummy Zip]",
                    Country = "USA"
                },
            };
        }

        public PpCustomersResultReadyEmailNotificationModel GetPpCustomerResultNotificationModel(Customer customer, PrimaryCarePhysician primaryCarePhysician)
        {
            return new PpCustomersResultReadyEmailNotificationModel(CreateBase())
         {
             CustomerId = customer.CustomerId,
             CustomerName = customer.Name,
             PcpName = primaryCarePhysician.Name.ToString(),
             PcpPhone = primaryCarePhysician.Primary != null ? primaryCarePhysician.Primary.ToString() : string.Empty
         };
        }

        public PpCustomersResultReadyEmailNotificationModel GetDummyPpCustomerResultNotificationModel()
        {
            return new PpCustomersResultReadyEmailNotificationModel(CreateBase())
            {
                CustomerId = 123456,
                CustomerName = new Name("Customer's", "", "Name's"),
                PcpName = "Jone Doe",
                PcpPhone = new PhoneNumber("211", "2345678", PhoneNumberType.Office).ToString(),
            };
        }

        public EventFullNotificationViewModel GetEventFullNotificationViewModel(long eventId, int totalSlots)
        {
            var eventHostViewData = _eventService.GetById(eventId);
            var pods = _podRepository.GetPodsForEvent(eventId);
            return new EventFullNotificationViewModel(CreateBase())
            {
                EventId = eventHostViewData.EventId,
                EventDate = eventHostViewData.EventDate,
                TotalSlots = totalSlots,
                Pods = pods != null && pods.Any() ? string.Join(",", pods.Select(p => p.Name)) : string.Empty,
                AddressOfVenue = new AddressViewModel
                {
                    StreetAddressLine1 = eventHostViewData.StreetAddressLine1,
                    StreetAddressLine2 = eventHostViewData.StreetAddressLine2,
                    City = eventHostViewData.City,
                    State = eventHostViewData.State,
                    ZipCode = eventHostViewData.Zip,
                    Country = "USA"
                },
            };
        }

        public EventFullNotificationViewModel GetDummyEventFullNotificationViewModel()
        {
            return new EventFullNotificationViewModel(CreateBase())
            {
                EventId = 1234,
                EventDate = DateTime.Now,
                TotalSlots = 40,
                Pods = "VB006",
                AddressOfVenue = new AddressViewModel()
                {
                    StreetAddressLine1 = "[Dummy Address 1]",
                    StreetAddressLine2 = "",
                    City = "[Dummy City]",
                    State = "[Dummy State]",
                    ZipCode = "[Dummy Zip]",
                    Country = "USA"
                },
            };
        }

        public LoginOtpEmailNotificationViewModel GetLoginOtpEmailNotificationViewModel(long userId, string otp, string expirationMin)
        {
            var customerData = _userRepository.GetUser(userId);
            return new LoginOtpEmailNotificationViewModel(CreateBase())
            {
                UserName = customerData.Name.FullName,
                Otp = otp,
                ExpirationMinutes = expirationMin
            };
        }

        public LoginOtpEmailNotificationViewModel GetDummyLoginOtpEmailNotificationViewModel()
        {
            return new LoginOtpEmailNotificationViewModel(CreateBase())
            {
                UserName = "[Dummy Name]",
                Otp = "123456",
                ExpirationMinutes = "60"
            };
        }
        public CustomerTagChangeNotificationViewModel GetCustomerTagChangeNotificationViewModel(long oldEventId, long newEventId, long customerId, string previousTag)
        {
            var customer = _customerRepository.GetCustomer(customerId);
            var eventHostViewDataO = oldEventId > 0 ? _eventService.GetById(oldEventId) : null;
            var eventHostViewDataN = _eventService.GetById(newEventId);

            var corporatelst = new List<long>();
            if (oldEventId > 0) corporatelst.Add(oldEventId);
            if (newEventId > 0) corporatelst.Add(newEventId);
            var corporateAccountNames = _corporateAccountRepository.GetEventIdCorporateAccountNamePair(corporatelst).ToList();
            var corporateAccountO = corporateAccountNames.FirstOrDefault(x => x.FirstValue == oldEventId);
            var corporateAccountN = corporateAccountNames.FirstOrDefault(x => x.FirstValue == newEventId);

            var oldSponser = _settings.CompanyName;
            var newSponser = _settings.CompanyName;

            //var corporateO = _corporateAccountRepository.GetbyEventId(oldEventId);
            var corporateN = _corporateAccountRepository.GetbyEventId(newEventId);
            if (corporateAccountO == null)
            {
                var lst = new List<long>(); lst.Add(oldEventId);
                var hospitalPartnerNames = _hospitalPartnerRepository.GetEventIdHospitalPartnerNamePair(lst);

                if (!hospitalPartnerNames.IsNullOrEmpty())
                {
                    var sponserName = hospitalPartnerNames.First();
                    oldSponser = sponserName != null ? sponserName.SecondValue : _settings.CompanyName;
                }
            }
            if (corporateAccountN == null)
            {
                var lst = new List<long>(); lst.Add(newEventId);
                var hospitalPartnerNames = _hospitalPartnerRepository.GetEventIdHospitalPartnerNamePair(lst);

                if (!hospitalPartnerNames.IsNullOrEmpty())
                {
                    var sponserName = hospitalPartnerNames.First();
                    newSponser = sponserName != null ? sponserName.SecondValue : _settings.CompanyName;
                }

            }
            return new CustomerTagChangeNotificationViewModel(CreateBase())
            {
                CustomerName = customer.Name.FullName,
                CustomerId = customerId.ToString(),
                PreviousEventId = eventHostViewDataO != null ? eventHostViewDataO.EventId.ToString(CultureInfo.InvariantCulture) : "NA",
                PreviousEventDate = eventHostViewDataO != null ? eventHostViewDataO.EventDate.Date.ToString("MM/dd/yyyy") : "NA",
                PreviousTag = previousTag,//corporateO != null ? corporateO.Tag : "",
                PreviousSponser = eventHostViewDataO != null ? (corporateAccountO != null ? corporateAccountO.SecondValue : oldSponser) : "NA",

                NewEventId = eventHostViewDataN.EventId.ToString(CultureInfo.InvariantCulture),
                NewEventDate = eventHostViewDataN.EventDate.Date,
                NewTag = corporateN != null ? corporateN.Tag : "NA",
                NewSponser = corporateAccountN != null ? corporateAccountN.SecondValue : newSponser
            };
        }

        public CustomerTagChangeNotificationViewModel GetDummyCustomerTagChangeNotificationViewModel()
        {
            return new CustomerTagChangeNotificationViewModel(CreateBase())
            {
                CustomerName = "[Customer Name]",
                CustomerId = "12345",
                PreviousEventId = "11111",
                PreviousEventDate = DateTime.Now.Date.ToString("MM/dd/yyyy"),
                PreviousTag = "[Previous Tag]",
                PreviousSponser = "[Previous Sponser]",
                NewEventId = "22222",
                NewEventDate = DateTime.Now.Date,
                NewTag = "[New Tag]",
                NewSponser = "[New Sponser]"
            };
        }

        public EventLockedNotificationViewModel GetEventLockedNotificationViewModel(User user, EventHostViewData eventHostViewData)
        {
            var pods = _podRepository.GetPodsForEvent(eventHostViewData.EventId);

            return new EventLockedNotificationViewModel(CreateBase())
            {
                Name = user.NameAsString,
                EventName = eventHostViewData.OrganizationName,
                EventId = eventHostViewData.EventId,
                EventDate = eventHostViewData.EventDate,
                Pods = pods != null && pods.Any() ? string.Join(",", pods.Select(p => p.Name)) : string.Empty,
                AddressOfVenue = new AddressViewModel
                                    {
                                        StreetAddressLine1 = eventHostViewData.StreetAddressLine1,
                                        StreetAddressLine2 = eventHostViewData.StreetAddressLine2,
                                        City = eventHostViewData.City,
                                        State = eventHostViewData.State,
                                        ZipCode = eventHostViewData.Zip,
                                        Country = "USA"
                                    },

            };
        }

        public EventLockedNotificationViewModel GetDummyEventLockedNotificationViewModel()
        {
            return new EventLockedNotificationViewModel(CreateBase())
            {
                Name = "Account Coordinator Name",
                EventName = "Test Event",
                EventId = 1234,
                EventDate = DateTime.Now,
                Pods = "[Pod Name]",
                AddressOfVenue = new AddressViewModel()
                {
                    StreetAddressLine1 = "[Dummy Address 1]",
                    StreetAddressLine2 = "",
                    City = "[Dummy City]",
                    State = "[Dummy State]",
                    ZipCode = "[Dummy Zip]",
                    Country = "USA"
                },
            };
        }

        public NoShowCustomerNotificationViewModel GetDummyNoShowCustomerNotificationViewModel()
        {
            return new NoShowCustomerNotificationViewModel(CreateBase())
            {
                CustomerId = 123456789,
                EventId = 123456,
                EventName = "Test Event",
                EventDate = DateTime.Now,
                Pods = "[Pod Name]",
                AddressOfVenue = new AddressViewModel()
                {
                    StreetAddressLine1 = "[Dummy Address 1]",
                    StreetAddressLine2 = "",
                    City = "[Dummy City]",
                    State = "[Dummy State]",
                    ZipCode = "[Dummy Zip]",
                    Country = "USA"
                },

                AppointmentTime = DateTime.Now
            };
        }

        public NoShowCustomerNotificationViewModel GetNoShowCustomerNotificationViewModel(EventCustomer eventCustomer, Appointment appointment)
        {
            var eventHostViewData = _eventService.GetById(eventCustomer.EventId);
            var pods = _podRepository.GetPodsForEvent(eventCustomer.EventId);


            return new NoShowCustomerNotificationViewModel(CreateBase())
            {
                CustomerId = eventCustomer.CustomerId,
                EventId = eventHostViewData.EventId,
                EventName = eventHostViewData.OrganizationName,
                EventDate = eventHostViewData.EventDate,
                Pods = pods != null && pods.Any() ? string.Join(",", pods.Select(p => p.Name)) : string.Empty,
                AddressOfVenue = new AddressViewModel
                {
                    StreetAddressLine1 = eventHostViewData.StreetAddressLine1,
                    StreetAddressLine2 = eventHostViewData.StreetAddressLine2,
                    City = eventHostViewData.City,
                    State = eventHostViewData.State,
                    ZipCode = eventHostViewData.Zip,
                    Country = "USA"
                },

                AppointmentTime = appointment.StartTime
            };
        }

        public CorporateUploadNotificationViewModel GetDummyCorporateUploadNotificationViewModel()
        {
            return new CorporateUploadNotificationViewModel(CreateBase())
            {
                CorporateName = "ABC Corporate",
                DateOfUpload = DateTime.Now,
                UploadedBy = "XZY Agent",
                TotalCustomers = 10,
                UploadedCustomers = 8,
                FailedCustomers = 2
            };
        }
        public CorporateUploadNotificationViewModel GetCorporateUploadNotificationViewModel(string corporateName, string uploadedBy, long totalCustomers, long uploadedCustomers, long failedCustomers)
        {
            return new CorporateUploadNotificationViewModel(CreateBase())
            {
                CorporateName = corporateName,
                DateOfUpload = DateTime.Now,
                UploadedBy = uploadedBy,
                TotalCustomers = totalCustomers,
                UploadedCustomers = uploadedCustomers,
                FailedCustomers = failedCustomers
            };
        }

        public DirectMailActivityNotificationViewModel GetDummyDirectMailActivityNotificationViewModel()
        {
            return new DirectMailActivityNotificationViewModel(CreateBase())
            {
                UserName = "User Name",
                CampaignName = "Campaign Name",
                HealthPlan = "HealthPlan Name",
                CustomTags = "Custom Tags",
            };
        }
        public DirectMailActivityNotificationViewModel GetDirectMailActivityNotificationViewModel(string userName, string campaignName, string healthPlan, string customTags)
        {
            return new DirectMailActivityNotificationViewModel(CreateBase())
            {
                UserName = userName,
                CampaignName = campaignName,
                HealthPlan = healthPlan,
                CustomTags = customTags,
            };
        }

        public IneligibleCustomerAppointmentNotificationViewModel GetDummyIneligibleCustomerAppointmentNotificationViewModel()
        {
            return new IneligibleCustomerAppointmentNotificationViewModel(CreateBase())
            {
                CustomerId = 1001,
                CustomerName = "[Customer Name]",
                EventId = 101,
                EventDate = DateTime.Now,
                Tag = "[Tag]"

            };
        }
        public IneligibleCustomerAppointmentNotificationViewModel GetIneligibleCustomerAppointmentNotificationViewModel(Customer customer, Event eventInfo)
        {
            return new IneligibleCustomerAppointmentNotificationViewModel(CreateBase())
            {
                CustomerId = customer.CustomerId,
                CustomerName = customer.Name.FullName,
                EventId = eventInfo.Id,
                EventDate = eventInfo.EventDate,
                Tag = (!string.IsNullOrEmpty(customer.Tag)) ? customer.Tag : "N/A"
            };
        }

        public CustomerExportableReportsNotificationViewModel GetDummyCustomerExportableReportsNotificationViewModel()
        {
            return new CustomerExportableReportsNotificationViewModel(CreateBase())
            {
                Name = "[Customer Name]",
                ExportableReport = "[Report Name]"
            };
        }
        public CustomerExportableReportsNotificationViewModel GetCustomerExportableReportsNotificationViewModel(string name, string exportableReport)
        {
            return new CustomerExportableReportsNotificationViewModel(CreateBase())
            {
                Name = name,
                ExportableReport = exportableReport
            };
        }

        public CancelRescheduleAppointmentNotification GetDummyCancelRescheduleAppointmentNotificationViewModel()
        {
            return new CancelRescheduleAppointmentNotification(CreateBase())
            {
                CustomerName = "[Customer Name]",
                EventId = 999999,
                NewEventId = 123456,
                NewEventDate = DateTime.Now.AddDays(5),
                IsCancelAppointment = false,
                Reason = "[Some Reason Added]",
                SubReason = "[Some SubReason Added]"
            };
        }
        public CancelRescheduleAppointmentNotification GetCancelRescheduleAppointmentNotificationViewModel(string customerName, long eventId, long newEventId, DateTime? newEventDate, bool isCancelAppointment, string reason, string subReason)
        {
            return new CancelRescheduleAppointmentNotification(CreateBase())
            {
                CustomerName = customerName,
                EventId = eventId,
                NewEventId = newEventId,
                NewEventDate = newEventDate,
                IsCancelAppointment = isCancelAppointment,
                Reason = reason,
                SubReason = subReason
            };
        }

        public PatientLeftNotificationViewModel GetPatientLeftNotificationViewModel(long eventCustomerId, long? leftWithoutScreeningReasonId, string notes, long currentUserId)
        {
            var eventCustomer = _eventCustomerRepository.GetById(eventCustomerId);

            var eventHostViewData = _eventService.GetById(eventCustomer.EventId);
            var customer = _customerRepository.GetCustomer(eventCustomer.CustomerId);

            var technician = _userRepository.GetUser(currentUserId);

            var reason = leftWithoutScreeningReasonId.HasValue ? EnumExtension.GetDescription(((LeftWithoutScreeningReason)leftWithoutScreeningReasonId.Value)) : "N/A";

            var pods = _podRepository.GetPodsForEvent(eventCustomer.EventId);

            return new PatientLeftNotificationViewModel(CreateBase())
            {
                CustomerId = customer.CustomerId,
                CustomerName = customer.Name.FullName,
                MemberId = !string.IsNullOrEmpty(customer.InsuranceId) ? customer.InsuranceId : "N/A",
                EventId = eventHostViewData.EventId,
                EventDate = eventHostViewData.EventDate,
                EventLocation = new AddressViewModel
                {
                    StreetAddressLine1 = eventHostViewData.StreetAddressLine1,
                    StreetAddressLine2 = eventHostViewData.StreetAddressLine2,
                    City = eventHostViewData.City,
                    State = eventHostViewData.State,
                    ZipCode = eventHostViewData.Zip,
                    Country = "USA"
                },
                User = technician.NameAsString,
                Tag = !string.IsNullOrEmpty(customer.Tag) ? customer.Tag : "N/A",
                Reason = reason,
                Pod = string.Join(", ", pods.Select(ep => ep.Name)),
                Notes = notes
            };
        }
        public PatientLeftNotificationViewModel GetDummyPatientLeftNotificationModel()
        {
            return new PatientLeftNotificationViewModel(CreateBase())
            {
                CustomerId = 250021,
                CustomerName = "[Customer Name]",
                MemberId = "[Member Id]",
                EventDate = DateTime.Now.AddDays(10),
                EventId = 12,
                User = "[Marked By Name]",
                Reason = "Reason",
                Tag = "Tag",
                EventLocation = new AddressViewModel
                {
                    StreetAddressLine1 = "[StreetAddressLine1]",
                    StreetAddressLine2 = "[StreetAddressLine2]",
                    City = "[City]",
                    State = "[State]",
                    ZipCode = "[Zipcode]"
                },
                Pod = "[Pod Name]",
                Notes = "Notes"
            };
        }

        public RecordSendBackForCorrectionNotificationViewModel GetRecordSendBackForCorrectionNotificationViewModel(long customerID, long eventID, long physicianId, string reasonNote)
        {
            var physician = _physicianRepository.GetPhysician(physicianId);
            return new RecordSendBackForCorrectionNotificationViewModel(CreateBase())
            {
                CustomerId = customerID,
                EventId = eventID,
                PhysicianName = physician != null ? physician.NameAsString : string.Empty,
                ReasonEntered = reasonNote
            };
        }
        public RecordSendBackForCorrectionNotificationViewModel GetDummyRecordSendBackForCorrectionNotificationViewModel()
        {
            return new RecordSendBackForCorrectionNotificationViewModel(CreateBase())
            {
                CustomerId = 020021,
                EventId = 12,
                PhysicianName = "[Physician Name]",
                ReasonEntered = "[Reason]"
            };
        }

        public HourlyAppointmentBookedReportNotificationViewModel GetDummyHourlyAppointmentBookedReportNotificationViewModel()
        {
            return new HourlyAppointmentBookedReportNotificationViewModel(CreateBase())
            {
                ReportName = "Appointment Booked Report",
                ExportPath = string.Format(@"PhysicalPath\HourlyAppointmentBookedReport_{0}.csv", DateTime.Now.ToString("yyyyMMdd"))
            };
        }
        public HourlyAppointmentBookedReportNotificationViewModel GetHourlyAppointmentBookedReportNotificationViewModel(string reportName, string exportPath)
        {
            return new HourlyAppointmentBookedReportNotificationViewModel(CreateBase())
            {
                ReportName = reportName,
                ExportPath = exportPath
            };
        }

        public HourlyOutreachNotificationViewModel GetDummyHourlyOutreachNotificationViewModel()
        {
            return new HourlyOutreachNotificationViewModel(CreateBase())
            {
                ReportName = "Outreach Call Report",
                ExportPath = string.Format(@"PhysicalPath\HourlyOutreachCallReport_{0}.csv", DateTime.Now.ToString("yyyyMMdd"))
            };
        }
        public HourlyOutreachNotificationViewModel GetHourlyOutreachNotificationViewModel(string reportName, string exportPath)
        {
            return new HourlyOutreachNotificationViewModel(CreateBase())
            {
                ReportName = reportName,
                ExportPath = exportPath
            };
        }

        public MergeCustomerNotificationViewModel GetDummyMergeCustomerViewModel()
        {
            return new MergeCustomerNotificationViewModel(CreateBase())
            {
                UploadId = 1,
                UploadDate = DateTime.Now,
                FileName = string.Format(@"MergeCustomer_{0}.csv", DateTime.Now.ToString("yyyyMMdd"))
            };
        }
        public MergeCustomerNotificationViewModel GetDummyWrongSmsResponseViewModel()
        {
            return new MergeCustomerNotificationViewModel(CreateBase())
            ;
        }
        public MergeCustomerNotificationViewModel GetMergeCustomerViewModel(long uploadId, DateTime uploadTime, string fileName)
        {
            return new MergeCustomerNotificationViewModel(CreateBase())
            {
                UploadId = uploadId,
                UploadDate = uploadTime,
                FileName = fileName
            };
        }

        public FileNotPostedNotificationViewModel GetDummyFileNotPostedViewModel()
        {
            return new FileNotPostedNotificationViewModel(CreateBase())
            {
                FailedCustomerCount = 0,
                Tag = "HealthPlan Tag"
            };
        }
        public FileNotPostedNotificationViewModel GetFileNotPostedViewModel(string tag, int failedCustomerCount)
        {
            return new FileNotPostedNotificationViewModel(CreateBase())
            {
                Tag = tag,
                FailedCustomerCount = failedCustomerCount
            };
        }

        public TestNotPerformedEmailNotificationViewModel GetDummyTestNotPerformedEmailNotificationViewModel()
        {
            return new TestNotPerformedEmailNotificationViewModel(CreateBase())
            {
                CustomerId = 250021,
                CustomerName = "[Customer Name]",
                EventDate = DateTime.Now.AddDays(10),
                EventId = 120,
                Reason = "[Reason]",
                Pod = "[Pod Name]",
                TestData = new List<TestNotPerformedNotificationTestViewModel> { 
                    new TestNotPerformedNotificationTestViewModel { TestName = "[Test Name]",ConductedBy = "[Updated By]",Notes="[Test not performed Notes]"},
                    new TestNotPerformedNotificationTestViewModel { TestName = "[Test Name]",ConductedBy = "[Updated By]",Notes="[Test not performed Notes]"},
                    new TestNotPerformedNotificationTestViewModel { TestName = "[Test Name]",ConductedBy = "[Updated By]",Notes="[Test not performed Notes]"},
                    new TestNotPerformedNotificationTestViewModel { TestName = "[Test Name]",ConductedBy = "[Updated By]",Notes="[Test not performed Notes]"}
                }
            };
        }
        public TestNotPerformedEmailNotificationViewModel GetTestNotPerformedEmailNotificationViewModel(long customerId, long eventId, string reason, IEnumerable<TestNotPerformedNotificationTestViewModel> testData)
        {
            var eventHostViewData = _eventService.GetById(eventId);
            var customer = _customerRepository.GetCustomer(customerId);
            var pods = eventHostViewData.Pods.IsNullOrEmpty() ? "N/A" : eventHostViewData.PodNames();

            return new TestNotPerformedEmailNotificationViewModel(CreateBase())
            {
                CustomerId = customerId,
                CustomerName = customer.Name.FullName,
                EventId = eventHostViewData.EventId,
                EventDate = eventHostViewData.EventDate,
                Pod = pods,
                Reason = reason,
                TestData = testData
            };
        }

        public ReTestNotificationViewModel GetDummyReTestNotificationViewModel()
        {
            return new ReTestNotificationViewModel(CreateBase())
            {
                PatientID = 250021,
                EventID = 120,
                ReTests = "[Test Name 1], [Test Name 2], [Test Name 3]"
            };
        }
        public ReTestNotificationViewModel GetReTestNotificationViewModel(long patientId, long eventId, long[] testIds)
        {
            var retests = _testRepository.GetByIds(testIds);
            return new ReTestNotificationViewModel(CreateBase())
            {
                PatientID = patientId,
                EventID = eventId,
                ReTests = string.Join(", ", retests.Select(x => x.Name)),
            };
        }

        public NonTargetedMemberRegistrationNotificationViewModel GetDummyNonTargetedMemberRegistrationNotificationViewModel()
        {
            return new NonTargetedMemberRegistrationNotificationViewModel(CreateBase())
            {
                PatientID = 250021,
                PatientName = "[Patient Name]",
                EventID = 12000,
                Healthplan = "[Healthplan]",
                Pod = "[Pod Name]"
            };
        }
        public NonTargetedMemberRegistrationNotificationViewModel GetNonTargetedMemberRegistrationNotificationViewModel(Customer customer, Event eventData, CorporateAccount account)
        {
            var pods = ((IUniqueItemRepository<Pod>)_podRepository).GetByIds(eventData.PodIds);

            var healthPlanName = "N/A";

            if (account != null && account.IsHealthPlan)
            {
                var healthPlanorganization = _organizationRepository.GetOrganizationbyId(account.Id);
                if (healthPlanorganization != null)
                    healthPlanName = healthPlanorganization.Name;
            }
            return new NonTargetedMemberRegistrationNotificationViewModel(CreateBase())
            {
                PatientID = customer.CustomerId,
                PatientName = customer.Name.FullName,
                EventID = eventData.Id,
                Healthplan = healthPlanName,
                Pod = string.Join(", ", pods.Select(ep => ep.Name)),
            };
        }

        public MammoPatientRegistrationOnNonMammoEventNotificationViewModel GetDummyMammoPatientRegestrationOnNonMammoEventViewModel()
        {
            return new MammoPatientRegistrationOnNonMammoEventNotificationViewModel(CreateBase())
            {
                CustomerId = 250021,
                CustomerName = "[Customer Name]",
                EventDate = DateTime.Now.AddDays(10),
                EventId = 120,
                Pod = "[Pod Name]",
                HealthPlan = "Test HealthPlan",
            };
        }
        public MammoPatientRegistrationOnNonMammoEventNotificationViewModel GetMammoPatientRegestrationOnNonMammoEventViewModel(Customer customer, Event eventData)
        {
            var pods = _podRepository.GetPodsForEvent(eventData.Id);

            var healthPlanName = "N/A";
            if (eventData.AccountId.HasValue && eventData.AccountId.Value > 0)
            {
                var organizatuon = _organizationRepository.GetOrganizationbyId(eventData.AccountId.Value);
                healthPlanName = organizatuon.Name;
            }

            return new MammoPatientRegistrationOnNonMammoEventNotificationViewModel(CreateBase())
            {
                CustomerId = customer.CustomerId,
                CustomerName = customer.Name.FullName,
                EventId = eventData.Id,
                EventDate = eventData.EventDate,
                HealthPlan = healthPlanName,
                Pod = string.Join(", ", pods.Select(ep => ep.Name))
            };
        }

        public SingleTestOverrideNotificationViewModel GetDummySingleTestOverrideNotificationViewModel()
        {
            return new SingleTestOverrideNotificationViewModel(CreateBase())
            {
                PatientID = 12345,
                EventID = 120
            };
        }
        public SingleTestOverrideNotificationViewModel GetSingleTestOverrideNotificationViewModel(long patientId, long eventId)
        {
            return new SingleTestOverrideNotificationViewModel(CreateBase())
            {
                PatientID = patientId,
                EventID = eventId
            };
        }

        public NPfordiagnosingwithlinkNotificationViewModel GetDummyNPfordiagnosingwithlinkNotificationViewModel()
        {
            return new NPfordiagnosingwithlinkNotificationViewModel(CreateBase())
            {
                PatientID = 12345,
                EventID = 120,
                UrlTestDocumentation = _settings.AppUrl + "/UrlTestDocumentation",
                UrlUnlockAssessment = _settings.AppUrl + "/UrlTestDocumentation",
                UrlTriggersReadyForCodingStatus = _settings.AppUrl + "/UrlTriggersReadyForCodingStatus"
            };
        }
        public NPfordiagnosingwithlinkNotificationViewModel GetNPfordiagnosingwithlinkNotificationViewModel(long patientId, long eventId, string UrlTestDocumentation, string UrlUnlockAssessment, string UrlTriggersReadyForCodingStatus)
        {
            return new NPfordiagnosingwithlinkNotificationViewModel(CreateBase())
            {
                PatientID = patientId,
                EventID = eventId,
                UrlTestDocumentation = UrlTestDocumentation,
                UrlUnlockAssessment = UrlUnlockAssessment,
                UrlTriggersReadyForCodingStatus = UrlTriggersReadyForCodingStatus
            };
        }

        public CoverLetterTemplateViewModel GetDummyCoverLetterTemplateViewModel()
        {
            return new CoverLetterTemplateViewModel(CreateBase())
            {
                CustomerName = "[Patient Name]",
                PcpName = "[PCP Name]",
                DoctorSignatureFilePathUrl = _settings.SignatureForCoverLetterRelativePath,
                LetterDate = DateTime.Today.ToString("dd-MM-yyyy")
            };

        }
        public CoverLetterTemplateViewModel GetCoverLetterTemplateViewModel(string customerName, string doctorSignatureFilePath, string pcpName, DateTime? letterDate)
        {
            return new CoverLetterTemplateViewModel(CreateBase())
            {
                CustomerName = customerName,
                PcpName = pcpName,
                DoctorSignatureFilePathUrl = doctorSignatureFilePath,
                LetterDate = letterDate.HasValue ? letterDate.Value.ToString("dd-MM-yyyy") : DateTime.Today.ToString("dd-MM-yyyy")
            };
        }

        public ListWithoutCustomTagsNotificationViewModel GetDummyListWithoutCustomTagsViewModel()
        {
            return new ListWithoutCustomTagsNotificationViewModel(CreateBase())
            {
                PatientwithoutCustomTagFileLocation = "[Patient without Custom Tag File Location]",
                FailedCustomerRecordFileLocation = "[Failed Customer Record File Location]",
                AdjustOrderFileLocation = "[Adjust Order File Location]"
            };
        }

        public ListWithoutCustomTagsNotificationViewModel GetListWithoutCustomTagsViewModel(string patientwithoutCustomTagFileLocation, string failedCustomerRecordFileLocation, string adjustOrderFileLocation)
        {
            return new ListWithoutCustomTagsNotificationViewModel(CreateBase())
            {
                PatientwithoutCustomTagFileLocation = patientwithoutCustomTagFileLocation,
                FailedCustomerRecordFileLocation = failedCustomerRecordFileLocation,
                AdjustOrderFileLocation = adjustOrderFileLocation,
            };
        }

        public AbsenceByMemberNotificationViewModel GetAbsenceByMemberViewModel(string tag, long CorporateUploadId)
        {
            return new AbsenceByMemberNotificationViewModel(CreateBase())
            {
                Tag = tag,
                CorporateUploadId = CorporateUploadId
            };
        }

        public AbsenceByMemberNotificationViewModel GetDummyAbsenceByMemberPostedViewModel()
        {
            return new AbsenceByMemberNotificationViewModel(CreateBase())
            {
                CorporateUploadId = 0,
                Tag = "HealthPlan Tag"
            };
        }
       
    }
}

