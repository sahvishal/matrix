using System.Collections.Generic;
using Falcon.App.Core.Finance.Domain;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;

namespace Falcon.App.Infrastructure.Finance.Interfaces
{
    public interface IPaymentInstrumentFactory
    {
        List<PaymentInstrument> CreatePaymentInstruments(EntityCollection<CheckEntity> checkEntities);
        PaymentInstrument CreatePaymentInstrument(CheckEntity checkEntity);
    }
}