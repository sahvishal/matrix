using System;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Finance
{
    public interface IChargeCardService
    {
        ProcessorResponse ChargefromCard(decimal amountToCharge, Name customerName, ChargeCard card, AddressEditModel address, string ipAddress, string cardProcessingUniqueId, string email); // Should use Address DO in place of Model
        ProcessorResponse ApplyRefundtoNewCard(decimal amountToRefund, Name customerName, ChargeCard card, AddressEditModel address, string ipAddress, string cardProcessingUniqueId, string email); // Should use Address DO in place of Model

        ProcessorResponse ApplyRefundtoCardonFile(decimal amountToRefund, string cardNumber, DateTime expiryDate, string rawResponse);
        ProcessorResponse VoidRequest(string rawResponse);
        bool IsCardValidforRefund(ChargeCardPayment cardPayment, decimal amountToRefund, out string reasonForFailure);
    }
}