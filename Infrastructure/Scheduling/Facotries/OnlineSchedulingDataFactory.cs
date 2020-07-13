using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Scheduling.Facotries
{
    [DefaultImplementation]
    public class OnlineSchedulingDataFactory : IOnlineSchedulingDataFactory
    {
        public OnlineSchedulingProcessAndCartViewModel Create(TempCart tempCart, Customer customer, EventSchedulingSlot appointmentSlot, string sponsoredBy, string checkoutPhoneNumber)
        {
            var model = new OnlineSchedulingProcessAndCartViewModel
                            {
                                CartGuid = tempCart.Guid,
                                PackageId = tempCart.EventPackageId,
                                AppointmentId = tempCart.AppointmentId,
                                CustomerId = tempCart.CustomerId,
                                CustomerName = customer != null ? customer.NameAsString : "",
                                SponsoredBy = sponsoredBy,
                                ProspectCustomerId = tempCart.ProspectCustomerId,
                                EventId = tempCart.EventId,
                                Tests = tempCart.TestId,
                                Products = tempCart.ProductId,
                                IsExistingCustomer = tempCart.IsExistingCustomer,
                                AppointmentTime = appointmentSlot != null ? (DateTime?)appointmentSlot.StartTime : null,
                                IsUsedAppointmentSlotExpiryExtension = tempCart.IsUsedAppointmentSlotExpiryExtension,
                                ScreenResolution = tempCart.ScreenResolution,
                                CheckoutPhoneNumber = checkoutPhoneNumber
                            };

            return model;
        }
    }
}