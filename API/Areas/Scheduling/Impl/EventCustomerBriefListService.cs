using System;
using System.Collections.Generic;
using System.Linq;
using API.Areas.Scheduling.Models;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;

namespace API.Areas.Scheduling.Impl
{
    public class EventCustomerBriefListService : IEventCustomerBriefListService
    {
        private readonly IEventCustomerReportingService _eventCustomerReportingService;
        private readonly IElectronicProductRepository _productRepository;
        private readonly IShippingOptionRepository _shippingOptionRepository;
        private readonly IEventCustomerRepository _eventCustomerRepository;

        public EventCustomerBriefListService(IEventCustomerReportingService eventCustomerReportingService, IElectronicProductRepository productRepository, IShippingOptionRepository shippingOptionRepository, 
            IEventCustomerRepository eventCustomerRepository)
        {
            _eventCustomerReportingService = eventCustomerReportingService;
            _productRepository = productRepository;
            _shippingOptionRepository = shippingOptionRepository;
            _eventCustomerRepository = eventCustomerRepository;
        }

        public EventCustomerBrifListModel GetList(EventCustomerListFilter filter)
        {
            var model = _eventCustomerReportingService.GetEventCustomerBriefList(filter.EventId, filter);
            if (model == null) return null;

            var products = _productRepository.GetAllProductsForEvent(filter.EventId);
            var shippingOptions = _shippingOptionRepository.GetAllShippingOptionsForBuyingProcess();

            var shippingOptionsToBind = new List<ShippingOption>();

            if (model.EventType == EventType.Retail)
            {
                var onlineShippingOption = _shippingOptionRepository.GetOnlineShippingOption();
                shippingOptionsToBind.Add(onlineShippingOption);

                if (shippingOptions != null && shippingOptions.Count > 0)
                {
                    shippingOptions.RemoveAll(so => so.Price == 0);
                    shippingOptionsToBind.AddRange(shippingOptions);
                }
            }
            else if (model.EventType == EventType.Corporate)
            {
                var onlineShippingOption = _shippingOptionRepository.GetOnlineShippingOption();
                shippingOptionsToBind.Add(onlineShippingOption);

                shippingOptions = _shippingOptionRepository.GetAllShippingOptionForCorporate(model.AccountId.HasValue ? model.AccountId.Value : 0);
                if (shippingOptions != null && shippingOptions.Count > 0)
                {
                    shippingOptionsToBind.AddRange(shippingOptions);
                }
            }
            model.ShippingOptions = shippingOptionsToBind;
            model.Products = products != null ? products.OrderBy(d => d.Price).ToList() : null;

            return model;
        }

        public bool UpdateCheckinCheckOutTime(long eventCustomerId, long appointmentId, DateTime? checkInTime, DateTime? checkOutTime)
        {
            var eventCustomer = _eventCustomerRepository.GetById(eventCustomerId);

            if (eventCustomer == null) return false;

            _eventCustomerRepository.UpdateCheckInCheckOutTime(eventCustomer.Id, appointmentId, checkInTime, checkOutTime);

            return true;
        }

        public EventCustomerConsents UpdateConsentsStatusforEventIdCustomerId(EventCustomerConsents model)
        {
            var eventCustomer = _eventCustomerRepository.Get(model.EventId, model.CustomerId);

            if (eventCustomer == null) return model;

            if (model.Hipaa != null)
            {
                try
                {
                    _eventCustomerRepository.UpdateHippaStatus(eventCustomer.Id, (short)model.Hipaa.Status);
                    model.Hipaa.Message = "Updated Successfully";
                    model.Hipaa.IsSuccess = true;
                }
                catch (Exception exception)
                {
                    model.Hipaa.Message = exception.Message;
                    model.Hipaa.IsSuccess = false;
                }
            }
            if (model.PcpConsent != null)
            {
                try
                {
                    _eventCustomerRepository.UpdatePcpConsentStatus(eventCustomer.Id, (short)model.PcpConsent.Status);
                    model.PcpConsent.Message = "Updated Successfully";
                    model.PcpConsent.IsSuccess = true;
                }
                catch (Exception exception)
                {
                    model.PcpConsent.Message = exception.Message;
                    model.PcpConsent.IsSuccess = false;
                }
            }

            if (model.PartnerRelease != null)
            {
                try
                {
                    _eventCustomerRepository.UpdatePartnerReleaseStatus(eventCustomer.Id, (short)model.PartnerRelease.Status);
                    model.PartnerRelease.Message = "Updated Successfully";
                    model.PartnerRelease.IsSuccess = true;
                }
                catch (Exception exception)
                {
                    model.PartnerRelease.Message = exception.Message;
                    model.PartnerRelease.IsSuccess = false;
                }
            }

            if (model.AbnConsent != null)
            {
                try
                {
                    _eventCustomerRepository.UpdateAbnStatus(eventCustomer.Id, (short)model.AbnConsent.Status);
                    model.AbnConsent.Message = "Updated Successfully";
                    model.AbnConsent.IsSuccess = true;
                }
                catch (Exception exception)
                {
                    model.AbnConsent.Message = exception.Message;
                    model.AbnConsent.IsSuccess = false;
                }
            }

            if (model.InsuranceRelease != null)
            {
                try
                {
                    _eventCustomerRepository.UpdateInsuranceReleaseStatus(eventCustomer.Id, (short)model.InsuranceRelease.Status);
                    model.InsuranceRelease.Message = "Updated Successfully";
                    model.InsuranceRelease.IsSuccess = true;
                }
                catch (Exception exception)
                {
                    model.InsuranceRelease.Message = exception.Message;
                    model.InsuranceRelease.IsSuccess = false;
                }
            }

            return model;
        }

        public IEnumerable<ShortPatientInfoViewModel> GetPatientsByEventyId(long eventId)
        {
            var filter = new EventCustomerListFilter
            {
                EventId = eventId
            };

            return _eventCustomerReportingService.GetCustomerAppointmentList(filter.EventId, filter);
        }
    }
}