using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.CallQueues.Factories
{
    [DefaultImplementation]
    public class ProspectCustomerFactory : IProspectCustomerFactory
    {
        public ProspectCustomer CreateProspectCustomerFromCustomer(Customer customer, bool isConverted)
        {
            var prospectCustomer = new ProspectCustomer();
            prospectCustomer.IsConverted = isConverted;

            if (!prospectCustomer.IsConverted.Value)
            {
                prospectCustomer.ConvertedOnDate = null;
                prospectCustomer.Status = (long)ProspectCustomerConversionStatus.NotConverted;
            }

            prospectCustomer.CreatedOn = DateTime.Now;
            prospectCustomer.CustomerId = customer.CustomerId;
            prospectCustomer.FirstName = customer.Name.FirstName;
            prospectCustomer.LastName = customer.Name.LastName;

            prospectCustomer.Gender = customer.Gender;
            prospectCustomer.Address = customer.Address;

            prospectCustomer.BirthDate = customer.DateOfBirth;
            prospectCustomer.CustomerId = customer.CustomerId;

            prospectCustomer.PhoneNumber = customer.MobilePhoneNumber;
            prospectCustomer = SetCallBackPhoneNumber(prospectCustomer, customer);

            prospectCustomer.Email = customer.Email;

            prospectCustomer.Source = ProspectCustomerSource.CallCenter;
            prospectCustomer.Tag = ProspectCustomerTag.CallCenterSignup;

            prospectCustomer.MarketingSource = customer.MarketingSource;
            prospectCustomer.TagUpdateDate = DateTime.Now;

            return prospectCustomer;
        }

        private ProspectCustomer SetCallBackPhoneNumber(ProspectCustomer prospectCustomer, Customer customer)
        {
            if (customer.HomePhoneNumber != null && !string.IsNullOrEmpty(customer.HomePhoneNumber.ToString()))
            {
                prospectCustomer.CallBackPhoneNumber = customer.HomePhoneNumber;
            }
            else if (customer.MobilePhoneNumber != null && !string.IsNullOrEmpty(customer.MobilePhoneNumber.ToString()))
            {
                prospectCustomer.CallBackPhoneNumber = customer.MobilePhoneNumber;
            }
            else if (customer.OfficePhoneNumber != null && !string.IsNullOrEmpty(customer.OfficePhoneNumber.ToString()))
            {
                prospectCustomer.CallBackPhoneNumber = customer.OfficePhoneNumber;
            }

            return prospectCustomer;
        }
    }
}
