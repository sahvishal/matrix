using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Core.Extensions;
using System.Linq;
using System;
using System.Collections.Generic;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Enum;

namespace Falcon.App.Infrastructure.Users.Services
{
    [DefaultImplementation]
    public class CustomerAccountGlocomNumberService : ICustomerAccountGlocomNumberService
    {
        private readonly IAccountCheckoutPhoneNumberRepository _accountCheckoutPhoneNumberRepository;
        private readonly ICustomerAccountGlocomNumberRepository _customerAccountGlocomNumberRepository;
        private readonly IPhoneNumberFactory _phoneNumberFactory;

        public CustomerAccountGlocomNumberService(IAccountCheckoutPhoneNumberRepository accountCheckoutPhoneNumberRepository,
            ICustomerAccountGlocomNumberRepository customerAccountGlocomNumberRepository, IPhoneNumberFactory phoneNumberFactory)
        {
            _accountCheckoutPhoneNumberRepository = accountCheckoutPhoneNumberRepository;
            _customerAccountGlocomNumberRepository = customerAccountGlocomNumberRepository;
            _phoneNumberFactory = phoneNumberFactory;
        }

        public void SaveAccountCheckoutPhoneNumber(CustomerAccountGlocomNumber model)
        {
            model.GlocomNumber = model.GlocomNumber.Replace("-", "");
            //var oldCustomerGlocomNumber = _customerAccountGlocomNumberRepository.GetByCustomerIdAndGlocomNumber(model.CustomerId, model.GlocomNumber);
            //if (oldCustomerGlocomNumber != null)
            //{
            //    oldCustomerGlocomNumber.IsActive = false;
            //    _customerAccountGlocomNumberRepository.Update(oldCustomerGlocomNumber);
            //}

            _customerAccountGlocomNumberRepository.Save(model, false);
        }

        public PhoneNumber GetGlocomNumber(long accountId, long stateId, long customerId, long? callId = null)
        {
            var accountCheckoutPhoneNumbers = _accountCheckoutPhoneNumberRepository.GetAccountCheckoutPhoneNumberByStateID(accountId, stateId);
            if (accountCheckoutPhoneNumbers.IsNullOrEmpty())
                return null;

            var phoneNumber = string.Empty;
            var customerAccountGlocomNumbers = _customerAccountGlocomNumberRepository.GetByCustomerId(customerId)
                                                .Where(x => accountCheckoutPhoneNumbers.Select(acpn => acpn.CheckoutPhoneNumber).Contains(x.GlocomNumber));
            CustomerAccountGlocomNumber checkoutPhoneNumberForCall = null;
            if (!customerAccountGlocomNumbers.IsNullOrEmpty())
            {
                if (callId != null && callId > 0)
                {
                    checkoutPhoneNumberForCall = customerAccountGlocomNumbers.OrderByDescending(x => x.CreatedDate).FirstOrDefault(x => x.CallId == callId);
                    if (checkoutPhoneNumberForCall != null)
                    {
                        phoneNumber = checkoutPhoneNumberForCall.GlocomNumber;
                        return _phoneNumberFactory.CreatePhoneNumber(phoneNumber, PhoneNumberType.Unknown);
                    }
                }
                var checkoutPhoneNumbers = (from acpn in accountCheckoutPhoneNumbers where !customerAccountGlocomNumbers.Select(x => x.GlocomNumber).Contains(acpn.CheckoutPhoneNumber) select acpn);
                if (!checkoutPhoneNumbers.IsNullOrEmpty())
                {
                    var glocomNumber = checkoutPhoneNumbers.First();
                    phoneNumber = glocomNumber.CheckoutPhoneNumber;
                }
                else
                {
                    var glocomNumber = customerAccountGlocomNumbers.First();
                    phoneNumber = glocomNumber.GlocomNumber;
                }
            }
            else
            {
                var glocomNumber = accountCheckoutPhoneNumbers.First();
                phoneNumber = glocomNumber.CheckoutPhoneNumber;
            }

            if (string.IsNullOrEmpty(phoneNumber))
                return null;
            else
                return _phoneNumberFactory.CreatePhoneNumber(phoneNumber, PhoneNumberType.Unknown);
        }

        public IEnumerable<OrderedPair<long, PhoneNumber>> GetGlocomNumberForGmsReport(long accountId, IEnumerable<Customer> customers)
        {
            var collection = new List<OrderedPair<long, PhoneNumber>>();

            var accountCheckoutPhoneNumbers = _accountCheckoutPhoneNumberRepository.GetAccountCheckoutPhoneNumberByStateIDs(accountId, customers.Select(x => x.Address.StateId));
            if (accountCheckoutPhoneNumbers.IsNullOrEmpty())
                return null;

            var customerIdStateIdPairList = customers.Select(x => new OrderedPair<long, long> { FirstValue = x.CustomerId, SecondValue = x.Address.StateId });
            var customerAccountGlocomNumbers = _customerAccountGlocomNumberRepository.GetByCustomerIds(customers.Select(x => x.CustomerId));

            foreach (var customerIdStateIdPair in customerIdStateIdPairList)
            {
                var customerId = customerIdStateIdPair.FirstValue;
                var stateId = customerIdStateIdPair.SecondValue;
                var phoneNumber = string.Empty;
                customerAccountGlocomNumbers = customerAccountGlocomNumbers.Where(x => accountCheckoutPhoneNumbers.Select(acpn => acpn.CheckoutPhoneNumber).Contains(x.GlocomNumber) && x.CustomerId == customerId);

                if (!customerAccountGlocomNumbers.IsNullOrEmpty())
                {
                    var checkoutPhoneNumbers = (from acpn in accountCheckoutPhoneNumbers
                                                where !customerAccountGlocomNumbers.Select(x => x.GlocomNumber).Contains(acpn.CheckoutPhoneNumber)
                                                && acpn.StateID == stateId
                                                select acpn);

                    if (!checkoutPhoneNumbers.IsNullOrEmpty())
                    {
                        var glocomNumber = checkoutPhoneNumbers.First();
                        phoneNumber = glocomNumber.CheckoutPhoneNumber;
                    }
                    else
                    {
                        var glocomNumber = customerAccountGlocomNumbers.First();
                        phoneNumber = glocomNumber.GlocomNumber;
                    }
                }
                else
                {
                    var glocomNumber = accountCheckoutPhoneNumbers.First();
                    phoneNumber = glocomNumber.CheckoutPhoneNumber;
                }

                collection.Add(string.IsNullOrEmpty(phoneNumber)
                    ? new OrderedPair<long, PhoneNumber> { FirstValue = customerId, SecondValue = null }
                    : new OrderedPair<long, PhoneNumber>
                    {
                        FirstValue = customerId,
                        SecondValue = _phoneNumberFactory.CreatePhoneNumber(phoneNumber, PhoneNumberType.Unknown)
                    });
            }
            return collection;
        }
    }
}
