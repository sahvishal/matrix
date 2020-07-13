using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.CallCenter.Factories
{
    [DefaultImplementation]
    public class CallQueueCustomerPubFactory : ICallQueueCustomerPubFactory
    {
        public CallQueueCustomerPubViewModel GetCallQueueCustomerPubViewModel(Customer customer, Address address)
        {
            var callQueueCustomer = new CallQueueCustomerPubViewModel
            {
                CustomerId = customer.CustomerId,
                FirstName = customer.Name.FirstName,
                MiddleName = customer.Name.MiddleName,
                LastName = customer.Name.LastName,
                PhoneCell = customer.MobilePhoneNumber != null ? customer.MobilePhoneNumber.AreaCode + customer.MobilePhoneNumber.Number : "",
                PhoneHome = customer.HomePhoneNumber != null ? customer.HomePhoneNumber.AreaCode + customer.HomePhoneNumber.Number : "",
                PhoneOffice = customer.OfficePhoneNumber != null ? customer.OfficePhoneNumber.AreaCode + customer.OfficePhoneNumber.Number : "",
                DoNotContactTypeId = customer.DoNotContactTypeId,
                DoNotContactReasonId = customer.DoNotContactReasonId,
                DoNotContactUpdateDate = customer.DoNotContactUpdateDate,
                ActivityId = customer.ActivityId,
                //IsEligible = customer.IsEligible,                         //while updating Eligibility status , we are Updating it for CQC too
                IsIncorrectPhoneNumber = customer.IsIncorrectPhoneNumber,
                IsLanguageBarrier = customer.IsLanguageBarrier,
                ZipCode = address.ZipCode.Zip,
                ZipId = address.ZipCode.Id,
                Tag = customer.Tag,
                DoNotContactUpdateSource = customer.DoNotContactUpdateSource,
                IncorrectPhoneNumberMarkedDate = customer.IncorrectPhoneNumberMarkedDate,
                LanguageBarrierMarkedDate = customer.LanguageBarrierMarkedDate,
                LanguageId = customer.LanguageId
            };
            return callQueueCustomer;
        }
    }
}
