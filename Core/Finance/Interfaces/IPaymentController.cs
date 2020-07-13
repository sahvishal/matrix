using System.Collections.Generic;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.ViewModels;

namespace Falcon.App.Core.Finance.Interfaces
{
    public interface IPaymentController
    {
        long SavePayment(PaymentInstrument paymentInstrument, string notes, long dataRecorderCreatorId);
        long SavePayment(IEnumerable<PaymentInstrument> paymentInstruments, string notes, 
            long dataRecorderCreatorId);

        long SavePayment(PaymentEditModel paymentEditModel, long dataRecorderOrgRoleUserId);
        void ManagePayment(PaymentEditModel paymentEditModel, long customerId, string ipAddress, string uniquePaymentReference);
        void VoidCreditCardGatewayRequests(PaymentEditModel paymentEditModel);
    }
}