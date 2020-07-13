using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.Marketing.Impl;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Extentions;
using Falcon.App.UI.Filters;

namespace Falcon.App.UI.Areas.Marketing.Controllers
{
    [RoleBasedAuthorize]
    public class ReportsController : Controller
    {
        private readonly IProspectCustomerService _prospectCustomerService;
        private readonly IProspectCustomerRepository _prospectCustomerRepository;
        private readonly int _pageSize;
        private readonly ISessionContext _sessionContext;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICallQueueCustomerRepository _callQueueCustomerRepository;
        private readonly ICallQueueCustomerCallRepository _callQueueCustomerCallRepository;
        private readonly IOutboundCallQueueService _outboundCallQueueService;
        private readonly ICustomerService _customerService;
        private readonly ILogger _logger;

        public ReportsController(IProspectCustomerService prospectCustomerService, ISettings settings, IProspectCustomerRepository prospectCustomerRepository, ISessionContext sessionContext,
             ICustomerRepository customerRepository, ICallQueueCustomerRepository callQueueCustomerRepository, ICallQueueCustomerCallRepository callQueueCustomerCallRepository, IOutboundCallQueueService outboundCallQueueService,
            ILogManager logManager, ICustomerService customerService)
        {
            _prospectCustomerService = prospectCustomerService;
            _pageSize = settings.DefaultPageSizeForReports;
            _prospectCustomerRepository = prospectCustomerRepository;
            _sessionContext = sessionContext;
            _customerRepository = customerRepository;
            _callQueueCustomerRepository = callQueueCustomerRepository;
            _callQueueCustomerCallRepository = callQueueCustomerCallRepository;
            _outboundCallQueueService = outboundCallQueueService;
            _customerService = customerService;
            _logger = logManager.GetLogger<ReportsController>();
        }

        public ActionResult ProspectCustomerAbandonedReport(int pageNumber = 1, ProspectCustomerListModelFilter filter = null)
        {
            var filterValidator = IoC.Resolve<ProspectCustomerListModelFilterValidator>();
            var result = filterValidator.Validate(filter);
            if (result.IsValid)
            {
                if (_sessionContext.UserSession.CurrentOrganizationRole.GetSystemRoleId == (long) Roles.CallCenterRep)
                    filter.AgentOrganizationId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationId;

                int totalRecords;
                var model = _prospectCustomerService.GetAbandonedCustomers(pageNumber, _pageSize, filter, out totalRecords);
                if (model == null) model = new ProspectCustomerListModel();
                model.Filter = filter;

                var currentAction = ControllerContext.RouteData.Values["action"].ToString();
                //Func<int, string> urlFunc = pn => Url.Action(currentAction, new
                //                                                                {
                //                                                                    pageNumber = pn,
                //                                                                    filter.FromDate,
                //                                                                    filter.ToDate,
                //                                                                    filter.DateType,
                //                                                                    filter.Source,
                //                                                                    filter.Tag,
                //                                                                    filter.Miles,
                //                                                                    filter.Zipcode,
                //                                                                    filter.PhoneNumber,
                //                                                                    filter.StateId,
                //                                                                    filter.City,
                //                                                                    filter.CorporateTag,
                //                                                                    CustomTags = filter.CustomTags.IsNullOrEmpty() ? "" : string.Join("&CustomTags=", filter.CustomTags)
                //                                                                });

                var routeValueDictionary = GetProspectCustomerAbandonedReport(filter);

                Func<int, string> urlFunc = pn => Url.Action(currentAction, AddRouteValueDictionary(routeValueDictionary, pn));


                model.PagingModel = new PagingModel(pageNumber, _pageSize, totalRecords, urlFunc);

                return View(model);
            }
            var propertyNames = result.Errors.Select(e => e.PropertyName).Distinct();
            var htmlString = propertyNames.Aggregate("", (current, property) => current + (result.Errors.Where(e => e.PropertyName == property).FirstOrDefault().ErrorMessage + "<br />"));

            return View(new ProspectCustomerListModel { Filter = filter, FeedbackMessage = FeedbackMessageModel.CreateFailureMessage(htmlString) });
        }

        public bool DeleteSingleProspectCustomer(long prospectCustomerId)
        {
            try
            {
                return _prospectCustomerRepository.Delete(prospectCustomerId);
            }
            catch (Exception ex)
            {
                _logger.Error("Delete Single Prospect Customer Payment. Message: " + ex.Message + ". \n\t Stack Trace: " + ex.StackTrace);
                return false;
            }
        }

        public bool DeleteMultipleProspectCustomer(long[] prospectCustomerIds)
        {
            try
            {
                return _prospectCustomerRepository.Delete(prospectCustomerIds);
            }
            catch (Exception ex)
            {
                _logger.Error("Delete Multiple Prospect Customer Payment. Message: " + ex.Message + ". \n\t Stack Trace: " + ex.StackTrace);
                return false;
            }
        }

        public bool UpdateContactedInfo(long prospectCustomerId)
        {
            return _prospectCustomerRepository.UpdateContactedStatus(prospectCustomerId, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
        }

        public bool UpdateDoNotCallStatus(long prospectCustomerId, bool isDoNotCall)
        {
            var prospectCustomer = _prospectCustomerRepository.GetProspectCustomer(prospectCustomerId);
            if (isDoNotCall)
            {
                if (prospectCustomer.CustomerId.HasValue && prospectCustomer.CustomerId.Value > 0)
                {
                    var customer = _customerRepository.GetCustomer(prospectCustomer.CustomerId.Value);

                    customer.DoNotContactTypeId = (long)DoNotContactType.DoNotCall;
                    customer.DoNotContactReasonId = (long)DoNotContactReason.CustomerRequest;
                    customer.DoNotContactUpdateDate = DateTime.Now;
                    customer.DoNotContactUpdateSource = (long)DoNotContactSource.Manual;

                    _customerService.SaveCustomer(customer, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
                }
                return _prospectCustomerRepository.UpdateDoNotCallStatus(prospectCustomerId, ProspectCustomerConversionStatus.Declined);
            }

            if (prospectCustomer.CustomerId.HasValue && prospectCustomer.CustomerId.Value > 0)
            {
                var customer = _customerRepository.GetCustomer(prospectCustomer.CustomerId.Value);
                customer.DoNotContactReasonId = null;
                customer.DoNotContactTypeId = null;
                customer.DoNotContactUpdateDate = null;
                customer.DoNotContactUpdateSource = null;

                _customerService.SaveCustomer(customer, _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
            }
            return _prospectCustomerRepository.UpdateDoNotCallStatus(prospectCustomerId, ProspectCustomerConversionStatus.NotConverted);
        }

        public void Register(long customerId, long prospectCustomerId)
        {
            var organizationRoleUserId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
            var callId = _outboundCallQueueService.SetCallDetail(organizationRoleUserId);

            var guid = Guid.NewGuid().ToString();
            var registrationFlow = new RegistrationFlowModel
                                       {
                                           GuId = guid,
                                           CallId = callId
                                       };
            Session[guid] = registrationFlow;
            if (customerId == 0 && prospectCustomerId > 0)
            {
                UpdateContactedInfo(prospectCustomerId);
                registrationFlow.ProspectCustomerId = prospectCustomerId;
                Response.RedirectUser("/App/CallCenter/CallCenterRep/BasicCallInfo.aspx?guid=" + guid);
            }
            else if (customerId > 0 && prospectCustomerId > 0)
            {
                var customer = _customerRepository.GetCustomer(customerId);
                UpdateContactedInfo(prospectCustomerId);
                registrationFlow.ProspectCustomerId = prospectCustomerId;
                Response.RedirectUser("/App/CallCenter/CallCenterRep/CustomerVerification.aspx?CustomerID=" + customerId + "&Zip=" + customer.Address.ZipCode.Zip + "&guid=" + guid);
            }
        }

        public void StartOutboundCall(long customerId, long prospectCustomerId, long callQueueCustomerId)
        {
            var organizationRoleUserId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
            var callId = _outboundCallQueueService.SetCallDetail(organizationRoleUserId, customerId);
            var guid = Guid.NewGuid().ToString();
            var registrationFlow = new RegistrationFlowModel
            {
                GuId = guid,
                CallId = callId,
                CallQueueCustomerId = callQueueCustomerId
            };

            var callQueueCustomer = _callQueueCustomerRepository.GetById(callQueueCustomerId);
            callQueueCustomer.Status = CallQueueStatus.InProcess;
            callQueueCustomer.DateModified = DateTime.Now;
            callQueueCustomer.ModifiedByOrgRoleUserId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;

            _callQueueCustomerRepository.Save(callQueueCustomer);

            var callQueueCustomerCall = new CallQueueCustomerCall { CallQueueCustomerId = callQueueCustomerId, CallId = callId };
            _callQueueCustomerCallRepository.Save(callQueueCustomerCall);

            Session[guid] = registrationFlow;
            if (customerId == 0 && prospectCustomerId > 0)
            {
                UpdateContactedInfo(prospectCustomerId);
                registrationFlow.ProspectCustomerId = prospectCustomerId;
                Response.RedirectUser("/App/CallCenter/CallCenterRep/BasicCallInfo.aspx?guid=" + guid);
            }
            else if (customerId > 0)
            {
                var customer = _customerRepository.GetCustomer(customerId);
                var prospectCustomer = _prospectCustomerRepository.GetProspectCustomerByCustomerId(customerId);
                if (prospectCustomer != null)
                {
                    UpdateContactedInfo(prospectCustomer.Id);
                    registrationFlow.ProspectCustomerId = prospectCustomer.Id;
                }
                Response.RedirectUser("/App/CallCenter/CallCenterRep/CustomerVerification.aspx?CustomerID=" + customerId + "&Zip=" + customer.Address.ZipCode.Zip + "&guid=" + guid);
            }
        }

        public bool RemoveFromQueue(long callQueueCustomerId, string text)
        {
            var callQueueCustomer = _callQueueCustomerRepository.GetById(callQueueCustomerId);
            callQueueCustomer.Status = CallQueueStatus.Removed;
            callQueueCustomer.DateModified = DateTime.Now;
            callQueueCustomer.ModifiedByOrgRoleUserId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;

            var notes = new Notes
            {
                Text = text,
                DataRecorderMetaData = new DataRecorderMetaData
                {
                    DateCreated = DateTime.Now,
                    DataRecorderCreator = new OrganizationRoleUser(_sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId)
                }
            };
            notes = _outboundCallQueueService.RemoveFromQueue(callQueueCustomer, notes);

            if (callQueueCustomer.ProspectCustomerId.HasValue && callQueueCustomer.ProspectCustomerId.Value > 0)
                UpdateDoNotCallStatus(callQueueCustomer.ProspectCustomerId.Value, true);
            return notes.Id > 0;
        }


        private RouteValueDictionary GetProspectCustomerAbandonedReport(ProspectCustomerListModelFilter filter)
        {
            var routeValueDictionary = new RouteValueDictionary
            {
                {"FromDate",filter.FromDate},
                {"ToDate",filter.ToDate},  
                {"DateType",filter.DateType},
                {"Source",filter.Source},
                {"Tag",filter.Tag},
                {"Miles",filter.Miles},
                {"Zipcode",filter.Zipcode},
                {"PhoneNumber", filter.PhoneNumber},
                {"StateId", filter.StateId},
                {"City", filter.City},
                {"CorporateTag", filter.CorporateTag},
                {"AgentOrganizationId", filter.AgentOrganizationId}
            };

            if (!filter.CustomTags.IsNullOrEmpty())
            {
                var index = 0;
                foreach (var customtag in filter.CustomTags)
                {
                    routeValueDictionary.Add(string.Format("CustomTags[{0}]", index), customtag);
                    index++;
                }
            }

            return routeValueDictionary;
        }

        private RouteValueDictionary AddRouteValueDictionary(RouteValueDictionary routeValueDictionary, int pageNumber)
        {
            routeValueDictionary.Remove("pageNumber");
            routeValueDictionary.Add("pageNumber", pageNumber);

            return routeValueDictionary;
        }
    }
}
