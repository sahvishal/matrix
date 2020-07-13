using System;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;

namespace HealthYes.Web.UnitTests.Fakes
{
    internal class FakePaymentInstrument : PaymentInstrument
    {
        public override PaymentType PaymentType
        {
            get { throw new NotImplementedException(); }
        }
    }
}