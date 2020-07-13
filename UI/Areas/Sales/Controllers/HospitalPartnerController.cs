using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Sales.Impl;
using Falcon.App.Core.ValueTypes;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Filters;

namespace Falcon.App.UI.Areas.Sales.Controllers
{
    [RoleBasedAuthorize]
    public class HospitalPartnerController : Controller
    {
        //
        // GET: /Sales/HospitalPartner/
        private readonly int _pageSize;
        private readonly IEventService _eventService;
        private readonly IHospitalPartnerService _hospitalPartnerService;
        private readonly ISessionContext _sessionContext;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly IHospitalPartnerCustomerRepository _hospitalPartnerCustomerRepository;
        private readonly IHospitalPartnerRepository _hospitalPartnerRepository;
        private readonly IPrimaryCarePhysicianRepository _primaryCarePhysicianRepository;
        private readonly IHealthAssessmentRepository _healthAssessmentRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly IHospitalFacilityRepository _hospitalFacilityRepository;


        public HospitalPartnerController(IEventService eventService, ISettings settings, IHospitalPartnerService hospitalPartnerService, ISessionContext sessionContext,
            IOrganizationRoleUserRepository organizationRoleUserRepository, IHospitalPartnerCustomerRepository hospitalPartnerCustomerRepository, IHospitalPartnerRepository hospitalPartnerRepository,
            IPrimaryCarePhysicianRepository primaryCarePhysicianRepository, IHealthAssessmentRepository healthAssessmentRepository, IEventCustomerRepository eventCustomerRepository,
            IHospitalFacilityRepository hospitalFacilityRepository)
        {
            _eventService = eventService;
            _pageSize = settings.DefaultPageSizeForReports;
            _hospitalPartnerService = hospitalPartnerService;
            _sessionContext = sessionContext;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _hospitalPartnerCustomerRepository = hospitalPartnerCustomerRepository;
            _hospitalPartnerRepository = hospitalPartnerRepository;
            _primaryCarePhysicianRepository = primaryCarePhysicianRepository;
            _healthAssessmentRepository = healthAssessmentRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _hospitalFacilityRepository = hospitalFacilityRepository;
        }

        public ActionResult EventCustomers(HospitalPartnerCustomerListModelFilter filter, int pageNumber = 1)
        {
            int totalRecords = 0;
            var model = _eventService.GetEventSummary(filter.EventId);

            if (_sessionContext.UserSession.CurrentOrganizationRole.RoleId == (long)Roles.HospitalPartnerCoordinator)
            {

                filter.HospitalPartnerId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationId;
            }
            else if (_sessionContext.UserSession.CurrentOrganizationRole.RoleId == (long)Roles.HospitalFacilityCoordinator)
            {
                filter.HospitalFacilityId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationId;
                filter.HospitalPartnerId = 0;
            }

            model.Customers = _hospitalPartnerService.GetHospitalPartnerEventCustomers(pageNumber, _pageSize, filter, out totalRecords) ??
                new HospitalPartnerCustomerListModel();

            model.Customers.Filter = filter;
            var currentAction = ControllerContext.RouteData.Values["action"].ToString();
            Func<int, string> urlFunc =
                pn => Url.Action(currentAction, new
                {
                    pageNumber = pn,
                    filter.EventId,
                    filter.HospitalPartnerId,
                    filter.HospitalFacilityId,
                    filter.SortingColumn,
                    filter.SortingOrder
                });

            model.Customers.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);
            return View(model);
        }

        public ActionResult SearchCustomers(HospitalPartnerCustomerListModelFilter filter = null, int pageNumber = 1)
        {
            var filterValidator = IoC.Resolve<HospitalPartnerCustomerListModelFilterValidator>();
            var result = filterValidator.Validate(filter);
            if (!result.IsValid)
            {
                var propertyNames = result.Errors.Select(e => e.PropertyName).Distinct();
                var htmlString = propertyNames.Aggregate("", (current, property) => current + (result.Errors.Where(e => e.PropertyName == property).FirstOrDefault().ErrorMessage + "<br />"));

                return View(new HospitalPartnerCustomerListModel { Filter = filter, FeedbackMessage = FeedbackMessageModel.CreateFailureMessage(htmlString) });
            }

            int totalRecords = 0;
            if (_sessionContext.UserSession.CurrentOrganizationRole.GetSystemRoleId == (long)Roles.HospitalPartnerCoordinator)
            {
                if (filter == null)
                    filter = new HospitalPartnerCustomerListModelFilter
                                 {
                                     HospitalPartnerId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationId
                                 };
                else
                    filter.HospitalPartnerId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationId;
            }
            else if (_sessionContext.UserSession.CurrentOrganizationRole.CheckRole((long)Roles.HospitalFacilityCoordinator))
            {
                if (filter == null)
                    filter = new HospitalPartnerCustomerListModelFilter
                    {
                        HospitalFacilityId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationId,
                        HospitalPartnerId = 0
                    };
                else
                {
                    filter.HospitalFacilityId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationId;
                    filter.HospitalPartnerId = 0;
                }
            }

            var model = _hospitalPartnerService.GetHospitalPartnerCustomers(pageNumber, _pageSize, filter, out totalRecords) ??
                new HospitalPartnerCustomerListModel();
            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();

            Func<int, string> urlFunc =
                pn => Url.Action(currentAction, new
                {
                    pageNumber = pn,
                    filter.FromDate,
                    filter.ToDate,
                    filter.HospitalPartnerId,
                    filter.HospitalFacilityId,
                    filter.CustomerId,
                    filter.CustomerName,
                    filter.Pod,
                    filter.ResultSummary,
                    filter.Status,
                    filter.DateType,
                    filter.PhoneNumber,
                    filter.CriticalMarkedByTechnician,
                    filter.SortingColumn,
                    filter.SortingOrder

                });

            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        public ActionResult EditHospitalPartnerCustomer(long eventId, long customerId)
        {
            var customerName = _organizationRoleUserRepository.GetNameIdPairofUsers(new[] { customerId }).First().SecondValue;

            var model = new HospitalPartnerCustomerEditModel { CustomerName = customerName, CustomerId = customerId, EventId = eventId };

            var pcp = _primaryCarePhysicianRepository.Get(customerId);
            if (pcp != null)
                model.PrimaryCarePhysicianName = pcp.Name.FullName;

            return View(model);
        }

        [HttpPost]
        public ActionResult EditHospitalPartnerCustomer(HospitalPartnerCustomerEditModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var currentSession = _sessionContext.UserSession.CurrentOrganizationRole;
                    var customer = Mapper.Map<HospitalPartnerCustomerEditModel, HospitalPartnerCustomer>(model);

                    customer.CareCoordinatorOrgRoleUserId = currentSession.OrganizationRoleUserId;
                    customer.DataRecorderMetaData = new DataRecorderMetaData(currentSession.OrganizationRoleUserId, DateTime.Now, DateTime.Now);

                    _hospitalPartnerCustomerRepository.Save(customer);

                    var eventCustomer = _eventCustomerRepository.Get(model.EventId, model.CustomerId);

                    SavePcp(model.CustomerId, model.PrimaryCarePhysicianName, currentSession.OrganizationRoleUserId, eventCustomer.Id);

                    model.FeedbackMessage =
                        FeedbackMessageModel.CreateSuccessMessage("The Information updated uccessfully");

                    return View(model);
                }
                return View(model);
            }
            catch (Exception ex)
            {
                model.FeedbackMessage =
                    FeedbackMessageModel.CreateFailureMessage("System Failure. Message: " + ex.Message);
                return View(model);

            }
        }

        public ActionResult GetCustomerActivities(long eventId, long customerId)
        {
            return Json(_hospitalPartnerService.GetHospitalPartnerCustomerActivities(eventId, customerId));
        }

        public ActionResult SearchEvents(HospitalPartnerEventListModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords = 0;

            if (filter == null)
                filter = new HospitalPartnerEventListModelFilter { HospitalPartnerId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationId };
            else
                filter.HospitalPartnerId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationId;

            var model =
                _hospitalPartnerService.GetHospitalPartnerEvents(pageNumber, _pageSize, filter, out totalRecords) ??
                new HospitalPartnerEventListModel();

            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();

            Func<int, string> urlFunc =
                pn => Url.Action(currentAction, new
                                                    {
                                                        pageNumber = pn,
                                                        filter.FromDate,
                                                        filter.ToDate,
                                                        filter.HospitalPartnerId,
                                                        filter.ResultInterpretation,
                                                        filter.Status,
                                                        filter.CriticalMarkedByTechnician
                                                    });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        public ActionResult CustomerAggregateResultSummary(HospitalPartnerCustomerListModelFilter filter = null, int pageNumber = 1)
        {
            var filterValidator = IoC.Resolve<HospitalPartnerCustomerListModelFilterValidator>();
            var result = filterValidator.Validate(filter);
            if (!result.IsValid)
            {
                var propertyNames = result.Errors.Select(e => e.PropertyName).Distinct();
                var htmlString = propertyNames.Aggregate("", (current, property) => current + (result.Errors.Where(e => e.PropertyName == property).FirstOrDefault().ErrorMessage + "<br />"));

                return View(new HospitalPartnerCustomerListModel { Filter = filter, FeedbackMessage = FeedbackMessageModel.CreateFailureMessage(htmlString) });
            }

            int totalRecords = 0;

            var model = _hospitalPartnerService.GetCustomerAggregateResultSummary(pageNumber, _pageSize, filter, out totalRecords) ??
                new HospitalPartnerCustomerListModel();
            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();

            Func<int, string> urlFunc =
                pn => Url.Action(currentAction, new
                {
                    pageNumber = pn,
                    filter.FromDate,
                    filter.ToDate,
                    filter.HospitalPartnerId,
                    filter.CustomerId,
                    filter.CustomerName,
                    filter.Pod,
                    filter.CorporateAccountId,
                    filter.IsRetailEvent,
                    filter.IsCorporateEvent,
                    filter.IsHospitalPartnerAttached,
                    filter.IsPublicEvent,
                    filter.IsPrivateEvent,
                    filter.ResultSummary,
                    filter.Status,
                    filter.DateType,
                    filter.PhoneNumber,
                    filter.SortingColumn,
                    filter.SortingOrder
                });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }

        public bool SaveEventNotes(long eventId, string text)
        {
            var notes = new Notes
            {
                Text = text,
                DataRecorderMetaData = new DataRecorderMetaData
                {
                    DateCreated = DateTime.Now,
                    DataRecorderCreator = new OrganizationRoleUser(_sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId)
                }
            };
            notes = _hospitalPartnerRepository.SaveHospitalPartnerEventNotes(eventId, notes);
            return notes.Id > 0 ? true : false;
        }

        public ActionResult GetEventNotes(long eventId)
        {
            return Json(_hospitalPartnerService.GetEventNotes(eventId));
        }

        private void SavePcp(long customerId, string primaryCarePhysicianName, long updatorOrgRoleUserId, long eventCustomerId)
        {

            var pcp = _primaryCarePhysicianRepository.Get(customerId);
            if (!string.IsNullOrEmpty(primaryCarePhysicianName))
            {
                if (pcp == null)
                {
                    pcp = new PrimaryCarePhysician
                              {
                                  CustomerId = customerId,
                                  Name = new Name(primaryCarePhysicianName),
                                  DataRecorderMetaData =
                                      new DataRecorderMetaData(updatorOrgRoleUserId, DateTime.Now, null)
                              };
                }
                else
                {
                    pcp.Name = new Name(primaryCarePhysicianName);
                }

                _primaryCarePhysicianRepository.Save(pcp);
                SaveCustomerHealthAnswer("Yes", customerId, eventCustomerId);
            }
            else if (pcp != null)
            {
                _primaryCarePhysicianRepository.Delete(pcp);
                SaveCustomerHealthAnswer("No", customerId, eventCustomerId);
            }
        }

        private void SaveCustomerHealthAnswer(string answer, long customerId, long eventCustomerId)
        {
            var question = _healthAssessmentRepository.GetQuestionByLabel(HealthAssessmentQuestionLabel.PrimaryCare.GetDescription());
            if (question != null)
            {
                var customerHealthAnawer = new HealthAssessmentAnswer
                                               {
                                                   Answer = answer,
                                                   CustomerId = customerId,
                                                   QuestionId = question.Id,
                                                   EventCustomerId = eventCustomerId,
                                                   DataRecorderMetaData = new DataRecorderMetaData(0, DateTime.Now, null)
                                               };
                _healthAssessmentRepository.Save(customerHealthAnawer);
            }
        }

        public ActionResult GetPrimaryCarePhysician(long customerId)
        {
            return Json(_primaryCarePhysicianRepository.Get(customerId));
        }

        [HttpGet]
        public bool SendCannedMessage(long eventCustomerId, long customerId)
        {
            var customerRepository = IoC.Resolve<ICustomerRepository>();
            var customer = customerRepository.GetCustomer(customerId);

            if (customer.Email == null || string.IsNullOrEmpty(customer.Email.ToString()))
                return true;

            var eventCustomerNotificationrepository = IoC.Resolve<IEventCustomerNotificationRepository>();
            var messageAlreadySent = eventCustomerNotificationrepository.GetByEventCustomerId(eventCustomerId, NotificationTypeAlias.CannedMessageNotification);
            if (messageAlreadySent != null)
                return true;

            var currentSession = _sessionContext.UserSession.CurrentOrganizationRole;
            var bodyText = string.Empty;

            var userService = IoC.Resolve<IUserService>();
            var careCoordinatorUser = userService.GetUser(currentSession.OrganizationRoleUserId);

            if (currentSession.GetSystemRoleId == (long)Roles.HospitalPartnerCoordinator)
            {
                var eventCustomer = _eventCustomerRepository.GetById(eventCustomerId);
                if (eventCustomer.HospitalFacilityId.HasValue && eventCustomer.HospitalFacilityId.Value > 0)
                {
                    var hospitalFacility = _hospitalFacilityRepository.GetHospitalFacility(eventCustomer.HospitalFacilityId.Value);
                    if (!string.IsNullOrEmpty(hospitalFacility.CannedMessage))
                        bodyText = hospitalFacility.CannedMessage;
                }

                if (string.IsNullOrEmpty(bodyText))
                {
                    var hospitalPartnerId = currentSession.OrganizationId;
                    var hospitalPartner = _hospitalPartnerRepository.GetHospitalPartnerforaVendor(hospitalPartnerId);
                    bodyText = hospitalPartner.CannedMessage;
                }
            }
            else if (currentSession.CheckRole((long)Roles.HospitalFacilityCoordinator))
            {
                var hospitalFacilityId = currentSession.OrganizationId;
                var hospitalFacility = _hospitalFacilityRepository.GetHospitalFacility(hospitalFacilityId);
                if (!string.IsNullOrEmpty(hospitalFacility.CannedMessage))
                    bodyText = hospitalFacility.CannedMessage;
                else
                {
                    var hospitalPartnerId = _hospitalFacilityRepository.GetHospitalPartnerId(hospitalFacilityId);
                    if (hospitalPartnerId > 0)
                    {
                        var hospitalPartner = _hospitalPartnerRepository.GetHospitalPartnerforaVendor(hospitalPartnerId);
                        bodyText = hospitalPartner.CannedMessage;
                    }
                }
            }
            var subjectText = "Mail from Care coordinator";
            var notifier = IoC.Resolve<INotifier>();
            var notification = notifier.NotifyCannedEmail(NotificationTypeAlias.CannedMessageNotification, careCoordinatorUser.Email, customer.Email.ToString(), subjectText, bodyText, customer.Id, currentSession.OrganizationRoleUserId, "Canned Message");

            if (notification != null)
            {
                var eventCustomerNotification = new EventCustomerNotification { EventCustomerId = eventCustomerId, NotificationId = notification.Id, NotificationTypeId = notification.NotificationType.Id };
                eventCustomerNotificationrepository.Save(eventCustomerNotification);
            }
            return true;
        }

        public ActionResult SearchHospitalFacilityEvents(HospitalPartnerEventListModelFilter filter = null, int pageNumber = 1)
        {
            int totalRecords = 0;

            if (filter == null)
                filter = new HospitalPartnerEventListModelFilter { HospitalFacilityId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationId };
            else
                filter.HospitalFacilityId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationId;

            var model = _hospitalPartnerService.GetHospitalFacilityEvents(pageNumber, _pageSize, filter, out totalRecords) ??
                new HospitalPartnerEventListModel();

            model.Filter = filter;

            var currentAction = ControllerContext.RouteData.Values["action"].ToString();

            Func<int, string> urlFunc =
                pn => Url.Action(currentAction, new
                {
                    pageNumber = pn,
                    filter.FromDate,
                    filter.ToDate,
                    filter.HospitalFacilityId,
                    filter.ResultInterpretation,
                    filter.Status,
                    filter.CriticalMarkedByTechnician
                });
            model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

            return View(model);
        }
    }
}
