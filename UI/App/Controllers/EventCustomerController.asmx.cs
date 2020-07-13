using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Marketing;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Marketing.Repositories;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Order;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Infrastructure.Scheduling.Repositories;

namespace Falcon.App.UI.Controllers
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class EventCustomerController : WebService
    {
        private readonly IEventCustomerAggregateRepository _eventCustomerAggregateRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderController _orderController;
        private readonly ISourceCodeRepository _sourceCodeRepository;
        private readonly IEventRepository _eventRepository;
        private readonly ISessionContext _sessionContext;

        public EventCustomerController()
            : this(new EventCustomerAggregateRepository(), new EventCustomerRepository(), new CustomerRepository(), new OrderRepository(), new SourceCodeRepository(), new Infrastructure.Finance.Impl.OrderController(), IoC.Resolve<IEventRepository>(),
            IoC.Resolve<ISessionContext>())
        { }

        public EventCustomerController(IEventCustomerAggregateRepository eventCustomerAggregateRepository, IEventCustomerRepository eventCustomerRepository, ICustomerRepository customerRepository,
                IOrderRepository orderRepository, ISourceCodeRepository sourceCodeRepository, IOrderController orderController, IEventRepository eventRepository, ISessionContext sessionContext)
        {
            _eventCustomerAggregateRepository = eventCustomerAggregateRepository;
            _eventCustomerRepository = eventCustomerRepository;
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
            _sourceCodeRepository = sourceCodeRepository;
            _orderController = orderController;
            _eventRepository = eventRepository;
            _sessionContext = sessionContext;
        }

        [WebMethod(EnableSession = true)]
        public List<EventCustomerAggregate> GetEventCustomerAggregatesForSalesRep(long salesRepId,
            DateTime eventStartDate, DateTime eventEndDate)
        {
            var eventDateRange = new DateRange { StartDate = eventStartDate, EndDate = eventEndDate };
            return _eventCustomerAggregateRepository.GetEventCustomerInfoBySalesRep(salesRepId, eventDateRange).
                OrderBy(eca => eca.EventDate).ThenBy(eca => eca.EventName).
                ThenBy(eca => eca.MarketingSource).ThenBy(eca => eca.SourceCode).ToList();
        }

        [WebMethod(EnableSession = true)]
        public bool UpdateCustomerMaketingSource(long customerId, string marketingSource, bool isFirstRegistrationUpdateRequired)
        {
            marketingSource = marketingSource.Replace("'", "''");

            bool isSuccessful = _customerRepository.UpdateMaketingSource(customerId, marketingSource);

            if (isSuccessful && isFirstRegistrationUpdateRequired)
            {
                return _eventCustomerRepository.UpdateFirstRegistrationMarketingSource(customerId, marketingSource);
            }
            return isSuccessful;
        }

        [WebMethod(EnableSession = true)]
        public bool UpdateEventCustomerMaketingSource(long customerId, long eventCustomerId, string marketingSource, bool isSignUpMarketingSourceRequired)
        {
            marketingSource = marketingSource.Replace("'", "''");

            bool isSuccessful = _eventCustomerRepository.UpdateMaketingSource(eventCustomerId, marketingSource);

            if (isSuccessful && isSignUpMarketingSourceRequired)
            {
                return _customerRepository.UpdateMaketingSource(customerId, marketingSource);
            }
            return isSuccessful;
        }

        [WebMethod(EnableSession = true)]
        public bool UpdateEventCustomerSourceCode(long eventCustomerId, string sourceCode, long userId, long shellId, long roleId)
        {
            //TODO: This will be pulled into the UpdateSourceCode in EventCustomerRepository once old order system is removed.
            return UpdateSourceCodeForExistingOrder(eventCustomerId, sourceCode, userId, shellId, roleId);
        }


        [WebMethod(EnableSession = true)]
        public void UpdateHippaStatusforEventIdCustomerId(long eventId, long customerId, short hippaStatus)
        {
            var eventCustomer = _eventCustomerRepository.Get(eventId, customerId);
            if (eventCustomer == null) return;
            _eventCustomerRepository.UpdateHippaStatus(eventCustomer.Id, hippaStatus);
        }

        [WebMethod(EnableSession = true)]
        public bool UpdateHippaStatus(long eventCustomerId, short hippaStatus)
        {
            return _eventCustomerRepository.UpdateHippaStatus(eventCustomerId, hippaStatus);
        }

        [WebMethod(EnableSession = true)]
        public bool UpdateCustomerEventShowUp(long eventCustomerId, bool isNoShowUp)
        {
            var customerService = IoC.Resolve<ICustomerService>();
            var callQueueCustomerDetailService = IoC.Resolve<ICallQueueCustomerDetailService>();
            if (isNoShowUp)
                customerService.UnMarkProspectCustomerConverted(eventCustomerId, ProspectCustomerTag.NoShow);
            else
                customerService.MarkProspectCustomerConverted(eventCustomerId);

            DateTime? noShowDate = null;

            if (isNoShowUp)
                noShowDate = DateTime.Now;
            var returnVal = _eventCustomerRepository.UpdateShowUp(eventCustomerId, isNoShowUp, noShowDate);
            callQueueCustomerDetailService.DoNoShowCallQueueCustomerChanges(eventCustomerId, isNoShowUp, noShowDate);
            return returnVal;
        }


        [WebMethod(EnableSession = true)]
        public string UpdateCheckInCheckOutTime(long eventCustomerId, long appointmentId, DateTime? checkInTime, DateTime? checkOutTime)
        {
            var returnValue = string.Empty;
            //TODO:Authorization check has been removed.
            //if (IoC.Resolve<ISettings>().IsAuthorizationRequired)
            //{
            //    var screeningAuthorizationRepository = IoC.Resolve<IScreeningAuthorizationRepository>();
            //    var screeningAuthorization = screeningAuthorizationRepository.GetAuthorization(eventCustomerId);
            //    if (screeningAuthorization != null)
            //    {
            //        var compareDate = checkInTime.HasValue ? checkInTime.Value : checkOutTime.Value;
            //        var screeningAuthorizationDate = screeningAuthorization.DateCreated;

            //        if (DateTime.Compare(screeningAuthorizationDate, compareDate) < 0)
            //        {
            //            returnValue = _eventCustomerRepository.UpdateCheckInCheckOutTime(eventCustomerId, appointmentId, checkInTime, checkOutTime);
            //        }
            //        else
            //        {
            //            returnValue = "Check-In/Check-Out time cannot be before authorization time. This client was authorized at " + screeningAuthorizationDate.ToShortTimeString() + ".";
            //            return returnValue;
            //        }
            //    }
            //    else
            //    {
            //        returnValue = "Check-In/Check-Out time cannot be entered since customer is not authorized by physician.";
            //        return returnValue;
            //    }
            //}
            //else
            //{
            //    returnValue = _eventCustomerRepository.UpdateCheckInCheckOutTime(eventCustomerId, appointmentId, checkInTime, checkOutTime);
            //}

            returnValue = _eventCustomerRepository.UpdateCheckInCheckOutTime(eventCustomerId, appointmentId, checkInTime, checkOutTime);
            IAffiliateCommisionGenerationRepository affiliateCommisionGenerationRepository =
                    new AffiliateCommisionGenerationRepository();

            affiliateCommisionGenerationRepository.SaveEventAffiliate(eventCustomerId, null);
            return returnValue;
        }

        [WebMethod(EnableSession = true)]
        public string ClearCheckInCheckOutTime(long eventCustomerId, long appointmentId)
        {
            var returnValue = _eventCustomerRepository.ClearCheckInCheckOutTime(eventCustomerId, appointmentId);

            return returnValue;
        }

        [WebMethod(EnableSession = true)]
        public List<int> GetHipaaRatio(long eventId)
        {
            return _eventCustomerRepository.GetHipaaRatio(eventId);
        }

        //TODO: This will be pulled into the UpdateSourceCode in EventCustomerRepository once old order system is removed.
        private bool UpdateSourceCodeForExistingOrder(long eventCustomerId, string sourceCode, long userId, long shellId, long roleId)
        {
            IUniqueItemRepository<EventCustomer> itemRepository = new EventCustomerRepository();
            EventCustomer eventCustomer = itemRepository.GetById(eventCustomerId);

            var creatorOrganizationRoleUser = IoC.Resolve<IOrgRoleUserModelBinder>().ToDomain(
                        IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole,
                        IoC.Resolve<ISessionContext>().UserSession.UserId);

            var newSourceCode = _sourceCodeRepository.GetSourceCodeByCode(sourceCode);

            if (creatorOrganizationRoleUser == null || newSourceCode == null) return false;

            try
            {
                var order = _orderRepository.GetOrder(eventCustomer.CustomerId, eventCustomer.EventId);

                OrderDetail orderDetail = _orderController.GetActiveOrderDetail(order);

                if (orderDetail == null) return false;

                newSourceCode.CouponValue = orderDetail.SourceCodeOrderDetail != null ? orderDetail.SourceCodeOrderDetail.Amount : 0.00m;

                return _orderController.UpdateOrder(order, newSourceCode, creatorOrganizationRoleUser.Id) != null;

            }
            catch (ObjectNotFoundInPersistenceException<Order>)
            {
                return false;
            }
        }


        [WebMethod(EnableSession = true)]
        public void UpdatePartnerReleaseStatusforEventIdCustomerId(long eventId, long customerId, short partnerReleaseStatus)
        {
            var eventCustomer = _eventCustomerRepository.Get(eventId, customerId);
            if (eventCustomer == null) return;
            _eventCustomerRepository.UpdatePartnerReleaseStatus(eventCustomer.Id, partnerReleaseStatus);
        }

        [WebMethod(EnableSession = true)]
        public bool UpdatePartnerReleaseStatus(long eventCustomerId, short partnerReleaseStatus)
        {
            return _eventCustomerRepository.UpdatePartnerReleaseStatus(eventCustomerId, partnerReleaseStatus);
        }

        [WebMethod(EnableSession = true)]
        public Notes GetNotes(long eventId)
        {
            return _eventRepository.GetEmrNotes(eventId);
        }

        [WebMethod(EnableSession = true)]
        public Notes SaveNotes(long eventId, string text)
        {
            var notes = _eventRepository.GetEmrNotes(eventId);
            if (notes == null)
            {
                notes = new Notes
                            {
                                Text = text,
                                DataRecorderMetaData = new DataRecorderMetaData
                                                           {
                                                               DateCreated = DateTime.Now,
                                                               DataRecorderCreator = new OrganizationRoleUser(_sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId)
                                                           }
                            };
            }
            else
            {
                notes.Text = text;
                notes.DataRecorderMetaData.DateModified = DateTime.Now;
                notes.DataRecorderMetaData.DataRecorderModifier = new OrganizationRoleUser(_sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
            }

            return _eventRepository.SaveEmrNotes(eventId, notes);
        }

        [WebMethod(EnableSession = true)]
        public bool UpdateHospitalFacilitily(long eventCustomerId, long hospitalFacilityId)
        {
            return _eventCustomerRepository.UpdateHospitalFacility(eventCustomerId, hospitalFacilityId > 0 ? (long?)hospitalFacilityId : null);
        }

        [WebMethod(EnableSession = true)]
        public bool UpdateAbnStatus(long eventCustomerId, short abnStatus)
        {
            return _eventCustomerRepository.UpdateAbnStatus(eventCustomerId, abnStatus);
        }

        [WebMethod(EnableSession = true)]
        public bool UpdatePcpConsentStatus(long eventCustomerId, short pcpConsentStatus)
        {
            return _eventCustomerRepository.UpdatePcpConsentStatus(eventCustomerId, pcpConsentStatus);
        }

        [WebMethod(EnableSession = true)]
        public bool UpdateInsuranceReleaseStatus(long eventCustomerId, short insuranceReleaseStatus)
        {
            return _eventCustomerRepository.UpdateInsuranceReleaseStatus(eventCustomerId, insuranceReleaseStatus);
        }
    }
}
