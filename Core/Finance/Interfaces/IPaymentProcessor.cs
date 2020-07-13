using System;
using Falcon.App.Core.Finance.Domain;

namespace Falcon.App.Core.Finance.Interfaces
{
    //TODO: One Interface contains two different behavior. Both for Echeck and Charge Card. Hence methods are left  Not implemented. Need to seperate these.
    public interface IPaymentProcessor
    {
        ProcessorResponse ChargeCreditCard(CreditCardProcessorProcessingInfo creditCardProcessorProcessingInfo);

        ProcessorResponse ChargeECheck(ElectronicCheckProcessorProcessingInfo electronicCheckProcessorProcessingInfo);

        ProcessorResponse RefundRequestOnSameCreditCard(string transactionId, string cardNumber, DateTime expiryDate, string amount);
        ProcessorResponse RefundRequestOnOtherCreditCard(CreditCardProcessorProcessingInfo creditCardProcessorProcessingInfo);
        ProcessorResponse VoidRequest(string transactionId);
        ProcessorResponse VoidRequestforaPreviousResponse(string rawResponse);
        ProcessorResponse AuthorizeOnly(CreditCardProcessorProcessingInfo processingInfo);

    }
}