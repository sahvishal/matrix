using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class OnlineShippingService : IOnlineShippingService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IShippingOptionRepository _shippingOptionRepository;
        private readonly IHospitalPartnerRepository _hospitalPartnerRepository;

        public OnlineShippingService(IEventRepository eventRepository, IShippingOptionRepository shippingOptionRepository, IHospitalPartnerRepository hospitalPartnerRepository)
        {
            _eventRepository = eventRepository;
            _shippingOptionRepository = shippingOptionRepository;
            _hospitalPartnerRepository = hospitalPartnerRepository;
        }

        public OnlineProductShippingEditModel GetShippingOption(TempCart tempCart)
        {
            var model = new OnlineProductShippingEditModel();

            if (tempCart.EventId != null)
            {
                var theEvent = _eventRepository.GetById(tempCart.EventId.Value);
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

                model.AllShippingOptions = Mapper.Map<IEnumerable<ShippingOption>, IEnumerable<ShippingOptionOrderItemViewModel>>(shippingOptionsToBind);

            }

            return model;
        }
    }
}