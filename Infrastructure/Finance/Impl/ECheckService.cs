using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Service;

namespace Falcon.App.Infrastructure.Finance.Impl
{
    [DefaultImplementation]
    public class ECheckService : IECheckService
    {
        private IPaymentProcessor _authorizeNetPaymentGateway;
        private ICountryRepository _countryRepository;
        private IStateRepository _stateRepository;
        private readonly ISettings _settings;

        public ECheckService(ICountryRepository countryRepository, IStateRepository stateRepository,ISettings settings)
        {
            _authorizeNetPaymentGateway = new AuthorizeNetECheckPaymentGateway();
            _countryRepository = countryRepository;
            _stateRepository = stateRepository;
            _settings = settings;
        }

        public ProcessorResponse ChargefromECheck(Check check, Address address, Customer customer, string ipAddress, string uniqueReference)
        {
            var electronicCheckProcessorProcessingInfo = new ElectronicCheckProcessorProcessingInfo
                                                             {
                                                                 OrderId = uniqueReference,
                                                                 CustomerId = customer.CustomerId.ToString(),
                                                                 BankRoutingNumber = check.RoutingNumber,
                                                                 BankAccountNumber = check.AccountNumber,
                                                                 BankAccountType = "",
                                                                 BankAccountName = check.AcountHolderName,
                                                                 BankName = check.BankName,
                                                                 CheckType = "Web",
                                                                 CheckNumber = check.CheckNumber,
                                                                 Price = check.Amount.ToString(),
                                                                 FirstName =
                                                                     customer.Name.FirstName,
                                                                 LastName =
                                                                     customer.Name.LastName,
                                                                 BillingAddress =
                                                                     address.StreetAddressLine1,
                                                                 BillingCity =
                                                                     address.City,
                                                                 BillingState =
                                                                     _stateRepository.GetState(address.StateId).Code,
                                                                 BillingPostalCode =
                                                                     address.ZipCode.Zip,
                                                                 BillingCountry =
                                                                     _countryRepository.GetCountryCode(address.CountryId),
                                                                 Email = string.IsNullOrEmpty(customer.Email.ToString()) ? _settings.SupportEmail.ToString() : customer.Email.ToString(),
                                                                 PhoneNumber =
                                                                     customer.HomePhoneNumber.ToString(),
                                                                 IpAddress = ipAddress,
                                                                 Currency = "USD"
                                                             };

            var gatewayResponse = _authorizeNetPaymentGateway.ChargeECheck(electronicCheckProcessorProcessingInfo);
            return gatewayResponse;
        }

    }
}