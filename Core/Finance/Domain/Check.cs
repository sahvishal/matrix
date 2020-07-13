using System;
using Falcon.App.Core.Finance.Enum;

namespace Falcon.App.Core.Finance.Domain
{
    // NOTE: Check should not be a PaymentInstrument. Only its children should be (CheckPayment / ECheckPayment).
    // However, we are leaving this as-is for now due to dependencies on the medical vendor payment system.
    // This requires refactoring; Check should inherit from DomainObjectBase.
    // Scott & Yasir
    public class Check : PaymentInstrument
    {
        public string PayableTo { get; set; }
        public string CheckNumber { get; set; }
        public DateTime? CheckDate { get; set; }
        public string RoutingNumber { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string Memo { get; set; }
        public string AcountHolderName { get; set; }
        public bool IsElectronicCheck { get; set; }

        public Check()
        {}

        public Check(long id)
            : base(id)
        {}

        public override PaymentType PaymentType
        {
            get { return PaymentType.Check; }
        }

        public override string ToString()
        {
            return "Check";
        }
    }
}