using System;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Infrastructure.Scheduling.Interfaces;
using Falcon.Data.TypedViewClasses;

namespace Falcon.App.Infrastructure.Factories.Events
{
    public class EventCustomerViewDataFactory : IEventCustomerViewDataFactory
    {
        public void Create(EventCustomerViewData eventCustomerViewData, 
            CustomerOrderBasicInfoRow customerOrderBasicInfoRow)
        {
            var eventAddress = new Address
                                   {
                                       City = customerOrderBasicInfoRow.HostCity,
                                       Latitude = customerOrderBasicInfoRow.Latitude,
                                       Longitude = customerOrderBasicInfoRow.Longitude,
                                       LatLogUseForAddressMaping = customerOrderBasicInfoRow.UseLatLogForMapping,
                                       StreetAddressLine1 = customerOrderBasicInfoRow.HostAddress,
                                       State = customerOrderBasicInfoRow.HostState,
                                       ZipCode = new ZipCode {Zip = customerOrderBasicInfoRow.HostZip}
                                   };

            var checkInTime = (new DateTime(1900, 1, 1)) == customerOrderBasicInfoRow.CheckinTime
                                  ? null
                                  : (DateTime?)customerOrderBasicInfoRow.CheckinTime;
            var checkOutTime = (new DateTime(1900, 1, 1)) == customerOrderBasicInfoRow.CheckoutTime
                                 ? null
                                 : (DateTime?)customerOrderBasicInfoRow.CheckoutTime;

            eventCustomerViewData.AppointmentEndTime = customerOrderBasicInfoRow.AppointmentEndTime;
            eventCustomerViewData.AppointmentId = customerOrderBasicInfoRow.AppointmentId;
            eventCustomerViewData.AppointmentStartTime = customerOrderBasicInfoRow.AppointmentStartTime;
            eventCustomerViewData.CheckInTime = checkInTime;
            eventCustomerViewData.CheckOutTime = checkOutTime;
            eventCustomerViewData.CustomerEventTestId = customerOrderBasicInfoRow.CustomerEventTestId;
            eventCustomerViewData.CustomerId = customerOrderBasicInfoRow.CustomerId;
            eventCustomerViewData.EffectiveOrderPrice = customerOrderBasicInfoRow.EffectiveCost;
            eventCustomerViewData.EventAddress = eventAddress;
            eventCustomerViewData.EventCustomerId = customerOrderBasicInfoRow.EventCustomerId;
            eventCustomerViewData.EventDate = customerOrderBasicInfoRow.EventDate;
            eventCustomerViewData.EventId = customerOrderBasicInfoRow.EventId;
            eventCustomerViewData.EventName = customerOrderBasicInfoRow.EventName;
            eventCustomerViewData.EventSignupDate = customerOrderBasicInfoRow.EventSignupDate;
            eventCustomerViewData.EventStatus = (EventStatus) customerOrderBasicInfoRow.EventStatus;
            eventCustomerViewData.HipaaStatus = (RegulatoryState) customerOrderBasicInfoRow.Hipaastatus;
            eventCustomerViewData.IsAuthorized = Convert.ToBoolean(customerOrderBasicInfoRow.IsAuthorized);
            eventCustomerViewData.IsClinicalFormPdfGenerated = customerOrderBasicInfoRow.IsPdfgenerated;
            eventCustomerViewData.ResultStatus = customerOrderBasicInfoRow.TestStatus;
            eventCustomerViewData.IsColoractelResultReady =
                Convert.ToBoolean(customerOrderBasicInfoRow.IsColoractelResultReady);
            eventCustomerViewData.IsManuallyVerified = Convert.ToBoolean(customerOrderBasicInfoRow.IsManuallyVerified);
            eventCustomerViewData.IsPaid = Convert.ToBoolean(customerOrderBasicInfoRow.IsPaid);
            eventCustomerViewData.IsResultPdfgenerated = customerOrderBasicInfoRow.IsResultPdfgenerated;
            eventCustomerViewData.IsResultReady = Convert.ToBoolean(customerOrderBasicInfoRow.IsResultReady);
            eventCustomerViewData.MarketingSource = customerOrderBasicInfoRow.EventSignupMarketingSource;
            eventCustomerViewData.NoShow = customerOrderBasicInfoRow.Noshow;
            eventCustomerViewData.OrderDetailId = customerOrderBasicInfoRow.OrderDetailId;
            eventCustomerViewData.OrderId = customerOrderBasicInfoRow.OrderId;
            //eventCustomerViewData.OrganizationRoleUserCreatorId = customerOrderBasicInfoRow.o
            eventCustomerViewData.PackageId = customerOrderBasicInfoRow.PackageId;
            eventCustomerViewData.PackageName = customerOrderBasicInfoRow.PackageName;
            eventCustomerViewData.PackagePrice = customerOrderBasicInfoRow.PackagePrice;
            //TODO: Need to map it with additional test 
            eventCustomerViewData.AdditinalTest = customerOrderBasicInfoRow.AdditionalTest;
            eventCustomerViewData.SignUpMode = (CustomerEventSignUpMode) customerOrderBasicInfoRow.EventSignupRoleId;
            eventCustomerViewData.SourceCode = customerOrderBasicInfoRow.SourceCode;
            eventCustomerViewData.SourceCodeAmount = customerOrderBasicInfoRow.SourceCodeAmount;
            eventCustomerViewData.SourceCodeId = customerOrderBasicInfoRow.SourceCodeId;
            eventCustomerViewData.TotalPayment = (customerOrderBasicInfoRow.CreditCard + customerOrderBasicInfoRow.Check +
                                                  customerOrderBasicInfoRow.Gc + customerOrderBasicInfoRow.Echeck +
                                                  customerOrderBasicInfoRow.Cash);
            eventCustomerViewData.TotalShippingCost = customerOrderBasicInfoRow.ShippingCost;
            eventCustomerViewData.IsShippingApplied = Convert.ToBoolean(customerOrderBasicInfoRow.IsShippingApplied);

            eventCustomerViewData.PartnerRelease = (RegulatoryState)customerOrderBasicInfoRow.PartnerRelease;
            eventCustomerViewData.AwvVisitId = customerOrderBasicInfoRow.AwvVisitId;
        }
    }
}