using System;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.ValueTypes;
using System.Collections.Generic;

namespace Falcon.App.Core.Finance.Impl
{
    [DefaultImplementation]
    public class ChargeCardService : IChargeCardService
    {
        private IPaymentProcessor _paymentProcessor;
        private ICountryRepository _countryRepository;
        private IStateRepository _stateRepository;
        private readonly ISettings _settings;

        public ChargeCardService(IPaymentProcessor paymentProcessor, ICountryRepository countryRepository, IStateRepository stateRepository, ISettings settings)
        {
            _paymentProcessor = paymentProcessor;
            _stateRepository = stateRepository;
            _countryRepository = countryRepository;
            _settings = settings;
        }

        /// <summary>
        /// Gets the valid transactions needed for creating a refund.
        /// </summary>
        /// <param name="cardPayments"></param>
        /// <param name="amountToRefund"></param>
        /// <returns></returns>
        public IEnumerable<long> GetChageCardIdsvalidforRefund(IEnumerable<ChargeCardPayment> cardPayments, decimal amountToRefund)
        {
            string reasonForFailure;
            return cardPayments.Where(cp => IsCardValidforRefund(cp, amountToRefund, out reasonForFailure)).Select(cp => cp.ChargeCardId).ToArray();
        }

        /// <summary>
        /// Checks if the given transaction is valid for refund or not
        /// </summary>
        /// <param name="cardPayment"></param>
        /// <param name="amountToRefund"></param>
        /// <returns></returns>
        public bool IsCardValidforRefund(ChargeCardPayment cardPayment, decimal amountToRefund, out string reasonForFailure)
        {
            reasonForFailure = string.Empty;
            if (cardPayment.Amount < amountToRefund)
            {
                reasonForFailure = "The payment gateway doesn't allow refund of an amount greater than the one in the last transaction made. The Last Transaction amount is ($" + cardPayment.Amount.ToString("0.00") + ").";
                return false;
            }

            if (cardPayment.DataRecorderMetaData.DateCreated < DateTime.Now.Date.AddDays(-120))
            {
                reasonForFailure = "Can Not Refund against the last transaction, made on Card on file. As the valid date of making a request is within 120 days.";
                return false;
            }


            if (!ProcessorResponse.IsValidResponseString(cardPayment.ProcessorResponse))
            {
                reasonForFailure = "No valid Transaction Code found in the database, for the selected card on file.";
                return false;
            }

            return true;
        }

        public ProcessorResponse ChargefromCard(decimal amountToCharge, Name customerName, ChargeCard card, AddressEditModel address, string ipAddress, string cardProcessingUniqueId, string email)// Should use Address DO in place of Model
        {
            return _paymentProcessor.ChargeCreditCard(GetCreditCardProcesingInfo(amountToCharge, customerName, card, address, ipAddress, cardProcessingUniqueId,email));
        }

        public ProcessorResponse ApplyRefundtoNewCard(decimal amountToRefund, Name customerName, ChargeCard card, AddressEditModel address, string ipAddress, string cardProcessingUniqueId, string email)// Should use Address DO in place of Model
        {
            return
                _paymentProcessor.RefundRequestOnOtherCreditCard(
                    GetCreditCardProcesingInfo(amountToRefund > 0 ? (-1 * amountToRefund) : amountToRefund, customerName,
                                               card, address, ipAddress, cardProcessingUniqueId,email));
        }

        public ProcessorResponse ApplyRefundtoCardonFile(decimal amountToRefund, string cardNumber, DateTime expiryDate, string rawResponse)
        {
            var processorResponse = new ProcessorResponse(rawResponse);
            return _paymentProcessor.RefundRequestOnSameCreditCard(processorResponse.TransactionCode, cardNumber, expiryDate, (amountToRefund > 0 ? (-1 * amountToRefund) : amountToRefund).ToString());
        }

        public ProcessorResponse VoidRequest(string rawResponse)
        {
            var processorResponse = new ProcessorResponse(rawResponse);
            return _paymentProcessor.VoidRequest(processorResponse.TransactionCode);
        }

        //Yasir: This is really a factory method. june 10 2011
        private CreditCardProcessorProcessingInfo GetCreditCardProcesingInfo(decimal amount, Name customerName, ChargeCard card, AddressEditModel address, string ipAddress, string cardProcessingUniqueId, string email)// Should use Address DO in place of Model
        {
            return new CreditCardProcessorProcessingInfo
             {
                 CreditCardNo = card.Number,
                 SecurityCode = card.CVV,
                 ExpiryMonth = card.ExpirationDate.Month,
                 ExpiryYear = card.ExpirationDate.Year,
                 CardType = card.TypeId.ToString(),
                 Price = amount.ToString(),
                 FirstName = customerName.FirstName,
                 LastName = !string.IsNullOrEmpty(customerName.LastName) ? customerName.LastName : customerName.FirstName,
                 BillingAddress = address.StreetAddressLine1,
                 BillingCity = address.City,
                 BillingState = _stateRepository.GetState(address.StateId).Code,
                 BillingPostalCode = address.ZipCode,
                 BillingCountry = _countryRepository.GetCountryCode(address.CountryId),
                 Email = string.IsNullOrEmpty(email)?_settings.SupportEmail.ToString():email,
                 IpAddress = ipAddress,
                 Currency = "USD",
                 OrderId = cardProcessingUniqueId
             };
        }

    }
}